-- CREAZIONE VISTA pettycashopunderwritingview
IF EXISTS(select * from sysobjects where id = object_id(N'[pettycashopunderwritingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pettycashopunderwritingview]
GO


CREATE     VIEW [pettycashopunderwritingview]
(
	idunderwriting,
	codeunderwriting,
	underwriting,
	idpettycash,
	pettycash,
	pettycode,
	yoperation,
	noperation,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	amount,
	adate,
	idexp,
	nrestore,
	yrestore,
	adaterestore,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	PCOU.idunderwriting,
	underwriting.codeunderwriting,
	underwriting.title,
	PCO.idpettycash,
	pettycash.description,
	pettycash.pettycode,
	PCO.yoperation,
	PCO.noperation,
	PCO.idfin,
	fin.codefin,
	fin.title,
	PCO.idupb,
	upb.codeupb,
	upb.title,
	PCO.idreg,
	registry.title,
	PCO.idman,
	manager.title,
	PCO.doc,
	PCO.docdate,
	PCO.description,
	PCO.amount,
	PCO.adate,
	PCO.idexp,
	PCO.nrestore,
	PCO.yrestore,
	restoreop.adate,
	PCOU.cu,
	PCOU.ct,
	PCOU.lu,
	PCOU.lt
FROM pettycashoperationunderwriting PCOU
JOIN pettycash
	ON pettycash.idpettycash = PCOU.idpettycash
JOIN pettycashoperation PCO
	ON PCO.idpettycash = PCOU.idpettycash
	AND PCO.yoperation = PCOU.yoperation
	AND PCO.noperation = PCOU.noperation
JOIN underwriting
	ON underwriting.idunderwriting = PCOU.idunderwriting
LEFT OUTER JOIN fin
	ON fin.idfin = PCO.idfin
LEFT OUTER JOIN upb
	on upb.idupb = PCO.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = PCO.idreg
LEFT OUTER JOIN manager
	ON manager.idman = PCO.idman
LEFT OUTER JOIN pettycashoperation restoreop 
	ON restoreop.yoperation = PCO.yrestore 
	AND restoreop.noperation = PCO.nrestore 
	AND restoreop.idpettycash = PCO.idpettycash 
	AND (restoreop.flag& 2)<>0 





GO


