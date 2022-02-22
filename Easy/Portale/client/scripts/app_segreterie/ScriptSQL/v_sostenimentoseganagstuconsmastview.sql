
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
-- CREAZIONE VISTA sostenimentoseganagstuconsmastview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sostenimentoseganagstuconsmastview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sostenimentoseganagstuconsmastview]
GO

CREATE VIEW [dbo].[sostenimentoseganagstuconsmastview] AS SELECT  sostenimento.ct AS sostenimento_ct, sostenimento.cu AS sostenimento_cu, sostenimento.data AS sostenimento_data, sostenimento.domande AS sostenimento_domande, sostenimento.ects AS sostenimento_ects, sostenimento.giudizio AS sostenimento_giudizio, sostenimento.idappello AS sostenimento_idappello, sostenimento.idattivform AS sostenimento_idattivform, sostenimento.idcorsostudio, sostenimento.iddidprog, sostenimento.idiscrizione, [dbo].prova.title AS prova_title, [dbo].prova.start AS prova_start, sostenimento.idprova, [dbo].registry.title AS registry_title, sostenimento.idreg, sostenimento.idsostenimento, [dbo].sostenimentoesito.title AS sostenimentoesito_title, sostenimento.idsostenimentoesito AS sostenimento_idsostenimentoesito, sostenimento.idtitolostudio AS sostenimento_idtitolostudio, sostenimento.insecod AS sostenimento_insecod, sostenimento.insedesc AS sostenimento_insedesc,CASE WHEN sostenimento.livello = 'A' THEN 'A ' WHEN sostenimento.livello = 'B' THEN 'B ' WHEN sostenimento.livello = 'C' THEN 'C ' WHEN sostenimento.livello = 'D' THEN 'D ' END AS sostenimento_livello, sostenimento.lt AS sostenimento_lt, sostenimento.lu AS sostenimento_lu, sostenimento.paridsostenimento AS sostenimento_paridsostenimento, sostenimento.protanno AS sostenimento_protanno, sostenimento.protnumero AS sostenimento_protnumero, sostenimento.voto AS sostenimento_voto,CASE WHEN sostenimento.votolode = 'S' THEN 'Si' WHEN sostenimento.votolode = 'N' THEN 'No' END AS sostenimento_votolode, sostenimento.votosu AS sostenimento_votosu, isnull('Studente: ' + [dbo].registry.title + '; ','') + ' ' + isnull('Voto: ' + CAST( sostenimento.voto AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Su: ' + CAST( sostenimento.votosu AS NVARCHAR(64)) + '; ','') + ' ' + isnull('' + CASE WHEN sostenimento.votolode = 'S' THEN 'Lode' ELSE '' END,'') as dropdown_title FROM [dbo].sostenimento WITH (NOLOCK)  LEFT OUTER JOIN [dbo].prova WITH (NOLOCK) ON sostenimento.idprova = [dbo].prova.idprova LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON sostenimento.idreg = [dbo].registry.idreg LEFT OUTER JOIN [dbo].sostenimentoesito WITH (NOLOCK) ON sostenimento.idsostenimentoesito = [dbo].sostenimentoesito.idsostenimentoesito WHERE  sostenimento.idcorsostudio IS NOT NULL  AND sostenimento.iddidprog IS NOT NULL  AND sostenimento.idiscrizione IS NOT NULL  AND sostenimento.idprova IS NOT NULL  AND sostenimento.idreg IS NOT NULL  AND sostenimento.idsostenimento IS NOT NULL 
GO

-- VERIFICA DI sostenimentoseganagstuconsmastview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sostenimentoseganagstuconsmastview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoseganagstuconsmastview','nvarchar(263)','ASSISTENZA','dropdown_title','263','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','idiscrizione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','idprova','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoseganagstuconsmastview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoseganagstuconsmastview','int','ASSISTENZA','idsostenimento','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','datetime','ASSISTENZA','prova_start','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','varchar(50)','ASSISTENZA','prova_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoseganagstuconsmastview','datetime','ASSISTENZA','sostenimento_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoseganagstuconsmastview','varchar(64)','ASSISTENZA','sostenimento_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoseganagstuconsmastview','date','ASSISTENZA','sostenimento_data','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','ntext','ASSISTENZA','sostenimento_domande','16','N','ntext','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','sostenimento_ects','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','varchar(50)','ASSISTENZA','sostenimento_giudizio','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','sostenimento_idappello','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','sostenimento_idattivform','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoseganagstuconsmastview','int','ASSISTENZA','sostenimento_idsostenimentoesito','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','sostenimento_idtitolostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','varchar(50)','ASSISTENZA','sostenimento_insecod','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','varchar(1024)','ASSISTENZA','sostenimento_insedesc','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','varchar(2)','ASSISTENZA','sostenimento_livello','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoseganagstuconsmastview','datetime','ASSISTENZA','sostenimento_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sostenimentoseganagstuconsmastview','varchar(64)','ASSISTENZA','sostenimento_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','sostenimento_paridsostenimento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','sostenimento_protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','sostenimento_protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','decimal(9,2)','ASSISTENZA','sostenimento_voto','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','varchar(2)','ASSISTENZA','sostenimento_votolode','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','int','ASSISTENZA','sostenimento_votosu','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sostenimentoseganagstuconsmastview','varchar(50)','ASSISTENZA','sostenimentoesito_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI sostenimentoseganagstuconsmastview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sostenimentoseganagstuconsmastview')
UPDATE customobject set isreal = 'N' where objectname = 'sostenimentoseganagstuconsmastview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sostenimentoseganagstuconsmastview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

