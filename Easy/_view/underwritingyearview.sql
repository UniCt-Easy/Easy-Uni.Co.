
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA underwritingyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[underwritingyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [underwritingyearview]
GO



CREATE  VIEW [underwritingyearview] 
(
	idunderwriting,
	underwriting,
	idunderwriter,
	underwriter,
	ayear,
	doc,
	docdate,
	prevision,-- � una previsione puramente indicativa, � extra-contabile
	initialprevision,
	currentprevision,
	initialsecondaryprev,
	currentsecondaryprev,
	incomeprevavailable,
	expenseprevavailable,
	appropriation,
	assessment,
	toassess,
	payment,
	proceeds,
	active,

	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cu,
	ct,
	lu,
	lt
)

AS SELECT
	underwriting.idunderwriting,
	underwriting.title,
	underwriting.idunderwriter,
	underwriter.description,
	underwritingyear.ayear,
	underwriting.doc,
	underwriting.docdate,
	-- prevision
	ISNULL(underwritingyear.prevision,0),
	-- initialprevision							
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.currentprev)			
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) = 0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)				
	,0),
	-- currentprevision
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.currentprev)
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.previsionvariation)
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0),
	-- initialsecondaryprev
	CASE
		WHEN config.fin_kind = 3
		THEN
			ISNULL(
				(SELECT SUM(upbunderwritingtotal.currentsecondaryprev)
				FROM    upbunderwritingtotal
				JOIN    fin
					ON fin.idfin = upbunderwritingtotal.idfin
				WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
				AND     ( (fin.flag & 1) =0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = underwritingyear.ayear
				GROUP BY upbunderwritingtotal.idunderwriting)
			,0)
		ELSE NULL
	END,
	-- currentsecondaryprev
	CASE
		WHEN config.fin_kind = 3
		THEN
			ISNULL(
				(SELECT SUM(upbunderwritingtotal.currentsecondaryprev)
				FROM    upbunderwritingtotal
				JOIN    fin
					ON fin.idfin = upbunderwritingtotal.idfin
				WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
				AND     ( (fin.flag & 1) =0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = underwritingyear.ayear
				GROUP BY upbunderwritingtotal.idunderwriting)
			,0)
			+ 
			ISNULL(
				(SELECT SUM(upbunderwritingtotal.secondaryvariation)
				FROM    upbunderwritingtotal
				JOIN    fin
					ON fin.idfin = upbunderwritingtotal.idfin
				WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
				AND     ( (fin.flag & 1) =0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = underwritingyear.ayear
				GROUP BY upbunderwritingtotal.idunderwriting)
			,0)
		ELSE NULL
	END,
	-- incomeprevavailable
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.currentprev)			
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.previsionvariation)
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0)
	-
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingincometotal.totalcompetency),0) + 
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(underwritingincometotal.totalarrears),0)
				ELSE 0
			END
		FROM    underwritingincometotal
		JOIN    fin
			ON fin.idfin = underwritingincometotal.idfin
		JOIN 	uniconfig 
			ON underwritingincometotal.nphase = uniconfig.incomefinphase
		WHERE   underwritingincometotal.idunderwriting = underwriting.idunderwriting
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY underwritingincometotal.idunderwriting)
	,0),
	--expenseprevavailable
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.currentprev)
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) = 1)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.previsionvariation)
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) = 1)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0)
	-
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(underwritingexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM underwritingexpensetotal
		JOIN fin
			ON fin.idfin = underwritingexpensetotal.idfin
		JOIN uniconfig 
			ON underwritingexpensetotal.nphase = uniconfig.expensefinphase
		WHERE underwritingexpensetotal.idunderwriting = underwriting.idunderwriting
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = underwritingyear.ayear
		GROUP BY underwritingexpensetotal.idunderwriting)
	,0),
	-- appropriation
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(underwritingexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM underwritingexpensetotal
		JOIN fin
			ON fin.idfin = underwritingexpensetotal.idfin
		JOIN uniconfig 
			ON underwritingexpensetotal.nphase = uniconfig.expensefinphase
		WHERE underwritingexpensetotal.idunderwriting = underwriting.idunderwriting
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = underwritingyear.ayear
		GROUP BY underwritingexpensetotal.idunderwriting)
	,0),
	-- assessment
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingincometotal.totalcompetency),0) + 
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(underwritingincometotal.totalarrears),0)
				ELSE 0
			END
		FROM    underwritingincometotal
		JOIN    fin
			ON fin.idfin = underwritingincometotal.idfin
		JOIN 	uniconfig 
			ON underwritingincometotal.nphase = uniconfig.incomefinphase
		WHERE   underwritingincometotal.idunderwriting = underwriting.idunderwriting
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY underwritingincometotal.idunderwriting)
	,0),
	-- toassess, cio� da accertare. = prevision - assesment
	ISNULL(underwritingyear.prevision,0)
		- ISNULL(
		(SELECT
			ISNULL(SUM(underwritingincometotal.totalcompetency),0) + 
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(underwritingincometotal.totalarrears),0)
				ELSE 0
			END
		FROM    underwritingincometotal
		JOIN    fin
			ON fin.idfin = underwritingincometotal.idfin
		JOIN 	uniconfig 
			ON underwritingincometotal.nphase = uniconfig.incomefinphase
		WHERE   underwritingincometotal.idunderwriting = underwriting.idunderwriting
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY underwritingincometotal.idunderwriting)
	,0),
	-- payment
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingexpensetotal.totalcompetency),0)  +
			ISNULL(SUM(underwritingexpensetotal.totalarrears),0)
		FROM underwritingexpensetotal
		JOIN fin
			ON fin.idfin = underwritingexpensetotal.idfin
		WHERE underwritingexpensetotal.idunderwriting = underwriting.idunderwriting
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = underwritingyear.ayear
		AND underwritingexpensetotal.nphase = (SELECT MAX(nphase) FROM expensephase)
		GROUP BY underwritingexpensetotal.idunderwriting)
	,0),
	-- proceeds
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingincometotal.totalcompetency),0) + 
			ISNULL(SUM(underwritingincometotal.totalarrears),0)
		FROM    underwritingincometotal
		JOIN    fin
			ON fin.idfin = underwritingincometotal.idfin
		WHERE underwritingincometotal.idunderwriting = underwriting.idunderwriting
		AND fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND fin.ayear = underwritingyear.ayear
		AND underwritingincometotal.nphase = (SELECT MAX(nphase) FROM incomephase)
		GROUP BY underwritingincometotal.idunderwriting)
	,0),
	underwriting.active,
	underwriting.idsor01,
	underwriting.idsor02,
	underwriting.idsor03,
	underwriting.idsor04,
	underwriting.idsor05,
	underwriting.cu,
	underwriting.ct,
	underwriting.lu,
	underwriting.lt
FROM underwriting
JOIN underwritingyear
	ON underwriting.idunderwriting = underwritingyear.idunderwriting
JOIN config
	ON config.ayear = underwritingyear.ayear
LEFT OUTER JOIN underwriter
	ON underwriting.idunderwriter = underwriter.idunderwriter



GO


