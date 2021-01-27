
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


-- CREAZIONE VISTA mandatedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[mandatedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatedetailview]
GO


--setuser 'amministrazione'
--clear_table_info'mandatedetailview'
--select * from mandatedetailview
CREATE      VIEW [mandatedetailview]

(
	idmankind,	yman,	nman,	rownum,
	idgroup, 	mankind,	
	idinv,	codeinv,	inventorytree,
  	idreg,   	registry,
	detaildescription,
	annotations,
	number,	taxable,	taxrate,	tax,  	discount,
	assetkind,
	start,	stop,
	idexp_taxable,	idexp_iva,	
	taxable_euro,	iva_euro,
	rowtotal,
	idupb,	codeupb,	upb,
	idupb_iva, 	codeupb_iva,	upb_iva, 
	idman,	manager,
	cu,	ct,	lu,	lt,
	idaccmotive,	codemotive,	idaccmotiveannulment,	codemotiveannulment,
	idsor1,	idsor2,	idsor3,	sortcode1,	sortcode2,	sortcode3,
	competencystart,	competencystop,
	idivakind,	ivakind,
	unabatable,
	flagmixed,
	toinvoice,
	exchangerate,
	description,	
	flagactivity,	va3type,	flagintracom,	
	ivanotes,	
	idlist,	intcode,	idunit,	idpackage,	unitsforpackage,	npackage,
	idstore,	store,
	cupcode,
	flagto_unload,
	applierannotations,cigcode,ninvoiced,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	epkind,
	rownum_origin,
	contractamount,
	idavcp,
	idavcp_choice,
	avcp_choice,
	avcp_startcontract,
	avcp_stopcontract,
	avcp_description,
	idpccdebitmotive,
	idpccdebitstatus,
	idcostpartition,
	expensekind,
	expensekinddescription,
	idepexp,
	idepacc,
	list,
	yepexp,
	nepexp,
	yexpimpo,
	nexpimpo,
	yexpiva,
	nexpiva,
	idlocation,
	locationcode,
	location,
	idsor_siope, 
	idepexp_pre,
	yepexp_pre,
	nepexp_pre
)
	AS SELECT
	mandatedetail.idmankind,	mandatedetail.yman,	mandatedetail.nman,	mandatedetail.rownum,
	mandatedetail.idgroup,	mandatekind.description,
	mandatedetail.idinv,	inventorytree.codeinv,	inventorytree.description,
 	mandatedetail.idreg,  	registry.title,
	mandatedetail.detaildescription,	mandatedetail.annotations,
	mandatedetail.number,	mandatedetail.taxable,	mandatedetail.taxrate,	mandatedetail.tax,  	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,	mandatedetail.stop,
	mandatedetail.idexp_taxable,	mandatedetail.idexp_iva,
 	    ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		),
	ROUND(mandatedetail.tax,2),
	ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		)+
	ROUND(mandatedetail.tax,2),

	mandatedetail.idupb,	upb.codeupb,	upb.title,
	mandatedetail.idupb_iva, 	upb_iva.codeupb,	upb_iva.title, 
	mandate.idman,	manager.title,
	mandatedetail.cu,	mandatedetail.ct,	mandatedetail.lu,	mandatedetail.lt,
	mandatedetail.idaccmotive,	accmotive.codemotive,	mandatedetail.idaccmotiveannulment,	accmotiveannulment.codemotive,
	mandatedetail.idsor1,	mandatedetail.idsor2,	mandatedetail.idsor3,	sorting1.sortcode,	sorting2.sortcode,	sorting3.sortcode,
	mandatedetail.competencystart,	mandatedetail.competencystop,
	mandatedetail.idivakind,	ivakind.description,
	mandatedetail.unabatable,	mandatedetail.flagmixed,	mandatedetail.toinvoice,	mandate.exchangerate,
	mandate.description,	mandatedetail.flagactivity,	mandatedetail.va3type,	mandate.flagintracom,
	mandatedetail.ivanotes,
	mandatedetail.idlist,	list.intcode,	mandatedetail.idunit,	mandatedetail.idpackage,	mandatedetail.unitsforpackage,	mandatedetail.npackage,
	mandate.idstore,	store.description,
	mandatedetail.cupcode,	mandatedetail.flagto_unload,
	mandatedetail.applierannotations,mandatedetail.cigcode,mandatedetail.ninvoiced,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,

	mandatedetail.epkind,
	mandatedetail.rownum_origin,
	mandatedetail.contractamount,
	mandatedetail.idavcp,
	mandatedetail.idavcp_choice,
	avcpchoice.description,
	mandatedetail.avcp_startcontract,
	mandatedetail.avcp_stopcontract,
	mandatedetail.avcp_description,
	mandatedetail.idpccdebitmotive,
	mandatedetail.idpccdebitstatus,
	mandatedetail.idcostpartition,
	mandatedetail.expensekind,
	case 
		when mandatedetail.expensekind='CO' then 'Spesa corrente'
		when mandatedetail.expensekind='CA' then 'Conto capitale'
		else null
	end,
	mandatedetail.idepexp,
	mandatedetail.idepacc,
	list.description,
	epexp.yepexp,
	epexp.nepexp,
	eimpo.ymov,
	eimpo.nmov,
	eiva.ymov,
	eiva.nmov,
	location.idlocation,
	location.locationcode,
	location.description,
	mandatedetail.idsor_siope,
	mandatedetail.idepexp_pre,
	epexp_pre.yepexp,
	epexp_pre.nepexp

FROM mandatedetail with (nolock)
JOIN mandatekind with (nolock)					ON mandatekind.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN ivakind with (nolock)			ON ivakind.idivakind = mandatedetail.idivakind
LEFT OUTER JOIN inventorytree with (nolock)		ON inventorytree.idinv = mandatedetail.idinv
JOIN mandate with (nolock)						ON mandate.yman = mandatedetail.yman
													AND mandate.nman = mandatedetail.nman
													AND mandate.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN registry with (nolock)			ON registry.idreg = mandatedetail.idreg
LEFT OUTER JOIN upb with (nolock)				ON upb.idupb = mandatedetail.idupb
LEFT OUTER JOIN upb upb_iva  WITH (NOLOCK)	ON upb_iva.idupb = mandatedetail.idupb_iva
LEFT OUTER JOIN manager with (nolock)			ON manager.idman = mandate.idman
LEFT OUTER JOIN accmotive with (nolock)			ON accmotive.idaccmotive = mandatedetail.idaccmotive
LEFT OUTER JOIN accmotive accmotiveannulment with (nolock)
												ON accmotiveannulment.idaccmotive = mandatedetail.idaccmotiveannulment
LEFT OUTER JOIN sorting sorting1 with (nolock)	ON sorting1.idsor = mandatedetail.idsor1
LEFT OUTER JOIN sorting sorting2 with (nolock)	ON sorting2.idsor = mandatedetail.idsor2
LEFT OUTER JOIN sorting sorting3 with (nolock)	ON sorting3.idsor = mandatedetail.idsor3
LEFT OUTER JOIN store  with (nolock)			ON store.idstore = mandate.idstore
LEFT OUTER JOIN list with (nolock)				ON list.idlist = mandatedetail.idlist
LEFT OUTER JOIN avcpchoice with (nolock)		ON avcpchoice.idavcp_choice = mandatedetail.idavcp_choice
LEFT OUTER JOIN  epexp	with (nolock)			ON mandatedetail.idepexp = epexp.idepexp
LEFT OUTER JOIN  expense eimpo	with (nolock)	ON mandatedetail.idexp_taxable = eimpo.idexp
LEFT OUTER JOIN  expense eiva	with (nolock)	ON mandatedetail.idexp_iva = eiva.idexp
LEFT OUTER JOIN location    with (nolock)		ON location.idlocation=mandatedetail.idlocation
LEFT OUTER JOIN epexp epexp_pre	with (nolock)	on epexp_pre.idepexp=mandatedetail.idepexp_pre 	

GO

