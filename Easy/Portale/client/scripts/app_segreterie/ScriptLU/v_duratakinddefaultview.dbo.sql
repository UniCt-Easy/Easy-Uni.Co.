
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


-- CREAZIONE VISTA duratakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[duratakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[duratakinddefaultview]
GO



CREATE VIEW [dbo].[duratakinddefaultview] AS SELECT CASE WHEN duratakind.active = 'S' THEN 'Si' WHEN duratakind.active = 'N' THEN 'No' END AS duratakind_active, duratakind.ans AS duratakind_ans, duratakind.idduratakind, duratakind.lt AS duratakind_lt, duratakind.lu AS duratakind_lu, duratakind.sortcode AS duratakind_sortcode, duratakind.title, isnull('Tipologia: ' + duratakind.title + '; ','') as dropdown_title FROM [dbo].duratakind WITH (NOLOCK)  WHERE  duratakind.idduratakind IS NOT NULL 

GO

