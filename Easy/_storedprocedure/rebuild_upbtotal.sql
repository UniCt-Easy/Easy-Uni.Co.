
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


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_upbtotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_upbtotal]
GO
 
CREATE     PROCEDURE [rebuild_upbtotal]
(
	@ayear int = null
)
AS BEGIN

IF (@ayear IS NULL) 
BEGIN
	DELETE FROM upbtotal
	INSERT INTO upbtotal (idfin, idupb, previsionvariation,
					--previsionvariation_inserted,
				 secondaryvariation, creditvariation, proceedsvariation) 
	SELECT   F.idfin, D.idupb,
				sum( case when V.flagprevision='S' and V.idfinvarstatus = 5 then D.amount else 0 end),
				--sum( case when V.flagprevision='S'  then D.amount else 0 end),
				sum( case when V.flagsecondaryprev='S' and V.idfinvarstatus = 5  then D.amount else 0 end),
				sum( case when V.flagcredit='S' and V.idfinvarstatus = 5 AND F.flag&1<>0  then D.amount else 0 end),
				sum( case when V.flagproceeds='S' and V.idfinvarstatus = 5 AND F.flag&1<>0  then D.amount else 0 end)
	from finvardetail D 
			join finvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
			join finlink FL ON FL.idchild=D.idfin
			join fin F ON F.idfin=FL.idparent
			where  (V.idfinvarstatus = 5  or   V.idfinvarstatus = 4) and V.variationkind <> 5
	group by F.idfin, D.idupb

	
	
	INSERT INTO upbtotal (idfin, idupb, previsionvariation, 
					--previsionvariation_inserted, 
					secondaryvariation, creditvariation, proceedsvariation)
	SELECT DISTINCT F.idfin, IY.idupb, 0,
			--0,
			0,0,0		
	FROM fin F
	JOIN finlink FL
		ON FL.idparent = F.idfin
	JOIN expenseyear IY
		ON IY.idfin = FL.idchild
	WHERE NOT EXISTS
		(SELECT upbtotal.idfin FROM upbtotal
		WHERE upbtotal.idfin = F.idfin AND upbtotal.idupb = IY.idupb)

	
	
	INSERT INTO upbtotal (idfin, idupb, previsionvariation, 
					--previsionvariation_inserted,
					secondaryvariation, creditvariation, proceedsvariation)
	SELECT DISTINCT F.idfin, IY.idupb, 0,
					--0,
						0,0,0		
	FROM fin F
	JOIN finlink FL
		ON FL.idparent = F.idfin
	JOIN incomeyear IY
		ON IY.idfin = FL.idchild
	WHERE NOT EXISTS
		(SELECT upbtotal.idfin FROM upbtotal
		WHERE upbtotal.idfin = F.idfin AND upbtotal.idupb = IY.idupb)

	
	INSERT INTO upbtotal (idfin, idupb, previsionvariation,	-- previsionvariation_inserted,
			secondaryvariation, creditvariation, proceedsvariation) 
	SELECT DISTINCT F.idfin, FY.idupb,0, --0,
					0,0,0
		
	FROM fin F
	JOIN finlink FL
		ON FL.idparent = F.idfin
	JOIN finyear FY
		ON FY.idfin = FL.idchild
	WHERE (
			ISNULL(FY.previousprevision,0) <> 0 OR
			ISNULL(FY.prevision,0) <> 0 OR
			ISNULL(FY.previoussecondaryprev,0) <> 0 OR
			ISNULL(FY.secondaryprev,0) <> 0 OR
			ISNULL(FY.previousarrears,0) <> 0 OR
			ISNULL(FY.currentarrears,0) <> 0
		)
	AND NOT EXISTS
		(SELECT upbtotal.idfin FROM upbtotal
		WHERE upbtotal.idfin = F.idfin AND upbtotal.idupb = FY.idupb)

	INSERT INTO upbtotal (idfin, idupb)
	SELECT DISTINCT CP.idfin, CP.idupb
	FROM creditpart CP
	JOIN fin
		ON fin.idfin = CP.idfin
	WHERE NOT EXISTS(SELECT U.idfin FROM upbtotal U WHERE U.idfin = CP.idfin AND U.idupb = CP.idupb)

	INSERT INTO upbtotal (idfin, idupb)
	SELECT DISTINCT PP.idfin, PP.idupb
	FROM proceedspart PP
	JOIN fin
		ON fin.idfin = PP.idfin
	WHERE NOT EXISTS(SELECT U.idfin FROM upbtotal U WHERE U.idfin = PP.idfin AND U.idupb = PP.idupb)

	UPDATE upbtotal 
	SET
	totcreditpart =
	(
		SELECT SUM(creditpart.amount)
		FROM creditpart
		WHERE creditpart.idfin = upbtotal.idfin
			AND creditpart.idupb = upbtotal.idupb
	)
	
	UPDATE upbtotal 
	SET totproceedspart =
	(
		SELECT SUM(proceedspart.amount)
		FROM proceedspart
		WHERE proceedspart.idfin = upbtotal.idfin
		AND proceedspart.idupb = upbtotal.idupb
	)

	UPDATE upbtotal SET 
	previousprev = 
		(SELECT t2.previousprevision
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.previousprevision IS NOT NULL)

	UPDATE upbtotal SET 
	currentprev = 
		(SELECT t2.prevision
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.prevision IS NOT NULL)

	UPDATE upbtotal SET 
	previoussecondaryprev = 
		(SELECT t2.previoussecondaryprev
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.previoussecondaryprev IS NOT NULL)

	UPDATE upbtotal SET 
	currentsecondaryprev = 
		(SELECT t2.secondaryprev
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.secondaryprev IS NOT NULL)

	UPDATE upbtotal SET 
	previousarrears = 
		(SELECT t2.previousarrears
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.previousarrears IS NOT NULL)

	UPDATE upbtotal SET 
	currentarrears = 
		(SELECT t2.currentarrears
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.currentarrears IS NOT NULL)
END
ELSE -- @ayear specificato
BEGIN 
	DELETE FROM upbtotal WHERE EXISTS(SELECT fin.idfin FROM fin WHERE fin.idfin = upbtotal.idfin AND fin.ayear = @ayear)
	
	INSERT INTO upbtotal (idfin, idupb, previsionvariation, --previsionvariation_inserted,
				 secondaryvariation, creditvariation, proceedsvariation) 
	SELECT   F.idfin, D.idupb,
				sum( case when V.flagprevision='S' and V.idfinvarstatus = 5 then D.amount else 0 end),
				--sum( case when V.flagprevision='S'  then D.amount else 0 end),
				sum( case when V.flagsecondaryprev='S' and V.idfinvarstatus = 5 then D.amount else 0 end),
				sum( case when V.flagcredit='S' and V.idfinvarstatus = 5 AND F.flag&1<>0  then D.amount else 0 end),
				sum( case when V.flagproceeds='S' and V.idfinvarstatus = 5 AND F.flag&1<>0  then D.amount else 0 end)
	from finvardetail D 
			join finvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
			join finlink FL ON FL.idchild=D.idfin
			join fin F ON F.idfin=FL.idparent
			where  (V.idfinvarstatus = 5  or   V.idfinvarstatus = 4) and V.variationkind <> 5 and F.ayear = @ayear
	group by F.idfin, D.idupb

	
	INSERT INTO upbtotal (idfin, idupb, previsionvariation, --previsionvariation_inserted,
				secondaryvariation, creditvariation, proceedsvariation)
	SELECT DISTINCT F.idfin, IY.idupb,0,--0,
			0,0,0
	FROM fin F
	JOIN finlink FL				ON FL.idparent = F.idfin
	JOIN expenseyear IY			ON IY.idfin = FL.idchild
	WHERE F.ayear = @ayear
		AND NOT EXISTS	(SELECT upbtotal.idfin FROM upbtotal	WHERE upbtotal.idfin = F.idfin AND upbtotal.idupb = IY.idupb)
	
	
	INSERT INTO upbtotal (idfin, idupb, previsionvariation, --previsionvariation_inserted,
					secondaryvariation, creditvariation, proceedsvariation)
	SELECT DISTINCT F.idfin, IY.idupb,0,	--0	,
					0,0,0
	FROM fin F
	JOIN finlink FL				ON FL.idparent = F.idfin
	JOIN incomeyear IY			ON IY.idfin = FL.idchild
	WHERE F.ayear = @ayear
		AND NOT EXISTS	(SELECT upbtotal.idfin FROM upbtotal	WHERE upbtotal.idfin = F.idfin AND upbtotal.idupb = IY.idupb)
	
	INSERT INTO upbtotal (idfin, idupb, previsionvariation, --previsionvariation_inserted,
			secondaryvariation, creditvariation, proceedsvariation) 
	SELECT DISTINCT F.idfin, FY.idupb, 0,	--0,
					0,0,0
	FROM fin F
	JOIN finlink FL					ON FL.idparent = F.idfin
	JOIN finyear FY					ON FY.idfin = FL.idchild
	WHERE F.ayear = @ayear
		AND (
			ISNULL(FY.previousprevision,0) <> 0 OR
			ISNULL(FY.prevision,0) <> 0 OR
			ISNULL(FY.previoussecondaryprev,0) <> 0 OR
			ISNULL(FY.secondaryprev,0) <> 0 OR
			ISNULL(FY.previousarrears,0) <> 0 OR
			ISNULL(FY.currentarrears,0) <> 0
		)
	AND NOT EXISTS
		(SELECT upbtotal.idfin FROM upbtotal
		WHERE upbtotal.idfin = F.idfin AND upbtotal.idupb = FY.idupb)

	INSERT INTO upbtotal (idfin, idupb)

	SELECT DISTINCT CP.idfin, CP.idupb
	FROM creditpart CP
	JOIN fin
		ON fin.idfin = CP.idfin
	WHERE NOT EXISTS(SELECT U.idfin FROM upbtotal U WHERE U.idfin = CP.idfin AND U.idupb = CP.idupb)
		AND fin.ayear = @ayear

	INSERT INTO upbtotal (idfin, idupb)
	SELECT DISTINCT PP.idfin, PP.idupb
	FROM proceedspart PP
	JOIN fin
		ON fin.idfin = PP.idfin
	WHERE NOT EXISTS(SELECT U.idfin FROM upbtotal U WHERE U.idfin = PP.idfin AND U.idupb = PP.idupb)
		AND fin.ayear = @ayear

	UPDATE upbtotal 
	SET
	totcreditpart =
	(
		SELECT SUM(creditpart.amount)
		FROM creditpart
		WHERE creditpart.idfin = upbtotal.idfin
			AND creditpart.idupb = upbtotal.idupb
	)
	FROM fin WHERE fin.idfin = upbtotal.idfin AND fin.ayear = @ayear

	UPDATE upbtotal 
	SET totproceedspart =
	(
		SELECT SUM(proceedspart.amount)
		FROM proceedspart
		WHERE proceedspart.idfin = upbtotal.idfin
			AND proceedspart.idupb = upbtotal.idupb
	)
	FROM fin WHERE fin.idfin = upbtotal.idfin AND fin.ayear = @ayear

	UPDATE upbtotal SET 
	previousprev = 
		(SELECT t2.previousprevision
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.previousprevision IS NOT NULL)
	FROM fin WHERE fin.idfin = upbtotal.idfin AND fin.ayear = @ayear

	UPDATE upbtotal SET 
	currentprev = 
		(SELECT t2.prevision
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.prevision IS NOT NULL)
	FROM fin WHERE fin.idfin = upbtotal.idfin AND fin.ayear = @ayear

	UPDATE upbtotal SET 
	previoussecondaryprev = 
		(SELECT t2.previoussecondaryprev
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.previoussecondaryprev IS NOT NULL)
	FROM fin WHERE fin.idfin = upbtotal.idfin AND fin.ayear = @ayear

	UPDATE upbtotal SET 
	currentsecondaryprev = 
		(SELECT t2.secondaryprev
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.secondaryprev IS NOT NULL)
	FROM fin WHERE fin.idfin = upbtotal.idfin AND fin.ayear = @ayear

	UPDATE upbtotal SET 
	previousarrears = 
		(SELECT t2.previousarrears
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.previousarrears IS NOT NULL)
	FROM fin WHERE fin.idfin = upbtotal.idfin AND fin.ayear = @ayear

	UPDATE upbtotal SET 
	currentarrears = 
		(SELECT t2.currentarrears
		FROM finyear t2
		WHERE t2.idfin = upbtotal.idfin
			AND t2.idupb = upbtotal.idupb
			AND t2.currentarrears IS NOT NULL)
	FROM fin WHERE fin.idfin = upbtotal.idfin AND fin.ayear = @ayear
END

DECLARE @nlevel tinyint
SELECT @nlevel = MAX(nlevel) FROM finlevel
set @nlevel = @nlevel-1

WHILE (@nlevel>0)
BEGIN
	IF (@ayear IS NULL)
	BEGIN
		UPDATE upbtotal SET 
		previousprev =
			(SELECT SUM(t2.previousprev)
			FROM upbtotal t2
			JOIN fin F
				ON F.idfin = t2.idfin
			WHERE t2.previousprev IS NOT NULL
				AND F.paridfin = upbtotal.idfin
				AND t2.idupb = upbtotal.idupb)
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.nlevel = @nlevel
			AND ISNULL(upbtotal.previousprev,0) = 0
	
		UPDATE upbtotal SET 
		currentprev =
			(SELECT SUM(t2.currentprev)
			FROM upbtotal t2
			JOIN fin F
				ON F.idfin = t2.idfin
			WHERE t2.currentprev IS NOT NULL
				AND F.paridfin = upbtotal.idfin
				AND t2.idupb = upbtotal.idupb) 
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.nlevel = @nlevel
			AND ISNULL(upbtotal.currentprev,0) = 0
 
	
		UPDATE upbtotal SET 
		previoussecondaryprev =
			(SELECT SUM(t2.previoussecondaryprev)
			FROM upbtotal t2
			JOIN fin F
				ON F.idfin = t2.idfin
			WHERE t2.previoussecondaryprev IS NOT NULL
				AND F.paridfin = upbtotal.idfin
				AND t2.idupb = upbtotal.idupb) 
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.nlevel = @nlevel
			AND ISNULL(upbtotal.previoussecondaryprev,0) = 0
		 
		UPDATE upbtotal SET 
		currentsecondaryprev =
			(SELECT SUM(t2.currentsecondaryprev)
			FROM upbtotal t2
			JOIN fin F
				ON F.idfin = t2.idfin
			WHERE t2.currentsecondaryprev IS NOT NULL
				AND F.paridfin = upbtotal.idfin
				AND t2.idupb = upbtotal.idupb) 
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.nlevel = @nlevel
			AND ISNULL(upbtotal.currentsecondaryprev,0) = 0
		 
		UPDATE upbtotal SET 
		previousarrears =
			(SELECT SUM(t2.previousarrears)
			FROM upbtotal t2
			JOIN fin F
				ON F.idfin = t2.idfin
			WHERE t2.previousarrears IS NOT NULL
				AND F.paridfin = upbtotal.idfin
				AND t2.idupb = upbtotal.idupb) 
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.nlevel = @nlevel
			AND ISNULL(upbtotal.previousarrears,0) = 0
		 
		UPDATE upbtotal SET 
		currentarrears =
			(SELECT SUM(t2.currentarrears)
			FROM upbtotal t2
			JOIN fin F
				ON F.idfin = t2.idfin
			WHERE t2.currentarrears IS NOT NULL
				AND F.paridfin = upbtotal.idfin
				AND t2.idupb = upbtotal.idupb) 
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.nlevel = @nlevel
			AND ISNULL(upbtotal.currentarrears,0) = 0
		 
	END
	ELSE
	BEGIN
		UPDATE upbtotal SET 
		previousprev =	--somma dei figli
			(SELECT SUM(t2.previousprev)
			FROM upbtotal t2
			JOIN fin F 				ON F.idfin = t2.idfin
			WHERE t2.previousprev IS NOT NULL
				AND F.paridfin = upbtotal.idfin  --F.idfin= t2.idfin punta ai figli di upbtotal 
				AND t2.idupb = upbtotal.idupb) 
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.ayear = @ayear
			AND fin.nlevel = @nlevel
			AND isnull(upbtotal.previousprev,0) = 0
	
		UPDATE upbtotal SET 
		currentprev =
			(SELECT SUM(t2.currentprev)
			FROM upbtotal t2
			JOIN fin F
				ON F.idfin = t2.idfin
			WHERE t2.currentprev IS NOT NULL
				AND F.paridfin = upbtotal.idfin
				AND t2.idupb = upbtotal.idupb) 
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.ayear = @ayear
			AND fin.nlevel = @nlevel
			AND isnull(upbtotal.currentprev,0) = 0
 
	
		UPDATE upbtotal SET 
		previoussecondaryprev =
			(SELECT SUM(t2.previoussecondaryprev)
			FROM upbtotal t2
			JOIN fin F
				ON F.idfin = t2.idfin
			WHERE t2.previoussecondaryprev IS NOT NULL
				AND F.paridfin = upbtotal.idfin
				AND t2.idupb = upbtotal.idupb) 
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.ayear = @ayear
			AND fin.nlevel = @nlevel
			AND isnull(upbtotal.previoussecondaryprev,0) = 0
		 
		UPDATE upbtotal SET 
		currentsecondaryprev =
			(SELECT SUM(t2.currentsecondaryprev)
			FROM upbtotal t2
			JOIN fin F
				ON F.idfin = t2.idfin
			WHERE t2.currentsecondaryprev IS NOT NULL
				AND F.paridfin = upbtotal.idfin
				AND t2.idupb = upbtotal.idupb) 
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.ayear = @ayear
			AND fin.nlevel = @nlevel
			AND isnull(upbtotal.currentsecondaryprev,0) = 0
		 
		UPDATE upbtotal SET 
		previousarrears =
			(SELECT SUM(t2.previousarrears)
			FROM upbtotal t2
			JOIN fin F
				ON F.idfin = t2.idfin
			WHERE t2.previousarrears IS NOT NULL
				AND F.paridfin = upbtotal.idfin
				AND t2.idupb = upbtotal.idupb)
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.ayear = @ayear
			AND fin.nlevel = @nlevel
			AND isnull(upbtotal.previousarrears,0) = 0
		 
		UPDATE upbtotal SET 
		currentarrears =
			(SELECT SUM(t2.currentarrears)
			FROM upbtotal t2
			JOIN fin F
				ON F.idfin = t2.idfin
			WHERE t2.currentarrears IS NOT NULL
				AND F.paridfin = upbtotal.idfin
				AND t2.idupb = upbtotal.idupb) 
		FROM fin
		WHERE fin.idfin = upbtotal.idfin
			AND fin.ayear = @ayear
			AND fin.nlevel = @nlevel
			AND isnull(upbtotal.currentarrears,0) = 0
	END
	PRINT 'iterazione ' + CONVERT(varchar(4),@nlevel)
	SET @nlevel = @nlevel - 1
END
	
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

