
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



if exists (select * from dbo.sysobjects where id = object_id(N'[compute_importflow_assign]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_importflow_assign]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [compute_importflow_assign]
	@ayear int
AS
BEGIN
--  compute_importflow_assign 2014
declare @idupb varchar(100)
select @idupb = idupb from unict_config where ayear=@ayear


;with sumimp(idfin,idupb,amount) as
(select idfin,idupb,sum(importo)
from import_flowview 
where esercizio=@ayear and anno_accimp is null and isnull(variazione,'N')<>'S' and assegnazione='S'
		 and id_inc is null and id_liq is null
group by idfin,idupb
)
/*,
sumimp2(idfin,idupb,amount) as 
(select idfin,@idupb,-sum(importo)
from import_flowview 
where esercizio=@ayear and anno_accimp is null and isnull(variazione,'N')<>'S' and assegnazione='S'
			 and id_inc is null and id_liq is null
group by idfin
)
*/
select sumimp.idfin,sumimp.idupb, F.codefin,F.title as fin, UU.codeupb, UU.title as upb,
		(sumimp.amount- isnull(U.expenseprevavailable,0)) as amount,
  	case
		when (( F.flag & 1)=0) then 'E'
		when (( F.flag & 1)<>0) then 'S'
	End as finpart

from sumimp
	left outer join  upbfinyearview U on U.idfin=sumimp.idfin and sumimp.idupb=U.idupb
	join fin F on F.idfin=sumimp.idfin
	join upb UU on UU.idupb= sumimp.idupb
    where (sumimp.amount > isnull(U.expenseprevavailable,0))
union all
select sumimp.idfin,@idupb, F.codefin,F.title as fin, UU.codeupb, UU.title as upb,
		-SUM((sumimp.amount- isnull(U.expenseprevavailable,0))) as amount,
  	case
		when (( F.flag & 1)=0) then 'E'
		when (( F.flag & 1)<>0) then 'S'
	End as finpart

from sumimp
	left outer join  upbfinyearview U on U.idfin=sumimp.idfin and sumimp.idupb=U.idupb
	join fin F on F.idfin=sumimp.idfin
	join upb UU on UU.idupb= @idupb
    where (sumimp.amount > isnull(U.expenseprevavailable,0))
	group by sumimp.idfin, F.codefin,F.title,UU.codeupb, UU.title,F.flag 

/*
select sumimp2.idfin,sumimp2.idupb, F.codefin,F.title as fin, UU.codeupb, UU.title as upb,
		sumimp2.amount,
  	case
		when (( F.flag & 1)=0) then 'E'
		when (( F.flag & 1)<>0) then 'S'
	End as finpart

from sumimp2
	join fin F on F.idfin=sumimp2.idfin
	left outer join upb UU on UU.idupb= sumimp2.idupb
  
*/




END
