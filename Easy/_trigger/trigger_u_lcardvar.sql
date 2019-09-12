SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_lcardvar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_lcardvar]
GO


CREATE   TRIGGER [trigger_u_lcardvar] ON [lcardvar] FOR UPDATE
AS BEGIN
	DECLARE @idlcard int
	DECLARE @new_amount decimal(19,2)
	DECLARE @old_amount decimal(19,2)

	select @idlcard = idlcard,@old_amount = amount from deleted
	select @new_amount = amount from inserted

	if not exists (select * from lcardtotal where idlcard = @idlcard) 
	BEGIN 
		insert into lcardtotal(idlcard,amount) values (@idlcard,@new_amount-@old_amount)
	END
	ELSE
	BEGIN
		update lcardtotal set amount = amount+@new_amount-@old_amount where idlcard = @idlcard
	END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



