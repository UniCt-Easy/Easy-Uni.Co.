SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_moneytransfer]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_moneytransfer]
GO

CREATE TRIGGER [trigger_i_moneytransfer] ON [moneytransfer] FOR INSERT
AS BEGIN 

DECLARE @idtreasurerSource int
DECLARE @idtreasurerDest int
DECLARE @amount decimal(19,2)
DECLARE @amountNeg decimal(19,2)
DECLARE @ayear int

SELECT	@idtreasurerSource = idtreasurersource,
		@idtreasurerDest	= idtreasurerdest,
		@amount = amount,
		@ayear = ytransfer
FROM inserted


-- Cassiere di Sorgete
if exists (select * from treasurercashtotal where idtreasurer = @idtreasurerSource and ayear = @ayear)
Begin
	UPDATE treasurercashtotal SET currentfloatfund = isnull(currentfloatfund,0) - @amount WHERE idtreasurer = @idtreasurerSource and ayear = @ayear
End
else
Begin
	SET @amountNeg = - @amount
	INSERT INTO treasurercashtotal(idtreasurer, ayear, currentfloatfund)
	VALUES(@idtreasurerSource, @ayear, @amountNeg)
End



-- Cassiere destinatario
if exists (select * from treasurercashtotal where idtreasurer = @idtreasurerDest and ayear = @ayear)
Begin
	UPDATE treasurercashtotal SET currentfloatfund = isnull(currentfloatfund,0) + @amount WHERE idtreasurer = @idtreasurerDest and ayear = @ayear
End
else
Begin
	INSERT INTO treasurercashtotal(idtreasurer, ayear, currentfloatfund)
	VALUES(@idtreasurerDest, @ayear, @amount)
End








END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


