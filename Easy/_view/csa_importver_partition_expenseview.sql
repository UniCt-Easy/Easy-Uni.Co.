
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


 -- CREAZIONE VISTA [csa_importriep_partition_expenseview]
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importver_partition_expenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importver_partition_expenseview]
GO  
 --setuser'amm'
 --setuser 'amministrazione'
 
--SELECT * FROM [capitolocsa]
--DROP VIEW [csa_importver_partition_expenseview]
CREATE       VIEW  [csa_importver_partition_expenseview]
(
	kind,
	idcsa_import,
	yimport,
	nimport,
	idcsa_contract,
	ycontract,
	ncontract,
	idcsa_contractkind,
	csa_contractkindcode,
	csa_contractkind,
	idver,
	importo,
	ayear,
	vocecsa,
	ndetail,
	amount,
	originalamount,
	idexp,
	ymov,
	nmov,
	descrmov,
	paridexp,
	nphaseexpense,
	phase,
	movkind,
	descrmovkind,
	idcsa_agency,
	agency,
	idreg ,
	registry ,
	idreg_main,
	registry_main,
	idreg_agency,
	registry_agency,
	matricola,flagcr,
	ruolocsa,
	capitolocsa,
	lu,	lt,cu,ct

)
AS SELECT 
	CASE WHEN (IV.idcsa_contract = null  AND  IV.idcsa_contractkind=null AND
		       IV.idcsa_contractkinddata=null AND IV.idcsa_contracttax=null AND IV.idcsa_incomesetup=null)	THEN 'Voce CSA'
	 WHEN 	(ISNULL(IV.flagclawback,'N') = 'S')																THEN 'Recupero' 
	 WHEN 	(ISNULL(IV.flagclawback,'N') = 'N' AND 	(IV.idcsa_contractkinddata IS NOT NULL OR IV.idcsa_contracttax IS NOT NULL))  THEN 'Contributo' 
	 ELSE 'Ritenuta' END,
	VE.idcsa_import,
	I.yimport,
	I.nimport,
	IV.idcsa_contract,
	C.ycontract,
	C.ncontract,
	IV.idcsa_contractkind,
	CK.contractkindcode,
	CK.description,
	VE.idver,
	IV.importo,
	IV.ayear,
	IV.vocecsa,
	VE.ndetail,
	PVE.amount,
	PVE.originalamount,
	EX.idexp,
	EX.ymov,
	EX.nmov,
	EX.description,
	EX.parentidexp,
	EX.nphase,
	F.description,
	PVE.movkind,
	MK.description,
	AG.idcsa_agency,
	AG.description,
	REG.idreg ,
	REG.title ,
	REG_MAIN.idreg,
	REG_MAIN.title,
	REG_AG.idreg,
	REG_AG.title,
	IV.matricola, IV.flagcr,
	IV.ruolocsa,
	IV.capitolocsa,
	VE.lu,	VE.lt,VE.cu,VE.ct
FROM csa_importver_partition_expense PVE
JOIN csa_importver_partition VE		ON PVE.idcsa_import = VE.idcsa_import  AND PVE.idver = VE.idver AND PVE.ndetail = VE.ndetail
JOIN csa_importver IV 				ON VE.idcsa_import = IV.idcsa_import and IV.idver = VE.idver
JOIN expense EX						on PVE.idexp=EX.idexp
LEFT OUTER JOIN registry REG_MAIN	on REG_MAIN.idreg=EX.idreg
LEFT OUTER JOIN registry REG		on REG.idreg=IV.idreg
LEFT OUTER JOIN registry REG_AG		on REG_AG.idreg=IV.idreg_agency
LEFT OUTER JOIN csa_agency AG		on AG.idcsa_agency=IV.idcsa_agency
JOIN csa_import I					ON I.idcsa_import = IV.idcsa_import
LEFT OUTER JOIN csa_contractkind CK	ON IV.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN csa_contract C		ON C.idcsa_contract = IV.idcsa_contract	AND C.idcsa_contractkind = CK.idcsa_contractkind AND C.ayear = IV.ayear
LEFT OUTER JOIN csa_contractkindyear CKY	ON C.idcsa_contractkind = CKY.idcsa_contractkind AND CKY.ayear = C.ayear
LEFT OUTER JOIN expensephase F		ON 	F.nphase = EX.nphase
LEFT OUTER JOIN csa_movkind MK		ON 	MK.movkind = PVE.movkind



GO


