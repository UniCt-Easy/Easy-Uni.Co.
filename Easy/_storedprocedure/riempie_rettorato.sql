SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

ALTER  procedure exp_fg_riempiebanktransactionsorting (
	@idsorkind varchar(20),
	@start datetime, 
	@stop datetime) 
as
begin
	select banktransaction.yban, banktransaction.nban,
		sortingtranslation.idsortingmaster,
		banktransaction.idexp, amount=sum(expensesorted.amount)
		into #tabspesa
		from banktransaction
		join expensesorted 
			on banktransaction.idexp=expensesorted.idexp
		join sortingtranslation 
			on sortingtranslation.sortingkindchild=expensesorted.idsorkind
			and sortingtranslation.idsortingchild=expensesorted.idsor
		where sortingtranslation.sortingkindmaster=@idsorkind
		and banktransaction.transactiondate between @start and @stop
		and (select isnull(sum(amount),0) from banktransactionsorting
			where banktransaction.yban=banktransactionsorting.yban
			and banktransaction.nban=banktransactionsorting.nban
			and idsorkind=@idsorkind)<>banktransaction.amount
		group by banktransaction.yban, 
		banktransaction.nban,
		sortingtranslation.idsortingmaster,
		banktransaction.idexp
	
	insert into banktransactionsorting 
		(yban, nban, idsorkind, idsor, amount, ct, cu, lt, lu)
		select #tabspesa.yban, #tabspesa.nban, @idsorkind, idsortingmaster, 
			amount 
			* (--classificato su spesa
				(select isnull(amount,0) from banktransaction t2 
					where t2.yban=#tabspesa.yban and t2.nban=#tabspesa.nban)
			- --gia classificato su transazione	
				(select isnull(sum(amount),0) from banktransactionsorting t2 
					where t2.yban=#tabspesa.yban and t2.nban=#tabspesa.nban and idsorkind=@idsorkind)
			) / --classificato su spesa
				(select isnull(sum(amount),0) from #tabspesa t2 
				where t2.yban=#tabspesa.yban and t2.nban=#tabspesa.nban),
			getdate(), 'SP', getdate(), 'SP'
		from #tabspesa
		where (select isnull(sum(amount),0) from #tabspesa t2 where t2.yban=#tabspesa.yban and t2.nban=#tabspesa.nban)<>0


	update banktransactionsorting
		set amount = (select isnull(amount,0) 
				from banktransaction 
				where yban=banktransactionsorting.yban and nban=banktransactionsorting.nban)
			- isnull((select sum(amount) 
				from banktransactionsorting b2
				where b2.yban=banktransactionsorting.yban
				and b2.nban=banktransactionsorting.nban
				and b2.idsorkind=@idsorkind
				and b2.idsor<>banktransactionsorting.idsorkind),0)
		from #tabspesa
		where banktransactionsorting.yban=#tabspesa.yban
		and banktransactionsorting.nban=#tabspesa.nban
		and idsorkind=@idsorkind
		and idsor=(select max(idsorkind) from banktransactionsorting b2 
			where b2.yban=banktransactionsorting.yban 
			and b2.nban=banktransactionsorting.nban
			and b2.idsorkind=banktransactionsorting.idsorkind)

	drop table #tabspesa

	select banktransaction.yban, banktransaction.nban,
		sortingtranslation.idsortingmaster,
		banktransaction.idinc, amount=sum(incomesorted.amount)
		into #tabentrata
		from banktransaction
		join incomesorted 
			on banktransaction.idinc=incomesorted.idinc
		join sortingtranslation 
			on sortingtranslation.sortingkindchild=incomesorted.idsorkind
			and sortingtranslation.idsortingchild=incomesorted.idsor
		where sortingtranslation.sortingkindmaster=@idsorkind
		and banktransaction.transactiondate between @start and @stop
		and (select isnull(sum(amount),0) from banktransactionsorting
			where banktransaction.yban=banktransactionsorting.yban
			and banktransaction.nban=banktransactionsorting.nban
			and idsorkind=@idsorkind)<>banktransaction.amount
		group by banktransaction.yban, 
		banktransaction.nban,
		sortingtranslation.idsortingmaster,
		banktransaction.idinc
	
	insert into banktransactionsorting 
		(yban, nban, idsorkind, idsor, amount, ct, cu, lt, lu)
		select #tabentrata.yban, #tabentrata.nban, @idsorkind, idsortingmaster, 
			amount 
			* (--classificato su entrata
				(select isnull(amount,0) from banktransaction t2 
					where t2.yban=#tabentrata.yban and t2.nban=#tabentrata.nban)
			- --gia classificato su transazione	
				(select isnull(sum(amount),0) from banktransactionsorting t2 
					where t2.yban=#tabentrata.yban and t2.nban=#tabentrata.nban and idsorkind=@idsorkind)
			) / --classificato su entrata
				(select isnull(sum(amount),0) from #tabentrata t2 
				where t2.yban=#tabentrata.yban and t2.nban=#tabentrata.nban),
			getdate(), 'SP', getdate(), 'SP'
		from #tabentrata
		where (select isnull(sum(amount),0) from #tabentrata t2 where t2.yban=#tabentrata.yban and t2.nban=#tabentrata.nban)<>0


	update banktransactionsorting
		set amount = (select isnull(amount,0) 
				from banktransaction 
				where yban=banktransactionsorting.yban and nban=banktransactionsorting.nban)
			- isnull((select sum(amount) 
				from banktransactionsorting b2
				where b2.yban=banktransactionsorting.yban
				and b2.nban=banktransactionsorting.nban
				and b2.idsorkind=@idsorkind
				and b2.idsor<>banktransactionsorting.idsorkind),0)
		from #tabentrata
		where banktransactionsorting.yban=#tabentrata.yban
		and banktransactionsorting.nban=#tabentrata.nban
		and idsorkind=@idsorkind
		and idsor=(select max(idsorkind) from banktransactionsorting b2 
			where b2.yban=banktransactionsorting.yban 
			and b2.nban=banktransactionsorting.nban
			and b2.idsorkind=banktransactionsorting.idsorkind)

	drop table #tabentrata

end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

