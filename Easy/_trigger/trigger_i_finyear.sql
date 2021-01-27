
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_finyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_finyear]
GO

CREATE             TRIGGER [trigger_i_finyear] ON [finyear] FOR INSERT
AS BEGIN
	declare @howmany int
	select @howmany= count(*) from inserted	
	if (@howmany=0) return


	DECLARE @ayear int
	DECLARE	@idfin int
	DECLARE @idupb varchar(36)
	DECLARE	@prevision decimal(19, 2)
	DECLARE	@previousprevision decimal(19,2)
	DECLARE	@secondaryprev decimal(19,2)
	DECLARE	@previoussecondaryprev decimal(19,2)
	DECLARE	@currentarrears decimal(19,2)
	DECLARE	@previousarrears decimal(19,2)
	DECLARE	@expiration datetime
	DECLARE	@flagincomesurplus char(1)
	DECLARE	@cu varchar(64)
	DECLARE	@ct datetime
	DECLARE	@lu varchar(64)
	DECLARE	@lt datetime

	SELECT	@idfin=idfin, @ayear=ayear, @idupb=idupb,
		@prevision=prevision, @previousprevision=previousprevision, 
		@secondaryprev=secondaryprev, @previoussecondaryprev=previoussecondaryprev,
		@currentarrears=currentarrears, @previousarrears=previousarrears,
		@cu=cu, @ct=ct, @lu=lu, @lt=lt
	FROM inserted

	DECLARE @idfinincomesurplus int
	SELECT @idfinincomesurplus = idfinincomesurplus FROM config WHERE ayear = @ayear

	IF (@idfinincomesurplus = @idfin)
	BEGIN
		DECLARE @fin_kind tinyint

		SELECT @fin_kind = ISNULL(fin_kind, 0) FROM config WHERE ayear = @ayear

		IF (@fin_kind = 3)
		BEGIN
			EXEC rebuild_currentfloatfund @ayear
		END
		IF (@fin_kind = 2)
		BEGIN
			EXEC rebuild_currentfloatfund @ayear
		END
	END

	DECLARE @nlevel tinyint
	SELECT @nlevel = nlevel FROM fin WHERE idfin = @idfin

	DECLARE @minoplevel tinyint
	SELECT @minoplevel = MIN(nlevel) FROM finlevel WHERE (flag & 2) <> 0 AND ayear = @ayear

	-- Se sto inserendo un capitolo devo propagare la modifica fino al primo livello
	-- altrimenti inserisco in UPBTOTAL solo la voce di bilancio appena inserita
	IF (@nlevel <= @minoplevel) 
	BEGIN
		EXEC trg_upd_upbextended @idfin,@idupb,@previousprevision,@prevision,@previoussecondaryprev,@secondaryprev,@previousarrears,@currentarrears
	END
	ELSE
	BEGIN
		IF NOT EXISTS(SELECT * FROM upbtotal WHERE idfin = @idfin AND idupb = @idupb)
		BEGIN
			INSERT INTO upbtotal
			(
				idupb,
				idfin,
				currentprev,
				previousprev,
				currentsecondaryprev,
				previoussecondaryprev,
				currentarrears,
				previousarrears 
			)
			VALUES
			(
				@idupb,
				@idfin,
				@prevision,
				@previousprevision,
				@secondaryprev,
				@previoussecondaryprev,
				@currentarrears,
				@previousarrears 
			)
		END
		ELSE
		BEGIN
			UPDATE upbtotal SET currentprev = @prevision, previousprev = @previousprevision,
			currentsecondaryprev = @secondaryprev, previoussecondaryprev = @previoussecondaryprev,
			currentarrears =  @currentarrears, previousarrears = @previousarrears 
			WHERE idfin = @idfin AND idupb = @idupb
		END
	END

-- Inserimento righe in FINYEAR a zero sugli UPB padre di quello che sto inserendo nel caso in cui
-- tale voce non esiste

	IF (LEN(@idupb) > 4)
	BEGIN
		DECLARE @curridupb varchar(36)
		SET @curridupb = SUBSTRING(@idupb,1,LEN(@idupb)-4)
		IF NOT EXISTS(SELECT * FROM finyear WHERE idupb = @curridupb AND idfin = @idfin)
		BEGIN
			INSERT INTO finyear
			(
				idfin, idupb,
				prevision, secondaryprev,
				previousprevision, previoussecondaryprev,
				currentarrears, previousarrears,
				prevision2, prevision3, prevision4, prevision5,
				ct, cu, lt, lu,
				ayear
			)
			VALUES
			(
				@idfin, @curridupb,
				0, 0,
				0, 0,
				0, 0,
				0, 0, 0, 0,
				GETDATE(), 'TRIGGER', GETDATE(), '''TRIGGER''',
				@ayear
			)
		END
	END
	-- totalizza sugli UPB la previsione principale nel campo totprev di upbconstotal
	EXEC trg_totalizza_upbconstotal @idfin,@idupb, @prevision --,'A'	
	/*	I clienti non hanno questo trigger, rettorato_ok invece si. Affinchè non scatti il DB error al salvataggio di una	
																	previsione per la mancanza del parametro:
																		@A_I char(1) : A per approvata, I per inserita
																		che invece la sp trg_totalizza_upbconstotal richiede, gli passo 'A' .
																	*/
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

