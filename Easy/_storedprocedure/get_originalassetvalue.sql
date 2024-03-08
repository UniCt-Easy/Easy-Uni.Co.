
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



if exists (select * from dbo.sysobjects where id = object_id(N'[get_originalassetvalue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [get_originalassetvalue]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE    PROCEDURE  [get_originalassetvalue]
(
 @idasset int,
 @idpiece int,
 @flagiva char(1),
 @totale  decimal (19,2) OUTPUT
)
AS
BEGIN
DECLARE @flagivaapplying float
IF(@flagiva)='S'
BEGIN
	SET @flagivaapplying = 1
END
ELSE 
BEGIN
	SET @flagivaapplying = 0
END

DECLARE @flagdiscount int
IF (SELECT inventorykind.flag & 1
		FROM inventory 
		JOIN assetacquire
			ON inventory.idinventory = assetacquire.idinventory
		JOIN asset
			ON assetacquire.nassetacquire = asset.nassetacquire
		JOIN inventorykind 
			ON inventory.idinventorykind = inventorykind.idinventorykind
	WHERE asset.idasset = @idasset 
	AND asset.idpiece = @idpiece) <> 0
	SET @flagdiscount = 1
ELSE
	SET @flagdiscount = 0


----------------------------------------------------------------------------------
-------------------- Valore iniziale se cespite ----------------------------------
----------------------------------------------------------------------------------	
DECLARE @initialamount decimal(19,2) 
DECLARE @summallquota float

IF      (@idpiece = 1) --Cespite principale
	BEGIN
	SET @initialamount = ISNULL((
	       SELECT 
		CASE	
			----------------------------------------------------------------------------------
			----------------- Considera i buoni di carico precedenti al 2005 -----------------
			----------------------------------------------------------------------------------
			WHEN 
		 	((inventorykind.flag & 1 <> 0) OR ISNULL(assetload.yassetload,2006)<2005 OR
					(assetacquire.idassetload IS NULL AND (assetacquire.flag & 2 <> 0))
				)	
			THEN
			CONVERT(decimal(19,2),ROUND(
				ROUND(ISNULL(assetacquire.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount , 0))),2)
				+ ROUND(ISNULL(assetacquire.tax*@flagivaapplying,0) / assetacquire.number,2)
				- ROUND(ISNULL(assetacquire.abatable*@flagivaapplying,0) / assetacquire.number,2) 
			,2))
			----------------------------------------------------------------------------------
			------- Considera i buoni di carico del 2005 e i successivi  SENZA SCONTO --------
			----------------------------------------------------------------------------------			
			WHEN NOT ((inventorykind.flag & 1 <> 0) OR ISNULL(assetload.yassetload,2006)<2005 OR  
			(assetacquire.idassetload IS NULL AND (assetacquire.flag & 2 <> 0)) )	
			THEN
			CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.tax*@flagivaapplying,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable*@flagivaapplying,0) / assetacquire.number,2) 
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
			        * (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount * @flagdiscount, 0))),2)
				+ ROUND(ISNULL(assetacquire.tax*@flagivaapplying,0) / assetacquire.number,2)
				- ROUND(ISNULL(assetacquire.abatable*@flagivaapplying,0) / assetacquire.number,2) 
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
			  AND (assetacquire.idassetload IS NOT NULL OR 
			      ((assetacquire.flag & 1 <> 1) AND (assetacquire.flag & 2 <> 0)))),0.0)
	END

------------------------------------------------------------------------------------------
-- Calcola gli accessori scaricati caricati come posseduti e già inclusi nel cespite -----
------------------------------------------------------------------------------------------	
DECLARE @totpieceunloaded decimal(19,2) 
IF      (@idpiece = 1)
	BEGIN
	SET @totpieceunloaded = ISNULL(
			(SELECT SUM(ROUND(ISNULL(B.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(B.discount * @flagdiscount, 0))),2)
			+ ROUND(ISNULL(B.tax,0) / B.number,2)
			- ROUND(ISNULL(B.abatable,0) / B.number,2))
			 from assetacquire B
				join asset A
				on B.nassetacquire = A.nassetacquire
				where A.idasset = @idasset
				and   A.idpiece >1
				and   (A.idassetunload IS NOT NULL or (A.flag & 1 = 0))
				and  ((B.flag & 1 =  0) AND (B.flag & 2 <> 0)))
			,0)
	END
ELSE  
	SET @totpieceunloaded = 0


	declare @historical decimal(19,2)
	select 	@historical= historicalvalue from assetacquire AC 
				join asset A on A.nassetacquire=AC.nassetacquire
				where A.idasset=@idasset and A.idpiece=@idpiece

	if @historical is null set @historical=@initialamount

	set @totale  = @historical


if @totpieceunloaded > 0 begin
	
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

	SELECT @summallquota=ISNULL(
				(SELECT SUM(
					ISNULL(assetamortization.amortizationquota,0.0)
					)
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

-- sia valore tot = valore attuale del cespite più tutti i valori degli accessori scaricati, al momento dello scarico
-- sia 	@initialamount = valore del carico iniziale (cespite e accessori posseduti insieme)
--			 valore tot = (original + accessori) * (1+sum am.quota prima degli scarichi) + original * (sum am.quota dopo scarichi)
--						=  original  * (1+sum all am.quota)  +   (accessori * (1+sum am.quota prima scarichi))
--						=  original  * (1+ sum all am.quota) +    @totpieceunloaded
-- da cui	 original	= (valore tot -@totpieceunloaded)/(1+sum all am.quota)

--ma: 
-- valore tot =  @initialamount + @totamortization 
-- da cui
--						= (@initialamount +  @totamortization   -   @totpieceunloaded) / (1+@summallquota)

--print @historical
--print @initialamount
--print @totamortization
--print @totpieceunloaded


	IF @summallquota = -1		
		SET @totale =@historical 	
	ELSE        
 		SET @totale =(@historical + @totamortization-@totpieceunloaded) /(1+@summallquota)


/*

Cespite C0
Accessorio A0
valore iniziale = di assetacquire = A0+C0 = C
% ammortamenti X (prima scarico accessorio) e Y  (dopo scarico accessorio)
val.scaricato =  A0(1+X) = carico accessorio A 
val.attuale rimasto = C0(1+X+Y) 

		val.corrente + scaricato = C0*(1+X+Y) + A  
								 = C0*(1+X+Y) + A0(1+X)
								 = A0+C0  + (A0+C0)*X  + C0*Y
								 = C + Amm1 + Amm2 = 
				= val.iniziale + somma ammortamenti

		Da cui C0 = (C + somma ammortamenti - A)/(1+X+Y)
	   

Ora considerando un valore di partenza STORICO Z diverso da quello di carico iniziale, 
ove Z = Z0+A0 è il valore iniziale complessivo dei cespiti posseduti	rivelatisi nella nuova gestione
mentre Z0 il valore al netto (equivalente di C0 nel precedente esempio)		
			val.corrente + scaricato = C0 + Z0(X+Y) + A
									 = C0 + Z0(X+Y) + A0(1+X)
									 = A0+C0   +  Z0(X+Y)  + A0*X
									 = C   + (A0+Z0)*X  + Z0*Y
									 = C   + amm1 + amm2
	 								 = C   + somma ammortamenti
			Da cui 
			C0+  Z0(X+Y) + A   =  val.iniziale  + somma ammortamenti
			C0+  Z0(X+Y)	   =  val.iniziale  + somma ammortamenti - A           (1)

ma C = C0+A0
   Z = Z0+A0
   Z-C = Z0-C0
   C0 = Z0-Z+C
			C0  + Z0(X+Y) = (Z0-Z+C)  + Z0(X+Y) = Z0(1+X+Y) -Z + C
	
	quindi proseguendo dalla (1)
			Z0(1+X+Y) - Z + C = C   + somma ammortamenti - A  
			Z0 (1+X+Y) = Z+ somma ammortamenti - A
			quindi Z0 =  (Z  + somma ammortamenti - A   )/(1+X+Y)



*/





		--print @totale
end

 --print @totale
END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

