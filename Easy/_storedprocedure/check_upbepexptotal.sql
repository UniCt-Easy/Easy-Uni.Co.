
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

if exists (select * from dbo.sysobjects where id = object_id(N'[check_upbepexptotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_upbepexptotal]
GO

--setuser 'amm' 
--check_upbepexptotal 2019

CREATE  PROCEDURE [check_upbepexptotal]
(
	@ayear int = null , @idupb varchar(36)='%'
)
AS BEGIN

CREATE TABLE #upbepexptotal(
	[idupb] [varchar](36) NOT NULL,
	[idacc] [varchar](38) NOT NULL,
	nphase tinyint not null,
	total [decimal](19, 2) NULL,
	total2 [decimal](19, 2) NULL,
	total3 [decimal](19, 2) NULL,
	total4 [decimal](19, 2) NULL,
	total5 [decimal](19, 2) NULL,

	
) 




if (@idupb <> '%') SET @idupb = @idupb + '%'
IF (@ayear IS NULL) 
BEGIN
	

	INSERT INTO #upbepexptotal 
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
	

INSERT INTO #upbepexptotal 
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
	




	
select isnull(u1.idacc,u2.idacc),isnull(u1.idupb,u2.idupb) , isnull(u1.nphase,u2.nphase),
			u1.total, u2.total,  
			u1.total2,u2.total2, 
			u1.total3,u2.total3 ,
			u1.total4,u2.total4 ,
			u1.total5,u2.total5 
			from #upbepexptotal U1 
			left outer join upbepexptotal  U2 on U1.idupb=U2.idupb and u1.idacc=u2.idacc and u1.nphase=u2.nphase
			where isnull(u1.total,0)<>isnull(u2.total,0) or
				isnull(u1.total2,0)<>isnull(u2.total2,0) or
				isnull(u1.total3,0)<>isnull(u2.total3,0) or
				isnull(u1.total4,0)<>isnull(u2.total4,0) or
				isnull(u1.total5,0)<>isnull(u2.total5,0) 

	



END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

