
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
