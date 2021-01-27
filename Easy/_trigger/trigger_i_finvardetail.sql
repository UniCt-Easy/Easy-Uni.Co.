
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_finvardetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_finvardetail]
GO

CREATE TRIGGER [trigger_i_finvardetail] ON [finvardetail] FOR INSERT
AS BEGIN
	DECLARE @yvar int
	DECLARE @nvar int
	DECLARE @idfin int
	DECLARE @idunderwriting int
	DECLARE @idupb varchar(36)
	DECLARE @amount decimal(19,2)
	DECLARE @flagprevision char(1)
	DECLARE @flagsecondaryprev char(1)
	DECLARE @flagprevision_inserted char(1)
	DECLARE @flagcredit char(1)
	DECLARE @flagproceeds char(1)
	DECLARE @idfinvarstatus smallint
	DECLARE @idlcard int	
	DECLARE @variationkind tinyint
	
	SELECT 
		@yvar = yvar,
		@nvar = nvar,
		@idfin = idfin, 
		@idunderwriting = idunderwriting,
		@idupb = idupb,
		@amount = amount,
		@idlcard = idlcard
	FROM inserted

	DECLARE @finpart char(1)
	select @finpart =	CASE		when (( fin.flag & 1)=0) then 'E'
									when (( fin.flag & 1)=1) then 'S'
						End from fin where idfin=@idfin


	SELECT
		@flagprevision = ISNULL(flagprevision,'N'),		
		@flagsecondaryprev = ISNULL(flagsecondaryprev,'N'),
		@flagcredit = ISNULL(flagcredit,'N'),
		@flagproceeds = ISNULL(flagproceeds,'N'),
		@idfinvarstatus = ISNULL(idfinvarstatus,0),
		@variationkind = ISNULL(variationkind,0)
	FROM finvar
	WHERE yvar = @yvar
		AND nvar = @nvar

	set @flagprevision_inserted= @flagprevision

	if (@idfinvarstatus<>5) BEGIN  --non è previsione approvata
		SET @flagprevision='N'
		SET @flagsecondaryprev='N'
		SET @flagcredit='N'
		SET @flagproceeds='N'
	END

	if (@idfinvarstatus<>4 and @idfinvarstatus<>5) BEGIN --non è previsione inserita e nemmeno approvata
		SET @flagprevision_inserted='N'
	END
	
	

	if (@finpart='E') BEGIN
		SET @flagcredit='N'
		SET @flagproceeds='N'
	END


	if (@flagprevision='S' and @idlcard is not null) BEGIN
			update lcardtotal set amount= amount - @amount
				where idlcard= @idlcard
	END


	DECLARE @idfinincomesurplus int
	DECLARE @fin_kind tinyint

	SELECT
		@idfinincomesurplus = idfinincomesurplus, 
		@fin_kind = ISNULL(fin_kind,0)
	FROM config WHERE ayear = @yvar

	IF (@flagprevision = 'S')  --si occupa del campo previsionvariation
	BEGIN
		if (@variationkind <>5) 
		BEGIN
				EXECUTE trg_upd_upbtotal 	@idfin, @idupb,'previsionvariation', @amount
		END
		
		IF (@idunderwriting IS NOT NULL)  --si occupa del totalizzatore sui finanziamenti
		BEGIN
			if (@variationkind <>5)
			BEGIN 
				EXECUTE trg_upd_upbunderwritingtotal 	@idfin,	@idupb,	@idunderwriting,'previsionvariation',	@amount			
			END
			ELSE
			BEGIN  --la previsione approvata è totalizzata in upbunderwritingtotal.currentprev per le variazioni iniziali 
				EXECUTE trg_upd_upbunderwritingtotal 	@idfin,	@idupb,	@idunderwriting,'currentprev',	@amount			
			END

		END
		
		IF (@variationkind <>5) AND (@idfinincomesurplus IS NOT NULL) AND (@idfinincomesurplus  =@idfin) AND (@fin_kind = 2)
		BEGIN
			EXEC trg_ins_curr_floatfundfin	@yvar,	@amount
		END
	END
	
	IF (@flagprevision_inserted = 'S')  --si occupa del campo previsionvariation_inserted
	BEGIN
		if (@variationkind <>5) 
		BEGIN
				EXECUTE trg_upd_upbtotal 	@idfin, @idupb,'previsionvariation_inserted', @amount
		END
		
		IF (@idunderwriting IS NOT NULL) --si occupa del totalizzatore sui finanziamenti
		BEGIN
			if (@variationkind <>5)
			BEGIN 
				EXECUTE trg_upd_upbunderwritingtotal 	@idfin,	@idupb,	@idunderwriting,'previsionvariation_inserted',	@amount			
			END
			/*  NON E' PREVISTA LA GESTIONE DELLE VAR.INIZIALI INSERITE E NON APPROVATE 
			ELSE
			BEGIN 
				EXECUTE trg_upd_upbunderwritingtotal 	@idfin,	@idupb,	@idunderwriting,'currentprev',	@amount			
			END
			*/

		END
		
	END
	

	IF (@flagsecondaryprev = 'S')   
	BEGIN
		if (@variationkind <>5)
		BEGIN 
			EXECUTE trg_upd_upbtotal @idfin, @idupb,'secondaryvariation', 	@amount
		END
		
		IF (@idunderwriting IS NOT NULL) 
		BEGIN
			if (@variationkind <>5)
			BEGIN 
				EXECUTE trg_upd_upbunderwritingtotal 	@idfin,	@idupb,	@idunderwriting,'secondaryvariation',	@amount
			END
			ELSE
			BEGIN
				EXECUTE trg_upd_upbunderwritingtotal	@idfin, @idupb,	@idunderwriting,'currentsecondaryprev',	@amount
			END
		END
		
		IF (@variationkind <>5) AND (@idfinincomesurplus IS NOT NULL) AND (@idfinincomesurplus  =@idfin) AND (@fin_kind = 3)
		BEGIN
			EXEC trg_ins_curr_floatfundfin	@yvar,	@amount
		END
	END
	
	
	
	IF (@flagcredit = 'S')and (@variationkind <>5)
	BEGIN
		EXECUTE trg_upd_upbtotal @idfin, @idupb,'creditvariation', 	@amount
		
		IF (@idunderwriting IS NOT NULL)
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal 	@idfin,	@idupb,	@idunderwriting,	'creditvariation',	@amount
		END
	END
	
	IF (@flagproceeds = 'S')and (@variationkind <>5)
	BEGIN
		EXECUTE trg_upd_upbtotal @idfin, @idupb,'proceedsvariation', @amount
		
		IF (@idunderwriting IS NOT NULL) 
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal 
				@idfin,
				@idupb,
				@idunderwriting,
				'proceedsvariation',
				@amount
		END
	END
	
	-- Se non esiste la previsione della coppia (UPB,BILANCIO) in fase di creazione della var.
	-- si aggiunge la riga in FINYEAR
--	Questa parte di codice è stata rimossa perchè provoca eccezioni in fase di creazione della previsione
--	tramite il button CreaPrevisione. Per ulteriori dettagli vedere il task n. 3886.
	DECLARE @finlevel int
	SELECT @finlevel = nlevel FROM fin WHERE idfin = @idfin

	DECLARE @minusablelevel tinyint
	SELECT @minusablelevel = MIN(nlevel) FROM finlevel WHERE ayear = @yvar AND (flag & 2) <> 0

	WHILE(@finlevel >= @minusablelevel)
	BEGIN
		IF NOT EXISTS(SELECT * FROM finyear WHERE idfin = @idfin AND idupb = @idupb)
		AND ((@flagprevision = 'S') OR (@flagsecondaryprev = 'S'))
		BEGIN
			INSERT INTO finyear
			(
				idfin,
				idupb,
				ct,
				cu,
				lt,
				lu,
				ayear
			)
			VALUES(
				@idfin,
				@idupb,
				GETDATE(),
				'TRIGGER',
				GETDATE(),
				'''TRIGGER''',
				@yvar
			)
		END
		SET @finlevel = @finlevel - 1
		SELECT @idfin = idparent FROM finlink WHERE idchild = @idfin AND nlevel = @finlevel
	END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO






