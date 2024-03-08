
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


/* Versione 1.0.3 del 10/10/2007 ultima modifica: SARA */

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_startprevision]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_startprevision]
GO

--compute_startprevision 2008,'2008-10-15',3
--
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [compute_startprevision]
	@ayear int,
	@date datetime,
	@levelusable tinyint
AS
BEGIN

DECLARE @firstday datetime
SET 	@firstday = CONVERT(smalldatetime, '01-01-' + CONVERT(char(4), @ayear), 105)

DECLARE @lastday datetime
SET 	@lastday = CONVERT(smalldatetime, '31-12-' + CONVERT(char(4), @ayear), 105)

DECLARE @assessmentphasecode tinyint
SELECT 	@assessmentphasecode = assessmentphasecode FROM config WHERE ayear = @ayear

DECLARE @infoavanzo char(1)
SELECT 	@infoavanzo = paramvalue
FROM 	generalreportparameter
WHERE 	idparam = 'MostraAvanzo'

-- Ricerca la fase equivalente all'impegno se è stata inserita nella tabella di configurazione  del bilancio
DECLARE @phasebilancio tinyint
SELECT  @phasebilancio = appropriationphasecode
FROM 	config
WHERE 	ayear = @ayear
-- Se non è stata inserita nella tabella di configurazione  ipotizza che si tratti della fase dove viene identificata  la voce di bilancio
IF (@phasebilancio IS NULL)
BEGIN
	SELECT 	@phasebilancio = expensefinphase FROM uniconfig 
END
--print @phasebilancio
-- Se @fin_kind = 1 ==> è stata personalizzata una previsione principale di tipo "competenza", se @fin_kind = 2
-- ==> è stata personalizzata una previsione principale di tipo "cassa", se  @fin_kind = 3 ==> è stata personalizzata una
-- previsione principale di tipo "altra previsione". 

DECLARE @fin_kind tinyint
SELECT 	@fin_kind = ISNULL(fin_kind,0) FROM config WHERE ayear = @ayear

-- Alla stregua della compute_transf_prevision, quando:
-- 1)capitolo 2008 è articolato 
-- 2)capitolo 2009 non è articolato
-- si può spezzare il legame capitolo 2008-2009 in #finlookup

CREATE TABLE #finlookup(
        oldidfin	int,-- ayear
        newidfin	int -- ayear +1
)
INSERT INTO #finlookup(oldidfin,newidfin)
SELECT oldidfin,newidfin
FROM finlookup
JOIN fin
        ON finlookup.oldidfin = fin.idfin
WHERE fin.ayear = @ayear
-- Cancella il capitolo articolato nel 2008, e dearticolato nel 2009.
DELETE FROM #finlookup WHERE EXISTS ( select * from fin where fin.paridfin = #finlookup.oldidfin )--è parent nel  2008
                                AND NOT EXISTS ( select * from fin where fin.paridfin = #finlookup.newidfin )-- non è parent nel 2009

CREATE TABLE #bilprevision
(
	--totcreditpart decimal(19,2),
	finpart 		char (1),
	idupb 			varchar(36),
	assured 		char (1),
	idfin 			int,
	paridfin int,
	nlevel tinyint,
	thisyearprevision 	decimal (19,2),	-- (non va in output)
	thisyearsecondaryprevision decimal (19,2),	-- prev. secondaria di finyear(non va in output)
	prevision 		decimal(19,2),	-- pura prev. comp. 
	availableprevision	decimal(19,2),	-- prev. disponibile di quest''anno x Entrate e Spese,
        availableprevision_secondary decimal(19,2),-- prev. disponibile secondaria di quest'anno x Entrate e Spese,
        availableprevision_onlycash decimal(19,2),--  prev. disponibile per un bilancio di SOLA cassa di quest'anno x Entrate e Spese,
	--prevision2 decimal(19,2), 	
	--prevision3 decimal(19,2),	
	--prevision4 decimal(19,2),	
	--prevision5 decimal(19,2),
	previousprevision 	decimal (19,2),
	previoussecondaryprev 	decimal (19,2),
	previousarrears 	decimal (19,2)
	--proceedsvariation decimal(19,2)--, -- Dotazione Cassa
	--floatfund decimal(19,2), -- Fondo Cassa alla data di redazione del bilancio di previsione
	--supposedproceeds decimal(19,2), -- Incassi Presunti al 31/12
	--supposedpayments decimal(19,2), -- Pagamenti Presunti al 31/12
	--supposedrevenue decimal(19,2), -- Residui Attivi Presunti al 31/12	SERVONO  X IL CALCOLO DELLA PREV DI CASSA, SE SI TRATTA DI SPESA SARà ZERO
	--supposedexpenditure decimal(19,2) -- Residui Passivi Presunti al 31/12	SERVONO X IL CALCOLO DELLA PREV DI CASSA, SE SI TRATTA DI ENTRATA SARà ZERO
)

INSERT INTO #bilprevision
(
	finpart,
	idfin,
	idupb,
	paridfin,
	nlevel,
	thisyearprevision,
        thisyearsecondaryprevision,
	assured,
	prevision,
	previousprevision,
	previoussecondaryprev,
	previousarrears  
)
SELECT 
	CASE
		WHEN ((F_NEW.flag&1)=0) THEN 'E'
		WHEN ((F_NEW.flag&1)=1) THEN 'S'
	END,	
	F_NEW.idfin, 
	u.idupb,
	F_NEW.paridfin,
	F_NEW.nlevel,
	ISNULL(SUM(finyear.prevision),0), -- è sempre la principale
	ISNULL(SUM(finyear.secondaryprev),0), -- è sempre la secondaria
	u.assured,	
	0,
	ISNULL(SUM(finyear.prevision),0), 
	ISNULL(SUM(finyear.secondaryprev),0),
	ISNULL(SUM(finyear.currentarrears),0)		
FROM finyear 
JOIN fin f 
        ON f.idfin = finyear.idfin
JOIN upb u 
        ON u.idupb = finyear.idupb
JOIN #finlookup FK 
        ON FK.oldidfin = f.idfin 
JOIN fin F_NEW
         ON F_NEW.idfin = FK.newidfin
WHERE  f.ayear = @ayear
	AND ( (
		((f.flag&1)=0) --Entrata
		AND (@infoavanzo <> 'S' OR  (f.flag & 16 =0)))
		OR (((f.flag&1)=1)) --Spesa
	)
GROUP BY F_NEW.idfin, u.idupb,u.assured,
        F_NEW.paridfin, F_NEW.flag,F_NEW.nlevel

INSERT INTO #bilprevision
(
	finpart,
	idfin,
	idupb,
	paridfin,
	nlevel,
	thisyearprevision,
        thisyearsecondaryprevision,
	assured,
	prevision,
	previousprevision,
	previoussecondaryprev,
	previousarrears  
)
SELECT  distinct
	CASE
		WHEN ((F_NEW.flag&1)=0) THEN 'E'
		WHEN ((F_NEW.flag&1)=1) THEN 'S'
	END,	
	F_NEW.idfin, 
	u.idupb,
	F_NEW.paridfin, --> new paridfin
	F_NEW.nlevel,
	0, -- è sempre la principale
	0, -- è sempre la secondaria
	u.assured,	
	0,
	0, 
	0,
	0		
FROM    incomeyear IY
join fin f  
        on f.idfin=IY.idfin
join upb u  
        on u.idupb=IY.idupb
JOIN #finlookup FK 
        ON FK.oldidfin = f.idfin 
JOIN fin F_NEW
         ON F_NEW.idfin = FK.newidfin
WHERE  f.ayear = @ayear and iy.ayear=@ayear 	
	AND (@infoavanzo <> 'S' OR (f.flag & 16 =0))	
	AND NOT EXISTS (select * from #bilprevision where  #bilprevision.idfin=F_NEW.idfin and #bilprevision.idupb=IY.idupb)

INSERT INTO #bilprevision
(
	finpart,
	idfin,
	idupb,
	paridfin,
	nlevel,
	thisyearprevision,
        thisyearsecondaryprevision,
	assured,
	prevision,
	previousprevision,
	previoussecondaryprev,
	previousarrears  
)
SELECT DISTINCT
	CASE
		WHEN ((F_NEW.flag&1)=0) THEN 'E'
		WHEN ((F_NEW.flag&1)=1) THEN 'S'
	END,	
	F_NEW.idfin, 
	u.idupb,
	F_NEW.paridfin, --> new paridfin
	F_NEW.nlevel,
	0, -- è sempre la principale
	0, -- è sempre la secondaria
	u.assured,	
	0,
	0, 
	0,
	0		
FROM    expenseyear IY
join fin f  
        on f.idfin=IY.idfin
join upb u  
        on u.idupb=IY.idupb
JOIN #finlookup FK 
        ON FK.oldidfin = f.idfin 
JOIN fin F_NEW
         ON F_NEW.idfin = FK.newidfin
WHERE  f.ayear = @ayear and iy.ayear=@ayear 	
	AND NOT EXISTS (select * from #bilprevision where  #bilprevision.idfin=F_NEW.idfin and #bilprevision.idupb=IY.idupb)


-- VARIAZIONI DI BILANCIO della previsione principale
CREATE TABLE #tot_varprev (idfin int, idupb varchar(36), total decimal(19,2))
INSERT INTO #tot_varprev
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent, FK.newidfin),
	FVD.idupb,
	SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV 
	ON  FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN #finlookup FK 
        ON FK.oldidfin = FVD.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
GROUP BY FVD.idupb,ISNULL(finlink.idparent, FK.newidfin)

-- VARIAZIONI DI BILANCIO della previsione secondaria
CREATE TABLE #tot_varsecondaryprev (idfin int, idupb varchar(36), total decimal(19,2))
INSERT INTO #tot_varsecondaryprev
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent, FK.newidfin),
	FVD.idupb,
	SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV 
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN #finlookup FK 
        ON FK.oldidfin = FVD.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
GROUP BY FVD.idupb,ISNULL(finlink.idparent, FK.newidfin)


--Per questi due campi in un bilancio di sola cassa la previoussecondaryprev non sarà valorizzata 
-- controllare nel form se è giusto così
UPDATE #bilprevision
SET 
	previousprevision =  ISNULL(previousprevision,0) 
				+ 
				ISNULL(
					(SELECT sum(#tot_varprev.total) 
					   FROM #tot_varprev
					LEFT OUTER JOIN  finlink
						ON finlink.idchild = #tot_varprev.idfin 
					  WHERE #tot_varprev.idupb = #bilprevision.idupb
					AND ISNULL(finlink.idparent, #tot_varprev.idfin) = #bilprevision.idfin), 0),
	
	previoussecondaryprev =  ISNULL(previoussecondaryprev,0) 
				+ 
				ISNULL(
					(SELECT sum(#tot_varsecondaryprev.total)
					   FROM #tot_varsecondaryprev
					LEFT OUTER JOIN  finlink
						ON finlink.idchild = #tot_varsecondaryprev.idfin
					  WHERE #tot_varsecondaryprev.idupb = #bilprevision.idupb
					AND ISNULL(finlink.idparent,#tot_varsecondaryprev.idfin) = #bilprevision.idfin), 0)

DECLARE @nextayear int
SET 	@nextayear = @ayear + 1

-- Procedura che imposta il valore dei capitoli articolati pari alla somma degli articoli
-- in particolare sta prendendo i capitoli degli articoli, se non esistono nella tabella.
-- Per esempio se ho fatto solo un mov. di spesa sull'articolo, lo troverò SOLO in expenseyear
-- quindi in #bilprevision troverò SOLO l'articolo. Questo ciclo serve ad inserisce anche il relativo capitolo
-- per poterlo totalizzare.
DECLARE @minlivop tinyint
DECLARE @maxlivop tinyint

SELECT @minlivop = isnull(MIN(nlevel),1) FROM finlevel WHERE flag&2 <> 0 AND ayear = @nextayear
SELECT @maxlivop = MAX(nlevel) FROM finlevel WHERE ayear = @nextayear

DECLARE @liv tinyint
SET @liv = @maxlivop - 1
WHILE (@liv >= @minlivop)
BEGIN
-- @liv = 3
-- @childlevel = 4
	DECLARE @childlevel tinyint
	SET @childlevel = @liv + 1


	INSERT INTO #bilprevision
	(
		idupb, 
		idfin, 
		paridfin,
		nlevel,
                prevision,	
                availableprevision,
                availableprevision_secondary,
                availableprevision_onlycash,
                previousprevision, 
                previoussecondaryprev,
                previousarrears
	)

	SELECT DISTINCT
		CHILD.idupb, 
		CHILD.paridfin, 
		finlink.idparent, 
		@liv,
		0,0,0,0,0,
                0,0
	FROM #bilprevision CHILD
	JOIN finlink
		ON finlink.idchild = CHILD.idfin
		AND finlink.nlevel = @liv
	WHERE CHILD.nlevel = @childlevel
		AND NOT EXISTS
		(SELECT * FROM #bilprevision PARENT
		WHERE PARENT.idfin = CHILD.paridfin
			AND PARENT.idupb = CHILD.idupb)

	UPDATE #bilprevision
	SET 
                prevision = 
        	ISNULL(
        		(SELECT SUM(prevision) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),
                availableprevision = 
        	ISNULL(
        		(SELECT SUM(availableprevision) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),
                availableprevision_secondary = 
        	ISNULL(
        		(SELECT SUM(availableprevision_secondary) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),
                availableprevision_onlycash = 
        	ISNULL(
        		(SELECT SUM(availableprevision_onlycash) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),
                previousprevision = 
        	ISNULL(
        		(SELECT SUM(previousprevision) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),
        	previoussecondaryprev = 
        	ISNULL(
        		(SELECT SUM(previoussecondaryprev) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin
        		AND child.idupb = #bilprevision.idupb)
        	,0),
        	previousarrears = 
        	ISNULL(
        		(SELECT SUM(previousarrears) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin
        		AND child.idupb = #bilprevision.idupb)
        	,0)

	WHERE #bilprevision.nlevel = @liv
	AND EXISTS(SELECT * FROM #bilprevision b2 WHERE b2.paridfin = #bilprevision.idfin)
	
	SET @liv = @liv - 1
END

IF ((@fin_kind = 1) OR (@fin_kind = 3))
BEGIN
	SELECT 
		#bilprevision.finpart,		
		newfin.codefin,			
		newfin.title as fin, 		
		#bilprevision.idupb,	
		newfin.idfin as idfin,	
		0 as floatfund, 		-- Fondo di Cassa alla Data. (Per i FONDI è zero)
		0 as supposedproceeds,		-- INCASSI PRESUNTI alla data(RIMANE) servono x le Entrate
		0 as supposedpayments,		-- PAGAMENTI PRESUNTI alla data (RIMANE)
		0 as supposedrevenue,		-- Residui Attivi Presunti al 31/12
		0 as supposedexpenditure,	-- Residui Passivi Presunti al 31/12
		
	-- Pura Prev. Comp.
		0 AS competency,
                -- Prev. Cassa = finyear.prevision2 + prev.disponibile secondaria, ossia di cassa. 
		0  AS cash,
	-- Prev. Disponibile di quest''anno x E,
		0  as availableprevision,
		ISNULL(sum(previousprevision),0) AS previousprevision, 
		ISNULL(sum(previoussecondaryprev),0) AS previoussecondaryprev,
		ISNULL(sum(previousarrears),0) AS previousarrears,
		0 as prevision2, 	
		0 as prevision3, 		
		0 as prevision4, 	
		0 as prevision5	
	FROM #bilprevision
	JOIN fin newfin
                ON newfin.idfin= #bilprevision.idfin
	GROUP BY newfin.idfin,
		newfin.codefin,newfin.title,#bilprevision.finpart,#bilprevision.idupb,
		#bilprevision.assured
END

IF (@fin_kind = 2)
BEGIN
	SELECT 
		#bilprevision.finpart,		
		newfin.codefin,			
		newfin.title as fin, 		
		#bilprevision.idupb,	
		newfin.idfin as idfin,			
		0 as floatfund, 		-- Fondo di Cassa alla Data. (Per i FONDI è zero)
		0 as supposedproceeds,		-- INCASSI PRESUNTI alla data(RIMANE) servono x le E
		0 as supposedpayments,		-- PAGAMENTI PRESUNTI alla data (RIMANE)
		0 as supposedrevenue,		-- Residui Attivi Presunti al 31/12
		0 as supposedexpenditure,	-- Residui Passivi Presunti al 31/12
	
	-- Previsione di cassa(in un bilancio di competenza è la Pura Prev. Comp.)
		0 	AS competency,
                -- Prev. Cassa = finyear.prevision2 + prev.disponibile principale. 
		0       AS cash,
	-- Prev. Disponibile di quest''anno x E,
		0       as availableprevision,
		ISNULL(sum(previousprevision),0) AS previousprevision, 
		0 	AS previoussecondaryprev,

		ISNULL(sum(previousarrears),0) AS previousarrears,
		0 as prevision2, 	
		0 as prevision3, 		
		0 as prevision4, 	
		0 as prevision5	
	FROM #bilprevision
	JOIN fin newfin
                ON newfin.idfin= #bilprevision.idfin
	GROUP BY newfin.idfin,
		newfin.codefin,newfin.title,#bilprevision.finpart,#bilprevision.idupb,
		#bilprevision.assured
END

END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

