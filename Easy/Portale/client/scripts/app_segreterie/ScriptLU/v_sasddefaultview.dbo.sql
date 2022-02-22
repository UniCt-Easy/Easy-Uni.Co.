
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


-- CREAZIONE VISTA sasddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sasddefaultview]
GO

CREATE VIEW [dbo].[sasddefaultview] AS 
SELECT  sasd.codice, sasd.codice_old AS sasd_codice_old,
 [dbo].areadidattica.title AS areadidattica_title, sasd.idareadidattica, sasd.idsasd, sasd.lt AS sasd_lt, sasd.lu AS sasd_lu, sasd.title AS sasd_title,
 isnull('Codice: ' + sasd.codice + '; ','') + ' ' + isnull('Denominazione: ' + sasd.title + '; ','') as dropdown_title
FROM [dbo].sasd WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].areadidattica WITH (NOLOCK) ON sasd.idareadidattica = [dbo].areadidattica.idareadidattica
WHERE  sasd.idsasd IS NOT NULL 
GO


-- GENERAZIONE DATI PER sasddefaultview --
