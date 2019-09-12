if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_mandato_pagamento_siope_sub1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_mandato_pagamento_siope_sub1]
GO
--setuser'amm'
----[rpt_mandato_pagamento_siope_sub1] 2015, 2
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
	sum(expenseyear.amount) as amount
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
	SUM(expensesorted.amount) AS amount
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
 GROUP BY sortcode,sorting.description
 ORDER BY sortcode

END

go