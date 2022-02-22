
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_moneytransfer]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_moneytransfer]
GO

CREATE TRIGGER [trigger_i_moneytransfer] ON [moneytransfer] FOR INSERT
AS BEGIN 

DECLARE @idtreasurerSource int
DECLARE @idtreasurerDest int
DECLARE @amount decimal(19,2)
DECLARE @amountNeg decimal(19,2)
DECLARE @ayear int

SELECT	@idtreasurerSource = idtreasurersource,
		@idtreasurerDest	= idtreasurerdest,
		@amount = amount,
		@ayear = ytransfer
FROM inserted


-- Cassiere di Sorgete
if exists (select * from treasurercashtotal where idtreasurer = @idtreasurerSource and ayear = @ayear)
Begin
	UPDATE treasurercashtotal SET currentfloatfund = isnull(currentfloatfund,0) - @amount WHERE idtreasurer = @idtreasurerSource and ayear = @ayear
End
else
Begin
	SET @amountNeg = - @amount
	INSERT INTO treasurercashtotal(idtreasurer, ayear, currentfloatfund)
	VALUES(@idtreasurerSource, @ayear, @amountNeg)
End



-- Cassiere destinatario
if exists (select * from treasurercashtotal where idtreasurer = @idtreasurerDest and ayear = @ayear)
Begin
	UPDATE treasurercashtotal SET currentfloatfund = isnull(currentfloatfund,0) + @amount WHERE idtreasurer = @idtreasurerDest and ayear = @ayear
End
else
Begin
	INSERT INTO treasurercashtotal(idtreasurer, ayear, currentfloatfund)
	VALUES(@idtreasurerDest, @ayear, @amount)
End








END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


