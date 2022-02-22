
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


-- CREAZIONE VISTA progettoactivitykinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoactivitykinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[progettoactivitykinddefaultview]
GO



CREATE VIEW [dbo].[progettoactivitykinddefaultview] AS SELECT CASE WHEN progettoactivitykind.active = 'S' THEN 'Si' WHEN progettoactivitykind.active = 'N' THEN 'No' END AS progettoactivitykind_active, progettoactivitykind.ct AS progettoactivitykind_ct, progettoactivitykind.cu AS progettoactivitykind_cu, progettoactivitykind.description AS progettoactivitykind_description, progettoactivitykind.idprogettoactivitykind, progettoactivitykind.lt AS progettoactivitykind_lt, progettoactivitykind.lu AS progettoactivitykind_lu, progettoactivitykind.sortcode AS progettoactivitykind_sortcode, progettoactivitykind.title, isnull('Tipologia: ' + progettoactivitykind.title + '; ','') as dropdown_title FROM [dbo].progettoactivitykind WITH (NOLOCK)  WHERE  progettoactivitykind.idprogettoactivitykind IS NOT NULL 

GO

