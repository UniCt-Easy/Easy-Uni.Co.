
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


-- CREAZIONE VISTA csa_incomesetupview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_incomesetupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_incomesetupview]
GO


--setuser 'amm'
--clear_table_info'csa_incomesetupview'


CREATE    VIEW [csa_incomesetupview]
(
	ayear,
	idcsa_incomesetup,
	vocecsa,	vocecsaunified,
	idupb,	codeupb,	upb,
	idacc_debit,	codeacc_debit,	account_debit,
	idacc_ente,	codeacc_ente,	account_ente,
	idacc_internalcredit,	codeacc_internalcredit,	account_internalcredit,
	idacc_revenue,	codeacc_revenue,	account_revenue,
	idacc_agency_credit,	codeacc_agency_credit,	account_agency_credit,	
	idfin_income,	codefin_income,	fin_income,
	idsor_siope_income,	sortcode_income,	sorting_income,	
	idfin_expense,	codefin_expense,	fin_expense,
	idsor_siope_expense,	sortcode_expense,	sorting_expense,	
	idfin_incomeclawback,	codefin_clawback,	fin_clawback,
	idsor_siope_clawback,	sortcode_clawback,	sorting_clawback,	
	idfin_cost,	codefin_cost,	fin_cost,
	idsor_siope_cost,	sortcode_cost,	sorting_cost,	
	flagdirectcsaclawback,
	cu,	ct,	lu,	lt
)
AS SELECT 
	C.ayear,
	C.idcsa_incomesetup,
	C.vocecsa,	C.vocecsaunified,
	C.idupb,	upb.codeupb,	upb.title,
	C.idacc_debit,	account_debit.codeacc,	account_debit.title,
	C.idacc_expense,	account_ente.codeacc,	account_ente.title,
	C.idacc_internalcredit,	account_internalcredit.codeacc,	account_internalcredit.title,
	C.idacc_revenue,	account_revenue.codeacc,	account_revenue.title,
	C.idacc_agency_credit,	account_agency_credit.codeacc,	account_agency_credit.title,	
	C.idfin_income,	fin_income.codefin,	fin_income.title,
	C.idsor_siope_income,	sorting_income.sortcode,	sorting_income.description,	
	C.idfin_expense,	fin_expense.codefin,	fin_expense.title,	
	C.idsor_siope_expense,	sorting_expense.sortcode,	sorting_expense.description,	
	C.idfin_incomeclawback,	fin_clawback.codefin,	fin_clawback.title,	
	C.idsor_siope_incomeclawback,	sorting_clawback.sortcode,	sorting_clawback.description,
	C.idfin_cost,	fin_cost.codefin,	fin_cost.title,	
	C.idsor_siope_cost,	sorting_cost.sortcode,	sorting_cost.description,	
	C.flagdirectcsaclawback,
		C.cu,	C.ct,	C.lu,	C.lt
FROM csa_incomesetup C
LEFT OUTER JOIN upb					ON upb.idupb=C.idupb
LEFT OUTER JOIN fin fin_income		ON fin_income.idfin=C.idfin_income
LEFT OUTER JOIN fin fin_expense		ON fin_expense.idfin=C.idfin_expense
LEFT OUTER JOIN fin fin_clawback	ON fin_clawback.idfin=C.idfin_incomeclawback
LEFT OUTER JOIN fin fin_cost		ON fin_cost.idfin=C.idfin_cost
LEFT OUTER JOIN account account_debit	ON account_debit.idacc=C.idacc_debit
LEFT OUTER JOIN account account_ente	ON account_ente.idacc=C.idacc_expense
LEFT OUTER JOIN account account_internalcredit	ON account_internalcredit.idacc=C.idacc_internalcredit
LEFT OUTER JOIN account account_revenue			ON account_revenue.idacc=C.idacc_revenue
LEFT OUTER JOIN account account_agency_credit	ON account_agency_credit.idacc=C.idacc_agency_credit
LEFT OUTER JOIN account account_cost			ON account_cost.idacc=C.idacc_cost

LEFT OUTER JOIN sorting sorting_income			ON sorting_income.idsor = C.idsor_siope_income
LEFT OUTER JOIN sorting sorting_expense			ON sorting_expense.idsor = C.idsor_siope_expense
LEFT OUTER JOIN sorting sorting_clawback		ON sorting_clawback.idsor = C.idsor_siope_incomeclawback
LEFT OUTER JOIN sorting sorting_cost			ON sorting_cost.idsor = C.idsor_siope_cost





GO
