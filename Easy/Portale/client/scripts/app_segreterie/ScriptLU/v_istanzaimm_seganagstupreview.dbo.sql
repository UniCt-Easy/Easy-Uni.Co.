
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


-- CREAZIONE VISTA istanzaimm_seganagstupreview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzaimm_seganagstupreview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzaimm_seganagstupreview]
GO

CREATE VIEW [dbo].[istanzaimm_seganagstupreview] AS 
SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data, istanza.extension AS istanza_extension, istanza.idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].sede.idsede AS sede_idsede, istanza.iddidprog, istanza.idiscrizione AS istanza_idiscrizione, istanza.idistanza, istanza.idistanzakind, istanza.idreg_studenti,
 [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu, istanza.paridistanza AS istanza_paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_imm.ct AS istanza_imm_ct, istanza_imm.cu AS istanza_imm_cu, istanza_imm.idcorsostudio AS istanza_imm_idcorsostudio, istanza_imm.iddidprog AS istanza_imm_iddidprog,
 [dbo].didprogcurr.title AS didprogcurr_title, istanza_imm.iddidprogcurr AS istanza_imm_iddidprogcurr,
 [dbo].didprogori.title AS didprogori_title, istanza_imm.iddidprogori AS istanza_imm_iddidprogori, istanza_imm.idistanza AS istanza_imm_idistanza, istanza_imm.idistanzakind AS istanza_imm_idistanzakind, istanza_imm.idreg AS istanza_imm_idreg, istanza_imm.lt AS istanza_imm_lt, istanza_imm.lu AS istanza_imm_lu, istanza_imm.motivrit AS istanza_imm_motivrit,CASE WHEN istanza_imm.parttime = 'S' THEN 'Si' WHEN istanza_imm.parttime = 'N' THEN 'No' END AS istanza_imm_parttime,CASE WHEN istanza_imm.pre = 'S' THEN 'Si' WHEN istanza_imm.pre = 'N' THEN 'No' END AS istanza_imm_pre,
 isnull('del ' + CONVERT(VARCHAR, istanza.data, 103),'') + ' ' + isnull('Status: ' + [dbo].statuskind.title + '; ','') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Sede Sede: ' + CAST( [dbo].sede.idsede AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].istanza WITH (NOLOCK) 
INNER JOIN istanza_imm WITH (NOLOCK) ON istanza.idistanza = istanza_imm.idistanza AND istanza.idistanzakind = istanza_imm.idistanzakind AND istanza.idreg_studenti = istanza_imm.idreg
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON istanza.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON istanza_imm.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON istanza_imm.iddidprogori = [dbo].didprogori.iddidprogori
WHERE  istanza.idcorsostudio IS NOT NULL  AND istanza.iddidprog IS NOT NULL  AND istanza.idistanza IS NOT NULL  AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza.idstatuskind in (select idstatuskind from statuskind where istanze = 'S') AND istanza_imm.idcorsostudio IS NOT NULL  AND istanza_imm.iddidprog IS NOT NULL  AND istanza_imm.idistanza IS NOT NULL  AND istanza_imm.idistanzakind IS NOT NULL  AND istanza_imm.idreg IS NOT NULL 
GO

