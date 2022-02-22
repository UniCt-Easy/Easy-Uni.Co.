
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

