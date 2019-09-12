SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_treasurerstart]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_treasurerstart]
GO

CREATE TRIGGER [trigger_i_treasurerstart] ON [treasurerstart] FOR INSERT
AS BEGIN 

DECLARE @idtreasurer int
DECLARE @amount decimal(19,2)
DECLARE @ayear int

SELECT	@idtreasurer = idtreasurer,
		@amount = amount,
		@ayear = ayear
FROM inserted


if exists (select * from treasurercashtotal where idtreasurer = @idtreasurer and ayear = @ayear)
Begin
	UPDATE treasurercashtotal SET currentfloatfund = isnull(currentfloatfund,0) + @amount WHERE idtreasurer = @idtreasurer and ayear = @ayear
End
else
Begin
	INSERT INTO treasurercashtotal(idtreasurer, ayear, currentfloatfund)
	VALUES(@idtreasurer, @ayear, @amount)
End








END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


