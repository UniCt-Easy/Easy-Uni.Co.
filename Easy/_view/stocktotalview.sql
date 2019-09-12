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

