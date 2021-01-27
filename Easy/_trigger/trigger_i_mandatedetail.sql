
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


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
