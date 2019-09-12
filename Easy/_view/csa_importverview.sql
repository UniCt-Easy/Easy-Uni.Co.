-- CREAZIONE VISTA csa_importverview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importverview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importverview]
GO

CREATE  VIEW [csa_importverview]
(
	kind,
	ayear,
	competency,
	idver,
	idcsa_import,
	yimport,
	nimport,
	idcsa_contract,
	ycontract,
	ncontract,
	idcsa_contractkind,
	csa_contractkindcode,
	csa_contractkind,
	ruolocsa,
	capitolocsa,
	competenza,
	matricola,
	ente,
	vocecsa,
	vocecsaunified,
	importo,
	idreg,
	registry,
	idcsa_agency,
	agency, --description
	idreg_agency,
	registry_agency,
	idcsa_agencypaymethod,
	idregistrypaymethod,
	idcsa_contracttax,
	idcsa_contractkinddata,
	idcsa_incomesetup,
	idacc_debit,
	codeacc_debit,
	account_debit,
	idacc_expense,
	codeacc_expense,
	account_expense,
	idacc_internalcredit,
	codeacc_internalcredit,
	account_internalcredit,
	idacc_cost,
	codeacc_cost,
	account_cost,
	idacc_revenue,
	codeacc_revenue,
	account_revenue,
	idacc_agency_credit,
	codeacc_agency_credit,
	account_agency_credit,
	idfin_income,
	codefin_income,
	fin_income,
	idfin_expense,
	codefin_expense,
	fin_expense,
	idfin_incomeclawback,
	codefin_incomeclawback,
	fin_incomeclawback,
	idfin_cost,
	codefin_cost,
	fin_cost,

	idsor_siope_income,
	sortcode_income,
	sorting_income,
	idsor_siope_expense,
	sortcode_expense,
	sorting_expense,
	idsor_siope_incomeclawback,
	sortcode_incomeclawback,
	sorting_incomeclawback,
	idsor_siope_cost,
	sortcode_cost,
	sorting_cost,
	csa_agency_flag, 
	annualpayment,
	idupb,
	codeupb,
	upb,
	idexp_cost,
	nphase_cost,
	phase_cost,
	ymov_cost,
	nmov_cost,
	flagcr,
	flagclawback,
	flagdirectcsaclawback,
	idunderwriting,
	underwriting,
	idepexp,yepexp,nepexp,epexp_nphase,
	lu,
	lt
)
AS SELECT 
	CASE WHEN (IV.idcsa_contract = null  AND  IV.idcsa_contractkind=null AND
		       IV.idcsa_contractkinddata=null AND IV.idcsa_contracttax=null AND IV.idcsa_incomesetup=null)	THEN 'Voce CSA'
	 WHEN 	(ISNULL(IV.flagclawback,'N') = 'S')																THEN 'Recupero' 
	 WHEN 	(ISNULL(IV.flagclawback,'N') = 'N' AND 	(IV.idcsa_contractkinddata IS NOT NULL OR IV.idcsa_contracttax IS NOT NULL))  THEN 'Contributo' 
	 ELSE 'Ritenuta' END,
	IV.ayear,
	IV.competency,
	IV.idver,
	IV.idcsa_import,
	I.yimport,
	I.nimport,
	IV.idcsa_contract,
	C.ycontract,
	C.ncontract,
	IV.idcsa_contractkind,
	CK.contractkindcode,
	CK.description,
	IV.ruolocsa,
	IV.capitolocsa,
	IV.competenza,
	IV.matricola,
	IV.ente,
	IV.vocecsa,
	IV.vocecsaunified,
	IV.importo,
	IV.idreg,
	registry.title,
	IV.idcsa_agency,
	A.description, 
	IV.idreg_agency,
	registry_agency.title,
	IV.idcsa_agencypaymethod,
	AP.idregistrypaymethod,
	IV.idcsa_contracttax,
	IV.idcsa_contractkinddata,
	IV.idcsa_incomesetup,
	IV.idacc_debit,
	account_debit.codeacc,
	account_debit.title,
	IV.idacc_expense,
	account_expense.codeacc,
	account_expense.title,
	IV.idacc_internalcredit,
	account_internalcredit.codeacc,
	account_internalcredit.title,
	IV.idacc_cost,
	account_cost.codeacc,
	account_cost.title,
	IV.idacc_revenue,
	account_revenue.codeacc,
	account_revenue.title,
	account_agency_credit.idacc,
	account_agency_credit.codeacc,
	account_agency_credit.title,
	IV.idfin_income,
	fin_income.codefin,
	fin_income.title,
	IV.idfin_expense,
	fin_expense.codefin,
	fin_expense.title,
	IV.idfin_incomeclawback,
	fin_incomeclawback.codefin,
	fin_incomeclawback.title,
	IV.idfin_cost,
	fin_cost.codefin,
	fin_cost.title,

	IV.idsor_siope_income,
	sorting_income.sortcode,
	sorting_income.description,
	IV.idsor_siope_expense,
	sorting_expense.sortcode,
	sorting_expense.description,
	IV.idsor_siope_incomeclawback,
	sorting_incomeclawback.sortcode,
	sorting_incomeclawback.description,
	IV.idsor_siope_cost,
	sorting_cost.sortcode,
	sorting_cost.description,
	A.flag, 
	CASE	WHEN (ISNULL(A.flag,0) & 1 <> 0) THEN 'S' ELSE 'N' END,
	upb.idupb,
	upb.codeupb,
	upb.title,
	IV.idexp_cost,
	expensephase.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	IV.flagcr,
	IV.flagclawback,
	IV.flagdirectcsaclawback,
	IV.idunderwriting,
	underwriting.title,
	IV.idepexp,epexp.yepexp,epexp.nepexp,epexp.nphase,
	IV.lu,
	IV.lt
FROM csa_importver IV
JOIN csa_import I
	ON I.idcsa_import = IV.idcsa_import
LEFT OUTER JOIN csa_contractkind CK
	ON IV.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN csa_contract C
	ON C.idcsa_contract = IV.idcsa_contract
	AND C.idcsa_contractkind = CK.idcsa_contractkind
	AND C.ayear = IV.ayear
LEFT OUTER JOIN csa_contractkindyear CKY
	ON C.idcsa_contractkind = CKY.idcsa_contractkind
	AND CKY.ayear = C.ayear
LEFT OUTER JOIN csa_agency A
	ON A.idcsa_agency = IV.idcsa_agency
LEFT OUTER JOIN csa_agencypaymethod AP
	ON AP.idcsa_agency = A.idcsa_agency
	AND AP.idcsa_agencypaymethod = IV.idcsa_agencypaymethod
LEFT OUTER JOIN registry registry_agency
	ON IV.idreg_agency = registry_agency.idreg
LEFT OUTER JOIN fin fin_income
	ON fin_income.idfin=IV.idfin_income
LEFT OUTER JOIN fin fin_expense
	ON fin_expense.idfin=IV.idfin_expense
LEFT OUTER JOIN fin fin_incomeclawback
	ON fin_incomeclawback.idfin=IV.idfin_incomeclawback
LEFT OUTER JOIN fin fin_cost
	ON fin_cost.idfin=IV.idfin_cost

LEFT OUTER JOIN sorting sorting_income
	ON sorting_income.idsor = IV.idsor_siope_income
LEFT OUTER JOIN sorting sorting_expense
	ON sorting_expense.idsor = IV.idsor_siope_expense
LEFT OUTER JOIN sorting sorting_incomeclawback
	ON sorting_incomeclawback.idsor = IV.idsor_siope_incomeclawback
LEFT OUTER JOIN sorting sorting_cost
	ON sorting_cost.idsor = IV.idsor_siope_cost

LEFT OUTER JOIN upb
	ON upb.idupb = IV.idupb
LEFT OUTER JOIN account account_debit
	ON account_debit.idacc=IV.idacc_debit
LEFT OUTER JOIN account account_expense
	ON account_expense.idacc=IV.idacc_expense
LEFT OUTER JOIN account account_internalcredit
	ON account_internalcredit.idacc=IV.idacc_internalcredit
LEFT OUTER JOIN account account_cost
	ON account_cost.idacc=IV.idacc_cost  
LEFT OUTER JOIN account account_revenue
	ON account_revenue.idacc=IV.idacc_revenue
LEFT OUTER JOIN account account_agency_credit
	ON account_agency_credit.idacc=IV.idacc_agency_credit
LEFT OUTER JOIN registry
	ON IV.idreg = registry.idreg
LEFT OUTER JOIN expense
	ON IV.idexp_cost = expense.idexp
LEFT OUTER JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
	AND expenseyear.ayear= IV.ayear
LEFT OUTER JOIN expensetotal
	ON  expensetotal.idexp = expense.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN underwriting
	ON IV.idunderwriting = underwriting.idunderwriting
LEFT OUTER JOIN epexp	
	ON epexp.idepexp = IV.idepexp


GO

--clear_table_info 'csa_importverview'
