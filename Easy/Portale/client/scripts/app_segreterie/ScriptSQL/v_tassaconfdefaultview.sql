
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
-- CREAZIONE VISTA tassaconfdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tassaconfdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tassaconfdefaultview]
GO

CREATE VIEW [dbo].[tassaconfdefaultview] AS SELECT  tassaconf.aa, tassaconf.ct AS tassaconf_ct, tassaconf.cu AS tassaconf_cu, [dbo].costoscontodef.title AS costoscontodef_title, tassaconf.idcostoscontodef, tassaconf.idtassaconf, [dbo].tassaconfkind.title AS tassaconfkind_title, tassaconf.idtassaconfkind AS tassaconf_idtassaconfkind, tassaconf.lt AS tassaconf_lt, tassaconf.lu AS tassaconf_lu, tassaconf.title, isnull('Titolo: ' + tassaconf.title + '; ','') as dropdown_title FROM [dbo].tassaconf WITH (NOLOCK)  LEFT OUTER JOIN [dbo].costoscontodef WITH (NOLOCK) ON tassaconf.idcostoscontodef = [dbo].costoscontodef.idcostoscontodef LEFT OUTER JOIN [dbo].tassaconfkind WITH (NOLOCK) ON tassaconf.idtassaconfkind = [dbo].tassaconfkind.idtassaconfkind WHERE  tassaconf.idtassaconf IS NOT NULL 
GO

-- VERIFICA DI tassaconfdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tassaconfdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfdefaultview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaconfdefaultview','nvarchar(2024)','ASSISTENZA','costoscontodef_title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfdefaultview','varchar(2034)','ASSISTENZA','dropdown_title','2034','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfdefaultview','int','ASSISTENZA','idcostoscontodef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfdefaultview','int','ASSISTENZA','idtassaconf','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfdefaultview','datetime','ASSISTENZA','tassaconf_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfdefaultview','varchar(64)','ASSISTENZA','tassaconf_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfdefaultview','int','ASSISTENZA','tassaconf_idtassaconfkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfdefaultview','datetime','ASSISTENZA','tassaconf_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfdefaultview','varchar(64)','ASSISTENZA','tassaconf_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaconfdefaultview','varchar(50)','ASSISTENZA','tassaconfkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaconfdefaultview','varchar(2024)','ASSISTENZA','title','2024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tassaconfdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tassaconfdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'tassaconfdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('tassaconfdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

