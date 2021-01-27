
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sit_residui_per_anno_dett]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sit_residui_per_anno_dett]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [rpt_sit_residui_per_anno_dett]
	@ayear 		int,
	@date		datetime,
	@finpart 	char(1),
	@levelusable 	tinyint,
	@idupb		varchar(36),
	@showupb 	char(1),
	@showchildupb 	char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
BEGIN


/* PRELEVATA DAL DB DI BARI IN DATA 16 11 2012*/
DECLARE @finphase		tinyint
DECLARE @cash_phase		tinyint
DECLARE @idupboriginal 		varchar(36)
DECLARE @regphase int
DECLARE @namephase varchar(150)
		
CREATE TABLE #report_residual
(
	ayear				int,
	codeupb				varchar(50),
	idupb 				varchar(36),
	upb   				varchar(150),
	upbprintingorder	varchar(50),
	idfin				int,
	codefin				varchar(50),
	title				varchar(150),
	finprintingorder	varchar(50),
	initial_residual	decimal(19,2),
	var_residual		decimal(19,2),
	cash_residual		decimal(19,2),
	var_cash_residual	decimal(19,2),
	ymov				int,
	nmov				int,
	description			varchar(150),
	registry			varchar(150)
)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') set @idupb=@idupb + '%' 
CREATE TABLE #initial_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2), nmov int, ymov int, description varchar(150), registry varchar(150))
CREATE TABLE #var_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2), nmov int, ymov int, description varchar(150), registry varchar(150))
CREATE TABLE #cash_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2), nmov int, ymov int, description varchar(150), registry varchar(150))
CREATE TABLE #var_cash_residual
    	(ayear int, idfin int, idupb varchar(36), total decimal(19,2), nmov int, ymov int, description varchar(150), registry varchar(150))

DECLARE @cashvaliditykind int
SELECT	@cashvaliditykind = cashvaliditykind
FROM 	config
WHERE 	ayear = @ayear
IF @finpart = 'E'
	BEGIN
		SELECT @finphase = assessmentphasecode
		FROM config
		WHERE ayear = @ayear
		IF @finphase IS NULL
			BEGIN
				SELECT @finphase = incomefinphase
				FROM uniconfig
			END
		SELECT @cash_phase = MAX(nphase)
		FROM incomephase
		SELECT @regphase = incomeregphase FROM uniconfig
		SELECT @namephase = description FROM incomephase where nphase = @finphase
	END
ELSE
	BEGIN
		SELECT @finphase = appropriationphasecode
			FROM config
			WHERE ayear = @ayear
		IF @finphase IS NULL
			BEGIN
				SELECT @finphase = expensefinphase
				FROM uniconfig
			END
		SELECT @cash_phase = MAX(nphase)
		FROM expensephase
		SELECT @regphase = expenseregphase FROM uniconfig
		SELECT @namephase = description FROM expensephase where nphase = @finphase
	END
IF @finpart = 'E'
BEGIN
	INSERT INTO #initial_residual																		
		(
		ayear,
		idfin,
		idupb,
		total,
		ymov,
		nmov,
		description,
		registry
		)
	SELECT 
		income.ymov,
		ISNULL(finlink.idparent,incomeyear.idfin), 
		incomeyear.idupb,
		ISNULL(incomeyear.amount, 0.0),
		income.ymov,
		income.nmov,
		income.description,--I2.description,
		R.title
	FROM incomeyear
	JOIN income
		ON income.idinc = incomeyear.idinc
	JOIN upb U
		ON incomeyear.idupb = U.idupb
	LEFT OUTER JOIN finlink
		ON finlink.idchild = incomeyear.idfin  AND finlink.nlevel = @levelusable
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear 
	JOIN incomelink IL1
		ON income.idinc = IL1.idchild
		AND income.nphase = @finphase
	LEFT OUTER JOIN  incomelink IL2
		ON IL1.idchild = IL2.idchild
		AND IL2.nlevel = @regphase
	LEFT OUTER JOIN   income I2
		ON I2.idinc = IL2.idchild
	LEFT OUTER JOIN   registry R
		ON I2.idreg = R.idreg							
	WHERE incomeyear.ayear = @ayear
		AND (incomeyear.idupb like @idupb )
		AND income.adate <= @date
		AND ((incometotal.flag&1) = 1) -- Residuo
		AND income.nphase = @finphase
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)

	INSERT INTO #var_residual
		(
		ayear,
		idfin,
		idupb,
		total,
		ymov,
		nmov,
		description,
		registry
		)
	SELECT 
		income.ymov,
		ISNULL(finlink.idparent,incomeyear.idfin), 
		incomeyear.idupb,
		ISNULL(incomevar.amount, 0.0),
		income.ymov,
		income.nmov,
		income.description,--I2.description,
		R.title
	FROM incomevar
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
		AND incomeyear.ayear = @ayear
	JOIN income
		ON incomeyear.idinc = income.idinc
	JOIN upb U
		ON incomeyear.idupb = U.idupb
	LEFT OUTER JOIN finlink
		ON finlink.idchild = incomeyear.idfin  AND finlink.nlevel = @levelusable
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear	
	JOIN incomelink IL1
		ON income.idinc = IL1.idchild
		AND income.nphase = @finphase
	LEFT OUTER JOIN  incomelink IL2
		ON IL1.idchild = IL2.idchild
		AND IL2.nlevel = @regphase
	LEFT OUTER JOIN  income I2
		ON I2.idinc = IL2.idchild
	LEFT OUTER JOIN  registry R
		ON I2.idreg = R.idreg			
	WHERE incomevar.yvar = @ayear
		AND incomevar.adate <= @date 
		and (incomeyear.idupb like @idupb )
		AND ((incometotal.flag&1) = 1) -- Residuo
		AND income.nphase = @finphase
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	
	INSERT INTO #cash_residual
		(
		ayear,
		idfin,
		idupb,
		total,
		ymov,
		nmov,
		description,
		registry
		)
	SELECT 
		I.ymov,
		ISNULL(FL1.idparent,IY.idfin), 
		IY.idupb,
		HPV.amount,
		I.ymov,
		I.nmov,
		I.description,
		R.title
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON IY.idinc = HPV.idinc
		AND HPV.ymov = @ayear
	JOIN incomelink IL 
		ON IL.idchild = IY.idinc AND IL.nlevel = @finphase
	JOIN income I
		ON IL.idparent = I.idinc 
	JOIN upb U
		ON IY.idupb = U.idupb
	LEFT OUTER JOIN finlink  FL1
		ON FL1.idchild = IY.idfin AND FL1.nlevel = @levelusable
	LEFT OUTER JOIN  incomelink IL2
		ON IL.idchild = IL2.idchild
		AND IL2.nlevel = @regphase
	LEFT OUTER JOIN  income I2
		ON I2.idinc = IL2.idchild
	LEFT OUTER JOIN  registry R
		ON I2.idreg = R.idreg	
	WHERE HPV.competencydate <= @date
		AND IY.idupb LIKE @idupb 
		AND IY.ayear = @ayear
		AND HPV.flagarrear = 'R'
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)

	IF @cashvaliditykind <> 4
	BEGIN
		INSERT INTO #var_cash_residual
		    	(
			 	ayear,
		    	idfin,
				idupb,
		    	total,
				ymov,
				nmov,
				description,
				registry
		    	)
		SELECT 
			I.ymov,
			ISNULL(FL1.idparent,IY.idfin),
			IY.idupb,
			ISNULL(IV.amount, 0.0),
			I.ymov,
			I.nmov,
			I1.description,
			R.title
		FROM incomevar IV
		JOIN incomeyear IY
			ON  IY.idinc = IV.idinc
			AND IY.ayear = @ayear
		JOIN incomelink IL 
			ON IL.idchild = IY.idinc AND IL.nlevel = @finphase
		JOIN upb U
			ON IY.idupb = U.idupb
		LEFT OUTER JOIN finlink  FL1
			ON FL1.idchild = IY.idfin AND FL1.nlevel = @levelusable
		JOIN income I
			ON I.idinc = IL.idparent
		JOIN income I1
			ON I1.idinc = IY.idinc 
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
			AND HPV.ymov = @ayear
		LEFT OUTER JOIN  incomelink IL2
			ON IL.idchild = IL2.idchild
			AND IL2.nlevel = @regphase
		LEFT OUTER JOIN  income I2
			ON I2.idinc = IL2.idchild
		LEFT OUTER JOIN  registry R
			ON I2.idreg = R.idreg	
		WHERE IV.yvar = @ayear
			AND IV.adate <= @date
			AND IY.idupb like @idupb
			AND HPV.flagarrear = 'R'
			AND HPV.competencydate <= @date
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	END
END
IF @finpart = 'S'
BEGIN
	INSERT INTO #initial_residual
		(
		ayear,
		idfin,
		idupb,
		total,
		ymov,
		nmov,
		description,
		registry
		)
	SELECT 
		expense.ymov,
		ISNULL(finlink.idparent,expenseyear.idfin), 
		expenseyear.idupb,
		ISNULL(expenseyear.amount, 0.0),
		expense.ymov,
		expense.nmov,
		expense.description,--E2.description,
		R.title
	FROM expenseyear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	JOIN upb U
		ON expenseyear.idupb = U.idupb
	LEFT OUTER JOIN finlink
		ON finlink.idchild = expenseyear.idfin  AND finlink.nlevel = @levelusable
	JOIN expensetotal
		ON  expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear	
	JOIN expenselink EL1
		ON expense.idexp = EL1.idchild
		AND expense.nphase = @finphase
	LEFT OUTER JOIN  expenselink EL2
		ON EL1.idchild = EL2.idchild
		AND EL2.nlevel = @regphase
	LEFT OUTER JOIN  expense E2
		ON E2.idexp = EL2.idchild
	LEFT OUTER JOIN  registry R
		ON E2.idreg = R.idreg				
	WHERE expenseyear.ayear = @ayear
		AND (expenseyear.idupb like @idupb )
		AND ((expensetotal.flag&1) = 1) -- Residuo
		AND expense.nphase = @finphase
		AND expense.adate <= @date
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)

	INSERT INTO #var_residual
		(
		ayear,
		idfin,idupb,
		total,
		ymov,
		nmov,
		description,
		registry
		)
	SELECT 
	  	expense.ymov,
		ISNULL(finlink.idparent,expenseyear.idfin), 
		expenseyear.idupb,
		ISNULL(expensevar.amount, 0.0),
		expense.ymov,
		expense.nmov,
		expense.description,--E2.description,
		R.title
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = @ayear
	JOIN expense
		ON expenseyear.idexp = expense.idexp
	JOIN upb U
		ON expenseyear.idupb = U.idupb
	LEFT OUTER JOIN finlink
		ON finlink.idchild = expenseyear.idfin  AND finlink.nlevel = @levelusable
	JOIN expensetotal
		ON  expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear	
	JOIN expenselink EL1
		ON expense.idexp = EL1.idchild
		AND expense.nphase = @finphase
	LEFT OUTER JOIN  expenselink EL2
		ON EL1.idchild = EL2.idchild
		AND EL2.nlevel = @regphase
	LEFT OUTER JOIN  expense E2
		ON E2.idexp = EL2.idchild
	LEFT OUTER JOIN  registry R
		ON E2.idreg = R.idreg				
	WHERE expensevar.yvar = @ayear
		AND (expenseyear.idupb like @idupb )
		AND expensevar.adate <= @date 
		AND ((expensetotal.flag&1) = 1) -- Residuo
		AND expense.nphase = @finphase
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	
	INSERT INTO #cash_residual
		(
		ayear,
		idfin,
		idupb,
		total,
		ymov,
		nmov,
		description,
		registry
		)
	SELECT 
		E.ymov,
		ISNULL(FL1.idparent,EY.idfin), 
		EY.idupb,
		HPV.amount,
		E.ymov,
		E.nmov,
		E2.description,
		R.title
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON  EY.idexp = HPV.idexp
		AND HPV.ymov = @ayear
	JOIN expenselink EL 
		ON EL.idchild = EY.idexp AND EL.nlevel = @finphase
	JOIN upb U
		ON EY.idupb = U.idupb
	LEFT OUTER JOIN finlink  FL1
		ON FL1.idchild = EY.idfin AND FL1.nlevel = @levelusable
	JOIN expense E
		ON EL.idparent = E.idexp
	JOIN expense E1
		ON EY.idexp = E1.idexp 
	LEFT OUTER JOIN  expenselink EL2
		ON EL.idchild = EL2.idchild
		AND EL2.nlevel = @regphase
	LEFT OUTER JOIN  expense E2
		ON E2.idexp = EL2.idchild
	LEFT OUTER JOIN  registry R
		ON E2.idreg = R.idreg		
	WHERE 	HPV.competencydate <= @date
		AND EY.idupb like @idupb
		AND EY.ayear = @ayear
		AND (HPV.flagarrear = 'R')
		AND E1.nphase = @cash_phase
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	
	IF @cashvaliditykind <> 4
	BEGIN
		INSERT INTO #var_cash_residual
		    (
			ayear,
			idfin,
			idupb,
			total,
			ymov,
			nmov,
			description,
			registry
		    )
		SELECT  
			E.ymov,
			ISNULL(FL1.idparent,EY.idfin),
			EY.idupb,
			ISNULL(EV.amount, 0.0),
			E.ymov,
			E.nmov,
			E2.description,
			R.title
		FROM expensevar EV
		JOIN expenseyear EY 
			ON EY.idexp = EV.idexp
			AND EY.ayear = @ayear
		JOIN expenselink EL 
			ON EL.idchild = EY.idexp AND EL.nlevel = @finphase
		JOIN finlink  FL1
			ON FL1.idchild = EY.idfin AND FL1.nlevel = @levelusable
		JOIN expense E
			ON EL.idparent = E.idexp
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN expense E1
			ON EY.idexp = E1.idexp 
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
			AND HPV.ymov = @ayear
		LEFT OUTER JOIN  expenselink EL2
			ON EL.idchild = EL2.idchild
			AND EL2.nlevel = @regphase
		LEFT OUTER JOIN  expense E2
			ON E2.idexp = EL2.idchild
		LEFT OUTER JOIN  registry R
			ON E2.idreg = R.idreg		
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND (HPV.flagarrear = 'R')
			AND E1.nphase = @cash_phase
			AND HPV.competencydate <= @date
			AND (EY.idupb like @idupb )
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	END
END
	
INSERT INTO #report_residual(ayear, idfin,idupb,ymov, nmov, description, registry)
SELECT distinct ayear,idfin,idupb ,ymov, nmov, description, registry
	FROM #initial_residual

INSERT INTO #report_residual(ayear, idfin,idupb,ymov, nmov, description, registry)
SELECT  distinct ayear,idfin,idupb ,ymov, nmov, description, registry
FROM #var_residual
WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #var_residual.idfin
		and i1.idupb = #var_residual.idupb
		and i1.ayear = #var_residual.ayear
		AND i1.ymov = #var_residual.ymov
		AND i1.nmov = #var_residual.nmov
		)
/*	WHERE (	
		#var_residual.idfin	
		) 
		NOT IN (
			SELECT #report_residual.idfin  
			FROM #report_residual	
			)
*/

INSERT INTO #report_residual (ayear, idfin,idupb,ymov, nmov, description, registry)
SELECT  distinct ayear,idfin,idupb,ymov, nmov, description, registry
FROM #cash_residual
WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #cash_residual.idfin
		and i1.idupb = #cash_residual.idupb
		and i1.ayear = #cash_residual.ayear
		AND i1.ymov = #cash_residual.ymov
		AND i1.nmov = #cash_residual.nmov
		)
/*	WHERE (
		#cash_residual.idfin
		) 
		NOT IN (
			SELECT idfin  
			FROM #report_residual
			)*/
INSERT INTO #report_residual(ayear, idfin, idupb, ymov, nmov, description, registry)
SELECT distinct ayear,idfin ,idupb,ymov, nmov, description, registry
FROM #var_cash_residual
WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #var_cash_residual.idfin
		and i1.idupb = #var_cash_residual.idupb
		and i1.ayear = #var_cash_residual.ayear
		AND i1.ymov = #var_cash_residual.ymov
		AND i1.nmov = #var_cash_residual.nmov
		)
/*	WHERE (
		#var_cash_residual.idfin
		) 
		NOT IN (
			SELECT idfin  
			FROM #report_residual
			)
*/


UPDATE #report_residual 
SET initial_residual = ISNULL((SELECT SUM(#initial_residual.total) FROM #initial_residual
		WHERE #initial_residual.idfin = #report_residual.idfin
		and #initial_residual.idupb = #report_residual.idupb
		AND #initial_residual.ayear = #report_residual.ayear
		AND #initial_residual.ymov = #report_residual.ymov
		AND #initial_residual.nmov = #report_residual.nmov), 0.0)


UPDATE #report_residual 
SET var_residual = ISNULL((SELECT SUM(#var_residual.total) FROM #var_residual
		WHERE #var_residual.idfin = #report_residual.idfin
		and #var_residual.idupb = #report_residual.idupb
		AND #var_residual.ayear = #report_residual.ayear
		AND #var_residual.ymov = #report_residual.ymov
		AND #var_residual.nmov = #report_residual.nmov), 0.0)

UPDATE #report_residual
SET cash_residual =
		ISNULL((SELECT SUM(#cash_residual.total) FROM #cash_residual
		WHERE #cash_residual.idfin = #report_residual.idfin
		and #cash_residual.idupb = #report_residual.idupb
		AND #cash_residual.ayear = #report_residual.ayear
		AND #cash_residual.ymov = #report_residual.ymov
		AND #cash_residual.nmov = #report_residual.nmov), 0.0)

UPDATE #report_residual
SET var_cash_residual =	ISNULL((SELECT SUM(#var_cash_residual.total) FROM #var_cash_residual
		WHERE #var_cash_residual.idfin = #report_residual.idfin
		and #var_cash_residual.idupb = #report_residual.idupb
		AND #var_cash_residual.ayear = #report_residual.ayear
		AND #var_cash_residual.ymov = #report_residual.ymov
		AND #var_cash_residual.nmov = #report_residual.nmov), 0.0)

	UPDATE #report_residual SET title = fin.title ,
			finprintingorder = fin.printingorder,
			codefin = fin.codefin	
		 	from fin where fin.idfin = #report_residual.idfin
	UPDATE #report_residual SET codeupb = upb.codeupb ,
			upbprintingorder = upb.printingorder,			
			upb = upb.title
		 from upb where upb.idupb = #report_residual.idupb

	IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
			UPDATE #report_residual SET  
				upbprintingorder = (SELECT TOP 1 upbprintingorder
					FROM #report_residual
					WHERE idupb = @idupboriginal),
				upb = (SELECT TOP 1 upb
					FROM #report_residual
					WHERE idupb = @idupboriginal),
				idupb = @idupboriginal,
				codeupb =(SELECT TOP 1 codeupb
					FROM #report_residual	
					WHERE idupb = @idupboriginal)
	
	IF (@showupb <>'S') and (@idupboriginal = '%') 
				UPDATE #report_residual SET  
				upbprintingorder = null	,
				upb =  null,
				idupb = null,
				codeupb = null
IF (@showupb <>'S') 
BEGIN
	SELECT 
		ayear,
		idfin,
		codefin,
		title,
		finprintingorder,
		codeupb,		
		idupb,	
		upb,
		upbprintingorder,
		SUM(ISNULL(initial_residual,0.0)) 	as 'initial_residual',
		SUM(ISNULL(var_residual,0.0)) 		as 'var_residual',
		SUM(ISNULL(cash_residual,0.0)) 		as 'cash_residual',
		SUM(ISNULL(var_cash_residual,0.0)) 	as 'var_cash_residual',
		ymov,
		nmov,
		description,
		registry,
		@namephase as 'namephase'
	FROM #report_residual
	GROUP BY ayear,
		idfin,
		codefin,
		title,
		finprintingorder,
		codeupb,		
		idupb,	
		upb,
		upbprintingorder,ymov,
		nmov,
		description,
		registry
 				ORDER BY ayear ASC,finprintingorder ASC
END 
ELSE
	SELECT 
		ayear,
		idfin,
		codefin,
		title,
		finprintingorder,
		codeupb,		
		idupb,	
		upb,
		upbprintingorder,
		initial_residual,
		var_residual,
		cash_residual,
		var_cash_residual,
		ymov,
		nmov,
		description,
		registry,
		@namephase as 'namephase'
	FROM #report_residual
	ORDER BY ayear ASC,finprintingorder ASC
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
