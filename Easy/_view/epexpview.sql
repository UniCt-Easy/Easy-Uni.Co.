-- CREAZIONE VISTA epexpview
IF EXISTS(select * from sysobjects where id = object_id(N'[epexpview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [epexpview]
GO

-- setuser 'amm'
--clear_table_info'epexpview'
--select * from epexpview
CREATE    VIEW [epexpview]
(
	idepexp,yepexp,nepexp,nphase,phase,
	flagvariation,
	description,
	amount,amount2,amount3,amount4,amount5,
	amountwithsign,amountwithsign2,amountwithsign3,amountwithsign4,amountwithsign5,
	totamount,
	curramount,curramount2,curramount3,curramount4,curramount5,totcurramount,
	available,available2,available3,available4,available5,totavailable,
	totalcost, costavailable,
	totaldebit,
	ayear,
	idacc,codeacc,account,
	idupb,codeupb,upb,
	paridepexp, parentyepexp,parentnepexp,
	yliv1,nliv1,
	start, stop, adate,
	idreg,registry,
	doc,docdate,
	idman,manager,
	idrelated,
	flagaccountusage,
	rateiattivi,rateipassivi,
	riscontiattivi, riscontipassivi,
	debit,credit,
	cost,revenue,
	fixedassets,freeusesurplus,captiveusesurplus,reserve,provision,
	idaccmotive,
	codemotive,
	lt,lu,ct,cu,idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	epexp.idepexp,epexp.yepexp,epexp.nepexp,epexp.nphase,
	case when epexp.nphase = 1 then 'Preimpegno'
		else 'Impegno'
	end,
	epexp.flagvariation,
	epexp.description,
	EY.amount,EY.amount2,EY.amount3,EY.amount4,EY.amount5,
	--amountwithsign
	case when epexp.flagvariation ='N' 
					then ISNULL(EY.amount,0)
					else -ISNULL(EY.amount,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(EY.amount2,0)
					else -ISNULL(EY.amount2,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(EY.amount3,0)
					else -ISNULL(EY.amount3,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(EY.amount4,0)
					else -ISNULL(EY.amount4,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(EY.amount5,0)
					else -ISNULL(EY.amount5,0)
	end,
	-- totamount:
	isnull(EY.amount,0)+isnull(EY.amount2,0)+isnull(EY.amount3,0)+isnull(EY.amount4,0)+isnull(EY.amount5,0),
	ET.curramount,ET.curramount2,ET.curramount3,ET.curramount4,ET.curramount5,
	-- totcurramount :
	isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0),
	case when epexp.nphase = 1 then ET.available else null end,
	case when epexp.nphase = 1 then ET.available2 else null end,
	case when epexp.nphase = 1 then ET.available3 else null end,
	case when epexp.nphase = 1 then ET.available4 else null end,
	case when epexp.nphase = 1 then ET.available5 else null end,
	-- totavailable :
	case when epexp.nphase = 1 then
			isnull(ET.available,0)+isnull(ET.available2,0)+isnull(ET.available3,0)+isnull(ET.available4,0)+isnull(ET.available5,0)
		else 
			null
	end
	,	
	-- totalcost:
	case when epexp.nphase = 2 then
			case when epexp.flagvariation ='N' 
					then ISNULL(ET.cost,0)
					else -ISNULL(ET.cost,0)
			end		 
		else null
	end,
	--costavailable
	case when epexp.nphase = 2 then
		isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0)-
		(case when epexp.flagvariation ='N' 
					then ISNULL(ET.cost,0)
					else -ISNULL(ET.cost,0)
		end) 	
		else null
	end,

	 -- totaldebit:
	 case when epexp.nphase = 2 then
		case when epexp.flagvariation ='N' 
					then 	ISNULL(ISNULL(ET.debit,0),0)
					else 	-ISNULL(ET.debit,0)
		end 
		else null
	end,
	EY.ayear,
	A.idacc, A.codeacc, A.title,
	U.idupb, U.codeupb, U.title,
	epexp.paridepexp,par.yepexp,par.nepexp,
	isnull(par.yepexp,epexp.yepexp),isnull(par.nepexp,epexp.nepexp),
	epexp.start,epexp.stop,epexp.adate,
	registry.idreg,registry.title,
	epexp.doc,epexp.docdate,
	manager.idman,manager.title,
	epexp.idrelated,
	A.flagaccountusage,
	CASE	when (( A.flagaccountusage & 1) = 0)  then 'N'	ELSE 'S' END,	/* Ratei attivi*/ 
	CASE	when (( A.flagaccountusage & 2) = 0)  then 'N'	ELSE 'S' END,	/* Ratei Passivi*/
	CASE	when (( A.flagaccountusage & 4) = 0)  then 'N'	ELSE 'S' END,	/* Risconti Attivi*/
	CASE	when (( A.flagaccountusage & 8) = 0)  then 'N'	ELSE 'S' END,	/* Risconti Passivi */
	CASE	when (( A.flagaccountusage & 16) = 0) then 'N' ELSE 'S' END,	/* Debito  */
	CASE	when (( A.flagaccountusage & 32) = 0) then 'N' ELSE 'S'	END,	/* Credito */
	CASE	when (( A.flagaccountusage & 64) = 0) then 'N' ELSE  'S' END,	/* Costi */
	CASE	when (( A.flagaccountusage & 128) = 0) then 'N' ELSE 'S' END,	/* Ricavi */
	CASE	when (( A.flagaccountusage & 256) = 0) then 'N' ELSE 'S' END,/*Immobilizzazioni*/
	CASE	when (( A.flagaccountusage & 512) = 0) then 'N' ELSE 'S' END, /* Avanzo libero */
	CASE 	when (( A.flagaccountusage & 1024) = 0) then 'N' ELSE 'S' END, /* Avanzo vincolato */ 
	CASE    when (( A.flagaccountusage & 2048) = 0) then 'N' ELSE 'S' END, /*Riserva*/
	CASE    when (( A.flagaccountusage & 4096) = 0) then 'N' ELSE 'S' END, /*Accantonamento*/
	accmotive.idaccmotive,
	accmotive.codemotive,
	epexp.lt,epexp.lu,epexp.ct,epexp.cu
	,U.idsor01,U.idsor02,U.idsor03,U.idsor04,U.idsor05
FROM epexp
left outer JOIN registry ON epexp.idreg= registry.idreg
join epexpyear EY on epexp.idepexp= EY.idepexp
join epexptotal ET on ET.idepexp= EY.idepexp and EY.ayear=ET.ayear
join account A on EY.idacc=A.idacc
join upb U on U.idupb=EY.idupb
left outer join epexp par on epexp.paridepexp=par.idepexp
left outer join manager on manager.idman= epexp.idman
LEFT OUTER JOIN accmotive   
	ON accmotive.idaccmotive = epexp.idaccmotive

GO

 