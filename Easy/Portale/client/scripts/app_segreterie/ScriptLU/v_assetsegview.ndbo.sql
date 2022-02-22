
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA assetsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetsegview]
GO

CREATE VIEW [assetsegview] AS 
SELECT  asset.amortizationquota AS asset_amortizationquota, asset.ct AS asset_ct, asset.cu AS asset_cu, asset.flag AS asset_flag, asset.idasset, asset.idasset_prev AS asset_idasset_prev, asset.idassetunload AS asset_idassetunload, asset.idcurrlocation AS asset_idcurrlocation, asset.idcurrman AS asset_idcurrman, asset.idcurrsubman AS asset_idcurrsubman,
 inventory.description AS inventory_description, asset.idinventory, asset.idinventoryamortization AS asset_idinventoryamortization, asset.idpiece, asset.idpiece_prev AS asset_idpiece_prev, asset.lifestart AS asset_lifestart, asset.lt AS asset_lt, asset.lu AS asset_lu, asset.multifield AS asset_multifield,
 assetacquire.description AS assetacquire_description, [dbo].inventorytree.codeinv AS inventorytree_codeinv, [dbo].inventorytree.description AS inventorytree_description, [dbo].inventorytree.idinv AS inventorytree_idinv, upb.codeupb AS upb_codeupb, upb.title AS upb_title, upb.idupb AS upb_idupb, asset.nassetacquire, asset.ninventory AS asset_ninventory, asset.rfid AS asset_rfid, asset.rtf AS asset_rtf,CASE WHEN asset.transmitted = 'S' THEN 'Si' WHEN asset.transmitted = 'N' THEN 'No' END AS asset_transmitted, asset.txt AS asset_txt,
 isnull('Inventario: ' + inventory.description + '; ','') + ' ' + isnull('Numero inventario: ' + CAST( asset.ninventory AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Codice Class. Inv.: ' + [dbo].inventorytree.codeinv + '; ','') + ' ' + isnull('Denominazione Class. Inv.: ' + [dbo].inventorytree.description + '; ','') + ' ' + isnull('Class. Inv. Class. Inv.: ' + CAST( [dbo].inventorytree.idinv AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Identificativo: ' + CAST( asset.idasset AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Codice UPB: ' + upb.codeupb + '; ','') + ' ' + isnull('Denominazione UPB: ' + upb.title + '; ','') + ' ' + isnull('UPB UPB: ' + upb.idupb + '; ','') + ' ' + isnull('Numero parte: ' + CAST( asset.idpiece AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Descrizione: ' + assetacquire.description + '; ','') + ' ' + isnull('Codice RFID: ' + asset.rfid + '; ','') as dropdown_title
FROM asset WITH (NOLOCK) 
LEFT OUTER JOIN inventory WITH (NOLOCK) ON asset.idinventory = inventory.idinventory
LEFT OUTER JOIN assetacquire WITH (NOLOCK) ON asset.nassetacquire = assetacquire.nassetacquire
LEFT OUTER JOIN [dbo].inventorytree WITH (NOLOCK) ON assetacquire.idinv = [dbo].inventorytree.idinv
LEFT OUTER JOIN upb WITH (NOLOCK) ON assetacquire.idupb = upb.idupb
WHERE  asset.idasset IS NOT NULL  AND asset.idpiece IS NOT NULL 
GO

