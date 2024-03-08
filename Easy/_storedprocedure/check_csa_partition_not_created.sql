
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_csa_partition_not_created]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_csa_partition_not_created]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser'amministrazione'
-- exec  check_csa_partition_not_created  2018
CREATE  PROCEDURE [check_csa_partition_not_created]
(
	@ayear		  int
)
AS BEGIN
select 'Ripartizione Regola Specifica' as'Rip. Assente', C.csa_contractkind as 'Regola generale',  C.description as 'Regola specifica', C.ycontract as 'Eserc.', C.ncontract as 'Numero', 
		C.idcsa_contract as '#id_csacontract' , null as '#id_csacontracttax' , null as 'Voce CSA'
		from csa_contractview C		 	
		 WHERE  C.ayear =  2018		 AND isnull(C.active, 'N')='S'
		AND NOT EXISTS (SELECT * FROM csa_contract_partition WHERE  csa_contract_partition.idcsa_contract = C.idcsa_contract AND csa_contract_partition.ayear = C.ayear)
		AND EXISTS (SELECT * FROM csa_contractepexp WHERE  csa_contractepexp.idcsa_contract = C.idcsa_contract AND csa_contractepexp.ayear = C.ayear)
		AND EXISTS (SELECT * FROM csa_contractexpense WHERE  csa_contractexpense.idcsa_contract = C.idcsa_contract AND csa_contractexpense.ayear = C.ayear)
		UNION
	   SELECT  'Ripartizione Contributo - Voce CSA' as'Rip. Assente',    C.csa_contractkind as 'Regola generale',  C.description as 'Regola specifica', C.ycontract as 'Eserc.', C.ncontract as 'Numero', 
		C.idcsa_contract as '#id_csacontract' , CT.idcsa_contracttax as '#id_csacontracttax' ,   CT.vocecsa as 'Voce CSA'
		FROM csa_contractview C			
		JOIN csa_contracttax CT ON  C.idcsa_contract = CT.idcsa_contract AND C.ayear = CT.ayear
		WHERE  C.ayear =  2018 	 AND isnull(C.active, 'N')='S'	AND CT.ayear = 2018 
		AND  NOT EXISTS (SELECT * FROM csa_contracttax_partition WHERE  csa_contracttax_partition.idcsa_contract = CT.idcsa_contract AND csa_contracttax_partition.idcsa_contracttax = CT.idcsa_contracttax  AND csa_contracttax_partition.ayear = CT.ayear)
		AND EXISTS (SELECT * FROM csa_contracttaxepexp WHERE  csa_contracttaxepexp.idcsa_contract = C.idcsa_contract AND csa_contracttaxepexp.ayear = C.ayear)
		AND EXISTS (SELECT * FROM csa_contracttaxexpense WHERE  csa_contracttaxexpense.idcsa_contract = C.idcsa_contract AND csa_contracttaxexpense.ayear = C.ayear)
		order by 		C.idcsa_contract  ,'Rip. Assente' desc
	END

 
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
