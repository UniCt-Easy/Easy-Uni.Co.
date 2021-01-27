
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
