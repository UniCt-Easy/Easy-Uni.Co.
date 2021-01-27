
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_liquidazioneiva_intra]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_liquidazioneiva_intra]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE rpt_liquidazioneiva_intra
(
	@ayear int,
	@number int,
	@official char(1)
)
AS BEGIN
CREATE TABLE #ivapayed(
	idivapayperiodicity varchar(50),
	yivapay int,
	nivapay int,
	start datetime,
	stop datetime,
	description varchar(50),
	motive varchar(50),
	debitamount12 decimal(19,2),
	debitamountdeferred12 decimal(19,2),
	creditamount12 decimal(19,2),
	creditamountdeferred12 decimal(19,2),
	previouscredit12 decimal(19,2),
	previousdebit12 decimal(19,2),
	currentcredit12 decimal(19,2),
	currentdebit12 decimal(19,2),
	refundamount12 decimal(19,2),
	paymentamount12 decimal(19,2),
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
DECLARE @prorata float
DECLARE @refundamount12 decimal(19,2)
DECLARE @paymentamount12 decimal(19,2)
SELECT @start_period = start,
	@stop_period = stop,
	@paymentdetails = paymentdetails,
	@prorata = prorata * 100,
	@refundamount12 = ISNULL(refundamount12, 0),
	@paymentamount12 = ISNULL(paymentamount12, 0)
FROM ivapay
WHERE yivapay = @ayear
	AND nivapay = @number

DECLARE @saldo_iniziale12 decimal (19,2)
DECLARE @prev_creditdebit12 decimal(19,2)
DECLARE @prevcredit12 decimal(19,2)
DECLARE @prevdebit12 decimal(19,2)
SELECT @saldo_iniziale12 = ISNULL(-startivabalance12,0) from config where ayear = @ayear
SELECT
	 @prev_creditdebit12 = ISNULL(SUM(totaldebit12),0) - ISNULL(SUM(paymentamount12),0)  -  ISNULL(SUM(totalcredit12),0) + ISNULL(SUM(refundamount12),0)
FROM ivapay
WHERE yivapay = @ayear
	AND nivapay < @number


-- Ora il saldo precedente viene memorizzato e quindi letto direttamente dalla tabella.
-- ove non memorizzato, per i dati pregressi, continuiamo a calcolarlo.
DECLARE @saldo_precedente12 decimal (19,2)
select @saldo_precedente12 = prev_debit12 from ivapay where yivapay = @ayear AND nivapay = @number
if (@saldo_precedente12 is null)
Begin
	SET @saldo_precedente12 = @saldo_iniziale12 + @prev_creditdebit12
End
	
IF @saldo_precedente12 >0
BEGIN
	SET @prevdebit12 = @saldo_precedente12
	SET @prevcredit12 = 0 
END
ELSE
BEGIN
	SET @prevdebit12 = 0
	SET @prevcredit12 = - @saldo_precedente12 
END
-- Iva INTRA 
INSERT INTO #ivapayed(
	idivapayperiodicity,
	yivapay,
	nivapay,
	start,
	stop,
	description,
	motive,
	debitamount12,
	debitamountdeferred12,
	previouscredit12,
	previousdebit12,
	paymentdetails	
)
SELECT 
	@idivapayperiodicity,
	@ayear,
	@number,
	@start_period,
	@stop_period,
	K.description,
	'IVA Intra da Versare',--DEBITO
	case when ISNULL(D.ivanet,0)>0 
			then ISNULL(D.ivanet,0)
			else 0
	end	,
	case when ISNULL(D.ivanetdeferred,0)>0 
			then ISNULL(D.ivanetdeferred,0)
			else 0
	end,
	@prevcredit12,
	@prevdebit12,
	@paymentdetails	
FROM ivapaydetail D
JOIN ivaregisterkind K
	ON D.idivaregisterkind = K.idivaregisterkind
WHERE D.yivapay = @ayear
	AND D.nivapay = @number
	AND (ISNULL(D.ivanet,0) > 0 OR ISNULL(D.ivanetdeferred,0) > 0)
	AND (K.registerclass ='A' and K.flagactivity = 1)-- Istituzionale
		AND EXISTS (SELECT  * FROM invoicedeferred I
		JOIN invoice INV 
			ON I.yinv= INV.yinv AND I.ninv = INV.ninv AND I.idinvkind = INV.idinvkind 
		JOIN invoicekind INVKIND 
			ON INVKIND.idinvkind= INV.idinvkind
		JOIN invoicekindregisterkind INVR
			ON INVR.idinvkind = INVKIND.idinvkind
			AND INVR.idivaregisterkind = K.idivaregisterkind
		WHERE I.yivapay= D.yivapay AND I.nivapay = D.nivapay
		AND	INV.flagintracom IN ('S','X')  
		AND ISNULL(INV.flag_enable_split_payment,'N') = 'N')

INSERT INTO #ivapayed(
	idivapayperiodicity,
	yivapay,
	nivapay,
	start,
	stop,
	description,
	motive,
	creditamount12,
	creditamountdeferred12,
	previouscredit12,
	previousdebit12,
	paymentdetails
)
SELECT
	@idivapayperiodicity,
	@ayear,
	@number,
	@start_period,
	@stop_period,
	K.description,
	'IVA Intra da Rimborsare',-- CREDITO
	case when ISNULL(D.ivanet,0) < 0 
			then ISNULL(D.ivanet,0)
			else 0
	end	,
	case when ISNULL(D.ivanetdeferred,0) < 0 
			then ISNULL(D.ivanetdeferred,0)
			else 0
	end,
	@prevcredit12,
	@prevdebit12,
	@paymentdetails
FROM ivapaydetail D
JOIN ivaregisterkind K
	ON D.idivaregisterkind = K.idivaregisterkind
WHERE D.yivapay = @ayear
	AND D.nivapay = @number
	AND (ISNULL(D.ivanet,0) < 0 OR ISNULL(D.ivanetdeferred,0) < 0)
	AND (K.registerclass ='A' and K.flagactivity = 1)-- Istituzionale
	AND EXISTS (SELECT  * FROM invoicedeferred I
		JOIN invoice INV 
			ON I.yinv= INV.yinv AND I.ninv = INV.ninv AND I.idinvkind = INV.idinvkind 
		JOIN invoicekind INVKIND 
			ON INVKIND.idinvkind= INV.idinvkind
		JOIN invoicekindregisterkind INVR
			ON INVR.idinvkind = INVKIND.idinvkind
			AND INVR.idivaregisterkind = K.idivaregisterkind
		WHERE I.yivapay= D.yivapay AND I.nivapay = D.nivapay
		AND	INV.flagintracom IN ('S','X')  
		AND ISNULL(INV.flag_enable_split_payment,'N') = 'N')

DECLARE @credittotal12 decimal(19,2)  -- Somma dell'IVA detraibile dopo l'applicazione prorata/promuscuo
DECLARE @debittotal12 decimal(19,2) -- Somma dell'IVA esigibile

SELECT	@credittotal12 = ISNULL(SUM(creditamount12), 0) + ISNULL(SUM(creditamountdeferred12),0),
		@debittotal12  = ISNULL(SUM(debitamount12), 0) + ISNULL(SUM(debitamountdeferred12),0)

FROM #ivapayed

DECLARE @currentcredit12 decimal(19,2)
DECLARE @currentdebit12 decimal(19,2)

-- In currentcredit e currentdebit sono memorizzati i saldi correnti, valorizzando il maggiore fra essi "crediti - debiti" o viceversa

IF @credittotal12 > @debittotal12
Begin
	SET @currentcredit12 = ISNULL(@prevcredit12, 0) + ISNULL(@credittotal12,0) - ISNULL(@debittotal12, 0) 
	SET @currentdebit12 = 0
End
ELSE
Begin
	SET @currentcredit12 = 0
	SET @currentdebit12 = ISNULL(@prevdebit12, 0) + ISNULL(@debittotal12, 0) - ISNULL(@credittotal12,0)
End 

UPDATE #ivapayed
SET currentcredit12 = @currentcredit12,
	currentdebit12 = @currentdebit12,
	refundamount12 = @refundamount12,
	paymentamount12 = @paymentamount12

-- Questo UPDATE serve per gestire a livello di layout di stampa una situazione molto particolare.
-- E' il caso in cui nel mese in oggetto è stata liquidata SOLO una nota di variazione di una fattura di Acquisto Istituzionale Intracomunitaria.
-- Se la nota di variazione è stata fatta nello stesso mese della fattura, allora non dovrebbe sorgere alcun problema
-- perchè l'iva della nota di var. sarà sottratta dall'iva della fattura. Ma se invece nel mese ho fatto SOLO la nota di variazione
-- nella liquidazione troverò una riga "Registro Acquisti Istituzionale", con importo negativo: creditamount12 = -10 .
-- Anche nel form della liquidazione avrò nel Grid dell'iva a debito : -10. Nei totali : 0 - -10 = +10 iva a credito.
-- Quindi per gestire questa situazione, alquanto remota, piuttosto che visualizzare l'importo negatico nella colonna "IVA a debito"
-- si è deciso di visualizzare questo importo negativo nella colonna "IVA a credito" con segno positivo.

UPDATE #ivapayed SET currentcredit12 = - currentcredit12 where currentcredit12 <0
UPDATE #ivapayed SET previouscredit12 = - previouscredit12 where previouscredit12 <0
UPDATE #ivapayed SET creditamount12 = - creditamount12 where creditamount12 <0
UPDATE #ivapayed SET creditamountdeferred12 = - creditamountdeferred12 where creditamountdeferred12 <0


SELECT
	idivapayperiodicity,
	yivapay,
	nivapay,
	start,
	stop,
	description,
	motive,
	ISNULL(debitamount12,0) as debitamount12,
	ISNULL(debitamountdeferred12,0) as debitamountdeferred12,
	ISNULL(creditamount12,0) as creditamount12,
	ISNULL(creditamountdeferred12,0) as creditamountdeferred12,
	previouscredit12,
	previousdebit12,
	currentcredit12,
	currentdebit12,
	refundamount12,
	paymentamount12,
	paymentdetails,
	prorata
FROM #ivapayed 
ORDER BY #ivapayed.description ASC


END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

