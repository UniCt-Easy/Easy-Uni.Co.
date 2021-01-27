
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expensesorted]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expensesorted]
GO


CREATE TRIGGER [trigger_u_expensesorted] ON [expensesorted] FOR UPDATE
AS BEGIN
IF UPDATE(amount)
BEGIN
	DECLARE @newayear int
	DECLARE @oldayear int
	DECLARE @idexp int
	DECLARE @idsor int
	DECLARE @newamount decimal(19,2)
	DECLARE @oldamount decimal(19,2)

	SELECT 
		@idexp = idexp, 
		@idsor = idsor, 
		@newamount = amount,
		@newayear = ayear
	FROM inserted

	IF (@newayear IS NULL)
	BEGIN
		SELECT @newayear = ymov FROM expense WHERE idexp = @idexp
	END

	SELECT @oldamount = -amount,
	@oldayear = ayear
	FROM deleted

	IF (@oldayear IS NULL)
	BEGIN
		SELECT @oldayear = ymov FROM expense WHERE idexp = @idexp
	END

	EXECUTE trg_upd_sorttotal 
	@idsor, 
	@newayear, 
	'totexpense', 
	@newamount

	EXECUTE trg_upd_sorttotal 
	@idsor, 
	@oldayear, 
	'totexpense', 
	@oldamount
END
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

