
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

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_parasubcontractcud]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_parasubcontractcud]
GO

CREATE  PROCEDURE compute_parasubcontractcud
(
	@idser int,
	@res int output
)
AS BEGIN

DECLARE @iddbdepartment varchar(50)
SET @res = 0

DECLARE @sql nvarchar(4000)
CREATE TABLE #temp (value int)

DECLARE @crs cursor
SET @crs = CURSOR FOR
SELECT iddbdepartment FROM dbdepartment

OPEN @crs

FETCH NEXT FROM @crs INTO @iddbdepartment 
WHILE (@@FETCH_STATUS = 0)
BEGIN
	SET @sql = N'SELECT COUNT(*)
	FROM [dbo].parasubcontractlist L
	JOIN [' + @iddbdepartment + '].parasubcontract P
		ON L.idcon = P.idcon
	JOIN [dbo].service S
		ON S.idser = P.idser
	WHERE L.iddbdepartment = ''' + @iddbdepartment + '''
		AND S.idser = ' + CONVERT(varchar(10), @idser) + '
		AND L.linked = ''S'''

	INSERT INTO #temp (value)
	EXEC SP_EXECUTESQL @sql

	SET @res = @res + ISNULL((SELECT value FROM #temp),0)

	DELETE FROM #temp

	FETCH NEXT FROM @crs INTO @iddbdepartment
END
CLOSE @crs
DEALLOCATE @crs
DROP TABLE #temp
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

