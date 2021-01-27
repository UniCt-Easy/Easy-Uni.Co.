
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoprestocc_impegni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoprestocc_impegni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE    PROCEDURE [rpt_compensoprestocc_impegni]
(	
	@ayear int, 
	@ycon  int, 
	@ncon  int
)
AS BEGIN
	
	
CREATE TABLE #contract_accounting
(
	expensephase 		varchar(60),
	ymov 			int,
	nmov 			int,
	adate 			datetime,
	description 		varchar(200),	
	codefin 		varchar(50),
	codeupb 		varchar(50),
	amount 			decimal(19,2) 
)

DECLARE @accountingphase tinyint
SELECT 	@accountingphase = expensephase 
FROM 	config 
WHERE 	ayear = ISNULL(@ayear,(SELECT MAX(ayear) FROM config))		
	
INSERT INTO #contract_accounting
(
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
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.adate,
	expense.description,
	fin.codefin,
	upb.codeupb,
	expenseyear_starting.amount
FROM expensecasualcontract
JOIN expense
	ON expense.idexp = expensecasualcontract.idexp
	AND expense.nphase = @accountingphase 
JOIN expensetotal expensetotal_firstyear
  	ON expensetotal_firstyear.idexp = expense.idexp
  	AND ((expensetotal_firstyear.flag & 2) <> 0 )
JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear_starting.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = expenseyear_starting.idupb
WHERE expensecasualcontract.ycon = @ycon
	AND expensecasualcontract.ncon = @ncon
	
INSERT INTO #contract_accounting
(
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
	pettycash.description,
	pettycashoperation.yoperation,
	pettycashoperation.noperation,
	pettycashoperation.adate,
	pettycashoperation.description,
	ISNULL(f2.codefin, fin.codefin),
	ISNULL(u2.codeupb,upb.codeupb),
	pettycashoperation.amount
FROM pettycashoperationcasualcontract
JOIN pettycashoperation
	ON pettycashoperation.idpettycash = pettycashoperationcasualcontract.idpettycash
	AND pettycashoperation.yoperation = pettycashoperationcasualcontract.yoperation
	AND pettycashoperation.noperation = pettycashoperationcasualcontract.noperation
JOIN pettycash 
	ON pettycash.idpettycash = pettycashoperation.idpettycash
LEFT OUTER JOIN expenseyear
	ON pettycashoperation.idexp = expenseyear.idexp
	AND expenseyear.ayear = pettycashoperation.yoperation
LEFT OUTER JOIN fin f2
	ON f2.idfin = expenseyear.idfin
LEFT OUTER JOIN upb u2
	ON u2.idupb = expenseyear.idupb
LEFT OUTER JOIN fin
	ON fin.idfin = pettycashoperation.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = pettycashoperation.idupb
WHERE 	pettycashoperationcasualcontract.ycon = @ycon
	AND pettycashoperationcasualcontract.ncon = @ncon

IF (@ayear IS NULL)
BEGIN
SELECT 
	@ycon as 'ycon',
	@ncon as 'ncon',
	expensephase,
	ymov,
	nmov,
	adate,
	description,
	codefin,
	codeupb,
	amount 
FROM 	#contract_accounting
ORDER BY adate, expensephase ASC,
	 ymov ASC,
	 nmov ASC
END
ELSE
BEGIN
SELECT 
	@ycon as 'ycon',
	@ncon as 'ncon',
	expensephase,
	ymov,
	nmov,
	adate,
	description,
	codefin,
	codeupb,
	amount 
FROM 	#contract_accounting
WHERE	ymov = @ayear
ORDER BY adate, expensephase ASC,
	ymov ASC,
	nmov ASC
END
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

