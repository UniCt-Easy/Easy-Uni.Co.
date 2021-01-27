
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_accountvardetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_accountvardetail]
GO

CREATE    TRIGGER [trigger_i_accountvardetail] ON [accountvardetail] FOR INSERT
AS BEGIN
	DECLARE @yvar int
	DECLARE @nvar int
	DECLARE @idupb varchar(36)
	DECLARE @idacc varchar(38)
	DECLARE @amount decimal(19,2)
	DECLARE @amount2 decimal(19,2)
	DECLARE @amount3 decimal(19,2)
	DECLARE @amount4 decimal(19,2)
	DECLARE @amount5 decimal(19,2)

	SELECT 
	@yvar = yvar,
	@nvar = nvar,
	@idacc = idacc, 
	@idupb = idupb,
		@amount = isnull(amount,0),
		@amount2 =  isnull(amount2,0),
		@amount3 =  isnull(amount3,0),
		@amount4 =  isnull(amount4,0),
		@amount5 =  isnull(amount5,0)
	FROM inserted
	

	DECLARE @flagprevision char(1)
	DECLARE @variationkind tinyint
	DECLARE @idaccountvarstatus smallint
	set @flagprevision='S'

	SELECT
		@idaccountvarstatus = ISNULL(idaccountvarstatus,0),
		@variationkind = ISNULL(variationkind,0)
	FROM accountvar
	WHERE yvar = @yvar
		AND nvar = @nvar

	if (@idaccountvarstatus<>5) BEGIN
		SET @flagprevision='N'
	END

	IF (@variationkind <>5 and @flagprevision='S')
	BEGIN
			if (isnull(@amount,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idacc ,	@idupb, 'previsionvariation',	@amount
			if (isnull(@amount2,0)<>0) EXEC trg_upd_upbaccounttotal 	@idacc ,	@idupb, 'previsionvariation2',@amount2
			if (isnull(@amount3,0)<>0) EXEC trg_upd_upbaccounttotal 	@idacc ,	@idupb, 'previsionvariation3',@amount3
			if (isnull(@amount4,0)<>0) EXEC trg_upd_upbaccounttotal 	@idacc ,	@idupb, 'previsionvariation4',@amount4
			if (isnull(@amount5,0)<>0) EXEC trg_upd_upbaccounttotal 	@idacc ,	@idupb, 'previsionvariation5',@amount5
	END

	
	-- Se non esiste la previsione della coppia (UPB,BILANCIO) in fase di creazione della var.
	-- si aggiunge la riga in ACCOUNTYEAR
	DECLARE @accountlevel int
	SET @accountlevel = (LEN(@idacc) - 2) / 4
	DECLARE @minusablelevelstr char(1)
	SELECT @minusablelevelstr = MIN(nlevel) FROM accountlevel WHERE ayear = @yvar AND flagusable = 'S'
	DECLARE @minusablelevel int
	SET @minusablelevel = CONVERT(int,@minusablelevelstr)
	WHILE(@accountlevel >= @minusablelevel)
	BEGIN
		IF NOT EXISTS(SELECT * FROM accountyear WHERE idacc = @idacc AND idupb = @idupb)
		BEGIN
			INSERT INTO accountyear
			(
				idacc,
				idupb,
				ct,
				cu,
				lt,
				lu,
				ayear
			)
			VALUES(
				@idacc,
				@idupb,
				GETDATE(),
				'TRIGGER',
				GETDATE(),
				'''TRIGGER''',
				@yvar
			)
		END
		SET @idacc = SUBSTRING(@idacc,1,LEN(@idacc)-4)
		SET @accountlevel = (LEN(@idacc) - 2) / 4
	END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

