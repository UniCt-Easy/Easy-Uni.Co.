
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


-- CREAZIONE VISTA corsostudiokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudiokinddefaultview]
GO

CREATE VIEW [dbo].[corsostudiokinddefaultview] AS 
SELECT CASE WHEN corsostudiokind.active = 'S' THEN 'Si' WHEN corsostudiokind.active = 'N' THEN 'No' END AS corsostudiokind_active, corsostudiokind.ct AS corsostudiokind_ct, corsostudiokind.cu AS corsostudiokind_cu, corsostudiokind.description AS corsostudiokind_description, corsostudiokind.idcorsostudiokind, corsostudiokind.lt AS corsostudiokind_lt, corsostudiokind.lu AS corsostudiokind_lu, corsostudiokind.sortcode AS corsostudiokind_sortcode, corsostudiokind.title,
 isnull('Tipologia: ' + corsostudiokind.title + '; ','') as dropdown_title
FROM [dbo].corsostudiokind WITH (NOLOCK) 
WHERE  corsostudiokind.idcorsostudiokind IS NOT NULL 
GO

-- VERIFICA DI corsostudiokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'corsostudiokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudiokinddefaultview','varchar(2)','ASSISTENZA','corsostudiokind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokinddefaultview','datetime','ASSISTENZA','corsostudiokind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokinddefaultview','varchar(64)','ASSISTENZA','corsostudiokind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudiokinddefaultview','varchar(256)','ASSISTENZA','corsostudiokind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokinddefaultview','datetime','ASSISTENZA','corsostudiokind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokinddefaultview','varchar(64)','ASSISTENZA','corsostudiokind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokinddefaultview','int','ASSISTENZA','corsostudiokind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokinddefaultview','int','ASSISTENZA','idcorsostudiokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI corsostudiokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'corsostudiokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'corsostudiokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('corsostudiokinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER corsostudiokinddefaultview --
-- FINE GENERAZIONE SCRIPT --

