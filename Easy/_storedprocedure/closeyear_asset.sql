
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_asset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_asset]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--closeyear_asset 2015,null
CREATE      PROCEDURE [closeyear_asset]
(
	 @ayear int,
	 @idinventoryagency int
)
AS BEGIN
DECLARE @date datetime
SET 	@date = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)
	
DECLARE @firstday datetime
SET 	@firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@ayear), 105)
	
	-------------------------------------------------------------------------------------
	-------------------------- Situazione patrim. iniziale-------------------------------
	-------------------------------------------------------------------------------------

CREATE TABLE #cons_iniziale
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)
INSERT INTO #cons_iniziale
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	assetvar.idinventoryagency,
	assetvardetail.idinv,
	assetvardetail.idinventory,
	assetvardetail.idmot,
	ISNULL(SUM(assetvardetail.amount),0)
FROM assetvardetail
JOIN assetvar							ON assetvar.idassetvar = assetvardetail.idassetvar
WHERE assetvar.flag & 1 = 0
	AND assetvar.yvar = @ayear
	AND assetvar.adate <= @date
	AND (assetvar.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
GROUP BY assetvar.idinventoryagency, assetvardetail.idinv, assetvardetail.idinventory,assetvardetail.idmot 

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

	-------------------------------------------------------------------------------------
	-------------------------- Variazioni sit. patrim. ----------------------------------
	-------------------------------------------------------------------------------------

CREATE TABLE #variazione_aum
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)
	
INSERT INTO #variazione_aum
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	assetvar.idinventoryagency,
	assetvardetail.idinv,
	assetvardetail.idinventory,
	assetvardetail.idmot,
	ISNULL(SUM(assetvardetail.amount),0)
FROM assetvardetail
JOIN assetvar						ON assetvar.idassetvar = assetvardetail.idassetvar
WHERE assetvar.flag & 1 <> 0
	AND assetvar.yvar = @ayear
	AND assetvar.adate <= @date
	AND assetvardetail.amount > 0
	AND (assetvar.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
GROUP BY assetvar.idinventoryagency, assetvardetail.idinv, assetvardetail.idinventory,assetvardetail.idmot 
	
CREATE TABLE #variazione_dim
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)
INSERT INTO #variazione_dim
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	assetvar.idinventoryagency,
	assetvardetail.idinv,
	assetvardetail.idinventory,
	assetvardetail.idmot, 
	ISNULL(SUM(assetvardetail.amount),0)
FROM assetvardetail
JOIN assetvar					ON assetvar.idassetvar = assetvardetail.idassetvar
WHERE assetvar.flag & 1 <> 0
	AND assetvar.yvar = @ayear
	AND assetvar.adate <= @date
	AND assetvardetail.amount < 0
	AND (assetvar.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
GROUP BY assetvar.idinventoryagency, assetvardetail.idinv, assetvardetail.idinventory,assetvardetail.idmot



-------------------------------------------------------------------------------------
-------------------------- Carichi CESPITI E accessori ----------------------------------------
-------------------------------------------------------------------------------------	

CREATE TABLE #caricocespiti
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)
INSERT INTO #caricocespiti
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idinventory,
	assetacquire.idmot,
	ISNULL(SUM(AC.start),0)
FROM assetacquire
JOIN asset							ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC			on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetload						ON  assetload.idassetload = assetacquire.idassetload
JOIN inventory						ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind					ON inventory.idinventorykind= inventorykind.idinventorykind
	WHERE  assetload.yassetload <= @ayear
		AND assetload.ratificationdate BETWEEN @firstday AND @date
		AND (inventory.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
		AND ( (inventorykind.flag&2)=0)
GROUP BY inventory.idinventoryagency, assetacquire.idinv, assetacquire.idinventory,assetacquire.idmot

-------------------------------------------------------------------------------------
---- Rivalutazioni positive ufficiali (di CESPITI E DI ACCESSORI) -------------------
-------------------------------------------------------------------------------------

CREATE TABLE #rivalutazione_cespiti
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)

INSERT INTO #rivalutazione_cespiti
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idinventory,
	assetacquire.idmot,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset								ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization					ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetload				ON  assetamortization.idassetload = assetload.idassetload
JOIN inventory							ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization				ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorykind						ON inventory.idinventorykind= inventorykind.idinventorykind

WHERE  
	((assetacquire.flag & 1 = 0) OR assetacquire.idassetload IS NOT NULL)
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota > 0
	AND 
	(
		(
		 ((assetamortization.flag & 1 = 0) 
		  AND assetamortization.adate BETWEEN @firstday AND @date)
		  OR 
		  ((assetamortization.flag & 1 <> 0)
	           AND assetload.ratificationdate BETWEEN @firstday AND @date)
		)
	)	AND (inventory.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND ( (inventorykind.flag&2)=0)

GROUP BY inventory.idinventoryagency, assetacquire.idinv, assetacquire.idinventory,assetacquire.idmot

-------------------------------------------------------------------------------------
----- Rivalutazioni Negative ufficiali  (di CESPITI E DI ACCESSORI) -----------------
-------------------------------------------------------------------------------------
CREATE TABLE #svalutazione_cespiti
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)
INSERT INTO #svalutazione_cespiti
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idinventory,
	assetacquire.idmot,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset							ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization				ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload			ON  assetamortization.idassetunload = assetunload.idassetunload
JOIN inventory						ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind					ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization			ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
WHERE 
	((assetacquire.flag & 1 = 0) OR assetacquire.idassetload IS NOT NULL)
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
	AND (inventory.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND ( (inventorykind.flag&2)=0)

GROUP BY inventory.idinventoryagency,assetacquire.idinv, assetacquire.idinventory,assetacquire.idmot


--------------------------------------------------------------------------------------
-------------------------- Scarichi Cespiti e Accessori ------------------------------
--------------------------------------------------------------------------------------
CREATE TABLE #scaricocespiti
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)
INSERT INTO #scaricocespiti
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idinventory,
	assetacquire.idmot,
	ISNULL(	SUM(AC.currentvalue)	,0)
FROM assetacquire 
LEFT OUTER JOIN assetload				ON assetload.idassetload = assetacquire.idassetload
JOIN asset								ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC				on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetunload						ON assetunload.idassetunload = asset.idassetunload
JOIN inventory							ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind						ON inventory.idinventorykind = inventorykind.idinventorykind
WHERE  assetunload.yassetunload <= @ayear
	AND assetunload.adate BETWEEN @firstday AND @date		
	AND (inventory.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND ( (inventorykind.flag&2)=0)
GROUP BY inventory.idinventoryagency, assetacquire.idinv, assetacquire.idinventory, assetacquire.idmot



CREATE TABLE #cons_finale
(
	idinventoryagency int,
	descrinventoryagency varchar(150),
	idinv int,
	codesor1 varchar(50),
	nlevel1 tinyint,
	description1 varchar(150),
	start_cons decimal(19,2),
	cons_aum decimal(19,2),
	cons_dim decimal(19,2),
	dateend datetime,
	idassetvardetail int, 
	idinventory int,
	idmot int
)

INSERT INTO #cons_finale
(
	idinventoryagency,
	descrinventoryagency,
	idinv,
	codesor1,
	nlevel1,
	description1,
	dateend,
	idinventory,
	idmot
)
SELECT 
	inventoryagency.idinventoryagency,
	inventoryagency.description,
	inventorytree.idinv,
	inventorytree.codeinv,
	inventorytree.nlevel,
	inventorytree.description,
	@date,
	inventory.idinventory,
	#assetloadmotive.idmot
FROM inventorytree
CROSS JOIN inventoryagency
CROSS JOIN #assetloadmotive
JOIN inventory					ON inventoryagency.idinventoryagency = inventory.idinventoryagency
JOIN inventorykind				ON inventory.idinventorykind= inventorykind.idinventorykind
WHERE (@idinventoryagency IS NULL OR inventoryagency.idinventoryagency = @idinventoryagency)
	AND (@idinventoryagency IS NULL OR inventory.idinventoryagency = @idinventoryagency)
	AND ( (inventorykind.flag&2)=0)

INSERT INTO #cons_finale
(
	idinventoryagency,
	descrinventoryagency,
	idinv,
	codesor1,
	nlevel1,
	description1,
	dateend,
	idinventory,
	idmot
)
SELECT
	inventoryagency.idinventoryagency,
	inventoryagency.description,
	inventorytree.idinv,
	inventorytree.codeinv,
	inventorytree.nlevel,
	inventorytree.description,
	@date,
	null,
	#assetloadmotive.idmot
FROM inventorytree
CROSS JOIN inventoryagency
CROSS JOIN #assetloadmotive
WHERE (@idinventoryagency IS NULL OR inventoryagency.idinventoryagency = @idinventoryagency)
	
UPDATE #cons_finale
SET start_cons = 
ISNULL(
	(SELECT ISNULL(SUM(total),0)
	FROM #cons_iniziale
	WHERE #cons_iniziale.idinv = #cons_finale.idinv
		AND #cons_iniziale.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#cons_iniziale.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#cons_iniziale.idmot, 0) = ISNULL(#cons_finale.idmot, 0))
, 0)
UPDATE #cons_finale
SET cons_aum =
ISNULL(
	(SELECT total
	FROM #variazione_aum
	WHERE #variazione_aum.idinv = #cons_finale.idinv
		AND #variazione_aum.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#variazione_aum.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#variazione_aum.idmot, 0) = ISNULL(#cons_finale.idmot, 0))
, 0) +
ISNULL(
	(SELECT ISNULL(SUM(total),0)
        FROM #caricocespiti
        WHERE #caricocespiti.idinv = #cons_finale.idinv
	        AND #caricocespiti.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#caricocespiti.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#caricocespiti.idmot, 0) = ISNULL(#cons_finale.idmot, 0))
, 0) +
ISNULL(
	(SELECT total
	FROM #rivalutazione_cespiti
	WHERE #rivalutazione_cespiti.idinv = #cons_finale.idinv
		AND #rivalutazione_cespiti.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#rivalutazione_cespiti.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#rivalutazione_cespiti.idmot, 0) = ISNULL(#cons_finale.idmot, 0))
, 0)


UPDATE #cons_finale
SET cons_dim = 
-- var in diminuzioni patrimoniali
- ISNULL(
	(SELECT total
        FROM #variazione_dim
        WHERE #variazione_dim.idinv = #cons_finale.idinv
		AND #variazione_dim.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#variazione_dim.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#variazione_dim.idmot, 0) = ISNULL(#cons_finale.idmot, 0)
		)
, 0) +
ISNULL(
	(SELECT ISNULL(SUM(total),0)
        FROM #scaricocespiti
        WHERE #scaricocespiti.idinv = #cons_finale.idinv
		AND #scaricocespiti.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#scaricocespiti.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#scaricocespiti.idmot, 0) = ISNULL(#cons_finale.idmot, 0)
		)
, 0) 

 -
ISNULL(
	(SELECT total
	FROM #svalutazione_cespiti
	WHERE #svalutazione_cespiti.idinv = #cons_finale.idinv
		AND #svalutazione_cespiti.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#svalutazione_cespiti.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#svalutazione_cespiti.idmot, 0) = ISNULL(#cons_finale.idmot, 0)
)
, 0)

DECLARE @numvariazione int
DECLARE @idassetvar int

delete from #cons_finale where (#cons_finale.start_cons + #cons_finale.cons_aum - #cons_finale.cons_dim) = 0

--select * from #cons_finale

select
isnull((select count(*) from #cons_finale b
	where (b.idinv < #cons_finale.idinv)
	OR  
	(b.idinv = #cons_finale.idinv 
	and (isnull(b.idinventory,0) < isnull(#cons_finale.idinventory,0))
	)
	OR  
	(b.idinv = #cons_finale.idinv 
	and (isnull(b.idmot,0) < isnull(#cons_finale.idmot,0))
	and (isnull(b.idinventory,0) = isnull(#cons_finale.idinventory,0))
	)
	)  ,0) + 1 as 'count'
from #cons_finale

BEGIN TRANSACTION
	SET @numvariazione =
	ISNULL(
		(SELECT MAX(nvar)
		FROM assetvar
		WHERE yvar = @ayear + 1)
	, 0) + 1

	-- l'ID deve essere il MAX indipendentemente dall'esercizio
	SET @idassetvar = 
	ISNULL(
		(SELECT MAX(idassetvar)
		FROM assetvar)
	,0) + 1
 
	DECLARE @insertdate datetime
	SET @insertdate = CONVERT(datetime, '01-01-' + CONVERT(char(4), @ayear+1), 105)

	if (select count(*) from #cons_finale where #cons_finale.idinventoryagency = @idinventoryagency)<>0
	BEGIN
	INSERT assetvar (idassetvar, yvar, nvar, idinventoryagency, description, flag, adate, cu, ct, lu, lt)
	VALUES (@idassetvar, @ayear + 1, @numvariazione, @idinventoryagency,
	'Variazione iniziale', 0, @insertdate , 'APERTURA',
	GETDATE(), 'APERTURA', GETDATE())
	
	INSERT assetvardetail
	(
		idassetvar,
		idassetvardetail,
		idinv,
		amount,
		description,
		idinventory,
		idmot,
		cu,
		ct,
		lu,
		lt
	)
	SELECT
		@idassetvar, 
		isnull((select count(*) from #cons_finale b
		where (b.idinv < #cons_finale.idinv )
		OR  
		( b.idinv = #cons_finale.idinv 
		and (isnull(b.idinventory,0) < isnull(#cons_finale.idinventory,0)))
		OR
		( b.idinv = #cons_finale.idinv 
		and (isnull(b.idinventory,0) = isnull(#cons_finale.idinventory,0)) 
		and (isnull(b.idmot,0) < isnull(#cons_finale.idmot,0)) )
		) 
		,0) 
		+ 1,
		idinv,
		-- Qualcosa di nuovo qui al posto di rownum
		((start_cons + cons_aum - cons_dim)),
		'Consistenza Iniziale',
		idinventory,
		idmot,
		'APERTURA',
		GETDATE(),
		'''APERTURA''',
		GETDATE()
	FROM #cons_finale 
	-- ORDER BY idassetvardetail, codesor1
	END


	IF EXISTS(SELECT * FROM accountingyear WHERE ayear = @ayear + 1)  
	BEGIN
		INSERT INTO inventorysortingamortizationyear(
			idinventoryamortization,
			ayear,
			idinv,
			ct,
			cu,
			lt,
			lu,
			amortizationquota,
			idaccmotive,
			idaccmotiveunload
		)
		SELECT DISTINCT
		t1.idinventoryamortization,
		(@ayear + 1),
		t1.idinv,
		GETDATE(),
		'SA',
		GETDATE(),
		'''SA''',
		t1.amortizationquota,
		t1.idaccmotive,
		t1.idaccmotiveunload
		FROM inventorysortingamortizationyear t1
		JOIN inventoryamortization t
		ON t1.idinventoryamortization =	t.idinventoryamortization
		WHERE NOT EXISTS
			(SELECT * 
			FROM inventorysortingamortizationyear t2 
			WHERE t1.idinv = t2.idinv
			AND t1.idinventoryamortization = t2.idinventoryamortization
			AND t2.ayear = (@ayear + 1))
		AND t1.ayear = @ayear
		
	END
COMMIT TRANSACTION
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

