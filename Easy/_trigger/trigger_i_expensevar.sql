
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_expensevar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_expensevar]
GO

CREATE TRIGGER [trigger_i_expensevar] ON expensevar FOR INSERT
AS BEGIN
	DECLARE @finphase tinyint
	SELECT  @finphase = expensefinphase FROM uniconfig

	DECLARE @paymentphase tinyint	
	SELECT  @paymentphase = MAX(nphase) FROM expensephase

	DECLARE @ybalance int	
	EXECUTE trg_yearbalance 'E', @ybalance OUTPUT	
	DECLARE @idexp int
	DECLARE @yvar int
	DECLARE @amount decimal(19,2)
	DECLARE @lu varchar(64)
	DECLARE @lt datetime
	DECLARE @idunderwriting int
		
	SELECT
		@yvar = yvar, 
		@idexp = idexp, 
		@amount = amount,
		@idunderwriting = idunderwriting,
		@lu = lu,
		@lt = lt
	FROM inserted

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

	EXECUTE trg_amount_variation
	@yvar,
	'E',
	@idexp,
	@parentidexp,
	@nphase,
	0,
	@amount
	
	DECLARE @kpay int
	DECLARE @idtreasurer int
	
	SELECT @kpay = kpay FROM expenselast 
	WHERE idexp = @idexp
	
	SELECT @idtreasurer = idtreasurer 
	FROM payment WHERE kpay = @kpay
	
	if (@kpay IS NOT NULL and @idtreasurer IS NOT NULL) BEGIN
		-- Ricalcolo del Fondo di Cassa del Tesoriere corrispondente
		EXEC trg_upd_treasurercashtotal
		@yvar,
		@idtreasurer,
		'E',
		0,
		@amount
	END
	

	DECLARE @ymovpar int
	SELECT @ymovpar = expense.ymov 
	FROM expenselink
	JOIN expense
	ON expenselink.idparent = expense.idexp
	WHERE idchild = @idexp
		AND nlevel = @finphase

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
			@amount
		END
		ELSE
		BEGIN
			EXECUTE trg_upd_upbmovtotal 
			'E', 
			@idfin, 
			@idupb,
			'R', 
			@nphase, 
			@amount
		END
	END

	IF @idunderwriting IS NOT NULL
	BEGIN
		IF (@ymovpar = @yvar)
		BEGIN
			EXECUTE trg_upd_underwritingmovtotal 
			'E', 
			@idunderwriting,
			@idupb,
			@idfin,
			'C', 
			@nphase, 
			@amount
		END
		ELSE
		BEGIN
			EXECUTE trg_upd_underwritingmovtotal 
			'E', 
			@idunderwriting,
			@idupb,
			@idfin,
			'R', 
			@nphase, 
			@amount
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
/*
			DECLARE @currentphase tinyint
			DECLARE @idcurrentexp int
			SET @idcurrentexp = @idexp
			SELECT @currentphase = 1
			WHILE @currentphase < @paymentphase
			BEGIN
				SELECT @idcurrentexp = idparent FROM expenselink WHERE idchild = @idcurrentexp
					AND nlevel = @currentphase

				EXECUTE trg_evaluatearrears
				'E',
				@idcurrentexp,
				@yvar,
				@currentphase
	
				SELECT @currentphase = @currentphase + 1
			END
*/
		END
	END
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

