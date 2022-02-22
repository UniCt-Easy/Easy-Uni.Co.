
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
-- CREAZIONE VISTA tassaistanzaconfdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tassaistanzaconfdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tassaistanzaconfdefaultview]
GO

CREATE VIEW [dbo].[tassaistanzaconfdefaultview] AS SELECT  tassaistanzaconf.aa, tassaistanzaconf.ct AS tassaistanzaconf_ct, tassaistanzaconf.cu AS tassaistanzaconf_cu, [dbo].costoscontodef.title AS costoscontodef_title, tassaistanzaconf.idcostoscontodef, [dbo].istanzakind.title AS istanzakind_title, tassaistanzaconf.idistanzakind, tassaistanzaconf.idtassaistanzaconf, tassaistanzaconf.lt AS tassaistanzaconf_lt, tassaistanzaconf.lu AS tassaistanzaconf_lu,CASE WHEN tassaistanzaconf.nullaosta = 'S' THEN 'Si' WHEN tassaistanzaconf.nullaosta = 'N' THEN 'No' END AS tassaistanzaconf_nullaosta, isnull('Tipo di istanza: ' + [dbo].istanzakind.title + '; ','') as dropdown_title FROM [dbo].tassaistanzaconf WITH (NOLOCK)  LEFT OUTER JOIN [dbo].costoscontodef WITH (NOLOCK) ON tassaistanzaconf.idcostoscontodef = [dbo].costoscontodef.idcostoscontodef LEFT OUTER JOIN [dbo].istanzakind WITH (NOLOCK) ON tassaistanzaconf.idistanzakind = [dbo].istanzakind.idistanzakind WHERE  tassaistanzaconf.idtassaistanzaconf IS NOT NULL 
GO

-- VERIFICA DI tassaistanzaconfdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tassaistanzaconfdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaistanzaconfdefaultview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaistanzaconfdefaultview','nvarchar(2024)','ASSISTENZA','costoscontodef_title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaistanzaconfdefaultview','varchar(69)','ASSISTENZA','dropdown_title','69','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaistanzaconfdefaultview','int','ASSISTENZA','idcostoscontodef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaistanzaconfdefaultview','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaistanzaconfdefaultview','int','ASSISTENZA','idtassaistanzaconf','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaistanzaconfdefaultview','varchar(50)','ASSISTENZA','istanzakind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaistanzaconfdefaultview','datetime','ASSISTENZA','tassaistanzaconf_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaistanzaconfdefaultview','varchar(64)','ASSISTENZA','tassaistanzaconf_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaistanzaconfdefaultview','datetime','ASSISTENZA','tassaistanzaconf_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaistanzaconfdefaultview','varchar(64)','ASSISTENZA','tassaistanzaconf_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaistanzaconfdefaultview','varchar(2)','ASSISTENZA','tassaistanzaconf_nullaosta','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tassaistanzaconfdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tassaistanzaconfdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'tassaistanzaconfdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('tassaistanzaconfdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

