
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_amortization]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_amortization]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE         PROCEDURE [compute_amortization] 
(
	@idasset int,
	@idpiece int,
	@idinventoryamortization int,
	@ayear int,
	@amortizationquota float output 
)
AS BEGIN
DECLARE @asset_startvalue decimal(19,2)

DECLARE @flagivaapplying char(1)
SELECT @flagivaapplying =
CASE
	WHEN flag & 4 <> 0 THEN 'S'
	ELSE 'N'
END
FROM inventoryamortization
WHERE idinventoryamortization = @idinventoryamortization

SET @amortizationquota = (SELECT TOP 1 inventorysortingamortizationyear.amortizationquota
FROM inventorysortingamortizationyear
JOIN inventorytreelink IL  
    	ON IL.idparent = inventorysortingamortizationyear.idinv
JOIN assetacquire
	ON assetacquire.idinv = IL.idchild
JOIN asset
	ON asset.nassetacquire = assetacquire.nassetacquire
WHERE inventorysortingamortizationyear.idinventoryamortization = @idinventoryamortization
	AND asset.idasset = @idasset
	AND ayear = @ayear
	AND asset.idpiece = @idpiece  
ORDER BY IL.nlevel DESC)

print @amortizationquota


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

