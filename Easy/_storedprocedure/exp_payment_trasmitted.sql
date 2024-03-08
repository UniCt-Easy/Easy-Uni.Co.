
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment_trasmitted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment_trasmitted]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
--setuser 'amministrazione'
-- exec exp_payment_trasmitted {d '2023-12-19'}, 2023

CREATE                     PROCEDURE [exp_payment_trasmitted]
@date datetime,
@ayear int
AS 
BEGIN
/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */
SELECT  P.ypay  AS 'Esercizio Mandato',
	P.npay AS 'Numero Mandato',
	P.adate AS 'Data Mandato',
	SUM(ET.curramount) AS 'Importo totale',
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction B
		WHERE B.kpay = EL.kpay
		AND B.transactiondate <= @date)
	,0) AS 'Importo Esitato',
	(SUM(ET.curramount) -
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction B
		WHERE B.kpay = EL.kpay
		AND B.transactiondate <= @date)
	,0)) AS 'Importo Non Esitato',
	t.description as 'Cassiere'
FROM expensetotal ET 
JOIN expense E 
	ON ET.idexp = E.idexp  	AND ET.ayear = @ayear
JOIN expenselast EL 
	ON EL.idexp = E.idexp  
JOIN payment P 
	ON P.kpay = EL.kpay
JOIN paymenttransmission pt
	ON PT.kpaymenttransmission = P.kpaymenttransmission
left join treasurer t on t.idtreasurer = P.idtreasurer
WHERE P.ypay = @ayear
	AND PT.transmissiondate <= @date
	AND PT.ypaymenttransmission = @ayear
GROUP BY P.ypay,P.npay,P.adate,EL.kpay, t.description
HAVING ISNULL(SUM(ET.curramount),0)>0 
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

