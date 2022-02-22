
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


-- CREAZIONE VISTA istanzapas_seganagstuview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzapas_seganagstuview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzapas_seganagstuview]
GO

CREATE VIEW [dbo].[istanzapas_seganagstuview] AS 
SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data, istanza.extension AS istanza_extension, istanza.idcorsostudio, istanza.iddidprog, istanza.idiscrizione, istanza.idistanza, istanza.idistanzakind, istanza.idreg_studenti,
 [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu, istanza.paridistanza AS istanza_paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_pas.ct AS istanza_pas_ct, istanza_pas.cu AS istanza_pas_cu, istanza_pas.idcorsostudio AS istanza_pas_idcorsostudio, istanza_pas.iddidprog AS istanza_pas_iddidprog, istanza_pas.idiscrizione AS istanza_pas_idiscrizione,
 iscrizionefrom.anno AS iscrizionefrom_anno, iscrizionefrom.iddidprog AS iscrizionefrom_iddidprog, iscrizionefrom.aa AS iscrizionefrom_aa, istanza_pas.idiscrizione_from AS istanza_pas_idiscrizione_from, istanza_pas.idistanza AS istanza_pas_idistanza, istanza_pas.idistanzakind AS istanza_pas_idistanzakind, istanza_pas.idreg AS istanza_pas_idreg, istanza_pas.lt AS istanza_pas_lt, istanza_pas.lu AS istanza_pas_lu,
 isnull('del ' + CONVERT(VARCHAR, istanza.data, 103),'') + ' ' + isnull('Iscrizione di partenza: ' + CAST( iscrizionefrom.anno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Iscrizione di partenza: ' + CAST( iscrizionefrom.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Iscrizione di partenza: ' + iscrizionefrom.aa + '; ','') + ' ' + isnull('Status: ' + [dbo].statuskind.title + '; ','') + ' ' + isnull('Didattica di destinazione: ' + CAST( istanza.iddidprog AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].istanza WITH (NOLOCK) 
INNER JOIN istanza_pas WITH (NOLOCK) ON istanza.idistanza = istanza_pas.idistanza AND istanza.idistanzakind = istanza_pas.idistanzakind AND istanza.idreg_studenti = istanza_pas.idreg
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].iscrizione AS iscrizionefrom WITH (NOLOCK) ON istanza_pas.idiscrizione_from = iscrizionefrom.idiscrizione
WHERE  istanza.idcorsostudio IS NOT NULL  AND istanza.iddidprog IS NOT NULL  AND istanza.idiscrizione IS NOT NULL  AND istanza.idistanza IS NOT NULL  AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza.idstatuskind in (select idstatuskind from statuskind where istanzedelibera = 'S') AND istanza_pas.idcorsostudio IS NOT NULL  AND istanza_pas.iddidprog IS NOT NULL  AND istanza_pas.idiscrizione IS NOT NULL  AND istanza_pas.idistanza IS NOT NULL  AND istanza_pas.idistanzakind IS NOT NULL  AND istanza_pas.idreg IS NOT NULL 
GO

