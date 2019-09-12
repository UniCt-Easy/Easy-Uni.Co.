--setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_undo_incomearrearscopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_undo_incomearrearscopy]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE    PROCEDURE [closeyear_undo_incomearrearscopy]
(
	@ayear int
)
AS BEGIN
	
DECLARE @idinc 		int
 
DECLARE @nlevel 	tinyint
DECLARE @nphase 	tinyint
DECLARE @nextayear 	int

SET 	@nextayear = @ayear + 1
DECLARE @nextayearstr 	varchar(4)
SET 	@nextayearstr = CONVERT(varchar(4),@nextayear)

DECLARE @maxincomephase int
SELECT  @maxincomephase = MAX(nphase) FROM incomephase
DECLARE inc_crs INSENSITIVE CURSOR FOR
SELECT  income.idinc 
FROM 	incometotal
JOIN    income
	ON income.idinc= incometotal.idinc
WHERE   ayear = @ayear
	AND income.nphase < @maxincomephase
ORDER BY income.idinc
FOR READ ONLY
	
OPEN inc_crs
FETCH NEXT FROM inc_crs 
INTO @idinc 

WHILE (@@FETCH_STATUS = 0)
BEGIN
		IF   EXISTS(SELECT * FROM incomeyear WHERE idinc = @idinc AND ayear = @nextayear)
		BEGIN
			 DELETE FROM incomeyear WHERE idinc = @idinc AND AYEAR =  @nextayear 
		END
	FETCH NEXT FROM inc_crs 
	INTO @idinc 
END
CLOSE inc_crs
DEALLOCATE inc_crs
	

EXEC closeyear_undo_epaccarrearscopy @ayear

CREATE TABLE #info (msg varchar(800))
INSERT INTO #info VALUES('Il trasferimento dei residui attivi  all'' esercizio ' + @nextayearstr + ' è stato annullato' )

-- azzero i bit da 0 a 3 e imposto il valore 3 nell'esercizio corrente. 
UPDATE accountingyear SET flag = flag&0xF0 WHERE ayear = @ayear
UPDATE accountingyear SET flag = flag|0x03 WHERE ayear = @ayear
	
	
SELECT * FROM #info
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 