
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


-- CREAZIONE VISTA underwritingappropriationview
IF EXISTS(select * from sysobjects where id = object_id(N'[underwritingappropriationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [underwritingappropriationview]
GO



CREATE      VIEW [underwritingappropriationview]
(
	idexp,
	nphase,
	expensephase,
	ymov,
	nmov,
	ayear,
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	adate,
	idunderwriting,
	codeunderwriting,
	underwriting,
	amount,
	idfin,
	codefin,
	fin,
	idupb,
	codeupb,
	upb,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expenseyear.ayear,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	expense.doc,
	expense.docdate,
	expense.description,
	expense.adate,
	underwriting.idunderwriting,
	underwriting.codeunderwriting,
	underwriting.title,
	underwritingappropriation.amount,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.idupb,
	upb.codeupb,
	underwritingappropriation.cu,
	underwritingappropriation.ct,
	underwritingappropriation.lu,
	underwritingappropriation.lt
FROM underwritingappropriation
JOIN expense
	ON underwritingappropriation.idexp = expense.idexp
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp	
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN underwriting
	ON underwritingappropriation.idunderwriting = underwriting.idunderwriting
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb


GO

