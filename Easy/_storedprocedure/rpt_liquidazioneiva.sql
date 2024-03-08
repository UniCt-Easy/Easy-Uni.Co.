
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_liquidazioneiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure rpt_liquidazioneiva
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE rpt_liquidazioneiva
(
	@ayear int,
	@number int,
	@official char(1)
)
AS BEGIN

-- exec rpt_liquidazioneiva 2010,2 ,'N'
CREATE TABLE #ivapayed
(
	idivapayperiodicity varchar(50),
	yivapay int,
	nivapay int,
	start datetime,
	stop datetime,
	description varchar(50),
	motive varchar(50),
	debitamount decimal(19,2),
	debitamountdeferred decimal(19,2),
	creditamount decimal(19,2),
	creditamountdeferred decimal(19,2),
	previouscredit decimal(19,2),
	previousdebit decimal(19,2),
	currentcredit decimal(19,2),
	currentdebit decimal(19,2),
	refundamount decimal(19,2),
	paymentamount decimal(19,2),
	paymentdetails varchar(150),
	prorata float,
	iva decimal(19,2),
	ivadeferred decimal(19,2),
	unabatable decimal(19,2), 
	unabatabledeferred decimal(19,2)
)
DECLARE @idivapayperiodicity varchar(50)
SELECT @idivapayperiodicity = ivapayperiodicity.description
FROM config
JOIN ivapayperiodicity
	ON config.idivapayperiodicity = ivapayperiodicity.idivapayperiodicity
WHERE config.ayear = @ayear

DECLARE @start_period datetime
DECLARE @stop_period datetime
DECLARE @paymentdetails varchar(150)
DECLARE @prorata float
DECLARE @refundamount decimal(19,2)
DECLARE @paymentamount decimal(19,2)
DECLARE @flag tinyint
SELECT @start_period = start,
	@stop_period = stop,
	@paymentdetails = paymentdetails,
	@prorata = prorata * 100,
	@refundamount = ISNULL(refundamount, 0),
	@paymentamount = ISNULL(paymentamount, 0),
	@flag = ISNULL(flag,3)
FROM ivapay
WHERE yivapay = @ayear
	AND nivapay = @number

DECLARE @saldo_iniziale decimal (19,2)
SELECT @saldo_iniziale = ISNULL(-startivabalance,0) from config where ayear = @ayear

DECLARE @prev_debitcredit decimal(19,2)
SELECT
	 @prev_debitcredit = ISNULL(SUM(totaldebit),0) - ISNULL(SUM(paymentamount),0)  -  ISNULL(SUM(totalcredit),0) + ISNULL(SUM(refundamount),0)
FROM ivapay
WHERE yivapay = @ayear
	AND nivapay < @number

-- Ora il saldo precedente viene memorizzato e quindi letto direttamente dalla tabella.
-- ove non memorizzato, per i dati pregressi, continuiamo a calcolarlo.
DECLARE @saldo_precedente decimal (19,2)
select @saldo_precedente = prev_debit from ivapay where yivapay = @ayear AND nivapay = @number
if (@saldo_precedente is null)
Begin
	SET @saldo_precedente = @saldo_iniziale + @prev_debitcredit
End

DECLARE @prevcredit decimal(19,2)
DECLARE @prevdebit decimal(19,2)
IF @saldo_precedente > 0
BEGIN
	SET @prevdebit = @saldo_precedente
	SET @prevcredit = 0 
END
ELSE
BEGIN
	SET @prevdebit = 0
	SET @prevcredit = - @saldo_precedente 
END

INSERT INTO #ivapayed
(
	idivapayperiodicity,
	yivapay,
	nivapay,
	start,
	stop,
	description,
	motive,
	debitamount,
	debitamountdeferred,
	previouscredit,
	previousdebit,
	paymentdetails
)
SELECT 
	@idivapayperiodicity,
	@ayear,
	@number,
	@start_period,
	@stop_period,
	ivaregisterkind.description,
	'IVA esigibile su vendite',
	ISNULL(ivapaydetail.ivanet,0),
	ISNULL(ivapaydetail.ivanetdeferred,0),
	@prevcredit,
	@prevdebit,
	@paymentdetails
FROM ivapaydetail
JOIN ivaregisterkind
	ON ivapaydetail.idivaregisterkind = ivaregisterkind.idivaregisterkind
WHERE ivaregisterkind.registerclass = 'V' AND flagactivity <> 1
	AND ivapaydetail.yivapay = @ayear
	AND ivapaydetail.nivapay = @number
	AND (ISNULL(ivapaydetail.ivanet,0) <> 0 OR ISNULL(ivapaydetail.ivanetdeferred,0) <> 0)

INSERT INTO #ivapayed
(
	idivapayperiodicity,
	yivapay,
	nivapay,
	start,
	stop,
	description,
	motive,
	creditamount,
	creditamountdeferred,
	previouscredit,
	previousdebit,
	paymentdetails,
	iva,
	ivadeferred,
	unabatable, 
	unabatabledeferred
)
SELECT
	@idivapayperiodicity,
	@ayear,
	@number,
	@start_period,
	@stop_period,
	ivaregisterkind.description,
	'IVA detraibile su acquisti',
	ISNULL(ivapaydetail.ivanet,0),
	ISNULL(ivapaydetail.ivanetdeferred,0),
	@prevcredit,
	@prevdebit,
	@paymentdetails,
	ISNULL(ivapaydetail.iva,0),
	ISNULL(ivapaydetail.ivadeferred,0),
	ISNULL(ivapaydetail.unabatable,0),
	ISNULL(ivapaydetail.unabatabledeferred,0)
FROM ivapaydetail
JOIN ivaregisterkind
	ON ivapaydetail.idivaregisterkind = ivaregisterkind.idivaregisterkind
WHERE ivaregisterkind.registerclass = 'A' AND flagactivity <> 1
	AND ivapaydetail.yivapay = @ayear
	AND ivapaydetail.nivapay = @number
	AND (ISNULL(ivapaydetail.ivanet,0) <> 0 OR ISNULL(ivapaydetail.ivanetdeferred,0) <> 0)

DECLARE @pre_credittotal decimal(19,2)
SELECT @pre_credittotal = ISNULL(SUM(iva), 0) - ISNULL(SUM(unabatable),0) + ISNULL(SUM(ivadeferred),0) - ISNULL(SUM(unabatabledeferred),0)
FROM #ivapayed 

DECLARE @credittotal decimal(19,2) -- Somma dell'IVA detraibile dopo l'applicazione prorata/promuscuo
DECLARE @debittotal decimal(19,2) -- Somma dell'IVA esigibile

SELECT @credittotal = ISNULL(SUM(creditamount), 0) + ISNULL(SUM(creditamountdeferred),0),
	   @debittotal = ISNULL(SUM(debitamount), 0) + ISNULL(SUM(debitamountdeferred),0)
FROM #ivapayed

DECLARE @currentcredit decimal(19,2)
DECLARE @currentdebit decimal(19,2)

-- In currentcredit e currentdebit sono memorizzati i saldi correnti, valorizzando il maggiore fra essi "crediti - debiti" o viceversa

IF @prevcredit + @credittotal >= @prevdebit + @debittotal
Begin
	SET @currentcredit = ISNULL(@prevcredit, 0) + ISNULL(@credittotal, 0) - ISNULL(@debittotal, 0) - @prevdebit
	SET @currentdebit = 0
End
ELSE
Begin
	SET @currentcredit = 0
	SET @currentdebit = ISNULL(@prevdebit, 0) + ISNULL(@debittotal, 0) - ISNULL(@credittotal, 0) -ISNULL(@prevcredit, 0)
End 

UPDATE #ivapayed
SET currentcredit = @currentcredit,
currentdebit = @currentdebit,
refundamount = @refundamount,
paymentamount = @paymentamount,
prorata = @prorata

SELECT
	idivapayperiodicity,
	yivapay,
	nivapay,
	start,
	stop,
	description,
	motive,
	ISNULL(debitamount,0) as debitamount,
	ISNULL(debitamountdeferred,0) as debitamountdeferred,
	ISNULL(creditamount,0) as creditamount,
	ISNULL(creditamountdeferred,0) as creditamountdeferred,
	previouscredit,
	previousdebit,
	currentcredit,
	currentdebit,
	refundamount,
	paymentamount,
	paymentdetails,
	prorata,
	@pre_credittotal AS precredittotal,
	CASE 
		WHEN (((@flag&1) <> 0)AND((@flag&2) = 0)) THEN 'Iva Commerciale e Promiscua'
		WHEN (((@flag&1) = 0)AND((@flag&2) <> 0)) THEN 'Iva Istituzionale (INTRA12)'
		ELSE  'Iva Commerciale, Promiscua e Istituzionale (INTRA12)'
	END as  'ivapaykind'
FROM #ivapayed
ORDER BY description ASC
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
