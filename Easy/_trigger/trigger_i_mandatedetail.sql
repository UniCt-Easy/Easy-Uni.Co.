IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[trigger_i_mandatedetail]'))
DROP TRIGGER [trigger_i_mandatedetail]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [trigger_i_mandatedetail] ON [mandatedetail] FOR INSERT
AS BEGIN

DECLARE @newnumber decimal (19,2)
DECLARE @newidlist int
DECLARE @idstore int
DECLARE @newyman int
DECLARE @newnman int
DECLARE @newidmankind varchar(20)
DECLARE @newrownum int
DECLARE @newidgroup int


SELECT  @newidmankind = idmankind, @newyman = yman , 
		@newnman = nman, @newrownum = rownum, @newidgroup = idgroup  FROM inserted 

SELECT  @idstore = idstore FROM mandate WHERE  @newidmankind = idmankind and @newyman = yman and @newnman = nman

SELECT  @newnumber = number , @newidlist = idlist  FROM inserted

IF ((@newidlist IS NULL) OR ( @idstore IS NULL))	RETURN

IF   (@newrownum <> 
	 (SELECT MIN(ISNULL(rownum, @newrownum)) FROM mandatedetail  
	   WHERE @newidmankind = idmankind and @newyman = yman and 
		     @newnman = nman and @newidgroup = idgroup))
RETURN

IF exists( select * from stocktotal where idstore = @idstore AND idlist = @newidlist) 
Begin
	UPDATE stocktotal SET ordered = ordered + @newnumber WHERE idstore = @idstore AND idlist = @newidlist
End
Else
Begin
	INSERT INTO stocktotal
		(idstore, idlist, number, ordered, booked)
	VALUES (@idstore, @newidlist, 0, @newnumber, 0)
End

END
