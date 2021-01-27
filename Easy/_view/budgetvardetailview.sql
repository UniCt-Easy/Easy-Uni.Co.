
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


-- CREAZIONE VISTA budgetvardetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[budgetvardetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [budgetvardetailview]
GO
--select * from budgetvardetailview
CREATE       VIEW budgetvardetailview
(
	ybudgetvar,
	nbudgetvar,
	yvar,
	nvar,
	rownum,
	variationdescription,
	official,
	nofficial,
	idman,
	manager,
	idbudgetvarstatus,
	budgetvarstatus,
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	description,
	idupb,		
	codeupb,	
	upb,	
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	amount,
	annotation,
	adate,	
	cu,
	ct,
	lu,
	lt,
	flagactivity,
	activity,
	flagkind,
	kindd,
	kindr
	
)
AS SELECT
	budgetvardetail.ybudgetvar,
	budgetvardetail.nbudgetvar,
	budgetvar.yvar,
	budgetvar.nvar,
	budgetvardetail.rownum,
	budgetvar.description,
	budgetvar.official,
	budgetvar.nofficial,
	budgetvar.idman,
	manager.title,
	budgetvar.idbudgetvarstatus,
	budgetvarstatus.description,
	budgetvar.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	budgetvardetail.idsor,
	sorting.sortcode,
	sorting.description,
	budgetvardetail.description,
	upb.idupb,	
	upb.codeupb,		
	upb.title,	
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	budgetvardetail.amount,
	budgetvardetail.annotation,
	budgetvar.adate,	
	budgetvardetail.cu,
	budgetvardetail.ct,
	budgetvardetail.lu,
	budgetvardetail.lt,
	upb.flagactivity,
--	activity,
	case
	when upb.flagactivity ='1' then 'Istituzionale'
	when upb.flagactivity ='2' then 'Commerciale'
	-- when upb.flagactivity ='3' then 'p': l'upb non ha il promiscuo
	when upb.flagactivity ='4' then 'Qualsiasi/Non specificata'
	end,
	upb.flagkind,
--	kindd,
	CASE
		when (( upb.flagkind & 1)<> 0) then 'S'
	End,
--	kindr,
	CASE
		when (( upb.flagkind & 2)<>0) then 'S'
	End
FROM budgetvardetail with (nolock)
JOIN budgetvar with (nolock)
	ON budgetvardetail.ybudgetvar = budgetvar.ybudgetvar
	AND budgetvardetail.nbudgetvar = budgetvar.nbudgetvar
JOIN sortingkind with (nolock)
	ON budgetvar.idsorkind = sortingkind.idsorkind
JOIN sorting with (nolock)
	ON budgetvardetail.idsor = sorting.idsor
JOIN upb with (nolock)
	ON budgetvardetail.idupb=upb.idupb 	
LEFT OUTER JOIN manager with (nolock)
	ON manager.idman = budgetvar.idman
LEFT OUTER JOIN budgetvarstatus with (nolock)
	ON budgetvarstatus.idbudgetvarstatus = budgetvar.idbudgetvarstatus

GO

