
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


-- CREAZIONE VISTA auladefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[auladefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[auladefaultview]
GO

CREATE VIEW [dbo].[auladefaultview] AS 
SELECT  aula.address AS aula_address, aula.cap AS aula_cap, aula.capienza AS aula_capienza, aula.capienzadis AS aula_capienzadis, aula.code AS aula_code, aula.ct AS aula_ct, aula.cu AS aula_cu, aula.dotazioni AS aula_dotazioni, aula.idaula,
 [dbo].aulakind.title AS aulakind_title, aula.idaulakind AS aula_idaulakind,
 [dbo].geo_city.title AS geo_city_title, aula.idcity,
 [dbo].edificio.title AS edificio_title, aula.idedificio,
 [dbo].geo_nation.title AS geo_nation_title, aula.idnation,
 [dbo].sede.title AS sede_title, aula.idsede,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, aula.idstruttura, aula.latitude AS aula_latitude, aula.location AS aula_location, aula.longitude AS aula_longitude, aula.lt AS aula_lt, aula.lu AS aula_lu, aula.title,
 isnull('Denominazione: ' + aula.title + '; ','') as dropdown_title
FROM [dbo].aula WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].aulakind WITH (NOLOCK) ON aula.idaulakind = [dbo].aulakind.idaulakind
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON aula.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].edificio WITH (NOLOCK) ON aula.idedificio = [dbo].edificio.idedificio
LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON aula.idnation = [dbo].geo_nation.idnation
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON aula.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON aula.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  aula.idaula IS NOT NULL  AND aula.idedificio IS NOT NULL  AND aula.idsede IS NOT NULL 
GO

