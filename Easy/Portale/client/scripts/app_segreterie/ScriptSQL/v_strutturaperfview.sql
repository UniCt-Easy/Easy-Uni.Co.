
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


-- CREAZIONE VISTA strutturaperfview
IF EXISTS(select * from sysobjects where id = object_id(N'[strutturaperfview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [strutturaperfview]
GO

CREATE VIEW [strutturaperfview] AS 
SELECT  struttura.idstruttura, struttura.title, struttura.codice AS struttura_codice, struttura.codiceipa AS struttura_codiceipa, struttura.email AS struttura_email, struttura.fax AS struttura_fax, struttura.idaoo AS struttura_idaoo, struttura.idreg AS struttura_idreg, struttura.idsede AS struttura_idsede,
 [dbo].strutturakind.title AS strutturakind_title, struttura.idstrutturakind AS struttura_idstrutturakind,
 upb.title AS upb_title, struttura.idupb, struttura.telefono AS struttura_telefono, struttura.title_en AS struttura_title_en, struttura.ct AS struttura_ct, struttura.cu AS struttura_cu, struttura.lt AS struttura_lt, struttura.lu AS struttura_lu,
 strutturaparent.title AS strutturaparent_title, strutturakind_struttura.title AS strutturakind_struttura_title, strutturaparent.idstrutturakind AS strutturaparent_idstrutturakind, struttura.paridstruttura, struttura.pesoindicatori AS struttura_pesoindicatori, struttura.pesoobiettivi AS struttura_pesoobiettivi, struttura.pesoprogaltreuo AS struttura_pesoprogaltreuo, struttura.pesoproguo AS struttura_pesoproguo,
 isnull('Denominazione: ' + struttura.title + '; ','') as dropdown_title
FROM [dbo].struttura WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
LEFT OUTER JOIN upb WITH (NOLOCK) ON struttura.idupb = upb.idupb
LEFT OUTER JOIN [dbo].struttura AS strutturaparent WITH (NOLOCK) ON struttura.paridstruttura = strutturaparent.idstruttura
LEFT OUTER JOIN [dbo].strutturakind AS strutturakind_struttura WITH (NOLOCK) ON strutturaparent.idstrutturakind = strutturakind_struttura.idstrutturakind
WHERE  struttura.idstruttura IS NOT NULL 
GO

-- VERIFICA DI strutturaperfview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'strutturaperfview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturaperfview','varchar(1041)','ASSISTENZA','dropdown_title','1041','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturaperfview','int','ASSISTENZA','idstruttura','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','varchar(36)','ASSISTENZA','idupb','36','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','int','','paridstruttura','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','varchar(50)','ASSISTENZA','struttura_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','nchar(10)','ASSISTENZA','struttura_codiceipa','10','N','nchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturaperfview','datetime','ASSISTENZA','struttura_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturaperfview','varchar(64)','ASSISTENZA','struttura_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','varchar(200)','ASSISTENZA','struttura_email','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','varchar(50)','ASSISTENZA','struttura_fax','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','int','ASSISTENZA','struttura_idaoo','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','int','ASSISTENZA','struttura_idreg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturaperfview','int','ASSISTENZA','struttura_idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturaperfview','int','ASSISTENZA','struttura_idstrutturakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturaperfview','datetime','ASSISTENZA','struttura_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturaperfview','varchar(64)','ASSISTENZA','struttura_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','decimal(19,2)','','struttura_pesoindicatori','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','decimal(19,2)','','struttura_pesoobiettivi','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','decimal(19,2)','','struttura_pesoprogaltreuo','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','decimal(19,2)','','struttura_pesoproguo','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','varchar(50)','ASSISTENZA','struttura_telefono','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','varchar(1024)','ASSISTENZA','struttura_title_en','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','varchar(50)','','strutturakind_struttura_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','int','','strutturaparent_idstrutturakind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','varchar(1024)','','strutturaparent_title','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaperfview','varchar(150)','ASSISTENZA','upb_title','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI strutturaperfview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'strutturaperfview')
UPDATE customobject set isreal = 'N' where objectname = 'strutturaperfview'
ELSE
INSERT INTO customobject (objectname, isreal) values('strutturaperfview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

