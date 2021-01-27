
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


if exists (select * from dbo.sysobjects where id = object_id(N'[getassetvalue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure .[getassetvalue]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [getassetvalue]
(
 @idasset int,
 @idpiece int,
 @totale  decimal (19,2) OUTPUT
)
AS
BEGIN

----------------------------------------------------------------------------------
-------------------- Valore iniziale se cespite ----------------------------------
----------------------------------------------------------------------------------	
DECLARE @initialamount decimal(19,2) 
IF      (@idpiece = 1) --Cespite principale
	BEGIN
	SET @initialamount = ISNULL((
	       SELECT 
		CASE	
			----------------------------------------------------------------------------------
			----------------- Considera i buoni di carico precedenti al 2005 -----------------
			----------------------------------------------------------------------------------
			WHEN 
		 	((inventorykind.flag & 1 <> 0) OR ISNULL(assetload.yassetload,2006)<2005 OR(
			assetacquire.idassetload IS NULL AND (assetacquire.flag & 2 <> 0)))	
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
			WHEN NOT ((inventorykind.flag & 1 <> 0) OR ISNULL(assetload.yassetload,2006)<2005 OR  
			(assetacquire.idassetload IS NULL AND (assetacquire.flag & 2 <> 0)) )	
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
		  AND asset.idpiece = @idpiece),0.0)
	END
----------------------------------------------------------------------------------
---------------------- Valore iniziale se accessorio -----------------------------
----------------------------------------------------------------------------------			
IF   (@idpiece > 1)
	BEGIN
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
			  AND ((assetacquire.flag & 1 <> 1) OR assetacquire.idassetload IS NOT NULL)
			      
			),0.0)
	END


----------------------------------------------------------------------------------
--------- Considera le svalutazioni/rivalutazioni ufficiali-----------------------
----------------------------------------------------------------------------------	
DECLARE  @totamortization  decimal(19,2) 
	 SET @totamortization = ISNULL(
				(SELECT SUM(ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2))
				FROM  assetamortization
				JOIN  inventoryamortization
				ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				WHERE assetamortization.idasset = @idasset
				AND   assetamortization.idpiece = @idpiece
				AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
			            (
				     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
			             ((assetamortization.flag & 1 <> 1) OR 
				      (assetamortization.idassetunload IS NOT NULL))
				     )
				    )
				AND   (inventoryamortization.flag & 2 <> 0))
			,0)

------------------------------------------------------------------------------------------
-- Sottrae gli accessori scaricati caricati come posseduti e già inclusi nel cespite -----
------------------------------------------------------------------------------------------	
DECLARE @totpieceunloaded decimal(19,2) 
IF      (@idpiece = 1)
	BEGIN
	SET @totpieceunloaded = ISNULL(
			(SELECT SUM(ROUND(ISNULL(B.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
			+ ROUND(ISNULL(B.tax,0) / B.number,2)
			- ROUND(ISNULL(B.abatable,0) / B.number,2))
			 from assetacquire B
				join asset A
				on B.nassetacquire = A.nassetacquire
				where A.idasset = @idasset
				and   A.idpiece >1
				and   A.idassetunload IS NOT NULL
				and  ((B.flag & 1 <> 1) AND (B.flag & 2 <> 0)))
			,0)
	END
ELSE  SET @totpieceunloaded = 0

--print @initialamount
--print @totamortization
--print @totpieceunloaded

SET @totale = @initialamount + @totamortization - @totpieceunloaded
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

