
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_finlast]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_finlast]
GO

CREATE  TRIGGER [trigger_d_finlast] ON [finlast] FOR DELETE
AS BEGIN

IF (@@ROWCOUNT = 0) RETURN
DECLARE @idfin int

SELECT	@idfin = idfin
FROM deleted



DECLARE @ayear int
SELECT  @ayear = ayear FROM fin WHERE idfin = @idfin

IF (user<>'amministrazione'  )return
IF (TRIGGER_NESTLEVEL () > 1 ) RETURN



DECLARE @unifiedfinlevel smallint
SET @unifiedfinlevel = (SELECT unifiedfinlevel FROM commonconfig WHERE ayear = @ayear  )

-- Parte di propagazione delle modifiche a tutti i dipartimenti

        CREATE TABLE #finlast (codefin varchar(50),flag tinyint, ayear smallint)
        
        INSERT INTO #finlast (codefin, flag, ayear)
        SELECT fin.codefin, fin.flag & 1, fin.ayear
        FROM deleted
        JOIN fin
        ON fin.idfin = deleted.idfin
        WHERE fin.nlevel <= @unifiedfinlevel
        
        DECLARE @currdep varchar(50)
        SET @currdep = user
        
        DECLARE @iddbdepartment varchar(50)
        
        DECLARE @cursore cursor
        declare @cursfin cursor
        
        
        declare @ayearfin smallint
        declare @codefin varchar(100) 
        declare @flagfin tinyint
        
        SET @cursore = CURSOR FOR
        SELECT  iddbdepartment FROM dbdepartment WHERE iddbdepartment <> @currdep
        OPEN @cursore
        FETCH NEXT FROM @cursore INTO @iddbdepartment
        WHILE (@@FETCH_STATUS = 0)
        BEGIN
        	
        	SET @cursfin = CURSOR FOR SELECT  ayear,codefin,flag FROM #finlast 
        	OPEN @cursfin
        	FETCH NEXT FROM @cursfin INTO @ayearfin,@codefin,@flagfin
        	WHILE (@@FETCH_STATUS = 0)
        		BEGIN
        		set @codefin=''''+replace(@codefin,'''','''''')+''''
        		DECLARE @sql nvarchar(2000)
        		SET @sql = N'DELETE FROM [' + @iddbdepartment + '].finlast  WHERE idfin = '+	
        			'(SELECT idfin from ['+@iddbdepartment+'].fin where codefin='+@codefin+
        			'  and ayear='+convert(varchar(5),@ayear)+
        			'  and (flag & 1)='+convert(varchar(5),@flagfin)+')'
        		--PRINT @sql
        		EXEC SP_EXECUTESQL @sql
        		FETCH NEXT FROM @cursfin INTO @ayearfin,@codefin,@flagfin
        	
        	END --WHILE
        	CLOSE @cursfin
        	DEALLOCATE @cursfin
        
        
        	FETCH NEXT FROM @cursore INTO @iddbdepartment
        END
        CLOSE @cursore
        DEALLOCATE  @cursore
        DROP TABLE #finlast


END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

