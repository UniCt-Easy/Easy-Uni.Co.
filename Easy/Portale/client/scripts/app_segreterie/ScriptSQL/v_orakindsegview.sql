
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


-- CREAZIONE VISTA orakindsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[orakindsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[orakindsegview]
GO

CREATE VIEW [dbo].[orakindsegview] AS 
SELECT CASE WHEN orakind.active = 'S' THEN 'Si' WHEN orakind.active = 'N' THEN 'No' END AS orakind_active, orakind.ct AS orakind_ct, orakind.cu AS orakind_cu, orakind.description AS orakind_description, orakind.idorakind, orakind.lt AS orakind_lt, orakind.lu AS orakind_lu,CASE WHEN orakind.ripetizioni = 'S' THEN 'Si' WHEN orakind.ripetizioni = 'N' THEN 'No' END AS orakind_ripetizioni, orakind.sortcode AS orakind_sortcode, orakind.title,
 isnull('Tipologia: ' + orakind.title + '; ','') as dropdown_title
FROM [dbo].orakind WITH (NOLOCK) 
WHERE  orakind.idorakind IS NOT NULL 
GO

-- VERIFICA DI orakindsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'orakindsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','orakindsegview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','orakindsegview','int','ASSISTENZA','idorakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','orakindsegview','varchar(2)','ASSISTENZA','orakind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','orakindsegview','datetime','ASSISTENZA','orakind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','orakindsegview','varchar(64)','ASSISTENZA','orakind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','orakindsegview','varchar(256)','ASSISTENZA','orakind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','orakindsegview','datetime','ASSISTENZA','orakind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','orakindsegview','varchar(64)','ASSISTENZA','orakind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','orakindsegview','varchar(2)','ASSISTENZA','orakind_ripetizioni','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','orakindsegview','int','ASSISTENZA','orakind_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','orakindsegview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI orakindsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'orakindsegview')
UPDATE customobject set isreal = 'N' where objectname = 'orakindsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('orakindsegview', 'N')
GO

-- GENERAZIONE DATI PER orakindsegview --
-- FINE GENERAZIONE SCRIPT --

