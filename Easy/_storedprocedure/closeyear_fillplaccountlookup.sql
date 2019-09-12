if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_fillplaccountlookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_fillplaccountlookup]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE closeyear_fillplaccountlookup
(
	@ayear int
)
AS BEGIN
CREATE TABLE #lookup (oldidplaccount varchar(31), newidplaccount varchar(31))
	
INSERT #lookup
SELECT oldplaccount.idplaccount, placcountlookup.newidplaccount
FROM placcount oldplaccount
LEFT OUTER JOIN placcountlookup 
	ON oldplaccount.idplaccount = placcountlookup.oldidplaccount
WHERE oldplaccount.ayear = @ayear

DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
UPDATE #lookup
SET newidplaccount =
	SUBSTRING(@nextayearstr, 3, 2)
	+ SUBSTRING(oldidplaccount, 3, 29)
WHERE newidplaccount IS NULL

SELECT * FROM #lookup

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

