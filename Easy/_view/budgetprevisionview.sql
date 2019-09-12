-- CREAZIONE VISTA budgetprevisionview
IF EXISTS(select * from sysobjects where id = object_id(N'[budgetprevisionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [budgetprevisionview]
GO
 
CREATE  VIEW [budgetprevisionview]
(
	ayear,
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	paridsor,
	nlevel,
	leveldescr,
	idupb,
	codeupb,
	upb,
	paridupb,
	prevision,
	previousprevision,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	ct,
	cu,
	lt,
	lu
)
AS
SELECT
budgetprevision.ayear,
sortingkind.idsorkind,
sortingkind.codesorkind,
sortingkind.description,
budgetprevision.idsor,
sorting.sortcode,
sorting.description,
sorting.paridsor,
sorting.nlevel,
sortinglevel.description,
budgetprevision.idupb,
upb.codeupb,
upb.title,
upb.paridupb,
budgetprevision.prevision,
budgetprevision.previousprevision,
budgetprevision.prevision2,
budgetprevision.prevision3,
budgetprevision.prevision4,
budgetprevision.prevision5,
upb.idsor01,
upb.idsor02,
upb.idsor03,
upb.idsor04,
upb.idsor05,	
budgetprevision.ct,
budgetprevision.cu,
budgetprevision.lt,
budgetprevision.lu
FROM budgetprevision
JOIN sorting		ON budgetprevision.idsor = sorting.idsor
JOIN upb			ON budgetprevision.idupb = upb.idupb
JOIN sortingkind	ON sortingkind.idsorkind = sorting.idsorkind
JOIN sortinglevel	ON sortinglevel.nlevel = sorting.nlevel
							AND sortingkind.idsorkind = sortinglevel.idsorkind

GO


