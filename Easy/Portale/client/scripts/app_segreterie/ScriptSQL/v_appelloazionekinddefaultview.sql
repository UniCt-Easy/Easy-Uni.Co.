
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


-- CREAZIONE VISTA appelloazionekinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appelloazionekinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[appelloazionekinddefaultview]
GO

CREATE VIEW [dbo].[appelloazionekinddefaultview] AS 
SELECT CASE WHEN appelloazionekind.active = 'S' THEN 'Si' WHEN appelloazionekind.active = 'N' THEN 'No' END AS appelloazionekind_active, appelloazionekind.ct AS appelloazionekind_ct, appelloazionekind.cu AS appelloazionekind_cu, appelloazionekind.description AS appelloazionekind_description, appelloazionekind.idappelloazionekind, appelloazionekind.lt AS appelloazionekind_lt, appelloazionekind.lu AS appelloazionekind_lu, appelloazionekind.sortcode AS appelloazionekind_sortcode, appelloazionekind.title,
 isnull('Tipologia: ' + appelloazionekind.title + '; ','') as dropdown_title
FROM [dbo].appelloazionekind WITH (NOLOCK) 
WHERE  appelloazionekind.idappelloazionekind IS NOT NULL 
GO

-- VERIFICA DI appelloazionekinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'appelloazionekinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloazionekinddefaultview','varchar(2)','ASSISTENZA','appelloazionekind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloazionekinddefaultview','datetime','ASSISTENZA','appelloazionekind_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloazionekinddefaultview','varchar(64)','ASSISTENZA','appelloazionekind_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloazionekinddefaultview','varchar(250)','ASSISTENZA','appelloazionekind_description','250','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloazionekinddefaultview','datetime','ASSISTENZA','appelloazionekind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloazionekinddefaultview','varchar(64)','ASSISTENZA','appelloazionekind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloazionekinddefaultview','int','ASSISTENZA','appelloazionekind_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloazionekinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloazionekinddefaultview','int','ASSISTENZA','idappelloazionekind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloazionekinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI appelloazionekinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'appelloazionekinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'appelloazionekinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('appelloazionekinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER appelloazionekinddefaultview --
-- FINE GENERAZIONE SCRIPT --

