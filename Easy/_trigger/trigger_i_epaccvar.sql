SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_epaccvar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_epaccvar]
GO

CREATE TRIGGER [trigger_i_epaccvar] ON [epaccvar] FOR INSERT
AS BEGIN
	DECLARE @idepacc int
	DECLARE @yvar int
	DECLARE @amount decimal(19,2)
	DECLARE @amount2 decimal(19,2)
	DECLARE @amount3 decimal(19,2)
	DECLARE @amount4 decimal(19,2)
	DECLARE @amount5 decimal(19,2)
	DECLARE @lu varchar(64)
	DECLARE @lt datetime
	DECLARE @nphase tinyint
	
	SELECT
		@yvar = yvar, 
		@idepacc = idepacc, 
		@amount = amount,
		@amount2 = isnull(amount2,0),
		@amount3 = isnull(amount3,0),
		@amount4 = isnull(amount4,0),
		@amount5 = isnull(amount5,0),
		@lu = lu,
		@lt = lt
	FROM inserted

	DECLARE @idacc  varchar(38)
	DECLARE @idupb varchar(36)
	DECLARE @parentidepacc int
	
	SELECT
		@idacc = epaccyear.idacc,
		@idupb = epaccyear.idupb,
		@nphase = epacc.nphase,
		@parentidepacc = epacc.paridepacc
	FROM epaccyear
	JOIN epacc
		ON epacc.idepacc = epaccyear.idepacc
	WHERE epacc.idepacc = @idepacc
	AND ayear = @yvar

	EXECUTE trg_amount_epaccvariation 	@yvar,	@idepacc,@parentidepacc,@nphase,
					@amount,@amount2,@amount3,@amount4,@amount5
	
	declare @is_variation char(1) 
	SET @is_variation = isnull((SELECT isnull(epacc.flagvariation,'N') FROM epacc WHERE idepacc = @idepacc),'N')  

	if (@is_variation = 'N' )
	Begin
		EXECUTE trg_upd_upbepacctotal @idacc, @idupb, @nphase, 
					@amount,@amount2,@amount3,@amount4,@amount5
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

		EXECUTE trg_upd_upbepacctotal @idacc, @idupb, @nphase, 
						@amount_ofvar, @amount2_ofvar, @amount3_ofvar, @amount4_ofvar, @amount5_ofvar
	End

	DECLARE @ybalance int	
	EXECUTE trg_yearbalance 'I', @ybalance OUTPUT	

	DECLARE @paymentphase tinyint	
	SET @paymentphase = 2
	IF @yvar = @ybalance
	BEGIN
		EXECUTE trg_evaluatearrearsepacc @idepacc,@yvar
	END


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



