
--setuser 'amministrazione'
-- CREAZIONE VISTA payrollview
IF EXISTS(select * from sysobjects where id = object_id(N'[payrollview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payrollview]
GO



--select * from payrollview
CREATE VIEW [payrollview]
(
	idpayroll,
	fiscalyear,
	enabletaxrelief,
	currentrounding,
	feegross,
	netfee, 
	ct,
	cu,
	disbursementdate,
	stop,
	start,
	flagcomputed,
	flagbalance, 
	flagsummarybalance,
	workingdays,
	idresidence,
	idcon,
	lt,
	lu,
	npayroll,
	ycon, 
	ncon,
	registry,
	idreg,
	matricula,
	idser, 
	service,
	codeser,
	residencecity,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	ymov_lastphase,
	nmov_lastphase,
	ypay,
	npay
)
AS
SELECT
	payroll.idpayroll,
	payroll.fiscalyear,
	payroll.enabletaxrelief,
	payroll.currentrounding,
	payroll.feegross,
	payroll.netfee, 
	payroll.ct,
	payroll.cu,
	payroll.disbursementdate,
	payroll.stop,
	payroll.start,
	payroll.flagcomputed,
	payroll.flagbalance, 
	payroll.flagsummarybalance,
	payroll.workingdays,
	payroll.idresidence,
	payroll.idcon,
	payroll.lt,
	payroll.lu,
	payroll.npayroll,
	parasubcontract.ycon, 
	parasubcontract.ncon,
	registry.title,
	parasubcontract.idreg,
	parasubcontract.matricula,
	parasubcontract.idser,
	service.description,
	service.codeser,
	geo_city.title,
	isnull(parasubcontract.idsor01,upb.idsor01),
	isnull(parasubcontract.idsor02,upb.idsor02),
	isnull(parasubcontract.idsor03,upb.idsor03),
	isnull(parasubcontract.idsor04,upb.idsor04),
	isnull(parasubcontract.idsor05,upb.idsor05),
	lastexp.ymov,
	lastexp.nmov,
	payment.ypay,
	payment.npay
FROM payroll with (nolock)
JOIN parasubcontract with (nolock)			ON payroll.idcon = parasubcontract.idcon
JOIN service with (nolock)					ON parasubcontract.idser = service.idser
INNER JOIN registry with (nolock)			ON parasubcontract.idreg = registry.idreg
LEFT OUTER JOIN geo_city with (nolock)		ON payroll.idresidence = geo_city.idcity
LEFT OUTER JOIN upb  with (nolock)			ON upb.idupb = parasubcontract.idupb
LEFT OUTER JOIN expensepayroll  with (nolock)	ON payroll.idpayroll = expensepayroll.idpayroll
LEFT OUTER JOIN expense   with (nolock)		ON expense.idexp = expensepayroll.idexp
LEFT OUTER JOIN expenselast with (nolock)	ON expenselast.idexp in
		 (select expenselink.idchild from expenselink with (nolock) 	where expenselink.idparent=expense.idexp)
LEFT OUTER JOIN expense lastexp with (nolock)	ON lastexp.idexp = expenselast.idexp		 
LEFT OUTER JOIN payment	(nolock)	ON payment.kpay = expenselast.kpay

GO


 

 