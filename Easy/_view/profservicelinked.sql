-- CREAZIONE VISTA profservicelinked
IF EXISTS(select * from sysobjects where id = object_id(N'[profservicelinked]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [profservicelinked]
GO


--setuser 'amministrazione'
--clear_table_info 'profservicelinked'
--select * from profservicelinked


CREATE VIEW [profservicelinked]
(
	ayear,
	ycon,
	ncon,
	socialsecurityrate,
	pensioncontributionrate,
	ivarate,
	idreg,
	registry,
	idser,
	service,
	codeser,
	feegross,
	totalcost,
	totalgross,
	adate,
	stop,
	start,
	ndays,
	ivaamount,
	idupb,
	codeupb,
	upb,
	cu,
	ct,
	lu,
	lt,
	ivafieldnumber,
	txt,
	rtf,
	description,
	docdate,
	doc,
	flaginvoiced,
	idinvkind,
	yinv,
	ninv,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT
	accountingyear.ayear,
	profservice.ycon,
	profservice.ncon,
	profservice.socialsecurityrate,
	profservice.pensioncontributionrate,
	profservice.ivarate,
	profservice.idreg,
	registry.title,
	profservice.idser,
	service.description,
	service.codeser,
	profservice.feegross,
	profservice.totalcost,
	profservice.totalgross,
	profservice.adate,
	profservice.stop,
	profservice.start,
	profservice.ndays,
	profservice.ivaamount,
	profservice.cu,
	profservice.ct,
	profservice.lu,
	profservice.lt,
	profservice.ivafieldnumber,
	upb.idupb,
	upb.codeupb,
	upb.title,
	profservice.txt,
	profservice.rtf,
	profservice.description,
	profservice.docdate,
	profservice.doc,
	profservice.flaginvoiced,
	profservice.idinvkind,
	profservice.yinv,
	profservice.ninv,
	profservice.idsor01,profservice.idsor02,profservice.idsor03,profservice.idsor04,profservice.idsor05
FROM profservice with (nolock)
JOIN service with (nolock)
	ON profservice.idser = service.idser
JOIN registry with (nolock)
	ON profservice.idreg = registry.idreg
LEFT OUTER JOIN upb with (nolock)
	ON upb.idupb = profservice.idupb
CROSS JOIN accountingyear (nolock)
WHERE EXISTS (SELECT * FROM expenseprofservice JOIN expenseyear with (nolock) ON expenseyear.idexp = expenseprofservice.idexp Where expenseprofservice.ycon = profservice.ycon and expenseprofservice.ncon = profservice.ncon and expenseyear.ayear = accountingyear.ayear)


GO
--setuser 'amm'
--clear_table_info 'profservice,profservicelinked,profserviceresidual,profserviceavailable,profserviceview'
--select * from autokind
