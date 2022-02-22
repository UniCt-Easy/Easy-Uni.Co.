
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


-- CREAZIONE VISTA insegndefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[insegndefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[insegndefaultview]
GO

CREATE VIEW [dbo].[insegndefaultview] AS 
SELECT  insegn.codice AS insegn_codice, insegn.ct AS insegn_ct, insegn.cu AS insegn_cu, insegn.denominazione, insegn.denominazione_en AS insegn_denominazione_en,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, insegn.idcorsostudio,
 [dbo].corsostudiokind.title AS corsostudiokind_title, insegn.idcorsostudiokind AS insegn_idcorsostudiokind, insegn.idinsegn,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, insegn.idstruttura, insegn.lt AS insegn_lt, insegn.lu AS insegn_lu,
 isnull('Denominazione: ' + insegn.denominazione + '; ','') + ' ' + isnull('; Codice  : ' + insegn.codice + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull(CAST(insegncaratteristica.cf AS NVARCHAR(64)),'0.00') AS Crediti,isnull((Select top 1 'Codice: ' +codice + '; ' + 'Denominazione: ' +title from sasd x where x.idsasd = insegncaratteristica.idsasd) + '; ','') AS SASD,isnull('' + CASE WHEN insegncaratteristica.profess = 'S' THEN 'Professionalizzante' ELSE 'non Professionalizzante' END,'') AS Professionalizzante FROM  dbo.insegncaratteristica
 WHERE insegncaratteristica.idinsegn = insegn.idinsegn FOR XML path, root)))) AS XXinsegncaratteristica 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT insegninteg.denominazione AS Denominazione,insegninteg.codice AS Codice FROM  dbo.insegninteg
 WHERE insegninteg.idinsegn = insegn.idinsegn FOR XML path, root)))) AS XXinsegninteg 
FROM [dbo].insegn WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON insegn.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].corsostudiokind WITH (NOLOCK) ON insegn.idcorsostudiokind = [dbo].corsostudiokind.idcorsostudiokind
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON insegn.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  insegn.idinsegn IS NOT NULL 
GO

