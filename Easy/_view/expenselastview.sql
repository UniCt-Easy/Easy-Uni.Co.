-- CREAZIONE VISTA expenselastview
IF EXISTS(select * from sysobjects where id = object_id(N'[expenselastview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenselastview]
GO

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
	idsor01,idsor02,idsor03,idsor04,idsor05
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
							((II.autokind=4 and II.idreg = expense.idreg ) or II.autokind in (6,14,20,21,30,31)) 
							 ) ,0),
	(
		expensetotal.curramount - 
		isnull(
		(SELECT sum(IIT.curramount) from  			
					income II with (nolock) 
					join incometotal IIT  with (nolock)  on II.idinc=IIT.idinc and IIT.ayear=expenseyear.ayear	
					join incomelast IL with (nolock) on IL.idinc=II.idinc 
			WHERE  expenselast.idexp=II.idpayment and 
							((II.autokind=4 and II.idreg = expense.idreg ) or II.autokind in (6,14,20,21,30,31)) 
							 ) ,0)
	),
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
	upb.idsor01,upb.idsor02,upb.idsor03,upb.idsor04,upb.idsor05
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


 