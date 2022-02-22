
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


-- CREAZIONE VISTA bookingdetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[bookingdetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [bookingdetailview]
GO





CREATE   VIEW [bookingdetailview]
(
	idstore,
	store,
	idbooking,
	ybooking,
	nbooking,
	idlist,
	idstock,
	list,
	intcode,
	idlistclass,
	codelistclass,
	listclass,
	number,
	price,
	authorizedimg,
	authorized,
	idman,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	fulfilled,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	bookingdetail.idstore,
	store.description,
	booking.idbooking,
	booking.ybooking,
	booking.nbooking,
	bookingdetail.idlist,
	bookingdetail.idstock,
	list.description,
	list.intcode,
	list.idlistclass,
	listclass.codelistclass,
	listclass.title,
	bookingdetail.number,
	bookingdetail.price,
	(
	case when bookingdetail.authorized='S' then '<center><img src="Immagini\tl_green.png"></center>'
		  when bookingdetail.authorized='N' then '<center><img src="Immagini\tl_red.png"></center>'
		  when bookingdetail.authorized is null then '<center><img src="Immagini\tl_yellow.png"></center>'
	end
	),
	bookingdetail.authorized,
	booking.idman,
	bookingdetail.idsor1,
	bookingdetail.idsor2,
	bookingdetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	CASE ISNULL(authorized,'N')
		 WHEN 'S' THEN bookingdetail.number - ISNULL((SELECT booktotal.number FROM booktotal 
													   WHERE booktotal.idstore = bookingdetail.idstore AND
															 booktotal.idlist = bookingdetail.idlist AND
															 booktotal.idbooking = bookingdetail.idbooking),0) 
		 ELSE 0
	END,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05,
	bookingdetail.cu,
	bookingdetail.ct,
	bookingdetail.lu,
	bookingdetail.lt
FROM bookingdetail
JOIN booking 
	ON booking.idbooking = bookingdetail.idbooking
JOIN store
	ON store.idstore = bookingdetail.idstore
JOIN list 
	ON bookingdetail.idlist = list.idlist
LEFT OUTER JOIN stock  -- togliere il left outer join tra un po'
	ON bookingdetail.idstock = stock.idstock
LEFT OUTER JOIN listclass 
	ON list.idlistclass = listclass.idlistclass
LEFT OUTER JOIN sorting sorting1
	ON sorting1.idsor = bookingdetail.idsor1
LEFT OUTER JOIN sorting sorting2
	ON sorting2.idsor = bookingdetail.idsor2
LEFT OUTER JOIN sorting sorting3
	ON sorting3.idsor = bookingdetail.idsor3
GO
