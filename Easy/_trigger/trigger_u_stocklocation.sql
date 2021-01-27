
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


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[trigger_u_stocklocation]'))
DROP TRIGGER [trigger_u_stocklocation]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    TRIGGER [trigger_u_stocklocation] ON [stocklocation] FOR UPDATE
AS BEGIN
DECLARE @idstocklocation int
DECLARE @nlevel tinyint

IF UPDATE(paridstocklocation)
BEGIN
	DECLARE @newidparent int
	SELECT @idstocklocation = idstocklocation, @newidparent = paridstocklocation, @nlevel = nlevel FROM inserted
	
	IF (@newidparent IS NULL) RETURN
	CREATE TABLE #stocklocationlink (idchild int)
	
	INSERT INTO #stocklocationlink
	SELECT idchild
	FROM stocklocationlink
	WHERE stocklocationlink.idparent = @idstocklocation
	
	UPDATE stocklocationlink
	SET idparent = (SELECT idparent FROM stocklocationlink EL2 WHERE EL2.idchild = @newidparent AND EL2.nlevel = stocklocationlink.nlevel)
	FROM #stocklocationlink T
	WHERE stocklocationlink.idchild = T.idchild
	AND nlevel < @nlevel
END
END

SET QUOTED_IDENTIFIER OFF



