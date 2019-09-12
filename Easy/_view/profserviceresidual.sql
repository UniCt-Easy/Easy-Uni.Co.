-- CREAZIONE VISTA profserviceresidual
IF EXISTS(select * from sysobjects where id = object_id(N'[profserviceresidual]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [profserviceresidual]
GO


CREATE   VIEW [profserviceresidual]
(
	ycon,
	ncon,
	description,
	idreg,
	registry,
	start,
	stop,
	feegross,
	totalcost,
	totalgross,
	taxabletotal,
	ivatotal,
	residual,
	linkedimpon,
	linkedimpos,
	linkeddocum,
	linkedtotal,
	linkedtotalexpense,
	idupb,
	codeupb,
	upb,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT
profservice.ycon,
profservice.ncon,
profservice.description,
profservice.idreg,
registry.title,
profservice.start,
profservice.stop,
profservice.feegross,
profservice.totalcost,
profservice.totalgross,
-- TOTALEIMPONIBILE = costototale - importoiva
CONVERT(decimal(19,2),
	ROUND(profservice.totalgross - ISNULL(profservice.ivaamount,0),2)
),
profservice.ivaamount,
-- Calcolo del RESIDUO
CONVERT(decimal(19,2),
	ROUND(
--select top 1 totflag,flagarrear from historypaymentview
		profservice.totalgross -
		(
			ISNULL(
				(SELECT SUM(expenseyear_starting.amount)
				FROM expenseprofservice mov
				JOIN expense s
					ON s.idexp = mov.idexp
				LEFT OUTER JOIN expensetotal expensetotal_firstyear
					ON expensetotal_firstyear.idexp = s.idexp
					AND ((expensetotal_firstyear.flag & 2) <> 0 )
				LEFT OUTER JOIN expenseyear expenseyear_starting 
					ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
				WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
			,0) +
			ISNULL(
				(SELECT ISNULL(SUM(v.amount), 0.0)
				FROM expenseprofservice mov
				JOIN expense s
					ON s.idexp = mov.idexp
				LEFT OUTER JOIN expensevar v
					ON (v.idexp = mov.idexp)
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
-- Calcolo del CONTIMPON (imponibile contabilizzato)
CONVERT(decimal(19,2),
	(
		(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
		FROM expenseprofservice mov  
		JOIN expense s
			ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensetotal expensetotal_firstyear
			ON expensetotal_firstyear.idexp = s.idexp
			AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
		WHERE mov.ycon = profservice.ycon
			AND mov.ncon = profservice.ncon
			AND (mov.movkind = 3)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
		) +
		(SELECT ISNULL(SUM(v.amount), 0.0)
		FROM expenseprofservice mov
		JOIN expense s
			ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
		WHERE mov.ycon = profservice.ycon
			AND mov.ncon = profservice.ncon
			AND mov.movkind = 3
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
	)
),
-- Calcolo del CONTIMPOS (imposta contabilizzata)
CONVERT(decimal(19,2),
	(
		(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
		FROM expenseprofservice mov
		JOIN expense s
			ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensetotal expensetotal_firstyear
			ON expensetotal_firstyear.idexp = s.idexp
			AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
		WHERE mov.ycon = profservice.ycon
			AND mov.ncon = profservice.ncon
			AND (mov.movkind = 2)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
		) +
		(SELECT ISNULL(SUM(v.amount), 0.0)
		FROM expenseprofservice mov
		JOIN expense s
			ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
		WHERE mov.ycon = profservice.ycon
			AND mov.ncon = profservice.ncon
			AND mov.movkind = 2
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
	)
),
-- Calcolo del CONTDOCUM (totale del documento contabilizzato)
CONVERT(decimal(19,2),
	(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expenseprofservice mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear
				ON expensetotal_firstyear.idexp = s.idexp
				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon
				AND (mov.movkind = 1)
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expenseprofservice mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
				ON v.idexp = mov.idexp
			WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon
				AND mov.movkind = 1
				AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0)
		+
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
),
-- Calcolo di TOTCONTABILIZZATO
CONVERT(decimal(19,2),
	(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount) 
			FROM expenseprofservice mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear
				ON expensetotal_firstyear.idexp = s.idexp
				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting 
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
			LEFT OUTER JOIN expensevar v
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
),
-- TOTCONTABILIZZATOSPESA
CONVERT(decimal(19,2),
	(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount) 
			FROM expenseprofservice mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear
				ON expensetotal_firstyear.idexp = s.idexp
				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting 
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
			LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
			WHERE mov.ycon = profservice.ycon 
			AND mov.ncon = profservice.ncon
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0)
	)
),
	upb.idupb,
	upb.codeupb,
	upb.title,
	profservice.idsor01,profservice.idsor02,profservice.idsor03,profservice.idsor04,profservice.idsor05
FROM profservice  with (nolock)
JOIN registry  with (nolock)
ON registry.idreg = profservice.idreg
LEFT OUTER JOIN upb with (nolock)
	ON upb.idupb = profservice.idupb

GO
