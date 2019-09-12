--setuser 'amministrazione'

-- CREAZIONE VISTA csa_importver_varresidualview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importver_varresidualview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importver_varresidualview]
GO

SET ANSI_NULLS ON
GO
--setuser 'amm'

SET QUOTED_IDENTIFIER ON
GO 
 -- setuser 'amministrazione'
 -- select * from [csa_importver_varresidualview] order by idinc, idexp
 CREATE VIEW  [csa_importver_varresidualview]
 (
 			kind, idinc, idexp,parentidinc, parentidexp,ymov, nmov, nphase, idpayment, ayear, idfin, idupb, idman, amount,idacccredit,idaccdebit,  idreg,registry, description,
			flag, nbill,cc, cin,iban,idbank,idcab,iddeputy,idregistrypaymethod,
			paymentdescr,refexternaldoc,idpaymethod,biccode,extracode,paymethod_allowdeputy,
			paymethod_flag,idchargehandling
 )
 AS SELECT  'Entrata', income.idinc, null,income.parentidinc,null,income.ymov, income.nmov, income.nphase, income.idpayment, incomeyear.ayear, incomeyear.idfin, incomeyear.idupb, income.idman,incomevar.amount,
			incomelast.idacccredit,null, income.idreg, registry_agency.title, income.description,
			incomelast.flag, incomelast.nbill,null,null,null,null,null,null,null,null,null,null,null,null,null,null, null
			from  income   
			JOIN  incomeyear ON income.idinc = incomeyear.idinc  
			JOIN  incomelast ON income.idinc = incomelast.idinc  
			JOIN  incomevar ON incomevar.idinc = incomelast.idinc  
			JOIN  registry as registry_agency ON registry_agency.idreg = income.idreg 
			--    tipo movimento automatismo versamento CSA
			WHERE incomevar.autokind  = 32
UNION ALL
SELECT		'Spesa', null, expense.idexp, null,expense.parentidexp,expense.ymov, expense.nmov,expense.nphase, expense.idpayment, expenseyear.ayear, expenseyear.idfin, expenseyear.idupb, expense.idman,expensevar.amount,
			null,expenselast.idaccdebit,expense.idreg, registry_agency.title,expense.description,
			expenselast.flag, expenselast.nbill,expenselast.cc, expenselast.cin, expenselast.iban,expenselast.idbank,expenselast.idcab,iddeputy,expenselast.idregistrypaymethod,
			expenselast.paymentdescr,expenselast.refexternaldoc,expenselast.idpaymethod,expenselast.biccode,expenselast.extracode,expenselast.paymethod_allowdeputy,
			expenselast.paymethod_flag,expenselast.idchargehandling

			from  expense  
			JOIN  expenseyear ON expense.idexp = expenseyear.idexp  
			JOIN  expenselast ON expense.idexp = expenselast.idexp  
			JOIN  expensevar ON expensevar.idexp = expenselast.idexp  
			JOIN  registry as registry_agency ON registry_agency.idreg = expense.idreg 
			-- tipo movimento automatismo versamento CSA
			WHERE expensevar.autokind  = 32
 
  