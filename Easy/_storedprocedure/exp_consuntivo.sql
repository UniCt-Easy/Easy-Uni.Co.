
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_consuntivo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_consuntivo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--setuser 'amm'

CREATE   PROCEDURE [exp_consuntivo]
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@levelusable tinyint,
	@idupb varchar(36),
	@showchildupb char(1),
	@officialvar varchar(1)
)
AS BEGIN
/* Versione 1.0.1 del 16/11/2007 ultima modifica: Pino */

CREATE TABLE #balance
(
	idfin int,
	codefin varchar(50),
	description varchar(150),
	printingorder varchar(31),
	initialprevision decimal(19,2),
	var_prev_M_acc decimal(19,2),
	var_prev_M_red decimal(19,2),
	secondaryprev decimal(19,2),
	var_prev_S_acc decimal(19,2),
	var_prev_S_red decimal(19,2),
	mov_finphase_C decimal(19,2),
	var_finphase_C decimal(19,2),
	mov_maxphase_C decimal(19,2),
	var_maxphase_C decimal(19,2),
	mov_finphase_R decimal(19,2),
	var_finphase_acc_R decimal(19,2),
	var_finphase_red_R decimal(19,2),
	mov_maxphase_R decimal(19,2),
	var_maxphase_R decimal(19,2)
)

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb+'%' 
END

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (E = Entrata S = Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

DECLARE @infoadvance char(1)
SELECT  @infoadvance = paramvalue
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'

DECLARE @cashvaliditykind tinyint
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
DECLARE @finphase tinyint
DECLARE @maxphase tinyint


DECLARE @idavanzocassa  int
DECLARE @idavanzoamm int

SET @idavanzocassa  = -1
SET @idavanzoamm = -2


IF (@finpart = 'E')
BEGIN
	-- ricerca la fase equivalente all'accertamento
	-- se è stata inserita nella tabella di configurazione del bilancio
	SELECT @finphase = assessmentphasecode FROM config WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		-- se non è stata inserita nella tabella di configurazione
		-- ipotizza che si tratti della fase dove viene identificata
		-- la voce di bilancio
		SELECT @finphase = incomefinphase FROM uniconfig
	END
	-- la fase di cassa è sempre l'ultima fase della procedura
	-- di entrata
	SELECT @maxphase = MAX(nphase) FROM incomephase
END
IF (@finpart = 'S')
BEGIN
	-- ricerca la fase equivalente all'impegno
	-- se è stata inserita nella tabella di configurazione
	-- del bilancio
	SELECT @finphase = appropriationphasecode FROM config WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		-- se non è stata inserita nella tabella di configurazione
		-- ipotizza che si tratti della fase dove viene identificata
		-- la voce di bilancio
		SELECT @finphase = expensefinphase FROM uniconfig
	END
	-- la fase di cassa è sempre l'ultima fase della procedura di spesa
	SELECT @maxphase = MAX(nphase) FROM expensephase
END
DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @ff_jan01 decimal(19,2)
DECLARE @aa_jan01 decimal(19,2)

IF (@finpart = 'E')
BEGIN
	-- Fondo cassa e avanzo di amministrazione presunti ed effettivi al 01/01
	-- dell'ayear per il quale si effettua il consuntivo.
	SELECT	@supposed_ff_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(proceedstilldate, 0) +
		ISNULL(proceedstoendofyear, 0) -
		ISNULL(paymentstilldate, 0) -
		ISNULL(paymentstoendofyear, 0),
	@supposed_aa_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(proceedstilldate, 0) +
		ISNULL(proceedstoendofyear, 0) -
		ISNULL(paymentstilldate, 0) -
		ISNULL(paymentstoendofyear, 0) +
		ISNULL(supposedpreviousrevenue, 0) +
		ISNULL(supposedcurrentrevenue , 0) -
		ISNULL(supposedpreviousexpenditure, 0) -
		ISNULL(supposedcurrentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 1

-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
	SELECT	@ff_jan01 = ISNULL(startfloatfund, 0) 
	FROM surplus
	WHERE ayear = @ayear
	
	SELECT
	@aa_jan01 = @ff_jan01 +
		ISNULL(previousrevenue, 0) +
		ISNULL(currentrevenue , 0) -
		ISNULL(previousexpenditure, 0) -
		ISNULL(currentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 1
END
INSERT INTO #balance
(
	idfin,
	codefin, printingorder,
	initialprevision,
	secondaryprev
)
SELECT 
	f.idfin, 
	f.codefin, f.printingorder,
	ISNULL(SUM(fy.prevision),0), 
	ISNULL(SUM(fy.secondaryprev),0)
FROM fin f
CROSS JOIN upb 
JOIN finlevel fl
	ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
LEFT OUTER JOIN finyear fy
	ON fy.idfin = f.idfin
	AND fy.idupb = upb.idupb
WHERE f.ayear = @ayear
	AND (upb.idupb LIKE @idupb)
	AND ((f.flag & 1)= @finpart_bit)
	AND (f.nlevel = @levelusable
		OR (f.nlevel < @levelusable
			AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
			AND (fl.flag&2)<>0
			)
		)
	AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
GROUP BY f.idfin, f.codefin, f.printingorder, f.nlevel

CREATE TABLE #tot_varprev_acc_M (idfin int, total decimal(19,2))
INSERT INTO #tot_varprev_acc_M
(
	idfin,
	total
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount > 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

CREATE TABLE #tot_varprev_red_M (idfin int, total decimal(19,2))
INSERT INTO #tot_varprev_red_M
(
	idfin,
	total
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount < 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)
	
CREATE TABLE #tot_varprev_acc_S (idfin int, total decimal(19,2))
INSERT INTO #tot_varprev_acc_S
(
	idfin,
	total
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND ((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount > 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

CREATE TABLE #tot_varprev_red_S (idfin int, total decimal(19,2))
INSERT INTO #tot_varprev_red_S
(
	idfin,
	total
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND ((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount < 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)


CREATE TABLE #mov_finphase_C (idfin int, total decimal(19,2))
CREATE TABLE #var_finphase_C (idfin int, total decimal(19,2))
CREATE TABLE #mov_finphase_R (idfin int, total decimal(19,2))
CREATE TABLE #var_finphase_acc_R (idfin int, total decimal(19,2))
CREATE TABLE #var_finphase_red_R (idfin int, total decimal(19,2))
CREATE TABLE #mov_maxphase_C (idfin int, total decimal(19,2))
CREATE TABLE #var_maxphase_C (idfin int, total decimal(19,2))
CREATE TABLE #mov_maxphase_R (idfin int, total decimal(19,2))
CREATE TABLE #var_maxphase_R (idfin int, total decimal(19,2))
IF (@finpart = 'E')
BEGIN
	INSERT INTO #mov_finphase_C
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(IY.amount),0)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE I.adate <= @date
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #var_finphase_C
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND IV.adate <= @date 
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #mov_finphase_R
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(IY.amount),0)
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IY.ayear = @ayear
		AND IY.idupb LIKE @idupb
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND I.adate <= @date
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #var_finphase_acc_R
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND IV.amount > 0
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #var_finphase_red_R
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND IV.amount < 0
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #mov_maxphase_C
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND HPV.idupb LIKE @idupb
		AND HPV.flagarrear = 'C'
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

	INSERT INTO #mov_maxphase_R
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND HPV.idupb LIKE @idupb
		AND HPV.flagarrear = 'R'
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #var_maxphase_C
		(
			idfin,
			total
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND HPV.idupb LIKE @idupb
			AND IV.adate <= @date
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)
	
		INSERT INTO #var_maxphase_R
		(
			idfin,
			total
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND HPV.idupb LIKE @idupb
			AND IV.adate <= @date
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)
	END
END
IF @finpart = 'S'
BEGIN

	INSERT INTO #mov_finphase_C
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(EY.amount),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE E.adate <= @date
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #var_finphase_C
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND EV.adate <= @date 
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #mov_finphase_R
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(EY.amount),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE E.adate <= @date
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1)
		AND E.nphase = @finphase
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #var_finphase_acc_R
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND EV.adate <= @date 
		AND EV.amount > 0
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #var_finphase_red_R
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND EV.adate <= @date 
		AND EV.amount < 0
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #mov_maxphase_C
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND HPV.idupb LIKE @idupb
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

	INSERT INTO #mov_maxphase_R
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND HPV.idupb LIKE @idupb	
		AND ( (HPV.totflag & 1) = 1) -- Residuo
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #var_maxphase_C
		(
			idfin,
			total
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND  HPV.idupb LIKE @idupb
			AND EV.adate <= @date
			AND ( (HPV.totflag & 1) = 0)--Competenza
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY  HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)
	
		INSERT INTO #var_maxphase_R
		(
			idfin,
			total
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND  HPV.idupb LIKE @idupb
			AND EV.adate <= @date
			AND ( (HPV.totflag & 1) = 1)--Residuo
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY  HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)
	END
END

UPDATE #balance
SET var_prev_m_acc =
ISNULL(
	(SELECT SUM(#tot_varprev_acc_M.total) FROM #tot_varprev_acc_M
	WHERE #tot_varprev_acc_M.idfin = #balance.idfin)
, 0),
var_prev_m_red = 
ISNULL(
	(SELECT SUM(#tot_varprev_red_M.total) FROM #tot_varprev_red_M
	WHERE #tot_varprev_red_M.idfin = #balance.idfin),
0),
var_prev_s_acc =
ISNULL(
	(SELECT SUM(#tot_varprev_acc_S.total) FROM #tot_varprev_acc_S
	WHERE #tot_varprev_acc_S.idfin = #balance.idfin),
0),
var_prev_s_red =
ISNULL(
	(SELECT SUM(#tot_varprev_red_S.total) FROM #tot_varprev_red_S
	WHERE #tot_varprev_red_S.idfin = #balance.idfin), 0),
mov_finphase_C =
ISNULL(
	(SELECT SUM(#mov_finphase_C.total) FROM #mov_finphase_C
	WHERE #mov_finphase_C.idfin = #balance.idfin)
, 0),
var_finphase_C =
ISNULL(
	(SELECT SUM(#var_finphase_C.total) FROM #var_finphase_C
	WHERE #var_finphase_C.idfin = #balance.idfin)
, 0),
mov_maxphase_C =
ISNULL(
	(SELECT SUM(#mov_maxphase_C.total) FROM #mov_maxphase_C
	WHERE #mov_maxphase_C.idfin = #balance.idfin)
, 0),
var_maxphase_C =
ISNULL(
	(SELECT SUM(#var_maxphase_C.total) FROM #var_maxphase_C
	WHERE #var_maxphase_C.idfin = #balance.idfin)
, 0),
mov_finphase_R =
ISNULL(
	(SELECT SUM(#mov_finphase_R.total) FROM #mov_finphase_R
	WHERE #mov_finphase_R.idfin = #balance.idfin)
, 0),
var_finphase_acc_R =
ISNULL(
	(SELECT SUM(#var_finphase_acc_R.total) FROM #var_finphase_acc_R
	WHERE #var_finphase_acc_R.idfin = #balance.idfin)
, 0),
var_finphase_red_R =
ISNULL(
	(SELECT SUM(#var_finphase_red_R.total) FROM #var_finphase_red_R
	WHERE #var_finphase_red_R.idfin = #balance.idfin)
, 0),
mov_maxphase_R =
ISNULL(
	(SELECT SUM(#mov_maxphase_R.total) FROM #mov_maxphase_R
        WHERE #mov_maxphase_R.idfin = #balance.idfin)
, 0),
var_maxphase_R =
ISNULL(
	(SELECT SUM(#var_maxphase_R.total) FROM #var_maxphase_R
	WHERE #var_maxphase_R.idfin = #balance.idfin)
, 0)

DECLARE @supposed_cash_jan01 decimal(19,2)
DECLARE @cash_jan01 decimal(19,2)
DECLARE @supposed_amm_jan01 decimal(19,2)
DECLARE @var_ff_acc decimal(19,2)
DECLARE @var_ff_red decimal(19,2)
DECLARE @var_aa_acc decimal(19,2)
DECLARE @var_aa_red decimal(19,2)

DECLARE @fin_kind tinyint
SELECT  @fin_kind = fin_kind
FROM    config
WHERE   ayear = @ayear
print   @fin_kind
-- Competenza Pura
IF (@fin_kind = 1)
BEGIN 
	IF (@finpart = 'E')
	BEGIN   
		IF (@infoadvance <> 'N')
		BEGIN
			IF (@aa_jan01 > 0)
			BEGIN
				SET @supposed_amm_jan01 = @supposed_aa_jan01
				IF (@aa_jan01 - @supposed_aa_jan01) >0 
				BEGIN
					SET @var_aa_acc = (@aa_jan01 - @supposed_aa_jan01)
					SET @var_aa_red = 0
				END
				ELSE
				BEGIN
					SET @var_aa_acc = 0
					SET @var_aa_red = (@aa_jan01 - @supposed_aa_jan01)
				END
			END
		ELSE
		BEGIN
			SET @supposed_amm_jan01 = 0
			SET @var_aa_acc = 0
			SET @var_aa_red = 0
		END
		-- Inserisce la riga relativa all'avanzo di amministrazione
		INSERT INTO #balance
		(
			idfin, codefin, description, 
			initialprevision,
			var_prev_M_acc,
			var_prev_M_red
		)
		VALUES
		(
			@idavanzoamm , ' ', 'Avanzo di Amministrazione', ---avanzo amministrazione 0
			@supposed_amm_jan01,
			@var_aa_acc,
			@var_aa_red)
	END
	
	SELECT
		CASE
			WHEN #balance.idfin = @idavanzoamm   ---avanzo amministrazione 0
			THEN #balance.codefin
			ELSE fin.codefin
		END AS 'Codice Bilancio',
		CASE
			WHEN #balance.idfin = @idavanzoamm   ---avanzo amministrazione 0
			THEN #balance.description
			ELSE fin.title
		END AS 'Denominazione',
		initialprevision AS 'Prev. di competenza iniziale', 
		var_prev_M_acc AS 'Var. aumento prev. Competenza',
		- var_prev_M_red AS 'Var. dimin. prev. Competenza',
		(initialprevision + var_prev_M_acc + var_prev_M_red)  AS 'Prev. Competenza Definitiva',
		(mov_maxphase_C + var_maxphase_C) AS 'Accertamenti riscossi',
		(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C) AS 'Accertamenti da riscuotere',
		(mov_finphase_C + var_finphase_C) AS 'Totale somme accertate',
		CASE #balance.idfin
			WHEN @idavanzoamm  THEN NULL
			ELSE (initialprevision + var_prev_M_acc + var_prev_M_red - mov_finphase_C - var_finphase_C)
		END AS 'Differenza rispetto alle previsioni',
		mov_finphase_R AS 'Residui Attivi Iniziali' ,
		(mov_maxphase_R + var_maxphase_R) AS 'Residui Attivi Riscossi',
		(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Residui Attivi da riscuotere',
		(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R) AS 'Totale Residui Attivi',
		var_finphase_acc_R AS 'Var. aumento residui attivi',
		- var_finphase_red_R AS 'Var. diminuzione residui attivi' ,
		(var_finphase_acc_R + var_finphase_red_R) AS 'Totale Variazioni Residui Attivi',
		(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C + mov_finphase_R + var_finphase_acc_R + var_finphase_red_R  - mov_maxphase_R - var_maxphase_R) AS 'Tot. res. attivi a fine esercizio'
	FROM #balance
	LEFT OUTER JOIN fin
		ON fin.idfin = #balance.idfin
	ORDER BY #balance.codefin ASC
END
	IF (@finpart = 'S')
	BEGIN
		SELECT
			fin.codefin AS 'Codice Bilancio',
			fin.title AS 'Denominazione',
			initialprevision AS 'Prev. di competenza iniziale', 
			var_prev_M_acc  AS 'Var. aumento prev. competenza',
			- var_prev_M_red  AS 'Var. dimin. prev. competenza',
			(initialprevision + var_prev_M_acc + var_prev_M_red)  AS 'Prev. competenza definitiva',
			(mov_maxphase_C + var_maxphase_C) AS 'Somme impegnate pagate',
			(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C) AS 'Somme impegnate da pagare',
			(mov_finphase_C + var_finphase_C) AS 'Totale somme impegnate',
			(initialprevision + var_prev_M_acc + var_prev_M_red - mov_finphase_C-var_finphase_C) AS 'Differenza rispetto alle previsioni',
			mov_finphase_R AS 'Residui passivi iniziali' ,
			(mov_maxphase_R + var_maxphase_R) AS 'Residui passivi riscossi',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Residui Passivi da riscuotere',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R) AS 'Totale residui passivi',
			var_finphase_acc_R  AS 'Var. residui passivi in aumento',
			-var_finphase_red_R  AS 'Var. residui passivi in diminuzione',
			(var_finphase_acc_R + var_finphase_red_R) AS 'Totale variazioni residui passivi',
			(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C + mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Tot. res. passivi a fine esercizio'
		FROM #balance
		LEFT OUTER JOIN fin
			ON fin.idfin = #balance.idfin
		ORDER BY #balance.codefin ASC
	END
END 
-- Cassa Pura
IF @fin_kind = 2
BEGIN 
	IF @finpart = 'E'
	BEGIN 
		IF @infoadvance <> 'N'
		BEGIN
			IF @ff_jan01 > 0
			BEGIN
				SET @supposed_cash_jan01 =@supposed_ff_jan01
				SET @cash_jan01 =@ff_jan01
				IF (@ff_jan01 - @supposed_ff_jan01) >0 
					BEGIN
					SET @var_ff_acc = (@ff_jan01 - @supposed_ff_jan01)
					SET @var_ff_red = 0
	      		 	END
				ELSE
				BEGIN
					SET @var_ff_acc = 0
					SET @var_ff_red = (@ff_jan01 - @supposed_ff_jan01)
				END
			END
			ELSE
			BEGIN
			  	SET @supposed_cash_jan01 =0
				SET @cash_jan01 =0
			  	SET @var_ff_acc =0
	  		 	SET @var_ff_red =0
			END
			INSERT INTO #balance
			(
				idfin, codefin, description,
				initialprevision, var_prev_M_acc, var_prev_M_red, mov_maxphase_C) -- Fondo cassa effettivo nella colonna  Totale Riscossioni  
			VALUES
			(
				@idavanzocassa , ' ', 'Avanzo di Cassa',
				@supposed_cash_jan01, @var_ff_acc, @var_ff_red, @cash_jan01
			)
		END
		SELECT  
			CASE
				WHEN #balance.idfin = @idavanzocassa
				THEN #balance.codefin
				ELSE fin.codefin
			END AS 'Codice Bilancio',
			CASE
				WHEN #balance.idfin = @idavanzocassa
				THEN #balance.description
				ELSE fin.title
			END AS 'Denominazione',
			initialprevision AS 'Prev. di cassa iniziale', 
			var_prev_M_acc AS 'Var. aumento prev. cassa',
			-var_prev_M_red AS 'Var. dimin. prev. cassa',
			(initialprevision + var_prev_M_acc + var_prev_M_red) AS 'Prev. cassa definitiva',
			(mov_finphase_C + var_finphase_C) AS 'Totale Somme Accertate',
			CASE #balance.idfin
				WHEN @idavanzocassa   THEN mov_maxphase_C
				ELSE (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R)
			END AS 'Totale Riscossioni',
			CASE #balance.idfin 
				WHEN @idavanzocassa   THEN NULL
				ELSE (initialprevision + var_prev_M_acc + var_prev_M_red) -  (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R)
			END AS 'Differenza rispetto alle previsioni'
		FROM #balance
		LEFT OUTER JOIN fin
			ON fin.idfin = #balance.idfin
		ORDER BY #balance.codefin ASC
	END
	IF (@finpart = 'S')
	BEGIN
		SELECT
			fin.codefin AS 'Codice Bilancio',
			fin.title AS 'Denominazione',
			initialprevision AS 'Prev. di cassa iniziale', 
			var_prev_M_acc AS 'Var. aumento prev. cassa',
			-var_prev_M_red AS 'Var. dimin. prev. cassa',
			(initialprevision + var_prev_M_acc + var_prev_M_red) AS 'Prev. cassa definitiva',
			(mov_finphase_C + var_finphase_C) AS 'Totale Somme Impegnate',
			(mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R) AS 'Totale Pagamenti',
			(initialprevision + var_prev_M_acc + var_prev_M_red) - (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R) AS 'Differ. rispetto alle previsioni'	 
		FROM #balance
		LEFT OUTER JOIN fin
			ON fin.idfin = #balance.idfin
		ORDER BY #balance.codefin ASC
	END
END
-- Compentenza e Cassa
IF (@fin_kind = 3)
BEGIN 
	IF (@finpart = 'E')
	BEGIN
		IF @infoadvance <> 'N'
		BEGIN
			IF (@aa_jan01 > 0)
			BEGIN
				SET @supposed_amm_jan01 =@supposed_aa_jan01
				IF (@aa_jan01 - @supposed_aa_jan01) >0 
				BEGIN
					SET @var_aa_acc = (@aa_jan01 - @supposed_aa_jan01)
					SET @var_aa_red = 0
				END
				ELSE
				BEGIN
					SET @var_aa_acc = 0
					SET @var_aa_red = (@aa_jan01 - @supposed_aa_jan01)
				END
			END
			ELSE
			BEGIN
				SET @supposed_amm_jan01 = 0
				SET @var_aa_acc = 0
				SET @var_aa_red = 0
			END
			INSERT INTO #balance
			(
				idfin, codefin, description,
				initialprevision, var_prev_M_acc, var_prev_M_red
			)
			VALUES
			(
				@idavanzoamm , ' ', 'Avanzo di Amministrazione',   ---avanzo amministrazione 0
				@supposed_amm_jan01, @var_aa_acc, @var_aa_red
			)
			IF (@ff_jan01 > 0)
			BEGIN
				SET @supposed_cash_jan01 =@supposed_ff_jan01
				SET @cash_jan01 =@ff_jan01
				IF (@ff_jan01 - @supposed_ff_jan01) >0 
				BEGIN
					SET @var_ff_acc = (@ff_jan01 - @supposed_ff_jan01)
					SET @var_ff_red = 0
				END
				ELSE
				BEGIN
					SET @var_ff_acc = 0
					SET @var_ff_red = (@ff_jan01 - @supposed_ff_jan01)
				END
			END
			ELSE
			BEGIN
				SET @supposed_cash_jan01 = 0
				SET @cash_jan01 = 0
				SET @var_ff_acc = 0
				SET @var_ff_red = 0
			END
			INSERT INTO #balance
			(
				idfin, codefin, description,
				secondaryprev, var_prev_S_acc, var_prev_S_red, mov_maxphase_C
			) --Fondo cassa effettivo nella colonna  Totale Riscossioni
			VALUES
			(
				@idavanzocassa  , ' ', 'Avanzo di Cassa',  ---Avanzo di cassa null
				@supposed_cash_jan01, @var_ff_acc, @var_ff_red, @cash_jan01
			)
		END
		SELECT
			CASE
				WHEN #balance.idfin = @idavanzoamm  THEN #balance.codefin
				WHEN #balance.idfin = @idavanzocassa   THEN #balance.codefin
				ELSE fin.codefin
			END AS 'Codice Bilancio',
			CASE
				WHEN #balance.idfin = @idavanzoamm  THEN #balance.description
				WHEN #balance.idfin = @idavanzocassa   THEN #balance.description
				ELSE fin.title
			END AS 'Denominazione',
			initialprevision AS 'Prev. competenza iniziale', 
			var_prev_M_acc AS 'Var. aumento prev. competenza',
			-var_prev_M_red AS 'Var. dimin. prev. competenza',
			(initialprevision + var_prev_M_acc + var_prev_M_red)  AS 'Prev. competenza definitiva',
			CASE #balance.idfin
				WHEN @idavanzocassa  THEN NULL
				ELSE (mov_maxphase_C+var_maxphase_C)
			END AS 'Accertamenti riscossi',
			CASE #balance.idfin
				WHEN @idavanzocassa   THEN NULL
				ELSE (mov_finphase_C+var_finphase_C - mov_maxphase_C - var_maxphase_C)
			END AS 'Accertamenti da riscuotere',
			(mov_finphase_C + var_finphase_C) AS 'Totale somme accertate',
			CASE #balance.idfin
				WHEN @idavanzocassa   THEN NULL
				ELSE (initialprevision + var_prev_M_acc + var_prev_M_red - mov_finphase_C-var_finphase_C)
			END AS 'Differenza rispetto alle previsioni (comp.)',
			secondaryprev AS 'Prev. cassa iniziale', 
			var_prev_S_acc AS 'Var. aumento prev. cassa',
			-var_prev_S_red AS 'Var. dimin. prev. cassa',
			(secondaryprev + var_prev_S_acc + var_prev_S_red) AS 'Prev. cassa definitiva' ,
			CASE #balance.idfin
				WHEN @idavanzocassa   THEN mov_maxphase_C
				ELSE (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R)
			END AS 'Totale Riscossioni',
			CASE #balance.idfin
				WHEN @idavanzocassa   THEN NULL
				ELSE (secondaryprev + var_prev_S_acc + var_prev_S_red)- (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R)
			END AS 'Differenza rispetto alle previsioni (cassa)',
			mov_finphase_R AS 'Residui Attivi Iniziali' ,
			(mov_maxphase_R + var_maxphase_R) AS 'Residui Attivi Riscossi',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Residui Attivi da riscuotere',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R) AS 'Totale Residui Attivi',
			var_finphase_acc_R  AS 'Var. residui attivi in aumento',
			-var_finphase_red_R  AS 'Var. residui attivi in diminuzione',
			(var_finphase_acc_R + var_finphase_red_R) AS 'Totale Variazioni Residui Attivi',
			CASE #balance.idfin
				WHEN @idavanzocassa  THEN NULL
				ELSE (mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C + mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R)
			END AS 'Tot. res. attivi a fine esercizio'
		FROM #balance
		LEFT OUTER JOIN fin
			ON fin.idfin = #balance.idfin
		ORDER BY #balance.codefin ASC
	END
	IF(@finpart = 'S')
	BEGIN
		SELECT
			fin.codefin AS 'Codice Bilancio',
			fin.title AS 'Denominazione',
			initialprevision AS 'Prev. competenza iniziale', 
			var_prev_M_acc AS 'Var. aumento prev. competenza',
			-var_prev_M_red AS 'Var. dimin. prev. competenza',
			(initialprevision + var_prev_M_acc + var_prev_M_red)  AS 'Prev. competenza definitiva',
			(mov_maxphase_C + var_maxphase_C) AS 'Somme impegnate pagate',
			(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C) AS 'Somme impegnate da pagare',
			(mov_finphase_C + var_finphase_C) AS 'Totale somme impegnate',
			(initialprevision + var_prev_M_acc + var_prev_M_red - mov_finphase_C-var_finphase_C) AS 'Differenza rispetto alle previsioni (comp.)',	 
			secondaryprev AS 'Prev. cassa iniziale', 
			var_prev_S_acc AS 'Var. aumento prev. cassa',
			-var_prev_S_red AS 'Var. dimin. prev. cassa',
			(secondaryprev + var_prev_S_acc + var_prev_S_red)  AS 'Prev. cassa definitiva',
			(mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R) AS 'Totale Pagamenti',
			(secondaryprev + var_prev_S_acc + var_prev_S_red)- (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R) AS 'Differenza rispetto alle previsioni (cassa)',   	
			mov_finphase_R AS 'Residui Passivi Iniziali' ,
			(mov_maxphase_R + var_maxphase_R) AS 'Residui Passivi Pagati',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Residui Passivi da pagare',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R) AS 'Totale Residui Passivi',
			var_finphase_acc_R AS 'Var. residui passivi in aumento',
			-var_finphase_red_R AS 'Var. residui passivi in diminuzione',
			(var_finphase_acc_R + var_finphase_red_R) AS 'Totale Variazioni Residui Passivi',
			(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C + mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Tot. res. passivi a fine esercizio'
		FROM #balance
		LEFT OUTER JOIN fin
			ON fin.idfin = #balance.idfin
		ORDER BY #balance.codefin ASC
	END
END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
