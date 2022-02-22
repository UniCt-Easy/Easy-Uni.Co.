
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgetinvestimentiufficiale_puro]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgetinvestimentiufficiale_puro]
GO

--setuser'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec rpt_budgetinvestimentiufficiale_puro 2018, '%','S',null,null,null,null,null, 'N'
CREATE      PROCEDURE [rpt_budgetinvestimentiufficiale_puro](
	@ayear int,--> anno del bilancio di previsione
	@idupb varchar(36)='%',
	@showchildupb char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@show_investimentiprogettiricerca char(1)
)
AS BEGIN
declare @treasurer varchar(150)
declare @codeupb varchar(50)
declare	@upb varchar(150)
select @codeupb = codeupb,
		@upb = title
from upb where idupb = @idupb

if(@idupb = '%') 
Begin
	select @treasurer = null
end
Else
Begin
	select @treasurer = isnull(T.header, T.description) from upb U
						join treasurer T
							ON T.idtreasurer = U.idtreasurer
						where U.idupb = @idupb
End

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END
 
-- creo una tabella temporanea degli impieghi 
declare @idsorkind int
select  @idsorkind = idsorkind from sortingkind  -- 18 BUDGET_UFF Budget Schema Ufficiale
where   codesorkind = 'BUDGET_UFF'

--select substring(sortcode, 4,6) ,  S.sortcode, S.description,S.printingorder from sorting S where  @idsorkind = idsorkind and substring(sortcode, 1,3) = 'I21'
--and S.nlevel = 5

--sp_help sorting
create table #impieghi
(prefix varchar(4), nlevel int, code varchar(10), sortcode varchar(50), description varchar(200), printingorder varchar(50), underwritingkind char(1))

create table #fonti
(underwritingkind char(1) )
insert into #fonti
select 'C' union  select 'P'union select 'I'

insert into  #impieghi (nlevel, code, sortcode, description,printingorder)
select S.nlevel,substring(sortcode, 4,3) ,  S.sortcode, S.description,S.printingorder from sorting S  
where  @idsorkind = idsorkind and substring(sortcode, 1,3) = 'I21'
and (S.nlevel = 4 OR S.nlevel = 5)

update #impieghi set prefix = (case #impieghi.code  when '1' then 'I. ' when '2' then 'II. ' when '3' then 'III. ' when '4' then 'IV. ' else null end) where nlevel = 4
update #impieghi set prefix = substring(#impieghi.code, 3,1) + '. ' where nlevel = 5
--select * from #impieghi

create table #budget_puro
(code varchar(10), sortcode varchar(50), description varchar(200), printingorder varchar(50), amount_c decimal(19,2), amount_i decimal(19,2), amount_p decimal(19,2), amount decimal(19,2))

insert into  #budget_puro (code, sortcode, description,printingorder, amount_c,amount_i, amount_p,amount )
select  #impieghi.code, #impieghi.sortcode, #impieghi.description, #impieghi.printingorder, 
	CASE WHEN accountvardetail.underwritingkind = 'C' THEN isnull(accountvardetail.amount,0) ELSE 0 END  ,
	CASE WHEN accountvardetail.underwritingkind = 'I' THEN isnull(accountvardetail.amount,0) ELSE 0 END  ,
	CASE WHEN accountvardetail.underwritingkind = 'p' THEN isnull(accountvardetail.amount,0) ELSE 0 END  ,
	isnull(accountvardetail.amount,0)
	FROM accountvar  
JOIN accountvardetail 
	ON accountvar.yvar = accountvardetail.yvar 
	AND accountvar.nvar = accountvardetail.nvar 
join account A
	on accountvardetail.idacc =  A.idacc
JOIN upb U
		on accountvardetail.idupb = U.idupb
join sorting S
	on S.idsor = A.idsor_investmentbudget
join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 
WHERE accountvar.yvar = @ayear  AND accountvar.idaccountvarstatus = 5  -- Tipo Approvata  
	AND accountvar.variationkind = 5 -- Tipo iniziale
	AND S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)


--select * from #budget_puro  
--drop table #impieghi
--sp_help accountvardetail
--	I) CONTRIBUTI DA TERZI FINALIZZATI(IN CONTO CAPITALE E/O CONTO IMPIANTI)
--	II) RISORSE DA INDEBITAMENTO
--	III) RISORSE PROPRIE



-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

select
	@codeupb as codeupb,
	@upb as upb,
	@treasurer as department, 
	#impieghi.nlevel,
	CASE WHEN  UPPER(#impieghi.description) <> UPPER(parent.description) and #impieghi.nlevel = 5 THEN #impieghi.prefix + #impieghi.description
		 ELSE parent.prefix + parent.description
	END as 'description',
	parent.prefix + parent.description as 'parentdescription',
	substring(#impieghi.printingorder,1,4) as parentprintingorder,
	#impieghi.printingorder,
	isnull(sum(amount),0) AS amount,
	isnull(sum(amount_c),0) AS amount_c,
	isnull(sum(amount_i),0) AS amount_i,
	isnull(sum(amount_p),0) AS amount_p
	from #impieghi
	left outer join #budget_puro 
	on #impieghi.code = #budget_puro.code
	left outer join #impieghi parent 
	on parent.sortcode = substring(#impieghi.sortcode,1,4)
	and parent.nlevel = 4
	-- Condizione sulla voce Investimenti per progetti di ricerca
	WHERE ((#impieghi.printingorder not like '2214%'  and @show_investimentiprogettiricerca = 'N') or @show_investimentiprogettiricerca = 'S')
	AND (#impieghi.nlevel = 5 or (#impieghi.nlevel = 4 and #impieghi.printingorder not like '2214%' and #impieghi.printingorder  not like '2213%'))
	group by #impieghi.description,substring(#impieghi.printingorder,1,4),#impieghi.printingorder,	parent.prefix ,parent.description,
	#impieghi.nlevel,	#impieghi.prefix
	order by #impieghi.printingorder
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 
