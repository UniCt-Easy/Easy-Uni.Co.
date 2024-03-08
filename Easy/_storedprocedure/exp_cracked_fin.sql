
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_cracked_fin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_cracked_fin]
GO

CREATE PROCEDURE exp_cracked_fin
(
	@ayear int,
	@finpart char(1)
)
AS BEGIN
DECLARE @fasebil tinyint
DECLARE @fin_kind tinyint
SELECT  @fin_kind = fin_kind FROM config WHERE ayear = @ayear

IF (@finpart = 'S')
BEGIN
	SELECT @fasebil = expensefinphase FROM uniconfig

	SELECT
	--	FY.idfin, FY.idupb, 
		'Spesa' AS 'Parte Bil.',
		U.codeupb AS 'Cod. U.P.B.',
		U.title AS 'U.P.B.',
		F.codefin AS 'Cod. Bilancio',
		F.title AS 'Bilancio',
		ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) AS 'Previsione Corrente', 
		ISNULL(UET.totalcompetency,0) +
		CASE
			WHEN @fin_kind in (1,3) THEN 0
			ELSE ISNULL(UET.totalarrears, 0)
		END AS 'Tot. Impegnato',
		ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) - ISNULL(UET.totalcompetency,0) 
		-
		CASE
			WHEN @fin_kind in (1,3) THEN 0
			ELSE ISNULL(UET.totalarrears, 0)
		END AS 'Previsione Disponibile'
	FROM finyear FY
	JOIN finlast FL 
		ON FL.idfin = FY.idfin 
	LEFT OUTER JOIN upbtotal UT 
		ON UT.idfin = FY.idfin
		AND UT.idupb = FY.idupb
	LEFT OUTER JOIN upbexpensetotal UET 
		ON UET.idfin = FY.idfin
		AND UET.idupb = FY.idupb
		AND UET.nphase = @fasebil
	JOIN fin F
		ON F.idfin = FY.idfin 
	JOIN upb U
		ON U.idupb = FY.idupb
	WHERE (ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) 
	- ISNULL(UET.totalcompetency,0) )  - 
	CASE
		WHEN @fin_kind in (1,3) THEN 0
		ELSE ISNULL(UET.totalarrears, 0)
	END
	< 0
	AND FY.ayear = @ayear
	AND (F.flag & 1) <> 0
END
ELSE -- @finpart = 'E'
BEGIN 
	SELECT @fasebil = incomefinphase FROM uniconfig

	SELECT
	--	FY.idfin, FY.idupb, 
		'Entrata' AS 'Parte Bil.',
		U.codeupb AS 'Cod. U.P.B.',
		U.title AS 'U.P.B.',
		F.codefin AS 'Cod. Bilancio',
		F.title AS 'Bilancio',
		ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) AS 'Previsione Corrente', 
		ISNULL(UIT.totalcompetency,0) + 
		CASE
			WHEN @fin_kind in (1,3) THEN 0
			ELSE ISNULL(UIT.totalarrears, 0)
		END AS 'Tot. Accertato',
		ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) - ISNULL(UIT.totalcompetency,0) -
		CASE
			WHEN @fin_kind  in (1,3) THEN 0
			ELSE ISNULL(UIT.totalarrears, 0)
		END AS 'Previsione Disponibile'
	FROM finyear FY 
	JOIN finlast FL 
		ON FL.idfin = FY.idfin 
	LEFT OUTER JOIN upbtotal UT 
		ON UT.idfin = FY.idfin
		AND UT.idupb = FY.idupb
	LEFT OUTER JOIN upbincometotal UIT 
		ON UIT.idfin = FY.idfin
		AND UIT.idupb = FY.idupb
		AND UIT.nphase = @fasebil
	JOIN fin F
		ON F.idfin = FY.idfin 
	JOIN upb U
		ON U.idupb = FY.idupb
	WHERE (ISNULL(UT.currentprev,0)+ISNULL(UT.previsionvariation,0) 
	- ISNULL(UIT.totalcompetency,0) ) -
	CASE
		WHEN @fin_kind  in (1,3) THEN 0
		ELSE ISNULL(UIT.totalarrears, 0)
	END < 0
	AND FY.ayear = @ayear
	AND (F.flag & 1) = 0
END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

