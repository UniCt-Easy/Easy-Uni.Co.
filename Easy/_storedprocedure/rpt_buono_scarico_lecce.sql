
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_scarico_lecce]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_scarico_lecce]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [rpt_buono_scarico_lecce]
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
--	exec rpt_buono_scarico_lecce 2014, 'I', 6, 1, 1, {ts '2014-10-25 00:00:00'}, 'N' 


DECLARE @flagdiscount float  
IF (SELECT  TOP 1 (inventorykind.flag & 1)
	FROM inventorykind 
	JOIN inventory				ON inventory.idinventorykind= inventorykind.idinventorykind
	JOIN assetacquire			ON assetacquire.idinventory=inventory.idinventory
	JOIN assetunloadkind		ON assetunloadkind.idinventory=inventory.idinventory
	WHERE idassetunloadkind=@idassetunloadkind
	)<> 0
BEGIN
	SET @flagdiscount = 1 
END
ELSE 
BEGIN
	SET @flagdiscount = 0
END
	
IF (@ayear<2005) SET @flagdiscount = 1 
-- Contiene i numeri di Buoni di Scarico da stampare
CREATE TABLE #printing (num int)

IF @printkind = 'A' 
	INSERT INTO #printing (num) 
	SELECT nassetunload from  assetunload  where (yassetunload=@ayear) and (printdate IS NULL) and (idassetunloadkind=@idassetunloadkind)
	
IF @printkind <> 'A'
	INSERT INTO #printing (num) 
	SELECT nassetunload from  assetunload where (yassetunload=@ayear) and (nassetunload BETWEEN @startassetunload AND @stopassetunload)
															 and (idassetunloadkind=@idassetunloadkind)

------------------------------------------------------------------------------------------------------------------------
-- CODIFICA DI typeoperation
-- CP : Riga relativa al valore Cespite Principale Scaricato																	(1)

-- AC : Riga relativa al valore dell'accessorio appartenente al Cespite Principale Scaricato									(4)
--> DA RIMUOVERE

-- AS : Riga relativa al valore dell'accessorio scaricato appartenente al Cespite Principale Scaricato "NUOVA ACQUISIZIONE"		(3)
---> DA RIMUOVERE

-- AP : Riga relativa al valore dell'accessorio scaricato appartenente al Cespite Principale Scaricato "POSSEDUTO"				(3)
--> VA BENE

-- SA : Riga relativa al valore dello scarico dell'accessorio appartenente al Cespite Principale scaricato						(2)

-- AM : Riga relativa all'ammortamento
-- AA : Ammortamenti degli accessori
-- RA : Rivalutazione Accessori
-- DA : Svalutazioni Accessori
-- RD : Rivalutazioni Accessori Scaricati
-- DD : Svalutazioni Accessori Scaricati
-- SV : Scarico Ammortamenti
--- 'AM' 'AA'  'RA'  'DA'  'RD'  'DD'  'SV'  sono trattati dal report come "amortization"
------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------
-- Valore degli accessori CARICATI collegati ai cespiti principali attualmente in scarico ----- 
-- Si considerano quelli inseriti in buoni di carico ------------------------------------------
-----------------------------------------------------------------------------------------------

CREATE TABLE #pieceloaded_load
(
	idasset int,
	idpiece	int,
	amount  decimal(23,6),
	typeoperation varchar(2),
	nassetunload int,
	yassetunload int
)

INSERT INTO #pieceloaded_load
(
	idasset,
	idpiece,
	amount,
	typeoperation,
	nassetunload,
	yassetunload
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
	SUM(
	ROUND(ISNULL(caricoaccessorio.taxable, 0)
	* (1 - CONVERT(decimal(19,6),ISNULL(caricoaccessorio.discount, 0))),2)
	+ ROUND(ISNULL(caricoaccessorio.tax,0) / caricoaccessorio.number,2)
	- ROUND(ISNULL(caricoaccessorio.abatable,0) / caricoaccessorio.number,2)),
	'AC',
	assetunloadaccessorio.nassetunload,
	assetunloadaccessorio.yassetunload
FROM   assetacquire as caricoaccessorio
JOIN   asset as assetaccessorio					ON caricoaccessorio.nassetacquire = assetaccessorio.nassetacquire
JOIN asset as assetcespite						ON assetcespite.idasset=assetaccessorio.idasset
JOIN assetunload as assetunloadcespite			ON assetunloadcespite.idassetunload=assetcespite.idassetunload
LEFT OUTER JOIN assetunload as assetunloadaccessorio		ON assetunloadaccessorio.idassetunload=assetaccessorio.idassetunload
WHERE assetaccessorio.idpiece>1
	AND assetcespite.idpiece=1
	AND caricoaccessorio.flag & 2  =0
	AND caricoaccessorio.idassetload IS NOT NULL
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece,assetunloadaccessorio.nassetunload,assetunloadaccessorio.yassetunload

------------------------------------------------------------------------------------------------
-- Valore degli accessori SCARICATI collegati ai cespiti principali attualmente in scarico ----- 
-- Si considerano quelli inseriti in buoni di scarico o che sono flaggati come da includere ----
------------------------------------------------------------------------------------------------
CREATE TABLE #pieceunloaded_load
(
	idasset int,
	idpiece	int,
	amount  decimal(23,6),
	typeoperation varchar(2),
	nassetunload int,
	yassetunload int
)
------------------------------------
--Accessorio di Nuova Acquisizione--
------------------------------------
INSERT INTO #pieceunloaded_load
(
	idasset,
	idpiece,
	amount,
	typeoperation,
	nassetunload ,
	yassetunload 
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
	SUM(
	ROUND(ISNULL(caricoaccessorio.taxable, 0)
	* (1 - CONVERT(decimal(19,6),ISNULL(caricoaccessorio.discount, 0))),2)
	+ ROUND(ISNULL(caricoaccessorio.tax,0) / caricoaccessorio.number,2)
	- ROUND(ISNULL(caricoaccessorio.abatable,0) / caricoaccessorio.number,2)),
	'AS',
	assetunloadaccessorio.nassetunload,
	assetunloadaccessorio.yassetunload
FROM   assetacquire as caricoaccessorio
JOIN   asset as assetaccessorio							ON caricoaccessorio.nassetacquire = assetaccessorio.nassetacquire
JOIN asset as assetcespite								ON assetcespite.idasset=assetaccessorio.idasset	
JOIN assetunload as assetunloadcespite					ON assetunloadcespite.idassetunload=assetcespite.idassetunload
LEFT OUTER JOIN assetunload as assetunloadaccessorio	ON assetunloadaccessorio.idassetunload=assetaccessorio.idassetunload
WHERE assetaccessorio.idpiece>1
	AND assetcespite.idpiece=1
	AND caricoaccessorio.flag & 2  =0
	AND (assetaccessorio.idassetunload IS NOT NULL OR (assetaccessorio.flag & 1 <> 1)) 
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece,assetunloadaccessorio.nassetunload,assetunloadaccessorio.yassetunload

----------------------------------------
--Accessorio Posseduto (Scarico Parti)--
----------------------------------------
INSERT INTO #pieceunloaded_load
(
	idasset,
	idpiece,
	amount,
	typeoperation,
	nassetunload ,
	yassetunload 
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
	SUM(
	ROUND(ISNULL(caricoaccessorio.taxable, 0)
	* (1 - CONVERT(decimal(19,6),ISNULL(caricoaccessorio.discount, 0))),2)
	+ ROUND(ISNULL(caricoaccessorio.tax,0) / caricoaccessorio.number,2)
	- ROUND(ISNULL(caricoaccessorio.abatable,0) / caricoaccessorio.number,2)),
	'AP',
	assetunloadaccessorio.nassetunload,
	assetunloadaccessorio.yassetunload
FROM   assetacquire as caricoaccessorio
JOIN   asset as assetaccessorio							ON caricoaccessorio.nassetacquire = assetaccessorio.nassetacquire
JOIN asset as assetcespite								ON assetcespite.idasset=assetaccessorio.idasset
JOIN assetunload as assetunloadcespite					ON assetunloadcespite.idassetunload=assetcespite.idassetunload
LEFT OUTER JOIN assetunload as assetunloadaccessorio	ON assetunloadaccessorio.idassetunload=assetaccessorio.idassetunload
WHERE assetaccessorio.idpiece>1
	AND assetcespite.idpiece=1
	AND caricoaccessorio.flag & 2  <> 0
	AND (assetaccessorio.idassetunload IS NOT NULL OR (assetaccessorio.flag & 1 <> 1)) 
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece,assetunloadaccessorio.nassetunload,assetunloadaccessorio.yassetunload


--
--select 'pieceunloaded_load',* from #pieceunloaded_load
--------------------------------------------------------------------------------------
--Rivalutazioni / Svalutazioni dei cespiti e degli accessori attualmente in scarico --
--------------------------------------------------------------------------------------
CREATE TABLE #amortization
(
	idasset int,
	idpiece	int,
	amount decimal(23,6),
	typeoperation varchar(2),
	nassetunload int,
	yassetunload int
)
INSERT INTO #amortization
(
	idasset,
	idpiece,
	amount,
	typeoperation,
	nassetunload ,
	yassetunload 
)
SELECT
	asset.idasset,
	asset.idpiece,
--	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
	(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),
	'AM',
	assetunload.nassetunload,
	assetunload.yassetunload
FROM assetamortization
JOIN asset											ON asset.idasset = assetamortization.idasset
															AND asset.idpiece = assetamortization.idpiece
JOIN inventoryamortization							ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN assetunload									ON asset.idassetunload = assetunload.idassetunload
WHERE 	ISNULL(assetamortization.amortizationquota,0) > 0
	AND (assetamortization.idassetload IS NOT NULL OR (assetamortization.flag & 1 <> 1))
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)
--GROUP BY asset.idasset,asset.idpiece

INSERT INTO #amortization
(
	idasset,
	idpiece,
	amount,
	typeoperation,
	nassetunload ,
	yassetunload
)
SELECT
	asset.idasset,
	asset.idpiece,
	--SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
	(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),
	'AM',
	assetunload.nassetunload,
	assetunload.yassetunload
FROM assetamortization
JOIN asset											ON asset.idasset = assetamortization.idasset
															AND asset.idpiece = assetamortization.idpiece
JOIN inventoryamortization							ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN assetunload									ON asset.idassetunload = assetunload.idassetunload
WHERE 	ISNULL(assetamortization.amortizationquota,0) < 0
	AND (inventoryamortization.flag & 2 <> 0)
	AND (assetamortization.idassetunload IS NOT NULL OR (assetamortization.flag & 1 <> 1))
	AND assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)
--GROUP BY asset.idasset,asset.idpiece

--select 'amortization',* from #amortization
	
--------------------------------------------------------------------------------------
------------------ Rivalutazioni / Svalutazioni degli accessori CARICATI -------------
---------------- collegati ai cespiti principali attualmente in scarico --------------
----- Si considerano quelli inseriti in buoni di carico ------------------------------
--------------------------------------------------------------------------------------
CREATE TABLE #pieceloaded_amortization
(
	idasset int,
	idpiece	int,
	amount decimal(23,6),
	typeoperation varchar(2),
	nassetunload int,
	yassetunload int
)

INSERT INTO #pieceloaded_amortization
(
	idasset,
	idpiece,
	amount,
	typeoperation,
	nassetunload ,
	yassetunload 
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),
	'RA',
	assetunloadcespite.nassetunload,
	assetunloadcespite.yassetunload
FROM assetamortization
JOIN inventoryamortization						ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset as  assetaccessorio					ON  assetaccessorio.idasset = assetamortization.idasset
													AND assetaccessorio.idpiece = assetamortization.idpiece
JOIN   assetacquire as caricoaccessorio			ON caricoaccessorio.nassetacquire = assetaccessorio.nassetacquire
JOIN asset as assetcespite						ON assetcespite.idasset=assetaccessorio.idasset
JOIN assetunload as assetunloadcespite			ON assetunloadcespite.idassetunload = assetcespite.idassetunload
WHERE assetaccessorio.idpiece>1
	AND assetcespite.idpiece=1
	AND caricoaccessorio.idassetload IS NOT NULL
	AND (inventoryamortization.flag & 2 <> 0)
	AND ISNULL(assetamortization.amortizationquota,0)>0
	AND (assetamortization.idassetload IS NOT NULL OR (assetamortization.flag & 1<> 1))
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece,assetunloadcespite.nassetunload,assetunloadcespite.yassetunload

INSERT INTO #pieceloaded_amortization
(
	idasset,
	idpiece,
	amount,
	typeoperation,
	nassetunload ,
	yassetunload 
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),
	'DA',
	assetunloadcespite.nassetunload,
	assetunloadcespite.yassetunload
FROM assetamortization
JOIN inventoryamortization						ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset as assetaccessorio					ON  assetaccessorio.idasset = assetamortization.idasset
														AND assetaccessorio.idpiece = assetamortization.idpiece
JOIN   assetacquire as caricoaccessorio			ON caricoaccessorio.nassetacquire = assetaccessorio.nassetacquire
JOIN asset as assetcespite						ON assetcespite.idasset=assetaccessorio.idasset
JOIN assetunload as assetunloadcespite			ON assetunloadcespite.idassetunload = assetcespite.idassetunload
WHERE assetaccessorio.idpiece>1
	AND assetcespite.idpiece=1
	AND caricoaccessorio.idassetload IS NOT NULL
	AND (inventoryamortization.flag & 2 <> 0)
	AND ISNULL(assetamortization.amortizationquota,0)< 0
	AND (assetamortization.idassetunload IS NOT NULL OR (assetamortization.flag & 1<> 1))
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece,assetunloadcespite.nassetunload,assetunloadcespite.yassetunload

--select 'pieceloaded_amortization',* from #pieceloaded_amortization

--------------------------------------------------------------------------------------
------------------ Rivalutazioni / Svalutazioni degli accessori SCARICATI-------------
---------------- collegati ai cespiti principali attualmente in scarico --------------
--- Si considerano quelli inseriti in buoni di scarico o con flagunload='N'-----------
--------------------------------------------------------------------------------------

CREATE TABLE #pieceunloaded_amortization
(
	idasset int,
	idpiece	int,
	amount decimal(23,6),
	typeoperation varchar(2),
	nassetunload int,
	yassetunload int
)

INSERT INTO #pieceunloaded_amortization
(
	idasset,
	idpiece,
	amount,
	typeoperation,
	nassetunload ,
	yassetunload 
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
---	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
	(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),
	'RD',
	assetunloadcespite.nassetunload,
	assetunloadcespite.yassetunload int
FROM assetamortization
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset as  assetaccessorio
	ON  assetaccessorio.idasset = assetamortization.idasset
	AND assetaccessorio.idpiece = assetamortization.idpiece
JOIN   assetacquire as caricoaccessorio
	ON caricoaccessorio.nassetacquire = assetaccessorio.nassetacquire
JOIN asset as assetcespite
	ON assetcespite.idasset=assetaccessorio.idasset
JOIN assetunload as assetunloadcespite
	ON assetunloadcespite.idassetunload = assetcespite.idassetunload
WHERE assetaccessorio.idpiece>1
	AND assetcespite.idpiece=1
	AND (assetaccessorio.idassetunload IS NOT NULL OR (assetaccessorio.flag & 1 <> 1)) 
	AND (inventoryamortization.flag & 2 <> 0)
	AND ISNULL(assetamortization.amortizationquota,0)> 0
	AND (assetamortization.idassetload IS NOT NULL OR (assetamortization.flag & 1 <> 1))
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
--GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece

INSERT INTO #pieceunloaded_amortization
(
	idasset,
	idpiece,
	amount,
	typeoperation,
	nassetunload,
	yassetunload
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
--	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
	(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),
	'DD',
	assetunloadcespite.nassetunload,
	assetunloadcespite.yassetunload
FROM assetamortization						
JOIN inventoryamortization						ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset as  assetaccessorio					ON  assetaccessorio.idasset = assetamortization.idasset
													AND assetaccessorio.idpiece = assetamortization.idpiece
JOIN   assetacquire as caricoaccessorio			ON caricoaccessorio.nassetacquire = assetaccessorio.nassetacquire
JOIN asset as assetcespite						ON assetcespite.idasset=assetaccessorio.idasset
JOIN assetunload as assetunloadcespite			ON assetunloadcespite.idassetunload = assetcespite.idassetunload
WHERE assetaccessorio.idpiece>1
	AND assetcespite.idpiece=1
	AND (assetaccessorio.idassetunload IS NOT NULL OR (assetaccessorio.flag & 1 <> 1)) 
	AND (inventoryamortization.flag & 2 <> 0)
	AND ISNULL(assetamortization.amortizationquota,0)< 0
	AND (assetamortization.idassetunload IS NOT NULL OR (assetamortization.flag & 1 <> 1))
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
--GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece

--select 'pieceunload_amortization',* from #pieceunloaded_amortization
	
--------------------------------------------------------------------------------------
--------------------------------Scarichi cespiti principali---------------------------
--------------------------------------------------------------------------------------	
CREATE TABLE #asset_unload
(
	idassetunloadkind int,
	yassetunload int,
	nassetunload int,
	idmot int,
	idinventoryagency int,
	codeinventoryagency varchar(20),
	idinventorykind int,
	doc varchar(35),
	docdate datetime,
	description varchar(150),
	enactment varchar(150),
	enactmentdate datetime,
	adate datetime,
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
	typeoperation varchar(2)
)

INSERT INTO #asset_unload
(
	idassetunloadkind,
	yassetunload,
	nassetunload,
	idmot,
	idinventoryagency,
	codeinventoryagency,
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
	nassetacquire,
	typeoperation
)
SELECT DISTINCT
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunload.idmot,
	inventory.idinventoryagency,
	inventoryagency.codeinventoryagency,
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
	CASE 
		WHEN @flagdiscount = 1
		THEN
			ROUND(ISNULL(assetacquire.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)
		WHEN   @flagdiscount = 0
		THEN
			ISNULL(assetacquire.taxable, 0)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)
	END,
	asset.nassetacquire,
	'CP'
FROM assetunload
JOIN asset									ON assetunload.idassetunload = asset.idassetunload
JOIN assetacquire							ON asset.nassetacquire = assetacquire.nassetacquire
LEFT OUTER JOIN assetload					ON assetload.idassetload = assetacquire.idassetload
JOIN inventory								ON assetacquire.idinventory = inventory.idinventory	
JOIN inventoryagency						ON inventory.idinventoryagency = inventoryagency.idinventoryagency	
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
	codeinventoryagency,
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
	typeoperation
)
SELECT
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunload.idmot,
	inventory.idinventoryagency,
	inventoryagency.codeinventoryagency,
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
	ROUND(ISNULL(assetacquire.taxable, 0)
	* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
	+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
	- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2),
	'SA'
FROM assetacquire
JOIN asset									ON asset.nassetacquire = assetacquire.nassetacquire
JOIN asset as assetmain						ON asset.idasset=assetmain.idasset
JOIN assetunload							ON assetunload.idassetunload = asset.idassetunload
JOIN inventory								ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryagency						ON inventory.idinventoryagency = inventoryagency.idinventoryagency	
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
	codeinventoryagency,
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
	nassetacquire,
	typeoperation
)
SELECT DISTINCT
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunload.idmot,
	inventory.idinventoryagency,
	inventoryagency.codeinventoryagency,
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
	assetamortization.namortization,
	'SV'
FROM assetunload
JOIN assetamortization									ON assetunload.idassetunload = assetamortization.idassetunload
JOIN inventoryamortization								ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset												ON asset.idasset = assetamortization.idasset
																AND asset.idpiece = assetamortization.idpiece		
JOIN assetacquire										ON asset.nassetacquire = assetacquire.nassetacquire
JOIN inventory											ON assetacquire.idinventory = inventory.idinventory	
JOIN inventoryagency									ON inventory.idinventoryagency = inventoryagency.idinventoryagency	
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
	codeinventoryagency,
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
	nassetacquire,
	typeoperation
)
SELECT DISTINCT
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunload.idmot,
	inventory.idinventoryagency,
	inventoryagency.codeinventoryagency,
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
	assetamortization.namortization,
	'SV'
FROM assetunload
JOIN assetamortization							ON  assetunload.idassetunload = assetamortization.idassetunload
JOIN inventoryamortization						ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset										ON asset.idasset = assetamortization.idasset
													AND asset.idpiece = assetamortization.idpiece
JOIN asset AS assetcespite						ON asset.idasset = assetcespite.idasset
JOIN assetacquire								ON asset.nassetacquire = assetacquire.nassetacquire
JOIN inventory									ON assetacquire.idinventory = inventory.idinventory	
JOIN inventoryagency							ON inventory.idinventoryagency = inventoryagency.idinventoryagency	
WHERE 	asset.idpiece >1 AND assetcespite.idpiece = 1 
	AND assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)

IF @official = 'S'
BEGIN
	UPDATE #asset_unload
	SET printdate = @printdate
	WHERE yassetunload = @ayear 
	AND nassetunload IN (SELECT num from #printing)
	AND printdate IS NULL
END

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

CREATE TABLE #OUT(
	idassetunloadkind int,
	yassetunload smallint,
	nassetunload int,
	idmot int,
	assetunloadmotive varchar(50),
	idinventoryagency int,
	inventoryagency varchar(150),
	idinventorykind int,
	inventorykind varchar(50),
	doc varchar(35),
	docdate smalldatetime,
	description  varchar(150),
	enactment   varchar(150),
	enactmentdate smalldatetime,
	adate smalldatetime,
	printdate smalldatetime,
	operationorder int,	
	kind varchar(50),
	idinventory int,
	idasset int,
	idpiece int,
	ninventory int ,
	idinv int,
	codeinventory varchar(20),
	codeinv varchar(50), 
	assetdescription  varchar(210),
	unitvalue decimal(23,2),
	unitvalue_parz decimal (23,2),
	nassetacquire int,
	amortization decimal(19,2),
	codeinventoryagency varchar(20),
	typeammortization varchar(2),
	yassetunload_acc smallint,
	nassetunload_acc int	
)

INSERT INTO #OUT(
	idassetunloadkind,	yassetunload,	nassetunload,	idmot,	assetunloadmotive,	idinventoryagency,	inventoryagency,	idinventorykind,
	inventorykind,	doc,	docdate,	description,	enactment,	enactmentdate,	adate,	printdate,	operationorder,		kind,	idinventory,
	idasset,	idpiece,	ninventory,	idinv,	codeinventory,	codeinv, 	assetdescription,	unitvalue,	unitvalue_parz,	nassetacquire,	amortization ,
	codeinventoryagency,	typeammortization,	yassetunload_acc,	nassetunload_acc )
SELECT  
	idassetunloadkind ,	yassetunload ,	nassetunload ,	#asset_unload.idmot ,	MOTIVE.description,	#asset_unload.idinventoryagency ,AGENCY.description,
	#asset_unload.idinventorykind ,	INVKIND.description,	doc ,	docdate ,	#asset_unload.description ,	enactment ,	enactmentdate ,	adate ,
	printdate ,	operationorder ,	kind ,	#asset_unload.idinventory ,	#asset_unload.idasset ,	#asset_unload.idpiece ,	ninventory ,	#asset_unload.idinv ,
	inventory.codeinventory,	inventorytree.codeinv, 	assetdescription ,	unitvalue ,	unitvalue,	nassetacquire,	0,	#asset_unload.codeinventoryagency,
	typeoperation,	NULL,	NULL
FROM #asset_unload
JOIN inventorytree								ON inventorytree.idinv = #asset_unload.idinv
JOIN inventory									on #asset_unload.idinventory = inventory.idinventory
LEFT OUTER JOIN assetunloadmotive MOTIVE		ON #asset_unload.idmot = MOTIVE.idmot
LEFT OUTER JOIN inventoryagency AGENCY			ON #asset_unload.idinventoryagency = AGENCY.idinventoryagency
LEFT OUTER JOIN inventorykind INVKIND			ON #asset_unload.idinventorykind = INVKIND.idinventorykind  
WHERE #asset_unload.kind not in ('Scarico bene', 'Scarico accessorio')


INSERT INTO #OUT(
	idassetunloadkind,	yassetunload,	nassetunload,	idmot,	assetunloadmotive,	idinventoryagency,	inventoryagency,
	idinventorykind,	inventorykind,	doc,	docdate,	description,	enactment,	enactmentdate,	adate,	printdate,
	operationorder,		kind,	idinventory,	idasset,	idpiece,	ninventory,	idinv,	codeinventory,	codeinv, 	assetdescription,
	unitvalue,	unitvalue_parz,	nassetacquire,	amortization ,	codeinventoryagency,	typeammortization,	yassetunload_acc,	nassetunload_acc 
)
SELECT  
	idassetunloadkind ,	#asset_unload.yassetunload ,	#asset_unload.nassetunload ,	#asset_unload.idmot ,	MOTIVE.description,
	#asset_unload.idinventoryagency ,	AGENCY.description,	#asset_unload.idinventorykind ,	INVKIND.description,	doc ,
	docdate ,	#asset_unload.description ,	enactment ,	enactmentdate ,	adate ,	printdate ,	operationorder ,	kind ,	#asset_unload.idinventory ,
	#asset_unload.idasset ,	#asset_unload.idpiece ,	ninventory ,	#asset_unload.idinv ,	inventory.codeinventory,	inventorytree.codeinv, 
	assetdescription ,	unitvalue ,	unitvalue,	nassetacquire,	0, --> amortization 
	#asset_unload.codeinventoryagency,	typeoperation,	NULL,	NULL
FROM #asset_unload
JOIN inventorytree									ON inventorytree.idinv = #asset_unload.idinv
JOIN inventory										on #asset_unload.idinventory = inventory.idinventory
LEFT OUTER JOIN assetunloadmotive MOTIVE			ON #asset_unload.idmot = MOTIVE.idmot
LEFT OUTER JOIN inventoryagency AGENCY				ON #asset_unload.idinventoryagency = AGENCY.idinventoryagency
LEFT OUTER JOIN inventorykind INVKIND				ON #asset_unload.idinventorykind = INVKIND.idinventorykind  
WHERE #asset_unload.kind in ('Scarico bene', 'Scarico accessorio')


INSERT INTO #OUT(
	idassetunloadkind,	yassetunload,	nassetunload,	idmot,	assetunloadmotive,	idinventoryagency,	inventoryagency,
	idinventorykind,	inventorykind,	doc,	docdate,	description,	enactment,	enactmentdate,	adate,	printdate,
	operationorder,		kind,	idinventory,	idasset,	idpiece,	ninventory,	idinv,	codeinventory,	codeinv, 
	assetdescription,	unitvalue,	unitvalue_parz,	nassetacquire,	amortization ,	codeinventoryagency,	typeammortization,
	yassetunload_acc,	nassetunload_acc 
)
SELECT  
	idassetunloadkind ,	#asset_unload.yassetunload ,	#asset_unload.nassetunload ,	#asset_unload.idmot ,
	MOTIVE.description,	#asset_unload.idinventoryagency ,	AGENCY.description,	#asset_unload.idinventorykind ,
	INVKIND.description,	doc ,	docdate ,	#asset_unload.description ,	enactment ,	enactmentdate ,	adate ,
	printdate ,	operationorder ,	kind ,	#asset_unload.idinventory ,	#asset_unload.idasset ,	#asset_unload.idpiece ,
	ninventory ,	#asset_unload.idinv ,	inventory.codeinventory,	inventorytree.codeinv, 	assetdescription ,
	0 ,	0 ,	nassetacquire,	ISNULL(#pieceloaded_load.amount,0), --> amortization 
	#asset_unload.codeinventoryagency,	#pieceloaded_load.typeoperation,	#pieceloaded_load.yassetunload ,
	#pieceloaded_load.nassetunload 
FROM #asset_unload
JOIN inventorytree									ON inventorytree.idinv = #asset_unload.idinv
JOIN inventory										on #asset_unload.idinventory = inventory.idinventory
LEFT OUTER JOIN assetunloadmotive MOTIVE			ON #asset_unload.idmot = MOTIVE.idmot
LEFT OUTER JOIN inventoryagency AGENCY				ON #asset_unload.idinventoryagency = AGENCY.idinventoryagency
LEFT OUTER JOIN inventorykind INVKIND				ON #asset_unload.idinventorykind = INVKIND.idinventorykind  

LEFT OUTER JOIN #pieceloaded_load
	ON #pieceloaded_load.idasset = #asset_unload.idasset
WHERE #asset_unload.kind = 'Scarico bene' and ISNULL(#pieceloaded_load.amount,0)<>0


INSERT INTO #OUT(
	idassetunloadkind,	yassetunload,	nassetunload,	idmot,	assetunloadmotive,	idinventoryagency,	inventoryagency,
	idinventorykind,	inventorykind,	doc,	docdate,	description,	enactment,	enactmentdate,	adate,	printdate,
	operationorder,		kind,	idinventory,	idasset,	idpiece,	ninventory,	idinv,	codeinventory,	codeinv, 	assetdescription,
	unitvalue,	unitvalue_parz,	nassetacquire,	amortization ,	codeinventoryagency,	typeammortization,	yassetunload_acc,	nassetunload_acc 
)
SELECT  
	idassetunloadkind ,	#asset_unload.yassetunload ,	#asset_unload.nassetunload ,	#asset_unload.idmot ,	MOTIVE.description,
	#asset_unload.idinventoryagency ,	AGENCY.description,	#asset_unload.idinventorykind ,	INVKIND.description,	doc ,
	docdate ,	#asset_unload.description ,	enactment ,	enactmentdate ,	adate ,	printdate ,	operationorder ,	kind ,
	#asset_unload.idinventory ,	#asset_unload.idasset ,	#asset_unload.idpiece ,	ninventory ,	#asset_unload.idinv ,	inventory.codeinventory,
	inventorytree.codeinv, 	assetdescription ,	0 ,	0 ,	nassetacquire,	ISNULL(#amortization.amount,0), --> amortization 
	#asset_unload.codeinventoryagency,	#amortization.typeoperation,	#amortization.yassetunload,	#amortization.nassetunload 
FROM #asset_unload
JOIN inventorytree								ON inventorytree.idinv = #asset_unload.idinv
JOIN inventory									on #asset_unload.idinventory = inventory.idinventory
LEFT OUTER JOIN assetunloadmotive MOTIVE		ON #asset_unload.idmot = MOTIVE.idmot
LEFT OUTER JOIN inventoryagency AGENCY			ON #asset_unload.idinventoryagency = AGENCY.idinventoryagency
LEFT OUTER JOIN inventorykind INVKIND			ON #asset_unload.idinventorykind = INVKIND.idinventorykind  
LEFT OUTER JOIN #amortization					ON  #amortization.idasset = #asset_unload.idasset
														AND    #amortization.idpiece   = #asset_unload.idpiece
WHERE #asset_unload.kind = 'Scarico bene' and ISNULL(#amortization.amount,0)<>0


INSERT INTO #OUT(
	idassetunloadkind,	yassetunload,	nassetunload,	idmot,	assetunloadmotive,	idinventoryagency,	inventoryagency,	idinventorykind,	inventorykind,
	doc,	docdate,	description,	enactment,	enactmentdate,	adate,	printdate,	operationorder,		kind,	idinventory,	idasset,
	idpiece,	ninventory,	idinv,	codeinventory,	codeinv, 	assetdescription,	unitvalue,	unitvalue_parz,	nassetacquire,	amortization ,
	codeinventoryagency,	typeammortization,	yassetunload_acc,	nassetunload_acc )
SELECT  
	idassetunloadkind ,	#asset_unload.yassetunload ,	#asset_unload.nassetunload ,	#asset_unload.idmot ,	MOTIVE.description,
	#asset_unload.idinventoryagency ,	AGENCY.description,	#asset_unload.idinventorykind ,	INVKIND.description,	doc ,
	docdate ,	#asset_unload.description ,	enactment , enactmentdate ,	adate ,	printdate ,	operationorder ,	kind ,	#asset_unload.idinventory ,
	#asset_unload.idasset ,	#asset_unload.idpiece ,	ninventory ,	#asset_unload.idinv ,	inventory.codeinventory,	inventorytree.codeinv, 
	assetdescription ,	0 ,	0 ,	nassetacquire,	ISNULL(#pieceloaded_amortization.amount,0), --> amortization 
	#asset_unload.codeinventoryagency,	#pieceloaded_amortization.typeoperation, #pieceloaded_amortization.yassetunload ,#pieceloaded_amortization.nassetunload 
FROM #asset_unload
JOIN inventorytree									ON inventorytree.idinv = #asset_unload.idinv
JOIN inventory										on #asset_unload.idinventory = inventory.idinventory
LEFT OUTER JOIN assetunloadmotive MOTIVE			ON #asset_unload.idmot = MOTIVE.idmot
LEFT OUTER JOIN inventoryagency AGENCY				ON #asset_unload.idinventoryagency = AGENCY.idinventoryagency
LEFT OUTER JOIN inventorykind INVKIND				ON #asset_unload.idinventorykind = INVKIND.idinventorykind  
LEFT OUTER JOIN  #pieceloaded_amortization			ON #pieceloaded_amortization.idasset = #asset_unload.idasset
WHERE #asset_unload.kind = 'Scarico bene' and ISNULL(#pieceloaded_amortization.amount,0)<>0


INSERT INTO #OUT( 	idassetunloadkind,	yassetunload,	nassetunload,	idmot,	assetunloadmotive,	idinventoryagency,	inventoryagency,	idinventorykind,
	inventorykind,	doc,	docdate,	description,	enactment,	enactmentdate,	adate,	printdate,	operationorder,		kind,	idinventory,
	idasset,	idpiece,	ninventory,	idinv,	codeinventory,	codeinv, 	assetdescription,	unitvalue,	unitvalue_parz,	nassetacquire,	amortization ,
	codeinventoryagency,	typeammortization,	yassetunload_acc,	nassetunload_acc 
)
SELECT  
	idassetunloadkind ,	#asset_unload.yassetunload ,	#asset_unload.nassetunload ,	#asset_unload.idmot ,	MOTIVE.description,	#asset_unload.idinventoryagency ,
	AGENCY.description,	#asset_unload.idinventorykind ,	INVKIND.description,	doc ,	docdate ,	#asset_unload.description ,	enactment ,	enactmentdate ,
	adate ,	printdate ,	operationorder ,	kind ,	#asset_unload.idinventory ,	#asset_unload.idasset ,	#asset_unload.idpiece ,	ninventory ,
	#asset_unload.idinv ,	inventory.codeinventory,	inventorytree.codeinv, 	assetdescription ,	0 ,	0 ,	nassetacquire,
	-	ISNULL(#pieceunloaded_load.amount,0) , --> amortization 
	#asset_unload.codeinventoryagency,	#pieceunloaded_load.typeoperation,	#pieceunloaded_load.yassetunload,	#pieceunloaded_load.nassetunload 
FROM #asset_unload											
JOIN inventorytree								ON inventorytree.idinv = #asset_unload.idinv			
JOIN inventory									on #asset_unload.idinventory = inventory.idinventory
LEFT OUTER JOIN assetunloadmotive MOTIVE		ON #asset_unload.idmot = MOTIVE.idmot
LEFT OUTER JOIN inventoryagency AGENCY			ON #asset_unload.idinventoryagency = AGENCY.idinventoryagency
LEFT OUTER JOIN inventorykind INVKIND			ON #asset_unload.idinventorykind = INVKIND.idinventorykind  
LEFT OUTER JOIN #pieceunloaded_load				ON #pieceunloaded_load.idasset = #asset_unload.idasset
WHERE #asset_unload.kind = 'Scarico bene' and ISNULL(#pieceunloaded_load.amount,0)<>0

INSERT INTO #OUT(	idassetunloadkind,	yassetunload,	nassetunload,	idmot,	assetunloadmotive,	idinventoryagency,	inventoryagency,	idinventorykind,
	inventorykind,	doc,	docdate,	description,	enactment,	enactmentdate,	adate,	printdate,	operationorder,		kind,	idinventory,
		#asset_unload.idasset ,	#asset_unload.idpiece ,	ninventory,	idinv,	codeinventory,	codeinv, 	assetdescription,	unitvalue,	unitvalue_parz,
	nassetacquire,	amortization ,	codeinventoryagency,	typeammortization,	yassetunload_acc,	nassetunload_acc )
SELECT  
	idassetunloadkind ,	#asset_unload.yassetunload ,	#asset_unload.nassetunload ,	#asset_unload.idmot ,	MOTIVE.description,	#asset_unload.idinventoryagency ,
	AGENCY.description,	#asset_unload.idinventorykind ,	INVKIND.description,	doc ,	docdate ,	#asset_unload.description ,	enactment ,	enactmentdate ,
	adate ,	printdate ,	operationorder ,	kind ,	#asset_unload.idinventory ,	#asset_unload.idasset ,	#asset_unload.idpiece ,	ninventory ,
	#asset_unload.idinv ,	inventory.codeinventory,	inventorytree.codeinv, 	assetdescription ,	0 ,	0,	nassetacquire,
	- ISNULL(#pieceunloaded_amortization.amount,0) , --> amortization 
	#asset_unload.codeinventoryagency,	#pieceunloaded_amortization.typeoperation,	#pieceunloaded_amortization.yassetunload ,#pieceunloaded_amortization.nassetunload 
FROM #asset_unload
JOIN inventorytree								ON inventorytree.idinv = #asset_unload.idinv
JOIN inventory									on #asset_unload.idinventory = inventory.idinventory
LEFT OUTER JOIN assetunloadmotive MOTIVE		ON #asset_unload.idmot = MOTIVE.idmot
LEFT OUTER JOIN inventoryagency AGENCY			ON #asset_unload.idinventoryagency = AGENCY.idinventoryagency
LEFT OUTER JOIN inventorykind INVKIND			ON #asset_unload.idinventorykind = INVKIND.idinventorykind  
LEFT OUTER JOIN #pieceunloaded_amortization		ON #pieceunloaded_amortization.idasset = #asset_unload.idasset
WHERE #asset_unload.kind = 'Scarico bene' and ISNULL(#pieceunloaded_amortization.amount,0)<>0

INSERT INTO #OUT(	idassetunloadkind,	yassetunload,	nassetunload,	idmot,	assetunloadmotive,	idinventoryagency,	inventoryagency,	idinventorykind,
	inventorykind,	doc,	docdate,	description,	enactment,	enactmentdate,	adate,	printdate,	operationorder,		kind,	idinventory,	idasset,
	idpiece,	ninventory,	idinv,	codeinventory,	codeinv, 	assetdescription,	unitvalue,	unitvalue_parz,	nassetacquire,	amortization ,	codeinventoryagency,
	typeammortization,	yassetunload_acc,	nassetunload_acc 
)
SELECT  
	idassetunloadkind ,	#asset_unload.yassetunload ,	#asset_unload.nassetunload ,	#asset_unload.idmot ,	MOTIVE.description,	#asset_unload.idinventoryagency ,
	AGENCY.description,	#asset_unload.idinventorykind ,	INVKIND.description,	doc ,	docdate ,	#asset_unload.description ,	enactment ,	enactmentdate ,
	adate ,	printdate ,	operationorder ,	kind ,	#asset_unload.idinventory ,	#asset_unload.idasset ,	#asset_unload.idpiece ,	ninventory ,	#asset_unload.idinv ,
	inventory.codeinventory,	inventorytree.codeinv, 	assetdescription ,	0 ,	0,	nassetacquire,
	ISNULL(#amortization.amount,0) , --> amortization 
	#asset_unload.codeinventoryagency,	#amortization.typeoperation,	#amortization.yassetunload ,	#amortization.nassetunload 
FROM #asset_unload	
JOIN inventorytree										ON inventorytree.idinv = #asset_unload.idinv
JOIN inventory											on #asset_unload.idinventory = inventory.idinventory
LEFT OUTER JOIN assetunloadmotive MOTIVE				ON #asset_unload.idmot = MOTIVE.idmot
LEFT OUTER JOIN inventoryagency AGENCY					ON #asset_unload.idinventoryagency = AGENCY.idinventoryagency
LEFT OUTER JOIN inventorykind INVKIND					ON #asset_unload.idinventorykind = INVKIND.idinventorykind  
 LEFT OUTER JOIN #amortization							ON #amortization.idasset = #asset_unload.idasset
																AND    #amortization.idpiece = #asset_unload.idpiece
WHERE #asset_unload.kind = 'Scarico accessorio' and ISNULL(#amortization.amount,0)<>0

UPDATE #OUT SET
	unitvalue = (SELECT ISNULL(O2.unitvalue,0) FROM #OUT O2
					WHERE #OUT.idassetunloadkind = O2.idassetunloadkind
					AND #OUT.yassetunload = O2.yassetunload
					AND #OUT.nassetunload = O2.nassetunload
					AND #OUT.idinventoryagency = O2.idinventoryagency
					AND #OUT.idinventorykind = O2.idinventorykind
					AND #OUT.idasset = O2.idasset
					AND #OUT.idpiece = O2.idpiece
					AND O2.unitvalue > 0 
					AND ((O2.typeammortization = 'CP' AND #OUT.idpiece = 1) OR (O2.typeammortization = 'SA' AND #OUT.idpiece > 1))
				 )
WHERE ISNULL(#OUT.unitvalue,0) = 0

SELECT O.*, 
	A.title_l,   -- sezione firme
	A.name_l,
	A.title_c,
	A.name_c,
	A.title_r,
	A.name_r
FROM #OUT O
join inventoryagency A
	on O.idinventoryagency = A.idinventoryagency
ORDER BY nassetunload,ninventory,operationorder

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


