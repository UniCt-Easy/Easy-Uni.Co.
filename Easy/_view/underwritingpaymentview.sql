-- CREAZIONE VISTA underwritingpaymentview
IF EXISTS(select * from sysobjects where id = object_id(N'[underwritingpaymentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [underwritingpaymentview]
GO






CREATE      VIEW [underwritingpaymentview]
(
	idexp,
	nphase,
	expensephase,
	ymov,
	nmov,
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	adate,
	idunderwriting,
	codeunderwriting,
	underwriting,
	amount,
	idfin,
	codefin,
	fin,
	idupb,
	codeupb,
	upb,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	expense.doc,
	expense.docdate,
	expense.description,
	expense.adate,
	underwriting.idunderwriting,
	underwriting.codeunderwriting,
	underwriting.title,
	underwritingpayment.amount,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.idupb,
	upb.codeupb,
	underwritingpayment.cu,
	underwritingpayment.ct,
	underwritingpayment.lu,
	underwritingpayment.lt
FROM underwritingpayment
JOIN expense
	ON underwritingpayment.idexp = expense.idexp
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp	
JOIN underwriting
	ON underwritingpayment.idunderwriting = underwriting.idunderwriting
JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb



GO

