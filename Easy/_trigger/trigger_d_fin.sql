
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_fin]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_fin]
GO

CREATE   TRIGGER [trigger_d_fin] ON [fin] FOR DELETE
AS BEGIN
IF (@@ROWCOUNT = 0) RETURN

CREATE TABLE #fin
(
	idfin int,
	codefin varchar(50),
	flag tinyint,
	ayear smallint,
	paridfin int
)
INSERT INTO #fin (idfin,paridfin)  SELECT idfin,paridfin FROM deleted 


DELETE FROM finlookup WHERE EXISTS(SELECT * FROM #fin WHERE #fin.idfin = finlookup.oldidfin OR #fin.idfin = finlookup.newidfin)
DELETE FROM prevfindetail WHERE EXISTS (SELECT * FROM #fin WHERE #fin.idfin = prevfindetail.idfin )
DELETE FROM finbalancedetail WHERE EXISTS (SELECT * FROM #fin WHERE #fin.idfin = finbalancedetail.idfin )
DELETE FROM finlink	WHERE idchild IN (SELECT idfin FROM #fin)

insert into finlast  (idfin, idman, cupcode, expiration, ct, cu, lt, lu)
	select distinct #fin.paridfin, null, null, null, GETDATE(), 'TRIGGER', GETDATE(), '''TRIGGER'''
	from #fin
		join fin on fin.idfin= #fin.paridfin
		left outer join  finlast on finlast.idfin = #fin.paridfin
	where (SELECT COUNT(*) FROM finlink WHERE idparent = #fin.paridfin ) = 1
			and finlast.idfin is null
			


DELETE FROM #fin

IF (TRIGGER_NESTLEVEL () > 1 ) RETURN

INSERT INTO #fin ( codefin,flag, ayear)
SELECT codefin, flag & 1, ayear FROM deleted  WHERE nlevel <= (SELECT unifiedfinlevel FROM commonconfig WHERE ayear = deleted.ayear)


DECLARE @currdep varchar(50)
SET @currdep = user



DECLARE @iddbdepartment varchar(50)
DECLARE @cursore cursor


declare @cursfin cursor
declare @ayear smallint
declare @codefin varchar(100) 
declare @flagfin tinyint

IF (user='amministrazione')
Begin
        SET @cursore = CURSOR FOR
        SELECT  iddbdepartment FROM dbdepartment WHERE iddbdepartment <> @currdep
        OPEN @cursore
        FETCH NEXT FROM @cursore INTO @iddbdepartment
        WHILE (@@FETCH_STATUS = 0)
        BEGIN
        
        	SET @cursfin = CURSOR FOR
        	SELECT  ayear,codefin,flag FROM #fin 
        	OPEN @cursfin
        	FETCH NEXT FROM @cursfin INTO @ayear,@codefin,@flagfin
        	WHILE (@@FETCH_STATUS = 0)
        	BEGIN
        		set @codefin=''''+replace(@codefin,'''','''''')+''''
        		DECLARE @sql nvarchar(2000)
        		SET @sql = N'DELETE FROM [' + @iddbdepartment + '].fin' +
        			' WHERE codefin ='+@codefin+' and ayear='+convert(varchar(5),@ayear)+
        			' and (flag & 1)='+convert(varchar(5),@flagfin)
        		--PRINT @sql
        		EXEC SP_EXECUTESQL @sql
        		FETCH NEXT FROM @cursfin INTO @ayear,@codefin,@flagfin
        	END --WHILE
        	CLOSE @cursfin
        	DEALLOCATE @cursfin
        
        	FETCH NEXT FROM @cursore INTO @iddbdepartment	
        END --WHILE
        CLOSE  @cursore
        DEALLOCATE  @cursore
End

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

