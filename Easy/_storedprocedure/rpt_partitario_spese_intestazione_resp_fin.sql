
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_spese_intestazione_resp_fin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_spese_intestazione_resp_fin]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--  exec rpt_partitario_spese_intestazione_resp_fin 2006, {ts '2006-03-07 00:00:00'},'3','%','4','S'

CREATE  PROCEDURE [rpt_partitario_spese_intestazione_resp_fin]
	@ayear int,
	@codelevel tinyint,
	@idman int,
	@suppressifblank char(1),
	@codefin		varchar(50),
	@start datetime,
	@stop datetime

AS
BEGIN
/* Versione 1.0.3 del 17/10/2007 ultima modifica: SARA */

DECLARE @idfin int
IF (@codefin IS NULL OR @codefin = '' OR @codefin = '%')
	BEGIN
		SET @idfin = null	
	END
Else
	BEGIN
	   	SET @idfin = (select idfin 
				from fin 
				where codefin = @codefin 
				and ayear=@ayear 
				and (fin.flag&1)=1) -- Spesa
	END

DECLARE @levelusable	tinyint
SELECT  @levelusable = MIN(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear AND (flag&2)<>0

DECLARE @nfinphase tinyint



SELECT  @nfinphase = appropriationphasecode
FROM 	config
WHERE 	ayear = @ayear

IF (@nfinphase IS NULL)
BEGIN
	SELECT @nfinphase = expensefinphase FROM uniconfig
END
-- ovvero prendo la massima fase tra quelle che contengono o il codice di bilancio o il creditore perchè  questa è la vera fase di impegno giuridico
DECLARE @maxexpensephase tinyint
SELECT 	@maxexpensephase = MAX(nphase)
FROM  	expensephase 
-- ATTENZIONE L'ipotesi di funzionamento di questa sp è che faseimpegno = fasepagamento - 1.
-- ALTRIMENTI SBALLA LE RIGHE DEL PAGAMENTO SUL REPORT (o meglio con un pò di tempo si deve fare un controllo per eliminare tutte le fasi 
-- che non sono fasepagamento e faseimpegno, anzi lo faccio subito inserendo alla fine una DELETE WHERE nphase <> fasepagamento AND nphase <> faseimpegno)

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@codelevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@codelevel < @level_input ) AND (@idfin is not null)
BEGIN
	SET  @codelevel = @level_input
END


CREATE TABLE #expense
(
	idfin int ,
	nphase tinyint,
	rowkind int,
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
	adate datetime,
	description varchar(300),                   
	idreg int,	
	nappropriation int,
	ymovappropriation int,
	nmovappropriation int,
	appropriation_amount decimal(19,2),
	npayment int,
	ymovpayment int,
	nmovpayment int,
	payment_amount decimal(19,2),
	npay int,
	flagarrear char(1),	
	reportdate datetime,
	ayear int,
	idappropriation int,
	idman int,
	manager varchar(150),
	total_appropriation_C decimal(19,2) ,
	total_var_appropriation_C decimal(19,2),
	total_appropriation_R decimal(19,2),
	total_var_appropriation_R decimal(19,2),
	total_payment_C decimal(19,2),
	total_var_payment_C decimal(19,2),
	total_payment_R  decimal(19,2),
	total_var_payment_R decimal(19,2)   -- N.B.: non serve calcolare i totali relativi alle previsioni e alle var di previsione 
	-- in quanto sono gia calcolati indipendentemente dal responsabile.
)
INSERT INTO #expense
(
	idfin,
	nphase,
	rowkind, 
	adate, 
	description, 
	idreg,		
	nappropriation, 
	ymovappropriation,
	nmovappropriation,
	appropriation_amount,
	npayment, 
	ymovpayment,
	nmovpayment,
	payment_amount,
	npay,
	flagarrear,
	idappropriation,
	idman
)	--> prende quelli movimentati
SELECT 
	ISNULL(FL.idparent, expenseyear.idfin),-- figlio di livello @codelevel della voce di bilancio in input ut
	expense.nphase,
	expense.nphase-1,
	expense.adate,
	case 
		when (isnull(expense.doc,'') = '') then expense.description 
		when (isnull(expense.doc,'') <> '' and isnull(expense.docdate,'') = '' ) then
			expense.description + ' (Doc. ' + isnull(Convert (varchar(20),expense.doc),'') +')'
		else  expense.description + ' (Doc. ' + isnull(Convert (varchar(20),expense.doc),'') + ' del '+ 
		isnull(Convert (varchar(2),datepart(dd,expense.docdate)),'')+'/'+ isnull(Convert (varchar(2),datepart(mm,expense.docdate)),'')+
		'/'+ isnull(Convert (varchar(4),datepart(yy,expense.docdate)),'')+')'
	end,
	expense.idreg,	
	E2.idexp, --IMPEGNO
	E2.ymov,
	E2.nmov,  
	expenseyear.amount,
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
	finlast.idman 
FROM expense
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp and ayear=@ayear
JOIN fin
	ON expenseyear.idfin = fin.idfin 
	AND expenseyear.ayear = fin.ayear
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear	
JOIN finlast
	ON finlast.idfin = fin.idfin 
JOIN expenselink EL2
	ON EL2.idchild = expense.idexp  AND EL2.nlevel = @nfinphase
LEFT  OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin  AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1
	ON FL1.idchild = expenseyear.idfin  AND FL1.nlevel = @level_input
LEFT OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN payment
	ON expenselast.kpay = payment.kpay
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expense.idexp  AND EL3.nlevel = @maxexpensephase
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
WHERE ((fin.flag&1)=1) -- = 'S'	
	AND (@idfin IS NULL OR  isnull(FL1.idparent, expenseyear.idfin) = @idfin)		
	AND expense.adate between @start and @stop
	AND ((finlast.idman  = @idman) OR (@idman is null and finlast.idman is not null))	
	AND ((expense.nphase IN (@nfinphase, @maxexpensephase)))
	AND ((expense.nphase = @nfinphase) OR (expense.nphase = @maxexpensephase))
--select 3,* from #expense	
IF (@suppressifblank = 'S')
BEGIN
	INSERT INTO #expense
		(
		idfin,
		idman
		)	--> Prende quelli non movimentati 
	SELECT DISTINCT
		ISNULL(FL2.idparent, FD.idfin),
		finlast.idman	
	FROM fin
	JOIN finlink FL1
		ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
	JOIN finlink FL2
		ON FL2.idchild = fin.idfin AND FL2.nlevel = @codelevel
	JOIN finlink FL3
		ON FL3.idparent = fin.idfin
	JOIN finvardetail FD 
		ON FD.idfin = FL3.idchild
	JOIN finvar FVAR
		ON FVAR.yvar = FD.yvar
		AND FVAR.nvar = FD.nvar
	LEFT OUTER JOIN finlast
		ON finlast.idfin = FL1.idchild
	WHERE ((fin.flag&1)=1) -- Spesa
		AND FVAR.idfinvarstatus = 5
		AND (@idfin IS NULL 
		OR  (isnull(FL1.idparent, FD.idfin) = @idfin AND @idfin is NOT NULL))	
		AND ((finlast.idman  = @idman) OR (@idman is null and finlast.idman is not null))	
		AND fin.ayear = @ayear
		AND NOT EXISTS (SELECT *
			FROM #expense
			WHERE FL2.idparent = #expense.idfin
			and finlast.idman = #expense.idman
			)	
		
INSERT INTO #expense
	(
		idfin,
		idman
	)	--> Prende quelli non movimentati 
SELECT distinct
	isnull(FL2.idparent, EY.idfin),
	finlast.idman
FROM fin
	JOIN finlink FL1
		ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
	JOIN finlink FL2
		ON FL2.idchild = fin.idfin AND FL2.nlevel = @codelevel
	JOIN finlink FL3
		ON FL3.idparent = fin.idfin
	JOIN expenseyear EY 
		ON EY.idfin = FL3.idchild and EY.ayear = fin.ayear
	LEFT OUTER JOIN finlast
		ON finlast.idfin = FL1.idchild
WHERE ((fin.flag&1)=1) -- Spesa
		AND (@idfin IS NULL 
		OR  isnull(FL1.idparent, EY.idfin) = @idfin)	
		AND ((finlast.idman  = @idman) OR (@idman is null and finlast.idman is not null))	
		AND fin.ayear = @ayear
		AND NOT EXISTS (SELECT *
			FROM #expense
			WHERE FL2.idparent = #expense.idfin
			and finlast.idman = #expense.idman
			)	

INSERT INTO #expense
	(
		idfin,
		idman
	)	--> Prende quelli non movimentati 
SELECT distinct
	isnull(FL2.idparent, FY.idfin),
	finlast.idman
FROM fin
	JOIN finlink FL1
		ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
	JOIN finlink FL2
		ON FL2.idchild = fin.idfin AND FL2.nlevel = @codelevel
	JOIN finlink FL3
		ON FL3.idparent = fin.idfin
	JOIN finyear FY 
		on FY.idfin = FL3.idchild   
		and FY.ayear=fin.ayear and
			(isnull(FY.previousprevision,0) <> 0 OR
			 isnull(FY.prevision,0) <> 0 OR
			 isnull(FY.previoussecondaryprev,0) <> 0 OR
			 isnull(FY.secondaryprev,0) <> 0 OR
			 isnull(FY.previousarrears,0) <> 0 OR
			 isnull(FY.currentarrears,0) <> 0					 
			)
	LEFT OUTER JOIN finlast
		ON finlast.idfin = FL1.idchild
WHERE ((fin.flag&1)=1) -- Spesa
		AND (@idfin IS NULL 
		OR  isnull(FL1.idparent, FY.idfin) = @idfin)	
		AND ((finlast.idman  = @idman) OR (@idman is null and finlast.idman is not null))	
		AND fin.ayear = @ayear
		AND NOT EXISTS (SELECT *
			FROM #expense
			WHERE FL2.idparent = #expense.idfin
			and finlast.idman = #expense.idman
			)	

--select 4,* from #expense
END
ELSE
BEGIN
INSERT INTO #expense
	(
		idfin,
		idman
	)	--> Prende quelli non movimentati 
SELECT 	distinct
	isnull(FL2.idparent, fin.idfin),
	finlast.idman
FROM 	fin
	JOIN finlink FL1
		ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
	JOIN finlink FL2
		ON FL2.idchild = fin.idfin AND FL2.nlevel = @codelevel
	JOIN finlink FL3
		ON FL3.idparent = fin.idfin
	LEFT OUTER JOIN finlast
		ON finlast.idfin = FL1.idchild
	WHERE ((fin.flag&1)=1) -- Spesa	
		AND (@idfin IS NULL OR  isnull(FL1.idparent, fin.idfin) = @idfin)	
		AND ((finlast.idman  = @idman) OR (@idman IS NULL AND finlast.idman is not null))	
		AND fin.ayear = @ayear
		AND NOT EXISTS (SELECT *
			FROM #expense
			WHERE FL2.idparent = #expense.idfin
			AND finlast.idman = #expense.idman 
			)


END

CREATE TABLE #appropriation_C
    (
	idfin int,
	idman int,
	amount decimal(19,2)			 
    )
INSERT INTO #appropriation_C
	(
	idfin,
	idman,
	amount
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	finlast.idman,
	SUM(ISNULL(expenseyear.amount, 0))
FROM expense
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp 
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear 
JOIN finlast
	ON finlast.idfin = expenseyear.idfin
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE expense.adate between @start and @stop
	AND expenseyear.ayear = @ayear
	AND ((expensetotal.flag&1)=0) --Competenza
	AND expense.nphase = @nfinphase
	AND (@idfin IS NULL OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((finlast.idman  = @idman) OR (@idman IS NULL AND finlast.idman is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),finlast.idman 

CREATE TABLE #var_appropriation_C
    (
	idfin int,
	idman int,
	amount decimal(19,2)					 
    )
INSERT INTO #var_appropriation_C
	(
	idfin,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	finlast.idman, 
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear 
JOIN expense 
	ON expense.idexp = expenseyear.idexp
JOIN finlast
	ON finlast.idfin = expenseyear.idfin
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE expensevar.yvar = @ayear
	AND expenseyear.ayear = @ayear
	AND ((expensetotal.flag&1)=0) --Competenza
	AND expense.nphase = @nfinphase
	AND expensevar.adate between @start and @stop 
	AND (@idfin IS NULL OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((finlast.idman  = @idman) OR (@idman IS NULL AND finlast.idman is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),finlast.idman 

CREATE TABLE #appropriation_R
    (
	idfin int,
	idman int,
	amount decimal(19,2)					 
    )
INSERT INTO #appropriation_R
	(
	idfin,
	idman,
	amount
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	finlast.idman,	
	SUM(ISNULL(expenseyear.amount, 0))
FROM expenseyear
JOIN expense
	ON expense.idexp = expenseyear.idexp 
JOIN fin 
	ON fin.idfin = expenseyear.idfin
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear
JOIN finlast
	ON finlast.idfin = fin.idfin
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE  ((expensetotal.flag&1)=1) --Residuo
	AND expenseyear.ayear = @ayear
	AND expense.nphase = @nfinphase
	AND expense.adate between @start and @stop
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((finlast.idman  = @idman) OR (@idman IS NULL AND finlast.idman is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),finlast.idman --expense.idman

CREATE TABLE #var_appropriation_R
    (
	idfin int,
	idman int,
	amount decimal(19,2)					 
    )
INSERT INTO #var_appropriation_R
	(
	idfin,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	finlast.idman,	
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp	
JOIN expense 
	ON expense.idexp = expenseyear.idexp
JOIN fin 
	ON expenseyear.idfin = fin.idfin
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear
JOIN finlast
	ON finlast.idfin = fin.idfin
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE expensevar.yvar = @ayear
	AND expenseyear.ayear = @ayear
	AND ((expensetotal.flag&1)=1) --Residuo
	AND expense.nphase = @nfinphase
	AND expensevar.adate between @start and @stop 
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((finlast.idman  = @idman) OR (@idman IS NULL AND finlast.idman is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),finlast.idman 

CREATE TABLE #payment_C
    (
	idfin int,
	idman int,
	amount decimal(19,2)					 
    )

INSERT INTO #payment_C
	(
	idfin,
	idman,
	amount
	)
SELECT
	ISNULL(finlink.idparent,paymentemitted.idfin),
	finlast.idman,
	SUM(ISNULL(paymentemitted.amount,0))
FROM paymentemitted
JOIN expense 
	ON expense.idexp = paymentemitted.idexp
JOIN fin
	ON paymentemitted.idfin = fin.idfin
JOIN finlast
	ON finlast.idfin = fin.idfin
LEFT OUTER JOIN finlink 
	ON finlink.idchild = paymentemitted.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = paymentemitted.idfin 
	AND FL.nlevel = @level_input
WHERE paymentemitted.competencydate between @start and @stop
	AND paymentemitted.ymov = @ayear
	AND (paymentemitted.flagarrear='C') --Competenza
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,paymentemitted.idfin) = @idfin)	
	AND ((finlast.idman  = @idman) OR (@idman IS NULL AND finlast.idman is not null))	
GROUP BY ISNULL(finlink.idparent,paymentemitted.idfin),finlast.idman 

CREATE TABLE #payment_R
    (
	idfin int,
	idman int,
	amount decimal(19,2)					 
    )
INSERT INTO #payment_R
	(
	idfin,
	idman,
	amount
	)
SELECT
	ISNULL(finlink.idparent,paymentemitted.idfin),
	finlast.idman,
	SUM(ISNULL(paymentemitted.amount,0))
FROM paymentemitted
JOIN expense 
	ON expense.idexp = paymentemitted.idexp
JOIN fin
	ON paymentemitted.idfin = fin.idfin
JOIN finlast
	ON finlast.idfin = fin.idfin
LEFT OUTER JOIN finlink 
	ON finlink.idchild = paymentemitted.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = paymentemitted.idfin 
	AND FL.nlevel = @level_input
WHERE paymentemitted.competencydate between @start and @stop
	AND paymentemitted.ymov = @ayear
	AND (paymentemitted.flagarrear= 'R') --Residuo
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,paymentemitted.idfin) = @idfin)	
	AND ((finlast.idman  = @idman) OR (@idman IS NULL AND finlast.idman is not null))	
GROUP BY ISNULL(finlink.idparent,paymentemitted.idfin),finlast.idman

CREATE TABLE #var_payment_C
    (
	idfin int,
	idman int,
	amount decimal(19,2)					 
    )
INSERT INTO #var_payment_C
	(
	idfin,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	finlast.idman,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
JOIN expense 
	ON expense.idexp = expenseyear.idexp
JOIN fin 
	ON expenseyear.idfin = fin.idfin
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear
JOIN finlast
	ON finlast.idfin = fin.idfin
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE expensevar.yvar = @ayear
	AND expenseyear.ayear = @ayear
	AND ((expensetotal.flag&1)=0) --Competenza
	AND expense.nphase = @maxexpensephase
	AND expensevar.adate between @start and @stop
	AND expensevar.idexp IN (select idexp from paymentemitted)
	AND (@idfin IS NULL OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((finlast.idman  = @idman) OR (@idman IS NULL AND finlast.idman is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),finlast.idman 

CREATE TABLE #var_payment_R
    (
	idfin int,
	idman int,
	amount decimal(19,2)					 
    )
INSERT INTO #var_payment_R
	(
	idfin,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	finlast.idman,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
JOIN expense 
	ON expense.idexp = expenseyear.idexp
JOIN fin 
	ON expenseyear.idfin = fin.idfin
JOIN finlast
	ON finlast.idfin = fin.idfin
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE expensevar.yvar = @ayear
	AND expenseyear.ayear = @ayear
	AND ((expensetotal.flag&1)=1) --Residuo
	AND expense.nphase = @maxexpensephase
	AND expensevar.adate between @start and @stop
	AND expensevar.idexp IN (select idexp FROM paymentemitted)
	AND (@idfin IS NULL 
	OR  (isnull(FL.idparent,expenseyear.idfin) = @idfin AND @idfin is NOT NULL))	
	AND ((finlast.idman  = @idman) OR (@idman IS NULL AND finlast.idman is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),finlast.idman

UPDATE #expense
SET
	appropriation_amount = appropriation_amount + (SELECT ISNULL(SUM(amount),0) 
		FROM expensevar
		join expense on expensevar.idexp = expense.idexp
		WHERE expensevar.idexp= #expense.nappropriation
		and expensevar.adate between @start and @stop
		and expensevar.yvar = @ayear
		and expense.nphase  = @nfinphase
		),
	payment_amount = payment_amount + (SELECT ISNULL(SUM(amount),0) 
		FROM expensevar
		join expense on expensevar.idexp = expense.idexp
		WHERE expensevar.idexp = #expense.npayment
		and expensevar.adate between @start and @stop
		and expensevar.yvar = @ayear
		and expense.nphase = @maxexpensephase
		),
	reportdate =@stop,
	ayear=@ayear


UPDATE #expense SET 
	finvar_prevision = ISNULL((SELECT SUM(ISNULL(finvardetail.amount,0))
			FROM finvardetail
			JOIN finvar
				ON finvar.yvar = finvardetail.yvar
				AND finvar.nvar = finvardetail.nvar
			LEFT OUTER JOIN finlink 
				ON finlink.idchild = finvardetail.idfin AND 
				finlink.nlevel = @codelevel
			WHERE finvar.flagprevision ='S'	
				AND finvar.idfinvarstatus = 5
				AND finvar.variationkind <> 5
				AND finvar.adate between @start and @stop
				AND finvar.yvar = @ayear
				and ISNULL(finlink.idparent,finvardetail.idfin) = #expense.idfin 
			), 0),
	finvar_secondaryprev = ISNULL((SELECT SUM(ISNULL(finvardetail.amount,0))
				FROM finvardetail
				JOIN finvar
					ON finvar.yvar = finvardetail.yvar
					AND finvar.nvar = finvardetail.nvar
				LEFT OUTER JOIN finlink 
					ON finlink.idchild = finvardetail.idfin AND 
					finlink.nlevel = @codelevel
				WHERE finvar.flagsecondaryprev ='S'	
					AND finvar.idfinvarstatus = 5
					AND finvar.variationkind <> 5
					AND finvar.adate between @start and @stop
					AND finvar.yvar = @ayear
					AND ISNULL(finlink.idparent,finvardetail.idfin)  = #expense.idfin 
					), 0),
	appropriation_C = (SELECT SUM(ISNULL(#appropriation_C.amount,0))  
				FROM #appropriation_C
				WHERE  #appropriation_C.idfin = #expense.idfin
					and #appropriation_C.idman = #expense.idman), 
	var_appropriation_C = (SELECT SUM(ISNULL(#var_appropriation_C.amount,0))  
				FROM #var_appropriation_C
				WHERE  #var_appropriation_C.idfin = #expense.idfin
					and #var_appropriation_C.idman = #expense.idman),
	payment_C = (SELECT SUM(ISNULL(#payment_C.amount,0))  
				FROM #payment_C
				WHERE  #payment_C.idfin = #expense.idfin
					and #payment_C.idman = #expense.idman), 
	var_payment_C = (SELECT SUM(ISNULL(#var_payment_C.amount,0))  
				FROM #var_payment_C
				WHERE   #var_payment_C.idfin = #expense.idfin
					and #var_payment_C.idman = #expense.idman),
  	appropriation_R =(SELECT SUM(ISNULL(#appropriation_R.amount,0))  
				FROM #appropriation_R
				WHERE  #appropriation_R.idfin = #expense.idfin
					and #appropriation_R.idman = #expense.idman), 
	var_appropriation_R =(SELECT SUM(ISNULL(#var_appropriation_R.amount,0))  
				FROM #var_appropriation_R
				WHERE  #var_appropriation_R.idfin = #expense.idfin
					and #var_appropriation_R.idman = #expense.idman), 
	payment_R =(SELECT SUM(ISNULL(#payment_R.amount,0))  
			FROM #payment_R					
			WHERE  #payment_R.idfin = #expense.idfin
				and #payment_R.idman = #expense.idman), 
	var_payment_R = (SELECT SUM(ISNULL(#var_payment_R.amount,0))  
			FROM #var_payment_R
			WHERE  #var_payment_R.idfin = #expense.idfin
				and #var_payment_R.idman = #expense.idman)
	IF @codelevel >= @levelusable
		BEGIN	
		UPDATE #expense
		SET	
		initialprevisioncomp= (SELECT SUM(ISNULL(finyear.prevision,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					where  finyear.idfin = #expense.idfin
					
					) ,
	  
		initialprevisioncassa = (SELECT SUM(ISNULL(finyear.secondaryprev,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					where fin.idfin = #expense.idfin
					
					)
		END 
	ELSE 
		BEGIN
		UPDATE #expense
		SET 
		initialprevisioncomp= (SELECT SUM(ISNULL(finyear.prevision,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin
					where ISNULL(finlink.idparent,finyear.idfin) = #expense.idfin
						AND fin.nlevel = @levelusable),
	  
		initialprevisioncassa = (SELECT SUM(ISNULL(finyear.secondaryprev,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin
					where   ISNULL(finlink.idparent,finyear.idfin) = #expense.idfin
						AND fin.nlevel = @levelusable)
	
		END
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------- CALCOLO DEL DISPONIBILE -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	UPDATE #expense
		SET 
		total_appropriation_C = (SELECT SUM(ISNULL(expenseyear.amount, 0))
					FROM expense
					JOIN expenseyear
						ON expenseyear.idexp = expense.idexp AND expenseyear.ayear = @ayear
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expense.adate between @start and @stop
						AND expense.nphase = @nfinphase
						AND ((expensetotal.flag&1)=0) --Competenza
						AND ISNULL(finlink.idparent, expenseyear.idfin) = #expense.idfin),
		
		total_var_appropriation_C = (SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN expenseyear
						ON expenseyear.idexp = expensevar.idexp AND expenseyear.ayear = @ayear
					join expense on expense.idexp = expenseyear.idexp
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND expense.nphase = @nfinphase
						AND ((expensetotal.flag&1)=0) --Competenza
						AND expensevar.adate between @start and @stop 
						AND ISNULL(finlink.idparent, expenseyear.idfin) = #expense.idfin),
		total_appropriation_R = (SELECT SUM(ISNULL(expenseyear.amount, 0))
					FROM expenseyear
					JOIN expense
						ON expense.idexp = expenseyear.idexp 
						and expenseyear.ayear = @ayear
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE ((expensetotal.flag&1)=1) --Residuo
						AND expense.nphase = @nfinphase
						AND expense.adate between @start and @stop
						AND ISNULL(finlink.idparent, expenseyear.idfin) = #expense.idfin),
		total_var_appropriation_R = ( SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN expenseyear
						ON expenseyear.idexp = expensevar.idexp 
						AND expenseyear.ayear = @ayear
					JOIN expense
						on expense.idexp = expenseyear.idexp
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND ((expensetotal.flag&1)=1) --Residuo
						AND expense.nphase = @nfinphase
						AND expensevar.adate between @start and @stop 
						AND ISNULL(finlink.idparent, expenseyear.idfin)  = #expense.idfin),
	
		total_payment_C = (SELECT SUM(ISNULL(paymentemitted.amount,0))
					FROM paymentemitted
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = paymentemitted.idfin AND 
						finlink.nlevel = @codelevel
					WHERE paymentemitted.competencydate between @start and @stop
						AND paymentemitted.ymov = @ayear
						AND paymentemitted.flagarrear = 'C'
						AND ISNULL(finlink.idparent,paymentemitted.idfin) = #expense.idfin),
		total_var_payment_C = (SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN paymentemitted
						ON paymentemitted.idexp = expensevar.idexp
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = paymentemitted.idfin  
						AND finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND paymentemitted.ymov = @ayear
						AND paymentemitted.flagarrear = 'C'
						AND expensevar.adate between @start and @stop
						AND ISNULL(finlink.idparent,paymentemitted.idfin)= #expense.idfin),
		total_payment_R = (SELECT SUM(ISNULL(paymentemitted.amount,0))
					FROM paymentemitted
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = paymentemitted.idfin AND 
						finlink.nlevel = @codelevel
					WHERE paymentemitted.competencydate between @start and @stop
						AND paymentemitted.flagarrear = 'R'
						AND paymentemitted.ymov = @ayear
						AND ISNULL(finlink.idparent,paymentemitted.idfin) = #expense.idfin),
		total_var_payment_R = ( SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN paymentemitted
						ON expensevar.idexp = paymentemitted.idexp
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = paymentemitted.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND paymentemitted.ymov = @ayear
						AND paymentemitted.flagarrear = 'R'
						AND expensevar.adate between @start and @stop
						AND ISNULL(finlink.idparent,paymentemitted.idfin ) = #expense.idfin)
					


if (@suppressifblank = 'S') and @codelevel>2	--> se la stampa è x un livello sottostante la categoria cancella le righe
	BEGIN
		DELETE FROM  #expense   
		WHERE  
		(ISNULL(initialprevisioncomp,0)= 0 AND 
		ISNULL(initialprevisioncassa,0)= 0 AND 
		ISNULL(finvar_prevision,0)= 0 AND
		ISNULL(finvar_secondaryprev,0)= 0 AND
		ISNULL(appropriation_C,0) = 0 AND
		ISNULL(var_appropriation_C,0)= 0 AND
		ISNULL(payment_C,0)= 0 and
		ISNULL(var_payment_C,0)= 0 AND
		ISNULL(appropriation_R,0)= 0 AND
		ISNULL(var_appropriation_R,0)= 0 AND
		ISNULL(payment_R,0)= 0 AND
		ISNULL(var_payment_R,0)= 0 AND
		ISNULL(appropriation_amount,0)=0 AND
		ISNULL(payment_amount,0)=0 
		AND (select nlevel from fin FFF where FFF.idfin= #expense.idfin)>=2
		)
	END

SELECT 
	#expense.idfin,
	F.codefin,
	F.title as fintitle,
	F.printingorder as finprintingorder,
	nphase,
	rowkind,
	sum(isnull(initialprevisioncomp,0)) as initialprevisioncomp,
	sum(isnull(initialprevisioncassa,0)) as  initialprevisioncassa , 
	sum(isnull(finvar_prevision,0)) as  finvar_prevision ,
	sum(isnull(finvar_secondaryprev,0)) as  finvar_secondaryprev ,	
	sum(isnull(appropriation_C,0)) as  appropriation_C ,
	sum(isnull(var_appropriation_C,0)) as  var_appropriation_C ,
	sum(isnull(payment_C,0)) as  payment_C ,
	sum(isnull(var_payment_C,0))as  var_payment_C ,
	sum(isnull(appropriation_R,0)) as  appropriation_R ,
	sum(isnull(var_appropriation_R,0)) as  var_appropriation_R ,
	sum(isnull(payment_R,0)) as  payment_R ,
	sum(isnull(var_payment_R,0)) as  var_payment_R ,
	adate,
	description,
	REG.title as registry,
	nappropriation,
	ymovappropriation,
	nmovappropriation,	
	sum(isnull(appropriation_amount,0)) as appropriation_amount,
	npayment,
	ymovpayment,
	nmovpayment,
	sum(isnull(payment_amount,0)) as  payment_amount,
	npay,
	flagarrear,
	reportdate,
	#expense.ayear,
	idappropriation,
	MAN.title as manager,
	#expense.idman,
	sum(isnull(total_appropriation_C,0)) as total_appropriation_C,
	sum(isnull(total_var_appropriation_C,0)) as total_var_appropriation_C,
	sum(isnull(total_appropriation_R,0)) as  total_appropriation_R,
	sum(isnull(total_var_appropriation_R,0))as total_var_appropriation_R,
	sum(isnull(total_payment_C,0)) as total_payment_C,
	sum(isnull(total_var_payment_C,0)) as total_var_payment_C,
	sum(isnull(total_payment_R,0)) as  total_payment_R,
	sum(isnull(total_var_payment_R,0))as total_var_payment_R  
FROM #expense
JOIN fin F
	ON #expense.idfin = F.idfin
JOIN manager MAN  
	ON #expense.idman = MAN.idman
LEFT OUTER JOIN registry REG
	On #expense.idreg = REG.idreg
GROUP BY  #expense.idman,MAN.title,		
	#expense.idfin,F.codefin,F.title,
	F.printingorder,nphase,
	rowkind,adate,description,REG.title,nappropriation,npayment,
	npay,flagarrear,reportdate,#expense.ayear,idappropriation,
	ymovappropriation,nmovappropriation,ymovpayment,nmovpayment	
ORDER BY manager,F.printingorder, rowkind, adate

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
