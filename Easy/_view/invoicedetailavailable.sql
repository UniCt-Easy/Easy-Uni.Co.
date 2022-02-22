
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA invoicedetailavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicedetailavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicedetailavailable]
GO

--clear_table_info 'invoicedetailavailable'
-- select * from invoicedetailavailable
CREATE  VIEW [invoicedetailavailable]
(
	idinvkind,
	yinv,
	ninv,
	invidgroup,
	invkind,
	registry,
	detaildescription,
	invoiced,
	loaded,
	residual,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	idreg,
	exchangerate,
	taxable,
	taxrate,
	discount,
	idmankind,
	yman,
	nman,
	--manrownum,
	manidgroup
)
AS SELECT DISTINCT 
	invoicedetail.idinvkind,
	invoicedetail.yinv, 
	invoicedetail.ninv, 
	invoicedetail.idgroup,
	invoicekind.description,

	registry.title, 	
	invoicedetail.detaildescription, 
	invoicedetail.number,	--fatturato
	(SELECT ISNULL(SUM(number), 0)
		FROM assetacquire
		WHERE invoicedetail.idinvkind = assetacquire.idinvkind
		AND invoicedetail.yinv = assetacquire.yinv
		AND invoicedetail.ninv = assetacquire.ninv
		AND invoicedetail.idgroup = assetacquire.invrownum), --loaded
	ISNULL(invoicedetail.number, 0) -
	(SELECT ISNULL(SUM(number), 0)
		FROM assetacquire
		WHERE invoicedetail.idinvkind = assetacquire.idinvkind
		AND invoicedetail.yinv = assetacquire.yinv
		AND invoicedetail.ninv = assetacquire.ninv
		AND invoicedetail.idgroup = assetacquire.invrownum), --residual: da caricare
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05,
	invoice.idreg,
	invoice.exchangerate,
	(SELECT  ISNULL(SUM(MD1.taxable),0)
	FROM invoicedetail MD1
	JOIN invoice M1			ON M1.yinv = MD1.yinv AND M1.ninv = MD1.ninv AND M1.idinvkind = MD1.idinvkind
	WHERE M1.idinvkind = invoicedetail.idinvkind
		AND M1.yinv = invoicedetail.yinv 
		AND M1.ninv = invoicedetail.ninv 
		AND MD1.idgroup = invoicedetail.idgroup) , 	 
	ivakind.rate,
	invoicedetail.discount,
	invoicedetail.idmankind,
	invoicedetail.yman,
	invoicedetail.nman,
	--invoicedetail.manrownum,
	mandatedetail.idgroup
FROM invoicedetail (nolock)
JOIN invoicekind with (nolock)	ON invoicekind.idinvkind = invoicedetail.idinvkind
JOIN ivakind WITH (NOLOCK)	ON ivakind.idivakind = invoicedetail.idivakind

INNER JOIN invoice	(nolock)	ON invoice.idinvkind = invoicedetail.idinvkind
									AND invoice.yinv = invoicedetail.yinv
									AND invoice.ninv = invoicedetail.ninv
join registry  on registry.idreg = invoice.idreg
LEFT OUTER JOIN mandatedetail (NOLOCK)
	ON invoicedetail.idmankind = mandatedetail.idmankind
	AND invoicedetail.yman = mandatedetail.yman
	AND invoicedetail.nman = mandatedetail.nman
	AND invoicedetail.manrownum = mandatedetail.rownum


GO


