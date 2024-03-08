
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_situazioneupbaccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_situazioneupbaccount]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON  
GO
--setuser'amm'
--setuser 'amministrazione'
-- exp_situazioneupbaccount 2017, {ts '2017-12-31 00:00:00'}, 'C','%','N','N', '%','S'
-- exp_situazioneupbaccount 2017, {ts '2017-12-31 00:00:00'}, 'R','%','17000400010001000200010001','N', '%','S','N'

-- exp_situazioneupbaccount 2019, {ts '2019-05-27 00:00:00'}, 'C','%','S','N', 33, '%','N','N' -- @multiannual, @showonlyavailable
-- exp_situazioneupbaccount 2019, {ts '2019-05-27 00:00:00'}, 'C','%','S','N', '%','S','N' -- @multiannual, @showonlyavailable
-- exp_situazioneupbaccount 2023, {ts '2023-05-27 00:00:00'}, 'C','%','S','N', '%','S','N' -- @multiannual, @showonlyavailable
CREATE  PROCEDURE  [exp_situazioneupbaccount]
(
	@ayear int,
	@adate datetime, 
	@budgetpart char(1), -- Parte del Budget: Ricavi  o Costi
	@idupb varchar(38),
	@showupb char(1),
	@showchildupb char(1),
	@idman int,
	@codeacc varchar(50),   --- codeacc
	@multiannual char(1),
	@showonlyavailable char(1), -- Mostra solo disponibilità
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
	
)
AS 
BEGIN

declare @idacc varchar(38)
if (@codeacc = '%')
begin
	set @idacc = '%'
end
else
Begin
	set @idacc = (select idacc from account where codeacc = @codeacc and ayear = @ayear)
End

IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
BEGIN
	SET @idupb=@idupb+'%' 
END

-- minimo livello operativo
declare @nlevel int
set @nlevel = (select MIN(nlevel) from accountlevel where ayear = @ayear and flagusable = 'S')

declare @lenminlevel int
set @lenminlevel = 2 + 4*@nlevel
print @lenminlevel

-- massimo livello operativo
declare @maxnlevel int
set @maxnlevel = (select MAX(nlevel) from accountlevel where ayear = @ayear and flagusable = 'S')


CREATE TABLE #situazione_upb_account
(
	idupb varchar(36),
	idacc varchar(38),
	idman int,
	prevision decimal(19,2),
	varprev decimal(19,2),
	prevision2 decimal(19,2),
	varprev2 decimal(19,2),
	prevision3 decimal(19,2),
	varprev3 decimal(19,2),
	prevision4 decimal(19,2),
	varprev4 decimal(19,2),
	prevision5 decimal(19,2),
	varprev5 decimal(19,2),
	preimp_acc decimal(19,2), 
	preimp_acc_res decimal(19,2), 
	preimp_acc_comp decimal(19,2),
	preimp_acc2 decimal(19,2),
	preimp_acc3 decimal(19,2), 
	preimp_acc4 decimal(19,2), 
	preimp_acc5 decimal(19,2),
	imp_acc decimal(19,2),
	imp_acc2 decimal(19,2),
	imp_acc3 decimal(19,2),
	imp_acc4 decimal(19,2),
	imp_acc5 decimal(19,2),
	available  decimal(19,2),
	available2  decimal(19,2),
	available3  decimal(19,2),
	available4  decimal(19,2),
	available5  decimal(19,2) ,
	entryamount decimal(19,2)
)

		--PREVISIONI INIZIALI 
IF @budgetpart = 'C'

	INSERT INTO #situazione_upb_account
	(
 		idupb,	idacc, idman,
		prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
		preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
		preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
		imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
		available,	available2,	available3,	available4,	available5,
		entryamount   
	)

		select accountyear.idupb, accountyear.idacc, upb.idman,
		isnull(accountyear.prevision,0)  as prevision, 0 as varprev, 
		isnull(accountyear.prevision2,0) as prevision2, 0 as varprev2, 
		isnull(accountyear.prevision3,0) as prevision3, 0 as varprev3, 
		isnull(accountyear.prevision4,0) as prevision4, 0 as varprev4, 
		isnull(accountyear.prevision5,0) as prevision5, 0 as varprev5, 
		0 as preimp_acc, 0 as preimp_acc_res, 0 as preimp_acc_comp,	0 as preimp_acc2, 	0 as preimp_acc3, 	0 as preimp_acc4, 	0 as preimp_acc5, 
		0 as imp_acc,	0 as imp_acc2,	0 as imp_acc3,	0 as imp_acc4,	0 as imp_acc5,
		0 as available,	0 as available2,		0 as available3,		0 as available4,		0 as available5,
		0 as entryamount		 
		from accountyear
		join account A on accountyear.idacc=A.idacc 
		JOIN upb ON upb.idupb = accountyear.idupb  
		WHERE prevision IS NOT NULL AND accountyear.ayear = @ayear
			and A.flagaccountusage&320<>0  
		AND A.nlevel = @nlevel
		AND (upb.idman = @idman or @idman is null)
		and  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
			AND (upb.idupb like @idupb OR @idupb = '%') 
			AND (A.idacc like @idacc OR @idacc is null)
ELSE

	INSERT INTO #situazione_upb_account
	(
 		idupb,	idacc, idman,
		prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
		preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
		preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
		imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
		available,	available2,	available3,	available4,	available5,
		entryamount   
	)
	 

		select accountyear.idupb, accountyear.idacc, upb.idman,
		isnull(accountyear.prevision,0)  as prevision, 0 as varprev, 
		isnull(accountyear.prevision2,0) as prevision2, 0 as varprev2, 
		isnull(accountyear.prevision3,0) as prevision3, 0 as varprev3, 
		isnull(accountyear.prevision4,0) as prevision4, 0 as varprev4, 
		isnull(accountyear.prevision5,0) as prevision5, 0 as varprev5, 
		0 as preimp_acc, 0 as preimp_acc_res, 0 as preimp_acc_comp,	0 as preimp_acc2, 	0 as preimp_acc3, 	0 as preimp_acc4, 	0 as preimp_acc5, 
		0 as imp_acc,	0 as imp_acc2,	0 as imp_acc3,	0 as imp_acc4,	0 as imp_acc5,
		0 as available,	0 as available2,		0 as available3,		0 as available4,		0 as available5,
		0 as entryamount		 
		from accountyear
		join account A on accountyear.idacc=A.idacc 
		JOIN upb ON upb.idupb = accountyear.idupb  
		WHERE prevision IS NOT NULL AND accountyear.ayear = @ayear
			and A.flagaccountusage&128<>0  --ricavi
		AND A.nlevel = @nlevel
		AND (upb.idman = @idman or @idman is null)
		and  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
			AND (upb.idupb like @idupb OR @idupb = '%') 
			AND (A.idacc like @idacc OR @idacc is null)

 		--VARIAZIONI DI PREVISIONE NORMALI
IF @budgetpart = 'C'
	INSERT INTO #situazione_upb_account
	(
 		idupb,	idacc, idman,
		prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
		preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
		preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
		imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
		available,	available2,	available3,	available4,	available5,
		entryamount   
	)

		select D.idupb, D.idacc, upb.idman,
			0 as prevision,  sum(D.amount) as varprev, 
			0 as prevision2, sum(D.amount2) as varprev2, 
			0 as prevision3, sum(D.amount3) as varprev3, 
			0 as prevision4, sum(D.amount4) as varprev4, 
			0 as prevision5, sum(D.amount5) as varprev5, 
			0 as preimp_acc, 	0 as preimp_acc_res, 0 as preimp_acc_comp,	0 as preimp_acc2, 		0 as preimp_acc3, 		0 as preimp_acc4, 		0 as preimp_acc5, 
			0 as imp_acc,		0 as imp_acc2,		0 as imp_acc3,		0 as imp_acc4,		0 as imp_acc5,
			0 as available,		0 as available2,			0 as available3,			0 as available4,			0 as available5	,
			0 as entryamount
			from accountvardetail D 
			join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
			join account A on D.idacc=A.idacc 
			JOIN upb ON upb.idupb = D.idupb  
	  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
			AND (upb.idupb like @idupb OR @idupb = '%') 
			AND (D.idacc like @idacc OR @idacc is null)
			and  V.idaccountvarstatus = 5 and V.variationkind <> 5  AND V.yvar = @ayear AND V.adate<= @adate  
				and A.flagaccountusage&320<>0  --costi e immobilizzaz.
					  
			AND A.nlevel = @nlevel
			AND (upb.idman = @idman or @idman is null)
			group by D.idupb, D.idacc, upb.idman
ELSE
	INSERT INTO #situazione_upb_account
	(
 		idupb,	idacc, idman,
		prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
		preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
		preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
		imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
		available,	available2,	available3,	available4,	available5,
		entryamount   
	)
		--VARIAZIONI DI PREVISIONE NORMALI
		select D.idupb, D.idacc, upb.idman,
			0 as prevision,  sum(D.amount) as varprev, 
			0 as prevision2, sum(D.amount2) as varprev2, 
			0 as prevision3, sum(D.amount3) as varprev3, 
			0 as prevision4, sum(D.amount4) as varprev4, 
			0 as prevision5, sum(D.amount5) as varprev5, 
			0 as preimp_acc, 	0 as preimp_acc_res, 0 as preimp_acc_comp,	0 as preimp_acc2, 		0 as preimp_acc3, 		0 as preimp_acc4, 		0 as preimp_acc5, 
			0 as imp_acc,		0 as imp_acc2,		0 as imp_acc3,		0 as imp_acc4,		0 as imp_acc5,
			0 as available,		0 as available2,			0 as available3,			0 as available4,			0 as available5	,
			0 as entryamount
			from accountvardetail D 
			join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
			join account A on D.idacc=A.idacc 
			JOIN upb ON upb.idupb = D.idupb  
	  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
			AND (upb.idupb like @idupb OR @idupb = '%') 
			AND (D.idacc like @idacc OR @idacc is null)
			and  V.idaccountvarstatus = 5 and V.variationkind <> 5  AND V.yvar = @ayear AND V.adate<= @adate  
				and A.flagaccountusage&128<>0  --ricavi
			AND A.nlevel = @nlevel
			AND (upb.idman = @idman or @idman is null)
			group by D.idupb, D.idacc, upb.idman

-- IMPORTI INIZALI DI ESERCIZIO PREIMPEGNI 
-- flagvariation='N'
IF @budgetpart = 'C'
	INSERT INTO #situazione_upb_account
	(
 		idupb,	idacc, idman,
		prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
		preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
		preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
		imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
		available,	available2,	available3,	available4,	available5,
		entryamount   
	)

	
		SELECT EY.idupb, PARENT.idacc, upb.idman,
				0 as prevision  ,0 as varprev,			0 as prevision2 ,0 as varprev2,			0 as prevision3 ,0 as varprev3,		0 as prevision4 ,0 as varprev4,			0 as prevision5 ,0 as varprev5,
				SUM(EY.amount ) as preimp_acc, 
				SUM(case 
						when E.yepexp < @ayear  then EY.amount 
						else 0 END) as preimp_acc_res, 
				SUM(case
						when E.yepexp = @ayear then EY.amount  
						ELSE 0 END) as preimp_acc_comp, 
				SUM( EY.amount2) as preimp_acc2,    
				SUM(EY.amount3 ) as preimp_acc3,    
				SUM(EY.amount4 ) as preimp_acc4,    
				SUM(EY.amount5 ) as preimp_acc5,      
				0 as imp_acc,		0 as imp_acc2,		0 as imp_acc3,		0 as imp_acc4,		0 as imp_acc5,
				0 as available,			0 as available2,				0 as available3,				0 as available4,				0 as available5,
				0 as entryamount	
			FROM epexpyear EY
			JOIN account PARENT				ON PARENT.idacc = SUBSTRING(EY.idacc, 1, @lenminlevel)
			JOIN epexp E					ON E.idepexp = EY.idepexp
			JOIN upb ON upb.idupb = EY.idupb  
				and  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
					AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
					AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
					AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
					AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
					AND (upb.idupb like @idupb OR @idupb = '%') 
					AND (Parent.idacc like @idacc OR @idacc is null)
			WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate AND @budgetpart = 'C'
				and E.flagvariation='N'
				AND (upb.idman = @idman or @idman is null)
				group by EY.idupb, PARENT.idacc, upb.idman

-- flagvariation='S'
IF @budgetpart = 'C'
	INSERT INTO #situazione_upb_account
	(
 		idupb,	idacc, idman,
		prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
		preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
		preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
		imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
		available,	available2,	available3,	available4,	available5,
		entryamount   
	)

		SELECT EY.idupb, PARENT.idacc, upb.idman,
				0 as prevision  ,0 as varprev,			0 as prevision2 ,0 as varprev2,			0 as prevision3 ,0 as varprev3,		0 as prevision4 ,0 as varprev4,			0 as prevision5 ,0 as varprev5,
				SUM(-EY.amount ) as preimp_acc, 
				SUM(case 
						when E.yepexp < @ayear THEN  -EY.amount 
						else 0 END) as preimp_acc_res, 
				SUM(case
						when E.yepexp = @ayear then -EY.amount  
						ELSE 0 END) as preimp_acc_comp, 
				SUM( -EY.amount2 ) as preimp_acc2,    
				SUM(-EY.amount3 ) as preimp_acc3,    
				SUM(-EY.amount4 ) as preimp_acc4,    
				SUM(-EY.amount5 ) as preimp_acc5,      
				0 as imp_acc,		0 as imp_acc2,		0 as imp_acc3,		0 as imp_acc4,		0 as imp_acc5,
				0 as available,			0 as available2,				0 as available3,				0 as available4,				0 as available5,
				0 as entryamount	
		FROM epexpyear EY
		JOIN account PARENT				ON PARENT.idacc = SUBSTRING(EY.idacc, 1, @lenminlevel)
		JOIN epexp E					ON E.idepexp = EY.idepexp
		JOIN upb ON upb.idupb = EY.idupb  
		and  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
		AND (upb.idupb like @idupb OR @idupb = '%') 
		AND (Parent.idacc like @idacc OR @idacc is null)
		and E.flagvariation='S'
		WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate AND @budgetpart = 'C'
		AND (upb.idman = @idman or @idman is null)
		group by EY.idupb, PARENT.idacc, upb.idman


IF @budgetpart = 'C'	
	--importi variazioni nell'esercizio  PREIMPEGNI
	--E.flagvariation='N'
		INSERT INTO #situazione_upb_account
	(
 		idupb,	idacc, idman,
		prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
		preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
		preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
		imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
		available,	available2,	available3,	available4,	available5,
		entryamount   
	)	
		SELECT EY.idupb, PARENT.idacc, upb.idman,
				0 as prevision  ,0 as varprev,	0 as prevision2 ,0 as varprev2,	0 as prevision3 ,0 as varprev3,	0 as prevision4 ,0 as varprev4,	0 as prevision5 ,0 as varprev5,
				SUM(EV.amount) as preimp_acc, 
	 			SUM(case 
					when E.yepexp < @ayear then EV.amount 
					ELSE  0 END) as preimp_acc_res, 
				SUM(case 
					when E.yepexp = @ayear then EV.amount 
					else  0 END) as preimp_acc_comp, 
				SUM(EV.amount2 ) as preimp_acc2,    
				SUM(EV.amount3 ) as preimp_acc3,    
				SUM(EV.amount4 ) as preimp_acc4,    
				SUM(EV.amount5 ) as preimp_acc5,      
				0 as imp_acc,	0 as imp_acc2,	0 as imp_acc3,	0 as imp_acc4,	0 as imp_acc5,
				0 as available,0 as available2,	0 as available3,	0 as available4,	0 as available5	,
				0 as entryamount
		FROM epexpvar EV
		JOIN epexpyear EY	ON EY.ayear = EV.yvar AND EY.idepexp = EV.idepexp
		JOIN account PARENT	ON PARENT.idacc = SUBSTRING(EY.idacc, 1, @lenminlevel)
		JOIN epexp E		ON E.idepexp = EY.idepexp
	  JOIN upb ON upb.idupb = EY.idupb  
	  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
			AND (upb.idupb like @idupb OR @idupb = '%') 
			AND (parent.idacc like @idacc OR @idacc is null)
			AND (upb.idman = @idman or @idman is null)
		and E.nphase = 1 AND EY.ayear = @ayear AND E.adate <= @adate AND EV.adate<= @adate  AND @budgetpart = 'C' 
		and E.flagvariation='N'
		group by EY.idupb, PARENT.idacc, upb.idman
 

IF @budgetpart = 'C'
 	--E.flagvariation='S'
	INSERT INTO #situazione_upb_account
(
 	idupb,	idacc, idman,
	prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
	preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
	preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
	imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
	available,	available2,	available3,	available4,	available5,
	entryamount   
)
	
	SELECT EY.idupb, PARENT.idacc,  upb.idman,
			0 as prevision  ,0 as varprev,	0 as prevision2 ,0 as varprev2,	0 as prevision3 ,0 as varprev3,	0 as prevision4 ,0 as varprev4,	0 as prevision5 ,0 as varprev5,
			SUM(-EV.amount ) as preimp_acc, 
	 		SUM(case 
				when E.yepexp < @ayear THEN -EV.amount 
				ELSE  0 END) as preimp_acc_res, 
			SUM(case 
				when E.yepexp = @ayear then -EV.amount 
				else  0 END) as preimp_acc_comp, 
			SUM( -EV.amount2 ) as preimp_acc2,    
			SUM( -EV.amount3 ) as preimp_acc3,    
			SUM( -EV.amount4 ) as preimp_acc4,    
			SUM( -EV.amount5 ) as preimp_acc5,      
			0 as imp_acc,	0 as imp_acc2,	0 as imp_acc3,	0 as imp_acc4,	0 as imp_acc5,
			0 as available,0 as available2,	0 as available3,	0 as available4,	0 as available5	,
			0 as entryamount
	FROM epexpvar EV
	JOIN epexpyear EY	ON EY.ayear = EV.yvar AND EY.idepexp = EV.idepexp
	JOIN account PARENT	ON PARENT.idacc = SUBSTRING(EY.idacc, 1, @lenminlevel)
	JOIN epexp E		ON E.idepexp = EY.idepexp
  JOIN upb ON upb.idupb = EY.idupb  
  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
		AND (upb.idupb like @idupb OR @idupb = '%') 
		AND (parent.idacc like @idacc OR @idacc is null)
		AND (upb.idman = @idman or @idman is null)
	and E.nphase = 1 AND EY.ayear = @ayear AND E.adate <= @adate AND EV.adate<= @adate  AND @budgetpart = 'C' 
	and E.flagvariation='S'
	group by EY.idupb, PARENT.idacc, upb.idman

IF @budgetpart = 'C'
	--IMPORTI INIZIALI DI ESERCIZIO IMPEGNI
INSERT INTO #situazione_upb_account
(
 	idupb,	idacc, idman,
	prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
	preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
	preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
	imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
	available,	available2,	available3,	available4,	available5,
	entryamount   
)
	
	SELECT EY.idupb, PARENT.idacc,  upb.idman,
	0 as prevision  ,0 as varprev,0 as prevision2 ,0 as varprev2,	0 as prevision3 ,0 as varprev3,	0 as prevision4 ,0 as varprev4,	0 as prevision5 ,0 as varprev5,
	0 as preimp_acc, 0 as preimp_acc_res,0 as preimp_acc_comp, 0 as preimp_acc2, 	0 as preimp_acc3, 	0 as preimp_acc4, 	0 as preimp_acc5, 
	SUM(case when E.flagvariation='N' then EY.amount else -EY.amount  end) as imp_acc,
	SUM(case when E.flagvariation='N' then EY.amount2 else -EY.amount2 end) as imp_acc2,
	SUM(case when E.flagvariation='N' then EY.amount3 else -EY.amount3 end) as imp_acc3,
	SUM(case when E.flagvariation='N' then EY.amount4 else -EY.amount4 end) as imp_acc4,
	SUM(case when E.flagvariation='N' then EY.amount5 else -EY.amount5 end) as imp_acc5,
	0 as available,	0 as available2,	0 as available3,	0 as available4,	0 as available5	,
	0 as entryamount
	FROM epexpyear EY	
		JOIN account PARENT				ON PARENT.idacc = SUBSTRING(EY.idacc, 1, @lenminlevel)
		JOIN epexp E				ON E.idepexp = EY.idepexp
  JOIN upb ON upb.idupb = EY.idupb  
  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
		AND (upb.idupb like @idupb OR @idupb = '%') 
		AND (parent.idacc like @idacc OR @idacc is null)
		AND (upb.idman = @idman or @idman is null)
	and E.nphase = 2 AND EY.ayear = @ayear AND E.adate<= @adate  AND @budgetpart = 'C'
	group by EY.idupb, PARENT.idacc, upb.idman

IF @budgetpart = 'C'
	--importi variazioni nell'esercizio  IMPEGNI 	
	INSERT INTO #situazione_upb_account
	(
 		idupb,	idacc, idman,
		prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
		preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
		preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
		imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
		available,	available2,	available3,	available4,	available5,
		entryamount   
	)	
		
		SELECT EY.idupb, PARENT.idacc, upb.idman,
				0 as prevision  ,0 as varprev,	0 as prevision2 ,0 as varprev2,	0 as prevision3 ,0 as varprev3,	0 as prevision4 ,0 as varprev4,	0 as prevision5 ,0 as varprev5,
				0 as preimp_acc, 0 as preimp_acc_res,0 as preimp_acc_comp, 0 as preimp_acc2, 	0 as preimp_acc3, 	0 as preimp_acc4, 	0 as preimp_acc5,  
				SUM(case when E.flagvariation='N' then EV.amount else -EV.amount  end) as imp_acc,
				SUM(case when E.flagvariation='N' then EV.amount2 else -EV.amount2 end) as imp_acc2,
				SUM(case when E.flagvariation='N' then EV.amount3 else -EV.amount3 end) as imp_acc3,
				SUM(case when E.flagvariation='N' then EV.amount4 else -EV.amount4 end) as imp_acc4,
				SUM(case when E.flagvariation='N' then EV.amount5 else -EV.amount5 end) as imp_acc5,
				0 as available,0 as available2,	0 as available3,	0 as available4,	0 as available5	,
				0 as entryamount
		FROM epexpvar EV
		JOIN epexpyear EY	ON EY.ayear = EV.yvar AND EY.idepexp = EV.idepexp
		JOIN account PARENT	ON PARENT.idacc = SUBSTRING(EY.idacc, 1, @lenminlevel)
		JOIN epexp E		ON E.idepexp = EY.idepexp
		JOIN upb ON upb.idupb = EY.idupb  
	  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
			AND (upb.idupb like @idupb OR @idupb = '%') 
			AND (parent.idacc like @idacc OR @idacc is null)
			AND (upb.idman = @idman or @idman is null)
		and E.nphase = 2 AND EY.ayear = @ayear AND E.adate <= @adate AND EV.adate<= @adate  AND @budgetpart = 'C' 
		group by EY.idupb, PARENT.idacc, upb.idman
 /*
   JOIN upb ON upb.idupb = T.idupb  
  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
		AND (upb.idupb like @idupb OR @idupb = '%') 
		AND (T.idacc like @idacc OR @idacc is null)
		*/

IF @budgetpart = 'R'
INSERT INTO #situazione_upb_account
(
 	idupb,	idacc, idman,
	prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
	preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
	preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
	imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
	available,	available2,	available3,	available4,	available5,
	entryamount   
)
	--importi iniziali di esercizio PREACCERTAMENTI
	SELECT AY.idupb, PARENT.idacc, upb.idman,
			0 as prevision  ,0 as varprev,	0 as prevision2 ,0 as varprev2,	0 as prevision3 ,0 as varprev3,	0 as prevision4 ,0 as varprev4,	0 as prevision5 ,0 as varprev5,
			SUM(case when A.flagvariation='N' then AY.amount else -AY.amount end) as preimp_acc, 
	 		SUM(case 
				when A.yepacc < @ayear and A.flagvariation='N' then AY.amount 
				when A.yepacc < @ayear and A.flagvariation='S' then -AY.amount 
			ELSE 0 END) as preimp_acc_res, 
			SUM(case 
				when A.yepacc = @ayear and A.flagvariation='N' then AY.amount
				when A.yepacc = @ayear and A.flagvariation='S' then -AY.amount 
				ELSE 0 END) as preimp_acc_comp, 
			SUM(case when A.flagvariation='N' then AY.amount2 else -AY.amount2  end) as preimp_acc2,    
			SUM(case when A.flagvariation='N' then AY.amount3 else -AY.amount3 end) as preimp_acc3,    
			SUM(case when A.flagvariation='N' then AY.amount4 else -AY.amount4 end) as preimp_acc4,    
			SUM(case when A.flagvariation='N' then AY.amount5 else -AY.amount5 end) as preimp_acc5,      
			0 as imp_acc,	0 as imp_acc2,	0 as imp_acc3,	0 as imp_acc4,	0 as imp_acc5,
			0 as available,0 as available2,	0 as available3,	0 as available4,	0 as available5	,
			0 as entryamount
	FROM epaccyear AY		
	JOIN account PARENT	ON PARENT.idacc = SUBSTRING(AY.idacc, 1, @lenminlevel)
	JOIN epacc A		ON A.idepacc = AY.idepacc
   JOIN upb ON upb.idupb = AY.idupb  
  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
		AND (upb.idupb like @idupb OR @idupb = '%') 
		AND (parent.idacc like @idacc OR @idacc is null)
		AND (upb.idman = @idman or @idman is null)
	AND A.nphase = 1 AND AY.ayear = @ayear AND A.adate<= @adate  AND @budgetpart = 'R' 
					group by AY.idupb, PARENT.idacc, upb.idman


IF @budgetpart = 'R'
	INSERT INTO #situazione_upb_account
	(
 		idupb,	idacc, idman,
		prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
		preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
		preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
		imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
		available,	available2,	available3,	available4,	available5,
		entryamount   
	)

		--importi variazioni nell'esercizio  PREACCERTAMENTI
		SELECT AY.idupb, PARENT.idacc, upb.idman,
				0 as prevision  ,0 as varprev,	0 as prevision2 ,0 as varprev2,	0 as prevision3 ,0 as varprev3,	0 as prevision4 ,0 as varprev4,	0 as prevision5 ,0 as varprev5,
				SUM(case when A.flagvariation='N' then AV.amount else -AV.amount end) as preimp_acc, 
	 			SUM(case 
				when A.yepacc < @ayear and A.flagvariation='N' then AV.amount 
				when A.yepacc < @ayear and A.flagvariation='S' then -AV.amount 
				ELSE 0 END) as preimp_acc_res, 
				SUM(case 
					when A.yepacc = @ayear and A.flagvariation='N' then AV.amount 
					when A.yepacc = @ayear and A.flagvariation='S' then -AV.amount 
					ELSE 0 END) as preimp_acc_comp, 
				SUM(case when A.flagvariation='N' then AV.amount2 else -AV.amount2 end) as preimp_acc2,    
				SUM(case when A.flagvariation='N' then AV.amount3 else -AV.amount3 end) as preimp_acc3,    
				SUM(case when A.flagvariation='N' then AV.amount4 else -AV.amount4 end) as preimp_acc4,    
				SUM(case when A.flagvariation='N' then AV.amount5 else -AV.amount5 end) as preimp_acc5,      
				0 as imp_acc,	0 as imp_acc2,	0 as imp_acc3,	0 as imp_acc4,	0 as imp_acc5,
				0 as available,0 as available2,	0 as available3,	0 as available4,	0 as available5	,
				0 as entryamount
		FROM epaccvar AV
		JOIN epaccyear AY			ON AY.ayear = AV.yvar AND AY.idepacc = AV.idepacc
		JOIN account PARENT				ON PARENT.idacc = SUBSTRING(AY.idacc, 1, @lenminlevel)
		JOIN epacc A				ON A.idepacc = AY.idepacc
	   JOIN upb ON upb.idupb = AY.idupb  
	  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
			AND (upb.idupb like @idupb OR @idupb = '%') 
			AND (parent.idacc like @idacc OR @idacc is null)
			AND (upb.idman = @idman or @idman is null)
		and A.nphase = 1 AND AY.ayear = @ayear AND A.adate <= @adate AND AV.adate<= @adate  AND @budgetpart = 'R' 
		group by AY.idupb, PARENT.idacc, upb.idman

IF @budgetpart = 'C'
	INSERT INTO #situazione_upb_account
	(
 		idupb,	idacc, idman,
		prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
		preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
		preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
		imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
		available,	available2,	available3,	available4,	available5,
		entryamount   
	)
		-- coppie che hanno solo scritture
		select entrydetail.idupb, PARENT.idacc, upb.idman,
		0 as prevision  ,0 as varprev,0 as prevision2 ,0 as varprev2,0 as prevision3 ,0 as varprev3,0 as prevision4 ,0 as varprev4,	0 as prevision5 ,0 as varprev5,
		0 as preimp_acc, 0 as preimp_acc_res,0 as preimp_acc_comp, 	0 as preimp_acc2, 	0 as preimp_acc3, 	0 as preimp_acc4, 	0 as preimp_acc5, 
		0 as imp_acc,	0 as imp_acc2,	0 as imp_acc3,	0 as imp_acc4,	0 as imp_acc5,
		0 as available,	0 as available2,		0 as available3,		0 as available4,		0 as available5		 ,
		case when @budgetpart = 'R' then sum(amount) else -sum(amount) end  as entryamount
		from entrydetail
		join entry 
			on entrydetail.yentry = entry.yentry and  entrydetail.nentry = entry.nentry 
		JOIN account PARENT 
			ON PARENT.idacc = SUBSTRING(entrydetail.idacc, 1, @lenminlevel)
	   JOIN upb ON upb.idupb = entrydetail.idupb  
	  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
			AND (upb.idupb like @idupb OR @idupb = '%') 
			AND (parent.idacc like @idacc OR @idacc is null)
			AND (upb.idman = @idman or @idman is null)
		and entrydetail.yentry = @ayear
			and entry.adate<=@adate
			and  PARENT.flagaccountusage & 320 <>0  
		and entry.identrykind NOT IN (6,7,11,12)
		group by  entrydetail.idupb, PARENT.idacc, upb.idman
ELSE
	INSERT INTO #situazione_upb_account
	(
 		idupb,	idacc, idman,
		prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
		preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
		preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
		imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
		available,	available2,	available3,	available4,	available5,
		entryamount   
	)
		-- coppie che hanno solo scritture
		select entrydetail.idupb, PARENT.idacc, upb.idman,
		0 as prevision  ,0 as varprev,0 as prevision2 ,0 as varprev2,0 as prevision3 ,0 as varprev3,0 as prevision4 ,0 as varprev4,	0 as prevision5 ,0 as varprev5,
		0 as preimp_acc, 0 as preimp_acc_res,0 as preimp_acc_comp, 	0 as preimp_acc2, 	0 as preimp_acc3, 	0 as preimp_acc4, 	0 as preimp_acc5, 
		0 as imp_acc,	0 as imp_acc2,	0 as imp_acc3,	0 as imp_acc4,	0 as imp_acc5,
		0 as available,	0 as available2,		0 as available3,		0 as available4,		0 as available5		 ,
		case when @budgetpart = 'R' then sum(amount) else -sum(amount) end  as entryamount
		from entrydetail
		join entry 
			on entrydetail.yentry = entry.yentry and  entrydetail.nentry = entry.nentry 
		JOIN account PARENT 
			ON PARENT.idacc = SUBSTRING(entrydetail.idacc, 1, @lenminlevel)
	   JOIN upb ON upb.idupb = entrydetail.idupb  
	  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
			AND (upb.idupb like @idupb OR @idupb = '%') 
			AND (parent.idacc like @idacc OR @idacc is null)
			AND (upb.idman = @idman or @idman is null)
		and entrydetail.yentry = @ayear
			and entry.adate<=@adate
			and  PARENT.flagaccountusage & 128 <>0 
		and entry.identrykind<>11
		group by  entrydetail.idupb, PARENT.idacc, upb.idman

IF @budgetpart = 'R'
INSERT INTO #situazione_upb_account
(
 	idupb,	idacc, idman,
	prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
	preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
	preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
	imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
	available,	available2,	available3,	available4,	available5,
	entryamount   
)

	--importi iniziali di esercizio ACCERTAMENTI
	SELECT AY.idupb, PARENT.idacc,  upb.idman,
	0 as prevision  ,0 as varprev,0 as prevision2 ,0 as varprev2,0 as prevision3 ,0 as varprev3,0 as prevision4 ,0 as varprev4,	0 as prevision5 ,0 as varprev5,
	0 as preimp_acc, 0 as preimp_acc_res,0 as preimp_acc_comp, 	0 as preimp_acc2, 	0 as preimp_acc3, 	0 as preimp_acc4, 	0 as preimp_acc5, 
	SUM(case when A.flagvariation='N' then AY.amount else -AY.amount end) as imp_acc,
	SUM(case when A.flagvariation='N' then AY.amount2 else -AY.amount2 end) as imp_acc2,
	SUM(case when A.flagvariation='N' then AY.amount3 else -AY.amount3 end) as imp_acc3,
	SUM(case when A.flagvariation='N' then AY.amount4 else -AY.amount4 end) as imp_acc4,
	SUM(case when A.flagvariation='N' then AY.amount5 else -AY.amount5 end) as imp_acc5,
	0 as available,	0 as available2,		0 as available3, 0 as available4,		0 as available5	,
	0 as entryamount
	FROM epaccyear AY
			JOIN account PARENT	 ON PARENT.idacc = SUBSTRING(AY.idacc, 1, @lenminlevel)
			JOIN epacc A			ON A.idepacc = AY.idepacc
   JOIN upb ON upb.idupb = AY.idupb  
  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
		AND (upb.idupb like @idupb OR @idupb = '%') 
		AND (parent.idacc like @idacc OR @idacc is null)
		AND (upb.idman = @idman or @idman is null)
	and A.nphase = 2 AND AY.ayear = @ayear AND A.adate<= @adate AND @budgetpart = 'R'
	group by AY.idupb, PARENT.idacc, upb.idman
		
IF @budgetpart = 'R'
INSERT INTO #situazione_upb_account
(
 	idupb,	idacc, idman,
	prevision,	varprev,	prevision2,	varprev2,	prevision3,	varprev3,	prevision4,	varprev4,	prevision5,	varprev5,
	preimp_acc, 	preimp_acc_res, 	preimp_acc_comp,	
	preimp_acc2,	preimp_acc3, 	preimp_acc4, 	preimp_acc5,
	imp_acc,	imp_acc2,	imp_acc3,	imp_acc4,	imp_acc5,
	available,	available2,	available3,	available4,	available5,
	entryamount   
)

	--importi variazioni di esercizio ACCERTAMENTI
	SELECT AY.idupb, PARENT.idacc,  upb.idman,
	0 as prevision  ,0 as varprev,0 as prevision2 ,0 as varprev2,0 as prevision3 ,0 as varprev3,0 as prevision4 ,0 as varprev4,	0 as prevision5 ,0 as varprev5,
	0 as preimp_acc, 0 as preimp_acc_res,0 as preimp_acc_comp, 	0 as preimp_acc2, 	0 as preimp_acc3, 	0 as preimp_acc4, 	0 as preimp_acc5, 
	SUM(case when A.flagvariation='N' then AV.amount else -AV.amount end) as imp_acc,
	SUM(case when A.flagvariation='N' then AV.amount2 else -AV.amount2 end) as imp_acc2,
	SUM(case when A.flagvariation='N' then AV.amount3 else -AV.amount3 end) as imp_acc3,
	SUM(case when A.flagvariation='N' then AV.amount4 else -AV.amount4 end) as imp_acc4,
	SUM(case when A.flagvariation='N' then AV.amount5 else -AV.amount5 end) as imp_acc5,
	0 as available,	0 as available2,		0 as available3, 0 as available4,		0 as available5	,
	0 as entryamount
	FROM epaccvar AV 
		 JOIN epaccyear AY ON AV.idepacc = AY.idepacc
		 JOIN account PARENT	 ON PARENT.idacc = SUBSTRING(AY.idacc, 1, @lenminlevel)
		 JOIN epacc A			ON A.idepacc = AY.idepacc
	JOIN upb ON upb.idupb = AY.idupb  
  WHERE  (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
		AND (upb.idupb like @idupb OR @idupb = '%') 
		AND (AY.idacc like @idacc OR @idacc is null)
		AND (upb.idman = @idman or @idman is null)
		and  A.nphase = 2 AND AY.ayear = @ayear AND A.adate<= @adate AND AV.adate<= @adate  AND @budgetpart = 'R'
	group by AY.idupb, PARENT.idacc, upb.idman
		

DECLARE @StringSelect nvarchar(max)
DECLARE @NomeFase_1 nvarchar(30)
DECLARE @NomeFase_2 nvarchar(30)
DECLARE @ayearStr nvarchar(20)
DECLARE @ayear2Str nvarchar(20)
DECLARE @ayear3Str nvarchar(20)
DECLARE @ayear4Str nvarchar(20)
DECLARE @ayear5Str nvarchar(20)
DECLARE @NomeScritture nvarchar(40)
DECLARE @Preimp_NomeScritture nvarchar(150)
DECLARE @adateStr nvarchar(30)
SET @ayearStr   = CONVERT(nvarchar(4), @ayear)
SET @ayear2Str = CONVERT(nvarchar(4), @ayear +1)
SET @ayear3Str = CONVERT(nvarchar(4), @ayear +2)
SET @ayear4Str = CONVERT(nvarchar(4), @ayear +3)
SET @ayear5Str = CONVERT(nvarchar(4), @ayear +4)
SET @adateStr =  CONVERT(nvarchar(30), @adate, 113)
IF (ISNULL(@budgetpart,'C') = 'R')
BEGIN
	SET @NomeFase_1 = 'Preaccertamenti Budg. '
	SET @NomeFase_2 = 'Accertamenti Budg. '
	SET @NomeScritture = 'Scritture di Ricavo'
	SET @Preimp_NomeScritture = '(Preaccertato - Scritture di Ricavo)'
END

IF (ISNULL(@budgetpart,'C') = 'C')
BEGIN
	SET @NomeFase_1 = 'Preimpegni Budg. '
	SET @NomeFase_2 = 'Impegni Budg. '
	SET @NomeScritture = 'Scritture di Costi\Immobilizzazioni'
	SET @Preimp_NomeScritture = '(Preimpegnato - Scritture di Costi\Imm.)'
END

IF (isnull(@showonlyavailable,'N')='N')
Begin
				IF (ISNULL(@multiannual,'N') = 'S') 
				BEGIN

					SET @StringSelect = 
					' SELECT ' +
						' account.codeacc AS ''Codice Conto'',' +
						' account.title as ''Conto'','+
						' SE.sortcode  as ''Codice Budget Economico'','+	
						' SE.description  as ''Descrizione Budget Economico'','+	
						' SI.sortcode  as ''Codice Budget Investimenti'','+	
						' SI.description  as ''Descrizione Budget Investimenti'',' +
						' MAN.title as ''Responsabile'','

						IF (@showupb ='S') 
							BEGIN
								SET @StringSelect = @StringSelect +
								' upb.codeupb as ''Codice UPB'','+
								' upb.title as ''UPB'','+
								' epupbkind.title as ''Tipo UPB'','+
								' case when epupbkind.flag&1<>0 then''S'' else ''N'' end as ''Considera preimpegni di budget per assestamento'','+
								' upb.start as  ''Data inizio UPB'','+
								' upb.stop as  ''Data fine UPB'','+
								' upb.expiration as ''Data scadenza UPB'','+
								'	case '+
								'	when upb.flagactivity =''1'' then ''Istituzionale''	'+
								'	when upb.flagactivity =''2'' then ''Commerciale''	'+
								'	when upb.flagactivity =''4'' then ''Qualsiasi/Non specificata''	'+
								'	end as ''Attività UPB'','
							END

						SET @StringSelect = @StringSelect +
						' isnull(sum(T.prevision),0)  as ''Prev. Budget  ' + @ayearStr + ''','+
						' isnull(sum(T.varprev),0)   as ''Var.  Budget ' + @ayearStr + ''','+
						' isnull(sum(T.prevision),0) + isnull(sum(T.varprev),0)   as ''Budget corrente ' + @ayearStr + ''','+
						' isnull(sum(T.preimp_acc),0)  as ''Totale Imp. Corrente  '  + @NomeFase_1   + @ayearStr + ''','+
						' isnull(sum(T.preimp_acc_res),0)  as ''Imp. Corrente  '  + @NomeFase_1   + @ayearStr + ' (Creazione esercizi precedenti)' + ''','+
						' isnull(sum(T.preimp_acc_comp),0)  as ''Imp. Corrente  '  + @NomeFase_1   + @ayearStr + ' (Creazione esercizio corrente)' + ''','+
						' isnull(sum(T.imp_acc),0)	  as ''Imp. Corrente  '  + @NomeFase_2   + @ayearStr + ''','+ 
						' isnull(sum(T.prevision),0) + isnull(sum(T.varprev),0) - ' +
						' isnull(sum(T.preimp_acc),0)   as ''Budget  Disp. (Budget corrente- ' + @NomeFase_1  + @ayearStr + ')'','+

						' isnull(sum(T.entryamount),0) 	as ''' + @NomeScritture + /**/+ ''','+ 

						' isnull(sum(T.preimp_acc),0) - isnull(sum(T.entryamount),0)   as '''+@Preimp_NomeScritture +''''+','+

						' isnull(sum(T.prevision2),0)   as ''Prev. Budget ' + @ayear2Str + ''','+
						' isnull(sum(T.varprev2),0)   as ''Var.  Budget ' + @ayear2Str + ''','+
						' isnull(sum(T.prevision2),0) + isnull(sum(T.varprev2),0)   as ''Budget corrente ' + @ayear2Str + ''','+
						' isnull(sum(T.preimp_acc2),0) as ''Imp. Corrente '   + @NomeFase_1   + @ayear2Str + ''','+
						' isnull(sum(T.imp_acc2),0)	  as ''Imp. Corrente '   + @NomeFase_2   + @ayear2Str + ''','+  
						' isnull(sum(T.prevision2),0) + isnull(sum(T.varprev2),0) - '+
						' isnull(sum(T.preimp_acc2),0)   as ''Budget  Disp. (Budget corrente- ' + @NomeFase_1  + @ayear2Str + ')'','+
 
						' isnull(sum(T.prevision3),0)  as ''Prev. Budget '  + @ayear3Str + ''','+
						' isnull(sum(T.varprev3),0)   as ''Var.  Budget'  + @ayear3Str + ''','+
						' isnull(sum(T.prevision3),0)+ isnull(sum(T.varprev3),0)  as ''Budget corrente ' + @ayear3Str + ''','+
						' isnull(sum(T.preimp_acc3),0)  as ''Imp. Corrente '	+ @NomeFase_1   + @ayear3Str + ''','+
						' isnull(sum(T.imp_acc3),0)	  as ''Imp. Corrente '		+ @NomeFase_2   + @ayear3Str + ''','+  
						' isnull(sum(T.prevision3),0)+ isnull(sum(T.varprev3),0) - ' +
						' isnull(sum(T.preimp_acc3),0)   as ''Budget  Disp. (Budget corrente- ' +  @NomeFase_1  + @ayear3Str + ')'','+
 
						' isnull(sum(T.prevision4),0)  as ''Prev. Budget ' + @ayear4Str + ''','+
						' isnull(sum(T.varprev4),0)  as ''Var.  Budget ' + @ayear4Str + ''','+
						' isnull(sum(T.prevision4),0)+ isnull(sum(T.varprev4),0)   as ''Budget corrente ' + @ayear4Str + ''','+
						' isnull(sum(T.preimp_acc4),0)  as ''Imp. Corrente  '  + @NomeFase_1   + @ayear4Str +''','+
						' isnull(sum(T.imp_acc4),0)	   as ''Imp. Corrente ' + @NomeFase_2   + @ayear4Str +''','+   
						' isnull(sum(T.prevision4),0)+ isnull(sum(T.varprev4),0) - ' +
						' isnull(sum(T.preimp_acc4),0)   as ''Budget  Disp. (Budget corrente- ' +  @NomeFase_1  + @ayear4Str + ')'','+
 
						' isnull(sum(T.prevision5),0)  as ''Prev. Budget ' + @ayear5Str + ''','+
						' isnull(sum(T.varprev5),0)  as ''Var.  Budget ' + @ayear5Str + ''','+
						' isnull(sum(T.prevision5),0)+ isnull(sum(T.varprev5),0)   as ''Budget corrente ' + @ayear5Str + ''','+
						' isnull(sum(T.preimp_acc5),0)  as ''Imp. Corrente '  + @NomeFase_1   + @ayear5Str + ''','+
						' isnull(sum(T.imp_acc5),0)	  as ''Imp. Corrente ' + @NomeFase_2   + @ayear5Str + ''','+  
						' isnull(sum(T.prevision5),0)+ isnull(sum(T.varprev5),0) - ' +
						' isnull(sum(T.preimp_acc5),0)    as ''Budget  Disp. (Budget corrente- ' +  @NomeFase_1  + @ayear5Str + ')''' 
				--TOTALE Budget  Disp. Pluriennale (Budget corrente- Preimpegni Budg. )
						+','+
						'   isnull(sum(T.prevision),0) + isnull(sum(T.varprev),0) - isnull(sum(T.preimp_acc),0) '+
						' + isnull(sum(T.prevision2),0) + isnull(sum(T.varprev2),0) -isnull(sum(T.preimp_acc2),0) '+
						' + isnull(sum(T.prevision3),0) + isnull(sum(T.varprev3),0) -isnull(sum(T.preimp_acc3),0) '+
						' + isnull(sum(T.prevision4),0) + isnull(sum(T.varprev4),0) -isnull(sum(T.preimp_acc4),0) '+
						' + isnull(sum(T.prevision5),0) + isnull(sum(T.varprev5),0) -isnull(sum(T.preimp_acc5),0) '+
						'  as ''TOTALE Budget  Disp. Pluriennale (Budget corrente- ' + @NomeFase_1 + ')'''+
						','+
						'  isnull(sum(T.preimp_acc),0)+isnull(sum(T.preimp_acc2),0)+isnull(sum(T.preimp_acc3),0)+isnull(sum(T.preimp_acc4),0)+isnull(sum(T.preimp_acc5),0) - isnull(sum(T.entryamount),0) as  ''TOTALE '+ @Preimp_NomeScritture +''''
		
				END 
				ELSE
				BEGIN
					SET @StringSelect = ' SELECT ' +
						' account.codeacc AS ''Codice Conto'',' +
						' account.title as ''Conto'','+
						' SE.sortcode  as ''Codice Budget Economico'','+	
						' SE.description  as ''Descrizione Budget Economico'','+	
						' SI.sortcode  as ''Codice Budget Investimenti'','+	
						' SI.description  as ''Descrizione Budget Investimenti'',' +
						' MAN.title as ''Responsabile'','

						IF (@showupb ='S') 
							BEGIN
								SET @StringSelect = @StringSelect +
								' upb.codeupb as ''Codice UPB'','+
								' upb.title as ''UPB'','+
								' epupbkind.title as ''Tipo UPB'','+
								' upb.start as  ''Data inizio UPB'','+
								' upb.stop as  ''Data fine UPB'','+
								' upb.expiration as ''Data scadenza UPB'','+
								' case when epupbkind.flag&1<>0 then''S'' else ''N'' end as ''Considera preimpegni di budget per assestamento'','+
								'	case '+
								'	when upb.flagactivity =''1'' then ''Istituzionale''	'+
								'	when upb.flagactivity =''2'' then ''Commerciale''	'+
								'	when upb.flagactivity =''4'' then ''Qualsiasi/Non specificata''	'+
								'	end as ''Attività UPB'','
							END

						SET @StringSelect = @StringSelect +
						' isnull(sum(T.prevision),0)  as ''Prev. Budget ' + @ayearStr + ''','+
						' isnull(sum(T.varprev),0)   as ''Var.  Budget ' + @ayearStr + ''','+
						' isnull(sum(T.prevision),0)+ isnull(sum(T.varprev),0)   as ''Budget corrente ' + @ayearStr + ''','+
						' isnull(sum(T.preimp_acc),0)  as ''Totale Imp. Corrente '  + @NomeFase_1   + @ayearStr + ''','+
						' isnull(sum(T.preimp_acc_res),0)  as ''Imp. Corrente '  + @NomeFase_1   + @ayearStr + ' (Creazione esercizi precedenti)' + ''','+
						' isnull(sum(T.preimp_acc_comp),0)  as ''Imp. Corrente '  + @NomeFase_1   + @ayearStr + ' (Creazione esercizio corrente)' + ''','+
						' isnull(sum(T.imp_acc),0)	  as ''Imp. Corrente '  + @NomeFase_2   + @ayearStr + ''','+ 
						' isnull(sum(T.prevision),0)+ isnull(sum(T.varprev),0) - ' + 
						' isnull(sum(T.preimp_acc),0)   as ''Budget  Disp. (Budget corrente- ' + @NomeFase_1  + @ayearStr + ')' + ''','+  

						' isnull(sum(T.entryamount),0)	as ''' + @NomeScritture + /**/+ ''','+ 

						' isnull(sum(T.preimp_acc),0) - isnull(sum(T.entryamount),0) as '''+@Preimp_NomeScritture +''''
	
							+','+
							' isnull(sum(T.prevision),0) + isnull(sum(T.varprev),0) - isnull(sum(T.preimp_acc),0) '+
							' + isnull(sum(T.prevision2),0) + isnull(sum(T.varprev2),0) -isnull(sum(T.preimp_acc2),0) '+
							' + isnull(sum(T.prevision3),0) + isnull(sum(T.varprev3),0) -isnull(sum(T.preimp_acc3),0) '+
							' + isnull(sum(T.prevision4),0) + isnull(sum(T.varprev4),0) -isnull(sum(T.preimp_acc4),0) '+
							' + isnull(sum(T.prevision5),0) + isnull(sum(T.varprev5),0) -isnull(sum(T.preimp_acc5),0) '+
							' as ''TOTALE Budget  Disp. Pluriennale  (Budget corrente- ' + @NomeFase_1 + ')'''
						+','+
						'  isnull(sum(T.preimp_acc),0)+isnull(sum(T.preimp_acc2),0)+isnull(sum(T.preimp_acc3),0)+isnull(sum(T.preimp_acc4),0)+isnull(sum(T.preimp_acc5),0) - isnull(sum(T.entryamount),0)  as  ''TOTALE '+ @Preimp_NomeScritture +''''

	
				END
 
End
IF (isnull(@showonlyavailable,'N')='S') -- Mostra solo disponibilità ha poche colonne
Begin
				IF (ISNULL(@multiannual,'N') = 'S') 
				BEGIN

					SET @StringSelect = 
					' SELECT ' +
						' account.codeacc AS ''Codice Conto'',' +
						' account.title as ''Conto'',' +
						' MAN.title as ''Responsabile'','

						IF (@showupb ='S') 
							BEGIN
								SET @StringSelect = @StringSelect +
								' upb.codeupb as ''Codice UPB'','+
								' upb.title as ''UPB'','
							END

						SET @StringSelect = @StringSelect +
						' isnull(sum(T.prevision),0) + isnull(sum(T.varprev),0) - isnull(sum(T.preimp_acc),0)   as ''Budget  Disp. (Budget corrente- ' + @NomeFase_1  + @ayearStr + ')'','+
						' isnull(sum(T.prevision2),0) + isnull(sum(T.varprev2),0) - isnull(sum(T.preimp_acc2),0)   as ''Budget  Disp. (Budget corrente- ' + @NomeFase_1  + @ayear2Str + ')'','+
						' isnull(sum(T.prevision3),0) + isnull(sum(T.varprev3),0) - isnull(sum(T.preimp_acc3),0)   as ''Budget  Disp. (Budget corrente- ' +  @NomeFase_1  + @ayear3Str + ')'','+
						' isnull(sum(T.prevision4),0) + isnull(sum(T.varprev4),0) -  isnull(sum(T.preimp_acc4),0)   as ''Budget  Disp. (Budget corrente- ' +  @NomeFase_1  + @ayear4Str + ')'','+
						' isnull(sum(T.prevision5),0) + isnull(sum(T.varprev5),0) - isnull(sum(T.preimp_acc5),0)    as ''Budget  Disp. (Budget corrente- ' +  @NomeFase_1  + @ayear5Str + ')''' 

						+','+
						'   isnull(sum(T.prevision),0) + isnull(sum(T.varprev),0) - isnull(sum(T.preimp_acc),0) '+
						' + isnull(sum(T.prevision2),0) + isnull(sum(T.varprev2),0) -isnull(sum(T.preimp_acc2),0) '+
						' + isnull(sum(T.prevision3),0) + isnull(sum(T.varprev3),0) -isnull(sum(T.preimp_acc3),0) '+
						' + isnull(sum(T.prevision4),0) + isnull(sum(T.varprev4),0) -isnull(sum(T.preimp_acc4),0) '+
						' + isnull(sum(T.prevision5),0) + isnull(sum(T.varprev5),0) -isnull(sum(T.preimp_acc5),0) '+
						'  as ''TOTALE Budget  Disp. Pluriennale  (Budget corrente- ' + @NomeFase_1 + ')'''+
						','+
						'  isnull(sum(T.preimp_acc),0)+isnull(sum(T.preimp_acc2),0)+isnull(sum(T.preimp_acc3),0)+isnull(sum(T.preimp_acc4),0)+isnull(sum(T.preimp_acc5),0) - isnull(sum(T.entryamount),0) as  ''TOTALE '+ @Preimp_NomeScritture +''''
		
				END 
				ELSE
				BEGIN
					SET @StringSelect = ' SELECT ' +
						' account.codeacc AS ''Codice Conto'',' +
						' account.title as ''Conto'',' + 
						' MAN.title as ''Responsabile'','

						IF (@showupb ='S') 
							BEGIN
								SET @StringSelect = @StringSelect +
								' upb.codeupb as ''Codice UPB'','+
								' upb.title as ''UPB'','
							END

						SET @StringSelect = @StringSelect +
						' isnull(sum(T.prevision),0) + isnull(sum(T.varprev),0) - isnull(sum(T.preimp_acc),0)   as ''Budget  Disp. (Budget corrente- ' + @NomeFase_1  + @ayearStr + ')'','+
						' isnull(sum(T.prevision),0) + isnull(sum(T.varprev),0) - isnull(sum(T.preimp_acc),0) '+
						' + isnull(sum(T.prevision2),0) + isnull(sum(T.varprev2),0) -isnull(sum(T.preimp_acc2),0) '+
						' + isnull(sum(T.prevision3),0) + isnull(sum(T.varprev3),0) -isnull(sum(T.preimp_acc3),0) '+
						' + isnull(sum(T.prevision4),0) + isnull(sum(T.varprev4),0) -isnull(sum(T.preimp_acc4),0) '+
						' + isnull(sum(T.prevision5),0) + isnull(sum(T.varprev5),0) -isnull(sum(T.preimp_acc5),0) '+
						' as ''TOTALE Budget  Disp. Pluriennale (Budget corrente- ' + @NomeFase_1 + ')'''
						+','+
						' isnull(sum(T.preimp_acc),0) - isnull(sum(T.entryamount),0) as '''+@Preimp_NomeScritture + /* new*/+''''+
						+','+
						' isnull(sum(T.preimp_acc),0)+isnull(sum(T.preimp_acc2),0)+isnull(sum(T.preimp_acc3),0)+isnull(sum(T.preimp_acc4),0)+isnull(sum(T.preimp_acc5),0) - isnull(sum(T.entryamount),0) as  ''TOTALE '+ @Preimp_NomeScritture +''''

				END
End


 
DECLARE @StringFrom nvarchar(3000)
/*
	SET @StringSelect = ' SELECT ' +
		' account.codeacc AS ''Codice Conto'',' +
		' account.title as ''Conto'','+
		' SE.sortcode  as ''Codice Budget Economico'','+	
		' SE.description  as ''Descrizione Budget Economico'','+	
		' SI.sortcode  as ''Codice Budget Investimenti'','+	
		' SI.description  as ''Descrizione Budget Investimenti'','
*/
 SET @StringFrom = ' FROM #situazione_upb_account T ' +
' JOIN account on account.idacc = T.idacc ' +
' LEFT OUTER JOIN sorting SE on account.idsor_economicbudget = SE.idsor '  + 
' LEFT OUTER JOIN sorting SI on account.idsor_investmentbudget = SI.idsor '  + 
' LEFT OUTER JOIN manager MAN on MAN.idman = T.idman' +
' GROUP BY	account.ayear, ' +
			' account.idacc,	account.codeacc, account.title, MAN.title,' +
			' SE.sortcode, SE.description, SI.sortcode, SI.description '

IF (@showupb ='S') 
	BEGIN
		SET @StringFrom = 
		' FROM #situazione_upb_account T ' +
		' JOIN upb ON upb.idupb = T.idupb ' +
		' JOIN account on account.idacc = T.idacc ' +
		' LEFT OUTER JOIN sorting SE on account.idsor_economicbudget = SE.idsor '  + 
		' LEFT OUTER JOIN sorting SI on account.idsor_investmentbudget = SI.idsor '  + 
		' LEFT OUTER JOIN epupbkind ON epupbkind.idepupbkind = upb.idepupbkind '+
		' LEFT OUTER JOIN manager MAN on MAN.idman = T.idman' +
		' GROUP BY	account.ayear, ' +
					' account.idacc,	account.codeacc, account.title, MAN.title,' +
					' upb.idupb, upb.codeupb, upb.title, SE.sortcode, SE.description, SI.sortcode, SI.description, '+
					' epupbkind.title, upb.start, upb.stop , upb.expiration,upb.flagactivity, epupbkind.flag '
	END
		PRINT   @StringSelect
		PRINT   @StringFrom
		DECLARE @StringSql NVARCHAR(max) 
		SET @StringSql =@StringSelect + @StringFrom
		EXEC sp_executesql 
		@stmt = @StringSql
		
END


GO



