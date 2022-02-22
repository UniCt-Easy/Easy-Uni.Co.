
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
-- CREAZIONE VISTA tassaconfkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tassaconfkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tassaconfkinddefaultview]
GO

CREATE VIEW [dbo].[tassaconfkinddefaultview] AS SELECT CASE WHEN tassaconfkind.active = 'S' THEN 'Si' WHEN tassaconfkind.active = 'N' THEN 'No' END AS tassaconfkind_active, tassaconfkind.ct AS tassaconfkind_ct, tassaconfkind.cu AS tassaconfkind_cu, tassaconfkind.idtassaconfkind, tassaconfkind.lt AS tassaconfkind_lt, tassaconfkind.lu AS tassaconfkind_lu, tassaconfkind.sortcode AS tassaconfkind_sortcode, tassaconfkind.title, isnull('Tipologia: ' + tassaconfkind.title + '; ','') as dropdown_title FROM [dbo].tassaconfkind WITH (NOLOCK)  WHERE  tassaconfkind.idtassaconfkind IS NOT NULL 
GO

-- VERIFICA DI tassaconfkinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tassaconfkinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfkinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfkinddefaultview','int','ASSISTENZA','idtassaconfkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaconfkinddefaultview','varchar(2)','ASSISTENZA','tassaconfkind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfkinddefaultview','datetime','ASSISTENZA','tassaconfkind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfkinddefaultview','varchar(64)','ASSISTENZA','tassaconfkind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfkinddefaultview','datetime','ASSISTENZA','tassaconfkind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfkinddefaultview','varchar(64)','ASSISTENZA','tassaconfkind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfkinddefaultview','int','ASSISTENZA','tassaconfkind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaconfkinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tassaconfkinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tassaconfkinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'tassaconfkinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('tassaconfkinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER tassaconfkinddefaultview --
-- FINE GENERAZIONE SCRIPT --

