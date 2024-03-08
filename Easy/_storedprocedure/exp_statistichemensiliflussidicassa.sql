
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_statistichemensiliflussidicassa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_statistichemensiliflussidicassa]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE   PROCEDURE exp_statistichemensiliflussidicassa(
	@ayear int,
	@finpart char(1),
	@officialvar char(1),
	@suppressifblank char(1),
	@insidecall char(1)  -- E' un parametro nascosto che indica che la sp è chiamata internamente dalla sp Previsione liquidità o meno.
)
AS BEGIN
--	exec exp_statistichemensiliflussidicassa 2011 , 'S', 'N', 'S','S'
DECLARE	@finpart_bit  tinyint  -- Parte del bilancio ( Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

CREATE TABLE #balance(
	idfin int,
	mese int,
	flag smallint,
	initialprevision decimal(19,2),
	variation decimal(19,2),
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

DECLARE @levelusable tinyint
SELECT  @levelusable = min(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear and flag&2 <> 0


INSERT INTO #balance(
	idfin, mese, flag,
	initialprevision
)
	SELECT F.idfin, monthname.code, F.flag,
		ISNULL(SUM(finyear.prevision),0)
	FROM fin F
	join finlevel FL
		ON F.nlevel = FL.nlevel
		AND FL.ayear = F.ayear
	LEFT OUTER JOIN finyear
		ON finyear.idfin = F.idfin
	CROSS JOIN monthname
	WHERE F.ayear = @ayear
		AND ((F.flag & 1)= @finpart_bit) 
		AND (F.nlevel = @levelusable
			OR (F.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = F.idfin)
				AND (FL.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )-- f5.flagincomesurplus = 'N')
	GROUP BY F.idfin, monthname.code,F.flag

CREATE TABLE #tot_varprev_M (idfin int, total decimal(19,2), mese int)
INSERT INTO #tot_varprev_M
(
	idfin,
	total,
	mese
)
SELECT 
	ISNULL(FLK.idparent,FVD.idfin),
	SUM(FVD.amount),
	MONTH(FV.adate)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) 
	AND F.ayear = @ayear
GROUP BY ISNULL(FLK.idparent,FVD.idfin),MONTH(FV.adate)


CREATE TABLE #mov_finphase_C (idfin int, total decimal(19,2), mese int)
CREATE TABLE #var_finphase_C (idfin int, total decimal(19,2), mese int)
CREATE TABLE #mov_finphase_R (idfin int, total decimal(19,2), mese int)
CREATE TABLE #var_finphase_R (idfin int, total decimal(19,2), mese int)
CREATE TABLE #mov_maxphase_C (idfin int, total decimal(19,2), mese int)
CREATE TABLE #var_maxphase_C (idfin int, total decimal(19,2), mese int)
CREATE TABLE #mov_maxphase_R (idfin int, total decimal(19,2), mese int)
CREATE TABLE #var_maxphase_R (idfin int, total decimal(19,2), mese int)

IF (@finpart = 'E')
BEGIN
	INSERT INTO #mov_finphase_C
	(
		idfin,
		total,	
		mese
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		SUM(IY.amount),	
		MONTH(I.adate)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
	GROUP BY ISNULL(FLK.idparent,IY.idfin),MONTH(I.adate)

	INSERT INTO #var_finphase_C
	(
		idfin,
		total,
		mese
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		SUM(IV.amount),
		MONTH(IV.adate)
	FROM incomevar IV
	JOIN income I
		ON IV.idinc = I.idinc
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
	GROUP BY ISNULL(FLK.idparent,IY.idfin),MONTH(IV.adate) 

	INSERT INTO #mov_finphase_R
	(
		idfin,
		total,
		mese
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		SUM(IY.amount),
		month(I.adate )
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IY.ayear = @ayear
		AND ( (IT.flag & 1) <>0 )-- Residuo
		AND I.nphase = @finphase
	GROUP BY ISNULL(FLK.idparent,IY.idfin), month(I.adate ) 

	INSERT INTO #var_finphase_R
	(
		idfin,
		total,
		mese
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		SUM(IV.amount),
		month(IV.adate)
	FROM incomevar IV
	JOIN income I
		ON I.idinc = IV.idinc
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) <> 0)-- Residuo
		AND I.nphase = @finphase
	GROUP BY ISNULL(FLK.idparent,IY.idfin), month(IV.adate)

	INSERT INTO #mov_maxphase_C
	(
		idfin,
		total,
		mese
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(HPV.amount),
		month(HPV.competencydate)
	FROM historyproceedsview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE ( (HPV.totflag & 1) = 0)--Competenza
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,HPV.idfin), month(HPV.competencydate) 

	INSERT INTO #mov_maxphase_R
	(
		idfin,
		total,
		mese
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin), 
		SUM(HPV.amount),
		month(HPV.competencydate)
	FROM historyproceedsview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE ( (HPV.totflag & 1) <> 0)-- Residuo
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,HPV.idfin), month(HPV.competencydate)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #var_maxphase_C
		(
			idfin,
			total,
			mese
		)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin), 
			SUM(IV.amount),
			month(HPV.competencydate)	--> Consideriamo la data contabile del pagamento a cui si riferisce la variazione
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			AND HPV.ymov = @ayear	
		GROUP BY ISNULL(FLK.idparent,IY.idfin), month(HPV.competencydate)
	
		INSERT INTO #var_maxphase_R
		(
			idfin,
			total,
			mese
		)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin),
			SUM(IV.amount),
			month(HPV.competencydate) --> Consideriamo la data contabile del pagamento a cui si riferisce la variazione
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) <> 0 )-- Residuo
			AND HPV.ymov = @ayear 
		GROUP BY ISNULL(FLK.idparent,IY.idfin), month(HPV.competencydate)  
	END
END
IF (@finpart = 'S')
BEGIN
	INSERT INTO #mov_finphase_C
	(
		idfin,
		total,
		mese
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		SUM(EY.amount),
		month(E.adate)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE  EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
	GROUP BY ISNULL(FLK.idparent,EY.idfin) , month(E.adate)

	INSERT INTO #var_finphase_C
	(
		idfin,
		total,
		mese
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin), 
		SUM(EV.amount),
		month(EV.adate)
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
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
	GROUP BY ISNULL(FLK.idparent,EY.idfin),month(EV.adate) 

	INSERT INTO #mov_finphase_R
	(
		idfin,
		total,
		mese
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		SUM(EY.amount),
		month(E.adate)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE  EY.ayear = @ayear
		AND ( (ET.flag & 1) <> 0) -- Residuo
		AND E.nphase = @finphase
	GROUP BY ISNULL(FLK.idparent,EY.idfin) , month(E.adate)

	INSERT INTO #var_finphase_R
	(
		idfin,
		total,
		mese
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		SUM(EV.amount),
		month(EV.adate)
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
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) <> 0) -- Residuo
		AND E.nphase = @finphase
	GROUP BY ISNULL(FLK.idparent,EY.idfin), month(EV.adate)

	INSERT INTO #mov_maxphase_C(
		idfin,
		total,
		mese
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin), 
		SUM(HPV.amount),
		month(HPV.competencydate)
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,EY.idfin), month(HPV.competencydate)



	INSERT INTO #mov_maxphase_R(
		idfin,
		total,
		mese
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		SUM(HPV.amount),
		month(HPV.competencydate)
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EY.ayear = @ayear
		AND ( (HPV.totflag & 1) <> 0)-- Residuo
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,EY.idfin) , month(HPV.competencydate)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #var_maxphase_C(
			idfin,
			total,
			mese
		)
		SELECT
			ISNULL(FLK.idparent,EY.idfin) ,
			SUM(EV.amount),
			month(HPV.competencydate)	--> Consideriamo la data contabile del pagamento a cui si riferisce la variazione
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)--Competenza
			AND HPV.ymov = @ayear 
		GROUP BY ISNULL(FLK.idparent,EY.idfin) , month(HPV.competencydate)



		INSERT INTO #var_maxphase_R(
			idfin,
			total,
			mese
		)
		SELECT
			ISNULL(FLK.idparent,EY.idfin),
			SUM(EV.amount),
			month(HPV.competencydate)--> Consideriamo la data contabile del pagamento a cui si riferisce la variazione
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) <> 0)-- Residuo
			AND HPV.ymov = @ayear -- DA CONTROLLARE
		GROUP BY ISNULL(FLK.idparent,EY.idfin),month(HPV.competencydate)
	END
END


UPDATE #balance
SET variation =
ISNULL(
	(SELECT #tot_varprev_M.total FROM #tot_varprev_M
	WHERE #tot_varprev_M.idfin = #balance.idfin and #tot_varprev_M.mese = #balance.mese)
, 0),

mov_finphase_C =
ISNULL(
	(SELECT #mov_finphase_C.total FROM #mov_finphase_C
	WHERE  #mov_finphase_C.idfin = #balance.idfin and #mov_finphase_C.mese = #balance.mese), 0),

var_finphase_C =
ISNULL(
	(SELECT #var_finphase_C.total FROM #var_finphase_C
	WHERE  #var_finphase_C.idfin = #balance.idfin and #var_finphase_C.mese = #balance.mese)
, 0),

mov_maxphase_C =
ISNULL(
	(SELECT #mov_maxphase_C.total FROM #mov_maxphase_C
	WHERE #mov_maxphase_C.idfin = #balance.idfin	and #mov_maxphase_C.mese = #balance.mese)
, 0),

var_maxphase_C =
ISNULL(
	(SELECT #var_maxphase_C.total FROM #var_maxphase_C	
	WHERE #var_maxphase_C.idfin = #balance.idfin and #var_maxphase_C.mese = #balance.mese)
, 0),

mov_finphase_R =
ISNULL(
	(SELECT #mov_finphase_R.total FROM #mov_finphase_R
	WHERE #mov_finphase_R.idfin = #balance.idfin and #mov_finphase_R.mese = #balance.mese)
, 0),

var_finphase_R =
ISNULL(
	(SELECT #var_finphase_R.total FROM #var_finphase_R
	WHERE  #var_finphase_R.idfin = #balance.idfin 	and #var_finphase_R.mese = #balance.mese)
, 0),

mov_maxphase_R =
ISNULL(
	(SELECT #mov_maxphase_R.total FROM #mov_maxphase_R
        WHERE #mov_maxphase_R.idfin = #balance.idfin and #mov_maxphase_R.mese = #balance.mese)
, 0),

var_maxphase_R =
ISNULL(
	(SELECT #var_maxphase_R.total FROM #var_maxphase_R
	WHERE #var_maxphase_R.idfin = #balance.idfin and #var_maxphase_R.mese = #balance.mese)
, 0)



declare @fin_kind tinyint
SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @ayear
IF @fin_kind = 2
BEGIN
	UPDATE #balance
	SET mov_maxphase_C = ISNULL(initialprevision, 0) + ISNULL(variation, 0)
	WHERE (F.flag & 16 <>0)
END

/*
 Se N qualora per un capitolo non esistano sott-capitoli con legami con l'upb fondo
 NON verrà visualizzata l'indicazione del Titolo/Categoria/Capitolo
*/
IF( @suppressifblank = 'S' )
BEGIN
	DELETE FROM #balance 
	WHERE ISNULL(initialprevision,0)= 0
		AND ISNULL(variation,0)= 0
		AND ISNULL(mov_finphase_C,0)= 0
		AND ISNULL(var_finphase_C,0)= 0
		AND ISNULL(mov_maxphase_C,0)= 0
		AND ISNULL(var_maxphase_C,0)= 0
		AND ISNULL(mov_finphase_R,0)= 0
		AND ISNULL(var_finphase_R,0)= 0
		AND ISNULL(mov_maxphase_R,0)= 0
		AND ISNULL(var_maxphase_R,0)= 0
		AND @fin_kind IN ('1','3')

	DELETE FROM #balance 
	WHERE ISNULL(initialprevision,0)= 0
		AND ISNULL(variation,0)= 0
		AND ISNULL(mov_finphase_C,0)= 0
		AND ISNULL(var_finphase_C,0)= 0
		AND ISNULL(mov_maxphase_C,0)= 0
		AND ISNULL(var_maxphase_C,0)= 0
		AND ISNULL(mov_maxphase_R,0)= 0
		AND ISNULL(var_maxphase_R,0)= 0
		AND @fin_kind IN ('2')
END

/*

Previniziale = initialprevision
PrevFineMese = initialprevision + (variation where mese=...) 
PrevConsuntivo3112 = initialprevision + variation(tutte)
ResiduiFineAnno3112 = 
Secondo il Consuntivo sono:impegni rimasti da pagare + Residui rimasti da pagare
	ove :
	Impegni rimasti da pagare = mov_finphase_C +  var_finphase_C -  mov_maxphase_C -  var_maxphase_C
	Residui rimasti da pagare = mov_finphase_R +  var_finphase_R - mov_maxphase_R -  var_maxphase_R
MENTRE in questa sp saranno calcolati come:
	Residui 01/01 al netto delle loro variazioni = mov_finphase_R +  var_finphase_R 

PagatoCompetenza  = mov_maxphase_C + var_maxphase_C WHERE MESE=...
PagatoResiduo = mov_maxphase_R + var_maxphase_R WHERE MESE=...
MeseRiferimento int
*/

CREATE TABLE #OUT(
idfin int,
_01Previniziale decimal (19,2),_01PrevFineMese decimal(19,2),_01PagatoCompetenza decimal(19,2),_01PagatoResiduo decimal(19,2),
_02Previniziale decimal (19,2),_02PrevFineMese decimal(19,2),_02PagatoCompetenza decimal(19,2),_02PagatoResiduo decimal(19,2),	
_03Previniziale decimal (19,2),_03PrevFineMese decimal(19,2),_03PagatoCompetenza decimal(19,2),_03PagatoResiduo decimal(19,2),
_04Previniziale decimal (19,2),_04PrevFineMese decimal(19,2),_04PagatoCompetenza decimal(19,2),_04PagatoResiduo decimal(19,2),
_05Previniziale decimal (19,2),_05PrevFineMese decimal(19,2),_05PagatoCompetenza decimal(19,2),_05PagatoResiduo decimal(19,2),
_06Previniziale decimal (19,2),_06PrevFineMese decimal(19,2),_06PagatoCompetenza decimal(19,2),_06PagatoResiduo decimal(19,2),
_07Previniziale decimal (19,2),_07PrevFineMese decimal(19,2),_07PagatoCompetenza decimal(19,2),_07PagatoResiduo decimal(19,2),
_08Previniziale decimal (19,2),_08PrevFineMese decimal(19,2),_08PagatoCompetenza decimal(19,2),_08PagatoResiduo decimal(19,2),
_09Previniziale decimal (19,2),_09PrevFineMese decimal(19,2),_09PagatoCompetenza decimal(19,2),_09PagatoResiduo decimal(19,2),
_10Previniziale decimal (19,2),_10PrevFineMese decimal(19,2),_10PagatoCompetenza decimal(19,2),_10PagatoResiduo decimal(19,2),
_11Previniziale decimal (19,2),_11PrevFineMese decimal(19,2),_11PagatoCompetenza decimal(19,2),_11PagatoResiduo decimal(19,2),
_12Previniziale decimal (19,2),_12PrevFineMese decimal(19,2),_12PagatoCompetenza decimal(19,2),_12PagatoResiduo decimal(19,2),

ResiduiFineAnno3112 decimal(19,2),	
PrevConsuntivo3112 decimal(19,2)
)


INSERT INTO #OUT(idfin) 
SELECT idfin
FROM #balance
GROUP BY idfin

-------------------
-- Primo Cursore
-------------------
declare @sql nvarchar(3000)

DECLARE @idfin int
DECLARE @mese int
DECLARE @initialprevision decimal(19,2)
DECLARE @variation decimal(19,2)
DECLARE @mov_finphase_C decimal(19,2)
DECLARE @var_finphase_C decimal(19,2)
DECLARE @mov_maxphase_C decimal(19,2)
DECLARE @var_maxphase_C decimal(19,2)
DECLARE @mov_finphase_R decimal(19,2)
DECLARE @var_finphase_R decimal(19,2)
DECLARE @mov_maxphase_R decimal(19,2)
DECLARE @var_maxphase_R decimal(19,2)

DECLARE @ColonnaMese varchar(2)
DECLARE rowcursor INSENSITIVE CURSOR FOR
SELECT idfin, mese,
	isnull(initialprevision,0),	isnull(variation,0),
	isnull(mov_finphase_C,0),	isnull(var_finphase_C,0),
	isnull(mov_maxphase_C,0),	isnull(var_maxphase_C,0),
	isnull(mov_finphase_R,0),	isnull(var_finphase_R,0),
	isnull(mov_maxphase_R,0),	isnull(var_maxphase_R,0)
FROM #balance

FOR READ ONLY

OPEN rowcursor FETCH  NEXT FROM rowcursor
INTO @idfin, @mese,@initialprevision,@variation,@mov_finphase_C,@var_finphase_C,@mov_maxphase_C,@var_maxphase_C,@mov_finphase_R,@var_finphase_R,@mov_maxphase_R,@var_maxphase_R
WHILE @@FETCH_STATUS = 0
BEGIN 
	
		SET @ColonnaMese = ISNULL(REPLICATE('0', 2-DATALENGTH(CONVERT(varchar(2),@mese))) + CONVERT(varchar(2),@mese),REPLICATE('0',2))

		SET @sql = 	'UPDATE #OUT SET _' + @ColonnaMese+'Previniziale = '+ convert(varchar(20),@initialprevision)
					+ ' WHERE idfin = '+ convert(varchar(20), @idfin)

		EXECUTE sp_executesql @sql
print @sql
		SET @sql = 	'UPDATE #OUT SET _'+@ColonnaMese+'PrevFineMese = ' + convert(varchar(20),@initialprevision)+ ' + '+convert(varchar(20),@variation)
					+ ' + isnull(( SELECT SUM (variation)'
					+ ' FROM #Balance B WHERE B.idfin = '+ convert(varchar(20), @idfin)+' AND B.mese <'+convert(varchar(2),@mese)
					+ ' ),0)'
					+ ' WHERE idfin = '+ convert(varchar(20), @idfin)

		EXECUTE sp_executesql @sql
print @sql
		SET @sql = ' UPDATE #OUT SET _'+@ColonnaMese+'PagatoCompetenza = '+ convert(varchar(20),@mov_maxphase_C)+ ' + '+ convert(varchar(20),@var_maxphase_C)  
					+ ' WHERE idfin = '+ convert(varchar(20), @idfin)
		EXECUTE sp_executesql @sql
print @sql
		SET @sql = 'UPDATE #OUT SET _'+@ColonnaMese+'PagatoResiduo = '+ convert(varchar(20),@mov_maxphase_R)+ ' + '+ convert(varchar(20),@var_maxphase_R)  
					+ ' WHERE idfin = '+ convert(varchar(20), @idfin)

		EXECUTE sp_executesql @sql
print @sql
	FETCH NEXT FROM rowcursor INTO  @idfin, @mese,@initialprevision,@variation,@mov_finphase_C,@var_finphase_C,@mov_maxphase_C,@var_maxphase_C,@mov_finphase_R,@var_finphase_R,@mov_maxphase_R,@var_maxphase_R

END 
DEALLOCATE rowcursor

-------------------
-- Secondo Cursore
-------------------
/*SELECT idfin as #balance ,	--sara
	initialprevision,	sum(variation) as variation,
	sum(mov_finphase_C) as mov_finphase_C,	sum(var_finphase_C) as var_finphase_C,
	sum(mov_maxphase_C) as mov_maxphase_C,	sum(var_maxphase_C) as var_maxphase_C,
	sum(mov_finphase_R) as mov_finphase_R,	sum(var_finphase_R) as var_finphase_R,
	sum(mov_maxphase_R) as mov_maxphase_R,	sum(var_maxphase_R) as var_maxphase_R
FROM #balance
WHERE idfin = 1490
GROUP BY idfin, initialprevision
*/

DECLARE rowcursor2 INSENSITIVE CURSOR FOR
SELECT idfin, 
	initialprevision,	sum(variation),
	sum(mov_finphase_C),	sum(var_finphase_C),
	sum(mov_maxphase_C),	sum(var_maxphase_C),
	sum(mov_finphase_R),	sum(var_finphase_R),
	sum(mov_maxphase_R),	sum(var_maxphase_R)
FROM #balance
GROUP BY idfin, initialprevision

FOR READ ONLY

OPEN rowcursor2 FETCH  NEXT FROM rowcursor2
INTO @idfin, @initialprevision,@variation,@mov_finphase_C,@var_finphase_C,@mov_maxphase_C,@var_maxphase_C,@mov_finphase_R,@var_finphase_R,@mov_maxphase_R,@var_maxphase_R
WHILE @@FETCH_STATUS = 0
BEGIN 
		SET @sql= 'UPDATE #OUT	SET ResiduiFineAnno3112= '+
							+ ' + '+ convert(varchar(20), @mov_finphase_R) 
							+ ' + '+ convert(varchar(20), @var_finphase_R) 
							+ ' WHERE idfin = '+ convert(varchar(20), @idfin)
		EXECUTE sp_executesql @sql

		SET @sql = 'UPDATE #OUT SET PrevConsuntivo3112 = '+ convert(varchar(20),@initialprevision) + ' + '+ convert(varchar(20),@variation)
			+ ' WHERE idfin = '+ convert(varchar(20), @idfin)
		EXECUTE sp_executesql @sql					

	FETCH NEXT FROM rowcursor2 INTO  @idfin, @initialprevision,@variation,@mov_finphase_C,@var_finphase_C,@mov_maxphase_C,@var_maxphase_C,@mov_finphase_R,@var_finphase_R,@mov_maxphase_R,@var_maxphase_R

END 
DEALLOCATE rowcursor2
/*
SELECT F.codefin, O._12pagatocompetenza,O.* -- sara
FROM #OUT O
JOIN fin F
	ON F.idfin = O.idfin 
WHERE F.codefin = '015006'
ORDER BY F.printingorder ASC
RETURN
*/
--------------------
-- SELECT FINALE
--------------------
IF (@insidecall='N')
BEGIN
	SELECT 
		F.codefin as Capitolo,
	-- incassato/pagato in conto competenza 
		_01PagatoCompetenza as 'Gen. Comp.',
	-- incassato/pagato in conto conto residui 
		_01PagatoResiduo as 'Gen.Res.',
	-- % dell'incassato/pagato di competenza rispetto alla previsione iniziale
		Case When _01Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_01PagatoCompetenza / _01Previniziale)*100 ,2)))+'%'
		End as 'Gen.% Comp. 01.01',
	-- % dell'incassato/pagato di competenza rispetto alla previsione alla fine del mese di riferimento
		Case when ( _01PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_01PagatoCompetenza / _01PrevFineMese)*100  ,2)))+'%'
		End as 'Gen.% Comp. Mese',
	-- % dell'incassato/pagato di competenza rispetto alla previsione a consuntivo
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_01PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Gen.% Comp. 31.12',
	-- % dell'incassato/pagato residuo rispetto ai residui del capitolo alla fine dell'anno 
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_01PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Gen.% Res.',


	-- Febbraio
		_02PagatoCompetenza as 'Feb. Comp.',
		_02PagatoResiduo as 'Feb.Res.',
		Case When _02Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_02PagatoCompetenza / _02Previniziale)*100 ,2)))+'%'
		End as 'Feb.% Comp. 01.01',
		Case when ( _02PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_02PagatoCompetenza / _02PrevFineMese)*100  ,2)))+'%'
		End as 'Feb.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_02PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Feb.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_02PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Feb.% Res.',

	-- Marzo
		_03PagatoCompetenza as 'Mar. Comp.',
		_03PagatoResiduo as 'Mar.Res.',
		Case When _03Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_03PagatoCompetenza / _03Previniziale)*100 ,2)))+'%'
		End as 'Mar.% Comp. 01.01',
		Case when ( _03PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_03PagatoCompetenza / _03PrevFineMese)*100  ,2)))+'%'
		End as 'Mar.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_03PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Mar.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_03PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Mar.% Res.',

	-- Aprile
		_04PagatoCompetenza as 'Apr. Comp.',
		_04PagatoResiduo as 'Apr.Res.',
		Case When _04Previniziale=0 Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_04PagatoCompetenza / _04Previniziale)*100  ,2)))+'%'
		End as 'Apr.% Comp. 01.01',
		Case when ( _04PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_04PagatoCompetenza / _04PrevFineMese)*100  ,2)))+'%'
		End as 'Apr.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_04PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Apr.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_04PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Apr.% Res.',

	-- Maggio
		_05PagatoCompetenza as 'Mag. Comp.',
		_05PagatoResiduo as 'Mag.Res.',
		Case When _05Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_05PagatoCompetenza / _05Previniziale)*100 ,2)))+'%'
		End as 'Mag.% Comp. 01.01',
		Case when ( _05PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_05PagatoCompetenza / _05PrevFineMese)*100  ,2)))+'%'
		End as 'Mag.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_05PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Mag.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_05PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Mag.% Res.',

	-- Giugno
		_06PagatoCompetenza as 'Giu. Comp.',
		_06PagatoResiduo as 'Giu.Res.',
		Case When _06Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_06PagatoCompetenza / _06Previniziale)*100 ,2)))+'%'
		End as 'Giu.% Comp. 01.01',
		Case when ( _06PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_06PagatoCompetenza / _06PrevFineMese)*100  ,2)))+'%'
		End as 'Giu.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_06PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Giu.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_06PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Giu.% Res.',

	-- Luglio
		_07PagatoCompetenza as 'Lug. Comp.',
		_07PagatoResiduo as 'Lug.Res.',
		Case When _07Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_07PagatoCompetenza / _07Previniziale)*100 ,2)))+'%'
		End as 'Lug.% Comp. 01.01',
		Case when ( _07PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_07PagatoCompetenza / _07PrevFineMese)*100  ,2)))+'%'
		End as 'Lug.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_07PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Lug.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_07PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Lug.% Res.',

	-- Agosto
		_08PagatoCompetenza as 'Ago. Comp.',
		_08PagatoResiduo as 'Ago.Res.',
		Case When _08Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_08PagatoCompetenza / _08Previniziale)*100 ,2)))+'%'
		End as 'Ago.% Comp. 01.01',
		Case when ( _08PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_08PagatoCompetenza / _08PrevFineMese)*100  ,2)))+'%'
		End as 'Ago.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_08PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Ago.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_08PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Ago.% Res.',

	-- Settembre
		_09PagatoCompetenza as 'Set. Comp.',
		_09PagatoResiduo as 'Set.Res.',
		Case When _09Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_09PagatoCompetenza / _09Previniziale)*100 ,2)))+'%'
		End as 'Set.% Comp. 01.01',
		Case when ( _09PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_09PagatoCompetenza / _09PrevFineMese)*100  ,2)))+'%'
		End as 'Set.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_09PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Set.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_09PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Set.% Res.',

	-- Ottobre
		_10PagatoCompetenza as 'Ott. Comp.',
		_10PagatoResiduo as 'Ott.Res.',
		Case When _10Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_10PagatoCompetenza / _10Previniziale)*100 ,2)))+'%'
		End as 'Ott.% Comp. 01.01',
		Case when ( _10PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_10PagatoCompetenza / _10PrevFineMese)*100  ,2)))+'%'
		End as 'Ott.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_10PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Ott.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_10PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Ott.% Res.',

	-- Novembre
		_11PagatoCompetenza as 'Nov. Comp.',
		_11PagatoResiduo as 'Nov.Res.',
		Case When _11Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_11PagatoCompetenza / _11Previniziale)*100 ,2)))+'%'
		End as 'Nov.% Comp. 01.01',
		Case when ( _11PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_11PagatoCompetenza / _11PrevFineMese)*100  ,2)))+'%'
		End as 'Nov.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_11PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Nov.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_11PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Nov.% Res.',

	-- Dicembre
		_12PagatoCompetenza as 'Dic. Comp.',
		_12PagatoResiduo as 'Dic.Res.',
		Case When _12Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_12PagatoCompetenza / _12Previniziale)*100 ,2)))+'%'
		End as 'Dic.% Comp. 01.01',
		Case when ( _12PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_12PagatoCompetenza / _12PrevFineMese)*100  ,2)))+'%'
		End as 'Dic.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_12PagatoCompetenza / PrevConsuntivo3112)*100  ,2)))+'%'
		End as 'Dic.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_12PagatoResiduo / ResiduiFineAnno3112)*100 ,2)))+'%'
		End  as'Dic.% Res.'
	FROM #OUT O
	JOIN fin F
		ON F.idfin = O.idfin 
	ORDER BY F.printingorder ASC
END
ELSE
BEGIN
	SELECT 
		F.codefin as Capitolo,
	-- incassato/pagato in conto competenza 
		_01PagatoCompetenza as 'Gen. Comp.',
	-- incassato/pagato in conto conto residui 
		_01PagatoResiduo as 'Gen.Res.',
	-- % dell'incassato/pagato di competenza rispetto alla previsione iniziale
		Case When _01Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_01PagatoCompetenza / _01Previniziale) ,2)))
		End as 'Gen.% Comp. 01.01',
	-- % dell'incassato/pagato di competenza rispetto alla previsione alla fine del mese di riferimento
		Case when ( _01PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_01PagatoCompetenza / _01PrevFineMese)  ,2)))
		End as 'Gen.% Comp. Mese',
	-- % dell'incassato/pagato di competenza rispetto alla previsione a consuntivo
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_01PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Gen.% Comp. 31.12',
	-- % dell'incassato/pagato residuo rispetto ai residui del capitolo alla fine dell'anno 
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_01PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Gen.% Res.',


	-- Febbraio
		_02PagatoCompetenza as 'Feb. Comp.',
		_02PagatoResiduo as 'Feb.Res.',
		Case When _02Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_02PagatoCompetenza / _02Previniziale) ,2)))
		End as 'Feb.% Comp. 01.01',
		Case when ( _02PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_02PagatoCompetenza / _02PrevFineMese)  ,2)))
		End as 'Feb.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_02PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Feb.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_02PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Feb.% Res.',

	-- Marzo
		_03PagatoCompetenza as 'Mar. Comp.',
		_03PagatoResiduo as 'Mar.Res.',
		Case When _03Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_03PagatoCompetenza / _03Previniziale) ,2)))
		End as 'Mar.% Comp. 01.01',
		Case when ( _03PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_03PagatoCompetenza / _03PrevFineMese)  ,2)))
		End as 'Mar.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_03PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Mar.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_03PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Mar.% Res.',

	-- Aprile
		_04PagatoCompetenza as 'Apr. Comp.',
		_04PagatoResiduo as 'Apr.Res.',
		Case When _04Previniziale=0 Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_04PagatoCompetenza / _04Previniziale)  ,2)))
		End as 'Apr.% Comp. 01.01',
		Case when ( _04PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_04PagatoCompetenza / _04PrevFineMese)  ,2)))
		End as 'Apr.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_04PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Apr.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_04PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Apr.% Res.',

	-- Maggio
		_05PagatoCompetenza as 'Mag. Comp.',
		_05PagatoResiduo as 'Mag.Res.',
		Case When _05Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_05PagatoCompetenza / _05Previniziale) ,2)))
		End as 'Mag.% Comp. 01.01',
		Case when ( _05PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_05PagatoCompetenza / _05PrevFineMese)  ,2)))
		End as 'Mag.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_05PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Mag.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_05PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Mag.% Res.',

	-- Giugno
		_06PagatoCompetenza as 'Giu. Comp.',
		_06PagatoResiduo as 'Giu.Res.',
		Case When _06Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_06PagatoCompetenza / _06Previniziale) ,2)))
		End as 'Giu.% Comp. 01.01',
		Case when ( _06PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_06PagatoCompetenza / _06PrevFineMese)  ,2)))
		End as 'Giu.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_06PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Giu.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_06PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Giu.% Res.',

	-- Luglio
		_07PagatoCompetenza as 'Lug. Comp.',
		_07PagatoResiduo as 'Lug.Res.',
		Case When _07Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_07PagatoCompetenza / _07Previniziale) ,2)))
		End as 'Lug.% Comp. 01.01',
		Case when ( _07PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_07PagatoCompetenza / _07PrevFineMese)  ,2)))
		End as 'Lug.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_07PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Lug.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_07PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Lug.% Res.',

	-- Agosto
		_08PagatoCompetenza as 'Ago. Comp.',
		_08PagatoResiduo as 'Ago.Res.',
		Case When _08Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_08PagatoCompetenza / _08Previniziale) ,2)))
		End as 'Ago.% Comp. 01.01',
		Case when ( _08PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_08PagatoCompetenza / _08PrevFineMese)  ,2)))
		End as 'Ago.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_08PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Ago.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_08PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Ago.% Res.',

	-- Settembre
		_09PagatoCompetenza as 'Set. Comp.',
		_09PagatoResiduo as 'Set.Res.',
		Case When _09Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_09PagatoCompetenza / _09Previniziale) ,2)))
		End as 'Set.% Comp. 01.01',
		Case when ( _09PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_09PagatoCompetenza / _09PrevFineMese)  ,2)))
		End as 'Set.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_09PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Set.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_09PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Set.% Res.',

	-- Ottobre
		_10PagatoCompetenza as 'Ott. Comp.',
		_10PagatoResiduo as 'Ott.Res.',
		Case When _10Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_10PagatoCompetenza / _10Previniziale) ,2)))
		End as 'Ott.% Comp. 01.01',
		Case when ( _10PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_10PagatoCompetenza / _10PrevFineMese)  ,2)))
		End as 'Ott.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_10PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Ott.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_10PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Ott.% Res.',

	-- Novembre
		_11PagatoCompetenza as 'Nov. Comp.',
		_11PagatoResiduo as 'Nov.Res.',
		Case When _11Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_11PagatoCompetenza / _11Previniziale) ,2)))
		End as 'Nov.% Comp. 01.01',
		Case when ( _11PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_11PagatoCompetenza / _11PrevFineMese)  ,2)))
		End as 'Nov.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_11PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Nov.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_11PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Nov.% Res.',

	-- Dicembre
		_12PagatoCompetenza as 'Dic. Comp.',
		_12PagatoResiduo as 'Dic.Res.',
		Case When _12Previniziale=0 Then NULL
			 Else CONVERT(varchar(50),convert(decimal(19,2), Round((_12PagatoCompetenza / _12Previniziale) ,2)))
		End as 'Dic.% Comp. 01.01',
		Case when ( _12PrevFineMese = 0 )Then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_12PagatoCompetenza / _12PrevFineMese)  ,2)))
		End as 'Dic.% Comp. Mese',
		Case when PrevConsuntivo3112 = 0 then NULL
			Else CONVERT(varchar(50),convert(decimal(19,2), Round((_12PagatoCompetenza / PrevConsuntivo3112)  ,2)))
		End as 'Dic.% Comp. 31.12',
		Case when ResiduiFineAnno3112 = 0 then null
			else CONVERT(varchar(50),convert(decimal(19,2), Round((_12PagatoResiduo / ResiduiFineAnno3112) ,2)))
		End  as'Dic.% Res.',
	-- Se la sp è chiamata internamente da exp_previsionediliquidità deve restituitre anche l'idfin. Lo metto come ultima colonna e senza intesatzione così
	-- l'utente non nota l'aggiunta della colonna vuota
		F.idfin,
   		CASE
			when (( F.flag & 1)=0) then 'E'
			when (( F.flag & 1)<>0) then 'S'
		End,
		@ayear as 'ayear'
	FROM #OUT O
	JOIN fin F
		ON F.idfin = O.idfin 
--	WHERE F.idfin in (1336, 1629)
	ORDER BY F.printingorder ASC

END


END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/*
GO

exec exp_statistichemensiliflussidicassa 2010 , 'E', 'N', 'S','S'

GO

exec exp_statistichemensiliflussidicassa 2011 , 'E', 'N', 'S','S'
*/
