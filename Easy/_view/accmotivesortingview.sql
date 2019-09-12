-- CREAZIONE VISTA accmotivesortingview
IF EXISTS(select * from sysobjects where id = object_id(N'[accmotivesortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [accmotivesortingview]
GO




CREATE        VIEW [accmotivesortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	idaccmotive,
	
	codemotive,
	title,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	accmotivesorting.idsor,
	sorting.sortcode, 
	sorting.description,
	accmotivesorting.idaccmotive,
	accmotive.codemotive,
	accmotive.title,
	
	accmotivesorting.cu,
	accmotivesorting.ct,
	accmotivesorting.lu,
	accmotivesorting.lt
FROM accmotivesorting
JOIN sorting
	ON sorting.idsor = accmotivesorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
JOIN accmotive
	ON accmotive.idaccmotive = accmotivesorting.idaccmotive

GO

--select * from accmotivesortingview