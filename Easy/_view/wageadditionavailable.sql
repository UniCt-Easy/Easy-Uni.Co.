
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


-- CREAZIONE VISTA wageadditionavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[wageadditionavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [wageadditionavailable]
GO


CREATE                                        VIEW [wageadditionavailable]
	(
	ycon,
	ncon,
	idreg,
	registry,
	description,
	start,
	stop,
	feegross,
	linkedtotal,
	residual,
	idupb,
	coudeupb,
	upb,
	completed,
	idsor01,idsor02,idsor03,idsor04,idsor05
	)
	AS SELECT
	wageaddition.ycon,
	wageaddition.ncon,
	wageaddition.idreg,
	registry.title,
	wageaddition.description,
	wageaddition.start,
	wageaddition.stop,
	wageaddition.feegross,
-- Calcolo TOTALEMOVIMENTI
	CONVERT(decimal(19,2),
		ROUND(
			(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
			FROM expensewageaddition mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
					ON expensetotal_firstyear.idexp = s.idexp
					AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = wageaddition.ycon
				AND mov.ncon = wageaddition.ncon
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				) 
			+
			(SELECT ISNULL(SUM(v.amount), 0.0)
			FROM expensewageaddition mov
			JOIN expense s
				ON s.idexp = mov.idexp
			JOIN expensevar v
				ON v.idexp = mov.idexp
			WHERE mov.ycon = wageaddition.ycon
				AND mov.ncon = wageaddition.ncon
				AND (ISNULL(v.autokind,0)<> 4)
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
		,2)
	),	
-- RESIDUO = costototale - totalemovimenti
	CONVERT(decimal(19,2),
		ROUND(
			wageaddition.feegross - 
			(
				(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
				FROM expensewageaddition mov
				JOIN expense s
					ON s.idexp = mov.idexp
				LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
					ON expensetotal_firstyear.idexp = s.idexp
					AND ((expensetotal_firstyear.flag & 2) <> 0 )
				LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
					ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
				WHERE mov.ycon = wageaddition.ycon
					AND mov.ncon = wageaddition.ncon
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
					) 
				+
				(SELECT ISNULL(SUM(v.amount), 0.0)
				FROM expensewageaddition mov
				JOIN expense s
					ON s.idexp = mov.idexp
				JOIN expensevar v
					ON v.idexp = mov.idexp
				WHERE mov.ycon = wageaddition.ycon
					AND mov.ncon = wageaddition.ncon
					AND (ISNULL(v.autokind,0)<> 4)
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
					)
			)
		,2)
	),
	wageaddition.idupb,
	upb.codeupb,
	upb.title,
	wageaddition.completed,
	wageaddition.idsor01,wageaddition.idsor02,wageaddition.idsor03,wageaddition.idsor04,wageaddition.idsor05
	FROM wageaddition (NOLOCK)
	JOIN registry (NOLOCK)					ON registry.idreg = wageaddition.idreg
	LEFT OUTER JOIN upb 	 (NOLOCK)		ON upb.idupb = wageaddition.idupb
	WHERE wageaddition.feegross >
			(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
				FROM expensewageaddition mov
					JOIN expense s		ON s.idexp = mov.idexp
					LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
					ON expensetotal_firstyear.idexp = s.idexp
					AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
					ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
						AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = wageaddition.ycon
				AND mov.ncon = wageaddition.ncon
		--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
	) +
	(SELECT ISNULL(SUM(v.amount), 0.0)
		FROM expensewageaddition mov
		JOIN expense s				ON s.idexp = mov.idexp
		JOIN expensevar v			ON v.idexp = mov.idexp
		WHERE mov.ycon = wageaddition.ycon		AND mov.ncon = wageaddition.ncon
			AND (isnull(v.autokind,0)<>4)
		--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
	)

GO

