
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


-- CREAZIONE VISTA mandatedetail_tostock
IF EXISTS(select * from sysobjects where id = object_id(N'[mandatedetail_tostock]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatedetail_tostock]
GO



--setuser 'amm'
---SELECT * FROM mandatedetail_tostock
-- clear_table_info 'mandatedetail_tostock'
CREATE VIEW [mandatedetail_tostock]
(
	idmankind,
	yman,
	nman,
	idgroup,
	mandatekind,
	adate,
 	idreg,
  	registry,
	detaildescription,
	annotations,
	npackage,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	start,
	stop,
	taxable_euro,
	iva_euro,
	idaccmotive,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	exchangerate,
	linktoinvoice,
	multireg,
	flagactivity,
	idmandatestatus,
	mandatestatus,
	ordered,
	stocked,
	ntostock,
	idlist,
	description,
	intcode,
	intbarcode,
	extcode,
	extbarcode,
	validitystop,
	active,
	idpackage,
	package,
	idunit,
	unit,
	unitsforpackage,
	has_expiry,
	idlistclass,
	idstore,
	store,
	flagto_unload,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	isrequest,
	idepexp,
	idman
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.idgroup,
	mandatekind.description,
	mandate.adate,
	mandatedetail.idreg,
	registry.title,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.npackage,
	mandatedetail.number,
	ISNULL(ROUND(SUM(mandatedetail.taxable),2),0), 	
	mandatedetail.taxrate,
	ISNULL(SUM(mandatedetail.tax),0), 
  	mandatedetail.discount,
	mandatedetail.start,
	mandatedetail.stop,
	Round(
	(SELECT  ISNULL(SUM(MD1.taxable),0)
	FROM mandatedetail MD1
	JOIN mandate M1
		ON M1.yman = MD1.yman AND M1.nman = MD1.nman AND M1.idmankind = MD1.idmankind
	WHERE M1.idmankind = mandatedetail.idmankind
		AND M1.yman = mandatedetail.yman 
		AND M1.nman = mandatedetail.nman 
		AND MD1.idgroup = mandatedetail.idgroup)
	 * ISNULL(ISNULL(mandatedetail.npackage,mandatedetail.number),0)   * CONVERT(DECIMAL(19,6),mandate.exchangerate)  
	 * (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0)))
	,2),
	isnull(sum(
		ROUND(mandatedetail.tax,2)
	),0),
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	isnull(sum(mandatedetail.unabatable),0),
	mandatedetail.flagmixed,
	mandate.exchangerate,
	mandatekind.linktoinvoice,
	mandatekind.multireg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.number,
	(SELECT  SUM (stock.number) 
   	   FROM stock
	  WHERE mandatedetail.idmankind = stock.idmankind
		AND mandatedetail.yman = stock.yman
		AND mandatedetail.nman = stock.nman
		AND mandatedetail.idgroup = stock.man_idgroup),
	mandatedetail.number 
	- ISNULL((SELECT  SUM (stock.number)
   	   FROM stock
	  WHERE mandatedetail.idmankind = stock.idmankind
		AND mandatedetail.yman = stock.yman
		AND mandatedetail.nman = stock.nman
		AND mandatedetail.idgroup = stock.man_idgroup 
	   ),0), 	-- ntostock 
	mandatedetail.idlist,
	list.description,
	list.intcode,
	list.intbarcode,
	list.extcode,
	list.extbarcode,
	list.validitystop,
	list.active,
	list.idpackage,
	package.description,
	list.idunit,
	unit.description,
	list.unitsforpackage,
	list.has_expiry,
	list.idlistclass,
	mandate.idstore,
	store.description,
	mandatedetail.flagto_unload,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,
	mandatekind.isrequest,
	mandatedetail.idepexp,mandate.idman
FROM mandatedetail (NOLOCK)
JOIN mandatekind		ON mandatekind.idmankind = mandatedetail.idmankind
LEFT JOIN inventorytree (NOLOCK)	ON inventorytree.idinv = mandatedetail.idinv
JOIN mandate (NOLOCK)				ON mandate.yman = mandatedetail.yman
						AND mandate.nman = mandatedetail.nman
						AND mandate.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN ivakind			ON ivakind.idivakind = mandatedetail.idivakind
LEFT OUTER JOIN mandatestatus (NOLOCK)		ON mandatestatus.idmandatestatus = mandate.idmandatestatus
LEFT OUTER JOIN list (NOLOCK)				ON mandatedetail.idlist = list.idlist
LEFT OUTER JOIN package						ON package.idpackage = mandatedetail.idpackage
LEFT OUTER JOIN unit				ON unit.idunit = mandatedetail.idunit
LEFT OUTER JOIN store					ON store.idstore = mandate.idstore
left outer join registry on registry.idreg=mandatedetail.idreg
GROUP BY 
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.idgroup,
	mandatekind.description,
	mandate.idreg,
	mandate.adate,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.npackage,
	mandatedetail.number,
	mandatedetail.taxrate,
  	mandatedetail.discount,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.flagmixed,
	mandatedetail.toinvoice,
	mandate.exchangerate,
	mandatekind.linktoinvoice,
	mandatekind.multireg,
	mandate.idreg,
	mandatedetail.idreg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandate.idstore,
	mandatedetail.idlist,
	store.description,
	list.description,
	list.intcode,
	list.intbarcode,
	list.extcode,
	list.extbarcode,
	list.validitystop,
	list.active,
	list.idpackage,package.description,
	list.idunit,unit.description,
	list.unitsforpackage,
	list.has_expiry,
	list.idlistclass,	
	mandatedetail.flagto_unload,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,
	mandatekind.isrequest,
	mandatedetail.idepexp,
	registry.idreg, registry.title,
	mandate.idman




GO
