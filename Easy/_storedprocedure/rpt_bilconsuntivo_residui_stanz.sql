
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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilconsuntivo_residui_stanz]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilconsuntivo_residui_stanz]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE        PROCEDURE [rpt_bilconsuntivo_residui_stanz]
(
	@ayear int,
	@date datetime,
	@levelusable tinyint,
	@idupb varchar(36),
	@showupb char(1),
	@showchildupb char(1),
	@suppressifblank char(1),
	@officialvar  char(1)
)
AS BEGIN   
-- exec rpt_bilconsuntivo_residui_stanz 2009,{ts '2009-12-31 00:00:00'},3,'%','N','S','S','S'
-- setuser 'amm'
CREATE TABLE #balance
(	ayear int,
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

	previsionkind char(1),
	showincomesurplus char(1),
	tosuppress char(1),
	nlevel tinyint,
	
	mov_finphase_C decimal(19,2),
	var_finphase_acc_C decimal(19,2),
	var_finphase_red_C decimal(19,2),
	mov_maxphase_C decimal(19,2),
	var_maxphase_C decimal(19,2),
	stanz3112  decimal(19,2),

	Stanziamenti decimal(19,2),
	var_Stanziamenti_acc decimal(19,2),
	var_Stanziamenti_red decimal(19,2),
	Impegni_Propri decimal(19,2),
	var_Impegni_Propri_acc decimal(19,2),
	var_Impegni_Propri_red decimal(19,2),
	Imp_Propri_da_stanziamenti decimal(19,2),
	Pag_Residui_Propri decimal(19,2),
	Pag_da_Stanziamenti decimal(19,2),
	--StanziamentiDaComp decimal(19,2),
	--ImpegniDaComp decimal(19,2)
)

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
set @finpart_bit = 1

DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S' and @idupb<>'%')
BEGIN
	SET @idupb=@idupb+'%' 
END

DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'

DECLARE @infoadvance char(1)
SELECT @infoadvance = paramvalue
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'

DECLARE @cashvaliditykind tinyint
SELECT @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
DECLARE @finallocation tinyint -- fase dello stanziamento
DECLARE @finphase tinyint
DECLARE @maxphase tinyint
DECLARE @finphase2 tinyint
declare @fin_kind tinyint
select @fin_kind = fin_kind
FROM config 
WHERE ayear = @ayear

-- L'ipotesi fondamentale di questo report è che la fase del residuo di stanziamento è la 1
-- Quella del residuo giuridico è la 3
-- Quella dello stanziamento è 1
SELECT @finallocation = 1
SELECT @finphase2 = 2
SELECT @finphase = 3  ---<<== IPOTESI DEL REPORT
SELECT @maxphase = MAX(nphase) FROM expensephase

DECLARE @minlevelusable tinyint
SELECT  @minlevelusable = min(nlevel) FROM finlevel WHERE ayear = @ayear and (flag&2) <> 0

DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable

IF(@levelusable < @minlevelusable)
begin
	SET @levelusable = @minlevelusable
end

CREATE TABLE #finyear
(
	idfin 			int, 
	idupb 			varchar(36),
	prevision		decimal(19,2)	,
	secondaryprev		decimal(19,2)	,
	currentarrears		decimal(19,2)
)

DECLARE @length1 int
DECLARE @pos1 int
DECLARE @length2 int
DECLARE @pos2 int
DECLARE @length3 int
DECLARE @pos3 int
DECLARE @length4 int
DECLARE @pos4 int
DECLARE @length5 int
DECLARE @pos5 int
SELECT @length1 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 1
SELECT @length2 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 2
SELECT @length3 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 3 
SELECT @length4 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 4
SELECT @length5 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 5
SELECT @pos1 = 1
SELECT @pos2 = @pos1 + @length1
SELECT @pos3 = @pos2 + @length2
SELECT @pos4 = @pos3 + @length3
SELECT @pos5 = @pos4 + @length4

-- calcolo del totale delle variazioni della
-- previsione principale
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

CREATE TABLE #mov_Fase1_R (ayear1 int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #mov_Fase1_acc_R (ayear1 int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #mov_Fase1_red_R (ayear1 int, idfin int, idupb varchar(36), total decimal(19,2))

CREATE TABLE #mov_Fase2_R (ayear1 int,ayear2 int, idfin int, idupb varchar(36), total decimal(19,2))

CREATE TABLE #mov_finphase_R	 (ayear1 int, ayear3 int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_finphase_acc_R (ayear1 int, ayear3 int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_finphase_red_R (ayear1 int, ayear3 int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #mov_maxphase_R 	 (ayear1 int, ayear3 int, ayear5 int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_maxphase_R 	 (ayear1 int, ayear3 int, ayear5 int, idfin int, idupb varchar(36), total decimal(19,2))

-- ayear1 contiene l'anno di creazione della fase 1
-- ayear3 contiene l'anno di creazione della fase 3

CREATE TABLE #mov_finphase_C (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_finphase_acc_C (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_finphase_red_C (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #mov_maxphase_C (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_maxphase_C (idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #stanz3112 (idfin int, idupb varchar(36), total decimal(19,2))

-- Creo anche la tabella per contenere la Fase 2 ai fini del calcolo dei Residui di Stanziamento. 
-- Stanziamenti = Residui di Stanziamento (Colonna 1):
-- disp F1 + F2 tutto ove F1>=2008, F1 < @ayear, F2< @ayear
INSERT INTO #mov_Fase1_R
(
	ayear1,
	idfin,
	idupb,
	total
)
	SELECT 
		E.ymov, 		-- anno del residuo di stanziamento (fase 1)
		ISNULL(FLK.idparent,EY.idfin),
		EY.idupb ,
		ISNULL(SUM(EY.amount),0) -- importo dello stanziamento  (fase 1)
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
		AND E.nphase = @finallocation
		AND E.adate <= @date
		AND EY.idupb like @idupb
GROUP BY E.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)

INSERT INTO #mov_Fase2_R
(
	ayear1,
	ayear2,
	idfin,
	idupb,
	total
)
	SELECT 
		E1.ymov, 	-- anno del residuo di stanziamento (fase 1)
		E2.ymov,		-- anno del mov. residuo di Fase2 
		ISNULL(FLK.idparent,EY.idfin),
		EY.idupb ,
		ISNULL(SUM(EY.amount),0) -- importo della Fase 2
	FROM expenseyear EY
	JOIN expense E2
		ON E2.idexp = EY.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	JOIN expenselink EL
		ON EL.idchild = E2.idexp
	JOIN expense E1
		ON E1.idexp = EL.idparent
	JOIN expenseyear EY1
		ON E1.idexp = EY1.idexp
	JOIN expensetotal ET1
		ON ET1.idexp = EY1.idexp AND ET1.ayear = EY1.ayear
	WHERE EY.ayear = @ayear
		AND EY1.ayear = @ayear
		AND ( (ET1.flag & 1) = 1) -- Residuo
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E2.nphase = @finphase2
		AND EL.nlevel = @finallocation
		AND E2.adate <= @date
		AND EY.idupb like @idupb
GROUP BY E1.ymov,E2.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)

INSERT INTO #mov_finphase_C
(
	idfin,
	idupb,
	total
)
SELECT
	isnull(FLK.idparent,EY.idfin),
	EY.idupb,
	ISNULL(SUM(EY.amount),0)
FROM expense E
JOIN expenseyear EY
	ON EY.idexp = E.idexp	
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
left outer JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE E.adate <= @date
	AND EY.ayear = @ayear
	AND ( (ET.flag & 1) = 0)-- Competenza
	AND E.nphase = @finphase
	AND EY.idupb like @idupb
GROUP BY EY.idupb,isnull(FLK.idparent,EY.idfin)

INSERT INTO #stanz3112
(
	idfin,
	idupb,
	total
)
SELECT
	isnull(FLK.idparent,EY.idfin),
	EY.idupb,
	ISNULL(SUM(ET.curramount),0)
FROM expense E
JOIN expenseyear EY
	ON EY.idexp = E.idexp	
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
left outer JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE E.adate <= @date
	AND EY.ayear = @ayear
	AND ( (ET.flag & 1) = 0)-- Competenza
	AND E.nphase = @finallocation -- IPOTESI
	AND EY.idupb like @idupb
GROUP BY EY.idupb,isnull(FLK.idparent,EY.idfin)


INSERT INTO #var_finphase_acc_C
(
	idfin,
	idupb,
	total
)
SELECT 
	ISNULL(FLK.idparent,EY.idfin),
	EY.idupb,
	ISNULL(SUM(EV.amount),0)
FROM expensevar EV
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
JOIN expense E
	ON EV.idexp = E.idexp	
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable 
WHERE EV.yvar = @ayear
	AND EY.ayear = @ayear
	AND ( (ET.flag & 1) = 0) -- Competenza
	AND E.nphase = @finphase
	AND EV.adate <= @date 
	AND EV.amount > 0
	AND EY.idupb like @idupb
GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

INSERT INTO #var_finphase_red_C
(
	idfin,
	idupb,
	total
)
SELECT 
	ISNULL(FLK.idparent,EY.idfin),
	EY.idupb,
	ISNULL(SUM(EV.amount),0)
FROM expensevar EV
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
JOIN expense E
	ON EV.idexp = E.idexp	
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE EV.yvar = @ayear
	AND EY.ayear = @ayear
	AND E.nphase = @finphase
	AND ( (ET.flag & 1) = 0) --Competenza
	AND EV.adate <= @date 
	AND EV.amount < 0
	AND EY.idupb like @idupb
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
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE HPV.competencydate <= @date
	AND EY.ayear = @ayear
	AND ( (HPV.totflag & 1) = 0)--Competenza
	AND HPV.ymov = @ayear
	AND EY.idupb like @idupb
GROUP BY EY.idupb, ISNULL(FLK.idparent,EY.idfin)


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
	JOIN historypaymentview HPV
		ON HPV.idexp = EV.idexp
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EV.adate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
		AND EY.idupb like @idupb
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin) 	
END

IF (@showupb <>'S') 
BEGIN 
	INSERT INTO #balance
	(	ayear,
		idfin,
		code1, order1,
		code2, order2,
		code3, order3,
		code4, order4,
		code5, order5,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		nlevel
	)
	SELECT distinct
		#mov_Fase1_R.ayear1,
		f5.idfin, 
		f1.codefin, f1.printingorder,
		f2.codefin, f2.printingorder,
		f3.codefin, f3.printingorder,
		f4.codefin, f4.printingorder,
		f5.codefin, f5.printingorder,
		null,
		null,
		null,
		null,
		f5.nlevel
	FROM fin f5
	JOIN finlevel fl
		ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
	LEFT OUTER JOIN fin f4
		ON f4.idfin = f5.paridfin
	LEFT OUTER JOIN fin f3
		ON f3.idfin = f4.paridfin
	LEFT OUTER JOIN fin f2
		ON f2.idfin = f3.paridfin
	LEFT OUTER JOIN fin f1
		ON f1.idfin = f2.paridfin
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = f5.idfin AND FLK.nlevel = @levelusable
	JOIN #mov_Fase1_R -- LEFT OUTER tolto perchè voglio solo le righe di cui esiste un residuo di stanziamento
		ON ISNULL(FLK.idparent,f5.idfin) = #mov_Fase1_R.idfin
	WHERE f5.ayear = @ayear	
		AND ((f5.flag & 1)= @finpart_bit)
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
			AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
			AND (fl.flag&2)<>0	)
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0))

	INSERT INTO #balance
	(	ayear,
		idfin,
		code1, order1,
		code2, order2,
		code3, order3,
		code4, order4,
		code5, order5,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		nlevel
	)
	SELECT 
		@ayear,
		f5.idfin, 
		f1.codefin, f1.printingorder,
		f2.codefin, f2.printingorder,
		f3.codefin, f3.printingorder,
		f4.codefin, f4.printingorder,
		f5.codefin, f5.printingorder,
		null,
		null,
		null,
		null,
		f5.nlevel
	FROM fin f5
	JOIN finlevel fl
		ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
	LEFT OUTER JOIN fin f4
		ON f4.idfin = f5.paridfin
	LEFT OUTER JOIN fin f3
		ON f3.idfin = f4.paridfin
	LEFT OUTER JOIN fin f2
		ON f2.idfin = f3.paridfin
	LEFT OUTER JOIN fin f1
		ON f1.idfin = f2.paridfin
	WHERE f5.ayear = @ayear	
		AND ((f5.flag & 1)= @finpart_bit)
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
			AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
			AND (fl.flag&2)<>0	)
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0))
END
ELSE
BEGIN
	INSERT INTO #balance
	(	ayear,
		idfin,
		code1, order1,
		code2, order2,
		code3, order3,
		code4, order4,
		code5, order5,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		nlevel
	)
	SELECT 
		#mov_Fase1_R.ayear1,
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
		f5.nlevel
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
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = f5.idfin AND FLK.nlevel = @levelusable
	JOIN #mov_Fase1_R -- LEFT OUTER tolto perchè voglio solo le righe di cui esiste un residuo di stanziamento
		ON ISNULL(FLK.idparent,f5.idfin) = #mov_Fase1_R.idfin
		AND upb.idupb = #mov_Fase1_R.idupb
	WHERE f5.ayear = @ayear
		AND (upb.idupb LIKE @idupb)	
		AND ((f5.flag & 1)= @finpart_bit)
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
			AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
			AND (fl.flag&2)<>0	)
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0))
	
	INSERT INTO #balance
	(	ayear,
		idfin,
		code1, order1,
		code2, order2,
		code3, order3,
		code4, order4,
		code5, order5,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		nlevel
	)
	SELECT 
		@ayear,
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
		f5.nlevel
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
		AND (upb.idupb LIKE @idupb)	
		AND ((f5.flag & 1)= @finpart_bit)
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
			AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
			AND (fl.flag&2)<>0	)
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0))
END

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
UPDATE #balance SET order1 = order2, order2 = order3, order3 = order4, order4 = order5, order5 = NULL WHERE order1 IS NULL

UPDATE #balance SET order1 = SUBSTRING(order1, @startpos1, @lencod_lev1)
UPDATE #balance SET order2 = SUBSTRING(order2, @startpos2, @lencod_lev2)
UPDATE #balance SET order3 = SUBSTRING(order3, @startpos3, @lencod_lev3)
UPDATE #balance SET order4 = SUBSTRING(order4, @startpos4, @lencod_lev4)
UPDATE #balance SET order5 = SUBSTRING(order5, @startpos5, @lencod_lev5)


INSERT INTO #mov_Fase1_acc_R
(	ayear1,
	idfin,
	idupb,
	total
)
SELECT  E.ymov,
	ISNULL(FLK.idparent,EY.idfin),
	EY.idupb,
	ISNULL(SUM(EV.amount),0)
FROM expensevar EV
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
JOIN expense E
	ON EV.idexp = E.idexp	
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE EV.yvar = @ayear
	AND EY.ayear = @ayear
	AND ((ET.flag & 1) = 1) -- Residuo
	AND E.nphase = @finallocation
	AND EV.adate <= @date 
	AND EV.amount > 0
	AND EY.idupb like @idupb
GROUP BY E.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)

INSERT INTO #mov_Fase1_red_R
(	ayear1,
	idfin,
	idupb,
	total
)
SELECT  E.ymov,
	ISNULL(FLK.idparent,EY.idfin),
	EY.idupb,
	ISNULL(SUM(EV.amount),0)
FROM expensevar EV
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
JOIN expense E
	ON EV.idexp = E.idexp	
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE EV.yvar = @ayear
	AND EY.ayear = @ayear
	AND ((ET.flag & 1) = 1) -- Residuo
	AND E.nphase = @finallocation
	AND EV.adate <= @date 
	AND EV.amount < 0
	AND EY.idupb like @idupb
GROUP BY E.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)

INSERT INTO #mov_finphase_R
(
	ayear1,
	ayear3,
	idfin,
	idupb,
	total
)
	SELECT 
		E1.ymov, 		-- anno del residuo di stanziamento (fase 1)
		E3.ymov,		-- anno del residuo proprio
		ISNULL(FLK.idparent,EY.idfin),
		EY.idupb ,
		ISNULL(SUM(EY.amount),0) -- importo dell'impegno  (fase 3)
	FROM expenseyear EY
	JOIN expense E3
		ON E3.idexp = EY.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	JOIN expenselink EL
		ON EL.idchild = E3.idexp
	JOIN expense E1
		ON E1.idexp = EL.idparent
	JOIN expenseyear EY1
		ON E1.idexp = EY1.idexp
	JOIN expensetotal ET1
		ON ET1.idexp = EY1.idexp AND ET1.ayear = EY1.ayear
	WHERE EY.ayear = @ayear
		AND EY1.ayear = @ayear
		AND ( (ET1.flag & 1) = 1) -- Residuo
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E3.nphase = @finphase
		AND EL.nlevel = @finallocation
		AND E3.adate <= @date
		AND EY.idupb like @idupb
GROUP BY E1.ymov,E3.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)

INSERT INTO #var_finphase_acc_R
(
	ayear1,
	ayear3,
	idfin,
	idupb,
	total
)
SELECT  E1.ymov,
	E.ymov,
	ISNULL(FLK.idparent,EY.idfin),
	EY.idupb,
	ISNULL(SUM(EV.amount),0)
FROM expensevar EV
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
JOIN expense E
	ON EV.idexp = E.idexp	
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
JOIN expenselink EL
	ON EL.idchild = E.idexp
JOIN expense E1
	ON E1.idexp = EL.idparent
JOIN expenseyear EY1
	ON E1.idexp = EY1.idexp
JOIN expensetotal ET1
	ON ET1.idexp = EY1.idexp
	AND ET1.ayear = EY1.ayear
WHERE EV.yvar = @ayear
	AND EY.ayear = @ayear
	AND EY1.ayear = @ayear
	AND ( (ET1.flag & 1) = 1) -- Residuo
	AND ( (ET.flag & 1) = 1) -- Residuo
	AND E.nphase = @finphase
	AND EL.nlevel = @finallocation
	AND EV.adate <= @date 
	AND EV.amount > 0
	AND EY.idupb like @idupb
GROUP BY E1.ymov,E.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)

INSERT INTO #var_finphase_red_R
(	ayear1,
	ayear3,
	idfin,
	idupb,
	total
)
SELECT  
	E1.ymov,
	E.ymov,
	ISNULL(FLK.idparent,EY.idfin),
	EY.idupb,
	ISNULL(SUM(EV.amount),0) 
FROM expensevar EV
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
JOIN expense E
	ON EV.idexp = E.idexp	
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
JOIN expenselink EL
	ON EL.idchild = E.idexp
JOIN expense E1
	ON E1.idexp = EL.idparent
JOIN expenseyear EY1
	ON E1.idexp = EY1.idexp
JOIN expensetotal ET1
	ON ET1.idexp = EY1.idexp
	AND ET1.ayear = EY1.ayear
WHERE EV.yvar = @ayear
	AND EY.ayear = @ayear
	AND EY1.ayear = @ayear
	AND ( (ET1.flag & 1) = 1) -- Residuo
	AND ( (ET.flag & 1) = 1) -- Residuo
	AND E.nphase = @finphase
	AND EL.nlevel = @finallocation
	AND EV.adate <= @date 
	AND EV.amount < 0
	AND EY.idupb like @idupb 
GROUP BY E1.ymov,E.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)


INSERT INTO #mov_maxphase_R
(
	ayear1,
	ayear3,
	idfin,
	idupb,
	total
)
SELECT
	E1.ymov, E3.ymov,
	ISNULL(FLK.idparent,EY.idfin),
	EY.idupb,
	SUM(HPV.amount)
FROM historypaymentview HPV
JOIN expenseyear EY
	ON EY.idexp = HPV.idexp
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
JOIN expenselink EL1
	ON EL1.idchild = HPV.idexp
JOIN expense E1
	ON E1.idexp = EL1.idparent
JOIN expenseyear EY1
	ON E1.idexp = EY1.idexp
	AND EY1.ayear = EY.ayear
JOIN expensetotal ET1
	ON ET1.idexp = EY1.idexp
	AND ET1.ayear = EY1.ayear
JOIN expenselink EL3
	ON EL3.idchild = HPV.idexp
JOIN expense E3
	ON E3.idexp = EL3.idparent
JOIN expenseyear EY3
	ON E3.idexp = EY3.idexp
	AND EY3.ayear = EY.ayear
WHERE HPV.competencydate <= @date
	AND EY.ayear = @ayear
	AND EL1.nlevel = @finallocation
	AND EL3.nlevel = @finphase
	AND ( (ET1.flag & 1) = 1) -- Residuo
	AND ( (HPV.totflag & 1) = 1)--  Residuo
	AND HPV.ymov = @ayear
	AND EY.idupb like @idupb
GROUP BY E1.ymov, E3.ymov, HPV.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)
	
IF @cashvaliditykind <> 4
	BEGIN
		INSERT INTO #var_maxphase_R
		(
			ayear1,
			ayear3,
			idfin,
			idupb,
			total
		)
		SELECT
			E1.ymov, 
			E3.ymov,
			ISNULL(FLK.idparent,EY.idfin),
			EY.idupb,
		SUM(EV.amount)
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
		JOIN expenselink EL1
			ON EL1.idchild = HPV.idexp
		JOIN expense E1
			ON E1.idexp = EL1.idparent
		JOIN expenseyear EY1
			ON E1.idexp = EY1.idexp
			AND EY1.ayear = EY.ayear
		JOIN expensetotal ET1
			ON ET1.idexp = EY1.idexp
			AND ET1.ayear = EY1.ayear
		JOIN expenselink EL3
			ON EL3.idchild = HPV.idexp
		JOIN expense E3
			ON E3.idexp = EL3.idparent
		JOIN expenseyear EY3
			ON E3.idexp = EY3.idexp
			AND EY3.ayear = EY.ayear
		WHERE HPV.competencydate <= @date
			AND EY.ayear = @ayear
			AND EV.yvar = @ayear
			AND EV.adate <= @date
			AND EL1.nlevel = @finallocation
			AND EL3.nlevel = @finphase
			AND ( (ET1.flag & 1) = 1) -- Residuo
			AND ( (HPV.totflag & 1) = 1)--  Residuo
			AND HPV.ymov = @ayear
			AND EY.idupb like @idupb
		GROUP BY E1.ymov, E3.ymov, HPV.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)
END

-- TUTTO QUESTO NON DOVREBBE PIU' SERVIRE
/*
DECLARE @annoipotesi int
--IF @ayear > 2008  
SET @annoipotesi = 2008 
--ELSE SET @annoipotesi = 2007 

UPDATE #mov_Fase1_R SET ayear1 = @annoipotesi WHERE ayear1 < @annoipotesi
UPDATE #mov_Fase1_red_R_post2008 SET ayear1 = @annoipotesi WHERE ayear1 < @annoipotesi
UPDATE #mov_Fase1_acc_R_post2008 SET ayear1 = @annoipotesi WHERE ayear1 < @annoipotesi

UPDATE #mov_Fase2_R SET ayear1 = @annoipotesi WHERE ayear1 < @annoipotesi
UPDATE #mov_Fase2_R SET ayear2 = @annoipotesi WHERE ayear2 < @annoipotesi

UPDATE #mov_finphase_R SET ayear1 = @annoipotesi WHERE ayear1 < @annoipotesi
UPDATE #mov_finphase_R SET ayear3 = @annoipotesi WHERE ayear3 < @annoipotesi

UPDATE #var_finphase_acc_R SET ayear1 = @annoipotesi WHERE ayear1 < @annoipotesi
UPDATE #var_finphase_acc_R SET ayear3 = @annoipotesi WHERE ayear3 < @annoipotesi
UPDATE #var_finphase_red_R SET ayear1 = @annoipotesi WHERE ayear1 < @annoipotesi
UPDATE #var_finphase_red_R SET ayear3 = @annoipotesi WHERE ayear3 < @annoipotesi
UPDATE #mov_maxphase_R SET ayear1 = @annoipotesi WHERE ayear1 < @annoipotesi
UPDATE #mov_maxphase_R SET ayear3 = @annoipotesi WHERE ayear3 < @annoipotesi
*/

IF (@showupb <>'S') 
BEGIN
-------------------------------------------- @showupb = N -------------------------------------
-- Sara : mi sto calcolando la colonna 1, i RESIDUI DI STANZIAMENTO :
-- F1 				ove F1>=2008, F1 <@ayear
--	-
-- Tutto F3 (rimuove gli Imp.Res.)		ove F3<@ayear 
--select stanziamenti F1, * from #balance where idfin = 2556
		UPDATE #balance
		SET Stanziamenti =
		ISNULL(
			(SELECT SUM(#mov_Fase1_R.total) FROM #mov_Fase1_R
			WHERE #mov_Fase1_R.idfin = #balance.idfin
			AND #mov_Fase1_R.ayear1 = #balance.ayear
			AND #mov_Fase1_R.ayear1 >= 2008
			AND #mov_Fase1_R.ayear1 < @ayear
			GROUP BY #mov_Fase1_R.idfin,#mov_Fase1_R.ayear1 )
		, 0)

--select *  FROM #mov_Fase1_R where idfin = 2556
--select stanziamenti F1, * from #balance where idfin = 2556

-- Sara: devo depurare questo valore dagli Ix residui precedenti al @ayear
-- Dagli Stanziamenti sta togliendo gli Ix nati prima del @ayear, quindi quegli propri.
		UPDATE #balance
		SET Stanziamenti = Stanziamenti
		-- per esigenze di disegno dei report gli impegni PROPRI si devono trovare sulla riga con ayear1 = @year  <<-- IPOTESI
		-- e devo togliere l'importo degli impegni dagli stanziamenti
		-ISNULL(
			(SELECT SUM(#mov_finphase_R.total) FROM #mov_finphase_R
				WHERE #mov_finphase_R.idfin = #balance.idfin
				AND #mov_finphase_R.ayear1 = #balance.ayear								
				AND #mov_finphase_R.ayear3 < @ayear
			GROUP BY #mov_finphase_R.idfin,#mov_finphase_R.ayear1 )
		, 0)
--------------------------------------------------------------------------------------------------------------------
-- Variazioni F1:
-- Sono solo quelle per cui EsercMovF1>=2008 and ymov<@year
-- e yvar = @ayear 
-- Le var.  F1 devono essere calcolate al netto delle var. sugli impengni residui propri, cambiate di segno. Quindi 
-- col 7 = Var. dei Residui di Stanziamento in aumento - var. in diminuzione degli Impengni Residui propri
-- col 8 = Var. dei Residui di Stanziamento in dimunzione + var. in aumento degli Impengni Residui propri 
-- new
		UPDATE #balance
		SET var_Stanziamenti_acc =
		ISNULL(
			(SELECT SUM(#mov_Fase1_acc_R.total) FROM #mov_Fase1_acc_R
			WHERE #mov_Fase1_acc_R.idfin = #balance.idfin
				AND #mov_Fase1_acc_R.ayear1 = #balance.ayear
				AND #mov_Fase1_acc_R.ayear1 >= 2008
				AND #mov_Fase1_acc_R.ayear1 < @ayear
			GROUP BY #mov_Fase1_acc_R.idfin,#mov_Fase1_acc_R.ayear1 )
		, 0)
		- -->>> var_Impegni_Propri_red 
		ISNULL(
			(SELECT SUM(#var_finphase_red_R.total) FROM #var_finphase_red_R
				WHERE #var_finphase_red_R.idfin = #balance.idfin
				AND #var_finphase_red_R.ayear1 = #balance.ayear --AND #balance.ayear = @ayear								-- riga con anno = @year
				AND #var_finphase_red_R.ayear3 <= @ayear
				AND #var_finphase_red_R.ayear1 < @ayear 
				AND #var_finphase_red_R.ayear1 >= 2008
			GROUP BY #var_finphase_red_R.idfin)
		, 0)

		UPDATE #balance
		SET var_Stanziamenti_red =
		ISNULL(
			(SELECT SUM(#mov_Fase1_red_R.total) FROM #mov_Fase1_red_R
			WHERE #mov_Fase1_red_R.idfin = #balance.idfin
				AND #mov_Fase1_red_R.ayear1 = #balance.ayear
				AND #mov_Fase1_red_R.ayear1>= 2008
				AND #mov_Fase1_red_R.ayear1 < @ayear
			GROUP BY #mov_Fase1_red_R.idfin,#mov_Fase1_red_R.ayear1 )
		, 0)
		+ -->> var_Impegni_Propri_acc =
		ISNULL(
			(SELECT SUM(#var_finphase_acc_R.total) FROM #var_finphase_acc_R
				WHERE #var_finphase_acc_R.idfin = #balance.idfin
				AND #var_finphase_acc_R.ayear1 = #balance.ayear --AND #balance.ayear = @ayear								-- riga con anno = @year
				AND #var_finphase_acc_R.ayear3 <= @ayear
				AND #var_finphase_acc_R.ayear1 < @ayear 
				AND #var_finphase_acc_R.ayear1 >= 2008
			GROUP BY #var_finphase_acc_R.idfin)
		, 0)

---------------- IMPEGNI PROPRI --------------------------------------------------------------------------
-- Gli impegni propri  li voglio vedere sulla riga con anno = @year

-- Sara, Sono i Res. Propri al 01/01. Calcolati come:
-- F1, ove F1<=2007 (<2008), F1<@ayear
--	+
-- F3, ove F1 <@ayear, F3 < @ayear, F1 >= 2008
 		UPDATE #balance
		SET Impegni_Propri =
		ISNULL(
			(SELECT SUM(#mov_Fase1_R.total) FROM #mov_Fase1_R
			WHERE #mov_Fase1_R.idfin = #balance.idfin
			AND #balance.ayear = @ayear								-- vanno sulla riga con anno = @year
			AND #mov_Fase1_R.ayear1 < 2008
			AND #mov_Fase1_R.ayear1 < @ayear
			GROUP BY #mov_Fase1_R.idfin)
		, 0)
		-- Ora, aggiungo tutta la Fase 3
		UPDATE #balance
		SET Impegni_Propri =
		Impegni_Propri 
		+	
		ISNULL(
			(SELECT SUM(#mov_finphase_R.total) FROM #mov_finphase_R
				WHERE #mov_finphase_R.idfin = #balance.idfin
				AND #balance.ayear = @ayear								-- vanno sulla riga con anno = @year
				AND #mov_finphase_R.ayear1 >= 2008
				AND #mov_finphase_R.ayear1 < @ayear
				AND #mov_finphase_R.ayear3 < @ayear
			GROUP BY #mov_finphase_R.idfin )
		, 0)

-- Sara: Ix propri da Sx, o anche detti Residui divenuti propri (Colonna 3). Calcolati come:
-- tutta F3, ove F3 = @ayear e F1 >= 2008 e F1< @ayear
		UPDATE #balance
		SET Imp_Propri_da_stanziamenti = 
-- Gli impegni propri  creati da stanziamenti vecchi
-- per esigenze di disegno dei report questi impegni si devono trovare sulla corrispondente riga di ayear1 
		ISNULL(
			(SELECT SUM(#mov_finphase_R.total) FROM #mov_finphase_R
				WHERE #mov_finphase_R.idfin = #balance.idfin
				AND #balance.ayear = #mov_finphase_R.ayear1		
				AND #mov_finphase_R.ayear3 = @ayear
				AND #mov_finphase_R.ayear1 >= 2008
				AND #mov_finphase_R.ayear1 < @ayear
			GROUP BY #mov_finphase_R.idfin,#mov_finphase_R.ayear1 )
		, 0)

-- Variazioni F3:
-- Var. RP:
-- var. F3, F1 <@ayear, F1>= 2008, F3 <=@ayear
-- +
-- var. F1, F1<2008, F1 <@ayear

		UPDATE #balance
		SET var_Impegni_Propri_acc =
		ISNULL(
			(SELECT SUM(#var_finphase_acc_R.total) FROM #var_finphase_acc_R
				WHERE #var_finphase_acc_R.idfin = #balance.idfin
				AND #balance.ayear = @ayear								-- riga con anno = @year
				AND #var_finphase_acc_R.ayear3 <= @ayear
				AND #var_finphase_acc_R.ayear1 < @ayear 
				AND #var_finphase_acc_R.ayear1 >= 2008
			GROUP BY #var_finphase_acc_R.idfin)
		, 0)
		+
		ISNULL(
				(SELECT SUM(#mov_Fase1_acc_R.total) FROM #mov_Fase1_acc_R
				WHERE #mov_Fase1_acc_R.idfin = #balance.idfin
					AND #balance.ayear = @ayear
					AND #mov_Fase1_acc_R.ayear1 < 2008
					AND #mov_Fase1_acc_R.ayear1 < @ayear
				GROUP BY #mov_Fase1_acc_R.idfin)
				, 0)

		UPDATE #balance
		SET var_Impegni_Propri_red =
		ISNULL(
			(SELECT SUM(#var_finphase_red_R.total) FROM #var_finphase_red_R
				WHERE #var_finphase_red_R.idfin = #balance.idfin
				AND #balance.ayear = @ayear							-- riga con anno = @year
				AND #var_finphase_red_R.ayear3 < @ayear
				AND #var_finphase_red_R.ayear1 < @ayear 
				AND #var_finphase_red_R.ayear1 >= 2008
			GROUP BY #var_finphase_red_R.idfin)
		, 0)
		+
		ISNULL(
			(SELECT SUM(#var_finphase_red_R.total) FROM #var_finphase_red_R
				WHERE #var_finphase_red_R.idfin = #balance.idfin
				AND #balance.ayear = #var_finphase_red_R.ayear1								-- riga con anno = @year
				AND #var_finphase_red_R.ayear3 = @ayear
				AND #var_finphase_red_R.ayear1 < @ayear 
				AND #var_finphase_red_R.ayear1 >= 2008
			GROUP BY #var_finphase_red_R.idfin)
		, 0)
		+
		ISNULL(
			(SELECT SUM(#mov_Fase1_red_R.total) FROM #mov_Fase1_red_R
			WHERE #mov_Fase1_red_R.idfin = #balance.idfin
				AND #balance.ayear = @ayear
				AND #mov_Fase1_red_R.ayear1 <2008
				AND #mov_Fase1_red_R.ayear1 <@ayear
			GROUP BY #mov_Fase1_red_R.idfin)
		, 0)

		UPDATE #balance
		SET Pag_Residui_Propri =
		ISNULL(
			(SELECT SUM(#mov_maxphase_R.total) FROM #mov_maxphase_R
			WHERE #mov_maxphase_R.idfin = #balance.idfin
				AND #balance.ayear = @ayear								-- riga con anno = @year
				AND #mov_maxphase_R.ayear1 < 2008
				AND #mov_maxphase_R.ayear1 < @ayear
			GROUP BY #mov_maxphase_R.idfin)
		, 0) 
		+
		ISNULL(
			(SELECT SUM(#mov_maxphase_R.total) FROM #mov_maxphase_R
			WHERE #mov_maxphase_R.idfin = #balance.idfin
				AND #balance.ayear = @ayear								-- riga con anno = @year
				AND #mov_maxphase_R.ayear1>= 2008
				AND #mov_maxphase_R.ayear3 < @ayear
			GROUP BY #mov_maxphase_R.idfin)
		, 0) 
-- al netto delle variazioni
		UPDATE #balance
		SET Pag_Residui_Propri =
		Pag_Residui_Propri
		+
		ISNULL(
			(SELECT SUM(#var_maxphase_R.total) FROM #var_maxphase_R
			WHERE #var_maxphase_R.idfin = #balance.idfin
				AND #balance.ayear = @ayear						
				AND #var_maxphase_R.ayear1 < 2008
				AND #var_maxphase_R.ayear1 < @ayear
			GROUP BY #var_maxphase_R.idfin)
		, 0) 
		+
		ISNULL(
			(SELECT SUM(#var_maxphase_R.total) FROM #var_maxphase_R
			WHERE #var_maxphase_R.idfin = #balance.idfin
				AND #balance.ayear = @ayear							
				AND #var_maxphase_R.ayear1>= 2008
				AND #var_maxphase_R.ayear3 < @ayear
			GROUP BY #var_maxphase_R.idfin)
		, 0) 

		UPDATE #balance
		SET Pag_da_Stanziamenti = 
		ISNULL(
			(SELECT SUM(#mov_maxphase_R.total) FROM #mov_maxphase_R
			WHERE #mov_maxphase_R.idfin = #balance.idfin
				AND #balance.ayear = #mov_maxphase_R.ayear1								-- riga con anno = @year
				AND #mov_maxphase_R.ayear1>=2008
				AND #mov_maxphase_R.ayear1 <@ayear
				AND #mov_maxphase_R.ayear3 =@ayear
			GROUP BY #mov_maxphase_R.idfin,#mov_maxphase_R.ayear1)
		, 0)

-- al netto delle variazioni
		UPDATE #balance
		SET Pag_da_Stanziamenti = 
		Pag_da_Stanziamenti
		+
		ISNULL(
			(SELECT SUM(#var_maxphase_R.total) FROM #var_maxphase_R
			WHERE #var_maxphase_R.idfin = #balance.idfin
				AND #balance.ayear = #var_maxphase_R.ayear1								-- riga con anno = @year
				AND #var_maxphase_R.ayear1>=2008
				AND #var_maxphase_R.ayear1 <@ayear
				AND #var_maxphase_R.ayear3 =@ayear
			GROUP BY #var_maxphase_R.idfin,#var_maxphase_R.ayear1)
		, 0)

-------------------------------------------- @showupb = N -------------------------------------
-- Calcola la competenza

	UPDATE #balance
	SET mov_finphase_C =
	ISNULL(
		(SELECT SUM(#mov_finphase_C.total) FROM #mov_finphase_C
		WHERE #mov_finphase_C.idfin = #balance.idfin
		AND #balance.ayear = @ayear						-- riga con anno = @year
		GROUP BY #mov_finphase_C.idfin)
	, 0),
	stanz3112 =
	ISNULL(
		(SELECT SUM(#stanz3112.total) FROM #stanz3112
		WHERE #stanz3112.idfin = #balance.idfin
		AND #balance.ayear = @ayear						-- riga con anno = @year
		GROUP BY #stanz3112.idfin)
	, 0),
	var_finphase_acc_C =
	ISNULL(
		(SELECT SUM(#var_finphase_acc_C.total) FROM #var_finphase_acc_C
		WHERE #var_finphase_acc_C.idfin = #balance.idfin
		AND #balance.ayear = @ayear						-- riga con anno = @year
		GROUP BY #var_finphase_acc_C.idfin )
	, 0),
	var_finphase_red_C =
	ISNULL(
		(SELECT SUM(#var_finphase_red_C.total) FROM #var_finphase_red_C
		WHERE #var_finphase_red_C.idfin = #balance.idfin
		AND #balance.ayear = @ayear						-- riga con anno = @year
		GROUP BY #var_finphase_red_C.idfin )
	, 0),
	mov_maxphase_C =
	ISNULL(
		(SELECT SUM(#mov_maxphase_C.total) FROM #mov_maxphase_C
		WHERE #mov_maxphase_C.idfin = #balance.idfin
		AND #balance.ayear = @ayear						-- riga con anno = @year
		GROUP BY  #mov_maxphase_C.idfin)
	, 0),
	var_maxphase_C =
	ISNULL(
		(SELECT SUM(#var_maxphase_C.total) FROM #var_maxphase_C
		WHERE  #var_maxphase_C.idfin = #balance.idfin
		AND #balance.ayear = @ayear						-- riga con anno = @year
		GROUP BY #var_maxphase_C.idfin)
	, 0)

END


ELSE 
BEGIN
-------------------------------------------- @showupb = N -------------------------------------
-- Sara : mi sto calcolando la colonna 1, i RESIDUI DI STANZIAMENTO :
-- F1 				ove F1>=2008, F1 <@ayear
--	-
-- Tutto F3 (rimuove gli Imp.Res.)		ove F3<@ayear 
--select stanziamenti F1, * from #balance where idfin = 2556
		UPDATE #balance
		SET Stanziamenti =
		ISNULL(
			(SELECT SUM(#mov_Fase1_R.total) FROM #mov_Fase1_R
			WHERE #mov_Fase1_R.idfin = #balance.idfin
			AND #mov_Fase1_R.idupb = #balance.idupb
			AND #mov_Fase1_R.ayear1 = #balance.ayear
			AND #mov_Fase1_R.ayear1 >= 2008
			AND #mov_Fase1_R.ayear1 < @ayear
			GROUP BY #mov_Fase1_R.idfin,#mov_Fase1_R.ayear1 )
		, 0)

--select *  FROM #mov_Fase1_R where idfin = 2556
--select stanziamenti F1, * from #balance where idfin = 2556

-- Sara: devo depurare questo valore dagli Ix residui precedenti al @ayear
-- Dagli Stanziamenti sta togliendo gli Ix nati prima del @ayear, quindi quegli propri.
		UPDATE #balance
		SET Stanziamenti = Stanziamenti
		-- per esigenze di disegno dei report gli impegni PROPRI si devono trovare sulla riga con ayear1 = @year  <<-- IPOTESI
		-- e devo togliere l'importo degli impegni dagli stanziamenti
		-ISNULL(
			(SELECT SUM(#mov_finphase_R.total) FROM #mov_finphase_R
				WHERE #mov_finphase_R.idfin = #balance.idfin
				AND #mov_finphase_R.idupb = #balance.idupb
				AND #mov_finphase_R.ayear1 = #balance.ayear								
				AND #mov_finphase_R.ayear3 < @ayear
			GROUP BY #mov_finphase_R.idfin,#mov_finphase_R.ayear1 )
		, 0)

--------------------------------------------------------------------------------------------------------------------
-- Variazioni F1:
-- Sono solo quelle per cui EsercMovF1>=2008 and ymov<@year
-- e yvar = @ayear 

		UPDATE #balance
		SET var_Stanziamenti_acc =
		ISNULL(
			(SELECT SUM(#mov_Fase1_acc_R.total) FROM #mov_Fase1_acc_R
			WHERE #mov_Fase1_acc_R.idfin = #balance.idfin
				AND #mov_Fase1_acc_R.idupb = #balance.idupb
				AND #mov_Fase1_acc_R.ayear1 = #balance.ayear
				AND #mov_Fase1_acc_R.ayear1 >= 2008
				AND #mov_Fase1_acc_R.ayear1 < @ayear
			GROUP BY #mov_Fase1_acc_R.idfin,#mov_Fase1_acc_R.ayear1 )
		, 0)
		- -->>> var_Impegni_Propri_red 
		ISNULL(
			(SELECT SUM(#var_finphase_red_R.total) FROM #var_finphase_red_R
				WHERE #var_finphase_red_R.idfin = #balance.idfin
				AND #var_finphase_red_R.idupb = #balance.idupb
				AND #var_finphase_red_R.ayear1 = #balance.ayear --AND #balance.ayear = @ayear								-- riga con anno = @year
				AND #var_finphase_red_R.ayear3 <= @ayear
				AND #var_finphase_red_R.ayear1 < @ayear 
				AND #var_finphase_red_R.ayear1 >= 2008
			GROUP BY #var_finphase_red_R.idfin)
		, 0)

		UPDATE #balance
		SET var_Stanziamenti_red =
		ISNULL(
			(SELECT SUM(#mov_Fase1_red_R.total) FROM #mov_Fase1_red_R
			WHERE #mov_Fase1_red_R.idfin = #balance.idfin
				AND #mov_Fase1_red_R.idupb = #balance.idupb
				AND #mov_Fase1_red_R.ayear1 = #balance.ayear
				AND #mov_Fase1_red_R.ayear1>= 2008
				AND #mov_Fase1_red_R.ayear1 < @ayear
			GROUP BY #mov_Fase1_red_R.idfin,#mov_Fase1_red_R.ayear1 )
		, 0)
		+ -->> var_Impegni_Propri_acc =
		ISNULL(
			(SELECT SUM(#var_finphase_acc_R.total) FROM #var_finphase_acc_R
				WHERE #var_finphase_acc_R.idfin = #balance.idfin
				AND #var_finphase_acc_R.idupb = #balance.idupb
				AND #var_finphase_acc_R.ayear1 = #balance.ayear -- riga con anno = ayear1
				AND #var_finphase_acc_R.ayear3 <= @ayear
				AND #var_finphase_acc_R.ayear1 < @ayear 
				AND #var_finphase_acc_R.ayear1 >= 2008
			GROUP BY #var_finphase_acc_R.idfin)
		, 0)
---------------- IMPEGNI PROPRI --------------------------------------------------------------------------
-- Gli impegni propri  li voglio vedere sulla riga con anno = @year

-- Sara, Sono i Res. Propri al 01/01. Calcolati come:
-- F1, ove F1<=2007 (<2008), F1<@ayear
--	+
-- F3, ove F1 <@ayear, F3 < @ayear, F1 >= 2008
 		UPDATE #balance
		SET Impegni_Propri =
		ISNULL(
			(SELECT SUM(#mov_Fase1_R.total) FROM #mov_Fase1_R
			WHERE #mov_Fase1_R.idfin = #balance.idfin
			AND #mov_Fase1_R.idupb = #balance.idupb
			AND #balance.ayear = @ayear								-- vanno sulla riga con anno = @year
			AND #mov_Fase1_R.ayear1 < 2008
			AND #mov_Fase1_R.ayear1 < @ayear
			GROUP BY #mov_Fase1_R.idfin)
		, 0)
		-- Ora, aggiungo tutta la Fase 3
		UPDATE #balance
		SET Impegni_Propri =
		Impegni_Propri 
		+	
		ISNULL(
			(SELECT SUM(#mov_finphase_R.total) FROM #mov_finphase_R
				WHERE #mov_finphase_R.idfin = #balance.idfin
				AND #mov_finphase_R.idupb = #balance.idupb
				AND #balance.ayear = @ayear								-- vanno sulla riga con anno = @year
				AND #mov_finphase_R.ayear1 >= 2008
				AND #mov_finphase_R.ayear1 < @ayear
				AND #mov_finphase_R.ayear3 < @ayear
			GROUP BY #mov_finphase_R.idfin )
		, 0)

-- Sara: Ix propri da Sx, o anche detti Residui divenuti propri (Colonna 3). Calcolati come:
-- tutta F3, ove F3 = @ayear e F1 >= 2008 e F1< @ayear
		UPDATE #balance
		SET Imp_Propri_da_stanziamenti = 
-- Gli impegni propri  creati da stanziamenti vecchi
-- per esigenze di disegno dei report questi impegni si devono trovare sulla corrispondente riga di ayear1 
		ISNULL(
			(SELECT SUM(#mov_finphase_R.total) FROM #mov_finphase_R
				WHERE #mov_finphase_R.idfin = #balance.idfin
				AND #mov_finphase_R.idupb = #balance.idupb
				AND #balance.ayear = #mov_finphase_R.ayear1		
				AND #mov_finphase_R.ayear3 = @ayear
				AND #mov_finphase_R.ayear1 >= 2008
				AND #mov_finphase_R.ayear1 < @ayear
			GROUP BY #mov_finphase_R.idfin,#mov_finphase_R.ayear1 )
		, 0)

-- Variazioni F3:
-- Var. RP:
-- var. F3, F1 <@ayear, F1>= 2008, F3 <=@ayear
-- +
-- var. F1, F1<2008, F1 <@ayear

		UPDATE #balance
		SET var_Impegni_Propri_acc =
		ISNULL(
			(SELECT SUM(#var_finphase_acc_R.total) FROM #var_finphase_acc_R
				WHERE #var_finphase_acc_R.idfin = #balance.idfin
				AND #var_finphase_acc_R.idupb = #balance.idupb
				AND #balance.ayear = @ayear								-- riga con anno = @year
				AND #var_finphase_acc_R.ayear3 <= @ayear
				AND #var_finphase_acc_R.ayear1 < @ayear 
				AND #var_finphase_acc_R.ayear1 >= 2008
			GROUP BY #var_finphase_acc_R.idfin)
		, 0)
		+
		ISNULL(
				(SELECT SUM(#mov_Fase1_acc_R.total) FROM #mov_Fase1_acc_R
				WHERE #mov_Fase1_acc_R.idfin = #balance.idfin
					AND #mov_Fase1_acc_R.idupb = #balance.idupb
					AND #balance.ayear = @ayear
					AND #mov_Fase1_acc_R.ayear1 < 2008
					AND #mov_Fase1_acc_R.ayear1 < @ayear
				GROUP BY #mov_Fase1_acc_R.idfin)
				, 0)

		UPDATE #balance
		SET var_Impegni_Propri_red =
		ISNULL(
			(SELECT SUM(#var_finphase_red_R.total) FROM #var_finphase_red_R
				WHERE #var_finphase_red_R.idfin = #balance.idfin
				AND #balance.ayear = @ayear							-- riga con anno = @year
				AND #var_finphase_red_R.ayear3 < @ayear
				AND #var_finphase_red_R.ayear1 < @ayear 
				AND #var_finphase_red_R.ayear1 >= 2008
			GROUP BY #var_finphase_red_R.idfin)
		, 0)
		+
		ISNULL(
			(SELECT SUM(#var_finphase_red_R.total) FROM #var_finphase_red_R
				WHERE #var_finphase_red_R.idfin = #balance.idfin
				AND #balance.ayear = #var_finphase_red_R.ayear1								-- riga con anno = @year
				AND #var_finphase_red_R.ayear3 = @ayear
				AND #var_finphase_red_R.ayear1 < @ayear 
				AND #var_finphase_red_R.ayear1 >= 2008
			GROUP BY #var_finphase_red_R.idfin)
		, 0)
		+
		ISNULL(
			(SELECT SUM(#mov_Fase1_red_R.total) FROM #mov_Fase1_red_R
			WHERE #mov_Fase1_red_R.idfin = #balance.idfin
				AND #balance.ayear = @ayear
				AND #mov_Fase1_red_R.ayear1 <2008
				AND #mov_Fase1_red_R.ayear1 <@ayear
			GROUP BY #mov_Fase1_red_R.idfin)
		, 0)

		UPDATE #balance
		SET Pag_Residui_Propri =
		ISNULL(
			(SELECT SUM(#mov_maxphase_R.total) FROM #mov_maxphase_R
			WHERE #mov_maxphase_R.idfin = #balance.idfin
				AND #mov_maxphase_R.idupb = #balance.idupb
				AND #balance.ayear = @ayear								-- riga con anno = @year
				AND #mov_maxphase_R.ayear1 < 2008
				AND #mov_maxphase_R.ayear1 < @ayear
			GROUP BY #mov_maxphase_R.idfin)
		, 0) 
		+
		ISNULL(
			(SELECT SUM(#mov_maxphase_R.total) FROM #mov_maxphase_R
			WHERE #mov_maxphase_R.idfin = #balance.idfin
				AND #mov_maxphase_R.idupb = #balance.idupb
				AND #balance.ayear = @ayear								-- riga con anno = @year
				AND #mov_maxphase_R.ayear1>= 2008
				AND #mov_maxphase_R.ayear3 < @ayear
			GROUP BY #mov_maxphase_R.idfin)
		, 0) 
-- al netto delle variazioni
		UPDATE #balance
		SET Pag_Residui_Propri =
		Pag_Residui_Propri
		+
		ISNULL(
			(SELECT SUM(#var_maxphase_R.total) FROM #var_maxphase_R
			WHERE #var_maxphase_R.idfin = #balance.idfin
				AND  #var_maxphase_R.idupb = #balance.idupb
				AND #balance.ayear = @ayear						
				AND #var_maxphase_R.ayear1 < 2008
				AND #var_maxphase_R.ayear1 < @ayear
			GROUP BY #var_maxphase_R.idfin)
		, 0) 
		+
		ISNULL(
			(SELECT SUM(#var_maxphase_R.total) FROM #var_maxphase_R
			WHERE #var_maxphase_R.idfin = #balance.idfin
				AND  #var_maxphase_R.idupb = #balance.idupb
				AND #balance.ayear = @ayear							
				AND #var_maxphase_R.ayear1>= 2008
				AND #var_maxphase_R.ayear3 < @ayear
			GROUP BY #var_maxphase_R.idfin)
		, 0) 

		UPDATE #balance
		SET Pag_da_Stanziamenti = 
		ISNULL(
			(SELECT SUM(#mov_maxphase_R.total) FROM #mov_maxphase_R
			WHERE #mov_maxphase_R.idfin = #balance.idfin
				AND #mov_maxphase_R.idupb = #balance.idupb
				AND #balance.ayear = #mov_maxphase_R.ayear1								-- riga con anno = @year
				AND #mov_maxphase_R.ayear1>=2008
				AND #mov_maxphase_R.ayear1 <@ayear
				AND #mov_maxphase_R.ayear3 =@ayear
			GROUP BY #mov_maxphase_R.idfin,#mov_maxphase_R.ayear1)
		, 0)


-- al netto delle variazioni
		UPDATE #balance
		SET Pag_da_Stanziamenti = 
		Pag_da_Stanziamenti
		+
		ISNULL(
			(SELECT SUM(#var_maxphase_R.total) FROM #var_maxphase_R
			WHERE #var_maxphase_R.idfin = #balance.idfin
				AND #var_maxphase_R.idupb = #balance.idupb
				AND #balance.ayear = #var_maxphase_R.ayear1								-- riga con anno = @year
				AND #var_maxphase_R.ayear1>=2008
				AND #var_maxphase_R.ayear1 <@ayear
				AND #var_maxphase_R.ayear3 =@ayear
			GROUP BY #var_maxphase_R.idfin,#var_maxphase_R.ayear1)
		, 0)
-------------------------------------------- @showupb = S -------------------------------------
-- Calcola la Competenza

	UPDATE #balance
	SET 	mov_finphase_C =
	ISNULL(
		(SELECT #mov_finphase_C.total FROM #mov_finphase_C
		WHERE #mov_finphase_C.idupb = #balance.idupb
		and #mov_finphase_C.idfin = #balance.idfin)
	, 0),
	stanz3112 =
	ISNULL(
		(SELECT #stanz3112.total FROM #stanz3112
		WHERE #stanz3112.idupb = #balance.idupb
		and #stanz3112.idfin = #balance.idfin)
	, 0),
	var_finphase_acc_C =
	ISNULL(
		(SELECT #var_finphase_acc_C.total FROM #var_finphase_acc_C
		WHERE #var_finphase_acc_C.idupb = #balance.idupb
			and  #var_finphase_acc_C.idfin = #balance.idfin)
	, 0),
	var_finphase_red_C =
	ISNULL(
		(SELECT #var_finphase_red_C.total FROM #var_finphase_red_C
		WHERE #var_finphase_red_C.idupb = #balance.idupb
			and  #var_finphase_red_C.idfin = #balance.idfin)
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
	, 0)
END 

/*
 Se N qualora per un capitolo non esistano sott-capitoli con legami con l'upb fondo
 NON verrà visualizzata l'indicazione del Titolo/Categoria/Capitolo
*/

IF(Upper(@MostraTutteVoci)='N' AND @suppressifblank = 'S' )
BEGIN
	DELETE FROM #balance 
	WHERE 	ISNULL(Stanziamenti,0)= 0 AND ISNULL(var_Stanziamenti_acc,0)= 0 AND ISNULL(var_Stanziamenti_red,0)= 0
		AND ISNULL(Impegni_Propri,0)= 0 AND ISNULL(var_Impegni_Propri_acc,0)= 0 AND ISNULL(var_Impegni_Propri_red,0)= 0 
		AND ISNULL(Pag_Residui_Propri,0)= 0 AND ISNULL(Pag_da_Stanziamenti,0)= 0 AND ISNULL(Imp_Propri_da_stanziamenti,0)= 0
		AND ISNULL(mov_finphase_C,0)= 0 AND ISNULL(var_finphase_acc_C,0)= 0 AND ISNULL(var_finphase_red_C,0)= 0
		AND ISNULL(mov_maxphase_C,0)= 0 AND ISNULL(var_maxphase_C,0)= 0 AND ISNULL(stanz3112,0)= 0

		AND idupb <> '0001' 
END

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) 
BEGIN
	UPDATE #balance
	SET upbprintingorder =
		(SELECT TOP 1 upbprintingorder
		FROM #balance
		WHERE idupb = @idupboriginal),
	upb =
		(SELECT TOP 1 upb
		FROM #balance
		WHERE idupb = @idupboriginal),
	idupb =	@idupboriginal,
	codeupb =
		(SELECT TOP 1 codeupb
		FROM #balance	
		WHERE idupb = @idupboriginal)
END

IF (@showupb <>'S') and (@idupboriginal = '%')
BEGIN
	UPDATE #balance
	SET upbprintingorder = NULL,
	upb =  NULL,
	idupb = NULL,
	codeupb = NULL
END

IF (@levelusable_original=1)
BEGIN
	UPDATE #balance
	SET code2=NULL,order2=null,code3 = NULL,order3 =  NULL,code4=null,order4=null,code5=null,order5=null
END
IF (@levelusable_original=2)
BEGIN
	UPDATE #balance
	SET code3 = NULL,order3 =  NULL,code4=null,order4=null,code5=null,order5=null
END
IF (@levelusable_original=3) 
BEGIN
	UPDATE #balance
	SET code4=null,order4=null,code5=null,order5=null
END

IF  (@levelusable_original=4) 
BEGIN
	UPDATE #balance
	SET code5=null,order5=null
END

IF  (@levelusable_original<@minlevelusable) 
BEGIN
	UPDATE #balance SET idfin = (SELECT finlink.idparent 
				     FROM finlink 
				     WHERE finlink.idchild = #balance.idfin AND
				     finlink.nlevel  = @levelusable_original)
END


IF (@suppressifblank = 'S')
BEGIN
	UPDATE #balance SET tosuppress = 'S'
	WHERE   ISNULL(Stanziamenti,0)= 0 AND ISNULL(var_Stanziamenti_acc,0)= 0 AND ISNULL(var_Stanziamenti_red,0)= 0
		AND ISNULL(Impegni_Propri,0)= 0 AND ISNULL(var_Impegni_Propri_acc,0)= 0 AND ISNULL(var_Impegni_Propri_red,0)= 0 
		AND ISNULL(Pag_Residui_Propri,0)= 0 AND ISNULL(Pag_da_Stanziamenti,0)= 0 AND ISNULL(Imp_Propri_da_stanziamenti,0)= 0
		AND ISNULL(mov_finphase_C,0)= 0 AND ISNULL(var_finphase_acc_C,0)= 0 AND ISNULL(var_finphase_red_C,0)= 0
		AND ISNULL(mov_maxphase_C,0)= 0 AND ISNULL(var_maxphase_C,0)= 0 AND ISNULL(stanz3112,0)= 0


	UPDATE #balance SET tosuppress = 'N'
	WHERE NOT ( ISNULL(Stanziamenti,0)= 0 AND ISNULL(var_Stanziamenti_acc,0)= 0 AND ISNULL(var_Stanziamenti_red,0)= 0
		AND ISNULL(Impegni_Propri,0)= 0 AND ISNULL(var_Impegni_Propri_acc,0)= 0 AND ISNULL(var_Impegni_Propri_red,0)= 0 
		AND ISNULL(Pag_Residui_Propri,0)= 0 AND ISNULL(Pag_da_Stanziamenti,0)= 0 AND ISNULL(Imp_Propri_da_stanziamenti,0)= 0
		AND ISNULL(mov_finphase_C,0)= 0 AND ISNULL(var_finphase_acc_C,0)= 0 AND ISNULL(var_finphase_red_C,0)= 0
		AND ISNULL(mov_maxphase_C,0)= 0 AND ISNULL(var_maxphase_C,0)= 0 AND ISNULL(stanz3112,0)= 0
 
		) 
END
ELSE
BEGIN
	UPDATE #balance SET tosuppress = 'N'
END

delete from #balance where tosuppress = 'S'
	--and exists(select * from #balance B2 where  tosuppress = 'N' and
	--				B2.idfin=#balance.idfin
	--				and (B2.idupb=#balance.idupb OR (B2.idupb is null and #balance.idupb is null)))
delete from #balance where ayear < 2008

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

UPDATE #balance SET stanz3112 = stanz3112 - 
			(ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_acc_C,0)+ISNULL(var_finphase_red_C,0))

--select * from #balance
--return

SELECT #balance.ayear,
		--#balance.idfin,
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
		ISNULL(SUM(Stanziamenti),0) AS Stanziamenti,-- Colonna 1
		--ISNULL(SUM(var_Stanziamenti_acc),0) AS var_Stanziamenti_acc,
case when ISNULL(SUM(var_Stanziamenti_acc),0)+ISNULL(SUM(var_Stanziamenti_red),0)>0
	then  ISNULL(SUM(var_Stanziamenti_acc),0)+ISNULL(SUM(var_Stanziamenti_red),0)
	else 0
end
as var_Stanziamenti_acc,

--		ISNULL(SUM(var_Stanziamenti_red),0) AS var_Stanziamenti_red,
case when ISNULL(SUM(var_Stanziamenti_acc),0)+ISNULL(SUM(var_Stanziamenti_red),0)<0
	then  ISNULL(SUM(var_Stanziamenti_acc),0)+ISNULL(SUM(var_Stanziamenti_red),0)
	else 0
end
as var_Stanziamenti_red,

		ISNULL(SUM(Impegni_Propri),0) AS Impegni_Propri,-- Colonna 2
		ISNULL(SUM(var_Impegni_Propri_acc),0) AS var_Impegni_Propri_acc,
		ISNULL(SUM(var_Impegni_Propri_red),0) AS var_Impegni_Propri_red,
		ISNULL(SUM(Imp_Propri_da_stanziamenti),0) AS Imp_Propri_da_stanziamenti, -- Colonna 3
		ISNULL(SUM(Pag_Residui_Propri),0) AS Pag_Residui_Propri,
		ISNULL(SUM(Pag_da_Stanziamenti),0) AS Pag_da_Stanziamenti,

		ISNULL(SUM(stanz3112),0) AS StanziamentiDaComp,
		ISNULL(SUM(mov_finphase_C),0)+ISNULL(SUM(var_finphase_acc_C),0)+ ISNULL(SUM(var_finphase_red_C),0)-ISNULL(SUM(mov_maxphase_C),0)-ISNULL(SUM(var_maxphase_C),0) 
				AS ImpegniDaComp,

		case @fin_kind when 2 then 'S' else 'C' end AS previsionkind,
		showincomesurplus,
		CASE 
			WHEN (  ISNULL(SUM(Stanziamenti),0) = 0 AND 
				ISNULL(SUM(Impegni_Propri),0) = 0 AND 
				ISNULL(SUM(Imp_Propri_da_stanziamenti),0) = 0 AND
				ISNULL(SUM(Pag_Residui_Propri),0) = 0 AND
				ISNULL(SUM(Pag_da_Stanziamenti),0) = 0 AND 
				ISNULL(SUM(mov_finphase_C),0)= 0 AND 
				ISNULL(SUM(var_finphase_acc_C),0)= 0 AND 
				ISNULL(SUM(var_finphase_red_C),0)= 0	AND 
				ISNULL(SUM(mov_maxphase_C),0)= 0 AND 
				ISNULL(SUM(var_maxphase_C),0)= 0 AND 
				ISNULL(SUM(stanz3112),0)= 0 AND 
				@suppressifblank = 'S')
			THEN 'S' 
			ELSE 'N'
		END AS tosuppress,
		#balance.nlevel
	FROM #balance
	LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = #balance.idfin AND flk1.nlevel = 1
	LEFT OUTER JOIN fin f1
		ON flk1.idparent = f1.idfin 
	LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = #balance.idfin AND flk2.nlevel = 2
	LEFT OUTER JOIN fin f2
		ON flk2.idparent = f2.idfin 
	LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = #balance.idfin AND flk3.nlevel = 3
	LEFT OUTER JOIN fin f3
		ON flk3.idparent = f3.idfin 
	LEFT OUTER JOIN finlink flk4
		ON flk4.idchild = #balance.idfin AND flk4.nlevel = 4
	LEFT OUTER JOIN fin f4
		ON flk4.idparent = f4.idfin 
	LEFT OUTER JOIN finlink flk5
		ON flk5.idchild = #balance.idfin AND flk5.nlevel = 5
	LEFT OUTER JOIN fin f5
		ON flk5.idparent = f5.idfin 
	GROUP BY #balance.ayear,upbprintingorder,idupb,upb,codeupb,

		code1,f1.title,order1,code2,f2.title,order2,code3,
		f3.title,order3,code4,f4.title,order4,
		code5,f5.title,order5,
		codeupb,showincomesurplus,tosuppress,#balance.nlevel
	ORDER BY upbprintingorder ASC,
		order1 ASC,
		order2 ASC,
		order3 ASC,
		order4 ASC,
		order5 ASC,#balance.ayear ASC

END
/*

se fase1 < 2008 è tutto proprio
se fase 1 = 2008 allora stiamo almeno nel consuntivo 2009
	- se fase 3 = 2008 allora impegno proprio 
Quindi se fase 1 < 2008 allora porre = 2008
se fase 3 < 2008 porre uguale a 2008

CONSUNTIVO 2009 -------------------
se fase 1 = 2008 
	- se fase 3 = 2008 allora impegno proprio 
	- se fase 3 = 2009 allora impegno di stanziamento divenuto proprio nel 2009
CONSUNTIVO 2009 -------------------

CONSUNTIVO 2010 -------------------
se fase 1 = 2008 
	- se fase 3 = 2008 allora impegno proprio 
	- se fase 3 = 2009 allora impegno proprio
	- se fase 3 = 2010 allora impegno di stanziamento divenuto proprio nel 2010

se fase 1 = 2009 
	- se fase 3 = 2009 allora impegno proprio
CONSUNTIVO 2010 --------------------

CONSUNTIVO 2011 -------------------
se fase 1 = 2008 
	- se fase 3 = 2008 allora impegno proprio 
	- se fase 3 = 2009 allora impegno proprio
	- se fase 3 = 2010 allora impegno proprio
	- se fase 3 = 2011 allora impegno di stanziamento divenuto proprio nel 2011

se fase 1 = 2009 
	- se fase 3 = 2009 allora impegno proprio
	- se fase 3 = 2010 allora impegno proprio
	- se fase 3 = 2011 allora impegno di stanziamento divenuto proprio nel 2011

se fase 1 = 2010 
	- se fase 3 = 2010 allora impegno proprio
	- se fase 3 = 2011 allora impegno di stanziamento divenuto proprio nel 2011
CONSUNTIVO 2010 --------------------

Quindi:
- se fase 3 = <esercizio consuntivo> allora è un residuo divenuto proprio
- se fase 3 < <esercizio consuntivo> è un residuo proprio

Inoltre 
è residuo di stanziamento:
Somma Fase1 - Somma di tutti gli impegni propri ovvero
 Somma Fase1 - Somma Fase3 < <esercizio consuntivo>
*/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- exec rpt_bilconsuntivo_residui_stanz 2009,{ts '2009-12-31 00:00:00'},3,'%','N','S','S','S'
