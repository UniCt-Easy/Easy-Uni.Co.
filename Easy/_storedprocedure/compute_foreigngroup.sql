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
	DECLARE	@incomeclass int
	DECLARE @foreigngroupnumber int
	
	select @idreg = idreg, @idregistrylegalstatus = idregistrylegalstatus from itineration
	where  iditineration = @iditineration
	
 	
	select @incomeclass=incomeclass ,@idposition=idposition from registrylegalstatus 
	where  idreg=@idreg and idregistrylegalstatus=@idregistrylegalstatus 
	

	select top 1 @foreigngroupnumber=foreigngroupnumber from foreigngroupruledetail 
	join foreigngrouprule on (foreigngrouprule.idforeigngrouprule=foreigngroupruledetail.idforeigngrouprule) 
	where ((@incomeclass between minincomeclass and maxincomeclass) OR (maxincomeclass=0))
	and idposition=@idposition
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

