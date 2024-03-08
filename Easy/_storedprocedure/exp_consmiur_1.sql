
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_consmiur_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_consmiur_1]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE  PROCEDURE exp_consmiur_1
	@ayear int,
	@date	datetime,
	@finpart char(1),
	@levelusable varchar(10),
	@idupb varchar(36),
	@showchildupb char(1)
AS
BEGIN

DECLARE @flag_cs		char(1)
SELECT  @flag_cs = previsionkind
FROM    config
WHERE   ayear = @ayear

DECLARE @supposed_ff_jan01	decimal(19,2)
DECLARE @supposed_aa_jan01	decimal(19,2)
DECLARE @ff_jan01		decimal(19,2)
DECLARE @aa_jan01		decimal(19,2)
	
IF (@finpart = 'E')
BEGIN
	SELECT	
	@supposed_ff_jan01 =	
		ISNULL(startfloatfund, 0.0) +
		ISNULL(proceedstilldate, 0.0) +
		ISNULL(proceedstoendofyear, 0.0) -
		ISNULL(paymentstilldate, 0.0) -		
		ISNULL(paymentstoendofyear, 0.0),
	@supposed_aa_jan01 =	
		ISNULL(startfloatfund, 0.0) +
		ISNULL(proceedstilldate, 0.0) +
		ISNULL(proceedstoendofyear, 0.0) -
		ISNULL(paymentstilldate, 0.0) -
		ISNULL(paymentstoendofyear, 0.0) +
		ISNULL(supposedpreviousrevenue, 0.0) +
		ISNULL(supposedcurrentrevenue , 0.0) -
		ISNULL(supposedpreviousexpenditure, 0.0) -
		ISNULL(supposedcurrentexpenditure, 0.0),
	@ff_jan01 =	
		ISNULL(startfloatfund, 0.0) +
		ISNULL(competencyproceeds, 0.0) +
		ISNULL(residualproceeds, 0.0) -
		ISNULL(competencypayments, 0.0) -
		ISNULL(residualpayments, 0.0),
	@aa_jan01 =					
		ISNULL(startfloatfund, 0.0) +
		ISNULL(competencyproceeds, 0.0) +
		ISNULL(residualproceeds , 0.0) -
		ISNULL(competencypayments, 0.0) -
		ISNULL(residualpayments  , 0.0) +
		ISNULL(previousrevenue, 0.0) +
		ISNULL(currentrevenue , 0.0) -
		ISNULL(previousexpenditure, 0.0) -
		ISNULL(currentexpenditure, 0.0)
	FROM surplus
	WHERE ayear = @ayear - 1
END 

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb+'%' 
END

DECLARE @lengthidfinusab	int
SELECT 	@lengthidfinusab = (CONVERT(int,@levelusable) * 4 + 3 )

DECLARE @infoadvance		char(1)
SELECT 	@infoadvance = paramvalue
FROM 	reportadditionalparam
WHERE 	reportname = 'consentr'
AND 	paramname = 'MostraAvanzo'

DECLARE @cashvaliditykind	char(1)
SELECT  @cashvaliditykind = cashvaliditykind
FROM 	config
WHERE 	ayear = @ayear

DECLARE @finphase		varchar(10)
DECLARE @maxphase		varchar(10)

IF @finpart = 'E'
BEGIN
	SELECT @finphase = assessmentphasecode
	FROM config
	WHERE ayear = @ayear

	IF @finphase IS NULL
	BEGIN
		SELECT 	@finphase = nphase
		FROM 	incomephase
		WHERE 	flagfinance = 'S'
	END
	SELECT @maxphase = MAX(nphase)
	FROM incomephase
END
ELSE
BEGIN
	SELECT @finphase = appropriationphasecode
	FROM config
	WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		SELECT @finphase = nphase
		FROM expensephase
		WHERE flagfinance = 'S'
	END
	SELECT @maxphase = MAX(nphase)
	FROM expensephase
END

CREATE TABLE #balance
(
	idfin			varchar(39)		,
	codefin			varchar(10)		,
	description		varchar(100)		,
	printingorder		varchar(10)		,
	flagincomesurplus	char(1)			,
	initialprevision	decimal(19,2)		,
	var_main_prevision	decimal(19,2)		,
	sec_prevision		decimal(19,2)		,
	var_sec_prevision	decimal(19,2)		,
	supposed_partition	decimal(19,2)		,
	finphase		decimal(19,2)		,
	var_finphase		decimal(19,2)		,
	mov_maxphase_comp	decimal(19,2)		,
	var_mov_maxphase_comp	decimal(19,2)		,
	initial_residual	decimal(19,2)		,
	var_residual		decimal(19,2)		,
	mov_maxphase_resid	decimal(19,2)		,
	var_maxphase_resid	decimal(19,2)						
)

CREATE TABLE #balancemurst
(
	idfin			varchar(39)		,
	codefin			varchar(30)		,
	codelevel		varchar(1)		,
	curr_year_prevision	decimal(19,2)		,
	var_main_prevision	decimal(19,2)		,
	prev_year_prevision	decimal(19,2)		,
	var_sec_prevision	decimal(19,2)		,
	idsor  			varchar(36) 		,
	sortcode 		varchar(30) 		,
	description		varchar(100)		
)
	
CREATE TABLE #tot_var_main_prev
(idfin	varchar(39), total decimal(19,2))

CREATE TABLE #tot_var_sec_prev
(idfin	varchar(39), total decimal(19,2))

CREATE TABLE #tot_fin_phase
(idfin	varchar(39), total decimal(19,2))

CREATE TABLE #tot_var_fin_phase
(idfin	varchar(39), total decimal(19,2))

CREATE TABLE #tot_max_phase_comp
(idfin	varchar(39), total decimal(19,2))

CREATE TABLE #tot_var_max_phase_comp
(idfin	varchar(39), total decimal(19,2))

CREATE TABLE #tot_res_init
(idfin	varchar(39), total decimal(19,2))

CREATE TABLE #tot_var_res
(idfin	varchar(39), total decimal(19,2))

CREATE TABLE #tot_max_phase_res
(idfin	varchar(39), total decimal(19,2))

CREATE TABLE #tot_var_max_phase_res
(idfin	varchar(39), total decimal(19,2))
	
INSERT INTO #balancemurst
(
	idfin,
	codefin,
	codelevel,
	curr_year_prevision,
	var_main_prevision,
	prev_year_prevision,
	var_sec_prevision,
	idsor,
	sortcode,
	description		
)
SELECT  fin.idfin,  
	fin.codefin, 
	fin.nlevel,
	fin.prevision,                                
	0,
	fin.previousprevision ,
	0,
	finsorting.idsor,
	delete_classtabelle.delete_sortcode,
	delete_classtabelle.delete_description
FROM 	fin, finsorting, delete_classtabelle
WHERE   finsorting.idsor = delete_classtabelle.delete_idsor
	AND fin.idfin = finsorting.idfin
	AND finsorting.idsorkind = delete_classtabelle.delete_codicetipoclass
	AND delete_classtabelle.delete_codicetipoclass ='Miur'
	AND fin.ayear = @ayear
	
INSERT INTO #balance
(
	idfin,
	codefin,
--	description,
--	descliv1,
	printingorder,
	flagincomesurplus,
	initialprevision,
	sec_prevision
	--supposed_partition
)
SELECT 
	f4.idfin, 
	f4.codefin, 
	--b1.title,
	--l1.description,
	f4.printingorder, 
	f4.flagincomesurplus,
	ISNULL(SUM(fy.prevision),0),
	ISNULL(SUM(fy.secondaryprev),0)
	--ISNULL(b1.currentarrears, 0.0)
FROM fin f4
CROSS JOIN upb 
LEFT OUTER JOIN finyear fy
	ON fy.idfin = f4.idfin
	AND fy.idupb = upb.idupb
WHERE 	f4.ayear = @ayear
	AND f4.finpart = @finpart
	AND (upb.idupb LIKE @idupb)
	AND (f4.nlevel = @levelusable
		OR (b1.nlevel < @levelusable
		AND EXISTS
		(SELECT *
		FROM finusable
		WHERE finusable.idfin = f4.idfin)))
		AND (@infoadvance != 'S'
		OR b1.flagincomesurplus = 'N')

-- select * from #balance

INSERT INTO #tot_var_main_prev
	(
	idfin,
	total
	)
SELECT
	SUBSTRING(finvardetail.idfin, 1, @lengthidfinusab),
	SUM(finvardetail.amount) 
FROM finvardetail
JOIN finvar
	ON finvar.yvar = finvardetail.yvar
	AND finvar.nvar = finvardetail.nvar
WHERE finvar.yvar = @ayear
	AND finvardetail.idupb LIKE @idupb
	AND finvar.adate <= @date
	AND finvar.previsionkind = 'P'
	AND SUBSTRING(finvardetail.idfin, 3, 1) = @finpart
GROUP BY SUBSTRING(finvardetail.idfin, 1, @lengthidfinusab)

INSERT INTO #tot_var_sec_prev
	(
	idfin,
	total
	)
SELECT
	SUBSTRING(finvardetail.idfin, 1, @lengthidfinusab),
	SUM(finvardetail.amount) 
FROM finvardetail
JOIN finvar
	ON finvar.yvar = finvardetail.yvar
	AND finvar.nvar = finvardetail.nvar
WHERE finvar.yvar = @ayear
	AND finvardetail.idupb LIKE @idupb
	AND finvar.adate <= @date
	AND finvar.previsionkind = 'S'
	AND SUBSTRING(finvardetail.idfin, 3, 1) = @finpart
GROUP BY SUBSTRING(finvardetail.idfin, 1, @lengthidfinusab)
		
IF @finpart = 'E'
BEGIN
	INSERT INTO #tot_fin_phase
	(
		idfin,
		total
	)
	SELECT
		SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab),
		SUM(incomeyear.amount)
	FROM income
	JOIN incomeyear
		ON incomeyear.idinc = income.idinc
		AND incomeyear.ayear = @ayear
	WHERE income.adate <= @date
		AND incomeyear.idupb LIKE @idupb
		AND incomeyear.flagarrear = 'C'
		AND incomeyear.nphase = @finphase
	GROUP BY SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab)
	
	INSERT INTO #tot_var_fin_phase
		(
		idfin,
		total
		)
	SELECT 
		SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab),
		SUM(incomevar.amount)
	FROM incomevar
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
		AND incomeyear.ayear = @ayear
	WHERE incomevar.yvar = @ayear
		AND incomeyear.idupb LIKE @idupb
		AND incomeyear.flagarrear = 'C'
		AND incomeyear.nphase = @finphase
		AND incomevar.adate <= @date 
	GROUP BY SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab)
				
	INSERT INTO #tot_res_init
		(
		idfin,
		total
		)
	SELECT
		SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab),
		SUM(incomeyear.amount)
	FROM incomeyear
	JOIN income
		ON income.idinc = incomeyear.idinc
		AND incomeyear.ayear = @ayear
	WHERE 	incomeyear.idupb LIKE @idupb
		AND incomeyear.flagarrear = 'R'
		AND incomeyear.nphase = @finphase
		AND income.adate <= @date
	GROUP BY SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab)
	
	INSERT INTO #tot_var_res
		(
		idfin,
		total
		)
	SELECT 
		SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab),
		SUM(incomevar.amount)
	FROM incomevar
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
		AND incomeyear.ayear = @ayear
	WHERE 	incomevar.yvar = @ayear
		AND incomeyear.idupb LIKE @idupb
		AND incomeyear.flagarrear = 'R'
		AND incomeyear.nphase = @finphase
		AND incomevar.adate <= @date 
	GROUP BY SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab)

INSERT INTO #tot_max_phase_comp
		(
		idfin,
		total
		)
	SELECT
		SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab),
		SUM(proceedsemitted.amount)
	FROM historyproceedsview HPV
	JOIN incomeyear
		ON incomeyear.idinc = HPV.idinc
		AND incomeyear.ayear = @ayear
	WHERE 	HPV.competencydate <= @date
		AND HPV.ymov = @ayear
		AND incomeyear.idupb LIKE @idupb
		AND incomeyear.flagarrear = 'C'
		AND incomeyear.nphase = @maxphase
	GROUP BY SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab)

	INSERT INTO #tot_max_phase_res
		(
		idfin,
		total
		)
	SELECT
		SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab),
		SUM(proceedsemitted.amount)
	FROM historyproceedsview HPV
	JOIN incomeyear
		ON incomeyear.idinc = HPV.idinc
		AND incomeyear.ayear = @ayear
	WHERE HPV.competencydate <= @date
		AND HPV.ymov = @ayear
		AND incomeyear.idupb LIKE @idupb
		AND incomeyear.flagarrear = 'R'
		AND incomeyear.nphase = @maxphase
	GROUP BY SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab)
	
	IF @cashvaliditykind <> 'B'
	BEGIN
		INSERT INTO #tot_var_max_phase_comp
			(
			idfin,
			total
			)
		SELECT 
			SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab),
			SUM(incomevar.amount)
		FROM incomevar
		JOIN incomeyear
			ON incomeyear.idinc = incomevar.idinc
			AND incomeyear.ayear = @ayear
		WHERE 	incomevar.yvar = @ayear
			AND incomeyear.idupb LIKE @idupb
			AND incomeyear.flagarrear = 'C'
			AND incomeyear.nphase = @maxphase
			AND incomevar.adate <= @date
			AND EXISTS (SELECT * 
					FROM historyproceedsview HPV
					WHERE HPV.idinc = incomevar.idinc
						AND HPV.ymov = @ayear)
		GROUP BY SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab)
		
		INSERT INTO #tot_var_max_phase_res
			(
			idfin,
			total
			)
		SELECT 
			SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab),
			SUM(incomevar.amount)
		FROM incomevar
		JOIN incomeyear
			ON incomeyear.idinc = incomevar.idinc
			AND incomeyear.ayear = @ayear
		WHERE incomevar.yvar = @ayear
			AND incomeyear.idupb LIKE @idupb
			AND incomeyear.flagarrear = 'R'
			AND incomeyear.nphase = @maxphase
			AND incomevar.adate <= @date
			AND EXISTS(	SELECT * FROM historyproceedsview HPV
				   	WHERE HPV.idinc = incomevar.idinc
					AND HPV.ymov = @ayear)
		GROUP BY SUBSTRING(incomeyear.idfin, 1, @lengthidfinusab)
	END

END

ELSE
BEGIN
	INSERT INTO #tot_fin_phase
		(
		idfin,
		total
		)
	SELECT
		SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab),
		SUM(expenseyear.amount)
	FROM expense
	JOIN expenseyear
		ON expenseyear.idexp = expense.idexp
		AND expenseyear.ayear = @ayear
	WHERE expense.adate <= @date
		AND expenseyear.idupb LIKE @idupb
		AND expenseyear.flagarrear = 'C'
		AND expenseyear.nphase = @finphase
	GROUP BY SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab)
	
	INSERT INTO #tot_var_fin_phase
		(
		idfin,
		total
		)
	SELECT 
		SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab),
		SUM(expensevar.amount)
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = @ayear
	WHERE expensevar.yvar = @ayear
		AND expenseyear.idupb LIKE @idupb
		AND expenseyear.flagarrear = 'C'
		AND expenseyear.nphase = @finphase
		AND expensevar.adate <= @date 
	GROUP BY SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab)
				
	INSERT INTO #tot_res_init
		(
		idfin,
		total
		)
	SELECT
		SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab),
		SUM(expenseyear.amount)
	FROM expenseyear
	JOIN expense
		ON  expense.idexp = expenseyear.idexp
		AND expenseyear.ayear = @ayear
	WHERE   expenseyear.idupb LIKE @idupb
		AND expenseyear.flagarrear = 'R'
		AND expenseyear.nphase = @finphase
		AND expense.adate <= @date
	GROUP BY SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab)
	
	INSERT INTO #tot_var_res
		(
		idfin,
		total
		)
	SELECT 
		SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab),
		SUM(expensevar.amount)
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = @ayear
	WHERE 	expensevar.yvar = @ayear
		AND expenseyear.idupb LIKE @idupb
		AND expenseyear.flagarrear = 'R'
		AND expenseyear.nphase = @finphase
		AND expensevar.adate <= @date 
	GROUP BY SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab)
		INSERT INTO #tot_max_phase_comp
			(
			idfin,
			total
			)
		SELECT
			SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab),
			SUM(HPV.amount)
		FROM historypaymentview HPV
		JOIN expenseyear
			ON expenseyear.idexp = HPV.idexp
			AND expenseyear.ayear = @ayear
			AND HPV.ymov = @ayear
		WHERE HPV.competencydate <= @date
			AND expenseyear.idupb LIKE @idupb	
			AND expenseyear.flagarrear = 'C'
			AND expenseyear.nphase = @maxphase
		GROUP BY SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab)
	INSERT INTO #tot_max_phase_res
			(
			idfin,
			total
			)
		SELECT
			SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab),
			SUM(HPV.amount)
		FROM historypaymentview HPV
		JOIN expenseyear
			ON expenseyear.idexp = HPV.idexp
			AND expenseyear.ayear = @ayear
			AND HPV.ymov = @ayear
		WHERE 	expenseyear.idupb LIKE @idupb
			AND HPV.competencydate <= @date
			AND expenseyear.flagarrear = 'R'
			AND expenseyear.nphase = @maxphase
		GROUP BY SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab)

	IF @cashvaliditykind = 'E'
	BEGIN
	
		
	INSERT INTO #tot_var_max_phase_comp
		(
		idfin,
		total
		)
	SELECT 
		SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab),
		SUM(expensevar.amount)
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = @ayear
		WHERE expensevar.yvar = @ayear
			AND expenseyear.idupb LIKE @idupb
			AND expenseyear.flagarrear = 'C'
			AND expenseyear.nphase = @maxphase
			AND expensevar.adate <= @date
              		AND EXISTS(SELECT * FROM historypaymentview HPV
              		WHERE HPV.idexp = expensevar.idexp
				AND HPV.ymov = @ayear)
		GROUP BY SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab)
	
	INSERT INTO #tot_var_max_phase_res
		(
		idfin,
		total
		)
	SELECT 
		SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab),
		SUM(expensevar.amount)
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = @ayear
	WHERE expensevar.yvar = @ayear
		AND expenseyear.idupb LIKE @idupb
		AND expenseyear.flagarrear = 'R'
		AND expenseyear.nphase = @maxphase
		AND expensevar.adate <= @date
		AND EXISTS(SELECT * FROM historypaymentview HPV
			WHERE HPV.idexp = expensevar.idexp
				AND HPV.ymov = @ayear)
	GROUP BY SUBSTRING(expenseyear.idfin, 1, @lengthidfinusab)
END
END
    UPDATE #balance
      SET var_main_prevision =	      ISNULL((SELECT #tot_var_main_prev.total FROM #tot_var_main_prev
                              WHERE #tot_var_main_prev.idfin = #balance.idfin), 0.0),
      var_sec_prevision =	ISNULL((SELECT #tot_var_sec_prev.total FROM #tot_var_sec_prev
                              WHERE #tot_var_sec_prev.idfin = #balance.idfin), 0.0),
      finphase =          ISNULL((SELECT #tot_fin_phase.total FROM #tot_fin_phase
                              WHERE #tot_fin_phase.idfin = #balance.idfin), 0.0),
      var_finphase =       ISNULL((SELECT #tot_var_fin_phase.total FROM #tot_var_fin_phase
                              WHERE #tot_var_fin_phase.idfin = #balance.idfin), 0.0),
      mov_maxphase_comp =				ISNULL((SELECT #tot_max_phase_comp.total FROM #tot_max_phase_comp
                              WHERE #tot_max_phase_comp.idfin = #balance.idfin), 0.0),
      var_mov_maxphase_comp =		ISNULL((SELECT #tot_var_max_phase_comp.total FROM #tot_var_max_phase_comp
                              WHERE #tot_var_max_phase_comp.idfin = #balance.idfin), 0.0),
      initial_residual =       ISNULL((SELECT #tot_res_init.total FROM #tot_res_init
                              WHERE #tot_res_init.idfin = #balance.idfin), 0.0),
      var_residual =            ISNULL((SELECT #tot_var_res.total FROM #tot_var_res
                              WHERE #tot_var_res.idfin = #balance.idfin), 0.0),
      mov_maxphase_resid =					ISNULL((SELECT #tot_max_phase_res.total FROM #tot_max_phase_res
                              WHERE #tot_max_phase_res.idfin = #balance.idfin), 0.0),
      var_maxphase_resid =				ISNULL((SELECT #tot_var_max_phase_res.total FROM #tot_var_max_phase_res
                              WHERE #tot_var_max_phase_res.idfin = #balance.idfin), 0.0)
		UPDATE #balance
      SET cassaocompetenza =	@flag_cs,
			fondocassapres0101 =		@supposed_ff_jan01,
			avanzoamminpres0101 =		@supposed_aa_jan01,
			fondocassaeff0101 =			@ff_jan01,
			avanzoammineff0101 =		@aa_jan01
		IF @flag_cs = 'S'
			BEGIN
				UPDATE #balance
					SET mov_maxphase_comp = ISNULL(initialprevision, 0.0) + ISNULL(var_main_prevision, 0.0)
					WHERE flagincomesurplus = 'S'
			END



		SELECT 
			#balancemurst.sortcode,
			#balancemurst.description,

   		previsione =		SUM(ISNULL(#balance.initialprevision, 0.0)) ,

   		var_main_prevision =		SUM(ISNULL(#balance.var_main_prevision, 0.0)),

   		previsionefinale =	SUM(ISNULL(#balance.initialprevision, 0.0)) +
					SUM(ISNULL(#balance.var_main_prevision, 0.0)),
			
      		competenzafinphase =SUM(ISNULL(#balance.finphase, 0.0)) +
					SUM(ISNULL(#balance.var_finphase, 0.0)),

      		competenzafasefinale =	SUM(ISNULL(#balance.mov_maxphase_comp, 0.0)) +
					SUM(ISNULL(#balance.var_mov_maxphase_comp, 0.0)),

		competenzadifferenza = 	SUM(ISNULL(#balance.finphase, 0.0)) +
					SUM(ISNULL(#balance.var_finphase, 0.0)) -
					SUM(ISNULL(#balance.mov_maxphase_comp, 0.0)) -
					SUM(ISNULL(#balance.var_mov_maxphase_comp, 0.0)),

		residuifinphase =	SUM(ISNULL(#balance.initial_residual, 0.0)) +
					SUM(ISNULL(#balance.var_residual, 0.0)),

      		residuifasefinale =	SUM(ISNULL(#balance.mov_maxphase_resid, 0.0))+
					SUM(ISNULL(#balance.var_maxphase_resid, 0.0)),

		residuidifferenza = 	SUM(ISNULL(#balance.initial_residual, 0.0)) +
					SUM(ISNULL(#balance.var_residual, 0.0)) -
					SUM(ISNULL(#balance.mov_maxphase_resid, 0.0))-
					SUM(ISNULL(#balance.var_maxphase_resid, 0.0))
			
		FROM #balance
		JOIN #balancemurst
	  ON #balance.idfin = #balancemurst.idfin
    GROUP BY #balancemurst.sortcode,
#balancemurst.description
order by #balancemurst.sortcode
--#balance.idfin,
  END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

