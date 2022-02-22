
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


-- CREAZIONE VISTA perfprogettostatusdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettostatusdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettostatusdefaultview]
GO

CREATE VIEW [dbo].[perfprogettostatusdefaultview] AS 
SELECT CASE WHEN perfprogettostatus.active = 'S' THEN 'Si' WHEN perfprogettostatus.active = 'N' THEN 'No' END AS perfprogettostatus_active, perfprogettostatus.ct AS perfprogettostatus_ct, perfprogettostatus.cu AS perfprogettostatus_cu, perfprogettostatus.description AS perfprogettostatus_description, perfprogettostatus.idperfprogettostatus, perfprogettostatus.lt AS perfprogettostatus_lt, perfprogettostatus.lu AS perfprogettostatus_lu, perfprogettostatus.title,
 isnull('Stato: ' + perfprogettostatus.title + '; ','') as dropdown_title
FROM [dbo].perfprogettostatus WITH (NOLOCK) 
WHERE  perfprogettostatus.idperfprogettostatus IS NOT NULL 
GO


-- GENERAZIONE DATI PER perfprogettostatusdefaultview --
