
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


-- CREAZIONE VISTA istanzatru_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzatru_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzatru_segview]
GO

CREATE VIEW [dbo].[istanzatru_segview] AS 
SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data AS istanza_data, istanza.extension AS istanza_extension, istanza.idcorsostudio AS istanza_idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].sede.idsede AS sede_idsede, istanza.iddidprog,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, istanza.idiscrizione, istanza.idistanza, istanza.idistanzakind,
 registry_registry_studentistudenti.title AS registrystudenti_title, istanza.idreg_studenti,
 [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu, istanza.paridistanza AS istanza_paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_tru.ct AS istanza_tru_ct, istanza_tru.cu AS istanza_tru_cu, istanza_tru.idistanza AS istanza_tru_idistanza, istanza_tru.idistanzakind AS istanza_tru_idistanzakind, istanza_tru.idreg AS istanza_tru_idreg,
 registry_registry_istitutiistituti.title AS registryistituti_title, istanza_tru.idreg_istituti AS istanza_tru_idreg_istituti, istanza_tru.lt AS istanza_tru_lt, istanza_tru.lu AS istanza_tru_lu,
 isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Sede Sede: ' + CAST( [dbo].sede.idsede AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].istanza WITH (NOLOCK) 
INNER JOIN istanza_tru WITH (NOLOCK) ON istanza.idistanza = istanza_tru.idistanza AND istanza.idistanzakind = istanza_tru.idistanzakind AND istanza.idreg_studenti = istanza_tru.idreg
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON istanza.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON istanza.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].registry_studenti AS registry_studentistudenti WITH (NOLOCK) ON istanza.idreg_studenti = registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_studentistudenti WITH (NOLOCK) ON registry_studentistudenti.idreg = registry_registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].registry_istituti AS registry_istitutiistituti WITH (NOLOCK) ON istanza_tru.idreg_istituti = registry_istitutiistituti.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_istitutiistituti WITH (NOLOCK) ON registry_istitutiistituti.idreg = registry_registry_istitutiistituti.idreg
WHERE  istanza.idistanza IS NOT NULL  AND istanza.idistanzakind = 8 AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza.idstatuskind in (select idstatuskind from statuskind where istanze = 'S') AND istanza_tru.idistanza IS NOT NULL  AND istanza_tru.idistanzakind IS NOT NULL  AND istanza_tru.idreg IS NOT NULL 
GO

