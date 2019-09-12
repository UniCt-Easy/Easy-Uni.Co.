IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[trigger_u_mandatedetail]'))
DROP TRIGGER [trigger_u_mandatedetail]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [trigger_u_mandatedetail] ON [mandatedetail] FOR UPDATE
AS BEGIN

DECLARE @idstore int

DECLARE @oldidlist int
DECLARE @oldnumber 	decimal (19,2)

DECLARE @newidlist int
DECLARE @newnumber 	decimal (19,2)

DECLARE @yman int
DECLARE @nman int
DECLARE @idmankind varchar(20)
DECLARE @rownum int
DECLARE @idgroup int

SELECT  @idmankind = idmankind, @yman = yman , @nman = nman, @rownum = rownum, @idgroup = idgroup  FROM inserted
SELECT  @idstore = idstore FROM mandate WHERE  @idmankind = idmankind and @yman = yman and @nman = nman

SELECT  @oldidlist = idlist, @oldnumber = number FROM deleted

SELECT  @newidlist = idlist, @newnumber = number FROM inserted


IF (@rownum = (SELECT MIN(ISNULL(rownum, @rownum)) FROM mandatedetail  
			   WHERE  @idmankind = idmankind and @yman = yman and @nman = nman and @idgroup = idgroup))
BEGIN
	IF (@newidlist = @oldidlist)
		BEGIN
			UPDATE stocktotal SET ordered = ordered + @newnumber - @oldnumber WHERE idstore = @idstore and idlist = @newidlist
		END
	ELSE
		BEGIN
			UPDATE stocktotal SET ordered = ordered - @oldnumber WHERE idstore = @idstore and idlist = @oldidlist
			UPDATE stocktotal SET ordered = ordered + @newnumber WHERE idstore = @idstore and idlist = @newidlist
		END
END


END
