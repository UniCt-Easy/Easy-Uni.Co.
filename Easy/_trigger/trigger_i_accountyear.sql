
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_accountyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_accountyear]
GO

CREATE    TRIGGER [trigger_i_accountyear] ON [accountyear] FOR INSERT
AS BEGIN
IF @@ROWCOUNT > 0
BEGIN
	DECLARE @ayear int
	DECLARE	@idacc varchar(38)
	DECLARE @idupb varchar(36)
	DECLARE	@prevision decimal(19, 2)
	DECLARE	@prevision2 decimal(19, 2)
	DECLARE	@prevision3 decimal(19, 2)
	DECLARE	@prevision4 decimal(19, 2)
	DECLARE	@prevision5 decimal(19, 2)
	DECLARE	@cu varchar(64)
	DECLARE	@ct datetime
	DECLARE	@lu varchar(64)
	DECLARE	@lt datetime

	SELECT	@idacc=idacc, @ayear=ayear, @idupb=idupb,
		@prevision=prevision, @prevision2=prevision2, @prevision3=prevision3, @prevision4=prevision4, @prevision5=prevision5, 
		@cu=cu, @ct=ct, @lu=lu, @lt=lt
	FROM inserted

	DECLARE @nlevel tinyint
	SELECT @nlevel = nlevel FROM account WHERE idacc = @idacc

	DECLARE @minoplevel tinyint
	SELECT @minoplevel = MIN(nlevel) FROM accountlevel WHERE flagusable='S' AND ayear = @ayear

	-- Se sto inserendo un capitolo devo propagare la modifica fino al primo livello
	-- altrimenti inserisco in upbaccounttotal solo la voce di bilancio appena inserita
	IF (@nlevel <= @minoplevel) 
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
			UPDATE upbaccounttotal SET currentprev = @prevision, 
					currentprev2 = @prevision2, 
					currentprev3 = @prevision3, 
					currentprev4 = @prevision4, 
					currentprev5 = @prevision5 
			WHERE idacc = @idacc AND idupb = @idupb
		END
	END

-- Inserimento righe in accountyear a zero sugli UPB padre di quello che sto inserendo nel caso in cui
-- tale voce non esiste

	IF (LEN(@idupb) > 4)
	BEGIN
		DECLARE @curridupb varchar(36)
		SET @curridupb = SUBSTRING(@idupb,1,LEN(@idupb)-4)
		IF NOT EXISTS(SELECT * FROM accountyear WHERE idupb = @curridupb AND idacc = @idacc)
		BEGIN
			INSERT INTO accountyear
			(
				idacc, idupb,
				prevision, prevision2,prevision3,prevision4,prevision5,
				ct, cu, lt, lu,
				ayear
			)
			VALUES
			(
				@idacc, @curridupb,
				0, 0,0, 0,0, 
				GETDATE(), 'TRIGGER', GETDATE(), '''TRIGGER''',
				@ayear
			)
		END
	END
END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

