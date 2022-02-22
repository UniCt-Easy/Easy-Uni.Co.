
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


-- CREAZIONE VISTA ct_asscreddetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[ct_asscreddetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [ct_asscreddetailview]
GO

CREATE                                VIEW ct_asscreddetailview
	(
	idct_asscred,
	idfin_income,
	yfinincome,
	finincomecode,
	finincometitle,
	idfin_expense,
	yfinexpense,
	finexpensecode,
	finexpensetitle,
	idsor, sortcode, sorting,
	quota,
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
	ct_asscreddetail.idfin_expense,
	bilanciospesa.ayear,
	bilanciospesa.codefin,
	bilanciospesa.title,
	ct_asscred.idsor, sorting.sortcode,sorting.description,
	ct_asscreddetail.quota,
	ct_asscreddetail.cu,
	ct_asscreddetail.ct,
	ct_asscreddetail.lu,
	ct_asscreddetail.lt
	FROM ct_asscred (NOLOCK)
	join sorting
		on ct_asscred.idsor =sorting.idsor
	JOIN fin bilancioentrata (NOLOCK)
		ON bilancioentrata.idfin = ct_asscred.idfin_income
	join ct_asscreddetail (NOLOCK)
		on ct_asscred.idct_asscred = ct_asscreddetail.idct_asscred
	JOIN fin bilanciospesa (NOLOCK)
		ON bilanciospesa.idfin = ct_asscreddetail.idfin_expense
		

GO

