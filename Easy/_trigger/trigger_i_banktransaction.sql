SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_banktransaction]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_banktransaction]
go

CREATE TRIGGER [trigger_i_banktransaction]
   ON [banktransaction] FOR insert  
AS 
BEGIN
	SET NOCOUNT ON;

	declare @kind char(1)
	declare @iddoc int
	declare @kdoc int
	declare @idmov int
	declare @amount decimal(19,2)
	declare @nbill decimal(19,2)
	declare @yban int
	declare @nban int
	declare @totsub int

	select  @yban=yban,@nban=nban,
			@kind=kind,
			@iddoc=case when kind='D' then idpay else idpro end,
			@kdoc=case when kind='D' then kpay else kpro end,
			@idmov=case when kind='D' then idexp else idinc end,
			@nbill=nbill,
			@amount=amount from inserted

	if @idmov is not null  return

	if (@kind='D')begin

		select @idmov=min(EL.idexp) from expenselast EL			
			where el.kpay=@kdoc and el.idpay=@iddoc

		if (@idmov is null) begin
			select @totsub=count(*) from payment_bank where kpay=@kdoc
			if (@totsub=1) begin
				--sistema @iddoc a scanso di equivoci
				select @iddoc= idpay  from payment_bank where kpay=@kdoc

				--riprova a valorizzare @idmov
				select @idmov=min(EL.idexp) from expenselast EL
				where el.kpay=@kdoc and el.idpay=@iddoc
			end
		end
		update banktransaction set idexp=@idmov where yban=@yban and nban=@nban

	end
	else 
	begin
		select @idmov=min(EL.idinc) from incomelast EL
				where el.kpro=@kdoc and el.idpro=@iddoc

		if (@idmov is null) begin
				select @totsub=count(*) from proceeds_bank where kpro=@kdoc
				if (@totsub=1) begin
					--sistema @iddoc a scanso di equivoci
					select @iddoc= idpro  from proceeds_bank where kpro=@kdoc

					--riprova a valorizzare @idmov
					select @idmov=min(EL.idinc) from incomelast EL
					where el.kpro=@kdoc and el.idpro=@iddoc
				end
			end

		update banktransaction set idinc=@idmov where yban=@yban and nban=@nban

	end

	


END
GO
