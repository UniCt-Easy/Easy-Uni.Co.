
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


-- CREAZIONE VISTA expenselastmandatedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[expenselastmandatedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenselastmandatedetailview]
GO


 
--setuser 'amministrazione'
--setuser 'amm'
--clear_table_info 'expenselastestimatedetailview'
--select  * from [expenselastmandatedetailview] 
CREATE  VIEW [expenselastmandatedetailview]
(	idexp,
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mandatekind,
	idreg,
	registry,
	idcurrency,
	codecurrency, 
	detaildescription,
	ordered,
	taxabletotal,
	amount,	
	originalAmount,
	taxable,
	discount,
	start,
	stop,
	competencystart,
	competencystop,
	idupb,
	idupb_iva,
	idsor1,
	idsor2,
	idsor3,
	idaccmotive,
	idivakind,
	ivakind,
	toinvoice,
	linktoinvoice,
	multireg,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	epkind,exchangerate,
	idepexp,
	idlist,
	cigcode,
	idsor_siope,
	idexp_taxable,
	idexp_iva 
)
AS SELECT 
	expenselastmandatedetail.idexp,
	mandatedetail.idmankind,
	mandatedetail.yman, 
	mandatedetail.nman, 
	mandatedetail.rownum, 
	mandatedetail.idgroup,
	mandatekind.description,
	mandatedetail.idreg,	
	registry.title, 	
	mandate.idcurrency,
	currency.codecurrency,
	mandatedetail.detaildescription, 
	mandatedetail.number,		-- ordered
	ROUND(mandatedetail.taxable * mandatedetail.number * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		), --taxabletotal
	expenselastmandatedetail.amount,
	expenselastmandatedetail.originalAmount,
	mandatedetail.taxable,
	mandatedetail.discount,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.competencystart,
	mandatedetail.competencystop,
	mandatedetail.idupb,
	mandatedetail.idupb_iva,
	mandatedetail.idsor1,
	mandatedetail.idsor2,
	mandatedetail.idsor3,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.toinvoice,
	mandatekind.linktoinvoice,
	mandatekind.multireg,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,
	mandatedetail.epkind,
	mandate.exchangerate,
	mandatedetail.idepexp,
	mandatedetail.idlist,
	isnull(mandatedetail.cigcode,mandate.cigcode),
	mandatedetail.idsor_siope,
	mandatedetail.idexp_taxable,
	mandatedetail.idexp_iva 
	FROM expenselastmandatedetail
	JOIN mandatedetail		WITH (NOLOCK) ON expenselastmandatedetail.idmankind=mandatedetail.idmankind and
											expenselastmandatedetail.yman=mandatedetail.yman and
											expenselastmandatedetail.nman=mandatedetail.nman and
											expenselastmandatedetail.rownum=mandatedetail.rownum 
	JOIN mandatekind WITH (NOLOCK)					ON mandatekind.idmankind = mandatedetail.idmankind
	INNER JOIN mandate WITH (NOLOCK)				ON mandate.idmankind = mandatedetail.idmankind
												AND mandate.yman = mandatedetail.yman
												AND mandate.nman = mandatedetail.nman
	left outer JOIN registry WITH (NOLOCK) ON registry.idreg = mandatedetail.idreg
	LEFT OUTER JOIN ivakind WITH (NOLOCK)			ON ivakind.idivakind = mandatedetail.idivakind
	LEFT OUTER JOIN currency WITH (NOLOCK)			ON currency.idcurrency = mandate.idcurrency
	WHERE mandatedetail.stop is null



GO
