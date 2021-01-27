
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_not_spread_prevision]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_not_spread_prevision]
GO

CREATE PROCEDURE exp_not_spread_prevision
(
	@ayear int
)
AS BEGIN
DECLARE @fin_kind tinyint

CREATE TABLE #fin
(
	codefin varchar(50),
	idupb varchar(36),
	fin varchar(150),
	prevision decimal(19,2),
	son_prevision decimal(19,2),
	secprevision decimal(19,2),
	son_secprevision decimal(19,2),
	finpart char(1)
)

SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear
DECLARE @min tinyint
DECLARE @max tinyint


SELECT @min = MIN(nlevel) FROM finlevel WHERE ayear = @ayear AND (flag&2)<>0 --flag relativo all'usabilità
SELECT @max = MAX(nlevel) FROM finlevel WHERE ayear = @ayear
IF (@min = @max) 
Begin
	SELECT
		null AS 'Cod. U.P.B.',
		null AS 'Denominazione U.P.B.',
		codefin AS 'Cod. Bilancio',
		fin AS 'Denominazione Bilancio',
		null AS 'Parte Bil.',
		prevision AS 'Prev. Iniziale Princ.',
		son_prevision AS 'Prev. Iniziale Princ. dei figli'
	FROM #fin

	RETURN
End

IF (@fin_kind = 3)
BEGIN
	INSERT INTO #fin
	(
		idupb,codefin, fin, finpart, 
		prevision, son_prevision, secprevision, son_secprevision
	)
	SELECT
		idupb, codefin, title, 
		CASE
			when (( F.flag & 1)=0) then 'E'
			when (( F.flag & 1)=1) then 'S'
		End,
		ISNULL(U.currentprev,0),
		ISNULL((SELECT SUM(U2.currentprev) FROM upbtotal U2
										JOIN fin F2
											ON U2.idfin = F2.idfin
										 WHERE F2.ayear = @ayear AND U2.idupb = U.idupb AND F2.paridfin = F.idfin),0), 
		ISNULL(U.currentsecondaryprev, 0),
		ISNULL((SELECT SUM(U2.currentsecondaryprev) FROM upbtotal U2
										JOIN fin F2
											ON U2.idfin = F2.idfin
										 WHERE F2.ayear = @ayear AND U2.idupb = U.idupb AND F2.paridfin = F.idfin),0)
	FROM upbtotal U
	JOIN fin F
		ON U.idfin = F.idfin
	WHERE F.ayear = @ayear
		AND F.nlevel BETWEEN @min AND (@max - 1)
		AND NOT EXISTS
			(SELECT idfin FROM finlast WHERE F.idfin = finlast.idfin)
	GROUP BY U.idupb, F.idfin, F.codefin, F.title,F.flag,U.currentprev,U.currentsecondaryprev
	HAVING ISNULL(U.currentprev,0) >
			ISNULL(
				(SELECT SUM(U2.currentprev) FROM upbtotal U2
										JOIN fin F2
											ON U2.idfin = F2.idfin
									 WHERE F2.ayear = @ayear AND U2.idupb = U.idupb AND F2.paridfin = F.idfin)
			,0)
			OR
			ISNULL(U.currentsecondaryprev,0) >
			ISNULL(
				(SELECT SUM(U2.currentsecondaryprev) FROM upbtotal U2
										JOIN fin F2
											ON U2.idfin = F2.idfin
										 WHERE F2.ayear = @ayear AND U2.idupb = U.idupb AND F2.paridfin = F.idfin)
			,0)
END

IF (@fin_kind = 1) OR (@fin_kind = 2)
BEGIN
	INSERT INTO #fin
	(
		idupb, codefin, fin, finpart,
		prevision, son_prevision
	)
	SELECT
		idupb, codefin, title, 
		CASE
			when (( F.flag & 1)=0) then 'E'
			when (( F.flag & 1)=1) then 'S'
		End, 
		ISNULL(U.currentprev,0),
		ISNULL((SELECT SUM(U2.currentprev) FROM upbtotal U2
										JOIN fin F2
											ON U2.idfin = F2.idfin
										 WHERE F2.ayear = @ayear AND U2.idupb = U.idupb AND F2.paridfin = F.idfin),0) 
	FROM upbtotal U
	JOIN fin F
		ON U.idfin = F.idfin
	WHERE F.ayear = @ayear
		AND F.nlevel BETWEEN @min AND (@max - 1)
		AND NOT EXISTS
			(SELECT idfin FROM finlast WHERE F.idfin = finlast.idfin)
	GROUP BY U.idupb, F.idfin, F.codefin, F.title,F.flag,U.currentprev
	HAVING ISNULL(U.currentprev,0) >
			ISNULL(
				(SELECT SUM(U2.currentprev) FROM upbtotal U2
										JOIN fin F2
											ON U2.idfin = F2.idfin
									 WHERE F2.ayear = @ayear AND U2.idupb = U.idupb AND F2.paridfin = F.idfin)
			,0)
END

IF (@fin_kind = 1) OR (@fin_kind = 2)
BEGIN
	SELECT
		upb.codeupb AS 'Cod. U.P.B.',
		upb.title AS 'Denominazione U.P.B.',
		codefin AS 'Cod. Bilancio',
		fin AS 'Denominazione Bilancio',
		CASE
			WHEN finpart = 'E' THEN 'Entrata'
			ELSE 'Spesa'
		END AS 'Parte Bil.',
		prevision AS 'Prev. Iniziale Princ.',
		son_prevision AS 'Prev. Iniziale Princ. dei figli'
	FROM #fin
	JOIN upb
		ON #fin.idupb = upb.idupb
END
ELSE
BEGIN
	SELECT
		upb.codeupb AS 'Cod. U.P.B.',
		upb.title AS 'Denominazione U.P.B.',
		codefin AS 'Cod. Bilancio',
		fin AS 'Denominazione Bilancio',
		CASE
			WHEN finpart = 'E' THEN 'Entrata'
			ELSE 'Spesa'
		END AS 'Parte Bil.',
		prevision AS 'Prev. Iniziale Princ.',
		son_prevision AS 'Prev. Iniziale Princ. dei figli',
		secprevision AS 'Prev. Iniziale Sec.',
		son_secprevision AS 'Prev. Iniziale Sec. dei figli'
	FROM #fin
	JOIN upb
		ON #fin.idupb = upb.idupb

END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




