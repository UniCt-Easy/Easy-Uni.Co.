SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_expenselast]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_expenselast]
GO

CREATE TRIGGER [trigger_i_expenselast] ON [expenselast] FOR INSERT
AS BEGIN 

	DECLARE @idexp int
	DECLARE @kpay int
	SELECT	@idexp = idexp,
			@kpay = kpay
	FROM inserted

	DECLARE @idtreasurer int
	DECLARE @ypay int
	SELECT 
		@idtreasurer = idtreasurer, 
		@ypay = ypay
	FROM payment 
	WHERE kpay = @kpay
	
	-- Considero l'importo corrente del movimento di spesa inserito nel mandato di pagamento 
	-- vado cos� a considerare tutte le variazioni eventualmente inserite fino a quel momento
	DECLARE @amount decimal(19,2)
	--SELECT @amount = ISNULL(amount,0)	FROM expenseyear	WHERE expenseyear.ayear = @ypay	AND expenseyear.idexp = @idexp
	
	

	if (@idtreasurer is not null)
	BEGIN
		SELECT @amount = ISNULL(curramount,0)	FROM expensetotal	WHERE expensetotal.ayear = @ypay	AND expensetotal.idexp = @idexp

		if (isnull(@amount,0) <>0) begin
			EXEC trg_upd_treasurercashtotal		@ypay,		@idtreasurer,		'E',		0,		@amount
		end
	END







END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


