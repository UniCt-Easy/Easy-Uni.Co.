
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA aulakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[aulakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[aulakinddefaultview]
GO

CREATE VIEW [dbo].[aulakinddefaultview] AS 
SELECT CASE WHEN aulakind.active = 'S' THEN 'Si' WHEN aulakind.active = 'N' THEN 'No' END AS aulakind_active, aulakind.ct AS aulakind_ct, aulakind.cu AS aulakind_cu, aulakind.description AS aulakind_description, aulakind.idaulakind, aulakind.lt AS aulakind_lt, aulakind.lu AS aulakind_lu, aulakind.sortcode AS aulakind_sortcode, aulakind.title,
 isnull('Tipologia: ' + aulakind.title + '; ','') as dropdown_title
FROM [dbo].aulakind WITH (NOLOCK) 
WHERE  aulakind.idaulakind IS NOT NULL 
GO

-- VERIFICA DI aulakinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'aulakinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','aulakinddefaultview','varchar(2)','ASSISTENZA','aulakind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aulakinddefaultview','datetime','ASSISTENZA','aulakind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aulakinddefaultview','varchar(64)','ASSISTENZA','aulakind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','aulakinddefaultview','varchar(256)','ASSISTENZA','aulakind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aulakinddefaultview','datetime','ASSISTENZA','aulakind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aulakinddefaultview','varchar(64)','ASSISTENZA','aulakind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aulakinddefaultview','int','ASSISTENZA','aulakind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aulakinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aulakinddefaultview','int','ASSISTENZA','idaulakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aulakinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI aulakinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'aulakinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'aulakinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('aulakinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER aulakinddefaultview --
-- FINE GENERAZIONE SCRIPT --
