
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


-- CREAZIONE VISTA appellokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appellokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[appellokinddefaultview]
GO

CREATE VIEW [dbo].[appellokinddefaultview] AS 
SELECT CASE WHEN appellokind.active = 'S' THEN 'Si' WHEN appellokind.active = 'N' THEN 'No' END AS appellokind_active, appellokind.description AS appellokind_description, appellokind.idappellokind, appellokind.lt AS appellokind_lt, appellokind.lu AS appellokind_lu, appellokind.sortcode AS appellokind_sortcode, appellokind.title,
 isnull('Titolo: ' + appellokind.title + '; ','') as dropdown_title
FROM [dbo].appellokind WITH (NOLOCK) 
WHERE  appellokind.idappellokind IS NOT NULL 
GO


-- GENERAZIONE DATI PER appellokinddefaultview --
