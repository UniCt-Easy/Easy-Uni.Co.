
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_impegni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_impegni]
GO

CREATE  PROCEDURE [rpt_missione_impegni]
(
	@ayear smallint,
	@yitineration smallint,
	@nitineration int
)
AS BEGIN

-- setuser 'amministrazione'
-- exec  rpt_missione_impegni 2018,2018,194
CREATE TABLE #itinerationyear
(
	yitineration smallint,
	nitineration int,
	expensephase varchar(50),
	ymov smallint,
	nmov int,
	adate smalldatetime,
	description varchar(200),
	codefin varchar(50),
	codeupb varchar(50),
	amount decimal(19,2)
)
DECLARE @itinerationphase tinyint
SELECT @itinerationphase = expensephase FROM config WHERE ayear = @ayear

DECLARE @iditineration int
SELECT  @iditineration=iditineration
	FROM itineration 
	WHERE yitineration = @yitineration AND nitineration = @nitineration



INSERT INTO #itinerationyear
(
	yitineration,
	nitineration,
	expensephase,
	ymov,
	nmov,
	adate,
	description,
	codefin,
	codeupb,
	amount
)
SELECT
	@yitineration,
	@nitineration,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.adate,
	expense.description,
	fin.codefin,
	upb.codeupb,
	expenseyear.amount
FROM expenseitineration
join itineration		on itineration.iditineration = expenseitineration.iditineration
JOIN expense			ON expense.idexp = expenseitineration.idexp
JOIN expenseyear		ON expenseyear.idexp = expenseitineration.idexp
JOIN expensephase		ON expensephase.nphase = expense.nphase
JOIN fin				ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb		ON upb.idupb = expenseyear.idupb
WHERE isnull(itineration.iditineration_ref,itineration.iditineration)=@iditineration 
	AND expenseitineration.movkind IN (4, 6)
	AND expense.nphase = @itinerationphase 
	AND expenseyear.ayear = @ayear

INSERT INTO #itinerationyear
(
	yitineration,
	nitineration,
	expensephase,
	ymov,
	nmov,
	adate,
	description,
	codefin,
	codeupb,
	amount
)
SELECT 
	@yitineration,
	@nitineration,	
	pettycash.description,
	pettycashoperation.yoperation,
	pettycashoperation.noperation,
	pettycashoperation.adate,
	pettycashoperation.description,
	ISNULL(f2.codefin, fin.codefin),
	ISNULL(u2.codeupb,upb.codeupb),
	pettycashoperation.amount
FROM pettycashoperationitineration
	join itineration on itineration.iditineration = pettycashoperationitineration.iditineration
JOIN pettycashoperation
	ON pettycashoperation.idpettycash = pettycashoperationitineration.idpettycash
	AND pettycashoperation.yoperation = pettycashoperationitineration.yoperation
	AND pettycashoperation.noperation = pettycashoperationitineration.noperation
JOIN pettycash 	ON pettycash.idpettycash = pettycashoperation.idpettycash
LEFT OUTER JOIN expenseyear 	ON pettycashoperation.idexp = expenseyear.idexp	AND expenseyear.ayear = @ayear
LEFT OUTER JOIN fin f2		ON f2.idfin = expenseyear.idfin
LEFT OUTER JOIN upb u2		ON u2.idupb = expenseyear.idupb
LEFT OUTER JOIN fin			ON fin.idfin = pettycashoperation.idfin
LEFT OUTER JOIN upb			ON upb.idupb = pettycashoperation.idupb
WHERE isnull(itineration.iditineration_ref,itineration.iditineration)=@iditineration 
	AND pettycashoperationitineration.movkind = 6

SELECT * 
FROM #itinerationyear
ORDER BY adate, expensephase ASC,
	ymov ASC,
	nmov ASC
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
