
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


-- CREAZIONE VISTA estimateincavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[estimateincavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimateincavailable]
GO

 --setuser'amm'
--setuser 'amministrazione'
--clear_table_info 'estimateincavailable'
--select * from estimateincavailable

CREATE   VIEW [estimateincavailable]
(
	idestimkind,
	yestim,
	nestim,
	estimkind,
	registry,
	description,
	doc,
	docdate,
	adate,
	taxabletotal,
	ivatotal,
	detailtaxabletotal,
	detailivatotal,
	linkedtotal,
	residual,
	active,
	flagintracom,
	idman,
	manager,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cigcode,
	estimkindflag,
	linktoinvoice
)
AS SELECT
	estimate.idestimkind,
	estimate.yestim,
	estimate.nestim,
	estimatekind.description,
	registry.title,
	estimate.description,
	estimate.doc,
	estimate.docdate,
	estimate.adate,
	totestimateview.taxabletotal,       --totale imponibile su tutto l'ordine
	totestimateview.ivatotal,	    --totale iva su tutto l'ordine
	totestimatedetailview.taxabletotal, --totale imponibile dei dettagli associati a movimenti di entrata
	totestimatedetailview.ivatotal,     --totale iva dei dettagli associati a movimenti di entrata
	convert(decimal(19,2),ROUND(
	(SELECT ISNULL(SUM(incomeyear_starting.amount), 0.0) 
	FROM incomeestimate mov (NOLOCK)
		JOIN income e (NOLOCK)		ON e.idinc = mov.idinc
 		LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 		ON incomeyear_starting.idinc = e.idinc
  											AND incomeyear_starting.ayear = e.ymov
		WHERE mov.idestimkind = estimate.idestimkind	AND mov.yestim = estimate.yestim AND mov.nestim = estimate.nestim) +
	(SELECT ISNULL(SUM(v.amount), 0.0) 
		FROM incomeestimate mov (NOLOCK)
			JOIN income e (NOLOCK)	ON e.idinc = mov.idinc
			JOIN incomevar v (NOLOCK)	ON v.idinc = mov.idinc
			WHERE mov.idestimkind = estimate.idestimkind
						AND mov.yestim = estimate.yestim AND mov.nestim = estimate.nestim)
	,2)),
	--residuo :somma dei dett. ordine non contabilizzati o annullati
	(SELECT CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (estimatedetail.idinc_taxable IS  NULL) AND ( estimatedetail.idinc_iva IS  NOT NULL or (registry.flag_pa='S'))
			THEN
			     ROUND((ISNULL(estimatedetail.taxable,0)* estimatedetail.number )  ,2)

			WHEN (estimatedetail.idinc_iva IS NULL AND (isnull(registry.flag_pa,'N')='N' )) AND (estimatedetail.idinc_taxable IS  NOT NULL)
			THEN
			     ROUND( ISNULL(estimatedetail.tax,0)  ,2)

			WHEN (estimatedetail.idinc_iva IS  NULL AND (isnull(registry.flag_pa,'N')='N' )) AND (estimatedetail.idinc_taxable IS  NULL)
			THEN
			     ROUND((ISNULL(estimatedetail.taxable,0)* estimatedetail.number + ISNULL(estimatedetail.tax,0))  ,2)
			ELSE   0

		    END
		   ),0)
		) 
		FROM estimatedetail 
		left outer join registry on estimatedetail.idreg = registry.idreg
		WHERE estimatedetail.idestimkind = estimate.idestimkind
		AND  estimatedetail.yestim = estimate.yestim
		AND  estimatedetail.nestim = estimate.nestim
		AND	 estimatedetail.stop is null
	),
	estimate.active,
	estimate.flagintracom,
	estimate.idman,
	manager.title,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05,
	estimate.cigcode,
	estimatekind.flag,
	estimatekind.linktoinvoice
	FROM estimate (NOLOCK) 
	JOIN estimatekind				ON estimatekind.idestimkind = estimate.idestimkind
	JOIN totestimateview (NOLOCK)	ON totestimateview.idestimkind = estimate.idestimkind
										AND totestimateview.yestim = estimate.yestim
										AND totestimateview.nestim = estimate.nestim
	LEFT OUTER JOIN totestimatedetailview (NOLOCK)		ON totestimatedetailview.idestimkind = estimate.idestimkind
															AND totestimatedetailview.yestim = estimate.yestim
															AND totestimatedetailview.nestim = estimate.nestim
	LEFT OUTER JOIN registry (NOLOCK)		ON registry.idreg = estimate.idreg
	LEFT OUTER JOIN manager (NOLOCK)		ON manager.idman = estimate.idman










GO
