if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_wageaddition_trasfsingle]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_wageaddition_trasfsingle]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE  procedure closeyear_wageaddition_trasfsingle(
	@esercizio int,
	@ycon_single int, --esercizio del contratto
	@ncon_single int --numero del contratto
	)
 as
begin
	declare @maxfasespesa int
	select @maxfasespesa = max(nphase) from expensephase
	declare @eserccontratto int
	declare @numcontratto int
	declare @compensolordo decimal(19,2)
	declare @curscontratto cursor
	set @curscontratto = cursor for select ycon, ncon, feegross 
	from wageaddition
	 where ycon<=@esercizio 
	 and ycon = @ycon_single and ncon = @ncon_single
	 and not exists (select * from wageadditionyear 
				where wageaddition.ycon=wageadditionyear.ycon and wageaddition.ncon=wageadditionyear.ncon and ayear=@esercizio+1)
	open @curscontratto
	fetch next from @curscontratto into @eserccontratto, @numcontratto, @compensolordo
	while @@fetch_status = 0 begin
		declare @idspesa varchar(40)
		declare @importo decimal(19,2)
		declare @amount decimal(19,2)
		declare @cursspesa cursor
		set @cursspesa = cursor for 
			SELECT expense.idexp, isnull(expenseyear_starting.amount, 0)
			FROM expensewageaddition
			JOIN expenselink
				ON expenselink.idparent = expensewageaddition.idexp
			JOIN expense
				ON expense.idexp = expenselink.idchild 
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = expense.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0)
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE ycon=@eserccontratto AND ncon=@numcontratto AND expense.nphase=@maxfasespesa
		open @cursspesa
		fetch next from @cursspesa into @idspesa, @amount
		set @importo = 0;
		while @@fetch_status = 0 begin
			select @importo = @importo + @amount + isnull(sum(amount), 0) from expensevar where idexp=@idspesa and isnull(autokind,0)<> 4 --riten
			fetch next from @cursspesa into @idspesa, @amount
		end
		declare @residuo decimal (19,2)
		set @residuo = @compensolordo - @importo
		if (@residuo>0) begin
			declare @codicedurata varchar(20)
			declare @codicequalifica varchar(20)
			declare @codiceorario varchar(2)
			select 
				@codicedurata = wageadditionyear.idcontractlength, 
				@codicequalifica = wageadditionyear.idposition, 
				@codiceorario = wageadditionyear.idworkingtime
				from wageadditionyear 
				where wageadditionyear.ayear=@esercizio and wageadditionyear.ycon=@eserccontratto and wageadditionyear.ncon=@numcontratto
			insert into wageadditionyear (ayear, ycon, ncon, idcontractlength, idposition, idworkingtime, lt, ct, cu, lu)
				values (@esercizio+1, @eserccontratto, @numcontratto, @codicedurata, @codicequalifica, @codiceorario, getdate(), getdate(), 'closeyear_wageaddition_trasfsingle', 'closeyear_wageaddition_trasfsingle')
		end
		fetch next from @curscontratto into @eserccontratto, @numcontratto, @compensolordo
	end
end




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

