
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_mainliquidazioneiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_mainliquidazioneiva]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE   PROCEDURE [rpt_mainliquidazioneiva]
(
	@ayear int,
	@number int,
	@official char(1)
)
AS BEGIN
declare @ayearchar varchar(10)
set @ayearchar = convert(varchar(10),@ayear)

-- exec rpt_mainliquidazioneiva 2011,12 ,'S'
CREATE TABLE #mainivapayed
(
	ymainivapay int,
	nmainivapay int,
	nmonth int,
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
	assesmentdate smalldatetime,
	prorata float,
	iddbdepartment varchar(50) ,
	dbdepartment varchar(200),
	activity char(1),
	iva decimal(19,2),
	ivadeferred decimal(19,2),
	unabatable decimal(19,2), 
	unabatabledeferred decimal(19,2)
)


DECLARE @nmonth int
DECLARE @paymentdetails varchar(150)
DECLARE @assesmentdate smalldatetime
DECLARE @prorata float
DECLARE @refundamount decimal(19,2)
DECLARE @paymentamount decimal(19,2)
DECLARE @flag tinyint
SELECT @nmonth = nmonth,
	@paymentdetails = paymentdetails,
	@assesmentdate = assesmentdate,
	@prorata = prorata * 100,
	@refundamount = ISNULL(refundamount, 0),
	@paymentamount = ISNULL(paymentamount, 0),
	@flag = ISNULL(flag,3)
FROM mainivapay
WHERE ymainivapay = @ayear 	AND nmainivapay = @number

DECLARE @monthtitle varchar(10)
SELECT @monthtitle = title FROM monthname WHERE code = @nmonth

DECLARE @flagivapaybyrow char(1)-- Indica se il calcolo va fatto riga per riga
SELECT @flagivapaybyrow = isnull(flagivapaybyrow,'N') FROM config WHERE ayear = @ayear

DECLARE @saldo_iniziale decimal (19,2)
DECLARE @prevcredit decimal(19,2)
DECLARE @prevdebit decimal(19,2)

SELECT @saldo_iniziale = ISNULL(mainstartivabalance,0) FROM config WHERE ayear=@ayear  -- saldo iniziale dell'iva ad inizio anno da configurare manualmente all'interno della configurazione annuale
IF (@flagivapaybyrow = 'S')
Begin
	SELECT
		@prevcredit = ISNULL(SUM(creditamount),0) + ISNULL(SUM(creditamountdeferred),0) - ISNULL(SUM(refundamount), 0),
		@prevdebit = ISNULL(SUM(debitamount),0) + ISNULL(SUM(debitamountdeferred),0) - ISNULL(SUM(paymentamount), 0)
	FROM mainivapay
	WHERE ymainivapay = @ayear AND nmainivapay < @number
End
ELSE 
Begin
	SELECT
		@prevcredit = ISNULL(SUM(totalcredit),0)  - ISNULL(SUM(refundamount), 0),
		@prevdebit = ISNULL(SUM(totaldebit),0)  - ISNULL(SUM(paymentamount), 0)
	FROM mainivapay
	WHERE ymainivapay = @ayear AND nmainivapay < @number
End

SET @prevcredit = @prevcredit + @saldo_iniziale

IF @prevcredit>=@prevdebit
BEGIN
	SET @prevcredit = @prevcredit - @prevdebit 
	SET @prevdebit  = 0
END
ELSE
BEGIN
	SET @prevdebit = @prevdebit - @prevcredit
	SET @prevcredit= 0
END

INSERT INTO #mainivapayed(
	ymainivapay,
	nmainivapay,
	nmonth,
	description,
	motive,
	debitamount,
	debitamountdeferred,
	previouscredit,
	previousdebit,
	paymentdetails,
	assesmentdate,
	iddbdepartment
)
SELECT 
	@ayear,
	@number,
	@nmonth,
	K.description,
	'IVA esigibile su vendite',
	ISNULL(D.ivanet,0),
	ISNULL(D.ivanetdeferred,0),
	@prevcredit,
	@prevdebit,
	@paymentdetails,
	@assesmentdate,
	iddbdepartment
FROM mainivapaydetail D
JOIN ivaregisterkind K
	ON D.idivaregisterkind = K.idivaregisterkind
WHERE K.registerclass = 'V'
	AND D.ymainivapay = @ayear
	AND D.nmainivapay = @number
	AND (ISNULL(D.ivanet,0) <> 0 OR ISNULL(D.ivanetdeferred,0) <> 0)
	AND flagactivity <> 1

INSERT INTO #mainivapayed(
	ymainivapay,
	nmainivapay,
	nmonth,	
	description,
	motive,
	creditamount,
	creditamountdeferred,
	previouscredit,
	previousdebit,
	paymentdetails,
	assesmentdate,
	iddbdepartment,
	activity,
	iva,
	ivadeferred,
	unabatable,
	unabatabledeferred
)
SELECT
	@ayear,
	@number,
	@nmonth,	
	K.description,
	'IVA detraibile su acquisti',
	ISNULL(D.ivanet,0),
	ISNULL(D.ivanetdeferred,0),
	@prevcredit,
	@prevdebit,
	@paymentdetails,
	@assesmentdate,
	iddbdepartment,
	CASE  
		when flagactivity = 2 then  'C'
		when flagactivity = 3 then  'P'
		else null
	end,
	ISNULL(D.iva,0),
	ISNULL(D.ivadeferred,0),
	ISNULL(D.unabatable,0),
	ISNULL(D.unabatabledeferred,0)
FROM mainivapaydetail D
JOIN ivaregisterkind K
	ON D.idivaregisterkind = K.idivaregisterkind
WHERE K.registerclass = 'A'
	AND D.ymainivapay = @ayear
	AND D.nmainivapay = @number
	AND (ISNULL(D.ivanet,0) <> 0 OR ISNULL(D.ivanetdeferred,0) <> 0)
	AND flagactivity <> 1

DECLARE @credittotal decimal(19,2)  -- Somma dell'IVA detraibile dopo l'applicazione prorata/promuscuo
DECLARE @debittotal decimal(19,2)  -- Somma dell'IVA esigibile
DECLARE @pre_credittotal decimal(19,2)  -- Memorizza il valore dell'iva detraibile prima dell'applicazione del Prorata/Promiscuo utile unicamente nel caso non riga a riga

SET @pre_credittotal= 0

IF (@flagivapaybyrow = 'S')
Begin
	SELECT	@credittotal = ISNULL(SUM(creditamount), 0) + ISNULL(SUM(creditamountdeferred),0),
			@debittotal  = ISNULL(SUM(debitamount), 0) + ISNULL(SUM(debitamountdeferred),0),
			@pre_credittotal = ISNULL(SUM(iva), 0) - ISNULL(SUM(unabatable),0) + ISNULL(SUM(ivadeferred),0) - ISNULL(SUM(unabatabledeferred),0)
	FROM #mainivapayed
End
ELSE 
Begin
	SELECT
		@credittotal = ISNULL(SUM(totalcredit),0),
		@debittotal = ISNULL(SUM(totaldebit),0),
		@pre_credittotal = ISNULL(SUM(creditamount), 0) + ISNULL(SUM(creditamountdeferred),0)
	FROM mainivapay
	WHERE ymainivapay = @ayear AND nmainivapay = @number
End

DECLARE @currentcredit decimal(19,2)
DECLARE @currentdebit decimal(19,2)

-- In currentcredit e currentdebit sono memorizzati i saldi correnti, valorizzando il maggiore fra essi "crediti - debiti" o viceversa

IF @credittotal >= @debittotal
Begin
	SET @currentcredit = ISNULL(@prevcredit, 0) + ISNULL(@credittotal, 0) - ISNULL(@debittotal, 0) 
	SET @currentdebit = 0
End
ELSE
Begin
	SET @currentcredit = 0
	SET @currentdebit = ISNULL(@prevdebit, 0) + ISNULL(@debittotal, 0) - ISNULL(@credittotal, 0) 
End

UPDATE #mainivapayed
SET currentcredit = @currentcredit,
	currentdebit = @currentdebit,
	refundamount = @refundamount,
	paymentamount = @paymentamount,
	prorata = @prorata

	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor

	CREATE TABLE #descriptiondepartmenttable (iddbdepartment varchar(50), description varchar(240)) 

	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
										where (start is null or start <= @ayear ) AND 
											  (stop is null or stop >= @ayear)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @dip_nomesp varchar(3000)
		set @dip_nomesp = N'insert into #descriptiondepartmenttable
							(
							  iddbdepartment,
								description
							)
							select top 1' +''''+ @iddbdepartment+'''' + ',paramvalue from ' +'[' + @iddbdepartment +']' + '.generalreportparameter 
							where idparam = ' + '''' + 'DenominazioneDipartimento'+ ''' 
								and  (ISNULL(start, {d ''1900-01-01''}) = {d ''1900-01-01''} or year(start) <= ' + @ayearchar + ' ) ' +
								' and  (ISNULL(stop, {d ''2079-06-06''}) = {d ''2079-06-06''}  or year(stop) >= ' + @ayearchar + ')  '  +
								' order by ISNULL(stop, {d ''2079-06-06''}) desc  '
print @dip_nomesp

		exec (@dip_nomesp)
		fetch next from @crsdepartment into @iddbdepartment

	END



SELECT
	ymainivapay,
	nmainivapay,
	@monthtitle as monthtitle,
	#mainivapayed.description,
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
	assesmentdate,
	paymentdetails,
	prorata,
	#descriptiondepartmenttable.iddbdepartment,
	#descriptiondepartmenttable.description as dbdepartment,
	@flagivapaybyrow as flagivapaybyrow,
	@credittotal as credittotal,
	@debittotal as debittotal,
	isnull(activity,'Z') as activity,
	@pre_credittotal as pre_credittotal,
	CASE 
		WHEN (((@flag&1) <> 0)AND((@flag&2) = 0)) THEN 'Iva Commerciale e Promiscua'
		WHEN (((@flag&1) = 0)AND((@flag&2) <> 0))  THEN 'Iva Istituzionale (INTRA12)'
		ELSE  'Iva Commerciale, Promiscua e Istituzionale (INTRA12)'
	END as  'mainivapaykind'
FROM #mainivapayed
LEFT OUTER JOIN #descriptiondepartmenttable 
	ON 	#mainivapayed.iddbdepartment = #descriptiondepartmenttable.iddbdepartment
ORDER BY #mainivapayed.description ASC, #descriptiondepartmenttable.description ASC


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
