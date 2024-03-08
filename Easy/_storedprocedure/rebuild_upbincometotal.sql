
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_upbincometotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_upbincometotal]
GO

CREATE  PROCEDURE [rebuild_upbincometotal]
(
	@ayear int = null
)
AS BEGIN
DECLARE @arrearsphase tinyint
SELECT @arrearsphase = 1
SELECT @arrearsphase = incomefinphase FROM uniconfig

IF (@ayear IS NULL) 
BEGIN
	DELETE FROM upbincometotal
	INSERT INTO upbincometotal 
	(
		idupb, idfin, nphase,
		totalcompetency,
		totalarrears
	)
	SELECT 
		IY.idupb, F.idfin, I.nphase,
		ISNULL(
			(SELECT SUM(IT1.curramount)
			FROM incometotal IT1
			JOIN incomeyear IY1
				ON IY1.ayear = IT1.ayear
				AND IY1.idinc = IT1.idinc
			JOIN income I1
				ON I1.idinc = IT1.idinc
			JOIN finlink FL
				ON IY1.idfin = FL.idchild
			WHERE IY1.idupb = IY.idupb
				AND F.idfin = FL.idparent
				AND I1.nphase = I.nphase
				AND ((IT1.flag & 1) = 0))
		,0),
		ISNULL(
			(SELECT SUM(IT1.curramount)
			FROM incometotal IT1
			JOIN incomeyear IY1
				ON IY1.ayear = IT1.ayear
				AND IY1.idinc = IT1.idinc
			JOIN income I1
				ON I1.idinc = IT1.idinc
			JOIN finlink FL1
				ON IY1.idfin = FL1.idchild
			WHERE IY1.idupb = IY.idupb
				AND F.idfin = FL1.idparent
				AND I1.nphase = I.nphase
				AND ((IT1.flag & 1) = 1))
		,0)
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	LEFT OUTER JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN finlink 
		ON finlink.idchild = IY.idfin
	JOIN fin F
		ON finlink.idparent = F.idfin
	WHERE I.nphase >= @arrearsphase
		AND ((F.flag & 1) = 0)
	GROUP BY IY.idupb, F.idfin, I.nphase
END	
ELSE
BEGIN
	DELETE FROM upbincometotal WHERE EXISTS(SELECT fin.idfin FROM fin WHERE fin.idfin = upbincometotal.idfin
		AND fin.ayear = @ayear)

	INSERT INTO upbincometotal 
	(
		idupb,
		idfin,
		nphase,
		totalcompetency,
		totalarrears			
	)
	SELECT 
		IY.idupb,F.idfin,I.nphase,
		ISNULL(
			(SELECT SUM(IT1.curramount)
			FROM incometotal IT1
			JOIN incomeyear IY1
				ON IY1.ayear = IT1.ayear
				AND IY1.idinc = IT1.idinc
			JOIN income I1
				ON I1.idinc = IT1.idinc
			JOIN finlink FL
				ON IY1.idfin = FL.idchild
			WHERE IY1.idupb = IY.idupb
				AND F.idfin = FL.idparent
				AND I1.nphase = I.nphase
				AND ((IT1.flag & 1) = 0))
		,0),
		ISNULL(
			(SELECT SUM(IT1.curramount)
			FROM incometotal IT1
			JOIN incomeyear IY1
				ON IY1.ayear = IT1.ayear
				AND IY1.idinc = IT1.idinc
			JOIN income I1
				ON I1.idinc = IT1.idinc
			JOIN finlink FL1
				ON IY1.idfin = FL1.idchild
			WHERE IY1.idupb = IY.idupb
				AND F.idfin = FL1.idparent
				AND I1.nphase = I.nphase
				AND ((IT1.flag & 1) = 1))
		,0)
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	LEFT OUTER JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN finlink 
		ON finlink.idchild = IY.idfin
	JOIN fin F
		ON finlink.idparent = F.idfin
	WHERE I.nphase >= @arrearsphase
		AND F.ayear = @ayear
		AND IY.ayear = @ayear
		AND ((F.flag & 1) = 0)
	GROUP BY IY.idupb, F.idfin, I.nphase

END
	
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

