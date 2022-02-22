
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


-- CREAZIONE VISTA relatorekinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[relatorekinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[relatorekinddefaultview]
GO

CREATE VIEW [dbo].[relatorekinddefaultview] AS 
SELECT CASE WHEN relatorekind.active = 'S' THEN 'Si' WHEN relatorekind.active = 'N' THEN 'No' END AS relatorekind_active, relatorekind.description AS relatorekind_description, relatorekind.idrelatorekind, relatorekind.lt AS relatorekind_lt, relatorekind.lu AS relatorekind_lu, relatorekind.sortcode AS relatorekind_sortcode, relatorekind.title,
 isnull('Tipologia: ' + relatorekind.title + '; ','') as dropdown_title
FROM [dbo].relatorekind WITH (NOLOCK) 
WHERE  relatorekind.idrelatorekind IS NOT NULL 
GO

