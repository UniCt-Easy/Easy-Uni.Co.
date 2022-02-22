
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


-- CREAZIONE VISTA titolokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[titolokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[titolokinddefaultview]
GO

CREATE VIEW [dbo].[titolokinddefaultview] AS 
SELECT CASE WHEN titolokind.active = 'S' THEN 'Si' WHEN titolokind.active = 'N' THEN 'No' END AS titolokind_active, titolokind.idtitolokind, titolokind.lt AS titolokind_lt, titolokind.lu AS titolokind_lu, titolokind.sortcode AS titolokind_sortcode, titolokind.title,
 isnull('Tipologia: ' + titolokind.title + '; ','') as dropdown_title
FROM [dbo].titolokind WITH (NOLOCK) 
WHERE  titolokind.idtitolokind IS NOT NULL 
GO


-- GENERAZIONE DATI PER titolokinddefaultview --
