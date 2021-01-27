
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_scarichi_cespite_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_scarichi_cespite_ente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE         PROCEDURE [esporta_scarichi_cespite_ente]
@year			int,
@idinventoryagency	int,
@date			datetime,
@idinv			int,
@flagcategory		char(1)
--esporta_scarichi_cespite_ente '2013', null, {ts '2013-05-09 00:00:00.000'}, null, 'S'
AS BEGIN

	DECLARE @firstlevelidinv int
	SELECT @firstlevelidinv = idparent
		FROM inventorytreelink
		WHERE idchild = @idinv AND nlevel = 1

	DECLARE @firstday datetime
	SET @firstday = CONVERT(datetime, '01/01/' + CONVERT(char(4),@year), 105)

	DECLARE @levelInput tinyint
	SELECT @levelInput = nlevel FROM inventorytree WHERE idinv = @idinv
	SET @levelInput = isnull(@levelInput,1)
-------------------------------------------------------------------------------------
-------------------------- Scarichi Cespite -----------------------------------------
-------------------------------------------------------------------------------------
--    	Considera i buoni di carico precedenti al 2005 
	SELECT
	inventoryagency.codeinventoryagency	as 'Cod. Ente Inventario',
	inventoryagency.description  	as 'Ente Inventario', 
	inventory.description     	as 'Inventario',  
	inventorykind.description  	as 'Tipo Inventario',
	assetacquire.nassetacquire 	as 'Carico Bene',
	assetacquire.description   	as 'Descrizione',
	assetunloadkind.codeassetunloadkind 	as 'Codice Tipo Buono',
	assetunload.yassetunload        as 'Eserc. Buono Scarico',
	assetunload.nassetunload        as 'Num. Buono Scarico',
	CASE WHEN @flagcategory = 'S'
			THEN categoriainventariale.codeinv
			ELSE classificazioneCespite.codeinv
		END
	AS 'Classificazione inventariale',
	assetview_current.start AS 'Importo scaricato'
	FROM assetacquire
	left outer join assetload
		on assetacquire.idassetload = assetload.idassetload
	JOIN asset
		ON assetacquire.nassetacquire = asset.nassetacquire
	JOIN  assetview_current  
		on assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
	JOIN assetunload
		ON assetunload.idassetunload = asset.idassetunload
	join assetunloadkind
		on assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
 	JOIN inventory
 		ON assetacquire.idinventory = inventory.idinventory
	JOIN inventoryagency
		ON inventory.idinventoryagency = inventoryagency.idinventoryagency
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind
	join inventorytreelink as linkcategoria
		on linkcategoria.idchild = assetacquire.idinv and linkcategoria.nlevel = 1
	join inventorytree as categoriainventariale
		on categoriainventariale.idinv = linkcategoria.idparent
	join inventorytreelink as linkclassificazione
		on linkclassificazione.idchild = assetacquire.idinv and linkclassificazione.nlevel = @levelInput
	join inventorytree as classificazioneinventariale
		on classificazioneinventariale.idinv = linkclassificazione.idparent
	join inventorytree as classificazioneCespite
		on classificazioneCespite.idinv = assetacquire.idinv
	WHERE asset.idpiece = 1 
		AND assetunload.yassetunload <= @year
		AND assetunload.adate between @firstday and @date
		AND inventory.idinventoryagency = isnull(@idinventoryagency, inventory.idinventoryagency)
		AND (@idinv is null
			OR categoriainventariale.idinv = @firstlevelidinv AND @flagcategory = 'S'
	     		 OR linkclassificazione.idparent = @idinv AND @flagcategory = 'N')
			
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


