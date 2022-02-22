
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


-- CREAZIONE VISTA istanzarimb_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzarimb_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzarimb_segview]
GO

CREATE VIEW [dbo].[istanzarimb_segview] AS 
SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data AS istanza_data, istanza.extension AS istanza_extension,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, istanza.idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].didprog.idsede AS didprog_idsede, istanza.iddidprog,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, istanza.idiscrizione, istanza.idistanza, istanza.idistanzakind,
 registrystudenti.title AS registrystudenti_title, istanza.idreg_studenti,
 [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu,
 istanzaparent.idistanzakind AS istanzaparent_idistanzakind, istanzaparent.idreg_studenti AS istanzaparent_idreg_studenti, istanzaparent.aa AS istanzaparent_aa, istanzaparent.data AS istanzaparent_data, didprog_istanza.title AS didprog_istanza_title, didprog_istanza.aa AS didprog_istanza_aa, didprog_istanza.idsede AS didprog_istanza_idsede, istanzaparent.iddidprog AS istanzaparent_iddidprog, statuskind_istanza.title AS statuskind_istanza_title, istanzaparent.idstatuskind AS istanzaparent_idstatuskind, iscrizione_istanza.anno AS iscrizione_istanza_anno, iscrizione_istanza.iddidprog AS iscrizione_istanza_iddidprog, iscrizione_istanza.aa AS iscrizione_istanza_aa, istanzaparent.idiscrizione AS istanzaparent_idiscrizione, istanza.paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_rimb.ct AS istanza_rimb_ct, istanza_rimb.cu AS istanza_rimb_cu, istanza_rimb.idistanza AS istanza_rimb_idistanza, istanza_rimb.idistanzakind AS istanza_rimb_idistanzakind, istanza_rimb.idreg AS istanza_rimb_idreg, istanza_rimb.lt AS istanza_rimb_lt, istanza_rimb.lu AS istanza_rimb_lu
FROM [dbo].istanza WITH (NOLOCK) 
INNER JOIN istanza_rimb WITH (NOLOCK) ON istanza.idistanza = istanza_rimb.idistanza AND istanza.idistanzakind = istanza_rimb.idistanzakind AND istanza.idreg_studenti = istanza_rimb.idreg
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON istanza.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON istanza.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON [dbo].didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON istanza.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].registry_studenti AS registry_studentistudenti WITH (NOLOCK) ON istanza.idreg_studenti = registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].registry AS registrystudenti WITH (NOLOCK) ON registry_studentistudenti.idreg = registrystudenti.idreg
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].istanza AS istanzaparent WITH (NOLOCK) ON istanza.paridistanza = istanzaparent.idistanza
LEFT OUTER JOIN [dbo].didprog AS didprog_istanza WITH (NOLOCK) ON istanzaparent.iddidprog = didprog_istanza.iddidprog
LEFT OUTER JOIN [dbo].statuskind AS statuskind_istanza WITH (NOLOCK) ON istanzaparent.idstatuskind = statuskind_istanza.idstatuskind
LEFT OUTER JOIN [dbo].iscrizione AS iscrizione_istanza WITH (NOLOCK) ON istanzaparent.idiscrizione = iscrizione_istanza.idiscrizione
WHERE  istanza.idistanza IS NOT NULL  AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza_rimb.idistanza IS NOT NULL  AND istanza_rimb.idistanzakind IS NOT NULL  AND istanza_rimb.idreg IS NOT NULL 
GO

