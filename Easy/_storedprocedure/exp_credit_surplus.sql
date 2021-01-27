
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_credit_surplus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_credit_surplus]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



--	Calcolo ripartizione avanzo di amministrazione
CREATE  PROCEDURE [exp_credit_surplus]
	@ayear int,
	@adate	smalldatetime,
	@levelusable tinyint,
	@showupb char(1),
	@idupb varchar(36),
	@showchildupb char(1),
	@suppressifblank char(1)
AS
BEGIN

/* Versione 1.0.1 del 05/11/2007 ultima modifica: SARA */

SET @showupb = upper(@showupb)
SET @showchildupb = upper(@showchildupb)
SET @suppressifblank = upper (@suppressifblank)

DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END
		
CREATE TABLE #credit_surplus
(
	idfin int,
	codefin varchar(50),
	fin varchar(200),
	idupb varchar(36),
	codeupb varchar(50),
	upb varchar(150),

	prevision decimal(19,2),
	var_prevision_A decimal(19,2),
	var_prevision_D decimal(19,2),

	secondaryprev decimal(19,2),
	var_secondaryprev_A decimal(19,2),
	var_secondaryprev_D decimal(19,2),

	currentarrears decimal(19,2),
	mov_finphase_C decimal(19,2),
	var_finphase_C decimal(19,2),

	mov_maxphase_C	decimal(19,2),
	var_maxphase_C decimal(19,2),

	mov_finphase_R decimal(19,2),
	var_finphase_R decimal(19,2),

	mov_maxphase_R decimal(19,2),
	var_maxphase_R decimal(19,2),

	creditpart decimal(19,2),
	creditvariation decimal(19,2),

	proceedspart decimal(19,2),
	proceedsvariation decimal(19,2),

	proceeds_maxphase_C decimal(19,2),
	proceeds_maxphase_R decimal(19,2)
)



DECLARE @data varchar(13)
SET @data = CONVERT(varchar(10),@adate,5)

DECLARE @infoadvance char(1)
SELECT @infoadvance = paramvalue
FROM reportadditionalparam
WHERE reportname = 'consentr' AND paramname = 'MostraAvanzo'

DECLARE @cashvaliditykind tinyint
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
-- ricerca la fase equivalente all'impegno
-- se è stata inserita nella tabella di configurazione
-- del bilancio

DECLARE @finphase tinyint
SELECT  @finphase = appropriationphasecode
FROM 	config
WHERE 	ayear = @ayear

-- Se non è stata inserita nella tabella di configurazione ipotizza che si tratti della fase dove viene identificata
-- la voce di bilancio
IF @finphase IS NULL
BEGIN
	SELECT @finphase = expensefinphase
	FROM uniconfig
END

-- La fase di cassa è sempre l'ultima fase della procedura  di spesa
DECLARE @maxexpensephase tinyint
SELECT 	@maxexpensephase = MAX(nphase) FROM expensephase

DECLARE @maxincomephase  tinyint
SELECT 	@maxincomephase = MAX(nphase) FROM incomephase

-- Se @fin_kind = 1 ==> è stata personalizzata una  previsione principale di tipo "competenza", se @fin_kind = 2
-- ==> è stata personalizzata una previsione principale di tipo "cassa", se  @fin_kind = 3 ==> è stata personalizzata una
-- previsione principale di tipo "altra previsione". 
DECLARE @fin_kind tinyint
SELECT  @fin_kind = fin_kind  FROM config WHERE ayear = @ayear

DECLARE @lencod_lev1 int
SELECT  @lencod_lev1 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 1

DECLARE @startpos1 int
SET @startpos1 = 1

DECLARE @startpos2 int
SET @startpos2 = @startpos1 + @lencod_lev1

DECLARE @lencod_lev2 int
SELECT @lencod_lev2 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 2

DECLARE @startpos3 int
SET @startpos3 = @startpos2 + @lencod_lev2

DECLARE @lencod_lev3 int
SELECT @lencod_lev3 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 3

DECLARE @startpos4 int
SET @startpos4 = @startpos3 + @lencod_lev3

DECLARE @lencod_lev4 int
SELECT @lencod_lev4 = flag /256  FROM finlevel  WHERE ayear = @ayear AND nlevel = 4
	

INSERT INTO #credit_surplus
	(
	idfin,
	codefin,
	fin,
	idupb,
	codeupb,
	upb,
	--flagincomesurplus,
	prevision,
	secondaryprev,
	currentarrears
	)
SELECT  f.idfin, 
	f.codefin, 
	f.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	ISNULL(finyear.prevision,0), 
	ISNULL(finyear.secondaryprev,0) ,
	ISNULL(finyear.currentarrears,0)
FROM fin f
CROSS JOIN upb 
JOIN finlevel fl
	ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
LEFT OUTER JOIN finyear
	ON finyear.idfin = f.idfin
	AND finyear.idupb = upb.idupb
WHERE f.ayear = @ayear
	AND (upb.idupb LIKE @idupb)	
	AND ((f.flag & 1)= 1)
	AND (f.nlevel = @levelusable
		OR (f.nlevel < @levelusable
		AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
			AND (fl.flag&2)<>0
			)	
		)
UPDATE #credit_surplus
SET  	creditpart = (SELECT ISNULL(SUM(totcreditpart),0)
	FROM upbtotal UT	
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
	WHERE UT.idupb = #credit_surplus.idupb
		AND ISNULL(FLK.idparent,UT.idfin) = #credit_surplus.idfin
		
	),
	proceedspart	 = (SELECT ISNULL(SUM(totproceedspart),0)  
		FROM upbtotal UT	
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
		WHERE UT.idupb = #credit_surplus.idupb
			AND ISNULL(FLK.idparent,UT.idfin) = #credit_surplus.idfin
		)

DECLARE @minoplevel tinyint
SELECT  @minoplevel = MIN(nlevel) FROM finlevel WHERE ayear = @ayear AND (flag&2) <> 0


IF @levelusable > @minoplevel
BEGIN 
-- articolo 4>3
UPDATE #credit_surplus
SET  		
	creditvariation = (SELECT ISNULL(SUM(creditvariation),0) 
		FROM upbtotal UT	
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
		WHERE UT.idupb = #credit_surplus.idupb
			AND ISNULL(FLK.idparent,UT.idfin) = #credit_surplus.idfin
		),
	proceedsvariation =
		(SELECT ISNULL(SUM(proceedsvariation),0) 
		FROM upbtotal UT	
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
		WHERE UT.idupb = #credit_surplus.idupb
			AND ISNULL(FLK.idparent,UT.idfin) = #credit_surplus.idfin 
		)
END
ELSE 
BEGIN 
-- capitolo
UPDATE #credit_surplus
SET  		
	creditvariation = (SELECT ISNULL(SUM(creditvariation),0) 
		FROM upbtotal UT	
		JOIN finlink FLK
			ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
		WHERE UT.idupb = #credit_surplus.idupb
			AND FLK.idchild = #credit_surplus.idfin
		),
	proceedsvariation =
		(SELECT ISNULL(SUM(proceedsvariation),0) 
		FROM upbtotal UT	
		JOIN finlink FLK
			ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
		WHERE UT.idupb = #credit_surplus.idupb
			AND FLK.idchild = #credit_surplus.idfin 
		)
END

-- calcolo del totale delle variazioni della  previsione principale
CREATE TABLE #var_prevision_A(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_prevision_A
(
idupb,
idfin,
totale
)
SELECT FVD.idupb,
	ISNULL(FLK.idparent,FVD.idfin),
	SUM(ISNULL(FVD.amount, 0)) 
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @adate
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount > 0
	AND ((F.flag & 1 ) = 1) AND F.ayear = @ayear
	AND (FVD.idupb like @idupb )
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

CREATE TABLE #var_prevision_D(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_prevision_D
(
idupb,
idfin,
totale
)
SELECT	FVD.idupb,
	ISNULL(FLK.idparent,FVD.idfin),
	-(SUM(ISNULL(FVD.amount, 0))) 
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @adate
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount < 0
	AND ((F.flag & 1 ) = 1) AND F.ayear = @ayear
	AND (FVD.idupb like @idupb )
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

-- calcolo del totale delle variazioni della  previsione secondaria
CREATE TABLE #var_secondaryprev_A(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_secondaryprev_A
(
idupb,
idfin,
totale
)
SELECT
	FVD.idupb,
	ISNULL(FLK.idparent,FVD.idfin),
	ABS(SUM(ISNULL(FVD.amount, 0))) 
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @adate
	AND FV.flagsecondaryprev = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount > 0
	AND ((F.flag & 1 ) = 1) AND F.ayear = @ayear
	AND (FVD.idupb like @idupb )
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

-- calcolo del totale delle variazioni della  previsione secondaria
CREATE TABLE #var_secondaryprev_D(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_secondaryprev_D
(
	idupb,
	idfin,
	totale
)
SELECT
	FVD.idupb,
	ISNULL(FLK.idparent,FVD.idfin),
	ABS(SUM(ISNULL(FVD.amount, 0)))
FROM finvardetail FVD
JOIN finvar FV 
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @adate
	AND FV.flagsecondaryprev = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount < 0
	AND ((F.flag & 1 ) = 1) AND F.ayear = @ayear
	AND (FVD.idupb like @idupb )
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)
	
CREATE TABLE #mov_finphase_C(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #mov_finphase_C
(
	idupb,
	idfin,
	totale
)
SELECT	EY.idupb,
	ISNULL(FLK.idparent,EY.idfin),
	SUM(ISNULL(EY.amount, 0))
FROM expense E
JOIN expenseyear EY 
	ON EY.idexp = E.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE E.adate <= @adate
	AND EY.ayear = @ayear
	AND ( (ET.flag & 1) = 0) -- Competenza
	AND E.nphase = @finphase
	AND (EY.idupb like @idupb )
GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

CREATE TABLE #var_finphase_C(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_finphase_C
(
	idupb,
	idfin,
	totale
)
SELECT 
	EY.idupb,
	ISNULL(FLK.idparent,EY.idfin),
	SUM(ISNULL(EV.amount, 0))
FROM expensevar EV
JOIN expense E
	ON EV.idexp = E.idexp
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE EV.yvar = @ayear
	AND EV.adate <= @adate 
	AND EY.ayear = @ayear
	AND ( (ET.flag & 1) = 0) -- Competenza
	AND E.nphase = @finphase
	AND (EY.idupb like @idupb )
GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

CREATE TABLE #mov_finphase_R(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #mov_finphase_R
(
	idupb,
	idfin,
	totale
)
SELECT
	EY.idupb,
	ISNULL(FLK.idparent,EY.idfin),
	SUM(ISNULL(EY.amount, 0))
FROM expenseyear EY
JOIN expense E
	ON E.idexp = EY.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE EY.ayear = @ayear
	AND ( (ET.flag & 1) = 1) -- Residuo
	AND E.nphase = @finphase
	AND E.adate <= @adate
	AND (EY.idupb like @idupb )
GROUP BY  EY.idupb,ISNULL(FLK.idparent,EY.idfin)

CREATE TABLE #var_finphase_R(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_finphase_R
(
	idupb,
	idfin,
	totale
)
SELECT 
	EY.idupb,
	ISNULL(FLK.idparent,EY.idfin),
	SUM(ISNULL(EV.amount, 0))
FROM expensevar EV
JOIN expense E
	ON EV.idexp = E.idexp
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE EV.yvar = @ayear
	AND EV.adate <= @adate 
	AND EY.ayear = @ayear
	AND ( (ET.flag & 1) = 1) -- Residuo
	AND E.nphase = @finphase
	AND (EY.idupb like @idupb )
GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

CREATE TABLE #proceeds_maxphase_C(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #proceeds_maxphase_C
(
	idupb,
	idfin,
	totale
)
SELECT 
	PP.idupb,
	ISNULL(FLK.idparent,PP.idfin),
	SUM(ISNULL(PP.amount, 0))
FROM proceedspart PP 
JOIN incomeyear IY 
	ON IY .idinc = PP.idinc
JOIN incometotal IT
	ON IT.idinc = IY.idinc
	AND IT.ayear = IY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = PP.idfin AND FLK.nlevel = @levelusable
WHERE PP.yproceedspart = @ayear
	AND PP.adate <= @adate 
	AND IY.ayear = @ayear
	AND ( (IT.flag & 1) = 0)-- Competenza
	-- AND IY.nphase = @maxincomephase
	AND (PP.idupb like @idupb )
GROUP BY PP.idupb,ISNULL(FLK.idparent,PP.idfin)

CREATE TABLE #proceeds_maxphase_R(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #proceeds_maxphase_R
(
	idupb,
	idfin,
	totale
)
SELECT 
	IY.idupb,
	ISNULL(FLK.idparent,PP.idfin),
	SUM(ISNULL(PP.amount, 0))
FROM proceedspart PP 
JOIN incomeyear IY 
	ON IY .idinc = PP.idinc
JOIN incometotal IT
	ON IT.idinc = IY.idinc
	AND IT.ayear = IY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = PP.idfin AND FLK.nlevel = @levelusable
WHERE PP.yproceedspart = @ayear
	AND PP.adate <= @adate 
	AND IY.ayear = @ayear
	AND ( (IT.flag & 1) = 1)-- Residuo
	-- AND IY.nphase = @maxincomephase
	AND (IY.idupb like @idupb )
GROUP BY IY.idupb,ISNULL(FLK.idparent,PP.idfin)

CREATE TABLE #mov_maxphase_C(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #mov_maxphase_C
(
	idupb,
	idfin,
	totale
)
SELECT
	HPV.idupb,	
	ISNULL(FLK.idparent,HPV.idfin),
	SUM(HPV.amount)
FROM historypaymentview HPV
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable	
WHERE HPV.competencydate <= @adate
	AND HPV.ymov = @ayear
	AND HPV.flagarrear = 'C'
GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

CREATE TABLE #mov_maxphase_R(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #mov_maxphase_R
	(
	idupb,
	idfin,
	totale
	)
SELECT
	HPV.idupb,	
	ISNULL(FLK.idparent,HPV.idfin),
	SUM(HPV.amount)
FROM historypaymentview HPV		
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable	
WHERE HPV.competencydate <= @adate
	AND HPV.ymov = @ayear
	AND HPV.flagarrear = 'R'
GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

IF (@cashvaliditykind <> 4)
BEGIN
	CREATE TABLE #var_maxphase_C(idupb varchar(36),idfin int,totale decimal(19,2))
	INSERT INTO #var_maxphase_C
		(
		idupb,
		idfin,
		totale
		)
	SELECT 	HPV.idupb,
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(ISNULL(EV.amount, 0))
	FROM expensevar EV 
	JOIN historypaymentview HPV
		ON HPV.idexp = EV.idexp
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EV.adate <= @adate
		AND ( (HPV.totflag & 1) = 0)--Competenza
		AND HPV.competencydate <= @adate
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

	CREATE TABLE #var_maxphase_R(idupb varchar(36),idfin int,totale decimal(19,2))
	INSERT INTO #var_maxphase_R
	(
		idupb,
		idfin,
		totale
	)
	SELECT 	HPV.idupb,
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(ISNULL(EV.amount, 0))
	FROM expensevar EV 
	JOIN historypaymentview HPV
		ON HPV.idexp = EV.idexp
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EV.adate <= @adate
		AND ( (HPV.totflag & 1) = 1 )
		AND HPV.competencydate <= @adate
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

END


UPDATE #credit_surplus
SET 
	var_prevision_A = ISNULL((SELECT #var_prevision_A.totale FROM #var_prevision_A
				WHERE #var_prevision_A.idfin = #credit_surplus.idfin
				and #var_prevision_A.idupb = #credit_surplus.idupb), 0),

	var_prevision_D = ISNULL((SELECT #var_prevision_D.totale FROM #var_prevision_D
				WHERE #var_prevision_D.idfin = #credit_surplus.idfin 
				and #var_prevision_D.idupb = #credit_surplus.idupb), 0),

	var_secondaryprev_A = ISNULL((SELECT #var_secondaryprev_A.totale FROM #var_secondaryprev_A
				WHERE #var_secondaryprev_A.idfin = #credit_surplus.idfin
				and #var_secondaryprev_A.idupb = #credit_surplus.idupb), 0),

	var_secondaryprev_D = ISNULL((SELECT #var_secondaryprev_D.totale FROM #var_secondaryprev_D
				WHERE #var_secondaryprev_D.idfin = #credit_surplus.idfin 
				AND #var_secondaryprev_D.idupb = #credit_surplus.idupb), 0),

	mov_finphase_C = ISNULL((SELECT #mov_finphase_C.totale FROM #mov_finphase_C
				WHERE #mov_finphase_C.idfin = #credit_surplus.idfin
				and #mov_finphase_C.idupb = #credit_surplus.idupb),0),

	var_finphase_C = ISNULL((SELECT #var_finphase_C.totale FROM #var_finphase_C
				WHERE #var_finphase_C.idfin = #credit_surplus.idfin 
				and #var_finphase_C.idupb = #credit_surplus.idupb),0),

	mov_maxphase_C = ISNULL((SELECT #mov_maxphase_C.totale FROM #mov_maxphase_C
				WHERE #mov_maxphase_C.idfin = #credit_surplus.idfin
				and #mov_maxphase_C.idupb = #credit_surplus.idupb),0),

	var_maxphase_C = ISNULL((SELECT #var_maxphase_C.totale FROM #var_maxphase_C
				WHERE #var_maxphase_C.idfin = #credit_surplus.idfin
				and #var_maxphase_C.idupb = #credit_surplus.idupb),0),

	mov_finphase_R = ISNULL((SELECT #mov_finphase_R.totale FROM #mov_finphase_R
				WHERE #mov_finphase_R.idfin = #credit_surplus.idfin
				and  #mov_finphase_R.idupb = #credit_surplus.idupb),0),

	var_finphase_R = ISNULL((SELECT #var_finphase_R.totale FROM #var_finphase_R
				WHERE #var_finphase_R.idfin = #credit_surplus.idfin
				and #var_finphase_R.idupb = #credit_surplus.idupb),0),

	mov_maxphase_R = ISNULL((SELECT #mov_maxphase_R.totale FROM #mov_maxphase_R
				WHERE #mov_maxphase_R.idfin = #credit_surplus.idfin
				and #mov_maxphase_R.idupb = #credit_surplus.idupb),0),

	var_maxphase_R = ISNULL((SELECT #var_maxphase_R.totale FROM #var_maxphase_R
				WHERE #var_maxphase_R.idfin = #credit_surplus.idfin
				and #var_maxphase_R.idupb = #credit_surplus.idupb),0),

	proceeds_maxphase_R = ISNULL((SELECT #proceeds_maxphase_R.totale FROM #proceeds_maxphase_R
				WHERE #proceeds_maxphase_R.idfin = #credit_surplus.idfin
				and  #proceeds_maxphase_R.idupb = #credit_surplus.idupb),0),

	proceeds_maxphase_C = ISNULL((SELECT #proceeds_maxphase_C.totale FROM #proceeds_maxphase_C
				WHERE #proceeds_maxphase_C.idfin = #credit_surplus.idfin
				and #proceeds_maxphase_C.idupb = #credit_surplus.idupb), 0)

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
BEGIN
	UPDATE #credit_surplus
	SET upb =
		(SELECT TOP 1 upb
		FROM #credit_surplus
		WHERE idupb = @idupboriginal),
	idupb =	@idupboriginal,
	codeupb =
		(SELECT TOP 1 codeupb
		FROM #credit_surplus	
		WHERE idupb = @idupboriginal)
END
IF (@showupb <>'S') and (@idupboriginal = '%')
BEGIN
	UPDATE #credit_surplus
	SET upb =  NULL,
	idupb = NULL,
	codeupb = NULL
END

IF (@suppressifblank = 'S')
BEGIN
	DELETE FROM #credit_surplus 
	WHERE (ISNULL(prevision,0)= 0
		AND ISNULL(secondaryprev,0)= 0
		AND ISNULL(var_prevision_A,0)= 0
		AND ISNULL(var_prevision_D,0) = 0
		AND ISNULL(var_secondaryprev_A,0)= 0
		AND ISNULL(var_secondaryprev_D,0)= 0
		AND ISNULL(mov_finphase_C,0)= 0
		AND ISNULL(var_finphase_C,0)= 0
		AND ISNULL(mov_maxphase_C,0)= 0
		AND ISNULL(var_maxphase_C,0)= 0
		AND ISNULL(mov_finphase_R,0)= 0
		AND ISNULL(var_finphase_R,0)= 0
		AND ISNULL(mov_maxphase_R,0)= 0
		AND ISNULL(var_maxphase_R,0)= 0
		AND ISNULL(proceeds_maxphase_R,0)= 0
		AND ISNULL(proceeds_maxphase_C,0)= 0

		AND ISNULL(currentarrears,0)= 0
		AND ISNULL(creditpart,0)= 0 
		AND ISNULL(creditvariation,0)= 0 
		AND ISNULL(proceedspart,0)= 0 
		AND ISNULL(proceedsvariation,0)= 0
		)
END


IF (@showupb <>'S') 
BEGIN
SELECT 
	codeupb as 'codice UPB',
	upb as 'UPB',
	codefin as 'Codice Bilancio'  ,
	fin as 'Bilancio',
	SUM( (ISNULL(prevision,0) + ISNULL(var_prevision_A,0) - ISNULL(var_prevision_D,0))) as 'previsione totale competenza',
	SUM( (ISNULL(secondaryprev,0) + ISNULL(var_secondaryprev_A,0) - ISNULL(var_secondaryprev_D,0))) as 'previsione totale cassa',
	SUM( ISNULL(proceedsvariation,0)) as 'Cassa al 01/01 [1]',
	SUM( ISNULL(proceeds_maxphase_R,0) ) as 'Incassato in conto residui [2]',
	SUM( ISNULL(proceeds_maxphase_C,0) ) as 'Incassato in conto competenza [3]',
	SUM( (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)) ) as 'pagamenti di competenza [4]',			
	SUM( (ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) ) as 'pagamenti residui [5]',
	SUM( ISNULL(proceedspart,0)	
	+ ISNULL(proceedsvariation,0) 
	- (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)+ ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)
	) ) as 'Avanzo di cassa [AC]=(1+2+3-4-5)',
	SUM(ISNULL(creditvariation,0)) as 'Crediti riportati al 01/01 [6]',
	SUM(ISNULL(creditpart,0)) as 'Crediti accertati in corso d''anno  [7]',
	SUM(ISNULL(creditpart,0) + ISNULL(creditvariation,0) ) as 'Crediti totali [CT]=(6+7)',
	SUM(ISNULL(creditpart,0)  - ISNULL(proceeds_maxphase_C,0) ) as 'Residui Attivi dell''esercizio in corso [8]' ,
	SUM( ISNULL(creditvariation,0) 
	+ ISNULL(mov_finphase_R,0) + ISNULL(var_finphase_R,0) 
	- ISNULL(proceedsvariation,0) - ISNULL(proceeds_maxphase_R,0) ) as 'Residui Attivi degli esercizi precedenti [9]',
--			'Residui Attivi [Ra]' = ISNULL(creditpart,0) + ISNULL(creditvariation,0) + ISNULL(mov_finphase_R,0) +ISNULL(var_finphase_R,0) - ISNULL(proceedspart,0) - ISNULL(proceedsvariation,0),
	SUM( (ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0)) ) as 'impegni di competenza [10]',
	SUM( (ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0)) ) as 'impegni residui [11]',
	SUM( ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0) - ( ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)) )as 'Residui Passivi dell''esercizio in corso [Rpc]=()',
	SUM( ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0) -  ( ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) )
	as 'Residui Passivi [Rpr] degli esercizi precedenti',

--Avanzo di cassa
	SUM( ISNULL(proceedspart,0)	+ ISNULL(proceedsvariation,0) 
	- (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)+ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) 
-- Residui Attivi	
	+ ISNULL(creditpart,0) + ISNULL(creditvariation,0) 
	+ ISNULL(mov_finphase_R,0) +ISNULL(var_finphase_R,0) 
	- ISNULL(proceeds_maxphase_R,0) - ISNULL(proceeds_maxphase_C,0)-- - ISNULL(proceedspart,0) 
	- ISNULL(proceedsvariation,0) 
-- Residui Passivi 
	- (ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0)) 
	+ (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)) 
	- (ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0)) 
	+ (ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) 
	)
AS 'Avanzo di amministrazione (AC+Ra-Rp))'
FROM #credit_surplus
GROUP BY codeupb,upb,codefin,fin
ORDER BY codeupb,codefin ASC

END

ELSE

BEGIN
SELECT 
	codeupb as 'codice UPB',
	upb as 'UPB',
	codefin as 'Codice Bilancio'  ,
	fin as 'Bilancio',
	(  ISNULL(prevision,0) + ISNULL(var_prevision_A,0) - ISNULL(var_prevision_D,0)) as 'previsione totale competenza',
	(  ISNULL(secondaryprev,0) + ISNULL(var_secondaryprev_A,0) - ISNULL(var_secondaryprev_D,0)) as 'previsione totale cassa',
	ISNULL(proceedsvariation,0) as 'Cassa al 01/01 [1]',
	 proceeds_maxphase_R as 'Incassato in conto residui [2]',
	proceeds_maxphase_C as 'Incassato in conto competenza [3]',
	 ( ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)) as 'pagamenti di competenza [4]',			
	 ( ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) as 'pagamenti residui [5]',
	ISNULL(proceedspart,0)	
	+ ISNULL(proceedsvariation,0) 
	- (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)+ ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)
	) as 'Avanzo di cassa [AC]=(1+2+3-4-5)',
	 ISNULL(creditvariation,0) as 'Crediti riportati al 01/01 [6]',
	ISNULL(creditpart,0) as 'Crediti accertati in corso d''anno  [7]',
	ISNULL(creditpart,0) + ISNULL(creditvariation,0) as 'Crediti totali [CT]=(6+7)',
	ISNULL(creditpart,0)  - ISNULL(proceeds_maxphase_C,0)   as 'Residui Attivi dell''esercizio in corso [8]' ,
	ISNULL(creditvariation,0) 
	+ ISNULL(mov_finphase_R,0) + ISNULL(var_finphase_R,0) 
	- ISNULL(proceedsvariation,0) - ISNULL(proceeds_maxphase_R,0)  as 'Residui Attivi degli esercizi precedenti [9]',
--			'Residui Attivi [Ra]' = ISNULL(creditpart,0) + ISNULL(creditvariation,0) + ISNULL(mov_finphase_R,0) +ISNULL(var_finphase_R,0) - ISNULL(proceedspart,0) - ISNULL(proceedsvariation,0)  ,
	( ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0)) as 'impegni di competenza [10]',
	(ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0)) as 'impegni residui [11]',
	ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0) - ( ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0) ) as 'Residui Passivi dell''esercizio in corso [Rpc]=()',
	ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0) -  ( ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0) ) 
	as 'Residui Passivi [Rpr] degli esercizi precedenti',

--Avanzo di cassa
	ISNULL(proceedspart,0)	+ ISNULL(proceedsvariation,0) 
	- (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)
	+ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) 
-- Residui Attivi
	+ ISNULL(creditpart,0) + ISNULL(creditvariation,0) 
	+ ISNULL(mov_finphase_R,0) +ISNULL(var_finphase_R,0) 
	- ISNULL(proceeds_maxphase_R,0) - ISNULL(proceeds_maxphase_C,0)-- - ISNULL(proceedspart,0) 
	- ISNULL(proceedsvariation,0) 
-- Residui Passivi 
	- (ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0)) 
	+ (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)) 
	- (ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0)) 
	+ (ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) 
AS 'Avanzo di amministrazione (AC+Ra-Rp))'

FROM #credit_surplus
ORDER BY codeupb,codefin ASC
END


 END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

