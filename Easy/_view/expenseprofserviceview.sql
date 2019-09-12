-- CREAZIONE VISTA expenseprofserviceview
IF EXISTS(select * from sysobjects where id = object_id(N'[expenseprofserviceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenseprofserviceview]
GO




CREATE   VIEW [expenseprofserviceview]
(
	ycon,
	ncon,
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
	idaccmotive,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expenseprofservice.ycon,
	expenseprofservice.ncon,
	expenseprofservice.movkind,
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
	payment.kpay,
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
	profservice.idaccmotive,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	expenseprofservice.cu,
	expenseprofservice.ct,
	expenseprofservice.lu,
	expenseprofservice.lt
FROM expenseprofservice
JOIN profservice
	ON expenseprofservice.ycon = profservice.ycon
	AND expenseprofservice.ncon = profservice.ncon
JOIN config
	ON config.ayear=expenseprofservice.ycon 
JOIN expense
	ON expense.idexp = expenseprofservice.idexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense former
	ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay


GO
 