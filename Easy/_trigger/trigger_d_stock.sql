
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_stock]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_stock]
GO

CREATE TRIGGER [trigger_d_stock] ON [stock] FOR DELETE
AS BEGIN

DECLARE @oldidstore int
DECLARE @oldidlist int
DECLARE @oldnumber 	decimal (19,2)

SELECT  @oldidstore = idstore, @oldidlist = idlist, @oldnumber = number FROM deleted

-- Gestione Scarico = oldnumber
DECLARE @valoredaSottarre decimal(19,2) 

DECLARE @oldallocated int
SET @oldallocated =  (SELECT sum(allocated) from booktotal where idstore = @oldidstore and idlist = @oldidlist )

DECLARE @OldNumStockTotal int
SET @OldNumStockTotal = (SELECT number from stocktotal where idstore = @oldidstore and idlist = @oldidlist ) 

DECLARE @CurrNumStockTotal int
SET @CurrNumStockTotal = @OldNumStockTotal - @oldnumber

if ( @OldNumStockTotal <= @oldallocated )
	Begin
		SET @valoredaSottarre = - @oldnumber
	End
ELSE 
	Begin
		SET @valoredaSottarre = @oldallocated - @CurrNumStockTotal
		SET @valoredaSottarre = - @valoredaSottarre
		if (@valoredaSottarre >0 ) set @valoredaSottarre=0

	End



UPDATE stocktotal SET number = number - @oldnumber WHERE idstore = @oldidstore and idlist = @oldidlist

EXEC trg_upd_booktotal_allocated @oldidstore, @oldidlist, @valoredaSottarre 



END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

