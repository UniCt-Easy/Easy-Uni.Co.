
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_sortedmovementtotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_sortedmovementtotal]
GO

CREATE PROCEDURE [rebuild_sortedmovementtotal]
(@ayear int = NULL)
AS BEGIN
DELETE FROM sortedmovementtotal WHERE (@ayear IS NULL) OR (ayear=@ayear)
DECLARE @currentyear int
DECLARE ayear_cursor INSENSITIVE CURSOR FOR
SELECT ayear FROM accountingyear WHERE (@ayear IS NULL) OR (ayear=@ayear)
ORDER BY ayear 
OPEN ayear_cursor
FETCH NEXT FROM ayear_cursor INTO @currentyear
WHILE (@@FETCH_STATUS = 0)
BEGIN
	INSERT INTO sortedmovementtotal 
	(
		idsor,
		ayear
	)
	SELECT
		sorting.idsor,
		accountingyear.ayear
	FROM sorting 
	cross join accountingyear 
	WHERE accountingyear.ayear = @currentyear

	UPDATE sortedmovementtotal
	SET totincomevariation = 
	(
		SELECT SUM(sortingprevincomevar.amount)
		FROM sortingprevincomevar
		WHERE sortingprevincomevar.idsor = sortedmovementtotal.idsor
			AND sortingprevincomevar.yvar = @currentyear
	)
	WHERE ayear = @currentyear

	UPDATE sortedmovementtotal
	SET totexpensevariation = 
	(
		SELECT SUM(sortingprevexpensevar.amount)
		FROM sortingprevexpensevar
		WHERE sortingprevexpensevar.idsor = sortedmovementtotal.idsor
			AND sortingprevexpensevar.yvar = @currentyear
	)
	WHERE ayear = @currentyear

	UPDATE sortedmovementtotal
	SET totalincome = 
	(
		SELECT SUM(incomesorted.amount)
		FROM incomesorted
		WHERE incomesorted.idsor = sortedmovementtotal.idsor
			AND incomesorted.ayear = @currentyear
	)
	WHERE ayear = @currentyear

	UPDATE sortedmovementtotal
	SET totexpense = 
	(
		SELECT SUM(expensesorted.amount)
		FROM expensesorted
		WHERE expensesorted.idsor = sortedmovementtotal.idsor
			AND expensesorted.ayear = @currentyear
	)			
	WHERE ayear = @currentyear

	UPDATE sortedmovementtotal SET totalmakings = 0, totalcost = 0 WHERE ayear = @currentyear
	FETCH NEXT FROM ayear_cursor INTO @currentyear
END
CLOSE ayear_cursor
DEALLOCATE ayear_cursor
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

