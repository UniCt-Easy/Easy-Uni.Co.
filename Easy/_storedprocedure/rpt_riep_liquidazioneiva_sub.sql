
if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_riep_liquidazioneiva_sub]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_riep_liquidazioneiva_sub]
GO

 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exec rpt_riep_liquidazioneiva_sub 2016,1,12
CREATE   PROCEDURE [rpt_riep_liquidazioneiva_sub]
(
	@ayear int,
	@startmounth int,
	@stopmounth int
)
AS BEGIN


DECLARE @minnivapay int
DECLARE @maxnivapay int
DECLARE @previouscredit decimal(19,2)
DECLARE @previousdebit decimal(19,2)


 DECLARE @amm varchar(100)
 set @amm=user

	CREATE TABLE #liquidazioneiva (
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
	unabatabledeferred decimal(19,2),
	pre_credittotal decimal(19,2),
	ivapaykind varchar(150) 
	)

	select @minnivapay = min(nivapay) from ivapay where month(start) between @startmounth and @stopmounth
	and yivapay = @ayear

	select @maxnivapay = max(nivapay) from ivapay where month(stop) between @startmounth and @stopmounth
	and yivapay = @ayear

	IF (@minnivapay IS NULL) AND (@maxnivapay IS NULL)
	BEGIN
				SELECT	 
					idivapayperiodicity,
					yivapay,
					nivapay ,
					start ,
					stop,
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
					paymentdetails ,
					prorata ,
					pre_credittotal,
					ivapaykind,
					0 as acconto
				FROM #liquidazioneiva

	END
	ELSE
	BEGIN
		
		DECLARE @number INT
		SET @number = @minnivapay
    
		While ((@number) <= @maxnivapay) 
		BEGIN	
			print @number
			INSERT INTO #liquidazioneiva 
				(idivapayperiodicity,
					yivapay,
					nivapay ,
					start ,
					stop,
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
					paymentdetails ,
					prorata ,
					pre_credittotal,
					ivapaykind)
			EXEC rpt_liquidazioneiva @ayear, @number, 'N'
			
			SET @number = @number + 1
		END

	
	-- PER MOSTRARE IL CREDITO O DEBITO PRECEDENTE
	-- FILTRIAMO LA LIQUIDAZIONE IVA INCLUDENTE IL TIPO IVA COMMERCIALE / PROMISCUA: (ivapay.flag&1)<>0
	SELECT @previouscredit = min(previouscredit) FROM #liquidazioneiva
	WHERE nivapay = (select min(nivapay) FROM #liquidazioneiva	WHERE EXISTS (SELECT * FROM ivapay where yivapay = @ayear and nivapay =#liquidazioneiva.nivapay and ((ivapay.flag&1)<>0)))
	SELECT @previousdebit = min(previousdebit) FROM #liquidazioneiva
	WHERE nivapay = (select min(nivapay) FROM #liquidazioneiva	WHERE EXISTS (SELECT * FROM ivapay where yivapay = @ayear and nivapay =#liquidazioneiva.nivapay and ((ivapay.flag&1)<>0)))

		
	CREATE TABLE #totali (
		yivapay int,
		nivapay int,
		paymentamount decimal(19,2),
		refundamount decimal(19,2),
		currentcredit decimal(19,2),
		currentdebit decimal(19,2),
		pre_credittotal decimal(19,2)
	)
		DECLARE @pre_credittotal decimal(19,2)
		DECLARE @paymentamount decimal(19,2)
		DECLARE @refundamount decimal(19,2)
		DECLARE @currentcredit decimal(19,2)
		DECLARE @currentdebit decimal(19,2)
		
		INSERT INTO #totali
		(
			yivapay ,
			nivapay ,
			paymentamount,
			refundamount ,
			currentcredit ,
			currentdebit ,
			pre_credittotal
		)
		-- §sommo i valori dati dalle singole liquidazioni
		SELECT yivapay, nivapay,
			   SUM(distinct ISNULL(paymentamount,0)), 
			   SUM(distinct ISNULL(refundamount,0)),
			   SUM(distinct ISNULL(currentcredit,0)),
			   SUM(distinct ISNULL(currentdebit,0)), 
			   SUM(distinct ISNULL(pre_credittotal,0)) 
		FROM #liquidazioneiva
		GROUP BY yivapay, nivapay 
		
		
		-- §sommo i valori dati dalle singole liquidazioni
		SELECT @paymentamount = SUM(ISNULL(paymentamount,0)), @refundamount = SUM(ISNULL(refundamount,0)),
			   @currentcredit = SUM(ISNULL(currentcredit,0)),
			   @currentdebit = SUM(ISNULL(currentdebit,0)), 
			   @pre_credittotal = SUM(ISNULL(pre_credittotal,0)) 
		FROM #totali		

DECLARE @acconto decimal(19,2)		
SELECT @acconto = sum(creditamount)
FROM ivapay
where paymentkind='A'
	and yivapay = @ayear
	and month(start) between @startmounth and @stopmounth

		SELECT idivapayperiodicity,
			yivapay,
			nivapay ,
			start ,
			stop,
			description ,
			motive ,
			debitamount ,			
			debitamountdeferred ,	
			creditamount ,			
			creditamountdeferred ,	
			@previouscredit AS previouscredit,		
			@previousdebit AS previousdebit,		
			@currentcredit AS currentcredit ,		
			@currentdebit AS currentdebit ,			
			@refundamount AS refundamount ,			
			@paymentamount AS paymentamount ,		
			paymentdetails ,
			prorata ,
			@pre_credittotal as pre_credittotal,
			ivapaykind,
			isnull(@acconto,0) as acconto
		FROM #liquidazioneiva
		ORDER BY yivapay, nivapay, ivapaykind, motive, description ASC
		
	END
	

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
