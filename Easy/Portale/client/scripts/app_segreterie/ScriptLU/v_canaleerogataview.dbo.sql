
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


-- CREAZIONE VISTA canaleerogataview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[canaleerogataview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[canaleerogataview]
GO

CREATE VIEW [dbo].[canaleerogataview] AS 
SELECT  canale.aa, canale.ct AS canale_ct, canale.cu AS canale_cu, canale.CUIN AS canale_CUIN,
 [dbo].attivform.title AS attivform_title, canale.idattivform, canale.idcanale, canale.idcorsostudio, canale.iddidprog,
 [dbo].didproganno.title AS didproganno_title, canale.iddidproganno,
 [dbo].didprogcurr.title AS didprogcurr_title, canale.iddidprogcurr,
 [dbo].didprogori.title AS didprogori_title, canale.iddidprogori,
 [dbo].didprogporzanno.title AS didprogporzanno_title, canale.iddidprogporzanno, canale.idsede AS canale_idsede, canale.lt AS canale_lt, canale.lu AS canale_lu, canale.numerostud AS canale_numerostud, canale.sortcode AS canale_sortcode, canale.title,
 isnull('Denominazione: ' + canale.title + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT mutuazione.json AS Mutuazione FROM  dbo.mutuazione
 WHERE mutuazione.aa = canale.aa AND mutuazione.idattivform = canale.idattivform AND mutuazione.idcanale = canale.idcanale AND mutuazione.idcorsostudio = canale.idcorsostudio AND mutuazione.iddidprog = canale.iddidprog AND mutuazione.iddidproganno = canale.iddidproganno AND mutuazione.iddidprogcurr = canale.iddidprogcurr AND mutuazione.iddidprogori = canale.iddidprogori AND mutuazione.iddidprogporzanno = canale.iddidprogporzanno FOR XML path, root)))) AS XXmutuazione 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull((Select top 1 'Denominazione: ' +title from registry_docenti x where x.idreg = affidamento.idreg_docenti) + '; ','') AS Docente,affidamento.json AS Affidamento,isnull((Select top 1 'Tipologia: ' +title from affidamentokind x where x.idaffidamentokind = affidamento.idaffidamentokind) + '; ','') AS Tipologia,isnull((Select top 1 'Tipologia: ' +title from erogazkind x where x.iderogazkind = affidamento.iderogazkind) + '; ','') AS Tipo_di_erogazione,isnull('' + CASE WHEN affidamento.freqobbl = 'S' THEN 'Frequenza obbligatoria' ELSE 'non Frequenza obbligatoria' END,'') AS Frequenza_obbligatoria,isnull('"dal " : "' + CONVERT(VARCHAR, affidamento.start, 103)+ '"','') AS dal_,isnull('"al " : "' + CONVERT(VARCHAR, affidamento.stop, 103)+ '"','') AS al_ FROM  dbo.affidamento
 WHERE affidamento.aa = canale.aa AND affidamento.idattivform = canale.idattivform AND affidamento.idcanale = canale.idcanale AND affidamento.idcorsostudio = canale.idcorsostudio AND affidamento.iddidprog = canale.iddidprog AND affidamento.iddidproganno = canale.iddidproganno AND affidamento.iddidprogcurr = canale.iddidprogcurr AND affidamento.iddidprogori = canale.iddidprogori AND affidamento.iddidprogporzanno = canale.iddidprogporzanno FOR XML path, root)))) AS XXaffidamento 
FROM [dbo].canale WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].attivform WITH (NOLOCK) ON canale.idattivform = [dbo].attivform.idattivform
LEFT OUTER JOIN [dbo].didproganno WITH (NOLOCK) ON canale.iddidproganno = [dbo].didproganno.iddidproganno
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON canale.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON canale.iddidprogori = [dbo].didprogori.iddidprogori
LEFT OUTER JOIN [dbo].didprogporzanno WITH (NOLOCK) ON canale.iddidprogporzanno = [dbo].didprogporzanno.iddidprogporzanno
WHERE  canale.aa IS NOT NULL  AND canale.idattivform IS NOT NULL  AND canale.idcanale IS NOT NULL  AND canale.idcorsostudio IS NOT NULL  AND canale.iddidprog IS NOT NULL  AND canale.iddidproganno IS NOT NULL  AND canale.iddidprogcurr IS NOT NULL  AND canale.iddidprogori IS NOT NULL  AND canale.iddidprogporzanno IS NOT NULL 
GO

