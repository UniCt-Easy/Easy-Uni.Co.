
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


-- CREAZIONE VISTA itinerationresidual
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationresidual]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationresidual]
GO

--setuser 'amministrazione'
CREATE     VIEW [itinerationresidual]
	(
	iditineration,
	yitineration,
	nitineration,
	description,
	idreg,
	registry,
	start,
	stop,
	totalgross,
	totadvance,
	residual,
	linkedsaldo,
	linkedangir,
	linkedanpag,
	active,
	completed,
	idupb,
	codeupb,
	upb,
	idaccmotive,
	codemotive,
	idsor1,
	idsor2,
	idsor3,
	iditinerationstatus,
	itinerationstatus,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
	AS SELECT
	itineration.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itineration.description,
	itineration.idreg,
	registry.title,
	itineration.start,      
	itineration.stop,
	itineration.totalgross,
	itineration.totadvance,
	--residual
	CONVERT(decimal(19,2),itineration.totalgross -
		(
		ISNULL(	
			(SELECT SUM(EY_start.amount)
			FROM expenseitineration mov			(nolock)
			JOIN expense s						(nolock)		ON s.idexp = mov.idexp
			LEFT OUTER JOIN expenseyear EY_start (NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			WHERE mov.iditineration = itineration.iditineration		AND ((mov.movkind = 4)OR(mov.movkind = 6))			
			)
		,0) 
		+
		--ISNULL(
		--	(SELECT SUM(v.amount)
		--	FROM expenseitineration mov		(NOLOCK) 
		--	JOIN expense s					(NOLOCK) 	ON s.idexp = mov.idexp
		--	LEFT OUTER JOIN expensevar v	(NOLOCK) 		ON (v.idexp = mov.idexp)
		--	WHERE mov.iditineration = itineration.iditineration
		--	AND ( (mov.movkind = 4 )OR(mov.movkind = 6 ))
		--	AND (ISNULL(v.autokind,0)<> 4) --'RITEN')
		--	--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
		--	)
		--,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationitineration mov (NOLOCK) 
			JOIN pettycashoperation p (NOLOCK) 	ON mov.idpettycash = p.idpettycash
													AND mov.yoperation = p.yoperation
													AND mov.noperation = p.noperation
			WHERE mov.iditineration = itineration.iditineration		AND mov.movkind = 6 )			
		,0)
		)
	),
	--linkedsaldo
	CONVERT(decimal(19,2),
		(
		ISNULL(	
			(SELECT SUM(EY_start.amount)
			FROM expenseitineration mov (NOLOCK) 
			JOIN expense s (NOLOCK) 
			ON s.idexp = mov.idexp
				LEFT OUTER JOIN expenseyear EY_start (NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			WHERE mov.iditineration = itineration.iditineration
			AND (mov.movkind = 4)			
			)
		,0) 
		--	+
		--ISNULL(
		--	(SELECT SUM(v.amount)
		--	FROM expenseitineration mov (NOLOCK) 
		--	JOIN expense s				(NOLOCK) 			ON s.idexp = mov.idexp
		--	LEFT OUTER JOIN expensevar v (NOLOCK) 			ON v.idexp = mov.idexp
		--	WHERE mov.iditineration = itineration.iditineration
		--	AND (mov.movkind = 4)		AND (ISNULL(v.autokind,0)<>4) --'RITEN')			
		--	)
		--,0)
		)
	) ,
	--linkedangir
	CONVERT(decimal(19,2),
		(
		ISNULL(
			(SELECT SUM(EY_start.amount)
			FROM expenseitineration mov (NOLOCK) 
			JOIN expense s (NOLOCK) 
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expenseyear EY_start (NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			WHERE mov.iditineration = itineration.iditineration 	AND (mov.movkind = 5)
			
			)
		,0) 
		+
		--ISNULL(
		--	(SELECT SUM(v.amount)
		--	FROM expenseitineration mov (NOLOCK) 
		--	JOIN expense s (NOLOCK) 						ON s.idexp = mov.idexp
		--	LEFT OUTER JOIN expensevar v (NOLOCK) 			ON v.idexp = mov.idexp
		--	WHERE mov.iditineration = itineration.iditineration	
		--			AND (mov.movkind = 5)	AND (ISNULL(v.autokind,0)<>4 ) --'RITEN')			
		--	)
		--,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationitineration mov (NOLOCK) 
			JOIN pettycashoperation p				(NOLOCK) 	ON mov.idpettycash = p.idpettycash
																AND mov.yoperation = p.yoperation
																AND mov.noperation = p.noperation
			WHERE mov.iditineration = itineration.iditineration
			AND mov.movkind = 5)
		,0)
		)
	),
	--linkedanpag
	CONVERT(decimal(19,2),
		(
		ISNULL(
			(SELECT SUM(EY_start.amount)
			FROM expenseitineration mov (NOLOCK) 
			JOIN expense s  (NOLOCK)								ON s.idexp = mov.idexp
				LEFT OUTER JOIN expenseyear EY_start (NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			WHERE mov.iditineration = itineration.iditineration
			AND (mov.movkind = 6)
			)
		,0) 
		+
		--ISNULL(
		--	(SELECT SUM(v.amount)
		--	FROM expenseitineration mov (NOLOCK) 
		--	JOIN expense s	(NOLOCK)					ON s.idexp = mov.idexp
		--	LEFT OUTER JOIN expensevar v (NOLOCK) 		ON v.idexp = mov.idexp
		--	WHERE mov.iditineration = itineration.iditineration
		--		AND (mov.movkind = 6 )	AND (ISNULL(v.autokind,0)<>4) --'RITEN')
		--	)
		--,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationitineration mov (NOLOCK) 
			JOIN pettycashoperation p	(NOLOCK) 		ON mov.idpettycash = p.idpettycash
															AND mov.yoperation = p.yoperation
															AND mov.noperation = p.noperation
			WHERE mov.iditineration = itineration.iditineration		AND mov.movkind = 6)
		,0)
		)
	),
	itineration.active,
	itineration.completed,
	itineration.idupb,
	upb.codeupb,
	upb.title,
	itineration.idaccmotive,
	accmotive.codemotive,
	itineration.idsor1,
	itineration.idsor2,
	itineration.idsor3,
	itineration.iditinerationstatus,
	itinerationstatus.description,
	itineration.idsor01,itineration.idsor02,itineration.idsor03,itineration.idsor04,itineration.idsor05
	FROM itineration with (nolock)
	JOIN registry with (nolock)								ON registry.idreg = itineration.idreg
	LEFT OUTER JOIN upb with (nolock)						ON upb.idupb = itineration.idupb
	LEFT OUTER JOIN accmotive with (nolock)					ON accmotive.idaccmotive = itineration.idaccmotive
	LEFT OUTER JOIN itinerationstatus  with (nolock)		ON itinerationstatus.iditinerationstatus= itineration.iditinerationstatus

GO
