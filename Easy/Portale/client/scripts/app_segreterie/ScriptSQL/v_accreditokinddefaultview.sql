
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
-- CREAZIONE VISTA accreditokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accreditokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accreditokinddefaultview]
GO

CREATE VIEW [dbo].[accreditokinddefaultview] AS SELECT CASE WHEN accreditokind.active = 'S' THEN 'Si' WHEN accreditokind.active = 'N' THEN 'No' END AS accreditokind_active, accreditokind.ct AS accreditokind_ct, accreditokind.cu AS accreditokind_cu, accreditokind.description AS accreditokind_description, accreditokind.idaccreditokind, accreditokind.lt AS accreditokind_lt, accreditokind.lu AS accreditokind_lu, accreditokind.sortcode AS accreditokind_sortcode, accreditokind.title, isnull('Tipologia: ' + accreditokind.title + '; ','') as dropdown_title FROM [dbo].accreditokind WITH (NOLOCK)  WHERE  accreditokind.idaccreditokind IS NOT NULL 
GO

-- VERIFICA DI accreditokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accreditokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accreditokinddefaultview','varchar(2)','ASSISTENZA','accreditokind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accreditokinddefaultview','datetime','ASSISTENZA','accreditokind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accreditokinddefaultview','varchar(64)','ASSISTENZA','accreditokind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accreditokinddefaultview','nvarchar(256)','ASSISTENZA','accreditokind_description','256','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accreditokinddefaultview','datetime','ASSISTENZA','accreditokind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accreditokinddefaultview','varchar(64)','ASSISTENZA','accreditokind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accreditokinddefaultview','int','ASSISTENZA','accreditokind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accreditokinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accreditokinddefaultview','int','ASSISTENZA','idaccreditokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accreditokinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI accreditokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accreditokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'accreditokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('accreditokinddefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

