
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


IF EXISTS(select * from sysobjects where id = object_id(N'[lcardvarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [lcardvarview]
GO


CREATE  VIEW [lcardvarview]
(
	ylvar,
	nlvar,
	idlcard,
	idlcardvar,
	amount,
	idupb,
	idfin,
	lt,
	lu,
	email,
	yvar,
	nvar,
	description,
	adate,
	title,
	lcard,
	extcode,
	codeupb,
	upb,
	paridupb,
	ayear,
	codefin,
	fin,
	nlevel,
	paridfin,
	parcodefin,
	parfintitle,
	parfinlevel,
	idman,
	manager,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT 
	lcardvar.ylvar,
	lcardvar.nlvar,
	lcardvar.idlcard,
	lcardvar.idlcardvar,
	lcardvar.amount,
	lcardvar.idupb,
	lcardvar.idfin,
	lcardvar.lt,
	lcardvar.lu,
	lcardvar.email,
	lcardvar.yvar,
	lcardvar.nvar,
	lcardvar.description,
	lcardvar.adate,
	lcard.title,
	lcard.description,
	lcard.extcode,
	upb.codeupb,
	upb.title,
	upb.paridupb,
	f.ayear,
	f.codefin,
	f.title,
	f.nlevel,
	f1.idfin,
	f1.codefin,
	f1.title,
	f1.nlevel,
	manager.idman,
	manager.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05
FROM lcardvar
	JOIN lcard
		ON lcardvar.idlcard = lcard.idlcard
	LEFT OUTER JOIN upb
		ON lcardvar.idupb = upb.idupb
	LEFT OUTER  JOIN fin f
		ON f.idfin = lcardvar.idfin
		AND f.ayear = lcardvar.ylvar
	LEFT OUTER JOIN fin f1
		ON f.paridfin = f1.idfin
		AND f.ayear = f1.ayear
	LEFT OUTER JOIN manager
		on lcard.idman= manager.idman





GO


