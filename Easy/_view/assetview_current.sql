
-- CREAZIONE VISTA assetview_current
IF EXISTS(select * from sysobjects where id = object_id(N'[assetview_current]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetview_current]
GO


--setuser 'amministrazione'
CREATE     VIEW [assetview_current]
(
	idasset,
	idpiece,
	start,
	revals,
	revals_pending,
	subtractions,
	currentvalue,
	is_unloaded,
	is_loaded
)
AS SELECT
	asset.idasset,
	asset.idpiece,
	   CASE	
			WHEN (inventorykind.flag & 1 <> 0)
			THEN
			CONVERT(decimal(19,2),ROUND(
				ROUND(ISNULL(assetacquire.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
				+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
				- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))
			ELSE
			CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))
	END,
	--revals applied
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization (NOLOCK) 
				/*JOIN  inventoryamortization
				 ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload AA (NOLOCK) 	ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL (NOLOCK) 		ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is not null)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is not null)
					)
			 	)
				)
				--AND   (inventoryamortization.flag & 2 <> 0)
		),0),
	--revals pending
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization (NOLOCK) 
				/*JOIN  inventoryamortization
				ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload AA (NOLOCK) 		ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL (NOLOCK) 			ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is  null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is  null)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is  null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is  null)
					)
			 	)
				)				
				--AND   (inventoryamortization.flag & 2 <> 0)
				)
			,0),

	CASE	WHEN idpiece=1 THEN
	ISNULL(
			(SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(B.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
			+ ROUND(ISNULL(B.tax,0) / B.number,2)
			- ROUND(ISNULL(B.abatable,0) / B.number,2)))
			 from assetacquire B (NOLOCK) 
				join asset A (NOLOCK) 			on B.nassetacquire = A.nassetacquire
				where A.idasset = asset.idasset
				and   A.idpiece >1
				and   A.idassetunload IS NOT NULL
				and  ((B.flag & 1 <> 1) AND (B.flag & 2 <> 0)))
			,0)
	ELSE 0
	END,

	--valore iniziale cespiti
   CASE	
			----------------------------------------------------------------------------------
			----------------- Considera i buoni di carico cespiti precedenti al 2005   -------
			----------------------------------------------------------------------------------
			WHEN (inventorykind.flag & 1 <> 0) 
			THEN
			CONVERT(decimal(19,2),ROUND(
				ROUND(ISNULL(assetacquire.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
				+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
				- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))
			ELSE
			CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))		
	END
	--ammortamenti e rivalutazioni ufficiali	
	+
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization (NOLOCK) 
				/*JOIN  inventoryamortization
				ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload AA (NOLOCK) 		ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL (NOLOCK) 			ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
					( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is not null)
					))
					OR 
			            
					( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is not null)
					))

					)
				--AND   (inventoryamortization.flag & 2 <> 0)
				)
		,0)
	------------------------------------------------------------------------------------------
	-- Sottrae gli accessori scaricati caricati come posseduti e già inclusi nel cespite -----
	------------------------------------------------------------------------------------------	
	-
	CASE	WHEN idpiece=1 THEN
	ISNULL(
			(SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(B.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
			+ ROUND(ISNULL(B.tax,0) / B.number,2)
			- ROUND(ISNULL(B.abatable,0) / B.number,2)))
			 from assetacquire B (NOLOCK) 
				join asset A (NOLOCK) 		on B.nassetacquire = A.nassetacquire
				where A.idasset = asset.idasset
				and   A.idpiece >1
				and   A.idassetunload IS NOT NULL
				and  ((B.flag & 1 = 0) AND (B.flag & 2 <> 0)))
			,0)
	ELSE 0
	END,



	CASE 
		when assetunload.adate IS NOT NULL or (asset.flag & 1 = 0)
			THEN 'S'
		ELSE
			'N'
	END,
	CASE 
		when assetload.ratificationdate IS NOT NULL or ((assetacquire.flag & 1 = 0) AND (assetacquire.flag & 2 <> 0))
			THEN 'S'
		ELSE
			'N'
	END


FROM asset 
		 JOIN assetacquire (NOLOCK) 		   ON assetacquire.nassetacquire = asset.nassetacquire
		 LEFT OUTER JOIN assetload (NOLOCK)    ON assetload.idassetload = assetacquire.idassetload
		 LEFT OUTER JOIN assetunload (NOLOCK)  ON assetunload.idassetunload= asset.idassetunload
		 JOIN inventory  (NOLOCK)			   ON inventory.idinventory = asset.idinventory
		 JOIN inventorykind (NOLOCK) 		   ON inventory.idinventorykind= inventorykind.idinventorykind  

GO
