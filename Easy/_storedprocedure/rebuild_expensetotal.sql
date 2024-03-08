
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



SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_expensetotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_expensetotal]
GO

CREATE   PROCEDURE  rebuild_expensetotal
(
	@ayear int =  NULL
)
AS BEGIN
	
	DECLARE @curryear int
	DELETE from expensetotal where (@ayear is null)  OR ayear=@ayear
	
	declare @minfinyear int
	select @minfinyear=min(ayear) from fin

	DECLARE @finphase tinyint
	SELECT @finphase = expensefinphase FROM uniconfig

-- Bisogna valorizzare il campo flag
--bit 0: flagarrear
--bit 1: firstyear
		INSERT INTO expensetotal 
		(
			idexp,
			ayear,
			curramount,
			flag
		)
		SELECT
			expenseyear.idexp,
			expenseyear.ayear,
			expenseyear.amount,
		CASE
			WHEN expense.nphase < @finphase
			THEN 0
			WHEN (SELECT e2.ymov
				FROM expenselink
				JOIN expense e2
					ON expenselink.idparent = e2.idexp
				WHERE expenselink.idchild = expense.idexp
				AND expenselink.nlevel = @finphase) = expenseyear.ayear THEN 0
			ELSE 1
		END +
		CASE
			WHEN expense.ymov = expenseyear.ayear or expenseyear.ayear=@minfinyear THEN 2
			ELSE 0
		END 
		FROM expenseyear
		JOIN expense
			ON expense.idexp = expenseyear.idexp
		WHERE  (@ayear is null)  OR ayear=@ayear;

		with sumvar(idexp,yvar,amount) as 
		(select idexp,yvar,sum(amount) from expensevar 
				where (@ayear is null) OR expensevar.yvar=@ayear
				group by idexp,yvar)
		update expensetotal set curramount = isnull(curramount,0) + sumvar.amount
		from expensetotal
		join sumvar on expensetotal.idexp=sumvar.idexp 
					and expensetotal.ayear=sumvar.yvar
		where (@ayear is null) OR expensetotal.ayear=@ayear
		 
	;
		with sumexptot(idexp,ayear,amount) as
		(select E.parentidexp, ET.ayear, SUM(ET.curramount) from 
				expensetotal ET
				join expense e on e.idexp=ET.idexp
				WHERE  (@ayear is null) OR ET.ayear=@ayear
				group by E.parentidexp, ET.ayear
		)
		UPDATE expensetotal
		SET available = ISNULL(ET.curramount, 0) - isnull(SE.amount,0)
		from expensetotal ET
		left outer join sumexptot SE 
			on ET.idexp=SE.idexp and ET.ayear=SE.ayear 
		where (@ayear is null) OR ET.ayear=@ayear
;

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--rebuild_expensetotal

