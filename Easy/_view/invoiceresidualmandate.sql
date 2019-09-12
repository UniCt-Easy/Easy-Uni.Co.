-- CREAZIONE VISTA invoiceresidualmandate
IF EXISTS(select * from sysobjects where id = object_id(N'[invoiceresidualmandate]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoiceresidualmandate]
GO

--select * from [invoiceresidualmandate] where idinvkind = 2 and yinv = 2017 and ninv = 40
CREATE       VIEW [invoiceresidualmandate]
(
	idinvkind,
	codeinvkind,
	yinv,
	ninv,
	doc,
	docdate,
	description,
	idreg,
	idupb,
	idupb_iva,
	registry,
	taxabletotal,
	ivatotal,
	residual,
	linkedimpon,
	linkedimpos,
	linkeddocum,
	linkedtotal,
	flag,
	flagbuysell,
	flagvariation,
	idexp_taxablemand,
	idexp_ivamand,
	ycon,
	ncon,
	idmankind,
	mandatekind,
	yman,
	nman,
	manrownum,
	active,
	upb,
	upb_iva,
	flagintracom,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05 ,
	flagbit
)
	AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoice.yinv,
	invoice.ninv,
	invoice.doc,
	invoice.docdate,
	invoice.description,
	invoice.idreg,
	invoicedetail.idupb,
	invoicedetail.idupb_iva,
	registry.title,
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(  ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
		     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	   ),0)
	),
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(ROUND(invoicedetail.tax ,2)
	   ),0)
	),
	-- residuo :somma dei dett. fattura non contabilizzati 
	-- oppure 0 se la fattura è di ACQUISTO contabilizzata con fondo economale
	-- (la contabilizzazione totale è obbligatoria in questo caso)
	CASE 
	WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NOT NULL)
	THEN 0
	WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NULL)
	THEN CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
			    CASE 
				--> flagintracom X o S, e bit 6 a 0 => non c'è il recupero dell'iva
				WHEN (invoicedetail.idexp_taxable IS  NULL) AND (invoice.flagintracom!='N') and ((invoice.flagbit & 64) =0) 
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
				--> flagintracom N, e bit 6 a 0zero => non c'è il recupero dell'iva
				WHEN (invoicedetail.idexp_taxable IS  NULL) AND (invoicedetail.idexp_iva IS  NOT NULL) AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	
				WHEN (invoicedetail.idexp_iva IS NULL) AND (invoicedetail.idexp_taxable IS  NOT NULL)AND (invoice.flagintracom='N')
				THEN
				    ROUND(invoicedetail.tax ,2)
	
				WHEN (invoicedetail.idexp_iva IS  NULL) AND (invoicedetail.idexp_taxable IS  NULL)AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
				     +
				     ROUND(invoicedetail.tax ,2)
				--> flagintracom X o S, e bit 6 a 1o => c'è il recupero dell'iva
				WHEN (invoicedetail.idexp_taxable IS  NULL) AND (invoicedetail.idexp_iva IS  NOT NULL) AND (invoice.flagintracom!='N')and ((invoice.flagbit & 64) <> 0)
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	
				WHEN (invoicedetail.idexp_iva IS NULL) AND (invoicedetail.idexp_taxable IS  NOT NULL)AND (invoice.flagintracom!='N')and ((invoice.flagbit & 64) < >0)
				THEN
				    ROUND(invoicedetail.tax ,2)
	
				WHEN (invoicedetail.idexp_iva IS  NULL) AND (invoicedetail.idexp_taxable IS  NULL)AND (invoice.flagintracom!='N')and ((invoice.flagbit & 64) <> 0)
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
			WHEN (((invoicekind.flag&1)=0) AND invoicedetail.idexp_taxable IS NOT NULL 
				AND (invoicedetail.idexp_iva IS NULL OR 
				invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) 
			THEN
			      ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
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
			WHEN (((invoicekind.flag&1)=0) AND  invoicedetail.idexp_iva IS NOT NULL 
				AND  (invoicedetail.idexp_taxable IS NULL OR 
				invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) 
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
					ISNULL(SUM(  ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
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
						AND invoicedetail.idexp_iva= invoicedetail.idexp_taxable) )
					THEN
			  		     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
				     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
				     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
					     +
					     ROUND(invoicedetail.tax,2)			
					ELSE   0
				    END
				   ),0)
				)
	END,

-- linkedtotal = (mov.movkind = 'IMPON' ) + (mov.movkind = 'IMPOS') +  (mov.movkind = 'DOCUM' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)=0) AND invoicedetail.idexp_taxable IS NOT NULL 
				AND (invoicedetail.idexp_iva IS NULL OR 
				invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) 
			THEN
			      ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
		     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		)
	+  -- ('IMPOS')
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)=0) AND  invoicedetail.idexp_iva IS NOT NULL 
				AND  (invoicedetail.idexp_taxable IS NULL OR 
				invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) 
			THEN
			       ROUND(invoicedetail.tax ,2)
			ELSE   0
		    END
			
		   ),0)
		)
	+	--  ('DOCUM')
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
						AND invoicedetail.idexp_iva= invoicedetail.idexp_taxable) )
					THEN
			  		     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
				     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
				     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
					     +
					     ROUND(invoicedetail.tax,2)			
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
	mandatedetail.idexp_taxable,
	mandatedetail.idexp_iva,
	profservice.ycon,
	profservice.ncon,
	--isnull(profservice.ycon, profservice_old.ycon),
 --   isnull(profservice.ncon, profservice_old.ncon),
	mandatedetail.idmankind,
	mandatekind.description,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.rownum,
	invoice.active,
	upb.title,
	upbiva.title ,
	invoice.flagintracom,
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
	LEFT OUTER JOIN upb
	on upb.idupb=invoicedetail.idupb
	LEFT OUTER JOIN upb upbiva
	on upbiva.idupb=invoicedetail.idupb_iva
	LEFT OUTER JOIN mandatedetail
	ON  mandatedetail.idmankind=invoicedetail.idmankind 
	and mandatedetail.yman=invoicedetail.yman 
	and mandatedetail.nman=invoicedetail.nman
	and mandatedetail.rownum=invoicedetail.manrownum
	LEFT OUTER JOIN mandatekind
	ON mandatekind.idmankind = mandatedetail.idmankind
	LEFT OUTER JOIN  pettycashoperationinvoice
	ON pettycashoperationinvoice.idinvkind=invoice.idinvkind 
	and pettycashoperationinvoice.yinv=invoice.yinv 
	and pettycashoperationinvoice.ninv=invoice.ninv
	LEFT OUTER JOIN profservice
		ON profservice.ycon = invoicedetail.ycon
		AND profservice.ncon = invoicedetail.ncon
		AND invoicedetail.ncon IS NOT NULL
	GROUP BY invoice.idinvkind, invoicekind.codeinvkind, invoice.yinv, invoice.ninv,invoice.doc,invoice.docdate,
	invoicedetail.idmankind, invoicedetail.yman, invoicedetail.nman,
	mandatedetail.idexp_taxable,mandatedetail.idexp_iva,
	invoice.description,invoice.idreg,registry.title,invoicedetail.idupb, invoicedetail.idupb_iva,	upbiva.title ,
	mandatedetail.idmankind,mandatekind.description,mandatedetail.yman,mandatedetail.nman, mandatedetail.rownum,
	invoicekind.flag,(invoicekind.flag&1),(invoicekind.flag&4),
	pettycashoperationinvoice.idinvkind,invoice.active,upb.title,invoice.flagintracom,invoice.flagbit,
	invoice.idsor01,invoice.idsor02,invoice.idsor03,invoice.idsor04,invoice.idsor05 ,
	profservice.ycon, profservice.ncon
	--, profservice_old.ycon,profservice_old.ncon	








GO


 