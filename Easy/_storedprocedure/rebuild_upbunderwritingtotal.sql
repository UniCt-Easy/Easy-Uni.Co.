
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_upbunderwritingtotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_upbunderwritingtotal]
GO


CREATE     PROCEDURE [rebuild_upbunderwritingtotal]
(
	@ayear int = null
)
AS BEGIN

IF (@ayear IS NULL) 
BEGIN
	DELETE FROM upbunderwritingtotal

	
	INSERT INTO upbunderwritingtotal (idfin, idupb, idunderwriting, 
				currentprev,currentsecondaryprev,
				previsionvariation, previsionvariation_inserted,
				secondaryvariation, creditvariation, proceedsvariation) 
	SELECT  F.idfin, D.idupb, D.idunderwriting, 
				sum( case when V.flagprevision='S' and V.idfinvarstatus = 5 and V.variationkind = 5 then D.amount else 0 end),
				sum( case when V.flagsecondaryprev='S' and V.idfinvarstatus = 5 and V.variationkind = 5 then D.amount else 0 end),
				sum( case when V.flagprevision='S' and V.idfinvarstatus = 5 and V.variationkind <> 5 then D.amount else 0 end),
				sum( case when V.flagprevision='S' and V.variationkind <> 5 then D.amount else 0 end),
				sum( case when V.flagsecondaryprev='S' and V.idfinvarstatus = 5 and V.variationkind <> 5 then D.amount else 0 end),
				sum( case when V.flagcredit='S' and V.idfinvarstatus = 5 AND F.flag&1<>0 and V.variationkind <> 5 then D.amount else 0 end),
				sum( case when V.flagproceeds='S' and V.idfinvarstatus = 5 AND F.flag&1<>0 and V.variationkind <> 5 then D.amount else 0 end)
		from finvardetail D 
			join finvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
			join finlink FL ON FL.idchild=D.idfin
			join fin F ON F.idfin=FL.idparent
			where (V.idfinvarstatus = 5  or   V.idfinvarstatus = 4)
					AND D.idunderwriting IS NOT NULL
	group by F.idfin, D.idupb, D.idunderwriting


	
	
	INSERT INTO upbunderwritingtotal (idfin, idupb, idunderwriting, 
				previsionvariation,previsionvariation_inserted, secondaryvariation, creditvariation, proceedsvariation)
	SELECT DISTINCT F.idfin, IY.idupb, I.idunderwriting,0,0,0,0,0
		
	FROM fin F
	JOIN finlink FL
		ON FL.idparent = F.idfin
	JOIN incomeyear IY
		ON IY.idfin = FL.idchild
	JOIN income I
		ON IY.idinc = I.idinc
		AND I.idunderwriting IS NOT NULL
	WHERE NOT EXISTS
		(SELECT upbunderwritingtotal.idfin FROM upbunderwritingtotal
		WHERE upbunderwritingtotal.idfin = F.idfin AND 
			  upbunderwritingtotal.idupb = IY.idupb AND 
			  upbunderwritingtotal.idunderwriting = I.idunderwriting)
	

	INSERT INTO upbunderwritingtotal (idfin, idupb,idunderwriting)
	SELECT DISTINCT CP.idfin, CP.idupb,I.idunderwriting
	FROM creditpart CP
	JOIN fin
		ON fin.idfin = CP.idfin
	JOIN income I
		ON I.idinc = CP.idinc
		AND I.idunderwriting IS NOT NULL
	WHERE NOT EXISTS(SELECT U.idfin FROM upbunderwritingtotal U 
							WHERE U.idfin = CP.idfin AND U.idupb = CP.idupb AND U.idunderwriting = I.idunderwriting)
	

	INSERT INTO upbunderwritingtotal (idfin, idupb,idunderwriting)
	SELECT DISTINCT PP.idfin, PP.idupb,I.idunderwriting
	FROM proceedspart PP
	JOIN fin
		ON fin.idfin = PP.idfin
	JOIN income I
		ON I.idinc = PP.idinc
		AND I.idunderwriting IS NOT NULL
	WHERE NOT EXISTS(SELECT U.idfin FROM upbunderwritingtotal U 
						WHERE U.idfin = PP.idfin AND U.idupb = PP.idupb AND U.idunderwriting = I.idunderwriting)

	UPDATE upbunderwritingtotal 
	SET
	totcreditpart =
	(
		SELECT SUM(creditpart.amount)
		FROM creditpart
		JOIN income 
			ON income.idinc = creditpart.idinc
			AND income.idunderwriting IS NOT NULL
		WHERE creditpart.idfin = upbunderwritingtotal.idfin
			AND creditpart.idupb = upbunderwritingtotal.idupb
			AND income.idunderwriting = upbunderwritingtotal.idunderwriting
	)
	
	UPDATE upbunderwritingtotal 
	SET totproceedspart =
	(
		SELECT SUM(proceedspart.amount)
		FROM proceedspart
		JOIN income 
			ON income.idinc = proceedspart.idinc
			AND income.idunderwriting IS NOT NULL
		WHERE proceedspart.idfin = upbunderwritingtotal.idfin
		AND proceedspart.idupb = upbunderwritingtotal.idupb
		AND income.idunderwriting = upbunderwritingtotal.idunderwriting
	)

			
	--------------------------------------------------------------------------------
	--------------------------------------------------------------------------------
	--------------------------------------------------------------------------------
	
END
ELSE -- @ayear specificato
BEGIN 
	DELETE FROM upbunderwritingtotal WHERE 
				EXISTS(SELECT fin.idfin FROM fin WHERE fin.idfin = upbunderwritingtotal.idfin AND fin.ayear = @ayear)

	INSERT INTO upbunderwritingtotal (idfin, idupb, idunderwriting, 
				currentprev,currentsecondaryprev,
				previsionvariation,  previsionvariation_inserted,
				secondaryvariation, creditvariation, proceedsvariation) 
	SELECT  F.idfin, D.idupb, D.idunderwriting, 
				sum( case when V.flagprevision='S' and V.idfinvarstatus = 5 and V.variationkind = 5 then D.amount else 0 end),
				sum( case when V.flagsecondaryprev='S' and V.idfinvarstatus = 5 and V.variationkind = 5 then D.amount else 0 end),
				sum( case when V.flagprevision='S' and V.idfinvarstatus = 5 and V.variationkind <> 5 then D.amount else 0 end),
				sum( case when V.flagprevision='S' and V.variationkind <> 5 then D.amount else 0 end),
				sum( case when V.flagsecondaryprev='S' and V.idfinvarstatus = 5 and V.variationkind <> 5 then D.amount else 0 end),
				sum( case when V.flagcredit='S' and V.idfinvarstatus = 5 AND F.flag&1<>0 and V.variationkind <> 5 then D.amount else 0 end),
				sum( case when V.flagproceeds='S' and V.idfinvarstatus = 5  AND F.flag&1<>0 and V.variationkind <> 5 then D.amount else 0 end)
		from finvardetail D 
			join finvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
			join finlink FL ON FL.idchild=D.idfin
			join fin F ON F.idfin=FL.idparent
			where (V.idfinvarstatus = 5  or   V.idfinvarstatus = 4)
					AND D.idunderwriting IS NOT NULL	AND F.ayear = @ayear
	group by F.idfin, D.idupb, D.idunderwriting

		
	INSERT INTO upbunderwritingtotal (idfin, idupb, idunderwriting, 
					previsionvariation, previsionvariation_inserted, secondaryvariation, creditvariation, proceedsvariation)
	SELECT DISTINCT F.idfin, IY.idupb,I.idunderwriting,0,0,0,0,0
	FROM fin F
	JOIN finlink FL
		ON FL.idparent = F.idfin
	JOIN incomeyear IY
		ON IY.idfin = FL.idchild
	JOIN income I
		ON IY.idinc = I.idinc
		AND I.idunderwriting IS NOT NULL
	WHERE F.ayear = @ayear
	AND NOT EXISTS
		(SELECT upbunderwritingtotal.idfin FROM upbunderwritingtotal
		WHERE upbunderwritingtotal.idfin = F.idfin AND 
		upbunderwritingtotal.idupb = IY.idupb AND 
		upbunderwritingtotal.idunderwriting = I.idunderwriting)


	INSERT INTO upbunderwritingtotal (idfin, idupb,idunderwriting)

	SELECT DISTINCT CP.idfin, CP.idupb,I.idunderwriting
	FROM creditpart CP
	JOIN income I
		ON I.idinc = CP.idinc
		AND I.idunderwriting IS NOT NULL
	JOIN fin
		ON fin.idfin = CP.idfin
	WHERE NOT EXISTS(SELECT U.idfin FROM upbunderwritingtotal U 
					  WHERE U.idfin = CP.idfin AND U.idupb = CP.idupb
					    AND U.idunderwriting = I.idunderwriting)
		AND fin.ayear = @ayear

	INSERT INTO upbunderwritingtotal (idfin, idupb,idunderwriting)
	SELECT DISTINCT PP.idfin, PP.idupb,I.idunderwriting
	FROM proceedspart PP
	JOIN income I
		ON I.idinc = PP.idinc
		AND I.idunderwriting IS NOT NULL
	JOIN fin
		ON fin.idfin = PP.idfin
	WHERE NOT EXISTS(SELECT U.idfin FROM upbunderwritingtotal U 
					  WHERE U.idfin = PP.idfin AND U.idupb = PP.idupb
					    AND U.idunderwriting = I.idunderwriting)
		AND fin.ayear = @ayear

	UPDATE upbunderwritingtotal 
	SET
	totcreditpart =
	(
		SELECT SUM(creditpart.amount)
		FROM creditpart
		JOIN income ON income.idinc = creditpart.idinc
		AND income.idunderwriting IS NOT NULL
		WHERE creditpart.idfin = upbunderwritingtotal.idfin
		AND creditpart.idupb = upbunderwritingtotal.idupb
		AND income.idunderwriting = upbunderwritingtotal.idunderwriting
	)
	FROM fin WHERE fin.idfin = upbunderwritingtotal.idfin AND fin.ayear = @ayear

	UPDATE upbunderwritingtotal 
	SET totproceedspart =
	(
		SELECT SUM(proceedspart.amount)
		FROM proceedspart
		JOIN income ON income.idinc = proceedspart.idinc
		AND income.idunderwriting IS NOT NULL
		WHERE proceedspart.idfin = upbunderwritingtotal.idfin
		AND proceedspart.idupb = upbunderwritingtotal.idupb
		AND income.idunderwriting = upbunderwritingtotal.idunderwriting
	)
	FROM fin WHERE fin.idfin = upbunderwritingtotal.idfin AND fin.ayear = @ayear



	
END

	
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

