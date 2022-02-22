
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_finyear_compcash_UNIBA]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_finyear_compcash_UNIBA]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE     PROCEDURE [show_finyear_compcash_UNIBA]
	@date datetime,
	@idupb varchar(36),
	@idfin int ,
	@finpart char(1)
AS
BEGIN
DECLARE	@ayear int 
SELECT @ayear = YEAR(@date)
		
/* Versione 1.0.1 del 27/11/2007 ultima modifica: MARIA */

DECLARE	@departmentname varchar(150) -- Nome del Dipartimento
SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')

DECLARE	@residualphase int
SELECT @residualphase = 1

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (E = Entrata S = Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

DECLARE	@levelusable tinyint --varchar(20) -- Livello operativo per le voci di bilancio
SELECT @levelusable = MIN(nlevel) FROM finlevel
WHERE (flag & 2)<>0 and ayear = @ayear

DECLARE @assessmentphase tinyint  --char(1) -- Fase paragonabile all'accertamento o all'impegno
DECLARE	@finphase tinyint  --char(1) -- Fase in cui viene inserita la voce di bilancio
DECLARE	@maxphase tinyint  --char(1) -- Fase di cassa

IF @finpart = 'E'
BEGIN
	SELECT @assessmentphase = assessmentphasecode FROM config
		WHERE ayear = @ayear
	SELECT @residualphase = incomefinphase from uniconfig
	SELECT @finphase = incomefinphase from uniconfig
	SELECT @maxphase = MAX(nphase) FROM incomephase
END
ELSE
BEGIN
	SELECT @assessmentphase = appropriationphasecode FROM config
		WHERE ayear = @ayear
	SELECT @residualphase = expensefinphase from uniconfig
	SELECT @finphase = expensefinphase from uniconfig
	SELECT @maxphase = MAX(nphase) FROM expensephase
	
END

DECLARE	@fincode varchar(50) -- Codice di bilancio
DECLARE	@nlevel tinyint--varchar(20) -- Livello della voce di bilancio		
DECLARE	@fin varchar(150) -- Descrizione della voce di bilancio
SELECT @nlevel = nlevel, @fincode = codefin, @fin = title  FROM fin  WHERE idfin = @idfin

DECLARE	@finlevel varchar(50)
SELECT @finlevel = description FROM finlevel WHERE ayear = @ayear AND @nlevel = nlevel

DECLARE @descupb varchar(150)
DECLARE @codeupb varchar(50)
SELECT @descupb = title,
	@codeupb = codeupb
FROM upb
WHERE idupb = @idupb
DECLARE	@prevision decimal(19,2) -- Previsione Principale
DECLARE	@secondaryprev decimal(19,2) -- Previsione Secondaria
IF @nlevel < @levelusable OR @nlevel IS NULL
BEGIN
	SELECT @prevision = SUM(ISNULL(prevision,0)),
	@secondaryprev = SUM(ISNULL(secondaryprev,0)) 
	FROM finyearview
	JOIN finlink
		ON finlink.idchild = finyearview.idfin
	join fin
		ON finyearview.idfin = fin.idfin
	WHERE finyearview.nlevel  = @levelusable
	AND idupb = @idupb
	and fin.ayear = @ayear
	AND (
		(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
		OR 
		( @nlevel is null AND finlink.nlevel = @levelusable)
	    )
	and ((fin.flag & 1 ) = @finpart_bit)
/*	WHERE SUBSTRING(idfin, 1, @lengthidfin) = @idfin
	AND nlevel = @levelusable
	AND idupb = @idupb*/
END
ELSE
BEGIN
	SELECT @prevision = prevision, 
		@secondaryprev = secondaryprev
	FROM finyear
	WHERE idfin = @idfin AND idupb = @idupb
END
DECLARE	@var_prevision_A decimal(19,2) -- Totale delle variazioni di previsione principale in aumento
SELECT @var_prevision_A = SUM(finvardetail.amount)
FROM finvardetail
JOIN finvar
	ON finvar.yvar = finvardetail.yvar
	AND finvar.nvar = finvardetail.nvar
JOIN finlink 
	ON finlink.idchild = finvardetail.idfin
join fin 
	ON finvardetail.idfin = fin.idfin
WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )--SUBSTRING(finvardetail.idfin, 1, @lengthidfin) = @idfin
	and ((fin.flag & 1 ) = @finpart_bit) and fin.ayear = @ayear
	AND finvar.adate <=	@date
	AND finvar.flagprevision = 'S'
	AND finvar.variationkind <> 5 
	AND finvar.idfinvarstatus = 5
	AND idupb = @idupb
	AND amount > 0

DECLARE	@var_prevision_R decimal(19,2) -- Totale delle variazioni di previsione principale in diminuzione
SELECT @var_prevision_R = SUM(finvardetail.amount)
FROM finvardetail
JOIN finvar
	ON finvar.yvar = finvardetail.yvar
	AND finvar.nvar = finvardetail.nvar
JOIN finlink 
	ON finlink.idchild = finvardetail.idfin
join fin 
	ON finvardetail.idfin = fin.idfin
WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )--SUBSTRING(finvardetail.idfin, 1, @lengthidfin) = @idfin
	and ((fin.flag & 1 ) = @finpart_bit) and fin.ayear = @ayear
	AND finvar.adate <=	@date
	AND finvar.flagprevision = 'S'
	AND finvar.variationkind <> 5 
	AND finvar.idfinvarstatus = 5
	AND idupb = @idupb
	AND amount < 0
-- Calcolo delle variazioni totali sulla previsione principale date dalla somma algebrica di quelle in aumento e quelle in diminuzione
DECLARE @var_prevision decimal(19,2) -- Totale delle variazioni di previsione principale
SET @var_prevision = ISNULL(@var_prevision_A,0) + ISNULL(@var_prevision_R,0)
-- Calcolo della previsione principale attuale
DECLARE @current_prevision decimal(19,2) -- Previsione Attuale Principale
SET @current_prevision = ISNULL(@prevision,0) + ISNULL(@var_prevision,0)
		
DECLARE	@var_secondaryprev_A decimal(19,2) -- Totale delle variazioni di previsione secondaria in aumento
SELECT @var_secondaryprev_A = SUM(finvardetail.amount)
FROM finvardetail
JOIN finvar
	ON finvar.yvar = finvardetail.yvar
	AND finvar.nvar = finvardetail.nvar
JOIN finlink 
	ON finlink.idchild = finvardetail.idfin
join fin 
	ON finvardetail.idfin = fin.idfin
WHERE --SUBSTRING(finvardetail.idfin, 1, @lengthidfin) = @idfin
	(	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
	and ((fin.flag & 1 ) = @finpart_bit) and fin.ayear = @ayear
	AND finvar.adate <=	@date
	AND finvar.flagsecondaryprev = 'S'
	AND finvar.variationkind <> 5 
	AND finvar.idfinvarstatus = 5
	AND idupb = @idupb
	AND amount > 0

DECLARE	@var_secondaryprev_R decimal(19,2) -- Totale delle variazioni di previsione secondaria in diminuzione
SELECT @var_secondaryprev_R = SUM(finvardetail.amount)
FROM finvardetail
JOIN finvar
	ON finvar.yvar = finvardetail.yvar
	AND finvar.nvar = finvardetail.nvar
JOIN finlink 
	ON finlink.idchild = finvardetail.idfin
join fin 
	ON finvardetail.idfin = fin.idfin
WHERE --SUBSTRING(finvardetail.idfin, 1, @lengthidfin) = @idfin
	(	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
	and ((fin.flag & 1 ) = @finpart_bit) and fin.ayear = @ayear
	AND finvar.adate <= @date
	AND finvar.flagsecondaryprev = 'S'
	AND finvar.variationkind <> 5 
	AND finvar.idfinvarstatus = 5
	AND idupb = @idupb
	AND amount < 0
-- Calcolo delle variazioni totali sulla previsione secondaria date dalla somma algebrica di quelle in aumento e quelle in diminuzione
DECLARE @var_secondaryprev decimal(19,2) -- Totale delle variazioni di previsione secondaria
SET @var_secondaryprev = ISNULL(@var_secondaryprev_A,0) + ISNULL(@var_secondaryprev_R,0)
-- Calcolo della previsione secondaria attuale
DECLARE @current_secprevision decimal(19,2) -- Previsione Attuale Secondaria
SET @current_secprevision = ISNULL(@secondaryprev,0) + ISNULL(@var_secondaryprev,0)
-- Tabella dei movimenti di competenza
CREATE TABLE #mov_finphase_C
(
	nphase tinyint,
	amount decimal(19,2)
)
-- Tabella delle variazioni sui movimenti di competenza
CREATE TABLE #var_finphase_C_aum
(
	nphase tinyint,
	amount decimal(19,2)
)
CREATE TABLE #var_finphase_C_dim
(
	nphase tinyint,
	amount decimal(19,2)
)
-- Tabella dei movimenti residui
CREATE TABLE #mov_finphase_R
(
	nphase tinyint,
	amount decimal(19,2) 
)
-- Tabella delle variazioni sui movimenti residui
CREATE TABLE #var_finphase_R
(
	nphase tinyint,
	amount decimal(19,2) 
)
IF @finpart = 'E'
BEGIN
	INSERT INTO #mov_finphase_C
	SELECT income.nphase, 
		SUM(incomeyear.amount)
	FROM incomeyear
	JOIN incometotal
		ON incometotal.idinc = incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	JOIN income
		ON income.idinc = incomeyear.idinc
	JOIN finlink 
		ON finlink.idchild = incomeyear.idfin
	WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND incomeyear.ayear = @ayear
		AND ( (incometotal.flag & 1) =0) -- 'C'
		AND incomeyear.idupb = @idupb
		AND income.nphase >= @finphase
		AND income.adate <= @date
	GROUP BY income.nphase

	INSERT INTO #mov_finphase_R
	SELECT income.nphase, 
		SUM(incomeyear.amount)
	FROM incomeyear
	JOIN incometotal
		ON incometotal.idinc =	incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	JOIN income
		ON income.idinc = incomeyear.idinc
	JOIN finlink 
		ON finlink.idchild = incomeyear.idfin
	WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND incomeyear.ayear = @ayear
		AND ( (incometotal.flag & 1) = 1) -- 'R'
		AND incomeyear.idupb = @idupb
		AND income.nphase >= @finphase
		AND income.adate <= @date
	GROUP BY income.nphase

	INSERT INTO #var_finphase_C_aum
	SELECT income.nphase, 
		SUM(incomevar.amount)
	FROM incomevar
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
	JOIN incometotal
		ON incometotal.idinc =	incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	JOIN income
		ON income.idinc = incomeyear.idinc
	JOIN finlink 
		ON finlink.idchild = incomeyear.idfin
	WHERE incomevar.yvar = @ayear
		AND (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND incomevar.adate <= @date
		AND incomeyear.idupb = @idupb
		AND incomeyear.ayear = @ayear
		AND ( (incometotal.flag & 1) =0) -- 'C'
		AND income.nphase >= @finphase
		AND incomevar.amount > 0
	GROUP BY income.nphase

	INSERT INTO #var_finphase_C_dim
	SELECT income.nphase, 
		SUM(incomevar.amount)
	FROM incomevar
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
	JOIN incometotal
		ON incometotal.idinc =	incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	JOIN income
		ON income.idinc = incomeyear.idinc
	JOIN finlink 
		ON finlink.idchild = incomeyear.idfin
	WHERE incomevar.yvar = @ayear
		AND (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND incomevar.adate <= @date
		AND incomeyear.idupb = @idupb
		AND incomeyear.ayear = @ayear
		AND ( (incometotal.flag & 1) =0) -- 'C'
		AND income.nphase >= @finphase
		AND incomevar.amount < 0
	GROUP BY income.nphase

	INSERT INTO #var_finphase_R
	SELECT income.nphase, 
		SUM(incomevar.amount)
	FROM incomevar
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
	JOIN incometotal
		ON incometotal.idinc =	incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	JOIN income
		ON income.idinc = incomeyear.idinc
	JOIN finlink 
		ON finlink.idchild = incomeyear.idfin
	WHERE incomevar.yvar = @ayear
		AND incomevar.adate <= @date
		AND incomeyear.idupb = @idupb
		AND (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND incomeyear.ayear = @ayear
		AND ( (incometotal.flag & 1) = 1) -- 'R'
		AND income.nphase >= @finphase
	GROUP BY income.nphase

	DECLARE @proceeds_C decimal(19,2) -- Totale delle reversali di competenza
	SET @proceeds_C = ISNULL(
		(SELECT SUM(HPV.curramount)
		FROM historyproceedsview HPV
		JOIN incomeyear MY
			ON MY.idinc = HPV.idinc
		JOIN finlink FLK
			ON FLK.idchild = MY.idfin
		WHERE MY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0) -- 'C'
			AND(	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
			AND MY.idupb = @idupb
			AND HPV.competencydate <= @date)
		,0)
	DECLARE @proceeds_R decimal(19,2) -- Totale delle reversali residue
	SET @proceeds_R = ISNULL(
		(SELECT SUM(HPV.curramount)
		FROM historyproceedsview HPV
		JOIN incomeyear MY
			ON MY.idinc = HPV.idinc
		JOIN finlink FLK
			ON FLK.idchild = MY.idfin
		WHERE ayear = @ayear
			AND ( (HPV.totflag & 1) = 1) -- 'R'
			AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
			AND MY.idupb =@idupb
			AND HPV.competencydate <= @date)
		,0)
	DECLARE @proceeds decimal(19,2) -- Totale Reversali (secondo la configurazione di bilancio)
	SET @proceeds = ISNULL(@proceeds_C,0) + ISNULL(@proceeds_R,0)
END
ELSE
-------------------------------------------------
-----	PARTE SPESA
-------------------------------------------------
BEGIN
	-- Controllo se l'UPB ha finanziamento certo
	DECLARE @assured char(1)
	SELECT @assured = assured FROM upb WHERE idupb = @idupb
	
	INSERT INTO #mov_finphase_C
	SELECT expense.nphase, 
		SUM(expenseyear.amount)
	FROM expenseyear
	JOIN expensetotal
		ON expensetotal.idexp =	expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	JOIN finlink 
		ON finlink.idchild = expenseyear.idfin
	WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND expenseyear.ayear = @ayear
		AND expense.adate <= @date
		AND ( (expensetotal.flag & 1) = 0) -- 'C'
		AND expense.nphase >= @finphase
		AND expenseyear.idupb = @idupb
	GROUP BY expense.nphase

	INSERT INTO #mov_finphase_R
	SELECT expense.nphase, 
		SUM(expenseyear.amount)
	FROM expenseyear
	JOIN expensetotal
		ON expensetotal.idexp =	expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	JOIN finlink 
		ON finlink.idchild = expenseyear.idfin
	WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND expenseyear.ayear = @ayear
		AND ( (expensetotal.flag & 1) = 1) -- 'R'
		AND expense.adate <= @date
		AND expense.nphase >= @finphase
		AND expenseyear.idupb = @idupb
	GROUP BY expense.nphase

	INSERT INTO #var_finphase_C_aum
	SELECT expense.nphase, 
		SUM(expensevar.amount)
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
	JOIN expensetotal
		ON expensetotal.idexp =	expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	JOIN finlink 
		ON finlink.idchild = expenseyear.idfin
	WHERE expensevar.yvar =	@ayear
		AND expensevar.adate <= @date
		AND expenseyear.idupb = @idupb
		AND (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND expenseyear.ayear = @ayear
		AND ( (expensetotal.flag & 1) = 0) -- 'C'
		AND expense.nphase >= @finphase
		AND expensevar.amount > 0
	GROUP BY expense.nphase

	INSERT INTO #var_finphase_C_dim
	SELECT expense.nphase, 
		SUM(expensevar.amount)
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
	JOIN expensetotal
		ON expensetotal.idexp =	expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	JOIN finlink 
		ON finlink.idchild = expenseyear.idfin
	WHERE expensevar.yvar =	@ayear
		AND expensevar.adate <= @date
		AND expenseyear.idupb = @idupb
		AND (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND expenseyear.ayear = @ayear
		AND ( (expensetotal.flag & 1) = 0) -- 'C'
		AND expense.nphase >= @finphase
		AND expensevar.amount < 0
	GROUP BY expense.nphase


	INSERT INTO #var_finphase_R
	SELECT expense.nphase, 
		SUM(expensevar.amount)
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	JOIN expensetotal
		ON expensetotal.idexp =	expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	JOIN finlink 
		ON finlink.idchild = expenseyear.idfin
	WHERE expensevar.yvar =	@ayear
		AND expensevar.adate <= @date
		AND (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND expenseyear.ayear = @ayear
		AND ( (expensetotal.flag & 1) = 1) -- 'R'
		AND expense.nphase >= @finphase
		AND expenseyear.idupb = @idupb
	GROUP BY expense.nphase

	DECLARE @payment_C decimal(19,2) -- Totale dei mandati di competenza
	SET @payment_C = ISNULL(
		(SELECT SUM(HPV.curramount)
		FROM historypaymentview HPV 
		JOIN expenseyear MY
			ON MY.idexp = HPV.idexp
		JOIN finlink FLK
			ON FLK.idchild = MY.idfin
		WHERE ayear = @ayear
			AND ( (HPV.totflag & 1) = 0) -- 'C'
			AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )--AND SUBSTRING(MY.idfin,1,@lengthidfin) = @idfin
			AND MY.idupb = @idupb
			AND HPV.competencydate <= @date)
		,0)
	DECLARE @payment_R decimal(19,2) -- Totale dei mandati residui
	SET @payment_R = ISNULL(
		(SELECT SUM(HPV.curramount)
		FROM historypaymentview HPV
		JOIN expenseyear MY
			ON MY.idexp = HPV.idexp
		JOIN finlink FLK
			ON FLK.idchild = MY.idfin
		WHERE ayear = @ayear
			AND ( (HPV.totflag & 1) = 1) -- 'R'
			AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )--AND SUBSTRING(MY.idfin,1,@lengthidfin) = @idfin
			AND MY.idupb = @idupb
			AND HPV.competencydate <= @date)
		,0)
	DECLARE @payment decimal(19,2) -- Totale Mandati (secondo la configurazione di bilancio)
	SET @payment = ISNULL(@payment_C,0) + ISNULL(@payment_R,0)
END

DECLARE	@pettycash decimal(19,2) -- Totale operazioni del fondo economale

SELECT @pettycash = SUM(operation.amount)
FROM pettycashoperation operation
JOIN finlink FLK
	ON FLK.idchild = operation.idfin
JOIN fin 
	ON operation.idfin = fin.idfin
WHERE (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )--SUBSTRING(operation.idfin, 1, @lengthidfin) = @idfin
	AND operation.idupb = @idupb
	AND fin.ayear = @ayear
	AND operation.adate <= @date
	AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
		WHERE restoreop.yoperation = operation.yrestore
		AND restoreop.noperation = operation.nrestore
		AND restoreop.idpettycash = operation.idpettycash
		AND restoreop.adate <= @date)

-- Tabella della situazione della voce di bilancio
CREATE TABLE #situation	(value varchar(200), amount decimal(19,2), kind char(1))

INSERT INTO #situation	
	VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation	
	VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
INSERT INTO #situation
	VALUES (@codeupb + ' - ' + @descupb, NULL, 'H')
INSERT INTO #situation	
	VALUES (@finlevel + ' ' + @fincode, NULL, 'H')
INSERT INTO #situation	
	VALUES (@fin,	NULL, 'H')
INSERT INTO #situation	
	VALUES ('Esercizio ' + CONVERT(char(4),	@ayear), NULL, 'H')
INSERT INTO #situation	
	VALUES ('', NULL, 'N')
INSERT INTO #situation
	VALUES('C O M P E T E N Z A',NULL,'N')
INSERT INTO #situation	
	VALUES ('Previsione iniziale di competenza', @prevision, '')
INSERT INTO #situation	
	VALUES ('Variazioni di bilancio e Storni di previsione', @var_prevision,	'')
INSERT INTO #situation	
	VALUES ('Previsione attuale di competenza', ISNULL(@current_prevision,0), 'S')
DECLARE	@phasecod tinyint
DECLARE	@phasedescr varchar(50)
DECLARE	@mov_C decimal(19,2)
DECLARE	@var_C decimal(19,2)
DECLARE	@var_C_aum decimal(19,2)
DECLARE	@var_C_dim decimal(19,2)
DECLARE	@mov_R decimal(19,2)
DECLARE	@var_R decimal(19,2)
DECLARE @movE_finphase_C decimal(19,2)
DECLARE @movE_finphase_R decimal(19,2)
DECLARE @totalpro_C decimal(19,2)
DECLARE @totalpro_R decimal(19,2)
DECLARE @movS_finphase_C decimal(19,2)
DECLARE @movS_finphase_R decimal(19,2)
DECLARE @totalpay_C decimal(19,2)
DECLARE @totalpay_R decimal(19,2)
------------------------------------------------------------------------------------------------------------------------------------------------
-- 								GESTIONE DI COMPETENZA * ENTRATE
------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE @finphase_descr varchar(50) -- Nome della fase 'Accertamento' - 'Impegno'
DECLARE @maxphase_descr varchar(50) -- Nome della fase 'Riga Reversale' - 'Riga Mandato'
DECLARE @lbl_assessmentavailable varchar(150) -- Etichetta sulla disponibilità ad accertate
DECLARE @lbl_appropriationavailable varchar(150) -- Etichetta sulla disponibilità ad impegnare che varia in base alla presenza delle operazioni del fondo economale
DECLARE @lbl_available_firstphase varchar(150) -- Etichetta sulla disponibilità calcolata sulla prima fase di entrata o di spesa 
IF @finpart = 'E'
BEGIN
	-- Gestione in c/competenza
	DECLARE	fase_cursor INSENSITIVE	CURSOR FOR
	SELECT nphase, description FROM incomephase
	WHERE nphase >= @finphase AND nphase IN (@finphase,@assessmentphase,@maxphase) -- M. Smaldino
	FOR READ ONLY
	OPEN fase_cursor
	FETCH NEXT FROM	fase_cursor INTO @phasecod, @phasedescr
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		IF (@phasecod = @residualphase) SET @finphase_descr = @phasedescr
		ELSE SET @maxphase_descr = @phasedescr
		SELECT @mov_C = 0
		SELECT @var_C_aum = 0
		SELECT @var_C_dim = 0
		SELECT @mov_C = ISNULL(amount, 0)
			FROM #mov_finphase_C
			WHERE nphase = @phasecod
	
		SELECT @var_C_aum = ISNULL(amount, 0)
			FROM #var_finphase_C_aum
			WHERE nphase = @phasecod
		SELECT @var_C_dim = ISNULL(amount, 0)
			FROM #var_finphase_C_dim
			WHERE nphase = @phasecod
	---------------------------------------------------------------------------------------------------------------------------------------------
	-- Se la fase corrispondente all'accertamento o impegno non coincide con la prima fase di entrata o spesa in cui è imputata
	-- la voce di bilancio prendere in considerazione anche la previsione disponibile calcolata su questa fase 
	---------------------------------------------------------------------------------------------------------------------------------------------
		IF (@phasecod = @finphase and @finphase < @assessmentphase )
		BEGIN
			SELECT @lbl_available_firstphase = '   Disponibilità per ulteriore ' + '"' + @phasedescr + '"'
			INSERT INTO #situation VALUES(@lbl_available_firstphase,
				ISNULL(@current_prevision, 0) -
				ISNULL(@mov_C, 0) -
				ISNULL(@var_C_aum, 0) -
				ISNULL(@var_C_dim, 0), 'S')
		END
		ELSE
		BEGIN
			INSERT INTO #situation	VALUES('1) Movimenti competenza ('+ @phasedescr	+ ')', @mov_C, '')
			INSERT INTO #situation	VALUES('2) Variazioni in aumento competenza ('+ @phasedescr	+ ')', @var_C_aum, '')
			INSERT INTO #situation	VALUES('2) Variazioni in diminuzione competenza ('+ @phasedescr	+ ')', @var_C_dim, '')
			INSERT INTO #situation VALUES('3) Totale movimenti competenza ('+ @phasedescr	+ ')',
				ISNULL(@mov_C,0)+
				ISNULL(@var_C_aum,0)+
				ISNULL(@var_C_dim,0),'')
			SELECT @lbl_assessmentavailable = 'Disponibilità per ' + '"' + @phasedescr + '"' +' (Prev. Attuale - 3'
			IF (@phasecod = @residualphase) -- Informazioni inerenti gli accertamenti
			BEGIN
				SELECT @lbl_assessmentavailable = @lbl_assessmentavailable + ')'
				INSERT INTO #situation	VALUES(@lbl_assessmentavailable, 
				ISNULL(@current_prevision, 0) -
				ISNULL(@mov_C, 0) -
				ISNULL(@var_C_aum, 0) -
				ISNULL(@var_C_dim, 0), 'S')
			END
			ELSE IF (@phasecod = @maxphase) -- Informazioni inerenti gli incassi
				BEGIN
					SET @movE_finphase_C = 
					ISNULL((SELECT SUM(amount) FROM #mov_finphase_C WHERE nphase = @residualphase),0) +
					ISNULL((SELECT SUM(amount) FROM #var_finphase_C_aum WHERE nphase = @residualphase),0) +
					ISNULL((SELECT SUM(amount) FROM #var_finphase_C_dim WHERE nphase = @residualphase),0)
					INSERT INTO #situation VALUES('Accertato di competenza da incassare',
					@movE_finphase_C -
					ISNULL(@mov_C,0) - ISNULL(@var_C_aum,0)- ISNULL(@var_C_dim,0),'S')
				END
		END
		FETCH NEXT FROM	fase_cursor INTO @phasecod, @phasedescr
	END
	
	DEALLOCATE fase_cursor
	INSERT INTO #situation	VALUES('Reversali emesse in c/competenza', @proceeds_C, 'S')
	INSERT INTO #situation VALUES('',NULL,'H')
	
------------------------------------------------------------------------------------------------------------------------------------------------
-- 								GESTIONE RESIDUI * ENTRATE
------------------------------------------------------------------------------------------------------------------------------------------------
	INSERT INTO #situation
	VALUES('R E S I D U I',NULL,'N')
	DECLARE	fase_cursor INSENSITIVE	CURSOR FOR
	SELECT nphase, description FROM incomephase
	WHERE nphase >= @finphase AND @phasecod IN (@assessmentphase,@maxphase)
	FOR READ ONLY
	OPEN fase_cursor
	FETCH NEXT FROM	fase_cursor INTO @phasecod, @phasedescr
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SELECT @mov_R =	0
		SELECT @var_R = 0
		SELECT @mov_R =	ISNULL(amount, 0)
			FROM #mov_finphase_R
			WHERE nphase = @phasecod
	
		SELECT @var_R = ISNULL(amount, 0)
			FROM #var_finphase_R
			WHERE nphase = @phasecod
	
		INSERT INTO #situation	VALUES('1) Movimenti residui ('	+ @phasedescr	+ ')', @mov_R, '')
		INSERT INTO #situation	VALUES('2) Variazione residui ('+ @phasedescr	+ ')', @var_R, '')
		IF (@phasecod = @residualphase) -- Informazioni inerenti gli accertamenti
		BEGIN
			INSERT INTO #situation VALUES('Totale Residui Attivi ('
				+ @phasedescr	+ ')', 
				ISNULL(@mov_R,0) +
				ISNULL(@var_R,0)
				, 'S')
		END
		ELSE IF(@phasecod = @maxphase)
		BEGIN
			INSERT INTO #situation VALUES('3) Totale Movimenti residui ('
				+ @phasedescr	+ ')', 
				ISNULL(@mov_R,0) +
				ISNULL(@var_R,0), '')
			SET @movE_finphase_R = 
				ISNULL((SELECT SUM(amount) FROM #mov_finphase_R WHERE nphase = @residualphase),0) +
				ISNULL((SELECT SUM(amount) FROM #var_finphase_R WHERE nphase = @residualphase),0)
	
			INSERT INTO #situation VALUES('Residui Attivi da incassare',
				ISNULL(@movE_finphase_R,0) -
				ISNULL(@proceeds_R,0)
				, 'S')
		END
		FETCH NEXT FROM	fase_cursor INTO @phasecod, @phasedescr
	END
		
	DEALLOCATE fase_cursor
	
	DECLARE @totaccinc int
	SET @totalpro_C = 
		ISNULL((SELECT SUM(amount) FROM #mov_finphase_C WHERE nphase = @maxphase),0) +
		ISNULL((SELECT SUM(amount) FROM #var_finphase_C_aum WHERE nphase = @maxphase),0) +
		ISNULL((SELECT SUM(amount) FROM #var_finphase_C_dim WHERE nphase = @maxphase),0)
	
	SET @totalpro_R = 
		ISNULL((SELECT SUM(amount) FROM #mov_finphase_R WHERE nphase = @maxphase),0) +
		ISNULL((SELECT SUM(amount) FROM #var_finphase_R WHERE nphase = @maxphase),0)
	
	SET @totaccinc = 
		ISNULL(@movE_finphase_C,0) +
		ISNULL(@movE_finphase_R,0) -
		ISNULL(@totalpro_C,0) -
		ISNULL(@totalpro_R,0)
	INSERT INTO #situation	VALUES('Reversali emesse in c/residui', @proceeds_R, 'S')
	INSERT INTO #situation VALUES('',NULL,'H')
END
ELSE 
------------------------------------------------------------------------------------------------------------------------------------------------------
-- 								GESTIONE DI COMPETENZA * SPESA
------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN
	DECLARE	fase_cursor INSENSITIVE	CURSOR FOR
	SELECT nphase, description 
	FROM expensephase
	WHERE nphase >= @finphase AND nphase IN (@finphase,@assessmentphase,@maxphase)
	FOR READ ONLY
	OPEN fase_cursor
	FETCH NEXT FROM	fase_cursor INTO @phasecod, @phasedescr
	print @phasecod
	print @phasedescr
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		IF (@phasecod = @residualphase) SET @finphase_descr = @phasedescr
		ELSE SET @maxphase_descr = @phasedescr
		SELECT @mov_C = 0
		SELECT @var_C_aum = 0
		SELECT @var_C_dim = 0
		SELECT @mov_C = ISNULL(amount, 0)
			FROM #mov_finphase_C
			WHERE nphase = @phasecod
		SELECT @var_C_aum = ISNULL(amount, 0)
			FROM #var_finphase_C_aum
			WHERE nphase = @phasecod
		SELECT @var_C_dim = ISNULL(amount, 0)
			FROM #var_finphase_C_dim
			WHERE nphase = @phasecod
	---------------------------------------------------------------------------------------------------------------------------------------------
	-- Se la fase corrispondente all'accertamento o impegno non coincide con la prima fase di entrata o spesa in cui è imputata
	-- la voce di bilancio occorre prendere in considerazione la previsione disponibile calcolata su questa fase 
	---------------------------------------------------------------------------------------------------------------------------------------------
		IF (@phasecod = @finphase and @finphase < @assessmentphase )
		BEGIN
			SELECT @lbl_available_firstphase = '   Disponibilità per ulteriore ' + '"' + @phasedescr + '"'
			INSERT INTO #situation VALUES(@lbl_available_firstphase,
				ISNULL(@current_prevision, 0) -
				ISNULL(@mov_C,0) -
				ISNULL(@var_C_aum,0) -
 -				ISNULL(@var_C_dim,0) -
				ISNULL(@pettycash,0)	,'S')
		END
		ELSE
		BEGIN
			INSERT INTO #situation	VALUES('1) Movimenti competenza ('
			+ @phasedescr	+ ')', @mov_C, '')
			INSERT INTO #situation	VALUES('2) Variazioni in aumento competenza ('
			+ @phasedescr	+ ')', @var_C_aum, '')
			INSERT INTO #situation	VALUES('2) Variazioni in diminuzione competenza ('
			+ @phasedescr	+ ')', @var_C_dim, '')

			INSERT INTO #situation VALUES('3) Totale movimenti competenza ('
			+ @phasedescr	+ ')', 
			ISNULL(@mov_C,0) +
			ISNULL(@var_C_aum,0) +
			ISNULL(@var_C_dim,0), '')
			SELECT @lbl_appropriationavailable = 'Disponibilità per ' + '"' + @phasedescr + '"' +' (Prev. Attuale - 3'
			IF (@pettycash > 0)
				BEGIN
					INSERT INTO #situation	
					VALUES('4) Totale op. fondo economale attribuite non reintegrate',
						@pettycash, '')
					SELECT @lbl_appropriationavailable = @lbl_appropriationavailable + ' - 4'
				END
			IF (@phasecod = @assessmentphase)
				BEGIN
					SELECT @lbl_appropriationavailable = @lbl_appropriationavailable + ')'
					INSERT INTO #situation VALUES(@lbl_appropriationavailable,
						ISNULL(@current_prevision, 0) -
						ISNULL(@mov_C,0) -
						ISNULL(@var_C_aum,0) -
						ISNULL(@var_C_dim,0) -
						ISNULL(@pettycash,0)
						,'S')
				END
			IF (@phasecod = @maxphase)
			BEGIN
				SET @movS_finphase_C = 
				ISNULL((SELECT SUM(amount) FROM #mov_finphase_C WHERE nphase = @residualphase),0) +
				ISNULL((SELECT SUM(amount) FROM #var_finphase_C_aum WHERE nphase = @residualphase),0) +
				ISNULL((SELECT SUM(amount) FROM #var_finphase_C_dim WHERE nphase = @residualphase),0)
				INSERT INTO #situation VALUES('Impegnato di competenza da pagare',
				ISNULL(@movS_finphase_C,0) -
				ISNULL(@mov_C,0) - ISNULL(@var_C_aum,0)- ISNULL(@var_C_dim,0),'S')
			END
		END
	FETCH NEXT FROM fase_cursor INTO @phasecod, @phasedescr
	END
	DEALLOCATE fase_cursor
	INSERT INTO #situation	VALUES('Mandati emessi in c/competenza', @payment_C, 'S')
	INSERT INTO #situation VALUES('',NULL,'H')
------------------------------------------------------------------------------------------------------------------------------------------------------
-- 								GESTIONE RESIDUI * SPESA
------------------------------------------------------------------------------------------------------------------------------------------------------
	INSERT INTO #situation
	VALUES('R E S I D U I',NULL,'N')
	DECLARE	fase_cursor INSENSITIVE	CURSOR FOR
	SELECT nphase, description FROM expensephase
	WHERE nphase >= @finphase AND nphase IN (@assessmentphase,@maxphase)
	FOR READ ONLY
	OPEN fase_cursor
	FETCH NEXT FROM	fase_cursor INTO @phasecod, @phasedescr
	WHILE (@@FETCH_STATUS =	0)
	BEGIN		
		SELECT @mov_R =	0
		SELECT @var_R = 0	
		SELECT @mov_R =	ISNULL(amount, 0)
			FROM #mov_finphase_R
			WHERE nphase = @phasecod
		SELECT @var_R = ISNULL(amount, 0)
			FROM #var_finphase_R
			WHERE nphase = @phasecod		
		INSERT INTO #situation	VALUES('1) Movimenti residui ('
			+ @phasedescr	+ ')', @mov_R, '')
		INSERT INTO #situation	VALUES('2) Variazioni residui ('
			+ @phasedescr	+ ')', @var_R, '')
		IF (@phasecod = @residualphase)
		BEGIN
			INSERT INTO #situation VALUES('Totale Residui Passivi ('
				+ @phasedescr	+ ')', 
				ISNULL(@mov_R,0) +
				ISNULL(@var_R,0), 'S')
		END
		ELSE IF(@phasecod = @maxphase)
		BEGIN
			INSERT INTO #situation VALUES('3) Totale Movimenti residui ('
				+ @phasedescr	+ ')', 
				ISNULL(@mov_R,0) +
				ISNULL(@var_R,0), '')
			SET @movS_finphase_R = 
				ISNULL((SELECT SUM(amount) FROM #mov_finphase_R WHERE nphase = @residualphase),0) +
				ISNULL((SELECT SUM(amount) FROM #var_finphase_R WHERE nphase = @residualphase),0)
			INSERT INTO #situation VALUES('Residui Passivi da pagare',
				ISNULL(@movS_finphase_R,0) -
				ISNULL(@payment_R,0)
				, 'S')
			INSERT INTO #situation	VALUES('Mandati emessi in c/residui', @payment_R, 'S')
			INSERT INTO #situation VALUES('',NULL,'H')
		END
		FETCH NEXT FROM	fase_cursor INTO @phasecod, @phasedescr
	END
	DEALLOCATE fase_cursor
	DECLARE @totimppag int
	SET @totalpay_R = 
		ISNULL((SELECT SUM(amount) FROM #mov_finphase_R WHERE nphase = @maxphase),0) +
		ISNULL((SELECT SUM(amount) FROM #var_finphase_R WHERE nphase = @maxphase),0)
	SET @totalpay_C = 
		ISNULL((SELECT SUM(amount) FROM #mov_finphase_C WHERE nphase = @maxphase),0) +
		ISNULL((SELECT SUM(amount) FROM #var_finphase_C_aum WHERE nphase = @maxphase),0) +
		ISNULL((SELECT SUM(amount) FROM #var_finphase_C_dim WHERE nphase = @maxphase),0)
	SET @totimppag = 
		ISNULL(@movS_finphase_C,0) +
		ISNULL(@movS_finphase_R,0) -
		ISNULL(@totalpay_C,0) -
		ISNULL(@totalpay_R,0)
END
DECLARE @totaccertamenti decimal(19,2)
DECLARE @totimpegni decimal(19,2)
------------------------------------------------------------------------------------------------------------------------------------------------------
-- 								GESTIONE DI CASSA * SPESA
------------------------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO #situation
VALUES ('C A S S A',NULL,'N')
INSERT INTO #situation	
VALUES ('Previsione iniziale di cassa', @secondaryprev, '')
INSERT INTO #situation	
VALUES ('Variazioni di bilancio e Storni di previsione', @var_secondaryprev, '')
INSERT INTO #situation	
VALUES ('Previsione attuale di cassa', ISNULL(@current_secprevision, 0), 'S')
------------------------------------------------------------------------------------------------------------------------------------------------------
-- 								GESTIONE DI CASSA * ENTRATA
------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE @lbl_availableComp_E varchar(150) -- Etichetta sulla prev. disponibile di competenza
DECLARE @lbl_availableCass_E varchar(150) -- Etichetta sulla prev. disponibile di cassa che varia
DECLARE @lbl_availableComp_S varchar(150) -- Etichetta sulla prev. disponibile di competenza che varia in base alla presenza delle operazioni del fondo economale
DECLARE @lbl_availableCass_S varchar(150) -- Etichetta sulla prev. disponibile di cassa che varia in base alla presenza delle operazioni del fondo economale
DECLARE @nextphase_C decimal(19,2) -- Calcolo della fase successiva in c/competenza
DECLARE @nextphase_R decimal(19,2) -- Calcolo della fase successiva in c/residui
IF (@finpart = 'E')
BEGIN
	DECLARE	fase_cursor1 INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM incomephase
	WHERE nphase >= @finphase AND nphase IN (@assessmentphase,@maxphase)
	FOR READ ONLY
	OPEN fase_cursor1
	FETCH NEXT FROM	fase_cursor1 INTO @phasecod, @phasedescr
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SELECT @mov_C = 0
		SELECT @mov_R =	0
		SELECT @var_C = 0
		SELECT @var_R = 0
		SELECT @mov_C = ISNULL(amount, 0)
		FROM #mov_finphase_C
		WHERE nphase = @phasecod
		SELECT @mov_R =	ISNULL(amount, 0)
		FROM #mov_finphase_R
		WHERE nphase = @phasecod
		SELECT @var_C = ISNULL(amount, 0)
		FROM #var_finphase_C_aum
		WHERE nphase = @phasecod
		SELECT @var_C = @var_C + ISNULL(amount, 0)
		FROM #var_finphase_C_dim
		WHERE nphase = @phasecod
		SELECT @var_R = ISNULL(amount, 0)
		FROM #var_finphase_R
		WHERE nphase = @phasecod
		INSERT INTO #situation	VALUES('1) Movimenti ('	+ @phasedescr	+ ')', @mov_C + @mov_R, '')
		INSERT INTO #situation	VALUES('2) Variazioni movimenti ('+ @phasedescr	+ ')', @var_C + @var_R, '')
		INSERT INTO #situation VALUES('3) Totale Movimenti ('+@phasedescr	+ ')',
			ISNULL(@mov_C,0) +
			ISNULL(@mov_R,0) +
			ISNULL(@var_C,0) +
			ISNULL(@var_R,0),'')
		SELECT @lbl_assessmentavailable = 'Disponibilità per ' + '"' + @phasedescr + '"'+' (Prev. Attuale - 3'
		IF (@phasecod = @assessmentphase)
		BEGIN
			SELECT @lbl_assessmentavailable = @lbl_assessmentavailable + ')'
			INSERT INTO #situation	VALUES(@lbl_assessmentavailable, 
				ISNULL(@current_secprevision, 0) -
				ISNULL(@mov_C, 0) -
				ISNULL(@mov_R, 0) -
				ISNULL(@var_C, 0) -
				ISNULL(@var_R, 0), 'S')
		END
		IF (@phasecod = @maxphase)
			BEGIN
				SET @totaccertamenti = 
				ISNULL((SELECT SUM(amount) FROM #mov_finphase_C WHERE nphase = @assessmentphase),0) +
				ISNULL((SELECT SUM(amount) FROM #var_finphase_C_aum WHERE nphase = @assessmentphase),0) +
				ISNULL((SELECT SUM(amount) FROM #var_finphase_C_dim WHERE nphase = @assessmentphase),0) +
				ISNULL((SELECT SUM(amount) FROM #mov_finphase_R WHERE nphase = @assessmentphase),0) +
				ISNULL((SELECT SUM(amount) FROM #var_finphase_R WHERE nphase = @assessmentphase),0) 
				INSERT INTO #situation VALUES('Accertato da incassare',
				ISNULL(@totaccertamenti,0) -
				ISNULL(@mov_C,0) -
				ISNULL(@var_C,0) -
				ISNULL(@mov_R,0) -
				ISNULL(@var_R,0),'S')
				INSERT INTO #situation	VALUES('Disponibilità ad incassare (Reversali)', 
				ISNULL(@current_secprevision, 0) -
				ISNULL(@proceeds,0)
				, 'S')
			END
	FETCH NEXT FROM	fase_cursor1 INTO @phasecod, @phasedescr
	END
	DEALLOCATE fase_cursor1
	INSERT INTO #situation 
	VALUES('',NULL,'H')
-- Dopo le prove impostare il terzo parametro a N in luogo di S
	INSERT INTO #situation 
	VALUES('R I E P I L O G O  F A S I  F I N A N Z I A R I E',NULL,'N')
	DECLARE	fase_cursor1 INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM incomephase
	WHERE nphase >= @finphase
	FOR READ ONLY
	OPEN fase_cursor1
	FETCH NEXT FROM	fase_cursor1 INTO @phasecod, @phasedescr
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SELECT @mov_C = 0
		SELECT @var_C_aum = 0
		SELECT @var_C_dim = 0
		SELECT @mov_R =	0
		SELECT @var_R = 0
		SELECT @nextphase_C = 0
		SELECT @nextphase_R = 0
		SELECT @mov_C = ISNULL(amount, 0)
			FROM #mov_finphase_C
			WHERE nphase = @phasecod
		SELECT @var_C_aum = ISNULL(amount, 0)
			FROM #var_finphase_C_aum
			WHERE nphase = @phasecod
		SELECT @var_C_dim = ISNULL(amount, 0)
			FROM #var_finphase_C_dim
			WHERE nphase = @phasecod
		SELECT @mov_R =	ISNULL(amount, 0)
			FROM #mov_finphase_R
			WHERE nphase = @phasecod
		SELECT @var_R = ISNULL(amount, 0)
			FROM #var_finphase_R
			WHERE nphase = @phasecod
	-- Calcolo della fase successiva per sottrarla a quella attuale
		IF @phasecod < @maxphase
		BEGIN
			SELECT @nextphase_C = ISNULL(amount,0)
			FROM #mov_finphase_C
			WHERE nphase = (@phasecod + 1)
			SET @nextphase_C = ISNULL(@nextphase_C,0) + 
				ISNULL((SELECT ISNULL(amount,0) FROM #var_finphase_C_aum WHERE nphase = (@phasecod + 1)),0)+ 
				ISNULL((SELECT ISNULL(amount,0) FROM #var_finphase_C_dim WHERE nphase = (@phasecod + 1)),0)
			SELECT @nextphase_R = ISNULL(amount,0)
			FROM #mov_finphase_R
			WHERE nphase = (@phasecod + 1)
			SET @nextphase_R = ISNULL(@nextphase_R,0) +
				ISNULL((SELECT ISNULL(amount,0) FROM #var_finphase_R WHERE nphase = (@phasecod + 1)),0)
		END
		ELSE
		BEGIN
			SET @nextphase_C = ISNULL(@proceeds_C,0)
			SET @nextphase_R = ISNULL(@proceeds_R,0)
		END
		INSERT INTO #situation 
		VALUES('1. Totale Movimenti competenza (' + @phasedescr +')',ISNULL(@mov_C,0),'')
		INSERT INTO #situation 
		VALUES('2a. Totale Variazioni in aumento competenza (' + @phasedescr +')',ISNULL(@var_C_aum,0),'')
		INSERT INTO #situation 
		VALUES('2b. Totale Variazioni in diminuzione competenza (' + @phasedescr +')',ISNULL(@var_C_dim,0),'')
		INSERT INTO #situation 
		VALUES('3. Totale Movimenti residui (' + @phasedescr +')',ISNULL(@mov_R,0),'')
		INSERT INTO #situation 
		VALUES('4. Totale Variazioni residui (' + @phasedescr +')',ISNULL(@var_R,0),'')
		SELECT @lbl_availableComp_E = 'Previsione Disponibile di Competenza (Prev. Attuale - 1 - 2)'
		SELECT @lbl_availableCass_E = 'Previsione Disponibile di Cassa (Prev. Attuale - 1 - 2 - 3 - 4)'
		
		INSERT INTO #situation 
		VALUES(@lbl_availableComp_E,
			ISNULL(@current_prevision,0) -
			ISNULL(@mov_C,0) -
			ISNULL(@var_C_aum,0) -
			ISNULL(@var_C_dim,0)
			,'S')
		INSERT INTO #situation 
		VALUES(@lbl_availableCass_E,
			ISNULL(@current_secprevision,0) -
			ISNULL(@mov_C,0) -
			ISNULL(@var_C_aum,0) -
			ISNULL(@var_C_dim,0) -
			ISNULL(@mov_R,0) -
			ISNULL(@var_R,0)
			,'S')
		INSERT INTO #situation 
		VALUES('('+@phasedescr+') restanti rispetto alla fase successiva in c/competenza',
			ISNULL(@mov_C,0) + 
			ISNULL(@var_C_aum,0) + 
			ISNULL(@var_C_dim,0) -
			ISNULL(@nextphase_C,0),'S')
		INSERT INTO #situation 
		VALUES('('+@phasedescr+') restanti rispetto alla fase successiva in c/residui',
			ISNULL(@mov_R,0) + 
			ISNULL(@var_R,0) -
			ISNULL(@nextphase_R,0),'S')
	FETCH NEXT FROM	fase_cursor1 INTO @phasecod, @phasedescr
	END
	DEALLOCATE fase_cursor1
	INSERT INTO #situation	VALUES('Totale Reversali in c/competenza', ISNULL(@proceeds_C,0), '')	
	INSERT INTO #situation VALUES('Totale Reversali in c/residui', ISNULL(@proceeds_R,0),'')
	INSERT INTO #situation	VALUES('Totale Reversali', ISNULL(@proceeds,0), 'S')
	END
ELSE 
------------------------------------------------------------------------------------------------------------------------------------------------------
-- 								GESTIONE DI CASSA * SPESA
------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN
	DECLARE	fase_cursor1 INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM expensephase
	WHERE nphase >= @finphase AND nphase IN (@assessmentphase,@maxphase)
	FOR READ ONLY
	
	OPEN fase_cursor1
	FETCH NEXT FROM	fase_cursor1 INTO @phasecod, @phasedescr
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SELECT @mov_C = 0
		SELECT @mov_R =	0
		SELECT @var_C = 0
		SELECT @var_R = 0						
		SELECT @mov_C = 0
		SELECT @mov_C = ISNULL(amount, 0)
		FROM #mov_finphase_C
		WHERE nphase = @phasecod
		SELECT @mov_R =	ISNULL(amount, 0)
		FROM #mov_finphase_R
		WHERE nphase = @phasecod
		SELECT @var_C = ISNULL(amount, 0)
		FROM #var_finphase_C_aum
		WHERE nphase = @phasecod
		SELECT @var_C = @var_C +ISNULL(amount, 0)
		FROM #var_finphase_C_dim
		WHERE nphase = @phasecod
		SELECT @var_R = ISNULL(amount, 0)
		FROM #var_finphase_R
		WHERE nphase = @phasecod
		INSERT INTO #situation	
		VALUES('1) Movimenti ('	+ @phasedescr	+ ')', @mov_C + @mov_R, '')
		INSERT INTO #situation	
		VALUES('2) Variazioni movimenti ('+ @phasedescr	+ ')', @var_C + @var_R, '')
		INSERT INTO #situation 
		VALUES('3) Totale Movimenti ('
			+ @phasedescr	+ ')',
			ISNULL(@mov_C,0) +
			ISNULL(@mov_R,0) +
			ISNULL(@var_C,0) +
			ISNULL(@var_R,0),'')
		SELECT @lbl_appropriationavailable = 'Disponibilità per ' + '"' + @phasedescr + '"' + ' (Prev. Attuale - 3'
		IF (@pettycash > 0)
		BEGIN
			INSERT INTO #situation	VALUES(
			'4) Totale op. fondo economale attribuite non reintegrate',@pettycash, '')
			SELECT @lbl_appropriationavailable = @lbl_appropriationavailable + ' - 4'
		END
		IF (@phasecod = @assessmentphase)
		BEGIN
			SELECT @lbl_appropriationavailable = @lbl_appropriationavailable + ')'
			INSERT INTO #situation 
			VALUES(@lbl_appropriationavailable,
				ISNULL(@current_secprevision, 0) -
				ISNULL(@mov_C,0) -
				ISNULL(@var_C,0) -
				ISNULL(@mov_R,0) -
				ISNULL(@var_R,0) -
				ISNULL(@pettycash,0)
				,'S')
		END
		IF (@phasecod = @maxphase)
		BEGIN
			SET @totimpegni = 
			ISNULL((SELECT SUM(amount) FROM #mov_finphase_C WHERE nphase = @assessmentphase),0) +
			ISNULL((SELECT SUM(amount) FROM #var_finphase_C_aum WHERE nphase = @assessmentphase),0) +
			ISNULL((SELECT SUM(amount) FROM #var_finphase_C_dim WHERE nphase = @assessmentphase),0) +
			ISNULL((SELECT SUM(amount) FROM #mov_finphase_R WHERE nphase = @assessmentphase),0) +
			ISNULL((SELECT SUM(amount) FROM #var_finphase_R WHERE nphase = @assessmentphase),0)
			INSERT INTO #situation 
			VALUES('Impegnato da pagare',
				ISNULL(@totimpegni,0) -
				ISNULL(@mov_C,0) -
				ISNULL(@var_C,0) -
				ISNULL(@mov_R,0) -
				ISNULL(@var_R,0),'S')
			INSERT INTO #situation 
			VALUES('Disponibilità a pagare (Mandati)',
				ISNULL(@current_secprevision, 0) -
				ISNULL(@payment,0) -
				ISNULL(@pettycash,0)
				,'S')
		END
	FETCH NEXT FROM	fase_cursor1 INTO @phasecod, @phasedescr
	END
	DEALLOCATE fase_cursor1
	INSERT INTO #situation VALUES('',NULL,'H')
	INSERT INTO #situation VALUES('R I E P I L O G O  F A S I  F I N A N Z I A R I E',NULL,'N')
	DECLARE	fase_cursor INSENSITIVE	CURSOR FOR
	SELECT nphase, description FROM expensephase
	WHERE nphase >= @finphase
	FOR READ ONLY
	OPEN fase_cursor
	FETCH NEXT FROM	fase_cursor INTO @phasecod, @phasedescr
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SELECT @mov_C = 0
		SELECT @var_C_aum = 0
		SELECT @var_C_dim = 0
		SELECT @mov_R =	0
		SELECT @var_R = 0
		SELECT @nextphase_C = 0
		SELECT @nextphase_R = 0
		SELECT @mov_C = ISNULL(amount, 0)
		FROM #mov_finphase_C
		WHERE nphase = @phasecod
		SELECT @var_C_aum = ISNULL(amount, 0)
		FROM #var_finphase_C_aum
		WHERE nphase = @phasecod
		SELECT @var_C_dim = ISNULL(amount, 0)
		FROM #var_finphase_C_dim
		WHERE nphase = @phasecod
		SELECT @mov_R =	ISNULL(amount, 0)
		FROM #mov_finphase_R
		WHERE nphase = @phasecod
		SELECT @var_R = ISNULL(amount, 0)
		FROM #var_finphase_R
		WHERE nphase = @phasecod
	-- Calcolo della fase successiva per sottrarla a quella attuale
		IF @phasecod < @maxphase
		BEGIN
			SELECT @nextphase_C = ISNULL(amount,0)
			FROM #mov_finphase_C
			WHERE nphase = (@phasecod + 1)
			SET @nextphase_C = ISNULL(@nextphase_C,0) + 
				ISNULL((SELECT ISNULL(amount,0) FROM #var_finphase_C_aum WHERE nphase = (@phasecod + 1)),0)+ 
				ISNULL((SELECT ISNULL(amount,0) FROM #var_finphase_C_dim WHERE nphase = (@phasecod + 1)),0)
			SELECT @nextphase_R = ISNULL(amount,0)
			FROM #mov_finphase_R
			WHERE nphase = (@phasecod + 1)
			SET @nextphase_R = ISNULL(@nextphase_R,0) +
					ISNULL((SELECT ISNULL(amount,0) FROM #var_finphase_R WHERE nphase = (@phasecod + 1)),0)
		END
		ELSE
		BEGIN
			SET @nextphase_C = ISNULL(@payment_C,0)
			SET @nextphase_R = ISNULL(@payment_R,0)
		END
		INSERT INTO #situation VALUES('1. Totale Movimenti competenza (' + @phasedescr +')',
				ISNULL(@mov_C,0),'')
		INSERT INTO #situation VALUES('2. Totale Variazioni in aumento competenza (' + @phasedescr +')',
				ISNULL(@var_C_aum,0),'')
		INSERT INTO #situation VALUES('2. Totale Variazioni in diminuzione competenza (' + @phasedescr +')',
				ISNULL(@var_C_dim,0),'')
		INSERT INTO #situation VALUES('3. Totale Movimenti residui (' + @phasedescr +')',
				ISNULL(@mov_R,0),'')
		INSERT INTO #situation VALUES('4. Totale Variazioni residui (' + @phasedescr +')',
				ISNULL(@var_R,0),'')
		SELECT @lbl_availableComp_S = 'Previsione Disponibile di Competenza (Prev. Attuale - 1 - 2'
		SELECT @lbl_availableCass_S = 'Previsione Disponibile di Cassa (Prev. Attuale - 1 - 2 - 3 - 4'
		IF (@pettycash > 0)
		BEGIN
			INSERT INTO #situation VALUES('5. Totale operazioni fondo economale',ISNULL(@pettycash,0),'')
			SELECT @lbl_availableComp_S = @lbl_availableComp_S + ' - 5'
			SELECT @lbl_availableCass_S = @lbl_availableCass_S + ' - 5'
		END
		SELECT @lbl_availableComp_S = @lbl_availableComp_S + ')'
		SELECT @lbl_availableCass_S = @lbl_availableCass_S + ')'
		INSERT INTO #situation 
		VALUES(@lbl_availableComp_S,
			ISNULL(@current_prevision,0) -
			ISNULL(@mov_C,0) -
			ISNULL(@var_C_aum,0) -
			ISNULL(@var_C_dim,0) -
			ISNULL(@pettycash,0)
			,'S')
		INSERT INTO #situation 
		VALUES(@lbl_availableCass_S,
				ISNULL(@current_secprevision,0) -
				ISNULL(@mov_C,0) -
				ISNULL(@var_C_aum,0) -
				ISNULL(@var_C_dim,0) -
				ISNULL(@mov_R,0) -
				ISNULL(@var_R,0) -
				ISNULL(@pettycash,0)
				,'S')
		INSERT INTO #situation 
		VALUES('('+@phasedescr+') restanti rispetto alla fase successiva in c/competenza',
				ISNULL(@mov_C,0) + 
				ISNULL(@var_C_aum,0) + 
				ISNULL(@var_C_dim,0) -
				ISNULL(@nextphase_C,0),'S')
		INSERT INTO #situation VALUES('('+@phasedescr+') restanti rispetto alla fase successiva in c/residui',
			ISNULL(@mov_R,0) + 
			ISNULL(@var_R,0) -
			ISNULL(@nextphase_R,0),'S')
	FETCH NEXT FROM	fase_cursor INTO @phasecod, @phasedescr
	END
	DEALLOCATE fase_cursor
	INSERT INTO #situation	VALUES('Totale Mandati in c/competenza', ISNULL(@payment_C,0), '')	
	INSERT INTO #situation VALUES('Totale Mandati in c/residui', ISNULL(@payment_R,0),'')
	INSERT INTO #situation VALUES('Totale Mandati', ISNULL(@payment,0),'S')
END			
SELECT value, amount, kind FROM #situation	
END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





