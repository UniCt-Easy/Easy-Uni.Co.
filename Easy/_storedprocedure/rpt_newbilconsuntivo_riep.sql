
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_newbilconsuntivo_riep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_newbilconsuntivo_riep]
GO

CREATE   PROCEDURE rpt_newbilconsuntivo_riep 
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@levelusable tinyint,
	@idupb varchar(36),
	@showupb char(1),
	@showchildupb char(1),
	@officialvar  char(1),
	@suppressifblank char(1)
)
AS BEGIN
/* Versione 1.0.1 del 09/10/2007 ultima modifica: MARIA */
--	exec rpt_newbilconsuntivo_riep 2007,{ts '2007-08-20 00:00:00'},'S',3,'%','N','S','N','N'
--  exec    rpt_bilconsuntivo_riep 2007,{ts '2007-08-20 00:00:00'},'S',3,'%','N','S','N','N'
--  setuser 'amm'

DECLARE @idupboriginal 	varchar(36)
	
SET @idupboriginal= @idupb
		
IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%'
END


declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'



DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

CREATE TABLE #data
(
	idfin int,
	flagavanzo char(1),
	idupb varchar(36),
	initialprevision decimal(19,2),
	variation decimal(19,2),
	secondaryprevision decimal(19,2),
	secondaryvariation decimal(19,2),
	currentarrears decimal(19,2),
	mov_finphase_C decimal(19,2),
	var_finphase_C decimal(19,2),
	mov_maxphase_C decimal(19,2),
	var_maxphase_C decimal(19,2),
	mov_finphase_R decimal(19,2),
	var_finphase_R decimal(19,2),
	mov_maxphase_R decimal(19,2),
	var_maxphase_R decimal(19,2)
)
DECLARE @infoadvance char(1)
SELECT @infoadvance = paramvalue
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'
DECLARE @minoplevel tinyint

SELECT @minoplevel = MIN(nlevel) FROM finlevel WHERE ayear = @ayear AND (flag&2)<>0

IF(@levelusable < @minoplevel)
begin
	SET @levelusable = @minoplevel
end

DECLARE @cashvaliditykind tinyint

SELECT @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
DECLARE @fin_kind tinyint

SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear

	
DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @ff_jan01 decimal(19,2)
DECLARE @aa_jan01 decimal(19,2)

DECLARE @floatfund_01_jan_used decimal(19,2) 
DECLARE @supposed_aa_01_jan_used decimal(19,2) 
DECLARE @aa_01_jan_used decimal(19,2) 
DECLARE @supposed_ff_01_jan_used decimal(19,2) 

IF @finpart = 'E'
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
		ISNULL(supposedcurrentexpenditure, 0),
	@ff_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(competencyproceeds, 0) +
		ISNULL(residualproceeds, 0) -
		ISNULL(competencypayments, 0) -
		ISNULL(residualpayments, 0),
	@aa_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(competencyproceeds, 0) +
		ISNULL(residualproceeds , 0) -
		ISNULL(competencypayments, 0) -
		ISNULL(residualpayments  , 0) +
		ISNULL(previousrevenue, 0) +
		ISNULL(currentrevenue , 0) -
		ISNULL(previousexpenditure, 0) -
		ISNULL(currentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 1

	SELECT @floatfund_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='ff_jan01'
	
	SELECT @aa_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='aa_jan01'

	SELECT @supposed_ff_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='supposed_ff_jan01'
	
	SELECT @supposed_aa_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='supposed_aa_jan01'
END

DECLARE @finphase tinyint
DECLARE @maxphase tinyint
IF (@finpart = 'E')
BEGIN
	SELECT @finphase = assessmentphasecode
	FROM config
	WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		SELECT @finphase = incomefinphase
		FROM uniconfig
	END
	SELECT @maxphase = MAX(nphase) FROM incomephase
END
IF (@finpart = 'S')
BEGIN
	SELECT @finphase =  appropriationphasecode
	FROM config
	WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		SELECT @finphase = expensefinphase
		FROM uniconfig
	END
	SELECT @maxphase = MAX(nphase) FROM expensephase
END



IF @levelusable > @minoplevel
BEGIN
print 'then'
-- se la stampa è per articolo : 4 > 3 : legge le prev dalle foglie e somma sino al livello desiderato
--   [ex: finusable degli articoli, laddove non esiste l'articolo -- legge il capitolo]
	INSERT INTO #data
	(
		idfin,
		idupb,
		initialprevision
	)
	SELECT
		finlink.idparent,	isnull(@fixedidupb,fy2.idupb),
		ISNULL(SUM(fy2.prevision),0)
	FROM  finyear fy2
		JOIN finlast
			ON finlast.idfin = fy2.idfin
		JOIN finlink 
			ON finlink.idchild = finlast.idfin AND finlink.nlevel = 1
		JOIN fin 
			on fin.idfin=finlink.idparent			
	WHERE (fy2.idupb LIKE @idupb)
		AND fy2.ayear = @ayear
		AND ((fin.flag & 1)= @finpart_bit) -- AND fin.finpart = @finpart
		AND fin.nlevel = 1
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR ((fin.flag & 16) =0))  
	GROUP BY isnull(@fixedidupb,fy2.idupb),finlink.idparent
			
END
ELSE
BEGIN
print'Else'
	INSERT INTO #data
	(
		idfin,
		idupb,
		initialprevision
	)
	SELECT
		finlink.idparent,
		isnull(@fixedidupb,fy2.idupb),
		ISNULL(SUM(fy2.prevision),0)
	FROM finyear fy2
	JOIN fin f2
		ON f2.idfin = fy2.idfin 
	JOIN finlink
		ON fy2.idfin = finlink.idchild AND finlink.nlevel = 1
	JOIN fin
		ON fin.idfin = finlink.idparent 			
	WHERE f2.nlevel=@levelusable
		AND (fy2.idupb LIKE @idupb)
		AND fy2.ayear = @ayear
		AND ((fin.flag & 1)= @finpart_bit)
		AND (@infoadvance = 'N' OR @infoadvance = 'B'  OR ((fin.flag & 16) =0))
		GROUP BY isnull(@fixedidupb,fy2.idupb),finlink.idparent
END


print 'fin_kind:'
print @fin_kind


INSERT INTO #data
(
	idfin,
	idupb,
	variation
)
SELECT
	FLK.idparent,
	isnull(@fixedidupb,fvd.idupb),
	SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN fin F
	ON F.idfin = FVD.idfin
JOIN finlink FLK
	ON FLK.idchild = FVD.idfin
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND (((F.flag & 16) =0)OR @infoadvance = 'N' OR @infoadvance = 'B')
	AND FLK.nlevel = 1
GROUP BY isnull(@fixedidupb,fvd.idupb),FLK.idparent




IF @finpart = 'E'
BEGIN
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_finphase_C
	)
	SELECT
		FLK.idparent,
		isnull(@fixedidupb,iy.idupb),
		ISNULL(SUM(IY.amount),0)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN fin F
		ON IY.idfin = F.idfin
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN finlink FLK
		ON FLK.idchild = IY.idfin
	WHERE I.adate <= @date
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FLK.nlevel = 1
	GROUP BY isnull(@fixedidupb,iy.idupb),FLK.idparent

	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_C
	)
	SELECT 
		FLK.idparent,
		isnull(@fixedidupb,iy.idupb),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON I.idinc = IV.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN finlink FLK
		ON FLK.idchild = IY.idfin
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)--Competenza
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND (((F.flag & 16) =0)OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FLK.nlevel = 1
	GROUP BY isnull(@fixedidupb,iy.idupb),FLK.idparent

IF(	@fin_kind IN ('1','3'))
Begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_finphase_R
	)
	SELECT
		FLK.idparent,
		isnull(@fixedidupb,iy.idupb),
		ISNULL(SUM(IY.amount),0)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN fin F
		ON IY.idfin = F.idfin
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN finlink FLK
		ON FLK.idchild = IY.idfin
	WHERE I.adate <= @date
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)--Residuo
		AND I.nphase = @finphase
		AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FLK.nlevel = 1
	GROUP BY isnull(@fixedidupb,iy.idupb),FLK.idparent
End

IF(	@fin_kind IN ('1','3'))
Begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_R
	)
	SELECT 
		FLK.idparent,
		isnull(@fixedidupb,iy.idupb),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON I.idinc = IV.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN finlink FLK
		ON FLK.idchild = IY.idfin
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND FLK.nlevel = 1
		AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
	GROUP BY isnull(@fixedidupb,iy.idupb),FLK.idparent 
End
	
	INSERT INTO #data
	(
		idfin,
		idupb,	
		mov_maxphase_C
	)
	SELECT
		FLK.idparent,
		isnull(@fixedidupb,iy.idupb),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON IY.idinc = HPV.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN finlink FLK
		ON FLK.idchild = IY.idfin
	WHERE HPV.competencydate <= @date
		AND IY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
		AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FLK.nlevel = 1
	GROUP BY isnull(@fixedidupb,iy.idupb),FLK.idparent

	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_maxphase_R
	)
	SELECT
		FLK.idparent,
		isnull(@fixedidupb,iy.idupb),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON IY.idinc = HPV.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN finlink FLK
		ON FLK.idchild = IY.idfin
	WHERE HPV.competencydate <= @date
		AND IY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
		AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FLK.nlevel = 1
	GROUP BY isnull(@fixedidupb,iy.idupb),FLK.idparent

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_C
		)
		SELECT 
			FLK.idparent,
			isnull(@fixedidupb,iy.idupb),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN fin F
			ON F.idfin = IY.idfin
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		JOIN finlink FLK
			ON FLK.idchild = IY.idfin	
		WHERE IV.yvar = @ayear
			AND IV.adate <= @date
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			--AND IY.nphase = @maxphase
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
			/*AND EXISTS
				(SELECT * FROM historyproceedsview HPV
				WHERE HPV.idinc = IV.idinc
					AND HPV.competencydate <= @date
					AND HPV.ymov = @ayear)*/
			AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
			AND FLK.nlevel = 1
		GROUP BY isnull(@fixedidupb,iy.idupb), FLK.idparent
	
		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_R
		)
		SELECT 
			FLK.idparent, 
			isnull(@fixedidupb,iy.idupb),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN fin F
			ON F.idfin = IY.idfin
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		JOIN finlink FLK
			ON FLK.idchild = IY.idfin	
		WHERE IV.yvar = @ayear
			AND IV.adate <= @date
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			--AND IY.nphase = @maxphase
			/*AND EXISTS
				(SELECT * FROM historyproceedsview HPV
				WHERE HPV.idinc = IV.idinc
					AND HPV.competencydate <= @date
					AND HPV.ymov = @ayear)*/
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
			AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
			AND FLK.nlevel = 1
		GROUP BY isnull(@fixedidupb,iy.idupb),FLK.idparent
	END
END
IF (@finpart = 'S')
BEGIN
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_finphase_C
	)
	SELECT
		FLK.idparent,
		isnull(@fixedidupb,ey.idupb),
		ISNULL(SUM(EY.amount),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN fin F
		ON EY.idfin = F.idfin
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN finlink FLK
		ON FLK.idchild = EY.idfin	
	WHERE E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FLK.nlevel = 1
	GROUP BY isnull(@fixedidupb,ey.idupb), FLK.idparent

	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_C
	)
	SELECT 
		FLK.idparent, 
		isnull(@fixedidupb,ey.idupb),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON E.idexp = EV.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN finlink FLK
		ON FLK.idchild = EY.idfin
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND EV.adate <= @date 
		AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FLK.nlevel = 1
	GROUP BY isnull(@fixedidupb,ey.idupb),FLK.idparent


IF(	@fin_kind IN ('1','3'))
Begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_finphase_R
	)
	SELECT
		FLK.idparent,
		isnull(@fixedidupb,ey.idupb),
		ISNULL(SUM(EY.amount),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN fin F
		ON EY.idfin = F.idfin
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN finlink FLK
		ON FLK.idchild = EY.idfin
	WHERE E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FLK.nlevel = 1
	GROUP BY isnull(@fixedidupb,ey.idupb),FLK.idparent
end


IF(	@fin_kind IN ('1','3'))
Begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_R
	)
	SELECT 
		FLK.idparent,
		isnull(@fixedidupb,ey.idupb),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON E.idexp = EV.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	JOIN finlink FLK
		ON FLK.idchild = EY.idfin	
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND EV.adate <= @date 
		AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FLK.nlevel = 1
	GROUP BY isnull(@fixedidupb,ey.idupb),FLK.idparent
end

	INSERT INTO #data
	(
		idfin,
		idupb,	
		mov_maxphase_C
	)
	SELECT
		FLK.idparent,
		isnull(@fixedidupb,ey.idupb),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	JOIN finlink FLK
		ON FLK.idchild = EY.idfin
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
		AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FLK.nlevel = 1
	GROUP BY isnull(@fixedidupb,ey.idupb),FLK.idparent

	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_maxphase_R
	)
	SELECT
		FLK.idparent,
		isnull(@fixedidupb,ey.idupb),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	JOIN finlink FLK
		ON FLK.idchild = EY.idfin
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
		AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FLK.nlevel = 1
	GROUP BY isnull(@fixedidupb,ey.idupb),FLK.idparent

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_C
		)
		SELECT 
			FLK.idparent,
			isnull(@fixedidupb,ey.idupb),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN fin F
			ON F.idfin = EY.idfin
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		JOIN finlink FLK
			ON FLK.idchild = F.idfin
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)--Competenza
			--AND EY.nphase = @maxphase
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			/*AND EXISTS
				(SELECT * FROM historypaymentview HPV
				WHERE HPV.idexp = EV.idexp
					AND HPV.competencydate <= @date
					AND HPV.ymov = @ayear)*/
			AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
			AND FLK.nlevel = 1
		GROUP BY isnull(@fixedidupb,ey.idupb),FLK.idparent
	
		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_R
		)
		SELECT 
			FLK.idparent,
			isnull(@fixedidupb,ey.idupb),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN fin F
			ON F.idfin = EY.idfin
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		JOIN finlink FLK
			ON FLK.idchild = EY.idfin
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			--AND EY.nphase = @maxphase
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			/*AND EXISTS
				(SELECT * FROM historypaymentview HPV
				WHERE HPV.idexp = EV.idexp
					AND HPV.competencydate <= @date
					AND HPV.ymov = @ayear)*/
			AND (((F.flag & 16) =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
			AND FLK.nlevel = 1
		GROUP BY isnull(@fixedidupb,ey.idupb),FLK.idparent
	END
END


IF @fin_kind = 2 AND @finpart = 'E' AND (@infoadvance IN ('N','B')) AND 
(EXISTS (SELECT * FROM fin F WHERE  ((F.flag&16 <>0))) )
BEGIN

 
   if exists(select * from fin F 
    left outer join #data D on D.idfin=F.idfin
     where F.ayear=@ayear and (F.flag&16 <>0)  and D.idfin is null) 
		insert into #data (idfin,idupb,mov_maxphase_C) 
		  select F.idfin, '0001',0 
		   from 
			fin F 
			left outer join #data D on D.idfin=F.idfin
     where F.ayear=@ayear and (F.flag&16 <>0)  and D.idfin is null

;
with to_sum (idfin,idupb,amount) as
(select FL.idparent, FVD.idupb,sum(FVD.amount) 
   FROM finvardetail FVD
    JOIN finvar FV    ON FV.yvar = FVD.yvar  AND FV.nvar = FVD.nvar
    join fin F on FVD.idfin=F.idfin
    join finlink FL on FL.idchild= FVD.idfin and FL.nlevel=1
   WHERE FV.yvar = @ayear
    AND FV.adate <= @date
    AND FV.flagprevision ='S'
    AND FV.idfinvarstatus = 5
    AND FV.variationkind <> 5
    AND (F.flag&16 <>0)
   group by FL.idparent, FVD.idupb
) 


 UPDATE #data SET mov_maxphase_C = isnull(mov_maxphase_C,0)+ isnull(to_sum.amount,0)
 from #data 
 join to_sum on #data.idfin= to_sum.idfin and #data.idupb=to_sum.idupb;



END
 


DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'

DECLARE @lev_desc1 varchar(50)
SELECT @lev_desc1 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 1



IF (@showupb ='S')
BEGIN


SELECT
	#data.idfin,
	f.codefin AS code1,
	f.title AS desc1,
	f.printingorder AS order1,
	codeupb,
	#data.idupb,
	upb.title as upb,
	upb.printingorder as upbprintingorder,
	isnull(sum(initialprevision),0) as initialprevision,
	isnull(sum(variation),0) as variation,
	isnull(sum(secondaryprevision),0) as secondaryprevision,
	isnull(sum(secondaryvariation),0) as secondaryvariation,
	isnull(sum(currentarrears),0) as currentarrears,
	isnull(sum(mov_finphase_C),0) as mov_finphase_C,
	isnull(sum(var_finphase_C),0) as var_finphase_C,
	isnull(sum(mov_maxphase_C),0) as mov_maxphase_C,
	isnull(sum(var_maxphase_C),0) as var_maxphase_C,
	isnull(sum(mov_finphase_R),0) as mov_finphase_R,
	isnull(sum(var_finphase_R),0) as var_finphase_R,
	isnull(sum(mov_maxphase_R),0) as mov_maxphase_R,
	isnull(sum(var_maxphase_R),0) as var_maxphase_R,
	@supposed_ff_jan01 AS supposed_ff_jan01,
	@supposed_aa_jan01 AS supposed_aa_jan01,
	@ff_jan01 AS ff_jan01,
	@aa_jan01 AS aa_jan01,
	isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
	isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
	isnull(@aa_01_jan_used,0) as aa_01_jan_used,
	isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used
FROM fin f
cross join  upb 
left outer join #data on #data.idfin=f.idfin and #data.idupb=upb.idupb
where f.nlevel=1
		and ( (@MostraTutteVoci = 'S'  or @suppressifblank='N')  OR  (upb.idupb='0001' or #data.idfin is not null)) 
		and f.ayear=@ayear 
		AND ((f.flag & 1)= @finpart_bit)
		 and upb.idupb like @idupb
group by #data.idfin,f.codefin ,	f.title ,	f.printingorder ,
	codeupb,#data.idupb,upb.title ,	upb.printingorder 


ORDER BY f.printingorder ASC,#data.idupb ASC
END




IF (@showupb ='N')
BEGIN
declare 	@codeupb varchar(50)
declare		@upb varchar(150)
declare		@upbprintingorder varchar(50)
declare		@ext_idupb varchar(50)

if (@idupboriginal='%')
begin
	set @codeupb= null
	set @upb= null
	set @upbprintingorder= null
	set @ext_idupb= null
end
else
begin
	SET @upbprintingorder =
		(SELECT TOP 1 printingorder
		FROM upb
		WHERE idupb = @idupboriginal)
	SET  @upb =
		(SELECT TOP 1 title
		FROM upb
		WHERE idupb = @idupboriginal)
	SET  @ext_idupb =	@idupboriginal
	SET  @codeupb =
		(SELECT TOP 1 codeupb
		FROM upb	
		WHERE idupb = @idupboriginal)
end



SELECT
	#data.idfin,
	f.codefin AS code1,
	f.title AS desc1,
	f.printingorder AS order1,
	@codeupb as codeupb,
	@ext_idupb as idupb,
	@upb as upb,
	@upbprintingorder as upbprintingorder,
	isnull(sum(initialprevision),0) as initialprevision,
	isnull(sum(variation),0) as variation,
	isnull(sum(secondaryprevision),0) as secondaryprevision,
	isnull(sum(secondaryvariation),0) as secondaryvariation,
	isnull(sum(currentarrears),0) as currentarrears,
	isnull(sum(mov_finphase_C),0) as mov_finphase_C,
	isnull(sum(var_finphase_C),0) as var_finphase_C,
	isnull(sum(mov_maxphase_C),0) as mov_maxphase_C,
	isnull(sum(var_maxphase_C),0) as var_maxphase_C,
	isnull(sum(mov_finphase_R),0) as mov_finphase_R,
	isnull(sum(var_finphase_R),0) as var_finphase_R,
	isnull(sum(mov_maxphase_R),0) as mov_maxphase_R,
	isnull(sum(var_maxphase_R),0) as var_maxphase_R,
	@supposed_ff_jan01 AS supposed_ff_jan01,
	@supposed_aa_jan01 AS supposed_aa_jan01,
	@ff_jan01 AS ff_jan01,
	@aa_jan01 AS aa_jan01,
	isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
	isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
	isnull(@aa_01_jan_used,0) as aa_01_jan_used,
	isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used
FROM fin f
left outer join #data on #data.idfin=f.idfin 
where 
		--( (@MostraTutteVoci = 'S'  or @suppressifblank='N')  OR  (upb.idupb='0001' or #data.idfin is not null))  and
		f.nlevel=1
		and f.ayear=@ayear 
		AND ((f.flag & 1)= @finpart_bit)		 
group by #data.idfin,f.codefin ,	f.title ,	f.printingorder


ORDER BY f.printingorder ASC




END



END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
