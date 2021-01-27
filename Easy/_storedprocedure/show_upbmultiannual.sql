
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



if exists (select * from dbo.sysobjects where id = object_id(N'[show_upbmultiannual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_upbmultiannual]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE                    PROCEDURE [show_upbmultiannual]
	@date datetime,
	@idupb varchar(36)
AS BEGIN
	-- Modifica importante: La previsione attuale è data dalla previsione attuale di competenza + il movimento (impegnato o accertato) degli anni precedenti

	DECLARE @ayear int
	SET @ayear = YEAR(@date)
	
	DECLARE @fin_kind tinyint
	SELECT  @fin_kind = ISNULL(fin_kind,0) FROM config WHERE ayear = @ayear

	CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))
	
	DECLARE @incomeprevision decimal(19,2)
  	SELECT @incomeprevision = ISNULL(SUM(prevision),0)
	FROM finyearview
	WHERE idupb = @idupb
		AND finpart = 'E'
		AND ayear = @ayear
		AND nlevel = (SELECT MIN(nlevel) FROM finlevel 
			WHERE ayear = finyearview.ayear AND (flag & 2)<>0)

	DECLARE @expenseprevision decimal(19,2)
  	SELECT @expenseprevision = ISNULL(SUM(prevision),0)
	FROM finyearview
	WHERE idupb = @idupb
		AND finpart = 'S'
		AND finyearview.ayear = @ayear
		AND nlevel = (SELECT MIN(nlevel) FROM finlevel 
			WHERE ayear = finyearview.ayear AND (flag & 2)<>0)

	DECLARE @incomevar decimal(19,2)
 	SELECT @incomevar = ISNULL(SUM(d.amount),0)
	FROM finvar v
	JOIN finvardetail d
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN fin f
		ON f.idfin = d.idfin 
	WHERE d.idupb = @idupb
		AND ((f.flag & 1) = 0 )
		AND v.yvar = @ayear
		AND v.adate <= @date
		AND v.variationkind <> 5 
		AND v.flagprevision = 'S'
		AND v.idfinvarstatus = 5

	DECLARE @expensevar decimal(19,2)
  	SELECT @expensevar = ISNULL(SUM(d.amount),0)
	FROM finvar v
	JOIN finvardetail d
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN fin f
		ON f.idfin = d.idfin 
	WHERE d.idupb = @idupb
		AND ((f.flag & 1) = 1 )
		AND v.yvar = @ayear
		AND v.adate <= @date
		AND v.variationkind <> 5 
		AND v.flagprevision = 'S'
		AND v.idfinvarstatus = 5

	DECLARE @finincomephase tinyint
	SELECT  @finincomephase = incomefinphase from uniconfig
	

	DECLARE @finexpensephase tinyint
	SELECT  @finexpensephase = expensefinphase from uniconfig
	
	DECLARE @maxincomephase  tinyint
	DECLARE @maxexpensephase tinyint
	SELECT  @maxexpensephase = MAX (nphase) FROM expensephase
	SELECT  @maxincomephase  = MAX (nphase) FROM incomephase

	DECLARE @flagcompetency char(1)
	SET @flagcompetency = 'C'

	DECLARE @flagarrears char(1)
	SET @flagarrears  = 'R'

	DECLARE @flagprevmov char(1)
	SET @flagprevmov = 'P' 
	
	-- Movimenti di entrata esercizio corrente
	CREATE TABLE #totincome(nphase tinyint, tot decimal(19,2), flagarrear char(1))
	INSERT INTO #totincome
	SELECT 
		income.nphase, 
		ISNULL(SUM(incomeyear.amount),0),
		 @flagcompetency
	FROM incomeyear
	JOIN income
		ON income.idinc = incomeyear.idinc
	WHERE incomeyear.ayear = @ayear
		AND income.ymov = @ayear
		AND income.adate <= @date
		AND income.nphase >= @finincomephase
		AND incomeyear.idupb = @idupb
	GROUP BY income.nphase
	
	-- Variazione Movimenti di entrata esercizio corrente
	CREATE TABLE #totincomevar(nphase tinyint, tot decimal(19,2), flagarrear char(1))
	INSERT INTO #totincomevar
	SELECT 
		income.nphase, 
		ISNULL(SUM(incomevar.amount),0),
		@flagcompetency
	FROM incomevar
	JOIN income
		ON income.idinc = incomevar.idinc
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
	WHERE incomevar.adate <= @date
		AND incomevar.yvar = @ayear
		AND income.ymov = @ayear
		AND incomeyear.idupb = @idupb
		AND income.nphase >= @finincomephase
		AND incomeyear.ayear = @ayear
	GROUP BY income.nphase
	
	-- Movimenti di entrata in c/residui esercizio corrente
	INSERT INTO #totincome
	SELECT 
		income.nphase, 
		ISNULL(SUM(incomeyear.amount),0),
		@flagarrears
	FROM income
	JOIN incomeyear
		ON incomeyear.idinc = income.idinc
	JOIN incometotal
		ON incometotal.idinc = incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	WHERE income.adate <= @date
		AND income.nphase >= @finincomephase
		AND incomeyear.idupb = @idupb
		AND ((incometotal.flag & 1) = 1)
		AND incomeyear.ayear = @ayear
	GROUP BY income.nphase
	
	-- Variazione Movimenti di entrata in c/residui esercizio corrente
	INSERT INTO #totincomevar
	SELECT 
		income.nphase, 
		ISNULL(SUM(incomevar.amount),0),
		@flagarrears
	FROM incomevar
	JOIN income
		ON income.idinc = incomevar.idinc
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
	JOIN incometotal
		ON incometotal.idinc = incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	WHERE incomevar.adate <= @date
		AND incomevar.yvar = @ayear
		AND incomeyear.idupb = @idupb
		AND income.nphase >= @finincomephase
		AND incomeyear.ayear = @ayear
		AND ((incometotal.flag & 1) = 1)
	GROUP BY income.nphase
	
	-- Movimenti di entrata degli esercizi precedenti
	INSERT INTO #totincome
	SELECT income.nphase,
		ISNULL(SUM(incomeyear.amount),0),
		@flagprevmov
	FROM income
	JOIN incomeyear
		ON income.idinc = incomeyear.idinc
		AND income.ymov = incomeyear.ayear
	WHERE income.ymov < @ayear
		AND incomeyear.ayear < @ayear
		AND incomeyear.idupb = @idupb
		AND income.nphase >= @finincomephase
	GROUP BY income.nphase
	
	--- CONTROLLARE SE VENGONO PRESI, CON MOLTA PROBABILITA', PER DUE O PIU' VOLTE I MOVIMENTI RESIDUI
	-- Variazione dei movimenti di entrata degli esercizi precedenti
	INSERT INTO #totincomevar
	SELECT
		income.nphase,
		ISNULL(SUM(incomevar.amount),0),
		@flagprevmov
	FROM income
	JOIN incomevar
		ON income.idinc = incomevar.idinc
	JOIN incomeyear
		ON income.idinc = incomeyear.idinc
		AND income.ymov = incomeyear.ayear
	WHERE income.ymov < @ayear
		AND incomevar.yvar <= @ayear
		AND incomeyear.ayear < @ayear
		AND incomevar.adate <= @date
		AND incomeyear.idupb = @idupb
		AND income.nphase >= @finincomephase
	GROUP BY income.nphase
	
	-- Movimenti di spesa esercizio corrente
	CREATE TABLE #totexpense(nphase tinyint, tot decimal(19,2), flagarrear char(1))
	INSERT INTO #totexpense
	SELECT 
		expense.nphase, 
		ISNULL(SUM(expenseyear.amount),0),
		@flagcompetency
	FROM expenseyear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	WHERE expenseyear.ayear = @ayear
		AND expense.ymov = @ayear
		AND expense.adate <= @date
		AND expense.nphase >= @finexpensephase
		AND expenseyear.idupb = @idupb
	GROUP BY expense.nphase
	
	-- Variazione Movimenti di spesa esercizio corrente
	CREATE TABLE #totexpensevar(nphase tinyint, tot decimal(19,2), flagarrear char(1))
	INSERT INTO #totexpensevar
	SELECT 
		expense.nphase, 
		ISNULL(SUM(expensevar.amount),0),
		@flagcompetency
	FROM expensevar
	JOIN expense
		ON expense.idexp = expensevar.idexp
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
	WHERE expensevar.adate <= @date
		AND expensevar.yvar = @ayear
		AND expense.ymov = @ayear
		AND expenseyear.idupb = @idupb
		AND expense.nphase >= @finexpensephase
		AND expenseyear.ayear = @ayear
	GROUP BY expense.nphase
	
	-- Movimenti di spesa in c/residui esercizio corrente
	INSERT INTO #totexpense
	SELECT 
		expense.nphase, 
		ISNULL(SUM(expenseyear.amount),0),
		@flagarrears
	FROM expense
	JOIN expenseyear
		ON expenseyear.idexp = expense.idexp
	JOIN expensetotal
		ON expensetotal.idexp = expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	WHERE expense.adate <= @date
		AND expense.nphase >= @finexpensephase
		AND expenseyear.idupb = @idupb
		AND ((expensetotal.flag & 1) = 1)
		AND expenseyear.ayear = @ayear
	GROUP BY expense.nphase
	
	-- Variazione Movimenti di spesa in c/residui esercizio corrente
	INSERT INTO #totexpensevar
	SELECT 
		expense.nphase, 
		ISNULL(SUM(expensevar.amount),0),
		@flagarrears
	FROM expensevar
	JOIN expense
		ON expense.idexp = expensevar.idexp
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
	JOIN expensetotal
		ON expensetotal.idexp = expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	WHERE expensevar.adate <= @date
		AND expensevar.yvar = @ayear
		AND expenseyear.idupb = @idupb
		AND expense.nphase >= @finexpensephase
		AND expenseyear.ayear = @ayear
		AND ((expensetotal.flag & 1) = 1) 
	GROUP BY expense.nphase
	
	-- Movimenti di spesa degli esercizi precedenti
	INSERT INTO #totexpense
	SELECT
		expense.nphase,
		ISNULL(SUM(expenseyear.amount),0),
		@flagprevmov
	FROM expense
	JOIN expenseyear
		ON expense.idexp = expenseyear.idexp
		AND expense.ymov = expenseyear.ayear
	WHERE expense.ymov < @ayear
		AND expenseyear.idupb = @idupb
		AND expense.nphase >= @finexpensephase
	GROUP BY expense.nphase
	
	-- Variazione dei movimenti di spesa degli esercizi precedenti
	INSERT INTO #totexpensevar
	SELECT
		expense.nphase,
		ISNULL(SUM(expensevar.amount),0),
		@flagprevmov
	FROM expense
	JOIN expensevar
		ON expense.idexp = expensevar.idexp
	JOIN expenseyear
		ON expense.idexp = expenseyear.idexp
		AND expense.ymov = expenseyear.ayear
	WHERE expense.ymov < @ayear
		AND expensevar.yvar <= @ayear
		AND expenseyear.ayear < @ayear
		AND expensevar.adate <= @date
		AND expenseyear.idupb = @idupb
		AND expense.nphase >= @finexpensephase
	GROUP BY expense.nphase
	

	DECLARE @departmentname varchar(150)
	SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')

	DECLARE @totpettycashop decimal(19,2)
	SELECT @totpettycashop = ISNULL(SUM(operation.amount),0) FROM pettycashoperation operation
			WHERE operation.idupb = @idupb AND operation.adate <= @date
	AND NOT EXISTS 
		(SELECT * FROM pettycashoperation restoreop
		WHERE restoreop.yrestore = operation.yrestore
			AND restoreop.nrestore = operation.nrestore
			AND restoreop.idpettycash = operation.idpettycash
			AND restoreop.adate <= @date)

	INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
	INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
	DECLARE @codeupb varchar(50)
	DECLARE @descupb varchar(150)
	SELECT @codeupb = codeupb, @descupb = title FROM upb WHERE idupb = @idupb
	
	INSERT INTO #situation VALUES ('U.P.B. ' + @codeupb + ' - ' + @descupb, NULL, 'H')
	INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4), @ayear), NULL, 'H')
	INSERT INTO #situation VALUES ('', NULL, 'N')

	DECLARE @requested decimal(19,2)
	DECLARE @granted decimal(19,2)
	SELECT @requested = requested, @granted = granted FROM upb WHERE idupb = @idupb
	
	DECLARE @requested_distributed decimal(19,2)
	SELECT @requested_distributed = ISNULL(SUM(requested),0) FROM upb 
					WHERE paridupb = @idupb
	DECLARE @granted_distributed decimal(19,2)
	SELECT @granted_distributed = ISNULL(SUM(granted),0) FROM upb 
					WHERE paridupb = @idupb

	DECLARE @showgranted char(1)
	IF (@requested IS NOT NULL) OR (@granted IS NOT NULL)
	BEGIN
		SET @showgranted = 'S'
	END
	ELSE
	BEGIN
		SET @showgranted = 'N'
	END
	
	IF (@showgranted = 'S')
	BEGIN
		INSERT INTO #situation VALUES ('G E N E R A L E', NULL, 'N')
		INSERT INTO #situation VALUES ('Finanziamento richiesto', @requested, '')
		INSERT INTO #situation VALUES ('Finanziamento richiesto ripartito', @requested_distributed, '')
		INSERT INTO #situation VALUES ('Finanziamento richiesto da ripartire', 
			ISNULL(@requested, 0) - ISNULL(@requested_distributed, 0), 'S')

		INSERT INTO #situation VALUES ('Finanziamento concesso', @granted, '')
		INSERT INTO #situation VALUES ('Finanziamento concesso ripartito', @granted_distributed, '')
		INSERT INTO #situation VALUES ('Finanziamento concesso da ripartire', 
			ISNULL(@granted, 0) - ISNULL(@granted_distributed, 0), 'S')
		INSERT INTO #situation VALUES ('', NULL, 'N')
	END
	
	DECLARE @assessment_pastyears decimal(19,2)
	
	IF (@fin_kind IN(1,3))
	BEGIN	
		SET @assessment_pastyears =
		ISNULL(
			(SELECT SUM(tot)
			FROM #totincome
			WHERE flagarrear = @flagprevmov
				AND nphase = @finincomephase)
		,0) +
		ISNULL(
			(SELECT SUM(tot)
			FROM #totincomevar
			WHERE flagarrear = @flagprevmov
				AND nphase = @finincomephase)
		,0)
	END
	ELSE
	BEGIN
		SET @assessment_pastyears =
		ISNULL(
			(SELECT SUM(tot)
			FROM #totincome
			WHERE flagarrear = @flagprevmov
				AND nphase = @maxincomephase)
		,0) +
		ISNULL(
			(SELECT SUM(tot)
			FROM #totincomevar
			WHERE flagarrear = @flagprevmov
				AND nphase = @maxincomephase)
		,0)
	END

	SET @incomeprevision = @incomeprevision + @assessment_pastyears

	INSERT INTO #situation VALUES ('E N T R A T A', NULL, 'N')
	INSERT INTO #situation VALUES ('Previsione Iniziale', @incomeprevision, '')
	INSERT INTO #situation VALUES ('Variazioni', @incomevar, '')
	INSERT INTO #situation VALUES ('Previsione Attuale', 
	ISNULL(@incomeprevision, 0) + 
	ISNULL(@incomevar, 0), 'S')

	DECLARE @nphase tinyint
	DECLARE @phasedesc varchar(50)
	DECLARE @totcompetency decimal(19,2)
	DECLARE @competencyvar decimal(19,2)
	DECLARE @totarrears decimal(19,2)
	DECLARE @arrearsvar decimal(19,2)
	DECLARE @totprev decimal(19,2)
	DECLARE @prevvar decimal(19,2)

	DECLARE phase_crs INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM incomephase
	WHERE nphase >= @finincomephase
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totcompetency = 0
		SET @competencyvar = 0
		SET @totarrears = 0
		SET @arrearsvar = 0
		SET @totprev = 0
		SET @prevvar = 0
		SELECT @totcompetency = ISNULL(SUM(tot),0)	FROM #totincome	WHERE nphase = @nphase AND flagarrear = @flagcompetency
		SELECT @competencyvar = ISNULL(SUM(tot),0)	FROM #totincomevar	WHERE nphase = @nphase AND flagarrear = @flagcompetency
		SELECT @totarrears = ISNULL(SUM(tot),0)	FROM #totincome  	WHERE nphase = @nphase AND flagarrear = @flagarrears
		SELECT @arrearsvar = ISNULL(SUM(tot),0)	FROM #totincomevar	WHERE nphase = @nphase AND flagarrear = @flagarrears
		SELECT @totprev = ISNULL(SUM(tot),0)	FROM #totincome 	WHERE nphase = @nphase AND flagarrear = @flagprevmov
		SELECT @prevvar = ISNULL(SUM(tot),0)	FROM #totincomevar	WHERE nphase = @nphase AND flagarrear = @flagprevmov
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc + ') es. corrente', @totcompetency, '')
		INSERT INTO #situation VALUES('2.Totale movimenti in c/residui (' + @phasedesc	+ ') es. corrente', @totarrears, '')
		INSERT INTO #situation VALUES('3.Totale movimenti (' + @phasedesc	+ ') es. precedenti', @totprev, '')
		INSERT INTO #situation VALUES('4.Totale variazioni movimenti (' + @phasedesc + ') es. corrente', @competencyvar, '')
		INSERT INTO #situation VALUES('5.Totale variazioni movimenti in c/residui (' + @phasedesc + ') es. corrente', @arrearsvar, '')
		INSERT INTO #situation VALUES('6.Totale variazioni movimenti (' + @phasedesc + ') es. precedenti', @prevvar, '')
	
		INSERT INTO #situation VALUES('Previsione disponibile (' + @phasedesc + ') (Prev. Att. - 1 - 3 - 4 - 6)', 
		ISNULL(@incomeprevision, 0) + 
		ISNULL(@incomevar, 0) - 
		ISNULL(@totcompetency, 0) -
		ISNULL(@totprev ,0) -
		ISNULL(@competencyvar, 0) -
		ISNULL(@prevvar, 0),'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES('Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 - 3 - 4 - 6)', 
			ISNULL(@granted, 0) - 
			ISNULL(@totcompetency, 0) -
			ISNULL(@totprev ,0) -
			ISNULL(@competencyvar, 0) -
			ISNULL(@prevvar, 0),'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs

	INSERT INTO #situation VALUES ('', NULL, 'N')

	DECLARE @prev_arrears decimal(19,2)
		
	IF (@fin_kind IN(1,3))
	BEGIN	
		
	
	SET @prev_arrears =
		ISNULL(
			(SELECT SUM(tot)
			FROM #totexpense
			WHERE flagarrear = @flagprevmov
				AND nphase = @finexpensephase)
		,0) +
		ISNULL(
			(SELECT SUM(tot)
			FROM #totexpensevar
			WHERE flagarrear = @flagprevmov
				AND nphase = @finexpensephase)
		,0)
	END
	ELSE
	BEGIN
		SET @prev_arrears = 
		ISNULL(
			(SELECT SUM(tot)
			FROM #totexpense
			WHERE flagarrear = @flagprevmov
				AND nphase = @maxexpensephase)
		,0) +
		ISNULL(
			(SELECT SUM(tot)
			FROM #totexpensevar
			WHERE flagarrear = @flagprevmov
				AND nphase = @maxexpensephase)
		,0)
	END
	SET @expenseprevision = @expenseprevision + @prev_arrears
	INSERT INTO #situation VALUES ('S P E S A', NULL, 'N')
	INSERT INTO #situation VALUES ('Previsione Iniziale', @expenseprevision, '')
	INSERT INTO #situation VALUES ('Variazioni', @expensevar, '')
	INSERT INTO #situation VALUES ('Previsione Attuale', 
	ISNULL(@expenseprevision, 0) + 
	ISNULL(@expensevar, 0), 'S')
	DECLARE phase_crs INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM expensephase
	WHERE nphase >= @finexpensephase
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totcompetency = 0
		SET @competencyvar = 0
		SET @totarrears = 0
		SET @arrearsvar = 0
		SET @totprev = 0
		SET @prevvar = 0
		SELECT @totcompetency = ISNULL(SUM(tot),0) 		FROM #totexpense	WHERE nphase = @nphase and flagarrear = @flagcompetency
		SELECT @competencyvar = ISNULL(SUM(tot),0)	FROM #totexpensevar		WHERE nphase = @nphase and flagarrear = @flagcompetency
		SELECT @totarrears = ISNULL(SUM(tot),0) 	FROM #totexpense		WHERE nphase = @nphase and flagarrear = @flagarrears
		SELECT @arrearsvar = ISNULL(SUM(tot),0)	FROM #totexpensevar			WHERE nphase = @nphase and flagarrear = @flagarrears
		SELECT @totprev = ISNULL(SUM(tot),0)	FROM #totexpense			WHERE nphase = @nphase and flagarrear = @flagprevmov
		SELECT @prevvar = ISNULL(SUM(tot),0) FROM #totexpensevar			WHERE nphase = @nphase and flagarrear = @flagprevmov
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ') es. corrente', @totcompetency, '')
		INSERT INTO #situation VALUES('2.Totale movimenti in c/residui (' + @phasedesc+ ') es. corrente', @totarrears, '')
		INSERT INTO #situation VALUES('3.Totale movimenti (' + @phasedesc + ') es. precedenti', @totprev, '')
		INSERT INTO #situation VALUES('4.Totale variazioni movimenti (' + @phasedesc + ') es. corrente', @competencyvar, '')
		INSERT INTO #situation VALUES('5.Totale variazioni movimenti in c/residui (' + @phasedesc + ') es. corrente', @arrearsvar, '')
		INSERT INTO #situation VALUES('6.Totale variazioni movimenti (' + @phasedesc + ') es. precedenti', @prevvar, '')
		DECLARE @labelavail varchar(150)
		DECLARE @labelgranted varchar(150)
		SET @labelavail = 'Previsione disponibile (' + @phasedesc + ') (Prev. Att. - 1 - 3 - 4 - 6'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 - 3 - 4 - 6'
		IF @totpettycashop > 0
		BEGIN
			INSERT INTO #situation VALUES(
			'7.Totale op. fondo economale attribuite non reintegrate',
			@totpettycashop, '')
			SET @labelavail = @labelavail + ' - 7'
			SET @labelgranted = @labelgranted + ' - 7'
		END
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@expenseprevision, 0) + 
		ISNULL(@expensevar, 0) - 
		ISNULL(@totcompetency, 0) -
		ISNULL(@totprev, 0) -
		ISNULL(@competencyvar, 0) -
		ISNULL(@prevvar, 0) -
		ISNULL(@totpettycashop, 0), 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totcompetency, 0) -
			ISNULL(@totprev, 0) -
			ISNULL(@competencyvar, 0) -
			ISNULL(@prevvar, 0) -
			ISNULL(@totpettycashop, 0),'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs
	SELECT value, amount, kind FROM #situation
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

