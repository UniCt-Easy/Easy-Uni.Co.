
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


-- CREAZIONE VISTA tesikinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tesikinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tesikinddefaultview]
GO

CREATE VIEW [dbo].[tesikinddefaultview] AS 
SELECT CASE WHEN tesikind.active = 'S' THEN 'Si' WHEN tesikind.active = 'N' THEN 'No' END AS tesikind_active, tesikind.ct AS tesikind_ct, tesikind.cu AS tesikind_cu, tesikind.description AS tesikind_description, tesikind.idtesikind, tesikind.lt AS tesikind_lt, tesikind.lu AS tesikind_lu, tesikind.sortcode AS tesikind_sortcode, tesikind.title,
 isnull('Tipologia: ' + tesikind.title + '; ','') as dropdown_title
FROM [dbo].tesikind WITH (NOLOCK) 
WHERE  tesikind.active = 'S' AND tesikind.idtesikind IS NOT NULL 
GO

