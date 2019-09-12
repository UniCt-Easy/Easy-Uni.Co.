-- CREAZIONE VISTA assetrisconti
IF EXISTS(select * from sysobjects where id = object_id(N'[assetrisconti]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetrisconti]
GO
--setuser 'amministrazione'
 
--select top 10 * from assetrisconti  

CREATE    VIEW [assetrisconti]
(
	idasset,
	idpiece,
	mainidasset,
	mainidpiece,
	idinventory,
	inventory,
	ninventory,
	nassetacquire,
	idupb,
	loaddescription,
	idassetunload, 
	idassetunloadkind,
	assetunloadkind,
	yassetunload,
	nassetunload,
	idassetload, 
	idassetloadkind,
	assetloadkind,
	yassetload,
	nassetload,
	
	idaccmotive,

	idsor1,idsor2,idsor3,
	idacc,
	flagaccountusage,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	asset.idasset,
	asset.idpiece,
	assetmain.idasset,
	assetmain.idpiece,
	assetacquire.idinventory,
	inventory.description,
	assetmain.ninventory,
	assetacquire.nassetacquire,
	assetacquire.idupb,
	assetacquire.description,
	asset.idassetunload, assetunload.idassetunloadkind,assetunloadkind.description,	assetunload.yassetunload,assetunload.nassetunload,
	assetacquire.idassetload, 	assetload.idassetloadkind,	assetloadkind.description,	assetload.yassetload,	assetload.nassetload,
	accmotivedetail.idaccmotive,
	assetacquire.idsor1,assetacquire.idsor2,assetacquire.idsor3,
	account.idacc,	account.flagaccountusage,
	asset.cu, 	asset.ct,	asset.lu,	asset.lt
FROM asset	
JOIN asset AS assetmain	ON (asset.idasset = assetmain.idasset) and assetmain.idpiece=1
JOIN assetacquire 	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetload	ON assetacquire.idassetload = assetload.idassetload
LEFT OUTER JOIN assetunload	ON asset.idassetunload = assetunload.idassetunload
JOIN assetloadmotive 	ON assetload.idmot = assetloadmotive.idmot
JOIN accmotivedetail ON  accmotivedetail.idaccmotive = assetloadmotive.idaccmotive and ayear=assetunload.yassetunload
join account  on account.idacc=accmotivedetail.idacc
JOIN inventory		ON inventory.idinventory = assetacquire.idinventory
LEFT OUTER JOIN assetunloadkind 	ON assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
LEFT OUTER JOIN assetloadkind	ON assetloadkind.idassetloadkind = assetload.idassetloadkind
	




GO
