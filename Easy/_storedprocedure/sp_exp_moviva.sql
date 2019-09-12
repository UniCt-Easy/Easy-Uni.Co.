if exists (select * from dbo.sysobjects where id = object_id(N'[sp_exp_moviva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sp_exp_moviva]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



CREATE   PROCEDURE sp_exp_moviva
	@ayear smallint,
	@tipomovimento char(1),
	@datebegin smalldatetime,
	@dateend smalldatetime
AS
BEGIN
	DECLARE @fasemovimento int
	DECLARE @desctipoclass varchar(50)
	DECLARE @idsorkind int
	SELECT @idsorkind = idsorkind from sortingkind where codesorkind = 'CTERZI'

	CREATE TABLE #rptelencomovnonc
	(
		idsorkind int,
		desctipoclass varchar(50),
		sortcode varchar(50),
		descsortcode varchar(200),
		datamovimento smalldatetime,
		fasemovimento varchar(50),
		ymov smallint,
		nmov integer,
		idmovim int,
		registry varchar(100),
		badgecode varchar(20),
		codefin varchar(50),
		codiceupb varchar(50),
		manager varchaR(150),
		description varchar(150),
		curramount dec(19,2),
		cassa dec(19,2),
		amountclassif dec(19,2),
		curramountres dec(19,2),
		cassares dec(19,2)
	)

	IF @tipomovimento = 'E'
	BEGIN
		SELECT @desctipoclass = description, 
			@fasemovimento = nphaseincome
		FROM sortingkind
		WHERE idsorkind  = @idsorkind

		INSERT INTO #rptelencomovnonc
		(
			idsorkind,
			desctipoclass,
			sortcode,
			descsortcode,
			datamovimento,
			fasemovimento,
			ymov,
			nmov,
			idmovim,
			registry,
			badgecode,
			codefin,
			codiceupb,
			manager,
			description,
			curramount,
			amountclassif
		)
		SELECT
			@idsorkind,
			@desctipoclass,
			incomesortedview.sortcode,
			incomesortedview.sorting,
			income.adate,
			incomephase.description,
			income.ymov,
			income.nmov,
			income.idinc,
			registry.title,
			registry.badgecode,
			fin.codefin,
			upb.codeupb,
			manager.title,
			income.description,
			incometotal.curramount,
			incomesortedview.amount
		FROM income
		JOIN incometotal
			ON incometotal.idinc = income.idinc
		LEFT OUTER JOIN manager
			ON manager.idman = income.idman
		JOIN incomeyear
			ON incomeyear.idinc = income.idinc
		JOIN incomephase
			ON incomephase.nphase = income.nphase
		LEFT OUTER JOIN registry
			ON registry.idreg = income.idreg
		LEFT OUTER JOIN fin
			ON fin.idfin = incomeyear.idfin
		LEFT OUTER JOIN upb
			ON upb.idupb = incomeyear.idupb
		JOIN incomesortedview
			ON income.idinc = incomesortedview.idinc
		WHERE income.adate BETWEEN @datebegin AND @dateend
			AND income.nphase = @fasemovimento AND incomesortedview.idsorkind = @idsorkind
			AND incomesortedview.ayear = @ayear
			AND incomeyear.ayear = @ayear
			AND incometotal.ayear = @ayear

		UPDATE #rptelencomovnonc
		SET cassa =
			(SELECT SUM(incometotal.curramount)
				FROM incometotal JOIN incomelast
					ON incometotal.idinc = incomelast.idinc
					AND incometotal.ayear = @ayear
				join incomelink on incomelink.idparent = #rptelencomovnonc.idmovim
					and incomelink.idchild = incomelast.idinc)
	END
	ELSE
	BEGIN
		SELECT @desctipoclass = description, 
			@fasemovimento = nphaseexpense
			FROM sortingkind
			WHERE idsorkind  = @idsorkind

		INSERT INTO #rptelencomovnonc
		(
			idsorkind,
			desctipoclass,
			sortcode,
			descsortcode,
			datamovimento,
			fasemovimento,
			ymov,
			nmov,
			idmovim,
			registry,
			badgecode,
			codefin,
			codiceupb,
			manager,
			description,
			curramount,
			amountclassif
		)
		SELECT
			@idsorkind,
			@desctipoclass,
			expensesortedview.sortcode,
			expensesortedview.sorting,
			expense.adate,
			expensephase.description,
			expense.ymov,
			expense.nmov,
			expense.idexp,
			registry.title,
			registry.badgecode,
			fin.codefin,
			upb.codeupb,
			manager.title,
			expense.description,
			expensetotal.curramount,
			expensesortedview.amount
		FROM expense
		JOIN expensetotal
			ON expensetotal.idexp = expense.idexp
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
		JOIN expensephase
			ON expensephase.nphase = expense.nphase
		LEFT OUTER JOIN manager
			ON manager.idman = expense.idman
		LEFT OUTER JOIN registry
			ON registry.idreg = expense.idreg
		LEFT OUTER JOIN fin
			ON fin.idfin = expenseyear.idfin
		LEFT OUTER JOIN upb
			ON upb.idupb = expenseyear.idupb
		JOIN expensesortedview
			ON expense.idexp = expensesortedview.idexp
		WHERE expense.adate BETWEEN @datebegin AND @dateend
			AND expense.nphase = @fasemovimento
			AND expensesortedview.ayear = @ayear
			AND expensetotal.ayear = @ayear
			AND expenseyear.ayear = @ayear
					
		UPDATE #rptelencomovnonc
		SET cassa = (SELECT SUM (expensetotal.curramount)
				FROM expensetotal 
				JOIN expenselast 
					ON expensetotal.idexp = expenselast.idexp
					AND expensetotal.ayear = @ayear
				join expenselink 
					on expenselink.idparent = #rptelencomovnonc.idmovim
					and expenselink.idchild = expenselast.idexp)
	END

	UPDATE #rptelencomovnonc
	SET 	curramountres = curramount,
		cassares = cassa ,
		curramount = 0,
		cassa  = 0
		where ymov <> @ayear

	SELECT
		fasemovimento,
		ymov as esercmovimento,
		nmov as nummovimento,
		codefin as codicebilancio,
		codiceupb as codicecentrospesa,
		registry as creditoredebitore,
		badgecode as codicebadge,
		description as descrizione,
		curramount as importocorrente,
		amountclassif as importoclassif,
		cassa,
		CASE 
			WHEN sortcode like 'BI%' THEN 'BI'
			WHEN sortcode like 'RI1%' THEN 'RI'
			ELSE SUBSTRING(sortcode,1,3)
		END,
		CASE 
			WHEN sortcode like 'BI%'   THEN SUBSTRING(sortcode,3,3)
			WHEN sortcode like 'RI1%' THEN SUBSTRING(sortcode,3,3)
			ELSE SUBSTRING(sortcode,4,3)
		END,
		descsortcode as desccodiceclass,
		datamovimento	
	FROM #rptelencomovnonc 
	ORDER BY codefin ASC, 
	datamovimento ASC,
	ymov ASC,
	nmov ASC
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
