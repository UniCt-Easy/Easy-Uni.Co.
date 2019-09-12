SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_pettycashoperationinvoice]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_pettycashoperationinvoice]
GO

CREATE    TRIGGER [trigger_d_pettycashoperationinvoice] ON pettycashoperationinvoice 
FOR DELETE 
AS
BEGIN
	DECLARE @idinvkind int
	DECLARE @yinv int
	DECLARE @ninv int

	SELECT 
		@idinvkind = idinvkind, 
		@yinv = yinv, 
		@ninv = ninv
	FROM deleted

	UPDATE 	invoicedetail
	SET paymentcompetency= NULL
	WHERE 	idinvkind = @idinvkind  
		AND yinv = @yinv 
		AND ninv = @ninv
	
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

