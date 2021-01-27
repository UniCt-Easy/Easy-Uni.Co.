
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_entrate_intestazione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_entrate_intestazione]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [rpt_partitario_entrate_intestazione]
	@ayear int,
	@idupb	varchar(36),
	@adate datetime,
	@codelevel  tinyint,
	@showupb char(1),
	@showchildupb char(1),
	@suppressifblank char(1),
	@idfin int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
BEGIN
/* Versione 1.0.3 del 18/09/2007 ultima modifica: PINO */
DECLARE @level_input tinyint
SELECT @level_input = ISNULL(nlevel, @codelevel) from fin where idfin = @idfin
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

DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)

declare @fin_kind tinyint
DECLARE @nfinphase tinyint
SELECT @nfinphase = assessmentphasecode,
		@fin_kind = fin_kind
FROM config
WHERE ayear = @ayear
IF @nfinphase IS NULL
BEGIN
	SELECT @nfinphase = incomefinphase
	FROM uniconfig
END
DECLARE @maxincomephase tinyint
SELECT @maxincomephase = MAX(nphase)
FROM  incomephase 

	
CREATE TABLE #income
(
	upb varchar(150),
	codeupb	varchar(50),
	idupb varchar(36),
	upbprintingorder varchar(50),
	idfin int,
	idassessment int,
	nphase tinyint,
	flagarrear char(1),	
	ayear int,
	adate datetime,
	description varchar(150),
	idreg int,
	rowkind int,
	npro int,
	reportdate datetime,
	initialprevisioncomp decimal(19,2),
	initialprevisioncassa decimal(19,2),
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
	nassessment int,
	ymovassessment int,
	nmovassessment int,
	yvarassessment int,
	nvarassessment int,
	assessment_amount decimal(19,2),
	origin_assessment_amount decimal(19,2),
	nproceed int,
	ymovproceed int,
	nmovproceed int,
	yvarproceed int,
	nvarproceed int,
	proceed_amount decimal(19,2),
	emessiondate datetime,
	printeddate datetime,
	trasmitteddate datetime,
	transactiondate datetime,
	annulmentdate datetime,
	assessment_available decimal(19,2),
)

INSERT INTO #income
(
	idfin,
	idupb,
	nphase,
	rowkind, 
	adate, 
	description, 
	idreg,
	nassessment, 
	ymovassessment,
	nmovassessment,
	assessment_amount,
	origin_assessment_amount,
	nproceed, 
	ymovproceed,
	nmovproceed,
	proceed_amount,
	npro,
	flagarrear,
	idassessment
)
SELECT 
	ISNULL(FL.idparent, incomeyear.idfin),
	upb.idupb,
	income.nphase,
	income.nphase-1,
	income.adate,
	income.description,
	income.idreg,
	I2.idinc, --ACCERTAMENTO
	I2.ymov,
	I2.nmov,  
	incomeyear.amount,
	incomeyear_starting.amount,
	I3.idinc, --INCASSO
	I3.ymov,
	I3.nmov,
	incomeyear.amount,
	proceeds.npro,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	I2.idinc --INCASSO
FROM incomeyear
JOIN income
	ON incomeyear.idinc = income.idinc 
JOIN upb 
	ON upb.idupb=incomeyear.idupb
JOIN fin 
	ON incomeyear.idfin = fin.idfin 
JOIN incometotal
	ON  incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear	
JOIN incomelink IL2
	ON IL2.idchild = income.idinc  
	AND IL2.nlevel = @nfinphase
LEFT  OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1
	ON FL1.idchild = incomeyear.idfin AND FL1.nlevel = @level_input
LEFT  OUTER JOIN incomelast
	ON incomelast.idinc = income.idinc
LEFT  OUTER JOIN proceeds
	ON incomelast.kpro = proceeds.kpro
LEFT OUTER JOIN income I2
	ON I2.idinc = IL2.idparent
LEFT OUTER JOIN income I3
	 ON I3.idinc = incomelast.idinc 
LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  	ON incometotal_firstyear.idinc = income.idinc
  	AND ((incometotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  	AND incomeyear_starting.ayear = incometotal_firstyear.ayear
WHERE ((fin.flag&1)=0) -- Entrata
	AND (@idfin IS NULL OR isnull(FL1.idparent, fin.idfin) = @idfin)
	AND incomeyear.ayear = @ayear
	AND income.adate <= @adate
	AND income.nphase >= @nfinphase
	AND (upb.idupb like @idupb ) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

--- Inserimento delle variazioni dei movimenti
INSERT INTO #income
(
	idfin,
	idupb,
	nphase,
	rowkind, 
	adate, 
	description, 
	idreg,		
	nassessment, 
	ymovassessment,
	nmovassessment,
	yvarassessment,
	nvarassessment,
	assessment_amount,
	nproceed, 
	ymovproceed,
	nmovproceed,
	yvarproceed,
	nvarproceed,
	proceed_amount,
	npro,
	idassessment
)	--> prende quelli movimentati


SELECT 

	ISNULL(FL.idparent, incomeyear.idfin),
	incomeyear.idupb,
	income.nphase,
	income.nphase-1,
	incomevar.adate,
	incomevar.description,
	income.idreg,	
	I2.idinc, --IMPEGNO
	I2.ymov,
	I2.nmov,  
	incomevar.yvar,
	incomevar.nvar,
	incomevar.amount,

	I3.idinc, --PAGAMENTO
	I3.ymov,
	I3.nmov, 
	incomevar.yvar,--EV3
	incomevar.nvar,--EV3
	incomevar.amount,--EV3
	proceeds.npro,
	I2.idinc 
FROM incomevar
join income 
	on incomevar.idinc = income.idinc
JOIN incomeyear
	ON incomeyear.idinc = income.idinc 
JOIN upb
	ON upb.idupb = incomeyear.idupb
JOIN finlast
	ON finlast.idfin = incomeyear.idfin 
JOIN incomelink IL2
	ON IL2.idchild = incomevar.idinc  AND IL2.nlevel = @nfinphase
LEFT  OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin  AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1
	ON FL1.idchild = incomeyear.idfin  AND FL1.nlevel = @level_input
LEFT OUTER JOIN incomelast
	ON incomelast.idinc = income.idinc
LEFT OUTER JOIN incomelink IL3
	ON IL3.idchild = incomevar.idinc  AND IL3.nlevel = @maxincomephase
LEFT OUTER JOIN income I2
	ON I2.idinc = IL2.idparent
LEFT OUTER JOIN income I3
	ON I3.idinc = IL3.idparent
LEFT OUTER JOIN proceeds
	ON proceeds.kpro = incomelast.kpro
WHERE	(@idfin IS NULL OR  isnull(FL1.idparent, incomeyear.idfin) = @idfin)		
	AND incomevar.adate between @firstday and @adate
	AND isnull(incomevar.autokind,'') <>'22'
 	and incomevar.yvar = @ayear 
	AND ((income.nphase IN (@nfinphase, @maxincomephase)))
	AND (incomeyear.idupb like @idupb)
	AND incomeyear.ayear=@ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
INSERT INTO #income
	(
	idfin,
	idupb
	)
SELECT  
 	ISNULL(FL.idparent,fin.idfin),
 	upb.idupb
FROM fin 
CROSS JOIN upb 
LEFT  OUTER JOIN finlink FL
	ON FL.idchild = fin.idfin AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1
	ON FL1.idchild = fin.idfin AND FL1.nlevel = @level_input
WHERE 
 	((fin.flag&1)=0) -- Entrata
 	AND (@idfin IS NULL OR isnull(FL1.idparent, fin.idfin) = @idfin)
	AND (upb.idupb LIKE @idupb) 
	AND (fin.ayear = @ayear)
	AND fin.nlevel=@codelevel
 AND NOT EXISTS 
(SELECT  #income.idfin,
    #income.idupb
   FROM #income
   WHERE #income.idupb =UPB.idupb
    AND #income.idfin = fin.idfin)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)



CREATE TABLE #finvar_prevision
    (
	idfin  int,
	idupb  varchar(36),
	amount decimal(19,2)
    )
		
INSERT INTO #finvar_prevision
	(
	idfin,
	idupb,
	amount
	)
SELECT
	ISNULL(FL.idparent,finvardetail.idfin),
	finvardetail.idupb,
	SUM(ISNULL(finvardetail.amount,0.0))
FROM finvardetail
JOIN finvar
	ON finvar.yvar = finvardetail.yvar
	AND finvar.nvar = finvardetail.nvar
JOIN fin
	ON finvardetail.idfin = fin.idfin
JOIN upb
	ON upb.idupb = finvardetail.idupb
LEFT OUTER JOIN finlink FL
	ON FL.idchild = finvardetail.idfin  
	AND FL.nlevel = @codelevel
LEFT OUTER JOIN finlink FL1
	ON FL1.idchild = finvardetail.idfin  
	AND FL1.nlevel = @level_input
WHERE finvar.flagprevision ='S'	 
	AND finvar.idfinvarstatus = 5
	AND finvar.variationkind <> 5
	AND finvar.adate <= @adate
	AND finvar.yvar = @ayear
	AND (@idfin IS NULL OR isnull(FL1.idparent, fin.idfin) = @idfin)
	AND (finvardetail.idupb like @idupb) 
	AND ((fin.flag&1)=0) -- Entrata
	AND fin.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY finvardetail.idupb,ISNULL(FL.idparent,finvardetail.idfin)

CREATE TABLE #finvar_secondaryprev
    (
	idfin  int,
	idupb  varchar(36),
	amount decimal(19,2)					 
    )
INSERT INTO #finvar_secondaryprev
	(
	idfin,
	idupb,
	amount
	)
SELECT
	ISNULL(FL.idparent,finvardetail.idfin),
	finvardetail.idupb,
	SUM(ISNULL(finvardetail.amount, 0.0))
FROM finvardetail
JOIN fin
	ON finvardetail.idfin = fin.idfin
JOIN upb
	ON upb.idupb = finvardetail.idupb
JOIN finvar
	ON finvar.yvar = finvardetail.yvar
	AND finvar.nvar = finvardetail.nvar
LEFT OUTER JOIN finlink FL
	ON FL.idchild = finvardetail.idfin  
	AND FL.nlevel = @codelevel
LEFT OUTER JOIN finlink FL1
	ON FL1.idchild = finvardetail.idfin  
	AND FL1.nlevel = @level_input
WHERE finvar.yvar = @ayear
	AND finvar.adate <= @adate
	AND finvar.flagsecondaryprev='S'
	AND finvar.idfinvarstatus = 5
	AND finvar.variationkind <> 5
	AND (@idfin IS NULL OR isnull(FL1.idparent, fin.idfin) = @idfin)
	AND (finvardetail.idupb like @idupb) 
	AND ((fin.flag&1)=0) -- Entrata
	AND fin.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY finvardetail.idupb,ISNULL(FL.idparent,finvardetail.idfin)

CREATE TABLE #assessment_C
	(
	idfin int,
	idupb varchar(36),
	amount decimal(19,2)					 
	)
INSERT INTO #assessment_C
	(
	idfin,
	idupb,
	amount
	)
SELECT
	ISNULL(finlink.idparent,incomeyear.idfin),
	incomeyear.idupb,
	SUM(ISNULL(incomeyear.amount, 0.0))
FROM income
JOIN incomeyear
	ON  incomeyear.idinc = income.idinc 
	AND incomeyear.ayear = @ayear
JOIN upb
	ON upb.idupb = incomeyear.idupb
JOIN incometotal 
	ON  incomeyear.idinc = incometotal.idinc 
	AND incomeyear.ayear = incometotal.ayear 
LEFT OUTER JOIN finlink 
	ON  finlink.idchild = incomeyear.idfin  
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin 
	AND FL.nlevel = @level_input
WHERE income.adate <= @adate
	AND income.nphase = @nfinphase
	AND ((incometotal.flag&1)=0) -- Competenza
	AND (@idfin IS NULL OR isnull(FL.idparent, incomeyear.idfin) = @idfin)
	AND (incomeyear.idupb like @idupb) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin)

CREATE TABLE #var_assessment_C
    (
	idfin int,
	idupb varchar(36),
	amount decimal(19,2)					 
    )
INSERT INTO #var_assessment_C
(
	idfin,
	idupb,
	amount
)
SELECT 
	ISNULL(finlink.idparent,incomeyear.idfin),
	incomeyear.idupb,
	SUM(ISNULL(incomevar.amount, 0.0))
FROM incomevar
JOIN incomeyear
	ON incomeyear.idinc = incomevar.idinc AND incomeyear.ayear = @ayear
JOIN upb
	ON upb.idupb = incomeyear.idupb
JOIN income 
	ON income.idinc = incomeyear.idinc
JOIN incometotal 
	ON  incomeyear.idinc = incometotal.idinc AND
	incomeyear.ayear = incometotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = incomeyear.idfin AND 
	finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin 
	AND FL.nlevel = @level_input
WHERE incomevar.yvar = @ayear
	AND income.nphase = @nfinphase
	AND ((incometotal.flag&1)=0) --Competenza
	AND incomevar.adate <= @adate 
	AND (@idfin IS NULL OR isnull(FL.idparent, incomeyear.idfin) = @idfin)
	AND (incomeyear.idupb like @idupb) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin)

CREATE TABLE #assessment_R
    (
	idfin int,
	idupb varchar(36),    
	amount decimal(19,2)					 
    )
INSERT INTO #assessment_R
(
	idfin,
	idupb,
	amount
)
SELECT
	ISNULL(finlink.idparent,incomeyear.idfin),
	incomeyear.idupb,
	SUM(ISNULL(incomeyear.amount, 0.0))
FROM incomeyear
JOIN income
	ON income.idinc = incomeyear.idinc and incomeyear.ayear = @ayear
JOIN upb
	ON upb.idupb = incomeyear.idupb
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
	AND income.nphase = @nfinphase
	AND income.adate <= @adate
	AND (@idfin IS NULL OR isnull(FL.idparent, incomeyear.idfin) = @idfin)
	AND (incomeyear.idupb like @idupb) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin)

CREATE TABLE #var_assessment_R
    (     
	idfin int,
	idupb varchar(36),    
	amount decimal(19,2)					 
    )
INSERT INTO #var_assessment_R
	(
	idfin,
	idupb,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,incomeyear.idfin),
	incomeyear.idupb,
	SUM(ISNULL(incomevar.amount, 0.0))
FROM incomevar
JOIN incomeyear
	ON incomeyear.idinc = incomevar.idinc 
	AND incomeyear.ayear = @ayear
JOIN upb
	ON upb.idupb = incomeyear.idupb
JOIN income
	ON income.idinc = incomeyear.idinc 
JOIN incometotal 
	ON  incomeyear.idinc = incometotal.idinc AND
	incomeyear.ayear = incometotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = incomeyear.idfin AND 
	finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin 
	AND FL.nlevel = @level_input
WHERE incomevar.yvar = @ayear
	AND ((incometotal.flag&1)=1) --Residuo
	AND income.nphase = @nfinphase
	AND incomevar.adate <= @adate 
	AND (@idfin IS NULL OR isnull(FL.idparent, incomeyear.idfin) = @idfin)
	AND (incomeyear.idupb like @idupb) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin)

CREATE TABLE #proceed_C
    (
	idfin  int,
	idupb  varchar(36),    
	amount decimal(19,2)					 
    )
INSERT INTO #proceed_C
(
	idfin,
	idupb,
	amount
)
SELECT
	ISNULL(finlink.idparent,proceedsemitted.idfin),
	proceedsemitted.idupb,
	SUM(ISNULL(proceedsemitted.amount,0.0))
FROM proceedsemitted
LEFT OUTER JOIN finlink 
	ON finlink.idchild = proceedsemitted.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = proceedsemitted.idfin 
	AND FL.nlevel = @level_input
JOIN upb
	ON upb.idupb = proceedsemitted.idupb
WHERE proceedsemitted.competencydate <= @adate
	AND proceedsemitted.ymov = @ayear
	AND (proceedsemitted.flagarrear= 'C')
	AND (@idfin IS NULL OR isnull(FL.idparent, proceedsemitted.idfin) = @idfin)
	AND (proceedsemitted.idupb like @idupb) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY proceedsemitted.idupb, ISNULL(finlink.idparent,proceedsemitted.idfin)

CREATE TABLE #proceed_R
    (
	idfin  int,
	idupb  varchar(36),
	amount decimal(19,2)					 
    )
INSERT INTO #proceed_R
(
	idfin,
	idupb,
	amount
)
SELECT
	ISNULL(finlink.idparent,proceedsemitted.idfin),
	proceedsemitted.idupb,
	SUM(ISNULL(proceedsemitted.amount,0.0))
FROM proceedsemitted
LEFT JOIN finlink 
	ON finlink.idchild = proceedsemitted.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = proceedsemitted.idfin 
	AND FL.nlevel = @level_input
JOIN upb
	ON upb.idupb = proceedsemitted.idupb
WHERE proceedsemitted.competencydate <= @adate
	AND (proceedsemitted.flagarrear = 'R')
	AND (proceedsemitted.ymov = @ayear)
	AND (@idfin IS NULL OR isnull(FL.idparent, proceedsemitted.idfin) = @idfin)
	AND (proceedsemitted.idupb like @idupb) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY proceedsemitted.idupb,ISNULL(finlink.idparent,proceedsemitted.idfin)

CREATE TABLE #var_proceed_C
       (
	idfin  int,
	idupb  varchar(36),   
	amount decimal(19,2)					 
        )
INSERT INTO #var_proceed_C
	(
	idfin,
	idupb,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,proceedsemitted.idfin),
	proceedsemitted.idupb,
	SUM(ISNULL(incomevar.amount, 0.0))
FROM incomevar
JOIN proceedsemitted
	ON proceedsemitted.idinc = incomevar.idinc 
	AND proceedsemitted.ymov = @ayear
LEFT OUTER JOIN finlink 
	ON finlink.idchild = proceedsemitted.idfin  
	AND finlink.nlevel = @codelevel
JOIN upb
	ON upb.idupb = proceedsemitted.idupb
LEFT OUTER JOIN finlink FL
	ON FL.idchild = proceedsemitted.idfin 
	AND FL.nlevel = @level_input
WHERE incomevar.yvar = @ayear
	AND (proceedsemitted.flagarrear = 'C')
	AND (incomevar.adate <= @adate)
	AND (@idfin IS NULL OR isnull(FL.idparent, proceedsemitted.idfin) = @idfin)
	AND (proceedsemitted.idupb like @idupb) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY proceedsemitted.idupb, ISNULL(finlink.idparent,proceedsemitted.idfin)

CREATE TABLE #var_proceed_R
    (
	idfin int,
	idupb varchar(36),  
	amount decimal(19,2)					 
    )
INSERT INTO #var_proceed_R
(
	idfin,
	idupb,
	amount
)
SELECT 
	ISNULL(finlink.idparent,proceedsemitted.idfin),
	proceedsemitted.idupb,
	SUM(ISNULL(incomevar.amount, 0.0))
FROM incomevar
JOIN proceedsemitted
	ON proceedsemitted.idinc = incomevar.idinc 
	AND proceedsemitted.ymov = @ayear
LEFT OUTER JOIN finlink 
	ON finlink.idchild = proceedsemitted.idfin AND 
	finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = proceedsemitted.idfin 
	AND FL.nlevel = @level_input
JOIN upb
	ON upb.idupb = proceedsemitted.idupb
WHERE incomevar.yvar = @ayear
	AND (proceedsemitted.flagarrear = 'R')
	AND incomevar.adate <= @adate
	AND (@idfin IS NULL OR isnull(FL.idparent, proceedsemitted.idfin) = @idfin)
	AND (proceedsemitted.idupb like @idupb) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY proceedsemitted.idupb, ISNULL(finlink.idparent,proceedsemitted.idfin)

UPDATE #income
SET
finvar_prevision = ISNULL((SELECT #finvar_prevision.amount 
			FROM #finvar_prevision
			WHERE #finvar_prevision.idupb = #income.idupb and 
				#finvar_prevision.idfin = #income.idfin), 0.0),
finvar_secondaryprev = ISNULL((SELECT #finvar_secondaryprev.amount 
			FROM #finvar_secondaryprev
			WHERE #finvar_secondaryprev.idupb = #income.idupb and 
				#finvar_secondaryprev.idfin = #income.idfin), 0.0),
assessment_C =ISNULL((SELECT #assessment_C.amount 
			FROM #assessment_C
			WHERE #assessment_C.idupb = #income.idupb and
				#assessment_C.idfin = #income.idfin), 0.0),
var_assessment_C =ISNULL((SELECT #var_assessment_C.amount 
			FROM #var_assessment_C
			WHERE #var_assessment_C.idupb = #income.idupb and
				#var_assessment_C.idfin = #income.idfin), 0.0),
proceed_C =ISNULL((SELECT #proceed_C.amount 
			FROM #proceed_C
			WHERE #proceed_C.idupb = #income.idupb and 
				#proceed_C.idfin = #income.idfin), 0.0),
var_proceed_C =ISNULL((SELECT #var_proceed_C.amount 
			FROM #var_proceed_C
			WHERE #var_proceed_C.idupb = #income.idupb and 
				#var_proceed_C.idfin = #income.idfin), 0.0),
assessment_R =ISNULL((SELECT #assessment_R.amount 
			FROM #assessment_R
			WHERE #assessment_R.idfin = #income.idfin and 
				#assessment_R.idupb = #income.idupb), 0.0),
var_assessment_R =ISNULL((SELECT #var_assessment_R.amount 
			FROM #var_assessment_R
			WHERE #var_assessment_R.idupb = #income.idupb and 
				#var_assessment_R.idfin = #income.idfin), 0.0),
proceed_R =ISNULL((SELECT #proceed_R.amount 
			FROM #proceed_R
			WHERE #proceed_R.idupb = #income.idupb and 
				#proceed_R.idfin = #income.idfin), 0.0),
var_proceed_R = ISNULL((SELECT #var_proceed_R.amount 
			FROM #var_proceed_R
			WHERE #var_proceed_R.idupb = #income.idupb and 
				#var_proceed_R.idfin = #income.idfin), 0.0),
	
codeupb = (select upb.codeupb from upb 
			where upb.idupb = #income.idupb),
upb = (select upb.title from upb 
			where upb.idupb = #income.idupb),
upbprintingorder = (select upb.printingorder from upb 
			where upb.idupb = #income.idupb)
	
DECLARE @levelusable	tinyint
SELECT 	@levelusable = MIN(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear AND (flag&2)<>0

IF (@showupb = 'S')
Begin
	IF (@codelevel >= @levelusable)
	BEGIN	
		UPDATE #income
		SET initialprevisioncomp= ISNULL((SELECT finyear.prevision 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					where finyear.idupb = #income.idupb AND 
						finyear.idfin = #income.idfin),0.0),
			initialprevisioncassa = ISNULL((SELECT finyear.secondaryprev 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					where finyear.idupb = #income.idupb AND 
						finyear.idfin = #income.idfin),0.0)
	END 
	ELSE 
	BEGIN
		UPDATE #income
		SET initialprevisioncomp = ISNULL((SELECT SUM(isnull(finyear.prevision,0.0)) 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin 
					WHERE finyear.idupb = #income.idupb  
						AND ISNULL(finlink.idparent,finyear.idfin) = #income.idfin
						AND fin.nlevel = @levelusable),0.0),
		initialprevisioncassa = ISNULL((SELECT SUM(isnull(finyear.secondaryprev,0.0)) 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin 
					WHERE finyear.idupb = #income.idupb  
					AND ISNULL(finlink.idparent,finyear.idfin) = #income.idfin
					AND fin.nlevel = @levelusable),0.0)
	END
End

UPDATE #income
SET
/* Disp.dell' Accertamento per ulteriori mov. di fase successiva=
  Accertamento + Var.Accertamento alla data - (Incassi + Var. Incassi)
*/
	assessment_available = 
		assessment_amount 
		+ ISNULL((SELECT SUM(amount)
		FROM incomevar
		join income on incomevar.idinc = income.idinc
		WHERE incomevar.idinc= #income.nassessment
			and incomevar.adate between @firstday and @adate
			and incomevar.yvar = @ayear
			and income.nphase  = @nfinphase
			and #income.nvarassessment is null
		),0) 
		- ISNULL((SELECT SUM(incomeyear.amount)
			from incomeyear
		JOIN  income I					 
			ON I.idinc = incomeyear.idinc  
		JOIN incomelink ilk1
			ON ilk1.idchild = I.idinc AND ilk1.nlevel = @nfinphase
		where ilk1.idparent = #income.nassessment
			AND I.nphase = @nfinphase+1
			AND incomeyear.ayear =@ayear
			and #income.nvarassessment is null -- deve aggiornare solo le righe degli impegni
		),0)
		- ISNULL((SELECT SUM(incomevar.amount)
		FROM incomevar
		JOIN  income I					 
			ON I.idinc = incomevar.idinc  
		JOIN incomelink ilk1
			ON ilk1.idchild = I.idinc AND ilk1.nlevel = @nfinphase
		WHERE ilk1.idparent = #income.nassessment
			and incomevar.adate between @firstday and @adate
			and incomevar.yvar = @ayear
			AND I.nphase = @nfinphase+1
			and #income.nvarassessment is null
		),0)	


/*
UPDATE #income
	SET
	assessment_amount = assessment_amount + 
				(SELECT ISNULL(SUM(amount),0.0) 
				   FROM incomevar
				   JOIN income 
				     ON income.idinc = incomevar.idinc
				  WHERE income.idinc = #income.nassessment
				    AND incomevar.adate <= @adate
				    AND incomevar.yvar = @ayear
				    AND income.nphase   = @nfinphase),
	proceed_amount = proceed_amount + 
				(SELECT ISNULL(SUM(amount),0.0) 
				   FROM incomevar
				   JOIN income 
				     ON income.idinc = incomevar.idinc
				  WHERE income.idinc = #income.nproceed
				    AND incomevar.adate <= @adate
				    AND incomevar.yvar = @ayear
				    AND income.nphase = @maxincomephase
				),
	reportdate = @adate,
	ayear = @ayear*/

DELETE FROM #income
WHERE nphase <> @nfinphase AND nphase <> @maxincomephase
------------------------------------------- <	     NEW        > ----------------------------------------------------------------
-- SE ho scelto di totalizzare i figli dell'UPB selezionato (N, 'pippo',S)
-- O SE ho scelto di non vedere l'upb (N,N)  
-- ALLORA totalizzo gli importi
-- Se ho scelto di vedere l'upb (con o senza figli :  S/N o S/S) saranno presi i valori calcolati sopra 
-- che saranno stati calcolati distinguendo gli upb-padri dagli upb-figli.

IF (@showupb <>'S') 
Begin
	UPDATE #income set 
	finvar_prevision =(SELECT SUM(ISNULL(#finvar_prevision.amount,0.0)) 
				FROM #finvar_prevision
				WHERE #finvar_prevision.idupb like @idupb and 
				#finvar_prevision.idfin = #income.idfin),
	finvar_secondaryprev = (SELECT SUM(ISNULL(#finvar_secondaryprev.amount,0.0))  
				FROM #finvar_secondaryprev
				WHERE #finvar_secondaryprev.idupb like @idupb and 
				#finvar_secondaryprev.idfin = #income.idfin),
	assessment_C = (SELECT SUM(ISNULL( #assessment_C.amount,0.0)) 
				FROM #assessment_C
				WHERE #assessment_C.idupb like @idupb and
				#assessment_C.idfin = #income.idfin), 
	var_assessment_C = (SELECT SUM(ISNULL( #var_assessment_C.amount,0.0))  
				FROM #var_assessment_C
				WHERE #var_assessment_C.idupb like @idupb and
				#var_assessment_C.idfin = #income.idfin), 
	proceed_C =(SELECT SUM(ISNULL( #proceed_C.amount,0.0))  
				FROM #proceed_C
				WHERE #proceed_C.idupb like @idupb and 
				#proceed_C.idfin = #income.idfin),
	var_proceed_C =(SELECT SUM(ISNULL( #var_proceed_C.amount,0.0))  
				FROM #var_proceed_C
				WHERE #var_proceed_C.idupb like @idupb and 
				#var_proceed_C.idfin = #income.idfin), 
  	assessment_R =(SELECT SUM(ISNULL( #assessment_R.amount,0.0)) 
				FROM #assessment_R
				WHERE #assessment_R.idupb like @idupb and 
				#assessment_R.idfin = #income.idfin ), 
	var_assessment_R =(SELECT SUM(ISNULL( #var_assessment_R.amount,0.0))  
				FROM #var_assessment_R
				WHERE #var_assessment_R.idupb like @idupb and 
				#var_assessment_R.idfin = #income.idfin), 
	proceed_R =(SELECT SUM(ISNULL( #proceed_R.amount,0.0))  
				FROM #proceed_R
				WHERE #proceed_R.idupb like @idupb and 
				#proceed_R.idfin = #income.idfin), 
	var_proceed_R = (SELECT SUM(ISNULL( #var_proceed_R.amount,0.0))  
				FROM #var_proceed_R
				WHERE #var_proceed_R.idupb like @idupb and 
				#var_proceed_R.idfin = #income.idfin)
	IF @codelevel >= @levelusable
	BEGIN	
		UPDATE #income
		SET	
		initialprevisioncomp= (SELECT SUM(ISNULL(finyear.prevision,0.0))  
					FROM finyear
					JOIN fin
					ON finyear.idfin = fin.idfin
					JOIN upb
					ON finyear.idupb = upb.idupb
					where finyear.idupb like @idupb AND 
					finyear.idfin = #income.idfin
					),
	  
		initialprevisioncassa = (SELECT SUM(ISNULL(finyear.secondaryprev,0.0))  
					FROM finyear
					JOIN fin
					ON finyear.idfin = fin.idfin
					JOIN upb
					ON finyear.idupb = upb.idupb
					where upb.idupb like @idupb AND 
					fin.idfin = #income.idfin
					)
		END 
	ELSE 
	BEGIN
		UPDATE #income
		SET 
		initialprevisioncomp= (SELECT SUM(ISNULL(finyear.prevision,0.0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin
					WHERE finyear.idupb like @idupb  
					AND ISNULL(finlink.idparent,finyear.idfin) = #income.idfin
					AND fin.nlevel = @levelusable),
	  
		initialprevisioncassa = (SELECT SUM(ISNULL(finyear.secondaryprev,0.0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin
					WHERE upb.idupb like @idupb  
					AND ISNULL(finlink.idparent,finyear.idfin) = #income.idfin
					AND fin.nlevel = @levelusable)
	END
End
-- cancello le righe dei figli di @idupboriginal aventi idassessment = NULL
-- Se ho scelto l'upb ne cancello i figli perchè li ho totalizzati tramite la nuova UPDATE
IF (@showupb <>'S') and (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		DELETE FROM #income WHERE idassessment is null 
						AND substring(idupb,1,len(@idupboriginal))= @idupboriginal 	
						AND idupb <>@idupboriginal
-- cancello solo le righe che sono upb-figli aventi idassessment = NULL
-- Se non ho scelto alcun upb cancello solo gli upb-figli perchè li ho totalizzati tramite la nuova UPDATE
IF (@showupb <>'S') 
		DELETE FROM #income WHERE idassessment IS NULL 
			AND EXISTS (SELECT * FROM #income  R 
				join upb U on U.idupb=R.idupb  WHERE U.paridupb= #income.idupb)
	 
---------------------------------------------------------------------------------------------------------------
		
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

update #income set proceed_amount = 0 where nphase <> @maxincomephase

if (@suppressifblank = 'S') and @codelevel>2	--> se la stampa è x un livello sottostante la categoria cancella le righe
	BEGIN
		DELETE FROM  #income   
		WHERE  
		(ISNULL(initialprevisioncomp,0.0)= 0 AND 
		ISNULL(initialprevisioncassa,0.0)= 0 AND 
		ISNULL(finvar_prevision,0.0)= 0 AND
		ISNULL(finvar_secondaryprev,0.0)= 0 AND
		ISNULL(assessment_C,0.0) = 0 AND
		ISNULL(var_assessment_C,0.0)= 0 AND
		ISNULL(proceed_C,0.0)= 0) and
		ISNULL(var_proceed_C,0.0)= 0 AND
		ISNULL(assessment_R,0.0)= 0 AND
		ISNULL(var_assessment_R,0.0)= 0 AND
		ISNULL(proceed_R,0.0)= 0 AND
		ISNULL(var_proceed_R,0.0)= 0 AND
		ISNULL(assessment_amount,0.0)=0 AND
		ISNULL(assessment_available,0.0)=0 AND
		ISNULL(proceed_amount,0.0)=0
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
WHERE #income.npro = proceedsview.npro
	AND proceedsview.ypro = @ayear

DECLARE @finphase varchar(50)
DECLARE @maxphase varchar(50)

select @finphase = description from  incomephase where nphase = @nfinphase
select @maxphase = description from  incomephase where nphase = @maxincomephase


IF (@showupb <>'S')
BEGIN
	SELECT  
		#income.idfin,
		F.codefin,
		F.title as fintitle,
		F.printingorder as finprintingorder,
		codeupb			,
		idupb 			,
		upb   			,
		upbprintingorder	,
		nphase		,
		rowkind		,
		isnull(initialprevisioncomp,0.0)	as  initialprevisioncomp,
		isnull(initialprevisioncassa,0.0) as initialprevisioncassa,
		(isnull(finvar_prevision,0.0)) as finvar_prevision,
		(isnull(finvar_secondaryprev,0.0)) as finvar_secondaryprev,
		(isnull(assessment_C,0.0)) as assessment_C,
		(isnull(var_assessment_C,0.0)) as var_assessment_C,
		(isnull(proceed_C,0.0)) as proceed_C,
		(isnull(var_proceed_C,0.0)) as var_proceed_C,
		(isnull(assessment_R,0.0)) as assessment_R,
		(isnull(var_assessment_R,0.0)) as var_assessment_R,
		(isnull(proceed_R,0.0)) as proceed_R,
		(isnull(var_proceed_R,0.0)) as var_proceed_R,
		adate,
		description,
		REG.title as registry,
		nassessment,
		ymovassessment,
		nmovassessment,	
		yvarassessment,
		nvarassessment,	
		(isnull(assessment_amount,0.0)) as assessment_amount,
		(isnull(origin_assessment_amount,0.0)) as origin_assessment_amount,
		(isnull(assessment_available,0.0)) as assessment_available,
		nproceed,
		ymovproceed,
		nmovproceed,	
		yvarproceed,
		nvarproceed,	
		(isnull(proceed_amount,0.0)) as proceed_amount,
		npro,
		flagarrear,
		@adate as reportdate,
		@ayear as ayear,
		idassessment,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@maxincomephase as maxincomephase,
		@nfinphase as nfinphase,
		@finphase AS finphase,
		@maxphase AS maxphase,
		@fin_kind AS 'fin_kind'
	FROM  #income
	JOIN fin F
		ON #income.idfin = F.idfin
	LEFT OUTER JOIN registry REG 	 
		ON REG.idreg = #income.idreg
	GROUP BY
		upbprintingorder,F.printingorder,#income.idfin,F.codefin,F.title,codeupb,idupb,upb,nphase,
		rowkind	,adate,description,REG.title,nassessment,nproceed,npro,flagarrear,
		reportdate,#income.ayear,idassessment,initialprevisioncomp,initialprevisioncassa,
		finvar_prevision, finvar_secondaryprev,assessment_C, var_assessment_C, proceed_C,
		var_proceed_C,assessment_R,var_assessment_R,proceed_R,var_proceed_R,	
		assessment_amount,origin_assessment_amount,assessment_available,proceed_amount,
		ymovassessment, nmovassessment,	ymovproceed, nmovproceed,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		yvarproceed,nvarproceed,yvarassessment,nvarassessment		
	ORDER BY upbprintingorder, F.printingorder, rowkind, adate,nvarassessment,nvarproceed
END
ELSE
BEGIN
	SELECT 
		#income.idfin		,
		F.codefin		,
		F.title as fintitle	,
		F.printingorder as finprintingorder	,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		nphase,
		rowkind,
		initialprevisioncomp,
		initialprevisioncassa,
		finvar_prevision,
		finvar_secondaryprev,
		assessment_C,
		var_assessment_C,
		proceed_C,
		var_proceed_C,
		assessment_R,
		var_assessment_R,
		proceed_R,
		var_proceed_R,
		adate,
		description,
		REG.title as registry,
		nassessment,
		ymovassessment,
		nmovassessment,	
		yvarassessment,
		nvarassessment,	
		assessment_amount,
		origin_assessment_amount,
		assessment_available,
		nproceed,
		ymovproceed,
		nmovproceed,	
		yvarproceed,
		nvarproceed,	
		proceed_amount,
		npro,
		flagarrear,	
		@adate as reportdate,
		@ayear as ayear,
		idassessment,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@maxincomephase as maxincomephase,
		@nfinphase as nfinphase,
		@finphase AS finphase,
		@maxphase AS maxphase,
		@fin_kind AS 'fin_kind'
	FROM  #income
	JOIN fin F
		ON #income.idfin = F.idfin
	LEFT OUTER JOIN registry REG	
		ON REG.idreg = #income.idreg
	ORDER BY upbprintingorder, F.printingorder, rowkind, adate,nvarassessment,nvarproceed
END
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
