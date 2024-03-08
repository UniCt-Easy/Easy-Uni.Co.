
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_mov_class_incomplete_o_mancanti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_mov_class_incomplete_o_mancanti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE                            PROCEDURE [rpt_mov_class_incomplete_o_mancanti]
	@ayear 	           smallint,
	@idsorkind   	   int,
	@incomeorexpense   char(1),
	@start	   smalldatetime,
	@stop	   smalldatetime
AS
BEGIN
/*
exec rpt_mov_class_incomplete_o_mancanti 2007,'SIOPE', 'E',{ts '2007-01-20 00:00:00'},{ts '2007-08-20 00:00:00'}

*/
	DECLARE @sortingkind	 varchar(50)
	SELECT @sortingkind = description 
		FROM sortingkind where idsorkind=@idsorkind

	DECLARE @nphase  tinyint 

	IF (@incomeorexpense = 'E')
	BEGIN
		SELECT @nphase = nphaseincome
		FROM sortingkind where idsorkind=@idsorkind

		SELECT
			@idsorkind as 'idsorkind',
			@sortingkind as 'sortingkind',
			incomeview.adate,
			incomeview.phase,
			incomeview.ymov,
			incomeview.nmov,
			incomeview.registry,
			incomeview.codefin,
			incomeview.codeupb,
			incomeview.description,
			isnull(incomeview.curramount,0) as 'curramount',
			isnull((select isnull(sum(incomesorted.amount),0) from incomesorted
				join sorting on sorting.idsor = incomesorted.idsor
			  where incomesorted.idinc=incomeview.idinc and
			        sorting.idsorkind =@idsorkind  and
				incomesorted.ayear=@ayear
			  ) ,0) as'sortedamount'
		FROM incomeview  
		WHERE incomeview.adate BETWEEN 
			isnull(@start, {d '1900-01-01'}) AND isnull(@stop, {d '2079-06-06'})
			AND incomeview.nphase = @nphase
			AND incomeview.ayear=@ayear
			AND ( isnull(incomeview.curramount,0) <> 
	                    			ISNULL( (SELECT sum(amount) 	FROM incomesorted
					                join sorting ON sorting.idsor = incomesorted.idsor
                       					WHERE sorting.idsorkind = @idsorkind
                         					AND incomesorted.idinc = incomeview.idinc
			 			AND incomesorted.ayear=@ayear),0))
		ORDER BY idsorkind ASC,adate ASC,ymov ASC,nmov ASC
	END

	IF (@incomeorexpense = 'S')
	BEGIN
		SELECT 	@nphase = nphaseexpense
		FROM sortingkind WHERE idsorkind=@idsorkind

		SELECT
			@idsorkind as 'idsorkind',
			@sortingkind as 'sortingkind',
			expenseview.adate,
			expenseview.phase,
			expenseview.ymov,
			expenseview.nmov,
			expenseview.registry,
			expenseview.codefin,
			expenseview.codeupb,
			expenseview.description,
			isnull(expenseview.curramount,0) as 'curramount',
			isnull((select isnull(sum(expensesorted.amount),0) 
			   from expensesorted
				join sorting on sorting.idsor = expensesorted.idsor
			  where expensesorted.idexp=expenseview.idexp and
			        sorting.idsorkind =@idsorkind and
				expensesorted.ayear=@ayear	
			) ,0) as 'sortedamount'
		FROM expenseview  
		WHERE expenseview.adate BETWEEN 
			isnull(@start, {d '1900-01-01'}) AND isnull(@stop, {d '2079-06-06'})
			AND expenseview.ayear = @ayear
			AND expenseview.nphase = @nphase
			AND (isnull(expenseview.curramount,0) <> 
                    			ISNULL( (SELECT sum(amount) 
                        				FROM expensesorted
							join sorting on expensesorted.idsor=sorting.idsor
                      					 WHERE sorting.idsorkind = @idsorkind
                         				AND expensesorted.idexp = expenseview.idexp
			 			AND expensesorted.ayear=@ayear
					),0)
			)
		ORDER BY idsorkind ASC,	adate ASC,ymov ASC,nmov ASC
		END
	END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

