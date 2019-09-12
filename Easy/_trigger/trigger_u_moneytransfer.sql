SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_moneytransfer]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_moneytransfer]
GO

CREATE TRIGGER [trigger_u_moneytransfer] ON [moneytransfer] FOR UPDATE
AS BEGIN

DECLARE @idtreasurerSource int
DECLARE @idtreasurerDest int
DECLARE @oldamount decimal(19,2)
DECLARE @newamount decimal(19,2)
DECLARE @ayear int

SELECT  @oldamount = amount FROM deleted

SELECT  @idtreasurerSource = idtreasurersource, 
		@idtreasurerDest = idtreasurerdest, 
		@newamount = amount, 
		@ayear = ytransfer FROM inserted

DECLARE @amountDiff decimal(19,2)
SET @amountDiff = @newamount - @oldamount

-- Al momento è possibile modificare SOLO l'importo
IF ( @newamount<>@oldamount  )
	Begin
		UPDATE treasurercashtotal SET currentfloatfund = isnull(currentfloatfund,0) - @amountDiff
		WHERE idtreasurer = @idtreasurerSource and ayear = @ayear

		UPDATE treasurercashtotal SET currentfloatfund = isnull(currentfloatfund,0) + @amountDiff
		WHERE idtreasurer = @idtreasurerDest and ayear = @ayear

	End


END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

