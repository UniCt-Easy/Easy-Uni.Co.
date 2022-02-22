
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


-- CREAZIONE VISTA afferenzastruview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[afferenzastruview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[afferenzastruview]
GO

CREATE VIEW [dbo].[afferenzastruview] AS 
SELECT  afferenza.ct AS afferenza_ct, afferenza.cu AS afferenza_cu, afferenza.idafferenza,
 [dbo].mansionekind.title AS mansionekind_title, afferenza.idmansionekind AS afferenza_idmansionekind,
 [dbo].registry.title AS registry_title, afferenza.idreg,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, afferenza.idstruttura, afferenza.lt AS afferenza_lt, afferenza.lu AS afferenza_lu, afferenza.start AS afferenza_start, afferenza.stop AS afferenza_stop,
 isnull('Struttura: ' + [dbo].struttura.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, afferenza.start, 103),'') + ' ' + isnull('Tipologia Tipo: ' + [dbo].strutturakind.title + '; ','') + ' ' + isnull('al ' + CONVERT(VARCHAR, afferenza.stop, 103),'') as dropdown_title
FROM [dbo].afferenza WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].mansionekind WITH (NOLOCK) ON afferenza.idmansionekind = [dbo].mansionekind.idmansionekind
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON afferenza.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON afferenza.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  afferenza.idafferenza IS NOT NULL  AND afferenza.idreg IS NOT NULL  AND afferenza.idstruttura IS NOT NULL 
GO

