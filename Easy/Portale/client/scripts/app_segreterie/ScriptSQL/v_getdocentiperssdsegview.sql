
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


-- CREAZIONE VISTA getdocentiperssdsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[getdocentiperssdsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getdocentiperssdsegview]
GO

CREATE VIEW [getdocentiperssdsegview] AS 
SELECT  getdocentiperssd.aa, getdocentiperssd.cognome, getdocentiperssd.contratto AS getdocentiperssd_contratto, getdocentiperssd.costoorario AS getdocentiperssd_costoorario, getdocentiperssd.idreg,
 [dbo].sasd.codice AS sasd_codice, [dbo].sasd.title AS sasd_title, getdocentiperssd.idsasd, getdocentiperssd.iniziocontratto AS getdocentiperssd_iniziocontratto, getdocentiperssd.matricola AS getdocentiperssd_matricola, getdocentiperssd.nome AS getdocentiperssd_nome, getdocentiperssd.oremaxdida AS getdocentiperssd_oremaxdida, getdocentiperssd.oremindida AS getdocentiperssd_oremindida, getdocentiperssd.oreperaaaffidamento AS getdocentiperssd_oreperaaaffidamento, getdocentiperssd.oreperaacontratto AS getdocentiperssd_oreperaacontratto, getdocentiperssd.parttime AS getdocentiperssd_parttime, getdocentiperssd.ssd AS getdocentiperssd_ssd, getdocentiperssd.struttura AS getdocentiperssd_struttura,CASE WHEN getdocentiperssd.tempodefinito = 'S' THEN 'Si' WHEN getdocentiperssd.tempodefinito = 'N' THEN 'No' END AS getdocentiperssd_tempodefinito, getdocentiperssd.terminecontratto AS getdocentiperssd_terminecontratto,
 isnull('Cognome: ' + getdocentiperssd.cognome + '; ','') + ' ' + isnull('Nome: ' + getdocentiperssd.nome + '; ','') as dropdown_title
FROM getdocentiperssd WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].sasd WITH (NOLOCK) ON getdocentiperssd.idsasd = [dbo].sasd.idsasd
WHERE  getdocentiperssd.aa IS NOT NULL  AND getdocentiperssd.idreg IS NOT NULL 
GO

-- VERIFICA DI getdocentiperssdsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getdocentiperssdsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssdsegview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','varchar(50)','ASSISTENZA','cognome','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssdsegview','varchar(120)','ASSISTENZA','dropdown_title','120','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssdsegview','varchar(50)','ASSISTENZA','getdocentiperssd_contratto','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','decimal(18,2)','ASSISTENZA','getdocentiperssd_costoorario','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssdsegview','date','ASSISTENZA','getdocentiperssd_iniziocontratto','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','varchar(50)','ASSISTENZA','getdocentiperssd_matricola','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','varchar(50)','ASSISTENZA','getdocentiperssd_nome','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','int','ASSISTENZA','getdocentiperssd_oremaxdida','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','int','ASSISTENZA','getdocentiperssd_oremindida','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','int','ASSISTENZA','getdocentiperssd_oreperaaaffidamento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','int','ASSISTENZA','getdocentiperssd_oreperaacontratto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','decimal(5,2)','ASSISTENZA','getdocentiperssd_parttime','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','5','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssdsegview','varchar(50)','ASSISTENZA','getdocentiperssd_ssd','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','varchar(1024)','ASSISTENZA','getdocentiperssd_struttura','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','varchar(2)','ASSISTENZA','getdocentiperssd_tempodefinito','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssdsegview','date','ASSISTENZA','getdocentiperssd_terminecontratto','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssdsegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssdsegview','int','ASSISTENZA','idsasd','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','varchar(50)','ASSISTENZA','sasd_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssdsegview','varchar(255)','ASSISTENZA','sasd_title','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI getdocentiperssdsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getdocentiperssdsegview')
UPDATE customobject set isreal = 'N' where objectname = 'getdocentiperssdsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getdocentiperssdsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

