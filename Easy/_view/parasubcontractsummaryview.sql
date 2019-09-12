-- CREAZIONE VISTA parasubcontractsummaryview
IF EXISTS(select * from sysobjects where id = object_id(N'[parasubcontractsummaryview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [parasubcontractsummaryview]
GO

CREATE VIEW parasubcontractsummaryview
(
	idcon,
	ayear,
	taxerariale,
	taxablepension,
	inpsinail,
	deduction,
	fiscaltaxablegross
)
AS
SELECT
	idcon, ayear, 
	-- Ritenuta erariale
	ISNULL(
	(SELECT SUM(payrolltax.employtax)
	FROM payrolltax
	JOIN payroll
		ON payroll.idpayroll = payrolltax.idpayroll
	JOIN tax
		ON payrolltax.taxcode = tax.taxcode
	WHERE payroll.idcon = parasubcontractyear.idcon
		AND payroll.fiscalyear = parasubcontractyear.ayear
		AND payroll.flagbalance = 'S'
		AND tax.taxablecode='ERARIALE')
	,0),
	taxablepension,
	ISNULL(
		(SELECT SUM(payrolltax.employtax)
		FROM payrolltax
		JOIN payroll
			ON payroll.idpayroll = payrolltax.idpayroll
		JOIN tax
			ON payrolltax.taxcode = tax.taxcode
		WHERE payroll.idcon = parasubcontractyear.idcon
			AND payroll.fiscalyear = parasubcontractyear.ayear
			AND payroll.flagbalance = 'S'
			AND tax.taxkind IN (3,4))
	,0),
	ISNULL(
		(SELECT SUM(payrolldeduction.curramount)
		FROM payrolldeduction
		JOIN payroll
			ON payroll.idpayroll = payrolldeduction.idpayroll
		JOIN deduction
			ON deduction.iddeduction = payrolldeduction.iddeduction
		WHERE payroll.idcon = parasubcontractyear.idcon
			AND payroll.fiscalyear = parasubcontractyear.ayear
			AND payroll.flagbalance = 'S'
			AND deduction.flagdeductibleexpense = 'S'
			AND payrolldeduction.iddeduction <> 6) -- Per sicurezza scartiamo la deduzione 6 che sarebbe proprio INPS + INAIL
	,0),
	-- fiscaltaxablegross
	case when exists(select * from payrolltax pt 
						join payroll p on pt.idpayroll=p.idpayroll
						join tax t on t.taxcode=pt.taxcode
						where p.idcon = parasubcontractyear.idcon and p.fiscalyear=parasubcontractyear.ayear
							and t.taxkind=1)
	then 	ISNULL(taxablepension,0) 	-	
			ISNULL(
				(SELECT SUM(payrolltax.employtax)
					FROM payrolltax
					JOIN payroll 		ON payroll.idpayroll = payrolltax.idpayroll
					JOIN tax			ON payrolltax.taxcode = tax.taxcode
					WHERE payroll.idcon = parasubcontractyear.idcon
						AND payroll.fiscalyear = parasubcontractyear.ayear
						AND payroll.flagbalance = 'S'
						AND tax.taxablecode='ERARIALE')
			,0) - 
			ISNULL(
				(SELECT SUM(payrolltax.employtax)
					FROM payrolltax
					JOIN payroll			ON payroll.idpayroll = payrolltax.idpayroll
					JOIN tax				ON payrolltax.taxcode = tax.taxcode
					WHERE payroll.idcon = parasubcontractyear.idcon
							AND payroll.fiscalyear = parasubcontractyear.ayear
							AND payroll.flagbalance = 'S'
							AND tax.taxkind IN (3,4))
			,0) -
			ISNULL(
				(SELECT SUM(payrolldeduction.curramount)
					FROM payrolldeduction
					JOIN payroll			ON payroll.idpayroll = payrolldeduction.idpayroll
					JOIN deduction			ON deduction.iddeduction = payrolldeduction.iddeduction
				WHERE payroll.idcon = parasubcontractyear.idcon
						AND payroll.fiscalyear = parasubcontractyear.ayear
						AND payroll.flagbalance = 'S'
						AND deduction.flagdeductibleexpense = 'S'
						AND payrolldeduction.iddeduction <> 6) -- Per sicurezza scartiamo la deduzione 6 che sarebbe proprio INPS + INAIL
			,0)
	ELSE 
		0
	END
FROM parasubcontractyear



GO