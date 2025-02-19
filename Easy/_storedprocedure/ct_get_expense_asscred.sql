
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
