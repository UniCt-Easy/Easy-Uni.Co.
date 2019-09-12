if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_registro_ammortamenti_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_registro_ammortamenti_ente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE [rpt_registro_ammortamenti_ente]
@year			 int,
@idinventory	 	 varchar(20)


AS BEGIN
-------------------------------------------------------------------------------------
-------------- Elenco cespiti e accessori  ammortizzati nell'anno -------------------
-------------------------------------------------------------------------------------
	DECLARE @firstday datetime
	SET @firstday = CONVERT(datetime, '01/01/' + CONVERT(char(4),@year), 105)
			
	-- Tabella temporanea destinata a contenere gli ammortamenti dell'esercizio corrente
	CREATE TABLE #assetamortization
	(
		idasset 			int,
		idpiece 			int,
		idinventoryagency  		varchar(20),
		acquirekind			varchar(20),
		inventoryagency 		varchar(150),
		inventory 			varchar(50),
		inventorykind			varchar(50),   
		ninventory 			int,
		assetloadkind			varchar(50), 
		idassetloadkind 		varchar(20),
		yassetload 			int,
		nassetload 			int,
		category 			varchar(50),
		idinv	 			varchar(24),
		description 			varchar(150),
		assetdescription		varchar(150),
		assetoriginalvalue		decimal(19,2),
		startvalue 			decimal(19,2),
		finalvalue 			decimal(19,2),
		namortization			int,
		amortizationquota		float,
		assetvalue			decimal(19,2),
		adate				datetime,
		amortizationvalue		decimal(19,2) 
	)
	
	INSERT INTO #assetamortization
		(	
			idasset,
			idpiece,
			acquirekind,
			idinventoryagency,
			inventoryagency,
			inventory,
			inventorykind,
			ninventory,
			description,
			assetdescription,
			idinv,
			category,
			assetloadkind,
			idassetloadkind,  
			yassetload,  
			nassetload,
			namortization,
			amortizationquota,
			assetvalue,
			adate
		)
   	SELECT  
		cespite_o_accessorio.idasset,
		cespite_o_accessorio.idpiece,
		CASE 
			WHEN cespite_o_accessorio.idpiece = 1 THEN     'Cespite' 
			WHEN cespite_o_accessorio.idpiece > 1 THEN     'Accessorio'
		END					,
		inventory.idinventoryagency		,
		inventoryagency.description  		,
		inventory.description      		,
		inventorykind.description  		,
		cespite.ninventory			,
		carico.description   			,
		CASE 
			WHEN cespite_o_accessorio.idpiece = 1 THEN     NULL
			WHEN cespite_o_accessorio.idpiece > 1 THEN     caricocespite.description
		END					,
		SUBSTRING(carico.idinv, 1, 4)		,
		inventorytree.description               ,
		assetloadkind.description		,
		carico.idassetloadkind			,
		carico.yassetload			,
		carico.nassetload			,
		assetamortization.namortization		,
		assetamortization.amortizationquota	,
		assetamortization.assetvalue		,
		assetamortization.adate
	FROM asset as cespite_o_accessorio 		
	JOIN assetacquire as carico
		ON carico.nassetacquire = cespite_o_accessorio.nassetacquire
	JOIN asset as cespite
		ON cespite.idasset = cespite_o_accessorio.idasset
	JOIN assetacquire as caricocespite
		ON caricocespite.nassetacquire = cespite.nassetacquire
	LEFT OUTER JOIN assetloadkind
		ON  carico.idassetloadkind = assetloadkind.idassetloadkind
	JOIN inventory
		ON carico.idinventory = inventory.idinventory
	JOIN inventoryagency
		ON inventory.idinventoryagency = inventoryagency.idinventoryagency
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind   
	JOIN inventorytree
		ON inventorytree.idinv = SUBSTRING(carico.idinv, 1, 4)	
	JOIN assetamortization
		ON assetamortization.idasset = cespite_o_accessorio.idasset AND 
		   assetamortization.idpiece = cespite_o_accessorio.idpiece 
	JOIN inventoryamortization
		ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
	WHERE   cespite.idpiece = 1 
		AND (carico.yassetload is not null or (carico.flagload='N' AND carico.loadkind='N')) 
		AND inventoryamortization.flagofficial = 'S'  AND
		YEAR(assetamortization.adate) = @year AND
		assetamortization.adate >= @firstday AND
		carico.idinventory = @idinventory
	ORDER BY carico.nassetacquire
	       UPDATE #assetamortization 
       --print @idpiece
       SET assetoriginalvalue = ISNULL((
       SELECT 
	CASE	
		----------------------------------------------------------------------------------
		----------------- Considera i buoni di carico precedenti al 2005 -----------------
		----------------------------------------------------------------------------------
		WHEN 
	 	(inventorykind.flagdiscount='S' OR ISNULL(assetacquire.yassetload,2006)<2005 OR(
		assetacquire.yassetload is null and assetacquire.loadkind='R'))	
		THEN
		CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
		,2))
		----------------------------------------------------------------------------------
		------- Considera i buoni di carico del 2005 e i successivi  SENZA SCONTO --------
		----------------------------------------------------------------------------------			
		WHEN NOT (inventorykind.flagdiscount='S' OR ISNULL(assetacquire.yassetload,2006)<2005 OR  
		(assetacquire.yassetload is null and assetacquire.loadkind='R') )	
		THEN
		CONVERT(decimal(19,2),ROUND(
		ROUND(ISNULL(assetacquire.taxable, 0),2)
		+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
		- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
		,2))
		ELSE 0
		END
	 FROM asset 
	 JOIN assetacquire 
	   ON assetacquire.nassetacquire = asset.nassetacquire
	 JOIN inventory 
	   ON inventory.idinventory = assetacquire.idinventory
	 JOIN inventorykind
	   ON inventory.idinventorykind= inventorykind.idinventorykind  
	WHERE asset.idasset = #assetamortization.idasset
	  AND asset.idpiece = #assetamortization.idpiece
          ),0.0)
	WHERE #assetamortization.idpiece = 1
	
	UPDATE #assetamortization 
       --print @idpiece
       SET assetoriginalvalue = ISNULL((SELECT  CONVERT(decimal(19,2),ROUND(
				        ROUND(ISNULL(assetacquire.taxable, 0)
				        * (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
					+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
					- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
					,2))
				 FROM asset 
				 JOIN assetacquire 
				   ON assetacquire.nassetacquire = asset.nassetacquire
				 JOIN inventory 
				   ON inventory.idinventory = assetacquire.idinventory
				 JOIN inventorykind
				   ON inventory.idinventorykind= inventorykind.idinventorykind  
				WHERE asset.idasset = #assetamortization.idasset
				  AND asset.idpiece = #assetamortization.idpiece
				  AND (assetacquire.yassetload is  NOT NULL OR 
				      (assetacquire.flagload = 'N' AND assetacquire.loadkind = 'R'))),0.0)
	WHERE #assetamortization.idpiece > 1
	
	UPDATE #assetamortization
	SET amortizationvalue = ISNULL((SELECT ROUND(ISNULL(#assetamortization.assetvalue,0) * 
			                       ISNULL(#assetamortization.amortizationquota,0),2)), 0.0)
	UPDATE #assetamortization
	SET finalvalue = assetoriginalvalue

	UPDATE #assetamortization
	SET finalvalue = finalvalue +  ISNULL((SELECT
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
		ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetamortization
	JOIN asset
		ON  assetamortization.idasset=asset.idasset
		AND assetamortization.idpiece=asset.idpiece
	JOIN inventoryamortization
		ON assetamortization.idinventoryamortization=inventoryamortization.idinventoryamortization
	LEFT OUTER JOIN assetunload
		ON  assetamortization.idassetunloadkind = assetunload.idassetunloadkind
		AND assetamortization.yassetunload = assetunload.yassetunload
		AND assetamortization.nassetunload = assetunload.nassetunload
	WHERE   asset.idasset = #assetamortization.idasset AND asset.idpiece = 1
		AND ((assetamortization.amortizationquota >0 AND assetamortization.adate <= #assetamortization.adate) OR
	 		     (assetamortization.amortizationquota <0 AND 
			     (
			      (ISNULL(assetamortization.flagunload,'S')='N' AND assetamortization.adate <= #assetamortization.adate) OR 
			      (ISNULL(assetamortization.flagunload,'S')='S' AND assetunload.adate <= #assetamortization.adate))
			      )
			     )
		AND inventoryamortization.flagofficial = 'S'
		AND asset.idasset = #assetamortization.idasset
		AND asset.idpiece = #assetamortization.idpiece),0)
	WHERE #assetamortization.idpiece = 1

			
	-------------------------------------------------------------------------------------------------
	------ CARICHI ACCESSORI  DI BENI ---------------------------------------------------------------
	-------------------------------------------------------------------------------------------------

	UPDATE #assetamortization
	SET finalvalue = finalvalue + (
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
			accessorio.idpiece > 1 AND
			caricoaccessorio.adate<=#assetamortization.adate AND --maria
			accessorio.idasset = #assetamortization.idasset AND
			caricoaccessorio.yassetload is not null
			),0.0))
	WHERE #assetamortization.idpiece = 1
	
	-------------------------------------------------------------------------------------------------
	------ RIVALUTAZIONI DEGLI ACCESSORI DEI BENI ---------------------------------------------------
	-------------------------------------------------------------------------------------------------

	UPDATE #assetamortization
	SET finalvalue = finalvalue + (
		ISNULL((SELECT
			SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
				  ISNULL(assetamortization.amortizationquota,0),2))
		FROM assetacquire as caricoaccessorio 
		JOIN asset as accessorio 
			ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
		JOIN assetamortization
			ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
		LEFT OUTER JOIN assetunload
			ON  assetamortization.idassetunloadkind = assetunload.idassetunloadkind
			AND assetamortization.yassetunload = assetunload.yassetunload
			AND assetamortization.nassetunload = assetunload.nassetunload
		JOIN inventoryamortization
			ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
		WHERE accessorio.idasset = #assetamortization.idasset and
			assetamortization.idpiece > 1
			AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
			            (
				     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
			             ((ISNULL(assetamortization.flagunload,'S')= 'N') OR 
				      (assetamortization.yassetunload is not null))
				     )
				    )
			AND ISNULL(inventoryamortization.flagofficial,'') = 'S'
			AND caricoaccessorio.adate <= #assetamortization.adate
			AND caricoaccessorio.yassetload is not null
			), 0.0))
	WHERE #assetamortization.idpiece = 1
	
	-------------------------------------------------------------------------------------------------
	--------------------- SCARICHI ACCESSORI  DI BENI -----------------------------------------------
	-------------------------------------------------------------------------------------------------
	-- Non considerimao gli scarichi accessori associati allo scarico cespite
	-- ossia il valore del cespite rimane congelato al momento dello scarico
	UPDATE #assetamortization
	SET finalvalue = finalvalue - (
		ISNULL((SELECT 
		SUM(
		ROUND(ISNULL(caricoaccessorio.taxable, 0)
		* (1 - CONVERT(decimal(19,6),ISNULL(caricoaccessorio.discount, 0))),2)
		+ ROUND(ISNULL(caricoaccessorio.tax,0) / caricoaccessorio.number,2)
		- ROUND(ISNULL(caricoaccessorio.abatable,0) / caricoaccessorio.number,2))
		FROM assetacquire as caricoaccessorio 
		JOIN asset as accessorio 
			ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
		JOIN asset as cespite 
			ON cespite.idasset = #assetamortization.idasset
			AND cespite.idpiece = 1
		WHERE 
			accessorio.idpiece > 1 
			AND  accessorio.idasset = #assetamortization.idasset 
			AND (accessorio.yassetunload IS NOT NULL OR accessorio.flagunload='N')  --accessorio scaricato    
			AND (accessorio.yassetunload IS NULL OR       -- accessorio non scaricato esplicitamente
			    (cespite.yassetunload IS NULL AND cespite.flagunload='S')  OR --cespite non scaricato
			    (cespite.yassetunload <> accessorio.yassetunload) OR  --buono scarico distinto
			    (cespite.nassetunload <> accessorio.nassetunload) OR
	                    (cespite.idassetunloadkind <> accessorio.idassetunloadkind)
			)
			), 0.0))
	WHERE #assetamortization.idpiece = 1
	
	-------------------------------------------------------------------------------------------------
	-------------------- RIVALUTAZIONI DEGLI ACCESSORI SCARICATI DEI BENI ---------------------------
	-------------------------------------------------------------------------------------------------
	UPDATE #assetamortization
	SET finalvalue = finalvalue - (
	ISNULL((SELECT
		SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			  ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN asset as cespite 
		ON cespite.idasset = #assetamortization.idasset
		AND cespite.idpiece = 1
	JOIN assetamortization
		ON assetamortization.idasset = accessorio.idasset and 
		   assetamortization.idpiece = accessorio.idpiece
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	WHERE accessorio.idasset = #assetamortization.idasset 
		AND assetamortization.idpiece > 1
		AND ISNULL(inventoryamortization.flagofficial,'') = 'S'
		AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
		            (
			     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
		             ((ISNULL(assetamortization.flagunload,'S')= 'N') OR 
			      (assetamortization.yassetunload is not null))
			     )
			    )
		AND (accessorio.yassetunload IS NOT NULL OR accessorio.flagunload='N') 
		AND (accessorio.yassetunload IS NULL OR      --accessorio non scaricato esplicitamente
		    (cespite.yassetunload IS NULL AND cespite.flagunload='S')  OR --cespite non scaricato
		    (cespite.yassetunload <> accessorio.yassetunload) OR  --buono scarico distinto
		    (cespite.nassetunload <> accessorio.nassetunload) OR
                    (cespite.idassetunloadkind <> accessorio.idassetunloadkind)
		 )
		), 0.0))
	WHERE #assetamortization.idpiece = 1

	UPDATE #assetamortization
	SET finalvalue = finalvalue + ISNULL((SELECT
			 SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			 ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetamortization
	JOIN asset
		ON  assetamortization.idasset=asset.idasset
		AND assetamortization.idpiece=asset.idpiece
	JOIN inventoryamortization
		ON assetamortization.idinventoryamortization=inventoryamortization.idinventoryamortization
	LEFT OUTER JOIN assetunload
		ON  assetamortization.idassetunloadkind = assetunload.idassetunloadkind
		AND assetamortization.yassetunload = assetunload.yassetunload
		AND assetamortization.nassetunload = assetunload.nassetunload
	WHERE   asset.idasset = #assetamortization.idasset AND asset.idpiece > 1
		AND ((assetamortization.amortizationquota >0 AND assetamortization.adate <= #assetamortization.adate) OR
	 	     (assetamortization.amortizationquota <0 AND 
		     (
			(ISNULL(assetamortization.flagunload,'S')='N' AND assetamortization.adate <=  #assetamortization.adate) OR 
			(ISNULL(assetamortization.flagunload,'S')='S' AND assetunload.adate <=  #assetamortization.adate))
	 	     )
		    )
		AND inventoryamortization.flagofficial = 'S'
		AND asset.idasset = #assetamortization.idasset
		AND asset.idpiece = #assetamortization.idpiece),0)
	WHERE #assetamortization.idpiece > 1
	
	UPDATE #assetamortization
	SET startvalue = finalvalue - amortizationvalue

select * from #assetamortization
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
