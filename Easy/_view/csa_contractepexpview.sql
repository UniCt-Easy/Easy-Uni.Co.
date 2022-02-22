
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


-- CREAZIONE VISTA csa_contractepexpview
--IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contractepexpview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contractepexpview]
GO
 --setuser 'amministrazione'

CREATE      VIEW [csa_contractepexpview]
(
	ayear,
	idcsa_contract,
	ndetail,quota,cu,ct,lu,lt,idepexp,
	yepexp,nepexp,nphase,phase,
	ycontract,ncontract,idcsa_contractkind,
	contractkindcode, contractkind,
	idupb, codeupb,upb,
	idacc, codeacc, account, active
)
AS SELECT 
	C.ayear,
	C.idcsa_contract,
	C.ndetail,C.quota,C.cu,C.ct,C.lu,C.lt,C.idepexp,	
	E.yepexp,E.nepexp,	E.nphase,
	CASE E.nphase
		WHEN 1 THEN 'Preimpegno'
		WHEN 2 THEN 'Impegno'
	END,
	CC.ycontract,	CC.ncontract,CK.idcsa_contractkind,
	CK.contractkindcode,	CK.description,
	upb.idupb, upb.codeupb,upb.title,
	account.idacc, account.codeacc, account.title,CC.active
FROM csa_contractepexp C
join csa_contract CC			on C.idcsa_contract = CC.idcsa_contract and C.ayear = CC.ayear
JOIN csa_contractkind CK		ON CC.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN epexp E			ON C.idepexp = E.idepexp
LEFT OUTER JOIN epexpyear EY	ON C.idepexp = EY.idepexp	AND C.ayear = EY.ayear
LEFT OUTER JOIN account			ON account.idacc = EY.idacc
LEFT OUTER JOIN upb				ON upb.idupb = EY.idupb
GO

 
 
