
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


-- CREAZIONE VISTA questionariokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[questionariokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[questionariokinddefaultview]
GO

CREATE VIEW [dbo].[questionariokinddefaultview] AS 
SELECT CASE WHEN questionariokind.active = 'S' THEN 'Si' WHEN questionariokind.active = 'N' THEN 'No' END AS questionariokind_active, questionariokind.ct AS questionariokind_ct, questionariokind.cu AS questionariokind_cu, questionariokind.description AS questionariokind_description, questionariokind.idquestionariokind, questionariokind.lt AS questionariokind_lt, questionariokind.lu AS questionariokind_lu, questionariokind.sortcode AS questionariokind_sortcode, questionariokind.title,
 isnull('Tipologia: ' + questionariokind.title + '; ','') as dropdown_title
FROM [dbo].questionariokind WITH (NOLOCK) 
WHERE  questionariokind.idquestionariokind IS NOT NULL 
GO

-- VERIFICA DI questionariokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'questionariokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokinddefaultview','varchar(141)','ASSISTENZA','dropdown_title','141','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokinddefaultview','int','ASSISTENZA','idquestionariokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariokinddefaultview','varchar(2)','ASSISTENZA','questionariokind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokinddefaultview','datetime','ASSISTENZA','questionariokind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokinddefaultview','varchar(64)','ASSISTENZA','questionariokind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariokinddefaultview','varchar(256)','ASSISTENZA','questionariokind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokinddefaultview','datetime','ASSISTENZA','questionariokind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokinddefaultview','varchar(64)','ASSISTENZA','questionariokind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokinddefaultview','int','ASSISTENZA','questionariokind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokinddefaultview','varchar(128)','ASSISTENZA','title','128','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI questionariokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'questionariokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'questionariokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('questionariokinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER questionariokinddefaultview --
-- FINE GENERAZIONE SCRIPT --

