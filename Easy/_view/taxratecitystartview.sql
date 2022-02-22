
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


-- CREAZIONE VISTA taxratecitystartview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxratecitystartview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[taxratecitystartview]
GO


--clear_table_info 'taxratecitystartview'
--setuser 'amm'
--select * from taxratecitystartview
CREATE   VIEW [DBO].[taxratecitystartview]
AS
SELECT DISTINCT 
a1.taxcode,
tax.taxref,
a1.idcity,
a1.idtaxratecitystart,
c1.title as city,
p1.idcountry,
p1.title as country,
a1.start,
a1.enforcement,
a1.annotations,
isnull(a1.taxablemin,t1.minamount) as taxablemin,
isnull(t1.minamount,a1.taxablemin) as min1,
t1.maxamount as max1,
t1.rate as rate1,
t2.minamount as min2,
t2.maxamount as max2,
t2.rate as rate2,
t3.minamount as min3,
t3.maxamount as max3,
t3.rate as rate3,
t4.minamount as min4,
t4.maxamount as max4,
t4.rate as rate4,
t5.minamount as min5,
t5.maxamount as max5,
t5.rate as rate5

FROM taxratecitystart a1
JOIN geo_city c1	ON a1.idcity = c1.idcity
JOIN geo_country p1	ON c1.idcountry = p1.idcountry
JOIN tax	ON tax.taxcode = a1.taxcode
left outer join taxratecitybracket t1 on t1.idcity=a1.idcity and t1.idtaxratecitystart=a1.idtaxratecitystart and t1.taxcode=a1.taxcode and t1.nbracket=1
left outer join taxratecitybracket t2 on t2.idcity=a1.idcity and t2.idtaxratecitystart=a1.idtaxratecitystart and t2.taxcode=a1.taxcode and t2.nbracket=2
left outer join taxratecitybracket t3 on t3.idcity=a1.idcity and t3.idtaxratecitystart=a1.idtaxratecitystart and t3.taxcode=a1.taxcode and t3.nbracket=3
left outer join taxratecitybracket t4 on t4.idcity=a1.idcity and t4.idtaxratecitystart=a1.idtaxratecitystart and t4.taxcode=a1.taxcode and t4.nbracket=4
left outer join taxratecitybracket t5 on t5.idcity=a1.idcity and t5.idtaxratecitystart=a1.idtaxratecitystart and t5.taxcode=a1.taxcode and t5.nbracket=5




GO
