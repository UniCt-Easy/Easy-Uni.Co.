-- CREAZIONE VISTA assetloadkindview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetloadkindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetloadkindview]
GO



CREATE VIEW assetloadkindview 
(
	idassetloadkind,
	description,
	idinventory,
	inventory,
	startnumber,
	flag,
	flaglinear,
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
	assetloadkind.idassetloadkind,
	assetloadkind.description,
	assetloadkind.idinventory,
	inventory.description,
	assetloadkind.startnumber,
	assetloadkind.flag, 
	CASE
		WHEN assetloadkind.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetloadkind.idsor01,
	assetloadkind.idsor02,
	assetloadkind.idsor03,
	assetloadkind.idsor04,
	assetloadkind.idsor05,
	assetloadkind.cu,
	assetloadkind.ct,
	assetloadkind.lu,
	assetloadkind.lt
FROM assetloadkind
JOIN inventory
	ON inventory.idinventory = assetloadkind.idinventory






GO
