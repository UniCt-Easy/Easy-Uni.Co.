
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_mandato_pagamento_siope_subclasssup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_mandato_pagamento_siope_subclasssup]
GO



 
CREATE  PROCEDURE [rpt_mandato_pagamento_siope_subclasssup]
@y int,
@n int
AS
BEGIN
DECLARE @idsorkind int
DECLARE @codesorkind varchar(20)
SELECT  @codesorkind = paramvalue FROM reportadditionalparam
	WHERE   reportname = 'mandato_pagamento' AND paramname = 'ClassSup'
select  @idsorkind = idsorkind from sortingkind where codesorkind = @codesorkind
CREATE TABLE #sorting
(
	idsor int,
	sortcode varchar(20),
	sort varchar(200),
	amount decimal(19,2)
)
IF (@idsorkind IS NULL) OR (@idsorkind = 0)
BEGIN
	select sortcode,sort,NULL AS amount
	FROM #sorting
	RETURN
END
INSERT INTO #sorting
SELECT 	expensesorted.idsor,
	sorting.sortcode,
	sorting.description,
	expensesorted.amount
FROM expensesorted
JOIN expense 
	ON expensesorted.idexp = expense.idexp
JOIN expenselast
	ON expenselast.idexp = expense.idexp
JOIN payment
	ON expenselast.kpay = payment.kpay
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE expensesorted.ayear = @y
		AND sorting.idsorkind = @idsorkind
		AND payment.ypay = @y
		AND payment.npay = @n
SELECT sortcode,
	sort,
	SUM(amount) as amount
FROM #sorting
GROUP BY sortcode,sort
ORDER BY sortcode
END
go

