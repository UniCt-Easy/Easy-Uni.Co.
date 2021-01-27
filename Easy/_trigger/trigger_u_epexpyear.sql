
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_epexpyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_epexpyear]
GO

--setuser 'amm'
CREATE    TRIGGER [trigger_u_epexpyear] ON [epexpyear] FOR UPDATE
AS BEGIN
	
	DECLARE @ayear int
	DECLARE @parentidepexp int
	DECLARE @idepexp int
	DECLARE @nphase tinyint
	DECLARE @newidacc varchar(38)
	DECLARE @newidupb varchar(36)
	DECLARE @newamount decimal(19,2)
	DECLARE @newamount2 decimal(19,2)
	DECLARE @newamount3 decimal(19,2)
	DECLARE @newamount4 decimal(19,2)
	DECLARE @newamount5 decimal(19,2)

	SELECT
		@idepexp = INS.idepexp, 
		@parentidepexp = E.paridepexp,
		@ayear = INS.ayear, 
		@nphase = E.nphase, 
		@newidacc = INS.idacc, 
		@newidupb = INS.idupb,
		@newamount = isnull(INS.amount,0),
		@newamount2 = isnull(INS.amount2,0),
		@newamount3 = isnull(INS.amount3,0),
		@newamount4 = isnull(INS.amount4,0),
		@newamount5 = isnull(INS.amount5,0)
	FROM inserted INS
	JOIN epexp E			ON E.idepexp = INS.idepexp	
	JOIN epexptotal ET		ON ET.idepexp = INS.idepexp		AND ET.ayear = INS.ayear

	DECLARE @oldidacc varchar(38)
	DECLARE @oldidupb varchar(36)
	DECLARE @oldamount decimal(19,2)
	DECLARE @oldamount2 decimal(19,2)
	DECLARE @oldamount3 decimal(19,2)
	DECLARE @oldamount4 decimal(19,2)
	DECLARE @oldamount5 decimal(19,2)

	SELECT @oldidacc = idacc, 
		@oldidupb = idupb,
		@oldamount = -isnull(amount,0),
		@oldamount2 = -isnull(amount2,0),
		@oldamount3 = -isnull(amount3,0),
		@oldamount4 = -isnull(amount4,0),
		@oldamount5 =-isnull(amount5,0)
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
	FROM epexptotal
	WHERE idepexp = @idepexp AND ayear = @ayear
	
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
		EXECUTE trg_upd_upbaccount
		@idepexp,
		@ayear, 
		@nphase, 
		@newidacc,
		@newidupb
	END

	declare @is_variation char(1) 
	SET @is_variation = isnull((SELECT isnull(epexp.flagvariation,'N') FROM epexp WHERE idepexp = @idepexp),'N') 

	DECLARE @amount decimal(19,2)
	IF 	((@oldidacc <> @newidacc) OR (@oldidupb <> @newidupb))
	BEGIN
		if  (@is_variation = 'N')
		Begin
			EXECUTE trg_upd_upbepexptotal 	@oldidacc, 	@oldidupb,	@nphase, @oldcurrentamount,@oldcurrentamount2,@oldcurrentamount3,@oldcurrentamount4,@oldcurrentamount5

			EXECUTE trg_upd_upbepexptotal	@newidacc, 	@newidupb,	@nphase, @newcurrentamount,@newcurrentamount2,@newcurrentamount3,@newcurrentamount4,@newcurrentamount5
		End
		else
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

			EXECUTE trg_upd_upbepexptotal 	@oldidacc, 	@oldidupb,	@nphase, @oldcurrentamount_ofvar, @oldcurrentamount2_ofvar, @oldcurrentamount3_ofvar, @oldcurrentamount4_ofvar, @oldcurrentamount5_ofvar

			set @newcurrentamount_ofvar  = - @newcurrentamount
			set @newcurrentamount2_ofvar = - @newcurrentamount
			set @newcurrentamount3_ofvar = - @newcurrentamount
			set @newcurrentamount4_ofvar = - @newcurrentamount
			set @newcurrentamount5_ofvar = - @newcurrentamount

			EXECUTE trg_upd_upbepexptotal	@newidacc, 	@newidupb,	@nphase, @newcurrentamount_ofvar, @newcurrentamount2_ofvar, @newcurrentamount3_ofvar, @newcurrentamount4_ofvar, @newcurrentamount5_ofvar
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
				EXECUTE trg_upd_upbepexptotal 	@oldidacc, @oldidupb,	@nphase, 	@diff,@diff2,@diff3,@diff4,@diff5
			end
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

				EXECUTE trg_upd_upbepexptotal 	@oldidacc, @oldidupb, @nphase, @diff_ofvar, @diff2_ofvar, @diff3_ofvar, @diff4_ofvar, @diff5_ofvar
			End
	END

	IF @newamount <> @oldamount OR
	(@newamount IS NULL AND @oldamount IS NOT NULL) OR
	(@newamount IS NOT NULL AND @oldamount IS NULL)
	BEGIN
		EXECUTE trg_upd_epexpamount  @ayear, @parentidepexp,@idepexp,@diff,@diff2,@diff3,@diff4,@diff5
	END

	DECLARE @ybalance int	
	EXECUTE trg_yearbalance 'E', @ybalance OUTPUT	

	DECLARE @paymentphase tinyint	
	SET @paymentphase = 2

	IF @ayear = @ybalance AND 
	(@newamount != @oldamount OR
	(@newamount IS NULL AND @oldamount IS NOT NULL) OR
	(@newamount IS NOT NULL AND @oldamount IS NULL) OR
		(@oldidacc <> @newidacc) OR (@oldidupb <> @newidupb)
	)
	BEGIN
		EXECUTE trg_evaluatearrearsepexp @idepexp, @ayear
	END

END







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

