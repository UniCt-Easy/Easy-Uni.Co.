
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
IF EXISTS(select * from sysobjects where id = object_id(N'[assetamortizationunloadview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetamortizationunloadview]
GO


--setuser 'amministrazione'
--select top 10 * from assetamortizationunloadview

CREATE    VIEW assetamortizationunloadview
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

	idlocation,	locationcode,	location,	idcurrlocation,	currlocationcode,
	currlocation,	idman,	manager,	idcurrman,	currmanager,

	nassetacquire,
	idupb,
	loaddescription,
	description,
	assetvalue,
	amortizationquota,
	amount,
  	adate,
	idassetunload,	idassetunloadkind,	assetunloadkind,	yassetunload,	nassetunload,
	idassetload, 	idassetloadkind,	assetloadkind,	yassetload,	nassetload,

	flag,	flagunload,	flagload,	transmitted,
	idsor1,idsor2,idsor3,
	cu,	ct,	lu,	lt
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

	location.idlocation,	location.locationcode,	location.description,	CL.idlocation,	CL.locationcode,	CL.description,
	manager.idman,	manager.title,	CM.idman,	CM.title,

	assetacquire.nassetacquire,
	assetacquire.idupb,
	assetacquire.description,
	assetamortization.description,
	assetamortization.assetvalue,
	assetamortization.amortizationquota,
	CONVERT(DECIMAL(19,2),ISNULL(assetamortization.assetvalue, 0) *
	ISNULL(assetamortization.amortizationquota, 0)),
	assetamortization.adate,
	assetamortization.idassetunload,	assetunload.idassetunloadkind,	assetunloadkind.description,	assetunload.yassetunload,	assetunload.nassetunload,
	assetamortization.idassetload,	assetload.idassetloadkind,	assetloadkind.description,	assetload.yassetload,	assetload.nassetload,



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
	assetacquire.idsor1,assetacquire.idsor2,assetacquire.idsor3,
	assetamortization.cu,
	assetamortization.ct,
	assetamortization.lu,
	assetamortization.lt
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
	ON (asset.idasset = assetmain.idasset) 
LEFT OUTER JOIN assetunload
	ON assetamortization.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN assetunloadkind
	ON assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
LEFT OUTER JOIN assetload
	ON assetamortization.idassetload = assetload.idassetload
LEFT OUTER JOIN assetloadkind
	ON assetloadkind.idassetloadkind = assetload.idassetloadkind

LEFT OUTER JOIN assetlocation
	ON assetlocation.idasset = asset.idasset
	AND assetlocation.start IS NULL
LEFT OUTER JOIN location
	ON location.idlocation = assetlocation.idlocation
LEFT OUTER JOIN assetmanager
	ON assetmanager.idasset = asset.idasset
	AND assetmanager.start IS NULL
LEFT OUTER JOIN manager
	ON manager.idman = assetmanager.idman
LEFT OUTER JOIN location CL ON CL.idlocation= 
	(SELECT TOP 1 idlocation 
	FROM assetlocation 
	WHERE assetlocation.idasset = assetmain.idasset 
	ORDER BY start desc)
LEFT OUTER JOIN manager CM ON CM.idman= 
	(SELECT TOP 1 idman 
	FROM assetmanager 
	WHERE assetmanager.idasset = assetmain.idasset 
	ORDER BY start desc)
WHERE (assetmain.idpiece = 1)
	




GO
