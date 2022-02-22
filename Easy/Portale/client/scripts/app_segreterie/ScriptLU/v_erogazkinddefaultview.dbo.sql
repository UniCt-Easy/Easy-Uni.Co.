
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


-- CREAZIONE VISTA erogazkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[erogazkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[erogazkinddefaultview]
GO

CREATE VIEW [dbo].[erogazkinddefaultview] AS 
SELECT CASE WHEN erogazkind.active = 'S' THEN 'Si' WHEN erogazkind.active = 'N' THEN 'No' END AS erogazkind_active, erogazkind.ans AS erogazkind_ans, erogazkind.description AS erogazkind_description, erogazkind.iderogazkind, erogazkind.lt AS erogazkind_lt, erogazkind.lu AS erogazkind_lu, erogazkind.sortcode AS erogazkind_sortcode, erogazkind.title,
 isnull('Tipologia: ' + erogazkind.title + '; ','') as dropdown_title
FROM [dbo].erogazkind WITH (NOLOCK) 
WHERE  erogazkind.iderogazkind IS NOT NULL 
GO


-- GENERAZIONE DATI PER erogazkinddefaultview --
