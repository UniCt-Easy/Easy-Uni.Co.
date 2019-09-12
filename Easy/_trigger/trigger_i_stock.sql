SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_stock]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_stock]
GO

CREATE TRIGGER [trigger_i_stock] ON [stock] FOR INSERT
AS BEGIN

DECLARE @newidstore int
DECLARE @newidlist int
DECLARE @newnumber decimal (19,2)

SELECT  @newidstore = idstore, @newidlist = idlist, @newnumber = number FROM inserted


-- Gestione Carico = newnumber
DECLARE @valoredaSommare decimal(19,2) 

DECLARE @booked int
SET @booked = (SELECT booked from stocktotal where idstore = @newidstore and idlist = @newidlist )

DECLARE @OldNumStockTotal int
SET @OldNumStockTotal = ISNULL((SELECT number from stocktotal where idstore = @newidstore and idlist = @newidlist ),0)

DECLARE @CurrNumSockTotal int
SET @CurrNumSockTotal = @OldNumStockTotal + @newnumber

if (  @CurrNumSockTotal <= @booked )
	Begin
		SET @valoredaSommare = @newnumber
	End
ELSE
	Begin
 		SET @valoredaSommare =  @booked - @OldNumStockTotal
		if (@valoredaSommare<0) set @valoredaSommare=0

	End


if exists (select * from stocktotal where idstore = @newidstore and idlist = @newidlist)
Begin
	UPDATE stocktotal SET number = number + @newnumber WHERE idstore = @newidstore and idlist = @newidlist
End
else
Begin
	INSERT INTO stocktotal(idstore, idlist, number, ordered, booked)
	VALUES(@newidstore, @newidlist, @newnumber, 0, 0)
End


EXEC trg_upd_booktotal_allocated @newidstore, @newidlist, @valoredaSommare






END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


