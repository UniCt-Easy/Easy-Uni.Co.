
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_entrate_intestazione_respons]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_entrate_intestazione_respons]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE     PROCEDURE [rpt_partitario_entrate_intestazione_respons]
	@ayear int,
	@idupb	varchar(36),
	@codelevel tinyint,
	@showupb char(1),
	@showchildupb char(1),
	@idman int,
	@suppressifblank char(1),
	@codefin		varchar(50),
	@start datetime,
	@stop datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
BEGIN
/* Versione 1.0.7 del 19/10/2007 ultima modifica: SARA */

DECLARE @idfin int
IF (@codefin IS NULL OR @codefin = '' OR @codefin = '%')
	BEGIN
		SET @idfin = null	
	END
Else
	BEGIN
	   	SET @idfin = (select idfin 
				from fin 
				where codefin = @codefin 
				and ayear=@ayear 
				and (fin.flag&1)=0) -- Entrata
	END

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@codelevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@codelevel < @level_input ) AND (@idfin is not null)
	BEGIN
	SET  @codelevel = @level_input
	END

DECLARE @idupboriginal 	varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END

DECLARE @levelusable tinyint
SELECT 	@levelusable = MIN(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear
AND 	(flag&2)<>0



DECLARE @nfinphase tinyint
SELECT  @nfinphase = assessmentphasecode
FROM 	config
WHERE 	ayear = @ayear
IF (@nfinphase IS NULL)
BEGIN
	SELECT @nfinphase = incomefinphase
	FROM uniconfig
END	
DECLARE @maxincomephase tinyint
SELECT  @maxincomephase = MAX(nphase)
FROM   	incomephase 


CREATE TABLE #income
(
	idfin int,
	codeupb	varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
	nphase tinyint,
	rowkind int,
	initialprevisioncomp decimal(19,2),
	initialprevisioncash decimal(19,2),
	finvar_prevision decimal(19,2),
	finvar_secondaryprev decimal(19,2),
	assessment_C decimal(19,2),
	var_assessment_C decimal(19,2),
	proceed_C decimal(19,2),
	var_proceed_C decimal(19,2),
	assessment_R decimal(19,2),
	var_assessment_R decimal(19,2),
	proceed_R decimal(19,2),
	var_proceed_R decimal(19,2),
	adate datetime,
	description varchar(300),
	idreg int,	
	nassessment int,
	ymovassessment int,
	nmovassessment int,
	assessment_amount decimal(19,2),
	nproceed int,
	ymovproceed int,
	nmovproceed int,
	proceed_amount decimal(19,2),
	npro int,
	flagarrear char(1),
	reportdate datetime,
	ayear int,
	idassessment varchar(20),
	idman int,
	total_assessment_C decimal(19,2),
	total_var_assessment_C decimal(19,2),
	total_assessment_R decimal(19,2),
	total_var_assessment_R decimal(19,2),
	total_proceed_C decimal(19,2),
	total_var_proceed_C decimal(19,2),
	total_proceed_R decimal(19,2),
	total_var_proceed_R decimal(19,2)   
	-- N.B.: non serve calcolare i totali relativi alle previsioni e alle var di previsione 
	-- in quanto sono gia calcolati indipendentemente dal responsabile.
)
INSERT INTO #income	
(
	idfin,
	idupb,
	rowkind, 
	adate, 
	description, 
	idreg,
	nassessment, 
	ymovassessment,
	nmovassessment,
	assessment_amount,
	nproceed, 
	ymovproceed,
	nmovproceed,
	proceed_amount,
	npro,
	flagarrear,
	idassessment,
	idman
)
SELECT 
	isnull(FL.idparent, incomeyear.idfin),
	upb.idupb,
	income.nphase,
	income.adate,
	case isnull(income.doc,'') when '' then income.description 
	else  income.description + ' (Doc. ' + isnull(Convert (varchar(20),income.doc),'') + ' del '+ 
		isnull(Convert (varchar(2),datepart(dd,income.docdate)),'')+ ' '+ isnull(Convert (varchar(2),datepart(mm,income.docdate)),'')+
		' '+ isnull(Convert (varchar(4),datepart(yy,income.docdate)),'')+')'
	end,
	income.idreg,
	I2.idinc, --Accertamento
	I2.ymov,
	I2.nmov,  
	incomeyear.amount,
	I3.idinc, --Incasso
	I3.ymov,
	i3.nmov, 
	incomeyear.amount,
	proceeds.npro,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	I2.idinc, --Accertamento
	income.idman
FROM incomeyear
JOIN income
	ON incomeyear.idinc = income.idinc 
JOIN upb 
	ON upb.idupb=incomeyear.idupb
JOIN fin 
	ON incomeyear.idfin  = fin.idfin 
	AND incomeyear.ayear = fin.ayear
JOIN incometotal
	ON  incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear	
JOIN incomelink IL2
	ON IL2.idchild = income.idinc  AND IL2.nlevel = @nfinphase	
LEFT  OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin  
	AND FL.nlevel = @codelevel
LEFT OUTER JOIN finlink FL1
	ON FL1.idchild = incomeyear.idfin  
	AND FL1.nlevel = @level_input
LEFT  OUTER JOIN incomelast
	ON incomelast.idinc = income.idinc
LEFT  OUTER JOIN proceeds
	ON incomelast.kpro = proceeds.kpro
LEFT OUTER JOIN income I2
	ON I2.idinc = IL2.idparent
LEFT OUTER JOIN incomelink IL3
	ON IL3.idchild = income.idinc  AND IL3.nlevel = @maxincomephase
LEFT OUTER JOIN income I3
	ON I3.idinc = IL3.idparent
WHERE ((fin.flag&1)=0) -- = 'E'	
	AND incomeyear.ayear = @ayear
	AND (@idfin IS NULL OR  isnull(FL1.idparent, incomeyear.idfin) = @idfin )		
	AND income.adate  between @start and @stop
	AND ((income.idman  = @idman) OR (@idman is null and income.idman is not null))	
	AND (income.nphase IN  (@nfinphase, @maxincomephase))
	AND (upb.idupb like @idupb ) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)




-- Prende le coppie fin/upb che non sono state movimentate
IF (@suppressifblank = 'S')
BEGIN
	INSERT INTO #income
	(
		idfin,
		idupb,
		idman
		)
	SELECT DISTINCT
		ISNULL(FL2.idparent, FD.idfin),
		upb.idupb,
		upb.idman
	FROM fin
	JOIN finlink FL1
		ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
	JOIN finlink FL2
		ON FL2.idchild = fin.idfin AND FL2.nlevel = @codelevel
	JOIN finlink FL3
		ON FL3.idparent = fin.idfin
	join finvardetail FD 
		ON FD.idfin = FL3.idchild
	join finvar FVAR
		ON FVAR.yvar = FD.yvar
		AND FVAR.nvar = FD.nvar
	JOIN upb 
		on FD.idupb=upb.idupb
	WHERE ((fin.flag&1)=0) -- Entrata
		AND (@idfin IS NULL OR  isnull(FL1.idparent, FD.idfin) = @idfin )	
		AND (upb.idupb like @idupb ) 
		AND ((upb.idman  = @idman) OR (@idman is null and upb.idman is not null))	
		AND fin.ayear = @ayear
		AND FVAR.idfinvarstatus = 5
		AND NOT EXISTS (SELECT *
			FROM #income
			WHERE upb.idupb = #income.idupb 
			AND FL2.idparent = #income.idfin
			AND upb.idman   = #income.idman )	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	
	INSERT INTO #income
		(
		idfin,
		idupb,
		idman
		)	--> Prende quelli non movimentati 2^ parte
	SELECT distinct
		isnull(FL2.idparent, EY.idfin),
		upb.idupb,
		upb.idman
	FROM fin 
	JOIN finlink FL1
		ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
	JOIN finlink FL2
		ON FL2.idchild = fin.idfin AND FL2.nlevel = @codelevel
	JOIN finlink FL3
		ON FL3.idparent = fin.idfin
	JOIN incomeyear EY 
		on EY.idfin = FL3.idchild and EY.ayear = fin.ayear
	JOIN upb 
		on EY.idupb=upb.idupb
	WHERE ((fin.flag&1)=0) -- Entrata
		AND (@idfin IS NULL OR isnull(FL1.idparent, EY.idfin) = @idfin)	
		AND (upb.idupb like @idupb ) 
		AND ((upb.idman  = @idman) OR (@idman is null and upb.idman is not null))	
		AND fin.ayear = @ayear
		AND NOT EXISTS (SELECT *
			FROM #income
			WHERE upb.idupb = #income.idupb 
			AND FL2.idparent = #income.idfin
			AND upb.idman = #income.idman)
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	
	INSERT INTO #income
		(
		idfin,
		idupb,
		idman
		)	--> Prende quelli non movimentati 3^ parte
	SELECT distinct
		isnull(FL2.idparent, FY.idfin),
		upb.idupb,
		upb.idman
	FROM fin 
	JOIN finlink FL1
		ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
	JOIN finlink FL2
		ON FL2.idchild = fin.idfin AND FL2.nlevel = @codelevel
	JOIN finlink FL3
		ON FL3.idparent = fin.idfin
	join finyear FY 
		on FY.idfin = FL3.idchild   
		and FY.ayear=fin.ayear and
			(isnull(FY.previousprevision,0) <> 0 OR
			 isnull(FY.prevision,0) <> 0 OR
			 isnull(FY.previoussecondaryprev,0) <> 0 OR
			 isnull(FY.secondaryprev,0) <> 0 OR
			 isnull(FY.previousarrears,0) <> 0 OR
			 isnull(FY.currentarrears,0) <> 0					 
			)
	JOIN upb 
		on FY.idupb=upb.idupb
	WHERE ((fin.flag&1)=0) -- Entrata
		AND (@idfin IS NULL OR isnull(FL1.idparent, FY.idfin) = @idfin)	
		AND (upb.idupb like @idupb ) 
		AND ((upb.idman  = @idman) OR (@idman is null and upb.idman is not null))	
		AND fin.ayear = @ayear
		AND NOT EXISTS (SELECT *
			FROM #income
			WHERE upb.idupb = #income.idupb 
			AND FL2.idparent = #income.idfin
			AND upb.idman = #income.idman)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

END
ELSE
BEGIN
	INSERT INTO #income
	(
		idfin,
		idupb,
		idman
		)
	SELECT 
		fin.idfin,
		upb.idupb,
		upb.idman
	FROM 	fin CROSS JOIN upb 
	LEFT OUTER JOIN finlink FL
		ON FL.idchild = fin.idfin  and FL.nlevel = @level_input
	WHERE 	((fin.flag&1)=0) -- = 'E'	
		AND (@idfin IS NULL OR FL.idparent = @idfin)	
		AND (upb.idupb like @idupb ) 
		AND ((upb.idman  = @idman) OR (@idman is null and upb.idman is not null))	
		AND fin.nlevel = @codelevel
		AND fin.ayear = @ayear
		and not exists (SELECT *
			FROM #income
			WHERE upb.idupb = #income.idupb 
			AND fin.idfin = #income.idfin
			and upb.idman = #income.idman )	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
END



CREATE TABLE #assessment_C
	(
	idfin int,
	idupb varchar(36),
	idman int,	
	amount decimal(19,2)					 
	)
INSERT INTO #assessment_C	
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT
	ISNULL(finlink.idparent,incomeyear.idfin),
	incomeyear.idupb,
	income.idman,
	SUM(ISNULL(incomeyear.amount, 0))
FROM income
JOIN incomeyear
	ON incomeyear.idinc = income.idinc 
	AND incomeyear.ayear = @ayear
JOIN upb
	ON incomeyear.idupb = upb.idupb
JOIN incometotal 
	ON  incomeyear.idinc = incometotal.idinc 
	AND incomeyear.ayear = incometotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = incomeyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin 
	AND FL.nlevel = @level_input
WHERE income.adate between @start and @stop
	AND income.nphase = @nfinphase
	AND ((incometotal.flag&1)=0) --Competenza
	AND (@idfin IS NULL OR isnull(FL.idparent,incomeyear.idfin) = @idfin)	
	AND (incomeyear.idupb like @idupb) 
	AND ((income.idman  = @idman) OR (@idman is null and income.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin),income.idman

CREATE TABLE #var_assessment_C
    (
	idfin  int,
	idupb  varchar(36),      
	idman  int,	
	amount decimal(19,2)					 
    )
INSERT INTO #var_assessment_C	
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,incomeyear.idfin),
	incomeyear.idupb,
	income.idman,
	SUM(ISNULL(incomevar.amount, 0))
FROM incomevar
JOIN incomeyear
	ON incomeyear.idinc = incomevar.idinc 
	AND incomeyear.ayear = @ayear
JOIN upb
	ON incomeyear.idupb = upb.idupb
JOIN income 
	ON income.idinc = incomeyear.idinc
JOIN incometotal 
	ON  incomeyear.idinc = incometotal.idinc AND
	incomeyear.ayear = incometotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = incomeyear.idfin AND 
	finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin AND 
	FL.nlevel = @level_input
WHERE incomevar.yvar = @ayear
	AND income.nphase= @nfinphase
	AND ((incometotal.flag&1)=0) --Competenza
	AND incomevar.adate between @start and @stop
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,incomeyear.idfin) = @idfin)	
	AND (incomeyear.idupb like @idupb) 
	AND ((income.idman  = @idman) OR (@idman is null and income.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin),income.idman

CREATE TABLE #assessment_R
    (
	idfin  int,
	idupb  varchar(36),     
	idman  int,
	amount decimal(19,2)					 
    )
INSERT INTO #assessment_R	
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT
	ISNULL(finlink.idparent,incomeyear.idfin),
	incomeyear.idupb,
	income.idman,
	SUM(ISNULL(incomeyear.amount, 0))
FROM incomeyear
JOIN income
	ON income.idinc = incomeyear.idinc AND incomeyear.ayear = @ayear
JOIN upb
	ON incomeyear.idupb = upb.idupb
JOIN incometotal 
	ON  incomeyear.idinc = incometotal.idinc AND
	incomeyear.ayear = incometotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = incomeyear.idfin AND 
	finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin 
	AND FL.nlevel = @level_input
WHERE  ((incometotal.flag&1)=1) --Residuo
	AND income.nphase= @nfinphase
	AND income.adate between @start and @stop
	AND (@idfin IS NULL OR  isnull(FL.idparent,incomeyear.idfin) = @idfin)	
	AND (incomeyear.idupb like @idupb) 
	AND ((income.idman  = @idman) OR (@idman is null and income.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin),income.idman


CREATE TABLE #var_assessment_R
    (     
	idfin  int,
	idupb  varchar(36),     
	idman  int,	
	amount decimal(19,2)					 
    )
INSERT INTO #var_assessment_R
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,incomeyear.idinc),
	incomeyear.idupb,
	income.idman,	
	SUM(ISNULL(incomevar.amount, 0))
FROM incomevar
JOIN incomeyear
	ON incomeyear.idinc = incomevar.idinc 
	AND incomeyear.ayear = @ayear
JOIN upb
	ON incomeyear.idupb = upb.idupb
JOIN income
	ON income.idinc = incomeyear.idinc 
JOIN incometotal 
	ON  incomeyear.idinc = incometotal.idinc AND
	incomeyear.ayear = incometotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = incomeyear.idfin AND 
	finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin AND 
	FL.nlevel = @level_input
WHERE incomevar.yvar = @ayear
	AND ((incometotal.flag&1)=1) --Residuo
	AND income.nphase= @nfinphase
	AND incomevar.adate between @start and @stop
	AND (@idfin IS NULL 
	OR   isnull(FL.idparent,incomeyear.idinc) = @idfin)	
	AND (incomeyear.idupb like @idupb) 
	AND ((income.idman  = @idman) OR (@idman is null and income.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idinc),income.idman

CREATE TABLE #proceed_C
    (
	idfin  int,
	idupb  varchar(36),     
	idman  int,	
	amount decimal(19,2)					 
    )
INSERT INTO #proceed_C	
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT
	ISNULL(finlink.idparent,incomeyear.idinc),
	incomeyear.idupb,
	income.idman,
	SUM(ISNULL(proceedsemitted.amount,0))
FROM incomeyear
JOIN income 
	ON income.idinc = incomeyear.idinc 
JOIN upb
	ON incomeyear.idupb = upb.idupb
JOIN proceedsemitted
	ON incomeyear.idinc = proceedsemitted.idinc 
JOIN incometotal 
	ON  incomeyear.idinc = incometotal.idinc AND
	incomeyear.ayear = incometotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = incomeyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin AND 
	FL.nlevel = @level_input
WHERE proceedsemitted.competencydate between @start and @stop
	AND ((incometotal.flag&1)=0) --Competenza
	AND incomeyear.ayear = @ayear
	AND (@idfin IS NULL OR  isnull(FL.idparent,incomeyear.idinc) = @idfin)	
	AND (incomeyear.idupb like @idupb) 
	AND ((income.idman  = @idman) OR (@idman is null and income.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idinc),income.idman

CREATE TABLE #proceed_R
    (
	idfin  int,
	idupb  varchar(36),     
	idman  int,	
	amount decimal(19,2)					 
    )
INSERT INTO #proceed_R	
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT
	ISNULL(finlink.idparent,incomeyear.idfin),
	incomeyear.idupb,
	income.idman,	
	SUM(ISNULL(proceedsemitted.amount,0))
FROM proceedsemitted
JOIN incomeyear
	ON incomeyear.idinc = proceedsemitted.idinc 
	AND incomeyear.ayear = @ayear
JOIN upb
	ON incomeyear.idupb = upb.idupb
JOIN income 
	ON income.idinc = incomeyear.idinc 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = incomeyear.idfin AND 
	finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin AND 
	FL.nlevel = @level_input
WHERE proceedsemitted.competencydate between @start and @stop
	AND proceedsemitted.flagarrear ='R'
	AND income.nphase= @maxincomephase
	AND (@idfin IS NULL OR  isnull(FL.idparent,incomeyear.idfin) = @idfin)	 
	AND (incomeyear.idupb like @idupb) 
	AND ((income.idman  = @idman) OR  (@idman is null and income.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin),income.idman
CREATE TABLE #var_proceed_C
    (
	idfin int,
	idupb varchar(36),     
	idman int,	
	amount decimal(19,2)					 
    )
INSERT INTO #var_proceed_C	
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,incomeyear.idfin),
	incomeyear.idupb,
	income.idman,	
	SUM(ISNULL(incomevar.amount, 0))
FROM incomevar
JOIN incomeyear
	ON incomeyear.idinc = incomevar.idinc 
	AND incomeyear.ayear = @ayear
JOIN upb
	ON incomeyear.idupb = upb.idupb
JOIN income 
	ON income.idinc = incomeyear.idinc
JOIN incometotal 
	ON  incomeyear.idinc = incometotal.idinc AND
	incomeyear.idinc = incometotal.idinc 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = incomeyear.idfin AND 
	finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin AND 
	FL.nlevel = @level_input
WHERE incomevar.yvar = @ayear
	AND ((incometotal.flag&1)=0) --Competenza
	AND income.nphase= @maxincomephase
	AND incomevar.adate between @start and @stop
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,incomeyear.idfin) = @idfin)	
	AND (incomeyear.idupb like @idupb) 
	AND incomevar.idinc IN (select idinc from proceedsemitted)
	AND ((income.idman  = @idman) OR (@idman is null and income.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin),income.idman

CREATE TABLE #var_proceed_R
    (
	idfin  int,
	idupb  varchar(36),     
	idman  int,	
	amount decimal(19,2)					
    )
INSERT INTO #var_proceed_R
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,incomeyear.idfin),
	incomeyear.idupb,
	income.idman,	
	SUM(ISNULL(incomevar.amount,0))
FROM incomevar
JOIN incomeyear
	ON incomeyear.idinc = incomevar.idinc 
JOIN upb
	ON incomeyear.idupb = upb.idupb
JOIN income ON income.idinc = incomeyear.idinc	
JOIN incometotal 
	ON  incomeyear.idinc = incometotal.idinc AND
	incomeyear.ayear = incometotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = incomeyear.idfin AND 
	finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin AND 
	FL.nlevel = @level_input
WHERE incomevar.yvar = @ayear
	AND ((incometotal.flag&1)=1) --Residuo
	AND incomeyear.ayear = @ayear
	AND incomevar.adate between @start and @stop
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,incomeyear.idfin) = @idfin)	
	AND (incomeyear.idupb like @idupb) 
	AND incomevar.idinc IN (select idinc from proceedsemitted)
	AND ((income.idman  = @idman) OR (@idman is null and income.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin),income.idman
UPDATE #income
SET
	codeupb = (select upb.codeupb from upb  where upb.idupb = #income.idupb),
	upb = (select upb.title from upb where upb.idupb = #income.idupb),
	upbprintingorder = (select upb.printingorder from upb  where upb.idupb = #income.idupb)
IF (@showupb ='S') 
BEGIN
	UPDATE #income
	SET
	finvar_prevision = ISNULL((SELECT SUM(ISNULL(finvardetail.amount,0))
				FROM finvardetail
				JOIN finvar
					ON finvar.yvar = finvardetail.yvar
					AND finvar.nvar = finvardetail.nvar
				LEFT OUTER JOIN finlink 
					ON finlink.idchild = finvardetail.idfin 
					AND finlink.nlevel = @codelevel
				WHERE finvar.flagprevision ='S'	
					AND finvar.idfinvarstatus = 5
					AND finvar.variationkind <> 5
					AND finvar.adate between @start and @stop
					AND finvar.yvar = @ayear
					AND ISNULL(finlink.idparent,finvardetail.idfin) = #income.idfin 
					AND finvardetail.idupb = #income.idupb), 0),
	finvar_secondaryprev = ISNULL((SELECT SUM(ISNULL(finvardetail.amount,0))
				FROM finvardetail
				JOIN finvar
					ON finvar.yvar = finvardetail.yvar
					AND finvar.nvar = finvardetail.nvar
				LEFT OUTER JOIN finlink 
					ON finlink.idchild = finvardetail.idfin 
					AND finlink.nlevel = @codelevel
				WHERE finvar.flagsecondaryprev ='S'	
					AND finvar.idfinvarstatus = 5
					AND finvar.variationkind <> 5
					AND finvar.adate between @start and @stop
					AND finvar.yvar = @ayear
					AND ISNULL(finlink.idparent,finvardetail.idfin) = #income.idfin 
					AND finvardetail.idupb = #income.idupb), 0),
	assessment_C =ISNULL((SELECT #assessment_C.amount 
				FROM #assessment_C
				WHERE #assessment_C.idupb = #income.idupb and
					#assessment_C.idfin = #income.idfin and 
					#assessment_C.idman = #income.idman), 0),
	var_assessment_C =ISNULL((SELECT #var_assessment_C.amount 
				FROM #var_assessment_C
				WHERE #var_assessment_C.idupb = #income.idupb and
					#var_assessment_C.idfin = #income.idfin and 
					#var_assessment_C.idman = #income.idman), 0),
	proceed_C =ISNULL((SELECT #proceed_C.amount 
				FROM #proceed_C
				WHERE #proceed_C.idupb = #income.idupb and 
					#proceed_C.idfin = #income.idfin and 
					#proceed_C.idman = #income.idman), 0),
	var_proceed_C =ISNULL((SELECT #var_proceed_C.amount 
				FROM #var_proceed_C
				WHERE #var_proceed_C.idupb = #income.idupb and 
					#var_proceed_C.idfin = #income.idfin and 
					#var_proceed_C.idman = #income.idman), 0),
  	assessment_R =ISNULL((SELECT #assessment_R.amount 
				FROM #assessment_R
				WHERE #assessment_R.idfin = #income.idfin and 
					#assessment_R.idupb = #income.idupb and 
					#assessment_R.idman = #income.idman), 0),
	var_assessment_R =ISNULL((SELECT #var_assessment_R.amount 
				FROM #var_assessment_R
				WHERE #var_assessment_R.idupb = #income.idupb and 
					#var_assessment_R.idfin = #income.idfin and 
					#var_assessment_R.idman = #income.idman), 0),
	proceed_R =ISNULL((SELECT #proceed_R.amount 
				FROM #proceed_R
				WHERE #proceed_R.idupb = #income.idupb and 
					#proceed_R.idfin = #income.idfin and 
					#proceed_R.idman = #income.idman), 0),
	var_proceed_R = ISNULL((SELECT #var_proceed_R.amount 
				FROM #var_proceed_R
				WHERE #var_proceed_R.idupb = #income.idupb and 
					#var_proceed_R.idfin = #income.idfin and 
					#var_proceed_R.idman = #income.idman), 0)
	IF @codelevel >= @levelusable
	BEGIN	
		UPDATE #income
		SET	initialprevisioncomp= ISNULL((SELECT finyear.prevision 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					where finyear.idupb = #income.idupb AND 
						finyear.idfin = #income.idfin),0),
			initialprevisioncash = ISNULL((SELECT finyear.secondaryprev 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					WHERE finyear.idupb = #income.idupb AND 
						finyear.idfin = #income.idfin),0)
	END 
	ELSE 
	BEGIN
		UPDATE #income
		SET initialprevisioncomp= ISNULL((SELECT SUM(isnull(finyear.prevision,0)) 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					JOIN finlink 
						ON finlink.idchild = finyear.idfin 
					WHERE finyear.idupb = #income.idupb AND 
					      finlink.idparent = #income.idfin
					      AND fin.nlevel = @levelusable),0),
		initialprevisioncash = ISNULL((SELECT SUM(isnull(finyear.secondaryprev,0)) 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					JOIN finlink 
						ON finlink.idchild = finyear.idfin 
					where finyear.idupb = #income.idupb AND 
						finlink.idparent = #income.idfin 
						AND fin.nlevel = @levelusable),0)
	END
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------- CALCOLO DEL DISPONIBILE -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	UPDATE #income
	SET 
		total_assessment_C = ISNULL((SELECT SUM(ISNULL(incomeyear.amount, 0))
					FROM income
					JOIN incomeyear
						ON incomeyear.idinc = income.idinc 
						AND incomeyear.ayear = @ayear
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE income.adate between @start and @stop
					AND income.nphase= @nfinphase
					AND ((incometotal.flag&1)=0) --Competenza
					AND incomeyear.idupb = #income.idupb 
					AND ISNULL(finlink.idparent,incomeyear.idfin)  = #income.idfin),0),
	
		total_var_assessment_C = ISNULL((SELECT SUM(ISNULL(incomevar.amount, 0))
					FROM incomevar
					JOIN income ON income.idinc = incomevar.idinc
					JOIN incomeyear
						ON incomeyear.idinc = incomevar.idinc 
						AND incomeyear.ayear = @ayear
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE incomevar.yvar = @ayear
					AND income.nphase= @nfinphase
					AND ((incometotal.flag&1)=0) --Competenza
					AND incomevar.adate between @start and @stop 
					AND incomeyear.idupb = #income.idupb 
					AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),0),
		total_assessment_R = ISNULL((SELECT SUM(ISNULL(incomeyear.amount, 0))
					FROM incomeyear
					JOIN income
						ON income.idinc = incomeyear.idinc 
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE ((incometotal.flag&1)=1) --Competenza
					AND income.nphase= @nfinphase
					AND income.adate between @start and @stop
					AND incomeyear.ayear = @ayear
					AND incomeyear.idupb = #income.idupb 
					AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),0),
		total_var_assessment_R = ISNULL((SELECT SUM(ISNULL(incomevar.amount, 0))
					FROM incomevar
					JOIN income ON income.idinc = incomevar.idinc
					JOIN incomeyear
						ON incomeyear.idinc = incomevar.idinc AND 
						incomeyear.ayear = @ayear
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE incomevar.yvar = @ayear
					AND ((incometotal.flag&1)=1) --Residuo
					AND income.nphase= @nfinphase
					AND incomevar.adate between @start and @stop 
					AND incomeyear.idupb = #income.idupb 
					AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),0),
		total_proceed_C = ISNULL((SELECT SUM(ISNULL(proceedsemitted.amount,0))
					FROM incomeyear
					JOIN proceedsemitted
						ON incomeyear.idinc = proceedsemitted.idinc AND incomeyear.ayear = @ayear
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE proceedsemitted.competencydate between @start and @stop
					AND ((incometotal.flag&1)=0) --Competenza
					AND incomeyear.idupb = #income.idupb 
					AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),0),
		total_var_proceed_C = ISNULL((SELECT SUM(ISNULL(incomevar.amount, 0))
					FROM incomevar
					JOIN income ON income.idinc = incomevar.idinc
					JOIN incomeyear
						ON incomeyear.idinc = incomevar.idinc AND incomeyear.ayear = @ayear
					JOIN proceedsemitted
						ON incomeyear.idinc = proceedsemitted.idinc AND incomeyear.ayear = @ayear
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE incomevar.yvar = @ayear
					AND ((incometotal.flag&1)=0) --Competenza
					AND income.nphase= @maxincomephase
					AND incomevar.adate between @start and @stop
					AND incomevar.idinc IN (select idinc from proceedsemitted)
					AND incomeyear.idupb = #income.idupb 
					AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),0),
		total_proceed_R = ISNULL((SELECT SUM(ISNULL(proceedsemitted.amount,0))
					FROM proceedsemitted
					JOIN incomeyear
						ON incomeyear.idinc = proceedsemitted.idinc AND incomeyear.ayear = @ayear
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE proceedsemitted.competencydate between @start and @stop
					AND ((incometotal.flag&1)= 1) --Residuo
					AND proceedsemitted.nphase= @maxincomephase
					AND incomeyear.idupb = #income.idupb 
					AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),0),
		total_var_proceed_R = ISNULL((SELECT SUM(ISNULL(incomevar.amount, 0))
					FROM incomevar
					JOIN income ON income.idinc = incomevar.idinc
					JOIN incomeyear
						ON incomeyear.idinc = incomevar.idinc AND 
						incomeyear.ayear = @ayear
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE incomevar.yvar = @ayear
					AND ((incometotal.flag&1)= 1) --Residuo
					AND income.nphase= @maxincomephase
					AND incomevar.adate between @start and @stop
					AND incomevar.idinc IN (select idinc from proceedsemitted)
					AND incomeyear.idupb = #income.idupb 
					AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),0)
END
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

UPDATE #income
SET
	assessment_amount = assessment_amount + 
				(SELECT ISNULL(SUM(amount),0) 
				   FROM incomevar
				   JOIN income 
				     ON income.idinc = incomevar.idinc
				  WHERE income.idinc = #income.nassessment
				        AND incomevar.adate between @start and @stop
				        AND incomevar.yvar = @ayear
				        AND income.nphase = @nfinphase),
	proceed_amount = proceed_amount + 
				(SELECT ISNULL(SUM(amount),0) 
				   FROM incomevar
			           JOIN income 
				     ON income.idinc = incomevar.idinc
			          WHERE incomevar.idinc = #income.nproceed
					AND incomevar.adate between @start and @stop
					AND incomevar.yvar = @ayear
					AND income.nphase = @maxincomephase
				),
	reportdate =@stop,
	ayear=@ayear

------------------------------------------- <	     NEW        > ----------------------------------------------------------------
-- SE ho scelto di totalizzare i figli dell'UPB selezionato (N, 'pippo',S)
-- O SE ho scelto di non vedere l'upb (N,N)  
-- ALLORA totalizzo gli importi
-- Se ho scelto di vedere l'upb (con o senza figli :  S/N o S/S) saranno presi i valori calcolati sopra 
-- che saranno stati calcolati distinguendo gli upb-padri dagli upb-figli.
IF (@showupb <>'S') 
BEGIN
	UPDATE #income 
	SET 
		finvar_prevision = ISNULL((SELECT SUM(ISNULL(finvardetail.amount,0))
				FROM finvardetail
				JOIN finvar
					ON finvar.yvar = finvardetail.yvar
					AND finvar.nvar = finvardetail.nvar
				LEFT OUTER JOIN finlink 
					ON finlink.idchild = finvardetail.idfin AND 
					finlink.nlevel = @codelevel
				WHERE finvar.flagprevision ='S'	
				AND finvar.idfinvarstatus = 5
				AND finvar.variationkind <> 5
				AND finvar.adate between @start and @stop
				AND finvar.yvar = @ayear
				AND ISNULL(finlink.idparent,finvardetail.idfin) = #income.idfin 
				AND finvardetail.idupb like @idupb	
				), 0),
		finvar_secondaryprev = ISNULL((SELECT SUM(ISNULL(finvardetail.amount,0))
				FROM finvardetail
				JOIN finvar
					ON finvar.yvar = finvardetail.yvar
					AND finvar.nvar = finvardetail.nvar
				LEFT OUTER JOIN finlink 
					ON finlink.idchild = finvardetail.idfin AND 
					finlink.nlevel = @codelevel
				WHERE finvar.flagsecondaryprev ='S'	
				AND finvar.idfinvarstatus = 5
				AND finvar.variationkind <> 5
				AND finvar.adate between @start and @stop
				AND finvar.yvar = @ayear
				AND ISNULL(finlink.idparent,finvardetail.idfin) = #income.idfin 
				AND finvardetail.idupb like @idupb	
				), 0),
		assessment_C = (SELECT SUM(ISNULL( #assessment_C.amount,0)) 
					FROM #assessment_C
					WHERE #assessment_C.idupb like @idupb and
						#assessment_C.idfin = #income.idfin
						and #assessment_C.idman = #income.idman), 
		var_assessment_C = (SELECT SUM(ISNULL( #var_assessment_C.amount,0))  
					FROM #var_assessment_C
					WHERE #var_assessment_C.idupb like @idupb and
						#var_assessment_C.idfin = #income.idfin
						and #var_assessment_C.idman = #income.idman), 
		proceed_C =(SELECT SUM(ISNULL( #proceed_C.amount,0))  
					FROM #proceed_C
					WHERE #proceed_C.idupb like @idupb and 
						#proceed_C.idfin = #income.idfin
						and #proceed_C.idman = #income.idman),
		var_proceed_C =(SELECT SUM(ISNULL( #var_proceed_C.amount,0))  
					FROM #var_proceed_C
					WHERE #var_proceed_C.idupb like @idupb and 
						#var_proceed_C.idfin = #income.idfin
						and #var_proceed_C.idman = #income.idman), 
	  	assessment_R =(SELECT SUM(ISNULL( #assessment_R.amount,0)) 
					FROM #assessment_R
					WHERE #assessment_R.idupb like @idupb and 
						#assessment_R.idfin = #income.idfin
						and #assessment_R.idman = #income.idman ), 
		var_assessment_R =(SELECT SUM(ISNULL( #var_assessment_R.amount,0))  
					FROM #var_assessment_R
					WHERE #var_assessment_R.idupb like @idupb and 
						#var_assessment_R.idfin = #income.idfin
						and #var_assessment_R.idman = #income.idman), 
		proceed_R =(SELECT SUM(ISNULL( #proceed_R.amount,0))  
					FROM #proceed_R
					WHERE #proceed_R.idupb like @idupb and 
						#proceed_R.idfin = #income.idfin
						and #proceed_R.idman = #income.idman), 
		var_proceed_R = (SELECT SUM(ISNULL( #var_proceed_R.amount,0))  
					FROM #var_proceed_R
					WHERE #var_proceed_R.idupb like @idupb and 
						#var_proceed_R.idfin = #income.idfin
						and #var_proceed_R.idman = #income.idman) 
	IF (@codelevel >= @levelusable)
	BEGIN	
		UPDATE #income
		SET	
		initialprevisioncomp= (SELECT SUM(ISNULL(finyear.prevision,0))  
					FROM finyear
					JOIN fin
					ON finyear.idfin = fin.idfin
					JOIN upb
					ON finyear.idupb = upb.idupb
					where finyear.idupb like @idupb  
					 and finyear.idfin = #income.idfin
					--and upb.idman = #income.idman
					),
	  
		initialprevisioncash = (SELECT SUM(ISNULL(finyear.secondaryprev,0))  
					FROM finyear
					JOIN fin
					ON finyear.idfin = fin.idfin
					JOIN upb
					ON finyear.idupb = upb.idupb
					where finyear.idupb like @idupb  
					and finyear.idfin = #income.idfin
					--and upb.idman = #income.idman
					)
	END 
	ELSE 
	BEGIN
		UPDATE #income
		SET 
		initialprevisioncomp= (SELECT SUM(ISNULL(finyear.prevision,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin
					WHERE finyear.idupb like @idupb  
					AND ISNULL(finlink.idparent,finyear.idfin)  = #income.idfin
					AND fin.nlevel = @levelusable),
	  
		initialprevisioncash = (SELECT SUM(ISNULL(finyear.secondaryprev,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin
					WHERE upb.idupb like @idupb 
					AND ISNULL(finlink.idparent,finyear.idfin) = #income.idfin
					AND fin.idfin = @levelusable)
	END

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------- CALCOLO DEL DISPONIBILE -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	UPDATE #income
	SET 
		total_assessment_C = (SELECT SUM(ISNULL(incomeyear.amount, 0))
					FROM income
					JOIN incomeyear
						ON incomeyear.idinc = income.idinc 
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE income.adate between @start and @stop
						AND incomeyear.ayear = @ayear
						AND income.nphase= @nfinphase
						AND ((incometotal.flag&1)=0) --Competenza
						AND incomeyear.idupb like @idupb
						AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),
	
		total_var_assessment_C  = (SELECT SUM(ISNULL(incomevar.amount, 0))
					FROM incomevar
					JOIN income ON income.idinc = incomevar.idinc
					JOIN incomeyear
						ON incomeyear.idinc = incomevar.idinc 
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE incomevar.yvar = @ayear
						AND income.nphase= @nfinphase
						AND ((incometotal.flag&1)=0) --Competenza
						AND incomeyear.ayear = @ayear
						AND incomevar.adate between @start and @stop 
						AND incomeyear.idupb like @idupb
						AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),

		total_assessment_R = (SELECT SUM(ISNULL(incomeyear.amount, 0))
					FROM incomeyear
					JOIN income
						ON income.idinc = incomeyear.idinc 
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE  ((incometotal.flag&1)=1) --Residuo
						AND income.nphase= @nfinphase
						AND incomeyear.ayear = @ayear		
						AND income.adate between @start and @stop
						AND incomeyear.idupb like @idupb
						AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),
		
		total_var_assessment_R = ( SELECT SUM(ISNULL(incomevar.amount, 0))
					FROM incomevar
					JOIN income ON income.idinc = incomevar.idinc
					JOIN incomeyear
						ON incomeyear.idinc = incomevar.idinc
						AND incomeyear.ayear = @ayear
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE incomevar.yvar = @ayear
						AND ((incometotal.flag&1)=1) --Residuo
						AND income.nphase= @nfinphase
						AND incomevar.adate between @start and @stop 
						AND incomeyear.idupb like @idupb 
						AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),
		total_proceed_C = (SELECT SUM(ISNULL(proceedsemitted.amount,0))
					FROM incomeyear
					JOIN proceedsemitted
						ON incomeyear.idinc = proceedsemitted.idinc 
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE proceedsemitted.competencydate between @start and @stop
						AND incomeyear.ayear = @ayear
						AND ((incometotal.flag&1)=0) --Competenza
						AND proceedsemitted.nphase= @maxincomephase
						AND incomeyear.idupb like @idupb
						AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),
		total_var_proceed_C = (SELECT SUM(ISNULL(incomevar.amount, 0))
					FROM incomevar
					JOIN income ON income.idinc = incomevar.idinc
					JOIN incomeyear
						ON incomeyear.idinc = incomevar.idinc 
						AND incomeyear.ayear = @ayear
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE incomevar.yvar = @ayear
						AND ((incometotal.flag&1)=0) --Competenza
						AND income.nphase= @maxincomephase
						AND incomevar.adate between @start and @stop
						AND incomevar.idinc IN (select idinc from proceedsemitted)
						AND incomeyear.idupb like @idupb
						AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),
		total_proceed_R = (SELECT SUM(ISNULL(proceedsemitted.amount,0))
					FROM proceedsemitted
					JOIN incomeyear
						ON incomeyear.idinc = proceedsemitted.idinc
						AND incomeyear.ayear = @ayear
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE proceedsemitted.competencydate between @start and @stop
						AND ((incometotal.flag&1)=1) --Residuo
						AND proceedsemitted.nphase= @maxincomephase
						AND incomeyear.idupb like @idupb
						AND ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin),
		total_var_proceed_R = ( SELECT SUM(ISNULL(incomevar.amount, 0))
					FROM incomevar
					JOIN income ON income.idinc = incomevar.idinc
					JOIN incomeyear
						ON incomeyear.idinc = incomevar.idinc 
						AND incomeyear.ayear = @ayear
					JOIN incometotal 
						ON  incomeyear.idinc = incometotal.idinc AND
						incomeyear.ayear = incometotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = incomeyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE incomevar.yvar = @ayear
						AND ((incometotal.flag&1)=1) --Residuo
						AND income.nphase= @maxincomephase
						AND incomevar.adate between @start and @stop
						AND incomevar.idinc IN (select idinc from proceedsemitted)
						and incomeyear.idupb like @idupb
						and ISNULL(finlink.idparent,incomeyear.idfin) = #income.idfin)
END					
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

					
-- cancello le righe dei figli di @idupboriginal aventi idassessment = NULL
-- Se ho scelto l'upb ne cancello i figli perchè li ho totalizzati tramite la nuova UPDATE
/*IF (@showupb <>'S') and (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		DELETE FROM #income WHERE idassessment is null 
						AND substring(idupb,1,len(@idupboriginal))= @idupboriginal 	
						AND idupb <>@idupboriginal
*/
-- cancello solo le righe che sono upb-figli aventi idassessment = NULL
-- Se non ho scelto alcun upb cancello solo gli upb-figli perchè li ho totalizzati tramite la nuova UPDATE
/*IF (@showupb <>'S') 
		DELETE FROM #income WHERE idassessment IS NULL 
			AND EXISTS (SELECT * FROM #income  R 
				join upb U on U.idupb=R.idupb  
				WHERE U.paridupb = #income.idupb 
				and U.idman = #income.idman )*/
-- cancello i record duplicati 
-- se questa condizione è soffisfatta è significa che avrò (x es.) due record, di cui uno ha l'info dell'accertamento
-- l'altro no ma entrambi avranno i medesimi importi per le prev. e gli importi dei mov. in quanto li ho totalizzate sopra
-- Se non procedo con questa cancellazione nell'istruzione successiva in cui esegue l'update sull'idupb
-- poi farà il raggruppamento finale raddoppiando (erroneamente) gli importi.
IF (@showupb <>'S') 
		DELETE FROM #income WHERE idassessment IS NULL 
			AND EXISTS (SELECT * FROM #income E 
					WHERE E.idfin = #income.idfin 
					and E.idman = #income.idman 
					and E.idupb <>	#income.idupb)
---------------------------------------------------------------------------------------------------------------

	IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
			UPDATE #income SET  
				upbprintingorder = (SELECT TOP 1 printingorder
					FROM  upb
					WHERE idupb = @idupboriginal),
				upb = (SELECT TOP 1 title
					FROM  upb
					WHERE idupb = @idupboriginal),
				idupb = @idupboriginal,
				codeupb =(SELECT TOP 1 codeupb
					FROM  upb	
					WHERE idupb = @idupboriginal)
	
	IF (@showupb <>'S') and (@idupboriginal = '%')
				UPDATE #income SET  
				upbprintingorder = null	,
				upb =  null,
				idupb = null,
				codeupb = null

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--  ****************************************************************************************************************** --
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


CREATE TABLE #incomeprec
(
	idupb varchar(36),
	prevision decimal(19,2),
	finvar_prevision decimal(19,2),
	appropriation decimal(19,2),
	var_appropriation decimal(19,2)
)
-- questi calcoli li fa solo se vuoi vedere l'upb,perchè sono info relative ad essso
-- IF parametto mostra info = S  and mostra upb = S

DECLARE @secprevisionkind    char(1) 
SELECT  @secprevisionkind  = 
	 CASE 
		WHEN fin_kind = 3 THEN 'S'
		ELSE NULL
	END
FROM config 
WHERE config.ayear = @ayear

DECLARE @param char
SELECT  @param = isnull(paramvalue,'N') FROM reportadditionalparam 
WHERE paramname = 'MostraInfoAnniPrecedenti'
AND (
	(@secprevisionkind is not null AND reportname='partitario_entrate_intestazione_respons')
	OR
	 (@secprevisionkind is null and reportname= 'partitario_entarte_intestazione_respons_singprev')
	)
IF (@param='S' and @showupb ='S')
BEGIN
	insert into #incomeprec
	(
	idupb,
	prevision 
	)
	SELECT  
		FY.idupb,
		ISNULL(SUM(FY.prevision),0)
	FROM finyearview FY 
	WHERE  FY.finpart = 'E'
		AND FY.ayear = @ayear
		AND FY.nlevel = (SELECT MIN(nlevel) FROM finlevel 
				WHERE ayear = FY.ayear AND (flag&2)<>0)
		AND FY.idupb in (select distinct idupb from #income)
	GROUP BY FY.idupb


	UPDATE #incomeprec
	SET finvar_prevision = (SELECT ISNULL(SUM(d.amount),0)
				FROM finvar v
				JOIN finvardetail d
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				JOIN fin f
					ON f.idfin = d.idfin 
				WHERE d.idupb = #incomeprec.idupb
					AND ((f.flag & 1) = 0 )
					AND v.yvar = @ayear
					AND v.adate <= @stop
					AND v.flagprevision = 'S'
					AND v.variationkind <> 5
					AND v.idfinvarstatus = 5),
	
	appropriation = (SELECT ISNULL(SUM(incomeyear.amount),0)
				FROM income
				JOIN incomeyear
					ON income.idinc = incomeyear.idinc
					AND income.ymov = incomeyear.ayear
				WHERE income.ymov < @ayear
					AND incomeyear.idupb = #incomeprec.idupb
					AND income.nphase = @nfinphase ),
	var_appropriation = (SELECT ISNULL(SUM(incomevar.amount),0)
				FROM income
				JOIN incomevar
					ON income.idinc = incomevar.idinc
				JOIN incomeyear
					ON income.idinc = incomeyear.idinc
					AND income.ymov = incomeyear.ayear
				WHERE income.ymov < @ayear
					AND incomevar.yvar <= @ayear
					AND incomeyear.ayear < @ayear
					AND incomevar.adate <= @stop
					AND incomeyear.idupb = #incomeprec.idupb
					AND income.nphase = @nfinphase)
	
END

--previsione iniziale : SET @incomeprevision = @incomeprevision + @prev_arrears
--Variazioni: @incomevar
--Tot Previsione  ISNULL(@incomeprevision, 0) + ISNULL(@incomevar, 0)

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--  ****************************************************************************************************************** --
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


if ((@suppressifblank = 'S') and @codelevel>2)	--> se la stampa è x un livello sottostante la categoria cancella le righe
	BEGIN
		DELETE FROM  #income   
		WHERE  
		(ISNULL(initialprevisioncomp,0)= 0 AND 
		ISNULL(initialprevisioncash,0)= 0 AND 
		ISNULL(finvar_prevision,0)= 0 AND
		ISNULL(finvar_secondaryprev,0)= 0 AND
		ISNULL(assessment_C,0) = 0 AND
		ISNULL(var_assessment_C	,0)= 0 AND
		ISNULL(proceed_C,0)= 0 and
		ISNULL(var_proceed_C,0)= 0 AND
		ISNULL(assessment_R,0)= 0 AND
		ISNULL(var_assessment_R	,0)= 0 AND
		ISNULL(proceed_R,0)= 0 AND
		ISNULL(var_proceed_R,0)= 0 AND
		ISNULL(assessment_amount,0)=0 AND
		ISNULL(proceed_amount,0)=0  AND
		(select nlevel from fin FFF where FFF.idfin= #income.idfin)>=2
		--AND len(idfin)>=11
		)
	END
IF (@showupb <>'S')
BEGIN
	SELECT
		#income.idfin		,
		F.codefin		,
		F.title as fintitle	,
		F.printingorder as finprintingorder	,
		codeupb			,
		idupb 			,
		upb   			,
		upbprintingorder	,
		nphase		,
		rowkind		,							
		sum(isnull(initialprevisioncomp,0))	as initialprevisioncomp,
		sum(isnull(initialprevisioncash,0)) as initialprevisioncash,
		sum(isnull(finvar_prevision,0)) as finvar_prevision,
		sum(isnull(finvar_secondaryprev,0)) as finvar_secondaryprev,
		sum(isnull(assessment_C,0)) as assessment_C,
		sum(isnull(var_assessment_C,0)) as var_assessment_C,
		sum(isnull(proceed_C,0)) as proceed_C,
		sum(isnull(var_proceed_C,0)) as var_proceed_C,
		sum(isnull(assessment_R,0)) as assessment_R,
		sum(isnull(var_assessment_R,0)) as var_assessment_R,
		sum(isnull(proceed_R,0)) as proceed_R,
		sum(isnull(var_proceed_R,0)) as var_proceed_R,
		adate,
		description,
		REG.title as registry	,
		nassessment,
		ymovassessment,
		nmovassessment,	
		sum(isnull(assessment_amount,0)) as assessment_amount,
		nproceed,
		ymovproceed,
		nmovproceed,	
		sum(isnull(proceed_amount,0)) as proceed_amount,
		npro,
		flagarrear,
		reportdate,
		#income.ayear,
		idassessment,
		MAN.title as manager,
		#income.idman,
		sum(isnull(total_assessment_C,0)) as total_assessment_C,	
		sum(isnull(total_var_assessment_C ,0)) as total_var_assessment_C,
		sum(isnull(total_assessment_R,0)) as total_assessment_R,
		sum(isnull(total_var_assessment_R,0))	as total_var_assessment_R,
		sum(isnull(total_proceed_C,0)) as total_proceed_C,
		sum(isnull(total_var_proceed_C,0)) as total_var_proceed_C,
		sum(isnull(total_proceed_R,0)) as  total_proceed_R ,
		sum(isnull(total_var_proceed_R,0)) as	 total_var_proceed_R  ,
		0 as  prevision_prec,
		0 as  appropriation_prec
	FROM  #income
	JOIN fin F
		ON F.idfin = #income.idfin
	LEFT OUTER JOIN registry REG	
		ON REG.idreg = #income.idreg
	LEFT OUTER JOIN manager MAN  
		ON #income.idman = MAN.idman
	GROUP BY #income.idman,MAN.title,
		upbprintingorder,F.printingorder,#income.idfin,F.codefin,F.title,codeupb,idupb,upb,nphase,
		ymovassessment, nmovassessment,	ymovproceed, nmovproceed,	
		rowkind	,adate,description,REG.title,nassessment,nproceed,npro,flagarrear,
		reportdate,#income.ayear,idassessment
	ORDER BY manager,upbprintingorder, finprintingorder, rowkind, adate
END
ELSE
BEGIN
	SELECT 
		#income.idfin		,
		F.codefin		,
		F.title as fintitle	,
		F.printingorder as finprintingorder	,
		codeupb,
		#income.idupb,
		upb,
		upbprintingorder,
		nphase,
		rowkind,
		initialprevisioncomp,
		initialprevisioncash,
		#income.finvar_prevision,
		finvar_secondaryprev,
		assessment_C,
		var_assessment_C,
		proceed_C,
		var_proceed_C,
		assessment_R,
		var_assessment_R,
		proceed_R,
		var_proceed_R,
		adate ,
		description,
		REG.title as registry,
		nassessment,
		ymovassessment,
		nmovassessment,	
		assessment_amount,
		nproceed,
		ymovproceed,
		nmovproceed,	
		proceed_amount,
		npro,
		flagarrear,
		reportdate,
		#income.ayear,
		idassessment,
		#income.idman,
		MAN.title as manager,
		total_assessment_C,
		total_var_assessment_C,
		total_assessment_R,
		total_var_assessment_R,
		total_proceed_C,
		total_var_proceed_C,
		total_proceed_R,
		total_var_proceed_R,
		isnull(prec.prevision,0) + isnull(prec.finvar_prevision,0) 
		+ isnull(prec.appropriation,0)+isnull(prec.var_appropriation,0) as  prevision_prec,
		isnull(prec.appropriation,0)+isnull(prec.var_appropriation,0) as  appropriation_prec

	FROM  #income
	JOIN fin F
		ON F.idfin = #income.idfin
	LEFT OUTER JOIN registry REG	
		ON REG.idreg = #income.idreg
	LEFT OUTER JOIN manager MAN  
		ON #income.idman = MAN.idman
	LEFT OUTER JOIN #incomeprec prec
		ON #income.idupb = prec.idupb
	ORDER BY MAN.title,upbprintingorder, F.printingorder, rowkind, adate
END
END
	




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


