/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_flussi_cassa_all4_ricalcola_percentuali]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_flussi_cassa_all4_ricalcola_percentuali]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO  
--setuser'amministrazione'
CREATE    PROCEDURE [exp_flussi_cassa_all4_ricalcola_percentuali]
(
	@ayear int, -- esercizio dell'esportazione
	@date_rif datetime, --data di riferimento
	@kind varchar(20),
	@ID VARCHAR(5),
	@label VARCHAR(100),
    @PrevisioneTotale DECIMAL(19, 2),
    @PercOrigTr1 DECIMAL(19, 2),
    @PercOrigTr2 DECIMAL(19, 2),
    @PercOrigTr3 DECIMAL(19, 2),
    @PercOrigTr4 DECIMAL(19, 2),
	@ImportoRealeTr1 DECIMAL(19, 2),
    @ImportoRealeTr2 DECIMAL(19, 2),
    @ImportoRealeTr3 DECIMAL(19, 2),
    @ImportoRealeTr4 DECIMAL(19, 2)
)
AS BEGIN
	--PRINT @ayear  
	--PRINT @kind 
	--PRINT @ID  
	--PRINT @label  
 --   PRINT @PrevisioneTotale 
 --   PRINT @PercOrigTr1  
 --   PRINT @PercOrigTr2 
 --   PRINT @PercOrigTr3  
 --   PRINT @PercOrigTr4 
	--PRINT @ImportoRealeTr1 
 --   PRINT @ImportoRealeTr2  
 --   PRINT @ImportoRealeTr3 
 --   PRINT @ImportoRealeTr4 
--- SETUSER 'amministrazione'
--- EXEC [exp_flussi_cassa_all4_ricalcola_percentuali]  2025, ,   {ts '2025-10-25 00:00:00'} ,'Entrate', 'B20', '(Beni e servizi)', 100000.00, 13.00, 12.00, 50.00, 25.00, 10000.00, 0.00, 5, 12340
--- ESEMPI DI CALCOLO TRIMESTRE DI RIFERIMENTO, PRECEDE QUELLO CORRENTE
/*
Anno di riferimento 2025
Data di Riferimento				Trimestre di riferimento (@trimestre)
17 marzo 2025							0
15 giugno 2025							1
10 settembre 2025						2
20 dicembre 2025						3
10 gennaio 2026							4
*/
 
--- AL TERMINE DEL 1° TRIMESTRE Calcola le correzioni alle previsioni iniziali per i trimestri successivi 2°, 3° e 4°
 -- Formula ricalcolo della previsione del secondo trimestre B2 al termine del primo trimestre A  
 -- B2 =(A1-A2)*(B1)/( B1 + C1+ D1 )
 -- A1 previsione originale primo trimestre 
 -- A2 pagato/incassato effettivo primo trimestre
 -- B1 previsione originale del secondo trimestre
 -- B1 + C1+ D1 somma delle previsioni originali del secondo, terzo e quarto trimestre

 -- Formula ricalcolo del terzo trimestre C2 al termine del primo trimestre A  
 -- C2 =(A1-A2)*(C1)/( B1 + C1+ D1 )
 -- A1 previsione originale primo trimestre 
 -- A2 pagato/incassato effettivo primo trimestre
 -- C1 previsione originale del terzo trimestre
 -- B1 + C1+ D1 somma delle previsioni originali del secondo, terzo e quarto trimestre

 -- Formula ricalcolo del quarto trimestre D2 al termine del primo trimestre  A  
 -- D2 =(A1-A2)*(D1)/(  B1 + C1+ D1)
 -- A1 previsione originale primo trimestre 
 -- A2 pagato/incassato effettivo primo trimestre
 -- D1 previsione originale del quarto trimestre
 -- B1 + C1+ D1 somma delle previsioni originali del secondo, terzo e quarto trimestre

 --------------------------------------------------------------------------------------------------
 --AL TERMINE DEL 2° TRIMESTRE Calcola le correzioni per i trimestri successivi 3° e 4° ----------- 
 --------------------------------------------------------------------------------------------------
 -- Formula ricalcolo del terzo trimestre C2 al termine del secondo trimestre B  
 -- C2 =(A1-A2 + B1 -B2 )*(C1)/(C1+ D1 )
 -- A1 previsione originale primo trimestre 
 -- A2 pagato/incassato effettivo primo trimestre
 -- B1 previsione originale secondo trimestre 
 -- B2 pagato/incassato effettivo secondo trimestre
 -- C1 previsione originale del terzo trimestre
 -- C1+ D1 somma delle previsioni originali del terzo e quarto trimestre

 -- Formula ricalcolo del Quarto trimestre D2 al termine del secondo trimestre  B 
 -- D2 =(A1-A2 + B1 - B2 )*(D1)/( C1+ D1)
 -- A1 previsione originale primo trimestre 
 -- A2 pagato/incassato effettivo primo trimestre
 -- B1 previsione originale secondo trimestre 
 -- B2 pagato/incassato effettivo secondo trimestre
 -- D1 previsione originale del quarto trimestre
 -- C1+ D1 somma delle previsioni originali del   terzo e quarto trimestre

 --------------------------------------------------------------------------------------------------
 --AL TERMINE DEL 3° TRIMESTRE Calcola le correzioni per il trimestre successivo 4° --------------- 
 --------------------------------------------------------------------------------------------------

 -- Formula ricalcolo del quarto trimestre D2 al termine del terzo trimestre C 
 -- D2 =(A1-A2 + B1 -B2 + C1 - C2)*(D1)/(D1)
 -- A1 previsione originale primo trimestre 

--- setuser 'amministrazione'
--- exec exp_piano_annuale_flussi_cassa_all4 2025, 29,30

 -- A2 pagato/incassato effettivo primo trimestre
 -- B1 previsione originale secondo trimestre 
 -- B2 pagato/incassato effettivo secondo trimestre
 -- C1 previsione originale terzo trimestre 
 -- C2 pagato/incassato effettivo terzo trimestre
 -- D1 previsione originale del quarto trimestre
 

--1. Definire la Tabella Iniziale
--Innanzitutto, definisci una tabella che contenga l''importo previsto totale e la sua ripartizione percentuale per ogni trimestre.
DECLARE @31dicCurr datetime
SET @31dicCurr = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear),105)

select @date_rif = isnull(@date_rif,GetDate())
-- DECLARE @ayear     int = 2025
-- SET @ayear = 2025
DECLARE @trimestre int 
 
SELECT  @trimestre = 
	    CASE 
			WHEN @31dicCurr = @date_rif THEN 4
			WHEN @ayear = year(@date_rif) THEN (DATEPART(q,@date_rif) - 1) 
			ELSE 4 
	    END 

--SET @trimestre  = 4   --- per test
IF OBJECT_ID('tempdb..#Previsioni') IS NOT NULL
DROP TABLE #Previsioni
 
IF OBJECT_ID('tempdb..#DatiReali') IS NOT NULL
DROP TABLE  #DatiReali

CREATE TABLE #Previsioni (
    ID VARCHAR(5) PRIMARY KEY,
    PrevisioneTotale DECIMAL(19, 2),
    PercOrigTr1 DECIMAL(19, 6),
    PercOrigTr2 DECIMAL(19, 6),
    PercOrigTr3 DECIMAL(19, 6),
    PercOrigTr4 DECIMAL(19, 6)
);

--2. Inserire i Dati Iniziali
--Inserisci i dati iniziali nella tabella Previsioni.
--Importo totale deve essere comprensivo delle variazioni entro la data termine del trimestre
INSERT INTO #Previsioni (ID, PrevisioneTotale, PercOrigTr1, PercOrigTr2, PercOrigTr3, PercOrigTr4)
-- VALUES ('1', 100000.00, 13.00, 12.00, 50.00, 25.00);
VALUES (@ID, @PrevisioneTotale, @PercOrigTr1,@PercOrigTr2, @PercOrigTr3, @PercOrigTr4);
--select '#Previsioni Perc.', * from #Previsioni
--3. Calcolare le Previsioni Iniziali per Trimestre
/*
SELECT '#Previsioni',
    ID,
	PrevisioneTotale,
    round(PrevisioneTotale * PercOrigTr1 / 100,2) AS PrevisioneTr1,
    round(PrevisioneTotale * PercOrigTr2 / 100,2) AS PrevisioneTr2,
    round(PrevisioneTotale * PercOrigTr3 / 100,2) AS PrevisioneTr3,
    round(PrevisioneTotale * PercOrigTr4 / 100,2) AS PrevisioneTr4
FROM #Previsioni;
*/
--4. Ricalcolare le Previsioni dopo Ogni Trimestre
--Supponendo di avere una tabella DatiReali con i dati effettivi incassati per ogni trimestre:

CREATE TABLE #DatiReali (
    ID VARCHAR(5) PRIMARY KEY,
    ImportoRealeTr1 DECIMAL(19, 2),
    ImportoRealeTr2 DECIMAL(19, 2),
    ImportoRealeTr3 DECIMAL(19, 2),
    ImportoRealeTr4 DECIMAL(19, 2)
);

INSERT INTO #DatiReali (ID, ImportoRealeTr1, ImportoRealeTr2, ImportoRealeTr3, ImportoRealeTr4)
--VALUES ('1', 10000.00, 0.00, 5, 12340);
VALUES (@ID, @ImportoRealeTr1,@ImportoRealeTr2, @ImportoRealeTr3, @ImportoRealeTr4);
--select '#DatiReali', * from #DatiReali
--select 'Trimestre riferimento',@trimestre

--4. Calcola le percentuali effettive dei trimestri trascorsi
/*
  SELECT 'PercentualiReali', 
	DR.ID,
        ISNULL(DR.ImportoRealeTr1 / P.PrevisioneTotale * 100, 0) AS PercRealeTr1,
        ISNULL(DR.ImportoRealeTr2 / P.PrevisioneTotale * 100, 0) AS PercRealeTr2,
        ISNULL(DR.ImportoRealeTr3 / P.PrevisioneTotale * 100, 0) AS PercRealeTr3,
        ISNULL(DR.ImportoRealeTr4 / P.PrevisioneTotale * 100, 0) AS PercRealeTr4
    FROM #DatiReali DR
    JOIN #Previsioni P ON DR.ID = P.ID;
 */
--- Somme delle previsioni originali da ricalcolare al termine di ogni Trimestre 
WITH PercOriginaliResidue AS (
    SELECT 
        ID,
        PercOrigTr2_3_4 = (PercOrigTr2 + PercOrigTr3 + PercOrigTr4),
        PercOrigTr3_4 = (PercOrigTr3 + PercOrigTr4),
        PercOrigTr4 = PercOrigTr4
    FROM #Previsioni
),
 
-- Calcola le percentuali effettive dell'incassato/pagato nei trimestri già trascorsi
PercentualiReali AS (
    SELECT 
		DR.ID,
        ISNULL(DR.ImportoRealeTr1 / (case when (P.PrevisioneTotale  = 0)  then 
									ISNULL(DR.ImportoRealeTr1,0) + ISNULL(DR.ImportoRealeTr2,0) + ISNULL(DR.ImportoRealeTr3,0) +ISNULL(DR.ImportoRealeTr4,0)   
									else  P.PrevisioneTotale end)   * 100, 0)  AS PercRealeTr1,
        ISNULL(DR.ImportoRealeTr2 / (case when (P.PrevisioneTotale  = 0)  then 
									ISNULL(DR.ImportoRealeTr1,0) + ISNULL(DR.ImportoRealeTr2,0) + ISNULL(DR.ImportoRealeTr3,0) +ISNULL(DR.ImportoRealeTr4,0)  
									else  P.PrevisioneTotale end)   * 100, 0)  AS PercRealeTr2,
        ISNULL(DR.ImportoRealeTr3 / (case when (P.PrevisioneTotale  = 0)  then 
									ISNULL(DR.ImportoRealeTr1,0) + ISNULL(DR.ImportoRealeTr2,0) + ISNULL(DR.ImportoRealeTr3,0) +ISNULL(DR.ImportoRealeTr4,0)  
									else  P.PrevisioneTotale end)   * 100, 0)  AS PercRealeTr3,
        ISNULL(DR.ImportoRealeTr4 / (case when (P.PrevisioneTotale  = 0)  then 
									ISNULL(DR.ImportoRealeTr1,0) + ISNULL(DR.ImportoRealeTr2,0) + ISNULL(DR.ImportoRealeTr3,0) +ISNULL(DR.ImportoRealeTr4,0)  
									else  P.PrevisioneTotale end)   * 100, 0)  AS PercRealeTr4
    FROM #DatiReali DR
    JOIN #Previsioni P ON DR.ID = P.ID 
),
-- Somma parziale delle differenze tra percentuali Originali e percentuali Reali al trascorrere dei Trimestri (1°, 1° e 2°,  1° 2° e 3°)
SommeParzDifferenzePerc AS
(
	SELECT 
		PR.ID,
		SumDiffTr1 = P.PercOrigTr1 - PR.PercRealeTr1,  --1°,
		SumDiffTr1_2 = P.PercOrigTr1 - PR.PercRealeTr1 + P.PercOrigTr2 - PR.PercRealeTr2, --1° e 2°,
		SumDiffTr1_2_3 = P.PercOrigTr1 - PR.PercRealeTr1 + P.PercOrigTr2 - PR.PercRealeTr2 + P.PercOrigTr3 - PR.PercRealeTr3  --1° 2° e 3°
		FROM PercentualiReali PR
		JOIN #Previsioni P ON PR.ID = P.ID
),
--- Formule correttive da applicare alle percentuali dopo 1° TRIMESTRE, le cui correzioni si applicano al 2° 3° e 4° trimestre
Correzioni AS (
    SELECT 
        P.ID,
		0 AS CorrPercTr1,  -- nessuna correzione
		(DIFF.SumDiffTr1)* (P.PercOrigTr2) / (case when  (PercResidue.PercOrigTr2_3_4) = 0  then 1  else  (PercResidue.PercOrigTr2_3_4) end)  
		AS CorrPercTr2,
		(DIFF.SumDiffTr1)*(P.PercOrigTr3) / (case when  (PercResidue.PercOrigTr2_3_4) = 0  then 1  else  (PercResidue.PercOrigTr2_3_4) end)   
		AS CorrPercTr3,
		(DIFF.SumDiffTr1) * (P.PercOrigTr4) / (case when  (PercResidue.PercOrigTr2_3_4) = 0  then 1  else  (PercResidue.PercOrigTr2_3_4) end)   
		AS CorrPercTr4
	FROM #Previsioni P
    JOIN PercentualiReali PE ON P.ID = PE.ID
	JOIN PercOriginaliResidue PercResidue ON P.ID = PercResidue.ID
	JOIN SommeParzDifferenzePerc DIFF ON DIFF.ID = P.ID
),

--- Formule correttive da applicare alle percentuali dopo 2° TRIMESTRE, le cui correzioni si applicano al   3° e 4° trimestre
Correzioni2 AS (
    SELECT 
        P.ID,
		0 AS CorrPercTr1, -- nessuna correzione 1°
		0 AS CorrPercTr2, -- nessuna correzione 2°

		(DIFF.SumDiffTr1_2) * (P.PercOrigTr3) / (case when  (PercResidue.PercOrigTr3_4) = 0  then 1  else  (PercResidue.PercOrigTr3_4) end)    
		AS CorrPercTr3,

		(DIFF.SumDiffTr1_2) * (P.PercOrigTr4) / (case when  (PercResidue.PercOrigTr3_4) = 0  then 1  else  (PercResidue.PercOrigTr3_4) end)    
		AS CorrPercTr4
	FROM #Previsioni P
	JOIN PercentualiReali PE ON P.ID = PE.ID
	JOIN SommeParzDifferenzePerc DIFF ON DIFF.ID = P.ID
	JOIN PercOriginaliResidue PercResidue ON P.ID = PercResidue.ID

),
--- Formule correttive da applicare alle percentuali dopo 3° TRIMESTRE,  le cui correzioni si applicano al   4° trimestre
Correzioni3 AS (
    SELECT 
        P.ID,
		0 AS CorrPercTr1, -- nessuna correzione 1°
		0 AS CorrPercTr2, -- nessuna correzione 2°
		0 AS CorrPercTr3, -- nessuna correzione 3°
		(DIFF.SumDiffTr1_2_3)
		AS CorrPercTr4
	FROM #Previsioni P
	JOIN PercentualiReali PE ON P.ID = PE.ID
	JOIN SommeParzDifferenzePerc DIFF ON DIFF.ID = P.ID
	JOIN PercOriginaliResidue PRes ON P.ID = PRes.ID  
)
 
--------------------------------------------------------------------
------------------------------ OUTPUT ------------------------------
--------------------------------------------------------------------

--------------------------------------------------------------------
------------------------------ TRIMESTRE "0" -----------------------
--------------------------------------------------------------------
-- Durante il 1° Trimestre, restituisce le stesse percentuali stimate 
-- e le stesse ripartizioni della previsione fornite in Input
 SELECT
	@trimestre AS TrimestreRif,
	@kind as kind,
	@label as label, 
	P.ID,
    0 as CorrPercTr1,
    0 as CorrPercTr2,
    0 as CorrPercTr3,
    0 as CorrPercTr4,
	P.PercOrigTr1 as PercRealeTr1,
	P.PercOrigTr2 as PercRealeTr2,
	P.PercOrigTr3 as PercRealeTr3,
    P.PercOrigTr4 as PercRealeTr4,
	P.PrevisioneTotale,
	convert(decimal(19,2),round(P.PrevisioneTotale * P.PercOrigTr1 / 100,2))  as ImportoRealeTr1,
	convert(decimal(19,2),round(P.PrevisioneTotale * P.PercOrigTr2 / 100,2))  as ImportoRealeTr2,
	convert(decimal(19,2),round(P.PrevisioneTotale * P.PercOrigTr3 / 100,2))  as ImportoRealeTr3,
	convert(decimal(19,2),round(P.PrevisioneTotale * P.PercOrigTr4 / 100,2))  as ImportoRealeTr4,
	P.PercOrigTr1 as   NuovaPercTr1,
	convert(decimal(19,2),round(P.PrevisioneTotale * P.PercOrigTr1 / 100,2))  as NuovaPrevTr1,
	P.PercOrigTr2 as   NuovaPercTr2,
	convert(decimal(19,2),round(P.PrevisioneTotale * P.PercOrigTr2 / 100,2))  as NuovaPrevTr2,
	P.PercOrigTr3 as   NuovaPercTr3,
	convert(decimal(19,2),round(P.PrevisioneTotale * P.PercOrigTr3 / 100,2))  as NuovaPrevTr3,
	P.PercOrigTr4 as   NuovaPercTr4,
	convert(decimal(19,2),round(P.PrevisioneTotale * P.PercOrigTr4 / 100,2))  as NuovaPrevTr4
	FROM #Previsioni P
	WHERE @trimestre =  0
UNION 
--------------------------------------------------------------------
------------------------------ TRIMESTRE 1°-------------------------
--------------------------------------------------------------------
-- Applica diverse correzioni per ottenere le nuove previsioni in base al trimestre in cui ci troviamo
-- Dopo il 1° Trimestre, applica le correzioni della tabella Correzioni
 SELECT
	@trimestre AS TrimestreRif,
	@kind as kind,
	@label as label, 
    Corr.*,
	PercReal.PercRealeTr1,
	PercReal.PercRealeTr2,
	PercReal.PercRealeTr3,
	PercReal.PercRealeTr4,
	P.PrevisioneTotale,

	ISNULL(D.ImportoRealeTr1,0) AS ImportoRealeTr1,
	ISNULL(D.ImportoRealeTr2,0) AS ImportoRealeTr2,
	ISNULL(D.ImportoRealeTr3,0) AS ImportoRealeTr3,
	ISNULL(D.ImportoRealeTr4,0) AS ImportoRealeTr4,

	PercReal.PercRealeTr1 AS   NuovaPercTr1,
    ISNULL(D.ImportoRealeTr1,0) AS NuovaPrevTr1,

	convert(decimal(19,2), (P.PercOrigTr2 + Corr.CorrPercTr2)) AS   NuovaPercTr2,
    convert(decimal(19,2), (P.PrevisioneTotale * (P.PercOrigTr2 + Corr.CorrPercTr2)/100))   AS NuovaPrevTr2,

	convert(decimal(19,2),(P.PercOrigTr3 + Corr.CorrPercTr3)) AS   NuovaPercTr3,
    convert(decimal(19,2),(P.PrevisioneTotale * (P.PercOrigTr3 + Corr.CorrPercTr3)/100))  AS NuovaPrevTr3,

	/*ultimo trimestre chiude la percentuale 100% per differenza dagli importi degli altri tre trimestri*/
			100 -  
			(PercReal.PercRealeTr1 +
			 convert(decimal(19,2),round(P.PercOrigTr2 + Corr.CorrPercTr2,2)) + 
			 convert(decimal(19,2),round(P.PercOrigTr3 + Corr.CorrPercTr3,2))  
			 )
	AS   NuovaPercTr4,
    (P.PrevisioneTotale - (ISNULL(D.ImportoRealeTr1,0) + 
	convert(decimal(19,2),round(P.PrevisioneTotale * (P.PercOrigTr2 + Corr.CorrPercTr2)/100,2)) +
	 convert(decimal(19,2),round(P.PrevisioneTotale * (P.PercOrigTr3 + Corr.CorrPercTr3)/100 ,2))
	))
	AS NuovaPrevTr4

FROM Correzioni	 AS Corr
JOIN PercentualiReali PercReal ON PercReal.ID = Corr.ID
JOIN #Previsioni P ON Corr.ID = P.ID
JOIN #DatiReali D  ON D.ID = P.ID 
WHERE  @trimestre =  1 
UNION 
--------------------------------------------------------------------
------------------------------ TRIMESTRE 2°-------------------------
--------------------------------------------------------------------
-- Dopo il 2° Trimestre, applica le correzioni della tabella Correzioni2
SELECT  
	@trimestre AS TrimestreRif,
	@kind as kind,
	@label as label, 
    Corr.*,
	PercReal.PercRealeTr1,
	PercReal.PercRealeTr2,
	PercReal.PercRealeTr3,
	PercReal.PercRealeTr4,
	P.PrevisioneTotale,

	ISNULL(D.ImportoRealeTr1,0) AS ImportoRealeTr1,
	ISNULL(D.ImportoRealeTr2,0) AS ImportoRealeTr2,
	ISNULL(D.ImportoRealeTr3,0) AS ImportoRealeTr3,
	ISNULL(D.ImportoRealeTr4,0) AS ImportoRealeTr4,

	PercReal.PercRealeTr1 AS   NuovaPercTr1,
    ISNULL(D.ImportoRealeTr1,0)  AS NuovaPrevTr1,

	PercReal.PercRealeTr2 AS   NuovaPercTr2,
    ISNULL(D.ImportoRealeTr2,0) AS NuovaPrevTr2,
 
	convert(decimal(19,2),round(P.PercOrigTr3 + Corr.CorrPercTr3,2)) AS   NuovaPercTr3,
    convert(decimal(19,2),round(P.PrevisioneTotale * (P.PercOrigTr3 + Corr.CorrPercTr3)/100,2))   AS NuovaPrevTr3,

	
	/*ultimo trimestre chiude la percentuale 100% per differenza dagli importi degli altri tre trimestri*/
	100 -  
	(PercReal.PercRealeTr1 +PercReal.PercRealeTr2 +
		convert(decimal(19,2),round(P.PercOrigTr3 + Corr.CorrPercTr3,2))  
		)
	AS   NuovaPercTr4,
    (P.PrevisioneTotale - (ISNULL(D.ImportoRealeTr1,0) + ISNULL(D.ImportoRealeTr2,0) +
	 convert(decimal(19,2),round(P.PrevisioneTotale * (P.PercOrigTr3 + Corr.CorrPercTr3)/100 ,2))
	))
	AS NuovaPrevTr4

FROM Correzioni2 Corr
JOIN PercentualiReali PercReal ON PercReal.ID = Corr.ID
JOIN #Previsioni P ON Corr.ID = P.ID
JOIN #DatiReali D  ON D.ID = P.ID  
WHERE  @trimestre =  2 
UNION 
--------------------------------------------------------------------
------------------------------ TRIMESTRE 3°-------------------------
--------------------------------------------------------------------
-- Dopo il 3° Trimestre, applica le correzioni della tabella Correzioni3
 SELECT
	@trimestre AS TrimestreRif,  
	@kind as kind,
	@label as label, 
    Corr.*,
	PercReal.PercRealeTr1,
	PercReal.PercRealeTr2,
	PercReal.PercRealeTr3,
	PercReal.PercRealeTr4,
	P.PrevisioneTotale,

	ISNULL(D.ImportoRealeTr1,0) AS ImportoRealeTr1,
	ISNULL(D.ImportoRealeTr2,0) AS ImportoRealeTr2,
	ISNULL(D.ImportoRealeTr3,0) AS ImportoRealeTr3,
	ISNULL(D.ImportoRealeTr4,0) AS ImportoRealeTr4,

	PercReal.PercRealeTr1 AS   NuovaPercTr1,
    ISNULL(D.ImportoRealeTr1,0) AS NuovaPrevTr1,

	PercReal.PercRealeTr2 AS   NuovaPercTr2,
    ISNULL(D.ImportoRealeTr2,0) AS NuovaPrevTr2,
 
	PercReal.PercRealeTr3 AS   NuovaPercTr3,
    ISNULL(D.ImportoRealeTr3,0) AS NuovaPrevTr3,
 
		
	/*ultimo trimestre chiude la percentuale 100% per differenza dagli importi degli altri tre trimestri*/
			100 -  
			(PercReal.PercRealeTr1 + PercReal.PercRealeTr2 + PercReal.PercRealeTr3)
	AS   NuovaPercTr4,
    (P.PrevisioneTotale - (ISNULL(D.ImportoRealeTr1,0) + ISNULL(D.ImportoRealeTr2,0) + ISNULL(D.ImportoRealeTr3,0) 
	))AS NuovaPrevTr4

FROM Correzioni3 Corr
JOIN PercentualiReali PercReal ON PercReal.ID = Corr.ID
JOIN #Previsioni P ON Corr.ID = P.ID
JOIN #DatiReali D  ON D.ID = P.ID
WHERE @trimestre =  3
UNION 
--------------------------------------------------------------------
------------------------------ TRIMESTRE 4°-------------------------
--------------------------------------------------------------------
-- Dopo il 4° Trimestre, applica le correzioni, per analogia coi trimestri precedenti
-- ma sono tutte a zero, perchè i valori si assumono effettivi dopo la fine dell'anno
SELECT 
	@trimestre AS TrimestreRif,
	@kind as kind,
	@label as label, 
	PercReal.ID, 
    0 AS CorrPercTr1,  -- nessuna correzione 1°
	0 AS CorrPercTr2,  -- nessuna correzione 2°
	0 AS CorrPercTr3,  -- nessuna correzione 3°
	0 AS CorrPercTr4,  -- nessuna correzione 4°
	PercReal.PercRealeTr1,
	PercReal.PercRealeTr2,
	PercReal.PercRealeTr3,
	PercReal.PercRealeTr4,
	P.PrevisioneTotale,

	ISNULL(D.ImportoRealeTr1,0) AS ImportoRealeTr1,
	ISNULL(D.ImportoRealeTr2,0) AS ImportoRealeTr2,
	ISNULL(D.ImportoRealeTr3,0) AS ImportoRealeTr3,
	ISNULL(D.ImportoRealeTr4,0) AS ImportoRealeTr4,

	PercReal.PercRealeTr1 AS   NuovaPercTr1,
    ISNULL(D.ImportoRealeTr1,0) AS NuovaPrevTr1,

	PercReal.PercRealeTr2 AS   NuovaPercTr2,
    ISNULL(D.ImportoRealeTr2,0) AS NuovaPrevTr2,
 
	PercReal.PercRealeTr3 AS   NuovaPercTr3,
	ISNULL(D.ImportoRealeTr3,0)  AS NuovaPrevTr3,
 
	PercReal.PercRealeTr4 AS   NuovaPercTr4,
    ISNULL(D.ImportoRealeTr4,0) AS NuovaPrevTr4 

FROM PercentualiReali PercReal 
JOIN #Previsioni P ON PercReal.ID = P.ID
JOIN #DatiReali D  ON D.ID = P.ID
WHERE  @trimestre =  4

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

  