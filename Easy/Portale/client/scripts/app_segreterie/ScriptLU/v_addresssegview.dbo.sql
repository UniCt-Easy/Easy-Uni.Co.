
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


-- CREAZIONE VISTA addresssegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[addresssegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[addresssegview]
GO

CREATE VIEW [dbo].[addresssegview] AS 
SELECT CASE WHEN address.active = 'S' THEN 'Si' WHEN address.active = 'N' THEN 'No' END AS address_active, address.codeaddress AS address_codeaddress, address.description, address.idaddress, address.lt AS address_lt, address.lu AS address_lu,
 isnull('Descrizione: ' + address.description + '; ','') as dropdown_title
FROM [dbo].address WITH (NOLOCK) 
WHERE  address.active = 'S' AND address.idaddress IS NOT NULL 
GO

