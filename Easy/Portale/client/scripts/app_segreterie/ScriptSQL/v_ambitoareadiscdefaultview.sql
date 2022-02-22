
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


-- CREAZIONE VISTA ambitoareadiscdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ambitoareadiscdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ambitoareadiscdefaultview]
GO

CREATE VIEW [dbo].[ambitoareadiscdefaultview] AS 
SELECT  ambitoareadisc.idambitoareadisc,
 [dbo].classescuola.sigla AS classescuola_sigla, [dbo].classescuola.title AS classescuola_title, ambitoareadisc.idclassescuola,
 [dbo].tipoattform.title AS tipoattform_title, [dbo].tipoattform.description AS tipoattform_description, ambitoareadisc.idtipoattform AS ambitoareadisc_idtipoattform, ambitoareadisc.indicecineca AS ambitoareadisc_indicecineca, ambitoareadisc.lt AS ambitoareadisc_lt, ambitoareadisc.lu AS ambitoareadisc_lu, ambitoareadisc.sortcode AS ambitoareadisc_sortcode, ambitoareadisc.title,
 isnull('Ambito: ' + ambitoareadisc.title + '; ','') as dropdown_title
FROM [dbo].ambitoareadisc WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].classescuola WITH (NOLOCK) ON ambitoareadisc.idclassescuola = [dbo].classescuola.idclassescuola
LEFT OUTER JOIN [dbo].tipoattform WITH (NOLOCK) ON ambitoareadisc.idtipoattform = [dbo].tipoattform.idtipoattform
WHERE  ambitoareadisc.idambitoareadisc IS NOT NULL 
GO

-- VERIFICA DI ambitoareadiscdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'ambitoareadiscdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ambitoareadiscdefaultview','int','ASSISTENZA','ambitoareadisc_idtipoattform','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ambitoareadiscdefaultview','int','ASSISTENZA','ambitoareadisc_indicecineca','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ambitoareadiscdefaultview','datetime','ASSISTENZA','ambitoareadisc_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ambitoareadiscdefaultview','varchar(64)','ASSISTENZA','ambitoareadisc_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ambitoareadiscdefaultview','int','ASSISTENZA','ambitoareadisc_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ambitoareadiscdefaultview','varchar(50)','','classescuola_sigla','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ambitoareadiscdefaultview','varchar(256)','ASSISTENZA','classescuola_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ambitoareadiscdefaultview','varchar(266)','ASSISTENZA','dropdown_title','266','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ambitoareadiscdefaultview','int','ASSISTENZA','idambitoareadisc','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ambitoareadiscdefaultview','int','ASSISTENZA','idclassescuola','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ambitoareadiscdefaultview','varchar(256)','ASSISTENZA','tipoattform_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ambitoareadiscdefaultview','varchar(1)','ASSISTENZA','tipoattform_title','1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ambitoareadiscdefaultview','varchar(256)','ASSISTENZA','title','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI ambitoareadiscdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'ambitoareadiscdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'ambitoareadiscdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('ambitoareadiscdefaultview', 'N')
GO

-- GENERAZIONE DATI PER ambitoareadiscdefaultview --
-- FINE GENERAZIONE SCRIPT --

