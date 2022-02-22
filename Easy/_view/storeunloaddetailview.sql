
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


-- CREAZIONE VISTA storeunloaddetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[storeunloaddetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [storeunloaddetailview]
GO




CREATE   VIEW [storeunloaddetailview]
(
	idstoreunload,
	ystoreunload,
	nstoreunload,
	idstoreunloaddetail,
	idstock,
	idstore,
	storeunload_motive,
	idlist,
	store,
	number,
	idbooking,
	ybooking,
	nbooking,
	forename,
	surname,
	idman,
	manager,
	idinvkind,
	invkind,
	yinv,
	ninv,
	detaildescription,
	rownum,
	adate,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	lu,
	cu,
	ct,
	lt
)
AS SELECT
	storeunloaddetail.idstoreunload,
	storeunload.ystoreunload,
	storeunload.nstoreunload,
	storeunloaddetail.idstoreunloaddetail,
	storeunloaddetail.idstock,
	storeunload.idstore,
	storeunload_motive.description,
	stock.idlist,
	store.description,
	storeunloaddetail.number,
	storeunloaddetail.idbooking,
	booking.ybooking,
	booking.nbooking,
	booking.forename,
	booking.surname,
	manager.idman,
	manager.title,
	storeunloaddetail.idinvkind,
	invoicekind.description,
	storeunloaddetail.yinv,
	storeunloaddetail.ninv,
	invoicedetail.detaildescription,
	storeunloaddetail.rownum,
	storeunload.adate,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05,
	storeunloaddetail.lu,
	storeunloaddetail.cu,
	storeunloaddetail.ct,
	storeunloaddetail.lt
FROM storeunloaddetail
JOIN storeunload 
	ON storeunloaddetail.idstoreunload = storeunload.idstoreunload
LEFT OUTER JOIN booking 
	ON booking.idbooking = storeunloaddetail.idbooking
LEFT OUTER JOIN manager 
	ON manager.idman = storeunloaddetail.idman
LEFT OUTER JOIN  store
	ON store.idstore = storeunload.idstore
LEFT OUTER JOIN  stock
	ON stock.idstock = storeunloaddetail.idstock
LEFT OUTER JOIN  list 
	ON stock.idlist = list.idlist
LEFT OUTER JOIN listclass 
	ON list.idlistclass = listclass.idlistclass
LEFT OUTER JOIN invoicedetail
	ON storeunloaddetail.idinvkind = invoicedetail.idinvkind AND 
	storeunloaddetail.yinv = invoicedetail.yinv AND 
	storeunloaddetail.ninv = invoicedetail.ninv 
LEFT OUTER JOIN invoicekind
	ON invoicekind.idinvkind = invoicedetail.idinvkind  
LEFT OUTER JOIN storeunload_motive
	ON storeunload_motive.idstoreunload_motive = storeunload.idstoreunload_motive

GO

