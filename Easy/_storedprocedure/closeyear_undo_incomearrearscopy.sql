
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


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

 
