
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_finyear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_finyear]
GO

CREATE    PROCEDURE rebuild_finyear
(
	@ayear int = null
)
AS BEGIN

CREATE TABLE #finyear
(
	ayear int,
	idfin int,
	idupb varchar(36)
)
-- Parte 1: Ricostruzione di FINYEAR sulla base dei dati presenti in UPBTOTAL
IF (@ayear IS NULL)
BEGIN

	INSERT INTO #finyear
	(
		ayear,
		idfin, idupb
	)
	SELECT
		fin.ayear,
		upbtotal.idfin, upbtotal.idupb
	FROM upbtotal
	JOIN fin
		ON fin.idfin = upbtotal.idfin
	JOIN finlevel
		ON fin.nlevel = finlevel.nlevel
		AND fin.ayear = finlevel.ayear
	WHERE NOT EXISTS(SELECT * FROM finyear WHERE finyear.idfin = upbtotal.idfin AND finyear.idupb = upbtotal.idupb)
	AND ((finlevel.flag & 2) <> 0)
END
ELSE
BEGIN
	INSERT INTO #finyear
	(
		ayear,
		idfin, idupb
	)
	SELECT
		@ayear,
		upbtotal.idfin, upbtotal.idupb
	FROM upbtotal
	JOIN fin
		ON fin.idfin = upbtotal.idfin
	JOIN finlevel
		ON fin.nlevel = finlevel.nlevel
		AND fin.ayear = finlevel.ayear
	WHERE NOT EXISTS(
		SELECT * FROM finyear
		WHERE finyear.idfin = upbtotal.idfin
			AND finyear.idupb = upbtotal.idupb
			AND ayear = @ayear)
		AND fin.ayear = @ayear
		AND ((finlevel.flag & 2) <> 0)
END

DECLARE @y int
DECLARE @idfin varchar(31)
DECLARE @idupb varchar(36)
DECLARE #fy_crs INSENSITIVE CURSOR FOR
SELECT ayear, idfin, idupb
FROM #finyear
FOR READ ONLY

OPEN #fy_crs
FETCH NEXT FROM #fy_crs INTO @y, @idfin, @idupb
WHILE(@@FETCH_STATUS = 0)
BEGIN
	IF NOT EXISTS(SELECT * FROM finyear WHERE idfin = @idfin AND idupb = @idupb)
	BEGIN
		INSERT INTO finyear(ayear, idfin, idupb, ct, cu, lt, lu)
		VALUES(@y, @idfin, @idupb, GETDATE(), '''REBUILD''', GETDATE(), '''REBUILD''')
	END
	FETCH NEXT FROM #fy_crs INTO @y, @idfin, @idupb
END
CLOSE #fy_crs
DEALLOCATE #fy_crs
DELETE FROM #finyear

-- Parte 2: Inserimento in FINYEAR delle righe con UPB padre assente rispetto alla riga di FINYEAR
IF (@ayear IS NULL)
BEGIN
	IF (SELECT COUNT(*) FROM finyear f1
	WHERE LEN(idupb) > 4
		AND NOT EXISTS
			(SELECT * FROM finyear f2
			WHERE f2.idfin = f1.idfin
				AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4))
	) > 0
	BEGIN
		INSERT INTO #finyear (ayear, idfin, idupb)
		SELECT ayear, idfin, SUBSTRING(idupb,1,LEN(idupb)-4) FROM finyear f1
		WHERE LEN(idupb) > 4
			AND NOT EXISTS
				(SELECT * FROM finyear f2
				WHERE f2.idfin = f1.idfin
					AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4))
	END
END

IF (@ayear IS NOT NULL)
BEGIN
	IF (SELECT COUNT(*) FROM finyear f1
	WHERE LEN(idupb) > 4
		AND NOT EXISTS
			(SELECT * FROM finyear f2
			WHERE f2.idfin = f1.idfin
				AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4)
		AND ayear = @ayear)
	) > 0
	BEGIN
		INSERT INTO #finyear (ayear, idfin, idupb)
		SELECT ayear, idfin, SUBSTRING(idupb,1,LEN(idupb)-4) FROM finyear f1
		WHERE LEN(idupb) > 4
			AND NOT EXISTS
				(SELECT * FROM finyear f2
				WHERE f2.idfin = f1.idfin
					AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4)
		AND ayear = @ayear)
	END
END

IF (SELECT COUNT(*) FROM #finyear) > 0
BEGIN
	DECLARE #father_crs INSENSITIVE CURSOR FOR
	SELECT ayear, idfin, idupb FROM #finyear
	FOR READ ONLY
	
	OPEN #father_crs
	FETCH NEXT FROM #father_crs INTO @y, @idfin, @idupb
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF NOT EXISTS(SELECT * FROM finyear WHERE idfin = @idfin AND idupb = @idupb)
		BEGIN
			INSERT INTO finyear(ayear, idfin, idupb, ct, cu, lt, lu)
			VALUES(@y, @idfin, @idupb, GETDATE(), '''REBUILD''', GETDATE(), '''REBUILD''')
		END
		FETCH NEXT FROM #father_crs INTO @y, @idfin, @idupb
	END
	CLOSE #father_crs
	DEALLOCATE #father_crs
END

DELETE FROM #finyear

-- Parte 3: Inserimento in FINYEAR delle righe con UPB padre assente rispetto alla riga di FINYEAR
-- (seconda iterata per essere sicuri di aver preso salti di livello maggiore)
IF (@ayear IS NULL)
BEGIN
	IF (SELECT COUNT(*) FROM finyear f1
	WHERE LEN(idupb) > 4
		AND NOT EXISTS
			(SELECT * FROM finyear f2
			WHERE f2.idfin = f1.idfin
				AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4))
	) > 0
	BEGIN
		INSERT INTO #finyear (ayear, idfin, idupb)
		SELECT ayear, idfin, SUBSTRING(idupb,1,LEN(idupb)-4) FROM finyear f1
		WHERE LEN(idupb) > 4
			AND NOT EXISTS
				(SELECT * FROM finyear f2
				WHERE f2.idfin = f1.idfin
					AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4))
	END
END

IF (@ayear IS NOT NULL)
BEGIN
	IF (SELECT COUNT(*) FROM finyear f1
	WHERE LEN(idupb) > 4
		AND NOT EXISTS
			(SELECT * FROM finyear f2
			WHERE f2.idfin = f1.idfin
				AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4)
		AND ayear = @ayear)
	) > 0
	BEGIN
		INSERT INTO #finyear (ayear, idfin, idupb)
		SELECT ayear, idfin, SUBSTRING(idupb,1,LEN(idupb)-4) FROM finyear f1
		WHERE LEN(idupb) > 4
			AND NOT EXISTS
				(SELECT * FROM finyear f2
				WHERE f2.idfin = f1.idfin
					AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4)
		AND ayear = @ayear)
	END
END

IF (SELECT COUNT(*) FROM #finyear) > 0
BEGIN
	DECLARE #father_crs INSENSITIVE CURSOR FOR
	SELECT ayear, idfin, idupb FROM #finyear
	FOR READ ONLY
	
	OPEN #father_crs
	FETCH NEXT FROM #father_crs INTO @y, @idfin, @idupb
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF NOT EXISTS(SELECT * FROM finyear WHERE idfin = @idfin AND idupb = @idupb)
		BEGIN
			INSERT INTO finyear(ayear, idfin, idupb, ct, cu, lt, lu)
			VALUES(@y, @idfin, @idupb, GETDATE(), '''REBUILD''', GETDATE(), '''REBUILD''')
		END
		FETCH NEXT FROM #father_crs INTO @y, @idfin, @idupb
	END
	CLOSE #father_crs
	DEALLOCATE #father_crs
END

DROP TABLE #finyear
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

