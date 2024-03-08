
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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



ALTER   procedure exp_fg_riempibanktransactionsorting(@ayear int) 
as
begin
	declare @oggi datetime
	set @oggi=getdate()
--se banktrans.amount= quello del mov. di spesa---> allora copiamo tutte le class. cosi come sono
	insert into banktransactionsorting
		(yban, nban, idsor, amount, ct, cu, lt, lu)
		select banktransaction.yban, banktransaction.nban, 
			expensesorted.idsor,
			sum(expensesorted.amount),
			@oggi, 'SP',  @oggi, 'SP'
		from banktransaction
		join expensetotal on expensetotal.ayear=@ayear and expensetotal.idexp=banktransaction.idexp
		join expensesorted on expensesorted.idexp=banktransaction.idexp
		where banktransaction.amount=expensetotal.curramount
		and yban=@ayear
		and not exists (select * 
			from banktransactionsorting
			where banktransaction.yban=banktransactionsorting.yban
			and banktransaction.nban=banktransactionsorting.nban)
		group by banktransaction.yban, banktransaction.nban, expensesorted.idsor

--vado a classificare i restanti movimenti bancari a debito

--riempio una tabella con gli nban relativi ai movimenti di spesa con importo corrente>0 che non sono stati ancora classificati
	select banktransaction.nban, banktransaction.idexp, banktransaction.amount
		into #transazspesa
		from banktransaction
		join expensetotal on expensetotal.ayear=@ayear and expensetotal.idexp=banktransaction.idexp
		where curramount<>0
		and yban=@ayear
		and not exists (select * 
			from banktransactionsorting
			where banktransaction.yban=banktransactionsorting.yban
			and banktransaction.nban=banktransactionsorting.nban)

	declare @idexp int
	declare @idsor varchar(32)
	declare @idsorkind varchar(20)

	declare @cursoreclassspesa cursor 
	set @cursoreclassspesa = cursor for 
		select distinct idsorkind, expensesorted.idsor, #transazspesa.idexp 
		from #transazspesa
		join expensesorted 
			on expensesorted.idexp=#transazspesa.idexp
			and expensesorted.ayear=@ayear
		join sorting on sorting.idsor=expensesorted.idsor

	open @cursoreclassspesa
	fetch next from @cursoreclassspesa into @idsorkind, @idsor, @idexp

	while @@fetch_status=0 
	begin
		--classifico i movimenti bancari basandomi sulla classificazione dei movimenti di spesa
		declare @curramountexp dec(19,2)
		select @curramountexp=isnull(curramount,0) from expensetotal where ayear=@ayear and idexp=@idexp

		declare @giaclassificatoexp_bts dec(19,2)
		select @giaclassificatoexp_bts=isnull(sum(banktransactionsorting.amount),0)
			from banktransactionsorting
			join banktransaction 
				on banktransaction.yban=banktransactionsorting.yban
				and banktransaction.nban=banktransactionsorting.nban
			where banktransactionsorting.idsor=@idsor
			and banktransactionsorting.yban=@ayear
			and banktransaction.idexp=@idexp

		--faccio la differenza tra quanto classificato su spesa e quanto sui movimenti bancari
		declare @daclassificare_es_bts dec(19,2)
		select @daclassificare_es_bts = isnull(sum(amount),0) - @giaclassificatoexp_bts
			from expensesorted
			where idexp=@idexp
			and idsor=@idsor
			and ayear=@ayear

		-- (classificato su spesa) / (importo corrente di spesa) * (classificato su spesa - classificato su banca)
		insert into banktransactionsorting
			(yban, nban, idsor, amount, ct, cu, lt, lu)
			select @ayear, nban, @idsor,
				round(amount * @daclassificare_es_bts / @curramountexp, 2, 1),
				@oggi, 'SP',  @oggi, 'SP'
			from #transazspesa
			where idexp=@idexp

		fetch next from @cursoreclassspesa into @idsorkind, @idsor, @idexp
	end

	drop table #transazspesa

--poichè prima ho fatto delle proporzioni, posso aver sgarrato di qualche centesimo
--cerco di sistemare il tutto

--comincio col riempire una tabella dei residui 
--(quanto c'è ancora da classificare per ogni yban, nban, idsorkind, idsor di banktransactionsoring rispetto ad expensesorted)
	select banktransaction.idexp, idsorkind, banktransactionsorting.idsor, 
		classificatosubanca=sum(banktransactionsorting.amount), 
		classificatosuspesa=(select sum(expensesorted.amount) from expensesorted 
			where idexp=banktransaction.idexp and idsor=banktransactionsorting.idsor)
		into #situazionespesa
		from banktransaction 
		join banktransactionsorting 
			on banktransaction.yban=banktransactionsorting.yban 
			and banktransaction.nban=banktransactionsorting.nban
		join sorting on sorting.idsor=banktransactionsorting.idsor
		group by banktransaction.idexp, sorting.idsorkind, banktransactionsorting.idsor

	declare @nban int
	declare @cursoreapprossimspesa cursor
	set @cursoreapprossimspesa = cursor for 
		select banktransaction.idexp, banktransaction.nban, #situazionespesa.idsorkind,
		banktransaction.amount
		- (select isnull(sum(bts.amount),0) 
			from banktransactionsorting bts
			join sorting on sorting.idsor = bts.idsor
			where bts.yban=banktransaction.yban
			and bts.nban=banktransaction.nban
			and sorting.idsorkind=#situazionespesa.idsorkind)
		from banktransaction
		join #situazionespesa
			on banktransaction.idexp=#situazionespesa.idexp
		where banktransaction.yban=@ayear
		and #situazionespesa.classificatosuspesa =
			(select isnull(sum(amount),0) from banktransaction bt where bt.idexp=banktransaction.idexp)
		and banktransaction.amount
			> (select isnull(sum(bts.amount),0) 
				from banktransactionsorting bts
				join sorting on sorting.idsor = bts.idsor
				where bts.yban=banktransaction.yban
				and bts.nban=banktransaction.nban
				and sorting.idsorkind=#situazionespesa.idsorkind)
		and #situazionespesa.classificatosuspesa > #situazionespesa.classificatosubanca

	open @cursoreapprossimspesa

	declare @residuospesa dec(19,2)

	fetch next from @cursoreapprossimspesa into @idexp, @nban, @idsorkind, @residuospesa
	while @@fetch_status=0
	begin
		--per ogni movimento bancario mi cerco l'idsor su cui andare ad aggiungere eventuali centesimi sbagliati nel calcolo di prima
		--e aggiungo ciò che manca
		while @residuospesa>0
		begin
			declare @tappo dec(19,2)

			select @idsor=#situazionespesa.idsor, 
				@tappo=classificatosuspesa-classificatosubanca
				from #situazionespesa
				where idexp=@idexp and idsorkind=@idsorkind 
					and (classificatosuspesa-classificatosubanca)
					= (select max(classificatosuspesa-classificatosubanca) from #situazionespesa r2
					where r2.idexp=#situazionespesa.idexp
					and r2.idsorkind=#situazionespesa.idsorkind)

			if (@residuospesa<@tappo) set @tappo = @residuospesa

			update #situazionespesa 
				set classificatosubanca = classificatosubanca + @tappo
				where idexp=@idexp
				and idsorkind=@idsorkind
				and idsor=@idsor
	
			set @residuospesa = @residuospesa - @tappo

			update banktransactionsorting set 
				amount = amount + @tappo, lt=@oggi
				where yban=@ayear
				and nban=@nban
				and idsor=@idsor

			if @tappo<=0.0
			begin
				select 'errore nell''approssimazione spesa', * from #situazionespesa
					where idexp=@idexp
					and idsorkind=@idsorkind
					and idsor=@idsor
				return
			end
		end
		fetch next from @cursoreapprossimspesa into @idexp, @nban, @idsorkind, @residuospesa
	end

	drop table #situazionespesa

--se banktrans.amount = quello del mov. di entrata---> allora copiamo tutte le class. cosi come sono
	insert into banktransactionsorting
		(yban, nban, idsor, amount, ct, cu, lt, lu)
		select banktransaction.yban, banktransaction.nban, 
			incomesorted.idsor,
			sum(incomesorted.amount),
			@oggi, 'SP',  @oggi, 'SP'
		from banktransaction
		join incometotal on incometotal.ayear=@ayear and incometotal.idinc=banktransaction.idinc
		join incomesorted on incomesorted.idinc=banktransaction.idinc
		where banktransaction.amount=incometotal.curramount
		and yban=@ayear
		and not exists (select * 
			from banktransactionsorting
			where banktransaction.yban=banktransactionsorting.yban
			and banktransaction.nban=banktransactionsorting.nban)
		group by banktransaction.yban, banktransaction.nban, incomesorted.idsor

	select banktransaction.nban, banktransaction.idinc, banktransaction.amount
		into #transazentrata
		from banktransaction
		join incometotal on incometotal.ayear=@ayear and incometotal.idinc=banktransaction.idinc
		where curramount<>0
		and yban=@ayear
		and not exists (select * 
			from banktransactionsorting
			where banktransaction.yban=banktransactionsorting.yban
			and banktransaction.nban=banktransactionsorting.nban)

	declare @idinc int

	declare @cursoreclassentrata cursor 
	set @cursoreclassentrata = cursor for 
		select distinct idsorkind, incomesorted.idsor, #transazentrata.idinc 
		from #transazentrata
		join incomesorted 
			on incomesorted.idinc=#transazentrata.idinc
			and incomesorted.ayear=@ayear
		join sorting on sorting.idsor = incomesorted.idsor

	open @cursoreclassentrata
	fetch next from @cursoreclassentrata into @idsorkind, @idsor, @idinc

	while @@fetch_status=0 
	begin
		declare @curramountinc dec(19,2)
		select @curramountinc=isnull(curramount,0) from incometotal where ayear=@ayear and idinc=@idinc

		declare @giaclassificatoinc_bts dec(19,2)
		select @giaclassificatoinc_bts=isnull(sum(banktransactionsorting.amount),0)
			from banktransactionsorting
			join banktransaction 
				on banktransaction.yban=banktransactionsorting.yban
				and banktransaction.nban=banktransactionsorting.nban
			where banktransactionsorting.idsor=@idsor
			and banktransactionsorting.yban=@ayear
			and banktransaction.idinc=@idinc

		declare @daclassificare_is_bts dec(19,2)
		select @daclassificare_is_bts = isnull(sum(amount),0) - @giaclassificatoinc_bts
			from incomesorted
			where idinc=@idinc
			and idsor=@idsor
			and ayear=@ayear

		insert into banktransactionsorting
			(yban, nban, idsor, amount, ct, cu, lt, lu)
			select @ayear, nban, @idsor,
				round(amount * @daclassificare_is_bts / @curramountinc, 2, 1),
				@oggi, 'SP',  @oggi, 'SP'
			from #transazentrata
			where idinc=@idinc

		fetch next from @cursoreclassentrata into @idsorkind, @idsor, @idinc
	end

	drop table #transazentrata

--riempimento della tabella dei residui 
--(quanto c'è ancora da classificare per ogni yban, nban, idsorkind, idsor di banktransactionsoring rispetto ad incomesorted)
	select banktransaction.idinc, sorting.idsorkind, banktransactionsorting.idsor, 
		classificatosubanca=sum(banktransactionsorting.amount), 
		classificatosuentrata=(select sum(incomesorted.amount) from incomesorted 
			where idinc=banktransaction.idinc and idsor=banktransactionsorting.idsor)
		into #situazioneentrata
		from banktransaction 
		join banktransactionsorting 
			on banktransaction.yban=banktransactionsorting.yban 
			and banktransaction.nban=banktransactionsorting.nban
		join sorting on sorting.idsor=banktransactionsorting.idsor
		group by banktransaction.idinc, sorting.idsorkind, banktransactionsorting.idsor

	declare @cursoreapprossimentrata cursor
	set @cursoreapprossimentrata = cursor for 
		select banktransaction.idinc, banktransaction.nban, #situazioneentrata.idsorkind,
		banktransaction.amount
		- (select isnull(sum(bts.amount),0) 
			from banktransactionsorting bts
			join sorting on sorting.idsor = bts.idsor
			where bts.yban=banktransaction.yban
			and bts.nban=banktransaction.nban
			and sorting.idsorkind=#situazioneentrata.idsorkind)
		from banktransaction
		join #situazioneentrata
			on banktransaction.idinc=#situazioneentrata.idinc
		where banktransaction.yban=@ayear
		and #situazioneentrata.classificatosuentrata =
			(select isnull(sum(amount),0) from banktransaction bt where bt.idinc=banktransaction.idinc)
		and banktransaction.amount
			> (select isnull(sum(bts.amount),0) 
				from banktransactionsorting bts
				join sorting on sorting.idsor = bts.idsor
				where bts.yban=banktransaction.yban
				and bts.nban=banktransaction.nban
				and sorting.idsorkind=#situazioneentrata.idsorkind)
		and #situazioneentrata.classificatosuentrata > #situazioneentrata.classificatosubanca

	open @cursoreapprossimentrata

	declare @residuoentrata dec(19,2)

	fetch next from @cursoreapprossimentrata into @idinc, @nban, @idsorkind, @residuoentrata
	while @@fetch_status=0
	begin
		while @residuoentrata>0
		begin
			select @idsor=#situazioneentrata.idsor, 
				@tappo=classificatosuentrata-classificatosubanca
				from #situazioneentrata
				where idinc=@idinc and idsorkind=@idsorkind 
					and (classificatosuentrata-classificatosubanca)
					= (select max(classificatosuentrata-classificatosubanca) from #situazioneentrata r2
					where r2.idinc=#situazioneentrata.idinc
					and r2.idsorkind=#situazioneentrata.idsorkind)

			if (@residuoentrata<@tappo) set @tappo = @residuoentrata

			update #situazioneentrata 
				set classificatosubanca = classificatosubanca + @tappo
				where idinc=@idinc
				and idsorkind=@idsorkind
				and idsor=@idsor
	
			set @residuoentrata = @residuoentrata - @tappo

			update banktransactionsorting set 
				amount = amount + @tappo, lt=@oggi
				where yban=@ayear
				and nban=@nban
				and idsor=@idsor

			if @tappo<=0.0
			begin
				select 'errore nell''approssimazioneentrata', * from #situazioneentrata
					where idinc=@idinc
					and idsorkind=@idsorkind
					and idsor=@idsor
				return
			end
		end
		fetch next from @cursoreapprossimentrata into @idinc, @nban, @idsorkind, @residuoentrata
	end

	drop table #situazioneentrata

	select banktransactionsorting.yban as 'Anno', 
		banktransactionsorting.nban as 'N°trans.banc.', 
		sortingkind.description as 'Tipo class.', 
		sorting.sortcode as 'Codice class.', 
		sorting.description as 'Classificazione', 
		banktransactionsorting.amount as 'Importo',
		expense.nmov as 'Spesa',
		income.nmov as 'Entrata'
		from banktransactionsorting
		join sorting on sorting.idsor=banktransactionsorting.idsor
		join sortingkind on sortingkind.idsorkind=sorting.idsorkind
		join banktransaction on banktransaction.yban=banktransactionsorting.yban and banktransaction.nban=banktransactionsorting.nban
		left outer join expense on banktransaction.idexp=expense.idexp
		left outer join income on banktransaction.idinc=income.idinc
		where banktransactionsorting.lt=@oggi
		order by banktransactionsorting.yban, banktransactionsorting.nban
end




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

