
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


-- CREAZIONE VISTA questionariodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[questionariodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[questionariodefaultview]
GO

CREATE VIEW [dbo].[questionariodefaultview] AS 
SELECT CASE WHEN questionario.anonimo = 'S' THEN 'Si' WHEN questionario.anonimo = 'N' THEN 'No' END AS questionario_anonimo, questionario.ct AS questionario_ct, questionario.cu AS questionario_cu, questionario.description AS questionario_description, questionario.idquestionario,
 [dbo].questionariokind.title AS questionariokind_title, questionario.idquestionariokind AS questionario_idquestionariokind, questionario.lt AS questionario_lt, questionario.lu AS questionario_lu, questionario.title,
 isnull('Titolo: ' + questionario.title + '; ','') as dropdown_title
FROM [dbo].questionario WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].questionariokind WITH (NOLOCK) ON questionario.idquestionariokind = [dbo].questionariokind.idquestionariokind
WHERE  questionario.idquestionario IS NOT NULL 
GO

-- VERIFICA DI questionariodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'questionariodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodefaultview','varchar(60)','ASSISTENZA','dropdown_title','60','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodefaultview','int','ASSISTENZA','idquestionario','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodefaultview','varchar(2)','ASSISTENZA','questionario_anonimo','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodefaultview','datetime','ASSISTENZA','questionario_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodefaultview','varchar(50)','ASSISTENZA','questionario_cu','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodefaultview','varchar(255)','ASSISTENZA','questionario_description','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodefaultview','int','ASSISTENZA','questionario_idquestionariokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodefaultview','datetime','ASSISTENZA','questionario_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodefaultview','varchar(64)','ASSISTENZA','questionario_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodefaultview','varchar(128)','ASSISTENZA','questionariokind_title','128','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodefaultview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI questionariodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'questionariodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'questionariodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('questionariodefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

