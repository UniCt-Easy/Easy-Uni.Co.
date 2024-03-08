
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sit_ubicazione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sit_ubicazione]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [rpt_sit_ubicazione]
(
	@idlocation varchar(50),  
	@idinventory int,
	@start datetime,
	@stop datetime,
	@idsorkind int
)
AS BEGIN

DECLARE @nlevellocation tinyint
SELECT @nlevellocation = MAX(nlevel) FROM locationlevel
	
CREATE TABLE #sit_cespiti
(
	yassetload int,
	flagload char(1),
	idinventory int,
	description varchar(300)	, ---verificare la lunghezza della descrizione del cespite
	number int		,
	ninventory int,
	idasset int,
	idinv int,
	idlocation int,
	idmanager int,
	idassetunload int,
	idassetunloadkind int,
	yassetunload smallint,
	nassetunload int,
	flagunload char(1),
	state varchar(300),
	currentvalue decimal(19,2),
	afferenza varchar(300)
)

INSERT INTO #sit_cespiti
(
	yassetload,
	flagload,
	idinventory,
	description,
	number,
	ninventory,
	idasset,
	idinv,
	idlocation,
	idmanager,
	idassetunload,
	idassetunloadkind,
	yassetunload,  
	nassetunload,
	flagunload,
	state,
	currentvalue
)
SELECT
	assetload.yassetload,
	CASE
		WHEN assetacquire.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetacquire.idinventory, 
	assetacquire.description,	----descrizione
	assetacquire.number,		----quantità
	asset.ninventory,			----numero inventario
	asset.idasset, 
	assetacquire.idinv, 		----classe
	location.idlocation,
	manager.idman,				----responsabile dell'ubicazione
	asset.idassetunload,
	assetunload.idassetunloadkind,
	assetunload.yassetunload, 
	assetunload.nassetunload,
	CASE
		WHEN asset.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	'In carico',
	assetview_current.start
FROM asset 
join  assetview_current 
	ON assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
LEFT OUTER JOIN assetunload
	ON assetunload.idassetunload = asset.idassetunload
JOIN assetacquire 
	ON assetacquire.nassetacquire = asset.nassetacquire
LEFT OUTER JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN inventory 
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind   
LEFT OUTER JOIN location 
	ON location.idlocation =
	(SELECT idlocation FROM assetlocation
	WHERE assetlocation.idasset = asset.idasset
	AND start IS NULL)
LEFT OUTER JOIN manager
	ON manager.idman = location.idman
WHERE 	asset.idpiece = 1 
	AND (location.nlevel >= @nlevellocation OR @nlevellocation IS NULL)
	AND (location.locationcode LIKE @idlocation +'%' OR @idlocation is null)
	AND assetacquire.adate BETWEEN @start AND @stop
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 

-------------------------------------------------------------------------------------------------
------ CARICHI ACCESSORI  DI BENI 
-------------------------------------------------------------------------------------------------

UPDATE #sit_cespiti
SET currentvalue = ISNULL(currentvalue, 0.0) +
ISNULL(
	(SELECT  SUM(assetview_current.start)
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	join  assetview_current  
		ON assetview_current.idasset=accessorio.idasset and assetview_current.idpiece=accessorio.idpiece
	WHERE accessorio.idpiece > 1
		AND caricoaccessorio.adate<=@stop
		AND accessorio.idasset = #sit_cespiti.idasset
		AND caricoaccessorio.idassetload IS NOT NULL)
,0.0)

-------------------------------------------------------------------------------------------------
------ RIVALUTAZIONI DEGLI ACCESSORI DEI BENI 
-------------------------------------------------------------------------------------------------

UPDATE #sit_cespiti
SET currentvalue = ISNULL(currentvalue, 0.0) +
ISNULL(
	(SELECT
		SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			iSNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire as caricoaccessorio 
JOIN asset as accessorio 
	ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN assetamortization
	ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
LEFT OUTER JOIN assetunload
	ON  assetamortization.idassetunload = assetunload.idassetunload
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
WHERE accessorio.idasset = #sit_cespiti.idasset AND
	assetamortization.idpiece > 1
	AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
	            (
		     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
	             ((assetamortization.flag & 1 <> 1) OR 
		      (assetamortization.idassetunload IS NOT NULL))
		     )
		    )
	AND (inventoryamortization.flag & 2 <> 0)
	AND caricoaccessorio.adate <= @stop
	AND caricoaccessorio.idassetload IS NOT NULL
	)
, 0.0)

-------------------------------------------------------------------------------------------------
--------------------- SCARICHI ACCESSORI  DI BENI -----------------------------------------------
-------------------------------------------------------------------------------------------------
-- Non considerimao gli scarichi accessori associati allo scarico cespite
-- ossia il valore del cespite rimane congelato al momento dello scarico

UPDATE #sit_cespiti
SET currentvalue = ISNULL(currentvalue, 0.0) -
ISNULL(
	(SELECT 
		SUM(assetview_current.start)
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN  assetview_current  
		ON accessorio.idasset=asset.idasset and accessorio.idpiece=asset.idpiece
	WHERE accessorio.idpiece > 1 
		AND accessorio.idasset = #sit_cespiti.idasset 
		AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 <> 1))  --accessorio scaricato
		AND (accessorio.idassetunload IS NULL OR --accessorio non scaricato esplicitamente
		    (#sit_cespiti.idassetunload IS NULL AND #sit_cespiti.flagunload = 'S') OR --cespite non scaricato
	        	(#sit_cespiti.idassetunload <> accessorio.idassetunload)  --buono scarico distinto
		)
	), 0.0)

-------------------------------------------------------------------------------------------------
-------------------- RIVALUTAZIONI DEGLI ACCESSORI SCARICATI DEI BENI ---------------------------
-------------------------------------------------------------------------------------------------

UPDATE #sit_cespiti
SET currentvalue = ISNULL(currentvalue, 0.0) -
ISNULL(
	(SELECT
		SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			  ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio 
		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN assetamortization
		ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	WHERE accessorio.idasset = #sit_cespiti.idasset 
		AND assetamortization.idpiece > 1
		AND (inventoryamortization.flag & 2 <> 0)
		AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
		            (
			     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
		             ((assetamortization.flag & 1 <> 1) OR 
			      (assetamortization.idassetunload IS NOT NULL))
			     )
			    )
		AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 <> 1)) 
		AND (accessorio.idassetunload IS NULL OR      --accessorio non scaricato esplicitamente
		    (#sit_cespiti.idassetunload IS NULL AND #sit_cespiti.flagunload='S')  OR --cespite non scaricato
		    (#sit_cespiti.idassetunload <> accessorio.idassetunload) --buono scarico distinto
		 )
	)
, 0.0)
		
--- update delle afferenze

UPDATE #sit_cespiti set afferenza =
	(SELECT S.description FROM sorting S
	JOIN locationsorting LS
		ON S.idsor = LS.idsor
	JOIN location L
		ON LS.idlocation=L.idlocation
	WHERE S.idsorkind=@idsorkind
		AND L.idlocation = #sit_cespiti.idlocation)

SELECT
	#sit_cespiti.idinventory,
	inventory.description as 'inventory',
	inventory.codeinventory,
	#sit_cespiti.ninventory,
	#sit_cespiti.idasset,
	assetacquire.description,
	#sit_cespiti.idinv,
	inventorytree.codeinv,
	inventorytree.description as 'descinvtree',
	inventorytree.nlevel as 'nlevelinvtree',
	inventorysortinglevel.description as 'desclevelinvtree',
	location.idlocation,
	location.locationcode,
	location.description as 'location',
	location.nlevel as 'nlevellocation',
	locationlevel.description as 'desclevellocation',
	manager.idman as 'idmanager',
	manager.title as 'manager',
	assetload.idassetloadkind,
	assetload.yassetload,
	assetload.nassetload,
	#sit_cespiti.nassetunload,
	#sit_cespiti.state,
	#sit_cespiti.currentvalue,
	isnull(u9.description,'') as 'descrlungaubic1',
	ltrim(ISNULL(u8.description,'') + ' ' + 
		ISNULL(u7.description,'')+' '+ ISNULL(u6.description,'')+' '+ 
		ISNULL(u5.description,'')+' '+ ISNULL(u4.description,'')+' '+ 
		ISNULL(u3.description,'')+' '+ ISNULL(u2.description,'')+' '+ 
		ISNULL(location.description,'')) as 'descrlungaubic2', 
	ltrim(  ISNULL(c6.description,'')+' '+ 
		ISNULL(c5.description,'')+' '+ ISNULL(c4.description,'')+' '+ 
		ISNULL(c3.description,'')+' '+ ISNULL(c2.description,'')+' '+ 
		ISNULL(inventorytree.description,'')) as 'descrlungaclas',
	'1' as 'quantità',
	#sit_cespiti.afferenza,
	inventory.description
FROM #sit_cespiti
JOIN asset 
	ON asset.idasset = #sit_cespiti.idasset
	AND asset.idpiece = 1
JOIN assetacquire 
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventorytree 
	ON inventorytree.idinv = #sit_cespiti.idinv
JOIN inventorysortinglevel 
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
JOIN inventory 
	ON inventory.idinventory = #sit_cespiti.idinventory
LEFT OUTER JOIN assetload
	ON assetacquire.idassetload = assetload.idassetload
LEFT OUTER JOIN location 
	ON location.idlocation = #sit_cespiti.idlocation
LEFT OUTER JOIN locationlevel 
	ON locationlevel.nlevel = location.nlevel
LEFT OUTER JOIN manager
	ON manager.idman = #sit_cespiti.idmanager
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind   
LEFT OUTER JOIN inventorytreelink il2
	ON il2.idchild = #sit_cespiti.idinv AND il2.nlevel = 6
LEFT OUTER JOIN inventorytree c2
	ON il2.idparent = c2.idinv
LEFT OUTER JOIN inventorytreelink il3
	ON il3.idchild = #sit_cespiti.idinv AND il3.nlevel = 5
LEFT OUTER JOIN inventorytree c3
	ON il3.idparent = c3.idinv
LEFT OUTER JOIN inventorytreelink il4
	ON il4.idchild = #sit_cespiti.idinv AND il4.nlevel = 4
LEFT OUTER JOIN inventorytree c4
	ON il4.idparent = c4.idinv
LEFT OUTER JOIN inventorytreelink il5
	ON il5.idchild = #sit_cespiti.idinv AND il5.nlevel = 3
LEFT OUTER JOIN inventorytree c5
	ON il5.idparent = c5.idinv
LEFT OUTER JOIN inventorytreelink il6
	ON il6.idchild = #sit_cespiti.idinv AND il6.nlevel = 2
LEFT OUTER JOIN inventorytree c6
	ON il6.idparent = c6.idinv
LEFT OUTER JOIN inventorytreelink il7
	ON il7.idchild = #sit_cespiti.idinv AND il7.nlevel = 1
LEFT OUTER JOIN inventorytree c7
	ON il7.idparent = c7.idinv
LEFT OUTER JOIN locationlink ll2
	ON ll2.idchild = #sit_cespiti.idlocation AND ll2.nlevel = 8
LEFT OUTER JOIN location u2
	ON ll2.idparent = u2.idlocation
LEFT OUTER JOIN locationlink ll3
	ON ll3.idchild = #sit_cespiti.idlocation AND ll3.nlevel = 7
LEFT OUTER JOIN location u3
	ON ll3.idparent = u3.idlocation
LEFT OUTER JOIN locationlink ll4
	ON ll4.idchild = #sit_cespiti.idlocation AND ll4.nlevel = 6
LEFT OUTER JOIN location u4
	ON ll4.idparent = u4.idlocation
LEFT OUTER JOIN locationlink ll5
	ON ll5.idchild = #sit_cespiti.idlocation AND ll5.nlevel = 5
LEFT OUTER JOIN location u5
	ON ll5.idparent = u5.idlocation
LEFT OUTER JOIN locationlink ll6
	ON ll6.idchild = #sit_cespiti.idlocation AND ll6.nlevel = 4
LEFT OUTER JOIN location u6
	ON ll6.idparent = u6.idlocation
LEFT OUTER JOIN locationlink ll7
	ON ll7.idchild = #sit_cespiti.idlocation AND ll7.nlevel = 3
LEFT OUTER JOIN location u7
	ON ll7.idparent = u7.idlocation
LEFT OUTER JOIN locationlink ll8
	ON ll8.idchild = #sit_cespiti.idlocation AND ll8.nlevel = 2
LEFT OUTER JOIN location u8
	ON ll8.idparent = u8.idlocation
LEFT OUTER JOIN locationlink ll9
	ON ll9.idchild = #sit_cespiti.idlocation AND ll9.nlevel = 1
LEFT OUTER JOIN location u9
	ON ll9.idparent = u9.idlocation

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 
