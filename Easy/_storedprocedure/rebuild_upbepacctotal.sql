
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_upbepacctotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_upbepacctotal]
GO

CREATE  PROCEDURE [rebuild_upbepacctotal]
(
	@ayear int = null , @idupb varchar(36)='%'
)
AS BEGIN
SET @idupb = @idupb + '%'
IF (@ayear IS NULL) 
BEGIN
	DELETE FROM upbepacctotal WHERE idupb like @idupb

	INSERT INTO upbepacctotal 
	(
		idupb, idacc, nphase,
		total,total2,total3,total4,total5
	)
	SELECT 
		EY.idupb, F.idacc, E.nphase,			
		ISNULL(
			(SELECT SUM(EY1.amount)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase AND isnull(E1.flagvariation,'N')='N'	) 				
		,0) 
		-ISNULL(
			(SELECT SUM(EY1.amount)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase AND isnull(E1.flagvariation,'N')='S'	) 				
		,0) 

		+ ISNULL(
			(SELECT SUM(EV1.amount)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	) 				 				
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	) 				 				
		,0) ,

		ISNULL(
			(SELECT SUM(EY1.amount2)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	) 				
		,0) 
		-ISNULL(
			(SELECT SUM(EY1.amount2)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	) 				
		,0) 

		+ ISNULL(
			(SELECT SUM(EV1.amount2)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	) 				
		,0) 
		 -ISNULL(
			(SELECT SUM(EV1.amount2)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	) 				
		,0) ,

		ISNULL(
			(SELECT SUM(EY1.amount3)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase   AND isnull(E1.flagvariation,'N')='N'	) 				 				
		,0) 
		-ISNULL(
			(SELECT SUM(EY1.amount3)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase   AND isnull(E1.flagvariation,'N')='S'	) 				 				
		,0)
		+ ISNULL(
			(SELECT SUM(EV1.amount3)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase   AND isnull(E1.flagvariation,'N')='N'	) 			 				
		,0)
		 -ISNULL(
			(SELECT SUM(EV1.amount3)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase   AND isnull(E1.flagvariation,'N')='S'	) 			 				
		,0) ,


		ISNULL(
			(SELECT SUM(EY1.amount4)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)  				
		,0) 
		-ISNULL(
			(SELECT SUM(EY1.amount4)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)  				
		,0) 
		+ISNULL(
			(SELECT SUM(EV1.amount4)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)  				
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount4)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)  				
		,0) ,

		ISNULL(
			(SELECT SUM(EY1.amount5)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)  				
		,0) 
		- ISNULL(
			(SELECT SUM(EY1.amount5)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)  				
		,0) 
		+ISNULL(
			(SELECT SUM(EV1.amount5)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)  				
		,0) 
		-ISNULL(
			(SELECT SUM(EV1.amount5)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)  				
		,0) 
	FROM epaccyear EY
	JOIN epacc E
		ON E.idepacc = EY.idepacc
	LEFT OUTER JOIN epacctotal ET
		ON ET.idepacc = EY.idepacc
		AND ET.ayear = EY.ayear
	JOIN account F
				ON EY.idacc LIKE F.idacc+'%'
    WHERE EY.idupb like @idupb
	GROUP BY EY.idupb, F.idacc, E.nphase
END	
ELSE
BEGIN
	DELETE FROM upbepacctotal WHERE EXISTS(SELECT account.idacc FROM account WHERE account.idacc = upbepacctotal.idacc
		AND account.ayear = @ayear)AND idupb like @idupb

INSERT INTO upbepacctotal 
	(
		idupb, idacc, nphase,
		total,total2,total3,total4,total5
	)
	SELECT 
		EY.idupb, F.idacc, E.nphase,
		ISNULL(
			(SELECT SUM(EY1.amount)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)   				
		,0) 
		- ISNULL(
			(SELECT SUM(EY1.amount)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)   				
		,0) 
		+ 	ISNULL(
			(SELECT SUM(EV1.amount)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)   				
		,0) 
		-	ISNULL(
			(SELECT SUM(EV1.amount)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)   				
		,0) ,

		ISNULL(
			(SELECT SUM(EY1.amount2)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)   				
		,0) 
		- ISNULL(
			(SELECT SUM(EY1.amount2)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)   				
		,0) 
		+ ISNULL(
			(SELECT SUM(EV1.amount2)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)   				
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount2)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)   				
		,0),

		ISNULL(
			(SELECT SUM(EY1.amount3)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)  				
		,0) 
		-ISNULL(
			(SELECT SUM(EY1.amount3)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)  				
		,0) 
		+ ISNULL(
			(SELECT SUM(EV1.amount3)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)  				
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount3)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)  				
		,0),

		ISNULL(
			(SELECT SUM(EY1.amount4)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)   				
		,0) 
		- ISNULL(
			(SELECT SUM(EY1.amount4)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)   				
		,0) 
		+ ISNULL(
			(SELECT SUM(EV1.amount4)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)   				
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount4)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)   				
		,0),

		ISNULL(
			(SELECT SUM(EY1.amount5)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)   				
		,0)
		- ISNULL(
			(SELECT SUM(EY1.amount5)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)   				
		,0)
		 + 	ISNULL(
			(SELECT SUM(EV1.amount5)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='N'	)  				
		,0) 
		- ISNULL(
			(SELECT SUM(EV1.amount5)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase  AND isnull(E1.flagvariation,'N')='S'	)  				
		,0) 
		
	FROM epaccyear EY
	JOIN epacc E
		ON E.idepacc = EY.idepacc
	LEFT OUTER JOIN epacctotal ET
		ON ET.idepacc = EY.idepacc
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

