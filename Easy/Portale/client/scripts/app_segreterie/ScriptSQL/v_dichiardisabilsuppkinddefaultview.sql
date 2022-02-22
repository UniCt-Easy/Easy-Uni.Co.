
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
-- CREAZIONE VISTA dichiardisabilsuppkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiardisabilsuppkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[dichiardisabilsuppkinddefaultview]
GO

CREATE VIEW [dbo].[dichiardisabilsuppkinddefaultview] AS SELECT CASE WHEN dichiardisabilsuppkind.active = 'S' THEN 'Si' WHEN dichiardisabilsuppkind.active = 'N' THEN 'No' END AS dichiardisabilsuppkind_active, dichiardisabilsuppkind.ct AS dichiardisabilsuppkind_ct, dichiardisabilsuppkind.cu AS dichiardisabilsuppkind_cu, dichiardisabilsuppkind.description AS dichiardisabilsuppkind_description, dichiardisabilsuppkind.iddichiardisabilsuppkind, dichiardisabilsuppkind.lt AS dichiardisabilsuppkind_lt, dichiardisabilsuppkind.lu AS dichiardisabilsuppkind_lu, dichiardisabilsuppkind.sortcode AS dichiardisabilsuppkind_sortcode, dichiardisabilsuppkind.title, isnull('Tipologia: ' + dichiardisabilsuppkind.title + '; ','') as dropdown_title FROM [dbo].dichiardisabilsuppkind WITH (NOLOCK)  WHERE  dichiardisabilsuppkind.iddichiardisabilsuppkind IS NOT NULL 
GO

-- VERIFICA DI dichiardisabilsuppkinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dichiardisabilsuppkinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabilsuppkinddefaultview','varchar(2)','ASSISTENZA','dichiardisabilsuppkind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilsuppkinddefaultview','datetime','ASSISTENZA','dichiardisabilsuppkind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilsuppkinddefaultview','varchar(64)','ASSISTENZA','dichiardisabilsuppkind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabilsuppkinddefaultview','varchar(256)','ASSISTENZA','dichiardisabilsuppkind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilsuppkinddefaultview','datetime','ASSISTENZA','dichiardisabilsuppkind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilsuppkinddefaultview','varchar(64)','ASSISTENZA','dichiardisabilsuppkind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilsuppkinddefaultview','int','ASSISTENZA','dichiardisabilsuppkind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilsuppkinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilsuppkinddefaultview','int','ASSISTENZA','iddichiardisabilsuppkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilsuppkinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI dichiardisabilsuppkinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dichiardisabilsuppkinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'dichiardisabilsuppkinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('dichiardisabilsuppkinddefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

