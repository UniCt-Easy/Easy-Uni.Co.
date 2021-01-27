
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_per_classificazione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_per_classificazione]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- STAMPA PRINCIPALE
CREATE                   PROCEDURE [rpt_partitario_per_classificazione]
	@ayear int,
	@idsorkind int,
	@start smalldatetime,
	@stop  smalldatetime,
	@idsor int,
	@idman int
AS
BEGIN

DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)

DECLARE @minoplevel tinyint
DECLARE @levelinput tinyint

SELECT @minoplevel = min(nlevel)
FROM sortinglevel
WHERE idsorkind = @idsorkind and flag&2 <> 0

SELECT @levelinput = (select nlevel from sorting where idsor = @idsor)

IF (@idsor IS NOT NULL)  SET @minoplevel = @levelinput

DECLARE @descriptionsortingkind	varchar(50)
SELECT  @descriptionsortingkind = description
FROM sortingkind
WHERE idsorkind = @idsorkind

DECLARE @nphasemovimento  varchar(20)
DECLARE @phasedescription varchar(50)
	
SELECT 	@nphasemovimento = nphaseexpense
FROM sortingkind
WHERE idsorkind = @idsorkind

SET @phasedescription = (select description from expensephase where nphase=@nphasemovimento)


DECLARE @maxexpensephase tinyint		
SELECT 	@maxexpensephase = MAX(nphase)
FROM  	expensephase 

CREATE TABLE #expense
(
	idfin int ,
	idupb varchar(36),
	nphase tinyint,
	rowkind int,

	sortcode varchar(50),
	sortingdescription varchar(200),
	description varchar(300), 
	prevision decimal(19,2),
	varprev decimal(19,2),
	idsor int,
	appropriation decimal(19,2),
	var_appropriation decimal(19,2),

	payment decimal(19,2),
	var_payment decimal(19,2),

	adate datetime,
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
	expenseidman int -- viene inserito solo a titolo informativo
)

INSERT INTO #expense
(
	sortcode,
	sortingdescription,
	idsor,
	idfin,
	idupb,
	nphase,
	rowkind, 
	adate, 
	description, 
	idreg,	
	flagarrear,	
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
	idappropriation,
	available_appropriation,
	idman,
	expenseidman
)	--> prende quelli movimentati
SELECT 
	sorting.sortcode,
	sorting.description,
	expensesorted.idsor,
	expenseyear.idfin,
	expenseyear.idupb,
	expense.nphase,
	expense.nphase-1,
	expense.adate,
	case isnull(expense.doc,'') 
	when '' then expense.description 
	else  expense.description + 
		' (Doc. ' 
		+ isnull(Convert (varchar(20),ISNULL(expense.doc,'')),'') + ' del '
		+ iSNULL(Convert (varchar(2),datepart(dd,expense.docdate))+'/'+Convert (varchar(2),datepart(mm,expense.docdate))+'/'+Convert (varchar(4),datepart(yy,expense.docdate)),'')
		+')'	
		end,
	expense.idreg,	
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	E2.idexp, --IMPEGNO (in realtà è la prima fase)
	E2.ymov,
	E2.nmov,  
	expensesorted.amount,  ---Sta già prendendo il valore classificato e non il valore originale dell'impegno quindi non deve sottrarre

	E3.idexp, --PAGAMENTO
	E3.ymov,
	E3.nmov, 
	case when expenseyear.amount>expensesorted.amount then expensesorted.amount else expenseyear.amount end,
	payment.npay,
	payment.printdate,
	payment.annulmentdate,
	paymenttransmission.transmissiondate,
	(SELECT MIN(transactiondate) from banktransaction where banktransaction.kpay = expenselast.kpay AND banktransaction.idexp= E3.idexp),
	E2.idexp, --IMPEGNO
	ET2.available,
	ISNULL(managersorting.idman,0),
	expense.idman
FROM expense
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear	
JOIN finlast
	ON finlast.idfin = expenseyear.idfin 
JOIN expenselink EL2
	ON EL2.idchild = expense.idexp AND EL2.nlevel = @nphasemovimento
LEFT OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expense.idexp AND EL3.nlevel = @maxexpensephase
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
LEFT OUTER JOIN expensetotal ET2
	ON ET2.idexp = E2.idexp
	AND ET2.ayear = expenseyear.ayear
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
/*
LEFT OUTER JOIN banktransaction
	ON banktransaction.kpay = expenselast.kpay
	AND banktransaction.idexp= E3.idexp
*/
LEFT OUTER JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
left outer JOIN expensesorted
	ON expensesorted.idexp = EL2.idparent AND expensesorted.ayear = @ayear
JOIN sorting
	on sorting.idsor = expensesorted.idsor AND sorting.idsorkind = @idsorkind
join sortinglink
	ON sortinglink.idchild = expensesorted.idsor 
	AND (sortinglink.idparent = @idsor OR @idsor IS NULL)
	AND sortinglink.nlevel = @minoplevel
LEFT OUTER JOIN managersorting
	ON sorting.idsor = managersorting.idsor
WHERE   ( expense.adate BETWEEN @start AND ISNULL(@stop, {d '2079-06-06'}) OR expense.adate < @firstday)
	AND ((managersorting.idman = @idman) or (@idman is null ))
	AND (expense.nphase IN (@nphasemovimento, @maxexpensephase))
	and expenseyear.ayear=@ayear
	AND expensetotal.ayear = @ayear
				
--- Inserimento delle variazioni dei movimenti
INSERT INTO #expense
(
	sortcode,
	sortingdescription,
	idsor,
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
	idman,
	expenseidman
)	--> prende quelli movimentati


SELECT 
	sorting.sortcode,
	sorting.description,
	expensesorted.idsor,
	expenseyear.idfin,-- figlio di livello @codelevel della voce di bilancio in input ut
	expenseyear.idupb,
	expense.nphase,
	expense.nphase-1,
	expensevar.adate,
	expensevar.description, 
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
	EV3.yvar,
	EV3.nvar,
	EV3.amount,
	payment.npay,
	E2.idexp, 
	ISNULL(managersorting.idman,0),
	expense.idman
FROM expensevar
join expense 
	on expensevar.idexp = expense.idexp
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp 
JOIN finlast
	ON finlast.idfin = expenseyear.idfin 
JOIN expenselink EL2
	ON EL2.idchild = expensevar.idexp  AND EL2.nlevel = @nphasemovimento
LEFT OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expensevar.idexp  AND EL3.nlevel = @maxexpensephase
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
LEFT OUTER JOIN expensevar EV3
	ON EV3.idexp = E3.idexp
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN expensesorted
	ON expensesorted.idexp = expense.idexp
	AND expensesorted.ayear = @ayear
JOIN sorting
	on sorting.idsor = expensesorted.idsor
	AND sorting.idsorkind = @idsorkind
join sortinglink
	on sortinglink.idchild = expensesorted.idsor 
	AND (sortinglink.idparent = @idsor OR @idsor IS NULL)
	and sortinglink.nlevel = @minoplevel
LEFT OUTER JOIN managersorting
	ON sorting.idsor = managersorting.idsor
WHERE	expensevar.adate between @start and ISNULL(@stop, {d '2079-06-06'})
	AND isnull(expensevar.autokind,'') <>'22' 
	AND ((managersorting.idman = @idman) or (@idman is null ))
	AND (expense.nphase IN (@nphasemovimento, @maxexpensephase))
	AND expenseyear.ayear=@ayear
---------------------------------------------------------------------------------------------------------	
--ORA SONO AGGIUNTI QUELLI CHE NON SONO STATI MOVIMENTATI MA PER CUI ESISTE UNA PREVIISONE O UNA VAR DI PREVISIONE
--> Prende quelli non movimentati 1^ parte
print @minoplevel

INSERT INTO #expense
		(
		idsor,
		sortcode,
		sortingdescription,
		varprev
		)	
SELECT 
	sortingprevexpensevar.idsor, 
	sorting.sortcode,
	sorting.description,
	SUM(ISNULL(sortingprevexpensevar.amount, 0))
FROM sortingprevexpensevar
JOIN sorting
	on sorting.idsor = sortingprevexpensevar.idsor
join sortinglink
	on sortinglink.idchild = sortingprevexpensevar.idsor 
	and sortinglink.nlevel = @minoplevel
LEFT OUTER JOIN managersorting
	ON sorting.idsor = managersorting.idsor
WHERE sortingprevexpensevar.ayear = @ayear
	AND sortingprevexpensevar.adate between @firstday and ISNULL(@stop, {d '2079-06-06'}) 
	AND sorting.idsorkind = @idsorkind
	AND (sortinglink.idparent = @idsor OR @idsor IS NULL)
	AND ((managersorting.idman = @idman) or (@idman is null ))
	AND NOT EXISTS (SELECT *
		FROM #expense
		WHERE #expense.idsor = sortingprevexpensevar.idsor)	
GROUP BY sortingprevexpensevar.idsor,sorting.sortcode,sorting.description

--> Prende quelli non movimentati 2^ parte
INSERT INTO #expense
		(
		idsor,
		sortcode,	
		sortingdescription,
		prevision
		)	
SELECT 
	sortingprev.idsor, 
	sorting.sortcode,
	sorting.description,
	SUM(ISNULL(sortingprev.expenseprevision, 0))
FROM sortingprev
JOIN sorting
	on sorting.idsor = sortingprev.idsor
join sortinglink
	on sortinglink.idchild = sortingprev.idsor 
	and sortinglink.nlevel = @minoplevel
LEFT OUTER JOIN managersorting
	ON sorting.idsor = managersorting.idsor
WHERE sortingprev.ayear = @ayear
	AND sorting.idsorkind = @idsorkind
	AND (sortinglink.idparent = @idsor OR @idsor IS NULL)
	AND ((managersorting.idman = @idman) or (@idman is null ))
	AND NOT EXISTS (SELECT *
		FROM #expense
		WHERE #expense.idsor = sortingprev.idsor)	
GROUP BY sortingprev.idsor,sorting.sortcode,sorting.description

-----------------------------------------------------------------------------------------------------------
CREATE TABLE #appropriation
    (
	--idman int,
	idsor int,
	amount decimal(19,2),
	nphase tinyint			 
    )
INSERT INTO #appropriation
	(
	--idman,
	idsor,
	amount,
	nphase
	)
SELECT
	--ISNULL(managersorting.idman,0),
	expensesorted.idsor,
	SUM(ISNULL(expensesorted.amount, 0)),
	expense.nphase
FROM expensesorted
JOIN expense
	ON expensesorted.idexp = expense.idexp
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp 
	AND expenseyear.ayear= expensesorted.ayear
JOIN sorting
	on sorting.idsor = expensesorted.idsor
join sortinglink
	on sortinglink.idchild = expensesorted.idsor 
	and sortinglink.nlevel = @minoplevel
LEFT OUTER JOIN managersorting
	ON sorting.idsor = managersorting.idsor
WHERE expense.adate between @firstday and ISNULL(@stop, {d '2079-06-06'})
	AND expenseyear.ayear = @ayear
	AND expense.nphase = @nphasemovimento 
	AND ((managersorting.idman = @idman) or (@idman is null ))
	AND sorting.idsorkind = @idsorkind
	AND (sortinglink.idparent = @idsor OR @idsor IS NULL)
GROUP BY expensesorted.idsor,expense.nphase --,expense.idman

CREATE TABLE #var_appropriation
    (
	--idman int,
	idsor int,
	amount decimal(19,2),
	nphase tinyint							 
    )
INSERT INTO #var_appropriation
	(
	--idman,
	idsor,
	amount,
	nphase
	)
SELECT 
	--ISNULL(managersorting.idman,0),
	expensesorted.idsor, 
	SUM(ISNULL(expensevar.amount, 0)),
	expense.nphase
FROM expensevar
JOIN expensesorted
	ON expensesorted.idexp = expensevar.idexp
JOIN expense
	ON expensesorted.idexp = expense.idexp
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp 
	AND expenseyear.ayear= expensesorted.ayear
JOIN sorting
	on sorting.idsor = expensesorted.idsor
join sortinglink
	on sortinglink.idchild = expensesorted.idsor 
	and sortinglink.nlevel = @minoplevel
LEFT OUTER JOIN managersorting
	ON sorting.idsor = managersorting.idsor
WHERE expensevar.yvar = @ayear
	AND expenseyear.ayear = @ayear
	AND expense.nphase = @nphasemovimento
	AND expensevar.adate between @firstday and ISNULL(@stop, {d '2079-06-06'}) 
	AND ((managersorting.idman = @idman) or (@idman is null ))
	AND sorting.idsorkind = @idsorkind
	AND (sortinglink.idparent = @idsor OR @idsor IS NULL)
GROUP BY expensesorted.idsor,expense.nphase --,expense.idman

CREATE TABLE #payment
    (
	--idman int,
	idsor int,
	amount decimal(19,2)					 
    )

INSERT INTO #payment
	(
	--idman,
	idsor,
	amount
	)
SELECT
	--ISNULL(managersorting.idman,0),
	expensesorted.idsor,
	SUM(CASE WHEN expensesorted.amount >= paymentemitted.amount THEN paymentemitted.amount else expensesorted.amount END)
FROM expenseyear
JOIN paymentemitted
	ON expenseyear.idexp = paymentemitted.idexp 
-- deve prendere i pagamenti degli impegno classificati
JOIN expenselink EL
	ON EL.idchild = expenseyear.idexp  
	AND EL.nlevel = @nphasemovimento
JOIN expensesorted
	ON expensesorted.idexp = EL.idparent
JOIN sorting
	on sorting.idsor = expensesorted.idsor
join sortinglink
	on sortinglink.idchild = expensesorted.idsor 
	and sortinglink.nlevel = @minoplevel
LEFT OUTER JOIN managersorting
	ON sorting.idsor = managersorting.idsor
WHERE paymentemitted.competencydate between @firstday and ISNULL(@stop, {d '2079-06-06'})
	AND expenseyear.ayear = @ayear
	AND ((managersorting.idman = @idman) or (@idman is null ))
	AND sorting.idsorkind = @idsorkind
	AND expensesorted.ayear = @ayear
	AND (sortinglink.idparent = @idsor OR @idsor IS NULL)
GROUP BY expensesorted.idsor--,expense.idman

CREATE TABLE #var_payment
    (
	--idman int,
	idsor int,
	amount decimal(19,2)					 
    )
INSERT INTO #var_payment
	(
	--idman,
	idsor,
	amount
	)
SELECT 
	--ISNULL(managersorting.idman,0),
	expensesorted.idsor,
	SUM(ISNULL(expensevar.amount, 0))
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp 
	AND expenseyear.ayear = @ayear
JOIN expense 
	on expense.idexp = expenseyear.idexp
JOIN paymentemitted
	ON expensevar.idexp = paymentemitted.idexp 
-- deve prendere le var di pagamenti degli impegno classificati
JOIN expenselink EL
	ON EL.idchild = expense.idexp  AND EL.nlevel = @nphasemovimento
JOIN expensesorted
	ON expensesorted.idexp = EL.idparent
JOIN sorting
	on sorting.idsor = expensesorted.idsor
join sortinglink
	on sortinglink.idchild = expensesorted.idsor 
	and sortinglink.nlevel = @minoplevel
LEFT OUTER JOIN managersorting
	ON sorting.idsor = managersorting.idsor
WHERE expensevar.yvar = @ayear
	AND expensevar.adate between @firstday and ISNULL(@stop, {d '2079-06-06'})
	AND ((managersorting.idman = @idman) or (@idman is null ))
	AND sorting.idsorkind = @idsorkind
	AND expensesorted.ayear = @ayear
	AND (sortinglink.idparent = @idsor OR @idsor IS NULL)
GROUP BY expensesorted.idsor--,expense.idman

/*
UPDATE #expense
SET
-- stiamo correggendo il valore degli singoli impegni, aggiungeno le eventuali variazioni ai movimenti
	appropriation_amount = appropriation_amount + (SELECT ISNULL(SUM(amount),0) 
		FROM expensevar
		join expense on expensevar.idexp = expense.idexp
		WHERE expensevar.idexp= #expense.nappropriation
			and expensevar.adate between @start and ISNULL(@stop, {d '2079-06-06'})
			and expensevar.yvar = @ayear
			and expense.nphase  = @nphasemovimento
			and #expense.nvarappropriation is null
		),

	payment_amount = payment_amount + (SELECT ISNULL(SUM(amount),0) 
		FROM expensevar
		join expense on expensevar.idexp = expense.idexp
		WHERE expensevar.idexp = #expense.npayment
			and expensevar.adate between @start and ISNULL(@stop, {d '2079-06-06'})
			and expensevar.yvar = @ayear
			and expense.nphase = @maxexpensephase
			and #expense.nvarpayment is null
		),
	reportdate =@stop,
	ayear=@ayear
	
	*/

	

--aggiusta la situazione per i reintegri fondo piccole spese
UPDATE #expense set payment_amount=appropriation_amount where appropriation_amount<payment_amount


UPDATE #expense SET 
	varprev = ISNULL((SELECT SUM(sortingprevexpensevar.amount)
			FROM sortingprevexpensevar
			JOIN sorting
				ON sorting.idsor = sortingprevexpensevar.idsor 
			JOIN sortinglink 
				on sortinglink.idchild = sortingprevexpensevar.idsor 
				and sortinglink.nlevel = sorting.nlevel -- @nlevelinput
			WHERE sortingprevexpensevar.ayear = @ayear 
				AND sorting.idsorkind     = @idsorkind
				AND sortingprevexpensevar.idsor = #expense.idsor
				AND sortingprevexpensevar.adate <= ISNULL(@stop, {d '2079-06-06'})
			), 0),

	appropriation = (SELECT SUM(ISNULL(#appropriation.amount,0))  
				FROM #appropriation
				WHERE /*#appropriation.idman = #expense.idman
					and*/ #appropriation.idsor = #expense.idsor
					and #appropriation.nphase = @nphasemovimento ), 
	var_appropriation = (SELECT SUM(ISNULL(#var_appropriation.amount,0))  
				FROM #var_appropriation
				WHERE /*#var_appropriation.idman = #expense.idman
					and*/ #var_appropriation.idsor = #expense.idsor
					and #var_appropriation.nphase = @nphasemovimento),
	payment = (SELECT SUM(ISNULL(#payment.amount,0))  
				FROM #payment
				WHERE  #payment.idsor = #expense.idsor
					/*and #payment.idman = #expense.idman*/), 
	var_payment = (SELECT SUM(ISNULL(#var_payment.amount,0))  
				FROM #var_payment
				WHERE   #var_payment.idsor = #expense.idsor
					/*and #var_payment.idman = #expense.idman*/)

UPDATE #expense
SET	prevision= ISNULL(
	( SELECT SUM(sortingprev.expenseprevision)
	FROM sortingprev
	JOIN sorting
		ON sorting.idsor = sortingprev.idsor 
	JOIN sortinglink 
		on sortinglink.idchild = sortingprev.idsor 
		and sortinglink.nlevel = sorting.nlevel --@nlevelinput
	WHERE sorting.idsorkind=@idsorkind and sortingprev.ayear = @ayear 
	AND sortingprev.idsor = #expense.idsor --  sortinglink.idparent = #expense.idsor
	),0)
  
			

DECLARE @finphase varchar(50)
DECLARE @maxphase varchar(50)

select @finphase = description from  expensephase where nphase = @nphasemovimento
select @maxphase = description from  expensephase where nphase = @maxexpensephase

SELECT 
	@idsorkind as idsorkind,
	@descriptionsortingkind AS descriptionsortingkind,
	sortcode,
	sortingdescription,
	idsor,
	#expense.idfin,
	F.codefin,
	F.title as fintitle,
	nphase,
	rowkind,
	sum(isnull(prevision,0)) as prevision,
	sum(isnull(#expense.varprev,0)) as  varprev ,
	sum(isnull(appropriation,0)) as  appropriation ,
	sum(isnull(var_appropriation,0)) as  var_appropriation ,

	sum(isnull(payment,0)) as  payment ,
	sum(isnull(var_payment,0))as  var_payment ,
	adate,
	description,
	REG.title as registry,
	--flagarrear,
	nappropriation,
	ymovappropriation,
	nmovappropriation,	
	yvarappropriation,
	nvarappropriation,
	sum(isnull(appropriation_amount,0)) as appropriation_amount,
	sum(isnull(available_appropriation,0)) as available_appropriation,

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
	reportdate,
	#expense.ayear,
	idappropriation,
	MAN.title as manager,
	ISNULL(#expense.idman,0) AS idman,

	@finphase AS finphase,
	@maxphase AS maxphase,
	MANEXPENSE.title as expensemanager
FROM #expense
LEFT OUTER JOIN fin F
	ON #expense.idfin = F.idfin
LEFT OUTER JOIN manager MAN  
	ON #expense.idman = MAN.idman
LEFT OUTER JOIN manager MANEXPENSE  
	ON #expense.expenseidman = MANEXPENSE.idman
LEFT OUTER JOIN registry REG
	On #expense.idreg = REG.idreg
GROUP BY idsor,sortcode,sortingdescription,
	#expense.idfin,F.codefin,F.title,nphase,rowkind,
	adate,description,REG.title,
	nappropriation,ymovappropriation,nmovappropriation,yvarappropriation,nvarappropriation,
	npayment,ymovpayment,nmovpayment,yvarpayment,nvarpayment,
	npay,printdate,annulmentdate,transmissiondate,transactiondate,
	reportdate,#expense.ayear,idappropriation,
	MAN.title,#expense.idman,#expense.expenseidman,MANEXPENSE.title
ORDER BY sortcode,manager

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





