
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


-- CREAZIONE VISTA appellokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appellokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[appellokinddefaultview]
GO

CREATE VIEW [dbo].[appellokinddefaultview] AS 
SELECT CASE WHEN appellokind.active = 'S' THEN 'Si' WHEN appellokind.active = 'N' THEN 'No' END AS appellokind_active, appellokind.description AS appellokind_description, appellokind.idappellokind, appellokind.lt AS appellokind_lt, appellokind.lu AS appellokind_lu, appellokind.sortcode AS appellokind_sortcode, appellokind.title,
 isnull('Titolo: ' + appellokind.title + '; ','') as dropdown_title
FROM [dbo].appellokind WITH (NOLOCK) 
WHERE  appellokind.idappellokind IS NOT NULL 
GO

-- VERIFICA DI appellokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'appellokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellokinddefaultview','varchar(2)','ASSISTENZA','appellokind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellokinddefaultview','varchar(256)','ASSISTENZA','appellokind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellokinddefaultview','datetime','ASSISTENZA','appellokind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellokinddefaultview','varchar(64)','ASSISTENZA','appellokind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellokinddefaultview','int','ASSISTENZA','appellokind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellokinddefaultview','varchar(60)','ASSISTENZA','dropdown_title','60','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellokinddefaultview','int','ASSISTENZA','idappellokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellokinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI appellokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'appellokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'appellokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('appellokinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER appellokinddefaultview --
-- FINE GENERAZIONE SCRIPT --

