
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_spese_intestazione_respons]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_spese_intestazione_respons]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [rpt_partitario_spese_intestazione_respons]
	@ayear int,
	@idupb	varchar(36),
	@codelevel tinyint,
	@showupb char(1),
	@showchildupb char(1),
	@idman int,
	@suppressifblank char(1),
	@codefin varchar(50),
	@start datetime,
	@stop datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
BEGIN
declare @mystart smalldatetime
declare @mystop smalldatetime
set @mystart=convert(smalldatetime,@start)
set @mystop=convert(smalldatetime,@stop)


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

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@codelevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@codelevel < @level_input ) AND (@idfin is not null)
	BEGIN
	SET  @codelevel = @level_input
	END


DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel)
	FROM finlevel
	WHERE (flag&2)<>0  AND ayear = @ayear
IF @levelusable < @codelevel
BEGIN	
	SET @levelusable = @codelevel
END


DECLARE @idupboriginal 	varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END


-- considerare bene cosa succede quando voglio la stampa per articolo e specifico un capitolo in input
-- devo prendere i figli del capitolo specificato, aventi livello @codelevel


----modifica Piero-----


-- Nella logica di questi partitari la fase di spesa interessata deve essere quella di livelloo 
-- corrispondente all'anagrafica

DECLARE @nfinphase tinyint

select @nfinphase = expenseregphase
	FROM uniconfig

----fine modifica-----



-- ovvero prendo la massima fase tra quelle che contengono o il codice di bilancio o il creditore perchÃƒÂ¨ questÃƒÂ  ÃƒÂ¨ la vera fase di impegno giuridico
DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase)
FROM    expensephase 
-- ATTENZIONE L'ipotesi di funzionamento di questa sp è che fase dell'impegno = fase del pagamento - 1.
-- ALTRIMENTI SBALLA LE RIGHE DEL PAGAMENTO SUL REPORT (o meglio con un pò di tempo si deve fare un controllo per eliminare tutte le fasi 
-- che non sono fasepagamento e faseimpegno, anzi lo faccio subito inserendo alla fine una DELETE WHERE nphase <> fase del pagamento AND nphase <> fase dell'impegno)

CREATE TABLE #expense
(
	idfin int ,
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
	nphase tinyint,
	rowkind int,
	initialprevisioncomp decimal(19,2),
	initialprevisioncash decimal(19,2),
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
	available decimal(19,2),
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
	total_var_payment_R decimal(19,2),   -- N.B.: non serve calcolare i totali relativi alle previsioni e alle var di previsione 
	-- in quanto sono gia calcolati indipendentemente dal responsabile.
	emissiondate datetime,
	printeddate datetime,
	transmitteddate datetime,
	transactiondate datetime,
	annulmentdate datetime
)

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
	appropriation_amount,
	npayment, 
	ymovpayment,
	nmovpayment,
	payment_amount,
	npay,
	flagarrear,
	idappropriation,
	available,
	idman
)	--> prende quelli movimentati
SELECT 
	ISNULL(FL.idparent, expenseyear.idfin),
	upb.idupb,
	expense.nphase,
	expense.nphase-1,
	expense.adate,
	case isnull(expense.doc,'') when '' then expense.description 
	else  expense.description + ' (Doc. ' + isnull(Convert (varchar(35),expense.doc),'') + ' del '+ 
		isnull(Convert (varchar(2),datepart(dd,expense.docdate)),'')+ ' '+ 
		isnull(Convert (varchar(2),datepart(mm,expense.docdate)),'')+
		' '+ isnull(Convert (varchar(4),datepart(yy,expense.docdate)),'')+')'
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
	ET2.available,
	expense.idman
FROM expenseyear
JOIN expense
	ON expenseyear.idexp = expense.idexp 
JOIN upb
	ON upb.idupb = expenseyear.idupb
JOIN fin
	ON expenseyear.idfin = fin.idfin 
	AND expenseyear.ayear = fin.ayear
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear		
JOIN expenselink EL2
	ON EL2.idchild = expense.idexp  AND EL2.nlevel = @nfinphase  --adesso è la fase di registro (infatti solo il nome è lo stesso)
LEFT  OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin  AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1
	ON FL1.idchild = expenseyear.idfin  AND FL1.nlevel = @level_input
LEFT  OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT  OUTER JOIN payment
	ON expenselast.kpay = payment.kpay
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expense.idexp  AND EL3.nlevel = @maxexpensephase
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
JOIN expensetotal ET2
	ON ET2.idexp=E2.idexp
	AND ET2.ayear = expenseyear.ayear
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
WHERE ((fin.flag&1)=1) -- Spesa
	AND expenseyear.ayear = @ayear
	AND (@idfin IS NULL OR  isnull(FL1.idparent, expenseyear.idfin) = @idfin)		
	AND expense.adate between @mystart and @mystop
	AND ((expense.idman  = @idman) OR (@idman is null and expense.idman is not null))	
	AND ((expense.nphase IN (@nfinphase,@maxexpensephase )))
	AND (upb.idupb like @idupb) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


--select  'prima', * from #expense
IF (@suppressifblank = 'S')
BEGIN
	INSERT INTO #expense
		(
		idfin,
		idupb,
		idman
		)	--> Prende quelli non movimentati 1^ parte
	SELECT DISTINCT
		ISNULL(FL2.idparent, FD.idfin),
		upb.idupb,
		upb.idman
	FROM fin 
	JOIN finlink FL1
		ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
	JOIN finlink FL2
		ON FL2.idchild = fin.idfin AND FL2.nlevel = @codelevel
	JOIN finlink FL3
		ON FL3.idparent = fin.idfin
	join finvardetail FD 
		ON FD.idfin = FL3.idchild
	join finvar FVAR
		ON  FVAR.yvar = FD.yvar
		AND FVAR.nvar = FD.nvar
	JOIN upb 
		on FD.idupb=upb.idupb
	WHERE ((fin.flag&1)=1) --  Spesa	
		AND FVAR.idfinvarstatus = 5
		AND (@idfin IS NULL OR  isnull(FL1.idparent, FD.idfin) = @idfin)	
		AND (upb.idupb like @idupb ) 
		AND ((upb.idman  = @idman) OR (@idman is null and upb.idman is not null))	
		AND fin.ayear = @ayear
		AND NOT EXISTS (SELECT *
			FROM #expense
			WHERE upb.idupb = #expense.idupb 
			AND FL2.idparent = #expense.idfin
			AND upb.idman = #expense.idman)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
--select  'seconda', * from #expense
	INSERT INTO #expense
		(
		idfin,
		idupb,
		idman
		)	--> Prende quelli non movimentati 2^ parte
	SELECT distinct
		ISNULL(FL2.idparent, EY.idfin),
		upb.idupb,
		upb.idman
	FROM fin 
	JOIN finlink FL1
		ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
	JOIN finlink FL2
		ON FL2.idchild = fin.idfin AND FL2.nlevel = @codelevel
	JOIN finlink FL3
		ON FL3.idparent = fin.idfin
	join expenseyear EY 
		on EY.idfin = FL3.idchild and EY.ayear = fin.ayear
	JOIN upb 
		on EY.idupb=upb.idupb
	WHERE ((fin.flag&1)=1) -- Spesa
		AND (@idfin IS NULL OR isnull(FL1.idparent, EY.idfin) = @idfin)	
		AND (upb.idupb like @idupb ) 
		AND ((upb.idman  = @idman) OR (@idman is null and upb.idman is not null))	
		AND fin.ayear = @ayear
		AND NOT EXISTS (SELECT *
			FROM #expense
			WHERE upb.idupb = #expense.idupb 
			AND FL2.idparent = #expense.idfin
			AND upb.idman = #expense.idman)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

--select  'terza', * from #expense
	INSERT INTO #expense
		(
		idfin,
		idupb,
		idman
		)	--> Prende quelli non movimentati 3^ parte
	SELECT distinct
		isnull(FL2.idparent, FY.idfin),
		upb.idupb,
		upb.idman
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
	JOIN upb 
		on FY.idupb=upb.idupb
	WHERE ((fin.flag&1)=1) -- Spesa
		AND (@idfin IS NULL OR isnull(FL1.idparent, FY.idfin) = @idfin)	
		AND (upb.idupb like @idupb ) 
		AND ((upb.idman  = @idman) OR (@idman is null and upb.idman is not null))	
		AND fin.ayear = @ayear
		AND NOT EXISTS (SELECT *
			FROM #expense
			WHERE upb.idupb = #expense.idupb 
			AND FL2.idparent = #expense.idfin
			AND upb.idman = #expense.idman)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
END
ELSE
BEGIN
	INSERT INTO #expense
		(
		idfin,
		idupb,
		idman
		)	--> Prende quelli non movimentati 
	SELECT 
		fin.idfin,
		upb.idupb,
		upb.idman
	FROM fin CROSS JOIN upb 
	LEFT OUTER JOIN finlink FL1
		ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
	WHERE ((fin.flag&1)=1) -- Spesa	
		AND (@idfin IS NULL 
		OR  (FL1.idparent = @idfin AND @idfin is NOT NULL))	
		AND (upb.idupb LIKE @idupb ) 
		AND ((upb.idman  = @idman) OR (@idman is null and upb.idman is not null))	
		AND fin.nlevel = @codelevel
		AND fin.ayear = @ayear
		AND NOT EXISTS (SELECT *
			FROM #expense
			WHERE upb.idupb = #expense.idupb 
			AND fin.idfin = #expense.idfin
			AND upb.idman = #expense.idman )
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
--select  'quinta', * from #expense
END
-- La parte eseguente l'ho commentata perchè dovendo calcolare (non solo le var degli upb con resp.) anche le var. degli upb senza resp movimentati
-- ho sposatto questo calcolo in fondo alla SP come per il calcolo della prev. Alla fine lui calcolerà le var di prev e la prev degli upb 
-- inseriti nel tabellone. Il calcolo sembra anche + veloce.

CREATE TABLE #appropriation_C
    (
	idfin int,
	idupb varchar(36),
	idman int,
	amount decimal(19,2)			 
    )
INSERT INTO #appropriation_C
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	expense.idman,
	SUM(ISNULL(expenseyear.amount, 0))
FROM expense
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp  
	AND expenseyear.ayear = @ayear
JOIN upb
	ON upb.idupb = expenseyear.idupb
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp 
	AND expenseyear.ayear = expensetotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE expense.adate between @mystart and @mystop
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((expense.idman  = @idman) OR (@idman is null and expense.idman is not null))	
	AND ((expensetotal.flag&1)=0) --Competenza
	AND expense.nphase = @nfinphase
	AND (expenseyear.idupb like @idupb) 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),expense.idman

--select '#appropriation_C', * from #appropriation_C
CREATE TABLE #var_appropriation_C
    (
	idfin int,
	idupb varchar(36),
	idman int,
	amount decimal(19,2)					 
    )
INSERT INTO #var_appropriation_C
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	expense.idman,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
	AND expenseyear.ayear = @ayear
JOIN upb
	ON upb.idupb = expenseyear.idupb
JOIN expense 
	ON expense.idexp = expenseyear.idexp
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp 
	AND expenseyear.ayear = expensetotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)=0) --Competenza
	AND expense.nphase = @nfinphase
	AND expensevar.adate between @mystart and @mystop 
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND (expenseyear.idupb like @idupb) 
	AND ((expense.idman  = @idman) OR (@idman is null and expense.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),expense.idman

CREATE TABLE #appropriation_R
    (
	idfin int,
	idupb varchar(36), 
	idman int,
	amount decimal(19,2)					 
    )
INSERT INTO #appropriation_R
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	expense.idman,
	SUM(ISNULL(expenseyear.amount, 0))
FROM expenseyear
JOIN expense
	ON expense.idexp = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN upb
	ON upb.idupb = expenseyear.idupb
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE  ((expensetotal.flag&1)=1) --Residuo
	AND expense.nphase = @nfinphase
	AND expense.adate between @mystart and @mystop
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)
	AND (expenseyear.idupb like @idupb) 
	AND ((expense.idman  = @idman) OR (@idman is null and expense.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),expense.idman

CREATE TABLE #var_appropriation_R
    (
	idfin int,
	idupb varchar(36),
	idman int,
	amount decimal(19,2)					 
    )
INSERT INTO #var_appropriation_R
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	expense.idman,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp	
	AND expenseyear.ayear = @ayear
JOIN upb
	ON upb.idupb = expenseyear.idupb
JOIN expense on expense.idexp = expenseyear.idexp
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear 
LEFT OUTER JOIN finlink ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)=1) --Residuo
	AND expense.nphase = @nfinphase
	AND expensevar.adate between @mystart and @mystop 
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND (expenseyear.idupb like @idupb) 
	AND ((expense.idman  = @idman) OR (@idman is null and expense.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),expense.idman

CREATE TABLE #payment_C
    (
	idfin int,
	idupb varchar(36),
	idman int,
	amount decimal(19,2)					 
    )

INSERT INTO #payment_C
	(
	idfin,
	idupb,
	idman,
	amount   
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	expense.idman,
	SUM(ISNULL(paymentemitted.amount,0))
FROM expenseyear
JOIN paymentemitted
	ON expenseyear.idexp = paymentemitted.idexp AND expenseyear.ayear = @ayear
JOIN expense on expense.idexp = expenseyear.idexp
JOIN upb
	ON upb.idupb = expenseyear.idupb
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE paymentemitted.competencydate between @mystart and @mystop
	AND  ((expensetotal.flag&1)=0) --Competenza
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND (expenseyear.idupb like @idupb) 
	AND ((expense.idman  = @idman) OR (@idman is null and expense.idman is not null))	 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),expense.idman
--select '#payment_C', * from #payment_C
CREATE TABLE #payment_R
    (
	idfin int,
	idupb varchar(36),
	idman int,
	amount decimal(19,2)					 
    )
INSERT INTO #payment_R
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	expense.idman,
	SUM(ISNULL(paymentemitted.amount,0))
FROM paymentemitted
JOIN expenseyear
	ON expenseyear.idexp = paymentemitted.idexp 
	AND expenseyear.ayear = @ayear
JOIN upb
	ON upb.idupb = expenseyear.idupb
JOIN expense 
	ON expense.idexp = expenseyear.idexp
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
WHERE paymentemitted.competencydate between @mystart and @mystop
	AND (paymentemitted.flagarrear='R') --Residuo
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin )	
	AND (expenseyear.idupb like @idupb) 
	AND ((expense.idman  = @idman) OR (@idman is null and expense.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),expense.idman

CREATE TABLE #var_payment_C
    (
	idfin int,
	idupb varchar(36),
	idman int,
	amount decimal(19,2)					 
    )
INSERT INTO #var_payment_C
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	expense.idman,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
	AND expenseyear.ayear = @ayear
JOIN upb
	ON upb.idupb = expenseyear.idupb
JOIN expense on expense.idexp = expenseyear.idexp
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
	AND ((expensetotal.flag&1)=0) --Competenza
	AND expensevar.adate between @mystart and @mystop
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND (expenseyear.idupb like @idupb) 
	AND expensevar.idexp IN (select idexp from paymentemitted)
	AND ((expense.idman  = @idman) OR (@idman is null and expense.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),expense.idman

CREATE TABLE #var_payment_R
    (
	idfin  int,
	idupb  varchar(36),
	idman  int,
	amount decimal(19,2)					 
    )
INSERT INTO #var_payment_R
	(
	idfin,
	idupb,
	idman,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	expense.idman,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
	AND expenseyear.ayear = @ayear
JOIN upb
	ON upb.idupb = expenseyear.idupb
JOIN expense on expense.idexp = expenseyear.idexp
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
	AND ((expensetotal.flag&1)=1) --Residuo
	AND expensevar.adate between @mystart and @mystop
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND (expenseyear.idupb like @idupb) 
	AND expensevar.idexp IN (select idexp FROM paymentemitted)
	AND ((expense.idman  = @idman) OR (@idman is null and expense.idman is not null))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),expense.idman



UPDATE #expense
	SET
	codeupb = (select codeupb from upb where upb.idupb = #expense.idupb),
	upb = (select title from upb where upb.idupb = #expense.idupb),
	upbprintingorder = (select printingorder from upb where upb.idupb = #expense.idupb)

IF (@showupb ='S') 
BEGIN
UPDATE #expense
	SET
	finvar_prevision = ISNULL((SELECT SUM(ISNULL(finvardetail.amount,0))
				FROM finvardetail
				JOIN finvar
					ON finvar.yvar = finvardetail.yvar
					AND finvar.nvar = finvardetail.nvar
				LEFT OUTER JOIN finlink 
					ON finlink.idchild = finvardetail.idfin 
					AND finlink.nlevel = @codelevel
				WHERE finvar.flagprevision ='S'	
					AND finvar.idfinvarstatus = 5
					AND finvar.variationkind <> 5
					AND finvar.adate between @mystart and @mystop
					AND finvar.yvar = @ayear
					AND ISNULL(finlink.idparent,finvardetail.idfin) = #expense.idfin 
					AND finvardetail.idupb = #expense.idupb), 0),
	finvar_secondaryprev = ISNULL((SELECT SUM(ISNULL(finvardetail.amount,0))
				FROM finvardetail
				JOIN finvar
					ON finvar.yvar = finvardetail.yvar
					AND finvar.nvar = finvardetail.nvar
				LEFT OUTER JOIN finlink 
					ON finlink.idchild = finvardetail.idfin 
					AND finlink.nlevel = @codelevel
				WHERE finvar.flagsecondaryprev ='S'	
					AND finvar.idfinvarstatus = 5
					AND finvar.variationkind <> 5
					AND finvar.adate between @mystart and @mystop
					AND finvar.yvar = @ayear
					AND ISNULL(finlink.idparent,finvardetail.idfin) = #expense.idfin 
					AND finvardetail.idupb = #expense.idupb), 0),
	
	appropriation_C =ISNULL((SELECT #appropriation_C.amount 
				FROM #appropriation_C
				WHERE #appropriation_C.idupb = #expense.idupb
					and #appropriation_C.idfin = #expense.idfin 
					and #appropriation_C.idman = #expense.idman), 0),
	var_appropriation_C =ISNULL((SELECT #var_appropriation_C.amount 
				FROM #var_appropriation_C
				WHERE #var_appropriation_C.idupb = #expense.idupb
					and #var_appropriation_C.idfin = #expense.idfin 
					and #var_appropriation_C.idman = #expense.idman), 0),
	payment_C =ISNULL((SELECT #payment_C.amount 
				FROM #payment_C
				WHERE #payment_C.idupb = #expense.idupb
					and #payment_C.idfin = #expense.idfin
					and #payment_C.idman = #expense.idman), 0),
	var_payment_C =ISNULL((SELECT #var_payment_C.amount 
				FROM #var_payment_C
				WHERE #var_payment_C.idupb = #expense.idupb
					and  #var_payment_C.idfin = #expense.idfin
					and  #var_payment_C.idman = #expense.idman), 0),
  	appropriation_R =ISNULL((SELECT #appropriation_R.amount 
				FROM #appropriation_R
				WHERE #appropriation_R.idupb = #expense.idupb
					and #appropriation_R.idfin = #expense.idfin
					and #appropriation_R.idman = #expense.idman), 0),
	var_appropriation_R =ISNULL((SELECT #var_appropriation_R.amount 
				FROM #var_appropriation_R
				WHERE #var_appropriation_R.idupb = #expense.idupb
					and #var_appropriation_R.idfin = #expense.idfin
					and #var_appropriation_R.idman = #expense.idman), 0),
	payment_R =ISNULL((SELECT #payment_R.amount 
				FROM #payment_R					
				WHERE #payment_R.idupb = #expense.idupb
					and #payment_R.idfin = #expense.idfin
					and #payment_R.idman = #expense.idman), 0),
	var_payment_R = ISNULL((SELECT #var_payment_R.amount 
			FROM #var_payment_R
			WHERE #var_payment_R.idupb = #expense.idupb
				and #var_payment_R.idfin = #expense.idfin
				and #var_payment_R.idman = #expense.idman), 0)
	
	IF @codelevel >= @levelusable
		BEGIN	
		UPDATE #expense
		SET	initialprevisioncomp= ISNULL((SELECT finyear.prevision 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					WHERE finyear.idupb = #expense.idupb AND 
						finyear.idfin = #expense.idfin),0),
	
			initialprevisioncash = ISNULL((SELECT finyear.secondaryprev 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					WHERE finyear.idupb = #expense.idupb AND 
						finyear.idfin = #expense.idfin),0)
		
		END  
	ELSE 
	BEGIN
		UPDATE #expense
		SET initialprevisioncomp = ISNULL((SELECT SUM(isnull(finyear.prevision,0)) 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					JOIN finlink 
						ON finlink.idchild = finyear.idfin 
					WHERE finyear.idupb = #expense.idupb AND 
						finlink.idparent =  #expense.idfin
						AND fin.nlevel = @levelusable),0) ,

		initialprevisioncash = ISNULL((SELECT SUM(isnull(finyear.secondaryprev,0)) 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					JOIN finlink 
						ON finlink.idchild = finyear.idfin 
					WHERE finyear.idupb = #expense.idupb AND 
						finlink.idparent =  #expense.idfin
						AND fin.nlevel = @levelusable),0)
		
		END 
	
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------- CALCOLO DEL DISPONIBILE -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	UPDATE #expense
	SET 
		total_appropriation_C = ISNULL((SELECT SUM(ISNULL(expenseyear.amount, 0))
					FROM expense
					JOIN expenseyear
						ON expenseyear.idexp = expense.idexp 
						AND expenseyear.ayear = @ayear
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp 
						AND expenseyear.ayear = expensetotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expense.adate between @mystart and @mystop
						AND expense.nphase = @nfinphase
						AND ((expensetotal.flag&1)=0) --Competenza
						AND expenseyear.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),0),

		total_var_appropriation_C = ISNULL((SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN expense
						ON expense.idexp = expensevar.idexp
					JOIN expenseyear
						ON expenseyear.idexp = expensevar.idexp 
						AND expenseyear.ayear = @ayear
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND expense.nphase = @nfinphase
						AND ((expensetotal.flag&1)=0) --Comptenza
						AND expensevar.adate between @mystart and @mystop 
						AND expenseyear.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),0),
		total_appropriation_R = ISNULL((SELECT SUM(ISNULL(expenseyear.amount, 0))
					FROM expenseyear
					JOIN expense
						ON expense.idexp = expenseyear.idexp 
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE  ((expensetotal.flag&1)=1) --Residuo
						AND expense.nphase = @nfinphase
						AND expenseyear.ayear = @ayear
						AND expense.adate between @mystart and @mystop
						AND expenseyear.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),0),
		total_var_appropriation_R = ISNULL((SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN expense
						ON expense.idexp = expensevar.idexp
					JOIN expenseyear
						ON expenseyear.idexp = expensevar.idexp 
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND ((expensetotal.flag&1)=1) --Residuo
						AND expenseyear.ayear = @ayear
						AND expense.nphase = @nfinphase
						AND expensevar.adate between @mystart and @mystop 
						AND expenseyear.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),0),
		total_payment_C = ISNULL((SELECT SUM(ISNULL(paymentemitted.amount,0))
					FROM expenseyear
					JOIN paymentemitted
						ON expenseyear.idexp = paymentemitted.idexp 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE paymentemitted.competencydate between @mystart and @mystop
						AND (paymentemitted.flagarrear='C') --Competenza
						AND expenseyear.ayear = @ayear
						AND paymentemitted.nphase = @maxexpensephase
						AND expenseyear.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),0),
		total_var_payment_C = ISNULL((SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN expense
						ON expensevar.idexp = expense.idexp
					JOIN expenseyear
						ON expenseyear.idexp = expensevar.idexp 
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND ((expensetotal.flag&1)=0) --Competenza
						AND expenseyear.ayear = @ayear
						AND expense.nphase = @maxexpensephase
						AND expensevar.adate between @mystart and @mystop
						AND expensevar.idexp IN (select idexp from paymentemitted)
						AND expenseyear.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),0),
		total_payment_R = ISNULL((SELECT SUM(ISNULL(paymentemitted.amount,0))
					FROM paymentemitted
					JOIN expenseyear
						ON expenseyear.idexp = paymentemitted.idexp 
					JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE paymentemitted.competencydate between @mystart and @mystop
						AND (paymentemitted.flagarrear = 'R') --Residuo
						AND expenseyear.ayear = @ayear
						AND paymentemitted.nphase = @maxexpensephase
						AND expenseyear.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),0),
		total_var_payment_R = ISNULL((SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN expense
						ON expense.idexp = expensevar.idexp
					JOIN expenseyear
						ON expenseyear.idexp = expensevar.idexp 
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND ((expensetotal.flag&1)=1) --Residuo
						AND expense.nphase = @maxexpensephase
						AND expenseyear.ayear = @ayear
						AND expensevar.adate between @mystart and @mystop
						AND expensevar.idexp IN (select idexp from paymentemitted)
						AND expenseyear.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),0)
END

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

UPDATE #expense
SET
	appropriation_amount = appropriation_amount + 
		(SELECT ISNULL(SUM(amount),0) 
		FROM expensevar
		JOIN expense 
		  ON expensevar.idexp = expense.idexp
		WHERE expensevar.idexp = #expense.nappropriation
		AND expensevar.adate between @mystart and @mystop
		AND expensevar.yvar = @ayear
		AND expense.nphase  = @nfinphase 
		),
	payment_amount = payment_amount + 
		(SELECT ISNULL(SUM(amount),0) FROM expensevar
		JOIN expense ON expensevar.idexp = expense.idexp
		WHERE expensevar.idexp = #expense.npayment
		and expensevar.adate between @mystart and @mystop
		and expensevar.yvar = @ayear
		and expense.nphase  = @maxexpensephase
		),
	reportdate =@mystop,
	ayear=@ayear

------------------------------------------- <	     NEW        > ----------------------------------------------------------------	
-- SE ho scelto di totalizzare i figli dell'UPB selezionato (N, 'pippo',S)
-- O SE ho scelto di non vedere l'upb (N,N)  
-- ALLORA totalizzo gli importi
-- Se ho scelto di vedere l'upb (con o senza figli :  S/N o S/S) saranno presi i valori calcolati sopra 
-- che saranno stati calcolati distinguendo gli upb-padri dagli upb-figli.
-- select * from #expense
IF (@showupb <>'S') 
BEGIN
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
				AND finvar.adate between @mystart and @mystop
				AND finvar.yvar = @ayear
				AND ISNULL(finlink.idparent,finvardetail.idfin) = #expense.idfin 
				AND finvardetail.idupb  like @idupb), 0),
-- il like è stato tolto perchè posso avere un upb figlio con responsabile <> dal padre, con il like non era possibile distinguere i casi. 
--In questo modo, invece, calcolo la var. su ciascun upb, dopo andrò a fare un update sugli idupb con @idupb 
-- e poi una stampa raggruppata per responsabile.
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
				AND finvar.adate between @mystart and @mystop
				AND finvar.yvar = @ayear
				AND ISNULL(finlink.idparent,finvardetail.idfin)  = #expense.idfin 
				AND finvardetail.idupb like @idupb), 0),
	appropriation_C = (SELECT SUM(ISNULL(#appropriation_C.amount,0))  
				FROM #appropriation_C
				WHERE #appropriation_C.idupb like @idupb
					and #appropriation_C.idfin = #expense.idfin
					and #appropriation_C.idman = #expense.idman), 
	var_appropriation_C = (SELECT SUM(ISNULL(#var_appropriation_C.amount,0))  
				FROM #var_appropriation_C
				WHERE #var_appropriation_C.idupb like @idupb
					and #var_appropriation_C.idfin = #expense.idfin
					and #var_appropriation_C.idman = #expense.idman),
	payment_C = (SELECT SUM(ISNULL(#payment_C.amount,0))  
				FROM #payment_C
				WHERE #payment_C.idupb like @idupb
					and #payment_C.idfin = #expense.idfin
					and #payment_C.idman = #expense.idman), 
	var_payment_C = (SELECT SUM(ISNULL(#var_payment_C.amount,0))  
				FROM #var_payment_C
				WHERE #var_payment_C.idupb like @idupb
					and  #var_payment_C.idfin = #expense.idfin
					and #var_payment_C.idman = #expense.idman),
  	appropriation_R =(SELECT SUM(ISNULL(#appropriation_R.amount,0))  
				FROM #appropriation_R
				WHERE #appropriation_R.idupb like @idupb
					and #appropriation_R.idfin = #expense.idfin
					and #appropriation_R.idman = #expense.idman), 
	var_appropriation_R =(SELECT SUM(ISNULL(#var_appropriation_R.amount,0))  
				FROM #var_appropriation_R
				WHERE #var_appropriation_R.idupb like @idupb
					and #var_appropriation_R.idfin = #expense.idfin
					and #var_appropriation_R.idman = #expense.idman), 
	payment_R =(SELECT SUM(ISNULL(#payment_R.amount,0))  
			FROM #payment_R					
			WHERE #payment_R.idupb like @idupb
				and #payment_R.idfin = #expense.idfin
				and #payment_R.idman = #expense.idman), 
	var_payment_R = (SELECT SUM(ISNULL(#var_payment_R.amount,0))  
			FROM #var_payment_R
			WHERE #var_payment_R.idupb like @idupb
				and #var_payment_R.idfin = #expense.idfin
				and #var_payment_R.idman = #expense.idman)

	IF @codelevel >= @levelusable
		BEGIN	
		UPDATE #expense
		SET	
		initialprevisioncomp= (SELECT SUM(ISNULL(finyear.prevision,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					where finyear.idupb like @idupb	
						AND finyear.idfin = #expense.idfin
					--and upb.idman = #expense.idman	
					) ,
	  
		initialprevisioncash = (SELECT SUM(ISNULL(finyear.secondaryprev,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					where upb.idupb  like @idupb	
						AND fin.idfin = #expense.idfin
					--and upb.idman = #expense.idman	
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
					JOIN upb
						ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin
					WHERE finyear.idupb like @idupb
					AND ISNULL(finlink.idparent,finyear.idfin) = #expense.idfin
					AND fin.nlevel =  @levelusable),
	  
		initialprevisioncash = (SELECT SUM(ISNULL(finyear.secondaryprev,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin
					WHERE upb.idupb like @idupb 
					AND ISNULL(finlink.idparent,finyear.idfin) = #expense.idfin
					AND fin.nlevel =  @levelusable)
	
		END

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------- CALCOLO DEL DISPONIBILE -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	update #expense
		SET 
		total_appropriation_C = (SELECT SUM(ISNULL(expenseyear.amount, 0))
					FROM expense
					JOIN expenseyear
						ON expenseyear.idexp = expense.idexp 
						AND expenseyear.ayear = @ayear
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear 
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expense.adate between @mystart and @mystop
						AND expense.nphase = @nfinphase
						AND ((expensetotal.flag&1)=0) --Comptenza
						AND expenseyear.idupb like @idupb
						AND ISNULL(finlink.idparent,expenseyear.idfin)  = #expense.idfin),
		
		total_var_appropriation_C = (SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN expense
						ON expense.idexp = expensevar.idexp
					JOIN expenseyear
						ON expenseyear.idexp = expensevar.idexp AND expenseyear.ayear = @ayear
					JOIN expensetotal 
						ON expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN  finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND expense.nphase = @nfinphase
						AND ((expensetotal.flag&1)=0) --Comptenza
						AND expensevar.adate between @mystart and @mystop 
						AND expenseyear.idupb like @idupb
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),
		total_appropriation_R = (SELECT SUM(ISNULL(expenseyear.amount, 0))
					FROM expenseyear
					JOIN expense
						ON expense.idexp = expenseyear.idexp 
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN  finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE ((expensetotal.flag&1)=1) --Residuo
						AND expense.nphase = @nfinphase
						AND expense.adate between @mystart and @mystop
						AND expenseyear.ayear = @ayear
						AND expenseyear.idupb like @idupb
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),
		total_var_appropriation_R = ( SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN expenseyear
						ON expenseyear.idexp = expensevar.idexp 
						AND expenseyear.ayear = @ayear
					JOIN expense
						ON expense.idexp = expensevar.idexp
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND ((expensetotal.flag&1)=1) --Reesiduo
						AND expense.nphase = @nfinphase
						AND expensevar.adate between @mystart and @mystop 
						AND expenseyear.idupb like @idupb 
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),
	
		total_payment_C = (SELECT SUM(ISNULL(paymentemitted.amount,0))
					FROM expenseyear
					JOIN paymentemitted
						ON expenseyear.idexp = paymentemitted.idexp AND expenseyear.ayear = @ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE paymentemitted.competencydate between @mystart and @mystop
						AND (paymentemitted.flagarrear= 'C') --Comptenza
						AND expenseyear.idupb like @idupb
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),
		total_var_payment_C = (SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN expense
						ON expense.idexp = expensevar.idexp
					JOIN expenseyear
						ON expenseyear.idexp = expensevar.idexp 
						AND expenseyear.ayear = @ayear
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND ((expensetotal.flag&1)=0) --Comptenza
						AND expense.nphase = @maxexpensephase
						AND expensevar.adate between @mystart and @mystop
						AND expensevar.idexp IN (select idexp from paymentemitted)
						and expenseyear.idupb like @idupb
						and ISNULL(finlink.idparent,expenseyear.idfin)= #expense.idfin),
		total_payment_R = (SELECT SUM(ISNULL(paymentemitted.amount,0))
					FROM paymentemitted
					JOIN expenseyear
						ON expenseyear.idexp = paymentemitted.idexp AND expenseyear.ayear = @ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE paymentemitted.competencydate between @mystart and @mystop
						AND (paymentemitted.flagarrear='R') --Residuo
						AND paymentemitted.nphase = @maxexpensephase
						and expenseyear.idupb like @idupb
						and ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),
		total_var_payment_R = ( SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN expenseyear
						ON expenseyear.idexp = expensevar.idexp 
						AND expenseyear.ayear = @ayear
					JOIN expense
						ON expense.idexp = expensevar.idexp
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND ((expensetotal.flag&1)=1) --Residuo
						AND expense.nphase = @maxexpensephase
						AND expensevar.adate between @mystart and @mystop
						AND expensevar.idexp IN (select idexp from paymentemitted)
						AND expenseyear.idupb like @idupb
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin)
					
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--select * from #expense
END
-- cancello le righe dei figli di @idupboriginal aventi idappropriation = NULL
-- Se ho scelto l'upb ne cancello i figli perchè li ho totalizzati tramite la nuova UPDATE
/*IF (@showupb <>'S') and (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		DELETE FROM #expense WHERE idappropriation is null 
						AND substring(idupb,1,len(@idupboriginal))= @idupboriginal 	
						AND idupb <>@idupboriginal
*/						
-- cancello solo le righe che sono upb-figli aventi idappropriation = NULL
-- Se non ho scelto alcun upb cancello solo gli upb padri con lo stesso resp. del figlio perchè li ho totalizzati tramite la nuova UPDATE
   
/*IF (@showupb <>'S') 
		DELETE FROM #expense WHERE idappropriation IS NULL 
			AND EXISTS (SELECT * FROM #expense R 
					join upb U 
					on U.idupb=R.idupb  
					WHERE U.paridupb = #expense.idupb 
					and U.idman=#expense.idman )
*/					
-- se questa condizione è soffisfatta è significa che avrò (x es.) due roghe, di cui una ha l0info dell'impegno
-- l'altra ma entrambe avranno i medesimi importi per le prev. e gli importi dei mov. in quanto li ho totalizzate sopra
-- Se non procedo con questa cancellazione nell'istruzione succezziva sui esegue l'update sull'idupb
-- poi farà il raggruppamento finale raddoppiando (erroneamente) gli importi.
IF (@showupb <>'S') 
		DELETE FROM #expense WHERE idappropriation IS NULL 
			AND EXISTS (SELECT * FROM #expense S 
					WHERE S.idfin = #expense.idfin 
					and S.idman = #expense.idman 
					and S.idupb <>	#expense.idupb)

----------------------------------------------------------------------------------------------------------------------------------
	IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
			UPDATE #expense SET  
				upbprintingorder = (SELECT TOP 1 printingorder
					FROM upb--#expense -- perchè nel tabellone posso non avere il padre quindi non avrò le info che mi servono
					WHERE idupb = @idupboriginal),
				upb = (SELECT TOP 1 title
					FROM upb
					WHERE idupb = @idupboriginal),
				idupb = @idupboriginal,
				codeupb =(SELECT TOP 1 codeupb
					FROM upb	
					WHERE idupb = @idupboriginal)
	
	IF (@showupb <>'S') and (@idupboriginal = '%')
				UPDATE #expense SET  
				upbprintingorder = null	,
				upb =  null,
				idupb = null,
				codeupb = null
	
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--  ****************************************************************************************************************** --
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


CREATE TABLE #expenseprec
(
	idupb varchar(36),
	prevision decimal(19,2),
	finvar_prevision decimal(19,2),
	appropriation decimal(19,2),
	var_appropriation decimal(19,2)
)
-- questi calcoli li fa solo se vuoi vedere l'upb,perchè sono info relative ad essso
-- IF parametto mostra info = S  and mostra upb = S

DECLARE @secprevisionkind    char(1) 
SELECT  @secprevisionkind  = 
	 CASE 
		WHEN fin_kind = 3 THEN 'S'
		ELSE NULL
	END
FROM config 
WHERE config.ayear = @ayear

DECLARE @param char
SELECT  @param = isnull(paramvalue,'N') FROM reportadditionalparam 
WHERE paramname = 'MostraInfoAnniPrecedenti'
AND (
	(@secprevisionkind is not null AND reportname='partitario_spese_intestazione_respons')
	OR
	 (@secprevisionkind is null and reportname= 'partitario_spese_intestazione_respons_singprev')
	)

IF (@param='S' and @showupb ='S')
BEGIN
	insert into #expenseprec
	(
	idupb,
	prevision 
	)
	SELECT 
		FY.idupb,
		ISNULL(SUM(FY.prevision),0)
	FROM finyearview FY 
	WHERE  FY.finpart = 'S'
		AND FY.ayear = @ayear
		AND FY.nlevel = (SELECT MIN(nlevel) FROM finlevel 
				WHERE FY.ayear = @ayear   AND (flag&2)<>0)
	AND FY.idupb in (select distinct idupb from #expense)
	GROUP BY FY.idupb

	UPDATE #expenseprec
	SET finvar_prevision = (SELECT ISNULL(SUM(d.amount),0)
				FROM finvar v
				JOIN finvardetail d
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				JOIN fin f
					ON f.idfin = d.idfin 
				WHERE d.idupb = #expenseprec.idupb
					AND v.idfinvarstatus = 5
					AND ((f.flag & 1) = 1 )
					AND v.yvar = @ayear
					AND v.adate <= @mystop
					AND v.variationkind <> 5
					AND v.flagprevision = 'S'),
	
	appropriation = (SELECT ISNULL(SUM(expenseyear.amount),0)
				FROM expense
				JOIN expenseyear
					ON expense.idexp = expenseyear.idexp
					AND expense.ymov = expenseyear.ayear
				WHERE expense.ymov < @ayear
					AND expenseyear.idupb = #expenseprec.idupb
					AND expense.nphase = @nfinphase ),
	var_appropriation = (SELECT ISNULL(SUM(expensevar.amount),0)
				FROM expense
				JOIN expensevar
					ON expense.idexp = expensevar.idexp
				JOIN expenseyear
					ON expense.idexp = expenseyear.idexp
					AND expense.ymov = expenseyear.ayear
				WHERE expense.ymov < @ayear
					AND expensevar.yvar <= @ayear
					AND expenseyear.ayear < @ayear
					AND expensevar.adate <= @mystop
					AND expenseyear.idupb = #expenseprec.idupb
					AND expense.nphase = @nfinphase)
	
END

--previsione iniziale : SET @expenseprevision = @expenseprevision + @prev_arrears
--Variazioni: @expensevar
--Tot Previsione  ISNULL(@expenseprevision, 0) + ISNULL(@expensevar, 0)

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--  ****************************************************************************************************************** --
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

if (@suppressifblank = 'S') and @codelevel>2	--> se la stampa è x un livello sottostante la categoria cancella le righe
	BEGIN
		DELETE 
		FROM  #expense   
		WHERE  
		(ISNULL(initialprevisioncomp,0)= 0 AND 
		ISNULL(initialprevisioncash,0)= 0 AND 
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

UPDATE #expense
	SET 	emissiondate = paymentview.adate,
		printeddate = 	paymentview.printdate,
		transmitteddate = paymentview.transmissiondate,	
		transactiondate = paymentperformed.competencydate,
		annulmentdate = paymentview.annulmentdate
FROM paymentview
LEFT OUTER JOIN banktransaction
	ON banktransaction.kpay=paymentview.kpay	
	AND (banktransaction.kind='D' OR banktransaction.kind IS NULL)
LEFT OUTER JOIN paymentperformed 
	ON paymentperformed.npay=paymentview.npay
	AND paymentperformed.ypay=paymentview.ypay
WHERE #expense.npay = paymentview.npay
	AND paymentview.ypay=@ayear

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
		sum(isnull(initialprevisioncomp,0)) as initialprevisioncomp,
		sum(isnull(initialprevisioncash,0)) as  initialprevisioncash , 
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
		sum(isnull(available,0)) as available,
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
		sum(isnull(total_var_payment_R,0))as total_var_payment_R  ,
		0 as  prevision_prec,
		0 as  appropriation_prec,
		emissiondate,printeddate,transmitteddate,transactiondate,annulmentdate
	FROM #expense
	JOIN fin F
		ON #expense.idfin = F.idfin
	JOIN manager MAN  
		ON #expense.idman = MAN.idman
	LEFT OUTER JOIN registry REG
		On #expense.idreg = REG.idreg
	GROUP BY  #expense.idman,MAN.title,		
		#expense.idfin,F.codefin,F.title,
		F.printingorder,codeupb,idupb,upb,upbprintingorder,nphase,
		rowkind,adate,description,REG.title,nappropriation,npayment,
		npay,flagarrear,reportdate,#expense.ayear,idappropriation,
		ymovappropriation,nmovappropriation,ymovpayment,nmovpayment,
		emissiondate,printeddate,transmitteddate,transactiondate,annulmentdate	
	ORDER BY manager,upbprintingorder,F.printingorder, rowkind, adate
END
ELSE
BEGIN
	SELECT
		#expense.idfin,
		F.codefin,
		F.title as fintitle,
		F.printingorder as finprintingorder,
		codeupb,
		#expense.idupb,
		upb,
		upbprintingorder,
		nphase,
		rowkind,
		initialprevisioncomp,
		initialprevisioncash , 
		#expense.finvar_prevision,
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
		appropriation_amount ,
		available,
		npayment,
		ymovpayment,
		nmovpayment,
		payment_amount, 
		npay,
		flagarrear,
		reportdate,
		#expense.ayear,
		idappropriation,
		MAN.title as manager,
		#expense.idman,
		total_appropriation_C ,	
		total_var_appropriation_C,
		total_appropriation_R,
		total_var_appropriation_R,
		total_payment_C,
		total_var_payment_C,
		total_payment_R,
		total_var_payment_R  ,

		isnull(prec.prevision,0) + isnull(prec.finvar_prevision,0) 
		+ isnull(prec.appropriation,0)+isnull(prec.var_appropriation,0) as  prevision_prec,
		isnull(prec.appropriation,0)+isnull(prec.var_appropriation,0) as  appropriation_prec,
		emissiondate,printeddate,transmitteddate,transactiondate,annulmentdate
	FROM #expense
	JOIN fin F
		ON #expense.idfin = F.idfin
	JOIN manager MAN  
		ON #expense.idman = MAN.idman
	LEFT OUTER JOIN registry REG
		ON #expense.idreg = REG.idreg
	LEFT OUTER JOIN #expenseprec prec
		ON #expense.idupb = prec.idupb
	ORDER BY MAN.title,upbprintingorder,F.printingorder, rowkind, adate
END
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
exec rpt_partitario_spese_intestazione_respons @ayear=2007, 
		@idupb='', @start={d '2007-01-01'}, @stop={d '2007-09-05'}, 
			@codelevel=1, @codefin=null, @showupb='S', @showchildupb='S', @idman=null, @suppressifblank='S'
*/
