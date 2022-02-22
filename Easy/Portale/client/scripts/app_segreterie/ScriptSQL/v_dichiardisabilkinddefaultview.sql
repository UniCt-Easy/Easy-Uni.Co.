
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
-- CREAZIONE VISTA dichiardisabilkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiardisabilkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[dichiardisabilkinddefaultview]
GO

CREATE VIEW [dbo].[dichiardisabilkinddefaultview] AS SELECT CASE WHEN dichiardisabilkind.active = 'S' THEN 'Si' WHEN dichiardisabilkind.active = 'N' THEN 'No' END AS dichiardisabilkind_active, dichiardisabilkind.ct AS dichiardisabilkind_ct, dichiardisabilkind.cu AS dichiardisabilkind_cu, dichiardisabilkind.description AS dichiardisabilkind_description, dichiardisabilkind.iddichiardisabilkind, dichiardisabilkind.lt AS dichiardisabilkind_lt, dichiardisabilkind.lu AS dichiardisabilkind_lu, dichiardisabilkind.sortcode AS dichiardisabilkind_sortcode, dichiardisabilkind.specification AS dichiardisabilkind_specification, dichiardisabilkind.title, isnull('Titolo: ' + dichiardisabilkind.title + '; ','') + ' ' + isnull('Specifica: ' + dichiardisabilkind.specification + '; ','') as dropdown_title FROM [dbo].dichiardisabilkind WITH (NOLOCK)  WHERE  dichiardisabilkind.iddichiardisabilkind IS NOT NULL 
GO

-- VERIFICA DI dichiardisabilkinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dichiardisabilkinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabilkinddefaultview','varchar(2)','ASSISTENZA','dichiardisabilkind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilkinddefaultview','datetime','ASSISTENZA','dichiardisabilkind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilkinddefaultview','varchar(64)','ASSISTENZA','dichiardisabilkind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabilkinddefaultview','varchar(256)','ASSISTENZA','dichiardisabilkind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilkinddefaultview','datetime','ASSISTENZA','dichiardisabilkind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilkinddefaultview','varchar(64)','ASSISTENZA','dichiardisabilkind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilkinddefaultview','int','ASSISTENZA','dichiardisabilkind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabilkinddefaultview','varchar(50)','ASSISTENZA','dichiardisabilkind_specification','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilkinddefaultview','varchar(124)','ASSISTENZA','dropdown_title','124','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilkinddefaultview','int','ASSISTENZA','iddichiardisabilkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabilkinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI dichiardisabilkinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dichiardisabilkinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'dichiardisabilkinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('dichiardisabilkinddefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

