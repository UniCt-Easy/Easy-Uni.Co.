
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


-- CREAZIONE VISTA getcontrattikindviewdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getcontrattikindviewdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getcontrattikindviewdefaultview]
GO

CREATE VIEW [dbo].[getcontrattikindviewdefaultview] AS 
SELECT  getcontrattikindview.costolordoannuo AS getcontrattikindview_costolordoannuo, getcontrattikindview.costolordoannuo_ck AS getcontrattikindview_costolordoannuo_ck, getcontrattikindview.costolordoannuo_inq AS getcontrattikindview_costolordoannuo_inq, getcontrattikindview.costolordoannuo_stip AS getcontrattikindview_costolordoannuo_stip, getcontrattikindview.costomese AS getcontrattikindview_costomese, getcontrattikindview.costoora AS getcontrattikindview_costoora,
 [dbo].contrattokind.title AS contrattokind_title, getcontrattikindview.idcontrattokind, getcontrattikindview.oremaxdidatempoparziale AS getcontrattikindview_oremaxdidatempoparziale, getcontrattikindview.oremaxdidatempopieno AS getcontrattikindview_oremaxdidatempopieno, getcontrattikindview.oremaxgg AS getcontrattikindview_oremaxgg, getcontrattikindview.oremaxtempoparziale AS getcontrattikindview_oremaxtempoparziale, getcontrattikindview.oremaxtempopieno AS getcontrattikindview_oremaxtempopieno, getcontrattikindview.oremindidatempoparziale AS getcontrattikindview_oremindidatempoparziale, getcontrattikindview.oremindidatempopieno AS getcontrattikindview_oremindidatempopieno,CASE WHEN getcontrattikindview.parttime = 'S' THEN 'Si' WHEN getcontrattikindview.parttime = 'N' THEN 'No' END AS getcontrattikindview_parttime,CASE WHEN getcontrattikindview.tempdef = 'S' THEN 'Si' WHEN getcontrattikindview.tempdef = 'N' THEN 'No' END AS getcontrattikindview_tempdef, getcontrattikindview.title,
 isnull('Tipologia: ' + getcontrattikindview.title + '; ','') as dropdown_title
FROM [dbo].getcontrattikindview WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON getcontrattikindview.idcontrattokind = [dbo].contrattokind.idcontrattokind
WHERE  getcontrattikindview.idcontrattokind IS NOT NULL 
GO

