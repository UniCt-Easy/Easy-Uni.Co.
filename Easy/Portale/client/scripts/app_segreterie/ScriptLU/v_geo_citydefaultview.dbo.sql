
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


-- CREAZIONE VISTA geo_citydefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_citydefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_citydefaultview]
GO

CREATE VIEW [dbo].[geo_citydefaultview] AS 
SELECT  geo_city.idcity,
 [dbo].geo_country.title AS geo_country_title, geo_city.idcountry, geo_city.lt AS geo_city_lt, geo_city.lu AS geo_city_lu,
 geo_city_1.title AS geo_city_1_title, geo_city.newcity,
 geo_city_2.title AS geo_city_2_title, geo_city.oldcity, geo_city.start AS geo_city_start, geo_city.stop AS geo_city_stop, geo_city.title,
 isnull('Denominazione: ' + geo_city.title + '; ','') as dropdown_title
FROM [dbo].geo_city WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].geo_country WITH (NOLOCK) ON geo_city.idcountry = [dbo].geo_country.idcountry
LEFT OUTER JOIN [dbo].geo_city AS geo_city_1 WITH (NOLOCK) ON geo_city.newcity = geo_city_1.idcity
LEFT OUTER JOIN [dbo].geo_city AS geo_city_2 WITH (NOLOCK) ON geo_city.oldcity = geo_city_2.idcity
WHERE  geo_city.idcity IS NOT NULL 
GO


-- GENERAZIONE DATI PER geo_citydefaultview --
