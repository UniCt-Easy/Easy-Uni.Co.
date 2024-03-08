
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_asset_subzero]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_asset_subzero]
GO

CREATE PROCEDURE exp_asset_subzero
AS BEGIN
	DECLARE @totale decimal(19,2)
	DECLARE @idasset int
	DECLARE @idpiece int

	CREATE TABLE #err (message varchar(1000))

	DECLARE #crs INSENSITIVE CURSOR FOR
	SELECT idasset, idpiece FROM asset
	FOR READ ONLY
	OPEN #crs
	FETCH NEXT FROM #crs INTO @idasset, @idpiece
	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		EXEC getassetvalue @idasset, @idpiece, @totale output
		IF (@totale < 0)
		BEGIN
			INSERT INTO #err
			SELECT 'Cespite ' + CONVERT(varchar(10),@idasset) + '/' + CONVERT(varchar(4), @idpiece)
			+ ' con valore attuale pari a ' + CONVERT(varchar(20), @totale)
		END
		FETCH NEXT FROM #crs INTO @idasset, @idpiece
	END
	CLOSE #crs
	DEALLOCATE #crs
	SELECT message AS 'Errore' FROM #err
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

