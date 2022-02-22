
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
-- CREAZIONE VISTA dichiaraltrekinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiaraltrekinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[dichiaraltrekinddefaultview]
GO

CREATE VIEW [dbo].[dichiaraltrekinddefaultview] AS SELECT CASE WHEN dichiaraltrekind.active = 'S' THEN 'Si' WHEN dichiaraltrekind.active = 'N' THEN 'No' END AS dichiaraltrekind_active, dichiaraltrekind.ct AS dichiaraltrekind_ct, dichiaraltrekind.cu AS dichiaraltrekind_cu, dichiaraltrekind.description AS dichiaraltrekind_description, dichiaraltrekind.iddichiaraltrekind, dichiaraltrekind.lt AS dichiaraltrekind_lt, dichiaraltrekind.lu AS dichiaraltrekind_lu, dichiaraltrekind.sortcode AS dichiaraltrekind_sortcode, dichiaraltrekind.title, isnull('Tipologia: ' + dichiaraltrekind.title + '; ','') as dropdown_title FROM [dbo].dichiaraltrekind WITH (NOLOCK)  WHERE  dichiaraltrekind.iddichiaraltrekind IS NOT NULL 
GO

-- VERIFICA DI dichiaraltrekinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dichiaraltrekinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiaraltrekinddefaultview','varchar(2)','ASSISTENZA','dichiaraltrekind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekinddefaultview','datetime','ASSISTENZA','dichiaraltrekind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekinddefaultview','varchar(64)','ASSISTENZA','dichiaraltrekind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekinddefaultview','varchar(2048)','ASSISTENZA','dichiaraltrekind_description','2048','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekinddefaultview','datetime','ASSISTENZA','dichiaraltrekind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekinddefaultview','varchar(64)','ASSISTENZA','dichiaraltrekind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekinddefaultview','int','ASSISTENZA','dichiaraltrekind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekinddefaultview','varchar(269)','ASSISTENZA','dropdown_title','269','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekinddefaultview','int','ASSISTENZA','iddichiaraltrekind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekinddefaultview','varchar(256)','ASSISTENZA','title','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI dichiaraltrekinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dichiaraltrekinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'dichiaraltrekinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('dichiaraltrekinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER dichiaraltrekinddefaultview --
-- FINE GENERAZIONE SCRIPT --

