if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgetinvestimentiufficiale_triennale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgetinvestimentiufficiale_triennale]
GO
 --setuser'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec rpt_budgetinvestimentiufficiale_triennale 2018, 18,'%','S',null,null,null,null,null, 'S','N'
CREATE      PROCEDURE [rpt_budgetinvestimentiufficiale_triennale](
	@ayear int,--> anno del bilancio di previsione
	@idsorkind int,
	@idupb varchar(36)='%',
	@showchildupb char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@show_investimentiprogettiricerca char(1),
	@budgetpuro char(1)
)
AS BEGIN
if (@budgetpuro='S') 
	Begin
		exec rpt_budgetinvestimentiufficiale_triennale_puro @ayear, @idupb,@showchildupb,@idsor01,@idsor02,@idsor03,	@idsor04,@idsor05,@show_investimentiprogettiricerca
		RETURN
	End
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

--	I) CONTRIBUTI DA TERZI FINALIZZATI(IN CONTO CAPITALE E/O CONTO IMPIANTI)
--	II) RISORSE DA INDEBITAMENTO
--	III) RISORSE PROPRIE
 

 

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

create table #budget_derivato
(code varchar(10), sortcode varchar(50), description varchar(200), printingorder varchar(50), 
 amount_c_prev1 decimal(19,2), amount_i_prev1 decimal(19,2), amount_p_prev1 decimal(19,2), amount_prev1 decimal(19,2),
 amount_c_prev2 decimal(19,2), amount_i_prev2 decimal(19,2), amount_p_prev2 decimal(19,2), amount_prev2 decimal(19,2),	
 amount_c_prev3 decimal(19,2), amount_i_prev3 decimal(19,2), amount_p_prev3 decimal(19,2), amount_prev3 decimal(19,2),
)
--  I11 I12  I13 tre fonti 
--- caratteri 4 5 6 impieghi

insert into  #budget_derivato (code, sortcode, description,printingorder, 
							   amount_c_prev1 ,amount_i_prev1 , amount_p_prev1 , amount_prev1 ,
							   amount_c_prev2 ,amount_i_prev2 , amount_p_prev2 , amount_prev2 ,
							   amount_c_prev3 ,amount_i_prev3 , amount_p_prev3 , amount_prev3 
							   )
SELECT  #impieghi.code, #impieghi.sortcode, #impieghi.description, #impieghi.printingorder, 
	CASE WHEN  substring(S.sortcode,1,3) = 'I11' THEN isnull(budgetprevision.prevision,0) ELSE 0 END  , -- C
	CASE WHEN  substring(S.sortcode,1,3) = 'I12' THEN isnull(budgetprevision.prevision,0) ELSE 0 END  , -- I 
	CASE WHEN  substring(S.sortcode,1,3) = 'I13' THEN isnull(budgetprevision.prevision,0) ELSE 0 END  , -- P 
	CASE WHEN  substring(S.sortcode,1,3) = 'I21' THEN isnull(budgetprevision.prevision,0) ELSE 0 END  , -- totale impiego

	CASE WHEN  substring(S.sortcode,1,3) = 'I11' THEN isnull(budgetprevision.prevision2,0) ELSE 0 END  , -- C
	CASE WHEN  substring(S.sortcode,1,3) = 'I12' THEN isnull(budgetprevision.prevision2,0) ELSE 0 END  , -- I 
	CASE WHEN  substring(S.sortcode,1,3) = 'I13' THEN isnull(budgetprevision.prevision2,0) ELSE 0 END  , -- P 
	CASE WHEN  substring(S.sortcode,1,3) = 'I21' THEN isnull(budgetprevision.prevision2,0) ELSE 0 END  , -- totale impiego

	CASE WHEN  substring(S.sortcode,1,3) = 'I11' THEN isnull(budgetprevision.prevision3,0) ELSE 0 END  , -- C
	CASE WHEN  substring(S.sortcode,1,3) = 'I12' THEN isnull(budgetprevision.prevision3,0) ELSE 0 END  , -- I 
	CASE WHEN  substring(S.sortcode,1,3) = 'I13' THEN isnull(budgetprevision.prevision3,0) ELSE 0 END  , -- P 
	CASE WHEN  substring(S.sortcode,1,3) = 'I21' THEN isnull(budgetprevision.prevision3,0) ELSE 0 END    -- totale impiego

FROM budgetprevision 
	join sorting S
		on budgetprevision.idsor = S.idsor
	JOIN upb U
		ON budgetprevision.idupb = U.idupb
	join #impieghi  
		on #impieghi.code = SUBSTRING(S.sortcode,4,3) 
	WHERE budgetprevision.ayear = @ayear
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
 
--select * from #budget_derivato
select
	@codeupb as codeupb,
	@upb as upb,
	@treasurer as department, 
	#impieghi.nlevel,
	#impieghi.prefix + #impieghi.description as 'description',
	parent.prefix + parent.description as 'parentdescription',
	substring(#impieghi.printingorder,1,4) as parentprintingorder,
	#impieghi.printingorder,
	isnull(sum(amount_prev1),0) AS amount_prev1,
	isnull(sum(amount_c_prev1),0) AS amount_c,
	isnull(sum(amount_i_prev1),0) AS amount_i,
	isnull(sum(amount_p_prev1),0) AS amount_p,

	isnull(sum(amount_prev2),0) AS amount_prev2,
	isnull(sum(amount_c_prev2),0) AS amount_c_prev2,
	isnull(sum(amount_i_prev2),0) AS amount_i_prev2,
	isnull(sum(amount_p_prev2),0) AS amount_p_prev2,

	isnull(sum(amount_prev3),0) AS amount_prev3,
	isnull(sum(amount_c_prev3),0) AS amount_c_prev3,
	isnull(sum(amount_i_prev3),0) AS amount_i_prev3,
	isnull(sum(amount_p_prev3),0) AS amount_p_prev3
	from #impieghi
	left outer join #budget_derivato 
	on #impieghi.code = #budget_derivato.code
	left outer join #impieghi parent 
	on parent.sortcode = substring(#impieghi.sortcode,1,4)
	and parent.nlevel = 4
	-- Condizione sulla voce Investimenti per progetti di ricerca
	WHERE ((#impieghi.printingorder not like '2214%'  and @show_investimentiprogettiricerca = 'N') or @show_investimentiprogettiricerca = 'S')
	group by #impieghi.description,	substring(#impieghi.printingorder,1,4),#impieghi.printingorder,parent.prefix ,parent.description,
	#impieghi.nlevel,	#impieghi.prefix
	order by #impieghi.printingorder
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 

