
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


-- CREAZIONE VISTA assetdiaryoraview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetdiaryoraview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetdiaryoraview]
GO



CREATE VIEW [assetdiaryoraview] AS 
SELECT  assetdiary.idreg, assetdiary.idasset, assetdiary.idpiece, assetdiary.idassetdiary,assetdiaryora.start, assetdiaryora.stop, 
'<b>Progetto:</b> ' + isnull(progetto.titolobreve,'') + 
'; <b>Workpackage:</b> ' + isnull(workpackage.title,'') + 
'; <b>Operatore:</b> ' + isnull(registrydefaultview.dropdown_title,'') + 
'; <b>Bene:</b> ' + isnull('' + CAST(inventory.description AS NVARCHAR(64)) + ' Inventario' ,'') + ' ' + isnull('' + CAST( asset.idasset AS NVARCHAR(64)) + ' Identificativo' ,'') + ' ' + 
isnull('' + CAST( asset.idpiece AS NVARCHAR(64)) + ' Numero parte' ,'') + ' ' + isnull('' + CAST(assetacquire.description AS NVARCHAR(64)) + ' Descrizione' ,'') + ' ' + 
isnull('' + CAST( asset.ninventory AS NVARCHAR(64)) + ' Numero inventario' ,'') + ' ' + isnull('' + asset.rfid,'')
as title
FROM  assetdiaryora WITH (NOLOCK) 
LEFT OUTER JOIN assetdiary WITH (NOLOCK) ON assetdiary.idassetdiary = assetdiaryora.idassetdiary
LEFT OUTER JOIN asset WITH (NOLOCK) ON asset.idasset = assetdiary.idasset and asset.idpiece = assetdiary.idpiece
LEFT OUTER JOIN inventory WITH (NOLOCK) ON asset.idinventory = inventory.idinventory 
LEFT OUTER JOIN assetacquire WITH (NOLOCK) ON asset.nassetacquire = assetacquire.nassetacquire 
LEFT OUTER JOIN progetto WITH (NOLOCK) ON progetto.idprogetto = assetdiary.idprogetto 
LEFT OUTER JOIN workpackage WITH (NOLOCK) ON workpackage.idworkpackage = assetdiary.idworkpackage
LEFT OUTER JOIN dbo.registrydefaultview WITH (NOLOCK) ON dbo.registrydefaultview.idreg = assetdiary.idreg
WHERE  asset.idasset IS NOT NULL  AND asset.idpiece IS NOT NULL 

GO

-- VERIFICA DI assetdiaryoraview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetdiaryoraview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryoraview','int','assistenza','idasset','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryoraview','int','assistenza','idassetdiary','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryoraview','int','assistenza','idpiece','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryoraview','int','assistenza','idreg','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryoraview','datetime','assistenza','start','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryoraview','datetime','assistenza','stop','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryoraview','nvarchar(4000)','assistenza','title','4000','S','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI assetdiaryoraview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetdiaryoraview')
UPDATE customobject set isreal = 'N' where objectname = 'assetdiaryoraview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetdiaryoraview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

