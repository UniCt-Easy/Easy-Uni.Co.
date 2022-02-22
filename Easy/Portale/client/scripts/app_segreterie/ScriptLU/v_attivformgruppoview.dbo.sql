
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


-- CREAZIONE VISTA attivformgruppoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[attivformgruppoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[attivformgruppoview]
GO

CREATE VIEW [dbo].[attivformgruppoview] AS 
SELECT  attivform.aa, attivform.ct AS attivform_ct, attivform.cu AS attivform_cu, attivform.idattivform, attivform.idcorsostudio, attivform.iddidprog,
 [dbo].didproganno.title AS didproganno_title, attivform.iddidproganno,
 [dbo].didprogcurr.title AS didprogcurr_title, attivform.iddidprogcurr, attivform.iddidproggrupp AS attivform_iddidproggrupp,
 [dbo].didprogori.title AS didprogori_title, attivform.iddidprogori,
 [dbo].didprogporzanno.title AS didprogporzanno_title, attivform.iddidprogporzanno,
 [dbo].insegn.denominazione AS insegn_denominazione, [dbo].insegn.codice AS insegn_codice, attivform.idinsegn,
 [dbo].insegninteg.denominazione AS insegninteg_denominazione, [dbo].insegninteg.codice AS insegninteg_codice, attivform.idinsegninteg, attivform.idsede, attivform.lt AS attivform_lt, attivform.lu AS attivform_lu, attivform.obbform AS attivform_obbform, attivform.obbform_en AS attivform_obbform_en, attivform.sortcode AS attivform_sortcode, attivform.start AS attivform_start, attivform.stop AS attivform_stop,CASE WHEN attivform.tipovalutaz = 'P' THEN 'Profitto' WHEN attivform.tipovalutaz = 'I' THEN 'Idoneità' END AS attivform_tipovalutaz, attivform.title,
 isnull('Attività formativa: ' + attivform.title + '; ','') as dropdown_title
FROM [dbo].attivform WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].didproganno WITH (NOLOCK) ON attivform.iddidproganno = [dbo].didproganno.iddidproganno
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON attivform.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON attivform.iddidprogori = [dbo].didprogori.iddidprogori
LEFT OUTER JOIN [dbo].didprogporzanno WITH (NOLOCK) ON attivform.iddidprogporzanno = [dbo].didprogporzanno.iddidprogporzanno
LEFT OUTER JOIN [dbo].insegn WITH (NOLOCK) ON attivform.idinsegn = [dbo].insegn.idinsegn
LEFT OUTER JOIN [dbo].insegninteg WITH (NOLOCK) ON attivform.idinsegninteg = [dbo].insegninteg.idinsegninteg
WHERE  attivform.aa IS NOT NULL  AND attivform.idattivform IS NOT NULL  AND attivform.idcorsostudio IS NOT NULL  AND attivform.iddidprog IS NOT NULL  AND attivform.iddidproganno IS NOT NULL  AND attivform.iddidprogcurr IS NOT NULL  AND attivform.iddidprogori IS NOT NULL  AND attivform.iddidprogporzanno IS NOT NULL  AND attivform.idsede IS NOT NULL 
GO

