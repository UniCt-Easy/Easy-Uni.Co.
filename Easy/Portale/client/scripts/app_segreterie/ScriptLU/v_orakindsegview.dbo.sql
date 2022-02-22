
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


-- CREAZIONE VISTA orakindsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[orakindsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[orakindsegview]
GO

CREATE VIEW [dbo].[orakindsegview] AS 
SELECT CASE WHEN orakind.active = 'S' THEN 'Si' WHEN orakind.active = 'N' THEN 'No' END AS orakind_active, orakind.ct AS orakind_ct, orakind.cu AS orakind_cu, orakind.description AS orakind_description, orakind.idorakind, orakind.lt AS orakind_lt, orakind.lu AS orakind_lu,CASE WHEN orakind.ripetizioni = 'S' THEN 'Si' WHEN orakind.ripetizioni = 'N' THEN 'No' END AS orakind_ripetizioni, orakind.sortcode AS orakind_sortcode, orakind.title,
 isnull('Tipologia: ' + orakind.title + '; ','') as dropdown_title
FROM [dbo].orakind WITH (NOLOCK) 
WHERE  orakind.idorakind IS NOT NULL 
GO


-- GENERAZIONE DATI PER orakindsegview --
