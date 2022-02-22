
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


-- CREAZIONE VISTA edificioseg_childview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[edificioseg_childview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[edificioseg_childview]
GO



CREATE VIEW [dbo].[edificioseg_childview] AS SELECT  edificio.address AS edificio_address, edificio.cap AS edificio_cap, edificio.code AS edificio_code, edificio.ct AS edificio_ct, edificio.cu AS edificio_cu, [dbo].geo_city.title AS geo_city_title, edificio.idcity, edificio.idedificio, [dbo].geo_nation.title AS geo_nation_title, edificio.idnation, edificio.idsede, edificio.latitude AS edificio_latitude, edificio.location AS edificio_location, edificio.longitude AS edificio_longitude, edificio.lt AS edificio_lt, edificio.lu AS edificio_lu, edificio.title, isnull('Denominazione: ' + edificio.title + '; ','') as dropdown_title FROM [dbo].edificio WITH (NOLOCK)  LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON edificio.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON edificio.idnation = [dbo].geo_nation.idnation WHERE  edificio.idedificio IS NOT NULL  AND edificio.idsede IS NOT NULL 

GO

