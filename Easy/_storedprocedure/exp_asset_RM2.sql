
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_asset_RM2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_asset_RM2]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE       PROCEDURE [exp_asset_RM2]
(
	@datebegin datetime,
	@dateend datetime,
	@idman int,
	@idinventoryagency int,
	@idinventory int
)
AS BEGIN
CREATE TABLE #pat
(
	ninventory int,
	idinventory varchar(20),-- voluto
	nasset_loadunload int,
	assetkind char(1),
	adate datetime,
	description varchar(150),
	opkind varchar(1),
	codeinv varchar(50),
	currentvalue decimal(28,2),
	manager varchar(150),
	description_dep varchar(150),
	idasset int,
	idpiece int
)

DECLARE	@departmentname varchar(150)
SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' and 
				(start is null or start <= @datebegin) and
				(stop is null or stop >= @datebegin)
				),'Manca Cfg. Parametri Tutte le stampe')

DECLARE @lencat int 
SELECT @lencat = codelen
FROM inventorysortinglevel 
WHERE nlevel= (SELECT MIN(nlevel) FROM inventorysortinglevel)
-- carico cespite
INSERT INTO #pat
(
	ninventory,
	idinventory,
	nasset_loadunload,
	assetkind,
	adate,
	description,
	opkind,
	codeinv,
	currentvalue,
	manager,
	description_dep,
	idasset,
	idpiece
)

SELECT
	asset.ninventory,
	idinventory =
	CASE 
		WHEN  (inventory.codeinventory LIKE '%lib%' OR inventory.codeinventory LIKE '%DepBook%') THEN 'L'
		WHEN  (inventory.codeinventory LIKE '%ord%' OR inventory.codeinventory LIKE '%Depmain%') THEN 'O'
	END,
	assetload.nassetload,
	'C',	-- Tipo Buono
	assetload.adate,
	assetacquire.description,
	'C',	-- Tipo operazione: carico
	codeinv,
	-- Valore Attuale
	CASE 
		WHEN -- con lo sconto
		( 
			(inventorykind.flag&1 <> 0
				AND (assetload.yassetload>=2005
				OR (assetacquire.idassetload IS NULL AND assetacquire.flag&2 <> 0)
				)
			)
			OR(inventorykind.flag&1 = 0 AND  assetload.yassetload<2005)
		)
		THEN
		ROUND(ISNULL(assetacquire.taxable, 0)
		  * (1 - CONVERT(decimal(19,3),ISNULL(assetacquire.discount,0))),2)
		  + ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
		  - ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)
		WHEN -- senza sconto
		(
			(inventorykind.flag&1 = 0
				AND (assetacquire.idassetload IS NULL OR assetload.yassetload>=2005))
				OR (inventorykind.flag&1 <> 0
					AND 
					((assetacquire.flag&2 = 0 AND assetacquire.idassetload is null)
					OR assetload.yassetload < 2005
				)	 
			) 
			
		)
		THEN
		ROUND(ISNULL(assetacquire.taxable, 0),2)
		  + ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
		  - ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)
	END,
	manager.title,
	inventoryagency.description,
	asset.idasset,
	asset.idpiece
FROM  assetload 
JOIN assetacquire 
	ON assetload.idassetload=assetacquire.idassetload
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
LEFT OUTER JOIN assetmanager	
	ON assetmanager.idasset = asset.idasset and assetmanager.start is null
left outer join manager
	on manager.idman = assetmanager.idman
JOIN inventorytree
	ON  inventorytree.idinv = assetacquire.idinv
JOIN inventory
	ON inventory.idinventory=assetacquire.idinventory 
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventoryagency							
	ON inventoryagency.idinventoryagency=inventory.idinventoryagency
JOIN inventorysortinglevel 
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
WHERE (assetacquire.idinventory = @idinventory or @idinventory IS NULL) 			
	AND (assetmanager.idman = @idman OR @idman IS NULL)
	AND (inventoryagency.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND (assetload.adate BETWEEN @datebegin AND @dateend)
	AND asset.idpiece = 1


-- carico accessorio
INSERT INTO #pat
(
	ninventory,
	idinventory,
	nasset_loadunload,
	assetkind,
	adate,
	description,
	opkind,
	codeinv,
	currentvalue,
	manager,
	description_dep,
	idasset,
	idpiece
)
SELECT 
	assetmain.ninventory,
	idinventory =
	CASE 
		WHEN  (inventory.codeinventory LIKE '%lib%' OR inventory.codeinventory LIKE '%DepBook%') THEN 'L'
		WHEN  (inventory.codeinventory LIKE '%ord%' OR inventory.codeinventory LIKE '%Depmain%') THEN 'O'
	END,
	assetload.nassetload,
	'C',	-- Tipo buono
	assetload.adate ,
	assetacquire.description,
	'A',	--'P',   Tipo operazione: carico accessorio. Per Roma è stato messo A
	codeinv,
	-- valore attuale
		ROUND(ISNULL(assetacquire.taxable, 0)
		  * (1 - CONVERT(decimal(19,3),ISNULL(assetacquire.discount,0))),2)
		  + ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
		  - ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2),
	-- fine calcolo valore attuale
	manager.title,
	inventoryagency.description,
	asset.idasset,
	asset.idpiece
FROM  assetload 
JOIN assetacquire 
	ON assetload.idassetload=assetacquire.idassetload
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN asset AS assetmain
	ON asset.idasset=assetmain.idasset
LEFT OUTER JOIN assetmanager	
	ON assetmanager.idasset = asset.idasset and start is null
left outer join manager 
	on manager.idman = assetmanager.idman
JOIN inventorytree
	ON inventorytree.idinv = assetacquire.idinv
JOIN inventory
	ON inventory.idinventory=assetacquire.idinventory 
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventoryagency							
	ON inventoryagency.idinventoryagency=inventory.idinventoryagency
JOIN inventorysortinglevel 
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
WHERE (assetacquire.idinventory = @idinventory or @idinventory IS NULL) 			
	AND(assetmanager.idman = @idman OR @idman IS NULL)
	AND(inventoryagency.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND (assetload.adate BETWEEN @datebegin AND @dateend)
	AND asset.idpiece>1
	AND assetmain.idpiece = 1


-- scarico cespite
INSERT INTO #pat
(
	ninventory,
	idinventory,
	nasset_loadunload,
	assetkind,
	adate,
	description,
	opkind,
	codeinv,
	currentvalue,
	manager,
	description_dep,
	idasset,
	idpiece
)
SELECT
	asset.ninventory,
	idinventory =
	CASE 
		WHEN  (inventory.codeinventory LIKE '%lib%' OR inventory.codeinventory LIKE '%DepBook%') THEN 'L'
		WHEN  (inventory.codeinventory LIKE '%ord%' OR inventory.codeinventory LIKE '%Depmain%') THEN 'O'
	END,
	assetunload.nassetunload,
	'S',	--Tipo buono
	assetunload.adate ,
	assetacquire.description,
	'S',	--Tipo operazione: scarico cespite
	codeinv,
	-- valore attuale
	CASE
		WHEN	-- con lo sconto
			 ( 
			   (inventorykind.flag&1 <> 0 AND 
				(assetload.yassetload>=2005 OR 
				   (assetacquire.idassetload is null and assetacquire.flag&2 <> 0)
				)
			   )
			   OR
			   (
			    inventorykind.flag&1 = 0 AND  assetload.yassetload<2005
			   )
			)
		THEN
		ROUND(ISNULL(assetacquire.taxable, 0)
		  * (1 - CONVERT(decimal(19,3),ISNULL(assetacquire.discount,0))),2)
		  + ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
		  - ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)
		WHEN -- senza sconto
		(
			   (inventorykind.flag&1 = 0 AND (assetacquire.idassetload is null or assetload.yassetload>=2005))
			    OR
			   (inventorykind.flag&1 <> 0 AND 
				((assetacquire.flag&2 = 0 AND assetacquire.idassetload is null)OR
				  assetload.yassetload < 2005
				)	 
			   ) 
			
		)
		THEN	
		ROUND(ISNULL(assetacquire.taxable, 0),2)
		  + ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
		  - ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)
	END,
	manager.title,
	inventoryagency.description,
	asset.idasset,
	asset.idpiece
FROM  assetunload 
JOIN asset
	ON assetunload.idassetunload=asset.idassetunload
JOIN assetacquire
	ON assetacquire.nassetacquire = asset.nassetacquire
left outer join assetload
	on assetload.idassetload = assetacquire.idassetload
LEFT OUTER JOIN assetmanager	
	ON assetmanager.idasset = asset.idasset and assetmanager.start is null
left outer join manager
	on manager.idman = assetmanager.idman
JOIN inventorytree
	ON inventorytree.idinv = assetacquire.idinv
JOIN inventory
	ON inventory.idinventory=assetacquire.idinventory 
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventoryagency							
	ON inventoryagency.idinventoryagency=inventory.idinventoryagency					
JOIN inventorysortinglevel 
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
WHERE (assetacquire.idinventory = @idinventory or @idinventory IS NULL )			
	AND (assetmanager.idman = @idman OR @idman IS NULL)
	AND (inventoryagency.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND (assetunload.adate BETWEEN @datebegin AND @dateend)
	AND asset.idpiece=1


--scarico accessorio
INSERT INTO #pat
(
	ninventory,
	idinventory,
	nasset_loadunload,
	assetkind,
	adate,
	description,
	opkind,
	codeinv,
	currentvalue,
	manager,
	description_dep,
	idasset,
	idpiece
)
SELECT
	assetmain.ninventory,
	idinventory =
	CASE 
		WHEN  (inventory.codeinventory LIKE '%lib%' OR inventory.codeinventory LIKE '%DepBook%') THEN 'L'
		WHEN  (inventory.codeinventory LIKE '%ord%' OR inventory.codeinventory LIKE '%Depmain%') THEN 'O'
	END,
	assetunload.nassetunload,
	'S',	-- Tipo buono
	assetunload.adate ,
	assetacquire.description,
	'D',	--'P',	Tipo operazione:scarico accessorio. Per Roma è stato messo D
	codeinv,
	ROUND(ISNULL(assetacquire.taxable, 0)
	  * (1 - CONVERT(decimal(19,3),ISNULL(assetacquire.discount,0))),2)
	  + ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
	  - ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)
	,	
	manager.title,
	inventoryagency.description,
	asset.idasset, 
	asset.idpiece
FROM  assetunload 
JOIN asset
	ON assetunload.idassetunload=asset.idassetunload
JOIN asset AS assetmain
	ON asset.idasset=assetmain.idasset
JOIN assetacquire							
	ON assetacquire.nassetacquire=asset.nassetacquire		
LEFT OUTER JOIN assetmanager								
	ON assetmanager.idasset = asset.idasset and assetmanager.start is null
left outer join manager
	on manager.idman = assetmanager.idman
JOIN inventorytree
	ON inventorytree.idinv = assetacquire.idinv
JOIN inventory
	ON inventory.idinventory=assetacquire.idinventory 
JOIN inventoryagency							
	ON inventoryagency.idinventoryagency=inventory.idinventoryagency					
JOIN inventorysortinglevel 
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
WHERE  (assetacquire.idinventory = @idinventory or @idinventory IS NULL) 			
	AND (assetmanager.idman = @idman OR @idman IS NULL)
	AND (inventoryagency.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND (assetunload.adate BETWEEN @datebegin AND @dateend)
	AND assetmain.idpiece=1
	AND asset.idpiece>1

--RIVALUTAZIONI / SVALUTAZIONI CESPITI E ACCESSORI SCARICATI
update #pat 
	SET currentvalue= isnull(currentvalue,0) +
	ISNULL((SELECT
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))

	FROM assetamortization
	left outer join assetunload
		on assetunload.idassetunload = assetamortization.idassetunload
	JOIN inventoryamortization
		ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
	WHERE assetamortization.idasset = #pat.idasset and
		assetamortization.idpiece = #pat.idpiece
		AND inventoryamortization.flag&2 <> 0
		AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
	            (
		     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
	             (assetamortization.flag&1 = 0 OR 
		      (assetunload.yassetunload is not null))
		     )
		    )
		), 0.0)
	WHERE #pat.opkind in ('S','D') --scarichi cespiti e accessori

		
-------------------------------------------------------------------------------------------------
------ CARICHI ACCESSORI  DI CESPITI SCARICATI
-------------------------------------------------------------------------------------------------

UPDATE #pat
	SET currentvalue = ISNULL(currentvalue, 0.0) +
	ISNULL((SELECT 
	SUM(
	ROUND(ISNULL(caricoaccessorio.taxable, 0)
	* (1 - CONVERT(decimal(19,6),ISNULL(caricoaccessorio.discount, 0))),2)
	+ ROUND(ISNULL(caricoaccessorio.tax,0) / caricoaccessorio.number,2)
	- ROUND(ISNULL(caricoaccessorio.abatable,0) / caricoaccessorio.number,2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	WHERE 
		accessorio.idpiece > 1 and
		accessorio.idasset = #pat.idasset 
		AND (caricoaccessorio.idassetload is not null )
		),0.0)
	WHERE #pat.opkind='S'


-------------------------------------------------------------------------------------------------
------ RIVALUTAZIONI DEGLI ACCESSORI DEI CESPITI SCARICATI
-------------------------------------------------------------------------------------------------

UPDATE #pat
	SET currentvalue = ISNULL(currentvalue, 0.0) +
	ISNULL((SELECT
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
    
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN assetamortization
		ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	WHERE accessorio.idasset = #pat.idasset and
		assetamortization.idpiece > 1
		AND inventoryamortization.flag&2 <> 0
		AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
	            (
		     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
	             (assetamortization.flag&1 = 0 OR 
		      (assetamortization.idassetunload is not null))
		     )
		    )
		AND (caricoaccessorio.idassetload is not null)
		), 0.0)
	WHERE #pat.opkind='S'



-------------------------------------------------------------------------------------------------
------ SCARICHI ACCESSORI  DI CESPITI SCARICATI
-------------------------------------------------------------------------------------------------

	UPDATE #pat
	SET currentvalue = ISNULL(currentvalue, 0.0) -
	ISNULL((SELECT 
	SUM(
	ROUND(ISNULL(caricoaccessorio.taxable, 0)
	* (1 - CONVERT(decimal(19,6),ISNULL(caricoaccessorio.discount, 0))),2)
	+ ROUND(ISNULL(caricoaccessorio.tax,0) / caricoaccessorio.number,2)
	- ROUND(ISNULL(caricoaccessorio.abatable,0) / caricoaccessorio.number,2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	WHERE 
		accessorio.idpiece > 1 and
		accessorio.idasset = #pat.idasset 
		AND (accessorio.idassetunload is not null or accessorio.flag&1 = 0) 
		),0.0)
	WHERE #pat.opkind='S'


-------------------------------------------------------------------------------------------------
------ RIVALUTAZIONI DEGLI ACCESSORI SCARICATI DEI CESPITI SCARICATI
-------------------------------------------------------------------------------------------------

	UPDATE #pat
	SET currentvalue = ISNULL(currentvalue, 0.0) -
	ISNULL((SELECT
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))

	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN assetamortization
		ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	WHERE accessorio.idasset = #pat.idasset and
		assetamortization.idpiece > 1
		AND inventoryamortization.flag&2 <> 0
		AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
	            (
		     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
	             ((assetamortization.flag&1 = 0) OR 
		      (assetamortization.idassetunload is not null))
		     )
		    )
		AND (accessorio.idassetunload is not null or accessorio.flag&1 = 0) 
		), 0.0)
	WHERE #pat.opkind='S'

-- ammortamenti per CESPITI PRINCIPALI
INSERT INTO #pat
(
	ninventory,
	idinventory,
	nasset_loadunload,
	assetkind,
	adate,
	description,
	opkind,
	codeinv,
	currentvalue,
	manager,
	description_dep,
	idasset,
	idpiece
)
SELECT
	asset.ninventory,
	idinventory =
	CASE 
		WHEN  (inventory.codeinventory LIKE '%lib%' OR inventory.codeinventory LIKE '%DepBook%') THEN 'L'
		WHEN  (inventory.codeinventory LIKE '%ord%' OR inventory.codeinventory LIKE '%Depmain%') THEN 'O'
	END,
	assetunload.nassetunload,
	'S',	--Tipo buono
	assetamortization.adate ,
	assetacquire.description,
	'D',	--Tipo operazione: ammortamento cespite
	codeinv,
	-- valore ammortizzato
	ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2),
	manager.title,
	inventoryagency.description,
	asset.idasset,
	asset.idpiece
FROM asset
JOIN assetacquire
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization
		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload
		ON  assetamortization.idassetunload = assetunload.idassetunload
JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
LEFT OUTER JOIN assetmanager	
	ON assetmanager.idasset = asset.idasset and assetmanager.start is null
left outer join manager
	on manager.idman = assetmanager.idman
JOIN inventorytree
	ON inventorytree.idinv = assetacquire.idinv
JOIN inventory
	ON inventory.idinventory=assetacquire.idinventory 
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventoryagency							
	ON inventoryagency.idinventoryagency=inventory.idinventoryagency					
JOIN inventorysortinglevel 
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
WHERE (assetacquire.idinventory = @idinventory or @idinventory IS NULL )			
	AND (manager.idman = @idman OR @idman IS NULL)
	AND (inventoryagency.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND asset.idpiece=1
	AND inventoryamortization.flag&2 <> 0
	AND ((assetamortization.amortizationquota >0 AND assetamortization.adate BETWEEN @datebegin AND @dateend) OR
	     (assetamortization.amortizationquota <0 AND 
	     (
	      (assetamortization.flag&1 = 0 AND assetamortization.adate BETWEEN @datebegin AND @dateend) OR 
	      (assetamortization.flag&1 <> 0 AND assetunload.adate BETWEEN @datebegin AND @dateend))
	      )
	     )

-- ammortamenti per ACCESSORI
INSERT INTO #pat
(
	ninventory,
	idinventory,
	nasset_loadunload,
	assetkind,
	adate,
	description,
	opkind,
	codeinv,
	currentvalue,
	manager,
	description_dep,
	idasset,
	idpiece
)
SELECT
	assetmain.ninventory,
	idinventory =
	CASE 
		WHEN  (inventory.codeinventory LIKE '%lib%' OR inventory.codeinventory LIKE '%DepBook%') THEN 'L'
		WHEN  (inventory.codeinventory LIKE '%ord%' OR inventory.codeinventory LIKE '%Depmain%') THEN 'O'
	END,
	assetunload.nassetunload,
	'S',	--Tipo buono
	assetamortization.adate ,
	assetacquire.description,
	'D',	--Tipo operazione: ammortamento accessorio
	codeinv,
	-- valore ammortizzato
	 ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2),
	manager.title,
	inventoryagency.description,
	asset.idasset,
	asset.idpiece
FROM  asset
JOIN assetacquire
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN asset AS assetmain
	ON asset.idasset=assetmain.idasset
JOIN assetamortization
		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload
		ON  assetamortization.idassetunload = assetunload.idassetunload
JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
LEFT OUTER JOIN assetmanager	
	ON assetmanager.idasset = asset.idasset and assetmanager.start is null
left outer join manager
	on manager.idman = assetmanager.idman
JOIN inventorytree
	ON inventorytree.idinv = assetacquire.idinv
JOIN inventory
	ON inventory.idinventory=assetacquire.idinventory 
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventoryagency							
	ON inventoryagency.idinventoryagency=inventory.idinventoryagency					
JOIN inventorysortinglevel 
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
WHERE (assetacquire.idinventory = @idinventory or @idinventory IS NULL )			
	AND (assetmanager.idman = @idman OR @idman IS NULL)
	AND (inventoryagency.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND asset.idpiece>1
	AND assetmain.idpiece=1
	AND inventoryamortization.flag&2 <> 0
	AND ((assetamortization.amortizationquota >0 AND assetamortization.adate BETWEEN @datebegin AND @dateend) OR
	     (assetamortization.amortizationquota <0 AND 
	     (
	      (assetamortization.flag&1 = 0 AND assetamortization.adate BETWEEN @datebegin AND @dateend) OR 
	      (assetamortization.flag&1 <> 0 AND assetunload.adate BETWEEN @datebegin AND @dateend))
	      )
	     )

	
SELECT  
	@departmentname AS 'Nome Struttura',
	ninventory AS Inventario,
	SUBSTRING(idinventory,1,1) AS 'Tipo Inventario',
	nasset_loadunload AS Buono,
	assetkind AS 'Tipo Buono', 
	CONVERT(varchar(12),adate,105) AS Data,
	description AS Descrizione,
	opkind AS 'Tipo Operazione',
	SUBSTRING(codeinv,1,@lencat) AS Categoria,
	currentvalue AS 'Valore Attuale'
FROM #pat
ORDER BY idinventory,nasset_loadunload
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
