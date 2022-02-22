
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


-- CREAZIONE VISTA affidamentokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[affidamentokinddefaultview]
GO

CREATE VIEW [dbo].[affidamentokinddefaultview] AS 
SELECT CASE WHEN affidamentokind.active = 'S' THEN 'Si' WHEN affidamentokind.active = 'N' THEN 'No' END AS affidamentokind_active, affidamentokind.costoora AS affidamentokind_costoora,CASE WHEN affidamentokind.costoorariodacontratto = 'S' THEN 'Si' WHEN affidamentokind.costoorariodacontratto = 'N' THEN 'No' END AS affidamentokind_costoorariodacontratto, affidamentokind.ct AS affidamentokind_ct, affidamentokind.cu AS affidamentokind_cu, affidamentokind.description AS affidamentokind_description, affidamentokind.idaffidamentokind, affidamentokind.lt AS affidamentokind_lt, affidamentokind.lu AS affidamentokind_lu, affidamentokind.sortcode AS affidamentokind_sortcode, affidamentokind.title,
 isnull('Tipologia: ' + affidamentokind.title + '; ','') as dropdown_title
FROM [dbo].affidamentokind WITH (NOLOCK) 
WHERE  affidamentokind.idaffidamentokind IS NOT NULL 
GO


-- GENERAZIONE DATI PER affidamentokinddefaultview --
