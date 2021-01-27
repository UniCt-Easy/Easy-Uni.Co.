
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_upbannual_onlycash]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_upbannual_onlycash]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE    PROCEDURE [show_upbannual_onlycash]
	@date datetime,
	@idupb varchar(36)
AS BEGIN


	DECLARE @ayear int
	SELECT @ayear = YEAR(@date)

	CREATE TABLE #situation (value varchar(250), amount decimal(19,2),kind char(1))
	
	DECLARE @revenuephase int
	SELECT @revenuephase = 1
	DECLARE @finincomephase tinyint
	SELECT @revenuephase = incomefinphase, @finincomephase = incomefinphase FROM uniconfig

	DECLARE @arrearphase int
	SELECT @arrearphase = 1

	DECLARE @finexpensephase tinyint
	SELECT @arrearphase = expensefinphase, @finexpensephase = expensefinphase FROM uniconfig

	DECLARE @departmentname	varchar(150)
	SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')
	
	DECLARE @usablelevel tinyint --varchar(20)
	SELECT @usablelevel = MIN(nlevel) FROM finlevel WHERE (flag & 2)<>0 AND ayear = @ayear
	
	DECLARE @codeupb varchar(50)
	DECLARE @assured char(1)
	DECLARE @fintitle varchar(150)
	SELECT  @codeupb = codeupb, @fintitle = title, @assured = assured FROM upb WHERE idupb = @idupb
	
	DECLARE @maxincomephase tinyint
	SELECT  @maxincomephase = MAX(nphase) FROM incomephase

	DECLARE @maxexpensephase tinyint
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase
		
	DECLARE @totalincomeprevision decimal(19,2)
	SELECT  @totalincomeprevision = SUM(prevision) FROM finyearview
		WHERE idupb = @idupb AND finpart='E' AND nlevel = @usablelevel AND ayear = @ayear
	
	DECLARE @totalexpenseprevision decimal(19,2)
	SELECT @totalexpenseprevision = SUM(prevision)	FROM finyearview
		WHERE idupb = @idupb AND finpart='S' AND nlevel = @usablelevel AND ayear = @ayear
	
	DECLARE @totalincomeprevisionvar decimal(19,2)
	SELECT @totalincomeprevisionvar = SUM(d.amount)
	FROM finvar v
	JOIN finvardetail d	
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN fin f
		ON f.idfin = d.idfin 
	WHERE d.idupb = @idupb
		AND v.adate <= @date
		AND v.flagprevision = 'S'
		AND v.idfinvarstatus = 5
		AND v.variationkind <> 5
		AND ((f.flag & 1) = 0 )
		AND v.yvar = @ayear

	DECLARE @totalexpenseprevisionvar decimal(19,2)	
	SELECT @totalexpenseprevisionvar = SUM(d.amount)
	FROM finvar v
	JOIN finvardetail d
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN fin f
		ON f.idfin = d.idfin 
	WHERE d.idupb = @idupb
		AND v.adate <= @date
		AND v.flagprevision = 'S'
		AND v.idfinvarstatus = 5
		AND v.variationkind <> 5
		AND ((f.flag & 1) = 1 )
		AND v.yvar = @ayear
	
	DECLARE @totalproceedsvar decimal(19,2)
	DECLARE @totalproceedspart decimal(19,2)
	IF (@assured <> 'S')
	BEGIN
		SELECT @totalproceedsvar = SUM(d.amount)
		FROM finvar v
		JOIN finvardetail d
			ON v.yvar = d.yvar
			AND v.nvar = d.nvar
		JOIN fin F
			ON F.idfin = D.idfin 
		WHERE d.idupb = @idupb
			AND v.adate <= @date
			AND v.flagproceeds = 'S'
			AND v.idfinvarstatus = 5
			AND v.variationkind <> 5
			AND d.yvar = @ayear
			AND (F.flag & 1) = 1
		
		SELECT @totalproceedspart = SUM(p.amount)
		FROM proceedspart p
		WHERE p.idupb = @idupb
			AND p.adate <= @date
			AND p.yproceedspart = @ayear
	END
	ELSE
	BEGIN
		SET @totalproceedsvar = 0
		SET @totalproceedspart = 0
	END


	CREATE TABLE #competency_income	(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #competency_income
		SELECT income.nphase, 
			SUM(incomeyear.amount)
		FROM incomeyear
		JOIN incometotal
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN income
			ON income.idinc = incomeyear.idinc
		WHERE incomeyear.idupb = @idupb
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1) = 0) --Competenza
			AND income.nphase >= @finincomephase
			AND income.adate <= @date
		GROUP BY income.nphase
	
	CREATE TABLE #competency_expense(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #competency_expense
		SELECT expense.nphase, 
			SUM(expenseyear.amount)
		FROM expenseyear
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN expense
			ON expense.idexp = expenseyear.idexp
		WHERE expenseyear.idupb = @idupb
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 0) --Competenza
			AND expense.nphase >= @finexpensephase
			AND expense.adate <= @date
		GROUP BY expense.nphase
				
	-- Totale mandati in c/competenza
	DECLARE @totpayment_c decimal(19,2)
	SET @totpayment_c =
	ISNULL(
		(SELECT SUM(curramount)
		FROM historypaymentview HPV
		WHERE ((HPV.totflag & 1) = 0) --Competenza
			AND idupb = @idupb
			AND competencydate <= @date
			AND ymov = @ayear)
	,0)

	-- Totale mandati in c/residuo
	DECLARE @totpayment_r decimal(19,2)
	SET @totpayment_r =
	ISNULL(
		(SELECT SUM(curramount)
		FROM historypaymentview HPV
		WHERE ((HPV.totflag & 1) = 1) --Residuo
			AND idupb = @idupb
			AND competencydate <= @date
			AND ymov = @ayear)
	,0)

	-- Totale reversali emesse in c/competenza
	DECLARE @totproceeds_c decimal(19,2)
	SET @totproceeds_c =
	ISNULL(
		(SELECT SUM(curramount)
		FROM historyproceedsview HPV
		WHERE ((HPV.totflag & 1) = 0) --Competenza
			AND idupb = @idupb
			AND competencydate <= @date
			AND ymov = @ayear)
	,0)

	-- Totale reversali emesse in c/residuo
	DECLARE @totproceeds_r decimal(19,2)
	SET @totproceeds_r =
	ISNULL(
		(SELECT SUM(curramount)
		FROM historyproceedsview HPV
		WHERE ((HPV.totflag & 1) = 1) --Residuo
			AND idupb = @idupb
			AND competencydate <= @date
			AND ymov = @ayear)
	,0)

	CREATE TABLE #arrear_income(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #arrear_income
		SELECT income.nphase, 
		SUM(incomeyear.amount)
		FROM incomeyear
		JOIN incometotal
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN income
			ON income.idinc = incomeyear.idinc
		WHERE incomeyear.idupb = @idupb
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1) = 1) --Residuo
			AND income.nphase >= @finincomephase
			AND income.adate <= @date
		GROUP BY income.nphase
	
	CREATE TABLE #arrear_expense(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #arrear_expense
		SELECT expense.nphase, 
		SUM(expenseyear.amount)
		FROM expenseyear
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN expense
			ON expense.idexp = expenseyear.idexp
		WHERE expenseyear.idupb = @idupb
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 1) --Residuo
			AND expense.nphase >= @finexpensephase
			AND expense.adate <= @date
		GROUP BY expense.nphase
	
	CREATE TABLE #competency_incomevar(	nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #competency_incomevar
		SELECT income.nphase, 
			SUM(incomevar.amount)
		FROM incomevar
		JOIN incomeyear
			ON incomeyear.idinc = incomevar.idinc
		JOIN incometotal
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN income
			ON income.idinc = incomeyear.idinc
		WHERE incomevar.yvar = @ayear
			AND incomevar.adate <= @date
			AND incomeyear.idupb = @idupb
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1) = 0) --Competenza
			AND income.nphase >= @finincomephase
		GROUP BY income.nphase
	
	CREATE TABLE #competency_expensevar(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #competency_expensevar
		SELECT expense.nphase, 
			SUM(expensevar.amount)
		FROM expensevar
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN expense
			ON expense.idexp = expenseyear.idexp
		WHERE expensevar.yvar = @ayear
			AND expensevar.adate <= @date
			AND expenseyear.idupb = @idupb
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 0) --Competenza
			AND expense.nphase >= @finexpensephase
		GROUP BY expense.nphase
	
	CREATE TABLE #arrear_incomevar(	nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #arrear_incomevar
		SELECT income.nphase, 
			SUM(incomevar.amount)
		FROM incomevar
		JOIN incomeyear
			ON incomeyear.idinc = incomevar.idinc
		JOIN incometotal
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN income
			ON income.idinc = incomeyear.idinc
		WHERE incomevar.yvar = @ayear
			AND incomevar.adate <= @date
			AND incomeyear.idupb = @idupb
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1) = 1) --Residuo
			AND income.nphase >= @finincomephase
		GROUP BY income.nphase
	
	CREATE TABLE #arrear_expensevar(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #arrear_expensevar
		SELECT expense.nphase, 
			SUM(expensevar.amount)
		FROM expensevar
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN expense
			ON expense.idexp = expenseyear.idexp
		WHERE expensevar.yvar = @ayear
			AND expensevar.adate <= @date
			AND expenseyear.idupb = @idupb
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 1) --Residuo
			AND expense.nphase >= @finexpensephase
		GROUP BY expense.nphase


	DECLARE @totpettycashop decimal(19,2)
	SELECT @totpettycashop = SUM(operation.amount)
		FROM pettycashoperation operation
		WHERE operation.idupb = @idupb
		and operation.yoperation = @ayear
		AND operation.adate <= @date
		AND NOT EXISTS
			(SELECT * FROM pettycashoperation restoreop
			WHERE restoreop.yrestore = operation.yrestore
				AND restoreop.nrestore = operation.nrestore
				AND restoreop.idpettycash = operation.idpettycash
				AND restoreop.adate <= @date)

	DECLARE @competency_tot decimal(19,2)
	DECLARE @competency_totvar decimal(19,2)
	DECLARE @arrears_tot decimal(19,2)
	DECLARE @arrears_totvar decimal(19,2)
	DECLARE @nphase tinyint
	DECLARE @phasedescription varchar(50)
	
	INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
	INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
	INSERT INTO #situation VALUES (@codeupb + ' - ' + @fintitle, NULL, 'H')
	INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4), @ayear), NULL, 'H')
	INSERT INTO #situation VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES('E N T R A T A  ',NULL,'N')
--Movimenti entrata
	INSERT INTO #situation VALUES ('Previsione iniziale', @totalincomeprevision, '')
	INSERT INTO #situation VALUES ('Variazioni', @totalincomeprevisionvar, '')
	INSERT INTO #situation VALUES ('Previsione Attuale',
		ISNULL(@totalincomeprevision,0) +
		ISNULL(@totalincomeprevisionvar,0)
		,'S')
	DECLARE crs_income INSENSITIVE CURSOR FOR
		SELECT nphase, description FROM incomephase
		WHERE nphase >= @finincomephase
		FOR READ ONLY
	OPEN crs_income
	FETCH NEXT FROM crs_income INTO @nphase, @phasedescription
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SELECT @competency_tot = 0
		SELECT @arrears_tot = 0
		SELECT @competency_totvar = 0
		SELECT @arrears_totvar = 0
		SELECT @competency_tot = ISNULL(total, 0)
			FROM #competency_income
			WHERE nphase = @nphase
		SELECT @competency_totvar = ISNULL(total, 0)
			FROM #competency_incomevar
			WHERE nphase = @nphase
		SELECT @arrears_tot = ISNULL(total, 0)
			FROM #arrear_income
			WHERE nphase = @nphase
		SELECT @arrears_totvar = ISNULL(total, 0)
			FROM #arrear_incomevar
			WHERE nphase = @nphase
		INSERT INTO #situation VALUES(@phasedescription + ' ',
			ISNULL(@competency_tot, 0) +
			ISNULL(@arrears_tot, 0), '')
		INSERT INTO #situation VALUES('Variazioni ' + @phasedescription + ' ',
			ISNULL(@competency_totvar, 0) +
			ISNULL(@arrears_totvar, 0), '')
		INSERT INTO #situation VALUES('Totale ' + @phasedescription + ' ', 
			ISNULL(@competency_tot, 0) +
			ISNULL(@competency_totvar, 0) +
			ISNULL(@arrears_tot, 0) +
			ISNULL(@arrears_totvar, 0), 'S')

		INSERT INTO #situation VALUES('Previsione Disponibile per ' + '"' + @phasedescription + '"',--'Previsione disponibile', 
			ISNULL(@totalincomeprevision, 0) +
			ISNULL(@totalincomeprevisionvar, 0) - 
			ISNULL(@competency_tot, 0) -
			ISNULL(@competency_totvar, 0) -
			ISNULL(@arrears_tot, 0) -
			ISNULL(@arrears_totvar, 0), 'S')
		FETCH NEXT FROM crs_income INTO @nphase, @phasedescription
	END
	DEALLOCATE crs_income
	INSERT INTO #situation VALUES ('Reversali emesse ',
		ISNULL(@totproceeds_c,0) +
		ISNULL(@totproceeds_r, 0), 'S')
		
	INSERT INTO #situation VALUES('',NULL,'H')
	INSERT INTO #situation VALUES('S P E S A ',NULL,'N')
-- Movimenti Spesa
	INSERT INTO #situation VALUES ('Previsione Iniziale', @totalexpenseprevision, '')
	INSERT INTO #situation VALUES ('Variazioni', @totalexpenseprevisionvar, '')
	INSERT INTO #situation VALUES ('Previsione Attuale',
		ISNULL(@totalexpenseprevision, 0) +
		ISNULL(@totalexpenseprevisionvar, 0), 'S')
	
	DECLARE crs_expense INSENSITIVE CURSOR FOR
		SELECT nphase, description FROM expensephase
		WHERE nphase >= @finexpensephase
		FOR READ ONLY
	OPEN crs_expense
	FETCH NEXT FROM crs_expense INTO @nphase, @phasedescription
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SELECT @competency_tot = 0
		SELECT @arrears_tot = 0
		SELECT @competency_totvar = 0
		SELECT @arrears_totvar = 0
		SELECT @competency_tot = ISNULL(total, 0)
			FROM #competency_expense
			WHERE nphase = @nphase
		SELECT @competency_totvar = ISNULL(total, 0)
			FROM #competency_expensevar
			WHERE nphase = @nphase
		SELECT @arrears_tot = ISNULL(total, 0)
			FROM #arrear_expense
			WHERE nphase = @nphase
		SELECT @arrears_totvar = ISNULL(total, 0)
			FROM #arrear_expensevar
			WHERE nphase = @nphase
		INSERT INTO #situation VALUES(@phasedescription+' ', 
			ISNULL(@competency_tot, 0) +
			ISNULL(@arrears_tot, 0), '')
		INSERT INTO #situation VALUES('Variazioni ' + @phasedescription + ' ',
			ISNULL(@competency_totvar, 0) +
			ISNULL(@arrears_totvar, 0), '')
		IF @totpettycashop > 0
			BEGIN
				INSERT INTO #situation VALUES(
					'Totale piccole spese attribuite non reintegrate',
					@totpettycashop, '')
			END
		INSERT INTO #situation VALUES('Totale ' + @phasedescription + ' ',
			ISNULL(@competency_tot, 0) +
			ISNULL(@competency_totvar, 0) +
			ISNULL(@arrears_tot, 0) +
			ISNULL(@arrears_totvar, 0) +
			ISNULL(@totpettycashop, 0), 'S')

		INSERT INTO #situation VALUES('Previsione Disponibile per ' + '"' + @phasedescription + '"',--'Previsione disponibile', 
			ISNULL(@totalexpenseprevision, 0) +
			ISNULL(@totalexpenseprevisionvar, 0) - 
			ISNULL(@competency_tot, 0) -
			ISNULL(@competency_totvar, 0) -
			ISNULL(@arrears_tot, 0) -
			ISNULL(@arrears_totvar, 0) -
			ISNULL(@totpettycashop, 0), 'S')

		FETCH NEXT FROM crs_expense INTO @nphase, @phasedescription
	END
	DEALLOCATE crs_expense
	
	INSERT INTO #situation VALUES ('Mandati emessi ',
		ISNULL(@totpayment_c, 0) +
		ISNULL(@totpayment_r, 0) , 'S')
-- Incassi
	IF (@assured <> 'S')
	BEGIN
		IF 	(EXISTS(SELECT * FROM proceedspart 
			WHERE yproceedspart = @ayear
			AND adate <= @date) 
		OR
			EXISTS (SELECT * FROM finvar
			JOIN finvardetail
			ON finvar.yvar = finvardetail.yvar
			AND finvar.nvar = finvardetail.nvar
			WHERE finvar.yvar = @ayear
			AND finvar.flagproceeds = 'S'
			AND finvar.variationkind <> 5
			AND finvar.idfinvarstatus = 5
			AND finvar.adate <= @date))	
		BEGIN
			INSERT INTO #situation  VALUES ('', NULL, 'N')
			INSERT INTO #situation VALUES('I N C A S S I',NULL,'N')
			INSERT INTO #situation VALUES ('Variazioni dotazione cassa', @totalproceedsvar, '')
			INSERT INTO #situation VALUES ('Assegnazioni di cassa', @totalproceedspart, '')
			INSERT INTO #situation VALUES ('Totale',
				ISNULL(@totalproceedsvar, 0) +
				ISNULL(@totalproceedspart, 0), 'S')
			INSERT INTO #situation VALUES('Incassi disponibili', 
				ISNULL(@totalproceedsvar, 0) +
				ISNULL(@totalproceedspart, 0) -
				--Mandati emessi 
				ISNULL(@totpayment_c, 0) -
				ISNULL(@totpayment_r, 0) , '')
				--ISNULL(@competency_tot, 0) -
				--ISNULL(@competency_totvar, 0) -
				--ISNULL(@totpettycashop, 0), '')
			INSERT INTO #situation VALUES ('Previsione da incassare', 
				ISNULL(@totalexpenseprevision, 0) +
				ISNULL(@totalexpenseprevisionvar, 0) - 
				ISNULL(@totalproceedsvar, 0) -
				ISNULL(@totalproceedspart, 0) , 'S')
		END
	END
	SELECT value, amount, kind FROM #situation
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

