
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


-- CREAZIONE VISTA expenseitinerationview
IF EXISTS(select * from sysobjects where id = object_id(N'[expenseitinerationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenseitinerationview]
GO


--setuser 'amm'
--clear_table_info 'expenseitinerationview'
--select * from expenseitinerationview



CREATE   VIEW [expenseitinerationview]
(
	iditineration,
	yitineration,
	nitineration,
	movkind,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	formerymov,
	formernmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	autokind,
	idpayment,
	totflag,
	flagarrear,
	expiration,
	adate,
	cu, ct, lu, lt,
	idaccmotive, 
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	expenseitineration.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	expenseitineration.movkind,
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	former.ymov,
	former.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,	
	upb.codeupb,	
	upb.title,	
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	expenselast.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expense.autokind,
	expense.idpayment,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.expiration,
	expense.adate,
	expenseitineration.cu,
	expenseitineration.ct,
	expenseitineration.lu,
	expenseitineration.lt,
	itineration.idaccmotive,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05
FROM expenseitineration	
JOIN itineration		ON itineration.iditineration = expenseitineration.iditineration
JOIN config				ON config.ayear=itineration.yitineration 
JOIN expense			ON expense.idexp = expenseitineration.idexp
JOIN expensephase		ON expensephase.nphase = expense.nphase
JOIN expenseyear		ON expenseyear.idexp = expense.idexp
JOIN expensetotal		ON expensetotal.idexp = expenseyear.idexp
								AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense 	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expense former			ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expenseyear expenseyear_starting	ON expenseyear_starting.idexp = expense.idexp
										AND expenseyear_starting.ayear = expense.ymov
LEFT OUTER JOIN expenselast			ON expense.idexp = expenselast.idexp
LEFT OUTER JOIN fin					ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb					on upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry			ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager				ON manager.idman = expense.idman
LEFT OUTER JOIN service				ON service.idser = expenselast.idser
LEFT OUTER JOIN payment				ON payment.kpay = expenselast.kpay



GO
