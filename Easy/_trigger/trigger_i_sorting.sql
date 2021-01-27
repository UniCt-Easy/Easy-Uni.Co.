
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_sorting]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_sorting]
GO

CREATE TRIGGER [trigger_i_sorting] ON [sorting] FOR INSERT
AS BEGIN
IF (@@ROWCOUNT = 0) RETURN
DECLARE @nrowinserted int
SET @nrowinserted = ISNULL((SELECT COUNT(*) FROM inserted),0)

IF (@nrowinserted > 1)
BEGIN
	CREATE TABLE #sorting (idsor int, nlevel tinyint)
	
	INSERT INTO #sorting (idsor, nlevel)
	SELECT idsor, nlevel FROM inserted
	
	INSERT INTO sortinglink (idchild, nlevel, idparent)
	SELECT idsor, nlevel, idsor
	FROM #sorting
	
	WHILE(@@ROWCOUNT > 0)
	BEGIN
		INSERT INTO sortinglink (idchild, nlevel, idparent)
		SELECT IL.idchild, (IL.nlevel - 1), I.paridsor
		FROM sortinglink IL
		JOIN sorting I
		ON IL.idparent = I.idsor
		WHERE IL.nlevel > 1
		AND NOT EXISTS(SELECT * FROM sortinglink IL2 WHERE IL2.idchild = IL.idchild AND IL2.nlevel = (IL.nlevel - 1))
		AND EXISTS(SELECT * FROM #sorting WHERE #sorting.idsor = IL.idchild)
	END
END
ELSE
BEGIN
	DECLARE @idsor int
	DECLARE @nlevel tinyint
	DECLARE @paridsor int
	SELECT @idsor = idsor, @nlevel = nlevel, @paridsor = paridsor FROM inserted

	INSERT INTO sortinglink (idchild, nlevel, idparent)
	VALUES(@idsor, @nlevel, @idsor)

	DECLARE @currlevel tinyint
	SET @currlevel = @nlevel - 1

	DECLARE @currpar int
	SET @currpar = @paridsor

	WHILE (@currlevel >= 1)
	BEGIN
		INSERT INTO sortinglink (idchild, nlevel, idparent)
		VALUES(@idsor, @currlevel, @currpar)

		SET @currpar = (SELECT paridsor FROM sorting WHERE idsor = @currpar)
		SET @currlevel = @currlevel - 1
	END
END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

