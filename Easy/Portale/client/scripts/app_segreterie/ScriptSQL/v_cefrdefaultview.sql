
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
-- CREAZIONE VISTA cefrdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[cefrdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[cefrdefaultview]
GO

CREATE VIEW [dbo].[cefrdefaultview] AS SELECT CASE WHEN cefr.active = 'S' THEN 'Si' WHEN cefr.active = 'N' THEN 'No' END AS cefr_active, cefr.descriptioncompasc AS cefr_descriptioncompasc, cefr.descriptioncomplett AS cefr_descriptioncomplett, cefr.descriptionparlinter AS cefr_descriptionparlinter, cefr.descriptionparlprod AS cefr_descriptionparlprod, cefr.descriptionscritto AS cefr_descriptionscritto, cefr.idcefr, cefr.lt AS cefr_lt, cefr.lu AS cefr_lu, cefr.sortcode AS cefr_sortcode, cefr.title, isnull('Titolo: ' + cefr.title + '; ','') as dropdown_title FROM [dbo].cefr WITH (NOLOCK)  WHERE  cefr.idcefr IS NOT NULL 
GO

-- VERIFICA DI cefrdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'cefrdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrdefaultview','varchar(2)','ASSISTENZA','cefr_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrdefaultview','varchar(512)','ASSISTENZA','cefr_descriptioncompasc','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrdefaultview','varchar(512)','ASSISTENZA','cefr_descriptioncomplett','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrdefaultview','varchar(512)','ASSISTENZA','cefr_descriptionparlinter','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrdefaultview','varchar(512)','ASSISTENZA','cefr_descriptionparlprod','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrdefaultview','varchar(512)','ASSISTENZA','cefr_descriptionscritto','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrdefaultview','datetime','ASSISTENZA','cefr_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrdefaultview','varchar(64)','ASSISTENZA','cefr_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrdefaultview','int','ASSISTENZA','cefr_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrdefaultview','varchar(60)','ASSISTENZA','dropdown_title','60','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrdefaultview','int','ASSISTENZA','idcefr','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrdefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI cefrdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'cefrdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'cefrdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('cefrdefaultview', 'N')
GO

-- GENERAZIONE DATI PER cefrdefaultview --
-- FINE GENERAZIONE SCRIPT --

