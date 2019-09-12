-- CREAZIONE VISTA [csa_importriep_partition_expenseview]
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importriep_partition_expenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importriep_partition_expenseview]
GO  
 --setuser 'amministrazione'
--SELECT * FROM [csa_importriep_partition_expenseview]
--DROP VIEW [csa_importriep_partition_expenseview]
CREATE VIEW [csa_importriep_partition_expenseview]
(

	idcsa_import,
	yimport,
	nimport,
	idcsa_contract,
	ycontract,
	ncontract,
	idcsa_contractkind,
	csa_contractkindcode,
	csa_contractkind,
	idriep,
	importo,
	ndetail,
	amount,
	idexp,
	ymov,
	nmov,
	descrmov,
	paridexp,
	nphaseexpense,
	phase,
	movkind,
	descrmovkind,
	idreg ,
	registry ,
	idreg_main,
	registry_main,
	lu,	lt,cu,ct
)
AS SELECT 
	RE.idcsa_import,
	I.yimport,
	I.nimport,
	IR.idcsa_contract,
	C.ycontract,
	C.ncontract,
	IR.idcsa_contractkind,
	CK.contractkindcode,
	CK.description,
	RE.idriep,
	IR.importo,
	RE.ndetail,
	RPE.amount,
	EX.idexp,
	EX.ymov,
	EX.nmov,
	EX.description,
	EX.parentidexp,
	EX.nphase,
	F.description,
	RPE.movkind,
	MK.description,
	REG.idreg ,
	REG.title ,
	REG_MAIN.idreg,
	REG_MAIN.title,
	RE.lu,	RE.lt,RE.cu,RE.ct
FROM csa_importriep_partition_expense RPE
JOIN csa_importriep_partition RE ON RPE.idcsa_import = RE.idcsa_import  AND RPE.idriep = RE.idriep AND RPE.ndetail = RE.ndetail
JOIN csa_importriep IR 	ON RE.idcsa_import = IR.idcsa_import and RE.idriep = IR.idriep 
LEFT OUTER JOIN expense EX on RPE.idexp=EX.idexp
LEFT OUTER JOIN registry REG_MAIN on REG_MAIN.idreg=EX.idreg
LEFT OUTER JOIN registry REG on REG.idreg=IR.idreg
JOIN csa_import I
	ON I.idcsa_import = IR.idcsa_import
LEFT OUTER JOIN csa_contractkind CK
	ON IR.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN csa_contract C
	ON C.idcsa_contract = IR.idcsa_contract
	AND C.idcsa_contractkind = CK.idcsa_contractkind
	AND C.ayear = IR.ayear
LEFT OUTER JOIN csa_contractkindyear CKY
	ON C.idcsa_contractkind = CKY.idcsa_contractkind
	AND CKY.ayear = C.ayear
LEFT OUTER JOIN expensephase F ON 
	F.nphase = EX.nphase
LEFT OUTER JOIN csa_movkind MK ON 
	MK.movkind = RPE.movkind




GO


