
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
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importriep_partitionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importriep_partitionview]
GO

CREATE VIEW [csa_importriep_partitionview]
(

	ayear,
	competency,
	idcsa_import,
	yimport,
	nimport,
	idriep,
	ndetail,
	idcsa_contract,
	ycontract,
	ncontract,
	idcsa_contractkind,
	csa_contractkindcode,
	csa_contractkind,
	ruolocsa,	
	capitolocsa,
	competenza,
	flagcr,

	idreg,
	registry,
	matricola,
	amount,
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
	idunderwriting,
	underwriting,
	idupb,codeupb, upb,idman,
	idacc, codeacc, account,flagaccountusage,descflagaccountusage,
	idfin,codefin, fin,
	idsorkind, codesorkind,sortingkind,
	idsor_siope, sortcode_siope,sorting_siope
)
AS SELECT 
	IR.ayear,
	IR.competency,
	RE.idcsa_import,
	I.yimport,
	I.nimport,
	RE.idriep,
	RE.ndetail,
	IR.idcsa_contract,
	C.ycontract,
	C.ncontract,
	IR.idcsa_contractkind,
	CK.contractkindcode,
	CK.description,
	IR.ruolocsa,	
	IR.capitolocsa,
	IR.competenza,
	IR.flagcr,
	IR.idreg,
	registry.title,
	IR.matricola,
	RE.amount,
	EX.idexp,
	EX.ymov,
	EX.nmov,
	EX.parentidexp,
	EX.nphase,
	RE.lu,	RE.lt,RE.cu,RE.ct,
	EP.idepexp,
	EP.yepexp,
	EP.nepexp,
	EP.idrelated,
	EP.paridepexp,
	EP.nphase,
	IR.idunderwriting,
	underwriting.title,
	U.idupb,U.codeupb, U.title,
	U.idman,
	A.idacc, A.codeacc, A.title,A.flagaccountusage,
		CASE 		when (( A.flagaccountusage & 1) <> 0)  then 'Ratei attivi'
		 		when (( A.flagaccountusage & 2) <> 0)  then 'Ratei Passivi'
		 		when (( A.flagaccountusage & 4) <> 0)  then 'Risconti Attivi'
		 		when (( A.flagaccountusage & 8) <> 0)  then 'Risconti Passivi'
		 		when (( A.flagaccountusage & 16) <> 0)  then 'Debito'
		 		when (( A.flagaccountusage & 32) <> 0)  then 'Credito'
		 		when (( A.flagaccountusage & 64) <> 0)  then 'Costi'
		 		when (( A.flagaccountusage & 128) <> 0)  then 'Ricavi'
		 		when (( A.flagaccountusage & 256) <> 0)  then 'Immobilizzazioni'
		 		when (( A.flagaccountusage & 512) <> 0)  then 'Avanzo libero'
		 		when (( A.flagaccountusage & 1024) <> 0)  then 'Avanzo vincolato'
		 		when (( A.flagaccountusage & 2048) <> 0)  then 'Riserva'
		 		when (( A.flagaccountusage & 4096) <> 0)  then 'Accantonamento'
		 		when (( A.flagaccountusage & 8192) <> 0)  then 'Disponibilità liquide'
		 		when (( A.flagaccountusage & 32768) <> 0) then 'Fondi ammortamento'
		 		when (( A.flagaccountusage & 131072) <> 0)  then 'Ammortamento'
		else null
		end,
		
	F.idfin,F.codefin, F.title,
	S.idsorkind, SK.codesorkind,SK.description,
	S.idsor, S.sortcode,S.description	 
FROM csa_importriep_partition RE
JOIN csa_importriep IR 	ON RE.idcsa_import = IR.idcsa_import AND RE.idriep = IR.idriep
JOIN csa_import I
	ON I.idcsa_import = IR.idcsa_import
LEFT OUTER JOIN csa_contractkind CK
	ON IR.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN csa_contract C
	ON C.idcsa_contract = IR.idcsa_contract
	AND C.idcsa_contractkind = CK.idcsa_contractkind
	AND C.ayear = IR.ayear
LEFT OUTER JOIN csa_contractkindyear CKY
	ON C.idcsa_contractkind = CKY.idcsa_contractkind
	AND CKY.ayear = C.ayear
	LEFT OUTER JOIN registry ON IR.idreg = registry.idreg
	LEFT OUTER JOIN epexp EP on RE.idepexp=EP.idepexp
	LEFT OUTER JOIN expense EX on RE.idexp=EX.idexp
	LEFT OUTER JOIN fin F on RE.idfin=F.idfin
	LEFT OUTER JOIN upb U on RE.idupb=U.idupb
	LEFT OUTER JOIN account A on RE.idacc=A.idacc
	LEFT OUTER JOIN underwriting	ON IR.idunderwriting = underwriting.idunderwriting
	LEFT OUTER JOIN sorting S on RE.idsor_siope=S.idsor
	LEFT OUTER JOIN sortingkind SK ON SK.idsorkind = S.idsorkind
GO
--setuser 'amm'
--clear_table_info 'csa_importriep_partitionview'
--select * from csa_importriep_partitionview
 
