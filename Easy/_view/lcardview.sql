-- CREAZIONE VISTA lcardview
IF EXISTS(select * from sysobjects where id = object_id(N'[lcardview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [lcardview]
GO



--clear_table_info'lcard'
create  VIEW [lcardview](
	idlcard,
	title,
	description,
	ystart,
	ystop,
	active,
	idman,
	manager,
	idstore,
	store,
	extcode,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	lt,
	lu
)
AS
SELECT
	lcard.idlcard,
	lcard.title,
	lcard.description,
	lcard.ystart,
	lcard.ystop,
	lcard.active,
	lcard.idman,
	manager.title,
	lcard.idstore,
	store.description,
	lcard.extcode,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05,
	lcard.lt,
	lcard.lu
FROM lcard
JOIN store
	ON lcard.idstore = store.idstore
JOIN manager
	ON lcard.idman = manager.idman

GO

