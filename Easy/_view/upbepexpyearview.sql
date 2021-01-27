
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


-- CREAZIONE VISTA [upbepexpyearview]
IF EXISTS(select * from sysobjects where id = object_id(N'[upbepexpyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbepexpyearview]
GO


CREATE     VIEW  [upbepexpyearview] 
(
	idupb,
	codeupb,
	upb,
	idman,
	manager,
	iddivision,
	codedivision,
	division,
	requested,
	granted,
	assured,
	ayear,
	currentprev,
	previsionvariation,
	appropriation,
	available,
	currentprev2,
	previsionvariation2,
	appropriation2,
	available2,
	currentprev3,
	previsionvariation3,
	appropriation3,
	available3,
	currentprev4,
	previsionvariation4,
	appropriation4,
	available4,
	currentprev5,
	previsionvariation5,
	appropriation5,
	available5,
	active,
	cupcode,
	printingorder,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	flagactivity,
	activity,
	flagkind,
	kindd,
	kindr,
	idtreasurer,
	treasurer,	
	start,
	stop,
	cigcode,
	cu,
	ct,
	lu,
	lt,
	revenueprevision,
	costprevision
)

AS SELECT
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idman,
	manager.title,
	division.iddivision,
	division.codedivision,
	division.description,
	upb.requested,
	upb.granted,
	upb.assured,
	accountingyear.ayear,
	-- currentprev
	ISNULL(
		(SELECT SUM(upbaccounttotal.currentprev)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
)
	,0),
	-- previsionvariation
	ISNULL(
		(SELECT SUM(upbaccounttotal.previsionvariation)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
)
	,0),
	ISNULL(
		(SELECT SUM(upbepexptotal.total)
		FROM    upbepexptotal
		JOIN    account
			ON account.idacc = upbepexptotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbepexptotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
		AND nphase = 1)
	,0),
	-----------------------------------------
	-----------------------------------------
	--available
	ISNULL(
		(SELECT SUM(upbaccounttotal.currentprev)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
)
	,0)
	+ 
	ISNULL(
		(SELECT SUM(upbaccounttotal.previsionvariation)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
)
	,0)
	-
	ISNULL(
		(SELECT SUM(upbepexptotal.total)
		FROM    upbepexptotal
		JOIN    account
			ON account.idacc = upbepexptotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbepexptotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
		AND nphase = 1)
	,0)
	 ,
	-----------------------------------------
	-----------------------------------------
	-- currentprev2
	ISNULL(
		(SELECT SUM(upbaccounttotal.currentprev2)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
)
	,0),
	-- previsionvariation2
	ISNULL(
		(SELECT SUM(upbaccounttotal.previsionvariation2)
		FROM    upbaccounttotal
		JOIN    account
			ON  account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
)
	,0),
	ISNULL(
		(SELECT SUM(upbepexptotal.total2)
		FROM    upbepexptotal
		JOIN    account
			ON account.idacc = upbepexptotal.idacc
		WHERE   account.ayear = accountingyear.ayear
	 
		AND upbepexptotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
		AND nphase = 1)
	,0),
	--available2
	ISNULL(
		(SELECT SUM(upbaccounttotal.currentprev2)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
)
	,0)
	+ 
	-- previsionvariation
	ISNULL(
		(SELECT SUM(upbaccounttotal.previsionvariation2)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
)
	,0)
	-
	ISNULL(
		(SELECT SUM(upbepexptotal.total2)
		FROM    upbepexptotal
		JOIN    account
			ON account.idacc = upbepexptotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbepexptotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
		AND nphase = 1)
	,0)
	,
	-- currentprev3
	ISNULL(
		(SELECT SUM(upbaccounttotal.currentprev3)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
)
	,0),
	-- previsionvariation3
	ISNULL(
		(SELECT SUM(upbaccounttotal.previsionvariation3)
		FROM    upbaccounttotal
		JOIN    account
			ON  account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
)
	,0),
	ISNULL(
		(SELECT SUM(upbepexptotal.total3)
		FROM    upbepexptotal
		JOIN    account
			ON account.idacc = upbepexptotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbepexptotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
		AND nphase = 1)
	,0),
	--available3
	ISNULL(
		(SELECT SUM(upbaccounttotal.currentprev3)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
		)
	,0)
	+ 
	ISNULL(
		(SELECT SUM(upbaccounttotal.previsionvariation3)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S'))
	,0)
	-
	ISNULL(
		(SELECT SUM(upbepexptotal.total3)
		FROM    upbepexptotal
		JOIN    account
			ON account.idacc = upbepexptotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbepexptotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
				AND nphase = 1)
	,0)
	,
	-- currentprev4
	ISNULL(
		(SELECT SUM(upbaccounttotal.currentprev4)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S'))
	,0),
	-- previsionvariation4
	ISNULL(
		(SELECT SUM(upbaccounttotal.previsionvariation4)
		FROM    upbaccounttotal
		JOIN    account
			ON  account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S'))
	,0),
	ISNULL(
		(SELECT SUM(upbepexptotal.total4)
		FROM    upbepexptotal
		JOIN    account
			ON account.idacc = upbepexptotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbepexptotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
		AND nphase = 1)
	,0),
	--available4
	ISNULL(
		(SELECT SUM(upbaccounttotal.currentprev4)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S'))
	,0)
	+ 
	ISNULL(
		(SELECT SUM(upbaccounttotal.previsionvariation4)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S'))
	,0)
	-
	ISNULL(
		(SELECT SUM(upbepexptotal.total4)
		FROM    upbepexptotal
		JOIN    account
			ON account.idacc = upbepexptotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbepexptotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
		AND nphase = 1)
	,0),
	-- currentprev5
	ISNULL(
		(SELECT SUM(upbaccounttotal.currentprev5)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S'))
	,0),
	-- previsionvariation5
	ISNULL(
		(SELECT SUM(upbaccounttotal.previsionvariation5)
		FROM    upbaccounttotal
		JOIN    account
			ON  account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S'))
	,0),
	ISNULL(
		(SELECT SUM(upbepexptotal.total5)
		FROM    upbepexptotal
		JOIN    account
			ON account.idacc = upbepexptotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbepexptotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
		AND nphase = 1)
	,0),
	--available5
	ISNULL(
		(SELECT SUM(upbaccounttotal.currentprev5)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S'))
	,0)
	+ 
	ISNULL(
		(SELECT SUM(upbaccounttotal.previsionvariation5)
		FROM    upbaccounttotal
		JOIN    account
			ON account.idacc = upbaccounttotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbaccounttotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S'))
	,0)
	-
	ISNULL(
		(SELECT SUM(upbepexptotal.total5)
		FROM    upbepexptotal
		JOIN    account
			ON account.idacc = upbepexptotal.idacc
		WHERE   account.ayear = accountingyear.ayear
		AND upbepexptotal.idupb = upb.idupb
		AND account.nlevel  = (SELECT MIN(nlevel) 
					 FROM accountlevel 
					WHERE ayear = account.ayear AND  ISNULL(flagusable,'N') = 'S')
		AND nphase = 1)
	,0),
	upb.active,
	upb.cupcode,
	upb.printingorder,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
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
	End,
	upb.idtreasurer,
	treasurer.description,
	upb.start,
	upb.stop,
	upb.cigcode,
	upb.cu,
	upb.ct,
	upb.lu,
	upb.lt,
	upbyear.revenueprevision,
	upbyear.costprevision
FROM upb
CROSS JOIN accountingyear
JOIN config
	ON config.ayear = accountingyear.ayear
LEFT OUTER JOIN manager
	ON upb.idman = manager.idman
LEFT OUTER JOIN division
	ON division.iddivision = manager.iddivision
LEFT OUTER JOIN treasurer
	ON treasurer.idtreasurer = upb.idtreasurer
LEFT OUTER JOIN upbyear
	on upbyear.idupb = upb.idupb and upbyear.ayear = accountingyear.ayear
GO


