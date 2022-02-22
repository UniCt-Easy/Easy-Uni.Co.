
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


-- CREAZIONE VISTA learningagrtrainersegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[learningagrtrainersegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[learningagrtrainersegview]
GO

CREATE VIEW [dbo].[learningagrtrainersegview] AS 
SELECT  learningagrtrainer.address AS learningagrtrainer_address,CASE WHEN learningagrtrainer.assicurazienda = 'S' THEN 'Si' WHEN learningagrtrainer.assicurazienda = 'N' THEN 'No' END AS learningagrtrainer_assicurazienda,CASE WHEN learningagrtrainer.assicuraziendacivile = 'S' THEN 'Si' WHEN learningagrtrainer.assicuraziendacivile = 'N' THEN 'No' END AS learningagrtrainer_assicuraziendacivile,CASE WHEN learningagrtrainer.assicuraziendaspost = 'S' THEN 'Si' WHEN learningagrtrainer.assicuraziendaspost = 'N' THEN 'No' END AS learningagrtrainer_assicuraziendaspost,CASE WHEN learningagrtrainer.assicuraziendaviagg = 'S' THEN 'Si' WHEN learningagrtrainer.assicuraziendaviagg = 'N' THEN 'No' END AS learningagrtrainer_assicuraziendaviagg,CASE WHEN learningagrtrainer.assicuristituto = 'S' THEN 'Si' WHEN learningagrtrainer.assicuristituto = 'N' THEN 'No' END AS learningagrtrainer_assicuristituto,CASE WHEN learningagrtrainer.assicuristitutocivile = 'S' THEN 'Si' WHEN learningagrtrainer.assicuristitutocivile = 'N' THEN 'No' END AS learningagrtrainer_assicuristitutocivile,CASE WHEN learningagrtrainer.assicuristitutospost = 'S' THEN 'Si' WHEN learningagrtrainer.assicuristitutospost = 'N' THEN 'No' END AS learningagrtrainer_assicuristitutospost,CASE WHEN learningagrtrainer.assicuristitutoviagg = 'S' THEN 'Si' WHEN learningagrtrainer.assicuristitutoviagg = 'N' THEN 'No' END AS learningagrtrainer_assicuristitutoviagg, learningagrtrainer.cap AS learningagrtrainer_cap, learningagrtrainer.capacitaacquis AS learningagrtrainer_capacitaacquis, learningagrtrainer.ct AS learningagrtrainer_ct, learningagrtrainer.cu AS learningagrtrainer_cu, learningagrtrainer.ectscf AS learningagrtrainer_ectscf, learningagrtrainer.ectstitle AS learningagrtrainer_ectstitle, learningagrtrainer.idbandomi,
 [dbo].geo_city.title AS geo_city_title, learningagrtrainer.idcity, learningagrtrainer.idiscrizionebmi,
 [dbo].learningagrkind.title AS learningagrkind_title, [dbo].learningagrkind.description AS learningagrkind_description, learningagrtrainer.idlearningagrkind AS learningagrtrainer_idlearningagrkind, learningagrtrainer.idlearningagrtrainer,
 [dbo].learningagrtrainerkind.title AS learningagrtrainerkind_title, learningagrtrainer.idlearningagrtrainerkind AS learningagrtrainer_idlearningagrtrainerkind,
 [dbo].learningagrtrainervalut.title AS learningagrtrainervalut_title, [dbo].learningagrtrainervalut.description AS learningagrtrainervalut_description, learningagrtrainer.idlearningagrtrainervalut, learningagrtrainer.idnation AS learningagrtrainer_idnation, learningagrtrainer.idreg,
 registry_registry_aziendeaziende.title AS registryaziende_title, learningagrtrainer.idreg_aziende, learningagrtrainer.location AS learningagrtrainer_location, learningagrtrainer.lt AS learningagrtrainer_lt, learningagrtrainer.lu AS learningagrtrainer_lu, learningagrtrainer.oresettimana AS learningagrtrainer_oresettimana, learningagrtrainer.pianomonit AS learningagrtrainer_pianomonit, learningagrtrainer.pianovalut AS learningagrtrainer_pianovalut, learningagrtrainer.programma AS learningagrtrainer_programma,CASE WHEN learningagrtrainer.registrainemd = 'S' THEN 'Si' WHEN learningagrtrainer.registrainemd = 'N' THEN 'No' END AS learningagrtrainer_registrainemd,CASE WHEN learningagrtrainer.registraintor = 'S' THEN 'Si' WHEN learningagrtrainer.registraintor = 'N' THEN 'No' END AS learningagrtrainer_registraintor, learningagrtrainer.sostaltro AS learningagrtrainer_sostaltro, learningagrtrainer.sostazienda AS learningagrtrainer_sostazienda, learningagrtrainer.start AS learningagrtrainer_start, learningagrtrainer.stop AS learningagrtrainer_stop, learningagrtrainer.title, learningagrtrainer.voto AS learningagrtrainer_voto,(select top 1 cf 
						from dbo.convalida 
						where dbo.convalida.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by convalida.idconvalida asc ) as convalida_cf,
						(select top 1 cfintegrazione 
						from dbo.convalida 
						where dbo.convalida.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by convalida.idconvalida asc ) as convalida_cfintegrazione,
						(select top 1 data 
						from dbo.convalida 
						where dbo.convalida.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by convalida.idconvalida asc ) as convalida_data,
						(select top 1 iddichiar 
						from dbo.convalida 
						where dbo.convalida.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by convalida.idconvalida asc ) as iddichiar,
						(select top 1 iddidprog 
						from dbo.convalida 
						where dbo.convalida.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by convalida.idconvalida asc ) as iddidprog,
						(select top 1 idiscrizione 
						from dbo.convalida 
						where dbo.convalida.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by convalida.idconvalida asc ) as idiscrizione,
						(select top 1 idpratica 
						from dbo.convalida 
						where dbo.convalida.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by convalida.idconvalida asc ) as idpratica,
						(select top 1 voto 
						from dbo.convalida 
						where dbo.convalida.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by convalida.idconvalida asc ) as convalida_voto,
						(select top 1 CASE WHEN convalida.votolode = 'S' THEN 'Si' WHEN convalida.votolode = 'N' THEN 'No' END AS convalida_votolode 
						from dbo.convalida 
						where dbo.convalida.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by convalida.idconvalida asc ) as convalida_votolode,
						(select top 1 votosu 
						from dbo.convalida 
						where dbo.convalida.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by convalida.idconvalida asc ) as convalida_votosu,
						(select top 1 idcefr_compasc 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_compasc,
						(select top 1 idcefr_complett 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_complett,
						(select top 1 idcefr_parlinter 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_parlinter,
						(select top 1 idcefr_parlprod 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_parlprod,
						(select top 1 idcefr_scritto 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_scritto,
						(select top 1 idnation 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrtrainer = learningagrtrainer.idlearningagrtrainer
						 order by cefrlanglevel.idnation desc) as idnation,
 isnull('Titolo del tirocinio : ' + learningagrtrainer.title + '; ','') as dropdown_title
FROM [dbo].learningagrtrainer WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON learningagrtrainer.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].learningagrkind WITH (NOLOCK) ON learningagrtrainer.idlearningagrkind = [dbo].learningagrkind.idlearningagrkind
LEFT OUTER JOIN [dbo].learningagrtrainerkind WITH (NOLOCK) ON learningagrtrainer.idlearningagrtrainerkind = [dbo].learningagrtrainerkind.idlearningagrtrainerkind
LEFT OUTER JOIN [dbo].learningagrtrainervalut WITH (NOLOCK) ON learningagrtrainer.idlearningagrtrainervalut = [dbo].learningagrtrainervalut.idlearningagrtrainervalut
LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON learningagrtrainer.idreg_aziende = registry_aziendeaziende.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_aziendeaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registry_registry_aziendeaziende.idreg
WHERE  learningagrtrainer.idbandomi IS NOT NULL  AND learningagrtrainer.idiscrizionebmi IS NOT NULL  AND learningagrtrainer.idlearningagrtrainer IS NOT NULL  AND learningagrtrainer.idreg IS NOT NULL 
GO

-- VERIFICA DI learningagrtrainersegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'learningagrtrainersegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','cefrlanglevel_idcefr_compasc','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','cefrlanglevel_idcefr_complett','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','cefrlanglevel_idcefr_parlinter','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','cefrlanglevel_idcefr_parlprod','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','cefrlanglevel_idcefr_scritto','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','decimal(9,2)','','convalida_cf','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','decimal(9,2)','','convalida_cfintegrazione','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','datetime','','convalida_data','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','decimal(9,2)','','convalida_voto','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(2)','','convalida_votolode','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','convalida_votosu','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','varchar(max)','ASSISTENZA','dropdown_title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(65)','','geo_city_title','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','int','','idbandomi','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','idcity','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','iddichiar','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','iddidprog','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','idiscrizione','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','int','','idiscrizionebmi','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','int','','idlearningagrtrainer','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','idlearningagrtrainervalut','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','idnation','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','idpratica','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','int','','idreg','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','idreg_aziende','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(256)','','learningagrkind_description','256','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(50)','','learningagrkind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(100)','','learningagrtrainer_address','100','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(2)','','learningagrtrainer_assicurazienda','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(2)','','learningagrtrainer_assicuraziendacivile','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(2)','','learningagrtrainer_assicuraziendaspost','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(2)','','learningagrtrainer_assicuraziendaviagg','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(2)','','learningagrtrainer_assicuristituto','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(2)','','learningagrtrainer_assicuristitutocivile','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(2)','','learningagrtrainer_assicuristitutospost','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(2)','','learningagrtrainer_assicuristitutoviagg','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(20)','','learningagrtrainer_cap','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','varchar(max)','','learningagrtrainer_capacitaacquis','-1','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','datetime','','learningagrtrainer_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','varchar(64)','','learningagrtrainer_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','learningagrtrainer_ectscf','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(max)','','learningagrtrainer_ectstitle','-1','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','int','','learningagrtrainer_idlearningagrkind','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','int','','learningagrtrainer_idlearningagrtrainerkind','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','learningagrtrainer_idnation','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(20)','','learningagrtrainer_location','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','datetime','','learningagrtrainer_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','varchar(64)','','learningagrtrainer_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','int','','learningagrtrainer_oresettimana','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','varchar(max)','','learningagrtrainer_pianomonit','-1','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','varchar(max)','','learningagrtrainer_pianovalut','-1','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','varchar(max)','','learningagrtrainer_programma','-1','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(2)','','learningagrtrainer_registrainemd','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(2)','','learningagrtrainer_registraintor','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','decimal(9,2)','','learningagrtrainer_sostaltro','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','decimal(9,2)','','learningagrtrainer_sostazienda','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','date','','learningagrtrainer_start','3','S','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','date','','learningagrtrainer_stop','3','S','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','int','','learningagrtrainer_voto','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(50)','','learningagrtrainerkind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(256)','','learningagrtrainervalut_description','256','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(50)','','learningagrtrainervalut_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainersegview','varchar(101)','','registryaziende_title','101','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainersegview','varchar(max)','','title','-1','S','varchar','System.String','','','','','N')
GO

-- VERIFICA DI learningagrtrainersegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'learningagrtrainersegview')
UPDATE customobject set isreal = 'N' where objectname = 'learningagrtrainersegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('learningagrtrainersegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

