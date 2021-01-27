
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


-- CREAZIONE VISTA csa_importriepview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importriepview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importriepview]
GO


CREATE       VIEW [csa_importriepview]
(
	ayear,
	competency,
	idriep,
	idcsa_import,
	yimport,
	nimport,
	idcsa_contract,
	ycontract,
	ncontract,
	idcsa_contractkind,
	csa_contractkindcode,
	csa_contractkind,
	ruolocsa,	
	capitolocsa,
	competenza,
	importo,
	idreg,
	registry,
	matricola,
	idupb,
	codeupb,
	upb,
	idacc,
	codeacc,
	account,
	idfin,
	codefin,
	fin,
	idsor_siope,
	sortcode,
	sorting,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	flagcr,
	idunderwriting,
	underwriting,
	idepexp,yepexp,nepexp,epexp_nphase,
	lu,
	lt
)
AS SELECT 
	IR.ayear,
	IR.competency,
	IR.idriep,
	IR.idcsa_import,
	I.yimport,
	I.nimport,
	IR.idcsa_contract,
	C.ycontract,
	C.ncontract,
	IR.idcsa_contractkind,
	CK.contractkindcode,
	CK.description,
	IR.ruolocsa,	
	IR.capitolocsa,
	IR.competenza,
	IR.importo,
	IR.idreg,
	registry.title,
	IR.matricola,
	IR.idupb,
	upb.codeupb,
	upb.title,
	IR.idacc,
	account.codeacc,
	account.title,
	IR.idfin,
	fin.codefin,
	fin.title,
	IR.idsor_siope,
	sorting.sortcode,
	sorting.description,
	IR.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	IR.flagcr,
	IR.idunderwriting,
	underwriting.title,
	IR.idepexp,epexp.yepexp,epexp.nepexp,epexp.nphase,
	IR.lu,
	IR.lt
FROM csa_importriep IR
JOIN csa_import I
	ON I.idcsa_import = IR.idcsa_import
LEFT OUTER JOIN csa_contractkind CK
	ON IR.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN csa_contract C
	ON C.idcsa_contract = IR.idcsa_contract
	AND C.idcsa_contractkind = IR.idcsa_contractkind
	AND C.ayear = IR.ayear
LEFT OUTER JOIN csa_contractkindyear CKY
	ON CKY.idcsa_contractkind =IR.idcsa_contractkind 
	AND CKY.ayear = IR.ayear
LEFT OUTER JOIN upb 
	ON upb.idupb=IR.idupb
LEFT OUTER JOIN fin 
	ON fin.idfin=IR.idfin
LEFT OUTER JOIN sorting	
	ON sorting.idsor = IR.idsor_siope
LEFT OUTER JOIN account 
	ON account.idacc=IR.idacc
LEFT OUTER JOIN registry
	ON IR.idreg = registry.idreg
LEFT OUTER JOIN expense
	ON IR.idexp = expense.idexp
LEFT OUTER JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN expenseyear
	ON expenseyear.idexp = IR.idexp
	AND expenseyear.ayear= IR.ayear
LEFT OUTER JOIN expensetotal
	ON  expensetotal.idexp = IR.idexp
	AND expensetotal.ayear = IR.ayear
LEFT OUTER JOIN underwriting	
	ON IR.idunderwriting = underwriting.idunderwriting
LEFT OUTER JOIN epexp	
	ON epexp.idepexp = IR.idepexp



GO
--clear_table_info 'csa_importriepview'
 
