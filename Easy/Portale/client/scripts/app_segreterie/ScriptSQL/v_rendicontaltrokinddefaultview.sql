
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


-- CREAZIONE VISTA rendicontaltrokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontaltrokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[rendicontaltrokinddefaultview]
GO

CREATE VIEW [dbo].[rendicontaltrokinddefaultview] AS 
SELECT CASE WHEN rendicontaltrokind.active = 'S' THEN 'Si' WHEN rendicontaltrokind.active = 'N' THEN 'No' END AS rendicontaltrokind_active, rendicontaltrokind.ct AS rendicontaltrokind_ct, rendicontaltrokind.cu AS rendicontaltrokind_cu, rendicontaltrokind.description AS rendicontaltrokind_description, rendicontaltrokind.idrendicontaltrokind, rendicontaltrokind.lt AS rendicontaltrokind_lt, rendicontaltrokind.lu AS rendicontaltrokind_lu, rendicontaltrokind.sortcode AS rendicontaltrokind_sortcode, rendicontaltrokind.title,
 isnull('Tipologia: ' + rendicontaltrokind.title + '; ','') as dropdown_title
FROM [dbo].rendicontaltrokind WITH (NOLOCK) 
WHERE  rendicontaltrokind.idrendicontaltrokind IS NOT NULL 
GO

-- VERIFICA DI rendicontaltrokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontaltrokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontaltrokinddefaultview','varchar(141)','ASSISTENZA','dropdown_title','141','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontaltrokinddefaultview','int','ASSISTENZA','idrendicontaltrokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontaltrokinddefaultview','varchar(2)','ASSISTENZA','rendicontaltrokind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontaltrokinddefaultview','datetime','ASSISTENZA','rendicontaltrokind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontaltrokinddefaultview','varchar(64)','ASSISTENZA','rendicontaltrokind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontaltrokinddefaultview','varchar(256)','ASSISTENZA','rendicontaltrokind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontaltrokinddefaultview','datetime','ASSISTENZA','rendicontaltrokind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontaltrokinddefaultview','varchar(64)','ASSISTENZA','rendicontaltrokind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontaltrokinddefaultview','int','ASSISTENZA','rendicontaltrokind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontaltrokinddefaultview','varchar(128)','ASSISTENZA','title','128','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontaltrokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontaltrokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontaltrokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontaltrokinddefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

