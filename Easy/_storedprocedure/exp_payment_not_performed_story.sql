/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment_not_performed_story]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment_not_performed_story]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--setuser 'amministrazione'
-- exec exp_payment_not_performed_story {d '2022-09-30'}, 2022

-- ELENCO MANDATI NON ESITATI
CREATE                          PROCEDURE [exp_payment_not_performed_story]
@date datetime,  -- data in cui si effettua l'interrogazione
@ayear  int 	 -- anno dei mandati da controllare
AS 
BEGIN
SELECT  P.ypay AS 'Esercizio Mandato',
	P.npay AS 'Numero Mandato',
	P.adate AS 'Data Mandato',
	E.nmov AS 'Num. Movimento',
	E.description AS Descrizione,
	r.title AS Percipiente,
	(SUM(EY.amount) 
	+ isnull((select sum(iv2.amount) from expensevar iv2 
					JOIN expenselast el2
						ON el2.idexp = iv2.idexp
						join expense e2 ON EL2.idexp = E2.idexp  
					where iv2.idexp = el2.idexp 
							and el2.kpay = el.kpay
							and e2.nmov = e.nmov
							and iv2.yvar = @ayear and iv2.adate <=@date),0)
	-
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction B
		WHERE B.kpay = EL.kpay
		AND B.transactiondate <= @date)
	,0)) AS Importo,
	t.description as 'Conto Corrente'
FROM expenseyear EY 
JOIN expense E 
	ON EY.idexp = E.idexp  	AND EY.ayear = @ayear
JOIN expenselast EL 
	ON EL.idexp = E.idexp 
JOIN payment P
	ON EL.kpay = P.kpay
JOIN paymenttransmission PT
	ON PT.kpaymenttransmission = P.kpaymenttransmission
left join treasurer t on t.idtreasurer = P.idtreasurer
LEFT JOIN registry r ON r.idreg = E.idreg
WHERE (EY.ayear IS NULL OR p.ypay = @ayear)
	AND PT.transmissiondate <= @date
	AND
		ISNULL((SELECT SUM(amount)from banktransaction PD
		where PD.kpay=P.kpay and
		PD.transactiondate <= @date),0) =0
GROUP BY P.ypay,P.npay,P.adate,EL.kpay, E.nmov, E.description, r.title, t.description
ORDER BY P.ypay,P.npay,E.nmov
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

