
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


-- CREAZIONE VISTA sedeseg_childview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sedeseg_childview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sedeseg_childview]
GO



CREATE VIEW [dbo].[sedeseg_childview] AS SELECT  sede.address AS sede_address, sede.annotations AS sede_annotations, sede.cap AS sede_cap, sede.ct AS sede_ct, sede.cu AS sede_cu, [dbo].geo_city.title AS geo_city_title, sede.idcity, [dbo].geo_nation.title AS geo_nation_title, sede.idnation, sede.idreg AS sede_idreg, sede.idsede, sede.idsedemiur AS sede_idsedemiur, sede.latitude AS sede_latitude, sede.longitude AS sede_longitude, sede.lt AS sede_lt, sede.lu AS sede_lu, sede.title, isnull('Denominazione: ' + sede.title + '; ','') as dropdown_title FROM [dbo].sede WITH (NOLOCK)  LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON sede.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON sede.idnation = [dbo].geo_nation.idnation WHERE  sede.idsede IS NOT NULL 

GO

