
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
if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_undo_expensearrearscopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_undo_expensearrearscopy]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 

CREATE    PROCEDURE [closeyear_undo_expensearrearscopy]
(
	@ayear int
)
AS BEGIN
	
DECLARE @idexp int
DECLARE @idfin  int
DECLARE @idupb varchar(36)
DECLARE @nphase tinyint
DECLARE @nlevel tinyint
DECLARE @curramount decimal(19,2)
DECLARE @available decimal(19,2)
DECLARE @payed decimal(19,2)
DECLARE @newidfin int
DECLARE @nextayear int

SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
DECLARE @maxexpensephase int
SELECT @maxexpensephase =  MAX(nphase) FROM expensephase

DECLARE exp_crs INSENSITIVE CURSOR FOR
SELECT expense.idexp
FROM expensetotal
JOIN expense
	ON expense.idexp = expensetotal.idexp
WHERE ayear = @ayear
	AND expense.nphase < @maxexpensephase 
ORDER BY expense.idexp
FOR READ ONLY

	
OPEN exp_crs
FETCH NEXT FROM exp_crs INTO @idexp  
WHILE (@@FETCH_STATUS = 0)
BEGIN
	IF  EXISTS
		(SELECT * FROM expenseyear 	WHERE idexp = @idexp AND ayear = @nextayear)
	BEGIN
		DELETE FROM expenseyear WHERE idexp = @idexp and ayear = @nextayear  
		DELETE FROM csa_contractexpense  WHERE idexp = @idexp and ayear = @nextayear  
		DELETE FROM csa_contracttaxexpense  WHERE idexp = @idexp and ayear = @nextayear  
		UPDATE csa_contract set idexp_main=null  WHERE idexp_main = @idexp and ayear = @nextayear  
	END
	FETCH NEXT FROM exp_crs INTO @idexp 
END
DEALLOCATE exp_crs


EXEC closeyear_undo_casualcontract @ayear
EXEC closeyear_undo_wageaddition @ayear
EXEC closeyear_undo_epexparrearscopy @ayear



CREATE TABLE #info (msg varchar(800))
INSERT INTO #info
VALUES('Il trasferimento dei residui passivi all''esercizio ' + @nextayearstr + ' è stato annullato ')

INSERT INTO #info
VALUES('Il trasferimento degli impegni di budget, per la quota non pagata,  all''esercizio ' + @nextayearstr  + ' è stato annullato ')

	
-- Azzero i bit da 0 a 3 e imposto il valore 4 nell'esercizio corrente. (Pari alla fase precedente: trasferimento residui attivi)
UPDATE accountingyear SET flag = flag&0xF0 WHERE ayear = @ayear
UPDATE accountingyear SET flag = flag|0x04 WHERE ayear = @ayear
	
SELECT * FROM #info
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

