
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


-- CREAZIONE VISTA menuwebtreeview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[menuwebtreeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[menuwebtreeview]
GO

CREATE VIEW [dbo].[menuwebtreeview] AS 
SELECT  menuweb.editType AS menuweb_editType, menuweb.idmenuweb,
 menuwebparent.label AS menuwebparent_label, menuweb.idmenuwebparent, menuweb.label, menuweb.link AS menuweb_link, menuweb.sort AS menuweb_sort, menuweb.tableName AS menuweb_tableName,
 isnull('Label: ' + menuweb.label + '; ','') as dropdown_title
FROM [dbo].menuweb WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].menuweb AS menuwebparent WITH (NOLOCK) ON menuweb.idmenuwebparent = menuwebparent.idmenuweb
WHERE  menuweb.idmenuweb IS NOT NULL 
GO

-- VERIFICA DI menuwebtreeview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'menuwebtreeview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','menuwebtreeview','nvarchar(259)','ASSISTENZA','dropdown_title','259','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','menuwebtreeview','int','ASSISTENZA','idmenuweb','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebtreeview','int','ASSISTENZA','idmenuwebparent','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','menuwebtreeview','nvarchar(250)','ASSISTENZA','label','250','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebtreeview','nvarchar(60)','ASSISTENZA','menuweb_editType','60','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebtreeview','nvarchar(250)','ASSISTENZA','menuweb_link','250','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebtreeview','int','ASSISTENZA','menuweb_sort','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebtreeview','nvarchar(60)','ASSISTENZA','menuweb_tableName','60','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebtreeview','nvarchar(250)','ASSISTENZA','menuwebparent_label','250','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI menuwebtreeview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'menuwebtreeview')
UPDATE customobject set isreal = 'N' where objectname = 'menuwebtreeview'
ELSE
INSERT INTO customobject (objectname, isreal) values('menuwebtreeview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

