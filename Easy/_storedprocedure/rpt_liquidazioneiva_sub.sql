
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_liquidazioneiva_sub]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_liquidazioneiva_sub]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [rpt_liquidazioneiva_sub]
(
	@ayear int,
	@startmounth int,
	@stopmounth int

)
AS BEGIN


DECLARE @query nvarchar(3000)
DECLARE @minnivapay int
DECLARE @maxnivapay int
DECLARE @previouscredit decimal(19,2)
DECLARE @previousdebit decimal(19,2)


 DECLARE @amm varchar(100)
 set @amm=user

	CREATE TABLE #mainliquidazione (
	ymainivapay int,
	nmainivapay int,
	monthtitle varchar(10),
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
	assesmentdate datetime,	
	paymentdetails varchar(150),
	prorata float,
	iddbdepartment varchar(50) ,
	dbdepartment varchar(200),
	flagivapaybyrow char(1),
	credittotal decimal(19,2),
	debittotal decimal(19,2),
	activity char(1),
	pre_credittotal decimal(19,2),
	mainivapaykind varchar(100)
	)

	select @minnivapay = min(nmainivapay) from mainivapay where nmonth between @startmounth and @stopmounth
	and ymainivapay = @ayear

	select @maxnivapay = max(nmainivapay) from mainivapay where nmonth between @startmounth and @stopmounth
	and ymainivapay = @ayear

	IF (@minnivapay IS NULL) AND (@maxnivapay IS NULL)
	BEGIN

				SELECT	 ymainivapay,
					nmainivapay ,
					monthtitle ,
					description ,
					motive ,
					debitamount ,			
					debitamountdeferred ,	
					creditamount ,			
					creditamountdeferred ,	
					previouscredit ,		
					previousdebit ,		
					currentcredit ,		
					currentdebit ,			
					refundamount ,			
					paymentamount ,	
					assesmentdate,
					paymentdetails ,
					prorata ,
					iddbdepartment ,
					dbdepartment ,
					flagivapaybyrow ,
					credittotal ,
					debittotal,
					activity,
					pre_credittotal,
					mainivapaykind
				FROM #mainliquidazione

	END
	ELSE
	BEGIN
		
		DECLARE @number INT
		SET @number = @minnivapay
    
		While ((@number) <= @maxnivapay) 
		BEGIN	
			print @number
			INSERT INTO #mainliquidazione 
				(ymainivapay,
					nmainivapay ,
					monthtitle ,
					description ,
					motive ,
					debitamount ,			
					debitamountdeferred ,	
					creditamount ,			
					creditamountdeferred ,	
					previouscredit ,		
					previousdebit ,		
					currentcredit ,		
					currentdebit ,			
					refundamount ,			
					paymentamount ,	
					assesmentdate	,
					paymentdetails ,
					prorata ,
					iddbdepartment ,
					dbdepartment ,
					flagivapaybyrow ,
					credittotal ,
					debittotal,
					activity,
					pre_credittotal,
					mainivapaykind)
			EXEC rpt_mainliquidazioneiva @ayear, @number, 'N'
			
			SET @number = @number + 1
		END

		SELECT @previouscredit = min(previouscredit) FROM #mainliquidazione
		WHERE nmainivapay = @minnivapay 
		SELECT @previousdebit = min(previousdebit) FROM #mainliquidazione
		WHERE nmainivapay = @minnivapay 

	    CREATE TABLE #totali (
			ymainivapay int,
			nmainivapay int,
			paymentamount decimal(19,2),
			refundamount decimal(19,2),
			credittotal decimal(19,2),
			debittotal decimal(19,2),
			currentcredit decimal(19,2),
			currentdebit decimal(19,2),
			pre_credittotal decimal(19,2)
		)
		
		
		INSERT INTO #totali
		(
			ymainivapay ,
			nmainivapay ,
			paymentamount,
			refundamount ,
			credittotal,
			debittotal,
			currentcredit ,
			currentdebit ,
			pre_credittotal
		)
		-- §sommo i valori dati dalle singole liquidazioni
		SELECT ymainivapay, nmainivapay,
			   SUM(distinct ISNULL(paymentamount,0)), 
			   SUM(distinct ISNULL(refundamount,0)),
			   SUM(distinct ISNULL(credittotal,0)),
			   SUM(distinct ISNULL(debittotal,0)), 
			   SUM(distinct ISNULL(currentcredit,0)),
			   SUM(distinct ISNULL(currentdebit,0)), 
			   SUM(distinct ISNULL(pre_credittotal,0)) 
		FROM #mainliquidazione
		GROUP BY ymainivapay, nmainivapay 

		DECLARE @credittotal decimal(19,2)
		DECLARE @pre_credittotal decimal(19,2)
		DECLARE @paymentamount decimal(19,2)
		DECLARE @refundamount decimal(19,2)
		DECLARE @debittotal decimal(19,2)
		DECLARE @currentcredit decimal(19,2)
		DECLARE @currentdebit decimal(19,2)
		
		SELECT @paymentamount = SUM(ISNULL(paymentamount,0)), @refundamount = SUM( ISNULL(refundamount,0)),
			   @credittotal =  SUM( ISNULL(credittotal,0)),
			   @debittotal = SUM( ISNULL(debittotal,0)), @currentcredit = SUM( ISNULL(currentcredit,0)),
			   @currentdebit = SUM( ISNULL(currentdebit,0)), 
			   @pre_credittotal = SUM(ISNULL(pre_credittotal,0)) 
		FROM #totali		

		SELECT ymainivapay,
			nmainivapay ,
			monthtitle ,
			description ,
			motive ,
			ISNULL(debitamount,0) as debitamount,
			ISNULL(debitamountdeferred,0) as debitamountdeferred,
			ISNULL(creditamount,0) as creditamount,
			ISNULL(creditamountdeferred,0) as creditamountdeferred,
			@previouscredit AS previouscredit,		
			@previousdebit AS previousdebit,		
			@currentcredit AS currentcredit ,		
			@currentdebit AS currentdebit ,			
			@refundamount AS refundamount ,			
			@paymentamount AS paymentamount ,		
			paymentdetails ,
			prorata ,
			iddbdepartment ,
			dbdepartment ,
			flagivapaybyrow ,
			@credittotal as credittotal,
			@debittotal as debittotal,
			activity,
			@pre_credittotal as pre_credittotal
		FROM #mainliquidazione
		ORDER BY ymainivapay, nmainivapay, motive, description ASC, dbdepartment ASC
		
	END
	

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
