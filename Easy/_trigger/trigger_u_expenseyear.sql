
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expenseyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expenseyear]
GO

CREATE    TRIGGER [trigger_u_expenseyear] ON [expenseyear] FOR UPDATE
AS BEGIN
IF UPDATE(idfin) OR
UPDATE(idupb) OR
UPDATE(amount)
BEGIN
	DECLARE @ybalance int	
	EXECUTE trg_yearbalance 'E', @ybalance OUTPUT	

	DECLARE @ayear int
	DECLARE @parentidexp int
	DECLARE @idexp int
	DECLARE @flagarrear char(1)
	DECLARE @nphase tinyint
	DECLARE @newidfin int
	DECLARE @newidupb varchar(36)
	DECLARE @newamount decimal(19,2)

	SELECT
		@idexp = INS.idexp, 
		@parentidexp = E.parentidexp,
		@ayear = INS.ayear, 
		@nphase = E.nphase, 
		@newidfin = INS.idfin, 
		@newidupb = INS.idupb,
		@newamount = INS.amount,
		@flagarrear =
 		CASE
			WHEN ((ET.flag&1)=0) THEN 'C'
			WHEN ((ET.flag&1)=1) THEN 'R'
		END
	FROM inserted INS
	JOIN expense E
		ON E.idexp = INS.idexp
	JOIN expensetotal ET
		ON ET.idexp = INS.idexp
		AND ET.ayear = INS.ayear

	DECLARE @oldidfin int
	DECLARE @oldidupb varchar(36)
	DECLARE @oldamount decimal(19,2)
	SELECT @oldidfin = idfin, 
		@oldidupb = idupb,
		@oldamount = -amount
	FROM deleted

	DECLARE @finphase tinyint
	SELECT @finphase = expensefinphase FROM uniconfig

	DECLARE @paymentphase tinyint
	SELECT @paymentphase = MAX(nphase) FROM expensephase

	DECLARE @variationsamount decimal(19,2)
	SELECT @variationsamount = curramount + @oldamount 
	FROM expensetotal WHERE idexp = @idexp AND ayear = @ayear
	
	DECLARE @oldcurrentamount decimal(19,2)
	SELECT @oldcurrentamount = @oldamount - @variationsamount

	DECLARE @newcurrentamount decimal(19,2)
	SELECT @newcurrentamount = @newamount + @variationsamount

	IF (@nphase >= @finphase) AND
	((@newidfin <> @oldidfin) OR (@newidupb <> @oldidupb))
	BEGIN
		EXECUTE trg_upd_upb
		'E',
		@idexp,
		@ayear, 
		@nphase, 
		@newidfin,
		@newidupb
	END
	IF @nphase = @finphase AND @newidfin <> @oldidfin
	BEGIN
		EXECUTE trg_upd_doc
		'S', -- Parte di bilancio
		@idexp,
		@ayear,
		@newidfin
	END	

				DECLARE @oldunderwritingamount decimal(19,2)
				DECLARE @newunderwritingamount decimal(19,2)
				DECLARE @idunderwriting int
				DECLARE @amount decimal(19,2)

	IF @nphase >= @finphase AND
	((@oldidfin <> @newidfin) OR (@oldidupb <> @newidupb))
	BEGIN
		-- Se è cambiata solo la voce di bilancio aggiorno solo UPBINCOMETOTAL
		EXECUTE trg_upd_upbmovtotal
		'E', 
		@oldidfin, 
		@oldidupb,
		@flagarrear, 
		@nphase, 
		@oldcurrentamount

		EXECUTE trg_upd_upbmovtotal
		'E', 
		@newidfin, 
		@newidupb,
		@flagarrear, 
		@nphase, 
		@newcurrentamount
		
		--	MPORTANTE 
		--  Se modifico idfin o idupb devo aggiornare il totalizzatore
			IF EXISTS(SELECT * FROM underwritingappropriation WHERE idexp = @idexp )
			BEGIN
				DECLARE #FinanziamentiCollegati INSENSITIVE CURSOR FOR
				SELECT idunderwriting, amount
				FROM underwritingappropriation
				WHERE idexp = @idexp 

				FOR READ ONLY
				OPEN #FinanziamentiCollegati

				FETCH NEXT FROM #FinanziamentiCollegati INTO @idunderwriting, @amount
				WHILE (@@FETCH_STATUS = 0)
				BEGIN
						SET @oldunderwritingamount = - @amount
						SET @newunderwritingamount = @amount
					
						EXECUTE trg_upd_underwritingmovtotal		
						'E', 
						@idunderwriting, 
						@oldidupb,
						@oldidfin,
						@flagarrear, 
						@nphase, 
						@oldunderwritingamount

						EXECUTE trg_upd_underwritingmovtotal		
						'E', 
						@idunderwriting, 
						@newidupb,
						@newidfin,
						@flagarrear, 
						@nphase, 
						@newunderwritingamount
					FETCH NEXT FROM #FinanziamentiCollegati INTO @idunderwriting, @amount
				END
				CLOSE #FinanziamentiCollegati
				DEALLOCATE #FinanziamentiCollegati
			END
 

 		--  Idem per  underwritingpayment
			IF EXISTS(SELECT * FROM underwritingpayment WHERE idexp = @idexp )
			BEGIN
				DECLARE @idunderwritingPay int
				DECLARE @oldunderwritingamountPay decimal(19,2)
				DECLARE @newunderwritingamountPay decimal(19,2)
				DECLARE @amountPay decimal(19,2)
				DECLARE #FinanziamentiCollegatiPay INSENSITIVE CURSOR FOR
				SELECT idunderwriting, amount
				FROM underwritingpayment
				WHERE idexp = @idexp 

				FOR READ ONLY
				OPEN #FinanziamentiCollegatiPay

				FETCH NEXT FROM #FinanziamentiCollegatiPay INTO @idunderwriting, @amount
				WHILE (@@FETCH_STATUS = 0)
				BEGIN
						SET @oldunderwritingamount = - @amount
						SET @newunderwritingamount = @amount
					
						EXECUTE trg_upd_underwritingmovtotal		
						'E', 
						@idunderwriting, 
						@oldidupb,
						@oldidfin,
						@flagarrear, 
						@nphase, 
						@oldunderwritingamount

						EXECUTE trg_upd_underwritingmovtotal		
						'E', 
						@idunderwriting, 
						@newidupb,
						@newidfin,
						@flagarrear, 
						@nphase, 
						@newunderwritingamount
					FETCH NEXT FROM #FinanziamentiCollegatiPay INTO @idunderwriting, @amount
				END
				CLOSE #FinanziamentiCollegatiPay
				DEALLOCATE #FinanziamentiCollegatiPay
			END
  
		--stessa cosa, con expensevar, ove idunderwriting not null
		IF ((@nphase = @finphase) OR  (@nphase = @paymentphase) ) AND 
				EXISTS(SELECT * FROM expensevar WHERE idexp = @idexp and yvar= @ayear and idunderwriting is not null)
			BEGIN
				DECLARE #varFinanziamentiCollegati INSENSITIVE CURSOR FOR
				SELECT idunderwriting, amount
				FROM expensevar 
				WHERE idexp = @idexp and yvar= @ayear and idunderwriting is not null
				

				FOR READ ONLY
				OPEN #varFinanziamentiCollegati

				FETCH NEXT FROM #varFinanziamentiCollegati INTO @idunderwriting, @amount
				WHILE (@@FETCH_STATUS = 0)
				BEGIN
						SET @oldunderwritingamount = - @amount
						SET @newunderwritingamount = @amount
					
						EXECUTE trg_upd_underwritingmovtotal		
						'E', 
						@idunderwriting, 
						@oldidupb,
						@oldidfin,
						@flagarrear, 
						@nphase, 
						@oldunderwritingamount

						EXECUTE trg_upd_underwritingmovtotal		
						'E', 
						@idunderwriting, 
						@newidupb,
						@newidfin,
						@flagarrear, 
						@nphase, 
						@newunderwritingamount
					FETCH NEXT FROM #varFinanziamentiCollegati INTO @idunderwriting, @amount
				END
				CLOSE #varFinanziamentiCollegati
				DEALLOCATE #varFinanziamentiCollegati
			END


	END

	IF (@nphase >= @finphase)
	AND (@newidfin = @oldidfin)
	AND (@newidupb = @oldidupb)
	AND (ABS(@oldcurrentamount) <> @newcurrentamount)
	BEGIN
		DECLARE @diff decimal(19,2)
		SET @diff = @oldcurrentamount + @newcurrentamount
		EXECUTE trg_upd_upbmovtotal 
		'e', 
		@oldidfin, @oldidupb,
		@flagarrear, 
		@nphase, 
		@diff
	END

	IF @newamount <> -@oldamount OR
	(@newamount IS NULL AND @oldamount IS NOT NULL) OR
	(@newamount IS NOT NULL AND @oldamount IS NULL)
	BEGIN
		EXECUTE trg_upd_amount 
		@ayear, 
		'E', 
		@parentidexp,
		@idexp,
		@newamount, 
		@oldamount
	END


declare @amountPos decimal(19,2) 
	SET @amountPos= -@oldamount
	
--- Aggiorniamo il totalizzatore del saldo iniziale
IF (@nphase = @paymentphase) AND 
	((isnull(@newamount,0) != isnull(@amountPos,0)) OR
	(@newamount IS NULL AND @amountPos IS NOT NULL) OR
	(@newamount IS NOT NULL AND @amountPos IS NULL))
Begin	
	DECLARE @idtreasurer int
	SELECT 
		@idtreasurer = payment.idtreasurer 
	FROM payment 
	JOIN expenselast
		on payment.kpay = expenselast.kpay
	WHERE payment.ypay = @ayear
		and expenselast.idexp = @idexp
		
	IF (@idtreasurer is not null)
	BEGIN
		EXEC trg_upd_treasurercashtotal
		@ayear,
		@idtreasurer,
		'E',
		@amountPos,
		@newamount
		
	END
End

	IF @ayear = @ybalance AND 
	(@newamount != @oldamount OR
	(@newamount IS NULL AND @oldamount IS NOT NULL) OR
	(@newamount IS NOT NULL AND @oldamount IS NULL))
	BEGIN
		IF @nphase < @paymentphase
		BEGIN
			EXECUTE trg_evaluatearrears
			'E',
			@idexp,
			@ayear,
			@nphase
		END
		ELSE
		BEGIN
			DECLARE @currentphase tinyint
			DECLARE @idcurrentexp int
			SET @idcurrentexp = @idexp
			SELECT @currentphase = (@paymentphase - 1)
			WHILE @currentphase > 0 
			BEGIN
				SELECT @idcurrentexp = idparent FROM expenselink WHERE idchild = @idcurrentexp
					AND nlevel = @currentphase

				EXECUTE trg_evaluatearrears
				'E',
				@idcurrentexp,
				@ayear,
				@currentphase
	
				SELECT @currentphase = @currentphase - 1
			END

/*
			DECLARE @currentphase tinyint
			DECLARE @idcurrentexp int
			SET @idcurrentexp = @idexp
			SELECT @currentphase = 1
			WHILE @currentphase < @paymentphase
			BEGIN
				SELECT @idcurrentexp = idparent FROM expenselink WHERE idchild = @idexp
					AND nlevel = @currentphase

				EXECUTE trg_evaluatearrears
				'E',
				@idcurrentexp,
				@ayear,
				@currentphase

				SELECT @currentphase = @currentphase + 1
			END
*/
		END
	END
END
END







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

