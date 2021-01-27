
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


-- CREAZIONE VISTA invoiceincavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[invoiceincavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoiceincavailable]
GO

CREATE  VIEW [invoiceincavailable]
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
	idsor05
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
	(SELECT ISNULL(SUM(incomeyear_starting.amount), 0) 
	FROM incomeinvoice mov (NOLOCK)
	JOIN income s (NOLOCK)
	ON s.idinc = mov.idinc
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
	ON incometotal_firstyear.idinc = s.idinc
	AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
	AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	WHERE mov.idinvkind = invoice.idinvkind
	AND mov.yinv = invoice.yinv
	AND mov.ninv = invoice.ninv)
	,2)),
	--residuo :somma dei dett. ordine non contabilizzati
	(SELECT CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (invoicedetail.idinc_taxable IS  NULL) AND (invoicedetail.idinc_iva IS  NOT NULL)
			THEN
			     ROUND((ISNULL(invoicedetail.taxable,0)* CONVERT(decimal(19,10),I.exchangerate) * ISNULL(invoicedetail.npackage,invoicedetail.number))  ,2)
			WHEN ( invoicedetail.idinc_iva IS NULL) AND (invoicedetail.idinc_taxable IS  NOT NULL)
			THEN
			     ROUND( ISNULL(invoicedetail.tax,0)  ,2)
			WHEN ( invoicedetail.idinc_iva IS  NULL) AND (invoicedetail.idinc_taxable IS  NULL)
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
	invoice.idsor05 
FROM invoice (NOLOCK)
JOIN invoicekind  (NOLOCK)
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
WHERE ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)=0)



GO
