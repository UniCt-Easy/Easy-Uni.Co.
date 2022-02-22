
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
-- CREAZIONE VISTA menuwebdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[menuwebdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[menuwebdefaultview]
GO

CREATE VIEW [dbo].[menuwebdefaultview] AS SELECT  menuweb.editType AS menuweb_editType, menuweb.idmenuweb, menuwebparent.label AS menuwebparent_label, menuweb.idmenuwebparent, menuweb.label, menuweb.link AS menuweb_link, menuweb.sort AS menuweb_sort, menuweb.tableName AS menuweb_tableName, isnull('Label: ' + menuweb.label + '; ','') as dropdown_title FROM menuweb WITH (NOLOCK)  LEFT OUTER JOIN menuweb AS menuwebparent WITH (NOLOCK) ON menuweb.idmenuwebparent = menuwebparent.idmenuweb WHERE  menuweb.idmenuweb IS NOT NULL 
GO

-- VERIFICA DI menuwebdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'menuwebdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','menuwebdefaultview','nvarchar(259)','','dropdown_title','259','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','menuwebdefaultview','int','assistenza','idmenuweb','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebdefaultview','int','assistenza','idmenuwebparent','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','menuwebdefaultview','nvarchar(250)','assistenza','label','250','S','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebdefaultview','nvarchar(60)','assistenza','menuweb_editType','60','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebdefaultview','nvarchar(250)','assistenza','menuweb_link','250','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebdefaultview','int','assistenza','menuweb_sort','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebdefaultview','nvarchar(60)','assistenza','menuweb_tableName','60','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuwebdefaultview','nvarchar(250)','assistenza','menuwebparent_label','250','N','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI menuwebdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'menuwebdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'menuwebdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('menuwebdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

