
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_mainliquidazioneiva_intra]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_mainliquidazioneiva_intra]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE rpt_mainliquidazioneiva_intra
(
	@ayear int,
	@number int,
	@official char(1)
)
AS BEGIN
declare @ayearchar varchar(10)
set @ayearchar = convert(varchar(10),@ayear)

CREATE TABLE #mainivapayed(
	ymainivapay int,
	nmainivapay int,
	nmonth int,
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
	prorata float,
	iddbdepartment varchar(50),
	dbdepartment varchar(200)
)


DECLARE @nmonth int
DECLARE @paymentdetails varchar(150)
DECLARE @prorata float
DECLARE @refundamount12 decimal(19,2)
DECLARE @paymentamount12 decimal(19,2)
SELECT @nmonth = nmonth,
	@paymentdetails = paymentdetails,
	@prorata = prorata * 100,
	@refundamount12 = ISNULL(refundamount12, 0),
	@paymentamount12 = ISNULL(paymentamount12, 0)
FROM mainivapay
WHERE ymainivapay = @ayear 	AND nmainivapay = @number

DECLARE @monthtitle varchar(10)
SELECT @monthtitle = title FROM monthname WHERE code = @nmonth

DECLARE @saldo_iniziale12 decimal (19,2)
DECLARE @prevcredit12 decimal(19,2)
DECLARE @prevdebit12 decimal(19,2)

SELECT @saldo_iniziale12 = ISNULL(mainstartivabalance12,0) FROM config WHERE ayear=@ayear

SELECT
	@prevcredit12 = ISNULL(SUM(creditamount12),0) + ISNULL(SUM(creditamountdeferred12),0) - ISNULL(SUM(refundamount12), 0),
	@prevdebit12 = ISNULL(SUM(debitamount12),0) + ISNULL(SUM(debitamountdeferred12),0) - ISNULL(SUM(paymentamount12), 0)
FROM mainivapay
WHERE ymainivapay = @ayear AND nmainivapay < @number

SET @prevcredit12 = @prevcredit12 + @saldo_iniziale12

IF @prevcredit12>=@prevdebit12
BEGIN
	SET @prevcredit12 = @prevcredit12 - @prevdebit12 
	SET @prevdebit12  = 0
END
ELSE
BEGIN
	SET @prevdebit12 = @prevdebit12 - @prevcredit12
	SET @prevcredit12= 0
END

-- Iva INTRA 
INSERT INTO #mainivapayed(
	ymainivapay,
	nmainivapay,
	nmonth,
	description,
	motive,
	debitamount12,
	debitamountdeferred12,
	previouscredit12,
	previousdebit12,
	paymentdetails,
	iddbdepartment
)
SELECT 
	@ayear,
	@number,
	@nmonth,
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
	@paymentdetails,
	iddbdepartment
FROM mainivapaydetail D
JOIN ivaregisterkind K
	ON D.idivaregisterkind = K.idivaregisterkind
WHERE D.ymainivapay = @ayear
	AND D.nmainivapay = @number
	AND (ISNULL(D.ivanet,0) > 0 OR ISNULL(D.ivanetdeferred,0) > 0)
	AND (K.registerclass ='A' and K.flagactivity = 1)-- Istituzionale

INSERT INTO #mainivapayed(
	ymainivapay,
	nmainivapay,
	nmonth,	
	description,
	motive,
	creditamount12,
	creditamountdeferred12,
	previouscredit12,
	previousdebit12,
	paymentdetails,
	iddbdepartment
)
SELECT
	@ayear,
	@number,
	@nmonth,	
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
	@paymentdetails,
	iddbdepartment
FROM mainivapaydetail D
JOIN ivaregisterkind K
	ON D.idivaregisterkind = K.idivaregisterkind
WHERE D.ymainivapay = @ayear
	AND D.nmainivapay = @number
	AND (ISNULL(D.ivanet,0) < 0 OR ISNULL(D.ivanetdeferred,0) < 0)
	AND (K.registerclass ='A' and K.flagactivity = 1)-- Istituzionale

DECLARE @credittotal12 decimal(19,2)
DECLARE @debittotal12 decimal(19,2)
SELECT	@credittotal12 = ISNULL(SUM(creditamount12), 0) + ISNULL(SUM(creditamountdeferred12),0),
		@debittotal12  = ISNULL(SUM(debitamount12), 0) + ISNULL(SUM(debitamountdeferred12),0)
FROM #mainivapayed

DECLARE @currentcredit12 decimal(19,2)
DECLARE @currentdebit12 decimal(19,2)

IF @credittotal12 > @debittotal12
Begin
	SET @currentcredit12 = ISNULL(@prevcredit12, 0) + ISNULL(@credittotal12, 0) - ISNULL(@debittotal12, 0)
	SET @currentdebit12 = 0
End
ELSE
Begin
	SET @currentcredit12 = 0
	SET @currentdebit12 = ISNULL(@prevdebit12, 0) + ISNULL(@debittotal12, 0) - ISNULL(@credittotal12, 0)
End 

UPDATE #mainivapayed
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

UPDATE #mainivapayed SET currentcredit12 = - currentcredit12 where currentcredit12 <0
UPDATE #mainivapayed SET previouscredit12 = - previouscredit12 where previouscredit12 <0
UPDATE #mainivapayed SET creditamount12 = - creditamount12 where creditamount12 <0
UPDATE #mainivapayed SET creditamountdeferred12 = - creditamountdeferred12 where creditamountdeferred12 <0


declare @iddbdepartment varchar(50)
declare @crsdepartment cursor

CREATE TABLE #descriptiondepartmenttable (iddbdepartment varchar(50), description varchar(240)) 

set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
									 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
open 	@crsdepartment
fetch next from @crsdepartment into @iddbdepartment
while @@fetch_status=0 begin
	declare @dip_nomesp varchar(300)
	set @dip_nomesp = N'insert into #descriptiondepartmenttable
						(
							 iddbdepartment,
						     description
						)
						select ' +''''+ @iddbdepartment+'''' + ',paramvalue from ' +'[' + @iddbdepartment +']' + '.generalreportparameter 
							where idparam = ' + '''' + 'DenominazioneDipartimento'+ ''' 
								and  (start is null or year(start) <= '+@ayearchar +')'+ 
								'and (stop is null or year(stop) >= '+ @ayearchar+ ')'

	exec (@dip_nomesp)
	fetch next from @crsdepartment into @iddbdepartment
END

SELECT
	ymainivapay,
	nmainivapay,
	@monthtitle as monthtitle,
	#mainivapayed.description,
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
	prorata,
	#descriptiondepartmenttable.iddbdepartment,
	#descriptiondepartmenttable.description as dbdepartment
FROM #mainivapayed 
JOIN #descriptiondepartmenttable 
	ON 	#mainivapayed.iddbdepartment = #descriptiondepartmenttable.iddbdepartment
ORDER BY #mainivapayed.description ASC, #descriptiondepartmenttable.description ASC


END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

