--setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_undo_casualcontract]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_undo_casualcontract]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE closeyear_undo_casualcontract
(
	@ayear int
)
AS BEGIN
DECLARE @maxexpensephase int
SELECT @maxexpensephase = MAX(nphase) FROM expensephase
DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @ycon int
DECLARE @ncon int
DECLARE @feegross decimal(19,2)
DECLARE @cascon_crs cursor
SET @cascon_crs = CURSOR FOR
	SELECT ycon, ncon FROM casualcontract WHERE ycon <= @ayear 
		AND EXISTS
			(SELECT * FROM casualcontractyear
			WHERE casualcontract.ycon = casualcontractyear.ycon
				AND casualcontract.ncon = casualcontractyear.ncon
				AND ayear = @nextayear)
OPEN @cascon_crs
FETCH NEXT FROM @cascon_crs INTO @ycon, @ncon 
WHILE (@@FETCH_STATUS = 0)
BEGIN
		DELETE FROM  casualcontractyear  WHERE ayear = @nextayear
		AND ycon = @ycon  AND ncon=  @ncon 
	 
	FETCH NEXT FROM @cascon_crs into @ycon, @ncon
END
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

