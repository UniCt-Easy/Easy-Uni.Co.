
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_stock]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_stock]
GO

CREATE TRIGGER [trigger_u_stock] ON [stock] FOR UPDATE
AS BEGIN

DECLARE @oldidstore int
DECLARE @oldidlist int
DECLARE @oldnumber 	decimal (19,2)

DECLARE @newidstore int
DECLARE @newidlist int
DECLARE @newnumber 	decimal (19,2)

SELECT  @oldidstore = idstore, @oldidlist = idlist, @oldnumber = number FROM deleted
SELECT  @newidstore = idstore, @newidlist = idlist, @newnumber = number FROM inserted

-- Gestione Scarico = oldnumber
DECLARE @valoredaSottarre decimal(19,2) 

DECLARE @oldbooked int
SET @oldbooked =  (SELECT booked from stocktotal where idstore = @oldidstore and idlist = @oldidlist )

DECLARE @OldNumStockTotal int
SET @OldNumStockTotal = (SELECT number from stocktotal where idstore = @oldidstore and idlist = @oldidlist ) 

DECLARE @CurrNumStockTotal int  -->  Nuova giacenza del vecchio magazzino
SET @CurrNumStockTotal = @OldNumStockTotal - @oldnumber 

-- Se la giacenza è inferiore alle prenotazioni, vuol dire che le prenotazioni non sono state tutte assegnate.
-- Se invece, la giacenza è superiore alle prenotazioni, vuol dire che avevo già assegnato la merce a tutte le prenotazioni.

if ( @OldNumStockTotal <= @oldbooked )
	Begin
		SET @valoredaSottarre = - @oldnumber
	End
ELSE 
	Begin
		SET @valoredaSottarre = @oldbooked - @CurrNumStockTotal
		SET @valoredaSottarre = - @valoredaSottarre
		if (@valoredaSottarre >0 ) set @valoredaSottarre=0

	End



-- Gestione Carico = newnumber
DECLARE @valoredaSommare decimal(19,2) 

DECLARE @booked int
SET @booked = (SELECT booked from stocktotal where idstore = @newidstore and idlist = @newidlist )

DECLARE @OldNumStockTotal_newpart int
SET @OldNumStockTotal_newpart = (SELECT number from stocktotal where idstore = @newidstore and idlist = @newidlist )

IF ( @newidstore = @oldidstore  and  @newidlist = @oldidlist )-- new
Begin
	SET @OldNumStockTotal_newpart = @OldNumStockTotal_newpart - @oldnumber -- va decurtato di @oldnumber se idstore = @newidstore and idlist = @newidlist 
End

DECLARE @CurrNumStockTotalNew int --> Nuova giacenza del Nuovo magazzino
SET @CurrNumStockTotalNew = @OldNumStockTotal_newpart + @newnumber

-- Se con questo carico NON riesco ad assegnate la merce a tutte le prenotazioni esistenti, perchè
-- le prenotazioni sono superiori al valore caricato, allora sommerò semplicemente @newnumber
-- altrimenti devo assegnare : q.tà prenotazioni - la vecchia q.tà caricata,
-- cioè depuro la q.tà da assegnare alle prenotazioni, della q.tà che ho già assegnato prima, quando è nato il carico.

if ( @CurrNumStockTotalNew <= @booked )
	Begin
		SET @valoredaSommare = @newnumber
	End
ELSE
	Begin
 		SET @valoredaSommare =  @booked - @OldNumStockTotal_newpart
		if (@valoredaSommare<0) set @valoredaSommare=0
	End



IF ( @newidstore = @oldidstore  and  @newidlist = @oldidlist )
	Begin
		UPDATE stocktotal SET number = number + @newnumber - @oldnumber
		WHERE idstore = @newidstore and idlist = @newidlist

		SET @valoredaSommare = @valoredaSommare + @valoredaSottarre --> è già negativo 
		EXEC trg_upd_booktotal_allocated @newidstore, @newidlist, @valoredaSommare
	End
ELSE
	Begin
		UPDATE stocktotal SET number = number - @oldnumber WHERE idstore = @oldidstore and idlist = @oldidlist
		UPDATE stocktotal SET number = number + @newnumber WHERE idstore = @newidstore and idlist = @newidlist

		EXEC trg_upd_booktotal_allocated @oldidstore, @oldidlist, @valoredaSottarre 
		EXEC trg_upd_booktotal_allocated @newidstore, @newidlist, @valoredaSommare
	End




END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

