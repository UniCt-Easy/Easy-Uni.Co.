
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_entrydetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_entrydetail]
GO
 
--setuser 'amministrazione'
--setuser 'amm'
CREATE                   TRIGGER [trigger_u_entrydetail] ON [entrydetail] FOR UPDATE
AS BEGIN
		

	DECLARE @yentry int
	DECLARE @nentry int
	DECLARE @newamount decimal(19,2)
	DECLARE @oldamount decimal(19,2)

	DECLARE @newamount2 decimal(19,2)
	DECLARE @newamount3 decimal(19,2)
	DECLARE @newamount4 decimal(19,2)
	DECLARE @newamount5 decimal(19,2)	
	DECLARE @lu varchar(64)
	DECLARE @lt datetime
	DECLARE @idepexp int
	DECLARE @idepacc int
	DECLARE @newcosto decimal(19,2)
	DECLARE @newricavo decimal(19,2)
	DECLARE @oldcosto decimal(19,2)
	DECLARE @oldricavo decimal(19,2)

	DECLARE @idacc varchar(38)
	DECLARE @idupb varchar(36)
	DECLARE @ybalance int	
	DECLARE @parent_oldidepexp int
	DECLARE @parent_oldidepacc int
	DECLARE @parent_nphase tinyint

	declare @flagaccountusage int


	SELECT
		@yentry = yentry, 
		@nentry = nentry, 
		@idepexp = idepexp, 
		@idepacc = idepacc, 
		@newcosto = -isnull(amount,0),
		@newricavo = isnull(amount,0),
		@newamount = amount,
		@idacc = idacc,
		@idupb = idupb,
		@lu = lu,
		@lt = lt
	FROM inserted

	declare @identrykind int
	select @identrykind =  ISNULL(identrykind, 0) from entry where nentry = @nentry and yentry = @yentry
	if(@identrykind IN (6,10,11,12)) 		
	Begin
		return
	End

	select @flagaccountusage =  flagaccountusage from account where idacc=@idacc

	DECLARE @oldidepexp int
	DECLARE @oldidepacc int
	
	SELECT	@oldcosto = -isnull(amount,0),
			@oldricavo = isnull(amount,0),
			@oldamount = -amount, 
			@oldidepexp = idepexp, 
			@oldidepacc = idepacc 
	FROM deleted

	DECLARE @nphase tinyint

	DECLARE @parentidepexp int
	DECLARE @parentidepacc int
	
	if (@idepexp IS NOT NULL or @oldidepexp is not null) and (@flagaccountusage & (4096+256+64+16+2+32))<>0 
	BEGIN
		if (@flagaccountusage & 16)<>0 begin			
			--attenzione: E' VOLUTO l'uso delle var @newricavo e @oldricavo per cambiare il SEGNO rispetto al costo
			if (isnull(@oldidepexp,0) <> isnull(@idepexp,0))begin
					if (@oldidepexp is not null) update epexptotal set debit= isnull(debit,0)-@oldricavo  where idepexp=@oldidepexp and ayear=@yentry
					if (@idepexp is not null) update epexptotal set debit= isnull(debit,0)+@newricavo where idepexp=@idepexp and ayear=@yentry
				end
			else begin
					if (@idepexp is not null and (@newricavo<>@oldricavo))  begin
						update epexptotal set debit= isnull(debit,0)+@newricavo-@oldricavo where idepexp=@idepexp and ayear=@yentry
					end
			end
		end

		if (@flagaccountusage & 32)<>0 begin	--conto di credito, comportamento opposto		
			if (isnull(@oldidepexp,0) <> isnull(@idepexp,0))begin
					if (@oldidepexp is not null) update epexptotal set debit= isnull(debit,0)+@oldricavo  where idepexp=@oldidepexp and ayear=@yentry
					if (@idepexp is not null) update epexptotal set debit= isnull(debit,0)-@newricavo where idepexp=@idepexp and ayear=@yentry
				end
			else begin
					if (@idepexp is not null and (@newricavo<>@oldricavo))  begin
						update epexptotal set debit= isnull(debit,0)-@newricavo+@oldricavo where idepexp=@idepexp and ayear=@yentry
					end
			end
		end

		if (@flagaccountusage & 2)<>0 begin			
			--attenzione: E' VOLUTO l'uso delle var @newricavo e @oldricavo per cambiare il SEGNO rispetto al costo
			if (isnull(@oldidepexp,0) <> isnull(@idepexp,0))begin
					if (@oldidepexp is not null) update epexptotal set rateo= isnull(rateo,0)-@oldcosto where idepexp=@oldidepexp and ayear=@yentry
					if (@idepexp is not null) update epexptotal set rateo= isnull(rateo,0)+@newcosto where idepexp=@idepexp and ayear=@yentry
				end
			else begin
					if (@idepexp is not null and (@newcosto<>@oldcosto))  begin
						update epexptotal set rateo= isnull(rateo,0)+@newcosto -@oldcosto where idepexp=@idepexp and ayear=@yentry
					end
			end
		end

		if ( @flagaccountusage & 4096 <> 0) begin
				if (isnull(@oldidepexp,0) <> isnull(@idepexp,0))begin
					if (@oldidepexp is not null) update epexptotal set accantonamento= isnull(accantonamento,0)-@oldcosto where idepexp=@oldidepexp and ayear=@yentry
					if (@idepexp is not null) update epexptotal set accantonamento= isnull(accantonamento,0)+@newcosto where idepexp=@idepexp and ayear=@yentry
				end
				else begin
					if (@idepexp is not null and (@newcosto<>@oldcosto))  begin
						update epexptotal set accantonamento= isnull(accantonamento,0)+@newcosto-@oldcosto where idepexp=@idepexp and ayear=@yentry
					end
				end				
		end


		if ( @flagaccountusage & (256+64) <> 0) begin

				if (isnull(@oldidepexp,0) <> isnull(@idepexp,0))begin
					if (@oldidepexp is not null) update epexptotal set cost= isnull(cost,0)-@oldcosto where idepexp=@oldidepexp and ayear=@yentry
					if (@idepexp is not null) update epexptotal set cost= isnull(cost,0)+@newcosto where idepexp=@idepexp and ayear=@yentry
				end
				else begin
					if (@idepexp is not null and (@newcosto<>@oldcosto))  begin
						update epexptotal set cost= isnull(cost,0)+@newcosto-@oldcosto where idepexp=@idepexp and ayear=@yentry
					end
				end				
		end
		else begin
			set @newricavo=0
		end

		SELECT	@parentidepexp = epexp.paridepexp	FROM epexp	WHERE epexp.idepexp = @idepexp			

		--Sto modificando l'importo della scrittura
		EXECUTE trg_yearbalance 'E', @ybalance OUTPUT	

		SELECT @parent_oldidepexp = paridepexp FROM epexp WHERE idepexp = @oldidepexp

		IF ( @yentry = @ybalance)
			BEGIN
					if (  @oldidepexp is null and @idepexp is not null) --Stiamo collegando l'impegno  = Insert
					Begin
							execute trg_updatearrearsepexp @idepexp,@yentry, 2,@idacc, @idupb,@newricavo,null,null,null,null
							set @parent_nphase = @nphase - 1
							execute trg_updatearrearsepexp @parentidepexp,@yentry, 1, @idacc, @idupb,@newricavo,null,null,null,null
					End
					if(  @oldidepexp is not null and @idepexp is null) --Stiamo Scollegando l'impegno = Delete
					Begin
						EXECUTE trg_evaluatearrearsepexp @oldidepexp, @yentry

						EXECUTE trg_evaluatearrearsepexp @parent_oldidepexp,@yentry
					End

					if (  @oldidepexp = @idepexp) 
						and
						(@newamount <> -@oldamount OR
						(@newamount IS NULL AND @oldamount IS NOT NULL) OR
						(@newamount IS NOT NULL AND @oldamount IS NULL))
					Begin
						EXECUTE trg_evaluatearrearsepexp @idepexp, @yentry

						EXECUTE trg_evaluatearrearsepexp @parentidepexp,@yentry
					End
		END
		
END


IF (@idepacc is not null or @oldidepacc is not null) and (@flagaccountusage & (128+32+1+16))<>0 

BEGIN
		if (@flagaccountusage & 16)<>0 begin  --conto di debito: comportamento OPPOSTO al caso del credito
			--attenzione: E' VOLUTO l'uso delle var  @newcostoicavo e @oldcosto per cambiare il SEGNO rispetto al ricavo
			if (isnull(@oldidepacc,0) <> isnull(@idepacc,0))begin
					if (@oldidepacc is not null) update epacctotal set credit= isnull(credit,0)+@oldcosto where idepacc=@oldidepacc and ayear=@yentry
					if (@idepacc is not null) update epacctotal set credit= isnull(credit,0)-@newcosto where idepacc=@idepacc and ayear=@yentry
				end
				else begin
					if (@idepacc is not null and (@newcosto<>@oldcosto) ) begin
						 update epacctotal set credit= isnull(credit,0)-@newcosto+@oldcosto where idepacc=@idepacc and ayear=@yentry
					end
				end

		end	


		if (@flagaccountusage & 32)<>0 begin  --conto di credito
			--attenzione: E' VOLUTO l'uso delle var  @newcostoicavo e @oldcosto per cambiare il SEGNO rispetto al ricavo
			if (isnull(@oldidepacc,0) <> isnull(@idepacc,0))begin
					if (@oldidepacc is not null) update epacctotal set credit= isnull(credit,0)-@oldcosto where idepacc=@oldidepacc and ayear=@yentry
					if (@idepacc is not null) update epacctotal set credit= isnull(credit,0)+@newcosto where idepacc=@idepacc and ayear=@yentry
				end
				else begin
					if (@idepacc is not null and (@newcosto<>@oldcosto) ) begin
						 update epacctotal set credit= isnull(credit,0)+@newcosto-@oldcosto where idepacc=@idepacc and ayear=@yentry
					end
				end

		end	
		if (@flagaccountusage & 1)<>0 begin
		if (isnull(@oldidepacc,0) <> isnull(@idepacc,0))begin
					if (@oldidepacc is not null) update epacctotal set rateo= isnull(rateo,0)-@oldricavo where idepacc=@oldidepacc and ayear=@yentry
					if (@idepacc is not null) update epacctotal set rateo= isnull(rateo,0)+@newricavo where idepacc=@idepacc and ayear=@yentry
				end
				else begin
					if (@idepacc is not null and (@newricavo<>@oldricavo))  begin
						update epacctotal set rateo= isnull(rateo,0)+@newricavo-@oldricavo where idepacc=@idepacc and ayear=@yentry
					end
				end
		end
		
		if ( @flagaccountusage & 128 <> 0) begin
				if (isnull(@oldidepacc,0) <> isnull(@idepacc,0))begin
					if (@oldidepacc is not null) update epacctotal set revenue= isnull(revenue,0)-@oldricavo where idepacc=@oldidepacc and ayear=@yentry
					if (@idepacc is not null) update epacctotal set revenue= isnull(revenue,0)+@newricavo where idepacc=@idepacc and ayear=@yentry
				end
				else begin
					if (@idepacc is not null and (@newricavo<>@oldricavo ))  begin
						update epacctotal set revenue= isnull(revenue,0)+@newricavo-@oldricavo where idepacc=@idepacc and ayear=@yentry
					end
				end
		end
		else begin
			set @newcosto=0
		end

		SELECT		@parentidepacc = epacc.paridepacc FROM epacc 		WHERE epacc.idepacc = @idepacc
		
		EXECUTE trg_yearbalance 'I', @ybalance OUTPUT	

		SELECT @parent_oldidepacc = paridepacc FROM epacc WHERE idepacc = @oldidepacc

		IF ( @yentry = @ybalance)
			BEGIN
				if (  @oldidepacc is null and @idepacc is not null) --Stiamo collegando l'accertamento  = Insert
					Begin
							execute trg_updatearrearsepacc @idepacc,@yentry, 2,@idacc, @idupb,@newcosto,null,null,null,null
							execute trg_updatearrearsepacc @parentidepacc,@yentry, 1, @idacc, @idupb,@newcosto,null,null,null,null
					End
				if(  @oldidepacc is not null and @idepacc is null) --Stiamo Scollegando l'accertamento = Delete
					Begin
						EXECUTE trg_evaluatearrearsepacc @oldidepacc, @yentry
						EXECUTE trg_evaluatearrearsepacc @parent_oldidepacc,@yentry
					End

				if (  @oldidepacc = @idepacc) 
						and
						(@newamount <> -@oldamount OR
						(@newamount IS NULL AND @oldamount IS NOT NULL) OR
						(@newamount IS NOT NULL AND @oldamount IS NULL))
					Begin
						EXECUTE trg_evaluatearrearsepacc @idepacc, @yentry
						EXECUTE trg_evaluatearrearsepacc @parentidepacc,@yentry
					End
			END



END

	declare @diff decimal(19,2)
	set @diff = isnull(@newamount,0) + isnull(@oldamount,0)
	update entrytotal set amount = isnull(amount,0) + isnull(@diff,0) where yentry =@yentry and nentry = @nentry
	
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
