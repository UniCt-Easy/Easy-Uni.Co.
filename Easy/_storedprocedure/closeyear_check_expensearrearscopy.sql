
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_check_expensearrearscopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_check_expensearrearscopy]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amm'
-- setuser 'amministrazione'
-- exec closeyear_check_expensearrearscopy 2021

CREATE    PROCEDURE [closeyear_check_expensearrearscopy]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #errors (errordescr varchar(800))
DECLARE @minusablelevel tinyint
SELECT  @minusablelevel = MIN(nlevel) FROM finlevel WHERE ayear = @ayear AND flag&2 <> 0
DECLARE @paymentphase tinyint
SELECT  @paymentphase = MAX(nphase) FROM expensephase


INSERT INTO #errors
SELECT 'ATTRIBUZIONE SPESA(EXPENSEYEAR) senza corrispondente voce di bilancio nell''anno successivo ' 
+ F.codefin 
FROM expenseyear EY
join fin F ON EY.idfin=F.idfin
WHERE NOT EXISTS(SELECT * FROM finlookup FL WHERE FL.oldidfin=EY.idfin)
AND EY.ayear = @ayear

INSERT INTO #errors
SELECT 'ATTRIBUZIONE SPESA(EXPENSEYEAR) corrispondente a voce di bilancio articolata nell''anno successivo ' 
+ F.codefin 
FROM expenseyear EY
JOIN fin F ON EY.idfin=F.idfin
WHERE EXISTS	(SELECT * 
		FROM finlookup FL JOIN finlink FLI 
		ON FLI.idparent = FL.newidfin AND FLI.idparent <> FLI.idchild 
		WHERE FL.oldidfin=EY.idfin)
AND EY.ayear = @ayear

INSERT INTO #errors
SELECT 'ATTRIBUZIONE SPESA(EXPENSEYEAR) senza MOVIMENTO SPESA (expense) (incoerenza nel db, contattare il settore assistenza) ' 
+ CONVERT(varchar(20), expenseyear.idexp) 
FROM expenseyear 
WHERE NOT EXISTS(SELECT * FROM expense E1 WHERE E1.idexp=expenseyear.idexp)

INSERT INTO #errors
SELECT 'TOTALIZZATORE SPESA(EXPENSETOTAL) senza MOVIMENTO SPESA (expense) (incoerenza nel db, contattare il settore assistenza) ' 
+ CONVERT(varchar(20), expensetotal.idexp) 
FROM expensetotal 
WHERE NOT EXISTS(SELECT * FROM expense E1 WHERE E1.idexp=expensetotal.idexp)

INSERT INTO #errors
SELECT expensephase.description 
+ '(EXPENSE) senza ATTRIBUZIONE (EXPENSEYEAR) (incoerenza nel db, contattare il settore assistenza) ' 
+ CONVERT(varchar(4), expense.ymov) 
+ ' num. ' 
+ CONVERT(varchar(6), expense.nmov)
FROM expense
LEFT OUTER JOIN expensephase
	ON expense.nphase=expensephase.nphase
WHERE NOT EXISTS( SELECT * FROM expenseyear E1 WHERE E1.idexp=expense.idexp)

INSERT INTO #errors
SELECT expensephase.description
+ '(EXPENSE) senza TOTALIZZATORE  (EXPENSETOTAL) (incoerenza nel db, contattare il settore assistenza: bisogna fare il REBUILD) ' 
+ CONVERT(varchar(4), expense.ymov) 
+ ' num. ' 
+ CONVERT(varchar(6), expense.nmov)
FROM expense
LEFT OUTER JOIN expensephase
	ON expense.nphase=expensephase.nphase
WHERE NOT EXISTS(SELECT * FROM expensetotal E1 WHERE E1.idexp=expense.idexp)

INSERT INTO #errors
SELECT expensephase.description
+ ' con disponibile NEGATIVO ' 
+ CONVERT(varchar(4), expense.ymov) 
+ ' num. ' 
+ CONVERT(varchar(6), expense.nmov)
FROM expense LEFT OUTER JOIN expensephase on expense.nphase=expensephase.nphase
JOIN expensetotal
	ON expensetotal.idexp = expense.idexp
	AND expensetotal.ayear = @ayear
WHERE expensetotal.available<0


INSERT INTO #errors
SELECT expensephase.description
+ ' con importo corrente NEGATIVO ' 
+ CONVERT(varchar(4), expense.ymov) 
+ ' num. ' 
+ CONVERT(varchar(6), expense.nmov)
FROM expense
LEFT OUTER JOIN expensephase
	ON expense.nphase=expensephase.nphase
JOIN expensetotal
	ON expensetotal.idexp = expense.idexp
	AND expensetotal.ayear = @ayear
WHERE expensetotal.curramount<0

DECLARE @phasedescription varchar(50)
SELECT @phasedescription = description FROM expensephase WHERE nphase = @paymentphase

IF (upper(user) <> 'AMMINISTRAZIONE')
BEGIN
	INSERT INTO #errors
	SELECT 
	@phasedescription + ' senza mandato eserc. ' + CONVERT(varchar(4), expense.ymov) + 
	' num. ' + CONVERT(varchar(6), expense.nmov)
	FROM expense
	JOIN expenselast
	ON expense.idexp = expenselast.idexp
	JOIN expensetotal
		ON expensetotal.idexp = expense.idexp
	WHERE expense.nphase = @paymentphase
		AND expensetotal.ayear = @ayear
		AND expensetotal.curramount > 0
		AND expenselast.kpay IS NULL

	INSERT INTO #errors
	SELECT 
	'Mandato senza distinta di trasmissione eserc. ' + CONVERT(varchar(4), ypay) + 
	' num. ' + CONVERT(varchar(6), npay)
	FROM payment
	WHERE kpaymenttransmission IS NULL
		AND ypay = @ayear
		AND EXISTS(SELECT * FROM expenselast WHERE kpay = payment.kpay)
		AND payment.annulmentdate IS NULL
END

INSERT INTO #errors
SELECT 
f1.description + ' num. ' + CONVERT(varchar(20),s1.nmov) + ' è attribuito a voce di bilancio non operativa o articolata'
FROM expense s1
JOIN expenseyear i1
	ON s1.idexp = i1.idexp
JOIN expensetotal i2
	ON i1.idexp = i2.idexp
JOIN fin b1
	ON i1.idfin = b1.idfin
JOIN expensephase f1
	ON s1.nphase = f1.nphase
WHERE i1.ayear = @ayear 
AND (SELECT COUNT(finlast.idfin) 
	 FROM finlast 
	WHERE finlast.idfin = b1.idfin
	  AND b1.nlevel >= @minusablelevel
	  AND finlast.idfin is not null) = 0

 -- Cedolini calcolati ed impegnati nell'esercizio X o negli esercizi precedenti ma non pagati, sia competenza che residui
 INSERT INTO #errors
 SELECT 'Cedolino ' + convert(varchar(20), ce.idpayroll) + ' del contratto n. ' + convert(varchar(20), co.ncon) + ' dell''anno ' + convert(varchar(4), co.ycon) + 
 ' calcolato ed impegnato nell''esercizio  o in esercizi precedenti' + convert(varchar(4), @ayear) + ' ma non pagato.' +
 ' Decontabilizzare il cedolino e trasferirlo nell''esercizio successivo per ricalcolarlo.'
 
 FROM payroll ce 
	JOIN parasubcontract co						ON co.idcon = ce.idcon
    JOIN parasubcontractyear im					ON co.idcon = im.idcon
	join registry R on co.idreg = R.idreg
	WHERE ce.flagbalance = 'n'
		AND ce.fiscalyear = @ayear
		AND ce.disbursementdate is not null -- erogati
		and year(ce.disbursementdate) <= @ayear
		AND not EXISTS (SELECT payroll.idpayroll 
				from payroll 
				join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
				join expenselink ON expenselink.idparent = expensepayroll.idexp
				join expenselast on expenselast.idexp = expenselink.idchild
				--join payment on payment.kpay=expenselast.kpay
				where CE.idpayroll = payroll.idpayroll -- and payment.kpaymenttransmission is not null
				)

SELECT * FROM #errors
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

