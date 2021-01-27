
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_finyear_comp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_finyear_comp]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
/*
exec show_finyear_comp {ts '2007-03-07 00:00:00'},'0001',11180, 'E'
07E
*/
 

CREATE        PROCEDURE [show_finyear_comp]
	@date datetime,
	@idupb varchar(36),
	@idfin int ,
	@finpart char(1)
AS
BEGIN
/* Versione 1.0.1 del 27/11/2007 ultima modifica: MARIA */
DECLARE	@ayear int -- Esercizio
SELECT @ayear = YEAR(@date)

DECLARE @lbl_dispacc varchar(150) -- Etichetta sulla disponibilità ad accertate
DECLARE @lbl_dispcomp_e varchar(150) -- Etichetta sulla prev. disponibile di competenza
DECLARE @lbl_dispimp varchar(150) -- Etichetta sulla disponibilità ad impegnare che varia in base alla presenza delle operazioni del fondo economale
DECLARE @lbl_dispcomp_s varchar(150) -- Etichetta sulla prev. disponibile di competenza che varia in base alla presenza delle operazioni del fondo economale
DECLARE @lbl_dispprimafase varchar(150) -- Etichetta sulla disponibilità calcolata sulla prima fase di entrata o di spesa 
DECLARE	@mainprev_var_AUM decimal(19,2) -- Totale delle variazioni di previsione principale in aumento
DECLARE	@mainprev_var_DIM decimal(19,2) -- Totale delle variazioni di previsione principale in diminuzione

DECLARE @nextphasecomp decimal(19,2) -- Calcolo della fase successiva in c/competenza
DECLARE @nextphaseres decimal(19,2) -- Calcolo della fase successiva in c/residui

-- Tabella della situazione della voce di bilancio
CREATE TABLE #situation	(value varchar(200), amount decimal(19,2), kind char(1))

 

DECLARE @creditsurplus decimal(19,2) -- Avanzo di Amministrazione
SELECT @creditsurplus = creditsurplus FROM finsurplusview WHERE ayear = @ayear

DECLARE	@departmentname varchar(150) -- Nome del Dipartimento

SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')



DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

PRINT @finpart_bit

DECLARE	@arrearsphase int
SELECT @arrearsphase = 1

DECLARE	@levelusable tinyint -- Livello operativo per le voci di bilancio
SELECT @levelusable = MIN(nlevel) FROM finlevel WHERE (flag & 2)<>0 AND ayear =@ayear

DECLARE	@fincode varchar(50) -- Codice di bilancio
DECLARE	@fintitle varchar(150) -- Descrizione della voce di bilancio
DECLARE	@nlevel tinyint -- Livello della voce di bilancio
DECLARE	@leveldesc varchar(50)
SELECT @nlevel = nlevel, 
	@fincode = codefin,
	@fintitle = title 	
FROM fin  WHERE idfin = @idfin

SELECT @leveldesc = description 
FROM finlevel  
WHERE ayear = @ayear AND @nlevel = nlevel

DECLARE	@finphase tinyint  -- Fase in cui viene inserita la voce di bilancio
DECLARE	@lastphase tinyint  -- Fase di cassa

DECLARE @competencyphase tinyint  -- Fase paragonabile all'accertamento o all'impegno
IF @finpart = 'E'
BEGIN
	SELECT @competencyphase = assessmentphasecode FROM config
		WHERE ayear = @ayear
	SELECT @arrearsphase = incomefinphase from uniconfig
	SELECT @finphase = incomefinphase from uniconfig
	SELECT @lastphase = MAX(nphase) FROM incomephase
END
ELSE
BEGIN
	SELECT @competencyphase = appropriationphasecode FROM config 
		WHERE ayear = @ayear
	SELECT @arrearsphase = expensefinphase from uniconfig
	SELECT @finphase =  expensefinphase from uniconfig
	SELECT @lastphase = MAX(nphase) FROM expensephase
END


DECLARE @descupb varchar(150)
DECLARE @codeupb varchar(50)
SELECT @descupb = title,
@codeupb = codeupb
FROM upb
WHERE idupb = @idupb

DECLARE	@mainprev decimal(19,2) -- Previsione Principale
IF (@nlevel < @levelusable) OR (@nlevel IS NULL)
	BEGIN
		print 'then'
		SELECT @mainprev = SUM(ISNULL(prevision,0)) 
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
		--AND nlevel = @levelusable AND idupb = @idupb
	END
ELSE
	BEGIN
	SELECT @mainprev = prevision
		FROM finyear
		WHERE idfin = @idfin
		AND idupb = @idupb
	END

SELECT @mainprev_var_AUM = SUM(FVD.amount)
FROM finvardetail FVD  
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN finlink FLK
	ON FLK.idchild = FVD.idfin
join fin F
	ON FVD.idfin = F.idfin
WHERE (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
	AND FV.adate <=	@date
	AND FV.flagprevision = 'S'
	AND FV.variationkind <> 5 
	AND FV.idfinvarstatus = 5
	and ((F.flag & 1 ) = @finpart_bit) and F.ayear = @ayear
	AND FVD.idupb = @idupb
	AND FVD.amount > 0

SELECT @mainprev_var_DIM = SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN finlink FLK
	ON FLK.idchild = FVD.idfin
join fin F
	ON FVD.idfin = F.idfin
WHERE 	(	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
	AND FV.adate <=	@date
	AND FV.flagprevision = 'S'
	AND FV.variationkind <> 5 
	AND FV.idfinvarstatus = 5
	and ((F.flag & 1 ) = @finpart_bit) and F.ayear = @ayear
	AND FVD.idupb = @idupb
	AND FVD.amount < 0

DECLARE @tot_mainprev_var decimal(19,2) -- Totale delle variazioni di previsione principale
-- Calcolo delle variazioni totali sulla previsione principale date dalla somma algebrica di quelle in aumento e quelle in diminuzione
SET @tot_mainprev_var = ISNULL(@mainprev_var_AUM,0) + ISNULL(@mainprev_var_DIM,0)

-- Tabella dei movimenti di competenza
CREATE TABLE #tot_mov_c	(nphase tinyint,amount decimal(19,2) NULL)

-- Tabella delle variazioni sui movimenti di competenza
CREATE TABLE #tot_var_c	(nphase tinyint NULL,amount decimal(19,2) NULL)

-- Tabella dei movimenti residui
CREATE TABLE #tot_mov_r	(nphase tinyint NULL,amount decimal(19,2) NULL)

-- Tabella delle variazioni sui movimenti residui
CREATE TABLE #tot_var_r (nphase tinyint NULL,amount decimal(19,2) NULL)

DECLARE	@tot_creditpart decimal(19,2) -- Totale assegnazione dei crediti
DECLARE @totcreditsurplus decimal(19,2) -- Totale ripartizione dell'avanzo di amministrazione
DECLARE	@totcreditvar decimal(19,2) -- Totale variazione assegnazione dei crediti
DECLARE	@totproceedspart decimal(19,2) -- Totale assegnazioni di cassa
DECLARE @totproceedscomp decimal(19,2) -- Totale delle reversali di competenza
DECLARE @totproceedsres decimal(19,2) -- Totale delle reversali residue
DECLARE @totcashsurplus decimal(19,2) -- Totale ripartizione dell'avanzo di cassa
DECLARE	@totproceedsvar decimal(19,2) -- Totale variazioni assegnazioni di cassa
DECLARE @currmainprev decimal(19,2) -- Previsione Attuale Principale

DECLARE @totpayment decimal(19,2) -- Totale Mandati (secondo la configurazione di bilancio)
DECLARE @totproceeds decimal(19,2) -- Totale Reversali (secondo la configurazione di bilancio)
DECLARE @totpaymentcomp decimal(19,2) -- Totale dei mandati di competenza
DECLARE @totpaymentres decimal(19,2) -- Totale dei mandati residui

-- Calcolo della previsione attuale
SET @currmainprev = ISNULL(@mainprev,0) + ISNULL(@tot_mainprev_var,0)
IF  @finpart = 'E'
	BEGIN
		INSERT INTO #tot_mov_c
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
		WHERE
			((finlink.nlevel = @nlevel AND finlink.idparent = @idfin ) or (@idfin is null AND finlink.nlevel = @levelusable))
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1)=0) --Competenza
			AND incomeyear.idupb = @idupb
			AND income.nphase >= @finphase
			AND income.adate <= @date
		GROUP BY income.nphase

		INSERT INTO #tot_mov_r
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
		WHERE 
			((finlink.nlevel = @nlevel AND finlink.idparent = @idfin ) or (@idfin is null AND finlink.nlevel = @levelusable))
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1) = 1) --Residuo
			AND incomeyear.idupb = @idupb
			AND income.nphase >= @finphase
			AND income.adate <= @date
		GROUP BY income.nphase


		INSERT INTO #tot_var_c
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
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1) = 0) --Copetenza
			AND income.nphase >= @finphase
			AND((finlink.nlevel = @nlevel AND finlink.idparent = @idfin ) or (@idfin is null AND finlink.nlevel = @levelusable))
		GROUP BY income.nphase

		INSERT INTO #tot_var_r
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
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1) = 1) --Residuo
			AND income.nphase >= @finphase
			AND ((finlink.nlevel = @nlevel AND finlink.idparent = @idfin ) or (@idfin is null AND finlink.nlevel = @levelusable))
		GROUP BY income.nphase

		SET @totproceedscomp = 
		ISNULL(
			(SELECT SUM(HPV.curramount)
			FROM historyproceedsview HPV
			JOIN finlink FLK
				ON FLK.idchild = HPV.idfin
			WHERE HPV.ymov = @ayear
				AND ((HPV.totflag & 1) = 0) --Competenza
				AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
				AND HPV.idupb = @idupb
				AND HPV.competencydate <= @date)
		,0)

		SET @totproceedsres = 
		ISNULL(
			(SELECT SUM(curramount)
			FROM historyproceedsview HPV
			JOIN finlink FLK
				ON FLK.idchild = HPV.idfin
			WHERE HPV.ymov = @ayear
				AND ((HPV.totflag & 1) = 1) --Resiudo
				AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
				AND idupb = @idupb
				AND competencydate <= @date)
		,0)
		
		SET @totproceeds = ISNULL(@totproceedscomp,0) + ISNULL(@totproceedsres,0)
	END
ELSE
-- --------------> Parte 	SPESA	
	BEGIN
		-- Controllo se l'UPB ha finanziamento certo
		DECLARE @assured char(1)
		SELECT @assured = assured FROM upb WHERE idupb = @idupb

		INSERT INTO #tot_mov_c
		SELECT expense.nphase, 
			SUM(expenseyear.amount)
		FROM expenseyear
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN expense
			ON expense.idexp = expenseyear.idexp
			AND expense.adate <= @date
		JOIN finlink 
			ON finlink.idchild = expenseyear.idfin
		WHERE 	((finlink.nlevel = @nlevel AND finlink.idparent = @idfin ) or (@idfin is null AND finlink.nlevel = @levelusable))
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 0) --Competenza
			AND expenseyear.idupb = @idupb
			AND expense.nphase >= @finphase
		GROUP BY expense.nphase

		INSERT INTO #tot_mov_r
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
		WHERE 	((finlink.nlevel = @nlevel AND finlink.idparent = @idfin ) or (@idfin is null AND finlink.nlevel = @levelusable))
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 1) --Residuo
			AND expense.adate <= @date
			AND expenseyear.idupb = @idupb
			AND expense.nphase >= @finphase
		GROUP BY expense.nphase

		INSERT INTO #tot_var_c
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
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 0) --Competenza
			AND expense.nphase >= @finphase
			AND ((finlink.nlevel = @nlevel AND finlink.idparent = @idfin ) or (@idfin is null AND finlink.nlevel = @levelusable))
		GROUP BY expense.nphase

		INSERT INTO #tot_var_r
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
			AND ((finlink.nlevel = @nlevel AND finlink.idparent = @idfin ) or (@idfin is null AND finlink.nlevel = @levelusable))
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 1) --Residuo
			AND expense.nphase >= @finphase
			AND expensevar.adate <= @date
			AND expenseyear.idupb = @idupb
		GROUP BY expense.nphase

		IF (@assured <> 'S')
		BEGIN

			SELECT @tot_creditpart = SUM(creditpart.amount)
			FROM creditpart
			JOIN finlink 
				ON finlink.idchild = creditpart.idfin
			join fin F
				on creditpart.idfin = F.idfin
			WHERE 	((finlink.nlevel = @nlevel AND finlink.idparent = @idfin ) or (@idfin is null AND finlink.nlevel = @levelusable))
				AND creditpart.adate <= @date
				AND creditpart.idupb = @idupb
				AND ( (F.flag & 1)=1)--solo per le spese
				AND F.ayear = @ayear
				AND creditpart.ycreditpart = @ayear


			SELECT @totcreditsurplus = SUM(D.amount)
			FROM finvardetail D
			JOIN finvar V
				ON V.yvar = D.yvar
				AND V.nvar = D.nvar 
			JOIN finlink FLK
				ON FLK.idchild = D.idfin
			join fin F
				on D.idfin = F.idfin
			WHERE ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
				AND ( (F.flag & 1)=1)--solo per le spese
				AND F.ayear = @ayear
				AND V.adate <= @date
				AND V.flagcredit = 'S'
				AND V.idfinvarstatus = 5
				AND V.variationkind IN (2,3)
				AND D.idupb = @idupb

			SELECT @totcreditvar = SUM(D.amount)
			FROM finvardetail D
			JOIN finvar V
				ON V.yvar = D.yvar
				AND V.nvar = D.nvar
			JOIN finlink FLK
				ON FLK.idchild = D.idfin
			join fin F
				on D.idfin = F.idfin
			WHERE 
				((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
				AND ( (F.flag & 1)=1)--solo per le spese
				AND F.ayear = @ayear
				AND V.adate <= @date
				AND V.flagcredit = 'S'
				AND V.idfinvarstatus = 5
				AND V.variationkind IN (1,4)
				AND D.idupb = @idupb

			SELECT @totproceedspart = SUM(proceedspart.amount)
			FROM proceedspart
			JOIN finlink 
				ON finlink.idchild = proceedspart.idfin
			join fin F
				on proceedspart.idfin = F.idfin
			WHERE ((finlink.nlevel = @nlevel AND finlink.idparent = @idfin ) or (@idfin is null AND finlink.nlevel = @levelusable))
				AND ( (F.flag & 1)=1)--solo per le spese
				AND F.ayear = @ayear
				and proceedspart.adate <= @date
				AND proceedspart.idupb = @idupb

			SELECT @totcashsurplus = SUM(D.amount)
			FROM finvardetail D
			JOIN finvar V
				ON V.yvar = D.yvar
				AND V.nvar = D.nvar
			JOIN finlink FLK
				ON FLK.idchild = D.idfin
			join fin F
				on D.idfin = F.idfin
			WHERE 
				((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
				AND ( (F.flag & 1)=1)--solo per le spese
				AND F.ayear = @ayear
				AND v.adate <= @date
				AND v.flagproceeds = 'S'
				AND v.idfinvarstatus = 5
				AND v.variationkind IN (2,3)
				AND d.idupb = @idupb

			SELECT @totproceedsvar = SUM(D.amount)
			FROM finvardetail D
			JOIN finvar V
				ON V.yvar = D.yvar
				AND V.nvar = D.nvar
			JOIN finlink FLK
				ON FLK.idchild = D.idfin
			join fin F
				on D.idfin = F.idfin
			WHERE 
				((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
				AND ( (F.flag & 1)=1)--solo per le spese
				AND F.ayear = @ayear
				AND V.adate <= @date
				AND V.flagproceeds = 'S'
				AND V.idfinvarstatus = 5
				AND V.variationkind IN (1,4)
				AND D.idupb = @idupb
		END
		ELSE
		BEGIN
			SET @tot_creditpart = 0
			SET @totcreditsurplus = 0
			SET @totcreditvar = 0
			SET @totproceedspart = 0
			SET @totcashsurplus = 0
			SET @totproceedsvar = 0
		END

		SET @totpaymentcomp = 
		ISNULL(
			(SELECT SUM(curramount)
			FROM historypaymentview HPV 
			JOIN finlink FLK
				ON FLK.idchild = HPV.idfin
			WHERE HPV.ymov = @ayear
				AND ((HPV.totflag & 1) = 0) --Competenza
				AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
				AND idupb = @idupb
				AND competencydate <= @date)
		,0)

		SET @totpaymentres = 
		ISNULL(
			(SELECT SUM(curramount)
			FROM historypaymentview HPV
			JOIN finlink FLK
				ON FLK.idchild = HPV.idfin
			WHERE HPV.ymov = @ayear
				AND ((HPV.totflag & 1) = 1) --Residuo
				AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
				AND idupb = @idupb
				AND competencydate <= @date)
		,0)

		SET @totpayment = ISNULL(@totpaymentcomp,0) + ISNULL(@totpaymentres,0)
	END

DECLARE	@totpettycashop decimal(19,2) -- Totale operazioni fondo economale
SELECT @totpettycashop = SUM(operation.amount)
FROM pettycashoperation operation
JOIN finlink flk
	ON flk.idchild = operation.idfin
join fin F
	on operation.idfin = F.idfin
WHERE 
	((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
	AND operation.idupb = @idupb
	AND F.ayear = @ayear
	AND operation.adate	<= @date
	AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
	WHERE restoreop.yoperation = operation.yrestore
		AND restoreop.noperation = operation.nrestore
		AND restoreop.idpettycash = operation.idpettycash
		AND restoreop.adate <= @date)

INSERT INTO #situation	
	VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation	
	VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
INSERT INTO #situation
	VALUES (@codeupb + ' - ' + @descupb, NULL, 'H')
INSERT INTO #situation	
	VALUES (@leveldesc + ' ' + @fincode, NULL, 'H')
INSERT INTO #situation	
	VALUES (@fintitle,	NULL, 'H')
INSERT INTO #situation	
	VALUES ('', NULL, 'N')
INSERT INTO #situation
	VALUES('C O M P E T E N Z A',NULL,'N')
INSERT INTO #situation	
	VALUES ('Previsione iniziale di competenza', @mainprev, '')
INSERT INTO #situation	
	VALUES ('Variazioni di bilancio e Storni di previsione', @tot_mainprev_var,	'')
	
INSERT INTO #situation	
	VALUES ('Previsione attuale di competenza', ISNULL(@currmainprev, 0), 'S')
IF @finpart = 'S' AND 
		(EXISTS	
		(SELECT	* FROM creditpart 
			WHERE ycreditpart = @ayear
			AND adate <= @date) 
			OR
		EXISTS (SELECT * FROM finvar
		WHERE yvar = @ayear
		AND flagcredit = 'S'
		AND variationkind <> 5 
		AND adate <= @date
		AND idfinvarstatus = 5))
		AND @assured <> 'S'
BEGIN
	INSERT INTO #situation VALUES ('Avanzo di Amministrazione',@totcreditsurplus,'')	
	INSERT INTO #situation	VALUES ('Assegnazione crediti',	@tot_creditpart, '')
	INSERT INTO #situation	VALUES ('Variazione e Storni di Crediti', @totcreditvar, '')
	INSERT INTO #situation	VALUES ('Previsione da accreditare', 
		ISNULL(@currmainprev, 0) -
		ISNULL(@totcreditsurplus,0) -		
		ISNULL(@tot_creditpart, 0) - 
		ISNULL(@totcreditvar, 0),'S')
END
DECLARE	@competency_total decimal(19,2)
DECLARE	@arrears_total decimal(19,2)
DECLARE	@competencyvar_total decimal(19,2)
DECLARE	@arrearsvar_total decimal(19,2)
DECLARE	@nphase tinyint
DECLARE	@phasetitle varchar(50)
DECLARE @totcompexpense decimal(19,2)
DECLARE @tot_appropriation_R decimal(19,2)
DECLARE @tot_lastexpensephase_C decimal(19,2)
DECLARE @tot_lastexpensephase_R decimal(19,2)
DECLARE @competencyincome_total decimal(19,2)
DECLARE @revenue_total decimal(19,2)
DECLARE @tot_lastincomephase_C decimal(19,2)
DECLARE @tot_lastincomephase_R decimal(19,2)

DECLARE @arrearstitle varchar(50) -- Nome della fase 'Accertamento' - 'Impegno'
DECLARE @lastphasedescription varchar(50) -- Nome della fase 'Riga Reversale' - 'Riga Mandato'

-- GESTIONE DI COMPETENZA
IF @finpart = 'E'
	BEGIN
		-- Gestione in c/competenza
		DECLARE	crsphase INSENSITIVE CURSOR FOR
			SELECT nphase, description FROM incomephase
			WHERE nphase >= @finphase AND nphase in (@finphase,@competencyphase,@lastphase) --M. Smaldino
			FOR READ ONLY
		OPEN crsphase
		FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
		WHILE (@@FETCH_STATUS =	0)
			BEGIN
				IF (@nphase = @arrearsphase) SET @arrearstitle = @phasetitle
				ELSE SET @lastphasedescription = @phasetitle
				SELECT @competency_total = 0
				SELECT @competencyvar_total = 0
				SELECT @competency_total = ISNULL(amount, 0)
					FROM #tot_mov_c
					WHERE nphase = @nphase
				SELECT @competencyvar_total = ISNULL(amount, 0)
					FROM #tot_var_c
					WHERE nphase = @nphase
-- Se la fase corrispondente all'accertamento o impegno non coincide con la prima fase di entrata o spesa in cui è imputata
-- la voce di bilancio prendere in considerazione anche la previsione disponibile calcolata su questa fase 
-- M. Smaldino
				IF (@nphase = @finphase and @finphase < @competencyphase )
				    BEGIN
					SELECT @lbl_dispprimafase = '   Disponibilità  per ulteriore ' + '"' + @phasetitle + '"'
					INSERT INTO #situation VALUES(@lbl_dispprimafase,
						ISNULL(@currmainprev, 0) -
						ISNULL(@competency_total, 0) -
						ISNULL(@competencyvar_total, 0)
						, 'S')
				    END
				ELSE
				    BEGIN
					INSERT INTO #situation	VALUES('1) Movimenti competenza ('
					+ @phasetitle	+ ')', @competency_total, '')
					INSERT INTO #situation	VALUES('2) Variazioni competenza ('
					+ @phasetitle	+ ')', @competencyvar_total, '')
					INSERT INTO #situation VALUES('3) Totale movimenti competenza ('
					+ @phasetitle	+ ')',
					ISNULL(@competency_total,0) +
					ISNULL(@competencyvar_total,0),'')
					SELECT @lbl_dispacc = 'Disponibilità  per ' + '"' + @phasetitle + '"' + ' (Prev. Attuale - 3'
						IF (@nphase = @arrearsphase) -- Informazioni inerenti gli accertamenti
							BEGIN
								SELECT @lbl_dispacc = @lbl_dispacc + ')'
								INSERT INTO #situation	VALUES(@lbl_dispacc, 
								ISNULL(@currmainprev, 0) -
								ISNULL(@competency_total, 0) -
								ISNULL(@competencyvar_total, 0)
								, 'S')
							END
						ELSE IF (@nphase = @lastphase) -- Informazioni inerenti gli incassi
							BEGIN
								SET @competencyincome_total = 
								ISNULL((SELECT SUM(amount) FROM #tot_mov_c WHERE nphase = @arrearsphase),0) +
								ISNULL((SELECT SUM(amount) FROM #tot_var_c WHERE nphase = @arrearsphase),0)
								INSERT INTO #situation VALUES('Accertato di competenza da incassare',
								@competencyincome_total -
								ISNULL(@competency_total,0) - ISNULL(@competencyvar_total,0),'S')
							END
				   END
				FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
			END
		DEALLOCATE crsphase
		INSERT INTO #situation	VALUES('Reversali emesse in c/competenza', @totproceedscomp, 'S')
		INSERT INTO #situation VALUES('',NULL,'H')
		-- Gestione in c/residui
		INSERT INTO #situation
		VALUES('R E S I D U I',NULL,'N')
		DECLARE	crsphase INSENSITIVE	CURSOR FOR
			SELECT nphase, description FROM incomephase
			WHERE nphase >= @finphase AND @nphase IN (@competencyphase,@lastphase)
			FOR READ ONLY
		OPEN crsphase
		FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
		WHILE (@@FETCH_STATUS =	0)
			BEGIN
				SELECT @arrears_total =	0
				SELECT @arrearsvar_total = 0
				SELECT @arrears_total =	ISNULL(amount, 0)
					FROM #tot_mov_r
					WHERE nphase = @nphase
				SELECT @arrearsvar_total = ISNULL(amount, 0)
					FROM #tot_var_r
					WHERE nphase = @nphase
				INSERT INTO #situation	VALUES('1) Movimenti residui ('
					+ @phasetitle	+ ')', @arrears_total, '')
				INSERT INTO #situation	VALUES('2) Variazione residui ('
					+ @phasetitle	+ ')', @arrearsvar_total, '')
				IF (@nphase = @arrearsphase) -- Informazioni inerenti gli accertamenti
				BEGIN
				INSERT INTO #situation VALUES('Totale Residui Attivi ('
					+ @phasetitle	+ ')', 
					ISNULL(@arrears_total,0) +
					ISNULL(@arrearsvar_total,0)
					, 'S')
				END
				ELSE IF(@nphase = @lastphase)
				BEGIN
					INSERT INTO #situation VALUES('3) Totale Movimenti residui ('
						+ @phasetitle	+ ')', 
						ISNULL(@arrears_total,0) +
						ISNULL(@arrearsvar_total,0), '')
					SET @revenue_total = 
					ISNULL((SELECT SUM(amount) FROM #tot_mov_r WHERE nphase = @arrearsphase),0) +
					ISNULL((SELECT SUM(amount) FROM #tot_var_r WHERE nphase = @arrearsphase),0)
					INSERT INTO #situation VALUES('Residui Attivi da incassare',
					ISNULL(@revenue_total,0) -
					ISNULL(@totproceedsres,0)
					, 'S')
				END
				FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
			END
		DEALLOCATE crsphase
		DECLARE @totaccinc int
		SET @tot_lastincomephase_C = 
		ISNULL((SELECT SUM(amount) FROM #tot_mov_c WHERE nphase = @lastphase),0) +
		ISNULL((SELECT SUM(amount) FROM #tot_var_c WHERE nphase = @lastphase),0)
		SET @tot_lastincomephase_R = 
		ISNULL((SELECT SUM(amount) FROM #tot_mov_r WHERE nphase = @lastphase),0) +
		ISNULL((SELECT SUM(amount) FROM #tot_var_r WHERE nphase = @lastphase),0)
		SET @totaccinc = 
			ISNULL(@competencyincome_total,0) +
			ISNULL(@revenue_total,0) -
			ISNULL(@totproceeds,0)
		INSERT INTO #situation	VALUES('Reversali emesse in c/residui', @totproceedsres, 'S')
		INSERT INTO #situation VALUES('',NULL,'H')
		INSERT INTO #situation VALUES('R I E P I L O G O  F A S I  F I N A N Z I A R I E',NULL,'N')
		DECLARE	crs_phase1 INSENSITIVE CURSOR FOR
			SELECT nphase, description FROM incomephase
			WHERE nphase >= @finphase
			FOR READ ONLY
		OPEN crs_phase1
		FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
		WHILE (@@FETCH_STATUS =	0)
			BEGIN
				SELECT @competency_total = 0
				SELECT @competencyvar_total = 0
				SELECT @arrears_total =	0
				SELECT @arrearsvar_total = 0
				SELECT @nextphasecomp = 0
				SELECT @nextphaseres = 0
				SELECT @competency_total = ISNULL(amount, 0)
					FROM #tot_mov_c
					WHERE nphase = @nphase
				SELECT @competencyvar_total = ISNULL(amount, 0)
					FROM #tot_var_c
					WHERE nphase = @nphase
				SELECT @arrears_total =	ISNULL(amount, 0)
					FROM #tot_mov_r
					WHERE nphase = @nphase
				SELECT @arrearsvar_total = ISNULL(amount, 0)
					FROM #tot_var_r
					WHERE nphase = @nphase
-- Calcolo della fase successiva per sottrarla a quella attuale
				IF @nphase < @lastphase
				BEGIN
					SELECT @nextphasecomp = ISNULL(amount,0)
						FROM #tot_mov_c
						WHERE nphase = (@nphase + 1)
					SET @nextphasecomp = ISNULL(@nextphasecomp,0) + 
						ISNULL((SELECT ISNULL(amount,0) FROM #tot_var_c WHERE nphase = (@nphase + 1)),0)

					SELECT @nextphaseres = ISNULL(amount,0)
						FROM #tot_mov_r
						WHERE nphase = (@nphase + 1)
					SET @nextphaseres = ISNULL(@nextphaseres,0) +
							ISNULL((SELECT ISNULL(amount,0) FROM #tot_var_r WHERE nphase = (@nphase + 1)),0)
				END
				ELSE
				BEGIN
					SET @nextphasecomp = ISNULL(@totproceedscomp,0)
					SET @nextphaseres = ISNULL(@totproceedsres,0)
				END
				INSERT INTO #situation VALUES('1. Totale Movimenti competenza (' + @phasetitle +')',
					ISNULL(@competency_total,0),'')
				INSERT INTO #situation VALUES('2. Totale Variazioni competenza (' + @phasetitle +')',
					ISNULL(@competencyvar_total,0),'')
				INSERT INTO #situation VALUES('3. Totale Movimenti residui (' + @phasetitle +')',
					ISNULL(@arrears_total,0),'')
				INSERT INTO #situation VALUES('4. Totale Variazioni residui (' + @phasetitle +')',
					ISNULL(@arrearsvar_total,0),'')
				SELECT @lbl_dispcomp_e = 'Previsione Disponibile di Competenza (Prev. Attuale - 1 - 2)'
				INSERT INTO #situation VALUES(@lbl_dispcomp_e,
					ISNULL(@currmainprev,0) -
					ISNULL(@competency_total,0) -
					ISNULL(@competencyvar_total,0)
					,'S')
				INSERT INTO #situation VALUES('('+@phasetitle+') restanti rispetto alla fase successiva in c/competenza',
					ISNULL(@competency_total,0) + 
					ISNULL(@competencyvar_total,0) -
					ISNULL(@nextphasecomp,0),'S')
				INSERT INTO #situation VALUES('('+@phasetitle+') restanti rispetto alla fase successiva in c/residui',
					ISNULL(@arrears_total,0) + 
					ISNULL(@arrearsvar_total,0) -
					ISNULL(@nextphaseres,0),'S')
				FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
			END
		DEALLOCATE crs_phase1
	INSERT INTO #situation	VALUES('Totale Reversali in c/competenza', ISNULL(@totproceedscomp,0), '')	
	INSERT INTO #situation VALUES('Totale Reversali in c/residui', ISNULL(@totproceedsres,0),'')
	INSERT INTO #situation	VALUES('Totale Reversali', ISNULL(@totproceeds,0), 'S')
	END
ELSE -- fase spesa
	BEGIN
		DECLARE	crsphase INSENSITIVE	CURSOR FOR
			SELECT nphase, description FROM expensephase
			WHERE nphase >= @finphase AND nphase IN (@finphase,@competencyphase,@lastphase) --M. Smaldino
			FOR READ ONLY
		OPEN crsphase
		FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
		print @nphase
		print @phasetitle
		WHILE (@@FETCH_STATUS =	0)
			BEGIN
				IF (@nphase = @arrearsphase) SET @arrearstitle = @phasetitle
				ELSE SET @lastphasedescription = @phasetitle
				SELECT @competency_total = 0
				SELECT @competencyvar_total = 0
				SELECT @competency_total = ISNULL(amount, 0)
					FROM #tot_mov_c
					WHERE nphase = @nphase
				SELECT @competencyvar_total = ISNULL(amount, 0)
					FROM #tot_var_c
					WHERE nphase = @nphase
-- Se la fase corrispondente all'accertamento o impegno non coincide con la prima fase di entrata o spesa in cui è imputata
-- la voce di bilancio occorre prendere in considerazione la previsione disponibile calcolata su questa fase 
-- M. Smaldino
				IF (@nphase = @finphase and @finphase < @competencyphase )
				    BEGIN
					SELECT @lbl_dispprimafase = '  Disponibilità  per ulteriore ' + '"' + @phasetitle + '"'
					INSERT INTO #situation VALUES(@lbl_dispprimafase,
						ISNULL(@currmainprev, 0) -
						ISNULL(@competency_total,0) -
						ISNULL(@competencyvar_total,0) -
						ISNULL(@totpettycashop,0)
						,'S')
				    END
				ELSE
					BEGIN
						INSERT INTO #situation	VALUES('1) Movimenti competenza ('
						+ @phasetitle	+ ')', @competency_total, '')
						INSERT INTO #situation	VALUES('2) Variazioni competenza ('
						+ @phasetitle	+ ')', @competencyvar_total, '')
						INSERT INTO #situation VALUES('3) Totale movimenti competenza ('
						+ @phasetitle	+ ')', 
						ISNULL(@competency_total,0) +
						ISNULL(@competencyvar_total,0), '')
						SELECT @lbl_dispimp = 'Disponibilità  per ' + '"' + @phasetitle + '"' + ' (Prev. Attuale - 3'
						IF @totpettycashop > 0
							BEGIN
								INSERT INTO #situation	VALUES(
								'4) Totale op. fondo economale attribuite non reintegrate',
								@totpettycashop, '')
								SELECT @lbl_dispimp = @lbl_dispimp + ' - 4'
							END
						IF (@nphase = @competencyphase)
							BEGIN
								SELECT @lbl_dispimp = @lbl_dispimp + ')'
								INSERT INTO #situation VALUES(@lbl_dispimp,
								ISNULL(@currmainprev, 0) -
								ISNULL(@competency_total,0) -
								ISNULL(@competencyvar_total,0) -
								ISNULL(@totpettycashop,0)
								,'S')
								IF ( (@assured <> 'S') and ('S'= (SELECT ISNULL(flagcredit,'N') FROM config WHERE ayear = @ayear)) )
								BEGIN
									INSERT INTO #situation VALUES('Crediti Residui',
									ISNULL(@totcreditsurplus,0) +
									ISNULL(@tot_creditpart,0) +
									ISNULL(@totcreditvar,0) -
									ISNULL(@competency_total,0) -
									ISNULL(@competencyvar_total,0)-
                                					ISNULL(@totpettycashop,0),'S')
								END
							END
						IF (@nphase = @lastphase)
							BEGIN
								SET @totcompexpense = 
								ISNULL((SELECT SUM(amount) FROM #tot_mov_c WHERE nphase = @arrearsphase),0) +
								ISNULL((SELECT SUM(amount) FROM #tot_var_c WHERE nphase = @arrearsphase),0)
								INSERT INTO #situation VALUES('Impegnato di competenza da pagare',
								ISNULL(@totcompexpense,0) -
								ISNULL(@competency_total,0) - ISNULL(@competencyvar_total,0),'S')
							END
					END
			  	 FETCH NEXT FROM crsphase INTO @nphase, @phasetitle
			END
		DEALLOCATE crsphase
		INSERT INTO #situation	VALUES('Mandati emessi in c/competenza', @totpaymentcomp, 'S')
		INSERT INTO #situation VALUES('',NULL,'H')
		-- Gestione in c/residui
		INSERT INTO #situation
		VALUES('R E S I D U I',NULL,'N')
		DECLARE	crsphase INSENSITIVE	CURSOR FOR
			SELECT nphase, description FROM expensephase
			WHERE nphase >= @finphase AND nphase IN (@competencyphase,@lastphase)
			FOR READ ONLY
		OPEN crsphase
		FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
		WHILE (@@FETCH_STATUS =	0)
			BEGIN		
				SELECT @arrears_total =	0
				SELECT @arrearsvar_total = 0	
				SELECT @arrears_total =	ISNULL(amount, 0)
					FROM #tot_mov_r
					WHERE nphase = @nphase
				SELECT @arrearsvar_total = ISNULL(amount, 0)
					FROM #tot_var_r
					WHERE nphase = @nphase		
				INSERT INTO #situation	VALUES('1) Movimenti residui ('
					+ @phasetitle + ')', @arrears_total, '')
				INSERT INTO #situation	VALUES('2) Variazioni residui ('
					+ @phasetitle + ')', @arrearsvar_total, '')
				IF (@nphase = @arrearsphase)
				BEGIN
					INSERT INTO #situation VALUES('Totale Residui Passivi ('
						+ @phasetitle + ')', 
						ISNULL(@arrears_total,0) +
						ISNULL(@arrearsvar_total,0), 'S')
				END
				ELSE IF(@nphase = @lastphase)
				BEGIN
					INSERT INTO #situation VALUES('3) Totale Movimenti residui ('
						+ @phasetitle	+ ')', 
						ISNULL(@arrears_total,0) +
						ISNULL(@arrearsvar_total,0), '')
					SET @tot_appropriation_R = 
					ISNULL((SELECT SUM(amount) FROM #tot_mov_r WHERE nphase = @arrearsphase),0) +
					ISNULL((SELECT SUM(amount) FROM #tot_var_r WHERE nphase = @arrearsphase),0)
					INSERT INTO #situation VALUES('Residui Passivi da pagare',
					ISNULL(@tot_appropriation_R,0) -
					ISNULL(@totpaymentres,0)
					, 'S')
					INSERT INTO #situation	VALUES('Mandati emessi in c/residui', @totpaymentres, 'S')
					INSERT INTO #situation VALUES('',NULL,'H')
				END
				FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
			END
		DEALLOCATE crsphase
		DECLARE @totimppag int
		SET @tot_lastexpensephase_R = 
			ISNULL((SELECT SUM(amount) FROM #tot_mov_r WHERE nphase = @lastphase),0) +
			ISNULL((SELECT SUM(amount) FROM #tot_var_r WHERE nphase = @lastphase),0)
		SET @tot_lastexpensephase_C = 
			ISNULL((SELECT SUM(amount) FROM #tot_mov_c WHERE nphase = @lastphase),0) +
			ISNULL((SELECT SUM(amount) FROM #tot_var_c WHERE nphase = @lastphase),0)
		SET @totimppag = 
			ISNULL(@totcompexpense,0) +
			ISNULL(@tot_appropriation_R,0) -
			ISNULL(@tot_lastexpensephase_C,0) -
			ISNULL(@tot_lastexpensephase_R,0)
		IF (( @assured <> 'S') and ('S'= (SELECT ISNULL(flagproceeds,'N') FROM config WHERE ayear = @ayear)) )
		Begin
			INSERT INTO #situation	VALUES('Cassa Residua', 
			ISNULL(@totproceedspart,	0) + 
			ISNULL(@totcashsurplus, 0) +
			ISNULL(@totproceedsvar,	0) - 
			ISNULL(@totpayment, 0) -
			ISNULL(@totpettycashop,	0),'S')
		End
		INSERT INTO #situation VALUES('',NULL,'H')
		INSERT INTO #situation VALUES('R I E P I L O G O  F A S I  F I N A N Z I A R I E',NULL,'N')
		DECLARE	crsphase INSENSITIVE	CURSOR FOR
			SELECT nphase, description FROM expensephase
			WHERE nphase >= @finphase
			FOR READ ONLY
		OPEN crsphase
		FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
		WHILE (@@FETCH_STATUS =	0)
			BEGIN
				SELECT @competency_total = 0
				SELECT @competencyvar_total = 0
				SELECT @arrears_total =	0
				SELECT @arrearsvar_total = 0
				SELECT @nextphasecomp = 0
				SELECT @nextphaseres = 0
				SELECT @competency_total = ISNULL(amount, 0)
					FROM #tot_mov_c
					WHERE nphase = @nphase
				SELECT @competencyvar_total = ISNULL(amount, 0)
					FROM #tot_var_c
					WHERE nphase = @nphase
				SELECT @arrears_total =	ISNULL(amount, 0)
					FROM #tot_mov_r
					WHERE nphase = @nphase
				SELECT @arrearsvar_total = ISNULL(amount, 0)
					FROM #tot_var_r
					WHERE nphase = @nphase
-- Calcolo della fase successiva per sottrarla a quella attuale
				IF @nphase < @lastphase
				BEGIN
					SELECT @nextphasecomp = ISNULL(amount,0)
						FROM #tot_mov_c
						WHERE nphase = (@nphase + 1)
					SET @nextphasecomp = ISNULL(@nextphasecomp,0) + 
						ISNULL((SELECT ISNULL(amount,0) FROM #tot_var_c WHERE nphase = (@nphase + 1)),0)

					SELECT @nextphaseres = ISNULL(amount,0)
						FROM #tot_mov_r
						WHERE nphase = (@nphase + 1)
					SET @nextphaseres = ISNULL(@nextphaseres,0) +
							ISNULL((SELECT ISNULL(amount,0) FROM #tot_var_r WHERE nphase = (@nphase + 1)),0)
				END
				ELSE
				BEGIN
					SET @nextphasecomp = ISNULL(@totpaymentcomp,0)
					SET @nextphaseres = ISNULL(@totpaymentres,0)
				END
				INSERT INTO #situation VALUES('1. Totale Movimenti competenza (' + @phasetitle +')',
					ISNULL(@competency_total,0),'')
				INSERT INTO #situation VALUES('2. Totale Variazioni competenza (' + @phasetitle +')',
					ISNULL(@competencyvar_total,0),'')
				INSERT INTO #situation VALUES('3. Totale Movimenti residui (' + @phasetitle +')',
					ISNULL(@arrears_total,0),'')
				INSERT INTO #situation VALUES('4. Totale Variazioni residui (' + @phasetitle +')',
					ISNULL(@arrearsvar_total,0),'')
				SELECT @lbl_dispcomp_s = 'Previsione Disponibile di Competenza (Prev. Attuale - 1 - 2'
				IF (@totpettycashop > 0)
				BEGIN
					INSERT INTO #situation VALUES('5. Totale Op. Fondo Economale',ISNULL(@totpettycashop,0),'')
					SELECT @lbl_dispcomp_s = @lbl_dispcomp_s + ' - 5'
				END
					SELECT @lbl_dispcomp_s = @lbl_dispcomp_s + ')'
				INSERT INTO #situation VALUES(@lbl_dispcomp_s,
					ISNULL(@currmainprev,0) -
					ISNULL(@competency_total,0) -
					ISNULL(@competencyvar_total,0) -
					ISNULL(@totpettycashop,0)
					,'S')
				INSERT INTO #situation VALUES('('+@phasetitle+') restanti rispetto alla fase successiva in c/competenza',
					ISNULL(@competency_total,0) + 
					ISNULL(@competencyvar_total,0) -
					ISNULL(@nextphasecomp,0),'S')
				INSERT INTO #situation VALUES('('+@phasetitle+') restanti rispetto alla fase successiva in c/residui',
					ISNULL(@arrears_total,0) + 
					ISNULL(@arrearsvar_total,0) -
					ISNULL(@nextphaseres,0),'S')
				FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
			END
		DEALLOCATE crsphase
		INSERT INTO #situation	VALUES('Totale Mandati in c/competenza', ISNULL(@totpaymentcomp,0), '')	
		INSERT INTO #situation VALUES('Totale Mandati in c/residui', ISNULL(@totpaymentres,0),'')
		INSERT INTO #situation VALUES('Totale Mandati', ISNULL(@totpayment,0),'S')
	END
SELECT value, amount, kind FROM #situation
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

