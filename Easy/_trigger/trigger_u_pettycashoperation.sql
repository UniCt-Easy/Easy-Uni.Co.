SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_pettycashoperation]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_pettycashoperation]
GO


CREATE TRIGGER [trigger_u_pettycashoperation] ON [pettycashoperation] FOR UPDATE
AS BEGIN
IF UPDATE(adate)
BEGIN
	DECLARE @newadate datetime
	DECLARE @idinvkind int
	DECLARE @yinv int
	DECLARE @ninv int
	DECLARE @idpettycash int
	DECLARE @yoperation int
	DECLARE @noperation int

	SELECT 	@idpettycash = idpettycash,
		@yoperation = yoperation,
		@noperation = noperation,
		@newadate = adate
	FROM inserted

	SELECT 
		@idinvkind = idinvkind, 
		@yinv = yinv, 
		@ninv = ninv
	FROM pettycashoperationinvoice
	WHERE idpettycash = @idpettycash
		AND yoperation=@yoperation 
		AND noperation = @noperation

	UPDATE 	invoicedetail
	SET paymentcompetency= @newadate
	WHERE 	idinvkind = @idinvkind  
		AND yinv = @yinv 
		AND ninv = @ninv
END
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

