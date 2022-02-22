
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


-- CREAZIONE VISTA praticasegstuelencoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[praticasegstuelencoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[praticasegstuelencoview]
GO

CREATE VIEW [dbo].[praticasegstuelencoview] AS 
SELECT  pratica.ct AS pratica_ct, pratica.cu AS pratica_cu,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, pratica.idcorsostudio,
 [dbo].dichiarkind.title AS dichiarkind_title, [dbo].dichiarkind.iddichiarkind AS dichiarkind_iddichiarkind, [dbo].dichiar.aa AS dichiar_aa, [dbo].dichiar.date AS dichiar_date, pratica.iddichiar,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].sede.idsede AS sede_idsede, pratica.iddidprog,
 [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, pratica.idiscrizione,
 iscrizione_pratica.iddidprog AS iscrizione_pratica_iddidprog, iscrizione_pratica.aa AS iscrizione_pratica_aa, pratica.idiscrizione_from AS pratica_idiscrizione_from,
 istanza_istanza_imm.idistanzakind AS istanza_idistanzakind, istanza_istanza_imm.idreg_studenti AS istanza_idreg_studenti, istanza_istanza_imm.aa AS istanza_aa, istanza_istanza_imm.data AS istanza_data, istanza_istanza_imm.iddidprog AS istanza_iddidprog, istanza_istanza_imm.idstatuskind AS istanza_idstatuskind, istanza_istanza_imm.idiscrizione AS istanza_idiscrizione, pratica.idistanza,
 [dbo].istanzakind.title AS istanzakind_title, pratica.idistanzakind, pratica.idpratica,
 [dbo].registry.title AS registry_title, pratica.idreg,
 [dbo].statuskind.title AS statuskind_title, pratica.idstatuskind AS pratica_idstatuskind,
 [dbo].istattitolistudio.titolo AS istattitolistudio_titolo, [dbo].istattitolistudio.idistattitolistudio AS istattitolistudio_idistattitolistudio, [dbo].titolostudio.voto AS titolostudio_voto, [dbo].titolostudio.votosu AS titolostudio_votosu, [dbo].titolostudio.votolode AS titolostudio_votolode, [dbo].titolostudio.aa AS titolostudio_aa, pratica.idtitolostudio AS pratica_idtitolostudio, pratica.lt AS pratica_lt, pratica.lu AS pratica_lu, pratica.protanno AS pratica_protanno, pratica.protnumero AS pratica_protnumero,
 isnull('Tipologia Tipologia: ' + [dbo].dichiarkind.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + CAST( [dbo].dichiarkind.iddichiarkind AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Studente: ' + [dbo].registry.title + '; ','') + ' ' + isnull('Titolo di studio Titolo ISTAT: ' + [dbo].istattitolistudio.titolo + '; ','') + ' ' + isnull('Titolo ISTAT Titolo ISTAT: ' + CAST( [dbo].istattitolistudio.idistattitolistudio AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Didattica programmata: ' + [dbo].didprog.title + '; ','') + ' ' + isnull('Didattica programmata: ' + [dbo].didprog.aa + '; ','') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Sede Sede: ' + CAST( [dbo].sede.idsede AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].pratica WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON pratica.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].dichiar WITH (NOLOCK) ON pratica.iddichiar = [dbo].dichiar.iddichiar
LEFT OUTER JOIN [dbo].dichiarkind WITH (NOLOCK) ON dichiar.iddichiarkind = [dbo].dichiarkind.iddichiarkind
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON pratica.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON pratica.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].iscrizione AS iscrizione_pratica WITH (NOLOCK) ON pratica.idiscrizione_from = iscrizione_pratica.idiscrizione
LEFT OUTER JOIN [dbo].istanza_imm WITH (NOLOCK) ON pratica.idistanza = [dbo].istanza_imm.idistanza
LEFT OUTER JOIN [dbo].istanza AS istanza_istanza_imm WITH (NOLOCK) ON [dbo].istanza_imm.idistanza = istanza_istanza_imm.idistanza
LEFT OUTER JOIN [dbo].istanzakind WITH (NOLOCK) ON pratica.idistanzakind = [dbo].istanzakind.idistanzakind
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON pratica.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON pratica.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].titolostudio WITH (NOLOCK) ON pratica.idtitolostudio = [dbo].titolostudio.idtitolostudio
LEFT OUTER JOIN [dbo].istattitolistudio WITH (NOLOCK) ON titolostudio.idistattitolistudio = [dbo].istattitolistudio.idistattitolistudio
WHERE  pratica.idcorsostudio IS NOT NULL  AND pratica.iddidprog IS NOT NULL  AND pratica.idiscrizione IS NOT NULL  AND pratica.idistanza IS NOT NULL  AND pratica.idistanzakind IS NOT NULL  AND pratica.idpratica IS NOT NULL  AND pratica.idreg IS NOT NULL 
GO

