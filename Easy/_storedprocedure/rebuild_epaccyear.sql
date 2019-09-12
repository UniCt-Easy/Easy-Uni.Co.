if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_epaccyear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_epaccyear]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amministrazione'
--rebuild_epaccyear 2016
CREATE    PROCEDURE [rebuild_epaccyear]
(
	@ayear int
)
AS BEGIN
	SET NOCOUNT	 ON
DECLARE @idepacc int


DECLARE exp_crs INSENSITIVE CURSOR FOR
SELECT epaccyear.idepacc from epaccyear
WHERE epaccyear.ayear = @ayear	
ORDER BY epaccyear.idepacc
FOR READ ONLY

OPEN exp_crs
FETCH NEXT FROM exp_crs INTO @idepacc

WHILE (@@FETCH_STATUS = 0)
BEGIN
	exec trg_evaluatearrearsepacc @idepacc, @ayear
	

	FETCH NEXT FROM exp_crs INTO @idepacc
END
DEALLOCATE exp_crs
 
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
