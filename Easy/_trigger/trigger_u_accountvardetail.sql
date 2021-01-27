
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_accountvardetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_accountvardetail]
GO

CREATE     TRIGGER [trigger_u_accountvardetail] ON [accountvardetail] FOR UPDATE
AS BEGIN
	DECLARE @yvar int
	DECLARE @nvar int
	DECLARE @idacc varchar(38)
	DECLARE @idupb varchar(36)
	DECLARE @newamount decimal(19,2)
	DECLARE @newamount2 decimal(19,2)
	DECLARE @newamount3 decimal(19,2)
	DECLARE @newamount4 decimal(19,2)
	DECLARE @newamount5 decimal(19,2)

	DECLARE @variationkind tinyint

	SELECT 
		@yvar = yvar,
		@nvar = nvar,
		@idacc = idacc, 
		@idupb = idupb,
		@newamount = isnull(amount,0),
		@newamount2 = isnull(amount2,0),
		@newamount3 =isnull(amount3,0),
		@newamount4 = isnull(amount4,0),
		@newamount5 = isnull(amount5,0)
	FROM inserted
	
	DECLARE @oldamount decimal(19,2)
	DECLARE @oldamount2 decimal(19,2)
	DECLARE @oldamount3 decimal(19,2)
	DECLARE @oldamount4 decimal(19,2)
	DECLARE @oldamount5 decimal(19,2)

	SELECT @oldamount = -isnull(amount,0),
		   @oldamount2 = -isnull(amount2,0),
		   @oldamount3 = -isnull(amount3,0),
		   @oldamount4 = -isnull(amount4,0),
		   @oldamount5 = -isnull(amount5,0)
	FROM deleted

	DECLARE @flagprevision char(1)
	set @flagprevision='S'

	DECLARE @idaccountvarstatus smallint


	SELECT
		@idaccountvarstatus = ISNULL(idaccountvarstatus,0),
		@variationkind = ISNULL(variationkind,0)
	FROM accountvar
	WHERE yvar = @yvar AND nvar = @nvar

	

	if (@idaccountvarstatus<>5) BEGIN
		SET @flagprevision='N'
	END

	DECLARE @differenceamount decimal(19,2)
	DECLARE @differenceamount2 decimal(19,2)
	DECLARE @differenceamount3 decimal(19,2)
	DECLARE @differenceamount4 decimal(19,2)
	DECLARE @differenceamount5 decimal(19,2)
	
	SET @differenceamount = @oldamount + @newamount	
	SET @differenceamount2 = @oldamount2 + @newamount2	
	SET @differenceamount3 = @oldamount3 + @newamount3	
	SET @differenceamount4 = @oldamount4 + @newamount4	
	SET @differenceamount5 = @oldamount5 + @newamount5	



	IF (@flagprevision = 'S') AND (@variationkind <>5)
	BEGIN
		if (@differenceamount<>0) EXECUTE trg_upd_upbaccounttotal @idacc, @idupb,'previsionvariation', @differenceamount
		if (@differenceamount2<>0) EXECUTE trg_upd_upbaccounttotal @idacc, @idupb,'previsionvariation2', @differenceamount2
		if (@differenceamount3<>0) EXECUTE trg_upd_upbaccounttotal @idacc, @idupb,'previsionvariation3', @differenceamount3
		if (@differenceamount4<>0) EXECUTE trg_upd_upbaccounttotal @idacc, @idupb,'previsionvariation4', @differenceamount4
		if (@differenceamount5<>0) EXECUTE trg_upd_upbaccounttotal @idacc, @idupb,'previsionvariation5', @differenceamount5
			
	END
	
	
	

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

