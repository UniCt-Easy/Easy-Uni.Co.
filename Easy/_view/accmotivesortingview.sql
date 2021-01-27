
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
