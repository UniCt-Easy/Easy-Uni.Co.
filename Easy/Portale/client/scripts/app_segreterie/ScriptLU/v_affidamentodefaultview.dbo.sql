
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA affidamentodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[affidamentodefaultview]
GO

CREATE VIEW [dbo].[affidamentodefaultview] AS 
SELECT  affidamento.aa, affidamento.ct AS affidamento_ct, affidamento.cu AS affidamento_cu,CASE WHEN affidamento.freqobbl = 'S' THEN 'Si' WHEN affidamento.freqobbl = 'N' THEN 'No' END AS affidamento_freqobbl, affidamento.frequenzaminima AS affidamento_frequenzaminima, affidamento.frequenzaminimadebito AS affidamento_frequenzaminimadebito,CASE WHEN affidamento.gratuito = 'S' THEN 'Si' WHEN affidamento.gratuito = 'N' THEN 'No' END AS affidamento_gratuito, affidamento.idaffidamento,
 [dbo].affidamentokind.title AS affidamentokind_title, affidamento.idaffidamentokind AS affidamento_idaffidamentokind, affidamento.idattivform, affidamento.idcanale, affidamento.idcorsostudio, affidamento.iddidprog, affidamento.iddidproganno, affidamento.iddidprogcurr, affidamento.iddidprogori, affidamento.iddidprogporzanno,
 [dbo].erogazkind.title AS erogazkind_title, affidamento.iderogazkind AS affidamento_iderogazkind,
 registrydocenti.title AS registrydocenti_title, affidamento.idreg_docenti, affidamento.idsede AS affidamento_idsede, affidamento.json AS affidamento_json, affidamento.jsonancestor AS affidamento_jsonancestor, affidamento.lt AS affidamento_lt, affidamento.lu AS affidamento_lu, affidamento.orariric AS affidamento_orariric, affidamento.orariric_en AS affidamento_orariric_en, affidamento.paridaffidamento AS affidamento_paridaffidamento, affidamento.prog AS affidamento_prog, affidamento.prog_en AS affidamento_prog_en,CASE WHEN affidamento.riferimento = 'S' THEN 'Si' WHEN affidamento.riferimento = 'N' THEN 'No' END AS affidamento_riferimento, affidamento.start AS affidamento_start, affidamento.stop AS affidamento_stop, affidamento.testi AS affidamento_testi, affidamento.testi_en AS affidamento_testi_en, affidamento.title AS affidamento_title, affidamento.urlcorso AS affidamento_urlcorso,
 isnull('Affidamento: ' + affidamento.json + '; ','') + ' ' + isnull('Docente: ' + registrydocenti.title + '; ','') + ' ' + isnull('Tipologia: ' + [dbo].affidamentokind.title + '; ','') + ' ' + isnull('Tipo di erogazione: ' + [dbo].erogazkind.title + '; ','') + ' ' + isnull('' + CASE WHEN affidamento.freqobbl = 'S' THEN 'Frequenza obbligatoria' ELSE 'non Frequenza obbligatoria' END,'') + ' ' + isnull('dal ' + CONVERT(VARCHAR, affidamento.start, 103),'') + ' ' + isnull('al ' + CONVERT(VARCHAR, affidamento.stop, 103),'') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull(CAST(affidamentocaratteristica.cf AS NVARCHAR(64)),'0.00') AS Crediti,isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Descrizione: ' +description from tipoattform x where x.idtipoattform = affidamentocaratteristica.idtipoattform) + '; ','') AS Tipo_di_attivit�_formativa,isnull((Select top 1 'Ambito: ' +title from ambitoareadisc x where x.idambitoareadisc = affidamentocaratteristica.idambitoareadisc) + '; ','') AS Ambito_o_area_disciplinare,isnull((Select top 1 'Codice: ' +codice + '; ' + 'Denominazione: ' +title from sasd x where x.idsasd = affidamentocaratteristica.idsasd) + '; ','') AS SASD,isnull('' + CASE WHEN affidamentocaratteristica.profess = 'S' THEN 'Professionalizzante' ELSE 'non Professionalizzante' END,'') AS Professionalizzante FROM  dbo.affidamentocaratteristica
 WHERE affidamentocaratteristica.aa = affidamento.aa AND affidamentocaratteristica.idaffidamento = affidamento.idaffidamento AND affidamentocaratteristica.idattivform = affidamento.idattivform AND affidamentocaratteristica.idcanale = affidamento.idcanale AND affidamentocaratteristica.idcorsostudio = affidamento.idcorsostudio AND affidamentocaratteristica.iddidprog = affidamento.iddidprog AND affidamentocaratteristica.iddidproganno = affidamento.iddidproganno AND affidamentocaratteristica.iddidprogcurr = affidamento.iddidprogcurr AND affidamentocaratteristica.iddidprogori = affidamento.iddidprogori AND affidamentocaratteristica.iddidprogporzanno = affidamento.iddidprogporzanno FOR XML path, root)))) AS XXaffidamentocaratteristica 
FROM [dbo].affidamento WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].affidamentokind WITH (NOLOCK) ON affidamento.idaffidamentokind = [dbo].affidamentokind.idaffidamentokind
LEFT OUTER JOIN [dbo].erogazkind WITH (NOLOCK) ON affidamento.iderogazkind = [dbo].erogazkind.iderogazkind
LEFT OUTER JOIN [dbo].registry_docenti AS registry_docentidocenti WITH (NOLOCK) ON affidamento.idreg_docenti = registry_docentidocenti.idreg
LEFT OUTER JOIN [dbo].registry AS registrydocenti WITH (NOLOCK) ON registry_docentidocenti.idreg = registrydocenti.idreg
WHERE  affidamento.aa IS NOT NULL  AND affidamento.idaffidamento IS NOT NULL  AND affidamento.idattivform IS NOT NULL  AND affidamento.idcanale IS NOT NULL  AND affidamento.idcorsostudio IS NOT NULL  AND affidamento.iddidprog IS NOT NULL  AND affidamento.iddidproganno IS NOT NULL  AND affidamento.iddidprogcurr IS NOT NULL  AND affidamento.iddidprogori IS NOT NULL  AND affidamento.iddidprogporzanno IS NOT NULL 
GO
