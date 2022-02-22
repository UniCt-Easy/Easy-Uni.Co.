
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


-- CREAZIONE VISTA stipendiokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[stipendiokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[stipendiokinddefaultview]
GO



CREATE VIEW [dbo].[stipendiokinddefaultview] AS SELECT  stipendiokind.assegnoaggiuntivo AS stipendiokind_assegnoaggiuntivo, stipendiokind.ct AS stipendiokind_ct, stipendiokind.cu AS stipendiokind_cu, stipendiokind.elementoperequativo AS stipendiokind_elementoperequativo, [dbo].contrattokind.title AS contrattokind_title, stipendiokind.idcontrattokind, [dbo].inquadramento.idcontrattokind AS inquadramento_idcontrattokind, [dbo].inquadramento.title AS inquadramento_title, stipendiokind.idinquadramento, stipendiokind.idstipendiokind, stipendiokind.indennitadiateneo AS stipendiokind_indennitadiateneo, stipendiokind.indennitadiposizione AS stipendiokind_indennitadiposizione, stipendiokind.indintegrativaspeciale AS stipendiokind_indintegrativaspeciale, stipendiokind.indvacancacontrattuale AS stipendiokind_indvacancacontrattuale, stipendiokind.irap AS stipendiokind_irap, stipendiokind.lt AS stipendiokind_lt, stipendiokind.lu AS stipendiokind_lu, stipendiokind.oneriprevidenzialicaricoente AS stipendiokind_oneriprevidenzialicaricoente, stipendiokind.retribuzione AS stipendiokind_retribuzione, stipendiokind.scatto AS stipendiokind_scatto,CASE WHEN stipendiokind.tempdef = 'S' THEN 'Si' WHEN stipendiokind.tempdef = 'N' THEN 'No' END AS stipendiokind_tempdef, stipendiokind.totaletredicesima AS stipendiokind_totaletredicesima, stipendiokind.tredicesimaindennitaintegrativaspeciale AS stipendiokind_tredicesimaindennitaintegrativaspeciale, isnull('Ruolo: ' + [dbo].contrattokind.title + '; ','') + ' ' + isnull('Inquadramento: ' + CAST( [dbo].inquadramento.idcontrattokind AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Inquadramento: ' + [dbo].inquadramento.title + '; ','') + ' ' + isnull('Scatto: ' + stipendiokind.scatto + '; ','') as dropdown_title FROM [dbo].stipendiokind WITH (NOLOCK)  LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON stipendiokind.idcontrattokind = [dbo].contrattokind.idcontrattokind LEFT OUTER JOIN [dbo].inquadramento WITH (NOLOCK) ON stipendiokind.idinquadramento = [dbo].inquadramento.idinquadramento WHERE  stipendiokind.idstipendiokind IS NOT NULL 

GO

