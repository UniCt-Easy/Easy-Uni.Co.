
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


-- CREAZIONE VISTA bandodssegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bandodssegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[bandodssegview]
GO

CREATE VIEW [dbo].[bandodssegview] AS 
SELECT  bandods.aa, bandods.ct AS bandods_ct, bandods.cu AS bandods_cu, bandods.description AS bandods_description, bandods.fondo AS bandods_fondo, bandods.idbandods, bandods.lt AS bandods_lt, bandods.lu AS bandods_lu, bandods.title,
 isnull('Titolo: ' + bandods.title + '; ','') as dropdown_title
FROM [dbo].bandods WITH (NOLOCK) 
WHERE  bandods.idbandods IS NOT NULL 
GO

