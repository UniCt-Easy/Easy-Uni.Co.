
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


-- CREAZIONE VISTA strutturakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[strutturakinddefaultview]
GO

CREATE VIEW [dbo].[strutturakinddefaultview] AS 
SELECT CASE WHEN strutturakind.active = 'S' THEN 'Si' WHEN strutturakind.active = 'N' THEN 'No' END AS strutturakind_active, strutturakind.description AS strutturakind_description, strutturakind.idstrutturakind, strutturakind.lt AS strutturakind_lt, strutturakind.lu AS strutturakind_lu, strutturakind.sortCode AS strutturakind_sortCode, strutturakind.title,
 isnull('Tipologia: ' + strutturakind.title + '; ','') as dropdown_title
FROM [dbo].strutturakind WITH (NOLOCK) 
WHERE  strutturakind.idstrutturakind IS NOT NULL 
GO

-- VERIFICA DI strutturakinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'strutturakinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturakinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturakinddefaultview','int','ASSISTENZA','idstrutturakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturakinddefaultview','varchar(2)','ASSISTENZA','strutturakind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturakinddefaultview','varchar(256)','ASSISTENZA','strutturakind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturakinddefaultview','datetime','ASSISTENZA','strutturakind_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturakinddefaultview','varchar(64)','ASSISTENZA','strutturakind_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturakinddefaultview','int','ASSISTENZA','strutturakind_sortCode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturakinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI strutturakinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'strutturakinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'strutturakinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('strutturakinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER strutturakinddefaultview --
-- FINE GENERAZIONE SCRIPT --

