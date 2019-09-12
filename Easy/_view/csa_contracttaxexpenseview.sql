-- CREAZIONE VISTA csa_contracttaxexpenseview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contracttaxexpenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contracttaxexpenseview]
GO

--clear_table_info'csa_contracttaxexpenseview'
--select * from csa_contracttaxexpense
--select * from csa_contracttaxexpenseview

 
--clear_table_info'csa_contracttaxexpenseview'

CREATE      VIEW [csa_contracttaxexpenseview]
(
	ayear,
	idcsa_contract,
	idcsa_contracttax,vocecsa,
	ndetail,quota,cu,ct,lu,lt,idexp,
	ymov,nmov,nphase,phase,
	ycontract,ncontract,idcsa_contractkind,
	contractkindcode, contractkind,
	idupb, codeupb,upb,
	idfin, codefin, finance, active
)
AS SELECT 
	C.ayear,
	C.idcsa_contract,
	C.idcsa_contracttax,CT.vocecsa,
	C.ndetail,C.quota,C.cu,C.ct,C.lu,C.lt,C.idexp,	
	E.ymov,E.nmov,E.nphase,EF.description,
	CC.ycontract,	CC.ncontract,CK.idcsa_contractkind,
	CK.contractkindcode,	CK.description,
	upb.idupb, upb.codeupb,upb.title,
	fin.idfin, fin.codefin, fin.title,
	CC.active
FROM csa_contracttaxexpense C
join csa_contracttax CT
	 on CT.idcsa_contract = C.idcsa_contract
	 and CT.idcsa_contracttax = C.idcsa_contracttax
	 and CT.ayear = C.ayear
join csa_contract CC
	on CT.idcsa_contract = CC.idcsa_contract and CT.ayear = CC.ayear
JOIN csa_contractkind CK
	ON CC.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN expense E
	ON C.idexp = E.idexp
LEFT OUTER JOIN expensephase EF
	ON EF.nphase = E.nphase
LEFT OUTER JOIN expenseyear EY
	ON C.idexp = EY.idexp
	AND C.ayear = EY.ayear
LEFT OUTER JOIN fin
	ON fin.idfin = EY.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = EY.idupb
GO
