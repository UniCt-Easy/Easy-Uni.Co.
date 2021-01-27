
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_newbilconsuntivo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_newbilconsuntivo]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--update generalreportparameter set paramvalue='S' WHERE idparam = 'MostraTutteVoci'
--rpt_newbilconsuntivo 2005,'2005-12-31','S',3,'0001','S','S','S','S'

CREATE       PROCEDURE [rpt_newbilconsuntivo]
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@levelusable tinyint,
	@idupb varchar(36),
	@showupb char(1),
	@showchildupb char(1),
	@suppressifblank char(1),
	@officialvar  char(1)
)
AS BEGIN
DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb
IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'


DECLARE	@finpart_bit  tinyint  -- Parte del bilancio ( Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

declare @fin_kind tinyint
SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @ayear


DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'




CREATE TABLE #data
(
	idfin int,
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
	var_maxphase_R decimal(19,2),
	showincomesurplus char(1),
	tosuppress char(1)
)






DECLARE @infoadvance char(1)
SELECT @infoadvance = paramvalue
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
DECLARE @cashvaliditykind int
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
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


DECLARE @minoplevel tinyint
SELECT  @minoplevel = min(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear and flag&2 <> 0

DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable

IF(@levelusable < @minoplevel)
BEGIN
	SET @levelusable = @minoplevel
END



DECLARE @lencod_lev1 int
SELECT @lencod_lev1 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 1
DECLARE @startpos1 int
SELECT @startpos1 = 1
DECLARE @lencod_lev2 int
SELECT @lencod_lev2 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 2
DECLARE @startpos2 int
SELECT @startpos2 = @startpos1 + @lencod_lev1
DECLARE @lencod_lev3 int
SELECT @lencod_lev3 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 3
DECLARE @startpos3 int
SELECT @startpos3 = @startpos2 + @lencod_lev2
DECLARE @lencod_lev4 int
SELECT @lencod_lev4 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 4
DECLARE @startpos4 int
SELECT @startpos4 = @startpos3 + @lencod_lev3
DECLARE @lencod_lev5 int 
SELECT @lencod_lev5 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 5
DECLARE @startpos5 int 
SELECT @startpos5 = @startpos4 + @lencod_lev4

insert into #data (
	idfin,
	idupb,
	initialprevision
)
select finyear.idfin,isnull(@fixedidupb,finyear.idupb),
		ISNULL(SUM(finyear.prevision),0)
from finyear 
	join fin f5 on finyear.idfin=f5.idfin
JOIN finlevel fl
		ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
where f5.ayear = @ayear
		AND (finyear.idupb LIKE @idupb)	
		AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (f5.flag & 16 =0) )-- f5.flagincomesurplus = 'N')
group by finyear.idfin,isnull(@fixedidupb,finyear.idupb)


--select SUBSTRING('123456789', 12, 5)
--tutti gli inserimenti avvengono a livello di @levelusable o inferiore se per quel ramo non esiste un livello così basso
INSERT INTO #data
(
	idfin,
	idupb,
	variation
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	isnull(@fixedidupb,FVD.idupb),
	SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND (FVD.idupb LIKE @idupb)
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin)


INSERT INTO #data
(
	idfin,
	idupb,
	secondaryvariation
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	isnull(@fixedidupb,FVD.idupb),
	SUM(FVD.amount) 
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN  fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND FV.idfinvarstatus = 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND (FVD.idupb LIKE @idupb)
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin)


IF (@finpart = 'E')
BEGIN
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_finphase_C
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		SUM(IY.amount)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE I.adate <= @date
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND (IY.idupb LIKE @idupb)
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_C
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		SUM(IV.amount)
	FROM incomevar IV
	JOIN income I
		ON IV.idinc = I.idinc
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND (IY.idupb LIKE @idupb)
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin) 

IF(	@fin_kind IN ('1','3'))
Begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_finphase_R
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		SUM(IY.amount)
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND I.adate <= @date
		AND (IY.idupb LIKE @idupb)
	GROUP BY isnull(@fixedidupb,IY.idupb), ISNULL(FLK.idparent,IY.idfin) 
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
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		SUM(IV.amount)
	FROM incomevar IV
	JOIN income I
		ON I.idinc = IV.idinc
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND (IY.idupb LIKE @idupb)
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)
end

	INSERT INTO #data
	(
		idfin,
		idupb,	
		mov_maxphase_C
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		isnull(@fixedidupb,HPV.idupb),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 0)--Competenza
		AND HPV.ymov = @ayear
		AND (HPV.idupb LIKE @idupb)
	GROUP BY isnull(@fixedidupb,HPV.idupb), ISNULL(FLK.idparent,HPV.idfin) --

	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_maxphase_R
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin), 
		isnull(@fixedidupb,HPV.idupb),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
		AND (HPV.idupb LIKE @idupb)
	GROUP BY isnull(@fixedidupb,HPV.idupb),ISNULL(FLK.idparent,HPV.idfin)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_C
		)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin), 
			isnull(@fixedidupb,IY.idupb),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
		WHERE IV.yvar = @ayear
			AND IV.adate <= @date
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			AND (HPV.competencydate <= @date AND HPV.ymov = @ayear)
			AND (IY.idupb LIKE @idupb)		
		GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)
	
		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_R
		)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin),
			isnull(@fixedidupb,IY.idupb),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
		WHERE IV.yvar = @ayear
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			AND IV.adate <= @date
			AND (HPV.competencydate <= @date AND HPV.ymov = @ayear)
			AND (IY.idupb LIKE @idupb)		
		GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)  
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
		ISNULL(FLK.idparent,EY.idfin),
		isnull(@fixedidupb,EY.idupb),
		SUM(EY.amount)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND (EY.idupb LIKE @idupb)		
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin) 

	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_C
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin), 
		isnull(@fixedidupb,EY.idupb),
		SUM(EV.amount)
	FROM expensevar EV
	JOIN expense E
		ON EV.idexp = E.idexp
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE EV.yvar = @ayear
		AND EV.adate <= @date 
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND (EY.idupb LIKE @idupb)		
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)


IF(	@fin_kind IN ('1','3'))
Begin
	INSERT INTO #data
	(
		idfin,
		idupb,	
		mov_finphase_R
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin), 
		isnull(@fixedidupb,EY.idupb),
		SUM(EY.amount)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND (EY.idupb LIKE @idupb)		
	GROUP BY isnull(@fixedidupb,EY.idupb), ISNULL(FLK.idparent,EY.idfin) 
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
		ISNULL(FLK.idparent,EY.idfin),
		isnull(@fixedidupb,EY.idupb),
		SUM(EV.amount)
	FROM expensevar EV
	JOIN expense E
		ON EV.idexp = E.idexp
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE EV.yvar = @ayear
		AND EV.adate <= @date 
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND (EY.idupb LIKE @idupb)		
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
end

	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_maxphase_C
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin), 
		isnull(@fixedidupb,EY.idupb),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
		AND (EY.idupb LIKE @idupb)		
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_maxphase_R
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		isnull(@fixedidupb,EY.idupb),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
		AND (EY.idupb LIKE @idupb)		
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin) 

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_C
		)
		SELECT
			ISNULL(FLK.idparent,EY.idfin) ,
			isnull(@fixedidupb,EY.idupb),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)--Competenza
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
			AND (EY.idupb LIKE @idupb)		
		GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin) 

		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_R
		)
		SELECT
			ISNULL(FLK.idparent,EY.idfin),
			isnull(@fixedidupb,EY.idupb),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
			AND (EY.idupb LIKE @idupb)		
		GROUP BY isnull(@fixedidupb,EY.idupb), ISNULL(FLK.idparent,EY.idfin)
	END
END



IF @fin_kind = 2 and exists(select * from fin where ayear=@ayear and (flag&16 <>0) )
BEGIN

if exists(select * from fin F    left outer join #data D on D.idfin=F.idfin
				where F.ayear=@ayear and (F.flag&16 <>0)  and D.idfin is null)
 BEGIN 
  insert into #data (idfin,idupb,mov_maxphase_C)
   select F.idfin, '0001',0 
   from 
    fin F 
    left outer join #data D on D.idfin=F.idfin
     where F.ayear=@ayear and (F.flag&16 <>0)  and D.idfin is null
    
 END

 UPDATE #data SET mov_maxphase_C = ISNULL(initialprevision, 0) + ISNULL(variation, 0)
  where (select F.flag&16 from fin F where #data.idfin=F.idfin) <> 0



END

/*
 Se N qualora per un capitolo non esistano sott-capitoli con legami con l'upb fondo
 NON verrà visualizzata l'indicazione del Titolo/Categoria/Capitolo
*/

UPDATE #data SET tosuppress = 'N'


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

if (@levelusable_original<5) 
	set @lev_desc5='liv5'

if (@levelusable_original<4) 
	set @lev_desc4='liv4'

if (@levelusable_original<3) 
	set @lev_desc3='liv3'


if (@levelusable_original<2) 
	set @lev_desc2='liv2'


IF (@showupb ='S')
BEGIN


SELECT 
	--#balance.idfin,
	SUBSTRING(f.codefin, @startpos1, @lencod_lev1) as code1,
	f1.title AS desc1,
	@lev_desc1 AS descliv1,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,
	SUBSTRING(f.codefin, @startpos2, @lencod_lev2) as code2,
	f2.title AS desc2,
	@lev_desc2 AS descliv2,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) as order2,
	SUBSTRING(f.codefin, @startpos3, @lencod_lev3) as code3,
	f3.title as desc3,
	@lev_desc3 as descliv3,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) as order3,
	SUBSTRING(f.codefin, @startpos4, @lencod_lev4)as code4,
	f4.title AS desc4,
	@lev_desc4 AS descliv4,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) as order4,
	SUBSTRING(f.codefin, @startpos5, @lencod_lev5) as code5,
	f5.title AS desc5,
	@lev_desc5 AS descliv5,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) as order5,
	upb.codeupb,
	upb.idupb as idupb,
	upb.title as upb,
	upb.printingorder as upbprintingorder,
	ISNULL(SUM(initialprevision),0) AS initialprevision,
	ISNULL(SUM(variation),0) AS variation,
	0 AS secondaryprevision,
	0 AS secondaryvariation,
	0 AS currentarrears,
	ISNULL(SUM(mov_finphase_C),0) AS mov_finphase_C,
	ISNULL(SUM(var_finphase_C),0) AS var_finphase_C,
	ISNULL(SUM(mov_maxphase_C),0) AS mov_maxphase_C,
	ISNULL(SUM(var_maxphase_C),0) AS var_maxphase_C,
	ISNULL(SUM(mov_finphase_R),0) AS mov_finphase_R,
	ISNULL(SUM(var_finphase_R),0) AS var_finphase_R,
	ISNULL(SUM(mov_maxphase_R),0) AS mov_maxphase_R,
	ISNULL(SUM(var_maxphase_R),0) AS var_maxphase_R,
	case @fin_kind when 1 then 'C' else 'S' end AS previsionkind,
	showincomesurplus,
	@supposed_ff_jan01 AS supposed_ff_jan01,
	@supposed_aa_jan01 AS supposed_aa_jan01,
	@ff_jan01 AS ff_jan01,
	@aa_jan01 AS aa_jan01,
	isnull(#data.tosuppress, @suppressifblank) AS tosuppress,	
	f.nlevel,
	isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
	isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
	isnull(@aa_01_jan_used,0) as aa_01_jan_used,
	isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used
FROM fin f
	JOIN finlevel fl
		ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
cross join  upb 
left outer join #data on #data.idfin=f.idfin and #data.idupb=upb.idupb
LEFT OUTER JOIN finlink flk1
	ON flk1.idchild = f.idfin AND flk1.nlevel = 1
LEFT OUTER JOIN fin f1
	ON flk1.idparent = f1.idfin 
LEFT OUTER JOIN finlink flk2
	ON flk2.idchild = f.idfin AND flk2.nlevel = 2
LEFT OUTER JOIN fin f2
	ON flk2.idparent = f2.idfin 
LEFT OUTER JOIN finlink flk3
	ON flk3.idchild = f.idfin AND flk3.nlevel = 3
LEFT OUTER JOIN fin f3
	ON flk3.idparent = f3.idfin 
LEFT OUTER JOIN finlink flk4
	ON flk4.idchild = f.idfin AND flk4.nlevel = 4
LEFT OUTER JOIN fin f4
	ON flk4.idparent = f4.idfin 
LEFT OUTER JOIN finlink flk5
	ON flk5.idchild = f.idfin AND flk5.nlevel = 5
LEFT OUTER JOIN fin f5
	ON flk5.idparent = f5.idfin 
where  ( (@MostraTutteVoci = 'S'  or @suppressifblank='N') OR  (upb.idupb='0001' or isnull(#data.tosuppress, 'S')='N')) and
		f.ayear=@ayear 
		AND ((f.flag & 1)= @finpart_bit) 
		AND (f.nlevel = @levelusable_original 
			OR (f.nlevel < @levelusable_original
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
				AND (fl.flag&2)<>0
			   )
			 )
	  and upb.idupb like @idupb
	  
GROUP BY upb.printingorder,upb.idupb,upb.title,upb.codeupb,
	SUBSTRING(f.codefin, @startpos1, @lencod_lev1),
	SUBSTRING(f.codefin, @startpos2, @lencod_lev2),
	SUBSTRING(f.codefin, @startpos3, @lencod_lev3),
	SUBSTRING(f.codefin, @startpos4, @lencod_lev4),
	SUBSTRING(f.codefin, @startpos5, @lencod_lev5),
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1),
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2),
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3),
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4),
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5),
	f1.title,f2.title,f3.title,f4.title,f5.title,
	showincomesurplus,f.nlevel,isnull(#data.tosuppress, @suppressifblank)
ORDER BY upb.printingorder ASC,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) ASC,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) ASC,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) ASC,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) ASC,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) ASC



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
	--#balance.idfin,
	SUBSTRING(f.codefin, @startpos1, @lencod_lev1) as code1,
	f1.title AS desc1,
	@lev_desc1 AS descliv1,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,
	SUBSTRING(f.codefin, @startpos2, @lencod_lev2) as code2,
	f2.title AS desc2,
	@lev_desc2 AS descliv2,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) as order2,
	SUBSTRING(f.codefin, @startpos3, @lencod_lev3) as code3,
	f3.title as desc3,
	@lev_desc3 as descliv3,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) as order3,
	SUBSTRING(f.codefin, @startpos4, @lencod_lev4)as code4,
	f4.title AS desc4,
	@lev_desc4 AS descliv4,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) as order4,
	SUBSTRING(f.codefin, @startpos5, @lencod_lev5) as code5,
	f5.title AS desc5,
	@lev_desc5 AS descliv5,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) as order5,

	@codeupb as codeupb,
	@ext_idupb as idupb,
	@upb as upb,
	@upbprintingorder as upbprintingorder,
	ISNULL(SUM(initialprevision),0) AS initialprevision,
	ISNULL(SUM(variation),0) AS variation,
	0 AS secondaryprevision,
	0 AS secondaryvariation,
	0 AS currentarrears,
	ISNULL(SUM(mov_finphase_C),0) AS mov_finphase_C,
	ISNULL(SUM(var_finphase_C),0) AS var_finphase_C,
	ISNULL(SUM(mov_maxphase_C),0) AS mov_maxphase_C,
	ISNULL(SUM(var_maxphase_C),0) AS var_maxphase_C,
	ISNULL(SUM(mov_finphase_R),0) AS mov_finphase_R,
	ISNULL(SUM(var_finphase_R),0) AS var_finphase_R,
	ISNULL(SUM(mov_maxphase_R),0) AS mov_maxphase_R,
	ISNULL(SUM(var_maxphase_R),0) AS var_maxphase_R,
	case @fin_kind when 1 then 'C' else 'S' end AS previsionkind,
	showincomesurplus,
	@supposed_ff_jan01 AS supposed_ff_jan01,
	@supposed_aa_jan01 AS supposed_aa_jan01,
	@ff_jan01 AS ff_jan01,
	@aa_jan01 AS aa_jan01,
	isnull(#data.tosuppress, @suppressifblank) AS tosuppress,	
	f.nlevel,
	isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
	isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
	isnull(@aa_01_jan_used,0) as aa_01_jan_used,
	isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used
FROM fin f
	JOIN finlevel fl
		ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
left outer join #data on #data.idfin=f.idfin 
LEFT OUTER JOIN finlink flk1
	ON flk1.idchild = f.idfin AND flk1.nlevel = 1
LEFT OUTER JOIN fin f1
	ON flk1.idparent = f1.idfin 
LEFT OUTER JOIN finlink flk2
	ON flk2.idchild = f.idfin AND flk2.nlevel = 2
LEFT OUTER JOIN fin f2
	ON flk2.idparent = f2.idfin 
LEFT OUTER JOIN finlink flk3
	ON flk3.idchild = f.idfin AND flk3.nlevel = 3
LEFT OUTER JOIN fin f3
	ON flk3.idparent = f3.idfin 
LEFT OUTER JOIN finlink flk4
	ON flk4.idchild = f.idfin AND flk4.nlevel = 4
LEFT OUTER JOIN fin f4
	ON flk4.idparent = f4.idfin 
LEFT OUTER JOIN finlink flk5
	ON flk5.idchild = f.idfin AND flk5.nlevel = 5
LEFT OUTER JOIN fin f5
	ON flk5.idparent = f5.idfin 
where ((@MostraTutteVoci = 'S'  or @suppressifblank='N')  OR  (#data.idupb='0001' or isnull(#data.tosuppress, 'S')='N')) AND
		f.ayear=@ayear 
		AND ((f.flag & 1)= @finpart_bit) 
		AND (f.nlevel = @levelusable_original 
			OR (f.nlevel < @levelusable_original
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
				AND (fl.flag&2)<>0
			   )
			 )
	  
	  
GROUP BY 
	SUBSTRING(f.codefin, @startpos1, @lencod_lev1),
	SUBSTRING(f.codefin, @startpos2, @lencod_lev2),
	SUBSTRING(f.codefin, @startpos3, @lencod_lev3),
	SUBSTRING(f.codefin, @startpos4, @lencod_lev4),
	SUBSTRING(f.codefin, @startpos5, @lencod_lev5),
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1),
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2),
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3),
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4),
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5),
	f1.title,f2.title,f3.title,f4.title,f5.title,
	showincomesurplus,f.nlevel,isnull(#data.tosuppress, @suppressifblank)
ORDER BY 
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) ASC,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) ASC,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) ASC,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) ASC,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) ASC
END



















END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

