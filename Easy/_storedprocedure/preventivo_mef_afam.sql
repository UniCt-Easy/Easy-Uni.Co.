/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[preventivo_mef_afam]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [preventivo_mef_afam]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
--preventivo_mef_afam '2025', '13'
CREATE      PROCEDURE [preventivo_mef_afam]
(
	@ayear int,--> anno del bilancio di previsione
	@idsorkindfin int
)
AS BEGIN

	CREATE TABLE #mef_sheet
	(
		classificazione varchar(200),
		colonna char(1),
		valore decimal(19,2),
		movkind char(1),
		foglio varchar(100)
	)

	CREATE TABLE #preventivo
	(
		description varchar(200),
		movkind char(1),
		b decimal(19,2),
		c decimal(19,2),
		d decimal(19,2),
		e decimal(19,2)
	)

	CREATE TABLE #data
	(
		codefin varchar(50),
		fin varchar(200),
		movkind char(1),
	
		initialprevision decimal(19,2),
		previousprevision decimal(19,2),
		secondaryprevision decimal(19,2),
		currentarrears decimal(19,2)
	)

	DECLARE @fin_kind tinyint
	SELECT @fin_kind = fin_kind
	FROM config
	WHERE ayear = @ayear

	INSERT INTO #data 
	(
		codefin,
		fin,
		movkind,
	
		initialprevision,
		previousprevision,
		secondaryprevision,
		currentarrears
	)
	SELECT 
		sorFin.sortcode,	
		sorFin.description,
		sorFin.movkind,
		ISNULL(SUM(isnull(FS.quota,1)*finyear.prevision),0),
		ISNULL(SUM(isnull(FS.quota,1)*finyear.previousprevision),0), 
		ISNULL(SUM(isnull(FS.quota,1)*finyear.secondaryprev),0),
		ISNULL(SUM(isnull(FS.quota,1)*finyear.currentarrears),0)
	FROM sorting sorFin	
		left outer JOIN finsorting FS ON sorFin.idsor = FS.idsor	
		left outer JOIN fin	ON FS.idfin = fin.idfin	 AND fin.ayear = @ayear 	
		LEFT OUTER JOIN finlast	 ON fin.idfin = finlast.idfin
		left outer join  finyear ON finyear.idfin = fin.idfin
		WHERE sorFin.idsorkind= @idsorkindfin
		and sorFin.nlevel = (select max(nlevel) from sortinglevel where idsorkind = @idsorkindfin)
	group by  sorFin.sortcode, sorFin.description, sorFin.movkind
	
	IF( @fin_kind = 3)
	Begin		
		INSERT INTO #preventivo
		(
			description,
			movkind,
			b,
			c,
			d,
			e
		)
		SELECT 	
			fin,
			movkind,
			ISNULL(SUM(currentarrears),0),
			ISNULL(SUM(previousprevision),0),
			isnull(SUM(initialprevision),0),
			ISNULL(SUM(secondaryprevision),0)
		FROM #data
		GROUP BY codefin, fin, movkind
		ORDER BY codefin, movkind
	End
	ELSE
	Begin
		INSERT INTO #preventivo
		(
			description,
			movkind,
			c,
			d
		)
		SELECT
			fin,
			movkind,
			ISNULL(SUM(previousprevision),0),
			isnull(SUM(initialprevision),0)
		FROM #data
		GROUP BY codefin, fin, movkind
		ORDER BY codefin, movkind
	End

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'B',
		b,
		movkind,
		'Bilancio finanziario'
	FROM #preventivo

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'C',
		c,
		movkind,
		'Bilancio finanziario'
	FROM #preventivo

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'D',
		d,
		movkind,
		'Bilancio finanziario'
	FROM #preventivo

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'E',
		e,
		movkind,
		'Bilancio finanziario'
	FROM #preventivo

	SELECT
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	FROM #mef_sheet
	ORDER BY foglio, classificazione, movkind, colonna

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO