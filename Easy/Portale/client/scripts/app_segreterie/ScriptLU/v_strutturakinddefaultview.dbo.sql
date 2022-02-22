
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


-- CREAZIONE VISTA strutturakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[strutturakinddefaultview]
GO

CREATE VIEW [dbo].[strutturakinddefaultview] AS 
SELECT CASE WHEN strutturakind.active = 'S' THEN 'Si' WHEN strutturakind.active = 'N' THEN 'No' END AS strutturakind_active, strutturakind.description AS strutturakind_description, strutturakind.idstrutturakind, strutturakind.lt AS strutturakind_lt, strutturakind.lu AS strutturakind_lu, strutturakind.sortCode AS strutturakind_sortCode, strutturakind.title,
 isnull('Tipologia: ' + strutturakind.title + '; ','') as dropdown_title
FROM [dbo].strutturakind WITH (NOLOCK) 
WHERE  strutturakind.idstrutturakind IS NOT NULL 
GO


-- GENERAZIONE DATI PER strutturakinddefaultview --
