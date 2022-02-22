
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


-- CREAZIONE VISTA titolostudiodocentiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[titolostudiodocentiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[titolostudiodocentiview]
GO



CREATE VIEW [dbo].[titolostudiodocentiview] AS SELECT  titolostudio.aa,CASE WHEN titolostudio.conseguito = 'S' THEN 'Si' WHEN titolostudio.conseguito = 'N' THEN 'No' END AS titolostudio_conseguito, titolostudio.ct AS titolostudio_ct, titolostudio.cu AS titolostudio_cu, titolostudio.data AS titolostudio_data, titolostudio.giudizio AS titolostudio_giudizio, [dbo].attach.filename AS attach_filename, titolostudio.idattach, [dbo].istattitolistudio.titolo AS istattitolistudio_titolo, titolostudio.idistattitolistudio, titolostudio.idreg, registry_registry_istitutiistituti.title AS registryistituti_title, titolostudio.idreg_istituti, titolostudio.idtitolostudio, titolostudio.lt AS titolostudio_lt, titolostudio.lu AS titolostudio_lu, titolostudio.voto AS titolostudio_voto,CASE WHEN titolostudio.votolode = 'S' THEN 'Si' WHEN titolostudio.votolode = 'N' THEN 'No' END AS titolostudio_votolode, titolostudio.votosu AS titolostudio_votosu, isnull('Titolo : ' + [dbo].istattitolistudio.titolo + '; ','') + ' ' + isnull('Voto : ' + CAST( titolostudio.voto AS NVARCHAR(64)) + '; ','') + ' ' + isnull('/ : ' + CAST( titolostudio.votosu AS NVARCHAR(64)) + '; ','') + ' ' + isnull('' + CASE WHEN titolostudio.votolode = 'S' THEN 'Lode' ELSE '' END,'') + ' ' + isnull('AA : ' + titolostudio.aa + '; ','') as dropdown_title FROM [dbo].titolostudio WITH (NOLOCK)  LEFT OUTER JOIN [dbo].attach WITH (NOLOCK) ON titolostudio.idattach = [dbo].attach.idattach LEFT OUTER JOIN [dbo].istattitolistudio WITH (NOLOCK) ON titolostudio.idistattitolistudio = [dbo].istattitolistudio.idistattitolistudio LEFT OUTER JOIN [dbo].registry_istituti AS registry_istitutiistituti WITH (NOLOCK) ON titolostudio.idreg_istituti = registry_istitutiistituti.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_istitutiistituti WITH (NOLOCK) ON registry_istitutiistituti.idreg = registry_registry_istitutiistituti.idreg WHERE  titolostudio.idreg IS NOT NULL  AND titolostudio.idtitolostudio IS NOT NULL 

GO

