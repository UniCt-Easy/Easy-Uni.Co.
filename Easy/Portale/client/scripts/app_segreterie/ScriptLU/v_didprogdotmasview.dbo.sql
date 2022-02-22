
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


-- CREAZIONE VISTA didprogdotmasview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogdotmasview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[didprogdotmasview]
GO

CREATE VIEW [dbo].[didprogdotmasview] AS 
SELECT  didprog.aa, didprog.annosolare AS didprog_annosolare, didprog.attribdebiti AS didprog_attribdebiti, didprog.ciclo AS didprog_ciclo, didprog.codice AS didprog_codice, didprog.codicemiur AS didprog_codicemiur, didprog.dataconsmaxiscr AS didprog_dataconsmaxiscr,CASE WHEN didprog.freqobbl = 'S' THEN 'Si' WHEN didprog.freqobbl = 'N' THEN 'No' END AS didprog_freqobbl, didprog.idareadidattica AS didprog_idareadidattica, didprog.idconvenzione AS didprog_idconvenzione, didprog.idcorsostudio, didprog.iddidprog, didprog.iddidprognumchiusokind AS didprog_iddidprognumchiusokind, didprog.iddidprogsuddannokind AS didprog_iddidprogsuddannokind, didprog.iderogazkind AS didprog_iderogazkind,
 [dbo].graduatoria.title AS graduatoria_title, didprog.idgraduatoria,
 geo_nationlang.lang AS geo_nationlang_lang, didprog.idnation_lang, didprog.idnation_lang2 AS didprog_idnation_lang2,
 geo_nationlangvis.lang AS geo_nationlangvis_lang, didprog.idnation_langvis, didprog.idreg_docenti AS didprog_idreg_docenti,
 [dbo].sede.title AS sede_title, didprog.idsede, didprog.idsessione AS didprog_idsessione, didprog.idtitolokind AS didprog_idtitolokind,CASE WHEN didprog.immatoltreauth = 'S' THEN 'Si' WHEN didprog.immatoltreauth = 'N' THEN 'No' END AS didprog_immatoltreauth, didprog.modaccesso AS didprog_modaccesso, didprog.modaccesso_en AS didprog_modaccesso_en, didprog.obbformativi AS didprog_obbformativi, didprog.obbformativi_en AS didprog_obbformativi_en,CASE WHEN didprog.preimmatoltreauth = 'S' THEN 'Si' WHEN didprog.preimmatoltreauth = 'N' THEN 'No' END AS didprog_preimmatoltreauth, didprog.progesamamm AS didprog_progesamamm, didprog.prospoccupaz AS didprog_prospoccupaz, didprog.provafinaledesc AS didprog_provafinaledesc, didprog.regolamentotax AS didprog_regolamentotax, didprog.regolamentotaxurl AS didprog_regolamentotaxurl, didprog.startiscrizioni AS didprog_startiscrizioni, didprog.stopiscrizioni AS didprog_stopiscrizioni, didprog.title, didprog.title_en AS didprog_title_en, didprog.utenzasost AS didprog_utenzasost, didprog.website AS didprog_website,
 isnull('Denominazione: ' + didprog.title + '; ','') + ' ' + isnull('Anno accademico: ' + didprog.aa + '; ','') as dropdown_title
FROM [dbo].didprog WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].graduatoria WITH (NOLOCK) ON didprog.idgraduatoria = [dbo].graduatoria.idgraduatoria
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang WITH (NOLOCK) ON didprog.idnation_lang = geo_nationlang.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlangvis WITH (NOLOCK) ON didprog.idnation_langvis = geo_nationlangvis.idnation
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
WHERE  didprog.idcorsostudio IS NOT NULL  AND didprog.iddidprog IS NOT NULL 
GO

