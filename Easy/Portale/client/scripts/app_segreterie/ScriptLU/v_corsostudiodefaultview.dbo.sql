
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


-- CREAZIONE VISTA corsostudiodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudiodefaultview]
GO

CREATE VIEW [dbo].[corsostudiodefaultview] AS 
SELECT CASE WHEN corsostudio.almalaureasurvey = 'S' THEN 'Si' WHEN corsostudio.almalaureasurvey = 'N' THEN 'No' END AS corsostudio_almalaureasurvey, corsostudio.annoistituz AS corsostudio_annoistituz, corsostudio.basevoto AS corsostudio_basevoto, corsostudio.codice AS corsostudio_codice, corsostudio.codicemiur AS corsostudio_codicemiur, corsostudio.codicemiurlungo AS corsostudio_codicemiurlungo, corsostudio.crediti AS corsostudio_crediti, corsostudio.ct AS corsostudio_ct, corsostudio.cu AS corsostudio_cu, corsostudio.durata AS corsostudio_durata, corsostudio.idcorsostudio,
 [dbo].corsostudiokind.title AS corsostudiokind_title, corsostudio.idcorsostudiokind AS corsostudio_idcorsostudiokind,
 [dbo].corsostudiolivello.title AS corsostudiolivello_title, corsostudio.idcorsostudiolivello,
 [dbo].corsostudionorma.title AS corsostudionorma_title, corsostudio.idcorsostudionorma,
 [dbo].duratakind.title AS duratakind_title, corsostudio.idduratakind AS corsostudio_idduratakind,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, corsostudio.idstruttura, corsostudio.lt AS corsostudio_lt, corsostudio.lu AS corsostudio_lu, corsostudio.obbform AS corsostudio_obbform, corsostudio.sboccocc AS corsostudio_sboccocc, corsostudio.title, corsostudio.title_en AS corsostudio_title_en,
 isnull('Denominazione: ' + corsostudio.title + '; ','') + ' ' + isnull('Anno accademico di istituzione: ' + CAST( corsostudio.annoistituz AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].corsostudio WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudiokind WITH (NOLOCK) ON corsostudio.idcorsostudiokind = [dbo].corsostudiokind.idcorsostudiokind
LEFT OUTER JOIN [dbo].corsostudiolivello WITH (NOLOCK) ON corsostudio.idcorsostudiolivello = [dbo].corsostudiolivello.idcorsostudiolivello
LEFT OUTER JOIN [dbo].corsostudionorma WITH (NOLOCK) ON corsostudio.idcorsostudionorma = [dbo].corsostudionorma.idcorsostudionorma
LEFT OUTER JOIN [dbo].duratakind WITH (NOLOCK) ON corsostudio.idduratakind = [dbo].duratakind.idduratakind
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON corsostudio.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  corsostudio.idcorsostudio IS NOT NULL  AND corsostudio.idcorsostudiokind  not in (12, 13, 2)
GO

