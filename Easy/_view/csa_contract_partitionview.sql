
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


-- CREAZIONE VISTA csa_importriep_partitionview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contract_partitionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contract_partitionview]
GO
 
CREATE VIEW [csa_contract_partitionview]
(
	idcsa_contract,
	ayear,
	ycontract,
	ncontract,
	active,
	idcsa_contractkind,
	csa_contractkind,
	contractkindcode,
	flagcr,
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
	CP.idcsa_contract,
	CP.ayear,
	C.ycontract,
	C.ncontract,
	C.active,
	CK.idcsa_contractkind,
	CK.description,
	CK.contractkindcode,
	CK.flagcr,
	CP.ndetail,
	CP.quota,

	EX.idexp,
	EX.ymov,
	EX.nmov,
	EX.parentidexp,   
	EX.nphase,
	CP.lu,	CP.lt,CP.cu,CP.ct,
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
FROM csa_contract_partition CP
join csa_contract C
	on CP.idcsa_contract = C.idcsa_contract 
	and CP.ayear = C.ayear
JOIN csa_contractkindyear CKY
	ON C.idcsa_contractkind = CKY.idcsa_contractkind
	AND CKY.ayear = C.ayear
JOIN csa_contractkind CK
	ON C.idcsa_contractkind = CK.idcsa_contractkind
	LEFT OUTER JOIN epexp EP on CP.idepexp=EP.idepexp
	LEFT OUTER JOIN expense EX on CP.idexp=EX.idexp
	LEFT OUTER JOIN fin F on CP.idfin=F.idfin
	LEFT OUTER JOIN upb U on CP.idupb=U.idupb
	LEFT OUTER JOIN account A on CP.idacc=A.idacc
	LEFT OUTER JOIN sorting S on CP.idsor_siope=S.idsor
	LEFT OUTER JOIN sortingkind SK ON SK.idsorkind = S.idsorkind
GO
--setuser 'amm'
--clear_table_info 'csa_contract_partitionview'
--select * from csa_contract_partitionview
 
