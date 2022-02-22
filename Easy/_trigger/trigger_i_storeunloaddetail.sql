
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
