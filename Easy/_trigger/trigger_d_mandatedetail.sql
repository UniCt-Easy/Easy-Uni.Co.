
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


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[trigger_d_mandatedetail]'))
DROP TRIGGER [trigger_d_mandatedetail]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [trigger_d_mandatedetail] ON [mandatedetail] FOR DELETE
AS BEGIN

DECLARE @idstore int
DECLARE @oldidlist int
DECLARE @oldnumber 	decimal (19,2)

DECLARE @oldyman int
DECLARE @oldnman int
DECLARE @oldidmankind varchar(20)
DECLARE @oldrownum int
DECLARE @oldidgroup int

SELECT  @oldidmankind = idmankind, @oldyman = yman , @oldnman = nman, 
		@oldrownum = rownum, @oldidgroup = idgroup   FROM deleted
SELECT  @idstore = idstore FROM mandate WHERE  @oldidmankind = idmankind and @oldyman = yman and @oldnman = nman

SELECT  @oldidlist = idlist, @oldnumber = number FROM deleted

IF (SELECT COUNT( @oldrownum) FROM mandatedetail  
	WHERE  @oldidmankind = idmankind and @oldyman = yman and @oldnman = nman and @oldidgroup = idgroup) = 0
BEGIN 
	UPDATE stocktotal SET ordered = ordered - @oldnumber WHERE idstore = @idstore and idlist = @oldidlist
END

END
