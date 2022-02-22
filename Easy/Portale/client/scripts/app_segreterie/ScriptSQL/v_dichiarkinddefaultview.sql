
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


-- CREAZIONE VISTA dichiarkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiarkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[dichiarkinddefaultview]
GO

CREATE VIEW [dbo].[dichiarkinddefaultview] AS SELECT CASE WHEN dichiarkind.active = 'S' THEN 'Si' WHEN dichiarkind.active = 'N' THEN 'No' END AS dichiarkind_active, dichiarkind.ct AS dichiarkind_ct, dichiarkind.cu AS dichiarkind_cu, dichiarkind.description AS dichiarkind_description, dichiarkind.iddichiarkind, dichiarkind.lt AS dichiarkind_lt, dichiarkind.lu AS dichiarkind_lu, dichiarkind.sortcode AS dichiarkind_sortcode, dichiarkind.title, isnull('Tipologia: ' + dichiarkind.title + '; ','') as dropdown_title FROM [dbo].dichiarkind WITH (NOLOCK)  WHERE  dichiarkind.iddichiarkind IS NOT NULL 
GO

-- VERIFICA DI dichiarkinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dichiarkinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiarkinddefaultview','varchar(2)','ASSISTENZA','dichiarkind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarkinddefaultview','datetime','ASSISTENZA','dichiarkind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarkinddefaultview','varchar(64)','ASSISTENZA','dichiarkind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarkinddefaultview','varchar(256)','ASSISTENZA','dichiarkind_description','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarkinddefaultview','datetime','ASSISTENZA','dichiarkind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarkinddefaultview','varchar(64)','ASSISTENZA','dichiarkind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarkinddefaultview','int','ASSISTENZA','dichiarkind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarkinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarkinddefaultview','int','ASSISTENZA','iddichiarkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarkinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI dichiarkinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dichiarkinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'dichiarkinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('dichiarkinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER dichiarkinddefaultview --
-- FINE GENERAZIONE SCRIPT --

