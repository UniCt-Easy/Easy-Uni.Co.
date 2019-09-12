-- CREAZIONE VISTA mandateresidual
IF EXISTS(select * from sysobjects where id = object_id(N'[mandateresidual]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandateresidual]
GO


--setuser 'amm'
-- clear_table_info 'mandateresidual'
--select * from mandateresidual
CREATE     VIEW [mandateresidual]
	(
	idmankind,	
	yman,
	nman,
	mankind,
	description,
	idreg,
	idupb,
	idupb_iva,
	idman,
	manager,
	registry,
	taxabletotal,
	ivatotal,
	residual,
	linkedimpon,
	linkedimpos,
	linkedordin,
	active,
	upb,
	upb_iva,
	flagintracom,
	idmandatestatus,
	mandatestatus,
	isrequest,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	subappropriation,
	finsubappropriation,
	adatesubappropriation
	)
AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatekind.description,
	mandate.description,
	mandatedetail.idreg,
	mandatedetail.idupb,
	mandatedetail.idupb_iva,
	mandate.idman,
	manager.title,
	registry.title,	
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(  ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)
	   ),0)
	),
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(ROUND(mandatedetail.tax,2)
	   ),0)
	),
	--residuo :somma dei dett. ordine non contabilizzati
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN  (mandatedetail.idexp_taxable IS  NULL) AND (mandate.flagintracom<>'N')
			THEN
			     ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)

			WHEN (mandatedetail.idexp_taxable IS  NULL) AND (mandatedetail.idexp_iva IS  NOT NULL)   AND (mandate.flagintracom='N')
			THEN
			     ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)

			WHEN ( mandatedetail.idexp_iva IS NULL) AND (mandatedetail.idexp_taxable IS  NOT NULL) AND (mandate.flagintracom='N')
			THEN
			    ROUND(mandatedetail.tax,2)

			WHEN ( mandatedetail.idexp_iva IS  NULL) AND (mandatedetail.idexp_taxable IS  NULL) AND (mandate.flagintracom='N')
			THEN
			     ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2) 
			     +
			     ROUND(mandatedetail.tax,2)
			ELSE   0

		    END
		   ),0)
		),
-- (mov.movkind = '3' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (mandatedetail.idexp_taxable IS NOT NULL 
				AND (mandatedetail.idexp_iva IS NULL OR mandatedetail.idexp_taxable<>mandatedetail.idexp_iva)) 
			THEN
			      ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		),

-- (mov.movkind = '2')
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (mandatedetail.idexp_iva IS NOT NULL 
				AND  (mandatedetail.idexp_taxable IS NULL OR mandatedetail.idexp_taxable<>mandatedetail.idexp_iva)) 
			THEN
			       ROUND(mandatedetail.tax ,2)
			ELSE   0
		    END
			
		   ),0)
		),
	
--  (mov.movkind = '1' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (mandatedetail.idexp_taxable IS NOT NULL AND mandatedetail.idexp_iva= mandatedetail.idexp_taxable)
			THEN
	  		     ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2) 
			     +
			     ROUND(mandatedetail.tax,2)			
			ELSE   0
		    END
		   ),0)
		),

	mandate.active,
	upb.title,
	upb_iva.title,
	mandate.flagintracom,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatekind.isrequest,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,
	mandate.subappropriation,
	mandate.finsubappropriation,
	mandate.adatesubappropriation
FROM mandatedetail (NOLOCK)
JOIN mandate (NOLOCK)
  	ON mandatedetail.idmankind = mandate.idmankind
	AND mandatedetail.yman = mandate.yman
  	AND mandatedetail.nman = mandate.nman
JOIN mandatekind  (NOLOCK) 	ON mandatekind.idmankind = mandate.idmankind 
LEFT OUTER JOIN upb  (NOLOCK)	on upb.idupb=mandatedetail.idupb
LEFT OUTER JOIN upb as upb_iva		ON upb_iva.idupb=mandatedetail.idupb_iva
LEFT OUTER JOIN manager  (NOLOCK)	on mandate.idman= manager.idman
LEFT OUTER JOIN mandatestatus   (NOLOCK)	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
left outer join registry on registry.idreg= mandatedetail.idreg
WHERE mandatedetail.stop is null
GROUP BY mandatedetail.idmankind, mandatedetail.yman, mandatedetail.nman,
	mandate.idreg,mandatedetail.idreg, mandatedetail.idupb,mandatedetail.idupb_iva,
	mandatekind.description,mandate.description,mandate.idman, manager.title,
	mandate.active, upb.title, upb_iva.title, mandate.flagintracom, mandate.idmandatestatus, 
      mandatestatus.description,mandatekind.isrequest,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,
	mandate.subappropriation, mandate.finsubappropriation,mandate.adatesubappropriation,registry.title

GO
