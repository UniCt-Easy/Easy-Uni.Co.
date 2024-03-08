
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitpatrim_generale_dettaglio_con_immobilizzazione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitpatrim_generale_dettaglio_con_immobilizzazione]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
CREATE   PROCEDURE rpt_sitpatrim_generale_dettaglio_con_immobilizzazione
	@year int,
	@codinventoryagency int =null,
	@date datetime=null,	
	@showmotive char(1)='N',
	@idinventory int

AS BEGIN
-- setuser 'amministrazione'
-- exec [rpt_sitpatrim_generale_dettaglio_con_immobilizzazione] 2017, null, '2017-04-27', 'N',  null

DECLARE @firstday datetime

declare @idaccountkind_imm varchar(20)
set @idaccountkind_imm='0005' --immobilizzazione

declare @idaccountkind_fon varchar(20)
set @idaccountkind_fon='0008' --fondo ammortamento

SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)
if (@date is null) SET @date = CONVERT(datetime, '31-12-' + CONVERT(char(4),@year), 105)

-- Crea la tabella temporanea #assetloadmotive e la riempie
CREATE TABLE #assetloadmotive
(
idmot  int,
codemot varchar(20),
description  varchar(50)
)
INSERT INTO #assetloadmotive
(idmot, codemot, description)
SELECT idmot, codemot, description
FROM assetloadmotive
UNION
SELECT
null, null,null

-- Crea la tabella temporanea #patrimonio 
CREATE TABLE #patrimonio
(
	idinventoryagency int,
	idinv int,
	description varchar(150),
	initial_amount decimal(19,2), --somma valore iniziale  di tutti i cespiti e accessori sino all'anno precedente e non scaricati sino all'anno scorso
	final_amount decimal(19,2), 
	idmot int,
	var_aum decimal(19,2),   -- carichi di quest'anno
	var_dim decimal(19,2),	 -- scarichi di quest'anno

	-- Rivalutazioni Positive e Negative ufficiali  (di BENI E DI ACCESSORI) sino all'anno scorso, di cespiti non ancora scaricati nell'anno attuale
	-- COLONNA 5  "Ammortamenti pregressi di cespiti in carico nel "
	ammortization_pre_in_carico decimal(19,2),  


	-- Rivalutazioni Positive e Negative ufficiali  (di BENI E DI ACCESSORI) sino all'anno scorso purch? RISULTINO SCARICATI IN QUEST'ANNO
	-- COLONNA 6 "Ammortamenti pregressi di cespiti scaricati nel " 
	ammortization_pre_scaricati decimal(19,2),
	

	-- Rivalutazioni Positive e Negative ufficiali  (di BENI E DI ACCESSORI) di QUESTO ANNO, di cespiti non ancora scaricati nell'anno attuale
	-- COLONNA 8
	ammortization_post decimal(19,2)

			
	
)

-------------------------------------------------------------------------------------
-------------------------- Situazione patrim. iniziale-------------------------------
-------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------------------
---------------- COLONNA 1 Carichi cespite E accessori  DI ANNI PRECEDENTI ANCORA IN CARICO l'anno prec. -----------------
----- "Consistenza iniziale storica"  
---------------------------------------------------------------------------------------------------------------------------
INSERT INTO #patrimonio(idinventoryagency,idinv,idmot,initial_amount)
SELECT 	inventory.idinventoryagency,	inventorytreelink.idparent,	assetacquire.idmot,	SUM(AC.start)
FROM assetacquire 
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC	on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetload				ON assetload.idassetload = assetacquire.idassetload
JOIN inventory				ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind			ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventorytreelink		ON inventorytreelink.idchild = assetacquire.idinv
LEFT OUTER JOIN assetunload AU	ON  asset.idassetunload = AU.idassetunload

WHERE 
	--inventorytreelink.nlevel = 1
	--AND 
	assetload.ratificationdate < @firstday 
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL)	
	AND ( (inventorykind.flag&2)=0) --inventario visibile
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
	AND (AU.adate is null or AU.adate >= @firstday )  ---cespite ancora in carico l'anno scorso

GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot
	

-------------------------------------------------------------------------------------
--------- COLONNA 2  Carichi cespite E accessori di quest'anno  ---------------------
-------------------------------------------------------------------------------------
INSERT INTO #patrimonio(idinventoryagency,idinv,idmot,var_aum)
SELECT 	inventory.idinventoryagency,	inventorytreelink.idparent,	assetacquire.idmot,	SUM(AC.start)
FROM assetacquire 
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC	on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetload				ON assetload.idassetload = assetacquire.idassetload
JOIN inventory				ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind			ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventorytreelink		ON inventorytreelink.idchild = assetacquire.idinv
WHERE 
	--inventorytreelink.nlevel = 1
	--AND
	 assetload.ratificationdate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL)	
	AND ( (inventorykind.flag&2)=0)
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot
	
------------------------------------------------------------------------------------
------- COLONNA 3  Scarichi Cespite E accessori  DI QUESTO ANNO --------------------
------------------------------------------------------------------------------------
INSERT INTO #patrimonio(idinventoryagency,idinv,idmot,var_dim)
SELECT
	inventory.idinventoryagency,inventorytreelink.idparent, 	assetacquire.idmot,	SUM(AC.start)
FROM assetacquire
JOIN asset								ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC				on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetunload						ON assetunload.idassetunload = asset.idassetunload
JOIN inventory							ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind						ON inventory.idinventorykind= inventorykind.idinventorykind   
JOIN inventorytreelink					ON inventorytreelink.idchild = assetacquire.idinv
WHERE  
--inventorytreelink.nlevel = 1
	--AND 
	assetunload.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )	
	AND ( (inventorykind.flag&2)=0)
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent,assetacquire.idmot

---------------------------------------------------------------------------------------------------------------------------
---------------- COLONNA 4 Carichi cespite E accessori  ANCORA IN CARICO -------------------------------
-------  "Consistenza finale storica" 
---------------------------------------------------------------------------------------------------------------------------
INSERT INTO #patrimonio(idinventoryagency,idinv,idmot,final_amount)
SELECT 	inventory.idinventoryagency,	inventorytreelink.idparent,	assetacquire.idmot,	SUM(AC.start)
FROM assetacquire 
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC	on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetload				ON assetload.idassetload = assetacquire.idassetload
JOIN inventory				ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind			ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventorytreelink		ON inventorytreelink.idchild = assetacquire.idinv
LEFT OUTER JOIN assetunload AU	ON  asset.idassetunload = AU.idassetunload

WHERE 
	--inventorytreelink.nlevel = 1
	--AND
	 assetload.ratificationdate <= @date 
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL)	
	AND ( (inventorykind.flag&2)=0) --inventario visibile
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
	AND (AU.adate is null or AU.adate >@date)  ---cespite non ancora scaricato quest'anno

GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot

-------------------------------------------------------------------------------------
------ COLONNA 5 "Ammortamenti pregressi di cespiti in carico nel "
------ Ammortamenti PREGRESSI di cespiti ancora in carico nell'anno corrente
-------------------------------------------------------------------------------------

---Ammortamenti 
INSERT INTO #patrimonio(idinventoryagency,idinv,idmot,ammortization_pre_in_carico)
SELECT 	inventory.idinventoryagency,inventorytreelink.idparent, assetacquire.idmot,
	-SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload	ON  assetamortization.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN assetunload AU	ON  asset.idassetunload = AU.idassetunload
JOIN inventory					ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind				ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink			ON inventorytreelink.idchild = assetacquire.idinv
WHERE  
	--inventorytreelink.nlevel = 1
	--AND 
	(inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0  AND
	(
		(
		 ((assetamortization.flag & 1 = 0)	  AND assetamortization.adate < @firstday ) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)  AND assetunload.adate < @firstday)
		)
	)
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
	AND (AU.adate is null or AU.adate >@date)  ---cespite non ancora scaricato quest'anno
	AND ( (inventorykind.flag&2)=0)
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
	--AND (inventoryamortization.flag &8) <> 0 -- Considera solo i tipo ammortamento : Ammortamento
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot

--Rivalutazioni
INSERT INTO #patrimonio(idinventoryagency,idinv,idmot,ammortization_pre_in_carico)
SELECT 	inventory.idinventoryagency,	inventorytreelink.idparent,	assetacquire.idmot,
	-SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetload		ON  assetamortization.idassetload = assetload.idassetload
LEFT OUTER JOIN assetunload AU	ON  asset.idassetunload = AU.idassetunload
JOIN inventory					ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind				ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink			ON inventorytreelink.idchild = assetacquire.idinv
WHERE  
	--inventorytreelink.nlevel = 1
	--AND 
	(inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota > 0  AND
	(
		(
		 ((assetamortization.flag & 1 = 0)  AND assetamortization.adate < @firstday) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)AND assetload.ratificationdate < @firstday)
		)
	)
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
	AND (AU.adate is null or AU.adate >@date)  ---cespite non ancora scaricato quest'anno
	AND ( (inventorykind.flag&2)=0)
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
--	AND (inventoryamortization.flag &8) <> 0 -- Considera solo i tipo ammortamento : Ammortamento
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot
	 	
-------------------------------------------------------------------------------------
------ COLONNA 6
------ Ammortamenti pregressi di cespiti scaricati nell'anno corrente
-------------------------------------------------------------------------------------

---Ammortamenti 
INSERT INTO #patrimonio(idinventoryagency,idinv,idmot,ammortization_pre_scaricati)
SELECT 	inventory.idinventoryagency,inventorytreelink.idparent, assetacquire.idmot,
	-SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload	ON  assetamortization.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN assetunload AU	ON  asset.idassetunload = AU.idassetunload
JOIN inventory					ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind				ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink			ON inventorytreelink.idchild = assetacquire.idinv
WHERE  
	--inventorytreelink.nlevel = 1
	--AND 
	(inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0  AND
	(
		(
		 ((assetamortization.flag & 1 = 0)	  AND assetamortization.adate < @firstday) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)  AND assetunload.adate < @firstday)
		)
	)
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
	AND (AU.adate BETWEEN @firstday AND @date)  ---cespite scaricato quest'anno
	AND ( (inventorykind.flag&2)=0)
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
--	AND (inventoryamortization.flag &8) <> 0 -- Considera solo i tipo ammortamento : Ammortamento
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot

--Rivalutazioni
INSERT INTO #patrimonio(idinventoryagency,idinv,idmot,ammortization_pre_scaricati)
SELECT 	inventory.idinventoryagency,	inventorytreelink.idparent,	assetacquire.idmot,
	-SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetload		ON  assetamortization.idassetload = assetload.idassetload
LEFT OUTER JOIN assetunload AU	ON  asset.idassetunload = AU.idassetunload
JOIN inventory					ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind				ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink			ON inventorytreelink.idchild = assetacquire.idinv
WHERE  
	--inventorytreelink.nlevel = 1
	--AND 
	(inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota > 0  AND
	(
		(
		 ((assetamortization.flag & 1 = 0)  AND assetamortization.adate < @firstday) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)AND assetload.ratificationdate < @firstday)
		)
	)
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
	AND (AU.adate BETWEEN @firstday AND @date)  ---cespite scaricato quest'anno
	AND ( (inventorykind.flag&2)=0)
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
--	AND (inventoryamortization.flag &8) <> 0 -- Considera solo i tipo ammortamento : Ammortamento
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot

-------------------------------------------------------------------------------------
------ COLONNA 8  Ammortamenti di cespiti non ancora scaricati nell'anno attuale
------ Ammortamenti di quest'anno
-------------------------------------------------------------------------------------

---Ammortamenti 
INSERT INTO #patrimonio(idinventoryagency,idinv,idmot,ammortization_post)
SELECT 	inventory.idinventoryagency,inventorytreelink.idparent, assetacquire.idmot,
	-SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload	ON  assetamortization.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN assetunload AU	ON  asset.idassetunload = AU.idassetunload
JOIN inventory					ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind				ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink			ON inventorytreelink.idchild = assetacquire.idinv
WHERE  
	--inventorytreelink.nlevel = 1
	--AND 
	(inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0  AND
	(
		(
		 ((assetamortization.flag & 1 = 0)	  AND assetamortization.adate BETWEEN @firstday AND @date)  --ammortamenti di quest'anno
		  OR 
		  ((assetamortization.flag & 1 <> 0)  AND assetunload.adate BETWEEN @firstday AND @date)
		)
	)
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
	AND (AU.adate is null OR AU.adate > @date)  ---cespite non ancora scaricato
	AND ( (inventorykind.flag&2)=0)
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
	--AND (inventoryamortization.flag &8) <> 0 -- Considera solo i tipo ammortamento : Ammortamento
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot

--Rivalutazioni
INSERT INTO #patrimonio(idinventoryagency,idinv,idmot,ammortization_post)
SELECT 	inventory.idinventoryagency,	inventorytreelink.idparent,	assetacquire.idmot,
	-SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization		ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetload		ON  assetamortization.idassetload = assetload.idassetload
LEFT OUTER JOIN assetunload AU	ON  asset.idassetunload = AU.idassetunload
JOIN inventory					ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind				ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN inventorytreelink			ON inventorytreelink.idchild = assetacquire.idinv
WHERE  
	--inventorytreelink.nlevel = 1
	--AND 
	(inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota > 0  AND
	(
		(
		 ((assetamortization.flag & 1 = 0)  AND assetamortization.adate BETWEEN @firstday AND @date)   --rivalutazioni di quest'anno
		  OR 
		  ((assetamortization.flag & 1 <> 0)AND assetload.ratificationdate BETWEEN @firstday AND @date)
		)
	)
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
	AND (AU.adate is null OR AU.adate > @date)  ---cespite non ancora scaricato
	AND ( (inventorykind.flag&2)=0)
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
	--AND (inventoryamortization.flag &8) <> 0 -- Considera solo i tipo ammortamento : Ammortamento
GROUP BY inventory.idinventoryagency, inventorytreelink.idparent, assetacquire.idmot


DECLARE @MostraAvanzoCassa char(1)
SELECT  @MostraAvanzoCassa = isnull(paramvalue,'N')
FROM    reportadditionalparam
WHERE   paramname = 'MostraAvanzoCassa' and reportname='rpt_sitpatrim_generale'

IF (Upper(@MostraAvanzoCassa)='S')
Begin
	DECLARE @startfloatfund decimal(19,2)
	DECLARE @aumfloatfund decimal(19,2)
	DECLARE @dimfloatfund decimal(19,2)

	SELECT 
		@startfloatfund = ISNULL(startfloatfund, 0.0),
	        @aumfloatfund = ISNULL(competencyproceeds, 0.0) + ISNULL(residualproceeds, 0.0),
	        @dimfloatfund = ISNULL(competencypayments, 0.0) + ISNULL(residualpayments, 0.0)
	FROM surplus
	WHERE ayear = @year
	
	INSERT INTO #patrimonio (idsor, idmot, description, initial_amount, var_aum, var_dim)
	VALUES('9999','9999','Avanzo di cassa', @startfloatfund, @aumfloatfund, @dimfloatfund)
End


declare @inventory varchar(50)
select @inventory = description from inventory where idinventory = @idinventory

IF (@showmotive= 'S') 
BEGIN
	SELECT 
		ENTE.codeinventoryagency AS 'codinventoryagency',
		ENTE.description as 'descinventoryagency',
		#patrimonio.idinv as idsor,
		CLASS.codeinv as 'codesor',
		CLASS.nlevel,
		#patrimonio.idmot,
		MOTIVE.description as 'motive',
		CLASS.description,
		initial_amount as 'initial_amount',
		var_aum ,
		var_dim ,
		ammortization_pre_in_carico,
		ammortization_pre_scaricati,
		final_amount,
		ammortization_post ,
		@date as 'stop',
		@inventory as 'inventory'
	FROM #patrimonio
	LEFT OUTER JOIN inventorytree CLASS 		ON CLASS.idinv = #patrimonio.idinv
	LEFT OUTER JOIN inventoryagency	ENTE		ON ENTE.idinventoryagency = #patrimonio.idinventoryagency
	LEFT OUTER JOIN #assetloadmotive MOTIVE		ON MOTIVE.idmot = ISNULL(#patrimonio.idmot,0)
	ORDER BY ENTE.codeinventoryagency,#patrimonio.idmot, CLASS.codeinv
END
ELSE
BEGIN

---------------------------------------------------------------------------
-- Questo ramo di codice viene percorso se @showmotive <> 'S'
---------------------------------------------------------------------------

--WITH Sales_CTE (SalesPersonID, SalesOrderID, SalesYear)  
--AS  
---- Define the CTE query.  
--(  
--    SELECT SalesPersonID, SalesOrderID, YEAR(OrderDate) AS SalesYear  
--    FROM Sales.SalesOrderHeader  
--    WHERE SalesPersonID IS NOT NULL  
--)  
---- Define the outer query referencing the CTE name.  
--SELECT SalesPersonID, COUNT(SalesOrderID) AS TotalSales, SalesYear  
--FROM Sales_CTE  
--GROUP BY SalesYear, SalesPersonID  
--ORDER BY SalesPersonID, SalesYear;  
--GO  


WITH CONTI (IDINV, CODEINV, DESCRIPTION, 
[Causale Scarico Cespite Ammortamento], 
[Codice Conto Imm. da Causale di Scarico Cespite Ammortamento], 
[Conto Imm. da Causale di Scarico Cespite Ammortamento],
[Codice Fondo Amm. da Causale di Scarico Cespite Ammortamento], 
[Fondo Amm. da Causale di Scarico Cespite Ammortamento],
[Causale Applicazione Ammortamento o Svalutazione], 
[Codice Fondo Amm. da Causale Applicazione Ammortamento], 
[Fondo Amm. da Causale Applicazione Ammortamento]

 )

as
(
select distinct 
	 IU.idinv, IU.codeinv,IU.description,
	 coalesce(v3.codemotiveunload,v2.codemotiveunload,v1.codemotiveunload) [Causale Scarico Cespite Ammortamento], 
	 imm.codeacc [Codice Conto Imm. da Causale di Scarico Cespite Ammortamento], 
	 imm.account [Conto Imm. da Causale di Scarico Cespite Ammortamento],
	 fon.codeacc [Codice Fondo Amm. da Causale di Scarico Cespite Ammortamento], 
	 fon.account [Fondo Amm. da Causale di Scarico Cespite Ammortamento],
	 coalesce(v3.codemotive,v2.codemotive,v1.codemotive)[Causale Applicazione Ammortamento o Svalutazione], 
	 amm.codeacc [Codice Fondo Amm. da Causale Applicazione Ammortamento], 
	 amm.account [Fondo Amm. da Causale Applicazione Ammortamento]
	from inventorytreeusable IU
	 join inventorytreelink IL on IL.idchild = IU.idinv
	left outer join inventorysortingamortizationyearview v3 on v3.idinv=IL.idparent and IL.nlevel=3 and v3.ayear=@year
	left outer join inventorysortingamortizationyearview v2 on v2.idinv=IL.idparent and IL.nlevel=2 and v2.ayear=@year
	left outer join inventorysortingamortizationyearview v1 on v1.idinv=IL.idparent and IL.nlevel=1 and v1.ayear=@year
	left outer join  accmotivedetailview imm  on imm.idaccmotive = coalesce(v3.idaccmotiveunload,v2.idaccmotiveunload,v1.idaccmotiveunload) 
		and imm.idaccountkind = @idaccountkind_imm and imm.ayear=@year -- Conto Imm. da Causale di Scarico Cespite Ammortamento
    left outer join accmotivedetailview fon  on fon.idaccmotive =  coalesce(v3.idaccmotiveunload,v2.idaccmotiveunload,v1.idaccmotiveunload) 
		and fon.idaccountkind =@idaccountkind_fon and fon.ayear=@year -- Fondo Amm. da Causale di Scarico Cespite Ammortamento
	left outer join accmotivedetailview amm  on amm.idaccmotive =  coalesce(v3.idaccmotive,v2.idaccmotive,v1.idaccmotive) 
		and amm.idaccountkind =@idaccountkind_fon and amm.ayear=@year   -- Fondo Amm. da Causale Applicazione Ammortamento
	left outer join accountview on imm.idacc = accountview.idacc and imm.ayear=@year
	 where imm.idaccmotive is not null or fon.idaccmotive is not null or amm.idaccmotive is not null 


	)


	SELECT 
		ENTE.codeinventoryagency AS 'codinventoryagency',
		ENTE.description as 'descinventoryagency',
		#patrimonio.idinv as idsor,
		CLASS.codeinv as 'codesor',
		CLASS.nlevel,
		null as 'idmot',
		null as 'motive',
		CLASS.description,
		ISNULL(SUM(initial_amount),0) as 'initial_amount (a)',
		ISNULL(SUM(var_aum),0) as 'var_aum (b)',
		ISNULL(SUM(var_dim),0) as 'var_dim (c)',
		ISNULL(SUM(ammortization_pre_in_carico),0) as 'ammortization_pre_in_carico (e1)',
		ISNULL(SUM(ammortization_pre_scaricati),0) as 'ammortization_pre_scaricati (e2)',
		ISNULL(SUM(final_amount),0) as 'final_amount (d)',		  
		ISNULL(SUM(ammortization_post),0) as 'ammortization_post (g)',
		ISNULL(SUM(ammortization_post),0) + 
		ISNULL(SUM(ammortization_pre_in_carico),0) as 'fondo ammortamento (e1 + g)',
		ISNULL(SUM(final_amount),0)  - 
		ISNULL(SUM(ammortization_pre_in_carico),0) -
		ISNULL(SUM(ammortization_post),0) as 'Consistenza finale (h) d-e1-g',
		@date as 'stop',
		@inventory as 'inventory',
		car.codeacc as [Codice Conto Immobilizzazione],
		car.account as [Conto Immobilizzazione],
		accountview.codepatrimony as [Codice Stato Patrimoniale], 
		accountview.patrimony  as [Desc. Stato Patrimoniale],
		conti.[Causale Scarico Cespite Ammortamento], 
		--conti.[Codice Conto Imm. da Causale di Scarico Cespite Ammortamento], 
		--conti.[Conto Imm. da Causale di Scarico Cespite Ammortamento],
		conti.[Codice Fondo Amm. da Causale di Scarico Cespite Ammortamento], 
		conti.[Fondo Amm. da Causale di Scarico Cespite Ammortamento],
		conti.[Causale Applicazione Ammortamento o Svalutazione], 
		conti.[Codice Fondo Amm. da Causale Applicazione Ammortamento], 
		conti.[Fondo Amm. da Causale Applicazione Ammortamento]
	FROM #patrimonio
	LEFT OUTER JOIN inventorytree CLASS  	ON CLASS.idinv = #patrimonio.idinv
	LEFT OUTER JOIN inventoryagency	ENTE   	ON ENTE.idinventoryagency = #patrimonio.idinventoryagency
	LEFT OUTER JOIN accmotivedetailview car 
		ON car.idaccmotive = class.idaccmotiveload and  car.idaccountkind = '0005' and car.ayear=@year
	left outer join accountview on car.idacc = accountview.idacc and car.ayear=@year
	--left outer join accmotivedetailview amm on amm.idaccmotive = v.idaccmotive	and	 -- Fondo Amm. da Causale Applicazione Ammortamento 
	--	amm.idaccountkind = '0008' and amm.ayear=@year
	--LEFT OUTER JOIN inventoryagency	ENTE
	--	ON ENTE.idinventoryagency = #patrimonio.codinventoryagency
left outer join  conti on CLASS.idinv = conti.idinv
	WHERE CLASS.CODEINV IN (select codeinv from inventorytree where idinv not in (select distinct paridinv from inventorytree where paridinv is not null))
	GROUP BY ENTE.codeinventoryagency, ENTE.description,#patrimonio.idinv, CLASS.codeinv, CLASS.nlevel,CLASS.description, car.codeacc, car.account,
		conti.[Causale Scarico Cespite Ammortamento], 
		--conti.[Codice Conto Imm. da Causale di Scarico Cespite Ammortamento], 
		--conti.[Conto Imm. da Causale di Scarico Cespite Ammortamento],
		conti.[Codice Fondo Amm. da Causale di Scarico Cespite Ammortamento], 
		conti.[Fondo Amm. da Causale di Scarico Cespite Ammortamento],
		conti.[Causale Applicazione Ammortamento o Svalutazione], 
		conti.[Codice Fondo Amm. da Causale Applicazione Ammortamento], 
		conti.[Fondo Amm. da Causale Applicazione Ammortamento],
--		conti.[Codice Stato Patrimoniale],
--		conti.[Desc. Stato Patrimoniale]
		accountview.codepatrimony, 
		accountview.patrimony
	ORDER BY  ENTE.codeinventoryagency, CLASS.codeinv;
END
END


