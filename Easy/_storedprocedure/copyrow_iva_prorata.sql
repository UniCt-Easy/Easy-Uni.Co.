
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



if exists (select * from dbo.sysobjects where id = object_id(N'[copyrow_iva_prorata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [copyrow_iva_prorata]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE			copyrow_iva_prorata
(
		@nprorata	int
)
AS BEGIN

 declare @query nvarchar(3000)
 declare @iddbdepartment varchar(50)
 declare @prorata	decimal(19,6)    
 declare @ayear int
 SELECT  @prorata = prorata, @ayear = ayear FROM iva_prorata WHERE nprorata = @nprorata

 declare @nproratastr varchar(10)
 declare @proratastr varchar(15)

 declare  @ayearstr varchar(10)
 set @ayearstr= convert(varchar,@ayear)
 set @proratastr= convert(varchar,@prorata)
 set @nproratastr= convert(varchar,@nprorata)
  
 declare @amm varchar(100)
 set @amm=user

 declare @crsdepartment cursor
 set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment where iddbdepartment<>@amm order by iddbdepartment
 open 	@crsdepartment
 fetch next from @crsdepartment into @iddbdepartment
 while @@fetch_status=0 
 begin
  set @query= 
		' if not exists(select * from ['+@iddbdepartment+'].iva_prorata IP where IP.ayear = '+ @ayearstr+ ' ) '
		+ ' Begin '
		+ ' INSERT INTO ['+@iddbdepartment+'].iva_prorata (prorata, ayear, lt, lu, nprorata) '
		+ ' SELECT prorata, ayear, lt, lu, isnull((select max(nprorata) from ['+@iddbdepartment+'].iva_prorata),0)+1 ' 
		+ ' FROM [' + @amm + '].iva_prorata where nprorata = '+ @nproratastr
		+ ' END '
		+ ' ELSE ' 
		+ ' Begin '
		+ ' UPDATE  ['+@iddbdepartment+'].iva_prorata SET lt=IP1.lt, lu=IP1.lu, prorata = IP1.prorata'
		+ ' FROM ['+@iddbdepartment+'].iva_prorata inner join '+
		+ '['+@amm+'].iva_prorata IP1 ON IP1.ayear=['+@iddbdepartment+'].iva_prorata.ayear WHERE  IP1.ayear = '+ @ayearstr
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
