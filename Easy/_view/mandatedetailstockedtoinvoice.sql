-- CREAZIONE VISTA mandatedetailstockedtoinvoice
IF EXISTS(select * from sysobjects where id = object_id(N'[mandatedetailstockedtoinvoice]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatedetailstockedtoinvoice]
GO

/* usato per prendere merce  preceduta da DDT */
/* Calcola il residuo in modo diverso in base al fatto che sia merce di magazzino oppureno
    se non di magazzino:
		= ordinato  - fatturato
	se di magazzino:
		= somma di quanto c'è in magazzino associato al dettaglio ordine ma non fatturato

	Attenzione: non deve prendere la merce di magazzino, quella sarà presa indicando direttamente 
	la bolla
  */
/* va bene anche per merce non di magazzino */

-- setuser 'amm'
-- clear_table_info'mandatedetailstockedtoinvoice'
-- select * from mandatedetailstockedtoinvoice
CREATE  VIEW [mandatedetailstockedtoinvoice]
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mandatekind,
	idcurrency,
	codecurrency,
	cigcode,cupcode,
	idman,
	flagintracom,
	codeinv,
	inventorytree,
	idreg,
	registry,
	detaildescription,
	ordered,
	ddt,
	residual,
	taxrate,
	taxable,
	tax,
	discount,
	npackage,
	number,
	assetkind,
	start,
	stop,
	idupb,
	idupb_iva,
	idsor1,
	idsor2,
	idsor3,
	idcostpartition,
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
	flagto_unload,
	idstore,
	store,
	idlist,
	list,
	idunit,
	idpackage,
	unitsforpackage,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	epkind,
	expensekind,
	idepexp,
	idsor_siope,
	requested_doc
)
AS SELECT 	
	mandatedetail.idmankind,
	mandatedetail.yman, 
	mandatedetail.nman, 
	mandatedetail.rownum, 
	mandatedetail.idgroup,
	mandatekind.description,
	mandate.idcurrency,
	currency.codecurrency,
	mandatedetail.cigcode,mandatedetail.cupcode,
	mandate.idman,
	mandate.flagintracom,
	inventorytree.codeinv, 
	inventorytree.description,
	mandatedetail.idreg,
	registry.title,
	mandatedetail.detaildescription, 
	ISNULL(mandatedetail.npackage,mandatedetail.number),	-- ordered
	isnull((select sum(S.number) from stock S 
				where S.idmankind=mandatedetail.idmankind
				AND S.yman=mandatedetail.yman AND S.nman=mandatedetail.nman
				AND S.man_idgroup= mandatedetail.idgroup
				AND S.idddt_in is not null
				)
		,0)
	,     --ddt 
	case when mandatedetail.idlist is null then
		 ISNULL(mandatedetail.npackage, mandatedetail.number) 
	- ISNULL(
	(SELECT SUM(iv.number)
	  FROM (SELECT DISTINCT 
					  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
					  invoicedetail.idgroup as invidgroup,
					  --invoicedetail.rownum as rownum,			--task 8206
				      invoicedetail.number,invoicedetail.idmankind,invoicedetail.yman,
				      invoicedetail.nman, mandatedetail.idgroup as manidgroup
		FROM invoicedetail 
        JOIN mandatedetail mandatedetail2
		  ON invoicedetail.idmankind = mandatedetail2.idmankind AND
		     invoicedetail.yman = mandatedetail2.yman AND
	         invoicedetail.nman = mandatedetail2.nman AND
		     invoicedetail.manrownum = mandatedetail2.rownum 
		    WHERE  invoicedetail.idmankind = mandatedetail.idmankind AND
	               invoicedetail.yman = mandatedetail.yman AND
		           invoicedetail.nman = mandatedetail.nman AND
			       mandatedetail2.rownum = mandatedetail.rownum 
			) AS iv )  ,0)
	ELSE
   		isnull((select sum(S.number) from stock S 

				where S.idmankind=mandatedetail.idmankind
				AND S.yman=mandatedetail.yman AND S.nman=mandatedetail.nman
				AND S.man_idgroup= mandatedetail.idgroup
				AND S.idddt_in is not null
				AND S.idinvkind is null
				),0)
	END
,     --residual

	mandatedetail.taxrate,
	mandatedetail.taxable,
	mandatedetail.tax,
	mandatedetail.discount,
	mandatedetail.npackage,
	mandatedetail.number,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idupb,
	mandatedetail.idupb_iva,
	mandatedetail.idsor1,
	mandatedetail.idsor2,
	mandatedetail.idsor3,
	mandatedetail.idcostpartition,
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
	mandatedetail.flagto_unload,
	mandate.idstore,
	store.description  ,
	LIST.idlist,
	LIST.description,
	mandatedetail.idunit,
	mandatedetail.idpackage,
	mandatedetail.unitsforpackage,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,
	mandatedetail.epkind,
	isnull(mandatedetail.expensekind, accmotive. expensekind),
	mandatedetail.idepexp,
	mandatedetail.idsor_siope,
	mandate.requested_doc
FROM mandatedetail (NOLOCK)
JOIN mandatekind	(NOLOCK)		ON mandatekind.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN LIST	(NOLOCK)	ON mandatedetail.idlist= LIST.idlist
LEFT OUTER JOIN inventorytree (NOLOCK) ON inventorytree.idinv = mandatedetail.idinv
left outer join registry (NOLOCK) on mandatedetail.idreg=registry.idreg
INNER JOIN mandate	(NOLOCK)	ON mandate.idmankind = mandatedetail.idmankind
						AND mandate.yman = mandatedetail.yman
						AND mandate.nman = mandatedetail.nman
LEFT OUTER JOIN currency (NOLOCK)	ON mandate.idcurrency = currency.idcurrency
JOIN ivakind	(NOLOCK)			ON ivakind.idivakind = mandatedetail.idivakind
LEFT OUTER JOIN mandatestatus (NOLOCK)		ON mandatestatus.idmandatestatus = mandate.idmandatestatus
LEFT OUTER JOIN store (NOLOCK)	ON store.idstore = mandate.idstore
LEFT OUTER JOIN accmotive	(NOLOCK)	on accmotive.idaccmotive = mandatedetail.idaccmotive 
WHERE mandatedetail.stop is null			AND mandatedetail.idlist is null

		
 