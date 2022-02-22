
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


-- CREAZIONE VISTA istanzaeq_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzaeq_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzaeq_segview]
GO

CREATE VIEW [dbo].[istanzaeq_segview] AS 
SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data AS istanza_data, istanza.extension AS istanza_extension, istanza.idcorsostudio AS istanza_idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].sede.idsede AS sede_idsede, istanza.iddidprog, istanza.idiscrizione AS istanza_idiscrizione, istanza.idistanza, istanza.idistanzakind,
 registry_registry_studentistudenti.title AS registrystudenti_title, istanza.idreg_studenti,
 [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu, istanza.paridistanza AS istanza_paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_eq.ct AS istanza_eq_ct, istanza_eq.cu AS istanza_eq_cu,
 dichiar_dichiar_titolotitolo_seg.idreg AS dichiartitolo_seg_idreg, istanza_eq.iddichiar_titolo_seg AS istanza_eq_iddichiar_titolo_seg, istanza_eq.idistanza AS istanza_eq_idistanza, istanza_eq.idistanzakind AS istanza_eq_idistanzakind, istanza_eq.idreg AS istanza_eq_idreg, istanza_eq.lt AS istanza_eq_lt, istanza_eq.lu AS istanza_eq_lu,
 isnull('Studente: ' + registry_registry_studentistudenti.title + '; ','') + ' ' + isnull('Anno accademico: ' + istanza.aa + '; ','') + ' ' + isnull('Corso equipollente: ' + [dbo].didprog.title + '; ','') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Corso equipollente: ' + [dbo].didprog.aa + '; ','') + ' ' + isnull('Sede Sede: ' + CAST( [dbo].sede.idsede AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].istanza WITH (NOLOCK) 
INNER JOIN istanza_eq WITH (NOLOCK) ON istanza.idistanza = istanza_eq.idistanza AND istanza.idistanzakind = istanza_eq.idistanzakind AND istanza.idreg_studenti = istanza_eq.idreg
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON istanza.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].registry_studenti AS registry_studentistudenti WITH (NOLOCK) ON istanza.idreg_studenti = registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_studentistudenti WITH (NOLOCK) ON registry_studentistudenti.idreg = registry_registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].dichiar_titolo AS dichiar_titolotitolo_seg WITH (NOLOCK) ON istanza_eq.iddichiar_titolo_seg = dichiar_titolotitolo_seg.iddichiar
LEFT OUTER JOIN [dbo].dichiar AS dichiar_dichiar_titolotitolo_seg WITH (NOLOCK) ON dichiar_titolotitolo_seg.iddichiar = dichiar_dichiar_titolotitolo_seg.iddichiar
WHERE  istanza.idistanza IS NOT NULL  AND istanza.idistanzakind = 1 AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza.idstatuskind in (select idstatuskind from statuskind where istanze = 'S') AND istanza_eq.idistanza IS NOT NULL  AND istanza_eq.idistanzakind =1 AND istanza_eq.idistanzakind IS NOT NULL  AND istanza_eq.idreg IS NOT NULL 
GO

