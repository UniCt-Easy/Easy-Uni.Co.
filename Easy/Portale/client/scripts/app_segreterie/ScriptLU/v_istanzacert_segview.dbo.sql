
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


-- CREAZIONE VISTA istanzacert_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzacert_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzacert_segview]
GO

CREATE VIEW [dbo].[istanzacert_segview] AS 
SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data AS istanza_data, istanza.extension AS istanza_extension,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, istanza.idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].sede.idsede AS sede_idsede, istanza.iddidprog,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, istanza.idiscrizione, istanza.idistanza, istanza.idistanzakind,
 registry_registry_studentistudenti.title AS registrystudenti_title, istanza.idreg_studenti,
 [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu, istanza.paridistanza AS istanza_paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_cert.ct AS istanza_cert_ct, istanza_cert.cu AS istanza_cert_cu,
 [dbo].certkind.title AS certkind_title, [dbo].certkind.description AS certkind_description, istanza_cert.idcertkind AS istanza_cert_idcertkind, istanza_cert.idistanza AS istanza_cert_idistanza, istanza_cert.idistanzakind AS istanza_cert_idistanzakind, istanza_cert.idreg AS istanza_cert_idreg, istanza_cert.lt AS istanza_cert_lt, istanza_cert.lu AS istanza_cert_lu,
 isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Sede Sede: ' + CAST( [dbo].sede.idsede AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].istanza WITH (NOLOCK) 
INNER JOIN istanza_cert WITH (NOLOCK) ON istanza.idistanza = istanza_cert.idistanza AND istanza.idistanzakind = istanza_cert.idistanzakind AND istanza.idreg_studenti = istanza_cert.idreg
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON istanza.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON istanza.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON istanza.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].registry_studenti AS registry_studentistudenti WITH (NOLOCK) ON istanza.idreg_studenti = registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_studentistudenti WITH (NOLOCK) ON registry_studentistudenti.idreg = registry_registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].certkind WITH (NOLOCK) ON istanza_cert.idcertkind = [dbo].certkind.idcertkind
WHERE  istanza.idistanza IS NOT NULL  AND istanza.idistanzakind =9 AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza_cert.idistanza IS NOT NULL  AND istanza_cert.idistanzakind =9 AND istanza_cert.idistanzakind IS NOT NULL  AND istanza_cert.idreg IS NOT NULL 
GO

