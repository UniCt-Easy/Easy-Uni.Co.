-- CREAZIONE VISTA wageadditionresidual
IF EXISTS(select * from sysobjects where id = object_id(N'[wageadditionresidual]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [wageadditionresidual]
GO




CREATE                                        VIEW [wageadditionresidual]
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
	idsor01,idsor02,idsor03,idsor04,idsor05
	)
	AS SELECT
	wageaddition.ycon,
	wageaddition.ncon,
	wageaddition.description,
	wageaddition.idreg,
	registry.title,
	wageaddition.start,
	wageaddition.stop,
	wageaddition.feegross,
	CONVERT(decimal(23,6),
		wageaddition.feegross
		-
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
			) +
			(SELECT ISNULL(SUM(v.amount), 0.0)
			FROM expensewageaddition mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON (v.idexp = mov.idexp)
			WHERE mov.ycon = wageaddition.ycon 
			AND mov.ncon = wageaddition.ncon
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase =(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		)
	),
	CONVERT(decimal(23,6),
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
			) +
			(SELECT ISNULL(SUM(v.amount), 0.0)
			FROM expensewageaddition mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
			WHERE mov.ycon = wageaddition.ycon 
			AND mov.ncon = wageaddition.ncon
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = 	(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		)
	),
	wageaddition.idsor01,wageaddition.idsor02,wageaddition.idsor03,wageaddition.idsor04,wageaddition.idsor05
	FROM wageaddition (NOLOCK)
	JOIN registry (NOLOCK)
	ON registry.idreg = wageaddition.idreg









GO
