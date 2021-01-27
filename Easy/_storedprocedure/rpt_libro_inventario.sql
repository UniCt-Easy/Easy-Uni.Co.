
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_libro_inventario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_libro_inventario]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE      PROCEDURE [rpt_libro_inventario]
(
	@ayear int,
	@idinventory int,
	@start datetime,
	@stop datetime,
	@codeinv varchar(40)
)
AS BEGIN
-- LEGENDA 
-- 1 CARICO CESPITE   ASSETKIND = 1
-- 1 CARICO ACCESSORIO   ASSETKIND = 2
-- 3 SCARICO CESPITE   ASSETKIND = 1
-- 3 SCARICO ACCESSORIO   ASSETKIND = 2
-- 5 VAR.AUM
-- 6 VAR.DIM
-- 7 RIVALUTAZ
-- 8 SVALUTAZ.

DECLARE @flag_discount char(1)   
IF (SELECT TOP 1 (inventorykind.flag & 1) FROM inventorykind JOIN inventory 				
	ON inventory.idinventorykind= inventorykind.idinventorykind				
		WHERE idinventory=@idinventory) <> 0
BEGIN
	SET @flag_discount = 'S'
END
ELSE 
BEGIN
	SET @flag_discount = 'N'
END
	
DECLARE @inventory varchar(100)
SET @inventory = (SELECT description FROM inventory WHERE idinventory =@idinventory  )
 
IF @codeinv ='' OR @codeinv = '%' OR @codeinv IS NULL SET @codeinv ='%'
	
CREATE TABLE #total_inventory_list (codeinv varchar(40), total decimal(19,2))


CREATE TABLE #asset_amortization 
(
	codeinv varchar(40),valore decimal(19,2)
)


CREATE TABLE #asset_amortization_unload
(
	codeinv varchar(40),valore decimal(19,2)
)

CREATE TABLE #inventory_list
(
	startnumber int, idinventory int, inventorykind varchar(45),
	inventoryagency varchar(150), opdate datetime, operation varchar(45),
	opkind int, opnumber int, assetkind int, ninventory int, idasset int, idpiece int,
	idassetloadkind int, yassetload int, nassetload int,
	assetloaddate datetime, idinv int, codeinv varchar(40),
	detailsdescr varchar(150), loaded_amount decimal(19,2),	unloaded_amount	decimal(19,2),
	var_unloaded_amount decimal(19,2), idmot int, loadunloadmotive varchar(45),
	used char(1), idlocation int, location varchar(150),
	idmanager int, manager varchar(150), loadkind char(1),
	number int, descinvtree varchar(150), taxable decimal(19,2),
	sign char(1), adate datetime, total_amount decimal(19,2),tot_amortization_loaded decimal(19,2)
)
------------------------------------------------------------------------------------------
-- table per evitare duplicazioni di record se le ubicazioni o i responsabili sono diversi
CREATE TABLE #inventory_list_1
(
	idinventory int, inventorykind varchar(45), inventoryagency varchar(150),
	opdate datetime, operation varchar(45), opkind int, 
	opnumber int, assetkind int,yassetload int,
	nassetload int,	assetloaddate datetime,	codeinv varchar(40), detailsdescr varchar(150),
	loaded_amount decimal(19,2), unloaded_amount decimal(19,2), var_unloaded_amount decimal(19,2),
	loadunloadmotive varchar(45), location varchar(800), manager varchar(800),
	used char(1), descinvtree varchar(150), total_price decimal(19,2), sign char(1), 
	idinv int, startnumber int, ninventory int,
	number int, total_amount decimal(19,2), idpiece	int,tot_amortization_loaded decimal(19,2)
)
	
INSERT INTO #total_inventory_list (codeinv, total)
SELECT
	inventorytree.codeinv,
	ISNULL(SUM(assetvardetail.amount),0)
FROM assetvardetail
JOIN assetvar			ON assetvar.idassetvar = assetvardetail.idassetvar
JOIN inventorytree		ON inventorytree.idinv = assetvardetail.idinv
JOIN inventory			ON assetvar.idinventoryagency = inventory.idinventoryagency
							AND inventory.idinventory = @idinventory
WHERE assetvar.yvar = @ayear
	AND (assetvar.flag & 1 <> 1)
	AND (@idinventory IS NULL OR assetvardetail.idinventory = @idinventory)
GROUP BY inventorytree.codeinv

INSERT INTO #inventory_list
(
	idinventory, idinv, codeinv, descinvtree, opdate,
	adate, operation, opkind, opnumber, assetkind, detailsdescr,
	loaded_amount, unloaded_amount, var_unloaded_amount, sign,
	startnumber
)
SELECT 
	inventory.idinventory, inventorytree.idinv, inventorytree.codeinv, inventorytree.description, 
	assetvar.adate,	assetvar.adate,
	'Variazione in aumento', 5,assetvar.nvar, 0,
	'Var. ' + CONVERT(varchar(6), assetvar.nvar) + '/' + CONVERT(varchar(4), assetvar.yvar) + ' ' + assetvardetail.description,
	ISNULL(assetvardetail.amount, 0),
	0, 0, '+', 0
FROM assetvardetail
JOIN assetvar			ON assetvar.idassetvar = assetvardetail.idassetvar
JOIN inventorytree		ON inventorytree.idinv = assetvardetail.idinv
JOIN inventory			ON assetvar.idinventoryagency = inventory.idinventoryagency	AND inventory.idinventory = @idinventory
WHERE (assetvar.flag & 1 <> 0)
	AND assetvar.yvar = @ayear
	AND assetvar.adate BETWEEN @start AND @stop
	AND (assetvardetail.idinventory IS NULL OR assetvardetail.idinventory = @idinventory)
	AND assetvardetail.amount > 0
	
INSERT INTO #inventory_list
(
	idinventory, idinv, codeinv, descinvtree, opdate, 
	adate, operation, opkind,opnumber,assetkind,
	detailsdescr, loaded_amount, unloaded_amount, var_unloaded_amount, sign, startnumber
)
SELECT 
	inventory.idinventory, inventorytree.idinv, inventorytree.codeinv, inventorytree.description,
	assetvar.adate,	assetvar.adate,
	'Variazione in diminuzione', 6,assetvar.nvar, 0,
	'Var. ' + CONVERT(varchar(6), assetvar.nvar) + '/' + CONVERT(varchar(4), assetvar.yvar) + ' ' + assetvardetail.description ,
	0,
	- ISNULL(assetvardetail.amount, 0),
	0, '-', 0
FROM assetvardetail
JOIN assetvar			ON assetvar.idassetvar = assetvardetail.idassetvar
JOIN inventorytree		ON inventorytree.idinv = assetvardetail.idinv
JOIN inventory			ON assetvar.idinventoryagency = inventory.idinventoryagency		AND inventory.idinventory = @idinventory
WHERE (assetvar.flag & 1 <> 0)
	AND assetvar.yvar = @ayear
	AND assetvar.adate BETWEEN @start AND @stop
	AND (assetvardetail.idinventory IS NULL OR assetvardetail.idinventory = @idinventory)
	AND assetvardetail.amount < 0

-------------------------------------------------------------------------------------------------
------ CARICO CESPITI
-------------------------------------------------------------------------------------------------

INSERT INTO #inventory_list
(
	idinventory, idinv, codeinv, descinvtree, 
	opdate, operation, opkind, opnumber, assetkind, ninventory, 
	idassetloadkind, yassetload, nassetload, assetloaddate, detailsdescr, loaded_amount, 
	unloaded_amount, var_unloaded_amount, idmot, idlocation, idmanager, loadkind, number,
	taxable, sign, startnumber, adate
)
SELECT
	assetacquire.idinventory, assetacquire.idinv, inventorytree.codeinv, inventorytree.description,	assetacquire.adate,
	'Carico bene', 1, 0, 1,asset.ninventory, assetload.idassetloadkind, assetload.yassetload, assetload.nassetload,
	null, 
	isnull(assetacquire.description,''),
	assetview_current.start,
	0, 0, assetacquire.idmot,
	(SELECT l.idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT m.idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL),
	CASE
		WHEN assetacquire.flag & 2 <> 0 THEN 'R'
		ELSE 'N'
	END, assetacquire.number,
	ISNULL(assetacquire.taxable, 0.0),
	'+', assetacquire.startnumber, assetacquire.adate 
FROM assetacquire
LEFT OUTER JOIN assetload		ON assetload.idassetload = assetacquire.idassetload
JOIN asset						ON assetacquire.nassetacquire = asset.nassetacquire
join  assetview_current			on assetview_current.idasset=asset.idasset and assetview_current.idpiece=asset.idpiece
JOIN inventorytree				ON assetacquire.idinv = inventorytree.idinv
WHERE asset.idpiece = 1 
	AND assetacquire.idinventory = @idinventory
	AND codeinv LIKE @codeinv AND 
	((assetacquire.flag & 1 <> 1) AND assetacquire.idassetload IS NOT NULL)    -- Bene Posseduto
	--per i beni posseduti conta l'operazione di carico bene
	--NINO: RI-aggiunto filtro su adate, altrimenti sono inclusi beni già  presenti nella
	--situazione patrimoniale data dalla variazione iniziale dell'esercizio!
	AND assetacquire.adate BETWEEN @start AND @stop
UNION ALL
SELECT
	assetacquire.idinventory, assetacquire.idinv, inventorytree.codeinv, inventorytree.description, assetload.adate,
	'Carico bene', 1,assetload.nassetload, 1, asset.ninventory, assetload.idassetloadkind, assetload.yassetload, assetload.nassetload,
	assetload.adate, ISNULL(assetacquire.description,''),
	assetview_current.start,
	0, 0, assetacquire.idmot, 
	(SELECT l.idlocation FROM assetlocation l WHERE l.idasset = asset.idasset AND l.start IS NULL),
	(SELECT m.idman FROM assetmanager m WHERE m.idasset = asset.idasset AND m.start IS NULL),
	CASE
		WHEN assetacquire.flag & 2 <> 0 THEN 'R'
		ELSE 'N'
	END, assetacquire.number,
	ISNULL(assetacquire.taxable, 0.0),
	'+', assetacquire.startnumber, assetacquire.adate --era assetacquire.adate
FROM assetacquire
JOIN asset						ON assetacquire.nassetacquire = asset.nassetacquire
JOIN  assetview_current			ON  assetview_current.idasset=asset.idasset and  assetview_current.idpiece=asset.idpiece
JOIN assetload					ON assetload.idassetload = assetacquire.idassetload
JOIN inventorytree				ON assetacquire.idinv = inventorytree.idinv
WHERE asset.idpiece = 1 
	AND assetacquire.idinventory = @idinventory
	AND codeinv LIKE @codeinv 
	AND (assetacquire.flag & 1 <> 0)  --beni di nuova acquisizione inseriti in un buono di carico
	AND assetload.adate BETWEEN @start AND @stop

-------------------------------------------------------------------------------------------------
------ CARICO ACCESSORI -------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------

INSERT INTO #inventory_list
(
	idinventory, idinv, codeinv, descinvtree, opdate, operation, opkind,opnumber,assetkind,
	ninventory, idassetloadkind, yassetload, nassetload, assetloaddate, detailsdescr,
	loaded_amount, unloaded_amount, var_unloaded_amount, idmot, idlocation,
	idmanager, number, taxable, sign, startnumber, adate, idpiece
)
SELECT
	assetacquire_cespite.idinventory, assetacquire_accessorio.idinv, inventorytree.codeinv,
	inventorytree.description, assetload_accessorio.adate,
	'Carico accessorio', 1,assetload_accessorio.nassetload,2, cespite.ninventory,
  	assetload_accessorio.idassetloadkind, assetload_accessorio.yassetload,
 	assetload_accessorio.nassetload, assetload_accessorio.adate,
	isnull(assetacquire_accessorio.description,''),
	assetview_current.start,
	0, 0, assetacquire_accessorio.idmot, 
	(SELECT l.idlocation FROM assetlocation l WHERE l.idasset = cespite.idasset AND l.start IS NULL),
	(SELECT m.idman FROM assetmanager m WHERE m.idasset = cespite.idasset AND m.start IS NULL),
	assetacquire_accessorio.number,
	ISNULL(assetacquire_accessorio.taxable, 0.0),
	'+', assetacquire_cespite.startnumber, assetacquire_accessorio.adate, accessorio.idpiece
FROM assetacquire as assetacquire_accessorio 
JOIN asset as accessorio					ON accessorio.nassetacquire = assetacquire_accessorio.nassetacquire
join  assetview_current						on assetview_current.idasset=accessorio.idasset and assetview_current.idpiece=accessorio.idpiece
JOIN asset as cespite						ON accessorio.idasset = cespite.idasset
JOIN assetacquire as assetacquire_cespite	ON cespite.nassetacquire = assetacquire_cespite.nassetacquire
JOIN assetload as assetload_accessorio		ON assetload_accessorio.idassetload = assetacquire_accessorio.idassetload
JOIN inventorytree							ON assetacquire_accessorio.idinv = inventorytree.idinv
WHERE accessorio.idpiece >1 and cespite.idpiece = 1 
	AND assetacquire_accessorio.idinventory = @idinventory
	AND (assetacquire_accessorio.flag & 1 <> 0) --beni di nuova acquisizione inseriti in un buono di carico
	AND assetload_accessorio.adate BETWEEN @start AND @stop
	AND codeinv LIKE @codeinv
UNION ALL
SELECT
	assetacquire_cespite.idinventory, assetacquire_accessorio.idinv, inventorytree.codeinv,
	inventorytree.description, assetacquire_accessorio.adate,
	'Carico accessorio', 1,0,2, cespite.ninventory,
  	assetload_accessorio.idassetloadkind, assetload_accessorio.yassetload,
 	assetload_accessorio.nassetload,
  	null, 
	isnull(assetacquire_accessorio.description,''),
	assetview_current.start,
	0, 0, assetacquire_accessorio.idmot,
	(SELECT l.idlocation FROM assetlocation l WHERE l.idasset = cespite.idasset AND l.start IS NULL),
	(SELECT m.idman FROM assetmanager m WHERE m.idasset = cespite.idasset AND m.start IS NULL),
	assetacquire_accessorio.number,	ISNULL(assetacquire_accessorio.taxable, 0.0),
	'+', assetacquire_cespite.startnumber, assetacquire_accessorio.adate, accessorio.idpiece
FROM assetacquire as assetacquire_accessorio 
LEFT OUTER JOIN assetload assetload_accessorio			ON assetload_accessorio.idassetload = assetacquire_accessorio.idassetload
JOIN asset as accessorio								ON accessorio.nassetacquire = assetacquire_accessorio.nassetacquire
join  assetview_current									on assetview_current.idasset=accessorio.idasset and assetview_current.idpiece=accessorio.idpiece
JOIN asset as cespite									ON accessorio.idasset = cespite.idasset
JOIN assetacquire as assetacquire_cespite				ON assetacquire_cespite.nassetacquire = cespite.nassetacquire
JOIN inventorytree										ON   assetacquire_accessorio.idinv = inventorytree.idinv
WHERE accessorio.idpiece >1 and cespite.idpiece = 1 
	and assetacquire_cespite.idinventory = @idinventory
	and ((assetacquire_accessorio.flag & 1 <> 1) and assetacquire_accessorio.idassetload IS NOT NULL)    --Bene Posseduto
	AND assetacquire_accessorio.adate BETWEEN @start AND @stop
	AND codeinv LIKE @codeinv

-------------------------------------------------------------------------------------------------
------ SCARICO BENE
-------------------------------------------------------------------------------------------------

INSERT INTO #inventory_list
(
	idinventory, idinv, codeinv, descinvtree, opdate, operation, opkind, opnumber,assetkind,
	idasset, idpiece, ninventory, idassetloadkind, yassetload, nassetload,
	assetloaddate, detailsdescr, loaded_amount, unloaded_amount,
	idmot, idlocation, idmanager, number, taxable, sign, startnumber, adate
)
SELECT
	assetacquire_cespite.idinventory, assetacquire_cespite.idinv, inventorytree.codeinv,
	inventorytree.description, assetunload_cespite.adate, 'Scarico bene',
	3, assetunload_cespite.nassetunload, 1,cespite.idasset, cespite.idpiece, cespite.ninventory, assetunload_cespite.idassetunloadkind,
  	assetunload_cespite.yassetunload, assetunload_cespite.nassetunload, assetunload_cespite.adate,
	isnull(assetacquire_cespite.description,''), 0,
	assetview_current.start,
	assetunload_cespite.idmot,
	(SELECT l.idlocation FROM assetlocation l WHERE l.idasset = cespite.idasset AND l.start IS NULL),
	(SELECT m.idman FROM assetmanager m WHERE m.idasset = cespite.idasset AND m.start IS NULL),
	1, 
	ISNULL(assetacquire_cespite.taxable,0.0),
	'-', assetacquire_cespite.startnumber, assetunload_cespite.adate 
FROM assetunload as assetunload_cespite
JOIN asset as cespite							ON assetunload_cespite.idassetunload = cespite.idassetunload
JOIN  assetview_current							ON assetview_current.idasset=cespite.idasset and assetview_current.idpiece=cespite.idpiece
JOIN assetacquire as assetacquire_cespite		ON assetacquire_cespite.nassetacquire = cespite.nassetacquire
LEFT OUTER JOIN assetload assetload_cespite		ON assetload_cespite.idassetload = assetacquire_cespite.idassetload
JOIN inventorytree								ON assetacquire_cespite.idinv = inventorytree.idinv
WHERE cespite.idpiece = 1 
	AND assetacquire_cespite.idinventory = @idinventory
	AND assetunload_cespite.adate BETWEEN @start AND @stop
	AND codeinv LIKE @codeinv
	
-------------------------------------------------------------------------------------------------
------ RIVALUTAZIONI DI BENI SCARICATI
-------------------------------------------------------------------------------------------------

UPDATE #inventory_list
SET var_unloaded_amount = ISNULL(var_unloaded_amount, 0.0) +
	ISNULL((SELECT SUM(ROUND(ISNULL(assetamortization.assetvalue, 0.0) *	ISNULL(assetamortization.amortizationquota,0.0),2))
FROM assetamortization
JOIN inventoryamortization				ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
WHERE assetamortization.idasset = #inventory_list.idasset AND
	assetamortization.idpiece = 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
            (
	     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
             ((assetamortization.flag & 1 <> 1) OR 
	      (assetamortization.idassetunload IS NOT NULL))
	     )
	    )
	), 0.0)
WHERE opkind = 3 and assetkind = 1 --scarico bene
	AND idasset IS NOT NULL
	
-------------------------------------------------------------------------------------------------
------ SCARICO ACCESSORI
-------------------------------------------------------------------------------------------------

INSERT INTO #inventory_list
(
	idinventory, idinv, codeinv, descinvtree, 
	opdate, operation, opkind, opnumber,assetkind, idasset,
	idpiece, ninventory, idassetloadkind, yassetload, nassetload, assetloaddate,
	detailsdescr, loaded_amount, unloaded_amount, var_unloaded_amount, idmot,
	idlocation, idmanager, number, taxable,	sign, startnumber, adate
)
SELECT
	assetacquire_cespite.idinventory, assetacquire_accessorio.idinv,
	inventorytree.codeinv, inventorytree.description,
   	assetunload_accessorio.adate, 'Scarico accessorio', 3,assetunload_accessorio.nassetunload,2,
	accessorio.idasset, accessorio.idpiece, cespite.ninventory,
  	assetunload_accessorio.idassetunloadkind, assetunload_accessorio.yassetunload,
  	assetunload_accessorio.nassetunload, assetunload_accessorio.adate,
	isnull(assetacquire_accessorio.description,''),	0,
	assetview_current.start, 0,assetunload_accessorio.idmot,
	(SELECT l.idlocation FROM assetlocation l WHERE l.idasset = cespite.idasset AND l.start IS NULL),
	(SELECT m.idman FROM assetmanager m WHERE m.idasset = cespite.idasset AND m.start IS NULL),
	1,
	ISNULL(assetacquire_accessorio.taxable, 0.0), '-', assetacquire_cespite.startnumber,  
	assetunload_accessorio.adate
FROM assetunload as assetunload_accessorio 
JOIN asset as accessorio							ON  assetunload_accessorio.idassetunload = accessorio.idassetunload
JOIN assetview_current								ON assetview_current.idasset=accessorio.idasset and assetview_current.idpiece=accessorio.idpiece
JOIN assetacquire as assetacquire_accessorio		ON assetacquire_accessorio.nassetacquire = accessorio.nassetacquire
JOIN asset as cespite								ON accessorio.idasset = cespite.idasset
JOIN assetacquire as assetacquire_cespite			ON assetacquire_cespite.nassetacquire = cespite.nassetacquire
JOIN inventorytree									ON assetacquire_accessorio.idinv = inventorytree.idinv
WHERE accessorio.idpiece >1 AND cespite.idpiece=1
	AND assetacquire_accessorio.idinventory = @idinventory
	AND assetunload_accessorio.adate BETWEEN @start AND @stop
	AND codeinv LIKE @codeinv

-------------------------------------------------------------------------------------------------
------ RIVALUTAZIONI DI ACCESSORI SCARICATI -----------------------------------------------------
-------------------------------------------------------------------------------------------------

UPDATE #inventory_list
SET var_unloaded_amount = ISNULL(var_unloaded_amount, 0.0) +
	ISNULL((SELECT
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
		  ISNULL(assetamortization.amortizationquota,0),2))
FROM assetamortization
JOIN inventoryamortization
	ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
WHERE assetamortization.idasset = #inventory_list.idasset and
	assetamortization.idpiece = #inventory_list.idpiece
	AND (inventoryamortization.flag & 2 <> 0)
	AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
            (
	     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
             (((assetamortization.flag & 1 <> 1)) OR 
	      (assetamortization.idassetunload IS NOT NULL))
	     )
	    )
	-- AND assetamortization.adate BETWEEN @first_day_of_year AND @stop
), 0.0)
WHERE opkind = 3 and assetkind = 2 --scarico accessorio
	AND idasset IS NOT NULL

-------------------------------------------------------------------------------------------------
------ CARICHI ACCESSORI  DI BENI SCARICATI -----------------------------------------------------
-------------------------------------------------------------------------------------------------

UPDATE #inventory_list
SET var_unloaded_amount = ISNULL(var_unloaded_amount, 0.0) +
	ISNULL((SELECT 
	SUM(assetview_current.start)
FROM assetacquire as caricoaccessorio 
JOIN asset as accessorio				ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN  assetview_current					ON assetview_current.idasset=accessorio.idasset and assetview_current.idpiece=accessorio.idpiece
WHERE 
	accessorio.idpiece > 1 and
	accessorio.idasset = #inventory_list.idasset 
	AND (caricoaccessorio.idassetload IS NOT NULL )
	),0.0)
WHERE opkind = 3 and assetkind = 1  --scarico bene
	AND idasset IS NOT NULL

-------------------------------------------------------------------------------------------------
------ RIVALUTAZIONI DEGLI ACCESSORI DEI BENI SCARICATI -----------------------------------------
-------------------------------------------------------------------------------------------------

UPDATE #inventory_list
SET var_unloaded_amount = ISNULL(var_unloaded_amount, 0.0) +
	ISNULL((SELECT
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
	ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire as caricoaccessorio 
JOIN asset as accessorio				ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN assetamortization					ON assetamortization.idasset = accessorio.idasset AND assetamortization.idpiece = accessorio.idpiece
JOIN inventoryamortization				ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
WHERE accessorio.idasset = #inventory_list.idasset AND
	assetamortization.idpiece > 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
            (
	     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
             ((assetamortization.flag & 1 <> 1) OR 
	      (assetamortization.idassetunload IS NOT NULL))
	     )
	    )
	AND (caricoaccessorio.idassetload IS NOT NULL) 
	), 0.0)
WHERE opkind = 3 and assetkind = 1 --scarico bene
	AND idasset IS NOT NULL
	
-------------------------------------------------------------------------------------------------
------ SCARICHI ACCESSORI  DI BENI SCARICATI ----------------------------------------------------
-------------------------------------------------------------------------------------------------

UPDATE #inventory_list
SET var_unloaded_amount = ISNULL(var_unloaded_amount, 0.0) -
	ISNULL((SELECT SUM(assetview_current.start)
FROM assetacquire as caricoaccessorio 
JOIN asset as accessorio 
	ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN  assetview_current  
	ON assetview_current.idasset=accessorio.idasset and assetview_current.idpiece=accessorio.idpiece
WHERE 
	accessorio.idpiece > 1 AND
	accessorio.idasset = #inventory_list.idasset 
	AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 <> 1)) 
	),0.0)
WHERE opkind = 3 and assetkind = 1 --scarico bene
	AND idasset IS NOT NULL

-------------------------------------------------------------------------------------------------
------ RIVALUTAZIONI DEGLI ACCESSORI SCARICATI DEI BENI SCARICATI
-------------------------------------------------------------------------------------------------

UPDATE #inventory_list
SET var_unloaded_amount = ISNULL(var_unloaded_amount, 0.0) -
	ISNULL((SELECT
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
	ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire as caricoaccessorio 
JOIN asset as accessorio			ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN assetamortization				ON assetamortization.idasset = accessorio.idasset AND assetamortization.idpiece = accessorio.idpiece
JOIN inventoryamortization			ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
WHERE accessorio.idasset = #inventory_list.idasset AND
	assetamortization.idpiece > 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND ((ISNULL(assetamortization.amortizationquota,0)>0) OR 
            (
	     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
             ((assetamortization.flag & 1 <> 1) OR 
	      (assetamortization.idassetunload IS NOT NULL))
	     )
	    )
	AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 <> 1)) 
	), 0.0)
WHERE opkind = 3   and assetkind = 1 --scarico bene
	AND idasset IS NOT NULL


-------------------------------------------------------------------------------------
----- Rivalutazioni positive ufficiali (di BENI E DI ACCESSORI) ---------------------
-------------------------------------------------------------------------------------
INSERT INTO #asset_amortization(codeinv,valore)
SELECT
	inventorytree.codeinv,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetload	ON  assetamortization.idassetload = assetload.idassetload
LEFT OUTER JOIN assetunload	ON  asset.idassetunload= assetunload.idassetunload	
JOIN inventory				ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytree			ON inventorytree.idinv = assetacquire.idinv
WHERE 
	 (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota >= 0
	AND 
	(
		(
		 ((assetamortization.flag & 1 = 0)
		  AND assetamortization.adate BETWEEN @start AND @stop) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)
                   AND assetload.ratificationdate BETWEEN @start AND @stop)
		)
	)
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL )
	AND ((asset.idassetunload IS   NULL AND (asset.flag & 1 <> 0)) OR (ISNULL(assetunload.adate,{d '2079-06-06'})> @stop)) 
GROUP BY inventorytree.codeinv

-------------------------------------------------------------------------------------
-------- Rivalutazioni Negative ufficiali  (di BENI E DI ACCESSORI) -----------------
-------------------------------------------------------------------------------------
INSERT INTO #asset_amortization(codeinv,valore)
SELECT
	inventorytree.codeinv,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset							ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization				ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload			ON  assetamortization.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN assetunload AU		ON  asset.idassetunload= AU.idassetunload
JOIN inventory						ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization			ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytree					ON inventorytree.idinv = assetacquire.idinv
WHERE (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0 AND
	(
		(
		 ((assetamortization.flag & 1 = 0)
		  AND assetamortization.adate BETWEEN @start AND @stop) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)
                   AND assetunload.adate BETWEEN @start AND @stop)
		)
	)
AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL )
AND ((asset.idassetunload IS   NULL AND (asset.flag & 1 <> 0)) OR (ISNULL(assetunload.adate,{d '2079-06-06'}) > @stop)) 	
GROUP BY inventorytree.codeinv


--- LE SEGUENTI SEZIONI SERVONO PER ESEGUIRE  TEST DI QUADRATURA
--- CON LA STAMPA DEGLI AMMORTAMENTI E CORRISPONDONO AGLI AMMORTAMENTI 
--- E ALLE RIVALUTAZIONI DEI CESPITI/ACCESSORI SCARICATI NEL PERIODO 

--- LA SOMMA DI #asset_amortization_unload E #asset_amortization
--- NEL PERIODO 1 GENNAIO - 31 DICEMBRE DEVE ESSERE UGUALE AL TOTALE
--  FORNITO DALLA STAMPA DEL REGISTRO DEGLI AMMORTAMENTI.
--  LA PRESENTE STAMPA TUTTAVIA EVIDENZIERA' SOLO GLI AMMORTAMENTI
--  DEI BENI NON SCARICATI, IN QUANTO I RIMANENTI (#asset_amortization_unload) 
--  SONO INCLUSI NEL VALORE DI SCARICO
-------------------------------------------------------------------------------------
----- Rivalutazioni positive ufficiali (di BENI E DI ACCESSORI SCARICATI) -----------
-------------------------------------------------------------------------------------
/*
INSERT INTO #asset_amortization_unload(myid,valore)
SELECT
	inventorytreelink.idparent,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization
	ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetload
	ON  assetamortization.idassetload = assetload.idassetload
LEFT OUTER JOIN assetunload
	ON  asset.idassetunload= assetunload.idassetunload
	AND assetunload.adate BETWEEN @start AND @stop
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
WHERE inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota >= 0
	AND 
	(
		(
		 ((assetamortization.flag & 1 = 0)
		  AND assetamortization.adate BETWEEN @start AND @stop) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)
                   AND assetload.ratificationdate BETWEEN @start AND @stop)
		)
	)
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL )
	AND (asset.idassetunload IS  NOT  NULL OR (asset.flag & 1 <> 1))
GROUP BY inventorytreelink.idparent

-------------------------------------------------------------------------------------
-------- Rivalutazioni Negative ufficiali  (di BENI E DI ACCESSORI SCARICATI) -------
-------------------------------------------------------------------------------------
INSERT INTO #asset_amortization_unload(myid,valore)
SELECT
	inventorytreelink.idparent,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization
	ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload
	ON  assetamortization.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN assetunload AU
	ON  asset.idassetunload= AU.idassetunload
	AND assetunload.adate BETWEEN @start AND @stop
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
WHERE   inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0 AND
	(
		(
		 ((assetamortization.flag & 1 = 0)
		  AND assetamortization.adate BETWEEN @start AND @stop) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)
                   AND assetunload.adate BETWEEN @start AND @stop)
		)
	)
AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL )
AND (asset.idassetunload IS  NOT  NULL OR (asset.flag & 1 <> 1))
GROUP BY inventorytreelink.idparent


SELECT * FROM #asset_amortization
JOIN inventorytree ON #asset_amortization.myid = inventorytree.idinv

SELECT * FROM #asset_amortization_unload
JOIN inventorytree ON #asset_amortization_unload.myid = inventorytree.idinv

*/

------------------- da modificare-------------------------------
UPDATE #inventory_list
SET
location = (SELECT description FROM location WHERE idlocation = #inventory_list.idlocation),
manager = (SELECT title FROM manager WHERE idman = #inventory_list.idmanager),
inventorykind =
	(SELECT inventorykind.description 
	FROM inventorykind JOIN inventory ON inventorykind.idinventorykind = inventory.idinventorykind
	WHERE inventory.idinventory = @idinventory),
inventoryagency =
	(SELECT inventoryagency.description 
	FROM inventoryagency JOIN inventory ON inventoryagency.idinventoryagency = inventory.idinventoryagency
	WHERE inventory.idinventory = @idinventory)

UPDATE #inventory_list
	SET loadunloadmotive = (SELECT description FROM assetloadmotive	WHERE idmot = #inventory_list.idmot)
	WHERE opkind = 1 AND assetkind in (1,2) -- BETWEEN 1 AND 2 OPERAZIONI DI CARICO

UPDATE #inventory_list
	SET used =
	(SELECT
		CASE
			WHEN flag & 1 <> 0 THEN 'S'
			ELSE 'N'
		END
	FROM assetloadmotive WHERE idmot = #inventory_list.idmot)
	WHERE opkind = 1 AND assetkind in (1,2) -- BETWEEN 1 AND 2 OPERAZIONI DI CARICO

UPDATE #inventory_list
	SET loadunloadmotive = (SELECT description FROM assetunloadmotive WHERE idmot = #inventory_list.idmot)
	WHERE opkind = 3 AND assetkind in (1,2) --BETWEEN 3 AND 4 OPERAZIONI DI SCARICO

UPDATE #inventory_list SET number = 1 WHERE number IS NULL OR number = 0

INSERT INTO #total_inventory_list
SELECT #inventory_list.codeinv,
	isnull(SUM(loaded_amount),0.0) - isnull(SUM(unloaded_amount),0.0) - isnull(SUM(var_unloaded_amount), 0.0)
FROM #inventory_list
WHERE adate < @start 
GROUP BY #inventory_list.codeinv
ORDER BY #inventory_list.codeinv

--- Dobbiamo individuare il primo record su cu sarà valorizzata la consistenza iniziale ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- Prende la data operazione più vecchia
DECLARE @opdateini datetime
SELECT @opdateini = min(opdate)
FROM #inventory_list
WHERE adate BETWEEN @start AND @stop
AND codeinv LIKE @codeinv

-- Seleziona il primo tipo operazione prendendo il min. OpKind fra i record aventi:
-- Data Operazione = @opdateini
DECLARE @opkindini int
SELECT @opkindini = min(opkind)
FROM #inventory_list
WHERE opdate = @opdateini
	AND codeinv LIKE @codeinv

-- Seleziona il minimo numero operazione prendendo il min. numero operazione fra i record aventi:
-- data operazione = @opdateini AND Tipo Operazione = @opkindini
DECLARE @opnumber int
SELECT @opnumber = min(opnumber)
FROM #inventory_list
WHERE opdate = @opdateini
	AND codeinv LIKE @codeinv
	AND opkind = @opkindini 

-- Seleziona il minimo numero di inventario prendendo il min. numero di inventario fra i record aventi:
-- Data Operazione = @opdateini AND Tipo Operazione = @opkindini AND Numero operazione =  @opnumber
DECLARE @startninventory int
SELECT @startninventory = min(ninventory)
FROM #inventory_list
WHERE opdate = @opdateini
	AND opkind = @opkindini 
	AND opnumber = @opnumber
	AND codeinv LIKE @codeinv
			

-- Quindi fa l'UPDATE nella tabella #temp sul record con :
-- Data Operazione = @opdateini AND Numero operazione =  @opnumber AND  N. inventario = @startninventory AND Tipo Operazione = @opkindini
		
UPDATE #inventory_list
SET total_amount =
	ISNULL((SELECT SUM(total) 
	FROM #total_inventory_list 
	WHERE codeinv LIKE @codeinv),0)


-- Quindi fa l'UPDATE nella tabella ##inventory_list sul record con :
-- Data Operazione = @opdateini AND Numero operazione =  @opnumber AND  N. inventario = @startninventory AND Tipo Operazione = @opkindini
-- per valorizzare il totale ammortamenti dei beni ancora in carico
		
UPDATE #inventory_list
SET tot_amortization_loaded =
	ISNULL((SELECT SUM(valore) 
	FROM #asset_amortization 
	WHERE codeinv LIKE @codeinv),0)
	
	
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE @total_amount decimal(19,2)
DECLARE @tot_amortization_loaded decimal(19,2)
DECLARE @inventorykind varchar(45)
DECLARE @inventoryagency varchar(150)
-- se non ci sono righe in #inventory_list, vuol dire che non ci sono cespiti, aumenti, .... 
-- però può esserci la consistenza iniziale. Quindi se #inventory_list è vuota allora inserisco 
-- una riga con valori a null, tranne quelli significativi e l'importo della consistenza.
IF ((SELECT COUNT(*) FROM #inventory_list) = 0)
BEGIN
SET @total_amount =
	ISNULL((SELECT SUM(total) 
	FROM #total_inventory_list 
	WHERE codeinv LIKE @codeinv),0)
	
SET @tot_amortization_loaded =
	ISNULL((SELECT SUM(valore) 
	FROM #asset_amortization 
	WHERE codeinv LIKE @codeinv),0)
	
SET @inventorykind =
	(SELECT inventorykind.description 
	FROM inventorykind JOIN inventory ON inventorykind.idinventorykind = inventory.idinventorykind
	WHERE inventory.idinventory = @idinventory)
SET @inventoryagency =
	(SELECT inventoryagency.description 
	FROM inventoryagency JOIN inventory ON inventoryagency.idinventoryagency = inventory.idinventoryagency
	WHERE inventory.idinventory = @idinventory)

        INSERT INTO #inventory_list_1
        (
        	idinventory, inventorykind, inventoryagency, opdate, operation, opkind,
        	yassetload, nassetload, assetloaddate, codeinv, detailsdescr, loaded_amount,
        	unloaded_amount, var_unloaded_amount, loadunloadmotive, location,
        	manager, used, descinvtree, total_price, sign, idinv, startnumber, 
        	ninventory, number, total_amount, idpiece,tot_amortization_loaded
        )
        SELECT 
        	@idinventory, @inventorykind, @inventoryagency, NULL, NULL, NULL,
        	NULL, NULL, NULL, @codeinv, NULL, NULL,
              	NULL,NULL, NULL, NULL, NULL,NULL,NULL,NULL,
        	NULL, NULL, NULL, NULL, NULL,
        	@total_amount, NULL,@tot_amortization_loaded
END

INSERT INTO #inventory_list_1
(
	idinventory, inventorykind, inventoryagency, opdate, operation, opkind,opnumber,assetkind,
	yassetload, nassetload, assetloaddate, codeinv, detailsdescr, loaded_amount,
	unloaded_amount, var_unloaded_amount, loadunloadmotive, location,
	manager, used, descinvtree, total_price, sign, idinv, startnumber, 
	ninventory, number, total_amount, idpiece,tot_amortization_loaded
)
SELECT DISTINCT
	idinventory, inventorykind, inventoryagency, opdate, operation, opkind,opnumber,assetkind,
	yassetload, nassetload, assetloaddate, codeinv, detailsdescr, loaded_amount,
      	unloaded_amount = isnull(unloaded_amount,0.0)*number,
      	var_unloaded_amount, loadunloadmotive, location, manager,
	CASE used when 'S' then 'N' when 'N' then 'U' else '' END,
	descinvtree,
	total_price = isnull(loaded_amount, 0.0)*number,
	sign, idinv, startnumber, ninventory, number,
	total_amount = isnull(total_amount, 0.0), idpiece,
	tot_amortization_loaded = isnull(tot_amortization_loaded, 0.0)
	
FROM #inventory_list
WHERE opdate BETWEEN @start AND @stop
	AND codeinv LIKE @codeinv
	
 --select * from #total_inventory_list  
 --select * from #inventory_list
 --select * from #inventory_list_1


SELECT DISTINCT
	ninventory, idinventory, @inventory as inventory, inventorykind,	inventoryagency,
   	opdate,	operation, opkind,opnumber,assetkind,
  	yassetload, nassetload, assetloaddate, codeinv, detailsdescr,
	loaded_amount, unloaded_amount, var_unloaded_amount,
	loadunloadmotive, location, manager, used, descinvtree,
	total_price, sign, idinv, startnumber, number,total_amount, idpiece,
	tot_amortization_loaded
FROM #inventory_list_1
ORDER BY opdate, opkind, opnumber, startnumber,assetkind

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
