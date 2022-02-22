
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


-- CREAZIONE VISTA erogazkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[erogazkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[erogazkinddefaultview]
GO

CREATE VIEW [dbo].[erogazkinddefaultview] AS 
SELECT CASE WHEN erogazkind.active = 'S' THEN 'Si' WHEN erogazkind.active = 'N' THEN 'No' END AS erogazkind_active, erogazkind.ans AS erogazkind_ans, erogazkind.description AS erogazkind_description, erogazkind.iderogazkind, erogazkind.lt AS erogazkind_lt, erogazkind.lu AS erogazkind_lu, erogazkind.sortcode AS erogazkind_sortcode, erogazkind.title,
 isnull('Tipologia: ' + erogazkind.title + '; ','') as dropdown_title
FROM [dbo].erogazkind WITH (NOLOCK) 
WHERE  erogazkind.iderogazkind IS NOT NULL 
GO

-- VERIFICA DI erogazkinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'erogazkinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','erogazkinddefaultview','varchar(2)','ASSISTENZA','erogazkind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','erogazkinddefaultview','varchar(10)','ASSISTENZA','erogazkind_ans','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','erogazkinddefaultview','varchar(255)','ASSISTENZA','erogazkind_description','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkinddefaultview','datetime','ASSISTENZA','erogazkind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkinddefaultview','varchar(64)','ASSISTENZA','erogazkind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkinddefaultview','int','ASSISTENZA','erogazkind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkinddefaultview','int','ASSISTENZA','iderogazkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI erogazkinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'erogazkinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'erogazkinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('erogazkinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER erogazkinddefaultview --
-- FINE GENERAZIONE SCRIPT --

