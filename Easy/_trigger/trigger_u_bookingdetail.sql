
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_bookingdetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_bookingdetail]
GO

CREATE TRIGGER [trigger_u_bookingdetail] ON [bookingdetail] FOR UPDATE
AS BEGIN

DECLARE @oldnumber decimal (19,2)
DECLARE @oldauthorized char(1)

DECLARE @newnumber decimal (19,2)
DECLARE @newidbooking int

DECLARE @newidlist int
DECLARE @newidstore int
DECLARE @newauthorized char(1)
DECLARE @idlcard int
DECLARE @oldprice decimal(19,2)
DECLARE @newprice decimal(19,2)



SELECT @oldnumber = number,
	   @oldprice = price,
	   @oldauthorized = authorized	FROM deleted

SELECT  @newidbooking = idbooking, 
		@newnumber = number , 
		@newidlist = idlist, 
		@newidstore = idstore,
		@newprice = price,
		@newauthorized = authorized  FROM inserted


SELECT @idlcard = idlcard 
		from booking
	where idbooking= @newidbooking

DECLARE @valoredaSottrarre decimal(19,2) 

IF( isnull(@oldauthorized, 'N') <> 'S' ) 
Begin
	SET @valoredaSottrarre = 0
End
ELSE
Begin
	SET  @valoredaSottrarre = @oldnumber
End


DECLARE @valoredaSommare decimal(19,2) 

IF ( isnull(@newauthorized, 'N') <> 'S' ) 
Begin
	SET @valoredaSommare = 0
End
ELSE
Begin
	SET @valoredaSommare = @newnumber
End


IF not exists( select * from stocktotal where idstore = @newidstore AND idlist = @newidlist)
Begin
	INSERT INTO stocktotal
		(idstore, idlist, number, ordered, booked)
	VALUES (@newidstore, @newidlist, 0, 0, 0)
End


DECLARE @unallocated decimal(19,2)
select  @unallocated= number-booked from stocktotal WHERE idstore = @newidstore AND idlist = @newidlist
if @unallocated<0 set @unallocated=0


UPDATE stocktotal SET booked = booked + @valoredaSommare - @valoredaSottrarre WHERE idstore = @newidstore AND idlist = @newidlist


declare @toallocate decimal(19,2)
declare @todeallocate decimal(19,2)
declare @book_allocated decimal(19,2)

if @valoredaSommare>@valoredaSottrarre 
BEGIN
  set @todeallocate=0
  if  (@valoredaSommare-@valoredaSottrarre>@unallocated)
     set @toallocate= @unallocated
  else
     set @toallocate= @valoredaSommare-@valoredaSottrarre

END
ELSE
BEGIN 
  set  @toallocate=0

  SET @book_allocated = ISNULL( (SELECT allocated from booktotal where idbooking = @newidbooking AND idlist = @newidlist),0)
  if (@valoredaSottrarre - @valoredaSommare > @book_allocated) 
		set  @todeallocate = @book_allocated
  else
		set  @todeallocate = @valoredaSottrarre - @valoredaSommare

END


if not exists (select * from booktotal where idbooking = @newidbooking and idlist = @newidlist and idstore = @newidstore )
Begin
	INSERT INTO booktotal 
			(idbooking, idlist, idstore,number,allocated)
	VALUES (@newidbooking, @newidlist, @newidstore, 0, 0 )
end


UPDATE booktotal SET number = number + @valoredaSommare - @valoredaSottarre,
				allocated=allocated+@toallocate
			 WHERE idbooking = @newidbooking AND idlist = @newidlist

if (@todeallocate > 0)
BEGIN
	UPDATE booktotal SET allocated = allocated - @todeallocate WHERE idbooking = @newidbooking AND idlist = @newidlist 
	EXEC trg_upd_booktotal_allocated @newidstore, @newidlist, @todeallocate

END 


if @idlcard is not null
begin
	update lcardtotal set amount= isnull(amount,0)
			-round(@newprice*@valoredaSommare,2)
			+round(@oldprice*@valoredaSottarre,2) 
			where idlcard=@idlcard
end



END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




