
-- CREAZIONE VISTA invoicedeferredview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicedeferredview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicedeferredview]
GO
 
 -- clear_table_info'invoicedeferredview'
 --setuser 'amm'
 -- select * from invoicedeferredview
CREATE  VIEW [invoicedeferredview]
(
	nivapay,
	yivapay,
	ivatotalpayed,
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	idreg,
	registry,
	description,
	doc,
	docdate,
	adate,
	taxable,
	tax,
	unabatable,
	total,
	active,
	flag_enable_split_payment,
	flagintracom,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idivaregisterkind,
	registerclass,
	flagactivity
	)
	AS SELECT
	invoicedeferred.nivapay,
	invoicedeferred.yivapay,
--	invoicedeferred.ivatotalpayed,
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN invoicedeferred.ivatotalpayed -- Fattura 
		WHEN ((invoicekind.flag&4)<>0) THEN - (invoicedeferred.ivatotalpayed) -- Nota di variazione
	END,
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoice.yinv,
	invoice.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	invoice.idreg,
	registry.title,
	invoice.description,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	-- taxable
	ISNULL(
		(SELECT
 	    	SUM(
			ROUND(D.taxable * ISNULL(D.npackage,D.number) * CONVERT(decimal(19,10),M.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(D.discount, 0.0)))
			,2)
		)
		FROM invoicedetail D
		join invoicedetaildeferred  IDD on IDD.idinvkind=D.idinvkind and IDD.yinv=D.yinv
											and IDD.ninv=D.ninv and IDD.rownum=D.rownum
											and IDD.yivapay= invoicedeferred.yivapay and IDD.nivapay=invoicedeferred.nivapay
		JOIN invoice M		ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind	AND D.yinv = invoice.yinv	AND D.ninv = invoice.ninv
						AND isnull(D.rounding,'N')<>'S'
		)
	, 0),
	-- Tax
		ISNULL(
			(SELECT SUM(ROUND(D.tax ,2))
			FROM invoicedetail  D 
			join invoicedetaildeferred  IDD on IDD.idinvkind=D.idinvkind and IDD.yinv=D.yinv
												and IDD.ninv=D.ninv and IDD.rownum=D.rownum
												and IDD.yivapay= invoicedeferred.yivapay and IDD.nivapay=invoicedeferred.nivapay
			WHERE D.idinvkind = invoice.idinvkind 	AND D.yinv = invoice.yinv	AND D.ninv = invoice.ninv
			AND isnull(D.rounding,'N')<>'S'
			)
		, 0),
	-- Unabatable
	ISNULL(
		(SELECT
		SUM(ROUND(D.unabatable ,2))
		FROM invoicedetail D
		join invoicedetaildeferred  IDD on IDD.idinvkind=D.idinvkind and IDD.yinv=D.yinv
											and IDD.ninv=D.ninv and IDD.rownum=D.rownum
											and IDD.yivapay= invoicedeferred.yivapay and IDD.nivapay=invoicedeferred.nivapay
		JOIN invoice M		ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind 	AND D.yinv = invoice.yinv	AND D.ninv = invoice.ninv
		AND isnull(D.rounding,'N')<>'S'
		)
		
		
	, 0),
	-- Total
	ISNULL(
		(SELECT
 	    	SUM(
			ROUND(D.taxable * ISNULL(D.npackage,D.number)* CONVERT(decimal(19,10),M.exchangerate) *
				(1 - CONVERT(decimal(19,6),ISNULL(D.discount, 0.0)))
			,2)
		)
		FROM invoicedetail D
		join invoicedetaildeferred  IDD on IDD.idinvkind=D.idinvkind and IDD.yinv=D.yinv
											and IDD.ninv=D.ninv and IDD.rownum=D.rownum
											and IDD.yivapay= invoicedeferred.yivapay and IDD.nivapay=invoicedeferred.nivapay
		JOIN invoice M			ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind AND D.yinv = invoice.yinv	AND D.ninv = invoice.ninv
							AND isnull(D.rounding,'N')<>'S'
		)
	, 0) +
	ISNULL(
		(SELECT SUM(ROUND(D.tax,2))
		FROM invoicedetail D
		join invoicedetaildeferred  IDD on IDD.idinvkind=D.idinvkind and IDD.yinv=D.yinv
											and IDD.ninv=D.ninv and IDD.rownum=D.rownum
											and IDD.yivapay= invoicedeferred.yivapay and IDD.nivapay=invoicedeferred.nivapay
		JOIN invoice M		ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind AND D.yinv = invoice.yinv AND D.ninv = invoice.ninv
					AND isnull(D.rounding,'N')<>'S')
	, 0),
	invoice.active,
	invoice.flag_enable_split_payment,
	invoice.flagintracom,
	isnull(invoice.idsor01,invoicekind.idsor01),
	isnull(invoice.idsor02,invoicekind.idsor02),
	isnull(invoice.idsor03,invoicekind.idsor03),
	isnull(invoice.idsor04,invoicekind.idsor04),
	isnull(invoice.idsor05,invoicekind.idsor05)	,
	ivaregisterkind.idivaregisterkind,
	ivaregisterkind.registerclass,
	ivaregisterkind.flagactivity
FROM invoicedeferred WITH (NOLOCK)
JOIN invoice WITH (NOLOCK)		ON invoicedeferred.idinvkind = invoice.idinvkind and invoicedeferred.yinv = invoice.yinv and invoicedeferred.ninv = invoice.ninv
JOIN invoicekind WITH (NOLOCK)	ON invoicekind.idinvkind = invoice.idinvkind
JOIN registry  WITH (NOLOCK)	ON registry.idreg = invoice.idreg
JOIN ivaregister		ON ivaregister.idinvkind = invoice.idinvkind AND ivaregister.yinv = invoice.yinv AND ivaregister.ninv = invoice.ninv
JOIN ivaregisterkind 	ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind

GO



 