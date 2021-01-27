
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


-- CREAZIONE VISTA mandatedetailgroupview
IF EXISTS(select * from sysobjects where id = object_id(N'[mandatedetailgroupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatedetailgroupview]
GO


--setuser 'amm'
--setuser 'amministrazione'
--select * from mandatedetailgroupview
--clear_table_info'mandatedetailgroupview'
CREATE VIEW [mandatedetailgroupview]
(
	idmankind,
	yman,
	nman,
	idgroup,
	mankind,
	idinv,
	codeinv,
	inventorytree,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	assetkind,
	start,
	stop,
	taxable_euro,
	iva_euro,
	idaccmotive,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	toinvoice,
	epkind,
	exchangerate,
	linktoinvoice,
	linktoasset,
	multireg,
	mandateidreg,
	mandatedetailidreg,
	flagactivity,
	idmandatestatus,
	mandatestatus,
	idlist,
	npackage,
	idunit,
	idpackage,
	unitsforpackage,
	flagto_unload,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	--idepexp,
	va3type,
	expensekind,
	idlocation
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.idgroup,
	mandatekind.description,
	mandatedetail.idinv,
	inventorytree.codeinv,
	inventorytree.description,
 	mandatedetail.idreg,
	registry.title, 	
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	ISNULL(SUM(mandatedetail.taxable),0), 	
	mandatedetail.taxrate,
	ISNULL(SUM(mandatedetail.tax),0), 
  	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	/* Prima facendo  Round(somma * x*y*z ) sbagliava gli arrotondamenti xkè avvenivano dettaglio x dettaglio 
	   adesso calcola   Round(somma) * x*y*z  prima si calcola il taxable poi fa le moltiplicazioni.
	isnull(sum(
 	    ROUND(mandatedetail.taxable * mandatedetail.number * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		)
	),0) ,  */
	Round(
	(SELECT  ISNULL(SUM(MD1.taxable),0)
	FROM mandatedetail MD1
	JOIN mandate M1
		ON M1.yman = MD1.yman AND M1.nman = MD1.nman AND M1.idmankind = MD1.idmankind
	WHERE M1.idmankind = mandatedetail.idmankind
		AND M1.yman = mandatedetail.yman 
		AND M1.nman = mandatedetail.nman 
		AND MD1.idgroup = mandatedetail.idgroup)
	 * ISNULL(mandatedetail.npackage,mandatedetail.number)   * CONVERT(DECIMAL(19,6),mandate.exchangerate)  
	 * (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0)))
	,2)
	,
	isnull(sum(mandatedetail.tax),0) , -- sara
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	isnull(sum(mandatedetail.unabatable),0),
	mandatedetail.flagmixed,
	mandatedetail.toinvoice,
	mandatedetail.epkind,
	mandate.exchangerate,
	mandatekind.linktoinvoice,
	mandatekind.linktoasset,
	mandatekind.multireg,
	mandate.idreg,mandatedetail.idreg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.idlist,
	mandatedetail.npackage,
	mandatedetail.idunit,
	mandatedetail.idpackage,
	mandatedetail.unitsforpackage,
	mandatedetail.flagto_unload,
	mandate.idsor01,mandate.idsor02,mandate.idsor03,mandate.idsor04,	mandate.idsor05,
	--mandatedetail.idepexp,
	mandatedetail.va3type,
	mandatedetail.expensekind
	,	mandatedetail.idlocation
FROM mandatedetail (NOLOCK)
JOIN mandatekind (NOLOCK)		ON mandatekind.idmankind = mandatedetail.idmankind
LEFT JOIN inventorytree (NOLOCK)	ON inventorytree.idinv = mandatedetail.idinv
JOIN mandate (NOLOCK)			ON mandate.yman = mandatedetail.yman
		AND mandate.nman = mandatedetail.nman
	AND mandate.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN ivakind (NOLOCK)	ON ivakind.idivakind = mandatedetail.idivakind
LEFT OUTER JOIN mandatestatus (NOLOCK)		ON mandatestatus.idmandatestatus = mandate.idmandatestatus
left outer join registry on registry.idreg = mandatedetail.idreg
GROUP BY 
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.idgroup,
	mandatekind.description,
	mandatedetail.idinv,
	inventorytree.codeinv,
	inventorytree.description,
 	mandate.idreg,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	mandatedetail.npackage,	mandatedetail.idlist, mandatedetail.idunit,mandatedetail.idpackage,mandatedetail.unitsforpackage ,
	mandatedetail.taxrate,
  	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.flagmixed,
	mandatedetail.toinvoice,
	mandatedetail.epkind,
	mandate.exchangerate,
	mandatekind.linktoinvoice,
	mandatekind.linktoasset,
	mandatekind.multireg,
	mandate.idreg,
	mandatedetail.idreg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.flagto_unload,
	mandate.idsor01,	mandate.idsor02,	mandate.idsor03,	mandate.idsor04,	mandate.idsor05,
	--mandatedetail.idepexp, 
	registry.title,
	mandatedetail.va3type,mandatedetail.expensekind,mandatedetail.idlocation


GO
