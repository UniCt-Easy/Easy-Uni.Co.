
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


-- CREAZIONE VISTA accountyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[accountyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [accountyearview]
GO




CREATE  VIEW accountyearview
(
	ayear,
	idacc,
	codeacc,
	account,
	idupb,
	codeupb,
	upb,
	paridacc,
	paridupb,
	nlevel,
	leveldescr,
	prevision,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	flagaccountusage,
	ct,
	cu,
	lt,
	lu
)
AS SELECT 
accountyear.ayear,
accountyear.idacc,
account.codeacc,
account.title,
upb.idupb,
upb.codeupb,
upb.title,
account.paridacc,
upb.paridupb,
account.nlevel,
accountlevel.description,
accountyear.prevision,
accountyear.prevision2,
	accountyear.prevision3,
	accountyear.prevision4,
	accountyear.prevision5,
upb.idsor01,
upb.idsor02,
upb.idsor03,
upb.idsor04,
upb.idsor05,	
account.flagaccountusage,
accountyear.ct,
accountyear.cu,
accountyear.lt,
accountyear.lu
FROM accountyear
JOIN account
	ON accountyear.idacc = account.idacc
JOIN upb
	ON upb.idupb = accountyear.idupb
JOIN accountlevel
	ON accountlevel.nlevel = account.nlevel
	AND accountlevel.ayear = account.ayear





GO
