
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_set_transmitted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_set_transmitted]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE compute_set_transmitted
(
	@idinventoryagency int,
	@start int,
	@stop int
)
AS BEGIN
-- Aggiornamento ASSETLOAD (OK)
UPDATE assetload SET transmitted = 'S'
WHERE transmitted IS NULL
AND yassetload BETWEEN @start AND @stop
AND
	(SELECT I.idinventoryagency 
	FROM assetloadkind K
	JOIN inventory I
	ON I.idinventory = K.idinventory
	WHERE assetload.idassetloadkind = K.idassetloadkind) = @idinventoryagency

-- Aggiornamento ASSETUNLOAD (OK)
UPDATE assetunload SET transmitted = 'S'
WHERE transmitted IS NULL
AND yassetunload BETWEEN @start AND @stop
AND
	(SELECT I.idinventoryagency 
	FROM assetunloadkind K
	JOIN inventory I
	ON I.idinventory = K.idinventory
	WHERE assetunload.idassetunloadkind = K.idassetunloadkind) = @idinventoryagency

-- Aggiornamento ASSETAMORTIZATION (OK)

-- Ammortamenti associati ad un buono di scarico
UPDATE assetamortization SET transmitted = 'S'
WHERE transmitted IS NULL
AND assetamortization.idassetunload IS NOT NULL
AND
	(SELECT u.yassetunload
	FROM assetunload u
	WHERE u.idassetunload = assetamortization.idassetunload) BETWEEN @start AND @stop
AND (flag & 1 <> 0)
AND
	(SELECT DISTINCT I.idinventoryagency
	FROM assetacquire CBI
	JOIN asset A
	ON A.nassetacquire = CBI.nassetacquire
	JOIN inventory I
	ON I.idinventory = CBI.idinventory
	WHERE A.idasset = assetamortization.idasset
	AND A.idpiece = assetamortization.idpiece) = @idinventoryagency

-- Ammortamenti non associati ad un buono di scarico
UPDATE assetamortization SET transmitted = 'S'
WHERE transmitted IS NULL
AND YEAR(adate) BETWEEN @start AND @stop
AND (flag & 1 <> 1)
AND
	(SELECT DISTINCT I.idinventoryagency
	FROM assetacquire CBI
	JOIN asset A
	ON A.nassetacquire = CBI.nassetacquire
	JOIN inventory I
	ON I.idinventory = CBI.idinventory
	WHERE A.idasset = assetamortization.idasset
	AND A.idpiece = assetamortization.idpiece) = @idinventoryagency

-- Aggiornamento ASSETACQUIRE (OK)

-- Carichi associati a buono di carico ricadente nel range
UPDATE assetacquire SET transmitted = 'S'
WHERE transmitted IS NULL
AND idassetload IS NOT NULL
AND 
	(SELECT l.yassetload
	FROM assetload l
	WHERE l.idassetload = assetacquire.idassetload) BETWEEN @start AND @stop
AND
	(SELECT I.idinventoryagency
	FROM assetloadkind AK
	JOIN inventory I
	ON I.idinventory = AK.idinventory
	JOIN assetload A
	ON AK.idassetloadkind = A.idassetloadkind
	WHERE A.idassetload = assetacquire.idassetload) = @idinventoryagency

-- Carichi non associati a buono di carico ma che devono cmq avere attivo il flag (caso di carichi con flag & 1 = 0 )
UPDATE assetacquire SET transmitted = 'S'
WHERE transmitted IS NULL
AND (flag & 1 <> 1)
AND YEAR(adate) BETWEEN @start AND @stop
AND
	(SELECT I.idinventoryagency
	FROM inventory I
	WHERE assetacquire.idinventory = I.idinventory) = @idinventoryagency

-- Aggiornamento ASSET
UPDATE asset SET transmitted = 'S'
WHERE transmitted IS NULL
AND EXISTS
	(SELECT * FROM assetacquire AQ
	WHERE AQ.nassetacquire = asset.nassetacquire
	AND AQ.transmitted = 'S')
OR EXISTS
	(SELECT * FROM assetunload AU
	WHERE AU.idassetunload = asset.idassetunload
	AND AU.transmitted = 'S')
OR EXISTS
	(SELECT * FROM assetamortization AA
	WHERE AA.idasset = asset.idasset
	AND AA.idpiece = asset.idpiece
	AND AA.transmitted = 'S')
OR
((flag & 1 <> 1)
AND
	(SELECT I.idinventoryagency
	FROM assetacquire AQ
	JOIN inventory I
	ON I.idinventory = AQ.idinventory
	WHERE AQ.nassetacquire = asset.nassetacquire) = @idinventoryagency
)

CREATE TABLE #temp (dummyfield int)

SELECT * FROM #temp
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

