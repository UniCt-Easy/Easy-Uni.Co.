
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


-- CREAZIONE VISTA csa_contractview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contractview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contractview]
GO

--clear_table_info'csa_contractview'

CREATE      VIEW [csa_contractview]
(
	ayear,
	idcsa_contract,
	ycontract,
	ncontract,
	idcsa_contractkind,
	csa_contractkindcode,
	csa_contractkind,
	csa_contractkindflagcr,
	title,	
	description,
	idupb,
	codeupb,
	upb,
	idupb_contractkind,
	codeupb_contractkind,
	upb_contractkind,
	idacc_main,
	codeacc_main,
	account_main,
	idfin_main,
	codefin_main,
	fin_main,
	idexp_main,
	nphase_main,
	phase_main,
	ymov_main,
	nmov_main,
	flagkeepalive,
	flagrecreate,
	active,
	idsor_siope_main,
	sortcode_main,
	sorting_main,
	idunderwriting,
	underwriting,
	idepexp_main,yepexp_main,nepexp_main,epexp_main_nphase,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	C.ayear,
	C.idcsa_contract,
	C.ycontract,
	C.ncontract,
	CK.idcsa_contractkind,
	CK.contractkindcode,
	CK.description,
	CK.flagcr,
	C.title,	
	C.description,
	C.idupb,
	upb.codeupb,
	upb.title,
	CKY.idupb,
	upbck.codeupb,
	upbck.title,
	C.idacc_main,
	account.codeacc,
	account.title,
	C.idfin_main,
	fin.codefin,
	fin.title,
	C.idexp_main,
	expensephase.nphase,
	expensephase.description, 
	expense.ymov,
	expense.nmov,
	C.flagkeepalive,
	C.flagrecreate,
	C.active,
	C.idsor_siope_main,
	sorting.sortcode,
	sorting.description, 
	C.idunderwriting,
	underwriting.title,
	E.idepexp,E.yepexp,E.nepexp,E.nphase,
	C.cu,
	C.ct,
	C.lu,
	C.lt
FROM csa_contract C
LEFT OUTER JOIN csa_contractkind CK
	ON C.idcsa_contractkind = CK.idcsa_contractkind
JOIN csa_contractkindyear CKY
	ON C.idcsa_contractkind = CKY.idcsa_contractkind
	AND CKY.ayear = C.ayear
LEFT OUTER JOIN upb 
	ON upb.idupb=C.idupb
LEFT OUTER JOIN upb upbck 
	ON upbck.idupb=CKY.idupb
LEFT OUTER JOIN fin fin
	ON fin.idfin=C.idfin_main
LEFT OUTER JOIN account account
	ON account.idacc=C.idacc_main
LEFT OUTER JOIN expense
	ON C.idexp_main = expense.idexp
LEFT OUTER JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
	AND expenseyear.ayear = C.ayear
LEFT OUTER JOIN expensetotal
	ON  expensetotal.idexp = expense.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN sorting
	ON sorting.idsor = C.idsor_siope_main
LEFT OUTER JOIN underwriting
	ON C.idunderwriting = underwriting.idunderwriting
LEFT OUTER JOIN epexp	E
	ON E.idepexp = C.idepexp_main



 

GO
  
