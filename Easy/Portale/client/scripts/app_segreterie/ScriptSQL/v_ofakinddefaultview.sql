
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
-- CREAZIONE VISTA ofakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ofakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ofakinddefaultview]
GO

CREATE VIEW [dbo].[ofakinddefaultview] AS SELECT CASE WHEN ofakind.active = 'S' THEN 'Si' WHEN ofakind.active = 'N' THEN 'No' END AS ofakind_active, ofakind.ct AS ofakind_ct, ofakind.cu AS ofakind_cu, ofakind.description AS ofakind_description, ofakind.idofakind, ofakind.lt AS ofakind_lt, ofakind.lu AS ofakind_lu, ofakind.sortcode AS ofakind_sortcode, ofakind.title, isnull('Tipologia: ' + ofakind.title + '; ','') as dropdown_title FROM [dbo].ofakind WITH (NOLOCK)  WHERE  ofakind.idofakind IS NOT NULL 
GO

-- VERIFICA DI ofakinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'ofakinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ofakinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ofakinddefaultview','int','ASSISTENZA','idofakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ofakinddefaultview','varchar(2)','ASSISTENZA','ofakind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ofakinddefaultview','datetime','ASSISTENZA','ofakind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ofakinddefaultview','varchar(64)','ASSISTENZA','ofakind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ofakinddefaultview','varchar(256)','ASSISTENZA','ofakind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ofakinddefaultview','datetime','ASSISTENZA','ofakind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ofakinddefaultview','varchar(64)','ASSISTENZA','ofakind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ofakinddefaultview','int','ASSISTENZA','ofakind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ofakinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI ofakinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'ofakinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'ofakinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('ofakinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER ofakinddefaultview --
-- FINE GENERAZIONE SCRIPT --

