
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
-- CREAZIONE VISTA bandodsiscresitokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bandodsiscresitokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[bandodsiscresitokinddefaultview]
GO

CREATE VIEW [dbo].[bandodsiscresitokinddefaultview] AS SELECT CASE WHEN bandodsiscresitokind.active = 'S' THEN 'Si' WHEN bandodsiscresitokind.active = 'N' THEN 'No' END AS bandodsiscresitokind_active, bandodsiscresitokind.ct AS bandodsiscresitokind_ct, bandodsiscresitokind.cu AS bandodsiscresitokind_cu, bandodsiscresitokind.description AS bandodsiscresitokind_description, bandodsiscresitokind.idbandodsiscresitokind, bandodsiscresitokind.lt AS bandodsiscresitokind_lt, bandodsiscresitokind.lu AS bandodsiscresitokind_lu, bandodsiscresitokind.sortcode AS bandodsiscresitokind_sortcode, bandodsiscresitokind.title, isnull('Tipologia: ' + bandodsiscresitokind.title + '; ','') as dropdown_title FROM [dbo].bandodsiscresitokind WITH (NOLOCK)  WHERE  bandodsiscresitokind.idbandodsiscresitokind IS NOT NULL 
GO

-- VERIFICA DI bandodsiscresitokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'bandodsiscresitokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandodsiscresitokinddefaultview','varchar(2)','ASSISTENZA','bandodsiscresitokind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsiscresitokinddefaultview','datetime','ASSISTENZA','bandodsiscresitokind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsiscresitokinddefaultview','varchar(64)','ASSISTENZA','bandodsiscresitokind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsiscresitokinddefaultview','varchar(256)','ASSISTENZA','bandodsiscresitokind_description','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsiscresitokinddefaultview','datetime','ASSISTENZA','bandodsiscresitokind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsiscresitokinddefaultview','varchar(64)','ASSISTENZA','bandodsiscresitokind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsiscresitokinddefaultview','int','ASSISTENZA','bandodsiscresitokind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsiscresitokinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsiscresitokinddefaultview','int','ASSISTENZA','idbandodsiscresitokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsiscresitokinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI bandodsiscresitokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'bandodsiscresitokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'bandodsiscresitokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('bandodsiscresitokinddefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

