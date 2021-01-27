
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
 
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_expenseyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_expenseyear]
GO

CREATE    TRIGGER [trigger_d_expenseyear] ON [expenseyear] FOR DELETE
AS BEGIN
IF @@ROWCOUNT > 0
BEGIN
	DECLARE @ybalance int	
	EXECUTE trg_yearbalance 'E', @ybalance OUTPUT	

	DECLARE @finphase tinyint
	SELECT  @finphase = expensefinphase FROM uniconfig

	DECLARE @paymentphase tinyint
	SELECT  @paymentphase = MAX(nphase) FROM expensephase

	DECLARE @idexp int
	DECLARE @ayear int
	DECLARE @amount decimal(19,2)
	DECLARE @idfin int
	DECLARE @idupb varchar(36)
	DECLARE @flagarrear char(1)
	DECLARE @nphase tinyint
	DECLARE @parentidexp int

	-- dobbiamo essere certi che esista expense in caso la riga sia stata già cancellata non verranno eseguiti pezzi 
	-- del trigger che però replicheremo come esecuzione nel trigger in delete su expense
	SELECT
		@idexp = D.idexp, @ayear = D.ayear, @idfin = D.idfin, @idupb = D.idupb,
		@nphase = I.nphase, @amount = - IT.curramount,
		@flagarrear = 
		CASE
			WHEN ((IT.flag&1)=0) THEN 'C'
			WHEN ((IT.flag&1)=1) THEN 'R'
		END,
		@parentidexp = I.parentidexp
	FROM deleted D
	JOIN expensetotal IT
		ON IT.idexp = D.idexp
		AND IT.ayear = D.ayear
	LEFT OUTER JOIN expense I
		ON I.idexp = D.idexp
	
	IF (@idfin IS NOT NULL)	AND (@nphase IS NOT NULL)
	BEGIN
		EXECUTE trg_upd_upbmovtotal 
		'E', 
		@idfin, 
		@idupb,
		@flagarrear, 
		@nphase, 
		@amount
	END
	--	MPORTANTE 
	--  Se modifico idfin o idupb devo aggiornare il totalizzatore
		IF EXISTS(SELECT * FROM underwritingappropriation WHERE idexp = @idexp )
		BEGIN
			DECLARE @idunderwriting int
			DECLARE @amountunderwriting decimal(19,2)
			DECLARE #FinanziamentiCollegati INSENSITIVE CURSOR FOR
			SELECT idunderwriting, - amount
			FROM underwritingappropriation
			WHERE idexp = @idexp 

			FOR READ ONLY
			OPEN #FinanziamentiCollegati

			FETCH NEXT FROM #FinanziamentiCollegati INTO @idunderwriting, @amountunderwriting
			WHILE (@@FETCH_STATUS = 0)
			BEGIN
				
					EXECUTE trg_upd_underwritingmovtotal		
					'E', 
					@idunderwriting, 
					@idupb,
					@idfin,
					@flagarrear, 
					@nphase, 
					@amountunderwriting

				FETCH NEXT FROM #FinanziamentiCollegati INTO @idunderwriting, @amountunderwriting
			END
			CLOSE #FinanziamentiCollegati
			DEALLOCATE #FinanziamentiCollegati
		END
--Idem per underwritingpayment
		IF EXISTS(SELECT * FROM underwritingpayment WHERE idexp = @idexp )
		BEGIN
			DECLARE @idunderwritingPay int
			DECLARE @underwritingamountPay decimal(19,2)
			DECLARE #FinanziamentiCollegatiPay INSENSITIVE CURSOR FOR
			SELECT idunderwriting, - amount
			FROM underwritingpayment
			WHERE idexp = @idexp 

			FOR READ ONLY
			OPEN #FinanziamentiCollegatiPay

			FETCH NEXT FROM #FinanziamentiCollegatiPay INTO @idunderwritingPay, @underwritingamountPay
			WHILE (@@FETCH_STATUS = 0)
			BEGIN
				
					EXECUTE trg_upd_underwritingmovtotal		
					'E', 
					@idunderwritingPay, 
					@idupb,
					@idfin,
					@flagarrear, 
					@paymentphase, 
					@underwritingamountPay

				FETCH NEXT FROM #FinanziamentiCollegatiPay INTO @idunderwritingPay, @underwritingamountPay
			END
			CLOSE #FinanziamentiCollegatiPay
			DEALLOCATE #FinanziamentiCollegatiPay
		END
					
	EXECUTE trg_del_amount 
	@ayear, 
	'E', 
	@idexp,
	@parentidexp,
	@nphase,
	@amount

--- Aggiorniamo il totalizzatore del saldo iniziale
IF (@nphase = @paymentphase)
Begin
	DECLARE @idtreasurer int
	SELECT 
		@idtreasurer = payment.idtreasurer 
	FROM payment 
	JOIN expenselast
		on payment.kpay = expenselast.kpay
	WHERE ypay = @ayear
		and expenselast.idexp = @idexp
		
	declare @amountPos decimal(19,2) 
	SET @amountPos= -@amount
	IF (@idtreasurer is not null)
	BEGIN
		EXEC trg_upd_treasurercashtotal
		@ayear,
		@idtreasurer,
		'E',
		@amountPos,
		0
	END
End

	IF @ayear = @ybalance
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

