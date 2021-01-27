
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_varbudget]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_varbudget]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--	exec rpt_varbudget 2014, 1,1,'S',null,null,null,null,null

CREATE   PROCEDURE rpt_varbudget
	@ybudgetvar          	int, 
	@nbudgetvarbegin   	int,
	@nbudgetvarend     	int,
	@showupb char(1),
	@compress char(1),
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 
	AS
	BEGIN
declare @sortingkind varchar(50)
set @sortingkind = (select top 1 sortingkind.description 
	FROM budgetvardetail
	JOIN sorting
		ON sorting.idsor = budgetvardetail.idsor
	JOIN sortingkind
		on sorting.idsorkind = sortingkind.idsorkind
	WHERE budgetvardetail.ybudgetvar = @ybudgetvar
			AND ((budgetvardetail.nbudgetvar BETWEEN @nbudgetvarbegin AND @nbudgetvarend) OR 
		     	     (@nbudgetvarbegin IS NULL) OR (@nbudgetvarend IS NULL))
)
		SELECT  
			@sortingkind as 'sortingkind',
			SK.description as 'sortingkind01',
			S01.description as 'sorting01',
			budgetvar.ybudgetvar,
			budgetvar.nbudgetvar,
			budgetvar.description,
			budgetvar.adate,
			budgetvar.yvar,
			budgetvar.nvar
		FROM budgetvar 
		JOIN budgetvardetail
			ON budgetvar.ybudgetvar = budgetvardetail.ybudgetvar
			AND budgetvar.nbudgetvar = budgetvardetail.nbudgetvar
		JOIN upb
			ON budgetvardetail.idupb = upb.idupb		
		LEFT OUTER JOIN sorting S01
				ON budgetvar.idsor01 = S01.idsor
		LEFT OUTER JOIN sortingkind SK
				ON SK.idsorkind = S01.idsorkind
		WHERE
			budgetvar.ybudgetvar = @ybudgetvar
			AND ((budgetvar.nbudgetvar BETWEEN @nbudgetvarbegin AND @nbudgetvarend) OR 
		     	     (@nbudgetvarbegin IS NULL) OR (@nbudgetvarend IS NULL))
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)		     	     
		GROUP BY SK.description, S01.description, 
				budgetvar.ybudgetvar, budgetvar.nbudgetvar, budgetvar.description, budgetvar.adate,
				budgetvar.yvar, budgetvar.nvar
		ORDER BY budgetvar.nbudgetvar
		


END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
