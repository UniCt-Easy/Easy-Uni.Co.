
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


-- CREAZIONE VISTA rendicontaltrokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontaltrokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[rendicontaltrokinddefaultview]
GO

CREATE VIEW [dbo].[rendicontaltrokinddefaultview] AS 
SELECT CASE WHEN rendicontaltrokind.active = 'S' THEN 'Si' WHEN rendicontaltrokind.active = 'N' THEN 'No' END AS rendicontaltrokind_active, rendicontaltrokind.ct AS rendicontaltrokind_ct, rendicontaltrokind.cu AS rendicontaltrokind_cu, rendicontaltrokind.description AS rendicontaltrokind_description, rendicontaltrokind.idrendicontaltrokind, rendicontaltrokind.lt AS rendicontaltrokind_lt, rendicontaltrokind.lu AS rendicontaltrokind_lu, rendicontaltrokind.sortcode AS rendicontaltrokind_sortcode, rendicontaltrokind.title,
 isnull('Tipologia: ' + rendicontaltrokind.title + '; ','') as dropdown_title
FROM [dbo].rendicontaltrokind WITH (NOLOCK) 
WHERE  rendicontaltrokind.idrendicontaltrokind IS NOT NULL 
GO

