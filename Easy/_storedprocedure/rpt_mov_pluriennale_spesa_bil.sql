
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_mov_pluriennale_spesa_bil]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_mov_pluriennale_spesa_bil]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE rpt_mov_pluriennale_spesa_bil
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

-- exec rpt_mov_pluriennale_spesa_bil 1999, 2008, 3,'010203',{ts '2008-05-22 00:00:00'},'S','S',NULL

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
		AND isnull(expensevar.autokind,'') <>'22' 
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
			AND isnull(expensevar.autokind,'') <>'22' 
			AND ((fin.flag&1)=1) -- Spesa
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
			AND isnull(expensevar.autokind,'') <>'22' 
			AND expensevar.adate <= @stop
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


IF (@suppressifblank = 'S') 
BEGIN
	DELETE FROM #expense WHERE 
		ISNULL(finphase_amount,0) = 0
		AND ISNULL(available,0) = 0
		AND ISNULL(cassaphase_amount,0) = 0
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
	annotations,REG.title,
	emessiondate,printeddate			,
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

