if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_expense_bpcassinate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_expense_bpcassinate]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [trasmele_expense_bpcassinate]
(
	@y int,
	@n int
)
AS BEGIN
-- BPS Banca Popolare del Cassinate

DECLARE @transmissionkind char(1)
SELECT @transmissionkind      = transmissionkind
FROM   paymenttransmission 
WHERE  npaymenttransmission = @n
AND    ypaymenttransmission = @y


IF (ISNULL(@transmissionkind, 'I') = 'I')
BEGIN
	EXEC trasmele_expense_bpcassinate_ins @y,@n
END
IF (ISNULL(@transmissionkind, 'I') = 'V')
BEGIN
	EXEC trasmele_expense_bpcassinate_var @y,@n
END


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


