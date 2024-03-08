
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


--setuser 'amministrazione'
--simulation_asset_ammortization_to_date 2011
IF exists (select * from dbo.sysobjects where id = object_id(N'[calcola_ammortamenti_futuri_cespiti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure calcola_ammortamenti_futuri_cespiti
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--select user
--setuser'amministrazione'
--calcola_ammortamenti_futuri_cespiti '2020', {d '2020-12-31'}   --- chiamata massiva
--calcola_ammortamenti_futuri_cespiti '2020', {d '2020-12-31'} ,'0001000100250728' --- chiamata puntuale
CREATE PROCEDURE calcola_ammortamenti_futuri_cespiti -- su tutti gli upb
(
	@ayear int,  --- anno corrente
	@adate datetime,
	@idupbfiltro  varchar(36) = null
)
AS BEGIN
---QUESTA STORED PROCEDURE RESTITUIUSCE IL TOTALE AMMORTAMENTI FUTURI PER UPB 
-- E' UTILIZZABILE "SOLO" AI FINI DEL CALCOLO DELLA COMMESSA COMPLETATA

-- CONSIDERO SOLO CESPII DI UPB IN SCADENZA, INOLTRE GLI UPB DI CARICO DEVONO ESSERE A COMMESSA COMPLETATA
-- select user
-- setuser'amm'-- setuser'amm'
-- setuser 'amministrazione'
-- calcola_ammortamenti_futuri_cespiti 2017, '31-12-2017',10
-- la stored procedure GetAssetValue è usata per valutare l'importo corrente dei cespiti
-- la stored procedure get_originalassetvalue è usata per valutare l'importo iniziale dei cespiti, su cui calcolare l'ammortamento
-- se l'ammortamento calcolato è tale da rendere negativo il valore corrente viene considerata una base per l'ammortamento opportunamente ridotta
-- in modo da far si che l'aliquota di ammortamento per la base di ammortamento vada ad azzerare il valore residuo del cespite
-- select @ayear
DECLARE @dec_31_year_prec datetime
SELECT  @dec_31_year_prec = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear -1), 105)

DECLARE @dec_31 datetime
SELECT  @dec_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)

DECLARE @dec_31_year_1 datetime
SELECT  @dec_31_year_1 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear + 1), 105)

DECLARE @dec_31_year_2 datetime
SELECT  @dec_31_year_2 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear + 2), 105)

DECLARE @idacc	varchar(38)
DECLARE @idacc1	varchar(38)
DECLARE @idacc2	varchar(38)

DECLARE @quota_amm float
--DECLARE @quota_amm_2 float
--DECLARE @quota_amm_3 float

SET		@quota_amm = 1 
--SET		@quota_amm_2 = 2 
--SET		@quota_amm_3 = 3 

DECLARE @min_levelusable int 
SET		@min_levelusable = (select min(nlevel) from accountlevel where ayear = @ayear and (flagusable='S'))
print	@min_levelusable 

DECLARE @idsorkind int
SELECT  @idsorkind = idsorkind FROM sortingkind  WHERE codesorkind ='BUDGET_UFF' -- 18 BUDGET_UFF Budget Schema Ufficiale
DECLARE @idacc_revenue_reserve_ex_cofi  varchar(38)
DECLARE @idsor_reserve int
SET		@idsor_reserve = (SELECT idsor FROM sorting WHERE sortcode = 'EA1501' and idsorkind = @idsorkind) -- VOCE DI BUDGET ECONOMICO
SET     @idacc_revenue_reserve_ex_cofi = (SELECT TOP 1 A.idacc FROM account  A join account Parent on Parent.idacc = SUBSTRING(A.idacc, 1, 2 + 4*@min_levelusable)
		and Parent.nlevel= @min_levelusable 
		WHERE ISNULL(A.idsor_economicbudget, Parent.idsor_economicbudget) = @idsor_reserve
		AND A.ayear = @ayear
		AND A.nlevel = (select max(nlevel) from accountlevel)) 

-- Formula per il ricalcolo della quota : ammortamento su base annuale

DECLARE @namortization int
SELECT  @namortization = ISNULL((SELECT MAX(namortization) FROM assetamortization),0) + 1
DECLARE @idinventoryamortization int
DECLARE @idasset int
DECLARE @idpiece int
DECLARE @yvar int
DECLARE @nvar int
DECLARE @description varchar(150)
--DECLARE @assetvalue_to_datedecimal(19,2)
DECLARE @assetvalue_to_date decimal(19,2)
DECLARE @assetvalue_to_date_2 decimal(19,2)
DECLARE @assetvalue_to_date_3 decimal(19,2)
DECLARE @amortizationquota float
DECLARE @amortizationquota2 float
DECLARE @amortizationquota3 float
DECLARE @actual_amortizationquota float
DECLARE @actual_amortizationquota_2 float
DECLARE @actual_amortizationquota_3 float
--DECLARE @actualvalue _to_datedecimal(19,2)
DECLARE @actualvalue_to_date  decimal(19,2)
DECLARE @actualvalue_to_date_2  decimal(19,2)
DECLARE @actualvalue_to_date_3  decimal(19,2)
DECLARE @reval decimal(19,2)
DECLARE @reval_to_date decimal(19,2)
DECLARE @reval_to_date_2 decimal(19,2)
DECLARE @reval_to_date_3 decimal(19,2)
DECLARE @startvalue decimal(19,2)
DECLARE @idaccmotiveload varchar(36)
DECLARE @idaccmotiveload2 varchar(36)
DECLARE @idaccmotiveload3 varchar(36)
DECLARE @idupb varchar(36)
DECLARE @rownum int
DECLARE @amount decimal(19,2)
DECLARE @amount_2 decimal(19,2)
DECLARE @amount_3 decimal(19,2)
--DECLARE @maxidautomaticbudget int

 declare @maxlevel int
 select  @maxlevel =   max(nlevel) from inventorysortinglevel
 --SP_HELP inventorysortingamortizationyear

 -- INSERISCO UPB IN SCADENZA INCLUSI NELLA COMMESSA COMPLETATA
CREATE TABLE #UPB
(
 
	idupb varchar(36),
	idupb_capofila varchar(36)
)

if (@idupbfiltro is null)
BEGIN
	--- chiamata massiva:
	----1) filtro a monte gli UPB a commessa completata e in chiusura (in base a data @stop) se non hanno UPB capofila 
	--- 2) se hanno UPB capofila, il filtro va applicato a quest'ultimo perchè non sappiamo se hanno configurato bene tutto 
	--- e si prendono tutti gli UPB associati senza alcun filtro su di essi
	INSERT INTO #UPB
		SELECT U.idupb, U.idupb_capofila
		FROM UPB U
		JOIN epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind 
		LEFT OUTER JOIN  UPB U_capofila (nolock)  on U_capofila.idupb = U.idupb_capofila
		LEFT OUTER JOIN epupbkindyear EU_capofila (nolock)  on EU_capofila.idepupbkind = U_capofila.idepupbkind 
		WHERE 
				-- la data fine da considerare è quella dell'UPB stesso perchè non ha un capofila
				(
					((year(U.start) IS NULL)OR(year(U.start)<=@ayear)) 
					AND(year(U.stop)<=@ayear)
					AND	U_capofila.idupb IS NULL 
					AND (EU.ayear=@ayear)
					AND	(EU.adjustmentkind='C')    
				)
				OR
				-- la data fine da considerare non è quella dell'UPB ma del capofila, che deve essere a commessa completata
				(
					((year(U_capofila.start) IS NULL)OR(year(U_capofila.start)<=@ayear)) 
					AND(year(U_capofila.stop)<=@ayear)
					AND	U_capofila.idupb IS NOT NULL 
					AND (EU_capofila.ayear=@ayear)
					AND	(EU_capofila.adjustmentkind='C')    
				)
END
ELSE
BEGIN
	--  chiamata puntuale (su singolo UPB), nessun filtro relativo a data scadenza, flag commessa completata ecc. 
	--  se filtro su un capofila mi accerto di prendere tutti gli UPB collegati
	--  se filtro su un UPB non capofila prendo solo questo e non gli altri collegati
	INSERT INTO #UPB
		SELECT U.idupb, U.idupb_capofila
		FROM UPB U
		WHERE ISNULL(U.idupb_capofila,U.idupb) = @idupbfiltro  --- il filtro in INPUT potrebbe essere capofila o no
END
 --select * from #UPB
CREATE TABLE #inventorysortingamortizationyear
(
	ayear int,
	idinv int,
	idinventoryamortization int,
	amortizationquota float,
	idaccmotiveload varchar(36),
	age_min int,
	age_max int,
	valuemin decimal(19,2),
	valuemax decimal(19,2),
	idacc varchar(38)
)

INSERT INTO #inventorysortingamortizationyear
 (ayear, idinv,idinventoryamortization, amortizationquota,idaccmotiveload, age_min,age_max,valuemin,valuemax,idacc)
SELECT @ayear, C.idinv, tr.idinventoryamortization,	coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota),
	coalesce(t4.idaccmotive,t3.idaccmotive,t2.idaccmotive,t1.idaccmotive),
	tr.age,	tr.agemax,tr.valuemin,tr.valuemax, account.idacc
from inventorytree C
  
	LEFT OUTER JOIN inventorytreelink IL1     		ON IL1.idchild = C.idinv AND IL1.nlevel  = 1 
	LEFT OUTER JOIN inventorytreelink IL2  	    	ON IL2.idchild = C.idinv  AND IL2.nlevel = 2
	LEFT OUTER JOIN inventorytreelink IL3 	    	ON IL3.idchild = C.idinv  AND IL3.nlevel = 3 
	LEFT OUTER JOIN inventorytreelink IL4 	    	ON IL4.idchild = C.idinv  AND IL4.nlevel = 4 
	LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayear 
	LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayear
								and T4.idinv is null
	LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayear 
								and T4.idinv is null and T3.idinv is null	
	LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayear
				and T4.idinv is null and T3.idinv is null	and  T2.idinv is null
	LEFT OUTER JOIN inventoryamortization tr
		ON tr.idinventoryamortization = 
		ISNULL(t4.idinventoryamortization,ISNULL(t3.idinventoryamortization,
		ISNULL(t2.idinventoryamortization,t1.idinventoryamortization)))

	JOIN accmotivedetail ON accmotivedetail.idaccmotive = 		coalesce(t4.idaccmotive,t3.idaccmotive,t2.idaccmotive,t1.idaccmotive)
			and accmotivedetail.ayear = @ayear
	JOIN account ON account.idacc = accmotivedetail.idacc 	AND ( (account.flagaccountusage & 64) <> 0 OR (account.flagaccountusage & 131072)<>0 ) /*costi o ammortamento*/
	AND account.ayear = @ayear

	where 
		(C.idinv NOT IN (SELECT  IT.paridinv FROM   inventorytree IT WHERE  (IT.paridinv IS NOT NULL))) /* foglia */
		--AND
		--coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota) < 0
		and ((tr.flag & 2) <> 0) and ((tr.flag&8) <> 0)
		and isnull(tr.active,'S')= 'S'  	and (tr.flag & 1 = 0)  
 --select * from #inventorysortingamortizationyear
CREATE TABLE #automaticbudget
(
	idautomaticbudget int, 
	idaccmotiveload varchar(36), 
	amount decimal(19,2),
	amount2 decimal(19,2), 
	amount3 decimal(19,2), 
	idasset int, 
	idpiece int, 
	yvar int, 
	nvar int,
	rownum int,
	adate date, 
	idupb varchar(36), 
	idupb_capofila varchar(36), 
	idacc varchar(38), 
	ayear int,
	kind varchar(20),
	valoreattualecespite decimal (19,2)
)

-- 1. Le previsioni triennali di costi di ammortamento
-- Le previsioni triennali per ammortamenti di cespiti 

-- Caso in cui il cespite ha data di inizio esistenza a NULL
-- Applico tutte le rivalutazioni UFFICIALI che nell'anno sono associate alla classIFicazione del cespite e che hanno ETA NULL

	 
DECLARE amt_crs INSENSITIVE CURSOR FOR
SELECT 
	t.idinventoryamortization,
	b.idasset,	b.idpiece, c.idupb,
	c.description,
	t.amortizationquota,
	t.idaccmotiveload,
	t.idacc
FROM asset b
JOIN assetacquire c							ON b.nassetacquire = C.nassetacquire
JOIN #UPB U									ON U.idupb = c.idupb
JOIN assetview_current ac					ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
LEFT OUTER JOIN assetload					ON assetload.idassetload = c.idassetload			
LEFT OUTER JOIN assetunload AU				ON AU.idassetunload = B.idassetunload	
JOIN  #inventorysortingamortizationyear t	ON t.idinv = c.idinv
WHERE   b.lifestart IS NULL
	AND t.age_min IS NULL AND t.age_max is null	AND (b.flag & 1 <> 0)
	AND	((t.valuemin is null or t.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (t.valuemax is null or t.valuemax>=ISNULL(C.historicalvalue,AC.start)))
	AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
	AND (AU.adate is null OR  AU.adate>@dec_31_year_prec )
	AND b.amortizationquota is null  
	 
FOR READ ONLY
OPEN amt_crs

FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @idupb, @description, @amortizationquota,@idaccmotiveload,@idacc
WHILE (@@FETCH_STATUS = 0)
BEGIN
-- select '1 Caso in cui il cespite ha data di inizio esistenza a NULL'
	EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue_to_date OUTPUT, @actualvalue_to_date OUTPUT 
	--EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31_year_1, @assetvalue_to_date_2 OUTPUT, @actualvalue_to_date_2 OUTPUT 
	--EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31_year_2, @assetvalue_to_date_3 OUTPUT, @actualvalue_to_date_3 OUTPUT 
	--@assetvalue_to_datevalore ORIGINALE alla data del 31 12 dell'anno corrente
	--@actualvalue _to_datevalore ATTUALE alla data del 31 12 dell'anno corrente
	
	--SELECT @idacc = accmotivedetail.idacc 
	--FROM accmotivedetail 
	--JOIN account ON accmotivedetail.idacc = account.idacc 
	--WHERE accmotivedetail.ayear = @ayear AND accmotivedetail.idaccmotive = @idaccmotiveload
	--AND ((account.flagaccountusage & 64) <> 0)  

    SET @actual_amortizationquota = @amortizationquota * @quota_amm
	 

	-- Formula per il ricalcolo della quota : ammortamento su base annuale
	-- quota_simulata = quota_annuale * @dateintheyear /  @ndaysinyear

    IF @actualvalue_to_date > 0  
	BEGIN
		SET @reval_to_date=ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2)
		

		IF   ((@reval_to_date + @actualvalue_to_date) < 0) 
		BEGIN
			SET @actual_amortizationquota  = -@actualvalue_to_date/@assetvalue_to_date
		END
			
		SET @reval_to_date = ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2) 


		SET @actualvalue_to_date_2 = @actualvalue_to_date + @reval_to_date
		
		IF  @actualvalue_to_date_2 > 0  
		BEGIN
			SET @reval_to_date_2=ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2)	 

			IF   ((@reval_to_date_2 + @actualvalue_to_date_2) < 0) 
			BEGIN
				SET @actual_amortizationquota_2  = -@actualvalue_to_date_2/@actualvalue_to_date_2
			END
			
			SET @reval_to_date_2 = ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota_2,0.0) ,2) 
		END
		ELSE
			BEGIN
				SET @reval_to_date_2=0
			END
		SET @actualvalue_to_date_3 = @actualvalue_to_date_2 + @reval_to_date_2
		
		IF  @actualvalue_to_date_3 > 0  
		BEGIN
			SET @reval_to_date_3=ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2)	 
			IF   ((@reval_to_date_3 + @actualvalue_to_date_3) < 0) 
			BEGIN
				SET @actual_amortizationquota_3  = -@actualvalue_to_date_3/@actualvalue_to_date_3
			END
			
			SET @reval_to_date_3 = ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota_3,0.0) ,2) 
		END
		ELSE
			BEGIN
				SET @reval_to_date_3 = 0
			END
	END
	ELSE
		BEGIN
				SET @reval_to_date = 0
				SET @reval_to_date_2 = 0
				SET @reval_to_date_3 = 0
		END
	--print 1
	--print @idasset
	--print @idpiece
	--print @actualvalue_to_date
	--print @actualvalue_to_date_2
	--print @actualvalue_to_date_3
	--print @actual_amortizationquota
	--print @actual_amortizationquota_2
	--print @actual_amortizationquota_3
	IF ((@idacc is not null)AND(@reval_to_date <>0)OR((@reval_to_date_2 <>0)OR(@reval_to_date_3  <>0))) 
		BEGIN
		 
		--SELECT @maxidautomaticbudget = max(idautomaticbudget) from #automaticbudget
			INSERT INTO #automaticbudget
			(
				--idautomaticbudget,
				idaccmotiveload,
				kind, 
				amount,
				amount2, 
				amount3, 
				idasset, 
				idpiece, 
				adate, 
				idupb,
				idacc, 
				ayear,
				valoreattualecespite
			)
			SELECT
				/*@maxidautomaticbudget + 1,*/@idaccmotiveload,'ASSET',-@reval_to_date,-@reval_to_date_2,-@reval_to_date_3,
				@idasset, @idpiece,@adate, @idupb, @idacc,@ayear, @actualvalue_to_date
		END
	FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece,@idupb, @description, @amortizationquota,@idaccmotiveload,@idacc
END
DEALLOCATE amt_crs
 

-- Caso in cui il cespite ha valorizzata la quota di ammortamento direttamente sul cespite
-- Applico direttamente quella a prescindere da quella configurata nella classIFicazione inventariale.
-- Assumo che la quota sia annuale


DECLARE amt_crs1 INSENSITIVE CURSOR FOR
SELECT 
	tr.idinventoryamortization,
	b.idasset,	b.idpiece, c.idupb,
	c.description,
	b.amortizationquota,
	coalesce(t4.idaccmotive,t3.idaccmotive,t2.idaccmotive,t1.idaccmotive),--	INV.idaccmotiveload,
	account.idacc
FROM asset b
JOIN assetacquire c							ON b.nassetacquire = C.nassetacquire
JOIN #UPB U									ON U.idupb = c.idupb
JOIN inventorytree INV						ON INV.idinv = C.idinv
	LEFT OUTER JOIN inventorytreelink IL1     		ON IL1.idchild = C.idinv AND IL1.nlevel  = 1 
	LEFT OUTER JOIN inventorytreelink IL2  	    	ON IL2.idchild = C.idinv  AND IL2.nlevel = 2
	LEFT OUTER JOIN inventorytreelink IL3 	    	ON IL3.idchild = C.idinv  AND IL3.nlevel = 3 
	LEFT OUTER JOIN inventorytreelink IL4 	    	ON IL4.idchild = C.idinv  AND IL4.nlevel = 4 
	LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayear 
	LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayear
								and T4.idinv is null
	LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayear 
								and T4.idinv is null and T3.idinv is null	
	LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayear
				and T4.idinv is null and T3.idinv is null	and  T2.idinv is null
	JOIN inventoryamortization tr				ON tr.idinventoryamortization = b.idinventoryamortization  -- <<<<
	AND tr.idinventoryamortization = 
		ISNULL(t4.idinventoryamortization,ISNULL(t3.idinventoryamortization,
		ISNULL(t2.idinventoryamortization,t1.idinventoryamortization)))
	JOIN accmotivedetail ON accmotivedetail.idaccmotive = 		coalesce(t4.idaccmotive,t3.idaccmotive,t2.idaccmotive,t1.idaccmotive)
			and accmotivedetail.ayear = @ayear
JOIN account ON account.idacc = accmotivedetail.idacc 	AND ( (account.flagaccountusage & 64) <> 0 OR (account.flagaccountusage & 131072)<>0 ) /*costi o ammortamento*/
LEFT OUTER JOIN assetload					ON assetload.idassetload = c.idassetload			
LEFT OUTER JOIN assetunload AU				ON AU.idassetunload = B.idassetunload	
WHERE  (tr.flag & 2 <> 0) --ufficiale
	AND ((tr.flag&8) <> 0) -- ammortamenti
	AND ISNULL(tr.active,'S')= 'S'
	AND (b.flag & 1 <> 0)
	AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
	AND (AU.adate is null OR  AU.adate > @dec_31_year_prec)
	AND b.amortizationquota is not null  and account.ayear = @ayear
	AND accmotivedetail.ayear = @ayear
 
FOR READ ONLY
OPEN amt_crs1


FETCH NEXT FROM amt_crs1 INTO @idinventoryamortization, @idasset, @idpiece,@idupb, @description, @amortizationquota,@idaccmotiveload,@idacc
WHILE (@@FETCH_STATUS = 0)
BEGIN
--select '2 Caso in cui il cespite ha valorizzata la quota di ammortamento direttamente sul cespite'
	EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue_to_date OUTPUT, @actualvalue_to_date OUTPUT 
	--EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31_year_1, @assetvalue_to_date_2 OUTPUT, @actualvalue_to_date_2 OUTPUT 
	--EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31_year_2, @assetvalue_to_date_3 OUTPUT, @actualvalue_to_date_3 OUTPUT 
		--@assetvalue_to_datevalore ORIGINALE alla data del 31 12 dell'anno corrente
		--@actualvalue _to_datevalore ATTUALE alla data del 31 12 dell'anno corrente
 
    SET @actual_amortizationquota	= @amortizationquota -- * @quota_amm : la commento perchè è impostata a 1. 
	 -- Ho inizializzato @actual_amortizationquota_2 e @actual_amortizationquota_3 perchè se l'IF  [*] non agisce, @actual_amortizationquota_2 e @actual_amortizationquota_3 restano a 0.
	 -- Invece in questo caso deve valere quella impostata nel Cespite.
	SET @actual_amortizationquota_2 = @amortizationquota
	SET @actual_amortizationquota_3 = @amortizationquota

	-- Formula per il ricalcolo della quota : ammortamento su base annuale
	-- quota_simulata = quota_annuale * @dateintheyear /  @ndaysinyear

     IF @actualvalue_to_date > 0  
	BEGIN
		SET @reval_to_date=ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2)

		IF   ((@reval_to_date + @actualvalue_to_date) < 0) 
		BEGIN
			SET @actual_amortizationquota  = -@actualvalue_to_date/@assetvalue_to_date
		END
		SET @reval_to_date = ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2) 
		SET @actualvalue_to_date_2 = @actualvalue_to_date + @reval_to_date
		IF  @actualvalue_to_date_2 > 0  
		BEGIN
			SET @reval_to_date_2=ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2)	 
			IF   ((@reval_to_date_2 + @actualvalue_to_date_2) < 0) -- [*]
			BEGIN
				SET @actual_amortizationquota_2  = -@actualvalue_to_date_2/@assetvalue_to_date
			END
			SET @reval_to_date_2 = ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota_2,0.0) ,2) 
		END
		ELSE
			BEGIN
				SET @reval_to_date_2=0
			END
		SET @actualvalue_to_date_3 = @actualvalue_to_date_2 + @reval_to_date_2
		IF  @actualvalue_to_date_3 > 0  
		BEGIN
			SET @reval_to_date_3=ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2)	 
			IF   ((@reval_to_date_3 + @actualvalue_to_date_3) < 0) -- [*]
			BEGIN
				SET @actual_amortizationquota_3  = -@actualvalue_to_date_3/@assetvalue_to_date
			END
			SET @reval_to_date_3 = ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota_3,0.0) ,2) 
		END
		ELSE
			BEGIN
				SET @reval_to_date_3 = 0
			END
	END
	ELSE
		BEGIN
				SET @reval_to_date = 0
				SET @reval_to_date_2 = 0
				SET @reval_to_date_3 = 0
		END

	IF ((@idacc is not null)AND(@reval_to_date <>0)OR((@reval_to_date_2 <>0)OR(@reval_to_date_3  <>0))) 
		BEGIN
			--SELECT @maxidautomaticbudget = isnull(max(idautomaticbudget),0) from #automaticbudget
			INSERT INTO #automaticbudget
			(
				--idautomaticbudget,
				idaccmotiveload,
				kind, 
				amount,
				amount2, 
				amount3, 
				idasset, 
				idpiece, 
				adate, 
				idupb,
				idacc, 
				ayear,
				valoreattualecespite
			)
			SELECT
				/*@maxidautomaticbudget + 1,*/@idaccmotiveload,'ASSET',-@reval_to_date,-@reval_to_date_2,-@reval_to_date_3,
				@idasset, @idpiece,@adate, @idupb, @idacc,@ayear, @actualvalue_to_date
		END

	FETCH NEXT FROM amt_crs1 INTO @idinventoryamortization, @idasset, @idpiece,@idupb, @description, @amortizationquota,@idaccmotiveload,@idacc
	END
DEALLOCATE amt_crs1
 
 
-- Caso in cui il cespite ha la data di inizio esistenza NOT NULL 
-- Applico tutte le rivalutazioni UFFICIALI che nell'anno sono associate alla classIFicazione cespite con età pari alla dIFferenza tra l'anno
-- di acquisizione del cespite e la data contabile
-- In questo caso prima di effettuare le rivalutazioni controllo se ci sono rivalutazioni che hanno il campo ETA' valorizzato,
-- in caso negativo provo ad effettuare rivalutazioni senza ETA' (costanti nel tempo)

 

IF 
(SELECT COUNT(*)
FROM inventoryamortization I
JOIN inventorysortingamortizationyear A
	ON I.idinventoryamortization = A.idinventoryamortization
WHERE (I.flag & 2 <> 0) AND I.age IS NOT NULL AND A.ayear = @ayear AND ISNULL(I.active,'S')= 'S') > 0
BEGIN
	-- Considero i tipi di rivalutazioni 'ANNUALI' 
	DECLARE amt_crs2 INSENSITIVE CURSOR FOR
	SELECT DISTINCT
		t.idinventoryamortization,	b.idasset,	b.idpiece, c.idupb,
		t.amortizationquota,
		t.idaccmotiveload,

		t1.amortizationquota,
		t1.idaccmotiveload,

		t2.amortizationquota,
		t2.idaccmotiveload, 
		t.idacc,
		t1.idacc,
		t2.idacc
	FROM asset b					
	JOIN assetacquire c					ON b.nassetacquire = C.nassetacquire
	JOIN #UPB U							ON U.idupb = c.idupb
	JOIN inventory						ON c.idinventory = inventory.idinventory
	JOIN inventorykind					ON inventory.idinventorykind= inventorykind.idinventorykind
	JOIN assetview_current ac			ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
	--- tipo ammortamento per il primo anno (piano ammortamento attuale)
	JOIN #inventorysortingamortizationyear t	ON t.idinv = c.idinv
	--- alias tipo ammortamento per il secondo anno (secondo il piano ammortamento attuale)
	JOIN #inventorysortingamortizationyear t1	ON t1.idinv = c.idinv
	--- tipo ammortamento per il terzo anno (secondo il piano ammortamento attuale)
	JOIN #inventorysortingamortizationyear t2		ON t2.idinv = c.idinv
	LEFT OUTER JOIN assetload			ON assetload.idassetload = c.idassetload		
	LEFT OUTER JOIN assetunload AU		ON AU.idassetunload = B.idassetunload

	WHERE   b.lifestart IS NOT NULL AND b.lifestart <= @dec_31 
		AND t.age_min <= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.lifestart)) + 1
		AND t.age_max >= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.lifestart)) + 1
		-- età cespite secondo anno
		AND t1.age_min <= (DATEPART(YEAR,@dec_31_year_1) - DATEPART(YEAR,b.lifestart)) + 1
		AND t1.age_max >= (DATEPART(YEAR,@dec_31_year_1) - DATEPART(YEAR,b.lifestart)) + 1
		-- età cespite terzo anno
		AND t2.age_min <= (DATEPART(YEAR,@dec_31_year_2) - DATEPART(YEAR,b.lifestart)) + 1
		AND t2.age_max >= (DATEPART(YEAR,@dec_31_year_2) - DATEPART(YEAR,b.lifestart)) + 1

		AND	((t.valuemin is null or t.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (t.valuemax is null or t.valuemax>=ISNULL(C.historicalvalue,AC.start)))
		AND	((t1.valuemin is null or t1.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (t1.valuemax is null or t1.valuemax>=ISNULL(C.historicalvalue,AC.start)))
		AND	((t2.valuemin is null or t2.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (t2.valuemax is null or t2.valuemax>=ISNULL(C.historicalvalue,AC.start)))
		
		and (b.flag & 1 <> 0)
			AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
		AND (AU.adate is null OR  AU.adate>@dec_31_year_prec )		
		AND ( (inventorykind.flag&2)=0)
		AND b.amortizationquota is null
		--AND b.idasset = 202384 and b.idpiece = 1 
		--AND b.idasset < 10
FOR READ ONLY
	
	OPEN amt_crs2
	FETCH NEXT FROM amt_crs2 INTO @idinventoryamortization, @idasset, @idpiece,@idupb, @amortizationquota,@idaccmotiveload,@amortizationquota2,@idaccmotiveload2,@amortizationquota3,@idaccmotiveload3,@idacc,@idacc1, @idacc2
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	--select ' 3 Caso in cui il cespite ha la data di inizio esistenza NOT NULL '
		EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue_to_date OUTPUT, @actualvalue_to_date OUTPUT 
		--EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31_year_1, @assetvalue_to_date_2 OUTPUT, @actualvalue_to_date_2 OUTPUT 
		--EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31_year_2, @assetvalue_to_date_3 OUTPUT, @actualvalue_to_date_3 OUTPUT 
		--	--@assetvalue_to_datevalore ORIGINALE alla data del 31 12 dell'anno corrente
			--@actualvalue _to_datevalore ATTUALE alla data del 31 12 dell'anno corrente
			--select 'Valore attuale del cespite al 31/12 @actualvalue_to_date',@actualvalue_to_date
		SET @actual_amortizationquota_2 = @amortizationquota  
		SET @actual_amortizationquota_3 = @amortizationquota2  
		SET @actual_amortizationquota	= @amortizationquota3  
		-- Formula per il ricalcolo della quota : ammortamento su base annuale
		-- quota_simulata = quota_annuale * @dateintheyear /  @ndaysinyear
	  IF @actualvalue_to_date > 0  
	BEGIN
		SET @reval_to_date=ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2)
		--select 'Valore iniziale ai fini dell''ammortamento: @assetvalue_to_date',@assetvalue_to_date
		--select ' Aliquota ammortamento applicata @actual_amortizationquota',@actual_amortizationquota
		--select 'svalutazioni alla data 31/12 @reval_to_date',@reval_to_date

		IF   ((@reval_to_date + @actualvalue_to_date) < 0) 
		BEGIN
		--select '@reval_to_date + @actualvalue_to_date',@reval_to_date +@actualvalue_to_date
			SET @actual_amortizationquota  = -@actualvalue_to_date/@assetvalue_to_date
			--select 'quota ammportamento applicata @actual_amortizationquota',@actual_amortizationquota
		END
			
		SET @reval_to_date = ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2) 


		SET @actualvalue_to_date_2 = @actualvalue_to_date + @reval_to_date
		
		IF  @actualvalue_to_date_2 > 0  
		BEGIN
			SET @reval_to_date_2=ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota_2,0.0) ,2)	 

			IF   ((@reval_to_date_2 + @actualvalue_to_date_2) < 0) 
			BEGIN
				SET @actual_amortizationquota_2  = -@actualvalue_to_date_2/@assetvalue_to_date
			END
			
			SET @reval_to_date_2 = ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota_2,0.0) ,2) 
		END
		ELSE
			BEGIN
				SET @reval_to_date_2=0
			END
		SET @actualvalue_to_date_3 = @actualvalue_to_date_2 + @reval_to_date_2
		
		IF  @actualvalue_to_date_3 > 0  
		BEGIN
			SET @reval_to_date_3=ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota_3,0.0) ,2)	 
			IF   ((@reval_to_date_3 + @actualvalue_to_date_3) < 0) 
			BEGIN
				SET @actual_amortizationquota_3  = -@actualvalue_to_date_3/@assetvalue_to_date
			END
			
			SET @reval_to_date_3 = ROUND(ISNULL(@assetvalue_to_date, 0.0) * ISNULL(@actual_amortizationquota_3,0.0) ,2) 
		END
		ELSE
			BEGIN
				SET @reval_to_date_3 = 0
			END
	END
	ELSE
		BEGIN
				SET @reval_to_date = 0
				SET @reval_to_date_2 = 0
				SET @reval_to_date_3 = 0
		END
		--print 3
		--print @idasset
	--print @idpiece
	--print @actualvalue_to_date
	--print @actualvalue_to_date_2
	--print @actualvalue_to_date_3
	--print @actual_amortizationquota
	--print @actual_amortizationquota_2
	--print @actual_amortizationquota_3
	--print @amortizationquota
	--print @amortizationquota2
	--print @amortizationquota3
		IF ((@reval_to_date <>0)OR((@reval_to_date_2 <>0)OR(@reval_to_date_3  <>0))) 
		--SELECT @maxidautomaticbudget = max(idautomaticbudget) from #automaticbudget
				INSERT INTO #automaticbudget
				(
					--idautomaticbudget,
					idaccmotiveload,
					kind, 
					amount,
					amount2, 
					amount3, 
					idasset, 
					idpiece, 
					adate, 
					idupb,
					idacc, 
					ayear,
					valoreattualecespite
				)
				SELECT
					/*@maxidautomaticbudget + 1,*/@idaccmotiveload,'ASSET',-@reval_to_date,-@reval_to_date_2,-@reval_to_date_3,
					@idasset, @idpiece,@adate, @idupb, @idacc,@ayear,@actualvalue_to_date

		FETCH NEXT FROM amt_crs2 INTO @idinventoryamortization, @idasset, @idpiece, @idupb,@amortizationquota,@idaccmotiveload,@amortizationquota2,@idaccmotiveload2,@amortizationquota3,@idaccmotiveload3,@idacc,@idacc1, @idacc2
		END
	DEALLOCATE amt_crs2
	END

CREATE TABLE #budgetsituation
	(
		idupb			varchar(36),
		idupb_capofila varchar(36), 
		amount			decimal(19,2),
		amount2			decimal(19,2),
		amount3			decimal(19,2),
		accountkind		char(1) ,
		amm_futuricespiti decimal(19,2)
	)

	DECLARE @riserve_ex_cofi decimal(19,2)
	DECLARE @totcosti_upb decimal(19,2)
	DECLARE @totricavi_upb decimal(19,2)

	INSERT INTO #budgetsituation
			(
				idupb,	 			
				amount, amount2, amount3,
				accountkind,
				amm_futuricespiti
			)
		--- INSERISCO I DATI DELL'ELABORAZIONE DEL PUNTO 1.
		SELECT autob.idupb, sum(isnull(autob.amount,0)),sum(isnull(autob.amount2,0)), sum(isnull(autob.amount3,0)),   
		CASE	WHEN ((A.flagaccountusage & 128)<> 0) THEN 'R'  		-- conti di Ricavo
			WHEN ((A.flagaccountusage & 64)<> 0) THEN 'C'			-- conti di costo
			WHEN ((A.flagaccountusage & 131072)<> 0) THEN 'A'			-- conti di ammortamento
			WHEN ((A.flagaccountusage & 256)<> 0) THEN 'I'			-- o Immobilizzazioni
		END ,
		sum(isnull(autob.valoreattualecespite,0) - isnull(autob.amount,0)) -- => amm_futuricespiti
	FROM #automaticbudget	 autob (nolock)  
			 
	JOIN account A (NOLOCK) ON A.idacc = autob.idacc  
	WHERE /*autob.adate <= @adate AND autob.ayear = @ayear*/
		autob.kind IN ('ASSET','ASSETVAR')
	GROUP BY autob.idupb, 
	CASE	WHEN ((A.flagaccountusage & 128)<> 0) THEN 'R'  		-- conti di Ricavo
			WHEN ((A.flagaccountusage & 64)<> 0) THEN 'C'			-- conti di costo
			WHEN ((A.flagaccountusage & 131072)<> 0) THEN 'A'			-- conti di ammortamento
			WHEN ((A.flagaccountusage & 256)<> 0) THEN 'I'			-- o Immobilizzazioni
	END 

	UPDATE #budgetsituation SET idupb_capofila = (select idupb_capofila from #UPB WHERE #budgetsituation.idupb = #UPB.idupb)
	UPDATE #budgetsituation SET idupb_capofila = #budgetsituation.idupb where idupb_capofila IS NULL
 
	SELECT 
			avd.idupb_capofila as idupb,  
			--EU.idaccmotive_revenue, 
			sum(avd.amm_futuricespiti) AS amm_futuricespiti
		FROM #budgetsituation avd (nolock)  
		--join upb u (nolock) on avd.idupb_capofila = u.idupb 
		--join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind 
		--WHERE 
		--((year(U.start) IS NULL)OR(year(U.start)<=@ayear)) 
		--AND(year(U.stop)<=@ayear)
		--AND	(EU.ayear=@ayear)
		--AND	(EU.adjustmentkind='C')   
		GROUP BY avd.idupb_capofila /*EU.idaccmotive_revenue,  U.idepupbkind,U.codeupb,U.title*/
		HAVING sum(avd.amm_futuricespiti) <>0
										
 
END
GO
 


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
