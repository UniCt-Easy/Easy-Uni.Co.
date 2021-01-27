
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_accountyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_accountyear]
GO

CREATE    TRIGGER [trigger_u_accountyear] ON [accountyear] FOR UPDATE
AS BEGIN

	DECLARE @ayear int
	DECLARE @idacc varchar(38)
	DECLARE @idupb varchar(36)
	SELECT @ayear = ayear, @idacc = idacc, @idupb = idupb FROM inserted

	DECLARE @newamount decimal(19,2)
	DECLARE @oldamount decimal(19,2)


	DECLARE	@prevision decimal(19,2)
	DECLARE	@prevision2 decimal(19,2)
	DECLARE	@prevision3 decimal(19,2)
	DECLARE	@prevision4 decimal(19,2)
	DECLARE	@prevision5 decimal(19,2)

	
	SELECT
		@prevision = -ISNULL(prevision,0),
		@prevision2 = -ISNULL(prevision2,0),
		@prevision3 = -ISNULL(prevision3,0),
		@prevision4 = -ISNULL(prevision4,0),
		@prevision5 = -ISNULL(prevision5,0)
	FROM deleted

	SELECT
		@prevision = @prevision + ISNULL(prevision,0), 
		@prevision2 = @prevision2 + ISNULL(prevision2,0), 
		@prevision3 = @prevision3 + ISNULL(prevision3,0), 
		@prevision4 = @prevision4 + ISNULL(prevision4,0), 
		@prevision5 = @prevision5 + ISNULL(prevision5,0)
	FROM inserted

	-- Se mi trovo sul Capitolo devo propagare la modifica fino al primo livello
	-- altrimenti devo modificare solamente il livello modificato
	DECLARE @nlevel tinyint
	SELECT @nlevel = nlevel FROM account WHERE idacc = @idacc

	DECLARE @minlevelop tinyint
	SELECT @minlevelop = MIN(nlevel) FROM accountlevel WHERE (flagusable='S') AND ayear = @ayear
	IF (@nlevel = @minlevelop) 
	BEGIN
		EXEC trg_upd_upbaccountextended @idacc,@idupb,@prevision,@prevision2,@prevision3,@prevision4,@prevision5
	END
	ELSE
	BEGIN
		IF NOT EXISTS(SELECT * FROM upbaccounttotal WHERE idacc = @idacc AND idupb = @idupb)
		BEGIN
			INSERT INTO upbaccounttotal
			(
				idupb,
				idacc,
				currentprev,
				currentprev2,
				currentprev3,
				currentprev4,
				currentprev5
			)
			VALUES
			(
				@idupb,
				@idacc,
				@prevision,
				@prevision2,
				@prevision3,
				@prevision4,
				@prevision5
			)
		END
		ELSE
		BEGIN
			UPDATE upbaccounttotal SET
			currentprev = @prevision + ISNULL(currentprev,0), 
			currentprev2 = @prevision2 + ISNULL(currentprev2,0), 
			currentprev3 = @prevision3 + ISNULL(currentprev3,0), 
			currentprev4 = @prevision4 + ISNULL(currentprev4,0), 
			currentprev5 = @prevision5 + ISNULL(currentprev5,0) 
			WHERE idacc = @idacc AND idupb = @idupb
		END
	END

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

