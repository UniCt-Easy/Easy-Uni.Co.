-- CREAZIONE VISTA csa_contractkindview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contractkindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contractkindview]
GO




--clear_table_info'csa_contractkindview'


CREATE    VIEW [csa_contractkindview]
(
	ayear,
	idcsa_contractkind,
	idupb,
	codeupb,
	upb,
	description,
	idacc_main,
	codeacc_main,
	account_main,
	idfin_main,
	codefin_main,
	fin_main,
	contractkindcode,
	flagcr,
	flagkeepalive,
	active,
	idsor_siope_main,
	sortcode_main,
	sorting_main,
	idunderwriting,
	underwriting,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	CY.ayear,
	C.idcsa_contractkind,
	CY.idupb,
	upb.codeupb,
	upb.title,
	C.description,
	CY.idacc_main,
	account.codeacc,
	account.title,
	CY.idfin_main,
	fin.codefin, 
	fin.title, 
	C.contractkindcode,
	C.flagcr,
	C.flagkeepalive,
	C.active,
	CY.idsor_siope_main,
	sorting.sortcode,
	sorting.description, 
	C.idunderwriting,
	underwriting.title,
	C.cu,
	C.ct,
	C.lu,
	C.lt
FROM csa_contractkind C
JOIN csa_contractkindyear CY
	ON C.idcsa_contractkind = CY.idcsa_contractkind
LEFT OUTER JOIN upb 
	ON upb.idupb=CY.idupb
LEFT OUTER JOIN fin 
	ON fin.idfin=CY.idfin_main
LEFT OUTER JOIN account 
	ON account.idacc=CY.idacc_main
LEFT OUTER JOIN sorting
	ON sorting.idsor = CY.idsor_siope_main
LEFT OUTER JOIN underwriting
	ON C.idunderwriting = underwriting.idunderwriting


GO
