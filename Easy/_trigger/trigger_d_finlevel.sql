
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


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_finlevel]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_finlevel]
GO

CREATE TRIGGER [trigger_d_finlevel] ON [finlevel] FOR DELETE
AS BEGIN
IF (@@ROWCOUNT = 0) RETURN
IF (user<>'amministrazione') return
IF (( 
SELECT TRIGGER_NESTLEVEL ()) > 1 ) 
RETURN
CREATE TABLE #finlevel
(
	nlevel tinyint,
	ayear smallint
)

INSERT INTO #finlevel (nlevel, ayear)
SELECT nlevel, ayear FROM deleted WHERE nlevel <= (select unifiedfinlevel 
from commonconfig where ayear =deleted.ayear)


        DECLARE @currdep varchar(50)
        SET @currdep = user
        
        DECLARE @iddbdepartment varchar(50)
        
        DECLARE @cursore cursor
        SET @cursore = CURSOR FOR
        SELECT  iddbdepartment FROM dbdepartment WHERE iddbdepartment <> @currdep
        OPEN @cursore
        FETCH NEXT FROM @cursore INTO @iddbdepartment
        WHILE (@@FETCH_STATUS = 0)
        BEGIN
        	DECLARE @sql nvarchar(2000)
        
        	SET @sql = N'DELETE FROM [' + @iddbdepartment + '].finlevel' +
        	' WHERE EXISTS(SELECT * FROM #finlevel T WHERE T.nlevel = [' + @iddbdepartment +
        	'].finlevel.nlevel AND T.ayear = [' + @iddbdepartment + '].finlevel.ayear) '
        	
        	PRINT @sql
        	EXEC SP_EXECUTESQL @sql
        
        	FETCH NEXT FROM @cursore INTO @iddbdepartment
        END

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

