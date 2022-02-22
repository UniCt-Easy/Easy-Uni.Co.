
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


-- CREAZIONE VISTA assetdiarydocenteview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetdiarydocenteview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetdiarydocenteview]
GO

CREATE VIEW [assetdiarydocenteview] AS 
SELECT  assetdiary.idassetdiary,
 inventory.description AS inventory_description, asset.idinventory AS asset_idinventory, asset.ninventory AS asset_ninventory, asset.idasset AS asset_idasset, asset.idpiece AS asset_idpiece, assetacquire.description AS assetacquire_description, asset.nassetacquire AS asset_nassetacquire, asset.rfid AS asset_rfid, assetdiary.idpiece, assetdiary.idasset AS assetdiary_idasset,
 progetto.titolobreve AS progetto_titolobreve, assetdiary.idprogetto, assetdiary.idreg AS assetdiary_idreg,
 workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, assetdiary.idworkpackage, assetdiary.ct AS assetdiary_ct, assetdiary.orepreventivate AS assetdiary_orepreventivate, assetdiary.cu AS assetdiary_cu, assetdiary.lt AS assetdiary_lt, assetdiary.lu AS assetdiary_lu,
 isnull('Descrizione Inventario: ' + inventory.description + '; ','') + ' ' + isnull((Select top 1 'Inventario: ' +CAST( idinventory AS NVARCHAR(64)) + '; ' + 'Numero inventario: ' +CAST( ninventory AS NVARCHAR(64)) + '; ' + 'Identificativo: ' +CAST( idasset AS NVARCHAR(64)) + '; ' + 'Numero parte: ' +CAST( idpiece AS NVARCHAR(64)) + '; ' + 'Descrizione: ' +CAST( nassetacquire AS NVARCHAR(64)) + '; ' + 'Codice RFID: ' +rfid from asset x where x.idasset = assetdiary.idasset AND x.idpiece = assetdiary.idpiece ) + '; ','') + ' ' + isnull((Select top 1 'Inventario: ' +CAST( idinventory AS NVARCHAR(64)) + '; ' + 'Numero inventario: ' +CAST( ninventory AS NVARCHAR(64)) + '; ' + 'Identificativo: ' +CAST( idasset AS NVARCHAR(64)) + '; ' + 'Numero parte: ' +CAST( idpiece AS NVARCHAR(64)) + '; ' + 'Descrizione: ' +CAST( nassetacquire AS NVARCHAR(64)) + '; ' + 'Codice RFID: ' +rfid from asset x where x.idasset = assetdiary.idasset AND x.idpiece = assetdiary.idpiece ) + '; ','') + ' ' + isnull((Select top 1 'Inventario: ' +CAST( idinventory AS NVARCHAR(64)) + '; ' + 'Numero inventario: ' +CAST( ninventory AS NVARCHAR(64)) + '; ' + 'Identificativo: ' +CAST( idasset AS NVARCHAR(64)) + '; ' + 'Numero parte: ' +CAST( idpiece AS NVARCHAR(64)) + '; ' + 'Descrizione: ' +CAST( nassetacquire AS NVARCHAR(64)) + '; ' + 'Codice RFID: ' +rfid from asset x where x.idasset = assetdiary.idasset AND x.idpiece = assetdiary.idpiece ) + '; ','') + ' ' + isnull('Descrizione Descrizione: ' + assetacquire.description + '; ','') + ' ' + isnull('Bene strumentale: ' + asset.rfid + '; ','') + ' ' + isnull('Progetto: ' + progetto.titolobreve + '; ','') as dropdown_title
FROM assetdiary WITH (NOLOCK) 
LEFT OUTER JOIN asset WITH (NOLOCK) ON assetdiary.idasset = asset.idasset AND assetdiary.idpiece = asset.idpiece
LEFT OUTER JOIN inventory WITH (NOLOCK) ON asset.idinventory = inventory.idinventory
LEFT OUTER JOIN assetacquire WITH (NOLOCK) ON asset.nassetacquire = assetacquire.nassetacquire
LEFT OUTER JOIN progetto WITH (NOLOCK) ON assetdiary.idprogetto = progetto.idprogetto
LEFT OUTER JOIN workpackage WITH (NOLOCK) ON assetdiary.idworkpackage = workpackage.idworkpackage
WHERE  assetdiary.idassetdiary IS NOT NULL  AND assetdiary.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI assetdiarydocenteview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetdiarydocenteview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','int','ASSISTENZA','asset_idasset','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','int','ASSISTENZA','asset_idinventory','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','int','ASSISTENZA','asset_idpiece','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','int','ASSISTENZA','asset_nassetacquire','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','int','ASSISTENZA','asset_ninventory','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','varchar(30)','ASSISTENZA','asset_rfid','30','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','varchar(150)','ASSISTENZA','assetacquire_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocenteview','datetime','ASSISTENZA','assetdiary_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocenteview','varchar(64)','ASSISTENZA','assetdiary_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocenteview','int','ASSISTENZA','assetdiary_idasset','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocenteview','int','ASSISTENZA','assetdiary_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocenteview','datetime','ASSISTENZA','assetdiary_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocenteview','varchar(64)','ASSISTENZA','assetdiary_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','int','ASSISTENZA','assetdiary_orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocenteview','nvarchar(3716)','ASSISTENZA','dropdown_title','3716','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocenteview','int','ASSISTENZA','idassetdiary','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','int','ASSISTENZA','idpiece','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocenteview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocenteview','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','varchar(50)','ASSISTENZA','inventory_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','nvarchar(2048)','ASSISTENZA','progetto_titolobreve','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','nvarchar(2048)','ASSISTENZA','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocenteview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI assetdiarydocenteview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetdiarydocenteview')
UPDATE customobject set isreal = 'N' where objectname = 'assetdiarydocenteview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetdiarydocenteview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

