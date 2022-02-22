
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
IF exists (select * from dbo.sysobjects where id = object_id(N'[calcola_integrazione_previsione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure calcola_integrazione_previsione
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- select user
--setuser'amministrazione'
 --calcola_integrazione_previsione '2020', {d '2020-12-31'}, '10','n','n','s'
 --calcola_integrazione_previsione '2019', {d '2019-12-31'}, '10'
CREATE PROCEDURE calcola_integrazione_previsione
(
	@ayear int,  --- anno corrente
	@adate datetime,
	@exportazionekind int = 10, --  Se @exportazionekind è valorizzatto, l'output alimenta una sp di esportazione.  0 = Prev. iniziali, 1 = Le previsioni triennali di costi di ammortamento,  2 = Le previsioni di ricavo per utilizzo riserve ex COFI,  3 = Rettifiche
	@prevcorrente char(1) = 'N',
	@creavar char(1) = 'N',
	@riscontaricavi_ammortamentifuturi char(1) = 'N' -- task 15403
)
AS BEGIN
-- select user
-- setuser'amm'-- setuser'amm'
-- setuser 'amministrazione'
-- calcola_integrazione_previsione 2017, '31-12-2017',10
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
 select @maxlevel =   max(nlevel) from inventorysortinglevel
 --SP_HELP inventorysortingamortizationyear
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
--JOIN upb U									ON U.idupb = c.idupb
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

	WHERE   b.lifestart IS NOT NULL AND b.lifestart <= @dec_31_year_prec
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
		EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue_to_date OUTPUT, @actualvalue_to_date OUTPUT 
		--EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31_year_1, @assetvalue_to_date_2 OUTPUT, @actualvalue_to_date_2 OUTPUT 
		--EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31_year_2, @assetvalue_to_date_3 OUTPUT, @actualvalue_to_date_3 OUTPUT 
		--	--@assetvalue_to_datevalore ORIGINALE alla data del 31 12 dell'anno corrente
			--@actualvalue _to_datevalore ATTUALE alla data del 31 12 dell'anno corrente

		SET @actual_amortizationquota_2 = @amortizationquota  
		SET @actual_amortizationquota_3 = @amortizationquota2  
		SET @actual_amortizationquota	= @amortizationquota3  
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
 

--	Le previsioni triennali per ammortamenti di immobiliazzazioni 

--Le previsioni triennali per ammortamenti delle Immobilizzazioni caricate nel Budget degli investimenti. Esempio: inserisco una variazione di budget sulla voce di Budget Mobili e arredi per 100.000 euro e calcolo l’ammortamento.
--Delle var. sino alla data… prendo i dettagli collegati a conti di immobilizzazione associati a budget investimenti – considerare solo le var. approvate
--Di queste vanno considerati gli importi anno x, x+1 e x+2 e tralasciati gli altri due.
--L’importo anno x andrà ammortizzato  per 3 anni, quello x+1 per due anni a partire dal successivo e quello x+2 nell’anno x+2 solamente
--L’idea attuale è di associare al dett. Variaz. Budget una class. inventariale da cui poi derivare l’aliquota di ammortamento considerando come data “cespite” quella contabile della variazione

/*
SELECT * FROM #inventorysortingamortizationyear
SELECT  DISTINCT
		c.yvar, c.nvar, c.rownum,
		c.amount,
		c.amount2,
		c.amount3,
		t.amortizationquota,
		t1.amortizationquota,
		t2.amortizationquota,
		c.idupb,
		t.idacc
	FROM accountvar  b					
	JOIN accountvardetail c				ON b.yvar = c.yvar AND b.nvar = c.nvar 
	--- tipo ammortamento per il primo anno (piano ammortamento attuale)
	 LEFT OUTER JOIN #inventorysortingamortizationyear t	ON t.idinv = c.idinv
	--- alias tipo ammortamento per il secondo anno (secondo il piano ammortamento attuale)
	 LEFT OUTER JOIN #inventorysortingamortizationyear t1	ON t1.idinv = c.idinv
	--- tipo ammortamento per il terzo anno (secondo il piano ammortamento attuale)
	 LEFT OUTER JOIN #inventorysortingamortizationyear t2		ON t2.idinv = c.idinv
	LEFT OUTER  join account A						ON a.idacc = t.idacc
	left outer join sorting S						ON S.idsor = A.idsor_investmentbudget 		AND S.idsorkind = @idsorkind
	
	WHERE    b.adate <= @adate
	 		
		--AND t.age_min <= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.adate)) + 1
		--AND t.age_max >= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.adate)) + 1
		---- età cespite secondo anno
		--AND t1.age_max <= (DATEPART(YEAR,@dec_31_year_1) - DATEPART(YEAR,b.adate)) + 1
		--AND t1.age_max >= (DATEPART(YEAR,@dec_31_year_1) - DATEPART(YEAR,b.adate)) + 1
		---- età cespite terzo anno
		--AND t2.age_min <= (DATEPART(YEAR,@dec_31_year_2) - DATEPART(YEAR,b.adate)) + 1
		--AND t2.age_max >= (DATEPART(YEAR,@dec_31_year_2) - DATEPART(YEAR,b.adate)) + 1

		--and (b.idaccountvarstatus  = 5) --approvate
		--AND	((t.valuemin is null or t.valuemin<C.amount)  and (t.valuemax is null or t.valuemax>=C.amount))
		--AND	((t1.valuemin is null or t1.valuemin<(ISNULL(C.amount, 0.0) + ISNULL(C.amount, 0.0))) and (t1.valuemax is null or t1.valuemax>=(ISNULL(C.amount, 0.0) + ISNULL(C.amount2, 0.0)        )))
		--AND	((t2.valuemin is null or t2.valuemin<(ISNULL(C.amount, 0.0) + ISNULL(C.amount2, 0.0)+ ISNULL(C.amount3, 0.0))) and (t2.valuemax is null or t2.valuemax>=(ISNULL(C.amount, 0.0) + ISNULL(C.amount2, 0.0)+ ISNULL(C.amount3, 0.0)  )))
		--AND (( a.flagaccountusage & 256) <> 0) -- immobilizzazioni 	
*/

--select * from #inventorysortingamortizationyear
 

IF 
(SELECT COUNT(*)
FROM inventoryamortization I
JOIN inventorysortingamortizationyear A
	ON I.idinventoryamortization = A.idinventoryamortization
WHERE (I.flag & 2 <> 0) AND I.age IS NOT NULL AND A.ayear = @ayear AND ISNULL(I.active,'S')= 'S') > 0
BEGIN
print '@prevcorrente'
print @prevcorrente
	-- Considero i tipi di rivalutazioni 'ANNUALI' 
	DECLARE amt_crs3 INSENSITIVE CURSOR FOR
	SELECT  DISTINCT
		c.yvar, c.nvar, c.rownum,
		c.amount,
		c.amount2,
		c.amount3,
		t.amortizationquota,
		t1.amortizationquota,
		t2.amortizationquota,
		c.idupb,
		t.idacc
	FROM accountvar  b					
	JOIN accountvardetail c				ON b.yvar = c.yvar AND b.nvar = c.nvar 
	join account A						ON a.idacc = c.idacc
	--- tipo ammortamento per il primo anno (piano ammortamento attuale)
	 JOIN #inventorysortingamortizationyear t	ON t.idinv = c.idinv
	--- alias tipo ammortamento per il secondo anno (secondo il piano ammortamento attuale)
	 JOIN #inventorysortingamortizationyear t1	ON t1.idinv = c.idinv
	--- tipo ammortamento per il terzo anno (secondo il piano ammortamento attuale)
	 JOIN #inventorysortingamortizationyear t2		ON t2.idinv = c.idinv
	 	join account A1						ON a1.idacc = T.idacc
	
	--join sorting S						ON S.idsor = A.idsor_investmentbudget 		AND S.idsorkind = @idsorkind

	WHERE   
		( 
			(b.yvar = @ayear AND b.variationkind = 5  AND @prevcorrente = 'N')-- solo variazioni iniziali, se sto calcolando il budget iniziale
			OR
	 		-- calcolo budget corrente: prendo le variazioni tranne le non operative alla data  
			(
				 @prevcorrente = 'S' AND
				(
					(b.yvar = @ayear) AND
					(
						(b.variationkind = 5) /*tutte quelle iniziali dell'anno indipendentemente dalla data*/
						
						OR 
						(b.variationkind <> 5 AND b.variationkind <> 6 AND b.adate <= @adate)
					)
				) /*tutte quelle iniziali dell'anno e storni dell'anno alla data*/  
			
				)  
		)
		AND t.age_min <= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.adate)) + 1
		AND t.age_max >= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.adate)) + 1
		-- età cespite secondo anno
		AND t1.age_min <= (DATEPART(YEAR,@dec_31_year_1) - DATEPART(YEAR,b.adate)) + 1
		AND t1.age_max >= (DATEPART(YEAR,@dec_31_year_1) - DATEPART(YEAR,b.adate)) + 1
		-- età cespite terzo anno
		AND t2.age_min <= (DATEPART(YEAR,@dec_31_year_2) - DATEPART(YEAR,b.adate)) + 1
		AND t2.age_max >= (DATEPART(YEAR,@dec_31_year_2) - DATEPART(YEAR,b.adate)) + 1

		and (b.idaccountvarstatus  = 5) --approvate
		AND	((t.valuemin is null or t.valuemin<C.amount)  and (t.valuemax is null or t.valuemax>=C.amount))
		AND	((t1.valuemin is null or t1.valuemin<(ISNULL(C.amount, 0.0) + ISNULL(C.amount, 0.0))) and (t1.valuemax is null or t1.valuemax>=(ISNULL(C.amount, 0.0) + ISNULL(C.amount2, 0.0)        )))
		AND	((t2.valuemin is null or t2.valuemin<(ISNULL(C.amount, 0.0) + ISNULL(C.amount2, 0.0)+ ISNULL(C.amount3, 0.0))) and (t2.valuemax is null or t2.valuemax>=(ISNULL(C.amount, 0.0) + ISNULL(C.amount2, 0.0)+ ISNULL(C.amount3, 0.0)  )))
		--AND (( a.flagaccountusage & 256) <> 0) -- immobilizzazioni 	
		AND ( (A1.flagaccountusage & 64) <> 0 OR (A1.flagaccountusage & 131072)<>0 ) /*costi o ammortamento*/
		--AND S.idsorkind = @idsorkind
	FOR READ ONLY
	OPEN amt_crs3
	FETCH NEXT FROM amt_crs3 INTO @yvar, @nvar, @rownum, @amount, @amount_2,@amount_3, @amortizationquota,@amortizationquota2, @amortizationquota3,@idupb,@idacc 
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @actual_amortizationquota	= @amortizationquota 
		-- Formula per il ricalcolo della quota : ammortamento su base annuale

		--L’importo anno x andrà ammortizzato  per 3 anni, quello x+1 per due anni a partire dal successivo e quello x+2 nell’anno x+2 solamente

		SET @reval_to_date		=	ROUND(ISNULL(@amount, 0.0) * ISNULL(@amortizationquota,0.0) ,2) 
		SET @reval_to_date_2	=	/*ROUND(ISNULL(@amount, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2)*/  +  ROUND(ISNULL(@amount, 0.0) * ISNULL(@amortizationquota2,0.0) ,2) + 	ROUND(ISNULL(@amount_2, 0.0) * ISNULL(@amortizationquota,0.0),2) 
		SET @reval_to_date_3	=	/*ROUND(ISNULL(@amount, 0.0) * ISNULL(@actual_amortizationquota,0.0) ,2)*/  ROUND(ISNULL(@amount, 0.0) * ISNULL(@amortizationquota3,0.0) ,2) + 	ROUND(ISNULL(@amount_2, 0.0) * ISNULL(@amortizationquota2,0.0),2) +
																												ROUND(ISNULL(@amount_3, 0.0) * ISNULL(@amortizationquota,0.0) ,2)
	--print 4
	--print @nvar
	--print @rownum
	--print @amortizationquota
	--print @amortizationquota2
	--print @amortizationquota3
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
					yvar, 
					nvar, 
					rownum,
					adate, 
					idupb,
					idacc, 
					ayear
				)
				SELECT
					/*@maxidautomaticbudget + 1,*/@idaccmotiveload,'ACCOUNTVAR',-@reval_to_date,-@reval_to_date_2,-@reval_to_date_3,
					@yvar, @nvar, @rownum,@adate, @idupb, @idacc,@ayear
			END
		FETCH NEXT FROM amt_crs3 INTO  @yvar, @nvar, @rownum, @amount, @amount_2,@amount_3, @amortizationquota,@amortizationquota2, @amortizationquota3,@idupb,@idacc 
	END
 
DEALLOCATE amt_crs3
END


-- 2. Le previsioni di ricavo per utilizzo riserve ex COFI 
CREATE TABLE #budgetupb
	(
		idacc 			varchar(38), 
		idupb			varchar(36),
		ymov			int,
		nmov			int,	
		rowkind			int,
		operationdate		datetime,
		operationkind		varchar(100),
		amount			decimal(19,2),
		amount2			decimal(19,2),
		amount3			decimal(19,2),
		initialprevision 	decimal(19,2),
		initialprevision2 	decimal(19,2),
		initialprevision3 	decimal(19,2)	
	)

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

	-- determino saldo scritture su conto Ex Riserve COFI ANNO CORRENTE
 	CREATE TABLE #reserve
		(
					idupb varchar(36),	 			
					amount decimal(19,2),  
					accountkind varchar(10)
				)
	 --- dettagli scrittura di tipo apertura
		INSERT INTO #reserve
			(
				idupb,	 			
				amount,  
				accountkind
			)
			SELECT 
					entrydetail.idupb,			
					ISNULL(SUM(amount),0), --totale avere > 0
					'F'
			FROM entrydetail  
			JOIN entry 
			  ON  entry.nentry = entrydetail.nentry AND
				  entry.yentry = entrydetail.yentry 
			JOIN account AC
			  ON AC.idacc =  entrydetail.idacc
			WHERE ((AC.flagaccountusage & 262144)<> 0)  -- Fondi Riserve Ex COFI
			AND entry.identrykind = 7 --- apertura
			AND entry.yentry = (@ayear)  
			GROUP BY entrydetail.idupb 
	 
	IF (SELECT COUNT(*) FROM #reserve ) = 0
	BEGIN
	--	FASE 2 RICAVI RISERVE EX COFI
	--  determino saldo scritture su conto Ex Riserve COFI ANNO PRECEDENTE
 
			INSERT INTO #reserve
				(
					idupb,	 			
					amount,  
					accountkind
				)
			SELECT 
					entrydetail.idupb,			
					ISNULL(SUM(amount),0), --totale avere > 0
					'F'
			FROM entrydetail  
			JOIN entry 
			  ON  entry.nentry = entrydetail.nentry AND
				  entry.yentry = entrydetail.yentry 
			JOIN account AC
			  ON AC.idacc =  entrydetail.idacc
			WHERE ((AC.flagaccountusage & 262144)<> 0)  -- Fondi Riserve Ex COFI
			AND entry.yentry = (@ayear - 1)  
			GROUP BY entrydetail.idupb 
			HAVING ISNULL(SUM(amount),0) >0
	END
    --SELECT * FROM #reserve
	--previsioni iniziali per l'esercizio corrente
		INSERT INTO #budgetupb
			(
				idacc, 	
				idupb,			
				rowkind,
				operationdate,
				operationkind,	
				initialprevision,
				initialprevision2, 	
				initialprevision3 	
			)
		SELECT 
			AVD.idacc, 	
			AVD.idupb,
			1,		/* rowkind  = 1				Prev. iniziale Conti di COSTO */
			null,
			'Prev. iniziale Budget Costi',	
			isnull(amount,0),
			isnull(amount2,0), 	
			isnull(amount3,0)	
		from accountvar AV
		join accountvardetail AVD
			 on AV.yvar = AVD.yvar AND  AV.nvar = AVD.nvar 
			join account A
			on AVD.idacc = A.idacc
		WHERE AV.yvar = @ayear AND AV.variationkind = 5 --- INIZIALE
			--AND ((A.flagaccountusage & 320)<> 0)  	 -- conti di Costo e Immobilizzazioni
			and ( (A.flagaccountusage & 64) <> 0 OR (A.flagaccountusage & 131072)<>0 ) /*costi o ammortamento*/
		IF (@prevcorrente = 'S') 
		BEGIN
		-- e stiamo facendo il budget corrente deve includere nel calcolo gli storni  e le variazioni normali alla data
		INSERT INTO #budgetupb
			(
				idacc, 		idupb,	rowkind,		operationdate,	operationkind,	
				ymov,		nmov,		
				amount, amount2, amount3,
				initialprevision,initialprevision2, initialprevision3
			)
		SELECT 
				accountvardetail.idacc, 	
				accountvardetail.idupb,		
				2,	
				accountvar.adate,
				'Var. prev. Budget Costi',	
				accountvar.yvar,		accountvar.nvar,	
				isnull(accountvardetail.amount,0),
				isnull(accountvardetail.amount2,0),
				isnull(accountvardetail.amount3,0),
				0,0,0	
		from accountvar
		join accountvardetail			
			ON accountvar.yvar = accountvardetail.yvar
			AND accountvar.nvar = accountvardetail.nvar
		join account A
			on accountvardetail.idacc = A.idacc
		where accountvar.adate <= @adate
			--AND ((A.flagaccountusage & 320)<> 0)  	 -- conti di Costo
			AND ( (A.flagaccountusage & 64) <> 0 OR (A.flagaccountusage & 131072)<>0 ) /*costi o ammortamento*/
			and accountvar.yvar = @ayear
			and accountvar.idaccountvarstatus=5 
			and accountvar.variationkind <> 5 and accountvar.variationkind <> 6 
		END
 
		INSERT INTO #budgetupb
			(
				idacc, 	
				idupb,			
				rowkind,
				operationdate,
				operationkind,	
				initialprevision,
				initialprevision2, 	
				initialprevision3	
			)
		SELECT 
			AVD.idacc, 	
			AVD.idupb,
			10,		/* rowkind  = 10			Prev. iniziale Conti di RICAVO*/
			null,
			'Prev. iniziale Budget Ricavi',	
			isnull(amount,0),
			isnull(amount2,0), 	
			isnull(amount3,0)		
		from accountvar AV
		join accountvardetail AVD			
			ON AV.yvar = AVD.yvar
			AND AV.nvar = AVD.nvar
		join account A
			on AVD.idacc = A.idacc
		WHERE AVD.yvar = @ayear
			AND ((A.flagaccountusage & 128)<> 0)  	 -- conti di Ricavo		
			and ( A.flagaccountusage & 524288 ) = 0 --> Escludi i conti che si è scelto di escludere dal calcolo. Task 15404
		 and AV.variationkind  = 5 
	IF (@prevcorrente = 'S') 
		BEGIN
		-- e stiamo facendo il budget corrente deve includere nel calcolo gli storni  e le variazioni normali alla data
		INSERT INTO #budgetupb
			(
				idacc, 		idupb,	rowkind,		operationdate,	operationkind,
				ymov,		nmov,				
				amount, amount2, amount3,
				initialprevision,initialprevision2, initialprevision3
			)
			SELECT 
				accountvardetail.idacc, 	
				accountvardetail.idupb,			
				20,		/* rowkind  = 20			Var. Prev. iniziale Conti di RICAVO*/
				accountvar.adate,
				'Var. prev. Budget Ricavi',	
				accountvar.yvar,		accountvar.nvar,	
				isnull(accountvardetail.amount,0),
				isnull(accountvardetail.amount2,0),
				isnull(accountvardetail.amount3,0),
				0,0,0 		
			from accountvar
 			join accountvardetail			
				ON accountvar.yvar = accountvardetail.yvar
				AND accountvar.nvar = accountvardetail.nvar
		 	join account A
	  			on accountvardetail.idacc = A.idacc
			where accountvar.adate <= @adate
				AND ((A.flagaccountusage & 128)<> 0)  	 -- conti di Ricavo
				and ( A.flagaccountusage & 524288 ) = 0 --> Escludi i conti che si è scelto di escludere dal calcolo. Task 15404
				and accountvar.yvar = @ayear
				and accountvar.idaccountvarstatus=5 
				and accountvar.variationkind <> 5 and accountvar.variationkind <> 6 
		END
		--	SELECT * FROM #budgetupb where idupb = '00010003'
	--sELECT * FROM #automaticbudget  where idupb = '00010003' AND AMOUNT> 0

		--sELECT * FROM #automaticbudget  where idupb = '00010003' AND AMOUNT< 0
		INSERT INTO #budgetsituation
				(
					idupb,	 			
					amount, amount2, amount3,
					accountkind,
					amm_futuricespiti
				)
			SELECT 
				#budgetupb.idupb,			
				sum(isnull(#budgetupb.initialprevision,0)) + sum(isnull(#budgetupb.amount,0)),
				sum(isnull(#budgetupb.initialprevision2,0)) + sum(isnull(#budgetupb.amount2,0)),
				sum(isnull(#budgetupb.initialprevision3,0)) + sum(isnull(#budgetupb.amount3,0)),
				CASE	WHEN ((A.flagaccountusage & 128)<> 0) THEN 'R'  	-- conti di Ricavo
					WHEN ((A.flagaccountusage & 64)<> 0) THEN 'C'			-- conti di costo
					WHEN ((A.flagaccountusage & 131072)<> 0) THEN 'A'			-- conti di ammortamento
					WHEN ((A.flagaccountusage & 256)<> 0) THEN 'I'			-- o Immobilizzazioni
				END as accountkind,
				0
			FROM #budgetupb JOIN account A ON #budgetupb.idacc = A.idacc
			 
			GROUP BY #budgetupb.idupb,
			CASE	WHEN ((A.flagaccountusage & 128)<> 0) THEN 'R'  		-- conti di Ricavo
					WHEN ((A.flagaccountusage & 64)<> 0) THEN 'C'			-- conti di costo
					WHEN ((A.flagaccountusage & 131072)<> 0) THEN 'A'			-- conti di ammortamento
					WHEN ((A.flagaccountusage & 256)<> 0) THEN 'I'			-- o Immobilizzazioni
			END 

			UNION
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
 

 IF (SELECT count(*) FROM #reserve WHERE accountkind = 'F')>0
 BEGIN
	DECLARE amt_crs4 INSENSITIVE CURSOR FOR
		SELECT  idupb FROM #reserve WHERE accountkind = 'F' GROUP BY idupb
		FOR READ ONLY
		OPEN amt_crs4
	FETCH NEXT FROM amt_crs4 INTO @idupb 
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
			SELECT @amount = 0
			SELECT @amount2 = 0
			SELECT @amount3 = 0
			--select * from #budgetsituation where idupb =@idupb
			SELECT @riserve_ex_cofi_1_anno = (ISNULL(SUM(amount),0)) FROM #reserve where idupb = @idupb and accountkind = 'F' 
			SELECT @totcosti_upb_1_anno = (ISNULL(SUM(amount),0)) FROM #budgetsituation where idupb = @idupb and accountkind IN ('C','I','A') 
			SELECT @totricavi_upb_1_anno = (ISNULL(SUM(amount),0)) FROM #budgetsituation where idupb = @idupb and accountkind = 'R' 
 
			SELECT @totcosti_upb_2_anno = (ISNULL(SUM(amount2),0)) FROM #budgetsituation where idupb = @idupb and accountkind IN ('C','I','A') 
			SELECT @totricavi_upb_2_anno = (ISNULL(SUM(amount2),0)) FROM #budgetsituation where idupb = @idupb and accountkind = 'R' 
 
			SELECT @totcosti_upb_3_anno = (ISNULL(SUM(amount3),0)) FROM #budgetsituation where idupb = @idupb and accountkind IN ('C','I','A') 
			SELECT @totricavi_upb_3_anno = (ISNULL(SUM(amount3),0)) FROM #budgetsituation where idupb = @idupb and accountkind = 'R' 
 
			print 'riserve'
			print @riserve_ex_cofi_1_anno
			print @totcosti_upb_1_anno
			print @totricavi_upb_1_anno
			print @totcosti_upb_1_anno - @totricavi_upb_1_anno
			IF ((@totcosti_upb_1_anno - @totricavi_upb_1_anno) > 0) 
			BEGIN
				IF (@riserve_ex_cofi_1_anno) >= (@totcosti_upb_1_anno - @totricavi_upb_1_anno)
					SELECT @amount= ISNULL(@totcosti_upb_1_anno - @totricavi_upb_1_anno,0)
				ELSE
					SELECT @amount= ISNULL(@riserve_ex_cofi_1_anno,0)
					print  @amount
			END
			SELECT @riserve_ex_cofi_2_anno =  @riserve_ex_cofi_1_anno - @amount
			IF ((@totcosti_upb_2_anno - @totricavi_upb_2_anno) > 0) 
			BEGIN
					IF (@riserve_ex_cofi_2_anno) >= (@totcosti_upb_2_anno - @totricavi_upb_2_anno)
					SELECT @amount2= ISNULL(@totcosti_upb_2_anno - @totricavi_upb_2_anno,0)
					ELSE
					SELECT @amount2= ISNULL(@riserve_ex_cofi_2_anno,0)
					print  @amount2
			END
			SELECT @riserve_ex_cofi_3_anno =  @riserve_ex_cofi_2_anno - @amount2
			IF ((@totcosti_upb_3_anno - @totricavi_upb_3_anno) > 0) 
			BEGIN
					IF (@riserve_ex_cofi_3_anno) >= (@totcosti_upb_2_anno - @totricavi_upb_2_anno)
					SELECT @amount3= ISNULL(@totcosti_upb_3_anno - @totricavi_upb_3_anno,0)
					ELSE
					SELECT @amount3= ISNULL(@riserve_ex_cofi_3_anno,0)
					print  @amount3
			END
				-- creazione di una previsione di ricavo su un conto specIFico di ricavo 
					--SELECT @maxidautomaticbudget = max(idautomaticbudget) from #automaticbudget
					INSERT INTO #automaticbudget
					(
						--idautomaticbudget,
						idaccmotiveload,
						kind, 
						amount,
						amount2, 
						amount3, 
						adate, 
						idupb,
						idacc, 
						ayear
					)
					SELECT
						/*@maxidautomaticbudget + 1,*/@idaccmotiveload,'RESERVE',@amount,@amount2,@amount3,
							@adate, @idupb, @idacc_revenue_reserve_ex_cofi,@ayear
			END
		
	FETCH NEXT FROM amt_crs4 INTO  @idupb 
	END
	DEALLOCATE amt_crs4
	end
	
declare  @tab_ricavi RevenueTableType
			--( idupb varchar(36),	 	
			--idacc varchar(38),			
			--amount decimal(19,2),
			--accountkind char(1) ); -- SEMPRE R--> RICAVI

CREATE TABLE #t_risconti_ripartiti (idupb varchar(36),	idacc varchar(38), importo decimal(19,2))
 

 ----FASE 3 RETTIFICHE, INSERISCO I DATI DELLE ELABORAZIONI DEI PRECEDENTI PUNTI 1)	 E 2)
 INSERT INTO #budgetsituation
				(
					idupb,	 			
					amount, amount2, amount3,
					accountkind
				)
				SELECT autob.idupb, sum(isnull(autob.amount,0)),sum(isnull(autob.amount2,0)), sum(isnull(autob.amount3,0)),   
				CASE	WHEN ((A.flagaccountusage & 128)<> 0) THEN 'R'  		-- conti di Ricavo
					WHEN ((A.flagaccountusage & 64)<> 0) THEN 'C'			-- conti di costo
					WHEN ((A.flagaccountusage & 131072)<> 0) THEN 'A'			-- conti di ammortamento
					WHEN ((A.flagaccountusage & 256)<> 0) THEN 'I'			-- o Immobilizzazioni
				END 
			FROM #automaticbudget	 autob (nolock)  
			 
			JOIN account A (NOLOCK) ON A.idacc = autob.idacc  
			WHERE autob.adate = @adate AND autob.ayear = @ayear
			AND autob.kind IN ('RESERVE')
			GROUP BY autob.idupb, 
			CASE	WHEN ((A.flagaccountusage & 128)<> 0) THEN 'R'  		-- conti di Ricavo
					WHEN ((A.flagaccountusage & 64)<> 0) THEN 'C'			-- conti di costo
					WHEN ((A.flagaccountusage & 131072)<> 0) THEN 'A'			-- conti di ammortamento
					WHEN ((A.flagaccountusage & 256)<> 0) THEN 'I'			-- o Immobilizzazioni
			END 

--select avd.idupb,  
--			(SELECT	-SUM(isnull(amount,0)) FROM #budgetsituation B  WHERE B.accountkind = 'C' AND B.idupb = avd.idupb) as cost,
--			(SELECT	 SUM(isnull(amount,0)) FROM #budgetsituation B   WHERE B.accountkind = 'R' AND B.idupb = avd.idupb) as revenue,
--			EU.idacc_revenue, EU.idaccmotive_revenue,  year(U.stop) as yearstop, 
--			YEAR(U.start) as yearstart   
--			FROM #budgetsituation avd (nolock)  
--			join upb u (nolock) on avd.idupb = u.idupb 
--			join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind 
--			--join account A (nolock) on A.idacc = avd.idacc  
--			WHERE ((year(U.start) IS NULL)OR(year(U.start)<=@ayear)) AND(year(U.stop)>@ayear)
--			AND	(EU.ayear=@ayear)
--			AND	(EU.adjustmentkind='C')   
--			AND YEAR(U.stop)> @ayear
--			group by avd.idupb, EU.idacc_revenue, EU.idaccmotive_revenue,  
--			YEAR(U.stop),year(U.start),U.idepupbkind,U.codeupb,U.title 
--			order by U.codeupb 
--DECLARE @idupb varchar(38)
DECLARE @cost decimal(19,2)
DECLARE @revenue decimal(19,2)
DECLARE @idacc_revenue varchar(38)
DECLARE @idaccmotive_revenue varchar(36)
DECLARE @yearstart int
DECLARE @yearstop int
DECLARE @importo decimal(19,2)
SET		@rownum = 0
 --select * from #budgetsituation
 -- select * from #automaticbudget


UPDATE #budgetsituation SET idupb_capofila = (select idupb_capofila from upb WHERE #budgetsituation.idupb = upb.idupb)
UPDATE #budgetsituation SET idupb_capofila = #budgetsituation.idupb where idupb_capofila IS NULL

DECLARE amt_crs5 INSENSITIVE CURSOR FOR
		select avd.idupb_capofila,  
			(SELECT	 SUM(isnull(amount,0)) FROM #budgetsituation B   WHERE B.accountkind IN ('C','I','A') AND B.idupb_capofila = avd.idupb_capofila) as cost,
			(SELECT	 SUM(isnull(amount,0)) FROM #budgetsituation B   WHERE B.accountkind = 'R' AND B.idupb_capofila = avd.idupb_capofila) as revenue,
			EU.idacc_revenue, EU.idaccmotive_revenue,  year(U.stop) as yearstop, 
			YEAR(U.start) as yearstart   
			FROM #budgetsituation avd (nolock)  
			join upb u (nolock) on avd.idupb_capofila = u.idupb 
			join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind 
			WHERE ((year(U.start) IS NULL)OR(year(U.start)<=@ayear)) 
			AND(year(U.stop)>@ayear)
			AND	(EU.ayear=@ayear)
			AND	(EU.adjustmentkind='C')   
			group by avd.idupb_capofila, EU.idacc_revenue, EU.idaccmotive_revenue,  
			YEAR(U.stop),year(U.start),U.idepupbkind,U.codeupb,U.title 
		FOR READ ONLY
		OPEN amt_crs5
	FETCH NEXT FROM amt_crs5 INTO @idupb,@cost, @revenue,  @idacc_revenue, @idaccmotive_revenue,@yearstop,@yearstart
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
			--if ( @idupb='0001000300020040')
			--	begin select isnull(@cost,0) , isnull(@revenue,0)
			--	end
			SET @importo= 0
			SET @importo  = isnull(@cost,0)  - isnull(@revenue,0)
			-- calcola_integrazione_previsione '2019', {d '2019-12-31'}, '3'
			IF (@importo > 0)   --- attenzione c
			BEGIN
				SET @rownum = @rownum +1
				print 'ratei'
				INSERT INTO #automaticbudget
				(
					--idautomaticbudget,
					idaccmotiveload,
					kind, 
					amount,
					amount2, 
					amount3, 
					yvar, 
					nvar, 
					rownum,
					adate, 
					idupb,
					idacc, 
					ayear
				)
				SELECT
					/*@maxidautomaticbudget + 1,*/@idaccmotive_revenue,'ADJUSTMENT',@importo,0,0,@ayear,99999,@rownum,
						@adate, @idupb, @idacc_revenue,@ayear
		   END
		   ELSE
		   IF (@importo < 0) 
			BEGIN
			print 'risconti'
			delete from @tab_ricavi
			 INSERT INTO @tab_ricavi
				SELECT
				#budgetupb.idupb,
				#budgetupb.idacc,			
				sum(isnull(#budgetupb.initialprevision,0)) + sum(isnull(#budgetupb.amount,0)),			-- prendiamo solo il primo anno
				'R'-- conti di Ricavo
				FROM #budgetupb
				WHERE #budgetupb.rowkind in (10,20)  --  = 'R'  	-- conti di Ricavo
				AND #budgetupb.idupb = @idupb
				GROUP by #budgetupb.idupb,#budgetupb.idacc

			INSERT INTO #automaticbudget
				(
					--idautomaticbudget,
					idaccmotiveload,
					kind, 
					amount,
					amount2, 
					amount3, 
					yvar, 
					nvar, 
					rownum,
					adate, 
					idupb,
					idacc, 
					ayear
				)
				SELECT
						@idaccmotive_revenue,'ADJUSTMENT',-TResult.importo,0,0,@ayear,99999,@rownum + TResult.ndetail,
						@adate, @idupb, TResult.idacc,@ayear
					FROM  [f_ripartisci_risconto_su_ricavi_upb](- @importo ,@tab_ricavi) AS TResult
				SET @rownum = @rownum + (SELECT COUNT(*) from [f_ripartisci_risconto_su_ricavi_upb](- @importo ,@tab_ricavi) AS TResult)
		   END
	FETCH NEXT FROM amt_crs5 INTO @idupb,@cost, @revenue,  @idacc_revenue, @idaccmotive_revenue,@yearstop,@yearstart
	end
	DEALLOCATE amt_crs5
 
 --select * from #automaticbudget
 -- Introdotto col task 15403
 -- E' la parte ELSE del amt_crs5 precedente, a cui ho modificato la condizione della WHERE
 declare @amm_futuricespiti decimal(19,2)
 if ((@riscontaricavi_ammortamentifuturi='S') and (@exportazionekind in (3, 10) ) )
 Begin
		DECLARE amt_crs5_BIS INSENSITIVE CURSOR FOR
				select 
						avd.idupb_capofila,  
						EU.idaccmotive_revenue, 
						sum(avd.amm_futuricespiti)
					FROM #budgetsituation avd (nolock)  
					join upb u (nolock) on avd.idupb_capofila = u.idupb 
					join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind 
					WHERE ((year(U.start) IS NULL)OR(year(U.start)<=@ayear)) 
					AND(year(U.stop)<=@ayear)
					AND	(EU.ayear=@ayear)
					AND	(EU.adjustmentkind='C')   
					and isnull(amm_futuricespiti,0) <>0
					GROUP BY avd.idupb_capofila, EU.idaccmotive_revenue,  U.idepupbkind,U.codeupb,U.title 
										

				FOR READ ONLY
				OPEN amt_crs5_BIS
			FETCH NEXT FROM amt_crs5_BIS INTO @idupb, @idaccmotive_revenue, @amm_futuricespiti
			WHILE (@@FETCH_STATUS = 0)
			BEGIN
			
					print 'risconti che deve essere pari agli AMMORTAMENTI FUTURI dei cespiti presenti sull UPB'
					delete from @tab_ricavi
					 INSERT INTO @tab_ricavi
						SELECT
						#budgetupb.idupb,
						#budgetupb.idacc,			
						sum(isnull(#budgetupb.initialprevision,0)) + sum(isnull(#budgetupb.amount,0)),			-- prendiamo solo il primo anno
						'R'-- conti di Ricavo
						FROM #budgetupb
						WHERE #budgetupb.rowkind in (10,20)  --  = 'R'  	-- conti di Ricavo
						AND #budgetupb.idupb = @idupb
						GROUP by #budgetupb.idupb,#budgetupb.idacc

					INSERT INTO #automaticbudget(
							idaccmotiveload,
							kind, 
							amount,
							amount2, 
							amount3, 
							yvar, 
							nvar, 
							rownum,
							adate, 
							idupb,
							idacc, 
							ayear
						)
						SELECT
								@idaccmotive_revenue,'ADJUSTMENT_F',-TResult.importo,0,0,@ayear,99999,@rownum + TResult.ndetail,
								@adate, @idupb, TResult.idacc,@ayear
							FROM  [f_ripartisci_risconto_su_ricavi_upb](+ @amm_futuricespiti, @tab_ricavi) AS TResult

						SET @rownum = @rownum + (SELECT COUNT(*) from [f_ripartisci_risconto_su_ricavi_upb](+ @amm_futuricespiti ,@tab_ricavi) AS TResult)
		   

			FETCH NEXT FROM amt_crs5_BIS INTO @idupb, @idaccmotive_revenue, @amm_futuricespiti
			end
			DEALLOCATE amt_crs5_BIS
 End
 
IF ((@creavar = 'S') AND (@prevcorrente = 'N') /*il salvataggio della previsione iniziale non include le variazioni e gli storni alla data*/AND  (SELECT COUNT(*) FROM #automaticbudget)>0)
BEGIN
----1) Cancello la precedente variazione di tipo 6
	DECLARE @integravar int
	SELECT  @integravar = isnull(max(nvar),0) from accountvar where yvar = @ayear AND variationkind = 6 -- Integrazione previsione iniziale
	
	IF (@integravar > 0)
	BEGIN
		DELETE FROM accountvardetail WHERE  yvar = @ayear AND nvar = @integravar
		DELETE FROM accountvar WHERE  yvar = @ayear AND nvar = @integravar
	END

--- 2) Copio la variazione iniziale esistente nella nuova variazione di tipo 6 -- Integrazione variazione iniziale
	DECLARE @maxnvar int
	 
	SELECT  @maxnvar = isnull(max(nvar),0) from accountvar where yvar = @ayear

	INSERT INTO accountvar 
	(
		yvar	,
		nvar	,
		adate	,
		annotation	,
		ct	,
		cu	,
		description	,
		enactment	,
		enactmentdate	,
		idaccountvarstatus	,
		idman	,
		idsor01	,
		idsor02	,
		idsor03	,
		idsor04	,
		idsor05	,
		lt	,
		lu	,
		nenactment	,
		reason	,
		rtf	,
		txt	,
		variationkind,
		idenactment	,
		flag	
	)

	SELECT 
		yvar,
		ISNULL(@maxnvar,0) +1,
		@adate,
		null,
		GetDate()	,
		'Integrazione',
		'Budget iniziale non operativa'	,
		null	,
		null	,
		4	,   --- deve essere inserita e non approvata per non incidere sul budget operativo
		null	,
		null, -- idsor01	,
		null, --idsor02	,
		null, --idsor03	,
		null, --idsor04	,
		null, --idsor05	,
		GetDate()	,
		lu	,
		null	,
		null	,
		null	,
		null	,
		6, --variationkind, Integrazione previsione iniziale
		null	,
		flag	
	FROM accountvar
	WHERE yvar = @ayear AND  nvar in (SELECT top 1  nvar from accountvar where yvar = @ayear AND variationkind = 5)
	AND variationkind = 5 --- Previsione Iniziale

	INSERT INTO accountvardetail
	(	
		nvar	,
		yvar	,
		rownum	,
		amount	,
		amount2	,
		amount3	,
		amount4	,
		amount5	,
		--annotation	,
		ct	,
		cu	,
		description	,
		idacc	,
		idupb	,
		lt	,
		lu	 
	)
	
	SELECT
		ISNULL(@maxnvar,0) +1,
		@ayear,
		ROW_NUMBER() OVER(ORDER BY  B.idacc, B.idupb ASC) ,
		SUM(isnull(B.amount,0)),
		SUM(isnull(B.amount2,0)),
		SUM(isnull(B.amount3,0)),
		null,
		null,
		--annotation	,
		GetDate()	,
		'Integrazione'	,
		'Previsione iniziale',
		B.idacc,
		B.idupb,
		GetDate(),
		'Integrazione'
	FROM  accountvardetail B  
	WHERE nvar in (select nvar from accountvar where yvar = @ayear and variationkind = 5 ) and yvar = @ayear
	GROUP BY   B.idacc, B.idupb 
	HAVING (SUM(isnull(B.amount,0))<> 0 OR  SUM(isnull(B.amount2,0)) <>0 OR  SUM(isnull(B.amount3,0)) <> 0)

	--3) Inserisco i dettagli di integrazione
	DECLARE @maxrownum int
	SELECT @maxrownum =   MAX(rownum) FROM accountvardetail
	WHERE yvar = @ayear AND  nvar = ISNULL(@maxnvar,0) +1

	INSERT INTO accountvardetail
	(	
		nvar	,
		yvar	,
		rownum	,
		amount	,
		amount2	,
		amount3	,
		amount4	,
		amount5	,
		--annotation	,
		ct	,
		cu	,
		description	,
		idacc	,
		idupb	,
		lt	,
		lu	 
	)
	SELECT
		ISNULL(@maxnvar,0) +1,
		@ayear,
		@maxrownum +ROW_NUMBER() OVER(ORDER BY  parent.idacc, B.idupb ASC) ,
		SUM(isnull(amount,0)),
		SUM(isnull(amount2,0)),
		SUM(isnull(amount3,0)),
		null,
		null,
		--annotation	,
		GetDate()	,
		'Integrazione'	,
		case
			when B.kind ='INIZIALI' then 'Prev. iniziali' -- 0 -- 
			when B.kind ='ASSET' then 'Ammortamenti da Cespiti' -- 1 --
			when B.kind ='ACCOUNTVAR' then 'Ammortamenti da Budget Investimenti'-- 1 --
			when B.kind ='RESERVE' then 'Prev.Ricavo'	-- 2 --
			when B.kind ='ADJUSTMENT' then 'Rettifiche Commessa completata'	-- 3 --
			when B.kind ='ADJUSTMENT_F' then 'Risconto per ammortamenti futuri'
		end as 'Tipologia',
		parent.idacc	,
	    B.idupb,	
		GetDate()	,
		'Integrazione'	 
	FROM #automaticbudget B
	JOIN accountlevel	 minlevop		(NOLOCK) on	 minlevop.nlevel = (select min(nlevel) from accountlevel 
																			where ayear = @ayear and flagusable = 'S')	
																			AND @ayear = minlevop.ayear
	JOIN account parent	(NOLOCK)	ON parent.idacc  =  substring(B.idacc, 1, 2 + 4*minlevop.nlevel) AND minlevop.nlevel =parent.nlevel
	--WHERE yvar = @ayear 
	GROUP BY   parent.idacc, B.idupb,B.kind 
END
 

--select * from #budgetupb
--select * from #automaticbudget
if( @exportazionekind = 0)
Begin
	select 	
		B.idacc, 	B.idupb,
		B.yvar  , B.nvar  ,	
		@adate,
		null as idasset,
		null as idpiece,
		B.rownum,
		null as kind,
		0 as amount,
		0 as amount2,
		0 as amount3,
		isnull(B.amount,0)  as initialprevision ,	isnull(B.amount2,0)   as initialprevision2,	isnull(B.amount3,0) as initialprevision3
		--operationkind,
		--rowkind,
	FROM accountvardetail B  join accountvar A on A.yvar = B.yvar and A.nvar = B.nvar 
	WHERE     A.variationkind = 5  and A.yvar = @ayear --and A.adate<=@adate
	RETURN
End 
if (@exportazionekind =1)
Begin
	select 	 
	--idaccmotiveload, 
	parent.idacc, 	idupb,
	yvar, nvar,	
	adate, 
	idasset, idpiece,rownum,
	kind, 
	amount, amount2, amount3 , 
	null as initialprevision ,	null as initialprevision2,	null as initialprevision3 
	--ayear,
	FROM #automaticbudget B
	JOIN accountlevel	 minlevop		(NOLOCK) on	 minlevop.nlevel = (select min(nlevel) from accountlevel 
																			where ayear = @ayear and flagusable = 'S')	
																			AND @ayear = minlevop.ayear
	JOIN account parent	(NOLOCK)	ON parent.idacc  =  substring(B.idacc, 1, 2 + 4*minlevop.nlevel) AND minlevop.nlevel =parent.nlevel

	WHERE B.kind in ('ASSET','ACCOUNTVAR')
	RETURN
End
if (@exportazionekind =2)
Begin
	select 	 
	--idaccmotiveload, 
	parent.idacc, 	idupb,
	yvar, nvar,	
	adate, 
	idasset, idpiece,rownum,
	kind, 
	amount, amount2, amount3 , 
	null as initialprevision ,	null as initialprevision2,	null as initialprevision3 
	--ayear,
	FROM #automaticbudget B
	JOIN accountlevel	 minlevop		(NOLOCK) on	 minlevop.nlevel = (select min(nlevel) from accountlevel 
																			where ayear = @ayear and flagusable = 'S')	
																			AND @ayear = minlevop.ayear
	JOIN account parent	(NOLOCK)	ON parent.idacc  =  substring(B.idacc, 1, 2 + 4*minlevop.nlevel) AND minlevop.nlevel =parent.nlevel

	WHERE B.kind ='RESERVE'
	RETURN
End

if (@exportazionekind = 3)
Begin
	select 	 
	--idaccmotiveload, 
	parent.idacc, idupb,
	yvar, nvar,	
	adate, 
	idasset, idpiece,rownum,
	kind, 
	amount, amount2, amount3 , 
	null as initialprevision ,	null as initialprevision2,	null as initialprevision3 
	--ayear,
	FROM #automaticbudget B
	JOIN accountlevel	 minlevop		(NOLOCK) on	 minlevop.nlevel = (select min(nlevel) from accountlevel 
																			where ayear = @ayear and flagusable = 'S')	
																			AND @ayear = minlevop.ayear
	JOIN account parent	(NOLOCK)	ON parent.idacc  =  substring(B.idacc, 1, 2 + 4*minlevop.nlevel) AND minlevop.nlevel =parent.nlevel

	where B.kind in ('ADJUSTMENT', 'ADJUSTMENT_F')
	RETURN
End


if (@exportazionekind = 10)
Begin
	select
		B.idacc, 	B.idupb,
		B.yvar  , B.nvar  ,	
		@adate as adate,
		null as idasset,
		null as idpiece,
		B.rownum as rownum,
		'INIZIALI' as kind,
		0 as amount,
		0 as amount2,
		0 as amount3,
		isnull(B.amount,0) as initialprevision ,	isnull(B.amount2,0) as initialprevision2,	isnull(B.amount3,0) as initialprevision3
	FROM accountvardetail B  join accountvar A on A.yvar = B.yvar and A.nvar = B.nvar 
	WHERE     A.variationkind = 5  and A.yvar = @ayear --and A.adate<=@adate
	union
	select 	 
		parent.idacc, idupb, 
		yvar, nvar,
		adate, 
		idasset,
		idpiece,
		rownum,
		--ayear,
		kind ,
		isnull(amount,0) as amount ,	isnull(amount2,0) as amount2,	isnull(amount3,0) as amount3,
		0 as initialprevision ,	0 as initialprevision2,	0 as initialprevision3 
		-- idaccmotiveload, 
	FROM #automaticbudget B
	JOIN accountlevel	 minlevop		(NOLOCK) on	 minlevop.nlevel = (select min(nlevel) from accountlevel 
																			where ayear = @ayear and flagusable = 'S')	
																			AND @ayear = minlevop.ayear
	JOIN account parent	(NOLOCK)	ON parent.idacc  =  substring(B.idacc, 1, 2 + 4*minlevop.nlevel) AND minlevop.nlevel =parent.nlevel

	RETURN
End
 
END 

 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- calcola_integrazione_previsione '2020', {d '2020-06-17'}, '3'
