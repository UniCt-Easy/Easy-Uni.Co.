
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoparasub_impegni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoparasub_impegni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE   PROCEDURE [rpt_compensoparasub_impegni]
(
	@ayear smallint, 
	@ycon smallint, 
	@ncon int
)
AS BEGIN

DECLARE @expensephase tinyint
SELECT @expensephase = expensephase FROM config WHERE ayear = @ayear
			
SELECT
	@ycon,
	@ncon,
	payroll.npayroll,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.adate,
	expense.description,
	fin.codefin,
	upb.codeupb,
	expenseyear.amount
FROM expensepayroll
JOIN expense
	ON expense.idexp = expensepayroll.idexp
JOIN expenseyear
	ON expenseyear.idexp = expensepayroll.idexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = expenseyear.idupb
LEFT OUTER JOIN payroll
	ON payroll.idpayroll = expensepayroll.idpayroll
LEFT OUTER JOIN parasubcontract
	ON  parasubcontract.idcon = payroll.idcon
WHERE parasubcontract.ycon = @ycon
	AND parasubcontract.ncon = @ncon
	AND expense.nphase = @expensephase
	AND expenseyear.ayear = @ayear
ORDER BY expensephase.description ASC, expense.ymov ASC, expense.nmov ASC
END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

