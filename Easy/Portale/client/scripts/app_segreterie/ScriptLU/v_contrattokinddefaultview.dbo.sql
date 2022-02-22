
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


-- CREAZIONE VISTA contrattokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contrattokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[contrattokinddefaultview]
GO

CREATE VIEW [dbo].[contrattokinddefaultview] AS 
SELECT CASE WHEN contrattokind.active = 'S' THEN 'Si' WHEN contrattokind.active = 'N' THEN 'No' END AS contrattokind_active,CASE WHEN contrattokind.assegnoaggiuntivo = 'S' THEN 'Si' WHEN contrattokind.assegnoaggiuntivo = 'N' THEN 'No' END AS contrattokind_assegnoaggiuntivo, contrattokind.costolordoannuo AS contrattokind_costolordoannuo, contrattokind.costolordoannuooneri AS contrattokind_costolordoannuooneri, contrattokind.ct AS contrattokind_ct, contrattokind.cu AS contrattokind_cu, contrattokind.description AS contrattokind_description,CASE WHEN contrattokind.elementoperequativo = 'S' THEN 'Si' WHEN contrattokind.elementoperequativo = 'N' THEN 'No' END AS contrattokind_elementoperequativo, contrattokind.idcontrattokind,CASE WHEN contrattokind.indennitadiateneo = 'S' THEN 'Si' WHEN contrattokind.indennitadiateneo = 'N' THEN 'No' END AS contrattokind_indennitadiateneo,CASE WHEN contrattokind.indennitadiposizione = 'S' THEN 'Si' WHEN contrattokind.indennitadiposizione = 'N' THEN 'No' END AS contrattokind_indennitadiposizione,CASE WHEN contrattokind.indvacancacontrattuale = 'S' THEN 'Si' WHEN contrattokind.indvacancacontrattuale = 'N' THEN 'No' END AS contrattokind_indvacancacontrattuale, contrattokind.lt AS contrattokind_lt, contrattokind.lu AS contrattokind_lu, contrattokind.oremaxcompitididatempoparziale AS contrattokind_oremaxcompitididatempoparziale, contrattokind.oremaxcompitididatempopieno AS contrattokind_oremaxcompitididatempopieno, contrattokind.oremaxdidatempoparziale AS contrattokind_oremaxdidatempoparziale, contrattokind.oremaxdidatempopieno AS contrattokind_oremaxdidatempopieno, contrattokind.oremaxgg AS contrattokind_oremaxgg, contrattokind.oremaxtempoparziale AS contrattokind_oremaxtempoparziale, contrattokind.oremaxtempopieno AS contrattokind_oremaxtempopieno, contrattokind.oremincompitididatempoparziale AS contrattokind_oremincompitididatempoparziale, contrattokind.oremincompitididatempopieno AS contrattokind_oremincompitididatempopieno, contrattokind.oremindidatempoparziale AS contrattokind_oremindidatempoparziale, contrattokind.oremindidatempopieno AS contrattokind_oremindidatempopieno, contrattokind.oremintempoparziale AS contrattokind_oremintempoparziale, contrattokind.oremintempopieno AS contrattokind_oremintempopieno, contrattokind.orestraordinariemax AS contrattokind_orestraordinariemax,CASE WHEN contrattokind.parttime = 'S' THEN 'Si' WHEN contrattokind.parttime = 'N' THEN 'No' END AS contrattokind_parttime, contrattokind.puntiorganico AS contrattokind_puntiorganico,CASE WHEN contrattokind.scatto = 'S' THEN 'Si' WHEN contrattokind.scatto = 'N' THEN 'No' END AS contrattokind_scatto, contrattokind.siglaesportazione AS contrattokind_siglaesportazione, contrattokind.siglaimportazione AS contrattokind_siglaimportazione, contrattokind.sortcode AS contrattokind_sortcode,CASE WHEN contrattokind.tempdef = 'S' THEN 'Si' WHEN contrattokind.tempdef = 'N' THEN 'No' END AS contrattokind_tempdef, contrattokind.title,CASE WHEN contrattokind.totaletredicesima = 'S' THEN 'Si' WHEN contrattokind.totaletredicesima = 'N' THEN 'No' END AS contrattokind_totaletredicesima,CASE WHEN contrattokind.tredicesimaindennitaintegrativaspeciale = 'S' THEN 'Si' WHEN contrattokind.tredicesimaindennitaintegrativaspeciale = 'N' THEN 'No' END AS contrattokind_tredicesimaindennitaintegrativaspeciale,
 isnull('Tipologia: ' + contrattokind.title + '; ','') as dropdown_title
FROM [dbo].contrattokind WITH (NOLOCK) 
WHERE  contrattokind.idcontrattokind IS NOT NULL 
GO


-- GENERAZIONE DATI PER contrattokinddefaultview --
