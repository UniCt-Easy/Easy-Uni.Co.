
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
-- CREAZIONE VISTA fonteindicebibliometricosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[fonteindicebibliometricosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[fonteindicebibliometricosegview]
GO

CREATE VIEW [dbo].[fonteindicebibliometricosegview] AS SELECT CASE WHEN fonteindicebibliometrico.active = 'S' THEN 'Si' WHEN fonteindicebibliometrico.active = 'N' THEN 'No' END AS fonteindicebibliometrico_active, fonteindicebibliometrico.ct AS fonteindicebibliometrico_ct, fonteindicebibliometrico.cu AS fonteindicebibliometrico_cu, fonteindicebibliometrico.description AS fonteindicebibliometrico_description, fonteindicebibliometrico.idfonteindicebibliometrico, fonteindicebibliometrico.lt AS fonteindicebibliometrico_lt, fonteindicebibliometrico.lu AS fonteindicebibliometrico_lu, fonteindicebibliometrico.sortcode AS fonteindicebibliometrico_sortcode, fonteindicebibliometrico.title, isnull('Titolo: ' + fonteindicebibliometrico.title + '; ','') as dropdown_title FROM [dbo].fonteindicebibliometrico WITH (NOLOCK)  WHERE  fonteindicebibliometrico.idfonteindicebibliometrico IS NOT NULL 
GO

-- VERIFICA DI fonteindicebibliometricosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'fonteindicebibliometricosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','fonteindicebibliometricosegview','nvarchar(1034)','ASSISTENZA','dropdown_title','1034','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometricosegview','varchar(2)','ASSISTENZA','fonteindicebibliometrico_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometricosegview','datetime','ASSISTENZA','fonteindicebibliometrico_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometricosegview','varchar(64)','ASSISTENZA','fonteindicebibliometrico_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometricosegview','nvarchar(max)','ASSISTENZA','fonteindicebibliometrico_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometricosegview','datetime','ASSISTENZA','fonteindicebibliometrico_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometricosegview','varchar(64)','ASSISTENZA','fonteindicebibliometrico_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometricosegview','int','ASSISTENZA','fonteindicebibliometrico_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','fonteindicebibliometricosegview','int','ASSISTENZA','idfonteindicebibliometrico','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometricosegview','nvarchar(1024)','ASSISTENZA','title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI fonteindicebibliometricosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'fonteindicebibliometricosegview')
UPDATE customobject set isreal = 'N' where objectname = 'fonteindicebibliometricosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('fonteindicebibliometricosegview', 'N')
GO

-- GENERAZIONE DATI PER fonteindicebibliometricosegview --
-- FINE GENERAZIONE SCRIPT --

