
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




-- CREAZIONE VISTA invoicedetailgroupview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicedetailgroupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicedetailgroupview]
GO
-- setuser 'amm'
-- select * from invoicedetailgroupview
-- clear_table_info'invoicedetailgroupview'

CREATE   VIEW invoicedetailgroupview
(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	invidgroup,
	flag,
	flagbuysell,
	flagvariation,
	detaildescription,
	idivakind,
	ivakind,
	rate,
	unabatabilitypercentage,
	number,
	taxable,
	discount,
	tax,
	unabatable,
	exchangerate,
	annotations,
	idmankind,
	mankind,
	yman,
	nman,
	manidgroup,
	mandetaildescription,
	adate,	
	idlist,
	npackage,
	idunit,
	idpackage,
	unitsforpackage,
	rounding,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05 ,
	taxable_euro,
	iva_euro
)
	AS SELECT
	invoicedetail.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoicedetail.yinv,
	invoicedetail.ninv,
	invoicedetail.idgroup,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)=1) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)=1) THEN 'S'
	END, 
	invoicedetail.detaildescription,
	invoicedetail.idivakind,
	ivakind.description,
	ivakind.rate,
	ivakind.unabatabilitypercentage,
	invoicedetail.number,
	isnull(sum(invoicedetail.taxable),0),
	invoicedetail.discount,
	isnull(sum(invoicedetail.tax),0),
	isnull(sum(invoicedetail.unabatable),0),
	invoice.exchangerate,
	invoicedetail.annotations,
	invoicedetail.idmankind,
	mandatekind.description,
	invoicedetail.yman,
	invoicedetail.nman,
	mandatedetail.idgroup,
	max(mandatedetail.detaildescription),
	invoice.adate,
	invoicedetail.idlist,
	invoicedetail.npackage,
	invoicedetail.idunit,
	invoicedetail.idpackage,
	invoicedetail.unitsforpackage,
	invoicedetail.rounding,
	invoice.active,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05,
	Round(
	(SELECT  ISNULL(SUM(MD1.taxable),0)
	FROM invoicedetail MD1
	JOIN invoice M1
		ON M1.yinv = MD1.yinv AND M1.ninv = MD1.ninv AND M1.idinvkind = MD1.idinvkind
	WHERE M1.idinvkind = invoicedetail.idinvkind
		AND M1.yinv = invoicedetail.yinv 
		AND M1.ninv = invoicedetail.ninv 
		AND MD1.idgroup = invoicedetail.idgroup)
	 * ISNULL(invoicedetail.npackage,invoicedetail.number)   * CONVERT(DECIMAL(19,6),invoice.exchangerate)  
	 * (1 - CONVERT(DECIMAL(19,6),ISNULL(invoicedetail.discount, 0.0)))
	,2),
	isnull(sum(invoicedetail.tax),0)
FROM invoicedetail (NOLOCK)
JOIN ivakind (NOLOCK)		ON ivakind.idivakind = invoicedetail.idivakind
JOIN invoice (NOLOCK)		ON invoice.ninv = invoicedetail.ninv
									AND invoice.yinv = invoicedetail.yinv
									AND invoice.idinvkind = invoicedetail.idinvkind
JOIN invoicekind (NOLOCK)	ON invoicekind.idinvkind = invoicedetail.idinvkind
JOIN registry (NOLOCK)		ON registry.idreg = invoice.idreg
LEFT OUTER JOIN mandatedetail (NOLOCK)
				ON invoicedetail.idmankind = mandatedetail.idmankind
								AND invoicedetail.yman = mandatedetail.yman
								AND invoicedetail.nman = mandatedetail.nman
								AND invoicedetail.manrownum = mandatedetail.rownum
LEFT OUTER JOIN mandatekind  (NOLOCK)	ON mandatekind.idmankind = mandatedetail.idmankind
GROUP BY 
	invoicedetail.yman,
	invoicedetail.nman,
	--invoicedetail.manrownum,
	mandatedetail.idgroup,
	invoicedetail.idinvkind,
	invoicedetail.yinv,
	invoicedetail.ninv,
	invoicedetail.idgroup,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoicekind.flag,
	(invoicekind.flag&1),
	(invoicekind.flag&4),
	--invoicedetail.rownum,
	invoicedetail.detaildescription,
	invoicedetail.idivakind,
	ivakind.description,
	ivakind.rate,
	ivakind.unabatabilitypercentage,
	invoicedetail.number,
	invoicedetail.discount,
	invoice.exchangerate,
	invoicedetail.annotations,
	invoicedetail.idmankind,
	mandatekind.description,
	--mandatedetail.detaildescription,
	invoice.adate,
	invoicedetail.idlist,
	invoicedetail.npackage,
	invoicedetail.idunit,
	invoicedetail.idpackage,
	invoicedetail.unitsforpackage ,
	invoicedetail.rounding,
	invoice.active,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05







GO
