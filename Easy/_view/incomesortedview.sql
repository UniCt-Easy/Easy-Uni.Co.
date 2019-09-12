-- CREAZIONE VISTA incomesortedview
IF EXISTS(select * from sysobjects where id = object_id(N'[incomesortedview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [incomesortedview]
GO

--setuser 'amministrazione'
--clear_table_info 'incomesortedview'
--select * from incomesortedview
CREATE  VIEW [incomesortedview]
(
	idinc,
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
	npro,
	incomedescr,
	nproceedstransmission,
	yproceedstransmission
)
AS
SELECT
	incomesorted.idinc, 
	income.nphase, 
	incomephase.description AS phase, 
	income.ymov, income.nmov, 
	incomesorted.idsubclass, 
	sorting.idsorkind, 
	sortingkind.codesorkind,
	incomesorted.idsor, 
	sorting.sortcode, 
	sorting.description AS sorting, 
	incomesorted.amount, 
	incomesorted.originalamount,
	incomesorted.description, 
	income.adate, 
	incomesorted.cu, 
	incomesorted.ct, 
	incomesorted.lu, 
	incomesorted.lt, 
	incomesorted.flagnodate, 
	incomesorted.tobecontinued, 
	incomesorted.start, 
	incomesorted.stop, 
	incomesorted.valuen1, 
	incomesorted.valuen2, 
	incomesorted.valuen3, 
	incomesorted.valuen4, 
	incomesorted.valuen5, 
	incomesorted.values1, 
	incomesorted.values2, 
	incomesorted.values3, 
	incomesorted.values4, 
	incomesorted.values5, 
	incomesorted.valuev1, 
	incomesorted.valuev2, 
	incomesorted.valuev3, 
	incomesorted.valuev4, 
	incomesorted.valuev5, 
	parsor.idsorkind, 
	parsorkind.codesorkind,
	incomesorted.paridsor, 
	incomesorted.paridsubclass, 
	incomeyear.idfin, 
	fin.codefin, 
	fin.title AS finance, 
	upb.idupb,
	upb.codeupb,
	upb.title AS upb,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	incomeyear.ayear,
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END,
	registry.title,
	npro,
	income.description,
	proceedstransmission.nproceedstransmission,
	proceedstransmission.yproceedstransmission
FROM incomesorted
JOIN income (NOLOCK)		ON income.idinc = incomesorted.idinc 
JOIN incomephase (NOLOCK)	ON incomephase.nphase = income.nphase 
JOIN sorting (NOLOCK)		ON sorting.idsor = incomesorted.idsor 
JOIN sortingkind (NOLOCK)	ON sortingkind.idsorkind = sorting.idsorkind
LEFT OUTER JOIN sorting parsor (NOLOCK)	ON parsor.idsor = incomesorted.paridsor
LEFT OUTER JOIN sortingkind parsorkind (NOLOCK)	ON parsorkind.idsorkind = parsor.idsorkind
JOIN incomeyear (NOLOCK)	ON incomeyear.idinc = income.idinc 
								AND incomeyear.ayear= incomesorted.ayear	
JOIN incometotal (NOLOCK)	ON incometotal.idinc = incomeyear.idinc 
								AND incometotal.ayear= incomeyear.ayear
LEFT OUTER JOIN fin (NOLOCK)	ON fin.idfin = incomeyear.idfin 
LEFT OUTER JOIN upb (NOLOCK)	ON upb.idupb=incomeyear.idupb
LEFT OUTER JOIN registry (NOLOCK)	ON registry.idreg=income.idreg
LEFT OUTER JOIN incomelast (NOLOCK)	ON incomelast.idinc = incomesorted.idinc
LEFT OUTER JOIN proceeds (NOLOCK)	ON proceeds.kpro = incomelast.kpro
LEFT OUTER JOIN proceedstransmission (NOLOCK) 
ON proceeds.kproceedstransmission= proceedstransmission.kproceedstransmission


 



GO
