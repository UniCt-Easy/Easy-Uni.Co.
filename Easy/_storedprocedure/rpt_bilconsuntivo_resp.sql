
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilconsuntivo_resp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilconsuntivo_resp]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'

CREATE  PROCEDURE rpt_bilconsuntivo_resp
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@idman int,
	@levelusable tinyint,
	@suppressifblank char(1),
	@officialvar  char(1)
)
AS BEGIN
DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

CREATE TABLE #balance
(
	idfin int,
	code1 varchar(50),
	order1 varchar(50),
	code2 varchar(50),
	order2 varchar(50),
	code3 varchar(50),
	order3 varchar(50),
	code4 varchar(50),
	order4 varchar(50),
	code5 varchar(50),
	order5 varchar(50),
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
	flagincomesurplus char(1),
	initialprevision decimal(19,2),
	variation decimal(19,2),
	secondaryprev decimal(19,2),
	secondaryvariation decimal(19,2),
	currentarrears decimal(19,2),
	mov_finphase_C decimal(19,2),
	var_finphase_C decimal(19,2),
	mov_maxphase_C decimal(19,2),
	var_maxphase_C decimal(19,2),
	mov_finphase_R decimal(19,2),
	var_finphase_R decimal(19,2),
	mov_maxphase_R decimal(19,2),
	var_maxphase_R decimal(19,2),
	showincomesurplus char(1),
	tosuppress char(1),
	nlevel char(1),
	idman int
)
--DECLARE @lengthidfinop int
--SELECT  @lengthidfinop = (CONVERT(int,@levelusable) * 4 + 3 )

DECLARE @infoadvance char(1)
SELECT  @infoadvance = paramvalue
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'

DECLARE @finphase tinyint
DECLARE @maxphase tinyint

IF @finpart = 'E'
BEGIN
	SELECT @finphase = assessmentphasecode
	FROM config
	WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		SELECT @finphase = incomefinphase FROM uniconfig
	END
	SELECT @maxphase = MAX(nphase) FROM incomephase
END
ELSE
BEGIN
	SELECT @finphase = appropriationphasecode
	FROM config
	WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		SELECT @finphase = expensefinphase FROM uniconfig
	END
	SELECT @maxphase = MAX(nphase) FROM expensephase
END
	
DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @ff_jan01 decimal(19,2)
DECLARE @aa_jan01 decimal(19,2)
IF (@finpart = 'E')
BEGIN
	SELECT
	@supposed_ff_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(proceedstilldate, 0) -
		ISNULL(paymentstilldate, 0) +
		ISNULL(proceedstoendofyear, 0) -
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


DECLARE @minoplevel tinyint
SELECT @minoplevel = min(nlevel)
FROM finlevel
WHERE ayear = @ayear and (flag&2)<>0
	
IF(@levelusable < @minoplevel)
begin
	SET @levelusable = @minoplevel
end

INSERT INTO #balance
(
	idfin,
	code1,
	order1,
	code2,
	order2,
	code3,
	order3,
	code4,
	order4,
	code5,
	order5,
	codeupb,
	idupb,
	upb,
	upbprintingorder,
	initialprevision,
	secondaryprev,
	currentarrears,
	nlevel,
	idman
)
SELECT
	f5.idfin, 
	f1.codefin, f1.printingorder,
	f2.codefin, f2.printingorder,
	f3.codefin, f3.printingorder,
	f4.codefin, f4.printingorder,
	f5.codefin, f5.printingorder,
	upb.codeupb,
	upb.idupb,
	upb.title,
	upb.printingorder,
	ISNULL(fy.prevision,0), 
	ISNULL(fy.secondaryprev,0),
	ISNULL(fy.currentarrears,0),
	f5.nlevel,
	upb.idman
FROM fin f5
CROSS JOIN upb
JOIN finlevel fl
	ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
LEFT OUTER JOIN finyear fy
	ON fy.idfin = f5.idfin
	AND fy.idupb = upb.idupb
LEFT OUTER JOIN fin f4
	ON f4.idfin = f5.paridfin
LEFT OUTER JOIN fin f3
	ON f3.idfin = f4.paridfin
LEFT OUTER JOIN fin f2
	ON f2.idfin = f3.paridfin
LEFT OUTER JOIN fin f1
	ON f1.idfin = f2.paridfin
WHERE f5.ayear = @ayear
	 AND ((upb.idman = @idman) OR (@idman is null and upb.idman is not null))	
	AND ((f5.flag & 1)= @finpart_bit) 
	AND (f5.nlevel = @levelusable
		OR (f5.nlevel < @levelusable
		--AND EXISTS (SELECT * FROM finusable WHERE finusable.idfin = f5.idfin)
		AND EXISTS(SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
			AND (fl.flag&2)<>0
		)
		)
	AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (f5.flag & 16 =0))
DECLARE @lencod_lev1 int
SELECT @lencod_lev1 = flag /256 FROM finlevel WHERE ayear = @ayear AND nlevel = 1
DECLARE @startpos1 int
SELECT @startpos1 = 1
DECLARE @lencod_lev2 int
SELECT @lencod_lev2 = flag /256 FROM finlevel WHERE ayear = @ayear AND nlevel = 2
DECLARE @startpos2 int
SELECT @startpos2 = @startpos1 + @lencod_lev1
DECLARE @lencod_lev3 int
SELECT @lencod_lev3 = flag /256 FROM finlevel WHERE ayear = @ayear AND nlevel = 3
DECLARE @startpos3 int
SELECT @startpos3 = @startpos2 + @lencod_lev2
DECLARE @lencod_lev4 int
SELECT @lencod_lev4 = flag /256 FROM finlevel WHERE ayear = @ayear AND nlevel = 4
DECLARE @startpos4 int
SELECT @startpos4 = @startpos3 + @lencod_lev3
DECLARE @lencod_lev5 int 
SELECT @lencod_lev5 = flag /256 FROM finlevel WHERE ayear = @ayear AND nlevel = 5
DECLARE @startpos5 int 
SELECT @startpos5 = @startpos4 + @lencod_lev4
UPDATE #balance SET code1 = code2, code2 = code3, code3 = code4, code4 = code5, code5 = NULL WHERE code1 IS NULL
UPDATE #balance SET code1 = code2, code2 = code3, code3 = code4, code4 = code5, code5 = NULL WHERE code1 IS NULL
UPDATE #balance SET code1 = code2, code2 = code3, code3 = code4, code4 = code5, code5 = NULL WHERE code1 IS NULL
UPDATE #balance SET code1 = code2, code2 = code3, code3 = code4, code4 = code5, code5 = NULL WHERE code1 IS NULL
UPDATE #balance SET code1 = code2, code2 = code3, code3 = code4, code4 = code5, code5 = NULL WHERE code1 IS NULL
UPDATE #balance SET code1 = SUBSTRING(code1, @startpos1, @lencod_lev1)
UPDATE #balance SET code2 = SUBSTRING(code2, @startpos2, @lencod_lev2)
UPDATE #balance SET code3 = SUBSTRING(code3, @startpos3, @lencod_lev3)
UPDATE #balance SET code4 = SUBSTRING(code4, @startpos4, @lencod_lev4)
UPDATE #balance SET code5 = SUBSTRING(code5, @startpos5, @lencod_lev5)
UPDATE #balance SET order1 = order2, order2 = order3, order3 = order4, order4 = order5, order5 = NULL WHERE order1 IS NULL
UPDATE #balance SET order1 = order2, order2 = order3, order3 = order4, order4 = order5, order5 = NULL WHERE order1 IS NULL
UPDATE #balance SET order1 = order2, order2 = order3, order3 = order4, order4 = order5, order5 = NULL WHERE order1 IS NULL
UPDATE #balance SET order1 = order2, order2 = order3, order3 = order4, order4 = order5, order5 = NULL WHERE order1 IS NULL
UPDATE #balance SET order1 = SUBSTRING(order1, @startpos1, @lencod_lev1)
UPDATE #balance SET order2 = SUBSTRING(order2, @startpos2, @lencod_lev2)
UPDATE #balance SET order3 = SUBSTRING(order3, @startpos3, @lencod_lev3)
UPDATE #balance SET order4 = SUBSTRING(order4, @startpos4, @lencod_lev4)
UPDATE #balance SET order5 = SUBSTRING(order5, @startpos5, @lencod_lev5)

CREATE TABLE #tot_varprev_M (idfin int, idupb varchar(36), total decimal(19,2))
INSERT INTO #tot_varprev_M
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	FVD.idupb,
	SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
JOIN upb U
	ON U.idupb = FVD.idupb
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = '5'
	AND FV.variationkind <> 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	 AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

CREATE TABLE #tot_varprev_S (idfin int, idupb varchar(36), total decimal(19,2))
INSERT INTO #tot_varprev_S
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	FVD.idupb,
	SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN upb U
	ON U.idupb = FVD.idupb
JOIN  fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND FV.idfinvarstatus = '5'
	AND FV.variationkind <> 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

CREATE TABLE #mov_finphase_C (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_finphase_C (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #mov_finphase_R (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_finphase_R (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #mov_maxphase_C (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_maxphase_C (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #mov_maxphase_R (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_maxphase_R (idfin int, idupb varchar(36), total decimal(19,2))

DECLARE @cashvaliditykind tinyint
SELECT @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear

IF (@finpart = 'E')
BEGIN
	INSERT INTO #mov_finphase_C
	(
		idfin,
		idupb,
		total
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		IY.idupb,
		SUM(IY.amount)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN upb U
		ON U.idupb = IY.idupb
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE I.adate <= @date
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	

	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #var_finphase_C
	(
		idfin,
		idupb,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		IY.idupb,
		SUM(IV.amount)
	FROM incomevar IV
	JOIN income I
		ON IV.idinc = I.idinc
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN upb U
		ON U.idupb = IY.idupb
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #mov_finphase_R
	(
		idfin,
		idupb,
		total
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		IY.idupb,
		SUM(IY.amount)
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	JOIN upb U
		ON U.idupb = IY.idupb
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND I.adate <= @date
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #var_finphase_R
	(
		idfin,
		idupb,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		IY.idupb,
		SUM(IV.amount)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON IY.idinc = I.idinc
	JOIN upb U
		ON U.idupb = IY.idupb
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #mov_maxphase_C
	(
		idfin,
		idupb,	
		total
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		IY.idupb,
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON IY.idinc = HPV.idinc
	JOIN upb U
		ON U.idupb = IY.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND IY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #mov_maxphase_R
	(
		idfin,
		idupb,
		total
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		IY.idupb,
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON IY.idinc = HPV.idinc
	JOIN upb U
		ON U.idupb = IY.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND IY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	IF (@cashvaliditykind <> 4 )
	BEGIN
		INSERT INTO #var_maxphase_C
		(
			idfin,
			idupb,
			total
		)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin), 
			IY.idupb,
			SUM(IV.amount)
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN upb U
			ON U.idupb = IY.idupb
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND IV.adate <= @date
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			--AND IY.nphase = @maxphase
			AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
			/*AND EXISTS
				(SELECT * FROM historyproceedsview HPV
				WHERE HPV.idinc = IV.idinc
					AND HPV.competencydate <= @date
					AND HPV.ymov = @ayear)*/
		GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)
	
		INSERT INTO #var_maxphase_R
		(
			idfin,
			idupb,
			total
		)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin),
			IY.idupb,
			SUM(IV.amount)
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN upb U
			ON U.idupb = IY.idupb
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			--AND IY.nphase = @maxphase
			AND IV.adate <= @date
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
			/*AND EXISTS
				(SELECT * FROM historyproceedsview HPV
				WHERE HPV.idinc = IV.idinc
					AND HPV.competencydate <= @date
					AND HPV.ymov = @ayear)*/
		GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)
	END
END
IF (@finpart = 'S')
BEGIN
	INSERT INTO #mov_finphase_C
	(
		idfin,
		idupb,
		total
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		EY.idupb,
		SUM(EY.amount)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN upb U
		ON U.idupb = EY.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #var_finphase_C
	(
		idfin,
		idupb,
		total
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		EY.idupb,
		SUM(EV.amount)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON EY.idexp = E.idexp
	JOIN upb U
		ON U.idupb = EY.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EV.adate <= @date 
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #mov_finphase_R
	(
		idfin,
		idupb,	
		total
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		EY.idupb,
		SUM(EY.amount)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN upb U
		ON U.idupb = EY.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	GROUP BY EY.idupb, ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #var_finphase_R
	(
		idfin,
		idupb,	
		total
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		EY.idupb,
		SUM(EV.amount)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON EY.idexp = E.idexp
	JOIN upb U
		ON U.idupb = EY.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EV.adate <= @date 
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #mov_maxphase_C
	(
		idfin,
		idupb,
		total
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		EY.idupb,
		SUM(HPV.amount)
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	JOIN upb U
		ON U.idupb = EY.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #mov_maxphase_R
	(
		idfin,
		idupb,
		total
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		EY.idupb,
		SUM(HPV.amount)
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	JOIN upb U
		ON U.idupb = EY.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)
		AND HPV.ymov = @ayear
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #var_maxphase_C
		(
			idfin,
			idupb,
			total
		)
		SELECT
			ISNULL(FLK.idparent,EY.idfin),
			EY.idupb,
			SUM(EV.amount)
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN upb U
			ON U.idupb = EY.idupb
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)--Competenza
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			-- AND EY.nphase = @maxphase
			AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
			/*AND EXISTS
				(SELECT * FROM historypaymentview HPV
				WHERE HPV.idexp = EV.idexp
					AND HPV.competencydate <= @date
					AND HPV.ymov = @ayear)*/
		GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

		INSERT INTO #var_maxphase_R
		(
			idfin,
			idupb,
			total
		)
		SELECT
			ISNULL(FLK.idparent,EY.idfin),
			EY.idupb,
			SUM(EV.amount)
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN upb U
			ON U.idupb = EY.idupb
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND EY.ayear = @ayear
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			AND ( (HPV.totflag & 1) = 1) --Residuo
			--AND EY.nphase = @maxphase
			AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
			/*AND EXISTS
				(SELECT * FROM historypaymentview HPV
				WHERE HPV.idexp = EV.idexp
					AND HPV.competencydate <= @date
					AND HPV.ymov = @ayear)*/
		GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)
	END
END
UPDATE #balance
SET variation =
ISNULL(
	(SELECT #tot_varprev_M.total FROM #tot_varprev_M
	WHERE  #tot_varprev_M.idupb = #balance.idupb and 
		#tot_varprev_M.idfin = #balance.idfin)
, 0),
secondaryvariation =
ISNULL(
	(SELECT #tot_varprev_S.total FROM #tot_varprev_S
	WHERE #tot_varprev_S.idupb = #balance.idupb
		and #tot_varprev_S.idfin = #balance.idfin)
, 0),
mov_finphase_C =
ISNULL(
	(SELECT #mov_finphase_C.total FROM #mov_finphase_C
	WHERE #mov_finphase_C.idupb = #balance.idupb
	and #mov_finphase_C.idfin = #balance.idfin)
, 0),
var_finphase_C =
ISNULL(
	(SELECT #var_finphase_C.total FROM #var_finphase_C
	WHERE #var_finphase_C.idupb = #balance.idupb
		and  #var_finphase_C.idfin = #balance.idfin)
, 0),
mov_maxphase_C =
ISNULL(
	(SELECT #mov_maxphase_C.total FROM #mov_maxphase_C
	WHERE #mov_maxphase_C.idupb = #balance.idupb
	and #mov_maxphase_C.idfin = #balance.idfin)
, 0),
var_maxphase_C =
ISNULL(
	(SELECT #var_maxphase_C.total FROM #var_maxphase_C
	WHERE #var_maxphase_C.idupb = #balance.idupb
		and #var_maxphase_C.idfin = #balance.idfin)
, 0),
mov_finphase_R =
ISNULL(
	(SELECT #mov_finphase_R.total FROM #mov_finphase_R
	WHERE #mov_finphase_R.idupb = #balance.idupb
		and #mov_finphase_R.idfin = #balance.idfin)
, 0),
var_finphase_R =
ISNULL(
	(SELECT #var_finphase_R.total FROM #var_finphase_R
	WHERE #var_finphase_R.idupb = #balance.idupb
	and  #var_finphase_R.idfin = #balance.idfin)
, 0),
mov_maxphase_R =
ISNULL(
	(SELECT #mov_maxphase_R.total FROM #mov_maxphase_R
        WHERE #mov_maxphase_R.idupb = #balance.idupb
		and #mov_maxphase_R.idfin = #balance.idfin)
, 0),
var_maxphase_R =
ISNULL(
	(SELECT #var_maxphase_R.total FROM #var_maxphase_R
	WHERE #var_maxphase_R.idupb = #balance.idupb
		and #var_maxphase_R.idfin = #balance.idfin)
, 0)
DECLARE @fin_kind int
SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear
IF @fin_kind = 2
BEGIN
	UPDATE #balance
	SET mov_maxphase_C = ISNULL(initialprevision, 0) + ISNULL(variation, 0)
	WHERE idfin in (select  idfin from fin where ayear=@ayear and (flag&16<>0) )
END
	
IF (@suppressifblank = 'S')
BEGIN
	UPDATE #balance SET tosuppress = 'S'
	WHERE ISNULL(initialprevision,0)= 0
		AND ISNULL(variation,0)= 0
		AND ISNULL(secondaryprev,0) = 0
		AND ISNULL(secondaryvariation,0) = 0
		AND ISNULL(currentarrears,0) = 0
		AND ISNULL(mov_finphase_C,0) = 0
		AND ISNULL(var_finphase_C,0) = 0
		AND ISNULL(mov_maxphase_C,0) = 0
		AND ISNULL(var_maxphase_C,0) = 0
		AND ISNULL(mov_finphase_R,0) = 0
		AND ISNULL(var_finphase_R,0) = 0
		AND ISNULL(mov_maxphase_R,0) = 0
		AND ISNULL(var_maxphase_R,0) = 0
	
	UPDATE #balance SET tosuppress = 'N'
	WHERE NOT(ISNULL(initialprevision,0) = 0
		AND ISNULL(variation,0)= 0
		AND ISNULL(secondaryprev,0) = 0
		AND ISNULL(secondaryvariation,0) = 0
		AND ISNULL(currentarrears,0) = 0
		AND ISNULL(mov_finphase_C,0) = 0
		AND ISNULL(var_finphase_C,0) = 0
		AND ISNULL(mov_maxphase_C,0) = 0
		AND ISNULL(var_maxphase_C,0) = 0
		AND ISNULL(mov_finphase_R,0) = 0
		AND ISNULL(var_finphase_R,0) = 0
		AND ISNULL(mov_maxphase_R,0) = 0
		AND ISNULL(var_maxphase_R,0) = 0)
END
ELSE
BEGIN
	UPDATE #balance SET tosuppress = 'N'
END
	
DECLARE @lev_desc1 varchar(50)
SELECT @lev_desc1 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 1
DECLARE @lev_desc2 varchar(50)
SELECT @lev_desc2 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 2
DECLARE @lev_desc3 varchar(50)
SELECT @lev_desc3 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 3
DECLARE @lev_desc4 varchar(50)
SELECT @lev_desc4 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 4
DECLARE @lev_desc5 varchar(50)
SELECT @lev_desc5 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 5
SELECT 
	#balance.idfin,
	code1,
	f1.title AS desc1,
	@lev_desc1 AS lev_desc1,
	order1,
	code2,
	f2.title AS desc2,
	@lev_desc2 AS lev_desc2,
	order2,
	code3,
	f3.title AS desc3,
	@lev_desc3 AS lev_desc3,
	order3,
	code4,
	f4.title AS desc4,
	@lev_desc4 AS lev_desc4,
	order4,
	code5,
	f5.title AS desc5,
	@lev_desc5 AS lev_desc5,
	order5,
	codeupb,
	idupb,
	upb,
	upbprintingorder,
	initialprevision,
	variation,
	secondaryprev,
	secondaryvariation,
	currentarrears,
	mov_finphase_C,
	var_finphase_C,
	mov_maxphase_C,
	var_maxphase_C,
	mov_finphase_R,
	var_finphase_R,
	mov_maxphase_R,
	var_maxphase_R,
	case @fin_kind when 2 then 'S' else 'C' end AS previsionkind,
	showincomesurplus,
	@supposed_ff_jan01 AS supposed_ff_jan01,
	@supposed_aa_jan01 AS supposed_aa_jan01,
	@ff_jan01 AS ff_jan01,
	@aa_jan01 AS aa_jan01,
	tosuppress,	
	#balance.nlevel,
	#balance.idman,
	m.title AS manager
	FROM #balance
	/*LEFT OUTER JOIN fin f1
		ON f1.idfin = LEFT(#balance.idfin, 7)
		AND f1.nlevel = '1'*/
	LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = #balance.idfin AND flk1.nlevel = 1
	LEFT OUTER JOIN fin f1
		ON flk1.idparent = f1.idfin 

	/*LEFT OUTER JOIN fin f2
		ON f2.idfin = LEFT(#balance.idfin,11)
		AND f2.nlevel = '2'*/
	LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = #balance.idfin AND flk2.nlevel = 2
	LEFT OUTER JOIN fin f2
		ON flk2.idparent = f2.idfin 

	/*LEFT OUTER JOIN fin f3
		ON f3.idfin = LEFT(#balance.idfin,15)
		AND f3.nlevel = '3'*/
	LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = #balance.idfin AND flk3.nlevel = 3
	LEFT OUTER JOIN fin f3
		ON flk3.idparent = f3.idfin 

	/*LEFT OUTER JOIN fin f4
		ON f4.idfin = LEFT(#balance.idfin,19)
		AND f4.nlevel = '4'*/
	LEFT OUTER JOIN finlink flk4
		ON flk4.idchild = #balance.idfin AND flk4.nlevel = 4
	LEFT OUTER JOIN fin f4
		ON flk4.idparent = f4.idfin 

	/*LEFT OUTER JOIN fin f5
		ON f5.idfin = LEFT(#balance.idfin,23)
		AND f5.nlevel = '5'*/
	LEFT OUTER JOIN finlink flk5
		ON flk5.idchild = #balance.idfin AND flk5.nlevel = 5
	LEFT OUTER JOIN fin f5
		ON flk5.idparent = f5.idfin 
	LEFT OUTER JOIN manager m
		ON m.idman = #balance.idman
ORDER BY upbprintingorder ASC,order1 ASC, order2 ASC, order3 ASC, order4 ASC, order5 ASC
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
