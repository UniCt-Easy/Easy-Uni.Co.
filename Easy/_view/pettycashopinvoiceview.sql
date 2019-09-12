-- CREAZIONE VISTA pettycashopinvoiceview
IF EXISTS(select * from sysobjects where id = object_id(N'[pettycashopinvoiceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pettycashopinvoiceview]
GO





CREATE     VIEW [pettycashopinvoiceview]
(
	idinvkind,
	codeinvkind,
	yinv,
	ninv,
	idpettycash,
	pettycash,
	pettycode,
	yoperation,
	noperation,
	idaccmotive_cost,
	codemotive_cost,
	motive_cost,
	idaccmotive_debit,
	codemotive_debit,
	motive_debit,
	idfin,
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
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	amount,
	invoicekind,
	adate,
	nbill,
	idsor1,
	idsor2,
	idsor3,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	PCOI.idinvkind,
	invoicekind.codeinvkind,
	PCOI.yinv,
	PCOI.ninv,
	PCO.idpettycash,
	pettycash.description,
	pettycash.pettycode,
	PCO.yoperation,
	PCO.noperation,
	PCO.idaccmotive_cost,
	AMC.codemotive,
	AMC.title,
	PCO.idaccmotive_debit,
	AMD.codemotive,
	AMD.title,
	PCO.idfin,
	fin.codefin,
	fin.title,
	PCO.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	PCO.idreg,
	registry.title,
	PCO.idman,
	manager.title,
	PCO.doc,
	PCO.docdate,
	PCO.description,
	PCO.amount,
	invoicekind.description,
	invoice.adate,
	PCO.nbill,
	PCO.idsor1,
	PCO.idsor2,
	PCO.idsor3,
	PCOI.cu,
	PCOI.ct,
	PCOI.lu,
	PCOI.lt
FROM pettycashoperationinvoice PCOI
JOIN pettycash
	ON pettycash.idpettycash = PCOI.idpettycash
JOIN pettycashoperation PCO
	ON PCO.idpettycash = PCOI.idpettycash
	AND PCO.yoperation = PCOI.yoperation
	AND PCO.noperation = PCOI.noperation
JOIN invoice
	ON invoice.idinvkind = PCOI.idinvkind
	AND invoice.yinv = PCOI.yinv
	AND invoice.ninv = PCOI.ninv
JOIN invoicekind
	ON invoicekind.idinvkind = invoice.idinvkind
LEFT OUTER JOIN fin
	ON fin.idfin = PCO.idfin
LEFT OUTER JOIN upb
	on upb.idupb = PCO.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = PCO.idreg
LEFT OUTER JOIN manager
	ON manager.idman = PCO.idman
LEFT OUTER JOIN accmotive AMC
	ON AMC.idaccmotive = PCO.idaccmotive_cost
LEFT OUTER JOIN accmotive AMD
	ON AMD.idaccmotive = PCO.idaccmotive_debit




GO
