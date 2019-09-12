if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoice_split_errors]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoice_split_errors]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [exp_invoice_split_errors]
AS BEGIN
 
print 1
		
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 