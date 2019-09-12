-- CREAZIONE VISTA estimateview
IF EXISTS(select * from sysobjects where id = object_id(N'[estimateview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimateview]
GO



--setuser 'amm'
--select * from estimateview
CREATE    VIEW [estimateview]
(
	idestimkind,
	yestim,
	nestim,
	estimkind,
	idreg,
	registry,
	registryreference,
	description,
	idman,
	manager,
	deliveryexpiration,
	deliveryaddress,
	paymentexpiring,
	idexpirationkind,
	idcurrency,
	codecurrency,
	currency,
	exchangerate,
	doc,
	docdate,
	adate,
	officiallyprinted,
	txt,
	cu, 
	ct, 
	lu, 
	lt,
	taxable_euro,
	iva_euro,
	total,
	active,
	flagintracom,
	idaccmotivecredit,
	codemotivecredit,
	idaccmotivecredit_crg,
	codemotivecredit_crg,
	idaccmotivecredit_datacrg,
	idunderwriting,
	underwriting,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	expirationkind,
	expiration,
	external_reference,
	cigcode	
)
	AS SELECT
	estimate.idestimkind,
	estimate.yestim,
	estimate.nestim,
	estimatekind.description,
	estimate.idreg,
	registry.title,
	estimate.registryreference,
	estimate.description,
	estimate.idman,
	manager.title,
	estimate.deliveryexpiration,
	estimate.deliveryaddress,
	estimate.paymentexpiring,
	estimate.idexpirationkind,
	estimate.idcurrency,
	currency.codecurrency,
	currency.description,
	estimate.exchangerate,
	estimate.doc,
	estimate.docdate,
	estimate.adate,
	estimate.officiallyprinted,
	estimate.txt,
	estimate.cu, 
	estimate.ct, 
	estimate.lu, 
	estimate.lt,
	-- taxable_euro
	ISNULL(
		(SELECT
			SUM(
				ROUND(estimatedetail.taxable * estimatedetail.number * 
					CONVERT(decimal(19,6), m.exchangerate) *
					(1 - CONVERT(decimal(19,6), ISNULL(estimatedetail.discount, 0.0)))
				,2)
			)
		FROM estimatedetail
		JOIN estimate m
			ON estimatedetail.idestimkind = estimate.idestimkind
			AND estimatedetail.yestim = estimate.yestim
			AND estimatedetail.nestim = estimate.nestim
		WHERE m.idestimkind = estimate.idestimkind
			AND m.yestim = estimate.yestim
			AND m.nestim = estimate.nestim
			AND estimatedetail.stop IS NULL
		)
	,0),
	-- iva_euro
	ISNULL(
		(SELECT
			SUM(
				ROUND(estimatedetail.tax * CONVERT(decimal(19,6), m.exchangerate),2)
			)
		FROM estimatedetail
		JOIN estimate m
			ON estimatedetail.idestimkind = estimate.idestimkind
			AND estimatedetail.yestim = estimate.yestim
			AND estimatedetail.nestim = estimate.nestim
		WHERE m.idestimkind = estimate.idestimkind
			AND m.yestim = estimate.yestim
			AND m.nestim = estimate.nestim
			AND estimatedetail.stop IS NULL
		)
	,0),
	-- total
	ISNULL(
		(SELECT
			SUM(
				ISNULL(
					ROUND(estimatedetail.taxable * estimatedetail.number * 
						CONVERT(decimal(19,6), m.exchangerate) *
						(1 - CONVERT(decimal(19,6), ISNULL(estimatedetail.discount, 0.0)))
					,2)
				,0) +
				ISNULL(
					ROUND(estimatedetail.tax * CONVERT(decimal(19,6), m.exchangerate),2)
				,0)
			)
		FROM estimatedetail
		JOIN estimate m
			ON estimatedetail.idestimkind = estimate.idestimkind
			AND estimatedetail.yestim = estimate.yestim
			AND estimatedetail.nestim = estimate.nestim
		WHERE m.idestimkind = estimate.idestimkind
			AND m.yestim = estimate.yestim
			AND m.nestim = estimate.nestim
			AND estimatedetail.stop IS NULL
		)
	,0),
	estimate.active,
	estimate.flagintracom,
	AC.idaccmotive,
	AC.codemotive,
	ACCRG.idaccmotive,
	ACCRG.codemotive,
	estimate.idaccmotivecredit_datacrg,
	estimate.idunderwriting,
	underwriting.title	,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05,
	expirationkind.description,
	dateadd(day,isnull(estimate.paymentexpiring,0),
	case 
		when (estimate.idexpirationkind=1) then estimate.adate
		when (estimate.idexpirationkind=2) then estimate.docdate
		when (estimate.idexpirationkind=3) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(estimate.docdate) ,estimate.docdate)))
		when (estimate.idexpirationkind=4) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(estimate.adate) ,estimate.adate)))
		when (estimate.idexpirationkind=5) then estimate.adate
		when (estimate.idexpirationkind=6) then estimate.adate
	end
	),
	estimate.external_reference,
	estimate.cigcode
FROM estimate  with (nolock)
JOIN estimatekind  with (nolock)			ON estimatekind.idestimkind = estimate.idestimkind
LEFT OUTER JOIN registry with (nolock)		ON registry.idreg = estimate.idreg
LEFT OUTER JOIN currency with (nolock)		ON currency.idcurrency = estimate.idcurrency
LEFT OUTER JOIN manager  with (nolock)		ON manager.idman = estimate.idman
LEFT OUTER JOIN accmotive AC with (nolock)	ON AC.idaccmotive = estimate.idaccmotivecredit
LEFT OUTER JOIN accmotive ACCRG with (nolock)	ON ACCRG.idaccmotive = estimate.idaccmotivecredit_crg
LEFT OUTER JOIN underwriting with (nolock)		ON underwriting.idunderwriting = estimate.idunderwriting
LEFT OUTER JOIN expirationkind					ON estimate.idexpirationkind = expirationkind.idexpirationkind




GO

