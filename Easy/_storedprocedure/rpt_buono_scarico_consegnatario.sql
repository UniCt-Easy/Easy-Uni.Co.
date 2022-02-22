
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_scarico_consegnatario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_scarico_consegnatario]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec rpt_buono_scarico_consegnatario 2014, 'I', 6, 1, 1, {d '2014-12-31'},'N'

CREATE PROCEDURE [rpt_buono_scarico_consegnatario]
(
	@ayear int,
	@printkind char(1),
	@idassetunloadkind int,
	@startassetunload int,
	@stopassetunload int,
	@printdate datetime,
	@official char(1)
)
AS BEGIN
	-- flagdiscount='S': si considera lo sconto
	-- flagdiscount='N': non si considera lo sconto
DECLARE @flagdiscount float  
IF (SELECT  TOP 1 (inventorykind.flag & 1) FROM inventorykind 
        JOIN inventory 
	ON inventory.idinventorykind= inventorykind.idinventorykind
	JOIN assetacquire 
	ON assetacquire.idinventory=inventory.idinventory
	JOIN assetunloadkind 
	ON assetunloadkind.idinventory=inventory.idinventory
	WHERE idassetunloadkind=@idassetunloadkind
	) <> 0
BEGIN
	SET @flagdiscount = 1
END
ELSE 
BEGIN
	SET @flagdiscount = 0
END

IF (@ayear<2005) SET @flagdiscount = 1 
-- Vengono considerate anche le rivalutazioni come variazioni sull'amount scaricato
-- Contiene i numeri di Buoni di Scarico da stampare
CREATE TABLE #printing (num int)

IF @printkind = 'A' 
	INSERT INTO #printing (num) 
	SELECT nassetunload from  assetunload  where (yassetunload=@ayear) and (printdate IS NULL) and (idassetunloadkind=@idassetunloadkind)
	
IF @printkind <> 'A'
	INSERT INTO #printing (num) 
	SELECT nassetunload from  assetunload where (yassetunload=@ayear) and (nassetunload BETWEEN @startassetunload AND @stopassetunload)
														 and (idassetunloadkind=@idassetunloadkind)
	

-----------------------------------------------------------------------------------------------
-- Valore degli accessori CARICATI collegati ai cespiti principali attualmente in scarico ----- 
-- Si considerano quelli inseriti in buoni di carico ------------------------------------------
-----------------------------------------------------------------------------------------------

--
--select 'pieceunloaded_load',* from #pieceunloaded_load
--------------------------------------------------------------------------------------
--Rivalutazioni / Svalutazioni dei cespiti e degli accessori attualmente in scarico --
--------------------------------------------------------------------------------------

CREATE TABLE #amortization
(
	idasset int,
	idpiece	int,
	amount decimal(19,2)
)

INSERT INTO #amortization
(
	idasset,
	idpiece,
	amount
)
SELECT
	asset.idasset,
	asset.idpiece,
	convert(decimal(19,2),SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)))
FROM assetamortization
JOIN asset							ON asset.idasset = assetamortization.idasset
										AND asset.idpiece = assetamortization.idpiece
JOIN inventoryamortization			ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN assetunload					ON asset.idassetunload = assetunload.idassetunload
WHERE 	ISNULL(assetamortization.amortizationquota,0) > 0
	AND (assetamortization.idassetload IS NOT NULL OR (assetamortization.flag & 1 = 0))
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)
GROUP BY asset.idasset,asset.idpiece

INSERT INTO #amortization
(
	idasset,
	idpiece,
	amount
)
SELECT
	asset.idasset,
	asset.idpiece,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetamortization
JOIN asset						ON asset.idasset = assetamortization.idasset
									AND asset.idpiece = assetamortization.idpiece
JOIN inventoryamortization		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN assetunload				ON  asset.idassetunload = assetunload.idassetunload
WHERE 	ISNULL(assetamortization.amortizationquota,0) < 0
	AND (inventoryamortization.flag & 2 <> 0)
	AND (assetamortization.idassetunload IS NOT NULL OR (assetamortization.flag & 1 = 0))
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)
GROUP BY asset.idasset,asset.idpiece



CREATE TABLE #reduction
(
	idasset int,
	amount decimal(23,6)
)
INSERT INTO #reduction
(
	idasset,
	amount
)
SELECT
	AMAIN.idasset,
	-AC.start
from assetacquire B
JOIN assetview A					on B.nassetacquire = A.nassetacquire
join assetview_current AC			on A.idasset=AC.idasset and A.idpiece=AC.idpiece	
JOIN asset AMAIN					ON AMAIN.idasset = A.idasset
										AND AMAIN.idpiece = 1
JOIN assetunload					ON AMAIN.idassetunload = assetunload.idassetunload
WHERE 	
	A.idpiece >1
	and   A.idassetunload IS NOT NULL
	and  ((B.flag & 1 <> 1) AND (B.flag & 2 <> 0))
	AND assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)



--select 'pieceunload_amortization',* from #pieceunloaded_amortization

CREATE TABLE #asset_unload
(
	idassetunloadkind int,
	yassetunload int,
	nassetunload int,
	idmot varchar(20),
	idinventoryagency int,
	idinventorykind int,
	qualification varchar(50),
	title varchar(150),
	doc varchar(35),
	docdate datetime,
	description varchar(150),
	enactment varchar(150),
	enactmentdate datetime,
	adate datetime,
	start_assetconsignee datetime,
	printdate datetime,
	operationorder int,
	kind varchar(50),
	idinventory int,
	idasset int,
	idpiece int,
	ninventory int,
	idinv int,
	assetdescription varchar(210),
	unitvalue decimal(23,2),
	nassetacquire int,
	txt text
)

--------------------------------------------------------------------------------------
--------------------------------Scarichi cespiti -------------------------------------
--------------------------------------------------------------------------------------	
INSERT INTO #asset_unload
(
	idassetunloadkind,
	yassetunload,
	nassetunload,
	idmot,
	idinventoryagency,
	idinventorykind,
	doc,
	docdate,
	description,
	enactment,
	enactmentdate,
	adate,
	printdate,
	operationorder,
	kind,
	idinventory,
	idasset,
	idpiece,	
	ninventory,
	idinv,
	assetdescription,
	unitvalue,
	nassetacquire
)
SELECT DISTINCT
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunload.idmot,
	inventory.idinventoryagency,
	inventory.idinventorykind,
	assetunload.doc,
	assetunload.docdate,
	assetunload.description,
	assetunload.enactment,
	assetunload.enactmentdate,
	assetunload.adate,
	assetunload.printdate,
	1,
	'Scarico bene',
	assetacquire.idinventory, 
	asset.idasset,
	asset.idpiece,
	asset.ninventory,
	assetacquire.idinv,
	assetacquire.description,
	AC.start,
	asset.nassetacquire
FROM assetunload
join asset								ON assetunload.idassetunload = asset.idassetunload
join assetview_current AC				on asset.idasset=AC.idasset and asset.idpiece=AC.idpiece			
JOIN assetacquire						ON asset.nassetacquire = assetacquire.nassetacquire
LEFT OUTER JOIN assetload				ON assetload.idassetload = assetacquire.idassetload
JOIN inventory							ON assetacquire.idinventory = inventory.idinventory	
WHERE asset.idpiece=1
	and assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)

--------------------------------------------------------------------------------------
--------------------------------Scarichi accessori -----------------------------------
--------------------------------------------------------------------------------------	
INSERT INTO #asset_unload
(
	idassetunloadkind,
	yassetunload,
	nassetunload,
	idmot,
	idinventoryagency,
	idinventorykind,
	doc,
	docdate,
	description,
	enactment,
	enactmentdate,
	adate,
	printdate,
	operationorder,
	kind,
	idinventory,
	idasset,
	idpiece,
	ninventory,
	idinv,
	assetdescription,
	unitvalue
)
SELECT
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunload.idmot,
	inventory.idinventoryagency,
	inventory.idinventorykind,
	assetunload.doc,
	assetunload.docdate,
	assetunload.description,
	assetunload.enactment,
	assetunload.enactmentdate,
	assetunload.adate,
	assetunload.printdate,
	2,
	'Scarico accessorio',
	assetacquire.idinventory, 
	asset.idasset,
	asset.idpiece,
	assetmain.ninventory,
	assetacquire.idinv,
	assetacquire.description,
	AC.start	
FROM assetacquire
JOIN asset									ON asset.nassetacquire = assetacquire.nassetacquire
join assetview_current AC					on asset.idasset=AC.idasset and asset.idpiece=AC.idpiece		
JOIN asset as assetmain						ON asset.idasset=assetmain.idasset
JOIN assetunload							ON assetunload.idassetunload = asset.idassetunload
JOIN inventory								ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryagency						ON inventoryagency.idinventoryagency = inventory.idinventoryagency
JOIN inventorykind							ON inventorykind.idinventorykind = inventory.idinventorykind
WHERE asset.idpiece>1
	and assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)
	AND assetmain.idpiece=1


--------------------------------------------------------------------------------------
--------------------------------Scarichi ammortamenti---------------------------------
--------------------------------------------------------------------------------------


INSERT INTO #asset_unload
(
	idassetunloadkind,
	yassetunload,
	nassetunload,
	idmot,
	idinventoryagency,
	idinventorykind,
	doc,
	docdate,
	description,
	enactment,
	enactmentdate,
	adate,
	printdate,
	operationorder,
	kind,
	idinventory,
	idasset,
	idpiece,	
	ninventory,
	idinv,
	assetdescription,
	unitvalue ,
	nassetacquire
)
SELECT DISTINCT
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunload.idmot,
	inventory.idinventoryagency,
	inventory.idinventorykind,
	assetunload.doc,
	assetunload.docdate,
	assetunload.description,
	assetunload.enactment,
	assetunload.enactmentdate,
	assetunload.adate,
	assetunload.printdate,
	3,
	'Ammortamento cespite',
	assetacquire.idinventory, 
	asset.idasset,
	asset.idpiece,
	asset.ninventory,
	assetacquire.idinv,
	inventoryamortization.description + ' n. '+ convert(varchar(4),namortization) + char(13) + assetamortization.description,
	ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2),
	assetamortization.namortization
FROM assetunload
JOIN assetamortization							ON assetunload.idassetunload = assetamortization.idassetunload
JOIN inventoryamortization						ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset										ON asset.idasset = assetamortization.idasset
													AND asset.idpiece = assetamortization.idpiece
JOIN assetacquire								ON asset.nassetacquire = assetacquire.nassetacquire
JOIN inventory									ON assetacquire.idinventory = inventory.idinventory	
WHERE 	asset.idpiece = 1 
	AND assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)

INSERT INTO #asset_unload
(
	idassetunloadkind,
	yassetunload,
	nassetunload,
	idmot,
	idinventoryagency,
	idinventorykind,
	doc,
	docdate,
	description,
	enactment,
	enactmentdate,
	adate,
	printdate,
	operationorder,
	kind,
	idinventory,
	idasset,
	idpiece,	
	ninventory,
	idinv,
	assetdescription,
	unitvalue ,
	nassetacquire
)
SELECT DISTINCT
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunload.idmot,
	inventory.idinventoryagency,
	inventory.idinventorykind,
	assetunload.doc,
	assetunload.docdate,
	assetunload.description,
	assetunload.enactment,
	assetunload.enactmentdate,
	assetunload.adate,
	assetunload.printdate,
	4,
	'Ammortamento accessorio',
	assetacquire.idinventory, 
	asset.idasset,
	asset.idpiece,
	assetcespite.ninventory,
	assetacquire.idinv,
	inventoryamortization.description + ' n. '+ convert(varchar(4),namortization) + char(13) + assetamortization.description,
	ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2),
	assetamortization.namortization
FROM assetunload
JOIN assetamortization						ON assetunload.idassetunload = assetamortization.idassetunload
JOIN inventoryamortization					ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset									ON asset.idasset = assetamortization.idasset
													AND asset.idpiece = assetamortization.idpiece
JOIN asset AS assetcespite					ON asset.idasset = assetcespite.idasset
JOIN assetacquire							ON asset.nassetacquire = assetacquire.nassetacquire
JOIN inventory
	ON assetacquire.idinventory = inventory.idinventory	
WHERE 	asset.idpiece >1 AND assetcespite.idpiece = 1 
	AND assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)


UPDATE #asset_unload
SET start_assetconsignee =
	(SELECT MAX(start) FROM assetconsignee 
	WHERE idinventoryagency = #asset_unload.idinventoryagency
	AND start <= #asset_unload.adate)

UPDATE #asset_unload
	SET txt = assetunload.txt 
		FROM assetunload
		JOIN #asset_unload			ON assetunload.yassetunload = #asset_unload.yassetunload
										AND assetunload.nassetunload = #asset_unload.nassetunload
										AND assetunload.idassetunloadkind = #asset_unload.idassetunloadkind



	
IF @official = 'S'
	UPDATE #asset_unload
	SET printdate = @printdate
	WHERE yassetunload = @ayear 
	AND nassetunload IN (SELECT num from #printing)
	AND printdate IS NULL

-------------------------------------------------------------------------------------------------
--1. Variazioni del cespite scaricato
--   + Valore accessori CARICATI legati al cespite  
--   + Rivalutazioni positive e negative del cespite
--   + Rivalutazioni positive e negative di tutti gli accessori CARICATI collegati
--   - Valore accessori SCARICATI legati al cespite, presenti in questo o altri buoni di scarico
--   - Rivalutazioni positive e negative di accessori SCARICATI legati al cespite, 
--     presenti in questo o in altri buoni di scarico
--------------------------------------------------------------------------------------------------
--2. Variazioni dell' accessorio scaricato
--   + Rivalutazioni positive e negative dell'accessorio
--------------------------------------------------------------------------------------------------

SELECT 
	#asset_unload.idassetunloadkind,
	yassetunload,
	nassetunload,
	#asset_unload.idmot ,
	MOTIVE.description as assetunloadmotive ,
	#asset_unload.idinventoryagency,
	AGENCY.description as inventoryagency,
	#asset_unload.idinventorykind,
	INVKIND.description as inventorykind,
	assetconsignee.qualification,
	assetconsignee.title ,
	doc,
	docdate,
	#asset_unload.description, 
	enactment,
	enactmentdate,
	adate,
	start_assetconsignee,
	printdate,
	operationorder,
	kind,
	#asset_unload.idinventory,
	idasset,
	idpiece,
	ninventory,
	#asset_unload.idinv ,
	inventory.codeinventory,
	inventorytree.codeinv, 
	assetdescription,
	unitvalue,
	nassetacquire,
	nassetacquire ,
	CASE #asset_unload.kind 
		WHEN  'Scarico bene' THEN
			ISNULL((SELECT SUM(amount)
				FROM  #reduction
				WHERE #reduction.idasset = #asset_unload.idasset),0) 
			+
			ISNULL((SELECT SUM(amount)
				FROM   #amortization
				WHERE  #amortization.idasset = #asset_unload.idasset
				AND    #amortization.idpiece   = #asset_unload.idpiece),0) 	
		WHEN  'Scarico accessorio' THEN
			ISNULL((SELECT SUM(amount) FROM #amortization
				WHERE  #amortization.idasset = #asset_unload.idasset
				AND    #amortization.idpiece = #asset_unload.idpiece),0) 
		ELSE 0
	END as amortization, 
	#asset_unload.txt,
	AGENCY.title_l,   -- sezione firme
	AGENCY.name_l,
	AGENCY.title_c,
	AGENCY.name_c,
	AGENCY.title_r,
	AGENCY.name_r
FROM #asset_unload					
JOIN inventorytree							ON inventorytree.idinv = #asset_unload.idinv
JOIN inventory								on #asset_unload.idinventory = inventory.idinventory
LEFT OUTER  JOIN assetconsignee				ON assetconsignee.idinventoryagency = #asset_unload.idinventoryagency
												AND assetconsignee.start = #asset_unload.start_assetconsignee
LEFT OUTER JOIN assetunloadmotive MOTIVE	ON #asset_unload.idmot = MOTIVE.idmot
LEFT OUTER JOIN inventoryagency AGENCY		ON #asset_unload.idinventoryagency = AGENCY.idinventoryagency
LEFT OUTER JOIN inventorykind INVKIND		ON #asset_unload.idinventorykind = INVKIND.idinventorykind  
ORDER BY nassetunload,ninventory,operationorder
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

