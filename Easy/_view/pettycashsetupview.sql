-- CREAZIONE VISTA pettycashsetupview
IF EXISTS(select * from sysobjects where id = object_id(N'[pettycashsetupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pettycashsetupview]
GO







CREATE    VIEW pettycashsetupview 
(
	idpettycash,
	pettycash,
	pettycode,
	ayear,
	registrymanager,
	manager,
	idfinincome,
	finincomecode,
	finincometitle,
	idfinexpense,
	finexpensecode,
	finexpensetitle,
	amount,
	autoclassify,
	idacc,
	codeacc,
	account,
	flagmov,
	flag,
	idupb,
	upb,
	cu,
	ct,
	lu,
	lt,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	idsor_siopeinc,idsor_siopeexp
)
AS SELECT
	pettycashsetup.idpettycash,
	pettycash.description,
	pettycash.pettycode,
	pettycashsetup.ayear,
	pettycashsetup.registrymanager,
	registry.title,
	pettycashsetup.idfinincome,
	bilancioentrata.codefin,
	bilancioentrata.title,
	pettycashsetup.idfinexpense,
	bilanciospesa.codefin,
	bilanciospesa.title,
	pettycashsetup.amount,
	pettycashsetup.autoclassify,
	pettycashsetup.idacc,
	account.codeacc,
	account.title,
	CASE
		WHEN ((pettycashsetup.flag&1)=0) THEN 'S'
		WHEN ((pettycashsetup.flag&1)<>0) THEN 'N'
	END, 
	pettycashsetup.flag,
	pettycashsetup.idupb,
	upb.title,
	pettycashsetup.cu,
	pettycashsetup.ct,
	pettycashsetup.lu,
	pettycashsetup.lt,
	isnull(pettycash.idsor01,upb.idsor01),
	isnull(pettycash.idsor02,upb.idsor02),
	isnull(pettycash.idsor03,upb.idsor03),
	isnull(pettycash.idsor04,upb.idsor04),
	isnull(pettycash.idsor05,upb.idsor05),
	idsor_siopeinc,idsor_siopeexp
FROM pettycashsetup 
LEFT OUTER JOIN registry 
	ON registry.idreg = pettycashsetup.registrymanager
LEFT OUTER JOIN pettycash 
	ON pettycash.idpettycash = pettycashsetup.idpettycash
LEFT OUTER JOIN fin bilancioentrata 
	ON bilancioentrata.idfin = pettycashsetup.idfinincome
LEFT OUTER JOIN fin bilanciospesa 
	ON bilanciospesa.idfin = pettycashsetup.idfinexpense
LEFT OUTER JOIN account 
	ON account.idacc = pettycashsetup.idacc
LEFT OUTER JOIN upb
	ON upb.idupb = pettycashsetup.idupb












GO
