
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


-- CREAZIONE VISTA incomevarview
IF EXISTS(select * from sysobjects where id = object_id(N'[incomevarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [incomevarview]
GO
--clear_table_info 'incomevarview'
--select * from incomevarview
--setuser 'amm'

CREATE         VIEW [incomevarview]
(
	idinc,
	nvar,
	yvar,
	nphase,
	phase,
	ymov,
	nmov,
	description_main,
	description,
	amount,
	doc,
	docdate,
	adate,
	transferkind,
	autokind,
	cu,
	ct,
	lu,
	lt,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idunderwriting,
	codeunderwriting,
	underwriting,
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	movkind,
	kproceedstransmission,
	kpro,
	ypro,
	npro,
	kproceedstransmission_orig,
	idman,
	idtreasurer,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	incomevar.idinc,
	incomevar.nvar,
	incomevar.yvar,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	income.description,
	incomevar.description,
	incomevar.amount,
	incomevar.doc,
	incomevar.docdate,
	incomevar.adate,
	incomevar.transferkind,
	incomevar.autokind,
	incomevar.cu,
	incomevar.ct,
	incomevar.lu,
	incomevar.lt,
	fin.idfin,
	fin.codefin,
	fin.title,	
	upb.idupb,
	upb.codeupb,
	upb.title,
	income.idunderwriting,
	underwriting.codeunderwriting,
	underwriting.title,
	incomevar.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	incomevar.yinv,
	incomevar.ninv,
	incomevar.movkind,
	incomevar.kproceedstransmission,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	proceeds.kproceedstransmission,
	income.idman,
	proceeds.idtreasurer,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05
FROM incomevar (NOLOCK)
JOIN income (NOLOCK)
	ON income.idinc = incomevar.idinc
JOIN incomephase (NOLOCK)
	ON incomephase.nphase = income.nphase
JOIN incomeyear (NOLOCK)
	ON incomeyear.idinc= income.idinc
	AND incomeyear.ayear= incomevar.yvar
LEFT OUTER JOIN incomelast (NOLOCK)
	ON incomelast.idinc= income.idinc
LEFT OUTER JOIN proceeds (NOLOCK)
	ON proceeds.kpro = incomelast.kpro
LEFT OUTER JOIN upb (NOLOCK)
	ON upb.idupb= incomeyear.idupb
LEFT OUTER JOIN fin (NOLOCK)
	ON fin.idfin= incomeyear.idfin
LEFT OUTER JOIN invoicekind
	ON incomevar.idinvkind = invoicekind.idinvkind
LEFT OUTER JOIN underwriting
	ON income.idunderwriting = underwriting.idunderwriting	
	







GO
