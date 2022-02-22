
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


-- CREAZIONE VISTA perfobiettivokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfobiettivokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfobiettivokinddefaultview]
GO

CREATE VIEW [dbo].[perfobiettivokinddefaultview] AS 
SELECT  perfobiettivokind.idperfobiettivokind, perfobiettivokind.title, perfobiettivokind.ct AS perfobiettivokind_ct, perfobiettivokind.cu AS perfobiettivokind_cu, perfobiettivokind.lt AS perfobiettivokind_lt, perfobiettivokind.lu AS perfobiettivokind_lu, perfobiettivokind.description AS perfobiettivokind_description,CASE WHEN perfobiettivokind.active = 'S' THEN 'Si' WHEN perfobiettivokind.active = 'N' THEN 'No' END AS perfobiettivokind_active,
 isnull('Obiettivo: ' + perfobiettivokind.title + '; ','') as dropdown_title
FROM [dbo].perfobiettivokind WITH (NOLOCK) 
WHERE  perfobiettivokind.idperfobiettivokind IS NOT NULL 
GO


-- GENERAZIONE DATI PER perfobiettivokinddefaultview --
