
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_rivalutazioni_negative_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_rivalutazioni_negative_ente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE         PROCEDURE [esporta_rivalutazioni_negative_ente]
@year			int,
@idinventoryagency	int,
@date			datetime,
@idinv			int,
@flagcategory		char(1)

AS BEGIN
-------------------------------------------------------------------------------------
----- Rivalutazioni negative ufficiali (di BENI E DI ACCESSORI) ---------------------
-------------------------------------------------------------------------------------

	DECLARE @firstday datetime
	SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)
	
	declare @firstlevelidinv int
	select @firstlevelidinv = idparent from inventorytreelink where idchild = @idinv and nlevel = 1

	SELECT	inventoryamortization.description 	as 'Tipo Rivalutazione',
		assetamortization.namortization		as 'Numero Rivalutazione',
		inventoryagency.codeinventoryagency		as 'Cod. Ente Inventario' ,
		inventoryagency.description  		as 'Ente Inventario', 
		inventory.description        		as 'Inventario',  
		CASE asset.idpiece 
			WHEN 1 THEN asset.ninventory
			ELSE null 	     
		END  					as 'Numero Inventario',
		CASE asset.idpiece 
			WHEN 1 THEN null
			ELSE cespite.ninventory 	     
		END				    	as 'Numero Inventario Cespite Principale',
		assetacquire.nassetacquire 	    	as 'Carico Cespite/Accessorio',
		assetacquire.description   	    	as 'Descrizione',
		assetloadkind.codeassetloadkind 	   	as 'Codice Tipo Buono',
		assetload.yassetload     	    	as 'Eserc. Buono Carico',
		assetload.nassetload             	as 'Num. Buono Carico',
		categoriainventariale.codeinv   	as 'Categoria Inventariale',
		ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2) as 'Importo Rivalutazione',
		assetunloadkind.description		as 'Tipo Buono Scarico',
		assetunload.yassetunload		as 'Eserc. Buono Scarico',
		assetunload.nassetunload		as 'Num. Buono Scarico'
	FROM assetacquire
	left outer join assetload on assetload.idassetload = assetacquire.idassetload
	left outer join assetloadkind on assetload.idassetloadkind = assetloadkind.idassetloadkind
	JOIN asset
		ON assetacquire.nassetacquire = asset.nassetacquire
	JOIN asset as cespite
		ON asset.idasset = cespite.idasset
	JOIN assetamortization
		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
	LEFT OUTER JOIN assetunload
		ON  assetamortization.idassetunload = assetunload.idassetunload
	LEFT OUTER JOIN assetunloadkind
		ON  assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
	JOIN inventory
		ON inventory.idinventory = assetacquire.idinventory
	JOIN inventoryagency
		ON inventory.idinventoryagency = inventoryagency.idinventoryagency
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind   
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	join inventorytreelink as linkcategoria
		on linkcategoria.idchild = assetacquire.idinv and linkcategoria.nlevel=1
	join inventorytree as categoriainventariale
		on categoriainventariale.idinv = linkcategoria.idparent
	WHERE  
		(assetacquire.flag&1 = 0 or assetacquire.idassetload is not null) 
		AND cespite.idpiece = 1
		AND inventoryamortization.flag&2 <> 0
		AND assetamortization.amortizationquota < 0 
		AND (assetamortization.flag&1 = 0 and assetamortization.adate between @firstday and @date
			or assetamortization.flag&1 <> 0 and assetunload.adate between @firstday and @date)
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
