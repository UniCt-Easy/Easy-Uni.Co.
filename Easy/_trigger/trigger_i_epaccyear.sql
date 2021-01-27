
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_epaccyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_epaccyear]
GO

--setuser 'amministrazione'
--setuser 'amm'

CREATE   TRIGGER [trigger_i_epaccyear] ON [epaccyear] FOR INSERT
AS BEGIN
	
	DECLARE @idepacc int
	DECLARE @ayear int
	DECLARE @nphase tinyint
	DECLARE @idacc varchar(38)
	DECLARE @idupb varchar(36)
	DECLARE @amount decimal(19,2)
	DECLARE @amount2 decimal(19,2)
	DECLARE @amount3 decimal(19,2)
	DECLARE @amount4 decimal(19,2)
	DECLARE @amount5 decimal(19,2)

	DECLARE @parentidepacc int

	SELECT @idepacc = inserted.idepacc, 	@ayear = inserted.ayear, 
		@nphase = epacc.nphase, 	@idacc = inserted.idacc, 
			@idupb = inserted.idupb,
			@amount = inserted.amount,@amount2 = inserted.amount2,@amount3 = inserted.amount3,@amount4 = inserted.amount4,@amount5 = inserted.amount5,			
			@parentidepacc = epacc.paridepacc
	FROM inserted
	JOIN epacc
	ON epacc.idepacc = inserted.idepacc

	if (@idepacc is null) return

	declare @is_variation char(1) 
	SET @is_variation = isnull((SELECT isnull(epacc.flagvariation,'N') FROM epacc WHERE idepacc = @idepacc),'N')  
		
	EXECUTE trg_ins_epaccamount @ayear, @idepacc, @parentidepacc, @amount,@amount2,@amount3,@amount4,@amount5
		
	if  (@is_variation = 'N')
		Begin	
			EXECUTE trg_upd_upbepacctotal @idacc,@idupb, @nphase, @amount,@amount2,@amount3,@amount4,@amount5
		End
		Else
		Begin
			DECLARE @amount_ofvar decimal(19,2)
			DECLARE @amount2_ofvar decimal(19,2)
			DECLARE @amount3_ofvar decimal(19,2)
			DECLARE @amount4_ofvar decimal(19,2)
			DECLARE @amount5_ofvar decimal(19,2)
			set @amount_ofvar	 = - isnull(@amount,0)
			set @amount2_ofvar = - isnull(@amount2,0)
			set @amount3_ofvar = - isnull(@amount3,0)
			set @amount4_ofvar = - isnull(@amount4,0)
			set @amount5_ofvar = - isnull(@amount5,0)
			EXECUTE trg_upd_upbepacctotal @idacc,@idupb, @nphase, @amount_ofvar, @amount2_ofvar, @amount3_ofvar, @amount4_ofvar, @amount5_ofvar
		End

	DECLARE @ybalance int
	SELECT @ybalance = max(ayear) FROM accountingyear WHERE ((flag&0x0F)>=4) 

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
	
	
	
	IF @ayear = @ybalance
	BEGIN
		if (@is_variation='S') begin
			execute trg_updatearrearsepacc @idepacc,@ayear,	@nphase,@idacc, @idupb,@amount_ofvar,@amount2_ofvar,@amount3_ofvar, @amount4_ofvar, @amount5_ofvar
		end 
		else begin
			execute trg_updatearrearsepacc @idepacc,@ayear,	@nphase,@idacc, @idupb,@amount,@amount2,@amount3, @amount4, @amount5
		end

	END
				
	
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




