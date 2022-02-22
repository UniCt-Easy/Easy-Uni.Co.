
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
-- CREAZIONE VISTA sostenimentoesitodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sostenimentoesitodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sostenimentoesitodefaultview]
GO

CREATE VIEW [dbo].[sostenimentoesitodefaultview] AS SELECT CASE WHEN sostenimentoesito.active = 'S' THEN 'Si' WHEN sostenimentoesito.active = 'N' THEN 'No' END AS sostenimentoesito_active, sostenimentoesito.description AS sostenimentoesito_description, sostenimentoesito.idsostenimentoesito, sostenimentoesito.lt AS sostenimentoesito_lt, sostenimentoesito.lu AS sostenimentoesito_lu, sostenimentoesito.sortcode AS sostenimentoesito_sortcode, sostenimentoesito.title, isnull('Esito: ' + sostenimentoesito.title + '; ','') as dropdown_title FROM [dbo].sostenimentoesito WITH (NOLOCK)  WHERE  sostenimentoesito.idsostenimentoesito IS NOT NULL 
GO

-- VERIFICA DI sostenimentoesitodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sostenimentoesitodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoesitodefaultview','varchar(59)','ASSISTENZA','dropdown_title','59','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoesitodefaultview','int','ASSISTENZA','idsostenimentoesito','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoesitodefaultview','varchar(2)','ASSISTENZA','sostenimentoesito_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoesitodefaultview','varchar(256)','ASSISTENZA','sostenimentoesito_description','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoesitodefaultview','datetime','ASSISTENZA','sostenimentoesito_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoesitodefaultview','varchar(64)','ASSISTENZA','sostenimentoesito_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoesitodefaultview','int','ASSISTENZA','sostenimentoesito_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoesitodefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI sostenimentoesitodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sostenimentoesitodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'sostenimentoesitodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sostenimentoesitodefaultview', 'N')
GO

-- GENERAZIONE DATI PER sostenimentoesitodefaultview --
-- FINE GENERAZIONE SCRIPT --

