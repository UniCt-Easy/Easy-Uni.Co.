
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


--[DBO]--
-- CREAZIONE VISTA changeskinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[changeskinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[changeskinddefaultview]
GO

CREATE VIEW [dbo].[changeskinddefaultview] AS SELECT CASE WHEN changeskind.active = 'S' THEN 'Si' WHEN changeskind.active = 'N' THEN 'No' END AS changeskind_active, changeskind.description AS changeskind_description, [dbo].changes.title AS changes_title, changeskind.idchanges AS changeskind_idchanges, changeskind.idchangeskind, changeskind.lt AS changeskind_lt, changeskind.lu AS changeskind_lu, changeskind.sortcode AS changeskind_sortcode, changeskind.title, isnull('Tipologia: ' + changeskind.title + '; ','') as dropdown_title FROM [dbo].changeskind WITH (NOLOCK)  LEFT OUTER JOIN [dbo].changes WITH (NOLOCK) ON changeskind.idchanges = [dbo].changes.idchanges WHERE  changeskind.idchangeskind IS NOT NULL 
GO

-- VERIFICA DI changeskinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'changeskinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','changeskinddefaultview','varchar(256)','ASSISTENZA','changes_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','changeskinddefaultview','varchar(2)','ASSISTENZA','changeskind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','changeskinddefaultview','varchar(10)','ASSISTENZA','changeskind_description','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','changeskinddefaultview','int','ASSISTENZA','changeskind_idchanges','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskinddefaultview','datetime','ASSISTENZA','changeskind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskinddefaultview','varchar(64)','ASSISTENZA','changeskind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskinddefaultview','int','ASSISTENZA','changeskind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskinddefaultview','varchar(269)','ASSISTENZA','dropdown_title','269','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskinddefaultview','int','ASSISTENZA','idchangeskind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','changeskinddefaultview','varchar(256)','ASSISTENZA','title','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI changeskinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'changeskinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'changeskinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('changeskinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER changeskinddefaultview --
-- FINE GENERAZIONE SCRIPT --

