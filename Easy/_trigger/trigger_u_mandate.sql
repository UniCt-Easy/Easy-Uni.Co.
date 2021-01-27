
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_mandate]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_mandate]
GO

CREATE TRIGGER [trigger_u_mandate] ON [mandate] FOR UPDATE
AS BEGIN

DECLARE @idstoreOld int
DECLARE @idstoreNew int

DECLARE @yman int
DECLARE @nman int
DECLARE @idmankind varchar(20)

SELECT   @idmankind = idmankind, @yman = yman , @nman = nman, @idstoreOld = idstore  FROM deleted

SELECT  @idstoreNew = idstore  FROM inserted

IF (@idstoreOld <>@idstoreNew)
Begin

			DECLARE @idlist		int
			DECLARE @number 	decimal (19,2)
			DECLARE @rownum int
			DECLARE @idgroup int
	
			DECLARE @cursore cursor
			SET @cursore = CURSOR FOR
			SELECT DISTINCT idgroup FROM mandatedetail 
			WHERE  @idmankind = idmankind and @yman = yman and @nman = nman

			OPEN @cursore
			FETCH NEXT FROM @cursore INTO @idgroup
			WHILE (@@FETCH_STATUS = 0)
			BEGIN

				SET @rownum = (SELECT TOP 1 rownum FROM mandatedetail  
								WHERE  @idmankind = idmankind and @yman = yman and @nman = nman and @idgroup = idgroup)

				SELECT @idlist = idlist,  @number = number
					FROM mandatedetail 
					WHERE  @idmankind = idmankind and @yman = yman and @nman = nman and @rownum = rownum

				-- Lavora sul vecchio idstore
				UPDATE stocktotal SET ordered = ordered - @number WHERE idstore = @idstoreOld and idlist = @idlist

				-- Lavora sul nuovo idstore
				if exists (select * from stocktotal where idstore = @idstoreNew and idlist = @idlist)
				Begin
					UPDATE stocktotal SET ordered = ordered + @number WHERE idstore = @idstoreNew and idlist = @idlist
				End
				ELSE
				Begin
					INSERT INTO stocktotal	(idstore, idlist, number, ordered, booked)
					VALUES (@idstoreNew, @idlist, 0, @number, 0)
				End
	
		
       		FETCH NEXT FROM @cursore INTO @idgroup
			END

			CLOSE @cursore
			DEALLOCATE @cursore

End




END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
