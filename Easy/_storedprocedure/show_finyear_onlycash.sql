
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_finyear_onlycash]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_finyear_onlycash]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE          PROCEDURE [show_finyear_onlycash]
	@date  datetime,
	@idupb varchar(36),
	@idfin int,
	@finpart char(1)
AS BEGIN
/* Versione 1.0.1 del 27/11/2007 ultima modifica*/
	DECLARE	@ayear int -- Esercizio
	SELECT @ayear = YEAR(@date)

	DECLARE @lbl_dispacc varchar(150) -- Etichetta sulla disponibilità ad accertate
	DECLARE @lbl_dispcash_e varchar(150) -- Etichetta sulla prev. disponibile di cassa
	DECLARE @lbl_dispimp varchar(150) -- Etichetta sulla disponibilità ad impegnare che varia in base alla presenza delle operazioni del fondo economale
	DECLARE @lbl_dispcash_s varchar(150) -- Etichetta sulla prev. disponibile di cassa che varia in base alla presenza delle operazioni del fondo economale
	DECLARE @lbl_disp_firstphase varchar(150) -- Etichetta sulla disponibilità calcolata sulla prima fase di entrata

	DECLARE	@mainprev_var_AUM decimal(19,2) -- Totale delle variazioni di previsione principale in aumento
	DECLARE	@mainprev_var_DIM decimal(19,2) -- Totale delle variazioni di previsione principale in diminuzione

-- Variabili utilizzate nella sezione RIEPILOGO FASI FINANZIARIE
	DECLARE @nextphasecomp decimal(19,2) -- Calcolo della fase successiva in c/competenza
	DECLARE @nextphaseres decimal(19,2) -- Calcolo della fase successiva in c/residui

-- Tabella della situazione della voce di bilancio
	CREATE TABLE #situation (value varchar(200), amount decimal(19,2), kind char(1))
-- Tabella dei movimenti di competenza
	CREATE TABLE #tot_mov_c	(nphase tinyint, amount decimal(19,2))

-- Tabella delle variazioni sui movimenti di competenza
	CREATE TABLE #tot_var_c	(nphase tinyint, amount decimal(19,2))

	
	 
	DECLARE @floatfund decimal(19,2) -- Avanzo di Cassa
	DECLARE	@departmentname varchar(150) -- Nome del Dipartimento
	SELECT @floatfund = ISNULL(floatfund,0) FROM finsurplusview WHERE ayear = @ayear

	SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')


DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

	DECLARE	@levelusable tinyint  -- Livello operativo per le voci di bilancio
	DECLARE	@arrearsphase int


	SELECT @arrearsphase = 1
	SELECT @levelusable = MIN(nlevel) FROM finlevel
		WHERE (flag & 2)<>0 and  ayear = @ayear

	DECLARE	@fincode varchar(50) -- Codice di bilancio
	DECLARE	@fintitle varchar(150) -- Descrizione della voce di bilancio
	DECLARE	@nlevel tinyint -- Livello della voce di bilancio
	SELECT @nlevel = nlevel, @fincode = codefin, @fintitle = title FROM fin WHERE idfin = @idfin

	DECLARE	@leveldesc varchar(50)
	SELECT @leveldesc = description FROM finlevel WHERE ayear = @ayear AND @nlevel = nlevel

	DECLARE	@finphase tinyint  -- Fase in cui viene inserita la voce di bilancio
	DECLARE	@lastphase tinyint  -- Fase di cassa

	DECLARE @competencyphase tinyint   -- Fase paragonabile all'accertamento o all'impegno

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
			SELECT @finphase = expensefinphase from uniconfig
			SELECT @lastphase = MAX(nphase) FROM expensephase

		END

	DECLARE @descupb varchar(150)
	DECLARE @codeupb varchar(50)
	SELECT @descupb = title,
	@codeupb = codeupb
	FROM upb
	WHERE idupb = @idupb

	DECLARE	@mainprev decimal(19,2) -- Previsione Principale

	IF @nlevel < @levelusable OR @nlevel IS NULL
		BEGIN
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
			--AND nlevel = @levelusable
			--AND idupb = @idupb
		END
	ELSE
		BEGIN
		SELECT @mainprev = prevision
			FROM finyear
			WHERE idfin = @idfin
			AND idupb = @idupb
		END		


	SELECT @mainprev_var_AUM = SUM(finvardetail.amount)
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN finlink 
		ON finlink.idchild = finvardetail.idfin
	join fin 
		ON finvardetail.idfin = fin.idfin
	WHERE 	(	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND finvar.adate <=	@date
		AND finvar.flagprevision = 'S'
		AND finvar.idfinvarstatus = 5
		AND finvar.variationkind <> 5 
		and ((fin.flag & 1 ) = @finpart_bit) and fin.ayear = @ayear
		AND idupb = @idupb
		AND amount > 0

	SELECT @mainprev_var_DIM = SUM(finvardetail.amount)
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN finlink 
		ON finlink.idchild = finvardetail.idfin
	join fin 
		ON finvardetail.idfin = fin.idfin
	WHERE 	(	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
		AND finvar.adate <= @date
		AND finvar.idfinvarstatus = 5
		AND finvar.variationkind <> 5 
		and fin.ayear = @ayear
		and ((fin.flag & 1 ) = @finpart_bit) and fin.ayear = @ayear
		AND finvar.flagprevision = 'S'
		AND idupb = @idupb
		AND amount < 0

	DECLARE @currmainprev decimal(19,2) -- Previsione Attuale Principale
	DECLARE @tot_mainprev_var decimal(19,2) -- Totale delle variazioni di previsione principale

-- Calcolo delle variazioni totali sulla previsione principale date dalla somma algebrica di quelle in aumento e quelle in diminuzione
	SET @tot_mainprev_var = ISNULL(@mainprev_var_AUM,0) + ISNULL(@mainprev_var_DIM,0)
-- Calcolo della previsione principale attuale
	SET @currmainprev = ISNULL(@mainprev,0) + ISNULL(@tot_mainprev_var,0)

	DECLARE @totpayment decimal(19,2) -- Totale Mandati (secondo la configurazione di bilancio)
	DECLARE @totproceeds decimal(19,2) -- Totale Reversali (secondo la configurazione di bilancio)

	IF @finpart = 'E'
		BEGIN
			INSERT INTO #tot_mov_c
			SELECT I.nphase, 
				SUM(IY.amount) --incometotal
			FROM incomeyear IY
			/*JOIN incometotal
				ON incometotal.idinc = incomeyear.idinc
				AND incometotal.ayear = incomeyear.ayear*/
			JOIN income I
				ON I.idinc = IY.idinc
			JOIN finlink FLK
				ON FLK.idchild = IY.idfin
			WHERE (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
				AND IY.ayear = @ayear
				AND IY.idupb = @idupb
				AND I.nphase >= @finphase
				AND I.adate <= @date
			GROUP BY I.nphase

			INSERT INTO #tot_var_c
			SELECT income.nphase, 
				SUM(incomevar.amount)
			FROM incomevar
			JOIN incomeyear
				ON incomeyear.idinc = incomevar.idinc
			JOIN income 
				ON income.idinc = incomeyear.idinc
			JOIN finlink FLK
				ON FLK.idchild = incomeyear.idfin
			WHERE incomevar.yvar = @ayear
				AND incomevar.adate <= @date
				AND incomeyear.idupb = @idupb
				and (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
				AND incomeyear.ayear = @ayear
				AND income.nphase >= @finphase
			GROUP BY income.nphase

			SET @totproceeds = 
			ISNULL(
				(SELECT SUM(curramount)
				FROM historyproceedsview HPV
				JOIN finlink FLK
					ON FLK.idchild = HPV.idfin
				WHERE HPV.ymov = @ayear
					and (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
					AND idupb = @idupb
					AND competencydate <= @date)
			,0)
		END
	ELSE
-- --------------> Parte spese
		BEGIN
			DECLARE @assured char(1)
			SELECT @assured = assured FROM upb WHERE idupb = @idupb

			INSERT INTO #tot_mov_c
			SELECT expense.nphase, 
				SUM(expenseyear.amount)
			FROM expenseyear
			JOIN expense
				ON expense.idexp = expenseyear.idexp
			JOIN finlink 
				ON finlink.idchild = expenseyear.idfin
			WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
				AND expenseyear.ayear = @ayear
				AND expenseyear.idupb = @idupb
				AND expense.adate <= @date
				AND expense.nphase >= @finphase
			GROUP BY expense.nphase

			INSERT INTO #tot_var_c
			SELECT expense.nphase, 
				SUM(expensevar.amount)
			FROM expensevar
			JOIN expenseyear
				ON expenseyear.idexp = expensevar.idexp
			JOIN expense
				ON expense.idexp = expenseyear.idexp
			JOIN finlink 
				ON finlink.idchild = expenseyear.idfin
			WHERE expensevar.yvar =	@ayear
				AND expenseyear.idupb = @idupb
				AND expensevar.adate <= @date
				and (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
				AND expenseyear.ayear = @ayear
				AND expense.nphase >= @finphase
			GROUP BY expense.nphase


	DECLARE	@tot_creditpart decimal(19,2) -- Totale assegnazione dei crediti
	DECLARE	@totcreditvar decimal(19,2) -- Totale variazione assegnazione dei crediti
	DECLARE	@totproceedspart decimal(19,2) -- Totale assegnazioni di cassa
	DECLARE	@totproceedsvar decimal(19,2) -- Totale variazioni assegnazioni di cassa
	DECLARE @totcashsurplus decimal(19,2) -- Totale ripartizione dell'avanzo di cassa

			IF (@assured <> 'S')
			BEGIN
				SELECT @tot_creditpart = SUM(creditpart.amount)
				FROM creditpart
				JOIN finlink 
					ON finlink.idchild = creditpart.idfin
				join fin 
					on creditpart.idfin = fin.idfin
				WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
					AND creditpart.adate <= @date
					AND creditpart.idupb = @idupb
					AND ( (fin.flag & 1)=1)--solo per le spese
					AND fin.ayear = @ayear
					AND creditpart.ycreditpart = @ayear

				SELECT @totcreditvar = SUM(D.amount)
				FROM finvardetail D
				JOIN finvar V
					ON V.yvar = D.yvar
					AND V.nvar = D.nvar
				JOIN finlink FLK
					ON FLK.idchild = D.idfin
				join fin F
					on D.idfin = F.idfin
				WHERE (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
					AND V.adate <= @date
					AND V.idfinvarstatus = 5
					AND V.variationkind <> 5 
					AND V.flagcredit = 'S'
					AND D.idupb = @idupb
					AND ( (F.flag & 1)=1)--solo per le spese
					AND F.ayear = @ayear

				SELECT @totproceedspart = SUM(proceedspart.amount)
				FROM proceedspart
				JOIN finlink 
					ON finlink.idchild = proceedspart.idfin
				join fin 
					on proceedspart.idfin = fin.idfin
				WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
					AND ( (fin.flag & 1)=1)--solo per le spese
					AND fin.ayear = @ayear
					AND proceedspart.adate <= @date
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
					(	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
					AND V.adate <= @date
					AND V.idfinvarstatus = 5
					AND V.flagproceeds = 'S'
					AND V.variationkind IN (2,3)
					AND D.idupb = @idupb
					AND ( (F.flag & 1)=1)--solo per le spese
					AND F.ayear = @ayear

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
					(	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
					AND ( (F.flag & 1)=1)--solo per le spese
					AND F.ayear = @ayear
					AND V.idfinvarstatus = 5
					AND V.adate <= @date
					AND V.flagproceeds = 'S'
					AND V.variationkind IN (1,4)
					AND D.idupb = @idupb
			END
			ELSE
			BEGIN
				SET @tot_creditpart = 0
				SET @totcreditvar = 0
				SET @totproceedspart = 0
				SET @totcashsurplus = 0
				SET @totproceedsvar = 0
			END

			SET @totpayment = 
			ISNULL(
				(SELECT SUM(HPV.curramount)
				FROM historypaymentview HPV
				JOIN finlink FLK
					ON FLK.idchild = HPV.idfin
				WHERE HPV.ymov = @ayear
					and (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
					AND HPV.idupb = @idupb
					AND competencydate <= @date)
			,0)
		END

	DECLARE	@totpettycashop decimal(19,2) -- Totale operazioni fondo economale

	SELECT @totpettycashop = SUM(operation.amount)
		FROM pettycashoperation operation
		JOIN finlink FLK
			ON FLK.idchild = operation.idfin 
		join fin F
			on operation.idfin = F.idfin
		WHERE (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
			AND operation.idupb = @idupb
			AND operation.adate	<= @date
			AND F.ayear = @ayear
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
	INSERT INTO #situation VALUES('C A S S A',NULL,'N')

	DECLARE	@totcompetency decimal(19,2)
	DECLARE	@totcompetencyvar decimal(19,2)
	DECLARE	@totarrears decimal(19,2)
	DECLARE	@totarrearsvar decimal(19,2)
	DECLARE	@nphase tinyint
	DECLARE	@phasetitle varchar(50)
	DECLARE @totincome decimal(19,2)
	DECLARE @totexpense decimal(19,2)

-----------------------
-- GESTIONE DI CASSA --
-----------------------
	INSERT INTO #situation	
		VALUES ('Previsione iniziale di cassa', @mainprev, '')
	INSERT INTO #situation	
		VALUES ('Variazioni di bilancio e Storni di previsione', @tot_mainprev_var, '')
	INSERT INTO #situation	
		VALUES ('Previsione attuale di cassa', ISNULL(@currmainprev, 0), 'S')
	IF @finpart = 'S' AND 
			(EXISTS	(SELECT	* FROM creditpart 
			WHERE ycreditpart = @ayear
			AND adate <= @date) OR
			EXISTS (SELECT * FROM finvar
			WHERE yvar = @ayear
			AND flagcredit = 'S'
			AND variationkind <> 5 
			AND adate <= @date
			AND idfinvarstatus = 5))
			AND @assured <> 'S'
		BEGIN
			INSERT INTO #situation	VALUES ('Assegnazione crediti',	@tot_creditpart, '')
			INSERT INTO #situation	VALUES ('Variazioni e Storni di Crediti', @totcreditvar, '')
			INSERT INTO #situation	VALUES ('Previsione da accreditare', 
				ISNULL(@currmainprev, 0) - 
				ISNULL(@tot_creditpart, 0) - 
				ISNULL(@totcreditvar, 0),	'S')
		END
	IF @finpart = 'S' AND 
			(EXISTS	(SELECT	* FROM proceedspart
			WHERE yproceedspart	= @ayear
			AND adate <= @date) OR
			EXISTS (SELECT * FROM finvar
			WHERE yvar = @ayear
			AND flagproceeds = 'S'
			AND variationkind <> 5 
			AND adate <= @date
			AND idfinvarstatus = 5))
			AND @assured <> 'S'
		BEGIN
			INSERT INTO #situation VALUES ('Avanzo di cassa',@totcashsurplus,'')
			INSERT INTO #situation	VALUES ('Assegnazione incassi',	@totproceedspart, '')
			INSERT INTO #situation	VALUES ('Variazioni e Storni di Incassi', @totproceedsvar, '')
			INSERT INTO #situation	VALUES ('Previsione da incassare', 
				ISNULL(@currmainprev, 0) -
				ISNULL(@totcashsurplus,0) -
				ISNULL(@totproceedspart,	0) -
				ISNULL(@totproceedsvar,	0), 'S')
		END
	
	IF @finpart = 'E'
		BEGIN
			DECLARE	crs_phase1 INSENSITIVE CURSOR FOR
				SELECT nphase, description FROM incomephase
				WHERE nphase >= @finphase AND nphase IN (@finphase,@competencyphase,@lastphase) --M. Smaldino
				FOR READ ONLY
			OPEN crs_phase1
			FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
			WHILE (@@FETCH_STATUS =	0)
				BEGIN
					SELECT @totcompetency = 0
					SELECT @totcompetencyvar = 0
					SELECT @totcompetency = ISNULL(amount, 0)
						FROM #tot_mov_c
						WHERE nphase = @nphase
					SELECT @totcompetencyvar = ISNULL(amount, 0)
						FROM #tot_var_c
						WHERE nphase = @nphase
---------------------------------------------------------------------------------------------------------------------------------------------
-- Se la fase corrispondente all'accertamento o impegno non coincide con la prima fase di entrata o spesa in cui è imputata
-- la voce di bilancio  prendere in considerazione anche la previsione disponibile calcolata su questa fase 
---------------------------------------------------------------------------------------------------------------------------------------------
					IF (@nphase = @finphase and @finphase < @competencyphase )
					    BEGIN
						SELECT @lbl_disp_firstphase = '   Disponibilità per ulteriore ' + '"' + @phasetitle + '"'
						INSERT INTO #situation VALUES(@lbl_disp_firstphase,
							ISNULL(@currmainprev, 0) -
							ISNULL(@totcompetency, 0) -
							ISNULL(@totcompetencyvar, 0), 'S')
					    END
					ELSE
					    BEGIN
						INSERT INTO #situation VALUES('1) Movimenti ('
						+ @phasetitle	+ ')', ISNULL(@totcompetency,0), '')
						INSERT INTO #situation VALUES('2) Variazioni movimenti ('
						+ @phasetitle	+ ')', ISNULL(@totcompetencyvar,0), '')
						INSERT INTO #situation VALUES('3) Totale Movimenti ('
						+@phasetitle	+ ')',
						ISNULL(@totcompetency,0) +
						ISNULL(@totcompetencyvar,0),'')
						SELECT @lbl_dispacc = 'Disponibilità per ' + '"' + @phasetitle + '"' + ' (Prev. Attuale - 3';
				  		
						IF (@nphase = @competencyphase)
							BEGIN
								SELECT @lbl_dispacc = @lbl_dispacc + ')'
								INSERT INTO #situation	VALUES(@lbl_dispacc, 
								ISNULL(@currmainprev, 0) -
								ISNULL(@totcompetency, 0) -
								ISNULL(@totcompetencyvar, 0), 'S')
							END
						IF (@nphase = @lastphase)
							BEGIN
								SET @totincome = 
								ISNULL((SELECT SUM(amount) FROM #tot_mov_c WHERE nphase = @competencyphase),0) +
								ISNULL((SELECT SUM(amount) FROM #tot_var_c WHERE nphase = @competencyphase),0)
								INSERT INTO #situation VALUES('Accertato da incassare',
								ISNULL(@totincome,0) -
								ISNULL(@totcompetency,0) -
								ISNULL(@totcompetencyvar,0),'S')
								INSERT INTO #situation	VALUES('Disponibilità ad incassare (Reversali)', 
								ISNULL(@currmainprev, 0) -
								ISNULL(@totcompetency, 0) -
								ISNULL(@totcompetencyvar, 0), 'S')
							END
						END
					FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
				END
			DEALLOCATE crs_phase1
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
					SELECT @totcompetency = 0
					SELECT @totcompetencyvar = 0
					SELECT @nextphasecomp = 0
					SELECT @totcompetency = ISNULL(amount, 0)
						FROM #tot_mov_c
						WHERE nphase = @nphase
					SELECT @totcompetencyvar = ISNULL(amount, 0)
						FROM #tot_var_c
						WHERE nphase = @nphase
-- Calcolo della fase successiva per sottrarla a quella attuale
					IF @nphase < @lastphase
					BEGIN
						SELECT @nextphasecomp = ISNULL(amount, 0)
							FROM #tot_mov_c
							WHERE nphase = (@nphase + 1)
						SET @nextphasecomp = ISNULL(@nextphasecomp, 0) + 
							ISNULL((SELECT ISNULL(amount, 0) FROM #tot_var_c WHERE nphase = (@nphase + 1)),0)
					END
					ELSE
					BEGIN
						SET @nextphasecomp = ISNULL(@totproceeds,0)
					END
					INSERT INTO #situation VALUES('1. Totale Movimenti (' + @phasetitle +')',
						ISNULL(@totcompetency,0),'')
					INSERT INTO #situation VALUES('2. Totale Variazioni (' + @phasetitle +')',
						ISNULL(@totcompetencyvar,0),'')
					SELECT @lbl_dispcash_e = 'Previsione Disponibile di Cassa (Prev Attuale - 1 - 2)'
					
					INSERT INTO #situation VALUES(@lbl_dispcash_e,
						ISNULL(@currmainprev,0) -
						ISNULL(@totcompetency,0) -
						ISNULL(@totcompetencyvar,0)
						,'S')
					INSERT INTO #situation VALUES('('+@phasetitle+') restanti rispetto alla fase successiva in c/competenza',
						ISNULL(@totcompetency,0) + 
						ISNULL(@totcompetencyvar,0) -
						ISNULL(@nextphasecomp,0),'S')
					FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
				END
			DEALLOCATE crs_phase1
		INSERT INTO #situation	VALUES('Totale Reversali', ISNULL(@totproceeds,0), 'S')
		 END
	ELSE 
-- -------> Gestione spese CASSA
		BEGIN
			DECLARE	crs_phase1 INSENSITIVE CURSOR FOR
				SELECT nphase, description FROM expensephase
				WHERE nphase >= @finphase AND nphase IN (@finphase,@competencyphase,@lastphase)
				FOR READ ONLY
			OPEN crs_phase1
			FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
			WHILE (@@FETCH_STATUS =	0)
				BEGIN
					SELECT @totcompetency = 0
					SELECT @totcompetencyvar = 0
					SELECT @totcompetency = 0
					SELECT @totcompetency = ISNULL(amount, 0)
						FROM #tot_mov_c
						WHERE nphase = @nphase
					SELECT @totcompetencyvar = ISNULL(amount, 0)
						FROM #tot_var_c
						WHERE nphase = @nphase
---------------------------------------------------------------------------------------------------------------------------------------------
-- Se la fase corrispondente all'accertamento o impegno non coincide con la prima fase di entrata o spesa in cui è imputata
-- la voce di bilancio occorre prendere in considerazione la previsione disponibile calcolata su questa fase 
---------------------------------------------------------------------------------------------------------------------------------------------
					IF (@nphase = @finphase and @finphase < @competencyphase )
					    BEGIN
						SELECT @lbl_disp_firstphase = '   Disponibilità per ulteriore ' + '"' + @phasetitle + '"'
						INSERT INTO #situation VALUES(@lbl_disp_firstphase,
							ISNULL(@currmainprev, 0) -
							ISNULL(@totcompetency,0) -
							ISNULL(@totcompetencyvar,0) -
							ISNULL(@totpettycashop,0)
							,'S')
					    END
					ELSE
					    BEGIN
						INSERT INTO #situation VALUES('1) Movimenti ('
						+ @phasetitle	+ ')', ISNULL(@totcompetency,0), '')
						INSERT INTO #situation VALUES('2) Variazioni movimenti ('
						+ @phasetitle	+ ')', ISNULL(@totcompetencyvar,0), '')
						INSERT INTO #situation VALUES('3) Totale Movimenti ('
						+ @phasetitle	+ ')',
						ISNULL(@totcompetency,0) +
						ISNULL(@totcompetencyvar,0),'')
						SELECT @lbl_dispimp = 'Disponibilità per ' + '"' + @phasetitle + '"' +' (Prev. Attuale - 3'
						IF (@totpettycashop > 0)
							BEGIN
								INSERT INTO #situation	VALUES(
								'4) Totale op. fondo economale attribuite non reintegrate',@totpettycashop, '')
								SELECT @lbl_dispimp = @lbl_dispimp + ' - 4'
							END
						IF (@nphase = @competencyphase)
							BEGIN
								SELECT @lbl_dispimp = @lbl_dispimp + ')'
								INSERT INTO #situation VALUES(@lbl_dispimp,
								ISNULL(@currmainprev, 0) -
								ISNULL(@totcompetency,0) -
								ISNULL(@totcompetencyvar,0) -
								ISNULL(@totpettycashop,0)
								,'S')
								----------------------------------------------------------------------------------------------
								-- Visualizzare i crediti residui solo se le assegnazioni dei crediti E le variazioni o storni
								-- di crediti sono entrambi diversi da 0, trattandosi di un bilancio di sola cassa
								----------------------------------------------------------------------------------------------
										IF ( (@assured <> 'S')
                                                                                AND ('S'= (SELECT ISNULL(flagcredit,'N') FROM config WHERE ayear = @ayear)) )
										BEGIN
												INSERT INTO #situation VALUES('Crediti Residui',
												ISNULL(@tot_creditpart,0) +
												ISNULL(@totcreditvar,0) -
												ISNULL(@totcompetency,0) -
												ISNULL(@totcompetencyvar,0)-
                                                                                                ISNULL(@totpettycashop,0),'S')
										END									

							END
						IF (@nphase = @lastphase)
							BEGIN
								SET @totexpense = 
								ISNULL((SELECT SUM(amount) FROM #tot_mov_c WHERE nphase = @competencyphase),0) +
								ISNULL((SELECT SUM(amount) FROM #tot_var_c WHERE nphase = @competencyphase),0)							
								INSERT INTO #situation VALUES('Impegnato da pagare',
								ISNULL(@totexpense,0) -
								ISNULL(@totcompetency,0) -
								ISNULL(@totcompetencyvar,0),'S')
								-----------------------------------------------------------------------------------------
								-- Visualizzare la Cassa residua a livello di impegni
								-----------------------------------------------------------------------------------------
								IF (( @assured <> 'S') and ('S'= (SELECT ISNULL(flagproceeds,'N') FROM config WHERE ayear = @ayear)) )
								Begin
									INSERT INTO #situation	VALUES('Cassa Residua (Impegni)', 
									ISNULL(@totproceedspart,	0) + 
									ISNULL(@totcashsurplus, 0) +
									ISNULL(@totproceedsvar,	0) - 
									ISNULL(@totexpense, 0) -
									ISNULL(@totpettycashop,	0),'S')		
								End	
								-----------------------------------------------------------------------------------------
								INSERT INTO #situation VALUES('Disponibilità a pagare (Mandati)',
								ISNULL(@currmainprev, 0) -
								ISNULL(@totpayment,0) -
								ISNULL(@totpettycashop,0)
								,'S')
								IF (( @assured <> 'S') and ('S'= (SELECT ISNULL(flagproceeds,'N') FROM config WHERE ayear = @ayear)) )
								Begin
									INSERT INTO #situation	VALUES('Cassa Residua (Mandati)', 
									ISNULL(@totproceedspart,	0) + 
									ISNULL(@totcashsurplus, 0) +
									ISNULL(@totproceedsvar,	0) - 
									ISNULL(@totpayment, 0) -
									ISNULL(@totpettycashop,	0),'S')
								End
							END
						END
					FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
				END
			DEALLOCATE crs_phase1
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
					SELECT @totcompetency = 0
					SELECT @totcompetencyvar = 0
					SELECT @totarrears =	0
					SELECT @totarrearsvar = 0
					SELECT @nextphasecomp = 0
					SELECT @totcompetency = ISNULL(amount, 0)
						FROM #tot_mov_c
						WHERE nphase = @nphase
					SELECT @totcompetencyvar = ISNULL(amount, 0)
						FROM #tot_var_c
						WHERE nphase = @nphase
-- Calcolo della fase successiva per sottrarla a quella attuale
					IF @nphase < @lastphase
					BEGIN
						SELECT @nextphasecomp = ISNULL(amount,0)
							FROM #tot_mov_c
							WHERE nphase = (@nphase + 1)
						SET @nextphasecomp = ISNULL(@nextphasecomp,0) + 
							ISNULL((SELECT ISNULL(amount,0) FROM #tot_var_c WHERE nphase = (@nphase + 1)),0)
					END
					ELSE
					BEGIN
						SET @nextphasecomp = ISNULL(@totpayment,0)
					END
					INSERT INTO #situation VALUES('1. Totale Movimenti (' + @phasetitle +')',
						ISNULL(@totcompetency,0),'')
					INSERT INTO #situation VALUES('2. Totale Variazioni (' + @phasetitle +')',
						ISNULL(@totcompetencyvar,0),'')
					SELECT @lbl_dispcash_s = 'Previsione Disponibile di Cassa (Prev. Attuale - 1 - 2'
					IF (@totpettycashop > 0)
					BEGIN
						INSERT INTO #situation VALUES('5. Totale Operazioni Fondo Economale',ISNULL(@totpettycashop,0),'')
						SELECT @lbl_dispcash_s = @lbl_dispcash_s + ' - 5'
					END
					SELECT @lbl_dispcash_s = @lbl_dispcash_s + ')'
					INSERT INTO #situation VALUES(@lbl_dispcash_s,
						ISNULL(@currmainprev,0) -
						ISNULL(@totcompetency,0) -
						ISNULL(@totcompetencyvar,0)
						,'S')
					INSERT INTO #situation VALUES('('+@phasetitle+') restanti rispetto alla fase successiva',
						ISNULL(@totcompetency,0) + 
						ISNULL(@totcompetencyvar,0) -
						ISNULL(@nextphasecomp,0),'S')
					FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
				END
			DEALLOCATE crsphase
			INSERT INTO #situation VALUES('Totale Mandati', ISNULL(@totpayment,0),'S')
		END			

	SELECT value, amount, kind FROM #situation	
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

