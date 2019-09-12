if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_fillpatrimonylookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_fillpatrimonylookup]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE closeyear_fillpatrimonylookup
(
	@ayear int
)
AS BEGIN
CREATE TABLE #lookup (oldidpatrimony varchar(31), newidpatrimony varchar(31))
	
INSERT #lookup
SELECT oldpatrimony.idpatrimony, patrimonylookup.newidpatrimony 
FROM patrimony oldpatrimony
LEFT OUTER JOIN patrimonylookup 
	ON oldpatrimony.idpatrimony = patrimonylookup.oldidpatrimony
WHERE oldpatrimony.ayear = @ayear
DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
UPDATE #lookup
SET newidpatrimony =
	SUBSTRING(@nextayearstr, 3, 2)
	+ SUBSTRING(oldidpatrimony, 3, 29)
WHERE newidpatrimony IS NULL
SELECT * FROM #lookup
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

