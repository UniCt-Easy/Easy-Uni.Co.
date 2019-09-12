SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_entry]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_entry]
GO

create        TRIGGER [trigger_d_entry] ON [entry] FOR DELETE
AS BEGIN
	DECLARE @yentry int
	DECLARE @nentry int

	SELECT
		@yentry = yentry, 
		@nentry = nentry
	FROM deleted
	
	delete from entrytotal where yentry = @yentry and nentry = @nentry

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 