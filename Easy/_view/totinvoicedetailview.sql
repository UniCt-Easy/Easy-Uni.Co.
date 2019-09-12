-- CREAZIONE VISTA totinvoicedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[totinvoicedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [totinvoicedetailview]
GO



CREATE VIEW [totinvoicedetailview]
(
	idinvkind,
	yinv,
	ninv,
	taxabletotal,
	ivatotal
)
AS SELECT
	invoicedetail.idinvkind,
	invoicedetail.yinv,
	invoicedetail.ninv,
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN invoicedetail.idexp_taxable IS NOT NULL THEN
			    ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
				  CONVERT(decimal(19,10),invoice.exchangerate) *
				  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
				)
			ELSE
			   0
		    END
			
		   ),0)
		),
	   CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		 CASE
		 WHEN invoicedetail.idexp_iva IS NOT NULL THEN
			ROUND(invoicedetail.tax ,2)
		  ELSE 0
		END
		),0)
	   )
FROM invoicedetail (NOLOCK)
JOIN invoice (NOLOCK)
	ON invoicedetail.idinvkind = invoice.idinvkind
	AND invoicedetail.yinv = invoice.yinv
	AND invoicedetail.ninv = invoice.ninv
GROUP BY invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv


GO
