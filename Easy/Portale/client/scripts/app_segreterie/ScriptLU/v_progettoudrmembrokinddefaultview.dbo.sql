
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


-- CREAZIONE VISTA progettoudrmembrokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoudrmembrokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[progettoudrmembrokinddefaultview]
GO



CREATE VIEW [dbo].[progettoudrmembrokinddefaultview] AS SELECT CASE WHEN progettoudrmembrokind.active = 'S' THEN 'Si' WHEN progettoudrmembrokind.active = 'N' THEN 'No' END AS progettoudrmembrokind_active, progettoudrmembrokind.ct AS progettoudrmembrokind_ct, progettoudrmembrokind.cu AS progettoudrmembrokind_cu, progettoudrmembrokind.description AS progettoudrmembrokind_description, progettoudrmembrokind.idprogettoudrmembrokind, progettoudrmembrokind.lt AS progettoudrmembrokind_lt, progettoudrmembrokind.lu AS progettoudrmembrokind_lu, progettoudrmembrokind.sortcode AS progettoudrmembrokind_sortcode, progettoudrmembrokind.title, isnull('Tipo di membro: ' + progettoudrmembrokind.title + '; ','') as dropdown_title FROM [dbo].progettoudrmembrokind WITH (NOLOCK)  WHERE  progettoudrmembrokind.idprogettoudrmembrokind IS NOT NULL 

GO

