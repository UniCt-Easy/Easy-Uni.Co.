
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_location]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_location]
GO

CREATE TRIGGER [trigger_u_location] ON location FOR UPDATE
AS BEGIN
DECLARE @idlocation int
DECLARE @nlevel tinyint

IF UPDATE(paridlocation)
BEGIN
	DECLARE @newidparent int
	SELECT @idlocation = idlocation, @newidparent = paridlocation, @nlevel = nlevel FROM inserted
	
	IF (@newidparent IS NULL) RETURN
	CREATE TABLE #locationlink (idchild int)
	
	INSERT INTO #locationlink
	SELECT idchild
	FROM locationlink
	WHERE locationlink.idparent = @idlocation
	
	UPDATE locationlink
	SET idparent = (SELECT idparent FROM locationlink EL2 WHERE EL2.idchild = @newidparent AND EL2.nlevel = locationlink.nlevel)
	FROM #locationlink T
	WHERE locationlink.idchild = T.idchild
	AND nlevel < @nlevel
END
END

SET QUOTED_IDENTIFIER OFF



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

