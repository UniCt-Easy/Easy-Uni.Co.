if exists (select * from dbo.sysobjects where id = object_id(N'[exp_reversaliufficiali_nontrasmesse]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_reversaliufficiali_nontrasmesse]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE  PROCEDURE [exp_reversaliufficiali_nontrasmesse] 
@ayear	int
AS
BEGIN


	SELECT 
		ypro AS 'Esercizio',
		npro AS 'Numero Reversale',
		printdate AS 'Data di Stampa',
		adate AS 'Data Contabile'
	FROM proceeds WHERE printdate IS NOT NULL
	AND kproceedstransmission IS NULL
	AND ((ypro = @ayear) OR (@ayear is null))
	
END


SET QUOTED_IDENTIFIER ON 


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO