
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trigger_i_inventorytree]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[trigger_i_inventorytree]
GO



CREATE TRIGGER [dbo].[trigger_i_inventorytree] ON [dbo].[inventorytree] FOR INSERT
AS BEGIN
IF (@@ROWCOUNT = 0) RETURN
DECLARE @nrowinserted int
SET @nrowinserted = ISNULL((SELECT COUNT(*) FROM inserted),0)

IF (@nrowinserted > 1)
BEGIN
	CREATE TABLE #inventorytree (idinv int, nlevel tinyint)
	
	INSERT INTO #inventorytree (idinv, nlevel)
	SELECT idinv, nlevel FROM inserted
	
	INSERT INTO inventorytreelink (idchild, nlevel, idparent)
	SELECT idinv, nlevel, idinv
	FROM #inventorytree
	
	WHILE(@@ROWCOUNT > 0)
	BEGIN
		INSERT INTO inventorytreelink (idchild, nlevel, idparent)
		SELECT IL.idchild, (I.nlevel - 1), I.paridinv
		FROM inventorytreelink IL
		JOIN inventorytree I
		ON IL.idparent = I.idinv
		WHERE IL.nlevel > 1
		AND NOT EXISTS(SELECT * FROM inventorytreelink IL2 WHERE IL2.idchild = IL.idchild AND IL2.nlevel = (IL.nlevel - 1))
		AND EXISTS(SELECT * FROM #inventorytree WHERE #inventorytree.idinv = IL.idchild)
	END
END
ELSE
BEGIN
	DECLARE @idinv int
	DECLARE @nlevel tinyint
	DECLARE @paridinv int
	SELECT @idinv = idinv, @nlevel = nlevel, @paridinv = paridinv FROM inserted

	INSERT INTO inventorytreelink (idchild, nlevel, idparent)
	VALUES(@idinv, @nlevel, @idinv)

	DECLARE @currlevel tinyint
	SET @currlevel = @nlevel - 1

	DECLARE @currpar int
	SET @currpar = @paridinv

	WHILE (@currlevel >= 1)
	BEGIN
		INSERT INTO inventorytreelink (idchild, nlevel, idparent)
		VALUES(@idinv, @currlevel, @currpar)

		SET @currpar = (SELECT paridinv FROM inventorytree WHERE idinv = @currpar)
		SET @currlevel = @currlevel - 1
	END
END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

