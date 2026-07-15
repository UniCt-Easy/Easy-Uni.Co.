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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payments_performed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payments_performed]
GO
--setuser 'amministrazione'
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec exp_payments_performed 2024, {d '2024-12-15'}, {d '2024-12-31'}, null, 'S'
CREATE    PROCEDURE [exp_payments_performed]
	@ayear 		int,
	@start 		datetime,
	@stop 		datetime,
	@idtreasurer int,
	@documentiesitati char(1) --Considera tutti i mandati e reversali dell'esercizio esitati nell'esercizio

AS BEGIN

DECLARE @cashvaliditykind tinyint
SELECT	@cashvaliditykind = cashvaliditykind
FROM 	config
WHERE 	ayear = @ayear

DECLARE @31dicCurr datetime
SET @31dicCurr = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear),105)

CREATE TABLE #journal
(
	ymov int,
	nmov int,
	adate datetime,
	amount decimal(19,2),
	amount_var decimal(19, 2),
	flagarrear char(1),
	ypay int,
	npay int,
	payment_adate datetime,
	competencydate datetime		
)

INSERT INTO #journal
(
	ymov,
	nmov,
	adate,
	amount,
	amount_var,
	flagarrear,
	ypay,
	npay,
	payment_adate,
	competencydate
)
SELECT
	HPV.ymov,
	HPV.nmov,
	HPV.adate,
	sum(HPV.amount),
	isnull(
		(select sum(EV.amount)
		FROM   expensevar EV
		JOIN historypaymentview HPV2 on HPV2.idexp = EV.idexp
		where EV.idexp = HPV.idexp
		and	EV.yvar = @ayear
		and HPV2.ymov = @ayear
		AND (HPV2.idtreasurer = @idtreasurer or @idtreasurer is null)
		AND (
		(HPV2.competencydate BETWEEN @start AND @stop
  			AND ( 
				((EV.autokind <> 11) AND(EV.autokind <> 10)) 
				OR EV.autokind is null
          		)
		)
		OR
		(EV.adate BETWEEN @start AND @stop
			AND ((EV.autokind = 11)OR(EV.autokind = 10 )) 
		) 
		)
		)
	,0),
	HPV.flagarrear,
	HPV.ypay,
	HPV.npay,
	p.adate,
	HPV.competencydate
FROM historypaymentview HPV
JOIN payment p on p.kpay = HPV.kpay
WHERE HPV.ymov = @ayear
	AND HPV.competencydate BETWEEN @start AND @stop
	AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)
GROUP BY HPV.ymov, HPV.nmov, HPV.adate, HPV.idexp, HPV.flagarrear, HPV.ypay, HPV.npay, p.adate, HPV.competencydate

if (@cashvaliditykind = 4 and @documentiesitati='S')
Begin
	WITH
	banktr (idexp, amount, transactiondate)  
	AS 
	(  
		SELECT idexp, SUM(amount)AS amount,  max(transactiondate) AS transactiondate  
		FROM banktransaction where idexp is not null
		GROUP BY idexp  
	)
	INSERT INTO #journal
	(
		ymov,
		nmov,
		adate,
		amount,
		amount_var,
		flagarrear,
		ypay,
		npay,
		payment_adate,
		competencydate
	)
	SELECT
		EL.ymov,
		EL.nmov,
		EL.adate,
		sum(EL.curramount),
		0,
		EL.flagarrear,
		p.ypay,
		p.npay,
		p.adate,
		banktr.transactiondate
	FROM expenselastview EL
	JOIN payment p ON p.kpay = EL.kpay 
	JOIN banktr on banktr.idexp = EL.idexp AND year(banktr.transactiondate) = @ayear + 1  
	WHERE EL.ymov = @ayear AND @stop >= @31dicCurr
		AND (p.idtreasurer = @idtreasurer or @idtreasurer is null)
	GROUP BY EL.ymov, EL.nmov, EL.adate, EL.flagarrear, p.ypay, p.npay, p.adate, banktr.transactiondate
End

IF @cashvaliditykind <> 4
BEGIN
	INSERT INTO #journal
	(
		ymov,
		nmov,
		adate,
		amount,
		amount_var,
		flagarrear,
		ypay,
		npay,
		payment_adate,
		competencydate
	)
	SELECT
		HPV.ymov,
		HPV.nmov,
		EV.adate,
		0,
		sum(EV.amount),
		HPV.flagarrear,
		HPV.ypay,
		HPV.npay,
		p.adate,
		HPV.competencydate
	FROM expensevar EV
	JOIN historypaymentview HPV ON HPV.idexp = EV.idexp AND HPV.ymov = @ayear
	JOIN payment p ON p.kpay = HPV.kpay
	WHERE EV.yvar = @ayear
	AND isnull(EV.autokind,'') <>'22' 
	AND (HPV.idtreasurer = @idtreasurer	or @idtreasurer is null)			
	AND (
		(HPV.competencydate BETWEEN @start AND @stop
	  	AND ( 
			((EV.autokind <> 10) AND(EV.autokind <> 11)) 
			OR EV.autokind is null
	        )
		)
		OR
		(EV.adate BETWEEN @start AND @stop
			AND ((EV.autokind = 10)OR(EV.autokind = 11)) 
		) 
	)
	GROUP BY HPV.ymov, HPV.nmov, EV.adate, HPV.flagarrear, HPV.ypay, HPV.npay, p.adate, HPV.competencydate
END

SELECT
	ymov as 'Esercizio Movimento',
	nmov as 'Numero Movimento',
	adate as 'Data Movimento',
	sum(amount) as 'Importo',
	sum(amount_var) as 'Variazioni',
	flagarrear as 'Tipo Movimento',
	ypay as 'Esercizio Mandato',
	npay as 'Numero Mandato',		
	payment_adate as 'Data Mandato',
	competencydate as 'Data Esitazione'
FROM #journal
GROUP BY ymov, nmov, adate, flagarrear, ypay, npay, payment_adate, competencydate
ORDER BY competencydate, npay


END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO