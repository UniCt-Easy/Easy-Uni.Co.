
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


-- CREAZIONE VISTA aulakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[aulakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[aulakinddefaultview]
GO

CREATE VIEW [dbo].[aulakinddefaultview] AS 
SELECT CASE WHEN aulakind.active = 'S' THEN 'Si' WHEN aulakind.active = 'N' THEN 'No' END AS aulakind_active, aulakind.ct AS aulakind_ct, aulakind.cu AS aulakind_cu, aulakind.description AS aulakind_description, aulakind.idaulakind, aulakind.lt AS aulakind_lt, aulakind.lu AS aulakind_lu, aulakind.sortcode AS aulakind_sortcode, aulakind.title,
 isnull('Tipologia: ' + aulakind.title + '; ','') as dropdown_title
FROM [dbo].aulakind WITH (NOLOCK) 
WHERE  aulakind.idaulakind IS NOT NULL 
GO


-- GENERAZIONE DATI PER aulakinddefaultview --
