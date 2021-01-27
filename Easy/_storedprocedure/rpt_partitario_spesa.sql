
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_spesa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_spesa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
exec rpt_partitario_spesa 2006, 'C','N','%','N',2,10655,{ts '2006-01-01 00:00:00'},{ts '2006-08-30 00:00:00'},'S','N'
exec rpt_partitario_spesa 2006, 'R','N','%','N',3,10655,{ts '2006-02-01 00:00:00'},{ts '2006-08-30 00:00:00'},'N','N'
*/

CREATE    PROCEDURE rpt_partitario_spesa
	@ayear int,
	@kind char(1),
	@showupb char(1),
	@idupb varchar(36),
	@showchildupb char(1),
	@nlevel tinyint,
	@idfin int,
	@start datetime,
	@stop datetime,
	@suppressifblank char(1),
	@flagnofficial	char(1)
AS
BEGIN
/* Versione 1.0.1 del 17/09/2007 ultima modifica: PINO */
DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END

DECLARE @level_input tinyint
SELECT @level_input=ISNULL(nlevel, @nlevel) from fin where idfin = @idfin
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@nlevel < @level_input ) AND (@idfin is not null)
	BEGIN
	SET  @nlevel = @level_input
	END

DECLARE @level varchar(50)
SELECT @level = description 
	FROM finlevel
	WHERE nlevel = @nlevel
	AND ayear = @ayear

DECLARE @levelusable tinyint
SELECT @levelusable = MIN(nlevel)
	FROM finlevel
	WHERE flag&2 <> 0
	AND ayear = @ayear
IF @levelusable < @nlevel
BEGIN	
	SET @levelusable = @nlevel
END


DECLARE	@kind_bit  tinyint 
if @kind='C' set @kind_bit = 0
if @kind='R' set @kind_bit = 1

CREATE TABLE #payments
(
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
	idfin int,
	rowkind	int,
	nphase tinyint,
	operationdate datetime,
	operationkind varchar(55),
	idreg int ,
	idmov int,
	ymov int,
	nmov int,
	nofficial int, --numero ufficiale delle variazioni di bilancio
	nsubmov int,
	ndoc int,
	description  varchar(150),
        doc varchar(150),
	initialprevision decimal(19,2),
	finvar decimal(19,2),
	finphase_amount decimal(19,2),
	cassaphase_amount decimal(19,2),
	emessiondate datetime,
	printeddate datetime,
	trasmitteddate datetime,
	transactiondate	datetime,
	annulmentdate datetime,
	annotations varchar(400)
)
DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)
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
IF ((@kind IN ('C','S')) AND (DATEDIFF(DAY,@start, @firstday) = 0))
BEGIN
-- Previsione iniziale
	INSERT INTO #payments
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
						JOIN finlink FLK
							ON FLK.idchild = fy2.idfin and FLK.nlevel = @nlevel
						WHERE FLK.idparent = fin.idfin 
							AND f2.nlevel = @levelusable AND fy2.idupb= upb.idupb
							)
			WHEN (@kind = 'S' and @previsionkind = 'S') 
					THEN (SELECT SUM(fy2.prevision) 
						FROM finyear fy2 
						JOIN fin f2
							ON fy2.idfin=f2.idfin
						JOIN finlink FLK
							ON FLK.idchild = fy2.idfin and FLK.nlevel = @nlevel
						WHERE FLK.idparent = fin.idfin 
							AND f2.nlevel = @levelusable AND fy2.idupb= upb.idupb
							)
			WHEN (@kind = 'S' and @secprevisionkind = 'S') 
					THEN (SELECT SUM(fy2.secondaryprev) 
						FROM finyear fy2 
						JOIN fin f2
							ON fy2.idfin=f2.idfin
						JOIN finlink FLK
							ON FLK.idchild = fy2.idfin and FLK.nlevel = @nlevel
						WHERE FLK.idparent = fin.idfin
							AND f2.nlevel = @levelusable AND fy2.idupb= upb.idupb
							)
			END
	FROM finyear
	JOIN fin
		ON finyear.idfin = fin.idfin
	left outer JOIN finlink 
		ON finlink.idchild = fin.idfin and finlink.nlevel = @level_input
	JOIN upb
		ON finyear.idupb = upb.idupb
	WHERE (upb.idupb like @idupb )
		AND fin.ayear = @ayear
		AND  (( fin.flag & 1)=1)
		AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
END

DECLARE @finphase tinyint
SELECT @finphase = appropriationphasecode
	FROM config
	WHERE ayear = @ayear
IF @finphase IS NULL
	BEGIN
		SELECT @finphase = expensefinphase
			FROM uniconfig
	END
DECLARE @maxexpensephase tinyint
SELECT @maxexpensephase = MAX(nphase) FROM expensephase

IF (DATEDIFF(DAY,@start, @firstday) <> 0)
BEGIN
	CREATE TABLE #previousexpense
	(
		idfin int,
		idupb varchar(36),
		initialprevision decimal(19,2),
		finvar decimal(19,2),
		finphase_amount decimal(19,2),
		cassaphase_amount decimal(19,2)	
	)
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
	left outer JOIN finlink 
		ON finlink.idchild = fin.idfin and finlink.nlevel =  @level_input
	JOIN upb
		ON finyear.idupb = upb.idupb
	WHERE (upb.idupb like @idupb )
		AND fin.ayear = @ayear
		AND  (( fin.flag & 1) = 1)
		AND fin.nlevel = @nlevel
		and (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
	
	IF (@kind IN('C','S'))
	BEGIN
		UPDATE #previousexpense
			SET initialprevision =
				(SELECT 
					CASE
					WHEN @kind = 'C' THEN SUM(fy2.prevision) 
					WHEN (@kind = 'S' and @previsionkind = 'S') THEN SUM(fy2.prevision) 
					WHEN (@kind = 'S' and @secprevisionkind = 'S') THEN SUM(fy2.secondaryprev) 
				END
				FROM finyear fy2
				JOIN fin f2
					ON fy2.idfin = f2.idfin	
				JOIN finlink FLK
					ON FLK.idchild = fy2.idfin and FLK.nlevel =  @nlevel
				WHERE fy2.idupb= #previousexpense.idupb
					AND FLK.idparent = #previousexpense.idfin 
					AND f2.nlevel = @levelusable),
			finvar =
				(SELECT SUM(finvardetail.amount)
				FROM finvardetail
				JOIN finvar
					ON finvar.yvar = finvardetail.yvar
					AND finvar.nvar = finvardetail.nvar
				JOIN finlink FLK
					ON FLK.idchild = finvardetail.idfin and FLK.nlevel =  @nlevel
				WHERE finvardetail.idupb = #previousexpense.idupb 
					AND finvar.flagprevision ='S'
					AND finvar.idfinvarstatus = 5
					AND finvar.variationkind <> 5
					AND finvar.adate < @start
					AND FLK.idparent = #previousexpense.idfin 
					)
	END
	ELSE
	BEGIN
		UPDATE #previousexpense
			SET initialprevision =
				(SELECT SUM(expenseyear.amount)
				FROM expenseyear
				JOIN expense
					ON expense.idexp = expenseyear.idexp
				JOIN finlink FLK
					ON FLK.idchild = expenseyear.idfin and FLK.nlevel =  @nlevel
				JOIN expensetotal
					ON expenseyear.idexp = expensetotal.idexp
					AND expenseyear.ayear = expensetotal.ayear
				WHERE (( expensetotal.flag & 1)= @kind_bit)
					AND expenseyear.idupb = #previousexpense.idupb
					AND expense.adate < @start
					AND expense.nphase = @finphase
					AND FLK.idparent = #previousexpense.idfin 
					AND expenseyear.ayear = @ayear)
	END
	IF (@kind in ('C','R'))
	BEGIN
	UPDATE #previousexpense
		SET finphase_amount = ISNULL((
			SELECT SUM(expenseyear.amount)
			FROM expenseyear
			JOIN expense
				ON expense.idexp = expenseyear.idexp
			JOIN expensetotal
				ON expenseyear.idexp = expensetotal.idexp
				AND expenseyear.ayear = expensetotal.ayear
			JOIN finlink FLK
				ON FLK.idchild = expenseyear.idfin and FLK.nlevel =  @nlevel
			WHERE (( expensetotal.flag & 1)= @kind_bit)
				AND expense.adate < @start
				AND expense.nphase = @finphase
				AND expenseyear.idupb = #previousexpense.idupb
				AND FLK.idparent = #previousexpense.idfin
				AND expenseyear.ayear = @ayear), 0)
			+ 
			ISNULL((
			SELECT SUM(expensevar.amount)
			FROM expensevar
			JOIN expenseyear
				ON expenseyear.idexp = expensevar.idexp
			JOIN expense
				ON expense.idexp = expensevar.idexp
			JOIN expensetotal
				ON expenseyear.idexp = expensetotal.idexp
				AND expenseyear.ayear = expensetotal.ayear
			JOIN finlink FLK
				ON FLK.idchild = expenseyear.idfin and FLK.nlevel =  @nlevel
			WHERE expensevar.yvar = @ayear
				AND expenseyear.ayear = @ayear
				AND expenseyear.idupb = #previousexpense.idupb
				AND FLK.idparent = #previousexpense.idfin
				AND (( expensetotal.flag & 1)= @kind_bit)
				AND expense.nphase = @finphase
				AND expensevar.adate < @start), 0)
	END
	IF (@cashvaliditykind <> 4)
	BEGIN
		UPDATE #previousexpense
		SET cassaphase_amount = ISNULL((
				SELECT SUM(amount)
				FROM historypaymentview 
				JOIN finlink 
					ON idchild = idfin and nlevel =  @nlevel
				WHERE (flagarrear = @kind OR @kind = 'S')
					AND idupb = #previousexpense.idupb
					AND competencydate < @start
					AND idparent = #previousexpense.idfin
					AND ymov = @ayear)
				, 0)
				+ 
				ISNULL((
				SELECT SUM(expensevar.amount)
				FROM expensevar
				JOIN historypaymentview HPV
					ON HPV.idexp = expensevar.idexp
				JOIN finlink FLK
					ON FLK.idchild = HPV.idfin and FLK.nlevel =  @nlevel
				WHERE expensevar.yvar = @ayear
					AND HPV.idupb = #previousexpense.idupb
					AND HPV.competencydate <= @start AND HPV.ymov = @ayear
					AND FLK.idparent = #previousexpense.idfin
					AND (HPV.flagarrear = @kind OR @kind = 'S')
					AND expensevar.adate < @start

				), 0)
	END
	ELSE
	BEGIN
		UPDATE #previousexpense
		SET cassaphase_amount =  ISNULL((
				SELECT SUM(amount)
				FROM historypaymentview 
				JOIN finlink 
					ON idchild = idfin and nlevel =  @nlevel
				WHERE (flagarrear = @kind OR @kind = 'S')
					AND idupb = #previousexpense.idupb
					AND competencydate < @start
					AND idparent = #previousexpense.idfin
					AND ymov = @ayear)
				, 0)
	END
	INSERT INTO #payments
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
IF (@kind IN ('C','S')) 
BEGIN
-- Variazioni di previsione
INSERT INTO #payments
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
	isnull(FL1.idparent, fin.idfin),
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
		ELSE null
	END, 
	finvar.description,
	finvardetail.amount
FROM finvardetail
JOIN finvar
	ON finvar.yvar  = finvardetail.yvar
	AND finvar.nvar = finvardetail.nvar
left outer JOIN finlink 
	ON finlink.idchild = finvardetail.idfin and finlink.nlevel =  @level_input
left outer JOIN finlink FL1
	ON FL1.idchild = finvardetail.idfin AND FL1.nlevel = @nlevel
JOIN fin
	ON fin.idfin = FL1.idparent
JOIN upb 
	ON upb.idupb=finvardetail.idupb 
WHERE 	fin.ayear = @ayear
	AND finvar.flagprevision = 'S'	
	AND finvar.idfinvarstatus = 5
	AND finvar.variationkind <> 5
	AND finvar.adate BETWEEN @start AND @stop
	AND  (( fin.flag & 1)=1)
	AND fin.nlevel = @nlevel
	and (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
	and (upb.idupb like @idupb)
END
DECLARE @finname varchar(50)
SELECT @finname = description
FROM expensephase
WHERE nphase = @finphase
IF (@kind IN ( 'C','R'))
BEGIN
--	Movimenti di spesa / fase di bilancio
INSERT INTO #payments
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
	description,
	idreg,
	finphase_amount
	)
SELECT 
	isnull(FL1.idparent, fin.idfin),
	expense.idexp,
	upb.idupb,upb.codeupb,upb.title,upb.printingorder,
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
JOIN expensetotal
	ON expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
left outer JOIN finlink 
	ON finlink.idchild = expenseyear.idfin AND finlink.nlevel = @level_input
JOIN upb 
	ON upb.idupb=expenseyear.idupb
left outer JOIN finlink FL1
	ON FL1.idchild = expenseyear.idfin AND FL1.nlevel = @nlevel
JOIN fin
	ON fin.idfin = FL1.idparent
WHERE expense.nphase = @finphase
	AND expenseyear.ayear = @ayear
	AND fin.ayear = @ayear
	AND  (( fin.flag & 1)=1)
	AND fin.nlevel = @nlevel
	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
	AND (( expensetotal.flag & 1) = @kind_bit)
	AND (
	(@kind = 'C' AND expense.adate BETWEEN @start AND @stop) 
	OR 
	(@kind = 'R' AND DATEDIFF(DAY,@start,@firstday) = 0)
	)
	AND (upb.idupb like @idupb )
-- Variazioni movimenti di spesa / fase di bilancio
INSERT INTO #payments
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
	isnull(FL1.idparent, fin.idfin),
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
JOIN expensetotal
	ON expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
left outer JOIN finlink 
	ON finlink.idchild = expenseyear.idfin AND finlink.nlevel =  @level_input
JOIN upb 
	ON upb.idupb = expenseyear.idupb
left outer JOIN finlink FL1
	ON FL1.idchild = expenseyear.idfin AND FL1.nlevel = @nlevel
JOIN fin
	ON fin.idfin = FL1.idparent
WHERE expensevar.yvar = @ayear
	AND expensevar.adate BETWEEN @start AND @stop
	AND (upb.idupb like @idupb)
	AND expense.nphase = @finphase
	AND expenseyear.ayear = @ayear
	AND ((expensetotal.flag & 1) = @kind_bit) 
	AND fin.ayear = @ayear
	AND ((fin.flag & 1)=1)
	AND fin.nlevel = @nlevel
	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
END
DECLARE @phasecassa varchar(50)
SELECT @phasecassa = description
	FROM expensephase
	WHERE nphase = @maxexpensephase
-- Movimenti di spesa / fase di cassa
INSERT INTO #payments
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
	isnull(FL1.idparent, fin.idfin),
	HPV.idexp,
	upb.idupb,upb.codeupb,upb.title,upb.printingorder,
	5,
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
	idreg,	
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
	ON fin.idfin = FL1.idparent
WHERE HPV.competencydate BETWEEN @start AND @stop 
	AND (upb.idupb like @idupb )
	AND HPV.ymov = @ayear
	AND (   (@kind IN ('C', 'R') AND (HPV.totflag & 1)= @kind_bit) OR @kind = 'S')
	AND fin.ayear = @ayear
	AND (( fin.flag & 1) = 1)
	AND fin.nlevel = @nlevel
	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
-- Variazione ai Movimenti di spesa / fase cassa
IF (@cashvaliditykind <> 4)
BEGIN
	INSERT INTO #payments
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
		isnull(FL1.idparent, fin.idfin),
		expense.idexp,
		upb.idupb, upb.codeupb,upb.title,upb.printingorder,
		6,
		expense.nphase,
		expensevar.adate,
		'Var.' + @phasecassa,
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
	JOIN expense
		ON expense.idexp = expensevar.idexp
	JOIN historypaymentview HPV
		ON HPV.idexp = expensevar.idexp
	JOIN upb
		ON upb.idupb = HPV.idupb
	left outer JOIN finlink 
		ON finlink.idchild = HPV.idfin AND finlink.nlevel =  @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = HPV.idfin AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = FL1.idparent
	WHERE expensevar.yvar = @ayear
		AND expensevar.adate BETWEEN @start AND @stop
		AND isnull(expensevar.autokind,'') <>'22' 
		AND (upb.idupb like @idupb)
		AND HPV.competencydate BETWEEN @start AND @stop AND HPV.ymov = @ayear
		AND fin.ayear = @ayear
		AND ((fin.flag & 1)=1)
		-- AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin) 
		AND ((@kind IN ('C', 'R') AND ((HPV.totflag & 1)= @kind_bit))   OR @kind = 'S')
END
UPDATE #payments
	SET 	emessiondate = paymentview.adate,
		printeddate = 	paymentview.printdate,
		trasmitteddate = paymentview.transmissiondate,	
		transactiondate = paymentperformed.competencydate,
		annulmentdate = paymentview.annulmentdate
FROM paymentview
LEFT OUTER JOIN banktransaction
	ON banktransaction.kpay=paymentview.kpay	
	AND (banktransaction.kind='D' OR banktransaction.kind IS NULL)
LEFT OUTER JOIN paymentperformed 
	ON paymentperformed.npay=paymentview.npay
	AND paymentperformed.ypay=paymentview.ypay
WHERE #payments.ndoc = paymentview.npay
	AND paymentview.ypay=@ayear
	


IF (@suppressifblank = 'N')
BEGIN
	INSERT INTO #payments 
		(
			idfin,
			idupb,
			codeupb,
			upb,
			upbprintingorder,
			rowkind
			)
	SELECT 
		isnull(FL1.idparent, fin.idfin),
		upb.idupb,
		codeupb,
		upb.title,
		upb.printingorder,
		1
	FROM fin CROSS JOIN upb 
	left outer JOIN finlink
		ON finlink.idchild = fin.idfin 
		and finlink.nlevel =  @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = fin.idfin	
		AND FL1.nlevel = @nlevel
	WHERE (upb.idupb like @idupb )
		AND fin.ayear = @ayear
		AND (( fin.flag & 1)=1)
		AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin) 
		and not exists (SELECT *
			FROM #payments
			WHERE upb.idupb = #payments.idupb 
			AND FL1.idparent = #payments.idfin
		)

END

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		UPDATE #payments SET  
			upbprintingorder = (SELECT TOP 1 upbprintingorder
				FROM #payments
				WHERE idupb = @idupboriginal),
			upb = (SELECT TOP 1 upb
				FROM #payments
				WHERE idupb = @idupboriginal),
			idupb = @idupboriginal,
			codeupb =(SELECT TOP 1 codeupb
				FROM #payments	
				WHERE idupb = @idupboriginal)
	
IF (@showupb <>'S') and (@idupboriginal = '%') --(@idupboriginal IS NULL)
			UPDATE #payments SET  
			upbprintingorder = null	,
			upb =  null,
			idupb = null,
			codeupb = null
-- si ho scelto di nascondere le voci di bilancio non utilizzate:
-- cancello le righe che hanno valori pari a zero 
-- per cui non esistono variazioni di previzioni (rowkind=2) o movimenti di entrata (rowkind >= 3 )  
IF (@suppressifblank = 'S') AND @nlevel>2	--> se la stampa è x un livello sottostante la categoria cancella le righe
BEGIN
	DELETE FROM #payments WHERE 
		ISNULL(initialprevision,0)=0 AND 
		ISNULL(finvar,0)=0 AND 
		ISNULL(finphase_amount,0)=0 AND 
		ISNULL(cassaphase_amount,0)=0 AND
		NOT EXISTS (select * from  #payments i
				where #payments.idupb=i.idupb AND 
				      #payments.idfin=i.idfin AND 
					i.rowkind>1)
END

IF (@showupb <>'S')
	SELECT 
		#payments.idfin,
		idmov,
		@level as levelname,
		F.codefin,
		F.printingorder as finprintingorder,
		F.title,
		codeupb,idupb,upb,upbprintingorder,
		rowkind,
		nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,
		ndoc,description,doc,annotations,
		REG.title as registry,
		SUM(initialprevision) as initialprevision,
		SUM(finvar) as finvar	,
		SUM(finphase_amount) as finphase_amount,
		SUM(cassaphase_amount) as cassaphase_amount	,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@phasecassa as phasecassa,
		@finname as finname			
	FROM #payments
	JOIN fin F
		ON F.idfin = #payments.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #payments.idreg
	GROUP BY codeupb,idupb,upb,upbprintingorder,
		F.printingorder,#payments.idfin,idmov,
		F.codefin,F.title,
		rowkind,nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,ndoc,description,doc,
		annotations,REG.title,finvar,emessiondate,printeddate,
		trasmitteddate,transactiondate,annulmentdate
	ORDER BY upbprintingorder ASC, F.printingorder ASC,
		operationdate ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nofficial ASC,
		nsubmov ASC
ELSE
	SELECT #payments.idfin,idmov,@level as levelname,
		F.codefin,
		F.printingorder as finprintingorder,
		F.title,
		codeupb,idupb,upb,upbprintingorder,rowkind,
		nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,
		ndoc,description,doc,annotations,REG.title as registry,
		initialprevision,finvar,finphase_amount,cassaphase_amount,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@phasecassa as phasecassa,
		@finname as finname	 
	FROM #payments
	JOIN fin F
		ON F.idfin = #payments.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #payments.idreg
		ORDER BY upbprintingorder ASC, F.printingorder ASC,
		operationdate ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nofficial ASC,
		nsubmov ASC
  END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
