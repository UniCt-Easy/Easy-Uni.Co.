
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_csa_partition_inconsistent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_csa_partition_inconsistent]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser 'amministrazione'
-- exec  check_csa_partition_inconsistent 2018
CREATE  PROCEDURE [check_csa_partition_inconsistent]
(
	@ayear		  int
)
AS BEGIN
 SELECT  DISTINCT 'Ripartizione Regola Specifica' AS'Rip. Incoerente', C.csa_contractkind AS 'Regola generale',  C.description AS 'Regola specifica', C.ycontract AS 'Eserc.', C.ncontract AS 'Numero', 
		C.idcsa_contract as '#id_csacontract' , null AS '#id_csacontracttax' , null AS 'Voce CSA',CF.ndetail AS '#Riga', CF.quota AS 'Quota Rip.Fin.', CE.quota AS 'Quota Rip.EP'
		FROM csa_contractview C		 	
		JOIN csa_contractepexp  CF ON  CF.idcsa_contract = C.idcsa_contract AND CF.ayear = C.ayear 
		JOIN csa_contractexpense CE ON  CE.idcsa_contract = C.idcsa_contract AND CE.ayear = C.ayear   
		WHERE  C.ayear =  @ayear		 AND isnull(C.active, 'N')='S' AND CF.ndetail = CE.ndetail AND CF.quota <> CE.quota
		UNION  
	   SELECT DISTINCT 'Ripartizione Contributo - Voce CSA' AS'Rip. Incoerente',    C.csa_contractkind AS 'Regola generale',  C.description AS 'Regola specifica', C.ycontract AS 'Eserc.', C.ncontract AS 'Numero', 
		C.idcsa_contract AS '#id_csacontract' , CT.idcsa_contracttax AS '#id_csacontracttax' ,   CT.vocecsa AS 'Voce CSA',CF.ndetail AS '#Riga', CF.quota as 'Quota Rip.Fin.', CE.quota AS 'Quota Rip.EP'
		FROM csa_contractview C			
		JOIN csa_contracttax CT ON  C.idcsa_contract = CT.idcsa_contract AND C.ayear = CT.ayear
		JOIN csa_contracttaxepexp  CF ON  CF.idcsa_contract = C.idcsa_contract AND CF.ayear = C.ayear AND CF.idcsa_contracttax = CT.idcsa_contracttax 
		JOIN csa_contracttaxexpense CE ON  CE.idcsa_contract = C.idcsa_contract AND CE.ayear = C.ayear  AND CE.idcsa_contracttax = CT.idcsa_contracttax
		WHERE  C.ayear =  @ayear 	 AND isnull(C.active, 'N')='S'	AND CT.ayear = 2018  AND CF.ndetail = CE.ndetail AND CF.quota <> CE.quota
		order by 
		C.csa_contractkind ,  C.ycontract, C.ncontract 
 END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
