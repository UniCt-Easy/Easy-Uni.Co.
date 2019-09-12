
-- CREAZIONE VISTA casualcontractview
IF EXISTS(select * from sysobjects where id = object_id(N'[casualcontractview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [casualcontractview]
GO
 
-- setuser 'amm'
--  clear_table_info'casualcontractview'

CREATE VIEW [casualcontractview]
(
	ayear,
	ycon,
	ncon,
	start,
	stop,
	adate,
	idreg,
	registry,
	iddaliaposition,
	codedaliaposition,
	daliaposition,
	idupb,
	codeupb,
	upb,
	feegross,
	total,
	taxableotheragency,
	idser,
	service,
	codeser,
	description,
	ndays,
	activitycode,
	activity,
	idotherinsurance,
	otherinsurance,
	idemenscontractkind,
	emenscontractkind,
	flaghigherrate,
	completed,
	idaccmotive,
	codemotive,
	accmotive,
	idaccmotivedebit,
	codemotivedebit,
	accmotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	accmotive_crg,
	idaccmotivedebit_datacrg,
	idsor1,
	idsor2,
	idsor3,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	authneeded,
	authdoc,
	authdocdate,
	noauthreason,
	arrivalprotocolnum,
	arrivaldate,
	annotations,
	expiration,
	cupcode,
	cigcode,
	iduniqueregister,
	resendingpcc,
	ipa_fe,
	expensekind,
	cu,
	ct,
	lu,
	lt,
	txt,
	expensekinddescription,
	idrelated,
	datecompleted,
	idsor_siope,
	requested_doc
)
AS SELECT 
	ICOP.ayear,
	COP.ycon,
	COP.ncon,
	COP.start,
	COP.stop,
	COP.adate,
	COP.idreg,
	registry.title,
	DP.iddaliaposition,
	DP.codedaliaposition,
	DP.description,
	COP.idupb,
	UPB.codeupb,
	UPB.title,
	COP.feegross,
	COP.feegross + isnull((select sum(CTAX.admintax)
		from casualcontracttax CTAX
		where  COP.ycon = CTAX.ycon AND COP.ncon = CTAX.ncon),0)
	,
	ICOP.taxableotheragency,
	COP.idser,
	service.description,
	service.codeser,
	COP.description,
	COP.ndays,
	ICOP.activitycode,
	API.description,
	ICOP.idotherinsurance,
	AFA.description,
	ICOP.idemenscontractkind,
	ETR.description,
	ICOP.flaghigherrate,
	COP.completed,
	COP.idaccmotive,
	AM.codemotive,
	AM.title,
	COP.idaccmotivedebit,
	DB.codemotive,
	DB.title,
	COP.idaccmotivedebit_crg,
	CRG.codemotive,
	CRG.title,
	COP.idaccmotivedebit_datacrg,
	COP.idsor1,
	COP.idsor2,
	COP.idsor3,
	isnull(COP.idsor01,UPB.idsor01),
	isnull(COP.idsor02,UPB.idsor02),
	isnull(COP.idsor03,UPB.idsor03),
	isnull(COP.idsor04,UPB.idsor04),
	isnull(COP.idsor05,UPB.idsor05),
	COP.authneeded,
	COP.authdoc,
	COP.authdocdate,
	COP.noauthreason,
	COP.arrivalprotocolnum,
	COP.arrivaldate,
	COP.annotations,
	COP.expiration,
	COP.cupcode,
	COP.cigcode,
	uniqueregister.iduniqueregister,
	COP.resendingpcc,
	COP.ipa_fe,
	COP.expensekind,
	COP.cu,
	COP.ct,
	COP.lu,
	COP.lt,
	COP.txt,
	case 
		when COP.expensekind='CO' then 'Spesa corrente'
		when COP.expensekind='CA' then 'Conto capitale'
		else null
	end,
	'cascon§'+ convert(varchar(10),COP.ycon) + '§'+ convert(varchar(10),COP.ncon),
	COP.datecompleted,
	COP.idsor_siope,
	COP.requested_doc 
FROM casualcontract COP (nolock)
JOIN casualcontractyear ICOP (nolock)
	ON COP.ycon = ICOP.ycon
	AND COP.ncon = ICOP.ncon
JOIN registry (nolock)
	ON registry.idreg = COP.idreg
LEFT OUTER JOIN UPB (nolock)
	ON UPB.idupb=COP.idupb
JOIN service (nolock)
	ON service.idser = COP.idser
LEFT OUTER JOIN otherinsurance AFA (nolock)
	ON AFA.idotherinsurance = ICOP.idotherinsurance
	AND AFA.ayear = ICOP.ayear 
LEFT OUTER JOIN inpsactivity API (nolock)
	ON API.activitycode = ICOP.activitycode
	AND API.ayear = ICOP.ayear
LEFT OUTER JOIN emenscontractkind ETR (nolock)
	ON ETR.idemenscontractkind = ICOP.idemenscontractkind
	AND ETR.ayear = ICOP.ayear
LEFT OUTER JOIN accmotive AM (nolock)
	ON AM.idaccmotive = COP.idaccmotive
LEFT OUTER JOIN accmotive DB (nolock)
	ON DB.idaccmotive =  COP.idaccmotivedebit
LEFT OUTER JOIN accmotive CRG (nolock)
	ON CRG.idaccmotive = COP.idaccmotivedebit_crg
LEFT OUTER JOIN uniqueregister
	ON uniqueregister.ncon = COP.ncon
	AND uniqueregister.ycon = COP.ycon
LEFT OUTER JOIN dalia_position DP
	ON DP.iddaliaposition = COP.iddaliaposition






GO
 