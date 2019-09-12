--setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_undo_epexparrearscopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_undo_epexparrearscopy]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
CREATE    PROCEDURE [closeyear_undo_epexparrearscopy]
(
	@ayear int
)
AS BEGIN
	
DECLARE @idepexp int
 
DECLARE @nphase tinyint
 
DECLARE @nextayear int

SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
DECLARE @maxexpensephase int
SET @maxexpensephase =  2

DECLARE exp_crs INSENSITIVE CURSOR FOR
SELECT epexp.idepexp 
FROM epexptotal
JOIN epexp
	ON epexp.idepexp = epexptotal.idepexp
WHERE ayear = @ayear
	AND epexp.nphase <= @maxexpensephase 
ORDER BY epexp.idepexp
FOR READ ONLY
OPEN exp_crs
FETCH NEXT FROM exp_crs INTO @idepexp
WHILE (@@FETCH_STATUS = 0)
	BEGIN
		DELETE FROM epexpyear  WHERE idepexp = @idepexp AND ayear =  @nextayear 
		FETCH NEXT FROM exp_crs INTO @idepexp 
    END
DEALLOCATE exp_crs 
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 