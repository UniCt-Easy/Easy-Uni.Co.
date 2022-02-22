
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


-- CREAZIONE VISTA sostenimentosegconsview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sostenimentosegconsview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sostenimentosegconsview]
GO

CREATE VIEW [dbo].[sostenimentosegconsview] AS 
SELECT  sostenimento.ct AS sostenimento_ct, sostenimento.cu AS sostenimento_cu, sostenimento.data AS sostenimento_data, sostenimento.domande AS sostenimento_domande, sostenimento.ects AS sostenimento_ects, sostenimento.giudizio,
 [dbo].appello.description AS appello_description, [dbo].appello.aa AS appello_aa, sostenimento.idappello,
 [dbo].attivform.title AS attivform_title, sostenimento.idattivform,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, sostenimento.idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].sede.idsede AS sede_idsede, sostenimento.iddidprog,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, sostenimento.idiscrizione,
 [dbo].prova.title AS prova_title, [dbo].prova.start AS prova_start, sostenimento.idprova,
 [dbo].registry.title AS registry_title, sostenimento.idreg, sostenimento.idsostenimento,
 [dbo].sostenimentoesito.title AS sostenimentoesito_title, sostenimento.idsostenimentoesito,
 [dbo].istattitolistudio.titolo AS istattitolistudio_titolo, [dbo].istattitolistudio.idistattitolistudio AS istattitolistudio_idistattitolistudio, [dbo].titolostudio.voto AS titolostudio_voto, [dbo].titolostudio.votosu AS titolostudio_votosu, [dbo].titolostudio.votolode AS titolostudio_votolode, [dbo].titolostudio.aa AS titolostudio_aa, sostenimento.idtitolostudio, sostenimento.insecod AS sostenimento_insecod, sostenimento.insedesc AS sostenimento_insedesc,CASE WHEN sostenimento.livello = 'S' THEN 'Si' WHEN sostenimento.livello = 'N' THEN 'No' END AS sostenimento_livello, sostenimento.lt AS sostenimento_lt, sostenimento.lu AS sostenimento_lu,
 attivform_sostenimento.title AS attivform_sostenimento_title, attivform_sostenimento.idattivform AS attivform_sostenimento_idattivform, sostenimentoparent.idreg AS sostenimentoparent_idreg, sostenimentoparent.voto AS sostenimentoparent_voto, sostenimentoparent.votosu AS sostenimentoparent_votosu, sostenimentoparent.votolode AS sostenimentoparent_votolode, sostenimento.paridsostenimento, sostenimento.protanno AS sostenimento_protanno, sostenimento.protnumero AS sostenimento_protnumero, sostenimento.voto AS sostenimento_voto,CASE WHEN sostenimento.votolode = 'S' THEN 'Si' WHEN sostenimento.votolode = 'N' THEN 'No' END AS sostenimento_votolode, sostenimento.votosu AS sostenimento_votosu,
 isnull('Titolo : ' + [dbo].istattitolistudio.titolo + '; ','') + ' ' + isnull('Titolo : ' + CAST( [dbo].istattitolistudio.idistattitolistudio AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Attività formativa Attività formativa: ' + attivform_sostenimento.title + '; ','') + ' ' + isnull('Attività formativa Attività formativa: ' + CAST( attivform_sostenimento.idattivform AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Sede Sede: ' + CAST( [dbo].sede.idsede AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].sostenimento WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].appello WITH (NOLOCK) ON sostenimento.idappello = [dbo].appello.idappello
LEFT OUTER JOIN [dbo].attivform WITH (NOLOCK) ON sostenimento.idattivform = [dbo].attivform.idattivform
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON sostenimento.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON sostenimento.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON sostenimento.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].prova WITH (NOLOCK) ON sostenimento.idprova = [dbo].prova.idprova
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON sostenimento.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].sostenimentoesito WITH (NOLOCK) ON sostenimento.idsostenimentoesito = [dbo].sostenimentoesito.idsostenimentoesito
LEFT OUTER JOIN [dbo].titolostudio WITH (NOLOCK) ON sostenimento.idtitolostudio = [dbo].titolostudio.idtitolostudio
LEFT OUTER JOIN [dbo].istattitolistudio WITH (NOLOCK) ON titolostudio.idistattitolistudio = [dbo].istattitolistudio.idistattitolistudio
LEFT OUTER JOIN [dbo].sostenimento AS sostenimentoparent WITH (NOLOCK) ON sostenimento.paridsostenimento = sostenimentoparent.idsostenimento
LEFT OUTER JOIN [dbo].attivform AS attivform_sostenimento WITH (NOLOCK) ON sostenimentoparent.idattivform = attivform_sostenimento.idattivform
WHERE  sostenimento.idreg IS NOT NULL  AND sostenimento.idsostenimento IS NOT NULL 
GO

