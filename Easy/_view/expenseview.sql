
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


-- CREAZIONE VISTA expenseview
IF EXISTS(select * from sysobjects where id = object_id(N'[expenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenseview]
GO
--setuser 'amministrazione' 
--setuser 'amm'
--select * from expenseview
--select * from autokind
--clear_table_info 'expenseview'

CREATE      VIEW expenseview
(
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idformerexpense,
	formerymov,
	formernmov,
	ayear,
	idfin,
	codefin,
	finance,
	finflag,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idreg,
	registry,
	cf,
	p_iva,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	paymentadate,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idregistrypaymethod,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	biccode,
	paymethod_allowdeputy,
	paymethod_flag,
	extracode,
	idchargehandling,
	iddeputy,
	deputy,
	refexternaldoc,
	paymentdescr,
	idser,
	service,
	codeser,
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
	autocode,
	idclawback,
	clawback,
	clawbackref,
	nbill,
	idpay,
	kpaymenttransmission,
	npaymenttransmission,
	transmissiondate,
	idaccdebit, 
	codeaccdebit,
	accountdebit,
	cigcode,	
	cupcode,
	txt,
	cu,
	ct,
	lu,
	lt,
	external_reference,
	netamount,
	pagopanoticenum,
	idinc_linked,
	yinc_linked,
	ninc_linked
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idformerexpense,
	former.ymov,
	former.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	fin.flag,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	expense.idreg,
	registry.title,
	registry.cf,
	registry.p_iva,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	payment.adate,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idregistrypaymethod,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.biccode,
	expenselast.paymethod_allowdeputy,
	expenselast.paymethod_flag,
	extracode,
	expenselast.idchargehandling,
	expenselast.iddeputy,  
	deputy.title,
	expenselast.refexternaldoc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
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
	expense.autocode,
	expense.idclawback,
	clawback.description,
	clawback.clawbackref,
	expenselast.nbill,
	expenselast.idpay,
	paymenttransmission.kpaymenttransmission,
	paymenttransmission.npaymenttransmission,
	paymenttransmission.transmissiondate,
	expenselast.idaccdebit,
	account.codeacc,
	account.title,
	expense.cigcode,	
	expense.cupcode,
	expense.txt,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt,
	expense.external_reference,
	expensetotal.curramount
		- isnull( (SELECT sum(IIT.curramount) from income II with (nolock) 
				join incometotal IIT  with (nolock)  on II.idinc=IIT.idinc and IIT.ayear=expense.ymov	
				join incomelast IL with (nolock) on IL.idinc=II.idinc 
		WHERE expenselast.idexp=II.idpayment and 
						((II.autokind=4 and II.idreg = expense.idreg ) or II.autokind in (6,14,20,21,30,31))--ritenute pari anagrafica, recuperi,generico,csariten,csalordi, NCSALORDI,NCSARITEN
		  
         ),0),
	expenselast.pagopanoticenum,
	income.idinc,income.ymov,income.nmov

FROM expense
JOIN expensephase with(nolock)		ON expensephase.nphase = expense.nphase
JOIN expenseyear with(nolock)		ON expenseyear.idexp = expense.idexp
JOIN expensetotal with(nolock)		ON expensetotal.idexp = expense.idexp
							AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense with(nolock)	ON parentexpense.idexp = expense.parentidexp
LEFT OUTER JOIN expense former	with(nolock)	ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expenselast	with(nolock)	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN fin	with(nolock)	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb	with(nolock)	on upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry	with(nolock)	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager	with(nolock)		ON manager.idman = expense.idman
LEFT OUTER JOIN service	with(nolock)	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment with(nolock)	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN registry deputy with(nolock)	ON deputy.idreg = expenselast.iddeputy
LEFT OUTER JOIN clawback with(nolock)	ON clawback.idclawback = expense.idclawback
LEFT OUTER JOIN expensetotal expensetotal_firstyear with(nolock)  	ON expensetotal_firstyear.idexp = expense.idexp
  									and (expensetotal_firstyear.ayear=expense.ymov)
									--AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting with(nolock) 	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  										AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN paymenttransmission with(nolock) 	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
LEFT OUTER JOIN account			ON account.idacc =  expenselast.idaccdebit
LEFT OUTER JOIN income (nolock)			ON expense.idinc_linked =  income.idinc




GO



 
