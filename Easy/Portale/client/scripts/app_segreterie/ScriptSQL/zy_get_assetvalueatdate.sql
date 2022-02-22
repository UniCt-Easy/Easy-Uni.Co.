
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


IF EXISTS(select * from sysobjects where id = object_id(N'[amministrazione].[get_assetvalueatdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [amministrazione].[get_assetvalueatdate]
GO


CREATE    PROCEDURE [amministrazione].[get_assetvalueatdate]
(
	 @idasset int,
	 @idpiece int,
	 @date    datetime,
	 @originalvalue	decimal (19,2) OUTPUT,
	 @totale  decimal (19,2) OUTPUT
)
AS
BEGIN


----------------------------------------------------------------------------------
-------------------- Valore iniziale se cespite ----------------------------------
----------------------------------------------------------------------------------	
DECLARE @historical decimal(19,2) 
DECLARE @initialamount decimal(19,2) 
DECLARE @amortization decimal(19,2)
DECLARE @piece_posseduti_scaricati_original decimal(19,2)
DECLARE @piece_posseduti_scaricati_current decimal(19,2)

select @historical = historicalvalue from assetacquire AC 
				join asset A on A.nassetacquire=AC.nassetacquire
				where A.idasset=@idasset and A.idpiece=@idpiece
				
IF      (@idpiece = 1) --Cespite principale
	-- Per data intendiamo la data dell'ammortamento e calcoliamo la situazione alla data
	-- costruisco una sp che data una coppia idasset,idpiece e una data, calcoli il valore corrente 
	-- del cespite a quella data
	-- Calcolo valore alla data se cespite

BEGIN
       --print @idpiece
	SET @initialamount = ISNULL((
	SELECT 
	CASE	
		----------------------------------------------------------------------------------
		----------------- Considera i buoni di carico precedenti al 2005 -----------------
		----------------------------------------------------------------------------------
		WHEN 
	 	(((inventorykind.flag & 1)<> 0) OR ISNULL(assetload.yassetload,2006)<2005 OR(
		assetacquire.idassetload IS NULL AND ((assetacquire.flag & 2) <> 0)))	
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
		WHEN NOT (((inventorykind.flag & 1)<> 0) OR ISNULL(assetload.yassetload,2006)<2005 OR  
		(assetacquire.idassetload is null and ((assetacquire.flag & 2) <> 0)) )	
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
	LEFT OUTER JOIN assetload
		ON assetload.idassetload = assetacquire.idassetload
	JOIN inventory 
		ON inventory.idinventory = assetacquire.idinventory
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind  
	WHERE asset.idasset = @idasset
		AND asset.idpiece = @idpiece),0.0);
		
/*
X  = X0 + AMM = X0 (1+ somma aliq.amm)
X0 = X  / (1+somma aliq. amm)
*/
   WITH PIECE_SCARICATI (X, somma_aliquote)
   AS ( SELECT 
			CONVERT(decimal(19,2),ROUND(ISNULL(B.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
				+ ROUND(ISNULL(B.tax,0) / B.number,2)
				- ROUND(ISNULL(B.abatable,0) / B.number,2)),
				
				(SELECT SUM(AA.amortizationquota)					
				FROM  assetamortization AA
					LEFT OUTER JOIN assetunload AAU		ON  AA.idassetunload = AAU.idassetunload
					LEFT OUTER JOIN assetload AAL		ON  AA.idassetload = AAL.idassetload
				WHERE AA.idasset = A.idasset	AND   AA.idpiece = 1  /* il cespite esterno alla subquery */
				--AND (
					AND  ( (ISNULL(AA.amortizationquota,0)<0) AND
					    	( ((AA.flag & 1 = 0) 	AND year(AA.adate) <= year(AU.adate)) 
						    OR 
						    ((AA.flag & 1 <> 0)    AND year(AAU.adate) <= year(AU.adate))
					     )
					  )
					  
				-- gli aumenti di valore non entrano in gioco negli accessori posseduti
				--	OR 
					--( (ISNULL(AA.amortizationquota,0)>0) AND 
					 --    ( ((AA.flag & 1 = 0) 	AND year(AA.adate) < year(AU.adate)) 
					 --     OR 
					 --     ((AA.flag & 1 <> 0)    AND year(AAL.adate) <= year(AU.adate))
					 --    )
					 --  )			            

				--	)
				) 				 
		 from  asset A	/* gli accessori posseduti del cespite in input alla SP */
			  JOIN assetacquire B	on B.nassetacquire = A.nassetacquire
			  /*LEFT OUTER */ JOIN  assetunload AU		ON A.idassetunload = AU.idassetunload				
		where A.idasset = @idasset
			and   A.idpiece >1
			and  ((B.flag & 1 = 0) AND (B.flag & 2 <> 0)) 
			AND (/*AU.adate is null OR*/ AU.adate < @date)				/*accessori  scaricati*/
	)
	SELECT 	@piece_posseduti_scaricati_original = SUM(  isnull(X,0)* ( 1+ isnull(somma_aliquote,0)) ),
			@piece_posseduti_scaricati_current  = SUM( X)
				from PIECE_SCARICATI


	-------------------------------------------------------------------------------------------------
END
ELSE
BEGIN
	-- Calcolo valore alla data se accessorio
	SET @initialamount = ISNULL((SELECT  CONVERT(decimal(19,2),ROUND(
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
				WHERE asset.idasset = @idasset
				  AND asset.idpiece = @idpiece
				  AND asset.idpiece >1
				  AND (assetacquire.idassetload is  NOT NULL OR 
				      (((assetacquire.flag & 1) = 0) AND ((assetacquire.flag & 2) <> 0)))),0.0)


				
	
END

	SELECT  @amortization =
		SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
		ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetamortization
	JOIN asset
		ON  assetamortization.idasset=asset.idasset
		AND assetamortization.idpiece=asset.idpiece
	JOIN inventoryamortization
		ON assetamortization.idinventoryamortization=inventoryamortization.idinventoryamortization
	LEFT OUTER JOIN assetunload
		ON assetamortization.idassetunload = assetunload.idassetunload
	LEFT OUTER JOIN assetload 
					ON  assetamortization.idassetload = assetload.idassetload
	WHERE  (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate <= @date) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND assetload.adate <= @date)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate <= @date) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND assetunload.adate <= @date)
					)
			 	)
				)
		AND ((inventoryamortization.flag & 2) <> 0)
		AND asset.idasset = @idasset
		AND asset.idpiece = @idpiece


if (@historical is null) set @historical=@initialamount 

IF ISNULL(@idpiece,0)= 1
BEGIN
	SET @originalvalue = ISNULL(@historical, 0) 	- ISNULL(@piece_posseduti_scaricati_original, 0)
	SET @totale = ISNULL(@initialamount, 0) 	+ ISNULL(@amortization, 0)
							 - ISNULL(@piece_posseduti_scaricati_current, 0)

END
ELSE
BEGIN
	SET @originalvalue = @historical
	SET @totale =  ISNULL(@initialamount, 0) + ISNULL(@amortization, 0)  
END



END


GO


