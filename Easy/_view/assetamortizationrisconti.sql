
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


-- CREAZIONE VISTA assetamortizationunloadview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetamortizationrisconti]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetamortizationrisconti]
GO
--setuser 'amministrazione'

--select top 10 * from assetamortizationunloadview where yassetunload=2016

CREATE    VIEW assetamortizationrisconti
(
	namortization,
	idasset,
	idpiece,
	idinventoryamortization,
	codeinventoryamortization,
	inventoryamortization,
	idinventory,
	inventory,
	ninventory,


	nassetacquire,
	idupb,
	loaddescription,
	description,
	assetvalue,
	amortizationquota,
	amount,
  	adate,
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

	flag,
	idsor1,idsor2,idsor3,
	flagunload,
	flagload,
	transmitted,
	idacc,
	flagaccountusage,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	assetamortization.namortization,
	assetamortization.idasset,
	assetamortization.idpiece,
	assetamortization.idinventoryamortization,
	inventoryamortization.codeinventoryamortization,
	inventoryamortization.description,
	assetacquire.idinventory,
	inventory.description,
	assetmain.ninventory,

	assetacquire.nassetacquire,
	assetacquire.idupb,
	assetacquire.description,
	assetamortization.description,
	assetamortization.assetvalue,
	assetamortization.amortizationquota,
	CONVERT(DECIMAL(19,2),ISNULL(assetamortization.assetvalue, 0) *	ISNULL(assetamortization.amortizationquota, 0)),
	assetamortization.adate,
	assetamortization.idassetunload,assetunload.idassetunloadkind,assetunloadkind.description,	assetunload.yassetunload,assetunload.nassetunload,
	assetacquire.idassetload, 	assetload.idassetloadkind,	assetloadkind.description,	assetload.yassetload,	assetload.nassetload,
	
	accmotivedetail.idaccmotive,

	assetamortization.flag,
	assetacquire.idsor1,assetacquire.idsor2,assetacquire.idsor3,
	CASE 	WHEN assetamortization.flag & 1 <> 0 THEN 'S'	ELSE 'N'	END,
	CASE 	WHEN assetamortization.flag & 1 <> 0 THEN 'S'	ELSE 'N'	END,
	assetamortization.transmitted,
	account.idacc,	account.flagaccountusage,
	assetamortization.cu, 	assetamortization.ct,	assetamortization.lu,	assetamortization.lt
FROM assetamortization
JOIN asset		ON asset.idasset = assetamortization.idasset 	AND asset.idpiece = assetamortization.idpiece 
JOIN asset AS assetmain	ON (asset.idasset = assetmain.idasset) and assetmain.idpiece=1
JOIN assetunload	ON assetamortization.idassetunload = assetunload.idassetunload
JOIN assetacquire 	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetload	ON assetacquire.idassetload = assetload.idassetload
JOIN assetloadmotive 	ON assetload.idmot = assetloadmotive.idmot
JOIN accmotivedetail ON  accmotivedetail.idaccmotive = assetloadmotive.idaccmotive and ayear=assetunload.yassetunload
join account  on account.idacc=accmotivedetail.idacc
JOIN inventory		ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
LEFT OUTER JOIN assetunloadkind 	ON assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
LEFT OUTER JOIN assetloadkind	ON assetloadkind.idassetloadkind = assetload.idassetloadkind
	




GO
