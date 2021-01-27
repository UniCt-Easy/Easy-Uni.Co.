
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_sorting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_sorting]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO







CREATE     PROCEDURE rpt_partitario_sorting
	@ayear int,
	@kind char(1),
	@showupb char(1),
	@idupb	varchar(36),
	@showchildupb char(1),
	@nlevel varchar(20),
	@codefin varchar(50),
	@start datetime,
	@stop datetime,
	@suppressifblank char(1),
	@flagnofficial	char(1),
	@idsor varchar(32), 
	@idsorkind varchar(20),
	@finpart varchar(1)
AS
BEGIN
CREATE TABLE #previousexpense
(
	idfin varchar(31),
	idupb varchar(36),
	initialprevision decimal(19,2),
	finvar decimal(19,2),
	finphase_amount decimal(19,2),
	cassaphase_amount decimal(19,2)
)
DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END	
DECLARE @level varchar(50)
SELECT @level = description 
FROM finlevel
WHERE nlevel = @nlevel AND ayear = @ayear
DECLARE @levelusable varchar(20)             ----------forse da cambiare perchè dovrebbe essere quello legato alla classificazione
SELECT @levelusable = MIN(nlevel)
FROM finlevel
WHERE flag&2 <> 0 AND ayear = @ayear
IF (@levelusable < @nlevel)
BEGIN	
	SET @levelusable = @nlevel		-------o forse sarebbe questo da verificare in base al sotto della sp
END
DECLARE @finphase varchar(20)

SELECT @finphase = appropriationphasecode
FROM config
WHERE ayear = @ayear
IF (@finphase IS NULL)
BEGIN
	SELECT @finphase = expensefinphase
	FROM uniconfig
END
DECLARE @maxexpensephase varchar(20)



SELECT @maxexpensephase = nphaseexpense from sortingkind where idsorkind=@idsorkind   --- HO settato maxexpensephase uguale alla fase relativa alla classificazione in questione


IF (@codefin = ' ')
BEGIN
	SELECT @codefin = (NULL)
END
---
SET @codefin = RTRIM(@codefin)
DECLARE @len_codefin int
SET @len_codefin = DATALENGTH(RTRIM(@codefin))
DECLARE @len_finlevel int
SET @len_finlevel = (CONVERT(int, @nlevel)*4)+3
---
CREATE TABLE #expense
(
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
	idfin varchar(31),
	rowkind	int,
	idmov varchar(40),
	nphase varchar(20),
	operationdate datetime,
	operationkind varchar(55),
	idreg int,
	ymov int,
	nmov int,
	nofficial int,
	nsubmov int,
	ndoc int,
	description varchar(150),
        doc varchar(150),
	initialprevision decimal(19,2),
	finvar decimal(19,2),
	finphase_amount decimal(19,2),
	cassaphase_amount decimal(19,2),
	emessiondate datetime,
	printeddate datetime,
	trasmitteddate datetime,
	transactiondate datetime,
	annulmentdate datetime,
	annotations varchar(400)
)

DECLARE @firstday datetime    -- setta la data inizio da valurare all'01/01 del corrente esercizio
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)

DECLARE @previsionkind varchar(1)
DECLARE @secprevisionkind varchar(1)
SELECT @previsionkind = previsionkind,
	@secprevisionkind = secprevisionkind
FROM config 
WHERE ayear = @ayear
DECLARE @cashvaliditykind		char(1)
SELECT @cashvaliditykind = cashvaliditykind
FROM config
WHERE ayear = @ayear
IF ((@kind IN ('C','S')) AND (DATEDIFF(DAY,@start, @firstday) = 0))	---In base al tipo di previsioni principali e secondarie
BEGIN
---- caricamente della tabella di appoggio spesa.

	INSERT INTO #expense   ----parte col caricare le previsioni nella tabella di appoggio di spesa.
	(
		idfin,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		rowkind,
		operationdate,
		operationkind,
		initialprevision
	)
	SELECT 
		fin.idfin,
		upb.codeupb,
		upb.idupb,
		upb.title,
		upb.printingorder,
		1,
		@firstday,
		'Prev.iniziale',
		CASE
			WHEN @kind = 'C' THEN (SELECT SUM(fy2.prevision) 
						FROM finyear fy2 
						JOIN fin f2
							ON fy2.idfin=f2.idfin
						WHERE SUBSTRING(fy2.idfin, 1,@len_finlevel) = fin.idfin
							AND f2.nlevel = @levelusable AND fy2.idupb= upb.idupb)
			WHEN (@kind = 'S' and @previsionkind = 'S') 
					THEN (SELECT SUM(fy2.prevision) 
						FROM finyear fy2 
						JOIN fin f2
							ON fy2.idfin=f2.idfin
						WHERE SUBSTRING(fy2.idfin, 1,@len_finlevel) = fin.idfin
							AND f2.nlevel = @levelusable AND fy2.idupb= upb.idupb)
			WHEN (@kind = 'S' and @secprevisionkind = 'S') 
					THEN (SELECT SUM(fy2.secondaryprev) 
						FROM finyear fy2 
						JOIN fin f2
							ON fy2.idfin=f2.idfin
						WHERE SUBSTRING(fy2.idfin, 1,@len_finlevel) = fin.idfin
							AND f2.nlevel = @levelusable AND fy2.idupb= upb.idupb)
		END
	FROM finyear
	JOIN fin
		ON finyear.idfin = fin.idfin
	JOIN upb
		ON finyear.idupb = upb.idupb
	WHERE (upb.idupb like @idupb )
		AND fin.ayear = @ayear
		AND fin.finpart = 'S'
		AND fin.nlevel = @nlevel
		AND (@codefin IS NULL
		OR SUBSTRING(fin.codefin, 1,@len_codefin) = @codefin)
END
IF (DATEDIFF(DAY,@start, @firstday) <> 0)
BEGIN
	INSERT INTO #previousexpense
		(
		idfin,
		idupb
		)
	SELECT finyear.idfin,
	       finyear.idupb
	FROM finyear
	JOIN fin
		ON finyear.idfin = fin.idfin
	JOIN upb
		ON finyear.idupb = upb.idupb
	WHERE (upb.idupb like @idupb )
		AND fin.ayear = @ayear
		AND fin.finpart = 'S'
		AND fin.nlevel = @nlevel
		AND (@codefin IS NULL OR SUBSTRING(fin.codefin, 1,@len_codefin) = @codefin)
	IF @kind = 'C' OR @kind = 'S'
	BEGIN
		UPDATE #previousexpense
		SET initialprevision =
			(SELECT 
				CASE
					WHEN @kind = 'C' THEN SUM(u2.prevision) 
					WHEN (@kind = 'S' and @previsionkind = 'S') THEN SUM(u2.prevision) 
					WHEN (@kind = 'S' and @secprevisionkind = 'S') THEN SUM(u2.secondaryprev) 
				END
			FROM finyear u2
			JOIN fin f2
				ON u2.idfin = f2.idfin	
			WHERE u2.idupb= #previousexpense.idupb
				AND SUBSTRING(u2.idfin, 1,@len_finlevel) = #previousexpense.idfin
				AND f2.nlevel = @levelusable),
		finvar =
			(SELECT SUM(finvardetail.amount)
			FROM finvardetail
			JOIN finvar
				ON finvar.yvar = finvardetail.yvar
				AND finvar.nvar = finvardetail.nvar
			WHERE finvardetail.idupb = #previousexpense.idupb 
				AND finvar.flagprevision ='S'
				AND finvar.adate < @start
				AND finvar.yvar = @ayear
				AND SUBSTRING(finvardetail.idfin, 1, @len_finlevel) = #previousexpense.idfin)
	END
	ELSE
	BEGIN
		UPDATE #previousexpense		--da vedere se bisogna filtrare già qui x classificazione
		SET initialprevision =
				(SELECT SUM(expenseyear.amount)
				FROM expenseyear
				JOIN expense
					ON expense.idexp = expenseyear.idexp
				WHERE expenseyear.flagarrear = @kind
					AND expense.adate < @start
					AND expense.nphase = @finphase
					AND expenseyear.idupb = #previousexpense.idupb
					AND SUBSTRING(expenseyear.idfin, 1,@len_finlevel) = #previousexpense.idfin
					AND expenseyear.ayear = @ayear)
	END
	IF (@kind IN ('C','R'))
	BEGIN
		UPDATE #previousexpense			--- anche qui bisogna vedere se filtrare per classificazione
		SET finphase_amount =
			ISNULL((
			SELECT SUM(expenseyear.amount)
			FROM expenseyear
			JOIN expense
				ON expense.idexp = expenseyear.idexp
				AND expense.adate < @start
				AND expense.nphase = @finphase
			WHERE expenseyear.flagarrear = @kind
				AND expenseyear.idupb = #previousexpense.idupb
				AND SUBSTRING(expenseyear.idfin,1,@len_finlevel) = #previousexpense.idfin
				AND expenseyear.ayear = @ayear), 0)
			+ 
			ISNULL((
			SELECT SUM(expensevar.amount)
			FROM expensevar
			JOIN expenseyear
				ON expenseyear.idexp = expensevar.idexp
			WHERE expensevar.yvar = @ayear
				AND expenseyear.ayear = @ayear
				AND expenseyear.idupb = #previousexpense.idupb
				AND SUBSTRING(expenseyear.idfin, 1, @len_finlevel) = #previousexpense.idfin
				AND expenseyear.flagarrear = @kind
				AND expenseyear.nphase = @finphase
				AND expensevar.adate < @start), 0)
	END
	
	IF (@cashvaliditykind <> 'B')
	BEGIN
		UPDATE #previousexpense			--stesso discorso di previsione.
		SET cassaphase_amount =
			ISNULL((SELECT SUM(EY.amount)
			FROM expenseyear EY
			JOIN  historypaymentview HPV
				ON HPV.idexp = EY.idexp
				AND HPV.competencydate < @start
			WHERE (EY.flagarrear = @kind OR @kind = 'S')
				AND EY.idupb = #previousexpense.idupb
				AND EY.nphase = @maxexpensephase
				AND SUBSTRING(EY.idfin, 1, @len_finlevel) = #previousexpense.idfin
				AND EY.ayear = @ayear), 0)
			+ 
			ISNULL((SELECT SUM(expensevar.amount)
			FROM expensevar
			JOIN expenseyear
				ON expenseyear.idexp = expensevar.idexp
				AND expenseyear.ayear = @ayear
				AND expenseyear.idupb = #previousexpense.idupb
				AND SUBSTRING(expenseyear.idfin, 1,@len_finlevel) = #previousexpense.idfin
				AND (expenseyear.flagarrear = @kind OR @kind = 'S')
				AND expenseyear.nphase = @maxexpensephase
			WHERE expensevar.yvar = @ayear
				AND expensevar.adate < @start
				AND EXISTS (SELECT * FROM historypaymentview HPV
						WHERE HPV.idexp = expensevar.idexp
						AND HPV.competencydate <= @start
						AND HPV.ymov = @ayear)
			), 0)
	END
	ELSE
	BEGIN
		UPDATE #previousexpense			---- ed anche qui
		SET cassaphase_amount =
			ISNULL((SELECT SUM(EY.amount)
			FROM expenseyear EY
			JOIN  historypaymentview HPV
				ON HPV.idexp = EY.idexp
				AND HPV.competencydate < @start
			WHERE (EY.flagarrear = @kind OR @kind = 'S')
				AND EY.idupb = #previousexpense.idupb
				AND EY.nphase = @maxexpensephase
				AND SUBSTRING(EY.idfin, 1, @len_finlevel) = #previousexpense.idfin
				AND EY.ayear = @ayear), 0)
	END	

	INSERT INTO #expense			--- alla fine dalla tabella delle previsioni inserisce tutto in expense d'appoggio
	(
		idfin,
		idupb,
		codeupb,upb,upbprintingorder,
		rowkind,
		operationdate,
		operationkind,
		initialprevision,
		finvar,
		finphase_amount,
		cassaphase_amount
	)
	SELECT
		#previousexpense.idfin,
		upb.idupb,
		upb.codeupb,
		upb.title,
		upb.printingorder,
		1,
		DATEADD(dd, -1, @start),
		'Tot.prec.',
		#previousexpense.initialprevision,
		#previousexpense.finvar,
		#previousexpense.finphase_amount,
		#previousexpense.cassaphase_amount
	FROM #previousexpense
	JOIN fin
		ON fin.idfin = #previousexpense.idfin
	JOIN upb 
		ON upb.idupb=#previousexpense.idupb	
END	
--	Variazioni di previsione
IF (@kind IN ('C','S')) 
	BEGIN
	INSERT INTO #expense
		(
		idfin,
		idupb,codeupb,upb,upbprintingorder,
		rowkind,
		operationdate,
		operationkind,
		ymov,
		nmov,
		nofficial,
		description,
		finvar
		)
	SELECT 
		fin.idfin,
		upb.idupb,
		upb.codeupb,
		upb.title,
		upb.printingorder,
		2,
		finvar.adate,
		'Var.prev.',
		finvar.yvar,
		finvar.nvar,
		CASE finvar.official
			WHEN 'S' THEN finvar.nofficial
			ELSE NULL
		END,
		finvar.description,
		finvardetail.amount
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN fin
		ON fin.idfin = SUBSTRING(finvardetail.idfin, 1, @len_finlevel)
	JOIN upb 
		ON upb.idupb=finvardetail.idupb AND  (upb.idupb like @idupb )
	WHERE finvar.flagprevision = 'S'	
		AND finvar.adate BETWEEN @start AND @stop
		AND fin.ayear = @ayear
		AND fin.finpart = 'S'
		AND fin.nlevel = @nlevel
		AND (@codefin IS NULL OR SUBSTRING(fin.codefin, 1, @len_codefin) = @codefin)
END
DECLARE @finname varchar(50)
SELECT @finname = description
FROM expensephase
WHERE nphase = @finphase
-- Movimenti di Spesa / fase bilancio

-- qui dobbiamo indubbiamente iniziare aragionare per codice classificazione, anche perchè bisognerà inserire soltanto una delle fasi.

IF (@kind IN ('C','R')) 
BEGIN
	INSERT INTO #expense(
		idfin,
		idmov,
		idupb,codeupb,upb,upbprintingorder,
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		description,
		idreg,
		finphase_amount
		)
		SELECT 
		fin.idfin,
		expense.idexp,
		upb.idupb,
		upb.codeupb,
		upb.title,upb.printingorder,
		3,
		expense.nphase,
		expense.adate,
		@finname,
		expense.ymov,
		expense.nmov,
		expense.description,
		expense.idreg,
		expenseyear.amount
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
			AND expenseyear.ayear = @ayear
			AND expenseyear.flagarrear = @kind
		JOIN upb 
			ON upb.idupb=expenseyear.idupb
		JOIN fin
			ON fin.idfin = SUBSTRING(expenseyear.idfin, 1, @len_finlevel)
			AND fin.ayear = @ayear
			AND fin.finpart = 'S'
			AND fin.nlevel = @nlevel
			AND (@codefin IS NULL
			OR SUBSTRING(fin.codefin, 1,@len_codefin) = @codefin)
		JOIN expensesorted					-- inserita questa join su expensesorted
			ON expense.idexp=expensesorted.idexp

		WHERE expense.nphase = @finphase
			AND ((@kind = 'C' AND expense.adate BETWEEN @start AND @stop)
			OR (@kind = 'R' AND DATEPART(yy, @start) = @ayear AND DATEPART(mm, @start) = 1	AND DATEPART(dd, @start) = 1))
			AND (upb.idupb like @idupb )
			AND expensesorted.idsorkind=@idsorkind			---inserite queste due linee che filtrano per idsor
			AND expensesorted.idsor like isnull(@idsor,'%')
			
-- Variazione movimenti di spesa / fase bilancio
	INSERT INTO #expense
		(
		idfin,
		idmov,
		idupb,codeupb,upb,upbprintingorder,	
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		nsubmov,
		description,
		idreg,
		finphase_amount
		)
	SELECT 
		fin.idfin,
		expense.idexp,
		upb.idupb,upb.codeupb,upb.title,upb.printingorder,
		4,
		expense.nphase,
		expensevar.adate,
		CASE
			WHEN @kind = 'C' 
			THEN 'Var.' + @finname
			WHEN @kind = 'R' 
			THEN 'Var.residuo '+@finname 
		END,
		expense.ymov,
		expense.nmov,
		expensevar.nvar,
		expensevar.description,
		expense.idreg,
		expensevar.amount
	FROM expensevar
	JOIN expense
		ON expense.idexp = expensevar.idexp
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
	JOIN upb 
		ON upb.idupb = expenseyear.idupb					
	JOIN fin
		ON fin.idfin = SUBSTRING(expenseyear.idfin, 1, 	@len_finlevel)
	JOIN expensesorted					-- inserita questa join su expensesorted
			ON expense.idexp=expensesorted.idexp
	WHERE expensevar.yvar = @ayear
		AND expensevar.adate BETWEEN @start AND @stop
		AND (upb.idupb like @idupb )
		AND expense.nphase = @finphase
		AND expenseyear.ayear = @ayear
		AND expenseyear.flagarrear = @kind
		AND fin.ayear = @ayear
		AND fin.finpart = 'S'
		AND fin.nlevel = @nlevel
		AND (@codefin IS NULL OR SUBSTRING(fin.codefin, 1,@len_codefin) = @codefin)
		AND expensesorted.idsorkind=@idsorkind			---inserite queste due linee che filtrano per idsor
		AND expensesorted.idsor like isnull(@idsor,'%')
END
---	CILCLO WHILE
--------------------------
DECLARE @i int
SELECT @i = CONVERT(int,@finphase)
WHILE @i < (@maxexpensephase -1)
BEGIN
	SELECT @i = @i + 1
	IF (@kind = 'C' OR @kind = 'R') 
	BEGIN
		INSERT INTO #expense
			(
			idfin,
			idmov,
			codeupb,
			idupb,
			upb,
			upbprintingorder,
			rowkind,
			nphase,
			operationdate,
			operationkind,
			ymov,
			nmov,
			description,
			idreg,
			finphase_amount
			)
		SELECT 
			fin.idfin,
			expense.idexp,
			upb.codeupb	,
			upb.idupb ,
			upb.title ,
			upb.printingorder,
			5+(@i-@finphase-1)*2,
			expense.nphase,
			CASE
				WHEN @kind = 'C' 
				THEN expense.adate
				WHEN @kind = 'R' 
				THEN  expense.adate
			END,
			CASE
				WHEN @kind = 'C' 
				THEN (SELECT  description
					FROM expensephase
					WHERE nphase = @i)
				WHEN @kind = 'R' 
				THEN (SELECT  description
					FROM expensephase
					WHERE nphase = @i)
			END,
			expense.ymov,
			expense.nmov,
			expense.description,
			expense.idreg,
			expenseyear.amount
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
			AND expenseyear.ayear = @ayear
			AND expenseyear.flagarrear = @kind
		JOIN upb
			ON upb.idupb = expenseyear.idupb  
		JOIN fin
			ON fin.idfin = SUBSTRING(expenseyear.idfin, 1,@len_finlevel)
			AND fin.ayear = @ayear
			AND fin.finpart = 'S'
			AND fin.nlevel = @nlevel
			AND (@codefin IS NULL
			OR SUBSTRING(fin.codefin, 1,@len_codefin) = @codefin)
		JOIN expensesorted					-- inserita questa join su expensesorted
			ON expense.idexp=expensesorted.idexp
		WHERE  (upb.idupb like @idupb )
			AND expense.nphase = @i
			AND ((@kind = 'C' AND expense.adate BETWEEN @start AND @stop)
			OR (@kind = 'R'	AND DATEDIFF(DAY,@start,@firstday) = 0))
			AND expensesorted.idsorkind=@idsorkind			---inserite queste due linee che filtrano per idsor
			AND expensesorted.idsor like isnull(@idsor,'%')		---dovrebbe quindi prendere in considerazione i movimenti con quella classificazione scelta
		INSERT INTO #expense
			(
			idfin,
			idmov,
			codeupb	,
			idupb 			,
			upb   			,
			upbprintingorder	,
			rowkind,
			nphase,
			operationdate,
			operationkind,
			ymov,
			nmov,
			nsubmov,
			description,
			idreg,
			finphase_amount
			)
		SELECT 
			fin.idfin,
			expense.idexp,
			upb.codeupb	,
			upb.idupb 							,
			upb.title   							,
			upb.printingorder,
			6+(@i-@finphase-1)*2,
			expense.nphase,
			expensevar.adate,
			CASE
				WHEN @kind = 'C' 
				THEN 'Var.' + (SELECT  description
					FROM expensephase
					WHERE nphase = @i)
				WHEN @kind = 'R' 
				THEN 'Var. '+ (SELECT  description
					FROM expensephase
					WHERE nphase = @i)
			END,
			expense.ymov,
			expense.nmov,
			expensevar.nvar,
			expensevar.description,
			expense.idreg,
			expensevar.amount
		FROM expensevar
		JOIN expense
			ON expense.idexp = expensevar.idexp
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
		JOIN upb
			ON upb.idupb = expenseyear.idupb  
		JOIN fin
			ON fin.idfin = SUBSTRING(expenseyear.idfin, 1,@len_finlevel)
		JOIN expensesorted					-- inserita questa join su expensesorted
			ON expense.idexp=expensesorted.idexp
		WHERE (upb.idupb like @idupb )
			AND expense.nphase = @i
			AND fin.ayear = @ayear
			AND fin.finpart = 'S'
			AND fin.nlevel = @nlevel
			AND (@codefin IS NULL OR SUBSTRING(fin.codefin, 1,@len_codefin) = @codefin)
			AND expensevar.yvar = @ayear
			AND expenseyear.ayear = @ayear
			AND expenseyear.flagarrear = @kind
			AND expensevar.adate BETWEEN @start AND @stop
			AND expensesorted.idsorkind=@idsorkind			---inserite queste due linee che filtrano per idsor
			AND expensesorted.idsor like isnull(@idsor,'%')
	END		  
	CONTINUE
END
---	FINE CILCLO WHILE
--------------------------

DECLARE @phasecassa varchar(50)
SELECT @phasecassa = description
FROM expensephase
WHERE nphase = @maxexpensephase
-- Movimenti di spesa / fase cassa
INSERT INTO #expense
		(
		idfin,
		idmov,
		idupb,
		codeupb,
		upb,
		upbprintingorder,
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		ndoc,
		description,
		doc,
		idreg,
		cassaphase_amount
		)
SELECT 
	fin.idfin,
	HPV.idexp,
	upb.idupb,upb.codeupb,upb.title,
	upb.printingorder,
	15,
	expenseyear.nphase,
	HPV.competencydate,
	@phasecassa,
	HPV.ymov,
	HPV.nmov,
	HPV.npay,
	HPV.description,
	CASE
		WHEN HPV.doc IS NOT NULL AND 
			HPV.docdate IS NULL THEN
			'Pag. ' + HPV.doc
		WHEN HPV.doc IS NOT NULL AND
			HPV.docdate IS NOT NULL THEN
			'Pag. ' + HPV.doc + 
			' del ' + CONVERT(varchar(20), HPV.docdate, 105)
		ELSE
			(NULL)
	END,
	HPV.idreg,
	expenseyear.amount
FROM historypaymentview HPV
JOIN expenseyear
	ON expenseyear.idexp = HPV.idexp
JOIN upb 
	ON upb.idupb = expenseyear.idupb		
JOIN fin
	ON fin.idfin = SUBSTRING(expenseyear.idfin, 1, @len_finlevel)
JOIN expensesorted					-- inserita questa join su expensesorted
	ON expenseyear.idexp=expensesorted.idexp
WHERE HPV.competencydate BETWEEN @start AND @stop
	AND (upb.idupb like @idupb )
	AND expenseyear.ayear = @ayear
	AND expenseyear.nphase = @maxexpensephase
	AND ((@kind IN ('C', 'R') AND expenseyear.flagarrear = @kind) OR @kind = 'S')
	AND fin.ayear = @ayear
	AND fin.finpart = 'S'
	AND fin.nlevel = @nlevel
	AND (@codefin IS NULL OR SUBSTRING(fin.codefin, 1,@len_codefin) = @codefin)
	AND expensesorted.idsorkind=@idsorkind			---inserite queste due linee che filtrano per idsor
	AND expensesorted.idsor like isnull(@idsor,'%')
-- Variazione ai Movimenti di spesa / fase cassa
IF (@cashvaliditykind <> 'B')
BEGIN
	INSERT INTO #expense
		(
		idfin,
		idmov,
		idupb, codeupb,upb,upbprintingorder,
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		nsubmov,
		ndoc,
		description,
		doc,
		idreg,
		cassaphase_amount
		)
	SELECT 
		fin.idfin,
		expense.idexp,
		upb.idupb, upb.codeupb,upb.title,upb.printingorder,
		20,
		expense.nphase,
		expensevar.adate,
		'Var.' + @phasecassa,
		expense.ymov,
		expense.nmov,
		expensevar.nvar,
		expense.npay,
		expensevar.description,
		CASE
			WHEN expensevar.doc IS NOT NULL AND 
				expensevar.docdate IS NULL THEN
				'Pag. ' + expensevar.doc
			WHEN expensevar.doc IS NOT NULL AND
				expensevar.docdate IS NOT NULL THEN
				'Pag. ' + expensevar.doc + 
				' del ' + CONVERT(varchar(20), expensevar.docdate, 105)
			ELSE
		(NULL)
		END,
		expense.idreg,
		expensevar.amount
	FROM expensevar
	JOIN expense
	ON expense.idexp = expensevar.idexp
		AND expense.nphase = @maxexpensephase
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
	JOIN upb
		ON upb.idupb = expenseyear.idupb
	JOIN fin
		ON fin.idfin = SUBSTRING(expenseyear.idfin, 1, @len_finlevel)
	JOIN expensesorted					-- inserita questa join su expensesorted
		ON expense.idexp=expensesorted.idexp
	WHERE expensevar.yvar = @ayear
		AND expensevar.adate BETWEEN @start AND @stop
		AND DATALENGTH(expensevar.idexp) = CONVERT(int, @maxexpensephase) * 8
		AND (upb.idupb like @idupb )
		AND expenseyear.ayear = @ayear
		AND expenseyear.nphase = @maxexpensephase
		AND fin.ayear = @ayear
		AND fin.finpart = 'S'
		AND fin.nlevel = @nlevel
		AND (@codefin IS NULL OR SUBSTRING(fin.codefin, 1, @len_codefin) = @codefin)
		AND ((@kind IN ('C', 'R') AND expenseyear.flagarrear = @kind) OR @kind = 'S')
		AND EXISTS (SELECT * FROM historypaymentview HPV
				WHERE HPV.idexp = expensevar.idexp
				AND HPV.competencydate BETWEEN @start AND @stop
				AND HPV.ymov = @ayear)
		AND expensesorted.idsorkind=@idsorkind			---inserite queste due linee che filtrano per idsor
		AND expensesorted.idsor like isnull(@idsor,'%')
END
UPDATE #expense
	SET 	emessiondate = paymentview.adate,
		printeddate = 	paymentview.printdate,
		trasmitteddate = paymentview.transmissiondate,	
		transactiondate = paymentperformed.competencydate,
		annulmentdate = paymentview.annulmentdate
	FROM paymentview
	LEFT OUTER JOIN banktransaction
		ON banktransaction.npay=paymentview.npay	
		AND banktransaction.ypay=paymentview.ypay	
		AND (banktransaction.kind='D' OR banktransaction.kind IS NULL)
	LEFT OUTER JOIN  paymentperformed 
		ON paymentperformed.npay=paymentview.npay
		AND paymentperformed.ypay=paymentview.ypay
	WHERE #expense.ndoc = paymentview.npay and paymentview.ypay=@ayear

IF (@suppressifblank = 'N')			---- Qui ancora non ho toccato nulla
BEGIN
	INSERT INTO #expense 
		(
			idfin,
			idupb,
			codeupb,
			upb,
			upbprintingorder,
			rowkind
			)
	SELECT 
		SUBSTRING(fin.idfin, 1,@len_finlevel),
		upb.idupb,
		codeupb,
		upb.title,
		upb.printingorder,
		1
	FROM fin CROSS JOIN upb 
	WHERE (upb.idupb like @idupb )
		AND fin.ayear = @ayear
		AND fin.finpart = 'S'
		AND fin.nlevel = @nlevel
		AND (@codefin IS NULL OR SUBSTRING(fin.codefin, 1,@len_codefin) = @codefin)
		and not exists (SELECT *
			FROM #expense
			WHERE upb.idupb = #expense.idupb 
			AND SUBSTRING(fin.idfin, 1,@len_finlevel) = #expense.idfin )

END

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
	UPDATE #expense 
	SET  
		upbprintingorder = (SELECT TOP 1 upbprintingorder
			FROM #expense
			WHERE idupb = @idupboriginal),
		upb = (SELECT TOP 1 upb
			FROM #expense
			WHERE idupb = @idupboriginal),
		idupb = @idupboriginal,
		codeupb =(SELECT TOP 1 codeupb
			FROM #expense	
			WHERE idupb = @idupboriginal)
IF (@showupb <>'S') and (@idupboriginal = '%')
	UPDATE #expense SET  
		upbprintingorder = null	,
		upb =  null,
		idupb = null,
		codeupb = null
-- se ho scelto di nascondere le voci di bilancio non utilizzate:
-- cancello le righe che hanno valori pari a zero 
-- per cui non esistono variazioni di previzioni (rowkind=2) o movimenti di entrata (rowkind >= 3 )  
IF (@suppressifblank = 'S') AND @nlevel>2	--> se la stampa è x un livello sottostante la categoria cancella le righe
BEGIN
	DELETE FROM #expense WHERE 
		ISNULL(initialprevision,0)=0 AND 
		ISNULL(finvar,0)=0 AND 
		ISNULL(finphase_amount,0)=0 AND 
		ISNULL(cassaphase_amount,0)=0 AND
		NOT EXISTS (select * from  #expense i
				where #expense.idupb=i.idupb AND 
				      #expense.idfin=i.idfin AND 
					i.rowkind>1)
END

--- questa è uina parte che dovrebbe essere cancellata inquanto a me interessa soltanto la mia fase legata alla classificazione


-- Seleziona la terza fase da inserire nella stampa 
DECLARE @thirdphase varchar(50)
SELECT  @thirdphase = description
	FROM expensephase 
	WHERE nphase NOT IN (@finphase,@maxexpensephase,(select expenseregphase from uniconfig)) 

DECLARE @phaseregistry varchar(50)
SELECT  @phaseregistry = description
	FROM expensephase
	join uniconfig on uniconfig.expenseregphase=expensephase.nphase

----select finale filtrata nei due distinti casi

IF (@showupb <>'S') 
BEGIN
	SELECT 
		#expense.idfin,
		idmov,
		@level as levelname,
		F.codefin,
		F.printingorder as finprintingorder,
		F.title,
		codeupb,idupb,upb,upbprintingorder,rowkind,
		nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,
		ndoc,description,doc,annotations,REG.title as registry,	
		sum(initialprevision) as initialprevision,
		sum(finvar) as finvar	,
		sum(finphase_amount) as finphase_amount,
		sum(cassaphase_amount) as cassaphase_amount	,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@finname as finname,	
		@phaseregistry as phaseregistry,
		@thirdphase as thirdphase  ,					
		@phasecassa as phasecassa
	FROM #expense
	JOIN fin F
		ON F.idfin = #expense.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #expense.idreg
	GROUP BY codeupb,idupb,upb,upbprintingorder,
		F.printingorder,#expense.idfin,idmov,F.codefin,F.title,
		rowkind,nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,ndoc,description,doc,
		annotations,REG.title,finvar,emessiondate,printeddate			,
		trasmitteddate,transactiondate,annulmentdate
	ORDER BY upbprintingorder ASC, finprintingorder ASC,
		operationdate ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nofficial ASC,
		nsubmov ASC
END
ELSE
BEGIN
	SELECT #expense.idfin,
		idmov,
		@level as levelname,
		F.codefin,
		F.printingorder as finprintingorder,
		F.title,
		codeupb,idupb,upb,upbprintingorder,rowkind,
		nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,
		ndoc,description,doc,annotations,REG.title as registry,	
		initialprevision,finvar,finphase_amount,cassaphase_amount,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@finname as finname,	
		@phaseregistry as phaseregistry,
		@thirdphase as thirdphase  ,					
		@phasecassa as phasecassa 
	FROM #expense	
	JOIN fin F
		ON F.idfin = #expense.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #expense.idreg	
	ORDER BY upbprintingorder ASC, F.printingorder ASC,
		operationdate ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nofficial ASC,
		nsubmov ASC
END
END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

