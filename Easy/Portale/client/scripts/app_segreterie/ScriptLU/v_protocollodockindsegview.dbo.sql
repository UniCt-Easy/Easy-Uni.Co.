
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


-- CREAZIONE VISTA protocollodockindsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollodockindsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[protocollodockindsegview]
GO

CREATE VIEW [dbo].[protocollodockindsegview] AS 
SELECT CASE WHEN protocollodockind.active = 'S' THEN 'Si' WHEN protocollodockind.active = 'N' THEN 'No' END AS protocollodockind_active, protocollodockind.description AS protocollodockind_description, protocollodockind.idprotocollodockind, protocollodockind.kind AS protocollodockind_kind, protocollodockind.lt AS protocollodockind_lt, protocollodockind.lu AS protocollodockind_lu, protocollodockind.sortcode AS protocollodockind_sortcode, protocollodockind.title,
 isnull('Tipologia: ' + protocollodockind.title + '; ','') as dropdown_title
FROM [dbo].protocollodockind WITH (NOLOCK) 
WHERE  protocollodockind.idprotocollodockind IS NOT NULL 
GO


-- GENERAZIONE DATI PER protocollodockindsegview --
