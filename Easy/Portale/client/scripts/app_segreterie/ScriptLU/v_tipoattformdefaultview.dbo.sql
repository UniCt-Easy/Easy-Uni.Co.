
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


-- CREAZIONE VISTA tipoattformdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tipoattformdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tipoattformdefaultview]
GO

CREATE VIEW [dbo].[tipoattformdefaultview] AS 
SELECT  tipoattform.description AS tipoattform_description, tipoattform.idtipoattform, tipoattform.lt AS tipoattform_lt, tipoattform.lu AS tipoattform_lu, tipoattform.title,
 isnull('Denominazione: ' + tipoattform.title + '; ','') + ' ' + isnull('Descrizione: ' + tipoattform.description + '; ','') as dropdown_title
FROM [dbo].tipoattform WITH (NOLOCK) 
WHERE  tipoattform.idtipoattform IS NOT NULL 
GO


-- GENERAZIONE DATI PER tipoattformdefaultview --
