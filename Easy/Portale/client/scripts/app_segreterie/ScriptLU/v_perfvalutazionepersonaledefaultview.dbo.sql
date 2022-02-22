
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


-- CREAZIONE VISTA perfvalutazionepersonaledefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazionepersonaledefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfvalutazionepersonaledefaultview]
GO

CREATE VIEW [dbo].[perfvalutazionepersonaledefaultview] AS 
SELECT  perfvalutazionepersonale.idperfvalutazionepersonale,
 [dbo].registry.title AS registry_title, perfvalutazionepersonale.idreg, perfvalutazionepersonale.year, perfvalutazionepersonale.ct AS perfvalutazionepersonale_ct, perfvalutazionepersonale.risultato AS perfvalutazionepersonale_risultato, perfvalutazionepersonale.cu AS perfvalutazionepersonale_cu,
 [dbo].perfschedastatus.title AS perfschedastatus_title, perfvalutazionepersonale.idperfschedastatus AS perfvalutazionepersonale_idperfschedastatus,
 registryval.title AS registryval_title, perfvalutazionepersonale.idreg_val AS perfvalutazionepersonale_idreg_val, perfvalutazionepersonale.lt AS perfvalutazionepersonale_lt,
 registryappr.title AS registryappr_title, perfvalutazionepersonale.idreg_appr AS perfvalutazionepersonale_idreg_appr, perfvalutazionepersonale.lu AS perfvalutazionepersonale_lu, perfvalutazionepersonale.pesoperfuo AS perfvalutazionepersonale_pesoperfuo, perfvalutazionepersonale.percperfuo AS perfvalutazionepersonale_percperfuo, perfvalutazionepersonale.pesocomportamenti AS perfvalutazionepersonale_pesocomportamenti, perfvalutazionepersonale.perccomportamenti AS perfvalutazionepersonale_perccomportamenti, perfvalutazionepersonale.pesoobiettivi AS perfvalutazionepersonale_pesoobiettivi, perfvalutazionepersonale.percobiettivi AS perfvalutazionepersonale_percobiettivi,
 [dbo].struttura.title AS struttura_title, [dbo].afferenza.idstruttura AS afferenza_idstruttura, [dbo].afferenza.start AS afferenza_start, [dbo].afferenza.stop AS afferenza_stop, [dbo].mansionekind.title AS mansionekind_title, [dbo].afferenza.idmansionekind AS afferenza_idmansionekind, perfvalutazionepersonale.idafferenza AS perfvalutazionepersonale_idafferenza,
 isnull('Valutato: ' + [dbo].registry.title + '; ','') + ' ' + isnull((Select top 1 'Identificativo: ' +CAST( year AS NVARCHAR(64)) from year x where x.year = perfvalutazionepersonale.year) + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Tipo: ' +CAST( idstrutturakind AS NVARCHAR(64)) from struttura x where x.idstruttura = perfvalutazionepersonaleuo.idstruttura) + '; ','') AS Unità_organizzativa,isnull(CAST(perfvalutazionepersonaleuo.afferenza AS NVARCHAR(64)),'0.00') AS Tempo_di_afferenza,isnull(CAST(perfvalutazionepersonaleuo.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfvalutazionepersonaleuo.punteggio AS NVARCHAR(64)),'0.00') AS Punteggio,isnull(CAST(perfvalutazionepersonaleuo.punteggiopesato AS NVARCHAR(64)),'0.00') AS Punteggio_pesato FROM  dbo.perfvalutazionepersonaleuo
 WHERE perfvalutazionepersonaleuo.idperfvalutazionepersonale = perfvalutazionepersonale.idperfvalutazionepersonale FOR XML path, root)))) AS XXperfvalutazionepersonaleuo 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull((Select top 1 'Titolo: ' +title from perfcomportamento x where x.idperfcomportamento = perfvalutazionepersonalecomportamento.idperfcomportamento) + '; ','') AS Comportamento,isnull(CAST(perfvalutazionepersonalecomportamento.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfvalutazionepersonalecomportamento.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfvalutazionepersonalecomportamento
 WHERE perfvalutazionepersonalecomportamento.idperfvalutazionepersonale = perfvalutazionepersonale.idperfvalutazionepersonale FOR XML path, root)))) AS XXperfvalutazionepersonalecomportamento 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfvalutazionepersonaleobiettivo.title AS Titolo,isnull(CAST(perfvalutazionepersonaleobiettivo.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfvalutazionepersonaleobiettivo.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfvalutazionepersonaleobiettivo
 WHERE perfvalutazionepersonaleobiettivo.idperfvalutazionepersonale = perfvalutazionepersonale.idperfvalutazionepersonale FOR XML path, root)))) AS XXperfvalutazionepersonaleobiettivo 
FROM [dbo].perfvalutazionepersonale WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON perfvalutazionepersonale.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].perfschedastatus WITH (NOLOCK) ON perfvalutazionepersonale.idperfschedastatus = [dbo].perfschedastatus.idperfschedastatus
LEFT OUTER JOIN [dbo].registry AS registryval WITH (NOLOCK) ON perfvalutazionepersonale.idreg_val = registryval.idreg
LEFT OUTER JOIN [dbo].registry AS registryappr WITH (NOLOCK) ON perfvalutazionepersonale.idreg_appr = registryappr.idreg
LEFT OUTER JOIN [dbo].afferenza WITH (NOLOCK) ON perfvalutazionepersonale.idafferenza = [dbo].afferenza.idafferenza
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON [dbo].afferenza.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].mansionekind WITH (NOLOCK) ON [dbo].afferenza.idmansionekind = [dbo].mansionekind.idmansionekind
WHERE  perfvalutazionepersonale.idperfvalutazionepersonale IS NOT NULL  AND perfvalutazionepersonale.idreg IS NOT NULL 
GO

