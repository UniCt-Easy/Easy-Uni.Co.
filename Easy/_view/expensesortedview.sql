
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


-- CREAZIONE VISTA expensesortedview
IF EXISTS(select * from sysobjects where id = object_id(N'[expensesortedview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expensesortedview]
GO



 
--clear_table_info 'expensesortedview'
--select * from [expensesortedview]

--setuser 'amministrazione'



CREATE  VIEW [expensesortedview]
(
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	idsubclass,
	idsorkind,
	codesorkind,
	idsor,
	sortcode,
	sorting,
	amount,
	originalamount,
	description,
	adate,
	cu,
	ct,
	lu,
	lt,
	flagnodate, 
	tobecontinued, 
	start, 
	stop, 
	valuen1, 
	valuen2,                       
	valuen3, 
	valuen4, 
	valuen5, 
	values1, 
	values2, 
	values3, 
	values4, 
	values5, 
	valuev1, 
	valuev2, 
	valuev3, 
	valuev4, 
	valuev5, 
	paridsorkind, 
	parcodesorkind,
	paridsor, 
	paridsubclass,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	ayear,
	totflag,
	flagarrear,
	registry,
	npay,
	expensedescr,
	npaymenttransmission,
	ypaymenttransmission
)
AS SELECT
	expensesorted.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expensesorted.idsubclass,
	sorting.idsorkind,
	sortingkind.codesorkind,
	expensesorted.idsor,
	sorting.sortcode,
	sorting.description,
	expensesorted.amount,
	expensesorted.originalamount,
	expensesorted.description,
	expense.adate,
	expensesorted.cu,
	expensesorted.ct,
	expensesorted.lu,
	expensesorted.lt,
	expensesorted.flagnodate, 
	expensesorted.tobecontinued, 
	expensesorted.start, 
	expensesorted.stop, 
	expensesorted.valuen1, 
	expensesorted.valuen2,                       
	expensesorted.valuen3, 
	expensesorted.valuen4, 
	expensesorted.valuen5, 
	expensesorted.values1, 
	expensesorted.values2, 
	expensesorted.values3, 
	expensesorted.values4, 
	expensesorted.values5, 
	expensesorted.valuev1, 
	expensesorted.valuev2, 
	expensesorted.valuev3, 
	expensesorted.valuev4, 
	expensesorted.valuev5, 
	parsor.idsorkind, 
	parsorkind.codesorkind,
	expensesorted.paridsor, 
	expensesorted.paridsubclass,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	expenseyear.ayear,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END,
	registry.title,
	payment.npay,
	expense.description,
	paymenttransmission.npaymenttransmission,
	paymenttransmission.ypaymenttransmission
FROM expensesorted	
JOIN expense (NOLOCK)		ON expense.idexp = expensesorted.idexp
JOIN expensephase (NOLOCK)		ON expensephase.nphase = expense.nphase
JOIN sorting (NOLOCK)			ON sorting.idsor = expensesorted.idsor
JOIN sortingkind (NOLOCK)		ON sortingkind.idsorkind = sorting.idsorkind
JOIN expenseyear (NOLOCK)		ON expenseyear.idexp = expense.idexp
								AND expenseyear.ayear= expensesorted.ayear
JOIN expensetotal  (NOLOCK)		ON expensetotal.idexp = expense.idexp
							AND expensetotal.ayear= expenseyear.ayear
LEFT OUTER JOIN sorting  parsor (NOLOCK)	ON parsor.idsor = expensesorted.paridsor
LEFT OUTER JOIN sortingkind parsorkind		ON parsorkind.idsorkind = parsor.idsorkind
LEFT OUTER JOIN fin (NOLOCK)				ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb   (NOLOCK)				ON upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry (NOLOCK)			ON registry.idreg = expense.idreg
LEFT OUTER JOIN expenselast (NOLOCK)		ON expenselast.idexp = expensesorted.idexp
LEFT OUTER JOIN payment (NOLOCK)			ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN paymenttransmission (NOLOCK) 
ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission

GO

 
