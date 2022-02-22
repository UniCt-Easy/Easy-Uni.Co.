
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


-- CREAZIONE VISTA publicazkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[publicazkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[publicazkinddefaultview]
GO



CREATE VIEW [dbo].[publicazkinddefaultview] AS SELECT CASE WHEN publicazkind.active = 'S' THEN 'Si' WHEN publicazkind.active = 'N' THEN 'No' END AS publicazkind_active, publicazkind.ct AS publicazkind_ct, publicazkind.cu AS publicazkind_cu, publicazkind.idpublicazkind, publicazkind.lt AS publicazkind_lt, publicazkind.lu AS publicazkind_lu, publicazkind.sortcode AS publicazkind_sortcode, publicazkind.subtitle AS publicazkind_subtitle, publicazkind.title, isnull('Tipologia: ' + publicazkind.title + '; ','') + ' ' + isnull('Sotto-tipologia: ' + publicazkind.subtitle + '; ','') as dropdown_title FROM [dbo].publicazkind WITH (NOLOCK)  WHERE  publicazkind.idpublicazkind IS NOT NULL 

GO

