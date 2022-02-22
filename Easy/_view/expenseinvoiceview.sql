
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA expenseinvoiceview
IF EXISTS(select * from sysobjects where id = object_id(N'[expenseinvoiceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenseinvoiceview]
GO


--clear_table_info 'expenseinvoiceview'
--setuser 'amm'
--select * from expenseinvoiceview

CREATE  VIEW expenseinvoiceview 
(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
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
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag, 
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
	AS SELECT
	expenseinvoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	expenseinvoice.yinv,
	expenseinvoice.ninv,
	expenseinvoice.movkind,
	expenseinvoice.idexp,
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
	expenseyear.amount,
	expenseyear_starting.amount,
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
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	expenseinvoice.cu,
	expenseinvoice.ct,
	expenseinvoice.lu,
	expenseinvoice.lt,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05
	FROM expenseinvoice 
	JOIN invoicekind				ON invoicekind.idinvkind = expenseinvoice.idinvkind
	JOIN expense					ON expense.idexp = expenseinvoice.idexp
	JOIN expensephase				ON expensephase.nphase = expense.nphase
	JOIN expenseyear				ON expenseyear.idexp = expense.idexp
	JOIN expensetotal				ON expensetotal.idexp = expenseyear.idexp
												AND expensetotal.ayear = expenseyear.ayear
	LEFT OUTER JOIN expense parentexpense  		ON expense.parentidexp = parentexpense.idexp
	LEFT OUTER JOIN expense former			ON expense.idformerexpense = former.idexp
	--LEFT OUTER JOIN expensetotal expensetotal_firstyear		ON expensetotal_firstyear.idexp = expense.idexp
    --												AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting 		ON expenseyear_starting.idexp = expense.idexp
											AND expenseyear_starting.ayear = expense.ymov
	LEFT OUTER JOIN expenselast				ON expense.idexp = expenselast.idexp
	LEFT OUTER JOIN fin						ON fin.idfin = expenseyear.idfin
	LEFT OUTER JOIN upb						on upb.idupb = expenseyear.idupb
	LEFT OUTER JOIN registry				ON registry.idreg = expense.idreg
	LEFT OUTER JOIN manager					ON manager.idman = expense.idman
	LEFT OUTER JOIN service					ON service.idser = expenselast.idser
	LEFT OUTER JOIN payment					ON payment.kpay = expenselast.kpay



GO
