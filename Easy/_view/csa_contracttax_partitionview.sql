
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


-- CREAZIONE VISTA [csa_contracttax_partitionview]
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contracttax_partitionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contracttax_partitionview]
GO  
-- SELECT * FROM [csa_contracttax_partitionview]
CREATE VIEW [csa_contracttax_partitionview]
(
	idcsa_contract,
	ycontract,
	ncontract,
	active,
	idcsa_contractkind,
	csa_contractkind,
	contractkindcode,
	flagcr,
	idcsa_contracttax,
	vocecsa,
	ayear,
	ndetail,
	quota,
	idexp,
	ymov,
	nmov,
	paridexp,
	nphaseexpense,
	lu,	lt,cu,ct,
	idepexp,
	yepexp,
	nepexp,
	idrelated,
	paridepexp,
	nphaseepexp,
	idupb,codeupb, upb,
	idacc, codeacc, account,
	idfin,codefin, fin,
	idsorkind, codesorkind,sortingkind,
	idsor, sortcode,sorting
)
AS SELECT 
	CTP.idcsa_contract,
	C.ycontract,
	C.ncontract,
	C.active,
	CK.idcsa_contractkind,
	CK.description,
	CK.contractkindcode,
	CK.flagcr,
	CTP.idcsa_contracttax,
	CT.vocecsa,
	CTP.ayear,
	CTP.ndetail,
	CTP.quota,
	EX.idexp,
	EX.ymov,
	EX.nmov,
	EX.parentidexp,
	EX.nphase,
	CTP.lu,	CTP.lt,CTP.cu,CTP.ct,
	EP.idepexp,
	EP.yepexp,
	EP.nepexp,
	EP.idrelated,
	EP.paridepexp,
	EP.nphase,
	U.idupb,U.codeupb, U.title,
	A.idacc, A.codeacc, A.title,
	F.idfin,F.codefin, F.title,
	S.idsorkind, SK.codesorkind,SK.description,
	S.idsor, S.sortcode,S.description 
FROM csa_contracttax_partition CTP 
join csa_contracttax CT
		on CT.idcsa_contract = CTP.idcsa_contract 
	  and CT.ayear = CTP.ayear
	  and  CT.idcsa_contracttax = CTP.idcsa_contracttax 
join csa_contract C
	on CT.idcsa_contract = C.idcsa_contract 
	and CT.ayear = C.ayear
JOIN csa_contractkindyear CKY
	ON C.idcsa_contractkind = CKY.idcsa_contractkind
	AND CKY.ayear = C.ayear
JOIN csa_contractkind CK
	ON C.idcsa_contractkind = CK.idcsa_contractkind
	LEFT OUTER JOIN epexp EP on CTP.idepexp=EP.idepexp
	LEFT OUTER JOIN expense EX on CTP.idexp=EX.idexp
	LEFT OUTER JOIN fin F on CTP.idfin=F.idfin
	LEFT OUTER JOIN upb U on CTP.idupb=U.idupb
	LEFT OUTER JOIN account A on CTP.idacc=A.idacc
	LEFT OUTER JOIN sorting S on CTP.idsor_siope=S.idsor
	LEFT OUTER JOIN sortingkind SK ON SK.idsorkind = S.idsorkind
GO
--setuser 'amm'
--clear_table_info 'csa_contracttax_partitionview'
--select * from [csa_contracttax_partitionview]
 
