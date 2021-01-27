
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


if exists (select * from dbo.sysobjects where id = object_id(N'[get_expense_toreset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure get_expense_toreset
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE      PROCEDURE get_expense_toreset(
	@ayear int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int,
	@escludifatture char(1)
)



as BEGIN
declare @nmaxphase int
select @nmaxphase = max(nphase) from expensephase

if( @escludifatture = 'N')
Begin
	select E.idexp, E.ymov, E.nmov, ET.curramount, R.title as registry, U.codeupb, F.codefin, E.description, P.kpay
	from expense e
	JOIN expensetotal ET  on ET.idexp=E.idexp 
	JOIN expenselast EL ON EL.idexp = E.idexp
	join payment P on P.kpay = El.kpay
	join expenseyear EY on E.ymov = EY.ayear and E.idexp = EY.idexp
	join registry R on R.idreg= E.idreg
	join upb U on EY.idupb = U.idupb
	join fin F on F.idfin = EY.idfin
	where e.ymov = @ayear	
		and ET.curramount >0	
		and E.nphase = @nmaxphase	
		AND EL.nbill is null
		and 
		(
			(select count(*) from  banktransaction b2
			where  P.kpay = b2.kpay and  b2.yban = @ayear)=0 
		or
			(select sum(b3.amount) from  banktransaction b3
			where  P.kpay = b3.kpay and  b3.yban = @ayear )=0
		)
End
Else
Begin
-- Esclude le contabilizzazioni di fatture
	select E.idexp, E.ymov, E.nmov, ET.curramount, R.title as registry, U.codeupb, F.codefin, E.description, P.kpay
		from expense e
		JOIN expensetotal ET  on ET.idexp=E.idexp 
		JOIN expenselast EL ON EL.idexp = E.idexp
		join payment P on P.kpay = El.kpay
		join expenseyear EY on E.ymov = EY.ayear and E.idexp = EY.idexp
		join registry R on R.idreg= E.idreg
		join upb U on EY.idupb = U.idupb
		join fin F on F.idfin = EY.idfin
		left outer join expenseinvoice ei on e.idexp = ei.idexp 
		where e.YMOV = @ayear	
			and EI.idexp is null	-- Solo pagamenti privi di contabilizzazioni
			and ET.curramount >0	
			and E.nphase = @nmaxphase	
			AND EL.nbill is null
			and 
			(
				(select count(*) from  banktransaction b2
				where  P.kpay = b2.kpay and  b2.yban = @ayear)=0 
			or
				(select sum(b3.amount) from  banktransaction b3
				where  P.kpay = b3.kpay and  b3.yban = @ayear )=0
			)
End

END

GO

