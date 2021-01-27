
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


-- CREAZIONE VISTA expensepayrollview
IF EXISTS(select * from sysobjects where id = object_id(N'[expensepayrollview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expensepayrollview]
GO





CREATE   VIEW [expensepayrollview]
(
	idpayroll, idexp, fiscalyear, npayroll, 
	nphase, phase, ymov, nmov, 
	parentidexp, parentymov,parentnmov, 
	formerymov,formernmov,
	ayear, idfin, 
	codefin, finance, 
	idupb,	codeupb,upb,
	idreg,registry,
	idman, manager,kpay, ypay,npay, 
	doc, docdate, description, 
	amount,
	ayearstartamount, 
	curramount, available, 
	idpaymethod, iban, cin, 
	idbank, idcab,cc, 
	paymentdescr, idser, 
	service, codeser, servicestart, 
	servicestop, ivaamount, 
	flag,
	autokind,
	idpayment, 
	totflag,
	flagarrear, 
	expiration, adate, cu, 
	ct, lu, lt, 
	idcon,
	idaccmotive,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS
SELECT
	expensepayroll.idpayroll, expense.idexp, payroll.fiscalyear, 
	payroll.npayroll, 
	expense.nphase, expensephase.description , expense.ymov, expense.nmov, 
	expense.parentidexp, parentexpense.ymov, parentexpense.nmov,
	former.ymov,former.nmov,
	expenseyear.ayear, expenseyear.idfin, 
	fin.codefin, fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg, registry.title,
	expense.idman, manager.title , payment.kpay, payment.ypay, payment.npay, 
	expense.doc, expense.docdate, expense.description, 
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount, expensetotal.available, 
	expenselast.idpaymethod, expenselast.iban, expenselast.cin, 
	expenselast.idbank, expenselast.idcab, expenselast.cc, 
	expenselast.paymentdescr, expenselast.idser, 
	service.description, service.codeser, expenselast.servicestart, 
	expenselast.servicestop, expenselast.ivaamount, 
	expenselast.flag,
	expense.autokind, 
	expense.idpayment, 
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.expiration, expense.adate, expensepayroll.cu, 
	expensepayroll.ct, expensepayroll.lu, expensepayroll.lt, 
	payroll.idcon,
	parasubcontract.idaccmotive,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05
FROM expensepayroll
JOIN payroll				ON payroll.idpayroll = expensepayroll.idpayroll 
JOIN config					ON config.ayear = payroll.fiscalyear 
JOIN expense				ON expense.idexp=expensepayroll.idexp 
JOIN expensephase			ON expensephase.nphase = expense.nphase 
JOIN expenseyear			ON expenseyear.idexp = expense.idexp 
JOIN expensetotal			ON expensetotal.idexp = expenseyear.idexp 
								AND expensetotal.ayear = expenseyear.ayear 
JOIN parasubcontract		ON parasubcontract.idcon = payroll.idcon
LEFT OUTER JOIN expense parentexpense					ON expense.parentidexp = parentexpense.idexp 
LEFT OUTER JOIN expense former							ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear		ON expensetotal_firstyear.idexp = expense.idexp
															AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting		ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
															AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN fin				ON fin.idfin = expenseyear.idfin 
LEFT OUTER JOIN upb				ON  upb.idupb = expenseyear.idupb 
LEFT OUTER JOIN registry		ON registry.idreg = expense.idreg 
LEFT OUTER JOIN manager			ON manager.idman = expense.idman 
LEFT OUTER JOIN expenselast		ON expenselast.idexp in (select idchild from expenselink where idparent=expense.idexp)
LEFT OUTER JOIN service			ON service.idser = expenselast.idser
LEFT OUTER JOIN payment			ON payment.kpay = expenselast.kpay



GO
