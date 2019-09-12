-- CREAZIONE VISTA wageadditionview
IF EXISTS(select * from sysobjects where id = object_id(N'[wageadditionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [wageadditionview]
GO
 -- clear_table_info'wageadditionview'
CREATE VIEW [wageadditionview]
(
	ayear,
	ycon,
	ncon,
	start,
	stop,
	adate,
	idreg,
	registry,
	feegross,
	idser,
	service,
	codeser,
	description,
	ndays,
	idposition,
	position,
	iddaliaposition,
	codedaliaposition,
	daliaposition,
	idcontractlength,
	contractlength,
	idworkingtime,
	workingtime,
	idaccmotive,
	codemotive,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idsor1,
	idsor2,
	idsor3,
	authneeded,
	authdoc,
	authdocdate,
	noauthreason,
	idreg_distrained,
	registry_distrained,
	cu,
	ct,
	lu,
	lt,
	txt,
	completed,
	idrelated,
	idsor_siope
)
AS SELECT 
	ICD.ayear,
	CD.ycon,
	CD.ncon,
	CD.start,
	CD.stop,
	CD.adate,
	CD.idreg,
	registry.title as registry,
	CD.feegross,
	CD.idser,
	service.description,
	service.codeser,
	CD.description,
	CD.ndays,
	ICD.idposition,
	QR.description AS position,
	DP.iddaliaposition,
	DP.codedaliaposition,
	DP.description,
	ICD.idcontractlength,
	DR.description AS contractlength,
	ICD.idworkingtime,
	ORAP.description AS workingtime,
	CD.idaccmotive,
	AM.codemotive,
	CD.idaccmotivedebit,
	DB.codemotive,
	CD.idaccmotivedebit_crg,
	CRG.codemotive,
	CD.idaccmotivedebit_datacrg,
	CD.idupb,
	upb.codeupb,
	upb.title,
	isnull(CD.idsor01,UPB.idsor01),
	isnull(CD.idsor02,UPB.idsor02),
	isnull(CD.idsor03,UPB.idsor03),
	isnull(CD.idsor04,UPB.idsor04),
	isnull(CD.idsor05,UPB.idsor05),
	CD.idsor1,
	CD.idsor2,
	CD.idsor3,
	CD.authneeded,
	CD.authdoc,
	CD.authdocdate,
	CD.noauthreason,
	RD.idreg,
	RD.title,
	CD.cu,
	CD.ct,
	CD.lu,
	CD.lt,
	CD.txt,
	CD.completed,
	'wageadd§'+ convert(varchar(10),CD.ycon) + '§'+ convert(varchar(10),CD.ncon) ,
	CD.idsor_siope
FROM wageaddition CD
JOIN wageadditionyear ICD
	ON CD.ycon = ICD.ycon
	AND CD.ncon = ICD.ncon
JOIN registry
	ON registry.idreg = CD.idreg
JOIN service
	ON service.idser = CD.idser
LEFT OUTER JOIN upb
	ON upb.idupb=CD.idupb
LEFT OUTER JOIN positionworkcontract QR
	ON QR.idposition = ICD.idposition
	AND QR.ayear = ICD.ayear
LEFT OUTER JOIN contractlength DR
	ON DR.idcontractlength = ICD.idcontractlength
	AND DR.ayear = ICD.ayear
LEFT OUTER JOIN workingtime ORAP
	ON ORAP.idworkingtime = ICD.idworkingtime
	AND ORAP.ayear = ICD.ayear
LEFT OUTER JOIN accmotive AM
	ON AM.idaccmotive = CD.idaccmotive
LEFT OUTER JOIN accmotive DB
	ON DB.idaccmotive =  CD.idaccmotivedebit
LEFT OUTER JOIN accmotive CRG
	ON CRG.idaccmotive = CD.idaccmotivedebit_crg
LEFT OUTER JOIN registry RD
	ON RD.idreg = CD.idreg_distrained
LEFT OUTER JOIN dalia_position DP
	ON DP.iddaliaposition = CD.iddaliaposition


GO

