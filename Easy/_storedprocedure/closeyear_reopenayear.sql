if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_reopenayear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_reopenayear]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE         PROCEDURE [closeyear_reopenayear]
(
	@ayear int,
	@kind char(1)
)
AS BEGIN
IF @kind = 'F'
BEGIN
	--azzero i bit da 0 a 3 e poi imposto il valore 5 su questi flag
	UPDATE accountingyear SET flag = flag&0xF0 WHERE ayear = @ayear
	UPDATE accountingyear SET flag = flag|0x05 WHERE ayear = @ayear
END
IF @kind = 'P'
BEGIN
	--azzero il bit 4
	UPDATE accountingyear SET flag = flag&0xEF WHERE ayear = @ayear
END
IF @kind = 'E'
BEGIN
	--azzero il bit 5
	UPDATE accountingyear SET flag = flag&0xDF WHERE ayear = @ayear
END
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



