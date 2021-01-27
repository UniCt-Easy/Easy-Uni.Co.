
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


-- CREAZIONE VISTA estimatedetail_extview
IF EXISTS(select * from sysobjects where id = object_id(N'[estimatedetail_extview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimatedetail_extview]
GO




--setuser 'amm'
--clear_table_info 'estimatedetail_extview'
--select * from estimatedetail_extview
CREATE  VIEW [estimatedetail_extview]
(
	idestimkind,
	yestim,
	nestim,
	rownum,
	idgroup,
	estimkind,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	start,
	stop,
	competencystart,
	competencystop,
	idinc_taxable,
	idinc_iva,	
	taxable_euro,
	iva_euro,
	rowtotal,
	idupb,	codeupb,	upb,
	idupb_iva,	codeupb_iva,	upb_iva,
		idman,	manager,
	cu,
	ct,
	lu,
	lt,
	idaccmotive,
	codemotive,
	idaccmotiveannulment,
	codemotiveannulment,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	idivakind,
	ivakind,
	toinvoice,
	exchangerate,
	description,
	linkedtoinvoice,
	notlinkedtoinvoice,
	epkind,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idrevenuepartition,
	cigcode,
	idepacc,
	yepacc,
	nepacc,
	idfinmotive,
	codefinmotive,
	iduniqueformcode,
	nform,
	yincimpo,
	nincimpo,
	yinciva,
	ninciva,
	idsor_siope,
	intcode,idlist,list
)
	AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatedetail.rownum,
	estimatedetail.idgroup,
	estimatekind.description,
 	estimatedetail.idreg,
  	registry.title,
	estimatedetail.detaildescription,
	estimatedetail.annotations,
	estimatedetail.number,
	estimatedetail.taxable,
	estimatedetail.taxrate,
	estimatedetail.tax,
  	estimatedetail.discount,
	estimatedetail.start,
	estimatedetail.stop,
	estimatedetail.competencystart,
	estimatedetail.competencystop,
	estimatedetail.idinc_taxable,
	estimatedetail.idinc_iva,
 	    ROUND(estimatedetail.taxable * estimatedetail.number * 
		  CONVERT(DECIMAL(19,6),estimate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(estimatedetail.discount, 0.0))),2
		),
	ROUND(estimatedetail.tax ,2),
 	    ROUND(estimatedetail.taxable * estimatedetail.number * 
		  CONVERT(DECIMAL(19,6),estimate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(estimatedetail.discount, 0.0))),2
		)+
	ROUND(estimatedetail.tax ,2),
	estimatedetail.idupb,	upb.codeupb,	upb.title,
	estimatedetail.idupb_iva, upb_iva.codeupb,	upb_iva.title,
	estimate.idman,	manager.title,
	estimatedetail.cu,
	estimatedetail.ct,
	estimatedetail.lu,
	estimatedetail.lt,
	estimatedetail.idaccmotive,
	accmotive.codemotive,
	estimatedetail.idaccmotiveannulment,
	accmotiveannulment.codemotive,
	estimatedetail.idsor1,
	estimatedetail.idsor2,
	estimatedetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	estimatedetail.idivakind,
	ivakind.description,
	estimatedetail.toinvoice,
	estimate.exchangerate,
	estimate.description,
	-- linkedtoinvoice
	ISNULL(
		(SELECT  SUM (iv.number)
	FROM (SELECT DISTINCT number,idestimkind,yestim,nestim,estimrownum,idgroup
		FROM invoicedetail) 
		AS iv
	WHERE estimatedetail.idestimkind = iv.idestimkind
		AND estimatedetail.yestim = iv.yestim
		AND estimatedetail.nestim = iv.nestim
		AND estimatedetail.rownum = iv.estimrownum)
	,0),
	-- notlinkedtoinvoice
	estimatedetail.number -
	ISNULL(
		(SELECT  SUM (iv.number)
	FROM (SELECT DISTINCT number, idestimkind,yestim,nestim,estimrownum,idgroup
		FROM invoicedetail) 
		AS iv
	WHERE estimatedetail.idestimkind = iv.idestimkind
		AND estimatedetail.yestim = iv.yestim
		AND estimatedetail.nestim = iv.nestim
		AND estimatedetail.rownum = iv.estimrownum)
	,0),
	estimatedetail.epkind,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05,
	estimatedetail.idrevenuepartition,
	isnull(estimatedetail.cigcode,estimate.cigcode),
	estimatedetail.idepacc,
	epacc.yepacc,
	epacc.nepacc,
	estimatedetail.idfinmotive,
	finmotive.codemotive,
	estimatedetail.iduniqueformcode,
	estimatedetail.nform,
	iimpo.ymov,
	iimpo.nmov,
	iiva.ymov,
	iiva.nmov,
	estimatedetail.idsor_siope,
	list.intcode,
	list.idlist,
	list.description
FROM estimatedetail
JOIN estimatekind WITH (NOLOCK)				ON estimatekind.idestimkind = estimatedetail.idestimkind
JOIN estimate WITH (NOLOCK)					ON estimate.yestim = estimatedetail.yestim
												AND estimate.nestim = estimatedetail.nestim
												AND estimate.idestimkind = estimatedetail.idestimkind
left outer JOIN ivakind WITH (NOLOCK)					ON ivakind.idivakind = estimatedetail.idivakind
LEFT OUTER JOIN manager with (nolock)		ON manager.idman = estimate.idman
LEFT OUTER JOIN registry WITH (NOLOCK)		ON registry.idreg = estimatedetail.idreg
LEFT OUTER JOIN upb WITH (NOLOCK)			ON upb.idupb = estimatedetail.idupb
LEFT OUTER JOIN upb upb_iva WITH (NOLOCK)			ON upb_iva.idupb = estimatedetail.idupb_iva
LEFT OUTER JOIN accmotive WITH (NOLOCK)		ON accmotive.idaccmotive = estimatedetail.idaccmotive
LEFT OUTER JOIN accmotive accmotiveannulment WITH (NOLOCK)	ON accmotiveannulment.idaccmotive = estimatedetail.idaccmotiveannulment
LEFT OUTER JOIN sorting sorting1 WITH (NOLOCK)				ON sorting1.idsor = estimatedetail.idsor1
LEFT OUTER JOIN sorting sorting2 WITH (NOLOCK)				ON sorting2.idsor = estimatedetail.idsor2
LEFT OUTER JOIN sorting sorting3 WITH (NOLOCK)				ON sorting3.idsor = estimatedetail.idsor3
LEFT OUTER JOIN  epacc	WITH (NOLOCK)						ON estimatedetail.idepacc= epacc.idepacc
LEFT OUTER JOIN  finmotive	WITH (NOLOCK)					ON estimatedetail.idfinmotive= finmotive.idfinmotive
LEFT OUTER JOIN  income iimpo	WITH (NOLOCK)				ON estimatedetail.idinc_taxable = iimpo.idinc
LEFT OUTER JOIN  income iiva	WITH (NOLOCK)				ON estimatedetail.idinc_iva = iiva.idinc
LEFT OUTER JOIN  list		WITH (NOLOCK)					ON list.idlist = estimatedetail.idlist




GO
 
  
