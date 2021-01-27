
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitpatrim_assetsubmanager]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitpatrim_assetsubmanager]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--exec rpt_sitpatrim_assetsubmanager 2010,null,'31-12-2010' ,null

CREATE    PROCEDURE [rpt_sitpatrim_assetsubmanager]
	@year int,
	@codinventoryagency int=null,
	@date datetime=null,
	@idmanager int,  -- responsabile consegnatario del cespite
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null 
AS BEGIN
DECLARE @firstday datetime
DECLARE @lastday datetime

SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)
set @lastday = CONVERT(datetime, '31-12-' + CONVERT(char(4),@year), 105)
if (@date is null) SET @date = @lastday
if (@date>@lastday) set @date = @lastday


CREATE TABLE #patrimonio
(
	codinventoryagency int,
	idmanager int,
	idinv int,
	description varchar(150),
	initial_amount decimal(19,2),
	assetvar_aum decimal(19,2),
	assetvar_dim decimal(19,2),
	var_aum decimal(19,2),
	var_dim decimal(19,2)
)

INSERT INTO #patrimonio
(codinventoryagency,idmanager,idinv,description)
SELECT ENTE.idinventoryagency,manager.idman, CLASS.idinv,CLASS.description
FROM inventorytree CLASS 
CROSS JOIN inventoryagency ENTE
CROSS JOIN manager
WHERE CLASS.nlevel = 1
AND ((manager.idman = @idmanager AND @idmanager IS NOT NULL)  OR (@idmanager IS NULL))
AND (@idsor01 IS NULL OR manager.idsor01 = @idsor01)
AND (@idsor02 IS NULL OR manager.idsor02 = @idsor02)
AND (@idsor03 IS NULL OR manager.idsor03 = @idsor03)
AND (@idsor04 IS NULL OR manager.idsor04 = @idsor04)
AND (@idsor05 IS NULL OR manager.idsor05 = @idsor05)
AND (ENTE.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
AND (ENTE.active = 'S'						---Prende in considerazione le strutture attive o quelle inattive che abbiano una variazione nell'anno relativo alla stampa
	OR (ENTE.active = 'N' AND (SELECT COUNT(*) from assetvar AV
									JOIN assetvardetail AVD
										ON AV.idassetvar = AVD.idassetvar
									JOIN inventory I
										ON AVD.idinventory = I.idinventory
									JOIN inventoryagency IA
										ON I.idinventoryagency = IA.idinventoryagency
								WHERE AVD.amount > 0
								AND datepart(yy,AV.adate) = @year
								AND ENTE.idinventoryagency = IA.idinventoryagency
								) >0
		)
	)


CREATE TABLE #tempdata(	idente int, idmanager int, myid int, valore decimal(19,2))
	
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
WHERE (assetvar.flag & 1 = 0)
	AND assetvar.yvar = @year
	AND assetvar.adate <= @date
	AND assetvar.idinventoryagency = #patrimonio.codinventoryagency
	AND inventorytreelink.idparent = #patrimonio.idinv
	AND inventorytreelink.nlevel = 1),0)

-------------------------------------------------------------------------------------
-------------------------- Variazioni sit. patrim. ----------------------------------
-------------------------------------------------------------------------------------
UPDATE #patrimonio SET assetvar_aum =	
ISNULL(
(SELECT	SUM(assetvardetail.amount)
FROM assetvardetail
JOIN assetvar
	ON assetvar.idassetvar = assetvardetail.idassetvar
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetvardetail.idinv
WHERE (assetvar.flag & 1 <> 0)
	AND assetvar.yvar = @year
	AND assetvar.adate <= @date
	AND assetvardetail.amount > 0
	AND assetvar.idinventoryagency = #patrimonio.codinventoryagency
	AND inventorytreelink.idparent = #patrimonio.idinv
	AND inventorytreelink.nlevel = 1),0)


UPDATE #patrimonio SET assetvar_dim =	
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
	AND assetvar.idinventoryagency = #patrimonio.codinventoryagency
	AND inventorytreelink.idparent = #patrimonio.idinv
	AND inventorytreelink.nlevel = 1),0)
	
-------------------------------------------------------------------------------------
-------------------------- Carichi cespiti E accessori -------------------------------
-------------------------------------------------------------------------------------
INSERT INTO #tempdata(idente,idmanager, myid,valore)
SELECT
	inventory.idinventoryagency,
	manager.idman,
	inventorytreelink.idparent,
	sum(AC.start)
FROM assetacquire 
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC	on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece
JOIN assetload				ON assetload.idassetload = assetacquire.idassetload
JOIN inventory				ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind			ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventorytreelink		ON inventorytreelink.idchild = assetacquire.idinv
LEFT OUTER JOIN assetsubmanager ON assetsubmanager.idasset = asset.idasset 
LEFT OUTER JOIN manager ON 	assetsubmanager.idmanager = manager.idman
WHERE inventorytreelink.nlevel = 1
	AND assetload.yassetload <= @year  
	AND assetload.ratificationdate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL)
	AND ( (inventorykind.flag&2)=0)
	AND ((assetsubmanager.idmanager = @idmanager) OR (@idmanager is null and assetsubmanager.idmanager is not null))
	AND (@idsor01 IS NULL OR manager.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR manager.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR manager.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR manager.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR manager.idsor05 = @idsor05)
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent,manager.idman

	
UPDATE #patrimonio SET var_aum = ISNULL(var_aum,0) +
ISNULL( 
	(SELECT SUM(valore) 
	   FROM #tempdata 
	  WHERE idente = #patrimonio.codinventoryagency 
	    AND myid=#patrimonio.idinv
	    AND idmanager=#tempdata.idmanager
)
,0)


DELETE FROM #tempdata

	
UPDATE #patrimonio SET var_aum= ISNULL(var_aum,0) +
ISNULL( 
	(SELECT SUM(valore) FROM #tempdata 
	WHERE idente = #patrimonio.codinventoryagency 
	AND myid=#patrimonio.idinv
	AND idmanager=#tempdata.idmanager
	)
,0)

DELETE FROM #tempdata

-------------------------------------------------------------------------------------
----- Rivalutazioni positive ufficiali (di BENI E DI ACCESSORI) ---------------------
-------------------------------------------------------------------------------------
INSERT INTO #tempdata(idente, idmanager, myid,valore)
SELECT
	inventory.idinventoryagency,
	manager.idman,
	inventorytreelink.idparent,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset						ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization			ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetload		ON  assetamortization.idassetload = assetload.idassetload
JOIN inventory					ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind				ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink			ON inventorytreelink.idchild = assetacquire.idinv
LEFT OUTER JOIN assetsubmanager ON assetsubmanager.idasset = asset.idasset 
LEFT OUTER JOIN manager ON 	assetsubmanager.idmanager = manager.idman
WHERE inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota >= 0
	AND 
	(
		(
		 ((assetamortization.flag & 1 = 0)
		  AND assetamortization.adate BETWEEN @firstday AND @date) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)
                   AND assetload.ratificationdate BETWEEN @firstday AND @date)
		)
	)
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
	AND ( (inventorykind.flag&2)=0)
	AND ((assetsubmanager.idmanager = @idmanager) OR (@idmanager is null and assetsubmanager.idmanager is not null))
	AND (@idsor01 IS NULL OR manager.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR manager.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR manager.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR manager.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR manager.idsor05 = @idsor05)
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent,manager.idman

UPDATE #patrimonio SET var_aum= ISNULL(var_aum,0) +
ISNULL( 
	(SELECT SUM(valore) FROM #tempdata 
	  WHERE idente = #patrimonio.codinventoryagency 
	    AND myid=#patrimonio.idinv
	    AND idmanager=#tempdata.idmanager
)
,0)

DELETE FROM #tempdata

-------------------------------------------------------------------------------------
-------- Rivalutazioni Negative ufficiali  (di BENI E DI ACCESSORI)
-------------------------------------------------------------------------------------
INSERT INTO #tempdata(idente,idmanager, myid,valore)
SELECT
	inventory.idinventoryagency,
	manager.idman,
	inventorytreelink.idparent,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire				
JOIN asset						ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization			ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload		ON  assetamortization.idassetunload = assetunload.idassetunload
JOIN inventory					ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind				ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink			ON inventorytreelink.idchild = assetacquire.idinv
LEFT OUTER JOIN assetsubmanager	ON assetsubmanager.idasset = asset.idasset 
LEFT OUTER JOIN manager ON 	assetsubmanager.idmanager = manager.idman
WHERE   inventorytreelink.nlevel = 1
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
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
	AND ( (inventorykind.flag&2)=0)
	AND ((assetsubmanager.idmanager = @idmanager) OR (@idmanager is null and assetsubmanager.idmanager is not null))
	AND (@idsor01 IS NULL OR manager.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR manager.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR manager.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR manager.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR manager.idsor05 = @idsor05)
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent,manager.idman

UPDATE #patrimonio SET var_dim= ISNULL(var_dim,0) -
	ISNULL( 
		(SELECT SUM(valore) FROM #tempdata 
		WHERE idente = #patrimonio.codinventoryagency 
		  AND myid=#patrimonio.idinv
		  AND idmanager=#tempdata.idmanager
)
	,0)

DELETE FROM #tempdata

-------------------------------------------------------------------------------------
-------------------------- Scarichi Cespite E accessori------------------------------------------
-----------------------------------------------------------------------------------

INSERT INTO #tempdata(idente,idmanager, myid,valore)
SELECT
	inventory.idinventoryagency,
	manager.idman,
	inventorytreelink.idparent,
	sum(AC.currentvalue)
FROM assetacquire			
LEFT OUTER JOIN assetload				ON assetload.idassetload = assetacquire.idassetload
JOIN asset								ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current	AC				on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetunload						ON assetunload.idassetunload = asset.idassetunload
JOIN inventory							ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind						ON inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventorytreelink					ON inventorytreelink.idchild = assetacquire.idinv
LEFT OUTER JOIN assetsubmanager			ON assetsubmanager.idasset = asset.idasset 
LEFT OUTER JOIN manager					ON 	assetsubmanager.idmanager = manager.idman
WHERE inventorytreelink.nlevel = 1
	AND assetunload.yassetunload <= @year
	AND assetunload.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )	
	AND ( (inventorykind.flag&2)=0)
	AND ((assetsubmanager.idmanager = @idmanager) OR (@idmanager is null and assetsubmanager.idmanager is not null))
	AND (@idsor01 IS NULL OR manager.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR manager.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR manager.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR manager.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR manager.idsor05 = @idsor05)
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent,manager.idman


UPDATE #patrimonio SET var_dim= ISNULL(var_dim,0) +
ISNULL( 
	(SELECT SUM(valore) FROM #tempdata 
	WHERE idente=#patrimonio.codinventoryagency 
	AND myid=#patrimonio.idinv
	AND idmanager=#tempdata.idmanager
	)
,0)

DELETE FROM #tempdata

--DECLARE @MostraAvanzoCassa char(1)
--SELECT  @MostraAvanzoCassa = isnull(paramvalue,'N')
--FROM    reportadditionalparam
--WHERE   paramname = 'MostraAvanzoCassa' and reportname='situazionepatrim_ente_consegnatario'

--IF (Upper(@MostraAvanzoCassa)='S')
--Begin
--	DECLARE @startfloatfund decimal(19,2)
--	DECLARE @aumfloatfund decimal(19,2)
--	DECLARE @dimfloatfund decimal(19,2)

--	SELECT 
--		@startfloatfund = ISNULL(startfloatfund, 0.0),
--	        @aumfloatfund = ISNULL(competencyproceeds, 0.0) + ISNULL(residualproceeds, 0.0),
--	        @dimfloatfund = ISNULL(competencypayments, 0.0) + ISNULL(residualpayments, 0.0)
--	FROM surplus
--	WHERE ayear = @year
	
--	INSERT INTO #patrimonio (idinv, description, initial_amount, assetvar_aum, assetvar_dim)
--	VALUES('9999','Avanzo di cassa', @startfloatfund, @aumfloatfund, @dimfloatfund)
--End

SELECT 
	ENTE.codeinventoryagency AS 'codinventoryagency',
	ENTE.description as 'descinventoryagency',
	manager.idman as 'idman',
	manager.title as 'manager',
	#patrimonio.idinv,
	CLASS.codeinv as 'codesor',
	CLASS.nlevel,
	#patrimonio.description,
	ISNULL(SUM(initial_amount),0) as 'initialamount',
	ISNULL(SUM(assetvar_aum),0) as 'assetvaramountimprove',
	ISNULL(SUM(assetvar_dim),0) as 'assetvaramountdecrease',
	ISNULL(SUM(var_aum),0) as 'amountimprove',
	ISNULL(SUM(var_dim),0) as 'amountdecrease',
	@date as 'stop'
FROM #patrimonio
LEFT OUTER JOIN inventorytree CLASS 
	ON CLASS.idinv = #patrimonio.idinv
LEFT OUTER JOIN inventoryagency	ENTE
	ON ENTE.idinventoryagency = #patrimonio.codinventoryagency
LEFT OUTER JOIN manager	 
	ON manager.idman = #patrimonio.idmanager
GROUP BY ENTE.codeinventoryagency, ENTE.description,#patrimonio.idinv,
	 CLASS.codeinv, CLASS.nlevel,#patrimonio.description,	manager.idman,	manager.title
HAVING (ISNULL(SUM(var_aum),0)) > 0 AND (ISNULL(SUM(var_dim),0)) > 0 
ORDER BY  ENTE.codeinventoryagency,manager.title, codesor
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
