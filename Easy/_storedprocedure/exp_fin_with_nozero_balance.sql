
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_fin_with_nozero_balance]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_fin_with_nozero_balance]
GO

CREATE PROCEDURE exp_fin_with_nozero_balance
(
	@ayear int,
	@finpart char(1)
)
AS BEGIN

CREATE TABLE #dip
(
	idfin int,
	kind char(1),
	total decimal(19,2)
)

INSERT INTO #dip (idfin, kind, total)
SELECT D.idfin, 'P', SUM(D.amount)
FROM finvar V
JOIN finvardetail D
	ON V.yvar = D.yvar
	AND V.nvar = D.nvar
JOIN fin F
	ON F.idfin = D.idfin
WHERE D.idupb = '0001'
	AND V.variationkind = 4
	AND V.yvar = @ayear
	AND V.flagprevision = 'S'
	AND V.idfinvarstatus = 5
	AND (
		(((F.flag & 1) = 0) AND (@finpart = 'E'))
		OR
		(((F.flag & 1) <> 0) AND (@finpart = 'S'))
	)
GROUP BY D.idfin

INSERT INTO #dip (idfin, kind, total)
SELECT D.idfin, 'P', SUM(D.amount)
FROM finvar V
JOIN finvardetail D
	ON V.yvar = D.yvar
	AND V.nvar = D.nvar
JOIN fin F
	ON F.idfin = D.idfin
WHERE D.idupb <> '0001'
	AND V.variationkind = 4
	AND V.yvar = @ayear
	AND V.flagprevision = 'S'
	AND V.idfinvarstatus = 5
	AND (
		(((F.flag & 1) = 0) AND (@finpart = 'E'))
		OR
		(((F.flag & 1) <> 0) AND (@finpart = 'S'))
	)
GROUP BY D.idfin

DECLARE @fin_kind int
SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear

IF (@fin_kind = 3)
BEGIN
	INSERT INTO #dip (idfin, kind, total)
	SELECT D.idfin, 'S', SUM(D.amount)
	FROM finvar V
	JOIN finvardetail D
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar
	JOIN fin F
		ON F.idfin = D.idfin
	WHERE D.idupb = '0001'
		AND V.variationkind = 4
		AND V.yvar = @ayear
		AND V.flagsecondaryprev = 'S'
		AND V.idfinvarstatus = 5
		AND (
			(((F.flag & 1) = 0) AND (@finpart = 'E'))
			OR
			(((F.flag & 1) <> 0) AND (@finpart = 'S'))
		)
	GROUP BY D.idfin
	
	INSERT INTO #dip (idfin, kind, total)
	SELECT D.idfin, 'S', SUM(D.amount)
	FROM finvar V
	JOIN finvardetail D
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar
	JOIN fin F
		ON F.idfin = D.idfin
	WHERE D.idupb <> '0001'
		AND V.variationkind = 4
		AND V.yvar = @ayear
		AND V.flagsecondaryprev = 'S'
		AND V.idfinvarstatus = 5
		AND (
			(((F.flag & 1) = 0) AND (@finpart = 'E'))
			OR
			(((F.flag & 1) <> 0) AND (@finpart = 'S'))
		)
	GROUP BY D.idfin
END

IF (@fin_kind <> 3)
BEGIN
	-- Vengono considerate solo le variazioni di storno
	SELECT F.codefin as 'Codice Bilancio',
	F.title AS 'Descrizione', SUM(#dip.total) as 'Saldo'
	FROM #dip
	JOIN fin F
		ON F.idfin = #dip.idfin
	GROUP BY #dip.idfin, F.codefin, F.title
	HAVING SUM(#dip.total) <> 0
END
ELSE
BEGIN
	-- Vengono considerate solo le variazioni di storno
	SELECT F.codefin as 'Codice Bilancio',
	F.title AS 'Descrizione', SUM(#dip.total) as 'Saldo',
	CASE
		WHEN #dip.kind = 'P'
		THEN 'Competenza'
		ELSE 'Cassa'
	END AS 'Previsione'
	FROM #dip
	JOIN fin F
		ON F.idfin = #dip.idfin
	GROUP BY #dip.idfin, F.codefin, F.title, #dip.kind
	HAVING SUM(#dip.total) <> 0
END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

