SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_lcardvar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_lcardvar]
GO

CREATE TRIGGER [trigger_d_lcardvar] ON [lcardvar] FOR DELETE
AS BEGIN
	DECLARE @idlcard int
	DECLARE @amount decimal(19,2)

	select @idlcard = idlcard,@amount = amount from deleted

	if not exists (select * from lcardtotal where idlcard = @idlcard) 
	BEGIN 
		insert into lcardtotal(idlcard,amount) values (@idlcard,-@amount)
	END
	ELSE
	BEGIN
		update lcardtotal set amount = amount-@amount where idlcard = @idlcard
	END

END
GO




SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

