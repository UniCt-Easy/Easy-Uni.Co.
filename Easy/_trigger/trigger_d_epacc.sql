SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_epacc]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_epacc]
GO


CREATE   TRIGGER [trigger_d_epacc] ON [epacc] FOR DELETE
AS BEGIN

	DECLARE @idepacc int

	SELECT	@idepacc = idepacc
                
	FROM deleted
	
	DELETE FROM  epacctotal WHERE idepacc = @idepacc

	-- copiato da trigger_delete_expenseyear
	
	CREATE TABLE #epacc (idepacc int,  nphase tinyint)
	INSERT INTO #epacc (idepacc, nphase)
	SELECT idepacc,  nphase FROM deleted

    DELETE FROM epaccyear WHERE idepacc IN 
	(SELECT idepacc FROM #epacc) AND amount = 0

END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




