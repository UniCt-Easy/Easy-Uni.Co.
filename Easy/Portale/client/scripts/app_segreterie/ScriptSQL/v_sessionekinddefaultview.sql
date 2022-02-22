
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
-- CREAZIONE VISTA sessionekinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sessionekinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sessionekinddefaultview]
GO

CREATE VIEW [dbo].[sessionekinddefaultview] AS SELECT CASE WHEN sessionekind.active = 'S' THEN 'Si' WHEN sessionekind.active = 'N' THEN 'No' END AS sessionekind_active, sessionekind.ct AS sessionekind_ct, sessionekind.cu AS sessionekind_cu, sessionekind.description AS sessionekind_description, sessionekind.idsessionekind, sessionekind.lt AS sessionekind_lt, sessionekind.lu AS sessionekind_lu, sessionekind.sortcode AS sessionekind_sortcode, sessionekind.title, isnull('Tipologia: ' + sessionekind.title + '; ','') as dropdown_title FROM [dbo].sessionekind WITH (NOLOCK)  WHERE  sessionekind.idsessionekind IS NOT NULL 
GO

-- VERIFICA DI sessionekinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sessionekinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekinddefaultview','int','ASSISTENZA','idsessionekind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sessionekinddefaultview','varchar(2)','ASSISTENZA','sessionekind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekinddefaultview','datetime','ASSISTENZA','sessionekind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekinddefaultview','varchar(64)','ASSISTENZA','sessionekind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sessionekinddefaultview','varchar(256)','ASSISTENZA','sessionekind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekinddefaultview','datetime','ASSISTENZA','sessionekind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekinddefaultview','varchar(64)','ASSISTENZA','sessionekind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekinddefaultview','int','ASSISTENZA','sessionekind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI sessionekinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sessionekinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'sessionekinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sessionekinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER sessionekinddefaultview --
-- FINE GENERAZIONE SCRIPT --

