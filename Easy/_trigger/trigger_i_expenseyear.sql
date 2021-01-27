
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_expenseyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_expenseyear]
GO

CREATE   TRIGGER [trigger_i_expenseyear] ON [expenseyear] FOR INSERT
AS BEGIN
	DECLARE @finphase int
	SET @finphase =1 -- expensefinphase FROM uniconfig

	DECLARE @paymentphase tinyint
	SELECT @paymentphase = MAX(nphase) FROM expensephase

	DECLARE @ybalance int
	SELECT @ybalance = max(ayear) FROM accountingyear WHERE ((flag&0x0F)>=5) 
	--EXECUTE trg_yearbalance 'E', @ybalance OUTPUT	

	DECLARE @idexp int
	DECLARE @ayear int
	DECLARE @nphase tinyint
	DECLARE @idfin int
	DECLARE @idupb varchar(36)
	DECLARE @amount decimal(19,2)	
	DECLARE @ymov int
	DECLARE @parentidexp int

	SELECT @idexp = inserted.idexp, 
	@ayear = inserted.ayear, 
	@nphase = expense.nphase, 
	@idfin = inserted.idfin, 
	@idupb = inserted.idupb,
	@amount = inserted.amount,
	@ymov = expense.ymov,
	@parentidexp = expense.parentidexp
	FROM inserted
	JOIN expense	ON expense.idexp = inserted.idexp

	if (@idexp is null) return 
	
	DECLARE @ymovpar int
	SELECT @ymovpar = expense.ymov 
	FROM expenselink
	JOIN expense 	ON expenselink.idparent = expense.idexp
	WHERE idchild = @idexp		AND nlevel = @finphase

	DECLARE @firstyear tinyint
	SET @firstyear = CASE WHEN @ymov = @ayear THEN 2 ELSE 0 END

	DECLARE @ymovparfin int
	SELECT @ymovparfin = expense.ymov 
		FROM expenselink
		JOIN expense	ON expenselink.idparent = expense.idexp
	WHERE idchild = @idexp 	AND nlevel = @finphase
	
	--IF @idfin IS NOT NULL
	--BEGIN
		IF (@ymovparfin = @ayear)
		BEGIN

			EXECUTE trg_ins_amount 	@ayear, 'E', @idexp, @parentidexp, 	@amount, 	0, -- Competenza
										@firstyear

			EXECUTE trg_upd_upbmovtotal 'E', @idfin, @idupb, 'C', 	@nphase, 	@amount
		END
		ELSE
		BEGIN
			EXECUTE trg_ins_amount 	@ayear, 'E', @idexp,@parentidexp,	@amount, 1, -- Residuo
										@firstyear

			EXECUTE trg_upd_upbmovtotal  'E', 	@idfin, @idupb,	'R', @nphase, 	@amount
		END
	--END
	--ELSE
	--BEGIN
	--		EXECUTE trg_ins_amount 		@ayear, 'E', @idexp, @parentidexp,@amount, 	0,	@firstyear
	--END

	IF @ayear = @ybalance
	BEGIN
		IF @nphase < @paymentphase
		BEGIN
			--EXECUTE trg_evaluatearrears 'E',@idexp,	@ayear,	@nphase
			execute trg_updatearrears 'E',@idexp,	@ayear,	@nphase,@idfin,@idupb,@amount
		END
		ELSE
		BEGIN
			SET @amount=-@amount
			SET @nphase = @nphase-1
			WHILE @nphase > 0 
			BEGIN
				SELECT @idexp = parentidexp FROM expense WHERE idexp = @idexp
					
				--EXECUTE trg_evaluatearrears 'E',@idcurrentexp,@ayear,@currentphase
				execute trg_updatearrears 'E',@idexp,	@ayear,	@nphase,@idfin,@idupb,@amount

				SET @nphase = @nphase-1
			END


		END
	END


	IF (@nphase = @paymentphase) AND exists(select * from expenselast where idexp=@idexp) BEGIN

		DECLARE @idtreasurer int
		set @idtreasurer=null
		DECLARE @ypay int
		DECLARE @curramount decimal(19,2)

		SELECT 		@idtreasurer = idtreasurer, 	@ypay = ypay
			FROM payment 
			join expenselast on payment.kpay=expenselast.kpay
			WHERE expenselast.idexp= @idexp

		if (@idtreasurer is not null)
		BEGIN			

			EXEC trg_upd_treasurercashtotal		@ypay,		@idtreasurer,		'E',		0,		@amount
		END

	END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

