
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


-- CREAZIONE VISTA [csa_importriep_partition_expenseview]
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importriep_partition_expenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importriep_partition_expenseview]
GO  
 --setuser 'amministrazione'
 --setuser 'amm'
--SELECT * FROM [csa_importriep_partition_expenseview]
--DROP VIEW [csa_importriep_partition_expenseview]
CREATE VIEW [csa_importriep_partition_expenseview]
(

	idcsa_import,
	yimport,
	nimport,
	idcsa_contract,
	ycontract,
	ncontract,
	idcsa_contractkind,
	csa_contractkindcode,
	csa_contractkind,
	flagcr,
	idriep,
	idfin_part,codefin_part, fin_part,
	idupb_part,codeupb_part, upb_part,
	importo,
	ndetail,
	amount,
	idexp,
	ymov,
	nmov,
	descrmov,
	paridexp,
	nphaseexpense,
	phase,
	movkind,
	idfin_mov,codefin_mov, fin_mov,
	idupb_mov,codeupb_mov, upb_mov,
	descrmovkind,
	idreg ,
	registry ,
	idreg_main,
	registry_main,
	matricola,
	ruolocsa,
	lu,	lt,cu,ct
)
AS SELECT 
	RE.idcsa_import,
	I.yimport,
	I.nimport,
	IR.idcsa_contract,
	C.ycontract,
	C.ncontract,
	IR.idcsa_contractkind,
	CK.contractkindcode,
	CK.description,
	CK.flagcr,
	RE.idriep,
	F2.idfin,F2.codefin, F2.title,
	U2.idupb,U2.codeupb, U2.title,
	IR.importo,
	RE.ndetail,
	RPE.amount,
	EX.idexp,
	EX.ymov,
	EX.nmov,
	EX.description,
	EX.parentidexp,
	EX.nphase,
	F.description,
	RPE.movkind,
	F1.idfin,F1.codefin, F1.title,
	U1.idupb,U1.codeupb, U1.title,
	MK.description,
	REG.idreg ,
	REG.title ,
	REG_MAIN.idreg,
	REG_MAIN.title,
	IR.matricola,
	IR.ruolocsa,
	RE.lu,	RE.lt,RE.cu,RE.ct
FROM csa_importriep_partition_expense RPE
JOIN csa_importriep_partition RE			ON RPE.idcsa_import = RE.idcsa_import  AND RPE.idriep = RE.idriep AND RPE.ndetail = RE.ndetail
JOIN csa_importriep IR 						ON RE.idcsa_import = IR.idcsa_import and RE.idriep = IR.idriep 
JOIN expense EX								ON RPE.idexp=EX.idexp
LEFT OUTER JOIN registry REG_MAIN			on REG_MAIN.idreg=EX.idreg
LEFT OUTER JOIN registry REG				on REG.idreg=IR.idreg
JOIN csa_import I							ON I.idcsa_import = IR.idcsa_import
LEFT OUTER JOIN csa_contractkind CK			ON IR.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN csa_contract C				ON C.idcsa_contract = IR.idcsa_contract	AND C.idcsa_contractkind = CK.idcsa_contractkind	AND C.ayear = IR.ayear
LEFT OUTER JOIN csa_contractkindyear CKY 	ON C.idcsa_contractkind = CKY.idcsa_contractkind AND CKY.ayear = C.ayear
LEFT OUTER JOIN expensephase F				ON 	F.nphase = EX.nphase
LEFT OUTER JOIN csa_movkind MK				ON 	MK.movkind = RPE.movkind

LEFT OUTER JOIN expenseyear expenseyear_starting with(nolock) 	ON expenseyear_starting.idexp = EX.idexp
  										AND expenseyear_starting.ayear = EX.ymov

LEFT OUTER JOIN fin F2							ON RE.idfin=F2.idfin
LEFT OUTER JOIN upb U2							ON RE.idupb=U2.idupb

LEFT OUTER JOIN fin F1							ON expenseyear_starting.idfin=F1.idfin
LEFT OUTER JOIN upb U1							ON expenseyear_starting.idupb=U1.idupb
GO


