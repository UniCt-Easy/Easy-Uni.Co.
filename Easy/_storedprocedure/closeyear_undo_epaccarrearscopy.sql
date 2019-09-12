if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_undo_epaccarrearscopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_undo_epaccarrearscopy]
GO

--setuser 'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE [closeyear_undo_epaccarrearscopy]
(
	@ayear int
)
AS BEGIN
	
DECLARE @idepacc int

DECLARE @nphase tinyint
DECLARE @nlevel tinyint

DECLARE @nextayear int

SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
DECLARE @maxexpensephase int
SET @maxexpensephase =  2

DECLARE acc_crs INSENSITIVE CURSOR FOR
SELECT epacc.idepacc 
FROM epacctotal
JOIN epacc
	ON epacc.idepacc = epacctotal.idepacc
WHERE ayear = @ayear
	AND epacc.nphase <= @maxexpensephase 
ORDER BY epacc.idepacc
FOR READ ONLY
	
OPEN acc_crs
FETCH NEXT FROM acc_crs INTO @idepacc 
WHILE (@@FETCH_STATUS = 0)
BEGIN
	DELETE  FROM epaccyear	 WHERE idepacc = @idepacc AND ayear =  @nextayear  
	FETCH NEXT FROM acc_crs INTO @idepacc 
END
DEALLOCATE acc_crs

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 