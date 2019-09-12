-- CREAZIONE VISTA estimatelinked
IF EXISTS(select * from sysobjects where id = object_id(N'[estimatelinked]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimatelinked]
GO






--setuser 'amm'
--clear_table_info 'estimatelinked'
--select * from estimatelinked
CREATE         VIEW [estimatelinked]
(
	ayear,
	idestimkind, yestim, nestim, estimkind,
	idreg, registry, registryreference, idman, 
	manager,	
	description, deliveryexpiration, deliveryaddress, paymentexpiring, 
	idexpirationkind, idcurrency, 	codecurrency, currency,
	exchangerate, doc, docdate, adate, officiallyprinted,	
	cu, ct, lu, lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cigcode
)
AS
SELECT
	accountingyear.ayear,
	estimate.idestimkind, estimate.yestim, estimate.nestim, estimatekind.description,
	estimate.idreg, registry.title, estimate.registryreference, estimate.idman, 
	manager.title,
	estimate.description, deliveryexpiration,
	deliveryaddress, paymentexpiring, 
	idexpirationkind, estimate.idcurrency, currency.codecurrency,
	currency.description,
	estimate.exchangerate, estimate.doc, 
	estimate.docdate, adate, officiallyprinted,

	estimate.cu, estimate.ct, estimate.lu, estimate.lt,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05,
	estimate.cigcode
FROM estimate (NOLOCK)
JOIN estimatekind (NOLOCK)				ON estimatekind.idestimkind = estimate.idestimkind
LEFT OUTER JOIN registry (NOLOCK)		ON registry.idreg = estimate.idreg
LEFT OUTER JOIN currency (NOLOCK)		ON currency.idcurrency = estimate.idcurrency
LEFT OUTER JOIN manager (NOLOCK)		ON manager.idman = estimate.idman
CROSS JOIN accountingyear (NOLOCK)	
	WHERE EXISTS (SELECT * FROM incomeestimate AS MM 
			JOIN incomeyear II			  ON II.idinc=MM.idinc
												 AND MM.idestimkind = estimate.idestimkind
												 AND MM.yestim=estimate.yestim
												 AND MM.nestim=estimate.nestim
		      WHERE  II.ayear = accountingyear.ayear) 
			
GO

