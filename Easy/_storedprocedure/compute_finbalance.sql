
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_finbalance]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_finbalance]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec compute_finbalance 2007,'4'

CREATE        PROCEDURE [compute_finbalance]
@ayear smallint,
@levelusable smallint 

AS BEGIN
DECLARE @assessmentphasecode smallint		-- Fase corrispondente all'accertamento
DECLARE @appropriationphasecode smallint	-- Fase corrispondente all'impegno
DECLARE @fin_kind tinyint

SELECT 
	@fin_kind = ISNULL(fin_kind,0),
	@assessmentphasecode = assessmentphasecode,
	@appropriationphasecode = appropriationphasecode
FROM config 
WHERE ayear = (@ayear - 1)

DECLARE @maxexpensephase tinyint 
SELECT @maxexpensephase = MAX(nphase) FROM expensephase
DECLARE @maxincomephase	tinyint
SELECT @maxincomephase = MAX(nphase) FROM incomephase

-- 31/12 dell'esercizio precedente
DECLARE @lastdayOY datetime	
SET @lastdayOY = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear - 1),105)
-- 01/01 dell'esercizio precedente
DECLARE @firstdayOY datetime	
SET @firstdayOY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear - 1),105)
-- 01/01 dell'esercizio corrente
DECLARE @firstdayNY datetime	
SET @firstdayNY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear),105)
-- Parametro che gestisce le informazioni sull'avanzo
DECLARE @infoadvance char(1)		
SELECT @infoadvance = paramvalue
FROM generalreportparameter
WHERE idparam = 'MostraAvanzo'
-- Tabella che contiene i dati effettivi al 31/12 dell'esercizio precedente
CREATE TABLE #finbalance
(
	idfin int, 
	codefin varchar(50),
	idupb varchar(36),
	assured varchar (1),
	finpart char (1),
	actualcreditsurplus decimal(19,2),
	actualcashsurplus decimal(19,2),
	totcredit decimal(19,2), -- Total Assegnazione Crediti  + Totale Dotazione Crediti
	totproceedspart decimal(19,2), -- Totale Assegnazione Incassi
	proceedsvariation decimal(19,2), -- Totale Dotazione Cassa
	supposedcredits decimal(19,2), -- Totale Dotazione Crediti di Ripartizione Presunta
	supposedproceeds decimal(19,2), -- Totale Dotazione Cassa di Ripartizione Presunta
	revenue decimal(19,2), -- Totale dei residui attivi dell'esercizio precedente
	expenditure decimal(19,2), -- Totale dei residui passivi dell'esercizio precedente
	--settlement decimal (19,2), -- valore di assestamento calcolato in E/S solo x i Fondi
	revenue_E decimal(19,2), -- valore dei residui attivi calcolati in E solo x i fondi
	actualavailableprev decimal (19,2), 
	supposedavailableprev decimal(19,2),
	supposedexpenditure decimal(19,2), 
	supposedrevenue decimal(19,2) ,
	actualprev decimal (19,2),--  previsione effettiva[@ayear-1]
	payment decimal (19,2),-- pagamenti[@ayear-1]
	proceeds decimal (19,2), -- incassi_E[@ayear-1]
	assignedcash decimal (19,2)-- cassa in uscita:
)

INSERT INTO #finbalance
(
	idfin,
	idupb,
	assured,
	finpart
)
SELECT distinct
	F.idfin, 
	U.idupb,
	U.assured,
	CASE 
		when ( F.flag & 1=0) then 'E'
		when ( F.flag & 1=1) then 'S'
	End
FROM expenseyear EY 
JOIN finlink FLK
	ON FLK.idchild = EY.idfin
join fin F 
    on F.idfin= FLK.idparent
JOIN upb  U
    on U.idupb= EY.idupb
JOIN finlevel fl
 ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
WHERE EY.ayear = @ayear - 1
	AND (F.nlevel = @levelusable
		OR (F.nlevel < @levelusable
		AND EXISTS
			(SELECT * FROM finlast WHERE finlast.idfin = F.idfin)
			AND (fl.flag&2)<>0 
			)
		)

INSERT INTO #finbalance
(
	idfin,
	idupb,
	assured,
	finpart
)
SELECT DISTINCT
	F.idfin, 
	U.idupb,
	U.assured,
	CASE 
		when ( F.flag & 1=0) then 'E'
		when ( F.flag & 1=1) then 'S'
	End
FROM incomeyear IY 
JOIN finlink FLK
	ON FLK.idchild = IY.idfin
JOIN fin F 
    on F.idfin= FLK.idparent
 JOIN upb  U ON U.idupb= IY.idupb
JOIN finlevel fl
 ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
WHERE F.ayear = @ayear - 1
	AND  (@infoadvance <> 'S' OR (F.flag & 16 =0) )
	AND (F.nlevel = @levelusable
		OR (F.nlevel < @levelusable
		AND EXISTS
			(SELECT * FROM finlast WHERE finlast.idfin = F.idfin)
			AND (fl.flag&2)<>0 -- usable 
			)
		)
    AND NOT EXISTS(SELECT * from #finbalance where #finbalance.idfin=F.idfin and #finbalance.idupb=IY.idupb)

INSERT INTO #finbalance
(
	idfin,
	idupb,
	assured,
	finpart
)
SELECT distinct
	F.idfin, 
	U.idupb,
	U.assured,
	CASE 
		when ( F.flag & 1=0) then 'E'
		when ( F.flag & 1=1) then 'S'
	End
FROM upbtotal UT
 JOIN finlink FLK
	ON FLK.idchild = UT.idfin
join fin F 
        ON F.idfin=FLK.idparent
JOIN upb  U
        ON U.idupb = UT.idupb
JOIN finlevel fl
 ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
WHERE F.ayear = @ayear - 1
	AND (@infoadvance <> 'S' OR (F.flag & 16 =0) )
	AND (F.nlevel = @levelusable
		OR (F.nlevel < @levelusable
		AND EXISTS		
			(SELECT * FROM finlast WHERE finlast.idfin = F.idfin)
			AND (fl.flag&2)<>0
	           )
	   )
        AND NOT EXISTS(SELECT * from #finbalance where #finbalance.idfin=F.idfin and #finbalance.idupb=UT.idupb)

INSERT INTO #finbalance
(
	idfin,
	idupb,
	assured,
	finpart
)
SELECT distinct
	F.idfin, 
	U.idupb,
	U.assured,
	CASE 
		when ( F.flag & 1=0) then 'E'
		when ( F.flag & 1=1) then 'S'
	End

FROM prevfin PF 
JOIN prevfindetail PFD 
	ON PF.ayear = PFD.ayear AND PF.nprevfin = PFD.nprevfin  
JOIN finlookup LOOKUP
        ON PFD.idfin = LOOKUP.newidfin
JOIN finlink FLK
	ON FLK.idchild = LOOKUP.oldidfin
join fin F 
        ON F.idfin = FLK.idparent
JOIN upb  U
        ON U.idupb = PFD.idupb
JOIN finlevel fl
	ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
WHERE F.ayear = @ayear-1 AND PF.official = 'S' AND PF.ayear = @ayear - 1
	AND (@infoadvance <> 'S' OR (F.flag & 16 =0))
	AND (F.nlevel = @levelusable
		OR (F.nlevel < @levelusable
		AND EXISTS			
			(SELECT * FROM finlast WHERE finlast.idfin = F.idfin)
			AND (fl.flag&2)<>0
	           )
	   )
        AND NOT EXISTS(SELECT * from #finbalance where #finbalance.idfin = F.idfin and #finbalance.idupb = PFD.idupb)

-- Calcolo degli incassi e dei pagamenti di competenza dell'esercizio precedente
-- Vengono considerati gli incassi e i pagamenti in base alla configurazione di bilancio
-- Tabella dell'assegnazione incassi dell'esercizio precedente
CREATE TABLE #incassi(idfin int,idupb varchar(36),amount decimal(19,2))
INSERT INTO #incassi
(
	idfin,
	idupb,
	amount
)
SELECT								
	ISNULL(finlink.idparent,proceedspart.idfin),
	incomeyear.idupb,
	SUM(ISNULL(proceedspart.amount,0.0))
FROM proceedspart
JOIN incomeyear
	ON incomeyear.idinc = proceedspart.idinc
	AND incomeyear.ayear = proceedspart.yproceedspart
JOIN historyproceedsview HPV
	ON incomeyear.idinc = HPV.idinc
	AND incomeyear.ayear = HPV.ymov
LEFT OUTER JOIN finlink
	ON finlink.idchild = proceedspart.idfin AND finlink.nlevel = @levelusable
WHERE incomeyear.ayear = @ayear - 1
	AND (HPV.competencydate >= @firstdayOY 
		AND HPV.competencydate <= @lastdayOY)
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,proceedspart.idfin)

-- Tabella dei pagamenti dell'esercizio precedente
CREATE TABLE #pagamenti(idfin int,idupb varchar(36),amount decimal(19,2))
INSERT INTO #pagamenti
(
	idfin,
	idupb,
	amount
)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	SUM(ISNULL(HPV.curramount,0.0)) -- prima prendeva curramount da expensetotal, ma anche curramount di HPV è preso da expensetotal
FROM expenseyear
JOIN historypaymentview HPV
	ON expenseyear.idexp = HPV.idexp
	AND expenseyear.ayear = HPV.ymov
LEFT OUTER JOIN finlink
	ON finlink.idchild = expenseyear.idfin 	AND finlink.nlevel = @levelusable
WHERE expenseyear.ayear = @ayear - 1
	AND (HPV.competencydate >= @firstdayOY AND HPV.competencydate <= @lastdayOY)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin) 

-- Tabella degli incassi dell'esercizio precedente, 		
CREATE TABLE #incassi_E(idfin int,idupb varchar(36),amount decimal(19,2))
INSERT INTO #incassi_E
(
	idfin,
	idupb,
	amount
)
SELECT
	ISNULL(finlink.idparent,incomeyear.idfin),
	incomeyear.idupb,
	SUM(ISNULL(HPV.curramount,0.0)) 
FROM incomeyear
JOIN historyproceedsview HPV
	ON incomeyear.idinc = HPV.idinc
	AND incomeyear.ayear = HPV.ymov
LEFT OUTER JOIN finlink
	ON finlink.idchild = incomeyear.idfin AND finlink.nlevel = @levelusable
WHERE incomeyear.ayear = @ayear - 1
	AND (HPV.competencydate >= @firstdayOY AND HPV.competencydate <= @lastdayOY)
GROUP BY incomeyear.idupb, ISNULL(finlink.idparent,incomeyear.idfin) 

-- Fondo Cassa all'1/1 dell'anno precedente
UPDATE #finbalance
	SET 
-- Total Assegnazione Crediti  + Totale Dotazione Crediti
	totcredit =		
		(SELECT SUM(ISNULL(totcreditpart,0)  + ISNULL(creditvariation,0))
		FROM upbtotal UT	
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
		WHERE UT.idupb = #finbalance.idupb
			AND ISNULL(FLK.idparent,UT.idfin) = #finbalance.idfin
			AND #finbalance.assured <> 'S'
		),
-- Totale Assegnazione Incassi
	totproceedspart =
		ISNULL(
			(SELECT SUM(UT.totproceedspart)  
			FROM upbtotal UT	
			LEFT OUTER JOIN finlink FLK
				ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
			WHERE UT.idupb = #finbalance.idupb
				AND ISNULL(FLK.idparent,UT.idfin) = #finbalance.idfin
				AND #finbalance.assured <> 'S')
		,0),
-- Totale Dotazione Cassa
	proceedsvariation =
		ISNULL(
			(SELECT SUM(UT.proceedsvariation) 
			FROM upbtotal UT	
			LEFT OUTER JOIN finlink FLK
				ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
			WHERE UT.idupb = #finbalance.idupb
				AND ISNULL(FLK.idparent,UT.idfin) = #finbalance.idfin
			AND #finbalance.assured <> 'S')
		,0)
-------------------------
-- FONDO CASSA EFFETTIVO (viene calcolato sempre a prescindere dalla previsione utilizzata)
-------------------------
/*FONDO CASSA = 
	proceedsvariation
	+ assegnazione incassi dell'esercizio precedente
	- pagamenti anno prec(in base alla config.bilancio)	*/
UPDATE #finbalance
SET actualcashsurplus =
		 proceedsvariation 
		+ ISNULL(
			(SELECT amount 
			FROM #incassi 
			WHERE #finbalance.idupb = #incassi.idupb
				AND #finbalance.idfin = #incassi.idfin),0) 
		- ISNULL(
			(SELECT amount 
			FROM #pagamenti 
			WHERE #finbalance.idupb = #pagamenti.idupb
				AND #finbalance.idfin = #pagamenti.idfin),0)
	WHERE (finpart = 'S') and (assured <>'S') -- x i fondi vale zero

-- Tabella Residui Passivi Iniziali
CREATE TABLE #totinitial_expenditure(idfin int,idupb varchar(36),amount decimal(19,2))
-- Tabella Residui Attivi Iniziali
CREATE TABLE #totinitial_revenue(idfin int,idupb varchar(36),amount decimal(19,2))
-- Tabella Var. Residui Passivi Iniziali
CREATE TABLE #totvar_expenditure(idfin int,idupb varchar(36),amount decimal(19,2))
-- Tabella Var. Residui Attivi Iniziali
CREATE TABLE #totvar_revenue(idfin int,idupb varchar(36),amount decimal(19,2))
-- Tabella degli impegni di competenza dell'esercizio precedente
CREATE TABLE #impegni(idfin int,idupb varchar(36),amount decimal(19,2))
-- Tabella degli accertamenti di competenza dell'esercizio precedente
CREATE TABLE #accertamenti(idfin int,idupb varchar(36),amount decimal(19,2))

IF ((@fin_kind = 1) OR (@fin_kind = 3))
BEGIN
-- Calcolo Residui Passivi
	INSERT INTO #totinitial_expenditure
	(
		idfin,
		idupb,
		amount
	)
	SELECT
		ISNULL(finlink.idparent,expenseyear.idfin),
		expenseyear.idupb,
		ISNULL(SUM(expenseyear.amount), 0)
	FROM expenseyear
	JOIN expensetotal
		ON expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	LEFT OUTER JOIN finlink
		ON finlink.idchild = expenseyear.idfin AND finlink.nlevel = @levelusable
	WHERE expenseyear.ayear = @ayear - 1
		AND ( (expensetotal.flag & 1) = 1) -- Residuo
		AND expense.nphase = @appropriationphasecode
	GROUP BY expenseyear.idupb, ISNULL(finlink.idparent,expenseyear.idfin) 

-- Calcolo Residui Attivi 		
	INSERT INTO #totinitial_revenue
	(
		idfin,
		idupb,
		amount
	)
	SELECT
		ISNULL(finlink.idparent,incomeyear.idfin),
		incomeyear.idupb,
		ISNULL(SUM(incomeyear.amount), 0)
	FROM incomeyear
	JOIN incometotal
		ON incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear
	JOIN income
		ON income.idinc = incomeyear.idinc
	LEFT OUTER JOIN finlink
		ON finlink.idchild = incomeyear.idfin AND finlink.nlevel = @levelusable
	WHERE incomeyear.ayear = @ayear - 1
		AND ( (incometotal.flag & 1) = 1) -- Residuo
		AND income.nphase = @assessmentphasecode
	GROUP BY incomeyear.idupb, ISNULL(finlink.idparent,incomeyear.idfin) 

-- Variazione Residui Passivi 
	INSERT INTO #totvar_expenditure
	(
		idfin,
		idupb,
		amount
	)
	SELECT 
		ISNULL(finlink.idparent,expenseyear.idfin), 
		expenseyear.idupb,
		ISNULL(SUM(expensevar.amount), 0)
	FROM expensevar
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = expensevar.yvar
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	JOIN expensetotal
		ON expensetotal.idexp =	expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	LEFT OUTER JOIN finlink
		ON finlink.idchild = expenseyear.idfin AND finlink.nlevel = @levelusable
	WHERE expensevar.yvar = @ayear - 1
		AND ( (expensetotal.flag & 1) = 1) -- Residuo
		AND expense.nphase = @appropriationphasecode
		AND expensevar.adate <= @lastdayOY
	GROUP BY expenseyear.idupb, ISNULL(finlink.idparent,expenseyear.idfin)  

-- Variazione Residui Attivi		
	INSERT INTO #totvar_revenue
	(
		idfin,
		idupb,
		amount
	)
	SELECT 
		ISNULL(finlink.idparent,incomeyear.idfin),
		incomeyear.idupb,
		ISNULL(SUM(incomevar.amount), 0)
	FROM incomevar
	JOIN incomeyear
		ON incomeyear.idinc = incomevar.idinc
		AND incomeyear.ayear = incomevar.yvar
	JOIN income
		ON income.idinc = incomeyear.idinc
	JOIN incometotal
		ON incometotal.idinc =	incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN finlink
		ON finlink.idchild = incomeyear.idfin AND finlink.nlevel = @levelusable
	WHERE incomevar.yvar = @ayear - 1
		AND ( (incometotal.flag & 1) = 1) -- Residuo
		AND income.nphase = @assessmentphasecode
		AND incomevar.adate <= @lastdayOY
	GROUP BY incomeyear.idupb, ISNULL(finlink.idparent,incomeyear.idfin) 

-- Calcolo degli impegni di competenza
	INSERT INTO #impegni
	(
		idfin,
		idupb,
		amount
	)
	SELECT
		ISNULL(finlink.idparent,expenseyear.idfin), 
		expenseyear.idupb,
		ISNULL(SUM(expensetotal.curramount),0)
	FROM expensetotal
	JOIN expenseyear
		ON expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	LEFT OUTER JOIN finlink
		ON finlink.idchild = expenseyear.idfin AND finlink.nlevel = @levelusable
	WHERE expenseyear.ayear = @ayear - 1
		AND ( (expensetotal.flag & 1) = 0) -- Competenza
		AND expense.nphase = @appropriationphasecode
	GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin) 

-- Calcolo degli accertamenti di competenza
	INSERT INTO #accertamenti
	(
		idfin,
		idupb,
		amount
	)
	SELECT
		ISNULL(finlink.idparent,incomeyear.idfin),
		incomeyear.idupb,
		ISNULL(SUM(incometotal.curramount),0)
	FROM incometotal
	JOIN incomeyear
		ON incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear
	JOIN income
		ON income.idinc = incomeyear.idinc
	LEFT OUTER JOIN finlink
		ON finlink.idchild = incomeyear.idfin AND finlink.nlevel = @levelusable
	WHERE incomeyear.ayear = @ayear - 1
		AND ( (incometotal.flag & 1) = 0) -- Competenza
		AND income.nphase = @assessmentphasecode
	GROUP BY incomeyear.idupb, ISNULL(finlink.idparent,incomeyear.idfin) 


-- Calcolo dell'Assegnazione Crediti in uscita
	UPDATE #finbalance
	SET 
-- Calcola  Residui Attivi x le Spese sia x i fondi che x i non fondi,  ***   COME PRIMA    ***
-- xò solo x le Spese xkè x le entrate (solo fondi) saranno calcolati in modo speculare alle S
	revenue =
		ISNULL(totcredit,0)	
		+ ISNULL(
			(SELECT amount
			FROM #totinitial_expenditure
			WHERE #totinitial_expenditure.idupb = #finbalance.idupb AND #totinitial_expenditure.idfin = #finbalance.idfin)
			,0) 
		+ ISNULL(
			(SELECT 
			ISNULL(SUM(amount),0)
			FROM #totvar_expenditure
			WHERE #totvar_expenditure.idupb = #finbalance.idupb AND #totvar_expenditure.idfin = #finbalance.idfin)
			,0) 
		- ISNULL(totproceedspart,0) 
		- ISNULL(proceedsvariation,0)
	WHERE (finpart ='S')
	UPDATE #finbalance
	SET 
-- Calcola i Residui Attivi Effettivi in Entrata solo x i fondi, x i non fondi sarà 0 (Il calcolo è fatto speculare ai residui passivi)
-- serve  x calcolare il valore di assestamento che è fatto solo x i fondi
	revenue_E =
		ISNULL(
			(SELECT amount 
			FROM #totinitial_revenue 
			WHERE #finbalance.idupb = #totinitial_revenue.idupb AND #finbalance.idfin = #totinitial_revenue.idfin)
			,0) 
		+ ISNULL(
			(SELECT amount 
			FROM #totvar_revenue 
			WHERE #finbalance.idupb = #totvar_revenue.idupb AND #finbalance.idfin = #totvar_revenue.idfin),0) 
		+ ISNULL(
			(SELECT amount 
			FROM #accertamenti 
			WHERE #finbalance.idupb = #accertamenti.idupb AND #finbalance.idfin = #accertamenti.idfin),0) 
		- ISNULL(
			(SELECT amount 
			FROM #incassi_E
			WHERE #finbalance.idupb = #incassi_E.idupb AND #finbalance.idfin = #incassi_E.idfin),0)
	WHERE (finpart = 'E' and assured = 'N') 
-- Calcola i RP effettivi in spesa *** COME PRIMA ***
	UPDATE #finbalance
	SET 
	expenditure =
		ISNULL(
			(SELECT amount 
			FROM #totinitial_expenditure 
			WHERE #finbalance.idupb = #totinitial_expenditure.idupb AND #finbalance.idfin = #totinitial_expenditure.idfin)
			,0) 
		+ ISNULL(
			(SELECT amount 
			FROM #totvar_expenditure 
			WHERE #finbalance.idupb = #totvar_expenditure.idupb AND #finbalance.idfin = #totvar_expenditure.idfin),0) 
		+ ISNULL(
			(SELECT amount 
			FROM #impegni 
			WHERE #finbalance.idupb = #impegni.idupb AND #finbalance.idfin = #impegni.idfin),0) 
		- ISNULL(
			(SELECT amount 
			FROM #pagamenti 
			WHERE #finbalance.idupb = #pagamenti.idupb AND #finbalance.idfin = #pagamenti.idfin),0)
/* Calcolo dell'avanzo di amministrazione effettivo al 31/12 dell'esercizio precedente
	Avanzo Ammin. Effettivo = Avanzo Cassa Effettivo + Residui Attivi - Residui Passivi
	Residui Attivi = Residui Attivi all'1/1 + Residui Attivi Esercizio di Competenza
	Residui Passivi = Residui Passivi all'1/1 + Residui Passivi Esercizio di Competenza
*/
	UPDATE #finbalance
	SET actualcreditsurplus = 
		ISNULL(actualcashsurplus,0) 
		+ ISNULL(revenue,0) 
		- ISNULL(expenditure,0)
	WHERE (finpart = 'S')and (assured <>'S') -- x i fondi vale zero
END

IF (@fin_kind = 2) 
Begin
-- Per la Sola Cassa la Previsione Disponibile effettiva [@ayear-1] =  previsione effettiva[@ayear-1] - #pagamenti[@ayear-1] o #incassi_E[@ayear-1]
	UPDATE #finbalance
	SET 
	actualavailableprev = 	
				(SELECT SUM(ISNULL(currentprev,0)  + ISNULL(previsionvariation,0))
				FROM upbtotal UT	
				JOIN finlink FLK
					ON FLK.idchild = UT.idfin
				WHERE UT.idupb = #finbalance.idupb
				AND ISNULL(FLK.idparent,UT.idfin) = #finbalance.idfin
				)
			- ISNULL(
				(SELECT #pagamenti.amount FROM #pagamenti
				WHERE #pagamenti.idupb = #finbalance.idupb
					and #pagamenti.idfin = #finbalance.idfin
					and #finbalance.finpart = 'S'), 0)
			- ISNULL(
				(SELECT #incassi_E.amount FROM #incassi_E
				WHERE #incassi_E.idupb = #finbalance.idupb
					and #incassi_E.idfin = #finbalance.idfin
					and #finbalance.finpart = 'E'), 0),
	--sono i dettagli della formula ' Previsione Disponibile effettiva [@ayear-1]'
	actualprev = ISNULL((SELECT SUM(ISNULL(currentprev,0)  + ISNULL(previsionvariation,0))
				FROM upbtotal UT	
				JOIN finlink FLK
					ON FLK.idchild = UT.idfin
				WHERE UT.idupb = #finbalance.idupb
				AND ISNULL(FLK.idparent,UT.idfin) = #finbalance.idfin), 0),
	payment = ISNULL((SELECT #pagamenti.amount FROM #pagamenti
				WHERE #pagamenti.idupb = #finbalance.idupb
					and #pagamenti.idfin = #finbalance.idfin
					and #finbalance.finpart = 'S'), 0),
	proceeds = ISNULL((SELECT #incassi_E.amount FROM #incassi_E
				WHERE #incassi_E.idupb = #finbalance.idupb
					and #incassi_E.idfin = #finbalance.idfin
					and #finbalance.finpart = 'E'), 0)
	-- cassa in uscita: dot.cassa + ass.incassi anno prec
	UPDATE #finbalance
	SET
	assignedcash =	 proceedsvariation + ISNULL((SELECT amount 
					FROM #incassi 
					WHERE #finbalance.idupb = #incassi.idupb
					AND #finbalance.idfin = #incassi.idfin),0) 
	WHERE (finpart = 'S') and (assured <>'S') -- x i fondi vale zero
End
Else
Begin
-- Previsione Disponibile effettiva [@ayear-1] = previsione effettiva[@ayear-1] -  #impegni[@ayear-1] o #accertamenti[@ayear-1]
	UPDATE #finbalance
	SET 
	actualavailableprev = 	
				(SELECT SUM(ISNULL(currentprev,0)  + ISNULL(previsionvariation,0))
				FROM upbtotal UT	
				JOIN finlink FLK
					ON FLK.idchild = UT.idfin
				WHERE UT.idupb = #finbalance.idupb
				AND ISNULL(FLK.idparent,UT.idfin) = #finbalance.idfin
				)
			- ISNULL(
				(SELECT #impegni.amount FROM #impegni
				WHERE #impegni.idupb = #finbalance.idupb
					and #impegni.idfin = #finbalance.idfin
					and #finbalance.finpart = 'S'), 0)
			- ISNULL(
				(SELECT #accertamenti.amount FROM #accertamenti
				WHERE #accertamenti.idupb = #finbalance.idupb
					and #accertamenti.idfin = #finbalance.idfin
					and #finbalance.finpart = 'E'), 0),
	-- questi campi sono calcolati solo x un bil. di sola Cassa
	actualprev = 0,
	payment = 0,
	proceeds = 0,
	assignedcash = 0
End
-- Attualizzazione degli idfin all'esercizio corrente
UPDATE #finbalance
	SET idfin = 
		(SELECT newidfin  
		FROM finlookup 
		WHERE oldidfin = #finbalance.idfin)

UPDATE #finbalance
SET
	 supposedavailableprev = 
-- Previsione disponibile Presunta ufficiale
		ISNULL(
		(SELECT PFD.availableprevision 
		FROM prevfin PF 
		JOIN prevfindetail PFD 
			ON PF.ayear = PFD.ayear  
			AND PF.nprevfin = PFD.nprevfin  
		WHERE PF.official = 'S' AND PF.ayear = @ayear - 1
			AND PFD .idupb = #finbalance.idupb
			AND PFD .idfin = #finbalance.idfin)
		, 0.0),
--	passivi : expenditure
--	attivi : revenue
-- Residui Attivi Presunti ufficiali
	supposedrevenue = 
		ISNULL(
		(SELECT PFD.supposedrevenue 
		FROM prevfin PF 
		JOIN prevfindetail PFD 
			ON PF.ayear = PFD.ayear  
			AND PF.nprevfin = PFD.nprevfin  
		WHERE PF.official = 'S' AND PF.ayear = @ayear - 1
			AND PFD.idupb = #finbalance.idupb
			AND PFD.idfin = #finbalance.idfin
			)--AND #finbalance.finpart = 'E')
		, 0.0),
-- Residui Passivi Presunti ufficiali
	supposedexpenditure = 
		ISNULL(
		(SELECT PFD.supposedexpenditure 
		FROM prevfin PF 
		JOIN prevfindetail PFD 
			ON PF.ayear = PFD.ayear  
			AND PF.nprevfin = PFD.nprevfin  
		WHERE PF.official = 'S' AND PF.ayear = @ayear - 1
			AND PFD.idupb = #finbalance.idupb
			AND PFD.idfin = #finbalance.idfin
			)--AND #finbalance.finpart = 'S')
		, 0.0)

-- Attualizzazione degli idfin all'esercizio corrente
/*UPDATE #finbalance
	SET idfin = 
		(SELECT newidfin  
		FROM finlookup 
		WHERE oldidfin = #finbalance.idfin)
*/

-- CALCOLO ASSESTAMENTO
-- RIASSEGNAZIONE dei valori per l'esercizio corrente
SELECT 
	@fin_kind = ISNULL(fin_kind,0), 
	@assessmentphasecode = assessmentphasecode,
	@appropriationphasecode = appropriationphasecode
FROM config 
WHERE ayear = @ayear

-- Tabella della dotazione cassa presunta dell'esercizio corrente
CREATE TABLE #varcassapres(idfin int,idupb varchar(36),amount decimal(19,2))
-- Inserimento della somma delle dotazioni di cassa di ripartizione e assestamento
INSERT INTO #varcassapres(idfin,idupb,amount)
SELECT d.idfin,
	d.idupb,
	ISNULL(SUM(d.amount),0)
FROM finvardetail d
JOIN finvar v
	ON v.yvar = d.yvar
	AND v.nvar = d.nvar
WHERE v.yvar = @ayear
	AND v.flagproceeds='S'
	AND v.idfinvarstatus = 5
GROUP BY d.idupb,d.idfin



-- Tabella della dotazione crediti presunta dell'esercizio corrente
CREATE TABLE #varcreditipres(idfin int,idupb varchar(36),amount	decimal(19,2))
-- Inserimento della somma delle dotazioni di crediti di ripartizione e assestamento
INSERT INTO #varcreditipres(idfin,idupb,amount)
SELECT d.idfin,
	d.idupb,
	ISNULL(SUM(d.amount),0)
FROM finvardetail d
JOIN finvar v
	ON v.yvar = d.yvar
	AND v.nvar = d.nvar
WHERE v.yvar = @ayear
	AND v.flagcredit='S'
	AND v.idfinvarstatus = 5
GROUP BY d.idupb,d.idfin

 -- Totale Dotazione Crediti di Ripartizione Presunta
UPDATE #finbalance
SET supposedcredits =
		ISNULL(
		(SELECT #varcreditipres.amount 
		FROM #varcreditipres
		WHERE #varcreditipres.idupb = #finbalance.idupb
			AND #varcreditipres.idfin = #finbalance.idfin)
		, 0.0)
	WHERE (finpart = 'S')and (assured <>'S') -- Per i fondo non vanno calcolate la var. dot. crediti
-- Totale Dotazione Cassa di Ripartizione Presunta
UPDATE #finbalance
SET
	supposedproceeds =
		ISNULL(
		(SELECT #varcassapres.amount 
		FROM #varcassapres
		WHERE #varcassapres.idupb = #finbalance.idupb
		AND #varcassapres.idfin = #finbalance.idfin)
		, 0.0)
	WHERE (finpart = 'S')and (assured <>'S')  -- Per i fondi non vanno calcolate le var. dot. cassa
SELECT 
	A.finpart,		
	A.idupb,
	A.idfin,
	F.codefin,
	F.title as fin,
	ISNULL(supposedproceeds,0) AS supposedcash,  -- Var. Dot. Cassa
	ISNULL(supposedcredits,0) AS supposedcredits,    -- Var. Dot. Crediti
/*	Totale dei residui attivi dell'esercizio precedente : 
	x S = totcredit 
	+ RA anno precedente + var.RA anno precedente 
	 - var. dot.cassa - ass.cassa ;
	x E = residui attivi calcolati in E solo x i fondi				*/
	CASE WHEN (A.finpart = 'S') then ISNULL(revenue ,0)
	     WHEN (A.finpart = 'E') then ISNULL(revenue_E ,0)
	END 
	AS revenue,
/* 	Totale dei residui passivi dell'esercizio precedente = 
	RP anno precedente 
	+ var.RP anno precedente 
	+ impegni di C anno prec.
	- pagamenti di C anno prec.(in base alla config.bilancio)			*/
	ISNULL(expenditure,0) AS expenditure, 
	
-- Avanzo amm. = Fondo Cassa + RA - RP
	ISNULL(actualcreditsurplus,0) AS actualcreditsurplus,
/* 	FONDO CASSA = 
	proceedsvariation
	+ incassi anno prec(in base alla config.bilancio)
	- pagamenti anno prec(in base alla config.bilancio)				 */
	ISNULL(actualcashsurplus,0) AS actualcashsurplus,		
/*	Valore di assestamento = 
	Prev.disponibile Presunta ufficiale		
	+ Residui A/P Presunti ufficiali 
	- prev.disponibile attuale calcolata
	- Residui A/P effettivi 
*/
--	ISNULL(settlement,0) AS settlement, 
	ISNULL(actualavailableprev,0) AS actualavailableprev, 	 --> prev.disponibile attuale calcolata
	ISNULL(supposedavailableprev,0) AS supposedavailableprev,--> Prev.disponibile Presunta ufficiale
	ISNULL(supposedexpenditure,0) AS supposedexpenditure, 	 --> Residui Passivi Presunti ufficiali	
	ISNULL(supposedrevenue,0) AS supposedrevenue,		 --> Residui Attivi Presunti ufficiali	
/* 	I succ. 3 campi servono, x la sola cassa, per mostrare il calcolo della 
	Previsione Disponibile effettiva [@ayear-1] :
	previsione effettiva[@ayear-1] - #pagamenti[@ayear-1] o #incassi_E[@ayear-1]
*/
	isnull(actualprev,0)  as actualprev,	-->  previsione effettiva[@ayear-1]
	isnull(payment,0)  as payment, --> #pagamenti[@ayear-1]
	isnull(proceeds,0)  as proceeds, --> #incassi_E[@ayear-1]
	isnull(assignedcash,0) as assignedcash --> cassa in uscita: dot.cassa + ass.incassi anno prec
FROM #finbalance A
JOIN fin F 
	ON A.idfin= F.idfin
ORDER BY A.finpart,A.idupb,F.codefin ASC


END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

