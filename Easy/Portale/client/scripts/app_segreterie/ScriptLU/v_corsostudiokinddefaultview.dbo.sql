
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


-- CREAZIONE VISTA corsostudiokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudiokinddefaultview]
GO

CREATE VIEW [dbo].[corsostudiokinddefaultview] AS 
SELECT CASE WHEN corsostudiokind.active = 'S' THEN 'Si' WHEN corsostudiokind.active = 'N' THEN 'No' END AS corsostudiokind_active, corsostudiokind.ct AS corsostudiokind_ct, corsostudiokind.cu AS corsostudiokind_cu, corsostudiokind.description AS corsostudiokind_description, corsostudiokind.idcorsostudiokind, corsostudiokind.lt AS corsostudiokind_lt, corsostudiokind.lu AS corsostudiokind_lu, corsostudiokind.sortcode AS corsostudiokind_sortcode, corsostudiokind.title,
 isnull('Tipologia: ' + corsostudiokind.title + '; ','') as dropdown_title
FROM [dbo].corsostudiokind WITH (NOLOCK) 
WHERE  corsostudiokind.idcorsostudiokind IS NOT NULL 
GO


-- GENERAZIONE DATI PER corsostudiokinddefaultview --
