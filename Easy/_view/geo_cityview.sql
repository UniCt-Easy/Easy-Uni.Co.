
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_cityview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_cityview]
GO


/*Pino Rana, elaborazione del 10/08/2005 15:18:07
 Inserire la CREATE VIEW qui--
*/
-- setuser 'amm'
-- select * from geo_cityview
CREATE  VIEW [DBO].geo_cityview
AS
SELECT     geo_city.idcity, geo_city.title, geo_city.oldcity, geo_city.newcity, geo_city.start, geo_city.stop, geo_country.idcountry, 
                      geo_country.province AS provincecode, geo_country.title AS country, geo_country.oldcountry, geo_country.newcountry, 
                      geo_country.start AS countrydatestart, geo_country.stop AS countrydatestop, geo_region.idregion, geo_region.title AS region, 
                      geo_region.start AS regiondatestart, geo_region.stop AS regiondatestop, geo_region.oldregion, geo_region.newregion, 
                      geo_nation.idnation, geo_nation.idcontinent, geo_nation.title AS nation, geo_nation.start AS nationdatestart, 
                      geo_nation.stop AS nationdatestop, geo_nation.oldnation, geo_nation.newnation
FROM         geo_city LEFT OUTER  JOIN
                      geo_country ON geo_city.idcountry = geo_country.idcountry LEFT OUTER JOIN
                      geo_region ON geo_country.idregion = geo_region.idregion LEFT OUTER JOIN
                      geo_nation ON geo_region.idnation = geo_nation.idnation



GO
