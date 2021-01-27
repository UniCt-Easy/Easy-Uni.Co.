
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_beni_scaricati_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_beni_scaricati_ente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--esporta_beni_scaricati_ente 2009, 1,1,100

CREATE    PROCEDURE [esporta_beni_scaricati_ente]
(
	@year			int,
	@idinventoryagency	int,
	@startnumber		int,
	@stopnumber			int 
)
	AS BEGIN
	SELECT
		inventoryagency.description  	as 'Ente Inventario', 
		inventory.description     		as 'Inventario',  
		assetunloadkind.description 	as 'Tipo Buono Scarico',
		convert(varchar(4),assetunload.yassetunload) + 
		'/' + convert(varchar(6),assetunload.nassetunload) as 'Eserc./Numero',
		assetunloadmotive.description   as 'Causale Scarico', 
		assetunload.adate				as 'Data Cont. Buono Scarico',
		CASE
		WHEN asset.idpiece = 1 THEN 'Cespite'		
		ELSE 'Accessorio'
		END as 'Cespite/Acc.',
		CASE
		WHEN asset.idpiece = 1 THEN asset.ninventory		
		ELSE cespite.ninventory
		END as 'Num. inventario',
		assetacquire.description	as 'Descrizione',
		assetloadmotive.description	as 'Causale Carico',
		assetview_current.start as 'Importo Caricato',
		inventorytree.codeinv + ' - ' + inventorytree.description	as 'Classificazione'
	FROM 
		asset
	JOIN 	asset as cespite
		ON cespite.idasset = asset.idasset
	JOIN  assetview_current  
		ON assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
	JOIN 	assetunload
		ON asset.idassetunload = assetunload.idassetunload
	JOIN 	assetacquire
		ON asset.nassetacquire = assetacquire.nassetacquire
	JOIN 	assetloadmotive
		ON assetacquire.idmot = assetloadmotive.idmot
	JOIN    inventorytree
		ON assetacquire.idinv = inventorytree.idinv 
	LEFT OUTER JOIN registry
		ON assetunload.idreg = registry.idreg
	LEFT OUTER JOIN assetunloadmotive
		ON assetunload.idmot = assetunloadmotive.idmot 
	JOIN assetunloadkind
		on assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
 	JOIN inventory
 		ON assetunloadkind.idinventory = inventory.idinventory
	JOIN  inventoryagency
		ON inventory.idinventoryagency = inventoryagency.idinventoryagency
	WHERE assetunload.yassetunload = @year
	AND cespite.idpiece = 1
	AND inventoryagency.idinventoryagency = @idinventoryagency
	AND assetunload.nassetunload BETWEEN @startnumber AND @stopnumber
	ORDER BY inventoryagency.description,assetunload.yassetunload,assetunload.nassetunload,
	asset.idasset,asset.idpiece
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
