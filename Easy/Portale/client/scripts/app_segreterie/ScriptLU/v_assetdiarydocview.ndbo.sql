
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


-- CREAZIONE VISTA assetdiarydocview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetdiarydocview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetdiarydocview]
GO

CREATE VIEW [assetdiarydocview] AS 
SELECT  assetdiary.ct AS assetdiary_ct, assetdiary.cu AS assetdiary_cu, assetdiary.idasset AS assetdiary_idasset, assetdiary.idassetdiary,
 inventory.description AS inventory_description, inventory.idinventory AS inventory_idinventory, asset.ninventory AS asset_ninventory, asset.idasset AS asset_idasset, asset.idpiece AS asset_idpiece, assetacquire.description AS assetacquire_description, assetacquire.idinv AS assetacquire_idinv, assetacquire.idupb AS assetacquire_idupb, assetacquire.nassetacquire AS assetacquire_nassetacquire, asset.rfid AS asset_rfid, assetdiary.idpiece,
 progetto.titolobreve AS progetto_titolobreve, assetdiary.idprogetto, assetdiary.idreg AS assetdiary_idreg,
 workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, assetdiary.idworkpackage, assetdiary.lt AS assetdiary_lt, assetdiary.lu AS assetdiary_lu, assetdiary.orepreventivate AS assetdiary_orepreventivate,
 isnull('Inventario Inventario: ' + CAST( inventory.idinventory AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Descrizione Inventario: ' + inventory.description + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.ninventory AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.idasset AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.idpiece AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + asset.rfid + '; ','') + ' ' + isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Descrizione Descrizione: ' + assetacquire.description + '; ','') + ' ' + isnull('Class. Inv. Descrizione: ' + CAST( assetacquire.idinv AS NVARCHAR(64)) + '; ','') + ' ' + isnull('UPB Descrizione: ' + assetacquire.idupb + '; ','') + ' ' + isnull('Descrizione Descrizione: ' + CAST( assetacquire.nassetacquire AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM assetdiary WITH (NOLOCK) 
LEFT OUTER JOIN asset WITH (NOLOCK) ON assetdiary.idasset = asset.idasset AND assetdiary.idpiece = asset.idpiece
LEFT OUTER JOIN inventory WITH (NOLOCK) ON asset.idinventory = inventory.idinventory
LEFT OUTER JOIN assetacquire WITH (NOLOCK) ON asset.nassetacquire = assetacquire.nassetacquire
LEFT OUTER JOIN progetto WITH (NOLOCK) ON assetdiary.idprogetto = progetto.idprogetto
LEFT OUTER JOIN workpackage WITH (NOLOCK) ON assetdiary.idworkpackage = workpackage.idworkpackage
WHERE  assetdiary.idassetdiary IS NOT NULL  AND assetdiary.idworkpackage IS NOT NULL 
GO

