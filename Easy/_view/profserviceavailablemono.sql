/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿-- CREAZIONE VISTA profserviceavailablemono
IF EXISTS(select * from sysobjects where id = object_id(N'[profserviceavailablemono]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [profserviceavailablemono]
GO


CREATE          VIEW [profserviceavailablemono]
	(
	ycon,
	ncon,
	idreg,
	registry,
	description,
	doc,
	docdate,
	start,
	stop,
	adate,
	idupb,
	ivaamount,
	feegross,
	totalcost,
	totalgross,
	taxabletotal,
	ivatotal,
	linkedtotal,
	residual,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	idinvkind, yinv, ninv
	)
	AS SELECT
	profservice.ycon,
	profservice.ncon,
	profservice.idreg,
	registry.title,
	profservice.description,
 	profservice.doc,
	profservice.docdate,
	profservice.start,
	profservice.stop,
	profservice.adate,
	profservice.idupb,
	profservice.ivaamount,
	profservice.feegross,
	profservice.totalcost,
	profservice.totalgross,
-- TOTALEIMPONIBILE = importobeneficiario - importoiva
	CONVERT(decimal(19,2),
		ROUND(profservice.totalgross - ISNULL(profservice.ivaamount,0),2)
	),
	profservice.ivaamount,
-- Calcolo TOTALEMOVIMENTI 	linkedtotal
CONVERT(decimal(23,5),
		ISNULL(
			(SELECT TOP 1 expenseyear_starting.amount
			FROM expenseinvoice i 
				join expense s 	ON s.idexp = i.idexp
			join invoicedetail id
				on i.idinvkind = id.idinvkind and i.yinv = id.yinv and i.ninv = id.ninv 
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE profservice.ycon = id.ycon and profservice.ncon = id.ncon
					AND s.idexp = id.idexp_taxable)
		,0) +
		ISNULL(
			(SELECT TOP 1 expenseyear_starting.amount
			FROM expenseinvoice i 
				join expense s 	ON s.idexp = i.idexp
			join invoicedetail id
				on i.idinvkind = id.idinvkind and i.yinv = id.yinv and i.ninv = id.ninv 
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE profservice.ycon = id.ycon and profservice.ncon = id.ncon
				AND s.idexp = id.idexp_iva and isnull(id.idexp_iva,0)<>isnull(id.idexp_taxable,0))
		,0)/*+
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationinvoice mov
			JOIN pettycashoperation p
				ON mov.idpettycash = p.idpettycash
				AND mov.yoperation = p.yoperation
				AND mov.noperation = p.noperation
			WHERE mov.idinvkind = IDET.idinvkind
				AND mov.yinv = IDET.yinv
				AND mov.ninv = IDET.ninv)
		,0)*/
	 +
				ISNULL(
					(SELECT SUM(v.amount)
					FROM expenseinvoice i 
					join expense s 	ON s.idexp = i.idexp
					join invoicedetail id
						on i.idinvkind = id.idinvkind and i.yinv = id.yinv and i.ninv = id.ninv
					JOIN expensevar v
						ON v.idexp = s.idexp
					WHERE  profservice.ycon = id.ycon and profservice.ncon = id.ncon
					AND (s.idexp = id.idexp_iva or s.idexp = id.idexp_taxable)
					AND (ISNULL(v.autokind,0)<>4)
					)
				,0) 
),

-- RESIDUO = importobeneficiario - totalemovimenti
	CONVERT(decimal(19,2),
		ROUND(
			profservice.totalgross - 
		ISNULL(
			(SELECT TOP 1 expenseyear_starting.amount
			FROM expenseinvoice i 
				join expense s 	ON s.idexp = i.idexp
			join invoicedetail id
			on i.idinvkind = id.idinvkind and i.yinv = id.yinv and i.ninv = id.ninv 
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE profservice.ycon = id.ycon and profservice.ncon = id.ncon
					AND s.idexp = id.idexp_taxable)
		,0) +
		ISNULL(
			(SELECT TOP 1 expenseyear_starting.amount
			FROM expenseinvoice i 
			join expense s 	ON s.idexp = i.idexp
			join invoicedetail id
				on i.idinvkind = id.idinvkind and i.yinv = id.yinv and i.ninv = id.ninv 
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE profservice.ycon = id.ycon and profservice.ncon = id.ncon
				AND s.idexp = id.idexp_iva and isnull(id.idexp_iva,0)<>isnull(id.idexp_taxable,0))
		,0)/*+
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationinvoice mov
			JOIN pettycashoperation p
				ON mov.idpettycash = p.idpettycash
				AND mov.yoperation = p.yoperation
				AND mov.noperation = p.noperation
			WHERE mov.idinvkind = IDET.idinvkind
				AND mov.yinv = IDET.yinv
				AND mov.ninv = IDET.ninv)
		,0)*/
	+
			ISNULL(
					(SELECT SUM(v.amount)
					FROM expenseinvoice i 
					join expense s 	ON s.idexp = i.idexp
					join invoicedetail id
						on i.idinvkind = id.idinvkind and i.yinv = id.yinv and i.ninv = id.ninv
					JOIN expensevar v
						ON v.idexp = s.idexp
					WHERE  profservice.ycon = id.ycon and profservice.ncon = id.ncon
					AND (s.idexp = id.idexp_iva or s.idexp = id.idexp_taxable)
					AND (ISNULL(v.autokind,0)<>4)
					)
				,0) 

		,2)
	)
	,
	profservice.idsor01,profservice.idsor02,profservice.idsor03,profservice.idsor04,profservice.idsor05,
	profservice.idinvkind, profservice.yinv, profservice.ninv
	FROM profservice (NOLOCK)
	JOIN registry (NOLOCK)
	ON registry.idreg = profservice.idreg
		








GO

	


	