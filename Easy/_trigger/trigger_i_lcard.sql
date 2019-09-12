SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_lcard]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_lcard]
GO

CREATE   TRIGGER  [trigger_i_lcard] ON  [lcard] FOR INSERT
AS BEGIN
	DECLARE @idlcard int

	select @idlcard = idlcard from inserted
	if not exists (select * from lcardtotal where idlcard = @idlcard) 
	BEGIN 
		insert into lcardtotal(idlcard,amount) values (@idlcard,0)
	END
	ELSE
	BEGIN
		update lcardtotal set amount = 0 where idlcard = @idlcard
	END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

