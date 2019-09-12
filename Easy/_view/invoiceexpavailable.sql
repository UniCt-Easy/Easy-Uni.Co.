-- CREAZIONE VISTA invoiceexpavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[invoiceexpavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoiceexpavailable]
GO




CREATE  VIEW [invoiceexpavailable]
(
	idinvkind,
	codeinvkind,
	yinv,
	ninv,
	invkind,
	registry,
	description,
	doc,
	docdate,
	adate,
	taxabletotal,
	ivatotal,
	detailtaxabletotal,
	detailivatotal,
	linkedtotal,
	residual,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	flag_enable_split_payment,
	flag_auto_split_payment
)
AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoice.yinv,
	invoice.ninv,
	invoicekind.description,
	registry.title,
	invoice.description,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	totinvoiceview.taxabletotal, -- totale imponibile su tutta la fattura
	totinvoiceview.ivatotal,--totale iva su tutta la fattura
	totinvoicedetailview.taxabletotal,--totale imponibile dei dettagli associati a movimenti di spesa
	totinvoicedetailview.ivatotal,--totale iva dei dettagli associati a movimenti di spesa
	--totale movimenti = somma (importo) del join di expenseinvoice con expense
	convert(decimal(19,2),ROUND(
	(SELECT ISNULL(SUM(expenseyear_starting.amount), 0) 
	FROM expenseinvoice mov (NOLOCK)
	JOIN expense s (NOLOCK)
	ON s.idexp = mov.idexp
	LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
	ON expensetotal_firstyear.idexp = s.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
	WHERE mov.idinvkind = invoice.idinvkind
	AND mov.yinv = invoice.yinv
	AND mov.ninv = invoice.ninv)
	,2)),
	--residuo :somma dei dett. fattura non contabilizzati
	(SELECT CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (invoicedetail.idexp_taxable IS  NULL) AND (invoicedetail.idexp_iva IS  NOT NULL)
			THEN
			     ROUND((ISNULL(invoicedetail.taxable,0)* CONVERT(decimal(19,10),I.exchangerate) * ISNULL(invoicedetail.npackage,invoicedetail.number) )  ,2)
			WHEN ( invoicedetail.idexp_iva IS NULL) AND (invoicedetail.idexp_taxable IS  NOT NULL)
			THEN
			     ROUND( ISNULL(invoicedetail.tax,0)  ,2)
			WHEN ( invoicedetail.idexp_iva IS  NULL) AND (invoicedetail.idexp_taxable IS  NULL)
			THEN
			     ROUND((ISNULL(invoicedetail.taxable,0)* CONVERT(decimal(19,10),I.exchangerate) * ISNULL(invoicedetail.npackage,invoicedetail.number) + ISNULL(invoicedetail.tax,0))  ,2)
			ELSE   0
		    END
		   ),0)
		) 
	FROM invoicedetail 
	JOIN invoice I ON
		invoicedetail.idinvkind = I.idinvkind
		AND invoicedetail.yinv = I.yinv
		AND invoicedetail.ninv = I.ninv
	WHERE invoicedetail.idinvkind = invoice.idinvkind
		AND invoicedetail.yinv = invoice.yinv
		AND invoicedetail.ninv = invoice.ninv),
	invoice.active,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05,
	invoice.flag_enable_split_payment,
	invoice.flag_auto_split_payment
FROM invoice (NOLOCK)
JOIN invoicekind
	ON invoicekind.idinvkind = invoice.idinvkind
JOIN totinvoiceview (NOLOCK)
	ON totinvoiceview.idinvkind = invoice.idinvkind
	AND totinvoiceview.yinv = invoice.yinv
	AND totinvoiceview.ninv = invoice.ninv
LEFT OUTER JOIN totinvoicedetailview (NOLOCK)
	ON totinvoicedetailview.idinvkind = invoice.idinvkind
	AND totinvoicedetailview.yinv = invoice.yinv
	AND totinvoicedetailview.ninv = invoice.ninv
LEFT OUTER JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
WHERE ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)=0)


 
GO
