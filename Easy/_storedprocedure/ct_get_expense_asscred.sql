
if exists (select * from dbo.sysobjects where id = object_id(N'[ct_get_expense_asscred]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure ct_get_expense_asscred
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE      PROCEDURE ct_get_expense_asscred(
	@idupb varchar(36),
	@idfin_income int
)

as BEGIN

declare @codeupb varchar(50)
select @codeupb = codeupb from upb where idupb= @idupb

declare @entrata varchar(50)
select @entrata = codefin from fin where idfin = @idfin_income

declare @idsor01 int
select @idsor01 = idsor01 from upb where idupb = @idupb

-- In ct_asscred troviamo un padre di SICUR_UPB_2016
-- sortingtranslation troviamo l'associazione tra SICUR_UPB -> SICUR_UPB_2016
select D.idfin_expense, D.quota,F.codefin  as 'Spesa' , @codeupb as 'UPB' ,@entrata as 'Entrata'
from ct_asscred C 
join ct_asscreddetail D
	on C.idct_asscred = D.idct_asscred
join fin F
	on D.idfin_expense = F.idfin
join sorting S
	on S.idsor = C.idsor 
join sortinglink
	on sortinglink.idparent = S.idsor 
join sortingtranslation 
	on sortinglink.idchild = sortingtranslation.idsortingchild --> SICUR_UPB_2016
where  C.idfin_income = @idfin_income
	and sortingtranslation.idsortingmaster = @idsor01 --> SICUR_UPB


END

GO