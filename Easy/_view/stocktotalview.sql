
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


-- CREAZIONE VISTA stocktotalview
IF EXISTS(select * from sysobjects where id = object_id(N'[stocktotalview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stocktotalview]
GO



CREATE   VIEW [stocktotalview]
(
	idstore,
	store,
	deliveryaddress,
	idlist,
	list,
	intcode,
	idlistclass,
	codelistclass,
	listclass,
	number,
	ordered,
	booked,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT
	store.idstore,
	store.description,
	store.deliveryaddress,
	list.idlist,
	list.description,
	list.intcode,
	list.idlistclass,
	listclass.codelistclass,
	listclass.title,
	ISNULL(stocktotal.number,0),
	ISNULL(stocktotal.ordered,0),
	ISNULL(stocktotal.booked,0),
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05
FROM list
CROSS JOIN store 
LEFT OUTER JOIN stocktotal
	ON stocktotal.idstore = store.idstore
	AND stocktotal.idlist = list.idlist
LEFT OUTER JOIN listclass 
	ON list.idlistclass = listclass.idlistclass


GO

