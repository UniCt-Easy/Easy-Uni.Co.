
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


-- CREAZIONE VISTA istanzarein_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzarein_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzarein_segview]
GO

CREATE VIEW [dbo].[istanzarein_segview] AS 
SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data AS istanza_data, istanza.extension AS istanza_extension,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, istanza.idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].sede.idsede AS sede_idsede, istanza.iddidprog,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, istanza.idiscrizione, istanza.idistanza, istanza.idistanzakind,
 registry_registry_studentistudenti.title AS registrystudenti_title, istanza.idreg_studenti,
 [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu,
 istanzaparent.idistanzakind AS istanzaparent_idistanzakind, istanzaparent.aa AS istanzaparent_aa, istanzaparent.data AS istanzaparent_data, iscrizione_istanza.anno AS iscrizione_istanza_anno, iscrizione_istanza.iddidprog AS iscrizione_istanza_iddidprog, iscrizione_istanza.aa AS iscrizione_istanza_aa, iscrizione_istanza.idiscrizione AS iscrizione_istanza_idiscrizione, istanza.paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_rein.aa_rindec, istanza_rein.ct AS istanza_rein_ct, istanza_rein.cu AS istanza_rein_cu,CASE WHEN istanza_rein.darindec = 'D' THEN 'Decadenza' WHEN istanza_rein.darindec = 'R' THEN 'Rinuncia' END AS istanza_rein_darindec, istanza_rein.datarindec AS istanza_rein_datarindec, istanza_rein.idcorsostudio AS istanza_rein_idcorsostudio, istanza_rein.iddidprog AS istanza_rein_iddidprog, istanza_rein.idiscrizione AS istanza_rein_idiscrizione,
 iscrizione_istanza_rein.anno AS iscrizione_istanza_rein_anno, iscrizione_istanza_rein.iddidprog AS iscrizione_istanza_rein_iddidprog, iscrizione_istanza_rein.aa AS iscrizione_istanza_rein_aa, istanza_rein.idiscrizione_from, istanza_rein.idistanza AS istanza_rein_idistanza, istanza_rein.idistanzakind AS istanza_rein_idistanzakind, istanza_rein.idreg AS istanza_rein_idreg,
 [dbo].istattitolistudio.titolo AS istattitolistudio_titolo, [dbo].istattitolistudio.idistattitolistudio AS istattitolistudio_idistattitolistudio, [dbo].titolostudio.voto AS titolostudio_voto, [dbo].titolostudio.votosu AS titolostudio_votosu, [dbo].titolostudio.votolode AS titolostudio_votolode, [dbo].titolostudio.aa AS titolostudio_aa, istanza_rein.idtitolostudio, istanza_rein.lt AS istanza_rein_lt, istanza_rein.lu AS istanza_rein_lu,
 isnull('Studente: ' + registry_registry_studentistudenti.title + '; ','') + ' ' + isnull('Titolo : ' + [dbo].istattitolistudio.titolo + '; ','') + ' ' + isnull('Titolo : ' + CAST( [dbo].istattitolistudio.idistattitolistudio AS NVARCHAR(64)) + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, istanza.data, 103),'') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Status: ' + [dbo].statuskind.title + '; ','') + ' ' + isnull('Sede Sede: ' + CAST( [dbo].sede.idsede AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno di corso Iscrizione: ' + CAST( iscrizione_istanza.anno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Didattica programmata Iscrizione: ' + CAST( iscrizione_istanza.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno accademico Iscrizione: ' + iscrizione_istanza.aa + '; ','') + ' ' + isnull('Iscrizione Iscrizione: ' + CAST( iscrizione_istanza.idiscrizione AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].istanza WITH (NOLOCK) 
INNER JOIN istanza_rein WITH (NOLOCK) ON istanza.idistanza = istanza_rein.idistanza AND istanza.idistanzakind = istanza_rein.idistanzakind AND istanza.idreg_studenti = istanza_rein.idreg
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON istanza.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON istanza.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON istanza.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].registry_studenti AS registry_studentistudenti WITH (NOLOCK) ON istanza.idreg_studenti = registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_studentistudenti WITH (NOLOCK) ON registry_studentistudenti.idreg = registry_registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].istanza AS istanzaparent WITH (NOLOCK) ON istanza.paridistanza = istanzaparent.idistanza
LEFT OUTER JOIN [dbo].iscrizione AS iscrizione_istanza WITH (NOLOCK) ON istanzaparent.idiscrizione = iscrizione_istanza.idiscrizione
LEFT OUTER JOIN [dbo].iscrizione AS iscrizione_istanza_rein WITH (NOLOCK) ON istanza_rein.idiscrizione_from = iscrizione_istanza_rein.idiscrizione
LEFT OUTER JOIN [dbo].titolostudio WITH (NOLOCK) ON istanza_rein.idtitolostudio = [dbo].titolostudio.idtitolostudio
LEFT OUTER JOIN [dbo].istattitolistudio WITH (NOLOCK) ON titolostudio.idistattitolistudio = [dbo].istattitolistudio.idistattitolistudio
WHERE  istanza.idcorsostudio IS NOT NULL  AND istanza.iddidprog IS NOT NULL  AND istanza.idiscrizione IS NOT NULL  AND istanza.idistanza IS NOT NULL  AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza.idstatuskind in (select idstatuskind from statuskind where istanze = 'S') AND istanza_rein.idcorsostudio IS NOT NULL  AND istanza_rein.iddidprog IS NOT NULL  AND istanza_rein.idiscrizione IS NOT NULL  AND istanza_rein.idistanza IS NOT NULL  AND istanza_rein.idistanzakind IS NOT NULL  AND istanza_rein.idreg IS NOT NULL 
GO

