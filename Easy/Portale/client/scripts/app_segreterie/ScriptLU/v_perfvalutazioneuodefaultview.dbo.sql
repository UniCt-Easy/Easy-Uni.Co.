
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


-- CREAZIONE VISTA perfvalutazioneuodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazioneuodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfvalutazioneuodefaultview]
GO

CREATE VIEW [dbo].[perfvalutazioneuodefaultview] AS 
SELECT  perfvalutazioneuo.completamentopsauo AS perfvalutazioneuo_completamentopsauo, perfvalutazioneuo.completamentopsuo AS perfvalutazioneuo_completamentopsuo, perfvalutazioneuo.ct AS perfvalutazioneuo_ct, perfvalutazioneuo.cu AS perfvalutazioneuo_cu,
 [dbo].perfschedastatus.title AS perfschedastatus_title, perfvalutazioneuo.idperfschedastatus AS perfvalutazioneuo_idperfschedastatus, perfvalutazioneuo.idperfvalutazioneuo,
 registryappr.title AS registryappr_title, perfvalutazioneuo.idreg_appr AS perfvalutazioneuo_idreg_appr,
 registryval.title AS registryval_title, perfvalutazioneuo.idreg_val AS perfvalutazioneuo_idreg_val,
 [dbo].struttura.title AS struttura_title, strutturaparent.title AS strutturaparent_title, [dbo].struttura.paridstruttura AS struttura_paridstruttura, perfvalutazioneuo.idstruttura, perfvalutazioneuo.indicatori AS perfvalutazioneuo_indicatori, perfvalutazioneuo.lt AS perfvalutazioneuo_lt, perfvalutazioneuo.lu AS perfvalutazioneuo_lu, perfvalutazioneuo.obiettiviindividuali AS perfvalutazioneuo_obiettiviindividuali, perfvalutazioneuo.pesoindicatori AS perfvalutazioneuo_pesoindicatori, perfvalutazioneuo.pesoobiettivi AS perfvalutazioneuo_pesoobiettivi, perfvalutazioneuo.pesoprogaltreuo AS perfvalutazioneuo_pesoprogaltreuo, perfvalutazioneuo.pesoproguo AS perfvalutazioneuo_pesoproguo, perfvalutazioneuo.risultato AS perfvalutazioneuo_risultato, perfvalutazioneuo.year
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfprogettoobiettivouoview.progetto_title AS Progetto,isnull(CAST(perfprogettoobiettivouoview.peso AS NVARCHAR(64)),'0.00') AS Peso_per_il_progetto,perfprogettoobiettivouoview.title AS Titolo,isnull(CAST(perfprogettoobiettivouoview.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfprogettoobiettivouoview
 WHERE perfprogettoobiettivouoview.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo AND perfprogettoobiettivouoview.idstruttura = perfvalutazioneuo.idstruttura FOR XML path, root)))) AS XXperfprogettoobiettivouoview 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfprogettoobiettivopersonaleview.progetto_title AS Progetto,isnull(CAST(perfprogettoobiettivopersonaleview.peso AS NVARCHAR(64)),'0.00') AS Peso_per_il_progetto,perfprogettoobiettivopersonaleview.title AS Titolo,isnull(CAST(perfprogettoobiettivopersonaleview.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfprogettoobiettivopersonaleview
 WHERE perfprogettoobiettivopersonaleview.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo AND perfprogettoobiettivopersonaleview.idstruttura = perfvalutazioneuo.idstruttura FOR XML path, root)))) AS XXperfprogettoobiettivopersonaleview 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull((Select top 1 'Titolo: ' +title from perfindicatore x where x.idperfindicatore = perfvalutazioneuoindicatori.idperfindicatore) + '; ','') AS Indicatore,isnull(CAST(perfvalutazioneuoindicatori.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfvalutazioneuoindicatori
 WHERE perfvalutazioneuoindicatori.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo FOR XML path, root)))) AS XXperfvalutazioneuoindicatori 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfobiettiviuo.title AS Titolo,isnull(CAST(perfobiettiviuo.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfobiettiviuo.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfobiettiviuo
 WHERE perfobiettiviuo.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo FOR XML path, root)))) AS XXperfobiettiviuo 
FROM [dbo].perfvalutazioneuo WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].perfschedastatus WITH (NOLOCK) ON perfvalutazioneuo.idperfschedastatus = [dbo].perfschedastatus.idperfschedastatus
LEFT OUTER JOIN [dbo].registry AS registryappr WITH (NOLOCK) ON perfvalutazioneuo.idreg_appr = registryappr.idreg
LEFT OUTER JOIN [dbo].registry AS registryval WITH (NOLOCK) ON perfvalutazioneuo.idreg_val = registryval.idreg
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON perfvalutazioneuo.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].struttura AS strutturaparent WITH (NOLOCK) ON [dbo].struttura.paridstruttura = strutturaparent.idstruttura
WHERE  perfvalutazioneuo.idperfvalutazioneuo IS NOT NULL  AND perfvalutazioneuo.idstruttura IS NOT NULL 
GO

