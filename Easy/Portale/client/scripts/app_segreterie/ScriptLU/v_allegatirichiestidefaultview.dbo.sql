
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


-- CREAZIONE VISTA allegatirichiestidefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[allegatirichiestidefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[allegatirichiestidefaultview]
GO

CREATE VIEW [dbo].[allegatirichiestidefaultview] AS 
SELECT CASE WHEN allegatirichiesti.active = 'S' THEN 'Si' WHEN allegatirichiesti.active = 'N' THEN 'No' END AS allegatirichiesti_active, allegatirichiesti.ct AS allegatirichiesti_ct, allegatirichiesti.cu AS allegatirichiesti_cu, allegatirichiesti.idallegatirichiesti, allegatirichiesti.lt AS allegatirichiesti_lt, allegatirichiesti.lu AS allegatirichiesti_lu, allegatirichiesti.sortcode AS allegatirichiesti_sortcode, allegatirichiesti.title,
 isnull('Titolo: ' + allegatirichiesti.title + '; ','') as dropdown_title
FROM [dbo].allegatirichiesti WITH (NOLOCK) 
WHERE  allegatirichiesti.idallegatirichiesti IS NOT NULL 
GO

