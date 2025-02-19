
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_upbepexptotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_upbepexptotal]
GO

CREATE  PROCEDURE [rebuild_upbepexptotal]
(
	@ayear int = null , @idupb varchar(36)='%'
)
AS BEGIN
if (@idupb <> '%') SET @idupb = @idupb + '%'
IF (@ayear IS NULL) 
BEGIN
	DELETE FROM upbepexptotal WHERE idupb like @idupb

	INSERT INTO upbepexptotal 
	(
		idupb, idacc, nphase,
		total,total2,total3,total4,total5
	)
	SELECT 
		EY.idupb, F.idacc, E.nphase,
		ISNULL(
			(SELECT SUM(EY1.amount)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase AND isnull(E1.flagvariation,'N')='N'	) 				
		,0) 
		- ISNULL(
			(SELECT SUM(EY1.amount)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase AND isnull(E1.flagvariation,'N')='S'	) 				
		,0) 
		+ ISNULL(
			(SELECT SUM(EV1.amount)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp			and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase AND isnull(E1.flagvariation,'N')='N'	) 				 				
		,0) 
		-  ISNULL(
			(SELECT SUM(EV1.amount)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp			and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase AND isnull(E1.flagvariation,'N')='S'	) 				 				
		,0),

		ISNULL(
			(SELECT SUM(EY2.amount2)
			FROM epexpyear EY2 				
			JOIN epexp E2					ON E2.idepexp = EY2.idepexp
			JOIN account FL					ON EY2.idacc LIKE FL.idacc+'%'
			WHERE EY2.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E2.nphase = E.nphase  AND isnull(E2.flagvariation,'N')='N'	) 				 				 				
		,0) 
		- ISNULL(
			(SELECT SUM(EY2.amount2)
			FROM epexpyear EY2 				
			JOIN epexp E2					ON E2.idepexp = EY2.idepexp
			JOIN account FL					ON EY2.idacc LIKE FL.idacc+'%'
			WHERE EY2.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E2.nphase = E.nphase  AND isnull(E2.flagvariation,'N')='S'	) 				 				 				
		,0) 
		+ ISNULL(
			(SELECT SUM(EV1.amount2)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase   AND isnull(E1.flagvariation,'N')='N'	) 				 				 				 				
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount2)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase   AND isnull(E1.flagvariation,'N')='A'	) 				 				 				 				
		,0),
		
		ISNULL(
			(SELECT SUM(EY1.amount3)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase    AND isnull(E1.flagvariation,'N')='N'	) 				 				 				 				 				
		,0) 
		 - ISNULL(
			(SELECT SUM(EY1.amount3)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase    AND isnull(E1.flagvariation,'N')='S'	) 				 				 				 				 				
		,0) 
		 + ISNULL(
			(SELECT SUM(EV1.amount3)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase    AND isnull(E1.flagvariation,'N')='N'	) 				 				 				 				 				
		,0) 
		 - ISNULL(
			(SELECT SUM(EV1.amount3)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase    AND isnull(E1.flagvariation,'N')='S'	) 				 				 				 				 				
		,0),

		ISNULL(
			(SELECT SUM(EY1.amount4)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='N'	)			
		,0)
		- ISNULL(
			(SELECT SUM(EY1.amount4)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='S'	)			
		,0)
		+ ISNULL(
			(SELECT SUM(EV1.amount4)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase 	    AND isnull(E1.flagvariation,'N')='N'	)			
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount4)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase 	    AND isnull(E1.flagvariation,'N')='S'	)			
		,0)		,


		ISNULL(
			(SELECT SUM(EY1.amount5)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='N'	) 				
		,0) 
		- ISNULL(
			(SELECT SUM(EY1.amount5)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='S'	) 				
		,0) 
		+ ISNULL(
			(SELECT SUM(EV1.amount5)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp			and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='N'	) 				
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount5)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp			and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='S'	) 				
		,0) 

	FROM epexpyear EY
	JOIN epexp E					ON E.idepexp = EY.idepexp
	LEFT OUTER JOIN epexptotal ET	ON ET.idepexp = EY.idepexp		AND ET.ayear = EY.ayear
	JOIN account F					ON EY.idacc LIKE F.idacc+'%'
	WHERE EY.idupb like @idupb
	GROUP BY EY.idupb, F.idacc, E.nphase
END	
ELSE
BEGIN
	DELETE FROM upbepexptotal WHERE EXISTS(SELECT account.idacc FROM account WHERE account.idacc = upbepexptotal.idacc
		AND account.ayear = @ayear) AND idupb like @idupb

INSERT INTO upbepexptotal 
	(
		idupb, idacc, nphase,
		total,total2,total3,total4,total5
	)
	SELECT 
		EY.idupb, F.idacc, E.nphase,
		ISNULL(
			(SELECT SUM(EY1.amount)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase AND isnull(E1.flagvariation,'N')='N'	) 				
		,0) 
		- ISNULL(
			(SELECT SUM(EY1.amount)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase AND isnull(E1.flagvariation,'N')='S'	) 				
		,0) 
		+ ISNULL(
			(SELECT SUM(EV1.amount)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp			and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase AND isnull(E1.flagvariation,'N')='N'	) 				 				
		,0) 
		-  ISNULL(
			(SELECT SUM(EV1.amount)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp			and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase AND isnull(E1.flagvariation,'N')='S'	) 				 				
		,0),

		ISNULL(
			(SELECT SUM(EY2.amount2)
			FROM epexpyear EY2 				
			JOIN epexp E2					ON E2.idepexp = EY2.idepexp
			JOIN account FL					ON EY2.idacc LIKE FL.idacc+'%'
			WHERE EY2.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E2.nphase = E.nphase  AND isnull(E2.flagvariation,'N')='N'	) 				 				 				
		,0) 
		- ISNULL(
			(SELECT SUM(EY2.amount2)
			FROM epexpyear EY2 				
			JOIN epexp E2					ON E2.idepexp = EY2.idepexp
			JOIN account FL					ON EY2.idacc LIKE FL.idacc+'%'
			WHERE EY2.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E2.nphase = E.nphase  AND isnull(E2.flagvariation,'N')='S'	) 				 				 				
		,0) 
		+ ISNULL(
			(SELECT SUM(EV1.amount2)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase   AND isnull(E1.flagvariation,'N')='N'	) 				 				 				 				
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount2)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase   AND isnull(E1.flagvariation,'N')='A'	) 				 				 				 				
		,0),
		
		ISNULL(
			(SELECT SUM(EY1.amount3)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase    AND isnull(E1.flagvariation,'N')='N'	) 				 				 				 				 				
		,0) 
		 - ISNULL(
			(SELECT SUM(EY1.amount3)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase    AND isnull(E1.flagvariation,'N')='S'	) 				 				 				 				 				
		,0) 
		 + ISNULL(
			(SELECT SUM(EV1.amount3)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase    AND isnull(E1.flagvariation,'N')='N'	) 				 				 				 				 				
		,0) 
		 - ISNULL(
			(SELECT SUM(EV1.amount3)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase    AND isnull(E1.flagvariation,'N')='S'	) 				 				 				 				 				
		,0),

		ISNULL(
			(SELECT SUM(EY1.amount4)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='N'	)			
		,0)
		- ISNULL(
			(SELECT SUM(EY1.amount4)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='S'	)			
		,0)
		+ ISNULL(
			(SELECT SUM(EV1.amount4)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase 	    AND isnull(E1.flagvariation,'N')='N'	)			
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount4)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp				and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase 	    AND isnull(E1.flagvariation,'N')='S'	)			
		,0)		,


		ISNULL(
			(SELECT SUM(EY1.amount5)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='N'	) 				
		,0) 
		- ISNULL(
			(SELECT SUM(EY1.amount5)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='S'	) 				
		,0) 
		+ ISNULL(
			(SELECT SUM(EV1.amount5)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp			and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='N'	) 				
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount5)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp			and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  	    AND isnull(E1.flagvariation,'N')='S'	) 				
		,0) 




	FROM epexpyear EY
	JOIN epexp E
		ON E.idepexp = EY.idepexp
	LEFT OUTER JOIN epexptotal ET
		ON ET.idepexp = EY.idepexp
		AND ET.ayear = EY.ayear
	JOIN account  F
				ON EY.idacc LIKE F.idacc+'%'
	where 
			F.ayear = @ayear
			AND EY.ayear = @ayear 
			AND EY.idupb like @idupb
	GROUP BY EY.idupb, F.idacc, E.nphase



END
	
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

