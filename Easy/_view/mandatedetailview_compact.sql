-- CREAZIONE VISTA mandatedetailview_compact
IF EXISTS(select * from sysobjects where id = object_id(N'[mandatedetailview_compact]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatedetailview_compact]
GO



CREATE      VIEW [mandatedetailview_compact]

(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	idreg,
	detaildescription,
	annotations,
	number,
	npackage,
	taxable,
	taxrate,
	tax,
  	discount,
	start,
	stop,
	idexp_taxable,
	idexp_iva,	
	taxable_euro,
	iva_euro,
	rowtotal,
	idupb,
	idepexp,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.rownum,
	mandatedetail.idgroup,
	mandatedetail.idreg,
  	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	mandatedetail.npackage,
	mandatedetail.taxable,
	mandatedetail.taxrate,
	mandatedetail.tax,
  	mandatedetail.discount,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idexp_taxable,
	mandatedetail.idexp_iva,
 	    ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		),
	ROUND(mandatedetail.tax,2),
	ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		)+
	ROUND(mandatedetail.tax,2),
	mandatedetail.idupb,
	mandatedetail.idepexp,
	mandatedetail.cu,
	mandatedetail.ct,
	mandatedetail.lu,
	mandatedetail.lt
FROM mandatedetail
JOIN mandate
	ON mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
	AND mandate.idmankind = mandatedetail.idmankind

GO
