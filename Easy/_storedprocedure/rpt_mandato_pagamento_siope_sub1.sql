
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_mandato_pagamento_siope_sub1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_mandato_pagamento_siope_sub1]
GO
--setuser'amm'
--	[rpt_mandato_pagamento_siope_sub1] 2019, 22
CREATE     PROCEDURE [rpt_mandato_pagamento_siope_sub1]
	@y int,
	@n int
AS
BEGIN
DECLARE @sorkind int
DECLARE @npos int

DECLARE @codesorkind_siopespese varchar(20)
SELECT  @codesorkind_siopespese  =  
CASE  
	WHEN  (@y<= 2006) THEN  'SIOPE'
	WHEN  (@y BETWEEN 2007 AND 2017) THEN  '07U_SIOPE'
	ELSE   'SIOPE_U_18'
END
print @codesorkind_siopespese
select @sorkind = idsorkind from sortingkind where codesorkind = @codesorkind_siopespese

SELECT  @npos  =  
CASE  
	WHEN  (@y<= 2006) THEN  2
	WHEN  (@y BETWEEN 2007 AND 2017) THEN  1
	ELSE   1
END

declare @sortcode varchar(20)
select @sortcode=sortcode 
FROM expensesorted
JOIN expense 
	ON expensesorted.idexp = expense.idexp
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON expenselast.kpay = payment.kpay
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE 	expensesorted.ayear = @y
	AND sorting.idsorkind = @sorkind
	AND payment.ypay = @y
	AND payment.npay = @n

IF (@sortcode is null)
 SELECT 	sorting.sortcode as sortcode,
	sorting.description as sort,
	sum(expenseyear.amount) as amount,
	null as uesiopecode,
	null as cofogmpcode
 FROM finsorting
 JOIN sorting 
	ON finsorting.idsor=sorting.idsor 
 JOIN expenseyear 
	ON finsorting.idfin=expenseyear.idfin	
 JOIN expense 
	ON expenseyear.idexp=expense.idexp 
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON expenselast.kpay = payment.kpay
JOIN expensetotal
	ON expense.idexp = expensetotal.idexp and ((expensetotal.flag & 2) = 1) 
WHERE payment.ypay = @y AND payment.npay = @n and sorting.idsorkind=@sorkind
GROUP BY sortcode,sorting.description
ORDER BY sortcode

ELSE

 SELECT 	
	SUBSTRING(sorting.sortcode,@npos,LEN(sorting.sortcode)) AS sortcode,
	sorting.description AS sort,
	SUM(expensesorted.amount) AS amount,
	expensesorted.values1 as uesiopecode,
	expensesorted.values2 as cofogmpcode
 FROM expensesorted
 JOIN expense 
	ON expensesorted.idexp = expense.idexp
 JOIN sorting
	ON sorting.idsor = expensesorted.idsor
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON expenselast.kpay = payment.kpay
 WHERE 	expensesorted.ayear = @y
	AND sorting.idsorkind = @sorkind -- Ipotesi fondamentale
	AND payment.ypay = @y
	AND payment.npay = @n
 GROUP BY sortcode,sorting.description, expensesorted.values1, expensesorted.values2
 ORDER BY sortcode

END

go
