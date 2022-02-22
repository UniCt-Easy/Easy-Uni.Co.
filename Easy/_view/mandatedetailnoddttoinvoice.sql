
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


 -- CREAZIONE VISTA mandatedetailnoddttoinvoice
IF EXISTS(select * from sysobjects where id = object_id(N'[mandatedetailnoddttoinvoice]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatedetailnoddttoinvoice]
GO
--setuser 'amministrazione'
-- clear_table_info'mandatedetailnoddttoinvoice'
-- select * from mandatedetailnoddttoinvoice
--setuser 'amm'
/* usato per prendere merce non preceduta da DDT */
/* Calcola il residuo come ordinato - (fatturato + in bolla non fatturato)  */
/* va bene anche per merce non di magazzino */

CREATE  VIEW [mandatedetailnoddttoinvoice]
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mandatekind,
	idcurrency,
	codecurrency,
	cigcode,cupcode,
	idman,
	flagintracom,
	codeinv,
	inventorytree,
	idreg,
	registry,
	detaildescription,
	ordered,
	residual,
	taxrate,
	taxable,
	tax,
	rowtotal,
	discount,
	npackage,
	unitsforpackage,
	idunit,
	idpackage,
	number,
	assetkind,
	start,
	stop,
	idupb,
	idupb_iva,
	idsor1,
	idsor2,
	idsor3,
	idcostpartition,
	idaccmotive,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	competencystart,
	competencystop,
	toinvoice,
	linktoinvoice,
	linktoasset,
	multireg,
	flagactivity,
	idmandatestatus,
	mandatestatus,
	va3type,
	flagto_unload,
	idstore,
	store,
	idlist,
	list,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	epkind,
	expensekind,
	idepexp,
	idsor_siope,
	requested_doc
)
AS SELECT 	
	mandatedetail.idmankind,
	mandatedetail.yman, 
	mandatedetail.nman, 
	mandatedetail.rownum, 
	mandatedetail.idgroup,
	mandatekind.description,
	mandate.idcurrency,
	currency.codecurrency,
	mandatedetail.cigcode,
	mandatedetail.cupcode,
	mandate.idman,
	mandate.flagintracom,
	inventorytree.codeinv, 
	inventorytree.description,
	mandatedetail.idreg,
	registry.title,
	mandatedetail.detaildescription, 
	ISNULL(mandatedetail.npackage,mandatedetail.number),	-- ordered
    ISNULL(mandatedetail.npackage, mandatedetail.number) -	
	ISNULL(
	(SELECT SUM(iv.number)
	  FROM (SELECT  DISTINCT ISNULL(npackage,number) as number,
					  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
					  invoicedetail.idgroup as invidgroup
					  --invoicedetail.rownum as rownum,			--task 8206, tolto per task 8581
				      --invoicedetail.number
					  --invoicedetail.idmankind,invoicedetail.yman,invoicedetail.nman --, mandatedetail.idgroup as manidgroup --- 14 2  17 mi sembra inutile
		FROM invoicedetail 
			--JOIN mandatedetail mandatedetail2
		  WHERE invoicedetail.idmankind = mandatedetail.idmankind AND
		     invoicedetail.yman = mandatedetail.yman AND
	         invoicedetail.nman = mandatedetail.nman AND
		     invoicedetail.manrownum = mandatedetail.rownum 		   
			) AS iv )  ,0)
	- isnull((select sum(S.number/L.unitsforpackage) from stock S 
				JOIN list L on S.idlist=L.idlist				
				 where S.idmankind=mandatedetail.idmankind
				AND S.yman=mandatedetail.yman AND S.nman=mandatedetail.nman
				AND S.man_idgroup= mandatedetail.idgroup
				AND S.idinvkind is null
				),0), 	-- residual
	
	mandatedetail.taxrate,
	mandatedetail.taxable,
	mandatedetail.tax,
	ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		)+
	ROUND(mandatedetail.tax,2),
	mandatedetail.discount,
	mandatedetail.npackage,
	mandatedetail.unitsforpackage,
	mandatedetail.idunit,
	mandatedetail.idpackage,
	mandatedetail.number,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idupb,
	mandatedetail.idupb_iva,
	mandatedetail.idsor1,
	mandatedetail.idsor2,
	mandatedetail.idsor3,
	mandatedetail.idcostpartition,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.unabatable,
	mandatedetail.flagmixed,
	mandatedetail.competencystart,
	mandatedetail.competencystop,
	mandatedetail.toinvoice,
	mandatekind.linktoinvoice,
	mandatekind.linktoasset,
	mandatekind.multireg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.va3type,
	mandatedetail.flagto_unload,
	mandate.idstore,
	store.description,
	LIST.idlist,
	LIST.description ,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,
	mandatedetail.epkind,
	isnull(mandatedetail.expensekind, accmotive. expensekind),
	mandatedetail.idepexp,
	mandatedetail.idsor_siope,
	mandate.requested_doc
FROM mandatedetail  (nolock) 
JOIN mandatekind (nolock)	ON mandatekind.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN inventorytree (nolock) ON inventorytree.idinv = mandatedetail.idinv
INNER JOIN mandate  (nolock) 	ON mandate.idmankind = mandatedetail.idmankind
								AND mandate.yman = mandatedetail.yman
									AND mandate.nman = mandatedetail.nman
LEFT OUTER JOIN currency (nolock) 	ON mandate.idcurrency = currency.idcurrency
LEFT OUTER JOIN registry with (nolock)   ON registry.idreg = mandatedetail.idreg
JOIN ivakind (nolock) 	ON ivakind.idivakind = mandatedetail.idivakind
LEFT OUTER JOIN mandatestatus (NOLOCK)		ON mandatestatus.idmandatestatus = mandate.idmandatestatus
LEFT OUTER JOIN store  (nolock) 	ON store.idstore = mandate.idstore
LEFT OUTER JOIN LIST (nolock) 	ON mandatedetail.idlist = LIST.idlist
LEFT OUTER JOIN accmotive  (nolock) 	on accmotive.idaccmotive = mandatedetail.idaccmotive 
WHERE mandatedetail.stop is null


GO

 
