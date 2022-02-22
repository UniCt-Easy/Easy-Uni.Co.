
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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



-- CREAZIONE VISTA assetpieceview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetpieceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetpieceview]
GO

--setuser 'amministrazione'
--setuser 'amm'
--select * from assetpieceview


CREATE    VIEW [assetpieceview]
(
	idasset,
	idpiece,
	lifestart,
	yearstart,
	nassetacquire,
	idupb,
	ninventory,
	idlocation,
	locationcode,
	location,
	idcurrlocation,
	currlocationcode,
	currlocation,
	idman,
	manager,
	idcurrman,
	currmanager,
	--consegnatario del cespite
	idsubman,
	submanager,
	idcurrsubman,
	currsubmanager,
	idinv,
	codeinv,
	idinv_lev1,
	codeinv_lev1,	
	inventorytree,
	inventorytree_lev1,
	idinventory,
	inventory,
	description,
	descriptionmain,
	idassetload,
	idassetloadkind,
	yassetload,
	nassetload,
	taxable,
	tax,
	taxrate,
	discount,
	historicalvalue,
	cost,
	revals,
	revals_pending,
	subtractions,
	currentvalue,
	total,
	abatable,
	unabatable,
	idassetunload,
	idassetunloadkind,
	yassetunload,
	nassetunload,
	transmitted,
	flag,
	idsor1,
	idsor2,
	idsor3,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	is_unloaded,
	is_loaded,	
	cu,
	ct,
	lu,
	lt,
	idlist,
	intcode,
	list,
	inventorykind
)
AS SELECT
	asset.idasset,
	asset.idpiece,
	asset.lifestart,
	year(asset.lifestart),
	asset.nassetacquire,
	assetacquire.idupb,
	assetmain.ninventory,
	location.idlocation,
	location.locationcode,
	location.description,
	CL.idlocation,
	CL.locationcode,
	CL.description,
	manager.idman,
	manager.title,
	CM.idman,
	CM.title,
	-- Consegnatario del cespite
	submanager.idman,
	submanager.title,
	CMsub.idman,
	CMsub.title,
	assetacquire.idinv,
	inventorytree.codeinv,
	inventorytree1.idinv,
	inventorytree1.codeinv,
	inventorytree.description,
	inventorytree1.description,
	asset.idinventory,
	inventory.description,
	assetacquire.description,
	CASE 
	 	WHEN (asset.idpiece = 1) THEN NULL 
		ELSE assetacquiremain.description
	END,
	assetacquire.idassetload, 
	assetload.idassetloadkind,
	assetload.yassetload,
	assetload.nassetload,
	assetacquire.taxable,
	ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2),  --non era diviso prima
	assetacquire.taxrate,
	assetacquire.discount,
	isnull(assetacquire.historicalvalue,AC.start),
	AC.start,
	AC.revals,
	AC.revals_pending,
	AC.subtractions,
	AC.currentvalue,
	CONVERT(decimal(19,2),ROUND(
				ISNULL(assetacquire.taxable,0)
				*(1-ISNULL(assetacquire.discount,0))
				+ round(ISNULL(assetacquire.tax,0),2)/assetacquire.number
				,2)
		),
	ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) ,  --prima non era diviso
	ROUND((ISNULL(assetacquire.tax,0)-ISNULL(assetacquire.abatable,0)) / assetacquire.number,2),  --nuova colonna
	asset.idassetunload,
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	asset.transmitted,
	asset.flag,
	assetacquire.idsor1,assetacquire.idsor2,assetacquire.idsor3,
	COALESCE(assetloadkind.idsor01, inventory.idsor01, upb.idsor01),
	COALESCE(assetloadkind.idsor02, inventory.idsor02, upb.idsor02),
	COALESCE(assetloadkind.idsor03, inventory.idsor03, upb.idsor03),
	COALESCE(assetloadkind.idsor04, inventory.idsor04, upb.idsor04),
	COALESCE(assetloadkind.idsor05, inventory.idsor05, upb.idsor05),	
	AC.is_unloaded,
	AC.is_loaded,	
	asset.cu,
	asset.ct,
	asset.lu,
	asset.lt,
	assetacquire.idlist,
	list.intcode,
	list.description,
	inventorykind.description
FROM asset
JOIN assetacquire					ON assetacquire.nassetacquire = asset.nassetacquire
LEFT OUTER JOIN upb					ON upb.idupb = assetacquire.idupb	
JOIN inventorytree					ON inventorytree.idinv = assetacquire.idinv
JOIN inventory						ON inventory.idinventory = asset.idinventory
JOIN inventorytreelink				ON inventorytreelink.idchild = assetacquire.idinv
										AND inventorytreelink.nlevel=1
JOIN inventorytree inventorytree1	ON inventorytree1.idinv = inventorytreelink.idparent
JOIN asset AS assetmain				ON (asset.idasset=assetmain.idasset) 
JOIN assetacquire AS assetacquiremain		ON (assetacquiremain.nassetacquire = assetmain.nassetacquire)
JOIN assetview_current AC					ON AC.idasset= asset.idasset and AC.idpiece = asset.idpiece
LEFT OUTER JOIN assetload					ON assetload.idassetload = assetacquiremain.idassetload
LEFT OUTER JOIN assetloadkind			ON assetloadkind.idassetloadkind = assetload.idassetloadkind	
LEFT OUTER JOIN assetunload				ON assetunload.idassetunload = asset.idassetunload
LEFT OUTER JOIN assetlocation			ON assetlocation.idasset = asset.idasset
											AND assetlocation.start IS NULL	
LEFT OUTER JOIN location				ON location.idlocation = assetlocation.idlocation
LEFT OUTER JOIN assetmanager			ON assetmanager.idasset = asset.idasset
											AND assetmanager.start IS NULL
LEFT OUTER JOIN manager					ON manager.idman = assetmanager.idman
LEFT OUTER JOIN list					ON list.idlist = assetacquire.idlist
LEFT OUTER JOIN assetsubmanager			ON assetsubmanager.idasset = asset.idasset
											AND assetsubmanager.start IS NULL
LEFT OUTER JOIN manager as submanager	ON submanager.idman = assetsubmanager.idmanager
LEFT OUTER JOIN location CL ON CL.idlocation= 
											(SELECT TOP 1 idlocation 
											FROM assetlocation 
											WHERE assetlocation.idasset = assetmain.idasset 
											ORDER BY start desc)
LEFT OUTER JOIN manager CM			ON CM.idman= 
												(SELECT TOP 1 idman 
												FROM assetmanager 
												WHERE assetmanager.idasset = assetmain.idasset 
												ORDER BY start desc)
LEFT OUTER JOIN manager CMsub		ON CMsub.idman = 
										(SELECT TOP 1 idmanager
										FROM assetsubmanager
										WHERE assetsubmanager.idasset = assetmain.idasset
										ORDER BY start desc)
left outer JOIN inventorykind	(nolock)	 		    ON inventory.idinventorykind= inventorykind.idinventorykind  
WHERE (assetmain.idpiece = 1)





GO
