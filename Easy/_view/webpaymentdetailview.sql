
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


-- CREAZIONE VISTA webpaymentdetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[webpaymentdetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [webpaymentdetailview]
GO


-- select * from webpaymentdetailview
-- clear_table_info'webpaymentdetailview'

--setuser 'amm'
CREATE   VIEW [webpaymentdetailview]
(
	idstore,
	store,
	idwebpayment,
	iddetail,
	ywebpayment,
	nwebpayment,
	idlist,
	list,
	intcode,
	idlistclass,
	codelistclass,
	listclass,
	number,
	price, tax,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	cu,
	ct,
	lu,
	lt,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	annotations,
	idinvkind,
	competencystart,
	competencystop,
	idupb_iva

)
AS SELECT
	webpaymentdetail.idstore,
	store.description,
	webpayment.idwebpayment,
	webpaymentdetail.iddetail,
	webpayment.ywebpayment,
	webpayment.nwebpayment,
	webpaymentdetail.idlist,
	list.description,
	list.intcode,
	list.idlistclass,
	listclass.codelistclass,
	listclass.title,
	webpaymentdetail.number,
	webpaymentdetail.price,
	webpaymentdetail.tax,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05,
	webpaymentdetail.cu,
	webpaymentdetail.ct,
	webpaymentdetail.lu,
	webpaymentdetail.lt,
	webpaymentdetail.idsor1,
	webpaymentdetail.idsor2,
	webpaymentdetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	webpaymentdetail.annotations, 
	webpaymentdetail.idinvkind,
	webpaymentdetail.competencystart,
	webpaymentdetail.competencystop,
	webpaymentdetail.idupb_iva
FROM webpaymentdetail
JOIN webpayment				ON webpayment.idwebpayment = webpaymentdetail.idwebpayment
JOIN store					ON store.idstore = webpaymentdetail.idstore
JOIN list					ON webpaymentdetail.idlist = list.idlist
LEFT OUTER JOIN listclass 	ON list.idlistclass = listclass.idlistclass
LEFT OUTER JOIN sorting sorting1	ON sorting1.idsor = webpaymentdetail.idsor1
LEFT OUTER JOIN sorting sorting2	ON sorting2.idsor = webpaymentdetail.idsor2
LEFT OUTER JOIN sorting sorting3	ON sorting3.idsor = webpaymentdetail.idsor3


GO

