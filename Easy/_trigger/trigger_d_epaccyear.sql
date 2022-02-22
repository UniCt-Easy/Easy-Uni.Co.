
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_epaccyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_epaccyear]
GO

 
 
CREATE    TRIGGER [trigger_d_epaccyear] ON [epaccyear] FOR DELETE
AS BEGIN
IF @@ROWCOUNT > 0
BEGIN
	DECLARE @idepacc int
	DECLARE @ayear int
	DECLARE @amount decimal(19,2)
	DECLARE @amount2 decimal(19,2)
	DECLARE @amount3 decimal(19,2)
	DECLARE @amount4 decimal(19,2)
	DECLARE @amount5 decimal(19,2)
	DECLARE @idacc varchar(38)
	DECLARE @idupb varchar(36)
	DECLARE @nphase tinyint
	DECLARE @parentidepacc int

	-- dobbiamo essere certi che esista expense in caso la riga sia stata già cancellata non verranno eseguiti pezzi 
	-- del trigger che però replicheremo come esecuzione nel trigger in delete su expense
	SELECT
		@idepacc = D.idepacc, @ayear = D.ayear, @idacc = D.idacc, @idupb = D.idupb,
		@nphase = I.nphase, 
			@amount = - isnull(IT.curramount,0),
			@amount2 = - isnull(IT.curramount2,0),
			@amount3 = - isnull(IT.curramount3,0),
			@amount4 = - isnull(IT.curramount4,0),
			@amount5 = - isnull(IT.curramount5,0),
		@parentidepacc = I.paridepacc
	FROM deleted D
	JOIN epacctotal IT
		ON IT.idepacc = D.idepacc
		AND IT.ayear = D.ayear
	LEFT OUTER JOIN epacc I
		ON I.idepacc = D.idepacc

	declare @is_variation char(1) 
	SET @is_variation = isnull((SELECT isnull(epacc.flagvariation,'N') FROM epacc WHERE idepacc = @idepacc),'N')  


	IF (@idacc IS NOT NULL)	AND (@nphase IS NOT NULL)
	BEGIN
		if( @is_variation = 'N')
			Begin
				EXECUTE trg_upd_upbepacctotal 
				@idacc, 
				@idupb,
				@nphase, 
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
				
				EXECUTE trg_upd_upbepacctotal @idacc, @idupb,@nphase, 
					@amount_ofvar, @amount2_ofvar, @amount3_ofvar, @amount4_ofvar, @amount5_ofvar

			End	
	END

	
					
	EXECUTE trg_del_epaccamount 
	@ayear, 
	@idepacc,
	@parentidepacc,
	@amount,@amount2,@amount3,@amount4,@amount5

	DECLARE @ybalance int	
	EXECUTE trg_yearbalance 'E', @ybalance OUTPUT	

	DECLARE @paymentphase tinyint	
	SET @paymentphase = 2

	IF @ayear = @ybalance
	BEGIN
		EXECUTE trg_evaluatearrearsepacc @idepacc, @ayear
	END
END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



