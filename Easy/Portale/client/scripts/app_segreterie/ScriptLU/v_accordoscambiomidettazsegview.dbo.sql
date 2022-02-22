
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


-- CREAZIONE VISTA accordoscambiomidettazsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accordoscambiomidettazsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accordoscambiomidettazsegview]
GO

CREATE VIEW [dbo].[accordoscambiomidettazsegview] AS 
SELECT  accordoscambiomidettaz.ct AS accordoscambiomidettaz_ct, accordoscambiomidettaz.cu AS accordoscambiomidettaz_cu, accordoscambiomidettaz.idaccordoscambiomi, accordoscambiomidettaz.idaccordoscambiomidettaz,
 registry_registry_aziendeaziende.title AS registryaziende_title, accordoscambiomidettaz.idreg_aziende, accordoscambiomidettaz.lt AS accordoscambiomidettaz_lt, accordoscambiomidettaz.lu AS accordoscambiomidettaz_lu, accordoscambiomidettaz.numstud AS accordoscambiomidettaz_numstud, accordoscambiomidettaz.stipula AS accordoscambiomidettaz_stipula, accordoscambiomidettaz.stop AS accordoscambiomidettaz_stop
FROM [dbo].accordoscambiomidettaz WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON accordoscambiomidettaz.idreg_aziende = registry_aziendeaziende.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_aziendeaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registry_registry_aziendeaziende.idreg
WHERE  accordoscambiomidettaz.idaccordoscambiomi IS NOT NULL  AND accordoscambiomidettaz.idaccordoscambiomidettaz IS NOT NULL  AND accordoscambiomidettaz.idreg_aziende IS NOT NULL 
GO

