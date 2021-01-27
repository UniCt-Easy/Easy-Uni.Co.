
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sit_residui_di_competenza]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sit_residui_di_competenza]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [rpt_sit_residui_di_competenza]
	@ayear 		int,
	@date		datetime,
	@finpart 	char(1),
	@levelusable 	tinyint,
	@idupb		varchar(36),
	@showupb 	char(1),
	@showchildupb 	char(1)
AS
BEGIN
/*Questa sp viene aggiunta a SVN copiandola dal DB Uniroma4, perchè assente sia su SVN che nella nostra cartella di LU. Task 7164*/

/* PRELEVATA DAL DB DI BARI IN DATA 16 11 2012*/
-- [amministrazione].[rpt_sit_residui_di_competenza] 2014,{ts '2014-12-31 00:00:00'},'S','5','%','S','S'
DECLARE @finphase		tinyint
DECLARE @cash_phase		tinyint
DECLARE @idupboriginal 		varchar(36)
DECLARE @regphase int
DECLARE @namephase varchar(150)
DECLARE @Txt1 VARCHAR(MAX)
SET @Txt1=''		

CREATE TABLE #report_residual
(
	ayear				int,
	idexp1				int,
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
	initial_fase2		decimal(19,2),
	var_fase2			decimal(19,2),
	cash_residual		decimal(19,2),
	var_cash_residual	decimal(19,2),
	ymov				int,
	nmov				int,
	description			varchar(150),
	registry			varchar(150),
	txt					varchar(MAX)
)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') set @idupb=@idupb + '%' 
CREATE TABLE #initial_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2), nmov int, ymov int, description varchar(150), registry varchar(150))
CREATE TABLE #var_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2), nmov int, ymov int, description varchar(150), registry varchar(150))
CREATE TABLE #initial_fase2
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2), nmov int, ymov int, description varchar(150), registry varchar(150))
CREATE TABLE #var_fase2
    	(ayear int, idfin int, idupb varchar(36), total decimal(19,2), nmov int, ymov int, description varchar(150), registry varchar(150))
CREATE TABLE #cash_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2), nmov int, ymov int, description varchar(150), registry varchar(150))
CREATE TABLE #var_cash_residual
    	(ayear int, idfin int, idupb varchar(36), total decimal(19,2), nmov int, ymov int, description varchar(150), registry varchar(150))
CREATE TABLE #fornitore_disp
    	(idaaa int, title varchar(MAX))
-----------------------------------------------------------
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
	INSERT INTO #fornitore_disp (idaaa , title )
	    SELECT E1.idinc,title+' [Disp. €'+CONVERT(varchar(12),SUM(ET.available))+'] /'
	    FROM incomelink EL
	    JOIN income E1 on E1.idinc=EL.idparent
		JOIN income E2 ON EL.idchild=E2.idinc
        JOIN registry on registry.idreg=E2.idreg
        JOIN incometotal ET on ET.idinc=E2.idinc and ET.ayear= @ayear
         WHERE 
		 E1.nphase = 1
		 and E2.nphase=2 
		 AND ((ET.flag&1) = 0) -- Residuo
		 GROUP BY registry.title, E1.idinc

	INSERT INTO #initial_residual
		(
		ayear,
		idfin,
		idupb,
		total,
		ymov,
		nmov ,
		description
		)
	SELECT 
		income.ymov,
		ISNULL(finlink.idparent,incomeyear.idfin), 
		incomeyear.idupb,
		ISNULL(incomeyear.amount, 0.0),
		income.ymov,
		income.nmov ,
		income.description
	FROM incomeyear
	JOIN income
		ON income.idinc = incomeyear.idinc
	LEFT OUTER JOIN finlink
		ON finlink.idchild = incomeyear.idfin  AND finlink.nlevel = @levelusable
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear	
	WHERE incomeyear.ayear = @ayear
		AND (incomeyear.idupb like @idupb )
		AND ((incometotal.flag&1) = 0) -- Residuo
		AND income.nphase = @finphase
		AND income.adate <= @date
		
	INSERT INTO #var_residual
		(
		ayear,
		idfin,idupb,
		total,
		ymov,
		nmov,
		description
		)
	SELECT 
	  	income.ymov,
		ISNULL(finlink.idparent,incomeyear.idfin), 
		incomeyear.idupb,
		ISNULL(incomevar.amount, 0.0),
		income.ymov,
		income.nmov ,
		income.description
	FROM incomevar
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
		AND incomeyear.ayear = @ayear
	JOIN income
		ON incomeyear.idinc = income.idinc
	LEFT OUTER JOIN finlink
		ON finlink.idchild = incomeyear.idfin  AND finlink.nlevel = @levelusable
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear	
			
	WHERE incomevar.yvar = @ayear
		AND (incomeyear.idupb like @idupb )
		AND incomevar.adate <= @date 
		AND ((incometotal.flag&1) = 0) -- Residuo
		AND income.nphase = @finphase

	INSERT INTO #initial_fase2
		(
		ayear,
		idfin,
		idupb,
		total,
		ymov,
		nmov
		)
	SELECT 
		E.ymov,
		ISNULL(FL1.idparent,EY2.idfin), 
		EY2.idupb,
		SUM(EY2.amount),
		E.ymov,
		E.nmov
	FROM income E2
	JOIN incomeyear EY2
		ON E2.idinc = EY2.idinc
	JOIN incomelink EL 
		ON EL.idchild = E2.idinc AND EL.nlevel = @finphase  -- E2 figli di fase 2 i cui EL.idparent sono i rispettivi di fase 1
	JOIN incometotal ET
		ON ET.idinc = EY2.idinc
		and ET.ayear =EY2.ayear
	LEFT OUTER JOIN finlink  FL1
		ON FL1.idchild = EY2.idfin AND FL1.nlevel = @levelusable
	JOIN income E  -- fase 1
		ON EL.idparent = E.idinc

	WHERE 	E.adate <= @date
		AND E2.nphase = @finphase+1
		AND EY2.idupb like @idupb
		AND EY2.ayear = @ayear
		AND ((ET.flag&1) = 0) -- Residuo
		GROUP BY 	E.ymov,	ISNULL(FL1.idparent,EY2.idfin), 	EY2.idupb,E.ymov,E.nmov

		INSERT INTO #var_fase2
		    (
			ayear,
			idfin,
			idupb,
			total,
			ymov,
			nmov 
		    )
		SELECT  
			E1.ymov,
			ISNULL(FL1.idparent,EY2.idfin),
			EY2.idupb,
			ISNULL(EV2.amount, 0.0),
			E1.ymov,
			E1.nmov 
		FROM incomevar EV2
		JOIN incomeyear EY2 
			ON EY2.idinc = EV2.idinc
			AND EY2.ayear = @ayear
		JOIN income E2
			ON EY2.idinc = E2.idinc
		JOIN incomelink EL 
			ON EL.idchild = EY2.idinc AND EL.nlevel = @finphase
		LEFT JOIN finlink  FL1
			ON FL1.idchild = EY2.idfin AND FL1.nlevel = @levelusable
		JOIN income E1
			ON EL.idparent = E1.idinc
		JOIN incometotal ET
		ON ET.idinc = EY2.idinc
		and ET.ayear =EY2.ayear
		WHERE EV2.yvar = @ayear
			AND EV2.adate <= @date
			AND E1.nphase = @finphase
			AND E2.nphase = @finphase+1
			AND (EY2.idupb like @idupb )
			AND ((ET.flag&1) = 0) -- Residuo
			AND EY2.ayear = @ayear

	
	INSERT INTO #cash_residual
		(
		ayear,
		idfin,
		idupb,
		total,
		ymov,
		nmov,
		description
		)
	SELECT 
		E.ymov,
		ISNULL(FL1.idparent,EY.idfin), 
		EY.idupb,
		HPV.amount,
		E.ymov,
		E.nmov,
		E.description
	FROM historyproceedsview HPV
	JOIN incomeyear EY
		ON  EY.idinc = HPV.idinc
		AND HPV.ymov = @ayear
	JOIN incomelink EL 
		ON EL.idchild = EY.idinc AND EL.nlevel = @finphase
	LEFT OUTER JOIN finlink  FL1
		ON FL1.idchild = EY.idfin AND FL1.nlevel = @levelusable
	JOIN income E
		ON EL.idparent = E.idinc
	JOIN income E1
		ON EY.idinc = E1.idinc 
	WHERE 	HPV.competencydate <= @date
		AND EY.idupb like @idupb
		AND EY.ayear = @ayear
		AND (HPV.flagarrear = 'C')
		AND E1.nphase = @cash_phase



	IF @cashvaliditykind <> 4
	BEGIN
		INSERT INTO #var_cash_residual
		    (
			ayear,
			idfin,
			idupb,
			total,
			ymov,
			nmov ,
			description
		    )
		SELECT  
			E.ymov,
			ISNULL(FL1.idparent,EY.idfin),
			EY.idupb,
			ISNULL(EV.amount, 0.0),
			E.ymov,
			E.nmov ,
			E.description
		FROM incomevar EV
		JOIN incomeyear EY 
			ON EY.idinc = EV.idinc
			AND EY.ayear = @ayear
		JOIN incomelink EL 
			ON EL.idchild = EY.idinc AND EL.nlevel = @finphase
		LEFT JOIN finlink  FL1
			ON FL1.idchild = EY.idfin AND FL1.nlevel = @levelusable
		JOIN income E
			ON EL.idparent = E.idinc
		JOIN income E1
			ON EY.idinc = E1.idinc 
		JOIN historyproceedsview HPV
			ON HPV.idinc = EV.idinc
			AND HPV.ymov = @ayear
		--JOIN incomelink EL2
		--	ON EL.idchild = EL2.idchild
		--	AND EL2.nlevel = @regphase
		--JOIN income E2
		--	ON E2.idinc = EL2.idchild
		--JOIN registry R
		--	ON E2.idreg = R.idreg		
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND (HPV.flagarrear = 'C')
			AND E1.nphase = @cash_phase
			AND HPV.competencydate <= @date
			AND (EY.idupb like @idupb )
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
		nmov ,
		description
		)
	SELECT 
		expense.ymov,
		ISNULL(finlink.idparent,expenseyear.idfin), 
		expenseyear.idupb,
		ISNULL(expenseyear.amount, 0.0),
		expense.ymov,
		expense.nmov ,
		expense.description
	FROM expenseyear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	LEFT OUTER JOIN finlink
		ON finlink.idchild = expenseyear.idfin  AND finlink.nlevel = @levelusable
	JOIN expensetotal
		ON  expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear	
	WHERE expenseyear.ayear = @ayear
		AND (expenseyear.idupb like @idupb )
		AND ((expensetotal.flag&1) = 0) -- Residuo
		AND expense.nphase = @finphase
		AND expense.adate <= @date

	INSERT INTO #var_residual
		(
		ayear,
		idfin,idupb,
		total,
		ymov,
		nmov,
		description
		)
	SELECT 
	  	expense.ymov,
		ISNULL(finlink.idparent,expenseyear.idfin), 
		expenseyear.idupb,
		ISNULL(expensevar.amount, 0.0),
		expense.ymov,
		expense.nmov ,
		expense.description
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = @ayear
	JOIN expense
		ON expenseyear.idexp = expense.idexp
	LEFT OUTER JOIN finlink
		ON finlink.idchild = expenseyear.idfin  AND finlink.nlevel = @levelusable
	JOIN expensetotal
		ON  expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear	
			
	WHERE expensevar.yvar = @ayear
		AND (expenseyear.idupb like @idupb )
		AND expensevar.adate <= @date 
		AND ((expensetotal.flag&1) = 0) -- Residuo
		AND expense.nphase = @finphase

	INSERT INTO #initial_fase2
		(
		ayear,
		idfin,
		idupb,
		total,
		ymov,
		nmov
		)
	SELECT 
		E.ymov,
		ISNULL(FL1.idparent,EY2.idfin), 
		EY2.idupb,
		SUM(EY2.amount),
		E.ymov,
		E.nmov
	FROM expense E2
	JOIN expenseyear EY2
		ON E2.idexp = EY2.idexp
	JOIN expenselink EL 
		ON EL.idchild = E2.idexp AND EL.nlevel = @finphase  -- E2 figli di fase 2 i cui EL.idparent sono i rispettivi di fase 1
	JOIN expensetotal ET
		ON ET.idexp = EY2.idexp
		and ET.ayear =EY2.ayear
	LEFT OUTER JOIN finlink  FL1
		ON FL1.idchild = EY2.idfin AND FL1.nlevel = @levelusable
	JOIN expense E  -- fase 1
		ON EL.idparent = E.idexp

	WHERE 	E.adate <= @date
		AND E2.nphase = @finphase+1
		AND EY2.idupb like @idupb
		AND EY2.ayear = @ayear
		AND ((ET.flag&1) = 0) -- Residuo
		GROUP BY 	E.ymov,	ISNULL(FL1.idparent,EY2.idfin), 	EY2.idupb,E.ymov,E.nmov

		INSERT INTO #var_fase2
		    (
			ayear,
			idfin,
			idupb,
			total,
			ymov,
			nmov 
		    )
		SELECT  
			E1.ymov,
			ISNULL(FL1.idparent,EY2.idfin),
			EY2.idupb,
			ISNULL(EV2.amount, 0.0),
			E1.ymov,
			E1.nmov 
		FROM expensevar EV2
		JOIN expenseyear EY2 
			ON EY2.idexp = EV2.idexp
			AND EY2.ayear = @ayear
		JOIN expense E2
			ON EY2.idexp = E2.idexp
		JOIN expenselink EL 
			ON EL.idchild = EY2.idexp AND EL.nlevel = @finphase
		LEFT JOIN finlink  FL1
			ON FL1.idchild = EY2.idfin AND FL1.nlevel = @levelusable
		JOIN expense E1
			ON EL.idparent = E1.idexp
		JOIN expensetotal ET
		ON ET.idexp = EY2.idexp
		and ET.ayear =EY2.ayear
		WHERE EV2.yvar = @ayear
			AND EV2.adate <= @date
			AND E1.nphase = @finphase
			AND E2.nphase = @finphase+1
			AND (EY2.idupb like @idupb )
			AND ((ET.flag&1) = 0) -- Residuo
			AND EY2.ayear = @ayear

	INSERT INTO #cash_residual
		(
		ayear,
		idfin,
		idupb,
		total,
		ymov,
		nmov,
		description
		)
	SELECT 
		E.ymov,
		ISNULL(FL1.idparent,EY.idfin), 
		EY.idupb,
		HPV.amount,
		E.ymov,
		E.nmov,
		E.description
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON  EY.idexp = HPV.idexp
		AND HPV.ymov = @ayear
	JOIN expenselink EL 
		ON EL.idchild = EY.idexp AND EL.nlevel = @finphase
	LEFT OUTER JOIN finlink  FL1
		ON FL1.idchild = EY.idfin AND FL1.nlevel = @levelusable
	JOIN expense E
		ON EL.idparent = E.idexp
	JOIN expense E1
		ON EY.idexp = E1.idexp 
	WHERE 	HPV.competencydate <= @date
		AND EY.idupb like @idupb
		AND EY.ayear = @ayear
		AND (HPV.flagarrear = 'C')
		AND E1.nphase = @cash_phase
	
	IF @cashvaliditykind <> 4
	BEGIN
		INSERT INTO #var_cash_residual
		    (
			ayear,
			idfin,
			idupb,
			total,
			ymov,
			nmov ,
			description
		    )
		SELECT  
			E.ymov,
			ISNULL(FL1.idparent,EY.idfin),
			EY.idupb,
			ISNULL(EV.amount, 0.0),
			E.ymov,
			E.nmov ,
			E.description
		FROM expensevar EV
		JOIN expenseyear EY 
			ON EY.idexp = EV.idexp
			AND EY.ayear = @ayear
		JOIN expenselink EL 
			ON EL.idchild = EY.idexp AND EL.nlevel = @finphase
		LEFT JOIN finlink  FL1
			ON FL1.idchild = EY.idfin AND FL1.nlevel = @levelusable
		JOIN expense E
			ON EL.idparent = E.idexp
		JOIN expense E1
			ON EY.idexp = E1.idexp 
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
			AND HPV.ymov = @ayear
		--JOIN expenselink EL2
		--	ON EL.idchild = EL2.idchild
		--	AND EL2.nlevel = @regphase
		--JOIN expense E2
		--	ON E2.idexp = EL2.idchild
		--JOIN registry R
		--	ON E2.idreg = R.idreg		
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND (HPV.flagarrear = 'C')
			AND E1.nphase = @cash_phase
			AND HPV.competencydate <= @date
			AND (EY.idupb like @idupb )
	END
	 INSERT INTO #fornitore_disp
    	(idaaa , title )
	    SELECT E1.idexp, title+' [Disp. €'+CONVERT(varchar(12),SUM(ET.available))+'] /'
	    FROM expenselink EL
	    JOIN expense E1 on E1.idexp=EL.idparent
		JOIN expense E2 ON EL.idchild=E2.idexp
        JOIN registry on registry.idreg=E2.idreg
        JOIN expensetotal ET on ET.idexp=E2.idexp and ET.ayear=@ayear
         WHERE 
		 E1.nphase = 1
		 and E2.nphase=2 
		 
		 AND ((ET.flag&1) = 0) -- Residuo
		 GROUP BY registry.title, E1.idexp
		 HAVING SUM(ET.available)>0
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

UPDATE #report_residual 
SET initial_residual = ISNULL((SELECT SUM(#initial_residual.total) FROM #initial_residual
		WHERE #initial_residual.ymov = #report_residual.ymov
		AND #initial_residual.nmov = #report_residual.nmov), 0.0)

UPDATE #report_residual 
SET var_residual = ISNULL((SELECT SUM(#var_residual.total) FROM #var_residual
		WHERE  #var_residual.ymov = #report_residual.ymov
		AND #var_residual.nmov = #report_residual.nmov), 0.0)
			
UPDATE #report_residual 
SET initial_fase2 = ISNULL((SELECT SUM(#initial_fase2.total) FROM #initial_fase2
		WHERE  #initial_fase2.ymov  = #report_residual.ymov
		AND   #initial_fase2.nmov  = #report_residual.nmov), 0.0)

UPDATE #report_residual 
SET var_fase2 = ISNULL((SELECT SUM(#var_fase2.total) FROM #var_fase2
		WHERE  #var_fase2.ymov  = #report_residual.ymov
		AND   #var_fase2.nmov  = #report_residual.nmov), 0.0)		
		
UPDATE #report_residual
SET cash_residual =
		ISNULL((SELECT SUM(#cash_residual.total) FROM #cash_residual
		WHERE #cash_residual.ayear = #report_residual.ayear
		AND   #cash_residual.ymov  = #report_residual.ymov
		AND   #cash_residual.nmov  = #report_residual.nmov), 0.0)

UPDATE #report_residual
SET var_cash_residual =	ISNULL((SELECT SUM(#var_cash_residual.total) FROM #var_cash_residual
		WHERE  #var_cash_residual.ayear = #report_residual.ayear
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

IF @finpart = 'E'
UPDATE #report_residual 
SET idexp1 = (SELECT idinc from income I where I.ymov = #report_residual.ymov AND I.nmov = #report_residual.nmov and I.nphase = 1)
ELSE 
UPDATE #report_residual 
SET idexp1 = (SELECT idexp from expense I where I.ymov = #report_residual.ymov AND I.nmov = #report_residual.nmov and I.nphase = 1);

--------------------------
	--txt ---- #fornitore_disp

  
WITH CTE (idaaa, title2)  
AS   
(SELECT DISTINCT a.idaaa, (SELECT ', ' + title AS [text()]
            FROM #fornitore_disp b
            WHERE b.idaaa = a.idaaa
            ORDER BY b.idaaa
            FOR XML PATH ('')
        ) as title2
  FROM #fornitore_disp a
  )
  
	UPDATE #report_residual  
	 SET txt = STUFF((SELECT title2
            FROM CTE b
            WHERE b.idaaa = #report_residual.idexp1
           ),1,2,'');
 
-----------------------------
DELETE from #report_residual
WHERE ISNULL(initial_residual,0)+ISNULL(var_residual,0)-ISNULL(cash_residual,0)-ISNULL(var_cash_residual,0) = 0

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

	IF @finpart = 'E'
	BEGIN		-- ENTRATE
			IF (@showupb <>'S') 
			BEGIN
				SELECT 
					ymov as 'Anno Mov.',
					nmov as 'Numero Mov.',
					#report_residual.description as 'Descrizione Movimento finanziario',
					#report_residual.txt as 'Versanti',
					SUM(ISNULL(initial_residual,0.0)) 	as 'Pre Accertamento al 01/01',
					SUM(ISNULL(var_residual,0.0)) 		as 'Variazioni Pre Acc.',
					SUM(ISNULL(initial_fase2,0.0)) 	as 'Accertamento al 01/01',
					SUM(ISNULL(var_fase2,0.0)) 		as 'Variazioni Accertamento',
					SUM(ISNULL(initial_residual,0.0))+SUM(ISNULL(var_residual,0.0))-SUM(ISNULL(initial_fase2,0.0))-SUM(ISNULL(var_fase2,0.0)) as 'Disponibilità ad Accertare',
					SUM(ISNULL(cash_residual,0.0)) 		as 'Incassato',
					SUM(ISNULL(var_cash_residual,0.0)) 	as 'Var. su Incassato',
					SUM(ISNULL(initial_residual,0.0))+SUM(ISNULL(var_residual,0.0))-SUM(ISNULL(cash_residual,0.0))-SUM(ISNULL(var_cash_residual,0.0)) as 'Residuo finale',
					--ayear,
					--idfin,

					codefin as 'Codice Bilancio',
					#report_residual.title as 'Denominazione Bilancio',
					--finprintingorder,
					#report_residual.codeupb as 'Codice UPB',		

					upb as 'Denominazione UPB',
					S.sortcode as 'Attributo01',
					#report_residual.idupb
					--upbprintingorder
				FROM #report_residual
					join upb on #report_residual.idupb = upb.idupb
					 Join sorting S ON S.idsor = upb.idsor01
					GROUP BY ayear,
					idfin,
					#report_residual.codefin,
					#report_residual.finprintingorder,
					#report_residual.codeupb,		
					#report_residual.idupb,	#report_residual.title,
					upb,S.sortcode,
					#report_residual.upbprintingorder,ymov,#report_residual.description,
					nmov
							ORDER BY ymov, nmov 
			END 
			ELSE
				SELECT 
					ymov as 'Anno Mov.',
					nmov as 'Numero Mov.',  
					#report_residual.description as 'Descrizione Movimento finanziario',
					#report_residual.txt as 'Versanti',
					initial_residual as 'Pre Accertamento al 01/01',
					var_residual as 'Variazioni Accertamento',
					initial_fase2 as 'Accertamento al 01/01',
					var_fase2 as 'Variazioni Accertamento',
					initial_residual+var_residual-initial_fase2-var_fase2 as 'Disponibilità ad Accertare',
					cash_residual as 'Incassato',
					var_cash_residual 'Var. su Incassato',
					initial_residual+var_residual-cash_residual-var_cash_residual as 'Residuo finale',
					--ayear,
					--idfin,
					codefin as 'Codice Bilancio',
					#report_residual.title as 'Denominazione Bilancio',
					--finprintingorder,
					#report_residual.codeupb as 'Codice UPB',		

					#report_residual.upb as 'Denominazione UPB',
					S.sortcode as 'Attributo01',
							#report_residual.idupb


				FROM #report_residual
					left outer join upb on #report_residual.idupb = upb.idupb
					left outer Join sorting S ON S.idsor = upb.idsor01
				 
				ORDER BY ymov, nmov 
	END
	ELSE
	BEGIN -- SPESE
		IF (@showupb <>'S') 
			BEGIN
				SELECT 
					ymov as 'Anno Mov.',
					nmov as 'Numero Mov.',
					#report_residual.description as 'Descrizione Movimento finanziario',
					#report_residual.txt as 'Fornitori',
					SUM(ISNULL(initial_residual,0.0)) 	as 'Pre Impegno al 01/01',
					SUM(ISNULL(var_residual,0.0)) 		as 'Variazioni su Pre Impegno',
					SUM(ISNULL(initial_fase2,0.0)) 	as 'Importo Impegno al 01/01',
					SUM(ISNULL(var_fase2,0.0)) 		as 'Variazioni Impegno',
					SUM(ISNULL(initial_residual,0.0))+SUM(ISNULL(var_residual,0.0))-SUM(ISNULL(initial_fase2,0.0))-SUM(ISNULL(var_fase2,0.0)) as 'Disponibilità ad Impegnare',
					SUM(ISNULL(cash_residual,0.0)) 		as 'Pagato',
					SUM(ISNULL(var_cash_residual,0.0)) 	as 'Var. su Pagato',
					SUM(ISNULL(initial_residual,0.0))+SUM(ISNULL(var_residual,0.0))-SUM(ISNULL(cash_residual,0.0))-SUM(ISNULL(var_cash_residual,0.0)) as 'Residuo finale',
					--ayear,
					--idfin,
					codefin as 'Codice Bilancio',
					#report_residual.title as 'Denominazione Bilancio',
					--finprintingorder,
					#report_residual.codeupb as 'Codice UPB',		

					upb as 'Denominazione UPB',
					S.sortcode as 'Attributo01',
					#report_residual.idupb
					--upbprintingorder
				FROM #report_residual
					join upb on #report_residual.idupb = upb.idupb
					 Join sorting S ON S.idsor = upb.idsor01
					GROUP BY ayear,
					idfin,
					#report_residual.codefin,
					#report_residual.finprintingorder,
					#report_residual.codeupb,		
					#report_residual.idupb,	#report_residual.title,
					upb,S.sortcode,
					#report_residual.upbprintingorder,ymov,#report_residual.description,
					nmov
							ORDER BY ymov, nmov 
			END 
			ELSE
				SELECT 
					ymov as 'Anno Mov.',
					nmov as 'Numero Mov.',idexp1, 
					#report_residual.description as 'Descrizione Movimento finanziario',
					#report_residual.txt as 'Fornitori',
					initial_residual as 'Pre-Impegno al 01/01',
					var_residual as 'Variazioni su Pre-Impegno',
					initial_fase2 as 'Impegno al 01/01',
					var_fase2 as 'Variazioni Impegno',
					initial_residual+var_residual-initial_fase2-var_fase2 as 'Disponibilità ad Impegnare',
					cash_residual as 'Pagato',
					var_cash_residual 'Var. su Pagato',
					initial_residual+var_residual-cash_residual-var_cash_residual as 'Residuo finale',
					--ayear,
					--idfin,
					codefin as 'Codice Bilancio',
					#report_residual.title as 'Denominazione Bilancio',
					--finprintingorder,
					#report_residual.codeupb as 'Codice UPB',		
					#report_residual.upb as 'Denominazione UPB',
					S.sortcode as 'Attributo01',
					#report_residual.idupb
				FROM #report_residual
					left outer join upb on #report_residual.idupb = upb.idupb
					left outer Join sorting S ON S.idsor = upb.idsor01

				ORDER BY idexp1, ymov, nmov 
	END


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
