
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_carico_RC]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_carico_RC]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE [rpt_buono_carico_RC]
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
-- Inserimento del campo nassetacquire inquanto bisogna separare nelle stampe il carico bene altrimenti ci possono essere delle aggregazioni errate

-- exec [rpt_buono_carico_rc] 2014, 'I', 4, 1, 1, {d '2014-01-31'},'N' 

CREATE TABLE #printing (num int)
	
IF @printkind = 'A' 
	INSERT INTO #printing (num) 
		SELECT nassetload from  assetload  where (yassetload=@ayear) and (printdate IS NULL)
IF @printkind <> 'A'
	INSERT INTO #printing (num) 
	SELECT nassetload from  assetload where (yassetload=@ayear) and (nassetload BETWEEN @startnassetload AND @stopnassetload)

CREATE TABLE #assetload
(
	idassetloadkind int,
	yassetload int,
	nassetload int,
	idmot int,
	idinventoryagency int,
	idinventorykind int,
	idreg int,
	adate datetime,
	printdate datetime,
	operationorder int,
	kind varchar(50),
	idinventory int,
	startnumber int,
	idinv int,
	codeinv varchar(50),
	assetdescription varchar(150),
	unitaryvalue decimal(23,2),
	prezzocopertina decimal(19,2),
	idlocation int,
	location varchar(500),
	idman int,
	manager varchar(500),
	number int,
	aq_startnumber int,
	nassetacquire int,
	doc varchar(35),
	docdate datetime,
	description varchar(150),
	enactment varchar(150),
	enactmentdate datetime,
	annotation varchar(6000),
	rfid varchar(30),
	idsubmanager int
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
	idlocation,
	idman,
	number,
	aq_startnumber,
	nassetacquire, 
	prezzocopertina ,-- importo al lordo dello sconto	
	rfid,
	idsubmanager
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
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL),
	assetacquire.number,
	assetacquire.startnumber,
	assetacquire.nassetacquire,
	CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.taxable,0) * isnull(assetacquire.taxrate,1),2)-- IVA calcolata PRIMA dello sconto
			,2))  ,
	asset.rfid,
	(SELECT TOP 1 idmanager
				FROM assetsubmanager
				WHERE assetsubmanager.idasset = asset.idasset
				ORDER BY start desc)
FROM assetacquire
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current  
	ON assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN  inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind 
WHERE asset.idpiece=1		
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
	idman,
	number,
	aq_startnumber,
	nassetacquire, 
	prezzocopertina, -- importo al lordo dello sconto 
	rfid,
	idsubmanager
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
	asset.ninventory,
	assetacquire.idinv, 
	assetacquire.description,
	assetview_current.start,
	(SELECT idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL),
	assetacquire.number,		
	assetacquire.startnumber,
	assetacquire.nassetacquire,
	CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.taxable,0) * isnull(assetacquire.taxrate,1),2)-- IVA calcolata PRIMA dello sconto
			,2)) ,
	asset.rfid,
	(SELECT TOP 1 idmanager
				FROM assetsubmanager
				WHERE assetsubmanager.idasset = asset.idasset
				ORDER BY start desc)
FROM assetacquire
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
join  assetview_current  
	ON assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
WHERE asset.idpiece>1			
	and assetload.idassetloadkind = @idassetloadkind
	AND assetload.yassetload = @ayear
	AND assetload.nassetload IN (SELECT num from #printing)

UPDATE #assetload
SET 
codeinv =
(SELECT codeinv
	FROM inventorytree
	WHERE idinv = #assetload.idinv),
location =
(SELECT description
	FROM location
	WHERE idlocation = #assetload.idlocation),
manager =
(SELECT title 
	FROM manager
	WHERE idman = #assetload.idman)

UPDATE #assetload SET number = 1 WHERE number IS NULL OR number = 0

IF @official = 'S'
BEGIN
	UPDATE #assetload
	SET printdate = @printdate
	WHERE yassetload = @ayear 
	AND nassetload IN (SELECT num from #printing)
	AND printdate IS NULL
END

CREATE TABLE #assetloadfinal
(
	idassetloadkind int,
	yassetload int,
	nassetload int,
	idmot varchar(20),
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
	codeinv varchar(50),
	assetdescription varchar(150),
	unitaryvalue decimal(23,2),
	prezzocopertina decimal(19,2),
	idlocation int,
	location varchar(500),
	idman int,
	manager varchar(500),
	number int,
	aq_startnumber int,
	descrclass varchar(200),
	valoretotale decimal(19,2),
	nassetacquire int,
	annotation varchar(6000)	,
	rfid varchar(30),
	idsubmanager int 	
)

INSERT INTO #assetloadfinal
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
	codeinv,
	assetdescription,
	unitaryvalue,
	idlocation,
	location,
	idman,
	manager,
	number,
	aq_startnumber,
	valoretotale,
	nassetacquire,
	prezzocopertina,
	rfid,
	idsubmanager
)
SELECT
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
	codeinv,
	assetdescription,
	unitaryvalue,
	idlocation,
	location,
	idman,
	manager,
	number,
	aq_startnumber,
	0, --valore totale
	nassetacquire,
	0, -- prezzocopertina
	rfid,
	idsubmanager
FROM 
#assetload

update #assetloadfinal 
	SET number = (select sum(number)FROM #assetloadfinal f
	WHERE 
	f.number <2
	AND f.idassetloadkind =  #assetloadfinal.idassetloadkind 
	AND f.yassetload =  #assetloadfinal.yassetload
	AND f.nassetload =  #assetloadfinal.nassetload
	AND ISNULL(f.idmot,0) =  ISNULL(#assetloadfinal.idmot,0)
	AND f.idinventoryagency =  #assetloadfinal.idinventoryagency
        AND f.number  =  #assetloadfinal.number
	AND f.idinventorykind =  #assetloadfinal.idinventorykind
	AND ISNULL(f.idreg,0) =  ISNULL(#assetloadfinal.idreg,0)
	AND f.description   =  #assetloadfinal.description                                                                                      
	AND isnull(f.enactment,'') = isnull( #assetloadfinal.enactment,'') 
	AND f.aq_startnumber =  #assetloadfinal.aq_startnumber 
	AND f.operationorder =  #assetloadfinal.operationorder
	AND f.kind =  #assetloadfinal.kind
	AND f.idinventory =  #assetloadfinal.idinventory
	and f.nassetacquire = #assetloadfinal.nassetacquire   
	GROUP BY  f.idassetloadkind, 
	f.yassetload ,
	f.nassetload ,
	f.idmot ,
	f.idinventoryagency, 
	f.idinventorykind, 
	f.idreg, 
	f.doc,                 
	f.docdate,                                         
	f.description,                                                                                          
	f.enactment,                                                                                        
	f.enactmentdate,                                      
	f.adate,
	f.printdate,
	f.operationorder,
	f.kind,
	f.idinventory,
	f.nassetacquire  
	) 
	WHERE 
	#assetloadfinal.number < 2

update #assetloadfinal 
	set valoretotale = isnull((select sum( isnull(f.unitaryvalue, 0.0))
	FROM #assetloadfinal f
	WHERE 
	f.idassetloadkind =  #assetloadfinal.idassetloadkind 
	AND f.yassetload =  #assetloadfinal.yassetload
	AND f.nassetload =  #assetloadfinal.nassetload
	AND ISNULL(f.idmot,0) =  ISNULL(#assetloadfinal.idmot,0)
	AND f.idinventoryagency =  #assetloadfinal.idinventoryagency
	AND f.idinventorykind =  #assetloadfinal.idinventorykind
	AND isnull(f.idreg,0) =  isnull(#assetloadfinal.idreg,0)
	AND isnull(f.assetdescription,'')   = isnull(#assetloadfinal.assetdescription,'')                                                                                     
	AND f.adate = #assetloadfinal.adate
	AND isnull(f.printdate,{d '1900-01-01'}) =  isnull(#assetloadfinal.printdate,{d '1900-01-01'})
	AND f.operationorder =  #assetloadfinal.operationorder
	AND f.kind                      =  #assetloadfinal.kind
	AND f.idinventory =  #assetloadfinal.idinventory
	and f.nassetacquire = #assetloadfinal.nassetacquire  
	GROUP BY  f.idassetloadkind 
	,f.yassetload 
	,f.nassetload 
	,f.idmot 
	,f.idinventoryagency 
	,f.idinventorykind 
	,f.idreg 
	,f.assetdescription                                                                                          
	,f.adate                                          
	,f.printdate                                             
	,f.operationorder 
	,f.kind                      
	,f.idinventory 
	,f.nassetacquire  
	),0.0)

update #assetloadfinal 
	set prezzocopertina = isnull((select sum( isnull(f.prezzocopertina, 0.0))
	FROM #assetloadfinal f
	WHERE 
	f.idassetloadkind =  #assetloadfinal.idassetloadkind 
	AND f.yassetload =  #assetloadfinal.yassetload
	AND f.nassetload =  #assetloadfinal.nassetload
	AND ISNULL(f.idmot,0) =  ISNULL(#assetloadfinal.idmot,0)
	AND f.idinventoryagency =  #assetloadfinal.idinventoryagency
	AND f.idinventorykind =  #assetloadfinal.idinventorykind
	AND isnull(f.idreg,0) =  isnull(#assetloadfinal.idreg,0)
	AND isnull(f.assetdescription,'')   = isnull(#assetloadfinal.assetdescription,'')                                                                                     
	AND f.adate = #assetloadfinal.adate
	AND isnull(f.printdate,{d '1900-01-01'}) =  isnull(#assetloadfinal.printdate,{d '1900-01-01'})
	AND f.operationorder =  #assetloadfinal.operationorder
	AND f.kind                      =  #assetloadfinal.kind
	AND f.idinventory =  #assetloadfinal.idinventory
	and f.nassetacquire = #assetloadfinal.nassetacquire  
	GROUP BY  f.idassetloadkind 
	,f.yassetload 
	,f.nassetload 
	,f.idmot 
	,f.idinventoryagency 
	,f.idinventorykind 
	,f.idreg 
	,f.assetdescription                                                                                          
	,f.adate                                          
	,f.printdate                                             
	,f.operationorder 
	,f.kind                      
	,f.idinventory 
	,f.nassetacquire  
	),0.0)
------- necessario xchè il responsabile può cambiare per numero inventario
DECLARE @num int
DECLARE @responsabile varchar(300)
DECLARE @responsabile1 varchar(300)
DECLARE @resp varchar(400)
DECLARE @responsa varchar(700)
UPDATE #assetloadfinal  set manager =''
SELECT @responsabile =''
SELECT @responsabile1 =''
DECLARE num_cursor INSENSITIVE CURSOR FOR
SELECT aq_startnumber , manager 
FROM #assetload 
WHERE manager is not null ORDER BY aq_startnumber 
OPEN num_cursor 
FETCH NEXT FROM num_cursor INTO @num, @resp
WHILE (@@FETCH_STATUS = 0)
BEGIN
	SELECT @responsabile = manager FROM #assetload
	WHERE 	#assetload.aq_startnumber = @num and manager = @resp
	SELECT @responsabile1 = manager FROM #assetloadfinal 
	WHERE  #assetloadfinal.aq_startnumber  = @num
	IF @responsabile1 = @responsabile
		SELECT @responsa = @responsabile
	ELSE 
		IF @responsabile1 ='' 
			SELECT @responsa = @responsabile
		ELSE 
			SELECT @responsa = substring(@responsabile1 + '-' + @responsabile, 1,700)
	UPDATE #assetloadfinal SET manager = @responsa
	WHERE  #assetloadfinal.aq_startnumber  = @num
	
	FETCH NEXT FROM  num_cursor INTO @num, @resp
END
DEALLOCATE num_cursor
------- necessario xchè l'ubicazione puo' cambiare per numero inventario
DECLARE @ubicazione varchar(200)
DECLARE @ubicazione1 varchar(200)
DECLARE @ubi varchar(400)
DECLARE @ubica varchar(700)
UPDATE #assetloadfinal  set location =''
SELECT @ubicazione  =''
SELECT @ubicazione1  =''
DECLARE num_cursor INSENSITIVE CURSOR FOR
SELECT aq_startnumber ,location 
FROM #assetload
WHERE location is not null ORDER BY aq_startnumber , location 
OPEN num_cursor 
FETCH NEXT FROM num_cursor INTO @num, @ubi
WHILE (@@FETCH_STATUS = 0)
BEGIN
	SELECT @ubicazione = location 
	FROM #assetload 
	WHERE #assetload.aq_startnumber = @num and location = @ubi
	SELECT @ubicazione1 = location 
	FROM #assetloadfinal 
	WHERE #assetloadfinal.aq_startnumber = @num
	IF @ubicazione1 = @ubicazione 
		SELECT @ubica = @ubicazione
	ELSE 
		IF @ubicazione1 ='' 
			SELECT @ubica = @ubicazione
		ELSE 
			SELECT @ubica = substring(@ubicazione1 + '-' + @ubicazione, 1,700)
	
	UPDATE #assetloadfinal SET location = @ubica
	WHERE  #assetloadfinal.aq_startnumber  = @num
	
	FETCH NEXT FROM  num_cursor INTO @num, @ubi
END
DEALLOCATE num_cursor
----------------------------------------------------------------------------------------------
DECLARE @codente varchar(20)
select @codente =  agencycode from license
update #assetloadfinal set idlocation =0
update #assetloadfinal 
SET descrclass =	
	(SELECT description
	FROM inventorytree
	JOIN inventorytreelink
		ON inventorytree.idinv = inventorytreelink.idparent
	WHERE inventorytreelink.idchild = #assetloadfinal.idinv
	AND inventorytreelink.nlevel = 1)

SELECT DISTINCT
	#assetloadfinal.idassetloadkind,
	yassetload,
	nassetload,
	-- #assetloadfinal.idmot,
	assetloadmotive.description as assetloadmotive,
	#assetloadfinal.idinventoryagency,
	AGENCY.description as inventoryagency ,
	#assetloadfinal.idinventorykind,
	INVKIND.description as inventorykind ,
	#assetloadfinal.idreg,
	registry.title,
	doc,
	docdate,
	#assetloadfinal.description,
	#assetloadfinal.annotation,
	enactment,
	enactmentdate,
	adate,
	printdate,
	operationorder,
	kind,
	#assetloadfinal.idinventory,
	idinv,
	codeinv,
	assetdescription,
	unitaryvalue,
	idlocation,
	#assetloadfinal.location,
	--'idlocation' = 0,
	manager,
	ISNULL(number, 1) as 'number' ,
	CASE
		WHEN (assetloadmotive.flag & 1 <> 0) THEN 'S'
		ELSE 'N'
	END AS flagnewasset,
	CASE 
		WHEN (assetloadmotive.flag & 1 <> 0) THEN 'N' 
	 	WHEN (assetloadmotive.flag & 1 <> 1) THEN 'U'
	END
	AS usato,
	aq_startnumber,
	 ISNULL(@codente ,'') as 'codiceente',
	valoretotale,
	descrclass,
	nassetacquire,
	AGENCY.title_l,   -- sezione firme
	AGENCY.name_l,
	AGENCY.title_c,
	AGENCY.name_c,
	AGENCY.title_r,
	AGENCY.name_r,
	isnull(#assetloadfinal.prezzocopertina,0) as prezzocopertina,
	case	when  INVKIND.flag & 4 <>0 then 'S'
			else 'N'
	end as 'libri',
	rfid,
	Submanager.title as submanager
FROM #assetloadfinal
LEFT OUTER JOIN assetloadmotive
	ON #assetloadfinal.idmot = assetloadmotive.idmot
LEFT OUTER JOIN registry
	ON #assetloadfinal.idreg = registry.idreg
LEFT OUTER JOIN inventoryagency AGENCY
	ON AGENCY.idinventoryagency = #assetloadfinal.idinventoryagency
JOIN inventorykind INVKIND
	ON INVKIND.idinventorykind = #assetloadfinal.idinventorykind
LEFT OUTER JOIN  manager as Submanager
	ON Submanager.idman = #assetloadfinal.idsubmanager
ORDER BY nassetload,aq_startnumber,operationorder
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

