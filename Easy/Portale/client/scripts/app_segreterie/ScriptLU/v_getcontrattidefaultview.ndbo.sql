
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


-- CREAZIONE VISTA getcontrattidefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[getcontrattidefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getcontrattidefaultview]
GO

CREATE VIEW [getcontrattidefaultview] AS 
SELECT  getcontratti.costolordoannuo AS getcontratti_costolordoannuo, getcontratti.costomese AS getcontratti_costomese, getcontratti.costoora AS getcontratti_costoora,
 [dbo].contrattokind.title AS contrattokind_title, [dbo].contratto.idcontrattokind AS contratto_idcontrattokind, [dbo].inquadramento.idcontrattokind AS inquadramento_idcontrattokind, [dbo].inquadramento.title AS inquadramento_title, [dbo].inquadramento.tempdef AS inquadramento_tempdef, [dbo].contratto.idinquadramento AS contratto_idinquadramento, [dbo].contratto.start AS contratto_start, [dbo].contratto.stop AS contratto_stop, getcontratti.idcontratto,
 contrattokind_getcontratti.title AS contrattokind_getcontratti_title, getcontratti.idcontrattokind AS getcontratti_idcontrattokind,
 inquadramento_getcontratti.idcontrattokind AS inquadramento_getcontratti_idcontrattokind, inquadramento_getcontratti.title AS inquadramento_getcontratti_title, inquadramento_getcontratti.tempdef AS inquadramento_getcontratti_tempdef, getcontratti.idinquadramento,
 [dbo].registry.title AS registry_title, getcontratti.idreg, getcontratti.oremax AS getcontratti_oremax, getcontratti.oremaxdida AS getcontratti_oremaxdida, getcontratti.oremaxgg AS getcontratti_oremaxgg, getcontratti.oremindida AS getcontratti_oremindida, getcontratti.parttime AS getcontratti_parttime, getcontratti.scatto AS getcontratti_scatto, getcontratti.start AS getcontratti_start, getcontratti.stop AS getcontratti_stop,CASE WHEN getcontratti.tempdef = 'S' THEN 'Si' WHEN getcontratti.tempdef = 'N' THEN 'No' END AS getcontratti_tempdef, getcontratti.title, getcontratti.totale_inquadramento AS getcontratti_totale_inquadramento, getcontratti.totale_stipendioannuo AS getcontratti_totale_stipendioannuo, getcontratti.totale_tabellastipendiale AS getcontratti_totale_tabellastipendiale, getcontratti.totale_tipologiacontrattuale AS getcontratti_totale_tipologiacontrattuale,
 isnull('Ruolo/Figura contrattuale: ' + getcontratti.title + '; ','') as dropdown_title
FROM getcontratti WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].contratto WITH (NOLOCK) ON getcontratti.idcontratto = [dbo].contratto.idcontratto
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON [dbo].contratto.idcontrattokind = [dbo].contrattokind.idcontrattokind
LEFT OUTER JOIN [dbo].inquadramento WITH (NOLOCK) ON [dbo].contratto.idinquadramento = [dbo].inquadramento.idinquadramento
LEFT OUTER JOIN [dbo].contrattokind AS contrattokind_getcontratti WITH (NOLOCK) ON getcontratti.idcontrattokind = contrattokind_getcontratti.idcontrattokind
LEFT OUTER JOIN [dbo].inquadramento AS inquadramento_getcontratti WITH (NOLOCK) ON getcontratti.idinquadramento = inquadramento_getcontratti.idinquadramento
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON getcontratti.idreg = [dbo].registry.idreg
WHERE  getcontratti.idcontratto IS NOT NULL 
GO

