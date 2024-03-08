
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment_partially_performed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment_partially_performed]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--setuser 'amministrazione'
-- exec exp_payment_partially_performed {d '2023-12-19'}, 2023

CREATE  PROCEDURE [exp_payment_partially_performed]
@date smalldatetime,
@ayear  smallint
AS BEGIN

/* Versione 1.0.0 del 14/09/2007 ultima modifica: PIERO */

	SELECT p.ypay AS 'Esercizio Mandato',
	p.npay AS 'Numero Mandato',
	P.adate AS 'Data Mandato',
	SUM(ET.curramount) AS 'Importo totale' ,
	ISNULL(
		(SELECT SUM(pd.amount)
		FROM banktransaction pd
		WHERE pd.kpay = el.kpay
		AND pd.transactiondate <= @date)
	,0) AS 'Importo Esitato',
	(SUM(ET.curramount) -
	ISNULL(
		(SELECT SUM(pd.amount)
		FROM banktransaction pd
		WHERE pd.kpay = el.kpay
		AND pd.transactiondate <= @date)
	,0)) AS 'Importo Non Esitato',
	t.description as 'Cassiere'
	FROM expensetotal et 
	JOIN expense e
		ON et.idexp=e.idexp
	JOIN expenselast el
		ON el.idexp=e.idexp
	JOIN payment p
		ON  p.kpay = el.kpay
	JOIN paymenttransmission pt
		ON pt.kpaymenttransmission = p.kpaymenttransmission
	left join treasurer t on t.idtreasurer = p.idtreasurer
	WHERE pt.transmissiondate <= @date
		AND p.ypay = @ayear
	GROUP BY P.ypay,P.npay,P.adate,el.kpay, t.description
	HAVING ISNULL(SUM(ET.curramount),0)>0
		AND ISNULL(SUM(ET.curramount),0) - 
	ISNULL(
		(SELECT SUM(pd.amount)
		FROM banktransaction pd
		WHERE pd.kpay = el.kpay
		AND pd.transactiondate <= @date)
	,0) > 0
	AND
	ISNULL(
		(SELECT SUM(pd.amount)
		FROM banktransaction pd
		WHERE pd.kpay = el.kpay
		AND pd.transactiondate <= @date)
	,0) > 0
	

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

