
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_csa_partition_inconsistent_riep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_csa_partition_inconsistent_riep]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser'amministrazione'
-- exec  check_csa_partition_inconsistent_riep 2018
CREATE  PROCEDURE [check_csa_partition_inconsistent_riep]
(
	@ayear		  int,
	@idcsa_import int = null
)
AS BEGIN
 SELECT  DISTINCT CASE WHEN CE.ndetail IS NULL THEN 'Rip. EP assente'  WHEN CF.ndetail IS NULL THEN  'Rip. fin. assente' ELSE 'Rip. incoerente' END  AS 'Rip. Incoerente',C.idcsa_import,  C.yimport AS 'Eserc. importazione', C.nimport AS 'Numero importazione', C.csa_contractkind AS 'Regola generale',    C.ycontract AS 'Eserc. regola', C.ncontract AS 'Numero regola', 
		C.idcsa_contract as '#id_csacontract' ,  C.idriep,CF.ndetail AS '#Riga', CF.amount AS 'Importo Rip.Fin.', convert(decimal(19,2),round(CE.quota*C.importo,2)) AS 'Importo Rip.EP'
		FROM  
		csa_importriepview C		 	
		JOIN csa_importriep_expense  CF ON  CF.idcsa_import = C.idcsa_import AND CF.idriep = C.idriep 
		JOIN csa_importriep_epexp CE ON  CE.idcsa_import = C.idcsa_import AND CE.idriep = C.idriep    AND CF.ndetail = CE.ndetail AND CF.amount <> convert(decimal(19,2),round(CE.quota*C.importo,2))
		WHERE  C.ayear =  @ayear	  AND (C.idcsa_import = @idcsa_import OR @idcsa_import IS NULL) AND ((CF.ndetail IS NOT NULL) OR (CE.ndetail IS NOT NULL))
		 
		order by 
		C.csa_contractkind ,  C.ycontract, C.ncontract, C.idriep , CF.ndetail 
 END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
