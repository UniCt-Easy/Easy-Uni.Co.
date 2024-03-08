
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_residual_miur]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_residual_miur]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [exp_residual_miur] 
(
	@ayear int,
	@finpart char(1)
)
AS BEGIN

-- Per natura
DECLARE @iMIUR INT
DECLARE @eMIUR INT
DECLARE @MIUR INT

DECLARE @iSIOPE INT
DECLARE @eSIOPE INT

SELECT @iMIUR = idsorkind from sortingkind where codesorkind = '07E_MIUR'
SELECT @eMIUR = idsorkind from sortingkind where codesorkind = '07U_MIUR'

DECLARE @fase_MIUR varchar(50)

DECLARE @codesorkind varchar(20)
DECLARE @sortingkind varchar(50)


-- Creazione della Tabella che visualizzerà il riepilogo dei dati su foglio Excel

CREATE TABLE #mov_res 
			(idmov varchar(40), 
			 ymov int,
			 nmov int,
			 amount decimal(19,2), 
			 curramount decimal(19,2), 
			 varamount decimal(19,2))
CREATE TABLE #var_res (idmov varchar(40), amount decimal(19,2))

CREATE TABLE #class
(
	idmov int,
	ymov int,
	nmov int,		
	idsor int,
	amount decimal(19,2),
	sortcode varchar(30),
	rowkind char(1) -- Campo che vale 'P' = Movimento Principale, 'V' = Variazioni
)

DECLARE @phaseMIUR tinyint -- Fase di entrata/spesa associata alla classificazione MIUR

-- Codice per i movimenti di entrata 
IF @finpart = 'E'
BEGIN
	SELECT  @phaseMIUR = nphaseincome FROM sortingkind WHERE idsorkind  = @iMIUR
	SELECT  @fase_MIUR = description FROM incomephase WHERE nphase = @phaseMIUR
	SET		@MIUR = @iMIUR
	
	INSERT INTO #mov_res (idmov, ymov, nmov, amount, curramount, varamount)
	SELECT incomeyear.idinc, income.ymov, income.nmov, incomeyear.amount, incometotal.curramount, 
	ISNULL(
		(SELECT SUM(amount)
		FROM incomevar
		WHERE incomevar.idinc = incomeyear.idinc
		AND incomevar.yvar = incomeyear.ayear)
	,0)
	FROM incomeyear
	join income on income.idinc = incomeyear.idinc
	JOIN incometotal
		ON incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear
	WHERE incomeyear.ayear = @ayear
		AND income.nphase = @phaseMIUR
		AND ((incometotal.flag&1)=1)   ---Residuo
	AND ISNULL(
		(SELECT SUM(amount)
		FROM incomevar
		WHERE incomevar.idinc = incomeyear.idinc
		AND incomevar.yvar = incomeyear.ayear)
	,0) <>0

	INSERT INTO #var_res (idmov, amount)
	SELECT incomeyear.idinc, SUM(incomevar.amount)
	FROM incomeyear
	join income on incomeyear.idinc = income.idinc
	join incometotal on incomeyear.idinc = incometotal.idinc and incomeyear.ayear = incometotal.ayear
	JOIN incomevar
		ON incomevar.idinc = incomeyear.idinc
		AND incomevar.yvar = incomeyear.ayear
	WHERE incomeyear.ayear = @ayear
		AND income.nphase = @phaseMIUR
		AND ((incometotal.flag&1)=1) ---Residuo
	GROUP BY incomeyear.idinc
		
	-- Caso 2. Movimento di Entrata con variazioni
	-- Inserimento di dettagli SIOPE sul mov. principale riferito alle trattenute (calcolo per rapporto)
	INSERT INTO #class (idmov, ymov, nmov, idsor, sortcode)
	SELECT #mov_res.idmov, #mov_res.ymov, #mov_res.nmov, incomesorted.idsor, sorting.sortcode
	FROM #var_res
	JOIN #mov_res
		ON #var_res.idmov = #mov_res.idmov
	JOIN incomesorted
		ON #mov_res.idmov = incomesorted.idinc
	JOIN sorting
		ON sorting.idsor = incomesorted.idsor
	WHERE sorting.idsorkind = @iMIUR
		AND #mov_res.varamount <> 0
		AND incomesorted.ayear = @ayear
		AND (SELECT COUNT(DISTINCT INS.idsor) 
			   FROM incomesorted INS 
			   JOIN sorting S
				 ON S.idsor = INS.idsor
			  WHERE INS.ayear = incomesorted.ayear 
				AND INS.idinc = incomesorted.idinc
				AND S.idsorkind = @iMIUR) > 1
	GROUP BY #mov_res.idmov, #mov_res.ymov, #mov_res.nmov, 
			 sorting.sortcode, #var_res.amount, #mov_res.curramount, incomesorted.idsor
		
END	-- Fine codice per i movimenti di entrata
ELSE
-- Codice per i movimenti di spesa
BEGIN	
	SELECT  @phaseMIUR = nphaseexpense FROM sortingkind WHERE idsorkind  = @eMIUR
	SELECT  @fase_MIUR = description FROM expensephase WHERE nphase = @phaseMIUR
	SET		@MIUR = @eMIUR 
	
	print @phaseMIUR 
	print @fase_MIUR 
	print @MIUR
	
	INSERT INTO #mov_res (idmov, ymov, nmov, amount, curramount, varamount)
	SELECT expenseyear.idexp,expense.ymov, expense.nmov, expenseyear.amount, expensetotal.curramount, 
	ISNULL(
		(SELECT SUM(amount)
		FROM expensevar
		WHERE expensevar.idexp = expenseyear.idexp
		AND expensevar.yvar = expenseyear.ayear)
	,0)
	FROM expenseyear
	join expense on expense.idexp = expenseyear.idexp
	JOIN expensetotal
		ON expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear
	WHERE expenseyear.ayear = @ayear
		AND expense.nphase = @phaseMIUR
		AND ((expensetotal.flag&1)=1)   ---Residuo
	AND ISNULL(
		(SELECT SUM(amount)
		FROM expensevar
		WHERE expensevar.idexp = expenseyear.idexp
		AND expensevar.yvar = expenseyear.ayear)
	,0) <> 0

	INSERT INTO #var_res (idmov, amount)
	SELECT expensevar.idexp, SUM(expensevar.amount)
	FROM expenseyear
	join expense on expense.idexp = expenseyear.idexp
	join expensetotal on expensetotal.idexp=expenseyear.idexp and expensetotal.ayear=expenseyear.ayear
	JOIN expensevar
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = expensevar.yvar
	WHERE expenseyear.ayear = @ayear
		AND ((expensetotal.flag&1)=1)  ---Residuo
		AND expense.nphase = @phaseMIUR
	GROUP BY expensevar.idexp

	INSERT INTO #class (idmov, ymov,nmov,idsor, sortcode)
	SELECT #mov_res.idmov, #mov_res.ymov, #mov_res.nmov, expensesorted.idsor, sorting.sortcode
	FROM #mov_res
	JOIN expensesorted
		ON #mov_res.idmov = expensesorted.idexp
	JOIN sorting
		ON sorting.idsor = expensesorted.idsor
	WHERE sorting.idsorkind = @eMIUR
		AND #mov_res.varamount <> 0
		AND expensesorted.ayear = @ayear
		AND (SELECT COUNT(DISTINCT ES.idsor) 
			   FROM expensesorted ES 
			   JOIN sorting S
				ON  S.idsor = ES.idsor
			  WHERE ES.ayear = expensesorted.ayear 
				AND ES.idexp = expensesorted.idexp
				AND S.idsorkind = @eMIUR) > 1
	GROUP BY #mov_res.idmov, #mov_res.ymov,#mov_res.nmov, expensesorted.idsor, sorting.sortcode	

END	-- Fine codice per i movimenti di spesa
--select * from #mov_res
--select * from #var_res
select @codesorkind = codesorkind from sortingkind where idsorkind = @MIUR
select @sortingkind = description from sortingkind where idsorkind = @MIUR

select  @fase_MIUR + ' residuo ' + CONVERT(varchar(4), #class.ymov) + '/' + 
		CONVERT(varchar(10), #class.nmov) +
	    ' classificato secondo la classificazione '
		+ @sortingkind + ' (' + @codesorkind + ') ' 
		+ ' con codice '  + #class.sortcode
from #class order by #class.ymov, #class.nmov
END

--[exp_residual_miur] 2010, 'S'


