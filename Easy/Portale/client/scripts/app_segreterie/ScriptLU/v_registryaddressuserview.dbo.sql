
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


-- CREAZIONE VISTA registryaddressuserview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryaddressuserview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryaddressuserview]
GO

CREATE VIEW [dbo].[registryaddressuserview] AS 
SELECT CASE WHEN registryaddress.active = 'S' THEN 'Si' WHEN registryaddress.active = 'N' THEN 'No' END AS registryaddress_active, registryaddress.address, registryaddress.annotations AS registryaddress_annotations, registryaddress.cap AS registryaddress_cap, registryaddress.ct AS registryaddress_ct, registryaddress.cu AS registryaddress_cu,CASE WHEN registryaddress.flagforeign = 'S' THEN 'Si' WHEN registryaddress.flagforeign = 'N' THEN 'No' END AS registryaddress_flagforeign,
 [dbo].address.description AS address_description, registryaddress.idaddresskind,
 [dbo].geo_city.title AS geo_city_title, registryaddress.idcity, registryaddress.idnation AS registryaddress_idnation, registryaddress.idreg, registryaddress.location AS registryaddress_location, registryaddress.lt AS registryaddress_lt, registryaddress.lu AS registryaddress_lu, registryaddress.officename AS registryaddress_officename, registryaddress.recipientagency AS registryaddress_recipientagency, registryaddress.start, registryaddress.stop AS registryaddress_stop,
 isnull('Indirizzo: ' + registryaddress.address + '; ','') + ' ' + isnull('CAP: ' + registryaddress.cap + '; ','') + ' ' + isnull('Comune: ' + [dbo].geo_city.title + '; ','') as dropdown_title
FROM [dbo].registryaddress WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].address WITH (NOLOCK) ON registryaddress.idaddresskind = [dbo].address.idaddress
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registryaddress.idcity = [dbo].geo_city.idcity
WHERE  registryaddress.idaddresskind IS NOT NULL  AND registryaddress.idreg IS NOT NULL  AND registryaddress.start IS NOT NULL 
GO

