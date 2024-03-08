
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_anagrafica_rendiconto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_anagrafica_rendiconto]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE      PROCEDURE rpt_anagrafica_rendiconto
	@ayear int, 
	@date datetime
AS
BEGIN
CREATE TABLE #proceeds
(
	idreg int,
	proceeds decimal(19,2)
)

INSERT INTO #proceeds
SELECT 
	idreg,
	SUM(amount)
FROM historyproceedsview
WHERE 	ymov = @ayear 
	AND competencydate < = @date
GROUP BY idreg
CREATE TABLE #payments
(
	idreg int,
	payment decimal(19,2)						
)
INSERT INTO #payments
SELECT 
	idreg,
	SUM(amount)
FROM historypaymentview
WHERE 	ymov = @ayear 
	AND competencydate < = @date
GROUP BY idreg
CREATE TABLE #varproceeds
(
	idreg int,
	varproceeds decimal(19,2)						
)
DECLARE @maxincomephase varchar(20)
SELECT @maxincomephase = MAX(nphase)
FROM incomephase

INSERT INTO #varproceeds
SELECT 
	income.idreg,
	SUM(incomevar.amount)
FROM incomevar
JOIN income
	ON incomevar.idinc = income.idinc
WHERE income.nphase = @maxincomephase 
	AND incomevar.yvar = @ayear
	AND incomevar.adate <= @date
GROUP BY income.idreg

CREATE TABLE #varpayments
(
	idreg int,
	varpayment decimal(19,2)						
)

DECLARE @maxexpensephase varchar(20)
SELECT @maxexpensephase = MAX(nphase)
FROM expensephase
INSERT INTO #varpayments
SELECT 
	expense.idreg,
	SUM(expensevar.amount)
FROM expensevar
JOIN expense
	ON expensevar.idexp = expense.idexp
WHERE expense.nphase = @maxexpensephase
	AND expensevar.yvar = @ayear
	AND expensevar.adate <= @date
GROUP BY expense.idreg

--- Modifica Piero ---


CREATE TABLE #incomephase
(
	idreg int,
	amount decimal(19,2)
)

INSERT INTO #incomephase
SELECT
	income.idreg,
	sum(incomeyear.amount)
FROM income 
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
JOIN config 
	ON income.ymov=config.ayear
WHERE income.nphase = config.incomephase
	AND income.ymov=@ayear
	AND incomeyear.ayear = @ayear -- new
	AND income.adate <= @date
GROUP BY income.idreg


CREATE TABLE #varincomephase
(
	idreg int,
	amount decimal(19,2)						
)

INSERT INTO #varincomephase
SELECT 
	income.idreg,
	SUM(incomevar.amount)
FROM incomevar
JOIN income
	ON incomevar.idinc = income.idinc
JOIN config 
	ON income.ymov=config.ayear
WHERE income.nphase = config.incomephase
	AND incomevar.yvar = @ayear
	AND incomevar.adate <= @date
GROUP BY income.idreg


CREATE TABLE #expensephase
(
	idreg int,
	amount decimal(19,2)
)

INSERT INTO #expensephase
SELECT
	expense.idreg,
	sum(expenseyear.amount)
FROM expense 
JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
JOIN config 
	on expense.ymov=config.ayear
WHERE expense.nphase = config.expensephase
	AND expenseyear.ayear = @ayear
	AND expense.ymov=@ayear
	AND expense.adate <= @date
GROUP BY expense.idreg

CREATE TABLE #varexpensephase
(
	idreg int,
	amount decimal(19,2)						
)

INSERT INTO #varexpensephase
SELECT 
	expense.idreg,
	SUM(expensevar.amount)
FROM expensevar
JOIN expense
	ON expensevar.idexp = expense.idexp
JOIN config 
	ON expense.ymov=config.ayear
WHERE expense.nphase = config.expensephase
	AND expensevar.yvar = @ayear
	AND expensevar.adate <= @date
GROUP BY expense.idreg

--- fine modifica Piero

CREATE TABLE #rendiconto
(
	idreg int,
	title varchar(50),
	cf varchar(16),
	p_iva varchar(15),
	proceeds decimal(19,2),
	payment decimal(19,2),
	assessment decimal(19,2),
	appropriation decimal(19,2)
)
INSERT INTO #rendiconto(idreg)
SELECT idreg
FROM registry
UPDATE #rendiconto
	SET proceeds =	ISNULL((SELECT proceeds 
				FROM #proceeds
				WHERE #proceeds.idreg = #rendiconto.idreg), 0.0)
			+ ISNULL((SELECT varproceeds 
				FROM #varproceeds
				WHERE #varproceeds.idreg = #rendiconto.idreg), 0.0)
UPDATE #rendiconto
	SET payment = ISNULL((SELECT payment 
				FROM #payments
				WHERE #payments.idreg = #rendiconto.idreg), 0.0)
			+ ISNULL((SELECT varpayment 
				FROM #varpayments
				WHERE #varpayments.idreg = #rendiconto.idreg), 0.0)
-- Modifica Piero --
UPDATE #rendiconto
	SET assessment = ISNULL((SELECT amount
				  FROM #incomephase
				  WHERE #incomephase.idreg = #rendiconto.idreg),0.0)
			+ ISNULL((SELECT amount
				FROM #varincomephase
				WHERE #varincomephase.idreg = #rendiconto.idreg),0.0)
UPDATE #rendiconto
	SET appropriation = ISNULL((SELECT amount
				  FROM #expensephase
				  WHERE #expensephase.idreg = #rendiconto.idreg),0.0)
			+ ISNULL((SELECT amount
				FROM #varexpensephase
				WHERE #varexpensephase.idreg = #rendiconto.idreg),0.0)

-- fine modifica Piero --

SELECT 
	#rendiconto.idreg,
	registry.title,
	registry.cf,  
	registry.p_iva,
	#rendiconto.proceeds,
	#rendiconto.payment,
	#rendiconto.assessment as assessment,  	--inserimento accertati
	#rendiconto.appropriation as appropriation	--inserimento impegnati
FROM	#rendiconto 
JOIN 	registry
	on #rendiconto.idreg = registry.idreg
WHERE (ISNULL(proceeds, 0) <> 0 OR ISNULL(payment, 0) <> 0)
ORDER BY registry.title ASC
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

