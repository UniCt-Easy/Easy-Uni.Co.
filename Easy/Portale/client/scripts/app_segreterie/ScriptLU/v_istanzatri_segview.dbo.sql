
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


-- CREAZIONE VISTA istanzatri_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzatri_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzatri_segview]
GO

CREATE VIEW [dbo].[istanzatri_segview] AS 
SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data AS istanza_data, istanza.extension AS istanza_extension,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, istanza.idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].sede.idsede AS sede_idsede, istanza.iddidprog,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, istanza.idiscrizione, istanza.idistanza, istanza.idistanzakind, istanza.idreg_studenti,
 [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu,
 istanzaparent.idistanzakind AS istanzaparent_idistanzakind, istanzaparent.idreg_studenti AS istanzaparent_idreg_studenti, istanzaparent.aa AS istanzaparent_aa, istanzaparent.data AS istanzaparent_data, didprog_istanza.title AS didprog_istanza_title, didprog_istanza.aa AS didprog_istanza_aa, didprog_istanza.idsede AS didprog_istanza_idsede, didprog_istanza.iddidprog AS didprog_istanza_iddidprog, statuskind_istanza.title AS statuskind_istanza_title, statuskind_istanza.idstatuskind AS statuskind_istanza_idstatuskind, iscrizione_istanza.anno AS iscrizione_istanza_anno, iscrizione_istanza.iddidprog AS iscrizione_istanza_iddidprog, iscrizione_istanza.aa AS iscrizione_istanza_aa, iscrizione_istanza.idiscrizione AS iscrizione_istanza_idiscrizione, istanza.paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_tri.aaprimaiscr, istanza_tri.ct AS istanza_tri_ct, istanza_tri.cu AS istanza_tri_cu,
 dichiar_dichiar_titolotitolo.idreg AS dichiartitolo_idreg, istanza_tri.iddichiar_titolo, istanza_tri.iddidprog AS istanza_tri_iddidprog, istanza_tri.idiscrizione AS istanza_tri_idiscrizione, istanza_tri.idistanza AS istanza_tri_idistanza, istanza_tri.idistanzakind AS istanza_tri_idistanzakind, istanza_tri.idreg AS istanza_tri_idreg,
 registry_registry_istitutiistituti.title AS registryistituti_title, istanza_tri.idreg_istituti, istanza_tri.lt AS istanza_tri_lt, istanza_tri.lu AS istanza_tri_lu,
 isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Denominazione Didattica programmata: ' + didprog_istanza.title + '; ','') + ' ' + isnull('Stato Status: ' + statuskind_istanza.title + '; ','') + ' ' + isnull('Anno accademico Didattica programmata: ' + didprog_istanza.aa + '; ','') + ' ' + isnull('Sede Sede: ' + CAST( [dbo].sede.idsede AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Sede Didattica programmata: ' + CAST( didprog_istanza.idsede AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Didattica programmata Didattica programmata: ' + CAST( didprog_istanza.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Status Status: ' + CAST( statuskind_istanza.idstatuskind AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno di corso Iscrizione: ' + CAST( iscrizione_istanza.anno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Didattica programmata Iscrizione: ' + CAST( iscrizione_istanza.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno accademico Iscrizione: ' + iscrizione_istanza.aa + '; ','') + ' ' + isnull('Iscrizione Iscrizione: ' + CAST( iscrizione_istanza.idiscrizione AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].istanza WITH (NOLOCK) 
INNER JOIN istanza_tri WITH (NOLOCK) ON istanza.idistanza = istanza_tri.idistanza AND istanza.idistanzakind = istanza_tri.idistanzakind AND istanza.idreg_studenti = istanza_tri.idreg
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON istanza.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON istanza.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON istanza.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].istanza AS istanzaparent WITH (NOLOCK) ON istanza.paridistanza = istanzaparent.idistanza
LEFT OUTER JOIN [dbo].didprog AS didprog_istanza WITH (NOLOCK) ON istanzaparent.iddidprog = didprog_istanza.iddidprog
LEFT OUTER JOIN [dbo].statuskind AS statuskind_istanza WITH (NOLOCK) ON istanzaparent.idstatuskind = statuskind_istanza.idstatuskind
LEFT OUTER JOIN [dbo].iscrizione AS iscrizione_istanza WITH (NOLOCK) ON istanzaparent.idiscrizione = iscrizione_istanza.idiscrizione
LEFT OUTER JOIN [dbo].dichiar_titolo AS dichiar_titolotitolo WITH (NOLOCK) ON istanza_tri.iddichiar_titolo = dichiar_titolotitolo.iddichiar
LEFT OUTER JOIN [dbo].dichiar AS dichiar_dichiar_titolotitolo WITH (NOLOCK) ON dichiar_titolotitolo.iddichiar = dichiar_dichiar_titolotitolo.iddichiar
LEFT OUTER JOIN [dbo].registry_istituti AS registry_istitutiistituti WITH (NOLOCK) ON istanza_tri.idreg_istituti = registry_istitutiistituti.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_istitutiistituti WITH (NOLOCK) ON registry_istitutiistituti.idreg = registry_registry_istitutiistituti.idreg
WHERE  istanza.idistanza IS NOT NULL  AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza_tri.iddidprog IS NOT NULL  AND istanza_tri.idiscrizione IS NOT NULL  AND istanza_tri.idistanza IS NOT NULL  AND istanza_tri.idistanzakind IS NOT NULL  AND istanza_tri.idreg IS NOT NULL 
GO

