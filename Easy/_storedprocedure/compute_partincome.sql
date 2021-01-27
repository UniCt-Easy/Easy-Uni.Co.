
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

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_partincome]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_partincome]
GO



CREATE            PROCEDURE [compute_partincome]
(
	@ayear int,
	@idinc int 
)
AS BEGIN
CREATE TABLE #partincome
(
	idfin int,
	codefin varchar(50),
	idupb varchar(36),
	codeupb varchar(50),
	description varchar(150),
	percentage float,
	amount decimal(19,2)
)
INSERT INTO #partincome (idfin, codefin, idupb, codeupb, description, percentage, amount)
SELECT
	P.idfinexpense, P.finexpensecode, I.idupb, I.codeupb,
	'Assegnazione ' + I.phase + ' eserc. ' + CONVERT(char(4), I.ymov) + ' n. ' + CONVERT(char(6), I.nmov),
	P.percentage, ROUND(I.unpartitioned * P.percentage, 2)
FROM incomeview I
JOIN partincomesetupview P
	ON P.idfinincome = I.idfin
WHERE idinc = @idinc
	AND ayear = @ayear
DECLARE @topartition decimal(19,2)
DECLARE @sum_partitioned decimal(19,2)
DECLARE @sum_percentage decimal(19,6)
SELECT @sum_partitioned = SUM(amount) FROM #partincome
SELECT @sum_percentage = SUM(percentage) FROM #partincome
IF (@sum_percentage = 1)
BEGIN
	SELECT @topartition = ISNULL(unpartitioned, 0) FROM incomeview
	WHERE idinc = @idinc 
		AND ayear = @ayear
	SELECT @sum_partitioned = SUM(amount) FROM #partincome
	UPDATE #partincome
	SET amount = amount + @topartition - @sum_partitioned
	WHERE idfin = (SELECT MAX(idfin) FROM #partincome)
END
SELECT idfin, codefin, idupb,codeupb, description, amount FROM #partincome ORDER BY idupb,idfin
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

