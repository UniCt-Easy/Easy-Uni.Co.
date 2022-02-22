
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
-- CREAZIONE VISTA sostenimentosegconsview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sostenimentosegconsview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sostenimentosegconsview]
GO

CREATE VIEW [dbo].[sostenimentosegconsview] AS SELECT  sostenimento.ct AS sostenimento_ct, sostenimento.cu AS sostenimento_cu, sostenimento.data AS sostenimento_data, sostenimento.domande AS sostenimento_domande, sostenimento.ects AS sostenimento_ects, sostenimento.giudizio, [dbo].appello.description AS appello_description, [dbo].annoaccademico.aa AS annoaccademico_aa, sostenimento.idappello, [dbo].attivform.title AS attivform_title, sostenimento.idattivform, [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, sostenimento.idcorsostudio, [dbo].didprog.title AS didprog_title, annoaccademico_didprog.aa AS annoaccademico_didprog_aa, [dbo].sede.title AS sede_title, sostenimento.iddidprog, [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, annoaccademico_iscrizione.aa AS annoaccademico_iscrizione_aa, sostenimento.idiscrizione, [dbo].prova.title AS prova_title, [dbo].prova.start AS prova_start, sostenimento.idprova, sostenimento.idreg, sostenimento.idsostenimento, [dbo].sostenimentoesito.title AS sostenimentoesito_title, sostenimento.idsostenimentoesito, [dbo].istattitolistudio.titolo AS istattitolistudio_titolo, [dbo].titolostudio.voto AS titolostudio_voto, [dbo].titolostudio.votosu AS titolostudio_votosu, [dbo].titolostudio.votolode AS titolostudio_votolode, annoaccademico_titolostudio.aa AS annoaccademico_titolostudio_aa, sostenimento.idtitolostudio, sostenimento.insecod AS sostenimento_insecod, sostenimento.insedesc AS sostenimento_insedesc,CASE WHEN sostenimento.livello = 'S' THEN 'Si' WHEN sostenimento.livello = 'N' THEN 'No' END AS sostenimento_livello, sostenimento.lt AS sostenimento_lt, sostenimento.lu AS sostenimento_lu, attivform_sostenimento.title AS attivform_sostenimento_title, sostenimentoparent.idreg AS sostenimentoparent_idreg, sostenimentoparent.voto AS sostenimentoparent_voto, sostenimentoparent.votosu AS sostenimentoparent_votosu, sostenimentoparent.votolode AS sostenimentoparent_votolode, sostenimento.paridsostenimento, sostenimento.protanno AS sostenimento_protanno, sostenimento.protnumero AS sostenimento_protnumero, sostenimento.voto AS sostenimento_voto,CASE WHEN sostenimento.votolode = 'S' THEN 'Si' WHEN sostenimento.votolode = 'N' THEN 'No' END AS sostenimento_votolode, sostenimento.votosu AS sostenimento_votosu, isnull('Titolo di studio Titolo ISTAT: ' + [dbo].istattitolistudio.titolo + '; ','') + ' ' + isnull('Attività formativa Attività formativa: ' + attivform_sostenimento.title + '; ','') + ' ' + isnull('Codice Anno accademico: ' + [dbo].annoaccademico.aa + '; ','') + ' ' + isnull('Codice Anno accademico: ' + annoaccademico_didprog.aa + '; ','') + ' ' + isnull('Codice Anno accademico: ' + annoaccademico_iscrizione.aa + '; ','') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Codice Anno accademco: ' + annoaccademico_titolostudio.aa + '; ','') as dropdown_title FROM [dbo].sostenimento WITH (NOLOCK)  LEFT OUTER JOIN [dbo].appello WITH (NOLOCK) ON sostenimento.idappello = [dbo].appello.idappello LEFT OUTER JOIN [dbo].annoaccademico WITH (NOLOCK) ON appello.aa = [dbo].annoaccademico.aa LEFT OUTER JOIN [dbo].attivform WITH (NOLOCK) ON sostenimento.idattivform = [dbo].attivform.idattivform LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON sostenimento.idcorsostudio = [dbo].corsostudio.idcorsostudio LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON sostenimento.iddidprog = [dbo].didprog.iddidprog LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_didprog WITH (NOLOCK) ON didprog.aa = annoaccademico_didprog.aa LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON sostenimento.idiscrizione = [dbo].iscrizione.idiscrizione LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_iscrizione WITH (NOLOCK) ON iscrizione.aa = annoaccademico_iscrizione.aa LEFT OUTER JOIN [dbo].prova WITH (NOLOCK) ON sostenimento.idprova = [dbo].prova.idprova LEFT OUTER JOIN [dbo].sostenimentoesito WITH (NOLOCK) ON sostenimento.idsostenimentoesito = [dbo].sostenimentoesito.idsostenimentoesito LEFT OUTER JOIN [dbo].titolostudio WITH (NOLOCK) ON sostenimento.idtitolostudio = [dbo].titolostudio.idtitolostudio LEFT OUTER JOIN [dbo].istattitolistudio WITH (NOLOCK) ON titolostudio.idistattitolistudio = [dbo].istattitolistudio.idistattitolistudio LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_titolostudio WITH (NOLOCK) ON titolostudio.aa = annoaccademico_titolostudio.aa LEFT OUTER JOIN [dbo].sostenimento AS sostenimentoparent WITH (NOLOCK) ON sostenimento.paridsostenimento = sostenimentoparent.idsostenimento LEFT OUTER JOIN [dbo].attivform AS attivform_sostenimento WITH (NOLOCK) ON sostenimento.idattivform = attivform_sostenimento.idattivform WHERE  sostenimento.idreg IS NOT NULL  AND sostenimento.idsostenimento IS NOT NULL 
GO

-- VERIFICA DI sostenimentosegconsview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sostenimentosegconsview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','nvarchar(9)','','annoaccademico_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','nvarchar(9)','','annoaccademico_didprog_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','nvarchar(9)','','annoaccademico_iscrizione_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','nvarchar(9)','','annoaccademico_titolostudio_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','varchar(1024)','ASSISTENZA','appello_description','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','nvarchar(max)','','attivform_sostenimento_title','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','nvarchar(max)','ASSISTENZA','attivform_title','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','','corsostudio_annoistituz','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','varchar(1024)','ASSISTENZA','corsostudio_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','varchar(1024)','ASSISTENZA','didprog_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentosegconsview','nvarchar(max)','','dropdown_title','0','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','varchar(50)','ASSISTENZA','giudizio','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','idappello','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','idattivform','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','idiscrizione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','idprova','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentosegconsview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentosegconsview','int','ASSISTENZA','idsostenimento','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentosegconsview','int','ASSISTENZA','idsostenimentoesito','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','idtitolostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','iscrizione_anno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','iscrizione_iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','varchar(1024)','','istattitolistudio_titolo','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','paridsostenimento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','datetime','ASSISTENZA','prova_start','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','varchar(50)','ASSISTENZA','prova_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','nvarchar(1024)','','sede_title','1024','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentosegconsview','datetime','ASSISTENZA','sostenimento_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentosegconsview','varchar(64)','ASSISTENZA','sostenimento_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentosegconsview','date','ASSISTENZA','sostenimento_data','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','ntext','ASSISTENZA','sostenimento_domande','16','N','ntext','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','sostenimento_ects','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','varchar(50)','ASSISTENZA','sostenimento_insecod','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','varchar(1024)','ASSISTENZA','sostenimento_insedesc','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','varchar(2)','ASSISTENZA','sostenimento_livello','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentosegconsview','datetime','ASSISTENZA','sostenimento_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentosegconsview','varchar(64)','ASSISTENZA','sostenimento_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','sostenimento_protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','sostenimento_protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','decimal(9,2)','ASSISTENZA','sostenimento_voto','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','varchar(2)','ASSISTENZA','sostenimento_votolode','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','sostenimento_votosu','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','varchar(50)','ASSISTENZA','sostenimentoesito_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','','sostenimentoparent_idreg','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','decimal(9,2)','','sostenimentoparent_voto','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','char(1)','ASSISTENZA','sostenimentoparent_votolode','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','','sostenimentoparent_votosu','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','titolostudio_voto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','char(1)','ASSISTENZA','titolostudio_votolode','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentosegconsview','int','ASSISTENZA','titolostudio_votosu','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI sostenimentosegconsview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sostenimentosegconsview')
UPDATE customobject set isreal = 'N' where objectname = 'sostenimentosegconsview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sostenimentosegconsview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

