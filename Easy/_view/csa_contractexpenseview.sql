-- CREAZIONE VISTA csa_contractexpenseview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contractexpenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contractexpenseview]
GO
-- setuser 'amm' 
-- clear_table_info'csa_contractexpenseview'
-- select * from csa_contractexpenseview
CREATE      VIEW [csa_contractexpenseview]
(
	ayear,
	idcsa_contract,
	ndetail,quota,cu,ct,lu,lt,idexp,
	ymov,nmov,nphase, phase,
	ycontract,ncontract,idcsa_contractkind,
	contractkindcode, contractkind, active,
	idupb, codeupb,upb,idfin,codefin,finance
)
AS SELECT 
	C.ayear,
	C.idcsa_contract,
	C.ndetail,C.quota,C.cu,C.ct,C.lu,C.lt,C.idexp,	
	E.ymov,E.nmov,E.nphase, EF.description,
	CC.ycontract,	CC.ncontract,CK.idcsa_contractkind,
	CK.contractkindcode,	CK.description,
	CC.active,
	EY.idupb, upb.codeupb,upb.title,
	fin.idfin,fin.codefin, fin.title


FROM csa_contractexpense C
join csa_contract CC			on C.idcsa_contract = CC.idcsa_contract and C.ayear = CC.ayear
JOIN csa_contractkind CK		ON CC.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN expense E		ON C.idexp = E.idexp
LEFT OUTER JOIN expenseyear EY	ON C.idexp = EY.idexp	AND C.ayear = EY.ayear
LEFT OUTER JOIN upb				ON upb.idupb = EY.idupb
LEFT OUTER JOIN fin				ON fin.idfin = EY.idfin
LEFT OUTER JOIN expensephase EF
	ON EF.nphase = E.nphase
GO

 