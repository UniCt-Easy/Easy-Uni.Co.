
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
-- CREAZIONE VISTA questionariodomkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[questionariodomkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[questionariodomkinddefaultview]
GO

CREATE VIEW [dbo].[questionariodomkinddefaultview] AS SELECT CASE WHEN questionariodomkind.active = 'S' THEN 'Si' WHEN questionariodomkind.active = 'N' THEN 'No' END AS questionariodomkind_active, questionariodomkind.ct AS questionariodomkind_ct, questionariodomkind.cu AS questionariodomkind_cu, questionariodomkind.idquestionariodomkind, questionariodomkind.lt AS questionariodomkind_lt, questionariodomkind.lu AS questionariodomkind_lu, questionariodomkind.sortcode AS questionariodomkind_sortcode, questionariodomkind.title, isnull('Tipologia: ' + questionariodomkind.title + '; ','') as dropdown_title FROM [dbo].questionariodomkind WITH (NOLOCK)  WHERE  questionariodomkind.idquestionariodomkind IS NOT NULL 
GO

-- VERIFICA DI questionariodomkinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'questionariodomkinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomkinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomkinddefaultview','int','ASSISTENZA','idquestionariodomkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodomkinddefaultview','varchar(2)','ASSISTENZA','questionariodomkind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomkinddefaultview','datetime','ASSISTENZA','questionariodomkind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodomkinddefaultview','varchar(64)','ASSISTENZA','questionariodomkind_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodomkinddefaultview','datetime','ASSISTENZA','questionariodomkind_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodomkinddefaultview','varchar(64)','ASSISTENZA','questionariodomkind_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomkinddefaultview','int','ASSISTENZA','questionariodomkind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomkinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI questionariodomkinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'questionariodomkinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'questionariodomkinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('questionariodomkinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER questionariodomkinddefaultview --
-- FINE GENERAZIONE SCRIPT --

