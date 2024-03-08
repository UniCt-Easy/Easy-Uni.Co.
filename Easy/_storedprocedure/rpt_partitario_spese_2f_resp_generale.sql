
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_spese_2f_resp_generale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_spese_2f_resp_generale]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE                   PROCEDURE [rpt_partitario_spese_2f_resp_generale]
	@ayear int,
	@idupb	varchar(36), 
	@codelevel tinyint,
	@showupb char(1),	
	@showchildupb char(1),	
	@suppressifblank char(1),
	@idman int,	
	@start datetime,
	@stop datetime,
	@idfin int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null

AS
BEGIN

DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)

declare @previsionkind int
declare @flagcredit varchar(1)
declare @flagproceeds varchar(1)

select  @previsionkind=fin_kind,
	@flagcredit =isnull(flagcredit,'N'),
	@flagproceeds = isnull(flagproceeds,'N')
from config
where ayear=@ayear

-- dove fase 1 =@nfinphase è anche la fase dei Residui, fase 3 = maxphase
DECLARE @nfinphase tinyint
SELECT @nfinphase = expensefinphase FROM uniconfig


DECLARE @maxexpensephase tinyint		
SELECT 	@maxexpensephase = MAX(nphase)
FROM  	expensephase 

-- ATTENZIONE L'ipotesi di funzionamento di questa sp è che faseimpegno = fasepagamento - 1.
-- ALTRIMENTI SBALLA LE RIGHE DEL PAGAMENTO SUL REPORT (o meglio con un pò di tempo si deve fare un controllo per eliminare tutte le fasi 
-- che non sono fasepagamento e faseimpegno, anzi lo faccio subito inserendo alla fine una DELETE WHERE nphase <> fasepagamento AND nphase <> faseimpegno)

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@codelevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@codelevel < @level_input ) AND (@idfin is not null)		-- x eventuale calcolo livello scrivendo il cap di spesa in input
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


IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END

CREATE TABLE #expense
(
	idfin int ,
	idupb varchar(36),
	codeupb varchar(50),
	nphase tinyint,
	rowkind int,
	initialprevisioncomp decimal(19,2),
	initialprevisioncassa decimal(19,2),
	finvar_prevision decimal(19,2),
	finvar_secondaryprev decimal(19,2),
	appropriation_C decimal(19,2),
	var_appropriation_C decimal(19,2),
	appropriation_R decimal(19,2),
	var_appropriation_R decimal(19,2),

	payment_C decimal(19,2),
	var_payment_C decimal(19,2),
	payment_R decimal(19,2),
	var_payment_R decimal(19,2),
	adate datetime,
	description varchar(300),                   
	idreg int,	
	nappropriation int,
	ymovappropriation int,
	nmovappropriation int,
	yvarappropriation int,
	nvarappropriation int,
	appropriation_amount decimal(19,2),

	available_appropriation decimal(19,2),

	npayment int,
	ymovpayment int,
	nmovpayment int,
	yvarpayment int,
	nvarpayment int,
	payment_amount decimal(19,2),
	npay int,
	printdate datetime,
	annulmentdate datetime,
	transmissiondate datetime,
	transactiondate datetime,
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
	avanzo_ammin decimal(19,2),
	assign_credit decimal(19,2),
	dot_credit decimal(19,2),
	avanzo_cassa decimal(19,2),
	assign_cash decimal(19,2),
	dot_cash decimal(19,2)
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
	printdate,
	annulmentdate,
	transmissiondate,
	transactiondate,
	flagarrear,
	idappropriation,
	idman
)	--> prende quelli movimentati
SELECT 
	ISNULL(FL.idparent, expenseyear.idfin),-- figlio di livello @codelevel della voce di bilancio in input ut
	expenseyear.idupb,
	expense.nphase,
	expense.nphase-1,
	expense.adate,
	case 
	when isnull(expense.doc,'')='' then expense.description 
	when isnull(expense.doc,'') <> '' and isnull(expense.docdate,'')='' 
		then	expense.description + 
			' (Doc. ' 
			+ isnull(Convert (varchar(35),ISNULL(expense.doc,'')),'') + ')'
	else  expense.description + 
		' (Doc. ' 
		+ isnull(Convert (varchar(35),ISNULL(expense.doc,'')),'') + ' del '
		+ iSNULL(Convert (varchar(2),datepart(dd,expense.docdate))+'/'+Convert (varchar(2),datepart(mm,expense.docdate))+'/'+Convert (varchar(4),datepart(yy,expense.docdate)),'')
		+')'	
	end,
	expense.idreg,	
	E2.idexp, --IMPEGNO (in realtà è la prima fase)
	E2.ymov,
	E2.nmov,  
	expenseyear.amount,

	E3.idexp, --PAGAMENTO
	E3.ymov,
	E3.nmov, 
	expenseyear.amount,
	payment.npay,
	payment.printdate,
	payment.annulmentdate,
	paymenttransmission.transmissiondate,
	(SELECT MIN(transactiondate) 
		FROM banktransaction 
		WHERE banktransaction.kpay = expenselast.kpay AND banktransaction.idexp= E3.idexp),
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	E2.idexp, --IMPEGNO
	expense.idman 
FROM expense
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN upb
	ON expenseyear.idupb = upb.idupb	
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear	
JOIN finlast
	ON finlast.idfin = expenseyear.idfin 
JOIN expenselink EL2
	ON EL2.idchild = expense.idexp  AND EL2.nlevel = @nfinphase
LEFT  OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin  AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1
	ON FL1.idchild = expenseyear.idfin  AND FL1.nlevel = @level_input
LEFT OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expense.idexp  AND EL3.nlevel = @maxexpensephase
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
WHERE (@idfin IS NULL OR  isnull(FL1.idparent, expenseyear.idfin) = @idfin)		
--	AND expense.adate between @start and @stop
	AND expense.adate <= @stop -- Con il between esclude i residui
	AND ((E2.idman = @idman) or (@idman is null )) -- and expense.idman is not null))
	AND ((expense.nphase IN (@nfinphase, @maxexpensephase)))
	AND expenseyear.ayear=@ayear
	AND (expenseyear.idupb like @idupb)
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
	appropriation_amount,

	npayment, 
	ymovpayment,
	nmovpayment,
	yvarpayment,
	nvarpayment,
	payment_amount,
	npay,
	idappropriation,
	idman
)	--> prende quelli movimentati


SELECT 

	ISNULL(FL.idparent, expenseyear.idfin),-- figlio di livello @codelevel della voce di bilancio in input ut
	expenseyear.idupb,
	expense.nphase,
	expense.nphase-1,
	expensevar.adate,
	case isnull(expensevar.doc,'') when '' then expensevar.description 
	else  expensevar.description + ' (Doc. ' + isnull(Convert (varchar(35),expensevar.doc),'') + ' del '+ 
		Convert (varchar(2),datepart(dd,expensevar.docdate))+'/'+Convert (varchar(2),datepart(mm,expensevar.docdate))+
		'/'+Convert (varchar(4),datepart(yy,expensevar.docdate))+')'
	end,
	expense.idreg,	
	E2.idexp, --IMPEGNO, in relatà è la prima fase
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
	expense.idman 
FROM expensevar
join expense 
	on expensevar.idexp = expense.idexp
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp 
JOIN upb
	ON expenseyear.idupb = upb.idupb	
JOIN finlast
	ON finlast.idfin = expenseyear.idfin 
JOIN expenselink EL2
	ON EL2.idchild = expensevar.idexp  AND EL2.nlevel = @nfinphase
LEFT  OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin  AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1
	ON FL1.idchild = expenseyear.idfin  AND FL1.nlevel = @level_input
LEFT OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expensevar.idexp  AND EL3.nlevel = @maxexpensephase
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
WHERE	(@idfin IS NULL OR  isnull(FL1.idparent, expenseyear.idfin) = @idfin)		
	AND expensevar.adate between @firstday and @stop
	AND isnull(expensevar.autokind,'') <>'22'
	and expensevar.yvar = @ayear 
	AND ((E2.idman = @idman) or (@idman is null ))
	AND ((expense.nphase IN (@nfinphase, @maxexpensephase)))
	AND (expenseyear.idupb like @idupb)
	AND expenseyear.ayear=@ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

-- -L'update è stato introdotto perchè dobbiamo considerare con Responsabile quello della prima fase
UPDATE #expense SET idman = ( select ee.idman FROM #expense ee  -- posso avere 2 righe se ho la fase 1 e la var.
                        WHERE ee.nappropriation = #expense.nappropriation 
                                AND ee.nphase = @nfinphase
                                AND ee.nvarappropriation is null
                                )
WHERE nphase > @nfinphase

IF (@suppressifblank = 'S')
BEGIN
	INSERT INTO #expense
		(
		idfin,
		idupb,
		idman
		)	--> Prende quelli non movimentati 
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
	JOIN finvardetail FD 
		ON FD.idfin = FL3.idchild
	JOIN finvar FVAR 
		ON FVAR.yvar = FD.yvar
		AND FVAR.nvar = FD.nvar
	JOIN upb 
		ON FD.idupb=upb.idupb
	WHERE ((fin.flag&1)<>0) 
		AND (@idfin IS NULL 
		AND FVAR.idfinvarstatus = 5
		OR  (isnull(FL1.idparent, FD.idfin) = @idfin AND @idfin is NOT NULL))	
		AND ((upb.idman  = @idman) OR (@idman is null ) OR (@idfin is NOT NULL))--and upb.idman is not null))	
		AND fin.ayear = @ayear
		AND (upb.idupb like @idupb)
                AND (
                       ( 
                        upb.idman IS NOT NULL 
                        AND NOT EXISTS (SELECT *
                           FROM #expense
                           WHERE isnull(FL2.idparent, FD.idfin) = #expense.idfin
                           and  upb.idman = #expense.idman 
                           and upb.idupb = #expense.idupb
                           ) 
                        )
                        OR
                        (
                        upb.idman IS NULL 
                        AND
                        NOT EXISTS ( SELECT *
			FROM #expense
			WHERE isnull(FL2.idparent, FD.idfin) = #expense.idfin
			        ---and #expense.idman IS NOT NULL
        			and upb.idupb = #expense.idupb)
                        )
                )
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


INSERT INTO #expense
	(
		idfin,
		idupb,
		idman
	)	--> Prende quelli non movimentati 
SELECT distinct
	isnull(FL2.idparent, EY.idfin),
	upb.idupb,
	upb.idman
FROM fin
	JOIN finlink FL1
		ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
	JOIN finlink FL2
		ON FL2.idchild = fin.idfin AND FL2.nlevel = @codelevel
	JOIN finlink FL3
		ON FL3.idparent = fin.idfin
	JOIN expenseyear EY 
		ON EY.idfin = FL3.idchild and EY.ayear = fin.ayear
	JOIN upb 
		on EY.idupb=upb.idupb
	WHERE ((fin.flag&1)<>0)
		AND (@idfin IS NULL 
		OR  isnull(FL1.idparent, EY.idfin) = @idfin)	
		AND ((upb.idman  = @idman) OR (@idman is null ))-- and upb.idman is not null))	
		AND fin.ayear = @ayear
		AND (upb.idupb like @idupb)
                AND (
                       ( 
                        upb.idman IS NOT NULL 
                        AND NOT EXISTS (SELECT *
                           FROM #expense
                           WHERE isnull(FL2.idparent, EY.idfin) = #expense.idfin
                           and  upb.idman = #expense.idman 
                           and upb.idupb = #expense.idupb ) 
                        )
                        OR
                        (
                        upb.idman IS NULL
                        AND
                        NOT EXISTS ( SELECT *
			FROM #expense
			WHERE isnull(FL2.idparent, EY.idfin) = #expense.idfin
			        ---and #expense.idman IS NOT NULL
        			and upb.idupb = #expense.idupb)
                        )
                )
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

INSERT INTO #expense
	(
		idfin,
		idupb,
		idman
	)	--> Prende quelli non movimentati 
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
	
WHERE ((fin.flag&1)<>0) 	
		AND (@idfin IS NULL 
		OR  isnull(FL1.idparent, FY.idfin) = @idfin)	
		AND ((upb.idman  = @idman) OR (@idman is null ))-- and upb.idman is not null))	
		AND fin.ayear = @ayear
		AND (upb.idupb like @idupb ) 
                AND (
                       ( upb.idman IS NOT NULL 
                        AND NOT EXISTS (SELECT *
                           FROM #expense
                           WHERE isnull(FL2.idparent, FY.idfin) = #expense.idfin
                           and  upb.idman = #expense.idman 
                           and upb.idupb = #expense.idupb ) 
                        )
                        OR
                        ( upb.idman IS NULL
                        AND NOT EXISTS ( SELECT *
			FROM #expense
			WHERE isnull(FL2.idparent, FY.idfin) = #expense.idfin
			        ---and #expense.idman IS NOT NULL
        			and upb.idupb = #expense.idupb)
                        )
                )
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

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
JOIN creditpart CP
	ON CP.idfin = fin.idfin
LEFT OUTER JOIN finlink FL1
	ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
WHERE ((fin.flag&1)=1) 	
	AND (@idfin IS NULL 
	OR  (FL1.idparent = @idfin AND @idfin is NOT NULL))	
	AND (upb.idupb LIKE @idupb ) 
	AND ((upb.idman  = @idman) OR (@idman is null ))--and upb.idman is not null))	
	AND fin.nlevel = @codelevel
	AND fin.ayear = @ayear
        AND (
               ( upb.idman IS NOT NULL 
                AND NOT EXISTS (SELECT *
                   FROM #expense
                   WHERE fin.idfin = #expense.idfin
                   and  upb.idman = #expense.idman 
                   and upb.idupb = #expense.idupb ) 
                )
                OR
                ( upb.idman IS NULL
                AND NOT EXISTS ( SELECT *
		FROM #expense
		WHERE fin.idfin = #expense.idfin
		        ---and #expense.idman IS NOT NULL
			and upb.idupb = #expense.idupb)
                )
        )
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


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
JOIN proceedspart PP
	ON PP.idfin = fin.idfin
LEFT OUTER JOIN finlink FL1
	ON FL1.idchild = fin.idfin and FL1.nlevel = @level_input
WHERE ((fin.flag&1)=1) 	
	AND (@idfin IS NULL 
	OR  (FL1.idparent = @idfin AND @idfin is NOT NULL))	
	AND (upb.idupb LIKE @idupb ) 
	AND ((upb.idman  = @idman) OR (@idman is null ))--and upb.idman is not null))	
	AND fin.nlevel = @codelevel
	AND fin.ayear = @ayear
        AND (
               ( upb.idman IS NOT NULL 
                AND NOT EXISTS (SELECT *
                   FROM #expense
                   WHERE fin.idfin = #expense.idfin
                   and  upb.idman = #expense.idman 
                   and upb.idupb = #expense.idupb ) 
                )
                OR
                ( upb.idman IS NULL
                AND NOT EXISTS ( SELECT *
		FROM #expense
		WHERE fin.idfin = #expense.idfin
		        ---and #expense.idman IS NOT NULL
			and upb.idupb = #expense.idupb)
                )
        )
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
WHERE ((fin.flag&1)=1) 	
	AND (@idfin IS NULL 
	OR  (FL1.idparent = @idfin AND @idfin is NOT NULL))	
	AND (upb.idupb LIKE @idupb ) 
	AND ((upb.idman  = @idman) OR (@idman is null ))-- and upb.idman is not null))	
	AND fin.nlevel = @codelevel
	AND fin.ayear = @ayear
                AND (
                       ( upb.idman IS NOT NULL 
                        AND NOT EXISTS (SELECT *
                           FROM #expense
                           WHERE fin.idfin = #expense.idfin
                           and  upb.idman = #expense.idman 
                           and upb.idupb = #expense.idupb ) 
                        )
                        OR
                        (
                        upb.idman IS NULL
                        AND
                        NOT EXISTS ( SELECT *
			FROM #expense
			WHERE fin.idfin = #expense.idfin
			        ---and #expense.idman IS NOT NULL
        			and upb.idupb = #expense.idupb)
                        )
                )
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

END

CREATE TABLE #appropriation_C
    (
	idfin int,
	idupb varchar(36),
	idman int,
	amount decimal(19,2),
	nphase tinyint			 
    )
INSERT INTO #appropriation_C
	(
	idfin,
	idupb,
	idman,
	amount,
	nphase
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	E1.idman,
	SUM(ISNULL(expenseyear.amount, 0)),
	expense.nphase
FROM expense
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp 
JOIN upb
	ON expenseyear.idupb = upb.idupb	
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp 
	AND expenseyear.ayear = expensetotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
LEFT OUTER JOIN expenselink
        ON expenselink.idchild = expense.idexp and expenselink.nlevel = @nfinphase
LEFT OUTER JOIN expense E1
        ON E1.idexp = expenselink.idparent 
WHERE expense.adate between @firstday and @stop
	AND expenseyear.ayear = @ayear
	AND ((expensetotal.flag&1)=0)
	AND expense.nphase = @nfinphase 
	AND (@idfin IS NULL OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((expense.idman  = @idman) OR (@idman IS NULL ))-- AND expense.idman is not null))	
	AND (expenseyear.idupb like @idupb)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),E1.idman,expense.nphase 

CREATE TABLE #var_appropriation_C
    (
	idfin int,
	idupb varchar(36),
	idman int,
	amount decimal(19,2),
	nphase tinyint							 
    )
INSERT INTO #var_appropriation_C
	(
	idfin,
	idupb,
	idman,
	amount,
	nphase
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	E1.idman, 
	SUM(ISNULL(expensevar.amount, 0)),
	expense.nphase
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
JOIN upb
	ON expenseyear.idupb = upb.idupb	
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear 
JOIN expense 
	ON expense.idexp = expenseyear.idexp
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
LEFT OUTER JOIN expenselink
        ON expenselink.idchild = expense.idexp and expenselink.nlevel = @nfinphase
LEFT OUTER JOIN expense E1
        ON E1.idexp = expenselink.idparent 
WHERE expensevar.yvar = @ayear
	AND expenseyear.ayear = @ayear
	AND ((expensetotal.flag&1)=0) 
	AND expense.nphase =  @nfinphase 
	AND expensevar.adate between @firstday and @stop 
	AND (@idfin IS NULL OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((expense.idman  = @idman) OR (@idman IS NULL ))-- AND expense.idman is not null))	
	AND (expenseyear.idupb like @idupb)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),E1.idman,expense.nphase 

CREATE TABLE #appropriation_R
    (
	idfin int,
	idupb varchar(36),
	idman int,
	amount decimal(19,2),
	nphase tinyint							 
    )
INSERT INTO #appropriation_R
	(
	idfin,
	idupb,
	idman,
	amount,
	nphase
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	E1.idman,	
	SUM(ISNULL(expenseyear.amount, 0)),
	expense.nphase
FROM expenseyear
JOIN expense
	ON expense.idexp = expenseyear.idexp 
JOIN upb
	ON expenseyear.idupb = upb.idupb 
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp 
	AND expenseyear.ayear = expensetotal.ayear
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
LEFT OUTER JOIN expenselink
        ON expenselink.idchild = expense.idexp and expenselink.nlevel = @nfinphase
LEFT OUTER JOIN expense E1
        ON E1.idexp = expenselink.idparent 
WHERE  ((expensetotal.flag&1)=1)
	AND expenseyear.ayear = @ayear
	AND expense.nphase = @nfinphase 
	AND expense.adate  <= @stop
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((expense.idman  = @idman) OR (@idman IS NULL ))-- AND expense.idman is not null))	
	AND (expenseyear.idupb like @idupb)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),E1.idman,expense.nphase 

CREATE TABLE #var_appropriation_R
    (
	idfin int,
	idupb varchar(36),
	idman int,
	amount decimal(19,2),
	nphase tinyint							 
    )
INSERT INTO #var_appropriation_R
	(
	idfin,
	idupb,
	idman,
	amount,
	nphase
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	expenseyear.idupb,
	E1.idman,	
	SUM(ISNULL(expensevar.amount, 0)),
	expense.nphase
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp	
JOIN upb
	ON expenseyear.idupb = upb.idupb	
JOIN expense 
	ON expense.idexp = expenseyear.idexp
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
LEFT OUTER JOIN expenselink
        ON expenselink.idchild = expense.idexp and expenselink.nlevel = @nfinphase
LEFT OUTER JOIN expense E1
        ON E1.idexp = expenselink.idparent 
WHERE expensevar.yvar = @ayear
	AND expenseyear.ayear = @ayear
	AND ((expensetotal.flag&1)=1) 
	AND expense.nphase = @nfinphase 
	AND expensevar.adate <=  @stop 
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((expense.idman  = @idman) OR (@idman IS NULL ))--  AND expense.idman is not null))	
	AND (expenseyear.idupb like @idupb)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),E1.idman,expense.nphase 

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
	E1.idman,
	SUM(ISNULL(paymentemitted.amount,0))
FROM expenseyear
JOIN upb
	ON expenseyear.idupb = upb.idupb
JOIN paymentemitted
	ON expenseyear.idexp = paymentemitted.idexp AND expenseyear.ayear = @ayear
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
LEFT OUTER JOIN expenselink
        ON expenselink.idchild = expense.idexp and expenselink.nlevel = @nfinphase
LEFT OUTER JOIN expense E1
        ON E1.idexp = expenselink.idparent 
WHERE paymentemitted.competencydate between @firstday and @stop
	AND  ((expensetotal.flag&1)=0)
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND (expenseyear.idupb like @idupb) 
	AND ((expense.idman  = @idman) OR (@idman is null ))
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),E1.idman

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
	E1.idman,
	SUM(ISNULL(paymentemitted.amount,0))
FROM paymentemitted
JOIN expenseyear
	ON expenseyear.idexp = paymentemitted.idexp 
	AND expenseyear.ayear = @ayear
JOIN upb
	ON expenseyear.idupb = upb.idupb	
JOIN expense 
	ON expense.idexp = expenseyear.idexp
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
LEFT OUTER JOIN expenselink
        ON expenselink.idchild = expense.idexp and expenselink.nlevel = @nfinphase
LEFT OUTER JOIN expense E1
        ON E1.idexp = expenselink.idparent 
WHERE paymentemitted.competencydate between @firstday and @stop
	AND (paymentemitted.flagarrear='R') 
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin )	
	AND (expenseyear.idupb like @idupb) 
	AND ((expense.idman  = @idman) OR (@idman is null ))
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),E1.idman


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
	E1.idman,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
	AND expenseyear.ayear = @ayear
JOIN upb
	ON expenseyear.idupb = upb.idupb
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
LEFT OUTER JOIN expenselink
        ON expenselink.idchild = expense.idexp and expenselink.nlevel = @nfinphase
LEFT OUTER JOIN expense E1
        ON E1.idexp = expenselink.idparent 
WHERE expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)=0) 
	AND isnull(expensevar.autokind,'') <>'22'
	AND expensevar.adate between @firstday and @stop
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND (expenseyear.idupb like @idupb) 
	AND expensevar.idexp IN (select idexp from paymentemitted)
	AND ((expense.idman  = @idman) OR (@idman is null ))	
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),E1.idman

CREATE TABLE #var_payment_R
    (
	idfin int,
	idupb varchar(36),
	idman int,
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
	E1.idman,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
	AND expenseyear.ayear = @ayear
JOIN upb
	ON expenseyear.idupb = upb.idupb	
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
LEFT OUTER JOIN expenselink
        ON expenselink.idchild = expense.idexp and expenselink.nlevel = @nfinphase
LEFT OUTER JOIN expense E1
        ON E1.idexp = expenselink.idparent 
WHERE expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)=1) 
	AND expensevar.adate between @firstday and @stop
	AND isnull(expensevar.autokind,'') <>'22'
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND (expenseyear.idupb like @idupb) 
	AND expensevar.idexp IN (select idexp FROM paymentemitted)
	AND ((expense.idman  = @idman) OR (@idman is null ))
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY expenseyear.idupb,ISNULL(finlink.idparent,expenseyear.idfin),E1.idman

UPDATE #expense
SET
-- Disp.dell' Impegno:  Impegno + Var.Impegno alla data - (SubImpegni + Var. SubImpegni)
	available_appropriation = 
		appropriation_amount 
		+ ISNULL((SELECT SUM(amount)
		FROM expensevar
		join expense on expensevar.idexp = expense.idexp
		WHERE expensevar.idexp= #expense.nappropriation
			and expensevar.adate between @firstday and @stop
			and expensevar.yvar = @ayear
			and expense.nphase  = @nfinphase
			and #expense.nvarappropriation is null
		),0) 
		- ISNULL((SELECT SUM(expenseyear.amount)
			from expenseyear
		JOIN  expense E					 
			ON E.idexp = expenseyear.idexp  
		JOIN expenselink elk1
			ON elk1.idchild = E.idexp AND elk1.nlevel = @nfinphase
		where elk1.idparent = #expense.nappropriation
			AND E.nphase = @maxexpensephase
			AND expenseyear.ayear =@ayear
			and #expense.nvarappropriation is null -- deve aggiornare solo le righe degli impegni
		),0)
		- ISNULL((SELECT SUM(expensevar.amount)
		FROM expensevar
		JOIN  expense E					 
			ON E.idexp = expensevar.idexp  
		JOIN expenselink elk1
			ON elk1.idchild = E.idexp AND elk1.nlevel = @nfinphase
		WHERE elk1.idparent = #expense.nappropriation
			and expensevar.adate between @firstday and @stop
			and expensevar.yvar = @ayear
			AND E.nphase = @maxexpensephase
			and #expense.nvarappropriation is null
		),0)	

UPDATE #expense SET 
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
				AND finvar.adate between @firstday and @stop
				AND finvar.yvar = @ayear
				AND ISNULL(finlink.idparent,finvardetail.idfin) = #expense.idfin 
				AND finvardetail.idupb = #expense.idupb
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
					AND finvar.variationkind <> 5
					AND finvar.idfinvarstatus = 5	
					AND finvar.adate between @firstday and @stop
					AND finvar.yvar = @ayear
					AND ISNULL(finlink.idparent,finvardetail.idfin)  = #expense.idfin 
					AND finvardetail.idupb = #expense.idupb
					), 0),
	appropriation_C = (SELECT SUM(ISNULL(#appropriation_C.amount,0))  
				FROM #appropriation_C
				WHERE  #appropriation_C.idfin = #expense.idfin
					and isnull(#appropriation_C.idman,0) = isnull(#expense.idman,0)
					and #appropriation_C.idupb = #expense.idupb
					and #appropriation_C.nphase = @nfinphase ), 
	var_appropriation_C = (SELECT SUM(ISNULL(#var_appropriation_C.amount,0))  
				FROM #var_appropriation_C
				WHERE  #var_appropriation_C.idfin = #expense.idfin
					and isnull(#var_appropriation_C.idman ,0)= isnull(#expense.idman,0) 
					and #var_appropriation_C.idupb = #expense.idupb
					and #var_appropriation_C.nphase = @nfinphase),
	payment_C = (SELECT SUM(ISNULL(#payment_C.amount,0))  
				FROM #payment_C
				WHERE  #payment_C.idfin = #expense.idfin
					and #payment_C.idupb = #expense.idupb
					and isnull(#payment_C.idman,0) = isnull(#expense.idman,0)), 
	var_payment_C = (SELECT SUM(ISNULL(#var_payment_C.amount,0))  
				FROM #var_payment_C
				WHERE   #var_payment_C.idfin = #expense.idfin
					and #var_payment_C.idupb = #expense.idupb
					and isnull(#var_payment_C.idman,0) = isnull(#expense.idman,0)),
  	appropriation_R =(SELECT SUM(ISNULL(#appropriation_R.amount,0))  
				FROM #appropriation_R
				WHERE  #appropriation_R.idfin = #expense.idfin
					and isnull(#appropriation_R.idman,0) = isnull(#expense.idman,0)
					and #appropriation_R.idupb = #expense.idupb
					and #appropriation_R.nphase = @nfinphase), 
	var_appropriation_R =(SELECT SUM(ISNULL(#var_appropriation_R.amount,0))  
				FROM #var_appropriation_R
				WHERE  #var_appropriation_R.idfin = #expense.idfin
					and isnull(#var_appropriation_R.idman,0) = isnull(#expense.idman,0)
					and #var_appropriation_R.idupb = #expense.idupb
					and #var_appropriation_R.nphase = @nfinphase), 
	payment_R =(SELECT SUM(ISNULL(#payment_R.amount,0))  
			FROM #payment_R					
			WHERE  #payment_R.idfin = #expense.idfin
				and #payment_R.idupb = #expense.idupb
				and isnull(#payment_R.idman,0) = isnull(#expense.idman,0) ), 
	var_payment_R = (SELECT SUM(ISNULL(#var_payment_R.amount,0))  
			FROM #var_payment_R
			WHERE  #var_payment_R.idfin = #expense.idfin
				and #var_payment_R.idupb = #expense.idupb
				and isnull(#var_payment_R.idman,0) = isnull(#expense.idman,0) )

	IF @codelevel >= @levelusable
		BEGIN	
print 'Then'
		UPDATE #expense
		SET	
		initialprevisioncomp= ISNULL((SELECT finyear.prevision 
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					JOIN upb
						ON finyear.idupb = upb.idupb
					WHERE finyear.idupb = #expense.idupb AND 
						finyear.idfin = #expense.idfin),0),
	  
		initialprevisioncassa = ISNULL((SELECT finyear.secondaryprev 
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
print 'Else'
		UPDATE #expense
		SET 
		initialprevisioncomp= ISNULL((SELECT SUM(isnull(finyear.prevision,0)) 
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
	  
		initialprevisioncassa = ISNULL((SELECT SUM(isnull(finyear.secondaryprev,0)) 
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
					WHERE expense.adate between @firstday and @stop
						AND expense.nphase = @nfinphase
						AND ((expensetotal.flag&1)=0) 
						AND expenseyear.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent, expenseyear.idfin) = #expense.idfin),
		
		total_var_appropriation_C = (SELECT SUM(ISNULL(expensevar.amount, 0))
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
						AND ((expensetotal.flag&1)=0) 
						AND expensevar.adate between @firstday and @stop 
						AND expenseyear.idupb = #expense.idupb 
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
					WHERE ((expensetotal.flag&1)=1)
						AND expense.nphase = @nfinphase
						AND expense.adate <=  @stop
						AND expenseyear.idupb = #expense.idupb 
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
						AND ((expensetotal.flag&1)=1) 
						AND expense.nphase = @nfinphase
						AND expensevar.adate between @firstday and @stop 
						AND expenseyear.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent, expenseyear.idfin)  = #expense.idfin),
	
		total_payment_C = (SELECT SUM(ISNULL(paymentemitted.amount,0))
					FROM paymentemitted
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = paymentemitted.idfin 
						AND finlink.nlevel = @codelevel
					WHERE paymentemitted.competencydate between @firstday and @stop
						AND paymentemitted.ymov = @ayear
						AND paymentemitted.flagarrear = 'C'
						AND paymentemitted.idupb = #expense.idupb 
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
						AND expensevar.adate between @firstday and @stop
						AND paymentemitted.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent,paymentemitted.idfin)= #expense.idfin),
		total_payment_R = (SELECT SUM(ISNULL(paymentemitted.amount,0))
					FROM paymentemitted
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = paymentemitted.idfin AND 
						finlink.nlevel = @codelevel
					WHERE paymentemitted.competencydate between @firstday and @stop
						AND paymentemitted.flagarrear = 'R'
						AND paymentemitted.ymov = @ayear
						AND paymentemitted.idupb = #expense.idupb 
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
						AND expensevar.adate between @firstday and @stop
						AND paymentemitted.idupb = #expense.idupb 
						AND ISNULL(finlink.idparent,paymentemitted.idfin ) = #expense.idfin)

	


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


DECLARE @InfoAnniPrec char
SELECT  @InfoAnniPrec = isnull(paramvalue,'N') FROM reportadditionalparam 
WHERE paramname = 'MostraInfoAnniPrecedenti'
AND reportname in ('rpt_partitario_spese_2f_resp_generale')


IF (@InfoAnniPrec='S' and @showupb ='S')
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
	JOIN upb
		ON FY.idupb = upb.idupb
	WHERE  FY.finpart = 'S'
		AND FY.ayear = @ayear
		AND FY.nlevel = (SELECT MIN(nlevel) FROM finlevel 
				WHERE FY.ayear = @ayear   AND (flag&2)<>0)
	AND FY.idupb in (select distinct idupb from #expense)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

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
					AND v.variationkind <> 5
					AND ((f.flag & 1) = 1 )
					AND v.yvar = @ayear
					AND v.adate <= @stop
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
					AND expensevar.yvar < @ayear
					AND expenseyear.ayear < @ayear
					-- AND expensevar.adate < @stop
					AND expenseyear.idupb = #expenseprec.idupb
					AND expense.nphase = @nfinphase)
	
END

-- Crediti e Cassa
-- Controlla che i CREDITI  siano gestiti
IF 	(
	isnull((select flagcredit from config where ayear = @ayear),'N')='S'
	)
BEGIN
	UPDATE #expense
	SET avanzo_ammin = 
		isnull((select SUM(d.amount)--Avanzo di Amministrazione
			FROM finvardetail d
			JOIN finvar v 
				ON v.yvar = d.yvar
				AND v.nvar = d.nvar
				AND v.flagcredit ='S'
			JOIN finlink
				ON  finlink.idchild = d.idfin   
			where finlink.idparent = #expense.idfin
				AND v.idfinvarstatus = 5
				and d.idupb = #expense.idupb
				AND v.adate <= @stop
				AND v.yvar = @ayear
				AND v.variationkind IN (2,3)),0.0),
	 assign_credit = 	
		isnull((SELECT SUM(creditpart.amount)--Assegnazione crediti'
			FROM creditpart 
			JOIN incomeyear
				ON creditpart.idinc = incomeyear.idinc
				and creditpart.ycreditpart = incomeyear.ayear
			JOIN finlink
				ON  finlink.idchild = creditpart.idfin   
			WHERE finlink.idparent = #expense.idfin
			AND incomeyear.idupb = #expense.idupb
			AND adate between @firstday and @stop),0.0),
	dot_credit = 		
		isnull((SELECT SUM(d.amount)--Variazioni e Storni di Crediti'
			FROM finvardetail d
			JOIN finvar v
				ON v.yvar = d.yvar
				AND v.nvar = d.nvar
				AND v.flagcredit ='S'
			JOIN finlink
				ON  finlink.idchild = d.idfin   
			WHERE finlink.idparent = #expense.idfin
			      AND v.idfinvarstatus = 5
			      AND d.idupb = #expense.idupb
			      AND v.adate between @firstday and @stop
			      AND v.variationkind IN (1,4)),0.0)
END
-- Controlla che gli INCASSI siano gestiti
IF 	(
	isnull((select flagproceeds from config where ayear = @ayear),'N')='S'
	)
BEGIN
	UPDATE #expense
		SET avanzo_cassa = 
			isnull(( select SUM(d.amount)
				FROM finvardetail d
				JOIN finvar v
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				JOIN finlink
					ON  finlink.idchild = d.idfin   
				where  finlink.idparent = #expense.idfin
					AND d.idupb = #expense.idupb
					AND v.flagproceeds='S'
					AND v.idfinvarstatus = 5
					AND v.adate <= @stop
					AND v.yvar = @ayear
					AND v.variationkind IN (2,3)),0.0),
		assign_cash = 
			isnull(( select SUM(proceedspart.amount)
				FROM proceedspart
				JOIN incomeyear
					on proceedspart.idinc = incomeyear.idinc
					and proceedspart.yproceedspart = incomeyear.ayear
				JOIN finlink
					ON  finlink.idchild = proceedspart.idfin   
				where finlink.idparent = #expense.idfin
				AND incomeyear.idupb = #expense.idupb
				AND adate between @firstday and @stop),0.0),
		dot_cash =
			isnull((SELECT SUM(d.amount)
				FROM finvardetail d
				JOIN finvar v
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				JOIN finlink
					ON  finlink.idchild = d.idfin  
				where finlink.idparent = #expense.idfin
					AND v.flagproceeds='S'
					AND v.idfinvarstatus = 5
					AND v.adate between @firstday and @stop
					and d.idupb = #expense.idupb
					AND v.variationkind IN (1,4)),0.0)
END
					


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
		ISNULL(payment_amount,0)=0 AND
		ISNULL(avanzo_ammin,0)=0 AND
		ISNULL(assign_credit,0)=0 AND
		ISNULL(dot_credit,0)=0 AND
		ISNULL(avanzo_cassa,0)=0 AND
		ISNULL(assign_cash,0)=0 AND
		ISNULL(dot_cash,0)=0 
		AND (select nlevel from fin FFF where FFF.idfin= #expense.idfin)>=2
		)
	END

DECLARE @finphase varchar(50)
DECLARE @maxphase varchar(50)

select @finphase = description from  expensephase where nphase = @nfinphase
select @maxphase = description from  expensephase where nphase = @maxexpensephase

SELECT 
	#expense.idupb,
	#expense.idfin,
	U.codeupb,
	U.title as upb,
	U.printingorder as upbprintingorder,
	F.codefin,
	F.title as fintitle,
	F.printingorder as finprintingorder,
	F.nlevel,
	nphase,
	rowkind,
	sum(isnull(initialprevisioncomp,0)) as initialprevisioncomp,
	sum(isnull(initialprevisioncassa,0)) as  initialprevisioncassa , 
	sum(isnull(#expense.finvar_prevision,0)) as  finvar_prevision ,
	sum(isnull(#expense.finvar_secondaryprev,0)) as  finvar_secondaryprev ,	
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
	yvarappropriation,
	nvarappropriation,
	isnull(appropriation_amount,0) as appropriation_amount,
	isnull(available_appropriation,0) as available_appropriation,

	npayment,
	ymovpayment,
	nmovpayment,
	yvarpayment,
	nvarpayment,
	sum(isnull(payment_amount,0)) as  payment_amount,
	npay,
	printdate,
	annulmentdate ,
	transmissiondate,
	transactiondate,
	flagarrear,
	@stop as reportdate,
	@ayear as ayear,
	idappropriation,
	MAN.title as manager,
	isnull(#expense.idman,0) as idman,
	sum(isnull(total_appropriation_C,0)) as total_appropriation_C,
	sum(isnull(total_var_appropriation_C,0)) as total_var_appropriation_C,

	sum(isnull(total_appropriation_R,0)) as  total_appropriation_R,
	sum(isnull(total_var_appropriation_R,0))as total_var_appropriation_R,

	sum(isnull(total_payment_C,0)) as total_payment_C,
	sum(isnull(total_var_payment_C,0)) as total_var_payment_C,
	sum(isnull(total_payment_R,0)) as  total_payment_R,
	sum(isnull(total_var_payment_R,0))as total_var_payment_R,
	@previsionkind as previsionkind,
	@flagcredit as flagcredit,
	@flagproceeds as flagproceeds,
	CASE 
		WHEN  @previsionkind = 2 THEN
		  	sum (isnull(prec.prevision,0) + isnull(prec.finvar_prevision,0))
		ELSE
			sum(isnull(prec.prevision,0) + isnull(prec.finvar_prevision,0) 
			+ isnull(prec.appropriation,0)+isnull(prec.var_appropriation,0))
	END  as  prevision_prec,
	sum(isnull(prec.appropriation,0)+isnull(prec.var_appropriation,0)) as  appropriation_prec,
	@finphase AS finphase,
	@maxphase AS maxphase,
	U.expiration, 
	U.requested,
	U.granted,
	ISNULL(sum(avanzo_ammin),0) as avanzo_ammin,
	ISNULL(sum(assign_credit),0) as assign_credit,
	ISNULL(sum(dot_credit),0) as dot_credit,
	ISNULL(sum(avanzo_cassa),0) as avanzo_cassa,
	ISNULL(sum(assign_cash),0) as assign_cash,
	ISNULL(sum(dot_cash),0) as dot_cash
FROM #expense
JOIN fin F
	ON #expense.idfin = F.idfin
JOIN upb U
	ON #expense.idupb = U.idupb
LEFT OUTER JOIN manager MAN  
	ON #expense.idman = MAN.idman
LEFT OUTER JOIN registry REG
	On #expense.idreg = REG.idreg
LEFT OUTER JOIN #expenseprec prec
		ON #expense.idupb = prec.idupb
GROUP BY  #expense.idupb,U.codeupb,#expense.idman,MAN.title,		
	#expense.idfin,F.codefin,F.title,F.nlevel,
	F.printingorder,nphase,
	rowkind,adate,description,REG.title,nappropriation,npayment,
	npay,#expense.printdate,#expense.transactiondate,flagarrear,reportdate,#expense.ayear,idappropriation,
	ymovappropriation,nmovappropriation,ymovpayment,nmovpayment,yvarappropriation,nvarappropriation,
	yvarpayment,nvarpayment,U.title,U.printingorder,annulmentdate ,	transmissiondate,
	U.expiration,U.requested,U.granted,
	appropriation_amount,available_appropriation
ORDER BY manager,F.printingorder, rowkind, adate,
		nvarappropriation,nvarpayment


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



