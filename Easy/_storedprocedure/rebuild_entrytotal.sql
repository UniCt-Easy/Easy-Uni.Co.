SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_entrytotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_entrytotal]
GO
-- exec rebuild_entrytotal 
-- select * from entrytotal
CREATE     PROCEDURE [rebuild_entrytotal]
(
	@ayear int = null
)
AS BEGIN

	IF (@ayear IS NULL) 
	BEGIN
		DELETE FROM entrytotal

		INSERT INTO entrytotal (yentry, nentry, amount) 
		SELECT   yentry, nentry, isnull(sum(amount),0)
		FROM entrydetail  
		GROUP BY yentry, nentry

	END
	ELSE -- @ayear specificato
	BEGIN 
		DELETE FROM entrytotal WHERE yentry = @ayear

		INSERT INTO entrytotal (yentry, nentry, amount) 
		SELECT   yentry, nentry, isnull(sum(amount),0)
		FROM entrydetail  
		WHERE yentry = @ayear
		GROUP BY yentry, nentry

	END

	
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO