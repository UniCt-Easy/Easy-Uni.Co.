
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


-- CREAZIONE VISTA appelloazionekinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appelloazionekinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[appelloazionekinddefaultview]
GO

CREATE VIEW [dbo].[appelloazionekinddefaultview] AS 
SELECT CASE WHEN appelloazionekind.active = 'S' THEN 'Si' WHEN appelloazionekind.active = 'N' THEN 'No' END AS appelloazionekind_active, appelloazionekind.ct AS appelloazionekind_ct, appelloazionekind.cu AS appelloazionekind_cu, appelloazionekind.description AS appelloazionekind_description, appelloazionekind.idappelloazionekind, appelloazionekind.lt AS appelloazionekind_lt, appelloazionekind.lu AS appelloazionekind_lu, appelloazionekind.sortcode AS appelloazionekind_sortcode, appelloazionekind.title,
 isnull('Tipologia: ' + appelloazionekind.title + '; ','') as dropdown_title
FROM [dbo].appelloazionekind WITH (NOLOCK) 
WHERE  appelloazionekind.idappelloazionekind IS NOT NULL 
GO


-- GENERAZIONE DATI PER appelloazionekinddefaultview --
