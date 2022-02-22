
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


