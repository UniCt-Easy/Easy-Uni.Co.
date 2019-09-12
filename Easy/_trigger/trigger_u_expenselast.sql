
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expenselast]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expenselast]
GO

CREATE TRIGGER [trigger_u_expenselast] ON [expenselast] FOR UPDATE
AS BEGIN
IF UPDATE(kpay)
BEGIN
	
	DECLARE @idexp int
	DECLARE @newkpay int
	DECLARE @oldkpay int
	
	DECLARE @newamount decimal(19,2)
	SELECT  @idexp = idexp, @newkpay = kpay FROM inserted
	SELECT  @oldkpay = kpay FROM deleted
	
	DECLARE @idtreasurer int
	DECLARE @ypay int
	SELECT @idtreasurer = idtreasurer, @ypay = ypay
	FROM payment WHERE kpay = ISNULL(@newkpay,@oldkpay)
	
	-- Considero l'importo corrente del movimento di spesa inserito nel mandato di pagamento 
	-- vado cos� a considerare tutte le variazioni eventualmente inserite fino a quel momento
	SELECT @newamount = ISNULL(SUM(curramount),0)
	FROM expensetotal
	JOIN expenselast
		ON expensetotal.idexp = expenselast.idexp
	WHERE expensetotal.ayear = @ypay
		AND expenselast.idexp = @idexp
	
	-- caso inserimento nella reversale 
	if ((@newkpay is not null) and (@idtreasurer is not null))
	-- Ricalcolo del Fondo di Cassa del Tesoriere corrispondente
	BEGIN
		EXEC trg_upd_treasurercashtotal
		@ypay,
		@idtreasurer,
		'E',
		0,
		@newamount
	END
	
	if ((@oldkpay is not null) and (@idtreasurer is not null))
	-- Ricalcolo del Fondo di Cassa del Tesoriere corrispondente
	BEGIN
		EXEC trg_upd_treasurercashtotal
		@ypay,
		@idtreasurer,
		'E',
		@newamount,
		0	
	END

END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



