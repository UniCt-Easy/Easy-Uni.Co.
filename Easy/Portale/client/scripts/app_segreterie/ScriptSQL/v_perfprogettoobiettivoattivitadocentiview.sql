
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


-- CREAZIONE VISTA perfprogettoobiettivoattivitadocentiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivoattivitadocentiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettoobiettivoattivitadocentiview]
GO

CREATE VIEW [dbo].[perfprogettoobiettivoattivitadocentiview] AS 
SELECT 
 [dbo].perfprogetto.title AS perfprogetto_title, perfprogettoobiettivoattivita.idperfprogetto, perfprogettoobiettivoattivita.description AS perfprogettoobiettivoattivita_description,
 [dbo].perfprogettoobiettivo.title AS perfprogettoobiettivo_title, perfprogettoobiettivoattivita.idperfprogettoobiettivo, perfprogettoobiettivoattivita.idreg AS perfprogettoobiettivoattivita_idreg,
 perfprogettoobiettivoattivitaparent.title AS perfprogettoobiettivoattivitaparent_title, perfprogettoobiettivoattivita.paridperfprogettoobiettivoattivita AS perfprogettoobiettivoattivita_paridperfprogettoobiettivoattivita, perfprogettoobiettivoattivita.title, perfprogettoobiettivoattivita.datainizioprevista AS perfprogettoobiettivoattivita_datainizioprevista, perfprogettoobiettivoattivita.datafineprevista AS perfprogettoobiettivoattivita_datafineprevista, perfprogettoobiettivoattivita.datainizioeffettiva AS perfprogettoobiettivoattivita_datainizioeffettiva, perfprogettoobiettivoattivita.datafineeffettiva AS perfprogettoobiettivoattivita_datafineeffettiva, perfprogettoobiettivoattivita.completamento AS perfprogettoobiettivoattivita_completamento, perfprogettoobiettivoattivita.ct AS perfprogettoobiettivoattivita_ct, perfprogettoobiettivoattivita.cu AS perfprogettoobiettivoattivita_cu, perfprogettoobiettivoattivita.lt AS perfprogettoobiettivoattivita_lt, perfprogettoobiettivoattivita.lu AS perfprogettoobiettivoattivita_lu, perfprogettoobiettivoattivita.idperfprogettoobiettivoattivita,
 isnull('Titolo: ' + perfprogettoobiettivoattivita.title + '; ','') as dropdown_title
FROM [dbo].perfprogettoobiettivoattivita WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].perfprogetto WITH (NOLOCK) ON perfprogettoobiettivoattivita.idperfprogetto = [dbo].perfprogetto.idperfprogetto
LEFT OUTER JOIN [dbo].perfprogettoobiettivo WITH (NOLOCK) ON perfprogettoobiettivoattivita.idperfprogettoobiettivo = [dbo].perfprogettoobiettivo.idperfprogettoobiettivo
LEFT OUTER JOIN [dbo].perfprogettoobiettivoattivita AS perfprogettoobiettivoattivitaparent WITH (NOLOCK) ON perfprogettoobiettivoattivita.paridperfprogettoobiettivoattivita = perfprogettoobiettivoattivitaparent.idperfprogettoobiettivoattivita
WHERE  perfprogettoobiettivoattivita.idperfprogetto IS NOT NULL  AND perfprogettoobiettivoattivita.idperfprogettoobiettivo IS NOT NULL  AND perfprogettoobiettivoattivita.idperfprogettoobiettivoattivita IS NOT NULL 
GO

-- VERIFICA DI perfprogettoobiettivoattivitadocentiview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfprogettoobiettivoattivitadocentiview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivitadocentiview','varchar(1034)','ASSISTENZA','dropdown_title','1034','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivitadocentiview','int','ASSISTENZA','idperfprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivitadocentiview','int','ASSISTENZA','idperfprogettoobiettivo','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivitadocentiview','int','ASSISTENZA','idperfprogettoobiettivoattivita','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','varchar(1024)','ASSISTENZA','perfprogetto_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','varchar(1024)','','perfprogettoobiettivo_title','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','decimal(19,2)','ASSISTENZA','perfprogettoobiettivoattivita_completamento','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivitadocentiview','datetime','ASSISTENZA','perfprogettoobiettivoattivita_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivitadocentiview','varchar(64)','ASSISTENZA','perfprogettoobiettivoattivita_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','datetime','ASSISTENZA','perfprogettoobiettivoattivita_datafineeffettiva','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','datetime','ASSISTENZA','perfprogettoobiettivoattivita_datafineprevista','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','datetime','ASSISTENZA','perfprogettoobiettivoattivita_datainizioeffettiva','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','datetime','ASSISTENZA','perfprogettoobiettivoattivita_datainizioprevista','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','varchar(max)','ASSISTENZA','perfprogettoobiettivoattivita_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','int','ASSISTENZA','perfprogettoobiettivoattivita_idreg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivitadocentiview','datetime','ASSISTENZA','perfprogettoobiettivoattivita_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivitadocentiview','varchar(64)','ASSISTENZA','perfprogettoobiettivoattivita_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','int','','perfprogettoobiettivoattivita_paridperfprogettoobiettivoattivita','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','varchar(1024)','ASSISTENZA','perfprogettoobiettivoattivitaparent_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivitadocentiview','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI perfprogettoobiettivoattivitadocentiview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfprogettoobiettivoattivitadocentiview')
UPDATE customobject set isreal = 'N' where objectname = 'perfprogettoobiettivoattivitadocentiview'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfprogettoobiettivoattivitadocentiview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

