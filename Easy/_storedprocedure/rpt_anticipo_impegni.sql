
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_anticipo_impegni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_anticipo_impegni]
GO

CREATE  PROCEDURE [rpt_anticipo_impegni]
(
	@ayear smallint, 
	@yitineration smallint, 
	@nitineration int
)
AS BEGIN
declare @iditineration int
select @iditineration = iditineration from itineration where yitineration = @yitineration and nitineration = @nitineration

CREATE TABLE #itineration_appropriation
(
	ymov smallint,
	nmov int,
	yitineration smallint,
	nitineration int,
	codefin varchar(50),
	codeupb varchar(50),
	expensephase varchar(60),
	adate smalldatetime,
	description varchar(200),
	amount decimal(19,2)
)

DECLARE @itinerationphase varchar(20)
SELECT @itinerationphase = expensephase FROM config WHERE ayear = @ayear

INSERT INTO #itineration_appropriation
(
	ymov,	nmov,
	codefin,	codeupb,
	yitineration,	nitineration,
	expensephase,
	adate,
	description,
	amount
)
SELECT
	expense.ymov,	expense.nmov,
	fin.codefin,	upb.codeupb,
	@yitineration,	@nitineration,
	expensephase.description,
	expense.adate,
	expense.description,
	expenseyear.amount
FROM expenseitineration
join itineration
	on itineration.iditineration = expenseitineration.iditineration
JOIN expense
	ON expense.idexp = expenseitineration.idexp
	AND expense.nphase = @itinerationphase  
JOIN expenseyear
	ON expenseyear.idexp = expenseitineration.idexp
	AND expenseyear.ayear = @ayear
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = expenseyear.idupb
WHERE ISNULL(itineration.iditineration_ref, itineration.iditineration)= @iditineration
	AND expenseitineration.movkind IN (5, 6)
	
INSERT INTO #itineration_appropriation
(
	ymov,
	nmov,
	codefin,
	codeupb,
	yitineration,
	nitineration,
	expensephase,
	adate,
	description,
	amount
)
SELECT 
	pettycashoperation.yoperation,
	pettycashoperation.noperation,
	ISNULL(f2.codefin, fin.codefin),
	ISNULL(u2.codeupb,upb.codeupb),
	@yitineration,
	@nitineration,	
	pettycash.description,
	pettycashoperation.adate,
	pettycashoperation.description,
	pettycashoperation.amount
FROM pettycashoperationitineration
join itineration on itineration.iditineration = pettycashoperationitineration.iditineration
JOIN pettycashoperation
	ON pettycashoperation.idpettycash = pettycashoperationitineration.idpettycash
	AND pettycashoperation.yoperation = pettycashoperationitineration.yoperation
	AND pettycashoperation.noperation = pettycashoperationitineration.noperation
JOIN pettycash 
	ON pettycash.idpettycash = pettycashoperation.idpettycash
LEFT OUTER JOIN expenseyear
	ON pettycashoperation.idexp = expenseyear.idexp
	AND expenseyear.ayear = @ayear
LEFT OUTER JOIN fin f2
	ON f2.idfin = expenseyear.idfin
LEFT OUTER JOIN upb u2
	ON u2.idupb = expenseyear.idupb
LEFT OUTER JOIN fin
	ON fin.idfin = pettycashoperation.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = pettycashoperation.idupb
WHERE  ISNULL(itineration.iditineration_ref, itineration.iditineration)= @iditineration

SELECT 
	yitineration ,	nitineration ,	expensephase ,	
	ymov ,	nmov ,	adate ,	description ,	codefin ,
	codeupb ,amount 
FROM #itineration_appropriation
ORDER BY adate, expensephase ASC,
	ymov ASC,
	nmov ASC
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
