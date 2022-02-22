
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


-- CREAZIONE VISTA corsostudiolivellodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiolivellodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudiolivellodefaultview]
GO

CREATE VIEW [dbo].[corsostudiolivellodefaultview] AS 
SELECT 
 [dbo].corsostudiokind.title AS corsostudiokind_title, corsostudiolivello.idcorsostudiokind AS corsostudiolivello_idcorsostudiokind, corsostudiolivello.idcorsostudiolivello, corsostudiolivello.lt AS corsostudiolivello_lt, corsostudiolivello.lu AS corsostudiolivello_lu, corsostudiolivello.title,
 isnull('Livello: ' + corsostudiolivello.title + '; ','') as dropdown_title
FROM [dbo].corsostudiolivello WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudiokind WITH (NOLOCK) ON corsostudiolivello.idcorsostudiokind = [dbo].corsostudiokind.idcorsostudiokind
WHERE  corsostudiolivello.idcorsostudiolivello IS NOT NULL 
GO


-- GENERAZIONE DATI PER corsostudiolivellodefaultview --
