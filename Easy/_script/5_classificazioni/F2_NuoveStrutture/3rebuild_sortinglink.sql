
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_sortinglink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_sortinglink]
GO

CREATE PROCEDURE rebuild_sortinglink
AS BEGIN
	DELETE FROM sortinglink

	INSERT INTO sortinglink (idchild, nlevel, idparent)
	SELECT idsor, nlevel, idsor
	FROM sorting

	WHILE(@@ROWCOUNT > 0)
	BEGIN
		INSERT INTO sortinglink (idchild, nlevel, idparent)
		SELECT idchild, (EL.nlevel - 1), paridsor
		FROM sortinglink EL
		JOIN sorting E
			ON EL.idparent = E.idsor
		WHERE EL.nlevel > 1 AND paridsor IS NOT NULL
		AND NOT EXISTS(SELECT * FROM sortinglink EL2 WHERE EL2.idchild = EL.idchild AND EL2.nlevel = (EL.nlevel - 1))
	END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

