
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


if exists (select * from dbo.sysobjects where id = object_id(N'[uniform_inventorytree_check]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [uniform_inventorytree_check]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE uniform_inventorytree_check
(
	@idsorkind  int
)
AS BEGIN
	-- Controlli da effettuare

	CREATE TABLE #logerror
	(
		message varchar(200)
	)

	-- 1. Voci adoperate siano classificate
	INSERT INTO #logerror
	SELECT 'Nella var. n. ' + CONVERT(varchar(6),V.nvar) + ' / ' + CONVERT(varchar(6),V.yvar)
	+ ' la voce di class. inventariale con codice ' + IT.codeinv + ' non è stata classificata'
	FROM assetvardetail A
	JOIN assetvar V
		ON V.idassetvar = A.idassetvar
	JOIN inventorytree IT
		ON IT.idinv = A.idinv
	WHERE A.idinv NOT IN
		(SELECT ITS.idinv FROM inventorytreesorting ITS
		 JOIN sorting SS on ITS.idsor=SS.idsor
		WHERE A.idinv = ITS.idinv
		AND SS.idsorkind = @idsorkind)

	INSERT INTO #logerror
	SELECT 'Nel dettaglio del contratto passivo ' + M.idmankind + ' n. ' +
	CONVERT(varchar(6),M.nman) + ' / ' + CONVERT(varchar(6),M.yman) + ' riga ' +
	CONVERT(varchar(6), M.rownum)
	+ ' la voce di class. inventariale con codice ' + IT.codeinv + ' non è stata classificata'
	FROM mandatedetail M
	JOIN inventorytree IT
		ON IT.idinv = M.idinv
	WHERE M.idinv NOT IN
		(SELECT ITS.idinv FROM inventorytreesorting ITS
		 JOIN sorting SS on ITS.idsor=SS.idsor
		WHERE M.idinv = ITS.idinv
		AND SS.idsorkind = @idsorkind)
		AND M.idinv IS NOT NULL

	INSERT INTO #logerror
	SELECT 'Nel carico cespite n. ' + CONVERT(varchar(6),A.nassetacquire) +
	' la voce di class. inventariale con codice ' + IT.codeinv + ' non è stata classificata'
	FROM assetacquire A
	JOIN inventorytree IT
		ON IT.idinv = A.idinv
	WHERE A.idinv NOT IN
		(SELECT ITS.idinv FROM inventorytreesorting ITS
		JOIN SORTING SS ON SS.idsor=ITS.idsor
		WHERE A.idinv = ITS.idinv
		AND SS.idsorkind = @idsorkind)

	INSERT INTO #logerror
	SELECT 'Nella classificazione degli ammortamenti dell''esercizio ' + CONVERT(varchar(4),I.ayear) +
	' la voce di class. inventariale con codice ' + IT.codeinv +
	' non è stata classificata'
	FROM inventorysortingamortizationyear I
	JOIN inventorytree IT
		ON IT.idinv = I.idinv
	WHERE I.idinv NOT IN
		(SELECT ITS.idinv FROM inventorytreesorting ITS
		JOIN SORTING SS ON SS.idsor=ITS.idsor
		WHERE I.idinv = ITS.idinv
		AND SS.idsorkind = @idsorkind)

	INSERT INTO #logerror
	SELECT 'Nella classificazione alla classificazione inventariale ' + 
	' la voce di class. inventariale con codice ' + IT.codeinv +
	' non è stata riclassificata'
	FROM inventorytreesorting I
	JOIN sorting ISS on I.idsor=ISS.idsor
	JOIN inventorytree IT
		ON IT.idinv = I.idinv 
	WHERE I.idinv NOT IN
		(SELECT ITS.idinv FROM inventorytreesorting ITS
		JOIN SORTING SS ON SS.idsor=ITS.idsor
		WHERE I.idinv = ITS.idinv
		AND SS.idsorkind = @idsorkind)
	AND ISS.idsorkind <> @idsorkind

	-- 2. Congruità tra i figli di un nodo operativo
	INSERT INTO #logerror
	SELECT 'La voce della classificazione inventariale con codice ' + I.codeinv + 
	' ha figli classificati in modo non congruo'
	FROM inventorytree I
	WHERE I.idinv NOT IN
		(SELECT idinv FROM inventorytreesorting ITS
		 JOIN sorting ISS  ON ITS.idsor=ISS.idsor
		WHERE ISS.idsorkind = @idsorkind)
		AND
			(SELECT COUNT(DISTINCT SS.paridsor)
			FROM inventorytreesorting ITS
			JOIN SORTING SS ON SS.idsor=ITS.idsor
			JOIN inventorytreelink L
				ON L.idchild = ITS.idinv
			WHERE I.idinv = L.idparent
				AND SS.idsorkind = @idsorkind) > 1

	SELECT * FROM #logerror
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



