if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_liquidazioneivasplitistituzionale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure rpt_liquidazioneivasplitistituzionale
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE rpt_liquidazioneivasplitistituzionale
(
	@ayear int,
	@number int,
	@official char(1)
)
AS BEGIN

-- exec rpt_liquidazioneivasplitistituzionale 2015,6 ,'N'
CREATE TABLE #ivapayed
(
	idivapayperiodicity varchar(50),
	yivapay int,
	nivapay int,
	start datetime,
	stop datetime,
	description varchar(50),
	motive varchar(50),
	ivasplit decimal(19,2),
	ivasplitdeferred decimal(19,2),
	currentdebit decimal(19,2),
	refundamount decimal(19,2),
	paymentamount decimal(19,2),
	paymentdetails varchar(150),
	iva decimal(19,2),
	ivadeferred decimal(19,2)
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
	@refundamount = ISNULL(refundamount, 0),
	@paymentamount = ISNULL(paymentamount, 0),
	@flag = ISNULL(flag,3)
FROM ivapay
WHERE yivapay = @ayear
	AND nivapay = @number

DECLARE @saldo_iniziale_split decimal (19,2)
SELECT @saldo_iniziale_split = ISNULL(-startivabalancesplit,0) from config where ayear = @ayear

DECLARE @prev_debitcredit_split decimal(19,2)
SELECT
	 @prev_debitcredit_split = ISNULL(SUM(totaldebitsplit),0) - ISNULL(SUM(paymentamountsplit),0) 
FROM ivapay
WHERE yivapay = @ayear
	AND nivapay < @number

-- Ora il saldo precedente viene memorizzato e quindi letto direttamente dalla tabella.
-- ove non memorizzato, per i dati pregressi, continuiamo a calcolarlo.
DECLARE @saldo_precedente_split decimal (19,2)
select @saldo_precedente_split = prev_debitsplit from ivapay where yivapay = @ayear AND nivapay = @number
if (@saldo_precedente_split is null)
Begin
	SET @saldo_precedente_split = @saldo_iniziale_split + @prev_debitcredit_split
End
--select @saldo_precedente_split as  saldo_precedente_split

DECLARE @ivadelperiodosplit decimal (19,2)
select @ivadelperiodosplit = ISNULL(SUM(totaldebitsplit),0) from ivapay where yivapay = @ayear AND nivapay < @number

DECLARE @paymentamountsplit decimal (19,2)
select @paymentamountsplit = ISNULL(SUM(paymentamountsplit),0) from ivapay where yivapay = @ayear AND nivapay < @number

DECLARE @nuovosaldosplit decimal(19,2) 
set @nuovosaldosplit = @saldo_precedente_split + @ivadelperiodosplit - @paymentamountsplit
--select @nuovosaldosplit as nuovosaldosplit  

INSERT INTO #ivapayed
(
	idivapayperiodicity,
	yivapay,
	nivapay,
	start,
	stop,
	description,
	motive,
	ivasplit,
	ivasplitdeferred
)
SELECT
	@idivapayperiodicity,
	@ayear,
	@number,
	@start_period,
	@stop_period,
	ivaregisterkind.description,
	'IVA detraibile su acquisti',
	null,--ISNULL(ivapaydetail.iva,0),
	ISNULL(ivapaydetail.ivadeferred,0)
FROM ivapaydetail
JOIN ivaregisterkind
	ON ivapaydetail.idivaregisterkind = ivaregisterkind.idivaregisterkind
WHERE ivaregisterkind.registerclass = 'A' AND flagactivity = 1
	AND ivapaydetail.yivapay = @ayear
	AND ivapaydetail.nivapay = @number
	AND (ISNULL(ivapaydetail.ivanet,0) <> 0 OR ISNULL(ivapaydetail.ivanetdeferred,0) <> 0)


UPDATE #ivapayed
SET currentdebit = @nuovosaldosplit,
refundamount = @refundamount,
paymentamount = @paymentamount

SELECT
	idivapayperiodicity,
	yivapay,
	nivapay,
	start,
	stop,
	description,
	motive,
	ISNULL(ivasplit,0) as debitamount,
	ISNULL(ivasplitdeferred,0) as debitamountdeferred,
	@nuovosaldosplit as currentdebit,
	CASE 
		WHEN (((@flag&4) <> 0)) THEN 'Iva Istituzionale Split Payment'
		ELSE  ''
	END as  'ivapaykind'
FROM #ivapayed
ORDER BY description ASC
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
