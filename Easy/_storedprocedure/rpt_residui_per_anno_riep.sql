
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


/* Versione 1.0.1 del 16/11/2007 ultima modifica: MARIA */

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_residui_per_anno_riep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_residui_per_anno_riep]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE  PROCEDURE [rpt_residui_per_anno_riep]
	@ayear 			int,
	@date			datetime,
	@finpart 		char(1),
	@levelusable 		tinyint
AS
BEGIN
							
DECLARE @finphase		tinyint
DECLARE @cash_phase		tinyint
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

CREATE TABLE #initial_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2))

CREATE TABLE #var_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2))
	
CREATE TABLE #cash_residual
	(ayear int, idfin int, idupb varchar(36), total decimal(19,2))

CREATE TABLE #var_cash_residual
    	(ayear int, idfin int, idupb varchar(36), total decimal(19,2))

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
		finlink.idparent, 
		incomeyear.idupb,
		SUM(ISNULL(incomeyear.amount, 0.0))
	FROM incomeyear
	JOIN income
		ON income.idinc = incomeyear.idinc
	JOIN finlink
		ON finlink.idchild = incomeyear.idfin  AND finlink.nlevel = @levelusable
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear			
	WHERE 	incomeyear.ayear = @ayear
		AND ((incometotal.flag&1) = 1) -- Residuo
		AND income.nphase = @finphase
		AND income.adate <= @date
	GROUP BY income.ymov,incomeyear.idupb,finlink.idparent
	

	INSERT INTO #var_residual
		(
		ayear,
		idfin,
		idupb,
		total
		)
	SELECT
		income.ymov,
		finlink.idparent, 
		incomeyear.idupb,
		SUM(ISNULL(incomevar.amount, 0.0))
	FROM incomevar
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
		AND incomeyear.ayear = @ayear
	JOIN income
		ON incomeyear.idinc = income.idinc
	JOIN finlink
		ON finlink.idchild = incomeyear.idfin  AND finlink.nlevel = @levelusable
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear			
	WHERE incomevar.yvar = @ayear
		AND incomevar.adate <= @date 
		AND ((incometotal.flag&1) = 1) -- Residuo
		AND income.nphase = @finphase
	GROUP BY income.ymov, incomeyear.idupb,finlink.idparent
	
	INSERT INTO #cash_residual
		(
		ayear,
		idfin,
		idupb,
		total
		)
	SELECT
		I.ymov,
		FL1.idparent,
		IY.idupb,
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON  IY.idinc = HPV.idinc
		AND HPV.ymov = @ayear
	JOIN incomelink IL 
		ON IL.idchild = IY.idinc AND IL.nlevel = @finphase
	JOIN finlink  FL1
		ON FL1.idchild = IY.idfin AND FL1.nlevel = @levelusable
	JOIN income I
		ON IL.idparent = I.idinc 
	JOIN income I1
		ON IY.idinc = I1.idinc 
	JOIN incometotal
		ON  IY.idinc = incometotal.idinc
		AND IY.ayear = incometotal.ayear
	WHERE HPV.competencydate <= @date
		AND IY.ayear = @ayear
		AND ((incometotal.flag&1) = 1) -- Residuo
		AND I1.nphase = @cash_phase
	GROUP BY I.ymov, IY.idupb,FL1.idparent

	INSERT INTO #var_cash_residual
			(
			ayear,
			idfin,
			idupb,
			total
			)
		SELECT
			I.ymov,
			FL1.idparent,
			IY.idupb,
			SUM(ISNULL(IV.amount, 0.0))
		FROM incomevar IV
		JOIN incomeyear IY
			ON  IY.idinc = IV.idinc
			AND IY.ayear = @ayear
		JOIN incomelink IL 
			ON IL.idchild = IY.idinc AND IL.nlevel = @finphase
		JOIN finlink  FL1
			ON FL1.idchild = IY.idfin AND FL1.nlevel = @levelusable
		JOIN income I
			ON I.idinc = IL.idparent
		JOIN income I1
			ON I1.idinc = IY.idinc 
		JOIN incometotal
			ON  IY.idinc = incometotal.idinc
			AND IY.ayear = incometotal.ayear
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
			AND HPV.ymov = @ayear
		WHERE 	IV.yvar = @ayear
			AND IV.adate <= @date
			AND ((incometotal.flag&1) = 1) -- Residuo
			AND I1.nphase = @cash_phase
		 	AND HPV.competencydate <= @date
		GROUP BY I.ymov, IY.idupb,FL1.idparent
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
		finlink.idparent, 
		expenseyear.idupb,
		SUM(ISNULL(expenseyear.amount, 0.0))
	FROM expenseyear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	JOIN finlink
		ON finlink.idchild = expenseyear.idfin  AND finlink.nlevel = @levelusable
	JOIN expensetotal
		ON  expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear			
	WHERE expenseyear.ayear = @ayear
		AND ((expensetotal.flag&1) = 1) -- Residuo
		AND expense.nphase = @finphase
		AND expense.adate <= @date
	GROUP BY expense.ymov, expenseyear.idupb,finlink.idparent

	INSERT INTO #var_residual
		(
		ayear,
		idfin,
		idupb,	
		total
		)
	SELECT
		expense.ymov,
		finlink.idparent,
		expenseyear.idupb,
		SUM(ISNULL(expensevar.amount, 0.0))
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = @ayear
	JOIN expense
		ON expenseyear.idexp = expense.idexp
	JOIN finlink
		ON finlink.idchild = expenseyear.idfin  AND finlink.nlevel = @levelusable
	JOIN expensetotal
		ON  expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear			
	WHERE expensevar.yvar = @ayear
		AND expensevar.adate <= @date 
		AND ((expensetotal.flag&1) = 1) -- Residuo
		AND expense.nphase = @finphase
	GROUP BY expense.ymov, expenseyear.idupb,finlink.idparent

	INSERT INTO #cash_residual
		(
		ayear,
		idfin,
		idupb,
		total
		)
	SELECT
		E.ymov,
		FL1.idparent, 
		EY.idupb,
		SUM(HPV.amount)
	FROM historypaymentview HPV 
	JOIN expenseyear EY
		ON  EY.idexp = HPV.idexp
		AND EY.ayear = @ayear
	JOIN expenselink EL 
		ON EL.idchild = EY.idexp AND EL.nlevel = @finphase
	JOIN finlink  FL1
		ON FL1.idchild = EY.idfin AND FL1.nlevel = @levelusable
	JOIN expense E
		ON EL.idparent = E.idexp
	JOIN expense E1
		ON EY.idexp = E1.idexp 
	JOIN expensetotal
		ON  EY.idexp = expensetotal.idexp
		AND EY.ayear = expensetotal.ayear
	WHERE HPV.competencydate <= @date
		AND ((expensetotal.flag&1) = 1) -- Residuo
		AND E1.nphase = @cash_phase
	GROUP BY E.ymov, EY.idupb,FL1.idparent

	INSERT INTO #var_cash_residual
	    (
		ayear,
		idfin,
		idupb,
		total
	    )
	SELECT 
			E.ymov,
			FL1.idparent,
			EY.idupb,
			SUM(ISNULL(EV.amount, 0.0))
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
		JOIN expense E1
			ON EY.idexp = E1.idexp 
		JOIN expensetotal
			ON  EY.idexp = expensetotal.idexp
			AND EY.ayear = expensetotal.ayear
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
			AND HPV.ymov = @ayear
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND ((expensetotal.flag&1) = 1) -- Residuo
			AND E1.nphase = @cash_phase
			AND HPV.competencydate <= @date
		GROUP BY E.ymov, EY.idupb, FL1.idparent
END

CREATE TABLE #report_residual
(
	ayear			int,
	codeupb			varchar(50),
	idupb 			varchar(36),
	upb   			varchar(100),
	upbprintingorder	varchar(36),
	idfin			varchar(39),
	codefin			varchar(12),
	title			varchar(100),
	initial_residual	decimal(19,2),
	var_residual		decimal(19,2),
	cash_residual		decimal(19,2),
	var_cash_residual	decimal(19,2)
)

INSERT INTO #report_residual
	(ayear, idfin,idupb)
SELECT DISTINCT ayear,idfin,idupb 
	FROM #initial_residual
INSERT INTO #report_residual
	(ayear, idfin,idupb)
SELECT DISTINCT ayear,idfin,idupb 
	FROM #var_residual
	WHERE  (
		#var_residual.idfin
		) 
		NOT IN (
			SELECT #report_residual.idfin  
			FROM #report_residual
			)

INSERT INTO #report_residual
	(ayear, idfin,idupb)
SELECT DISTINCT ayear,idfin,idupb 
	FROM #cash_residual
	WHERE (
		#cash_residual.idfin
		) 
		NOT IN (
			SELECT #report_residual.idfin  
			FROM #report_residual
			)
INSERT INTO #report_residual
	(ayear, idfin,idupb)
SELECT DISTINCT ayear,idfin,idupb 
	FROM #var_cash_residual
	WHERE  (
		#var_cash_residual.idfin
		) 
		NOT IN (
		SELECT 
		 	#report_residual.idfin  FROM #report_residual
			)
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

SELECT 
	ayear,    
	sum(initial_residual) initial_residual,
	sum(var_residual) var_residual,
	sum(cash_residual) cash_residual,
	sum(var_cash_residual) var_cash_residual
FROM #report_residual
GROUP BY ayear
ORDER BY ayear ASC

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

