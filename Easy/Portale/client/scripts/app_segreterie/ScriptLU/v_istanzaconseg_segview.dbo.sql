
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


-- CREAZIONE VISTA istanzaconseg_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzaconseg_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzaconseg_segview]
GO

CREATE VIEW [dbo].[istanzaconseg_segview] AS 
SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data AS istanza_data, istanza.extension AS istanza_extension, istanza.idcorsostudio AS istanza_idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].sede.idsede AS sede_idsede, istanza.iddidprog, istanza.idiscrizione AS istanza_idiscrizione, istanza.idistanza, istanza.idistanzakind,
 registry_registry_studentistudenti.title AS registrystudenti_title, istanza.idreg_studenti,
 [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu, istanza.paridistanza AS istanza_paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_conseg.ct AS istanza_conseg_ct, istanza_conseg.cu AS istanza_conseg_cu, istanza_conseg.datacompalmalaur AS istanza_conseg_datacompalmalaur, istanza_conseg.fascicolo AS istanza_conseg_fascicolo,
 [dbo].appello.description AS appello_description, [dbo].appello.aa AS appello_aa, istanza_conseg.idappello, istanza_conseg.idistanza AS istanza_conseg_idistanza, istanza_conseg.idistanzakind AS istanza_conseg_idistanzakind, istanza_conseg.idreg AS istanza_conseg_idreg, istanza_conseg.idrichitesi AS istanza_conseg_idrichitesi, istanza_conseg.lt AS istanza_conseg_lt, istanza_conseg.lu AS istanza_conseg_lu, istanza_conseg.posizione AS istanza_conseg_posizione,
 isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Sede Sede: ' + CAST( [dbo].sede.idsede AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].istanza WITH (NOLOCK) 
INNER JOIN istanza_conseg WITH (NOLOCK) ON istanza.idistanza = istanza_conseg.idistanza AND istanza.idistanzakind = istanza_conseg.idistanzakind AND istanza.idreg_studenti = istanza_conseg.idreg
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON istanza.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].registry_studenti AS registry_studentistudenti WITH (NOLOCK) ON istanza.idreg_studenti = registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_studentistudenti WITH (NOLOCK) ON registry_studentistudenti.idreg = registry_registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].appello WITH (NOLOCK) ON istanza_conseg.idappello = [dbo].appello.idappello
WHERE  istanza.idistanza IS NOT NULL  AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza_conseg.idistanza IS NOT NULL  AND istanza_conseg.idistanzakind IS NOT NULL  AND istanza_conseg.idreg IS NOT NULL 
GO

