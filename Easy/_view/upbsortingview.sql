-- CREAZIONE VISTA upbsortingview
IF EXISTS(select * from sysobjects where id = object_id(N'[upbsortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbsortingview]
GO






CREATE        VIEW [upbsortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	idupb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	quota,
	cu,
	ct,
	lu,
	lt,
	codeupb,	
	upb
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	upbsorting.idsor,
	sorting.sortcode, 
	sorting.description,
	upbsorting.idupb,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	upbsorting.quota,
	upbsorting.cu,
	upbsorting.ct,
	upbsorting.lu,
	upbsorting.lt,
	upb.codeupb,	
	upb.title
FROM upbsorting
JOIN sorting
	ON sorting.idsor = upbsorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
JOIN upb
	ON upb.idupb = upbsorting.idupb





GO
