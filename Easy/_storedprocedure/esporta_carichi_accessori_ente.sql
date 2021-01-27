
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_carichi_accessori_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_carichi_accessori_ente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE    PROCEDURE [esporta_carichi_accessori_ente]
@year			int,
@idinventoryagency	int,
@date			datetime,
@idinv			int,
@flagcategory		char(1)

AS BEGIN
	declare @firstlevelidinv int
	select @firstlevelidinv = idparent
		from inventorytreelink
		where idchild = @idinv
		and nlevel = 1

	DECLARE @firstday datetime
	SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)
	-------------------------------------------------------------------------------------
	-------------------------- Carichi accessori ----------------------------------------
	-------------------------------------------------------------------------------------	
	SELECT
	inventoryagency.codeinventoryagency	as 'Cod. Ente Inventario' ,
	inventoryagency.description  	   as 'Ente Inventario', 
	inventory.description              as 'Inventario',  
	inventorykind.description    	   as 'Tipo Inventario',
	caricoaccessorio.nassetacquire 	   as 'Carico Accessorio',
	caricoaccessorio.description   	   as 'Descrizione',
	assetloadkind.codeassetloadkind    as 'Codice Tipo Buono',
	buonocaricoaccessorio.yassetload   as 'Eserc. Buono Carico',
	buonocaricoaccessorio.nassetload   as 'Num. Buono Carico',
	categoriainventariale.codeinv	   as 'Categoria inventariale',
	cespite.ninventory		           as 'Numero Inventario Cespite',
	assetview_current.start            as 'Importo Carichi Parte'
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN  assetview_current  
		ON assetview_current.idasset=accessorio.idasset and assetview_current.idpiece=accessorio.idpiece
	JOIN asset as cespite 
		ON accessorio.idasset = cespite.idasset
	JOIN assetload as buonocaricoaccessorio
		ON buonocaricoaccessorio.idassetload = caricoaccessorio.idassetload
	JOIN assetloadkind on assetloadkind.idassetloadkind=buonocaricoaccessorio.idassetloadkind
	JOIN inventory
		ON caricoaccessorio.idinventory = inventory.idinventory
	JOIN inventoryagency
		ON inventory.idinventoryagency = inventoryagency.idinventoryagency
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind   
	join inventorytreelink as linkcategoria
		on linkcategoria.idchild = caricoaccessorio.idinv
		and linkcategoria.nlevel = 1
	join inventorytree as categoriainventariale
		on categoriainventariale.idinv=linkcategoria.idparent
	WHERE 	accessorio.idpiece>1 and cespite.idpiece =1
		AND buonocaricoaccessorio.yassetload <= @year
		AND buonocaricoaccessorio.ratificationdate <= @date
		AND buonocaricoaccessorio.ratificationdate>=@firstday
		AND inventory.idinventoryagency=isnull(@idinventoryagency, inventory.idinventoryagency)
		AND (@idinv is null
			or categoriainventariale.idinv = @firstlevelidinv AND @flagcategory = 'S'
		        OR caricoaccessorio.idinv = @idinv AND @flagcategory = 'N')
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
