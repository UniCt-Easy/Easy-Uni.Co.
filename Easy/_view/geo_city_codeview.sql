
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


-- CREAZIONE VISTA geo_cityview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_city_codeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].geo_city_codeview
GO

--  select * from  geo_city_codeview where newcity is null and stop is null

CREATE  VIEW [DBO].geo_city_codeview
AS
SELECT     geo_city.idcity, geo_city.title, geo_city.oldcity, geo_city.newcity, geo_city.start, geo_city.stop, 
						geo_country.idcountry, geo_region.idregion, geo_nation.idnation, geo_nation.idcontinent, 
                      geo_country.province AS provincecode, 
					  geo_country.title AS country, 
					  geo_region.title AS region,                       
                      geo_nation.title AS nation,                       
					  g_cat.value as 'catastale',
					  g_naz.value as 'nazionale',
					  g_istat.value as 'istat',
					  g_cap.value as 'cap',
					  g_old.title as 'precedente',
					  g_new.title as 'successiva'

FROM         geo_city 
LEFT OUTER  JOIN
                      geo_country ON geo_city.idcountry = geo_country.idcountry LEFT OUTER JOIN
                      geo_region ON geo_country.idregion = geo_region.idregion LEFT OUTER JOIN
                      geo_nation ON geo_region.idnation = geo_nation.idnation
LEFT OUTER  JOIN geo_city_agency g_cat on g_cat.idcity=geo_city.idcity and g_cat.idagency=1 and g_cat.idcode=2
		and g_cat.version =  (select max(gg.version) from geo_city_agency gg where gg.idcity=geo_city.idcity and gg.idagency=1 and gg.idcode=2) 
LEFT OUTER  JOIN geo_city_agency g_naz on g_naz.idcity=geo_city.idcity and g_naz.idagency=1 and g_naz.idcode=1
LEFT OUTER  JOIN geo_city_agency g_istat on g_istat.idcity=geo_city.idcity and g_istat.idagency=2 and g_istat.idcode=1
				and g_istat.version =  (select max(gg.version) from geo_city_agency gg where gg.idcity=geo_city.idcity and gg.idagency=2 and gg.idcode=1) 
LEFT OUTER  JOIN geo_city_agency g_cap on g_cap.idcity=geo_city.idcity and g_cap.idagency=3 and g_cap.idcode=1 
				and g_cap.version =  (select max(gg.version) from geo_city_agency gg where gg.idcity=geo_city.idcity and gg.idagency=3 and gg.idcode=1) 
							
LEFT OUTER  JOIN geo_city g_new on g_new.idcity=geo_city.newcity 
LEFT OUTER  JOIN geo_city g_old on g_old.idcity=geo_city.oldcity 



GO
