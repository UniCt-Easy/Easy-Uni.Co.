
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


-- CREAZIONE VISTA sostenimentoingressoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sostenimentoingressoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sostenimentoingressoview]
GO

CREATE VIEW [dbo].[sostenimentoingressoview] AS 
SELECT  sostenimento.ct AS sostenimento_ct, sostenimento.cu AS sostenimento_cu, sostenimento.data AS sostenimento_data, sostenimento.domande AS sostenimento_domande, sostenimento.ects AS sostenimento_ects, sostenimento.giudizio AS sostenimento_giudizio, sostenimento.idappello AS sostenimento_idappello, sostenimento.idattivform AS sostenimento_idattivform, sostenimento.idcorsostudio, sostenimento.iddidprog,
 [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, sostenimento.idiscrizione, sostenimento.idprova,
 [dbo].registry.title AS registry_title, sostenimento.idreg, sostenimento.idsostenimento,
 [dbo].sostenimentoesito.title AS sostenimentoesito_title, sostenimento.idsostenimentoesito AS sostenimento_idsostenimentoesito, sostenimento.idtitolostudio AS sostenimento_idtitolostudio, sostenimento.insecod AS sostenimento_insecod, sostenimento.insedesc AS sostenimento_insedesc,CASE WHEN sostenimento.livello = 'A' THEN 'A ' WHEN sostenimento.livello = 'B' THEN 'B ' WHEN sostenimento.livello = 'C' THEN 'C ' WHEN sostenimento.livello = 'D' THEN 'D ' END AS sostenimento_livello, sostenimento.lt AS sostenimento_lt, sostenimento.lu AS sostenimento_lu, sostenimento.paridsostenimento AS sostenimento_paridsostenimento, sostenimento.protanno AS sostenimento_protanno, sostenimento.protnumero AS sostenimento_protnumero, sostenimento.voto AS sostenimento_voto,CASE WHEN sostenimento.votolode = 'S' THEN 'Si' WHEN sostenimento.votolode = 'N' THEN 'No' END AS sostenimento_votolode, sostenimento.votosu AS sostenimento_votosu,
 isnull('Studente: ' + [dbo].registry.title + '; ','') + ' ' + isnull('Voto: ' + CAST( sostenimento.voto AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Su: ' + CAST( sostenimento.votosu AS NVARCHAR(64)) + '; ','') + ' ' + isnull('' + CASE WHEN sostenimento.votolode = 'S' THEN 'Lode' ELSE '' END,'') as dropdown_title
FROM [dbo].sostenimento WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON sostenimento.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON sostenimento.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].sostenimentoesito WITH (NOLOCK) ON sostenimento.idsostenimentoesito = [dbo].sostenimentoesito.idsostenimentoesito
WHERE  sostenimento.idcorsostudio IS NOT NULL  AND sostenimento.iddidprog IS NOT NULL  AND sostenimento.idprova IS NOT NULL  AND sostenimento.idreg IS NOT NULL  AND sostenimento.idsostenimento IS NOT NULL 
GO

