
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


-- CREAZIONE VISTA dichiartitolo_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiartitolo_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[dichiartitolo_segview]
GO

CREATE VIEW [dbo].[dichiartitolo_segview] AS SELECT  dichiar.aa, dichiar.ct AS dichiar_ct, dichiar.cu AS dichiar_cu, dichiar.date AS dichiar_date, dichiar.extension AS dichiar_extension, dichiar.iddichiar, dichiar.iddichiarkind AS dichiar_iddichiarkind, [dbo].registry.title AS registry_title, dichiar.idreg, dichiar.lt AS dichiar_lt, dichiar.lu AS dichiar_lu, dichiar.protanno AS dichiar_protanno, dichiar.protnumero AS dichiar_protnumero, dichiar_titolo.ct AS dichiar_titolo_ct, dichiar_titolo.cu AS dichiar_titolo_cu, dichiar_titolo.iddichiar AS dichiar_titolo_iddichiar, dichiar_titolo.idreg AS dichiar_titolo_idreg, [dbo].istattitolistudio.titolo AS istattitolistudio_titolo, [dbo].titolostudio.voto AS titolostudio_voto, [dbo].titolostudio.votosu AS titolostudio_votosu, [dbo].titolostudio.votolode AS titolostudio_votolode, [dbo].annoaccademico.aa AS annoaccademico_aa, dichiar_titolo.idtitolostudio AS dichiar_titolo_idtitolostudio, dichiar_titolo.lt AS dichiar_titolo_lt, dichiar_titolo.lu AS dichiar_titolo_lu, isnull('Studente: ' + [dbo].registry.title + '; ','') + ' ' + isnull('Titolo di studio Titolo ISTAT: ' + [dbo].istattitolistudio.titolo + '; ','') + ' ' + isnull('Titolo di studio: ' + CAST( [dbo].titolostudio.voto AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Titolo di studio: ' + CAST( [dbo].titolostudio.votosu AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Titolo di studio: ' + [dbo].titolostudio.votolode + '; ','') + ' ' + isnull('Codice Anno accademco: ' + [dbo].annoaccademico.aa + '; ','') as dropdown_title FROM [dbo].dichiar WITH (NOLOCK)  INNER JOIN dichiar_titolo WITH (NOLOCK) ON dichiar.iddichiar = dichiar_titolo.iddichiar AND dichiar.idreg = dichiar_titolo.idreg LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON dichiar.idreg = [dbo].registry.idreg LEFT OUTER JOIN [dbo].titolostudio WITH (NOLOCK) ON dichiar_titolo.idtitolostudio = [dbo].titolostudio.idtitolostudio LEFT OUTER JOIN [dbo].istattitolistudio WITH (NOLOCK) ON titolostudio.idistattitolistudio = [dbo].istattitolistudio.idistattitolistudio LEFT OUTER JOIN [dbo].annoaccademico WITH (NOLOCK) ON titolostudio.aa = [dbo].annoaccademico.aa WHERE  dichiar.iddichiar IS NOT NULL  AND dichiar.iddichiarkind = 1 AND dichiar.idreg IS NOT NULL  AND dichiar_titolo.iddichiar IS NOT NULL  AND dichiar_titolo.idreg IS NOT NULL 
GO

