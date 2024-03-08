
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_attobudget_previsione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_attobudget_previsione]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--	exec exp_attobudget_previsione 2015, 9, 35,null,null,null,null,null
-- exec exp_attobudget_previsione 2015, 2, 35,null,null,null,null,null
CREATE   PROCEDURE exp_attobudget_previsione
	@yvar          	int, 
	@nenactment		int,
	@idsorkind_econ int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 
	AS
BEGIN
	DECLARE @yenactment int
	DECLARE @idenactment int
	
	SET 	@yenactment = @yvar
	SET     @idenactment = 	 (SELECT idenactment
						FROM enactment 
						WHERE enactment.yenactment = @yenactment  AND enactment.nenactment = @nenactment)
	SELECT   	
		@yvar as 'Esercizio',
		@nenactment as 'Num.Atto',
		budgetvar.nbudgetvar as'Num.Prot.Var.Budget',
		budgetvar.nofficial as 'Num.Uff.Var.Budget',
		finvar.nvar as'Num.Prot. Var Finanziaria',
		finvar.nofficial as'Num.Uff. Var Finanziaria',
		S.sortcode as'Voce di budget',
		CASE
			when (( fin.flag & 1)=0) then 'E'
			when (( fin.flag & 1)=1) then 'S'
		End as 'E/S',
		finvardetail.amount as 'Importo (finanziario)',
		budgetvardetail.amount  as 'Importo (budget)' ,
		upb.codeupb+'-'+	upb.title as 'UPB',
		budgetvar.description as 'Descrizione'
	FROM budgetvardetail
	JOIN budgetvar 
		ON  budgetvardetail.ybudgetvar = budgetvar.ybudgetvar 
		AND budgetvardetail.nbudgetvar = budgetvar.nbudgetvar
	join sorting S
		on budgetvardetail.idsor = S.idsor
	JOIN upb
		ON upb.idupb = budgetvardetail.idupb 
	join finvar
		on  finvar.yvar = budgetvar.yvar 
		and finvar.nvar = budgetvar.nvar
	join finvardetail
		on  finvardetail.yvar = budgetvar.yvar 
		and finvardetail.nvar = budgetvar.nvar 
		and finvardetail.rownum = budgetvardetail.rownum
	JOIN fin	
		on fin.idfin = finvardetail.idfin
	join finsortingview 
		on S.idsor = finsortingview.idsor and finsortingview.idsorkind = @idsorkind_econ
	WHERE budgetvar.yvar = @yvar
		AND (finvar.idenactment = @idenactment)
		and S.idsorkind = @idsorkind_econ
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
UNION

SELECT   	
		@yvar as 'Esercizio',
		@nenactment as 'Num.Atto',
		budgetvar.nbudgetvar as'Num.Prot.Var.Budget',
		budgetvar.nofficial as 'Num.Uff.Var.Budget',
		finvar.nvar as'Num.Prot. Var Finanziaria',
		finvar.nofficial as'Num.Uff. Var Finanziaria',
		'NON MAPPATA'as'Voce di budget',
		CASE
			when (( fin.flag & 1)=0) then 'E'
			when (( fin.flag & 1)=1) then 'S'
		End as 'E/S',
		finvardetail.amount as 'Importo (finanziario)',
		0 as 'Importo (budget)' ,
		upb.codeupb+'-'+	upb.title as 'UPB',
		budgetvar.description as 'Descrizione'
	FROM budgetvardetail
	JOIN budgetvar 
		ON  budgetvardetail.ybudgetvar = budgetvar.ybudgetvar 
		AND budgetvardetail.nbudgetvar = budgetvar.nbudgetvar
	join sorting S
		on budgetvardetail.idsor = S.idsor
	join finvar
		on  finvar.yvar = budgetvar.yvar 
		and finvar.nvar = budgetvar.nvar
	join finvardetail
		on  finvardetail.yvar = finvar.yvar 
		and finvardetail.nvar = finvar.nvar 
	JOIN fin	
		on fin.idfin = finvardetail.idfin
	JOIN upb
		ON upb.idupb = finvardetail.idupb 
	WHERE budgetvar.yvar = @yvar
		AND (finvar.idenactment = @idenactment)
		and S.idsorkind = @idsorkind_econ
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		and (select count(*) from budgetvardetail BVD
				join budgetvar BV
					ON  BVD.ybudgetvar = BV.ybudgetvar 
					AND BVD.nbudgetvar = BV.nbudgetvar
			where  finvardetail.yvar = BV.yvar 
			and finvardetail.nvar = BV.nvar 
			and finvardetail.rownum = BVD.rownum)=0
	ORDER BY budgetvar.nbudgetvar--, S.sortcode





  
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
