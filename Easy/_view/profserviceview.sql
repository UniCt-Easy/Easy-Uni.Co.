-- CREAZIONE VISTA profserviceview
IF EXISTS(select * from sysobjects where id = object_id(N'[profserviceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [profserviceview]
GO

-- setuser 'amm'
-- clear_table_info 'profserviceview'
-- select * from profserviceview
CREATE VIEW [profserviceview]
(
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
	feegross,
	idser,
	service,
	codeser,
	description,
	idivakind,
	ivakind,
	ivarate,
	ndays,
	ivaamount,
	totalcost, --costo totale
	totalgross,  --lordo al beneficiario
	taxabletotal, --totale imponibile
	cu,
	ct,
	lu,
	lt,
	ivafieldnumber,
	pensioncontributionrate,
	socialsecurityrate,
	txt,
	doc,
	docdate,
	idinvkind,
	codeinvkind,
	invkind,
	flaginvoiced,
	yinv,
	ninv,
	idaccmotive,
	codemotive,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	idsor1,
	idsor2,
	idsor3,
	idupb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	authneeded,
	authdoc,
	authdocdate,
	noauthreason,
	idrelated,
	epkind,
	idsor_siope,
	requested_doc
)
AS SELECT 
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
	COP.feegross,
	COP.idser,
	service.description,
	service.codeser,
	COP.description,
	COP.idivakind,
	ivakind.description,
	COP.ivarate,
	COP.ndays,
	COP.ivaamount,
	COP.totalcost,
	COP.totalgross,  --lordo al beneficiario
	COP.totalgross - COP.ivaamount,  --totale imponibile
	COP.cu,
	COP.ct,
	COP.lu,
	COP.lt,
	COP.ivafieldnumber,
	COP.pensioncontributionrate,
	COP.socialsecurityrate,
	COP.txt,
	COP.doc,
	COP.docdate,
	COP.idinvkind,
	IK.codeinvkind,
	IK.description,
	COP.flaginvoiced,
	COP.yinv,
	COP.ninv,
	COP.idaccmotive,
	AM.codemotive,
	COP.idaccmotivedebit,
	DB.codemotive,
	COP.idaccmotivedebit_crg,
	CRG.codemotive,
	COP.idaccmotivedebit_datacrg,
	COP.idsor1,
	COP.idsor2,
	COP.idsor3,
	COP.idupb,
	isnull(COP.idsor01,UPB.idsor01),
	isnull(COP.idsor02,UPB.idsor02),
	isnull(COP.idsor03,UPB.idsor03),
	isnull(COP.idsor04,UPB.idsor04),
	isnull(COP.idsor05,UPB.idsor05),
	COP.authneeded,
	COP.authdoc,
	COP.authdocdate,
	COP.noauthreason,
	'profservice§'+ convert(varchar(10),COP.ycon) + '§'+ convert(varchar(10),COP.ncon) ,
	COP.epkind,
	COP.idsor_siope,
	COP.requested_doc
FROM profservice COP  with (nolock)
left OUTER JOIN ivakind with (nolock)		ON ivakind.idivakind = COP.idivakind
LEFT OUTER JOIN registry with (nolock)		ON registry.idreg = COP.idreg
LEFT OUTER JOIN service with (nolock)		ON service.idser = COP.idser
LEFT OUTER JOIN invoice I with (nolock)		ON COP.idinvkind = I.idinvkind
											AND COP.yinv = I.yinv	AND COP.ninv = I.ninv
LEFT OUTER JOIN invoicekind IK with (nolock)	ON I.idinvkind = IK.idinvkind
LEFT OUTER JOIN accmotive AM with (nolock)		ON AM.idaccmotive = COP.idaccmotive
LEFT OUTER JOIN accmotive DB with (nolock)		ON DB.idaccmotive =  COP.idaccmotivedebit
LEFT OUTER JOIN accmotive CRG with (nolock)		ON CRG.idaccmotive = COP.idaccmotivedebit_crg
LEFT OUTER JOIN upb with (nolock)				ON upb.idupb = COP.idupb
LEFT OUTER JOIN dalia_position DP				ON DP.iddaliaposition = COP.iddaliaposition

GO
 
 