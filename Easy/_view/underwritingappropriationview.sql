-- CREAZIONE VISTA underwritingappropriationview
IF EXISTS(select * from sysobjects where id = object_id(N'[underwritingappropriationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [underwritingappropriationview]
GO



CREATE      VIEW [underwritingappropriationview]
(
	idexp,
	nphase,
	expensephase,
	ymov,
	nmov,
	ayear,
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
	expenseyear.ayear,
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
	underwritingappropriation.amount,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.idupb,
	upb.codeupb,
	underwritingappropriation.cu,
	underwritingappropriation.ct,
	underwritingappropriation.lu,
	underwritingappropriation.lt
FROM underwritingappropriation
JOIN expense
	ON underwritingappropriation.idexp = expense.idexp
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp	
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN underwriting
	ON underwritingappropriation.idunderwriting = underwriting.idunderwriting
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb


GO

