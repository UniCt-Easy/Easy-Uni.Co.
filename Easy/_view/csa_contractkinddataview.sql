-- CREAZIONE VISTA csa_contractkinddataview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contractkinddataview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contractkinddataview]
GO


CREATE      VIEW [csa_contractkinddataview]
(
	idcsa_contractkind,
	csa_contractkindcode,
	csa_contractkind,
	idcsa_contractkinddata,
	vocecsa,
	idfin, 	codefin, 	fin,
	idacc,
	codeacc,
	account,
	ayear,
	idupb, codeupb, upb,
	idsor_siope,
	sortcode_siope,
	sort_siope,
	active,
	flagcr,
	ct,
	cu,
	lt,
	lu
)
AS SELECT 
	CK.idcsa_contractkind,
	CK.contractkindcode,
	CK.description,
	C.idcsa_contractkinddata,
	C.vocecsa,
	C.idfin,
	fin.codefin,
	fin.title,
	C.idacc,
	account.codeacc,
	account.title,
	C.ayear,
	C.idupb,
	upb.codeupb,
	upb.title,
	C.idsor_siope,	
	sorting.sortcode,
	sorting.description,
	CK.active,
	CK.flagcr,
	C.ct,
	C.cu,
	C.lt,
	C.lu
FROM csa_contractkinddata C
JOIN csa_contractkind CK		ON C.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN upb				ON upb.idupb=C.idupb
LEFT OUTER JOIN fin				ON fin.idfin=C.idfin
LEFT OUTER JOIN account			ON account.idacc = C.idacc
LEFT OUTER JOIN sorting			ON sorting.idsor = C.idsor_siope


GO

 