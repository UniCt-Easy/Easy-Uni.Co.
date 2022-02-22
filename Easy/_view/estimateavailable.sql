
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


-- CREAZIONE VISTA estimateavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[estimateavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimateavailable]
GO


--setuser 'amm'
--clear_table_info 'estimateavailable'
--select * from estimateavailable

CREATE    VIEW [estimateavailable]
(
	idestimkind,
	yestim,
	nestim,
	estimkind,
	registry,
	idupb,
	description,
	doc,
	docdate,
	adate,
	idman,
	manager,
	taxabletotal,
	ivatotal,
	linkedtotal,
	residual,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cigcode
)
	AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatekind.description,
	registry.title,
	estimatedetail.idupb,
	estimate.description,
	estimate.doc,
	estimate.docdate,
	estimate.adate,
	estimate.idman,
	manager.title,
	isnull(totestimateview.taxabletotal,0),
	isnull(totestimateview.ivatotal,0),
	convert(decimal(19,2),ROUND(
	(SELECT ISNULL(SUM(incomeyear_starting.amount), 0.0) 
	FROM incomeestimate mov (NOLOCK)
	JOIN income e (NOLOCK)										ON e.idinc = mov.idinc
 	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK)		ON incomeyear_starting.idinc = e.idinc
  																AND incomeyear_starting.ayear = e.ymov
	WHERE mov.idestimkind = estimate.idestimkind
	AND mov.yestim = estimate.yestim
	AND mov.nestim = estimate.nestim) +
	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM incomeestimate mov (NOLOCK)
	JOIN income e (NOLOCK)			ON e.idinc = mov.idinc
	JOIN incomevar v (NOLOCK)		ON v.idinc = mov.idinc
	WHERE mov.idestimkind = estimate.idestimkind
							AND mov.yestim = estimate.yestim
							AND mov.nestim = estimate.nestim)
	,2)),
	--residuo = totaleimponibile + totaleiva - totale movimenti
	CONVERT(decimal(19,2),ROUND(
	ISNULL(totestimateview.taxabletotal, 0.0) +
	ISNULL(totestimateview.ivatotal, 0.0) -
	(SELECT ISNULL(SUM(incomeyear_starting.amount), 0.0) 
	FROM incomeestimate mov (NOLOCK)
	JOIN income e (NOLOCK)										ON e.idinc = mov.idinc
 	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK)		ON incomeyear_starting.idinc = e.idinc
  															AND incomeyear_starting.ayear = e.ymov
	WHERE mov.idestimkind = estimate.idestimkind
		AND mov.yestim = estimate.yestim
		AND mov.nestim = estimate.nestim) -
			(SELECT ISNULL(SUM(v.amount), 0.0) 
					FROM incomeestimate mov (NOLOCK)	
					JOIN income e (NOLOCK)					ON e.idinc = mov.idinc
					JOIN incomevar v (NOLOCK)				ON v.idinc = mov.idinc
					WHERE mov.idestimkind = estimate.idestimkind
												AND mov.yestim = estimate.yestim
												AND mov.nestim = estimate.nestim)
					,2)),
	estimate.active,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05,
	isnull(estimatedetail.cigcode,estimate.cigcode)
FROM estimatedetail (NOLOCK)
JOIN estimate (NOLOCK)			 	ON estimatedetail.idestimkind = estimate.idestimkind
											AND estimatedetail.yestim = estimate.yestim
  											AND estimatedetail.nestim = estimate.nestim
JOIN estimatekind (nolock)			ON estimate.idestimkind = estimatekind.idestimkind
LEFT OUTER JOIN totestimateview (NOLOCK)	ON totestimateview.idestimkind = estimate.idestimkind
													AND totestimateview.yestim = estimate.yestim
													AND totestimateview.nestim = estimate.nestim
left outer JOIN registry (NOLOCK) 	ON registry.idreg = estimatedetail.idreg
LEFT OUTER JOIN manager  (nolock)	ON manager.idman = estimate.idman
GROUP BY estimatedetail.idestimkind,estimate.idestimkind, 
	estimatedetail.yestim,estimate.yestim,
	estimate.nestim,estimatedetail.nestim,
	estimate.idreg,estimatedetail.idreg,
	estimatedetail.idupb,
	estimatekind.description,estimate.description,
	estimate.doc,estimate.docdate,estimate.adate,estimate.active, 
	estimate.idman,manager.title,
	taxabletotal,ivatotal,estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05,
	isnull(estimatedetail.cigcode,estimate.cigcode),registry.title







GO


