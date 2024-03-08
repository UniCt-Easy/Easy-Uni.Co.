
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


--closeyear_asset_ammortization 2011
if exists (select * from dbo.sysobjects where id = object_id(N'[f_calcola_ammortamento]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function f_calcola_ammortamento
GO
 
 
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 
 
CREATE  FUNCTION [f_calcola_ammortamento]
(
 	@idasset      int,
	@idpiece      int,
	@ayear	      int,  --- anno in cui si desidera calcolare l'ammortamento del cespite partendo da un valore iniziale
	@ayear_rif    int,  --- anno di riferimento per la configurazione del piano di ammortamento
	@assetvalue  decimal(19,2), -- valore originale al 31 12 dell'anno in cui si desidera calcolare l'ammortamento del cespite
	@actualvalue decimal(19,2)  -- valore attuale al 31 12 anno in cui si desidera calcolare l'ammortamento del cespite
)
RETURNS decimal(19,2) AS
 BEGIN
-- setuser 'ammINISTRAZIONE'
-- se l'ammortamento calcolato è tale da rendere il valore corrente viene considerata una base per l'ammortamento opportunamente ridotta
-- in modo da far si che l'aliquota di ammortamento per la base di ammortamento vada ad azzerare il valore residuo del cespite
IF (ISNULL(@actualvalue,0) = 0) RETURN 0

DECLARE @trovato CHAR(1)  
DECLARE @asset_amortization decimal(19,2)

DECLARE @dec_31 datetime
SELECT  @dec_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)

DECLARE @idinventoryamortization int
 
DECLARE @amortizationquota float
DECLARE @reval decimal(19,2)
 
 
SET @trovato = 'N'
IF 
 EXISTS(
  SELECT * FROM assetamortization r join inventoryamortization tr1 
   ON  r.idinventoryamortization = tr1.idinventoryamortization  
  WHERE  YEAR(r.adate) = @ayear
   AND (tr1.flag&8)<>0
   AND r.idasset = @idasset AND r.idpiece = @idpiece
  )
  BEGIN
			SELECT  @reval =SUM( ROUND(ISNULL(r.assetvalue, 0.0) * ISNULL(r.amortizationquota,0.0) ,2) ) 
		 
			FROM   assetamortization r join inventoryamortization tr1 
			ON  r.idinventoryamortization = tr1.idinventoryamortization  
		WHERE  YEAR(r.adate) = @ayear
		AND  (tr1.flag&8)<>0
		AND r.idasset = @idasset AND r.idpiece = @idpiece

	   RETURN @reval 
  END 

-- Caso in cui il cespite ha data di inizio esistenza a NULL
-- Applico tutte le rivalutazioni UFFICIALI che nell'anno sono associate alla classificazione del cespite e che hanno ETA NULL
 
 IF (@trovato = 'N')
		BEGIN
		SELECT @trovato = 'S',
			@idinventoryamortization = tr.idinventoryamortization, 
			@amortizationquota = coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)
		FROM asset b
		JOIN assetacquire c							ON b.nassetacquire = C.nassetacquire
		JOIN assetview_current ac					ON ac.idasset = b.idasset and ac.idpiece=b.idpiece
		LEFT OUTER JOIN assetload					ON assetload.idassetload = c.idassetload			
		LEFT OUTER JOIN assetunload AU				ON AU.idassetunload = B.idassetunload	
		LEFT OUTER JOIN inventorytreelink IL1		ON IL1.idchild = C.idinv AND IL1.nlevel  = 1 
		LEFT OUTER JOIN inventorytreelink IL2		ON IL2.idchild = C.idinv  AND IL2.nlevel = 2
		LEFT OUTER JOIN inventorytreelink IL3		ON IL3.idchild = C.idinv  AND IL3.nlevel = 3 
		LEFT OUTER JOIN inventorytreelink IL4		ON IL4.idchild = C.idinv  AND IL4.nlevel = 4 
		LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayear_rif
		LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent AND t2.ayear = @ayear_rif
		LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayear_rif
		LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayear_rif 
		JOIN inventoryamortization tr			ON tr.idinventoryamortization = 
					COALESCE( t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
		WHERE   b.lifestart IS NULL
			AND (tr.flag & 2 <> 0) --ufficiale
			AND ((tr.flag&8) <> 0) -- ammortamenti
			AND tr.age IS NULL
			AND ISNULL(tr.active,'S')= 'S'
			AND (b.flag & 1 <> 0)
			AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start)))
			AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
			AND (AU.adate is null OR YEAR(AU.adate)>@ayear )
			AND b.amortizationquota is null
			AND b.idasset = @idasset AND b.idpiece = @idpiece

	END
 
-- Caso in cui il cespite ha valorizzata la quota di ammortamento direttamente sul cespite
-- Applico direttamente quella a prescindere da quella configurata nella classificazione inventariale.
 
 IF (@trovato = 'N')
		BEGIN
		SELECT  @trovato = 'S',
			@idinventoryamortization = tr.idinventoryamortization,
			@amortizationquota = b.amortizationquota
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
			AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
			AND (AU.adate is null OR YEAR(AU.adate)>@ayear )
			AND b.idasset = @idasset AND b.idpiece = @idpiece

		END
  

-- Caso in cui il cespite ha la data di inizio esistenza NOT NULL 
-- Applico tutte le rivalutazioni UFFICIALI che nell'anno sono associate alla classificazione cespite con età pari alla differenza tra l'anno
-- di acquisizione del cespite e la data contabile
-- In questo caso prima di effettuare le rivalutazioni controllo se ci sono rivalutazioni che hanno il campo ETA' valorizzato,
-- in caso negativo provo ad effettuare rivalutazioni senza ETA' (costanti nel tempo)
 
 IF (@trovato = 'N')
		BEGIN
			IF 
			(SELECT COUNT(*)
			FROM inventoryamortization I
			JOIN inventorysortingamortizationyear A
				ON I.idinventoryamortization = A.idinventoryamortization
			WHERE (I.flag & 2 <> 0) AND I.age IS NOT NULL AND A.ayear = @ayear_rif AND ISNULL(I.active,'S')= 'S') > 0
			BEGIN
				-- Considero i tipi di rivalutazioni 'ANNUALI' 
				SELECT  
					@trovato = 'S',
					@idinventoryamortization = tr.idinventoryamortization,
					@amortizationquota = coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)
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
				LEFT OUTER JOIN inventorysortingamortizationyear t1			ON t1.idinv = IL1.idparent AND t1.ayear = @ayear_rif
				LEFT OUTER JOIN inventorysortingamortizationyear t2			ON t2.idinv = IL2.idparent  AND t2.ayear = @ayear_rif
				LEFT OUTER JOIN inventorysortingamortizationyear t3			ON t3.idinv = IL3.idparent AND t3.ayear = @ayear_rif
				LEFT OUTER JOIN inventorysortingamortizationyear t4			ON t4.idinv = IL4.idparent AND t4.ayear = @ayear_rif 
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
					AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start)))
					AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
					AND (AU.adate is null OR YEAR(AU.adate)>@ayear )		
					AND ( (inventorykind.flag&2)=0)
					AND b.amortizationquota is null
				 END
	 END

		 

	-- CONSIDERO I TIPI DI RIVALUTAZIONI MENSILI
 
 IF (@trovato = 'N')
		BEGIN
		SELECT 
			@trovato = 'S',
			@idinventoryamortization = tr.idinventoryamortization, 
			@amortizationquota = ISNULL(t4.amortizationquota,ISNULL(t3.amortizationquota,
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
		LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayear_rif
		LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent AND t2.ayear = @ayear_rif
		LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayear_rif
		LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayear_rif 
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
			AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start) ))
			AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
			AND (AU.adate is null OR YEAR(AU.adate)>@ayear )
			AND ( (inventorykind.flag&2)=0)
			AND b.amortizationquota is null
 END
		

-- Nel caso non ci siano rivalutazioni con il campo ETA valorizzato allora effettuo la rivalutazione dei cespiti
-- con tipi rivalutazione con il campo ETA non valorizzato
		IF (@trovato = 'N')
		BEGIN
		IF 
		(SELECT COUNT(*)
		FROM inventoryamortization I
		JOIN inventorysortingamortizationyear A
			ON I.idinventoryamortization = A.idinventoryamortization
		WHERE (I.flag & 2 <> 0) AND I.age IS NOT NULL AND A.ayear = @ayear_rif AND ISNULL(I.active,'S')= 'S') = 0
		BEGIN
			SELECT @trovato = 'S',
				@idinventoryamortization = tr.idinventoryamortization, 
				@amortizationquota = coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)
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
			LEFT OUTER JOIN inventorysortingamortizationyear t1		ON t1.idinv = IL1.idparent AND t1.ayear = @ayear_rif
			LEFT OUTER JOIN inventorysortingamortizationyear t2		ON t2.idinv = IL2.idparent AND t2.ayear = @ayear_rif
			LEFT OUTER JOIN inventorysortingamortizationyear t3		ON t3.idinv = IL3.idparent AND t3.ayear = @ayear_rif
			LEFT OUTER JOIN inventorysortingamortizationyear t4		ON t4.idinv = IL4.idparent AND t4.ayear = @ayear_rif 
			JOIN inventoryamortization tr		ON tr.idinventoryamortization = 
						COALESCE(t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
			WHERE   b.lifestart IS NOT NULL AND b.lifestart <= @dec_31
				AND (tr.flag & 2 <> 0)	--ufficiale
				AND ((tr.flag&8) <> 0) -- ammortamenti
				AND (tr.flag & 1 = 0)		--annuale
				AND ISNULL(tr.active,'S')= 'S'
				AND tr.age is null
				AND tr.agemax is null
				AND (b.flag & 1 <> 0)
				AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start) ))
				AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
				AND (AU.adate is null OR YEAR(AU.adate)>@ayear )
				AND ( (inventorykind.flag&2)=0)
				AND b.amortizationquota is null
			 END
	 END
	 
	 IF (@trovato = 'N')
			BEGIN
			SELECT  @trovato = 'S',
				@idinventoryamortization = tr.idinventoryamortization,	 
				@amortizationquota = coalesce(t4.amortizationquota,t3.amortizationquota,t2.amortizationquota,t1.amortizationquota)/12 *
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
			LEFT OUTER JOIN inventorysortingamortizationyear t1			ON t1.idinv = IL1.idparent AND t1.ayear = @ayear_rif
			LEFT OUTER JOIN inventorysortingamortizationyear t2			ON t2.idinv = IL2.idparent AND t2.ayear = @ayear_rif
			LEFT OUTER JOIN inventorysortingamortizationyear t3			ON t3.idinv = IL3.idparent AND t3.ayear = @ayear_rif
			LEFT OUTER JOIN inventorysortingamortizationyear t4			ON t4.idinv = IL4.idparent AND t4.ayear = @ayear_rif 
			JOIN inventoryamortization tr		ON tr.idinventoryamortization = 
					COALESCE(t4.idinventoryamortization,t3.idinventoryamortization,t2.idinventoryamortization,t1.idinventoryamortization)
			WHERE  b.lifestart IS NOT NULL AND b.lifestart <= @dec_31
				AND (tr.flag & 2 <> 0)	--ufficiale
				AND ((tr.flag&8) <> 0)  --ammortamenti
				AND (tr.flag & 1 <> 0)	--mensile
				AND ISNULL(tr.active,'S')= 'S'
				AND tr.age is null
				AND tr.agemax is null
				AND (b.flag & 1 <> 0)
		 
				AND	((tr.valuemin is null or tr.valuemin<ISNULL(C.historicalvalue,AC.start) ) and (tr.valuemax is null or tr.valuemax>=ISNULL(C.historicalvalue,AC.start) ))
				AND (YEAR(assetload.ratificationdate)<=@ayear OR   ((c.flag & 1 = 0) AND (c.flag & 2 <> 0)) )
				AND (AU.adate is null OR YEAR(AU.adate)>@ayear )
				AND ( (inventorykind.flag&2)=0)
				AND b.amortizationquota is null
	 END

		--@assetvalue valore ORIGINALE alla data del 31 12 dell'anno
		--@actualvalue valore ATTUALE alla data del 31 12 dell'anno
	    
	   IF (@trovato = 'S')
		BEGIN
			SET @reval=ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2)

			-- Viene sostituito il precedente controllo (@reval > @actualvalue) in quanto @reval nel caso di ammortamenti
			-- è negativo! Quindi la somma algebrica dei due importi deve essere sempre >=0
			IF ( (@reval + @actualvalue) < 0) 
			BEGIN
				SET @amortizationquota  = -@actualvalue/@assetvalue
			END

			SET @reval = ROUND(ISNULL(@assetvalue, 0.0) * ISNULL(@amortizationquota,0.0) ,2) 
			RETURN @reval
		END
	 RETURN 0
END
 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
