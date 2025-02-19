
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_foreigngroup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_foreigngroup]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [compute_foreigngroup](
	@iditineration int,
	@res int out
) AS
BEGIN
	DECLARE @idreg int
	DECLARE @idregistrylegalstatus int
	DECLARE @idposition int
	DECLARE @livello int
	DECLARE	@incomeclass int
	DECLARE @foreigngroupnumber int
	
	select @idreg = idreg, @idregistrylegalstatus = idregistrylegalstatus from itineration
	where  iditineration = @iditineration
	
 	
	select @incomeclass=incomeclass ,@idposition=idposition, @livello = livello from registrylegalstatus 
	where  idreg=@idreg and idregistrylegalstatus=@idregistrylegalstatus 
	
	
	select top 1 @foreigngroupnumber=foreigngroupnumber from foreigngroupruledetail 
	join foreigngrouprule on (foreigngrouprule.idforeigngrouprule=foreigngroupruledetail.idforeigngrouprule) 
	where ((@incomeclass between minincomeclass and maxincomeclass) OR (maxincomeclass=0))
	and idposition=@idposition
	and (livello=@livello or @livello is null)
	order by foreigngrouprule.start desc
	
	print @idregistrylegalstatus
	print @idreg
	print @incomeclass
	print @idposition
	
	set @res=@foreigngroupnumber
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

