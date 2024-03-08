
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_spesa_tutte_fasi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_spesa_tutte_fasi]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser'amministrazione'
CREATE PROCEDURE rpt_partitario_spesa_tutte_fasi
	@ayear int,
	@kind char(1),
	@idupb	varchar(36),
	@nlevel tinyint,
	@start datetime,
	@stop datetime,
	@showupb char(1),
	@showchildupb char(1),
	@suppressifblank char(1),
	@flagnofficial	char(1),
	@idfin int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
AS
BEGIN
--exec rpt_partitario_spesa_tutte_fasi 2011, 'R', '%', 3, {ts '2011-01-01 00:00:00'}, {ts '2011-12-31 00:00:00'}, 'N', 'N', 'S', 'N', NULL, NULL, NULL, NULL, NULL, NULL

CREATE TABLE #previousexpense
(
	idfin int,
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
	SET @idupb = @idupb+'%' 
END	

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'

DECLARE @kind_bit  tinyint 
IF @kind='C' set @kind_bit = 0
IF @kind='R' set @kind_bit = 1

DECLARE @levelusable tinyint
SELECT 	@levelusable = MIN(nlevel)
FROM 	finlevel
WHERE 	flag&2 <> 0 AND ayear = @ayear

DECLARE @finphase tinyint
DECLARE @finname varchar(50)
SELECT  @finphase = appropriationphasecode FROM config WHERE 	ayear = @ayear
SELECT  @finname = description FROM expensephase WHERE nphase = @finphase

DECLARE @maxexpensephase tinyint 
DECLARE @phasecassa varchar(50)
SELECT  @maxexpensephase = MAX(nphase) FROM 	expensephase
SELECT  @phasecassa = description FROM expensephase WHERE nphase = @maxexpensephase


DECLARE @regphase tinyint 
SELECT  @regphase = expenseregphase FROM uniconfig

-- Seleziona la seconda/terza fase da inserire nella stampa 
DECLARE @secondphase varchar(50)
DECLARE @thirdphase varchar(50)
DECLARE @fourthphase varchar(50)

DECLARE @second tinyint
DECLARE @third tinyint
-- la seconda fase è quella successiva alla prima MA non deve essere quella del pagamento
SELECT  @secondphase = description, @second = nphase FROM expensephase WHERE nphase = @finphase+1 and nphase < @maxexpensephase
-- la terza fase è quella successiva alla seconda MA non deve essere quella del pagamento
SELECT  @thirdphase = description, @third = nphase FROM expensephase  WHERE nphase =  @second + 1 and nphase < @maxexpensephase

-- la quarta fase è quella successiva alla terza MA non deve essere quella del pagamento
SELECT  @fourthphase = description FROM expensephase  WHERE nphase = @third + 1 and nphase < @maxexpensephase

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@nlevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3

IF (@nlevel < @level_input ) AND (@idfin is not null)
BEGIN
	SET  @nlevel = @level_input
END

IF (@levelusable < @nlevel)
BEGIN	
	SET @levelusable = @nlevel
END
 
DECLARE @level varchar(50)
SELECT  @level = description 
	FROM    finlevel
	WHERE   nlevel = @nlevel AND ayear = @ayear

CREATE TABLE #expense
(
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
	idfin int,
	rowkind	int,
	idmov int,
	nphase tinyint,
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
	annotations varchar(400),

	available decimal(19,2),
	hierarchy varchar (200),
	tothierarchy varchar (200)
	)

DECLARE @firstday datetime
SET 	@firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)

DECLARE @cashvaliditykind       	int
SELECT  @cashvaliditykind = cashvaliditykind
FROM    config
WHERE   ayear = @ayear

DECLARE @previsionkind char(1) 
SELECT  @previsionkind =  
	 CASE 
		WHEN fin_kind IN (1,3) THEN 'C'
		WHEN fin_kind = 2 THEN 'S'
	 END
FROM  config 
WHERE config.ayear = @ayear

DECLARE @secprevisionkind    char(1) 
SELECT  @secprevisionkind  = 
	 CASE 
		WHEN fin_kind = 3 THEN 'S'
		ELSE NULL
	END
FROM config 
WHERE config.ayear = @ayear


IF ((@kind ='C') AND (DATEDIFF(DAY,@start, @firstday) = 0))
	BEGIN
		INSERT INTO #expense
		(
			idfin,
			idupb,
			rowkind,
			operationdate,
			operationkind,
			initialprevision
		)
		SELECT 
			isnull(finlink.idparent, fin.idfin),
			isnull(@fixedidupb,finyear.idupb),
			1,
			@firstday,
			'Prev.iniziale',
			SUM(finyear.prevision)		
		FROM finyear  
		JOIN fin
			ON finyear.idfin = fin.idfin
		JOIN upb
			ON finyear.idupb = upb.idupb	
		left outer JOIN finlink
			ON finlink.idchild = finyear.idfin
			AND finlink.nlevel = @level_input--@nlevel
		WHERE finyear.idupb like @idupb 
			and fin.ayear = @ayear
			AND ((fin.flag&1)<>0) 
			AND fin.nlevel =  @nlevel--@levelusable
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		GROUP BY isnull(@fixedidupb,finyear.idupb), isnull(finlink.idparent, fin.idfin)
			

	END

IF (DATEDIFF(DAY,@start, @firstday) <> 0)
BEGIN
	IF (@kind = 'C') 
			BEGIN
			INSERT INTO #expense	
				(
				idfin,
				idupb,
				rowkind,
				operationdate,
				operationkind,
				initialprevision
				)
			SELECT isnull(finlink.idparent, finyear.idfin),
				   isnull(@fixedidupb, finyear.idupb),
					1,
					DATEADD(dd, -1, @start),
					'Tot.prec.',
				   SUM(finyear.prevision)
			FROM finyear
			JOIN fin
				ON finyear.idfin = fin.idfin
			JOIN upb
				On finyear.idupb = upb.idupb	
			left outer JOIN finlink
				ON finlink.idchild = finyear.idfin
				AND finlink.nlevel = @level_input
			WHERE finyear.idupb like @idupb 
				AND fin.ayear = @ayear
				AND ((fin.flag&1)<>0) 
				AND fin.nlevel = @nlevel
				AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
			GROUP by isnull(@fixedidupb, finyear.idupb),isnull(finlink.idparent, finyear.idfin)

			INSERT INTO #expense
			(
				idfin,
				idupb,
				rowkind,
				operationdate,
				operationkind,
				finvar
			)
			SELECT 
				isnull(finlink.idparent, finvardetail.idfin),
				isnull(@fixedidupb,finvardetail.idupb),
				1,
				DATEADD(dd, -1, @start),
				'Tot.prec.',
				SUM(finvardetail.amount)
			FROM finvardetail
			JOIN finvar
				ON finvar.yvar = finvardetail.yvar
				AND finvar.nvar = finvardetail.nvar
			JOIN fin
				ON finvardetail.idfin = fin.idfin
			JOIN upb
				ON finvardetail.idupb = upb.idupb
			LEFT OUTER JOIN finlink
				ON finlink.idchild = finvardetail.idfin  
				AND finlink.nlevel = @nlevel	
			WHERE finvardetail.idupb like @idupb 
				AND finvar.flagprevision ='S'
				AND finvar.idfinvarstatus = 5
				AND finvar.variationkind <> 5	
				AND finvar.adate < @start
				AND ((fin.flag&1)<>0) 
				AND finvar.yvar = @ayear
				AND (@idfin IS NULL OR isnull(finlink.idparent, finvardetail.idfin) = @idfin)	
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
			GROUP by isnull(@fixedidupb,finvardetail.idupb),isnull(finlink.idparent, finvardetail.idfin)

	END -- @kind='C'

	IF (@kind = 'R') 
			BEGIN
			INSERT INTO #expense
				(
				idfin,
				idupb,
				rowkind,
				operationdate,
				operationkind,
				initialprevision
				)
			SELECT isnull(finlink.idparent, expenseyear.idfin),
				   isnull(@fixedidupb,expenseyear.idupb),
					1,
					DATEADD(dd, -1, @start),
					'Tot.prec.',
					SUM(expenseyear.amount)
			FROM expenseyear
			JOIN expense
				ON expense.idexp = expenseyear.idexp
			JOIN expensetotal
				ON  expenseyear.idexp = expensetotal.idexp
				AND expenseyear.ayear = expensetotal.ayear	
			JOIN upb
				ON expenseyear.idupb = upb.idupb	
			left outer JOIN finlink
				ON finlink.idchild = expenseyear.idfin
				AND finlink.nlevel = @nlevel
			WHERE  ((expensetotal.flag&1) = @kind_bit)
				AND expense.adate < @start
				AND expense.nphase = @finphase
				AND expenseyear.idupb like @idupb 
				AND (@idfin IS NULL OR isnull(finlink.idparent, expenseyear.idfin) = @idfin)	
				AND expenseyear.ayear = @ayear
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
			GROUP by isnull(@fixedidupb,expenseyear.idupb),isnull(finlink.idparent, expenseyear.idfin)
			END

	INSERT INTO #expense
		(
		idfin,
		idupb,
		rowkind,
		operationdate,
		operationkind,
		finphase_amount
		)
	SELECT 
		isnull(finlink.idparent, expenseyear.idfin),
		isnull(@fixedidupb,expenseyear.idupb),
		1,
		DATEADD(dd, -1, @start),
		'Tot.prec.',
		SUM(expenseyear.amount)
	FROM expenseyear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	JOIN expensetotal
		ON  expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear	
	JOIN upb
		ON expenseyear.idupb = upb.idupb	
	left outer JOIN finlink
		ON finlink.idchild = expenseyear.idfin
		AND finlink.nlevel = @nlevel
	WHERE ((expensetotal.flag&1) = @kind_bit)
		AND expense.adate < @start
		AND expense.nphase = @finphase
		AND expenseyear.ayear = @ayear
		AND expenseyear.idupb like @idupb 
		AND (@idfin IS NULL OR isnull(finlink.idparent, expenseyear.idfin) = @idfin)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP by isnull(@fixedidupb,expenseyear.idupb),isnull(finlink.idparent, expenseyear.idfin)

-- Esegue un'altra insert per 'finphase_amount' ma questa volta ci mette le var, perchè #expense prevede solo il campo 'finphase_amount'
-- Nella select finale i valori saranno sommati

	INSERT INTO #expense
		(
		idfin,
		idupb,
		rowkind,
		operationdate,
		operationkind,
		finphase_amount
		)
	SELECT 
		isnull(finlink.idparent, expenseyear.idfin),
		isnull(@fixedidupb,expenseyear.idupb),
		1,
		DATEADD(dd, -1, @start),
		'Tot.prec.',
		SUM(expensevar.amount)
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	JOIN expensetotal
		ON  expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear	
	JOIN upb
		ON expenseyear.idupb = upb.idupb	
	left outer JOIN finlink
		ON finlink.idchild = expenseyear.idfin
		AND finlink.nlevel = @nlevel
	WHERE expensevar.yvar = @ayear
		AND expenseyear.ayear = @ayear
		AND expenseyear.idupb like @idupb 
		AND (@idfin IS NULL OR isnull(finlink.idparent, expenseyear.idfin) = @idfin)	
		AND ((expensetotal.flag&1) = @kind_bit)
		AND expense.nphase = @finphase
		AND expensevar.adate < @start
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP by isnull(@fixedidupb,expenseyear.idupb),isnull(finlink.idparent, expenseyear.idfin)

	
	INSERT INTO #expense
		(
		idfin,
		idupb,
		rowkind,
		operationdate,
		operationkind,
		cassaphase_amount
		)
	SELECT 
		isnull(finlink.idparent, HPV.idfin),
		isnull(@fixedidupb,HPV.idupb),
		1,
		DATEADD(dd, -1, @start),
		'Tot.prec.',
		SUM(HPV.amount)
	FROM historypaymentview HPV
	JOIN upb
		ON HPV.idupb = upb.idupb
	left outer JOIN finlink
		ON finlink.idchild = HPV.idfin	
		AND finlink.nlevel = @nlevel
	WHERE HPV.flagarrear = @kind 
		AND HPV.competencydate < @start
		AND HPV.ymov = @ayear
		AND HPV.idupb like @idupb 
		AND (@idfin IS NULL OR isnull(finlink.idparent, HPV.idfin) = @idfin)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP by isnull(@fixedidupb,HPV.idupb),isnull(finlink.idparent, HPV.idfin)

-- Esegue un'altra insert per 'cassaphase_amount' ma questa volta ci mette le var, perchè #expense prevede solo il campo 'cassaphase_amount'
-- Nella select finale i valori saranno sommati

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #expense
			(
			idfin,
			idupb,
			rowkind,
			operationdate,
			operationkind,
			cassaphase_amount
			)
		SELECT 
			isnull(finlink.idparent, HPV.idfin),
			isnull(@fixedidupb,HPV.idupb),
			1,
			DATEADD(dd, -1, @start),
			'Tot.prec.',
			SUM(expensevar.amount)
		FROM expensevar
		JOIN historypaymentview HPV
			ON HPV.idexp = expensevar.idexp
		JOIN upb
			ON HPV.idupb = upb.idupb	
		left outer JOIN finlink
			ON finlink.idchild = HPV.idfin	
			AND finlink.nlevel = @nlevel
		WHERE HPV.ymov = @ayear
			AND HPV.idupb like @idupb 
			AND (@idfin IS NULL OR isnull(finlink.idparent, HPV.idfin) = @idfin)	
			AND (HPV.flagarrear = @kind OR @kind = 'S')
			AND expensevar.yvar = @ayear
			AND expensevar.adate < @start
			AND HPV.competencydate <= @start
			AND HPV.ymov = @ayear
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		GROUP by isnull(@fixedidupb,HPV.idupb),isnull(finlink.idparent, HPV.idfin)
		
	END


END	-- IF (DATEDIFF(DAY,@start, @firstday) <> 0)

--	Variazioni di previsione
IF (@kind = 'C') 
	BEGIN
	INSERT INTO #expense
		(
		idfin,
		idupb,
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
		isnull(FL1.idparent, fin.idfin),
		finvardetail.idupb,
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
	JOIN finvar						ON finvar.yvar = finvardetail.yvar
										AND finvar.nvar = finvardetail.nvar
	JOIN upb						ON finvardetail.idupb = upb.idupb	
	left outer JOIN finlink			ON finlink.idchild = finvardetail.idfin	
										AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1		ON FL1.idchild = finvardetail.idfin	
										AND FL1.nlevel = @nlevel
	JOIN fin						ON fin.idfin = ISNULL(FL1.idparent,finvardetail.idfin)
	WHERE finvar.flagprevision = 'S'	
		AND finvar.idfinvarstatus = 5
		AND finvar.variationkind <> 5
		AND finvar.adate BETWEEN @start AND @stop
		AND finvardetail.idupb like @idupb 
		AND fin.ayear = @ayear
		AND ((fin.flag&1)<>0) 
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
END

-- Movimenti di Spesa / fase bilancio
	INSERT INTO #expense(
		idfin,
		idmov,
		idupb,
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		description,
		idreg,
		finphase_amount,	
		available
		)
		SELECT 
		isnull(FL1.idparent, fin.idfin),
		expense.idexp,
		expenseyear.idupb,
		3,
		expense.nphase,
		expense.adate,
		@finname,
		expense.ymov,
		expense.nmov,
		expense.description,
		expense.idreg,
		expenseyear.amount,
		expensetotal.available
		FROM expense
		JOIN expenseyear					ON expenseyear.idexp = expense.idexp
		JOIN expensetotal					ON expensetotal.idexp = expenseyear.idexp
												AND expensetotal.ayear = expenseyear.ayear
		JOIN upb							ON expenseyear.idupb = upb.idupb	
		left outer JOIN finlink FL1			ON FL1.idchild = expenseyear.idfin	
												AND FL1.nlevel = @nlevel
		JOIN fin							ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)
		left outer JOIN finlink				ON finlink.idchild = fin.idfin	
												AND finlink.nlevel = @level_input
		WHERE expense.nphase = @finphase
			AND ((@kind = 'C' AND expense.adate BETWEEN @start AND @stop)
			OR (@kind = 'R' AND DATEPART(yy, @start) = @ayear AND DATEPART(mm, @start) = 1	AND DATEPART(dd, @start) = 1))
			AND expenseyear.ayear = @ayear
			AND (expensetotal.flag&1)= @kind_bit
			AND fin.ayear = @ayear
			AND ((fin.flag&1)<>0) 
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	
			AND expenseyear.idupb like @idupb 
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


-- Variazione movimenti di spesa / fase bilancio
	INSERT INTO #expense
		(
		idfin,
		idmov,
		idupb,
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
		isnull(FL1.idparent, fin.idfin),
		expense.idexp,
		expenseyear.idupb,
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
	JOIN expense					ON expense.idexp = expensevar.idexp
	JOIN expenseyear				ON expenseyear.idexp = expensevar.idexp
	JOIN expensetotal				ON expensetotal.idexp = expenseyear.idexp
										AND expensetotal.ayear = expenseyear.ayear
	JOIN upb						ON expenseyear.idupb = upb.idupb	
	left outer JOIN finlink			ON finlink.idchild = expenseyear.idfin	
										AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1		ON FL1.idchild = expenseyear.idfin	
										AND FL1.nlevel = @nlevel
	JOIN fin						ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)
	WHERE expensevar.yvar = @ayear
		AND expensevar.adate BETWEEN @start AND @stop
		AND expenseyear.idupb like @idupb 
		AND expense.nphase = @finphase
		AND expenseyear.ayear = @ayear
		AND (expensetotal.flag&1)= @kind_bit
		AND fin.ayear = @ayear
		AND ((fin.flag&1)<>0)
		AND (@idfin IS NULL OR isnull(finlink.idparent, expenseyear.idfin) = @idfin)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
 
---	CILCLO WHILE
--------------------------
DECLARE @i int
SELECT @i = CONVERT(int,@finphase)
WHILE @i < (@maxexpensephase -1)
BEGIN
	SELECT @i = @i + 1
	IF (@kind = 'C') 
	BEGIN
		INSERT INTO #expense
			(
			idfin,
			idmov,
			idupb,
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
			isnull(FL1.idparent, fin.idfin),
			expense.idexp,
			expenseyear.idupb 							,
			5+(@i-@finphase-1)*2,
			expense.nphase,
			expense.adate,
			(SELECT  description
					FROM expensephase
					WHERE nphase = @i),
			expense.ymov,
			expense.nmov,
			expense.description,
			expense.idreg,
			expenseyear.amount
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN upb
			ON expenseyear.idupb = upb.idupb	
		left outer JOIN finlink
			ON finlink.idchild = expenseyear.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = expenseyear.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)
		WHERE  expenseyear.idupb like @idupb 
			AND expenseyear.ayear = @ayear
			AND (expensetotal.flag&1) = @kind_bit
			AND expense.nphase = @i
			AND fin.ayear = @ayear
			AND ((fin.flag&1)<>0)
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			AND (expense.adate BETWEEN @start AND @stop) --> @kind C
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	END		  
	IF (@kind = 'R') 
	BEGIN
		INSERT INTO #expense
			(
			idfin,
			idmov,
			idupb,
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
			isnull(FL1.idparent, fin.idfin),
			expense.idexp,
			expenseyear.idupb 							,
			5+(@i-@finphase-1)*2,
			expense.nphase,
			expense.adate,
			(SELECT  description
					FROM expensephase
					WHERE nphase = @i),
			expense.ymov,
			expense.nmov,
			expense.description,
			expense.idreg,
			expenseyear.amount
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN upb
			ON upb.idupb = expenseyear.idupb	
		left outer JOIN finlink
			ON finlink.idchild = expenseyear.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = expenseyear.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)
		WHERE  expenseyear.idupb like @idupb 
			AND expenseyear.ayear = @ayear
			AND (expensetotal.flag&1) = @kind_bit
			AND expense.nphase = @i
			AND fin.ayear = @ayear
			AND ((fin.flag&1)<>0)
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			AND ( DATEDIFF(DAY,@start,@firstday) = 0)	--> @kind R
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

	END

	INSERT INTO #expense
		(
		idfin,
		idmov,
		idupb,
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
		isnull(FL1.idparent, fin.idfin),
		expense.idexp,
		expenseyear.idupb 							,
		6+(@i-@finphase-1)*2,
		expense.nphase,
		expensevar.adate,
		'Var.' + (SELECT  description
				FROM expensephase
				WHERE nphase = @i),
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
	JOIN expensetotal
		ON expensetotal.idexp = expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	JOIN upb
		ON expenseyear.idupb = upb.idupb	
	left outer JOIN finlink
		ON finlink.idchild = expenseyear.idfin	
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = expenseyear.idfin	
		AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)
	WHERE   expenseyear.idupb like @idupb 
		AND expense.nphase = @i
		AND fin.ayear = @ayear
		AND ((fin.flag&1)<>0) -- Spese
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
		AND expensevar.yvar = @ayear
		AND expenseyear.ayear = @ayear
		AND isnull(expensevar.autokind,'') <>'22'
		AND (expensetotal.flag&1) = @kind_bit
		AND expensevar.adate BETWEEN @start AND @stop
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)  
	CONTINUE
END
---	FINE CILCLO WHILE
--------------------------

-- Movimenti di spesa / fase cassa
INSERT INTO #expense
		(
		idfin,
		idmov,
		idupb,
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
	isnull(FL1.idparent, fin.idfin),
	HPV.idexp,
	HPV.idupb,
	15,
	@maxexpensephase,
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
	HPV.amount
FROM historypaymentview HPV
JOIN upb
	ON HPV.idupb = upb.idupb
left outer JOIN finlink
	ON finlink.idchild = HPV.idfin	
	AND finlink.nlevel = @level_input
left outer JOIN finlink FL1
	ON FL1.idchild = HPV.idfin	
	AND FL1.nlevel = @nlevel
JOIN fin
	ON fin.idfin = isnull(FL1.idparent, HPV.idfin)
WHERE HPV.competencydate BETWEEN @start AND @stop
	AND HPV.idupb like @idupb 
	AND HPV.ymov = @ayear
	AND HPV.flagarrear = @kind
	AND fin.ayear = @ayear
	AND ((fin.flag&1)<>0) -- Spesa
	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

-- Variazione ai Movimenti di spesa / fase cassa
IF (@cashvaliditykind <> 4)
BEGIN

	INSERT INTO #expense
		(
		idfin,
		idmov,
		idupb, 
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
		isnull(FL1.idparent, fin.idfin),
		expense.idexp,
		HPV.idupb,
		20,
		expense.nphase,
		expensevar.adate,
		'Var.' +@phasecassa,
		expense.ymov,
		expense.nmov,
		expensevar.nvar,
		HPV.npay,
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
		JOIN historypaymentview HPV
			ON HPV.idexp = expensevar.idexp
		JOIN expense
			ON expense.idexp = expensevar.idexp
		JOIN upb
			ON HPV.idupb = upb.idupb	
		left outer JOIN finlink
			ON finlink.idchild = HPV.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = HPV.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, HPV.idfin)
		WHERE expensevar.yvar = @ayear
			AND expensevar.adate BETWEEN @start AND @stop
			AND isnull(expensevar.autokind,'') <>'22'
			AND   HPV.idupb like @idupb 
			AND HPV.ymov = @ayear
			AND fin.ayear = @ayear
			AND ((fin.flag&1)<>0) -- Spesa
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin) 
			AND HPV.flagarrear = @kind
			AND HPV.competencydate BETWEEN @start AND @stop
			AND HPV.ymov = @ayear
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
END	--(@cashvaliditykind <> 4)

-- costruisce la gerarchia del movimento per creare l'ordinamento nel report
UPDATE #expense 
SET 
	hierarchy = convert(varchar(4),E1.ymov) + '/' + Replicate('0',6-len(convert(varchar(6),E1.nmov)))+ convert(varchar(6),E1.nmov),
	tothierarchy = 
	convert(varchar(4),E1.ymov) + '/' + Replicate('0',6-len(convert(varchar(6),E1.nmov)))+ convert(varchar(6),E1.nmov)
	+' '+ convert(varchar(4),isnull(E2.ymov,'')) + '/' + convert(varchar(6),isnull(E2.nmov,''))
	+' '+ convert(varchar(4),isnull(E3.ymov,'')) + '/' + convert(varchar(6),isnull(E3.nmov,''))
	+' '+ convert(varchar(4),isnull(E4.ymov,'')) + '/' + convert(varchar(6),isnull(E4.nmov,''))
	+' '+ convert(varchar(4),isnull(E5.ymov,'')) + '/' + convert(varchar(6),isnull(E5.nmov,''))
FROM expense
JOIN expenselink EL1
	ON EL1.idchild = expense.idexp  AND EL1.nlevel = 1
LEFT OUTER JOIN expenselink EL2
	ON EL2.idchild = expense.idexp  AND EL2.nlevel = 2
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expense.idexp  AND EL3.nlevel = 3
LEFT OUTER JOIN expenselink EL4
	ON EL4.idchild = expense.idexp  AND EL4.nlevel = 4
LEFT OUTER JOIN expenselink EL5
	ON EL5.idchild = expense.idexp  AND EL4.nlevel = 5
LEFT OUTER JOIN expense E1
	ON E1.idexp = EL1.idparent
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
LEFT OUTER JOIN expense E4
	ON E4.idexp = EL4.idparent
LEFT OUTER JOIN expense E5
	ON E5.idexp = EL5.idparent
WHERE  EL1.idchild = #expense.idmov

-- Qualora una fase abbia la stessa descrizione della fase precedente, viene rimossa la descrizione per non sprecare spazio nel report.

UPDATE #expense SET description = null
	FROM expense
	JOIN expenselink
		ON expense.idexp = expenselink.idparent 
	WHERE #expense.idmov = expenselink.idchild AND expenselink.nlevel = #expense.nphase-1 
		AND expense.description = #expense.description

UPDATE #expense
	SET 	emessiondate = paymentview.adate,
		printeddate = 	paymentview.printdate,
		trasmitteddate = paymentview.transmissiondate,	
		transactiondate = paymentperformed.competencydate,
		annulmentdate = paymentview.annulmentdate
	FROM paymentview
	LEFT OUTER JOIN banktransaction
		ON banktransaction.kpay=paymentview.kpay	
		AND (banktransaction.kind='D' OR banktransaction.kind IS NULL)
	LEFT OUTER JOIN  paymentperformed 
		ON paymentperformed.npay=paymentview.npay
		AND paymentperformed.ypay=paymentview.ypay
	WHERE #expense.ndoc = paymentview.npay and paymentview.ypay=@ayear


IF (@suppressifblank = 'N') 
BEGIN
--se ho scelto di vedere l'upb inserisco le coppie upb/bilancio altrimenti inserisco solo il bilanico non utilizzato
	IF ( (@showupb <>'S') and (@idupboriginal = '%'))
	Begin
		INSERT INTO #expense(
				idfin,
				rowkind
				)
		SELECT 
			fin.idfin,
			1
		FROM fin 
		JOIN finlink
			ON finlink.idchild = fin.idfin	
			AND finlink.nlevel = @level_input
		WHERE  fin.ayear = @ayear
			AND ((fin.flag&1) <>0 ) -- Spesa
			AND fin.nlevel = @nlevel
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
		End
	Else
		Begin
		INSERT INTO #expense 
			(
				idfin,
				idupb,
				rowkind
				)
		SELECT 
			fin.idfin,
			upb.idupb,
			1
		FROM fin CROSS JOIN upb 
		left outer JOIN finlink
			ON finlink.idchild = fin.idfin	
			AND finlink.nlevel = @level_input
		WHERE (upb.idupb like @idupb )
			AND fin.ayear = @ayear
			AND ((fin.flag&1)<>0) -- Spesa
			AND fin.nlevel = @nlevel
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)				
		End

END



-- se ho scelto di nascondere le voci di bilancio non utilizzate:
-- cancello le righe che hanno valori pari a zero 
-- per cui non esistono variazioni di previzioni (rowkind=2) o movimenti di entrata (rowkind >= 3 )  
IF (@suppressifblank = 'S') AND @nlevel>2	--> se la stampa è x un livello sottostante la categoria cancella le righe
BEGIN
	DELETE FROM #expense WHERE 
		ISNULL(initialprevision,0)=0 
		AND ISNULL(finvar,0)=0 
		AND ISNULL(finphase_amount,0)=0 
		AND ISNULL(cassaphase_amount,0)=0 
		AND	NOT EXISTS (select * from  #expense i
				where #expense.idupb = i.idupb AND 
				      #expense.idfin=i.idfin AND 
					i.rowkind>1)
END

IF (@showupb = 'S') 
BEGIN
	SELECT #expense.idfin,
		idmov,
		@level as levelname,
		F.codefin,
		F.printingorder as finprintingorder,
		F.title,
		U.codeupb,
		#expense.idupb,
		U.title as upb,
		U.printingorder as upbprintingorder,
		rowkind,
		nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,
		ndoc,description,doc,annotations,
		CASE
			WHEN nphase = @regphase  THEN REG.title
			ELSE NULL
		END as registry,	
		isnull(sum(initialprevision),0) as initialprevision,
		isnull(sum(finvar),0) as finvar,
		isnull(sum(finphase_amount),0) as finphase_amount,
		isnull(sum(available),0) as available,
		isnull(sum(cassaphase_amount),0) as cassaphase_amount,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@finname as finname,	
		@secondphase as secondphase,
		@thirdphase as thirdphase,					
		@fourthphase as fourthphase,
		@phasecassa as phasecassa,
		hierarchy,tothierarchy
 	FROM #expense	
	JOIN fin F
		ON F.idfin = #expense.idfin
	JOIN upb U
		ON U.idupb = #expense.idupb	
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #expense.idreg	
	GROUP BY U.codeupb,#expense.idupb,U.title,U.printingorder,
		hierarchy,tothierarchy,
		F.printingorder,#expense.idfin,idmov,F.codefin,F.title,
		rowkind,nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,ndoc,description,doc,
		annotations,REG.title,emessiondate,printeddate			,
		trasmitteddate,transactiondate,annulmentdate
	ORDER BY upbprintingorder ASC, F.printingorder ASC,hierarchy ASC,tothierarchy ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nofficial ASC,
		nsubmov ASC
END


IF (@showupb ='N')
BEGIN
		declare 	@codeupb varchar(50)
		declare		@upb varchar(150)
		declare		@upbprintingorder varchar(50)
		declare		@ext_idupb varchar(50)

		if (@idupboriginal='%')
		begin
			set @codeupb= null
			set @upb= null
			set @upbprintingorder= null
			set @ext_idupb= null
		end
		else
		begin
			SET @upbprintingorder =
				(SELECT TOP 1 printingorder
				FROM upb
				WHERE idupb = @idupboriginal)
			SET  @upb =
				(SELECT TOP 1 title
				FROM upb
				WHERE idupb = @idupboriginal)
			SET  @ext_idupb =	@idupboriginal
			SET  @codeupb =
				(SELECT TOP 1 codeupb
				FROM upb	
				WHERE idupb = @idupboriginal)
		end

	SELECT 
		#expense.idfin,
		idmov,
		@level as levelname,
		F.codefin,
		F.printingorder as finprintingorder,
		F.title,
		@codeupb as codeupb,
		@ext_idupb as idupb,
		@upb as upb,
		@upbprintingorder as upbprintingorder,	
		rowkind,
		nphase,
		operationdate,
		operationkind,ymov,nmov,nofficial,nsubmov,
		ndoc,description,doc,annotations,
		CASE
			WHEN nphase = @regphase  THEN REG.title
			ELSE NULL
		END as registry,	
		isnull(sum(initialprevision),0) as initialprevision,
		isnull(sum(finvar),0) as finvar	,
		isnull(sum(finphase_amount),0) as finphase_amount,
		isnull(sum(available),0) as available,
		isnull(sum(cassaphase_amount),0) as cassaphase_amount,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@finname as finname,	
		@secondphase as secondphase,
		@thirdphase as thirdphase  ,					
		@fourthphase as fourthphase,
		@phasecassa as phasecassa,
		hierarchy,
		tothierarchy
	FROM #expense
	JOIN fin F
		ON F.idfin = #expense.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #expense.idreg  
	GROUP BY hierarchy,tothierarchy,
		F.printingorder,#expense.idfin,idmov,F.codefin,F.title,
		rowkind,nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,ndoc,description,doc,
		annotations,REG.title,emessiondate,printeddate			,
		trasmitteddate,transactiondate,annulmentdate
	ORDER BY  finprintingorder ASC,hierarchy ASC,tothierarchy ASC,
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




 
