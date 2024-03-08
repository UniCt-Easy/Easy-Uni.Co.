
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


if exists (select * from dbo.sysobjects where id = object_id(N'[copyrow_invoicekind]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [copyrow_invoicekind]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE	PROCEDURE copyrow_invoicekind
(
	@idinvkind int
)
AS BEGIN

 declare @query nvarchar(3000)
 declare @query1 nvarchar(3000)

 declare @iddbdepartment varchar(50)
 declare  @idinvkindstr varchar(10)
 declare @codeinvkindstr varchar(100)
 declare @codeinvkind varchar(100)
 set @idinvkindstr= convert(varchar,@idinvkind)
 SELECT  @codeinvkind = codeinvkind from invoicekind where idinvkind=@idinvkind
 set @codeinvkindstr= ''''+ replace(@codeinvkind,'''','''''')+''''
 
 declare @amm varchar(100)
 set @amm=user
 --set @amm='amm'
 --print user



CREATE TABLE #registerkind (codeivaregisterkind varchar(200))
insert into #registerkind (codeivaregisterkind)
SELECT IRK.codeivaregisterkind from invoicekindregisterkind IKR
		JOIN ivaregisterkind IRK
			ON IKR.idivaregisterkind = IRK.idivaregisterkind
WHERE IKR.idinvkind = @idinvkind
	
		
 DECLARE @crsdepartment CURSOR
 SET 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment where iddbdepartment<>@amm order by iddbdepartment
 OPEN 	@crsdepartment
 fetch next from @crsdepartment into @iddbdepartment
 while @@fetch_status=0 
 begin
  set @query= 
		' DELETE FROM ['+@iddbdepartment+'].invoicekindregisterkind 
		  WHERE ['+@iddbdepartment+'].invoicekindregisterkind.idinvkind IN (SELECT IK.idinvkind FROM ['+@iddbdepartment+'].invoicekind IK
		  WHERE ['+@iddbdepartment+'].invoicekindregisterkind.idinvkind = IK.idinvkind
										AND IK.codeinvkind=' + @codeinvkindstr + ') '+
		' DELETE FROM ['+@iddbdepartment+'].invoicekindyear 
		  WHERE ['+@iddbdepartment+'].invoicekindyear.idinvkind IN (SELECT IK.idinvkind FROM ['+@iddbdepartment+'].invoicekind IK
										WHERE ['+@iddbdepartment+'].invoicekindyear.idinvkind = IK.idinvkind
										AND IK.codeinvkind=' + @codeinvkindstr + ') '+
		' if not exists(select * from ['+@iddbdepartment+'].invoicekind IK where '+
		' IK.codeinvkind= '+@codeinvkindstr+' ) '+
		' insert into ['+@iddbdepartment+'].invoicekind (
		  ct,cu,description,lt,lu,codeinvkind,idinvkind,flag,flag_autodocnumbering,formatstring,active)' +
		' SELECT ct,cu,description,lt,lu,codeinvkind,' + 'isnull((select max(idinvkind) from ['+@iddbdepartment+'].invoicekind),0)+1,' + 
		'flag,flag_autodocnumbering,formatstring,active from ['+@amm+'].invoicekind where idinvkind='+@idinvkindstr+
		' ELSE 
		  BEGIN
			UPDATE  ['+@iddbdepartment+'].invoicekind SET ct=IK1.ct, cu=IK1.cu,description=IK1.description,lt=IK1.lt,lu=IK1.lu,'+
		'	codeinvkind=IK1.codeinvkind, 	flag=IK1.flag, flag_autodocnumbering = IK1.flag_autodocnumbering,formatstring= IK1.formatstring, active= IK1.active
			FROM ['+@iddbdepartment+'].invoicekind inner join '+
			'['+@amm+'].invoicekind IK1 ON IK1.codeinvkind=['+@iddbdepartment+'].invoicekind.codeinvkind  WHERE  IK1.idinvkind='+@idinvkindstr+
			' END' +
		' DECLARE @new_idinvkind int
		  SELECT @new_idinvkind=idinvkind from ['+@iddbdepartment+'].invoicekind where codeinvkind = ' +@codeinvkindstr+

		' INSERT INTO ['+@iddbdepartment+'].invoicekindregisterkind(idinvkind,idivaregisterkind,ct,cu,lt,lu)
		  SELECT @new_idinvkind,idivaregisterkind,ct,cu,lt,lu
		  FROM #registerkind 
			JOIN ['+@iddbdepartment+'].ivaregisterkind
				ON #registerkind.codeivaregisterkind = ['+@iddbdepartment+'].ivaregisterkind.codeivaregisterkind'+
		' INSERT INTO ['+@iddbdepartment+'].invoicekindyear (ayear,idinvkind,ct,cu,idacc,idacc_deferred,idacc_discount,
															 idacc_unabatable,lt,lu,idacc_deferred_intra,idacc_intra,idacc_unabatable_intra,idacc_deferred_split,idacc_split,idacc_unabatable_split)
		  SELECT ayear,@new_idinvkind,ct,cu,idacc,idacc_deferred,idacc_discount,
															 idacc_unabatable,lt,lu,idacc_deferred_intra,idacc_intra,idacc_unabatable_intra,idacc_deferred_split,idacc_split,idacc_unabatable_split
		  FROM ['+@amm+'].invoicekindyear where idinvkind = ' + @idinvkindstr 
	
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


