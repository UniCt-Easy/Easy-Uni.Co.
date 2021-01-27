
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


/****** Object:  StoredProcedure [amm].[count_contract]    Script Date: 05/12/2014 11.53.10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[count_contract]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [count_contract]
GO


--input @kind= C occasionale  o P professionale
CREATE    PROCEDURE [count_contract](
	@ayear 		smallint,
	@kind 		char(1),
	@idreg		int,
	@res int out
) as 
begin

create table #mytable (nrows int)
declare @iddbdepartment varchar(50)
declare @currstmt nvarchar(1000)

declare @num int

declare @cursore cursor
set @cursore = cursor for select  iddbdepartment from dbdepartment
open @cursore
fetch next from @cursore into @iddbdepartment

while @@fetch_status=0 begin
--	print @iddbdepartment
	if (@kind='C')
		SET @currstmt= 'SELECT  COUNT(*) FROM ['+ @iddbdepartment + '].casualcontract' +
					' where ycon = '+convert(varchar(20),@ayear)+' and idreg= '+convert(varchar(20),@idreg)
	else
		SET @currstmt= 'SELECT  COUNT(*) FROM ['+ @iddbdepartment + '].profservice' +
					' where ycon = '+convert(varchar(20),@ayear)+' and idreg= '+convert(varchar(20),@idreg)

	insert into #mytable exec sp_executesql @currstmt
	if (select max(nrows) from #mytable)>0 break
	delete from #mytable 
	fetch next from @cursore into @iddbdepartment	
end

SET @res= ISNULL((SELECT max(nrows) from #mytable), 0)
drop table #mytable
--print @res
end
