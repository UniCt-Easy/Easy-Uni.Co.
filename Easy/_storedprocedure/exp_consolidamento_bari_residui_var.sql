
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_consolidamento_bari_residui_var]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_consolidamento_bari_residui_var]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE      PROCEDURE exp_consolidamento_bari_residui_var
(
	@ayear int,
	@finpart char(1),
	@levelusable tinyint
)
AS 
BEGIN

/* Versione 1.0.0 del 04/03/2008 ultima modifica: GIUSEPPE */

--  exec exp_consolidamento_bari_residui_var 2007,'S',2

CREATE TABLE #output
(
	nrow int,
	ymov int,
	nmov int,
	idmov int,
	idfin int,
	startamount decimal(19,2),
	variationamount decimal(19,2),
	lastphaseamount decimal(19,2)
)

DECLARE @arrearsphase tinyint
DECLARE @maxphase tinyint
IF @finpart = 'E'
BEGIN
	SELECT @arrearsphase = assessmentphasecode FROM config WHERE ayear = @ayear
	SELECT @maxphase = MAX(nphase) FROM incomephase
END
ELSE
BEGIN
	SELECT @arrearsphase = appropriationphasecode FROM config WHERE ayear = @ayear
	SELECT @maxphase = MAX(nphase) FROM expensephase
END

IF @finpart = 'E'
BEGIN
	INSERT INTO #output (nrow, ymov, nmov, idmov, idfin, startamount, variationamount)
	SELECT
		0, incomeview.ymov, incomeview.nmov, incomeview.idinc,
		finlink.idparent, 
		incomeview.ayearstartamount,
		-ISNULL(
			(SELECT SUM(amount) FROM incomevar
			WHERE incomevar.idinc = incomeview.idinc
				AND incomevar.yvar = @ayear)
		,0)
	FROM incomeview
	LEFT OUTER JOIN finlink
		ON finlink.idchild = incomeview.idfin
	WHERE finlink.nlevel = @levelusable
		AND incomeview.nphase = @arrearsphase
		AND ymov < @ayear
		AND ayear = @ayear

	UPDATE #output SET lastphaseamount = 
	ISNULL(
		(SELECT SUM(curramount)
		FROM incomeview
		JOIN incomelink
			ON incomeview.idinc = incomelink.idchild
		WHERE incomelink.idparent = #output.idmov
			AND incomeview.ayear = @ayear
			AND incomeview.nphase = @maxphase)
	,0)
END
ELSE
BEGIN
	INSERT INTO #output (nrow, ymov, nmov, idmov, idfin, startamount, variationamount)
	SELECT
		0, expenseview.ymov, expenseview.nmov, expenseview.idexp,
		finlink.idparent, 
		expenseview.ayearstartamount,
		-ISNULL(
			(SELECT SUM(amount) FROM expensevar
			WHERE expensevar.idexp = expenseview.idexp
				AND expensevar.yvar = @ayear)
		,0)
	FROM expenseview
	LEFT OUTER JOIN finlink
		ON finlink.idchild = expenseview.idfin
	WHERE finlink.nlevel = @levelusable
		AND expenseview.nphase = @arrearsphase
		AND ymov < @ayear
		AND ayear = @ayear

	UPDATE #output SET lastphaseamount = 
	ISNULL(
		(SELECT SUM(curramount)
		FROM expenseview
		JOIN expenselink
			ON expenseview.idexp = expenselink.idchild
		WHERE expenselink.idparent = #output.idmov
			AND expenseview.ayear = @ayear
			AND expenseview.nphase = @maxphase)
	,0)
END

INSERT INTO #output (nrow, startamount, variationamount, lastphaseamount)
SELECT 1, SUM(startamount), SUM(variationamount), SUM(lastphaseamount)
FROM #output

IF @finpart = 'E'
BEGIN
	SELECT 
		#output.ymov as 'Esercizio',
		#output.nmov as 'Numero',
		CASE
			WHEN nrow = 0
			THEN fin.codefin
			ELSE 'TOTALE'
		END  as 'Cod. Bilancio',
		CASE
			WHEN nrow = 0
			THEN fin.title
			ELSE NULL
		END as 'Descr. Bilancio',
		startamount as 'Importo all''1/1',
		variationamount as 'Variazioni in Diminuzione',
		lastphaseamount as 'Incassato',
		ISNULL(startamount,0) - ISNULL(variationamount,0) - ISNULL(lastphaseamount,0) as 'Importo al 31/12'
	FROM #output
	LEFT OUTER JOIN fin
		ON fin.idfin = #output.idfin
	ORDER BY nrow, ymov, nmov
END
ELSE
BEGIN
	SELECT 
		#output.ymov as 'Esercizio',
		#output.nmov as 'Numero',
		CASE
			WHEN nrow = 0
			THEN fin.codefin
			ELSE 'TOTALE'
		END as 'Cod. Bilancio',
		CASE
			WHEN nrow = 0
			THEN fin.title
			ELSE NULL
		END as 'Descr. Bilancio',
		startamount as 'Importo all''1/1',
		variationamount as 'Variazioni in Diminuzione',
		lastphaseamount as 'Pagato',
		ISNULL(startamount,0) - ISNULL(variationamount,0) - ISNULL(lastphaseamount,0) as 'Importo al 31/12'
	FROM #output
	LEFT OUTER JOIN fin
		ON fin.idfin = #output.idfin
	ORDER BY nrow, ymov, nmov
END
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
