-- CREAZIONE VISTA csa_importver_varresidualview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_originalsortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_originalsortingview]
GO

SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO 
 -- setuser 'amministrazione'
 -- select * from [csa_originalsortingview]
 CREATE VIEW  [csa_originalsortingview]
 (
 			kind, idinc, idexp, ymov, nmov, nphase, ayear,amount, originalamount, idsor, idsubclass, idreg,registry, description
 )
 AS SELECT  'Entrata', income.idinc, null, income.ymov, income.nmov, income.nphase,incomesorted.ayear,incomesorted.amount, incomesorted.originalamount, 
			incomesorted.idsor, incomesorted.idsubclass, income.idreg, registry_agency.title, income.description
			from  income   
			JOIN  incomelast ON income.idinc = incomelast.idinc  
			JOIN  incomesorted ON incomesorted.idinc = incomelast.idinc 
			JOIN  incomevar ON incomevar.idinc = incomelast.idinc  
			JOIN  registry as registry_agency ON registry_agency.idreg = income.idreg 
			--    tipo movimento automatismo versamento CSA
			WHERE incomevar.autokind  = 32
UNION ALL
SELECT		'Spesa', null, expense.idexp, expense.ymov, expense.nmov,expense.nphase, expensesorted.ayear,expensesorted.amount, expensesorted.originalamount, 
			expensesorted.idsor, expensesorted.idsubclass,expense.idreg, registry_agency.title,expense.description
			from  expense  
			JOIN  expenseyear ON expense.idexp = expenseyear.idexp  
			JOIN  expenselast ON expense.idexp = expenselast.idexp  
			JOIN  expensesorted ON expensesorted.idexp = expenselast.idexp 
			JOIN  expensevar ON expensevar.idexp = expenselast.idexp  
			JOIN  registry as registry_agency ON registry_agency.idreg = expense.idreg 
			-- tipo movimento automatismo versamento CSA
			WHERE expensevar.autokind  = 32