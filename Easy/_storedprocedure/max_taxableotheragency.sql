
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


if exists (select * from dbo.sysobjects where id = object_id(N'[max_taxableotheragency]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [max_taxableotheragency]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE     PROCEDURE [max_taxableotheragency](
	@ayear 		smallint,
	@idreg		int,
	@res decimal(19,6) out
) as 
begin

create table #mytable (taxableotheragency decimal(19,6) null)
declare @iddbdepartment varchar(50)
declare @currstmt nvarchar(1000)

declare @num int

declare @cursore cursor
set @cursore = cursor for select  iddbdepartment from dbdepartment
						   where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
open @cursore
fetch next from @cursore into @iddbdepartment

while @@fetch_status=0 begin
	--print @iddbdepartment
	
		SET @currstmt= 'SELECT  max(taxableotheragency)  FROM '+ @iddbdepartment + '.casualcontractyear CY' +
					' join ' + @iddbdepartment + '.casualcontract C on C.ycon = CY.ycon and C.ncon = CY.ncon ' + 
					' where ayear = '+convert(varchar(20),@ayear)+' and isnull(taxableotheragency,0)>0 and ' + 
					' C.idreg= '+convert(varchar(20),@idreg)
	--print @currstmt
	insert into #mytable exec sp_executesql @currstmt
	fetch next from @cursore into @iddbdepartment	
end

SET @res= ISNULL((SELECT max(taxableotheragency) from #mytable), 0)
--print @res
drop table #mytable
--print @res
end



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

