-- CREAZIONE VISTA invoiceresidualestimate
IF EXISTS(select * from sysobjects where id = object_id(N'[invoiceresidualestimate]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoiceresidualestimate]
GO



CREATE     VIEW [invoiceresidualestimate]
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
	idinc_taxableestim,
	idinc_ivaestim,
	idestimkind,
	estimatekind,
	yestim,
	nestim,
	estimrownum,
	active,
	upb,
	upb_iva,
	flagintracom,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05 
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
		ISNULL(SUM(  ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
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
	WHEN ((invoicekind.flag&1)<>0) 
	THEN	CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
			    CASE 
				 --taxable null , intracom -> residuo = taxable
				/*WHEN (invoicedetail.idinc_taxable IS  NULL) AND (invoice.flagintracom<>'N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)*/

				-- taxable null  e (iva not null o split) e non intracom -->residuo = taxable
				WHEN 
				(invoicedetail.idinc_taxable IS  NULL) AND (invoicedetail.idinc_iva IS  NOT NULL OR (flag_enable_split_payment='S'))--AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)*  
			     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	
				-- iva null e taxable not null e non intracom e non split -> residuo = iva
				WHEN
				 (invoicedetail.idinc_iva IS NULL) AND (invoicedetail.idinc_taxable IS  NOT NULL)/*AND (invoice.flagintracom='N')*/ AND (flag_enable_split_payment='N')				 
				THEN
				    ROUND(invoicedetail.tax ,2)
	
				-- iva null e non split e non intracom e no imponibile -> residuo = iva+imponibile
				WHEN (invoicedetail.idinc_iva IS  NULL) AND (invoicedetail.idinc_taxable IS  NULL) /*AND (invoice.flagintracom='N')*/  AND (flag_enable_split_payment='N')
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
-- (mov.movkind = '3' )  IMPON
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN ((invoicekind.flag&1)<>0) AND invoicedetail.idinc_taxable IS NOT NULL 
				AND (invoicedetail.idinc_iva IS NULL OR 
							(isnull(invoicedetail.idinc_taxable,0)<>isnull(invoicedetail.idinc_iva,0) AND (flag_enable_split_payment='N')) )
			THEN
			      ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		),
		
-- (mov.movkind = '2') IMPOS
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN ((invoicekind.flag&1)<>0) AND 
						(invoicedetail.idinc_iva IS NOT NULL OR (flag_enable_split_payment='S'))
				AND  (invoicedetail.idinc_taxable IS NULL OR (flag_enable_split_payment='S') OR 
					(isnull(invoicedetail.idinc_taxable,0)<>isnull(invoicedetail.idinc_iva,0) AND (flag_enable_split_payment='N')) )
			THEN
			       ROUND(invoicedetail.tax ,2)
			ELSE   0
		    END
			
		   ),0)
		),
	
--  (mov.movkind = '1' ) DOCUM
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN		
			 ((invoicekind.flag&1)<>0) AND (invoicedetail.idinc_taxable IS NOT NULL )
				AND ((isnull(invoicedetail.idinc_taxable,0)=isnull(invoicedetail.idinc_iva,0) ) 	)			 
			THEN
	  		     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
			     +
			     ROUND(invoicedetail.tax ,2)			
			ELSE   0
		    END
		   ),0)
		),
-- linkedtotal = (mov.movkind = 'IMPON' ) + (mov.movkind = 'IMPOS') +  (mov.movkind = 'DOCUM' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN ((invoicekind.flag&1)<>0) AND invoicedetail.idinc_taxable IS NOT NULL 
				AND (invoicedetail.idinc_iva IS NULL OR 
							(isnull(invoicedetail.idinc_taxable,0)<>isnull(invoicedetail.idinc_iva,0) AND (flag_enable_split_payment='N')) )
			THEN
			      ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		   +
		   ISNULL(SUM(
		    CASE 
			WHEN ((invoicekind.flag&1)<>0) AND 
						(invoicedetail.idinc_iva IS NOT NULL OR (flag_enable_split_payment='S'))
				AND  (invoicedetail.idinc_taxable IS NULL OR (flag_enable_split_payment='S') OR 
					(isnull(invoicedetail.idinc_taxable,0)<>isnull(invoicedetail.idinc_iva,0) AND (flag_enable_split_payment='N')) )
			THEN
			       ROUND(invoicedetail.tax ,2)
			ELSE   0
		    END
			
		   ),0)
		   +
		   ISNULL(SUM(
		    CASE 
			WHEN		
			 ((invoicekind.flag&1)<>0) AND (invoicedetail.idinc_taxable IS NOT NULL )
				AND ((isnull(invoicedetail.idinc_taxable,0)=isnull(invoicedetail.idinc_iva,0) ) 	)		 
			THEN
	  		     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,10),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
			     +
			     ROUND(invoicedetail.tax ,2)			
			ELSE   0
		    END
		   ),0)
		),
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 

	estimatedetail.idinc_taxable,
	estimatedetail.idinc_iva,
	estimatedetail.idestimkind,
	estimatekind.description,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatedetail.rownum,
	invoice.active,
	upb.title,
	upbiva.title ,
	invoice.flagintracom,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05  	
	FROM invoicedetail (NOLOCK)
	JOIN invoice (NOLOCK)
  	ON invoicedetail.idinvkind = invoice.idinvkind
	AND invoicedetail.yinv = invoice.yinv
  	AND invoicedetail.ninv = invoice.ninv
	JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
	JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
	LEFT OUTER JOIN estimatekind
	ON estimatekind.idestimkind = invoicedetail.idestimkind
	LEFT OUTER JOIN upb
	on upb.idupb=invoicedetail.idupb
	LEFT OUTER JOIN upb upbiva
	on upbiva.idupb=invoicedetail.idupb_iva
	LEFT OUTER JOIN estimatedetail
	ON  estimatedetail.idestimkind=invoicedetail.idestimkind 
	and estimatedetail.yestim=invoicedetail.yestim 
	and estimatedetail.nestim=invoicedetail.nestim
	and estimatedetail.rownum=invoicedetail.estimrownum
	GROUP BY invoice.idinvkind, invoicekind.codeinvkind,invoice.yinv, invoice.ninv,
	invoice.doc,invoice.docdate,
	invoicedetail.idestimkind, invoicedetail.yestim, invoicedetail.nestim,
	estimatedetail.idinc_taxable,estimatedetail.idinc_iva,
	invoice.description,invoice.idreg,registry.title,invoicedetail.idupb,invoicedetail.idupb_iva,upbiva.title,
	estimatedetail.idestimkind,estimatekind.description,estimatedetail.yestim,
	estimatedetail.nestim,estimatedetail.rownum,invoicekind.flag,
	(invoicekind.flag&1), (invoicekind.flag&4),invoice.active,upb.title,invoice.flagintracom,
	invoice.idsor01,invoice.idsor02,invoice.idsor03,invoice.idsor04,invoice.idsor05  	



GO

