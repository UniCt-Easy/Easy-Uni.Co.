
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_finvardetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_finvardetail]
GO

CREATE TRIGGER [trigger_u_finvardetail] ON [finvardetail] FOR UPDATE
AS BEGIN
IF (UPDATE(amount))
BEGIN
	DECLARE @yvar int
	DECLARE @nvar int
	DECLARE @idfin int
	DECLARE @idunderwriting int
	DECLARE @idupb varchar(36)
	DECLARE @newamount decimal(19,2)
	DECLARE @oldidlcard int	
	DECLARE @newidlcard int	
	DECLARE @variationkind tinyint

	SELECT 
		@yvar = yvar,
		@nvar = nvar,
		@idfin = idfin, 
		@idunderwriting = idunderwriting,
		@idupb = idupb,
		@newamount = amount, 
		@newidlcard  = idlcard
	FROM inserted
	
	DECLARE @oldamount decimal(19,2)
	DECLARE @oldparamamount decimal(19,2)

	SELECT @oldamount = -amount,
		   @oldparamamount = amount,
		   @oldidlcard = idlcard
	FROM deleted


	DECLARE @flagprevision char(1)
	DECLARE @flagprevision_inserted char(1)
	DECLARE @flagsecondaryprev char(1)
	DECLARE @flagcredit char(1)
	DECLARE @flagproceeds char(1)
	DECLARE @idfinvarstatus smallint
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
	WHERE yvar = @yvar AND nvar = @nvar

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

	--supponiamo @idfinvarstatus costante
	if 	(@idfinvarstatus= 5 AND @newidlcard is not null ) BEGIN
		update lcardtotal set amount= amount - @newamount
				where idlcard= @newidlcard

	END

	if 	(@idfinvarstatus= 5 AND @oldidlcard is not null) BEGIN
		update lcardtotal set amount= amount + @oldparamamount
				where idlcard= @oldidlcard

	END

	DECLARE @differenceamount decimal(19,2)
	SET @differenceamount = @oldamount + @newamount	

	DECLARE @idfinincomesurplus int
	DECLARE @previsionkind char(1)
	DECLARE @secprevisionkind char(1)
	DECLARE @fin_kind tinyint

	SELECT
		@idfinincomesurplus = idfinincomesurplus, 
		@fin_kind = ISNULL(fin_kind,0)
	FROM config WHERE ayear = @yvar

	IF (@flagprevision = 'S') AND (@variationkind <>5)
	BEGIN
		EXECUTE trg_upd_upbtotal @idfin, @idupb,'previsionvariation', @differenceamount
	
		IF (@idunderwriting IS NOT NULL) 
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal @idfin,@idupb,	@idunderwriting,'previsionvariation',	@differenceamount
		END
		IF (@idfinincomesurplus IS NOT NULL AND @idfinincomesurplus =@idfin) AND (@fin_kind = 2)
		BEGIN
			EXEC trg_upd_curr_floatfundfin
			@yvar,
			@oldparamamount,
			@newamount
		END
	END

	IF (@flagprevision_inserted = 'S') AND (@variationkind <>5)
	BEGIN
		EXECUTE trg_upd_upbtotal @idfin, @idupb,'previsionvariation_inserted', @differenceamount
	
		IF (@idunderwriting IS NOT NULL) 
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal @idfin,@idupb,	@idunderwriting,'@previsionvariation_inserted',	@differenceamount
		END
	END


	
	IF (@flagsecondaryprev = 'S') AND (@variationkind <>5)
	BEGIN
		EXECUTE trg_upd_upbtotal @idfin, @idupb, 'secondaryvariation', @differenceamount 

		IF (@idunderwriting IS NOT NULL)
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal @idfin,@idupb,	@idunderwriting,'secondaryvariation',@differenceamount
		END
		
		IF (@idfinincomesurplus IS NOT NULL AND @idfinincomesurplus  =@idfin) AND (@fin_kind = 3)
		BEGIN
			EXEC trg_upd_curr_floatfundfin	@yvar,@oldparamamount,@newamount
		END
	END
	
	IF (@flagprevision = 'S')  AND (@variationkind  = 5)
	BEGIN
		
		IF (@idunderwriting IS NOT NULL)
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal @idfin,@idupb,	@idunderwriting,'currentprev',	@differenceamount
		END
	END
	
	IF (@flagsecondaryprev = 'S') AND (@variationkind =5)
	BEGIN
		IF (@idunderwriting IS NOT NULL) 
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal @idfin,@idupb,@idunderwriting,'currentsecondaryprev',@differenceamount
		END	
	END
	
	IF (@flagcredit = 'S')and (@variationkind <>5)
	BEGIN
		EXECUTE trg_upd_upbtotal @idfin, @idupb,'creditvariation', @differenceamount
			
		IF (@idunderwriting IS NOT NULL)  
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal 	@idfin,	@idupb,	@idunderwriting,'creditvariation',	@differenceamount
		END
	END
	
	IF (@flagproceeds = 'S')and (@variationkind <>5)
	BEGIN
		EXECUTE trg_upd_upbtotal @idfin, @idupb,'proceedsvariation', @differenceamount
		
		IF (@idunderwriting IS NOT NULL) 
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal @idfin,@idupb,@idunderwriting,'proceedsvariation',	@differenceamount
		END
		
	END
END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




