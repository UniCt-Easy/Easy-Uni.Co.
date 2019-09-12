if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_epexpyear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_epexpyear]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 

-- setuser 'amm'
-- rebuild_epexptotal 2016
-- rebuild_epexpyear 2016
CREATE    PROCEDURE [rebuild_epexpyear]
(
	@ayear int
)
AS BEGIN
SET NOCOUNT	 ON
DECLARE @idepexp int
DECLARE exp_crs INSENSITIVE CURSOR FOR
SELECT epexpyear.idepexp from epexpyear
WHERE epexpyear.ayear = @ayear	
ORDER BY epexpyear.idepexp
FOR READ ONLY

OPEN exp_crs
FETCH NEXT FROM exp_crs INTO @idepexp

WHILE (@@FETCH_STATUS = 0)
BEGIN
	exec trg_evaluatearrearsepexp @idepexp, @ayear
	

	FETCH NEXT FROM exp_crs INTO @idepexp
END
DEALLOCATE exp_crs
 
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
