
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_inventorytree]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_inventorytree]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--  exec show_inventorytree  {ts '2007-08-20 00:00:00'},'0001',2007

CREATE  PROCEDURE [show_inventorytree]
@date 	datetime,
@idinv 	int,
@ayear 	int
AS
BEGIN

DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@ayear), 105)

DECLARE @inventorytree varchar(150)
DECLARE @codeinv varchar(50)
DECLARE	@nlevel tinyint

SELECT @codeinv = codeinv, @inventorytree = description, @nlevel = nlevel
FROM inventorytree WHERE idinv = @idinv

DECLARE	@departmentname varchar(150)
SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')

CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
INSERT INTO #situation VALUES ('Classificazione ' + @codeinv, NULL, 'H')
INSERT INTO #situation VALUES (@inventorytree, NULL, 'H')
INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4), @ayear), NULL, 'H')
INSERT INTO #situation VALUES ('', NULL, 'N')

DECLARE @levelusable tinyint -- Livello operativo per le voci di classificazione inventariale
SELECT @levelusable = MIN(nlevel) FROM inventorysortinglevel WHERE flag & 2 <> 0

DECLARE @initialresource decimal(19,2)
SELECT @initialresource =
ISNULL(
	(SELECT SUM(D.amount)
	FROM assetvardetail D
	JOIN assetvar V
		ON V.idassetvar = D.idassetvar
	JOIN inventorytreelink L
		ON L.idchild = D.idinv
	JOIN inventorytree I
		ON I.idinv = D.idinv
	WHERE ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
		AND V.yvar = @ayear
		AND V.flag & 1 <> 1
		AND V.adate <= @date)
,0)

INSERT INTO #situation VALUES ('Consistenza iniziale', @initialresource, 'S')

DECLARE @var_A decimal(19,2)
SELECT  @var_A =
ISNULL(
	(SELECT SUM(D.amount)
	FROM assetvardetail D
	JOIN assetvar V
		ON V.idassetvar = D.idassetvar
	JOIN inventorytreelink L
		ON L.idchild = D.idinv
	JOIN inventorytree I
		ON I.idinv = D.idinv
	WHERE ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
		AND V.yvar = @ayear
		AND V.flag & 1 <> 0
		AND V.adate <= @date
		AND D.amount > 0)
,0)

INSERT INTO #situation VALUES ('Variazioni in aumento della situazione patrimoniale', @var_A, '')

DECLARE @assetacquire decimal(19,2)	
-----   Considera i buoni di carico precedenti al 2005 -----
SELECT  @assetacquire =  ISNULL(SUM(
		ROUND(ISNULL(assetacquire.taxable, 0)
		* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
		+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
		- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)),0)
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN inventory  
	ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind
	ON inventory.idinventorykind = inventorykind.idinventorykind   
JOIN inventorytreelink L
	ON L.idchild = assetacquire.idinv
WHERE asset.idpiece = 1
	AND ((L.nlevel = @nlevel AND L.idparent = @idinv ) OR (@idinv IS NULL AND L.nlevel = @levelusable))
	AND (assetload.yassetload < 2005 OR (inventorykind.flag & 1 <> 0))
	AND assetload.yassetload = @ayear
	AND assetload.ratificationdate BETWEEN @firstday AND @date

print @assetacquire
-- Considera i buoni di carico del 2005 e i successivi  SENZA SCONTO
SELECT  @assetacquire = ISNULL (@assetacquire,0) + ISNULL(SUM(
			ISNULL(assetacquire.taxable, 0)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)),0)
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN inventory  
	ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind
	ON inventory.idinventorykind = inventorykind.idinventorykind
JOIN inventorytreelink L
	ON L.idchild = assetacquire.idinv
WHERE asset.idpiece = 1
	AND ((L.nlevel = @nlevel AND L.idparent = @idinv ) OR (@idinv IS NULL AND L.nlevel = @levelusable))
	AND (assetload.yassetload >= 2005 AND (inventorykind.flag & 1 <> 1))
	AND assetload.yassetload = @ayear
	AND assetload.ratificationdate BETWEEN @firstday AND @date

print @assetacquire
INSERT INTO #situation VALUES ('Cespiti caricati e pagati nell''esercizio corrente', @assetacquire, '')

-----   Considera i buoni di carico precedenti al 2005 -----
DECLARE @assetacquire_previous decimal(19,2)
SELECT  @assetacquire_previous = ISNULL(SUM(
		ROUND(ISNULL(assetacquire.taxable, 0)
		* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
		+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
		- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)),0)
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN inventory  
	ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind
	ON inventory.idinventorykind = inventorykind.idinventorykind   
JOIN inventorytreelink L
	ON L.idchild = assetacquire.idinv
WHERE asset.idpiece = 1
	AND ((L.nlevel = @nlevel AND L.idparent = @idinv ) OR (@idinv IS NULL AND L.nlevel = @levelusable))
	AND (assetload.yassetload < 2005 OR (inventorykind.flag & 1 <> 0))
	AND assetload.yassetload < @ayear
	AND assetload.ratificationdate BETWEEN @date AND @firstday 

print @assetacquire_previous
-- Considera i buoni di carico del 2005 e i successivi  SENZA SCONTO
SELECT  @assetacquire_previous =
			ISNULL (@assetacquire_previous,0) + ISNULL(SUM(
			ISNULL(assetacquire.taxable, 0)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)),0)
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN inventory  
	ON assetacquire.idinventory=inventory.idinventory
JOIN inventorykind
	ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventorytreelink L
	ON L.idchild = assetacquire.idinv
WHERE asset.idpiece = 1
	AND ((L.nlevel = @nlevel AND L.idparent = @idinv ) OR (@idinv IS NULL AND L.nlevel = @levelusable))
	AND (assetload.yassetload >= 2005 AND (inventorykind.flag & 1 <> 1))
	AND assetload.yassetload < @ayear
	AND assetload.ratificationdate BETWEEN @firstday AND @date

INSERT  INTO #situation VALUES ('Cespiti caricati in esercizi precedenti e pagati nell''esercizio corrente', @assetacquire_previous, '')

DECLARE @pieceacquire decimal(19,2)
SELECT  @pieceacquire = ISNULL(SUM(
			ROUND(ISNULL(pieceacquire.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(pieceacquire.discount, 0))),2)
			+ ROUND(ISNULL(pieceacquire.tax,0)/pieceacquire.number,2)
			- ROUND(ISNULL(pieceacquire.abatable,0)/pieceacquire.number,2)),0)
FROM assetacquire as pieceacquire
JOIN asset as piece
	ON pieceacquire.nassetacquire = piece.nassetacquire
JOIN asset 
	ON piece.idasset = asset.idasset
JOIN assetload as pieceload
	ON pieceload.idassetload = pieceacquire.idassetload
JOIN inventorytreelink L
	ON L.idchild = pieceacquire.idinv
WHERE piece.idpiece>1 and asset.idpiece = 1
	AND ((L.nlevel = @nlevel AND L.idparent = @idinv ) OR (@idinv IS NULL AND L.nlevel = @levelusable))
	AND pieceload.yassetload = @ayear
	AND pieceload.ratificationdate BETWEEN @firstday AND @date

INSERT INTO #situation VALUES ('Accessori caricati e pagati nell''esercizio corrente', @pieceacquire, '')

DECLARE @pieceacquire_previous decimal(19,2)
SELECT  @pieceacquire_previous =
			ISNULL(SUM(
			ROUND(ISNULL(pieceacquire.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(pieceacquire.discount, 0))),2)
			+ ROUND(ISNULL(pieceacquire.tax,0) / pieceacquire.number,2)
			- ROUND(ISNULL(pieceacquire.abatable,0) / pieceacquire.number,2)),0)
FROM assetacquire as pieceacquire
JOIN asset as piece
	ON pieceacquire.nassetacquire = piece.nassetacquire
JOIN asset 
	ON piece.idasset = asset.idasset
JOIN assetload as pieceload
	ON pieceload.idassetload = pieceacquire.idassetload
JOIN inventorytreelink L
	ON L.idchild = pieceacquire.idinv
WHERE piece.idpiece >1 and asset.idpiece = 1
	AND ((L.nlevel = @nlevel AND L.idparent = @idinv ) OR (@idinv IS NULL AND L.nlevel = @levelusable))
	AND pieceload.yassetload < @ayear
	AND pieceload.ratificationdate BETWEEN @firstday AND @date

INSERT INTO #situation VALUES ('Accessori caricati in esercizi precedenti e pagati nell''esercizio corrente', @pieceacquire_previous, '')

-- INSERIAMO LE RIVALUTAZIONI POSITIVE UFFICIALI DI BENI E 
-- ACCESSORI CARICATI  (maria)

DECLARE @positive_amortization  decimal(19,2)
SELECT  @positive_amortization = 
	ISNULL(SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),0)
	FROM assetacquire
	JOIN assetload
		ON assetload.idassetload = assetacquire.idassetload
	JOIN asset
		ON assetacquire.nassetacquire = asset.nassetacquire
	JOIN assetamortization
		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
	JOIN inventory
		ON inventory.idinventory = assetacquire.idinventory
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	JOIN inventorytreelink L
		ON L.idchild = assetacquire.idinv
	WHERE  
		((assetacquire.flag & 1 = 0) OR assetload.yassetload IS NOT NULL)
		AND (inventoryamortization.flag & 2 <> 0)
		AND assetamortization.amortizationquota >= 0
		AND assetamortization.adate BETWEEN @firstday AND @date
		AND ((L.nlevel = @nlevel AND L.idparent = @idinv ) OR (@idinv IS NULL AND L.nlevel = @levelusable))
	
INSERT INTO #situation VALUES ('Rivalutazioni positive ufficiali di Cespiti e Accessori Caricati', @positive_amortization, '') --maria

DECLARE @resource_A decimal(19,2)
SELECT  @resource_A = 
	ISNULL(@var_A, 0) + 
	ISNULL(@assetacquire, 0) + 
	ISNULL(@assetacquire_previous, 0) +
	ISNULL(@pieceacquire, 0) + 
	ISNULL(@pieceacquire_previous, 0) +
	ISNULL(@positive_amortization, 0) -- maria (le includo nella consistenza patrimoniale)

INSERT INTO #situation VALUES ('Totale aumenti della consistenza patrimoniale', @resource_A, 'S')

DECLARE @var_R decimal(19,2)
SELECT  @var_R =
-ISNULL(
	(SELECT SUM(D.amount)
	FROM assetvardetail D
	JOIN assetvar V
		ON V.idassetvar = D.idassetvar
	JOIN inventorytreelink L
		ON L.idchild = D.idinv
	JOIN inventorytree I
		ON I.idinv = D.idinv
	WHERE ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
		AND V.yvar = @ayear
		AND V.flag & 1 <> 0
		AND V.adate <= @date
		AND D.amount < 0)
,0)

INSERT INTO #situation VALUES ('Variazioni in diminuzione della situazione patrimoniale', @var_R, '')

DECLARE @pieceunload decimal(19,2)		
SELECT  @pieceunload =
	ISNULL(SUM(
		ROUND(ISNULL(pieceacquire.taxable, 0)
		* (1 - CONVERT(decimal(19,6),ISNULL(pieceacquire.discount, 0))),2)
		+ ROUND(ISNULL(pieceacquire.tax,0) / pieceacquire.number,2)
		- ROUND(ISNULL(pieceacquire.abatable,0) / pieceacquire.number,2)),0)
FROM assetacquire as pieceacquire
JOIN asset as piece 
	ON pieceacquire.nassetacquire = piece.nassetacquire
JOIN asset 
	ON piece.idasset = asset.idasset
JOIN assetacquire 
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetunload as pieceunload
	ON  pieceunload.idassetunload = piece.idassetunload
JOIN inventorytreelink L
	ON L.idchild = pieceacquire.idinv
WHERE piece.idpiece > 1 AND asset.idpiece = 1
	AND ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
	AND pieceunload.yassetunload = @ayear
	AND pieceunload.adate BETWEEN @firstday AND @date

INSERT INTO #situation VALUES ('Accessori scaricati nell''esercizio', @pieceunload, '')

DECLARE @assetunload decimal(19,2)

SELECT  @assetunload =
	ISNULL(SUM(
	ROUND(ISNULL(assetacquire.taxable, 0)
	* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
	+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
	- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)),0)
FROM assetacquire
LEFT OUTER JOIN assetload
	ON assetacquire.idassetload = assetload.idassetload
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetunload
	ON assetunload.idassetunload = asset.idassetunload
JOIN inventory  
	ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind
	ON inventory.idinventorykind = inventorykind.idinventorykind   
JOIN inventorytreelink L
	ON L.idchild = assetacquire.idinv
WHERE asset.idpiece = 1 
	AND ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
	AND assetunload.yassetunload = @ayear
	AND assetunload.adate BETWEEN @firstday AND @date
	AND (ISNULL(assetload.yassetload,2006)<2005 OR 
	           (assetacquire.idassetload IS NULL AND 
                    (assetacquire.flag & 2 <> 0))OR 
		    (inventorykind.flag & 1 <> 0))

SELECT  @assetunload = 
	ISNULL(@assetunload,0) + 
	ISNULL(SUM(
	ISNULL(assetacquire.taxable, 0)
	+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
	- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)),0)
FROM assetacquire
LEFT OUTER JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
JOIN asset 
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetunload 
	ON  assetunload.idassetunload = asset.idassetunload
JOIN inventory  
	ON assetacquire.idinventory=inventory.idinventory
JOIN inventorykind
	ON inventory.idinventorykind = inventorykind.idinventorykind 
JOIN inventorytreelink L
	ON L.idchild = assetacquire.idinv
WHERE ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
	AND assetunload.yassetunload = @ayear
	AND assetunload.adate BETWEEN @firstday AND @date
	AND asset.idpiece = 1
	AND NOT
	(ISNULL(assetload.yassetload, 2006) < 2005 OR 
	(assetacquire.idassetload IS NULL AND (assetacquire.flag & 2 <> 0)) 
	OR (inventorykind.flag & 1 <> 0))

INSERT INTO #situation VALUES ('Cespiti scaricati nell''esercizio', @assetunload, '')

-- Carichi accessori di beni scaricati
DECLARE @pieceload_unloaded decimal(19,2)
SELECT  @pieceload_unloaded = 
	ISNULL(SUM(
		ROUND(ISNULL(assetacquire.taxable, 0)
		* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
		+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
		- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)),0)
FROM assetacquire 
JOIN asset as accessorio 
	ON assetacquire.nassetacquire = accessorio.nassetacquire
JOIN asset as cespite
	ON cespite.idasset = accessorio.idasset
JOIN assetunload
	ON assetunload.idassetunload = cespite.idassetunload
JOIN inventory
	ON assetacquire.idinventory = inventory.idinventory
JOIN inventorytreelink L
	ON L.idchild = assetacquire.idinv
WHERE ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
	AND accessorio.idpiece > 1 
	AND cespite.idpiece = 1
	AND (assetacquire.idassetload IS NOT NULL)
	AND assetunload.yassetunload <= @ayear
	AND assetunload.adate BETWEEN @firstday AND @date

INSERT INTO #situation VALUES ('Carichi Accessori di Cespiti scaricati', @pieceload_unloaded, '')

-------------------------------------------------------------------------------------
--RIVALUTAZIONI POSITIVE di Accessori di beni scaricati -----------------------------
-------------------------------------------------------------------------------------

DECLARE @positive_amortization_pieces_asset_unloaded decimal(19,2)
SELECT  @positive_amortization_pieces_asset_unloaded = 
		ISNULL(SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),0)
FROM assetacquire as caricoaccessorio
JOIN asset as accessorio 
 ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN asset as cespite
 ON cespite.idasset = accessorio.idasset
JOIN assetunload as scaricocespite
 ON scaricocespite.idassetunload = cespite.idassetunload
JOIN inventory
 ON caricoaccessorio.idinventory = inventory.idinventory
JOIN assetamortization
 ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
JOIN inventoryamortization
 ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink L
 ON L.idchild = caricoaccessorio.idinv
WHERE ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable)) 
 AND accessorio.idpiece>1 AND cespite.idpiece =1
 AND (caricoaccessorio.idassetload IS NOT NULL) 
 AND (inventoryamortization.flag & 2 <> 0)
 AND assetamortization.amortizationquota >=0
 AND scaricocespite.yassetunload <= @ayear
 AND scaricocespite.adate BETWEEN @firstday AND @date

INSERT INTO #situation VALUES ('Rivalutazioni positive ufficiali  di Accessori di Cespiti Scaricati', @positive_amortization_pieces_asset_unloaded, '')


--------------------------------------------------------------------------------------------
--RIVALUTAZIONI NEGATIVE di  Accessori di beni scaricati ----------------------------------- 
------------------(da collegare a Carichi accessori di beni scaricati) ---------------------
--------------------------------------------------------------------------------------------
DECLARE @negative_amortization_pieces_asset_unloaded decimal(19,2)
SELECT  @negative_amortization_pieces_asset_unloaded = 
		- ISNULL(SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),0)
FROM assetacquire as caricoaccessorio
JOIN asset as accessorio 
 ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
JOIN asset as cespite
 ON cespite.idasset = accessorio.idasset
JOIN assetunload as scaricocespite
 ON scaricocespite.idassetunload = cespite.idassetunload
JOIN inventory
 ON caricoaccessorio.idinventory = inventory.idinventory
JOIN assetamortization
 ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
JOIN inventoryamortization
 ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink L
 ON L.idchild = caricoaccessorio.idinv
WHERE ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable)) 
 AND accessorio.idpiece>1 AND cespite.idpiece = 1
 AND (caricoaccessorio.idassetload IS NOT NULL) 
 AND 
 (
     (assetamortization.flag & 1 <> 1) OR 
     (assetamortization.idassetunload IS NOT NULL)
 )
 AND (inventoryamortization.flag & 2 <> 0)
 AND assetamortization.amortizationquota < 0
 AND scaricocespite.yassetunload <= @ayear
 AND scaricocespite.adate BETWEEN @firstday AND @date

INSERT INTO #situation VALUES ('Rivalutazioni negative ufficiali  di Accessori di Cespiti Scaricati', @negative_amortization_pieces_asset_unloaded, '')

-- Rivalutazioni positive ufficiali di BENI E ACCESSORI scaricati --
DECLARE @positive_amortization_unload decimal(19,2)

SELECT  @positive_amortization_unload = 
	ISNULL(SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),0)
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetunload
	ON assetunload.idassetunload = asset.idassetunload
JOIN assetamortization
	ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink L
	ON L.idchild = assetacquire.idinv
WHERE ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota >= 0
	AND assetunload.adate BETWEEN @firstday AND @date


INSERT INTO #situation VALUES ('Rivalutazioni positive ufficiali di Cespiti e Accessori Scaricati', @positive_amortization_unload, '') --maria
	
DECLARE @negative_amortization_unload decimal(19,2)

SELECT  @negative_amortization_unload = 
	-ISNULL(SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),0)
FROM assetacquire
JOIN asset
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetunload
	ON assetunload.idassetunload = asset.idassetunload
JOIN assetamortization
	ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink L
	ON L.idchild = assetacquire.idinv
WHERE  
	((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
	AND
	(
	    (assetamortization.flag & 1 = 0) OR 
	    (assetamortization.idassetunload IS NOT NULL)
	)
	AND (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0
	AND assetunload.adate BETWEEN @firstday AND @date 

INSERT INTO #situation VALUES ('Rivalutazioni negative ufficiali di Cespiti e Accessori Scaricati', @negative_amortization_unload, '') --maria

-----------------------------------------
-- Scarico Accessori di beni scaricati --
-----------------------------------------
DECLARE @pieceunload_unloaded decimal (19,2)

SELECT  @pieceunload_unloaded = 
			ISNULL(SUM(
			ROUND(ISNULL(assetacquire.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2)),0)
FROM assetacquire 
	JOIN asset as accessorio 
		ON assetacquire.nassetacquire = accessorio.nassetacquire
	JOIN asset as cespite
		ON cespite.idasset = accessorio.idasset
	JOIN assetunload as scaricocespite
		ON scaricocespite.idassetunload = cespite.idassetunload
	JOIN inventory
 		ON assetacquire.idinventory = inventory.idinventory
	JOIN inventorytreelink L
		ON L.idchild = assetacquire.idinv
	WHERE 	accessorio.idpiece>1 	and cespite.idpiece =1 
		AND ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
		AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 <> 1)) 
		AND scaricocespite.yassetunload <= @ayear
		AND scaricocespite.adate BETWEEN @firstday AND @date

INSERT INTO #situation VALUES ('Scarichi Accessori di Cespiti Scaricati', @pieceunload_unloaded, '') --maria

------- RIVALUTAZIONI POSITIVE di Accessori SCARICATI di beni scaricati -------------  
DECLARE @positive_pieceamortization_unloaded decimal (19,2)

SELECT  @positive_pieceamortization_unloaded =		
		ISNULL(SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),0)
	FROM assetacquire 
	JOIN asset as accessorio 
		ON assetacquire.nassetacquire = accessorio.nassetacquire
	JOIN asset as cespite
		ON cespite.idasset = accessorio.idasset
	JOIN assetunload as scaricocespite
		ON scaricocespite.idassetunload = cespite.idassetunload
	JOIN inventory
 		ON assetacquire.idinventory = inventory.idinventory
	JOIN assetamortization
		ON  assetamortization.idasset = accessorio.idasset 
		AND assetamortization.idpiece = accessorio.idpiece
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	JOIN inventorytreelink L
		ON L.idchild = assetacquire.idinv
	WHERE 	accessorio.idpiece>1 AND cespite.idpiece =1
		AND ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
		AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 = 0)) 
		AND (inventoryamortization.flag & 2 = 0)
		AND assetamortization.amortizationquota >=0
		AND scaricocespite.yassetunload <= @ayear
		AND scaricocespite.adate BETWEEN @firstday AND @date

INSERT INTO #situation VALUES ('Rivalutazioni Positive di Accessori Scaricati di Cespiti Scaricati', @positive_pieceamortization_unloaded, '') --maria

-- RIVALUTAZIONI NEGATIVE di Accessori SCARICATI di beni scaricati -------------
DECLARE @negative_pieceamortization_unloaded decimal (19,2)
SELECT  @negative_pieceamortization_unloaded =	
		-ISNULL(SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2)),0)
	FROM assetacquire 
	JOIN asset as accessorio 
		ON assetacquire.nassetacquire = accessorio.nassetacquire
	JOIN asset as cespite
		ON cespite.idasset = accessorio.idasset
	JOIN assetunload as scaricocespite
		ON scaricocespite.idassetunload = cespite.idassetunload
	JOIN inventory
		ON assetacquire.idinventory = inventory.idinventory
	JOIN assetamortization
		ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	JOIN inventorytreelink L
		ON L.idchild = assetacquire.idinv
	WHERE 	accessorio.idpiece>1 and cespite.idpiece =1
		AND ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
		AND
		(
		    (assetamortization.flag & 1 <> 0) OR 
		    (assetamortization.idassetunload IS NOT NULL)
		)
		AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 = 0)) 
		AND (inventoryamortization.flag & 2 <> 0)
		AND assetamortization.amortizationquota < 0
		AND scaricocespite.yassetunload <= @ayear
		AND scaricocespite.adate BETWEEN @firstday AND @date

INSERT INTO #situation VALUES ('Rivalutazioni Negative di Accessori Scaricati di Cespiti Scaricati', @negative_pieceamortization_unloaded, '') --maria

DECLARE @resource_R decimal(19,2)
SELECT  @resource_R = 
	ISNULL(@var_R, 0) + 	
	ISNULL(@pieceunload, 0) + 
	ISNULL(@assetunload, 0) +
	ISNULL(@pieceload_unloaded, 0) +
	ISNULL(@positive_amortization_pieces_asset_unloaded,0) -
	ISNULL(@negative_amortization_pieces_asset_unloaded,0) +
	ISNULL(@positive_amortization_unload, 0) -
	ISNULL(@negative_amortization_unload, 0) -
	ISNULL(@pieceunload_unloaded, 0) -
	ISNULL(@positive_pieceamortization_unloaded, 0) +
	ISNULL(@negative_pieceamortization_unloaded, 0)

INSERT INTO #situation VALUES ('Totale diminuzioni della consistenza patrimoniale', @resource_R, 'S')

-- Considero le rivalutazioni negative ufficiali di beni e accessori caricati
DECLARE @negative_amortization  decimal(19,2)
SELECT  @negative_amortization = 
	- ISNULL(SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
	ISNULL(assetamortization.amortizationquota,0),2)),0)
	FROM assetacquire
	JOIN asset
		ON assetacquire.nassetacquire = asset.nassetacquire
	JOIN assetamortization
		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
	LEFT OUTER JOIN assetunload
		ON  assetamortization.idassetunload = assetunload.idassetunload
	JOIN inventoryamortization
		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	JOIN inventorytreelink L
		ON L.idchild = assetacquire.idinv
	WHERE 
		((assetacquire.flag & 1 = 0) OR assetacquire.idassetload IS NOT NULL)
		AND (inventoryamortization.flag & 2 <> 0)
		AND assetamortization.amortizationquota < 0 
		AND DATEPART(YEAR, assetamortization.adate) = @ayear
		AND
		(
			(
			 ((assetamortization.flag & 1 = 0)
			  AND assetamortization.adate BETWEEN @firstday AND @date) 
			  OR 
			  ((assetamortization.flag & 1 <> 0)
	                   AND assetunload.adate BETWEEN @firstday AND @date)
			)
		 )
		AND ((L.nlevel = @nlevel AND L.idparent = @idinv) OR (@idinv is null AND L.nlevel = @levelusable))
	
INSERT INTO #situation VALUES ('Ammortamenti', @negative_amortization, 'S') 

DECLARE @finalresource decimal(19,2)
SELECT  @finalresource = 
	ISNULL(@initialresource, 0) +
	ISNULL(@resource_A, 0) -
	ISNULL(@resource_R, 0) -
	ISNULL(@negative_amortization,0)
INSERT INTO #situation VALUES ('Consistenza finale', @finalresource, 'S')
INSERT INTO #situation VALUES('',NULL,'N')

SELECT value, amount, kind FROM #situation
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

