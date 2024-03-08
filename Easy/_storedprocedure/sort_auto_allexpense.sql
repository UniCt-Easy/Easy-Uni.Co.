
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


if exists (select * from dbo.sysobjects where id = object_id(N'[sort_auto_allexpense]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sort_auto_allexpense]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE          PROCEDURE [sort_auto_allexpense]
(
	@idsorkind int,
	@ayear int
)
AS BEGIN
DECLARE @nlevel tinyint

DECLARE @idexp int
DECLARE @idsormov int
DECLARE @amount decimal(23,6)
DECLARE @sortcode_temp int

DECLARE @nphaseexpense tinyint
SELECT @nphaseexpense = nphaseexpense FROM sortingkind WHERE idsorkind = @idsorkind

CREATE TABLE #finsor (idsor int, quota float)

DECLARE #expense_cursor INSENSITIVE CURSOR FOR
SELECT idexp
FROM expenseview
WHERE ayear = @ayear 
	AND nphase = @nphaseexpense
	AND idexp NOT IN
		(SELECT idexp 
		FROM expensesorted 
		JOIN sorting
			ON sorting.idsor = expensesorted.idsor
		WHERE sorting.idsorkind = @idsorkind AND ayear = @ayear)
FOR READ ONLY

OPEN #expense_cursor

FETCH NEXT FROM #expense_cursor INTO @idexp
WHILE (@@FETCH_STATUS = 0)
BEGIN
	SELECT @nlevel = nlevel 
	FROM fin
	JOIN expenseyear
		ON fin.idfin = expenseyear.idfin
	WHERE expenseyear.idexp = @idexp AND expenseyear.ayear = @ayear
	
	IF (
	SELECT COUNT(*)
	FROM finsorting C
	JOIN expenseyear I 
		ON C.idfin = I.idfin
	JOIN sorting S
		ON S.idsor = C.idsor
	WHERE I.idexp = @idexp 
		AND S.idsorkind = @idsorkind
	AND i.ayear = @ayear) > 0
	BEGIN
		INSERT INTO #finsor
		SELECT C.idsor,quota
		FROM finsorting C
		JOIN expenseyear I 
			ON C.idfin = I.idfin
		JOIN sorting S
			ON S.idsor = C.idsor
		WHERE I.idexp = @idexp 
			AND S.idsorkind = @idsorkind
			AND i.ayear = @ayear
	END
	ELSE IF (
	SELECT COUNT(*)
	FROM finsorting C
	JOIN finlink K
		ON K.idparent = C.idfin
	JOIN expenseyear I 
		ON I.idfin = K.idchild 
	JOIN sorting S
		ON S.idsor = C.idsor
	WHERE I.idexp = @idexp 
		AND K.nlevel = @nlevel-1
		AND S.idsorkind = @idsorkind AND i.ayear = @ayear) > 0
	BEGIN
		INSERT INTO #finsor
		SELECT C.idsor,quota
		FROM finsorting C
		JOIN finlink K
			ON K.idparent = C.idfin
		JOIN expenseyear I 
			ON I.idfin = K.idchild 
		JOIN sorting S
			ON S.idsor = C.idsor
		WHERE I.idexp = @idexp 
			AND K.nlevel = @nlevel-1
			AND S.idsorkind = @idsorkind
			AND i.ayear = @ayear
	END
	ELSE IF (
	SELECT COUNT(*)
	FROM finsorting C
	JOIN finlink K
		ON K.idparent = C.idfin
	JOIN expenseyear I 
		ON I.idfin = K.idchild 
	JOIN sorting S
		ON S.idsor = C.idsor
	WHERE I.idexp = @idexp 
		AND K.nlevel = @nlevel-2
		AND S.idsorkind = @idsorkind
		AND i.ayear = @ayear) > 0
	BEGIN
		INSERT INTO #finsor
		SELECT C.idsor,quota 
		FROM finsorting C 
		JOIN finlink K
			ON K.idparent = C.idfin
		JOIN expenseyear I 
			ON I.idfin = K.idchild 
		JOIN sorting S
			ON S.idsor = C.idsor
		WHERE I.idexp = @idexp 
			AND K.nlevel = @nlevel-2
			AND S.idsorkind = @idsorkind
			AND i.ayear = @ayear
	END
	ELSE IF (
	SELECT COUNT(*)
	FROM finsorting C
	JOIN finlink K
		ON K.idparent = C.idfin
	JOIN expenseyear I 
		ON I.idfin = K.idchild 
	JOIN sorting S
		ON S.idsor = C.idsor
	WHERE I.idexp = @idexp AND K.nlevel = @nlevel-3
		AND S.idsorkind = @idsorkind AND i.ayear = @ayear) > 0
	BEGIN
		INSERT INTO #finsor
		SELECT C.idsor,quota
		FROM finsorting C
		JOIN finlink K
			ON K.idparent = C.idfin
		JOIN expenseyear I -->ISNULL(quota,0)
			ON I.idfin = K.idchild 
		JOIN sorting S
			ON S.idsor = C.idsor
		WHERE I.idexp = @idexp AND K.nlevel = @nlevel-3
			AND S.idsorkind = @idsorkind AND i.ayear = @ayear
	END
	ELSE 
	BEGIN
		FETCH NEXT FROM #expense_cursor INTO @idexp
		CONTINUE	-- Voce di bilancio non classificata
	END
	
	SELECT @amount =
	ISNULL(
		(SELECT curramount
		FROM expensetotal
		WHERE idexp = @idexp
			AND ayear = @ayear)
	,0)
	IF (
	SELECT COUNT(*)
	FROM #finsor
	WHERE ISNULL(@amount,0) * ISNULL(#finsor.quota,1) > 0)>0
	BEGIN
		INSERT INTO expensesorted
		(
			idsor, idexp,
			idsubclass,
			amount,
			description, ayear,
			cu, ct, lu, lt
		)
		SELECT
			idsor, @idexp,
			ISNULL(
				(SELECT MAX(idsubclass)
				FROM expensesorted I
				WHERE I.idsor = #finsor.idsor
					AND I.idexp = @idexp)
			,0) + 1, 
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
		FROM expensesorted
		JOIN sorting S
			ON S.idsor = expensesorted.idsor
		WHERE S.idsorkind = @idsorkind
			AND @idexp = idexp
			AND ayear=@ayear) <> @amount
		BEGIN
			-- non quadra quindi devo compensare automaticamente
			SELECT @sortcode_temp = (SELECT TOP 1 idsor FROM #finsor ORDER BY quota DESC) -- prendo il codice di classificazione con la quota maggiore
			DECLARE @idsubclass int
			SELECT @idsubclass =
			ISNULL(
				(SELECT MAX(idsubclass)
				FROM expensesorted I
				WHERE I.idsor = @sortcode_temp 
					AND I.idexp = @idexp 
					AND I.ayear=@ayear)
			,0)

			UPDATE expensesorted
			SET amount = @amount -
			ISNULL(
				(SELECT SUM(amount)
				FROM expensesorted
				JOIN sorting S
					ON S.idsor = expensesorted.idsor
				WHERE S.idsorkind = @idsorkind
					AND idexp = @idexp
					AND ((expensesorted.idsor <> @sortcode_temp) OR (idsubclass <> @idsubclass))
					AND ayear=@ayear)
			,0)
			WHERE idsor = @sortcode_temp 
				AND idexp = @idexp 
				AND idsubclass = @idsubclass
		END
	END
	DELETE #finsor
	FETCH NEXT FROM #expense_cursor INTO @idexp
END
CLOSE #expense_cursor
DEALLOCATE #expense_cursor
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

