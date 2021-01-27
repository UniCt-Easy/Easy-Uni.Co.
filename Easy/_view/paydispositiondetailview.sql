
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


-- CREAZIONE VISTA paydispositiondetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[paydispositiondetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [paydispositiondetailview]
GO

 
CREATE VIEW [paydispositiondetailview]
(
	idpaydisposition,
	iddetail,
	ayear,
	maindescription,
	mainmotive,
	surname,
	forename,
	title,
	gender,
	birthdate,
	flaghuman,
	idcity,
	city,
	provincecode,
	idnation,
	nation,
	cf,
	p_iva,
	address,
	location,
	province,
	cap,
	abi,
	bankdescription,
	cab,
	cabdescription,
	motive,
	email,
	amount,
	paymentcode,
	cc,
	cin,
	iban,
	kpay,
	ypay,
	npay,
	kpaydett,
	ypaydett,
	npaydett,
	academicyear,
	degreekind,
	degreecode,
	flagtaxrefund,
	calendaryear,
	idexp,
	ymov,
	nmov,
	nphase,
	phase,
	flag,
	idchargehandling,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	D.idpaydisposition,
	D.iddetail,
	P.ayear,
	P.description,
	P.motive,
	D.surname,
	D.forename,
	D.title,
	D.gender,
	D.birthdate,
	flaghuman,
	D.idcity,
	GC.title,
	GCO.province,
	D.idnation,
	GN.title,
	D.cf,
	D.p_iva,
	D.address,
	D.location,
	D.province,
	D.cap,
	D.abi,
	B.description,
	D.cab,
	C.description,
	D.motive,
	D.email,
	D.amount,
	D.paymentcode,
	D.cc,
	D.cin,
	D.iban,
	M.kpay,
	M.ypay,
	M.npay,
	M1.kpay,
	M1.ypay,
	M1.npay,
	D.academicyear,
	D.degreekind,
	D.degreecode,
	D.flagtaxrefund,
	D.calendaryear,
	D.idexp,
	E.ymov,
	E.nmov,
	E.nphase,
	F.description,
	D.flag,
	D.idchargehandling,
	D.ct,
	D.cu,
	D.lt,
	D.lu
FROM paydispositiondetail D
JOIN paydisposition P
	ON P.idpaydisposition = D.idpaydisposition
LEFT OUTER JOIN geo_city GC
	ON GC.idcity = D.idcity
LEFT OUTER JOIN geo_country GCO
	ON GCO.idcountry = GC.idcountry
LEFT OUTER JOIN geo_nation GN
	ON GN.idnation = D.idnation
LEFT OUTER JOIN bank B
	ON B.idbank = D.abi
LEFT OUTER JOIN cab C
	ON C.idbank = D.abi
	AND C.idcab = D.cab
LEFT OUTER JOIN expense E
	ON E.idexp = D.idexp
LEFT OUTER JOIN expensephase F
	ON E.nphase = F.nphase
LEFT OUTER JOIN expenselast EL
	ON E.idexp = EL.idexp
LEFT OUTER JOIN payment M
	ON M.kpay = P.kpay
LEFT OUTER JOIN payment M1
	ON M1.kpay = EL.kpay


GO


 
