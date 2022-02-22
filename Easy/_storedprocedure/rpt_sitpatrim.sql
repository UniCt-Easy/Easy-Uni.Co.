
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitpatrim]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitpatrim]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--setuser 'amministrazione'
--EXEC [rpt_sitpatrim] NULL, NULL, NULL, NULL, NULL,9,'2016-01-01','2016-12-31','S'

CREATE  PROCEDURE [rpt_sitpatrim]
	@nlevellocation	tinyint,
	@idlocation varchar(50), -- Questo par. indica il codice dell'ubicazione e non l'ID
	@idmanager int,
	@nlevelinvtree tinyint,
	@codeinv varchar(50),
	@idinventory int,
	@start datetime,	/* questo parametro è meglio ignorarlo */
	@stop datetime,
	@situationkind char(19)
AS BEGIN

CREATE TABLE #sit_cespiti
(
	yassetload int,
	flagload char(1),
	idinventory int,
	ninventory int,
	idasset int,
	idinv int,
	idlocation int,
	idmanager int,
	idassetunload int,
	idassetunloadkind int,
	yassetunload smallint,
	nassetunload int,
	flagunload char(1),
	state varchar(150),
	currentvalue decimal(28,2),
	originalamount decimal (19,2),
	payment varchar(100)
)

	------------------------------------------------------------
	------------------- ubicazione------------------------------
	------------------------------------------------------------
IF (@situationkind = 'U')
BEGIN
	INSERT INTO #sit_cespiti
	(
		yassetload,
		flagload,
		idinventory,
		ninventory,
		idasset,
		idinv,
		idlocation,
		idmanager,
		idassetunload,
		idassetunloadkind,
		yassetunload,  
		nassetunload,
		flagunload,
		state,
		currentvalue
	)
	SELECT
		assetload.yassetload,
		CASE
			WHEN assetacquire.flag & 1 <> 0 THEN 'S'
			ELSE 'N'
		END,
		assetacquire.idinventory, 
		asset.ninventory,
		asset.idasset, 
		assetacquire.idinv, 
		location.idlocation,
		manager.idman,
		asset.idassetunload,
		assetunload.idassetunloadkind,
		assetunload.yassetunload, 
		assetunload.nassetunload,
		CASE
			WHEN asset.flag & 1 <> 0 THEN 'S'
			ELSE 'N'
		END,
		'In carico',
		AC.start

	FROM asset 
	join  assetview_current AC
		on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece
	LEFT OUTER JOIN assetunload
		ON assetunload.idassetunload = asset.idassetunload
	JOIN assetacquire 
		ON assetacquire.nassetacquire = asset.nassetacquire
	LEFT OUTER JOIN assetload
		ON assetload.idassetload = assetacquire.idassetload
	JOIN inventory 
		ON inventory.idinventory = assetacquire.idinventory
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind   
	LEFT OUTER JOIN inventorytree  -->>
		ON inventorytree.idinv = assetacquire.idinv -->>
	LEFT OUTER JOIN location
		ON location.idlocation = 
		(SELECT TOP 1 idlocation
			FROM assetlocation WHERE assetlocation.idasset = asset.idasset
			ORDER BY start desc)
	LEFT OUTER JOIN manager
		ON manager.idman = 
			(SELECT TOP 1 idman
				FROM assetmanager
				WHERE assetmanager.idasset = asset.idasset
				ORDER BY start desc)
		
	WHERE 	asset.idpiece = 1 
		AND (location.nlevel >= @nlevellocation OR @nlevellocation IS NULL)
		AND (location.locationcode LIKE @idlocation +'%' OR @idlocation IS NULL)
		AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
		AND assetacquire.adate <= @stop
		AND (inventorytree.nlevel >= @nlevelinvtree or @nlevelinvtree IS NULL)-->>
		AND (inventorytree.codeinv LIKE @codeinv +'%' OR @codeinv IS NULL)	-->>
		AND ( @idinventory is not null OR ( (inventorykind.flag&2)=0) )
END

------------------------------------------------------------
------------------- RESPONSABILE----------------------------
------------------------------------------------------------
IF (@situationkind = 'R')
BEGIN
	INSERT INTO #sit_cespiti
	(
		yassetload,
		flagload,
		idinventory,
		ninventory,
		idasset,
		idinv,
		idlocation,
		idmanager,
		idassetunload,
		idassetunloadkind,
		yassetunload,
		nassetunload,
		flagunload,
		state,
		currentvalue
	)
	SELECT
		assetload.yassetload,
		CASE
			WHEN assetacquire.flag & 1 <> 0 THEN 'S'
			ELSE 'N'
		END,
		assetacquire.idinventory,  
		asset.ninventory,
		asset.idasset, 
		assetacquire.idinv, 
		location.idlocation,
		manager.idman,
		asset.idassetunload,
		assetunload.idassetunloadkind,
		assetunload.yassetunload, 
		assetunload.nassetunload,
		CASE
			WHEN asset.flag & 1 <> 0 THEN 'S'
			ELSE 'N'
		END,
		'In carico',
		AC.start
	FROM asset 
	join  assetview_current AC
		on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece
	LEFT OUTER JOIN assetunload
		ON assetunload.idassetunload = asset.idassetunload
	JOIN assetacquire 
		ON assetacquire.nassetacquire = asset.nassetacquire
	LEFT OUTER JOIN assetload
		ON assetload.idassetload = assetacquire.idassetload
	JOIN inventory 
		ON inventory.idinventory = assetacquire.idinventory
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind   
	LEFT OUTER JOIN location
		ON location.idlocation = 
		(SELECT TOP 1 idlocation
			FROM assetlocation WHERE assetlocation.idasset = asset.idasset
			ORDER BY start desc)
	LEFT OUTER JOIN manager
		ON manager.idman = 
			(SELECT TOP 1 idman
				FROM assetmanager
				WHERE assetmanager.idasset = asset.idasset
				ORDER BY start desc)
	WHERE asset.idpiece = 1
		AND (manager.idman = @idmanager OR @idmanager IS NULL)
		AND (assetacquire.idinventory = @idinventory or @idinventory IS NULL) -- Sara
		AND assetacquire.adate  <= @stop
		AND ( @idinventory is not null OR ( (inventorykind.flag&2)=0) )
END

------------------------------------------------------------
------------------- SUBCONSEGNATARIO----------------------------
------------------------------------------------------------
IF (@situationkind = 'S')
BEGIN
	INSERT INTO #sit_cespiti
	(
		yassetload,
		flagload,
		idinventory,
		ninventory,
		idasset,
		idinv,
		idlocation,
		idmanager,
		idassetunload,
		idassetunloadkind,
		yassetunload,
		nassetunload,
		flagunload,
		state,
		currentvalue
	)
	SELECT
		assetload.yassetload,
		CASE
			WHEN assetacquire.flag & 1 <> 0 THEN 'S'
			ELSE 'N'
		END,
		assetacquire.idinventory,  
		asset.ninventory,
		asset.idasset, 
		assetacquire.idinv, 
		location.idlocation,
		manager.idman,
		asset.idassetunload,
		assetunload.idassetunloadkind,
		assetunload.yassetunload, 
		assetunload.nassetunload,
		CASE
			WHEN asset.flag & 1 <> 0 THEN 'S'
			ELSE 'N'
		END,
		'In carico',
		AC.start
	FROM asset 
	join  assetview_current AC
		on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece
	LEFT OUTER JOIN assetunload
		ON assetunload.idassetunload = asset.idassetunload
	JOIN assetacquire 
		ON assetacquire.nassetacquire = asset.nassetacquire
	LEFT OUTER JOIN assetload
		ON assetload.idassetload = assetacquire.idassetload
	JOIN inventory 
		ON inventory.idinventory = assetacquire.idinventory
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind   
	LEFT OUTER JOIN location
		ON location.idlocation = 
		(SELECT TOP 1 idlocation
			FROM assetlocation WHERE assetlocation.idasset = asset.idasset
			ORDER BY start desc)
	LEFT OUTER JOIN manager
		ON manager.idman = 
			(SELECT TOP 1 idmanager
				FROM assetsubmanager
				WHERE assetsubmanager.idasset = asset.idasset
				ORDER BY start desc)
	WHERE asset.idpiece = 1
		AND (manager.idman = @idmanager OR @idmanager IS NULL)
		AND (assetacquire.idinventory = @idinventory or @idinventory IS NULL) -- Sara
		AND assetacquire.adate  <= @stop
		AND assetacquire.adate  >= @start
		AND ( @idinventory is not null OR ( (inventorykind.flag&2)=0) )
 
END

--setuser 'amministrazione'
------------------------------------------------------------
------------------- CLASSIFICAZIONE-------------------------
------------------------------------------------------------
IF (@situationkind = 'C')
BEGIN
	INSERT INTO #sit_cespiti
	(
		yassetload,
		flagload,
		idinventory,
		ninventory,
		idasset,
		idinv,
		idlocation,
		idmanager,
		idassetunload,
		idassetunloadkind,
		yassetunload,
		nassetunload,
		flagunload,
		state,
		currentvalue
	)
	SELECT
		assetload.yassetload,
		CASE
			WHEN assetacquire.flag & 1 <> 0 THEN 'S'
			ELSE 'N'
		END,
		assetacquire.idinventory, 
		asset.ninventory,
		asset.idasset, 
		inventorytree.idinv, 
		location.idlocation,
		manager.idman,
		asset.idassetunload,
		assetunload.idassetunloadkind,
		assetunload.yassetunload, 
		assetunload.nassetunload,
		CASE
			WHEN asset.flag & 1 <> 0 THEN 'S'
			ELSE 'N'
		END,
		'In carico',
		AC.start
	FROM asset 
	join  assetview_current AC
		on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece
	LEFT OUTER JOIN assetunload
		ON assetunload.idassetunload = asset.idassetunload
	JOIN assetacquire 
		ON assetacquire.nassetacquire = asset.nassetacquire
	LEFT OUTER JOIN assetload
		ON assetload.idassetload = assetacquire.idassetload
	LEFT OUTER JOIN inventorytree 
		ON inventorytree.idinv = assetacquire.idinv
	JOIN inventory 
		ON inventory.idinventory = assetacquire.idinventory
	LEFT OUTER JOIN location
		ON location.idlocation = 
		(SELECT TOP 1 idlocation
			FROM assetlocation WHERE assetlocation.idasset = asset.idasset
			ORDER BY start desc)
	LEFT OUTER JOIN manager
		ON manager.idman = 
			(SELECT TOP 1 idman
				FROM assetmanager
				WHERE assetmanager.idasset = asset.idasset
				ORDER BY start desc)
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind   
	WHERE  asset.idpiece = 1
	AND (inventorytree.nlevel >= @nlevelinvtree or @nlevelinvtree IS NULL)
	AND (inventorytree.codeinv LIKE @codeinv +'%' OR @codeinv IS NULL)	
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL)  
	AND assetacquire.adate <= @stop
	AND ( @idinventory is not null OR ( (inventorykind.flag&2)=0) )
			
END

UPDATE #sit_cespiti SET state = 'In carico' WHERE flagload = 'N' OR yassetload IS NOT NULL 

UPDATE #sit_cespiti SET state = 'Da caricare' WHERE yassetload IS NULL AND flagload = 'S'

UPDATE #sit_cespiti SET state = 'Scaricato' WHERE yassetunload IS NOT NULL OR flagunload = 'N'


--rivalutazioni di beni 
/*
UPDATE #sit_cespiti
SET currentvalue = ISNULL(currentvalue, 0.0) +
ISNULL(
	(SELECT
		SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			  ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetamortization
	JOIN inventoryamortization
		ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
	LEFT OUTER JOIN assetunload
		ON  assetamortization.idassetunload = assetunload.idassetunload
	WHERE assetamortization.idasset = #sit_cespiti.idasset 
		AND assetamortization.idpiece = 1 --maria
		AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
	            (
		     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
	             ((assetamortization.flag & 1 <> 1) OR 
		      (assetamortization.idassetunload IS NOT NULL))
		     )
		    )
		AND (inventoryamortization.flag & 2 <> 0)
	)
, 0.0)
*/
-------------------------------------------------------------------------------------------------
------ CARICHI ACCESSORI  DI BENI 
-------------------------------------------------------------------------------------------------

UPDATE #sit_cespiti
SET currentvalue = ISNULL(currentvalue, 0.0) +
ISNULL(
	(SELECT 
		SUM(
		ROUND(ISNULL(caricoaccessorio.taxable, 0)
		* (1 - CONVERT(decimal(19,6),ISNULL(caricoaccessorio.discount, 0))),2)
		+ ROUND(ISNULL(caricoaccessorio.tax,0) / caricoaccessorio.number,2)
		- ROUND(ISNULL(caricoaccessorio.abatable,0) / caricoaccessorio.number,2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	WHERE accessorio.idpiece > 1
	AND caricoaccessorio.adate <= @stop
	AND accessorio.idasset = #sit_cespiti.idasset
	AND caricoaccessorio.idassetload IS NOT NULL
	)
,0.0)

-------------------------------------------------------------------------------------------------
------ RIVALUTAZIONI DI BENI  E ACCESSORI
-------------------------------------------------------------------------------------------------

UPDATE #sit_cespiti
SET currentvalue = ISNULL(currentvalue, 0.0) +
ISNULL(
	(SELECT
		SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			  ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN assetamortization
		ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
	LEFT OUTER JOIN assetunload AA
		ON  assetamortization.idassetunload = AA.idassetunload
	LEFT OUTER JOIN assetload AL
		ON  assetamortization.idassetload = AL.idassetload
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	WHERE accessorio.idasset = #sit_cespiti.idasset 
		/* and assetamortization.idpiece > 1  */
		/*AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
		            (
			     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
		             ((assetamortization.flag & 1 <> 1) OR 
			      (assetamortization.idassetunload IS NOT NULL))
			     )
			    )		
		*/	    
		AND (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate  <= @stop) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate  <= @stop)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate  <= @stop) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate  <= @stop)
					)
			 	)
			)			    	    
		AND (inventoryamortization.flag & 2 <> 0)
		--AND caricoaccessorio.adate <= @stop
		AND caricoaccessorio.idassetload IS NOT NULL
	)
, 0.0)

-------------------------------------------------------------------------------------------------
--------------------- SCARICHI ACCESSORI  DI BENI -----------------------------------------------
-------------------------------------------------------------------------------------------------
-- Non considerimao gli scarichi accessori associati allo scarico cespite
-- ossia il valore del cespite rimane congelato al momento dello scarico

UPDATE #sit_cespiti
SET currentvalue = ISNULL(currentvalue, 0.0) -
ISNULL(
	(SELECT 
		SUM(
		ROUND(ISNULL(caricoaccessorio.taxable, 0)
		* (1 - CONVERT(decimal(19,6),ISNULL(caricoaccessorio.discount, 0))),2)
		+ ROUND(ISNULL(caricoaccessorio.tax,0) / caricoaccessorio.number,2)
		- ROUND(ISNULL(caricoaccessorio.abatable,0) / caricoaccessorio.number,2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN assetunload  AA
		ON AA.idassetunload = accessorio.idassetunload
		
	WHERE 
		accessorio.idpiece > 1 
		AND  accessorio.idasset = #sit_cespiti.idasset 
		AND (
	        (#sit_cespiti.idassetunload <> accessorio.idassetunload) --buono di scarico distinto
	        AND
	         AA.adate <= @stop
		)		
	)
, 0.0)

-------------------------------------------------------------------------------------------------
-------------------- RIVALUTAZIONI DEGLI ACCESSORI SCARICATI DEI BENI ---------------------------
-------------------------------------------------------------------------------------------------

UPDATE #sit_cespiti
SET currentvalue = ISNULL(currentvalue, 0.0) -
ISNULL(
	(SELECT
		SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			  ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN assetamortization
		ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
	LEFT OUTER JOIN assetunload AA
		ON  assetamortization.idassetunload = AA.idassetunload
	LEFT OUTER JOIN assetload AL
		ON  assetamortization.idassetload = AL.idassetload
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	WHERE accessorio.idasset = #sit_cespiti.idasset 
		AND assetamortization.idpiece > 1
		AND (inventoryamortization.flag & 2 <> 0)
		AND (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate  <= @stop) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate  <= @stop)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate  <= @stop) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate  <= @stop)
					)
			 	)
			)
		AND (
	        (#sit_cespiti.idassetunload <> accessorio.idassetunload) --buono di scarico distinto
	        AND
	         AA.adate <= @stop
		)			
	)
, 0.0)

IF (@situationkind = 'R')
BEGIN
-- aggiorna valore originale
	DECLARE @idasset int
	/*
	DECLARE @originalamount  decimal (19,2)
	DECLARE rowcursor INSENSITIVE CURSOR FOR
		SELECT 	idasset
		FROM #sit_cespiti
		FOR READ ONLY
	OPEN rowcursor FETCH  NEXT FROM rowcursor 
	INTO @idasset
	WHILE @@FETCH_STATUS = 0
		BEGIN 
			execute get_originalassetvalue @idasset,1,@iva,@originalamount out 

			UPDATE #sit_cespiti 
			SET	originalamount = ISNULL(@originalamount,0)
			WHERE 	idasset = @idasset
			FETCH NEXT FROM rowcursor INTO  @idasset
		END 
	DEALLOCATE rowcursor
	*/

--- aggiorna pagamenti 
	DECLARE @npay int
	DECLARE @ypay int

	DECLARE rowcursor INSENSITIVE CURSOR FOR
		SELECT asset.idasset, payment.ypay, payment.npay
		FROM assetacquire 
		JOIN assetloadexpense
			ON assetacquire.idassetload =  assetloadexpense.idassetload
		JOIN asset 
			ON assetacquire.nassetacquire = asset.nassetacquire
		JOIN expenselast
			ON assetloadexpense.idexp = expenselast.idexp
		JOIN payment
			ON payment.kpay = expenselast.kpay
		WHERE  asset.idpiece = 1
		FOR READ ONLY
	OPEN rowcursor FETCH  NEXT FROM rowcursor 
	INTO @idasset, @ypay, @npay
	WHILE @@FETCH_STATUS = 0
		BEGIN 
			UPDATE #sit_cespiti 
			SET	payment = isnull(payment,'')  + (convert(varchar(4),@ypay) + ' / ' + convert(varchar(6),@npay)) + '; '
			WHERE 	idasset = @idasset
			FETCH NEXT FROM rowcursor INTO   @idasset, @ypay, @npay
		END 
	DEALLOCATE rowcursor

END

SELECT
	#sit_cespiti.idinventory,
	inventory.description as 'inventory',
	#sit_cespiti.ninventory,
	#sit_cespiti.idasset,
	assetacquire.description,
	#sit_cespiti.idinv,
	inventory.codeinventory,
	inventorytree.codeinv,
	inventorytree.description as 'descinvtree',
	inventorytree.nlevel as 'nlevelinvtree',
	inventorysortinglevel.description as 'desclevelinvtree',
	location.idlocation,
	location.locationcode,
	location.description as 'location',
	location.nlevel as 'nlevellocation',
	locationlevel.description as 'desclevellocation',
	manager.idman as 'idmanager',
	manager.title as 'manager',
	assetload.idassetloadkind,
	assetload.yassetload,
	assetload.nassetload,
	#sit_cespiti.nassetunload,
	#sit_cespiti.state,
	#sit_cespiti.currentvalue,
	registry.title as registry,
	payment, 
	isnull(#sit_cespiti.originalamount,0) as originalamount,
	ltrim(ISNULL(u9.description,'')+ ' ' + ISNULL(u8.description,'') + ' ' + 
		ISNULL(u7.description,'')+' '+ ISNULL(u6.description,'')+' '+ 
		ISNULL(u5.description,'')+' '+ ISNULL(u4.description,'')+' '+ 
		ISNULL(u3.description,'')+' '+ ISNULL(u2.description,'')+' '+ 
		ISNULL(location.description,'')) as 'descrlungaubic', 
	ltrim(  ISNULL(c6.description,'')+' '+ 
		ISNULL(c5.description,'')+' '+ ISNULL(c4.description,'')+' '+ 
		ISNULL(c3.description,'')+' '+ ISNULL(c2.description,'')+' '+ 
		ISNULL(inventorytree.description,'')) as 'descrlungaclas'
FROM #sit_cespiti
JOIN asset 
	ON asset.idasset = #sit_cespiti.idasset
	AND asset.idpiece = 1
JOIN assetacquire 
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventorytree 
	ON inventorytree.idinv = #sit_cespiti.idinv
JOIN inventorysortinglevel 
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
JOIN inventory 
	ON inventory.idinventory = #sit_cespiti.idinventory
LEFT OUTER JOIN registry
	ON registry.idreg = assetacquire.idreg
LEFT OUTER JOIN assetload
	ON assetacquire.idassetload = assetload.idassetload
LEFT OUTER JOIN location 
	ON location.idlocation = #sit_cespiti.idlocation
LEFT OUTER JOIN locationlevel 
	ON locationlevel.nlevel = location.nlevel
LEFT OUTER JOIN manager
	ON manager.idman = #sit_cespiti.idmanager
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind   
LEFT OUTER JOIN inventorytreelink il2
	ON il2.idchild = #sit_cespiti.idinv AND il2.nlevel = 6
LEFT OUTER JOIN inventorytree c2
	ON il2.idparent = c2.idinv
LEFT OUTER JOIN inventorytreelink il3
	ON il3.idchild = #sit_cespiti.idinv AND il3.nlevel = 5
LEFT OUTER JOIN inventorytree c3
	ON il3.idparent = c3.idinv
LEFT OUTER JOIN inventorytreelink il4
	ON il4.idchild = #sit_cespiti.idinv AND il4.nlevel = 4
LEFT OUTER JOIN inventorytree c4
	ON il4.idparent = c4.idinv
LEFT OUTER JOIN inventorytreelink il5
	ON il5.idchild = #sit_cespiti.idinv AND il5.nlevel = 3
LEFT OUTER JOIN inventorytree c5
	ON il5.idparent = c5.idinv
LEFT OUTER JOIN inventorytreelink il6
	ON il6.idchild = #sit_cespiti.idinv AND il6.nlevel = 2
LEFT OUTER JOIN inventorytree c6
	ON il6.idparent = c6.idinv
LEFT OUTER JOIN inventorytreelink il7
	ON il7.idchild = #sit_cespiti.idinv AND il7.nlevel = 1
LEFT OUTER JOIN inventorytree c7
	ON il7.idparent = c7.idinv
LEFT OUTER JOIN locationlink ll2
	ON ll2.idchild = #sit_cespiti.idlocation AND ll2.nlevel = 8
LEFT OUTER JOIN location u2
	ON ll2.idparent = u2.idlocation
LEFT OUTER JOIN locationlink ll3
	ON ll3.idchild = #sit_cespiti.idlocation AND ll3.nlevel = 7
LEFT OUTER JOIN location u3
	ON ll3.idparent = u3.idlocation
LEFT OUTER JOIN locationlink ll4
	ON ll4.idchild = #sit_cespiti.idlocation AND ll4.nlevel = 6
LEFT OUTER JOIN location u4
	ON ll4.idparent = u4.idlocation
LEFT OUTER JOIN locationlink ll5
	ON ll5.idchild = #sit_cespiti.idlocation AND ll5.nlevel = 5
LEFT OUTER JOIN location u5
	ON ll5.idparent = u5.idlocation
LEFT OUTER JOIN locationlink ll6
	ON ll6.idchild = #sit_cespiti.idlocation AND ll6.nlevel = 4
LEFT OUTER JOIN location u6
	ON ll6.idparent = u6.idlocation
LEFT OUTER JOIN locationlink ll7
	ON ll7.idchild = #sit_cespiti.idlocation AND ll7.nlevel = 3
LEFT OUTER JOIN location u7
	ON ll7.idparent = u7.idlocation
LEFT OUTER JOIN locationlink ll8
	ON ll8.idchild = #sit_cespiti.idlocation AND ll8.nlevel = 2
LEFT OUTER JOIN location u8
	ON ll8.idparent = u8.idlocation
LEFT OUTER JOIN locationlink ll9
	ON ll9.idchild = #sit_cespiti.idlocation AND ll9.nlevel = 1
LEFT OUTER JOIN location u9
	ON ll9.idparent = u9.idlocation
--ORDER BY #sit_cespiti.ninventory
ORDER BY  
CASE	WHEN (@situationkind = 'U') THEN location.locationcode
	WHEN (@situationkind = 'C') THEN inventorytree.codeinv
	WHEN (@situationkind in ('R','S')) THEN manager.title
END,
#sit_cespiti.ninventory

END



--setuser 'amm'
-- exec rpt_sitpatrim_class 2, '1MOBI', 2, {ts '1900-01-01 00:00:00'}, {ts '2007-12-31 00:00:00'}
-- exec rpt_sitpatrim_class 2, '1COMP', 2, {ts '1900-01-01 00:00:00'}, {ts '2007-12-31 00:00:00'}

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
