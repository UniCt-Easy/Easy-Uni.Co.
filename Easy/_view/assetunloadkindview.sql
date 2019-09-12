-- CREAZIONE VISTA assetunloadkindview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetunloadkindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetunloadkindview]
GO




CREATE VIEW assetunloadkindview 
(
	idassetunloadkind,
	description,
	idinventory,
	inventory,
	startnumber,
	flag,
	flaglinear,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	assetunloadkind.idassetunloadkind,
	assetunloadkind.description,
	assetunloadkind.idinventory,
	inventory.description,
 	assetunloadkind.startnumber,
	assetunloadkind.flag,
	CASE
		WHEN assetunloadkind.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetunloadkind.active,
	assetunloadkind.idsor01,
	assetunloadkind.idsor02,
	assetunloadkind.idsor03,
	assetunloadkind.idsor04,
	assetunloadkind.idsor05,
	assetunloadkind.cu,
	assetunloadkind.ct,
	assetunloadkind.lu,
	assetunloadkind.lt
FROM assetunloadkind
JOIN inventory
	ON inventory.idinventory = assetunloadkind.idinventory

GO
