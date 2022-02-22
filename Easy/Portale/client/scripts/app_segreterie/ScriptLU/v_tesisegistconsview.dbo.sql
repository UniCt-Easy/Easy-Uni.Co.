
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


-- CREAZIONE VISTA tesisegistconsview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tesisegistconsview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tesisegistconsview]
GO

CREATE VIEW [dbo].[tesisegistconsview] AS 
SELECT  tesi.aa, tesi.abstract AS tesi_abstract, tesi.abstract_en AS tesi_abstract_en, tesi.ct AS tesi_ct, tesi.cu AS tesi_cu,CASE WHEN tesi.filestatus = 'S' THEN 'Si' WHEN tesi.filestatus = 'N' THEN 'No' END AS tesi_filestatus,
 [dbo].attach.filename AS attach_filename, tesi.idattach,
 [dbo].insegn.denominazione AS insegn_denominazione, [dbo].insegn.codice AS insegn_codice, tesi.idinsegn, tesi.idreg, tesi.idtesi,
 [dbo].tesikind.title AS tesikind_title, tesi.idtesikind AS tesi_idtesikind, tesi.lt AS tesi_lt, tesi.lu AS tesi_lu, tesi.title, tesi.title_en AS tesi_title_en,
 isnull('Titolo: ' + tesi.title + '; ','') as dropdown_title
FROM [dbo].tesi WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].attach WITH (NOLOCK) ON tesi.idattach = [dbo].attach.idattach
LEFT OUTER JOIN [dbo].insegn WITH (NOLOCK) ON tesi.idinsegn = [dbo].insegn.idinsegn
LEFT OUTER JOIN [dbo].tesikind WITH (NOLOCK) ON tesi.idtesikind = [dbo].tesikind.idtesikind
WHERE  tesi.idreg IS NOT NULL  AND tesi.idtesi IS NOT NULL 
GO

