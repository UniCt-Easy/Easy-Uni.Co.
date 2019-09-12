if exists (select * from dbo.sysobjects where id = object_id(N'[ct_get_countincome_asscred]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure ct_get_countincome_asscred
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE      PROCEDURE ct_get_countincome_asscred(
	@idupb varchar(36),
	@idfin_expense int,
	@n int OUTPUT
)

as BEGIN

declare @idsor01 int
select @idsor01 = idsor01 from upb where idupb = @idupb

select @n= count(*)
from ct_asscred C 
join ct_asscreddetail D
	on C.idct_asscred = D.idct_asscred
join fin F
	on C.idfin_income = F.idfin
join sorting S
	on S.idsor = C.idsor 
join sortinglink
	on sortinglink.idparent = S.idsor 
join sortingtranslation 
	on sortinglink.idchild = sortingtranslation.idsortingchild --> SICUR_UPB_2016
where  D.idfin_expense = @idfin_expense
		and sortingtranslation.idsortingmaster = @idsor01 --> SICUR_UPB



END

GO
