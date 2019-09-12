-- CREAZIONE VISTA profserviceavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[profserviceavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [profserviceavailable]
GO


CREATE          VIEW [profserviceavailable]
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
	feegross,
	totalcost,
	totalgross,
	taxabletotal,
	ivatotal,
	linkedtotal,
	residual,
	idsor01,idsor02,idsor03,idsor04,idsor05
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
	profservice.feegross,
	profservice.totalcost,
	profservice.totalgross,
-- TOTALEIMPONIBILE = importobeneficiario - importoiva
	CONVERT(decimal(19,2),
		ROUND(profservice.totalgross - ISNULL(profservice.ivaamount,0),2)
	),
	profservice.ivaamount,
-- Calcolo TOTALEMOVIMENTI
	CONVERT(decimal(19,2),
		ROUND(
			ISNULL(
				(SELECT SUM(expenseyear_starting.amount)
				FROM expenseprofservice mov
				JOIN expense s
					ON s.idexp = mov.idexp
				LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
					ON expensetotal_firstyear.idexp = s.idexp
					AND ((expensetotal_firstyear.flag & 2) <> 0 )
				LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
					ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
				WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
			,0) +
			ISNULL(
				(SELECT SUM(v.amount)
				FROM expenseprofservice mov
				JOIN expense s
				ON s.idexp = mov.idexp
				JOIN expensevar v
				ON v.idexp = mov.idexp
				WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon
				AND (ISNULL(v.autokind,0)<>4)
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
			,0) +
			ISNULL(
				(SELECT SUM(p.amount)
				FROM pettycashoperationprofservice mov
				JOIN pettycashoperation p
				ON mov.idpettycash = p.idpettycash
				AND mov.yoperation = p.yoperation
				AND mov.noperation = p.noperation
				WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon)
			,0)
		,2)
	),
-- RESIDUO = importobeneficiario - totalemovimenti
	CONVERT(decimal(19,2),
		ROUND(
			profservice.totalgross - 
			(
				ISNULL(
					(SELECT SUM(expenseyear_starting.amount)
					FROM expenseprofservice mov
					JOIN expense s
						ON s.idexp = mov.idexp
					LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
						ON expensetotal_firstyear.idexp = s.idexp
						AND ((expensetotal_firstyear.flag & 2) <> 0 )
					LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
						ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
						AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
					WHERE mov.ycon = profservice.ycon
						AND mov.ncon = profservice.ncon
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
				,0) +
				ISNULL(
					(SELECT SUM(v.amount)
					FROM expenseprofservice mov
					JOIN expense s
					ON s.idexp = mov.idexp
					JOIN expensevar v
					ON v.idexp = mov.idexp
					WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon
					AND (ISNULL(v.autokind,0)<>4)
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
					)
				,0) +
				ISNULL(
					(SELECT SUM(p.amount)
					FROM pettycashoperationprofservice mov
					JOIN pettycashoperation p
					ON mov.idpettycash = p.idpettycash
					AND mov.yoperation = p.yoperation
					AND mov.noperation = p.noperation
					WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon)
				,0)
			)
		,2)
	),
	profservice.idsor01,profservice.idsor02,profservice.idsor03,profservice.idsor04,profservice.idsor05
	FROM profservice (NOLOCK)
	JOIN registry (NOLOCK)
	ON registry.idreg = profservice.idreg
	WHERE profservice.totalgross >
	ISNULL(
		(SELECT SUM(expenseyear_starting.amount)
		FROM expenseprofservice mov
		JOIN expense s
			ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
			ON expensetotal_firstyear.idexp = s.idexp
			AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
		WHERE mov.ycon = profservice.ycon
			AND mov.ncon = profservice.ncon
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
		)
	,0) +
	ISNULL(
		(SELECT SUM(v.amount)
		FROM expenseprofservice mov
		JOIN expense s
		ON s.idexp = mov.idexp
		JOIN expensevar v
		ON v.idexp = mov.idexp
		WHERE mov.ycon = profservice.ycon
		AND mov.ncon = profservice.ncon
		AND (ISNULL(v.autokind,0)<>4)
		--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
		)
	,0) +
	ISNULL(
		(SELECT SUM(p.amount)
		FROM pettycashoperationprofservice mov
		JOIN pettycashoperation p
		ON mov.idpettycash = p.idpettycash
		AND mov.yoperation = p.yoperation
		AND mov.noperation = p.noperation
		WHERE mov.ycon = profservice.ycon
		AND mov.ncon = profservice.ncon)
	,0)








GO
