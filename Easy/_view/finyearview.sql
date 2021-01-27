
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


-- CREAZIONE VISTA finyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[finyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finyearview]
GO




CREATE                                VIEW [finyearview]
(
	ayear,
	idfin,
	codefin,
	finance,
	flag,
	finpart,
	paridfin,
	nlevel,
	leveldescr,
	idupb,
	codeupb,
	upb,
	paridupb,
	prevision,
	secondaryprev,
	previousprevision,
	previoussecondaryprev,
	currentarrears,
	previousarrears,
	limit,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	ct,
	cu,
	lt,
	lu
)
AS
SELECT
finyear.ayear,
finyear.idfin,
fin.codefin,
fin.title,
fin.flag,
CASE
	WHEN ((fin.flag&1)=0) THEN 'E'
	WHEN ((fin.flag&1)=1) THEN 'S'
END,
fin.paridfin,
fin.nlevel,
finlevel.description,
finyear.idupb,
upb.codeupb,
upb.title,
upb.paridupb,
finyear.prevision,
finyear.secondaryprev,
finyear.previousprevision,
finyear.previoussecondaryprev,
finyear.currentarrears,
finyear.previousarrears,
finyear.limit,
finyear.prevision2,
finyear.prevision3,
finyear.prevision4,
finyear.prevision5,
upb.idsor01,
upb.idsor02,
upb.idsor03,
upb.idsor04,
upb.idsor05,	
finyear.ct,
finyear.cu,
finyear.lt,
finyear.lu
FROM finyear
JOIN fin
ON finyear.idfin = fin.idfin
JOIN upb
ON finyear.idupb = upb.idupb
JOIN finlevel
ON finlevel.nlevel = fin.nlevel
AND finlevel.ayear = fin.ayear






GO
