-- CREAZIONE VISTA mandatedetailtoinvoice
IF EXISTS(select * from sysobjects where id = object_id(N'[mandatedetailtoinvoiceyear]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatedetailtoinvoiceyear]
GO

 -- clear_table_info 'mandatedetailtoinvoiceyear'
 -- select * from [mandatedetailtoinvoiceyear]
CREATE  VIEW [mandatedetailtoinvoiceyear]
(	ayear,
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mandatekind,
	idcurrency,
	codecurrency,
	idman,
	flagintracom,
	codeinv,
	inventorytree,
	idreg,
	registry,
	detaildescription,
	ordered,
	invoiced,
	residual,
	taxrate,
	taxable,
	tax,
	discount,
	assetkind,
	start,
	stop,
	idupb,
	idupb_iva,
	idsor1,
	idsor2,
	idsor3,
	idaccmotive,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	competencystart,
	competencystop,
	toinvoice,
	linktoinvoice,
	linktoasset,
	multireg,
	flagactivity,
	idmandatestatus,
	mandatestatus,
	va3type,
	idstore,
	store,
	flagto_unload,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	epkind,exchangerate,
	unitsforpackage,
	idcostpartition,
	idepexp
)
AS SELECT 	
	MYear.ayear,
	mandatedetail.idmankind,
	mandatedetail.yman, 
	mandatedetail.nman, 
	mandatedetail.rownum, 
	mandatedetail.idgroup,
	mandatekind.description,
	mandate.idcurrency,
	currency.codecurrency,
	mandate.idman,
	mandate.flagintracom,
	inventorytree.codeinv, 
	inventorytree.description,
	mandatedetail.idreg,
	registry.title,
	mandatedetail.detaildescription, 
	ISNULL(mandatedetail.npackage,mandatedetail.number),	-- ordered
	ISNULL(
	(SELECT SUM(iv.npackage)
	  FROM (SELECT DISTINCT 
					  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
					  invoicedetail.idgroup as invidgroup,		--ripristinato a seguito di task 8409
				      isnull(invoicedetail.npackage,invoicedetail.number) as npackage,invoicedetail.idmankind,invoicedetail.yman,
				      invoicedetail.nman, mandatedetail.idgroup as manidgroup
		FROM invoicedetail 
        JOIN mandatedetail mandatedetail2
		  ON invoicedetail.idmankind = mandatedetail2.idmankind AND
		     invoicedetail.yman = mandatedetail2.yman AND
	         invoicedetail.nman = mandatedetail2.nman AND
		     invoicedetail.manrownum = mandatedetail2.rownum 
		    WHERE  invoicedetail.yinv <= MYEAR.ayear AND
					invoicedetail.idmankind = mandatedetail.idmankind AND
	               invoicedetail.yman = mandatedetail.yman AND
		           invoicedetail.nman = mandatedetail.nman AND
			       mandatedetail2.idgroup = mandatedetail.idgroup 
			) AS iv )  ,0),	-- invoiced
	ISNULL(mandatedetail.npackage, mandatedetail.number) 
	- 
	ISNULL(
	(SELECT SUM(iv.npackage)
	  FROM (SELECT DISTINCT 
					  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
					  invoicedetail.idgroup as invidgroup,		--ripristinato a seguito di task 8409
				      isnull(invoicedetail.npackage,invoicedetail.number) as npackage,invoicedetail.idmankind,invoicedetail.yman,
				      invoicedetail.nman, mandatedetail.idgroup as manidgroup
		FROM invoicedetail 
        JOIN mandatedetail mandatedetail2
		  ON invoicedetail.idmankind = mandatedetail2.idmankind AND
		     invoicedetail.yman = mandatedetail2.yman AND
	         invoicedetail.nman = mandatedetail2.nman AND
		     invoicedetail.manrownum = mandatedetail2.rownum 
		    WHERE  invoicedetail.yinv <= MYEAR.ayear AND
				  invoicedetail.idmankind = mandatedetail.idmankind AND
	               invoicedetail.yman = mandatedetail.yman AND
		           invoicedetail.nman = mandatedetail.nman AND
			       mandatedetail2.idgroup = mandatedetail.idgroup 
			) AS iv )  ,0), 	-- residual
	mandatedetail.taxrate,
	mandatedetail.taxable,
	mandatedetail.tax,
	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idupb,
	mandatedetail.idupb_iva,
	mandatedetail.idsor1,
	mandatedetail.idsor2,
	mandatedetail.idsor3,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.unabatable,
	mandatedetail.flagmixed,
	mandatedetail.competencystart,
	mandatedetail.competencystop,
	mandatedetail.toinvoice,
	mandatekind.linktoinvoice,
	mandatekind.linktoasset,
	mandatekind.multireg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.va3type,
	mandate.idstore,
	store.description,
	mandatedetail.flagto_unload,
	mandate.idsor01,mandate.idsor02,mandate.idsor03,mandate.idsor04,mandate.idsor05,
	mandatedetail.epkind,mandate.exchangerate,
	mandatedetail.unitsforpackage,
	mandatedetail.idcostpartition,
	mandatedetail.idepexp
FROM mandatedetail with (nolock) 
JOIN mandatekind  with (nolock)					ON mandatekind.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN inventorytree  with (nolock)	ON inventorytree.idinv = mandatedetail.idinv
INNER JOIN mandate   with (nolock)				ON mandate.idmankind = mandatedetail.idmankind
														AND mandate.yman = mandatedetail.yman
														AND mandate.nman = mandatedetail.nman
LEFT OUTER JOIN currency  with (nolock)			ON mandate.idcurrency = currency.idcurrency
JOIN ivakind  with (nolock)						ON ivakind.idivakind = mandatedetail.idivakind
LEFT OUTER JOIN mandatestatus  with (nolock)	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
LEFT OUTER JOIN store   with (nolock)			ON store.idstore = mandate.idstore
left outer join registry (nolock)	on registry.idreg  = mandatedetail.idreg
CROSS JOIN mainaccountingyear MYEAR
WHERE mandatedetail.stop is null








GO
