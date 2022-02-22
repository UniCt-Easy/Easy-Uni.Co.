
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


-- CREAZIONE VISTA perfprogettoobiettivovalutazione_altreuoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivovalutazione_altreuoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettoobiettivovalutazione_altreuoview]
GO



CREATE VIEW [dbo].[perfprogettoobiettivovalutazione_altreuoview] AS 
SELECT  perfprogettoobiettivo.completamento AS perfprogettoobiettivo_completamento, perfprogettoobiettivo.ct AS perfprogettoobiettivo_ct, perfprogettoobiettivo.cu AS perfprogettoobiettivo_cu, perfprogettoobiettivo.description AS perfprogettoobiettivo_description, perfprogettoobiettivo.idperfprogetto, perfprogettoobiettivo.idperfprogettoobiettivo, perfprogettoobiettivo.lt AS perfprogettoobiettivo_lt, perfprogettoobiettivo.lu AS perfprogettoobiettivo_lu, perfprogettoobiettivo.peso AS perfprogettoobiettivo_peso, perfprogettoobiettivo.title, perfprogettoobiettivo_valutazione.ct AS perfprogettoobiettivo_valutazione_ct, perfprogettoobiettivo_valutazione.cu AS perfprogettoobiettivo_valutazione_cu, perfprogettoobiettivo_valutazione.idperfprogetto AS perfprogettoobiettivo_valutazione_idperfprogetto, perfprogettoobiettivo_valutazione.idperfprogettoobiettivo AS perfprogettoobiettivo_valutazione_idperfprogettoobiettivo, perfprogettoobiettivo_valutazione.idperfprogettouo AS perfprogettoobiettivo_valutazione_idperfprogettouo, perfprogettoobiettivo_valutazione.idperfvalutazioneuo AS perfprogettoobiettivo_valutazione_idperfvalutazioneuo, perfprogettoobiettivo_valutazione.lt AS perfprogettoobiettivo_valutazione_lt, perfprogettoobiettivo_valutazione.lu AS perfprogettoobiettivo_valutazione_lu,
 isnull('Titolo: ' + perfprogettoobiettivo.title + '; ','') as dropdown_title
FROM [dbo].perfprogettoobiettivo WITH (NOLOCK) 
INNER JOIN perfprogettoobiettivo_valutazione WITH (NOLOCK) ON perfprogettoobiettivo.idperfprogetto = perfprogettoobiettivo_valutazione.idperfprogetto AND perfprogettoobiettivo.idperfprogettoobiettivo = perfprogettoobiettivo_valutazione.idperfprogettoobiettivo
WHERE  perfprogettoobiettivo.idperfprogetto IS NOT NULL  AND perfprogettoobiettivo.idperfprogettoobiettivo IS NOT NULL  AND perfprogettoobiettivo_valutazione.idperfprogetto IS NOT NULL  AND perfprogettoobiettivo_valutazione.idperfprogettoobiettivo IS NOT NULL  AND perfprogettoobiettivo_valutazione.idperfprogettouo IS NOT NULL  AND perfprogettoobiettivo_valutazione.idperfvalutazioneuo IS NOT NULL 

GO

