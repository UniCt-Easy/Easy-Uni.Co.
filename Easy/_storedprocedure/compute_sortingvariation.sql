
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_sortingvariation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_sortingvariation]
GO

CREATE PROCEDURE compute_sortingvariation
(
	@ayear int,
	@idsorkind int
)
AS BEGIN
DECLARE @nextayear int
SET @nextayear = @ayear + 1

CREATE TABLE #sortingprevexpensevar
(
	nvar int identity (1,1),
	idsor int,
	amount decimal(19,2)
)

INSERT INTO #sortingprevexpensevar
(
	idsor,
	amount
)
SELECT expensesorted.idsor, SUM(expensesorted.amount)
FROM expensesorted
JOIN sorting
	ON expensesorted.idsor = sorting.idsor
JOIN expensetotal
	ON expensetotal.idexp = expensesorted.idexp
	AND expensetotal.ayear = expensesorted.ayear
WHERE sorting.idsorkind = @idsorkind
	AND expensesorted.ayear = @nextayear
	AND (expensetotal.flag & 1 <> 0)
GROUP BY expensesorted.idsor
HAVING SUM(expensesorted.amount) <> 0

DECLARE @maxnvar_exp int
SET @maxnvar_exp = 1 + ISNULL((SELECT MAX(nvar) FROM sortingprevexpensevar WHERE ayear = @nextayear),0)

DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(char(4),@nextayear), 105)

INSERT INTO sortingprevexpensevar
(
	yvar,
	nvar,
	adate,
	idsor,
	amount,
	ayear,
	description,
	ct, cu, lt, lu
)
SELECT 
	@nextayear,
	nvar + @maxnvar_exp,
	@firstday,
	idsor,
	amount,
	@nextayear,
	'Variazioni sui residui',
	GETDATE(), 'SA', GETDATE(), 'SA'
FROM #sortingprevexpensevar

CREATE TABLE #sortingprevincomevar
(
	nvar int identity (1,1),
	idsor int,
	amount decimal(19,2)
)

INSERT INTO #sortingprevincomevar
(
	idsor,
	amount
)
SELECT incomesorted.idsor, SUM(incomesorted.amount)
FROM incomesorted
JOIN sorting
	ON incomesorted.idsor = sorting.idsor
JOIN incometotal
	ON incometotal.idinc = incomesorted.idinc
	AND incometotal.ayear = incomesorted.ayear
WHERE sorting.idsorkind = @idsorkind
	AND incomesorted.ayear = @nextayear
	AND (incometotal.flag & 1 <> 0)
GROUP BY incomesorted.idsor
HAVING SUM(incomesorted.amount) <> 0

DECLARE @maxnvar_inc int
SET @maxnvar_inc = 1 + ISNULL((SELECT MAX(nvar) FROM sortingprevincomevar WHERE ayear = @nextayear),0)

INSERT INTO sortingprevincomevar
(
	yvar,
	nvar,
	adate,
	idsor,
	amount,
	ayear,
	description,
	ct, cu, lt, lu
)
SELECT 
	@nextayear,
	nvar + @maxnvar_inc,
	@firstday,
	idsor,
	amount,
	@nextayear,
	'Variazioni sui residui',
	GETDATE(), 'SA', GETDATE(), 'SA'
FROM #sortingprevincomevar

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

