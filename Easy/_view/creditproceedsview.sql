
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


-- CREAZIONE VISTA creditproceedsview
IF EXISTS(select * from sysobjects where id = object_id(N'[creditproceedsview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [creditproceedsview]
GO

CREATE VIEW [creditproceedsview] 
	(
	idinc,
	nphase,
	phase,
	ymov,
	nmov,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	ayear,
	credit,
	proceeds,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
	)
	AS SELECT
	creditpart.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	allfinlookup.newidfin,
	fin.codefin,
	fin.title,
	creditpart.idupb,
	upb.codeupb,
	upb.title,
	incomeyear.ayear,
	sum(creditpart.amount),
	isnull( (select sum(proceedspart.amount)   from  incomelink (NOLOCK) 
					join   proceedspart (NOLOCK)        
							ON incomelink.idchild=proceedspart.idinc		
							AND proceedspart.idfin in (select newidfin from allfinlookup AA where AA.oldidfin = creditpart.idfin)
						where  incomelink.idparent=creditpart.idinc)
						
			,0),
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05

	FROM creditpart (NOLOCK)
	JOIN income (NOLOCK)
		ON income.idinc = creditpart.idinc
	LEFT OUTER JOIN incomeyear (nolock)
		ON income.idinc = incomeyear.idinc
	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase	
	JOIN allfinlookup (NOLOCK)
		ON allfinlookup.oldidfin = creditpart.idfin
		AND allfinlookup.ayear= incomeyear.ayear
	JOIN fin (NOLOCK)
		ON fin.idfin= allfinlookup.newidfin
	JOIN upb (NOLOCK)
		ON upb.idupb = creditpart.idupb
	
	group by 
	creditpart.idinc,	income.nphase,	incomephase.description,	income.ymov,
	income.nmov,	allfinlookup.newidfin,	fin.codefin,	fin.title,
		creditpart.idupb,	upb.codeupb,	upb.title,	incomeyear.ayear,
		upb.idsor01,	upb.idsor02,	upb.idsor03,	upb.idsor04,	upb.idsor05,
		creditpart.idfin
			
	


GO




