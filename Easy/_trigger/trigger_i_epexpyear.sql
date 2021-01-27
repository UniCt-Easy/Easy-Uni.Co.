
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_epexpyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_epexpyear]
GO

--setuser 'amministrazione'
--setuser 'amm'


CREATE   TRIGGER [trigger_i_epexpyear] ON [epexpyear] FOR INSERT
AS BEGIN
	
	DECLARE @idepexp int
	DECLARE @ayear int
	DECLARE @nphase tinyint
	DECLARE @idacc varchar(38)
	DECLARE @idupb varchar(36)
	DECLARE @amount decimal(19,2)
	DECLARE @amount2 decimal(19,2)
	DECLARE @amount3 decimal(19,2)
	DECLARE @amount4 decimal(19,2)
	DECLARE @amount5 decimal(19,2)

	DECLARE @parentidepexp int

	SELECT @idepexp = inserted.idepexp, 	@ayear = inserted.ayear, 
		@nphase = epexp.nphase, 	@idacc = inserted.idacc, 
			@idupb = inserted.idupb,
			@amount = isnull(inserted.amount,0),
			@amount2 = isnull(inserted.amount2,0),
			@amount3 = isnull(inserted.amount3,0),
			@amount4 = isnull(inserted.amount4,0),
			@amount5 = isnull(inserted.amount5,0),	
			@parentidepexp = epexp.paridepexp
	FROM inserted
	JOIN epexp
	ON epexp.idepexp = inserted.idepexp
	
	if (@idepexp is null) return
			
	EXECUTE trg_ins_epexpamount @ayear, @idepexp, @parentidepexp, @amount,@amount2,@amount3,@amount4,@amount5
			
	declare @is_variation char(1) 
	SET @is_variation = isnull((SELECT isnull(epexp.flagvariation,'N') FROM epexp WHERE idepexp = @idepexp),'N')  
	
	if  (@is_variation = 'N')
	Begin
		EXECUTE trg_upd_upbepexptotal @idacc,@idupb, @nphase, @amount,@amount2,@amount3,@amount4,@amount5
	End
	else
	Begin
		DECLARE @amount_ofvar decimal(19,2)
		DECLARE @amount2_ofvar decimal(19,2)
		DECLARE @amount3_ofvar decimal(19,2)
		DECLARE @amount4_ofvar decimal(19,2)
		DECLARE @amount5_ofvar decimal(19,2)
		set @amount_ofvar	 = - @amount
		set @amount2_ofvar = - @amount2
		set @amount3_ofvar = - @amount3
		set @amount4_ofvar = - @amount4
		set @amount5_ofvar = - @amount5
		EXECUTE trg_upd_upbepexptotal @idacc,@idupb, @nphase, @amount_ofvar, @amount2_ofvar, @amount3_ofvar, @amount4_ofvar, @amount5_ofvar
	end

	DECLARE @ybalance int
	SELECT @ybalance = max(ayear) FROM accountingyear WHERE ((flag&0x0F)>=5) 

	DECLARE @paymentphase tinyint	
	SET @paymentphase = 2

	--DECLARE @newamount decimal(19,2)
	--DECLARE @newamount2 decimal(19,2)
	--DECLARE @newamount3 decimal(19,2)
	--DECLARE @newamount4 decimal(19,2)
	--set @newamount= isnull(@amount,0)+isnull(@amount2,0)
	--set @newamount2 = @amount3
	--set @newamount3 = @amount4
	--set @newamount4 = @amount5
	
	-- Ora non dobbiamo cambiare il segno, perchè la sp lavora sul movimento, su idexp.
	IF @ayear = @ybalance
	BEGIN
		if (@is_variation='S') begin
			execute trg_updatearrearsepexp @idepexp,@ayear,	@nphase,@idacc, @idupb,@amount_ofvar,@amount2_ofvar,@amount3_ofvar, @amount4_ofvar, @amount5_ofvar
		end 
		else begin
			execute trg_updatearrearsepexp @idepexp,@ayear,	@nphase,@idacc, @idupb,@amount,@amount2,@amount3, @amount4, @amount5
		end

	END
			
	
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

