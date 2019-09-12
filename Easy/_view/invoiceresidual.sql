-- CREAZIONE VISTA invoiceresidual
IF EXISTS(select * from sysobjects where id = object_id(N'[invoiceresidual]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoiceresidual]
GO


CREATE     VIEW [invoiceresidual]
(
	idinvkind,
	codeinvkind,
	yinv,
	ninv,
	description,
	idreg,
	doc,
	docdate,
	idupb,
	registry,
	taxabletotal,
	ivatotal,
	residual,
	linkedimpon,
	linkedimpos,
	linkeddocum,
	flag,
	flagbuysell,
	flagvariation,
	ycon,
	ncon,
	active,
	upb,
	flagintracom,
	flag_enable_split_payment,
	idupb_iva,
	upb_iva,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	flagbit
)
	AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoice.yinv,
	invoice.ninv,
	invoice.description,
	invoice.idreg,
	invoice.doc,
	invoice.docdate,
	invoicedetail.idupb,	
	registry.title,			--registry
	CONVERT(DECIMAL(19,2),  
		ISNULL(SUM(  ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	   ),0)
	),    --taxabletotal
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(ROUND(invoicedetail.tax,2)
	   ),0)
	),  --ivatotal
	-- residuo :somma dei dett. fattura non contabilizzati 
	-- oppure 0 se la fattura è di ACQUISTO contabilizzata con fondo economale
	-- (la contabilizzazione totale è obbligatoria in questo caso)
	CASE 
	WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NOT NULL)
	THEN 0
	WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NULL)  ----fatt.acquisto senza op.fondo economale
	THEN CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
			    CASE 
				WHEN (invoicedetail.idexp_taxable IS  NULL) AND (invoice.flagintracom<>'N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)

				WHEN (invoicedetail.idexp_taxable IS  NULL) AND (invoicedetail.idexp_iva IS  NOT NULL)AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	
				WHEN (invoicedetail.idexp_iva IS NULL) AND (invoicedetail.idexp_taxable IS  NOT NULL)AND (invoice.flagintracom='N')
				THEN
				    ROUND(invoicedetail.tax ,2)
	
				WHEN (invoicedetail.idexp_iva IS  NULL) AND (invoicedetail.idexp_taxable IS  NULL)AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)  * 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
				     +
				     ROUND(invoicedetail.tax ,2)
				ELSE   0
	
			    END
			   ),0)
			)
	WHEN  ((invoicekind.flag&1)<>0)  --fatt.vendita
	THEN	CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
			    CASE 
				 --taxable null , intracom -> residuo = taxable
				WHEN (invoicedetail.idinc_taxable IS  NULL) AND (invoice.flagintracom ='S') 
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)

				-- taxable null  e (iva not null o split) e non intracom -->residuo = taxable
				WHEN (invoicedetail.idinc_taxable IS  NULL) AND (invoicedetail.idinc_iva IS  NOT NULL OR (flag_enable_split_payment='S'))AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	
				-- iva null e taxable not null e non intracom e non split -> residuo = iva
				WHEN (invoicedetail.idinc_iva IS NULL) AND (invoicedetail.idinc_taxable IS  NOT NULL)AND (invoice.flagintracom='N') AND (flag_enable_split_payment='N')
				THEN
				    ROUND(invoicedetail.tax ,2)
	
				-- iva null e non split e non intracom e no imponibile -> residuo = iva+imponibile
				WHEN (invoicedetail.idinc_iva IS  NULL) AND (invoicedetail.idinc_taxable IS  NULL)AND (invoice.flagintracom='N') AND (flag_enable_split_payment='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
				     +
				     ROUND(invoicedetail.tax ,2)
				ELSE   0
	
			    END
			   ),0)
			)
	END,
-- (mov.movkind = 'IMPON' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN ((((invoicekind.flag&1)=0) AND invoicedetail.idexp_taxable IS NOT NULL 
				AND (invoicedetail.idexp_iva IS NULL OR 
					invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) OR
			      ( ((invoicekind.flag&1)<>0) AND invoicedetail.idinc_taxable IS NOT NULL 
				AND (invoicedetail.idinc_iva IS NULL OR 
							(isnull(invoicedetail.idinc_taxable,0)<>isnull(invoicedetail.idinc_iva,0) AND (flag_enable_split_payment='N')) )) )
			THEN
			      ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
		     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		),

-- (mov.movkind = 'IMPOS')
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN ((((invoicekind.flag&1)=0) AND  invoicedetail.idexp_iva IS NOT NULL 
				AND  (invoicedetail.idexp_taxable IS NULL OR 
				invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) OR
			     ( ((invoicekind.flag&1)<>0) AND 
						(invoicedetail.idinc_iva IS NOT NULL OR (flag_enable_split_payment='S'))
				AND  (invoicedetail.idinc_taxable IS NULL OR (flag_enable_split_payment='S') OR 
					(isnull(invoicedetail.idinc_taxable,0)<>isnull(invoicedetail.idinc_iva,0) AND (flag_enable_split_payment='N')) )) )
			
			THEN
			       ROUND(invoicedetail.tax ,2)
			ELSE   0
		    END
			
		   ),0)
		),
	
--  (mov.movkind = 'DOCUM' )
	CASE 
		WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NOT NULL)
			THEN 
				CONVERT(DECIMAL(19,2),
						ISNULL(SUM(  ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)*  
						     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
						     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
					   ),0)
					)
				+
				CONVERT(DECIMAL(19,2),
					ISNULL(SUM(ROUND(invoicedetail.tax ,2)
				   ),0)
				)
		ELSE
			CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
			    CASE 
				WHEN ((((invoicekind.flag&1)=0) AND invoicedetail.idexp_taxable IS NOT NULL 
					AND invoicedetail.idexp_iva= invoicedetail.idexp_taxable) OR
				     ( ((invoicekind.flag&1)<>0) AND invoicedetail.idinc_taxable IS NOT NULL 
					AND invoicedetail.idinc_iva= invoicedetail.idinc_taxable AND (flag_enable_split_payment='N')))
				THEN
		  		     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
				     +
				     ROUND(invoicedetail.tax ,2)			
				ELSE   0
			    END
			   ),0)
			)
	END,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	null,
	null,
	invoice.active,
	upb.title,
	invoice.flagintracom,
	invoice.flag_enable_split_payment,
	invoicedetail.idupb_iva,
	upb2.title ,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05,
	invoice.flagbit 
	FROM invoicedetail (NOLOCK) 
	JOIN invoice (NOLOCK)
  	ON invoicedetail.idinvkind = invoice.idinvkind
	AND invoicedetail.yinv = invoice.yinv
  	AND invoicedetail.ninv = invoice.ninv
	JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
	JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
	LEFT OUTER JOIN upb (NOLOCK)
	on upb.idupb=invoicedetail.idupb
	LEFT OUTER JOIN upb upb2 (NOLOCK)
	on upb2.idupb=invoicedetail.idupb_iva
	LEFT OUTER JOIN  pettycashoperationinvoice (NOLOCK)
	ON pettycashoperationinvoice.idinvkind=invoice.idinvkind 
	and pettycashoperationinvoice.yinv=invoice.yinv 
	and pettycashoperationinvoice.ninv=invoice.ninv
	GROUP BY invoice.idinvkind, invoicekind.codeinvkind, invoice.yinv, invoice.ninv,
	invoice.description,invoice.idreg,invoice.doc,invoice.docdate,registry.title,invoicedetail.idupb,
	invoicekind.flag,(invoicekind.flag&1), (invoicekind.flag&4),
	pettycashoperationinvoice.idinvkind,invoice.active,upb.title,invoice.flagintracom,
	invoicedetail.idupb_iva, upb2.title,invoice.flag_enable_split_payment,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05 ,invoice.flagbit 





GO
