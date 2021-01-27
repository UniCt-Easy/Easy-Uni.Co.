
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_moneytransfer]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_moneytransfer]
GO

CREATE TRIGGER [trigger_u_moneytransfer] ON [moneytransfer] FOR UPDATE
AS BEGIN

DECLARE @idtreasurerSource int
DECLARE @idtreasurerDest int
DECLARE @oldamount decimal(19,2)
DECLARE @newamount decimal(19,2)
DECLARE @ayear int

SELECT  @oldamount = amount FROM deleted

SELECT  @idtreasurerSource = idtreasurersource, 
		@idtreasurerDest = idtreasurerdest, 
		@newamount = amount, 
		@ayear = ytransfer FROM inserted

DECLARE @amountDiff decimal(19,2)
SET @amountDiff = @newamount - @oldamount

-- Al momento è possibile modificare SOLO l'importo
IF ( @newamount<>@oldamount  )
	Begin
		UPDATE treasurercashtotal SET currentfloatfund = isnull(currentfloatfund,0) - @amountDiff
		WHERE idtreasurer = @idtreasurerSource and ayear = @ayear

		UPDATE treasurercashtotal SET currentfloatfund = isnull(currentfloatfund,0) + @amountDiff
		WHERE idtreasurer = @idtreasurerDest and ayear = @ayear

	End


END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

