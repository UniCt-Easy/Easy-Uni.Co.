
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_fin_compcash]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_fin_compcash]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE   PROCEDURE [show_fin_compcash]
(
	@date datetime,
	@idfin int,
	@finpart char(1)
)
AS
BEGIN
/* Versione 1.0.1 del 27/11/2007 ultima modifica: MARIA */
DECLARE	@ayear int
SELECT @ayear = YEAR(@date)
		
-- Verifica se l'avanzo di amministrazione non è totalizzato e viene attribuito in previsione ad una voce  
-- di bilancio in entrata -- M. Smaldino
DECLARE @flagincomesurplus char(1) -- Flag indicante se l'avanzo di amministrazione Ã Â¨ attribuito in previsione ad un capitolo di entrata o no --M. Smaldino
IF EXISTS (SELECT *  FROM fin  WHERE ayear = @ayear AND ((flag & 16) <>0) )
	         SET @flagincomesurplus = 'S'
	        ELSE  SET @flagincomesurplus = 'N'


CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

DECLARE	@nphase_fin_int int
SELECT @nphase_fin_int = 1

DECLARE @levelusable tinyint -- Livello operativo per le voci di bilancio
SELECT @levelusable = MIN(nlevel) FROM finlevel WHERE (flag & 2)<>0 AND ayear = @ayear
DECLARE @nphase_ass_app tinyint-- Fase paragonabile all'accertamento o all'impegno
DECLARE	@nphase_fin tinyint -- Fase in cui viene inserita la voce di bilancio
DECLARE	@maxphase tinyint-- Fase di cassa

IF @finpart = 'E'
BEGIN
	SELECT @nphase_ass_app = assessmentphasecode FROM config WHERE ayear = @ayear
	SELECT @nphase_fin = incomefinphase FROM uniconfig
	SELECT @maxphase = MAX(nphase) FROM incomephase
	SET @nphase_fin_int = CONVERT(int, @nphase_fin)
END
ELSE
BEGIN
	SELECT @nphase_ass_app = appropriationphasecode FROM config WHERE ayear = @ayear
	SELECT @nphase_fin = expensefinphase from uniconfig
	SELECT @maxphase = MAX(nphase) FROM expensephase
	SET @nphase_fin_int = CONVERT(int, @nphase_fin) 
END

DECLARE	@nlevel tinyint -- Livello della voce di bilancio
DECLARE	@fincode varchar(50) -- Codice di bilancio
DECLARE	@title varchar(150) -- Descrizione della voce di bilancio

SELECT @nlevel = nlevel, 
	@fincode = codefin, 
	@title = title 
FROM fin WHERE idfin = @idfin

DECLARE	@prevision_M decimal(19,2)
DECLARE	@prevision_S decimal(19,2)
IF (@nlevel < @levelusable) OR (@nlevel IS NULL)
BEGIN
-- ho scleto la categoria (x es)
	SELECT @prevision_M = ISNULL(SUM(prevision),0), @prevision_S = ISNULL(SUM(secondaryprev),0) 
	FROM finyearview 
	JOIN finlink
		ON finlink.idchild = finyearview.idfin
	join fin
		ON finyearview.idfin = fin.idfin
	WHERE finyearview.nlevel  = @levelusable
	and fin.ayear = @ayear
	AND (
		(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
		OR 
		( @nlevel is null AND finlink.nlevel = @levelusable)
	    )
	and ((fin.flag & 1 ) = @finpart_bit)
--	AND nlevel = @levelusable
END
ELSE
BEGIN
-- ho scleot la voce operativa
	SELECT @prevision_M = SUM(prevision), @prevision_S = SUM(secondaryprev)
	FROM finyear
	WHERE idfin = @idfin
END

DECLARE	@var_prev_acc_M decimal(19,2)
SELECT @var_prev_acc_M = SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN finlink FLK
	ON FLK.idchild = FVD.idfin
join fin F
	ON FVD.idfin = F.idfin
WHERE 
	(	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	and ((F.flag & 1 ) = @finpart_bit) and F.ayear = @ayear
	AND FVD.amount > 0

DECLARE	@var_prev_red_M decimal(19,2)
SELECT @var_prev_red_M = SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN finlink FLK
	ON FLK.idchild = FVD.idfin
join fin F
	ON FVD.idfin = F.idfin
WHERE 
	((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
	AND FV.adate <= @date
	and ((F.flag & 1 ) = @finpart_bit) and F.ayear = @ayear
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND amount < 0
-- Calcolo delle variazioni totali sulla previsione principale date dalla somma algebrica di quelle in aumento e quelle in diminuzione
DECLARE @var_prev_M decimal(19,2)
SET @var_prev_M = ISNULL(@var_prev_acc_M,0) + ISNULL(@var_prev_red_M,0)
-- Calcolo della previsione principale attuale
DECLARE @prev_curr_M decimal(19,2)
SET @prev_curr_M = ISNULL(@prevision_M,0) + ISNULL(@var_prev_M,0)

DECLARE	@var_prev_acc_S decimal(19,2)
SELECT @var_prev_acc_S = SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN finlink FLK
	ON FLK.idchild = FVD.idfin
join fin F
	ON FVD.idfin = F.idfin
WHERE
	((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
	AND FV.adate <= @date
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	and ((F.flag & 1 ) = @finpart_bit) and F.ayear = @ayear
	AND FV.flagsecondaryprev = 'S'
	AND amount > 0

DECLARE	@var_prev_red_S decimal(19,2)
SELECT @var_prev_red_S = SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN finlink FLK
	ON FLK.idchild = FVD.idfin
join fin F
	ON FVD.idfin = F.idfin
WHERE
	((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
	AND FV.adate <= @date
	and ((F.flag & 1 ) = @finpart_bit) and F.ayear = @ayear
	AND FV.flagsecondaryprev = 'S'
	AND FV.variationkind <> 5
	AND FV.idfinvarstatus = 5
	AND amount < 0
-- Calcolo delle variazioni totali sulla previsione secondaria date dalla somma algebrica di quelle in aumento e quelle in diminuzione
DECLARE @var_prev_S decimal(19,2) -- Totale delle variazioni di previsione secondaria
SET @var_prev_S = ISNULL(@var_prev_acc_S,0) + ISNULL(@var_prev_red_S,0)
-- Calcolo della previsione secondaria attuale
DECLARE @prev_curr_S decimal(19,2)
SET @prev_curr_S = ISNULL(@prevision_S,0) + ISNULL(@var_prev_S,0)
-- Tabella dei movimenti di competenza
CREATE TABLE #mov_C (nphase tinyint, amount decimal(19,2))
-- Tabella delle variazioni sui movimenti di competenza
CREATE TABLE #var_C (nphase tinyint, amount decimal(19,2))
-- Tabella dei movimenti residui
CREATE TABLE #mov_R (nphase tinyint, amount decimal(19,2))
-- Tabella delle variazioni sui movimenti residui
CREATE TABLE #var_R (nphase tinyint, amount decimal(19,2))

IF (@finpart = 'E')
BEGIN
	INSERT INTO #mov_C (nphase, amount)
	SELECT M.nphase, SUM(MY.amount)-- SUM(MT.amount)
	FROM incomeyear MY
	JOIN incometotal MT
		ON MT.idinc = MY.idinc
		AND MT.ayear = MY.ayear
	JOIN income M
		ON M.idinc = MY.idinc
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	WHERE 	((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND M.adate <= @date
		AND MY.ayear = @ayear
		AND ((MT.flag & 1)=0)  --Competenza
		AND M.nphase >= @nphase_fin
	GROUP BY M.nphase

	INSERT INTO #mov_R (nphase, amount)
	SELECT M.nphase, SUM(MY.amount)-- SUM(MT.amount)
	FROM incomeyear MY
	JOIN incometotal MT
		ON MT.idinc = MY.idinc
		AND MT.ayear = MY.ayear
	JOIN income M
		ON M.idinc = MY.idinc
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	WHERE 
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND M.adate <= @date
		AND MY.ayear = @ayear
		AND ((MT.flag & 1)=1)  --Residuo
		AND M.nphase >= @nphase_fin
	GROUP BY M.nphase
	
	INSERT INTO #var_C (nphase, amount)
	SELECT M.nphase, SUM(MV.amount)
	FROM incomevar MV
	JOIN incomeyear MY
		ON MY.idinc = MV.idinc
	JOIN incometotal MT
		ON MT.idinc = MY.idinc
		AND MT.ayear = MY.ayear
	JOIN income M
		ON M.idinc = MY.idinc
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	WHERE MV.yvar = @ayear
--		AND 
		AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND MY.ayear = @ayear
		AND ((MT.flag & 1)=0)  --Competenza
		AND M.nphase >= @nphase_fin
		AND MV.adate <= @date
	GROUP BY M.nphase


	INSERT INTO #var_R
	SELECT M.nphase, SUM(MV.amount)
	FROM incomevar MV
	JOIN incomeyear MY
		ON MY.idinc = MV.idinc
	JOIN incometotal MT
		ON MT.idinc = MY.idinc
		AND MT.ayear = MY.ayear
	JOIN income M
		ON M.idinc = MY.idinc
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	WHERE MV.yvar = @ayear
		AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND MY.ayear = @ayear
		AND ((MT.flag & 1)=1)  --Residuo
		AND M.nphase >= @nphase_fin
		AND MV.adate <= @date
	GROUP BY M.nphase
	
	DECLARE @tot_proceeds_C decimal(19,2)
	SET @tot_proceeds_C =
	ISNULL(
		(SELECT SUM(HPV.curramount)
		FROM historyproceedsview HPV
		JOIN finlink FLK
			ON FLK.idchild = HPV.idfin
		WHERE HPV.ymov = @ayear
			AND ((HPV.totflag & 1)=0)  --Competenza
			AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
			AND HPV.competencydate <= @date)
	,0)

	DECLARE @tot_proceeds_R decimal(19,2)
	SET @tot_proceeds_R =
	ISNULL(
		(SELECT SUM(HPV.curramount)
		FROM historyproceedsview HPV
		JOIN finlink FLK
			ON FLK.idchild = HPV.idfin
		WHERE HPV.ymov = @ayear
			AND ((HPV.totflag & 1)=1)  --Residuo
			AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
			AND HPV.competencydate <= @date)
	,0)
	DECLARE @tot_proceeds decimal(19,2)
	SET @tot_proceeds = ISNULL(@tot_proceeds_C,0) + ISNULL(@tot_proceeds_R,0)
END


IF (@finpart = 'S')
BEGIN
	INSERT INTO #mov_C (nphase, amount)
	SELECT M.nphase, SUM(MY.amount)
	FROM expenseyear MY
	JOIN expensetotal MT
		ON MT.idexp = MY.idexp
		AND MT.ayear = MY.ayear
	JOIN expense M
		ON M.idexp = MY.idexp
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	WHERE 
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND M.adate <= @date
		AND MY.ayear = @ayear
		AND ((MT.flag & 1)=0)  --Competenza
		AND M.nphase >= @nphase_fin
	GROUP BY M.nphase

	INSERT INTO #mov_R (nphase, amount)
	SELECT M.nphase, SUM(MY.amount)
	FROM expenseyear MY
	JOIN expensetotal MT
		ON MT.idexp = MY.idexp
		AND MT.ayear = MY.ayear
	JOIN expense M
		ON M.idexp = MY.idexp
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	WHERE 
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND M.adate <= @date
		AND MY.ayear = @ayear
		AND ((MT.flag & 1) = 1)  --Residuo
		AND M.nphase >= @nphase_fin
	GROUP BY M.nphase
	
	INSERT INTO #var_C (nphase, amount)
	SELECT M.nphase, SUM(MV.amount)
	FROM expensevar MV
	JOIN expenseyear MY
		ON MY.idexp = MV.idexp
	JOIN expense M
		ON M.idexp = MY.idexp
	JOIN expensetotal MT
		ON MT.idexp = MY.idexp
		AND MT.ayear = MY.ayear
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	WHERE MV.yvar = @ayear
		AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND MY.ayear = @ayear
		AND ((MT.flag & 1)=0)  --Competenza
		AND M.nphase >= @nphase_fin
		AND MV.adate <= @date
	GROUP BY M.nphase

	INSERT INTO #var_R
	SELECT M.nphase, SUM(MV.amount)
	FROM expensevar MV
	JOIN expenseyear MY
		ON MY.idexp = MV.idexp
	JOIN expensetotal MT
		ON MT.idexp = MY.idexp
		AND MT.ayear = MY.ayear
	JOIN expense M
		ON M.idexp = MY.idexp
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	WHERE MV.yvar = @ayear
		AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND MY.ayear = @ayear
		AND ((MT.flag & 1) = 1)  --Residuo
		AND M.nphase >= @nphase_fin
		AND MV.adate <= @date
	GROUP BY M.nphase

	DECLARE	@tot_creditpart decimal(19,2)
	SELECT @tot_creditpart = SUM(CP.amount)
	FROM creditpart CP
	JOIN finlink FLK
		ON FLK.idchild = CP.idfin
	join fin F
		on CP.idfin = F.idfin
	WHERE 
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND CP.adate <= @date
		AND ( (F.flag & 1)=1)--solo per le spese
		AND F.ayear = @ayear

	DECLARE @tot_aa decimal(19,2) -- Totale ripartizione dell'avanzo di amministrazione
	SELECT @tot_aa = SUM(D.amount)
	FROM finvardetail D
	JOIN finvar V
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar
	JOIN finlink FLK
		ON FLK.idchild = D.idfin
	join fin F
		on D.idfin = F.idfin
	WHERE 
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND V.adate <= @date
		AND V.flagcredit = 'S'
		AND V.idfinvarstatus = 5
		AND V.variationkind IN (2,3)
		AND ( (F.flag & 1)=1)--solo per le spese
		AND F.ayear = @ayear

	DECLARE	@tot_var_credit decimal(19,2) -- Totale variazione assegnazione dei crediti
	SELECT @tot_var_credit = SUM(D.amount)
	FROM finvardetail D
	JOIN finvar V
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar
	JOIN finlink FLK
		ON FLK.idchild = D.idfin
	join fin F
		on D.idfin = F.idfin
	WHERE 
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND V.adate <= @date
		AND V.flagcredit = 'S'
		AND V.idfinvarstatus = 5
		AND V.variationkind IN (1,4)
		AND ( (F.flag & 1)=1)--solo per le spese
		AND F.ayear = @ayear

	DECLARE	@tot_proceedspart decimal(19,2) -- Totale assegnazioni di cassa
	SELECT @tot_proceedspart = SUM(P.amount)
	FROM proceedspart P
	JOIN finlink FLK
		ON FLK.idchild = P.idfin
	join fin F
		on P.idfin = F.idfin
	WHERE 
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND P.adate <= @date
		AND ( (F.flag & 1)=1)--solo per le spese
		AND F.ayear = @ayear

	DECLARE @tot_ff decimal(19,2) -- Totale ripartizione dell'avanzo di cassa
	SELECT @tot_ff = SUM(D.amount)
	FROM finvardetail D
	JOIN finvar V
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar
	JOIN finlink FLK
		ON FLK.idchild = D.idfin
	join fin F
		on D.idfin = F.idfin
	WHERE 
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND v.adate <= @date
		AND v.flagproceeds = 'S'
		AND V.idfinvarstatus = 5
		AND v.variationkind IN (2,3)
		AND ( (F.flag & 1)=1)--solo per le spese
		AND F.ayear = @ayear

	DECLARE	@tot_var_proceeds decimal(19,2) -- Totale variazioni assegnazioni di cassa
	SELECT @tot_var_proceeds = SUM(D.amount)
	FROM finvardetail D
	JOIN finvar V
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar
	JOIN finlink FLK
		ON FLK.idchild = D.idfin
	join fin F
		on D.idfin = F.idfin
	WHERE 
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		AND v.adate <= @date
		AND v.flagproceeds = 'S'
		AND V.idfinvarstatus = 5
		AND v.variationkind IN (1,4)
		AND ( (F.flag & 1)=1)--solo per le spese
		AND F.ayear = @ayear

	DECLARE @tot_payment_C decimal(19,2)
	SET @tot_payment_C = 
	ISNULL(
		(SELECT SUM(HPV.curramount)
		FROM historypaymentview HPV
		JOIN finlink FLK
			ON FLK.idchild = HPV.idfin
		WHERE HPV.ymov = @ayear
			AND ((HPV.totflag & 1)=0)  --Competenza
			AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
			AND HPV.competencydate <= @date)
	,0)

	DECLARE @tot_payment_R decimal(19,2)
	SET @tot_payment_R =
	ISNULL(
		(SELECT SUM(HPV.curramount)
		FROM historypaymentview HPV
		JOIN finlink FLK
			ON FLK.idchild = HPV.idfin
		WHERE HPV.ymov = @ayear
			AND ((HPV.totflag & 1)=1)  --Residuo
			AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
			AND HPV.competencydate <= @date)
	,0)
	DECLARE @tot_payment decimal(19,2)
	SET @tot_payment = ISNULL(@tot_payment_C,0) + ISNULL(@tot_payment_R,0)
END

DECLARE	@tot_pettycashop decimal(19,2)
SELECT @tot_pettycashop = SUM(exp_op.amount)
FROM pettycashoperation exp_op
JOIN finlink FLK
	ON FLK.idchild = exp_op.idfin
JOIN fin F
	on exp_op.idfin = F.idfin
WHERE ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
	AND exp_op.adate	<= @date
	AND ( (F.flag & 1)=1)--solo per le spese
	AND F.ayear = @ayear

	AND NOT	EXISTS
		(SELECT * FROM pettycashoperation restore_op
		WHERE restore_op.yoperation = exp_op.yrestore
			AND restore_op.noperation = exp_op.nrestore
			AND restore_op.idpettycash = exp_op.idpettycash
			AND restore_op.adate <= @date)

DECLARE	@departmentname varchar(150)

SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')


INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
DECLARE	@desc_level varchar(50)
SELECT @desc_level = description 
FROM finlevel 
WHERE ayear = @ayear
	AND nlevel = @nlevel
INSERT INTO #situation VALUES (@desc_level + ' ' + @fincode, NULL, 'H')
INSERT INTO #situation VALUES (@title,	NULL, 'H')
INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4),	@ayear), NULL, 'H')
INSERT INTO #situation VALUES ('', NULL, 'N')
INSERT INTO #situation VALUES('C O M P E T E N Z A',NULL,'N')
INSERT INTO #situation VALUES ('Previsione iniziale di competenza', @prevision_M, '')
INSERT INTO #situation VALUES ('Variazioni di bilancio e Storni di previsione', @var_prev_M, '')
IF (@finpart = 'E' AND (@nlevel is null) AND @flagincomesurplus = 'N')-- Significa che stiamo sul titolo
-- Se l'avanzo di amministrazione viene attribuito in previsione ad una voce  
-- di bilancio in entrata non deve essere totalizzato M. Smaldino
BEGIN
	DECLARE @creditsurplus decimal(19,2) -- Avanzo di Amministrazione
	SELECT @creditsurplus = ISNULL(creditsurplus,0) FROM finsurplusview WHERE ayear = @ayear
	INSERT INTO #situation VALUES ('Avanzo di Amministrazione Totale',@creditsurplus,'')
	-- Ricalcolo della previsione attuale dove sommo anche l'avanzo di amministrazione
	SET @prev_curr_M = ISNULL(@prev_curr_M, 0) + ISNULL(@creditsurplus,0)
END
DECLARE @credit char(1)
INSERT INTO #situation VALUES ('Previsione attuale di competenza', ISNULL(@prev_curr_M,0), 'S')
IF @finpart = 'S'
	AND (EXISTS
		(SELECT * FROM creditpart 
		WHERE ycreditpart = @ayear
		AND adate <= @date)
	OR EXISTS
		(SELECT * FROM finvar
		WHERE yvar = @ayear
		AND flagcredit = 'S'
		AND adate <= @date
		AND variationkind <> 5
		AND idfinvarstatus = 5))
BEGIN
	INSERT INTO #situation VALUES ('Avanzo di Amministrazione',@tot_aa,'')
	INSERT INTO #situation	VALUES ('Assegnazione crediti',	@tot_creditpart, '')
	INSERT INTO #situation	VALUES ('Variazioni e Storni di Crediti', @tot_var_credit, '')
	DECLARE @prev_to_credit decimal(19,2)
	SET @prev_to_credit = 
		ISNULL(@prev_curr_M, 0) -
		ISNULL(@tot_aa,0) -
		ISNULL(@tot_creditpart, 0) - 
		ISNULL(@tot_var_credit, 0)
	INSERT INTO #situation	VALUES ('Previsione da accreditare', @prev_to_credit,'S')
        SET @credit = 'S'
END
ELSE
BEGIN
        SET @credit = 'N'        
END
DECLARE @next_phase_C decimal(19,2) -- Calcolo della fase successiva in c/competenza
DECLARE @next_phase_R decimal(19,2) -- Calcolo della fase successiva in c/residui
DECLARE @desc_ass_app varchar(50) -- Nome della fase 'Accertamento' - 'Impegno'
DECLARE @desc_pay_pro varchar(50) -- Nome della fase 'Riga Reversale' - 'Riga Mandato'
DECLARE	@desc_phase varchar(50)
DECLARE	@tot_mov_C decimal(19,2)
DECLARE	@tot_mov_R decimal(19,2)
DECLARE	@tot_var_C decimal(19,2)
DECLARE	@tot_var_R decimal(19,2)
DECLARE	@nphase tinyint
DECLARE @lbl_avail_firstphase varchar(150) -- Etichetta sulla disponibilità calcolata sulla prima fase di entrata o di spesa
DECLARE @lbl_avail_ass varchar(150) -- Etichetta sulla disponibilità ad accertate
DECLARE @amount_lastphase_C decimal(19,2)
DECLARE @amount_lastphase_R decimal(19,2)
DECLARE @lbl_avail_app varchar(150) -- Etichetta sulla disponibilità ad impegnare
-- Competenza
IF (@finpart = 'E')
BEGIN
	-- Gestione in c/competenza
	DECLARE	phase_crs INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM incomephase
	WHERE nphase >= @nphase_fin
		AND nphase IN (@nphase_fin,@nphase_ass_app,@maxphase)
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM	phase_crs INTO @nphase, @desc_phase
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		IF (@nphase = @nphase_fin_int)
		BEGIN
			SET @desc_ass_app = @desc_phase
		END
		ELSE
		BEGIN
			SET @desc_pay_pro = @desc_phase
		END
		SET @tot_mov_C = ISNULL((SELECT amount FROM #mov_C WHERE nphase = @nphase),0)
		SET @tot_var_C = ISNULL((SELECT amount FROM #var_C WHERE nphase = @nphase),0)
		-- Se la fase corrispondente all'accertamento o impegno non coincide con la prima fase di entrata o spesa in cui è imputata
		-- la voce di bilancio  prendere in considerazione anche la previsione disponibile calcolata su questa fase 
		IF (@nphase = @nphase_fin AND @nphase_fin < @nphase_ass_app)
		BEGIN
			SET @lbl_avail_firstphase = 'Disponibilità per ulteriore ' + '"' + @desc_phase + '"'
			INSERT INTO #situation VALUES(@lbl_avail_firstphase,
			ISNULL(@prev_curr_M, 0) -
			ISNULL(@tot_mov_C, 0) -
			ISNULL(@tot_var_C, 0), 'S')
		END
		ELSE
		BEGIN
			INSERT INTO #situation VALUES('1) Movimenti competenza (' + @desc_phase + ')', @tot_mov_C, '')
			INSERT INTO #situation VALUES('2) Variazioni competenza (' + @desc_phase + ')', @tot_var_C, '')
			INSERT INTO #situation VALUES('3) Totale movimenti competenza (' + @desc_phase + ')',
				ISNULL(@tot_mov_C,0) + ISNULL(@tot_var_C,0),'')
			SELECT @lbl_avail_ass = 'Disponibilità per ' + '"' + @desc_phase + '"' +' (Prev. Attuale - 3'
			IF (@nphase = @nphase_fin_int) -- Informazioni inerenti gli accertamenti
			BEGIN
				IF (@finpart = 'E' AND (@nlevel is null ) AND @flagincomesurplus = 'N')-- Significa che stiamo sul titolo
				  Begin
					SELECT @lbl_avail_ass = @lbl_avail_ass + ' - Avanzo di Amm. Totale)'
					INSERT INTO #situation	VALUES(@lbl_avail_ass,ISNULL(@prev_curr_M, 0) - ISNULL(@tot_mov_C, 0) 
					- ISNULL(@tot_var_C, 0)- ISNULL(@creditsurplus,0), 'S')
				  End	
				Else
				  Begin
					SELECT @lbl_avail_ass = @lbl_avail_ass + ')'
					INSERT INTO #situation	VALUES(@lbl_avail_ass, 	ISNULL(@prev_curr_M, 0) - ISNULL(@tot_mov_C, 0) 
					- ISNULL(@tot_var_C, 0), 'S')
				  End
			END
			ELSE IF (@nphase = @maxphase) -- Informazioni inerenti gli incassi
			BEGIN
				DECLARE @tot_assessment_C decimal(19,2)
				SET @tot_assessment_C = 
				ISNULL((SELECT SUM(amount) FROM #mov_C WHERE nphase = @nphase_fin_int),0) +
				ISNULL((SELECT SUM(amount) FROM #var_C WHERE nphase = @nphase_fin_int),0)
	
				INSERT INTO #situation VALUES('Accertato di competenza da incassare',
				@tot_assessment_C - ISNULL(@tot_mov_C,0) - ISNULL(@tot_var_C,0),'S')
			END
		END
		FETCH NEXT FROM	phase_crs INTO @nphase, @desc_phase
	END
	CLOSE phase_crs
	DEALLOCATE phase_crs
	INSERT INTO #situation VALUES('Reversali emesse in c/competenza', @tot_proceeds_C, 'S')
	INSERT INTO #situation VALUES('',NULL,'H')
	
	-- Gestione in c/residui
	INSERT INTO #situation VALUES('R E S I D U I',NULL,'N')
	DECLARE	phase_crs INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM incomephase
	WHERE nphase >= @nphase_fin
		AND @nphase IN (@nphase_ass_app,@maxphase)
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM	phase_crs INTO @nphase, @desc_phase
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SET @tot_mov_R = 0
		SET @tot_var_R = 0
		SELECT @tot_mov_R = ISNULL(amount, 0) FROM #mov_R WHERE nphase = @nphase
		INSERT INTO #situation VALUES('1) Movimenti residui (' + @desc_phase + ')', @tot_mov_R, '')
		SELECT @tot_var_R = ISNULL(amount, 0) FROM #var_R WHERE nphase = @nphase
		INSERT INTO #situation VALUES('2) Variazione residui ('+ @desc_phase + ')', @tot_var_R, '')
		DECLARE @tot_assessment_R decimal(19,2)
		IF (@nphase = @nphase_fin_int) -- Informazioni inerenti gli accertamenti
		BEGIN
			INSERT INTO #situation VALUES('Totale Residui Attivi ('+ @desc_phase + ')',
			ISNULL(@tot_mov_R,0) + ISNULL(@tot_var_R,0), 'S')
		END
		ELSE IF(@nphase = @maxphase)
		BEGIN
			INSERT INTO #situation VALUES('3) Totale Movimenti residui ('+ @desc_phase + ')', 
			ISNULL(@tot_mov_R,0) + ISNULL(@tot_var_R,0), '')
			SET @tot_assessment_R = 
			ISNULL((SELECT SUM(amount) FROM #mov_R WHERE nphase = @nphase_fin_int),0) +
			ISNULL((SELECT SUM(amount) FROM #var_R WHERE nphase = @nphase_fin_int),0)
			INSERT INTO #situation VALUES('Residui Attivi da incassare',
			ISNULL(@tot_assessment_R,0) - ISNULL(@tot_proceeds_R,0), 'S')
		END
		FETCH NEXT FROM	phase_crs INTO @nphase, @desc_phase
	END
	CLOSE phase_crs
	DEALLOCATE phase_crs
	
	SET @amount_lastphase_C = 
		ISNULL((SELECT SUM(amount) FROM #mov_C WHERE nphase = @maxphase),0) +
		ISNULL((SELECT SUM(amount) FROM #var_C WHERE nphase = @maxphase),0)
	SET @amount_lastphase_R = 
		ISNULL((SELECT SUM(amount) FROM #mov_R WHERE nphase = @maxphase),0) +
		ISNULL((SELECT SUM(amount) FROM #var_R WHERE nphase = @maxphase),0)
	DECLARE @tot_ass_proceeded int
	SET @tot_ass_proceeded = 
		ISNULL(@tot_assessment_C,0) + ISNULL(@tot_assessment_R,0) -
		ISNULL(@amount_lastphase_C,0) - ISNULL(@amount_lastphase_R,0)
	INSERT INTO #situation VALUES('Reversali emesse in c/residui', @tot_proceeds_R, 'S')
	INSERT INTO #situation VALUES('',NULL,'H')
END
IF(@finpart = 'S')
BEGIN
	DECLARE	phase_crs INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM expensephase
	WHERE nphase >= @nphase_fin
		AND nphase IN (@nphase_fin,@nphase_ass_app,@maxphase)
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM	phase_crs INTO @nphase, @desc_phase
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		IF (@nphase = @nphase_fin_int)
		BEGIN
			SET @desc_ass_app = @desc_phase
		END
		ELSE
		BEGIN
			SET @desc_pay_pro = @desc_phase
		END
		SET @tot_mov_C = ISNULL((SELECT amount FROM #mov_C WHERE nphase = @nphase),0)
		SET @tot_var_C = ISNULL((SELECT amount FROM #var_C WHERE nphase = @nphase),0)
		-- Se la fase corrispondente all'accertamento o impegno non coincide con la prima fase di entrata o spesa in cui è imputata
		-- la voce di bilancio occorre prendere in considerazione la previsione disponibile calcolata su questa fase 
		IF (@nphase = @nphase_fin and @nphase_fin < @nphase_ass_app )
		BEGIN
			SELECT @lbl_avail_firstphase = 'Disponibilità  per ulteriore ' + '"' + @desc_phase + '"'
			INSERT INTO #situation VALUES(@lbl_avail_firstphase,
			ISNULL(@prev_curr_M, 0) -
			ISNULL(@tot_mov_C,0) -
			ISNULL(@tot_var_C,0) -
			ISNULL(@tot_pettycashop,0) ,'S')
		END
		ELSE
		BEGIN
			INSERT INTO #situation VALUES('1) Movimenti competenza ('+ @desc_phase + ')', @tot_mov_C, '')
			INSERT INTO #situation	VALUES('2) Variazioni competenza ('+ @desc_phase + ')', @tot_var_C, '')
			INSERT INTO #situation VALUES('3) Totale movimenti competenza (' +  @desc_phase + ')', 
				ISNULL(@tot_mov_C,0) + ISNULL(@tot_var_C,0), '')
			SELECT @lbl_avail_app = 'Disponibilità per ' + '"' + @desc_phase + '"' +' (Prev. Attuale - 3'
			IF @tot_pettycashop > 0
			BEGIN
				INSERT INTO #situation	VALUES(
				'4) Totale op. fondo economale attribuite non reintegrate', @tot_pettycashop, '')
				SELECT @lbl_avail_app = @lbl_avail_app + ' - 4'
			END
			IF (@nphase = @nphase_ass_app)
			BEGIN
				SELECT @lbl_avail_app = @lbl_avail_app + ')'
				INSERT INTO #situation VALUES(@lbl_avail_app,
					ISNULL(@prev_curr_M, 0) -
					ISNULL(@tot_mov_C,0) -
					ISNULL(@tot_var_C,0) -
					ISNULL(@tot_pettycashop,0),'S')
                                IF (@credit = 'S')
                                Begin
				INSERT INTO #situation VALUES('Crediti Residui',
					ISNULL(@tot_aa,0) +
					ISNULL(@tot_creditpart,0) +
					ISNULL(@tot_var_credit,0) -
					ISNULL(@tot_mov_C,0) -
					ISNULL(@tot_var_C,0)-
					ISNULL(@tot_pettycashop,0),'S')
                                End
			END
			IF (@nphase = @maxphase)
			BEGIN
				DECLARE @tot_appropriation_C decimal(19,2)
				SET @tot_appropriation_C = 
					ISNULL((SELECT SUM(amount) FROM #mov_C WHERE nphase = @nphase_fin_int),0) +
					ISNULL((SELECT SUM(amount) FROM #var_C WHERE nphase = @nphase_fin_int),0)
				INSERT INTO #situation VALUES('Impegnato di competenza da pagare',
					ISNULL(@tot_appropriation_C,0) - ISNULL(@tot_mov_C,0) - ISNULL(@tot_var_C,0),'S')
			END
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @desc_phase
	END
	CLOSE phase_crs
	DEALLOCATE phase_crs
	
	INSERT INTO #situation VALUES('Mandati emessi in c/competenza', @tot_payment_C, 'S')
	INSERT INTO #situation VALUES('',NULL,'H')
	-- Gestione in c/residui
	INSERT INTO #situation VALUES('R E S I D U I',NULL,'N')
	DECLARE	phase_crs INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM expensephase
	WHERE nphase >= @nphase_fin
		AND nphase IN (@nphase_ass_app,@maxphase)
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM	phase_crs INTO @nphase, @desc_phase
	WHILE (@@FETCH_STATUS =	0)
	BEGIN		
		SET @tot_mov_R = 0
		SET @tot_var_R = 0
	
		SELECT @tot_mov_R = ISNULL(amount, 0) FROM #mov_R WHERE nphase = @nphase
		INSERT INTO #situation	VALUES('1) Movimenti residui (' + @desc_phase + ')', @tot_mov_R, '')
		SELECT @tot_var_R = ISNULL(amount, 0) FROM #var_R WHERE nphase = @nphase
		INSERT INTO #situation	VALUES('2) Variazioni residui ('+ @desc_phase + ')', @tot_var_R, '')
		DECLARE @tot_appropriation_R decimal(19,2)	
		IF (@nphase = @nphase_fin_int)
		BEGIN
			INSERT INTO #situation VALUES('Totale Residui Passivi (' + @desc_phase + ')', 
				ISNULL(@tot_mov_R,0) + ISNULL(@tot_var_R,0), 'S')
		END
		ELSE IF(@nphase = @maxphase)
		BEGIN
			INSERT INTO #situation VALUES('3) Totale Movimenti residui (' + @desc_phase + ')', 
				ISNULL(@tot_mov_R,0) + ISNULL(@tot_var_R,0), '')
			SET @tot_appropriation_R = 
				ISNULL((SELECT SUM(amount) FROM #mov_R WHERE nphase = @nphase_fin_int),0) +
				ISNULL((SELECT SUM(amount) FROM #var_R WHERE nphase = @nphase_fin_int),0)
			INSERT INTO #situation VALUES('Residui Passivi da pagare',
				ISNULL(@tot_appropriation_R,0) - ISNULL(@tot_payment_R,0) , 'S')
			INSERT INTO #situation VALUES('Mandati emessi in c/residui', @tot_payment_R, 'S')
			INSERT INTO #situation VALUES('',NULL,'H')
		END
		FETCH NEXT FROM	phase_crs INTO @nphase, @desc_phase
	END
	CLOSE phase_crs
	DEALLOCATE phase_crs
	SET @amount_lastphase_R = 
		ISNULL((SELECT SUM(amount) FROM #mov_R WHERE nphase = @maxphase),0) +
		ISNULL((SELECT SUM(amount) FROM #var_R WHERE nphase = @maxphase),0)
	SET @amount_lastphase_C = 
		ISNULL((SELECT SUM(amount) FROM #mov_C WHERE nphase = @maxphase),0) +
		ISNULL((SELECT SUM(amount) FROM #var_C WHERE nphase = @maxphase),0)
	DECLARE @tot_app_payed int
	SET @tot_app_payed = 
		ISNULL(@tot_appropriation_C,0) +
		ISNULL(@tot_appropriation_R,0) -
		ISNULL(@amount_lastphase_C,0) -
		ISNULL(@amount_lastphase_R,0)
END
-- Cassa
INSERT INTO #situation VALUES ('C A S S A',NULL,'N')
INSERT INTO #situation VALUES ('Previsione iniziale di cassa', @prevision_S, '')
INSERT INTO #situation VALUES ('Variazioni di bilancio e Storni di previsione', @var_prev_S, '')

IF (@finpart = 'E' AND @nlevel is null AND @flagincomesurplus = 'N')-- Significa che stiamo sul titolo
-- Se l'avanzo di cassa viene attribuito in previsione ad una voce  
-- di bilancio in entrata non deve essere totalizzato M. Smaldino
BEGIN
	DECLARE @floatfund decimal(19,2) -- Avanzo di Cassa
	SELECT @floatfund = ISNULL(floatfund,0) FROM finsurplusview WHERE ayear = @ayear
	INSERT INTO #situation VALUES ('Avanzo di Cassa Totale',@floatfund,'')
	-- Ricalcolo della previsione attuale dove sommo anche l'avanzo di cassa
	SET @prev_curr_S = ISNULL(@prev_curr_S, 0) + ISNULL(@floatfund,0)
END

DECLARE @proceeds char(1)
INSERT INTO #situation VALUES ('Previsione attuale di cassa', ISNULL(@prev_curr_S, 0), 'S')
IF @finpart = 'S'
	AND (EXISTS
		(SELECT	* FROM proceedspart
		WHERE yproceedspart = @ayear
			AND adate <= @date)
	OR EXISTS
		(SELECT * FROM finvar
		WHERE yvar = @ayear
		AND flagproceeds = 'S'
		AND adate <= @date
		AND variationkind <> 5
		AND idfinvarstatus = 5))
BEGIN
	INSERT INTO #situation VALUES ('Avanzo di cassa', @tot_ff,'')
	INSERT INTO #situation VALUES ('Assegnazione incassi',	@tot_proceedspart, '')
	INSERT INTO #situation VALUES ('Variazioni e Storni di Incassi', @tot_var_proceeds, '')
	DECLARE @prev_to_proceed decimal(19,2)
	SET @prev_to_proceed = 
		ISNULL(@prev_curr_S, 0) -
		ISNULL(@tot_ff, 0) -
		ISNULL(@tot_proceedspart, 0) -
		ISNULL(@tot_var_proceeds, 0)
	INSERT INTO #situation VALUES ('Previsione da incassare', @prev_to_proceed, 'S')
        SET @proceeds = 'S'        
END
ELSE
BEGIN
        SET @proceeds = 'N'        
END
IF @finpart = 'E'
BEGIN
	DECLARE	phase_crs1 INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM incomephase
	WHERE nphase >= @nphase_fin
		AND nphase IN (@nphase_ass_app,@maxphase)
	FOR READ ONLY
	OPEN phase_crs1
	FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SET @tot_mov_C = ISNULL((SELECT amount FROM #mov_C WHERE nphase = @nphase),0)
		SET @tot_mov_R = ISNULL((SELECT amount FROM #mov_R WHERE nphase = @nphase),0)
		INSERT INTO #situation	VALUES('1) Movimenti (' + @desc_phase + ')', @tot_mov_C + @tot_mov_R, '')
		SET @tot_var_C = ISNULL((SELECT amount FROM #var_C WHERE nphase = @nphase),0)
		SET @tot_var_R = ISNULL((SELECT amount FROM #var_R WHERE nphase = @nphase),0)
		INSERT INTO #situation	VALUES('2) Variazioni movimenti ('+ @desc_phase	+ ')', @tot_var_C + @tot_var_R, '')
		INSERT INTO #situation VALUES('3) Totale Movimenti (' + @desc_phase + ')',
			ISNULL(@tot_mov_C,0) +
			ISNULL(@tot_mov_R,0) +
			ISNULL(@tot_var_C,0) +
			ISNULL(@tot_var_R,0),'')
		SELECT @lbl_avail_ass = 'Disponibilità per ' + '"' + @desc_phase + '"'+' (Prev. Attuale - 3'
		IF (@nphase = @nphase_ass_app)
		BEGIN
			IF (@finpart = 'E' AND (@nlevel is null ) AND @flagincomesurplus = 'N')-- Significa che stiamo sul titolo
			  Begin
				SELECT @lbl_avail_ass = @lbl_avail_ass + ' - Avanzo di Cassa Totale)'
				INSERT INTO #situation	VALUES(@lbl_avail_ass,ISNULL(@prev_curr_S, 0) 
				- ISNULL(@tot_mov_C, 0) - ISNULL(@tot_mov_R, 0) 
				- ISNULL(@tot_var_C, 0) - ISNULL(@tot_var_R, 0)- ISNULL(@floatfund,0), 'S')
			  End	
			Else
			  Begin
				SELECT @lbl_avail_ass = @lbl_avail_ass + ')'
				INSERT INTO #situation	VALUES(@lbl_avail_ass,ISNULL(@prev_curr_S, 0) 
				- ISNULL(@tot_mov_C, 0) - ISNULL(@tot_mov_R, 0) 
				- ISNULL(@tot_var_C, 0) - ISNULL(@tot_var_R, 0), 'S')
			  End
		END
		IF (@nphase = @maxphase)
		BEGIN
			DECLARE @tot_assessment decimal(19,2)
			SET @tot_assessment = 
				ISNULL((SELECT SUM(amount) FROM #mov_C WHERE nphase = @nphase_ass_app),0) +
				ISNULL((SELECT SUM(amount) FROM #var_C WHERE nphase = @nphase_ass_app),0) +
				ISNULL((SELECT SUM(amount) FROM #mov_R WHERE nphase = @nphase_ass_app),0) +
				ISNULL((SELECT SUM(amount) FROM #var_R WHERE nphase = @nphase_ass_app),0) 
			INSERT INTO #situation VALUES('Accertato da incassare',
				ISNULL(@tot_assessment,0) -
				ISNULL(@tot_mov_C,0) -
				ISNULL(@tot_var_C,0) -
				ISNULL(@tot_mov_R,0) -
				ISNULL(@tot_var_R,0),'S')
			IF (@finpart = 'E' AND (@nlevel is null ) AND @flagincomesurplus = 'N')-- Significa che stiamo sul titolo
			  Begin
				INSERT INTO #situation	VALUES('Disponibilità ad incassare (Reversali)', 
				ISNULL(@prev_curr_S, 0) - ISNULL(@tot_proceeds,0)- ISNULL(@floatfund,0), 'S')
			  End
			Else
			  Begin	
				INSERT INTO #situation	VALUES('Disponibilità ad incassare (Reversali)', 
				ISNULL(@prev_curr_S, 0) - ISNULL(@tot_proceeds,0), 'S')
			  End	
		END
		FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	END
	CLOSE phase_crs1
	DEALLOCATE phase_crs1
	INSERT INTO #situation VALUES('',NULL,'H')
	
	INSERT INTO #situation VALUES('R I E P I L O G O  F A S I  F I N A N Z I A R I E',NULL,'N')
	DECLARE	phase_crs1 INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM incomephase
	WHERE nphase >= @nphase_fin
	FOR READ ONLY
	OPEN phase_crs1
	FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SET @tot_mov_C = ISNULL((SELECT amount FROM #mov_C WHERE nphase = @nphase),0)
		SET @tot_var_C = ISNULL((SELECT amount FROM #var_C WHERE nphase = @nphase),0)
		SET @tot_mov_R = ISNULL((SELECT amount FROM #mov_R WHERE nphase = @nphase),0)
		SET @tot_var_R = ISNULL((SELECT amount FROM #var_R WHERE nphase = @nphase),0)
		-- Calcolo della fase successiva per sottrarla a quella attuale
		IF @nphase < @maxphase
		BEGIN
			SELECT @next_phase_C = ISNULL(amount,0) FROM #mov_C WHERE nphase = (@nphase + 1)
			SET @next_phase_C = ISNULL(@next_phase_C,0) + 
				ISNULL((SELECT ISNULL(amount,0) FROM #var_C WHERE nphase = (@nphase + 1)),0)
	
			SELECT @next_phase_R = ISNULL(amount,0)	FROM #mov_R WHERE nphase = (@nphase + 1)
			SET @next_phase_R = ISNULL(@next_phase_R,0) +
	 			ISNULL((SELECT ISNULL(amount,0) FROM #var_R WHERE nphase = (@nphase + 1)),0)
		END
		ELSE
		BEGIN
			SET @next_phase_C = ISNULL(@tot_proceeds_C,0)
			SET @next_phase_R = ISNULL(@tot_proceeds_R,0)
		END
		INSERT INTO #situation VALUES('1. Totale Movimenti competenza (' + @desc_phase +')', ISNULL(@tot_mov_C,0),'')
		INSERT INTO #situation VALUES('2. Totale Variazioni competenza (' + @desc_phase +')', ISNULL(@tot_var_C,0),'')
		INSERT INTO #situation VALUES('3. Totale Movimenti residui (' + @desc_phase +')', ISNULL(@tot_mov_R,0),'')
		INSERT INTO #situation VALUES('4. Totale Variazioni residui (' + @desc_phase +')', ISNULL(@tot_var_R,0),'')
	
		DECLARE @lbl_avail_C_inc varchar(150) -- Etichetta sulla prev. disponibile di competenza
		SELECT @lbl_avail_C_inc = 'Previsione Disponibile di Competenza (Prev. Attuale - 1 - 2'
		DECLARE @lbl_avail_S_inc varchar(150) -- Etichetta sulla prev. disponibile di cassa
		SELECT @lbl_avail_S_inc = 'Previsione Disponibile di Cassa (Prev. Attuale - 1 - 2 - 3 - 4'

		IF (@finpart = 'E' AND (@nlevel is null ) AND @flagincomesurplus = 'N')-- Significa che stiamo sul titolo
		  Begin
			INSERT INTO #situation VALUES(@lbl_avail_C_inc + ' - Avanzo Amm. Totale)',
			ISNULL(@prev_curr_M,0) - ISNULL(@tot_mov_C,0) - ISNULL(@tot_var_C,0) - ISNULL(@creditsurplus,0) ,'S')
		  End
		  Else	
		  Begin
			INSERT INTO #situation VALUES(@lbl_avail_C_inc + ')',
			ISNULL(@prev_curr_M,0) - ISNULL(@tot_mov_C,0) - ISNULL(@tot_var_C,0) ,'S')
		  End

		IF (@finpart = 'E' AND (@nlevel is null ) AND @flagincomesurplus = 'N')-- Significa che stiamo sul titolo
		  Begin
			INSERT INTO #situation VALUES(@lbl_avail_S_inc+ ' - Avanzo Cassa. Totale)',
			ISNULL(@prev_curr_S,0) - ISNULL(@tot_mov_C,0) -
			ISNULL(@tot_var_C,0) -	ISNULL(@tot_mov_R,0) - 	ISNULL(@tot_var_R,0) - isnull(@floatfund,0),'S')
		  End
		  Else
		  Begin
			INSERT INTO #situation VALUES(@lbl_avail_S_inc+ ')',
			ISNULL(@prev_curr_S,0) - ISNULL(@tot_mov_C,0) -
			ISNULL(@tot_var_C,0) -	ISNULL(@tot_mov_R,0) - 	ISNULL(@tot_var_R,0) ,'S')

		  End

		INSERT INTO #situation VALUES('('+@desc_phase+') restanti rispetto alla fase successiva in c/competenza',
			ISNULL(@tot_mov_C,0) + ISNULL(@tot_var_C,0) - ISNULL(@next_phase_C,0),'S')
	
		INSERT INTO #situation VALUES('('+@desc_phase+') restanti rispetto alla fase successiva in c/residui',
			ISNULL(@tot_mov_R,0) + ISNULL(@tot_var_R,0) - ISNULL(@next_phase_R,0),'S')
		FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	END
	CLOSE phase_crs1
	DEALLOCATE phase_crs1
	INSERT INTO #situation	VALUES('Totale Reversali in c/competenza', ISNULL(@tot_proceeds_C,0), '')	
	INSERT INTO #situation VALUES('Totale Reversali in c/residui', ISNULL(@tot_proceeds_R,0),'')
	INSERT INTO #situation	VALUES('Totale Reversali', ISNULL(@tot_proceeds,0), 'S')
END
ELSE 
IF (@finpart = 'S')
BEGIN
	DECLARE	phase_crs1 INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM expensephase
	WHERE nphase >= @nphase_fin
		AND nphase IN (@nphase_ass_app,@maxphase)
	FOR READ ONLY
	OPEN phase_crs1
	FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SET @tot_mov_C = ISNULL((SELECT amount FROM #mov_C WHERE nphase = @nphase),0)
		SET @tot_mov_R = ISNULL((SELECT amount FROM #mov_R WHERE nphase = @nphase),0)
		INSERT INTO #situation VALUES('1) Movimenti (' + @desc_phase + ')', @tot_mov_C + @tot_mov_R, '')
		SET @tot_var_C = ISNULL((SELECT amount FROM #var_C WHERE nphase = @nphase),0)
		SET @tot_var_R = ISNULL((SELECT amount FROM #var_R WHERE nphase = @nphase),0)
		INSERT INTO #situation VALUES('2) Variazioni movimenti (' + @desc_phase + ')', @tot_var_C + @tot_var_R, '')
		INSERT INTO #situation VALUES('3) Totale Movimenti (' + @desc_phase + ')',
			ISNULL(@tot_mov_C,0) +
			ISNULL(@tot_mov_R,0) +
			ISNULL(@tot_var_C,0) +
			ISNULL(@tot_var_R,0),'')
		SELECT @lbl_avail_app = 'Disponibilità per ' + '"' + @desc_phase + '"' + ' (Prev. Attuale - 3'
		IF (@tot_pettycashop > 0)
		BEGIN
			INSERT INTO #situation	VALUES(
			'4) Totale op. fondo economale attribuite non reintegrate',@tot_pettycashop, '')
			SELECT @lbl_avail_app = @lbl_avail_app + ' - 4'
		END
		IF (@nphase = @nphase_ass_app)
		BEGIN
			SELECT @lbl_avail_app = @lbl_avail_app + ')'
			INSERT INTO #situation VALUES(@lbl_avail_app,
				ISNULL(@prev_curr_S, 0) -
				ISNULL(@tot_mov_C,0) -
				ISNULL(@tot_var_C,0) -
				ISNULL(@tot_mov_R,0) -
				ISNULL(@tot_var_R,0) -
				ISNULL(@tot_pettycashop,0) ,'S')
		END
		IF (@nphase = @maxphase)
		BEGIN
			DECLARE @tot_appropriation decimal(19,2)
			SET @tot_appropriation = 
				ISNULL((SELECT SUM(amount) FROM #mov_C WHERE nphase = @nphase_ass_app),0) +
				ISNULL((SELECT SUM(amount) FROM #var_C WHERE nphase = @nphase_ass_app),0) +
				ISNULL((SELECT SUM(amount) FROM #mov_R WHERE nphase = @nphase_ass_app),0) +
				ISNULL((SELECT SUM(amount) FROM #var_R WHERE nphase = @nphase_ass_app),0)
		
			INSERT INTO #situation VALUES('Impegnato da pagare',
				ISNULL(@tot_appropriation,0) -
				ISNULL(@tot_mov_C,0) -
				ISNULL(@tot_var_C,0) -
				ISNULL(@tot_mov_R,0) -
				ISNULL(@tot_var_R,0),'S')
	
			INSERT INTO #situation VALUES('Disponibilità a pagare (Mandati)',
				ISNULL(@prev_curr_S, 0) - ISNULL(@tot_payment,0) - ISNULL(@tot_pettycashop,0) ,'S')
			IF (@proceeds = 'S')
                        Begin   
			INSERT INTO #situation VALUES('Cassa Residua (Mandati)', 
				ISNULL(@tot_proceedspart, 0) + 
				ISNULL(@tot_ff, 0) +
				ISNULL(@tot_var_proceeds, 0) - 
				ISNULL(@tot_payment, 0) -
				ISNULL(@tot_pettycashop, 0) ,'S')
                        End
		END
		FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	END
	CLOSE phase_crs1
	DEALLOCATE phase_crs1
	INSERT INTO #situation VALUES('',NULL,'H')
	INSERT INTO #situation VALUES('R I E P I L O G O  F A S I  F I N A N Z I A R I E',NULL,'N')
	DECLARE	phase_crs INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM expensephase WHERE nphase >= @nphase_fin
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM	phase_crs INTO @nphase, @desc_phase
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SET @tot_mov_C = ISNULL((SELECT amount FROM #mov_C WHERE nphase = @nphase),0)
		INSERT INTO #situation VALUES('1. Totale Movimenti competenza (' + @desc_phase +')',
			ISNULL(@tot_mov_C,0),'')
		SET @tot_var_C = ISNULL((SELECT amount FROM #var_C WHERE nphase = @nphase),0)
		INSERT INTO #situation VALUES('2. Totale Variazioni competenza (' + @desc_phase +')',
			ISNULL(@tot_var_C,0),'')
		SET @tot_mov_R = ISNULL((SELECT amount FROM #mov_R WHERE nphase = @nphase),0)
		INSERT INTO #situation VALUES('3. Totale Movimenti residui (' + @desc_phase +')',
			ISNULL(@tot_mov_R,0),'')
		SET @tot_var_R = ISNULL((SELECT amount FROM #var_R WHERE nphase = @nphase),0)
		INSERT INTO #situation VALUES('4. Totale Variazioni residui (' + @desc_phase +')',
			ISNULL(@tot_var_R,0),'')
		-- Calcolo della fase successiva per sottrarla a quella attuale
		IF @nphase < @maxphase
		BEGIN
			SELECT @next_phase_C = ISNULL(amount,0)
				FROM #mov_C
				WHERE nphase = (@nphase + 1)
			SET @next_phase_C = ISNULL(@next_phase_C,0) + 
				ISNULL((SELECT ISNULL(amount,0) FROM #var_C WHERE nphase = (@nphase + 1)),0)
	
			SELECT @next_phase_R = ISNULL(amount,0)
				FROM #mov_R
				WHERE nphase = (@nphase + 1)
			SET @next_phase_R = ISNULL(@next_phase_R,0) +
					ISNULL((SELECT ISNULL(amount,0) FROM #var_R WHERE nphase = (@nphase + 1)),0)
		END
		ELSE
		BEGIN
			SET @next_phase_C = ISNULL(@tot_payment_C,0)
			SET @next_phase_R = ISNULL(@tot_payment_R,0)
		END
		DECLARE @lbl_avail_C_exp varchar(150) -- Etichetta sulla prev. disponibile di competenza
		SELECT @lbl_avail_C_exp = 'Previsione Disponibile di Competenza (Prev. Attuale - 1 - 2'
		DECLARE @lbl_avail_S_exp varchar(150) -- Etichetta sulla prev. disponibile di cassa
		SELECT @lbl_avail_S_exp = 'Previsione Disponibile di Cassa (Prev. Attuale - 1 - 2 - 3 - 4'
	
		IF (@tot_pettycashop > 0)
		BEGIN
			INSERT INTO #situation VALUES('5. Totale Op. Fondo Economale',ISNULL(@tot_pettycashop,0),'')
			SELECT @lbl_avail_C_exp = @lbl_avail_C_exp + ' - 5'
			SELECT @lbl_avail_S_exp = @lbl_avail_S_exp + ' - 5'
		END
		SELECT @lbl_avail_C_exp = @lbl_avail_C_exp + ')'
		SELECT @lbl_avail_S_exp = @lbl_avail_S_exp + ')'
		INSERT INTO #situation VALUES(@lbl_avail_C_exp,
			ISNULL(@prev_curr_M,0) -
			ISNULL(@tot_mov_C,0) -
			ISNULL(@tot_var_C,0) -
			ISNULL(@tot_pettycashop,0) ,'S')
		INSERT INTO #situation VALUES(@lbl_avail_S_exp,
			ISNULL(@prev_curr_S,0) -
			ISNULL(@tot_mov_C,0) -
			ISNULL(@tot_var_C,0) -
			ISNULL(@tot_mov_R,0) -
			ISNULL(@tot_var_R,0) -
			ISNULL(@tot_pettycashop,0) ,'S')
		INSERT INTO #situation VALUES('('+@desc_phase+') restanti rispetto alla fase successiva in c/competenza',
			ISNULL(@tot_mov_C,0) + 
			ISNULL(@tot_var_C,0) -
			ISNULL(@next_phase_C,0),'S')
		INSERT INTO #situation VALUES('('+@desc_phase+') restanti rispetto alla fase successiva in c/residui',
			ISNULL(@tot_mov_R,0) + 
			ISNULL(@tot_var_R,0) -
			ISNULL(@next_phase_R,0),'S')
		FETCH NEXT FROM	phase_crs INTO @nphase, @desc_phase
	END
	CLOSE phase_crs
	DEALLOCATE phase_crs
	INSERT INTO #situation VALUES('Totale Mandati in c/competenza', ISNULL(@tot_payment_C,0), '')	
	INSERT INTO #situation VALUES('Totale Mandati in c/residui', ISNULL(@tot_payment_R,0),'')
	INSERT INTO #situation VALUES('Totale Mandati', ISNULL(@tot_payment,0),'S')
END
SELECT value, amount, kind FROM #situation	
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

