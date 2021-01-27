
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_rivalutazioni_accessori_scaricati_beni_scaricati_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_rivalutazioni_accessori_scaricati_beni_scaricati_ente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE         PROCEDURE [esporta_rivalutazioni_accessori_scaricati_beni_scaricati_ente]
@year			int,
@idinventoryagency	int,
@date			datetime,
@idinv			int,
@flagcategory		char(1)

AS BEGIN

-------------------------------------------------------------------------------------
--RIVALUTAZIONI POSITIVE E NEGATIVE di Accessori SCARICATI di beni scaricati --------
-------------------------------------------------------------------------------------
	declare @firstlevelidinv int
	select @firstlevelidinv=idparent from inventorytreelink where idchild=@idinv and nlevel=1

   	DECLARE @firstday datetime
	SET @firstday = dateadd(yy, @year-1753, {d '1753-01-01'})

   	SELECT
		inventoryamortization.description 	as 'Tipo Rivalutazione',
		assetamortization.namortization		as 'Numero Rivalutazione',
		inventoryagency.codeinventoryagency	as 'Cod. Ente Inventario',
		inventoryagency.description  		as 'Ente Inventario', 
		inventory.description      		as 'Inventario',  
		inventorykind.description  		as 'Tipo Inventario',
		cespite.ninventory			as 'Numero inventario Cespite ',
		caricoaccessorio.nassetacquire 		as 'Carico Accessorio',
		caricoaccessorio.description   		as 'Descrizione',
		assetload.idassetloadkind 	as 'Codice Tipo Buono',
		assetload.yassetload     	as 'Eserc. Buono Carico',
		assetload.nassetload      	as 'Num. Buono Carico',
		categoriainventariale.codeinv	as 'Categoria Inventariale',
		ISNULL(ROUND(ISNULL(assetamortization.assetvalue,0) * 
		ISNULL(assetamortization.amortizationquota,0),2),0)  as 'Importo Rivalutazione'
	FROM assetacquire as caricoaccessorio
	join assetload on assetload.idassetload = caricoaccessorio.idassetload
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	
	JOIN asset as cespite
		ON cespite.idasset = accessorio.idasset

	JOIN assetunload as scaricocespite
		ON scaricocespite.idassetunload = cespite.idassetunload

	JOIN inventory
 		ON caricoaccessorio.idinventory = inventory.idinventory
	JOIN inventoryagency
		ON inventory.idinventoryagency = inventoryagency.idinventoryagency
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind   
	JOIN assetamortization
		ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization

	join inventorytreelink as linkcategoria
		on linkcategoria.idchild = caricoaccessorio.idinv and linkcategoria.nlevel = 1
	join inventorytree as categoriainventariale 
		on categoriainventariale.idinv = linkcategoria.idparent

	WHERE 	accessorio.idpiece>1 and cespite.idpiece =1
		AND (accessorio.idassetunload is not null or accessorio.flag&1 = 0) 
		AND inventoryamortization.flag&2 <> 0
		AND (	(ISNULL(assetamortization.amortizationquota,0)>0) 
			OR (assetamortization.flag&1 = 0) OR (assetamortization.idassetunload is not null)
		    )
		AND scaricocespite.yassetunload <= @year
		AND scaricocespite.adate <= @date
		AND scaricocespite.adate >= @firstday
		AND inventory.idinventoryagency = isnull(@idinventoryagency, inventory.idinventoryagency)
		AND (@idinv is null
			or linkcategoria.idparent = @firstlevelidinv AND @flagcategory = 'S'
			OR caricoaccessorio.idinv = @idinv AND @flagcategory = 'N')
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
