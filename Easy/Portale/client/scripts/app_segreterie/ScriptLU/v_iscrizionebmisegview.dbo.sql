
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


-- CREAZIONE VISTA iscrizionebmisegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[iscrizionebmisegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[iscrizionebmisegview]
GO

CREATE VIEW [dbo].[iscrizionebmisegview] AS 
SELECT  iscrizionebmi.ct AS iscrizionebmi_ct, iscrizionebmi.cu AS iscrizionebmi_cu, iscrizionebmi.data AS iscrizionebmi_data, iscrizionebmi.idbandomi,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, iscrizionebmi.idiscrizione, iscrizionebmi.idiscrizionebmi,
 [dbo].registry.title AS registry_title, iscrizionebmi.idreg, iscrizionebmi.lt AS iscrizionebmi_lt, iscrizionebmi.lu AS iscrizionebmi_lu,(select top 1 idcefr_compasc 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_compasc,
						(select top 1 idcefr_complett 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_complett,
						(select top 1 idcefr_parlinter 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_parlinter,
						(select top 1 idcefr_parlprod 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_parlprod,
						(select top 1 idcefr_scritto 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_scritto,
						(select top 1 idnation 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as idnation,
 isnull('Identificativo: ' + [dbo].registry.title + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, iscrizionebmi.data, 103),'') + ' ' + isnull('Iscrizione: ' + CAST( [dbo].iscrizione.anno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Iscrizione: ' + CAST( [dbo].iscrizione.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Iscrizione: ' + [dbo].iscrizione.aa + '; ','') as dropdown_title
FROM [dbo].iscrizionebmi WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON iscrizionebmi.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON iscrizionebmi.idreg = [dbo].registry.idreg
WHERE  iscrizionebmi.idbandomi IS NOT NULL  AND iscrizionebmi.idiscrizionebmi IS NOT NULL  AND iscrizionebmi.idreg IS NOT NULL 
GO

