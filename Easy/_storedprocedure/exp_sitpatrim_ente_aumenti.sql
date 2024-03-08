
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_sitpatrim_ente_aumenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_sitpatrim_ente_aumenti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE     PROCEDURE [exp_sitpatrim_ente_aumenti]
	@year int,
	@codinventoryagency int,
	@date datetime,
	@idinv int
AS BEGIN
DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)



CREATE TABLE #aumenti
(
	operationkind varchar(50),
	nassetacquire int,
	adate datetime,
	description varchar(300),
	import decimal(19,2),
	ninventory int,
	yassetload int,
	nassetload int,
	ratificationdate datetime,
	idinv int
)
	
-------------------------------------------------------------------------------------
-------------------------- Carichi cespiti  -------------------------------
-------------------------------------------------------------------------------------

INSERT INTO #aumenti(operationkind,nassetacquire,adate,description,import,ninventory ,yassetload ,nassetload ,ratificationdate,idinv)
SELECT
	'Carico Cespite',
	assetacquire.nassetacquire, 
	assetacquire.adate, 
	assetacquire.description, 
	assetview_current.start,
	asset.ninventory,
	assetload.yassetload, 
	assetload.nassetload, 
	assetload.ratificationdate,
	assetacquire.idinv
FROM assetacquire 
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN  assetview_current  
	ON assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN inventory
	ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv

WHERE asset.idpiece = 1
	AND inventorytreelink.nlevel = 1
	AND assetload.yassetload <= @year  
	AND assetload.ratificationdate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)

-------------------------------------------------------------------------------------
-------------------------- Carichi accessori ----------------------------------------
-------------------------------------------------------------------------------------	

INSERT INTO #aumenti(operationkind,nassetacquire,adate,description,import,ninventory ,yassetload ,nassetload ,ratificationdate,idinv)
SELECT
	'Carico Accessorio',
	caricoaccessorio.nassetacquire, 
	caricoaccessorio.adate, 
	caricoaccessorio.description, 
	assetview_current.start,
	caricoaccessorio.startnumber + accessorio.idpiece,
	buonocaricoaccessorio.yassetload, 
	buonocaricoaccessorio.nassetload, 
	buonocaricoaccessorio.ratificationdate,
	caricoaccessorio.idinv
FROM assetacquire as caricoaccessorio 
JOIN asset as accessorio 
	ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN assetview_current  
	ON assetview_current.idasset=accessorio.idasset and  assetview_current.idpiece=accessorio.idpiece
JOIN assetload as buonocaricoaccessorio
	ON buonocaricoaccessorio.idassetload = caricoaccessorio.idassetload
JOIN inventory
	ON caricoaccessorio.idinventory = inventory.idinventory
JOIN inventorytreelink
	ON inventorytreelink.idchild = caricoaccessorio.idinv
WHERE 	accessorio.idpiece>1 
	AND inventorytreelink.nlevel = 1
	AND buonocaricoaccessorio.yassetload <= @year
	AND buonocaricoaccessorio.ratificationdate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)


-------------------------------------------------------------------------------------
----- Rivalutazioni positive ufficiali (di BENI E DI ACCESSORI) ---------------------
-------------------------------------------------------------------------------------

INSERT INTO #aumenti(operationkind,nassetacquire,adate,description,import,ninventory,idinv)
SELECT 	
	'Rivalutazioni Positive Cespiti',
	assetacquire.nassetacquire, 
	assetacquire.adate, 
	assetacquire.description, 
	ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2),
	CASE asset.idpiece WHEN  1 THEN asset.ninventory
		ELSE assetacquire.startnumber + asset.idpiece
	END,
	assetacquire.idinv

FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization
	ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
WHERE ((assetacquire.flag & 1 <> 1) OR assetacquire.idassetload IS NOT NULL)
	AND inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota >= 0
	AND assetamortization.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency)
	AND ((inventorytreelink.idparent = @idinv
	AND inventorytreelink.nlevel = (select max(ITL.nlevel) from inventorytreelink ITL where ITL.idparent = inventorytreelink.idparent))
	OR @idinv is null)

SELECT  #aumenti.operationkind AS 'Tipo Operazione',
	#aumenti.nassetacquire AS 'Num Carico Cespite',
	#aumenti.adate AS 'Data Contabile',
	#aumenti.description AS 'Descrizione',
	#aumenti.import AS 'Importo',
	#aumenti.ninventory AS 'Numero Inventario',
	#aumenti.yassetload AS 'Esercizio Buono',
	#aumenti.nassetload AS 'Numero Buono',
	#aumenti.ratificationdate AS 'Data Ratifica',
	inventorytree.codeinv AS 'Cod. Class.' ,
	inventorytree.description AS 'Classificazione'
FROM #aumenti
	JOIN inventorytree
		ON #aumenti.idinv = inventorytree.idinv

END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

