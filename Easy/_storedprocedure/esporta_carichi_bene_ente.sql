
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_carichi_bene_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_carichi_bene_ente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE     PROCEDURE [esporta_carichi_bene_ente]
@year	int,
@idinventoryagency	int,
@date			datetime,
@idinv			int,
@flagcategory		char(1)

------------------------------------------------------------------------
-- CONSIDERA I CARICHI BENE --------------------------------------------
------------------------------------------------------------------------
AS BEGIN
	DECLARE @firstday datetime
	SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)

	declare @firstlevelidinv int
	select @firstlevelidinv = idparent
		from inventorytreelink
		where inventorytreelink.idchild=@idinv and nlevel=1

	-------------------------------------------------------------------------------------
	-------------------------- Carichi cespiti  -----------------------------------------
	-------------------------------------------------------------------------------------
	SELECT
	inventoryagency.codeinventoryagency         as 'Cod. Ente Inventario' , 
	inventoryagency.description  	as 'Ente Inventario', 
	inventory.description      	    as 'Inventario',  
	inventorykind.description  	    as 'Tipo Inventario',
	assetacquire.nassetacquire 	    as 'Carico Bene',
	assetacquire.description   	    as 'Descrizione',
	assetloadkind.codeassetloadkind	    as 'Codice Tipo Buono',
	assetload.yassetload     	    as 'Eserc. Buono Carico',
	assetload.nassetload       	    as 'Num. Buono Carico',
	categoriainventariale.codeinv	    as 'Categoria inventariale',
	asset.ninventory				as 'Numero Inventario',
	assetview_current.start			as 'Importo Carichi Bene'
	FROM assetacquire
	JOIN asset
		ON assetacquire.nassetacquire = asset.nassetacquire
	JOIN  assetview_current 
		on assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
	JOIN assetload
		ON assetload.idassetload = assetacquire.idassetload
	join assetloadkind
		on assetloadkind.idassetloadkind = assetload.idassetloadkind
	JOIN inventory  
		ON assetacquire.idinventory=inventory.idinventory
	JOIN inventoryagency
		ON inventory.idinventoryagency = inventoryagency.idinventoryagency
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind
	JOIN inventorytreelink linkcategoria
		on linkcategoria.idchild=assetacquire.idinv and linkcategoria.nlevel=1
	JOIN inventorytree as categoriainventariale
		on categoriainventariale.idinv=linkcategoria.idparent
	WHERE  asset.idpiece = 1
		AND assetload.yassetload <= @year
		AND ( assetload.ratificationdate>=@firstday and assetload.ratificationdate <= @date)  
		AND inventory.idinventoryagency = isnull(@idinventoryagency, inventory.idinventoryagency)
		AND (@idinv is null
			or categoriainventariale.idinv = @firstlevelidinv AND @flagcategory = 'S'
			OR assetacquire.idinv = @idinv AND @flagcategory = 'N')
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
