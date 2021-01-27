
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_pluriennale_spesa_bil]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_pluriennale_spesa_bil]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE rpt_partitario_pluriennale_spesa_bil
	@ayearstart  int,
	@ayearstop  int,
	@nlevel tinyint,
	@codefin varchar(50),
	@stop datetime,
	@flagnofficial	char(1),
	@suppressifblank char(1),
	@idman int	
AS
BEGIN

-- exec rpt_partitario_pluriennale_spesa_bil 1999, 2008, 3,'010203',{ts '2008-05-22 00:00:00'},'S','S',NULL

DECLARE @levelusable tinyint
SELECT 	@levelusable = MIN(nlevel)
FROM 	finlevel
WHERE 	flag&2 <> 0 AND ayear = @ayearstop

IF (@levelusable < @nlevel)
BEGIN	
	SET @levelusable = @nlevel
END

DECLARE @previsionkind char(1) 
SELECT  @previsionkind =  
	 CASE 
		WHEN fin_kind IN (1,3) THEN 'C'
		WHEN fin_kind = 2 THEN 'S'
	 END
FROM  config 
WHERE config.ayear = @ayearstop

DECLARE @regphase tinyint 
DECLARE @finphase tinyint
SELECT  @regphase = expenseregphase,
		@finphase = expensefinphase FROM uniconfig

DECLARE @finname varchar(50)
SELECT  @finname = description FROM expensephase WHERE nphase = @finphase

DECLARE @maxexpensephase tinyint 
SELECT  @maxexpensephase = MAX(nphase) FROM expensephase
DECLARE @phasecassa varchar(50)
SELECT  @phasecassa = description FROM expensephase WHERE nphase = @maxexpensephase


-- Seleziona la seconda/terza fase da inserire nella stampa 
DECLARE @secondphase varchar(50)
DECLARE @thirdphase varchar(50)
DECLARE @second tinyint
-- la seconda fase è quella successiva alla prima MA non deve essere quella del pagamento
SELECT  @secondphase = description, @second = nphase FROM expensephase WHERE nphase = @finphase+1 and nphase < @maxexpensephase
-- la terza fase è quella successiva alla seconda MA non deve essere quella del pagamento
SELECT  @thirdphase = description FROM expensephase  WHERE nphase =  @second + 1 and nphase < @maxexpensephase

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where codefin = @codefin and (flag&1)<>0 and ayear = @ayearstop ) ,@nlevel)

IF (@nlevel < @level_input ) AND (@codefin is not null)
BEGIN
	SET  @nlevel = @level_input
END

IF (@codefin is not null)
SET @codefin = @codefin + '%'
-- con i livelli @nlevel e @level_input saranno gestiti le stampe a seconda della selezione del livello di input
-- ossia se scegliamo di fare una stampa x articolo, vedremo gli articoli laddove il cap. non è articolato vedremo il capitolo
-- se scelgiamo come livello articolo e selezioniamo un capitolo vedremo tutti gli articoli di quel capitolo

DECLARE @level varchar(50)
SELECT  @level = description 
	FROM    finlevel
	WHERE   nlevel = @nlevel AND ayear = @ayearstop

CREATE TABLE #expense
(
	ayear  int,
	codefin varchar(50),
	finprintingorder  varchar(50),
	title  varchar(150),
	idfin int,
	rowkind	int,
	idmov int,
	nphase tinyint,
	operationdate datetime,
	operationkind varchar(55),
	idreg int,
	ymov int,
	nmov int,
	nofficial int,
	nsubmov int,
	ndoc int,
	description varchar(150),
        doc varchar(150),
	initialprevision decimal(19,2),
	finvar decimal(19,2),
	finphase_amount decimal(19,2),
	cassaphase_amount decimal(19,2),
	emessiondate datetime,
	printeddate datetime,
	trasmitteddate datetime,
	transactiondate datetime,
	annulmentdate datetime,
	annotations varchar(400),
	available decimal(19,2),
	hierarchy varchar (50),
	tothierarchy varchar (50),
	idman int
)

DECLARE @cashvaliditykind int
SELECT  @cashvaliditykind = cashvaliditykind
FROM    config
WHERE   ayear = @ayearstop

/*
Per le VARIAZIONI DI PREVISIONE 
vanno prese SOLO quelle che incidono sulla previsione finale. 
Quindi, vanno ESCLUSE quelle che ribaltano la prev. disponibile al 31/12 in prev. iniziale al 01/01 perchè non incidono sulla previsione dell'UPB, 
vanno INCLUSE le var. di prev. insite nella previsione, calcolate come la prev.di finyear + var. di assestamento e 
SOTTRAENDO il disponibile dell'anno prec. con i dovuti finlookup. 
*/

--Ora sta prendendo quelle che deve elencare: sta escludendo SIA quelle di assestamento e ripartizione, perchè saranno sommate 
-- a quelle insite alla prev, CHE quelle fatte per ribaltare la prev di fine anno.
	INSERT INTO #expense
		(
		ayear,
		idfin,
		rowkind,
		operationdate,
		operationkind,
		ymov,
		nmov,
		nofficial,
		description,
		finvar,
		hierarchy,
		idman
		)
	SELECT 	
		finvar.yvar,
		isnull(FL1.idparent, fin.idfin),
		2,
		finvar.adate,
		'Var.prev.',-- > CHE INCIDONO SULLA PREVISIONE FINALE
		finvar.yvar,
		finvar.nvar,
		CASE finvar.official
			WHEN 'S' THEN finvar.nofficial
			ELSE NULL
		END,
		finvar.description,
		sum(finvardetail.amount),-- sommare gli importi delle var serve nel caso di capitoli articolati  
		finvar.yvar,
		finlast.idman
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN finlast
		ON finvardetail.idfin = finlast.idfin
	left outer JOIN finlink
		ON finlink.idchild = finvardetail.idfin	
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = finvardetail.idfin	
		AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = isnull(FL1.idparent, finvardetail.idfin)
	WHERE  finvar.flagprevision = 'S'	
		AND finvar.idfinvarstatus = 5
		AND finvar.variationkind not in ('2','3','5')-- Ripartizione e Assestamento, iniziale
		AND finvar.yvar between isnull(@ayearstart,1900) and @ayearstop
		AND finvar.adate <=  @stop
		AND ((fin.flag&1)<>0) 
		AND (@codefin IS NULL OR fin.codefin like @codefin )
		AND (finlast.idman = @idman OR @idman is null )
	GROUP BY finvar.yvar, isnull(FL1.idparent, fin.idfin), finvar.adate, finvar.nvar, finvar.nofficial,
		finvar.official, finvar.description, finlast.idman

/*
 Sta calcolando quelle insite, in cui sono automaticamente comprese quelle di assestamento che ha fatto l'utente
 VARIAZIONI INSITE NELLA PREVISIONE = Previsione dell'anno + Var. di Ripartizione/Assestamento - Disp. a Pagare Anno prec.
 Ove  Disp. a Pagare Anno prec = Previsione anno prec. + Var. di previsione - ( Pagamenti prec + Var.Pagamenti prec)
*/

-- Previsione dell'anno + Var. di Ripartizione/Assestamento
CREATE TABLE #embedded_increase
    (
	ayear int,
	idfin int,
	amount decimal(19,2),
	idman int					 
    )
INSERT INTO #embedded_increase
    (
	ayear,
	idfin,
	amount,
	idman 
    )
SELECT 
	finyear.ayear,
	finyear.idfin,
	isnull(sum(finyear.prevision),0)
	+ 
	ISNULL(
		(SELECT SUM(FDV.amount)	
		FROM finvardetail FDV
		JOIN finvar FV
			ON FV.yvar = FDV.yvar
			AND FV.nvar = FDV.nvar
		JOIN fin F
			ON FDV.idfin = F.idfin
		WHERE FDV.yvar = finyear.ayear
			AND FV.flagprevision='S'
			AND FV.idfinvarstatus = 5
			--AND FDV.idfin = finyear.idfin 
			AND F.codefin like fin.codefin + '%'
			AND FV.variationkind in ('2','3'))
		,0),
	finlast.idman
FROM finyear
JOIN fin
	ON fin.idfin = finyear.idfin 
JOIN finlast
	ON finyear.idfin = finlast.idfin
JOIN finlevel fl
	ON fin.nlevel = fl.nlevel 
	AND fin.ayear = fl.ayear
WHERE 	((fin.flag&1)<>0) 
	AND finyear.ayear between isnull(@ayearstart,1900) and @ayearstop
	AND (fin.nlevel = @levelusable
		OR (fin.nlevel < @levelusable
			AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = fin.idfin)
			AND (fl.flag&2)<>0
		   )
		)
	AND (@codefin IS NULL OR fin.codefin like @codefin )
--> Le var insite le deve calcolare dal 2° anno in poi, nel primo anno 
-- non vanno calcolate, per il 1° anno sarà presa la var. iniziale e poi le variaizoni che fa l'utente N e S
	AND finyear.ayear > (select min(birtyear.ayear) from finyear birtyear 
				JOIN fin F2
					ON birtyear.idfin = F2.idfin
				where F2.codefin = fin.codefin)	
	AND (finlast.idman = @idman OR @idman is null )
GROUP BY finyear.ayear,finyear.idfin,fin.codefin,finyear.prevision,finlast.idman

/*
SELECT codefin,#embedded_increase.ayear, #embedded_increase.idfin, #embedded_increase.idupb, amount as 'Previsione dell''anno + Var. di Ripartizione/Assestamento' FROM #embedded_increase -- sara
join fin
on fin.idfin = #embedded_increase.idfin
order by #embedded_increase.ayear
*/

-- Previsione anno prec. + Var. di previsione.
CREATE TABLE #previous
    (
	ayear int,
	idfin int,
	prevision decimal(19,2),					 
	payment decimal(19,2),
	idman int
    )
INSERT INTO #previous
    (
	ayear,
	idfin,
	prevision,
	payment,
	idman
    )
	SELECT 
		finyear.ayear,
		finyear.idfin,
		isnull(sum(finyear.prevision),0)
		 + ISNULL(
			(SELECT SUM(FDV.amount)	
			FROM finvardetail FDV
			JOIN finvar FV
				ON FV.yvar = FDV.yvar
				AND FV.nvar = FDV.nvar
			JOIN fin F
				ON FDV.idfin = F.idfin
			WHERE FDV.yvar = finyear.ayear
				AND FV.flagprevision='S'
				AND FV.variationkind <> 5
				AND FV.idfinvarstatus = 5
				--AND FDV.idfin = finyear.idfin 
				AND F.codefin like fin.codefin + '%')
			,0),
-- se è un bilancio di competenza/cassa o solo competenza legge la fase di bilancio ai fini di calcolarsi il disp. a impegnare dell'anno prec
-- se è un bilancio di sola cassa la fase di pagamento ai fini di calcolarsi il disp. a pagare dell'anno prec.
CASE @previsionkind 
		WHEN 'C' 
		THEN
		ISNULL((
			SELECT SUM(ISNULL(expenseyear.amount, 0)) -- ISNULL(expensevar.amount, 0))
			FROM expense
			JOIN expenseyear
				ON expenseyear.idexp = expense.idexp 
			JOIN expensetotal 
				ON  expenseyear.idexp = expensetotal.idexp 
				AND expenseyear.ayear = expensetotal.ayear 
			/*LEFT OUTER JOIN expensevar
				ON expenseyear.idexp = expensevar.idexp
				AND expenseyear.ayear = expensevar.yvar */
			LEFT OUTER JOIN finlink 
				ON finlink.idchild = expenseyear.idfin 
				AND finlink.nlevel = @nlevel
			LEFT OUTER JOIN finlink FL
				ON FL.idchild = expenseyear.idfin 
				AND FL.nlevel = @level_input
			WHERE expense.adate <= @stop
				AND ((expensetotal.flag&1)=0)
				AND  isnull(FL.idparent, expenseyear.idfin)=finyear.idfin
				AND expense.nphase = @finphase 
				--AND ISNULL(expensevar.adate,{d '1900-01-01'})<= @stop
		),0)
		+ 	-- Ho separato le var. perchè le var le deve prendere anche in anni deiversi da quello di creazione della spesa.
			-- Se per esempio devo diminuire un impegno residuo.
		ISNULL((
			SELECT SUM(ISNULL(expensevar.amount, 0))
			FROM expense
			JOIN expenseyear
				ON expenseyear.idexp = expense.idexp 
			JOIN expensevar
				ON expense.idexp = expensevar.idexp
				AND expense.ymov = expensevar.yvar 
			LEFT OUTER JOIN finlink 
				ON finlink.idchild = expenseyear.idfin 
				AND finlink.nlevel = @nlevel
			LEFT OUTER JOIN finlink FL
				ON FL.idchild = expenseyear.idfin 
				AND FL.nlevel = @level_input
			WHERE expense.adate <= @stop
				AND  isnull(FL.idparent, expenseyear.idfin)=finyear.idfin
				AND expense.nphase = @finphase 
				AND ISNULL(expensevar.adate,{d '1900-01-01'})<= @stop
		),0)
		ELSE 
		ISNULL((
			SELECT	SUM(ISNULL(paymentemitted.amount,0) + ISNULL(expensevar.amount,0) )
			FROM paymentemitted
			JOIN expenseyear
				ON expenseyear.idexp = paymentemitted.idexp 
			JOIN expense 
				ON expense.idexp = expenseyear.idexp
			LEFT OUTER JOIN expensevar
				ON expenseyear.idexp = expensevar.idexp 
			LEFT OUTER JOIN finlink 
				ON finlink.idchild = expenseyear.idfin 
				AND finlink.nlevel = @nlevel
			LEFT OUTER JOIN finlink FL
				ON FL.idchild = expenseyear.idfin 
				AND FL.nlevel = @level_input
			WHERE paymentemitted.competencydate <= @stop
				AND  isnull(FL.idparent, expenseyear.idfin)=finyear.idfin
				AND ISNULL(expensevar.adate,{d '1900-01-01'})<= @stop
			),0)
END,
	finlast.idman
	FROM finyear
	JOIN fin
		ON fin.idfin = finyear.idfin 
	JOIN finlast
		ON fin.idfin = finlast.idfin
	JOIN finlevel fl
		ON fin.nlevel = fl.nlevel 
		AND fin.ayear = fl.ayear
	WHERE 	((fin.flag&1)<>0) 
		AND finyear.ayear between isnull(@ayearstart,1900) and @ayearstop
		AND (fin.nlevel = @levelusable
			OR (fin.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = fin.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		AND (@codefin IS NULL OR fin.codefin like @codefin )
		AND (finlast.idman = @idman OR @idman is null )
	GROUP BY finyear.ayear,fin.codefin,finyear.idfin,finyear.prevision,finlast.idman

/*
select codefin,#previous.ayear, #previous.idfin, idupb,prevision as ' Previsione anno prec. + Var. di previsione.',payment as 'Pag.prec+var' from #previous -- sara
join fin
on fin.idfin = #previous.idfin
order by #previous.ayear

RETURN
*/
-- Inserisce nella Tab. principale le variazioni Insite nella prev
/*
 Var. Insite = Previsione dell'anno + Var. di Ripartizione/Assestamento - Disp. a Pagare Anno prec
 ove  Disp. a Pagare Anno prec = Previsione anno prec. + Var. di previsione - ( Pagamenti prec + Var.Pagamenti prec)
*/
	INSERT INTO #expense
		(
		ayear,
		idfin,
		rowkind,
		operationdate,
		operationkind,
		ymov,
		description,
		finvar,
		hierarchy,
		I.idman -- dovrebbe essere uguale a P.idman 
		)
-- I LEFT OUTER JOIN sono stati introdotti perchè può capitare che un capitolo del 2002 confluisca in un capitolo del 2003 nuovo, ossia creato nel 2003
	SELECT 
		I.ayear,
		I.idfin,
		2,
		CONVERT(datetime, '01-01-' + CONVERT(varchar(4),I.ayear), 105),
		'Var.prev.',--> INSITE NELLA PREVISIONE
		I.ayear,
		'Adeguamento previsione',
		ISNULL(I.amount,0) - ( ISNULL(P.prevision,0) - ISNULL(P.payment,0) )
		+ ( ISNULL(FY_I.prevision2,0) + ISNULL(FY_I.prevision3,0) + ISNULL(FY_I.prevision4,0) + ISNULL(FY_I.prevision5,0) )
		- ( ISNULL(FY_P.prevision2,0) + ISNULL(FY_P.prevision3,0) + ISNULL(FY_P.prevision4,0) + ISNULL(FY_P.prevision5,0) ),
		I.ayear,
		I.idman
	FROM #embedded_increase I
	JOIN finyear FY_I
		ON FY_I.idfin = I.idfin
	LEFT OUTER JOIN finlookup F
		ON I.idfin = F.newidfin
	LEFT OUTER JOIN #previous P
		ON P.idfin = F.oldidfin
	JOIN finyear FY_P
		ON FY_P.idfin = P.idfin
	WHERE ISNULL(P.ayear,I.ayear - 1) = I.ayear - 1 -- Altri filtri sui parametri @... non servono perchè sono stati usati nelle tab. Temporanee
	AND (
		(SELECT codefin FROM fin WHERE idfin = F.oldidfin)=(SELECT codefin FROM fin WHERE idfin = F.newidfin)
		OR 
		(SELECT codefin FROM fin WHERE idfin = F.oldidfin) is null
		)
	
/*
SELECT fin.codefin,* FROM #expense 
join fin
on fin.idfin = #expense.idfin
where fin.codefin like '102310%'   or fin.codefin like '102440%'  
AND rowkind = 2 
order by #expense.ayear -- sara

RETURN
*/
					
-- Movimenti di Spesa / fase bilancio
INSERT INTO #expense(
		ayear,
		idfin,
		idmov,
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		description,
		idreg,
		finphase_amount,	
		available,
		idman 
		)
		SELECT 
		expenseyear.ayear,
		isnull(FL1.idparent, fin.idfin),
		expense.idexp,
		3,
		expense.nphase,
		expense.adate,
		@finname,
		expense.ymov,
		expense.nmov,
		expense.description,
		expense.idreg,
		sum(expenseyear.amount),
		sum(expensetotal.available),
		finlast.idman
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
		JOIN finlast
			ON finlast.idfin  =expenseyear.idfin
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		left outer JOIN finlink FL1
			ON FL1.idchild = expenseyear.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)
		left outer JOIN finlink
			ON finlink.idchild = fin.idfin	
			AND finlink.nlevel = @level_input
		WHERE expense.nphase = @finphase
			AND expense.adate <= @stop
			AND expenseyear.ayear between isnull(@ayearstart,1900) and @ayearstop
			AND (expensetotal.flag&1)= 0 -- Solo quelli di competenza dell'anno
			AND ((fin.flag&1)<>0) 
			AND (@codefin IS NULL OR fin.codefin like @codefin )
			AND ((finlast.idman = @idman) or (@idman is null ))
		GROUP BY expenseyear.ayear,isnull(FL1.idparent, fin.idfin),
			expense.idexp,expense.nphase,expense.adate,expense.ymov,expense.nmov,
			expense.description,expense.idreg,finlast.idman

-- Variazione movimenti di spesa / fase bilancio
	INSERT INTO #expense
		(
		ayear,
		idfin,
		idmov,
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		nsubmov,
		description,
		idreg,
		finphase_amount,
		idman
		)
	SELECT 
		expenseyear.ayear,
		isnull(FL1.idparent, fin.idfin),
		expense.idexp,
		4,
		expense.nphase,
		expensevar.adate,
		'Var.' + @finname,
		expense.ymov,
		expense.nmov,
		expensevar.nvar,
		expensevar.description,
		expense.idreg,
		SUM(expensevar.amount),
		finlast.idman
	FROM expensevar
	JOIN expense
		ON expense.idexp = expensevar.idexp
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
	JOIN expensetotal
		ON expensetotal.idexp = expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	JOIN finlast
		ON expenseyear.idfin = finlast.idfin	
	left outer JOIN finlink
		ON finlink.idchild = expenseyear.idfin	
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = expenseyear.idfin	
		AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)
	WHERE expensevar.yvar between isnull(@ayearstart,1900) and @ayearstop
		AND expensevar.adate <= @stop
		AND expense.nphase = @finphase
		AND expenseyear.ayear between isnull(@ayearstart,1900) and @ayearstop
		AND (expensetotal.flag&1)= 0
		AND ((fin.flag&1)<>0)
		AND (@codefin IS NULL OR fin.codefin like @codefin )
		AND ((finlast.idman = @idman) or (@idman is null ))
	GROUP BY expenseyear.ayear,isnull(FL1.idparent, fin.idfin),
		expense.idexp,expense.nphase,expensevar.adate,
		expense.ymov,expense.nmov,expensevar.nvar,expensevar.description,
		expense.idreg,finlast.idman

---	CILCLO WHILE
--------------------------
DECLARE @i int
SELECT @i = CONVERT(int,@finphase)
WHILE @i < (@maxexpensephase -1)
BEGIN
	SELECT @i = @i + 1
		INSERT INTO #expense
			(
			ayear,
			idfin,
			idmov,
			rowkind,
			nphase,
			operationdate,
			operationkind,
			ymov,
			nmov,
			description,
			idreg,
			finphase_amount,
			idman
			)
		SELECT 
			expenseyear.ayear,
			isnull(FL1.idparent, fin.idfin),
			expense.idexp,
			5+(@i-@finphase-1)*2,
			expense.nphase,
			expense.adate,
			(SELECT  description
				FROM expensephase
				WHERE nphase = @i),
			expense.ymov,
			expense.nmov,
			expense.description,
			expense.idreg,
			sum(expenseyear.amount),
			finlast.idman
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlast 
			ON finlast.idfin=expenseyear.idfin
		left outer JOIN finlink
			ON finlink.idchild = expenseyear.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = expenseyear.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)
		WHERE  expenseyear.ayear between isnull(@ayearstart,1900) and @ayearstop
			AND (expensetotal.flag&1) = 0 --solo la competenza ci interessa
			AND expense.nphase = @i
			AND ((fin.flag&1)<>0)
			AND (@codefin IS NULL OR fin.codefin like @codefin )
			AND (expense.adate <= @stop)
			AND ((finlast.idman = @idman) or (@idman is null ))
		GROUP BY expenseyear.ayear,isnull(FL1.idparent, fin.idfin),
			expense.idexp,expense.nphase,expense.adate,
			expense.ymov,expense.nmov,expense.description,
			expense.idreg,finlast.idman

		INSERT INTO #expense
			(
			ayear,	
			idfin,
			idmov,
			rowkind,
			nphase,
			operationdate,
			operationkind,
			ymov,
			nmov,
			nsubmov,
			description,
			idreg,
			finphase_amount,
			idman
			)
		SELECT 
			expenseyear.ayear,
			isnull(FL1.idparent, fin.idfin),
			expense.idexp,
			6+(@i-@finphase-1)*2,
			expense.nphase,
			expensevar.adate,
			'Var.' + (SELECT  description
					FROM expensephase
					WHERE nphase = @i),
			expense.ymov,
			expense.nmov,
			expensevar.nvar,
			expensevar.description,
			expense.idreg,
			sum(expensevar.amount),
			finlast.idman
		FROM expensevar
		JOIN expense
			ON expense.idexp = expensevar.idexp
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlast
			ON finlast.idfin = expenseyear.idfin  
		left outer JOIN finlink
			ON finlink.idchild = expenseyear.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = expenseyear.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)	
		WHERE  expense.nphase = @i
			AND ((fin.flag&1)=1) -- Spesa
			AND isnull(expensevar.autokind,'') <>'22' 
			AND (@codefin IS NULL OR fin.codefin like @codefin )
			AND expensevar.yvar between isnull(@ayearstart,1900) and @ayearstop
			AND expenseyear.ayear between isnull(@ayearstart,1900) and @ayearstop
			AND (expensetotal.flag&1) = 0
			AND expensevar.adate <= @stop
			AND ((finlast.idman = @idman) or (@idman is null ))
		GROUP BY expenseyear.ayear,isnull(FL1.idparent, fin.idfin),
			expense.idexp,expense.nphase,
			expensevar.adate,expense.ymov,expense.nmov,expensevar.nvar,
			expensevar.description,expense.idreg,finlast.idman
  
	CONTINUE
END
---	FINE CILCLO WHILE
--------------------------

-- Movimenti di spesa / fase cassa
INSERT INTO #expense
		(
		ayear,
		idfin,
		idmov,
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		ndoc,
		description,
		doc,
		idreg,
		cassaphase_amount,
		idman
		)
SELECT 
	HPV.ymov,
	isnull(FL1.idparent, fin.idfin),
	HPV.idexp,
	15,
	@maxexpensephase,
	HPV.competencydate,
	@phasecassa,
	HPV.ymov,
	HPV.nmov,
	HPV.npay,
	HPV.description,
	CASE
		WHEN HPV.doc IS NOT NULL AND 
			HPV.docdate IS NULL THEN
			'Pag. ' + HPV.doc
		WHEN HPV.doc IS NOT NULL AND
			HPV.docdate IS NOT NULL THEN
			'Pag. ' + HPV.doc + 
			' del ' + CONVERT(varchar(20), HPV.docdate, 105)
		ELSE
			(NULL)
	END,
	HPV.idreg,
	SUM(HPV.amount),
	finlast.idman
FROM historypaymentview HPV
JOIN finlast 
	ON finlast.idfin = HPV.idfin		
left outer JOIN finlink
	ON finlink.idchild = HPV.idfin	
	AND finlink.nlevel = @level_input
left outer JOIN finlink FL1
	ON FL1.idchild = HPV.idfin	
	AND FL1.nlevel = @nlevel
JOIN fin
	ON fin.idfin = isnull(FL1.idparent, HPV.idfin)--FL1.idparent
WHERE HPV.competencydate <= @stop
	AND HPV.ymov between isnull(@ayearstart,1900) and @ayearstop
	AND ((fin.flag&1)=1)
	AND (@codefin IS NULL OR fin.codefin like @codefin )
	AND ((finlast.idman = @idman) or (@idman is null ))
GROUP BY HPV.ymov,isnull(FL1.idparent, fin.idfin),HPV.idexp,HPV.competencydate,
	HPV.ymov,HPV.nmov,HPV.npay,HPV.description,HPV.doc,HPV.docdate, 
	HPV.idreg,finlast.idman

-- Variazione ai Movimenti di spesa / fase cassa
IF (@cashvaliditykind <> 4)
BEGIN
	INSERT INTO #expense
		(
		ayear,
		idfin,
		idmov,
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		nsubmov,
		ndoc,
		description,
		doc,
		idreg,
		cassaphase_amount,
		idman
		)
	SELECT 
		HPV.ymov,
		isnull(FL1.idparent, fin.idfin),
		expense.idexp,
		20,
		expense.nphase,
		expensevar.adate,
		'Var.' + @phasecassa,
		expense.ymov,
		expense.nmov,
		expensevar.nvar,
		HPV.npay,
		expensevar.description,
		CASE
			WHEN expensevar.doc IS NOT NULL AND 
				expensevar.docdate IS NULL THEN
				'Pag. ' + expensevar.doc
			WHEN expensevar.doc IS NOT NULL AND
				expensevar.docdate IS NOT NULL THEN
				'Pag. ' + expensevar.doc + 
				' del ' + CONVERT(varchar(20), expensevar.docdate, 105)
			ELSE
		(NULL)
		END,
		expense.idreg,
		sum(expensevar.amount),
		finlast.idman
		FROM expensevar
		JOIN historypaymentview HPV
			ON HPV.idexp = expensevar.idexp
		JOIN expense
			ON expense.idexp = expensevar.idexp
		JOIN finlast
			ON finlast.idfin = HPV.idfin
		left outer JOIN finlink
			ON finlink.idchild = HPV.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = HPV.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, HPV.idfin)
		WHERE expensevar.yvar between isnull(@ayearstart,1900) and @ayearstop
			AND expensevar.adate <= @stop
			AND isnull(expensevar.autokind,'') <>'22' 
			AND HPV.ymov between isnull(@ayearstart,1900) and @ayearstop
			AND ((fin.flag&1)=1) -- = 'S'
			AND (@codefin IS NULL OR fin.codefin like @codefin )
			AND HPV.competencydate <= @stop
			AND ((finlast.idman = @idman) or (@idman is null ))
		GROUP BY HPV.ymov,isnull(FL1.idparent, fin.idfin),expense.idexp,
			expense.nphase,expensevar.adate,expense.ymov,
			expense.nmov,expensevar.nvar,HPV.npay,expensevar.description,
			expensevar.doc,expensevar.docdate,expense.idreg,finlast.idman

END

/*----------------------------------------------------------------------------------------------------------------------------------
Ora si sta calcolando la PREVISIONE INIZIALE, e la mette nel primo anno di esistenza del fondo:
Prev. pluriennale iniziale 2008 = Prev.annuale del 2008 + Prev. Anni futuri + Impegni Anni precedenti (o Pagamenti anni precedenti)
-----------------------------------------------------------------------------------------------------------------------------------*/
/*SELECT fin.codefin,* FROM #expense 
join fin
on fin.idfin = #expense.idfin
where fin.codefin like '010333024%'
order by #expense.ayear */
-----------------------------

UPDATE #expense SET codefin =(select codefin FROM fin 
				WHERE idfin = #expense.idfin )
		WHERE #expense.codefin IS NULL

INSERT INTO #expense
(
	ayear,
	codefin,
	rowkind,
	operationkind,
	initialprevision,
	idman
)
SELECT isnull(@ayearstart, 
		(select min(birtyear.ayear) from finyear birtyear
			join fin F2
				on birtyear.idfin = F2.idfin
			join finlast FL2
				ON FL2.idfin = F2.idfin
			where  ((F2.flag&1)=1) 
				AND F2.codefin = #expense.codefin
				and isnull(FL2.idman,0) = isnull(#expense.idman,0)
		)),
	#expense.codefin,
	1,
	'Prev.iniziale',
	0,
	#expense.idman
FROM #expense
JOIN fin
	ON fin.idfin = #expense.idfin
where ((fin.flag&1)=1)
GROUP BY #expense.codefin,#expense.idman,fin.flag

-- Previsione di ques'anno
UPDATE #expense SET initialprevision = initialprevision +
			ISNULL( (SELECT sum(isnull(finyear.prevision,0)
					+ isnull(finyear.prevision2,0)
					+ isnull(finyear.prevision3,0)
					+ isnull(finyear.prevision4,0)
					+ isnull(finyear.prevision5,0))
				FROM finyear
				JOIN fin 
					ON finyear.idfin = fin.idfin
				WHERE fin.codefin = #expense.codefin
					AND #expense.rowkind = 1
					AND finyear.ayear = #expense.ayear)
				,0)

UPDATE #expense SET initialprevision = initialprevision + 
			ISNULL(
			(SELECT SUM(FDV.amount)	
			FROM finvardetail FDV
			JOIN finvar FV
				ON FV.yvar = FDV.yvar
				AND FV.nvar = FDV.nvar
			JOIN fin F
				ON FDV.idfin = F.idfin
			WHERE FDV.yvar = #expense.ayear
				AND FV.flagprevision='S'
				AND FV.idfinvarstatus = 5
				AND FV.variationkind in ('2','3')
				AND F.codefin like #expense.codefin + '%'
				AND #expense.rowkind = 1
			),0)

UPDATE #expense SET operationdate = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),#expense.ayear), 105),
		finprintingorder = (select printingorder from fin 
				where   ((fin.flag&1)=1) AND fin.codefin = #expense.codefin
					AND fin.ayear = #expense.ayear),
		title = (select title from fin 
				where   ((fin.flag&1)=1) AND fin.codefin = #expense.codefin
					AND fin.ayear = #expense.ayear)
WHERE rowkind = 1

-- Cancella quelle di adeguamento a importo 0
DELETE FROM #expense WHERE rowkind = 2 AND isnull(finvar,0)=0

-- costruisce la gerarchia del movimento per creare l'ordinamento nel report
UPDATE #expense 
SET 
	hierarchy = convert(varchar(4),E1.ymov) + '/' + Replicate('0',6-len(convert(varchar(6),E1.nmov)))+ convert(varchar(6),E1.nmov),
	tothierarchy = 
	convert(varchar(4),E1.ymov) + '/' + Replicate('0',6-len(convert(varchar(6),E1.nmov)))+ convert(varchar(6),E1.nmov)
	+' '+ convert(varchar(4),isnull(E2.ymov,'')) + '/' + convert(varchar(6),isnull(E2.nmov,''))
	+' '+ convert(varchar(4),isnull(E3.ymov,'')) + '/' + convert(varchar(6),isnull(E3.nmov,''))
	+' '+ convert(varchar(4),isnull(E4.ymov,'')) + '/' + convert(varchar(6),isnull(E4.nmov,''))
FROM expense
JOIN expenselink EL1
	ON EL1.idchild = expense.idexp  AND EL1.nlevel = 1
LEFT OUTER JOIN expenselink EL2
	ON EL2.idchild = expense.idexp  AND EL2.nlevel = 2
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expense.idexp  AND EL3.nlevel = 3
LEFT OUTER JOIN expenselink EL4
	ON EL4.idchild = expense.idexp  AND EL4.nlevel = 4
LEFT OUTER JOIN expense E1
	ON E1.idexp = EL1.idparent
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
LEFT OUTER JOIN expense E4
	ON E4.idexp = EL4.idparent
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
WHERE  EL1.idchild = #expense.idmov

-- Qualora una fase abbia la stessa descrizione della fase precedente, viene rimossa la descrizione per non sprecare spazio nel report.
UPDATE #expense SET description = null
	FROM expense
	JOIN expenselink
		ON expense.idexp = expenselink.idparent --AND expenselink.nlevel = @nfinphase		
	WHERE #expense.idmov = expenselink.idchild AND expenselink.nlevel = #expense.nphase-1 --AND #expense.nphase = @nmaxphase
		AND expense.description = #expense.description

UPDATE #expense
	SET 	emessiondate = paymentview.adate,
		printeddate = 	paymentview.printdate,
		trasmitteddate = paymentview.transmissiondate,	
		transactiondate = (SELECT MIN(competencydate) from paymentperformed 
			WHERE paymentperformed.npay = #expense.ndoc 
			AND paymentperformed.ypay = #expense.ymov 
			AND paymentperformed.idexp= #expense.idmov),
		annulmentdate = paymentview.annulmentdate
	FROM paymentview
	WHERE #expense.ndoc = paymentview.npay 
		AND paymentview.ypay = #expense.ymov 

IF (@suppressifblank = 'N') 
BEGIN
-- Inserisco il bilancio non utilizzato
	INSERT INTO #expense 
		(
			idfin,
			rowkind,
			idman
			)
	SELECT 
		fin.idfin,
		1,
		idman	
	FROM fin 
	JOIN finlevel fl
		ON fin.nlevel = fl.nlevel 
		AND fin.ayear = fl.ayear
-- non posso fare il JOIN stretto perchè se faccio la stampa x capitolo, per i capitoli articolati 
-- il JOIN stretto mi prendeerebbe gli articoli
	LEFT OUTER JOIN finlast
		ON fin.idfin = finlast.idfin
	WHERE  	((fin.flag&1)<>0) 
		AND fin.ayear between isnull(@ayearstart,1900) and @ayearstop
		AND (fin.nlevel = @levelusable
			OR (fin.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = fin.idfin)
				AND (fl.flag&2)<>0
	   			)
			)
-- questa serve se facci la stampa x articolo di un capitolo e voglio vedere anche l'articolo inutilizzato
		AND (@codefin IS NULL OR fin.codefin like @codefin )
		AND ((finlast.idman = @idman) or (@idman is null ))
		and not exists (SELECT *
			FROM #expense
			WHERE fin.idfin = #expense.idfin 
				AND ISNULL(finlast.idman,0) = ISNULL(#expense.idman,0) )

END

-- se ho scelto di nascondere le voci di bilancio non utilizzate:
-- cancello le righe che hanno valori pari a zero 
-- per cui non esistono variazioni di previsioni (rowkind=2) o movimenti di entrata (rowkind >= 3 )  
IF (@suppressifblank = 'S') AND @nlevel>2	--> se la stampa è x un livello sottostante la categoria cancella le righe
BEGIN
	DELETE FROM #expense WHERE 
		ISNULL(initialprevision,0)=0 AND 
		ISNULL(finvar,0)=0 AND 
			ISNULL(finphase_amount,0)=0 AND 
		ISNULL(cassaphase_amount,0)=0 AND
		NOT EXISTS (select * from  #expense i
				where #expense.idfin=i.idfin AND 
					i.rowkind>1)
END


SELECT 
	#expense.ayear,
	idmov,
	@level as levelname,
	isnull(#expense.codefin,F.codefin) as codefin,
	isnull(#expense.finprintingorder,F.printingorder) as finprintingorder,
	isnull(#expense.title,F.title) as title,
	rowkind,
	nphase,
	operationdate,
	operationkind,ymov,nmov,nofficial,nsubmov,
	ndoc,description,doc,annotations,
	CASE
		WHEN nphase = @regphase  THEN REG.title
		ELSE NULL
	END as registry,	
	isnull(sum(initialprevision),0) as initialprevision,
	isnull(sum(finvar),0) as finvar	,
	isnull(sum(finphase_amount),0) as finphase_amount,
	isnull(sum(available),0) as available,
	isnull(sum(cassaphase_amount),0) as cassaphase_amount,
	emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
	@finname as finname,	
	@secondphase as secondphase,
	@thirdphase as thirdphase  ,					
	@phasecassa as phasecassa,
	hierarchy,
	tothierarchy,
	@second as nsecondphase,
	@finphase as nfinphase,
	@maxexpensephase as nmaxexpensephase,
	isnull(#expense.idman,0) as idman,
	manager.title AS manager,
	@previsionkind as previsionkind
FROM #expense
LEFT OUTER JOIN fin F
	ON F.idfin = #expense.idfin
LEFT OUTER JOIN registry REG
	ON REG.idreg = #expense.idreg  
LEFT OUTER JOIN manager
	ON manager.idman = #expense.idman	
GROUP BY #expense.ayear,hierarchy,tothierarchy,
	isnull(#expense.codefin,F.codefin),
	isnull(#expense.finprintingorder,F.printingorder),
	isnull(#expense.title,F.title),
	idmov,
	#expense.idman,manager.title,
	rowkind,nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,ndoc,description,doc,
	annotations,REG.title,finvar,emessiondate,printeddate			,
	trasmitteddate,transactiondate,annulmentdate
ORDER BY #expense.ayear,finprintingorder ASC,hierarchy ASC,tothierarchy ASC,
	rowkind ASC,
	ymov ASC,
	nmov ASC,
	nofficial ASC,
	nsubmov ASC


END 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

