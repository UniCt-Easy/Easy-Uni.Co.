
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_consuntivobudgetinvestimentiufficiale_puro]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_consuntivobudgetinvestimentiufficiale_puro]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser'amministrazione' 
-- exec rpt_consuntivobudgetinvestimentiufficiale_puro 2017, '2017-12-31','%','S',null,null,null,null,null, 'S'
-- exec rpt_consuntivobudgetinvestimentiufficiale_puro 2019, {ts '2019-12-31 00:00:00'}, '000100040078', 'S', NULL, NULL, NULL, NULL, NULL, 'S'
CREATE      PROCEDURE [rpt_consuntivobudgetinvestimentiufficiale_puro](
	@ayear int,--> anno del bilancio di previsione
	@adate datetime,
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
 
declare @nlevel int
set @nlevel = (select MIN(nlevel) from accountlevel where ayear = @ayear and flagusable = 'S')

declare @lenminlevel int
set @lenminlevel = 2 + 4*@nlevel

declare @maxnlevel int
set @maxnlevel = (select MAX(nlevel) from accountlevel where ayear = @ayear and flagusable = 'S')
 
 declare @idsorkind int
select  @idsorkind = idsorkind from sortingkind  -- 18 BUDGET_UFF Budget Schema Ufficiale
where   codesorkind = 'BUDGET_UFF'
create table #impieghi
(prefix varchar(4), nlevel int, code varchar(10), sortcode varchar(50), description varchar(200), printingorder varchar(50), underwritingkind char(1))

create table #fonti
(underwritingkind char(1) )
insert into #fonti
select 'C' union  select 'P'union select 'I'

insert into  #impieghi (nlevel, code, sortcode, description,printingorder)
select S.nlevel,substring(sortcode, 4,3) ,  S.sortcode, S.description,S.printingorder 
from sorting S  
where  @idsorkind = idsorkind and substring(sortcode, 1,3) = 'I21'
and (S.nlevel = 4 OR S.nlevel = 5)

update #impieghi set prefix = (case #impieghi.code  when '1' then 'I. ' when '2' then 'II. ' when '3' then 'III. ' when '4' then 'IV. ' else null end) where nlevel = 4
update #impieghi set prefix = substring(#impieghi.code, 3,1) + '. ' where nlevel = 5



declare @A1_Costi_impianto_prev decimal(19,2)
set @A1_Costi_impianto_prev= ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget
join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21101%'),0)

declare @A1_Costi_impianto_var decimal(19,2)
set @A1_Costi_impianto_var = ISNULL(( SELECT SUM(accountvardetail.amount)
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
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND adate<= @adate
		AND A.nlevel = @nlevel
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21101%'),0)

declare @A1_Costi_impianto_preimp decimal(19,2)
set @A1_Costi_impianto_preimp = (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
				join #impieghi  
					on #impieghi.code = SUBSTRING(S.sortcode,4,3) 
				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21101%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY			ON EV.idepexp = EY.idepexp 
				JOIN epexp E				ON E.idepexp = EY.idepexp
				JOIN account A				ON EY.idacc = A.idacc
				JOIN account PARENT 		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U					ON EY.idupb = U.idupb
				JOIN sorting S				ON S.idsor = PARENT.idsor_investmentbudget
				join #impieghi   on #impieghi.code = SUBSTRING(S.sortcode,4,3) 
				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21101%'),0))


declare @A2_Diritti_brevetto_prev decimal(19,2)
set @A2_Diritti_brevetto_prev= ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A			on accountyear.idacc = A.idacc
	JOIN upb U				ON accountyear.idupb = U.idupb
	join sorting S			on S.idsor = A.idsor_investmentbudget
	join #impieghi       on #impieghi.code = SUBSTRING(S.sortcode,4,3) 
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21102%'),0)

declare @A2_Diritti_brevetto_var decimal(19,2)
set @A2_Diritti_brevetto_var = ISNULL(( SELECT SUM(accountvardetail.amount)
	FROM accountvar  
	JOIN accountvardetail	ON accountvar.yvar = accountvardetail.yvar 	AND accountvar.nvar = accountvardetail.nvar  
	join account A			on accountvardetail.idacc =  A.idacc
	JOIN upb U				on accountvardetail.idupb = U.idupb
	join sorting S			on S.idsor = A.idsor_investmentbudget
	join #impieghi    on #impieghi.code = SUBSTRING(S.sortcode,4,3) 
	WHERE accountvar.yvar = @ayear  AND accountvar.idaccountvarstatus = 5  -- Tipo Approvata  
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND adate<= @adate
		AND A.nlevel = @nlevel
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21102%'),0)


declare @A2_Diritti_brevetto_preimp decimal(19,2)
set @A2_Diritti_brevetto_preimp =  (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E				ON E.idepexp = EY.idepexp
				JOIN account A				ON EY.idacc = A.idacc
				JOIN account PARENT 		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U					ON EY.idupb = U.idupb
				JOIN sorting S				ON S.idsor = PARENT.idsor_investmentbudget
				join #impieghi   on #impieghi.code = SUBSTRING(S.sortcode,4,3) 
				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21102%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY			ON EV.idepexp = EY.idepexp 
				JOIN epexp E				ON E.idepexp = EY.idepexp
				JOIN account A				ON EY.idacc = A.idacc
				JOIN account PARENT 		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U					ON EY.idupb = U.idupb
				JOIN sorting S				ON S.idsor = PARENT.idsor_investmentbudget
				join #impieghi				on #impieghi.code = SUBSTRING(S.sortcode,4,3) 
				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21102%'),0))



declare @A3_Concessioni_licenze_prev decimal(19,2)
set @A3_Concessioni_licenze_prev= ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A			on accountyear.idacc = A.idacc
	JOIN upb U				ON accountyear.idupb = U.idupb
	join sorting S			on S.idsor = A.idsor_investmentbudget
	join #impieghi			on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21103%'),0)

declare @A3_Concessioni_licenze_var decimal(19,2)
set @A3_Concessioni_licenze_var = ISNULL(( SELECT SUM(accountvardetail.amount)
	FROM accountvar  
	JOIN accountvardetail 	ON accountvar.yvar = accountvardetail.yvar 	AND accountvar.nvar = accountvardetail.nvar  
	join account A			on accountvardetail.idacc =  A.idacc
	JOIN upb U				 on accountvardetail.idupb = U.idupb
	join sorting S			on S.idsor = A.idsor_investmentbudget
	join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountvar.yvar = @ayear  AND accountvar.idaccountvarstatus = 5  -- Tipo Approvata  
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND adate<= @adate
		AND A.nlevel = @nlevel
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21103%'),0)

declare @A3_Concessioni_licenze_preimp decimal(19,2)
set @A3_Concessioni_licenze_preimp =  (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E				ON E.idepexp = EY.idepexp
				JOIN account A				ON EY.idacc = A.idacc
				JOIN account PARENT 		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U					ON EY.idupb = U.idupb
				JOIN sorting S				ON S.idsor = PARENT.idsor_investmentbudget
				join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21103%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY		ON EV.idepexp = EY.idepexp 
				JOIN epexp E			ON E.idepexp = EY.idepexp
				JOIN account A			ON EY.idacc = A.idacc
				JOIN account PARENT 	ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U				ON EY.idupb = U.idupb
				JOIN sorting S			ON S.idsor = PARENT.idsor_investmentbudget
				join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21103%'),0))




declare @A4_immobilizzazioni_IMMATERIALI_prev decimal(19,2)
set @A4_immobilizzazioni_IMMATERIALI_prev=ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21104%'),0)

declare @A4_immobilizzazioni_IMMATERIALI_var decimal(19,2)
set @A4_immobilizzazioni_IMMATERIALI_var = ISNULL(( SELECT SUM(accountvardetail.amount)
	FROM accountvar  
	JOIN accountvardetail 	ON accountvar.yvar = accountvardetail.yvar 	AND accountvar.nvar = accountvardetail.nvar  
	join account A			on accountvardetail.idacc =  A.idacc
	JOIN upb U				 on accountvardetail.idupb = U.idupb
	join sorting S			on S.idsor = A.idsor_investmentbudget
	join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountvar.yvar = @ayear  AND accountvar.idaccountvarstatus = 5  -- Tipo Approvata  
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND A.nlevel = @nlevel
		AND adate<= @adate
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21104%'),0)

declare @A4_immobilizzazioni_IMMATERIALI_preimp decimal(19,2)
set @A4_immobilizzazioni_IMMATERIALI_preimp = (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY	
				JOIN epexp E				ON E.idepexp = EY.idepexp
				JOIN account A				ON EY.idacc = A.idacc
				JOIN account PARENT 		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U					ON EY.idupb = U.idupb
				JOIN sorting S				ON S.idsor = PARENT.idsor_investmentbudget
				join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21104%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY				ON EV.idepexp = EY.idepexp 
				JOIN epexp E					ON E.idepexp = EY.idepexp
				JOIN account A					ON EY.idacc = A.idacc
				JOIN account PARENT				ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U						ON EY.idupb = U.idupb
				JOIN sorting S 					ON S.idsor = PARENT.idsor_investmentbudget
				join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21104%'),0))




declare @A5_Altre_immobilizzazioni_immateriali_prev decimal(19,2)
set @A5_Altre_immobilizzazioni_immateriali_prev =ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21105%'),0)

declare @A5_Altre_immobilizzazioni_immateriali_var decimal(19,2)
set @A5_Altre_immobilizzazioni_immateriali_var =ISNULL(( SELECT SUM(accountvardetail.amount)
	FROM accountvar  
	JOIN accountvardetail	ON accountvar.yvar = accountvardetail.yvar 	AND accountvar.nvar = accountvardetail.nvar  
	join account A			on accountvardetail.idacc =  A.idacc
	JOIN upb U				 on accountvardetail.idupb = U.idupb
	join sorting S			on S.idsor = A.idsor_investmentbudget
	join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountvar.yvar = @ayear  AND accountvar.idaccountvarstatus = 5  -- Tipo Approvata  
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND A.nlevel = @nlevel
		AND adate<= @adate
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21105%'),0)

declare @A5_Altre_immobilizzazioni_immateriali_preimp decimal(19,2)
set @A5_Altre_immobilizzazioni_immateriali_preimp = (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E		ON E.idepexp = EY.idepexp
				JOIN account A		ON EY.idacc = A.idacc
				JOIN account PARENT ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U			ON EY.idupb = U.idupb
				JOIN sorting S		ON S.idsor = PARENT.idsor_investmentbudget
				join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21105%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY			ON EV.idepexp = EY.idepexp 
				JOIN epexp E				ON E.idepexp = EY.idepexp
				JOIN account A				ON EY.idacc = A.idacc
				JOIN account PARENT 		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U					ON EY.idupb = U.idupb
				JOIN sorting S				ON S.idsor = PARENT.idsor_investmentbudget
				join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21105%'),0))
 


declare @A_TOT_IMMATERIALI_prev decimal(19,2)
set @A_TOT_IMMATERIALI_prev = isnull(@A1_Costi_impianto_prev,0) + isnull(@A2_Diritti_brevetto_prev,0) + isnull(@A3_Concessioni_licenze_prev,0) 
					+ isnull(@A4_immobilizzazioni_IMMATERIALI_prev,0) + isnull(@A5_Altre_immobilizzazioni_immateriali_prev,0)

declare @A_TOT_IMMATERIALI_var decimal(19,2)
set @A_TOT_IMMATERIALI_var = isnull(@A1_Costi_impianto_var,0) + isnull(@A2_Diritti_brevetto_var,0) + isnull(@A3_Concessioni_licenze_var,0) 
					+ isnull(@A4_immobilizzazioni_IMMATERIALI_var,0) + isnull(@A5_Altre_immobilizzazioni_immateriali_var,0)

declare @A_TOT_IMMATERIALI_preimp decimal(19,2)
set @A_TOT_IMMATERIALI_preimp = isnull(@A1_Costi_impianto_preimp ,0) + isnull(@A2_Diritti_brevetto_preimp ,0) + isnull(@A3_Concessioni_licenze_preimp ,0) 
					+ isnull(@A4_immobilizzazioni_IMMATERIALI_preimp ,0) + isnull(@A5_Altre_immobilizzazioni_immateriali_preimp ,0)

declare @A1_Terreni_fabbricati_prev decimal(19,2)
set @A1_Terreni_fabbricati_prev =ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21201%'),0)

declare @A1_Terreni_fabbricati_var decimal(19,2)
set @A1_Terreni_fabbricati_var = ISNULL(( SELECT SUM(accountvardetail.amount)
	FROM accountvar  
	JOIN accountvardetail 	ON accountvar.yvar = accountvardetail.yvar 	AND accountvar.nvar = accountvardetail.nvar  
	join account A		on accountvardetail.idacc =  A.idacc
	JOIN upb U			 on accountvardetail.idupb = U.idupb
	join sorting S		on S.idsor = A.idsor_investmentbudget
	join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountvar.yvar = @ayear  AND accountvar.idaccountvarstatus = 5  -- Tipo Approvata  
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND A.nlevel = @nlevel
		AND adate<= @adate
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21201%'),0)

declare @A1_Terreni_fabbricati_preimp decimal(19,2)
set @A1_Terreni_fabbricati_preimp = (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21201%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY
					ON EV.idepexp = EY.idepexp 
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21201%'),0))


declare @A2_impianti_attrezzature_prev decimal(19,2)
set @A2_impianti_attrezzature_prev = ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21202%'),0)
--select @A2_impianti_attrezzature_prev -- QUA

declare @A2_impianti_attrezzature_var decimal(19,2)
set @A2_impianti_attrezzature_var= ISNULL(( SELECT SUM(accountvardetail.amount)
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
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND A.nlevel = @nlevel
		AND adate<= @adate
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21202%'),0)

--select  @A2_impianti_attrezzature_var -- QUA

declare @A2_impianti_attrezzature_preimp decimal(19,2)
set @A2_impianti_attrezzature_preimp=  (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21202%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY
					ON EV.idepexp = EY.idepexp 
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21202%'),0))
		
---select @A2_impianti_attrezzature_preimp --- QUA

declare @A3_Attrezzature_scientifiche_prev decimal(19,2)
set @A3_Attrezzature_scientifiche_prev =ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21203%'),0)

declare @A3_Attrezzature_scientifiche_var decimal(19,2)
set @A3_Attrezzature_scientifiche_var =ISNULL(( SELECT SUM(accountvardetail.amount)
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
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND A.nlevel = @nlevel
		AND adate<= @adate
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21203%'),0)

declare @A3_Attrezzature_scientifiche_preimp decimal(19,2)
set @A3_Attrezzature_scientifiche_preimp= (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21203%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY
					ON EV.idepexp = EY.idepexp 
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21203%'),0))



declare @A4_Patrimonio_librario_prev decimal(19,2)
set @A4_Patrimonio_librario_prev=ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget

		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21204%'),0)

declare @A4_Patrimonio_librario_var decimal(19,2)
set @A4_Patrimonio_librario_var =ISNULL(( SELECT SUM(accountvardetail.amount)
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
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND A.nlevel = @nlevel
		AND adate<= @adate
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21204%'),0)

declare @A4_Patrimonio_librario_preimp decimal(19,2)
set @A4_Patrimonio_librario_preimp = (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21204%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY
					ON EV.idepexp = EY.idepexp 
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21204%'),0))
	 




declare @A5_Mobili_arredi_prev decimal(19,2)
set @A5_Mobili_arredi_prev =ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21205%'),0)


declare @A5_Mobili_arredi_var decimal(19,2)
set @A5_Mobili_arredi_var =ISNULL(( SELECT SUM(accountvardetail.amount)
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
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND A.nlevel = @nlevel
		AND adate<= @adate
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21205%'),0)

declare @A5_Mobili_arredi_preimp decimal(19,2)
set @A5_Mobili_arredi_preimp = (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21205%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY
					ON EV.idepexp = EY.idepexp 
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21205%'),0))
 

declare @A6_immobilizzazioni_materiali_corso_acconti_prev decimal(19,2)
set @A6_immobilizzazioni_materiali_corso_acconti_prev =ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21206%'),0)

declare @A6_immobilizzazioni_materiali_corso_acconti_var decimal(19,2)
set @A6_immobilizzazioni_materiali_corso_acconti_var =ISNULL(( SELECT SUM(accountvardetail.amount)
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
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND A.nlevel = @nlevel
		AND adate<= @adate
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21206%'),0)

declare @A6_immobilizzazioni_materiali_corso_acconti_preimp decimal(19,2)
set @A6_immobilizzazioni_materiali_corso_acconti_preimp = (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21206%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY
					ON EV.idepexp = EY.idepexp 
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21206%'),0))
	



declare @A7_Altre_immobilizzazioni_materiali_prev decimal(19,2)
set @A7_Altre_immobilizzazioni_materiali_prev =ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21207%'),0)

declare @A7_Altre_immobilizzazioni_materiali_var decimal(19,2)
set @A7_Altre_immobilizzazioni_materiali_var =ISNULL(( SELECT SUM(accountvardetail.amount)
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
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND A.nlevel = @nlevel
		AND adate<= @adate
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21207%'),0)

declare @A7_Altre_immobilizzazioni_materiali_preimp decimal(19,2)
set @A7_Altre_immobilizzazioni_materiali_preimp = (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21207%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY
					ON EV.idepexp = EY.idepexp 
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21207%'),0))
	 



declare @A_TOT_MATERIALI_prev decimal(19,2)	
set @A_TOT_MATERIALI_prev =	@A1_Terreni_fabbricati_prev + @A2_impianti_attrezzature_prev + @A3_Attrezzature_scientifiche_prev + 
						@A4_Patrimonio_librario_prev + @A5_Mobili_arredi_prev + @A6_immobilizzazioni_materiali_corso_acconti_prev + 
						@A7_Altre_immobilizzazioni_materiali_prev

declare @A_TOT_MATERIALI_var decimal(19,2)	
set @A_TOT_MATERIALI_var =	@A1_Terreni_fabbricati_var + @A2_impianti_attrezzature_var + @A3_Attrezzature_scientifiche_var + 
						@A4_Patrimonio_librario_var + @A5_Mobili_arredi_var + @A6_immobilizzazioni_materiali_corso_acconti_var +
						@A7_Altre_immobilizzazioni_materiali_var


declare @A_TOT_MATERIALI_preimp decimal(19,2)	
set @A_TOT_MATERIALI_preimp =	@A1_Terreni_fabbricati_preimp + @A2_impianti_attrezzature_preimp + @A3_Attrezzature_scientifiche_preimp + 
						@A4_Patrimonio_librario_preimp + @A5_Mobili_arredi_preimp + 
						@A6_immobilizzazioni_materiali_corso_acconti_preimp + @A7_Altre_immobilizzazioni_materiali_preimp

declare @A_IMMOBILIZZAZIONI_FINANZIARIE_prev decimal(19,2)
set @A_IMMOBILIZZAZIONI_FINANZIARIE_prev = ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21301%'),0)

declare @A_IMMOBILIZZAZIONI_FINANZIARIE_var decimal(19,2)
set @A_IMMOBILIZZAZIONI_FINANZIARIE_var = ISNULL(( SELECT SUM(accountvardetail.amount)
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
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND A.nlevel = @nlevel
		AND adate<= @adate
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21301%'),0)

declare @A_IMMOBILIZZAZIONI_FINANZIARIE_preimp decimal(19,2)
set @A_IMMOBILIZZAZIONI_FINANZIARIE_preimp =  (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21301%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY
					ON EV.idepexp = EY.idepexp 
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21301%'),0))
		 




declare @A_INVESTIMENTI_PERPROGETTIDIRICERCA_prev decimal(19,2)
set @A_INVESTIMENTI_PERPROGETTIDIRICERCA_prev = 0
if (@show_investimentiprogettiricerca = 'S')
Begin
	set @A_INVESTIMENTI_PERPROGETTIDIRICERCA_prev = ISNULL(( SELECT SUM(accountyear.prevision)
	FROM accountyear 
	join account A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND A.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21401%'),0)
End

declare @A_INVESTIMENTI_PERPROGETTIDIRICERCA_var decimal(19,2)
set @A_INVESTIMENTI_PERPROGETTIDIRICERCA_var = 0
if (@show_investimentiprogettiricerca = 'S')
Begin
	set @A_INVESTIMENTI_PERPROGETTIDIRICERCA_var = ISNULL(( SELECT SUM(accountvardetail.amount)
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
		AND accountvar.variationkind <> 5 -- Diversa da Tipo iniziale
		AND A.nlevel = @nlevel
		AND adate<= @adate
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21401%'),0)
End

declare @A_INVESTIMENTI_PERPROGETTIDIRICERCA_preimp decimal(19,2)
set @A_INVESTIMENTI_PERPROGETTIDIRICERCA_preimp = 0
if (@show_investimentiprogettiricerca = 'S')
Begin
	set @A_INVESTIMENTI_PERPROGETTIDIRICERCA_preimp =  (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
				FROM epexpyear EY
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21401%'),0))
				+
				(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
				FROM epexpvar EV 
				JOIN epexpyear EY
					ON EV.idepexp = EY.idepexp 
				JOIN epexp E
					ON E.idepexp = EY.idepexp
				JOIN account A
					ON EY.idacc = A.idacc
				JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
				JOIN upb U
					ON EY.idupb = U.idupb
				JOIN sorting S
 					ON S.idsor = PARENT.idsor_investmentbudget
					join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

				WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
				AND U.idupb like @idupb
				AND A.flagaccountusage & 256 <> 0
				--AND A.nlevel = @maxnlevel
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and #impieghi.sortcode like 'I21401%'),0))
	
End


	
DECLARE @TOT_GENERALE_prev decimal(19,2)
SET @TOT_GENERALE_prev = isnull(@A_TOT_IMMATERIALI_prev,0) + isnull(@A_TOT_MATERIALI_prev,0) + 
						 isnull(@A_IMMOBILIZZAZIONI_FINANZIARIE_prev,0) + isnull(@A_INVESTIMENTI_PERPROGETTIDIRICERCA_prev,0)

DECLARE @TOT_GENERALE_var decimal(19,2)
SET @TOT_GENERALE_var = isnull(@A_TOT_IMMATERIALI_var,0) + isnull(@A_TOT_MATERIALI_var,0) + 
						isnull(@A_IMMOBILIZZAZIONI_FINANZIARIE_var,0) + isnull(@A_INVESTIMENTI_PERPROGETTIDIRICERCA_var,0)

DECLARE @TOT_GENERALE_preimp decimal(19,2)
SET @TOT_GENERALE_preimp = isnull(@A_TOT_IMMATERIALI_preimp,0) + isnull(@A_TOT_MATERIALI_preimp,0) + 
						   isnull(@A_IMMOBILIZZAZIONI_FINANZIARIE_preimp,0) + isnull(@A_INVESTIMENTI_PERPROGETTIDIRICERCA_preimp,0)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------- SCRITTURE IN PARTITA DOPPIA -------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--	I) CONTRIBUTI DA TERZI FINALIZZATI(IN CONTO CAPITALE E/O CONTO IMPIANTI)
--	II) RISORSE DA INDEBITAMENTO
--	III) RISORSE PROPRIE
declare @A1_Costi_impianto_entry decimal(19,2)
set @A1_Costi_impianto_entry = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND entrydetail.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21101%'),0)

declare @A2_Diritti_brevetto_entry decimal(19,2)
set @A2_Diritti_brevetto_entry = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21102%'),0)

declare @A3_Concessioni_licenze_entry decimal(19,2)
set @A3_Concessioni_licenze_entry = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21103%'),0)

declare @A4_immobilizzazioni_IMMATERIALI_entry decimal(19,2)
set @A4_immobilizzazioni_IMMATERIALI_entry =ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21104%'),0)

declare @A5_Altre_immobilizzazioni_immateriali_entry decimal(19,2)
set @A5_Altre_immobilizzazioni_immateriali_entry = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21105%'),0)

declare @A_TOT_IMMATERIALI_entry decimal(19,2)
set @A_TOT_IMMATERIALI_entry = isnull(@A1_Costi_impianto_entry,0) + isnull(@A2_Diritti_brevetto_entry,0) + isnull(@A3_Concessioni_licenze_entry,0) 
					+ isnull(@A4_immobilizzazioni_IMMATERIALI_entry,0) + isnull(@A5_Altre_immobilizzazioni_immateriali_entry,0)

declare @A1_Terreni_fabbricati_entry  decimal(19,2)
set @A1_Terreni_fabbricati_entry  = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21201%'),0)

declare @A2_impianti_attrezzature_entry  decimal(19,2)
set @A2_impianti_attrezzature_entry = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21202%'),0)
--select @A2_impianti_attrezzature_entry -- QUA

declare @A3_Attrezzature_scientifiche_entry  decimal(19,2)
set @A3_Attrezzature_scientifiche_entry  = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21203%'),0)

declare @A4_Patrimonio_librario_entry  decimal(19,2)
set @A4_Patrimonio_librario_entry =ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21204%'),0)


declare @A5_Mobili_arredi_entry  decimal(19,2)
set @A5_Mobili_arredi_entry  = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21205%'),0)

declare @A6_immobilizzazioni_materiali_corso_acconti_entry  decimal(19,2)
set @A6_immobilizzazioni_materiali_corso_acconti_entry  = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21206%'),0)

declare @A7_Altre_immobilizzazioni_materiali_entry  decimal(19,2)
set @A7_Altre_immobilizzazioni_materiali_entry  = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21207%'),0)

declare @A_TOT_MATERIALI_entry  decimal(19,2)	
set @A_TOT_MATERIALI_entry  =	@A1_Terreni_fabbricati_entry  + @A2_impianti_attrezzature_entry  + @A3_Attrezzature_scientifiche_entry  + 
						@A4_Patrimonio_librario_entry + @A5_Mobili_arredi_entry + @A6_immobilizzazioni_materiali_corso_acconti_entry  + @A7_Altre_immobilizzazioni_materiali_entry 

declare @A_IMMOBILIZZAZIONI_FINANZIARIE_entry  decimal(19,2)
set @A_IMMOBILIZZAZIONI_FINANZIARIE_entry  = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21301%'),0)

declare @A_INVESTIMENTI_PERPROGETTIDIRICERCA_entry  decimal(19,2)
set @A_INVESTIMENTI_PERPROGETTIDIRICERCA_entry  = 0
if (@show_investimentiprogettiricerca = 'S')
Begin
	set @A_INVESTIMENTI_PERPROGETTIDIRICERCA_entry  = ISNULL(( SELECT SUM(-entrydetail.amount)
FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account A
		ON A.idacc = entrydetail.idacc
	JOIN account PARENT 
					ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	JOIN upb U
		ON entrydetail.idupb = U.idupb
	join sorting S
		on S.idsor = PARENT.idsor_investmentbudget
		join #impieghi  
	on #impieghi.code = SUBSTRING(S.sortcode,4,3) 

	WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND adate <= @adate
		AND entrydetail.idupb like @idupb
		AND A.flagaccountusage & 256 <> 0	-- Immobilizzazioni
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and #impieghi.sortcode like 'I21401%'),0)
End
	
DECLARE @TOT_GENERALE_entry  decimal(19,2)
SET @TOT_GENERALE_entry  = isnull(@A_TOT_IMMATERIALI_entry ,0) + isnull(@A_TOT_MATERIALI_entry ,0)
						 + isnull(@A_IMMOBILIZZAZIONI_FINANZIARIE_entry ,0) + isnull(@A_INVESTIMENTI_PERPROGETTIDIRICERCA_entry ,0)

select
	@codeupb as codeupb,
	@upb as upb,
	@treasurer as department,
	@A1_Costi_impianto_prev 	as		  'I_A1_Costi_impianto',  
	@A1_Costi_impianto_var 		as		  'II_A1_Costi_impianto',  
	@A1_Costi_impianto_prev + @A1_Costi_impianto_var as	'III_A1_Costi_impianto',
	@A1_Costi_impianto_preimp 	as		  'IV_A1_Costi_impianto',  
	@A1_Costi_impianto_prev + @A1_Costi_impianto_var - @A1_Costi_impianto_preimp as	'V_A1_Costi_impianto',  
	@A1_Costi_impianto_entry 	as		  'VI_A1_Costi_impianto', 
	@A1_Costi_impianto_preimp - @A1_Costi_impianto_entry 		as		  'VII_A1_Costi_impianto', 

	@A2_Diritti_brevetto_prev 		as		  'I_A2_Diritti_brevetto',   
	@A2_Diritti_brevetto_var 		as		  'II_A2_Diritti_brevetto', 
	@A2_Diritti_brevetto_prev+ @A2_Diritti_brevetto_var as	'III_A2_Diritti_brevetto', 
	@A2_Diritti_brevetto_preimp 	as		  'IV_A2_Diritti_brevetto', 
	@A2_Diritti_brevetto_prev + @A2_Diritti_brevetto_var - @A2_Diritti_brevetto_preimp as	'V_A2_Diritti_brevetto', 
	@A2_Diritti_brevetto_entry 		as		  'VI_A2_Diritti_brevetto',
	@A2_Diritti_brevetto_preimp - @A2_Diritti_brevetto_entry 		as		  'VII_A2_Diritti_brevetto',

	@A3_Concessioni_licenze_prev 		as		  'I_A3_Concessioni_licenze',   
	@A3_Concessioni_licenze_var 		as		  'II_A3_Concessioni_licenze', 
	@A3_Concessioni_licenze_prev + @A3_Concessioni_licenze_var as 'III_A3_Concessioni_licenze',
	@A3_Concessioni_licenze_preimp 		as		  'IV_A3_Concessioni_licenze',  
	@A3_Concessioni_licenze_prev + @A3_Concessioni_licenze_var - @A3_Concessioni_licenze_preimp  as 'V_A3_Concessioni_licenze',
	@A3_Concessioni_licenze_entry 		as		  'VI_A3_Concessioni_licenze',
	@A3_Concessioni_licenze_preimp - @A3_Concessioni_licenze_entry 		as		  'VII_A3_Concessioni_licenze',

	@A4_immobilizzazioni_IMMATERIALI_prev 		as		  'I_A4_immobilizzazioni_IMMATERIALI',    
	@A4_immobilizzazioni_IMMATERIALI_var 		as		  'II_A4_immobilizzazioni_IMMATERIALI',  
	@A4_immobilizzazioni_IMMATERIALI_prev + @A4_immobilizzazioni_IMMATERIALI_var as		  'III_A4_immobilizzazioni_IMMATERIALI', 
	@A4_immobilizzazioni_IMMATERIALI_preimp 	as		  'IV_A4_immobilizzazioni_IMMATERIALI',  
	@A4_immobilizzazioni_IMMATERIALI_prev + @A4_immobilizzazioni_IMMATERIALI_var - @A4_immobilizzazioni_IMMATERIALI_preimp as 'V_A4_immobilizzazioni_IMMATERIALI', 
	@A4_immobilizzazioni_IMMATERIALI_entry		as		  'VI_A4_immobilizzazioni_IMMATERIALI', 
	@A4_immobilizzazioni_IMMATERIALI_preimp - @A4_immobilizzazioni_IMMATERIALI_entry		as		  'VII_A4_immobilizzazioni_IMMATERIALI', 

	@A5_Altre_immobilizzazioni_immateriali_prev  		as		  'I_A5_Altre_immobilizzazioni_immateriali',    
	@A5_Altre_immobilizzazioni_immateriali_var  		as		  'II_A5_Altre_immobilizzazioni_immateriali',    
	@A5_Altre_immobilizzazioni_immateriali_prev + @A5_Altre_immobilizzazioni_immateriali_var as		  'III_A5_Altre_immobilizzazioni_immateriali',  
	@A5_Altre_immobilizzazioni_immateriali_preimp  		as		  'IV_A5_Altre_immobilizzazioni_immateriali',    
	@A5_Altre_immobilizzazioni_immateriali_prev + @A5_Altre_immobilizzazioni_immateriali_var - @A5_Altre_immobilizzazioni_immateriali_preimp  as	'V_A5_Altre_immobilizzazioni_immateriali',  
	@A5_Altre_immobilizzazioni_immateriali_entry 		as		  'VI_A5_Altre_immobilizzazioni_immateriali', 
	@A5_Altre_immobilizzazioni_immateriali_preimp - @A5_Altre_immobilizzazioni_immateriali_entry 		as		  'VII_A5_Altre_immobilizzazioni_immateriali', 

	@A_TOT_IMMATERIALI_prev  		as		  'I_A_TOT_IMMATERIALI',  
	@A_TOT_IMMATERIALI_var  		as		  'II_A_TOT_IMMATERIALI',    
	@A_TOT_IMMATERIALI_prev + @A_TOT_IMMATERIALI_var as	'III_A_TOT_IMMATERIALI', 
	@A_TOT_IMMATERIALI_preimp  		as		  'IV_A_TOT_IMMATERIALI',      	 
	@A_TOT_IMMATERIALI_prev + @A_TOT_IMMATERIALI_var - @A_TOT_IMMATERIALI_preimp as	'V_A_TOT_IMMATERIALI',  
	@A_TOT_IMMATERIALI_entry  		    as		  'VI_A_TOT_IMMATERIALI',  
	@A_TOT_IMMATERIALI_preimp - @A_TOT_IMMATERIALI_entry  		    as		  'VII_A_TOT_IMMATERIALI',  

	@A1_Terreni_fabbricati_prev  		as		  'I_A1_Terreni_fabbricati',    
	@A1_Terreni_fabbricati_var  		as		  'II_A1_Terreni_fabbricati',  
	@A1_Terreni_fabbricati_prev + @A1_Terreni_fabbricati_var as	'III_A1_Terreni_fabbricati', 
	@A1_Terreni_fabbricati_preimp  		as		  'IV_A1_Terreni_fabbricati',  	
	@A1_Terreni_fabbricati_prev + @A1_Terreni_fabbricati_var - @A1_Terreni_fabbricati_preimp  as	'V_A1_Terreni_fabbricati', 
	@A1_Terreni_fabbricati_entry  		as		  'VI_A1_Terreni_fabbricati', 
	@A1_Terreni_fabbricati_preimp - @A1_Terreni_fabbricati_entry  		as		  'VII_A1_Terreni_fabbricati', 

	@A2_impianti_attrezzature_prev  	as		  'I_A2_impianti_attrezzature',    
	@A2_impianti_attrezzature_var  		as		  'II_A2_impianti_attrezzature',  
	@A2_impianti_attrezzature_prev + @A2_impianti_attrezzature_var as 'III_A2_impianti_attrezzature',
	@A2_impianti_attrezzature_preimp  	as		  'IV_A2_impianti_attrezzature',	
	@A2_impianti_attrezzature_prev + @A2_impianti_attrezzature_var - @A2_impianti_attrezzature_preimp	as 'V_A2_impianti_attrezzature',
	@A2_impianti_attrezzature_entry  	as		  'VI_A2_impianti_attrezzature', 
	@A2_impianti_attrezzature_preimp - @A2_impianti_attrezzature_entry  	as		  'VII_A2_impianti_attrezzature', 

	@A3_Attrezzature_scientifiche_prev  as		  'I_A3_Attrezzature_scientifiche',   
	@A3_Attrezzature_scientifiche_var  	as		  'II_A3_Attrezzature_scientifiche', 
	@A3_Attrezzature_scientifiche_prev + @A3_Attrezzature_scientifiche_var as 'III_A3_Attrezzature_scientifiche', 
	@A3_Attrezzature_scientifiche_preimp  as	  'IV_A3_Attrezzature_scientifiche', 	
	@A3_Attrezzature_scientifiche_prev + @A3_Attrezzature_scientifiche_var - @A3_Attrezzature_scientifiche_preimp	as 'V_A3_Attrezzature_scientifiche', 
	@A3_Attrezzature_scientifiche_entry  as		  'VI_A3_Attrezzature_scientifiche', 
	@A3_Attrezzature_scientifiche_preimp - @A3_Attrezzature_scientifiche_entry  as		  'VI_A3_Attrezzature_scientifiche', 

	@A4_Patrimonio_librario_prev  		as		  'I_A4_Patrimonio_librario',    
	@A4_Patrimonio_librario_var  		as		  'II_A4_Patrimonio_librario',  
	@A4_Patrimonio_librario_prev + @A4_Patrimonio_librario_var as 'III_A4_Patrimonio_librario', 
	@A4_Patrimonio_librario_preimp  	as		  'IV_A4_Patrimonio_librario',  	
	@A4_Patrimonio_librario_prev + @A4_Patrimonio_librario_var - @A4_Patrimonio_librario_preimp	as 'V_A4_Patrimonio_librario', 
	@A4_Patrimonio_librario_entry 	as		  'VI_A4_Patrimonio_librario', 
	@A4_Patrimonio_librario_preimp - @A4_Patrimonio_librario_entry 	as		  'VII_A4_Patrimonio_librario', 

	@A5_Mobili_arredi_prev  		as		  'I_A5_Mobili_arredi',   
	@A5_Mobili_arredi_var  			as		  'II_A5_Mobili_arredi',  
	@A5_Mobili_arredi_prev + @A5_Mobili_arredi_var as 'III_A5_Mobili_arredi', 
	@A5_Mobili_arredi_preimp  		as		  'IV_A5_Mobili_arredi',   	
	@A5_Mobili_arredi_prev + @A5_Mobili_arredi_var  - @A5_Mobili_arredi_preimp	as 'V_A5_Mobili_arredi', 
	@A5_Mobili_arredi_entry  		as		  'VI_A5_Mobili_arredi', 
	@A5_Mobili_arredi_preimp - @A5_Mobili_arredi_entry  		as		  'VII_A5_Mobili_arredi', 

	@A6_immobilizzazioni_materiali_corso_acconti_prev  		as		  'I_A6_immobilizzazioni_materiali_corso_acconti',    
	@A6_immobilizzazioni_materiali_corso_acconti_var  		as		  'II_A6_immobilizzazioni_materiali_corso_acconti',  
	@A6_immobilizzazioni_materiali_corso_acconti_prev + @A6_immobilizzazioni_materiali_corso_acconti_var	as  'III_A6_immobilizzazioni_materiali_corso_acconti',
	@A6_immobilizzazioni_materiali_corso_acconti_preimp  	as		  'IV_A6_immobilizzazioni_materiali_corso_acconti',	
	@A6_immobilizzazioni_materiali_corso_acconti_prev + @A6_immobilizzazioni_materiali_corso_acconti_var -@A6_immobilizzazioni_materiali_corso_acconti_preimp	as  'V_A6_immobilizzazioni_materiali_corso_acconti',
	@A6_immobilizzazioni_materiali_corso_acconti_entry 		as		  'VI_A6_immobilizzazioni_materiali_corso_acconti', 
	@A6_immobilizzazioni_materiali_corso_acconti_preimp - @A6_immobilizzazioni_materiali_corso_acconti_entry 		as		  'VII_A6_immobilizzazioni_materiali_corso_acconti', 

	@A7_Altre_immobilizzazioni_materiali_prev  		as		  'I_A7_Altre_immobilizzazioni_materiali',    
	@A7_Altre_immobilizzazioni_materiali_var  		as		  'II_A7_Altre_immobilizzazioni_materiali', 
	@A7_Altre_immobilizzazioni_materiali_prev + @A7_Altre_immobilizzazioni_materiali_var as	'III_A7_Altre_immobilizzazioni_materiali',
	@A7_Altre_immobilizzazioni_materiali_preimp  	as		  'IV_A7_Altre_immobilizzazioni_materiali', 	 
	@A7_Altre_immobilizzazioni_materiali_prev + @A7_Altre_immobilizzazioni_materiali_var -@A7_Altre_immobilizzazioni_materiali_preimp	as	'V_A7_Altre_immobilizzazioni_materiali', 
	@A7_Altre_immobilizzazioni_materiali_entry  		as		  'VI_A7_Altre_immobilizzazioni_materiali', 
	@A7_Altre_immobilizzazioni_materiali_preimp - @A7_Altre_immobilizzazioni_materiali_entry  		as		  'VII_A7_Altre_immobilizzazioni_materiali', 

	@A_TOT_MATERIALI_prev  		as		  'I_A_TOT_MATERIALI',    
	@A_TOT_MATERIALI_var  		as		  'II_A_TOT_MATERIALI',   
	@A_TOT_MATERIALI_prev + @A_TOT_MATERIALI_var as		  'III_A_TOT_MATERIALI',
	@A_TOT_MATERIALI_preimp  	as		  'IV_A_TOT_MATERIALI',   	  
	@A_TOT_MATERIALI_prev + @A_TOT_MATERIALI_var - @A_TOT_MATERIALI_preimp as		  'V_A_TOT_MATERIALI',  
	@A_TOT_MATERIALI_entry 		as		  'VI_A_TOT_MATERIALI',   
	@A_TOT_MATERIALI_preimp - @A_TOT_MATERIALI_entry 		as		  'VII_A_TOT_MATERIALI',   

	@A_IMMOBILIZZAZIONI_FINANZIARIE_prev  		as		  'I_A_IMMOBILIZZAZIONI_FINANZIARIE',   
	@A_IMMOBILIZZAZIONI_FINANZIARIE_var  		as		  'II_A_IMMOBILIZZAZIONI_FINANZIARIE',  
	@A_IMMOBILIZZAZIONI_FINANZIARIE_prev + @A_IMMOBILIZZAZIONI_FINANZIARIE_var	as	'III_A_IMMOBILIZZAZIONI_FINANZIARIE',  
	@A_IMMOBILIZZAZIONI_FINANZIARIE_preimp  	as		  'IV_A_IMMOBILIZZAZIONI_FINANZIARIE',   	 
	@A_IMMOBILIZZAZIONI_FINANZIARIE_prev + @A_IMMOBILIZZAZIONI_FINANZIARIE_var -@A_IMMOBILIZZAZIONI_FINANZIARIE_preimp	as	'V_A_IMMOBILIZZAZIONI_FINANZIARIE',  
	@A_IMMOBILIZZAZIONI_FINANZIARIE_entry  		as  'VI_A_IMMOBILIZZAZIONI_FINANZIARIE', 
	@A_IMMOBILIZZAZIONI_FINANZIARIE_preimp - @A_IMMOBILIZZAZIONI_FINANZIARIE_entry  		as  'VII_A_IMMOBILIZZAZIONI_FINANZIARIE', 

	@A_INVESTIMENTI_PERPROGETTIDIRICERCA_prev	as  'I_A_INVESTIMENTI_PERPROGETTIDIRICERCA',
	@A_INVESTIMENTI_PERPROGETTIDIRICERCA_var	as  'II_A_INVESTIMENTI_PERPROGETTIDIRICERCA',
	@A_INVESTIMENTI_PERPROGETTIDIRICERCA_prev + @A_INVESTIMENTI_PERPROGETTIDIRICERCA_var	as  'III_A_INVESTIMENTI_PERPROGETTIDIRICERCA',
	@A_INVESTIMENTI_PERPROGETTIDIRICERCA_preimp as  'IV_A_INVESTIMENTI_PERPROGETTIDIRICERCA',	
	@A_INVESTIMENTI_PERPROGETTIDIRICERCA_prev + @A_INVESTIMENTI_PERPROGETTIDIRICERCA_var -@A_INVESTIMENTI_PERPROGETTIDIRICERCA_preimp	as  'V_A_INVESTIMENTI_PERPROGETTIDIRICERCA',
	@A_INVESTIMENTI_PERPROGETTIDIRICERCA_entry	as  'VI_A_INVESTIMENTI_PERPROGETTIDIRICERCA',
	@A_INVESTIMENTI_PERPROGETTIDIRICERCA_preimp - @A_INVESTIMENTI_PERPROGETTIDIRICERCA_entry	as  'VII_A_INVESTIMENTI_PERPROGETTIDIRICERCA',

	@TOT_GENERALE_prev  		as	'I_TOT_GENERALE',  
	@TOT_GENERALE_var  			as	'II_TOT_GENERALE',
	@TOT_GENERALE_prev - @TOT_GENERALE_var as	'III_TOT_GENERALE',
	@TOT_GENERALE_preimp  		as	'IV_TOT_GENERALE', 	
	@TOT_GENERALE_prev - @TOT_GENERALE_var - @TOT_GENERALE_preimp as 'V_TOT_GENERALE'  	,
	@TOT_GENERALE_entry 		as	'VI_TOT_GENERALE' 		,
	@TOT_GENERALE_preimp - @TOT_GENERALE_entry 		as	'VII_TOT_GENERALE'
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 
