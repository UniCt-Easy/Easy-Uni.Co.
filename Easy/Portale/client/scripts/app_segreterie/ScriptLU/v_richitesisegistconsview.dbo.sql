
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


-- CREAZIONE VISTA richitesisegistconsview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[richitesisegistconsview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[richitesisegistconsview]
GO

CREATE VIEW [dbo].[richitesisegistconsview] AS 
SELECT CASE WHEN richitesi.accettata = 'S' THEN 'Si' WHEN richitesi.accettata = 'N' THEN 'No' END AS richitesi_accettata, richitesi.ct AS richitesi_ct, richitesi.cu AS richitesi_cu, richitesi.idistanza, richitesi.idreg,
 registry_registry_docentidocenti.title AS registrydocenti_title, richitesi.idreg_docenti, richitesi.idrichitesi, richitesi.lt AS richitesi_lt, richitesi.lu AS richitesi_lu,(select top 1 aa 
						from dbo.tesi 
						where dbo.tesi.idreg = richitesi.idrichitesi
						 order by tesi.title desc) as tesi_aa,
						(select top 1 abstract 
						from dbo.tesi 
						where dbo.tesi.idreg = richitesi.idrichitesi
						 order by tesi.title desc) as tesi_abstract,
						(select top 1 abstract_en 
						from dbo.tesi 
						where dbo.tesi.idreg = richitesi.idrichitesi
						 order by tesi.title desc) as tesi_abstract_en,
						(select top 1 CASE WHEN tesi.filestatus = 'S' THEN 'Si' WHEN tesi.filestatus = 'N' THEN 'No' END AS tesi_filestatus 
						from dbo.tesi 
						where dbo.tesi.idreg = richitesi.idrichitesi
						 order by tesi.title desc) as tesi_filestatus,
						(select top 1 idattach 
						from dbo.tesi 
						where dbo.tesi.idreg = richitesi.idrichitesi
						 order by tesi.title desc) as idattach,
						(select top 1 idinsegn 
						from dbo.tesi 
						where dbo.tesi.idreg = richitesi.idrichitesi
						 order by tesi.title desc) as idinsegn,
						(select top 1 idrichitesi 
						from dbo.tesi 
						where dbo.tesi.idreg = richitesi.idrichitesi
						 order by tesi.title desc) as tesi_idrichitesi,
						(select top 1 title 
						from dbo.tesi 
						where dbo.tesi.idreg = richitesi.idrichitesi
						 order by tesi.title desc) as tesi_title,
						(select top 1 title_en 
						from dbo.tesi 
						where dbo.tesi.idreg = richitesi.idrichitesi
						 order by tesi.title desc) as tesi_title_en
FROM [dbo].richitesi WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry_docenti AS registry_docentidocenti WITH (NOLOCK) ON richitesi.idreg_docenti = registry_docentidocenti.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_docentidocenti WITH (NOLOCK) ON registry_docentidocenti.idreg = registry_registry_docentidocenti.idreg
WHERE  richitesi.idistanza IS NOT NULL  AND richitesi.idreg IS NOT NULL  AND richitesi.idrichitesi IS NOT NULL 
GO

