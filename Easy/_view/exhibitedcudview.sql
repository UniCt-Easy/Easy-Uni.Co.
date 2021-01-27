
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


-- CREAZIONE VISTA exhibitedcudview
IF EXISTS(select * from sysobjects where id = object_id(N'[exhibitedcudview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [exhibitedcudview]
GO

 
CREATE  VIEW exhibitedcudview
(
	idcon,
	ycon,
	ncon,
	idexhibitedcud,
	cfotherdeputy,
	citytax_account,
	citytaxapplied,
	fiscalyear,
	flagignoreprevcud,
	inpsowed,
	inpsretained,
	irpefapplied,
	irpefsuspended,
	ndays,
	nmonths,
	regionaltaxapplied,
	start,
	stop,
	suspendedcitytax,
	suspendedregionaltax,
	taxablegross,
	taxablenet,
	taxablepension,
	transfermotive,
	idlinkedcon,
	ylinkedcon,
	nlinkedcon,
	idcity,
	city0101,
	provincecode0101,
	region0101,
	idfiscaltaxregion,
	fiscaltaxregion,
	irpefgross,
	earnings_based_abatements,
	totabatements,
	fiscalbonusapplied,
	fiscalbonusnotapplied,
	flagbonusaccredited,
	ct, cu, lt, lu
)
AS
SELECT
	E.idcon,
	P.ycon,
	P.ncon,
	E.idexhibitedcud,
	E.cfotherdeputy,
	E.citytax_account,
	E.citytaxapplied,
	E.fiscalyear,
	E.flagignoreprevcud,
	E.inpsowed,
	E.inpsretained,
	E.irpefapplied,
	E.irpefsuspended,
	E.ndays,
	E.nmonths,
	E.regionaltaxapplied,
	E.start,
	E.stop,
	E.suspendedcitytax,
	E.suspendedregionaltax,
	E.taxablegross,
	E.taxablenet,
	E.taxablepension,
	E.transfermotive,
	E.idlinkedcon,
	L.ycon,
	L.ncon,
	E.idcity,
	G0101.title,
	GC0101.province,
	GR0101.title,
	E.idfiscaltaxregion,
	F.title,
	E.irpefgross,
	E.earnings_based_abatements,
	E.totabatements,
	E.fiscalbonusapplied,
	E.fiscalbonusnotapplied,
	E.flagbonusaccredited,
	E.ct, E.cu, E.lt, E.lu
FROM exhibitedcud E
JOIN parasubcontract P
	ON P.idcon = E.idcon
LEFT OUTER JOIN parasubcontract L
	ON L.idcon = E.idlinkedcon
LEFT OUTER JOIN geo_city G0101
	ON G0101.idcity = E.idcity
LEFT OUTER JOIN geo_country GC0101
	ON GC0101.idcountry = G0101.idcountry
LEFT OUTER JOIN geo_region GR0101
	ON GR0101.idregion = GC0101.idregion
LEFT OUTER JOIN fiscaltaxregion F
	ON F.idfiscaltaxregion = E.idfiscaltaxregion
GO
 
