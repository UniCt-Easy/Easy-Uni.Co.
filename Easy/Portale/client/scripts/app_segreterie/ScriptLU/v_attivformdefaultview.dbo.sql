
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


-- CREAZIONE VISTA attivformdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[attivformdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[attivformdefaultview]
GO

CREATE VIEW [dbo].[attivformdefaultview] AS 
SELECT  attivform.aa, attivform.ct AS attivform_ct, attivform.cu AS attivform_cu, attivform.idattivform, attivform.idcorsostudio, attivform.iddidprog,
 [dbo].didproganno.title AS didproganno_title, attivform.iddidproganno,
 [dbo].didprogcurr.title AS didprogcurr_title, attivform.iddidprogcurr,
 [dbo].didproggrupp.title AS didproggrupp_title, attivform.iddidproggrupp AS attivform_iddidproggrupp,
 [dbo].didprogori.title AS didprogori_title, attivform.iddidprogori,
 [dbo].didprogporzanno.title AS didprogporzanno_title, attivform.iddidprogporzanno,
 [dbo].insegn.denominazione AS insegn_denominazione, [dbo].insegn.codice AS insegn_codice, attivform.idinsegn,
 [dbo].insegninteg.denominazione AS insegninteg_denominazione, [dbo].insegninteg.codice AS insegninteg_codice, attivform.idinsegninteg, attivform.idsede, attivform.lt AS attivform_lt, attivform.lu AS attivform_lu, attivform.obbform AS attivform_obbform, attivform.obbform_en AS attivform_obbform_en, attivform.sortcode AS attivform_sortcode, attivform.start AS attivform_start, attivform.stop AS attivform_stop,CASE WHEN attivform.tipovalutaz = 'P' THEN 'Profitto' WHEN attivform.tipovalutaz = 'I' THEN 'Idoneità' END AS attivform_tipovalutaz, attivform.title,
 isnull('Attività formativa: ' + attivform.title + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT canale.title AS Denominazione FROM  dbo.canale
 WHERE canale.aa = attivform.aa AND canale.idattivform = attivform.idattivform AND canale.idcorsostudio = attivform.idcorsostudio AND canale.iddidprog = attivform.iddidprog AND canale.iddidproganno = attivform.iddidproganno AND canale.iddidprogcurr = attivform.iddidprogcurr AND canale.iddidprogori = attivform.iddidprogori AND canale.iddidprogporzanno = attivform.iddidprogporzanno AND canale.idsede = attivform.idsede FOR XML path, root)))) AS XXcanale 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull(CAST(attivformcaratteristica.cf AS NVARCHAR(64)),'0.00') AS Crediti,attivformcaratteristica.json AS Caratteristiche,isnull((Select top 1 'Denominazione: ' +title from tipoattform x where x.idtipoattform = attivformcaratteristica.idtipoattform) + '; ','') AS Tipo_di_attività_formativa,isnull((Select top 1 'Ambito: ' +title from ambitoareadisc x where x.idambitoareadisc = attivformcaratteristica.idambitoareadisc) + '; ','') AS Ambito_o_area_disciplinare,isnull((Select top 1 'Gruppo: ' +title from sasdgruppo x where x.idsasdgruppo = attivformcaratteristica.idsasdgruppo) + '; ','') AS Gruppo,isnull((Select top 1 'Codice: ' +codice + '; ' + 'Denominazione: ' +title from sasd x where x.idsasd = attivformcaratteristica.idsasd) + '; ','') AS SASD,isnull('' + CASE WHEN attivformcaratteristica.profess = 'S' THEN 'Professionalizzante' ELSE 'non Professionalizzante' END,'') AS Professionalizzante FROM  dbo.attivformcaratteristica
 WHERE attivformcaratteristica.aa = attivform.aa AND attivformcaratteristica.idattivform = attivform.idattivform AND attivformcaratteristica.idcorsostudio = attivform.idcorsostudio AND attivformcaratteristica.iddidprog = attivform.iddidprog AND attivformcaratteristica.iddidproganno = attivform.iddidproganno AND attivformcaratteristica.iddidprogcurr = attivform.iddidprogcurr AND attivformcaratteristica.iddidprogori = attivform.iddidprogori AND attivformcaratteristica.iddidprogporzanno = attivform.iddidprogporzanno FOR XML path, root)))) AS XXattivformcaratteristica 
FROM [dbo].attivform WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].didproganno WITH (NOLOCK) ON attivform.iddidproganno = [dbo].didproganno.iddidproganno
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON attivform.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].didproggrupp WITH (NOLOCK) ON attivform.iddidproggrupp = [dbo].didproggrupp.iddidproggrupp
LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON attivform.iddidprogori = [dbo].didprogori.iddidprogori
LEFT OUTER JOIN [dbo].didprogporzanno WITH (NOLOCK) ON attivform.iddidprogporzanno = [dbo].didprogporzanno.iddidprogporzanno
LEFT OUTER JOIN [dbo].insegn WITH (NOLOCK) ON attivform.idinsegn = [dbo].insegn.idinsegn
LEFT OUTER JOIN [dbo].insegninteg WITH (NOLOCK) ON attivform.idinsegninteg = [dbo].insegninteg.idinsegninteg
WHERE  attivform.aa IS NOT NULL  AND attivform.idattivform IS NOT NULL  AND attivform.idcorsostudio IS NOT NULL  AND attivform.iddidprog IS NOT NULL  AND attivform.iddidproganno IS NOT NULL  AND attivform.iddidprogcurr IS NOT NULL  AND attivform.iddidprogori IS NOT NULL  AND attivform.iddidprogporzanno IS NOT NULL  AND attivform.idsede IS NOT NULL 
GO

