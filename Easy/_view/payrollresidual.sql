-- CREAZIONE VISTA payrollresidual
IF EXISTS(select * from sysobjects where id = object_id(N'[payrollresidual]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payrollresidual]
GO




CREATE                                   VIEW [payrollresidual]
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
	workingdays,
	idresidence,
	idcon,
	lt,
	lu,
	npayroll,
	linkedamount,
	residual,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT
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
(
	(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 	
	FROM expensepayroll mov
	JOIN expense s 
		ON s.idexp = mov.idexp  
	LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
		ON expensetotal_firstyear.idexp = s.idexp
		AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
		ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
		AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
	WHERE mov.idpayroll = payroll.idpayroll)
	+
	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM expensepayroll mov
	JOIN expense s  
		ON s.idexp = mov.idexp  
	LEFT OUTER JOIN expensevar v
		ON (v.idexp = mov.idexp) 
	WHERE mov.idpayroll =payroll.idpayroll)
),
CONVERT(decimal(23,6),payroll.feegross -
	(
		(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 	
		FROM expensepayroll mov
		JOIN expense s 
			ON s.idexp = mov.idexp  
		LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
			ON expensetotal_firstyear.idexp = s.idexp
			AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
		WHERE mov.idpayroll = payroll.idpayroll)
		+
		(SELECT ISNULL(SUM(v.amount), 0.0) 
		FROM expensepayroll mov
		JOIN expense s  
			ON s.idexp = mov.idexp  LEFT OUTER JOIN expensevar v
			ON (v.idexp = mov.idexp)
		WHERE mov.idpayroll =payroll.idpayroll 
			AND ISNULL(v.autokind,0) <> 4)
	)
),
	parasubcontract.idsor01,parasubcontract.idsor02,parasubcontract.idsor03,parasubcontract.idsor04,parasubcontract.idsor05
FROM payroll  with (nolock)
JOIN parasubcontract with (nolock)
	ON payroll.idcon = parasubcontract.idcon








GO
