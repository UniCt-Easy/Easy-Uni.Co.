-- CREAZIONE VISTA pettycashoperationview
IF EXISTS(select * from sysobjects where id = object_id(N'[pettycashoperationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pettycashoperationview]
GO

-- setuser 'amm'
-- clear_table_info 'pettycashoperationview'
-- select * from pettycashoperationview
CREATE  VIEW pettycashoperationview 
(
	yoperation,
	noperation,
	idpettycash,
	pettycash,
	pettycode,
	flag,
	kind,
	idreg,
	registry,
	idaccmotive_cost,
	codemotive_cost,
	motive_cost,
	idaccmotive_debit,
	codemotive_debit,
	motive_debit,
	flagdocumented,
	idfin,
	finpart,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	yrestore,
	nrestore,
	adaterestore,
	description,
	doc,
	docdate,
	amount,
	adate,
	nlist,
	nbill,
	cu,
	ct,
	lu,
	lt,
	idman,
	manager,
	idexp,
	idsor1,
	idsor2,
	idsor3,
	start,
	stop,
	ymov,nmov,phase
)
AS SELECT
	pettycashoperation.yoperation,
	pettycashoperation.noperation,
	pettycashoperation.idpettycash,
	pettycash.description,
	pettycash.pettycode,
	pettycashoperation.flag,
	CASE
		WHEN (pettycashoperation.flag & 1) <> 0 THEN 'A'
		WHEN (pettycashoperation.flag & 2) <> 0 THEN 'R'
		WHEN (pettycashoperation.flag & 4) <> 0 THEN 'C'
		WHEN (pettycashoperation.flag & 8) <> 0 THEN 'S'
	END,
	pettycashoperation.idreg,
	registry.title,
	pettycashoperation.idaccmotive_cost,
	AMC.codemotive,
	AMC.title,
	pettycashoperation.idaccmotive_debit,
	AMD.codemotive,
	AMD.title,
	CASE
		WHEN (pettycashoperation.flag & 16) <> 0 THEN 'S'
		ELSE 'N'
	END,
	pettycashoperation.idfin,
 	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	END,
	fin.codefin,
	fin.title,
	pettycashoperation.idupb,
	upb.codeupb,
	upb.title,
	pettycashoperation.idsor01,
	pettycashoperation.idsor02,
	pettycashoperation.idsor03,
	pettycashoperation.idsor04,
	pettycashoperation.idsor05,
	pettycashoperation.yrestore,
	pettycashoperation.nrestore,
	restoreop.adate,
	pettycashoperation.description,
	pettycashoperation.doc,
	pettycashoperation.docdate,
	pettycashoperation.amount,
	pettycashoperation.adate,
	pettycashoperation.nlist,
	pettycashoperation.nbill,
	pettycashoperation.cu,
	pettycashoperation.ct,
	pettycashoperation.lu,
	pettycashoperation.lt,
	pettycashoperation.idman,
	manager.title,
	pettycashoperation.idexp,
	pettycashoperation.idsor1,
	pettycashoperation.idsor2,
	pettycashoperation.idsor3,
	pettycashoperation.start,
	pettycashoperation.stop,
	expense.ymov,
	expense.nmov,
	expensephase.description
FROM pettycashoperation
LEFT OUTER JOIN pettycash			ON pettycash.idpettycash = pettycashoperation.idpettycash
LEFT OUTER JOIN fin					ON fin.idfin = pettycashoperation.idfin
LEFT OUTER JOIN expense				ON expense.idexp = pettycashoperation.idexp
LEFT OUTER JOIN expensephase		ON expense.nphase = expensephase.nphase
LEFT OUTER JOIN upb					ON upb.idupb = pettycashoperation.idupb
LEFT OUTER JOIN manager				ON manager.idman = pettycashoperation.idman
LEFT OUTER JOIN registry			ON registry.idreg = pettycashoperation.idreg
LEFT OUTER JOIN accmotive AMC		ON AMC.idaccmotive = pettycashoperation.idaccmotive_cost
LEFT OUTER JOIN accmotive AMD		ON AMD.idaccmotive = pettycashoperation.idaccmotive_debit
LEFT OUTER JOIN pettycashoperation restoreop 	ON restoreop.yoperation = pettycashoperation.yrestore 
							AND restoreop.noperation = pettycashoperation.nrestore 
							AND restoreop.idpettycash = pettycashoperation.idpettycash 
							AND (restoreop.flag& 2)<>0 


GO
