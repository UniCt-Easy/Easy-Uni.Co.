-- CREAZIONE VISTA mandategroupview
IF EXISTS(select * from sysobjects where id = object_id(N'[mandategroupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandategroupview]
GO


--setuser 'amm'
--select  * from mandategroupview
CREATE     VIEW [mandategroupview]
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mankind,
	idinv,
	codeinv,
	inventorytree,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	assetkind,
	start,
	stop,
	idexp_taxable,
	idexp_iva,	
	taxable_euro,
	iva_euro,
	idupb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idman,
	cu,
	ct,
	lu,
	lt,
	idaccmotive,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	toinvoice,
	exchangerate
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.rownum,
	mandatedetail.idgroup,
	mandatekind.description,
	mandatedetail.idinv,
	inventorytree.codeinv,
	inventorytree.description,
 	mandatedetail.idreg,
  	registry.title,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	mandatedetail.taxable,
	mandatedetail.taxrate,
	mandatedetail.tax,
  	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idexp_taxable,
	mandatedetail.idexp_iva,
 	    ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		),
	ROUND(mandatedetail.tax,2),
	mandatedetail.idupb,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,
	mandate.idman,
	mandatedetail.cu,
	mandatedetail.ct,
	mandatedetail.lu,
	mandatedetail.lt,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.unabatable,
	mandatedetail.flagmixed,
	mandatedetail.toinvoice,
	mandate.exchangerate
FROM mandatedetail  (nolock)
JOIN mandatekind with (nolock)		ON mandatekind.idmankind = mandatedetail.idmankind
LEFT JOIN inventorytree		 (nolock)	ON inventorytree.idinv = mandatedetail.idinv
LEFT OUTER JOIN upb	 (nolock)				ON upb.idupb = mandatedetail.idupb
JOIN ivakind		 (nolock)				ON ivakind.idivakind = mandatedetail.idivakind
JOIN mandate  (nolock)
											ON mandate.yman = mandatedetail.yman
											AND mandate.nman = mandatedetail.nman
											AND mandate.idmankind = mandatedetail.idmankind
JOIN registry	 (nolock)		ON registry.idreg = mandatedetail.idreg





GO
