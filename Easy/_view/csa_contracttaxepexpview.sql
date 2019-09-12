-- CREAZIONE VISTA csa_contracttaxepexpview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contracttaxepexpview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contracttaxepexpview]
GO
--setuser 'amministrazione'
 -- select * from csa_contracttaxepexpview
CREATE      VIEW [csa_contracttaxepexpview]
(
	ayear,
	idcsa_contract,
	idcsa_contracttax,vocecsa,
	ndetail,quota,cu,ct,lu,lt,idepexp,
	yepexp,nepexp,nphase,phase,
	ycontract,ncontract,idcsa_contractkind,
	contractkindcode, contractkind,
	idupb, codeupb,upb,
	idacc, codeacc, account, active
)
AS SELECT 
	C.ayear,
	C.idcsa_contract,
	C.idcsa_contracttax,CT.vocecsa,
	C.ndetail,C.quota,C.cu,C.ct,C.lu,C.lt,C.idepexp,	
	E.yepexp,E.nepexp,	E.nphase,
	CASE E.nphase
		WHEN 1 THEN 'Preimpegno'
		WHEN 2 THEN 'Impegno'
	END ,
	CC.ycontract,	CC.ncontract,CK.idcsa_contractkind,
	CK.contractkindcode,	CK.description,
	upb.idupb, upb.codeupb,upb.title,
	account.idacc, account.codeacc, account.title,CC.active
FROM csa_contracttaxepexp C
join csa_contracttax CT
	 on CT.idcsa_contract = C.idcsa_contract
	 and CT.idcsa_contracttax = C.idcsa_contracttax
	 and CT.ayear = C.ayear
join csa_contract CC
	on CT.idcsa_contract = CC.idcsa_contract and CT.ayear = CC.ayear
JOIN csa_contractkind CK
	ON CC.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN epexp E
	ON C.idepexp = E.idepexp
LEFT OUTER JOIN epexpyear EY
	ON C.idepexp = EY.idepexp
	AND C.ayear = EY.ayear
LEFT OUTER JOIN account
	ON account.idacc = EY.idacc
LEFT OUTER JOIN upb
	ON upb.idupb = EY.idupb

GO

 