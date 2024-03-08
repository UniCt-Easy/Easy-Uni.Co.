
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_responsabile_dm]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_responsabile_dm]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--    exec rpt_partitario_responsabile_dm null,{ts '2007-12-20 00:00:00'},2007,null,null,2007


CREATE    PROCEDURE rpt_partitario_responsabile_dm 
	@subimpegno	int,-- consente di scegliere il num del subimpegno
	@dateend datetime,
	@ayear int,
	@idman int,
	@idfin	int,
	@subimpegno_ayear int
	

AS
BEGIN
-- Bilancioa tre fasi
-- 1. Fase del bilancio - responsabile
-- 2. Fase della contabilizzazione
-- 3. Fase del pagamento 
	

declare @subi int
set @subi = null
IF (@subimpegno_ayear is not null) and (@subimpegno is not null) and (@subimpegno_ayear > 2002)and (@subimpegno>0)
BEGIN
	select @subi = idexp
	from expense where nmov = @subimpegno and ymov = @subimpegno_ayear and nphase = 1 
END

--print @subi := 7111
CREATE TABLE #manager
(
	idfin int,
	idexp int,
	finlevel varchar(50),
	codefin varchar(50),
	finprintingorder varchar(50),
	fin varchar(150),
	idman int,
	manager varchar(150),
	rowkind int,
	nphase tinyint,
	adate datetime,
	operationkind varchar(50),
	ymov int,
	nmov int,
	nsubmov int,
	npay int,
	description varchar(150),
	doc varchar(150),
	idreg int,
	expense_amount decimal(19,2),
	cassaphase_amount decimal(19,2),
	available decimal(19,2)
)
DECLARE @finlevel	varchar(50)
SELECT @finlevel = description 
FROM finlevel
WHERE nlevel = 3 AND ayear = @ayear

DECLARE @levelusable char
SELECT @levelusable = MIN(nlevel)
FROM finlevel
WHERE flag&2 <> 0 AND ayear = @ayear
		
-- Ipotesi fondamentale per vito de mola
DECLARE @manager_nphase tinyint
SELECT @manager_nphase = 1

DECLARE @managerphase	varchar(50)
SELECT @managerphase = description
FROM expensephase
WHERE nphase = @manager_nphase

DECLARE @cash_nphase tinyint
SELECT @cash_nphase = MAX(nphase)
FROM expensephase

-- imputazione di spesa della fase 1 = fase responsabile (imposta come tipo riga: 3)
INSERT INTO #manager
(
	idfin,
	idexp,
	finlevel,
	codefin,
	finprintingorder,
	fin,
	idman,
	rowkind,
	nphase,
	adate,
	operationkind,
	ymov,
	nmov,
	description,
	expense_amount
)
SELECT 
	fin.idfin,
	expense.idexp,
	@finlevel,
	fin.codefin,
	fin.printingorder,
	fin.title,
	expense.idman,
	3,
	expense.nphase,
	expense.adate,
	@managerphase,
	expense.ymov,
	expense.nmov,
	expense.description,
	expenseyear.amount
FROM expense
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
join expenselink
	ON expenselink.idchild = expense.idexp
JOIN finlink 
	ON finlink.idchild = expenseyear.idfin and finlink.nlevel = @levelusable
join fin 
	ON fin.idfin = finlink.idparent

WHERE expense.nphase = @manager_nphase
	AND expenseyear.ayear = @ayear
	AND expense.adate <= @dateend
	AND fin.ayear = @ayear
	AND  (( fin.flag & 1)=1)
	AND fin.nlevel = @levelusable
	AND ((expense.idman = @idman) OR (@idman is null and expense.idman is not null))	
        AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)

	and (@subi IS NULL OR expenselink.idparent = @subi)

-- inserisce le variaizoni nella fase del responsabile (imposta tipo riga :4 )
INSERT INTO #manager
(
	idfin,
	idexp,
	finlevel,
	codefin,
	finprintingorder,
	fin,
	idman,
	rowkind,
	nphase,
	adate,
	operationkind,
	ymov,
	nmov,
	nsubmov,
	description,
	expense_amount
)
SELECT 
	fin.idfin,
	expense.idexp,
	@finlevel,
	fin.codefin,
	fin.printingorder,
	fin.title,
	expense.idman,
	4,
	expense.nphase,
	expensevar.adate,
	'Var. ' + @managerphase,
	expense.ymov,
	expense.nmov,
	expensevar.nvar,
	expensevar.description,
	expensevar.amount
FROM expensevar
JOIN expense
	ON expense.idexp = expensevar.idexp
join expenselink
	ON expenselink.idchild = expense.idexp
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp
JOIN finlink 
	ON finlink.idchild = expenseyear.idfin and finlink.nlevel = @levelusable
join fin 
	ON fin.idfin = finlink.idparent
WHERE expensevar.yvar = @ayear
	AND isnull(expensevar.autokind,'') <>'22' 
	AND fin.ayear = @ayear
	AND  (( fin.flag & 1)=1)
	AND fin.nlevel = @levelusable
	AND expense.nphase = @manager_nphase
	AND expenseyear.ayear = @ayear
	AND expensevar.adate <= @dateend
	AND ((expense.idman = @idman) OR (@idman is null and expense.idman is not null))	
 	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
	and (@subi IS NULL OR expenselink.idparent = @subi)

-- procedo con le altre fasi di spesa tranne l'ultima
-- prende in questo db i movimenti (ordini) che nascono dai subimpegni presi precedentemente
DECLARE @cash					varchar(35)
SELECT @cash = description
FROM expensephase
WHERE nphase = @cash_nphase

DECLARE @i int

SELECT @i = CONVERT(int,@manager_nphase)
WHILE @i < (@cash_nphase -1)
BEGIN
	
	SELECT @i = @i + 1
	INSERT INTO #manager
	(
		idfin,
		idexp,
		finlevel,
		codefin,
		finprintingorder,
		fin,
		idman,
		rowkind,
		nphase,
		adate,
		operationkind,
		ymov,
		nmov,
		description,
		idreg,
		expense_amount
	)
	SELECT 
		fin.idfin,
		expense.idexp,
		@finlevel,
		fin.codefin,
		fin.printingorder,
		fin.title,
		expense.idman,
		5+(@i-@manager_nphase-1)*2,
		expense.nphase,
		expense.adate,
		(SELECT  description
				FROM expensephase
				WHERE nphase = @i),
		expense.ymov,
		expense.nmov,
		expense.description,
		expense.idreg,
		expenseyear.amount
	FROM expense
	JOIN expenseyear
		ON expenseyear.idexp = expense.idexp
	JOIN expenselink
		ON expenselink.idchild = expense.idexp and expenselink.nlevel = @manager_nphase
	JOIN finlink 
		ON finlink.idchild = expenseyear.idfin and finlink.nlevel = @levelusable
	join fin 
		ON fin.idfin = finlink.idparent
	WHERE expense.nphase = @i
		AND fin.ayear = @ayear
		AND expenseyear.ayear = @ayear
		AND  (( fin.flag & 1)=1)
		AND fin.nlevel = @levelusable
		AND expense.adate <= @dateend
		and expenselink.idparent IN (SELECT idexp FROM #manager WHERE rowkind = 3)	
	 	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
		and (@subi IS NULL OR expenselink.idparent = @subi)
	
	INSERT INTO #manager
	(
		idfin,
		idexp,
		finlevel,
		codefin,
		finprintingorder,
		fin,
		idman,
		rowkind,
		nphase,
		adate,
		operationkind,
		ymov,
		nmov,
		nsubmov,
		description,
		idreg,
		expense_amount
	)
	SELECT 
		fin.idfin,
		expense.idexp,
		@finlevel,
		fin.codefin,
		fin.printingorder,
		fin.title,
		expense.idman,
		6+(@i-@manager_nphase-1)*2,
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
		expensevar.amount
	FROM expensevar
	JOIN expense
		ON expense.idexp = expensevar.idexp
	JOIN expenseyear
		ON expenseyear.idexp = expensevar.idexp
	JOIN expenselink
		ON expenselink.idchild = expense.idexp and expenselink.nlevel = @manager_nphase
	JOIN finlink 
		ON finlink.idchild = expenseyear.idfin and finlink.nlevel = @levelusable
	join fin 
		ON fin.idfin = finlink.idparent
	WHERE expensevar.yvar = @ayear
		AND isnull(expensevar.autokind,'') <>'22' 
		AND expense.nphase = @i
		AND fin.ayear = @ayear
		AND  (( fin.flag & 1)=1)
		AND fin.nlevel = @levelusable
		AND expenseyear.ayear = @ayear
		AND expensevar.adate <= @dateend
		and expenselink.idparent IN (SELECT idexp FROM #manager WHERE rowkind = 3)
	 	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
	 	and (@subi IS NULL OR expenselink.idparent = @subi)

END

-- tutto ciò che riguarda la fase del pagamento
SELECT @i = 4
INSERT INTO #manager
(
	idfin,
	idexp,
	finlevel,
	codefin,
	finprintingorder,
	fin,
	idman,
	rowkind,
	nphase,
	adate,
	operationkind,
	ymov,
	nmov,
	npay,
	description,
	doc,
	idreg,
	expense_amount,
	cassaphase_amount
)
SELECT 
	fin.idfin,
	expense.idexp,
	@finlevel,
	fin.codefin,
	fin.printingorder,
	fin.title,
	expense.idman,
	15,
	expense.nphase,
	expense.adate,
	@cash,
	expense.ymov,
	expense.nmov,
	payment.npay,
	expense.description,
	CASE
		WHEN expense.doc IS NOT NULL AND 
			expense.docdate IS NULL THEN
			'Pag. ' + expense.doc
		WHEN expense.doc IS NOT NULL AND
			expense.docdate IS NOT NULL THEN
			'Pag. ' + expense.doc + 
			' del ' + CONVERT(varchar(10), expense.docdate, 105)
		ELSE
			(NULL)
	END,
	expense.idreg,
	-expenseyear.amount,			
	expenseyear.amount
FROM expense
JOIN expenselast
	ON expenselast.idexp = expense.idexp
JOIN payment
	ON expenselast.kpay = payment.kpay
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expenselink
	ON expenselink.idchild = expense.idexp and expenselink.nlevel = @manager_nphase
JOIN finlink 
	ON finlink.idchild = expenseyear.idfin and finlink.nlevel = @levelusable
join fin 
	ON fin.idfin = finlink.idparent
WHERE expense.adate <= @dateend
	and expenselink.idparent IN (SELECT idexp FROM #manager WHERE rowkind = 3)
	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
	AND fin.ayear = @ayear
	AND  (( fin.flag & 1)=1)
	AND expenseyear.ayear = @ayear
	--AND expenseyear.nphase = @cash_nphase
	AND fin.nlevel = @levelusable
	and (@subi IS NULL OR expenselink.idparent = @subi)

INSERT INTO #manager
	(
	idfin,
	idexp,
	finlevel,
	codefin,
	finprintingorder,
	fin,
	idman,
	rowkind,
	nphase,
	adate,
	operationkind,
	ymov,
	nmov,
	nsubmov,
	npay,
	description,
	doc,
	idreg,
	expense_amount,
	cassaphase_amount
	)
SELECT 
	fin.idfin,
	expense.idexp,
	@finlevel,
	fin.codefin,
	fin.printingorder,
	fin.title,
	expense.idman,
	20,
	expense.nphase,
	expensevar.adate,
	'Var.' + @cash,
	expense.ymov,
	expense.nmov,
	expensevar.nvar,
	payment.npay,
	expensevar.description,
	CASE
		WHEN expensevar.doc IS NOT NULL AND 
			expensevar.docdate IS NULL THEN
			'Pag. ' + expensevar.doc
		WHEN expensevar.doc IS NOT NULL AND
			expensevar.docdate IS NOT NULL THEN
			'Pag. ' + expensevar.doc + 
			' del ' + CONVERT(varchar(10), expensevar.docdate, 105)
		ELSE
	(NULL)
	END,
	expense.idreg,
	-expensevar.amount,
	expensevar.amount
FROM expensevar
JOIN expense
	ON expense.idexp = expensevar.idexp
JOIN expenselast
	ON expenselast.idexp = expense.idexp
JOIN payment
	ON expenselast.kpay = payment.kpay
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp
JOIN expenselink
	ON expenselink.idchild = expensevar.idexp and expenselink.nlevel = @manager_nphase
JOIN finlink 
	ON finlink.idchild = expenseyear.idfin and finlink.nlevel = @levelusable
join fin 
	ON fin.idfin = finlink.idparent
WHERE expensevar.yvar = @ayear
	AND expensevar.adate <= @dateend
	AND isnull(expensevar.autokind,'') <>'22' 
	AND fin.ayear = @ayear
	AND  (( fin.flag & 1)=1)
	AND expenseyear.ayear = @ayear
	--AND expense.nphase = @cash_nphase
	--AND expenseyear.nphase = @cash_nphase
	AND fin.nlevel = @levelusable
	and expenselink.idparent IN (SELECT idexp FROM #manager WHERE rowkind = 3)
	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
	and (@subi IS NULL OR expenselink.idparent = @subi)	

DELETE FROM #manager
	WHERE  expense_amount IS NULL AND cassaphase_amount IS NULL

UPDATE #manager
	SET available  = ISNULL(expense_amount,0) - ISNULL((SELECT SUM(ISNULL(expensetotal.curramount,0))
									FROM expensetotal
									join expenselink
										on expensetotal.idexp = expenselink.idchild 
									join expense
										on expense.idexp = expensetotal.idexp
									WHERE
										expenselink.idparent = #manager.idexp
										AND expensetotal.ayear = @ayear
										and expense.nphase = 2
									),0)
	WHERE #manager.nphase = '1' and rowkind =3
UPDATE #manager
	SET available = ISNULL(available,0) + ISNULL(
			(SELECT SUM(ISNULL(expense_amount,0)) 
			FROM #manager rpt2 
			WHERE rpt2.idexp = #manager.idexp and rpt2.rowkind = 4 ),0)
	WHERE #manager.nphase = '1' and rowkind =3

DECLARE @secondphase	varchar(50)
SELECT @secondphase = description
FROM expensephase
WHERE nphase = 2


SELECT 
	--idfin,
	#manager.idexp,
	#manager.finlevel,
	#manager.codefin,
	#manager.finprintingorder,
	#manager.fin,
	#manager.idman,
	manager.title as manager,
	#manager.rowkind,
	#manager.nphase,
	#manager.adate,
	#manager.operationkind,
	#manager.ymov,
	#manager.nmov,
	#manager.nsubmov,
	#manager.npay,
	#manager.description,
 	#manager.doc,
	--idreg,
	registry.title as registry, 
	#manager.expense_amount,
	#manager.cassaphase_amount,
	#manager.available,
	@cash as cash  ,
	@managerphase as managerphase,
	@secondphase as secondphase	
FROM #manager
JOIN manager
	ON #manager.idman = manager.idman
LEFT OUTER JOIN registry 
	ON #manager.idreg = registry.idreg
LEFT OUTER JOIN expenselink elk1
		ON elk1.idchild = #manager.idexp AND elk1.nlevel = 1
LEFT OUTER JOIN expenselink elk2
		ON elk2.idchild = #manager.idexp AND elk2.nlevel = 2
LEFT OUTER JOIN expenselink elk3
		ON elk3.idchild = #manager.idexp AND elk3.nlevel = 3

ORDER BY 
#manager.manager ASC,
elk1.idparent ASC,elk2.idparent ASC,elk3.idparent ASC,
#manager.rowkind ASC,
#manager.adate ASC,
#manager.ymov ASC,
#manager.nmov ASC,
#manager.nsubmov ASC

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec rpt_partitario_responsabile_dm 157,{ts '2007-12-20 00:00:00'},2007,21,'020901',2007
