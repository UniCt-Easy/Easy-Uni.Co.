
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[trigger_u_inventorytree]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[trigger_u_inventorytree]
GO



CREATE TRIGGER [dbo].[trigger_u_inventorytree] ON [dbo].inventorytree FOR UPDATE
AS BEGIN
DECLARE @idinv int
DECLARE @nlevel tinyint

IF UPDATE(paridinv)
BEGIN
	DECLARE @newidparent int
	SELECT @idinv = idinv, @newidparent = paridinv, @nlevel = nlevel FROM inserted
	
	IF (@newidparent IS NULL) RETURN
	CREATE TABLE #inventorytreelink (idchild int)
	
	INSERT INTO #inventorytreelink
	SELECT idchild
	FROM inventorytreelink
	WHERE inventorytreelink.idparent = @idinv
	
	UPDATE inventorytreelink
	SET idparent = (SELECT idparent FROM inventorytreelink EL2 WHERE EL2.idchild = @newidparent AND EL2.nlevel = inventorytreelink.nlevel)
	FROM #inventorytreelink T
	WHERE inventorytreelink.idchild = T.idchild
	AND nlevel < @nlevel
END
END

SET QUOTED_IDENTIFIER OFF



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

