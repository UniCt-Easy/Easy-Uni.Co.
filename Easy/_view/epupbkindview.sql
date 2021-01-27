
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA capview
IF EXISTS(select * from sysobjects where id = object_id(N'[epupbkindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [epupbkindview]
GO
 
--select * from epupbkindview
--clear_table_info'epupbkindview'
--setuser 'amministrazione'
CREATE    VIEW [epupbkindview]
(
	idepupbkind,
	title,
	description,
	active,
	isresource,
	ayear,
	idacc_cost, codeacc_cost, account_cost,
	idacc_revenue, codeacc_revenue, account_revenue,
	idacc_deferredcost, codeacc_deferredcost, account_deferredcost,
	idacc_accruals,  codeacc_accruals,  account_accruals,
	idacc_reserve, codeacc_reserve, account_reserve,
	idaccmotive_cost, codemotive_cost,  
	idaccmotive_revenue, codemotive_revenue,  
	idaccmotive_deferredcost, codemotive_deferredcost, 
	idaccmotive_accruals,  codemotive_accruals, 
	idaccmotive_reserve, codemotive_reserve,  
	adjustmentkind,adjustment,
	flag,
	considerapreimpegni,
	lt,lu,ct,cu
)
AS
SELECT
	E.idepupbkind,
	E.title,
	E.description,
	E.active,
	E.isresource,
	config.ayear,
	ACC_COST.idacc, ACC_COST.codeacc, ACC_COST.title,
	ACC_REVENUE.idacc, ACC_REVENUE.codeacc, ACC_REVENUE.title,
	ACC_DEFERREDCOST.idacc, ACC_DEFERREDCOST.codeacc, ACC_DEFERREDCOST.title,
	ACC_ACCRUALS.idacc, ACC_ACCRUALS.codeacc, ACC_ACCRUALS.title,
	ACC_RESERVE.idacc, ACC_RESERVE.codeacc, ACC_RESERVE.title,
	accmotive_cost.idaccmotive, accmotive_cost.codemotive,  
	accmotive_revenue.idaccmotive, accmotive_revenue.codemotive,  
	accmotive_deferredcost.idaccmotive, accmotive_deferredcost.codemotive, 
	accmotive_accruals.idaccmotive, accmotive_accruals.codemotive, 
	accmotive_reserve.idaccmotive, accmotive_reserve.codemotive,  
	EY.adjustmentkind,
	case when EY.adjustmentkind='C' then 'commessa' 
		 when EY.adjustmentkind='P' then 'percentuale'
		 else null
	end  ,
	E.flag,
	case when E.flag&1<>0 then'S' else 'N' end,
	E.lt,E.lu,E.ct,E.cu
FROM epupbkind E 
cross JOIN config 
LEFT OUTER JOIN epupbkindyear EY on E.idepupbkind= EY.idepupbkind and config.ayear= EY.ayear
left outer join  account ACC_COST on EY.idacc_cost=ACC_COST.idacc
left outer join  account ACC_REVENUE on EY.idacc_revenue=ACC_REVENUE.idacc
left outer join  account ACC_DEFERREDCOST on EY.idacc_deferredcost=ACC_DEFERREDCOST.idacc
left outer join  account ACC_ACCRUALS on EY.idacc_accruals=ACC_ACCRUALS.idacc
left outer join  account ACC_RESERVE on EY.idacc_reserve=ACC_RESERVE.idacc   

left outer join  accmotive accmotive_cost on EY.idaccmotive_cost=accmotive_cost.idaccmotive
left outer join  accmotive accmotive_revenue on EY.idaccmotive_revenue=accmotive_revenue.idaccmotive
left outer join  accmotive accmotive_deferredcost on EY.idaccmotive_deferredcost=accmotive_deferredcost.idaccmotive
left outer join  accmotive accmotive_accruals on EY.idaccmotive_accruals=accmotive_accruals.idaccmotive
left outer join  accmotive accmotive_reserve on EY.idaccmotive_reserve=accmotive_reserve.idaccmotive  

GO
 
