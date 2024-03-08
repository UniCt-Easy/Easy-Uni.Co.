
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_balancebudgetvar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_balancebudgetvar]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE      PROCEDURE [compute_balancebudgetvar]
(
	@ayear int,
	@adate date,
	@assestamento char(1)='N',
	@generatevar char(1) ='N',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS 
BEGIN

declare @minlevel int 
select @minlevel = min(nlevel) from accountlevel where ayear =@ayear and flagusable='S'

declare @lenaccount int
set @lenaccount =2+@minlevel*4


DECLARE @nextayear int
SET	@nextayear = @ayear + 1

CREATE TABLE #situazione_upb_account
(
	idupb varchar(36),	idacc varchar(38),
	prev decimal(19,2),	
	prev2 decimal(19,2),	
	prev3 decimal(19,2),	
	prev4 decimal(19,2),
	prev5 decimal(19,2),	
	pre_mov decimal(19,2),
	pre_mov2 decimal(19,2),
	pre_mov3 decimal(19,2),
	pre_mov4 decimal(19,2),
	pre_mov5 decimal(19,2),
	scritture decimal(19,2),
	variazioni_esistenti decimal(19,2),
	variazioni_esistenti2 decimal(19,2),
	variazioni_esistenti3 decimal(19,2),
	variazioni_esistenti4 decimal(19,2),
	variazioni_esistenti5 decimal(19,2)
)

-- PREVISIONI INIZIALI SPESA (Costi, Immobilizzazioni, Accantonamenti)
-- IMPORTI CORRENTI PREIMPEGNI, per le upb con tipo upb

INSERT INTO #situazione_upb_account(
 	idupb,	idacc,
	prev,prev2,prev3,prev4,prev5
)
	 
SELECT
	AY.idupb, AL.newidacc,
	sum(AY.prevision), sum(AY.prevision2), sum(AY.prevision3), sum(AY.prevision4), sum(AY.prevision5)
	from accountyear AY
	join account A on AY.idacc=A.idacc 
	JOIN upb  ON upb.idupb = AY.idupb  
	join accountlookup AL  	on AL.oldidacc = A.idacc
	JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
	WHERE AY.ayear= @ayear
		--and Upb.idepupbkind is not null /* VINCOLATO */
		and (epupbkind.flag &1 = 0) /* VINCOLATO */
		and (A.flagaccountusage & (64+128+256))<>0  and (A.flagaccountusage & 131072)=0  /*costi, immobilizzazioni e accantonamenti*/
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
		AND len(AY.idacc)=@lenaccount
group by AY.idupb,AL.newidacc


INSERT INTO #situazione_upb_account(
 	idupb,	idacc,
	prev,prev2,prev3,prev4,prev5
)
	 
SELECT
	AVD.idupb, substring(AL.newidacc,1,@lenaccount),
	sum(AVD.amount), sum(AVD.amount2), sum(AVD.amount3), sum(AVD.amount4), sum(AVD.amount5)
	from accountvardetail AVD
	join accountvar AV on AV.yvar=AVD.yvar and AV.nvar=AVD.nvar
	join account A on AVD.idacc=A.idacc 
	JOIN upb  ON upb.idupb = AVD.idupb  
	join accountlookup AL  	on AL.oldidacc = A.idacc
	JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
	WHERE AV.yvar= @ayear
		and AV.adate <= @adate 
		--and Upb.idepupbkind is not null /* VINCOLATO */
		and (epupbkind.flag &1 = 0) /* VINCOLATO */
		and AV.idaccountvarstatus=5 
		and av.variationkind<>5
		and (A.flagaccountusage & (64+128+256))<>0  and (A.flagaccountusage & 131072)=0  /*costi, immobilizzazioni e accantonamenti*/
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
group by AVD.idupb,substring(AL.newidacc,1,@lenaccount)


-- IMPORTI CORRENTI PREIMPEGNI, per le upb senza tipo upb
INSERT INTO #situazione_upb_account(
 	idupb,
	idacc,
	pre_mov,pre_mov2,pre_mov3,pre_mov4,pre_mov5
	)
SELECT EY.idupb, substring(AL.newidacc,1,@lenaccount),
	SUM(case when E.flagvariation='N' then EY.amount else -EY.amount end),
	SUM(case when E.flagvariation='N' then EY.amount2 else -EY.amount2 end),
	SUM(case when E.flagvariation='N' then EY.amount3 else -EY.amount3 end),
	SUM(case when E.flagvariation='N' then EY.amount4 else -EY.amount4 end),
	SUM(case when E.flagvariation='N' then EY.amount5 else -EY.amount5 end)
	FROM epexpyear EY				
	JOIN upb			ON upb.idupb = EY.idupb  
	JOIN epexp E		ON E.idepexp = EY.idepexp
	join account A		on EY.idacc=A.idacc 
	join accountlookup AL  	on AL.oldidacc = EY.idacc
	left outer JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
	WHERE E.nphase = 1 AND EY.ayear = @ayear
		AND E.adate <= @adate
		and (Upb.idepupbkind is  null  or (epupbkind.flag &1 <> 0) )/* LIBERO */
		and (A.flagaccountusage & (64+128+256))<>0  and (A.flagaccountusage & 131072)=0  /*costi, immobilizzazioni e accantonamenti*/
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
group by EY.idupb, substring(AL.newidacc,1,@lenaccount)


INSERT INTO #situazione_upb_account(
 	idupb,
	idacc,
	pre_mov,pre_mov2,pre_mov3,pre_mov4,pre_mov5
	)
SELECT EY.idupb, substring(AL.newidacc,1,@lenaccount),
	SUM(case when E.flagvariation='N' then EV.amount else -EV.amount end),
	SUM(case when E.flagvariation='N' then EV.amount2 else -EV.amount2 end),
	SUM(case when E.flagvariation='N' then EV.amount3 else -EV.amount3 end),
	SUM(case when E.flagvariation='N' then EV.amount4 else -EV.amount4 end),
	SUM(case when E.flagvariation='N' then EV.amount5 else -EV.amount5 end)
	FROM epexpyear EY				
	join epexpvar EV on EV.idepexp=EY.idepexp
	JOIN upb			ON upb.idupb = EY.idupb  
	JOIN epexp E		ON E.idepexp = EY.idepexp
	join account A		on EY.idacc=A.idacc 
	join accountlookup AL  	on AL.oldidacc = EY.idacc
	left outer JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
	WHERE E.nphase = 1 AND EY.ayear = @ayear
		AND EV.yvar=@ayear  AND EV.adate <= @adate
		and (Upb.idepupbkind is  null  or (epupbkind.flag &1 <> 0) )/* LIBERO */
		and (A.flagaccountusage & (64+128+256))<>0  and (A.flagaccountusage & 131072)=0  /*costi, immobilizzazioni e accantonamenti*/
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
group by EY.idupb,  substring(AL.newidacc,1,@lenaccount)



--importi correnti PREACCERTAMENTI
INSERT INTO #situazione_upb_account(
 	idupb,	idacc,
	pre_mov,pre_mov2,pre_mov3,pre_mov4,pre_mov5
	)
SELECT AY.idupb, substring(AL.newidacc,1,@lenaccount),
	SUM(case when AA.flagvariation='N' then AY.amount else -AY.amount end),
	SUM(case when AA.flagvariation='N' then AY.amount2 else -AY.amount2 end),
	SUM(case when AA.flagvariation='N' then AY.amount3 else -AY.amount3 end),
	SUM(case when AA.flagvariation='N' then AY.amount4 else -AY.amount4 end),
	SUM(case when AA.flagvariation='N' then AY.amount5 else -AY.amount5 end)
FROM epaccyear AY			
	JOIN upb				ON upb.idupb = AY.idupb  
	JOIN epacc AA			ON AA.idepacc = AY.idepacc
	join account A		on AY.idacc=A.idacc 
	join accountlookup AL  	on AL.oldidacc = AY.idacc
	left outer JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
WHERE   AA.nphase = 1 AND AY.ayear = @ayear
		AND AA.adate <= @adate
		and (Upb.idepupbkind is  null  or (epupbkind.flag &1 <> 0) )/* LIBERO */
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
group by AY.idupb,substring(AL.newidacc,1,@lenaccount)


INSERT INTO #situazione_upb_account(
 	idupb,
	idacc,
	pre_mov,pre_mov2,pre_mov3,pre_mov4,pre_mov5
	)
SELECT EY.idupb,substring(AL.newidacc,1,@lenaccount),
	SUM(case when E.flagvariation='N' then EV.amount else -EV.amount end),
	SUM(case when E.flagvariation='N' then EV.amount2 else -EV.amount2 end),
	SUM(case when E.flagvariation='N' then EV.amount3 else -EV.amount3 end),
	SUM(case when E.flagvariation='N' then EV.amount4 else -EV.amount4 end),
	SUM(case when E.flagvariation='N' then EV.amount5 else -EV.amount5 end)
	FROM epaccyear EY				
	join epaccvar EV	on EV.idepacc=EY.idepacc
	JOIN upb			ON upb.idupb = EY.idupb  
	JOIN epacc E		ON E.idepacc = EY.idepacc	
	join account A		on EY.idacc=A.idacc 
	join accountlookup AL  	on AL.oldidacc = EY.idacc
	left outer JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
	WHERE E.nphase = 1 AND EY.ayear = @ayear
		AND EV.yvar=@ayear  AND EV.adate <= @adate
		and (Upb.idepupbkind is  null  or (epupbkind.flag &1 <> 0) )/* LIBERO */
		and (A.flagaccountusage & (64+128+256))<>0  and (A.flagaccountusage & 131072)=0  /*costi, immobilizzazioni e accantonamenti*/
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
group by EY.idupb,substring(AL.newidacc,1,@lenaccount)



INSERT INTO #situazione_upb_account( 	idupb,	idacc,	scritture	)
SELECT ED.idupb,substring(AL.newidacc,1,@lenaccount),
	sum(case when (A.flagaccountusage & 128) <> 0 then ED.amount else -ED.amount end)  --i costi si movimentano normalmente in dare quindi li cambiamo di segno
FROM entrydetail ED
	join entry E			on ED.yentry=E.yentry and ED.nentry=E.nentry
	JOIN upb				ON upb.idupb = ED.idupb  
	JOIN account A			ON A.idacc = substring(ED.idacc,1,@lenaccount)	
	join accountlookup AL  	on AL.oldidacc = ED.idacc
WHERE   E.yentry = @ayear
		AND E.adate <= @adate
		and (A.flagaccountusage & (64+128+256))<>0  and (A.flagaccountusage & 131072)=0  /*costi, immobilizzazioni e accantonamenti*/
		and E.identrykind <> 7
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
group by ED.idupb, substring(AL.newidacc,1,@lenaccount)

declare @tipovariazione int
if (@assestamento='S') begin
	set @tipovariazione=3		--assestamento
	insert into  #situazione_upb_account( 	idupb,	idacc,
		variazioni_esistenti,variazioni_esistenti2,variazioni_esistenti3,variazioni_esistenti4,variazioni_esistenti5	)
	select  AVD.idupb, AVD.idacc, 
	sum(AVD.amount),sum(AVD.amount2),sum(AVD.amount3),sum(AVD.amount4),sum(AVD.amount5)
	FROM accountvardetail AVD
	join accountvar AV			on AVD.yvar=AV.yvar and AVD.nvar=AV.nvar
	JOIN upb				ON upb.idupb = AVD.idupb  
	where  AVD.yvar = @nextayear
		--AND E.adate <= @adate
		AND AV.variationkind = 3
		and  AV.idaccountvarstatus=5
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
group by AVD.idupb, AVD.idacc
end
else begin
	set @tipovariazione=5		--iniziale
end

--da sottrarre comunque
insert into  #situazione_upb_account( 	idupb,	idacc,
	variazioni_esistenti,variazioni_esistenti2,variazioni_esistenti3,variazioni_esistenti4,variazioni_esistenti5	)
	select  AVD.idupb, AVD.idacc, 
	sum(AVD.amount),sum(AVD.amount2),sum(AVD.amount3),sum(AVD.amount4),sum(AVD.amount5)
	FROM accountvardetail AVD
	join accountvar AV			on AVD.yvar=AV.yvar and AVD.nvar=AV.nvar
	JOIN upb				ON upb.idupb = AVD.idupb  
	where  AVD.yvar = @nextayear
		--AND E.adate <= @adate
		AND AV.variationkind = 5
		and (AV.idaccountvarstatus=5 )
		and (AV.flag & 1)<>0
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 		
	group by AVD.idupb, AVD.idacc

--select  * from entrykind


declare @nmaxvar int
select @nmaxvar = max(nvar) from accountvar where yvar=@nextayear
if @nmaxvar is null  set @nmaxvar=0
 
declare @oggi date
set @oggi= getdate();

declare @day1 date
set @day1 =  CONVERT(date, '01-01-' + CONVERT(char(4), @nextayear), 105)

--select * from #situazione_upb_account where idupb='0001000100250589' and idacc='190004000100010002'  

 if ( (select count(*) from #situazione_upb_account )<>0 and @generatevar='S')
 Begin
	set @nmaxvar = @nmaxvar + 1
	insert into accountvar(yvar, nvar, adate, description,  idaccountvarstatus, idman, 
				idsor01, idsor02, idsor03, idsor04,idsor05, variationkind,flag,
				ct, cu, lt, lu)
				
	values (@nextayear, @nmaxvar,
				case when @assestamento='S' then @oggi else @day1 end, 
				case when @assestamento='S' then 'Assestamento di Budget' else 'Budget presunto' end, 
				4 /* Inserita */, null,
				@idsor01,@idsor02,@idsor03,@idsor04,@idsor05, @tipovariazione, /*Assestamento*/
				case when @assestamento='S' then 0 else 1 end, 
				GETDATE(),'compute_balancebudgetvar',GETDATE(),'compute_balancebudgetvar')
	
	insert into accountvardetail(yvar, nvar, rownum, idacc, idupb,
						amount, 
						amount2, amount3, amount4, amount5, description,
						ct, cu, lt, lu)
	
	select @nextayear, @nmaxvar, ROW_NUMBER()OVER (ORDER BY T.idacc, T.idupb) as rownum,
				T.idacc,T.idupb,
				 --per upb con tipo upb: prev. anno corr. + prev. anno succ - scritture
				 --per upb senza tipo upb: preimpegni anno corr. + preimpegni anno succ - scritture
				 isnull(sum(T.prev),0)  + isnull(sum(T.prev2),0) +  isnull(sum(T.pre_mov),0)+  isnull(sum(T.pre_mov2),0) 
								- isnull(sum(T.scritture),0) - isnull(sum(T.variazioni_esistenti),0),				
					  isnull(sum(prev3),0)+  isnull(sum(T.pre_mov3),0)- isnull(sum(T.variazioni_esistenti2),0),
					  isnull(sum(prev4),0)+  isnull(sum(T.pre_mov4),0)- isnull(sum(T.variazioni_esistenti3),0),
					  isnull(sum(prev5),0)+  isnull(sum(T.pre_mov5),0)- isnull(sum(T.variazioni_esistenti4),0),
					   0- isnull(sum(T.variazioni_esistenti5),0),
						case when @assestamento='S' then 'Assestamento di Budget' else 'Budget presunto' end,
					GETDATE(),'compute_balancebudgetvar',GETDATE(),'compute_balancebudgetvar'
	 FROM #situazione_upb_account T 		
		JOIN account A on A.idacc = T.idacc
		--where  (A.flagaccountusage & 64+128+256+4096)<>0 -- DA VALUTARE
	GROUP BY  T.idacc, T.idupb
			HAVING
		(isnull(sum(T.prev),0)  +  isnull(sum(T.prev2),0) +  isnull(sum(T.pre_mov),0)+  isnull(sum(T.pre_mov2),0) 
								-  isnull(sum(T.scritture),0) - isnull(sum(T.variazioni_esistenti),0) ) <> 0 OR
		(isnull(sum(prev3),0)	+  isnull(sum(T.pre_mov3),0)- isnull(sum(T.variazioni_esistenti2),0)  ) <> 0 OR
		(isnull(sum(prev4),0)	+  isnull(sum(T.pre_mov4),0)- isnull(sum(T.variazioni_esistenti3),0)  ) <> 0 OR
		(isnull(sum(prev5),0)	+  isnull(sum(T.pre_mov5),0)- isnull(sum(T.variazioni_esistenti4),0)  ) <> 0 OR
		( 0 - isnull(sum(T.variazioni_esistenti5),0)  ) <> 0  
End



if(@generatevar<>'S')
Begin

	select @nextayear as Esercizio,
		/*case 
		when  (A.flagaccountusage & 128)<>0 /*ricavi*/
			then 'Conto di Ricavi'
		when  ((A.flagaccountusage & 64)<>0 or (A.flagaccountusage & 256)<>0 or (A.flagaccountusage & 4096)<>0 )  /*costi, immobilizzazioni e accantonamenti*/
		then 'Conto di Costo'
		End,*/
	A.codeacc AS 'Codice Conto',
	A.title as 'Conto',
	U.codeupb as 'Codice UPB',
	U.title as 'UPB',
	case when epupbkind.flag&1<>0 then'S' else 'N' end as'Considera preimpegni di budget per assestamento',
	isnull(sum(T.prev),0) as 'Previsione corrente',
	isnull(sum(T.prev2),0) as 'Previsione corrente anno +2',
	isnull(sum(T.prev3),0) as 'Previsione corrente anno +3',
	isnull(sum(T.prev4),0) as 'Previsione corrente anno +4',
	isnull(sum(T.prev5),0) as 'Previsione corrente anno +5',
	isnull(sum(T.pre_mov),0) as 'Pre-Movimenti budget',
	isnull(sum(T.pre_mov2),0) as 'Pre-Movimenti budget anno +2',
	isnull(sum(T.pre_mov3),0) as 'Pre-Movimenti budget anno +3',
	isnull(sum(T.pre_mov4),0) as 'Pre-Movimenti budget anno +4',
	isnull(sum(T.pre_mov5),0) as 'Pre-Movimenti budget anno +5',
	isnull(sum(T.scritture),0) as 'costi o ricavi',
	isnull(sum(T.variazioni_esistenti),0) as 'Variazioni esistenti',
	isnull(sum(T.variazioni_esistenti2),0) as 'Variazioni esistenti anno +2',
	isnull(sum(T.variazioni_esistenti3),0) as 'Variazioni esistenti anno +3',
	isnull(sum(T.variazioni_esistenti4),0) as 'Variazioni esistenti anno +4',
	isnull(sum(T.variazioni_esistenti5),0) as 'Variazioni esistenti anno +5',
	isnull(sum(T.prev),0)  + isnull(sum(T.prev2),0) +  isnull(sum(T.pre_mov),0)+  isnull(sum(T.pre_mov2),0) 
	- isnull(sum(T.scritture),0) - isnull(sum(T.variazioni_esistenti),0) as 'assestamento',				
	isnull(sum(prev3),0)-isnull(sum(T.variazioni_esistenti2),0)  as 'assestamento anno +2',
	isnull(sum(prev4),0)-isnull(sum(T.variazioni_esistenti3),0) as 'assestamento anno +3',
	isnull(sum(prev5),0)-isnull(sum(T.variazioni_esistenti4),0) as 'assestamento anno +4', 
	0-isnull(sum(T.variazioni_esistenti5),0) as 'assestamento anno +5'
	 FROM #situazione_upb_account T 
		JOIN account A on A.idacc = T.idacc
		join UPB U		on T.idupb = U.idupb
		left outer JOIN epupbkind ON U.idepupbkind = epupbkind.idepupbkind
	GROUP BY T.idacc, T.idupb,	A.codeacc, A.codeacc, A.title,	U.codeupb, U.title,epupbkind.flag
End


END

GO
