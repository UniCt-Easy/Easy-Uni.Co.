
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_accountyear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_accountyear]
GO

CREATE    PROCEDURE rebuild_accountyear
(
	@ayear int = null, @curridupb varchar(36)='%'
)
AS BEGIN
SET @curridupb = @curridupb + '%'
CREATE TABLE #accountyear
(
	ayear int,
	idacc varchar(38),
	idupb varchar(36)
)

-- Parte 1: Ricostruzione di accountYEAR sulla base dei dati presenti in UPBaccountTOTAL
IF (@ayear IS NULL)
BEGIN

	INSERT INTO #accountyear
	(
		ayear,
		idacc, idupb
	)
	SELECT
		account.ayear,
		upbaccounttotal.idacc, upbaccounttotal.idupb
	FROM upbaccounttotal
	JOIN account
		ON account.idacc = upbaccounttotal.idacc
	JOIN accountlevel
		ON account.nlevel = accountlevel.nlevel
		AND account.ayear = accountlevel.ayear
	WHERE NOT EXISTS(SELECT * FROM accountyear WHERE accountyear.idacc = upbaccounttotal.idacc 
					AND accountyear.idupb = upbaccounttotal.idupb)
	AND (accountlevel.flagusable='S')
	AND upbaccounttotal.idupb like @curridupb
END
ELSE
BEGIN
	INSERT INTO #accountyear
	(
		ayear,
		idacc, idupb
	)
	SELECT
		@ayear,
		upbaccounttotal.idacc, upbaccounttotal.idupb
	FROM upbaccounttotal
	JOIN account
		ON account.idacc = upbaccounttotal.idacc
	JOIN accountlevel
		ON account.nlevel = accountlevel.nlevel
		AND account.ayear = accountlevel.ayear
	WHERE NOT EXISTS(
		SELECT * FROM accountyear
		WHERE accountyear.idacc = upbaccounttotal.idacc
			AND accountyear.idupb = upbaccounttotal.idupb
			AND ayear = @ayear)
		AND account.ayear = @ayear
		AND (accountlevel.flagusable='S')
		AND  upbaccounttotal.idupb like @curridupb
END

DECLARE @y int
DECLARE @idacc varchar(38)
DECLARE @idupb varchar(36)
DECLARE #fy_crs INSENSITIVE CURSOR FOR
SELECT ayear, idacc, idupb
FROM #accountyear
FOR READ ONLY

OPEN #fy_crs
FETCH NEXT FROM #fy_crs INTO @y, @idacc, @idupb
WHILE(@@FETCH_STATUS = 0)
BEGIN
	IF NOT EXISTS(SELECT * FROM accountyear WHERE idacc = @idacc AND idupb = @idupb)
	BEGIN
		INSERT INTO accountyear(ayear, idacc, idupb, ct, cu, lt, lu)
		VALUES(@y, @idacc, @idupb, GETDATE(), '''REBUILD''', GETDATE(), '''REBUILD''')
	END
	FETCH NEXT FROM #fy_crs INTO @y, @idacc, @idupb
END
CLOSE #fy_crs
DEALLOCATE #fy_crs
DELETE FROM #accountyear

-- Parte 2: Inserimento in accountyear delle righe con UPB padre assente rispetto alla riga di accountyear
IF (@ayear IS NULL)
BEGIN
	IF (SELECT COUNT(*) FROM accountyear f1
	WHERE LEN(idupb) > 4
	    AND f1.idupb like @curridupb
		AND NOT EXISTS
			(SELECT * FROM accountyear f2
			WHERE f2.idacc = f1.idacc
				AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4))
	) > 0
	BEGIN
		INSERT INTO #accountyear (ayear, idacc, idupb)
		SELECT ayear, idacc, SUBSTRING(idupb,1,LEN(idupb)-4) FROM accountyear f1
		WHERE LEN(idupb) > 4
		    AND f1.idupb like @curridupb
			AND NOT EXISTS
				(SELECT * FROM accountyear f2
				WHERE f2.idacc = f1.idacc
					AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4))
	END
END

IF (@ayear IS NOT NULL)
BEGIN
	IF (SELECT COUNT(*) FROM accountyear f1
	WHERE LEN(idupb) > 4
	    AND f1.idupb like @curridupb
		AND NOT EXISTS
			(SELECT * FROM accountyear f2
			WHERE f2.idacc = f1.idacc
				AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4)
		AND ayear = @ayear)
	) > 0
	BEGIN
		INSERT INTO #accountyear (ayear, idacc, idupb)
		SELECT ayear, idacc, SUBSTRING(idupb,1,LEN(idupb)-4) FROM accountyear f1
		WHERE LEN(idupb) > 4
		    AND f1.idupb like @curridupb
			AND NOT EXISTS
				(SELECT * FROM accountyear f2
				WHERE f2.idacc = f1.idacc
					AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4)
		AND ayear = @ayear)
	END
END

IF (SELECT COUNT(*) FROM #accountyear) > 0
BEGIN
	DECLARE #father_crs INSENSITIVE CURSOR FOR
	SELECT ayear, idacc, idupb FROM #accountyear
	FOR READ ONLY
	
	OPEN #father_crs
	FETCH NEXT FROM #father_crs INTO @y, @idacc, @idupb
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF NOT EXISTS(SELECT * FROM accountyear WHERE idacc = @idacc AND idupb = @idupb)
		BEGIN
			INSERT INTO accountyear(ayear, idacc, idupb, ct, cu, lt, lu)
			VALUES(@y, @idacc, @idupb, GETDATE(), '''REBUILD''', GETDATE(), '''REBUILD''')
		END
		FETCH NEXT FROM #father_crs INTO @y, @idacc, @idupb
	END
	CLOSE #father_crs
	DEALLOCATE #father_crs
END

DELETE FROM #accountyear
-- Parte 3: Inserimento in accountyear delle righe con UPB padre assente rispetto alla riga di accountyear
-- (seconda iterata per essere sicuri di aver preso salti di livello maggiore)
IF (@ayear IS NULL)
BEGIN
	IF (SELECT COUNT(*) FROM accountyear f1
	WHERE LEN(idupb) > 4
	    AND f1.idupb like @curridupb
		AND NOT EXISTS
			(SELECT * FROM accountyear f2
			WHERE f2.idacc = f1.idacc
				AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4))
	) > 0
	BEGIN
		INSERT INTO #accountyear (ayear, idacc, idupb)
		SELECT ayear, idacc, SUBSTRING(idupb,1,LEN(idupb)-4) FROM accountyear f1
		WHERE LEN(idupb) > 4
		    AND f1.idupb like @curridupb
			AND NOT EXISTS
				(SELECT * FROM accountyear f2
				WHERE f2.idacc = f1.idacc
					AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4))
	END
END

IF (@ayear IS NOT NULL)
BEGIN
	IF (SELECT COUNT(*) FROM accountyear f1
	WHERE LEN(idupb) > 4
	    AND f1.idupb like @curridupb
		AND NOT EXISTS
			(SELECT * FROM accountyear f2
			WHERE f2.idacc = f1.idacc
				AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4)
		AND ayear = @ayear)
	) > 0
	BEGIN
		INSERT INTO #accountyear (ayear, idacc, idupb)
		SELECT ayear, idacc, SUBSTRING(idupb,1,LEN(idupb)-4) FROM accountyear f1
		WHERE LEN(idupb) > 4
		    AND f1.idupb like @curridupb
			AND NOT EXISTS
				(SELECT * FROM accountyear f2
				WHERE f2.idacc = f1.idacc
					AND f2.idupb = SUBSTRING(f1.idupb,1,LEN(f1.idupb) - 4)
		AND ayear = @ayear)
	END
END

IF (SELECT COUNT(*) FROM #accountyear) > 0
BEGIN
	DECLARE #father_crs INSENSITIVE CURSOR FOR
	SELECT ayear, idacc, idupb FROM #accountyear
	FOR READ ONLY
	
	OPEN #father_crs
	FETCH NEXT FROM #father_crs INTO @y, @idacc, @idupb
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF NOT EXISTS(SELECT * FROM accountyear WHERE idacc = @idacc AND idupb = @idupb)
		BEGIN
			INSERT INTO accountyear(ayear, idacc, idupb, ct, cu, lt, lu)
			VALUES(@y, @idacc, @idupb, GETDATE(), '''REBUILD''', GETDATE(), '''REBUILD''')
		END
		FETCH NEXT FROM #father_crs INTO @y, @idacc, @idupb
	END
	CLOSE #father_crs
	DEALLOCATE #father_crs
END

DROP TABLE #accountyear
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

