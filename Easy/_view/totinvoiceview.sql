-- CREAZIONE VISTA totinvoiceview
IF EXISTS(select * from sysobjects where id = object_id(N'[totinvoiceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [totinvoiceview]
GO

CREATE                                       VIEW [totinvoiceview]
(
	idinvkind,
	yinv,
	ninv,
	taxabletotal,
	ivatotal,
	unabatabletotal
)
	AS SELECT
	invoicedetail.idinvkind,
	invoicedetail.yinv,
	invoicedetail.ninv,
-- Arrotondamento effettuato come nella vista TOTMANDATEVIEW
	CONVERT(decimal(19,2),
		SUM(
		    ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
			  CONVERT(decimal(19,10),invoice.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2
			 )
		   )
		),
	CONVERT(decimal(19,2),
	SUM(ROUND(
		ISNULL(invoicedetail.tax, 0.0)  ,2))),
	CONVERT(decimal(19,2),	SUM(ISNULL(invoicedetail.unabatable, 0)))

	FROM invoicedetail (NOLOCK)
	JOIN invoice (NOLOCK)
  ON invoicedetail.idinvkind = invoice.idinvkind
  AND invoicedetail.yinv = invoice.yinv
  AND invoicedetail.ninv = invoice.ninv
	GROUP BY invoicedetail.idinvkind,
  invoicedetail.yinv, 
  invoicedetail.ninv,
  invoice.exchangerate








GO
