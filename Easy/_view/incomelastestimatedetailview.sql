
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


-- CREAZIONE VISTA incomelastestimatedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[incomelastestimatedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [incomelastestimatedetailview]
GO



--setuser 'amministrazione'
--setuser 'amm'
--clear_table_info 'incomelastestimatedetailview'
--select idepacc,idaccmotive,amount,nestim,yestim,rownum,estimkind,idestimkind from incomelastestimatedetailview
CREATE  VIEW [amministrazione].[incomelastestimatedetailview]
(	idinc,
	idestimkind,
	yestim,
	nestim,
	rownum,
	idgroup,
	estimkind,
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
	idepacc,
	idlist,
	cigcode,
	idfinmotive, 
	iduniqueformcode,
	nform,
	idsor_siope,
	idinc_taxable
)
AS SELECT 
	incomelastestimatedetail.idinc,
	estimatedetail.idestimkind,
	estimatedetail.yestim, 
	estimatedetail.nestim, 
	estimatedetail.rownum, 
	estimatedetail.idgroup,
	estimatekind.description,
	estimatedetail.idreg,	
	registry.title, 	
	estimate.idcurrency,
	currency.codecurrency,
	estimatedetail.detaildescription, 
	estimatedetail.number,		-- ordered
	ROUND(estimatedetail.taxable * estimatedetail.number * 
		  CONVERT(DECIMAL(19,6),estimate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(estimatedetail.discount, 0.0))),2
		), --taxabletotal
	incomelastestimatedetail.amount,
	incomelastestimatedetail.originalAmount,
	estimatedetail.taxable,
	estimatedetail.discount,
	estimatedetail.start,
	estimatedetail.stop,
	estimatedetail.competencystart,
	estimatedetail.competencystop,
	estimatedetail.idupb,
	estimatedetail.idupb_iva,
	estimatedetail.idsor1,
	estimatedetail.idsor2,
	estimatedetail.idsor3,
	estimatedetail.idaccmotive,
	estimatedetail.idivakind,
	ivakind.description,
	estimatedetail.toinvoice,
	estimatekind.linktoinvoice,
	estimatekind.multireg,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05,
	estimatedetail.epkind,
	estimate.exchangerate,
	estimatedetail.idepacc,
	estimatedetail.idlist,
	isnull(estimatedetail.cigcode,estimate.cigcode),
	estimatedetail.idfinmotive, 
	estimatedetail.iduniqueformcode,
	estimatedetail.nform,
	estimatedetail.idsor_siope,
	estimatedetail.idinc_taxable
	FROM incomelastestimatedetail
	JOIN estimatedetail		WITH (NOLOCK) ON incomelastestimatedetail.idestimkind=estimatedetail.idestimkind and
											incomelastestimatedetail.yestim=estimatedetail.yestim and
											incomelastestimatedetail.nestim=estimatedetail.nestim and
											incomelastestimatedetail.rownum=estimatedetail.rownum 
	JOIN estimatekind WITH (NOLOCK)					ON estimatekind.idestimkind = estimatedetail.idestimkind
	INNER JOIN estimate WITH (NOLOCK)				ON estimate.idestimkind = estimatedetail.idestimkind
												AND estimate.yestim = estimatedetail.yestim
												AND estimate.nestim = estimatedetail.nestim
	left outer JOIN registry WITH (NOLOCK) ON registry.idreg = estimatedetail.idreg
	LEFT OUTER JOIN ivakind WITH (NOLOCK)			ON ivakind.idivakind = estimatedetail.idivakind
	LEFT OUTER JOIN currency WITH (NOLOCK)			ON currency.idcurrency = estimate.idcurrency
	WHERE estimatedetail.stop is null



GO
