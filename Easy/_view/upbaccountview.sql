-- CREAZIONE VISTA upbaccountview
IF EXISTS(select * from sysobjects where id = object_id(N'[upbaccountview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbaccountview]
GO


CREATE VIEW upbaccountview
AS  
-- setuser 'amministrazione'
-- clear_table_info 'upbaccountview'
-- select * from upbaccountview where ayear = 2017
SELECT 
	A.idacc,
	A.codeacc,
	A.title as account,
	U.idupb,
	U.codeupb,
	U.title as upb,
	isnull(UAT.currentprev,0)+ isnull(UAT.previsionvariation,0)   as currentprev,
	isnull(UAT.currentprev2,0)+ isnull(UAT.previsionvariation2,0) as currentprev2,
	isnull(UAT.currentprev3,0)+ isnull(UAT.previsionvariation3,0) as currentprev3,
	isnull(UAT.currentprev4,0)+ isnull(UAT.previsionvariation4,0) as currentprev4,
	isnull(UAT.currentprev5,0)+ isnull(UAT.previsionvariation5,0) as currentprev5,
	isnull(UET1.total,0)  as epexp1, 
	isnull(UET1.total2,0) as epexp1_2, 
	isnull(UET1.total3,0) as epexp1_3, 
	isnull(UET1.total4,0) as epexp1_4, 
	isnull(UET1.total5,0) as epexp1_5, 
	isnull(UET2.total,0)	 as epexp2,
	isnull(UET2.total2,0)    as epexp2_2,
	isnull(UET2.total3,0)    as epexp2_3,
	isnull(UET2.total4,0)    as epexp2_4,
	isnull(UET2.total5,0)    as epexp2_5,
	isnull(UAT.currentprev,0)+ isnull(UAT.previsionvariation,0)   -  isnull(UET1.total,0)   as available,

	isnull(UAT1.total,0)  as epacc1, 
	isnull(UAT1.total2,0) as epacc1_2, 
	isnull(UAT1.total3,0) as epacc1_3, 
	isnull(UAT1.total4,0) as epacc1_4, 
	isnull(UAT1.total5,0) as epacc1_5, 
	isnull(UAT2.total,0)	 as epacc2,
	isnull(UAT2.total2,0)    as epacc2_2,
	isnull(UAT2.total3,0)    as epacc2_3,
	isnull(UAT2.total4,0)    as epacc2_4,
	isnull(UAT2.total5,0)    as epacc2_5,
	isnull(UAT.currentprev,0)+ isnull(UAT.previsionvariation,0)   -  isnull(UAT1.total,0)   as available_epacc,

	 -(select sum(D.amount) from entrydetail D where D.idacc=A.idacc and D.idupb=U.idupb and D.amount<0) as dare, 
	(select sum(D.amount) from entrydetail D where D.idacc=A.idacc and D.idupb=U.idupb and D.amount>0) as avere, 
	A.ayear,
	U.flagactivity,
	case
		when U.flagactivity ='1' then 'Istituzionale'
		when U.flagactivity ='2' then 'Commerciale'
		when U.flagactivity ='4' then 'Qualsiasi/Non specificata'
	end as activity,
	U.flagkind,
	CASE
		when (( U.flagkind & 1)<> 0) then 'S'
		else 'N'
	End as kinddidattica,
	CASE
		when (( u.flagkind & 2)<>0) then 'S'
		else 'N'
	End kindricerca,
	CASE
		when (( u.flagkind & 4)<>0) then 'S'
		else 'N'
	End as contabilitaspeciale,
	u.cigcode,
	u.cupcode,
	u.idman,
	manager.title as manager,
	-- tipo upb
	u.idepupbkind,
	epupbkind.title as epupbkind,
	epupbkind.isresource,
	a.flagaccountusage,
		CASE 	when ((A.flagaccountusage & 1) = 0)  then 'N'  ELSE 'S' END as rateiattivi,
		CASE 	when (( A.flagaccountusage & 2) = 0)  then 'N'  ELSE 'S' END as rateipassivi,
		CASE 	when (( A.flagaccountusage & 4) = 0)  then 'N'  ELSE 'S' END as riscontiattivi,
		CASE 	when (( A.flagaccountusage & 8) = 0)  then 'N'  ELSE 'S' END as riscontipassivi,
		CASE 	when (( A.flagaccountusage & 32) = 0)  then 'N'  ELSE 'S' END as credit,
		CASE 	when (( A.flagaccountusage & 16) = 0)  then 'N'  ELSE 'S' END as debit,
		CASE 	when (( A.flagaccountusage & 64) = 0)  then 'N'  ELSE 'S' END as cost,
		CASE 	when (( A.flagaccountusage & 128) = 0)  then 'N'  ELSE 'S' END as revenue,
		CASE 	when (( A.flagaccountusage & 256) = 0)  then 'N'  ELSE 'S' END as fixedassets,
		CASE 	when (( A.flagaccountusage & 512) = 0)  then 'N'  ELSE 'S' END as freeusesurplus,
		CASE 	when (( A.flagaccountusage & 1024) = 0)  then 'N'  ELSE 'S' END as captiveusesurplus,
		CASE 	when (( A.flagaccountusage & 2048) = 0)  then 'N'  ELSE 'S' END as reserve,
		CASE 	when (( A.flagaccountusage & 4096) = 0)  then 'N'  ELSE 'S' END as provision,	
		A.flagenablebudgetprev,
		A.flagprofit,--utile
		A.flagloss,--perdita
		A.flagcompetency,--competenza
		--conto d'ordine
		CASE
			when (( A.flag & 4) = 0)  then 'N'
			when (( A.flag & 4)<> 0)  then 'S'
		END as contoordine,
		A.flag,
		AL.flagusable, 
		sorting_investimenti.sortcode as sortcode_investimenti,
		sorting_economico.sortcode as sortcode_economico,
		U.idsor01,
		U.idsor02,
		U.idsor03,
		U.idsor04,
		U.idsor05
FROM upbaccounttotal (NOLOCK)  UAT 
	join account (NOLOCK) A on UAT.idacc=A.idacc
	join accountlevel (NOLOCK) AL on AL.nlevel=A.nlevel AND AL.ayear=A.ayear
	join  upb (NOLOCK)  U   on UAT.idupb=U.idupb	
	left outer join upbepexptotal (NOLOCK)  UET1 on UET1.idacc=A.idacc and UET1.idupb=U.idupb and UET1.nphase=1
	left outer join  upbepexptotal (NOLOCK)  UET2 on UET2.idacc=A.idacc and UET2.idupb=U.idupb and UET2.nphase=2

	left outer join upbepacctotal (NOLOCK)  UAT1 on UAT1.idacc = A.idacc and UAT1.idupb = U.idupb and UAT1.nphase = 1
	left outer join  upbepacctotal (NOLOCK)  UAT2 on UAT2.idacc = A.idacc and UAT2.idupb = U.idupb and UAT2.nphase = 2

	LEFT OUTER JOIN  sorting (NOLOCK) as sorting_investimenti  ON A.idsor_investmentbudget = sorting_investimenti.idsor
	LEFT OUTER JOIN  sorting (NOLOCK) as sorting_economico  ON A.idsor_economicbudget = sorting_economico.idsor
	LEFT OUTER JOIN  manager (NOLOCK)	ON U.idman = manager.idman
	left outer join epupbkind	 (NOLOCK)	on U.idepupbkind = epupbkind.idepupbkind

 

GO