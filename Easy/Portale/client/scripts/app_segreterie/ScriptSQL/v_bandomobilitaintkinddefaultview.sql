
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
-- CREAZIONE VISTA bandomobilitaintkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bandomobilitaintkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[bandomobilitaintkinddefaultview]
GO

CREATE VIEW [dbo].[bandomobilitaintkinddefaultview] AS SELECT CASE WHEN bandomobilitaintkind.active = 'S' THEN 'Si' WHEN bandomobilitaintkind.active = 'N' THEN 'No' END AS bandomobilitaintkind_active, bandomobilitaintkind.ct AS bandomobilitaintkind_ct, bandomobilitaintkind.cu AS bandomobilitaintkind_cu, bandomobilitaintkind.idbandomobilitaintkind, bandomobilitaintkind.lt AS bandomobilitaintkind_lt, bandomobilitaintkind.lu AS bandomobilitaintkind_lu, bandomobilitaintkind.sortcode AS bandomobilitaintkind_sortcode, bandomobilitaintkind.title, isnull('Tipologia: ' + bandomobilitaintkind.title + '; ','') as dropdown_title FROM [dbo].bandomobilitaintkind WITH (NOLOCK)  WHERE  bandomobilitaintkind.idbandomobilitaintkind IS NOT NULL 
GO

-- VERIFICA DI bandomobilitaintkinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'bandomobilitaintkinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkinddefaultview','varchar(2)','ASSISTENZA','bandomobilitaintkind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkinddefaultview','datetime','ASSISTENZA','bandomobilitaintkind_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkinddefaultview','varchar(60)','ASSISTENZA','bandomobilitaintkind_cu','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkinddefaultview','datetime','ASSISTENZA','bandomobilitaintkind_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkinddefaultview','varchar(60)','ASSISTENZA','bandomobilitaintkind_lu','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkinddefaultview','int','ASSISTENZA','bandomobilitaintkind_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomobilitaintkinddefaultview','nvarchar(213)','ASSISTENZA','dropdown_title','213','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomobilitaintkinddefaultview','int','ASSISTENZA','idbandomobilitaintkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkinddefaultview','nvarchar(200)','ASSISTENZA','title','200','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI bandomobilitaintkinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'bandomobilitaintkinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'bandomobilitaintkinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('bandomobilitaintkinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER bandomobilitaintkinddefaultview --
-- FINE GENERAZIONE SCRIPT --

