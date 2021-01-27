
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_finlevel]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_finlevel]
GO

CREATE TRIGGER [trigger_i_finlevel] ON [finlevel] FOR INSERT
AS BEGIN

IF (@@ROWCOUNT = 0) RETURN
DECLARE	@cu varchar(64)
SELECT	@cu = cu FROM inserted

-- Parte di propagazione delle modifiche a tutti i dipartimenti
IF (user<>'amministrazione' OR @cu ='trigger_finlevel_copy') RETURN

        CREATE TABLE #finlevel
        (
        	ayear smallint,
        	nlevel tinyint,
        	flag smallint,
        	ct datetime, cu varchar(64), lt datetime, lu varchar(64),
        	description varchar(50)
        )
        
        INSERT INTO #finlevel
        (
        	ayear, nlevel,
        	flag,
        	description, 
        	ct, cu, lt, lu
        )
        SELECT 
        	I.ayear, I.nlevel,
        	I.flag,
        	I.description, 
        	I.ct, 'trigger_finlevel_copy', I.lt, I.lu
        FROM inserted I
        WHERE I.nlevel <= (select unifiedfinlevel from commonconfig where ayear =I.ayear)
        AND cu <> 'trigger_finlevel_copy'
        
        DECLARE @currdep varchar(50)
        SET @currdep = user
        
        DECLARE @iddbdepartment varchar(50)
        
        DECLARE @cursore cursor
        SET @cursore = CURSOR FOR
        SELECT  iddbdepartment FROM dbdepartment WHERE iddbdepartment <> @currdep
        OPEN @cursorE
        FETCH NEXT FROM @cursore INTO @iddbdepartment
        WHILE (@@FETCH_STATUS = 0)
        BEGIN
        	DECLARE @sql nvarchar(2000)
        
        	SET @sql = N'IF (SELECT COUNT(*) from #finlevel where not exists (SELECT * FROM [' + @iddbdepartment + '].finlevel fd '+
        	    ' WHERE #finlevel.nlevel = fd.nlevel AND #finlevel.ayear = fd.ayear) )>0 BEGIN '+
        
        	 ' INSERT INTO [' + @iddbdepartment + '].finlevel' +
        	' (ayear, nlevel, flag, description,  ct, cu, lt, lu)' +
        	' SELECT ayear, nlevel, flag,  description,  ct, ''trigger_finlevel_copy'', lt, lu ' +
        	' FROM #finlevel WHERE NOT EXISTS(SELECT * FROM [' + @iddbdepartment + '].finlevel fd '+
        	    ' WHERE #finlevel.nlevel = fd.nlevel AND #finlevel.ayear = fd.ayear) END '
        
        	PRINT @sql
        	EXEC SP_EXECUTESQL @sql
        
        	FETCH NEXT FROM @cursore INTO @iddbdepartment
        END
        
        DROP TABLE #finlevel

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

