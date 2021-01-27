
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


-- CREAZIONE VISTA csa_importver_varresidualview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_originalsortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_originalsortingview]
GO

SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO 
 -- setuser 'amm'
 -- select * from [csa_originalsortingview]
 CREATE VIEW  [csa_originalsortingview]
 (
 			kind, idinc, idexp, ymov, nmov, nphase, ayear,amount, originalamount, idsor, idsubclass, idreg,registry, description,
			valuen1,valuen2,valuen3,valuen4,valuen5,valuev1,valuev2,valuev3,valuev4,valuev5,values1,values2,values3,values4,values5
 )
 AS SELECT  'Entrata', income.idinc, null, income.ymov, income.nmov, income.nphase,incomesorted.ayear,incomesorted.amount, incomesorted.originalamount, 
			incomesorted.idsor, incomesorted.idsubclass, income.idreg, registry_agency.title, income.description,
			valuen1,valuen2,valuen3,valuen4,valuen5,valuev1,valuev2,valuev3,valuev4,valuev5,values1,values2,values3,values4,values5
			from  income   
			JOIN  incomelast ON income.idinc = incomelast.idinc  
			JOIN  incomesorted ON incomesorted.idinc = incomelast.idinc 
			JOIN  incomevar ON incomevar.idinc = incomelast.idinc  
			JOIN  registry as registry_agency ON registry_agency.idreg = income.idreg 
			--    tipo movimento automatismo versamento CSA
			WHERE incomevar.autokind  = 32
UNION ALL
SELECT		'Spesa', null, expense.idexp, expense.ymov, expense.nmov,expense.nphase, expensesorted.ayear,expensesorted.amount, expensesorted.originalamount, 
			expensesorted.idsor, expensesorted.idsubclass,expense.idreg, registry_agency.title,expense.description,
			valuen1,valuen2,valuen3,valuen4,valuen5,valuev1,valuev2,valuev3,valuev4,valuev5,values1,values2,values3,values4,values5
			from  expense  
			JOIN  expenseyear ON expense.idexp = expenseyear.idexp  
			JOIN  expenselast ON expense.idexp = expenselast.idexp  
			JOIN  expensesorted ON expensesorted.idexp = expenselast.idexp 
			JOIN  expensevar ON expensevar.idexp = expenselast.idexp  
			JOIN  registry as registry_agency ON registry_agency.idreg = expense.idreg 
			-- tipo movimento automatismo versamento CSA
			WHERE expensevar.autokind  = 32
