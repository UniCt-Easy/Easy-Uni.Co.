
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


-- CREAZIONE VISTA upbsortingview
IF EXISTS(select * from sysobjects where id = object_id(N'[accountsortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [accountsortingview]
GO
 
CREATE        VIEW [accountsortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	idacc,
	quota,
	cu,
	ct,
	lu,
	lt,
	codeacc,	
	account,
	ayear,
	flag
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	accountsorting.idsor,
	sorting.sortcode, 
	sorting.description,
	accountsorting.idacc,
	accountsorting.quota,
	accountsorting.cu,
	accountsorting.ct,
	accountsorting.lu,
	accountsorting.lt,
	account.codeacc,	
	account.title,
	account.ayear,
	account.flag
FROM accountsorting
JOIN sorting
	ON sorting.idsor = accountsorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
JOIN account
	ON account.idacc = accountsorting.idacc


 


GO
