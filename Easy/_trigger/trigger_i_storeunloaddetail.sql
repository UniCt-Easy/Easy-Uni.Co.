SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_storeunloaddetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_storeunloaddetail]
GO

CREATE TRIGGER [trigger_i_storeunloaddetail] ON [storeunloaddetail] FOR INSERT
AS BEGIN

DECLARE @newnumber decimal (19,2)
DECLARE @newidbooking int
DECLARE @newidstock int
SELECT  @newnumber = number , @newidbooking = idbooking,  @newidstock = idstock FROM inserted


DECLARE @idstore int
DECLARE @idlist int
SELECT @idstore = idstore, @idlist = idlist FROM stock WHERE idstock = @newidstock


UPDATE stocktotal SET number = number - @newnumber WHERE idstore = @idstore and idlist = @idlist
-- se collegata alla prenotazione devo diminuire anche la q.tà prenotata
IF (@newidbooking is not null)
Begin
	UPDATE stocktotal SET booked = booked - @newnumber WHERE idstore = @idstore and idlist = @idlist  
End


UPDATE booktotal SET
					number	  = number - @newnumber, 
					allocated = allocated - @newnumber 
WHERE idstore = @idstore AND idlist = @idlist AND idbooking = @newidbooking

DELETE FROM booktotal WHERE number = 0 AND allocated =  0
		AND idstore = @idstore AND idlist = @idlist AND idbooking = @newidbooking


END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO