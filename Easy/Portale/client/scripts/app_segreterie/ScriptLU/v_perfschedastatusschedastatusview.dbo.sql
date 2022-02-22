
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


-- CREAZIONE VISTA perfschedastatusschedastatusview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfschedastatusschedastatusview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfschedastatusschedastatusview]
GO

CREATE VIEW [dbo].[perfschedastatusschedastatusview] AS 
SELECT CASE WHEN perfschedastatus.active = 'S' THEN 'Si' WHEN perfschedastatus.active = 'N' THEN 'No' END AS perfschedastatus_active, perfschedastatus.ct AS perfschedastatus_ct, perfschedastatus.cu AS perfschedastatus_cu, perfschedastatus.description AS perfschedastatus_description, perfschedastatus.idperfschedastatus, perfschedastatus.lt AS perfschedastatus_lt, perfschedastatus.lu AS perfschedastatus_lu, perfschedastatus.title,
 isnull('Stato: ' + perfschedastatus.title + '; ','') as dropdown_title
FROM [dbo].perfschedastatus WITH (NOLOCK) 
WHERE  perfschedastatus.idperfschedastatus IS NOT NULL 
GO

