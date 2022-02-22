
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


-- CREAZIONE VISTA insegnintegdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[insegnintegdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[insegnintegdefaultview]
GO

CREATE VIEW [dbo].[insegnintegdefaultview] AS 
SELECT  insegninteg.codice AS insegninteg_codice, insegninteg.ct AS insegninteg_ct, insegninteg.cu AS insegninteg_cu, insegninteg.denominazione, insegninteg.denominazione_en AS insegninteg_denominazione_en, insegninteg.idinsegn, insegninteg.idinsegninteg, insegninteg.lt AS insegninteg_lt, insegninteg.lu AS insegninteg_lu,
 isnull('Denominazione: ' + insegninteg.denominazione + '; ','') + ' ' + isnull('Codice: ' + insegninteg.codice + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull(CAST(insegnintegcaratteristica.cf AS NVARCHAR(64)),'0.00') AS Crediti,isnull(CAST( (Select top 1 'Codice: ' +codice + '; ' + 'Denominazione: ' +title from sasd x where x.idsasd = insegnintegcaratteristica.idsasd) AS NVARCHAR(1024)) + '; ','') AS SASD,isnull('' + CASE WHEN insegnintegcaratteristica.profess = 'S' THEN 'Professionalizzante' ELSE 'non Professionalizzante' END,'') AS Professionalizzante FROM  dbo.insegnintegcaratteristica
 WHERE insegnintegcaratteristica.idinsegn = insegninteg.idinsegn AND insegnintegcaratteristica.idinsegninteg = insegninteg.idinsegninteg FOR XML path, root)))) AS XXinsegnintegcaratteristica 
FROM [dbo].insegninteg WITH (NOLOCK) 
WHERE  insegninteg.idinsegn IS NOT NULL  AND insegninteg.idinsegninteg IS NOT NULL 
GO

