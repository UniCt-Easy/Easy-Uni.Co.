
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sit_residui_per_anno_riep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sit_residui_per_anno_riep]
GO



CREATE PROCEDURE [rpt_sit_residui_per_anno_riep]
	@ayear 		int,
	@date		datetime,
	@finpart 	char(1),
	@levelusable 	tinyint,
	@idupb		varchar(36),
	@showupb 	char(1),
	@showchildupb 	char(1)
AS
BEGIN
/* Versione 1.0.2 del 16/11/2007 ultima modifica: MARIA */							
DECLARE @finphase		tinyint
DECLARE @cash_phase		tinyint
DECLARE @idupboriginal 		varchar(36)

SET @idupboriginal= @idupb
IF (@showchildupb = 'S') set @idupb=@idupb + '%' 		

CREATE TABLE #report_residual
(
	ayear			int,
	codeupb			varchar(50),
	idupb 			varchar(36),
	upb   			varchar(150),
	upbprintingorder	varchar(50),
	idfin			int,
	codefin			varchar(12),
	title			varchar(150),
	initial_residual	decimal(19,2),
	var_residual		decimal(19,2),
	cash_residual		decimal(19,2),
	var_cash_residual	decimal(19,2)
)
CREATE TABLE #initial_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #cash_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_cash_residual
    	(ayear int, idfin int, idupb varchar(36), total decimal(19,2))
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
	END

IF @finpart = 'E'
BEGIN
	
	INSERT INTO #initial_residual
		(
		ayear,
		idfin,
		idupb,
		total
		)
	SELECT
		income.ymov,
		ISNULL(finlink.idparent,incomeyear.idfin), 
		incomeyear.idupb,
		SUM(ISNULL(incomeyear.amount, 0.0))
	FROM incomeyear
	JOIN income
		ON income.idinc = incomeyear.idinc
        JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear			
	LEFT OUTER JOIN finlink
		ON finlink.idchild = incomeyear.idfin  AND finlink.nlevel = @levelusable
	WHERE 	incomeyear.ayear = @ayear
		AND (incomeyear.idupb like @idupb )
		AND ((incometotal.flag&1) = 1) -- Residuo
		AND income.nphase = @finphase
		AND income.adate <= @date
	GROUP BY income.ymov,incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin)
	
	INSERT INTO #var_residual
		(
		ayear,
		idfin,
		idupb,
		total
		)
	SELECT
		income.ymov,
		ISNULL(finlink.idparent,incomeyear.idfin), 
		incomeyear.idupb,
		SUM(ISNULL(incomevar.amount, 0.0))
	FROM incomevar
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
		AND incomeyear.ayear = @ayear
	JOIN income
		ON incomeyear.idinc = income.idinc
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear			
	LEFT OUTER JOIN finlink
		ON finlink.idchild = incomeyear.idfin  AND finlink.nlevel = @levelusable
	WHERE incomevar.yvar = @ayear
		AND incomevar.adate <= @date 
		AND (incomeyear.idupb like @idupb )
		AND ((incometotal.flag&1) = 1) -- Residuo
		AND income.nphase = @finphase
	GROUP BY income.ymov, incomeyear.idupb,ISNULL(finlink.idparent,incomeyear.idfin)
	
	INSERT INTO #cash_residual
		(
		ayear,
		idfin,
		idupb,
		total
		)
	SELECT
		I.ymov,
		ISNULL(FL1.idparent,IY.idfin),
		IY.idupb,
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON  IY.idinc = HPV.idinc
		AND HPV.ymov = @ayear
	JOIN incomelink IL 
		ON IL.idchild = IY.idinc AND IL.nlevel = @finphase
	JOIN income I
		ON IL.idparent = I.idinc 
	LEFT OUTER JOIN finlink  FL1
		ON FL1.idchild = IY.idfin AND FL1.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND IY.idupb like @idupb
		AND IY.ayear = @ayear
		AND HPV.flagarrear = 'R'
	GROUP BY I.ymov, IY.idupb,ISNULL(FL1.idparent,IY.idfin)
	
	IF @cashvaliditykind <> 4
	BEGIN
		INSERT INTO #var_cash_residual
			(
			ayear,
			idfin,
			idupb,
			total
			)
		SELECT
			I.ymov,
			ISNULL(FL1.idparent,IY.idfin),
			IY.idupb,
			SUM(ISNULL(IV.amount, 0.0))
		FROM incomevar IV
		JOIN incomeyear IY
			ON  IY.idinc = IV.idinc
			AND IY.ayear = @ayear
		JOIN incomelink IL 
			ON IL.idchild = IY.idinc AND IL.nlevel = @finphase
		JOIN income I
			ON I.idinc = IL.idparent
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
			AND HPV.ymov = @ayear
		LEFT OUTER JOIN finlink  FL1
			ON FL1.idchild = IY.idfin AND FL1.nlevel = @levelusable
		WHERE 	IV.yvar = @ayear
			AND IY.idupb like @idupb
			AND IV.adate <= @date
			AND HPV.flagarrear = 'R'
		 	AND HPV.competencydate <= @date
		GROUP BY I.ymov, IY.idupb,ISNULL(FL1.idparent,IY.idfin)
	END
END
-- PARTE SPESA
IF @finpart = 'S'
BEGIN
	
	INSERT INTO #initial_residual
		(
		ayear,
		idfin,
		idupb,
		total
		)
	SELECT
		expense.ymov,
		ISNULL(finlink.idparent,expenseyear.idfin), 
		expenseyear.idupb,
		SUM(ISNULL(expenseyear.amount, 0.0))
	FROM expenseyear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
        JOIN expensetotal
		ON  expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear			
	LEFT OUTER JOIN finlink
		ON finlink.idchild = expenseyear.idfin AND finlink.nlevel = @levelusable
	WHERE expenseyear.ayear = @ayear
		AND expenseyear.idupb like @idupb
		AND ((expensetotal.flag&1) = 1) -- Residuo
		AND expense.nphase = @finphase
		AND expense.adate <= @date
	GROUP BY expense.ymov, expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin)
	INSERT INTO #var_residual
		(
		ayear,
		idfin,
		idupb,	
		total
		)
	SELECT
		expense.ymov,
		ISNULL(finlink.idparent,expenseyear.idfin), 
		expenseyear.idupb,
		SUM(ISNULL(expensevar.amount, 0.0))
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = @ayear
	JOIN expense
		ON expenseyear.idexp = expense.idexp
	JOIN expensetotal
		ON  expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear			
	LEFT OUTER JOIN finlink
		ON finlink.idchild = expenseyear.idfin AND finlink.nlevel = @levelusable
	WHERE expensevar.yvar = @ayear
		AND expenseyear.idupb like @idupb
		AND expensevar.adate <= @date 
		AND ((expensetotal.flag&1) = 1) -- Residuo
		AND expense.nphase = @finphase
	GROUP BY expense.ymov, expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin)
	
	INSERT INTO #cash_residual
		(
		ayear,
		idfin,
		idupb,
		total
		)
	SELECT
		E.ymov,
		ISNULL(FL1.idparent,EY.idfin), 
		EY.idupb,
		SUM(HPV.amount)
	FROM historypaymentview HPV 
	JOIN expenseyear EY
		ON  EY.idexp = HPV.idexp
		AND EY.ayear = @ayear
	JOIN expenselink EL 
		ON EL.idchild = EY.idexp AND EL.nlevel = @finphase
	JOIN expense E
		ON EL.idparent = E.idexp
	LEFT OUTER JOIN finlink  FL1
		ON FL1.idchild = EY.idfin AND FL1.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND EY.idupb like @idupb
		AND HPV.flagarrear = 'R'
	GROUP BY E.ymov, EY.idupb,ISNULL(FL1.idparent,EY.idfin)
	
	IF @cashvaliditykind <> 4
	BEGIN
		INSERT INTO #var_cash_residual
		    (
			ayear,
			idfin,
			idupb,
			total
		    )
		SELECT 
			E.ymov,
			ISNULL(FL1.idparent,EY.idfin), 
			EY.idupb,
			SUM(ISNULL(EV.amount, 0.0))
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
			AND EY.ayear = @ayear
		JOIN expenselink EL 
			ON EL.idchild = EY.idexp AND EL.nlevel = @finphase
		JOIN expense E
			ON EL.idparent = E.idexp
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
			AND HPV.ymov = @ayear
		LEFT OUTER JOIN finlink  FL1
			ON FL1.idchild = EY.idfin AND FL1.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND EY.idupb like @idupb
			AND EV.adate <= @date
			AND (HPV.flagarrear = 'R')
			AND HPV.competencydate <= @date
		GROUP BY E.ymov, EY.idupb, ISNULL(FL1.idparent,EY.idfin)
	END
END
INSERT INTO #report_residual(ayear, idfin,idupb)
SELECT DISTINCT ayear,idfin,idupb 
	FROM #initial_residual

INSERT INTO #report_residual(ayear, idfin,idupb)
SELECT DISTINCT ayear,idfin,idupb 
FROM #var_residual
WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #var_residual.idfin
		and i1.idupb = #var_residual.idupb
		and i1.ayear = #var_residual.ayear
		)
/*	WHERE  (
		#var_residual.idfin
		) 
		NOT IN (
			SELECT idfin  
			FROM #report_residual
			)
*/

INSERT INTO #report_residual(ayear, idfin,idupb)
SELECT DISTINCT ayear,idfin,idupb 
FROM #cash_residual
WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #cash_residual.idfin
		and i1.idupb = #cash_residual.idupb
		and i1.ayear = #cash_residual.ayear
		)
/*	WHERE (
		#cash_residual.idfin
		) 
		NOT IN (
			SELECT idfin  
			FROM #report_residual
			)*/

INSERT INTO #report_residual(ayear, idfin,idupb)
SELECT DISTINCT ayear,idfin,idupb 
FROM #var_cash_residual
WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #var_cash_residual.idfin
		and i1.idupb = #var_cash_residual.idupb
		and i1.ayear = #var_cash_residual.ayear
		)
/*	WHERE  (
		#var_cash_residual.idfin
		) 
		NOT IN (
		SELECT idfin  FROM #report_residual
			)
*/
UPDATE #report_residual
SET initial_residual = ISNULL((SELECT #initial_residual.total FROM #initial_residual
		WHERE #initial_residual.idfin = #report_residual.idfin
		and #initial_residual.idupb = #report_residual.idupb
		AND #initial_residual.ayear = #report_residual.ayear), 0.0)
UPDATE #report_residual
SET var_residual = ISNULL((SELECT #var_residual.total FROM #var_residual
		WHERE #var_residual.idfin = #report_residual.idfin
		and #var_residual.idupb = #report_residual.idupb
		AND #var_residual.ayear = #report_residual.ayear), 0.0)
		
UPDATE #report_residual
SET cash_residual = ISNULL((SELECT #cash_residual.total FROM #cash_residual
		WHERE #cash_residual.idfin = #report_residual.idfin
		and #cash_residual.idupb = #report_residual.idupb
		AND #cash_residual.ayear = #report_residual.ayear), 0.0)
UPDATE #report_residual
SET var_cash_residual = ISNULL((SELECT #var_cash_residual.total FROM #var_cash_residual
		WHERE #var_cash_residual.idfin = #report_residual.idfin
		and #var_cash_residual.idupb = #report_residual.idupb
		AND #var_cash_residual.ayear = #report_residual.ayear), 0.0)

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
			upbprintingorder = null,
			upb =  null,
			idupb = null,
			codeupb = null

SELECT 
	ayear,    
	codeupb,		
	idupb,	
	upb,
	upbprintingorder,
	sum(initial_residual) initial_residual,
	sum(var_residual) var_residual,
	sum(cash_residual) cash_residual,
	sum(var_cash_residual) var_cash_residual
FROM #report_residual
GROUP BY upbprintingorder,
ayear,codeupb,idupb,upb   			
ORDER BY ayear ASC,upbprintingorder ASC
END

