
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_spese_intestazione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_spese_intestazione]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [rpt_partitario_spese_intestazione]
	@ayear int,
	@idupb	varchar(36),
	@adate datetime,
	@codelevel tinyint,
	@showupb char(1),
	@showchildupb char(1),
	@suppressifblank char(1),
	@idfin int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
BEGIN

CREATE TABLE #expense
(
	upb varchar(150),
	codeupb	varchar(50),
	idupb varchar(36),
	upbprintingorder varchar(50),
	nphase tinyint,
	idfin int,
	idappropriation int,
	adate datetime,
	ayear int,
	description varchar(150),
	idreg int,
	rowkind 	  int,
	npay 		  int,
	nappropriation    int,
	ymovappropriation int,
	nmovappropriation int,
	yvarappropriation int,
	nvarappropriation int,
	amount_appropriation decimal(19,2),
	origin_amount_appropriation decimal(19,2),
	available_appropriation decimal(19,2),
	flagarrear char(1),	
	reportdate datetime,
	initialprevisioncomp decimal(19,2),
	initialprevisioncassa decimal(19,2),
	finvar_prevision decimal(19,2),
	finvar_secondaryprev decimal(19,2),
	appropriation_C decimal(19,2),
	var_appropriation_C decimal(19,2),
	payment_C decimal(19,2),
	var_payment_C decimal(19,2),
	appropriation_R decimal(19,2),
	var_appropriation_R decimal(19,2),
	payment_R decimal(19,2),
	var_payment_R decimal(19,2),
	npayment int,
	ymovpayment int,
	nmovpayment int,
	yvarpayment int,
	nvarpayment int,
	payment_amount decimal(19,2),
	assign_credit 		decimal(19,2),
	var_assign_credit	decimal(19,2),
	assign_cash		decimal(19,2), 
	var_assign_cash		decimal(19,2),
	flag_assign_credit 	char(1),
	flag_assign_cash 	char(1),
	emessiondate datetime,
	printeddate datetime,
	trasmitteddate datetime,
	transactiondate datetime,
	annulmentdate datetime,
	doc varchar(150)

)

DECLARE @previsionkind char(1) 
SELECT  @previsionkind =  fin_kind
FROM  config 
WHERE config.ayear = @ayear


DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END
DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear AND (flag&2)<>0

DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin), @codelevel)

IF (@codelevel < @level_input ) AND (@idfin is not null)
	BEGIN
	SET  @codelevel = @level_input
	END

DECLARE @nfinphase tinyint
SELECT  @nfinphase = appropriationphasecode
FROM config
WHERE ayear = @ayear
IF (@nfinphase IS NULL)
BEGIN
	SELECT @nfinphase = expensefinphase FROM uniconfig
END
  
-- ovvero prendo la massima fase tra quelle che contengono o il codice di bilancio o il creditore perchè questa  è la vera fase di impegno giuridico
DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase)
FROM    expensephase 
--ATTENZIONE L'ipotesi di funzionamento di questa sp è che fase dell' impegno = fase del pagamento - 1.
--ALTRIMENTI SBALLA LE RIGHE DEL PAGAMENTO SUL REPORT (o meglio con un pò di tempo si deve fare un controllo per eliminare tutte le fasi 
--che non sono fasepagamento e faseimpegno, anzi lo faccio subito inserendo alla fine una DELETE WHERE nphase <> fase del pagamento AND nphase <> fase dell'impegno)
INSERT INTO #expense
(
	idfin,
	idupb,
	nphase,
	rowkind, 
	adate, 
	description, 
	idreg,--registry, 
	nappropriation, 
	ymovappropriation,
	nmovappropriation,
	amount_appropriation,
	origin_amount_appropriation,
	npayment, 
	ymovpayment,
	nmovpayment,
	payment_amount,
	npay,
	flagarrear,
	idappropriation,
	doc
)	--> prende quelli movimentati
SELECT 
	ISNULL(FL.idparent, expenseyear.idfin),
	upb.idupb,
	expense.nphase,
	expense.nphase-1,
	expense.adate,
	expense.description,
	expense.idreg,
	E2.idexp, --IMPEGNO
	E2.ymov,
	E2.nmov,  
	expenseyear.amount,
	expenseyear_starting.amount,
	E3.idexp, --PAGAMENTO
	E3.ymov,
	E3.nmov, 
	expenseyear.amount,
	payment.npay,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	E2.idexp, --IMPEGNO
	CASE
		WHEN expense.doc IS NOT NULL
			AND expense.docdate IS NULL
			THEN 'Pag. ' + expense.doc
		WHEN expense.doc IS NOT NULL
			AND expense.docdate IS NOT NULL
			THEN 'Pag. ' + expense.doc + 
			' del ' + CONVERT(varchar(20), expense.docdate, 105)
		ELSE NULL
	END
FROM expenseyear
JOIN expense	(NOLOCK)  			ON expenseyear.idexp = expense.idexp 
JOIN upb		(NOLOCK)  			ON upb.idupb = expenseyear.idupb
JOIN fin		(NOLOCK)  			ON expenseyear.idfin = fin.idfin AND expenseyear.ayear = fin.ayear
JOIN expensetotal (NOLOCK)  		ON  expenseyear.idexp = expensetotal.idexp	AND expenseyear.ayear = expensetotal.ayear	
JOIN expenselink EL2 (NOLOCK)  		ON EL2.idchild = expense.idexp  AND EL2.nlevel = @nfinphase
LEFT  OUTER JOIN finlink FL	(NOLOCK)  	ON FL.idchild = expenseyear.idfin AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1 (NOLOCK)  		ON FL1.idchild = expenseyear.idfin AND FL1.nlevel = @level_input
LEFT  OUTER JOIN expenselast (NOLOCK)  		ON expenselast.idexp = expense.idexp
LEFT  OUTER JOIN payment	 (NOLOCK)  		ON expenselast.kpay = payment.kpay
LEFT OUTER JOIN expense E2		ON E2.idexp = EL2.idparent
LEFT OUTER JOIN expense E3		ON E3.idexp = expenselast.idexp	
LEFT OUTER JOIN expensetotal expensetotal_firstyear (NOLOCK)  	
				ON expensetotal_firstyear.idexp = expense.idexp AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp 	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
WHERE ((fin.flag&1)=1) -- = 'S'	
	AND expenseyear.ayear=@ayear
	AND (@idfin IS NULL OR  isnull(FL1.idparent, expenseyear.idfin) = @idfin)		
	AND expense.adate <= @adate
	AND expense.nphase >= @nfinphase -- le prendo da qui in poi
	AND (upb.idupb like @idupb) 
 	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

--- Inserimento delle variazioni dei movimenti
INSERT INTO #expense
(
	idfin,
	idupb,
	nphase,
	rowkind, 
	adate, 
	description, 
	idreg,		
	nappropriation, 
	ymovappropriation,
	nmovappropriation,
	yvarappropriation,
	nvarappropriation,
	amount_appropriation,

	npayment, 
	ymovpayment,
	nmovpayment,
	yvarpayment,
	nvarpayment,
	payment_amount,
	npay,
	idappropriation,
	doc
)	--> prende quelli movimentati


SELECT 
	ISNULL(FL.idparent, expenseyear.idfin),
	expenseyear.idupb,
	expense.nphase,
	expense.nphase-1,
	expensevar.adate,
	expensevar.description,
	expense.idreg,	
	E2.idexp, --IMPEGNO
	E2.ymov,
	E2.nmov,  
	expensevar.yvar,
	expensevar.nvar,
	expensevar.amount,

	E3.idexp, --PAGAMENTO
	E3.ymov,
	E3.nmov, 
	expensevar.yvar,--EV3
	expensevar.nvar,--EV3
	expensevar.amount,--EV3
	payment.npay,
	E2.idexp,
	CASE
		WHEN expensevar.doc IS NOT NULL
			AND expensevar.docdate IS NULL
			THEN 'Pag. ' + expensevar.doc
		WHEN expensevar.doc IS NOT NULL
			AND expensevar.docdate IS NOT NULL
			THEN 'Pag. ' + expensevar.doc + 
			' del ' + CONVERT(varchar(20), expensevar.docdate, 105)
		ELSE NULL
	END
FROM expensevar
join expense	 (NOLOCK)  		on expensevar.idexp = expense.idexp
JOIN expenseyear (NOLOCK)  		ON expenseyear.idexp = expense.idexp 
JOIN upb		(NOLOCK)  		ON upb.idupb = expenseyear.idupb
JOIN finlast	(NOLOCK)  		ON finlast.idfin = expenseyear.idfin 
JOIN expenselink EL2 (NOLOCK)  	ON EL2.idchild = expensevar.idexp  AND EL2.nlevel = @nfinphase
LEFT  OUTER JOIN finlink FL (NOLOCK)  	ON FL.idchild = expenseyear.idfin  AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1 (NOLOCK)  	ON FL1.idchild = expenseyear.idfin  AND FL1.nlevel = @level_input
LEFT OUTER JOIN expenselast (NOLOCK)  		ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN expenselink EL3 (NOLOCK)  	ON EL3.idchild = expensevar.idexp  AND EL3.nlevel = @maxexpensephase
LEFT OUTER JOIN expense E2 (NOLOCK)  		ON E2.idexp = EL2.idparent
LEFT OUTER JOIN expense E3 (NOLOCK)  		ON E3.idexp = EL3.idparent
LEFT OUTER JOIN payment (NOLOCK)  			ON payment.kpay = expenselast.kpay
WHERE	(@idfin IS NULL OR  isnull(FL1.idparent, expenseyear.idfin) = @idfin)		
	AND expensevar.adate between @firstday and @adate
	and expensevar.yvar = @ayear 
	AND isnull(expensevar.autokind,'') <>'22'
	AND ((expense.nphase IN (@nfinphase, @maxexpensephase)))
	AND (expenseyear.idupb like @idupb)
	AND expenseyear.ayear=@ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


INSERT INTO #expense
	(
	idfin,
	idupb
	)--> Prende quelli non movimentati 
SELECT 
	ISNULL(FL.idparent, fin.idfin),
	upb.idupb
FROM fin 
	CROSS JOIN upb (NOLOCK)  	
LEFT OUTER JOIN finyear (NOLOCK)  		ON finyear.idfin=fin.idfin 	AND finyear.idupb = upb.idupb
LEFT  OUTER JOIN finlink FL (NOLOCK)  	ON FL.idchild = fin.idfin  AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1 (NOLOCK)  		ON FL1.idchild = fin.idfin  AND FL1.nlevel = @level_input
WHERE ((fin.flag&1)=1) -- Spesa
	AND (@idfin IS NULL OR  isnull(FL1.idparent, fin.idfin) = @idfin)	
	AND (upb.idupb like @idupb) 
	AND  fin.nlevel = @codelevel
	AND  fin.ayear = @ayear
	and not exists (SELECT #expense.idfin,#expense.idupb
			FROM #expense
			JOIN finyear ff
			ON ff.idupb=#expense.idupb
			AND ff.idfin=#expense.idfin
			WHERE finyear.idupb=ff.idupb 
			AND finyear.idfin=ff.idfin)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

CREATE TABLE #finvar_prevision
    (
	idfin  int,
	idupb  varchar(36),
	totale decimal(19,2)			 
    )
INSERT INTO #finvar_prevision
	(
	idfin,
	idupb,
	totale
	)
SELECT
	ISNULL(finlink.idparent,finvardetail.idfin),
	finvardetail.idupb,
	SUM(ISNULL(finvardetail.amount,0.0))
FROM finvardetail
JOIN finvar (NOLOCK)  		ON finvar.yvar = finvardetail.yvar
						AND finvar.nvar = finvardetail.nvar
JOIN upb	(NOLOCK)  	ON upb.idupb = finvardetail.idupb	
LEFT OUTER JOIN finlink (NOLOCK)  		ON finlink.idchild = finvardetail.idfin AND finlink.nlevel = @codelevel	
WHERE finvar.flagprevision ='S'
	AND finvar.idfinvarstatus = 5
	AND finvar.variationkind <> 5
	AND finvar.adate <= @adate
	AND finvar.yvar = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY finvardetail.idupb,ISNULL(finlink.idparent,finvardetail.idfin)


CREATE TABLE #finvar_secondaryprev
    (
	idfin  int,
	idupb  varchar(36),
	totale decimal(19,2)			 
    )
INSERT INTO #finvar_secondaryprev
	(
	idfin,
	idupb,
	totale
	)
SELECT
	ISNULL(finlink.idparent,finvardetail.idfin),
	finvardetail.idupb,
	SUM(ISNULL(finvardetail.amount, 0.0))
FROM finvardetail
JOIN finvar (NOLOCK)  		ON finvar.yvar = finvardetail.yvar	AND finvar.nvar = finvardetail.nvar
JOIN upb	(NOLOCK)  		ON upb.idupb = finvardetail.idupb	
LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = finvardetail.idfin AND finlink.nlevel = @codelevel			
WHERE finvar.yvar = @ayear
	AND finvar.adate <= @adate
	AND finvar.flagsecondaryprev='S'
	AND finvar.idfinvarstatus = 5
	AND finvar.variationkind <> 5
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY finvardetail.idupb,ISNULL(finlink.idparent,finvardetail.idfin)

CREATE TABLE #appropriation_C
    (
	idfin  int,
	idupb  varchar(36),
	totale decimal(19,2)			 
    )
INSERT INTO #appropriation_C
	(
	idfin,
	idupb,
	totale
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	SUM(ISNULL(expenseyear.amount, 0.0))
FROM expense
JOIN expenseyear	(NOLOCK)  		ON expenseyear.idexp = expense.idexp AND expenseyear.ayear = @ayear
JOIN expensetotal   (NOLOCK)  		ON  expenseyear.idexp = expensetotal.idexp AND	expenseyear.ayear = expensetotal.ayear 
JOIN fin (NOLOCK)  					ON fin.idfin = expenseyear.idfin
JOIN upb (NOLOCK)  					ON upb.idupb = expenseyear.idupb	
LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = expenseyear.idfin 	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL	(NOLOCK)  	ON FL.idchild = expenseyear.idfin 	AND FL.nlevel = @level_input
WHERE expense.adate <= @adate
	AND expenseyear.ayear = @ayear
	AND ((expensetotal.flag&1)=0) --Competenza
	AND expense.nphase = @nfinphase
	AND (@idfin IS NULL OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin)

CREATE TABLE #var_appropriation_C
    (
	idfin  int,
	idupb  varchar(36),
	totale decimal(19,2)					 
    )
INSERT INTO #var_appropriation_C
	(
	idfin,
	idupb,
	totale
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	SUM(ISNULL(expensevar.amount, 0.0))
FROM expensevar
JOIN expenseyear (NOLOCK)  		ON expenseyear.idexp = expensevar.idexp AND expenseyear.ayear = @ayear
JOIN expensetotal (NOLOCK)  	ON  expenseyear.idexp = expensetotal.idexp AND	expenseyear.ayear = expensetotal.ayear 
JOIN expense (NOLOCK)  			ON expense.idexp = expenseyear.idexp
JOIN fin	(NOLOCK)  			ON fin.idfin = expenseyear.idfin
JOIN upb	(NOLOCK)  			ON upb.idupb = expenseyear.idupb	
LEFT OUTER JOIN finlink (NOLOCK)  		ON finlink.idchild = expenseyear.idfin 	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL	(NOLOCK)  	ON FL.idchild = expenseyear.idfin 	AND FL.nlevel = @level_input
WHERE expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)=0) --Competenza
	AND expense.nphase = @nfinphase
	AND expensevar.adate <= @adate 
	AND (@idfin IS NULL OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin)

CREATE TABLE #appropriation_R
    (
	idfin int,
	idupb varchar(36),
	totale decimal(19,2)					 
    )
INSERT INTO #appropriation_R
	(
	idfin,
	idupb,
	totale
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	SUM(ISNULL(expenseyear.amount, 0.0))
FROM expenseyear
JOIN expense (NOLOCK)  		ON expense.idexp = expenseyear.idexp 	AND expenseyear.ayear = @ayear
JOIN fin (NOLOCK)  			ON fin.idfin = expenseyear.idfin
JOIN upb (NOLOCK)  			ON upb.idupb = expenseyear.idupb	
JOIN expensetotal (NOLOCK)  		ON  expenseyear.idexp = expensetotal.idexp AND	expenseyear.ayear = expensetotal.ayear 	
LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = expenseyear.idfin 	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL (NOLOCK)  	ON FL.idchild = expenseyear.idfin 	AND FL.nlevel = @level_input
WHERE ((expensetotal.flag&1)=1) --Residuo
	AND expense.nphase = @nfinphase
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND expense.adate <= @adate
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin)

CREATE TABLE #var_appropriation_R
    (
	idfin int,
	idupb varchar(36),
	totale decimal(19,2)					 
    )
INSERT INTO #var_appropriation_R
	(
	idfin,
	idupb,
	totale
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	SUM(ISNULL(expensevar.amount, 0.0))
FROM expensevar
JOIN expenseyear (NOLOCK)  		ON expenseyear.idexp = expensevar.idexp	AND expenseyear.ayear = @ayear
JOIN upb	(NOLOCK)  			ON upb.idupb = expenseyear.idupb	
JOIN expensetotal (NOLOCK)  	ON  expenseyear.idexp = expensetotal.idexp AND	expenseyear.ayear = expensetotal.ayear 	
JOIN expense (NOLOCK)  			ON expense.idexp = expenseyear.idexp
LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = expenseyear.idfin 	AND finlink.nlevel = @codelevel		
LEFT OUTER JOIN finlink FL (NOLOCK) ON FL.idchild = expenseyear.idfin 	AND FL.nlevel = @level_input
WHERE expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)=1) --Residuo
	AND expense.nphase = @nfinphase
	AND (@idfin IS NULL OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND expensevar.adate <= @adate 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin)
CREATE TABLE #payment_C
    (
	idfin int,
	idupb varchar(36),
	totale decimal(19,2)					 
    )
INSERT INTO #payment_C
	(
	idfin,
	idupb,
	totale
	)
SELECT
	ISNULL(finlink.idparent,paymentemitted.idfin),
	paymentemitted.idupb,
	SUM(ISNULL(paymentemitted.amount,0.0))
FROM paymentemitted
LEFT OUTER JOIN finlink (NOLOCK)  		ON finlink.idchild = paymentemitted.idfin 	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL (NOLOCK)  	ON FL.idchild = paymentemitted.idfin 	AND FL.nlevel = @level_input	
JOIN upb (NOLOCK)  						ON upb.idupb = paymentemitted.idupb	
WHERE paymentemitted.competencydate <= @adate
	AND paymentemitted.flagarrear= 'C'
	AND (@idfin IS NULL OR  isnull(FL.idparent,paymentemitted.idfin) = @idfin)	
	AND paymentemitted.ymov = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY paymentemitted.idupb,ISNULL(finlink.idparent,paymentemitted.idfin)

CREATE TABLE #payment_R
    (
	idfin int,
	idupb varchar(36),
	totale decimal(19,2)					 
    )
INSERT INTO #payment_R
	(
	idfin,
	idupb,
	totale
	)
SELECT
	ISNULL(finlink.idparent,paymentemitted.idfin),
	paymentemitted.idupb,
	SUM(ISNULL(paymentemitted.amount,0))
FROM paymentemitted
JOIN expense  (NOLOCK)  			ON expense.idexp = paymentemitted.idexp
JOIN fin (NOLOCK)  					ON paymentemitted.idfin = fin.idfin
JOIN upb (NOLOCK)  					ON upb.idupb = paymentemitted.idupb	
JOIN finlast	(NOLOCK)  			ON finlast.idfin = fin.idfin
LEFT OUTER JOIN finlink	(NOLOCK)  	ON finlink.idchild = paymentemitted.idfin 	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL (NOLOCK) ON FL.idchild = paymentemitted.idfin 	AND FL.nlevel = @level_input
WHERE paymentemitted.competencydate <= @adate
	AND paymentemitted.ymov = @ayear
	AND (paymentemitted.flagarrear= 'R')
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,paymentemitted.idfin) = @idfin)	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY paymentemitted.idupb,ISNULL(finlink.idparent,paymentemitted.idfin)

CREATE TABLE #var_payment_C
    (
	idfin int,
	idupb varchar(36),
	totale decimal(19,2)					 
    )
INSERT INTO #var_payment_C
	(
	idfin,
	idupb,
	totale
	)
SELECT 
	ISNULL(finlink.idparent,paymentemitted.idfin),
	paymentemitted.idupb,
	SUM(ISNULL(expensevar.amount, 0.0))
FROM expensevar
JOIN paymentemitted (NOLOCK)  		ON paymentemitted.idexp = expensevar.idexp	AND paymentemitted.ymov = @ayear
JOIN upb	(NOLOCK)  				ON upb.idupb = paymentemitted.idupb	
LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = paymentemitted.idfin AND 	finlink.nlevel = @codelevel	
LEFT OUTER JOIN finlink FL (NOLOCK) ON FL.idchild = paymentemitted.idfin AND FL.nlevel = @level_input				
WHERE expensevar.yvar = @ayear
	AND paymentemitted.flagarrear = 'C'
	AND expensevar.adate <= @adate
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,paymentemitted.idfin) = @idfin)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)	
GROUP BY paymentemitted.idupb,ISNULL(finlink.idparent,paymentemitted.idfin)


CREATE TABLE #var_payment_R
    (
	idfin varchar(31),
	idupb varchar(36),
	totale decimal(19,2)					 
    )
INSERT INTO #var_payment_R
	(
	idfin,
	idupb,
	totale
	)
SELECT 
	ISNULL(finlink.idparent,paymentemitted.idfin),
	paymentemitted.idupb,
	SUM(ISNULL(expensevar.amount, 0.0))
FROM expensevar 
JOIN paymentemitted (NOLOCK)  		ON paymentemitted.idexp = expensevar.idexp	AND paymentemitted.ymov = @ayear
JOIN upb	(NOLOCK)  				ON upb.idupb = paymentemitted.idupb	
LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = paymentemitted.idfin AND 	finlink.nlevel = @codelevel	
LEFT OUTER JOIN finlink FL (NOLOCK) ON FL.idchild = paymentemitted.idfin AND FL.nlevel = @level_input					
WHERE expensevar.yvar = @ayear
	AND paymentemitted.flagarrear = 'R'
	AND expensevar.adate <= @adate
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,paymentemitted.idfin) = @idfin)	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY paymentemitted.idupb,ISNULL(finlink.idparent,paymentemitted.idfin)

UPDATE #expense
	SET
	finvar_prevision =ISNULL((SELECT #finvar_prevision.totale 
				FROM #finvar_prevision
				WHERE #finvar_prevision.idupb = #expense.idupb
				and #finvar_prevision.idfin = #expense.idfin), 0.0),
	finvar_secondaryprev = ISNULL((SELECT #finvar_secondaryprev.totale 
				FROM #finvar_secondaryprev
				WHERE #finvar_secondaryprev.idupb = #expense.idupb
				and #finvar_secondaryprev.idfin = #expense.idfin), 0.0),
	appropriation_C =ISNULL((SELECT #appropriation_C.totale 
				FROM #appropriation_C
				WHERE #appropriation_C.idupb = #expense.idupb
				and #appropriation_C.idfin = #expense.idfin), 0.0),
	var_appropriation_C =ISNULL((SELECT #var_appropriation_C.totale 
				FROM #var_appropriation_C
				WHERE #var_appropriation_C.idupb = #expense.idupb
				and #var_appropriation_C.idfin = #expense.idfin), 0.0),
	payment_C =ISNULL((SELECT #payment_C.totale 
				FROM #payment_C
				WHERE #payment_C.idupb = #expense.idupb
				and #payment_C.idfin = #expense.idfin), 0.0),
	var_payment_C =ISNULL((SELECT #var_payment_C.totale 
				FROM #var_payment_C
				WHERE #var_payment_C.idupb = #expense.idupb
				and  #var_payment_C.idfin = #expense.idfin), 0.0),
  	appropriation_R =ISNULL((SELECT #appropriation_R.totale 
				FROM #appropriation_R
				WHERE #appropriation_R.idupb = #expense.idupb
				and #appropriation_R.idfin = #expense.idfin), 0.0),
	var_appropriation_R =ISNULL((SELECT #var_appropriation_R.totale 
				FROM #var_appropriation_R
				WHERE #var_appropriation_R.idupb = #expense.idupb
				and #var_appropriation_R.idfin = #expense.idfin), 0.0),
	payment_R =ISNULL((SELECT #payment_R.totale 
			FROM #payment_R					
			WHERE #payment_R.idupb = #expense.idupb
			and #payment_R.idfin = #expense.idfin), 0.0),
	var_payment_R = ISNULL((SELECT #var_payment_R.totale 
			FROM #var_payment_R
			WHERE #var_payment_R.idupb = #expense.idupb
			and #var_payment_R.idfin = #expense.idfin), 0.0),
	codeupb = (select upb.codeupb from upb 
				where upb.idupb = #expense.idupb),
	upb = (select upb.title from upb 
				where upb.idupb = #expense.idupb),
	upbprintingorder = (select upb.printingorder from upb 
				where upb.idupb = #expense.idupb)



IF (@showupb = 'S')
Begin
	IF @codelevel >= @levelusable
	BEGIN	
		UPDATE #expense
		SET	initialprevisioncomp= ISNULL((SELECT finyear.prevision 
					FROM finyear
					JOIN fin (NOLOCK)  				ON finyear.idfin = fin.idfin
					JOIN upb (NOLOCK)  				ON finyear.idupb = upb.idupb
					where finyear.idupb = #expense.idupb AND 
					finyear.idfin = #expense.idfin),0.0),
			initialprevisioncassa = ISNULL((SELECT finyear.secondaryprev 
					FROM finyear
					JOIN fin (NOLOCK)  		ON finyear.idfin = fin.idfin
					JOIN upb (NOLOCK)  		ON finyear.idupb = upb.idupb
					where finyear.idupb = #expense.idupb AND 
					finyear.idfin = #expense.idfin),0.0)
	END 
	ELSE 
	BEGIN
		UPDATE #expense
		SET initialprevisioncomp = ISNULL((SELECT SUM(isnull(finyear.prevision,0.0)) 
					FROM finyear
					JOIN fin (NOLOCK)  		ON finyear.idfin = fin.idfin
					JOIN upb	(NOLOCK)  	ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = finyear.idfin
					WHERE finyear.idupb = #expense.idupb  
					AND ISNULL(finlink.idparent,finyear.idfin) = #expense.idfin
					AND fin.nlevel= @levelusable),0),
		initialprevisioncassa = ISNULL((SELECT SUM(isnull(finyear.secondaryprev,0.0)) 
					FROM finyear
					JOIN fin (NOLOCK)  		ON finyear.idfin = fin.idfin
					JOIN upb (NOLOCK)  		ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = finyear.idfin
					WHERE finyear.idupb = #expense.idupb  
					AND ISNULL(finlink.idparent,finyear.idfin) =  #expense.idfin
					AND fin.nlevel = @levelusable),0)
	END
End

UPDATE #expense
SET
/* Disp.dell' Impegno per ulteriori mov. di fase successiva=
  Impegno + Var.Impegno alla data - (Pagamenti + Var. Pagamenti)
*/
	available_appropriation = 
		amount_appropriation 
		+ ISNULL((SELECT SUM(amount)
		FROM expensevar
		join expense on expensevar.idexp = expense.idexp
		WHERE expensevar.idexp= #expense.nappropriation
			and expensevar.adate between @firstday and @adate
			and expensevar.yvar = @ayear
			and expense.nphase  = @nfinphase
			and #expense.nvarappropriation is null
		),0) 
		- ISNULL((SELECT SUM(expenseyear.amount)
			from expenseyear
		JOIN  expense E (NOLOCK)  				ON E.idexp = expenseyear.idexp  
		JOIN expenselink elk1 (NOLOCK)  		ON elk1.idchild = E.idexp AND elk1.nlevel = @nfinphase
		where elk1.idparent = #expense.nappropriation
			AND E.nphase = @nfinphase+1
			AND expenseyear.ayear =@ayear
			and #expense.nvarappropriation is null -- deve aggiornare solo le righe degli impegni
		),0)
		- ISNULL((SELECT SUM(expensevar.amount)
		FROM expensevar
		JOIN  expense E		(NOLOCK)  		ON E.idexp = expensevar.idexp  
		JOIN expenselink elk1 (NOLOCK)  	ON elk1.idchild = E.idexp AND elk1.nlevel = @nfinphase
		WHERE elk1.idparent = #expense.nappropriation
			and expensevar.adate between @firstday and @adate
			and expensevar.yvar = @ayear
			AND E.nphase = @nfinphase+1
			and #expense.nvarappropriation is null
		),0)	


DELETE FROM #expense WHERE nphase <> @nfinphase AND nphase <> @maxexpensephase
------------------------------------------- <	     NEW        > ----------------------------------------------------------------	
-- SE ho scelto di totalizzare i figli dell'UPB selezionato (N, 'pippo',S)
-- O SE ho scelto di non vedere l'upb (N,N)  
-- ALLORA totalizzo gli importi
-- Se ho scelto di vedere l'upb (con o senza figli :  S/N o S/S) saranno presi i valori calcolati sopra 
-- che saranno stati calcolati distinguendo gli upb-padri dagli upb-figli.
IF (@showupb <>'S') 
Begin
	UPDATE #expense SET 
	finvar_prevision = (SELECT SUM(ISNULL(#finvar_prevision.totale,0.0))  
				FROM #finvar_prevision
				WHERE #finvar_prevision.idupb like @idupb
				and #finvar_prevision.idfin = #expense.idfin),
	finvar_secondaryprev =(SELECT SUM(ISNULL(#finvar_secondaryprev.totale,0.0))  
				FROM #finvar_secondaryprev
				WHERE #finvar_secondaryprev.idupb like @idupb
				and #finvar_secondaryprev.idfin = #expense.idfin), 
	appropriation_C = (SELECT SUM(ISNULL(#appropriation_C.totale,0.0))  
				FROM #appropriation_C
				WHERE #appropriation_C.idupb like @idupb
				and #appropriation_C.idfin = #expense.idfin), 
	var_appropriation_C = (SELECT SUM(ISNULL(#var_appropriation_C.totale,0.0))  
				FROM #var_appropriation_C
				WHERE #var_appropriation_C.idupb like @idupb
				and #var_appropriation_C.idfin = #expense.idfin),
	payment_C = (SELECT SUM(ISNULL(#payment_C.totale,0.0))  
				FROM #payment_C
				WHERE #payment_C.idupb like @idupb
				and #payment_C.idfin = #expense.idfin), 
	var_payment_C = (SELECT SUM(ISNULL(#var_payment_C.totale,0.0))  
				FROM #var_payment_C
				WHERE #var_payment_C.idupb like @idupb
				and  #var_payment_C.idfin = #expense.idfin),
  	appropriation_R =(SELECT SUM(ISNULL(#appropriation_R.totale,0.0))  
				FROM #appropriation_R
				WHERE #appropriation_R.idupb like @idupb
				and #appropriation_R.idfin = #expense.idfin), 
	var_appropriation_R =(SELECT SUM(ISNULL(#var_appropriation_R.totale,0.0))  
				FROM #var_appropriation_R
				WHERE #var_appropriation_R.idupb like @idupb
				and #var_appropriation_R.idfin = #expense.idfin), 
	payment_R =(SELECT SUM(ISNULL(#payment_R.totale,0.0))  
			FROM #payment_R					
			WHERE #payment_R.idupb like @idupb
			and #payment_R.idfin = #expense.idfin), 
	var_payment_R = (SELECT SUM(ISNULL(#var_payment_R.totale,0.0))  
			FROM #var_payment_R
			WHERE #var_payment_R.idupb like @idupb
			and #var_payment_R.idfin = #expense.idfin)	
	IF @codelevel >= @levelusable
	BEGIN	
		UPDATE #expense
		SET	
		initialprevisioncomp= (SELECT SUM(ISNULL(finyear.prevision,0.0))  
					FROM finyear
					JOIN fin (NOLOCK)  	ON finyear.idfin = fin.idfin
					JOIN upb (NOLOCK)  	ON finyear.idupb = upb.idupb
					where finyear.idupb like @idupb AND 
					finyear.idfin = #expense.idfin),
	  
		initialprevisioncassa = (SELECT SUM(ISNULL(finyear.secondaryprev,0.0))  
					FROM finyear
					JOIN fin (NOLOCK)  	ON finyear.idfin = fin.idfin
					JOIN upb (NOLOCK)  	ON finyear.idupb = upb.idupb
					where upb.idupb like @idupb AND 
					fin.idfin = #expense.idfin)
	END 
	ELSE 
	BEGIN
		UPDATE #expense
		SET 
		initialprevisioncomp= (SELECT SUM(ISNULL(finyear.prevision,0.0))  
					FROM finyear
					JOIN fin (NOLOCK)  	ON finyear.idfin = fin.idfin
					JOIN upb (NOLOCK)  	ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink  (NOLOCK)  	ON finlink.idchild = finyear.idfin
					where finyear.idupb like @idupb  
					AND ISNULL(finlink.idparent,finyear.idfin) = #expense.idfin
					AND fin.nlevel = @levelusable),
	  
		initialprevisioncassa = (SELECT SUM(ISNULL(finyear.secondaryprev,0.0))  
					FROM finyear
					JOIN fin (NOLOCK)  	ON finyear.idfin = fin.idfin
					JOIN upb (NOLOCK)  	ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink  (NOLOCK)  	ON finlink.idchild = finyear.idfin
					where upb.idupb like @idupb  
					AND ISNULL(finlink.idparent,finyear.idfin) = #expense.idfin
					AND fin.nlevel = @levelusable)
	END
End
-- cancello le righe dei figli di @idupboriginal aventi idappropriation = NULL
-- Se ho scelto l'upb ne cancello i figli perchè li ho totalizzati tramite la nuova UPDATE
IF (@showupb <>'S') and (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		DELETE FROM #expense WHERE idappropriation is null 
						AND substring(idupb,1,len(@idupboriginal))= @idupboriginal 	
						AND idupb <>@idupboriginal
-- cancello solo le righe che sono upb-figli aventi idappropriation = NULL
-- Se non ho scelto alcun upb cancello solo gli upb-figli perchè li ho totalizzati tramite la nuova UPDATE
IF (@showupb <>'S') 
		DELETE FROM #expense WHERE idappropriation IS NULL 
			AND EXISTS (SELECT * FROM #expense  R 
				join upb U on U.idupb=R.idupb  WHERE U.paridupb= #expense.idupb)
----------------------------------------------------------------------------------------------------------------------------------
IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
			UPDATE #expense SET  
				upbprintingorder = (SELECT TOP 1 upbprintingorder
					FROM #expense
					WHERE idupb = @idupboriginal),
				upb = (SELECT TOP 1 upb
					FROM #expense
					WHERE idupb = @idupboriginal),
				idupb = @idupboriginal,
				codeupb =(SELECT TOP 1 codeupb
					FROM #expense	
					WHERE idupb = @idupboriginal)
	
	IF (@showupb <>'S') and (@idupboriginal = '%')
				UPDATE #expense SET  
				upbprintingorder = null	,
				upb =  null,
				idupb = null,
				codeupb = null

update #expense set payment_amount = 0 where nphase <> @maxexpensephase

if (@suppressifblank = 'S') and @codelevel>2	--> se la stampa è x un livello sottostante la categoria cancella le righe
	BEGIN
		DELETE FROM  #expense   
		WHERE  
		(ISNULL(initialprevisioncomp,0.0)= 0 AND 
		ISNULL(initialprevisioncassa,0.0)= 0 AND 
		ISNULL(finvar_prevision,0.0)= 0 AND
		ISNULL(finvar_secondaryprev,0.0)= 0 AND
		ISNULL(appropriation_C,0.0) = 0 AND
		ISNULL(var_appropriation_C,0.0)= 0 AND
		ISNULL(payment_C,0.0)= 0) and
		ISNULL(var_payment_C,0.0)= 0 AND
		ISNULL(appropriation_R,0.0)= 0 AND
		ISNULL(var_appropriation_R,0.0)= 0 AND
		ISNULL(payment_R,0.0)= 0 AND
		ISNULL(var_payment_R,0.0)= 0 AND
		ISNULL(amount_appropriation,0.0)=0 AND
		ISNULL(available_appropriation,0.0)=0 AND
		ISNULL(payment_amount,0.0)=0
END
--  Aggiunta delle informazioni relative ai crediti e agli incassi  -----------------------------------------------------------------------------------
-- Controlla che i CREDITI  siano gestiti
IF 	
	(EXISTS(SELECT* FROM creditpart
		WHERE ycreditpart = @ayear AND adate <= @adate) 
	OR
	EXISTS (SELECT * FROM finvar
		WHERE flagcredit ='S' and yvar = @ayear
		AND adate <= @adate)
	OR  
	EXISTS (select * from upb where assured='S'))
		BEGIN
			UPDATE #expense
			SET var_assign_credit = isnull((
				SELECT SUM(d.amount)
				FROM finvardetail d
				JOIN finvar v (NOLOCK)  	ON v.yvar = d.yvar AND v.nvar = d.nvar AND v.flagcredit ='S'
				LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = d.idfin
				WHERE ISNULL(finlink.idparent,d.idfin) = #expense.idfin
					AND v.idfinvarstatus = 5
					AND d.idupb = #expense.idupb
					AND v.adate <= @adate
					AND v.variationkind IN (2,3)),0.0),
			 assign_credit = 	
				isnull((
				SELECT SUM(creditpart.amount)
				FROM creditpart 
				JOIN incomeyear (NOLOCK)  	ON creditpart.idinc = incomeyear.idinc AND creditpart.ycreditpart = incomeyear.ayear
				LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = creditpart.idfin
				WHERE ISNULL(finlink.idparent,creditpart.idfin)  = #expense.idfin
					AND incomeyear.idupb = #expense.idupb
					AND adate <= @adate),0.0)
				+	
				isnull((
				SELECT SUM(d.amount)
				FROM finvardetail d
				JOIN finvar v (NOLOCK)  	ON v.yvar = d.yvar AND v.nvar = d.nvar AND v.flagcredit ='S'
				LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = d.idfin
				WHERE ISNULL(finlink.idparent,d.idfin) = #expense.idfin
					AND v.idfinvarstatus = 5
					AND d.idupb = #expense.idupb
					AND v.adate <= @adate
					AND v.variationkind IN (1,4)),0.0),
			flag_assign_credit='S'
		END
ELSE
	UPDATE #expense
	SET flag_assign_credit='N'
IF 	(EXISTS(SELECT* FROM proceedspart 
		WHERE yproceedspart	= @ayear
		AND adate <= @adate) 
	OR
	EXISTS (SELECT * FROM finvar
		WHERE flagproceeds='S' and yvar = @ayear AND adate <= @adate AND idfinvarstatus = 5)
	OR
	EXISTS (select * from upb where assured='S')
	)
	BEGIN
	UPDATE #expense
		SET var_assign_cash = ISNULL(( 
			SELECT SUM(d.amount)
			FROM finvardetail d
			JOIN finvar v (NOLOCK)  	ON v.yvar = d.yvar	AND v.nvar = d.nvar AND v.flagproceeds='S'
			LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = d.idfin
			WHERE ISNULL(finlink.idparent,d.idfin) = #expense.idfin
				AND v.idfinvarstatus = 5
				AND d.idupb = #expense.idupb
				AND v.adate <= @adate
				AND v.variationkind IN (2,3)),0.0),
		 	assign_cash = isnull (( 
			SELECT SUM(proceedspart.amount)
				FROM proceedspart
			JOIN incomeyear (NOLOCK)  	ON proceedspart.idinc = incomeyear.idinc AND proceedspart.yproceedspart = incomeyear.ayear
			LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = proceedspart.idfin
			WHERE ISNULL(finlink.idparent,proceedspart.idfin)  = #expense.idfin
				AND incomeyear.idupb = #expense.idupb
				AND adate <= @adate),0.0)
				+
				ISNULL((
			SELECT  SUM(d.amount)
			FROM finvardetail d
			JOIN finvar v (NOLOCK)  ON v.yvar = d.yvar AND v.nvar = d.nvar AND v.flagproceeds='S'
			LEFT OUTER JOIN finlink (NOLOCK)  	ON finlink.idchild = d.idfin
			WHERE ISNULL(finlink.idparent,d.idfin) = #expense.idfin
				AND v.idfinvarstatus = 5
				AND v.adate <= @adate
				AND d.idupb = #expense.idupb
				AND v.variationkind IN (1,4)),0.0),
			flag_assign_cash='S'
	END
ELSE
	UPDATE #expense
	SET	flag_assign_cash='N'

--select 'seconda insert', amount_appropriation from #expense order by amount_appropriation

------------------------------------------------------------------------------------------------------------------------------------------------------
UPDATE #expense
	SET 	emessiondate = paymentview.adate,
		printeddate = 	paymentview.printdate,
		trasmitteddate = paymentview.transmissiondate,	
		transactiondate = paymentperformed.competencydate,
		annulmentdate = paymentview.annulmentdate
FROM paymentview
LEFT OUTER JOIN banktransaction (NOLOCK)  ON banktransaction.kpay=paymentview.kpay	
								AND (banktransaction.kind='D' OR banktransaction.kind IS NULL)
LEFT OUTER JOIN paymentperformed (NOLOCK)  	 
		ON paymentperformed.npay=paymentview.npay	AND paymentperformed.ypay=paymentview.ypay
WHERE #expense.npay = paymentview.npay
	AND paymentview.ypay=@ayear

DECLARE @finphase varchar(50)
DECLARE @maxphase varchar(50)

select @finphase = description from  expensephase where nphase = @nfinphase
select @maxphase = description from  expensephase where nphase = @maxexpensephase

IF (@showupb <>'S')
BEGIN
	SELECT 
		#expense.idfin,
		F.codefin,
		F.title as fintitle,
		F.printingorder as finprintingorder,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		nphase,
		rowkind,
		isnull(initialprevisioncomp,0.0)	as  initialprevisioncomp,
		isnull(initialprevisioncassa,0.0) as initialprevisioncassa,
		isnull(finvar_prevision,0.0) as finvar_prevision,
		isnull(finvar_secondaryprev,0.0) as  finvar_secondaryprev,	
		isnull(appropriation_C,0.0)as appropriation_C,
		isnull(var_appropriation_C,0.0)	as var_appropriation_C,
		isnull(payment_C,0.0)	as payment_C,
		isnull(var_payment_C,0.0)as var_payment_C,
		(isnull(appropriation_R,0.0))	 as appropriation_R,
		(isnull(var_appropriation_R,0.0)) as var_appropriation_R,
		(isnull(payment_R,0.0)) as payment_R,
		(isnull(var_payment_R,0.0)) as var_payment_R,
		adate,
		description,
		REG.title as registry,
		nappropriation,
		ymovappropriation,
		nmovappropriation,
		yvarappropriation,
		nvarappropriation,
		(isnull(amount_appropriation,0.0)) as amount_appropriation,	
		(isnull(origin_amount_appropriation,0.0)) as origin_amount_appropriation,
		(isnull(available_appropriation,0.0)) as available_appropriation,
		npayment,
		ymovpayment,
		nmovpayment,
		yvarpayment,
		nvarpayment,
		(isnull(payment_amount,0.0)) as payment_amount,
		npay,
		flagarrear,
		@adate as reportdate,
		@ayear as ayear,
		idappropriation,
		isnull(assign_credit,0) as assign_credit,
		isnull(var_assign_credit,0) as var_assign_credit,
		isnull(assign_cash,0) as assign_cash, 
		isnull(var_assign_cash,0) as var_assign_cash,
		flag_assign_credit,
		flag_assign_cash,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@maxexpensephase as maxexpensephase,
		@nfinphase as nfinphase,
		@finphase AS finphase,
		@maxphase AS maxphase,
		#expense.doc,
                @previsionkind AS previsionkind
	FROM #expense
	JOIN fin F	(NOLOCK)  			ON #expense.idfin = F.idfin
	LEFT OUTER JOIN registry REG (NOLOCK)  		On #expense.idreg = REG.idreg
	GROUP BY  
		#expense.idfin,F.codefin,F.title,
		F.printingorder,codeupb,idupb,upb,upbprintingorder,nphase,
		rowkind,adate,description,REG.title,nappropriation,
		yvarappropriation,nvarappropriation,
		npayment,npay,flagarrear,idappropriation,
		initialprevisioncomp,initialprevisioncassa,finvar_prevision	,
		finvar_secondaryprev,appropriation_C,var_appropriation_C,payment_C,var_payment_C,
		appropriation_R, var_appropriation_R,payment_R,var_payment_R,amount_appropriation,payment_amount,
		origin_amount_appropriation,available_appropriation,flag_assign_credit,flag_assign_cash,	
		assign_credit,var_assign_credit,assign_cash,var_assign_cash,
		ymovappropriation,nmovappropriation,ymovpayment,nmovpayment,yvarpayment,nvarpayment,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate, #expense.doc
	ORDER BY upbprintingorder,F.printingorder, rowkind, adate,nvarappropriation, nvarpayment
--select 'terza insert', amount_appropriation from #expense order by amount_appropriation

END
ELSE
BEGIN
	SELECT  
		#expense.idfin,
		F.codefin,
		F.title as fintitle,
		F.printingorder as finprintingorder,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		nphase,
		rowkind,
		initialprevisioncomp,
		initialprevisioncassa,
		finvar_prevision,
		finvar_secondaryprev,
		appropriation_C,
		var_appropriation_C,
		payment_C,
		var_payment_C,
		appropriation_R,
		var_appropriation_R,
		payment_R,
		var_payment_R,
		adate,
		description,
		REG.title as registry,
		nappropriation,
		ymovappropriation,
		nmovappropriation,
		yvarappropriation,
		nvarappropriation,
		amount_appropriation,
		origin_amount_appropriation,
		available_appropriation,
		npayment,
		ymovpayment,
		nmovpayment,
		yvarpayment,
		nvarpayment,
		payment_amount,
		npay,
		flagarrear,
		@adate as reportdate,
		@ayear as ayear,
		idappropriation,
		isnull(assign_credit,0)as assign_credit,-- Aggiunta delle informaziojni relative ai crediti e agli incassi
		isnull(var_assign_credit,0) as var_assign_credit,
		isnull(assign_cash,0) as assign_cash, 
		isnull(var_assign_cash,0) as var_assign_cash,
		flag_assign_credit,
		flag_assign_cash,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@maxexpensephase as maxexpensephase,
		@nfinphase as nfinphase,
		@finphase AS finphase,
		@maxphase AS maxphase,
		#expense.doc,
                @previsionkind as previsionkind
	FROM #expense
	JOIN fin F (NOLOCK)  	ON #expense.idfin = F.idfin
	LEFT OUTER JOIN registry REG (NOLOCK)  	On #expense.idreg = REG.idreg
	ORDER BY upbprintingorder,F.printingorder, rowkind, adate, nvarappropriation,nvarpayment
END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
