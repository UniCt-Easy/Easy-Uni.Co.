-- CREAZIONE VISTA casualcontractavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[casualcontractavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [casualcontractavailable]
GO




CREATE  VIEW [casualcontractavailable]
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
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	casualcontract.ycon,
	casualcontract.ncon,
	casualcontract.idreg,
	registry.title,
	casualcontract.description,
	casualcontract.start,
	casualcontract.stop,
	casualcontract.feegross,
-- Calcolo TOTALEMOVIMENTI
	CONVERT(decimal(19,2),
		ROUND(
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
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
			,0) +
			ISNULL(
				(SELECT SUM(v.amount)
				FROM expensecasualcontract mov
				JOIN expense s
				ON s.idexp = mov.idexp
				JOIN expensevar v
				ON v.idexp = mov.idexp
				WHERE mov.ycon = casualcontract.ycon
				AND mov.ncon = casualcontract.ncon
				AND (ISNULL(v.autokind,0)<> 4)
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
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
		,2)
	),	
-- RESIDUO = costototale - totalemovimenti
	CONVERT(decimal(19,2),
		ROUND(
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
					
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
				,0) +
				ISNULL(
					(SELECT SUM(v.amount)
					FROM expensecasualcontract mov
					JOIN expense s
					ON s.idexp = mov.idexp
					JOIN expensevar v
					ON v.idexp = mov.idexp
					WHERE mov.ycon = casualcontract.ycon
					AND mov.ncon = casualcontract.ncon
					AND (ISNULL(v.autokind,0)<> 4)
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
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
		,2)
	),
	casualcontract.idupb,
	upb.codeupb,
	upb.title,
	casualcontract.completed,
	casualcontract.idsor01,
	casualcontract.idsor02,
	casualcontract.idsor03,
	casualcontract.idsor04,
	casualcontract.idsor05

	FROM casualcontract (NOLOCK)
	JOIN registry (NOLOCK)
		ON registry.idreg = casualcontract.idreg
	LEFT OUTER JOIN upb 	
		ON upb.idupb=casualcontract.idupb
	WHERE (casualcontract.feegross >
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
				)
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
		
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expensecasualcontract mov
			JOIN expense s    ON s.idexp = mov.idexp
			JOIN expensevar v ON v.idexp = mov.idexp
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
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
	OR
	 ((casualcontract.feegross = 
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
	   AND
	   NOT EXISTS (select * from expensecasualcontract E where 
				E.ycon=casualcontract.ycon  and E.ncon=casualcontract.ncon) 
	)







GO

