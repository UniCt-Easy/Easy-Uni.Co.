
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


-- CREAZIONE VISTA questionariokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[questionariokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[questionariokinddefaultview]
GO

CREATE VIEW [dbo].[questionariokinddefaultview] AS 
SELECT CASE WHEN questionariokind.active = 'S' THEN 'Si' WHEN questionariokind.active = 'N' THEN 'No' END AS questionariokind_active, questionariokind.ct AS questionariokind_ct, questionariokind.cu AS questionariokind_cu, questionariokind.description AS questionariokind_description, questionariokind.idquestionariokind, questionariokind.lt AS questionariokind_lt, questionariokind.lu AS questionariokind_lu, questionariokind.sortcode AS questionariokind_sortcode, questionariokind.title,
 isnull('Tipologia: ' + questionariokind.title + '; ','') as dropdown_title
FROM [dbo].questionariokind WITH (NOLOCK) 
WHERE  questionariokind.idquestionariokind IS NOT NULL 
GO


-- GENERAZIONE DATI PER questionariokinddefaultview --
