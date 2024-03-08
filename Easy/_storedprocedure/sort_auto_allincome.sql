
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


if exists (select * from dbo.sysobjects where id = object_id(N'[sort_auto_allincome]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sort_auto_allincome]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE          PROCEDURE [sort_auto_allincome]
(
	@idsorkind int,
	@ayear int
)
AS BEGIN
DECLARE @nlevel tinyint

DECLARE @idinc int
DECLARE @idsormov int
DECLARE @amount decimal(23,6)
DECLARE @sortcode_temp int

DECLARE @nphaseincome tinyint
SELECT  @nphaseincome = nphaseincome FROM sortingkind WHERE idsorkind = @idsorkind

CREATE TABLE #finsor (idsor int, quota float)

DECLARE #income_cursor INSENSITIVE CURSOR FOR
SELECT idinc
FROM incomeview
WHERE ayear = @ayear
	AND nphase = @nphaseincome
	AND idinc NOT IN
		(SELECT idinc
		FROM incomesorted
		JOIN sorting
			ON sorting.idsor = incomesorted.idsor
		WHERE sorting.idsorkind = @idsorkind AND ayear = @ayear)
FOR READ ONLY

OPEN #income_cursor

FETCH NEXT FROM #income_cursor INTO @idinc
WHILE (@@FETCH_STATUS = 0)
BEGIN	
	SELECT @nlevel = nlevel 
	FROM fin
	JOIN incomeyear
		ON fin.idfin = incomeyear.idfin
	WHERE incomeyear.idinc = @idinc AND incomeyear.ayear = @ayear
		
	IF (
	SELECT COUNT(*)
	FROM finsorting C
	JOIN incomeyear I 
		ON C.idfin = I.idfin
	JOIN sorting S
		ON S.idsor = C.idsor
	WHERE I.idinc = @idinc 
		AND S.idsorkind = @idsorkind
		AND i.ayear = @ayear) > 0
	BEGIN
		INSERT INTO #finsor
		SELECT C.idsor,quota
		FROM finsorting C
		JOIN incomeyear I 
			ON C.idfin = I.idfin
		JOIN sorting S
			ON S.idsor = C.idsor
		WHERE I.idinc = @idinc 
			AND S.idsorkind = @idsorkind
			AND i.ayear = @ayear
	END
	ELSE IF (
	SELECT COUNT(*)
	FROM finsorting C
	JOIN finlink K
		ON K.idparent = C.idfin
	JOIN incomeyear I 
		ON I.idfin = K.idchild 
	JOIN sorting S
		ON S.idsor = C.idsor
	WHERE I.idinc = @idinc 
		AND K.nlevel = @nlevel-1
		AND S.idsorkind = @idsorkind
		AND i.ayear = @ayear)>0
	BEGIN
		INSERT INTO #finsor
		SELECT C.idsor,quota FROM finsorting C
		JOIN finlink K
			ON K.idparent = C.idfin
		JOIN incomeyear I 
			ON I.idfin = K.idchild 
		JOIN sorting S
			ON S.idsor = C.idsor
		WHERE I.idinc = @idinc 
			AND K.nlevel = @nlevel-1
			AND S.idsorkind = @idsorkind
			AND I.ayear = @ayear
	END
	ELSE IF (
	SELECT COUNT(*)
	FROM finsorting C
	JOIN finlink K
		ON K.idparent = C.idfin
	JOIN incomeyear I 
		ON I.idfin = K.idchild 
	JOIN sorting S
		ON S.idsor = C.idsor
	WHERE I.idinc = @idinc 
		AND K.nlevel = @nlevel-2
		AND S.idsorkind = @idsorkind
		AND i.ayear = @ayear)>0
	BEGIN
		INSERT INTO #finsor
		SELECT C.idsor,quota 
		FROM finsorting C 
		JOIN finlink K
			ON K.idparent = C.idfin
		JOIN incomeyear I 
			ON I.idfin = K.idchild 
		JOIN sorting S
			ON S.idsor = C.idsor
		WHERE I.idinc = @idinc 
			AND K.nlevel = @nlevel-2
			AND S.idsorkind = @idsorkind
			AND I.ayear = @ayear
	END
	ELSE IF (
	SELECT COUNT(*)
	FROM finsorting C
	JOIN finlink K
		ON K.idparent = C.idfin
	JOIN incomeyear I 
		ON I.idfin = K.idchild 
	JOIN sorting S
		ON S.idsor = C.idsor
	WHERE I.idinc = @idinc AND K.nlevel = @nlevel-3
		AND S.idsorkind = @idsorkind AND i.ayear = @ayear) > 0
	BEGIN
		INSERT INTO #finsor
		SELECT C.idsor,quota
		FROM finsorting C
		JOIN finlink K
			ON K.idparent = C.idfin
		JOIN incomeyear I -->ISNULL(quota,0)
			ON I.idfin = K.idchild 
		JOIN sorting S
			ON S.idsor = C.idsor
		WHERE I.idinc = @idinc AND K.nlevel = @nlevel-3
			AND S.idsorkind = @idsorkind AND i.ayear = @ayear
	END
	ELSE 
	BEGIN
		FETCH NEXT FROM #income_cursor INTO @idinc
		CONTINUE	-- Voce di bilancio non classificata
	END

	SELECT @amount =
	ISNULL(
		(SELECT curramount
		FROM incometotal
		WHERE idinc = @idinc
			AND ayear = @ayear)
	,0)
	IF (
	SELECT COUNT(*)
	FROM #finsor
	WHERE ISNULL(@amount,0)*ISNULL(#finsor.quota,1) > 0)>0
	BEGIN
		INSERT INTO incomesorted
		(
			idsor, idinc,
			idsubclass,
			amount,
			description, ayear,
			cu, ct, lu, lt
		)
		SELECT
			idsor, @idinc,
			ISNULL(
				(SELECT MAX(idsubclass)
				FROM incomesorted I
				WHERE I.idsor = #finsor.idsor 
					AND I.idinc = @idinc)
			,0) + 1,  -- calcolo l'IDSUBCLAS
			ISNULL(@amount,0) * ISNULL(#finsor.quota,1),
			'movimento classificato automaticamente dalla voce di bilancio', @ayear,
			'Automatico', GETDATE(), 'Automatico', GETDATE()
		FROM #finsor
		WHERE ISNULL(@amount,0) * ISNULL(#finsor.quota,1) > 0
	END
	IF (SELECT COUNT(*) FROM #finsor)>1	-- esistono almeno due ripartizione del movimento di spesa quindi devo verificare se la somma delle classificazioni quadra con l'importo del movimento di spesa
	BEGIN
		IF (
		SELECT SUM(amount)
		FROM incomesorted
		JOIN sorting S
			ON S.idsor = incomesorted.idsor
		WHERE ayear=@ayear
			AND S.idsorkind = @idsorkind 
			AND @idinc = idinc ) <> @amount
		BEGIN
			-- non quadra quindi devo compensare automaticamente
			SELECT @sortcode_temp = (SELECT TOP 1 idsor FROM #finsor ORDER BY quota DESC) -- prendo il codice di classificazione con la quota maggiore
			DECLARE @idsubclass int
			SELECT @idsubclass =
			ISNULL(
				(SELECT MAX(idsubclass)
				FROM incomesorted I
				WHERE I.idsor = @sortcode_temp
					AND I.idinc = @idinc
					AND I.ayear=@ayear)
			,0)
	
			UPDATE incomesorted
			SET amount = @amount -
			ISNULL(
				(SELECT SUM(amount)
				FROM incomesorted
				JOIN sorting S
					ON S.idsor = incomesorted.idsor
				WHERE S.idsorkind = @idsorkind
					AND idinc = @idinc
					AND (incomesorted.idsor <> @sortcode_temp OR (idsubclass <>@idsubclass))
					AND ayear=@ayear)
			,0)
			WHERE idsor = @sortcode_temp
				AND idinc = @idinc
				AND idsubclass = @idsubclass 
		END
	END
	DELETE #finsor
	FETCH NEXT FROM #income_cursor INTO @idinc
END
CLOSE #income_cursor
DEALLOCATE #income_cursor
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

