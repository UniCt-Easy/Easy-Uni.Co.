
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_finvardetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_finvardetail]
GO

CREATE TRIGGER [trigger_d_finvardetail] ON [finvardetail] FOR DELETE
AS BEGIN
IF @@ROWCOUNT > 0
BEGIN
	DECLARE @yvar int
	DECLARE @nvar int
	DECLARE @idfin int
	DECLARE @idunderwriting int
	DECLARE @idupb varchar(36)
	DECLARE @amount decimal(19,2)
	DECLARE @paramamount decimal(19,2)
	DECLARE @idlcard int
	DECLARE @variationkind tinyint
	

	SELECT 
		@yvar = yvar,
		@nvar = nvar,
		@idfin = idfin, 
		@idupb = idupb,
		@idunderwriting = idunderwriting, 
		@amount = -amount,
		@paramamount = amount,
		@idlcard = idlcard  
	FROM deleted

	DECLARE @finpart char(1)
	select @finpart =	CASE		when (( fin.flag & 1)=0) then 'E'
									when (( fin.flag & 1)=1) then 'S'
						End from fin where idfin=@idfin

	-- Dichiarazione variabili per il ricalcolo del fondo cassa

	DECLARE @flagprevision char(1)
	DECLARE @flagprevision_inserted char(1)
	DECLARE @flagsecondaryprev char(1)
	DECLARE @flagcredit char(1)
	DECLARE @flagproceeds char(1)
	DECLARE @idfinvarstatus smallint
	
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
	
	if (@idfinvarstatus<>5) BEGIN
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
	update lcardtotal set amount= amount + @paramamount
		where idlcard= @idlcard
	END
	

	DECLARE @idfinincomesurplus int
	DECLARE @fin_kind tinyint
	SELECT
		@idfinincomesurplus = idfinincomesurplus, 
		@fin_kind = ISNULL(fin_kind,0)
	FROM config WHERE ayear = @yvar

	IF (@flagprevision = 'S')  
	BEGIN
		if (@variationkind <>5)
		BEGIN
			EXECUTE trg_upd_upbtotal 	@idfin, 	@idupb,	'previsionvariation', 		@amount
		END
		
		IF (@idunderwriting IS NOT NULL)
		BEGIN
			if  (@variationkind  <> 5)
			BEGIN
				EXECUTE trg_upd_upbunderwritingtotal 	@idfin,	@idupb,	@idunderwriting,'previsionvariation',	@amount
			END
			ELSE
			BEGIN
			   	EXECUTE trg_upd_upbunderwritingtotal 	@idfin,	@idupb,	@idunderwriting,'currentprev',	@amount
			END
		END

		IF (@variationkind <>5) AND (@idfinincomesurplus IS NOT NULL) AND (@idfinincomesurplus =@idfin) AND (@fin_kind = 2)
		BEGIN
			EXEC trg_del_curr_floatfundfin		@yvar,	@paramamount
		END
	END
	
	IF (@flagprevision_inserted = 'S')  
	BEGIN
		if (@variationkind <>5)
		BEGIN
			EXECUTE trg_upd_upbtotal 	@idfin, 	@idupb,	'previsionvariation_inserted', 		@amount
		END
		
		IF (@idunderwriting IS NOT NULL)
		BEGIN
			if  (@variationkind  <> 5)
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
			EXECUTE trg_upd_upbtotal 	@idfin, 	@idupb,	'secondaryvariation', 	@amount
		END
		
		IF (@idunderwriting IS NOT NULL) 
		BEGIN
			if  (@variationkind  <> 5)
			BEGIN
				EXECUTE trg_upd_upbunderwritingtotal @idfin,	@idupb,	@idunderwriting,	'secondaryvariation',	@amount
			END
			ELSE
			BEGIN
				EXECUTE trg_upd_upbunderwritingtotal @idfin,	@idupb,	@idunderwriting,	'currentsecondaryprev',	@amount
			END
		END
		
		IF (@variationkind <>5) AND (@idfinincomesurplus IS NOT NULL) AND (@idfinincomesurplus  =@idfin) AND (@fin_kind = 3)
		BEGIN
			EXEC trg_del_curr_floatfundfin	@yvar,	@paramamount
		END
	END
	
	
	IF (@flagcredit = 'S') and (@variationkind <>5) 
	BEGIN
		EXECUTE trg_upd_upbtotal 		@idfin, @idupb,	'creditvariation', 		@amount
			
		IF (@idunderwriting IS NOT NULL)
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal 	@idfin,	@idupb,	@idunderwriting,	'creditvariation',	@amount
		END
	END
	
	IF (@flagproceeds = 'S') and (@variationkind <>5) 
	BEGIN
		EXECUTE trg_upd_upbtotal 	@idfin, 	@idupb,		'proceedsvariation', 	@amount
		
		IF (@idunderwriting IS NOT NULL)
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal 	@idfin,	@idupb,	@idunderwriting,	'proceedsvariation',	@amount
		END
	END
END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




