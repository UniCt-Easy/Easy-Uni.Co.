
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_registro_ammortamenti_ente_con_simulazione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_registro_ammortamenti_ente_con_simulazione]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amministrazione'
-- exec rpt_registro_ammortamenti_ente_con_simulazione 2020, 8, {d '2023-03-16'},'N', 8024, 8024
-- exec rpt_registro_ammortamenti_ente_con_simulazione 2015, 1, null,'S'
CREATE    PROCEDURE [rpt_registro_ammortamenti_ente_con_simulazione]
(
	@year int,
	@idinventory int,
	@simulation_on_to_adate datetime,
	@mostrabenitotammortizzati char(1) ='N',
	@ninvstart int = null,
	@ninvstop int = null
)
AS BEGIN
-- setuser 'amm'
-- ATTENZIONE: la sp alimenta anche il report : registro_ammortamenti_ente_suduerighe.rpt, realizzato col task 8499
declare @SS1 datetime
declare @SS2 datetime

IF (@simulation_on_to_adate IS NULL OR
   YEAR(@simulation_on_to_adate)<  @year)
   BEGIN
		SELECT
			NULL AS idasset,
			NULL AS idpiece,
			NULL AS lifestart,
			NULL AS idinventoryagency,
			NULL AS acquirekind,
			NULL AS inventoryagency,
			NULL AS inventory,
			NULL AS inventorykind,
			NULL AS ninventory,
			NULL AS assetloadkind, 
			NULL AS idassetloadkind,
			NULL AS yassetload,
			NULL AS nassetload,
			NULL AS category,
			NULL AS idinv,
			NULL AS codeinv,
			NULL AS description,
			NULL AS assetdescription,
			NULL AS assetoriginalvalue,
			NULL AS startvalue,
			NULL AS finalvalue,
			NULL AS namortization,
			NULL AS amortizationquota,
			NULL AS assetvalue,
			NULL AS adate,
			NULL AS amortizationvalue,
			NULL AS real_or_simulation
		RETURN
END
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
	lifestart datetime,
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
	amortizationvalue decimal(19,2),
	real_or_simulation char(1)  -- R oppure S 
)

CREATE TABLE #simula_assetamortization
(
	namortization int,
	adate datetime,
	lastdate datetime,
	amortizationquota float,
	actual_amortizationquota  float,
	assetvalue decimal(19,2),
	assetvalue_on_the_date decimal(19,2),
	description varchar(150), 
	idasset int,
	idpiece int,
	idinventoryamortization int
)
	
set @ss1= getdate()
print 'INSERT INTO #assetamortization'
-- INSERIMENTO DEGLI AMMORTAMENTI REALI

 
 
INSERT INTO #assetamortization
	(	
		idasset,
		idpiece,
		lifestart,
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
		assetoriginalvalue,
		real_or_simulation
	)

		SELECT  
		cespite_o_accessorio.idasset,
		cespite_o_accessorio.idpiece,
		cespite_o_accessorio.lifestart,
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
		 
		
		END,
		'R'  --reali
	FROM  assetacquire as carico
	JOIN	asset as cespite_o_accessorio
		ON carico.nassetacquire = cespite_o_accessorio.nassetacquire
	LEFT OUTER JOIN assetload buono_carico
		ON buono_carico.idassetload = carico.idassetload
	JOIN asset as cespite
		ON cespite.idasset = cespite_o_accessorio.idasset and cespite.idpiece = 1 
	JOIN assetacquire as caricocespite
		ON caricocespite.nassetacquire = cespite.nassetacquire
	LEFT OUTER JOIN assetloadkind
		ON  buono_carico.idassetloadkind = assetloadkind.idassetloadkind
	JOIN inventory
		ON carico.idinventory = inventory.idinventory
	JOIN inventoryagency
		ON inventory.idinventoryagency = inventoryagency.idinventoryagency
	JOIN inventorykind
		ON inventory.idinventorykind = inventorykind.idinventorykind   
	JOIN inventorytreelink
		ON inventorytreelink.idchild = carico.idinv
	JOIN inventorytree
		ON inventorytree.idinv = inventorytreelink.idparent
	JOIN assetamortization
		ON assetamortization.idasset = cespite_o_accessorio.idasset
		AND assetamortization.idpiece = cespite_o_accessorio.idpiece 
	JOIN inventoryamortization
		ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
	LEFT OUTER JOIN assetunload
			ON  assetamortization.idassetunload = assetunload.idassetunload
	LEFT OUTER JOIN assetload
			ON  assetamortization.idassetload = assetload.idassetload

	WHERE
	carico.idinventory = @idinventory
		AND (carico.idassetload IS NOT NULL OR ((carico.flag & 1 = 0) ))  
		AND (inventoryamortization.flag & 2 <> 0)
		
		AND ( 
			( @MostraClassificazioneCompleta = 'N' AND inventorytreelink.nlevel = 1 )
			OR
			(@MostraClassificazioneCompleta = 'S' AND inventorytreelink.idparent = inventorytreelink.idchild )
			)
	AND (
	 		     (assetamortization.amortizationquota >0 AND 
			      (
			       ((assetamortization.flag & 1 = 0) AND YEAR(assetamortization.adate) <= @year) OR 
			       ((assetamortization.flag & 1 <> 0) AND YEAR(assetload.ratificationdate)<= @year)
				  )
			     )
				OR
	 		     (assetamortization.amortizationquota <0 AND 
			      (
			       ((assetamortization.flag & 1 = 0) AND YEAR(assetamortization.adate) <= @year) OR 
			       ((assetamortization.flag & 1 <> 0) AND YEAR(assetunload.adate)<= @year)
				  )
			     )
			    )
	and	(cespite.ninventory >=  @ninvstart or @ninvstart is null)
	and (cespite.ninventory <= @ninvstop or @ninvstop is null)
	--select * from #assetamortization
 
	

-- ORDER BY carico.nassetacquire
-- se desidero effettuare la simulazione alla data chiamo la sp che simula il valore attuale del cespite e le quote ricalcolate alla data
-- select * from #assetamortization  
if (@simulation_on_to_adate IS NOT NULL)
BEGIN
	INSERT INTO #simula_assetamortization
	(
		namortization,
		adate,
		lastdate,
		amortizationquota,
		actual_amortizationquota,
		assetvalue,
		assetvalue_on_the_date,
		description, 
		idasset,
		idpiece,
		idinventoryamortization
	)
	exec simulation_asset_ammortization_on_the_date @year, @simulation_on_to_adate, @idinventory, @ninvstart, @ninvstop
	--SELECT '#simula_assetamortization',* FROM #simula_assetamortization
	--select * from #simula_assetamortization
	INSERT INTO #assetamortization
	(	
		idasset,
		idpiece,
		lifestart,
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
		assetoriginalvalue,
		real_or_simulation
	)
		SELECT  
		cespite_o_accessorio.idasset,
		cespite_o_accessorio.idpiece,
		cespite_o_accessorio.lifestart,
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
		#simula_assetamortization.namortization,
		#simula_assetamortization.actual_amortizationquota,
		#simula_assetamortization.assetvalue_on_the_date,
		@simulation_on_to_adate,

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
		 
		
		END,
		'S'  --simulati
	FROM  assetacquire as carico
	JOIN	asset as cespite_o_accessorio
		ON carico.nassetacquire = cespite_o_accessorio.nassetacquire
	LEFT OUTER JOIN assetload buono_carico
		ON buono_carico.idassetload = carico.idassetload
	JOIN asset as cespite
		ON cespite.idasset = cespite_o_accessorio.idasset and cespite.idpiece = 1 
	JOIN assetacquire as caricocespite
		ON caricocespite.nassetacquire = cespite.nassetacquire
	LEFT OUTER JOIN assetloadkind
		ON  buono_carico.idassetloadkind = assetloadkind.idassetloadkind
	JOIN inventory
		ON carico.idinventory = inventory.idinventory
	JOIN inventoryagency
		ON inventory.idinventoryagency = inventoryagency.idinventoryagency
	JOIN inventorykind
		ON inventory.idinventorykind = inventorykind.idinventorykind   
	JOIN inventorytreelink
		ON inventorytreelink.idchild = carico.idinv
	JOIN inventorytree
		ON inventorytree.idinv = inventorytreelink.idparent
	JOIN #simula_assetamortization
		ON #simula_assetamortization.idasset = cespite_o_accessorio.idasset
		AND #simula_assetamortization.idpiece = cespite_o_accessorio.idpiece 
	JOIN inventoryamortization
		ON #simula_assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
 
	WHERE   carico.idinventory = @idinventory
		AND (carico.idassetload IS NOT NULL OR ((carico.flag & 1 = 0) ))   
		AND (inventoryamortization.flag & 2 <> 0)
		AND ( 
			( @MostraClassificazioneCompleta = 'N' AND inventorytreelink.nlevel = 1 )
			OR
			(@MostraClassificazioneCompleta = 'S' AND inventorytreelink.idparent = inventorytreelink.idchild )
			)
	 	and (cespite.ninventory >=  @ninvstart or @ninvstart is null)
		and (cespite.ninventory <= @ninvstop or @ninvstop is null)

	END
print 'end if'
set @ss2= getdate()
print datediff(ms,@ss1,@ss2)

-- vale per tutti gli ammortamenti reali o simulati
UPDATE #assetamortization
SET amortizationvalue =
ISNULL(
	(SELECT ROUND(ISNULL(#assetamortization.assetvalue,0) * 
	ISNULL(#assetamortization.amortizationquota,0),2))
, 0.0)
WHERE #assetamortization.real_or_simulation IN ('R', 'S')


--SELECT * FROM #assetamortization

----------------------------------------------------------
--------- CALCOLO DEL FINALVALUE -------------------------
----------------------------------------------------------

-- vale per tutti gli ammortamenti reali o simulati
UPDATE #assetamortization
SET finalvalue = isnull(assetoriginalvalue,0)
WHERE   #assetamortization.real_or_simulation IN ('R', 'S')
--SELECT 1, * FROM #assetamortization

--- AGGIUNGE AMMORTAMENTI REALI DI TUTTI GLI ANNI
print '	UPDATE #assetamortization SET amortizationvalue + '
set @ss1= getdate()
UPDATE #assetamortization
SET finalvalue = finalvalue + 
ISNULL(
	(SELECT
		SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
		ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetamortization
	JOIN inventoryamortization		ON assetamortization.idinventoryamortization=inventoryamortization.idinventoryamortization
	LEFT OUTER JOIN assetunload		ON  assetamortization.idassetunload = assetunload.idassetunload
	LEFT OUTER JOIN assetload		ON  assetamortization.idassetload = assetload.idassetload
	WHERE assetamortization.idasset = #assetamortization.idasset AND assetamortization.idpiece = #assetamortization.idpiece
		
			AND (
	 		     (assetamortization.amortizationquota >0 AND 
			      (
			       ((assetamortization.flag & 1 = 0) AND assetamortization.adate <= #assetamortization.adate ) OR 
			       ((assetamortization.flag & 1 <> 0) AND assetload.ratificationdate <= #assetamortization.adate) 
				  )
			     )
				OR
	 		     (assetamortization.amortizationquota <0 AND 
			      (
			       ((assetamortization.flag & 1 = 0) AND assetamortization.adate <= #assetamortization.adate ) OR 
			       ((assetamortization.flag & 1 <> 0) AND assetunload.adate <= #assetamortization.adate)
				  )
			     )
			    )
		
		AND (inventoryamortization.flag & 2 <> 0)  
		
		)
,0)
WHERE  #assetamortization.real_or_simulation IN('R','S')  

--SELECT '1#simula_assetamortization',* FROM #simula_assetamortization
--SELECT '1#assetamortization',* FROM #assetamortization
--select 'ammortamenti reali di tutti gli anni cespiti/accessori',finalvalue,* from #assetamortization

-------------------------------------------------------------------------------------
------------------------- AMMORTAMENTI SIMULATI -------------------------------------
-------------------------------------------------------------------------------------
--SELECT 2, * FROM #assetamortization

UPDATE #assetamortization
SET finalvalue = finalvalue + 
ISNULL(
	(SELECT
		SUM(ROUND(ISNULL(#simula_assetamortization.assetvalue_on_the_date,0) * 
		ISNULL(#simula_assetamortization.actual_amortizationquota,0),2))
	FROM #simula_assetamortization
	JOIN inventoryamortization
		ON #simula_assetamortization.idinventoryamortization=inventoryamortization.idinventoryamortization
	WHERE #assetamortization.idasset = #simula_assetamortization.idasset AND #simula_assetamortization.idpiece = #assetamortization.idpiece
	AND (inventoryamortization.flag & 2 <> 0)  
)
,0)
WHERE   #assetamortization.real_or_simulation  = 'S'
--select 'ammortamenti simulati di quest''anno cespiti/accessori',finalvalue,* from #assetamortization
 
 
--SELECT '2#assetamortization',* FROM #assetamortization

UPDATE #assetamortization
SET startvalue = isnull(finalvalue,0) - isnull(amortizationvalue,0)
 
--SELECT '3#assetamortization',* FROM #assetamortization

--select 'assetoriginalvalue',finalvalue,* from #assetamortization
--UPDATE #assetamortization
--SET startvalue = isnull(finalvalue,0)  

--select 'ammortamenti simulati  accessori beni  ', finalvalue from #assetamortization
	--SELECT '#assetamortization',* FROM #assetamortization
set @ss2= getdate()
print datediff(ms,@ss1,@ss2)
 

 
-- Azzera i valori per gli ammortamenti di eserc. prec. perchè se il bene è completamente  amm. ci saranno tante righe quanti sono gli ammort. negli anni precedenti, 
-- ma ora il suo valore sarà sempre 0
update #assetamortization set startvalue=0, namortization=null, amortizationquota = null , amortizationvalue = null 
where year(adate)<@year and finalvalue=0

--- CANCELLO AMMORTAMENTI REALI ANNI PRECEDENTI SU CESPITI COMPLETAMENTE AMMORTIZZATI
delete from #assetamortization where exists 
	(select * from #assetamortization A 
	where A.idasset = #assetamortization.idasset and A.idpiece = #assetamortization.idpiece
	AND startvalue=0 AND  finalvalue=0 
	AND year(A.adate) < @year   AND #assetamortization.adate < A.adate
	)
and year(#assetamortization.adate) <= @year -1
AND adate IS NOT NULL
AND  real_or_simulation = 'R' 

--- CANCELLO AMMORTAMENTI REALI ANNI PRECEDENTI SU CESPITI NON COMPLETAMENTE AMMORTIZZATI (SCARICATI PRIMA DELL'AMMORTAMENTO TOTALE)
--- /* DEGLI ANNI PRECEDENTI MOSTRO SOLO ULTIMO AMMORTAMENTO CHE AMMORTIZZA IL CESPITE ESCLUDENDO GLI ALTRI*/
delete from #assetamortization where  
year(#assetamortization.adate) <= @year -1
AND adate IS NOT NULL AND NOT (startvalue=0 AND  finalvalue=0 )
AND  real_or_simulation = 'R' 
 

SELECT distinct
		idasset,
		idpiece,
		lifestart,
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
		CASE --- non mostro il valore iniziale dato dai cespiti con inizio esistenza maggiore dell'esercizio precedente
			WHEN YEAR(lifestart)<= (@year-1) THEN  startvalue
			ELSE 0
		END as startvalue,
		finalvalue,
		namortization,
		amortizationquota,
		assetvalue,
		adate,
		amortizationvalue,
		real_or_simulation
	FROM #assetamortization
	JOIN inventorytree
		on #assetamortization.idinv = inventorytree.idinv
	WHERE ISNULL(finalvalue, 0) <> 0 OR ISNULL(@mostrabenitotammortizzati,'N') = 'S'
	OR ISNULL(real_or_simulation,'N') = 'S'
	ORDER BY adate, ninventory
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
--exec [rpt_registro_ammortamenti_ente_con_simulazione]  2022, 12, {d '2022-12-31'},'S', 5119, 5119 
--go
--exec [rpt_registro_ammortamenti_ente_con_simulazione1]  2023, 12, {d '2024-12-31'},'S', 5119, 5119 
--go



--exec [rpt_registro_ammortamenti_ente_con_simulazione]  2022, 12, {d '2022-12-31'},'S', null, null 

--exec [rpt_registro_ammortamenti_ente_con_simulazione]  2021, 12, {d '2023-12-31'},'S', null, null 
--go
--exec simulation_asset_ammortization_on_the_date 2023, {d '2028-12-31'}, 12, NULL, NULL   --112289

--exec simulation_asset_ammortization_on_the_date 2023, {d '2023-12-31'}, 12, 5119, 5119   --112289
--go
--exec simulation_asset_ammortization_on_the_date 2023, {d '2023-01-01'}, 12, 5119, 5119   --112289
--go
--exec simulation_asset_ammortization_on_the_date 2023, {d '2023-01-15'}, 12, 5119, 5119   --112289
--go
--exec simulation_asset_ammortization_on_the_date 2023, {d '2023-02-15'}, 12, 5119, 5119   --112289

--select * from assetview where ninventory= 8304  --110606

--declare @originalvalue	decimal (19,2) ;
--declare @totale  decimal (19,2) ;
--exec get_assetvalueatdate 110606,1,'12-31-2017', @originalvalue output ,@totale output

--select @originalvalue
--select @totale


--exec [rpt_registro_ammortamenti_ente_con_simulazione]  2024, 8, {d '2025-12-31'},'S', 8304, 8304 
--exec simulation_asset_ammortization_on_the_date 2023, {d '2023-12-31'}, 8, 8304, 8304   --112289


--exec simulation_asset_ammortization_on_the_date 2023, {d '2023-01-31'}, 8, 8304, 8304   --112289
--GO

--exec simulation_asset_ammortization_on_the_date 2023, {d '2025-12-31'}, 8, 8304, 8304   --112289

--exec simulation_asset_ammortization_on_the_date 2023, {d '2029-09-30'}, 8, 8304, 8304   --112289

--exec [rpt_registro_ammortamenti_ente_con_simulazione]  2023, 8, {d '2024-12-31'},'N', 8304, 8304 

--exec [rpt_registro_ammortamenti_ente_con_simulazione]  2023, 8, {d '2029-12-31'},'N', 8304, 8304 

--exec [rpt_registro_ammortamenti_ente_con_simulazione]  2023, 12, {d '2025-12-31'},'S', 5119, 5119 
--exec  rpt_registro_ammortamenti_ente_con_simulazione  2022, 8, {ts '2022-12-31 00:00:00'}, 'S', 8304, 8304

--exec  rpt_registro_ammortamenti_ente_con_simulazione  2024, 8, {ts '2027-01-16 00:00:00'}, 'S', 8304, 8304

--exec  rpt_registro_ammortamenti_ente_con_simulazione  2015, 8, {ts '2019-12-31 00:00:00'}, 'S', 7019, 7019

-- exec simulation_asset_ammortization_on_the_date 2024, {d '2025-01-16'}, 8, 7019, 7019   --112289







