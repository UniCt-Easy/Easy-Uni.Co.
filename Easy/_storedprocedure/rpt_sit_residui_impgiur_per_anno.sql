if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sit_residui_impgiur_per_anno]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sit_residui_impgiur_per_anno]
GO


CREATE  PROCEDURE [rpt_sit_residui_impgiur_per_anno]
	@ayear 		int,
	@date		datetime,
	@finpart 	char(1),
	@levelusable 	tinyint,
	@idupb		varchar(36),
	@showupb 	char(1),
	@showchildupb 	char(1)
AS
BEGIN
-- Questa stampa è sviluppata SOLO per l'amministrazione di BARI
DECLARE @finphase		tinyint
DECLARE @cash_phase		tinyint
DECLARE @idupboriginal 		varchar(36)
		

-- exec rpt_sit_residui_impgiur_per_anno 2008,{ts '2008-12-31 00:00:00'},'S',3,'%','N','S'
-- exec rpt_sit_residui_impgiur_per_anno 2009,{ts '2009-06-07 00:00:00'},'S',3,'%','N','S'
CREATE TABLE #report_residual
(
	ayear			int,
	codeupb			varchar(50),
	idupb 			varchar(36),
	upb   			varchar(150),
	upbprintingorder	varchar(50),
	idfin			int,
	codefin			varchar(50),
	title			varchar(150),
	finprintingorder	varchar(50),
	initial_residual	decimal(19,2),
	var_residual		decimal(19,2),
	cash_residual		decimal(19,2),
	var_cash_residual	decimal(19,2)				
)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') set @idupb=@idupb + '%' 
CREATE TABLE #initial_residual
	(ayear1 int,ayear3 int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #mov_Fase1_R
	(ayear1 int,idfin int, idupb varchar(36), total decimal(19,2))

CREATE TABLE #var_residual
	(ayear1 int,ayear3 int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_Fase1_R
	(ayear1 int,idfin int, idupb varchar(36), total decimal(19,2))

CREATE TABLE #cash_residual
	(ayear1 int,ayear3 int, idfin int, idupb varchar(36), total decimal(19,2))

CREATE TABLE #var_cash_residual
    	(ayear1 int,ayear3 int, idfin int, idupb varchar(36), total decimal(19,2))

DECLARE @cashvaliditykind int
SELECT	@cashvaliditykind = cashvaliditykind
FROM 	config
WHERE 	ayear = @ayear

DECLARE @finallocation tinyint
SELECT @finallocation = 1
SELECT @finphase = 3 --	<<<<<<	Questa è l'ipotesi fondamentale di questa stampa
SELECT @cash_phase = MAX(nphase)
FROM expensephase

INSERT INTO #initial_residual
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


INSERT INTO #var_residual
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
	AND EY.idupb like @idupb
GROUP BY E1.ymov,E.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)

INSERT INTO #var_Fase1_R
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
	AND EY.idupb like @idupb
GROUP BY E.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)


INSERT INTO #cash_residual
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
		INSERT INTO #var_cash_residual
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

	
INSERT INTO #report_residual (ayear, idfin,idupb)
SELECT DISTINCT ayear3,idfin,idupb 
	FROM #initial_residual

INSERT INTO #report_residual (ayear, idfin,idupb)
SELECT DISTINCT ayear1,idfin,idupb 
	FROM #mov_Fase1_R
	WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #mov_Fase1_R.idfin
		and i1.idupb = #mov_Fase1_R.idupb
		and i1.ayear = #mov_Fase1_R.ayear1
		)

INSERT INTO #report_residual (ayear, idfin,idupb)
SELECT DISTINCT ayear3,idfin,idupb 
	FROM #var_residual
	WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #var_residual.idfin
		and i1.idupb = #var_residual.idupb
		and i1.ayear = #var_residual.ayear3
		)

INSERT INTO #report_residual (ayear, idfin,idupb)
SELECT DISTINCT ayear1,idfin,idupb 
	FROM #var_Fase1_R
	WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #var_Fase1_R.idfin
		and i1.idupb = #var_Fase1_R.idupb
		and i1.ayear = #var_Fase1_R.ayear1
		)


INSERT INTO #report_residual (ayear, idfin,idupb)
SELECT DISTINCT ayear3,idfin,idupb
	FROM #cash_residual
	WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #cash_residual.idfin
		and i1.idupb = #cash_residual.idupb
		and i1.ayear = #cash_residual.ayear3
		)
--- SARA
INSERT INTO #report_residual (ayear, idfin,idupb)
SELECT DISTINCT ayear1,idfin,idupb
	FROM #cash_residual
	WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #cash_residual.idfin
		and i1.idupb = #cash_residual.idupb
		and i1.ayear = #cash_residual.ayear1
		)

INSERT INTO #report_residual (ayear, idfin, idupb)
SELECT DISTINCT ayear3,idfin ,idupb
	FROM #var_cash_residual
	WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #var_cash_residual.idfin
		and i1.idupb = #var_cash_residual.idupb
		and i1.ayear = #var_cash_residual.ayear3
		)
-- Sara

INSERT INTO #report_residual (ayear, idfin, idupb)
SELECT DISTINCT ayear1,idfin ,idupb
	FROM #var_cash_residual
	WHERE not exists(SELECT *
		FROM #report_residual i1
		where i1.idfin = #var_cash_residual.idfin
		and i1.idupb = #var_cash_residual.idupb
		and i1.ayear = #var_cash_residual.ayear1
		)

-- F1, ove F1<=2007 (<2008), F1<@ayear
--	+
-- F3, ove F1 <@ayear, F3 < @ayear, F1 >= 2008

UPDATE #report_residual 
SET initial_residual = 
		ISNULL((SELECT sum(#mov_Fase1_R.total) FROM #mov_Fase1_R
			WHERE 
			#mov_Fase1_R.ayear1 < 2008
			AND #mov_Fase1_R.ayear1 < @ayear
			AND #mov_Fase1_R.idfin = #report_residual.idfin
			AND #mov_Fase1_R.idupb = #report_residual.idupb
			AND #mov_Fase1_R.ayear1 = #report_residual.ayear -- Anno del Residuo di Stanziamento
			group by #mov_Fase1_R.idupb, #mov_Fase1_R.idfin , #mov_Fase1_R.ayear1 
		), 0.0)
		+
		ISNULL((SELECT sum(#initial_residual.total) FROM #initial_residual
			WHERE 
			#initial_residual.ayear1 >= 2008
			AND #initial_residual.ayear1 < @ayear
			AND #initial_residual.ayear3 < @ayear
			AND #initial_residual.idfin = #report_residual.idfin
			AND #initial_residual.idupb = #report_residual.idupb
			AND #initial_residual.ayear3 = #report_residual.ayear-- Anno dell' impegno Residuo
			group by #initial_residual.idupb,#initial_residual.idfin, #initial_residual.ayear3 
			), 0.0)

-- Variazioni F3:
-- Var. RP:
-- var. F3, F1 <@ayear, F1>= 2008, F3 <=@ayear
-- +
-- var. F1, F1<2008, F1 <@ayear

UPDATE #report_residual 
SET var_residual = ISNULL((SELECT sum(#var_residual.total) FROM #var_residual
	WHERE #var_residual.idfin = #report_residual.idfin
	and #var_residual.idupb = #report_residual.idupb
	and #var_residual.ayear3 = #report_residual.ayear
	AND #var_residual.ayear3 <= @ayear
	AND #var_residual.ayear1 < @ayear
	AND #var_residual.ayear1 >= 2008
	GROUP BY #var_residual.idupb, #var_residual.idfin, #var_residual.ayear3
	), 0.0)
	+
	ISNULL((SELECT sum(#var_Fase1_R.total) FROM #var_Fase1_R
	WHERE #var_Fase1_R.idfin = #report_residual.idfin
	AND #var_Fase1_R.idupb = #report_residual.idupb
	AND #var_Fase1_R.ayear1 = #report_residual.ayear
	AND #var_Fase1_R.ayear1 < @ayear
	AND #var_Fase1_R.ayear1 < 2008
	group by #var_Fase1_R.idupb, #var_Fase1_R.idfin, #var_Fase1_R.ayear1
	), 0.0)

-- In questa colonna aggiungo i Residui divenuti Propri, ossia
-- Residui di Stanziamento Divenuti propri 
-- Tutto F3					ove F3 = @ayear, F1>=2008, F1<@ayear
UPDATE #report_residual 
SET var_residual = 
	var_residual
	+
		ISNULL(
			(SELECT SUM(#initial_residual.total) FROM #initial_residual
				WHERE #initial_residual.idfin = #report_residual.idfin
				AND #initial_residual.idupb = #report_residual.idupb
				AND #report_residual.ayear = #initial_residual.ayear3		
				AND #initial_residual.ayear3 = @ayear	
				AND #initial_residual.ayear1 >= 2008
				AND #initial_residual.ayear1 < @ayear
			GROUP BY #initial_residual.idfin,#initial_residual.ayear3 )
		, 0)

-- Pagamenti da Residui Propri
-- Pag. Residui, ove F1<2008, F1<@ayear
-- +
-- Pag. Residui, ove F1>= 2008, F3< ayear

UPDATE #report_residual
SET cash_residual =	
	ISNULL((SELECT sum(#cash_residual.total) FROM #cash_residual
	WHERE #cash_residual.idfin = #report_residual.idfin
	and #cash_residual.idupb = #report_residual.idupb
	AND #cash_residual.ayear1 < 2008
 	AND #cash_residual.ayear1 < @ayear
	AND #cash_residual.ayear1 = #report_residual.ayear
	group by  #cash_residual.idupb,#cash_residual.idfin,#cash_residual.ayear1 --- F1, Sara
	), 0.0)
	+
	ISNULL((SELECT sum(#cash_residual.total) FROM #cash_residual
	WHERE #cash_residual.idfin = #report_residual.idfin
	and #cash_residual.idupb = #report_residual.idupb
	AND #cash_residual.ayear1 >= 2008
 	AND #cash_residual.ayear3 < @ayear
	AND #cash_residual.ayear3 = #report_residual.ayear
	group by  #cash_residual.idupb,#cash_residual.idfin,#cash_residual.ayear3
	), 0.0)


-- Devo anche, sommare Pagamenti da Residui ( di stanziamento) :
 -- Pagamenti residui, ove F1>= 2008, F1<@ayear , F3 = @ayear				

UPDATE #report_residual
SET cash_residual =	
	cash_residual 
	+ 
	ISNULL((SELECT sum(#cash_residual.total) FROM #cash_residual
		WHERE #cash_residual.idfin = #report_residual.idfin
		and #cash_residual.idupb = #report_residual.idupb
		AND #cash_residual.ayear1 >= 2008
 		AND #cash_residual.ayear1 < @ayear
		AND #cash_residual.ayear3 = @ayear
		AND #cash_residual.ayear3 = #report_residual.ayear
	group by  #cash_residual.idupb,#cash_residual.idfin,#cash_residual.ayear3 -- F3
	), 0.0)


-- Devo calcolare le variazioni sia dei pagamenti dei Residui Propri che dei residui di stanziamento
-- Var. dei Pagamenti da Residui Propri
-- Var. Pag. Residui, ove F1<2008, F1<@ayear
-- +
-- Var. Pag. Residui, ove F1>= 2008, F3< ayear

UPDATE #report_residual
SET var_cash_residual =	
	ISNULL((SELECT sum(#var_cash_residual.total) FROM #var_cash_residual
	WHERE #var_cash_residual.idfin = #report_residual.idfin
	and #var_cash_residual.idupb = #report_residual.idupb
	AND #var_cash_residual.ayear1 < 2008
 	AND #var_cash_residual.ayear1 < @ayear
	AND #var_cash_residual.ayear1 = #report_residual.ayear -- F1
	group by  #var_cash_residual.idupb,#var_cash_residual.idfin,#var_cash_residual.ayear1
	), 0.0)
	+
	ISNULL((SELECT sum(#var_cash_residual.total) FROM #var_cash_residual
	WHERE #var_cash_residual.idfin = #report_residual.idfin
	and #var_cash_residual.idupb = #report_residual.idupb
	AND #var_cash_residual.ayear1 >= 2008
 	AND #var_cash_residual.ayear3 < @ayear
	AND #var_cash_residual.ayear3 = #report_residual.ayear -- F3
	group by  #var_cash_residual.idupb,#var_cash_residual.idfin,#var_cash_residual.ayear3
	), 0.0)


-- Devo anche, sommare le Var. dei Pagamenti da Residui di stanziamento:
 -- Var. Pagamenti residui, ove F1>= 2008, F1<@ayear , F3 = @ayear

UPDATE #report_residual
SET var_cash_residual =	
	var_cash_residual 
	+ 
	ISNULL((SELECT sum(#var_cash_residual.total) FROM #var_cash_residual
		WHERE #var_cash_residual.idfin = #report_residual.idfin
		and #var_cash_residual.idupb = #report_residual.idupb
		AND #var_cash_residual.ayear1 >= 2008
 		AND #var_cash_residual.ayear1 < @ayear
		AND #var_cash_residual.ayear3 = @ayear
		AND #var_cash_residual.ayear3 = #report_residual.ayear
	group by  #var_cash_residual.idupb,#var_cash_residual.idfin,#var_cash_residual.ayear3
	), 0.0)


UPDATE #report_residual SET title = fin.title ,
		finprintingorder = fin.printingorder,
		codefin = fin.codefin	
	 	from fin where fin.idfin = #report_residual.idfin

UPDATE #report_residual SET codeupb = upb.codeupb ,
		upbprintingorder = upb.printingorder,			
		upb = upb.title
	 from upb where upb.idupb = #report_residual.idupb

	IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
			UPDATE #report_residual SET  
				upbprintingorder = (SELECT TOP 1 upbprintingorder
					FROM #report_residual
					WHERE idupb = @idupboriginal),
				upb = (SELECT TOP 1 upb
					FROM #report_residual
					WHERE idupb = @idupboriginal),
				idupb = @idupboriginal,
				codeupb =(SELECT TOP 1 codeupb
					FROM #report_residual	
					WHERE idupb = @idupboriginal)
	
	IF (@showupb <>'S') and (@idupboriginal = '%') 
				UPDATE #report_residual SET  
				upbprintingorder = null	,
				upb =  null,
				idupb = null,
				codeupb = null

IF (@showupb <>'S') 
BEGIN
	SELECT 
		ayear,
		idfin,
		codefin,
		title,
		finprintingorder,
		codeupb,		
		idupb,	
		upb,
		upbprintingorder,
		ISNULL(SUM(initial_residual),0) 	as 'initial_residual',
		ISNULL(SUM(var_residual),0)		as 'var_residual',
		ISNULL(SUM(cash_residual),0) 		as 'cash_residual',
		ISNULL(SUM(var_cash_residual),0) 	as 'var_cash_residual'
	FROM #report_residual
	group by upbprintingorder,finprintingorder,
	ayear,idfin,codefin,title,codeupb,idupb,upb   			
	ORDER BY ayear ASC,upbprintingorder ASC,finprintingorder ASC
END 
ELSE
	SELECT 
		ayear,
		idfin,
		codefin,
		title,
		finprintingorder,
		codeupb,		
		idupb,	
		upb,
		upbprintingorder,
		isnull(initial_residual,0) 		as 'initial_residual',
		isnull(var_residual,0)			as 'var_residual',
		isnull(cash_residual,0)			as 'cash_residual',
		isnull(var_cash_residual,0)		as 'var_cash_residual'
	FROM #report_residual
	ORDER BY ayear ASC,upbprintingorder ASC,finprintingorder ASC
END

GO

