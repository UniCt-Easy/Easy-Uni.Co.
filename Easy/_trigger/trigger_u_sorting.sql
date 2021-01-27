
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_sorting]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_sorting]
GO

CREATE TRIGGER [trigger_u_sorting] ON sorting FOR UPDATE
AS BEGIN
DECLARE @idsor int
DECLARE @nlevel tinyint

IF UPDATE(paridsor)
BEGIN
	DECLARE @newidparent int
	SELECT @idsor = idsor, @newidparent = paridsor, @nlevel = nlevel FROM inserted
	
	IF (@newidparent IS NULL) RETURN
	CREATE TABLE #sortinglink (idchild int)
	
	INSERT INTO #sortinglink
	SELECT idchild
	FROM sortinglink
	WHERE sortinglink.idparent = @idsor
	
	UPDATE sortinglink
	SET idparent = (SELECT idparent FROM sortinglink EL2 WHERE EL2.idchild = @newidparent AND EL2.nlevel = sortinglink.nlevel)
	FROM #sortinglink T
	WHERE sortinglink.idchild = T.idchild
	AND nlevel < @nlevel
END
END

SET QUOTED_IDENTIFIER OFF



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

