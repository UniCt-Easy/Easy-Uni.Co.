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

