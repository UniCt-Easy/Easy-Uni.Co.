--exp_checkclosepatr 2009,2012,1,'1','N'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_checkclosepatr]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_checkclosepatr]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE [exp_checkclosepatr]
	@year_start int,
	@year_stop int=null,
	@codinventoryagency int=null,
	@cat char(1)='S',
	@display_ever char(1)='N'
AS BEGIN
if @year_stop is null set @year_stop=@year_start

DECLARE @date datetime
	
DECLARE @firstday datetime

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
	codinventoryagency int,
	idinv int,
	initial_amount decimal(19,2),
	idmot int,
	var_aum decimal(19,2),
	var_dim decimal(19,2),
	car_cespiti decimal(19,2),
	rivalpos_all decimal(19,2),
	rivalneg_all decimal(19,2),
	scar_cespiti decimal(19,2),
	rival_allscar decimal(19,2),
	scaracc_benscar decimal(19,2),
	rival_accscar_benscar decimal(19,2),
	tot_aum  decimal(19,2),
	tot_dim	decimal(19,2),
	final_amount decimal(19,2),
	amount_nextyear decimal(19,2)
)

	-------------------------------------------------------------------------------------
	-------------------------- Situazione patrim. iniziale-------------------------------
	-------------------------------------------------------------------------------------

CREATE TABLE #cons_iniziale
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)

CREATE TABLE #diff_end 
(
	codinventoryagency int,
	idinv int,
	final_amount decimal(19,2),
	amount_nextyear decimal(19,2),
	initial_amount decimal(19,2),
	var_aum  decimal(19,2),
	rivalpos_all decimal(19,2),
	car  decimal(19,2), 
	tot_aum  decimal(19,2),  
	var_dim  decimal(19,2),
	rivalneg_all  decimal(19,2),
	scar  decimal(19,2),
	tot_dim  decimal(19,2),
	impliciti decimal(19,2)
)


CREATE TABLE #diff
(
	codinventoryagency int,
	idinv int,
	initial_amount decimal(19,2),
	idmot int,
	var_aum decimal(19,2),
	var_dim decimal(19,2),
	car_cespiti decimal(19,2),
	rivalpos_all decimal(19,2),
	rivalneg_all decimal(19,2),
	scar_cespiti decimal(19,2),
	rival_allscar decimal(19,2),
scaracc_benscar decimal(19,2),
	rival_accscar_benscar decimal(19,2),
	tot_aum  decimal(19,2),
	tot_dim	decimal(19,2),
	final_amount decimal(19,2)
)

CREATE TABLE #diffgrouped
(
	codinventoryagency int,
	idinv int,
	initial_amount decimal(19,2),
	idmot int,
	var_aum decimal(19,2),
	var_dim decimal(19,2),
	car_cespiti decimal(19,2),
	rivalpos_all decimal(19,2),
	rivalneg_all decimal(19,2),
	scar_cespiti decimal(19,2),
	rival_allscar decimal(19,2),
	scaracc_benscar decimal(19,2),
	rival_accscar_benscar decimal(19,2),
	tot_aum  decimal(19,2),
	tot_dim	decimal(19,2),
	final_amount decimal(19,2)
)

CREATE TABLE #variazione_aum
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)

CREATE TABLE #variazione_dim
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)
CREATE TABLE #caricocespiti
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)

CREATE TABLE #tempdata(	idente int, myid int, idmot int, valore decimal(19,2))

CREATE TABLE #rivalutazione_cespiti
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)

CREATE TABLE #cons_finale
(
	idinventoryagency int,
	descrinventoryagency varchar(150),
	idinv int,
	codesor1 varchar(50),
	nlevel1 tinyint,
	description1 varchar(150),
	start_cons decimal(19,2),
	cons_aum decimal(19,2),
	cons_dim decimal(19,2),
	dateend datetime,
	idassetvardetail int, 
	idinventory int,
	idmot int,
	car_cespiti decimal(19,2),
	rivalpos_all decimal(19,2),
	rivalneg_all decimal(19,2),
	scar_cespiti decimal(19,2),
	scar_acc decimal(19,2),
	rival_allscar decimal(19,2),
	scaracc_benscar decimal(19,2),
	rival_accscar_benscar decimal(19,2),
	tot_aum  decimal(19,2),
	tot_dim	decimal(19,2),
	final_amount decimal(19,2)

)


CREATE TABLE #svalutazione_cespiti
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)

CREATE TABLE #scaricocespiti
(
	idinventoryagency int,
	idinv int,
	idinventory int, 
	idmot int,
	total decimal(19,2)
)



declare @year int
declare @ayear int  --usata per la 2a parte
declare @idinventoryagency int --usata per la 2a parte
set @idinventoryagency = @codinventoryagency

set @year = @year_start

while (@year<=@year_stop)
BEGIN

SET 	@date = CONVERT(datetime, '31-12-' + CONVERT(char(4), @year), 105)
SET 	@firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)
set		 @ayear=@year






delete from #diff_end
delete from #patrimonio
delete from #cons_iniziale
DELETE FROM #tempdata
delete from #variazione_aum
delete from #variazione_dim
delete from #caricocespiti
delete from #rivalutazione_cespiti
delete from #cons_finale
delete from #svalutazione_cespiti
delete from #scaricocespiti


INSERT INTO #cons_iniziale
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	assetvar.idinventoryagency,
	assetvardetail.idinv,
	assetvardetail.idinventory,
	assetvardetail.idmot,
	ISNULL(SUM(assetvardetail.amount),0)
FROM assetvardetail
JOIN assetvar
	ON assetvar.idassetvar = assetvardetail.idassetvar
WHERE assetvar.flag & 1 = 0
	AND assetvar.yvar = @ayear
	AND assetvar.adate <= @date
	AND (assetvar.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
GROUP BY assetvar.idinventoryagency, assetvardetail.idinv, assetvardetail.idinventory,assetvardetail.idmot 


INSERT INTO #patrimonio
(codinventoryagency,idinv,idmot,initial_amount,var_aum,var_dim,car_cespiti,
			 rivalpos_all,rivalneg_all,	scar_cespiti ,	tot_aum  ,	tot_dim,amount_nextyear	
)
SELECT ENTE.idinventoryagency,CLASS.idinv,MOTIVE.idmot,
		0,0,0,0,0,0,0,0,0,0
FROM inventorytree CLASS 
CROSS JOIN inventoryagency ENTE
CROSS JOIN #assetloadmotive MOTIVE
WHERE (ENTE.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
	AND (ENTE.active = 'S'		
	OR (ENTE.active = 'N' AND (SELECT COUNT(*) from assetvar AV
									JOIN assetvardetail AVD
										ON AV.idassetvar = AVD.idassetvar
									JOIN inventory I
										ON AVD.idinventory = I.idinventory
									JOIN inventoryagency IA
										ON I.idinventoryagency = IA.idinventoryagency
								WHERE AVD.amount > 0
								AND datepart(yy,AV.adate) = @year
								AND ENTE.idinventoryagency = IA.idinventoryagency
								) >0
		)
	)


print 'L E G E N D A'	
-------------------------------------------------------------------------------------
-------------------------- Situazione patrim. iniziale-------------------------------
-------------------------------------------------------------------------------------
print 'initial_amount: le variazioni INIZIALI prese da assetvardetail avente segno positivo'
UPDATE #patrimonio SET initial_amount =
ISNULL((SELECT SUM(assetvardetail.amount)
FROM assetvardetail
JOIN assetvar
	ON assetvar.idassetvar = assetvardetail.idassetvar
	AND #patrimonio.idinv = assetvardetail.idinv
WHERE (assetvar.flag & 1 = 0)
	AND assetvar.yvar = @year
	AND assetvar.adate <= @date
	AND assetvar.idinventoryagency = #patrimonio.codinventoryagency
	AND ISNULL(assetvardetail.idmot,0) = ISNULL(#patrimonio.idmot,0)
	),0)

UPDATE #patrimonio SET amount_nextyear =
ISNULL((SELECT SUM(assetvardetail.amount)
FROM assetvardetail
JOIN assetvar
	ON assetvar.idassetvar = assetvardetail.idassetvar
	AND #patrimonio.idinv = assetvardetail.idinv
WHERE (assetvar.flag & 1 = 0)
	AND assetvar.yvar = @year+1
	AND assetvar.idinventoryagency = #patrimonio.codinventoryagency
	AND ISNULL(assetvardetail.idmot,0) = ISNULL(#patrimonio.idmot,0)
	),0)




-------------------------------------------------------------------------------------
-------------------------- Variazioni sit. patrim. ----------------------------------
-------------------------------------------------------------------------------------
print 'var_aum: le variazioni (non iniziali) prese da assetvardetail avente segno positivo'
UPDATE #patrimonio SET var_aum =	
ISNULL(
(SELECT	SUM(assetvardetail.amount)
FROM assetvardetail
JOIN assetvar
	ON assetvar.idassetvar = assetvardetail.idassetvar
	AND #patrimonio.idinv = assetvardetail.idinv
WHERE (assetvar.flag & 1 <> 0)
	AND assetvar.yvar = @year
	AND assetvar.adate <= @date
	AND assetvardetail.amount > 0
	AND ISNULL(assetvardetail.idmot,0) = ISNULL(#patrimonio.idmot,0)
	AND assetvar.idinventoryagency = #patrimonio.codinventoryagency
	),0)

print 'var_dim: le variazioni  (non iniziali) prese da assetvardetail avente segno negativo, cambiate di segno'
UPDATE #patrimonio SET var_dim =	
- ISNULL(
(SELECT SUM(assetvardetail.amount)
FROM assetvardetail
JOIN assetvar
	ON assetvar.idassetvar = assetvardetail.idassetvar
	AND #patrimonio.idinv = assetvardetail.idinv
WHERE (assetvar.flag & 1 <> 0)
	AND assetvar.yvar = @year
	AND assetvar.adate <= @date
	AND assetvardetail.amount < 0
	AND ISNULL(assetvardetail.idmot,0) = ISNULL(#patrimonio.idmot,0)
	AND assetvar.idinventoryagency = #patrimonio.codinventoryagency
	),0)
	
-------------------------------------------------------------------------------------
-------------------------- Carichi cespiti  CAR_CESPITI e ACCESSORI -----------------
-------------------------------------------------------------------------------------
print 'car_cespiti: costo preso da assetacquire prese nella data ratifica del buono di carico.'
INSERT INTO #tempdata(idente,myid,idmot,valore)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idmot,
	SUM(AC.start)
FROM assetacquire						
JOIN asset									ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC					on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetload								ON assetload.idassetload = assetacquire.idassetload
JOIN inventory								ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind							ON inventory.idinventorykind= inventorykind.idinventorykind
WHERE  assetload.yassetload <= @year		
	AND assetload.ratificationdate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL)
	AND ( (inventorykind.flag&2)=0)
GROUP BY inventory.idinventoryagency, assetacquire.idinv, assetacquire.idmot
	
UPDATE #patrimonio SET car_cespiti = ISNULL(car_cespiti,0) +
ISNULL( 
	(SELECT SUM(valore) 
	   FROM #tempdata 
	  WHERE idente = #patrimonio.codinventoryagency 
	    AND myid=#patrimonio.idinv
	    AND idmot=#patrimonio.idmot
)
,0)

DELETE FROM #tempdata

-------------------------------------------------------------------------------------
----- Rivalutazioni positive ufficiali (di BENI E DI ACCESSORI) rivalpos_all ---------------------
-------------------------------------------------------------------------------------
print 'rivalpos_all: Rivalutazioni positive ufficiali (di BENI E DI ACCESSORI) prese nella data contabile (adate)'
INSERT INTO #tempdata(idente,myid,idmot,valore)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idmot,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset								ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization					ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetload				ON  assetamortization.idassetload = assetload.idassetload
JOIN inventory							ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind						ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization				ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
WHERE  (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota >= 0
	AND 
	(
		(
		 ((assetamortization.flag & 1 = 0)
		  AND assetamortization.adate BETWEEN @firstday AND @date) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)
                   AND assetload.ratificationdate BETWEEN @firstday AND @date)
		)
	)
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
	AND ( (inventorykind.flag&2)=0)

GROUP BY inventory.idinventoryagency, assetacquire.idinv, assetacquire.idmot

UPDATE #patrimonio SET rivalpos_all= ISNULL(rivalpos_all,0) +
ISNULL( 
	(SELECT SUM(valore) FROM #tempdata 
	  WHERE idente = #patrimonio.codinventoryagency 
	    AND myid=#patrimonio.idinv
	    AND ISNULL(idmot,0)=ISNULL(#patrimonio.idmot,0)
)
,0)

DELETE FROM #tempdata

-------------------------------------------------------------------------------------
-------- Rivalutazioni Negative ufficiali  (di BENI E DI ACCESSORI)  rivalneg_all
-------------------------------------------------------------------------------------
print 'rivalneg_all: Rivalutazioni Negative ufficiali (di BENI E DI ACCESSORI) prese nella data contabile o nella data del buono se richiesto'

INSERT INTO #tempdata(idente,myid,idmot,valore)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idmot,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset								ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization					ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload				ON  assetamortization.idassetunload = assetunload.idassetunload
JOIN inventory							ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind						ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization				ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
WHERE  
	 (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0 AND
	(
		(
		 ((assetamortization.flag & 1 = 0)
		  AND assetamortization.adate BETWEEN @firstday AND @date) 
		  OR 
		  ((assetamortization.flag & 1 <> 0)
                   AND assetunload.adate BETWEEN @firstday AND @date)
		)
	)
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
	AND ( (inventorykind.flag&2)=0)
GROUP BY inventory.idinventoryagency, assetacquire.idinv, assetacquire.idmot

UPDATE #patrimonio SET rivalneg_all=  
	ISNULL( 
		(SELECT SUM(valore) FROM #tempdata 
		WHERE idente = #patrimonio.codinventoryagency 
		  AND myid=#patrimonio.idinv
		  AND ISNULL(idmot,0)=ISNULL(#patrimonio.idmot,0)
)
	,0)

DELETE FROM #tempdata

	

-------------------------------------------------------------------------------------
-------------------------- Scarichi Cespite  e ACCESSORI scar_cespiti  -------------------
-----------------------------------------------------------------------------------
print 'scar_cespiti: valore corrente dei cespiti che stiamo scaricando (la data considerata è quella del buono di scarico)' 

--    	Considera i buoni di carico precedenti al 2005 
INSERT INTO #tempdata(idente,myid,idmot,valore)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idmot,
	SUM(AC.currentvalue)
FROM assetacquire
LEFT OUTER JOIN assetload					ON assetload.idassetload = assetacquire.idassetload
JOIN asset									ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC					on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece
JOIN assetunload							ON assetunload.idassetunload = asset.idassetunload
JOIN inventory								ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind							ON inventory.idinventorykind= inventorykind.idinventorykind   
WHERE assetunload.yassetunload <= @year
	AND assetunload.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @codinventoryagency OR @codinventoryagency IS NULL )
GROUP BY inventory.idinventoryagency, assetacquire.idinv,assetacquire.idmot


UPDATE #patrimonio SET scar_cespiti=  
	ISNULL( 
		(SELECT SUM(valore) FROM #tempdata 
		WHERE idente = #patrimonio.codinventoryagency 
		  AND myid=#patrimonio.idinv
		  AND ISNULL(idmot,0)=ISNULL(#patrimonio.idmot,0)
)
	,0)

DELETE FROM #tempdata



print ' -------------------------------------------------'
print ' tot_aum = var_aum + car_cespiti + rivalpos_all '
print ' tot_dim = var_dim  - rivalneg_all + scar_cespiti   '
print ' ossia var_dim= gli scarichi che stiamo facendo '

	update #patrimonio set 
		tot_aum = var_aum + car_cespiti +  rivalpos_all,
		tot_dim = var_dim  - rivalneg_all + scar_cespiti 

	update #patrimonio set final_amount= initial_amount+tot_aum-tot_dim













	

--select * from #cons_iniziale


	-------------------------------------------------------------------------------------
	-------------------------- Variazioni sit. patrim. ----------------------------------
	-------------------------------------------------------------------------------------

	
INSERT INTO #variazione_aum
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	assetvar.idinventoryagency,
	assetvardetail.idinv,
	assetvardetail.idinventory,
	assetvardetail.idmot,
	ISNULL(SUM(assetvardetail.amount),0)
FROM assetvardetail
JOIN assetvar						ON assetvar.idassetvar = assetvardetail.idassetvar
WHERE assetvar.flag & 1 <> 0
	AND assetvar.yvar = @ayear
	AND assetvar.adate <= @date
	AND assetvardetail.amount > 0
	AND (assetvar.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
GROUP BY assetvar.idinventoryagency, assetvardetail.idinv, assetvardetail.idinventory,assetvardetail.idmot 
	
INSERT INTO #variazione_dim
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	assetvar.idinventoryagency,
	assetvardetail.idinv,
	assetvardetail.idinventory,
	assetvardetail.idmot, 
	ISNULL(SUM(assetvardetail.amount),0)
FROM assetvardetail
JOIN assetvar						ON assetvar.idassetvar = assetvardetail.idassetvar
WHERE assetvar.flag & 1 <> 0
	AND assetvar.yvar = @ayear
	AND assetvar.adate <= @date
	AND assetvardetail.amount < 0
	AND (assetvar.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
GROUP BY assetvar.idinventoryagency, assetvardetail.idinv, assetvardetail.idinventory,assetvardetail.idmot

	-------------------------------------------------------------------------------------
	-------------------------- Carichi cespiti  E accessori -----------------------------
	-------------------------------------------------------------------------------------
-- E' stata utilizzata la UNION in modo da considerare i buoni di carico precedenti al 2005 
-- (ai quali si applica lo sconto)
-- e quelli successivi al 2005 per i quali lo sconto si applica in base al flagdiscount
INSERT INTO #caricocespiti
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idinventory,
	assetacquire.idmot,
	ISNULL(SUM(AC.start),0)
FROM assetacquire
JOIN asset									ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC					on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece
JOIN assetload								ON assetload.idassetload = assetacquire.idassetload
JOIN inventory								ON assetacquire.idinventory=inventory.idinventory
JOIN inventorykind							ON inventory.idinventorykind = inventorykind.idinventorykind
	WHERE assetload.yassetload <= @ayear  
		AND assetload.ratificationdate BETWEEN @firstday AND @date
		AND (inventory.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
		AND ( (inventorykind.flag&2)=0)
GROUP BY inventory.idinventoryagency, assetacquire.idinv, assetacquire.idinventory,assetacquire.idmot

-------------------------------------------------------------------------------------
---- Rivalutazioni positive ufficiali (di CESPITI E DI ACCESSORI) -------------------
-------------------------------------------------------------------------------------


INSERT INTO #rivalutazione_cespiti
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idinventory,
	assetacquire.idmot,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset							ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization				ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetload			ON  assetamortization.idassetload = assetload.idassetload
JOIN inventory						ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind					ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization			ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
WHERE  
	(inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota > 0 AND
	(
		(
		 ((assetamortization.flag & 1 = 0) 
		  AND assetamortization.adate BETWEEN @firstday AND @date)
		  OR 
		  ((assetamortization.flag & 1 <> 0)
	           AND assetload.ratificationdate BETWEEN @firstday AND @date)
		)
	)
	AND assetamortization.adate BETWEEN @firstday AND @date
	AND (inventory.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND ( (inventorykind.flag&2)=0)

GROUP BY inventory.idinventoryagency, assetacquire.idinv, assetacquire.idinventory,assetacquire.idmot

-------------------------------------------------------------------------------------
----- Rivalutazioni Negative ufficiali  (di CESPITI E DI ACCESSORI) -----------------
-------------------------------------------------------------------------------------
INSERT INTO #svalutazione_cespiti
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idinventory,
	assetacquire.idmot,
	SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * ISNULL(assetamortization.amortizationquota,0),2))
FROM assetacquire
JOIN asset						ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetamortization			ON assetamortization.idasset = asset.idasset and assetamortization.idpiece = asset.idpiece
LEFT OUTER JOIN assetunload		ON  assetamortization.idassetunload = assetunload.idassetunload
JOIN inventory					ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind				ON inventory.idinventorykind= inventorykind.idinventorykind
JOIN inventoryamortization		ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
WHERE 
	 (inventoryamortization.flag & 2 <> 0)
	AND assetamortization.amortizationquota < 0 AND
	(
		(
		 ((assetamortization.flag & 1 = 0) 
		  AND assetamortization.adate BETWEEN @firstday AND @date)
		  OR 
		  ((assetamortization.flag & 1 <> 0)
	           AND assetunload.adate BETWEEN @firstday AND @date)
		)
	)
	AND (inventory.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND ( (inventorykind.flag&2)=0)
GROUP BY inventory.idinventoryagency,assetacquire.idinv, assetacquire.idinventory,assetacquire.idmot



--------------------------------------------------------------------------------------
-------------------------- Scarichi Cespite E Accessori ------------------------------
--------------------------------------------------------------------------------------


INSERT INTO #scaricocespiti
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	total
)
SELECT
	inventory.idinventoryagency,
	assetacquire.idinv,
	assetacquire.idinventory,
	assetacquire.idmot,
	ISNULL(SUM(AC.currentvalue)	,0)
FROM assetacquire 
LEFT OUTER JOIN assetload				ON assetload.idassetload = assetacquire.idassetload
JOIN asset								ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC				on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetunload						ON assetunload.idassetunload = asset.idassetunload
JOIN inventory							ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind						ON inventory.idinventorykind = inventorykind.idinventorykind
WHERE   assetunload.yassetunload <= @ayear
	AND assetunload.adate BETWEEN @firstday AND @date	
	AND (inventory.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)
	AND ( (inventorykind.flag&2)=0)
GROUP BY inventory.idinventoryagency, assetacquire.idinv, assetacquire.idinventory, assetacquire.idmot




INSERT INTO #cons_finale
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	start_cons,cons_aum,cons_dim,
			car_cespiti,rivalpos_all,
			rivalneg_all,	scar_cespiti ,	tot_aum  ,	tot_dim	
)
SELECT 
	inventoryagency.idinventoryagency,
	inventorytreeusable.idinv,
	inventory.idinventory,
	#assetloadmotive.idmot,
			0,0,0,0,0,0,0,0,0
FROM inventorytreeusable
CROSS JOIN inventoryagency
CROSS JOIN #assetloadmotive
JOIN inventory			ON inventoryagency.idinventoryagency = inventory.idinventoryagency
JOIN inventorykind				ON inventory.idinventorykind= inventorykind.idinventorykind
WHERE (@idinventoryagency IS NULL OR inventoryagency.idinventoryagency = @idinventoryagency)
	AND (@idinventoryagency IS NULL OR inventory.idinventoryagency = @idinventoryagency)
	AND ( (inventorykind.flag&2)=0)


INSERT INTO #cons_finale
(
	idinventoryagency,
	idinv,
	idinventory,
	idmot,
	start_cons,cons_aum,cons_dim,
			car_cespiti, rivalpos_all,
			rivalneg_all,	scar_cespiti ,		tot_aum  ,	tot_dim	
)
SELECT
	inventoryagency.idinventoryagency,
	inventorytreeusable.idinv,
	null,
	#assetloadmotive.idmot,
			0,0,0,0,0,0,0,0,0
FROM inventorytreeusable
CROSS JOIN inventoryagency
CROSS JOIN #assetloadmotive
WHERE (@idinventoryagency IS NULL OR inventoryagency.idinventoryagency = @idinventoryagency)
	
UPDATE #cons_finale
SET start_cons = 
ISNULL(
	(SELECT ISNULL(SUM(total),0)
	FROM #cons_iniziale
	WHERE #cons_iniziale.idinv = #cons_finale.idinv
		AND #cons_iniziale.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#cons_iniziale.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#cons_iniziale.idmot, 0) = ISNULL(#cons_finale.idmot, 0))
, 0)

UPDATE #cons_finale
SET cons_aum =
ISNULL(
	(SELECT total
	FROM #variazione_aum
	WHERE #variazione_aum.idinv = #cons_finale.idinv
		AND #variazione_aum.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#variazione_aum.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#variazione_aum.idmot, 0) = ISNULL(#cons_finale.idmot, 0))
, 0) 

			-- era +
UPDATE #cons_finale
SET car_cespiti =
ISNULL(
	(SELECT ISNULL(SUM(total),0)
        FROM #caricocespiti
        WHERE #caricocespiti.idinv = #cons_finale.idinv
	        AND #caricocespiti.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#caricocespiti.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#caricocespiti.idmot, 0) = ISNULL(#cons_finale.idmot, 0))
, 0)  


			-- era +

UPDATE #cons_finale
SET rivalpos_all  =
ISNULL(
	(SELECT total
	FROM #rivalutazione_cespiti
	WHERE #rivalutazione_cespiti.idinv = #cons_finale.idinv
		AND #rivalutazione_cespiti.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#rivalutazione_cespiti.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#rivalutazione_cespiti.idmot, 0) = ISNULL(#cons_finale.idmot, 0))
, 0)


UPDATE #cons_finale
SET cons_dim = 
-- var in diminuzioni patrimoniali
- ISNULL(
	(SELECT total
        FROM #variazione_dim
        WHERE #variazione_dim.idinv = #cons_finale.idinv
		AND #variazione_dim.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#variazione_dim.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#variazione_dim.idmot, 0) = ISNULL(#cons_finale.idmot, 0)
		)
, 0) 

			--era -  
UPDATE #cons_finale
SET rivalneg_all  = 
ISNULL(
	(SELECT total
	FROM #svalutazione_cespiti
	WHERE #svalutazione_cespiti.idinv = #cons_finale.idinv
		AND #svalutazione_cespiti.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#svalutazione_cespiti.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#svalutazione_cespiti.idmot, 0) = ISNULL(#cons_finale.idmot, 0)
)
, 0)



			--era +
UPDATE #cons_finale
SET scar_cespiti = 
ISNULL(
	(SELECT ISNULL(SUM(total),0)
        FROM #scaricocespiti
        WHERE #scaricocespiti.idinv = #cons_finale.idinv
		AND #scaricocespiti.idinventoryagency = #cons_finale.idinventoryagency
		AND ISNULL(#scaricocespiti.idinventory, 0) = ISNULL(#cons_finale.idinventory, 0)
		AND ISNULL(#scaricocespiti.idmot, 0) = ISNULL(#cons_finale.idmot, 0)
		)
, 0) 




update #cons_finale set 
		tot_aum = cons_aum + car_cespiti + rivalpos_all,
		tot_dim = cons_dim  - rivalneg_all + scar_cespiti 

update #cons_finale set final_amount= start_cons+tot_aum-tot_dim

--select * from #cons_finale where
--		(isnull(start_cons,0) <> 0) or (isnull(tot_dim,0) <> 0) or (isnull(tot_aum,0) <> 0) or (isnull(final_amount,0) <> 0) 

	if (@display_ever='S' and @cat='N')
	BEGIN
	SELECT 
		'@display_ever #patrimonio' as label,
		ENTE.codeinventoryagency AS 'codinventoryagency',
		CLASS.codeinv as 'codeinv',
		CLASS.description,
		ISNULL(SUM(initial_amount),0) as 'initialamount',

		ISNULL(SUM(var_aum),0) as 'var_aum',
		ISNULL(SUM(car_cespiti),0) as 'car_cespiti',
		ISNULL(SUM(rivalpos_all),0) as 'rivalpos_all',
		ISNULL(SUM(tot_aum),0) as 'tot_aum',

		ISNULL(SUM(var_dim),0) as 'var_dim',
		ISNULL(SUM(rivalneg_all),0) as 'rivalneg_all',
		ISNULL(SUM(scar_cespiti),0) as 'scar_cespiti',
		ISNULL(SUM(tot_dim),0) as 'tot_dim',
		ISNULL(SUM(final_amount),0) as 'final_amount',
		ISNULL(SUM(amount_nextyear),0) as 'amount_nextyear'
	FROM #patrimonio
	LEFT OUTER JOIN inventorytree CLASS 
		ON CLASS.idinv = #patrimonio.idinv
	LEFT OUTER JOIN inventoryagency	ENTE
		ON ENTE.idinventoryagency = #patrimonio.codinventoryagency
	GROUP BY ENTE.codeinventoryagency, CLASS.codeinv, CLASS.description	
	ORDER BY  ENTE.codeinventoryagency, codeinv
	




	
	SELECT 
		'@display_ever #cons_finale' as label,
		ENTE.codeinventoryagency AS 'codinventoryagency',
		CLASS.codeinv as 'codeinv',
		CLASS.description,
		ISNULL(SUM(start_cons),0) as 'initialamount',

		ISNULL(SUM(cons_aum),0) as 'var_aum',
		ISNULL(SUM(car_cespiti),0) as 'car_cespiti',
		ISNULL(SUM(rivalpos_all),0) as 'rivalpos_all',
		ISNULL(SUM(tot_aum),0) as 'tot_aum',

		ISNULL(SUM(cons_dim),0) as 'var_dim',
		ISNULL(SUM(rivalneg_all),0) as 'rivalneg_all',
		ISNULL(SUM(scar_cespiti),0) as 'scar_cespiti',
		ISNULL(SUM(tot_dim),0) as 'tot_dim',

		ISNULL(SUM(final_amount),0) as 'final_amount'

	FROM #cons_finale
	LEFT OUTER JOIN inventorytree CLASS					ON CLASS.idinv = #cons_finale.idinv
	LEFT OUTER JOIN inventoryagency	ENTE				ON ENTE.idinventoryagency = #cons_finale.idinventoryagency
	GROUP BY ENTE.codeinventoryagency, CLASS.codeinv, CLASS.description
	ORDER BY  ENTE.codeinventoryagency, codeinv
	END

	if (@display_ever='S' and @cat='S')
	BEGIN
	SELECT 
		'@display_ever #patrimonio' as label,
		ENTE.codeinventoryagency AS 'codinventoryagency',
		CLASS1.codeinv as 'codeinv',
		CLASS1.description,
		ISNULL(SUM(initial_amount),0) as 'initialamount',

		ISNULL(SUM(var_aum),0) as 'var_aum',
		ISNULL(SUM(car_cespiti),0) as 'car_cespiti',
		ISNULL(SUM(rivalpos_all),0) as 'rivalpos_all',
		ISNULL(SUM(tot_aum),0) as 'tot_aum',

		ISNULL(SUM(var_dim),0) as 'var_dim',
		ISNULL(SUM(rivalneg_all),0) as 'rivalneg_all',
		ISNULL(SUM(scar_cespiti),0) as 'scar_cespiti',
		ISNULL(SUM(tot_dim),0) as 'tot_dim',

		ISNULL(SUM(final_amount),0) as 'final_amount',
		ISNULL(SUM(amount_nextyear),0) as 'amount_nextyear'
	FROM #patrimonio
	JOIN inventorytreelink CLASS1L					ON CLASS1L.idchild = #patrimonio.idinv AND CLASS1L.nlevel=1 
	JOIN inventorytree CLASS1						ON CLASS1L.idparent = CLASS1.idinv
	LEFT OUTER JOIN inventoryagency	ENTE			ON ENTE.idinventoryagency = #patrimonio.codinventoryagency
	GROUP BY ENTE.codeinventoryagency, CLASS1.codeinv, CLASS1.description	
	ORDER BY  ENTE.codeinventoryagency, CLASS1.codeinv
	




	
	SELECT 
		'@display_ever #cons_finale' as label,
		ENTE.codeinventoryagency AS 'codinventoryagency',
		CLASS1.codeinv as 'codeinv',
		CLASS1.description,
		ISNULL(SUM(start_cons),0) as 'initialamount',

		ISNULL(SUM(cons_aum),0) as 'var_aum',
		ISNULL(SUM(car_cespiti),0) as 'car_cespiti',
		ISNULL(SUM(rivalpos_all),0) as 'rivalpos_all',
		ISNULL(SUM(tot_aum),0) as 'tot_aum',

		ISNULL(SUM(cons_dim),0) as 'var_dim',
		ISNULL(SUM(rivalneg_all),0) as 'rivalneg_all',
		ISNULL(SUM(scar_cespiti),0) as 'scar_cespiti',
		ISNULL(SUM(tot_dim),0) as 'tot_dim',

		ISNULL(SUM(final_amount),0) as 'final_amount'

	FROM #cons_finale
	JOIN inventorytreelink CLASS1L						ON CLASS1L.idchild = #cons_finale.idinv AND CLASS1L.nlevel=1 
	JOIN inventorytree CLASS1							ON CLASS1L.idparent = CLASS1.idinv
	LEFT OUTER JOIN inventoryagency	ENTE				ON ENTE.idinventoryagency = #cons_finale.idinventoryagency
	GROUP BY ENTE.codeinventoryagency, CLASS1.codeinv, CLASS1.description
	ORDER BY  ENTE.codeinventoryagency, CLASS1.codeinv
	END






	insert into #diff (codinventoryagency,idinv,initial_amount,idmot,var_aum,var_dim,
				car_cespiti,rivalpos_all,rivalneg_all,scar_cespiti,	tot_aum,tot_dim,final_amount)
	select codinventoryagency, idinv,
			initial_amount,idmot,var_aum,var_dim,
				car_cespiti,rivalpos_all,rivalneg_all,
							scar_cespiti,tot_aum,tot_dim,final_amount 
	from #patrimonio

	insert into #diff (codinventoryagency,idinv,initial_amount,idmot,var_aum,var_dim,
				car_cespiti,rivalpos_all,rivalneg_all,scar_cespiti,	tot_aum,tot_dim,final_amount)
	select idinventoryagency,
			idinv,
			-start_cons,idmot,-cons_aum,-cons_dim,
				-car_cespiti,-rivalpos_all,-rivalneg_all,-scar_cespiti,	-tot_aum,-tot_dim,-final_amount 
	from #cons_finale
	
	
	insert into #diffgrouped (codinventoryagency,idinv,initial_amount,idmot,var_aum,var_dim,
				car_cespiti,rivalpos_all,rivalneg_all,scar_cespiti,	tot_aum,tot_dim,final_amount)
		select codinventoryagency,idinv,  SUM(initial_amount), idmot, sum(var_aum), sum(var_dim),
				sum(car_cespiti),sum(rivalpos_all),sum(rivalneg_all),sum(scar_cespiti),	
						sum(tot_aum),sum(tot_dim),sum(final_amount)
		from #diff
		group by codinventoryagency,idinv,idmot
		having isnull(SUM(initial_amount),0)<>0 or 
				isnull(sum(var_aum),0)<>0 or 
				isnull(sum(var_dim),0)<>0 or
				isnull(sum(car_cespiti),0)<>0 or 
				isnull(sum(rivalpos_all),0)<>0 or 
				isnull(sum(rivalneg_all),0)<>0 or 
				isnull(sum(scar_cespiti),0)<>0 or	
				isnull(sum(tot_aum),0)<>0 or 
				isnull(sum(tot_dim),0)<>0  or 
				isnull(sum(final_amount),0)<>0


	/*
	if (select count(*) from #diffgrouped)=0 
	BEGIN
		select @ayear as anno, 'nessuna differenza' as 'Differenza tra chiusura RIcalcolata e sit.patrimoniale fine anno'
	END
	*/
	if (select count(*) from #diffgrouped)<>0 
	BEGIN

	
	if (@cat='N')
	BEGIN

			SELECT 
				null as 'Differenze',
				@ayear as 'anno',
				ENTE.codeinventoryagency AS 'codinventoryagency',
				CLASS.codeinv as 'codeinv',
				CLASS.description,
				initial_amount ,
				idmot,var_aum, var_dim,car_cespiti,rivalpos_all,rivalneg_all,scar_cespiti, tot_aum,tot_dim,final_amount

			FROM #diffgrouped
			LEFT OUTER JOIN inventorytree CLASS				ON CLASS.idinv = #diffgrouped.idinv
			LEFT OUTER JOIN inventoryagency	ENTE			ON ENTE.idinventoryagency = #diffgrouped.codinventoryagency
			ORDER BY  ENTE.codeinventoryagency, codeinv	


			SELECT 
				ENTE.codeinventoryagency AS 'codinventoryagency',
				CLASS.codeinv as 'codeinv',
				CLASS.description,
				ISNULL(SUM(#diffgrouped.initial_amount),0) as 'initialamount',

				ISNULL(SUM(#diffgrouped.var_aum),0) as 'var_aum',
				ISNULL(SUM(#diffgrouped.car_cespiti),0) as 'car_cespiti',
				ISNULL(SUM(#diffgrouped.rivalpos_all),0) as 'rivalpos_all',
				ISNULL(SUM(#diffgrouped.tot_aum),0) as 'tot_aum',

				ISNULL(SUM(#diffgrouped.var_dim),0) as 'var_dim',
				ISNULL(SUM(#diffgrouped.rivalneg_all),0) as 'rivalneg_all',
				ISNULL(SUM(#diffgrouped.scar_cespiti),0) as 'scar_cespiti',
				ISNULL(SUM(#diffgrouped.tot_dim),0) as 'tot_dim',				

				ISNULL(SUM(#diffgrouped.final_amount),0) as 'final_amount'

			FROM #patrimonio
			join #diffgrouped 
					on isnull(#patrimonio.codinventoryagency,0) = isnull(#diffgrouped.codinventoryagency,0)
					AND isnull(#patrimonio.idinv,0) =isnull(#diffgrouped.idinv,0)
					AND isnull(#patrimonio.idmot,0) = isnull(#diffgrouped.idmot,0)
			LEFT OUTER JOIN inventorytree CLASS				ON CLASS.idinv = #patrimonio.idinv
			LEFT OUTER JOIN inventoryagency	ENTE			ON ENTE.idinventoryagency = #patrimonio.codinventoryagency
			GROUP BY ENTE.codeinventoryagency, CLASS.codeinv, CLASS.description
			having ISNULL(SUM(#diffgrouped.final_amount),0)<>0 or ISNULL(SUM(#diffgrouped.tot_aum),0)<>0 
						or ISNULL(SUM(#diffgrouped.tot_dim),0)<>0 or ISNULL(SUM(#diffgrouped.initial_amount),0)<>0 
			ORDER BY  ENTE.codeinventoryagency, CLASS.codeinv
			

			SELECT '#cons_finale1' as label,
					ENTE.codeinventoryagency AS 'codinventoryagency',
					CLASS.codeinv as 'codeinv',
					CLASS.description,
					ISNULL(SUM(#cons_finale.start_cons),0) as 'initialamount',

					ISNULL(SUM(#cons_finale.cons_aum),0) as 'var_aum',
					ISNULL(SUM(#cons_finale.car_cespiti),0) as 'car_cespiti',
					ISNULL(SUM(#cons_finale.rivalpos_all),0) as 'rivalpos_all',
					ISNULL(SUM(#cons_finale.tot_aum),0) as 'tot_aum',

					ISNULL(SUM(#cons_finale.cons_dim),0) as 'var_dim',
					ISNULL(SUM(#cons_finale.rivalneg_all),0) as 'rivalneg_all',
					ISNULL(SUM(#cons_finale.scar_cespiti),0) as 'scar_cespiti',
					ISNULL(SUM(#cons_finale.tot_dim),0) as 'tot_dim',
					ISNULL(SUM(#cons_finale.final_amount),0) as 'final_amount'

				FROM #cons_finale
					join #diffgrouped 
					on isnull(#cons_finale.idinventoryagency,0) = isnull(#diffgrouped.codinventoryagency,0)
					AND isnull(#cons_finale.idinv,0) =isnull(#diffgrouped.idinv,0)
					AND isnull(#cons_finale.idmot,0) = isnull(#diffgrouped.idmot,0)
				LEFT OUTER JOIN inventorytree CLASS			ON CLASS.idinv = #cons_finale.idinv
				LEFT OUTER JOIN inventoryagency	ENTE		ON ENTE.idinventoryagency = #cons_finale.idinventoryagency
				GROUP BY ENTE.codeinventoryagency, CLASS.codeinv, CLASS.description
				having ISNULL(SUM(#cons_finale.final_amount),0)<>0 or ISNULL(SUM(#cons_finale.tot_aum),0)<>0 
							or ISNULL(SUM(#cons_finale.tot_dim),0)<>0 or ISNULL(SUM(#cons_finale.start_cons),0)<>0 
				ORDER BY  ENTE.codeinventoryagency, CLASS.codeinv

	END
	else 
	begin
			SELECT 
			'#situazione' as label,
			@ayear as 'anno',
			ENTE.codeinventoryagency AS 'codinventoryagency',
			CLASS1.codeinv as 'codeinv',
			CLASS1.description,
			SUM(initial_amount) as 'initial_amount', idmot, 
					sum(var_aum) as 'var_aum', sum(var_dim) as 'var_dim',
						sum(car_cespiti) as 'car_cespiti',
					sum(rivalpos_all) as 'rivalpos_all' ,
					sum(rivalneg_all) as 'rivalneg_all',
					sum(scar_cespiti) as 'scar_cespiti',	
					sum(tot_aum)as 'tot_aum',
					sum(tot_dim) as 'tot_dim',
					sum(final_amount) as 'final_amount'

			FROM #diffgrouped
			JOIN inventorytreelink CLASS1L				ON CLASS1L.idchild = #diffgrouped.idinv AND CLASS1L.nlevel=1 
			JOIN inventorytree CLASS1					ON CLASS1L.idparent = CLASS1.idinv
			LEFT OUTER JOIN inventoryagency	ENTE		ON ENTE.idinventoryagency = #diffgrouped.codinventoryagency
			GROUP BY ENTE.codeinventoryagency, CLASS1.codeinv, CLASS1.description,idmot
			having ISNULL(SUM(final_amount),0)<>0 or ISNULL(SUM(tot_aum),0)<>0 
						or ISNULL(SUM(tot_dim),0)<>0 or ISNULL(SUM(initial_amount),0)<>0 
			ORDER BY  ENTE.codeinventoryagency, codeinv	


			SELECT 
				'#patrimonio0'  as label,
				ENTE.codeinventoryagency AS 'codinventoryagency',
				CLASS1.codeinv as 'codeinv',
				CLASS1.description,
				ISNULL(SUM(#patrimonio.initial_amount),0) as 'initialamount',

				ISNULL(SUM(#patrimonio.var_aum),0) as 'var_aum',
				ISNULL(SUM(#patrimonio.car_cespiti),0) as 'car_cespiti',
				ISNULL(SUM(#patrimonio.rivalpos_all),0) as 'rivalpos_all',
				ISNULL(SUM(#patrimonio.tot_aum),0) as 'tot_aum',

				ISNULL(SUM(#patrimonio.var_dim),0) as 'var_dim',
				ISNULL(SUM(#patrimonio.rivalneg_all),0) as 'rivalneg_all',
				ISNULL(SUM(#patrimonio.scar_cespiti),0) as 'scar_cespiti',
				ISNULL(SUM(#patrimonio.tot_dim),0) as 'tot_dim',

				ISNULL(SUM(#patrimonio.final_amount),0) as 'final_amount'

			FROM #patrimonio
			JOIN inventorytreelink CLASS1L			ON CLASS1L.idchild = #patrimonio.idinv AND CLASS1L.nlevel=1 
			JOIN inventorytree CLASS1				ON CLASS1L.idparent = CLASS1.idinv
		
			join #diffgrouped 
					on isnull(#patrimonio.codinventoryagency,0) = isnull(#diffgrouped.codinventoryagency,0)
						AND isnull(CLASS1L.idparent,0) =isnull(#diffgrouped.idinv,0)
						AND isnull(#patrimonio.idmot,0) = isnull(#diffgrouped.idmot,0)
			LEFT OUTER JOIN inventoryagency	ENTE		ON ENTE.idinventoryagency = #patrimonio.codinventoryagency
			GROUP BY ENTE.codeinventoryagency, CLASS1.codeinv, CLASS1.description
			ORDER BY  ENTE.codeinventoryagency, CLASS1.codeinv
			

			SELECT 
					'#cons_finale0'  as label,
					ENTE.codeinventoryagency AS 'codinventoryagency',
					CLASS.codeinv as 'codeinv',
					CLASS.description,
					ISNULL(SUM(#cons_finale.start_cons),0) as 'initialamount',

					ISNULL(SUM(#cons_finale.cons_aum),0) as 'var_aum',
					ISNULL(SUM(#cons_finale.car_cespiti),0) as 'car_cespiti',
					ISNULL(SUM(#cons_finale.rivalpos_all),0) as 'rivalpos_all',
					ISNULL(SUM(#cons_finale.tot_aum),0) as 'tot_aum',

					ISNULL(SUM(#cons_finale.cons_dim),0) as 'var_dim',
					ISNULL(SUM(#cons_finale.rivalneg_all),0) as 'rivalneg_all',
					ISNULL(SUM(#cons_finale.scar_cespiti),0) as 'scar_cespiti',
					ISNULL(SUM(#cons_finale.tot_dim),0) as 'tot_dim',

					ISNULL(SUM(#cons_finale.final_amount),0) as 'final_amount'

				FROM #cons_finale
					JOIN inventorytreelink CLASS1				ON CLASS1.idchild = #cons_finale.idinv AND CLASS1.nlevel=1 
					JOIN inventorytree CLASS					ON CLASS1.idparent = CLASS.idinv		
					join #diffgrouped							on isnull(#cons_finale.idinventoryagency,0) = isnull(#diffgrouped.codinventoryagency,0)
																	AND isnull(CLASS1.idparent,0) =isnull(#diffgrouped.idinv,0)
																	AND isnull(#cons_finale.idmot,0) = isnull(#diffgrouped.idmot,0)
				LEFT OUTER JOIN inventoryagency	ENTE			ON ENTE.idinventoryagency = #cons_finale.idinventoryagency
				GROUP BY ENTE.codeinventoryagency, CLASS.codeinv, CLASS.description
				ORDER BY  ENTE.codeinventoryagency, codeinv

		END

	end





	if (select count(*) from #patrimonio where isnull(amount_nextyear,0)<>isnull(final_amount,0))=0 
	BEGIN
		select @ayear as anno, 'nessuna differenza' as 'Differenza tra chiusura ricalcolata e sit.patrimoniale inizio anno successivo'
	END
	else 
	BEGIN
		if (@cat='N')
		BEGIN
			insert into #diff_end(codinventoryagency ,	idinv , 
				initial_amount,var_aum,rivalpos_all,car,tot_aum,  var_dim,rivalneg_all, scar,tot_dim,
				final_amount ,	amount_nextyear )
			SELECT	
				#patrimonio.codinventoryagency,
				#patrimonio.idinv,

				ISNULL(SUM(initial_amount),0),

				ISNULL(SUM(var_aum),0) ,
				ISNULL(SUM(rivalpos_all),0) ,
				ISNULL(SUM(car_cespiti),0),
				ISNULL(SUM(tot_aum),0) ,

				ISNULL(SUM(var_dim),0) ,
				ISNULL(SUM(rivalneg_all),0),

				ISNULL(SUM(scar_cespiti),0),
				ISNULL(SUM(tot_dim),0),

				ISNULL(SUM(#patrimonio.final_amount),0) as 'finale',
				ISNULL(SUM(#patrimonio.amount_nextyear),0) as 'iniziale anno succ'

			FROM #patrimonio
			GROUP BY #patrimonio.codinventoryagency, #patrimonio.idinv
			HAVING ISNULL(SUM(#patrimonio.final_amount),0)<>ISNULL(SUM(#patrimonio.amount_nextyear),0)
			
			
		END
		ELSE
		BEGIN
			insert into #diff_end(codinventoryagency ,	idinv ,
				initial_amount,var_aum,rivalpos_all,car,tot_aum,  var_dim,rivalneg_all, scar,tot_dim, final_amount ,amount_nextyear )
			SELECT 
				#patrimonio.codinventoryagency,
				CLASS1.idinv,
				ISNULL(SUM(initial_amount),0) ,

				ISNULL(SUM(var_aum),0) ,
				ISNULL(SUM(rivalpos_all),0) ,
				ISNULL(SUM(car_cespiti),0),
				ISNULL(SUM(tot_aum),0) ,

				ISNULL(SUM(var_dim),0) ,
				ISNULL(SUM(rivalneg_all),0),

				ISNULL(SUM(scar_cespiti),0),
				ISNULL(SUM(tot_dim),0),

				ISNULL(SUM(#patrimonio.final_amount),0) ,
				ISNULL(SUM(#patrimonio.amount_nextyear),0)
			FROM #patrimonio
			JOIN inventorytreelink CLASS1L				ON CLASS1L.idchild = #patrimonio.idinv AND CLASS1L.nlevel=1 
			JOIN inventorytree CLASS1					ON CLASS1L.idparent = CLASS1.idinv
			GROUP BY #patrimonio.codinventoryagency, CLASS1.idinv
			HAVING ISNULL(SUM(#patrimonio.final_amount),0)<>ISNULL(SUM(#patrimonio.amount_nextyear),0)
		END
		
		if (select count(*) from #diff_end)>0
		BEGIN
		SELECT	'diff_end1' as label,
				@ayear as anno,
				ENTE.codeinventoryagency AS 'codinventoryagency',
				CLASS.codeinv as 'codeinv',
				CLASS.description,
				initial_amount		as 'iniziale',
				var_aum  as 'var.aum.',
				rivalpos_all as 'rivalutazioni',
				car as 'carichi',
				tot_aum as 'tot_aum',

				var_dim as 'var.dim.',
				-rivalneg_all as 'ammortamenti',
				scar   as 'scarichi',
				tot_dim as 'tot_dim',
				final_amount as 'finale',
				amount_nextyear as 'iniziale anno succ',
				amount_nextyear- final_amount as 'differenza'
			FROM #diff_end
			LEFT OUTER JOIN inventorytree CLASS				ON CLASS.idinv = #diff_end.idinv
			LEFT OUTER JOIN inventoryagency	ENTE			ON ENTE.idinventoryagency = #diff_end.codinventoryagency
			ORDER BY  ENTE.codeinventoryagency, codeinv
		END

	END
	

	set @year=@year+1
	END


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





