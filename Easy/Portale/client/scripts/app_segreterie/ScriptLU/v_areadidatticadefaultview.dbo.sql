
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


-- CREAZIONE VISTA areadidatticadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[areadidatticadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[areadidatticadefaultview]
GO

CREATE VIEW [dbo].[areadidatticadefaultview] AS 
SELECT CASE WHEN areadidattica.active = 'S' THEN 'Si' WHEN areadidattica.active = 'N' THEN 'No' END AS areadidattica_active, areadidattica.ct AS areadidattica_ct, areadidattica.cu AS areadidattica_cu, areadidattica.idareadidattica,
 [dbo].corsostudiokind.title AS corsostudiokind_title, areadidattica.idcorsostudiokind AS areadidattica_idcorsostudiokind, areadidattica.lt AS areadidattica_lt, areadidattica.lu AS areadidattica_lu, areadidattica.sortcode AS areadidattica_sortcode, areadidattica.subtitle AS areadidattica_subtitle, areadidattica.title,
 isnull('Titolo: ' + areadidattica.title + '; ','') as dropdown_title
FROM [dbo].areadidattica WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudiokind WITH (NOLOCK) ON areadidattica.idcorsostudiokind = [dbo].corsostudiokind.idcorsostudiokind
WHERE  areadidattica.idareadidattica IS NOT NULL 
GO


-- GENERAZIONE DATI PER areadidatticadefaultview --
