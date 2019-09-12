-- CREAZIONE VISTA payrollavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[payrollavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payrollavailable]
GO


CREATE VIEW [payrollavailable]
(
	idpayroll, fiscalyear, npayroll,
	idcon, ycon, ncon, registry, 
	feegross, netfee, disbursementdate, stop, start, 
	enabletaxrelief, currentrounding, flagcomputed, flagbalance, 
	workingdays, idresidence, cu, ct, lu, lt,
	idupb, idsor1, idsor2, idsor3, idaccmotive,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT 
	payroll.idpayroll, payroll.fiscalyear, payroll.npayroll, 
	payroll.idcon, parasubcontract.ycon, parasubcontract.ncon, registry.title, 
	payroll.feegross, payroll.netfee, payroll.disbursementdate, payroll.stop, payroll.start, 
	payroll.enabletaxrelief, payroll.currentrounding, payroll.flagcomputed, payroll.flagbalance, 
	payroll.workingdays, payroll.idresidence, payroll.cu, payroll.ct, payroll.lu, payroll.lt,
	parasubcontract.idupb, parasubcontract.idsor1, parasubcontract.idsor2, parasubcontract.idsor3, parasubcontract.idaccmotive,
	parasubcontract.idsor01,parasubcontract.idsor02,parasubcontract.idsor03,parasubcontract.idsor04,parasubcontract.idsor05
FROM payroll with (nolock)
JOIN parasubcontract with (nolock)
	ON payroll.idcon = parasubcontract.idcon
JOIN registry with (nolock)
	ON parasubcontract.idreg = registry.idreg
WHERE (payroll.flagcomputed='S')
AND (payroll.disbursementdate IS NULL) AND (payroll.flagbalance = 'N')
	AND ((payroll.fiscalyear * 12 + npayroll) =
	(SELECT MIN(c.fiscalyear * 12 + c.npayroll)
    FROM payroll c
    WHERE c.disbursementdate IS NULL AND c.idcon = payroll.idcon AND c.flagbalance = 'N' and c.flagcomputed='S'))



GO
