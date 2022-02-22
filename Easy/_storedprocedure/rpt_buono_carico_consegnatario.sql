
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_carico_consegnatario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_carico_consegnatario]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE [rpt_buono_carico_consegnatario]
(
	@ayear int,
	@printkind char(1),
	@idassetloadkind int,
	@startnassetload int,
	@stopnassetload int,
	@printdate smalldatetime,
	@official char(1)
)
AS BEGIN
-- exec rpt_buono_carico_consegnatario 2014, 'I', 4, 1, 1, {d '2014-01-31'},'N' 
CREATE TABLE #printing (
	num int  
)
IF @printkind = 'A' 
	INSERT INTO #printing (num) 
		SELECT nassetload from  assetload  where (yassetload=@ayear) and (printdate IS NULL)
IF @printkind <> 'A'
	INSERT INTO #printing (num) 
		SELECT nassetload from  assetload where (yassetload=@ayear) and (nassetload BETWEEN @startnassetload AND @stopnassetload)
	
CREATE TABLE #assetload
(
	idassetloadkind	int,
	assetloadkind varchar(50),
	yassetload smallint,
	nassetload int,
	idmot int,
	idinventoryagency int,
	inventoryagency	varchar(150),
	idinventorykind int,
	inventorykind varchar(55),
	idreg int,
	doc varchar(35),
	docdate date,
	description varchar(150),
	enactment varchar(150),
	enactmentdate date,
	adate date,
	startconsignee date,
	printdate date,
	operationorder int,
	kind varchar(50),
	idinventory int,
	startnumber int,
	idinv int,
	idinv1 int,
	idinv2 int,
	idinv3 int,
	idinv4 int,
	aliquota float,
	assetdescription varchar(210),
	unitaryvalue decimal(23,5),
	prezzocopertina decimal(19,2),
	idlocation int,
	idman int,
	annotation text,
	libri char(1),
	rfid varchar(30),
	idsubmanager int
)
	
INSERT INTO #assetload
(
	aliquota,
	idassetloadkind,
	assetloadkind,
	yassetload,
	nassetload,
	idmot,
	idinventoryagency,
	inventoryagency,
	idinventorykind,
	inventorykind,
	idreg,
	doc,
	docdate,
	description,
	annotation,
	enactment,
	enactmentdate,
	adate,
	printdate,
	operationorder,
	kind,
	idinventory,
	startnumber,
	idinv,
	idinv1,
	idinv2,
	idinv3,
	idinv4,
	assetdescription,
	unitaryvalue,
	idlocation,
	idman,
	prezzocopertina,
	libri,
	rfid ,
	idsubmanager
	)
	
SELECT
	assetacquire.taxrate,
	assetload.idassetloadkind,
	assetloadkind.description,
	assetload.yassetload,
	assetload.nassetload,
	assetload.idmot,
	inventory.idinventoryagency,
	inventoryagency.description,
	inventory.idinventorykind,
	inventorykind.description,
	assetload.idreg,
	assetload.doc,
	assetload.docdate,
	assetload.description,
	assetload.txt,
	assetload.enactment,
	assetload.enactmentdate,
	assetload.adate,
	assetload.printdate,
	1,
	'Carico bene',
	assetacquire.idinventory,
	asset.ninventory,
	assetacquire.idinv,
	IL1.idparent,
	IL2.idparent,
	IL3.idparent,
	IL4.idparent,
	assetacquire.description,
	--	Calcolo del valore unitario aggiornato con la gestione dello sconto :
	assetview_current.start,
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL),
	CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.taxable,0) * isnull(assetacquire.taxrate,0),2)-- IVA calcolata PRIMA dello sconto
			,2)),
	case	when  inventorykind.flag & 4 <>0 then 'S'
			else 'N'
	end ,-- 'libri'
	asset.rfid,
	(SELECT TOP 1 idmanager
				FROM assetsubmanager
				WHERE assetsubmanager.idasset = asset.idasset
				ORDER BY start desc) 
FROM assetacquire
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN assetloadkind
	ON assetload.idassetloadkind = assetloadkind.idassetloadkind
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
join  assetview_current  
	ON assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryagency
	ON inventoryagency.idinventoryagency = inventory.idinventoryagency
JOIN inventorykind
	ON inventorykind.idinventorykind = inventory.idinventorykind
LEFT OUTER JOIN inventorytreelink IL1  
    	ON IL1.idchild = assetacquire.idinv AND IL1.nlevel  = 1 
LEFT OUTER JOIN inventorytreelink IL2  
    	ON IL2.idchild = assetacquire.idinv  AND IL2.nlevel = 2
LEFT OUTER JOIN inventorytreelink IL3 
    	ON IL3.idchild = assetacquire.idinv  AND IL3.nlevel = 3 
LEFT OUTER JOIN inventorytreelink IL4  
    	ON IL4.idchild = assetacquire.idinv  AND IL4.nlevel = 4 
WHERE  asset.idpiece=1		
	and assetload.idassetloadkind = @idassetloadkind
	AND assetload.yassetload = @ayear
	AND assetload.nassetload IN (SELECT num from #printing)
 
			
INSERT INTO #assetload
(
	aliquota,
	idassetloadkind,
	assetloadkind,
	yassetload,
	nassetload,
	idmot,
	idinventoryagency,
	inventoryagency,
	idinventorykind,
	inventorykind,
	idreg,
	doc,
	docdate,
	description,
	annotation,
	enactment,
	enactmentdate,
	adate,
	printdate,
	operationorder,
	kind,
	idinventory,
	startnumber,
	idinv,
	idinv1,
	idinv2,
	idinv3,
	idinv4,
	assetdescription,
	unitaryvalue,
	idlocation,
	idman,
	prezzocopertina,
	libri,
	rfid ,
	idsubmanager
)
SELECT
	assetacquire.taxrate,	
	assetload.idassetloadkind,
	assetloadkind.description,
	assetload.yassetload,
	assetload.nassetload,
	assetload.idmot,
	inventory.idinventoryagency,
	inventoryagency.description,
	inventory.idinventorykind,
	inventorykind.description,
	assetload.idreg,
	assetload.doc,
	assetload.docdate,
	assetload.description,
	assetload.txt,
	assetload.enactment,
	assetload.enactmentdate,
	assetload.adate,
	assetload.printdate,
	2,
	'Carico accessorio',
	assetacquire.idinventory,
	assetmain.ninventory,
	assetacquire.idinv, 
	IL1.idparent,
	IL2.idparent,
	IL3.idparent,
	IL4.idparent,
	assetacquire.description,
	--Calcolo del valore unitario 
	assetview_current.start,
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL),
	CONVERT(decimal(19,2),ROUND(
		ROUND(ISNULL(assetacquire.taxable, 0),2)
		+ ROUND(ISNULL(assetacquire.taxable,0) * isnull(assetacquire.taxrate,1),2)-- IVA calcolata PRIMA dello sconto
		,2)),
	case	when  inventorykind.flag & 4 <>0 then 'S'
		else 'N'
	end ,-- 'libri'
	asset.rfid ,
	(SELECT TOP 1 idmanager
				FROM assetsubmanager
				WHERE assetsubmanager.idasset = asset.idasset
				ORDER BY start desc)
FROM assetacquire
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN assetloadkind
	ON assetload.idassetloadkind = assetloadkind.idassetloadkind
JOIN asset
	ON asset.nassetacquire = assetacquire.nassetacquire
JOIN  assetview_current  
	ON assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
JOIN asset as assetmain
	ON asset.idasset=assetmain.idasset
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryagency
	ON inventoryagency.idinventoryagency = inventory.idinventoryagency
JOIN inventorykind
	ON inventorykind.idinventorykind = inventory.idinventorykind
LEFT OUTER JOIN inventorytreelink IL1  
    	ON IL1.idchild = assetacquire.idinv AND IL1.nlevel  = 1 
LEFT OUTER JOIN inventorytreelink IL2  
    	ON IL2.idchild = assetacquire.idinv  AND IL2.nlevel = 2
LEFT OUTER JOIN inventorytreelink IL3 
    	ON IL3.idchild = assetacquire.idinv  AND IL3.nlevel = 3 
LEFT OUTER JOIN inventorytreelink IL4  
    	ON IL4.idchild = assetacquire.idinv  AND IL4.nlevel = 4 

WHERE asset.idpiece>1		
	and assetload.idassetloadkind = @idassetloadkind
	AND assetload.yassetload = @ayear
	AND assetload.nassetload IN (SELECT num from #printing)
	AND assetmain.idpiece=1



--------------------------------------------------------------------------------------
--------------------------------Carico Rivalutazioni ---------------------------------
--------------------------------------------------------------------------------------
	
INSERT INTO #assetload
(
	aliquota,
	idassetloadkind,
	assetloadkind,
	yassetload,
	nassetload,
	idmot,
	idinventoryagency,
	inventoryagency,
	idinventorykind,
	inventorykind,
	idreg,
	doc,
	docdate,
	description,
	annotation,
	enactment,
	enactmentdate,
	adate,
	printdate,
	operationorder,
	kind,
	idinventory,
	startnumber,
	idinv,
	idinv1,
	idinv2,
	idinv3,
	idinv4,
	assetdescription,
	unitaryvalue,
	idlocation,
	idman,
	rfid ,
	idsubmanager
)
SELECT 
	null,	
	assetload.idassetloadkind,
	assetloadkind.description,
	assetload.yassetload,
	assetload.nassetload,
	assetload.idmot,
	inventory.idinventoryagency,
	inventoryagency.description,
	inventory.idinventorykind,
	inventorykind.description,
	assetload.idreg,
	assetload.doc,
	assetload.docdate,
	assetload.description,
	assetload.txt,
	assetload.enactment,
	assetload.enactmentdate,
	assetload.adate,
	assetload.printdate,
	3,
	'Rivalutazione cespite',
	assetacquire.idinventory, 
	asset.ninventory,
	assetacquire.idinv,
	IL1.idparent,
	IL2.idparent,
	IL3.idparent,
	IL4.idparent,
	inventoryamortization.description + ' n. '+ convert(varchar(4),namortization) + char(13) + assetamortization.description,
	ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2),
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL),
	asset.rfid,
	(SELECT TOP 1 idmanager
				FROM assetsubmanager
				WHERE assetsubmanager.idasset = asset.idasset
				ORDER BY start desc)
FROM assetload
JOIN assetloadkind
	ON assetload.idassetloadkind = assetloadkind.idassetloadkind
JOIN assetamortization
	ON assetload.idassetload = assetamortization.idassetload
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset 
	ON asset.idasset = assetamortization.idasset
	AND asset.idpiece = assetamortization.idpiece
JOIN assetacquire
	ON asset.nassetacquire = assetacquire.nassetacquire
JOIN inventory
	ON assetacquire.idinventory = inventory.idinventory	
JOIN inventoryagency
	ON inventoryagency.idinventoryagency = inventory.idinventoryagency
JOIN inventorykind
	ON inventorykind.idinventorykind = inventory.idinventorykind
LEFT OUTER JOIN inventorytreelink IL1  
    	ON IL1.idchild = assetacquire.idinv AND IL1.nlevel  = 1 
LEFT OUTER JOIN inventorytreelink IL2  
    	ON IL2.idchild = assetacquire.idinv  AND IL2.nlevel = 2
LEFT OUTER JOIN inventorytreelink IL3 
    	ON IL3.idchild = assetacquire.idinv  AND IL3.nlevel = 3 
LEFT OUTER JOIN inventorytreelink IL4  
    	ON IL4.idchild = assetacquire.idinv  AND IL4.nlevel = 4 


WHERE 	asset.idpiece = 1 
	AND assetload.idassetloadkind = @idassetloadkind
	AND assetload.yassetload = @ayear
	AND assetload.nassetload IN (SELECT num from #printing)

INSERT INTO #assetload
(
	aliquota,
	idassetloadkind,
	assetloadkind,
	yassetload,
	nassetload,
	idmot,
	idinventoryagency,
	inventoryagency,
	idinventorykind,
	inventorykind,
	idreg,
	doc,
	docdate,
	description,
	annotation,
	enactment,
	enactmentdate,
	adate,
	printdate,
	operationorder,
	kind,
	idinventory,
	startnumber,
	idinv,
	idinv1,
	idinv2,
	idinv3,
	idinv4,
	assetdescription,
	unitaryvalue,
	idlocation,
	idman,
	rfid ,
	idsubmanager
)
SELECT 
	null,	
	assetload.idassetloadkind,
	assetloadkind.description,
	assetload.yassetload,
	assetload.nassetload,
	assetload.idmot,
	inventory.idinventoryagency,
	inventoryagency.description,
	inventory.idinventorykind,
	inventorykind.description,
	assetload.idreg,
	assetload.doc,
	assetload.docdate,
	assetload.description,
	assetload.txt,
	assetload.enactment,
	assetload.enactmentdate,
	assetload.adate,
	assetload.printdate,
	4,
	'Rivalutazione accessorio',
	assetacquire.idinventory, 
	assetcespite.ninventory,
	assetacquire.idinv,
	IL1.idparent,
	IL2.idparent,
	IL3.idparent,
	IL4.idparent,
	inventoryamortization.description + ' n. '+ convert(varchar(4),namortization) + char(13) + assetamortization.description,
	ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2),
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL),
	asset.rfid,
	(SELECT TOP 1 idmanager
				FROM assetsubmanager
				WHERE assetsubmanager.idasset = asset.idasset
				ORDER BY start desc) 
FROM assetload
JOIN assetloadkind
	ON assetload.idassetloadkind = assetloadkind.idassetloadkind
JOIN assetamortization
	ON assetload.idassetload = assetamortization.idassetload
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset 
	ON asset.idasset = assetamortization.idasset
	AND asset.idpiece = assetamortization.idpiece
JOIN asset AS assetcespite 
	ON asset.idasset = assetcespite.idasset
JOIN assetacquire
	ON asset.nassetacquire = assetacquire.nassetacquire
JOIN inventory
	ON assetacquire.idinventory = inventory.idinventory	
JOIN inventoryagency
	ON inventoryagency.idinventoryagency = inventory.idinventoryagency
JOIN inventorykind
	ON inventorykind.idinventorykind = inventory.idinventorykind
LEFT OUTER JOIN inventorytreelink IL1  
    	ON IL1.idchild = assetacquire.idinv AND IL1.nlevel  = 1 
LEFT OUTER JOIN inventorytreelink IL2  
    	ON IL2.idchild = assetacquire.idinv  AND IL2.nlevel = 2
LEFT OUTER JOIN inventorytreelink IL3 
    	ON IL3.idchild = assetacquire.idinv  AND IL3.nlevel = 3 
LEFT OUTER JOIN inventorytreelink IL4  
    	ON IL4.idchild = assetacquire.idinv  AND IL4.nlevel = 4 
WHERE 	asset.idpiece >1 AND assetcespite.idpiece = 1 
	AND assetload.idassetloadkind = @idassetloadkind
	AND assetload.yassetload = @ayear
	AND assetload.nassetload IN (SELECT num from #printing)


UPDATE #assetload
	SET startconsignee = (SELECT MAX(start) 
				FROM assetconsignee 
				WHERE idinventoryagency = #assetload.idinventoryagency
					AND start <= #assetload.adate)
	
IF @official = 'S'
BEGIN
	UPDATE #assetload
		SET printdate = @printdate
		WHERE yassetload = @ayear 
		AND nassetload IN (SELECT num from #printing)
		AND printdate is null
END
			
SELECT 
	#assetload.idassetloadkind	,
	#assetload.assetloadkind	,
	yassetload,
	nassetload,
	#assetload.idmot,
	assetloadmotive.description as assetloadmotive,
	#assetload.idinventoryagency,
	inventoryagency,
	#assetload.idinventorykind,
	inventorykind ,
	CONSEGNATARIO.qualification as qualificationconsignee ,
	CONSEGNATARIO.title as assetconsignee,
	#assetload.idreg,
	registry.title,
	doc,
	CONVERT(datetime, docdate) as docdate,
	#assetload.description,
	#assetload.annotation,
	enactment,
	CONVERT(datetime, enactmentdate) as enactmentdate,
	CONVERT(datetime, adate) as adate,
	CONVERT(datetime, startconsignee) as startconsignee ,
	CONVERT(datetime, printdate) as printdate,
	operationorder,
	kind,
	#assetload.idinventory,
	#assetload.startnumber,
	#assetload.idinv,
	inventory.codeinventory,
	inventorytree.description as descrizioneclassif,
	inventorytree.codeinv,
	INVTREE1.codeinv as codeinv1,
	INVTREE1.description as descrizioneclassif1,
	LV1.description as level1,
	INVTREE2.codeinv as codeinv2,
	INVTREE2.description as descrizioneclassif2,
	LV2.description as level2,
	INVTREE3.codeinv as codeinv3,
	INVTREE3.description as descrizioneclassif3,
	LV3.description as level3,
	INVTREE4.codeinv as codeinv4,
	INVTREE4.description as descrizioneclassif4,
	LV4.description as level4,
	aliquota,
	assetdescription,
	unitaryvalue ,
	#assetload.idlocation,
	location.locationcode + '-' +location.description as location,
	#assetload.idman,
	manager.title as manager,
	inventoryagency.title_l,   -- sezione firme
	inventoryagency.name_l,
	inventoryagency.title_c,
	inventoryagency.name_c,
	inventoryagency.title_r,
	inventoryagency.name_r,
	isnull(#assetload.prezzocopertina,0)  as prezzocopertina,
	isnull(libri,'N') as libri,
	#assetload.rfid,
	Submanager.title as submanager
FROM #assetload
join inventoryagency
	on inventoryagency.idinventoryagency = #assetload.idinventoryagency
JOIN inventory
	on #assetload.idinventory = inventory.idinventory
LEFT OUTER JOIN assetloadmotive
	ON #assetload.idmot = assetloadmotive.idmot
LEFT OUTER JOIN registry
	ON #assetload.idreg = registry.idreg
LEFT OUTER JOIN inventorytree
	ON inventorytree.idinv = #assetload.idinv
LEFT OUTER JOIN inventorytree INVTREE1
	ON INVTREE1.idinv = #assetload.idinv1
LEFT OUTER JOIN inventorytree INVTREE2
	ON INVTREE2.idinv = #assetload.idinv2
LEFT OUTER JOIN inventorytree INVTREE3
	ON INVTREE3.idinv = #assetload.idinv3
LEFT OUTER JOIN inventorytree INVTREE4
	ON INVTREE4.idinv = #assetload.idinv4
LEFT OUTER JOIN inventorysortinglevel LV1
	ON LV1.nlevel = INVTREE1.nlevel
LEFT OUTER JOIN inventorysortinglevel LV2
	ON LV2.nlevel = INVTREE2.nlevel
LEFT OUTER JOIN inventorysortinglevel LV3
	ON LV3.nlevel = INVTREE3.nlevel
LEFT OUTER JOIN inventorysortinglevel LV4
	ON LV4.nlevel = INVTREE4.nlevel
LEFT OUTER JOIN location
	ON location.idlocation = #assetload.idlocation
LEFT OUTER JOIN manager
	ON manager.idman = #assetload.idman
LEFT OUTER JOIN  manager as Submanager
	ON Submanager.idman = #assetload.idsubmanager
LEFT OUTER JOIN assetconsignee CONSEGNATARIO
	ON CONSEGNATARIO.idinventoryagency = #assetload.idinventoryagency
	AND CONSEGNATARIO.start = #assetload.startconsignee
ORDER BY nassetload, #assetload.startnumber, operationorder
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- Attenzione questa SP funziona solo se viene creata la tabella assetconsignee
 --exec [rpt_buono_carico_consegnatario] 2014, 'I', 4, 1, 1, {d '2014-05-31'},'N'

 
