if exists (select * from dbo.sysobjects where id = object_id(N'[count_idfin_table_multifield]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [count_idfin_table_multifield]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   procedure count_idfin_table_multifield (
@tablenames varchar(800),
@idfinname varchar(50),@idfinvalue int,
@equal char(2),-- se vale 1 è '=' se vale 0 è '<>'
@andor char(3),-- se vale 1 è 'and' se vale 0 è 'or'
@fieldname1 varchar(50),
@fieldname2 varchar(50),
@fieldname3 varchar(50),
@fieldname4 varchar(50),
@fieldname5 varchar(50),
@fieldname6 varchar(50),
@fieldname7 varchar(50),
@fieldname8 varchar(50),
@fieldname9 varchar(50),
@fieldname10 varchar(50),
@fieldname11 varchar(50),
@fieldname12 varchar(50),
@fieldname13 varchar(50),
@fieldname14 varchar(50),
@fieldname15 varchar(50),
@fieldname16 varchar(50),
@fieldname17 varchar(50),
@fieldname18 varchar(50),
@fieldname19 varchar(50),
@fieldname20 varchar(50),

@res int out
) as
BEGIN
IF (@equal='1')
        SET  @equal = '='
ELSE
        SET  @equal = '<>'

IF (@andor='1')
        SET  @andor = 'AND'
ELSE
        SET  @andor = 'OR'

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
        		-- print @iddbdepartment+'.'+@tablenames
        		SET @currstmt= 'SELECT  COUNT(*) FROM '+ @iddbdepartment + '.' + @currtablename +' as T'
                                        + ' JOIN '+ @iddbdepartment + '.fin as F' 
                                        + ' ON F.idfin = T.'+ @idfinname 
                                	+ ' where  F.codefin='''+replace(@codefin,'''',''''+'''') + ''''
                                        + ' and (F.flag & 1)='+isnull(convert(varchar(5),@flag),'null')+
                                        + ' and  F.ayear ='+ convert(varchar(4),@ayear)  
                                        + ' AND ( '
                        IF (@fieldname1 is not null)
                                SET @currstmt = @currstmt + ' T.'+@fieldname1 +''+@equal+'0' 
                        IF (@fieldname2 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname2 +''+@equal+'0' 
                        IF (@fieldname3 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname3 +''+@equal+'0' 
                        IF (@fieldname4 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname4 +''+@equal+'0' 
                        IF (@fieldname5 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname5 +''+@equal+'0' 
                        IF (@fieldname6 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname6 +''+@equal+'0' 
                        IF (@fieldname7 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname7 +''+@equal+'0' 
                        IF (@fieldname8 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname8 +''+@equal+'0' 
                        IF (@fieldname9 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname9 +''+@equal+'0' 
                        IF (@fieldname10 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname10 +''+@equal+'0' 
                        IF (@fieldname11 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname11 +''+@equal+'0' 
                        IF (@fieldname12 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname12 +''+@equal+'0' 
                        IF (@fieldname13 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname13 +''+@equal+'0' 
                        IF (@fieldname14 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname14 +''+@equal+'0' 
                        IF (@fieldname15 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname15 +''+@equal+'0' 
                        IF (@fieldname16 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname16 +''+@equal+'0' 
                        IF (@fieldname17 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname17 +''+@equal+'0' 
                        IF (@fieldname18 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname18 +''+@equal+'0' 
                        IF (@fieldname19 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname19 +''+@equal+'0' 
                        IF (@fieldname20 is not null)
                                SET @currstmt = @currstmt + ' '+ @andor + ' T.'+@fieldname20 +''+@equal+'0' 
                        SET @currstmt = @currstmt  + ' ) '


        		INSERT INTO #mytable exec sp_executesql @currstmt
                        -- print @currstmt
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

