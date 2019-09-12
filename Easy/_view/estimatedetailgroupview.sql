-- CREAZIONE VISTA estimatedetailgroupview
IF EXISTS(select * from sysobjects where id = object_id(N'[estimatedetailgroupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimatedetailgroupview]
GO




--setuser 'amm'
--clear_table_info 'estimatedetailgroupview'
--select * from estimatedetailgroupview
CREATE  VIEW [estimatedetailgroupview]
(
	idestimkind,
	yestim,
	nestim,
	idgroup,
	estimkind,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	start,
	stop,
	taxable_euro,
	iva_euro,
	idaccmotive,
	idivakind,
	ivakind,
	toinvoice,
	exchangerate,
	linktoinvoice,
	multireg,
	estimateidreg,
	estimatedetailidreg
	--,	cigcode
)
AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatedetail.idgroup,
	estimatekind.description,
 	estimatedetail.idreg,
	registry.title, 	
	estimatedetail.detaildescription,
	estimatedetail.annotations,
	estimatedetail.number,
	ISNULL(SUM(estimatedetail.taxable),0), 	
	estimatedetail.taxrate,
	ISNULL(SUM(estimatedetail.tax),0), 
  	estimatedetail.discount,
	estimatedetail.start,
	estimatedetail.stop,
	Round(
	(SELECT  ROUND(ISNULL(SUM(MD1.taxable),0),2)
	FROM estimatedetail MD1
	JOIN estimate M1			ON M1.yestim = MD1.yestim AND M1.nestim = MD1.nestim AND M1.idestimkind = MD1.idestimkind
	WHERE M1.idestimkind = estimatedetail.idestimkind
		AND M1.yestim = estimatedetail.yestim 
		AND M1.nestim = estimatedetail.nestim
		AND MD1.idgroup = estimatedetail.idgroup)
	 * ISNULL(estimatedetail.number,0)   * CONVERT(DECIMAL(19,6),estimate.exchangerate)  
	 * (1 - CONVERT(DECIMAL(19,6),ISNULL(estimatedetail.discount, 0.0)))
	,2)
	,
	isnull(sum(
		ROUND(estimatedetail.tax,2)
	),0) ,

	estimatedetail.idaccmotive,
	estimatedetail.idivakind,
	ivakind.description,
	estimatedetail.toinvoice,
	estimate.exchangerate,
	estimatekind.linktoinvoice,
	estimatekind.multireg,
	estimate.idreg,estimatedetail.idreg
	--,	isnull(estimatedetail.cigcode,estimate.cigcode)
FROM estimatedetail
JOIN estimatekind			ON estimatekind.idestimkind = estimatedetail.idestimkind
JOIN estimate				ON estimate.yestim = estimatedetail.yestim
								AND estimate.nestim = estimatedetail.nestim
								AND estimate.idestimkind = estimatedetail.idestimkind
JOIN ivakind				ON ivakind.idivakind = estimatedetail.idivakind
left outer join registry on registry.idreg=estimatedetail.idreg
GROUP BY 
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatedetail.idgroup,
	estimatekind.description,
 	estimate.idreg,
	estimatedetail.detaildescription,
	estimatedetail.annotations,
	estimatedetail.number,
	estimatedetail.taxrate,
  	estimatedetail.discount,
	estimatedetail.start,
	estimatedetail.stop,
	estimatedetail.idaccmotive,
	estimatedetail.idivakind,
	ivakind.description,
	estimatedetail.toinvoice,
	estimate.exchangerate,
	estimatekind.linktoinvoice,
	estimatekind.multireg,
	estimate.idreg,
	estimatedetail.idreg,
	--isnull(estimatedetail.cigcode,estimate.cigcode),
	registry.title


GO
