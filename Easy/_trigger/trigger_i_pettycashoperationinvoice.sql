SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_pettycashoperationinvoice]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_pettycashoperationinvoice]
GO

CREATE TRIGGER [trigger_i_pettycashoperationinvoice] ON [pettycashoperationinvoice] FOR INSERT
AS BEGIN
	DECLARE @idinvkind int
	DECLARE @yinv int
	DECLARE @ninv int
	DECLARE @idpettycash int
	DECLARE @yoperation int
	DECLARE @noperation int

	SELECT 
		@idinvkind = idinvkind, 
		@yinv = yinv, 
		@ninv = ninv,
		@idpettycash = idpettycash,
		@yoperation = yoperation,
		@noperation = noperation
	FROM inserted

	DECLARE @adate datetime
	
	SELECT @adate = adate 
	FROM pettycashoperation
	WHERE idpettycash = @idpettycash
		AND yoperation=@yoperation 
		AND noperation = @noperation
	
	UPDATE 	invoicedetail
	SET paymentcompetency= @adate
	WHERE 	idinvkind = @idinvkind  
		AND yinv = @yinv 
		AND ninv = @ninv
	

	
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

