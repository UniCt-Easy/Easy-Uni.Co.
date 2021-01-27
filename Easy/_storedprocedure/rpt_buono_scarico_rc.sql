
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_scarico_rc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_scarico_rc]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- rpt_buono_scarico_rc 2014,'I',6,1,2,{d '2014-01-31'},'N'
CREATE  PROCEDURE [rpt_buono_scarico_rc]
(
	@ayear int,
	@printkind char(1),
	@idassetunloadkind int,
	@startassetunload int,
	@stopassetunload int,
	@printdate datetime,
	@official char(1) 
)
AS
BEGIN
-- Update che permette di ricavare il corretto numero iniziale di un bene, inquanto con lo stesso numiniziale possono esserci dei beni con denominazioni diverse
-- Update che permette di calcolare le quantità dei beni presenti
-- Eliminazione nella select distinct finale dei campi ninventory,idasset,numcaricoinventario che contraddistinguono beni singoli.
	
DECLARE @flagdiscount float   
IF (SELECT  TOP 1 (inventorykind.flag & 1) FROM inventorykind 
	JOIN inventory 
		ON inventory.idinventorykind= inventorykind.idinventorykind
	JOIN assetacquire 
		ON assetacquire.idinventory=inventory.idinventory
	JOIN assetunloadkind 
		ON assetunloadkind.idinventory=inventory.idinventory
	WHERE idassetunloadkind=@idassetunloadkind
)<> 0
BEGIN
	SET @flagdiscount = 1
END
ELSE 
BEGIN
	SET @flagdiscount = 0
END
IF (@ayear<2005) 
	BEGIN
	SET @flagdiscount = 1 
	END
-- Contiene i numeri di Buoni di Scarico da stampare
CREATE TABLE #printing (num int)

IF @printkind = 'A' 
BEGIN
	INSERT INTO #printing (num) 
	SELECT nassetunload from  assetunload  where (yassetunload=@ayear) and (printdate IS NULL)
END
	
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printing (num) 
	SELECT nassetunload from  assetunload where (yassetunload=@ayear) and (nassetunload BETWEEN @startassetunload AND @stopassetunload)
END

-----------------------------------------------------------------------------------------------
-- Valore degli accessori CARICATI collegati ai cespiti principali attualmente in scarico ----- 
-- Si considerano quelli inseriti in buoni di carico ------------------------------------------
-----------------------------------------------------------------------------------------------

CREATE TABLE #pieceloaded_load
(
	idasset int,
	idpiece	int,
	amount  decimal(23,6)
)

INSERT INTO #pieceloaded_load
(
	idasset,
	idpiece,
	amount
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
	SUM(assetview_current.start)
FROM   assetacquire as caricoaccessorio
JOIN   asset as assetaccessorio
	ON caricoaccessorio.nassetacquire = assetaccessorio.nassetacquire
join  assetview_current  
	on assetview_current.idasset=assetaccessorio.idasset and assetview_current.idpiece=assetaccessorio.idpiece
JOIN asset as assetcespite
	ON assetcespite.idasset=assetaccessorio.idasset
JOIN assetunload as assetunloadcespite
	ON assetunloadcespite.idassetunload = assetcespite.idassetunload
WHERE assetaccessorio.idpiece>1
	AND assetcespite.idpiece=1
	AND caricoaccessorio.idassetload IS NOT NULL
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece

--select 'pieceloaded_load',* from #pieceloaded_load

------------------------------------------------------------------------------------------------
-- Valore degli accessori SCARICATI collegati ai cespiti principali attualmente in scarico ----- 
-- Si considerano quelli inseriti in buoni di scarico o con flagunload='N' ---------------------
------------------------------------------------------------------------------------------------
CREATE TABLE #pieceunloaded_load
(
	idasset int,
	idpiece	int,
	amount  decimal(23,6)
)

INSERT INTO #pieceunloaded_load
(
	idasset,
	idpiece,
	amount
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
	SUM(assetview_current.start)
FROM   assetacquire as caricoaccessorio
JOIN   asset as assetaccessorio
	ON caricoaccessorio.nassetacquire = assetaccessorio.nassetacquire
JOIN  assetview_current  
	ON assetview_current.idasset=assetaccessorio.idasset and assetview_current.idpiece=assetaccessorio.idpiece
JOIN asset as assetcespite
	ON assetcespite.idasset=assetaccessorio.idasset
JOIN assetunload as assetunloadcespite
	ON assetunloadcespite.idassetunload=assetcespite.idassetunload
WHERE assetaccessorio.idpiece>1
	AND assetcespite.idpiece=1
	AND (assetaccessorio.idassetunload IS NOT NULL OR (assetaccessorio.flag & 1 <> 1)) 
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece

--
--select 'pieceunloaded_load',* from #pieceunloaded_load
--------------------------------------------------------------------------------------
--Rivalutazioni / Svalutazioni dei cespiti e degli accessori attualmente in scarico --
--------------------------------------------------------------------------------------
CREATE TABLE #amortization
(
	idasset int,
	idpiece	int,
	amount decimal(23,6)
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
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetamortization
JOIN asset
	ON asset.idasset = assetamortization.idasset
	AND asset.idpiece = assetamortization.idpiece
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN assetunload
	ON  asset.idassetunload = assetunload.idassetunload
WHERE 	ISNULL(assetamortization.amortizationquota,0) > 0
	AND assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND (inventoryamortization.flag & 2 <> 0)
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
JOIN asset
	ON asset.idasset = assetamortization.idasset
	AND asset.idpiece = assetamortization.idpiece
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN assetunload
	ON  asset.idassetunload = assetunload.idassetunload
WHERE 	ISNULL(assetamortization.amortizationquota,0) < 0
	AND (inventoryamortization.flag & 2 <> 0)
	AND (assetamortization.idassetunload IS NOT NULL OR (assetamortization.flag & 1 <> 1))
	AND assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)
GROUP BY asset.idasset,asset.idpiece

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
	amount decimal(23,6)
)

INSERT INTO #pieceloaded_amortization
(
	idasset,
	idpiece,
	amount 
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
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
	AND caricoaccessorio.idassetload IS NOT NULL
	AND (inventoryamortization.flag & 2 <> 0)
	AND ISNULL(assetamortization.amortizationquota,0)>0
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece

INSERT INTO #pieceloaded_amortization
(
	idasset,
	idpiece,
	amount 
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
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
	AND caricoaccessorio.idassetload IS NOT NULL
	AND (inventoryamortization.flag & 2 <> 0)
	AND ISNULL(assetamortization.amortizationquota,0)< 0
	AND (assetamortization.idassetunload IS NOT NULL OR (assetamortization.flag & 1 <> 1))
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece

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
	amount decimal(23,6)
)

INSERT INTO #pieceunloaded_amortization
(
	idasset,
	idpiece,
	amount 
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
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
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece

INSERT INTO #pieceunloaded_amortization
(
	idasset,
	idpiece,
	amount 
)
SELECT
	assetaccessorio.idasset,
	assetaccessorio.idpiece,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
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
	AND ISNULL(assetamortization.amortizationquota,0)< 0
	AND (assetamortization.idassetunload IS NOT NULL OR (assetamortization.flag & 1 <> 1))
	AND assetunloadcespite.idassetunloadkind = @idassetunloadkind
	AND assetunloadcespite.yassetunload = @ayear
	AND assetunloadcespite.nassetunload IN (SELECT num from #printing)
GROUP BY assetaccessorio.idasset,assetaccessorio.idpiece

--select 'pieceunload_amortization',* from #pieceunloaded_amortization

--------------------------------------------------------------------------------------
----------------------------Scarichi cespiti principali ------------------------------
--------------------------------------------------------------------------------------	
CREATE TABLE #asset_unload
(
	idassetunloadkind int,
	yassetunload int ,
	nassetunload int ,
	idmot varchar(20) ,
	idinventoryagency int,
	idinventorykind int,
	doc varchar(35) ,
	docdate datetime ,
	description varchar(150) ,
	enactment varchar(150) ,
	enactmentdate datetime ,
	adate datetime ,
	printdate datetime ,
	operationorder int ,
	kind varchar(50) ,
	idinventory int,
	idasset int ,				
	idpiece int ,
	ninventory int ,			
	idinv int,
	assetdescription varchar(210) ,
	valoreunitario decimal(23,2) ,
	nassetacquire int ,
	number int ,
	idreg int,
	idlocation int,
	idman int, 
	startnumber int,
	amortization decimal(23,6)
)

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
	valoreunitario,
	nassetacquire,
	number,		-- quantita		
	idreg,			
	idlocation,
	idman,
	startnumber	
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
	assetview_current.start,
	asset.nassetacquire,
	1,			--	<-- QUANTITA'
	assetunload.idreg,	
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL),
	asset.ninventory        -- come numerazione iniziale ci mette il numero di inventario da preparare x l'update  
FROM assetunload
JOIN asset
	ON assetunload.idassetunload = asset.idassetunload
JOIN  assetview_current  
	ON assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
JOIN assetacquire
	ON asset.nassetacquire = assetacquire.nassetacquire
LEFT OUTER JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN inventory
	ON assetacquire.idinventory = inventory.idinventory	
WHERE asset.idpiece=1
	and assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)

UPDATE #asset_unload 
	set amortization = 
			ISNULL((SELECT SUM(amount)
				FROM  #pieceloaded_load
				WHERE #pieceloaded_load.idasset = #asset_unload.idasset),0) 
			+
			ISNULL((SELECT SUM(amount)
				FROM   #amortization
				WHERE  #amortization.idasset = #asset_unload.idasset
				AND    #amortization.idpiece = #asset_unload.idpiece),0) 
			+
			ISNULL((SELECT SUM(amount)
				FROM  #pieceloaded_amortization
				WHERE #pieceloaded_amortization.idasset = #asset_unload.idasset),0) 
			-
			ISNULL((SELECT SUM(amount)
				FROM  #pieceunloaded_load
				WHERE #pieceunloaded_load.idasset = #asset_unload.idasset),0) 
			-
			ISNULL((SELECT SUM(amount)
				FROM  #pieceunloaded_amortization
				WHERE #pieceunloaded_amortization.idasset = #asset_unload.idasset),0) 
WHERE kind = 'Scarico Bene'

--select 'ammortamenti prima accorpamento cespiti',* from #asset_unload
--Questa update imposta come numero iniziale il minore fra i beni con stesse proprietà 
UPDATE #asset_unload SET
startnumber = isnull((select max(b.ninventory) from #asset_unload b where
		#asset_unload.idassetunloadkind 	= b.idassetunloadkind 
		and #asset_unload.yassetunload 		= b.yassetunload 
		and #asset_unload.nassetunload 		= b.nassetunload 
		and isnull(#asset_unload.idmot,0) 	= isnull(b.idmot,0) 
		and #asset_unload.idinventoryagency 	= b.idinventoryagency 
		and isnull(#asset_unload.description,'') 	= isnull(b.description ,'') 
		and #asset_unload.idinventorykind 	= b.idinventorykind 
		and isnull(#asset_unload.doc,'') 		= isnull(b.doc ,'')
		and isnull(#asset_unload.docdate,{d '1900-01-01'})= isnull(b.docdate,{d '1900-01-01'}) 
		and #asset_unload.operationorder		= b.operationorder 
		and isnull(#asset_unload.enactment,'') 	= isnull( b.enactment,'') 
		and isnull(#asset_unload.enactmentdate,{d '1900-01-01'})= isnull(b.enactmentdate,{d '1900-01-01'})
		and #asset_unload.adate 			= b.adate
		and isnull(#asset_unload.printdate,{d '1900-01-01'} )= isnull(b.printdate, {d '1900-01-01'} )
		and #asset_unload.kind 			= b.kind 
		and #asset_unload.idinventory 		= b.idinventory 
		and #asset_unload.idinv 			= b.idinv 
		and isnull(#asset_unload.assetdescription,'') = isnull(b.assetdescription,'')
		and #asset_unload.valoreunitario 		= b.valoreunitario
		and #asset_unload.number			= b.number 	
		and isnull(#asset_unload.idreg,0)	= isnull(b.idreg,0)
		and isnull(#asset_unload.idlocation,0)	= isnull(b.idlocation,0) 
		and isnull(#asset_unload.idman,0)	= isnull(b.idman ,0)
		AND b.ninventory < #asset_unload.ninventory
		AND (select count (*) from  #asset_unload i where
		#asset_unload.idassetunloadkind 		= i.idassetunloadkind and 
		#asset_unload.yassetunload 		= i.yassetunload and
		#asset_unload.nassetunload 		= i.nassetunload and 
		isnull(#asset_unload.idmot,0) 		= isnull(i.idmot,0) and 
		#asset_unload.idinventoryagency 		= i.idinventoryagency and 
		isnull(#asset_unload.description,'') 	= isnull(i.description ,'')and 
		#asset_unload.idinventorykind 		= i.idinventorykind and 
		isnull(#asset_unload.doc,'') 		= isnull(i.doc ,'')and 
		isnull(#asset_unload.docdate,{d '1900-01-01'})= isnull(i.docdate,{d '1900-01-01'}) and 
		#asset_unload.operationorder		= i.operationorder and 
		isnull(#asset_unload.enactment,'') 	= isnull( i.enactment,'') and
		isnull(#asset_unload.enactmentdate,{d '1900-01-01'})= isnull(i.enactmentdate,{d '1900-01-01'}) and 
		#asset_unload.adate 			= i.adate and 
		isnull(#asset_unload.printdate,{d '1900-01-01'} )= isnull(i.printdate, {d '1900-01-01'} )and 
		#asset_unload.kind 			= i.kind and
		#asset_unload.idinventory 		= i.idinventory and
		#asset_unload.idinv 			= i.idinv and
		isnull(#asset_unload.assetdescription,'') = isnull(i.assetdescription,'') and
		#asset_unload.valoreunitario 		= i.valoreunitario and
		#asset_unload.number			= i.number and	--	<-- quantità 
		isnull(#asset_unload.idreg,0)		= isnull(i.idreg,0) and
		isnull(#asset_unload.idlocation,0)	= isnull(i.idlocation,0) and
		isnull(#asset_unload.idman,0)		= isnull(i.idman ,0)
		and b.ninventory= i.ninventory+1
		)=0
	),#asset_unload.ninventory)
WHERE exists (select * from #asset_unload e where 
		#asset_unload.ninventory=e.ninventory+1 
		and #asset_unload.assetdescription=e.assetdescription
		and #asset_unload.idassetunloadkind 	= e.idassetunloadkind and 
		#asset_unload.yassetunload 		= e.yassetunload and
		#asset_unload.nassetunload 		= e.nassetunload and 
		isnull(#asset_unload.idmot,0) 		= isnull(e.idmot,0) and 
		#asset_unload.idinventoryagency 		= e.idinventoryagency and 
		isnull(#asset_unload.description,'') 	= isnull(e.description ,'')and 
		#asset_unload.idinventorykind 		= e.idinventorykind and 
		isnull(#asset_unload.doc,'') 		= isnull(e.doc ,'')and 
		isnull(#asset_unload.docdate,{d '1900-01-01'})= isnull(e.docdate,{d '1900-01-01'}) and 
		#asset_unload.operationorder		= e.operationorder and 
		isnull(#asset_unload.enactment,'') 	= isnull( e.enactment,'') and
		isnull(#asset_unload.enactmentdate,{d '1900-01-01'})= isnull(e.enactmentdate,{d '1900-01-01'}) and 
		#asset_unload.adate 			= e.adate and 
		isnull(#asset_unload.printdate,{d '1900-01-01'} )= isnull(e.printdate, {d '1900-01-01'} )and 
		#asset_unload.kind 			= e.kind and
		#asset_unload.idinventory 		= e.idinventory and
		#asset_unload.idinv 			= e.idinv and
		isnull(#asset_unload.assetdescription,'') = isnull(e.assetdescription,'') and
		#asset_unload.valoreunitario 		= e.valoreunitario and
		#asset_unload.number			= e.number and		
		isnull(#asset_unload.idreg,0)		= isnull(e.idreg,0) and
		isnull(#asset_unload.idlocation,0)	= isnull(e.idlocation,0) and
		isnull(#asset_unload.idman,0)		= isnull(e.idman ,0)
		)
--------------------------------------------------------------------------------------
--------------------------------Scarichi accessori -----------------------------------
--------------------------------------------------------------------------------------	

CREATE TABLE #piece_unload
(
	idassetunloadkind int,
	yassetunload int ,
	nassetunload int ,
	idmot varchar(20) ,
	idinventoryagency int,
	idinventorykind int,
	doc varchar(35) ,
	docdate datetime ,
	description varchar(150) ,
	enactment varchar(150) ,
	enactmentdate datetime ,
	adate datetime ,
	printdate datetime ,
	operationorder int ,
	kind varchar(50) ,
	idinventory int,
	idasset int ,				
	idpiece int ,
	ninventory int ,			
	idinv varchar(36) ,
	assetdescription varchar(150) ,
	valoreunitario decimal(23,2) ,
	nassetacquire int ,
	number int ,
	idreg int,
	idlocation int,
	idman int,
	startnumber int,
	amortization decimal(23,6)
)


INSERT INTO #piece_unload
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
	startnumber,		
	idinv,
	assetdescription,
	valoreunitario,
	number,
	idreg,
	idlocation,
	idman
		
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
	assetview_current.start,
	1,    -- <-- QUANTITA'
	assetunload.idreg,	
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL)
FROM assetacquire
JOIN asset
	ON asset.nassetacquire = assetacquire.nassetacquire
JOIN  assetview_current  
	ON assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
JOIN asset as assetmain
	ON asset.idasset=assetmain.idasset
JOIN assetunload
	ON assetunload.idassetunload = asset.idassetunload
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
WHERE asset.idpiece>1
	and assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)
	AND assetmain.idpiece=1

--select 'Scarichi accessori', * from #piece_unload where kind = 'Scarico accessorio'
IF @official = 'S'
BEGIN
	UPDATE #asset_unload
	SET printdate = @printdate
	WHERE yassetunload = @ayear 
	AND nassetunload IN (SELECT num from #printing)
	AND printdate IS NULL
	
	UPDATE #piece_unload
	SET printdate = @printdate
	WHERE yassetunload = @ayear 
	AND nassetunload IN (SELECT num from #printing)
	AND printdate IS NULL
END
DECLARE @agencycode varchar(20)
SELECT @agencycode =  agencycode FROM license


UPDATE #piece_unload 
	set amortization = 
			ISNULL((SELECT SUM(amount) FROM #amortization
				WHERE  #amortization.idasset = #piece_unload.idasset
				AND    #amortization.idpiece = #piece_unload.idpiece),0) 
WHERE kind = 'Scarico Accessorio'

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
--select 'prima accorpamento number e amortization',* from #asset_unload

update #asset_unload set
number =  (select sum(number) from #asset_unload b where
		#asset_unload.idassetunloadkind = b.idassetunloadkind and 
		#asset_unload.yassetunload = b.yassetunload and
		#asset_unload.nassetunload = b.nassetunload and
		#asset_unload.startnumber  = b.startnumber 
	  )

--select 'dopo primo update',* from #asset_unload	
--select 'dopo accorpamento cespiti',* from #asset_unload


update #asset_unload 
       set amortization =  (select sum(amortization) from #asset_unload b where
				#asset_unload.idassetunloadkind = b.idassetunloadkind and 
				#asset_unload.yassetunload = b.yassetunload and
				#asset_unload.nassetunload = b.nassetunload and
				#asset_unload.startnumber = b.startnumber 
			   )

--select 'dopo secondo update',* from #asset_unload	


update #piece_unload set
number =  (select sum(number) from #piece_unload b where
		#piece_unload.idassetunloadkind = b.idassetunloadkind and 
		#piece_unload.yassetunload = b.yassetunload and
		#piece_unload.nassetunload = b.nassetunload and
		#piece_unload.startnumber  = b.startnumber and
		#piece_unload.assetdescription=b.assetdescription and
		isnull(#piece_unload.idmot,0) 		= isnull(b.idmot,0) and 
		#piece_unload.idinventoryagency 	= b.idinventoryagency and 
		isnull(#piece_unload.description,'') 	= isnull(b.description ,'')and 
		#piece_unload.idinventorykind 		= b.idinventorykind and 
		isnull(#piece_unload.doc,'') 		= isnull(b.doc ,'')and 
		isnull(#piece_unload.docdate,{d '1900-01-01'})= isnull(b.docdate,{d '1900-01-01'}) and 
		#piece_unload.operationorder		= b.operationorder and 
		isnull(#piece_unload.enactment,'') 	= isnull( b.enactment,'') and
		isnull(#piece_unload.enactmentdate,{d '1900-01-01'})= isnull(b.enactmentdate,{d '1900-01-01'}) and 
		#piece_unload.adate 			= b.adate and 
		isnull(#piece_unload.printdate,{d '1900-01-01'} )= isnull(b.printdate, {d '1900-01-01'} )and 
		#piece_unload.kind 			= b.kind and
		#piece_unload.idinventory 		= b.idinventory and
		#piece_unload.idinv 			= b.idinv and
		isnull(#piece_unload.assetdescription,'') = isnull(b.assetdescription,'') and
		#piece_unload.valoreunitario 		= b.valoreunitario and
		#piece_unload.number			= b.number and		
		isnull(#piece_unload.idreg,0)		= isnull(b.idreg,0) and
		isnull(#piece_unload.idlocation,0)	= isnull(b.idlocation,0) and
		isnull(#piece_unload.idman,0)		= isnull(b.idman ,0) 
		)

--select 'dopo terzo update',* from #asset_unload	

update #piece_unload 
	set amortization =  (select sum(amortization) from #piece_unload b where
				#piece_unload.idassetunloadkind = b.idassetunloadkind and 
				#piece_unload.yassetunload = b.yassetunload and
				#piece_unload.nassetunload = b.nassetunload and
				#piece_unload.startnumber  = b.startnumber and
				#piece_unload.assetdescription=b.assetdescription and
				isnull(#piece_unload.idmot,0) 		= isnull(b.idmot,0) and 
				#piece_unload.idinventoryagency 	= b.idinventoryagency and 
				isnull(#piece_unload.description,'') 	= isnull(b.description ,'')and 
				#piece_unload.idinventorykind 		= b.idinventorykind and 
				isnull(#piece_unload.doc,'') 		= isnull(b.doc ,'')and 
				isnull(#piece_unload.docdate,{d '1900-01-01'})= isnull(b.docdate,{d '1900-01-01'}) and 
				#piece_unload.operationorder		= b.operationorder and 
				isnull(#piece_unload.enactment,'') 	= isnull( b.enactment,'') and
				isnull(#piece_unload.enactmentdate,{d '1900-01-01'})= isnull(b.enactmentdate,{d '1900-01-01'}) and 
				#piece_unload.adate 			= b.adate and 
				isnull(#piece_unload.printdate,{d '1900-01-01'} )= isnull(b.printdate, {d '1900-01-01'} )and 
				#piece_unload.kind 			= b.kind and
				#piece_unload.idinventory 		= b.idinventory and
				#piece_unload.idinv 			= b.idinv and
				isnull(#piece_unload.assetdescription,'') = isnull(b.assetdescription,'') and
				#piece_unload.valoreunitario 		= b.valoreunitario and
				#piece_unload.number			= b.number and		
				isnull(#piece_unload.idreg,0)		= isnull(b.idreg,0) and
				isnull(#piece_unload.idlocation,0)	= isnull(b.idlocation,0) and
				isnull(#piece_unload.idman,0)		= isnull(b.idman ,0) 
)


--select 'dopo quarto update',* from #asset_unload	

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
	valoreunitario,
	nassetacquire,
	amortization,
	number,
	idreg,
	startnumber
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
	assetamortization.namortization,
	0,
	1,
	assetunload.idreg,	
	asset.ninventory
FROM assetunload
JOIN assetamortization
	ON assetunload.idassetunload = assetamortization.idassetunload
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset 
	ON asset.idasset = assetamortization.idasset
	AND asset.idpiece = assetamortization.idpiece
JOIN assetacquire
	ON asset.nassetacquire = assetacquire.nassetacquire
JOIN inventory
	ON assetacquire.idinventory = inventory.idinventory	
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
	valoreunitario ,
	nassetacquire,
	amortization,
	number,
	idreg,
	startnumber
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
	assetamortization.namortization,
	0,
	1,
	assetunload.idreg,	
	assetcespite.ninventory
FROM assetunload
JOIN assetamortization
	ON assetunload.idassetunload = assetamortization.idassetunload
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset 
	ON  asset.idasset = assetamortization.idasset
	AND asset.idpiece = assetamortization.idpiece
JOIN asset AS assetcespite 
	ON  asset.idasset = assetcespite.idasset
JOIN assetacquire
	ON asset.nassetacquire = assetacquire.nassetacquire
JOIN inventory
	ON assetacquire.idinventory = inventory.idinventory	
WHERE 	asset.idpiece >1 AND assetcespite.idpiece = 1 
	AND assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload IN (SELECT num from #printing)

IF @official = 'S'
	UPDATE #asset_unload
	SET printdate = @printdate
	WHERE yassetunload = @ayear 
	AND nassetunload IN (SELECT num from #printing)
	AND printdate IS NULL

SELECT DISTINCT
		#asset_unload.idassetunloadkind,			
		yassetunload,
		nassetunload,
		#asset_unload.idmot,
		MOTIVE.description as assetunloadmotive,
		REG.title as assetunloadregistry,
		#asset_unload.idinventoryagency,
		AGENCY.description as inventoryagency,
		#asset_unload.idinventorykind,
		INVKIND.description as inventorykind,
		doc,
		docdate,
		#asset_unload.description,
		enactment,
		enactmentdate,
		adate,
		printdate,
		operationorder,
		kind,
		#asset_unload.idinventory,
		#asset_unload.idinv ,
		INVTREE.codeinv ,
		assetdescription,
		valoreunitario,
		#asset_unload.amortization,
		number,
		'agencycode' = ISNULL(@agencycode ,''),
		#asset_unload.idlocation ,
		LOC.description as location ,
		#asset_unload.idman ,
		MAN.title as manager ,
		INVTREE.description AS inventorytree,
		#asset_unload.startnumber,
		AGENCY.title_l,   -- sezione firme
		AGENCY.name_l,
		AGENCY.title_c,
		AGENCY.name_c,
		AGENCY.title_r,
		AGENCY.name_r
FROM #asset_unload
LEFT OUTER JOIN inventoryagency AGENCY
	ON #asset_unload.idinventoryagency = AGENCY.idinventoryagency
LEFT OUTER JOIN inventorykind INVKIND
	ON INVKIND.idinventorykind = #asset_unload.idinventorykind
LEFT OUTER JOIN assetunloadmotive MOTIVE
	ON #asset_unload.idmot = MOTIVE.idmot
LEFT OUTER JOIN registry REG
	ON #asset_unload.idreg = REG.idreg
LEFT OUTER JOIN inventorytree INVTREE
	ON INVTREE.idinv = #asset_unload.idinv
LEFT OUTER JOIN location LOC
	ON LOC.idlocation = #asset_unload.idlocation
LEFT OUTER JOIN  manager MAN
	ON MAN.idman = #asset_unload.idman
-- ORDER BY nassetunload,startnumber,operationorder
UNION ALL
SELECT DISTINCT
		#piece_unload.idassetunloadkind,			
		yassetunload,
		nassetunload,
		#piece_unload.idmot,
		MOTIVE.description as assetunloadmotive,
		REG.title as assetunloadregistry,
		#piece_unload.idinventoryagency,
		AGENCY.description as inventoryagency,
		#piece_unload.idinventorykind,
		INVKIND.description as inventorykind,
		doc,
		docdate,
		#piece_unload.description,
		enactment,
		enactmentdate,
		adate,
		printdate,
		operationorder,
		kind,
		#piece_unload.idinventory,
		#piece_unload.idinv ,
		INVTREE.codeinv ,
		assetdescription,
		valoreunitario,
		#piece_unload.amortization,
		number,
		'agencycode' = ISNULL(@agencycode ,''),
		#piece_unload.idlocation ,
		LOC.description as location ,
		#piece_unload.idman ,
		MAN.title as manager ,
		INVTREE.description AS inventorytree,
		#piece_unload.startnumber,
		AGENCY.title_l,   -- sezione firme
		AGENCY.name_l,
		AGENCY.title_c,
		AGENCY.name_c,
		AGENCY.title_r,
		AGENCY.name_r
FROM #piece_unload
LEFT OUTER JOIN inventoryagency AGENCY
	ON #piece_unload.idinventoryagency = AGENCY.idinventoryagency
LEFT OUTER JOIN inventorykind INVKIND
	ON INVKIND.idinventorykind = #piece_unload.idinventorykind
LEFT OUTER JOIN assetunloadmotive MOTIVE
	ON #piece_unload.idmot = MOTIVE.idmot
LEFT OUTER JOIN registry REG
	ON #piece_unload.idreg = REG.idreg
LEFT OUTER JOIN inventorytree INVTREE
	ON INVTREE.idinv = #piece_unload.idinv
LEFT OUTER JOIN location LOC
	ON LOC.idlocation = #piece_unload.idlocation
LEFT OUTER JOIN  manager MAN
	ON MAN.idman = #piece_unload.idman
ORDER BY nassetunload, #asset_unload.startnumber,operationorder 
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--rpt_buono_scarico_rc 2014,'I',6,1,2,{d '2014-01-31'},'N'
