
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


-- CREAZIONE VISTA praticasegistabbrview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[praticasegistabbrview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[praticasegistabbrview]
GO

CREATE VIEW [dbo].[praticasegistabbrview] AS 
SELECT  pratica.ct AS pratica_ct, pratica.cu AS pratica_cu, pratica.idcorsostudio,
 [dbo].dichiarkind.title AS dichiarkind_title, [dbo].dichiarkind.iddichiarkind AS dichiarkind_iddichiarkind, [dbo].dichiar.aa AS dichiar_aa, [dbo].dichiar.date AS dichiar_date, pratica.iddichiar, pratica.iddidprog, pratica.idiscrizione,
 iscrizionefrom.anno AS iscrizionefrom_anno, iscrizionefrom.iddidprog AS iscrizionefrom_iddidprog, iscrizionefrom.aa AS iscrizionefrom_aa, pratica.idiscrizione_from, pratica.idistanza, pratica.idistanzakind, pratica.idpratica, pratica.idreg,
 [dbo].statuskind.title AS statuskind_title, pratica.idstatuskind AS pratica_idstatuskind,
 [dbo].istattitolistudio.titolo AS istattitolistudio_titolo, [dbo].istattitolistudio.idistattitolistudio AS istattitolistudio_idistattitolistudio, [dbo].titolostudio.voto AS titolostudio_voto, [dbo].titolostudio.votosu AS titolostudio_votosu, [dbo].titolostudio.votolode AS titolostudio_votolode, [dbo].titolostudio.aa AS titolostudio_aa, pratica.idtitolostudio, pratica.lt AS pratica_lt, pratica.lu AS pratica_lu, pratica.protanno AS pratica_protanno, pratica.protnumero AS pratica_protnumero,
 isnull('Tipologia Tipologia: ' + [dbo].dichiarkind.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + CAST( [dbo].dichiarkind.iddichiarkind AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Titolo : ' + [dbo].istattitolistudio.titolo + '; ','') + ' ' + isnull('Titolo : ' + CAST( [dbo].istattitolistudio.idistattitolistudio AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].pratica WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].dichiar WITH (NOLOCK) ON pratica.iddichiar = [dbo].dichiar.iddichiar
LEFT OUTER JOIN [dbo].dichiarkind WITH (NOLOCK) ON dichiar.iddichiarkind = [dbo].dichiarkind.iddichiarkind
LEFT OUTER JOIN [dbo].iscrizione AS iscrizionefrom WITH (NOLOCK) ON pratica.idiscrizione_from = iscrizionefrom.idiscrizione
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON pratica.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].titolostudio WITH (NOLOCK) ON pratica.idtitolostudio = [dbo].titolostudio.idtitolostudio
LEFT OUTER JOIN [dbo].istattitolistudio WITH (NOLOCK) ON titolostudio.idistattitolistudio = [dbo].istattitolistudio.idistattitolistudio
WHERE  pratica.idcorsostudio IS NOT NULL  AND pratica.iddidprog IS NOT NULL  AND pratica.idiscrizione IS NOT NULL  AND pratica.idistanza IS NOT NULL  AND pratica.idistanzakind IS NOT NULL  AND pratica.idpratica IS NOT NULL  AND pratica.idreg IS NOT NULL 
GO

