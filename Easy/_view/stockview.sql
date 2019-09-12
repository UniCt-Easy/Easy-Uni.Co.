-- CREAZIONE VISTA stockview
IF EXISTS(select * from sysobjects where id = object_id(N'[stockview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stockview]
GO




--clear_table_info'stockview'
create  VIEW [stockview]
(
	idstock,
	idstore,
	store,
	idlist,
	number,
	residual,
	available,
	amount,
	expiry,
	idmankind,
	mandatekind,
	yman,
	nman,
	man_idgroup,
	idinvkind,
	invoicekind,
	yinv,
	ninv,
	inv_idgroup,
	idddt_in,
	idstoreload_motive,
	storeload_motive,
	list,
	intcode,
	unit,
	yddt_in,
	nddt_in,
	codelistclass,
	listclass,
	authrequired,
	flagto_unload,
	adate,
	idstocklocation,
	stocklocationcode,
	stocklocation,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	stock.idstock,
	store.idstore,
	store.description,
	stock.idlist,
	stock.number,
	stock.number -  ISNULL(
						(SELECT SUM(storeunloaddetail.number)
                       FROM storeunloaddetail 
					  WHERE storeunloaddetail.idstock = stock.idstock),0),
	-- disponibile da prenotare				  
	stock.number - ISNULL(
						(SELECT SUM(storeunloaddetail.number) 
                       FROM storeunloaddetail 
					  WHERE storeunloaddetail.idstock = stock.idstock
					  AND storeunloaddetail.idbooking is null),0)
				 -
				   ISNULL(
						(SELECT SUM(number)
						FROM bookingdetail 
						WHERE stock.idstock = bookingdetail.idstock),0),
	stock.amount,
	stock.expiry,
	stock.idmankind,
	mandatekind.description,
	stock.yman,
	stock.nman,
	stock.man_idgroup,
	stock.idinvkind,
	invoicekind.description,
	stock.yinv,
	stock.ninv,
	stock.inv_idgroup,
	stock.idddt_in,
	stock.idstoreload_motive,
	storeload_motive.description,
	list.description,
	list.intcode,
	unit.description,
	ddt_in.yddt_in,
	ddt_in.nddt_in,
	listclass.codelistclass,
	listclass.title,
	listclass.authrequired,
	flagto_unload,
	stock.adate,
	SL.idstocklocation,
	SL.stocklocationcode,
	SL.description,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05
FROM stock
JOIN store
	ON stock.idstore = store.idstore
JOIN list
	ON list.idlist = stock.idlist
LEFT OUTER JOIN unit
	ON list.idunit = unit.idunit
LEFT OUTER JOIN listclass
	ON listclass.idlistclass = list.idlistclass
LEFT OUTER JOIN mandatekind
	ON mandatekind.idmankind = stock.idmankind
LEFT OUTER JOIN invoicekind
	ON invoicekind.idinvkind = stock.idinvkind
LEFT OUTER JOIN  ddt_in
	ON ddt_in.idddt_in = stock.idddt_in
LEFT OUTER JOIN storeload_motive
	ON storeload_motive.idstoreload_motive = stock.idstoreload_motive
LEFT OUTER JOIN stocklocation SL
	ON SL.idstocklocation = stock.idstocklocation




GO

