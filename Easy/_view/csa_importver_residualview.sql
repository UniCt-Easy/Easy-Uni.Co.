--setuser 'amministrazione'

-- CREAZIONE VISTA csa_importver_residualview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importver_residualview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importver_residualview]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 
 -- setuser 'amministrazione'
 -- select * from [csa_importver_residualview]
 CREATE VIEW  [csa_importver_residualview]
 (
 			idcsa_import, idver, ndetail, kind, movkind,idinc, idexp,ymov, nmov, nphase, yimport, nimport, ayear, competenza,
			amount, vocecsa, ruolocsa,capitolocsa, csa_contractkindcode, ycontract, ncontract,
			idreg, registry, agency, idreg_agency, registry_agency 
 )
 AS SELECT  csa_importver.idcsa_import,csa_importver.idver, csa_importver_partition_income.ndetail,'Entrata',csa_importver_partition_income.movkind,income.idinc,null, income.ymov,income.nmov,income.nphase,csa_import.yimport, 
			csa_import.nimport, csa_importver.ayear,  csa_importver.competenza,
		    csa_importver_partition.amount, csa_importver.vocecsa,csa_importver.ruolocsa,csa_importver.capitolocsa, 
			contractkindcode as 'csa_contractkindcode', csa_contract.ycontract, csa_contract.ncontract, 
	        csa_importver.idreg, registry.title, csa_agency.description as 'agency', csa_importver.idreg_agency, registry_agency.title 
			from csa_agency  
			JOIN  csa_importver ON csa_importver.idcsa_agency = csa_agency.idcsa_agency
			JOIN  csa_importver_partition ON csa_importver_partition.idcsa_import = csa_importver.idcsa_import AND   csa_importver_partition.idver = csa_importver.idver
			JOIN  csa_importver_partition_income ON csa_importver_partition_income.idcsa_import = csa_importver_partition.idcsa_import
			AND   csa_importver_partition_income.idver = csa_importver_partition.idver AND csa_importver_partition_income.ndetail = csa_importver_partition.ndetail
			JOIN  csa_import ON csa_import.idcsa_import = csa_importver.idcsa_import
			JOIN  income   ON csa_importver_partition_income.idinc = income.idinc  
			JOIN  incomeyear ON income.idinc = incomeyear.idinc AND incomeyear.ayear = csa_import.yimport 
			JOIN  incometotal ON incometotal.idinc = incomeyear.idinc AND incomeyear.ayear = incometotal.ayear 
			JOIN  incomelast ON income.idinc = incomelast.idinc  
			JOIN  incomevar ON incomevar.idinc = incomelast.idinc  
			LEFT OUTER JOIN csa_contract ON csa_contract.idcsa_contract = csa_importver.idcsa_contract
			LEFT OUTER JOIN csa_contractkind ON csa_contractkind.idcsa_contractkind = csa_importver.idcsa_contractkind
			LEFT OUTER JOIN registry ON registry.idreg = csa_importver.idreg
			LEFT OUTER JOIN registry as registry_agency ON registry_agency.idreg = csa_importver.idreg_agency
			WHERE  (ISNULL(csa_agency.flag,0) & 1 <> 0)  --- ente flaggato versamenti posticipati
			-- tipo movimento automatismo versamento CSA
			AND incomevar.autokind  = 32
			AND csa_importver_partition_income.movkind  in (9,10)
			AND csa_importver_partition.amount <0 
			AND incometotal.curramount = 0

UNION ALL
SELECT  csa_importver.idcsa_import, csa_importver.idver, csa_importver_partition_expense.ndetail,'Spesa',csa_importver_partition_expense.movkind,null, expense.idexp,expense.ymov,expense.nmov,expense.nphase,csa_import.yimport, csa_import.nimport, csa_importver.ayear,  csa_importver.competenza,
		    csa_importver_partition.amount, csa_importver.vocecsa,csa_importver.ruolocsa,csa_importver.capitolocsa, contractkindcode as 'csa_contractkindcode', csa_contract.ycontract, csa_contract.ncontract, 
	        csa_importver.idreg, registry.title, csa_agency.description as 'agency', csa_importver.idreg_agency, registry_agency.title 
			from csa_agency  
			JOIN  csa_importver ON csa_importver.idcsa_agency = csa_agency.idcsa_agency
			JOIN  csa_importver_partition ON csa_importver_partition.idcsa_import = csa_importver.idcsa_import AND   csa_importver_partition.idver = csa_importver.idver
			LEFT OUTER JOIN  csa_importver_partition_expense ON csa_importver_partition_expense.idcsa_import = csa_importver_partition.idcsa_import
			AND   csa_importver_partition_expense.idver = csa_importver_partition.idver AND csa_importver_partition_expense.ndetail = csa_importver_partition.ndetail
			JOIN  csa_import ON csa_import.idcsa_import = csa_importver.idcsa_import
			JOIN  expense   ON csa_importver_partition_expense.idexp = expense.idexp  
			JOIN  expenseyear ON expense.idexp = expenseyear.idexp AND expenseyear.ayear = csa_import.yimport 
			JOIN  expensetotal ON expensetotal.idexp = expenseyear.idexp AND expenseyear.ayear = expensetotal.ayear 
			JOIN  expenselast ON expense.idexp = expenselast.idexp  
			JOIN  expensevar ON expensevar.idexp = expenselast.idexp  
			left outer JOIN  csa_contract ON csa_contract.idcsa_contract = csa_importver.idcsa_contract
			LEFT OUTER JOIN csa_contractkind ON csa_contractkind.idcsa_contractkind = csa_importver.idcsa_contractkind
			LEFT OUTER JOIN registry ON registry.idreg = csa_importver.idreg
			LEFT OUTER JOIN registry as registry_agency ON registry_agency.idreg = csa_importver.idreg_agency
			WHERE  (ISNULL(csa_agency.flag,0) & 1 <> 0)  --- ente flaggato versamenti posticipati
			AND csa_importver_partition.amount >0 
			AND expensevar.autokind  = 32
			/*tipo movimento automatismo versamento CSA*/
			AND csa_importver_partition_expense.movkind = 4 
			AND expensetotal.curramount = 0
 
  