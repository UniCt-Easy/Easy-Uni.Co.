-- CREAZIONE VISTA assetamortizationview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetamortizationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetamortizationview]
GO

CREATE  VIEW [assetamortizationview]
(
	namortization,	idasset,	idpiece,	idinventoryamortization,	codeinventoryamortization,
	inventoryamortization,	official,	idinventory,	inventory,	ninventory,	loaddescription,	description,
	assetvalue,	amortizationquota,	amount,  	adate,	
	idassetunload, 	idassetunloadkind,	assetunloadkind,	yassetunload,	nassetunload,
	idassetload, 	idassetloadkind,	assetloadkind,	yassetload,	nassetload,
	flag,	flagunload,	flagload,	transmitted,	idinv,	codeinv,	inventorytree,
	cu,	ct,	lu,	lt,	rtf,	txt,
	am_year,ass_year,	idinv_lev1,	codeinv_lev1,inventorytree_lev1

)
	AS SELECT
	assetamortization.namortization,
	assetamortization.idasset,
	assetamortization.idpiece,
	assetamortization.idinventoryamortization,
	inventoryamortization.codeinventoryamortization,
	inventoryamortization.description,
	CASE 
		WHEN ((inventoryamortization.flag & 2) <> 0) THEN 'S'
		ELSE 'N'
	END,
	assetacquire.idinventory,
	inventory.description,
	assetmain.ninventory,
	assetacquire.description,
	assetamortization.description,
	assetamortization.assetvalue,
	assetamortization.amortizationquota,
	CONVERT(DECIMAL(19,2),ISNULL(assetamortization.assetvalue, 0) *
	ISNULL(assetamortization.amortizationquota, 0)),
	assetamortization.adate,

	assetamortization.idassetunload,
	assetunload.idassetunloadkind,
	assetunloadkind.description,
	assetunload.yassetunload,
	assetunload.nassetunload,	
	
	assetamortization.idassetload,
	assetload.idassetloadkind,	
	assetloadkind.description,
	assetload.yassetload,
	assetload.nassetload,
	assetamortization.flag,
	CASE 
		WHEN assetamortization.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	CASE 
		WHEN assetamortization.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetamortization.transmitted,
	assetacquire.idinv,
	inventorytree.codeinv,
	inventorytree.description,
	assetamortization.cu,
	assetamortization.ct,
	assetamortization.lu,
	assetamortization.lt,
	assetamortization.rtf,
	assetamortization.txt,
	year(assetamortization.adate),
	year(asset.lifestart),
	inventorytree1.idinv,
	inventorytree1.codeinv,
	inventorytree1.description
FROM assetamortization
JOIN asset
	ON asset.idasset = assetamortization.idasset 
	AND asset.idpiece = assetamortization.idpiece 
JOIN assetacquire
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset AS assetmain
	ON (asset.idasset = assetmain.idasset) AND (assetmain.idpiece = 1)
LEFT OUTER JOIN assetunload
	ON assetamortization.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN assetunloadkind
	ON assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
LEFT OUTER JOIN assetload
	ON assetamortization.idassetload = assetload.idassetload
LEFT OUTER JOIN assetloadkind
	ON assetloadkind.idassetloadkind = assetload.idassetloadkind

LEFT OUTER JOIN inventorytree
	ON inventorytree.idinv = assetacquire.idinv
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
	AND inventorytreelink.nlevel=1
JOIN inventorytree inventorytree1
	ON inventorytree1.idinv = inventorytreelink.idparent
	



GO










