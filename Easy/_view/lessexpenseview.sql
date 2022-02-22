
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


-- CREAZIONE VISTA lessexpenseview
IF EXISTS(select * from sysobjects where id = object_id(N'[lessexpenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [lessexpenseview]
GO

CREATE   VIEW lessexpenseview
(
ayear,
idexp,
nphase,
phase,
expensedescription,
parentidexp,
parentymov,
parentnmov,
idformerexpense,
idchild,
ymov,
nmov,
doc,
docdate,
amount,
variationamount,
curramount,
available,
idreg,
registry,
--ycreation,
idfin,
codefin,
finance,
idupb,
codeupb,
upb,
idman,
manager,
idunderwriting,
codeunderwriting,
underwriting,
idsor01,
idsor02,
idsor03,
idsor04,
idsor05
)
AS SELECT
expenseyear.ayear,
expense.idexp,
expense.nphase,
expensephase.description,
expense.description,
expense.parentidexp,
parentexpense.ymov,
parentexpense.nmov,
expense.idformerexpense,
s.idexp,
expense.ymov,
expense.nmov,
expense.doc,
expense.docdate,
expenseyear.amount,
expensevar.amount,
expensetotal.curramount,
expensetotal.available,
expense.idreg,
registry.title,
--expense.ycreation,
expenseyear.idfin,
fin.codefin,
fin.title,
expenseyear.idupb,
upb.codeupb,
upb.title,
expense.idman,
manager.title,
expensevar.idunderwriting,
underwriting.codeunderwriting,
underwriting.title,
upb.idsor01,
upb.idsor02,
upb.idsor03,
upb.idsor04,
upb.idsor05
FROM expense 
JOIN expensephase	ON expense.nphase = expensephase.nphase
JOIN expenseyear    ON expense.idexp = expenseyear.idexp
JOIN expensetotal   ON expenseyear.idexp = expensetotal.idexp
						AND expenseyear.ayear = expensetotal.ayear
LEFT OUTER JOIN registry	ON expense.idreg = registry.idreg
LEFT OUTER JOIN fin			ON expenseyear.idfin = fin.idfin
LEFT OUTER JOIN upb			ON expenseyear.idupb = upb.idupb
LEFT OUTER JOIN manager			ON manager.idman = expense.idman
LEFT OUTER JOIN expense parentexpense	ON expense.parentidexp = parentexpense.idexp
JOIN expensevar							ON expense.idexp = expensevar.idexp
												AND expenseyear.ayear = expensevar.yvar
LEFT OUTER JOIN underwriting	ON underwriting.idunderwriting = expensevar.idunderwriting
LEFT OUTER JOIN expense s				ON expense.idexp = s.idformerexpense
										AND s.ymov = expensevar.yvar+1

WHERE expensevar.autokind = 9 --'ECONO'

--Select * from lessexpenseview






GO


 
