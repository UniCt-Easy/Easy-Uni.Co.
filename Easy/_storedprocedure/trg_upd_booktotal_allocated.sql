
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_booktotal_allocated]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_booktotal_allocated]
GO

CREATE PROCEDURE [trg_upd_booktotal_allocated](
	@idstore int,
	@idlist int,
	@value decimal(19,2)
)
AS BEGIN

DECLARE @residuo decimal (19,2)

DECLARE @idbooking int 
DECLARE @allocated decimal (19,2)
DECLARE @number decimal (19,2)

IF (@value < 0)
Begin
-- SCARICO : devo diminuire
	SET @residuo =  - @value 	
	WHILE @residuo > 0 
	BEGIN
		
		IF (SELECT COUNT(idbooking) FROM booktotal WHERE idstore= @idstore AND idlist = @idlist and (allocated>0)) = 0
		BREAK
		
		SET @idbooking = ( SELECT TOP 1 idbooking FROM booktotal WHERE idstore= @idstore AND idlist = @idlist and (allocated>0) ORDER BY idbooking DESC )
		SELECT @allocated = allocated FROM booktotal WHERE idbooking = @idbooking AND idstore = @idstore AND idlist = @idlist 	

		IF (@allocated > = @residuo)
		Begin
			-- vuol dire che tutto l'importo va sotratto a questa prenotazione 
			UPDATE booktotal SET allocated = @allocated - @residuo WHERE idbooking = @idbooking AND idstore = @idstore AND idlist = @idlist
			SET @residuo = 0
		End
		ELSE
		Begin
			-- @allocated < @residuo
			UPDATE booktotal SET allocated = 0 WHERE idbooking = @idbooking AND idstore = @idstore AND idlist = @idlist
			SET @residuo = @residuo - @allocated
		End
	END
End

Else

Begin
-- CARICO : devo aumentare
	SET @residuo =  @value	
	WHILE @residuo > 0 
	BEGIN
		IF (SELECT COUNT(idbooking) FROM booktotal WHERE idstore= @idstore AND idlist = @idlist AND number > allocated) = 0
		BREAK
	
		SET @idbooking = ( SELECT TOP 1 idbooking FROM booktotal WHERE idstore= @idstore AND idlist = @idlist AND number > allocated ORDER BY idbooking ASC )
		SELECT @allocated = allocated, @number = number FROM booktotal WHERE idbooking = @idbooking AND idstore = @idstore AND idlist = @idlist 	

		IF ((@allocated + @residuo) >= @number )
			Begin
				UPDATE booktotal SET allocated = @number WHERE idbooking = @idbooking AND idstore = @idstore AND idlist = @idlist
				SET @residuo = @residuo - (@number - @allocated)
			End
		ELSE
			Begin
				UPDATE booktotal SET allocated = @allocated + @residuo WHERE idbooking = @idbooking AND idstore = @idstore AND idlist = @idlist
				SET @residuo = 0
			End
	END

End

-- number = quanto rimane da ricevere 
-- allocated = quanto è disponibile in magazzino

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

