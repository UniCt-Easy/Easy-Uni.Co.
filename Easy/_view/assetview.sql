
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


-- CREAZIONE VISTA assetview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetview]
GO
 
-- E vanno RIMOSSI dalla vista i campi relativi al manager/submanager/ubicaz. INIZIALE ossia quelli con la join alle righe con start null
--vanno invece lasciati i campi sui dati "correnti", usando i nuovi campi di ASSET  e non più le subquery
--vanno aggiunti poi degli indici sui 3 nuovi campi di asset

--setuser 'amm'
--select * from assetview
--clear_table_info 'assetview'
CREATE     VIEW [assetview]
(
	idasset,
	idpiece,
	idasset_prev,
	idpiece_prev,
	idinventory_prev,
	codeinventory_prev,
	inventory_prev,
	ninventory_prev,
	idasset_next,
	idpiece_next,
	idinventory_next,
	codeinventory_next,
	inventory_next,
	ninventory_next,
	lifestart,
	yearstart,
	nassetacquire,
	ninventory,
	idcurrlocation,
	currlocationcode,
	currlocation,
	idcurrman,
	currmanager,
	idcurrsubman,
	currsubmanager,
	idinv,
	codeinv,
	idinv_lev1,
	codeinv_lev1,	
	inventorytree,
	inventorytree_lev1,
	idinventory,
	codeinventory,
	inventory,
	description,
	idassetload,
	idassetloadkind,
	yassetload,
	nassetload,
	idloadmot,
	loadmotive,
	loaddescription,
	ratificationdate, 
	loaddate,
	loaddoc,
	loaddocdate,
	loadenactment,
	loadenactmentdate,
	loadprintdate,
	taxable,
	taxrate,
	tax,
	abatable,
	unabatable,
	number,
	discount,
	cost,
	revals,
	revals_pending,
	subtractions,
	currentvalue,
	total,
	idassetunload,
	idassetunloadkind,
	yassetunload,
	nassetunload,
	unloaddate,
	idunloadmot,
	unloadmotive,
	unloaddescription,
	unloaddoc,
	unloaddocdate,
	unloadenactment,
	unloadenactmentdate,
	unloadratificationdate,
	unloadregistry,
	flag,
	flagunload,
	flagtransf,
	transmitted,
	flagload,
	loadkind,
	multifield,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	is_unloaded,
	is_loaded,
	idupb,	codeupb,	upb,
	cu,
	ct,
	lu,
	lt,
	rtf,
	txt,
	idinventoryagency,
	inventoryagency,
	idlist,
	intcode,
	list,
	idinventoryamortization,
	amortizationquota,
	historical,
	ispiece,
	inventorykindvisible,
	rfid,
	idinvkind,
    yinv,
    ninv,
    invrownum
)
AS SELECT
	asset.idasset,
	asset.idpiece,
	asset.idasset_prev,
	asset.idpiece_prev,
	asset_prev.idinventory,
	inventory_prev.codeinventory,
	inventory_prev.description,
	asset_prev.ninventory,
	asset_next.idasset,
	asset_next.idpiece,
	asset_next.idinventory,
	inventory_next.codeinventory,
	inventory_next.description,
	asset_next.ninventory,
	asset.lifestart,
	year(asset.lifestart),
	asset.nassetacquire,
	assetmain.ninventory,
	CL.idlocation,
	CL.locationcode,
	CL.description,
	CM.idman,
	CM.title,
	-- Consegnatario del cespite
	CMsub.idman,
	CMsub.title,
	assetacquire.idinv,
	inventorytree.codeinv,
	inventorytree1.idinv,
	inventorytree1.codeinv,
	inventorytree.description,
	inventorytree1.description,
	asset.idinventory,
	inventory.codeinventory,
	inventory.description,
	assetacquire.description,
	assetacquire.idassetload,
	assetload.idassetloadkind,
	assetload.yassetload,
	assetload.nassetload,
	assetacquire.idmot,
	assetloadmotive.description,
	assetload.description,
	assetload.ratificationdate,
	assetload.adate,
	assetload.doc,
	assetload.docdate,
	assetload.enactment,
	assetload.enactmentdate,
	assetload.printdate,
	assetacquire.taxable,
	assetacquire.taxrate,
	ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2),
	ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) ,
	ROUND((ISNULL(assetacquire.tax,0)-ISNULL(assetacquire.abatable,0)) / assetacquire.number,2),
	assetacquire.number,
	assetacquire.discount,
-- Costo
	CASE	
			----------------------------------------------------------------------------------
			----------------- Considera i buoni di carico cespiti precedenti al 2005   -------
			----------------------------------------------------------------------------------
			WHEN (inventorykind.flag & 1 <> 0) 
			THEN
			CONVERT(decimal(19,2),ROUND(
				ROUND(ISNULL(assetacquire.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
				+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
				- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))
			ELSE
			CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))		 		
	END,
	--revals applied
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization   (NOLOCK) 
				/*JOIN  inventoryamortization
				 ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload AA (NOLOCK) 	ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL  (NOLOCK) 		ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is not null)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is not null)
					)
			 	)
				)
				--AND   (inventoryamortization.flag & 2 <> 0)
		),0),	
		--revals pending
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization (NOLOCK) 
				/*JOIN  inventoryamortization
				ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload AA  (NOLOCK) 	ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL  (NOLOCK) 		ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is  null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is  null)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is  null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is  null)
					)
			 	)
				)				
				--AND   (inventoryamortization.flag & 2 <> 0)
				)
			,0),
	--subtractions
			CASE	WHEN asset.idpiece=1 THEN
	ISNULL(
			(SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(B.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
			+ ROUND(ISNULL(B.tax,0) / B.number,2)
			- ROUND(ISNULL(B.abatable,0) / B.number,2)))
			 from assetacquire B
				join asset A
				on B.nassetacquire = A.nassetacquire
				where A.idasset = asset.idasset
				and   A.idpiece >1
				and   A.idassetunload IS NOT NULL
				and  ((B.flag & 1 <> 1) AND (B.flag & 2 <> 0)))
			,0)
	ELSE 0
	END,
	
	--valore iniziale cespiti
   CASE				
			WHEN (inventorykind.flag & 1 <> 0) 
			THEN
			CONVERT(decimal(19,2),ROUND(
				ROUND(ISNULL(assetacquire.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
				+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
				- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))
			ELSE
			CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))		 
		
	END
	--ammortamenti e rivalutazioni ufficiali	
	+
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization  (NOLOCK) 
				/*JOIN  inventoryamortization
				ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload  (NOLOCK)  AA	ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload  (NOLOCK) AL		ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
					( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is not null)
					))
					OR 
			            
					( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is not null)
					))

					)
				--AND   (inventoryamortization.flag & 2 <> 0)
				)
		,0)
	------------------------------------------------------------------------------------------
	-- Sottrae gli accessori scaricati caricati come posseduti e già inclusi nel cespite -----
	------------------------------------------------------------------------------------------	
	-
	CASE	WHEN asset.idpiece=1 THEN
	ISNULL(
			(SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(B.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
			+ ROUND(ISNULL(B.tax,0) / B.number,2)
			- ROUND(ISNULL(B.abatable,0) / B.number,2)))
			 from assetacquire B  (NOLOCK) 
				join asset A (NOLOCK) 	on B.nassetacquire = A.nassetacquire
				where A.idasset = asset.idasset
				and   A.idpiece >1
				and   A.idassetunload IS NOT NULL
				and  ((B.flag & 1 = 0) AND (B.flag & 2 <> 0)))
			,0)
	ELSE 0
	END,
	
	
	CONVERT(decimal(19,2),ROUND(
				ISNULL(assetacquire.taxable,0)
				*(1-ISNULL(assetacquire.discount,0))
				+ round(ISNULL(assetacquire.tax,0),2)/assetacquire.number
				,2)
		),
	asset.idassetunload,
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunload.adate,
	assetunload.idmot,
	assetunloadmotive.description,
	assetunload.description,
	assetunload.doc,
	assetunload.docdate,
	assetunload.enactment,
	assetunload.enactmentdate,
	assetunload.ratificationdate,
	assetunloadreg.title,
	asset.flag,
	CASE
		WHEN asset.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	CASE
		WHEN asset.flag & 4 <> 0 THEN 'S'
		ELSE 'N'
	END,
	asset.transmitted,
	CASE
		WHEN assetacquire.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	CASE
		WHEN assetacquire.flag & 2 <> 0 THEN 'R'
		ELSE 'N'
	END,
	asset.multifield,
	COALESCE(assetloadkind.idsor01, inventory.idsor01, upb.idsor01),
	COALESCE(assetloadkind.idsor02, inventory.idsor02, upb.idsor02),
	COALESCE(assetloadkind.idsor03, inventory.idsor03, upb.idsor03),
	COALESCE(assetloadkind.idsor04, inventory.idsor04, upb.idsor04),
	COALESCE(assetloadkind.idsor05, inventory.idsor05, upb.idsor05),
	CASE 
		when assetunload.adate IS NOT NULL or (asset.flag & 1 = 0)
			THEN 'S'
		ELSE
			'N'
	END,
	CASE 
		when assetload.ratificationdate IS NOT NULL or ((assetacquire.flag & 1 = 0) AND (assetacquire.flag & 2 <> 0))
			THEN 'S'
		ELSE
			'N'
	END,
	assetacquire.idupb,	upb.codeupb,	upb.title,
	asset.cu,
	asset.ct,
	asset.lu,
	asset.lt,
	asset.rtf,
	asset.txt,
	inventory.idinventoryagency,
	inventoryagency.description,
	list.idlist,
	list.intcode,
	list.description,
	asset.idinventoryamortization,
	asset.amortizationquota,
	assetacquire.historicalvalue,
	CASE	WHEN asset.idpiece>1 THEN 'S' else 'N' end,
	CASE	WHEN ((inventorykind.flag&2)=0)  THEN 'S' else 'N' end,
	assetmain.rfid,
	assetacquire.idinvkind,
    assetacquire.yinv,
    assetacquire.ninv,
    assetacquire.invrownum
FROM asset (NOLOCK) 
JOIN asset (NOLOCK) AS assetmain					ON (asset.idasset=assetmain.idasset) --
JOIN assetacquire		(NOLOCK) 				ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventorytree		(NOLOCK) 				ON inventorytree.idinv = assetacquire.idinv
JOIN inventory			(NOLOCK) 				ON inventory.idinventory = asset.idinventory
JOIN inventoryagency	(NOLOCK) 				ON inventoryagency.idinventoryagency = inventory.idinventoryagency
JOIN inventorykind		(NOLOCK) 				ON inventory.idinventorykind= inventorykind.idinventorykind  
JOIN inventorytreelink	(NOLOCK) 				ON inventorytreelink.idchild = assetacquire.idinv
											AND inventorytreelink.nlevel=1		
JOIN inventorytree inventorytree1	(NOLOCK) 	ON inventorytree1.idinv = inventorytreelink.idparent
LEFT OUTER JOIN assetload			(NOLOCK) 	ON assetacquire.idassetload = assetload.idassetload
LEFT OUTER JOIN assetloadkind		(NOLOCK) 	ON assetloadkind.idassetloadkind = assetload.idassetloadkind
LEFT OUTER JOIN upb					(NOLOCK) 	ON upb.idupb = assetacquire.idupb
LEFT OUTER JOIN assetunload			(NOLOCK) 	ON asset.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN asset asset_prev	(NOLOCK) 	ON asset.idasset_prev = asset_prev.idasset
											AND asset.idpiece_prev = asset_prev.idpiece
LEFT OUTER JOIN inventory inventory_prev		(NOLOCK) 	ON inventory_prev.idinventory = asset_prev.idinventory
LEFT OUTER JOIN asset asset_next				(NOLOCK) 	ON asset.idasset = asset_next.idasset_prev
															AND asset.idpiece = asset_next.idpiece_prev
LEFT OUTER JOIN inventory inventory_next		(NOLOCK) 	ON inventory_next.idinventory = asset_next.idinventory
LEFT OUTER JOIN location		CL		(NOLOCK)  on CL.idlocation = assetmain.idcurrlocation
LEFT OUTER JOIN manager CM				(NOLOCK)  ON CM.idman = assetmain.idcurrman
LEFT OUTER JOIN manager CMsub (NOLOCK)  ON CMsub.idman = assetmain.idcurrsubman
LEFT OUTER JOIN assetloadmotive			(NOLOCK) ON assetacquire.idmot = assetloadmotive.idmot
LEFT OUTER JOIN assetunloadmotive		(NOLOCK) ON assetunload.idmot = assetunloadmotive.idmot
LEFT OUTER JOIN registry assetunloadreg (NOLOCK) ON assetunload.idreg = assetunloadreg.idreg
LEFT OUTER JOIN list					(NOLOCK) ON assetacquire.idlist = list.idlist
WHERE (assetmain.idpiece = 1)




GO


 
