
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


-- CREAZIONE VISTA esonerotitolostudioview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[esonerotitolostudioview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[esonerotitolostudioview]
GO

CREATE VIEW [dbo].[esonerotitolostudioview] AS 
SELECT  esonero.aa,CASE WHEN esonero.applunavolta = 'S' THEN 'Si' WHEN esonero.applunavolta = 'N' THEN 'No' END AS esonero_applunavolta, esonero.ct AS esonero_ct, esonero.cu AS esonero_cu, esonero.description AS esonero_description,
 [dbo].costoscontodef.title AS costoscontodef_title, esonero.idcostoscontodef, esonero.idesonero,
 [dbo].esoneroanskind.title AS esoneroanskind_title, [dbo].esoneroanskind.description AS esoneroanskind_description, esonero.idesoneroanskind AS esonero_idesoneroanskind, esonero.lt AS esonero_lt, esonero.lu AS esonero_lu,CASE WHEN esonero.retroattivo = 'S' THEN 'Si' WHEN esonero.retroattivo = 'N' THEN 'No' END AS esonero_retroattivo,CASE WHEN esonero.soloconisee = 'S' THEN 'Si' WHEN esonero.soloconisee = 'N' THEN 'No' END AS esonero_soloconisee, esonero.title,CASE WHEN esonero_titolostudio.conseguitoincorso = 'S' THEN 'Si' WHEN esonero_titolostudio.conseguitoincorso = 'N' THEN 'No' END AS esonero_titolostudio_conseguitoincorso, esonero_titolostudio.ct AS esonero_titolostudio_ct, esonero_titolostudio.cu AS esonero_titolostudio_cu, esonero_titolostudio.dataconstutticf AS esonero_titolostudio_dataconstutticf, esonero_titolostudio.datalaurea AS esonero_titolostudio_datalaurea, esonero_titolostudio.idesonero AS esonero_titolostudio_idesonero,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, esonero_titolostudio.idstruttura, esonero_titolostudio.lt AS esonero_titolostudio_lt, esonero_titolostudio.lu AS esonero_titolostudio_lu,CASE WHEN esonero_titolostudio.nellistituto = 'S' THEN 'Si' WHEN esonero_titolostudio.nellistituto = 'N' THEN 'No' END AS esonero_titolostudio_nellistituto,CASE WHEN esonero_titolostudio.noabbr = 'S' THEN 'Si' WHEN esonero_titolostudio.noabbr = 'N' THEN 'No' END AS esonero_titolostudio_noabbr,CASE WHEN esonero_titolostudio.noparttime = 'S' THEN 'Si' WHEN esonero_titolostudio.noparttime = 'N' THEN 'No' END AS esonero_titolostudio_noparttime, esonero_titolostudio.votomin AS esonero_titolostudio_votomin,
 isnull('Denominazione: ' + esonero.title + '; ','') as dropdown_title
FROM [dbo].esonero WITH (NOLOCK) 
INNER JOIN esonero_titolostudio WITH (NOLOCK) ON esonero.idesonero = esonero_titolostudio.idesonero
LEFT OUTER JOIN [dbo].costoscontodef WITH (NOLOCK) ON esonero.idcostoscontodef = [dbo].costoscontodef.idcostoscontodef
LEFT OUTER JOIN [dbo].esoneroanskind WITH (NOLOCK) ON esonero.idesoneroanskind = [dbo].esoneroanskind.idesoneroanskind
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON esonero_titolostudio.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  esonero.idesonero IS NOT NULL  AND esonero_titolostudio.idesonero IS NOT NULL 
GO

