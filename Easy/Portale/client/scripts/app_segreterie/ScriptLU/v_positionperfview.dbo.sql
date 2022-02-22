
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


-- CREAZIONE VISTA positionperfview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[positionperfview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[positionperfview]
GO

CREATE VIEW [dbo].[positionperfview] AS 
SELECT CASE WHEN position.active = 'S' THEN 'Si' WHEN position.active = 'N' THEN 'No' END AS position_active, position.codeposition AS position_codeposition, position.ct AS position_ct, position.cu AS position_cu, position.description,CASE WHEN position.foreignclass = 'S' THEN 'Si' WHEN position.foreignclass = 'N' THEN 'No' END AS position_foreignclass, position.idposition, position.lt AS position_lt, position.lu AS position_lu, position.maxincomeclass AS position_maxincomeclass, position_perf.ct AS position_perf_ct, position_perf.cu AS position_perf_cu, position_perf.idposition AS position_perf_idposition, position_perf.lt AS position_perf_lt, position_perf.lu AS position_perf_lu, position_perf.pesoateneo AS position_perf_pesoateneo, position_perf.pesoindividuale AS position_perf_pesoindividuale, position_perf.pesouo AS position_perf_pesouo,
 isnull('Descrizione: ' + position.description + '; ','') + ' ' + isnull('Codice: ' + position.codeposition + '; ','') as dropdown_title
FROM [dbo].position WITH (NOLOCK) 
INNER JOIN position_perf WITH (NOLOCK) ON position.idposition = position_perf.idposition
WHERE  position.idposition IS NOT NULL  AND position_perf.idposition IS NOT NULL 
GO

