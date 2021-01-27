
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_sitpatrim_ente_diminuzioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_sitpatrim_ente_diminuzioni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE      PROCEDURE [exp_sitpatrim_ente_diminuzioni]
	@year int,
	@codinventoryagency int,
	@date datetime,
	@idinv int
AS BEGIN
DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)

CREATE TABLE #diminuzioni
(
	operationkind varchar(100),
	nassetacquire int,
	adate datetime,
	description varchar(300),
	import decimal(19,2),
	ninventory int,
	yassetunload int,
	nassetunload int,
	ratificationdate datetime,
	idinv int
)


-------------------------------------------------------------------------------------
-------- Rivalutazioni Negative ufficiali  (di BENI E DI ACCESSORI)
-------------------------------------------------------------------------------------
INSERT INTO #diminuzioni(operationkind,nassetacquire,adate,description,import,ninventory ,idinv)
SELECT
	'Rivalutazioni Negative uff',
	assetacquire.nassetacquire,
	assetacquire.adate,
	assetacquire.description,
	-1 * (ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2) ),
	CASE asset.idpiece WHEN 1 THEN asset.ninventory
		ELSE assetacquire.startnumber 
	END,
	assetacquire.idinv
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
WHERE  
	((assetacquire.flag & 1 <> 1) OR assetacquire.idassetload IS NOT NULL)
	AND inventorytreelink.nlevel = 1
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
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)


-------------------------------------------------------------------------------------
-------------------------- Carichi accessori di beni scaricati ----------------------
-------------------------------------------------------------------------------------
INSERT INTO #diminuzioni(operationkind,nassetacquire,adate,description,import,ninventory, yassetunload, nassetunload,idinv)
SELECT
	'Scarichi Accessori',
	caricoaccessorio.nassetacquire,
	caricoaccessorio.adate,
	caricoaccessorio.description,
	assetview_current.start,
	caricoaccessorio.startnumber,
	assetunload.yassetunload,
	assetunload.nassetunload,
	caricoaccessorio.idinv
FROM assetacquire as caricoaccessorio 
JOIN asset as accessorio 
	ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN asset as cespite
	ON cespite.idasset = accessorio.idasset
JOIN assetview_current  
	ON assetview_current.idasset=accessorio.idasset and assetview_current.idpiece=accessorio.idpiece
JOIN assetunload
	ON assetunload.idassetunload = cespite.idassetunload	
JOIN inventory
	ON caricoaccessorio.idinventory = inventory.idinventory
JOIN inventorytreelink
	ON inventorytreelink.idchild = caricoaccessorio.idinv
WHERE 	accessorio.idpiece>1 
	and cespite.idpiece =1
	AND inventorytreelink.nlevel = 1
	AND (caricoaccessorio.idassetload IS NOT NULL)
	AND assetunload.yassetunload <= @year
	AND assetunload.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)

-------------------------------------------------------------------------------------
--RIVALUTAZIONI POSITIVE di Accessori di beni scaricati -----------------------------
-------------------------------------------------------------------------------------
INSERT INTO #diminuzioni(operationkind,nassetacquire,adate,description,import,ninventory, yassetunload, nassetunload,idinv)
SELECT
	'Rivalutazioni Positive Accessori di beni scaricati',
	caricoaccessorio.nassetacquire,
	caricoaccessorio.adate,
	caricoaccessorio.description,
	ROUND(ISNULL(assetamortization.assetvalue,0) * 
		  ISNULL(assetamortization.amortizationquota,0),2),
	CASE accessorio.idpiece WHEN  1 THEN accessorio.ninventory
		ELSE caricoaccessorio.startnumber 
	END,
	scaricocespite.yassetunload,
	scaricocespite.nassetunload,
	caricoaccessorio.idinv	
FROM assetacquire as caricoaccessorio
JOIN asset as accessorio 
	ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN asset as cespite
	ON cespite.idasset = accessorio.idasset
JOIN assetunload as scaricocespite
	ON scaricocespite.idassetunload = cespite.idassetunload
JOIN inventory
	ON caricoaccessorio.idinventory = inventory.idinventory
JOIN assetamortization
	ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink
	ON inventorytreelink.idchild = caricoaccessorio.idinv
WHERE 	accessorio.idpiece>1 AND cespite.idpiece =1
	AND inventorytreelink.nlevel = 1
	AND (caricoaccessorio.idassetload IS NOT NULL)
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota >=0
	AND scaricocespite.yassetunload <= @year
	AND scaricocespite.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)
	
--------------------------------------------------------------------------------------------
--RIVALUTAZIONI NEGATIVE di  Accessori di beni scaricati ----------------------------------- 
------------------(da collegare a Carichi accessori di beni scaricati) ---------------------
--------------------------------------------------------------------------------------------
INSERT INTO #diminuzioni(operationkind,nassetacquire,adate,description,import,ninventory, yassetunload, nassetunload,idinv)
	SELECT
	'Rivalutazioni Negative di Accessori di beni scaricati',
	caricoaccessorio.nassetacquire,
	caricoaccessorio.adate,
	caricoaccessorio.description,
	ROUND(ISNULL(assetamortization.assetvalue,0) * 
		  ISNULL(assetamortization.amortizationquota,0),2),
	CASE accessorio.idpiece WHEN  1 THEN accessorio.ninventory
		ELSE caricoaccessorio.startnumber 
	END,
	scaricocespite.yassetunload,
	scaricocespite.nassetunload,
	caricoaccessorio.idinv
	
FROM assetacquire as caricoaccessorio
JOIN asset as accessorio 
	ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN asset as cespite
	ON cespite.idasset = accessorio.idasset
JOIN assetunload as scaricocespite
	ON scaricocespite.idassetunload = cespite.idassetunload
JOIN inventory
	ON caricoaccessorio.idinventory = inventory.idinventory
JOIN assetamortization
	ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink
	ON inventorytreelink.idchild = caricoaccessorio.idinv
WHERE accessorio.idpiece>1 AND cespite.idpiece = 1
	AND inventorytreelink.nlevel = 1
	AND (caricoaccessorio.idassetload IS NOT NULL)
	AND 
	(
	    (assetamortization.flag & 1 <> 1) OR 
	    (assetamortization.idassetunload IS NOT NULL)
	)
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0
	AND scaricocespite.yassetunload <= @year
	AND scaricocespite.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)

--------------------------------------------------------------------------------------
-------------------------- Scarichi Cespite ------------------------------------------
--------------------------------------------------------------------------------------
INSERT INTO #diminuzioni(operationkind,nassetacquire,adate,description,import,ninventory, yassetunload, nassetunload,idinv)
SELECT
	'Scarichi Cespite',
	assetacquire.nassetacquire,
	assetacquire.adate,
	assetacquire.description,
	assetview_current.start,
	asset.ninventory,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetacquire.idinv
FROM assetacquire
LEFT OUTER JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current  
	ON assetview_current.idasset=asset.idasset AND	 assetview_current.idpiece=asset.idpiece
JOIN assetunload
	ON assetunload.idassetunload = asset.idassetunload
JOIN inventory
	ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
WHERE asset.idpiece = 1 
	AND inventorytreelink.nlevel = 1
	AND assetunload.yassetunload <= @year
	AND assetunload.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)

-------------------------------------------------------------------------------------
-------------------------- Scarichi Accessori----------------------------------------
-------------------------------------------------------------------------------------
INSERT INTO #diminuzioni(operationkind,nassetacquire,adate,description,import,ninventory, yassetunload, nassetunload,idinv)
SELECT

	'Scarichi Accessori',
	caricoaccessorio.nassetacquire,
	caricoaccessorio.adate,
	caricoaccessorio.description,
	assetview_current.start,
	CASE accessorio.idpiece WHEN  1 THEN accessorio.ninventory
		ELSE caricoaccessorio.startnumber 
	END,
	buonoscaricoaccessorio.yassetunload,
	buonoscaricoaccessorio.nassetunload,
	caricoaccessorio.idinv
FROM assetacquire as caricoaccessorio
JOIN asset as accessorio 
	ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN  assetview_current  
	ON assetview_current.idasset=accessorio.idasset and assetview_current.idpiece=accessorio.idpiece
JOIN assetunload as buonoscaricoaccessorio
	ON buonoscaricoaccessorio.idassetunload = accessorio.idassetunload
JOIN inventory
	ON caricoaccessorio.idinventory = inventory.idinventory
JOIN inventorytreelink
	ON inventorytreelink.idchild = caricoaccessorio.idinv
WHERE accessorio.idpiece >1 
	AND inventorytreelink.nlevel = 1
	AND buonoscaricoaccessorio.yassetunload <= @year
	AND buonoscaricoaccessorio.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)
-------------------------------------------------------------------------------------
--Rivalutazioni  (POSITIVE E NEGATIVE) ufficiali di beni e accessori scaricati ---
-------------------------------------------------------------------------------------
INSERT INTO #diminuzioni(operationkind,nassetacquire,adate,description,import,ninventory, yassetunload, nassetunload,idinv)
SELECT

	'Rivalutazioni di beni e accessori scaricati',
	assetacquire.nassetacquire,
	assetacquire.adate,
	assetacquire.description,
	ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2),
	CASE asset.idpiece WHEN  1 THEN asset.ninventory
		ELSE assetacquire.startnumber 
	END,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetacquire.idinv
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetunload
	ON assetunload.idassetunload = asset.idassetunload
JOIN assetamortization
	ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
WHERE  
	(inventoryamortization.flag & 2 <> 0)
	AND inventorytreelink.nlevel = 1
	AND assetamortization.amortizationquota >= 0
	AND assetunload.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)

INSERT INTO #diminuzioni(operationkind,nassetacquire,adate,description,import,ninventory, yassetunload, nassetunload,idinv)
SELECT
	'Rivalutazioni di beni e accessori scaricati',
	assetacquire.nassetacquire,
	assetacquire.adate,
	assetacquire.description,
		ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2),
	CASE asset.idpiece WHEN  1 THEN asset.ninventory
		ELSE assetacquire.startnumber 
	END,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetacquire.idinv
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetunload
	ON assetunload.idassetunload = asset.idassetunload
JOIN assetamortization
	ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
WHERE  
	(
	    (assetamortization.flag & 1 <> 1) OR 
	    (assetamortization.idassetunload IS NOT NULL)  
	)
	AND inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0
	AND assetunload.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)

-------------------------------------------------------------------------------------
---Scarichi Accessori di beni scaricati ----------------------------------------
-------------------------------------------------------------------------------------
INSERT INTO #diminuzioni(operationkind,nassetacquire,adate,description,import,ninventory, yassetunload, nassetunload,idinv)
SELECT

	'Scarichi accessori di beni scaricati',
	caricoaccessorio.nassetacquire,
	caricoaccessorio.adate,
	caricoaccessorio.description,
	-1 * assetview_current.start,
	CASE accessorio.idpiece WHEN  1 THEN accessorio.ninventory
		ELSE caricoaccessorio.startnumber 
	END,
	scaricocespite.yassetunload,
	scaricocespite.nassetunload,
	caricoaccessorio.idinv
FROM assetacquire as caricoaccessorio
JOIN asset as accessorio 
	ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN asset as cespite
	ON cespite.idasset = accessorio.idasset
JOIN assetview_current  
	ON assetview_current.idasset=accessorio.idasset and assetview_current.idpiece=accessorio.idpiece
JOIN assetunload as scaricocespite
	ON scaricocespite.idassetunload = cespite.idassetunload
JOIN inventory
	ON caricoaccessorio.idinventory = inventory.idinventory
JOIN inventorytreelink
	ON inventorytreelink.idchild = caricoaccessorio.idinv
WHERE accessorio.idpiece>1 and cespite.idpiece =1
	AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 <> 1)) 
	AND inventorytreelink.nlevel = 1
	AND scaricocespite.yassetunload <= @year
	AND scaricocespite.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)

-------------------------------------------------------------------------------------
--RIVALUTAZIONI POSITIVE E NEGATIVE di Accessori SCARICATI di beni scaricati ----------------------------------------
-------------------------------------------------------------------------------------

INSERT INTO #diminuzioni(operationkind,nassetacquire,adate,description,import,ninventory, yassetunload, nassetunload,idinv)
SELECT

	'Rivalutazioni Positive e Negativedi Accessori Scaricati di beni scaricati',
	caricoaccessorio.nassetacquire,
	caricoaccessorio.adate,
	caricoaccessorio.description,
	-1 *(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),
	CASE accessorio.idpiece WHEN  1 THEN accessorio.ninventory
		ELSE caricoaccessorio.startnumber 
	END,
	scaricocespite.yassetunload,
	scaricocespite.nassetunload,
	caricoaccessorio.idinv

FROM assetacquire as caricoaccessorio
JOIN asset as accessorio 
	ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN asset as cespite
	ON cespite.idasset = accessorio.idasset
JOIN assetunload as scaricocespite
	ON scaricocespite.idassetunload = cespite.idassetunload
JOIN inventory
	ON caricoaccessorio.idinventory = inventory.idinventory
JOIN assetamortization
	ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink
	ON inventorytreelink.idchild = caricoaccessorio.idinv
WHERE 	accessorio.idpiece>1 	and cespite.idpiece =1
	AND inventorytreelink.nlevel = 1
	AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 <> 1)) 
	AND assetamortization.amortizationquota>= 0
	AND (inventoryamortization.flag & 2 <> 0)
	AND scaricocespite.yassetunload <= @year
	AND scaricocespite.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)


INSERT INTO #diminuzioni(operationkind,nassetacquire,adate,description,import,ninventory, yassetunload, nassetunload,idinv)
SELECT
	'Rivalutazioni Positive e Negativedi Accessori Scaricati di beni scaricati',
	caricoaccessorio.nassetacquire,
	caricoaccessorio.adate,
	caricoaccessorio.description,
	-1 * (ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),
	CASE accessorio.idpiece WHEN  1 THEN accessorio.ninventory
		ELSE caricoaccessorio.startnumber 
	END,
	scaricocespite.yassetunload,
	scaricocespite.nassetunload,
	caricoaccessorio.idinv

FROM assetacquire as caricoaccessorio
JOIN asset as accessorio 
	ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN asset as cespite
	ON cespite.idasset = accessorio.idasset
JOIN assetunload as scaricocespite
	ON scaricocespite.idassetunload = cespite.idassetunload
JOIN inventory
		ON caricoaccessorio.idinventory = inventory.idinventory
JOIN assetamortization
	ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink
	ON inventorytreelink.idchild = caricoaccessorio.idinv
WHERE accessorio.idpiece>1 	and cespite.idpiece =1
	AND inventorytreelink.nlevel = 1
	AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 <> 1)) 
	AND 
	(
	    (assetamortization.flag & 1 <> 1) OR 
	    (assetamortization.idassetunload IS NOT NULL) 
	)
	AND assetamortization.amortizationquota < 0
	AND (inventoryamortization.flag & 2 <> 0)
	AND scaricocespite.yassetunload <= @year
	AND scaricocespite.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)


SELECT  #diminuzioni.operationkind AS 'Tipo Operazione',
	#diminuzioni.nassetacquire AS 'Num Carico Cespite',
	#diminuzioni.adate AS 'Data Contabile',
	#diminuzioni.description AS 'Descrizione',
	#diminuzioni.import AS 'Importo',
	#diminuzioni.ninventory AS 'Numero Inventario',
	#diminuzioni.yassetunload AS 'Esercizio Buono',
	#diminuzioni.nassetunload AS 'Numero Buono',
	#diminuzioni.ratificationdate AS 'Data Ratifica',
	inventorytree.codeinv AS 'Cod. Class.' ,
	inventorytree.description AS 'Classificazione'
FROM #diminuzioni
	JOIN inventorytree
		ON #diminuzioni.idinv = inventorytree.idinv

END







GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

