
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


-- CREAZIONE VISTA upbfinused
IF EXISTS(select * from sysobjects where id = object_id(N'[upbfinused]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbfinused]
GO




CREATE  VIEW [upbfinused]
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
	totalarrears,
	totalcompetency,
	creditvariation,
	previsionvariation,
	proceedsvariation,
	secondaryvariation,
	totcreditpart,
	totproceedspart,
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
fin.ayear,--finyear.ayear,
upbtotal.idfin,--finyear.idfin,
fin.codefin,
fin.title,
fin.flag,
CASE
	WHEN ((fin.flag&1)=0) THEN 'E'
	WHEN ((fin.flag&1)=1) THEN 'S'
END as finpart,
fin.paridfin,
fin.nlevel,
finlevel.description,
upbtotal.idupb,--finyear.idupb,
upb.codeupb,
upb.title,
upb.paridupb,
ISNULL(finyear.prevision,0),
ISNULL(finyear.secondaryprev,0),
CASE 
	WHEN ((fin.flag&1)=0) THEN
	ISNULL(upbincometotal.totalarrears,0)
	ELSE
	ISNULL(upbexpensetotal.totalarrears,0)
END as totalarrears,
CASE 
	WHEN ((fin.flag&1)=0) THEN
	ISNULL(upbincometotal.totalcompetency,0)
	ELSE
	ISNULL(upbexpensetotal.totalcompetency,0)
END as totalcompetency,
ISNULL(upbtotal.creditvariation,0),
ISNULL(upbtotal.previsionvariation,0),
ISNULL(upbtotal.proceedsvariation,0),
ISNULL(upbtotal.secondaryvariation,0),
ISNULL(upbtotal.totcreditpart,0),
ISNULL(upbtotal.totproceedspart,0),
ISNULL(finyear.limit,0),
ISNULL(finyear.prevision2,0),
ISNULL(finyear.prevision3,0),
ISNULL(finyear.prevision4,0),
ISNULL(finyear.prevision5,0),
upb.idsor01,
upb.idsor02,
upb.idsor03,
upb.idsor04,
upb.idsor05,
finyear.ct,
finyear.cu,
finyear.lt,
finyear.lu

FROM upbtotal
JOIN fin
	ON upbtotal.idfin = fin.idfin
JOIN upb
	ON upbtotal.idupb = upb.idupb
JOIN finlevel
	ON finlevel.nlevel = fin.nlevel
	AND finlevel.ayear = fin.ayear
LEFT OUTER JOIN upbincometotal
	ON upbincometotal.idupb = upbtotal.idupb
	AND upbincometotal.idfin = upbtotal.idfin
	AND upbincometotal.nphase = (select incomefinphase from uniconfig)
	LEFT OUTER JOIN upbexpensetotal
ON upbexpensetotal.idupb = upbtotal.idupb
	AND upbexpensetotal.idfin = upbtotal.idfin
	AND upbincometotal.nphase = (select expensefinphase from uniconfig)
LEFT OUTER JOIN finyear
	ON upbtotal.idupb = finyear.idupb
	AND upbtotal.idfin = finyear.idfin
WHERE
	ISNULL(finyear.prevision,0) <> 0 OR
	ISNULL(finyear.secondaryprev,0) <> 0 OR
	ISNULL(upbincometotal.totalarrears,0) <> 0 OR
	ISNULL(upbincometotal.totalcompetency,0) <> 0 OR
	ISNULL(upbexpensetotal.totalarrears,0) <> 0 OR
	ISNULL(upbexpensetotal.totalcompetency,0) <> 0 OR
	ISNULL(upbtotal.creditvariation,0) <> 0 OR
	ISNULL(upbtotal.previsionvariation,0) <> 0 OR
	ISNULL(upbtotal.proceedsvariation,0) <> 0 OR
	ISNULL(upbtotal.secondaryvariation,0) <> 0 OR
	ISNULL(upbtotal.totcreditpart,0) <> 0 OR
	ISNULL(upbtotal.totproceedspart,0) <> 0



GO
