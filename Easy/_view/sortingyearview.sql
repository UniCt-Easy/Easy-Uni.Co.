
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


-- CREAZIONE VISTA sortingyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[sortingyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sortingyearview]
GO



--setuser 'amm'

CREATE        VIEW [sortingyearview]
	(
	codesorkind,
	idsorkind,
	sortingkind,
	idsor,
	sortcode,
	nlevel,
	leveldescr,
	paridsor,
	description,
	printingorder,
	ayear,
	incomeprevision,
	expenseprevision,
	totexpensevariation,
	totincomevariation,
	totexpense,
	totincome,
	currentincomeprevision,
	currentexpenseprevision,
	availableincomeprevision,
	availableexpenseprevision,
	idman,
	manager,
	start,
	stop,
	cu, 
	ct, 
	lu, 
	lt,
	defaultn1, 
	defaultn2,
	defaultn3, 
	defaultn4, 
	defaultn5, 
	defaults1, 
	defaults2, 
	defaults3, 
	defaults4, 
	defaults5, 
	flagnodate,
	movkind,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
	)
	AS SELECT
	sortingkind.codesorkind,
  	sorting.idsorkind,
	sortingkind.description,
	sorting.idsor,
	sorting.sortcode,
	sorting.nlevel,
	sortinglevel.description,
	sorting.paridsor,
	sorting.description,
	sorting.printingorder,
	accountingyear.ayear,
	sortingprev.incomeprevision,
	sortingprev.expenseprevision,
	sortedmovementtotal.totexpensevariation,
	sortedmovementtotal.totincomevariation,
	sortedmovementtotal.totexpense,
	sortedmovementtotal.totalincome,
	ISNULL(sortingprev.incomeprevision,0) + 
	ISNULL(sortedmovementtotal.totincomevariation,0),
	ISNULL(sortingprev.expenseprevision,0) + 
	ISNULL(sortedmovementtotal.totexpensevariation,0),
	ISNULL(sortingprev.incomeprevision,0) + 
	ISNULL(sortedmovementtotal.totincomevariation,0) -
	ISNULL(sortedmovementtotal.totalincome,0),
	ISNULL(sortingprev.expenseprevision,0) + 
	ISNULL(sortedmovementtotal.totexpensevariation,0) - 
	ISNULL(sortedmovementtotal.totexpense,0),
	manager.idman,
	manager.title,
	sorting.start,
	sorting.stop,
	sorting.cu, 
	sorting.ct, 
	sorting.lu,
	sorting.lt, 
	sorting.defaultn1, 
	sorting.defaultn2,
	sorting.defaultn3, 
	sorting.defaultn4, 
	sorting.defaultn5, 
	sorting.defaults1, 
	sorting.defaults2, 
	sorting.defaults3, 
	sorting.defaults4, 
	sorting.defaults5, 
	sorting.flagnodate,
	sorting.movkind,
	sorting.idsor01,
	sorting.idsor02,
	sorting.idsor03,
	sorting.idsor04,
	sorting.idsor05

FROM sorting
JOIN sortingkind				 ON sortingkind.idsorkind = sorting.idsorkind
CROSS JOIN accountingyear		
JOIN sortinglevel					ON sortinglevel.nlevel = sorting.nlevel AND sortinglevel.idsorkind = sorting.idsorkind
LEFT OUTER JOIN sortingprev			ON sortingprev.idsor = sorting.idsor AND sortingprev.ayear = accountingyear.ayear
LEFT OUTER JOIN sortedmovementtotal ON  sortedmovementtotal.idsor = sorting.idsor AND sortedmovementtotal.ayear = accountingyear.ayear
LEFT OUTER JOIN managersorting		ON managersorting.idsor = sorting.idsor
LEFT OUTER JOIN manager				ON manager.idman = managersorting.idman




--sp_help sortedmovementtotal
--sp_help managersorting




GO
