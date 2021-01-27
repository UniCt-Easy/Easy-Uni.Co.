
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_entrydetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_entrydetail]
GO

--setuser 'amministrazione'
--setuser 'amm'
create        TRIGGER [trigger_i_entrydetail] ON [entrydetail] FOR INSERT
AS BEGIN
	DECLARE @idepexp int
	DECLARE @idepacc int
	DECLARE @yentry int
	DECLARE @nentry int
	
	DECLARE @lu varchar(64)
	DECLARE @lt datetime
	DECLARE @nphase tinyint
	DECLARE @parent_nphase tinyint

	DECLARE @idacc  varchar(38)
	DECLARE @idupb varchar(36)
	DECLARE @parentidepexp int
	DECLARE @parentidepacc int
	DECLARE @costo decimal(19,2)
	DECLARE @ricavo decimal(19,2)
	DECLARE @amount decimal(19,2)
	DECLARE @ybalance int	

	declare @flagaccountusage int
	
	SELECT
		@yentry = yentry, 
		@nentry = nentry, 
		@idepexp = idepexp, 
		@idepacc = idepacc, 
		@costo = -amount,
		@ricavo = amount,
		@amount = amount,
		@idupb = idupb,
		@idacc = idacc,
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

	IF ((@idepexp is not null) and (@flagaccountusage & 4096+256+64+16+2+32)<>0 )	--costo+riserva+debito
	BEGIN		
		
		if (@flagaccountusage & 16)<>0 begin --conto di debito
			update epexptotal set debit= isnull(debit,0)+isnull(@ricavo,0) where idepexp=@idepexp and ayear=@yentry
		end
		if (@flagaccountusage & 32)<>0 begin  --conto di credito, riduco il debito
			update epexptotal set debit= isnull(debit,0)+isnull(@costo,0) where idepexp=@idepexp and ayear=@yentry
		end

		if (@flagaccountusage & 2)<>0 begin	--ratei passivi
			update epexptotal set rateo= isnull(rateo,0)+isnull(@costo,0) where idepexp=@idepexp and ayear=@yentry
		end
		
		if (@flagaccountusage & 4096)<>0 begin     --accantonamento
			update epexptotal set accantonamento= isnull(accantonamento,0)+isnull(@costo,0) where idepexp=@idepexp and ayear=@yentry					
		end

		if (@flagaccountusage & (256+64))<>0 begin	--costo o immobilizzazione
			update epexptotal set cost= isnull(cost,0)+isnull(@costo,0) where idepexp=@idepexp and ayear=@yentry					
		end
		else begin
			set @ricavo=0		-- non c'è costo
		end 

		
		SELECT	@parentidepexp = epexp.paridepexp		FROM epexp	WHERE epexp.idepexp = @idepexp	


		EXECUTE trg_yearbalance 'E', @ybalance OUTPUT	
		
		IF ( @yentry = @ybalance and @idepexp is not null) 
		BEGIN
			--non è incarico di questo trigger fornire i dati per le previsioni pluriennali			

			--le scritture sui conti di costo passano l'importo giusto, ossia negativo se in dare e positivo se in avere
			if (@parentidepexp is not null) begin
					execute trg_updatearrearsepexp @idepexp,		@yentry, 2, @idacc, @idupb,@ricavo,null,null,null,null
					execute trg_updatearrearsepexp @parentidepexp,	@yentry, 1, @idacc, @idupb,@ricavo,null,null,null,null
			end
			else begin
					execute trg_updatearrearsepexp @idepexp,		@yentry, 1, @idacc, @idupb,@ricavo,null,null,null,null
			end
		END
		
		

	END

IF ((@idepacc is not null) and (@flagaccountusage & (128+32+1+16))<>0 )	--ricavo+credito
BEGIN
		if (@flagaccountusage & 16)<>0 begin --conto di debito
			update epacctotal set credit= isnull(credit,0)+isnull(@ricavo,0) where idepacc=@idepacc and ayear=@yentry
		end
			
		if (@flagaccountusage & 32)<>0 begin	--credito
			update epacctotal set credit= isnull(credit,0)+isnull(@costo,0) where idepacc=@idepacc and ayear=@yentry
		end

		if (@flagaccountusage & 1)<>0 begin   --rateo attivo
			update epacctotal set rateo= isnull(rateo,0)+isnull(@ricavo,0) where idepacc=@idepacc and ayear=@yentry
		end
						
		if (@flagaccountusage & 128)<>0 begin	--ricavo		
			update epacctotal set revenue= isnull(revenue,0)+isnull(@ricavo,0) where idepacc=@idepacc and ayear=@yentry		
		end
		else	 begin
			set @costo=0		-- non c'è ricavo
		end 


		SELECT	@parentidepacc = epacc.paridepacc 	from  epacc		WHERE epacc.idepacc = @idepacc	

		EXECUTE trg_yearbalance 'I', @ybalance OUTPUT	
		IF ( @yentry = @ybalance and @idepacc is not null)
		BEGIN
		
		--le scritture sui conti di ricavo passano l'importo cambiato di segno, ossia negativo se in avere e positivo se in dare
				--non è incarico di questo trigger fornire i dati per le previsioni pluriennali
				if (@parentidepacc is not null) begin
					execute trg_updatearrearsepacc @idepacc,		@yentry, 2, @idacc, @idupb,@costo,null,null,null,null
					execute trg_updatearrearsepacc @parentidepacc,	@yentry, 1, @idacc, @idupb,@costo,null,null,null,null
				end
				else begin
					execute trg_updatearrearsepacc @idepacc,		@yentry, 1, @idacc, @idupb,@costo,null,null,null,null
				end
		END

		
END

update entrytotal set amount = isnull(amount,0) + isnull(@amount,0) where yentry =@yentry and nentry = @nentry

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
