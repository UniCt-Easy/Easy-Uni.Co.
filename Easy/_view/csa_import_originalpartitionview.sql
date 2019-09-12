--setuser 'amministrazione'

-- CREAZIONE VISTA csa_importver_originalpartitionview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_import_originalpartitionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_import_originalpartitionview]
GO

SET ANSI_NULLS ON
GO
--setuser 'amm'

--sp_help csa_import_originalpartitionview

SET QUOTED_IDENTIFIER ON
GO 
 -- setuser 'amministrazione'
 
 -- select * from [csa_import_originalpartitionview]
 CREATE VIEW  [csa_import_originalpartitionview]
 (
 			kind, idcsa_import, idinc, idexp, ymov, nmov, nphase, ayear, movkind, idcsa_agency,idreg,registry, description
 )
 AS SELECT  'Entrata', PV.idcsa_import,  
			income.idinc, null, income.ymov, income.nmov, income.nphase,incomeyear.ayear,
			V.idcsa_agency,PV.movkind,income.idreg, registry_agency.title, income.description
			from  income   
			JOIN  incomeyear ON income.idinc = incomeyear.idinc  
			JOIN  incomelast ON income.idinc = incomelast.idinc  
		 	JOIN  incomevar ON incomevar.idinc = incomelast.idinc  
			JOIN  registry as registry_agency ON registry_agency.idreg = income.idreg 
			JOIN  csa_importver_partition_income PV ON PV.idinc = incomelast.idinc
			--    tipo movimento automatismo versamento CSA
			JOIN csa_importver V ON PV.idcsa_import = V.idcsa_import  
			WHERE incomevar.autokind  = 32
UNION ALL
SELECT		'Spesa', PV.idcsa_import, 
			null, expense.idexp, expense.ymov, expense.nmov,expense.nphase, expenseyear.ayear,
			PV.movkind,V.idcsa_agency,expense.idreg, registry_agency.title,expense.description
			from  expense  
			JOIN  expenseyear ON expense.idexp = expenseyear.idexp  
			JOIN  expenselast ON expense.idexp = expenselast.idexp  
			JOIN  expensevar ON expensevar.idexp = expenselast.idexp  
			JOIN  registry as registry_agency ON registry_agency.idreg = expense.idreg 
			JOIN  csa_importver_partition_expense PV ON PV.idexp = expenselast.idexp
			-- tipo movimento automatismo versamento CSA
			JOIN csa_importver V ON PV.idcsa_import = V.idcsa_import  
			WHERE expensevar.autokind  = 32



