
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_consistenza_patrimoniale_inizio_anno_le]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_consistenza_patrimoniale_inizio_anno_le]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE    PROCEDURE [exp_consistenza_patrimoniale_inizio_anno_le]
	@year int,
	@codinventoryagency int =null,
	@date datetime=null,	
	@showmotive char(1)='S',
	@idinventory int

AS BEGIN
-- setuser 'amministrazione'
-- exec [exp_consistenza_patrimoniale_inizio_anno_le] 2020, null, '2020-12-31', 'S',  null
-- {rpt_sitpatrim_ente;1.initial_amount} - {rpt_sitpatrim_ente;1.ammortization_pre_scaricati} - {rpt_sitpatrim_ente;1.ammortization_pre_in_carico};
DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)
if (@date is null) SET @date = CONVERT(datetime, '31-12-' + CONVERT(char(4),@year), 105)



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


CREATE TABLE #patrimonio
(
	idinventoryagency int,
	idinv_category int,
	idinv int,
	description varchar(150),
	idinventorykind int,
	idinventory int,
	initial_amount decimal(19,2), --somma valore iniziale  di tutti i cespiti e accessori sino all'anno precedente e non scaricati sino all'anno scorso
	final_amount decimal(19,2), 
	idmot int,
	var_aum decimal(19,2),   -- carichi di quest'anno
	var_dim decimal(19,2),	 -- scarichi di quest'anno

	-- Rivalutazioni Positive e Negative ufficiali  (di BENI E DI ACCESSORI) sino all'anno scorso, di cespiti non ancora scaricati nell'anno attuale
	-- COLONNA 5  "Ammortamenti pregressi di cespiti in carico nel "
	ammortization_pre_in_carico decimal(19,2),  


	-- Rivalutazioni Positive e Negative ufficiali  (di BENI E DI ACCESSORI) sino all'anno scorso purchè RISULTINO SCARICATI IN QUEST'ANNO
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
INSERT INTO #patrimonio(idinventoryagency,idinventorykind,idinventory, idinv_category,idinv,idmot,initial_amount)
SELECT 	inventory.idinventoryagency,inventory.idinventorykind,inventory.idinventory,	inventorytreelink.idparent,	inventorytreelink.idchild,assetacquire.idmot,	SUM(AC.start)
FROM assetacquire 
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC	on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetload				ON assetload.idassetload = assetacquire.idassetload
JOIN inventory				ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind			ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventorytreelink		ON inventorytreelink.idchild = assetacquire.idinv
LEFT OUTER JOIN assetunload AU	ON  asset.idassetunload = AU.idassetunload

WHERE 
	inventorytreelink.nlevel = 1
	AND assetload.ratificationdate < @firstday 
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL)	
	AND ( (inventorykind.flag&2)=0) --inventario visibile
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
	AND (AU.adate is null or AU.adate >= @firstday )  ---cespite ancora in carico l'anno scorso

GROUP BY inventory.idinventoryagency,inventory.idinventorykind, inventory.idinventory,inventorytreelink.idparent, inventorytreelink.idchild,assetacquire.idmot
	


INSERT INTO #patrimonio(idinventoryagency,idinventorykind, idinventory,idinv_category,idinv, idmot,initial_amount)
SELECT 	inventory.idinventoryagency,inventory.idinventorykind, inventory.idinventory,	inventorytreelink.idparent,	inventorytreelink.idchild,assetacquire.idmot,	-SUM(AC.start)
FROM assetacquire 
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
join assetacquire B			on B.nassetacquire = asset.nassetacquire
JOIN assetview_current AC	on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
LEFT OUTER JOIN assetload	ON assetload.idassetload = assetacquire.idassetload
JOIN inventory				ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind			ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventorytreelink		ON inventorytreelink.idchild = assetacquire.idinv
JOIN assetunload AU	ON  asset.idassetunload = AU.idassetunload
WHERE 
	inventorytreelink.nlevel = 1 and AC.idpiece>1 
	AND assetload.idassetload is null	
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL)	
	AND ( (inventorykind.flag&2)=0)   --inventario visibile
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
	AND AU.adate < @firstday ---accessorio scaricato prima di quest'anno
	and  ((B.flag & 1 <> 1) AND (B.flag & 2 <> 0)) 

GROUP BY inventory.idinventoryagency,inventory.idinventorykind, inventory.idinventory, inventorytreelink.idparent, inventorytreelink.idchild,assetacquire.idmot

-------------------------------------------------------------------------------------
------ COLONNA 5 "Ammortamenti pregressi di cespiti in carico nel "
------ Ammortamenti PREGRESSI di cespiti ancora in carico nell'anno corrente
-------------------------------------------------------------------------------------

---Ammortamenti 
INSERT INTO #patrimonio(idinventoryagency,idinventorykind,idinventory,idinv_category,idinv,idmot,ammortization_pre_in_carico)
SELECT 	inventory.idinventoryagency,inventory.idinventorykind,inventory.idinventory,inventorytreelink.idparent,inventorytreelink.idchild, assetacquire.idmot,
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
	inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
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
GROUP BY inventory.idinventoryagency,inventory.idinventorykind, inventory.idinventory,inventorytreelink.idparent, inventorytreelink.idchild,assetacquire.idmot


--Rivalutazioni
INSERT INTO #patrimonio(idinventoryagency,idinventorykind,idinventory,idinv_category,idinv, idmot,ammortization_pre_in_carico)
SELECT 	inventory.idinventoryagency,inventory.idinventorykind,inventory.idinventory,	inventorytreelink.idparent,	inventorytreelink.idchild, assetacquire.idmot,
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
	inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
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
	--AND (inventoryamortization.flag &8) <> 0 -- Considera solo i tipo ammortamento : Ammortamento
GROUP BY inventory.idinventoryagency,inventory.idinventorykind, inventory.idinventory, inventorytreelink.idparent,inventorytreelink.idchild, assetacquire.idmot
	 
	

-------------------------------------------------------------------------------------
------ COLONNA 6
------ Ammortamenti pregressi di cespiti scaricati nell'anno corrente
-------------------------------------------------------------------------------------

---Ammortamenti 
INSERT INTO #patrimonio(idinventoryagency,idinventorykind,idinventory,idinv_category,idinv, idmot,ammortization_pre_scaricati)
SELECT 	inventory.idinventoryagency,inventory.idinventorykind,inventory.idinventory,inventorytreelink.idparent,inventorytreelink.idchild, assetacquire.idmot,
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
	inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
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
	AND ( (inventorykind.flag&2)=0)   ---inventario visibile
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
	--AND (inventoryamortization.flag &8) <> 0 -- Considera solo i tipo ammortamento : Ammortamento
GROUP BY inventory.idinventoryagency,inventory.idinventorykind, inventory.idinventory, inventorytreelink.idparent,inventorytreelink.idchild, assetacquire.idmot


--Rivalutazioni
INSERT INTO #patrimonio(idinventoryagency,idinventorykind,idinventory,idinv_category,idmot,ammortization_pre_scaricati)
SELECT 	inventory.idinventoryagency,inventory.idinventorykind,	inventory.idinventory,inventorytreelink.idparent,	assetacquire.idmot,
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
	inventorytreelink.nlevel = 1
	AND (inventoryamortization.flag & 2 <> 0)
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
	AND ( (inventorykind.flag&2)=0)  ---inventario visibile
	AND (assetacquire.idinventory = @idinventory OR @idinventory IS NULL) 
	--AND (inventoryamortization.flag &8) <> 0 -- Considera solo i tipo ammortamento : Ammortamento
GROUP BY inventory.idinventoryagency,inventory.idinventorykind, inventory.idinventory, inventorytreelink.idparent, assetacquire.idmot

 




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


 
	SELECT 
		@year as 'esercizio' ,
		ENTE.codeinventoryagency AS 'codeinvagency',
		ENTE.description as 'descrinvagency',
		IKIND.codeinventorykind as 'codeinvkind',
		IKIND.description as  'descrinvkind',
		INVENTARIO.codeinventory as 'codeinv' ,
		INVENTARIO.description as 'descrinv',
		#patrimonio.idinv_category,
		CATEGORY.codeinv as 'cod. category',
		CATEGORY.nlevel as 'liv. category',
		CATEGORY.description as 'category', 
		#patrimonio.idinv ,
		CLASS.codeinv as 'codeclass',
		CLASS.nlevel,
		CLASS.description as class,
		#patrimonio.idmot,
		MOTIVE.codemot as 'codicecausalecar',
		MOTIVE.description as 'descrcausalecar',

		ISNULL(SUM(initial_amount),0) as 'initial_amount',
		ISNULL(SUM(ammortization_pre_in_carico),0) as 'ammortization_pregressi_in_carico',
		ISNULL(SUM(ammortization_pre_scaricati),0) as 'ammortization_pregressi_scaricati',
 		ISNULL(SUM(initial_amount),0)  - 	ISNULL(SUM(ammortization_pre_in_carico),0) - 		ISNULL(SUM(ammortization_pre_scaricati),0) as    cons_inizio_anno,
		@date as 'stop' 
	FROM #patrimonio
	LEFT OUTER JOIN inventorytree CLASS  	ON CLASS.idinv = #patrimonio.idinv
	LEFT OUTER JOIN inventorytree CATEGORY  	ON CATEGORY.idinv = #patrimonio.idinv_category
	LEFT OUTER JOIN inventory  INVENTARIO  				ON #patrimonio.idinventory = INVENTARIO.idinventory
	LEFT OUTER JOIN  inventorykind	IKIND			ON INVENTARIO.idinventorykind= IKIND.idinventorykind
	LEFT OUTER JOIN inventoryagency	ENTE   	ON ENTE.idinventoryagency = #patrimonio.idinventoryagency
	LEFT OUTER JOIN #assetloadmotive MOTIVE		ON MOTIVE.idmot = ISNULL(#patrimonio.idmot,0)
	GROUP BY ENTE.codeinventoryagency, ENTE.description,#patrimonio.idinv,#patrimonio.idinv_category, CLASS.codeinv, CLASS.nlevel,CLASS.description,
	INVENTARIO.codeinventory ,INVENTARIO.description,IKIND.codeinventorykind, IKIND.description,
	#patrimonio.idmot,	MOTIVE.codemot,MOTIVE.description,CATEGORY.codeinv, CATEGORY.nlevel,CATEGORY.description 
	ORDER BY  ENTE.codeinventoryagency,INVENTARIO.codeinventory, CLASS.codeinv
END
 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


