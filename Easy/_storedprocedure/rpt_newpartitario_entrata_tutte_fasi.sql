
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


 
if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_newpartitario_entrata_tutte_fasi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_newpartitario_entrata_tutte_fasi]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE PROCEDURE rpt_newpartitario_entrata_tutte_fasi
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
--exec rpt_newpartitario_entrata_tutte_fasi 2011, 'R', '%', 3, {ts '2011-01-01 00:00:00'}, {ts '2011-12-31 00:00:00'}, 'N', 'N', 'S', 'N', NULL 
CREATE TABLE #previousincome
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
SELECT  @finphase = assessmentphasecode FROM config WHERE 	ayear = @ayear
SELECT  @finname = description FROM incomephase WHERE nphase = @finphase

DECLARE @maxincomephase tinyint 
DECLARE @phasecassa varchar(50)
SELECT  @maxincomephase = MAX(nphase) FROM 	incomephase
SELECT  @phasecassa = description FROM incomephase WHERE nphase = @maxincomephase


DECLARE @regphase tinyint 
SELECT  @regphase = incomeregphase FROM uniconfig

-- Seleziona la seconda/terza fase da inserire nella stampa 
DECLARE @secondphase varchar(50)
DECLARE @thirdphase varchar(50)

DECLARE @second tinyint
DECLARE @third tinyint
-- la seconda fase è quella successiva alla prima MA non deve essere quella del pagamento
SELECT  @secondphase = description, @second = nphase FROM incomephase WHERE nphase = @finphase+1 and nphase < @maxincomephase
-- la terza fase è quella successiva alla seconda MA non deve essere quella del pagamento
SELECT  @thirdphase = description, @third = nphase FROM incomephase  WHERE nphase =  @second + 1 and nphase < @maxincomephase


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

CREATE TABLE #income
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
	hierarchy varchar (50),
	tothierarchy varchar (50)
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
		INSERT INTO #income
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
		WHERE isnull(@fixedidupb,finyear.idupb) like @idupb 
			and fin.ayear = @ayear
			AND ((fin.flag&1)=0) 
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
			INSERT INTO #income	
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
				ON upb.idupb = finyear.idupb	
			left outer JOIN finlink
				ON finlink.idchild = finyear.idfin
				AND finlink.nlevel = @level_input
			WHERE isnull(@fixedidupb,finyear.idupb) like @idupb 
				AND fin.ayear = @ayear
				AND ((fin.flag&1)=0) 
				AND fin.nlevel = @nlevel
				AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)				
			GROUP by isnull(@fixedidupb, finyear.idupb),isnull(finlink.idparent, finyear.idfin)

			INSERT INTO #income
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
			WHERE isnull(@fixedidupb,finvardetail.idupb) like @idupb 
				AND finvar.flagprevision ='S'
				AND finvar.idfinvarstatus = 5
				AND finvar.variationkind <> 5
				AND finvar.adate < @start
				AND ((fin.flag&1)=0) 
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
			INSERT INTO #income
				(
				idfin,
				idupb,
				rowkind,
				operationdate,
				operationkind,
				initialprevision
				)
			SELECT isnull(finlink.idparent, incomeyear.idfin),
				   isnull(@fixedidupb,incomeyear.idupb),
					1,
					DATEADD(dd, -1, @start),
					'Tot.prec.',
					SUM(incomeyear.amount)
			FROM incomeyear
			JOIN income
				ON income.idinc = incomeyear.idinc
			JOIN incometotal
				ON  incomeyear.idinc = incometotal.idinc
				AND incomeyear.ayear = incometotal.ayear	
			JOIN upb
				ON incomeyear.idupb=upb.idupb	
			left outer JOIN finlink
				ON finlink.idchild = incomeyear.idfin
				AND finlink.nlevel = @nlevel
			WHERE  ((incometotal.flag&1) = @kind_bit)
				AND income.adate < @start
				AND income.nphase = @finphase
				AND isnull(@fixedidupb,incomeyear.idupb) like @idupb 
				AND (@idfin IS NULL OR isnull(finlink.idparent, incomeyear.idfin) = @idfin)	
				AND incomeyear.ayear = @ayear
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)				
			GROUP by isnull(@fixedidupb,incomeyear.idupb),isnull(finlink.idparent, incomeyear.idfin)
			END

	INSERT INTO #income
		(
		idfin,
		idupb,
		rowkind,
		operationdate,
		operationkind,
		finphase_amount
		)
	SELECT 
		isnull(finlink.idparent, incomeyear.idfin),
		isnull(@fixedidupb,incomeyear.idupb),
		1,
		DATEADD(dd, -1, @start),
		'Tot.prec.',
		SUM(incomeyear.amount)
	FROM incomeyear
	JOIN income
		ON income.idinc = incomeyear.idinc
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear	
	JOIN upb
		ON incomeyear.idupb=upb.idupb	
	left outer JOIN finlink
		ON finlink.idchild = incomeyear.idfin
		AND finlink.nlevel = @nlevel
	WHERE ((incometotal.flag&1) = @kind_bit)
		AND income.adate < @start
		AND income.nphase = @finphase
		AND incomeyear.ayear = @ayear
		AND isnull(@fixedidupb,incomeyear.idupb) like @idupb 
		AND (@idfin IS NULL OR isnull(finlink.idparent, incomeyear.idfin) = @idfin)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)		
	GROUP by isnull(@fixedidupb,incomeyear.idupb),isnull(finlink.idparent, incomeyear.idfin)

-- Esegue un'altra insert per 'finphase_amount' ma questa volta ci mette le var, perchè #income prevede solo il campo 'finphase_amount'
-- Nella select finale i valori saranno sommati

	INSERT INTO #income
		(
		idfin,
		idupb,
		rowkind,
		operationdate,
		operationkind,
		finphase_amount
		)
	SELECT 
		isnull(finlink.idparent, incomeyear.idfin),
		isnull(@fixedidupb,incomeyear.idupb),
		1,
		DATEADD(dd, -1, @start),
		'Tot.prec.',
		SUM(incomevar.amount)
	FROM incomevar
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
	JOIN income
		ON income.idinc = incomeyear.idinc
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear	
	JOIN upb
		ON incomeyear.idupb = upb.idupb	
	left outer JOIN finlink
		ON finlink.idchild = incomeyear.idfin
		AND finlink.nlevel = @nlevel
	WHERE incomevar.yvar = @ayear
		AND incomeyear.ayear = @ayear
		AND isnull(@fixedidupb,incomeyear.idupb) like @idupb 
		AND (@idfin IS NULL OR isnull(finlink.idparent, incomeyear.idfin) = @idfin)	
		AND ((incometotal.flag&1) = @kind_bit)
		AND income.nphase = @finphase
		AND incomevar.adate < @start
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)		
	GROUP by isnull(@fixedidupb,incomeyear.idupb),isnull(finlink.idparent, incomeyear.idfin)

	
	INSERT INTO #income
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
	FROM historyproceedsview HPV
	JOIN upb
		ON HPV.idupb = upb.idupb
	left outer JOIN finlink
		ON finlink.idchild = HPV.idfin	
		AND finlink.nlevel = @nlevel
	WHERE HPV.flagarrear = @kind 
		AND HPV.competencydate < @start
		AND HPV.ymov = @ayear
		AND isnull(@fixedidupb,HPV.idupb) like @idupb 
		AND (@idfin IS NULL OR isnull(finlink.idparent, HPV.idfin) = @idfin)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)		
	GROUP by isnull(@fixedidupb,HPV.idupb),isnull(finlink.idparent, HPV.idfin)

-- Esegue un'altra insert per 'cassaphase_amount' ma questa volta ci mette le var, perchè #income prevede solo il campo 'cassaphase_amount'
-- Nella select finale i valori saranno sommati

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #income
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
			SUM(incomevar.amount)
		FROM incomevar
		JOIN historyproceedsview HPV
			ON HPV.idinc = incomevar.idinc
		JOIN upb
			ON HPV.idupb = upb.idupb	
		left outer JOIN finlink
			ON finlink.idchild = HPV.idfin	
			AND finlink.nlevel = @nlevel
		WHERE HPV.ymov = @ayear
			AND isnull(@fixedidupb,HPV.idupb) like @idupb 
			AND (@idfin IS NULL OR isnull(finlink.idparent, HPV.idfin) = @idfin)	
			AND (HPV.flagarrear = @kind OR @kind = 'S')
			AND incomevar.yvar = @ayear
			AND incomevar.adate < @start
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
	INSERT INTO #income
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
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN upb
		ON finvardetail.idupb = upb.idupb	
	left outer JOIN finlink
		ON finlink.idchild = finvardetail.idfin	
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = finvardetail.idfin	
		AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = FL1.idparent
	WHERE finvar.flagprevision = 'S'	
		AND finvar.idfinvarstatus = 5
		AND finvar.variationkind <> 5
		AND finvar.adate BETWEEN @start AND @stop
		AND isnull(@fixedidupb, finvardetail.idupb) like @idupb 
		AND fin.ayear = @ayear
		AND ((fin.flag&1)=0) 
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)		

END

-- Movimenti di entrata / fase bilancio
	INSERT INTO #income(
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
		income.idinc,
		incomeyear.idupb,
		3,
		income.nphase,
		income.adate,
		@finname,
		income.ymov,
		income.nmov,
		income.description,
		income.idreg,
		incomeyear.amount,
		incometotal.available
		FROM income
		JOIN incomeyear
			ON incomeyear.idinc = income.idinc
		JOIN incometotal
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN upb
			ON incomeyear.idupb = upb.idupb	
		left outer JOIN finlink FL1
			ON FL1.idchild = incomeyear.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, incomeyear.idfin)
		left outer JOIN finlink
			ON finlink.idchild = fin.idfin	
			AND finlink.nlevel = @level_input
		WHERE income.nphase = @finphase
			AND ((@kind = 'C' AND income.adate BETWEEN @start AND @stop)
			OR (@kind = 'R' AND DATEPART(yy, @start) = @ayear AND DATEPART(mm, @start) = 1	AND DATEPART(dd, @start) = 1))
			AND incomeyear.ayear = @ayear
			AND (incometotal.flag&1)= @kind_bit
			AND fin.ayear = @ayear
			AND ((fin.flag&1)=0) 
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	
			AND isnull(@fixedidupb, incomeyear.idupb) like @idupb 
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

-- Variazione movimenti di entrata / fase bilancio
	INSERT INTO #income
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
		income.idinc,
		incomeyear.idupb,
		4,
		income.nphase,
		incomevar.adate,
		CASE
			WHEN @kind = 'C' 
			THEN 'Var.' + @finname
			WHEN @kind = 'R' 
			THEN 'Var.residuo '+@finname 
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
		ON incometotal.idinc = incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	JOIN upb
		ON incomeyear.idupb = upb.idupb	
	left outer JOIN finlink
		ON finlink.idchild = incomeyear.idfin	
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = incomeyear.idfin	
		AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = FL1.idparent	
	WHERE incomevar.yvar = @ayear
		AND incomevar.adate BETWEEN @start AND @stop
		AND isnull(@fixedidupb, incomeyear.idupb) like @idupb 
		AND income.nphase = @finphase
		AND incomeyear.ayear = @ayear
		AND (incometotal.flag&1)= @kind_bit
		AND fin.ayear = @ayear
		AND ((fin.flag&1)=0)
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
---	CILCLO WHILE
--------------------------
DECLARE @i int
SELECT @i = CONVERT(int,@finphase)
WHILE @i < (@maxincomephase -1)
BEGIN
	SELECT @i = @i + 1
	IF (@kind = 'C') 
	BEGIN
		INSERT INTO #income
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
			income.idinc,
			incomeyear.idupb 							,
			5+(@i-@finphase-1)*2,
			income.nphase,
			income.adate,
			(SELECT  description
					FROM incomephase
					WHERE nphase = @i),
			income.ymov,
			income.nmov,
			income.description,
			income.idreg,
			incomeyear.amount
		FROM income
		JOIN incomeyear
			ON incomeyear.idinc = income.idinc
		JOIN incometotal
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN upb
			ON incomeyear.idupb = upb.idupb	
		left outer JOIN finlink
			ON finlink.idchild = incomeyear.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = incomeyear.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = FL1.idparent	
		WHERE  isnull(@fixedidupb, incomeyear.idupb) like @idupb 
			AND incomeyear.ayear = @ayear
			AND (incometotal.flag&1) = @kind_bit
			AND income.nphase = @i
			AND fin.ayear = @ayear
			AND ((fin.flag&1)=0)
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			AND (income.adate BETWEEN @start AND @stop) --> @kind C
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	END		  
	IF (@kind = 'R') 
	BEGIN
		INSERT INTO #income
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
			income.idinc,
			incomeyear.idupb 							,
			5+(@i-@finphase-1)*2,
			income.nphase,
			income.adate,
			(SELECT  description
					FROM incomephase
					WHERE nphase = @i),
			income.ymov,
			income.nmov,
			income.description,
			income.idreg,
			incomeyear.amount
		FROM income
		JOIN incomeyear
			ON incomeyear.idinc = income.idinc
		JOIN incometotal
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN upb
			ON incomeyear.idupb = upb.idupb
		left outer JOIN finlink
			ON finlink.idchild = incomeyear.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = incomeyear.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = FL1.idparent	
		WHERE  isnull(@fixedidupb, incomeyear.idupb) like @idupb 
			AND incomeyear.ayear = @ayear
			AND (incometotal.flag&1) = @kind_bit
			AND income.nphase = @i
			AND fin.ayear = @ayear
			AND ((fin.flag&1)=0)
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			AND ( DATEDIFF(DAY,@start,@firstday) = 0)	--> @kind R
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	END

	INSERT INTO #income
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
		income.idinc,
		incomeyear.idupb 							,
		6+(@i-@finphase-1)*2,
		income.nphase,
		incomevar.adate,
		'Var.' + (SELECT  description
				FROM incomephase
				WHERE nphase = @i),
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
		ON incometotal.idinc = incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	JOIN upb
		ON incomeyear.idupb = upb.idupb	
	left outer JOIN finlink
		ON finlink.idchild = incomeyear.idfin	
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = incomeyear.idfin	
		AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = FL1.idparent	
	WHERE  isnull(@fixedidupb, incomeyear.idupb) like @idupb 
		AND income.nphase = @i
		AND fin.ayear = @ayear
		AND ((fin.flag&1)=0) 
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
		AND incomevar.yvar = @ayear
		AND incomeyear.ayear = @ayear
		AND isnull(incomevar.autokind,'') <>'22'
		AND (incometotal.flag&1) = @kind_bit
		AND incomevar.adate BETWEEN @start AND @stop
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

	CONTINUE
END
---	FINE CILCLO WHILE
--------------------------

-- Movimenti di entrata / fase cassa
INSERT INTO #income
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
	HPV.idinc,
	HPV.idupb,
	15,
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
	AND isnull(@fixedidupb, HPV.idupb) like @idupb 
	AND HPV.ymov = @ayear
	AND HPV.flagarrear = @kind
	AND fin.ayear = @ayear
	AND ((fin.flag&1)=0) -- entrata
	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
-- Variazione ai Movimenti di entrata / fase cassa
IF (@cashvaliditykind <> 4)
BEGIN

	INSERT INTO #income
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
		income.idinc,
		HPV.idupb,
		20,
		income.nphase,
		incomevar.adate,
		'Var.' +@phasecassa,
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
		JOIN historyproceedsview HPV
			ON HPV.idinc = incomevar.idinc
		JOIN upb
			ON HPV.idupb = upb.idupb	
		JOIN income
			ON income.idinc = incomevar.idinc
		left outer JOIN finlink
			ON finlink.idchild = HPV.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = HPV.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = FL1.idparent
		WHERE incomevar.yvar = @ayear
			AND incomevar.adate BETWEEN @start AND @stop
			AND isnull(incomevar.autokind,'') <>'22'
			AND  isnull(@fixedidupb, HPV.idupb) like @idupb 
			AND HPV.ymov = @ayear
			AND fin.ayear = @ayear
			AND ((fin.flag&1)=0) -- entrata
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
UPDATE #income 
SET 
	hierarchy = convert(varchar(4),E1.ymov) + '/' + Replicate('0',6-len(convert(varchar(6),E1.nmov)))+ convert(varchar(6),E1.nmov),
	tothierarchy = 
	convert(varchar(4),E1.ymov) + '/' + Replicate('0',6-len(convert(varchar(6),E1.nmov)))+ convert(varchar(6),E1.nmov)
	+' '+ convert(varchar(4),isnull(E2.ymov,'')) + '/' + convert(varchar(6),isnull(E2.nmov,''))
	+' '+ convert(varchar(4),isnull(E3.ymov,'')) + '/' + convert(varchar(6),isnull(E3.nmov,''))
	+' '+ convert(varchar(4),isnull(E4.ymov,'')) + '/' + convert(varchar(6),isnull(E4.nmov,''))
FROM income
JOIN incomelink EL1
	ON EL1.idchild = income.idinc  AND EL1.nlevel = 1
LEFT OUTER JOIN incomelink EL2
	ON EL2.idchild = income.idinc  AND EL2.nlevel = 2
LEFT OUTER JOIN incomelink EL3
	ON EL3.idchild = income.idinc  AND EL3.nlevel = 3
LEFT OUTER JOIN incomelink EL4
	ON EL4.idchild = income.idinc  AND EL4.nlevel = 4
LEFT OUTER JOIN income E1
	ON E1.idinc = EL1.idparent
LEFT OUTER JOIN income E2
	ON E2.idinc = EL2.idparent
LEFT OUTER JOIN income E4
	ON E4.idinc = EL4.idparent
LEFT OUTER JOIN income E3
	ON E3.idinc = EL3.idparent
WHERE  EL1.idchild = #income.idmov

-- Qualora una fase abbia la stessa descrizione della fase precedente, viene rimossa la descrizione per non sprecare spazio nel report.

UPDATE #income SET description = null
	FROM income
	JOIN incomelink
		ON income.idinc = incomelink.idparent 
	WHERE #income.idmov = incomelink.idchild AND incomelink.nlevel = #income.nphase-1 
		AND income.description = #income.description

UPDATE #income
	SET 	emessiondate = paymentview.adate,
		printeddate = 	paymentview.printdate,
		trasmitteddate = paymentview.transmissiondate,	
		transactiondate = paymentperformed.competencydate,
		annulmentdate = paymentview.annulmentdate
	FROM paymentview
	LEFT OUTER JOIN banktransaction
		ON banktransaction.kpay=paymentview.kpay	
		AND (banktransaction.kind='C' OR banktransaction.kind IS NULL)
	LEFT OUTER JOIN  paymentperformed 
		ON paymentperformed.npay=paymentview.npay
		AND paymentperformed.ypay=paymentview.ypay
	WHERE #income.ndoc = paymentview.npay and paymentview.ypay=@ayear


IF (@suppressifblank = 'N') 
BEGIN
--se ho scelto di vedere l'upb inserisco le coppie upb/bilancio altrimenti inserisco solo il bilanico non utilizzato
	IF ( (@showupb <>'S') and (@idupboriginal = '%'))
	Begin
		INSERT INTO #income(
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
			AND ((fin.flag&1) = 0 ) -- entrata
			AND fin.nlevel = @nlevel
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			and not exists (SELECT *
				FROM #income
				WHERE fin.idfin = #income.idfin )
		End
	Else
		Begin
		INSERT INTO #income 
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
			AND ((fin.flag&1)=0) -- entrata
			AND fin.nlevel = @nlevel
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			and not exists (SELECT *
				FROM #income
				WHERE upb.idupb = #income.idupb 
				AND fin.idfin = #income.idfin )
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
	DELETE FROM #income WHERE 
		ISNULL(initialprevision,0)=0 
		AND ISNULL(finvar,0)=0 
		AND ISNULL(finphase_amount,0)=0 
		AND ISNULL(cassaphase_amount,0)=0 
		AND	NOT EXISTS (select * from  #income i
				where #income.idupb = i.idupb AND 
				      #income.idfin=i.idfin AND 
					i.rowkind>1)
END

IF (@showupb = 'S') 
BEGIN
	SELECT #income.idfin,
		idmov,
		@level as levelname,
		F.codefin,
		F.printingorder as finprintingorder,
		F.title,
		U.codeupb,
		#income.idupb,
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
		@phasecassa as phasecassa,
		hierarchy,tothierarchy
 	FROM #income	
	JOIN fin F
		ON F.idfin = #income.idfin
	JOIN upb U
		ON U.idupb = #income.idupb	
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #income.idreg	
	GROUP BY U.codeupb,#income.idupb,U.title,U.printingorder,
		hierarchy,tothierarchy,
		F.printingorder,#income.idfin,idmov,F.codefin,F.title,
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
		#income.idfin,
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
		@phasecassa as phasecassa,
		hierarchy,
		tothierarchy
	FROM #income
	JOIN fin F
		ON F.idfin = #income.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #income.idreg  
	GROUP BY hierarchy,tothierarchy,
		F.printingorder,#income.idfin,idmov,F.codefin,F.title,
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





exec rpt_newpartitario_entrata_tutte_fasi 2012, 'C', '%', 3, {ts '2010-01-05 00:00:00'}, {ts '2012-12-31 00:00:00'}, 'N', 'N', 'S', 'N', 14242 ,null,null,null,null,null
