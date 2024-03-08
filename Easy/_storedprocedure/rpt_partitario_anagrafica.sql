
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_anagrafica]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_anagrafica]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO







-- rpt_partitario_anagrafica 2007,3,null,{d '1950-01-01'},{d '2007-12-31'},'village'

CREATE    PROCEDURE [rpt_partitario_anagrafica]
	@ayear int,
	@codelevel tinyint,

	@codefin varchar(50),
	@start datetime,
	@stop datetime,
	@title varchar(100)

AS
BEGIN
/* Versione 1.0.0 del 29/11/2007 ultima modifica: PIERO */


if @title not in (select title from registry)
	if @title != ''
		set @title = '%' + @title + '%'
	else
		set @title = null


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
				and (fin.flag&1)=1) -- = 'S'
	END

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@codelevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@codelevel < @level_input ) AND (@idfin is not null)
	BEGIN
	SET  @codelevel = @level_input
	END

/*DECLARE @level varchar(50)
SELECT @level = description 
	FROM finlevel
	WHERE nlevel = @codelevel
	AND ayear = @ayear*/

DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel)
	FROM finlevel
	WHERE (flag&2)<>0  AND ayear = @ayear
IF @levelusable < @codelevel
BEGIN	
	SET @levelusable = @codelevel
END

-- considerare bene cosa succede quando voglio la stampa per articolo e specifico un capitolo in input
-- devo prendere i figli del capitolo specificato, aventi livello @codelevel

DECLARE @nfinphase tinyint

SELECT @nfinphase = expenseregphase
FROM uniconfig

-- ovvero prendo la massima fase tra quelle che contengono o il codice di bilancio o il creditore perchÃ¨ questÃ  Ã¨ la vera fase di impegno giuridico
DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase)
FROM    expensephase 
-- ATTENZIONE L'ipotesi di funzionamento di questa sp � che faseimpegno = fasepagamento - 1.
-- ALTRIMENTI SBALLA LE RIGHE DEL PAGAMENTO SUL REPORT (o meglio con un p� di tempo si deve fare un controllo per eliminare tutte le fasi 
-- che non sono fasepagamento e faseimpegno, anzi lo faccio subito inserendo alla fine una DELETE WHERE nphase <> fasepagamento AND nphase <> faseimpegno)

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
	title varchar(100),	
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
	total_var_payment_R decimal(19,2)   -- N.B.: non serve calcolare i totali relativi alle previsioni e alle var di previsione 
	-- in quanto sono gia calcolati indipendentemente dal responsabile.
)

INSERT INTO #expense
(
	idfin,
	idupb,
	nphase,
	rowkind, 
	adate, 
	description, 
	title,		
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
	else  expense.description + ' (Doc. ' + isnull(Convert (varchar(20),expense.doc),'') + ' del '+ 
		Convert (varchar(2),datepart(dd,expense.docdate))+'/'+Convert (varchar(2),datepart(mm,expense.docdate))+
		'/'+Convert (varchar(4),datepart(yy,expense.docdate))+')'
	end,
	registry.title,	
	E2.idexp, --IMPEGNO
	E2.ymov,
	E2.nmov,  
	expenseyear.amount,
	E3.idexp, --PAGAMENTO
	E3.ymov,
	E3.nmov, 
	expenseyear.amount,
	expenselast.npay,
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
LEFT OUTER JOIN upb
	ON upb.idupb = expenseyear.idupb
JOIN fin
	ON expenseyear.idfin = fin.idfin 
	AND expenseyear.ayear = fin.ayear
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear		
JOIN expenselink EL2
	ON EL2.idchild = expense.idexp  AND EL2.nlevel = @nfinphase
LEFT  OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin  AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1
	ON FL1.idchild = expenseyear.idfin  AND FL1.nlevel = @level_input
LEFT  OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expense.idexp  AND EL3.nlevel = @maxexpensephase
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
JOIN expensetotal ET2
	ON ET2.idexp=E2.idexp
	AND ET2.ayear = expenseyear.ayear
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
JOIN registry 
	ON registry.idreg = expense.idreg
WHERE ((fin.flag&1)=1) -- = 'S'	
	AND expenseyear.ayear = @ayear
	AND (@idfin IS NULL OR  isnull(FL1.idparent, expenseyear.idfin) = @idfin)		
	AND expense.adate between @start and @stop
	--AND ((expense.idreg  = @idreg) OR (@idreg is null and expense.idreg is not null))	
	AND ((expense.nphase IN (@nfinphase,@maxexpensephase )))
	AND ((registry.title like @title) or (@title is null and expense.idreg is not null))


CREATE TABLE #appropriation_C
    (
	idfin int,
	idupb varchar(36),
	title varchar(100),
	amount decimal(19,2)			 
    )
INSERT INTO #appropriation_C
	(
	idfin,
	title,
	amount
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	registry.title,
	SUM(ISNULL(expenseyear.amount, 0))
FROM expense
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp  
	AND expenseyear.ayear = @ayear
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp 
	AND expenseyear.ayear = expensetotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
JOIN registry
	ON expense.idreg = registry.idreg
WHERE expense.adate between @start and @stop
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((registry.title  like @title) OR (@title is null and expense.idreg is not null))	
	AND ((expensetotal.flag&1)=0) --= 'C'
	AND expense.nphase = @nfinphase
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),registry.title

--select '#appropriation_C', * from #appropriation_C
CREATE TABLE #var_appropriation_C
    (
	idfin int,
	idupb varchar(36),
	title varchar(100),
	amount decimal(19,2)					 
    )
INSERT INTO #var_appropriation_C
	(
	idfin,
	title,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	registry.title,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
	AND expenseyear.ayear = @ayear
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
JOIN registry
	ON registry.idreg = expense.idreg
WHERE expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)=0) --= 'C'
	AND expense.nphase = @nfinphase
	AND expensevar.adate between @start and @stop 
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((registry.title like @title) OR (@title is null and expense.idreg is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),registry.title

CREATE TABLE #appropriation_R
    (
	idfin int,
	idupb varchar(36), 
	title varchar(100),
	amount decimal(19,2)					 
    )
INSERT INTO #appropriation_R
	(
	idfin,
	title,
	amount
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	registry.title,
	SUM(ISNULL(expenseyear.amount, 0))
FROM expenseyear
JOIN expense
	ON expense.idexp = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear 
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
JOIN registry
	ON registry.idreg = expense.idreg
WHERE  ((expensetotal.flag&1)=1) --=R
	AND expense.nphase = @nfinphase
	AND expense.adate between @start and @stop
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)
	AND ((registry.title like @title) OR (@title is null and expense.idreg is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),registry.title

CREATE TABLE #var_appropriation_R
    (
	idfin int,
	idupb varchar(36),
	title varchar(100),
	amount decimal(19,2)					 
    )
INSERT INTO #var_appropriation_R
	(
	idfin,
	title,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	registry.title,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp	
	AND expenseyear.ayear = @ayear
JOIN expense on expense.idexp = expenseyear.idexp
JOIN expensetotal 
	ON  expenseyear.idexp = expensetotal.idexp AND
	expenseyear.ayear = expensetotal.ayear 
LEFT OUTER JOIN finlink ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
JOIN registry
	ON registry.idreg = expense.idreg
WHERE expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)=1) --=R
	AND expense.nphase = @nfinphase
	AND expensevar.adate between @start and @stop 
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((registry.title like @title) OR (@title is null and expense.idreg is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),registry.title

CREATE TABLE #payment_C
    (
	idfin int,
	idupb varchar(36),
	title varchar(100),
	amount decimal(19,2)					 
    )

INSERT INTO #payment_C
	(
	idfin,
	title,
	amount   
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	registry.title,
	SUM(ISNULL(paymentemitted.amount,0))
FROM expenseyear
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
JOIN registry
	ON registry.idreg = expense.idreg
WHERE paymentemitted.competencydate between @start and @stop
	AND  ((expensetotal.flag&1)=0) --=C
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND ((registry.title like @title) OR (@title is null and expense.idreg is not null))	 
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),registry.title
--select '#payment_C', * from #payment_C
CREATE TABLE #payment_R
    (
	idfin int,
	idupb varchar(36),
	title varchar(100),
	amount decimal(19,2)					 
    )
INSERT INTO #payment_R
	(
	idfin,
	title,
	amount
	)
SELECT
	ISNULL(finlink.idparent,expenseyear.idfin),
	registry.title,
	SUM(ISNULL(paymentemitted.amount,0))
FROM paymentemitted
JOIN expenseyear
	ON expenseyear.idexp = paymentemitted.idexp 
	AND expenseyear.ayear = @ayear
JOIN expense 
	ON expense.idexp = expenseyear.idexp
LEFT OUTER JOIN finlink 
	ON finlink.idchild = expenseyear.idfin 
	AND finlink.nlevel = @codelevel
LEFT OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin 
	AND FL.nlevel = @level_input
JOIN registry
	ON registry.idreg = expense.idreg
WHERE paymentemitted.competencydate between @start and @stop
	AND (paymentemitted.flagarrear='R') --=R
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin )	
	AND ((registry.title like @title) OR (@title is null and expense.idreg is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),registry.title

CREATE TABLE #var_payment_C
    (
	idfin int,
	idupb varchar(36),
	title varchar(100),
	amount decimal(19,2)					 
    )
INSERT INTO #var_payment_C
	(
	idfin,
	title,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	registry.title,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
	AND expenseyear.ayear = @ayear
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
JOIN registry
	ON registry.idreg = expense.idreg
WHERE expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)=0) --=C
	AND expensevar.adate between @start and @stop
	AND (@idfin IS NULL OR isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND expensevar.idexp IN (select idexp from paymentemitted)
	AND ((registry.title like @title) OR (@title is null and expense.idreg is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),registry.title

CREATE TABLE #var_payment_R
    (
	idfin  int,
	idupb varchar(36),
	title  varchar(100),
	amount decimal(19,2)					 
    )
INSERT INTO #var_payment_R
	(
	idfin,
	title,
	amount
	)
SELECT 
	ISNULL(finlink.idparent,expenseyear.idfin),
	registry.title,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
	AND expenseyear.ayear = @ayear
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
JOIN registry
	ON registry.idreg = expense.idreg
WHERE expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)=1) --=R
	AND expensevar.adate between @start and @stop
	AND (@idfin IS NULL 
	OR  isnull(FL.idparent,expenseyear.idfin) = @idfin)	
	AND expensevar.idexp IN (select idexp FROM paymentemitted)
	AND ((registry.title like @title) OR (@title is null and expense.idreg is not null))	
GROUP BY ISNULL(finlink.idparent,expenseyear.idfin),registry.title

---mi sta solo segnando i codici upb e le specifiche nella tabella #expense

UPDATE #expense
	SET
	codeupb = (select codeupb from upb where upb.idupb = #expense.idupb),

	upb = (select title from upb where upb.idupb = #expense.idupb),
	upbprintingorder = (select printingorder from upb where upb.idupb = #expense.idupb)


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
	AND expensevar.adate between @start and @stop
	AND expensevar.yvar = @ayear
	AND expense.nphase  = @nfinphase 
	),
payment_amount = payment_amount + 
	(SELECT ISNULL(SUM(amount),0) FROM expensevar
	JOIN expense ON expensevar.idexp = expense.idexp
	WHERE expensevar.idexp = #expense.npayment
	and expensevar.adate between @start and @stop
	and expensevar.yvar = @ayear
	and expense.nphase  = @maxexpensephase
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
				AND finvar.adate between @start and @stop
				AND finvar.yvar = @ayear
				AND ISNULL(finlink.idparent,finvardetail.idfin) = #expense.idfin
				AND #expense.title = @title),0),


	finvar_secondaryprev = ISNULL((SELECT SUM(ISNULL(finvardetail.amount,0))
				FROM finvardetail
				JOIN finvar
					ON finvar.yvar = finvardetail.yvar
					AND finvar.nvar = finvardetail.nvar
				LEFT OUTER JOIN finlink 
					ON finlink.idchild = finvardetail.idfin AND 
					finlink.nlevel = @codelevel
				WHERE finvar.flagsecondaryprev ='S'	
				AND finvar.adate between @start and @stop
				AND finvar.yvar = @ayear
				AND ISNULL(finlink.idparent,finvardetail.idfin)  = #expense.idfin 
				AND #expense.title = @title),0) ,


	appropriation_C = (SELECT SUM(ISNULL(#appropriation_C.amount,0))  
				FROM #appropriation_C
				WHERE   #appropriation_C.idfin = #expense.idfin
					and #appropriation_C.title = #expense.title), 

	var_appropriation_C = (SELECT SUM(ISNULL(#var_appropriation_C.amount,0))  
				FROM #var_appropriation_C
				WHERE  #var_appropriation_C.idfin = #expense.idfin
					and #var_appropriation_C.title = #expense.title),
	payment_C = (SELECT SUM(ISNULL(#payment_C.amount,0))  
				FROM #payment_C
				WHERE   #payment_C.idfin = #expense.idfin
					and #payment_C.title = #expense.title), 
	var_payment_C = (SELECT SUM(ISNULL(#var_payment_C.amount,0))  
				FROM #var_payment_C
				WHERE   #var_payment_C.idfin = #expense.idfin
					and #var_payment_C.title = #expense.title),
  	appropriation_R =(SELECT SUM(ISNULL(#appropriation_R.amount,0))  
				FROM #appropriation_R
				WHERE   #appropriation_R.idfin = #expense.idfin
					and #appropriation_R.title = #expense.title), 
	var_appropriation_R =(SELECT SUM(ISNULL(#var_appropriation_R.amount,0))  
				FROM #var_appropriation_R
				WHERE   #var_appropriation_R.idfin = #expense.idfin
					and #var_appropriation_R.title = #expense.title), 
	payment_R =(SELECT SUM(ISNULL(#payment_R.amount,0))  
			FROM #payment_R					
			WHERE   #payment_R.idfin = #expense.idfin
				and #payment_R.title = #expense.title), 
	var_payment_R = (SELECT SUM(ISNULL(#var_payment_R.amount,0))  
			FROM #var_payment_R
			WHERE   #var_payment_R.idfin = #expense.idfin
				and #var_payment_R.title = #expense.title)


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
	  
		initialprevisioncash = (SELECT SUM(ISNULL(finyear.secondaryprev,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					where fin.idfin = #expense.idfin
					)
		END 
	ELSE 

		UPDATE #expense
		SET 
		initialprevisioncomp= (SELECT SUM(ISNULL(finyear.prevision,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin
					WHERE ISNULL(finlink.idparent,finyear.idfin) = #expense.idfin
					AND fin.nlevel =  @levelusable),
	  
		initialprevisioncash = (SELECT SUM(ISNULL(finyear.secondaryprev,0))  
					FROM finyear
					JOIN fin
						ON finyear.idfin = fin.idfin
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = finyear.idfin
					WHERE ISNULL(finlink.idparent,finyear.idfin) = #expense.idfin
					AND fin.nlevel =  @levelusable)
	


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------- CALCOLO DEL DISPONIBILE -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	UPDATE #expense
		SET 
--- di questi calcola i movimenti effettuati sulla voce dui bilancio

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
					WHERE expense.adate between @start and @stop
						AND expense.nphase = @nfinphase
						AND ((expensetotal.flag&1)=0) --=C
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
						AND ((expensetotal.flag&1)=0) --=C
						AND expensevar.adate between @start and @stop 
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),
		total_appropriation_R = (SELECT SUM(ISNULL(expenseyear.amount, 0))
					FROM expenseyear
					JOIN expense
						ON expense.idexp = expenseyear.idexp 
						AND expenseyear.ayear = @ayear
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp AND
						expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN  finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE ((expensetotal.flag&1)=1) --=R
						AND expense.nphase = @nfinphase
						AND expense.adate between @start and @stop
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
						AND ((expensetotal.flag&1)=1) --=R
						AND expense.nphase = @nfinphase
						AND expensevar.adate between @start and @stop 
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),
	
-- su questi calcola effettivamente il disponibile
		total_payment_C = (SELECT SUM(ISNULL(paymentemitted.amount,0))
					FROM expenseyear
					JOIN paymentemitted
						ON expenseyear.idexp = paymentemitted.idexp AND expenseyear.ayear = @ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE paymentemitted.competencydate between @start and @stop
						AND (paymentemitted.flagarrear= 'C') --=C
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
						AND ((expensetotal.flag&1)=0) --=C
						AND expense.nphase = @maxexpensephase
						AND expensevar.adate between @start and @stop
						AND expensevar.idexp IN (select idexp from paymentemitted)
						and ISNULL(finlink.idparent,expenseyear.idfin)= #expense.idfin),
		total_payment_R = (SELECT SUM(ISNULL(paymentemitted.amount,0))
					FROM paymentemitted
					JOIN expenseyear
						ON expenseyear.idexp = paymentemitted.idexp AND expenseyear.ayear = @ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE paymentemitted.competencydate between @start and @stop
						AND (paymentemitted.flagarrear='R') --=R
						AND paymentemitted.nphase = @maxexpensephase
						and ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin),
		total_var_payment_R = ( SELECT SUM(ISNULL(expensevar.amount, 0))
					FROM expensevar
					JOIN expenseyear
						ON expenseyear.idexp = expensevar.idexp 
						AND expenseyear.ayear = @ayear
					JOIN expense
						ON expense.idexp = expensevar.idexp
					JOIN expensetotal 
						ON  expenseyear.idexp = expensetotal.idexp 
						AND expenseyear.ayear = expensetotal.ayear
					LEFT OUTER JOIN finlink 
						ON finlink.idchild = expenseyear.idfin AND 
						finlink.nlevel = @codelevel
					WHERE expensevar.yvar = @ayear
						AND ((expensetotal.flag&1)=1) --=R
						AND expense.nphase = @maxexpensephase
						AND expensevar.adate between @start and @stop
						AND expensevar.idexp IN (select idexp from paymentemitted)
						AND ISNULL(finlink.idparent,expenseyear.idfin) = #expense.idfin)
	


		DELETE FROM #expense WHERE idappropriation IS NULL 
			AND EXISTS (SELECT * FROM #expense S 
					WHERE S.idfin = #expense.idfin 
					and S.title = #expense.title )----DA VALUTARE--------------------------------




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
		#expense.title as registry,
		nappropriation,
		ymovappropriation,
		nmovappropriation,	
		sum(isnull(appropriation_amount,0)) as appropriation_amount,
		npayment,
		ymovpayment,
		nmovpayment,
		sum(isnull(payment_amount,0)) as  payment_amount,
		sum(isnull(available,0)) as available,
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
		0 as  appropriation_prec
	FROM #expense
	JOIN fin F
		ON #expense.idfin = F.idfin
	LEFT OUTER JOIN manager MAN  
		ON #expense.idman = MAN.idman
	GROUP BY  #expense.idman,MAN.title,		
		#expense.idfin,F.codefin,F.title,
		F.printingorder,codeupb,idupb,upb,upbprintingorder,nphase,
		rowkind,adate,description,#expense.title,nappropriation,npayment,
		npay,flagarrear,reportdate,#expense.ayear,idappropriation,
		ymovappropriation,nmovappropriation,ymovpayment,nmovpayment	
	ORDER BY manager,upbprintingorder,F.printingorder, rowkind, adate

END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

