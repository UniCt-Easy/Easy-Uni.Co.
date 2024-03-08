
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[copyrow_ivaregisterkind]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [copyrow_ivaregisterkind]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE			copyrow_ivaregisterkind
(
	@idivaregisterkind int
)
AS BEGIN

 declare @query nvarchar(3000)
 declare @iddbdepartment varchar(50)
 declare  @idivaregisterkindstr varchar(10)
 declare @codeivaregisterkindstr varchar(100)
 declare @codeivaregisterkind varchar(100)
 set @idivaregisterkindstr= convert(varchar,@idivaregisterkind)
 SELECT  @codeivaregisterkind = codeivaregisterkind from ivaregisterkind where idivaregisterkind=@idivaregisterkind
 set @codeivaregisterkindstr= ''''+ replace(@codeivaregisterkind,'''','''''')+''''
 
 declare @amm varchar(100)
 set @amm=user
 --set @amm='amm'
 --print user

 declare @crsdepartment cursor
 set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment where iddbdepartment<>@amm order by iddbdepartment
 open 	@crsdepartment
 fetch next from @crsdepartment into @iddbdepartment
 while @@fetch_status=0 
 begin
  set @query= 'if not exists(select * from ['+@iddbdepartment+'].ivaregisterkind IK where '+
		' IK.codeivaregisterkind= '+@codeivaregisterkindstr+' ) '+
		' insert into ['+@iddbdepartment+'].ivaregisterkind (
	
		ct,cu,description,idivaregisterkindunified,lt,lu,registerclass,flagactivity,codeivaregisterkind,idivaregisterkind,compensation)' +


		' SELECT ct,cu,description,idivaregisterkindunified,lt,lu,registerclass,flagactivity,codeivaregisterkind,' + 'isnull((select max(idivaregisterkind) from ['+@iddbdepartment+'].ivaregisterkind),0)+1' + 
		' , compensation '+
		' from ['+@amm+'].ivaregisterkind where idivaregisterkind='+@idivaregisterkindstr+
		' ELSE UPDATE  ['+@iddbdepartment+'].ivaregisterkind SET ct=IK1.ct, cu=IK1.cu,description=IK1.description,idivaregisterkindunified=IK1.idivaregisterkindunified,lt=IK1.lt,lu=IK1.lu,'+
		'registerclass=IK1.registerclass,flagactivity=IK1.flagactivity,codeivaregisterkind=IK1.codeivaregisterkind,compensation=IK1.compensation '+
		' FROM ['+@iddbdepartment+'].ivaregisterkind inner join '+
		'['+@amm+'].ivaregisterkind IK1 ON IK1.codeivaregisterkind=['+@iddbdepartment+'].ivaregisterkind.codeivaregisterkind  WHERE  IK1.idivaregisterkind='+@idivaregisterkindstr
	
 print @query

 EXEC sp_executesql @query
 


 fetch next from @crsdepartment into @iddbdepartment
 end

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
