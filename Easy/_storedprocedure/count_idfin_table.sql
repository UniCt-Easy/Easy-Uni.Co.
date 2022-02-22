
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[count_idfin_table]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [count_idfin_table]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   procedure count_idfin_table (
@tablenames varchar(800),
@idfinname varchar(50),
@idfinvalue int,
@res int out
) as
BEGIN

-- Legge codefin,ayear e flag da fin del dipartimento corrente.
DECLARE @codefin varchar(50)
DECLARE @ayear smallint
DECLARE @flag tinyint
DECLARE @nlevel tinyint

SELECT @codefin=codefin, @ayear =ayear, @flag=(flag&1), @nlevel= nlevel
FROM fin 
WHERE idfin = @idfinvalue

declare @startpos int 
DECLARE @iddbdepartment varchar(50)
declare @nextcomma int 
DECLARE @currstmt nvarchar(1000)
declare @currtablename varchar(40) 
CREATE table #mytable (nrows int)

--Se sto eseguendo questa sp vuol dire che il livello di @idfinvalue è <= di  unifiedfinlevel, quindi devo cercare in tutti i dipartimenti, 
-- in base a AYEAR/CODEFIN/fla&1
DECLARE @cursore cursor
SET @cursore = cursor for select  iddbdepartment from dbdepartment
OPEN @cursore
fetch next from @cursore into @iddbdepartment
while @@fetch_status=0 
begin
	set @startpos=0
	set @nextcomma= charindex(',', @tablenames,@startpos)
	
	while (@startpos>=0) 
        begin
		if (@nextcomma>0)
			SET @currtablename = SUBSTRING(@tablenames,@startpos,@nextcomma-@startpos)
		else
			SET @currtablename = SUBSTRING(@tablenames,@startpos,50)


        	IF EXISTS(select * from sysobjects where id = object_id(@iddbdepartment+'.'+@currtablename) 
				and (OBJECTPROPERTY(id, N'IsUserTable') = 1 or OBJECTPROPERTY(id, N'IsView') = 1)
		and (uid=user_id(@iddbdepartment))) 
                  begin
        --		print @iddbdepartment+'.'+@tablenames
        		SET @currstmt= 'SELECT  COUNT(*) FROM '+ @iddbdepartment + '.' + @currtablename +' as T'
                                        + ' JOIN '+ @iddbdepartment + '.fin as F' 
                                        + ' ON F.idfin = T.'+ @idfinname 
                                	+ ' where  F.codefin='''+replace(@codefin,'''',''''+'''') + ''''
                                        + ' and (F.flag & 1)='+isnull(convert(varchar(5),@flag),'null')+
                                        + ' and  F.ayear ='+ convert(varchar(4),@ayear)  
        
        		INSERT INTO #mytable exec sp_executesql @currstmt
        --                 print @currstmt
        		if (select max(nrows) from #mytable)>0 break
        		DELETE FROM #mytable 
        end
	
                        
        if (@nextcomma=0) break;
        
        set @startpos=@nextcomma+1
        set @nextcomma= charindex(',', @tablenames,@startpos)
	end

        fetch next from @cursore into @iddbdepartment	
	if (select max(nrows) from #mytable)>0 break
end


SET @res= ISNULL((SELECT max(nrows) from #mytable), 0)


END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

