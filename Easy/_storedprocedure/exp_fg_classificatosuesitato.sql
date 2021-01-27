
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_fg_classificatosuesitato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_fg_classificatosuesitato]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure exp_fg_classificatosuesitato(
        @idsorkind int,
	@start datetime, 
	@stop datetime,
        @kind char(1)
) 
as 
begin
declare @impegno varchar(20)
select  @impegno  = description from expensephase where nphase = 1

declare @pagamento varchar(20)
select  @pagamento = description from expensephase where nphase = (select max(nphase) from expensephase)

declare @Accertamento varchar(20)
select  @Accertamento  = description from incomephase where nphase = 1

declare @incasso varchar(20)
select  @incasso = description from incomephase where nphase = (select max(nphase) from incomephase)

IF(@kind = 'D')
Begin
        select 
                payment.npay as 'N.Mandato',
                @pagamento +' '+ convert(varchar(20),expense.nmov) + '/'+  convert(varchar(20),expense.ymov)  as 'Pagamento',
                @impegno +' '+ convert(varchar(20),exp2.nmov) + '/'+  convert(varchar(20),exp2.ymov)  as 'Impegno',
                expense.description as 'Descr.Pagamento',
                fin.codefin as 'Bilancio',
                upb.codeupb as 'Cod.UPB',
                upb.title as 'UPB',
        	sortingkind.description as 'Tipo class.',
        	sorting.sortcode as 'Codice class.', 
        	sorting.description as 'Classificazione', 
        	banktransactionsorting.amount as 'Importo',
                banktransaction.transactiondate as 'Esitazione'
         from banktransaction 
        join banktransactionsorting  
                on banktransaction.nban = banktransactionsorting.nban
                and banktransaction.yban = banktransactionsorting.yban
        join sorting 
                ON sorting.idsor = banktransactionsorting.idsor
        join sortingkind 
                ON sortingkind.idsorkind = sorting.idsorkind
        join expense
                on banktransaction.idexp = expense.idexp
        join payment
                on banktransaction.kpay = payment.kpay
        join fin
                on payment.idfin = fin.idfin
        JOIN expenseyear
        	ON expense.idexp = expenseyear.idexp AND expense.ymov = expenseyear.ayear
        join upb
                on expenseyear.idupb = upb.idupb
        join expenselink
                ON expenselink.idchild = expense.idexp and expenselink.nlevel = 1
        join expense exp2
                ON exp2.idexp = expenselink.idparent
        where sorting.idsorkind = @idsorkind
                AND banktransaction.kind = 'D'
                AND banktransaction.transactiondate between @start and @stop
        ORDER BY banktransaction.transactiondate
End
Else
Begin
        select 
                proceeds.npro as 'N.Reversale',
                @incasso +' '+ convert(varchar(20),income.nmov) + '/'+  convert(varchar(20),income.ymov)  as 'Incasso',
                @Accertamento +' '+ convert(varchar(20),inc2.nmov) + '/'+  convert(varchar(20),inc2.ymov)  as 'Accertamento',
                income.description as 'Descr.Incasso',
                fin.codefin as 'Bilancio',
                upb.codeupb as 'Cod.UPB',
                upb.title as 'UPB',
        	sortingkind.description as 'Tipo class.',
        	sorting.sortcode as 'Codice class.', 
        	sorting.description as 'Classificazione', 
        	banktransactionsorting.amount as 'Importo',
                banktransaction.transactiondate as 'Esitazione'
         from banktransaction 
        join banktransactionsorting  
                on banktransaction.nban = banktransactionsorting.nban
                and banktransaction.yban = banktransactionsorting.yban
        join sorting 
                ON sorting.idsor = banktransactionsorting.idsor
        join sortingkind 
                ON sortingkind.idsorkind = sorting.idsorkind
        join income
                on banktransaction.idinc = income.idinc
        join proceeds
                on banktransaction.kpro = proceeds.kpro
        join fin
                on proceeds.idfin = fin.idfin
        JOIN incomeyear
        	ON income.idinc = incomeyear.idinc AND income.ymov =incomeyear.ayear
        join upb
                on incomeyear.idupb = upb.idupb
        join incomelink
                ON incomelink.idchild = income.idinc and incomelink.nlevel = 1
        join income inc2
                ON inc2.idinc = incomelink.idparent
        where sorting.idsorkind = @idsorkind
                AND banktransaction.kind = 'C'
                AND banktransaction.transactiondate between @start and @stop
        ORDER BY banktransaction.transactiondate

End

end




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
