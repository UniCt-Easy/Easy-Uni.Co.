SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_lcard]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_lcard]
GO

CREATE TRIGGER [trigger_d_lcard] ON [lcard] FOR DELETE
AS BEGIN
	DECLARE @idlcard int

	select @idlcard = idlcard from deleted
	delete from lcardtotal where idlcard = @idlcard


END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



