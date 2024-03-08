
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_locationlink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_locationlink]
GO

CREATE PROCEDURE rebuild_locationlink
AS BEGIN
	DELETE FROM locationlink

	INSERT INTO locationlink (idchild, nlevel, idparent)
	SELECT idlocation, nlevel, idlocation
	FROM location

	WHILE(@@ROWCOUNT > 0)
	BEGIN
		INSERT INTO locationlink (idchild, nlevel, idparent)
		SELECT idchild, (EL.nlevel - 1), paridlocation
		FROM locationlink EL
		JOIN location E
		ON EL.idparent = E.idlocation
		WHERE EL.nlevel > 1 AND paridlocation IS NOT NULL
		AND NOT EXISTS(SELECT * FROM locationlink EL2 WHERE EL2.idchild = EL.idchild AND EL2.nlevel = (EL.nlevel - 1))
	END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

