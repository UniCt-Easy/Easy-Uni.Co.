
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


-- CREAZIONE VISTA praticasegistpassview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[praticasegistpassview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[praticasegistpassview]
GO

CREATE VIEW [dbo].[praticasegistpassview] AS 
SELECT  pratica.ct AS pratica_ct, pratica.cu AS pratica_cu, pratica.idcorsostudio,
 [dbo].dichiar.aa AS dichiar_aa, [dbo].dichiar.extension AS dichiar_extension, pratica.iddichiar, pratica.iddidprog,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, pratica.idiscrizione,
 iscrizione_pratica.anno AS iscrizione_pratica_anno, iscrizione_pratica.iddidprog AS iscrizione_pratica_iddidprog, iscrizione_pratica.aa AS iscrizione_pratica_aa, pratica.idiscrizione_from, pratica.idistanza, pratica.idistanzakind, pratica.idpratica, pratica.idreg,
 [dbo].statuskind.title AS statuskind_title, pratica.idstatuskind AS pratica_idstatuskind,
 [dbo].istattitolistudio.titolo AS istattitolistudio_titolo, [dbo].istattitolistudio.idistattitolistudio AS istattitolistudio_idistattitolistudio, [dbo].titolostudio.voto AS titolostudio_voto, [dbo].titolostudio.votosu AS titolostudio_votosu, [dbo].titolostudio.votolode AS titolostudio_votolode, [dbo].titolostudio.aa AS titolostudio_aa, pratica.idtitolostudio, pratica.lt AS pratica_lt, pratica.lu AS pratica_lu, pratica.protanno AS pratica_protanno, pratica.protnumero AS pratica_protnumero,
 isnull('Titolo : ' + [dbo].istattitolistudio.titolo + '; ','') + ' ' + isnull('Titolo : ' + CAST( [dbo].istattitolistudio.idistattitolistudio AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].pratica WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].dichiar WITH (NOLOCK) ON pratica.iddichiar = [dbo].dichiar.iddichiar
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON pratica.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].iscrizione AS iscrizione_pratica WITH (NOLOCK) ON pratica.idiscrizione_from = iscrizione_pratica.idiscrizione
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON pratica.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].titolostudio WITH (NOLOCK) ON pratica.idtitolostudio = [dbo].titolostudio.idtitolostudio
LEFT OUTER JOIN [dbo].istattitolistudio WITH (NOLOCK) ON titolostudio.idistattitolistudio = [dbo].istattitolistudio.idistattitolistudio
WHERE  pratica.idcorsostudio IS NOT NULL  AND pratica.iddidprog IS NOT NULL  AND pratica.idiscrizione IS NOT NULL  AND pratica.idistanza IS NOT NULL  AND pratica.idistanzakind IS NOT NULL  AND pratica.idpratica IS NOT NULL  AND pratica.idreg IS NOT NULL 
GO

