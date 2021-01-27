
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_entrydetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_entrydetail]
GO

--setuser 'amministrazione'
--setuser 'amm'
CREATE    TRIGGER [trigger_d_entrydetail] ON [entrydetail] FOR DELETE
AS 
BEGIN

	DECLARE @idepexp int
	DECLARE @idepacc int
	DECLARE @amount decimal(19,2)
	DECLARE @yentry int
	DECLARE @nentry int
	DECLARE @idacc varchar(38)
	DECLARE @idupb varchar(36)
	declare @flagaccountusage int
	DECLARE @lu varchar(64)
	DECLARE @lt datetime
	DECLARE @ricavo decimal(19,2)
	DECLARE @costo decimal(19,2)

	SELECT
		@yentry = yentry, 
		@nentry = nentry, 
		@idepexp = idepexp, 
		@idepacc= idepacc, 
		@costo = -amount,
		@ricavo = amount,
		@amount = amount,
		@idacc = idacc,
		@idupb = idupb,
		@lu = lu,
		@lt = lt
	FROM deleted
		
	declare @identrykind int
	select @identrykind =  ISNULL(identrykind, 0) from entry where nentry = @nentry and yentry = @yentry
	if(@identrykind IN (6,10,11,12)) 		
	Begin
		return
	End

	select @flagaccountusage =  flagaccountusage from account where idacc=@idacc

	DECLARE @nphase tinyint
	DECLARE @parentidepexp int
	DECLARE @parentidepacc int
	DECLARE @ybalance int	



	IF ((@idepexp is not null) and (@flagaccountusage & (4096+256+64+16+2+32))<>0 )	--costo+riserva+debito+rateo
	BEGIN
		if (@flagaccountusage & 16)<>0 begin
			update epexptotal set debit= isnull(debit,0)-isnull(@ricavo,0) where idepexp=@idepexp and ayear=@yentry
		end
		
		if (@flagaccountusage & 32)<>0 begin  --conto di credito
			update epexptotal set debit= isnull(debit,0)-isnull(@costo,0) where idepexp=@idepexp and ayear=@yentry
		end

		if (@flagaccountusage & 2)<>0 begin
			update epexptotal set rateo= isnull(rateo,0)-isnull(@costo,0) where idepexp=@idepexp and ayear=@yentry
		end

		if (@flagaccountusage & (256+64))<>0 begin
			update epexptotal set cost= isnull(cost,0)-isnull(@costo,0) where idepexp=@idepexp and ayear=@yentry
		end		

		if (@flagaccountusage & 4096)<>0 begin
			update epexptotal set accantonamento= isnull(accantonamento,0)-isnull(@costo,0) where idepexp=@idepexp and ayear=@yentry
		end		


		EXECUTE trg_yearbalance 'E', @ybalance OUTPUT	

		DECLARE @paridepexp int
		SELECT @paridepexp = paridepexp FROM epexp WHERE idepexp = @idepexp

		IF ( @yentry = @ybalance and @idepexp is not null)
		BEGIN
				EXECUTE trg_evaluatearrearsepexp @idepexp, @yentry
				if (@paridepexp is not null) begin
					EXECUTE trg_evaluatearrearsepexp @paridepexp,@yentry
				end

		END
		
	END
	
IF ((@idepacc is not null) and (@flagaccountusage & (128+32+1+16))<>0 )	--ricavo+credito+rateo
	BEGIN
		if (@flagaccountusage & 16)<>0 begin --conto di debito
			update epacctotal set credit= isnull(credit,0)-isnull(@ricavo,0) where idepacc=@idepacc and ayear=@yentry
		end

		if (@flagaccountusage & 32)<>0 begin
			update epacctotal set credit= isnull(credit,0)-isnull(@costo,0) where idepacc=@idepacc and ayear=@yentry
		end
		if (@flagaccountusage & 1)<>0 begin
			update epacctotal set rateo= isnull(rateo,0)-isnull(@ricavo,0) where idepacc=@idepacc and ayear=@yentry
		end

		if (@flagaccountusage & 128)<>0 begin
			update epacctotal set revenue= isnull(revenue,0)-isnull(@ricavo,0) where idepacc=@idepacc and ayear=@yentry
		end

		DECLARE @paridepacc int 		
		
		EXECUTE trg_yearbalance 'I', @ybalance OUTPUT	

		SELECT @paridepacc = paridepacc FROM epacc WHERE idepacc = @idepacc

			IF ( @yentry = @ybalance and @idepacc is not null)
			BEGIN
				EXECUTE trg_evaluatearrearsepacc @idepacc, @yentry
				if (@paridepacc is not null) begin
					EXECUTE trg_evaluatearrearsepacc @paridepacc,@yentry
				end
			END

	END

update entrytotal set amount = isnull(amount,0) - isnull(@amount,0) where yentry =@yentry and nentry = @nentry	

END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



 
