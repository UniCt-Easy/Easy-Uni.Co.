
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_expensepayroll]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_expensepayroll]
GO


CREATE         TRIGGER [trigger_d_expensepayroll] ON [expensepayroll] 
FOR DELETE 
AS BEGIN
	DECLARE @idpayroll int
	DECLARE @start datetime
	DECLARE @idcon varchar(8)
	DECLARE @fiscalyear int
	SELECT @idpayroll = idpayroll
	FROM deleted
	
	UPDATE payroll SET disbursementdate = NULL,
	lt = GETDATE(),
	lu = 'TRIGGER'
	WHERE idpayroll = @idpayroll
	
	SELECT 
	@start = start,
	@fiscalyear = fiscalyear,
	@idcon = idcon
	FROM payroll
	WHERE idpayroll = @idpayroll
	
	DECLARE @otherpayrolls int
	SELECT @otherpayrolls = COUNT(*) FROM payroll 
	WHERE idcon = @idcon
	AND fiscalyear = @fiscalyear
	AND start > @start
	AND flagbalance = 'N'
	
	IF (@otherpayrolls = 0)
	BEGIN
		DECLARE @idpayrollbalance int
		SELECT @idpayrollbalance = idpayroll FROM payroll
		WHERE idcon = @idcon
		AND fiscalyear = @fiscalyear
		AND flagbalance = 'S'

		UPDATE payroll SET disbursementdate = NULL,
		lt = GETDATE(),
		lu = 'TRIGGER'
		WHERE idpayroll = @idpayrollbalance

		UPDATE parasubcontractlist
		SET balanced = 'N'
		WHERE idcon = @idcon
			AND ayear = @fiscalyear
			AND iddbdepartment = USER
	END
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

