SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_epaccyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_epaccyear]
GO


CREATE    TRIGGER [trigger_u_epaccyear] ON [epaccyear] FOR UPDATE
AS BEGIN
	
	DECLARE @ayear int
	DECLARE @parentidepacc int
	DECLARE @idepacc int
	DECLARE @nphase tinyint
	DECLARE @newidacc varchar(38)
	DECLARE @newidupb varchar(36)
	DECLARE @newamount decimal(19,2)
	DECLARE @newamount2 decimal(19,2)
	DECLARE @newamount3 decimal(19,2)
	DECLARE @newamount4 decimal(19,2)
	DECLARE @newamount5 decimal(19,2)

	SELECT
		@idepacc = INS.idepacc, 
		@parentidepacc = E.paridepacc,
		@ayear = INS.ayear, 
		@nphase = E.nphase, 
		@newidacc = INS.idacc, 
		@newidupb = INS.idupb,
		@newamount = INS.amount,
		@newamount2 = INS.amount2,
		@newamount3 = INS.amount3,
		@newamount4 = INS.amount4,
		@newamount5 = INS.amount5
	FROM inserted INS
	JOIN epacc E
		ON E.idepacc = INS.idepacc
	JOIN epacctotal ET
		ON ET.idepacc = INS.idepacc
		AND ET.ayear = INS.ayear

	DECLARE @oldidacc varchar(38)
	DECLARE @oldidupb varchar(36)
	DECLARE @oldamount decimal(19,2)
	DECLARE @oldamount2 decimal(19,2)
	DECLARE @oldamount3 decimal(19,2)
	DECLARE @oldamount4 decimal(19,2)
	DECLARE @oldamount5 decimal(19,2)

	SELECT @oldidacc = idacc, 
		@oldidupb = idupb,
		@oldamount = -amount,
		@oldamount2 = -amount2,
		@oldamount3 = -amount3,
		@oldamount4 = -amount4,
		@oldamount5 = -amount5
	FROM deleted

	DECLARE @variationsamount decimal(19,2)
	DECLARE @variationsamount2 decimal(19,2)
	DECLARE @variationsamount3 decimal(19,2)
	DECLARE @variationsamount4 decimal(19,2)
	DECLARE @variationsamount5 decimal(19,2)
	SELECT @variationsamount = curramount + @oldamount ,
			@variationsamount2 = curramount2 + @oldamount2 ,
			@variationsamount3 = curramount3 + @oldamount3 ,
			@variationsamount4 = curramount4 + @oldamount4 ,
			@variationsamount5 = curramount5 + @oldamount5 
	FROM epacctotal
	WHERE idepacc = @idepacc AND ayear = @ayear
	
	DECLARE @oldcurrentamount decimal(19,2)
	DECLARE @oldcurrentamount2 decimal(19,2)
	DECLARE @oldcurrentamount3 decimal(19,2)
	DECLARE @oldcurrentamount4 decimal(19,2)
	DECLARE @oldcurrentamount5 decimal(19,2)
	SET @oldcurrentamount = @oldamount - @variationsamount
	SET @oldcurrentamount2 = @oldamount2 - @variationsamount2
	SET @oldcurrentamount3 = @oldamount3 - @variationsamount3
	SET @oldcurrentamount4 = @oldamount4 - @variationsamount4
	SET @oldcurrentamount5 = @oldamount5 - @variationsamount5

	DECLARE @newcurrentamount decimal(19,2)
	DECLARE @newcurrentamount2 decimal(19,2)
	DECLARE @newcurrentamount3 decimal(19,2)
	DECLARE @newcurrentamount4 decimal(19,2)
	DECLARE @newcurrentamount5 decimal(19,2)
	SET @newcurrentamount = @newamount + @variationsamount
	SET @newcurrentamount2 = @newamount2 + @variationsamount2
	SET @newcurrentamount3 = @newamount3 + @variationsamount3
	SET @newcurrentamount4 = @newamount4 + @variationsamount4
	SET @newcurrentamount5 = @newamount5 + @variationsamount5


	IF	((@newidacc <> @oldidacc) OR (@newidupb <> @oldidupb))
	BEGIN
		EXECUTE trg_upd_upbaccountepacc
		@idepacc,
		@ayear, 
		@nphase, 
		@newidacc,
		@newidupb
	END

	declare @is_variation char(1) 
	SET @is_variation = isnull((SELECT isnull(epacc.flagvariation,'N') FROM epacc WHERE idepacc = @idepacc),'N')  

	DECLARE @amount decimal(19,2)
	IF 	((@oldidacc <> @newidacc) OR (@oldidupb <> @newidupb))
	BEGIN
		if  (@is_variation = 'N')
		Begin
			EXECUTE trg_upd_upbepacctotal 	@oldidacc, 	@oldidupb,	@nphase, @oldcurrentamount,@oldcurrentamount2,@oldcurrentamount3,@oldcurrentamount4,@oldcurrentamount5

			EXECUTE trg_upd_upbepacctotal	@newidacc, 	@newidupb,	@nphase, @newcurrentamount,@newcurrentamount2,@newcurrentamount3,@newcurrentamount4,@newcurrentamount5
		End
		Else
		Begin
			DECLARE @oldcurrentamount_ofvar decimal(19,2)	DECLARE @newcurrentamount_ofvar decimal(19,2)
			DECLARE @oldcurrentamount2_ofvar decimal(19,2)	DECLARE @newcurrentamount2_ofvar decimal(19,2)
			DECLARE @oldcurrentamount3_ofvar decimal(19,2)	DECLARE @newcurrentamount3_ofvar decimal(19,2)
			DECLARE @oldcurrentamount4_ofvar decimal(19,2)	DECLARE @newcurrentamount4_ofvar decimal(19,2)
			DECLARE @oldcurrentamount5_ofvar decimal(19,2)	DECLARE @newcurrentamount5_ofvar decimal(19,2)
			set @oldcurrentamount_ofvar	 = - @oldcurrentamount
			set @oldcurrentamount2_ofvar = - @oldcurrentamount2
			set @oldcurrentamount3_ofvar = - @oldcurrentamount3
			set @oldcurrentamount4_ofvar = - @oldcurrentamount4
			set @oldcurrentamount5_ofvar = - @oldcurrentamount5

			EXECUTE trg_upd_upbepacctotal 	@oldidacc, 	@oldidupb,	@nphase, @oldcurrentamount_ofvar, @oldcurrentamount2_ofvar, @oldcurrentamount3_ofvar, @oldcurrentamount4_ofvar, @oldcurrentamount5_ofvar

			set @newcurrentamount_ofvar  = - @newcurrentamount
			set @newcurrentamount2_ofvar = - @newcurrentamount
			set @newcurrentamount3_ofvar = - @newcurrentamount
			set @newcurrentamount4_ofvar = - @newcurrentamount
			set @newcurrentamount5_ofvar = - @newcurrentamount

			EXECUTE trg_upd_upbepacctotal	@newidacc, 	@newidupb,	@nphase, @newcurrentamount_ofvar, @newcurrentamount2_ofvar, @newcurrentamount3_ofvar, @newcurrentamount4_ofvar, @newcurrentamount5_ofvar
		End
	END		

	DECLARE @diff decimal(19,2)
	DECLARE @diff2 decimal(19,2)
	DECLARE @diff3 decimal(19,2)
	DECLARE @diff4 decimal(19,2)
	DECLARE @diff5 decimal(19,2)
	SET @diff = @oldcurrentamount + @newcurrentamount
	SET @diff2 = @oldcurrentamount2 + @newcurrentamount2
	SET @diff3 = @oldcurrentamount3 + @newcurrentamount3
	SET @diff4 = @oldcurrentamount4 + @newcurrentamount4
	SET @diff5 = @oldcurrentamount5 + @newcurrentamount5

	IF (@newidacc = @oldidacc)	AND (@newidupb = @oldidupb)
	BEGIN
			if  (@is_variation = 'N')
				Begin
					EXECUTE trg_upd_upbepacctotal 
						@oldidacc, @oldidupb,	@nphase, 	@diff,@diff2,@diff3,@diff4,@diff5
				End
				Else
				Begin
				DECLARE @diff_ofvar decimal(19,2)
				DECLARE @diff2_ofvar decimal(19,2)
				DECLARE @diff3_ofvar decimal(19,2)
				DECLARE @diff4_ofvar decimal(19,2)
				DECLARE @diff5_ofvar decimal(19,2)
				SET @diff_ofvar  = -@diff
				SET @diff2_ofvar = -@diff2
				SET @diff3_ofvar = -@diff3
				SET @diff4_ofvar = -@diff4
				SET @diff5_ofvar = -@diff5 

				EXECUTE trg_upd_upbepacctotal 	@oldidacc, @oldidupb, @nphase, @diff_ofvar, @diff2_ofvar, @diff3_ofvar, @diff4_ofvar, @diff5_ofvar

				End
	END

	IF @newamount <> @oldamount OR
	(@newamount IS NULL AND @oldamount IS NOT NULL) OR
	(@newamount IS NOT NULL AND @oldamount IS NULL)
	BEGIN
		EXECUTE trg_upd_epaccamount  @ayear, @parentidepacc,@idepacc,@diff,@diff2,@diff3,@diff4,@diff5
	END

	DECLARE @ybalance int	
	EXECUTE trg_yearbalance 'I', @ybalance OUTPUT	

	DECLARE @paymentphase tinyint	
	SET @paymentphase = 2

	IF @ayear = @ybalance AND 
	(	@newamount != @oldamount OR
		(@newamount IS NULL AND @oldamount IS NOT NULL) OR
		(@newamount IS NOT NULL AND @oldamount IS NULL) OR
		(@oldidacc <> @newidacc) OR (@oldidupb <> @newidupb)
	)
	BEGIN
		EXECUTE trg_evaluatearrearsepacc @idepacc, @ayear
	END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 