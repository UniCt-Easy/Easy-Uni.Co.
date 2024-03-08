
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_casualcontract]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_casualcontract]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE closeyear_casualcontract
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
	SELECT ycon, ncon, feegross FROM casualcontract WHERE ycon <= @ayear 
		AND NOT EXISTS
			(SELECT * FROM casualcontractyear
			WHERE casualcontract.ycon = casualcontractyear.ycon
				AND casualcontract.ncon = casualcontractyear.ncon
				AND ayear = @nextayear)
OPEN @cascon_crs
FETCH NEXT FROM @cascon_crs INTO @ycon, @ncon, @feegross
WHILE (@@FETCH_STATUS = 0)
BEGIN
	DECLARE @idexp varchar(40)
	DECLARE @curramount decimal(19,2)
	DECLARE @pettycashamount decimal(19,2)
	DECLARE @amount decimal(19,2)
	DECLARE @exp_crs cursor
	SET @exp_crs = CURSOR FOR
		SELECT expense.idexp, ISNULL(expenseyear_starting.amount, 0)
		FROM expensecasualcontract
		JOIN expenselink
			ON expenselink.idparent = expensecasualcontract.idexp
		JOIN expense
			ON expense.idexp = expenselink.idchild 
		LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  			ON expensetotal_firstyear.idexp = expense.idexp
  			AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
		WHERE ycon = @ycon
			AND ncon = @ncon
			AND expense.nphase = @maxexpensephase
	OPEN @exp_crs
	FETCH NEXT FROM @exp_crs into @idexp, @amount
	SET @curramount = 0
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SELECT @curramount = ISNULL(@curramount,0) + @amount + ISNULL(SUM(amount), 0)
		FROM expensevar
		WHERE idexp=@idexp
			AND ISNULL(autokind,0)<> 4 --RITENUTA
		FETCH NEXT FROM @exp_crs INTO @idexp, @amount
	END
        
        SELECT 	@pettycashamount = pettycashoperation.amount
                FROM pettycashoperationcasualcontract
                JOIN pettycashoperation
                	ON pettycashoperation.idpettycash = pettycashoperationcasualcontract.idpettycash
                	AND pettycashoperation.yoperation = pettycashoperationcasualcontract.yoperation
                	AND pettycashoperation.noperation = pettycashoperationcasualcontract.noperation
                WHERE 	pettycashoperationcasualcontract.ycon = @ycon AND pettycashoperationcasualcontract.ncon = @ncon
        
        DECLARE @residual decimal(19,2)
	SET @residual = @feegross - @curramount - isnull(@pettycashamount,0)
	IF (@residual>0)
	BEGIN
		DECLARE @activitycode varchar(20)
		DECLARE @idotherinsurance varchar(20)
		DECLARE @idemenscontractkind varchar(2)
		SELECT 
			@activitycode = casualcontractyear.activitycode, 
			@idotherinsurance = casualcontractyear.idotherinsurance, 
			@idemenscontractkind = casualcontractyear.idemenscontractkind
			FROM casualcontractyear 
			WHERE casualcontractyear.ayear = @ayear 
				AND casualcontractyear.ycon = @ycon
				AND casualcontractyear.ncon = @ncon
		INSERT INTO casualcontractyear
		(ayear, ycon, ncon, activitycode, idotherinsurance, idemenscontractkind,
		 taxableotheragency,flaghigherrate,higherrate)
		VALUES (@nextayear, @ycon, @ncon, @activitycode, @idotherinsurance, @idemenscontractkind,
			null,null,null)
	END
	FETCH NEXT FROM @cascon_crs into @ycon, @ncon, @feegross
END
END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

