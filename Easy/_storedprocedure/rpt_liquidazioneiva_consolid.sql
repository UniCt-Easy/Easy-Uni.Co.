if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_liquidazioneiva_consolid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure rpt_liquidazioneiva_consolid
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE rpt_liquidazioneiva_consolid
(
	@ayear int,
	@number int,
	@official char(1)
)
AS BEGIN
-- exec rpt_liquidazioneiva_consolid 2011,2 ,'N'
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
	prorata float
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
DECLARE @refundamount decimal(19,2)
DECLARE @paymentamount decimal(19,2)
DECLARE @prorata float
SELECT @start_period = start,
	@stop_period = stop,
	@paymentdetails = paymentdetails,
	@prorata = prorata * 100,
	@refundamount = ISNULL(refundamount, 0),
	@paymentamount = ISNULL(paymentamount, 0)
	FROM unifiedivapay 
	WHERE yunifiedivapay = @ayear
	AND nunifiedivapay = @number
DECLARE @prevcredit decimal(19,2)
DECLARE @prevdebit decimal(19,2)
SELECT
	@prevcredit =
		ISNULL(SUM(creditamount),0) +
		ISNULL(SUM(creditamountdeferred),0) -
		ISNULL(SUM(refundamount), 0),
	@prevdebit =
		ISNULL(SUM(debitamount),0) +
		ISNULL(SUM(debitamountdeferred),0) -
		ISNULL(SUM(paymentamount), 0)
FROM unifiedivapay 
WHERE yunifiedivapay = @ayear
	AND nunifiedivapay < @number
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
	ISNULL(unifiedivapaydetail.ivanet,0),
	ISNULL(unifiedivapaydetail.ivanetdeferred,0),
	@prevcredit,
	@prevdebit,
	@paymentdetails
FROM unifiedivapaydetail
JOIN ivaregisterkind
	ON unifiedivapaydetail.idivaregisterkindunified = ivaregisterkind.idivaregisterkindunified
WHERE ivaregisterkind.registerclass = 'V'
	AND unifiedivapaydetail.yunifiedivapay = @ayear
	AND unifiedivapaydetail.nunifiedivapay = @number
	AND (ISNULL(unifiedivapaydetail.ivanet,0) > 0 OR ISNULL(unifiedivapaydetail.ivanetdeferred,0) > 0)
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
	paymentdetails
)
SELECT
	@idivapayperiodicity,
	@ayear,
	@number,
	@start_period,
	@stop_period,
	ivaregisterkind.description,
	'IVA detraibile su acquisti',
	ISNULL(unifiedivapaydetail.ivanet,0),
	ISNULL(unifiedivapaydetail.ivanetdeferred,0),
	@prevcredit,
	@prevdebit,
	@paymentdetails
FROM unifiedivapaydetail
JOIN ivaregisterkind
	ON unifiedivapaydetail.idivaregisterkindunified = ivaregisterkind.idivaregisterkindunified
WHERE ivaregisterkind.registerclass = 'A'
	AND unifiedivapaydetail.yunifiedivapay = @ayear
	AND unifiedivapaydetail.nunifiedivapay = @number
	AND (ISNULL(unifiedivapaydetail.ivanet,0) > 0 OR ISNULL(unifiedivapaydetail.ivanetdeferred,0) > 0)
DECLARE @credittotal decimal(19,2)
DECLARE @debittotal decimal(19,2)
SELECT @credittotal = ISNULL(SUM(creditamount), 0) + ISNULL(SUM(creditamountdeferred),0),
	@debittotal = ISNULL(SUM(debitamount), 0) + ISNULL(SUM(debitamountdeferred),0)
FROM #ivapayed
UPDATE #ivapayed
SET currentcredit = ISNULL(@prevcredit, 0) + ISNULL(@credittotal, 0),
currentdebit = ISNULL(@prevdebit, 0) + ISNULL(@debittotal, 0),
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
	prorata
FROM #ivapayed
ORDER BY description ASC
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

