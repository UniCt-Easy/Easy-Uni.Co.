
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


-- CREAZIONE VISTA ct_asscredview
IF EXISTS(select * from sysobjects where id = object_id(N'[ct_asscredview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [ct_asscredview]
GO

CREATE                                VIEW ct_asscredview
	(
	idct_asscred,
	idfin_income,
	yfinincome,
	finincomecode,
	finincometitle,
	idsor, sortcode, sorting,
	cu,
	ct,
	lu,
	lt
 	)
	AS SELECT
	ct_asscred.idct_asscred,
	ct_asscred.idfin_income,
	bilancioentrata.ayear,
	bilancioentrata.codefin,
	bilancioentrata.title,
	sorting.idsor, sorting.sortcode, sorting.description,
	ct_asscred.cu,
	ct_asscred.ct,
	ct_asscred.lu,
	ct_asscred.lt
	FROM ct_asscred (NOLOCK)
	JOIN fin bilancioentrata (NOLOCK)
		ON bilancioentrata.idfin = ct_asscred.idfin_income
	join sorting 
		on sorting.idsor = ct_asscred.idsor



GO

-- clear_table_info'ct_asscredview'
