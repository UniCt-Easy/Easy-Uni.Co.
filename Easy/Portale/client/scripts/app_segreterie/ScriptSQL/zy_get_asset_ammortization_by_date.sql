
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
IF EXISTS(select * from sysobjects where id = object_id(N'[get_asset_ammortization_by_date]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [get_asset_ammortization_by_date]
GO
-- exec get_asset_ammortization_by_date '20170101', '20210101',47960,1
 
CREATE PROCEDURE [get_asset_ammortization_by_date]
(
	@start datetime,
	@end datetime,
	@idasset int  = 47418, 
	@idpiece int = 1
)
AS BEGIN
-- setuser 'amm'
---- closeyear_asset_ammortization 2014,'N'
--la stored procedure GetAssetValue è usata per valutare l'importo corrente dei cespiti
--la stored procedure get_originalassetvalue è usata per valutare l'importo iniziale dei cespiti, su cui calcolare l'ammortamento
-- se l'ammortamento calcolato è tale da rendere il valore corrente viene considerata una base per l'ammortamento opportunamente ridotta
--   in modo da far si che l'aliquota di ammortamento per la base di ammortamento vada ad azzerare il valore residuo del cespite
DECLARE @ayearstart int = YEAR(@start)
DECLARE @ayearend int = YEAR(@end)
DECLARE @monthstart int = MONTH(@start)
DECLARE @monthend int = MONTH(@end)
DECLARE @amortizationquota_toprint float
DECLARE @dec_31 datetime
SELECT  @dec_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayearstart), 105)
DECLARE @namortization int
SELECT  @namortization = ISNULL((SELECT MAX(namortization) FROM assetamortization),0) + 1
DECLARE @idinventoryamortization int
DECLARE @description varchar(150)
DECLARE @assetvalue decimal(19,2)
DECLARE @amortizationquota float = NULL
DECLARE @actualvalue decimal(19,2)
DECLARE @reval decimal(19,2)
declare @startvalue decimal(19,2)
declare @descr_amm varchar(150)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Caso in cui il cespite ha data di inizio esistenza a NULL
-- Ammortamento Annuo. Non calcolo l'ammortamento per mesi
-- Applico tutte le rivalutazioni UFFICIALI che nell'anno sono associate alla classificazione del cespite e che hanno ETA NULL

SET 	@amortizationquota = 
	( SELECT TOP 1  coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)

	FROM asset b
	JOIN assetacquire c							ON b.nassetacquire = C.nassetacquire
	JOIN assetview_current ac					ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
	LEFT OUTER JOIN assetload					ON assetload.idassetload = c.idassetload			
	LEFT OUTER JOIN assetunload AU				ON AU.idassetunload = B.idassetunload	
	LEFT OUTER JOIN inventorytreelink IL1		ON IL1.idchild = C.idinv AND IL1.nlevel  = 1 
	LEFT OUTER JOIN inventorytreelink IL2		ON IL2.idchild = C.idinv  AND IL2.nlevel = 2
	LEFT OUTER JOIN inventorytreelink IL3		ON IL3.idchild = C.idinv  AND IL3.nlevel = 3 
	LEFT OUTER JOIN inventorytreelink IL4		ON IL4.idchild = C.idinv  AND IL4.nlevel = 4 
	LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayearstart 
		LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayearstart
									and T4.idinv is null
		LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayearstart 
									and T4.idinv is null and T3.idinv is null	
		LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayearstart
					and T4.idinv is null and T3.idinv is null	and  T2.idinv is null
	JOIN inventoryamortization tr			ON tr.idinventoryamortization = 
				COALESCE( t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
	WHERE   b.lifestart IS NULL
		AND (tr.flag & 2 <> 0) --ufficiale
		AND ((tr.flag&8) <> 0) -- ammortamenti
		AND tr.age IS NULL
		AND ISNULL(tr.active,'S')= 'S'
		AND (b.flag & 1 <> 0)
		AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start)))
		--AND (YEAR(assetload.ratificationdate)<=@ayearstart OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
		AND (AU.adate is null OR YEAR(AU.adate)>@ayearstart )
		AND b.amortizationquota is null
		AND b.idasset = @idasset AND b.idpiece = @idpiece
	)

IF @amortizationquota IS NOT NULL
BEGIN
	set @amortizationquota_toprint = @amortizationquota 
	set @amortizationquota = @amortizationquota *(YEAR(@end)-YEAR(@start)+1)
	print 'primo caso aliquota annua : @amortizationquota_toprint = ' + cast(@amortizationquota_toprint as nvarchar(255))
	print 'primo caso aliquota applicata: @amortizationquota = ' + cast(@amortizationquota as nvarchar(255))

	execute get_assetvalueatdate @idasset,@idpiece, @start, @assetvalue OUTPUT, @actualvalue OUTPUT 
	--@assetvalue valore ORIGINALE 
	--@actualvalue valore ATTUALE alla data del 31 12 dell'anno

	if @actualvalue > 0  
	BEGIN
			SET @reval=ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2)
			-- Viene sostituito il precedente controllo (@reval > @actualvalue) in quanto @reval nel caso di ammortamenti
			-- è negativo! Quindi la somma algebrica dei due importi deve essere sempre >=0
			IF ( (@reval + @actualvalue) < 0) -- Valore dopo l'ammortamento

			BEGIN
				SET @amortizationquota  = -@actualvalue/@assetvalue
			END
			SET @reval = ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2) 
			if (@reval <>0) 
			BEGIN
		
				set @descr_amm = 'Valore:'+convert(varchar(30),@assetvalue)+
								'; Valore all''inizio del periodo:'+convert(varchar(30),@actualvalue)
								+'; Aliquota annuale applicata:'+	convert(varchar(30),@amortizationquota_toprint*100) +'%'
								+'; Aliquota applicata:'+	convert(varchar(30),@amortizationquota*100) +'%'
	
				SELECT 
					@descr_amm as descrizione,
					@assetvalue as valoreiniziale,
					@assetvalue*@amortizationquota as valoreammortizzato,
					@amortizationquota as quotaammortamento
			END
		END
	GOTO Fine
END

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Caso in cui il cespite ha valorizzata la quota di ammortamento direttamente sul cespite
-- Ammortamento Annuo. Non calcolo l'ammortamento per mesi
-- Applico direttamente quella a prescindere da quella configurata nella classificazione inventariale.

SET 	@amortizationquota = 
( SELECT  TOP 1 b.amortizationquota
	FROM asset b
	JOIN assetacquire c							ON b.nassetacquire = C.nassetacquire
	JOIN assetview_current ac					ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
	JOIN inventoryamortization tr				ON tr.idinventoryamortization = b.idinventoryamortization  -- <<<<
	LEFT OUTER JOIN assetload					ON assetload.idassetload = c.idassetload			
	LEFT OUTER JOIN assetunload AU				ON AU.idassetunload = B.idassetunload	
	WHERE  (tr.flag & 2 <> 0) --ufficiale
		AND b.idasset = @idasset AND b.idpiece = @idpiece
		AND ((tr.flag&8) <> 0) -- ammortamenti
		AND ISNULL(tr.active,'S')= 'S'
		AND (b.flag & 1 <> 0)
		AND (YEAR(assetload.ratificationdate)<=@ayearstart OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
		AND (AU.adate is null OR YEAR(AU.adate)>@ayearstart )
		AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start)))
)

IF @amortizationquota IS NOT NULL 
BEGIN
	set @amortizationquota_toprint = @amortizationquota 
	set @amortizationquota = @amortizationquota *(YEAR(@end)-YEAR(@start)+1)
	print 'secondo caso aliquota annua : @amortizationquota_toprint = ' + cast(@amortizationquota_toprint as nvarchar(255))
	print 'secondo caso aliquota applicata: @amortizationquota = ' + cast(@amortizationquota as nvarchar(255))

	execute get_assetvalueatdate @idasset,@idpiece, @start, @assetvalue OUTPUT, @actualvalue OUTPUT 
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
		

				set @descr_amm = 'Valore:'+convert(varchar(30),@assetvalue)+
								'; Valore all''inizio del periodo:'+convert(varchar(30),@actualvalue)
								+'; Aliquota annuale applicata:'+	convert(varchar(30),@amortizationquota_toprint*100) +'%'
								+'; Aliquota applicata:'+	convert(varchar(30),@amortizationquota*100) +'%'
			SELECT 
				@descr_amm as descrizione,
				@assetvalue as valoreiniziale,
				@assetvalue*@amortizationquota as valoreammortizzato,
				@amortizationquota as quotaammortamento
		
		END
	END
	GOTO Fine
END


-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
	JOIN assetacquire C ON C.idinv = A.idinv
	JOIN asset B ON b.nassetacquire = c.nassetacquire
	WHERE (I.flag & 2 <> 0) AND I.age IS NOT NULL AND A.ayear = @ayearstart AND ISNULL(I.active,'S')= 'S'
	AND b.idasset = @idasset AND b.idpiece = @idpiece
) > 0
BEGIN
	print 'terzo caso'

	-- Considero i tipi di rivalutazioni 'ANNUALI' 
	SET @amortizationquota = 
			( SELECT TOP 1	coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota) 
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
			LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayearstart 
			LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayearstart
										and T4.idinv is null
			LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayearstart 
										and T4.idinv is null and T3.idinv is null	
			LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayearstart
						and T4.idinv is null and T3.idinv is null	and  T2.idinv is null
			JOIN inventoryamortization tr		ON tr.idinventoryamortization = 
							COALESCE(t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
			WHERE   b.lifestart IS NOT NULL 
				AND b.lifestart <= @end -- Il cespite dev'essere acquistato prima della fine del progetto
				AND (tr.flag & 2 <> 0)		--ufficiale
				AND ((tr.flag&8) <> 0) -- ammortamenti
				AND ISNULL(tr.active,'S')= 'S'
				AND tr.age <= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.lifestart)) + 1
				AND tr.agemax >= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.lifestart)) + 1
				AND (tr.flag & 1 = 0)	--annuale
				and (b.flag & 1 <> 0)
				AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start)))
				--AND (YEAR(assetload.ratificationdate)<=@ayearstart OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
				AND (AU.adate is null OR YEAR(AU.adate)>@ayearstart )		
				AND ( (inventorykind.flag&2)=0)
				AND b.amortizationquota is null
				AND b.idasset = @idasset AND b.idpiece = @idpiece
				)

	IF @amortizationquota IS NOT NULL 
	BEGIN
		set @amortizationquota_toprint = @amortizationquota 
		set @amortizationquota = @amortizationquota *(YEAR(@end)-YEAR(@start)+1)
		print 'terzo caso aliquota annua : @amortizationquota_toprint = ' + cast(@amortizationquota_toprint as nvarchar(255))
		print 'terzo caso aliquota applicata: @amortizationquota = ' + cast(@amortizationquota as nvarchar(255))
		execute get_assetvalueatdate @idasset,@idpiece, @start, @assetvalue OUTPUT, @actualvalue OUTPUT 
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
				set @descr_amm = 'Valore:'+convert(varchar(30),@assetvalue)+
								'; Valore all''inizio del periodo:'+convert(varchar(30),@actualvalue)
								+'; Aliquota annuale applicata:'+	convert(varchar(30),@amortizationquota_toprint*100) +'%'
								+'; Aliquota applicata:'+	convert(varchar(30),@amortizationquota*100) +'%'

				SELECT 
					@descr_amm as descrizione,
					@assetvalue as valoreiniziale,
					@assetvalue*@amortizationquota as valoreammortizzato,
					@amortizationquota as quotaammortamento
			END
		END
		GOTO Fine
	END

END


-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- CONSIDERO I TIPI DI RIVALUTAZIONI MENSILI
SET @amortizationquota = 
	(
		SELECT TOP 1 
					ISNULL(t4.amortizationquota,ISNULL(t3.amortizationquota,ISNULL(t2.amortizationquota,t1.amortizationquota))) /12 
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
		LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayearstart 
		LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayearstart
									and T4.idinv is null
		LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayearstart 
									and T4.idinv is null and T3.idinv is null	
		LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayearstart
					and T4.idinv is null and T3.idinv is null	and  T2.idinv is null
		JOIN inventoryamortization tr				ON tr.idinventoryamortization = 
						COALESCE(t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
		WHERE 
			b.lifestart IS NOT NULL 
			AND b.lifestart <= @end -- Il cespite dev'essere acquistato prima della fine del progetto
			AND (tr.flag & 2 <> 0) --ufficiale
			AND ((tr.flag&8) <> 0) -- ammortamenti
			AND ISNULL(tr.active,'S')= 'S'
			AND tr.age <= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.lifestart)) + 1
			AND tr.agemax >= (DATEPART(YEAR,@dec_31) - DATEPART(YEAR,b.lifestart)) + 1
			AND (tr.flag & 1 <> 0)
			AND (b.flag & 1 <> 0)
			AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start) ))
			--AND (YEAR(assetload.ratificationdate)<=@ayearstart OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
			AND (AU.adate is null OR YEAR(AU.adate)>@ayearstart )
			AND ( (inventorykind.flag&2)=0)
			AND b.amortizationquota is null
			AND b.idasset = @idasset AND b.idpiece = @idpiece
		)

IF @amortizationquota IS NOT NULL 
BEGIN
	set @amortizationquota_toprint = @amortizationquota 
	set @amortizationquota = (select top 1 @amortizationquota *
			CASE 
				WHEN b.lifestart <= @start THEN  Datediff(month, @start, @end)
				WHEN b.lifestart >  @start THEN  Datediff(month, b.lifestart, @end)
			END
			FROM asset b where b.idasset = @idasset AND b.idpiece = @idpiece)
	print 'quarto caso aliquota mensile : @amortizationquota_toprint = ' + cast(@amortizationquota_toprint as nvarchar(255))
	print 'quarto caso aliquota applicata: @amortizationquota = ' + cast(@amortizationquota as nvarchar(255))

	execute get_assetvalueatdate @idasset,@idpiece, @start, @assetvalue OUTPUT, @actualvalue OUTPUT 
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
			set @descr_amm = 'Valore:'+convert(varchar(30),@assetvalue)+
							'; Valore all''inizio del periodo:'+convert(varchar(30),@actualvalue)
								+'; Aliquota mensile applicata:'+	convert(varchar(30),@amortizationquota_toprint*100) +'%'
								+'; Aliquota applicata:'+	convert(varchar(30),@amortizationquota*100) +'%'
			SELECT 
				@descr_amm as descrizione,
				@assetvalue as valoreiniziale,
				@assetvalue*@amortizationquota as valoreammortizzato,
				@amortizationquota as quotaammortamento
					
		END
	END
	GOTO Fine
END


----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Nel caso non ci siano rivalutazioni con il campo ETA valorizzato allora effettuo la rivalutazione dei cespiti
-- con tipi rivalutazione con il campo ETA non valorizzato
IF 
	(SELECT COUNT(*)
	FROM inventoryamortization I
	JOIN inventorysortingamortizationyear A	ON I.idinventoryamortization = A.idinventoryamortization
	JOIN assetacquire C ON C.idinv = A.idinv
	JOIN asset B ON b.nassetacquire = c.nassetacquire
	WHERE (I.flag & 2 <> 0) AND I.age IS NOT NULL AND A.ayear = @ayearstart AND ISNULL(I.active,'S')= 'S'
	AND B.idasset = @idasset AND B.idpiece = @idpiece
	) = 0
BEGIN
	print 'quinto caso'

	SET @amortizationquota = 
	(SELECT TOP 1 coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)
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
	LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayearstart 
	LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayearstart and T4.idinv is null
	LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayearstart 	and T4.idinv is null and T3.idinv is null	
	LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayearstart and T4.idinv is null and T3.idinv is null	and  T2.idinv is null	
	JOIN inventoryamortization tr ON tr.idinventoryamortization = COALESCE(t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
	WHERE   b.lifestart IS NOT NULL 
		AND b.lifestart <= @end -- Il cespite dev'essere acquistato prima della fine del progetto
		AND (tr.flag & 2 <> 0)	--ufficiale
		AND ((tr.flag&8) <> 0) -- ammortamenti
		AND (tr.flag & 1 = 0)		--annuale
		AND ISNULL(tr.active,'S')= 'S'
		AND (b.flag & 1 <> 0)
		AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start) ))
		--AND (YEAR(assetload.ratificationdate)<=@ayearstart OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
		AND (AU.adate is null OR YEAR(AU.adate)>@ayearstart )
		AND ( (inventorykind.flag&2)=0)
		AND b.amortizationquota is null
		AND b.idasset = @idasset AND b.idpiece = @idpiece
	)

	if @amortizationquota > 0 
	BEGIN
		set @amortizationquota_toprint = @amortizationquota 
		set @amortizationquota = @amortizationquota *(YEAR(@end)-YEAR(@start)+1)
		print 'quinto caso aliquota annua : @amortizationquota_toprint = ' + cast(@amortizationquota_toprint as nvarchar(255))
		print 'quinto caso aliquota applicata: @amortizationquota = ' + cast(@amortizationquota as nvarchar(255))

		execute get_assetvalueatdate @idasset,@idpiece, @start, @assetvalue OUTPUT, @actualvalue OUTPUT 
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
				set @descr_amm = 'Valore:'+convert(varchar(30),@assetvalue)+
								'; Valore all''inizio del periodo:'+convert(varchar(30),@actualvalue)
								+'; Aliquota annuale applicata:'+	convert(varchar(30),@amortizationquota_toprint*100) +'%'
								+'; Aliquota applicata:'+	convert(varchar(30),@amortizationquota*100) +'%'

				SELECT 
					@descr_amm as descrizione,
					@assetvalue as valoreiniziale,
					@assetvalue*@amortizationquota as valoreammortizzato,
					@amortizationquota as quotaammortamento
			END
		END
	END
END

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- CONSIDERO I TIPI DI RIVALUTAZIONI MENSILI
SET @amortizationquota = 
	(SELECT TOP 1 
		coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)/12 
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
	LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayearstart 
	LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayearstart
								and T4.idinv is null
	LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent  AND t2.ayear = @ayearstart 
								and T4.idinv is null and T3.idinv is null	
	LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayearstart
				and T4.idinv is null and T3.idinv is null	and  T2.idinv is null	

	JOIN inventoryamortization tr		ON tr.idinventoryamortization = 
			COALESCE(t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
	WHERE  b.lifestart IS NOT NULL 
		AND b.lifestart <= @end -- Il cespite dev'essere acquistato prima della fine del progetto
		AND (tr.flag & 2 <> 0)	--ufficiale
		AND ((tr.flag&8) <> 0)  -- ammortamenti
		AND (tr.flag & 1 <> 0)	--mensile
		AND ISNULL(tr.active,'S')= 'S'
		AND (b.flag & 1 <> 0)
		AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start) ))
		--AND (YEAR(assetload.ratificationdate)<=@ayearstart OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
		AND (AU.adate is null OR YEAR(AU.adate)>@ayearstart )
		AND ( (inventorykind.flag&2)=0)
		AND b.amortizationquota is null
		AND b.idasset = @idasset AND b.idpiece = @idpiece
	)
		
IF(@amortizationquota IS NOT NULL)
BEGIN
	set @amortizationquota_toprint = @amortizationquota 
	set @amortizationquota = (select top 1 @amortizationquota *
			CASE 
				WHEN b.lifestart <= @start THEN  Datediff(month, @start, @end)
				WHEN b.lifestart >  @start THEN  Datediff(month, b.lifestart, @end)
			END
			FROM asset b where b.idasset = @idasset AND b.idpiece = @idpiece)
	print 'sesto caso aliquota mensile : @amortizationquota_toprint = ' + cast(@amortizationquota_toprint as nvarchar(255))
	print 'sesto caso aliquota applicata: @amortizationquota = ' + cast(@amortizationquota as nvarchar(255))


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
			set @descr_amm = 'Valore:'+convert(varchar(30),@assetvalue)+
							'; Valore all''inizio del periodo:'+convert(varchar(30),@actualvalue)
								+'; Aliquota mensile applicata:'+	convert(varchar(30),@amortizationquota_toprint*100) +'%'
								+'; Aliquota applicata:'+	convert(varchar(30),@amortizationquota*100) +'%'
			SELECT 
				@descr_amm as descrizione,
				@assetvalue as valoreiniziale,
				@assetvalue*@amortizationquota as valoreammortizzato,
				@amortizationquota as quotaammortamento
		END
	END
END

Fine:
END





