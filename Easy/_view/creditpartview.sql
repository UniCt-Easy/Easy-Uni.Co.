-- CREAZIONE VISTA creditpartview
IF EXISTS(select * from sysobjects where id = object_id(N'[creditpartview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [creditpartview]
GO



-- setuser 'amm'
-- clear_table_info 'creditpartview'
-- select * from creditpartview
CREATE                                     VIEW creditpartview 
	(
	idinc,
	ncreditpart,
	ycreditpart,
	nphase,
	phase,
	ymov,
	nmov,
	idunderwriting,
	underwriting,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idupb_income,
	codeupb_income,
	upb_income,
	description,
	amount,
	financeincome,
	adate,
	cu,
	ct,
	lu,
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
	)
	AS SELECT
	creditpart.idinc,
	creditpart.ncreditpart,
	creditpart.ycreditpart,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	income.idunderwriting,
	underwriting.title,
	creditpart.idfin,
	fin.codefin,
	fin.title,
	creditpart.idupb,
	upb.codeupb,
	upb.title,
	incomeyear.idupb,
	upb_income.codeupb,
	upb_income.title,
	creditpart.description,
	creditpart.amount,
	b2.codefin,
	creditpart.adate,
	creditpart.cu,
	creditpart.ct,
	creditpart.lu,
	creditpart.lt,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05

	FROM creditpart (NOLOCK)
	JOIN income (NOLOCK) 	ON income.idinc = creditpart.idinc
	LEFT OUTER JOIN incomeyear (nolock) 	ON income.idinc = incomeyear.idinc
								AND incomeyear.ayear = creditpart.ycreditpart 
	JOIN incomephase (NOLOCK)	ON incomephase.nphase = income.nphase
	JOIN fin (NOLOCK)		ON fin.idfin = creditpart.idfin
	JOIN upb (NOLOCK)		ON upb.idupb = creditpart.idupb
	JOIN upb upb_income(NOLOCK)		ON upb_income.idupb = incomeyear.idupb
	LEFT OUTER JOIN fin b2 (NOLOCK) 	ON incomeyear.idfin = b2.idfin
	LEFT OUTER JOIN underwriting		ON underwriting.idunderwriting = income.idunderwriting
		
	








GO

