if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_fillaccountlookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_fillaccountlookup]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE closeyear_fillaccountlookup
(
	@ayear int
)
AS BEGIN
CREATE TABLE #lookup (oldidacc varchar(38), newidacc varchar(38))
	
INSERT #lookup
SELECT oldacc.idacc, accountlookup.newidacc 
FROM account oldacc
LEFT OUTER JOIN accountlookup 
	ON oldacc.idacc = accountlookup.oldidacc
WHERE oldacc.ayear = @ayear
DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
UPDATE #lookup
SET newidacc =
	SUBSTRING(@nextayearstr, 3, 2)
	+ SUBSTRING(oldidacc, 3, 36)
WHERE newidacc IS NULL
SELECT * FROM #lookup
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

