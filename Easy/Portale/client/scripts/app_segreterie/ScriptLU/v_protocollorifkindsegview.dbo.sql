
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


-- CREAZIONE VISTA protocollorifkindsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollorifkindsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[protocollorifkindsegview]
GO

CREATE VIEW [dbo].[protocollorifkindsegview] AS 
SELECT CASE WHEN protocollorifkind.active = 'S' THEN 'Si' WHEN protocollorifkind.active = 'N' THEN 'No' END AS protocollorifkind_active, protocollorifkind.description AS protocollorifkind_description, protocollorifkind.idprotocollorifkind, protocollorifkind.lt AS protocollorifkind_lt, protocollorifkind.lu AS protocollorifkind_lu, protocollorifkind.sortcode AS protocollorifkind_sortcode, protocollorifkind.title,
 isnull('Tipologia: ' + protocollorifkind.title + '; ','') as dropdown_title
FROM [dbo].protocollorifkind WITH (NOLOCK) 
WHERE  protocollorifkind.idprotocollorifkind IS NOT NULL 
GO


-- GENERAZIONE DATI PER protocollorifkindsegview --
