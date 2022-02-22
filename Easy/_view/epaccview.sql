
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


-- CREAZIONE VISTA epaccview
IF EXISTS(select * from sysobjects where id = object_id(N'[epaccview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [epaccview]
GO

--select * from epaccview
--clear_table_info'epaccview'
--setuser 'amm'
CREATE    VIEW epaccview
(
	idepacc,yepacc,nepacc,nphase,phase,
	flagvariation,
	description,
	amount,amount2,amount3,amount4,amount5,
	amountwithsign,amountwithsign2,amountwithsign3,amountwithsign4,amountwithsign5,
	totamount,
	curramount,curramount2,curramount3,curramount4,curramount5,totcurramount,
	available,available2,available3,available4,available5,totavailable,
	totalrevenue, revenueavailable,
	totalcredit,
	ayear,
	idacc,codeacc,account,
	idupb,codeupb,upb,
	paridepacc, parentyepacc,parentnepacc,
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
	idaccmotive,codemotive,

	lt,lu,ct,cu,idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	epacc.idepacc,epacc.yepacc,epacc.nepacc,epacc.nphase,
	case when epacc.nphase = 1 then 'Preaccertamento'
		else 'Accertamento'
	end,
	epacc.flagvariation,
	epacc.description,
	EY.amount,EY.amount2,EY.amount3,EY.amount4,EY.amount5,
	--amountwithsign
	case when epacc.flagvariation ='N' 
					then ISNULL(EY.amount,0)
					else -ISNULL(EY.amount,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(EY.amount2,0)
					else -ISNULL(EY.amount2,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(EY.amount3,0)
					else -ISNULL(EY.amount3,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(EY.amount4,0)
					else -ISNULL(EY.amount4,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(EY.amount5,0)
					else -ISNULL(EY.amount5,0)
	end,
	-- totamount:
	isnull(EY.amount,0)+isnull(EY.amount2,0)+isnull(EY.amount3,0)+isnull(EY.amount4,0)+isnull(EY.amount5,0),

	ET.curramount,ET.curramount2,ET.curramount3,ET.curramount4,ET.curramount5,
	-- totcurramount :
	isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0),
	case when epacc.nphase = 1 then ET.available else null end,
	case when epacc.nphase = 1 then ET.available2 else null end,
	case when epacc.nphase = 1 then ET.available3 else null end,
	case when epacc.nphase = 1 then ET.available4 else null end,
	case when epacc.nphase = 1 then ET.available5 else null end,
	-- totavailable :
	case when epacc.nphase = 1 then
			isnull(ET.available,0)+isnull(ET.available2,0)+isnull(ET.available3,0)+isnull(ET.available4,0)+isnull(ET.available5,0)
		else 
			null
	end,	
	-- totalrevenue:
	case when epacc.nphase = 2 then
		case when epacc.flagvariation ='N' 
					then ISNULL(ET.revenue,0)
					else -ISNULL(ET.revenue,0)
		end	
		else null
	end,
	-- revenueavailable
	case when epacc.nphase = 2 then
		isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0)-
			case when epacc.flagvariation ='N' 
					then ISNULL(ET.revenue,0)
					else -ISNULL(ET.revenue,0)
			end	
		else null
	end,

	 -- totalcredit:
	case when epacc.flagvariation ='N' 
					then ISNULL(ET.credit,0)
					else -ISNULL(ET.credit,0)
			end	,
	EY.ayear,
	A.idacc, A.codeacc, A.title,
	U.idupb, U.codeupb, U.title,
	epacc.paridepacc,par.yepacc,par.nepacc,
	isnull(par.yepacc,epacc.yepacc),isnull(par.nepacc,epacc.nepacc),
	epacc.start,epacc.stop,epacc.adate,
	registry.idreg,registry.title,
	epacc.doc,epacc.docdate,
	manager.idman,manager.title,
	epacc.idrelated,
	A.flagaccountusage,
	CASE	when (( A.flagaccountusage & 1) = 0)  then 'N'	ELSE 'S'END,	/* Ratei attivi*/ 
	CASE	when (( A.flagaccountusage & 2) = 0)  then 'N'	ELSE 'S'END,	/* Ratei Passivi*/
	CASE	when (( A.flagaccountusage & 4) = 0)  then 'N'	ELSE 'S'END,	/* Risconti Attivi*/
	CASE	when (( A.flagaccountusage & 8) = 0)  then 'N'	ELSE 'S'END,	/* Risconti Passivi */
	CASE	when (( A.flagaccountusage & 16) = 0) then 'N' ELSE 'S'END,	/* Debito  */
	CASE	when (( A.flagaccountusage & 32) = 0) then 'N' ELSE 'S'	END,	/* Credito */
	CASE	when (( A.flagaccountusage & 64) = 0) then 'N' ELSE 'S'	END,	/* Costi */
	CASE	when (( A.flagaccountusage & 128) = 0) then 'N' ELSE 'S'END,	/* Ricavi */
	CASE	when (( A.flagaccountusage & 256) = 0) then 'N' ELSE 'S'END,/*Immobilizzazioni*/
	CASE	when (( A.flagaccountusage & 512) = 0) then 'N' ELSE 'S'END, /* Avanzo libero */
	CASE 	when (( A.flagaccountusage & 1024) = 0) then 'N' ELSE 'S' END, /* Avanzo vincolato */ 
	CASE    when (( A.flagaccountusage & 2048) = 0) then 'N' ELSE 'S' END, /*Riserva*/
	CASE    when (( A.flagaccountusage & 4096) = 0) then 'N' ELSE 'N' END, /*Accantonamento*/
	accmotive.idaccmotive,
	accmotive.codemotive,
	epacc.lt,epacc.lu,epacc.ct,epacc.cu
	,U.idsor01,U.idsor02,U.idsor03,U.idsor04,U.idsor05
FROM epacc
left outer JOIN registry ON epacc.idreg= registry.idreg
join epaccyear EY on epacc.idepacc= EY.idepacc
join epacctotal ET on ET.idepacc= EY.idepacc and EY.ayear=ET.ayear
join account A on EY.idacc=A.idacc
join upb U on U.idupb=EY.idupb
left outer join epacc par on epacc.paridepacc=par.idepacc
left outer join manager on manager.idman= epacc.idman
LEFT OUTER JOIN accmotive   on accmotive.idaccmotive = epacc.idaccmotive

GO
 
