
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


-- CREAZIONE VISTA studprenotkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[studprenotkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[studprenotkinddefaultview]
GO

CREATE VIEW [dbo].[studprenotkinddefaultview] AS 
SELECT CASE WHEN studprenotkind.active = 'S' THEN 'Si' WHEN studprenotkind.active = 'N' THEN 'No' END AS studprenotkind_active, studprenotkind.description AS studprenotkind_description, studprenotkind.idstudprenotkind, studprenotkind.lt AS studprenotkind_lt, studprenotkind.lu AS studprenotkind_lu, studprenotkind.sortorder AS studprenotkind_sortorder, studprenotkind.title,
 isnull('Titolo: ' + studprenotkind.title + '; ','') as dropdown_title
FROM [dbo].studprenotkind WITH (NOLOCK) 
WHERE  studprenotkind.idstudprenotkind IS NOT NULL 
GO


-- GENERAZIONE DATI PER studprenotkinddefaultview --
