
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitpatrim_ente_po]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitpatrim_ente_po]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--exec rpt_sitpatrim_ente_po 2010,1,'31-12-2010','N'
CREATE    PROCEDURE [rpt_sitpatrim_ente_po]
(
	@year int,
	@codinventoryagency int,
	@date datetime,
	@showmotive char(1)
)
AS BEGIN
DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)

CREATE TABLE #patrimonio
(
	codinventoryagency int,
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
	
INSERT INTO #patrimonio
(codinventoryagency,idsor,description,idmot)
SELECT ENTE.idinventoryagency,CLASS.idinv,CLASS.description,MOTIVE.idmot
FROM inventorytree CLASS 
CROSS JOIN inventoryagency ENTE
CROSS JOIN #assetloadmotive MOTIVE
WHERE CLASS.nlevel = 1
AND (@codinventoryagency IS NULL OR ENTE.idinventoryagency = @codinventoryagency)

CREATE TABLE #tempdata(	idente int, myid int, idmot int, valore decimal(19,2))
	
-------------------------------------------------------------------------------------
-------------------------- Situazione patrim. iniziale-------------------------------
-------------------------------------------------------------------------------------
UPDATE #patrimonio SET initial_amount =
ISNULL((SELECT SUM(assetvardetail.amount)
FROM assetvardetail
JOIN assetvar
	ON assetvar.idassetvar = assetvardetail.idassetvar
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetvardetail.idinv
WHERE (assetvar.flag & 1 <> 1)
	AND assetvar.yvar = @year
	AND assetvar.adate <= @date
	AND ISNULL(assetvardetail.idmot,'') = ISNULL(#patrimonio.idmot,'')
	AND assetvar.idinventoryagency = #patrimonio.codinventoryagency
	AND inventorytreelink.idparent = #patrimonio.idsor
	AND inventorytreelink.nlevel = 1),0)
	
-------------------------------------------------------------------------------------
-------------------------- Variazioni sit. patrim. ----------------------------------
-------------------------------------------------------------------------------------
UPDATE #patrimonio SET var_aum =
ISNULL(
(SELECT SUM(assetvardetail.amount)
FROM assetvardetail
JOIN assetvar
	ON assetvar.idassetvar = assetvardetail.idassetvar
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetvardetail.idinv
WHERE (assetvar.flag & 1 <> 0)
	AND assetvar.yvar = @year
	AND assetvar.adate <= @date
	AND assetvardetail.amount > 0
	AND ISNULL(assetvardetail.idmot,'') = ISNULL(#patrimonio.idmot,'')
	AND assetvar.idinventoryagency = #patrimonio.codinventoryagency
	AND inventorytreelink.idparent = #patrimonio.idsor
	AND inventorytreelink.nlevel = 1),0)

UPDATE #patrimonio SET var_dim =	
- ISNULL(
(SELECT SUM(assetvardetail.amount)
FROM assetvardetail
JOIN assetvar
	ON assetvar.idassetvar = assetvardetail.idassetvar
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetvardetail.idinv
WHERE (assetvar.flag & 1 <> 0)
	AND assetvar.yvar = @year
	AND assetvar.adate <= @date
	AND assetvardetail.amount < 0
	AND ISNULL(assetvardetail.idmot,'') = ISNULL(#patrimonio.idmot,'')
	AND assetvar.idinventoryagency = #patrimonio.codinventoryagency
	AND inventorytreelink.idparent = #patrimonio.idsor
	AND inventorytreelink.nlevel = 1),0)
	
-------------------------------------------------------------------------------------
-------------------------- Carichi cespiti  -------------------------------
-------------------------------------------------------------------------------------
INSERT INTO #tempdata(idente,myid,idmot,valore)
SELECT
	inventory.idinventoryagency,
	inventorytreelink.idparent,
	assetacquire.idmot,
	sum(AC.start)
FROM assetacquire 
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN inventory
	ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
WHERE inventorytreelink.nlevel = 1
	AND assetload.yassetload <= @year  
	AND assetload.ratificationdate BETWEEN @firstday AND @date
	AND (@codinventoryagency IS NULL OR inventory.idinventoryagency = @codinventoryagency)
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot

	
UPDATE #patrimonio SET var_aum = ISNULL(var_aum,0) +
ISNULL( 
	(SELECT SUM(valore) FROM #tempdata 
	 WHERE idente = #patrimonio.codinventoryagency 
	   AND myid=#patrimonio.idsor
	   AND ISNULL(idmot,'') = ISNULL(#patrimonio.idmot,'')
	)
,0)

DELETE FROM #tempdata

-------------------------------------------------------------------------------------
----- Rivalutazioni positive ufficiali (di BENI E DI ACCESSORI) ---------------------
-------------------------------------------------------------------------------------
INSERT INTO #tempdata(idente,myid,idmot,valore)
SELECT
	inventory.idinventoryagency,
	inventorytreelink.idparent,
	assetacquire.idmot,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization
	ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
WHERE inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota >= 0
	AND assetamortization.adate BETWEEN @firstday AND @date
	AND (@codinventoryagency IS NULL OR inventory.idinventoryagency = @codinventoryagency)
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot

UPDATE #patrimonio SET var_aum= ISNULL(var_aum,0) +
ISNULL( 
	(SELECT SUM(valore) FROM #tempdata 
	WHERE idente = #patrimonio.codinventoryagency 
	AND myid=#patrimonio.idsor
	AND ISNULL(idmot,'') = ISNULL(#patrimonio.idmot,'')
	)
,0)

DELETE FROM #tempdata

-------------------------------------------------------------------------------------
-------- Rivalutazioni Negative ufficiali  (di BENI E DI ACCESSORI) -----------------
-------------------------------------------------------------------------------------
INSERT INTO #tempdata(idente,myid,idmot,valore)
SELECT
	inventory.idinventoryagency,
	inventorytreelink.idparent,
	assetacquire.idmot,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization
	ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload
	ON  assetamortization.idassetunload = assetunload.idassetunload
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
WHERE  inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0 AND
	(
		(
		 ((assetamortization.flag & 1 <> 1)
		  AND assetamortization.adate BETWEEN @firstday AND @date) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)
                   AND assetunload.adate BETWEEN @firstday AND @date)
		)
	)
	--AND assetamortization.adate <= @date
	--AND assetamortization.adate >= @firstday
	AND (@codinventoryagency IS NULL OR inventory.idinventoryagency = @codinventoryagency)
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot

UPDATE #patrimonio SET amortization= ISNULL(amortization,0) -
ISNULL( 
	(SELECT SUM(valore) from #tempdata 
	where idente=#patrimonio.codinventoryagency 
	and myid=#patrimonio.idsor
	AND ISNULL(idmot,'') = ISNULL(#patrimonio.idmot,'')
	)
,0)

DELETE FROM #tempdata


-------------------------------------------------------------------------------------
-------------------------- Scarichi Cespiti E Accessori ------------------------------------------
-----------------------------------------------------------------------------------

INSERT INTO #tempdata(idente,myid,idmot,valore)
SELECT
	inventory.idinventoryagency,
	inventorytreelink.idparent,
	assetacquire.idmot,
	sum(AC.currentvalue)
FROM assetacquire
LEFT OUTER JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetunload
	ON assetunload.idassetunload = asset.idassetunload
JOIN inventory
	ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind
	on inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
WHERE inventorytreelink.nlevel = 1
	AND assetunload.yassetunload <= @year
	AND assetunload.adate BETWEEN @firstday AND @date
	AND (@codinventoryagency IS NULL OR inventory.idinventoryagency = @codinventoryagency)
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot

UPDATE #patrimonio SET var_dim= isnull(var_dim,0) +
ISNULL( 
	(SELECT SUM(valore) from #tempdata 
	where idente=#patrimonio.codinventoryagency 
	and myid=#patrimonio.idsor
	and ISNULL(idmot,'') = ISNULL(#patrimonio.idmot,'')
	)
,0)
DELETE FROM #tempdata



IF (@showmotive = 'S')
BEGIN
	DELETE FROM #patrimonio 
	WHERE  #patrimonio.idmot IS NULL 
	AND    ISNULL(initial_amount,0) = 0
	AND    ISNULL(var_aum,0) = 0 
	AND    ISNULL(var_dim,0) = 0
	AND    ISNULL(amortization,0) = 0

	SELECT 
		ENTE.codeinventoryagency AS 'codinventoryagency',
		ENTE.description AS 'descinventoryagency',
		#patrimonio.idsor,
		CLASS.codeinv AS 'codesor',
		CLASS.nlevel,
		MOTIVE.idmot,
		MOTIVE.description as 'motive',
		#patrimonio.description,
		initial_amount AS 'initialamount',
		var_aum AS 'amountimprove',
		var_dim AS 'amountdecrease',
		amortization,
		@date AS 'stop'
	FROM #patrimonio
	LEFT OUTER JOIN inventorytree CLASS 
		ON CLASS.idinv=#patrimonio.idsor
	LEFT OUTER JOIN inventoryagency	ENTE
		ON ENTE.idinventoryagency = #patrimonio.codinventoryagency
	LEFT OUTER JOIN #assetloadmotive	MOTIVE
		ON MOTIVE.idmot = ISNULL(#patrimonio.idmot,0)
	ORDER BY codesor
END
ELSE
BEGIN
	SELECT 
		ENTE.codeinventoryagency AS 'codinventoryagency',
		ENTE.description AS 'descinventoryagency',
		#patrimonio.idsor,
		CLASS.codeinv AS 'codesor',
		CLASS.nlevel,
		null as 'idmot',
		null as 'motive',
		#patrimonio.description,
		ISNULL(SUM(initial_amount),0) AS 'initialamount',
		ISNULL(SUM(var_aum),0) AS 'amountimprove',
		ISNULL(SUM(var_dim),0) AS 'amountdecrease',
		ISNULL(SUM(amortization),0) AS 'amortization',
		@date AS 'stop'
	FROM #patrimonio
	LEFT OUTER JOIN inventorytree CLASS 
		ON CLASS.idinv=#patrimonio.idsor
	LEFT OUTER JOIN inventoryagency	ENTE
		ON ENTE.idinventoryagency = #patrimonio.codinventoryagency
	GROUP BY ENTE.codeinventoryagency, ENTE.description, #patrimonio.idsor,
	CLASS.codeinv, CLASS.nlevel, #patrimonio.description
	ORDER BY codesor
END
END









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

