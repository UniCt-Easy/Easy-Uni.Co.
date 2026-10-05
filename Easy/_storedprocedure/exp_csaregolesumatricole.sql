/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

IF  exists (SELECT * FROM  dbo.sysobjects WHERE id = object_id(N'[exp_csaregolesumatricole]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_csaregolesumatricole]
GO

--setuser'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- [exp_csaregolesumatricole] 2023
CREATE PROCEDURE [exp_csaregolesumatricole]	
	 @anno int /*esercizio configurazione stipendiale*/
AS
select R.surname 'Cognome', R.forename 'Nome', R.extmatricula 'Matricola in Anagrafica', CR.extmatricula 'Matricola in Regola Spec.',CK.description as 'Regola Gener.',
	   CC.ycontract 'Anno Regola Spec. (creazione)', CC.ncontract 'Num. Regola Spec.',cc.description 'Regola Spec.', '*LORDO*' as 'Voce CSA',
	   CP.ndetail as 'n°. Ripart.', CP.quota as 'Quota Ripart.',UPB.codeupb 'Codice UPB' ,CK.flagcr 'Residuo/comp.', 
	   E.ymov 'Anno Mov. Fin', E.nmov 'Num. Mov. Fin', E.nphase 'Fase Mov. Fin', E.available 'Disponibile PreImp. Fin.',
	   IB.yepexp 'Anno Mov. Budg', IB.nepexp 'Num. Mov. Budg.', IB.available 'Disponibile PreImp. Budget' --, 
	   
	   
	   --CT.vocecsa, CTP.quota as 'Quota Ripart . contributo',CTP.ndetail as 'n°. Ripart. contributo', 
	   --EC.ymov 'Anno Mov. Fin contributo', EC.nmov 'Num. Mov. Fin contributo', EC.nphase 'Fase Mov. Fin contributo', EC.available 'Disponibile PreImp. Fin. contributo',
	   --IBC.yepexp 'Anno Mov. Budg contributo', IBC.nepexp 'Num. Mov. Budg. contributo', IBC.available 'Disponibile PreI. Budget contributo'--,
	  -- *
from csa_contractregistry CR
JOIN csa_contract CC ON CR.idcsa_contract = CC.idcsa_contract AND CR.ayear = CC.ayear 
JOIN csa_contract_partition CP ON CP.idcsa_contract = CC.idcsa_contract AND CP.ayear = CC.ayear 
JOIN csa_contractkind CK ON CK.idcsa_contractkind = CC.idcsa_contractkind  
JOIN UPB ON CP.idupb = upb.idupb
LEFT OUTER JOIN expenseview E ON E.idexp = CP.idexp and E.ayear = CP.ayear
LEFT OUTER JOIN epexpview IB ON IB.idepexp = CP.idepexp and IB.ayear = CP.ayear
LEFT OUTER JOIN registry R ON (R.extmatricula = CR.extmatricula OR R.extmatricula = '00'+CR.extmatricula OR R.extmatricula = '0'+CR.extmatricula OR R.extmatricula = '000'+CR.extmatricula)
where CR.ayear = @anno
AND CK.active = 'S'

UNION ALL 
SELECT R.surname 'Cognome', R.forename 'Nome', R.extmatricula 'Matricola in Anagrafica', CR.extmatricula 'Matricola in Regola Spec.', CK.description as 'Regola Gener.', 
	   CC.ycontract 'Anno Regola Spec. (creazione)', CC.ncontract 'Num. Regola Spec.',cc.description 'Regola Spec.',  CT.vocecsa as 'Voce CSA', 
	   CTP.ndetail as 'n°. Ripart.', CTP.quota as 'Quota Ripart.',UPB.codeupb 'Codice UPB' ,CK.flagcr 'Residuo/comp.', 
	   EC.ymov 'Anno Mov. Fin', EC.nmov 'Num. Mov. Fin', EC.nphase 'Fase Mov. Fin', EC.available 'Disponibile PreImp. Fin.',
	   IBC.yepexp 'Anno Mov. Budg', IBC.nepexp 'Num. Mov. Budg.', IBC.available 'Disponibile PreImp. Budget' --, 
	   
	   
	   --CT.vocecsa, CTP.quota as 'Quota Ripart . contributo',CTP.ndetail as 'n°. Ripart. contributo', 
	   --EC.ymov 'Anno Mov. Fin contributo', EC.nmov 'Num. Mov. Fin contributo', EC.nphase 'Fase Mov. Fin contributo', EC.available 'Disponibile PreImp. Fin. contributo',
	   --IBC.yepexp 'Anno Mov. Budg contributo', IBC.nepexp 'Num. Mov. Budg. contributo', IBC.available 'Disponibile PreI. Budget contributo'--,
	  -- *
from csa_contractregistry CR
JOIN csa_contract CC ON CR.idcsa_contract = CC.idcsa_contract AND CR.ayear = CC.ayear 
JOIN csa_contractkind CK ON CK.idcsa_contractkind = CC.idcsa_contractkind  
JOIN csa_contracttax CT ON CT.idcsa_contract = CC.idcsa_contract  and CT.ayear = CC.ayear
LEFT OUTER JOIN csa_contracttax_partition CTP  ON (CT.idcsa_contract = CTP.idcsa_contract  and CT.ayear = CTP.ayear and  CT.idcsa_contracttax = CTP.idcsa_contracttax )
LEFT OUTER JOIN UPB  ON CTP.idupb = UPB.idupb
LEFT OUTER JOIN expenseview EC ON EC.idexp = CTP.idexp and EC.ayear = CTP.ayear
LEFT OUTER JOIN epexpview IBC ON IBC.idepexp = CTP.idepexp and IBC.ayear = CTP.ayear
LEFT OUTER JOIN registry R ON (R.extmatricula = CR.extmatricula OR R.extmatricula = '00'+CR.extmatricula OR R.extmatricula = '0'+CR.extmatricula OR R.extmatricula = '000'+CR.extmatricula)


--LEFT OUTER JOIN csa_contracttax CT ON CT.idcsa_contract = CC.idcsa_contract  and CT.ayear = CC.ayear
--LEFT OUTER JOIN csa_contracttax_partition CTP  ON (CT.idcsa_contract = CTP.idcsa_contract  and CT.ayear = CTP.ayear and  CT.idcsa_contracttax = CTP.idcsa_contracttax )
--LEFT OUTER JOIN expenseview EC ON EC.idexp = CTP.idexp and EC.ayear = CTP.ayear
--LEFT OUTER JOIN epexpview IBC ON IBC.idepexp = CTP.idepexp and IBC.ayear = CTP.ayear

--JOIN csa_contractkindyear CKY  ON CC.idcsa_contractkind = CKY.idcsa_contractkind  AND CKY.ayear = CC.ayear
--LEFT OUTER JOIN csa_contractkinddata CKD ON CK.idcsa_contractkind = CKD.idcsa_contractkind  and CKD.ayear = CKY.ayear

where CR.ayear = @anno
AND CK.active = 'S'
order by R.extmatricula ASC, CR.extmatricula ASC, CK.description ASC, CK.flagcr ASC, CC.ycontract ASC, CC.ncontract ASC, 9 /*voce csa*/, 10 /*ripartizione*/  /*, CT.vocecsa*/  


GO


