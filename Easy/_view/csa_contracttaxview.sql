-- CREAZIONE VISTA [csa_contracttaxview]
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contracttaxview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contracttaxview]
GO


-- clear_table_info'csa_contractview'


CREATE      VIEW [csa_contracttaxview]
(
	ayear,
	idcsa_contract,
	idcsa_contracttax,
	vocecsa,idfin,idexp,idacc,ct,cu,lt,lu,idupb,idsor_siope,
	ymov,nmov,nphase,codeupb,codefin,codeacc,sortcode_siope,
	idepexp,yepexp,nepexp,epexp_nphase,
	ycontract,ncontract,active,
	contractkindcode, contractkind
)
AS SELECT 
	C.ayear,
	C.idcsa_contract,
	C.idcsa_contracttax,
	C.vocecsa,C.idfin,C.idexp,C.idacc,C.ct,C.cu,C.lt,C.lu,C.idupb,C.idsor_siope,
	E.ymov,E.nmov,E.nphase,  U.codeupb, F.codefin, ACC.codeacc, S.sortcode,
	EP.idepexp,EP.yepexp,EP.nepexp,EP.nphase,
	CC.ycontract,	CC.ncontract,CC.active,
	CK.contractkindcode,	CK.description
FROM csa_contracttax C
join csa_contract CC
	on C.idcsa_contract = CC.idcsa_contract and C.ayear = CC.ayear
JOIN csa_contractkind CK
	ON CC.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN upb U
	ON U.idupb=C.idupb
LEFT OUTER JOIN fin F
	ON F.idfin=C.idfin
LEFT OUTER JOIN account ACC
	ON ACC.idacc=C.idacc
LEFT OUTER JOIN expense E
	ON C.idexp = E.idexp
LEFT OUTER JOIN sorting S
	ON S.idsor = C.idsor_siope
LEFT OUTER JOIN epexp	EP
	ON EP.idepexp = C.idepexp

GO


 