
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_epexpvar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_epexpvar]
GO

--setuser 'amm'

CREATE                   TRIGGER [trigger_d_epexpvar] ON [epexpvar] FOR DELETE
AS 
BEGIN

	DECLARE @idepexp int
	DECLARE @amount decimal(19,2)
	DECLARE @amount2 decimal(19,2)
	DECLARE @amount3 decimal(19,2)
	DECLARE @amount4 decimal(19,2)
	DECLARE @amount5 decimal(19,2)
	DECLARE @yvar int

	DECLARE @lu varchar(64)
	DECLARE @lt datetime
		
	SELECT
		@yvar = yvar, 
		@idepexp = idepexp, 
		@amount =  -isnull(amount,0),
		@amount2 = -isnull(amount2,0),
		@amount3 = -isnull(amount3,0),
		@amount4 = -isnull(amount4,0),
		@amount5 = -isnull(amount5,0),
		@lu = lu,
		@lt = lt
	FROM deleted
	
	IF (SELECT COUNT(*) FROM epexpyear WHERE idepexp = @idepexp AND ayear = @yvar) = 0
	BEGIN	
		RETURN
	END

	DECLARE @idacc varchar(38)
	DECLARE @idupb varchar(36)
	DECLARE @nphase tinyint
	DECLARE @parentidepexp int

	SELECT
		@idacc = epexpyear.idacc,
		@idupb = epexpyear.idupb,
		@nphase = epexp.nphase,
		@parentidepexp = epexp.paridepexp,
		@nphase = epexp.nphase
	FROM epexpyear
	JOIN epexp 		ON epexp.idepexp = epexpyear.idepexp
	WHERE epexp.idepexp = @idepexp		AND ayear = @yvar
		
	EXECUTE trg_amount_epexpvariation 	@yvar,	@idepexp,@parentidepexp, @amount,@amount2,@amount3,@amount4,@amount5
		
	declare @is_variation char(1) 
	SET @is_variation = isnull((SELECT isnull(epexp.flagvariation,'N') FROM epexp WHERE idepexp = @idepexp),'N') 

	if (@is_variation = 'N' )
	Begin
		EXECUTE trg_upd_upbepexptotal   @idacc, @idupb,	@nphase, @amount,@amount2,@amount3,@amount4,@amount5
	End
	Else
	Begin
		DECLARE @amount_ofvar decimal(19,2)
		DECLARE @amount2_ofvar decimal(19,2)
		DECLARE @amount3_ofvar decimal(19,2)
		DECLARE @amount4_ofvar decimal(19,2)
		DECLARE @amount5_ofvar decimal(19,2)
		set @amount_ofvar  = - @amount
		set @amount2_ofvar = - @amount2
		set @amount3_ofvar = - @amount3
		set @amount4_ofvar = - @amount4
		set @amount5_ofvar = - @amount5

		EXECUTE trg_upd_upbepexptotal   @idacc, @idupb,	@nphase, @amount_ofvar, @amount2_ofvar, @amount3_ofvar, @amount4_ofvar, @amount5_ofvar
	End

	DECLARE @ybalance int	
	EXECUTE trg_yearbalance 'E', @ybalance OUTPUT	

	DECLARE @paymentphase tinyint	
	SET @paymentphase = 2

	IF @yvar = @ybalance
	BEGIN
		EXECUTE trg_evaluatearrearsepexp @idepexp,@yvar
		/*IF @nphase < @paymentphase
		BEGIN
			EXECUTE trg_evaluatearrearsepexp
			@idepexp,
			@yvar
		END
		ELSE
		BEGIN
			DECLARE @currentphase tinyint
			DECLARE @idcurrentexp int
			SET @idcurrentexp = @idepexp
			SELECT @currentphase = (@paymentphase - 1)
			WHILE @currentphase > 0 
			BEGIN
				SELECT @idcurrentexp = paridepexp FROM epexp WHERE idepexp = @idcurrentexp

				EXECUTE trg_evaluatearrearsepexp
				@idcurrentexp,
				@yvar
	
				SELECT @currentphase = @currentphase - 1
			END

		END*/
	END



END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

