-- CREAZIONE VISTA payrolllinked
IF EXISTS(select * from sysobjects where id = object_id(N'[payrolllinked]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payrolllinked]
GO


CREATE    VIEW [payrolllinked]
(
	ayear,
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
	idupb,
	idsor1,
	idsor2,
	idsor3,
	idaccmotive,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	expenseyear.ayear,
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
	parasubcontract.idupb,
	parasubcontract.idsor1,
	parasubcontract.idsor2,
	parasubcontract.idsor3,
	parasubcontract.idaccmotive,
	parasubcontract.idsor01,parasubcontract.idsor02,parasubcontract.idsor03,parasubcontract.idsor04,parasubcontract.idsor05
FROM payroll  with (nolock)
JOIN parasubcontract  with (nolock)
	ON payroll.idcon = parasubcontract.idcon
JOIN service  with (nolock)
	ON parasubcontract.idser = service.idser
JOIN registry  with (nolock)
	ON parasubcontract.idreg = registry.idreg
LEFT OUTER JOIN geo_city  with (nolock)
	ON payroll.idresidence = geo_city.idcity 			       
JOIN expensepayroll  with (nolock)
	ON payroll.idpayroll = expensepayroll.idpayroll
JOIN expenseyear  with (nolock)
	ON expenseyear.idexp  = expensepayroll.idexp 
WHERE EXISTS(
	(SELECT * FROM expensepayroll
	WHERE expensepayroll.idpayroll = payroll.idpayroll))




GO
