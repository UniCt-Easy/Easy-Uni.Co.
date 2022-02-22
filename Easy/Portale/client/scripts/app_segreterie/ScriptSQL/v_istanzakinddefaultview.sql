
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
-- CREAZIONE VISTA istanzakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzakinddefaultview]
GO

CREATE VIEW [dbo].[istanzakinddefaultview] AS SELECT CASE WHEN istanzakind.active = 'S' THEN 'Si' WHEN istanzakind.active = 'N' THEN 'No' END AS istanzakind_active, istanzakind.ct AS istanzakind_ct, istanzakind.cu AS istanzakind_cu, istanzakind.description AS istanzakind_description, istanzakind.idistanzakind, istanzakind.lt AS istanzakind_lt, istanzakind.lu AS istanzakind_lu, istanzakind.sortcode AS istanzakind_sortcode, istanzakind.title, isnull('Tipologia: ' + istanzakind.title + '; ','') as dropdown_title FROM [dbo].istanzakind WITH (NOLOCK)  WHERE  istanzakind.idistanzakind IS NOT NULL 
GO

-- VERIFICA DI istanzakinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'istanzakinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakinddefaultview','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzakinddefaultview','varchar(2)','ASSISTENZA','istanzakind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakinddefaultview','datetime','ASSISTENZA','istanzakind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakinddefaultview','varchar(64)','ASSISTENZA','istanzakind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzakinddefaultview','varchar(256)','ASSISTENZA','istanzakind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakinddefaultview','datetime','ASSISTENZA','istanzakind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakinddefaultview','varchar(64)','ASSISTENZA','istanzakind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakinddefaultview','int','ASSISTENZA','istanzakind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzakinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI istanzakinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'istanzakinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'istanzakinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('istanzakinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER istanzakinddefaultview --
-- FINE GENERAZIONE SCRIPT --

