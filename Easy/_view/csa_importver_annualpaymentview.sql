
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


-- CREAZIONE VISTA csa_importver_annualpaymentview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importver_annualpaymentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importver_annualpaymentview]
GO

 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
 --setuser 'amministrazione'
 --select * from [csa_importver_annualpaymentview]
 CREATE VIEW  [csa_importver_annualpaymentview]
 (
 			idcsa_import, yimport, nimport, ayear, idver,ndetail, competenza,
			amount, vocecsa, ruolocsa,capitolocsa, csa_contractkindcode, ycontract, ncontract,
			idreg,registry, idcsa_agency, agency, idreg_agency ,registry_agency 
 )
 AS SELECT csa_importver.idcsa_import,csa_import.yimport, csa_import.nimport, csa_importver.ayear, csa_importver.idver, csa_importver_partition.ndetail, csa_importver.competenza,
	   csa_importver_partition.amount, csa_importver.vocecsa,csa_importver.ruolocsa,csa_importver.capitolocsa, contractkindcode as 'csa_contractkindcode', csa_contract.ycontract, csa_contract.ncontract, 
	   csa_importver.idreg, registry.title,csa_agency.idcsa_agency, csa_agency.description as 'agency', csa_importver.idreg_agency, registry_agency.title 
			FROM csa_agency  
			JOIN  csa_importver ON csa_importver.idcsa_agency = csa_agency.idcsa_agency
			JOIN  csa_importver_partition ON csa_importver_partition.idcsa_import = csa_importver.idcsa_import
			AND   csa_importver_partition.idver = csa_importver.idver
			JOIN csa_import ON csa_import.idcsa_import = csa_importver.idcsa_import
			LEFT OUTER JOIN csa_contract ON csa_contract.idcsa_contract = csa_importver.idcsa_contract
			LEFT OUTER JOIN csa_contractkind ON csa_contractkind.idcsa_contractkind = csa_importver.idcsa_contractkind
			LEFT OUTER JOIN registry ON registry.idreg = csa_importver.idreg
			LEFT OUTER JOIN registry as registry_agency ON registry_agency.idreg = csa_importver.idreg_agency
			LEFT OUTER JOIN expense ON expense.idexp = csa_importver.idexp_cost
			WHERE (ISNULL(csa_agency.flag,0) & 1 <> 0) AND 
			NOT EXISTS (SELECT * FROM csa_importver_partition_expense V where V.idcsa_import =csa_importver_partition.idcsa_import  
            and V.idver = csa_importver_partition.idver AND V.movkind = 4)  
			AND NOT EXISTS (SELECT * FROM csa_importver_partition_income V where V.idcsa_import =csa_importver_partition.idcsa_import  
            and V.idver = csa_importver_partition.idver AND V.movkind in (9, 10))  
			
	
GO

 
