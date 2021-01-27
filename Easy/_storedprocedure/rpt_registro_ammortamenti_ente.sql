
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_registro_ammortamenti_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_registro_ammortamenti_ente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec rpt_registro_ammortamenti_ente 2009,1
--setuser 'amm'

CREATE    PROCEDURE [rpt_registro_ammortamenti_ente]
(
	@year int,
	@idinventory int
)
AS BEGIN
-- ATTENZIONE: la sp alimenta anche il report : registro_ammortamenti_ente_suduerighe.rpt, realizzato col task 8499
declare @SS1 datetime
declare @SS2 datetime

-------------------------------------------------------------------------------------
-------------- Elenco cespiti e accessori  ammortizzati nell'anno -------------------
-------------------------------------------------------------------------------------
DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)
DECLARE @lastday datetime
SET @lastday = CONVERT(datetime, '31-12-' + CONVERT(char(4),@year), 105)

DECLARE @MostraClassificazioneCompleta char(1)
SELECT @MostraClassificazioneCompleta = isnull(paramvalue,'N') 
FROM reportadditionalparam WHERE paramname = 'MostraClassificazioneCompleta'
 
		
-- Tabella temporanea destinata a contenere gli ammortamenti dell'esercizio corrente
CREATE TABLE #assetamortization
(
	idasset int,
	idpiece int,
	idinventoryagency int,
	acquirekind varchar(20),
	inventoryagency varchar(150),
	inventory varchar(50),
	inventorykind varchar(50),   
	ninventory int,
	assetloadkind varchar(50), 
	idassetloadkind int,
	yassetload int,
	nassetload int,
	category varchar(150),
	idinv int,
	description varchar(150),
	assetdescription varchar(150),
	assetoriginalvalue decimal(19,2),
	startvalue decimal(19,2),
	finalvalue decimal(19,2),
	namortization int,
	amortizationquota float,
	assetvalue decimal(19,2),
	adate smalldatetime,
	amortizationvalue decimal(19,2) 
)
	
set @ss1= getdate()
print 'INSERT INTO #assetamortization'
INSERT INTO #assetamortization
(	
	idasset,
	idpiece,
	acquirekind,
	idinventoryagency,
	inventoryagency,
	inventory,
	inventorykind,
	ninventory,
	description,
	assetdescription,
	idinv,
	category,
	assetloadkind,
	idassetloadkind,  
	yassetload,  
	nassetload,
	namortization,
	amortizationquota,
	assetvalue,
	adate,
	assetoriginalvalue
)

	SELECT  
	cespite_o_accessorio.idasset,
	cespite_o_accessorio.idpiece,
	CASE 
		WHEN cespite_o_accessorio.idpiece = 1 THEN 'Cespite' 
		WHEN cespite_o_accessorio.idpiece > 1 THEN 'Accessorio'
	END,
	inventory.idinventoryagency,
	inventoryagency.description,
	inventory.description,
	inventorykind.description,
	cespite.ninventory,
	carico.description,
	CASE 
		WHEN cespite_o_accessorio.idpiece = 1 THEN NULL
		WHEN cespite_o_accessorio.idpiece > 1 THEN caricocespite.description
	END,
	inventorytree.idinv, 
	inventorytree.description,
	assetloadkind.description,
	buono_carico.idassetloadkind,
	buono_carico.yassetload,
	buono_carico.nassetload,
	assetamortization.namortization,
	assetamortization.amortizationquota,
	assetamortization.assetvalue,
	CASE 
		WHEN assetamortization.flag & 1 =0 THEN assetamortization.adate
		WHEN assetamortization.flag & 1<>0 THEN isnull(assetunload.adate,assetload.ratificationdate)
	END,

	CASE	
			----------------------------------------------------------------------------------
			----------------- Considera i buoni di carico cespiti precedenti al 2005   -------
			----------------------------------------------------------------------------------
			WHEN cespite_o_accessorio.idpiece=1 AND
		 		((inventorykind.flag & 1 <> 0) OR ISNULL(buono_carico.yassetload,2006)<2005 
					OR(carico.idassetload IS NULL AND (carico.flag & 2 <> 0)))	
			THEN
			CONVERT(decimal(19,2),ROUND(
				ROUND(ISNULL(carico.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(carico.discount, 0))),2)
				+ ROUND(ISNULL(carico.tax,0) / carico.number,2)
				- ROUND(ISNULL(carico.abatable,0) / carico.number,2) 
			,2))
			----------------------------------------------------------------------------------
			------- Considera i buoni di carico del 2005 e i successivi  SENZA SCONTO --------
			----------------------------------------------------------------------------------			
			WHEN cespite_o_accessorio.idpiece= 1 AND
					NOT ((inventorykind.flag & 1 <> 0) OR ISNULL(buono_carico.yassetload,2006)<2005
							 OR  (carico.idassetload IS NULL AND (carico.flag & 2 <> 0)) )	
			THEN
			CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(carico.taxable, 0),2)
			+ ROUND(ISNULL(carico.tax,0) / carico.number,2)
			- ROUND(ISNULL(carico.abatable,0) / carico.number,2) 
			,2))
			WHEN cespite_o_accessorio.idpiece>1 THEN
			CONVERT(decimal(19,2),ROUND(
			        ROUND(ISNULL(carico.taxable, 0)
			        * (1 - CONVERT(decimal(19,6),ISNULL(carico.discount, 0))),2)
				+ ROUND(ISNULL(carico.tax,0) / carico.number,2)
				- ROUND(ISNULL(carico.abatable,0) / carico.number,2) 
				,2))				
		 
		
	END
FROM  assetacquire as carico
JOIN	asset as cespite_o_accessorio		ON carico.nassetacquire = cespite_o_accessorio.nassetacquire
LEFT OUTER JOIN assetload buono_carico		ON buono_carico.idassetload = carico.idassetload
JOIN asset as cespite						ON cespite.idasset = cespite_o_accessorio.idasset and cespite.idpiece = 1 
JOIN assetacquire as caricocespite			ON caricocespite.nassetacquire = cespite.nassetacquire
LEFT OUTER JOIN assetloadkind				ON  buono_carico.idassetloadkind = assetloadkind.idassetloadkind
JOIN inventory								ON carico.idinventory = inventory.idinventory
JOIN inventoryagency						ON inventory.idinventoryagency = inventoryagency.idinventoryagency
JOIN inventorykind							ON inventory.idinventorykind = inventorykind.idinventorykind   
JOIN inventorytreelink						ON inventorytreelink.idchild = carico.idinv
JOIN inventorytree							ON inventorytree.idinv = inventorytreelink.idparent
JOIN assetamortization						ON assetamortization.idasset = cespite_o_accessorio.idasset
												AND assetamortization.idpiece = cespite_o_accessorio.idpiece 
JOIN inventoryamortization					ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
LEFT OUTER JOIN assetunload					ON  assetamortization.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN assetload					ON  assetamortization.idassetload = assetload.idassetload

WHERE   ( @idinventory is null or carico.idinventory = @idinventory)
	AND (carico.idassetload IS NOT NULL OR ((carico.flag & 1 = 0) ))   --AND (carico.flag & 2 = 0)
	AND (inventoryamortization.flag & 2 <> 0)
	--AND assetamortization.adate >= @firstday
	AND ( 
        ( @MostraClassificazioneCompleta = 'N' AND inventorytreelink.nlevel = 1 )
        OR
        (@MostraClassificazioneCompleta = 'S' AND inventorytreelink.idparent = inventorytreelink.idchild )
        )
	AND (
	 		     (assetamortization.amortizationquota >0 AND 
			      (
			       ((assetamortization.flag & 1 = 0) AND YEAR(assetamortization.adate)= @year) OR 
			       ((assetamortization.flag & 1 <> 0) AND YEAR(assetload.ratificationdate)= @year)
				  )
			     )
				OR
	 		     (assetamortization.amortizationquota <0 AND 
			      (
			       ((assetamortization.flag & 1 = 0) AND YEAR(assetamortization.adate) = @year) OR 
			       ((assetamortization.flag & 1 <> 0) AND YEAR(assetunload.adate)= @year)
				  )
			     )
			    )
	
--ORDER BY carico.nassetacquire

set @ss2= getdate()
print datediff(ms,@ss1,@ss2)


UPDATE #assetamortization
SET amortizationvalue =
ISNULL(
	(SELECT ROUND(ISNULL(#assetamortization.assetvalue,0) * 
	ISNULL(#assetamortization.amortizationquota,0),2))
, 0.0)

UPDATE #assetamortization
SET finalvalue = assetoriginalvalue


print '	UPDATE #assetamortization SET amortizationvalue + '
set @ss1= getdate()
UPDATE #assetamortization
SET finalvalue = finalvalue + 
ISNULL(
	(SELECT
		SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
		ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetamortization
	JOIN inventoryamortization				ON assetamortization.idinventoryamortization=inventoryamortization.idinventoryamortization
	LEFT OUTER JOIN assetunload				ON  assetamortization.idassetunload = assetunload.idassetunload
	LEFT OUTER JOIN assetload				ON  assetamortization.idassetload = assetload.idassetload
	WHERE assetamortization.idasset = #assetamortization.idasset AND assetamortization.idpiece = 1
		
			AND (
	 		     (assetamortization.amortizationquota >0 AND 
			      (
			       ((assetamortization.flag & 1 = 0) AND assetamortization.adate <= @lastday) OR 
			       ((assetamortization.flag & 1 <> 0) AND assetload.ratificationdate <= @lastday)
				  )
			     )
				OR
	 		     (assetamortization.amortizationquota <0 AND 
			      (
			       ((assetamortization.flag & 1 = 0) AND assetamortization.adate <= @lastday) OR 
			       ((assetamortization.flag & 1 <> 0) AND assetunload.adate <= @lastday)
				  )
			     )
			    )
		
		AND (inventoryamortization.flag & 2 <> 0)  
		
		)
,0)
WHERE #assetamortization.idpiece = 1

set @ss2= getdate()
print datediff(ms,@ss1,@ss2)


			
	-------------------------------------------------------------------------------------------------
	------ CARICHI ACCESSORI  DI BENI ---------------------------------------------------------------
	-------------------------------------------------------------------------------------------------
print '	UPDATE #assetamortization SET finalvalue '
set @ss1= getdate()

UPDATE #assetamortization
SET finalvalue = finalvalue +
ISNULL(
	(SELECT 
		SUM(
		ROUND(ISNULL(caricoaccessorio.taxable, 0)
		* (1 - CONVERT(decimal(19,6),ISNULL(caricoaccessorio.discount, 0))),2)
		+ ROUND(ISNULL(caricoaccessorio.tax,0) / caricoaccessorio.number,2)
		- ROUND(ISNULL(caricoaccessorio.abatable,0) / caricoaccessorio.number,2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio		ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	WHERE accessorio.idpiece > 1
		AND caricoaccessorio.adate <= @lastday --
		AND accessorio.idasset = #assetamortization.idasset
		AND caricoaccessorio.idassetload IS NOT NULL
		)
,0.0)
WHERE #assetamortization.idpiece = 1
	
set @ss2= getdate()
print datediff(ms,@ss1,@ss2)

print '	UPDATE #assetamortization SET finalvalue +'
set @ss1= getdate()
	-------------------------------------------------------------------------------------------------
	------ RIVALUTAZIONI DEGLI ACCESSORI DEI BENI ---------------------------------------------------
	-------------------------------------------------------------------------------------------------

UPDATE #assetamortization
SET finalvalue = finalvalue +
ISNULL(
	(SELECT
		SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
			  ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio			ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN assetamortization				ON assetamortization.idasset = accessorio.idasset and assetamortization.idpiece = accessorio.idpiece
	LEFT OUTER JOIN assetunload			ON assetamortization.idassetunload = assetunload.idassetunload
	LEFT OUTER JOIN assetload			ON assetamortization.idassetload = assetload.idassetload
	JOIN inventoryamortization			ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	WHERE accessorio.idasset = #assetamortization.idasset
		AND assetamortization.idpiece > 1
		AND (
				(
			     (ISNULL(assetamortization.amortizationquota,0)>0) AND 
		             ((assetamortization.flag & 1 = 0) OR 
			      (assetamortization.idassetload IS NOT NULL))
			     )		
			OR 
		       (
			     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
		             ((assetamortization.flag & 1 = 0) OR 
			      (assetamortization.idassetunload IS NOT NULL))
			     )
			    )
		AND (inventoryamortization.flag & 2 <> 0)
		AND caricoaccessorio.adate <= @lastday
		AND caricoaccessorio.idassetload IS NOT NULL
		)
, 0.0)
WHERE #assetamortization.idpiece = 1


set @ss2= getdate()
print datediff(ms,@ss1,@ss2)

print '	UPDATE #assetamortization SET finalvalue -'
set @ss1= getdate()
	
	-------------------------------------------------------------------------------------------------
	--------------------- SCARICHI ACCESSORI  DI BENI -----------------------------------------------
	-------------------------------------------------------------------------------------------------
	-- Non consideriamo gli scarichi accessori associati allo scarico cespite
	-- ossia il valore del cespite rimane congelato al momento dello scarico
UPDATE #assetamortization
SET finalvalue = finalvalue -
ISNULL(
	(SELECT 
		SUM(
		ROUND(ISNULL(caricoaccessorio.taxable, 0)
		* (1 - CONVERT(decimal(19,6),ISNULL(caricoaccessorio.discount, 0))),2)
		+ ROUND(ISNULL(caricoaccessorio.tax,0) / caricoaccessorio.number,2)
		- ROUND(ISNULL(caricoaccessorio.abatable,0) / caricoaccessorio.number,2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio			ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN asset as cespite				ON cespite.idasset = #assetamortization.idasset	AND cespite.idpiece = 1
	WHERE 
		accessorio.idpiece > 1 
		AND  accessorio.idasset = #assetamortization.idasset 
		AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 = 0))  --accessorio scaricato    
		AND (accessorio.idassetunload IS NULL OR       -- accessorio non scaricato esplicitamente
		    (cespite.idassetunload IS NULL AND (cespite.flag & 1 <> 0))  OR --cespite non scaricato
		    (cespite.idassetunload <> accessorio.idassetunload) --buono scarico distinto
		)
		)
, 0.0)
WHERE #assetamortization.idpiece = 1
	

set @ss2= getdate()
print datediff(ms,@ss1,@ss2)

print '	UPDATE #assetamortization SET finalvalue -'
set @ss1= getdate()
	-------------------------------------------------------------------------------------------------
	-------------------- RIVALUTAZIONI DEGLI ACCESSORI SCARICATI DEI BENI ---------------------------
	-------------------------------------------------------------------------------------------------
UPDATE #assetamortization
SET finalvalue = finalvalue - 
ISNULL(
	(SELECT
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
		  ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetacquire as caricoaccessorio 
	JOIN asset as accessorio			ON caricoaccessorio.nassetacquire = accessorio.nassetacquire
	JOIN asset as cespite				ON cespite.idasset = #assetamortization.idasset	AND cespite.idpiece = 1	
	JOIN assetamortization				ON assetamortization.idasset = accessorio.idasset	AND assetamortization.idpiece = accessorio.idpiece
	JOIN inventoryamortization			ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
	WHERE accessorio.idasset = #assetamortization.idasset 
		AND assetamortization.idpiece > 1
		AND (inventoryamortization.flag & 2 <> 0)
		AND (
	            (
			     (ISNULL(assetamortization.amortizationquota,0)>0) AND 
		             ((assetamortization.flag & 1 = 0) OR 
			      (assetamortization.idassetload IS NOT NULL))
			     )
			 OR 
	            (
			     (ISNULL(assetamortization.amortizationquota,0)<0) AND 
		             ((assetamortization.flag & 1 = 0) OR 
			      (assetamortization.idassetunload IS NOT NULL))
			     )
			    )
		AND (accessorio.idassetunload IS NOT NULL OR (accessorio.flag & 1 = 0)) 
		AND (accessorio.idassetunload IS NULL OR      --accessorio non scaricato esplicitamente
		    (cespite.idassetunload IS NULL AND (cespite.flag & 1 <> 0))  OR --cespite non scaricato
		    (cespite.idassetunload <> accessorio.idassetunload) --buono scarico distinto
		 )
		)
, 0.0)
WHERE #assetamortization.idpiece = 1


set @ss2= getdate()
print datediff(ms,@ss1,@ss2)

print '	UPDATE #assetamortization SET finalvalue +'
set @ss1= getdate()
UPDATE #assetamortization
SET finalvalue = finalvalue +
ISNULL(
	(SELECT
		 SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
		 ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetamortization
	JOIN asset							ON  assetamortization.idasset=asset.idasset	AND assetamortization.idpiece=asset.idpiece
	JOIN inventoryamortization			ON assetamortization.idinventoryamortization=inventoryamortization.idinventoryamortization
	LEFT OUTER JOIN assetunload			ON assetamortization.idassetunload = assetunload.idassetunload
	LEFT OUTER JOIN assetload			ON assetamortization.idassetload = assetload.idassetload
	WHERE asset.idasset = #assetamortization.idasset AND asset.idpiece > 1
		AND (
	 	     (assetamortization.amortizationquota >0 AND 
				(	
				 ((assetamortization.flag & 1 = 0) AND assetamortization.adate <= @lastday) OR 
				 ((assetamortization.flag & 1 <> 0) AND assetload.ratificationdate <= @lastday)
				)
	 	     )
			OR
	 	     (assetamortization.amortizationquota <0 AND 
				(	
				 ((assetamortization.flag & 1 = 0) AND assetamortization.adate <= @lastday) OR 
				 ((assetamortization.flag & 1 <> 0) AND assetunload.adate <= @lastday)
				)
	 	     )
		    )
		AND (inventoryamortization.flag & 2 <> 0)
		AND asset.idasset = #assetamortization.idasset
		AND asset.idpiece = #assetamortization.idpiece),0)
WHERE #assetamortization.idpiece > 1
	
UPDATE #assetamortization
SET startvalue = finalvalue - amortizationvalue


set @ss2= getdate()
print datediff(ms,@ss1,@ss2)


SELECT 
	idasset,
	idpiece,
	idinventoryagency,
	acquirekind,
	inventoryagency,
	inventory,
	inventorykind,
	ninventory,
	assetloadkind, 
	idassetloadkind,
	yassetload,
	nassetload,
	category,
	#assetamortization.idinv,
	inventorytree.codeinv,
	#assetamortization.description,
	assetdescription,
	assetoriginalvalue,
	startvalue,
	finalvalue,
	namortization,
	amortizationquota,
	assetvalue,
	adate,
	amortizationvalue
FROM #assetamortization
JOIN inventorytree
	on #assetamortization.idinv = inventorytree.idinv
ORDER BY adate, ninventory
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
