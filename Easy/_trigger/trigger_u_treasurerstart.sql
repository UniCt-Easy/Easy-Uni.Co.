SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_treasurerstart]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_treasurerstart]
GO

CREATE TRIGGER [trigger_u_treasurerstart] ON [treasurerstart] FOR UPDATE
AS BEGIN

DECLARE @idtreasurer int
DECLARE @oldamount decimal(19,2)
DECLARE @newamount decimal(19,2)
DECLARE @ayear int

SELECT  @oldamount = amount FROM deleted

SELECT  @idtreasurer = idtreasurer, 
		@newamount = amount, 
		@ayear = ayear FROM inserted

DECLARE @amountDiff decimal(19,2)
SET @amountDiff = @newamount - @oldamount

IF ( @newamount<>@oldamount  )
	Begin

		UPDATE treasurercashtotal SET currentfloatfund = isnull(currentfloatfund,0) + @amountDiff
		WHERE idtreasurer = @idtreasurer and ayear = @ayear

	End


END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

