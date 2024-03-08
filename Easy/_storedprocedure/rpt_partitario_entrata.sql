
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_entrata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_entrata]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE     PROCEDURE rpt_partitario_entrata
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
/*
-- exec rpt_partitario_entrata 2006, 'C','N','%','N',3,null,{ts '2006-01-30 00:00:00'},{ts '2006-08-30 00:00:00'},'S','N'
select idparent from finlink where idchild=10675 and nlevel=2
 exec rpt_partitario_entrata 2006, 'C','N','%','N',3,10642,{ts '2006-01-01 00:00:00'},{ts '2006-08-30 00:00:00'},'N','N'
exec rpt_partitario_entrata 2006, 'R','N','%','N',3,NULL,{ts '2006-02-01 00:00:00'},{ts '2006-08-30 00:00:00'},'N','N'

*/
/* Versione 1.0.1 del 17/09/2007 ultima modifica: PINO */
DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S')
BEGIN
	SET @idupb=@idupb+'%' 
END

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@nlevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@nlevel < @level_input ) AND (@idfin is not null)
	BEGIN
	SET  @nlevel = @level_input
	END

DECLARE @level 	varchar(50)
SELECT @level = description 
	FROM finlevel
	WHERE nlevel = @nlevel
	AND ayear = @ayear	


DECLARE @levelusable tinyint
SELECT @levelusable = MIN(nlevel)
	FROM finlevel
	WHERE flag&2 <> 0
	AND ayear = @ayear

IF (@levelusable < @nlevel)
	BEGIN
	SET @levelusable = @nlevel
	END


DECLARE	@kind_bit  tinyint 
if @kind='C' set @kind_bit = 0
if @kind='R' set @kind_bit = 1

CREATE TABLE #income	(
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
	idfin int,
	rowkind int,
	nphase tinyint,
	operationdate datetime,
	operationkind varchar(55),
	idreg int,
	idmov int,
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
DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)
declare @fin_kind tinyint
select @fin_kind = fin_kind 
	FROM config 
	WHERE ayear = @ayear

IF ((@kind IN ('C','S')) AND (DATEDIFF(DAY,@start, @firstday) = 0))
BEGIN
	INSERT INTO #income
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
			WHEN (@kind = 'S' and @fin_kind = 2) 
					THEN (SELECT SUM(fy2.prevision) 
						FROM finyear fy2 
						JOIN fin f2
							ON fy2.idfin=f2.idfin
						JOIN finlink FLK
							ON FLK.idchild = fy2.idfin and FLK.nlevel = @nlevel
						WHERE FLK.idparent = fin.idfin 
							AND f2.nlevel = @levelusable AND fy2.idupb= upb.idupb
							)
			WHEN (@kind = 'S' and @fin_kind = 3) 
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
	JOIN finlink 
		ON finlink.idchild = fin.idfin and finlink.nlevel = @level_input
	JOIN upb
		ON finyear.idupb = upb.idupb

	WHERE (upb.idupb like @idupb )
		AND fin.ayear = @ayear
		AND  (( fin.flag & 1)=0)
		AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
END
DECLARE @finphase tinyint
SELECT @finphase = assessmentphasecode
	FROM config
	WHERE ayear = @ayear
IF @finphase IS NULL
	BEGIN
		SELECT @finphase = incomefinphase
			FROM uniconfig
	END
DECLARE @maxincomephase tinyint
SELECT  @maxincomephase = MAX(nphase) FROM incomephase
DECLARE @cashvaliditykind int
SELECT  @cashvaliditykind = cashvaliditykind
FROM config
WHERE ayear = @ayear
IF (DATEDIFF(DAY,@start, @firstday) <> 0)
BEGIN
	CREATE TABLE #previousincome
	(
		idfin int,
		idupb varchar(36),
		initialprevision decimal(19,2),
		finvar decimal(19,2),
		finphase_amount decimal(19,2),
		cassaphase_amount decimal(19,2),
	)
	INSERT INTO #previousincome
		(
		idfin,
		idupb
		)
	SELECT finyear.idfin,
	       finyear.idupb
	FROM finyear
	JOIN fin
		ON finyear.idfin = fin.idfin
	JOIN finlink 
		ON finlink.idchild = fin.idfin and finlink.nlevel = @level_input
	JOIN upb
		ON finyear.idupb = upb.idupb
	WHERE (upb.idupb like @idupb )
		AND fin.ayear = @ayear
		AND  (( fin.flag & 1)=0)
		AND fin.nlevel = @nlevel
		and (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)

	IF (@kind IN('C','S'))
	BEGIN
		UPDATE #previousincome
		SET initialprevision = 
			(SELECT 
				CASE
					WHEN @kind = 'C' THEN SUM(fy2.prevision) 
					WHEN (@kind = 'S' and @fin_kind = 2) THEN SUM(fy2.prevision) 
					WHEN (@kind = 'S' and @fin_kind = 3) THEN SUM(fy2.secondaryprev) 
				END
				FROM finyear fy2
				JOIN fin f2
					ON fy2.idfin = f2.idfin	
				JOIN finlink FLK
					ON FLK.idchild = fy2.idfin and FLK.nlevel =  @nlevel
			WHERE 	fy2.idupb= #previousincome.idupb
				AND FLK.idparent = #previousincome.idfin 
				AND f2.nlevel = @levelusable),
		finvar = (
			SELECT SUM(finvardetail.amount)
			FROM finvardetail
			JOIN finvar
				ON finvar.yvar = finvardetail.yvar
				AND finvar.nvar = finvardetail.nvar
			JOIN finlink FLK
				ON FLK.idchild = finvardetail.idfin and FLK.nlevel =  @nlevel
			WHERE finvar.flagprevision ='S'
				AND finvar.idfinvarstatus = 5
				AND finvar.variationkind <> 5
				AND finvar.adate < @start
				AND finvar.yvar = @ayear
				AND finvardetail.idupb = #previousincome.idupb
				AND FLK.idparent = #previousincome.idfin 
				)
	END
	ELSE
	BEGIN
		UPDATE #previousincome
		SET initialprevision =(
			SELECT SUM(incomeyear.amount)
			FROM incomeyear
			JOIN income
				ON income.idinc = incomeyear.idinc
			JOIN finlink FLK
				ON FLK.idchild = incomeyear.idfin and FLK.nlevel =  @nlevel
			JOIN incometotal
				ON incomeyear.idinc = incometotal.idinc
				AND incomeyear.ayear = incometotal.ayear
			WHERE  (( incometotal.flag & 1)= @kind_bit)
				AND income.adate < @start
				AND income.nphase = @finphase
				AND incomeyear.idupb = #previousincome.idupb
				AND FLK.idparent = #previousincome.idfin 
				AND incomeyear.ayear = @ayear)
	END
	IF (@kind in ('C','R'))
	BEGIN
	UPDATE #previousincome
		SET finphase_amount = ISNULL((
			SELECT SUM(incomeyear.amount)
			FROM incomeyear
			JOIN income
				ON income.idinc = incomeyear.idinc
			JOIN incometotal
				ON incomeyear.idinc = incometotal.idinc
				AND incomeyear.ayear = incometotal.ayear
			JOIN finlink FLK
				ON FLK.idchild = incomeyear.idfin and FLK.nlevel =  @nlevel
			WHERE  (( incometotal.flag & 1)= @kind_bit)
				AND income.adate < @start
				AND income.nphase = @finphase
				AND incomeyear.idupb = #previousincome.idupb
				AND FLK.idparent = #previousincome.idfin
				AND incomeyear.ayear = @ayear), 0)
			+ 
			ISNULL((
			SELECT SUM(incomevar.amount)
			FROM incomevar
			JOIN incomeyear
				ON incomeyear.idinc = incomevar.idinc
			JOIN income
				ON income.idinc = incomevar.idinc
			JOIN incometotal
				ON incomeyear.idinc = incometotal.idinc
				AND incomeyear.ayear = incometotal.ayear
			JOIN finlink FLK
				ON FLK.idchild = incomeyear.idfin and FLK.nlevel =  @nlevel
			WHERE incomevar.yvar = @ayear
				AND incomeyear.ayear = @ayear
				AND incomeyear.idupb = #previousincome.idupb
				AND FLK.idparent = #previousincome.idfin
				AND (( incometotal.flag & 1)= @kind_bit)
				AND income.nphase = @finphase
				AND incomevar.adate < @start), 0)
	END
	IF (@cashvaliditykind <> 4)
	BEGIN
		UPDATE #previousincome 
		SET cassaphase_amount = ISNULL((
				SELECT SUM(amount)
			 	FROM historyproceedsview 
				JOIN finlink 
					ON idchild = idfin and nlevel =  @nlevel
				WHERE (flagarrear = @kind OR @kind = 'S')
					AND idupb = #previousincome.idupb
					AND competencydate < @start
					AND idparent = #previousincome.idfin
					AND ymov = @ayear)
				, 0)
				+ 
				ISNULL((
				SELECT SUM(incomevar.amount)
				FROM incomevar
				JOIN historyproceedsview HPV
					ON HPV.idinc = incomevar.idinc
				JOIN finlink FLK
					ON FLK.idchild = HPV.idfin and FLK.nlevel =  @nlevel
				WHERE incomevar.yvar = @ayear
					AND HPV.idupb = #previousincome.idupb
					AND HPV.competencydate <= @start AND HPV.ymov = @ayear
					AND FLK.idparent = #previousincome.idfin
					AND (HPV.flagarrear = @kind OR @kind = 'S')
					AND incomevar.adate < @start

				), 0)
	END
	ELSE
	BEGIN
		UPDATE #previousincome 
		SET cassaphase_amount = ISNULL((
				SELECT SUM(amount)
				FROM historyproceedsview 
				JOIN finlink 
					ON idchild = idfin and nlevel =  @nlevel
				WHERE (flagarrear = @kind OR @kind = 'S')
					AND idupb = #previousincome.idupb
					AND competencydate < @start
					AND idparent = #previousincome.idfin
					AND ymov = @ayear)
				, 0)
	END

	INSERT INTO #income
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
		#previousincome.idfin,
		upb.idupb,
		upb.codeupb,
		upb.title,
		upb.printingorder,
		1,
		DATEADD(dd, -1, @start),
		'Tot.prec.',
		#previousincome.initialprevision,
		#previousincome.finvar,
		#previousincome.finphase_amount,
		#previousincome.cassaphase_amount
	FROM #previousincome
	JOIN fin
		ON fin.idfin = #previousincome.idfin
	JOIN upb 
		ON upb.idupb=#previousincome.idupb

END	
IF (@kind IN ('C','S')) 
BEGIN

-- Variazione di previsione
	INSERT INTO #income
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
		CASE	finvar.official 
			WHEN 'S' THEN finvar.nofficial
			ELSE	NULL
		END,
		finvar.description,
		finvardetail.amount
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	left outer JOIN finlink 
		ON finlink.idchild = finvardetail.idfin and finlink.nlevel =  @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = finvardetail.idfin AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = FL1.idparent

	JOIN upb 
		ON upb.idupb=finvardetail.idupb 

	WHERE 	finvar.flagprevision = 'S'
		AND finvar.idfinvarstatus = 5
		AND finvar.variationkind <> 5
		AND finvar.adate BETWEEN @start AND @stop
		AND fin.ayear = @ayear
		AND  (( fin.flag & 1)=0)
		AND fin.nlevel = @nlevel
		and (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
		AND (upb.idupb like @idupb )

END
DECLARE @finname varchar(50)
SELECT @finname = description
	FROM incomephase
	WHERE nphase = @finphase

IF (@kind IN ( 'C','R'))
BEGIN
-- Movimenti di entrata / fase bilancio 
	INSERT INTO #income
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
		income.idinc,
		upb.idupb,
		upb.codeupb,
		upb.title,
		upb.printingorder,
		3,
		income.nphase,
		income.adate,
		@finname,
		income.ymov,
		income.nmov,
		income.description,
		income.idreg,
		incomeyear.amount
	FROM income
	JOIN incomeyear
		ON incomeyear.idinc = income.idinc
	JOIN incometotal
		ON incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear
	left outer JOIN finlink 
		ON finlink.idchild = incomeyear.idfin AND finlink.nlevel = @level_input
	JOIN upb 
		ON upb.idupb=incomeyear.idupb
	left outer JOIN finlink FL1
		ON FL1.idchild = incomeyear.idfin AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = FL1.idparent

	WHERE income.nphase = @finphase
		AND incomeyear.ayear = @ayear
		AND fin.ayear = @ayear
		AND  (( fin.flag & 1)=0)
		AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
		AND (( incometotal.flag & 1) = @kind_bit)
		AND (
		(@kind = 'C' AND income.adate BETWEEN @start AND @stop)
		OR 
		(@kind = 'R' AND DATEDIFF(DAY,@start,@firstday) = 0)
		)
		AND (upb.idupb like @idupb )

-- Variazione movimenti di entrata / fase bilancio
	INSERT INTO #income
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
		income.idinc,
		upb.idupb,upb.codeupb,upb.title,upb.printingorder,
		4,
		income.nphase,
		incomevar.adate,
		CASE
			WHEN @kind = 'C' 
			THEN 'Var.' + @finname
			WHEN @kind = 'R' 
			THEN 'Var.residuo ' + @finname 
		END,
		income.ymov,
		income.nmov,
		incomevar.nvar,
		incomevar.description,
		income.idreg,
		incomevar.amount
	FROM incomevar
	JOIN income
		ON income.idinc = incomevar.idinc
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
	JOIN incometotal
		ON incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear
	left outer JOIN finlink 
		ON finlink.idchild = incomeyear.idfin AND finlink.nlevel =  @level_input
	JOIN upb 
		ON upb.idupb = incomeyear.idupb
	left outer JOIN finlink FL1
		ON FL1.idchild = incomeyear.idfin AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = FL1.idparent

	WHERE incomevar.yvar = @ayear
		AND incomeyear.ayear = @ayear
		AND fin.ayear = @ayear
		AND income.nphase = @finphase
		AND (( fin.flag & 1)=0)
		AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
		AND  (( incometotal.flag & 1) = @kind_bit) 
		AND incomevar.adate BETWEEN @start AND @stop
		AND (upb.idupb like @idupb )
END	

DECLARE @phasecassa varchar(50)
SELECT @phasecassa = description FROM incomephase WHERE nphase = @maxincomephase
-- Movimenti di spesa / fase cassa
INSERT INTO #income
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
	HPV.idinc,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.printingorder,
	5,
	@maxincomephase,	
	HPV.competencydate,
	@phasecassa,
	HPV.ymov,
	HPV.nmov,
	HPV.npro,
	HPV.description,
	CASE
		WHEN HPV.doc IS NOT NULL AND 
			HPV.docdate IS NULL THEN
			'Inc. ' + HPV.doc
		WHEN HPV.doc IS NOT NULL AND
			HPV.docdate IS NOT NULL THEN
			'Inc. ' + HPV.doc + 
			' del ' + CONVERT(varchar(20), HPV.docdate, 105)
		ELSE
			(NULL)
	END,
	HPV.idreg,
	HPV.amount
FROM historyproceedsview HPV
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
	AND (   (@kind IN ('C', 'R') AND (HPV.totflag & 1)= @kind_bit  )   OR @kind = 'S')
	AND fin.ayear = @ayear
	AND (( fin.flag & 1)=0)
	AND fin.nlevel = @nlevel 
	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)

--	Variazione ai  Movimenti di spesa / fase cassa
IF (@cashvaliditykind <> 4)
BEGIN
	INSERT INTO #income
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
		nsubmov,
		ndoc,
		description,
		doc,
		idreg,
		cassaphase_amount
		)
	SELECT 
		isnull(FL1.idparent, fin.idfin),
		income.idinc,
		upb.idupb, upb.codeupb,upb.title,upb.printingorder,
		6,
		income.nphase,
		incomevar.adate,
		'Var.' + @phasecassa,
		income.ymov,
		income.nmov,
		incomevar.nvar,
		HPV.npro,
		incomevar.description,
		CASE
			WHEN incomevar.doc IS NOT NULL AND 
				incomevar.docdate IS NULL THEN
				'Inc. ' + incomevar.doc
			WHEN incomevar.doc IS NOT NULL AND
				incomevar.docdate IS NOT NULL THEN
				'Inc. ' + incomevar.doc + 
				' del ' + CONVERT(varchar(20), incomevar.docdate, 105)
			ELSE
		(NULL)
		END,
		income.idreg,
		incomevar.amount
	FROM incomevar
	JOIN income
		ON income.idinc = incomevar.idinc
	JOIN historyproceedsview HPV
		ON HPV.idinc = incomevar.idinc
	JOIN upb
		ON upb.idupb = HPV.idupb
	left outer JOIN finlink 
		ON finlink.idchild = HPV.idfin AND finlink.nlevel =  @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = HPV.idfin AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = FL1.idparent
	WHERE incomevar.yvar = @ayear
		AND incomevar.adate BETWEEN @start AND @stop
		AND isnull(incomevar.autokind,'') <>'22'
		AND (upb.idupb like @idupb)
		AND HPV.competencydate BETWEEN @start AND @stop AND HPV.ymov = @ayear
		AND fin.ayear = @ayear
		AND  (( fin.flag & 1)=0)
		AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin) 
		AND (   (@kind IN ('C', 'R') AND ((HPV.totflag & 1)= @kind_bit)  )   OR @kind = 'S')
END
	
UPDATE #income
SET 	emessiondate = proceedsview.adate,
	printeddate = 	proceedsview.printdate,
	trasmitteddate = proceedsview.transmissiondate,	
	transactiondate =  proceedsperformed.competencydate,
	annulmentdate = proceedsview.annulmentdate
FROM proceedsview
LEFT OUTER JOIN banktransaction
	ON banktransaction.kpro=proceedsview.kpro
	AND ( banktransaction.kind='C' OR banktransaction.kind IS NULL)	
LEFT OUTER JOIN proceedsperformed 
	ON proceedsperformed.npro=proceedsview.npro	
	AND proceedsperformed.ypro=proceedsview.ypro
WHERE #income.ndoc = proceedsview.npro
	AND proceedsview.ypro = @ayear

IF (@suppressifblank = 'N')
BEGIN
	INSERT INTO #income 
		(
			idfin,
			idupb,
			codeupb,
			upb,
			upbprintingorder,
			rowkind
			)
	SELECT 	isnull(FL1.idparent, fin.idfin),
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
		AND  (( fin.flag & 1)=0)
		AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
		and not exists (SELECT *
			FROM #income
			WHERE upb.idupb = #income.idupb 
				AND FL1.idparent = #income.idfin 
			)

END

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		UPDATE #income SET  
			upbprintingorder = (SELECT TOP 1 upbprintingorder
				FROM #income
				WHERE idupb = @idupboriginal),
			upb = (SELECT TOP 1 upb
				FROM #income
				WHERE idupb = @idupboriginal),
			idupb = @idupboriginal,
			codeupb =(SELECT TOP 1 codeupb
				FROM #income	
				WHERE idupb = @idupboriginal)
IF (@showupb <>'S') and (@idupboriginal = '%')
			UPDATE #income SET  
			upbprintingorder = null	,
			upb =  null,
			idupb = null,
			codeupb = null

-- se ho scelto di nascondere le voci di bilancio non utilizzate:
-- cancello le righe che hanno valori pari a zero 
-- e per cui non esistono variazioni di previzioni (rowkind=2) o movimenti di entrata (rowkind >= 3 )  
IF (@suppressifblank = 'S') AND @nlevel>2	--> se la stampa è x un livello sottostante la categoria cancella le righe
BEGIN
	DELETE FROM #income WHERE 
		ISNULL(initialprevision,0)=0 AND 
		ISNULL(finvar,0)=0 AND 
		ISNULL(finphase_amount,0)=0 AND 
		ISNULL(cassaphase_amount,0)=0 AND
		NOT EXISTS (select * from  #income i
				where #income.idupb=i.idupb AND 
				      #income.idfin=i.idfin AND 
					i.rowkind>1)
END

IF (@showupb <>'S')
	 SELECT 
		#income.idfin,
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
		sum(initialprevision) as initialprevision,
		sum(finvar) as finvar	,
		sum(finphase_amount) as finphase_amount,
		sum(cassaphase_amount) as cassaphase_amount,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@phasecassa as phasecassa,
		@finname as finname			
	FROM #income
	JOIN fin F
		ON F.idfin = #income.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #income.idreg
	GROUP BY codeupb,idupb,upb,upbprintingorder,
		F.printingorder,#income.idfin,idmov,
		F.codefin,F.title,
		rowkind,nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,ndoc,description,doc,
		annotations,REG.title,finvar,emessiondate,printeddate,
		trasmitteddate,transactiondate,annulmentdate			
	ORDER BY idupb ASC,F.printingorder ASC,
		operationdate ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nofficial ASC,
		nsubmov ASC
ELSE
	SELECT #income.idfin,idmov,
		@level as levelname,
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
	FROM #income
	JOIN fin F
		ON F.idfin = #income.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #income.idreg
	ORDER BY idupb ASC, F.printingorder ASC,
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
