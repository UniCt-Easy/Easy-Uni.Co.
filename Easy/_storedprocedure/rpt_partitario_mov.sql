
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


if OBJECTPROPERTY(object_id('rpt_partitario_mov'), 'IsProcedure') = 1
	drop procedure rpt_partitario_mov
go


CREATE                             PROCEDURE [rpt_partitario_mov]
	@ayear 		smallint,
	@tipopartitario char(1),
	@idupb		varchar(36),
	@finpart 	char(1),
	@nlevel 	tinyint, 	
	@filter 	varchar(50),
	@datebegin 	smalldatetime,
	@dateend 	smalldatetime,
	@showupb	char(1)
AS
BEGIN
	DECLARE @finphase varchar(20)
	DECLARE @phasecassa varchar(20)
	DECLARE @level 	varchar(50)
	
	DECLARE @fin varchar(50)
	DECLARE @phasecassadescription	varchar(50)
	DECLARE @flagvaliditadoc char(1)
	CREATE TABLE #rptpartitariomov
	(
		idfin int,
		codeupb varchar(50),
		idupb varchar(36),
		upb varchar(150),
		upbprintingorder varchar(50),
		idmov int,
		idaccertamento int,
		levelname varchar(50),
		codefin	varchar(50),
		finprintingorder varchar(50),
		title varchar(150),
		rowkind smallint,
		operationkind varchar(55),
		data smalldatetime,
		ymov smallint,
		nmov int,
		nvar int,
		description varchar(150),    
		registry varchar(100),
		accertamentoamount float,
		incassoamount float,
		ndoc int
	)
SELECT @level = description 
	FROM finlevel
	WHERE nlevel = @nlevel
	AND ayear = @ayear

DECLARE @levelusable tinyint
SELECT @levelusable = MIN(nlevel)
	FROM finlevel
	WHERE flagusable = 'S'
	AND ayear = @ayear
SELECT @flagvaliditadoc = cashvaliditykind
	FROM finsetup
	WHERE ayear = @ayear

IF @levelusable < @nlevel
	SELECT @levelusable = @nlevel
IF @finpart = 'E'
	BEGIN
		SELECT @finphase = assessmentphasecode
			FROM finsetup
			WHERE ayear = @ayear
		IF @finphase IS NULL
			BEGIN
				SELECT @finphase = nphase
					FROM incomephase
					WHERE flagfinance = 'S'
			END
		SELECT @fin = description
			FROM incomephase
			WHERE nphase = @finphase
		SELECT @phasecassa = MAX(nphase)
			FROM incomephase
		SELECT @phasecassadescription = description
			FROM incomephase
			WHERE nphase = @phasecassa
	END
ELSE
	BEGIN
		SELECT @finphase = appropriationphasecode
			FROM finsetup
			WHERE ayear = @ayear
		IF @finphase IS NULL
			BEGIN
				SELECT @finphase = nphase
					FROM expensephase
					WHERE flagfinance = 'S'
			END
		SELECT @fin = description
			FROM expensephase
			WHERE nphase = @finphase
		SELECT @phasecassa = MAX(nphase)
			FROM expensephase
		SELECT @phasecassadescription = description
			FROM expensephase
			WHERE nphase = @phasecassa
	END

IF @filter = ' '
	SELECT @filter = (NULL)

IF @finpart = 'E'
BEGIN
	INSERT INTO #rptpartitariomov
		(
		idfin,
		codeupb,
		idupb,
		upb,upbprintingorder,
		idmov,
		idaccertamento,
		levelname,
		codefin,
		finprintingorder,
		title,
		rowkind,
		operationkind,
		data,
		ymov,
		nmov,
		description,
		registry,
		accertamentoamount
		)
	SELECT 
		fin.idfin,
		upb.codeupb,
		upb.idupb,
		upb.title,upb.printingorder,
		income.idinc,
		income.idinc,
		@level,
		fin.codefin,
		fin.printingorder,
		fin.title,
		1,
	   	CASE
			when (( incometotal.flag & 1)=0) then @fin
			when (( incometotal.flag & 1)=1) then 'Residuo '+@fin
		End,


	   	CASE
			when (( incometotal.flag & 1)=0) then income.adate
			when (( incometotal.flag & 1)=1) 
			then CONVERT(smalldatetime, '01/01/' + CONVERT(varchar(4), @ayear), 101)
		End,
		income.ymov,
		income.nmov,
		income.description,
		registry.title,
		incomeyear.amount
	FROM income
	JOIN incomeyear
		ON incomeyear.idinc = income.idinc
		AND incomeyear.ayear = @ayear
	JOIN incometotal
		ON incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear
		
		AND ((@tipopartitario IN ('C', 'R')
			 AND (( incometotal.flag & 1)= @tipopartitario_bit) 
			OR @tipopartitario = 'S')
	JOIN finlink
		ON finlink.idchild = incomeyear.idfin and finlink.nlevel = @nlevel
	JOIN fin 
		ON finlink.idparent = fin.idfin
	JOIN upb 
		ON incomeyear.idupb=upb.idupb
	LEFT OUTER JOIN registry
		ON registry.idreg = income.idreg
	WHERE income.nphase = @finphase
		AND fin.ayear = @ayear
		AND fin.flag = @finpart_bit
		AND fin.nlevel = @nlevel
		AND (@filter IS NULL OR SUBSTRING(fin.codefin, 1,DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
		AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))
		AND ((@tipopartitario = 'C' OR @tipopartitario = 'S' 
			AND (( incometotal.flag & 1)=0) AND income.adate BETWEEN @datebegin AND @dateend)
			OR 
			(@tipopartitario = 'R' OR @tipopartitario = 'S' 
			AND (( incometotal.flag & 1)=1) 
		AND DATEPART(yy, @datebegin) = @ayear
		AND DATEPART(mm, @datebegin) = 1
		AND DATEPART(dd, @datebegin) = 1))

	INSERT INTO #rptpartitariomov
		(
		idfin,codeupb,idupb,
		upb,upbprintingorder,
		idmov,
		idaccertamento,
		levelname,
		codefin,
		finprintingorder,
		title,
		rowkind,
		operationkind,
		data,
		ymov,
		nmov,
		nvar,
		description,
		registry,
		accertamentoamount
		)
	SELECT 
		fin.idfin,
		upb.codeupb,
		upb.idupb,
		upb.title,upb.printingorder,
		income.idinc,
		income.idinc,
		@level,
		fin.codefin,
		fin.printingorder,
		fin.title,
		2,
		CASE
			WHEN incomeyear.flagarrear = 'C' 
			THEN 'Var.' + @fin
			WHEN incomeyear.flagarrear = 'R' 
			THEN 'Var.residuo '+ @fin
		END,
		incomevar.adate,
		income.ymov,
		income.nmov,
		incomevar.nvar,
		incomevar.description,
		registry.title,
		incomevar.amount
		FROM incomevar
		JOIN income
		ON income.idinc = incomevar.idinc
		AND income.nphase = @finphase
		JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
		AND incomeyear.ayear = @ayear
		AND ((@tipopartitario IN ('C', 'R') 
		AND incomeyear.flagarrear = @tipopartitario) 
		OR @tipopartitario = 'S')
		JOIN fin
		ON fin.idfin = SUBSTRING(incomeyear.idfin, 1, 
		(CONVERT(smallint, @nlevel)*4)+3)
		AND fin.ayear = @ayear
		AND fin.finpart = @finpart
		AND fin.nlevel = @nlevel
		AND (@filter IS NULL
		OR SUBSTRING(fin.codefin, 1,
		DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
		LEFT OUTER JOIN registry
		ON registry.idreg = income.idreg
		JOIN upb 
		ON incomeyear.idupb=upb.idupb
		WHERE incomevar.yvar = @ayear
		AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))
		AND incomevar.adate <= @dateend
	        AND DATALENGTH(incomevar.idinc) = CONVERT(smallint, @finphase) * 8
		AND EXISTS(SELECT * FROM #rptpartitariomov 
		WHERE idaccertamento	= incomevar.idinc)

IF @flagvaliditadoc = 'E'
		BEGIN
			INSERT INTO #rptpartitariomov
				(
				idfin,codeupb,idupb,
				upb,upbprintingorder,
				idmov,
				idaccertamento,
				levelname,
				codefin,
				finprintingorder,
				title, 							rowkind,
				operationkind,
				registry,
				data,
				ymov,
				nmov,
				description,
				incassoamount,
				ndoc
				)
				SELECT
				fin.idfin,upb.codeupb,upb.idupb,
				upb.title,upb.printingorder,
				proceedsemitted.idinc,
				SUBSTRING(proceedsemitted.idinc, 1, CONVERT(smallint, @finphase)*8),
				@level,
				fin.codefin,
				fin.printingorder,
				fin.title,
				3,
				@phasecassadescription,
				registry.title,
				proceedsemitted.competencydate,
				proceedsemitted.ymov,
				proceedsemitted.nmov,
				proceedsemitted.description,
				incomeyear.amount,
				proceedsemitted.npro
				FROM proceedsemitted
				JOIN incomeyear
				ON incomeyear.idinc = proceedsemitted.idinc
				AND incomeyear.ayear = @ayear
				AND incomeyear.nphase = @phasecassa
				AND ((@tipopartitario IN ('C', 'R') 
				AND incomeyear.flagarrear = @tipopartitario) 
				OR @tipopartitario = 'S')
				JOIN fin
				ON fin.idfin = SUBSTRING(incomeyear.idfin, 1, 
				(CONVERT(smallint, @nlevel)*4)+3)
				AND fin.ayear = @ayear
				AND fin.finpart = @finpart
				AND fin.nlevel = @nlevel
				AND (@filter IS NULL
				OR SUBSTRING(fin.codefin, 1,
				DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
				LEFT OUTER JOIN registry
				ON registry.idreg = proceedsemitted.idreg
				JOIN upb ON incomeyear.idupb = upb.idupb
				WHERE proceedsemitted.competencydate <= @dateend
				AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))
				AND EXISTS(SELECT * FROM #rptpartitariomov 
				WHERE idaccertamento	= SUBSTRING(proceedsemitted.idinc, 1, CONVERT(smallint, @finphase)*8))
		END
	ELSE IF @flagvaliditadoc = 'S'
		BEGIN
			INSERT INTO #rptpartitariomov
				(
				idfin,codeupb,idupb,
				upb,upbprintingorder,
				idmov,
				idaccertamento,
				levelname,
				codefin,
				finprintingorder,
				title,
				rowkind,
				operationkind,
				registry,
				data,
				ymov,
				nmov,
				description,
				incassoamount,
				ndoc
				)
				SELECT
				fin.idfin,upb.codeupb,upb.idupb,
				upb.title,upb.printingorder,
				proceedsprinted.idinc,
				SUBSTRING(proceedsprinted.idinc, 1, CONVERT(smallint, @finphase)*8),
				@level,
				fin.codefin,
				fin.printingorder,
				fin.title,
				3,
				@phasecassadescription,
				registry.title,
				proceedsprinted.competencydate,
				proceedsprinted.ymov,
				proceedsprinted.nmov,
				proceedsprinted.description,
				incomeyear.amount,
				proceedsprinted.npro
				FROM proceedsprinted
				JOIN incomeyear
				ON incomeyear.idinc = proceedsprinted.idinc
				AND incomeyear.ayear = @ayear
				AND incomeyear.nphase = @phasecassa
				AND ((@tipopartitario IN ('C', 'R') 
				AND incomeyear.flagarrear = @tipopartitario) 
				OR @tipopartitario = 'S')
				JOIN fin
				ON fin.idfin = SUBSTRING(incomeyear.idfin, 1, 
				(CONVERT(smallint, @nlevel)*4)+3)
				AND fin.ayear = @ayear
				AND fin.finpart = @finpart
				AND fin.nlevel = @nlevel
				AND (@filter IS NULL
				OR SUBSTRING(fin.codefin, 1,
				DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
				LEFT OUTER JOIN registry
				ON registry.idreg = proceedsprinted.idreg
				JOIN upb ON incomeyear.idupb=upb.idupb
				WHERE proceedsprinted.competencydate <= @dateend
				AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))
				AND EXISTS(SELECT * FROM #rptpartitariomov 
				WHERE idaccertamento = SUBSTRING(proceedsprinted.idinc, 1, CONVERT(smallint, @finphase)*8))
		END
	ELSE
		BEGIN
			INSERT INTO #rptpartitariomov
				(
				idfin,codeupb,idupb,
				upb,upbprintingorder,
				idmov,
				idaccertamento,
				levelname,
				codefin,
				finprintingorder,
				title,
				rowkind,
				operationkind,
				registry,
				data,
				ymov,
				nmov,
				description,
				incassoamount,
				ndoc
				)
				SELECT
				fin.idfin,upb.codeupb,upb.idupb,
				upb.title,upb.printingorder,
				proceedscommunicated.idinc,
				SUBSTRING(proceedscommunicated.idinc, 1, CONVERT(smallint, @finphase)*8),
				@level,
				fin.codefin,
				fin.printingorder,
				fin.title,
				3,
				@phasecassadescription,
				registry.title,
				proceedscommunicated.competencydate,
				proceedscommunicated.ymov,
				proceedscommunicated.nmov,
				proceedscommunicated.description,
				incomeyear.amount,
				proceedscommunicated.npro
				FROM proceedscommunicated
				JOIN incomeyear
				ON incomeyear.idinc = proceedscommunicated.idinc
				AND incomeyear.ayear = @ayear
				AND incomeyear.nphase = @phasecassa
				AND ((@tipopartitario IN ('C', 'R') 
				AND incomeyear.flagarrear = @tipopartitario) 
				OR @tipopartitario = 'S')
				JOIN fin
				ON fin.idfin = SUBSTRING(incomeyear.idfin, 1, 
				(CONVERT(smallint, @nlevel)*4)+3)
				AND fin.ayear = @ayear
				AND fin.finpart = @finpart
				AND fin.nlevel = @nlevel
				AND (@filter IS NULL
				OR SUBSTRING(fin.codefin, 1,
				DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
				LEFT OUTER JOIN registry
				ON registry.idreg = proceedscommunicated.idreg
				JOIN upb ON incomeyear.idupb=upb.idupb
				WHERE proceedscommunicated.competencydate <= @dateend
				AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))
				AND EXISTS(SELECT * FROM #rptpartitariomov 
				WHERE idaccertamento	= SUBSTRING(proceedscommunicated.idinc, 1, CONVERT(smallint, @finphase)*8))
		END
	INSERT INTO #rptpartitariomov
		(
		idfin,codeupb,idupb,
		upb,upbprintingorder,
		idmov,
		idaccertamento,
		levelname,
		codefin,
		finprintingorder,
		title,
		rowkind,
		operationkind,
		registry,
		data,
		ymov,
		nmov,
		nvar,
		description,
		incassoamount,
		ndoc
		)
		SELECT 
		fin.idfin,upb.codeupb,upb.idupb,
		upb.title,upb.printingorder,
		income.idinc,
		SUBSTRING(income.idinc, 1, CONVERT(smallint, @finphase)*8),
		@level,
		fin.codefin,
		fin.printingorder,
		fin.title,
		4,
		'Var.' + @phasecassadescription,
		registry.title,
		incomevar.adate,
		income.ymov,
		income.nmov,
		incomevar.nvar,
		incomevar.description,
		incomevar.amount,
		income.npro
		FROM incomevar
		JOIN income
		ON income.idinc = incomevar.idinc
		AND income.nphase = @phasecassa
		JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
		AND incomeyear.ayear = @ayear
		AND incomeyear.nphase = @phasecassa
		AND ((@tipopartitario IN ('C', 'R') 
		AND incomeyear.flagarrear = @tipopartitario) 
		OR @tipopartitario = 'S')
		JOIN fin
		ON fin.idfin = SUBSTRING(incomeyear.idfin, 1, 
		(CONVERT(smallint, @nlevel)*4)+3)
		AND fin.ayear = @ayear
		AND fin.finpart = @finpart
		AND fin.nlevel = @nlevel
		AND (@filter IS NULL
		OR SUBSTRING(fin.codefin, 1,
		DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
		LEFT OUTER JOIN registry
		ON registry.idreg = income.idreg
		JOIN upb ON incomeyear.idupb=upb.idupb
		WHERE incomevar.yvar = @ayear
		AND incomevar.adate <= @dateend
		AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))
	        AND DATALENGTH(incomevar.idinc) = CONVERT(smallint, @phasecassa) * 8
		AND EXISTS(SELECT * FROM #rptpartitariomov 
		WHERE idaccertamento	= SUBSTRING(incomevar.idinc, 1, CONVERT(smallint, @finphase)*8))
END
ELSE
BEGIN
	INSERT INTO #rptpartitariomov
		(
		idfin,codeupb,idupb,
		upb,upbprintingorder,
		idmov,
		idaccertamento,
		levelname,
		codefin,
		finprintingorder,
		title,
		rowkind,
		operationkind,
		data,
		ymov,
		nmov,
		description,
		registry,
		accertamentoamount
		)
		SELECT 
		fin.idfin,upb.codeupb,upb.idupb,
		upb.title,upb.printingorder,
		expense.idexp,
		expense.idexp,
		@level,
		fin.codefin,
		fin.printingorder,
		fin.title,
		1,
		CASE
			WHEN expenseyear.flagarrear = 'C' 
			THEN @fin
			WHEN expenseyear.flagarrear = 'R' 
			THEN 'Residuo ' + @fin
		END,
		CASE
			WHEN expenseyear.flagarrear = 'C'
			THEN expense.adate
			WHEN expenseyear.flagarrear = 'R' 
			THEN CONVERT(smalldatetime, '01/01/' + CONVERT(varchar(4), @ayear), 101)
		END,
		expense.ymov,
		expense.nmov,
		expense.description,
		registry.title,
		expenseyear.amount
		FROM expense
		JOIN expenseyear
		ON expenseyear.idexp = expense.idexp
		AND expenseyear.ayear = @ayear
		AND ((@tipopartitario IN ('C', 'R') 
		AND expenseyear.flagarrear = @tipopartitario) 
		OR @tipopartitario = 'S')
		JOIN fin
		ON fin.idfin = SUBSTRING(expenseyear.idfin, 1, 
		(CONVERT(smallint, @nlevel)*4)+3)
		AND fin.ayear = @ayear
		AND fin.finpart = @finpart
		AND fin.nlevel = @nlevel
		AND (@filter IS NULL
		OR SUBSTRING(fin.codefin, 1,
		DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
		LEFT OUTER JOIN registry
		ON registry.idreg = expense.idreg
		JOIN upb on expenseyear.idupb=upb.idupb
		WHERE expense.nphase = @finphase
		AND ((@tipopartitario IN ('C', 'S')
		AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))
		AND expense.adate BETWEEN @datebegin AND @dateend)
		OR (@tipopartitario IN ('R', 'S')
		AND expenseyear.flagarrear = 'R'
		AND DATEPART(yy, @datebegin) = @ayear
		AND DATEPART(mm, @datebegin) = 1
		AND DATEPART(dd, @datebegin) = 1))
	INSERT INTO #rptpartitariomov
		(
		idfin,codeupb,idupb,
		upb,upbprintingorder,
		idmov,
		idaccertamento,
		levelname,
		codefin,
		finprintingorder,
		title,
		rowkind,
		operationkind,
		data,
		ymov,
		nmov,
		nvar,
		description,
		registry,
		accertamentoamount
		)
		SELECT 
		fin.idfin,upb.codeupb,upb.idupb,
		upb.title,upb.printingorder,
		expense.idexp,
		expense.idexp,
		@level,
		fin.codefin,
		fin.printingorder,
		fin.title,
		2,
		CASE
			WHEN expenseyear.flagarrear = 'C' 
			THEN 'Var.' + @fin
			WHEN expenseyear.flagarrear = 'R' 
			THEN 'Var.residuo '  + @fin
		END,
		expensevar.adate,
		expense.ymov,
		expense.nmov,
		expensevar.nvar,
		expensevar.description,
		registry.title,
		expensevar.amount
		FROM expensevar
		JOIN expense
		ON expense.idexp = expensevar.idexp
		AND expense.nphase = @finphase
		JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = @ayear
		AND ((@tipopartitario IN ('C', 'R') 
		AND expenseyear.flagarrear = @tipopartitario) 
		OR @tipopartitario = 'S')
		JOIN fin
		ON fin.idfin = SUBSTRING(expenseyear.idfin, 1, 
		(CONVERT(smallint, @nlevel)*4)+3)
		AND fin.ayear = @ayear
		AND fin.finpart = @finpart
		AND fin.nlevel = @nlevel
		AND (@filter IS NULL
		OR SUBSTRING(fin.codefin, 1,
		DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
		LEFT OUTER JOIN registry
		ON registry.idreg = expense.idreg
		JOIN upb ON upb.idupb=expenseyear.idupb
		WHERE expensevar.yvar = @ayear
		AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))
		AND expensevar.adate <= @dateend
		        AND DATALENGTH(expensevar.idexp) = CONVERT(smallint, @finphase) * 8
		AND EXISTS(SELECT * FROM #rptpartitariomov 
		WHERE idaccertamento	= expensevar.idexp)
	IF @flagvaliditadoc = 'E'
		BEGIN
			INSERT INTO #rptpartitariomov
				(
				idfin,codeupb,idupb,
				upb,upbprintingorder,
				idmov,
				idaccertamento,
				levelname,
				codefin,
				finprintingorder,
				title,
				rowkind,
				operationkind,
				registry,
				data,
				ymov,
				nmov,
				description,
				incassoamount,
				ndoc
				)
				SELECT
				fin.idfin,upb.codeupb,upb.idupb,
				upb.title,upb.printingorder,
				paymentemitted.idexp,
				SUBSTRING(paymentemitted.idexp, 1, CONVERT(smallint, @finphase)*8),
				@level,
				fin.codefin,
				fin.printingorder,
				fin.title,
				3,
				@phasecassadescription,
				registry.title,
				paymentemitted.competencydate,
				paymentemitted.ymov,
				paymentemitted.nmov,
				paymentemitted.description,
				expenseyear.amount,
				paymentemitted.npay
				FROM paymentemitted
				JOIN expenseyear
				ON expenseyear.idexp = paymentemitted.idexp
				AND expenseyear.ayear = @ayear
				AND expenseyear.nphase = @phasecassa
				AND ((@tipopartitario IN ('C', 'R') 
				AND expenseyear.flagarrear = @tipopartitario) 
				OR @tipopartitario = 'S')
				JOIN fin
				ON fin.idfin = SUBSTRING(expenseyear.idfin, 1, 
				(CONVERT(smallint, @nlevel)*4)+3)
				AND fin.ayear = @ayear
				AND fin.finpart = @finpart
				AND fin.nlevel = @nlevel
				AND (@filter IS NULL
				OR SUBSTRING(fin.codefin, 1,
				DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
				LEFT OUTER JOIN registry
				ON registry.idreg = paymentemitted.idreg
				JOIN upb ON upb.idupb = expenseyear.idupb
				WHERE paymentemitted.competencydate <= @dateend
				AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))
				AND EXISTS(SELECT * FROM #rptpartitariomov 
				WHERE idaccertamento	= SUBSTRING(paymentemitted.idexp, 1, CONVERT(smallint, @finphase)*8))
		END
	ELSE IF @flagvaliditadoc = 'S'
		BEGIN
			INSERT INTO #rptpartitariomov
				(
				idfin,codeupb,idupb,
				upb,upbprintingorder,
				idmov,
				idaccertamento,
				levelname,
				codefin,
				finprintingorder,
				title,
				rowkind,
				operationkind,
				registry,
				data,
				ymov,
				nmov,
				description,
				incassoamount,
				ndoc
				)
				SELECT
				fin.idfin,upb.codeupb,upb.idupb,
				upb.title,upb.printingorder,
				paymentprinted.idexp,
				SUBSTRING(paymentprinted.idexp, 1, CONVERT(smallint, @finphase)*8),
				@level,
				fin.codefin,
				fin.printingorder,
				fin.title,
				3,
				@phasecassadescription,
				registry.title,
				paymentprinted.competencydate,
				paymentprinted.ymov,
				paymentprinted.nmov,
				paymentprinted.description,
				expenseyear.amount,
				paymentprinted.npay
				FROM paymentprinted
				JOIN expenseyear
				ON expenseyear.idexp = paymentprinted.idexp
				AND expenseyear.ayear = @ayear
				AND expenseyear.nphase = @phasecassa
				AND ((@tipopartitario IN ('C', 'R') 
				AND expenseyear.flagarrear = @tipopartitario) 
				OR @tipopartitario = 'S')
				JOIN fin
				ON fin.idfin = SUBSTRING(expenseyear.idfin, 1, 
				(CONVERT(smallint, @nlevel)*4)+3)
				AND fin.ayear = @ayear
				AND fin.finpart = @finpart
				AND fin.nlevel = @nlevel
				AND (@filter IS NULL
				OR SUBSTRING(fin.codefin, 1,
				DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
				LEFT OUTER JOIN registry
				ON registry.idreg = paymentprinted.idreg
				JOIN upb ON expenseyear.idupb = upb.idupb
				WHERE paymentprinted.competencydate <= @dateend
				AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))	
				AND EXISTS(SELECT * FROM #rptpartitariomov 
				WHERE idaccertamento	= SUBSTRING(paymentprinted.idexp, 1, CONVERT(smallint, @finphase)*8))
		END
	ELSE
		BEGIN
			INSERT INTO #rptpartitariomov
				(
				idfin,codeupb,idupb,
				upb,upbprintingorder,
				idmov,
				idaccertamento,
				levelname,
				codefin,
				finprintingorder,
				title,
				rowkind,
				operationkind,
				registry,
				data,
				ymov,
				nmov,
				description,
				incassoamount,
				ndoc
				)
				SELECT
				fin.idfin,upb.codeupb,upb.idupb,
				upb.title,upb.printingorder,
				paymentcommunicated.idexp,
				SUBSTRING(paymentcommunicated.idexp, 1, CONVERT(smallint, @finphase)*8),
				@level,
				fin.codefin,
				fin.printingorder,
				fin.title,
				3,
				@phasecassadescription,
				registry.title,
				paymentcommunicated.competencydate,
				paymentcommunicated.ymov,
				paymentcommunicated.nmov,
				paymentcommunicated.description,
				expenseyear.amount,
				paymentcommunicated.npay
				FROM paymentcommunicated
				JOIN expenseyear
				ON expenseyear.idexp = paymentcommunicated.idexp
				AND expenseyear.ayear = @ayear
				AND expenseyear.nphase = @phasecassa
				AND ((@tipopartitario IN ('C', 'R') 
				AND expenseyear.flagarrear = @tipopartitario) 
				OR @tipopartitario = 'S')
				JOIN fin
				ON fin.idfin = SUBSTRING(expenseyear.idfin, 1, 
				(CONVERT(smallint, @nlevel)*4)+3)
				AND fin.ayear = @ayear
				AND fin.finpart = @finpart
				AND fin.nlevel = @nlevel
				AND (@filter IS NULL
				OR SUBSTRING(fin.codefin, 1,
				DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
				LEFT OUTER JOIN registry
				ON registry.idreg = paymentcommunicated.idreg
				JOIN upb ON upb.idupb = expenseyear.idupb
				WHERE paymentcommunicated.competencydate <= @dateend
				AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))
				AND EXISTS(SELECT * FROM #rptpartitariomov 
				WHERE idaccertamento	= SUBSTRING(paymentcommunicated.idexp, 1, CONVERT(smallint, @finphase)*8))
		END
	INSERT INTO #rptpartitariomov
		(
		idfin,codeupb,idupb,
		upb,upbprintingorder,
		idmov,
		idaccertamento,
		levelname,
		codefin,
		finprintingorder,
		title,
		rowkind,
		operationkind,
		registry,
		data,
		ymov,
		nmov,
		nvar,
		description,
		incassoamount,
		ndoc
		)
		SELECT 
		fin.idfin,upb.codeupb,upb.idupb,
		upb.title,upb.printingorder,
		expense.idexp,
		SUBSTRING(expense.idexp, 1, CONVERT(smallint, @finphase)*8),
		@level,
		fin.codefin,
		fin.printingorder,
		fin.title,
		4,
		'Var.' + @phasecassadescription,
		registry.title,
		expensevar.adate,
		expense.ymov,
		expense.nmov,
		expensevar.nvar,
		expensevar.description,
		expensevar.amount,
		expense.npay
		FROM expensevar
		JOIN expense
		ON expense.idexp = expensevar.idexp
		AND expense.nphase = @phasecassa
		JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = @ayear
		AND expenseyear.nphase = @phasecassa
		AND ((@tipopartitario IN ('C', 'R') 
		AND expenseyear.flagarrear = @tipopartitario) 
		OR @tipopartitario = 'S')
		JOIN fin
		ON fin.idfin = SUBSTRING(expenseyear.idfin, 1, 
		(CONVERT(smallint, @nlevel)*4)+3)
		AND fin.ayear = @ayear
		AND fin.finpart = @finpart
		AND fin.nlevel = @nlevel
		AND (@filter IS NULL
		OR SUBSTRING(fin.codefin, 1,
		DATALENGTH(RTRIM(@filter))) = RTRIM(@filter))
		LEFT OUTER JOIN registry
		ON registry.idreg = expense.idreg
		JOIN upb on expenseyear.idupb = upb.idupb
		WHERE expensevar.yvar = @ayear
		AND expensevar.adate <= @dateend
		AND (upb.idupb like @idupb OR (upb.idupb IS NULL AND @idupb = '%'))
	        AND DATALENGTH(expensevar.idexp) = CONVERT(smallint, @phasecassa) * 8
		AND EXISTS(SELECT * FROM #rptpartitariomov 
		WHERE idaccertamento	= SUBSTRING(expensevar.idexp, 1, CONVERT(smallint, @finphase)*8))
END

UPDATE #rptpartitariomov
	SET idaccertamento = '20' + idaccertamento
	WHERE CONVERT(smallint, SUBSTRING(idaccertamento,1, 2)) <= 50
UPDATE #rptpartitariomov
	SET idaccertamento = '19' + idaccertamento
	WHERE CONVERT(smallint, SUBSTRING(idaccertamento,1, 2)) > 50


IF (@showupb <>'S') UPDATE #rptpartitariomov SET  upbprintingorder = null		

SELECT * 
	FROM #rptpartitariomov
	ORDER BY idupb ASC,idfin ASC,
	idaccertamento ASC,
-- Riga seguente aggiunta da Rusciano G.
	idmov ASC,
	data ASC,
	ymov ASC,
	nmov ASC,
	nvar ASC
  END


