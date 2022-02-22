
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
-- CREAZIONE VISTA ratakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ratakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ratakinddefaultview]
GO

CREATE VIEW [dbo].[ratakinddefaultview] AS SELECT CASE WHEN ratakind.active = 'S' THEN 'Si' WHEN ratakind.active = 'N' THEN 'No' END AS ratakind_active, ratakind.ct AS ratakind_ct, ratakind.cu AS ratakind_cu, ratakind.idratakind, ratakind.lt AS ratakind_lt, ratakind.lu AS ratakind_lu, ratakind.sortcode AS ratakind_sortcode, ratakind.title, isnull('Denominazione: ' + ratakind.title + '; ','') as dropdown_title FROM [dbo].ratakind WITH (NOLOCK)  WHERE  ratakind.idratakind IS NOT NULL 
GO

-- VERIFICA DI ratakinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'ratakinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratakinddefaultview','varchar(67)','ASSISTENZA','dropdown_title','67','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratakinddefaultview','varchar(50)','ASSISTENZA','idratakind','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ratakinddefaultview','varchar(2)','ASSISTENZA','ratakind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratakinddefaultview','datetime','ASSISTENZA','ratakind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratakinddefaultview','varchar(64)','ASSISTENZA','ratakind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratakinddefaultview','datetime','ASSISTENZA','ratakind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratakinddefaultview','varchar(64)','ASSISTENZA','ratakind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ratakinddefaultview','int','ASSISTENZA','ratakind_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ratakinddefaultview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI ratakinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'ratakinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'ratakinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('ratakinddefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

