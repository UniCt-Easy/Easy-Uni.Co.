
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expensevar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expensevar]
GO

CREATE  TRIGGER [trigger_u_expensevar] ON [expensevar] FOR UPDATE
AS BEGIN
	DECLARE @ybalance int
	EXECUTE trg_yearbalance 'E', @ybalance OUTPUT	
	DECLARE @finphase tinyint
	SELECT @finphase = expensefinphase FROM uniconfig

	DECLARE @paymentphase tinyint
	SELECT @paymentphase = MAX(nphase) FROM expensephase

	DECLARE @yvar int
	DECLARE @newamount decimal(19,2)
	DECLARE @lu varchar(64)
	DECLARE @lt datetime
	DECLARE @idexp int
	DECLARE @oldidunderwriting int
	DECLARE @newidunderwriting int
	
	SELECT
		@yvar = yvar, 
		@idexp = idexp, 
		@newamount = amount,
		@newidunderwriting = idunderwriting,
		@lu = lu,
		@lt = lt
	FROM inserted

	DECLARE @oldamount decimal(19,2)
	DECLARE @origamount decimal(19,2)
	SELECT @oldamount = -amount, @origamount = amount, @oldidunderwriting=idunderwriting
	FROM deleted

	DECLARE @nphase tinyint
	DECLARE @idfin int
	DECLARE @idupb varchar(36)
	DECLARE @parentidexp int

	SELECT
		@idfin = expenseyear.idfin,
		@idupb = expenseyear.idupb,
		@nphase = expense.nphase,
		@parentidexp = expense.parentidexp
	FROM expenseyear
	JOIN expense
		ON expense.idexp = expenseyear.idexp
	WHERE expense.idexp = @idexp
		AND ayear = @yvar

	DECLARE @ymovpar int
	SELECT @ymovpar = expense.ymov 
	FROM expenselink
	JOIN expense
	ON expenselink.idparent = expense.idexp
	WHERE idchild = @idexp
		AND nlevel = @finphase
		
IF UPDATE(amount)
Begin
	EXECUTE trg_amount_variation
			@yvar,
			'E',
			@idexp,
			@parentidexp,
			@nphase,
			@oldamount,
			@newamount
				
	DECLARE @kpay int
	DECLARE @idtreasurer int
	
	SELECT @kpay =  kpay FROM expenselast 
	WHERE idexp = @idexp
	
	SELECT @idtreasurer = idtreasurer 
	FROM payment WHERE kpay = @kpay
	
	if (@kpay IS NOT NULL and @idtreasurer IS NOT NULL) BEGIN
		-- Ricalcolo del Fondo di Cassa del Tesoriere corrispondente
		EXEC trg_upd_treasurercashtotal
		@yvar,
		@idtreasurer,
		'E',
		@origamount,
		@newamount
	END
	

	IF @idfin IS NOT NULL
	BEGIN
		IF (@ymovpar = @yvar)
		BEGIN
			EXECUTE trg_upd_upbmovtotal 
			'E', 
			@idfin, 
			@idupb,
			'C', 
			@nphase, 
			@oldamount

			EXECUTE trg_upd_upbmovtotal 
			'E',
			@idfin, 
			@idupb,
			'C', 
			@nphase, 
			@newamount
		END
		ELSE
		BEGIN
			EXECUTE trg_upd_upbmovtotal 
			'E',
			@idfin, 
			@idupb,
			'R', 
			@nphase, 
			@oldamount

			EXECUTE trg_upd_upbmovtotal 
			'E', 
			@idfin, 
			@idupb,
			'R', 
			@nphase, 
			@newamount
		END
	END
	
		IF @yvar = @ybalance
	BEGIN
		IF @nphase < @paymentphase
		BEGIN
			EXECUTE trg_evaluatearrears
			'E',
			@idexp,
			@yvar,
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
				@yvar,
				@currentphase
	
				SELECT @currentphase = @currentphase - 1
			END
		END
	END
	
End --> End : IF UPDATE(amount)


IF (UPDATE(idunderwriting) OR  UPDATE(amount))
Begin
	IF @oldidunderwriting IS NOT NULL
	BEGIN
		IF (@ymovpar = @yvar)
		BEGIN
			EXECUTE trg_upd_underwritingmovtotal 
			'E', 
			@oldidunderwriting,
			@idupb,
			@idfin,
			'C', 
			@nphase, 
			@oldamount
			
		END
		ELSE
		BEGIN
			EXECUTE trg_upd_underwritingmovtotal 
			'E',
			@oldidunderwriting,
			@idupb,
			@idfin,
			'R', 
			@nphase, 
			@oldamount
			
		END
	END
	
	IF @newidunderwriting IS NOT NULL
	BEGIN
		IF (@ymovpar = @yvar)
		BEGIN
			
			EXECUTE trg_upd_underwritingmovtotal 
			'E',
			@newidunderwriting,
			@idupb,
			@idfin,
			'C', 
			@nphase, 
			@newamount
		END
		ELSE
		BEGIN			

			EXECUTE trg_upd_underwritingmovtotal 
			'E', 
			@newidunderwriting,
			@idupb,
			@idfin,
			'R', 
			@nphase, 
			@newamount
		END
	END
End -- End : IF (UPDATE(idunderwriting) OR UPDATE(amount))


	

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

