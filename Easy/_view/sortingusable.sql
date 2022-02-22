
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


-- CREAZIONE VISTA sortingusable
IF EXISTS(select * from sysobjects where id = object_id(N'[sortingusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sortingusable]
GO





--setuser 'amm'
--clear_table_info 'sortingusable'



CREATE        VIEW [sortingusable]
(
	codesorkind,
	idsorkind,
	idsor,
	sortcode,
	nlevel,
	leveldescr,
	paridsor,
	description,
	start,
	stop,
	cu, 
	ct, 
	lu, 
	lt,
	movkind,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT
	sortingkind.codesorkind,
	sorting.idsorkind,
	sorting.idsor,
	sorting.sortcode,
	sorting.nlevel,
	sortinglevel.description,
	sorting.paridsor,
	sorting.description,
	sorting.start, 
	sorting.stop, 
	sorting.cu, 
	sorting.ct, 
	sorting.lu,
	sorting.lt,
	sorting.movkind,
		sorting.idsor01,sorting.idsor02,sorting.idsor03,sorting.idsor04,sorting.idsor05
FROM sorting
JOIN sortinglevel
	ON sortinglevel.nlevel = sorting.nlevel
	AND sortinglevel.idsorkind = sorting.idsorkind
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
WHERE ((sortinglevel.flag & 2) <> 0)
	AND sorting.idsor NOT IN
		(SELECT c1.paridsor FROM sorting c1
		WHERE c1.paridsor IS NOT NULL)





GO
