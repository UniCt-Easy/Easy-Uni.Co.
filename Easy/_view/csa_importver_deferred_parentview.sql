
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


--setuser 'amministrazione'

-- CREAZIONE VISTA csa_importver_varresidualview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importver_deferred_parentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importver_deferred_parentview]
GO

SET ANSI_NULLS ON
GO
--setuser 'amm'

SET QUOTED_IDENTIFIER ON
GO 
 -- setuser 'amministrazione'
 -- select * from [csa_importver_deferred_parentview] order by idinc, idexp
 CREATE VIEW  [csa_importver_deferred_parentview]
 (
 			kind,parentidinc, parentidexp,ymov, nmov, nphase,phase, parentayear, parentavailable,parentayear_new, parentavailable_new, tot_amount, available
			 
 )
 AS SELECT  'Entrata', income.parentidinc, null,parent.ymov, parent.nmov, parent.nphase,incomephase.description, parincayear.ayear,parincayear.available,parincayear_new.ayear,parincayear_new.available,sum(incomevar.amount),parincayear_new.available+sum(incomevar.amount)
			from  income   
			JOIN  incomeyear ON income.idinc = incomeyear.idinc  
			JOIN  incomelast ON income.idinc = incomelast.idinc  
			JOIN  incomevar ON incomevar.idinc = incomelast.idinc  
			JOIN  registry as registry_agency ON registry_agency.idreg = income.idreg 
			left outer join income enew on enew.parentidinc=income.parentidinc and enew.ymov=income.ymov+1 and enew.autokind=31
			LEFT OUTER JOIN  incometotal parincayear ON income.parentidinc = parincayear.idinc AND parincayear.ayear =   incomeyear.ayear
			LEFT OUTER JOIN  incometotal parincayear_new ON income.parentidinc = parincayear_new.idinc  AND parincayear_new.ayear =   incomeyear.ayear + 1 
			JOIN income   parent ON parent.idinc = income.parentidinc
			JOIN incomephase ON incomephase.nphase = parent.nphase
			--    tipo movimento automatismo versamento CSA
			WHERE incomevar.autokind  = 32  and enew.idinc is null
			GROUP BY income.parentidinc,parincayear.ayear,parincayear.available,parincayear_new.ayear,parincayear_new.available,parent.ymov, parent.nmov, parent.nphase,incomephase.description
UNION ALL
SELECT		'Spesa', null,expense.parentidexp,parent.ymov, parent.nmov, parent.nphase,expensephase.description, parexpayear.ayear,parexpayear.available,parexpayear_new.ayear,parexpayear_new.available,sum(expensevar.amount),parexpayear_new.available+sum(expensevar.amount)
			from  expense  
			JOIN  expenseyear ON expense.idexp = expenseyear.idexp  
			JOIN  expenselast ON expense.idexp = expenselast.idexp  
			JOIN  expensevar ON expensevar.idexp = expenselast.idexp  
			JOIN  registry as registry_agency ON registry_agency.idreg = expense.idreg 
			left outer join expense enew on enew.parentidexp=expense.parentidexp and enew.ymov=expense.ymov+1 and enew.autokind=31
			LEFT OUTER JOIN  expensetotal parexpayear ON expense.parentidexp = parexpayear.idexp AND parexpayear.ayear =   expenseyear.ayear
			LEFT OUTER JOIN  expensetotal parexpayear_new ON expense.parentidexp = parexpayear_new.idexp  AND parexpayear_new.ayear =   expenseyear.ayear + 1 
			JOIN expense   parent ON parent.idexp = expense.parentidexp
			JOIN expensephase ON expensephase.nphase = parent.nphase
			-- tipo movimento automatismo versamento CSA
			WHERE expensevar.autokind  = 32 and enew.idexp is null
 			GROUP BY expense.parentidexp,parexpayear.ayear,parexpayear.available,parexpayear_new.ayear,parexpayear_new.available,parent.ymov, parent.nmov, parent.nphase,expensephase.description
  
