
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_finyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_finyear]
GO


CREATE TRIGGER [trigger_u_finyear] ON [finyear] FOR UPDATE
AS BEGIN
	-- Imposto updatefc a N in quanto modifico il fondo di cassa solo se mi trovo in una delle configurazioni descritte in testa agli IF
	DECLARE @updatefc char(1)
	SELECT @updatefc = 'N' 

	declare @howmany int
	select @howmany= count(*) from inserted	
	if (@howmany=0) return


	DECLARE @ayear int
	DECLARE @idfin int
	DECLARE @idupb varchar(36)
	SELECT @ayear = ayear, @idfin = idfin, @idupb = idupb FROM inserted

	DECLARE @previsionkind char(1)
	DECLARE @secprevisionkind char(1)
	DECLARE @idfinincomesurplus int
	DECLARE @fin_kind tinyint

	SELECT
		@fin_kind = fin_kind,
		@idfinincomesurplus = idfinincomesurplus
	FROM config WHERE ayear = @ayear

	DECLARE @newamount decimal(19,2)
	DECLARE @oldamount decimal(19,2)
	
	DECLARE @newprevamount decimal(19,2)
	DECLARE @oldprevamount decimal(19,2)
	DECLARE @diffprevamount decimal(19,2)
	
	SELECT 
		@newprevamount = prevision
		FROM inserted
	
	SELECT
		@oldprevamount = prevision
		FROM deleted
		
	SELECT @diffprevamount = ISNULL(@newprevamount,0) - iSNULL(@oldprevamount,0)
	
	DECLARE @previsionkindcash char(1)

	-- Caso A: Previsione Principale di Competenza e Previsione Secondaria di Cassa	
	IF (@fin_kind = 3)
	BEGIN
		SELECT 
		@newamount = secondaryprev
		FROM inserted
		SELECT
		@oldamount = secondaryprev
		FROM deleted
	
		SELECT @previsionkindcash = 'S'
		SELECT @updatefc = 'S'
	END
	
	-- Caso B: Previsione Principale di Cassa
	IF (@fin_kind = 2)
	BEGIN
		
		SELECT 
		@newamount = prevision
		FROM inserted
		SELECT
		@oldamount = prevision
		FROM deleted
	
		SELECT @previsionkindcash = 'P'
		SELECT @updatefc = 'S'
	END

	DECLARE	@prevision decimal(19,2)
	DECLARE	@previousprevision decimal(19,2)
	DECLARE	@secondaryprev decimal(19,2)
	DECLARE	@previoussecondaryprev decimal(19,2)
	DECLARE	@currentarrears decimal(19,2)
	DECLARE	@previousarrears decimal(19,2)

	IF (@updatefc = 'S')
	BEGIN
		-- Caso A-B.1: Modifico l'importo di una voce di bilancio
		IF (@idfinincomesurplus = @idfin) AND (ISNULL(@newamount,0) <> ISNULL(@oldamount,0))
		BEGIN
			EXEC trg_upd_curr_floatfundfin
			@ayear,
			@oldamount,
			@newamount
		END
	END
	
	SELECT
		@prevision = -ISNULL(prevision,0),
		@previousprevision = -ISNULL(previousprevision,0), 
		@secondaryprev = -ISNULL(secondaryprev,0),
		@previoussecondaryprev = -ISNULL(previoussecondaryprev,0),
		@currentarrears = -ISNULL(currentarrears,0),
		@previousarrears = -ISNULL(previousarrears,0)
	FROM deleted

	SELECT
		@prevision = @prevision + ISNULL(prevision,0), 
		@previousprevision = @previousprevision + ISNULL(previousprevision,0), 
		@secondaryprev = @secondaryprev + ISNULL(secondaryprev,0), 
		@previoussecondaryprev = @previoussecondaryprev + ISNULL(previoussecondaryprev,0),
		@currentarrears = @currentarrears + ISNULL(currentarrears,0),
		@previousarrears = @previousarrears + ISNULL(previousarrears,0)
	FROM inserted

	-- Se mi trovo sul Capitolo devo propagare la modifica fino al primo livello
	-- altrimenti devo modificare solamente il livello modificato
	DECLARE @nlevel tinyint
	SELECT @nlevel = nlevel FROM fin WHERE idfin = @idfin

	DECLARE @minlevelop tinyint
	SELECT @minlevelop = MIN(nlevel) FROM finlevel WHERE (flag & 2 <> 0) AND ayear = @ayear
	IF (@nlevel = @minlevelop) 
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
			UPDATE upbtotal SET
			currentprev = @prevision + ISNULL(currentprev,0), 
			previousprev = @previousprevision + ISNULL(previousprev,0), 
			currentsecondaryprev = @secondaryprev + ISNULL(currentsecondaryprev,0), 
			previoussecondaryprev = @previoussecondaryprev + ISNULL(previoussecondaryprev,0),
			currentarrears = @currentarrears + ISNULL(currentarrears,0),
			previousarrears = @previousarrears + ISNULL(previousarrears,0)
			WHERE idfin = @idfin AND idupb = @idupb
		END
	END
	-- totalizza sugli UPB la previsione principale nel campo totprev di upbconstotal
	
	EXEC trg_totalizza_upbconstotal @idfin,@idupb, @diffprevamount --		, 'A'
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

