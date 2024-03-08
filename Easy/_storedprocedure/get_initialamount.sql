
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


if exists (select * from dbo.sysobjects where id = object_id(N'[get_initialamount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [get_initialamount]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [get_initialamount]
(
 @idasset int,
 @idpiece int,
 @initialamount decimal (19,2) OUTPUT
)
AS
BEGIN

----------------------------------------------------------------------------------
-------------------- Valore iniziale se cespite ----------------------------------
----------------------------------------------------------------------------------	 
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
	
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
