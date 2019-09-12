-- CREAZIONE VISTA pettycashopcasualcontractview
IF EXISTS(select * from sysobjects where id = object_id(N'[pettycashopcasualcontractview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pettycashopcasualcontractview]
GO








CREATE      VIEW [pettycashopcasualcontractview]
(
	ycon,
	ncon,
	idpettycash,
	pettycode,
	pettycash,
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
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
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
	PCOCC.ycon,
	PCOCC.ncon,
	PCO.idpettycash,
	pettycash.pettycode,
	pettycash.description,
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
	casualcontract.idser,
	service.description,
	service.codeser,
	casualcontract.start,
	casualcontract.stop,
	casualcontract.adate,
	PCO.nbill,
	PCO.idsor1,
	PCO.idsor2,
	PCO.idsor3,
	PCOCC.cu,
	PCOCC.ct,
	PCOCC.lu,
	PCOCC.lt
FROM pettycashoperationcasualcontract PCOCC
JOIN pettycash 
	ON pettycash.idpettycash = PCOCC.idpettycash
JOIN pettycashoperation PCO
	ON PCO.idpettycash = PCOCC.idpettycash
	AND PCO.yoperation = PCOCC.yoperation
	AND PCO.noperation = PCOCC.noperation
JOIN casualcontract
	ON casualcontract.ycon = PCOCC.ycon
	AND casualcontract.ncon = PCOCC.ncon
JOIN service
	ON service.idser = casualcontract.idser
LEFT OUTER JOIN fin
	ON fin.idfin = PCO.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = PCO.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = PCO.idreg
LEFT OUTER JOIN manager
	ON manager.idman = PCO.idman
LEFT OUTER JOIN accmotive AMC
	ON AMC.idaccmotive = PCO.idaccmotive_cost
LEFT OUTER JOIN accmotive AMD
	ON AMD.idaccmotive = PCO.idaccmotive_debit




GO
