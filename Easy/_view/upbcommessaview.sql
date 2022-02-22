
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



-- CREAZIONE VISTA upbcommessaview
IF EXISTS(select * from sysobjects where id = object_id(N'[upbcommessaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbcommessaview]
GO

--setuser  'amm'
--setuser  'amministrazione'
--clear_table_info'upbcommessaview'
--select * from upbcommessaview
CREATE VIEW upbcommessaview 
(
	idupb,
	ayear,
	codeupb,
	title,
	yearstart,
	yearstop,
	
	idepupbkind,	
	epupbkind,

	idaccmotive_cost,
	codemotive_cost,
	motive_cost,
	
	idaccmotive_revenue,		
	codemotive_revenue,		
	motive_revenue,		

	idaccmotive_deferredcost,
	codemotive_deferredcost,
	motive_deferredcost,

	idaccmotive_accruals,
	codemotive_accruals,
	motive_accruals,

	idacc_cost,
	codeacc_cost,
	acc_cost,

	idacc_revenue,
	codeacc_revenue,
	acc_revenue,

	idacc_deferredcost,
	codeacc_deferredcost,
	acc_deferredcost,

	idacc_accruals,
	codeacc_accruals,
	acc_accruals,

	cost,
	reserve,
	revenue,
	accruals,
	assetamortization,
	idsor01,idsor02,idsor03,idsor04,idsor05,

	costi, risconti,rateiattivi, 


	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	upbcommessa.idupb,
	upbcommessa.ayear,
	upbcommessa.codeupb,
	upbcommessa.title,
	upbcommessa.yearstart,
	upbcommessa.yearstop,

	upbcommessa.idepupbkind,	
	epupbkind.title,

	upbcommessa.idaccmotive_cost,
	accmotive_cost.codemotive,
	accmotive_cost.title,
	
	upbcommessa.idaccmotive_revenue,		
	accmotive_revenue.codemotive,
	accmotive_revenue.title,

	upbcommessa.idaccmotive_deferredcost,
	accmotive_deferredcost.codemotive,
	accmotive_deferredcost.title,

	upbcommessa.idaccmotive_accruals,
	accmotive_accruals.codemotive,
	accmotive_accruals.title,

	upbcommessa.idacc_cost,
	account_cost.codeacc,
	account_cost.title,
	
	upbcommessa.idacc_revenue,
	account_revenue.codeacc,
	account_revenue.title,

	upbcommessa.idacc_deferredcost,
	account_deferredcost.codeacc,
	account_deferredcost.title,

	upbcommessa.idacc_accruals,
	account_accruals.codeacc,
	account_accruals.title,

	upbcommessa.cost,
	upbcommessa.reserve,
	upbcommessa.revenue,
	upbcommessa.accruals,
	upbcommessa.assetamortization,
	upb.idsor01,upb.idsor02,upb.idsor03,upb.idsor04,upb.idsor05,

	-(select sum(case when A.flagaccountusage & 64 <> 0 then ED.amount else 0 end)  
		from entrydetail ed (nolock)
			join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry 
			join upb  U (nolock) on isnull(U.idupb_capofila,U.idupb)=upbcommessa.idupb
			join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind
			join account A (nolock) on A.idacc = ed.idacc
			where   ( U.start is null or year(U.start)<= upbcommessa.ayear) and
					( year(U.stop)> upbcommessa.ayear) and
					( EU.ayear= upbcommessa.ayear) and
					( ED.yentry= upbcommessa.ayear) and
					( EU.adjustmentkind= 'C') and
					( E.identrykind= 8) and
					( U.idupb= ED.idupb ) 
		),
	(select sum(case when A.flagaccountusage & 8 <> 0 then ED.amount else 0 end)  
		from entrydetail ed (nolock)
			join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry 
			join upb  U (nolock) on isnull(U.idupb_capofila,U.idupb)=upbcommessa.idupb
			join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind
			join account A (nolock) on A.idacc = ed.idacc
			where   ( U.start is null or year(U.start)<= upbcommessa.ayear) and
					( year(U.stop)> upbcommessa.ayear) and
					( EU.ayear= upbcommessa.ayear) and
					( ED.yentry= upbcommessa.ayear) and
					( EU.adjustmentkind= 'C') and
					( E.identrykind= 8) and
					( U.idupb= ED.idupb ) 

		),
	-(select sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end)  
		from entrydetail ed (nolock)
			join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry 
			join upb  U (nolock) on  isnull(U.idupb_capofila,U.idupb)=upbcommessa.idupb
			join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind
			join account A (nolock) on A.idacc = ed.idacc
			where   ( U.start is null or year(U.start)<= upbcommessa.ayear) and
					( year(U.stop)> upbcommessa.ayear) and
					( EU.ayear= upbcommessa.ayear) and
					( ED.yentry= upbcommessa.ayear) and
					( EU.adjustmentkind= 'C') and
					( E.identrykind= 8) and
					( U.idupb= ED.idupb ) 

		),

	upbcommessa.cu, 
	upbcommessa.ct, 
	upbcommessa.lu, 
	upbcommessa.lt
FROM upbcommessa
LEFT OUTER JOIN upb 	ON upb.idupb= upbcommessa.idupb
left outer join epupbkind on upbcommessa.idepupbkind= epupbkind.idepupbkind
left outer join accmotive accmotive_cost on upbcommessa.idaccmotive_cost=accmotive_cost.idaccmotive 
left outer join accmotive accmotive_revenue on upbcommessa.idaccmotive_revenue=accmotive_revenue.idaccmotive 
left outer join accmotive accmotive_accruals on upbcommessa.idaccmotive_accruals=accmotive_accruals.idaccmotive 
left outer join accmotive accmotive_deferredcost on upbcommessa.idaccmotive_deferredcost=accmotive_deferredcost.idaccmotive 
left outer join account account_cost on upbcommessa.idacc_cost=account_cost.idacc 
left outer join account account_revenue on upbcommessa.idacc_revenue=account_revenue.idacc
left outer join account account_accruals on upbcommessa.idacc_accruals=account_accruals.idacc
left outer join account account_deferredcost on upbcommessa.idacc_deferredcost=account_deferredcost.idacc


