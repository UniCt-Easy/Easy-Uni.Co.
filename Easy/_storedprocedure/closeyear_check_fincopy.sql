if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_check_fincopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_check_fincopy]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [closeyear_check_fincopy]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #errors (errordescr varchar(255))
DECLARE @nextayear int
SET @nextayear = @ayear + 1
	
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4), @nextayear)

DECLARE @unifiedfinlevel int
SET @unifiedfinlevel = ISNULL((SELECT unifiedfinlevel FROM commonconfig WHERE ayear = @nextayear),0)

DECLARE @minlevop tinyint
SELECT  @minlevop = MIN(nlevel) FROM finlevel WHERE flag&2 <> 0 AND ayear = @nextayear 

IF EXISTS (SELECT * FROM finlevel WHERE ayear = @nextayear AND nlevel > @minlevop AND nlevel > @unifiedfinlevel)
BEGIN
	INSERT INTO #errors VALUES('Livelli del bilancio annuale per esercizio ' + @nextayearstr + ' esistenti.')
END
IF EXISTS (SELECT * FROM fin WHERE ayear = @nextayear AND nlevel > @minlevop AND nlevel > @unifiedfinlevel)
BEGIN
	INSERT INTO #errors VALUES('Voci del bilancio annuale per esercizio ' + @nextayearstr + ' esistenti.')
END
IF EXISTS (SELECT * FROM sortingprev WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Previsioni classificazioni movimenti per esercizio ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM underwritingyear WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Finanziamenti per esercizio ' + @nextayearstr + ' esistenti.')
END

SELECT * FROM #errors
END
 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

