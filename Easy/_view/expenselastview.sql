
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


-- CREAZIONE VISTA expenselastview
IF EXISTS(select * from sysobjects where id = object_id(N'[expenselastview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenselastview]
GO
--setuser'amm'
--setuser'amministrazione'
CREATE     VIEW expenselastview
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
	paymentadate,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	linkedincome,
	net,
	performed,
	notperformed,
	idregistrypaymethod,
	idpaymethod,
	iban,
	biccode,
	cin,
	idbank,
	idcab,
	cc,
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
	txt,
	cu,
	ct,
	lu,
	lt,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	pagopanoticenum
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
	payment.adate,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	isnull(
		(SELECT sum(IIT.curramount) from  			
					income II with (nolock) 
					join incometotal IIT  with (nolock)  on II.idinc=IIT.idinc and IIT.ayear=expenseyear.ayear	
					join incomelast IL with (nolock) on IL.idinc=II.idinc 
			WHERE  expenselast.idexp=II.idpayment and 
							((II.autokind=4 and II.idreg = expense.idreg ) or II.autokind in (6,7,14,20,21,30,31)) 
							 ) ,0),
	(
		expensetotal.curramount - 
		isnull(
		(SELECT sum(IIT.curramount) from  			
					income II with (nolock) 
					join incometotal IIT  with (nolock)  on II.idinc=IIT.idinc and IIT.ayear=expenseyear.ayear	
					join incomelast IL with (nolock) on IL.idinc=II.idinc 
			WHERE  expenselast.idexp=II.idpayment and 
							((II.autokind=4 and II.idreg = expense.idreg ) or II.autokind in (6,7,14,20,21,30,31)) 
							 ) ,0)
	),
	-- ESITATO PERFORMED
	ISNULL((SELECT SUM(amount) from banktransaction P where
		P.idexp=expenselast.idexp),0),
	-- NON ESITATO NOT PERFORMED
	(SELECT SUM(curramount) from expensetotal I join expense S on I.idexp=S.idexp 
		JOIN expenselast EL ON EL.idexp = S.idexp
	  WHERE EL.idexp=expenselast.idexp AND I.ayear = payment.ypay)
	  -ISNULL( (SELECT SUM(amount) from banktransaction P where
		P.idexp=expenselast.idexp),0),
	expenselast.idregistrypaymethod,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.biccode,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymethod_allowdeputy,
	expenselast.paymethod_flag,
	expenselast.extracode,
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
	expense.txt,
	expenselast.cu,
	expenselast.ct,
	expenselast.lu,
	expenselast.lt,
	upb.idsor01,upb.idsor02,upb.idsor03,upb.idsor04,upb.idsor05,
	expenselast.pagopanoticenum
FROM expense (nolock)
JOIN expensephase	(nolock)		ON expensephase.nphase = expense.nphase
JOIN expenseyear	(nolock)		ON expenseyear.idexp = expense.idexp
JOIN expensetotal	(nolock)		ON expensetotal.idexp = expense.idexp
									AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense (nolock)	ON parentexpense.idexp = expense.parentidexp
JOIN expenselast	(nolock)		ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN fin	(nolock)		ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb	(nolock)		ON upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry(nolock)	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager (nolock)		ON manager.idman = expense.idman
LEFT OUTER JOIN service	 (nolock)	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment	(nolock)	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN registry deputy	(nolock)	ON deputy.idreg = expenselast.iddeputy
LEFT OUTER JOIN clawback	(nolock)		ON clawback.idclawback = expense.idclawback
LEFT OUTER JOIN expenseyear expenseyear_starting (nolock)
				ON expenseyear_starting.idexp = expense.idexp
  				AND expenseyear_starting.ayear = expense.ymov


GO


 
