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




