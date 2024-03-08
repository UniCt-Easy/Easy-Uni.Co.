
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_carichi_accessori_beni_scaricati_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_carichi_accessori_beni_scaricati_ente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE         PROCEDURE [esporta_carichi_accessori_beni_scaricati_ente]
@year			int,
@idinventoryagency	int,
@date			datetime,
@idinv			int,
@flagcategory		char(1)

AS BEGIN
	-------------------------------------------------------------------------------------
	-------------------------- Carichi accessori di beni scaricati ----------------------
	-------------------------------------------------------------------------------------	
	
	DECLARE @firstday datetime
	SET @firstday = CONVERT(datetime, '01/01/' + CONVERT(char(4),@year), 105)

	declare @firstlevelidinv int
	select @firstlevelidinv=idparent from inventorytreelink where idchild=@idinv and nlevel=1
	
	SELECT
	inventoryagency.codeinventoryagency 	as 'Cod. Ente Inventario' , 
	inventoryagency.description  		as 'Ente Inventario', 
	inventory.description      		as 'Inventario',  
	inventorykind.description  		as 'Tipo Inventario',
	cespite.ninventory			as 'Numero inventario Cespite ',
	caricoaccessorio.nassetacquire 		as 'Carico Accessorio',
	caricoaccessorio.description   		as 'Descrizione',
	assetloadkind.codeassetloadkind 	as 'Codice Tipo Buono',
	assetload.yassetload     	as 'Eserc. Buono Carico',
	assetload.nassetload      	as 'Num. Buono Carico',
	categoriainventariale.codeinv	as 'Categoria Inventariale',
	ISNULL(
				ROUND(ISNULL(caricoaccessorio.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(caricoaccessorio.discount, 0))),2)
				+ ROUND(ISNULL(caricoaccessorio.tax,0) / caricoaccessorio.number,2)
				- ROUND(ISNULL(caricoaccessorio.abatable,0) / caricoaccessorio.number,2)
			,0)	as 'Importo Carichi Accessori'
	FROM assetacquire as caricoaccessorio 
	join assetload on assetload.idassetload=caricoaccessorio.idassetload
	join assetloadkind on assetloadkind.idassetloadkind=assetload.idassetloadkind
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN asset as cespite
		ON cespite.idasset = accessorio.idasset
	JOIN assetunload
		ON assetunload.idassetunload = cespite.idassetunload
	JOIN inventory
		ON caricoaccessorio.idinventory = inventory.idinventory
	JOIN inventoryagency
		ON inventory.idinventoryagency = inventoryagency.idinventoryagency
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind   
	join inventorytreelink as linkcategoria on linkcategoria.idchild = caricoaccessorio.idinv and linkcategoria.nlevel=1
	join inventorytree as categoriainventariale on categoriainventariale.idinv=linkcategoria.idparent
	WHERE 	accessorio.idpiece>1 
		AND cespite.idpiece =1
		AND (assetload.yassetload is not null)-- or caricoaccessorio.flag & 1 = 0) 
		AND assetunload.yassetunload <= @year
		AND assetunload.adate between @firstday and @date
		AND inventory.idinventoryagency = isnull(@idinventoryagency, inventory.idinventoryagency)
		AND (@idinv is null 
			OR (categoriainventariale.idinv = @firstlevelidinv AND @flagcategory = 'S')
		        OR (caricoaccessorio.idinv = @idinv AND @flagcategory = 'N'))
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
