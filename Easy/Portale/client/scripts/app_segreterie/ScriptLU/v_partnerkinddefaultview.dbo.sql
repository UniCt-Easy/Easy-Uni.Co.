
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


-- CREAZIONE VISTA partnerkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[partnerkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[partnerkinddefaultview]
GO

CREATE VIEW [dbo].[partnerkinddefaultview] AS 
SELECT CASE WHEN partnerkind.active = 'S' THEN 'Si' WHEN partnerkind.active = 'N' THEN 'No' END AS partnerkind_active, partnerkind.description AS partnerkind_description, partnerkind.idpartnerkind, partnerkind.sortcode AS partnerkind_sortcode, partnerkind.title,
 isnull('Tipologia: ' + partnerkind.title + '; ','') as dropdown_title
FROM [dbo].partnerkind WITH (NOLOCK) 
WHERE  partnerkind.idpartnerkind IS NOT NULL 
GO


-- GENERAZIONE DATI PER partnerkinddefaultview --
