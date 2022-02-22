
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


-- CREAZIONE VISTA dichiarkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiarkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[dichiarkinddefaultview]
GO

CREATE VIEW [dbo].[dichiarkinddefaultview] AS SELECT CASE WHEN dichiarkind.active = 'S' THEN 'Si' WHEN dichiarkind.active = 'N' THEN 'No' END AS dichiarkind_active, dichiarkind.ct AS dichiarkind_ct, dichiarkind.cu AS dichiarkind_cu, dichiarkind.description AS dichiarkind_description, dichiarkind.iddichiarkind, dichiarkind.lt AS dichiarkind_lt, dichiarkind.lu AS dichiarkind_lu, dichiarkind.sortcode AS dichiarkind_sortcode, dichiarkind.title, isnull('Tipologia: ' + dichiarkind.title + '; ','') as dropdown_title FROM [dbo].dichiarkind WITH (NOLOCK)  WHERE  dichiarkind.iddichiarkind IS NOT NULL 
GO


-- GENERAZIONE DATI PER dichiarkinddefaultview --
