if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_carico]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_carico]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec [rpt_buono_carico] 2014, 'I', 4, 1, 1, {d '2014-01-31'},'N' 

CREATE    PROCEDURE [rpt_buono_carico]
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
			
CREATE TABLE #printing
(
	num int 
)
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printing (num) 
	SELECT nassetload from  assetload  where (yassetload=@ayear) and (printdate IS NULL)
END
	
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printing (num) 
	SELECT nassetload from  assetload where (yassetload=@ayear) and (nassetload BETWEEN @startnassetload AND @stopnassetload)
END
CREATE TABLE #assetload
(
	idassetloadkind int, 
	yassetload int ,
	nassetload int ,
	idmot int ,
	idinventoryagency int,
	idinventorykind int,
	idreg int,
	doc varchar(35),
	docdate datetime,
	description varchar(150),		
	enactment varchar(150),
	enactmentdate datetime,
	adate datetime,
	printdate datetime,
	operationorder int,		
	kind varchar(50),
	idinventory int,
	startnumber int,
	idinv int,
	assetdescription varchar(210),
	unitaryvalue decimal(23,2),
	prezzocopertina decimal(19,2),
	discount float,			
	idlocation int,
	idman int,
	annotation text
)
INSERT INTO #assetload
(
	idassetloadkind,
	yassetload,
	nassetload,
	idmot,
	idinventoryagency,
	idinventorykind,
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
	assetdescription,
	unitaryvalue,
	discount,		
	idlocation,
	idman, 
	prezzocopertina -- importo al lordo dello sconto
)
SELECT
	assetload.idassetloadkind,
	assetload.yassetload,
	assetload.nassetload,
	assetload.idmot,
	inventory.idinventoryagency,
	inventory.idinventorykind,
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
	assetacquire.description,
	assetview_current.start,
	assetacquire.discount,
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL),
	CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.taxable,0) * isnull(assetacquire.taxrate,1),2)-- IVA calcolata PRIMA dello sconto
			,2))
FROM assetacquire
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN  assetview_current  
	ON assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN  inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind 
WHERE asset.idpiece = 1		
	AND assetload.idassetloadkind = @idassetloadkind
	AND assetload.yassetload = @ayear
	AND assetload.nassetload IN (SELECT num FROM #printing)
 
INSERT INTO #assetload
(
	idassetloadkind,
	yassetload,
	nassetload,
	idmot,
	idinventoryagency,
	idinventorykind,
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
	assetdescription,
	unitaryvalue,
	idlocation,
	idman, 
	prezzocopertina -- importo al lordo dello sconto
)
SELECT
	assetload.idassetloadkind,
	assetload.yassetload,
	assetload.nassetload,
	assetload.idmot,
	inventory.idinventoryagency,
	inventory.idinventorykind,
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
	assetacquire.description,
	assetview_current.start,
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL),
	CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			,2))
FROM assetacquire
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN  assetview_current  
	ON assetview_current.idasset=asset.idasset and  assetview_current.idpiece=asset.idpiece
JOIN asset as assetmain
	ON asset.idasset=assetmain.idasset
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
WHERE asset.idpiece > 1		
	and assetload.idassetloadkind = @idassetloadkind
	AND assetload.yassetload = @ayear
	AND assetload.nassetload IN (SELECT num FROM #printing)
	AND assetmain.idpiece = 1
	
--------------------------------------------------------------------------------------
--------------------------------Carico Rivalutazioni ---------------------------------
--------------------------------------------------------------------------------------
	
INSERT INTO #assetload
(
	idassetloadkind,
	yassetload,
	nassetload,
	idmot,
	idinventoryagency,
	idinventorykind,
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
	assetdescription,
	unitaryvalue,
	idlocation,
	idman
)
SELECT 
	assetload.idassetloadkind,
	assetload.yassetload,
	assetload.nassetload,
	assetload.idmot,
	inventory.idinventoryagency,
	inventory.idinventorykind,
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
	inventoryamortization.description + ' n. '+ convert(varchar(4),namortization) + char(13) + assetamortization.description,
	ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2),
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL)
FROM assetload
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
	ON inventory.idinventoryagency = inventoryagency.idinventoryagency	
WHERE 	asset.idpiece = 1 
	AND assetload.idassetloadkind = @idassetloadkind
	AND assetload.yassetload = @ayear
	AND assetload.nassetload IN (SELECT num from #printing)


INSERT INTO #assetload
(
	idassetloadkind,
	yassetload,
	nassetload,
	idmot,
	idinventoryagency,
	idinventorykind,
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
	assetdescription,
	unitaryvalue,
	idlocation,
	idman
)
SELECT 
	assetload.idassetloadkind,
	assetload.yassetload,
	assetload.nassetload,
	assetload.idmot,
	inventory.idinventoryagency,
	inventory.idinventorykind,
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
	inventoryamortization.description + ' n. '+ convert(varchar(4),namortization) + char(13) + assetamortization.description,
	ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2),
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL)
FROM assetload
JOIN assetamortization
	ON  assetload.idassetload = assetamortization.idassetload
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
	ON inventory.idinventoryagency = inventoryagency.idinventoryagency	
WHERE 	asset.idpiece >1 AND assetcespite.idpiece = 1 
	AND assetload.idassetloadkind = @idassetloadkind
	AND assetload.yassetload = @ayear
	AND assetload.nassetload IN (SELECT num from #printing)



IF @official = 'S'
BEGIN	
	UPDATE #assetload
	SET printdate = @printdate
	WHERE yassetload = @ayear 
		AND nassetload IN (SELECT num FROM #printing)
		AND printdate IS NULL
END

declare @assetloadkind varchar(50)
select @assetloadkind = description from assetloadkind where idassetloadkind = @idassetloadkind

SELECT 
	@assetloadkind as assetloadkind,
	#assetload.idassetloadkind,
	yassetload ,
	nassetload ,
	#assetload.idmot ,
	assetloadmotive.description as assetloadmotive,
	#assetload.idinventoryagency ,
	AGENCY.description as inventoryagency ,
	#assetload.idinventorykind, 
	INVKIND.description as inventorykind ,
	#assetload.idreg ,
	registry.title,
	doc ,
	docdate,
	#assetload.description ,
	#assetload.annotation,
	enactment ,
	enactmentdate ,
	adate ,
	printdate ,
	operationorder ,	
	kind ,

	#assetload.idinventory,
	inventory.codeinventory,
	#assetload.startnumber ,
	#assetload.idinv ,
	inventorytree.codeinv ,
	assetdescription ,
	unitaryvalue,
	discount 	,
	#assetload.idlocation ,
	location.description as location ,
	#assetload.idman ,
	manager.title as manager,
	AGENCY.title_l,   -- sezione firme
	AGENCY.name_l,
	AGENCY.title_c,
	AGENCY.name_c,
	AGENCY.title_r,
	AGENCY.name_r,
	isnull(#assetload.prezzocopertina,0)  as prezzocopertina,
	case	when  INVKIND.flag & 4 <>0 then 'S'
			else  'N'
	end as 'libri'
	FROM #assetload
JOIN inventory
	on #assetload.idinventory = inventory.idinventory
LEFT OUTER JOIN assetloadmotive
	ON #assetload.idmot = assetloadmotive.idmot
LEFT OUTER JOIN inventoryagency AGENCY
	ON AGENCY.idinventoryagency = #assetload.idinventoryagency
JOIN inventorykind INVKIND
	ON INVKIND.idinventorykind = #assetload.idinventorykind
LEFT OUTER JOIN registry
	ON #assetload.idreg = registry.idreg
LEFT OUTER JOIN inventorytree
	ON inventorytree.idinv = #assetload.idinv
LEFT OUTER JOIN location
	ON location.idlocation = #assetload.idlocation
LEFT OUTER JOIN  manager
	ON manager.idman = #assetload.idman
ORDER BY nassetload,#assetload.startnumber,operationorder
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

