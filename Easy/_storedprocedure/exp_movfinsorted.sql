
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_movfinsorted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_movfinsorted
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE  PROCEDURE  exp_movfinsorted(
		@ayear int,
		@finpart char(1),
		@idsorkind int,
		@idsor01 int=null,
		@idsor02 int=null,
		@idsor03 int=null,
		@idsor04 int=null,
		@idsor05 int=null
)
as begin
--select * from sortingkind where nphaseincome is not null
--select * from sortingkind where nphaseexpense is not null
--exp_movfinsorted 2015, 'E', 6
--exp_movfinsorted 2015, 'S', 23
DECLARE @maxphase tinyint

if (@finpart = 'E')
begin
	SELECT @maxphase =  MAX(nphase) FROM incomephase
	select incomephase.description as 'Fase',
	ymov as 'Esercizio',
	nmov as 'Numero',
	fin.codefin as 'Cod Bilancio',
	fin.title as 'Voce Bilancio', 
	upb.codeupb as 'Code UPB',
	upb.title as 'UPB',
	attr01.sortcode+ ' ' + attr01.description  as 'Attr.',
	income.description as 'Descrizione Mov Fin.',
	incometotal.curramount as 'Importo corrente',
	registry.title as 'Anagrafica',
	sortingkind.codesorkind as 'Cod. Tipo Class.',
	sortingkind.description as 'Tipo Class.',
	sorting.sortcode as 'Cod. Class',
	sorting.description as 'Class',
	incomesorted.amount as 'Importo classificato', 
	proceeds.npro as 'Num. Reversale',
	proceedstransmission.nproceedstransmission as 'Num. Distinta Trasm.',
	proceedstransmission.transmissiondate as 'Data Distinta Trasm.',
	treasurer.description as 'Cassiere'
	from incomesorted
		join sorting on sorting.idsor=incomesorted.idsor
		join sortingkind on sortingkind.idsorkind = sorting.idsorkind
		join income on income.idinc = incomesorted.idinc 
		join registry on registry.idreg = income.idreg
		join incomephase on incomephase.nphase = income.nphase
		join incomelast on incomelast.idinc = incomesorted.idinc 
		join incometotal on incometotal.idinc = incomesorted.idinc and incometotal.ayear = @ayear
		join incomeyear  on incomeyear.idinc = incomesorted.idinc and incomeyear.ayear = @ayear
		join fin on fin.idfin=incomeyear.idfin
	join upb on incomeyear.idupb = upb.idupb
	left outer join proceeds on  proceeds.kpro = incomelast.kpro
	left outer join proceedstransmission on  proceeds.kproceedstransmission = proceedstransmission.kproceedstransmission
	left outer join treasurer on treasurer.idtreasurer = proceeds.idtreasurer
	left outer join sorting  as attr01 on attr01.idsor = upb.idsor01
	WHERE sorting.idsorkind = @idsorkind
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	order by income.ymov, income.nmov
end 
else
begin
	SELECT @maxphase =  MAX(nphase) FROM expensephase

	select expensephase.description as 'Fase',
	ymov as 'Esercizio',
	nmov as 'Numero',
	fin.codefin as 'Cod Bilancio',
	fin.title as 'Voce Bilancio', 
	upb.codeupb as 'Code UPB',
	upb.title as 'UPB',
    attr01.sortcode+ ' ' + attr01.description  as 'Attr.',
	expense.description as 'Descrizione Mov Fin.',
	expensetotal.curramount as 'Importo corrente',
	registry.title as 'Anagrafica',
	sortingkind.codesorkind as 'Cod. Tipo Class.',
	sortingkind.description as 'Tipo Class.',
	sorting.sortcode as 'Cod. Class',
	sorting.description as 'Class',
	expensesorted.amount as 'Importo classificato', 
	payment.npay as 'Num. Mandato',
	paymenttransmission.npaymenttransmission as 'Num. Distinta Trasm.',
	paymenttransmission.transmissiondate as 'Data Distinta Trasm.',
	treasurer.description as 'Cassiere'
	from expensesorted
	join sorting on sorting.idsor=expensesorted.idsor
	join sortingkind on sortingkind.idsorkind = sorting.idsorkind
	join expense on expensesorted.idexp=expense.idexp
	join registry on registry.idreg = expense.idreg
		join expensephase on expensephase.nphase = expense.nphase
		join expenselast on expenselast.idexp = expensesorted.idexp 
		join expensetotal on expensetotal.idexp = expensesorted.idexp and expensetotal.ayear = @ayear
		join expenseyear  on expenseyear.idexp = expensesorted.idexp and expenseyear.ayear = @ayear
		join fin on fin.idfin=expenseyear.idfin

	join upb on expenseyear.idupb  = upb.idupb 
	left outer join payment on payment.ypay = @ayear and payment.kpay = expenselast.kpay
	left outer join paymenttransmission on  payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission
	left outer join treasurer on treasurer.idtreasurer = payment.idtreasurer
	left outer join sorting  as attr01 on attr01.idsor = upb.idsor01
	WHERE sorting.idsorkind = @idsorkind
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	order by expense.ymov, expense.nmov
end

end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

