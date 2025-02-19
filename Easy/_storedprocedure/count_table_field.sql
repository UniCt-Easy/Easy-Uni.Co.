
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[count_table_field]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [count_table_field]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   procedure count_table_field (
@tablenames varchar(800),
@fieldname varchar(50),
@fieldvalue varchar(100),
@res int out
) as
BEGIN

declare @iddbdepartment varchar(50)
create table #mytable (nrows int)

select  @fieldvalue = REPLACE(@fieldvalue,'''','''''')

declare @cursore cursor
set @cursore = cursor for select  iddbdepartment from dbdepartment
open @cursore
fetch next from @cursore into @iddbdepartment
while @@fetch_status=0 begin

	declare @startpos int
	declare @nextcomma int
	declare @currtablename varchar(40)
	
	declare @currstmt nvarchar(1000)

	set @startpos=0
	set @nextcomma= charindex(',', @tablenames,@startpos)
	
	while (@startpos>=0) begin
		if (@nextcomma>0)
			SET @currtablename = SUBSTRING(@tablenames,@startpos,@nextcomma-@startpos)
		else
			SET @currtablename = SUBSTRING(@tablenames,@startpos,50)
		
		IF EXISTS(select * from sysobjects where id = object_id(@iddbdepartment+'.'+@currtablename) 
				and (OBJECTPROPERTY(id, N'IsUserTable') = 1 or OBJECTPROPERTY(id, N'IsView') = 1)
			and (uid=user_id(@iddbdepartment))) begin

			--print @iddbdepartment+'.'+@currtablename
			SET @currstmt= 'SELECT  COUNT(*) FROM '+ @iddbdepartment + '.' + @currtablename +
					' where '+@fieldname+' = '''+@fieldvalue+''''
			print @currstmt
			insert into #mytable exec sp_executesql @currstmt

			if (select max(nrows) from #mytable)>0 break
			delete from #mytable 
		end
	
		if (@nextcomma=0) break;

		set @startpos=@nextcomma+1
		set @nextcomma= charindex(',', @tablenames,@startpos)
	end
	
	fetch next from @cursore into @iddbdepartment	
	if (select max(nrows) from #mytable)>0 break
		
end

--si occupa delle tabelle dbo

	set @startpos=0
	set @nextcomma= charindex(',', @tablenames,@startpos)

	set @iddbdepartment='dbo'	

	while (@startpos>=0) begin
		if (@nextcomma>0)
			SET @currtablename = SUBSTRING(@tablenames,@startpos,@nextcomma-@startpos)
		else
			SET @currtablename = SUBSTRING(@tablenames,@startpos,50)
		
		IF EXISTS(select * from sysobjects where id = object_id(@iddbdepartment+'.'+@currtablename) 
				and (OBJECTPROPERTY(id, N'IsUserTable') = 1 or OBJECTPROPERTY(id, N'IsView') = 1)
			and (uid=user_id(@iddbdepartment))) begin

			--print @iddbdepartment+'.'+@currtablename
			SET @currstmt= 'SELECT  COUNT(*) FROM '+ @iddbdepartment + '.' + @currtablename +
					' where '+@fieldname+' = '''+@fieldvalue+''''
			--print @currstmt
			insert into #mytable exec sp_executesql @currstmt
			if (select max(nrows) from #mytable)>0 break
			delete from #mytable 
		end
	
		if (@nextcomma=0) break;

		set @startpos=@nextcomma+1
		set @nextcomma= charindex(',', @tablenames,@startpos)
	end
	

SET @res= ISNULL((SELECT max(nrows) from #mytable), 0)

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

