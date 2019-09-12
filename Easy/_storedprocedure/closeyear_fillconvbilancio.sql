if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_fillconvbilancio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_fillconvbilancio]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE closeyear_fillconvbilancio
(
	@ayear int
)
AS BEGIN
CREATE TABLE #lookup (oldidfin int, newidfin int)
	
INSERT #lookup
SELECT oldfin.idfin, finlookup.newidfin 
FROM fin oldfin
LEFT OUTER JOIN finlookup 
	ON oldfin.idfin = finlookup.oldidfin
WHERE oldfin.ayear = @ayear
DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)

SELECT * FROM #lookup
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

