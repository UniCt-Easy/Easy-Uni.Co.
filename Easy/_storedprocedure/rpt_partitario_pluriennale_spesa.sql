
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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_pluriennale_spesa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_pluriennale_spesa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE rpt_partitario_pluriennale_spesa
	@ayear  int,
	@showupb char(1),
	@idupb	varchar(36),
	@showchildupb char(1),
	@nlevel tinyint,
	@codefin varchar(50),
	@stop datetime,
	@flagnofficial	char(1),
	@suppressifblank char(1),
	@idman int	
AS
BEGIN

-- EXEC rpt_partitario_pluriennale_spesa 2008, 'S','000100030002', 'S',4, null,{ts '2008-06-04 00:00:00'},'S','S',NULL

DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb

IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END	

DECLARE @levelusable tinyint
SELECT 	@levelusable = MIN(nlevel)
FROM 	finlevel
WHERE 	flag&2 <> 0 AND ayear = @ayear

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
WHERE config.ayear = @ayear

DECLARE @nfinphase tinyint
DECLARE @regphase tinyint 
SELECT  @regphase = expenseregphase,
		@nfinphase = expensefinphase FROM uniconfig

DECLARE @finname varchar(50)
SELECT  @finname = description FROM expensephase WHERE nphase = @nfinphase

DECLARE @nmaxphase tinyint 
SELECT  @nmaxphase = MAX(nphase) FROM expensephase
DECLARE @phasecassa varchar(50)
SELECT  @phasecassa = description FROM expensephase WHERE nphase = @nmaxphase



-- Seleziona la seconda/terza fase da inserire nella stampa 
DECLARE @secondphase varchar(50)
DECLARE @thirdphase varchar(50)
DECLARE @nsecondphase tinyint
DECLARE @nthirdphase tinyint
-- la seconda fase è quella successiva alla prima MA non deve essere quella del pagamento
SELECT  @secondphase = description, @nsecondphase = nphase FROM expensephase WHERE nphase = @nfinphase+1 and nphase < @nmaxphase
-- la terza fase è quella successiva alla seconda MA non deve essere quella del pagamento
SELECT  @thirdphase = description, @nthirdphase = nphase FROM expensephase  WHERE nphase =  @nsecondphase + 1 and nphase < @nmaxphase

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where codefin = @codefin and (flag&1)<>0 and ayear = @ayear ) ,@nlevel)

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
	WHERE   nlevel = @nlevel AND ayear = @ayear

CREATE TABLE #expense
(
	ayear  int,
	codefin varchar(50),
	finprintingorder  varchar(50),
	title  varchar(150),
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
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
	idman int,
	var_insite char(1)
)

DECLARE @cashvaliditykind int
SELECT  @cashvaliditykind = cashvaliditykind
FROM    config
WHERE   ayear = @ayear

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
		idupb,codeupb,upb,upbprintingorder,
		rowkind,
		operationdate,
		operationkind,
		ymov,
		nmov,
		nofficial,
		description,
		finvar,
		hierarchy,
		idman,
		var_insite
		)
	SELECT 	
		finvar.yvar,
		isnull(FL1.idparent, fin.idfin),
		upb.idupb,
		upb.codeupb,
		upb.title,
		upb.printingorder,
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
		upb.idman,
		'N'
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN upb 
		ON upb.idupb=finvardetail.idupb 
	left outer JOIN finlink
		ON finlink.idchild = finvardetail.idfin	
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = finvardetail.idfin	
		AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = isnull(FL1.idparent, finvardetail.idfin)
	WHERE (upb.idupb like @idupb ) AND isnull(upb.active,'N')='S'
		AND finvar.flagprevision = 'S'	
		AND finvar.idfinvarstatus = 5
		AND finvar.variationkind not in ('2','3','5')-- Ripartizione e Assestamento
		AND finvar.yvar <= @ayear
		AND finvar.adate <=  @stop
		AND ((fin.flag&1)<>0) 
		AND (@codefin IS NULL OR fin.codefin like @codefin )
		AND (upb.idman = @idman OR @idman is null )
		AND NOT 
		(-- esclude quelle del ribaltamento della previsione
		finvar.cu ='assistenza' 
		AND finvar.description in ('Trasferimento previsioni competenza disponibili','Trasferimento previsioni cassa disponibili')
		)
		AND NOT
		(-- esclude anche quelle della migrazione
		(finvar.cu = 'Software and More' AND finvar.description ='Storno da UPB 0001 a UPB ex F.d.R.')
		OR 
		(finvar.cu = 'SA' AND finvar.description ='Storno da UPB Dipartimento a UPB dei Fondi di Ricerca (migrazione automatica)')
		)
	GROUP BY finvar.yvar,isnull(FL1.idparent, fin.idfin),upb.idupb,upb.codeupb,upb.title,upb.printingorder,
		finvar.adate,finvar.nvar,finvar.nofficial,finvar.official,finvar.description,upb.idman

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
	idupb varchar(36),
	amount decimal(19,2),
	idman int					 
    )
INSERT INTO #embedded_increase
    (
	ayear,
	idfin,
	idupb,
	amount,
	idman 
    )
SELECT 
	finyear.ayear,
	finyear.idfin,
	finyear.idupb,
	isnull(finyear.prevision,0)
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
			AND FDV.idupb = finyear.idupb
			AND FV.variationkind in ('2','3'))
		,0),
	upb.idman
FROM finyear
JOIN upb 
	ON finyear.idupb = upb.idupb
JOIN fin
	ON fin.idfin = finyear.idfin 
JOIN finlevel fl
	ON fin.nlevel = fl.nlevel 
	AND fin.ayear = fl.ayear
WHERE 	(finyear.idupb like @idupb) AND isnull(upb.active,'N')='S'
	AND ((fin.flag&1)<>0) 
	AND finyear.ayear <= @ayear
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
				where birtyear.idupb = finyear.idupb)	
	AND (upb.idman = @idman OR @idman is null )
GROUP BY finyear.ayear,finyear.idupb,finyear.idfin,fin.codefin,finyear.prevision,upb.idman

-- Previsione anno prec. + Var. di previsione.
CREATE TABLE #previous
    (
	ayear int,
	idfin int,
	idupb varchar(36),
	prevision decimal(19,2),					 
	payment decimal(19,2),
	idman int
    )
INSERT INTO #previous
    (
	ayear,
	idfin,
	idupb,
	prevision,
	payment,
	idman
    )
	SELECT 
		finyear.ayear,
		isnull(FL1.idparent, finyear.idfin),--finyear.idfin,
		finyear.idupb,
		isnull(finyear.prevision,0)
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
				AND FV.idfinvarstatus= 5
				--AND FDV.idfin = finyear.idfin 
				AND F.codefin like fin.codefin + '%'
				AND FDV.idupb = finyear.idupb)
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
			LEFT OUTER JOIN finlink 
				ON finlink.idchild = expenseyear.idfin 
				AND finlink.nlevel = @nlevel
			LEFT OUTER JOIN finlink FL
				ON FL.idchild = expenseyear.idfin 
				AND FL.nlevel = @level_input
			WHERE expense.adate <= @stop
				--AND ((expensetotal.flag&1)=0)		--SARA
				AND  isnull(FL.idparent, expenseyear.idfin)=isnull(FL1.idparent, finyear.idfin)--finyear.idfin
				AND expense.nphase = @nfinphase 
				AND (expenseyear.idupb = finyear.idupb) 
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
				AND expenseyear.ayear = expensevar.yvar 
			LEFT OUTER JOIN finlink 
				ON finlink.idchild = expenseyear.idfin 
				AND finlink.nlevel = @nlevel
			LEFT OUTER JOIN finlink FL
				ON FL.idchild = expenseyear.idfin 
				AND FL.nlevel = @level_input
			WHERE expense.adate <= @stop
				AND  isnull(FL.idparent, expenseyear.idfin)=isnull(FL1.idparent, finyear.idfin)--finyear.idfin
				AND expense.nphase = @nfinphase 
				AND (expenseyear.idupb = finyear.idupb) 
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
				AND  isnull(FL.idparent, expenseyear.idfin)= isnull(FL1.idparent, finyear.idfin) --finyear.idfin
				AND (expenseyear.idupb = finyear.idupb) 
				AND ISNULL(expensevar.adate,{d '1900-01-01'})<= @stop
			),0)
	END,
	upb.idman
	FROM finyear
	JOIN upb 
		ON finyear.idupb = upb.idupb				-- QUA
	JOIN fin
		ON fin.idfin = finyear.idfin 
	JOIN finlevel fl
		ON fin.nlevel = fl.nlevel 
		AND fin.ayear = fl.ayear
	left outer JOIN finlink
		ON finlink.idchild = finyear.idfin	
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = finyear.idfin	
		AND FL1.nlevel = @nlevel
	WHERE 	(finyear.idupb like @idupb )AND isnull(upb.active,'N')='S'
		AND ((fin.flag&1)<>0) 
		AND finyear.ayear <= @ayear
		AND (fin.nlevel = @levelusable
			OR (fin.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = fin.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		AND (@codefin IS NULL OR fin.codefin like @codefin )
		AND (upb.idman = @idman OR @idman is null )
	GROUP BY finyear.ayear, finyear.idupb, fin.codefin, isnull(FL1.idparent, finyear.idfin), finyear.prevision, upb.idman


-- Inserisce nella Tab. principale le variazioni Insite nella prev
/*
 Var. Insite = Previsione dell'anno + Var. di Ripartizione/Assestamento - Disp. a Pagare Anno prec
 ove  Disp. a Pagare Anno prec = Previsione anno prec. + Var. di previsione - ( Pagamenti prec + Var.Pagamenti prec)
*/
	INSERT INTO #expense
		(
		ayear,
		idfin,
		idupb,codeupb,upb,upbprintingorder,
		rowkind,
		operationdate,
		operationkind,
		ymov,
		description,
		finvar,
		hierarchy,
		I.idman, -- dovrebbe essere uguale a P.idman 
		var_insite
		)
-- I LEFT OUTER JOIN sono stati introdotti perchè può capitare che un capitolo del 2002 confluisca in un capitolo del 2003 nuovo, ossia creato nel 2003
	SELECT 
		I.ayear,
		isnull(FL1.idparent, I.idfin),--I.idfin,
		I.idupb,codeupb,upb.title,upb.printingorder,
		2,
		CONVERT(datetime, '01-01-' + CONVERT(varchar(4),I.ayear), 105),
		'Var.prev.',--> INSITE NELLA PREVISIONE
		I.ayear,
		'Adeguamento previsione',
		ISNULL(I.amount,0) - ( ISNULL(P.prevision,0) - ISNULL(P.payment,0) )
		+ ( ISNULL(FY_I.prevision2,0) + ISNULL(FY_I.prevision3,0) + ISNULL(FY_I.prevision4,0) + ISNULL(FY_I.prevision5,0) )
		- ( ISNULL(FY_P.prevision2,0) + ISNULL(FY_P.prevision3,0) + ISNULL(FY_P.prevision4,0) + ISNULL(FY_P.prevision5,0) ),
		I.ayear,
		I.idman,
		'S'
	FROM #embedded_increase I
	JOIN finyear FY_I
		ON FY_I.idfin = I.idfin
		AND FY_I.idupb = I.idupb
	LEFT OUTER JOIN finlookup F
		ON I.idfin = F.newidfin
	LEFT OUTER JOIN #previous P
		ON  P.idupb = I.idupb
		AND P.idfin = F.oldidfin
	JOIN finyear FY_P
		ON FY_P.idfin = P.idfin
		AND FY_P.idupb = P.idupb
	JOIN upb
		ON upb.idupb = I.idupb
	left outer JOIN finlink
		ON finlink.idchild = I.idfin	
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = I.idfin	
		AND FL1.nlevel = @nlevel
	WHERE ISNULL(P.ayear,I.ayear - 1) = I.ayear - 1 -- Altri filtri sui parametri @... non servono perchè sono stati usati nelle tab. Temporanee
	AND (
		(SELECT codefin FROM fin WHERE idfin = F.oldidfin)=(SELECT codefin FROM fin WHERE idfin = F.newidfin)
		OR 
		(SELECT codefin FROM fin WHERE idfin = F.oldidfin) is null
		)
/*
 le var di adeguamneto deve prenderle tutte, perchè queste servono anche a mettere le coppie nella tab. temporanea, se prendo oslo quelle 
con importo diverso da 0, nel caso in cui ho un upb nato nel 2007, con prev.10 (dovuta ad una var) al 31/12 il disp. è 10, nel 2008 la prev. è 10
allora la var. insita sarà 0 MA la coppia deve metterla in #expense perchè servirà dopo al JOIN
*/
			
-- Movimenti di Spesa / fase bilancio
INSERT INTO #expense(
		ayear,
		idfin, codefin,
		idmov,
		idupb,codeupb,upb,upbprintingorder,
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
		SELECT		-- IMPEGNI
		expenseyear.ayear,
		isnull(FL1.idparent, fin.idfin), fin.codefin,
		expense.idexp,
		upb.idupb,
		upb.codeupb,
		upb.title,upb.printingorder,
		3,
		expense.nphase,
		expense.adate,
		@finname,
		expense.ymov,
		expense.nmov,
		expense.description,
		expense.idreg,
		expenseyear.amount,
		expensetotal.available,
		upb.idman
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN upb 
			ON upb.idupb=expenseyear.idupb
		left outer JOIN finlink FL1
			ON FL1.idchild = expenseyear.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)
		left outer JOIN finlink
			ON finlink.idchild = fin.idfin	
			AND finlink.nlevel = @level_input
		WHERE expense.nphase = @nfinphase
			AND expense.adate <= @stop
			AND expenseyear.ayear <= @ayear
			--AND (expensetotal.flag&1)= 0 -- Solo quelli di competenza dell'anno SARA
			AND ((fin.flag&1)<>0) 
			AND (@codefin IS NULL OR fin.codefin like @codefin )
			AND (upb.idupb like @idupb )AND isnull(upb.active,'N')='S'
			AND ((upb.idman = @idman) or (@idman is null ))
			--and expense.ymov = 2014	 and expense.nmov =23565
-- Nella query precedente li ha presi tutti, ora vuole cancellare gli impegni, e lasciare solo il primo per voce di bilancio
--select * from #expense where idmov = 632529
delete from #expense where rowkind = 3
	and exists (select * from #expense e2 where e2.idmov = #expense.idmov and e2.idupb = #expense.idupb and e2.codefin = #expense.codefin and e2.ayear < #expense.ayear )


-- Variazione movimenti di spesa / fase bilancio
	INSERT INTO #expense
		(
		ayear,
		idfin,
		idmov,
		idupb,codeupb,upb,upbprintingorder,	
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
		upb.idupb,upb.codeupb,upb.title,upb.printingorder,
		4,
		expense.nphase,
		expensevar.adate,
		'Var.' + @finname,
		expense.ymov,
		expense.nmov,
		expensevar.nvar,
		expensevar.description,
		expense.idreg,
		expensevar.amount,
		upb.idman
	FROM expensevar
	JOIN expense
		ON expense.idexp = expensevar.idexp
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
	JOIN expensetotal
		ON expensetotal.idexp = expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	JOIN upb 
		ON upb.idupb=expenseyear.idupb
	left outer JOIN finlink
		ON finlink.idchild = expenseyear.idfin	
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = expenseyear.idfin	
		AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)
	WHERE expensevar.yvar <= @ayear
		AND expensevar.adate <= @stop
		AND (upb.idupb like @idupb )
		AND isnull(upb.active,'N')='S'
		AND expense.nphase = @nfinphase
		AND expenseyear.ayear <= @ayear
		AND (expensetotal.flag&1)= 0-- solo la competenza SARA
		AND ((fin.flag&1)<>0)
		AND (@codefin IS NULL OR fin.codefin like @codefin )
		AND ((upb.idman = @idman) or (@idman is null ))

---	CILCLO WHILE
--------------------------
DECLARE @i int
SELECT @i = CONVERT(int,@nfinphase)
WHILE @i < (@nmaxphase -1)
BEGIN
	SELECT @i = @i + 1
		INSERT INTO #expense
			(
			ayear,
			idfin,
			idmov,
			codeupb,
			idupb,
			upb,
			upbprintingorder,
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
			upb.codeupb,
			upb.idupb,
			upb.title,
			upb.printingorder,
			5+(@i-@nfinphase-1)*2,
			expense.nphase,
			expense.adate,
			(SELECT  description
				FROM expensephase
				WHERE nphase = @i),
			expense.ymov,
			expense.nmov,
			expense.description,
			expense.idreg,
			expenseyear.amount,
			upb.idman
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN upb 
			ON upb.idupb=expenseyear.idupb
		left outer JOIN finlink
			ON finlink.idchild = expenseyear.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = expenseyear.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)
		WHERE  (upb.idupb like @idupb )	
			AND isnull(upb.active,'N')='S'
			AND expenseyear.ayear <= @ayear
			AND (expensetotal.flag&1) = 0 --solo la competenza ci interessa
			AND expense.nphase = @i
			AND ((fin.flag&1)<>0)
			AND (@codefin IS NULL OR fin.codefin like @codefin )
			AND (expense.adate <= @stop)
			AND ((upb.idman = @idman) or (@idman is null ))

		INSERT INTO #expense
			(
			ayear,	
			idfin,
			idmov,
			codeupb	,
			idupb,
			upb,
			upbprintingorder,
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
			upb.codeupb,
			upb.idupb,
			upb.title,
			upb.printingorder,
			6+(@i-@nfinphase-1)*2,
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
			expensevar.amount,
			upb.idman
		FROM expensevar
		JOIN expense
			ON expense.idexp = expensevar.idexp
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN upb
			ON upb.idupb = expenseyear.idupb  
		left outer JOIN finlink
			ON finlink.idchild = expenseyear.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = expenseyear.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, expenseyear.idfin)	
		WHERE (upb.idupb like @idupb )
			AND isnull(upb.active,'N')='S'
			AND expense.nphase = @i
			AND isnull(expensevar.autokind,'') <>'22' 
			AND ((fin.flag&1)=1) -- Spesa
			AND (@codefin IS NULL OR fin.codefin like @codefin )
			AND expensevar.yvar <= @ayear
			AND expenseyear.ayear <= @ayear
			AND (expensetotal.flag&1) = 0
			AND expensevar.adate <= @stop
			AND ((upb.idman = @idman) or (@idman is null ))
  
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
		idupb,
		codeupb,
		upb,
		upbprintingorder,
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
	upb.idupb,upb.codeupb,upb.title,
	upb.printingorder,
	15,
	@nmaxphase,
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
	HPV.amount,
	upb.idman
FROM historypaymentview HPV
JOIN upb 
	ON upb.idupb = HPV.idupb		
left outer JOIN finlink
	ON finlink.idchild = HPV.idfin	
	AND finlink.nlevel = @level_input
left outer JOIN finlink FL1
	ON FL1.idchild = HPV.idfin	
	AND FL1.nlevel = @nlevel
JOIN fin
	ON fin.idfin = isnull(FL1.idparent, HPV.idfin)--FL1.idparent
WHERE HPV.competencydate <= @stop
	AND (upb.idupb like @idupb  )
	AND isnull(upb.active,'N')='S'
	AND HPV.ymov <= @ayear
	AND ((fin.flag&1)=1)
	AND (@codefin IS NULL OR fin.codefin like @codefin )
	AND ((upb.idman = @idman) or (@idman is null ))

-- Variazione ai Movimenti di spesa / fase cassa
IF (@cashvaliditykind <> 4)
BEGIN
	INSERT INTO #expense
		(
		ayear,
		idfin,
		idmov,
		idupb, codeupb,upb,upbprintingorder,
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
		upb.idupb, upb.codeupb,upb.title,upb.printingorder,
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
		expensevar.amount,
		upb.idman
		FROM expensevar
		JOIN historypaymentview HPV
			ON HPV.idexp = expensevar.idexp
		JOIN expense
			ON expense.idexp = expensevar.idexp
		JOIN upb
			ON upb.idupb = HPV.idupb
		left outer JOIN finlink
			ON finlink.idchild = HPV.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = HPV.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
			ON fin.idfin = isnull(FL1.idparent, HPV.idfin)
		WHERE expensevar.yvar <= @ayear
			AND expensevar.adate <= @stop
			AND (upb.idupb like @idupb )
			AND isnull(upb.active,'N')='S'
			AND isnull(expensevar.autokind,'') <>'22' 
			AND HPV.ymov <= @ayear
			AND ((fin.flag&1)=1) -- Spesa
			AND (@codefin IS NULL OR fin.codefin like @codefin )
			AND HPV.competencydate <= @stop
			AND ((upb.idman = @idman) or (@idman is null ))
	
END

/*----------------------------------------------------------------------------------------------------------------------------------
Ora si sta calcolando la PREVISIONE INIZIALE, e la mette nel primo anno di esistenza del fondo:
Prev. pluriennale iniziale 2008 = Prev.annuale del 2008 + Prev. Anni futuri + Impegni Anni precedenti (o Pagamenti anni precedenti)
-----------------------------------------------------------------------------------------------------------------------------------*/

UPDATE #expense SET codefin =(select codefin	FROM fin 
				WHERE idfin = #expense.idfin )
			where #expense.codefin IS NULL

INSERT INTO #expense
(
	ayear,
	codefin,
	finprintingorder,
	title,
	codeupb,
	idupb,
	upb,
	upbprintingorder,
	rowkind,
	operationkind,
	initialprevision,
	idman
)
SELECT 	(select min(birtyear.ayear) from finyear birtyear
		where birtyear.idupb = #expense.idupb),--2005
	fin.codefin,
	fin.printingorder,
	fin.title,
	upb.codeupb,
	#expense.idupb,
	upb.title,
	upb.printingorder,
	1,
	'Prev.iniziale',
	0,
	upb.idman
FROM #expense
JOIN fin
	ON fin.idfin = #expense.idfin
JOIN upb
	ON upb.idupb = #expense.idupb
GROUP BY fin.codefin,#expense.idupb,fin.printingorder,fin.title,upb.codeupb,upb.title,
	upb.printingorder,upb.idman
/*
 Ha inserito le coppie che non hanno movimentazione, ossia che finora non ha inserito nella #expensevar, 
 ma che contribuiscono alla previisone iniziale qualora esiste una var nell'ultimo anno.
*/

INSERT INTO #expense
(
	ayear,
	codefin,
	finprintingorder,
	title,
	codeupb,
	idupb,
	upb,
	upbprintingorder,
	rowkind,
	operationkind,
	initialprevision,
	idman
)
SELECT 	(select min(birtyear.ayear) from finyear birtyear
		where birtyear.idupb = FDV.idupb),--2005
	fin.codefin,
	fin.printingorder,
	fin.title,
	upb.codeupb,
	FDV.idupb,
	upb.title,
	upb.printingorder,
	1,
	'Prev.iniziale',
	0,
	upb.idman
FROM finvardetail FDV
JOIN finvar FV
	ON FV.yvar = FDV.yvar
	AND FV.nvar = FDV.nvar
left outer JOIN finlink
	ON finlink.idchild = FDV.idfin	
	AND finlink.nlevel = @level_input
left outer JOIN finlink FL1
	ON FL1.idchild = FDV.idfin	
	AND FL1.nlevel = @nlevel
JOIN fin
	ON fin.idfin = isnull(FL1.idparent, FDV.idfin)
JOIN upb
	ON upb.idupb = FDV.idupb
WHERE  FDV.yvar =  @ayear
	AND FV.flagprevision='S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND (@codefin IS NULL OR fin.codefin like @codefin )
	AND ((fin.flag&1)=1) 
	AND (upb.idupb like @idupb )
	AND (upb.idman = @idman OR @idman is null )
	AND not exists (select * from #expense E2
			where E2.codefin =  fin.codefin
			AND E2.idupb = FDV.idupb	
			)
GROUP BY fin.codefin,FDV.idupb,fin.printingorder,fin.title,upb.codeupb,upb.title,
	upb.printingorder,upb.idman,fin.flag


-- Previsione di quest'anno
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
					AND finyear.idupb = #expense.idupb
					AND #expense.rowkind = 1
					AND finyear.ayear = @ayear)
				,0)

-- Aggiunge gli impegni anni Prec.
UPDATE #expense SET initialprevision = initialprevision + 
			ISNULL(
			(SELECT SUM(payment) 
			FROM #previous
			JOIN fin 
				ON #previous.idfin = fin.idfin
			WHERE  fin.codefin like #expense.codefin + '%'
				AND #previous.idupb = #expense.idupb
				AND #expense.rowkind = 1 -- solo sulla riga della previsione
				AND #previous.ayear < @ayear)
			,0)
-- Aggiunge le variazioni degli impegni precedenti FATTE QUEST'ANNO, alla stregua della show_pliriennale
		+ISNULL(
			(SELECT SUM(ISNULL(expensevar.amount, 0))
			FROM expense
			JOIN expenseyear
				ON expenseyear.idexp = expense.idexp 
			JOIN expensevar
				ON expense.idexp = expensevar.idexp
				AND expenseyear.ayear = expensevar.yvar
			JOIN fin 
				ON expenseyear.idfin = fin.idfin
			WHERE expense.adate <= @stop
				AND fin.codefin like #expense.codefin + '%'
				AND expense.nphase = @nfinphase 
				AND expense.ymov < @ayear
				AND expensevar.yvar = @ayear
				AND expenseyear.idupb = #expense.idupb 
				AND ISNULL(expensevar.adate,{d '1900-01-01'})<= @stop
				AND #expense.rowkind = 1 -- solo sulla riga della previsione
				)
			,0)	,
		operationdate = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),#expense.ayear), 105)
				WHERE rowkind = 1

-- Ora sta sottraendo quelle insite e quelle normali, che sono state precedentemente incluse nella tab.	SARA
UPDATE #expense SET initialprevision = initialprevision - 
			ISNULL(
			(SELECT SUM(E2.finvar) 
			FROM #expense E2
			WHERE E2.codefin = #expense.codefin
				AND E2.idupb = #expense.idupb
				AND #expense.rowkind = 1 -- solo sulla riga della previsione
				and isnull(E2.var_insite,'N')='S'-- non mi risulta che siano state incluse. Quindi facciamo sottrarre solo quelle insite e non anche quelle normali
				) 
			,0)

-- Ora sta aggiungendo tutte le var di quest'anno
UPDATE #expense SET initialprevision = initialprevision + 
			ISNULL(
			(SELECT SUM(FDV.amount)	
			FROM finvardetail FDV
			JOIN finvar FV
				ON FV.yvar = FDV.yvar
				AND FV.nvar = FDV.nvar
			JOIN fin F
				ON FDV.idfin = F.idfin
			WHERE FDV.yvar =  @ayear
				AND FV.flagprevision='S'
				AND FV.idfinvarstatus = 5
				AND FV.variationkind <> 5
				AND F.codefin like #expense.codefin + '%'
				AND FDV.idupb = #expense.idupb
				AND #expense.rowkind = 1
			),0)

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
		AND #expense.ymov  = paymentview.ypay  


IF (@suppressifblank = 'N') 
BEGIN
--se ho scelto di vedere l'upb inserisco le coppie upb/bilancio altrimenti inserisco solo il bilanico non utilizzato
	IF ( (@showupb <>'S') and (@idupboriginal = '%'))
	Begin
		INSERT INTO #expense 
			(
				idfin,
				rowkind
				)
		SELECT 
			fin.idfin,
			1
		FROM fin 
		JOIN finlevel fl
			ON fin.nlevel = fl.nlevel 
			AND fin.ayear = fl.ayear
		WHERE  	((fin.flag&1)<>0) 
			AND fin.ayear <= @ayear
			AND (fin.nlevel = @levelusable
				OR (fin.nlevel < @levelusable
					AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = fin.idfin)
					AND (fl.flag&2)<>0
		   			)
				)
-- questa serve se facci la stampa x articolo di un capitolo e voligo vedere anche l'articolo inutilizzato
			AND (@codefin IS NULL OR fin.codefin like @codefin )
			and not exists (SELECT *
				FROM #expense
				WHERE fin.idfin = #expense.idfin )
		End
	Else
		Begin
		INSERT INTO #expense 
			(
				idfin,
				idupb,
				codeupb,
				upb,
				upbprintingorder,
				rowkind,
				idman
				)
		SELECT 
			fin.idfin,
			upb.idupb,
			codeupb,
			upb.title,
			upb.printingorder,
			1,
			upb.idman
		FROM fin CROSS JOIN upb 
		JOIN finlevel fl
			ON fin.nlevel = fl.nlevel 
			AND fin.ayear = fl.ayear
		WHERE 	(upb.idupb like @idupb )
			AND (upb.idman = @idman OR @idman is null )
			AND isnull(upb.active,'N')='S'
			AND ((fin.flag&1)<>0) 
			AND fin.ayear <= @ayear
			AND (fin.nlevel = @levelusable
				OR (fin.nlevel < @levelusable
					AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = fin.idfin)
					AND (fl.flag&2)<>0
				   )
				)
			AND (@codefin IS NULL OR fin.codefin like @codefin )
			AND NOT EXISTS (SELECT *
				FROM #expense
				WHERE upb.idupb = #expense.idupb 
				AND fin.idfin = #expense.idfin )
		End

END
-- Cancella quelle di adeguamento a importo 0
DELETE FROM #expense WHERE rowkind = 2 AND isnull(finvar,0)=0

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
	UPDATE #expense 
	SET  
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
				where #expense.idupb=i.idupb AND 
				      #expense.idfin=i.idfin AND 
					i.rowkind>1)
END
 	

IF (@showupb <>'S') 
BEGIN
	SELECT 
		#expense.ayear,
		idmov,
		@level as levelname,
		isnull(F.codefin,#expense.codefin) as codefin,
		isnull(F.printingorder,#expense.finprintingorder) as finprintingorder,
		isnull(F.title,#expense.title) as title,
		codeupb,idupb,upb,upbprintingorder,rowkind,
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
		@nsecondphase as nsecondphase,
		@nfinphase as nfinphase,
		@nmaxphase as nmaxexpensephase,
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
	GROUP BY #expense.ayear,codeupb,idupb,upb,upbprintingorder,hierarchy,tothierarchy,
		isnull(F.codefin,#expense.codefin),
		isnull(F.printingorder,#expense.finprintingorder),
		isnull(F.title,#expense.title),
		idmov,
		#expense.idman,manager.title,
		rowkind,nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,ndoc,description,doc,
		annotations,REG.title,finvar,emessiondate,printeddate			,
		trasmitteddate,transactiondate,annulmentdate
	ORDER BY upbprintingorder ASC, #expense.ayear,finprintingorder ASC,hierarchy ASC,tothierarchy ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nofficial ASC,
		nsubmov ASC
END
ELSE
BEGIN
	SELECT #expense.ayear,
		--#expense.idfin,
		idmov,
		@level as levelname,
		isnull(F.codefin,#expense.codefin) as codefin,
		isnull(F.printingorder,#expense.finprintingorder) as finprintingorder,
		isnull(F.title,#expense.title) as title,
		codeupb,idupb,upb,upbprintingorder,rowkind,
		nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,
		ndoc,description,doc,annotations,
		CASE
			WHEN nphase = @regphase  THEN REG.title
			ELSE NULL
		END as registry,	
		isnull(initialprevision,0) as initialprevision,
		isnull(finvar,0) as finvar,
		isnull(finphase_amount,0) as finphase_amount,
		isnull(available,0) as available,
		isnull(cassaphase_amount,0) as cassaphase_amount,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@finname as finname,	
		@secondphase as secondphase,
		@thirdphase as thirdphase  ,					
		@phasecassa as phasecassa,
		hierarchy,tothierarchy,
		@nsecondphase as nsecondphase,
		@nfinphase as nfinphase,
		@nmaxphase as nmaxexpensephase,
		isnull(#expense.idman,0) as idman,
		manager.title as manager,
		@previsionkind as previsionkind
 	FROM #expense	
	LEFT OUTER JOIN fin F
		ON F.idfin = #expense.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #expense.idreg	
	LEFT OUTER JOIN manager
		ON manager.idman = #expense.idman	
	ORDER BY upbprintingorder ASC,#expense.ayear, F.printingorder ASC,hierarchy ASC,tothierarchy ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nofficial ASC,
		nsubmov ASC
END
END 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--EXEC rpt_partitario_pluriennale_spesa 2015, 'N','00010005001200060018', 'S',3, '513008',{d '2015-04-11'},'N','S',NULL
--EXEC rpt_partitario_pluriennale_spesa 2015, 'N','00010005001200060018', 'S',3, '513008',{d '2015-04-11'},'N','S',NULL
--EXEC rpt_partitario_pluriennale_spesa 2016, 'N','00010005001200060018', 'S',3, '10102',{d '2016-03-29'},'N','S',NULL
--	EXEC rpt_partitario_pluriennale_spesa 2016, 'N','00010005001200060018', 'S',3, '1010215',{d '2016-03-29'},'N','S',NULL
--EXEC rpt_partitario_pluriennale_spesa 2016, 'N','00010005001200060018', 'S',3, '10106',{d '2016-03-29'},'N','S',NULL
--EXEC rpt_partitario_pluriennale_spesa 2016, 'N','00010005001200060018', 'S',3, '10101',{d '2016-03-29'},'N','S',NULL
--EXEC rpt_partitario_pluriennale_spesa 2016, 'N','00010005001200060018', 'S',3, '%',{d '2016-03-29'},'N','S',NULL
--EXEC rpt_partitario_pluriennale_spesa 2016, 'N','00010005001200060018', 'S',3, '718004',{d '2016-03-29'},'N','S',NULL
---EXEC rpt_partitario_pluriennale_spesa 2016, 'N','00010005001200060018', 'S',3, '10101',{d '2016-03-31'},'N','S',NULL

