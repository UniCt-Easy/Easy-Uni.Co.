
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_finlookup]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_finlookup]
GO


CREATE TRIGGER [trigger_d_finlookup] ON finlookup FOR DELETE
AS BEGIN
IF (@@ROWCOUNT = 0) RETURN

IF (user<>'amministrazione') return
IF (TRIGGER_NESTLEVEL () > 1 ) RETURN

CREATE TABLE #finlookup
(
	oldidfin int,
	newidfin int,
	oldcodefin varchar(50),
	newcodefin varchar(50),
	newflag tinyint,
	oldayear smallint,
	newayear smallint
)

INSERT INTO #finlookup
SELECT oldidfin, newidfin,fo.codefin,fn.codefin,fn.flag&1,fo.ayear,fn.ayear
FROM deleted
JOIN fin fo
	ON fo.idfin = deleted.oldidfin
JOIN fin fn
	ON fn.idfin = deleted.newidfin
WHERE fo.nlevel <= (SELECT unifiedfinlevel FROM commonconfig WHERE ayear  = fo.ayear)
AND fn.nlevel <= (SELECT unifiedfinlevel FROM commonconfig WHERE ayear = fn.ayear)

DECLARE @currdep varchar(50)
SET @currdep = user

DECLARE @iddbdepartment varchar(50)
declare @cursfin cursor
declare @oldayear smallint
declare @newayear smallint
declare @oldcodefin varchar(100) 
declare @newcodefin varchar(100) 
declare @flagfin tinyint


declare @newidfin int
declare @oldidfin int



        DECLARE @cursore cursor
        SET @cursore = CURSOR FOR
        SELECT  iddbdepartment FROM dbdepartment WHERE iddbdepartment <> @currdep
        OPEN @cursore
        FETCH NEXT FROM @cursore INTO @iddbdepartment
        WHILE (@@FETCH_STATUS = 0)
        BEGIN
        
        	SET @cursfin = CURSOR FOR
        	SELECT  oldayear,oldcodefin,newflag,newayear,newcodefin FROM #finlookup 
        	OPEN @cursfin
        	FETCH NEXT FROM @cursfin INTO @oldayear,@oldcodefin,@flagfin,@newayear,@newcodefin
        	WHILE (@@FETCH_STATUS = 0)
        	BEGIN
        		set @oldcodefin=''''+replace(@oldcodefin,'''','''''')+''''
        		set @newcodefin=''''+replace(@newcodefin,'''','''''')+''''
        
        		DECLARE @sql nvarchar(2000)
        
        		SET @sql = N'DELETE FROM [' + @iddbdepartment + '].finlookup' +
        		' WHERE EXISTS(SELECT * FROM #finlookup ' +
        		' WHERE [' + @iddbdepartment + '].finlookup.oldidfin =  ' +
        			'(SELECT idfin from ['+@iddbdepartment+'].fin where codefin='+@oldcodefin+
        			'  and ayear='+convert(varchar(5),@oldayear)+
        			'  and (flag & 1)='+convert(varchar(5),@flagfin)+')' +
        		' AND [' + @iddbdepartment + '].finlookup.newidfin = '+
        			'(SELECT idfin from ['+@iddbdepartment+'].fin where codefin='+@newcodefin+
        			'  and ayear='+convert(varchar(5),@newayear)+
        			'  and (flag & 1)='+convert(varchar(5),@flagfin)+')' + 
        			' )'
        	
        		PRINT @sql
        		EXEC SP_EXECUTESQL @sql
        
        		FETCH NEXT FROM @cursfin INTO @oldayear,@oldcodefin,@flagfin,@newayear,@newcodefin
        
        	END --WHILE
        	CLOSE  @cursfin
        	DEALLOCATE  @cursfin
        
        	FETCH NEXT FROM @cursore INTO @iddbdepartment
        END --WHILE
        CLOSE  @cursore
        DEALLOCATE  @cursore


END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
