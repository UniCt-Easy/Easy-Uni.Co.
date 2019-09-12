-- CREAZIONE VISTA expensevarview
IF EXISTS(select * from sysobjects where id = object_id(N'[expensevarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expensevarview]
GO
--clear_table_info 'expensevarview'
--select * from expensevarview
--setuser 'amm'
CREATE         VIEW [expensevarview]
(
	idexp,
	nvar,
	yvar,
	nphase,
	phase,
	ymov,
	nmov,
	description_main,
	description,
	amount,
	doc,
	docdate,
	autokind,
	idpayment,
	adate,
	transferkind,
	cu,
	ct,
	lu,
	lt,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	movkind,
	kpaymenttransmission,
	kpay,
	ypay,
	npay,
	kpaymenttransmission_orig,
	idman,
	idtreasurer,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idunderwriting,
	underwriting
)
AS SELECT
	expensevar.idexp,
	expensevar.nvar,
	expensevar.yvar,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.description,
	expensevar.description,
	expensevar.amount,
	expensevar.doc,
	expensevar.docdate,
	expensevar.autokind,
	expensevar.idpayment,
	expensevar.adate,
	expensevar.transferkind,
	expensevar.cu,
	expensevar.ct,
	expensevar.lu,
	expensevar.lt,
	fin.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	expensevar.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	expensevar.yinv,
	expensevar.ninv,
	expensevar.movkind,
	expensevar.kpaymenttransmission,
	payment.kpay,
	payment.ypay,
	payment.npay,
	payment.kpaymenttransmission,
	expense.idman,
	payment.idtreasurer,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	expensevar.idunderwriting,
	underwriting.title
FROM expensevar (NOLOCK)
JOIN expense (NOLOCK)
	ON expense.idexp = expensevar.idexp
JOIN expensephase (NOLOCK)
	ON expensephase.nphase = expense.nphase
JOIN expenseyear (NOLOCK)
	ON expenseyear.idexp= expense.idexp
     AND expenseyear.ayear= expensevar.yvar
LEFT OUTER JOIN expenselast (NOLOCK)
	ON expenselast.idexp= expense.idexp
LEFT OUTER JOIN payment (NOLOCK)
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN fin (NOLOCK)
	ON fin.idfin= expenseyear.idfin
LEFT OUTER JOIN upb (NOLOCK)
	ON upb.idupb= expenseyear.idupb
LEFT OUTER JOIN invoicekind
	ON expensevar.idinvkind = invoicekind.idinvkind
LEFT OUTER JOIN underwriting
	ON expensevar.idunderwriting = underwriting.idunderwriting


GO

