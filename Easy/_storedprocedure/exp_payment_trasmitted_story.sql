
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




if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment_trasmitted_story]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment_trasmitted_story]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE                     PROCEDURE [exp_payment_trasmitted_story]
@date datetime,
@ayear int
AS 
BEGIN

--exec exp_payment_trasmitted_story  {d '2023-06-24'},2023

SELECT  P.ypay  AS 'Esercizio Mandato',
	P.npay AS 'Numero Mandato',
	P.adate AS 'Data Mandato',
	SUM(EY.amount) 
	+ isnull((select sum(iv2.amount) from expensevar iv2 
				JOIN expenselast el2
					ON el2.idexp = iv2.idexp
				where iv2.idexp = el2.idexp 
						and el2.kpay = el.kpay
						and iv2.yvar = @ayear and iv2.adate <=@date),0)
	AS 'Importo totale',
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction B
		WHERE B.kpay = EL.kpay
		AND B.transactiondate <= @date)
	,0) AS 'Importo Esitato',
	(SUM(EY.amount) 
	+ isnull((select sum(iv2.amount) from expensevar iv2 
					JOIN expenselast el2
						ON el2.idexp = iv2.idexp
					where iv2.idexp = el2.idexp 
							and el2.kpay = el.kpay
							and iv2.yvar = @ayear and iv2.adate <=@date),0)
	-
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction B
		WHERE B.kpay = EL.kpay
		AND B.transactiondate <= @date)
	,0)) AS 'Importo Non Esitato'
FROM expenseyear Ey 
JOIN expense E 
	ON Ey.idexp = E.idexp  	AND Ey.ayear = @ayear
JOIN expenselast EL 
	ON EL.idexp = E.idexp  
JOIN payment P 
	ON P.kpay = EL.kpay
JOIN paymenttransmission pt
	ON PT.kpaymenttransmission = P.kpaymenttransmission
WHERE P.ypay = @ayear
	AND PT.transmissiondate <= @date
	AND PT.ypaymenttransmission = @ayear
GROUP BY P.ypay,P.npay,P.adate,EL.kpay 
having 	(SUM(EY.amount) 
	+ isnull((select sum(iv2.amount) from expensevar iv2 
					JOIN expenselast el2
						ON el2.idexp = iv2.idexp
					where iv2.idexp = el2.idexp 
							and el2.kpay = el.kpay
							and iv2.yvar = @ayear and iv2.adate <=@date),0)
							)>0
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

