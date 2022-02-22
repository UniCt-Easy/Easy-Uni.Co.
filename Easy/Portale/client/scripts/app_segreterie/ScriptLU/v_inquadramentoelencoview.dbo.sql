
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


-- CREAZIONE VISTA inquadramentoelencoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inquadramentoelencoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[inquadramentoelencoview]
GO

CREATE VIEW [dbo].[inquadramentoelencoview] AS 
SELECT  inquadramento.costolordoannuo AS inquadramento_costolordoannuo, inquadramento.costolordoannuooneri AS inquadramento_costolordoannuooneri, inquadramento.ct AS inquadramento_ct, inquadramento.cu AS inquadramento_cu,
 [dbo].contrattokind.title AS contrattokind_title, inquadramento.idcontrattokind, inquadramento.idinquadramento, inquadramento.lt AS inquadramento_lt, inquadramento.lu AS inquadramento_lu, inquadramento.siglaimportazione AS inquadramento_siglaimportazione, inquadramento.start AS inquadramento_start, inquadramento.stop AS inquadramento_stop,CASE WHEN inquadramento.tempdef = 'S' THEN 'Si' WHEN inquadramento.tempdef = 'N' THEN 'No' END AS inquadramento_tempdef, inquadramento.title AS inquadramento_title,
 isnull('Tipologia contrattuale: ' + [dbo].contrattokind.title + '; ','') + ' ' + isnull('Inquadramento: ' + inquadramento.title + '; ','') as dropdown_title
FROM [dbo].inquadramento WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON inquadramento.idcontrattokind = [dbo].contrattokind.idcontrattokind
WHERE  inquadramento.idcontrattokind IS NOT NULL  AND inquadramento.idinquadramento IS NOT NULL 
GO


-- GENERAZIONE DATI PER inquadramentoelencoview --
