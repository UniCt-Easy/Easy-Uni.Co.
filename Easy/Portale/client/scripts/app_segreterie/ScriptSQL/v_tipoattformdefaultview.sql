
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


-- CREAZIONE VISTA tipoattformdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tipoattformdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tipoattformdefaultview]
GO

CREATE VIEW [dbo].[tipoattformdefaultview] AS 
SELECT  tipoattform.description AS tipoattform_description, tipoattform.idtipoattform, tipoattform.lt AS tipoattform_lt, tipoattform.lu AS tipoattform_lu, tipoattform.title,
 isnull('Denominazione: ' + tipoattform.title + '; ','') + ' ' + isnull('Descrizione: ' + tipoattform.description + '; ','') as dropdown_title
FROM [dbo].tipoattform WITH (NOLOCK) 
WHERE  tipoattform.idtipoattform IS NOT NULL 
GO

-- VERIFICA DI tipoattformdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tipoattformdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipoattformdefaultview','varchar(290)','ASSISTENZA','dropdown_title','290','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipoattformdefaultview','int','ASSISTENZA','idtipoattform','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tipoattformdefaultview','varchar(256)','ASSISTENZA','tipoattform_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipoattformdefaultview','datetime','ASSISTENZA','tipoattform_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipoattformdefaultview','varchar(64)','ASSISTENZA','tipoattform_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipoattformdefaultview','varchar(1)','ASSISTENZA','title','1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tipoattformdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tipoattformdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'tipoattformdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('tipoattformdefaultview', 'N')
GO

-- GENERAZIONE DATI PER tipoattformdefaultview --
-- FINE GENERAZIONE SCRIPT --

