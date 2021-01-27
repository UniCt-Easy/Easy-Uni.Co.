
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


-- CREAZIONE VISTA payrollresidual
IF EXISTS(select * from sysobjects where id = object_id(N'[payrollresidual]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payrollresidual]
GO
--select * from [payrollresidual]

 --setuser 'amm'

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
	idupb,
	codeupb,
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
payroll.idupb,
upb.codeupb,
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
LEFT OUTER JOIN upb 
	ON upb.idupb = payroll.idupb







GO
