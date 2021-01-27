
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


--closeyear_asset_ammortization 2011
if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_asset_ammortization]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_asset_ammortization]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 
CREATE PROCEDURE [closeyear_asset_ammortization]
(
	@ayear int,
	@buonoscarico char(1) = 'S'
)
AS BEGIN
-- setuser 'amm'
---- closeyear_asset_ammortization 2014,'N'
--la stored procedure GetAssetValue è usata per valutare l'importo corrente dei cespiti
--la stored procedure get_originalassetvalue è usata per valutare l'importo iniziale dei cespiti, su cui calcolare l'ammortamento
-- se l'ammortamento calcolato è tale da rendere il valore corrente viene considerata una base per l'ammortamento opportunamente ridotta
--   in modo da far si che l'aliquota di ammortamento per la base di ammortamento vada ad azzerare il valore residuo del cespite

DECLARE @dec_31 datetime
SELECT  @dec_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)
DECLARE @namortization int
SELECT  @namortization = ISNULL((SELECT MAX(namortization) FROM assetamortization),0) + 1
DECLARE @idinventoryamortization int
DECLARE @idasset int
DECLARE @idpiece int
DECLARE @description varchar(150)
DECLARE @assetvalue decimal(19,2)
DECLARE @amortizationquota float
DECLARE @actualvalue decimal(19,2)
DECLARE @reval decimal(19,2)
declare @startvalue decimal(19,2)

declare @descr_amm varchar(150)

-- Caso in cui il cespite ha data di inizio esistenza a NULL
-- Applico tutte le rivalutazioni UFFICIALI che nell'anno sono associate alla classificazione del cespite e che hanno ETA NULL
DECLARE amt_crs INSENSITIVE CURSOR FOR
SELECT  DISTINCT
	tr.idinventoryamortization,
	b.idasset,	b.idpiece,
	c.description,
	coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)
FROM asset b
JOIN assetacquire c							ON b.nassetacquire = C.nassetacquire
JOIN assetview_current ac					ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
LEFT OUTER JOIN assetload					ON assetload.idassetload = c.idassetload			
LEFT OUTER JOIN assetunload AU				ON AU.idassetunload = B.idassetunload	
LEFT OUTER JOIN inventorytreelink IL1		ON IL1.idchild = C.idinv AND IL1.nlevel  = 1 
LEFT OUTER JOIN inventorytreelink IL2		ON IL2.idchild = C.idinv  AND IL2.nlevel = 2
LEFT OUTER JOIN inventorytreelink IL3		ON IL3.idchild = C.idinv  AND IL3.nlevel = 3 
LEFT OUTER JOIN inventorytreelink IL4		ON IL4.idchild = C.idinv  AND IL4.nlevel = 4 
LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayear 
	LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayear
								and T4.idinv is null
	LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayear 
								and T4.idinv is null and T3.idinv is null	
	LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayear
				and T4.idinv is null and T3.idinv is null	and  T2.idinv is null
JOIN inventoryamortization tr			ON tr.idinventoryamortization = 
			COALESCE( t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
WHERE   b.lifestart IS NULL
	AND (tr.flag & 2 <> 0) --ufficiale
	AND ((tr.flag&8) <> 0) -- ammortamenti
	AND tr.age IS NULL
	AND ISNULL(tr.active,'S')= 'S'
	AND (b.flag & 1 <> 0)
	AND NOT EXISTS(
		SELECT * FROM assetamortization r join inventoryamortization tr1 
			ON  r.idinventoryamortization = tr1.idinventoryamortization  
		WHERE r.idasset = b.idasset AND r.idpiece = b.idpiece
			AND YEAR(r.adate) = @ayear
			AND (tr.flag&8) = (tr1.flag&8))
	AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start)))
	AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
	AND (AU.adate is null OR YEAR(AU.adate)>@ayear )
	AND b.amortizationquota is null
FOR READ ONLY

OPEN amt_crs
FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota
WHILE (@@FETCH_STATUS = 0)
BEGIN

	execute get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue OUTPUT, @actualvalue OUTPUT 
	--@assetvalue valore ORIGINALE alla data del 31 12 dell'anno
	--@actualvalue valore ATTUALE alla data del 31 12 dell'anno

    if @actualvalue > 0  
	BEGIN
	
		SET @reval=ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2)

		-- Viene sostituito il precedente controllo (@reval > @actualvalue) in quanto @reval nel caso di ammortamenti
		-- è negativo! Quindi la somma algebrica dei due importi deve essere sempre >=0
		IF ( (@reval + @actualvalue) < 0) 
		BEGIN
			SET @amortizationquota  = -@actualvalue/@assetvalue
		END

		SET @reval = ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2) 
		if (@reval <>0) 
		BEGIN
		
			set @descr_amm = 'valore iniziale:'+convert(varchar(30),@assetvalue)+
							' attuale:'+convert(varchar(30),@actualvalue)+
							+' aliq.applicata:'+	convert(varchar(30),@amortizationquota*100)

			SELECT @namortization = ISNULL((SELECT MAX(namortization) FROM assetamortization),0) + 1
			INSERT INTO assetamortization
				(namortization,	idinventoryamortization,
				idasset,	idpiece,
				description,
				assetvalue,		amortizationquota,
					adate,flag,
				cu, ct, lu, lt
				)
    		VALUES
			( 	@namortization,	@idinventoryamortization,
				@idasset,		@idpiece,
				@descr_amm,
				@assetvalue,
				@amortizationquota,
				@dec_31,
				CASE WHEN @buonoscarico='N' THEN 0	ELSE 1		END,
				'GENER.AUTO', GETDATE(), '''GENER.AUTO''', GETDATE()
			)
		
		END
	END

	FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota
END
DEALLOCATE amt_crs

-- Caso in cui il cespite ha valorizzata la quota di ammortamento direttamente sul cespite
-- Applico direttamente quella a prescindere da quella configurata nella classificazione inventariale.
DECLARE amt_crs INSENSITIVE CURSOR FOR
SELECT  DISTINCT
	tr.idinventoryamortization,
	b.idasset,	b.idpiece,
	c.description,
	b.amortizationquota
FROM asset b
JOIN assetacquire c							ON b.nassetacquire = C.nassetacquire
JOIN assetview_current ac					ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
JOIN inventoryamortization tr				ON tr.idinventoryamortization = b.idinventoryamortization  -- <<<<
LEFT OUTER JOIN assetload					ON assetload.idassetload = c.idassetload			
LEFT OUTER JOIN assetunload AU				ON AU.idassetunload = B.idassetunload	
WHERE  (tr.flag & 2 <> 0) --ufficiale
	AND ((tr.flag&8) <> 0) -- ammortamenti
	AND ISNULL(tr.active,'S')= 'S'
	AND (b.flag & 1 <> 0)
	AND NOT EXISTS(
		SELECT * FROM assetamortization r join inventoryamortization tr1 
			ON  r.idinventoryamortization = tr1.idinventoryamortization  
		WHERE r.idasset = b.idasset AND r.idpiece = b.idpiece
			AND YEAR(r.adate) = @ayear
			AND (tr.flag&8) = (tr1.flag&8))
	AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
	AND (AU.adate is null OR YEAR(AU.adate)>@ayear )
	AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start)))
FOR READ ONLY

OPEN amt_crs
FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota
WHILE (@@FETCH_STATUS = 0)
BEGIN

	execute get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue OUTPUT, @actualvalue OUTPUT 
	--@assetvalue valore ORIGINALE alla data del 31 12 dell'anno
	--@actualvalue valore ATTUALE alla data del 31 12 dell'anno

    if @actualvalue > 0  
	BEGIN
	
		SET @reval=ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2)

		-- Viene sostituito il precedente controllo (@reval > @actualvalue) in quanto @reval nel caso di ammortamenti
		-- è negativo! Quindi la somma algebrica dei due importi deve essere sempre >=0
		IF ( (@reval + @actualvalue) < 0) 
		BEGIN
			SET @amortizationquota  = -@actualvalue/@assetvalue
		END

		SET @reval = ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2) 
		if (@reval <>0) 
		BEGIN
		

			set @descr_amm = 'valore iniziale:'+convert(varchar(30),@assetvalue)+
							' attuale:'+convert(varchar(30),@actualvalue)+
							+' aliq.applicata:'+	convert(varchar(30),@amortizationquota*100)

			SELECT @namortization = ISNULL((SELECT MAX(namortization) FROM assetamortization),0) + 1
			INSERT INTO assetamortization
				(namortization,	idinventoryamortization,
				idasset,	idpiece,
				description,
				assetvalue,		amortizationquota,
					adate,flag,
				cu, ct, lu, lt
				)
    		VALUES
			( 	@namortization,	@idinventoryamortization,
				@idasset,		@idpiece,
				@descr_amm,
				@assetvalue,
				@amortizationquota,
				@dec_31,
				CASE WHEN @buonoscarico='N' THEN 0	ELSE 1		END,
				'GENER.AUTO', GETDATE(), '''GENER.AUTO''', GETDATE()
			)
		
		END
	END

	FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota
END
DEALLOCATE amt_crs

-- Caso in cui il cespite ha la data di inizio esistenza NOT NULL 
-- Applico tutte le rivalutazioni UFFICIALI che nell'anno sono associate alla classificazione cespite con età pari alla differenza tra l'anno
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
	DECLARE amt_crs INSENSITIVE CURSOR FOR
	SELECT  DISTINCT
		tr.idinventoryamortization,	b.idasset,	b.idpiece,
		c.description,
		coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)
	FROM asset b					
	JOIN assetacquire c					ON b.nassetacquire = C.nassetacquire
	JOIN inventory						ON c.idinventory = inventory.idinventory
	JOIN inventorykind					ON inventory.idinventorykind= inventorykind.idinventorykind
	JOIN assetview_current ac			ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
	LEFT OUTER JOIN assetload			ON assetload.idassetload = c.idassetload		
	LEFT OUTER JOIN assetunload AU		ON AU.idassetunload = B.idassetunload
			
	LEFT OUTER JOIN inventorytreelink IL1			ON IL1.idchild = C.idinv AND IL1.nlevel  = 1 
	LEFT OUTER JOIN inventorytreelink IL2			ON IL2.idchild = C.idinv  AND IL2.nlevel = 2
	LEFT OUTER JOIN inventorytreelink IL3			ON IL3.idchild = C.idinv  AND IL3.nlevel = 3 
	LEFT OUTER JOIN inventorytreelink IL4			ON IL4.idchild = C.idinv  AND IL4.nlevel = 4 
	LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayear 
	LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayear
								and T4.idinv is null
	LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayear 
								and T4.idinv is null and T3.idinv is null	
	LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayear
				and T4.idinv is null and T3.idinv is null	and  T2.idinv is null
	JOIN inventoryamortization tr		ON tr.idinventoryamortization = 
					COALESCE(t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
	WHERE   b.lifestart IS NOT NULL AND b.lifestart <= @dec_31
		AND (tr.flag & 2 <> 0)		--ufficiale
		AND ((tr.flag&8) <> 0) -- ammortamenti
		AND ISNULL(tr.active,'S')= 'S'
		AND tr.age <= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.lifestart)) + 1
		AND tr.agemax >= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.lifestart)) + 1
		AND (tr.flag & 1 = 0)	--annuale
		and (b.flag & 1 <> 0)
		AND NOT EXISTS(
			SELECT * FROM assetamortization r join inventoryamortization tr1 
			ON  r.idinventoryamortization = tr1.idinventoryamortization  
					WHERE r.idasset = b.idasset AND r.idpiece = b.idpiece
					AND YEAR(r.adate) = @ayear
					AND (tr.flag&8) = (tr1.flag&8))
		AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start)))
		AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
		AND (AU.adate is null OR YEAR(AU.adate)>@ayear )		
		AND ( (inventorykind.flag&2)=0)
		AND b.amortizationquota is null
	FOR READ ONLY
	OPEN amt_crs
	FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		execute get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue OUTPUT, @actualvalue OUTPUT 
		--@assetvalue valore ORIGINALE alla data del 31 12 dell'anno
		--@actualvalue valore ATTUALE alla data del 31 12 dell'anno

		if @actualvalue > 0 
		BEGIN

			SET @reval=ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2)
			IF   ((@reval + @actualvalue) < 0) 
			BEGIN
				SET @amortizationquota  = -@actualvalue/@assetvalue
			END
			
			SET @reval = ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2) 
			if (@reval <>0) 
			BEGIN
				set @descr_amm = 'valore iniziale:'+convert(varchar(30),@assetvalue)+
							' attuale:'+convert(varchar(30),@actualvalue)+
							+' aliq.applicata:'+	convert(varchar(30),@amortizationquota*100)

				SELECT @namortization = ISNULL((SELECT MAX(namortization) FROM assetamortization),0) + 1
				INSERT INTO assetamortization
				(
					namortization,	idinventoryamortization,
					idasset,	idpiece,
					description,
					assetvalue,	amortizationquota,
					adate,flag,
					cu, ct, lu, lt
				)
				VALUES
				(
					@namortization,	@idinventoryamortization,
					@idasset,	@idpiece,
					@descr_amm,
					@assetvalue,@amortizationquota,
					@dec_31,
					CASE  when @buonoscarico='N' THEN 0		ELSE 1		END,
					'GENER.AUTO', GETDATE(), '''GENER.AUTO''', GETDATE()
				)
			END
		END
		
		FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota
	END
	DEALLOCATE amt_crs


	-- CONSIDERO I TIPI DI RIVALUTAZIONI MENSILI
	DECLARE amt_crs INSENSITIVE CURSOR FOR
	SELECT DISTINCT
		tr.idinventoryamortization,	b.idasset,	b.idpiece,
		c.description,
		ISNULL(t4.amortizationquota,ISNULL(t3.amortizationquota,
	    	ISNULL(t2.amortizationquota,t1.amortizationquota))) /12 *
		CASE 
			WHEN DATEPART(YEAR,b.lifestart) = @ayear THEN DATEPART(MONTH,@dec_31) - DATEPART(MONTH,b.lifestart) + 1
			WHEN DATEPART(YEAR,b.lifestart) < @ayear THEN 12
		END
	FROM asset b
	JOIN assetacquire c							ON b.nassetacquire = c.nassetacquire
	JOIN inventory								ON c.idinventory = inventory.idinventory
	JOIN inventorykind							ON inventory.idinventorykind= inventorykind.idinventorykind
	JOIN assetview_current ac					ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
	LEFT OUTER JOIN assetload					ON assetload.idassetload = c.idassetload			
	LEFT OUTER JOIN assetunload AU				ON AU.idassetunload = B.idassetunload		
	LEFT OUTER JOIN inventorytreelink IL1		ON IL1.idchild = C.idinv AND IL1.nlevel  = 1 
	LEFT OUTER JOIN inventorytreelink IL2		ON IL2.idchild = C.idinv  AND IL2.nlevel = 2
	LEFT OUTER JOIN inventorytreelink IL3		ON IL3.idchild = C.idinv  AND IL3.nlevel = 3 
	LEFT OUTER JOIN inventorytreelink IL4		ON IL4.idchild = C.idinv  AND IL4.nlevel = 4 
	LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayear 
	LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayear
								and T4.idinv is null
	LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayear 
								and T4.idinv is null and T3.idinv is null	
	LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayear
				and T4.idinv is null and T3.idinv is null	and  T2.idinv is null
	JOIN inventoryamortization tr				ON tr.idinventoryamortization = 
					COALESCE(t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
	WHERE 
		b.lifestart IS NOT NULL AND b.lifestart <= @dec_31
		AND (tr.flag & 2 <> 0) --ufficiale
		AND ((tr.flag&8) <> 0) -- ammortamenti
		AND ISNULL(tr.active,'S')= 'S'
		AND tr.age <= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.lifestart)) + 1
		AND tr.agemax >= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.lifestart)) + 1
		AND (tr.flag & 1 <> 0)
		AND (b.flag & 1 <> 0)
		AND NOT EXISTS(
			SELECT * FROM assetamortization r join inventoryamortization tr1 
					ON  r.idinventoryamortization = tr1.idinventoryamortization  
					WHERE r.idasset = b.idasset AND r.idpiece = b.idpiece
					AND YEAR(r.adate) = @ayear
					AND (tr.flag&8) = (tr1.flag&8))
		AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start) ))
		AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
		AND (AU.adate is null OR YEAR(AU.adate)>@ayear )
		AND ( (inventorykind.flag&2)=0)
		AND b.amortizationquota is null
	FOR READ ONLY
	OPEN amt_crs
		FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		execute get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue OUTPUT, @actualvalue OUTPUT 
		--@assetvalue valore ORIGINALE alla data del 31 12 dell'anno
		--@actualvalue valore ATTUALE alla data del 31 12 dell'anno
		
		if @actualvalue > 0 
		BEGIN

			SET @reval=ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2)

			IF ((@reval + @actualvalue) < 0) 
			BEGIN
				SET @amortizationquota  = -@actualvalue/@assetvalue
			END
			
			SET @reval = ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2) 
			if (@reval <>0) 
			BEGIN
				set @descr_amm = 'valore iniziale:'+convert(varchar(30),@assetvalue)+
							' attuale:'+convert(varchar(30),@actualvalue)+
							+' aliq.applicata:'+	convert(varchar(30),@amortizationquota*100)

				SELECT @namortization = ISNULL((SELECT MAX(namortization) FROM assetamortization),0) + 1
				INSERT INTO assetamortization
					(namortization,	idinventoryamortization,
					idasset,idpiece,
					description,
					assetvalue,	amortizationquota,
					adate,flag,
					cu, ct, lu, lt
					)
				VALUES
					(@namortization,@idinventoryamortization,
						@idasset,@idpiece,
						@descr_amm,
						@assetvalue,@amortizationquota,
						@dec_31,
						CASE  when @buonoscarico='N' THEN 0		ELSE 1		END,
						'GENER.AUTO', GETDATE(), '''GENER.AUTO''', GETDATE()
					)
				
			END
		END
		FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota
	END
	DEALLOCATE amt_crs
END

-- Nel caso non ci siano rivalutazioni con il campo ETA valorizzato allora effettuo la rivalutazione dei cespiti
-- con tipi rivalutazione con il campo ETA non valorizzato
IF 
(SELECT COUNT(*)
FROM inventoryamortization I
JOIN inventorysortingamortizationyear A
	ON I.idinventoryamortization = A.idinventoryamortization
WHERE (I.flag & 2 <> 0) AND I.age IS NOT NULL AND A.ayear = @ayear AND ISNULL(I.active,'S')= 'S') = 0
BEGIN
	DECLARE amt_crs INSENSITIVE CURSOR FOR
	SELECT DISTINCT
		tr.idinventoryamortization,	b.idasset,	b.idpiece,
		c.description,
		coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)
	FROM asset b
	JOIN assetacquire c							ON b.nassetacquire = c.nassetacquire
	JOIN inventory								ON c.idinventory = inventory.idinventory
	JOIN inventorykind							ON inventory.idinventorykind= inventorykind.idinventorykind
	JOIN assetview_current ac					ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
	LEFT OUTER JOIN assetload					ON assetload.idassetload = c.idassetload			
	LEFT OUTER JOIN assetunload AU				ON AU.idassetunload = B.idassetunload		
	LEFT OUTER JOIN inventorytreelink IL1		ON IL1.idchild = C.idinv AND IL1.nlevel  = 1 
	LEFT OUTER JOIN inventorytreelink IL2		ON IL2.idchild = C.idinv  AND IL2.nlevel = 2
	LEFT OUTER JOIN inventorytreelink IL3		ON IL3.idchild = C.idinv  AND IL3.nlevel = 3 
	LEFT OUTER JOIN inventorytreelink IL4		ON IL4.idchild = C.idinv  AND IL4.nlevel = 4 
	LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayear 
	LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayear
								and T4.idinv is null
	LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayear 
								and T4.idinv is null and T3.idinv is null	
	LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayear
				and T4.idinv is null and T3.idinv is null	and  T2.idinv is null	JOIN inventoryamortization tr		ON tr.idinventoryamortization = 
				COALESCE(t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
	WHERE   b.lifestart IS NOT NULL AND b.lifestart <= @dec_31
		AND (tr.flag & 2 <> 0)	--ufficiale
		AND ((tr.flag&8) <> 0) -- ammortamenti
		AND (tr.flag & 1 = 0)		--annuale
		AND ISNULL(tr.active,'S')= 'S'
		AND (b.flag & 1 <> 0)
		AND NOT EXISTS(
			SELECT * FROM assetamortization r join inventoryamortization tr1 
					ON  r.idinventoryamortization = tr1.idinventoryamortization  
					WHERE r.idasset = b.idasset AND r.idpiece = b.idpiece
					AND YEAR(r.adate) = @ayear
					AND (tr.flag&8) = (tr1.flag&8))
		AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start) ))
		AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
		AND (AU.adate is null OR YEAR(AU.adate)>@ayear )
		AND ( (inventorykind.flag&2)=0)
		AND b.amortizationquota is null
	FOR READ ONLY
	OPEN amt_crs
	FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		execute get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue OUTPUT, @actualvalue OUTPUT 
		--@assetvalue valore ORIGINALE alla data del 31 12 dell'anno
		--@actualvalue valore ATTUALE alla data del 31 12 dell'anno
		
		if @actualvalue > 0 
		BEGIN

			SET @reval=ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2)
			IF  ((@reval + @actualvalue) < 0) 
			BEGIN
				SET @amortizationquota = -@actualvalue/@assetvalue
			END
			
			SET @reval = ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2) 
			if (@reval <>0) 
			BEGIN
				set @descr_amm = 'valore iniziale:'+convert(varchar(30),@assetvalue)+
							' attuale:'+convert(varchar(30),@actualvalue)+
							+' aliq.applicata:'+	convert(varchar(30),@amortizationquota*100)

				SELECT @namortization = ISNULL((SELECT MAX(namortization) FROM assetamortization),0) + 1
				INSERT INTO assetamortization
				(namortization,	idinventoryamortization,
					idasset,idpiece,
					description,
					assetvalue,	amortizationquota,
					adate,flag,
					cu, ct, lu, lt
				)
				VALUES
				(@namortization,@idinventoryamortization,
					@idasset,@idpiece,
					@descr_amm,
					@assetvalue,@amortizationquota,
					@dec_31,
					CASE  when @buonoscarico='N' THEN 0 ELSE 1	END,
					'GENER.AUTO', GETDATE(), '''GENER.AUTO''', GETDATE()
				)
			END
		END
		FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota
	END
	DEALLOCATE amt_crs


	DECLARE amt_crs INSENSITIVE CURSOR FOR
	SELECT DISTINCT
		tr.idinventoryamortization,	b.idasset,b.idpiece,
		c.description,
			coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)/12 *
			CASE 
				WHEN DATEPART(YEAR,b.lifestart) = @ayear THEN DATEPART(MONTH,@dec_31) - DATEPART(MONTH,b.lifestart) + 1
				WHEN DATEPART(YEAR,b.lifestart) < @ayear THEN 12
			END
	FROM asset b
	JOIN assetacquire c						ON b.nassetacquire = c.nassetacquire
	JOIN inventory							ON c.idinventory = inventory.idinventory
	JOIN inventorykind						ON inventory.idinventorykind= inventorykind.idinventorykind
	LEFT OUTER JOIN assetload				ON assetload.idassetload = c.idassetload		
	LEFT OUTER JOIN assetunload AU			ON AU.idassetunload = B.idassetunload		
	JOIN assetview_current ac				ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
	LEFT OUTER JOIN inventorytreelink IL1	ON IL1.idchild = C.idinv AND IL1.nlevel  = 1 
	LEFT OUTER JOIN inventorytreelink IL2	ON IL2.idchild = C.idinv  AND IL2.nlevel = 2
	LEFT OUTER JOIN inventorytreelink IL3	ON IL3.idchild = C.idinv  AND IL3.nlevel = 3 
	LEFT OUTER JOIN inventorytreelink IL4	ON IL4.idchild = C.idinv  AND IL4.nlevel = 4 
	LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayear 
	LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayear
								and T4.idinv is null
	LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayear 
								and T4.idinv is null and T3.idinv is null	
	LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayear
				and T4.idinv is null and T3.idinv is null	and  T2.idinv is null	
	
	JOIN inventoryamortization tr		ON tr.idinventoryamortization = 
			COALESCE(t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
	WHERE  b.lifestart IS NOT NULL AND b.lifestart <= @dec_31
		AND (tr.flag & 2 <> 0)	--ufficiale
		AND ((tr.flag&8) <> 0)  -- ammortamenti
		AND (tr.flag & 1 <> 0)	--mensile
		AND ISNULL(tr.active,'S')= 'S'
		AND (b.flag & 1 <> 0)
		AND NOT EXISTS(
			SELECT * FROM assetamortization r join inventoryamortization tr1 
					ON  r.idinventoryamortization = tr1.idinventoryamortization  
					WHERE r.idasset = b.idasset AND r.idpiece = b.idpiece
					AND YEAR(r.adate) = @ayear
					AND (tr.flag&8) = (tr1.flag&8))
		AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start) ))
		AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
		AND (AU.adate is null OR YEAR(AU.adate)>@ayear )
		AND ( (inventorykind.flag&2)=0)
		AND b.amortizationquota is null
	FOR READ ONLY
	OPEN amt_crs
		FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		execute get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue OUTPUT, @actualvalue OUTPUT 
		--@assetvalue valore ORIGINALE alla data del 31 12 dell'anno
		--@actualvalue valore ATTUALE alla data del 31 12 dell'anno
	    
	    if @actualvalue > 0 
	    BEGIN
			SET @reval=ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2)
		
			IF  ((@reval + @actualvalue) < 0) 
			BEGIN
				SET @amortizationquota  = -@actualvalue/@assetvalue
			END
			
			SET @reval = ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2) 
			if (@reval <>0) 
			BEGIN
				set @descr_amm = 'valore iniziale:'+convert(varchar(30),@assetvalue)+
							' attuale:'+convert(varchar(30),@actualvalue)+
							+' aliq.applicata:'+	convert(varchar(30),@amortizationquota*100)

				SELECT @namortization = ISNULL((SELECT MAX(namortization) FROM assetamortization),0) + 1
				INSERT INTO assetamortization
					(namortization,idinventoryamortization,
						idasset,idpiece,
						description,
						assetvalue,	amortizationquota,
						adate,flag,
						cu, ct, lu, lt
					)
				VALUES
					(@namortization,@idinventoryamortization,
					@idasset,@idpiece,
					@descr_amm,
					@assetvalue,@amortizationquota,
					@dec_31,
					CASE  when @buonoscarico='N' THEN 0		ELSE 1		END,
					'GENER.AUTO', GETDATE(), '''GENER.AUTO''', GETDATE()
					)
			END
		END
		FETCH NEXT FROM amt_crs INTO @idinventoryamortization, @idasset, @idpiece, @description, @amortizationquota
	END
	DEALLOCATE amt_crs
END
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
