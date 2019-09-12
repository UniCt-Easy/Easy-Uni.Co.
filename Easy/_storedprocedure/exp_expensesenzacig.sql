if exists (select * from dbo.sysobjects where id = object_id(N'[exp_expensesenzacig]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_expensesenzacig]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE exp_expensesenzacig (
	@ayear int,
	@stop datetime,
	@idreg int,
	@idupb varchar(36),
	@codefin varchar(50)
) 
AS 

-- Fase in cui indichiamo il CIG
DECLARE @expenseregphase	tinyint
SELECT @expenseregphase = expenseregphase FROM  uniconfig

BEGIN

select  	
	E.ymov as 'Eserc.Mov.',
	E.nmov as 'N. Mov', 
	E.description as 'Descrizione'
from expense E
join expenseyear EY
	on EY.idexp = E.idexp
left outer join fin F
	on F.idfin = EY.idfin
left outer join expensemandate EM
	on EM.idexp = EY.idexp
left outer join mandate M
	on M.idmankind = EM.idmankind and M.yman = EM.yman and M.nman = EM.nman
where EY.ayear = @ayear
	and E.nphase = @expenseregphase
	and E.adate <= @stop
	and (@codefin is null or F.codefin like @codefin)
	and (@idreg is null or E.idreg = @idreg)
	AND EY.idupb like @idupb	
	AND E.cigcode is null
	AND M.cigcode is null
order by E.ymov, E.nmov, E.description

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





