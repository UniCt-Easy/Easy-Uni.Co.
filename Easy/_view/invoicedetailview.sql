
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


-- CREAZIONE VISTA invoicedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicedetailview]
GO
 
-- clear_table_info 'invoicedetailview' 
-- setuser 'amm' 
-- select  taxable,tax,taxable_euro,iva_euro,rowtotal from invoicedetailview
CREATE  VIEW [invoicedetailview]
(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	rownum,
	idgroup,
	idreg,
	detaildescription,
	idivakind,
	ivakind,
	rate,
	unabatabilitypercentage,
	idivataxablekind,
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
	manrownum,
	mandetaildescription,
	idestimkind,
	estimkind,
	yestim,
	nestim,
	estimrownum,
	estimatedetaildescription,
	ycon,
	ncon,
	idupb, 
	codeupb,	
	upb, 
	idupb_iva, 
	codeupb_iva,	
	upb_iva, 
	adate,
	toincludeinpaymentindicator,
	touniqueregister,
	idexp_iva,
	idexp_taxable,
	idexp_ivamand,
	idexp_taxablemand,
	idinc_iva,
	idinc_taxable,
	idinc_ivaestim,
	idinc_taxableestim,
	taxable_euro,
	iva_euro,
	unabatable_euro,
	rowtotal,
	competencystart,
	competencystop,
	paymentcompetency,
	yinv_main,
	ninv_main,
	codeinvkind_main,
	invoicekind_main,
	description,
	idaccmotive,
	codemotive,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	idintrastatcode,
	code,
	intrastatcode,
	idintrastatmeasure,
	intrastatmeasure,
	weight,
	va3type,
	va3typedescription,
	servicecode,
	idintrastatservice ,
	intrastatservice, 
	intrastatoperationkind,
	supplymethodcode,
	idintrastatsupplymethod,
	intrastatsupplymethod,
	idlist,
	intcode,
	idtassonomia,codicetassonomia,
	idunit,
	idpackage,
	unitsforpackage,
	npackage,
	flag_invoice,
	flag_invoicedetail,
	registry,
	cf,
	p_iva,
	exception12,
	intra12operationkind,
	move12,
	cu, 
	ct, 
	lu, 
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idinvkind_main,
	usedmodesospesometro,
	leasing,
	idfetransfer,
	fetransfer,
	fereferencerule,
	cupcode,
	cigcode,
	idpccdebitmotive,
	idpccdebitstatus,
	idcostpartition,
	expensekind,
	expensekinddescription,
	rounding,
	idepexp,
	nepexp,
	yepexp,
	idepacc,
	nepacc,
	yepacc,
	ymov_taxable,
	nmov_taxable,
	ymov_iva,
	nmov_iva,
	flagbit,
	idfinmotive,
	idfinmotive_iva,
	iduniqueformcode,
	idflussocrediti,
	idflussocreditidetail,
	codicetipo,codicevalore,
	idsor_siope,codesor_siope,
	flagbankitaliaproceeds,
	idepexp_pre,
	nepexp_pre,
	yepexp_pre
)
	AS SELECT
	invoicedetail.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoicedetail.yinv,
	invoicedetail.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	invoicedetail.rownum,
	invoicedetail.idgroup, 
	registry.idreg,
	invoicedetail.detaildescription,
	invoicedetail.idivakind,
	ivakind.description,
	ivakind.rate,
	ivakind.unabatabilitypercentage,
	ivakind.idivataxablekind,
	invoicedetail.number,
	invoicedetail.taxable,
	invoicedetail.discount,
	invoicedetail.tax,
	invoicedetail.unabatable,
	invoice.exchangerate,
	invoicedetail.annotations,
	invoicedetail.idmankind,
	mandatekind.description,
	invoicedetail.yman,
	invoicedetail.nman,
	invoicedetail.manrownum,
	mandatedetail.detaildescription,
	invoicedetail.idestimkind,
	estimatekind.description,
	invoicedetail.yestim,
	invoicedetail.nestim,
	invoicedetail.estimrownum,
	estimatedetail.detaildescription,
	invoicedetail.ycon,
	invoicedetail.ncon,
	invoicedetail.idupb, 
	upb.codeupb,	
	upb.title, 
	invoicedetail.idupb_iva, 
	upb_iva.codeupb,	
	upb_iva.title, 
	invoice.adate,
	invoice.toincludeinpaymentindicator,
	invoice.touniqueregister,
	invoicedetail.idexp_iva,
	invoicedetail.idexp_taxable,
	mandatedetail.idexp_iva,
	mandatedetail.idexp_taxable,
	invoicedetail.idinc_iva,
	invoicedetail.idinc_taxable,
	estimatedetail.idinc_iva,
	estimatedetail.idinc_taxable,
 	    CONVERT(decimal(19,2),
		ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		  CONVERT(DECIMAL(19,10),invoice.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(invoicedetail.discount, 0.0)))
		 ,2
		)),
	CONVERT(decimal(19,2),ROUND(invoicedetail.tax
				,2)
			),
	CONVERT(decimal(19,2), ROUND(invoicedetail.unabatable 
					
			       ,2)
			),
	CONVERT(decimal(19,2), ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
			  CONVERT(DECIMAL(19,10),ISNULL(invoice.exchangerate,1)) *
			  (1 - CONVERT(DECIMAL(19,6),ISNULL(invoicedetail.discount, 0.0))),2
		))+
	CONVERT(decimal(19,2),ROUND(ISNULL(invoicedetail.tax,0),2)),
	invoicedetail.competencystart,
	invoicedetail.competencystop,
	invoicedetail.paymentcompetency,
	invoicedetail.yinv_main,
	invoicedetail.ninv_main,

	invoicekind_main.codeinvkind,
	invoicekind_main.description,
	invoice.description,
	invoicedetail.idaccmotive,
	accmotive.codemotive,
	invoicedetail.idsor1,
	invoicedetail.idsor2,
	invoicedetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	invoicedetail.idintrastatcode,
	intrastatcode.code,
	intrastatcode.description,

	invoicedetail.idintrastatmeasure,
	intrastatmeasure.description,
	invoicedetail.weight,
	invoicedetail.va3type,

        CASE invoicedetail.va3type
                WHEN 'S' THEN 'Beni ammortizzabili'
                WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
                WHEN 'R' THEN 'Beni destinati alla rivendita ovvero alla produzione di beni e servizi'
                WHEN 'A' THEN ' Altri acquisti e importazioni'
        END,

intrastatservice.code,
intrastatservice.idintrastatservice ,
intrastatservice.description, 
invoicedetail.intrastatoperationkind,
intrastatsupplymethod.code,
intrastatsupplymethod.idintrastatsupplymethod,
intrastatsupplymethod.description,
invoicedetail.idlist,
list.intcode,
tassonomia_pagopa.idtassonomia,tassonomia_pagopa.causale,
invoicedetail.idunit,
invoicedetail.idpackage,
invoicedetail.unitsforpackage,
invoicedetail.npackage,
invoice.flag,
invoicedetail.flag,
registry.title,
registry.cf,
registry.p_iva,
invoicedetail.exception12,
invoicedetail.intra12operationkind,
invoicedetail.move12,
invoicedetail.cu, 
invoicedetail.ct, 
invoicedetail.lu,
invoicedetail.lt,
	isnull(invoice.idsor01,invoicekind.idsor01),
	isnull(invoice.idsor02,invoicekind.idsor02),
	isnull(invoice.idsor03,invoicekind.idsor03),
	isnull(invoice.idsor04,invoicekind.idsor04),
	isnull(invoice.idsor05,invoicekind.idsor05)	,
	invoicedetail.idinvkind_main,
	invoicedetail.usedmodesospesometro,
	invoicedetail.leasing,
	invoicedetail.idfetransfer,
	fetransfer.description,
	invoicedetail.fereferencerule,
	invoicedetail.cupcode,
	invoicedetail.cigcode,
	invoicedetail.idpccdebitmotive,
	invoicedetail.idpccdebitstatus,
	invoicedetail.idcostpartition,
	invoicedetail.expensekind,
	case 
		when invoicedetail.expensekind='CO' then 'Spesa corrente'
		when invoicedetail.expensekind='CA' then 'Conto capitale'
		else null
	end,
	invoicedetail.rounding,
	invoicedetail.idepexp,
	epexp.nepexp,
	epexp.yepexp,
	invoicedetail.idepacc,
	epacc.nepacc,
	epacc.yepacc,
	CASE
		WHEN ((invoicekind.flag&1)=0)  THEN expense_taxable.ymov
		WHEN ((invoicekind.flag&1)<>0) THEN income_taxable.ymov
	END, 
	CASE
		WHEN ((invoicekind.flag&1)=0)  THEN expense_taxable.nmov
		WHEN ((invoicekind.flag&1)<>0) THEN income_taxable.nmov
	END, 
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN  expense_iva.ymov
		WHEN ((invoicekind.flag&1)<>0) THEN income_iva.ymov
	END, 
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN  expense_iva.nmov
		WHEN ((invoicekind.flag&1)<>0) THEN income_iva.nmov
	END,
	invoicedetail.flagbit , 
	invoicedetail.idfinmotive,
	invoicedetail.idfinmotive_iva,
	invoicedetail.iduniqueformcode,
	flussocreditidetail.idflusso,
	flussocreditidetail.iddetail,
	invoicedetail.codicetipo,
	invoicedetail.codicevalore,
	invoicedetail.idsor_siope,sorting_siope.sortcode,
	registry.flagbankitaliaproceeds,
	invoicedetail.idepexp_pre,
	epexp_pre.nepexp,
	epexp_pre.yepexp
FROM invoicedetail WITH (NOLOCK)	
JOIN ivakind WITH (NOLOCK)		ON ivakind.idivakind = invoicedetail.idivakind
JOIN invoice WITH (NOLOCK)		ON invoice.ninv = invoicedetail.ninv	AND invoice.yinv = invoicedetail.yinv	AND invoice.idinvkind = invoicedetail.idinvkind
JOIN invoicekind WITH (NOLOCK)	ON invoicekind.idinvkind = invoicedetail.idinvkind
JOIN registry WITH (NOLOCK)		ON registry.idreg = invoice.idreg
LEFT OUTER JOIN mandatedetail WITH (NOLOCK)		ON invoicedetail.idmankind = mandatedetail.idmankind AND invoicedetail.yman = mandatedetail.yman AND invoicedetail.nman = mandatedetail.nman
														AND invoicedetail.manrownum = mandatedetail.rownum
LEFT OUTER JOIN mandatekind  WITH (NOLOCK)	ON mandatekind.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN estimatedetail WITH (NOLOCK)	ON invoicedetail.idestimkind = estimatedetail.idestimkind AND invoicedetail.yestim = estimatedetail.yestim
													AND invoicedetail.nestim = estimatedetail.nestim AND invoicedetail.estimrownum = estimatedetail.rownum
LEFT OUTER JOIN estimatekind  WITH (NOLOCK)		ON estimatekind.idestimkind = estimatedetail.idestimkind
LEFT OUTER JOIN invoice invoice_main WITH (NOLOCK)		ON invoice_main.ninv = invoicedetail.ninv_main	AND invoice_main.yinv = invoicedetail.yinv	AND invoice_main.idinvkind = invoicedetail.idinvkind
LEFT OUTER JOIN invoicekind invoicekind_main WITH (NOLOCK)	ON invoicedetail.idinvkind_main = invoicekind_main.idinvkind
LEFT OUTER JOIN upb WITH (NOLOCK) 	ON upb.idupb = invoicedetail.idupb
LEFT OUTER JOIN upb upb_iva  WITH (NOLOCK) 	ON upb_iva.idupb = invoicedetail.idupb_iva
LEFT OUTER JOIN accmotive WITH (NOLOCK)	ON accmotive.idaccmotive = invoicedetail.idaccmotive
LEFT OUTER JOIN sorting sorting1 WITH (NOLOCK)	ON sorting1.idsor = invoicedetail.idsor1
LEFT OUTER JOIN sorting sorting2 WITH (NOLOCK)	ON sorting2.idsor = invoicedetail.idsor2
LEFT OUTER JOIN sorting sorting3 WITH (NOLOCK)	ON sorting3.idsor = invoicedetail.idsor3
LEFT OUTER JOIN sorting sorting_siope WITH (NOLOCK)	ON sorting_siope.idsor = invoicedetail.idsor_siope
LEFT OUTER JOIN intrastatcode WITH (NOLOCK)	ON 	intrastatcode.idintrastatcode= invoicedetail.idintrastatcode
LEFT OUTER JOIN	intrastatmeasure WITH (NOLOCK)	ON 	intrastatmeasure.idintrastatmeasure = invoicedetail.idintrastatmeasure
LEFT OUTER JOIN intrastatservice WITH (NOLOCK)	ON invoicedetail.idintrastatservice=intrastatservice.idintrastatservice 
LEFT OUTER JOIN intrastatsupplymethod WITH (NOLOCK)	ON invoicedetail.idintrastatsupplymethod = intrastatsupplymethod.idintrastatsupplymethod
LEFT OUTER JOIN list  WITH (NOLOCK)		ON list.idlist = invoicedetail.idlist
LEFT OUTER JOIN tassonomia_pagopa WITH (NOLOCK) on list.idtassonomia= tassonomia_pagopa.idtassonomia
LEFT OUTER JOIN fetransfer		ON fetransfer.idfetransfer = invoicedetail.idfetransfer
LEFT OUTER JOIN  epexp			ON invoicedetail.idepexp= epexp.idepexp
LEFT OUTER JOIN  epexp	epexp_pre		ON invoicedetail.idepexp= epexp_pre.idepexp
LEFT OUTER JOIN  epacc			ON invoicedetail.idepacc= epacc.idepacc
LEFT OUTER JOIN  expense expense_taxable	ON invoicedetail.idexp_taxable = expense_taxable.idexp
LEFT OUTER JOIN  expense expense_iva		ON invoicedetail.idexp_iva = expense_iva.idexp
LEFT OUTER JOIN  income income_taxable		ON invoicedetail.idinc_taxable = income_taxable.idinc
LEFT OUTER JOIN  income income_iva			ON invoicedetail.idinc_iva = income_iva.idinc
left outer join flussocreditidetail on flussocreditidetail.idinvkind = invoicedetail.idinvkind 
								   and flussocreditidetail.yinv = invoicedetail.yinv and flussocreditidetail.ninv = invoicedetail.ninv and flussocreditidetail.invrownum = invoicedetail.rownum
								   and flussocreditidetail.stop is null

GO


 
 
