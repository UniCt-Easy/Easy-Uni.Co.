
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


-- CREAZIONE VISTA iscrizionestatoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[iscrizionestatoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[iscrizionestatoview]
GO

CREATE VIEW [dbo].[iscrizionestatoview] AS 
SELECT  iscrizione.aa, iscrizione.anno, iscrizione.ct AS iscrizione_ct, iscrizione.cu AS iscrizione_cu, iscrizione.data AS iscrizione_data, iscrizione.idcorsostudio, iscrizione.iddidprog, iscrizione.idiscrizione,
 [dbo].registry.title AS registry_title, iscrizione.idreg, iscrizione.lt AS iscrizione_lt, iscrizione.lu AS iscrizione_lu, iscrizione.matricola AS iscrizione_matricola,
 isnull('Anno di corso: ' + CAST( iscrizione.anno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Matricola: ' + iscrizione.matricola + '; ','') + ' ' + isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Anno accademico: ' +aa + '; ' + 'Sede: ' +CAST( idsede AS NVARCHAR(64)) from didprog x where x.iddidprog = iscrizione.iddidprog) + '; ','') + ' ' + isnull('Studente: ' + [dbo].registry.title + '; ','') + ' ' + isnull('Anno accademico: ' + iscrizione.aa + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, iscrizione.data, 103),'') as dropdown_title
FROM [dbo].iscrizione WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON iscrizione.idreg = [dbo].registry.idreg
WHERE  iscrizione.idcorsostudio IS NOT NULL  AND iscrizione.iddidprog IS NOT NULL  AND iscrizione.idiscrizione IS NOT NULL  AND iscrizione.idreg IS NOT NULL 
GO

