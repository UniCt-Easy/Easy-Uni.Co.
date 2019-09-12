if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitpatrim_totale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitpatrim_totale]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--setuser 'amm'
--rpt_sitpatrim_totale 2011


CREATE PROCEDURE [rpt_sitpatrim_totale]
(
	@year int,
	@date datetime =null,
	@showmotive char(1)='N'
)
AS BEGIN

DECLARE @firstday datetime
DECLARE @lastday datetime

SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)
set @lastday = CONVERT(datetime, '31-12-' + CONVERT(char(4),@year), 105)

if (@date is null) SET @date = @lastday
if (@date>@lastday) set @date = @lastday

-- Situazione Patrimoniale Totale
CREATE TABLE #patrimonio
(
	idsor int,
	description varchar(150),
	initial_amount decimal(19,2),
	idmot int,
	var_aum decimal(19,2),
	var_dim decimal(19,2),
	amortization decimal(19,2)
)
	
CREATE TABLE #assetloadmotive
(
idmot  int,
codemot varchar(20),
description  varchar(50)
)
INSERT INTO #assetloadmotive
(idmot, codemot, description)
SELECT idmot, codemot, description
FROM assetloadmotive
UNION
SELECT
null, null,null


INSERT INTO #patrimonio (idsor,idmot, description)
SELECT inventorytree.idinv,#assetloadmotive.idmot, inventorytree.description
FROM inventorytree 
CROSS JOIN #assetloadmotive
WHERE inventorytree.nlevel = 1
	
CREATE TABLE #tempdata(idsor int, idmot int, total decimal(19,2))

-------------------------------------------------------------------------------------
-------------------------- Situazione patrim. iniziale-------------------------------
-------------------------------------------------------------------------------------
UPDATE #patrimonio 
SET initial_amount = 
ISNULL(
	(SELECT	SUM(assetvardetail.amount)
	FROM assetvardetail
	JOIN assetvar						ON assetvar.idassetvar = assetvardetail.idassetvar
	JOIN inventorytreelink				ON inventorytreelink.idchild = assetvardetail.idinv
	WHERE (assetvar.flag & 1 = 0)
		AND assetvar.yvar = @year
		AND assetvar.adate <= @date
		AND ISNULL(assetvardetail.idmot,0) = ISNULL(#patrimonio.idmot,0)
		AND inventorytreelink.idparent = #patrimonio.idsor
		AND inventorytreelink.nlevel = 1)
,0)
	
-------------------------------------------------------------------------------------
-------------------------- Variazioni sit. patrim. ----------------------------------
-------------------------------------------------------------------------------------
UPDATE #patrimonio 
SET var_aum = 
ISNULL(
	(SELECT SUM(assetvardetail.amount)
	FROM assetvardetail		
	JOIN assetvar						ON assetvar.idassetvar = assetvardetail.idassetvar
	JOIN inventorytreelink				ON inventorytreelink.idchild = assetvardetail.idinv
	WHERE (assetvar.flag & 1 <> 0)
		AND assetvar.yvar = @year
		AND assetvar.adate <= @date
		AND assetvardetail.amount > 0
		AND ISNULL(assetvardetail.idmot,0) = ISNULL(#patrimonio.idmot,0)
		AND inventorytreelink.idparent = #patrimonio.idsor
		AND inventorytreelink.nlevel = 1)
,0)

UPDATE #patrimonio 
SET var_dim =
- ISNULL(
	(SELECT SUM(assetvardetail.amount)
	FROM assetvardetail
	JOIN assetvar						ON assetvar.idassetvar = assetvardetail.idassetvar
	JOIN inventorytreelink				ON inventorytreelink.idchild = assetvardetail.idinv
	WHERE (assetvar.flag & 1 <> 0)
		AND assetvar.yvar = @year
		AND assetvar.adate <= @date
		AND assetvardetail.amount < 0
		AND ISNULL(assetvardetail.idmot,0) = ISNULL(#patrimonio.idmot,0)
		AND inventorytreelink.idparent = #patrimonio.idsor
		AND inventorytreelink.nlevel = 1)
,0)

-------------------------------------------------------------------------------------
-------------------------- Carichi cespiti E accessori principali--------------------------------
INSERT INTO #tempdata(idsor,idmot,total)
SELECT
	inventorytreelink.idparent,
	assetacquire.idmot,
	SUM(AC.start)
FROM assetacquire
JOIN asset							ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC			on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece
JOIN assetload						ON assetload.idassetload = assetacquire.idassetload
JOIN inventory						ON assetacquire.idinventory=inventory.idinventory
JOIN inventorykind					ON inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventorytreelink				ON inventorytreelink.idchild = assetacquire.idinv
WHERE assetload.yassetload <= @year 
	AND inventorytreelink.nlevel = 1
	AND assetload.ratificationdate BETWEEN @firstday AND @date	
	AND ( (inventorykind.flag&2)=0)

GROUP BY inventorytreelink.idparent,assetacquire.idmot
		
UPDATE #patrimonio SET var_aum = ISNULL(var_aum,0) +
ISNULL(
	(SELECT SUM(total) FROM #tempdata 
	  WHERE idsor=#patrimonio.idsor
	    AND	ISNULL(idmot,0)=ISNULL(#patrimonio.idmot,0)
	)
,0)

DELETE FROM #tempdata

--------------------------------------------------------------------------------------------------------------
----------- Rivalutazioni positive ufficiali  (da accoppiare a carichi cespite/accessori) --------------------
--------------------------------------------------------------------------------------------------------------
INSERT INTO #tempdata(idsor,idmot,total)
SELECT
	inventorytreelink.idparent,
	assetacquire.idmot,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset								ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization					ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetload				ON  assetamortization.idassetload = assetload.idassetload
JOIN inventory							ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind						ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization				ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink					ON inventorytreelink.idchild = assetacquire.idinv
WHERE inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota > 0 AND
	(
		(
		 ((assetamortization.flag & 1 = 0)
		  AND assetamortization.adate BETWEEN @firstday AND @date) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)
                   AND assetload.ratificationdate BETWEEN @firstday AND @date)
		)
	)
	AND ( (inventorykind.flag&2)=0)
GROUP BY inventorytreelink.idparent,assetacquire.idmot
UPDATE #patrimonio SET amortization = ISNULL(amortization,0) -
ISNULL(
	(SELECT SUM(total) from #tempdata 
	where idsor=#patrimonio.idsor
	 AND  ISNULL(idmot,0)=ISNULL(#patrimonio.idmot,0)
	)
,0)
/*
UPDATE #patrimonio SET var_aum= ISNULL(var_aum,0) +
ISNULL( 
	(SELECT SUM(total) FROM #tempdata 
	WHERE idsor=#patrimonio.idsor
	 AND  ISNULL(idmot,0)=ISNULL(#patrimonio.idmot,0)
	)
,0)
*/

DELETE FROM #tempdata

----------------------------------------------------------------------------------------------------------
-- Rivalutazioni Negative ufficiali DI BENI E ACCESSORI (da accoppiare a carichi cespite/accessori) ------
----------------------------------------------------------------------------------------------------------
INSERT INTO #tempdata(idsor,idmot,total)
SELECT
	inventorytreelink.idparent,
	assetacquire.idmot,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire	
JOIN asset								ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventory							ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind						ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN assetamortization					ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload				ON  assetamortization.idassetunload = assetunload.idassetunload
JOIN inventoryamortization				ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink					ON inventorytreelink.idchild = assetacquire.idinv
WHERE inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0 AND
	(
		(
		 ((assetamortization.flag & 1 = 0)
		  AND assetamortization.adate BETWEEN @firstday AND @date) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)
                   AND assetunload.adate BETWEEN @firstday AND @date)
		)
	)
	AND ( (inventorykind.flag&2)=0)
	AND (inventoryamortization.flag &8) <> 0 -- Considera solo i tipo ammortamento : Ammortamento
	--AND assetamortization.adate <= @date
	--AND assetamortization.adate >= @firstday
GROUP BY inventorytreelink.idparent, assetacquire.idmot

UPDATE #patrimonio SET amortization = ISNULL(amortization,0) -
ISNULL(
	(SELECT SUM(total) from #tempdata 
	where idsor=#patrimonio.idsor
	 AND  ISNULL(idmot,0)=ISNULL(#patrimonio.idmot,0)
	)
,0)

DELETE FROM #tempdata


----------------------------------------------------------------------------------------------------------
-- Svalutazioni Negative ufficiali DI BENI E ACCESSORI (da accoppiare a carichi cespite/accessori) ------
----------------------------------------------------------------------------------------------------------
INSERT INTO #tempdata(idsor,idmot,total)
SELECT
	inventorytreelink.idparent,
	assetacquire.idmot,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire	
JOIN asset								ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventory							ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind						ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN assetamortization					ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload				ON  assetamortization.idassetunload = assetunload.idassetunload
JOIN inventoryamortization				ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink					ON inventorytreelink.idchild = assetacquire.idinv
WHERE inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0 AND
	(
		(
		 ((assetamortization.flag & 1 = 0)
		  AND assetamortization.adate BETWEEN @firstday AND @date) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)
                   AND assetunload.adate BETWEEN @firstday AND @date)
		)
	)
	AND ( (inventorykind.flag&2)=0)
	AND (inventoryamortization.flag &8) = 0 -- Considera solo i tipo ammortamento : Svalutazione
GROUP BY inventorytreelink.idparent, assetacquire.idmot

UPDATE #patrimonio SET var_dim = ISNULL(var_dim,0) -
ISNULL(
	(SELECT SUM(total) from #tempdata 
	where idsor=#patrimonio.idsor
	 AND  ISNULL(idmot,0)=ISNULL(#patrimonio.idmot,0)
	)
,0)

DELETE FROM #tempdata
---------------------------------------------------------------------------------------------------------
-------------------------- Scarichi Cespite E Accessori ------------------------------------------------
---------------------------------------------------------------------------------------------------------

--    	Considera i buoni di carico precedenti al 2005 
INSERT INTO #tempdata(idsor,idmot,total)
SELECT
	inventorytreelink.idparent,
	caricocespite.idmot,
	SUM(AC.currentvalue)
FROM assetacquire as caricocespite
LEFT OUTER JOIN assetload					ON assetload.idassetload = caricocespite.idassetload
JOIN asset as cespite						ON caricocespite.nassetacquire = cespite.nassetacquire
JOIN assetview_current AC					on AC.idasset=cespite.idasset and AC.idpiece=cespite.idpiece
JOIN assetunload as buonoscaricocespite		ON buonoscaricocespite.idassetunload = cespite.idassetunload
join inventory								on caricocespite.idinventory=inventory.idinventory
join inventorykind							on inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventorytreelink						ON inventorytreelink.idchild = caricocespite.idinv
WHERE buonoscaricocespite.yassetunload <= @year
	AND inventorytreelink.nlevel = 1
	AND buonoscaricocespite.adate BETWEEN @firstday AND @date
	AND ( (inventorykind.flag&2)=0)
GROUP BY inventorytreelink.idparent,caricocespite.idmot


UPDATE #patrimonio SET var_dim= ISNULL(var_dim,0) +
ISNULL( 
	(SELECT SUM(total) from #tempdata 
	 WHERE idsor=#patrimonio.idsor
	 AND ISNULL(idmot,0)=ISNULL(#patrimonio.idmot,0)
      )
,0)

DELETE FROM #tempdata




----CALCOLO VARIAZIONI DEI RESIDUI PASSIVI 

DECLARE @var_finphase_R_AUM decimal(19,2)
DECLARE @var_finphase_R_DIM decimal(19,2)
DECLARE @var_finphase_R decimal(19,2)
DECLARE @finphase tinyint
DECLARE @levelusable int



SELECT @finphase = appropriationphasecode FROM config
	WHERE ayear = @year
IF @finphase IS NULL
	BEGIN
		SELECT @finphase = expensefinphase FROM uniconfig
	END

SELECT  @levelusable = min(nlevel)
FROM 	finlevel
WHERE 	ayear = @year and flag&2 <> 0

SELECT 	@var_finphase_R_AUM = SUM(IV.amount)
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
	WHERE IV.yvar = @year
		AND IY.ayear = @year
		AND ( (IT.flag & 1) <> 0)-- Residuo
		AND I.nphase = @finphase								--calcolare
		AND IV.adate <= @date 

SELECT @var_finphase_R_DIM = SUM(EV.amount)
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
	WHERE EV.yvar = @year
		AND EV.adate <= @date 
		AND EY.ayear = @year
		AND ( (ET.flag & 1) <> 0) -- Residuo
		AND E.nphase = @finphase

IF  ISNULL(@var_finphase_R_AUM,0) > ABS(ISNULL(@var_finphase_R_DIM ,0))
	BEGIN
		SET @var_finphase_R_AUM = ISNULL(@var_finphase_R_AUM,0) - ISNULL(@var_finphase_R_DIM,0)
		SET @var_finphase_R_DIM = 0
	END
ELSE
	BEGIN
		SET @var_finphase_R_DIM  = ISNULL(@var_finphase_R_AUM,0) - ISNULL(@var_finphase_R_DIM ,0)
		SET @var_finphase_R_AUM = 0
	END

DELETE FROM #tempdata

DECLARE @startfloatfund decimal(19,2)
DECLARE @aumfloatfund decimal(19,2)
DECLARE @dimfloatfund decimal(19,2)
DECLARE @previousrevenue decimal(19,2)
DECLARE @currentrevenue decimal(19,2)
DECLARE @residualrevenue decimal(19,2)
DECLARE @previousexpenditure decimal(19,2)
DECLARE @currentexpenditure decimal(19,2)
DECLARE @residualexpenditure decimal(19,2)
DECLARE @residualpayments decimal(19,2)

SELECT 
	@startfloatfund = ISNULL(startfloatfund, 0.0),
    @aumfloatfund = ISNULL(competencyproceeds, 0.0) + ISNULL(residualproceeds, 0.0),
    @dimfloatfund = ISNULL(competencypayments, 0.0) + ISNULL(residualpayments, 0.0),
	@previousrevenue = ISNULL(previousrevenue, 0.0) + ISNULL(residualproceeds, 0.0),
    @currentrevenue = ISNULL(currentrevenue, 0.0),
    @residualrevenue = ISNULL(residualproceeds, 0.0),
	@previousexpenditure = ISNULL(previousexpenditure, 0.0),
    @currentexpenditure = ISNULL(currentexpenditure, 0.0),
    @residualexpenditure = ISNULL(residualpayments, 0.0),
	@residualpayments = ISNULL(residualpayments, 0.0)
FROM surplus
WHERE ayear = @year

	

INSERT INTO #patrimonio (idsor, idmot, description, initial_amount, var_aum, var_dim)
VALUES('9999','9999', 'Avanzo di cassa', @startfloatfund, @aumfloatfund, @dimfloatfund)
INSERT INTO #patrimonio (idsor, idmot, description, initial_amount, var_aum, var_dim)
VALUES('9998','9998', 'Residui Attivi', @previousrevenue, @currentrevenue, @residualrevenue)

if (@showmotive<>'S')
Begin
-- La riga non serve per la stampa '..._causale'
	INSERT INTO #patrimonio (idsor, idmot, description, initial_amount, var_aum, var_dim)
	VALUES('9997','9997', 'Residui Passivi', @previousexpenditure + @residualpayments + 
		(@var_finphase_R_AUM + @var_finphase_R_DIM )
			,@var_finphase_R_AUM , 
		(@residualpayments - @currentexpenditure) + @var_finphase_R_DIM )
End

IF (@showmotive = 'S')
BEGIN
	DELETE FROM #patrimonio 
	WHERE  #patrimonio.idmot IS NULL 
	AND    ISNULL(initial_amount,0) = 0
	AND    ISNULL(var_aum,0) = 0 
	AND    ISNULL(var_dim,0) = 0
	AND    ISNULL(amortization,0) = 0

	SELECT 
		#patrimonio.idsor,
		CLASS.codeinv AS 'codesor',
		CLASS.nlevel,
		MOTIVE.idmot,
		MOTIVE.description as 'motive',
		#patrimonio.description,
		#patrimonio.initial_amount AS 'initialamount',
		#patrimonio.var_aum AS 'improveamount',
		#patrimonio.var_dim AS 'decreaseamount',
		amortization,
		@date AS 'stop'
	FROM #patrimonio	
	LEFT OUTER JOIN inventorytree CLASS 
		ON CLASS.idinv=#patrimonio.idsor
	LEFT OUTER JOIN #assetloadmotive MOTIVE 
		ON MOTIVE.idmot = ISNULL(#patrimonio.idmot,0)
	ORDER BY #patrimonio.idmot, ISNULL(CLASS.codeinv,#patrimonio.idsor)
END
ELSE
BEGIN
	SELECT 
		#patrimonio.idsor,
		CLASS.codeinv AS 'codesor',
		CLASS.nlevel,
		null as 'idmot',
		null as 'motive',
		#patrimonio.description,
		ISNULL(SUM(#patrimonio.initial_amount),0) AS 'initialamount',
		ISNULL(SUM(#patrimonio.var_aum),0) AS 'improveamount',
		ISNULL(SUM(#patrimonio.var_dim),0) AS 'decreaseamount',
		ISNULL(SUM(amortization),0) as 'amortization',
		@date AS 'stop'
	FROM #patrimonio	
	LEFT OUTER JOIN inventorytree CLASS 
		ON CLASS.idinv=#patrimonio.idsor
	GROUP BY #patrimonio.idsor,CLASS.codeinv, CLASS.nlevel, #patrimonio.description
	ORDER BY ISNULL(CLASS.codeinv,#patrimonio.idsor)
END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 