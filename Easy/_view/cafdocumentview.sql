
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


-- CREAZIONE VISTA cafdocumentview
IF EXISTS(select * from sysobjects where id = object_id(N'[cafdocumentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [cafdocumentview]
GO


 

CREATE VIEW [cafdocumentview]
(
	idcafdocument,
	idcon,
	ycon,
	ncon,
	idreg,
	registry,
	ayear,
	cafdocumentkind,
	docdate,
	citytaxtorefundhusband,
	citytaxtorefund,
	citytaxtoretainhusband,
	citytaxtoretain,
	regionaltaxtorefundhusband,
	regionaltaxtorefund,
	regionaltaxtoretainhusband,
	regionaltaxtoretain,
	idcity,
	citycode,
	idfiscaltaxregion,
	fiscaltaxregion,
	irpeftorefund,
	irpeftoretain,
	startmonth,
	monthfirstinstalment,
	monthsecondinstalment,
	ratequantity,
	nquotafirstinstalment,
	nquotasecondinstalment,
	firstrateadvance,
	separatedincomehusband,
	separatedincome,
	secondrateadvance,
	citytaxaccount,
	citytaxaccounthusband,
	idf24ep,
	idunifiedcafdocument,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
cafdocument.idcafdocument,
cafdocument.idcon,
parasubcontract.ycon,
parasubcontract.ncon,
parasubcontract.idreg,
registry.title,
cafdocument.ayear,
CASE cafdocumentkind
	WHEN 'O' THEN 'Ordinaria'
	WHEN 'I' THEN 'Integrativa'
	WHEN 'R' THEN 'Rettificativa'
END,
docdate,
cafdocument.citytaxtorefundhusband,
cafdocument.citytaxtorefund,
cafdocument.citytaxtoretainhusband,
cafdocument.citytaxtoretain,
cafdocument.regionaltaxtorefundhusband,
cafdocument.regionaltaxtorefund,
cafdocument.regionaltaxtoretainhusband,
cafdocument.regionaltaxtoretain,
cafdocument.idcity,
A.value,
cafdocument.idfiscaltaxregion,
F.title,
cafdocument.irpeftorefund,
cafdocument.irpeftoretain,
cafdocument.startmonth,
cafdocument.monthfirstinstalment,
cafdocument.monthsecondinstalment,
cafdocument.ratequantity,
cafdocument.nquotafirstinstalment,
cafdocument.nquotasecondinstalment,
cafdocument.firstrateadvance,
cafdocument.separatedincomehusband,
cafdocument.separatedincome,
cafdocument.secondrateadvance,
cafdocument.citytaxaccount,
cafdocument.citytaxaccounthusband,
cafdocument.idf24ep,
cafdocument.idunifiedcafdocument,
cafdocument.ct,
cafdocument.cu,
cafdocument.lt,
cafdocument.lu
FROM cafdocument
JOIN parasubcontract
ON parasubcontract.idcon = cafdocument.idcon
JOIN registry
ON registry.idreg = parasubcontract.idreg
LEFT OUTER JOIN geo_city_agencyview A
	ON A.idcity = cafdocument.idcity
	AND A.idagency = 1
	AND A.idcode = 1
	AND A.version = 1
LEFT OUTER JOIN fiscaltaxregion F
	ON F.idfiscaltaxregion = cafdocument.idfiscaltaxregion





GO

 

