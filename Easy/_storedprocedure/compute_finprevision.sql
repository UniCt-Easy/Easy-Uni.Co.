
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_finprevision]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_finprevision]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [compute_finprevision]
	@ayear int,
	@date datetime,
	@levelusable tinyint
AS
BEGIN
DECLARE @data varchar(13)
SELECT 	@data = CONVERT(varchar(20),@date,5)
DECLARE @firstday datetime
SET 	@firstday = CONVERT(smalldatetime, '01-01-' + CONVERT(char(4), @ayear), 105)
DECLARE @lastday datetime
SET 	@lastday = CONVERT(smalldatetime, '31-12-' + CONVERT(char(4), @ayear), 105)
DECLARE @assessmentphasecode int
SELECT 	@assessmentphasecode = assessmentphasecode FROM config WHERE ayear = @ayear
DECLARE @appropriationphasecode int
SELECT 	@appropriationphasecode = appropriationphasecode FROM config WHERE ayear = @ayear
DECLARE @maxexpensephase int
SELECT 	@maxexpensephase =  MAX(nphase) FROM expensephase
DECLARE @maxincomephase int
SELECT 	@maxincomephase = MAX(nphase) FROM incomephase

DECLARE @infoavanzo char(1)
SELECT 	@infoavanzo = paramvalue
FROM 	generalreportparameter
WHERE 	idparam = 'MostraAvanzo'

-- Ricerca la fase equivalente all'impegno se è stata inserita nella tabella di configurazione  del bilancio
DECLARE @phasebilancio tinyint
SELECT 	@phasebilancio = appropriationphasecode
FROM config
WHERE ayear = @ayear
-- Se non è stata inserita nella tabella di configurazione  ipotizza che si tratti della fase dove viene identificata  la voce di bilancio
IF (@phasebilancio IS NULL)
BEGIN
	SELECT 	@phasebilancio = expensefinphase FROM uniconfig 
END

-- Se @fin_kind = 1 ==> è stata personalizzata una previsione principale di tipo "competenza", se @fin_kind = 2
-- ==> è stata personalizzata una previsione principale di tipo "cassa", se  @fin_kind = 3 ==> è stata personalizzata una
-- previsione principale di tipo "altra previsione". 

DECLARE @fin_kind tinyint
SELECT @fin_kind = ISNULL(fin_kind ,0) FROM config WHERE ayear = @ayear



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
	totcreditpart decimal(19,2),
	finpart char (1),
	idupb varchar(36),
	assured char (1),
	idfin int,
	paridfin int,
        nlevel tinyint,
	thisyearprevision decimal (19,2),	        -- prev. principale di finyear(non va in output)
	thisyearsecondaryprevision decimal (19,2),	-- prev. secondaria di finyear(non va in output)
	prevision decimal(19,2),		-- pura prev. comp. 
	availableprevision decimal(19,2),	-- prev. disponibile principale di quest'anno x Entrate e Spesa,
        availableprevision_secondary decimal(19,2),-- prev. disponibile secondaria di quest'anno x Entrate e Spesa,
        availableprevision_onlycash decimal(19,2),--  prev. disponibile per un bilancio di SOLA cassa di quest'anno x Entrate e Spesa,
	prevision2 decimal(19,2), 	
	prevision3 decimal(19,2),	
	prevision4 decimal(19,2),	
	prevision5 decimal(19,2),
	previousprevision decimal (19,2),
	previoussecondaryprev decimal (19,2),
	previousarrears decimal (19,2),
	proceedsvariation decimal(19,2), -- Dotazione Cassa
	floatfund decimal(19,2), -- Fondo Cassa alla data di redazione del bilancio di previsione
	supposedproceeds decimal(19,2), -- Incassi Presunti al 31/12
	supposedpayments decimal(19,2), -- Pagamenti Presunti al 31/12
	supposedrevenue decimal(19,2), -- Residui Attivi Presunti al 31/12	SERVONO  X IL CALCOLO DELLA PREV DI CASSA, SE è Spesa SARà ZERO
	supposedexpenditure decimal(19,2) -- Residui Passivi Presunti al 31/12	SERVONO X IL CALCOLO DELLA PREV DI CASSA, SE è Entrata SARà ZERO
)

INSERT INTO #bilprevision
(
	finpart,
	idfin,paridfin,
        nlevel,
	idupb,
	thisyearprevision,
        thisyearsecondaryprevision,
	assured,
	prevision,
	prevision2,
	prevision3,
	prevision4, 
	prevision5,
	previousprevision,
	previoussecondaryprev,
	previousarrears  
)
SELECT 
	CASE
		WHEN ((F_NEW.flag&1)=1) THEN 'S'	
		WHEN ((F_NEW.flag&1)=0) THEN 'E'
	END,
	F_NEW.idfin,F_NEW.paridfin,
        F_NEW.nlevel,
	u.idupb,
	ISNULL(SUM(finyear.prevision),0), -- è sempre la principale 
	ISNULL(SUM(finyear.secondaryprev),0), -- è sempre la secondaria
	u.assured,	
	ISNULL(SUM(finyear.prevision2),0),
	ISNULL(SUM(finyear.prevision3),0), 
	ISNULL(SUM(finyear.prevision4),0),
	ISNULL(SUM(finyear.prevision5),0),
	0,
	ISNULL(SUM(finyear.prevision),0), 
	ISNULL(SUM(finyear.secondaryprev),0),
	ISNULL(SUM(finyear.currentarrears),0)		
FROM finyear 
JOIN fin f 
        ON f.idfin = finyear.idfin
JOIN upb u 
        ON u.idupb= finyear.idupb
JOIN #finlookup FK 
        ON FK.oldidfin = f.idfin 
JOIN fin F_NEW
         ON F_NEW.idfin = FK.newidfin
WHERE  f.ayear = @ayear
	AND ((((f.flag&1)=0) --Entrata
	AND (@infoavanzo <> 'S' OR (F.flag & 16 =0)))
		OR ((f.flag&1)=1) --Spesa
	)
GROUP BY F_NEW.idfin,F_NEW.paridfin,U.idupb,F_NEW.nlevel,
        F_NEW.flag,u.assured

INSERT INTO #bilprevision
(
	finpart,
	idfin,paridfin,
        nlevel,
	idupb,
	thisyearprevision,
        thisyearsecondaryprevision,
	assured,
	prevision,
	prevision2,
	prevision3,
	prevision4, 
	prevision5,
	previousprevision,
	previoussecondaryprev,
	previousarrears  
)
SELECT  distinct
	CASE
		WHEN ((F_NEW.flag&1)=1) THEN 'S'	
		WHEN ((F_NEW.flag&1)=0) THEN 'E'	
	END,	
	F_NEW.idfin,F_NEW.paridfin, 
        F_NEW.nlevel,
	u.idupb,
	0, -- è sempre la principale
	0, -- è sempre la secondaria
	u.assured,	
	0,
	0,
	0,
	0,
	0,
	0, 
	0,
	0		
FROM    incomeyear IY
JOIN fin f  
        on f.idfin=IY.idfin
JOIN upb u  
        on u.idupb=IY.idupb
JOIN #finlookup FK 
        ON FK.oldidfin = f.idfin 
JOIN fin F_NEW
         ON F_NEW.idfin = FK.newidfin
WHERE   f.ayear = @ayear and iy.ayear=@ayear 	
	AND (@infoavanzo <> 'S' OR (F.flag & 16 =0))	
	AND NOT EXISTS (select * from #bilprevision 
			where  	#bilprevision.idfin=F_NEW.idfin 
			and 	#bilprevision.idupb=IY.idupb)


INSERT INTO #bilprevision
(
	finpart,
	idfin,paridfin,
        nlevel,
	idupb,
	thisyearprevision,
        thisyearsecondaryprevision,
	assured,
	prevision,
	prevision2,
	prevision3,
	prevision4, 
	prevision5,
	previousprevision,
	previoussecondaryprev,
	previousarrears  
)
SELECT DISTINCT
	CASE
		WHEN ((F_NEW.flag&1)=1) THEN 'S'	
		WHEN ((F_NEW.flag&1)=0) THEN 'E'	
	END,	
	F_NEW.idfin, F_NEW.paridfin,
        F_NEW.nlevel,
	u.idupb,
	0, -- è sempre la principale
	0, -- è sempre la secondaria
	u.assured,	
	0,
	0,
	0,
	0,
	0,
	0, 
	0,
	0		
FROM    expenseyear IY
JOIN fin f  
        on f.idfin=IY.idfin
JOIN upb u  
        on u.idupb=IY.idupb
JOIN #finlookup FK 
        ON FK.oldidfin = f.idfin 
JOIN fin F_NEW
         ON F_NEW.idfin = FK.newidfin
WHERE   f.ayear = @ayear AND iy.ayear=@ayear 	
	AND NOT EXISTS (select * from #bilprevision 
			where  #bilprevision.idfin=F_NEW.idfin 
			and #bilprevision.idupb=IY.idupb)

UPDATE #bilprevision 
SET 
	totcreditpart =		
		(SELECT SUM(ISNULL(UT.totcreditpart,0)  + ISNULL(UT.creditvariation,0)) 
		FROM upbtotal UT	
                JOIN #finlookup FK 
                        ON FK.oldidfin = UT.idfin 
		LEFT OUTER JOIN  finlink 
                        ON finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
		WHERE UT.idupb = #bilprevision.idupb
		AND ISNULL(finlink.idparent,FK.newidfin) = #bilprevision.idfin
		),
	proceedsvariation =
		(SELECT SUM(UT.proceedsvariation) 
		FROM upbtotal UT	
                JOIN #finlookup FK 
                        ON FK.oldidfin = UT.idfin 
		LEFT OUTER JOIN  finlink 
                        ON finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
		WHERE UT.idupb = #bilprevision.idupb
		AND ISNULL(finlink.idparent,FK.newidfin) = #bilprevision.idfin
		)

-- VARIAZIONI DI BILANCIO della previsione principale
CREATE TABLE #tot_varprev (idfin int, idupb varchar(36), total decimal(19,2))
INSERT INTO #tot_varprev
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
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
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
GROUP BY FVD.idupb,ISNULL(finlink.idparent,FK.newidfin)

-- VARIAZIONI DI BILANCIO della previsione secondaria
CREATE TABLE #tot_varsecondaryprev (idfin int, idupb varchar(36), total decimal(19,2))
INSERT INTO  #tot_varsecondaryprev
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
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
GROUP BY FVD.idupb,ISNULL(finlink.idparent,FK.newidfin)

-- Assegnazione degli Incassi Trasmessi prima della data 
CREATE TABLE #proceedstransmitted(idupb varchar(36),idfin int,total decimal(19,2) )
INSERT INTO #proceedstransmitted
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	proceedscommunicated.idupb,
	SUM(ISNULL(proceedspart.amount,0))
FROM proceedspart
JOIN proceedscommunicated
	ON proceedspart.idinc = proceedscommunicated.idinc
	AND proceedspart.yproceedspart = proceedscommunicated.ymov
JOIN #finlookup FK 
        ON FK.oldidfin = proceedspart.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE proceedscommunicated.ymov = @ayear
	AND (proceedscommunicated.competencydate >= @firstday AND proceedscommunicated.competencydate <= @date)
GROUP BY proceedscommunicated.idupb,ISNULL(finlink.idparent,FK.newidfin)
--select count(*) from #bilprevision

-- Importo attuale dei Residui Passivi al 1/1/
CREATE TABLE #totexpenditure(idupb varchar(36),idfin int, total decimal(19,2))
INSERT INTO #totexpenditure
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	expenseyear.idupb,
	SUM(ISNULL(expensetotal.curramount,0))
FROM expensetotal
JOIN expenseyear
	ON expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN expense 
	ON expense.idexp = expenseyear.idexp
JOIN #finlookup FK 
        ON FK.oldidfin = expenseyear.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE expenseyear.ayear = @ayear
	AND ((expensetotal.flag&1)=1) --=Residuo
	AND expense.nphase = @appropriationphasecode
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,FK.newidfin)


-- Mandati Trasmessi prima della data
CREATE TABLE #paymenttransmitted(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO  #paymenttransmitted
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	paymentcommunicated.idupb,
	SUM(ISNULL(expensetotal.curramount,0))
FROM expensetotal
JOIN paymentcommunicated
	ON expensetotal.idexp = paymentcommunicated.idexp
	AND expensetotal.ayear = paymentcommunicated.ymov
JOIN #finlookup FK 
        ON FK.oldidfin = paymentcommunicated.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE expensetotal.ayear = @ayear
	AND (paymentcommunicated.competencydate >= @firstday AND paymentcommunicated.competencydate <= @date)
GROUP BY paymentcommunicated.idupb, ISNULL(finlink.idparent,FK.newidfin)


-- Pagamenti trasmessi dopo la data della redazione del bilancio di previsione, quindi sono i presunti al 31/12, sa
CREATE TABLE #latecommunicated_payment(idupb varchar(36), idfin int, total decimal(19,2))
INSERT INTO  #latecommunicated_payment
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	paymentcommunicated.idupb,
	SUM(ISNULL(expensetotal.curramount,0))
FROM expensetotal
JOIN paymentcommunicated
	ON expensetotal.idexp = paymentcommunicated.idexp
	AND expensetotal.ayear = paymentcommunicated.ymov
JOIN #finlookup FK 
        ON FK.oldidfin = paymentcommunicated.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE expensetotal.ayear = @ayear
	AND (paymentcommunicated.competencydate > @date AND paymentcommunicated.competencydate <= @lastday)
GROUP BY paymentcommunicated.idupb,ISNULL(finlink.idparent,FK.newidfin)

-- Pagamenti senza mandato
CREATE TABLE #withoutdoc_payment(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO #withoutdoc_payment
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	expenseyear.idupb,
	SUM(ISNULL(expensetotal.curramount,0))
FROM expensetotal
JOIN expenseyear
	ON expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN expenselast
	ON expenselast.idexp = expense.idexp
JOIN #finlookup FK 
        ON FK.oldidfin = expenseyear.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE expenseyear.ayear = @ayear
	AND expenselast.kpay IS NULL
GROUP BY expenseyear.idupb, ISNULL(finlink.idparent,FK.newidfin)

-- Pagamenti non trasmessi
CREATE TABLE #uncommunicated_payment(idupb varchar(36) ,idfin int, total decimal(19,2))
INSERT INTO #uncommunicated_payment
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	paymentemitted.idupb,
	SUM(ISNULL(expensetotal.curramount,0))
FROM expensetotal
JOIN paymentemitted
	ON expensetotal.idexp = paymentemitted.idexp
	AND expensetotal.ayear = paymentemitted.ymov
JOIN #finlookup FK 
        ON FK.oldidfin = paymentemitted.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE paymentemitted.ymov = @ayear
	AND paymentemitted.idexp NOT IN 
		(SELECT paymentcommunicated.idexp 
		FROM paymentcommunicated
		WHERE ymov = @ayear)
GROUP BY paymentemitted.idupb, ISNULL(finlink.idparent,FK.newidfin)

-- Importo attuale dei Residui Attivi al 01/01
CREATE TABLE #totrevenue(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO #totrevenue
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	incomeyear.idupb,
	SUM(ISNULL(incometotal.curramount,0))
FROM incometotal
JOIN incomeyear
	ON incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear
JOIN income
	ON income.idinc = incomeyear.idinc
JOIN #finlookup FK 
        ON FK.oldidfin = incomeyear.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE incomeyear.ayear = @ayear
	AND ((incometotal.flag&1)=1) --=Residuo
	AND income.nphase = @assessmentphasecode
GROUP BY incomeyear.idupb, ISNULL(finlink.idparent,FK.newidfin)


--	Accertamenti effettuati nell'anno
CREATE TABLE #yearassessment(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO #yearassessment
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	incomeyear.idupb,
	SUM(ISNULL(incometotal.curramount,0))
FROM incometotal
JOIN incomeyear
	ON incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear
JOIN income
	ON incomeyear.idinc = income.idinc
JOIN #finlookup FK 
        ON FK.oldidfin = incomeyear.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE incomeyear.ayear = @ayear
	AND income.nphase = @assessmentphasecode
	AND ((incometotal.flag&1)=0) --=Competenza
GROUP BY incomeyear.idupb, ISNULL(finlink.idparent,FK.newidfin)


--	Accertamenti effettuati nell'anno alla data
CREATE TABLE #yearassessmentstilldate(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO #yearassessmentstilldate
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	incomeyear.idupb,
	SUM(ISNULL(incometotal.curramount,0))
FROM incometotal
JOIN incomeyear
	ON incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear
JOIN income
	ON incomeyear.idinc = income.idinc
JOIN #finlookup FK 
        ON FK.oldidfin = incomeyear.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE incomeyear.ayear = @ayear
	AND income.nphase = @assessmentphasecode
	AND ( (((incometotal.flag&1)=0) and @fin_kind IN (1,3))
		  or (@fin_kind = 2))
	and income.adate <= @date
GROUP BY incomeyear.idupb,ISNULL(finlink.idparent,FK.newidfin)

--	Reversali effettuate su residui attivi al 01/01
CREATE TABLE #expenditureproceeds(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO #expenditureproceeds
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	incomeyear.idupb,
	SUM(ISNULL(incometotal.curramount,0))
FROM incometotal
JOIN incomeyear
	ON incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear
JOIN income
	ON incomeyear.idinc = income.idinc
JOIN #finlookup FK 
        ON FK.oldidfin = incomeyear.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE incomeyear.ayear = @ayear
	AND income.nphase = @maxincomephase
	AND ((incometotal.flag&1)=1) --=Residuo
GROUP BY incomeyear.idupb, ISNULL(finlink.idparent,FK.newidfin)


--	Reversali effettuate su Accertamenti effettuati nell'anno corrente, ovvero quelli di Competenza
CREATE TABLE #yearproceeds(idupb varchar(36), idfin int, total decimal(19,2))	
INSERT INTO #yearproceeds
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	incomeyear.idupb,
	SUM(ISNULL(incometotal.curramount,0))
FROM incometotal
JOIN incomeyear
	ON incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear
JOIN income
	ON incomeyear.idinc = income.idinc
JOIN #finlookup FK 
        ON FK.oldidfin = incomeyear.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE incomeyear.ayear = @ayear
	AND income.nphase = @maxincomephase
	AND ((incometotal.flag&1)=0) --=Competenza
GROUP BY incomeyear.idupb, ISNULL(finlink.idparent,FK.newidfin)


--  Impegni con data scadenza con data di scadenza entro l'anno, ovvero Impegni con scadenza
CREATE TABLE #withexpiration_appropriation(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO  #withexpiration_appropriation
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	idupb,
	SUM(tabella.curramount)
FROM 
	(
		SELECT expense.idexp AS idexp, expenseyear.idupb AS idupb, expenseyear.idfin AS idfin,
		SUM(expensetotal.curramount) -
		ISNULL(
			(SELECT SUM(ET.curramount) 
			   FROM expensetotal ET
			JOIN expenselink ELK
				ON ELK.idchild = ET.idexp
			   JOIN expenselast ELS
			     ON ELS.idexp = ET.idexp
			WHERE ELK.idparent = expensetotal.idexp
			AND ET.ayear = @ayear)
		,0) AS curramount
		FROM expense
		JOIN expensetotal
			ON expensetotal.idexp = expense.idexp
		JOIN expenseyear
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		WHERE expensetotal.ayear = @ayear
			AND expense.nphase = @appropriationphasecode
			AND (expense.expiration <= @lastday
			OR expense.expiration IS NULL)
		GROUP BY expense.idexp, expenseyear.idupb,expenseyear.idfin, expensetotal.idexp
	) AS tabella
JOIN #finlookup FK 
        ON FK.oldidfin = tabella.idfin 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable 
GROUP BY idupb, ISNULL(finlink.idparent,FK.newidfin) 


-- Totale Reversali Trasmesse dopo la data
CREATE TABLE #latecommunicated_proceeds(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO #latecommunicated_proceeds
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	proceedscommunicated.idupb,
	SUM(ISNULL(incometotal.curramount,0))
FROM incometotal
JOIN proceedscommunicated
	ON incometotal.idinc = proceedscommunicated.idinc
	AND incometotal.ayear = proceedscommunicated.ymov
JOIN #finlookup FK 
        ON FK.oldidfin = proceedscommunicated.idfin 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable 
WHERE incometotal.ayear = @ayear
	AND (proceedscommunicated.competencydate > @date AND proceedscommunicated.competencydate <= @lastday)
GROUP BY proceedscommunicated.idupb,ISNULL(finlink.idparent,FK.newidfin)


-- Incassi o Righe di Reversale sensa Reversale di incasso
CREATE TABLE #withoutdoc_proceeds(idupb varchar(36),idfin int, total decimal(19,2))
INSERT INTO #withoutdoc_proceeds
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	incomeyear.idupb,
	SUM(ISNULL(incometotal.curramount,0))
FROM incometotal
JOIN incomeyear
	ON incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear
JOIN income
	ON incomeyear.idinc = income.idinc
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN #finlookup FK 
        ON FK.oldidfin = incomeyear.idfin 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable 
WHERE incomeyear.ayear = @ayear
	AND incomelast.kpro IS NULL
	AND income.nphase = @maxincomephase
GROUP BY incomeyear.idupb, ISNULL(finlink.idparent,FK.newidfin)


-- Reversali di Incasso non Trasmesse
CREATE TABLE #uncommunicated_proceeds(idupb varchar(36),idfin int, total decimal(19,2))
INSERT INTO  #uncommunicated_proceeds
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	proceedsemitted.idupb,
	SUM(ISNULL(incometotal.curramount,0))
FROM incometotal
JOIN proceedsemitted
	ON incometotal.idinc  = proceedsemitted.idinc
	AND incometotal.ayear = proceedsemitted.ymov
JOIN #finlookup FK 
        ON FK.oldidfin = proceedsemitted.idfin 
LEFT OUTER JOIN finlink
	ON finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE incometotal.ayear = @ayear
	AND proceedsemitted.idinc NOT IN 
		(SELECT proceedscommunicated.idinc 
		FROM proceedscommunicated
		WHERE ymov = @ayear)
GROUP BY proceedsemitted.idupb,ISNULL(finlink.idparent,FK.newidfin)

-- Accertamenti con scadenza entro l'anno oppure quelli che non hanno una data di scadenza
CREATE TABLE #withexpiration_assessment(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO  #withexpiration_assessment
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	idupb,
	SUM(tabella.curramount)
FROM 
	(
		SELECT income.idinc AS idinc, incomeyear.idupb AS idupb,incomeyear.idfin AS idfin,
		SUM(incometotal.curramount) -
		ISNULL(
		(SELECT SUM(IT.curramount) 
		   FROM incometotal IT
	           JOIN incomelast ILS
		     ON ILS.idinc = IT.idinc
		   JOIN incomelink ILK
		     ON ILK.idchild = IT.idinc
		  WHERE ILK.idparent = incometotal.idinc
		    AND IT.ayear = @ayear)
		,0) AS curramount
		FROM income
		JOIN incometotal
			ON incometotal.idinc = income.idinc
		JOIN incomeyear
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		WHERE incometotal.ayear = @ayear
			AND income.nphase = @assessmentphasecode
			AND (income.expiration <= @lastday
			OR income.expiration IS NULL)
		GROUP BY income.idinc, incomeyear.idupb, incomeyear.idfin, incometotal.idinc
	) AS tabella
JOIN #finlookup FK 
        ON FK.oldidfin = tabella.idfin 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable 
GROUP BY idupb,ISNULL(finlink.idparent,FK.newidfin)

-- Impegni di competenza, impegni effettuati nell'anno
CREATE TABLE #yearappropriation(idupb varchar(36), idfin int, total decimal(19,2))
INSERT INTO #yearappropriation
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	expenseyear.idupb,
	SUM(ISNULL(expensetotal.curramount,0))
FROM expensetotal
JOIN expenseyear
	ON expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN #finlookup FK 
        ON FK.oldidfin = expenseyear.idfin 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable 
WHERE expenseyear.ayear = @ayear
	AND expense.nphase = @appropriationphasecode
	AND ((expensetotal.flag&1)=0) --=Competenza
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,FK.newidfin)


-- Impegni di competenza alla data, impegni effettuati nell'anno alla ddata
CREATE TABLE #yearappropriationstilldate(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO #yearappropriationstilldate
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	expenseyear.idupb,
	SUM(ISNULL(expensetotal.curramount,0))
FROM expensetotal
JOIN expenseyear
	ON expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN #finlookup FK 
        ON FK.oldidfin = expenseyear.idfin 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable 
WHERE expenseyear.ayear = @ayear
	AND expense.nphase = @appropriationphasecode
	AND ( (((expensetotal.flag&1)=0)  AND  @fin_kind IN (1,3)) OR (@fin_kind = 2))
	AND expense.adate <= @date
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,FK.newidfin)


-- Pagamenti di cassa effettuati nell'anno alla data
CREATE TABLE #payment_cash(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO  #payment_cash
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	HPV.idupb,
	SUM(ISNULL(expensetotal.curramount,0))
FROM expensetotal
JOIN historypaymentview HPV
	ON expensetotal.idexp = HPV.idexp
	AND expensetotal.ayear = HPV.ymov
JOIN #finlookup FK 
        ON FK.oldidfin = HPV.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE expensetotal.ayear = @ayear
	AND (HPV.competencydate >= @firstday AND HPV.competencydate <= @date)
GROUP BY HPV.idupb, ISNULL(finlink.idparent,FK.newidfin)


-- Incassi di cassa effettuati nell'anno alla data
CREATE TABLE #proceeds_cash(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO  #proceeds_cash
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	HPV.idupb,
	SUM(ISNULL(incometotal.curramount,0))
FROM incometotal
JOIN historyproceedsview HPV
	ON incometotal.idinc = HPV.idinc
	AND incometotal.ayear = HPV.ymov
JOIN #finlookup FK 
        ON FK.oldidfin = HPV.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE incometotal.ayear = @ayear
	AND (HPV.competencydate >= @firstday AND HPV.competencydate <= @date)
GROUP BY HPV.idupb, ISNULL(finlink.idparent,FK.newidfin)



-- Mandati effettuati su impengi effettuati nell'anno corrente, ovvero Pagamenti su impegni di competenza	
CREATE TABLE #yearpayment(idupb varchar(36), idfin int, total decimal(19,2))
INSERT INTO #yearpayment
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	expenseyear.idupb,
	SUM(ISNULL(expensetotal.curramount,0))
FROM expensetotal
JOIN expenseyear
	ON expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN #finlookup FK 
        ON FK.oldidfin = expenseyear.idfin 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable 
WHERE expenseyear.ayear = @ayear
	AND expense.nphase = @maxexpensephase
	AND ((expensetotal.flag&1)=0) --Competenza
GROUP BY expenseyear.idupb, ISNULL(finlink.idparent,FK.newidfin)


-- Mandati effettuate su residui passivi al 01/01, ovvero Pagamenti su residui
CREATE TABLE #expenditurepayment(idupb varchar(36),idfin int,total decimal(19,2))
INSERT INTO #expenditurepayment
(
	idfin,
	idupb,
	total
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	expenseyear.idupb,
	SUM(ISNULL(expensetotal.curramount,0))
FROM expensetotal
JOIN expenseyear
	ON expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN #finlookup FK 
        ON FK.oldidfin = expenseyear.idfin 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable 
WHERE expenseyear.ayear = @ayear
	AND expense.nphase = @maxexpensephase
	AND ((expensetotal.flag&1) = 1) --Residuo
GROUP BY expenseyear.idupb, ISNULL(finlink.idparent,FK.newidfin)


--------------------------------------------		CALCOLO DEGLI IMPORTI DI OUTPUT		-------------------------------------------
/*	FONDO CASSA ALLA DATA = 
	  Tot. variazioni Dotazione Cassa
	+ Assegnazione degli incassi Tx. prima della data
	- Mandati Tx prima della data						*/
UPDATE #bilprevision
SET 
	floatfund	= 
			ISNULL(proceedsvariation,0) 
			+ ISNULL(
				(SELECT #proceedstransmitted.total FROM #proceedstransmitted
				WHERE #proceedstransmitted.idupb = #bilprevision.idupb 
					and #proceedstransmitted.idfin = #bilprevision.idfin), 0) 
			-ISNULL(
				(SELECT #paymenttransmitted.total FROM #paymenttransmitted
				WHERE #paymenttransmitted.idupb = #bilprevision.idupb
					and #paymenttransmitted.idfin = #bilprevision.idfin), 0)
	WHERE (finpart = 'S')and (assured <>'S') -- x i fondi vale zero

-- INCASSI PRESUNTI (RIMANE COM'ERA PRIMA) X LE SPESE
/* 
	Importo attuale dei Residui Passivi al 1/1/
	- Totale Variazioni Dotazione Cassa
	+ (Totale variazione Dotazione Crediti + Assegnazione degli Accertamenti)
	- Assegnazione degli Incassi Tx prima della data					*/
IF(@fin_kind <> 2) 
BEGIN
	UPDATE #bilprevision
	SET 
		supposedproceeds = 
			ISNULL(
				(SELECT #totexpenditure.total FROM #totexpenditure
				WHERE #totexpenditure.idupb = #bilprevision.idupb
					and #totexpenditure.idfin = #bilprevision.idfin), 0) 
			- ISNULL(proceedsvariation,0) 
			+ ISNULL(totcreditpart,0) 
			- ISNULL(
				(SELECT total FROM #proceedstransmitted
				WHERE #proceedstransmitted.idupb = #bilprevision.idupb
					and #proceedstransmitted.idfin = #bilprevision.idfin), 0)
	WHERE (finpart ='S') AND (assured <>'S')   -- x i fondi vale zero
END
-- INCASSI PRESUNTI X LE ENTRATE (NUOVO), duale ai pagamenti presunti
/*
	 Totale Reversali Tx dopo la data
	+ Incassi o Righe di Reversale sensa Reversale di incasso
	+ Reversali di Incasso non Tx
	+ Accertamenti con scadenza entro l'anno oppure quelli che non hanno una data di scadenza
																	*/
IF(@fin_kind <> 2) 
BEGIN
	UPDATE #bilprevision
	SET 
		supposedproceeds = 
			ISNULL(
				(SELECT #latecommunicated_proceeds.total FROM #latecommunicated_proceeds
				WHERE #latecommunicated_proceeds.idupb = #bilprevision.idupb
					and #latecommunicated_proceeds.idfin = #bilprevision.idfin), 0) +
			ISNULL(
				(SELECT #withoutdoc_proceeds.total FROM #withoutdoc_proceeds
				WHERE #withoutdoc_proceeds.idupb = #bilprevision.idupb 
					and #withoutdoc_proceeds.idfin = #bilprevision.idfin), 0) +
			ISNULL(
				(SELECT #uncommunicated_proceeds.total FROM #uncommunicated_proceeds
				WHERE #uncommunicated_proceeds.idupb = #bilprevision.idupb
					and #uncommunicated_proceeds.idfin = #bilprevision.idfin), 0) +
			ISNULL(
				(SELECT #withexpiration_assessment.total FROM #withexpiration_assessment
				WHERE #withexpiration_assessment.idupb = #bilprevision.idupb 
					and #withexpiration_assessment.idfin = #bilprevision.idfin), 0)
	WHERE (finpart ='E') and (assured <>'S')   -- x i fondi vale zero
END

-- PAGAMENTI PRESUNTI (RIMANE COM'ERA PRIMA) vale 0 per le Entrate, x le spese rimane così
/*
	 Totale Mandati Tx dopo la data
	+ Liquidazioni o Righe di Mandato sensa mandato di pagamento
	+ Mandati  di Pagamenti non Tx
	+ Impegni con scadenza entro l'anno oppure quelli che non hanno una data di scadenza
																	
*/

IF(@fin_kind <> 2) 
BEGIN
	UPDATE #bilprevision
	SET 
		supposedpayments = ISNULL(
					(SELECT #latecommunicated_payment.total FROM #latecommunicated_payment
					WHERE #latecommunicated_payment.idupb = #bilprevision.idupb
						and #latecommunicated_payment.idfin = #bilprevision.idfin), 0) +
				ISNULL(
					(SELECT #withoutdoc_payment.total FROM #withoutdoc_payment
					WHERE #withoutdoc_payment.idupb = #bilprevision.idupb 
						and #withoutdoc_payment.idfin = #bilprevision.idfin), 0) +
				ISNULL(
					(SELECT #uncommunicated_payment.total FROM #uncommunicated_payment
					WHERE #uncommunicated_payment.idupb = #bilprevision.idupb
						and #uncommunicated_payment.idfin = #bilprevision.idfin), 0) +
				ISNULL(
					(SELECT #withexpiration_appropriation.total FROM #withexpiration_appropriation
					WHERE #withexpiration_appropriation.idupb = #bilprevision.idupb 
						and #withexpiration_appropriation.idfin = #bilprevision.idfin), 0)
		WHERE (finpart='S') 	-- x le entrate è chiaramente a zero
END
--- Residui Attivi Presunti al 31/12
/*
	Importo attuale dei residui attivi al 01/01
	+ accertamenti effettuati nell'anno
	- Reversali effettuate su accertamenti effettuati nell'anno corrente
	- Reversali effettuate su residui attivi al 01/01
	- Accertamenti con data di scadenza entro l'anno
*/

IF(@fin_kind <> 2) 
BEGIN
	UPDATE #bilprevision
	SET 
		--supposedrevenue = 0,
		supposedrevenue = 
				ISNULL(
					(SELECT #totrevenue.total FROM #totrevenue
					WHERE #totrevenue.idupb = #bilprevision.idupb
						and #totrevenue.idfin = #bilprevision.idfin), 0) +
				ISNULL(
					(SELECT #yearassessment.total FROM #yearassessment
					WHERE #yearassessment.idupb = #bilprevision.idupb
						and #yearassessment.idfin = #bilprevision.idfin), 0) -
				ISNULL(
					(SELECT #yearproceeds.total FROM #yearproceeds
					WHERE #yearproceeds.idupb = #bilprevision.idupb
						and #yearproceeds.idfin = #bilprevision.idfin), 0) -
				ISNULL(
					(SELECT #expenditureproceeds.total FROM #expenditureproceeds
					WHERE #expenditureproceeds.idupb = #bilprevision.idupb
						and #expenditureproceeds.idfin = #bilprevision.idfin), 0) -
				ISNULL(
					(SELECT #withexpiration_assessment.total FROM #withexpiration_assessment
					WHERE #withexpiration_assessment.idupb = #bilprevision.idupb
						and #withexpiration_assessment.idfin = #bilprevision.idfin), 0)
		where (finpart = 'E')
END

-- Residui Passivi Presunti al 31/12
/*
	Importo attuale dei residui passivi al 01/01
	+ impegni effettuati nell'anno
	- Mandati effettuati su impengi effettuati nell'anno corrente
	- Mandati effettuate su residui passivi al 01/01
	- Impegni con data scadenza con data di scadenza entro l'anno
*/
IF(@fin_kind <> 2) 
BEGIN
	UPDATE #bilprevision
	SET 
		supposedexpenditure =
				ISNULL(
					(SELECT #totexpenditure.total FROM #totexpenditure
					WHERE #totexpenditure.idupb = #bilprevision.idupb
						and #totexpenditure.idfin = #bilprevision.idfin), 0) +
				ISNULL(
					(SELECT #yearappropriation.total FROM #yearappropriation
					WHERE #yearappropriation.idupb = #bilprevision.idupb
						and #yearappropriation.idfin = #bilprevision.idfin), 0) -
				ISNULL(
					(SELECT #yearpayment.total FROM #yearpayment
					WHERE #yearpayment.idupb = #bilprevision.idupb
						and #yearpayment.idfin = #bilprevision.idfin), 0) -
				ISNULL(
					(SELECT #expenditurepayment.total FROM #expenditurepayment
					WHERE #expenditurepayment.idupb = #bilprevision.idupb
						and #expenditurepayment.idfin = #bilprevision.idfin), 0) -
				ISNULL(
					(SELECT #withexpiration_appropriation.total FROM #withexpiration_appropriation
					WHERE #withexpiration_appropriation.idupb = #bilprevision.idupb
						and #withexpiration_appropriation.idfin = #bilprevision.idfin), 0)
		where (finpart='S')
END
-- Previsione disponibile pricipale, ossia di competenza (availableprevision) :
--	Previsione attuale principale
--	+ Variazioni di Previsione alla data
--	- Impegni di competenza effettuati nell'anno alla data / - Accertamenti di competenza effettuati nell'anno alla data
--
-- Previsione disponibile secondaria, ossia di cassa (availableprevision_secondary):
--	Previsione attuale secondaria
--	+ Variazioni di Previsione alla data
--	- Pagamenti di cassa effettuati nell'anno alla data / - Incassi di cassa effettuati nell'anno alla data
--
-- Previsione disponibile pricipale di cassa, è la prev. disponibile per un bilancio di SOLA cassa (availableprevision_onlycash) :
--	Previsione attuale principale
--	+ Variazioni di Previsione alla data
--	- Pagamenti di cassa effettuati nell'anno alla data / - Incassi di cassa effettuati nell'anno alla data

UPDATE #bilprevision
SET 
	availableprevision = 	ISNULL(thisyearprevision,0) 
				+ 
				ISNULL(
					(SELECT sum(#tot_varprev.total) 
					   FROM #tot_varprev
					LEFT OUTER JOIN  finlink
						ON finlink.idchild = #tot_varprev.idfin 
					  WHERE #tot_varprev.idupb = #bilprevision.idupb
					AND ISNULL(finlink.idparent, #tot_varprev.idfin) = #bilprevision.idfin), 0)
				- ISNULL(
					(SELECT #yearappropriationstilldate.total FROM #yearappropriationstilldate
					WHERE #yearappropriationstilldate.idupb = #bilprevision.idupb
						and #yearappropriationstilldate.idfin = #bilprevision.idfin
						and #bilprevision.finpart = 'S'), 0)
				- ISNULL(
					(SELECT #yearassessmentstilldate.total FROM #yearassessmentstilldate
					WHERE #yearassessmentstilldate.idupb = #bilprevision.idupb
						and #yearassessmentstilldate.idfin = #bilprevision.idfin
						and #bilprevision.finpart = 'E'), 0),
	availableprevision_secondary = 	ISNULL(thisyearsecondaryprevision,0) 
				+ 
				ISNULL(
					(SELECT sum(#tot_varsecondaryprev.total) 
					   FROM #tot_varsecondaryprev
					LEFT OUTER JOIN  finlink
						ON finlink.idchild = #tot_varsecondaryprev.idfin 
					  WHERE #tot_varsecondaryprev.idupb = #bilprevision.idupb
					AND ISNULL(finlink.idparent, #tot_varsecondaryprev.idfin) = #bilprevision.idfin), 0)
				- ISNULL(
					(SELECT #payment_cash.total FROM #payment_cash
					WHERE #payment_cash.idupb = #bilprevision.idupb
						and #payment_cash.idfin = #bilprevision.idfin
						and #bilprevision.finpart = 'S'), 0)
				- ISNULL(
					(SELECT #proceeds_cash.total FROM #proceeds_cash
					WHERE #proceeds_cash.idupb = #bilprevision.idupb
						and #proceeds_cash.idfin = #bilprevision.idfin
						and #bilprevision.finpart = 'E'), 0),
        availableprevision_onlycash = ISNULL(thisyearprevision,0) 
				+ 
				ISNULL(
					(SELECT sum(#tot_varprev.total) 
					   FROM #tot_varprev
					LEFT OUTER JOIN  finlink
						ON finlink.idchild = #tot_varprev.idfin 
					  WHERE #tot_varprev.idupb = #bilprevision.idupb
					AND ISNULL(finlink.idparent, #tot_varprev.idfin) = #bilprevision.idfin), 0)
				- ISNULL(
					(SELECT #payment_cash.total FROM #payment_cash
					WHERE #payment_cash.idupb = #bilprevision.idupb
						and #payment_cash.idfin = #bilprevision.idfin
						and #bilprevision.finpart = 'S'), 0)
				- ISNULL(
					(SELECT #proceeds_cash.total FROM #proceeds_cash
					WHERE #proceeds_cash.idupb = #bilprevision.idupb
						and #proceeds_cash.idfin = #bilprevision.idfin
						and #bilprevision.finpart = 'E'), 0),

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

/*	previousprevision =  ISNULL(previousprevision,0) 
				+ 
				ISNULL(
					(SELECT #tot_varprev.total FROM #tot_varprev
					WHERE #tot_varprev.idupb = #bilprevision.idupb
						and #tot_varprev.idfin = #bilprevision.idfin), 0),
	
	previoussecondaryprev =  ISNULL(previoussecondaryprev,0) 
				+ 
				ISNULL(
					(SELECT #tot_varsecondaryprev.total FROM #tot_varsecondaryprev
					WHERE #tot_varsecondaryprev.idupb = #bilprevision.idupb
						and #tot_varsecondaryprev.idfin = #bilprevision.idfin), 0)
*/
		
-- Procedura che imposta il valore dei capitoli articolati pari alla somma degli articoli
-- in particolare sta prendendo i capitoli degli articoli, se non esistono nella tabella.
-- Per esempio se ho fatto solo un mov. di spesa sull'articolo, lo troverò SOLO in expenseyear
-- quindi in #bilprevision troverò SOLO l'articolo. Questo ciclo serve ad inserisce anche il relativo capitolo
-- per poterlo totalizzare.
DECLARE @nextayear int
SET 	@nextayear = @ayear + 1

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
                assured,
                finpart,
                floatfund, 	
                supposedproceeds,
                supposedpayments,
                supposedrevenue,
                supposedexpenditure,
                prevision, 
                availableprevision,
                availableprevision_secondary,
                availableprevision_onlycash,
                previousprevision,
                previoussecondaryprev,
                previousarrears,
                prevision2, 	
                prevision3,	
                prevision4,	
                prevision5	
	)

	SELECT DISTINCT
		CHILD.idupb, 
		CHILD.paridfin, 
                CHILD.assured,
                CHILD.finpart,
		0,0,0,0,0,
		0,0,0,0,0,
		0,0,0,0,0,
                0
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
                floatfund = 
        	ISNULL(
        		(SELECT SUM(floatfund) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),
                supposedproceeds = 
        	ISNULL(
        		(SELECT SUM(supposedproceeds) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),
                supposedpayments = 
        	ISNULL(
        		(SELECT SUM(supposedpayments) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),
                supposedrevenue = 
        	ISNULL(
        		(SELECT SUM(supposedrevenue) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),
                supposedexpenditure = 
        	ISNULL(
        		(SELECT SUM(supposedexpenditure) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),
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
        	,0),
                prevision2 = 
        	ISNULL(
        		(SELECT SUM(prevision2) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),

                prevision3 = 
        	ISNULL(
        		(SELECT SUM(prevision3) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),

                prevision4 = 
        	ISNULL(
        		(SELECT SUM(prevision4) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),

                prevision5 = 
        	ISNULL(
        		(SELECT SUM(prevision5) FROM #bilprevision child
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
		ISNULL(SUM(floatfund),0) as floatfund, 			-- Fondo di Cassa alla Data. (Per i FONDI è zero)
		ISNULL(SUM(supposedproceeds),0) as supposedproceeds,		-- INCASSI PRESUNTI alla data(RIMANE) servono x le Entrate
		ISNULL(SUM(supposedpayments),0) as supposedpayments,		-- PAGAMENTI PRESUNTI alla data (RIMANE)
		ISNULL(SUM(supposedrevenue),0) as supposedrevenue,		-- Residui Attivi Presunti al 31/12
		ISNULL(SUM(supposedexpenditure),0) as supposedexpenditure,	-- Residui Passivi Presunti al 31/12
		-- Pura Prev. Comp. = finyear.prevision2 + prev.disponibile principale, ossia di competenza.
		CASE 
			WHEN (#bilprevision.assured ='S') THEN SUM((ISNULL(prevision2,0) + ISNULL(availableprevision,0)))
			ELSE ISNULL(SUM(prevision),0)
		END AS competency,
                -- Prev. Cassa = finyear.prevision2 + prev.disponibile secondaria, ossia di cassa. 
		CASE 
			WHEN (#bilprevision.assured ='S') THEN SUM((ISNULL(prevision2,0) + ISNULL(availableprevision_secondary,0)))
			ELSE ISNULL(SUM(prevision),0)
		END AS cash,
		-- Prev. Disponibile di quest''anno x Entate,
		ISNULL(SUM(availableprevision),0) as availableprevision,
		ISNULL(SUM(previousprevision),0) AS previousprevision, 
		ISNULL(SUM(previoussecondaryprev),0) AS previoussecondaryprev,
		ISNULL(SUM(previousarrears),0) AS previousarrears,
		SUM(prevision3) as prevision2, 	
		SUM(prevision4) as prevision3,	
		SUM(prevision5) as prevision4,	
		0 as prevision5	
	FROM #bilprevision
	JOIN fin newfin
                ON newfin.idfin= #bilprevision.idfin
        GROUP BY #bilprevision.finpart,	newfin.codefin,	newfin.title, #bilprevision.idupb,newfin.idfin,#bilprevision.assured 

END

IF (@fin_kind = 2)
BEGIN
	SELECT 
		#bilprevision.finpart,		
		newfin.codefin,			
		newfin.title as fin, 		
		#bilprevision.idupb,	
		newfin.idfin as idfin,			
		ISNULL(SUM(floatfund),0) as floatfund, 			-- Fondo di Cassa alla Data. (Per i FONDI è zero)
		ISNULL(SUM(supposedproceeds),0) as supposedproceeds,		-- INCASSI PRESUNTI alla data(RIMANE) servono x le Entrate
		ISNULL(SUM(supposedpayments),0) as supposedpayments,		-- PAGAMENTI PRESUNTI alla data (RIMANE)
		ISNULL(SUM(supposedrevenue),0) as supposedrevenue,		-- Residui Attivi Presunti al 31/12
		ISNULL(SUM(supposedexpenditure),0) as supposedexpenditure,	-- Residui Passivi Presunti al 31/12
		-- Previsione di cassa(in un bilancio di competenza è la Pura Prev. Comp.)
		0 	AS competency,
                -- Prev. Cassa = finyear.prevision2 + prev.disponibile principale. 
		CASE 
			WHEN (#bilprevision.assured ='S') THEN SUM((ISNULL(prevision,0) + ISNULL(availableprevision_onlycash,0)))
			ELSE ISNULL(SUM(prevision),0)
		END AS cash,
		-- Prev. Disponibile di quest''anno x Entrate,
		ISNULL(SUM(availableprevision_onlycash),0) as availableprevision,
		ISNULL(SUM(previousprevision),0) AS previousprevision, 
		0 	AS previoussecondaryprev,
		ISNULL(SUM(previousarrears),0) AS previousarrears,
		SUM(prevision3) as prevision2, 	
		SUM(prevision4) as prevision3,	
		SUM(prevision5) as prevision4,	
		0 as prevision5	
	FROM #bilprevision
	JOIN fin newfin
                ON newfin.idfin= #bilprevision.idfin
	GROUP BY #bilprevision.finpart,newfin.codefin,newfin.title,#bilprevision.idupb,newfin.idfin,#bilprevision.assured
	
END

END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

	
