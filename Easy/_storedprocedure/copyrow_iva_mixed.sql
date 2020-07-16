/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿if exists (select * from dbo.sysobjects where id = object_id(N'[copyrow_iva_mixed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure copyrow_iva_mixed
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE copyrow_iva_mixed
(
		@nmixed	int
)
AS BEGIN

 declare @query nvarchar(3000)
 declare @iddbdepartment varchar(50)
 declare @mixed	decimal(19,6)    
 declare @ayear int
 SELECT  @mixed = mixed, @ayear = ayear FROM iva_mixed WHERE nmixed = @nmixed
 declare @nmixedstr varchar(10)
 declare @mixedstr varchar(15)

 declare  @ayearstr varchar(10)
 set @ayearstr= convert(varchar,@ayear)
 set @mixedstr= convert(varchar,@mixed)
 set @nmixedstr= convert(varchar,@nmixed)
  
 declare @amm varchar(100)
 set @amm=user

 declare @crsdepartment cursor
 set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment where iddbdepartment<>@amm order by iddbdepartment
 open 	@crsdepartment
 fetch next from @crsdepartment into @iddbdepartment
 while @@fetch_status=0 
 begin
 print @iddbdepartment
  set @query= 
		' if not exists(select * from ['+@iddbdepartment+'].iva_mixed IM where IM.ayear = '+ @ayearstr+ ' ) '
		+ ' Begin '
		+ ' INSERT INTO ['+@iddbdepartment+'].iva_mixed(mixed, ayear, lt, lu, nmixed) '
		+ ' SELECT mixed, ayear, lt, lu, isnull((select max(nmixed) from ['+@iddbdepartment+'].iva_mixed),0)+1 ' 
		+ ' FROM [' + @amm + '].iva_mixed where nmixed = '+ @nmixedstr
		+ ' END '
		+ ' ELSE ' 
		+ ' Begin '
		+ ' UPDATE  ['+@iddbdepartment+'].iva_mixed SET lt=IM1.lt, lu=IM1.lu, mixed = IM1.mixed'
		+ ' FROM ['+@iddbdepartment+'].iva_mixed inner join '+
		+ '['+@amm+'].iva_mixed IM1 ON IM1.ayear=['+@iddbdepartment+'].iva_mixed.ayear WHERE  IM1.ayear = '+ @ayearstr
		+ ' END '
			
print  @query
EXEC sp_executesql @query



 fetch next from @crsdepartment into @iddbdepartment
 end

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
	