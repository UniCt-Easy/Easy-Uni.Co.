
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


-- CREAZIONE VISTA casualcontractresidual
IF EXISTS(select * from sysobjects where id = object_id(N'[casualcontractresidual]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [casualcontractresidual]
GO




CREATE  VIEW [casualcontractresidual]
(
	ycon,
	ncon,
	description,
	idreg,
	registry,
	start,
	stop,
	feegross,
	residual,
	linkedtotal,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	casualcontract.ycon,
	casualcontract.ncon,
	casualcontract.description,
	casualcontract.idreg,
	registry.title,
	casualcontract.start,
	casualcontract.stop,
	casualcontract.feegross,
	CONVERT(decimal(23,6),
		casualcontract.feegross -
		(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expensecasualcontract mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon
			--AND s.nphase =
			--	(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expensecasualcontract mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON (v.idexp = mov.idexp)
			WHERE mov.ycon = casualcontract.ycon 
			AND mov.ncon = casualcontract.ncon
			AND (ISNULL(v.autokind,0)<> 4)
			--AND s.nphase =
			--	(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationcasualcontract mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon)
		,0)
		)
	),
	CONVERT(decimal(23,6),
		(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expensecasualcontract mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon
			--AND s.nphase =
				--(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expensecasualcontract mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
			WHERE mov.ycon = casualcontract.ycon 
			AND mov.ncon = casualcontract.ncon
			AND (ISNULL(v.autokind,0)<> 4)
			--AND s.nphase =
				--(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationcasualcontract mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon)
		,0)
		)
	),
	casualcontract.idsor01,
	casualcontract.idsor02,
	casualcontract.idsor03,
	casualcontract.idsor04,
	casualcontract.idsor05
	FROM casualcontract (NOLOCK)
	JOIN registry (NOLOCK)
	ON registry.idreg = casualcontract.idreg


GO

