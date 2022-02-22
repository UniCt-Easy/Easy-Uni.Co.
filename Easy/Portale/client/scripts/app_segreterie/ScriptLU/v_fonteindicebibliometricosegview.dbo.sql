
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


-- CREAZIONE VISTA fonteindicebibliometricosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[fonteindicebibliometricosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[fonteindicebibliometricosegview]
GO



CREATE VIEW [dbo].[fonteindicebibliometricosegview] AS SELECT CASE WHEN fonteindicebibliometrico.active = 'S' THEN 'Si' WHEN fonteindicebibliometrico.active = 'N' THEN 'No' END AS fonteindicebibliometrico_active, fonteindicebibliometrico.ct AS fonteindicebibliometrico_ct, fonteindicebibliometrico.cu AS fonteindicebibliometrico_cu, fonteindicebibliometrico.description AS fonteindicebibliometrico_description, fonteindicebibliometrico.idfonteindicebibliometrico, fonteindicebibliometrico.lt AS fonteindicebibliometrico_lt, fonteindicebibliometrico.lu AS fonteindicebibliometrico_lu, fonteindicebibliometrico.sortcode AS fonteindicebibliometrico_sortcode, fonteindicebibliometrico.title, isnull('Titolo: ' + fonteindicebibliometrico.title + '; ','') as dropdown_title FROM [dbo].fonteindicebibliometrico WITH (NOLOCK)  WHERE  fonteindicebibliometrico.idfonteindicebibliometrico IS NOT NULL 

GO

